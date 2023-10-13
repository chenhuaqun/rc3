Imports System.Data.OleDb

Public Class FrmUpdate

    '建立OLEDB数据适配器对象
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDb命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        UpdateEvent()
    End Sub

    Private Sub UpdateEvent()
        Try
            sysOleDbConn.Open()
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM (SELECT filever FROM rc_file ORDER BY filever Desc) WHERE ROWNUM <= 1"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_file") IsNot Nothing Then
                rcDataSet.Tables("rc_file").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_file")
        Catch ex As Exception
            MsgBox("程序错误6。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            sysOleDbConn.Close()
        End Try
        If rcDataSet.Tables("rc_file").Rows.Count > 0 Then
            '分析升级文件
            '存储更新XML文件
            '保存设置
            Dim rcStreamWriter As System.IO.StreamWriter
            Dim oldXml As New System.Xml.XmlDocument
            If Not System.IO.File.Exists(Application.StartupPath & "\UpdateVersion.XML") Then
                '写xml文件
                rcStreamWriter = System.IO.File.CreateText(Application.StartupPath & "\UpdateVersion.XML")
                rcStreamWriter.WriteLine("<?xml version=""1.0"" encoding=""utf-8"" ?> ")
                rcStreamWriter.WriteLine("<product>")
                rcStreamWriter.WriteLine("<version>1.0</version>")
                rcStreamWriter.WriteLine("</product>")
                rcStreamWriter.Close()
            End If
            oldXml.Load(CurDir() & "\" & "UpdateVersion.XML")
            'If oldXml.SelectSingleNode("product").SelectSingleNode("version").InnerText <> rcDataSet.Tables("rc_file").Rows(0).Item("filever") Then
            Try
                sysOleDbConn.Open()
                rcOleDbCommand.Connection = sysOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM (SELECT fname,filecontent,filever FROM rc_file ORDER BY filever Desc) WHERE ROWNUM <= 1"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_file") IsNot Nothing Then
                    rcDataSet.Tables("rc_file").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_file")
            Catch ex As Exception
                MsgBox("程序错误7。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                sysOleDbConn.Close()
            End Try
            Dim s As String
            s = Application.StartupPath & "\update\" & rcDataSet.Tables("rc_file").Rows(0).Item("fname")
            If IO.File.Exists(s) Then
                IO.File.Delete(s)
            End If
            Dim size() As Byte = rcDataSet.Tables("rc_file").Rows(0).Item("filecontent")
            Dim fs As IO.FileStream
            fs = New IO.FileStream(s, IO.FileMode.CreateNew)
            fs.Write(size, 0, size.Length - 0)
            fs.Close()
            'End If
            '存储更新XML文件
            '保存设置
            If System.IO.File.Exists(Application.StartupPath & "\UpdateVersion.XML") Then
                System.IO.File.Delete(Application.StartupPath & "\UpdateVersion.XML")
            End If
            '写xml文件
            'Dim rcStreamWriter As System.IO.StreamWriter
            rcStreamWriter = System.IO.File.CreateText(Application.StartupPath & "\UpdateVersion.XML")
            rcStreamWriter.WriteLine("<?xml version=""1.0"" encoding=""utf-8"" ?> ")
            rcStreamWriter.WriteLine("<product>")
            rcStreamWriter.WriteLine("<version>" & Trim(rcDataSet.Tables("rc_file").Rows(0).Item("filever")) & "</version>")
            rcStreamWriter.WriteLine("</product>")
            rcStreamWriter.Close()
            MsgBox("应用程序下载完成，请退出所有应用程序后，再登陆。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Me.Close()
        End If
    End Sub
End Class