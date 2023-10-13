Imports System.Data.OleDb

Public Class FrmUpdate

    '����OLEDB��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '����OleDb����
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
            MsgBox("�������6��" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            sysOleDbConn.Close()
        End Try
        If rcDataSet.Tables("rc_file").Rows.Count > 0 Then
            '���������ļ�
            '�洢����XML�ļ�
            '��������
            Dim rcStreamWriter As System.IO.StreamWriter
            Dim oldXml As New System.Xml.XmlDocument
            If Not System.IO.File.Exists(Application.StartupPath & "\UpdateVersion.XML") Then
                'дxml�ļ�
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
                MsgBox("�������7��" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
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
            '�洢����XML�ļ�
            '��������
            If System.IO.File.Exists(Application.StartupPath & "\UpdateVersion.XML") Then
                System.IO.File.Delete(Application.StartupPath & "\UpdateVersion.XML")
            End If
            'дxml�ļ�
            'Dim rcStreamWriter As System.IO.StreamWriter
            rcStreamWriter = System.IO.File.CreateText(Application.StartupPath & "\UpdateVersion.XML")
            rcStreamWriter.WriteLine("<?xml version=""1.0"" encoding=""utf-8"" ?> ")
            rcStreamWriter.WriteLine("<product>")
            rcStreamWriter.WriteLine("<version>" & Trim(rcDataSet.Tables("rc_file").Rows(0).Item("filever")) & "</version>")
            rcStreamWriter.WriteLine("</product>")
            rcStreamWriter.Close()
            MsgBox("Ӧ�ó���������ɣ����˳�����Ӧ�ó�����ٵ�½��", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Me.Close()
        End If
    End Sub
End Class