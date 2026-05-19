Imports System.Data.OleDb

Public Class FrmRedoFcspyeHz
    '表示要对数据源执行的 SQL 语句或存储过程。
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '发出商品启用会计期间
    Dim dateFcspBegin As Date

    Private Sub FrmRedoFcspyeHz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.NudYear.Value = g_Kjrq.Year
        Dim strFcspKjqj As String = GetParaValue("发出商品启用会计期间", True)
        If Not String.IsNullOrEmpty(strFcspKjqj) Then
            dateFcspBegin = GetInvBegin(Mid(strFcspKjqj, 1, 4), Mid(strFcspKjqj, 5, 2))
        Else
            dateFcspBegin = g_Dwrq
        End If

    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 30
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP3_REDO_FCSPYEHZ"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@ParaStrYear", OleDbType.VarChar, 4).Value = Me.NudYear.Value
            rcOleDbCommand.Parameters.Add("@dwrq", OleDbType.Date, 8).Value = dateFcspBegin.Date
            rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
            rcOleDbCommand.ExecuteNonQuery()
            If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                    MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                    Return
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
        Finally
            rcOleDbConn.Close()
        End Try
        MsgBox("重新汇总发出商品总账已经完成。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
        Me.Close()

    End Sub
End Class