Imports System.IO
Imports System.Data.OleDb
Imports Oracle.DataAccess.Client

Public Class FrmUploadFile
#Region "定义变量"

    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '选择文件
    ReadOnly OpenFileDialog1 As New OpenFileDialog

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
        OpenFileDialog1.Filter = "所有文件(*.*)|*.*"
        If (OpenFileDialog1.ShowDialog(Me) = DialogResult.OK) Then
            Me.TextBox1.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If Not File.Exists(Me.TextBox1.Text) Then
            MsgBox("文件不存在。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        Me.LblMsg.Text = "1"
        '读入文件数据 
        Dim rcFileStream As New FileStream(Trim(Me.TextBox1.Text), IO.FileMode.Open, IO.FileAccess.Read)
        Dim imgData(rcFileStream.Length - 1) As Byte
        rcFileStream.Read(imgData, 0, rcFileStream.Length - 1)
        rcFileStream.Close()
        Me.LblMsg.Text = "2"
        '读取数据库连接字符串
        Dim c As New models.rcCryptography
        Dim rcStreamReader As StreamReader
        Dim FileName As String = Application.StartupPath + "\richen.config"
        If Not File.Exists(FileName) Then
            Return
        End If
        rcStreamReader = File.OpenText(FileName)
        Dim rcOracleConnection As New OracleConnection("Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = " & c.DeCryptography(rcStreamReader.ReadLine) & ")(PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = " & c.DeCryptography(rcStreamReader.ReadLine) & ")));User ID=" & c.DeCryptography(rcStreamReader.ReadLine) & ";Password=" & c.DeCryptography(rcStreamReader.ReadLine))
        rcStreamReader.Close()
        Try
            '取服务器名
            sysOleDbConn.Open()
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT host,servicename FROM rc_dwdm GROUP BY host,servicename ORDER BY host,servicename"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_dwdm") IsNot Nothing Then
                Me.rcDataset.Tables("rc_dwdm").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_dwdm")
        Catch ex As Exception
            MsgBox("程序错误7。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            sysOleDbConn.Close()
        End Try

        'REM 增加保存
        '建立命令
        Dim rcOracleCommand As OracleCommand = rcOracleConnection.CreateCommand()
        Me.LblMsg.Text = "3"
        Dim i As Integer
        For i = 0 To rcDataset.Tables("rc_dwdm").Rows.Count - 1
            Try
                '’rcOracleConnection.ConnectionString = "Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = " & rcDataset.Tables("rc_dwdm").Rows(i).Item("host") & ")(PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = " & rcDataset.Tables("rc_dwdm").Rows(i).Item("servicename") & ")));User ID=rcsystem;Password=123456"
                rcOracleConnection.Open()
                rcOracleCommand.Connection = rcOracleConnection
                rcOracleCommand.CommandTimeout = 300
                rcOracleCommand.CommandType = CommandType.Text
                Me.LblMsg.Text = "4"
                rcOracleCommand.CommandText = "Delete FROM rc_file WHERE fname = :fname"
                rcOracleCommand.Parameters.Clear()
                rcOracleCommand.Parameters.Add("fname", OpenFileDialog1.FileName.Substring(OpenFileDialog1.FileName.LastIndexOf("\") + 1))
                rcOracleCommand.ExecuteNonQuery()
                Me.LblMsg.Text = "5"
                rcOracleCommand.CommandText = "INSERT INTO rc_file (fname,filetype,filecontent,filever,filesize,fileuploader,uploaddate) VALUES (:fname,:filetype,EMPTY_BLOB(),:filever,:filesize,:fileuploader,:uploaddate)"
                rcOracleCommand.Parameters.Clear()
                rcOracleCommand.Parameters.Add("fname", OpenFileDialog1.FileName.Substring(OpenFileDialog1.FileName.LastIndexOf("\") + 1))
                Select Case OpenFileDialog1.FileName.Substring(OpenFileDialog1.FileName.LastIndexOf(".") + 1).ToUpper
                    Case "SQL"
                        rcOracleCommand.Parameters.Add("filetype", "脚本文件")
                    Case "TXT"
                        rcOracleCommand.Parameters.Add("filetype", "文本文件")
                    Case Else
                        rcOracleCommand.Parameters.Add("filetype", "WINRAR自解压文件")

                End Select
                'rcOracleCommand.Parameters.add("filecontext", OleDbType.Binary).Value = imgData
                rcOracleCommand.Parameters.Add("filever", File.GetLastWriteTime(Me.TextBox1.Text).ToString)
                rcOracleCommand.Parameters.Add("filesize", FileLen(Me.TextBox1.Text))
                rcOracleCommand.Parameters.Add("fileuploader", g_User_DspName)
                rcOracleCommand.Parameters.Add("uploaddate", Now())
                rcOracleCommand.ExecuteNonQuery()
                Me.LblMsg.Text = "6"
            Catch ex As Exception
                Try
                    'rcOleDbTrans.Rollback()
                    MsgBox("程序错误。" + ex.Message + Chr(13) + rcDataset.Tables("rc_dwdm").Rows(i).Item("host"), MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End Try
                Return
            Finally
                rcOracleConnection.Close()
            End Try
            Me.LblMsg.Text = "7"
            Try
                rcOracleConnection.Open()
                rcOracleCommand.Connection = rcOracleConnection
                rcOracleCommand.CommandTimeout = 300
                rcOracleCommand.CommandType = CommandType.Text
                Me.LblMsg.Text = "8"
                rcOracleCommand.CommandText = "SELECT filecontent FROM rc_file WHERE fname = :fname FOR UPDATE"
                rcOracleCommand.Parameters.Clear()
                rcOracleCommand.Parameters.Add("fname", OpenFileDialog1.FileName.Substring(OpenFileDialog1.FileName.LastIndexOf("\") + 1))
                rcOracleCommand.ExecuteNonQuery()
                Me.LblMsg.Text = "9"
                rcOracleCommand.CommandText = "UPDATE rc_file Set filecontent = :filecontext WHERE fname = :fname"
                rcOracleCommand.Parameters.Clear()
                rcOracleCommand.Parameters.Add("filecontext", imgData)
                rcOracleCommand.Parameters.Add("fname", OpenFileDialog1.FileName.Substring(OpenFileDialog1.FileName.LastIndexOf("\") + 1))
                rcOracleCommand.ExecuteNonQuery()
                Me.LblMsg.Text = "10"
            Catch ex As Exception
                Try
                    'rcOleDbTrans.Rollback()
                    MsgBox("程序错误。" + ex.Message + Chr(13) + rcDataset.Tables("rc_dwdm").Rows(i).Item("host"), MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End Try
                Return
            Finally
                rcOracleConnection.Close()
            End Try
        Next

        Me.LblMsg.Text = "11"
        Me.TextBox1.Text = ""
        Me.LblMsg.Text = "上传完毕！"
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class