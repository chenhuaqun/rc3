Imports System.Data.OleDb

Public Class FrmUserEdit
    '建立OLEDB数据适配器对象
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDb传递对象
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDb命令
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
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Return
        Finally
            sysOleDbConn.Close()
        End Try
        Me.Close()
    End Sub

End Class