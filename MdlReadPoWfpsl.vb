Imports System.Data.OleDb

Module MdlReadPoWfpsl

    Friend Function ReadPoWfpsl(ByVal strCpdm As String, ByVal strCgdDjh As String, ByVal intCgdXh As Integer, ByVal strDjh As String) As Double
        '建立数据适配器
        Dim rcOleDbDataAdpt As New OleDbDataAdapter
        '建立DataSet对象
        Dim rcDataset As New DataSet
        '建立OleDbCommand对象
        Dim rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT COALESCE(SUM(sl),0.0) AS wrksl FROM (SELECT COALESCE(sl,0.0) AS sl FROM po_cgd WHERE po_cgd.xh = " & intCgdXh & " AND po_cgd.djh = '" & strCgdDjh & "' UNION SELECT SUM(0 - COALESCE(sl,0.0)) AS sl FROM po_fp WHERE po_fp.bdelete = 0 AND po_fp.cgdxh = " & intCgdXh & " AND po_fp.cgddjh = '" & strCgdDjh & "' AND po_fp.djh <> '" & strDjh & "') aa"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("t_cpyeb") IsNot Nothing Then
                rcDataSet.Tables("t_cpyeb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "t_cpyeb")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return 0
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("t_cpyeb").Rows.Count = 0 Then
            Return 0
        Else
            Return rcDataSet.Tables("t_cpyeb").Rows(0).Item("wrksl")
        End If
    End Function

End Module
