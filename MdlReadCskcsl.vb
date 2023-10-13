Imports System.Data.OleDb

Module MdlReadCsKcsl

    Friend Function ReadCsKcsl(ByVal strCpdm As String, ByVal strCsdm As String, ByVal strCkdm As String) As Double
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
            If Not String.IsNullOrEmpty(strCsdm) Then
                '只取正常入库的供应商库存，红字入库部分应该已经冲销原先的入库单。
                rcOleDbCommand.CommandText = "SELECT COALESCE(SUM(COALESCE(po_rkda.kcsl,0.0)),0.0) AS kcsl FROM ((SELECT po_rkd.sl - po_rkd.cksl AS kcsl FROM po_rkd WHERE po_rkd.bdelete = 0 AND po_rkd.sl > po_rkd.cksl AND po_rkd.sl > 0 AND po_rkd.ckdm = ? AND po_rkd.csdm = ? AND po_rkd.cpdm = ?) UNION ALL (SELECT inv_dbd.sl - inv_dbd.cksl AS kcsl FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND inv_dbd.sl > inv_dbd.cksl AND inv_dbd.sl > 0 AND inv_dbd.rckdm = ? AND inv_dbd.csdm = ? AND inv_dbd.cpdm = ?)) po_rkda"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = strCkdm
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = strCsdm
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = strCpdm
                rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = strCkdm
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = strCsdm
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = strCpdm
            Else
                rcOleDbCommand.CommandText = "SELECT COALESCE(SUM(COALESCE(po_rkda.kcsl,0.0)),0.0) AS kcsl FROM ((SELECT inv_rkd.sl - inv_rkd.cksl AS kcsl FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND inv_rkd.sl > inv_rkd.cksl AND inv_rkd.sl > 0 AND inv_rkd.ckdm = ? AND inv_rkd.cpdm = ?) UNION ALL (SELECT inv_dbd.sl - inv_dbd.cksl AS kcsl FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND inv_dbd.sl > inv_dbd.cksl AND inv_dbd.sl > 0 AND inv_dbd.rckdm = ? AND inv_dbd.cpdm = ?)) po_rkda"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = strCkdm
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = strCpdm
                rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = strCkdm
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = strCpdm
            End If
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
            Return rcDataSet.Tables("t_cpyeb").Rows(0).Item("kcsl")
        End If
    End Function

End Module
