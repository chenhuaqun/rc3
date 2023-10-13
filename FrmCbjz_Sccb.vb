Imports System.Data.OleDb

Public Class FrmCbjz_Sccb
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '
    Dim bCostRegion As Boolean = False

#Region "初始化"

    Private Sub FrmCbjz_Sccb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        '是否按成本域计算成本
        bCostRegion = GetParaValue("是否按成本域计算成本", False)
        Me.TxtBiLi.Text = 0.0
    End Sub

#End Region

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NudYear.KeyPress, NudMonth.KeyPress, TxtBiLi.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim datePoBegin1 As Date
        Dim dateKsrq As Date '成本结转开始日期
        Dim dateJsrq As Date '成本结转结束日期
        datePoBegin1 = getInvBegin(Me.NudYear.Value, 1)
        dateKsrq = getInvBegin(Me.NudYear.Value, Me.NudMonth.Value)
        dateJsrq = getInvEnd(Me.NudYear.Value, Me.NudMonth.Value)
        Dim i As Integer
        Dim j As Integer
        Dim dblQcsl As Double
        Dim dblQcje As Double
        '结转成本
        '1）计算在产材料的成本
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            If Me.CheckBox1.Checked Then
                '更新物料清单中单价为0
                rcOleDbCommand.CommandText = "UPDATE pm_bom SET dj = 0,je = 0"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '更新物料清单的最新采购单价与产品的标准成本
                rcOleDbCommand.CommandText = "UPDATE pm_bom SET dj = (SELECT SUM(je)/SUM(sl) AS dj FROM po_rkd po_rkdc WHERE po_rkdc.sl > 0 AND po_rkdc.je > 0 AND po_rkdc.rkrq >= ? AND po_rkdc.rkrq <= ? AND pm_bom.childcpdm = po_rkdc.cpdm AND EXISTS (SELECT 1 FROM (SELECT MAX(rkrq) AS rkrq,cpdm FROM po_rkd po_rkda WHERE po_rkda.sl > 0 AND po_rkda.je > 0 AND po_rkda.rkrq >= ? AND po_rkda.rkrq <= ? GROUP BY po_rkda.cpdm) po_rkdb WHERE po_rkdc.cpdm = po_rkdb.cpdm AND po_rkdc.rkrq = po_rkdb.rkrq)) WHERE EXISTS (SELECT 1 FROM po_rkd po_rkdd WHERE  po_rkdd.sl > 0 AND po_rkdd.je > 0 AND po_rkdd.rkrq >= ? AND po_rkdd.rkrq <= ? AND po_rkdd.cpdm = pm_bom.childcpdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("rkrq", OleDbType.Date, 8).Value = dateKsrq
                rcOleDbCommand.Parameters.Add("rkrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbCommand.Parameters.Add("rkrq", OleDbType.Date, 8).Value = dateKsrq
                rcOleDbCommand.Parameters.Add("rkrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbCommand.Parameters.Add("rkrq", OleDbType.Date, 8).Value = dateKsrq
                rcOleDbCommand.Parameters.Add("rkrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "UPDATE pm_bom SET dj = (SELECT SUM(je)/SUM(sl) AS dj FROM po_rkd po_rkdc WHERE po_rkdc.sl > 0 AND po_rkdc.je > 0 AND pm_bom.childcpdm = po_rkdc.cpdm AND EXISTS (SELECT 1 FROM (SELECT MAX(rkrq) AS rkrq,cpdm FROM po_rkd po_rkda WHERE po_rkda.sl > 0 AND po_rkda.je > 0 GROUP BY po_rkda.cpdm) po_rkdb WHERE po_rkdc.cpdm = po_rkdb.cpdm AND po_rkdc.rkrq = po_rkdb.rkrq)) WHERE  EXISTS (SELECT 1 FROM po_rkd po_rkdd WHERE  po_rkdd.sl > 0 AND po_rkdd.je > 0 AND po_rkdd.cpdm = pm_bom.childcpdm) AND dj = 0 OR dj IS NULL"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '按标准成本替换
                rcOleDbCommand.CommandText = "UPDATE pm_bom SET dj = (SELECT bzcb FROM rc_cpxx WHERE rc_cpxx.cpdm = pm_bom.childcpdm) WHERE dj = 0 OR dj IS NULL"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "UPDATE pm_bom SET je = ROUND(sl * dj,4)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "UPDATE rc_cpxx SET clcb = (SELECT COALESCE(SUM(je),0.0) FROM pm_bom pm_boma WHERE pm_boma.parentcpdm = rc_cpxx.cpdm) WHERE EXISTS (SELECT 1 FROM pm_bom pm_bomb WHERE pm_bomb.parentcpdm = rc_cpxx.cpdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "UPDATE rc_cpxx SET bzcb = ((SELECT COALESCE(SUM(je),0.0) FROM pm_bom pm_boma WHERE pm_boma.parentcpdm = rc_cpxx.cpdm) + rgcb + glcb + nycb + zjcb) / chengpinlv * 100   WHERE EXISTS (SELECT 1 FROM pm_bom pm_bomb WHERE pm_bomb.parentcpdm = rc_cpxx.cpdm) AND chengpinlv <> 0"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '删除当月的物料清单
                rcOleDbCommand.CommandText = "DELETE FROM pm_bomdata WHERE cperiod = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                '添加当月物料清单
                rcOleDbCommand.CommandText = "INSERT INTO pm_bomdata SELECT ? AS cperiod,pm_bom.parentcpdm,pm_bom.childcpdm,pm_bom.sl,pm_bom.dj,pm_bom.je,pm_bom.bommemo FROM pm_bom"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
            End If

            '更新期末在产材料单价
            rcOleDbCommand.CommandText = "UPDATE pm_zccl SET cldj = (SELECT CASE WHEN beishu <> 0 THEN bzcb/beishu ELSE bzcb END FROM rc_cpxx WHERE rc_cpxx.cpdm = pm_zccl.cpdm) WHERE EXISTS (SELECT 1 FROM rc_cpxx WHERE rc_cpxx.cpdm = pm_zccl.cpdm) AND cperiod = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            '更新期末在产材料金额
            rcOleDbCommand.CommandText = "UPDATE pm_zccl SET zcclje = cldj * zcclsl WHERE EXISTS (SELECT 1 FROM rc_cpxx WHERE rc_cpxx.cpdm = pm_zccl.cpdm) AND cperiod = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            '更新ZCBJE表
            rcOleDbCommand.CommandText = "UPDATE pm_zcbje SET qmzcclje = (SELECT COALESCE(SUM(zcclje),0.0) FROM pm_zccl WHERE pm_zccl.cperiod = ? AND pm_zccl.bmdm = pm_zcbje.bmdm GROUP BY pm_zccl.bmdm) WHERE cperiod = ? AND EXISTS (SELECT 1 FROM pm_zccl pm_zcclc WHERE pm_zcclc.cperiod = ? AND pm_zcclc.bmdm = pm_zcbje.bmdm)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "UPDATE inv_rkd SET je = sl * (SELECT COALESCE(bzcb,0.0) FROM rc_cpxx WHERE rc_cpxx.cpdm = inv_rkd.cpdm) WHERE inv_rkd.bdelete = 0 And EXISTS (Select 1 FROM rc_lx WHERE SUBSTR(inv_rkd.djh,1,4) = rc_lx.pzlxdm And SUBSTR(inv_rkd.djh,5,4) = rc_lx.kjnd And lxgs = '产品入库单') AND EXISTS (SELECT 1 FROM rc_ckxx WHERE rc_ckxx.ckdm = inv_rkd.ckdm AND rc_ckxx.bscrkcb = 1) AND inv_rkd.rkrq <= ? AND inv_rkd.rkrq >= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
            rcOleDbCommand.ExecuteNonQuery()
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
        '2）计算在制品的约当产量、及产成品的约当产量
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '更新期末在产品的约当产量
            rcOleDbCommand.CommandText = "UPDATE pm_zcp SET ydsl = zcpsl * (SELECT ydcl FROM rc_gxxx WHERE rc_gxxx.gxdm = pm_zcp.gxdm) WHERE EXISTS (SELECT 1 FROM rc_gxxx WHERE rc_gxxx.gxdm = pm_zcp.gxdm) AND EXISTS (SELECT 1 FROM rc_cpxx WHERE rc_cpxx.cpdm = pm_zcp.cpdm) AND cperiod = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            '更新期末在产品的约当产量*标准成本
            rcOleDbCommand.CommandText = "UPDATE pm_zcp SET ydsl = ydsl * (SELECT CASE WHEN beishu <> 0 THEN bzcb/beishu ELSE bzcb END FROM rc_cpxx WHERE rc_cpxx.cpdm = pm_zcp.cpdm) WHERE EXISTS (SELECT 1 FROM rc_cpxx WHERE rc_cpxx.cpdm = pm_zcp.cpdm) AND cperiod = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            If Me.TxtBiLi.Text <> 0.0 Then
                '按留存比例留存
                rcOleDbCommand.CommandText = "UPDATE pm_zcp SET zcpje = (ydsl * " & Me.TxtBiLi.Text & "/ 100) WHERE EXISTS (SELECT 1 FROM rc_cpxx WHERE rc_cpxx.cpdm = pm_zcp.cpdm) AND cperiod = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
            End If
            '清空上次已保存的产品入库单数据
            rcOleDbCommand.CommandText = "UPDATE inv_rkd SET bzcb = 0.0,ydsl = 0.0,je = 0.0 WHERE inv_rkd.bdelete = 0 AND EXISTS (SELECT 1 FROM rc_lx WHERE SUBSTR(inv_rkd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(inv_rkd.djh,5,4) = rc_lx.kjnd AND lxgs = '产品入库单') AND NOT EXISTS (SELECT 1 FROM rc_ckxx WHERE rc_ckxx.ckdm = inv_rkd.ckdm AND rc_ckxx.bscrkcb = 1) AND inv_rkd.rkrq <= ? AND inv_rkd.rkrq >= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
            rcOleDbCommand.ExecuteNonQuery()
            If Me.CheckBox2.Checked Then
                '取红字产品入库数据
                rcOleDbCommand.CommandText = "SELECT inv_rkd.cpdm,inv_rkd.ckdm,SUM(sl) AS sl FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND EXISTS (SELECT 1 FROM rc_lx WHERE SUBSTR(inv_rkd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(inv_rkd.djh,5,4) = rc_lx.kjnd AND lxgs = '产品入库单') AND inv_rkd.rkrq <= ? AND inv_rkd.rkrq >= ? GROUP BY inv_rkd.cpdm,inv_rkd.ckdm HAVING SUM(SL) < 0"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("redinv_rkd") IsNot Nothing Then
                    rcDataSet.Tables("redinv_rkd").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "redinv_rkd")
                '按红字的入库的物料编码循环
                For i = 0 To rcDataSet.Tables("redinv_rkd").Rows.Count - 1
                    '取上月末库存
                    '调整尾差，计算库存数量，库存金额
                    rcOleDbCommand.CommandText = "SELECT cpdm,ckdm,COALESCE(sum(qcsl),0.0) as qcsl,COALESCE(sum(qcje),0.0) as qcje,COALESCE(sum(qccgrksl),0.0) as qccgrksl,COALESCE(sum(qccgrkje),0.0) as qccgrkje,COALESCE(sum(qcscrksl),0.0) as qcscrksl,COALESCE(sum(qcscrkje),0.0) as qcscrkje,COALESCE(sum(qcdbrksl),0.0) as qcdbrksl,COALESCE(sum(qcdbrkje),0.0) as qcdbrkje,COALESCE(sum(qcxscksl),0.0) as qcxscksl,COALESCE(sum(qcxsckje),0.0) as qcxsckje,COALESCE(sum(qcckcksl),0.0) as qcckcksl,COALESCE(sum(qcckckje),0.0) as qcckckje,COALESCE(sum(qcdbcksl),0.0) as qcdbcksl,COALESCE(sum(qcdbckje),0.0) as qcdbckje FROM (SELECT clnc.cpdm,clnc.ckdm,clnc.qcsl,clnc.qcje,qccgrk.qccgrksl,qccgrk.qccgrkje,qcscrk.qcscrksl,qcscrk.qcscrkje,qcdbrk.qcdbrksl,qcdbrk.qcdbrkje,qcxsck.qcxscksl,qcxsck.qcxsckje,qcckck.qcckcksl,qcckck.qcckckje,qcdbck.qcdbcksl,qcdbck.qcdbckje FROM" & _
                        " (SELECT inv_cpyeb.cpdm,inv_cpyeb.ckdm,sum(qcsl) as qcsl,sum(qcje) as qcje FROM inv_cpyeb WHERE kjnd = ? AND cpdm = ? AND ckdm = ? GROUP by inv_cpyeb.cpdm,inv_cpyeb.ckdm) clnc" & _
                        " Left join (SELECT po_rkd.cpdm,po_rkd.ckdm,sum(po_rkd.sl) as qccgrksl,sum(po_rkd.je) as qccgrkje FROM po_rkd WHERE po_rkd.bdelete = 0 AND TRUNC(po_rkd.rkrq,'mi') >= ? and TRUNC(po_rkd.rkrq,'mi') >= ? and TRUNC(po_rkd.rkrq,'mi') < ? AND cpdm = ? AND ckdm = ? GROUP BY po_rkd.cpdm,po_rkd.ckdm) qccgrk ON clnc.cpdm = qccgrk.cpdm AND clnc.ckdm = qccgrk.ckdm" & _
                        " Left join (SELECT inv_rkd.cpdm,inv_rkd.ckdm,sum(inv_rkd.sl) as qcscrksl,sum(inv_rkd.je) as qcscrkje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') < ? AND cpdm = ? AND ckdm = ? GROUP BY inv_rkd.cpdm,inv_rkd.ckdm) qcscrk ON clnc.cpdm = qcscrk.cpdm AND clnc.ckdm = qcscrk.ckdm" & _
                        " Left join (SELECT inv_dbd.cpdm,inv_dbd.rckdm AS ckdm,sum(inv_dbd.sl) as qcdbrksl,sum(inv_dbd.je) as qcdbrkje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ? AND cpdm = ? AND rckdm = ? GROUP BY inv_dbd.cpdm,inv_dbd.rckdm) qcdbrk ON clnc.cpdm = qcdbrk.cpdm AND clnc.ckdm = qcdbrk.ckdm" & _
                        " Left join (SELECT oe_xsd.cpdm,oe_xsd.ckdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') < ? AND cpdm = ? AND ckdm = ? GROUP BY oe_xsd.cpdm,oe_xsd.ckdm) qcxsck ON clnc.cpdm = qcxsck.cpdm AND clnc.ckdm = qcxsck.ckdm" & _
                        " Left join (SELECT inv_ckd.cpdm,inv_ckd.ckdm,sum(inv_ckd.sl) as qcckcksl,sum(inv_ckd.je) as qcckckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') < ? AND cpdm = ? AND ckdm = ? GROUP BY inv_ckd.cpdm,inv_ckd.ckdm) qcckck ON clnc.cpdm = qcckck.cpdm AND clnc.ckdm = qcckck.ckdm" & _
                        " Left join (SELECT inv_dbd.cpdm,inv_dbd.cckdm AS ckdm,sum(inv_dbd.sl) as qcdbcksl,sum(inv_dbd.je) as qcdbckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ? AND cpdm = ? AND cckdm = ? GROUP BY inv_dbd.cpdm,inv_dbd.cckdm) qcdbck ON clnc.cpdm = qcdbck.cpdm AND clnc.ckdm = qcdbck.ckdm) asfchz GROUP BY cpdm,ckdm"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataSet.Tables("redinv_rkd").Rows(i).Item("cpdm"))
                    rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("redinv_rkd").Rows(i).Item("ckdm"))
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePoBegin1
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("redinv_rkd").Rows(i).Item("cpdm"))
                    rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("redinv_rkd").Rows(i).Item("ckdm"))
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePoBegin1
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("redinv_rkd").Rows(i).Item("cpdm"))
                    rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("redinv_rkd").Rows(i).Item("ckdm"))
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePoBegin1
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateKsrq
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("redinv_rkd").Rows(i).Item("cpdm"))
                    rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("redinv_rkd").Rows(i).Item("ckdm"))
                    rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = datePoBegin1
                    rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("redinv_rkd").Rows(i).Item("cpdm"))
                    rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("redinv_rkd").Rows(i).Item("ckdm"))
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = datePoBegin1
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateKsrq
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("redinv_rkd").Rows(i).Item("cpdm"))
                    rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("redinv_rkd").Rows(i).Item("ckdm"))
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePoBegin1
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateKsrq
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("redinv_rkd").Rows(i).Item("cpdm"))
                    rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("redinv_rkd").Rows(i).Item("ckdm"))
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataSet.Tables("clqcye") IsNot Nothing Then
                        rcDataSet.Tables("clqcye").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataSet, "clqcye")
                    For j = 0 To rcDataSet.Tables("clqcye").Rows.Count - 1
                        '计算库存数量，库存金额inv_rkd.sl < 0 AND
                        dblQcsl = rcDataSet.Tables("clqcye").Rows(j).Item("qcsl") + rcDataSet.Tables("clqcye").Rows(j).Item("qccgrksl") + rcDataSet.Tables("clqcye").Rows(j).Item("qcscrksl") + rcDataSet.Tables("clqcye").Rows(j).Item("qcdbrksl") - rcDataSet.Tables("clqcye").Rows(j).Item("qcxscksl") - rcDataSet.Tables("clqcye").Rows(j).Item("qcckcksl") - rcDataSet.Tables("clqcye").Rows(j).Item("qcdbcksl")
                        dblQcje = rcDataSet.Tables("clqcye").Rows(j).Item("qcje") + rcDataSet.Tables("clqcye").Rows(j).Item("qccgrkje") + rcDataSet.Tables("clqcye").Rows(j).Item("qcscrkje") + rcDataSet.Tables("clqcye").Rows(j).Item("qcdbrkje") - rcDataSet.Tables("clqcye").Rows(j).Item("qcxsckje") - rcDataSet.Tables("clqcye").Rows(j).Item("qcckckje") - rcDataSet.Tables("clqcye").Rows(j).Item("qcdbckje")
                        If dblQcsl <> 0 Then   ' And dblQcje <> 0
                            rcOleDbCommand.CommandText = "UPDATE inv_rkd SET je = sl * ? / ?,bzcb = -1 WHERE inv_rkd.bdelete = 0 AND NOT EXISTS (SELECT 1 FROM rc_ckxx WHERE rc_ckxx.ckdm = inv_rkd.ckdm AND rc_ckxx.bscrkcb = 1) AND EXISTS (SELECT 1 FROM rc_lx WHERE SUBSTR(inv_rkd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(inv_rkd.djh,5,4) = rc_lx.kjnd AND lxgs = '产品入库单') AND inv_rkd.rkrq <= ? AND inv_rkd.rkrq >= ? AND inv_rkd.cpdm = ? AND inv_rkd.ckdm = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@qcje", OleDbType.Numeric, 14).Value = dblQcje
                            rcOleDbCommand.Parameters.Add("@qcsl", OleDbType.Numeric, 18).Value = dblQcsl
                            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("redinv_rkd").Rows(i).Item("cpdm"))
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("redinv_rkd").Rows(i).Item("ckdm"))
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    Next
                Next
            End If
            '更新本月入库产成品的标准成本
            rcOleDbCommand.CommandText = "UPDATE inv_rkd SET bzcb = (SELECT CASE WHEN beishu <> 0 THEN bzcb/beishu ELSE bzcb END FROM rc_cpxx WHERE rc_cpxx.cpdm = inv_rkd.cpdm) WHERE inv_rkd.bdelete = 0 AND inv_rkd.je = 0 AND EXISTS (SELECT 1 FROM rc_cpxx WHERE rc_cpxx.cpdm = inv_rkd.cpdm) AND NOT EXISTS (SELECT 1 FROM rc_ckxx WHERE rc_ckxx.ckdm = inv_rkd.ckdm AND rc_ckxx.bscrkcb = 1) AND EXISTS (SELECT 1 FROM rc_lx WHERE SUBSTR(inv_rkd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(inv_rkd.djh,5,4) = rc_lx.kjnd AND lxgs = '产品入库单') AND inv_rkd.bzcb <> -1 AND inv_rkd.rkrq <= ? AND inv_rkd.rkrq >= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "UPDATE inv_rkd SET bzcb = 0 WHERE inv_rkd.bdelete = 0 AND inv_rkd.je = 0 AND EXISTS (SELECT 1 FROM rc_cpxx WHERE rc_cpxx.cpdm = inv_rkd.cpdm) AND NOT EXISTS (SELECT 1 FROM rc_ckxx WHERE rc_ckxx.ckdm = inv_rkd.ckdm AND rc_ckxx.bscrkcb = 1) AND EXISTS (SELECT 1 FROM rc_lx WHERE SUBSTR(inv_rkd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(inv_rkd.djh,5,4) = rc_lx.kjnd AND lxgs = '产品入库单') AND inv_rkd.bzcb = -1 AND inv_rkd.rkrq <= ? AND inv_rkd.rkrq >= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
            rcOleDbCommand.ExecuteNonQuery()
            '更新本月入库产成品的约当产量
            rcOleDbCommand.CommandText = "UPDATE inv_rkd SET ydsl = bzcb * sl WHERE inv_rkd.bdelete = 0 AND inv_rkd.je = 0 AND NOT EXISTS (SELECT 1 FROM rc_ckxx WHERE rc_ckxx.ckdm = inv_rkd.ckdm AND rc_ckxx.bscrkcb = 1) AND EXISTS (SELECT 1 FROM rc_lx WHERE SUBSTR(inv_rkd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(inv_rkd.djh,5,4) = rc_lx.kjnd AND lxgs = '产品入库单') AND inv_rkd.rkrq <= ? AND inv_rkd.rkrq >= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
            rcOleDbCommand.ExecuteNonQuery()
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
        '取各部门的约当产量的合计数
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            If Me.TxtBiLi.Text = 0.0 Then
                If bCostRegion Then
                    rcOleDbCommand.CommandText = "SELECT sumydslc.bmdm,sumydslc.ydsl,COALESCE(sumydslb.zcbje,0.0) AS zcbje FROM (SELECT sumydsla.bmdm,COALESCE(SUM(sumydsla.ydsl),0.0) AS ydsl FROM ((SELECT rc_cr_ck.crdm AS bmdm,COALESCE(SUM(inv_rkd.ydsl),0.0) AS ydsl FROM inv_rkd,rc_lx,rc_cr_ck WHERE inv_rkd.ckdm = rc_cr_ck.ckdm AND inv_rkd.bdelete = 0 AND SUBSTR(inv_rkd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(inv_rkd.djh,5,4) = rc_lx.kjnd AND rc_lx.lxgs = '产品入库单' AND inv_rkd.rkrq <= ? AND inv_rkd.rkrq >= ? GROUP BY rc_cr_ck.crdm) UNION (SELECT bmdm,COALESCE(SUM(pm_zcp.ydsl),0.0) AS ydsl FROM pm_zcp WHERE cperiod = ? GROUP BY pm_zcp.bmdm)) sumydsla GROUP BY bmdm) sumydslc LEFT JOIN (SELECT cperiod,bmdm,qczcpje+zcbje-qmzcclje AS zcbje FROM pm_zcbje WHERE cperiod = ?) sumydslb ON sumydslc.bmdm = sumydslb.bmdm"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
                    rcOleDbCommand.Parameters.Add("cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Add("cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                Else
                    rcOleDbCommand.CommandText = "SELECT sumydslc.bmdm,sumydslc.ydsl,COALESCE(sumydslb.zcbje,0.0) AS zcbje FROM (SELECT sumydsla.bmdm,COALESCE(SUM(sumydsla.ydsl),0.0) AS ydsl FROM ((SELECT bmdm,COALESCE(SUM(inv_rkd.ydsl),0.0) AS ydsl FROM inv_rkd,rc_lx WHERE inv_rkd.bdelete = 0 AND SUBSTR(inv_rkd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(inv_rkd.djh,5,4) = rc_lx.kjnd AND rc_lx.lxgs = '产品入库单' AND inv_rkd.rkrq <= ? AND inv_rkd.rkrq >= ? GROUP BY inv_rkd.bmdm) UNION (SELECT bmdm,COALESCE(SUM(pm_zcp.ydsl),0.0) AS ydsl FROM pm_zcp WHERE cperiod = ? GROUP BY pm_zcp.bmdm)) sumydsla GROUP BY bmdm) sumydslc LEFT JOIN (SELECT cperiod,bmdm,qczcpje+zcbje-qmzcclje AS zcbje FROM pm_zcbje WHERE cperiod = ?) sumydslb ON sumydslc.bmdm = sumydslb.bmdm"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
                    rcOleDbCommand.Parameters.Add("cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Add("cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                End If
            Else
                If bCostRegion Then
                    rcOleDbCommand.CommandText = "SELECT sumydslc.bmdm,sumydslc.ydsl,COALESCE(sumydslb.zcbje,0.0) AS zcbje FROM (SELECT sumydsla.bmdm,COALESCE(SUM(sumydsla.ydsl),0.0) AS ydsl FROM (SELECT rc_cr_ck.crdm AS bmdm,COALESCE(SUM(inv_rkd.ydsl),0.0) AS ydsl FROM inv_rkd,rc_lx,rc_cr_ck WHERE inv_rkd.ckdm = rc_cr_ck.ckdm AND inv_rkd.bdelete = 0 AND SUBSTR(inv_rkd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(inv_rkd.djh,5,4) = rc_lx.kjnd AND rc_lx.lxgs = '产品入库单' AND inv_rkd.rkrq <= ? AND inv_rkd.rkrq >= ? GROUP BY rc_cr_ck.crdm) sumydsla GROUP BY bmdm) sumydslc LEFT JOIN (SELECT cperiod,bmdm,qczcpje+zcbje-qmzcclje AS zcbje FROM pm_zcbje WHERE cperiod = ?) sumydslb ON sumydslc.bmdm = sumydslb.bmdm"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
                    rcOleDbCommand.Parameters.Add("cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                Else
                    rcOleDbCommand.CommandText = "SELECT sumydslc.bmdm,sumydslc.ydsl,COALESCE(sumydslb.zcbje,0.0) AS zcbje FROM (SELECT sumydsla.bmdm,COALESCE(SUM(sumydsla.ydsl),0.0) AS ydsl FROM (SELECT bmdm,COALESCE(SUM(inv_rkd.ydsl),0.0) AS ydsl FROM inv_rkd,rc_lx WHERE inv_rkd.bdelete = 0 AND SUBSTR(inv_rkd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(inv_rkd.djh,5,4) = rc_lx.kjnd AND rc_lx.lxgs = '产品入库单' AND inv_rkd.rkrq <= ? AND inv_rkd.rkrq >= ? GROUP BY inv_rkd.bmdm) sumydsla GROUP BY bmdm) sumydslc LEFT JOIN (SELECT cperiod,bmdm,qczcpje+zcbje-qmzcclje AS zcbje FROM pm_zcbje WHERE cperiod = ?) sumydslb ON sumydslc.bmdm = sumydslb.bmdm"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
                    rcOleDbCommand.Parameters.Add("cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                End If
            End If
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("sumydsl") IsNot Nothing Then
                rcDataSet.Tables("sumydsl").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "sumydsl")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '3）分配生产成本
        '按部门编码或成本域进行分配总成本金额
        For i = 0 To rcDataSet.Tables("sumydsl").Rows.Count - 1
            Dim dblYdsl As Double = rcDataSet.Tables("sumydsl").Rows(i).Item("ydsl")
            Dim dblZcbje As Double = rcDataSet.Tables("sumydsl").Rows(i).Item("zcbje")
            '总约当产量为0则不能计算
            If dblYdsl <> 0 And dblZcbje <> 0 Then
                Try
                    rcOleDbConn.Open()
                    rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.Transaction = rcOleDbTrans
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    '读取生产入库成本按标准成本计算的成本金额
                    If bCostRegion Then
                        rcOleDbCommand.CommandText = "SELECT COALESCE(SUM(je),0.0) AS je FROM inv_rkd,rc_cr_ck WHERE inv_rkd.ckdm = rc_cr_ck.ckdm AND inv_rkd.bdelete = 0 AND rc_cr_ck.crdm = ? AND je <> 0 AND EXISTS (SELECT 1 FROM rc_ckxx WHERE rc_ckxx.ckdm = inv_rkd.ckdm AND rc_ckxx.bscrkcb = 1) AND EXISTS (SELECT 1 FROM rc_lx WHERE SUBSTR(inv_rkd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(inv_rkd.djh,5,4) = rc_lx.kjnd AND lxgs = '产品入库单') AND inv_rkd.rkrq <= ? AND inv_rkd.rkrq >= ?"
                    Else
                        rcOleDbCommand.CommandText = "SELECT COALESCE(SUM(je),0.0) AS je FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND bmdm = ? AND je <> 0 AND EXISTS (SELECT 1 FROM rc_ckxx WHERE rc_ckxx.ckdm = inv_rkd.ckdm AND rc_ckxx.bscrkcb = 1) AND EXISTS (SELECT 1 FROM rc_lx WHERE SUBSTR(inv_rkd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(inv_rkd.djh,5,4) = rc_lx.kjnd AND lxgs = '产品入库单') AND inv_rkd.rkrq <= ? AND inv_rkd.rkrq >= ?"
                    End If
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("sumydsl").Rows(i).Item("bmdm")
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("sumbzcbje") IsNot Nothing Then
                        rcDataset.Tables("sumbzcbje").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "sumbzcbje")
                    If rcDataset.Tables("sumbzcbje").Rows.Count > 0 Then
                        dblZcbje -= rcDataset.Tables("sumbzcbje").Rows(0).Item("je")
                    End If

                    If Me.CheckBox2.Checked Then
                        '读取留存的红字产品的成本
                        If bCostRegion Then
                            rcOleDbCommand.CommandText = "SELECT COALESCE(SUM(je),0.0) AS je FROM inv_rkd,rc_cr_ck WHERE inv_rkd.ckdm = rc_cr_ck.ckdm AND inv_rkd.bdelete = 0 AND rc_cr_ck.crdm = ? AND je <> 0 AND NOT EXISTS (SELECT 1 FROM rc_ckxx WHERE rc_ckxx.ckdm = inv_rkd.ckdm AND rc_ckxx.bscrkcb = 1) AND EXISTS (SELECT 1 FROM rc_lx WHERE SUBSTR(inv_rkd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(inv_rkd.djh,5,4) = rc_lx.kjnd AND lxgs = '产品入库单') AND inv_rkd.rkrq <= ? AND inv_rkd.rkrq >= ?"
                        Else
                            rcOleDbCommand.CommandText = "SELECT COALESCE(SUM(je),0.0) AS je FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND bmdm = ? AND je <> 0 AND NOT EXISTS (SELECT 1 FROM rc_ckxx WHERE rc_ckxx.ckdm = inv_rkd.ckdm AND rc_ckxx.bscrkcb = 1) AND EXISTS (SELECT 1 FROM rc_lx WHERE SUBSTR(inv_rkd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(inv_rkd.djh,5,4) = rc_lx.kjnd AND lxgs = '产品入库单') AND inv_rkd.rkrq <= ? AND inv_rkd.rkrq >= ?"
                        End If
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("sumydsl").Rows(i).Item("bmdm")
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataSet.Tables("sumredje") IsNot Nothing Then
                            rcDataSet.Tables("sumredje").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataSet, "sumredje")
                        If rcDataSet.Tables("sumredje").Rows.Count > 0 Then
                            dblZcbje -= rcDataSet.Tables("sumredje").Rows(0).Item("je")
                        End If
                    End If
                    '更新期末在产品的约当产量成本
                    If Me.TxtBiLi.Text = 0.0 Then
                        rcOleDbCommand.CommandText = "UPDATE pm_zcp SET zcpje = (ydsl * " & dblZcbje & "/" & dblYdsl & ") WHERE EXISTS (SELECT 1 FROM rc_cpxx WHERE rc_cpxx.cpdm = pm_zcp.cpdm) AND bmdm = ? AND cperiod = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("sumydsl").Rows(i).Item("bmdm")
                        rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                        rcOleDbCommand.ExecuteNonQuery()
                    Else
                        '读取留存的在产品的成本
                        rcOleDbCommand.CommandText = "SELECT COALESCE(SUM(zcpje),0.0) AS zcpje FROM pm_zcp WHERE bmdm = ? AND cperiod = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("sumydsl").Rows(i).Item("bmdm")
                        rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataSet.Tables("sumzcpje") IsNot Nothing Then
                            rcDataSet.Tables("sumzcpje").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataSet, "sumzcpje")
                        If rcDataSet.Tables("sumzcpje").Rows.Count > 0 Then
                            dblZcbje -= rcDataSet.Tables("sumzcpje").Rows(0).Item("zcpje")
                        End If
                    End If
                    If dblZcbje <> 0 Then
                        If bCostRegion Then
                            '更新本月入库产成品的入库成本
                            rcOleDbCommand.CommandText = "UPDATE inv_rkd SET je = (ydsl * " & dblZcbje & "/" & dblYdsl & ") WHERE inv_rkd.bdelete = 0 AND inv_rkd.je = 0 AND EXISTS (SELECT 1 FROM rc_lx WHERE SUBSTR(inv_rkd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(inv_rkd.djh,5,4) = rc_lx.kjnd AND lxgs = '产品入库单') AND EXISTS (SELECT 1 FROM rc_cr_ck WHERE rc_cr_ck.ckdm = inv_rkd.ckdm AND rc_cr_ck.crdm = ?) AND inv_rkd.rkrq <= ? AND inv_rkd.rkrq >= ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("sumydsl").Rows(i).Item("bmdm")
                            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
                            rcOleDbCommand.ExecuteNonQuery()
                            '更新本月入库产成品的入库单价
                            rcOleDbCommand.CommandText = "UPDATE inv_rkd SET dj = CASE WHEN sl <> 0 THEN je / sl ELSE 0 END WHERE inv_rkd.bdelete = 0 AND NOT EXISTS (SELECT 1 FROM rc_ckxx WHERE rc_ckxx.ckdm = inv_rkd.ckdm AND rc_ckxx.bscrkcb = 1) AND EXISTS (SELECT 1 FROM rc_lx WHERE SUBSTR(inv_rkd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(inv_rkd.djh,5,4) = rc_lx.kjnd AND lxgs = '产品入库单') AND EXISTS (SELECT 1 FROM rc_cr_ck WHERE rc_cr_ck.ckdm = inv_rkd.ckdm AND rc_cr_ck.crdm = ?) AND inv_rkd.rkrq <= ? AND inv_rkd.rkrq >= ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("sumydsl").Rows(i).Item("bmdm")
                            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
                            rcOleDbCommand.ExecuteNonQuery()
                        Else
                            '更新本月入库产成品的入库成本
                            rcOleDbCommand.CommandText = "UPDATE inv_rkd SET je = (ydsl * " & dblZcbje & "/" & dblYdsl & ") WHERE inv_rkd.bdelete = 0 AND inv_rkd.je = 0 AND EXISTS (SELECT 1 FROM rc_lx WHERE SUBSTR(inv_rkd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(inv_rkd.djh,5,4) = rc_lx.kjnd AND lxgs = '产品入库单') AND inv_rkd.bmdm = ? AND inv_rkd.rkrq <= ? AND inv_rkd.rkrq >= ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("sumydsl").Rows(i).Item("bmdm")
                            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
                            rcOleDbCommand.ExecuteNonQuery()
                            '更新本月入库产成品的入库单价
                            rcOleDbCommand.CommandText = "UPDATE inv_rkd SET dj = CASE WHEN sl <> 0 THEN je / sl ELSE 0 END WHERE inv_rkd.bdelete = 0 AND NOT EXISTS (SELECT 1 FROM rc_ckxx WHERE rc_ckxx.ckdm = inv_rkd.ckdm AND rc_ckxx.bscrkcb = 1) AND EXISTS (SELECT 1 FROM rc_lx WHERE SUBSTR(inv_rkd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(inv_rkd.djh,5,4) = rc_lx.kjnd AND lxgs = '产品入库单') AND inv_rkd.bmdm = ? AND inv_rkd.rkrq <= ? AND inv_rkd.rkrq >= ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("sumydsl").Rows(i).Item("bmdm")
                            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    If bCostRegion Then
                        '成本域--更新pm_zcbje的数据
                        rcOleDbCommand.CommandText = "UPDATE pm_zcbje SET ccpje = (SELECT COALESCE(SUM(je),0.0) FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND EXISTS (SELECT 1 FROM rc_cr_ck WHERE rc_cr_ck.ckdm = inv_rkd.ckdm AND rc_cr_ck.crdm = ?) AND inv_rkd.rkrq <= ? AND inv_rkd.rkrq >= ?) WHERE bmdm = ? AND cperiod = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("sumydsl").Rows(i).Item("bmdm")
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
                        rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("sumydsl").Rows(i).Item("bmdm")
                        rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                        rcOleDbCommand.ExecuteNonQuery()
                        rcOleDbCommand.CommandText = "UPDATE pm_zcbje SET qmzcpje = (SELECT COALESCE(SUM(zcpje),0.0) FROM pm_zcp WHERE pm_zcp.bmdm = ? AND pm_zcp.cperiod = ?) WHERE bmdm = ? AND cperiod = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("sumydsl").Rows(i).Item("bmdm")
                        rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                        rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("sumydsl").Rows(i).Item("bmdm")
                        rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                        rcOleDbCommand.ExecuteNonQuery()
                    Else
                        '更新pm_zcbje的数据
                        rcOleDbCommand.CommandText = "UPDATE pm_zcbje SET ccpje = (SELECT COALESCE(SUM(je),0.0) FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND inv_rkd.bmdm = ? AND inv_rkd.rkrq <= ? AND inv_rkd.rkrq >= ?) WHERE bmdm = ? AND cperiod = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("sumydsl").Rows(i).Item("bmdm")
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
                        rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("sumydsl").Rows(i).Item("bmdm")
                        rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                        rcOleDbCommand.ExecuteNonQuery()
                        rcOleDbCommand.CommandText = "UPDATE pm_zcbje SET qmzcpje = (SELECT COALESCE(SUM(zcpje),0.0) FROM pm_zcp WHERE pm_zcp.bmdm = ? AND pm_zcp.cperiod = ?) WHERE bmdm = ? AND cperiod = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("sumydsl").Rows(i).Item("bmdm")
                        rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                        rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("sumydsl").Rows(i).Item("bmdm")
                        rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
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

            End If
        Next
        MsgBox("生产成本分配完成。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        Me.Close()
    End Sub
End Class