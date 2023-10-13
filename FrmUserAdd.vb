Imports System.Data.OleDb

Public Class FrmUserAdd
    '����OLEDB��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '����OleDb���ݶ���
    Dim rcOleDbTrans As OleDbTransaction
    '����OleDb����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

#Region "�ؼ��س����Ĵ���"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAccount.KeyPress, TxtDspName.KeyPress, TxtPWD.KeyPress, TxtPWDConfirm.KeyPress, TxtDwdm.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
        End Select
    End Sub

#End Region


    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        '����
        Dim strPwdE As String
        Dim c As New models.rcCryptography
        strPwdE = c.EnCryptography(TxtPWD.Text)
        If TxtPWD.Text = Me.TxtPWDConfirm.Text Then
            Try
                sysOleDbConn.Open()
                rcOleDbTrans = sysOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = sysOleDbConn
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandText = "INSERT INTO rc_users (User_Account,User_PWD,User_DspName,User_Delete,User_Dwdm) values (?,?,?,0,?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = Trim(Me.TxtAccount.Text)
                rcOleDbCommand.Parameters.Add("@User_PWD", OleDbType.VarChar, 20).Value = strPwdE
                rcOleDbCommand.Parameters.Add("@User_DspName", OleDbType.VarChar, 30).Value = Trim(Me.TxtDspName.Text)
                rcOleDbCommand.Parameters.Add("@User_Dwdm", OleDbType.VarChar, 30).Value = Trim(Me.TxtDwdm.Text)
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Catch ey As OleDbException
                    MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                End Try
                Return
            Finally
                sysOleDbConn.Close()
            End Try
        End If
        Me.Close()
    End Sub

End Class