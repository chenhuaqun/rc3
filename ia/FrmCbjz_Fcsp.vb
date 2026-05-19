Imports System.Data.OleDb

Public Class FrmCbjz_Fcsp
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '发出商品启用会计期间
    Dim dateFcspBegin As Date

#Region "初始化"

    Private Sub FrmCbjz_Fcsp_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strDwKjqj As String = GetInvKjqj(g_Dwrq)
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT ny,jzbz,invbegin,invend FROM rc_yj WHERE jzbz = 0 AND ny >= ? ORDER BY ny"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = strDwKjqj
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_yj") IsNot Nothing Then
                rcDataset.Tables("rc_yj").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_yj")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_yj").Rows.Count = 0 Then
            MsgBox("会计期间设置有错误，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        '默认值
        NudYear.Value = Mid(rcDataset.Tables("rc_yj").Rows(0).Item("ny"), 1, 4)
        NudMonth.Value = Mid(rcDataset.Tables("rc_yj").Rows(0).Item("ny"), 5, 2)

        Dim strFcspKjqj As String = GetParaValue("发出商品启用会计期间", True)
        If Not String.IsNullOrEmpty(strFcspKjqj) Then
            dateFcspBegin = GetInvBegin(Mid(strFcspKjqj, 1, 4), Mid(strFcspKjqj, 5, 2))
        Else
            dateFcspBegin = g_Dwrq
        End If

    End Sub

#End Region

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NudYear.KeyPress, NudMonth.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim i As Integer
        Dim j As Integer
        Dim datePoBegin1 As Date
        Dim dateKsrq As Date '成本结转开始日期
        Dim dateJsrq As Date '成本结转结束日期
        datePoBegin1 = GetInvBegin(Me.NudYear.Value, 1)
        dateKsrq = GetInvBegin(Me.NudYear.Value, Me.NudMonth.Value)
        dateJsrq = GetInvEnd(Me.NudYear.Value, Me.NudMonth.Value)
        'MsgBox(datePoBegin1.ToString)
        'MsgBox(dateKsrq.ToString)
        'MsgBox(dateJsrq.ToString)
        Dim dblQcsl As Double
        Dim dblQcje As Double
        Dim dblQcdj As Double
        '汇总总账
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
        '读取收发存汇总表
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            If Me.CheckBox1.Checked Then
                '直接按销售出库单号更新出库成本
                rcOleDbCommand.CommandText = "UPDATE oe_fp t SET t.cbdj =0 ,t.cbje =0 WHERE t.fprq<= ? AND t.fprq >= ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@jsrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbCommand.Parameters.Add("@ksrq", OleDbType.Date, 8).Value = dateKsrq
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "MERGE INTO oe_fp t
                    USING (SELECT x.vbillcode, x.crowno,CASE WHEN SUM(x.sl) = 0 THEN 0 ELSE SUM(x.cbje) / SUM(x.sl) END AS cbdj FROM oe_xsd x GROUP BY x.vbillcode, x.crowno) s ON (t.xsddjh = s.vbillcode AND t.xsdxh = s.crowno)
                    WHEN MATCHED THEN UPDATE SET t.cbdj = s.cbdj, t.cbje = t.sl * s.cbdj WHERE t.fprq<= ? AND t.fprq >= ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@jsrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbCommand.Parameters.Add("@ksrq", OleDbType.Date, 8).Value = dateKsrq
                rcOleDbCommand.ExecuteNonQuery()
                'rcOleDbCommand.CommandText = "UPDATE oe_fp SET oe_fp.cbdj = (SELECT CASE WHEN oe_xsd.sl <> 0 THEN oe_xsd.cbje / oe_xsd.sl ELSE 0 END FROM oe_xsd WHERE oe_xsd.crowno = oe_fp.xsdxh AND oe_xsd.vbillcode = oe_fp.xsddjh) WHERE SUBSTR(oe_fp.djh,5,6) = ?"
                'rcOleDbCommand.Parameters.Clear()
                'rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
                'rcOleDbCommand.ExecuteNonQuery()
                'rcOleDbCommand.CommandText = "UPDATE oe_fp SET oe_fp.cbje = oe_fp.sl * oe_fp.cbdj WHERE SUBSTR(oe_fp.djh,5,6) = ?"
                'rcOleDbCommand.Parameters.Clear()
                'rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
                'rcOleDbCommand.ExecuteNonQuery()
            Else
                '按加权平均法计算
                'rcOleDbCommand.CommandText = "MERGE INTO oe_fp f
                '    USING (SELECT cpdm,khdm,bmdm,(NVL(qc.qcje, 0) + NVL(in_.in_amount, 0) - NVL(out_.out_amount, 0)) / NULLIF(NVL(qc.qcsl, 0) + NVL(in_.in_qty, 0) - NVL(out_.out_qty, 0), 0) AS avg_dj FROM (
                '    -- 期初数据（来自发出商品汇总表）
                '    SELECT cpdm, khdm, bmdm, SUM(qcsl) AS qcsl, SUM(qcje) AS qcje FROM inv_fcspyeb WHERE kjnd = ? AND EXISTS (SELECT 1 FROM oe_xsd WHERE oe_xsd.cpdm = inv_fcspyeb.cpdm) 
                '    -- 只取有销售出库的产品
                '    GROUP BY cpdm, khdm, bmdm) qc
                '    LEFT JOIN ( 
                '    -- 本期入库（销售出库）
                '    SELECT cpdm, khdm, bmdm,SUM(sl) AS in_qty,SUM(cbje) AS in_amount FROM oe_xsd WHERE bdelete = 0 AND je <> 0 AND TRUNC(xsrq) >= ? AND TRUNC(xsrq) <= ? GROUP BY cpdm, khdm, bmdm) in_ ON qc.cpdm = in_.cpdm AND qc.khdm = in_.khdm AND qc.bmdm = in_.bmdm
                '    LEFT JOIN (
                '    -- 本期出库（销售发票）
                '    SELECT cpdm, shkhdm AS khdm, bmdm, SUM(sl) AS out_qty, SUM(cbje) AS out_amount FROM oe_fp WHERE bdelete = 0 AND TRUNC(fprq) >= ? AND TRUNC(fprq) <= ? GROUP BY cpdm, shkhdm, bmdm) out_ ON qc.cpdm = out_.cpdm AND qc.khdm = out_.khdm AND qc.bmdm = out_.bmdm
                '    ) src ON (f.cpdm = src.cpdm AND f.shkhdm = src.khdm AND f.bmdm = src.bmdm AND SUBSTR(f.djh,5,6) = ?)
                '    WHEN MATCHED THEN UPDATE SET f.cbje = f.sl * src.avg_dj, f.cbdj = src.avg_dj"
                'rcOleDbCommand.Parameters.Clear()
                'rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                'rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateFcspBegin.Date
                'rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = datePoBegin1
                'rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateJsrq
                'rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateFcspBegin.Date
                'rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = datePoBegin1
                'rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateKsrq

                'rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
                'rcOleDbCommand.ExecuteNonQuery()


                '取分仓库含本期调拨与本期出库数据的收发存汇总表
                '分仓库汇总,含调拨单的入库数量与金额，用来计算出库单的出库成本
                rcOleDbCommand.CommandText = "SELECT cpdm,khdm,bmdm,COALESCE(sum(qcsl),0.0) as qcsl,COALESCE(sum(qcje),0.0) as qcje,COALESCE(sum(qcxscksl),0.0) as qcxscksl,COALESCE(sum(qcxsckje),0.0) as qcxsckje,COALESCE(sum(qcfpcksl),0.0) as qcfpcksl,COALESCE(sum(qcfpckje),0.0) as qcfpckje FROM (SELECT clnc.cpdm,clnc.khdm,clnc.bmdm,clnc.qcsl,clnc.qcje,qcxsck.qcxscksl,qcxsck.qcxsckje,qcfpck.qcfpcksl,qcfpck.qcfpckje FROM" &
                    " (SELECT inv_fcspyeb.cpdm,inv_fcspyeb.khdm,inv_fcspyeb.bmdm,sum(qcsl) as qcsl,sum(qcje) as qcje FROM inv_fcspyeb WHERE kjnd = ? AND EXISTS (SELECT 1 FROM oe_xsd WHERE oe_xsd.cpdm = inv_fcspyeb.cpdm) GROUP by inv_fcspyeb.cpdm,inv_fcspyeb.khdm,inv_fcspyeb.bmdm) clnc" &
                    " Left join (SELECT oe_xsd.cpdm,oe_xsd.khdm,oe_xsd.bmdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND oe_xsd.je <> 0 AND TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') < ? GROUP BY oe_xsd.cpdm,oe_xsd.khdm,oe_xsd.bmdm) qcxsck ON clnc.cpdm = qcxsck.cpdm AND clnc.khdm = qcxsck.khdm AND clnc.bmdm = qcxsck.bmdm" &
                    " Left join (SELECT oe_fp.cpdm,oe_fp.shkhdm AS khdm,oe_fp.bmdm,sum(oe_fp.sl) as qcfpcksl,sum(oe_fp.cbje) as qcfpckje FROM oe_fp WHERE oe_fp.bdelete = 0 AND TRUNC(oe_fp.fprq,'mi') >= ? and TRUNC(oe_fp.fprq,'mi') >= ? and TRUNC(oe_fp.fprq,'mi') <= ? GROUP BY oe_fp.cpdm,oe_fp.shkhdm,oe_fp.bmdm) qcfpck ON clnc.cpdm = qcfpck.cpdm AND clnc.khdm = qcfpck.khdm AND clnc.bmdm = qcfpck.bmdm) asfchz GROUP BY cpdm,khdm,bmdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateFcspBegin.Date
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = datePoBegin1
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateFcspBegin.Date
                rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = datePoBegin1
                rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateKsrq
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("clqcye") IsNot Nothing Then
                    rcDataset.Tables("clqcye").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "clqcye")
                '更新出库成本
                For i = 0 To rcDataset.Tables("clqcye").Rows.Count - 1
                    '取平均单价
                    dblQcsl = rcDataset.Tables("clqcye").Rows(i).Item("qcsl") + rcDataset.Tables("clqcye").Rows(i).Item("qcxscksl") - rcDataset.Tables("clqcye").Rows(i).Item("qcfpcksl")
                    dblQcje = rcDataset.Tables("clqcye").Rows(i).Item("qcje") + rcDataset.Tables("clqcye").Rows(i).Item("qcxsckje") - rcDataset.Tables("clqcye").Rows(i).Item("qcfpckje")
                    '计算产品调拨成本单价=上月的账面金额+本月入库金额/上月账面数量+本月入库数量
                    If dblQcsl <> 0 Then
                        dblQcdj = dblQcje / dblQcsl
                    Else
                        dblQcdj = 0.0
                    End If
                    'MsgBox(Str(dblQcdj) + "/" + rcDataSet.Tables("cpxx").Rows(i).Item("cpdm") + "/" + rcDataSet.Tables("clqcye").Rows(j).Item("bmdm"))

                    ''按平均单价进行更新当月产品出库单的调拨金额=成本单价*退货数量
                    rcOleDbCommand.CommandText = "UPDATE oe_fp SET oe_fp.cbje = oe_fp.sl * ?,oe_fp.cbdj = ? WHERE oe_fp.cpdm = ? AND oe_fp.shkhdm = ? AND oe_fp.bmdm = ? AND SUBSTR(oe_fp.djh,5,6) = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                    rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("clqcye").Rows(i).Item("cpdm")
                    rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("clqcye").Rows(i).Item("khdm")
                    rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("clqcye").Rows(i).Item("bmdm")
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
                    'rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.ExecuteNonQuery()
                Next
            End If
            '调整出库成本
            If Me.CheckBox2.Checked Then
                '退货无销售成本的业务，按最新入库单价计算销售成本 销售发票才调整成本
                rcOleDbCommand.CommandText = "SELECT djh,xh,cpdm,bmdm FROM oe_fp WHERE cbje = 0 AND (sl < 0 OR sl > 0 AND NOT EXISTS (SELECT 1 FROM oe_xsd WHERE oe_xsd.vbillcode = oe_fp.xsddjh
                    AND oe_xsd.crowno = oe_fp.xsdxh))AND oe_fp.fprq <= ? AND oe_fp.fprq >= ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq
                'rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("clqcye").Rows(i).Item("cpdm"))
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("oe_fp") IsNot Nothing Then
                    rcDataset.Tables("oe_fp").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "oe_fp")
                '发票无销售出库的无销售成本的业务，按最新入库单价计算销售成本
                For j = 0 To rcDataset.Tables("oe_fp").Rows.Count - 1
                    rcOleDbCommand.CommandText = "SELECT COALESCE(cbdj,0.0) AS cbdj FROM (SELECT xsrq,cbdj FROM oe_xsd WHERE cbdj <> 0 AND sl > 0 AND oe_xsd.bmdm = ? AND oe_xsd.cpdm = ?) rkd ORDER BY rkd.xsrq DESC"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("oe_fp").Rows(j).Item("bmdm"))
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("oe_fp").Rows(j).Item("cpdm"))
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    rcDataset.Tables("rkd")?.Clear()
                    rcOleDbDataAdpt.Fill(rcDataset, "rkd")
                    If rcDataset.Tables("rkd").Rows.Count > 0 Then
                        rcOleDbCommand.CommandText = "UPDATE oe_fp SET oe_fp.dj =  ?,oe_fp.cbje = oe_fp.sl * ? WHERE oe_fp.xh = ? AND oe_fp.djh = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@cbje", OleDbType.Numeric, 18).Value = rcDataset.Tables("rkd").Rows(0).Item("cbdj")
                        rcOleDbCommand.Parameters.Add("@cbje", OleDbType.Numeric, 18).Value = rcDataset.Tables("rkd").Rows(0).Item("cbdj")
                        rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = rcDataset.Tables("oe_fp").Rows(j).Item("xh")
                        rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataset.Tables("oe_fp").Rows(j).Item("djh")
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                Next
            End If
            '按核销进行调整尾差
            rcOleDbCommand.CommandText = "SELECT djh,xh,shkhdm,fpkhdm,bmdm,cpdm,SUM(sl) AS sl,SUM(je) AS je,SUM(se) AS se,SUM(cbje) AS cbje FROM 
                ((SELECT vbillcode as djh,to_number(crowno) as xh,khdm AS shkhdm,fpkhdm as fpkhdm,bmdm,cpdm,SUM(sl) AS sl,SUM(je) AS je,SUM(se) AS se,SUM(cbje) AS cbje FROM oe_xsd WHERE bdelete = 0
            AND oe_xsd.je <>0 /*过滤掉全是0的数据*/
            AND xsrq >= ? /*发出商品启用时间*/
            AND xsrq <= ? /*销售出库结束时间*/
            AND EXISTS (SELECT 1 FROM oe_fp s WHERE s.bdelete = 0
                    AND fprq >= ? /*销售发票开始时间改成发出商品启用时间*/
                    AND fprq <= ? /*销售发票结束时间*/
                    AND oe_xsd.vbillcode = s.xsddjh
                    AND oe_xsd.crowno = s.xsdxh) /*销售出库在销售发票中存在才算*/
          GROUP BY vbillcode, crowno, khdm, fpkhdm, bmdm, cpdm) UNION ALL
        (SELECT xsddjh AS djh,xsdxh AS xh,shkhdm AS shkhdm,khdm as fpkhdm,bmdm,cpdm,SUM(0 - sl) AS sl,SUM(0 - je) AS je,SUM(0 - se) AS se,SUM(0 - cbje) AS cbje FROM oe_fp WHERE bdelete = 0
            AND fprq >= ? /*销售发票开始时间发出商品启用时间*/
            AND fprq <= ? /*销售发票开票结束时间*/
            AND EXISTS (SELECT 1 FROM oe_xsd s WHERE s.bdelete = 0
                    AND xsrq >= ? /*发出商品启用时间*/
                    AND xsrq <= ? /*销售出库结束时间*/
                    AND s.vbillcode = oe_fp.xsddjh
                    AND s.crowno = oe_fp.xsdxh) /*销售发票在销售出库中存在才算*/
          GROUP BY xsddjh, xsdxh, shkhdm, khdm, bmdm, cpdm))
 GROUP BY djh, xh, shkhdm, fpkhdm, bmdm, cpdm
