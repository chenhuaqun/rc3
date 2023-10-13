Imports System.Data.OleDb

Public Class FrmRedoCpyeHz
    '表示要对数据源执行的 SQL 语句或存储过程。
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Private Sub FrmRedoCpyeHz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.NudYear.Value = g_Kjrq.Year
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 30
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP3_REDO_CPYEHZ"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@ParaStrYear", OleDbType.VarChar, 4).Value = Me.NudYear.Value
            rcOleDbCommand.Parameters.Add("@dwrq", OleDbType.Date, 8).Value = g_Dwrq
            rcOleDbCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
        Finally
            rcOleDbConn.Close()
        End Try
        MsgBox("重新汇总总账已经完成。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
        Me.Close()

    End Sub
End Class