﻿Imports System.Data.OleDb

Module MdlReadCsKcdj

    Friend Function ReadCsKcdj(ByVal strCpdm As String, ByVal strCsdm As String, ByVal strCkdm As String, ByVal blnFuShu As Boolean) As Double
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
            If Not blnFuShu Then
                '只取正常入库的供应商库存，红字入库部分应该已经冲销原先的入库单。
                If Not String.IsNullOrEmpty(strCsdm) Then
                    rcOleDbCommand.CommandText = "SELECT ROUND(CASE WHEN COALESCE(SUM((COALESCE(po_rkda.sl,0.0)-COALESCE(po_rkda.cksl,0.0))),0.0) <> 0 THEN COALESCE(SUM((COALESCE(po_rkda.je,0.0)-COALESCE(po_rkda.ckje,0.0))),0.0) / COALESCE(SUM((COALESCE(po_rkda.sl,0.0)-COALESCE(po_rkda.cksl,0.0))),0.0) ELSE 0 END,6) AS kcdj FROM ((SELECT po_rkd.sl,po_rkd.je,po_rkd.cksl,po_rkd.ckje FROM po_rkd WHERE po_rkd.bdelete = 0 AND po_rkd.sl > 0 AND po_rkd.sl > po_rkd.cksl AND po_rkd.ckdm = ? AND po_rkd.csdm = ? AND po_rkd.cpdm = ?) UNION (SELECT inv_dbd.sl,inv_dbd.je,inv_dbd.cksl,inv_dbd.ckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND inv_dbd.sl > 0 AND inv_dbd.sl > inv_dbd.cksl AND inv_dbd.rckdm = ? AND inv_dbd.csdm = ? AND inv_dbd.cpdm = ?)) po_rkda"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = strCkdm
                    rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = strCsdm
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = strCpdm
                    rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = strCkdm
                    rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = strCsdm
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = strCpdm
                Else
                    rcOleDbCommand.CommandText = "SELECT ROUND(CASE WHEN COALESCE(SUM((COALESCE(inv_rkda.sl,0.0)-COALESCE(inv_rkda.cksl,0.0))),0.0) <> 0 THEN COALESCE(SUM((COALESCE(inv_rkda.je,0.0)-COALESCE(inv_rkda.ckje,0.0))),0.0) / COALESCE(SUM((COALESCE(inv_rkda.sl,0.0)-COALESCE(inv_rkda.cksl,0.0))),0.0) ELSE 0 END,6) AS kcdj FROM ((SELECT inv_rkd.sl,inv_rkd.je,inv_rkd.cksl,inv_rkd.ckje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND inv_rkd.sl > 0 AND inv_rkd.sl > inv_rkd.cksl AND inv_rkd.ckdm = ? AND inv_rkd.cpdm = ?) UNION (SELECT inv_dbd.sl,inv_dbd.je,inv_dbd.cksl,inv_dbd.ckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND inv_dbd.sl > 0 AND inv_dbd.sl > inv_dbd.cksl AND inv_dbd.rckdm = ? AND inv_dbd.cpdm = ?)) inv_rkda"
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
            Else
                '负数时查最新出库单价
                If Not String.IsNullOrEmpty(strCsdm) Then
                    rcOleDbCommand.CommandText = "SELECT po_rkda.je / po_rkda.sl AS kcdj FROM ((SELECT po_rkd.rkrq,po_rkd.sl,po_rkd.je,po_rkd.cksl,po_rkd.ckje FROM po_rkd WHERE po_rkd.bdelete = 0 AND po_rkd.sl > 0 AND po_rkd.cksl > 0 AND po_rkd.ckdm = ? AND po_rkd.csdm = ? AND po_rkd.cpdm = ?) UNION (SELECT inv_dbd.dbrq AS rkrq,inv_dbd.sl,inv_dbd.je,inv_dbd.cksl,inv_dbd.ckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND inv_dbd.sl > 0 AND inv_dbd.cksl > 0 AND inv_dbd.rckdm = ? AND inv_dbd.csdm = ? AND inv_dbd.cpdm = ?)) po_rkda ORDER BY po_rkda.rkrq DESC"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = strCkdm
                    rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = strCsdm
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = strCpdm
                    rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = strCkdm
                    rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = strCsdm
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = strCpdm
                Else
                    rcOleDbCommand.CommandText = "SELECT  inv_rkda.je / inv_rkda.sl AS kcdj FROM ((SELECT inv_rkd.rkrq,inv_rkd.sl,inv_rkd.je,inv_rkd.cksl,inv_rkd.ckje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND inv_rkd.sl > 0 AND inv_rkd.cksl > 0 AND inv_rkd.ckdm = ? AND inv_rkd.cpdm = ?) UNION (SELECT ivn_dbd.dbrq AS rkrq,inv_dbd.sl,inv_dbd.je,inv_dbd.cksl,inv_dbd.ckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND inv_dbd.sl > 0 AND inv_dbd.cksl > 0 AND inv_dbd.rckdm = ? AND inv_dbd.cpdm = ?)) inv_rkda ORDER BY inv_rkda.rkrq DESC"
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
            End If
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return 0
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("t_cpyeb").Rows.Count = 0 Then
            Return 0
        Else
            Return rcDataSet.Tables("t_cpyeb").Rows(0).Item("kcdj")
        End If
    End Function

End Module
