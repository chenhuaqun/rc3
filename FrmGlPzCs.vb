Imports System.Data.OleDb

Public Class FrmGlPzCs

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

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCsdm.KeyPress, TxtYspz.KeyPress, TxtJsr.KeyPress, DtpWldqr.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "��Ӧ�̱����¼�"

    Private Sub TxtCsdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCsdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_csxx"
                    .paraField1 = "csdm"
                    .paraField2 = "csmc"
                    .paraField3 = "cssm"
                    .paraTitle = "��Ӧ��"
                    .paraOldValue = ""
                    .paraAddName = ""
                    .paraCondition = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtCsdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtCsdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCsdm.Validating
        If String.IsNullOrEmpty(Me.TxtCsdm.Text) Then
            e.Cancel = True
            Return
        End If
        rcOleDbConn.Open()
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT * FROM rc_csxx where (csdm = ?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(TxtCsdm.Text)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_csxx") IsNot Nothing Then
                Me.rcDataSet.Tables("rc_csxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_csxx")
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
        If rcDataSet.Tables("rc_Csxx").Rows.Count > 0 Then
            Me.TxtCsdm.Text = Trim(rcDataSet.Tables("rc_csxx").Rows(0).Item("csdm"))
            Me.TxtCsmc.Text = rcDataSet.Tables("rc_csxx").Rows(0).Item("csmc")
        Else
            MsgBox("��Ӧ�̱��벻���ڡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
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