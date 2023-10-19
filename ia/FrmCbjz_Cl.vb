Imports System.Data.OleDb

Public Class FrmCbjz_Cl
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

#Region "初始化"

    Private Sub FrmCbjz_Cl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        NudMonthBegin.Value = Mid(rcDataset.Tables("rc_yj").Rows(0).Item("ny"), 5, 2)
        NudMonthEnd.Value = Mid(rcDataset.Tables("rc_yj").Rows(0).Item("ny"), 5, 2)
    End Sub

#End Region

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NudYear.KeyPress, NudMonthBegin.KeyPress, NudMonthEnd.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        '结转成本
        '结转退货单的成本
        '结转出库单的成本
        Dim datePoBegin1 As Date
        Dim dateKsrq As Date '成本结转开始日期
        Dim dateJsrq As Date '成本结转结束日期
        Dim i As Integer
        Dim j As Integer
        Dim dblQcsl As Double
        Dim dblQcje As Double
        Dim dblQcdj As Double
        datePoBegin1 = GetInvBegin(Me.NudYear.Value, 1)
        dateKsrq = getInvBegin(Me.NudYear.Value, Me.NudMonthBegin.Value)
        dateJsrq = getInvEnd(Me.NudYear.Value, Me.NudMonthEnd.Value)
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            'If Me.CheckBox3.Checked Then
            '生产入库成本按标准成本计算的物料
            rcOleDbCommand.CommandText = "UPDATE inv_rkd SET dj = (SELECT bzcb FROM rc_cpxx WHERE rc_cpxx.cpdm = inv_rkd.cpdm),je = sl *  (SELECT bzcb FROM rc_cpxx WHERE rc_cpxx.cpdm = inv_rkd.cpdm) WHERE EXISTS (SELECT 1 FROM rc_ckxx WHERE rc_ckxx.ckdm = inv_rkd.ckdm AND rc_ckxx.bscrkcb = 1) AND TRUNC(inv_rkd.rkrq,'mi') >= ? AND TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
            rcOleDbCommand.ExecuteNonQuery()
            'End If
            '取材料信息
            rcOleDbCommand.CommandText = "SELECT rc_cpxx.cpdm FROM rc_cpxx ORDER BY rc_cpxx.cpdm" ',rc_cpxx.jjfs
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("cpxx") IsNot Nothing Then
                rcDataSet.Tables("cpxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "cpxx")
            For i = 0 To rcDataSet.Tables("cpxx").Rows.Count - 1
                Me.ProgressBar1.Value = 100 / rcDataSet.Tables("cpxx").Rows.Count * (i + 1)
                Me.LblMsg.Text = "正在结转成本：" & rcDataSet.Tables("cpxx").Rows(i).Item("cpdm")
                Dim strJjfs As String = "加权平均法" ' rcDataSet.Tables("cpxx").Rows(i).Item("jjfs")
                Select Case strJjfs
                    Case "加权平均法"
                        '''''''''''''''''''''''''''''''
                        ''''''''''加权平均法'''''''''''
                        '''''''''''''''''''''''''''''''

                        '计算该产品该仓库的上月账面数量+本月入库数量、上月的账面金额+本月入库金额
                        '分仓库汇总,不含调拨单的入库数量与金额，用来计算调调拨单的出库成本
                        rcOleDbCommand.CommandText = "SELECT cpdm,ckdm,COALESCE(sum(qcsl),0.0) as qcsl,COALESCE(sum(qcje),0.0) as qcje,COALESCE(sum(qccgrksl),0.0) as qccgrksl,COALESCE(sum(qccgrkje),0.0) as qccgrkje,COALESCE(sum(qcscrksl),0.0) as qcscrksl,COALESCE(sum(qcscrkje),0.0) as qcscrkje,COALESCE(sum(qcdbrksl),0.0) as qcdbrksl,COALESCE(sum(qcdbrkje),0.0) as qcdbrkje,COALESCE(sum(qcxscksl),0.0) as qcxscksl,COALESCE(sum(qcxsckje),0.0) as qcxsckje,COALESCE(sum(qcckcksl),0.0) as qcckcksl,COALESCE(sum(qcckckje),0.0) as qcckckje,COALESCE(sum(qcdbcksl),0.0) as qcdbcksl,COALESCE(sum(qcdbckje),0.0) as qcdbckje FROM (SELECT clnc.cpdm,clnc.ckdm,clnc.qcsl,clnc.qcje,qccgrk.qccgrksl,qccgrk.qccgrkje,qcscrk.qcscrksl,qcscrk.qcscrkje,qcdbrk.qcdbrksl,qcdbrk.qcdbrkje,qcxsck.qcxscksl,qcxsck.qcxsckje,qcckck.qcckcksl,qcckck.qcckckje,qcdbck.qcdbcksl,qcdbck.qcdbckje FROM" & _
                            " (SELECT inv_cpyeb.cpdm,inv_cpyeb.ckdm,sum(qcsl) as qcsl,sum(qcje) as qcje FROM inv_cpyeb WHERE kjnd = ? AND cpdm = ? GROUP by inv_cpyeb.cpdm,inv_cpyeb.ckdm) clnc" & _
                            " Left join (SELECT po_rkd.cpdm,po_rkd.ckdm,sum(po_rkd.sl) as qccgrksl,sum(po_rkd.je) as qccgrkje FROM po_rkd WHERE po_rkd.bdelete = 0 AND TRUNC(po_rkd.rkrq,'mi') >= ? AND TRUNC(po_rkd.rkrq,'mi') >= ? AND TRUNC(po_rkd.rkrq,'mi') <= ? AND cpdm = ? GROUP BY po_rkd.cpdm,po_rkd.ckdm) qccgrk ON clnc.cpdm = qccgrk.cpdm AND clnc.ckdm = qccgrk.ckdm" & _
                            " Left join (SELECT inv_rkd.cpdm,inv_rkd.ckdm,sum(inv_rkd.sl) as qcscrksl,sum(inv_rkd.je) as qcscrkje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') <= ? AND cpdm = ? GROUP BY inv_rkd.cpdm,inv_rkd.ckdm) qcscrk ON clnc.cpdm = qcscrk.cpdm AND clnc.ckdm = qcscrk.ckdm" & _
                            " Left join (SELECT inv_dbd.cpdm,inv_dbd.rckdm AS ckdm,sum(inv_dbd.sl) as qcdbrksl,sum(inv_dbd.je) as qcdbrkje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ? AND cpdm = ? GROUP BY inv_dbd.cpdm,inv_dbd.rckdm) qcdbrk ON clnc.cpdm = qcdbrk.cpdm AND clnc.ckdm = qcdbrk.ckdm" & _
                            " Left join (SELECT oe_xsd.cpdm,oe_xsd.ckdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') < ? AND cpdm = ? GROUP BY oe_xsd.cpdm,oe_xsd.ckdm) qcxsck ON clnc.cpdm = qcxsck.cpdm AND clnc.ckdm = qcxsck.ckdm" & _
                            " Left join (SELECT inv_ckd.cpdm,inv_ckd.ckdm,sum(inv_ckd.sl) as qcckcksl,sum(inv_ckd.je) as qcckckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') < ? AND cpdm = ? GROUP BY inv_ckd.cpdm,inv_ckd.ckdm) qcckck ON clnc.cpdm = qcckck.cpdm AND clnc.ckdm = qcckck.ckdm" & _
                            " Left join (SELECT inv_dbd.cpdm,inv_dbd.cckdm AS ckdm,sum(inv_dbd.sl) as qcdbcksl,sum(inv_dbd.je) as qcdbckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ? AND cpdm = ? GROUP BY inv_dbd.cpdm,inv_dbd.cckdm) qcdbck ON clnc.cpdm = qcdbck.cpdm AND clnc.ckdm = qcdbck.ckdm) asfchz GROUP BY cpdm,ckdm"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePoBegin1
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePoBegin1
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePoBegin1
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateKsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = datePoBegin1
                        rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = datePoBegin1
                        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateKsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePoBegin1
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateKsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataSet.Tables("clqcye") IsNot Nothing Then
                            rcDataSet.Tables("clqcye").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataSet, "clqcye")
                        '调拨单成本清零
                        rcOleDbCommand.CommandText = "UPDATE inv_dbd SET inv_dbd.je = 0.0,inv_dbd.dj = 0.0 WHERE inv_dbd.cpdm = ? AND TRUNC(inv_dbd.dbrq,'mi') <= ? AND TRUNC(inv_dbd.dbrq,'mi') >= ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("cpxx").Rows(i).Item("cpdm")
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateJsrq
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateKsrq
                        rcOleDbCommand.ExecuteNonQuery()
                        For j = 0 To rcDataSet.Tables("clqcye").Rows.Count - 1
                            '取平均单价
                            dblQcsl = rcDataSet.Tables("clqcye").Rows(j).Item("qcsl") + rcDataSet.Tables("clqcye").Rows(j).Item("qccgrksl") + rcDataSet.Tables("clqcye").Rows(j).Item("qcscrksl") + rcDataSet.Tables("clqcye").Rows(j).Item("qcdbrksl") - rcDataSet.Tables("clqcye").Rows(j).Item("qcxscksl") - rcDataSet.Tables("clqcye").Rows(j).Item("qcckcksl") - rcDataSet.Tables("clqcye").Rows(j).Item("qcdbcksl")
                            dblQcje = rcDataSet.Tables("clqcye").Rows(j).Item("qcje") + rcDataSet.Tables("clqcye").Rows(j).Item("qccgrkje") + rcDataSet.Tables("clqcye").Rows(j).Item("qcscrkje") + rcDataSet.Tables("clqcye").Rows(j).Item("qcdbrkje") - rcDataSet.Tables("clqcye").Rows(j).Item("qcxsckje") - rcDataSet.Tables("clqcye").Rows(j).Item("qcckckje") - rcDataSet.Tables("clqcye").Rows(j).Item("qcdbckje")
                            '计算产品调拨成本单价=上月的账面金额+本月入库金额/上月账面数量+本月入库数量
                            If dblQcsl <> 0 Then
                                dblQcdj = dblQcje / dblQcsl
                            Else
                                dblQcdj = 0.0
                            End If
                            'If rcDataSet.Tables("cpxx").Rows(i).Item("cpdm") = "211421440" Then
                            '    MsgBox(rcDataSet.Tables("clqcye").Rows(j).Item("ckdm") & dblQcsl & ",,," & dblQcje & dblQcdj)
                            'End If
                            ''按平均单价进行更新当月产品调拨单的调拨金额=成本单价*退货数量
                            rcOleDbCommand.CommandText = "UPDATE inv_dbd SET inv_dbd.je = inv_dbd.sl * ?,inv_dbd.dj = ? WHERE inv_dbd.cpdm = ? AND cckdm = ? AND TRUNC(inv_dbd.dbrq,'mi') <= ? AND TRUNC(inv_dbd.dbrq,'mi') >= ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                            rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("cpxx").Rows(i).Item("cpdm")
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("clqcye").Rows(j).Item("ckdm")
                            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateJsrq
                            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateKsrq
                            rcOleDbCommand.ExecuteNonQuery()
                        Next
                        If rcDataSet.Tables("clqcye").Rows.Count > 0 Then
                            dblQcsl = rcDataSet.Tables("clqcye").Compute("SUM(qcsl)", "") + rcDataSet.Tables("clqcye").Compute("SUM(qccgrksl)", "") + rcDataSet.Tables("clqcye").Compute("SUM(qcscrksl)", "") + rcDataSet.Tables("clqcye").Compute("SUM(qcdbrksl)", "") - rcDataSet.Tables("clqcye").Compute("SUM(qcxscksl)", "") - rcDataSet.Tables("clqcye").Compute("SUM(qcckcksl)", "") - rcDataSet.Tables("clqcye").Compute("SUM(qcdbcksl)", "")
                            dblQcje = rcDataSet.Tables("clqcye").Compute("SUM(qcje)", "") + rcDataSet.Tables("clqcye").Compute("SUM(qccgrkje)", "") + rcDataSet.Tables("clqcye").Compute("SUM(qcscrkje)", "") + rcDataSet.Tables("clqcye").Compute("SUM(qcdbrkje)", "") - rcDataSet.Tables("clqcye").Compute("SUM(qcxsckje)", "") - rcDataSet.Tables("clqcye").Compute("SUM(qcckckje)", "") - rcDataSet.Tables("clqcye").Compute("SUM(qcdbckje)", "")
                            If dblQcsl <> 0 Then
                                dblQcdj = dblQcje / dblQcsl
                            Else
                                dblQcdj = 0.0
                            End If
                            'If rcDataSet.Tables("cpxx").Rows(i).Item("cpdm") = "211421440" Then
                            '    MsgBox(dblQcsl & ",,,," & dblQcje & dblQcdj)
                            'End If
                            If Me.CheckBox2.Checked Then
                                ''对于未结转调拨成本按所有仓库的平均单价进行更新当月产品调拨单的调拨金额=成本单价*调拨数量
                                rcOleDbCommand.CommandText = "UPDATE inv_dbd SET inv_dbd.je = inv_dbd.sl * ?,inv_dbd.dj = ? WHERE inv_dbd.cpdm = ? AND inv_dbd.dj = 0.0 AND TRUNC(inv_dbd.dbrq,'mi') <= ? AND TRUNC(inv_dbd.dbrq,'mi') >= ?"
                                rcOleDbCommand.Parameters.Clear()
                                rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                                rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("cpxx").Rows(i).Item("cpdm")
                                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateJsrq
                                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateKsrq
                                rcOleDbCommand.ExecuteNonQuery()
                            End If
                        End If
                        '分仓库汇总,含调拨单的入库数量与金额，用来计算出库单的出库成本
                        rcOleDbCommand.CommandText = "SELECT cpdm,ckdm,COALESCE(sum(qcsl),0.0) as qcsl,COALESCE(sum(qcje),0.0) as qcje,COALESCE(sum(qccgrksl),0.0) as qccgrksl,COALESCE(sum(qccgrkje),0.0) as qccgrkje,COALESCE(sum(qcscrksl),0.0) as qcscrksl,COALESCE(sum(qcscrkje),0.0) as qcscrkje,COALESCE(sum(qcdbrksl),0.0) as qcdbrksl,COALESCE(sum(qcdbrkje),0.0) as qcdbrkje,COALESCE(sum(qcxscksl),0.0) as qcxscksl,COALESCE(sum(qcxsckje),0.0) as qcxsckje,COALESCE(sum(qcckcksl),0.0) as qcckcksl,COALESCE(sum(qcckckje),0.0) as qcckckje,COALESCE(sum(qcdbcksl),0.0) as qcdbcksl,COALESCE(sum(qcdbckje),0.0) as qcdbckje FROM (SELECT clnc.cpdm,clnc.ckdm,clnc.qcsl,clnc.qcje,qccgrk.qccgrksl,qccgrk.qccgrkje,qcscrk.qcscrksl,qcscrk.qcscrkje,qcdbrk.qcdbrksl,qcdbrk.qcdbrkje,qcxsck.qcxscksl,qcxsck.qcxsckje,qcckck.qcckcksl,qcckck.qcckckje,qcdbck.qcdbcksl,qcdbck.qcdbckje FROM" & _
                            " (SELECT inv_cpyeb.cpdm,inv_cpyeb.ckdm,sum(qcsl) as qcsl,sum(qcje) as qcje FROM inv_cpyeb WHERE kjnd = ? AND cpdm = ? GROUP by inv_cpyeb.cpdm,inv_cpyeb.ckdm) clnc" & _
                            " Left join (SELECT po_rkd.cpdm,po_rkd.ckdm,sum(po_rkd.sl) as qccgrksl,sum(po_rkd.je) as qccgrkje FROM po_rkd WHERE po_rkd.bdelete = 0 AND TRUNC(po_rkd.rkrq,'mi') >= ? and TRUNC(po_rkd.rkrq,'mi') >= ? and TRUNC(po_rkd.rkrq,'mi') <= ? AND cpdm = ? GROUP BY po_rkd.cpdm,po_rkd.ckdm) qccgrk ON clnc.cpdm = qccgrk.cpdm AND clnc.ckdm = qccgrk.ckdm" & _
                            " Left join (SELECT inv_rkd.cpdm,inv_rkd.ckdm,sum(inv_rkd.sl) as qcscrksl,sum(inv_rkd.je) as qcscrkje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') <= ? AND cpdm = ? GROUP BY inv_rkd.cpdm,inv_rkd.ckdm) qcscrk ON clnc.cpdm = qcscrk.cpdm AND clnc.ckdm = qcscrk.ckdm" & _
                            " Left join (SELECT inv_dbd.cpdm,inv_dbd.rckdm AS ckdm,sum(inv_dbd.sl) as qcdbrksl,sum(inv_dbd.je) as qcdbrkje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ? AND cpdm = ? GROUP BY inv_dbd.cpdm,inv_dbd.rckdm) qcdbrk ON clnc.cpdm = qcdbrk.cpdm AND clnc.ckdm = qcdbrk.ckdm" & _
                            " Left join (SELECT oe_xsd.cpdm,oe_xsd.ckdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') < ? AND cpdm = ? GROUP BY oe_xsd.cpdm,oe_xsd.ckdm) qcxsck ON clnc.cpdm = qcxsck.cpdm AND clnc.ckdm = qcxsck.ckdm" & _
                            " Left join (SELECT inv_ckd.cpdm,inv_ckd.ckdm,sum(inv_ckd.sl) as qcckcksl,sum(inv_ckd.je) as qcckckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') < ? AND cpdm = ? GROUP BY inv_ckd.cpdm,inv_ckd.ckdm) qcckck ON clnc.cpdm = qcckck.cpdm AND clnc.ckdm = qcckck.ckdm" & _
                            " Left join (SELECT inv_dbd.cpdm,inv_dbd.cckdm AS ckdm,sum(inv_dbd.sl) as qcdbcksl,sum(inv_dbd.je) as qcdbckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? AND TRUNC(inv_dbd.dbrq,'mi') <= ? AND TRUNC(inv_dbd.dbrq,'mi') >= ? AND cpdm = ? GROUP BY inv_dbd.cpdm,inv_dbd.cckdm) qcdbck ON clnc.cpdm = qcdbck.cpdm AND clnc.ckdm = qcdbck.ckdm) asfchz GROUP BY cpdm,ckdm"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePoBegin1
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePoBegin1
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePoBegin1
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateJsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = datePoBegin1
                        rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = datePoBegin1
                        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateKsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePoBegin1
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateJsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataSet.Tables("clqcye") IsNot Nothing Then
                            rcDataSet.Tables("clqcye").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataSet, "clqcye")
                        For j = 0 To rcDataSet.Tables("clqcye").Rows.Count - 1
                            '取平均单价
                            dblQcsl = rcDataSet.Tables("clqcye").Rows(j).Item("qcsl") + rcDataSet.Tables("clqcye").Rows(j).Item("qccgrksl") + rcDataSet.Tables("clqcye").Rows(j).Item("qcscrksl") + rcDataSet.Tables("clqcye").Rows(j).Item("qcdbrksl") - rcDataSet.Tables("clqcye").Rows(j).Item("qcxscksl") - rcDataSet.Tables("clqcye").Rows(j).Item("qcckcksl") - rcDataSet.Tables("clqcye").Rows(j).Item("qcdbcksl")
                            dblQcje = rcDataSet.Tables("clqcye").Rows(j).Item("qcje") + rcDataSet.Tables("clqcye").Rows(j).Item("qccgrkje") + rcDataSet.Tables("clqcye").Rows(j).Item("qcscrkje") + rcDataSet.Tables("clqcye").Rows(j).Item("qcdbrkje") - rcDataSet.Tables("clqcye").Rows(j).Item("qcxsckje") - rcDataSet.Tables("clqcye").Rows(j).Item("qcckckje") - rcDataSet.Tables("clqcye").Rows(j).Item("qcdbckje")
                            '计算产品调拨成本单价=上月的账面金额+本月入库金额/上月账面数量+本月入库数量
                            If dblQcsl <> 0 Then
                                dblQcdj = dblQcje / dblQcsl
                            Else
                                dblQcdj = 0.0
                            End If
                            'If rcDataSet.Tables("cpxx").Rows(i).Item("cpdm") = "211421440" Then
                            '    MsgBox(rcDataSet.Tables("clqcye").Rows(j).Item("ckdm") & dblQcsl & ",," & dblQcje & dblQcdj)
                            'End If
                            'MsgBox(Str(dblQcdj) + "/" + rcDataSet.Tables("cpxx").Rows(i).Item("cpdm") + "/" + rcDataSet.Tables("clqcye").Rows(j).Item("ckdm"))

                            ''按平均单价进行更新当月产品出库单的调拨金额=成本单价*退货数量
                            rcOleDbCommand.CommandText = "UPDATE oe_xsd SET oe_xsd.cbje = oe_xsd.sl * ?,oe_xsd.cbdj = ? WHERE oe_xsd.cpdm = ? AND ckdm = ? AND TRUNC(oe_xsd.xsrq,'mi') >= ?  AND TRUNC(oe_xsd.xsrq,'mi') <= ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                            rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("cpxx").Rows(i).Item("cpdm")
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("clqcye").Rows(j).Item("ckdm")
                            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateJsrq
                            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq
                            rcOleDbCommand.ExecuteNonQuery()
                            ''按标准成本进行更新当月的退货成本或退货的销售成本
                            rcOleDbCommand.CommandText = "UPDATE oe_xsd SET oe_xsd.cbje = oe_xsd.sl * (SELECT bzcb FROM rc_cpxx WHERE rc_cpxx.cpdm = oe_xsd.cpdm),oe_xsd.cbdj = (SELECT bzcb FROM rc_cpxx WHERE rc_cpxx.cpdm = oe_xsd.cpdm) WHERE oe_xsd.cpdm = ? AND ckdm = ? AND TRUNC(oe_xsd.xsrq,'mi') >= ?  AND TRUNC(oe_xsd.xsrq,'mi') <= ? AND oe_xsd.cbdj = 0.0"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("cpxx").Rows(i).Item("cpdm")
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("clqcye").Rows(j).Item("ckdm")
                            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateJsrq
                            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq
                            rcOleDbCommand.ExecuteNonQuery()
                            ''按平均单价进行更新当月产品出库单的调拨金额=成本单价*退货数量
                            rcOleDbCommand.CommandText = "UPDATE inv_ckd SET inv_ckd.je = inv_ckd.sl * ?,inv_ckd.dj = ? WHERE inv_ckd.btz <> 1 AND inv_ckd.ckdm = ? AND inv_ckd.cpdm = ? AND TRUNC(inv_ckd.ckrq,'mi') <= ? AND TRUNC(inv_ckd.ckrq,'mi') >= ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                            rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("clqcye").Rows(j).Item("ckdm")
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("cpxx").Rows(i).Item("cpdm")
                            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateJsrq
                            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateKsrq
                            rcOleDbCommand.ExecuteNonQuery()
                        Next
                        '调整尾差，计算库存数量，库存金额
                        rcOleDbCommand.CommandText = "SELECT cpdm,ckdm,COALESCE(sum(qcsl),0.0) as qcsl,COALESCE(sum(qcje),0.0) as qcje,COALESCE(sum(qccgrksl),0.0) as qccgrksl,COALESCE(sum(qccgrkje),0.0) as qccgrkje,COALESCE(sum(qcscrksl),0.0) as qcscrksl,COALESCE(sum(qcscrkje),0.0) as qcscrkje,COALESCE(sum(qcdbrksl),0.0) as qcdbrksl,COALESCE(sum(qcdbrkje),0.0) as qcdbrkje,COALESCE(sum(qcxscksl),0.0) as qcxscksl,COALESCE(sum(qcxsckje),0.0) as qcxsckje,COALESCE(sum(qcckcksl),0.0) as qcckcksl,COALESCE(sum(qcckckje),0.0) as qcckckje,COALESCE(sum(qcdbcksl),0.0) as qcdbcksl,COALESCE(sum(qcdbckje),0.0) as qcdbckje FROM (SELECT clnc.cpdm,clnc.ckdm,clnc.qcsl,clnc.qcje,qccgrk.qccgrksl,qccgrk.qccgrkje,qcscrk.qcscrksl,qcscrk.qcscrkje,qcdbrk.qcdbrksl,qcdbrk.qcdbrkje,qcxsck.qcxscksl,qcxsck.qcxsckje,qcckck.qcckcksl,qcckck.qcckckje,qcdbck.qcdbcksl,qcdbck.qcdbckje FROM" & _
                            " (SELECT inv_cpyeb.cpdm,inv_cpyeb.ckdm,sum(qcsl) as qcsl,sum(qcje) as qcje FROM inv_cpyeb WHERE kjnd = ? AND cpdm = ? GROUP by inv_cpyeb.cpdm,inv_cpyeb.ckdm) clnc" & _
                            " Left join (SELECT po_rkd.cpdm,po_rkd.ckdm,sum(po_rkd.sl) as qccgrksl,sum(po_rkd.je) as qccgrkje FROM po_rkd WHERE po_rkd.bdelete = 0 AND TRUNC(po_rkd.rkrq,'mi') >= ? and TRUNC(po_rkd.rkrq,'mi') >= ? and TRUNC(po_rkd.rkrq,'mi') <= ? AND cpdm = ? GROUP BY po_rkd.cpdm,po_rkd.ckdm) qccgrk ON clnc.cpdm = qccgrk.cpdm AND clnc.ckdm = qccgrk.ckdm" & _
                            " Left join (SELECT inv_rkd.cpdm,inv_rkd.ckdm,sum(inv_rkd.sl) as qcscrksl,sum(inv_rkd.je) as qcscrkje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') <= ? AND cpdm = ? GROUP BY inv_rkd.cpdm,inv_rkd.ckdm) qcscrk ON clnc.cpdm = qcscrk.cpdm AND clnc.ckdm = qcscrk.ckdm" & _
                            " Left join (SELECT inv_dbd.cpdm,inv_dbd.rckdm AS ckdm,sum(inv_dbd.sl) as qcdbrksl,sum(inv_dbd.je) as qcdbrkje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ? AND cpdm = ? GROUP BY inv_dbd.cpdm,inv_dbd.rckdm) qcdbrk ON clnc.cpdm = qcdbrk.cpdm AND clnc.ckdm = qcdbrk.ckdm" & _
                            " Left join (SELECT oe_xsd.cpdm,oe_xsd.ckdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') <= ? AND cpdm = ? GROUP BY oe_xsd.cpdm,oe_xsd.ckdm) qcxsck ON clnc.cpdm = qcxsck.cpdm AND clnc.ckdm = qcxsck.ckdm" & _
                            " Left join (SELECT inv_ckd.cpdm,inv_ckd.ckdm,sum(inv_ckd.sl) as qcckcksl,sum(inv_ckd.je) as qcckckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') <= ? AND cpdm = ? GROUP BY inv_ckd.cpdm,inv_ckd.ckdm) qcckck ON clnc.cpdm = qcckck.cpdm AND clnc.ckdm = qcckck.ckdm" & _
                            " Left join (SELECT inv_dbd.cpdm,inv_dbd.cckdm AS ckdm,sum(inv_dbd.sl) as qcdbcksl,sum(inv_dbd.je) as qcdbckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ? AND cpdm = ? GROUP BY inv_dbd.cpdm,inv_dbd.cckdm) qcdbck ON clnc.cpdm = qcdbck.cpdm AND clnc.ckdm = qcdbck.ckdm) asfchz GROUP BY cpdm,ckdm"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePoBegin1
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePoBegin1
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePoBegin1
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateJsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = datePoBegin1
                        rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateJsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = datePoBegin1
                        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateJsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePoBegin1
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateJsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataSet.Tables("clqcye") IsNot Nothing Then
                            rcDataSet.Tables("clqcye").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataSet, "clqcye")
                        For j = 0 To rcDataSet.Tables("clqcye").Rows.Count - 1
                            '计算库存数量，库存金额
                            dblQcsl = rcDataSet.Tables("clqcye").Rows(j).Item("qcsl") + rcDataSet.Tables("clqcye").Rows(j).Item("qccgrksl") + rcDataSet.Tables("clqcye").Rows(j).Item("qcscrksl") + rcDataSet.Tables("clqcye").Rows(j).Item("qcdbrksl") - rcDataSet.Tables("clqcye").Rows(j).Item("qcxscksl") - rcDataSet.Tables("clqcye").Rows(j).Item("qcckcksl") - rcDataSet.Tables("clqcye").Rows(j).Item("qcdbcksl")
                            dblQcje = rcDataSet.Tables("clqcye").Rows(j).Item("qcje") + rcDataSet.Tables("clqcye").Rows(j).Item("qccgrkje") + rcDataSet.Tables("clqcye").Rows(j).Item("qcscrkje") + rcDataSet.Tables("clqcye").Rows(j).Item("qcdbrkje") - rcDataSet.Tables("clqcye").Rows(j).Item("qcxsckje") - rcDataSet.Tables("clqcye").Rows(j).Item("qcckckje") - rcDataSet.Tables("clqcye").Rows(j).Item("qcdbckje")
                            'If rcDataSet.Tables("cpxx").Rows(i).Item("cpdm") = "211421440" Then
                            '    MsgBox(rcDataSet.Tables("clqcye").Rows(j).Item("ckdm") & dblQcsl & "," & dblQcje)
                            'End If
                            '需要调整
                            If dblQcsl = 0 And dblQcje <> 0 Then
                                '调整到oe_xsd
                                rcOleDbCommand.CommandText = "SELECT djh,xh FROM oe_xsd WHERE oe_xsd.xsrq >= ? AND oe_xsd.xsrq <= ? AND oe_xsd.cpdm = ? AND oe_xsd.ckdm = ? ORDER BY cbje DESC"
                                rcOleDbCommand.Parameters.Clear()
                                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq
                                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateJsrq
                                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataSet.Tables("cpxx").Rows(i).Item("cpdm")
                                rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("clqcye").Rows(j).Item("ckdm")
                                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                If rcDataSet.Tables("oe_xsd") IsNot Nothing Then
                                    rcDataSet.Tables("oe_xsd").Clear()
                                End If
                                rcOleDbDataAdpt.Fill(rcDataSet, "oe_xsd")
                                If rcDataSet.Tables("oe_xsd").Rows.Count > 0 Then
                                    rcOleDbCommand.CommandText = "UPDATE oe_xsd SET oe_xsd.cbje = oe_xsd.cbje + ? WHERE oe_xsd.xh = ? AND oe_xsd.djh = ?"
                                    rcOleDbCommand.Parameters.Clear()
                                    rcOleDbCommand.Parameters.Add("@qcje", OleDbType.Numeric, 18).Value = dblQcje
                                    rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = rcDataSet.Tables("oe_xsd").Rows(0).Item("xh")
                                    rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataSet.Tables("oe_xsd").Rows(0).Item("djh")
                                    rcOleDbCommand.ExecuteNonQuery()
                                Else
                                    '调整到inv_ckd
                                    rcOleDbCommand.CommandText = "SELECT djh,xh FROM inv_ckd WHERE inv_ckd.ckrq >= ? AND inv_ckd.ckrq <= ? AND inv_ckd.cpdm = ? AND inv_ckd.ckdm = ? ORDER BY je DESC"
                                    rcOleDbCommand.Parameters.Clear()
                                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateKsrq
                                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateJsrq
                                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataSet.Tables("cpxx").Rows(i).Item("cpdm")
                                    rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("clqcye").Rows(j).Item("ckdm")
                                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                    If rcDataSet.Tables("inv_ckd") IsNot Nothing Then
                                        rcDataSet.Tables("inv_ckd").Clear()
                                    End If
                                    rcOleDbDataAdpt.Fill(rcDataSet, "inv_ckd")
                                    If rcDataSet.Tables("inv_ckd").Rows.Count > 0 Then
                                        rcOleDbCommand.CommandText = "UPDATE inv_ckd SET inv_ckd.je = inv_ckd.je + ? WHERE inv_ckd.xh = ? AND inv_ckd.djh = ?"
                                        rcOleDbCommand.Parameters.Clear()
                                        rcOleDbCommand.Parameters.Add("@qcje", OleDbType.Numeric, 18).Value = dblQcje
                                        rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = rcDataSet.Tables("inv_ckd").Rows(0).Item("xh")
                                        rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataSet.Tables("inv_ckd").Rows(0).Item("djh")
                                        rcOleDbCommand.ExecuteNonQuery()
                                    Else
                                        '调整到inv_dbd
                                        rcOleDbCommand.CommandText = "SELECT djh,xh FROM inv_dbd WHERE inv_dbd.dbrq >= ? AND inv_dbd.dbrq <= ? AND inv_dbd.cpdm = ? AND inv_dbd.cckdm = ? ORDER BY je DESC"
                                        rcOleDbCommand.Parameters.Clear()
                                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateKsrq
                                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateJsrq
                                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataSet.Tables("cpxx").Rows(i).Item("cpdm")
                                        rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("clqcye").Rows(j).Item("ckdm")
                                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                        If rcDataSet.Tables("inv_dbd") IsNot Nothing Then
                                            rcDataSet.Tables("inv_dbd").Clear()
                                        End If
                                        rcOleDbDataAdpt.Fill(rcDataSet, "inv_dbd")
                                        If rcDataSet.Tables("inv_dbd").Rows.Count > 0 Then
                                            rcOleDbCommand.CommandText = "UPDATE inv_dbd SET inv_dbd.je = inv_dbd.je + ? WHERE inv_dbd.xh = ? AND inv_dbd.djh = ?"
                                            rcOleDbCommand.Parameters.Clear()
                                            rcOleDbCommand.Parameters.Add("@qcje", OleDbType.Numeric, 18).Value = dblQcje
                                            rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = rcDataSet.Tables("inv_dbd").Rows(0).Item("xh")
                                            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataSet.Tables("inv_dbd").Rows(0).Item("djh")
                                            rcOleDbCommand.ExecuteNonQuery()
                                        Else
                                            '提示未调整
                                            'MsgBox("尾差未调整,产品编码是(" & rcDataSet.Tables("cpxx").Rows(i).Item("cpdm") & ")", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
                                        End If

                                    End If

                                End If
                            End If
                        Next

                End Select
                '材料出库成本尾差的调整,先进先出法不用进行尾差调整。


            Next
            rcOleDbTrans.Commit()
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
        Me.LblMsg.Text = "成本结转完成。"
        Me.Close()
    End Sub
End Class