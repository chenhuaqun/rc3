Imports System.Data.OleDb

Module MdlReadKcsl

    Friend Function ReadKcsl(ByVal strYear As String, ByVal strCpdm As String, ByVal strCkdm As String, ByVal strDjh As String) As Double
        '建立数据适配器
        Dim rcOleDbDataAdpt As New OleDbDataAdapter
        '建立DataSet对象
        Dim rcDataset As New DataSet
        '建立OleDbCommand对象
        Dim rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
        Dim dateBegin As Date = getInvBegin(strYear, 1)
        Dim dateEnd As Date = GetInvEnd(strYear, 12)
        'MsgBox(strYear)
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT asfchz.cpdm,COALESCE(asfchz.qcsl,0.0)+COALESCE(asfchz.qcscrksl,0.0)+COALESCE(asfchz.qccgrksl,0.0)+COALESCE(asfchz.qcdbrksl,0.0)-COALESCE(asfchz.qcxscksl,0.0)-COALESCE(asfchz.qcckcksl,0.0)-COALESCE(asfchz.qcdbcksl,0.0) AS jcsl,COALESCE(asfchz.qcje,0.0)+COALESCE(asfchz.qcscrkje,0.0)+COALESCE(asfchz.qccgrkje,0.0)+COALESCE(asfchz.qcdbrkje,0.0)-COALESCE(asfchz.qcxsckje,0.0)-COALESCE(asfchz.qcckckje,0.0)-COALESCE(asfchz.qcdbckje,0.0) AS jcje FROM" &
                " (SELECT cpnc.cpdm,cpnc.qcsl,cpnc.qcje,qcscrk.qcscrksl,qcscrk.qcscrkje,qccgrk.qccgrksl,qccgrk.qccgrkje,qcdbrk.qcdbrksl,qcdbrk.qcdbrkje,qcxsck.qcxscksl,qcxsck.qcxsckje,qcckck.qcckcksl,qcckck.qcckckje,qcdbck.qcdbcksl,qcdbck.qcdbckje FROM" &
                " (SELECT inv_cpyeb.cpdm,sum(qcsl) as qcsl,sum(qcje) as qcje FROM inv_cpyeb WHERE kjnd = ?" & IIf(Not String.IsNullOrEmpty(strCkdm), " AND inv_cpyeb.ckdm ='" & strCkdm & "'", "") & " GROUP BY inv_cpyeb.cpdm) cpnc" &
                " Left join (SELECT inv_rkd.cpdm,sum(inv_rkd.sl) as qcscrksl,sum(inv_rkd.je) as qcscrkje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND inv_rkd.rkrq >= ? and inv_rkd.rkrq >= ? and inv_rkd.rkrq <= ? AND inv_rkd.djh <> '" & strDjh & "'" & IIf(Not String.IsNullOrEmpty(strCkdm), " AND inv_rkd.ckdm ='" & strCkdm & "'", "") & " GROUP BY inv_rkd.cpdm) qcscrk ON cpnc.cpdm = qcscrk.cpdm" &
                " Left join (SELECT po_rkd.cpdm,sum(po_rkd.sl) as qccgrksl,sum(po_rkd.je) as qccgrkje FROM po_rkd WHERE po_rkd.bdelete = 0 AND po_rkd.rkrq >= ? and po_rkd.rkrq >= ? and po_rkd.rkrq <= ? AND po_rkd.djh <> '" & strDjh & "'" & IIf(Not String.IsNullOrEmpty(strCkdm), " AND po_rkd.ckdm ='" & strCkdm & "'", "") & " GROUP BY po_rkd.cpdm) qccgrk ON cpnc.cpdm = qccgrk.cpdm" &
                " Left join (SELECT inv_dbd.cpdm,sum(inv_dbd.sl) as qcdbrksl,sum(inv_dbd.je) as qcdbrkje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ? AND inv_dbd.djh <> '" & strDjh & "'" & IIf(Not String.IsNullOrEmpty(strCkdm), " AND inv_dbd.rckdm ='" & strCkdm & "'", "") & " GROUP BY inv_dbd.cpdm) qcdbrk ON cpnc.cpdm = qcdbrk.cpdm" &
                " Left join (SELECT oe_xsd.cpdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq <= ? AND oe_xsd.djh <> '" & strDjh & "'" & IIf(Not String.IsNullOrEmpty(strCkdm), " AND oe_xsd.ckdm ='" & strCkdm & "'", "") & " GROUP BY oe_xsd.cpdm) qcxsck ON cpnc.cpdm = qcxsck.cpdm" &
                " Left join (SELECT inv_ckd.cpdm,sum(inv_ckd.sl) as qcckcksl,sum(inv_ckd.je) as qcckckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND inv_ckd.ckrq >= ? and inv_ckd.ckrq >= ? and inv_ckd.ckrq <= ? AND inv_ckd.djh <> '" & strDjh & "'" & IIf(Not String.IsNullOrEmpty(strCkdm), " AND inv_ckd.ckdm ='" & strCkdm & "'", "") & " GROUP BY inv_ckd.cpdm) qcckck ON cpnc.cpdm = qcckck.cpdm" &
                " Left join (SELECT inv_dbd.cpdm,sum(inv_dbd.sl) as qcdbcksl,sum(inv_dbd.je) as qcdbckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ? AND inv_dbd.djh <> '" & strDjh & "'" & IIf(Not String.IsNullOrEmpty(strCkdm), " AND inv_dbd.cckdm ='" & strCkdm & "'", "") & " GROUP BY inv_dbd.cpdm) qcdbck ON cpnc.cpdm = qcdbck.cpdm) asfchz WHERE (0=0)" & IIf(Not String.IsNullOrEmpty(strCpdm), " and cpdm = '" & Trim(strCpdm) & "'", "")
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = strYear
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateBegin
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateEnd
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateBegin
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateEnd
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateBegin
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateEnd
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateBegin
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateEnd
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateBegin
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateEnd
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateBegin
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateEnd
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
            MsgBox(0)
        Else
            Return rcDataset.Tables("t_cpyeb").Rows(0).Item("jcsl")
        End If
    End Function

End Module
