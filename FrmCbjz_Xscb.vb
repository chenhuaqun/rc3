Imports System.Data.OleDb

Public Class FrmCbjz_Xscb
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

#Region "初始化"

    Private Sub FrmCbjz_Xscb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        Dim dblQcsl As Double
        Dim dblQcje As Double
        Dim dblQcdj As Double
        '结转成本
        If Me.CheckBox4.Checked Then
            '汇总总账
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
            '读取收发存汇总表
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                '取分仓库不含本期调拨与本期出库数据的收发存汇总表
                rcOleDbCommand.CommandText = "SELECT cpdm,ckdm,COALESCE(sum(qcsl),0.0) as qcsl,COALESCE(sum(qcje),0.0) as qcje,COALESCE(sum(qccgrksl),0.0) as qccgrksl,COALESCE(sum(qccgrkje),0.0) as qccgrkje,COALESCE(sum(qcscrksl),0.0) as qcscrksl,COALESCE(sum(qcscrkje),0.0) as qcscrkje,COALESCE(sum(qcdbrksl),0.0) as qcdbrksl,COALESCE(sum(qcdbrkje),0.0) as qcdbrkje,COALESCE(sum(qcxscksl),0.0) as qcxscksl,COALESCE(sum(qcxsckje),0.0) as qcxsckje,COALESCE(sum(qcckcksl),0.0) as qcckcksl,COALESCE(sum(qcckckje),0.0) as qcckckje,COALESCE(sum(qcdbcksl),0.0) as qcdbcksl,COALESCE(sum(qcdbckje),0.0) as qcdbckje FROM (SELECT clnc.cpdm,clnc.ckdm,clnc.qcsl,clnc.qcje,qccgrk.qccgrksl,qccgrk.qccgrkje,qcscrk.qcscrksl,qcscrk.qcscrkje,qcdbrk.qcdbrksl,qcdbrk.qcdbrkje,qcxsck.qcxscksl,qcxsck.qcxsckje,qcckck.qcckcksl,qcckck.qcckckje,qcdbck.qcdbcksl,qcdbck.qcdbckje FROM" &
                    " (SELECT inv_cpyeb.cpdm,inv_cpyeb.ckdm,sum(qcsl) as qcsl,sum(qcje) as qcje FROM inv_cpyeb WHERE kjnd = ? AND EXISTS (SELECT 1 FROM inv_dbd WHERE inv_dbd.cpdm = inv_cpyeb.cpdm) GROUP by inv_cpyeb.cpdm,inv_cpyeb.ckdm) clnc" &
                    " Left join (SELECT po_rkd.cpdm,po_rkd.ckdm,sum(po_rkd.sl) as qccgrksl,sum(po_rkd.je) as qccgrkje FROM po_rkd WHERE po_rkd.bdelete = 0 AND TRUNC(po_rkd.rkrq,'mi') >= ? AND TRUNC(po_rkd.rkrq,'mi') >= ? AND TRUNC(po_rkd.rkrq,'mi') <= ? GROUP BY po_rkd.cpdm,po_rkd.ckdm) qccgrk ON clnc.cpdm = qccgrk.cpdm AND clnc.ckdm = qccgrk.ckdm" &
                    " Left join (SELECT inv_rkd.cpdm,inv_rkd.ckdm,sum(inv_rkd.sl) as qcscrksl,sum(inv_rkd.je) as qcscrkje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') <= ? GROUP BY inv_rkd.cpdm,inv_rkd.ckdm) qcscrk ON clnc.cpdm = qcscrk.cpdm AND clnc.ckdm = qcscrk.ckdm" &
                    " Left join (SELECT inv_dbd.cpdm,inv_dbd.rckdm AS ckdm,sum(inv_dbd.sl) as qcdbrksl,sum(inv_dbd.je) as qcdbrkje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ? GROUP BY inv_dbd.cpdm,inv_dbd.rckdm) qcdbrk ON clnc.cpdm = qcdbrk.cpdm AND clnc.ckdm = qcdbrk.ckdm" &
                    " Left join (SELECT oe_xsd.cpdm,oe_xsd.ckdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') < ? GROUP BY oe_xsd.cpdm,oe_xsd.ckdm) qcxsck ON clnc.cpdm = qcxsck.cpdm AND clnc.ckdm = qcxsck.ckdm" &
                    " Left join (SELECT inv_ckd.cpdm,inv_ckd.ckdm,sum(inv_ckd.sl) as qcckcksl,sum(inv_ckd.je) as qcckckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') < ? GROUP BY inv_ckd.cpdm,inv_ckd.ckdm) qcckck ON clnc.cpdm = qcckck.cpdm AND clnc.ckdm = qcckck.ckdm" &
                    " Left join (SELECT inv_dbd.cpdm,inv_dbd.cckdm AS ckdm,sum(inv_dbd.sl) as qcdbcksl,sum(inv_dbd.je) as qcdbckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ? GROUP BY inv_dbd.cpdm,inv_dbd.cckdm) qcdbck ON clnc.cpdm = qcdbck.cpdm AND clnc.ckdm = qcdbck.ckdm) asfchz GROUP BY cpdm,ckdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePoBegin1
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePoBegin1
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePoBegin1
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateKsrq
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = datePoBegin1
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq
                rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = datePoBegin1
                rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateKsrq
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePoBegin1
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateKsrq
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("clqcye") IsNot Nothing Then
                    rcDataset.Tables("clqcye").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "clqcye")
                '调拨单成本清零
                rcOleDbCommand.CommandText = "UPDATE inv_dbd SET inv_dbd.je = 0.0,inv_dbd.dj = 0.0 WHERE SUBSTR(inv_dbd.djh,5,6) >= ? AND SUBSTR(inv_dbd.djh,5,6) <= ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                For i = 0 To rcDataset.Tables("clqcye").Rows.Count - 1
                    Me.ProgressBar1.Value = 100 / rcDataset.Tables("clqcye").Rows.Count * (i + 1)
                    '取平均单价
                    dblQcsl = rcDataset.Tables("clqcye").Rows(i).Item("qcsl") + rcDataset.Tables("clqcye").Rows(i).Item("qccgrksl") + rcDataset.Tables("clqcye").Rows(i).Item("qcscrksl") + rcDataset.Tables("clqcye").Rows(i).Item("qcdbrksl") - rcDataset.Tables("clqcye").Rows(i).Item("qcxscksl") - rcDataset.Tables("clqcye").Rows(i).Item("qcckcksl") - rcDataset.Tables("clqcye").Rows(i).Item("qcdbcksl")
                    dblQcje = rcDataset.Tables("clqcye").Rows(i).Item("qcje") + rcDataset.Tables("clqcye").Rows(i).Item("qccgrkje") + rcDataset.Tables("clqcye").Rows(i).Item("qcscrkje") + rcDataset.Tables("clqcye").Rows(i).Item("qcdbrkje") - rcDataset.Tables("clqcye").Rows(i).Item("qcxsckje") - rcDataset.Tables("clqcye").Rows(i).Item("qcckckje") - rcDataset.Tables("clqcye").Rows(i).Item("qcdbckje")
                    '计算产品调拨成本单价=上月的账面金额+本月入库金额/上月账面数量+本月入库数量
                    If dblQcsl <> 0 Then
                        dblQcdj = dblQcje / dblQcsl
                    Else
                        dblQcdj = 0.0
                    End If
                    rcOleDbCommand.CommandText = "UPDATE inv_dbd SET inv_dbd.je = inv_dbd.sl * ?,inv_dbd.dj = ? WHERE inv_dbd.cpdm = ? AND cckdm = ? AND SUBSTR(inv_dbd.djh,5,6) >= ? AND SUBSTR(inv_dbd.djh,5,6) <= ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                    rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("clqcye").Rows(i).Item("cpdm")
                    rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("clqcye").Rows(i).Item("ckdm"))
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.ExecuteNonQuery()
                Next
                '取分仓库含本期调拨与本期出库数据的收发存汇总表
                '分仓库汇总,含调拨单的入库数量与金额，用来计算出库单的出库成本
                rcOleDbCommand.CommandText = "SELECT cpdm,ckdm,COALESCE(sum(qcsl),0.0) as qcsl,COALESCE(sum(qcje),0.0) as qcje,COALESCE(sum(qccgrksl),0.0) as qccgrksl,COALESCE(sum(qccgrkje),0.0) as qccgrkje,COALESCE(sum(qcscrksl),0.0) as qcscrksl,COALESCE(sum(qcscrkje),0.0) as qcscrkje,COALESCE(sum(qcdbrksl),0.0) as qcdbrksl,COALESCE(sum(qcdbrkje),0.0) as qcdbrkje,COALESCE(sum(qcxscksl),0.0) as qcxscksl,COALESCE(sum(qcxsckje),0.0) as qcxsckje,COALESCE(sum(qcckcksl),0.0) as qcckcksl,COALESCE(sum(qcckckje),0.0) as qcckckje,COALESCE(sum(qcdbcksl),0.0) as qcdbcksl,COALESCE(sum(qcdbckje),0.0) as qcdbckje FROM (SELECT clnc.cpdm,clnc.ckdm,clnc.qcsl,clnc.qcje,qccgrk.qccgrksl,qccgrk.qccgrkje,qcscrk.qcscrksl,qcscrk.qcscrkje,qcdbrk.qcdbrksl,qcdbrk.qcdbrkje,qcxsck.qcxscksl,qcxsck.qcxsckje,qcckck.qcckcksl,qcckck.qcckckje,qcdbck.qcdbcksl,qcdbck.qcdbckje FROM" &
                    " (SELECT inv_cpyeb.cpdm,inv_cpyeb.ckdm,sum(qcsl) as qcsl,sum(qcje) as qcje FROM inv_cpyeb WHERE kjnd = ? AND EXISTS (SELECT 1 FROM oe_xsd WHERE oe_xsd.cpdm = inv_cpyeb.cpdm) GROUP by inv_cpyeb.cpdm,inv_cpyeb.ckdm) clnc" &
                    " Left join (SELECT po_rkd.cpdm,po_rkd.ckdm,sum(po_rkd.sl) as qccgrksl,sum(po_rkd.je) as qccgrkje FROM po_rkd WHERE po_rkd.bdelete = 0 AND TRUNC(po_rkd.rkrq,'mi') >= ? and TRUNC(po_rkd.rkrq,'mi') >= ? and TRUNC(po_rkd.rkrq,'mi') <= ? GROUP BY po_rkd.cpdm,po_rkd.ckdm) qccgrk ON clnc.cpdm = qccgrk.cpdm AND clnc.ckdm = qccgrk.ckdm" &
                    " Left join (SELECT inv_rkd.cpdm,inv_rkd.ckdm,sum(inv_rkd.sl) as qcscrksl,sum(inv_rkd.je) as qcscrkje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') <= ? GROUP BY inv_rkd.cpdm,inv_rkd.ckdm) qcscrk ON clnc.cpdm = qcscrk.cpdm AND clnc.ckdm = qcscrk.ckdm" &
                    " Left join (SELECT inv_dbd.cpdm,inv_dbd.rckdm AS ckdm,sum(inv_dbd.sl) as qcdbrksl,sum(inv_dbd.je) as qcdbrkje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ? GROUP BY inv_dbd.cpdm,inv_dbd.rckdm) qcdbrk ON clnc.cpdm = qcdbrk.cpdm AND clnc.ckdm = qcdbrk.ckdm" &
                    " Left join (SELECT oe_xsd.cpdm,oe_xsd.ckdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') < ? GROUP BY oe_xsd.cpdm,oe_xsd.ckdm) qcxsck ON clnc.cpdm = qcxsck.cpdm AND clnc.ckdm = qcxsck.ckdm" &
                    " Left join (SELECT inv_ckd.cpdm,inv_ckd.ckdm,sum(inv_ckd.sl) as qcckcksl,sum(inv_ckd.je) as qcckckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') <= ? GROUP BY inv_ckd.cpdm,inv_ckd.ckdm) qcckck ON clnc.cpdm = qcckck.cpdm AND clnc.ckdm = qcckck.ckdm" &
                    " Left join (SELECT inv_dbd.cpdm,inv_dbd.cckdm AS ckdm,sum(inv_dbd.sl) as qcdbcksl,sum(inv_dbd.je) as qcdbckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ? GROUP BY inv_dbd.cpdm,inv_dbd.cckdm) qcdbck ON clnc.cpdm = qcdbck.cpdm AND clnc.ckdm = qcdbck.ckdm) asfchz GROUP BY cpdm,ckdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePoBegin1
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePoBegin1
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePoBegin1
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = datePoBegin1
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq
                rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = datePoBegin1
                rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePoBegin1
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("clqcye") IsNot Nothing Then
                    rcDataset.Tables("clqcye").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "clqcye")
                '更新出库成本
                For i = 0 To rcDataset.Tables("clqcye").Rows.Count - 1
                    '取平均单价
                    dblQcsl = rcDataset.Tables("clqcye").Rows(i).Item("qcsl") + rcDataset.Tables("clqcye").Rows(i).Item("qccgrksl") + rcDataset.Tables("clqcye").Rows(i).Item("qcscrksl") + rcDataset.Tables("clqcye").Rows(i).Item("qcdbrksl") - rcDataset.Tables("clqcye").Rows(i).Item("qcxscksl") - rcDataset.Tables("clqcye").Rows(i).Item("qcckcksl") - rcDataset.Tables("clqcye").Rows(i).Item("qcdbcksl")
                    dblQcje = rcDataset.Tables("clqcye").Rows(i).Item("qcje") + rcDataset.Tables("clqcye").Rows(i).Item("qccgrkje") + rcDataset.Tables("clqcye").Rows(i).Item("qcscrkje") + rcDataset.Tables("clqcye").Rows(i).Item("qcdbrkje") - rcDataset.Tables("clqcye").Rows(i).Item("qcxsckje") - rcDataset.Tables("clqcye").Rows(i).Item("qcckckje") - rcDataset.Tables("clqcye").Rows(i).Item("qcdbckje")
                    '计算产品调拨成本单价=上月的账面金额+本月入库金额/上月账面数量+本月入库数量
                    If dblQcsl <> 0 Then
                        dblQcdj = dblQcje / dblQcsl
                    Else
                        dblQcdj = 0.0
                    End If
                    'MsgBox(Str(dblQcdj) + "/" + rcDataSet.Tables("cpxx").Rows(i).Item("cpdm") + "/" + rcDataSet.Tables("clqcye").Rows(j).Item("ckdm"))

                    ''按平均单价进行更新当月产品出库单的调拨金额=成本单价*退货数量
                    rcOleDbCommand.CommandText = "UPDATE oe_xsd SET oe_xsd.cbje = oe_xsd.sl * ?,oe_xsd.cbdj = ? WHERE oe_xsd.cpdm = ? AND ckdm = ? AND SUBSTR(oe_xsd.djh,5,6) >= ?  AND SUBSTR(oe_xsd.djh,5,6) <= ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                    rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("clqcye").Rows(i).Item("cpdm")
                    rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("clqcye").Rows(i).Item("ckdm")
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.ExecuteNonQuery()
                    If Me.CheckBox1.Checked Then
                        ''按标准成本进行更新当月的退货成本或退货销售
                        rcOleDbCommand.CommandText = "UPDATE oe_xsd SET oe_xsd.cbje = oe_xsd.sl * (SELECT bzcb FROM rc_cpxx WHERE rc_cpxx.cpdm = oe_xsd.cpdm),oe_xsd.cbdj = (SELECT bzcb FROM rc_cpxx WHERE rc_cpxx.cpdm = oe_xsd.cpdm) WHERE oe_xsd.cpdm = ? AND ckdm = ? AND SUBSTR(oe_xsd.djh,5,6) >= ?  AND SUBSTR(oe_xsd.djh,5,6) <= ? AND oe_xsd.cbdj = 0.0"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("clqcye").Rows(i).Item("cpdm")
                        rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("clqcye").Rows(i).Item("ckdm")
                        rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
                        rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                Next
                '调整出库成本
                If Me.CheckBox2.Checked Then
                    '退货无销售成本的业务，按最新入库单价计算销售成本
                    rcOleDbCommand.CommandText = "SELECT djh,xh,cpdm FROM oe_xsd WHERE cbje = 0 AND sl < 0 AND oe_xsd.xsrq <= ? AND oe_xsd.xsrq >= ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateJsrq
                    rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq
                    'rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("clqcye").Rows(i).Item("cpdm"))
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("oe_xsd") IsNot Nothing Then
                        rcDataset.Tables("oe_xsd").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "oe_xsd")
                    For j = 0 To rcDataset.Tables("oe_xsd").Rows.Count - 1
                        rcOleDbCommand.CommandText = "SELECT COALESCE(dj,0.0) AS dj FROM ((SELECT rkrq,dj FROM po_rkd WHERE dj <> 0 AND sl > 0 AND po_rkd.cpdm = ?) UNION (SELECT rkrq,dj FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND dj <> 0 AND sl >0 AND inv_rkd.cpdm = ?)) rkd ORDER BY rkd.rkrq DESC"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("oe_xsd").Rows(j).Item("cpdm"))
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("oe_xsd").Rows(j).Item("cpdm"))
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rkd") IsNot Nothing Then
                            rcDataset.Tables("rkd").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rkd")
                        If rcDataset.Tables("rkd").Rows.Count > 0 Then
                            rcOleDbCommand.CommandText = "UPDATE oe_xsd SET oe_xsd.dj =  ?,oe_xsd.cbje = oe_xsd.sl * ? WHERE oe_xsd.xh = ? AND oe_xsd.djh = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@cbje", OleDbType.Numeric, 18).Value = rcDataset.Tables("rkd").Rows(0).Item("dj")
                            rcOleDbCommand.Parameters.Add("@cbje", OleDbType.Numeric, 18).Value = rcDataset.Tables("rkd").Rows(0).Item("dj")
                            rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = rcDataset.Tables("oe_xsd").Rows(j).Item("xh")
                            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataset.Tables("oe_xsd").Rows(j).Item("djh")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    Next
                End If
                '调整尾差，计算库存数量，库存金额
                rcOleDbCommand.CommandText = "SELECT cpdm,ckdm,COALESCE(sum(qcsl),0.0) as qcsl,COALESCE(sum(qcje),0.0) as qcje,COALESCE(sum(qccgrksl),0.0) as qccgrksl,COALESCE(sum(qccgrkje),0.0) as qccgrkje,COALESCE(sum(qcscrksl),0.0) as qcscrksl,COALESCE(sum(qcscrkje),0.0) as qcscrkje,COALESCE(sum(qcdbrksl),0.0) as qcdbrksl,COALESCE(sum(qcdbrkje),0.0) as qcdbrkje,COALESCE(sum(qcxscksl),0.0) as qcxscksl,COALESCE(sum(qcxsckje),0.0) as qcxsckje,COALESCE(sum(qcckcksl),0.0) as qcckcksl,COALESCE(sum(qcckckje),0.0) as qcckckje,COALESCE(sum(qcdbcksl),0.0) as qcdbcksl,COALESCE(sum(qcdbckje),0.0) as qcdbckje FROM (SELECT clnc.cpdm,clnc.ckdm,clnc.qcsl,clnc.qcje,qccgrk.qccgrksl,qccgrk.qccgrkje,qcscrk.qcscrksl,qcscrk.qcscrkje,qcdbrk.qcdbrksl,qcdbrk.qcdbrkje,qcxsck.qcxscksl,qcxsck.qcxsckje,qcckck.qcckcksl,qcckck.qcckckje,qcdbck.qcdbcksl,qcdbck.qcdbckje FROM" &
                    " (SELECT inv_cpyeb.cpdm,inv_cpyeb.ckdm,sum(qcsl) as qcsl,sum(qcje) as qcje FROM inv_cpyeb WHERE kjnd = ? GROUP by inv_cpyeb.cpdm,inv_cpyeb.ckdm) clnc" &
                    " Left join (SELECT po_rkd.cpdm,po_rkd.ckdm,sum(po_rkd.sl) as qccgrksl,sum(po_rkd.je) as qccgrkje FROM po_rkd WHERE po_rkd.bdelete = 0 AND TRUNC(po_rkd.rkrq,'mi') >= ? and TRUNC(po_rkd.rkrq,'mi') >= ? and TRUNC(po_rkd.rkrq,'mi') <= ? GROUP BY po_rkd.cpdm,po_rkd.ckdm) qccgrk ON clnc.cpdm = qccgrk.cpdm AND clnc.ckdm = qccgrk.ckdm" &
                    " Left join (SELECT inv_rkd.cpdm,inv_rkd.ckdm,sum(inv_rkd.sl) as qcscrksl,sum(inv_rkd.je) as qcscrkje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') <= ? GROUP BY inv_rkd.cpdm,inv_rkd.ckdm) qcscrk ON clnc.cpdm = qcscrk.cpdm AND clnc.ckdm = qcscrk.ckdm" &
                    " Left join (SELECT inv_dbd.cpdm,inv_dbd.rckdm AS ckdm,sum(inv_dbd.sl) as qcdbrksl,sum(inv_dbd.je) as qcdbrkje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ? GROUP BY inv_dbd.cpdm,inv_dbd.rckdm) qcdbrk ON clnc.cpdm = qcdbrk.cpdm AND clnc.ckdm = qcdbrk.ckdm" &
                    " Left join (SELECT oe_xsd.cpdm,oe_xsd.ckdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') <= ? GROUP BY oe_xsd.cpdm,oe_xsd.ckdm) qcxsck ON clnc.cpdm = qcxsck.cpdm AND clnc.ckdm = qcxsck.ckdm" &
                    " Left join (SELECT inv_ckd.cpdm,inv_ckd.ckdm,sum(inv_ckd.sl) as qcckcksl,sum(inv_ckd.je) as qcckckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') <= ? GROUP BY inv_ckd.cpdm,inv_ckd.ckdm) qcckck ON clnc.cpdm = qcckck.cpdm AND clnc.ckdm = qcckck.ckdm" &
                    " Left join (SELECT inv_dbd.cpdm,inv_dbd.cckdm AS ckdm,sum(inv_dbd.sl) as qcdbcksl,sum(inv_dbd.je) as qcdbckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ? GROUP BY inv_dbd.cpdm,inv_dbd.cckdm) qcdbck ON clnc.cpdm = qcdbck.cpdm AND clnc.ckdm = qcdbck.ckdm) asfchz GROUP BY cpdm,ckdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePoBegin1
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePoBegin1
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePoBegin1
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = datePoBegin1
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = datePoBegin1
                rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePoBegin1
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("clqcye") IsNot Nothing Then
                    rcDataset.Tables("clqcye").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "clqcye")
                For j = 0 To rcDataset.Tables("clqcye").Rows.Count - 1
                    '计算库存数量，库存金额
                    dblQcsl = rcDataset.Tables("clqcye").Rows(j).Item("qcsl") + rcDataset.Tables("clqcye").Rows(j).Item("qccgrksl") + rcDataset.Tables("clqcye").Rows(j).Item("qcscrksl") + rcDataset.Tables("clqcye").Rows(j).Item("qcdbrksl") - rcDataset.Tables("clqcye").Rows(j).Item("qcxscksl") - rcDataset.Tables("clqcye").Rows(j).Item("qcckcksl") - rcDataset.Tables("clqcye").Rows(j).Item("qcdbcksl")
                    dblQcje = rcDataset.Tables("clqcye").Rows(j).Item("qcje") + rcDataset.Tables("clqcye").Rows(j).Item("qccgrkje") + rcDataset.Tables("clqcye").Rows(j).Item("qcscrkje") + rcDataset.Tables("clqcye").Rows(j).Item("qcdbrkje") - rcDataset.Tables("clqcye").Rows(j).Item("qcxsckje") - rcDataset.Tables("clqcye").Rows(j).Item("qcckckje") - rcDataset.Tables("clqcye").Rows(j).Item("qcdbckje")
                    '需要调整
                    If dblQcsl = 0 And dblQcje <> 0 Then
                        '调整到oe_xsd
                        rcOleDbCommand.CommandText = "SELECT djh,xh FROM oe_xsd WHERE oe_xsd.xsrq >= ? AND oe_xsd.xsrq <= ? AND oe_xsd.cpdm = ? AND oe_xsd.ckdm = ? ORDER BY cbje DESC"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq
                        rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateJsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("clqcye").Rows(j).Item("cpdm")
                        rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("clqcye").Rows(j).Item("ckdm")
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("oe_xsd") IsNot Nothing Then
                            rcDataset.Tables("oe_xsd").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "oe_xsd")
                        If rcDataset.Tables("oe_xsd").Rows.Count > 0 Then
                            rcOleDbCommand.CommandText = "UPDATE oe_xsd SET oe_xsd.cbje = oe_xsd.cbje + ? WHERE oe_xsd.xh = ? AND oe_xsd.djh = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@qcje", OleDbType.Numeric, 18).Value = dblQcje
                            rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = rcDataset.Tables("oe_xsd").Rows(0).Item("xh")
                            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataset.Tables("oe_xsd").Rows(0).Item("djh")
                            rcOleDbCommand.ExecuteNonQuery()
                        Else
                            '调整到inv_dbd
                            rcOleDbCommand.CommandText = "SELECT djh,xh FROM inv_dbd WHERE inv_dbd.dbrq >= ? AND inv_dbd.dbrq <= ? AND inv_dbd.cpdm = ? AND inv_dbd.cckdm = ? ORDER BY je DESC"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateKsrq
                            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateJsrq
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("clqcye").Rows(j).Item("cpdm")
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("clqcye").Rows(j).Item("ckdm")
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("inv_dbd") IsNot Nothing Then
                                rcDataset.Tables("inv_dbd").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "inv_dbd")
                            If rcDataset.Tables("inv_dbd").Rows.Count > 0 Then
                                rcOleDbCommand.CommandText = "UPDATE inv_dbd SET inv_dbd.je = inv_dbd.je + ? WHERE inv_dbd.xh = ? AND inv_dbd.djh = ?"
                                rcOleDbCommand.Parameters.Clear()
                                rcOleDbCommand.Parameters.Add("@qcje", OleDbType.Numeric, 18).Value = dblQcje
                                rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = rcDataset.Tables("inv_dbd").Rows(0).Item("xh")
                                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataset.Tables("inv_dbd").Rows(0).Item("djh")
                                rcOleDbCommand.ExecuteNonQuery()
                            Else
                                '提示未调整
                                '’MsgBox("尾差未调整,产品编码是(" & rcDataSet.Tables("cpxx").Rows(i).Item("cpdm") & ")", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
                            End If

                        End If

                    End If
                Next
                rcOleDbTrans.Commit()
                rcOleDbCommand.CommandType = CommandType.StoredProcedure
                rcOleDbCommand.CommandText = "USP3_REDO_CPYEHZ"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ParaStrYear", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                rcOleDbCommand.Parameters.Add("@dwrq", OleDbType.Date, 8).Value = g_Dwrq
                rcOleDbCommand.ExecuteNonQuery()
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


            MsgBox("成本结转完成。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Me.Close()
        Else
            '结转退货单的成本
            '结转出库单的成本
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                '取材料信息
                rcOleDbCommand.CommandText = "SELECT rc_cpxx.cpdm FROM rc_cpxx ORDER BY rc_cpxx.cpdm" ',rc_cpxx.jjfs
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("cpxx") IsNot Nothing Then
                    rcDataset.Tables("cpxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "cpxx")
                For i = 0 To rcDataset.Tables("cpxx").Rows.Count - 1
                    Me.ProgressBar1.Value = 100 / rcDataset.Tables("cpxx").Rows.Count * (i + 1)
                    '计算该产品该仓库的上月账面数量+本月入库数量、上月的账面金额+本月入库金额
                    '分仓库汇总,不含调拨单的入库数量与金额，用来计算调拨单的出库成本
                    '''''''''''''''''''''''''''''''
                    ''''''''''加权平均法'''''''''''
                    '''''''''''''''''''''''''''''''
                    rcOleDbCommand.CommandText = "SELECT cpdm,ckdm,COALESCE(sum(qcsl),0.0) as qcsl,COALESCE(sum(qcje),0.0) as qcje,COALESCE(sum(qccgrksl),0.0) as qccgrksl,COALESCE(sum(qccgrkje),0.0) as qccgrkje,COALESCE(sum(qcscrksl),0.0) as qcscrksl,COALESCE(sum(qcscrkje),0.0) as qcscrkje,COALESCE(sum(qcdbrksl),0.0) as qcdbrksl,COALESCE(sum(qcdbrkje),0.0) as qcdbrkje,COALESCE(sum(qcxscksl),0.0) as qcxscksl,COALESCE(sum(qcxsckje),0.0) as qcxsckje,COALESCE(sum(qcckcksl),0.0) as qcckcksl,COALESCE(sum(qcckckje),0.0) as qcckckje,COALESCE(sum(qcdbcksl),0.0) as qcdbcksl,COALESCE(sum(qcdbckje),0.0) as qcdbckje FROM (SELECT clnc.cpdm,clnc.ckdm,clnc.qcsl,clnc.qcje,qccgrk.qccgrksl,qccgrk.qccgrkje,qcscrk.qcscrksl,qcscrk.qcscrkje,qcdbrk.qcdbrksl,qcdbrk.qcdbrkje,qcxsck.qcxscksl,qcxsck.qcxsckje,qcckck.qcckcksl,qcckck.qcckckje,qcdbck.qcdbcksl,qcdbck.qcdbckje FROM" &
                    " (SELECT inv_cpyeb.cpdm,inv_cpyeb.ckdm,sum(qcsl) as qcsl,sum(qcje) as qcje FROM inv_cpyeb WHERE kjnd = ? AND cpdm = ? GROUP by inv_cpyeb.cpdm,inv_cpyeb.ckdm) clnc" &
                    " Left join (SELECT po_rkd.cpdm,po_rkd.ckdm,sum(po_rkd.sl) as qccgrksl,sum(po_rkd.je) as qccgrkje FROM po_rkd WHERE po_rkd.bdelete = 0 AND TRUNC(po_rkd.rkrq,'mi') >= ? AND TRUNC(po_rkd.rkrq,'mi') >= ? AND TRUNC(po_rkd.rkrq,'mi') <= ? AND cpdm = ? GROUP BY po_rkd.cpdm,po_rkd.ckdm) qccgrk ON clnc.cpdm = qccgrk.cpdm AND clnc.ckdm = qccgrk.ckdm" &
                    " Left join (SELECT inv_rkd.cpdm,inv_rkd.ckdm,sum(inv_rkd.sl) as qcscrksl,sum(inv_rkd.je) as qcscrkje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') <= ? AND cpdm = ? GROUP BY inv_rkd.cpdm,inv_rkd.ckdm) qcscrk ON clnc.cpdm = qcscrk.cpdm AND clnc.ckdm = qcscrk.ckdm" &
                    " Left join (SELECT inv_dbd.cpdm,inv_dbd.rckdm AS ckdm,sum(inv_dbd.sl) as qcdbrksl,sum(inv_dbd.je) as qcdbrkje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ? AND cpdm = ? GROUP BY inv_dbd.cpdm,inv_dbd.rckdm) qcdbrk ON clnc.cpdm = qcdbrk.cpdm AND clnc.ckdm = qcdbrk.ckdm" &
                    " Left join (SELECT oe_xsd.cpdm,oe_xsd.ckdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') < ? AND cpdm = ? GROUP BY oe_xsd.cpdm,oe_xsd.ckdm) qcxsck ON clnc.cpdm = qcxsck.cpdm AND clnc.ckdm = qcxsck.ckdm" &
                    " Left join (SELECT inv_ckd.cpdm,inv_ckd.ckdm,sum(inv_ckd.sl) as qcckcksl,sum(inv_ckd.je) as qcckckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') < ? AND cpdm = ? GROUP BY inv_ckd.cpdm,inv_ckd.ckdm) qcckck ON clnc.cpdm = qcckck.cpdm AND clnc.ckdm = qcckck.ckdm" &
                    " Left join (SELECT inv_dbd.cpdm,inv_dbd.cckdm AS ckdm,sum(inv_dbd.sl) as qcdbcksl,sum(inv_dbd.je) as qcdbckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ? AND cpdm = ? GROUP BY inv_dbd.cpdm,inv_dbd.cckdm) qcdbck ON clnc.cpdm = qcdbck.cpdm AND clnc.ckdm = qcdbck.ckdm) asfchz GROUP BY cpdm,ckdm"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("cpxx").Rows(i).Item("cpdm"))
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePoBegin1
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("cpxx").Rows(i).Item("cpdm"))
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePoBegin1
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("cpxx").Rows(i).Item("cpdm"))
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePoBegin1
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateKsrq
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("cpxx").Rows(i).Item("cpdm"))
                    rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = datePoBegin1
                    rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("cpxx").Rows(i).Item("cpdm"))
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = datePoBegin1
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateKsrq
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("cpxx").Rows(i).Item("cpdm"))
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePoBegin1
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateKsrq
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("cpxx").Rows(i).Item("cpdm"))
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("clqcye") IsNot Nothing Then
                        rcDataset.Tables("clqcye").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "clqcye")
                    '调拨单成本清零
                    rcOleDbCommand.CommandText = "UPDATE inv_dbd SET inv_dbd.je = 0.0,inv_dbd.dj = 0.0 WHERE inv_dbd.cpdm = ? AND SUBSTR(inv_dbd.djh,5,6) >= ? AND SUBSTR(inv_dbd.djh,5,6) <= ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("cpxx").Rows(i).Item("cpdm")
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.ExecuteNonQuery()
                    If Me.CheckBox3.Checked Then
                        '计算调拨出库合计数小于0的数据
                        rcOleDbCommand.CommandText = "SELECT inv_dbd.cpdm,inv_dbd.cckdm,inv_dbd.rckdm,SUM(sl) AS sl FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') <= ? AND TRUNC(inv_dbd.dbrq,'mi') >= ? AND inv_dbd.cpdm = ? GROUP BY inv_dbd.cpdm,inv_dbd.cckdm,inv_dbd.rckdm HAVING SUM(SL) < 0"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("cpxx").Rows(i).Item("cpdm")
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("redinv_dbd") IsNot Nothing Then
                            rcDataset.Tables("redinv_dbd").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "redinv_dbd")
                        For j = 0 To rcDataset.Tables("redinv_dbd").Rows.Count - 1
                            '取调入仓库的物料的库存金额
                            rcOleDbCommand.CommandText = "SELECT cpdm,ckdm,COALESCE(sum(qcsl),0.0) + COALESCE(sum(qccgrksl),0.0) + COALESCE(sum(qcscrksl),0.0) + COALESCE(sum(qcdbrksl),0.0) + COALESCE(sum(qcxscksl),0.0) - COALESCE(sum(qcckcksl),0.0) - COALESCE(sum(qcdbcksl),0.0) AS qcsl,COALESCE(sum(qcje),0.0) + COALESCE(sum(qccgrkje),0.0) + COALESCE(sum(qcscrkje),0.0) + COALESCE(sum(qcdbrkje),0.0) - COALESCE(sum(qcxsckje),0.0) - COALESCE(sum(qcckckje),0.0) - COALESCE(sum(qcdbckje),0.0) as qcje FROM (SELECT clnc.cpdm,clnc.ckdm,clnc.qcsl,clnc.qcje,qccgrk.qccgrksl,qccgrk.qccgrkje,qcscrk.qcscrksl,qcscrk.qcscrkje,qcdbrk.qcdbrksl,qcdbrk.qcdbrkje,qcxsck.qcxscksl,qcxsck.qcxsckje,qcckck.qcckcksl,qcckck.qcckckje,qcdbck.qcdbcksl,qcdbck.qcdbckje FROM" &
                            " (SELECT inv_cpyeb.cpdm,inv_cpyeb.ckdm,sum(qcsl) as qcsl,sum(qcje) as qcje FROM inv_cpyeb WHERE kjnd = ? AND ckdm = ? AND cpdm = ? GROUP by inv_cpyeb.cpdm,inv_cpyeb.ckdm) clnc" &
                            " Left join (SELECT po_rkd.cpdm,po_rkd.ckdm,sum(po_rkd.sl) as qccgrksl,sum(po_rkd.je) as qccgrkje FROM po_rkd WHERE po_rkd.bdelete = 0 AND TRUNC(po_rkd.rkrq,'mi') >= ? AND TRUNC(po_rkd.rkrq,'mi') >= ? AND TRUNC(po_rkd.rkrq,'mi') <= ? AND po_rkd.ckdm = ? AND po_rkd.cpdm = ? GROUP BY po_rkd.cpdm,po_rkd.ckdm) qccgrk ON clnc.cpdm = qccgrk.cpdm AND clnc.ckdm = qccgrk.ckdm" &
                            " Left join (SELECT inv_rkd.cpdm,inv_rkd.ckdm,sum(inv_rkd.sl) as qcscrksl,sum(inv_rkd.je) as qcscrkje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') <= ? AND inv_rkd.ckdm = ? AND inv_rkd.cpdm = ? GROUP BY inv_rkd.cpdm,inv_rkd.ckdm) qcscrk ON clnc.cpdm = qcscrk.cpdm AND clnc.ckdm = qcscrk.ckdm" &
                            " Left join (SELECT inv_dbd.cpdm,inv_dbd.rckdm AS ckdm,sum(inv_dbd.sl) as qcdbrksl,sum(inv_dbd.je) as qcdbrkje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ? AND inv_dbd.rckdm = ? AND inv_dbd.cpdm = ? GROUP BY inv_dbd.cpdm,inv_dbd.rckdm) qcdbrk ON clnc.cpdm = qcdbrk.cpdm AND clnc.ckdm = qcdbrk.ckdm" &
                            " Left join (SELECT oe_xsd.cpdm,oe_xsd.ckdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') < ? AND oe_xsd.ckdm = ? AND oe_xsd.cpdm = ? GROUP BY oe_xsd.cpdm,oe_xsd.ckdm) qcxsck ON clnc.cpdm = qcxsck.cpdm AND clnc.ckdm = qcxsck.ckdm" &
                            " Left join (SELECT inv_ckd.cpdm,inv_ckd.ckdm,sum(inv_ckd.sl) as qcckcksl,sum(inv_ckd.je) as qcckckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') < ? AND inv_ckd.ckdm = ? AND inv_ckd.cpdm = ? GROUP BY inv_ckd.cpdm,inv_ckd.ckdm) qcckck ON clnc.cpdm = qcckck.cpdm AND clnc.ckdm = qcckck.ckdm" &
                            " Left join (SELECT inv_dbd.cpdm,inv_dbd.cckdm AS ckdm,sum(inv_dbd.sl) as qcdbcksl,sum(inv_dbd.je) as qcdbckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ? AND inv_dbd.cckdm = ? AND inv_dbd.cpdm = ? GROUP BY inv_dbd.cpdm,inv_dbd.cckdm) qcdbck ON clnc.cpdm = qcdbck.cpdm AND clnc.ckdm = qcdbck.ckdm) asfchz GROUP BY cpdm,ckdm"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("redinv_dbd").Rows(i).Item("rckdm"))
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("cpxx").Rows(i).Item("cpdm"))
                            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePoBegin1
                            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("redinv_dbd").Rows(i).Item("rckdm"))
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("cpxx").Rows(i).Item("cpdm"))
                            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePoBegin1
                            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("redinv_dbd").Rows(i).Item("rckdm"))
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("cpxx").Rows(i).Item("cpdm"))
                            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePoBegin1
                            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateKsrq
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("redinv_dbd").Rows(i).Item("rckdm"))
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("cpxx").Rows(i).Item("cpdm"))
                            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = datePoBegin1
                            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("redinv_dbd").Rows(i).Item("rckdm"))
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("cpxx").Rows(i).Item("cpdm"))
                            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = datePoBegin1
                            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateKsrq
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("redinv_dbd").Rows(i).Item("rckdm"))
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("cpxx").Rows(i).Item("cpdm"))
                            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePoBegin1
                            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateKsrq
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("redinv_dbd").Rows(i).Item("rckdm"))
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("cpxx").Rows(i).Item("cpdm"))
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("clsyye") IsNot Nothing Then
                                rcDataset.Tables("clsyye").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "clsyye")
                            '如果不为0，则替换
                            If rcDataset.Tables("clsyye").Rows.Count > 0 Then
                                If rcDataset.Tables("clsyye").Rows(0).Item("qcsl") <> 0 And rcDataset.Tables("clsyye").Rows(0).Item("qcje") <> 0 Then
                                    rcOleDbCommand.CommandText = "UPDATE inv_dbd SET inv_dbd.je = inv_dbd.sl * ?,inv_dbd.dj = ? WHERE inv_dbd.cpdm = ? AND cckdm = ? AND rckdm = ? AND SUBSTR(inv_dbd.djh,5,6) >= ? AND SUBSTR(inv_dbd.djh,5,6) <= ?"
                                    rcOleDbCommand.Parameters.Clear()
                                    rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = rcDataset.Tables("clsyye").Rows(0).Item("qcje") / rcDataset.Tables("clsyye").Rows(0).Item("qcsl")
                                    rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = rcDataset.Tables("clsyye").Rows(0).Item("qcje") / rcDataset.Tables("clsyye").Rows(0).Item("qcsl")
                                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("clsyye").Rows(0).Item("cpdm")
                                    rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("redinv_dbd").Rows(i).Item("cckdm"))
                                    rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("redinv_dbd").Rows(i).Item("rckdm"))
                                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
                                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
                                    rcOleDbCommand.ExecuteNonQuery()
                                End If
                            End If
                        Next
                    End If
                    For j = 0 To rcDataset.Tables("clqcye").Rows.Count - 1
                        '取平均单价
                        dblQcsl = rcDataset.Tables("clqcye").Rows(j).Item("qcsl") + rcDataset.Tables("clqcye").Rows(j).Item("qccgrksl") + rcDataset.Tables("clqcye").Rows(j).Item("qcscrksl") + rcDataset.Tables("clqcye").Rows(j).Item("qcdbrksl") - rcDataset.Tables("clqcye").Rows(j).Item("qcxscksl") - rcDataset.Tables("clqcye").Rows(j).Item("qcckcksl") - rcDataset.Tables("clqcye").Rows(j).Item("qcdbcksl")
                        dblQcje = rcDataset.Tables("clqcye").Rows(j).Item("qcje") + rcDataset.Tables("clqcye").Rows(j).Item("qccgrkje") + rcDataset.Tables("clqcye").Rows(j).Item("qcscrkje") + rcDataset.Tables("clqcye").Rows(j).Item("qcdbrkje") - rcDataset.Tables("clqcye").Rows(j).Item("qcxsckje") - rcDataset.Tables("clqcye").Rows(j).Item("qcckckje") - rcDataset.Tables("clqcye").Rows(j).Item("qcdbckje")
                        '计算产品调拨成本单价=上月的账面金额+本月入库金额/上月账面数量+本月入库数量
                        If dblQcsl <> 0 Then
                            dblQcdj = dblQcje / dblQcsl
                        Else
                            dblQcdj = 0.0
                        End If
                        ''按平均单价进行更新当月产品调拨单的调拨金额=成本单价*退货数量
                        rcOleDbCommand.CommandText = "UPDATE inv_dbd SET inv_dbd.je = inv_dbd.sl * ?,inv_dbd.dj = ? WHERE inv_dbd.cpdm = ? AND cckdm = ? AND inv_dbd.dj = 0.0 AND SUBSTR(inv_dbd.djh,5,6) >= ? AND SUBSTR(inv_dbd.djh,5,6) <= ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                        rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("cpxx").Rows(i).Item("cpdm")
                        rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("clqcye").Rows(j).Item("ckdm")
                        rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
                        rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
                        rcOleDbCommand.ExecuteNonQuery()
                    Next
                    If rcDataset.Tables("clqcye").Rows.Count > 0 Then
                        dblQcsl = rcDataset.Tables("clqcye").Compute("SUM(qcsl)", "") + rcDataset.Tables("clqcye").Compute("SUM(qccgrksl)", "") + rcDataset.Tables("clqcye").Compute("SUM(qcscrksl)", "") + rcDataset.Tables("clqcye").Compute("SUM(qcdbrksl)", "") - rcDataset.Tables("clqcye").Compute("SUM(qcxscksl)", "") - rcDataset.Tables("clqcye").Compute("SUM(qcckcksl)", "") - rcDataset.Tables("clqcye").Compute("SUM(qcdbcksl)", "")
                        dblQcje = rcDataset.Tables("clqcye").Compute("SUM(qcje)", "") + rcDataset.Tables("clqcye").Compute("SUM(qccgrkje)", "") + rcDataset.Tables("clqcye").Compute("SUM(qcscrkje)", "") + rcDataset.Tables("clqcye").Compute("SUM(qcdbrkje)", "") - rcDataset.Tables("clqcye").Compute("SUM(qcxsckje)", "") - rcDataset.Tables("clqcye").Compute("SUM(qcckckje)", "") - rcDataset.Tables("clqcye").Compute("SUM(qcdbckje)", "")
                        If dblQcsl <> 0 Then
                            dblQcdj = dblQcje / dblQcsl
                        Else
                            dblQcdj = 0.0
                        End If
                        ''对于未结转调拨成本按所有仓库的平均单价进行更新当月产品调拨单的调拨金额=成本单价*调拨数量
                        rcOleDbCommand.CommandText = "UPDATE inv_dbd SET inv_dbd.je = inv_dbd.sl * ?,inv_dbd.dj = ? WHERE inv_dbd.cpdm = ? AND inv_dbd.dj = 0.0 AND SUBSTR(inv_dbd.djh,5,6) >= ? AND SUBSTR(inv_dbd.djh,5,6) <= ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                        rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("cpxx").Rows(i).Item("cpdm")
                        rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
                        rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                    '分仓库汇总,含调拨单的入库数量与金额，用来计算出库单的出库成本
                    rcOleDbCommand.CommandText = "SELECT cpdm,ckdm,COALESCE(sum(qcsl),0.0) as qcsl,COALESCE(sum(qcje),0.0) as qcje,COALESCE(sum(qccgrksl),0.0) as qccgrksl,COALESCE(sum(qccgrkje),0.0) as qccgrkje,COALESCE(sum(qcscrksl),0.0) as qcscrksl,COALESCE(sum(qcscrkje),0.0) as qcscrkje,COALESCE(sum(qcdbrksl),0.0) as qcdbrksl,COALESCE(sum(qcdbrkje),0.0) as qcdbrkje,COALESCE(sum(qcxscksl),0.0) as qcxscksl,COALESCE(sum(qcxsckje),0.0) as qcxsckje,COALESCE(sum(qcckcksl),0.0) as qcckcksl,COALESCE(sum(qcckckje),0.0) as qcckckje,COALESCE(sum(qcdbcksl),0.0) as qcdbcksl,COALESCE(sum(qcdbckje),0.0) as qcdbckje FROM (SELECT clnc.cpdm,clnc.ckdm,clnc.qcsl,clnc.qcje,qccgrk.qccgrksl,qccgrk.qccgrkje,qcscrk.qcscrksl,qcscrk.qcscrkje,qcdbrk.qcdbrksl,qcdbrk.qcdbrkje,qcxsck.qcxscksl,qcxsck.qcxsckje,qcckck.qcckcksl,qcckck.qcckckje,qcdbck.qcdbcksl,qcdbck.qcdbckje FROM" &
                    " (SELECT inv_cpyeb.cpdm,inv_cpyeb.ckdm,sum(qcsl) as qcsl,sum(qcje) as qcje FROM inv_cpyeb WHERE kjnd = ? AND cpdm = ? GROUP by inv_cpyeb.cpdm,inv_cpyeb.ckdm) clnc" &
                    " Left join (SELECT po_rkd.cpdm,po_rkd.ckdm,sum(po_rkd.sl) as qccgrksl,sum(po_rkd.je) as qccgrkje FROM po_rkd WHERE po_rkd.bdelete = 0 AND TRUNC(po_rkd.rkrq,'mi') >= ? and TRUNC(po_rkd.rkrq,'mi') >= ? and TRUNC(po_rkd.rkrq,'mi') <= ? AND cpdm = ? GROUP BY po_rkd.cpdm,po_rkd.ckdm) qccgrk ON clnc.cpdm = qccgrk.cpdm AND clnc.ckdm = qccgrk.ckdm" &
                    " Left join (SELECT inv_rkd.cpdm,inv_rkd.ckdm,sum(inv_rkd.sl) as qcscrksl,sum(inv_rkd.je) as qcscrkje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') <= ? AND cpdm = ? GROUP BY inv_rkd.cpdm,inv_rkd.ckdm) qcscrk ON clnc.cpdm = qcscrk.cpdm AND clnc.ckdm = qcscrk.ckdm" &
                    " Left join (SELECT inv_dbd.cpdm,inv_dbd.rckdm AS ckdm,sum(inv_dbd.sl) as qcdbrksl,sum(inv_dbd.je) as qcdbrkje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ? AND cpdm = ? GROUP BY inv_dbd.cpdm,inv_dbd.rckdm) qcdbrk ON clnc.cpdm = qcdbrk.cpdm AND clnc.ckdm = qcdbrk.ckdm" &
                    " Left join (SELECT oe_xsd.cpdm,oe_xsd.ckdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') < ? AND cpdm = ? GROUP BY oe_xsd.cpdm,oe_xsd.ckdm) qcxsck ON clnc.cpdm = qcxsck.cpdm AND clnc.ckdm = qcxsck.ckdm" &
                    " Left join (SELECT inv_ckd.cpdm,inv_ckd.ckdm,sum(inv_ckd.sl) as qcckcksl,sum(inv_ckd.je) as qcckckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') <= ? AND cpdm = ? GROUP BY inv_ckd.cpdm,inv_ckd.ckdm) qcckck ON clnc.cpdm = qcckck.cpdm AND clnc.ckdm = qcckck.ckdm" &
                    " Left join (SELECT inv_dbd.cpdm,inv_dbd.cckdm AS ckdm,sum(inv_dbd.sl) as qcdbcksl,sum(inv_dbd.je) as qcdbckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ? AND cpdm = ? GROUP BY inv_dbd.cpdm,inv_dbd.cckdm) qcdbck ON clnc.cpdm = qcdbck.cpdm AND clnc.ckdm = qcdbck.ckdm) asfchz GROUP BY cpdm,ckdm"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("cpxx").Rows(i).Item("cpdm"))
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePoBegin1
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("cpxx").Rows(i).Item("cpdm"))
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePoBegin1
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("cpxx").Rows(i).Item("cpdm"))
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePoBegin1
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateJsrq
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("cpxx").Rows(i).Item("cpdm"))
                    rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = datePoBegin1
                    rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("cpxx").Rows(i).Item("cpdm"))
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = datePoBegin1
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateJsrq
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("cpxx").Rows(i).Item("cpdm"))
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePoBegin1
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateJsrq
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("cpxx").Rows(i).Item("cpdm"))
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("clqcye") IsNot Nothing Then
                        rcDataset.Tables("clqcye").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "clqcye")
                    'If rcDataSet.Tables("cpxx").Rows(i).Item("cpdm") = "105200204" Then
                    '    dblQcsl = 0.0
                    'End If
                    For j = 0 To rcDataset.Tables("clqcye").Rows.Count - 1
                        '取平均单价
                        dblQcsl = rcDataset.Tables("clqcye").Rows(j).Item("qcsl") + rcDataset.Tables("clqcye").Rows(j).Item("qccgrksl") + rcDataset.Tables("clqcye").Rows(j).Item("qcscrksl") + rcDataset.Tables("clqcye").Rows(j).Item("qcdbrksl") - rcDataset.Tables("clqcye").Rows(j).Item("qcxscksl") - rcDataset.Tables("clqcye").Rows(j).Item("qcckcksl") - rcDataset.Tables("clqcye").Rows(j).Item("qcdbcksl")
                        dblQcje = rcDataset.Tables("clqcye").Rows(j).Item("qcje") + rcDataset.Tables("clqcye").Rows(j).Item("qccgrkje") + rcDataset.Tables("clqcye").Rows(j).Item("qcscrkje") + rcDataset.Tables("clqcye").Rows(j).Item("qcdbrkje") - rcDataset.Tables("clqcye").Rows(j).Item("qcxsckje") - rcDataset.Tables("clqcye").Rows(j).Item("qcckckje") - rcDataset.Tables("clqcye").Rows(j).Item("qcdbckje")
                        '计算产品调拨成本单价=上月的账面金额+本月入库金额/上月账面数量+本月入库数量
                        If dblQcsl <> 0 Then
                            dblQcdj = dblQcje / dblQcsl
                        Else
                            dblQcdj = 0.0
                        End If
                        'MsgBox(Str(dblQcdj) + "/" + rcDataSet.Tables("cpxx").Rows(i).Item("cpdm") + "/" + rcDataSet.Tables("clqcye").Rows(j).Item("ckdm"))

                        ''按平均单价进行更新当月产品出库单的调拨金额=成本单价*退货数量
                        rcOleDbCommand.CommandText = "UPDATE oe_xsd SET oe_xsd.cbje = oe_xsd.sl * ?,oe_xsd.cbdj = ? WHERE oe_xsd.cpdm = ? AND ckdm = ? AND SUBSTR(oe_xsd.djh,5,6) >= ?  AND SUBSTR(oe_xsd.djh,5,6) <= ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                        rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("cpxx").Rows(i).Item("cpdm")
                        rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("clqcye").Rows(j).Item("ckdm")
                        rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
                        rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
                        rcOleDbCommand.ExecuteNonQuery()
                        If Me.CheckBox1.Checked Then
                            ''按标准成本进行更新当月的退货成本或退货销售
                            rcOleDbCommand.CommandText = "UPDATE oe_xsd SET oe_xsd.cbje = oe_xsd.sl * (SELECT bzcb FROM rc_cpxx WHERE rc_cpxx.cpdm = oe_xsd.cpdm),oe_xsd.cbdj = (SELECT bzcb FROM rc_cpxx WHERE rc_cpxx.cpdm = oe_xsd.cpdm) WHERE oe_xsd.cpdm = ? AND ckdm = ? AND SUBSTR(oe_xsd.djh,5,6) >= ?  AND SUBSTR(oe_xsd.djh,5,6) <= ? AND oe_xsd.cbdj = 0.0"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("cpxx").Rows(i).Item("cpdm")
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("clqcye").Rows(j).Item("ckdm")
                            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
                            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                        ' ''按平均单价进行更新当月产品出库单的调拨金额=成本单价*退货数量
                        'rcOleDbCommand.CommandText = "UPDATE inv_ckd SET inv_ckd.je = inv_ckd.sl * ?,inv_ckd.dj = ? WHERE inv_ckd.cpdm = ? AND ckdm = ? AND SUBSTR(inv_ckd.djh,5,6) >= ? AND SUBSTR(inv_ckd.djh,5,6) <= ?"
                        'rcOleDbCommand.Parameters.Clear()
                        'rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                        'rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                        'rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("cpxx").Rows(i).Item("cpdm")
                        'rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("clqcye").Rows(j).Item("ckdm")
                        'rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
                        'rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
                        'rcOleDbCommand.ExecuteNonQuery()
                    Next
                    If Me.CheckBox2.Checked Then
                        '退货无销售成本的业务，按最新入库单价计算销售成本
                        rcOleDbCommand.CommandText = "SELECT djh,xh FROM oe_xsd WHERE cbje = 0 AND sl < 0 AND oe_xsd.xsrq <= ? AND oe_xsd.xsrq >= ? AND oe_xsd.cpdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateJsrq
                        rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("oe_xsd") IsNot Nothing Then
                            rcDataset.Tables("oe_xsd").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "oe_xsd")
                        For j = 0 To rcDataset.Tables("oe_xsd").Rows.Count - 1
                            rcOleDbCommand.CommandText = "SELECT COALESCE(dj,0.0) AS dj FROM ((SELECT rkrq,dj FROM po_rkd WHERE dj <> 0 AND sl > 0 AND po_rkd.cpdm = ?) UNION (SELECT rkrq,dj FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND dj <> 0 AND sl >0 AND inv_rkd.cpdm = ?)) rkd ORDER BY rkd.rkrq DESC"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("cpxx").Rows(i).Item("cpdm"))
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("cpxx").Rows(i).Item("cpdm"))
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("rkd") IsNot Nothing Then
                                rcDataset.Tables("rkd").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "rkd")
                            If rcDataset.Tables("rkd").Rows.Count > 0 Then
                                rcOleDbCommand.CommandText = "UPDATE oe_xsd SET oe_xsd.dj =  ?,oe_xsd.cbje = oe_xsd.sl * ? WHERE oe_xsd.xh = ? AND oe_xsd.djh = ?"
                                rcOleDbCommand.Parameters.Clear()
                                rcOleDbCommand.Parameters.Add("@cbje", OleDbType.Numeric, 18).Value = rcDataset.Tables("rkd").Rows(0).Item("dj")
                                rcOleDbCommand.Parameters.Add("@cbje", OleDbType.Numeric, 18).Value = rcDataset.Tables("rkd").Rows(0).Item("dj")
                                rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = rcDataset.Tables("oe_xsd").Rows(j).Item("xh")
                                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataset.Tables("oe_xsd").Rows(j).Item("djh")
                                rcOleDbCommand.ExecuteNonQuery()
                            End If
                        Next
                    End If
                    '调整尾差，计算库存数量，库存金额
                    rcOleDbCommand.CommandText = "SELECT cpdm,ckdm,COALESCE(sum(qcsl),0.0) as qcsl,COALESCE(sum(qcje),0.0) as qcje,COALESCE(sum(qccgrksl),0.0) as qccgrksl,COALESCE(sum(qccgrkje),0.0) as qccgrkje,COALESCE(sum(qcscrksl),0.0) as qcscrksl,COALESCE(sum(qcscrkje),0.0) as qcscrkje,COALESCE(sum(qcdbrksl),0.0) as qcdbrksl,COALESCE(sum(qcdbrkje),0.0) as qcdbrkje,COALESCE(sum(qcxscksl),0.0) as qcxscksl,COALESCE(sum(qcxsckje),0.0) as qcxsckje,COALESCE(sum(qcckcksl),0.0) as qcckcksl,COALESCE(sum(qcckckje),0.0) as qcckckje,COALESCE(sum(qcdbcksl),0.0) as qcdbcksl,COALESCE(sum(qcdbckje),0.0) as qcdbckje FROM (SELECT clnc.cpdm,clnc.ckdm,clnc.qcsl,clnc.qcje,qccgrk.qccgrksl,qccgrk.qccgrkje,qcscrk.qcscrksl,qcscrk.qcscrkje,qcdbrk.qcdbrksl,qcdbrk.qcdbrkje,qcxsck.qcxscksl,qcxsck.qcxsckje,qcckck.qcckcksl,qcckck.qcckckje,qcdbck.qcdbcksl,qcdbck.qcdbckje FROM" &
                    " (SELECT inv_cpyeb.cpdm,inv_cpyeb.ckdm,sum(qcsl) as qcsl,sum(qcje) as qcje FROM inv_cpyeb WHERE kjnd = ? AND cpdm = ? GROUP by inv_cpyeb.cpdm,inv_cpyeb.ckdm) clnc" &
                    " Left join (SELECT po_rkd.cpdm,po_rkd.ckdm,sum(po_rkd.sl) as qccgrksl,sum(po_rkd.je) as qccgrkje FROM po_rkd WHERE po_rkd.bdelete = 0 AND TRUNC(po_rkd.rkrq,'mi') >= ? and TRUNC(po_rkd.rkrq,'mi') >= ? and TRUNC(po_rkd.rkrq,'mi') <= ? AND cpdm = ? GROUP BY po_rkd.cpdm,po_rkd.ckdm) qccgrk ON clnc.cpdm = qccgrk.cpdm AND clnc.ckdm = qccgrk.ckdm" &
                    " Left join (SELECT inv_rkd.cpdm,inv_rkd.ckdm,sum(inv_rkd.sl) as qcscrksl,sum(inv_rkd.je) as qcscrkje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') <= ? AND cpdm = ? GROUP BY inv_rkd.cpdm,inv_rkd.ckdm) qcscrk ON clnc.cpdm = qcscrk.cpdm AND clnc.ckdm = qcscrk.ckdm" &
                    " Left join (SELECT inv_dbd.cpdm,inv_dbd.rckdm AS ckdm,sum(inv_dbd.sl) as qcdbrksl,sum(inv_dbd.je) as qcdbrkje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ? AND cpdm = ? GROUP BY inv_dbd.cpdm,inv_dbd.rckdm) qcdbrk ON clnc.cpdm = qcdbrk.cpdm AND clnc.ckdm = qcdbrk.ckdm" &
                    " Left join (SELECT oe_xsd.cpdm,oe_xsd.ckdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') <= ? AND cpdm = ? GROUP BY oe_xsd.cpdm,oe_xsd.ckdm) qcxsck ON clnc.cpdm = qcxsck.cpdm AND clnc.ckdm = qcxsck.ckdm" &
                    " Left join (SELECT inv_ckd.cpdm,inv_ckd.ckdm,sum(inv_ckd.sl) as qcckcksl,sum(inv_ckd.je) as qcckckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') <= ? AND cpdm = ? GROUP BY inv_ckd.cpdm,inv_ckd.ckdm) qcckck ON clnc.cpdm = qcckck.cpdm AND clnc.ckdm = qcckck.ckdm" &
                    " Left join (SELECT inv_dbd.cpdm,inv_dbd.cckdm AS ckdm,sum(inv_dbd.sl) as qcdbcksl,sum(inv_dbd.je) as qcdbckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ? AND cpdm = ? GROUP BY inv_dbd.cpdm,inv_dbd.cckdm) qcdbck ON clnc.cpdm = qcdbck.cpdm AND clnc.ckdm = qcdbck.ckdm) asfchz GROUP BY cpdm,ckdm"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("cpxx").Rows(i).Item("cpdm"))
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePoBegin1
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("cpxx").Rows(i).Item("cpdm"))
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePoBegin1
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("cpxx").Rows(i).Item("cpdm"))
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePoBegin1
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateJsrq
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("cpxx").Rows(i).Item("cpdm"))
                    rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = datePoBegin1
                    rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateJsrq
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("cpxx").Rows(i).Item("cpdm"))
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = datePoBegin1
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateJsrq
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("cpxx").Rows(i).Item("cpdm"))
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePoBegin1
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateJsrq
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("cpxx").Rows(i).Item("cpdm"))
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("clqcye") IsNot Nothing Then
                        rcDataset.Tables("clqcye").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "clqcye")
                    For j = 0 To rcDataset.Tables("clqcye").Rows.Count - 1
                        '计算库存数量，库存金额
                        dblQcsl = rcDataset.Tables("clqcye").Rows(j).Item("qcsl") + rcDataset.Tables("clqcye").Rows(j).Item("qccgrksl") + rcDataset.Tables("clqcye").Rows(j).Item("qcscrksl") + rcDataset.Tables("clqcye").Rows(j).Item("qcdbrksl") - rcDataset.Tables("clqcye").Rows(j).Item("qcxscksl") - rcDataset.Tables("clqcye").Rows(j).Item("qcckcksl") - rcDataset.Tables("clqcye").Rows(j).Item("qcdbcksl")
                        dblQcje = rcDataset.Tables("clqcye").Rows(j).Item("qcje") + rcDataset.Tables("clqcye").Rows(j).Item("qccgrkje") + rcDataset.Tables("clqcye").Rows(j).Item("qcscrkje") + rcDataset.Tables("clqcye").Rows(j).Item("qcdbrkje") - rcDataset.Tables("clqcye").Rows(j).Item("qcxsckje") - rcDataset.Tables("clqcye").Rows(j).Item("qcckckje") - rcDataset.Tables("clqcye").Rows(j).Item("qcdbckje")
                        '需要调整
                        If dblQcsl = 0 And dblQcje <> 0 Then
                            '调整到oe_xsd
                            rcOleDbCommand.CommandText = "SELECT djh,xh FROM oe_xsd WHERE oe_xsd.xsrq >= ? AND oe_xsd.xsrq <= ? AND oe_xsd.cpdm = ? AND oe_xsd.ckdm = ? ORDER BY cbje DESC"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq
                            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateJsrq
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("cpxx").Rows(i).Item("cpdm")
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("clqcye").Rows(j).Item("ckdm")
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("oe_xsd") IsNot Nothing Then
                                rcDataset.Tables("oe_xsd").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "oe_xsd")
                            If rcDataset.Tables("oe_xsd").Rows.Count > 0 Then
                                rcOleDbCommand.CommandText = "UPDATE oe_xsd SET oe_xsd.cbje = oe_xsd.cbje + ? WHERE oe_xsd.xh = ? AND oe_xsd.djh = ?"
                                rcOleDbCommand.Parameters.Clear()
                                rcOleDbCommand.Parameters.Add("@qcje", OleDbType.Numeric, 18).Value = dblQcje
                                rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = rcDataset.Tables("oe_xsd").Rows(0).Item("xh")
                                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataset.Tables("oe_xsd").Rows(0).Item("djh")
                                rcOleDbCommand.ExecuteNonQuery()
                            Else
                                '调整到inv_dbd
                                rcOleDbCommand.CommandText = "SELECT djh,xh FROM inv_dbd WHERE inv_dbd.dbrq >= ? AND inv_dbd.dbrq <= ? AND inv_dbd.cpdm = ? AND inv_dbd.cckdm = ? ORDER BY je DESC"
                                rcOleDbCommand.Parameters.Clear()
                                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateKsrq
                                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateJsrq
                                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("cpxx").Rows(i).Item("cpdm")
                                rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("clqcye").Rows(j).Item("ckdm")
                                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                If rcDataset.Tables("inv_dbd") IsNot Nothing Then
                                    rcDataset.Tables("inv_dbd").Clear()
                                End If
                                rcOleDbDataAdpt.Fill(rcDataset, "inv_dbd")
                                If rcDataset.Tables("inv_dbd").Rows.Count > 0 Then
                                    rcOleDbCommand.CommandText = "UPDATE inv_dbd SET inv_dbd.je = inv_dbd.je + ? WHERE inv_dbd.xh = ? AND inv_dbd.djh = ?"
                                    rcOleDbCommand.Parameters.Clear()
                                    rcOleDbCommand.Parameters.Add("@qcje", OleDbType.Numeric, 18).Value = dblQcje
                                    rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = rcDataset.Tables("inv_dbd").Rows(0).Item("xh")
                                    rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataset.Tables("inv_dbd").Rows(0).Item("djh")
                                    rcOleDbCommand.ExecuteNonQuery()
                                Else
                                    '提示未调整
                                    '’MsgBox("尾差未调整,产品编码是(" & rcDataSet.Tables("cpxx").Rows(i).Item("cpdm") & ")", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
                                End If

                            End If

                        End If
                    Next
                    '材料出库成本尾差的调整,先进先出法不用进行尾差调整。
                Next
                rcOleDbTrans.Commit()
                rcOleDbCommand.CommandType = CommandType.StoredProcedure
                rcOleDbCommand.CommandText = "USP3_REDO_CPYEHZ"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ParaStrYear", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                rcOleDbCommand.Parameters.Add("@dwrq", OleDbType.Date, 8).Value = g_Dwrq
                rcOleDbCommand.ExecuteNonQuery()
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
            MsgBox("成本结转完成。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Me.Close()
        End If
    End Sub
End Class