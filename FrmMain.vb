Imports System.IO
Imports System.Data.OleDb
Imports System.Threading
Imports System.ComponentModel

Public Class FrmMain

    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    ReadOnly rcDataset As New DataSet
    ReadOnly rcOleDbCommand As New OleDbCommand

    Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If System.IO.File.Exists(Application.StartupPath + "\images\rc01.jpg") Then
            Me.BackgroundImage = System.Drawing.Image.FromFile(Application.StartupPath + "\images\rc01.jpg")
            Me.BackgroundImageLayout = ImageLayout.Stretch
        End If

        Me.ToolStripStatusLabel2.Text = "单位：" + g_Dwmc
        Me.ToolStripStatusLabel3.Text = "操作员：" + g_User_DspName
        Me.ToolStripStatusLabel4.Text = "登陆日期：" & g_Kjrq.ToLongDateString

        Try
            sysOleDbConn.Open()
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT rc_users.user_dwdm,rc_users.user_account,rc_userinrole.roleid FROM rc_users,rc_userinrole WHERE rc_users.user_account = rc_userinrole.user_account AND rc_users.user_account = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@USER_Account", OleDbType.VarChar, 30).Value = g_User_Account
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            rcDataset.Tables("rc_userinrole")?.Clear()
            rcOleDbDataAdpt.Fill(rcDataset, "rc_userinrole")
        Catch ex As Exception
            MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End
        Finally
            sysOleDbConn.Close()
        End Try

        If rcDataset.Tables("rc_userinrole").Rows.Count <= 0 Then
            MsgBox("您没有操作权限，请与系统管理员联系。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End
        End If

        MenuHelper.BuildMenu(Me.MenuStripMain, g_User_Account)

        Me.ToolStripStatusLabel1.Text = "欢迎使用。"

        BackgroundWorkerMain.RunWorkerAsync()
    End Sub

    Private Sub FrmMain_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Me.MdiChildren.Length > 0 Then
            e.Cancel = True
            Return
        End If
        If MsgBox("您真的要退出系统吗？", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "提示信息") = MsgBoxResult.Yes Then
            Application.Exit()
        Else
            e.Cancel = True
        End If
    End Sub

#Region "下载文件"

    Private Sub BackgroundWorkerMain_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorkerMain.DoWork
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
        UpdateEvent(worker, e)
    End Sub

    Private Sub BackgroundWorkerMain_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorkerMain.RunWorkerCompleted
        Me.ToolStripStatusLabel1.Text = "下载完成!"
        If sysOleDbConn.State = ConnectionState.Open Then
            sysOleDbConn.Close()
        End If
    End Sub

    Private Sub UpdateEvent(ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs)
        Try
            sysOleDbConn.Open()
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM (SELECT filever FROM rc_file ORDER BY filever Desc) WHERE ROWNUM <= 1"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_file") IsNot Nothing Then
                rcDataset.Tables("rc_file").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_file")
        Catch ex As Exception
            MsgBox("程序错误6。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            sysOleDbConn.Close()
        End Try

        If rcDataset.Tables("rc_file").Rows.Count > 0 Then
            Dim rcStreamWriter As System.IO.StreamWriter
            Dim oldXml As New System.Xml.XmlDocument

            If Not System.IO.File.Exists(Application.StartupPath & "\UpdateVersion.XML") Then
                rcStreamWriter = System.IO.File.CreateText(Application.StartupPath & "\UpdateVersion.XML")
                rcStreamWriter.WriteLine("<?xml version=""1.0"" encoding=""utf-8"" ?> ")
                rcStreamWriter.WriteLine("<product>")
                rcStreamWriter.WriteLine("<version>1.0</version>")
                rcStreamWriter.WriteLine("</product>")
                rcStreamWriter.Close()
            End If

            oldXml.Load(CurDir() & "\" & "UpdateVersion.XML")

            If oldXml.SelectSingleNode("product").SelectSingleNode("version").InnerText <> rcDataset.Tables("rc_file").Rows(0).Item("filever") Then
                sysOleDbConn.Open()
                rcOleDbCommand.Connection = sysOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                Try
                    rcOleDbCommand.CommandText = "SELECT * FROM (SELECT fname,filecontent,filever FROM rc_file ORDER BY filever Desc) WHERE ROWNUM <= 1"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("rc_file") IsNot Nothing Then
                        rcDataset.Tables("rc_file").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "rc_file")
                Catch ex As Exception
                    MsgBox("程序错误7。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                    Return
                Finally
                    sysOleDbConn.Close()
                End Try

                Dim s As String
                s = Application.StartupPath & "\update\" & rcDataset.Tables("rc_file").Rows(0).Item("fname")
                If IO.File.Exists(s) Then
                    IO.File.Delete(s)
                End If
                Dim size() As Byte = rcDataset.Tables("rc_file").Rows(0).Item("filecontent")
                Dim fs As IO.FileStream
                fs = New IO.FileStream(s, IO.FileMode.CreateNew)
                fs.Write(size, 0, size.Length - 0)
                fs.Close()
            End If

            If System.IO.File.Exists(Application.StartupPath & "\UpdateVersion.XML") Then
                System.IO.File.Delete(Application.StartupPath & "\UpdateVersion.XML")
            End If

            rcStreamWriter = System.IO.File.CreateText(Application.StartupPath & "\UpdateVersion.XML")
            rcStreamWriter.WriteLine("<?xml version=""1.0"" encoding=""utf-8"" ?> ")
            rcStreamWriter.WriteLine("<product>")
            rcStreamWriter.WriteLine("<version>" & Trim(rcDataset.Tables("rc_file").Rows(0).Item("filever")) & "</version>")
            rcStreamWriter.WriteLine("</product>")
            rcStreamWriter.Close()
        End If
    End Sub

#End Region

End Class