HAVING SUM(sl) = 0 AND SUM(cbje) <> 0 /*过滤掉数量是0，成本金额不为零的数据*/"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraDateXsrq", OleDbType.Date, 8).Value = dateFcspBegin.Date '/*发出商品启用时间*/
            rcOleDbCommand.Parameters.Add("@paraDateXsrq", OleDbType.Date, 8).Value = dateJsrq
            rcOleDbCommand.Parameters.Add("@paraDateFprq", OleDbType.Date, 8).Value = dateFcspBegin.Date '/*本期开始时间改成发出商品启用时间*/
            rcOleDbCommand.Parameters.Add("@paraDateFprq", OleDbType.Date, 8).Value = dateJsrq
            rcOleDbCommand.Parameters.Add("@paraDateFprq", OleDbType.Date, 8).Value = dateFcspBegin.Date '/*本期开始时间改成发出商品启用时间*/
            rcOleDbCommand.Parameters.Add("@paraDateFprq", OleDbType.Date, 8).Value = dateJsrq
            rcOleDbCommand.Parameters.Add("@paraDateXsrq", OleDbType.Date, 8).Value = dateFcspBegin.Date '/*发出商品启用时间*/
            rcOleDbCommand.Parameters.Add("@paraDateXsrq", OleDbType.Date, 8).Value = dateJsrq
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("oe_xsd_fp") IsNot Nothing Then
                rcDataset.Tables("oe_xsd_fp").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "oe_xsd_fp")
            For i = 0 To rcDataset.Tables("oe_xsd_fp").Rows.Count - 1
                'If rcDataset.Tables("oe_xsd_fp").Rows(i).Item("cpdm") = "101726396" Then
                '    MsgBox(rcDataset.Tables("oe_xsd_fp").Rows(i).Item("cpdm") & rcDataset.Tables("oe_xsd_fp").Rows(i).Item("cbje") & rcDataset.Tables("oe_xsd_fp").Rows(i).Item("djh"))
                'End If

                '读取xsddjh,xsdxh相同的数据
                rcOleDbCommand.CommandText = "SELECT djh ,xh FROM oe_fp WHERE fprq >= ? AND fprq <= ? AND xsdxh = ? AND xsddjh = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraDateFprq", OleDbType.Date, 8).Value = dateKsrq.Date '/*本期开始时间*/
                rcOleDbCommand.Parameters.Add("@paraDateFprq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbCommand.Parameters.Add("@xsdxh", OleDbType.Integer, 4).Value = rcDataset.Tables("oe_xsd_fp").Rows(i).Item("xh")
                rcOleDbCommand.Parameters.Add("@xsddjh", OleDbType.VarChar, 40).Value = rcDataset.Tables("oe_xsd_fp").Rows(i).Item("djh")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("oe_fp") IsNot Nothing Then
                    rcDataset.Tables("oe_fp").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "oe_fp")
                'MsgBox(rcOleDbCommand.CommandText)
                If rcDataset.Tables("oe_fp").Rows.Count > 0 Then
                    'MsgBox(rcDataset.Tables("oe_fp").Rows(0).Item("djh"))
                    rcOleDbCommand.CommandText = "UPDATE oe_fp SET oe_fp.cbje = oe_fp.cbje + ? WHERE oe_fp.xh = ? AND oe_fp.djh = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@cbje", OleDbType.Numeric, 18).Value = rcDataset.Tables("oe_xsd_fp").Rows(i).Item("cbje")
                    rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = rcDataset.Tables("oe_fp").Rows(0).Item("xh")
                    rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataset.Tables("oe_fp").Rows(0).Item("djh")
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            Next

            '调整尾差，计算库存数量，库存金额
            rcOleDbCommand.CommandText = "SELECT cpdm,khdm,bmdm,COALESCE(sum(qcsl),0.0) as qcsl,COALESCE(sum(qcje),0.0) as qcje,COALESCE(sum(qcxscksl),0.0) as qcxscksl,COALESCE(sum(qcxsckje),0.0) as qcxsckje,COALESCE(sum(qcfpcksl),0.0) as qcfpcksl,COALESCE(sum(qcfpckje),0.0) as qcfpckje FROM (SELECT clnc.cpdm,clnc.khdm,clnc.bmdm,clnc.qcsl,clnc.qcje,qcxsck.qcxscksl,qcxsck.qcxsckje,qcfpck.qcfpcksl,qcfpck.qcfpckje FROM" &
                    " (SELECT inv_fcspyeb.cpdm,inv_fcspyeb.khdm,inv_fcspyeb.bmdm,sum(qcsl) as qcsl,sum(qcje) as qcje FROM inv_fcspyeb WHERE kjnd = ? GROUP by inv_fcspyeb.cpdm,inv_fcspyeb.khdm,inv_fcspyeb.bmdm) clnc" &
                    " Left join (SELECT oe_xsd.cpdm,oe_xsd.khdm,oe_xsd.bmdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND oe_xsd.je <> 0 AND TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') <= ? GROUP BY oe_xsd.cpdm,oe_xsd.khdm,oe_xsd.bmdm) qcxsck ON clnc.cpdm = qcxsck.cpdm AND clnc.khdm = qcxsck.khdm AND clnc.bmdm = qcxsck.bmdm" &
                    " Left join (SELECT oe_fp.cpdm,oe_fp.shkhdm as khdm,oe_fp.bmdm,sum(oe_fp.sl) as qcfpcksl,sum(oe_fp.cbje) as qcfpckje FROM oe_fp WHERE oe_fp.bdelete = 0 AND TRUNC(oe_fp.fprq,'mi') >= ? and TRUNC(oe_fp.fprq,'mi') >= ? and TRUNC(oe_fp.fprq,'mi') <= ? GROUP BY oe_fp.cpdm,oe_fp.shkhdm,oe_fp.bmdm) qcfpck ON clnc.cpdm = qcfpck.cpdm AND clnc.khdm = qcfpck.khdm AND clnc.bmdm = qcfpck.bmdm) asfchz GROUP BY cpdm,khdm,bmdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateFcspBegin.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = datePoBegin1
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateJsrq
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateFcspBegin.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = datePoBegin1
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateJsrq
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("clqcye") IsNot Nothing Then
                rcDataset.Tables("clqcye").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "clqcye")
            For j = 0 To rcDataset.Tables("clqcye").Rows.Count - 1
                '计算库存数量，库存金额
                dblQcsl = rcDataset.Tables("clqcye").Rows(j).Item("qcsl") + rcDataset.Tables("clqcye").Rows(j).Item("qcxscksl") - rcDataset.Tables("clqcye").Rows(j).Item("qcfpcksl")
                dblQcje = rcDataset.Tables("clqcye").Rows(j).Item("qcje") + rcDataset.Tables("clqcye").Rows(j).Item("qcxsckje") - rcDataset.Tables("clqcye").Rows(j).Item("qcfpckje")
                '需要调整
                If dblQcsl = 0 And dblQcje <> 0 Then
                    'MsgBox(rcDataset.Tables("clqcye").Rows(j).Item("cpdm"))
                    '调整到oe_fp
                    rcOleDbCommand.CommandText = "SELECT djh,xh FROM oe_fp WHERE NOT EXISTS (SELECT 1 FROM oe_xsd s WHERE s.bdelete = 0
                    AND xsrq >= ? /*发出商品启用时间*/
                    AND xsrq <= ? /*销售出库结束时间*/
                    AND s.vbillcode = oe_fp.xsddjh
                    AND s.crowno = oe_fp.xsdxh) /*销售发票在销售出库中存在才算*/
                    AND oe_fp.fprq >= ? AND oe_fp.fprq <= ? AND oe_fp.cpdm = ? AND oe_fp.shkhdm = ? AND oe_fp.bmdm = ? ORDER BY cbje DESC,je DESC"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@paraDateXsrq", OleDbType.Date, 8).Value = dateFcspBegin.Date '/*发出商品启用时间*/
                    rcOleDbCommand.Parameters.Add("@paraDateXsrq", OleDbType.Date, 8).Value = dateJsrq
                    rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateKsrq
                    rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateJsrq
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("clqcye").Rows(j).Item("cpdm")
                    rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("clqcye").Rows(j).Item("khdm")
                    rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("clqcye").Rows(j).Item("bmdm")
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("oe_fp") IsNot Nothing Then
                        rcDataset.Tables("oe_fp").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "oe_fp")
                    If rcDataset.Tables("oe_fp").Rows.Count > 0 Then
                        rcOleDbCommand.CommandText = "UPDATE oe_fp SET oe_fp.cbje = oe_fp.cbje + ? WHERE oe_fp.xh = ? AND oe_fp.djh = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@qcje", OleDbType.Numeric, 18).Value = dblQcje
                        rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = rcDataset.Tables("oe_fp").Rows(0).Item("xh")
                        rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataset.Tables("oe_fp").Rows(0).Item("djh")
                        rcOleDbCommand.ExecuteNonQuery()
                        'MsgBox(rcDataset.Tables("clqcye").Rows(j).Item("cpdm") & rcDataset.Tables("oe_fp").Rows(0).Item("djh"))
                    Else
                        '未查到销售出库单号相同的发票
                        '查找产品部门客户相同的金额最大的一张销售发票进行调整
                        rcOleDbCommand.CommandText = "SELECT djh,xh FROM oe_fp WHERE oe_fp.fprq >= ? AND oe_fp.fprq <= ? AND oe_fp.cpdm = ? AND oe_fp.shkhdm = ? AND oe_fp.bmdm = ? ORDER BY cbje DESC,je DESC"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateKsrq.Date '/*本期开始时间*/
                        rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateJsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("clqcye").Rows(j).Item("cpdm")
                        rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("clqcye").Rows(j).Item("khdm")
                        rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("clqcye").Rows(j).Item("bmdm")
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("oe_fp") IsNot Nothing Then
                            rcDataset.Tables("oe_fp").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "oe_fp")
                        If rcDataset.Tables("oe_fp").Rows.Count > 0 Then
                            rcOleDbCommand.CommandText = "UPDATE oe_fp SET oe_fp.cbje = oe_fp.cbje + ? WHERE oe_fp.xh = ? AND oe_fp.djh = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@qcje", OleDbType.Numeric, 18).Value = dblQcje
                            rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = rcDataset.Tables("oe_fp").Rows(0).Item("xh")
                            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataset.Tables("oe_fp").Rows(0).Item("djh")
                            rcOleDbCommand.ExecuteNonQuery()
                        Else
                            'MsgBox("未找到可调整的销售发票，产品：" & rcDataset.Tables("clqcye").Rows(j).Item("cpdm"))
                        End If
                    End If
                End If
            Next
            rcOleDbTrans.Commit()
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP3_REDO_FCSPYEHZ"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@ParaStrYear", OleDbType.VarChar, 4).Value = Me.NudYear.Value
            rcOleDbCommand.Parameters.Add("@dwrq", OleDbType.Date, 8).Value = dateFcspBegin
            rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
            rcOleDbCommand.ExecuteNonQuery()
            If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                    MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                    Return
                End If
            End If
        Catch ex As Exception
            Try
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try


        MsgBox("发出商品成本结转完成。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        Me.Close()
    End Sub
End Class