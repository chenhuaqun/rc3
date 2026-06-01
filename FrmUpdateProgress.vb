Imports System.IO
Imports System.Net
Imports System.ComponentModel

Public Class FrmUpdateProgress
    Private _manifest As UpdateManifest
    Private _downloadPath As String
    Private _cancelled As Boolean = False
    Private _client As WebClient

    Public ReadOnly Property DownloadedFilePath As String
        Get
            Return _downloadPath
        End Get
    End Property

    Public Sub New(ByVal manifest As UpdateManifest)
        InitializeComponent()
        _manifest = manifest
        Me.LabelVersion.Text = "最新版本：" & manifest.latestVersion
        If manifest.fileSize > 0 Then
            Me.LabelFileSize.Text = FormatSize(manifest.fileSize)
        Else
            Me.LabelFileSize.Text = ""
        End If
        Me.ProgressBarMain.Value = 0
        Me.ProgressBarMain.Maximum = 100
    End Sub

    Private Sub FrmUpdateProgress_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        StartDownload()
    End Sub

    Private Sub StartDownload()
        Try
            Dim tempDir = Path.Combine(Path.GetTempPath(), "rc3_update")
            If Not Directory.Exists(tempDir) Then
                Directory.CreateDirectory(tempDir)
            End If

            Dim fileName = Path.GetFileName(New Uri(_manifest.downloadUrl).LocalPath)
            _downloadPath = Path.Combine(tempDir, fileName)

            _client = New WebClient()
            _client.Headers.Add("User-Agent", "RC3-Update-Checker")

            AddHandler _client.DownloadProgressChanged, AddressOf OnDownloadProgressChanged
            AddHandler _client.DownloadFileCompleted, AddressOf OnDownloadCompleted

            _client.DownloadFileAsync(New Uri(_manifest.downloadUrl), _downloadPath)
        Catch ex As Exception
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End Try
    End Sub

    Private Sub OnDownloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        If Me.InvokeRequired Then
            Me.Invoke(New Action(Of Object, DownloadProgressChangedEventArgs)(AddressOf OnDownloadProgressChanged), sender, e)
            Return
        End If

        Me.ProgressBarMain.Value = e.ProgressPercentage
        Me.LabelProgress.Text = FormatSize(e.BytesReceived) & " / " & FormatSize(e.TotalBytesToReceive)
    End Sub

    Private Sub OnDownloadCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
        If Me.InvokeRequired Then
            Me.Invoke(New Action(Of Object, AsyncCompletedEventArgs)(AddressOf OnDownloadCompleted), sender, e)
            Return
        End If

        If e.Cancelled Then
            _cancelled = True
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
            Return
        End If

        If e.Error IsNot Nothing Then
            MsgBox("下载失败：" & e.Error.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
            Return
        End If

        If _downloadPath IsNot Nothing AndAlso File.Exists(_downloadPath) Then
            Me.DialogResult = DialogResult.OK
        Else
            Me.DialogResult = DialogResult.Cancel
        End If
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnCancel.Click
        BtnCancel.Enabled = False
        Me.LabelProgress.Text = "正在取消..."
        If _client IsNot Nothing AndAlso _client.IsBusy Then
            _client.CancelAsync()
        End If
    End Sub

    Private Function FormatSize(ByVal bytes As Long) As String
        If bytes <= 0 Then Return "0 B"
        Dim sizes = {"B", "KB", "MB", "GB"}
        Dim i = 0
        Dim size = CDbl(bytes)
        While size >= 1024 AndAlso i < sizes.Length - 1
            size /= 1024
            i += 1
        End While
        Return size.ToString("F1") & " " & sizes(i)
    End Function
End Class
