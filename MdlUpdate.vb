Imports System.IO
Imports System.Net
Imports System.Xml
Imports System.Security.Cryptography
Imports System.Reflection
Imports System.Diagnostics
Imports Newtonsoft.Json

Public Class UpdateManifest
    Public Property latestVersion As String
    Public Property minVersion As String
    Public Property isRequired As Boolean
    Public Property releaseNotes As String
    Public Property downloadUrl As String
    Public Property fileHash As String
    Public Property fileSize As Long
End Class

Module MdlUpdate
    Private ReadOnly _configFile As String = Path.Combine(Application.StartupPath, "update.config")
    Private ReadOnly _updateDir As String = Path.Combine(Application.StartupPath, "update")

    Public Sub StartupCheck()
        Try
            If Not ShouldCheck() Then
                Return
            End If

            Dim manifest = FetchManifest()
            If manifest Is Nothing Then
                Return
            End If

            If IsNewerVersion(manifest) Then
                Dim downloadForm As New FrmUpdateProgress(manifest)
                If downloadForm.ShowDialog() = DialogResult.OK Then
                    If downloadForm.DownloadedFilePath IsNot Nothing Then
                        If VerifyHash(downloadForm.DownloadedFilePath, manifest.fileHash) Then
                            ExtractToUpdateDir(downloadForm.DownloadedFilePath)
                            RecordCheckTime()
                        Else
                            File.Delete(downloadForm.DownloadedFilePath)
                        End If
                    End If
                End If
            Else
                RecordCheckTime()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub HttpUpdate(ByRef success As Boolean)
        success = False
        Try
            Dim manifest = FetchManifest()
            If manifest Is Nothing Then
                Return
            End If

            If IsNewerVersion(manifest) Then
                Dim downloadForm As New FrmUpdateProgress(manifest)
                If downloadForm.ShowDialog() = DialogResult.OK Then
                    If downloadForm.DownloadedFilePath IsNot Nothing Then
                        If VerifyHash(downloadForm.DownloadedFilePath, manifest.fileHash) Then
                            ExtractToUpdateDir(downloadForm.DownloadedFilePath)
                            RecordCheckTime()
                            success = True
                        Else
                            File.Delete(downloadForm.DownloadedFilePath)
                        End If
                    End If
                End If
            Else
                RecordCheckTime()
                success = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Function ShouldCheck() As Boolean
        If Not File.Exists(_configFile) Then
            CreateDefaultConfig()
            Return False
        End If

        Dim doc As New XmlDocument()
        doc.Load(_configFile)
        Dim node = doc.SelectSingleNode("updateConfig/lastHttpCheck")
        If node Is Nothing Then
            Return True
        End If

        Dim lastCheck As DateTime
        If Not DateTime.TryParse(node.InnerText, lastCheck) Then
            Return True
        End If

        Return (DateTime.Now - lastCheck).TotalDays >= 7
    End Function

    Private Function FetchManifest() As UpdateManifest
        If Not File.Exists(_configFile) Then
            Return Nothing
        End If

        Dim doc As New XmlDocument()
        doc.Load(_configFile)
        Dim urlNode = doc.SelectSingleNode("updateConfig/updateUrl")
        If urlNode Is Nothing Then
            Return Nothing
        End If

        Dim baseUrl = urlNode.InnerText.TrimEnd("/"c)
        Dim manifestUrl = baseUrl & "/version.json"

        Using client As New WebClient()
            client.Headers.Add("User-Agent", "RC3-Update-Checker")
            Dim json = client.DownloadString(manifestUrl)
            Return JsonConvert.DeserializeObject(Of UpdateManifest)(json)
        End Using
    End Function

    Private Function IsNewerVersion(ByVal manifest As UpdateManifest) As Boolean
        Dim current As Version
        Try
            current = New Version(Application.ProductVersion)
        Catch
            current = New Version("1.0")
        End Try

        Dim latest As Version
        Try
            latest = New Version(manifest.latestVersion)
        Catch
            Return False
        End Try

        Return latest > current
    End Function

    Public Function VerifyHash(ByVal filePath As String, ByVal expectedHash As String) As Boolean
        If String.IsNullOrEmpty(expectedHash) Then
            Return True
        End If

        Try
            Using stream = File.OpenRead(filePath)
                Using sha = SHA256.Create()
                    Dim hash = sha.ComputeHash(stream)
                    Dim hashStr = BitConverter.ToString(hash).Replace("-", "").ToLower()
                    Return hashStr = expectedHash.ToLower()
                End Using
            End Using
        Catch
            Return False
        End Try
    End Function

    Public Sub ExtractToUpdateDir(ByVal zipPath As String)
        ' 解压到临时目录
        Dim tempExtractDir = Path.Combine(Path.GetTempPath(), "rc3_update_extract")
        If Directory.Exists(tempExtractDir) Then
            Try : Directory.Delete(tempExtractDir, True) : Catch : End Try
        End If
        Directory.CreateDirectory(tempExtractDir)

        System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, tempExtractDir)
        File.Delete(zipPath)

        ' 确保 RC3Updater.exe 在启动目录
        Dim updaterSrc = Path.Combine(tempExtractDir, "RC3Updater.exe")
        Dim updaterDst = Path.Combine(Application.StartupPath, "RC3Updater.exe")
        If File.Exists(updaterSrc) Then
            If File.Exists(updaterDst) Then
                Try : File.Delete(updaterDst) : Catch : End Try
            End If
            File.Copy(updaterSrc, updaterDst)

            ' 启动 RC3Updater，然后退出主程序
            Dim currentVersion = Application.ProductVersion
            Dim pid = Process.GetCurrentProcess().Id
            Try
                Process.Start(updaterDst,
                    """" & Application.StartupPath & """ """ & tempExtractDir & """ " & pid.ToString() & " " & currentVersion)
                Application.Exit()
            Catch
            End Try
        End If
    End Sub

    Private Sub RecordCheckTime()
        If Not File.Exists(_configFile) Then
            CreateDefaultConfig()
        End If

        Dim doc As New XmlDocument()
        doc.Load(_configFile)
        Dim node = doc.SelectSingleNode("updateConfig/lastHttpCheck")
        If node Is Nothing Then
            node = doc.CreateElement("lastHttpCheck")
            doc.SelectSingleNode("updateConfig").AppendChild(node)
        End If
        node.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        doc.Save(_configFile)
    End Sub

    Private Sub CreateDefaultConfig()
        Dim dir = Path.GetDirectoryName(_configFile)
        If Not Directory.Exists(dir) Then
            Directory.CreateDirectory(dir)
        End If

        Dim doc As New XmlDocument()
        Dim decl = doc.CreateXmlDeclaration("1.0", "utf-8", Nothing)
        doc.AppendChild(decl)

        Dim root = doc.CreateElement("updateConfig")
        doc.AppendChild(root)

        Dim url = doc.CreateElement("updateUrl")
        url.InnerText = "https://richen.dpdns.org/downloads/rc3"
        root.AppendChild(url)

        Dim lastCheck = doc.CreateElement("lastHttpCheck")
        lastCheck.InnerText = ""
        root.AppendChild(lastCheck)

        doc.Save(_configFile)
    End Sub
End Module
