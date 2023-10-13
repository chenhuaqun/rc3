Imports System.Data.OleDb

Public Class FrmUserEdit
    '����OLEDB��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '����OleDb���ݶ���
    Dim rcOleDbTrans As OleDbTransaction
    '����OleDb����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            sysOleDbConn.Open()
            rcOleDbTrans = sysOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandText = "UPDATE rc_users SET User_DspName = ? ,User_Dwdm = ?  WHERE User_Account = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@User_DspName", OleDbType.VarChar, 30).Value = Trim(Me.TxtDspName.Text)
            rcOleDbCommand.Parameters.Add("@User_Dwdm", OleDbType.VarChar, 30).Value = Trim(Me.TxtDwdm.Text)
            rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = Trim(Me.TxtAccount.Text)
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
        Me.Close()
    End Sub

End Class