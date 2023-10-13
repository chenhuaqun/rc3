Imports System.Data.OleDb

Public Class FrmGlPzXm

#Region "�������"

    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '���ݸ��´���
    ReadOnly rcOleDbTrans As OleDbTransaction

#End Region

#Region "�ؼ��س����Ĵ���"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtXmdm.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "��Ŀ�����¼�"

    Private Sub TxtXmdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtXmdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "gl_xmxx"
                    .paraField1 = "xmdm"
                    .paraField2 = "xmmc"
                    .paraField3 = "xmsm"
                    .paraTitle = "��Ŀ"
                    .paraOldValue = ""
                    .paraAddName = ""
                    .paraCondition = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtXmdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtXmdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtXmdm.Validating
        If String.IsNullOrEmpty(Me.TxtXmdm.Text) Then
            e.Cancel = True
            Return
        End If
        rcOleDbConn.Open()
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT * FROM gl_xmxx where (xmdm = ?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@xmdm", OleDbType.VarChar, 12).Value = Trim(TxtXmdm.Text)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("gl_xmxx") IsNot Nothing Then
                Me.rcDataSet.Tables("gl_xmxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "gl_xmxx")
        Catch ex As Exception
            Try
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Catch ey As OleDbException
                MsgBox("�������" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("gl_xmxx").Rows.Count > 0 Then
            Me.TxtXmdm.Text = Trim(rcDataSet.Tables("gl_xmxx").Rows(0).Item("xmdm"))
            Me.TxtXmmc.Text = rcDataSet.Tables("gl_xmxx").Rows(0).Item("xmmc")
        Else
            MsgBox("��Ŀ���벻���ڡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            e.Cancel = True
        End If
    End Sub

#End Region

#Region "ȷ���¼�"

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Me.DialogResult = DialogResult.OK
    End Sub

#End Region

End Class
