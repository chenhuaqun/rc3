Imports System.Data.OleDb

Module MdlReadJldwXsws

    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Friend Function ReadJldwXsws(ByVal strJldwmc As String) As String
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT NVL(xsws,0) AS xsws FROM rc_jldw WHERE jldwmc = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@jldwmc", OleDbType.VarChar, 8).Value = strJldwmc
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_jldw") IsNot Nothing Then
                rcDataset.Tables("rc_jldw").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_jldw")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return g_FormatSl
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_jldw").Rows.Count > 0 Then
            Return "N" & Trim(rcDataset.Tables("rc_jldw").Rows(0).Item("xsws").ToString)
        Else
            Return g_FormatSl
        End If
    End Function
End Module
