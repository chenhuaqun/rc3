Imports System.Data.OleDb
Module MdlLog
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Friend Sub AddLog(ByVal strCznr As String)
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "INSERT INTO rc_czrz (qssj,g_user_account,g_user_dspname,cznr,kjrq,zzsj) Values (SYSDATE,?,?,?,?,SYSDATE)"
            rcOleDbCommand.Parameters.Clear()
            'rcOleDbCommand.Parameters.Add("@qssj", OleDbType.Date, 8).Value = Now
            rcOleDbCommand.Parameters.Add("@g_user_account", OleDbType.VarChar, 30).Value = g_User_Account
            rcOleDbCommand.Parameters.Add("@g_user_dspname", OleDbType.VarChar, 30).Value = g_User_DspName
            rcOleDbCommand.Parameters.Add("@cznr", OleDbType.VarChar, 50).Value = "RC3" & strCznr
            rcOleDbCommand.Parameters.Add("@kjrq", OleDbType.Date, 8).Value = g_Kjrq
            'rcOleDbCommand.Parameters.Add("@zzsj", OleDbType.Date, 8).Value = Now
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
    End Sub
End Module
