Imports System.Data.OleDb

Public Class FrmCbjz
    '建立数据适配器
    Dim rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    Dim rcDataSet As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    Dim rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable '我们要利用该datatable进行金额计算
    Dim dtBom As New DataTable("rc_cbjz")

#Region "初始化"

    Private Sub FrmCbjz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        Me.NudYear.Value = Mid(g_Kjqj, 1, 4)
        Me.NudMonthBegin.Value = Mid(g_Kjqj, 5, 2)
        Me.NudMonthEnd.Value = Mid(g_Kjqj, 5, 2)
        Me.TxtZclcb.Text = 0.0
        Me.TxtZrgcb.Text = 0.0
        Me.TxtZglcb.Text = 0.0
        Me.TxtZcb.Text = 0.0
        '设置DataGridView
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.DataGridView1.Columns("ColClcb").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridView1.Columns("ColClcb").DefaultCellStyle.Format = g_FormatJe
        Me.DataGridView1.Columns("ColRgcb").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridView1.Columns("ColRgcb").DefaultCellStyle.Format = g_FormatJe
        Me.DataGridView1.Columns("ColGlcb").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridView1.Columns("ColGlcb").DefaultCellStyle.Format = g_FormatJe
        Me.DataGridView1.Columns("ColZcb").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridView1.Columns("ColZcb").DefaultCellStyle.Format = g_FormatJe
        '数据绑定
        dtBom.Columns.Add("bmdm", Type.GetType("System.String"))
        dtBom.Columns.Add("bmmc", Type.GetType("System.String"))
        dtBom.Columns.Add("clcb", Type.GetType("System.Double"))
        dtBom.Columns.Add("rgcb", Type.GetType("System.Double"))
        dtBom.Columns.Add("glcb", Type.GetType("System.Double"))
        dtBom.Columns.Add("zcb", Type.GetType("System.Double"))
        rcDataSet.Tables.Add(dtBom)
        With dtBom
            .Columns("bmdm").DefaultValue = ""
            .Columns("bmmc").DefaultValue = ""
            .Columns("clcb").DefaultValue = 0.0
            .Columns("rgcb").DefaultValue = 0.0
            .Columns("glcb").DefaultValue = 0.0
            .Columns("zcb").DefaultValue = 0.0
            .Columns("zcb").Expression = "clcb + rgcb + glcb"
        End With
        Me.rcBindingSource.DataSource = dtBom
        Me.DataGridView1.DataSource = Me.rcBindingSource
    End Sub

#End Region

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NudYear.KeyPress, NudMonthBegin.KeyPress, NudMonthEnd.KeyPress, TxtZcb.KeyPress, TxtZclcb.KeyPress, TxtZrgcb.KeyPress, TxtZglcb.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "读入数据"

    Private Sub BtnImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImp.Click
        Dim dateKsrq As Date = getInvBegin(Me.NudYear.Value, Me.NudMonthBegin.Value)
        Dim dateJsrq As Date = getInvEnd(Me.NudYear.Value, Me.NudMonthEnd.Value)
        '取产品入库单
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT rc_bmxx.bmdm,rc_bmxx.bmmc,COALESCE(acbjz.clcb,0.0) AS clcb,COALESCE(acbjz.rgcb,0.0) AS rgcb,COALESCE(acbjz.glcb,0.0) AS glcb FROM rc_bmxx LEFT JOIN (SELECT inv_rkd.bmdm,SUM(inv_rkd.clcb) AS clcb,SUM(inv_rkd.rgcb) AS rgcb,SUM(inv_rkd.glcb) AS glcb FROM inv_rkd WHERE inv_rkd.bdelete <> 1 AND inv_rkd.rkrq >= ? AND inv_rkd.rkrq <= ? GROUP BY inv_rkd.bmdm) acbjz ON acbjz.bmdm = rc_bmxx.bmdm ORDER BY rc_bmxx.bmdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If Not rcDataSet.Tables("rc_cbjz") Is Nothing Then
                rcDataSet.Tables("rc_cbjz").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_cbjz")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        Finally
            rcOleDbConn.Close()
        End Try
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        '结转成本
        '结转退货单的成本
        '结转出库单的成本
        Dim datePoBegin1 As Date = Now.Date
        Dim dateKsrq As Date '成本结转开始日期
        Dim dateJsrq As Date '成本结转结束日期
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim k As Integer = 0
        Dim dblQcsl As Double = 0.0
        Dim dblQcje As Double = 0.0
        Dim dblQcdj As Double = 0.0
        Dim dblBmzje As Double = 0.0
        Dim dblZydsl As Double = 0.0
        datePoBegin1 = getInvBegin(Me.NudYear.Value, 1)
        dateKsrq = getInvBegin(Me.NudYear.Value, Me.NudMonthBegin.Value)
        dateJsrq = getInvEnd(Me.NudYear.Value, Me.NudMonthEnd.Value)
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
            If Not rcDataSet.Tables("cpxx") Is Nothing Then
                rcDataSet.Tables("cpxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "cpxx")
            For i = 0 To rcDataSet.Tables("cpxx").Rows.Count - 1
                Me.ProgressBar1.Value = 100 / rcDataSet.Tables("cpxx").Rows.Count * (i + 1)
                Dim strJjfs As String = "加权平均法" ' rcDataSet.Tables("cpxx").Rows(i).Item("jjfs")
                Select Case strJjfs
                    Case "加权平均法"
                        '''''''''''''''''''''''''''''''
                        ''''''''''加权平均法'''''''''''
                        '''''''''''''''''''''''''''''''
                        '计算该产品该仓库的上月账面数量+本月入库数量、上月的账面金额+本月入库金额
                        'For j = 0 To rcDataset.Tables("dbdnr").Rows.Count - 1
                        '分仓库汇总,不含调拨单的入库数量与金额，用来计算调调拨单的出库成本
                        rcOleDbCommand.CommandText = "SELECT cpdm,ckdm,COALESCE(sum(qcsl),0.0) as qcsl,COALESCE(sum(qcje),0.0) as qcje,COALESCE(sum(qccgrksl),0.0) as qccgrksl,COALESCE(sum(qccgrkje),0.0) as qccgrkje,COALESCE(sum(qcscrksl),0.0) as qcscrksl,COALESCE(sum(qcscrkje),0.0) as qcscrkje,COALESCE(sum(qcdbrksl),0.0) as qcdbrksl,COALESCE(sum(qcdbrkje),0.0) as qcdbrkje,COALESCE(sum(qcxscksl),0.0) as qcxscksl,COALESCE(sum(qcxsckje),0.0) as qcxsckje,COALESCE(sum(qcckcksl),0.0) as qcckcksl,COALESCE(sum(qcckckje),0.0) as qcckckje,COALESCE(sum(qcdbcksl),0.0) as qcdbcksl,COALESCE(sum(qcdbckje),0.0) as qcdbckje FROM (SELECT clnc.cpdm,clnc.ckdm,clnc.qcsl,clnc.qcje,qccgrk.qccgrksl,qccgrk.qccgrkje,qcscrk.qcscrksl,qcscrk.qcscrkje,qcdbrk.qcdbrksl,qcdbrk.qcdbrkje,qcxsck.qcxscksl,qcxsck.qcxsckje,qcckck.qcckcksl,qcckck.qcckckje,qcdbck.qcdbcksl,qcdbck.qcdbckje FROM" & _
                            " (SELECT inv_cpyeb.cpdm,inv_cpyeb.ckdm,sum(qcsl) as qcsl,sum(qcje) as qcje FROM inv_cpyeb WHERE kjnd = ? AND cpdm = ? GROUP by inv_cpyeb.cpdm,inv_cpyeb.ckdm) clnc" & _
                            " Left join (SELECT po_rkd.cpdm,po_rkd.ckdm,sum(po_rkd.sl) as qccgrksl,sum(po_rkd.je) as qccgrkje FROM po_rkd WHERE po_rkd.bdelete = 0 AND po_rkd.rkrq >= ? AND po_rkd.rkrq >= ? AND po_rkd.rkrq <= ? AND cpdm = ? GROUP BY po_rkd.cpdm,po_rkd.ckdm) qccgrk ON clnc.cpdm = qccgrk.cpdm AND clnc.ckdm = qccgrk.ckdm" & _
                            " Left join (SELECT inv_rkd.cpdm,inv_rkd.ckdm,sum(inv_rkd.sl) as qcscrksl,sum(inv_rkd.je) as qcscrkje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND inv_rkd.rkrq >= ? and inv_rkd.rkrq >= ? and inv_rkd.rkrq < ? AND cpdm = ? GROUP BY inv_rkd.cpdm,inv_rkd.ckdm) qcscrk ON clnc.cpdm = qcscrk.cpdm AND clnc.ckdm = qcscrk.ckdm" & _
                            " Left join (SELECT inv_dbd.cpdm,inv_dbd.rckdm AS ckdm,sum(inv_dbd.sl) as qcdbrksl,sum(inv_dbd.je) as qcdbrkje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ? AND cpdm = ? GROUP BY inv_dbd.cpdm,inv_dbd.rckdm) qcdbrk ON clnc.cpdm = qcdbrk.cpdm AND clnc.ckdm = qcdbrk.ckdm" & _
                            " Left join (SELECT oe_xsd.cpdm,oe_xsd.ckdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq < ? AND cpdm = ? GROUP BY oe_xsd.cpdm,oe_xsd.ckdm) qcxsck ON clnc.cpdm = qcxsck.cpdm AND clnc.ckdm = qcxsck.ckdm" & _
                            " Left join (SELECT inv_ckd.cpdm,inv_ckd.ckdm,sum(inv_ckd.sl) as qcckcksl,sum(inv_ckd.je) as qcckckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND inv_ckd.ckrq >= ? and inv_ckd.ckrq >= ? and inv_ckd.ckrq < ? AND cpdm = ? GROUP BY inv_ckd.cpdm,inv_ckd.ckdm) qcckck ON clnc.cpdm = qcckck.cpdm AND clnc.ckdm = qcckck.ckdm" & _
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
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
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
                        If Not rcDataSet.Tables("clqcye") Is Nothing Then
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
                            ''按平均单价进行更新当月产品调拨单的调拨金额=成本单价*退货数量
                            rcOleDbCommand.CommandText = "UPDATE inv_dbd SET inv_dbd.je = inv_dbd.sl * ?,inv_dbd.dj = ? WHERE inv_dbd.cpdm = ? AND cckdm = ? AND SUBSTR(inv_dbd.djh,5,6) >= ? AND SUBSTR(inv_dbd.djh,5,6) <= ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                            rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("cpxx").Rows(i).Item("cpdm")
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("clqcye").Rows(j).Item("ckdm")
                            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthBegin.Value.ToString.PadLeft(2, "0")
                            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthEnd.Value.ToString.PadLeft(2, "0")
                            rcOleDbCommand.ExecuteNonQuery()
                        Next
                        '分仓库汇总,含调拨单的入库数量与金额，用来计算出库单的出库成本
                        rcOleDbCommand.CommandText = "SELECT cpdm,ckdm,COALESCE(sum(qcsl),0.0) as qcsl,COALESCE(sum(qcje),0.0) as qcje,COALESCE(sum(qccgrksl),0.0) as qccgrksl,COALESCE(sum(qccgrkje),0.0) as qccgrkje,COALESCE(sum(qcscrksl),0.0) as qcscrksl,COALESCE(sum(qcscrkje),0.0) as qcscrkje,COALESCE(sum(qcdbrksl),0.0) as qcdbrksl,COALESCE(sum(qcdbrkje),0.0) as qcdbrkje,COALESCE(sum(qcxscksl),0.0) as qcxscksl,COALESCE(sum(qcxsckje),0.0) as qcxsckje,COALESCE(sum(qcckcksl),0.0) as qcckcksl,COALESCE(sum(qcckckje),0.0) as qcckckje,COALESCE(sum(qcdbcksl),0.0) as qcdbcksl,COALESCE(sum(qcdbckje),0.0) as qcdbckje FROM (SELECT clnc.cpdm,clnc.ckdm,clnc.qcsl,clnc.qcje,qccgrk.qccgrksl,qccgrk.qccgrkje,qcscrk.qcscrksl,qcscrk.qcscrkje,qcdbrk.qcdbrksl,qcdbrk.qcdbrkje,qcxsck.qcxscksl,qcxsck.qcxsckje,qcckck.qcckcksl,qcckck.qcckckje,qcdbck.qcdbcksl,qcdbck.qcdbckje FROM" & _
                            " (SELECT inv_cpyeb.cpdm,inv_cpyeb.ckdm,sum(qcsl) as qcsl,sum(qcje) as qcje FROM inv_cpyeb WHERE kjnd = ? AND cpdm = ? GROUP by inv_cpyeb.cpdm,inv_cpyeb.ckdm) clnc" & _
                            " Left join (SELECT po_rkd.cpdm,po_rkd.ckdm,sum(po_rkd.sl) as qccgrksl,sum(po_rkd.je) as qccgrkje FROM po_rkd WHERE po_rkd.bdelete = 0 AND po_rkd.rkrq >= ? and po_rkd.rkrq >= ? and po_rkd.rkrq <= ? AND cpdm = ? GROUP BY po_rkd.cpdm,po_rkd.ckdm) qccgrk ON clnc.cpdm = qccgrk.cpdm AND clnc.ckdm = qccgrk.ckdm" & _
                            " Left join (SELECT inv_rkd.cpdm,inv_rkd.ckdm,sum(inv_rkd.sl) as qcscrksl,sum(inv_rkd.je) as qcscrkje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND inv_rkd.rkrq >= ? and inv_rkd.rkrq >= ? and inv_rkd.rkrq < ? AND cpdm = ? GROUP BY inv_rkd.cpdm,inv_rkd.ckdm) qcscrk ON clnc.cpdm = qcscrk.cpdm AND clnc.ckdm = qcscrk.ckdm" & _
                            " Left join (SELECT inv_dbd.cpdm,inv_dbd.rckdm AS ckdm,sum(inv_dbd.sl) as qcdbrksl,sum(inv_dbd.je) as qcdbrkje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ? AND cpdm = ? GROUP BY inv_dbd.cpdm,inv_dbd.rckdm) qcdbrk ON clnc.cpdm = qcdbrk.cpdm AND clnc.ckdm = qcdbrk.ckdm" & _
                            " Left join (SELECT oe_xsd.cpdm,oe_xsd.ckdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq < ? AND cpdm = ? GROUP BY oe_xsd.cpdm,oe_xsd.ckdm) qcxsck ON clnc.cpdm = qcxsck.cpdm AND clnc.ckdm = qcxsck.ckdm" & _
                            " Left join (SELECT inv_ckd.cpdm,inv_ckd.ckdm,sum(inv_ckd.sl) as qcckcksl,sum(inv_ckd.je) as qcckckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND inv_ckd.ckrq >= ? and inv_ckd.ckrq >= ? and inv_ckd.ckrq < ? AND cpdm = ? GROUP BY inv_ckd.cpdm,inv_ckd.ckdm) qcckck ON clnc.cpdm = qcckck.cpdm AND clnc.ckdm = qcckck.ckdm" & _
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
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
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
                        If Not rcDataSet.Tables("clqcye") Is Nothing Then
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
                            'MsgBox(Str(dblQcdj) + "/" + rcDataSet.Tables("cpxx").Rows(i).Item("cpdm") + "/" + rcDataSet.Tables("clqcye").Rows(j).Item("ckdm"))

                            ''按平均单价进行更新当月产品出库单的调拨金额=成本单价*退货数量
                            rcOleDbCommand.CommandText = "UPDATE oe_xsd SET oe_xsd.cbje = oe_xsd.sl * ?,oe_xsd.cbdj = ? WHERE oe_xsd.cpdm = ? AND ckdm = ? AND SUBSTR(oe_xsd.djh,5,6) >= ?  AND SUBSTR(oe_xsd.djh,5,6) <= ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                            rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("cpxx").Rows(i).Item("cpdm")
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("clqcye").Rows(j).Item("ckdm")
                            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthBegin.Value.ToString.PadLeft(2, "0")
                            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthEnd.Value.ToString.PadLeft(2, "0")
                            rcOleDbCommand.ExecuteNonQuery()
                            ''按平均单价进行更新当月产品出库单的调拨金额=成本单价*退货数量
                            rcOleDbCommand.CommandText = "UPDATE inv_ckd SET inv_ckd.je = inv_ckd.sl * ?,inv_ckd.dj = ? WHERE inv_ckd.cpdm = ? AND ckdm = ? AND SUBSTR(inv_ckd.djh,5,6) >= ? AND SUBSTR(inv_ckd.djh,5,6) <= ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                            rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("cpxx").Rows(i).Item("cpdm")
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("clqcye").Rows(j).Item("ckdm")
                            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthBegin.Value.ToString.PadLeft(2, "0")
                            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthEnd.Value.ToString.PadLeft(2, "0")
                            rcOleDbCommand.ExecuteNonQuery()
                        Next

                End Select
                '材料出库成本尾差的调整,先进先出法不用进行尾差调整。
            Next
            '分配产成品的成本
            '******************
            '更新产品分配标准
            rcOleDbCommand.CommandText = "UPDATE inv_rkd SET inv_rkd.bzcb = (SELECT bzcb FROM rc_cpxx WHERE rc_cpxx.cpdm = inv_rkd.cpdm)  WHERE SUBSTR(inv_rkd.djh,5,6) >= ? AND SUBSTR(inv_rkd.djh,5,6) <= ?"
            'rcOleDbCommand.CommandText = "UPDATE inv_rkd SET inv_rkd.clcb = (SELECT clcb FROM rc_cpxx WHERE rc_cpxx.cpdm = inv_rkd.cpdm),inv_rkd.rgcb = (SELECT rgcb FROM rc_cpxx WHERE rc_cpxx.cpdm = inv_rkd.cpdm) WHERE SUBSTR(inv_rkd.djh,5,6) >= ? AND SUBSTR(inv_rkd.djh,5,6) <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthBegin.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthEnd.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            '汇总材料出库总金额
            rcOleDbCommand.CommandText = "SELECT bmdm,COALESCE(SUM(je),0.0) AS je FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND SUBSTR(inv_ckd.djh,5,6) >= ? AND SUBSTR(inv_ckd.djh,5,6) <= ? GROUP BY bmdm ORDER BY bmdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthBegin.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthEnd.Value.ToString.PadLeft(2, "0")
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If Not rcDataSet.Tables("inv_ckd") Is Nothing Then
                rcDataSet.Tables("inv_ckd").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "inv_ckd")
            '在界面中显示材料金额
            For i = 0 To rcDataSet.Tables("inv_ckd").Rows.Count - 1
                For j = 0 To rcDataSet.Tables("rc_cbjz").Rows.Count - 1
                    If rcDataSet.Tables("inv_ckd").Rows(i).Item("bmdm") = rcDataSet.Tables("rc_cbjz").Rows(j).Item("bmdm") Then
                        rcDataSet.Tables("rc_cbjz").Rows(j).Item("clcb") = rcDataSet.Tables("inv_ckd").Rows(i).Item("je")
                    End If
                Next
            Next
            Me.TxtZclcb.Text = rcDataSet.Tables("rc_cbjz").Compute("SUM(clcb)", "")
            Me.TxtZrgcb.Text = rcDataSet.Tables("rc_cbjz").Compute("SUM(rgcb)", "")
            Me.TxtZglcb.Text = rcDataSet.Tables("rc_cbjz").Compute("SUM(glcb)", "")
            Me.TxtZcb.Text = Val(Me.TxtZclcb.Text) + Val(Me.TxtZrgcb.Text) + Val(Me.TxtZglcb.Text)
            '按部门进行循环分摊
            For i = 0 To rcDataSet.Tables("rc_cbjz").Rows.Count - 1
                dblBmzje = rcDataSet.Tables("rc_cbjz").Rows(i).Item("zcb")
                If dblBmzje <> 0 Then
                    '汇总约当产量
                    rcOleDbCommand.CommandText = "SELECT COALESCE(SUM(bzcb * sl),0.0) AS zydsl FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND SUBSTR(inv_rkd.djh,5,6) >= ? AND SUBSTR(inv_rkd.djh,5,6) <= ? AND inv_rkd.bmdm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthBegin.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthEnd.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("rc_cbjz").Rows(i).Item("bmdm")
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If Not rcDataSet.Tables("inv_rkd") Is Nothing Then
                        rcDataSet.Tables("inv_rkd").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataSet, "inv_rkd")
                    dblZydsl = rcDataSet.Tables("inv_rkd").Rows(0).Item("zydsl")
                    If dblZydsl <> 0 Then
                        rcOleDbCommand.CommandText = "UPDATE inv_rkd SET inv_rkd.dj = " & dblBmzje & "/" & dblZydsl & "  * inv_rkd.bzcb,inv_rkd.je = " & dblBmzje & "/" & dblZydsl & " * inv_rkd.sl * inv_rkd.bzcb WHERE SUBSTR(inv_rkd.djh,5,6) >= ? AND SUBSTR(inv_rkd.djh,5,6) <= ? AND inv_rkd.bmdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthBegin.Value.ToString.PadLeft(2, "0")
                        rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthEnd.Value.ToString.PadLeft(2, "0")
                        rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("rc_cbjz").Rows(i).Item("bmdm")
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                    '调整差额
                    '取合计入库金额
                    rcOleDbCommand.CommandText = "SELECT COALESCE(SUM(je),0.0) AS je FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND SUBSTR(inv_rkd.djh,5,6) >= ? AND SUBSTR(inv_rkd.djh,5,6) <= ? AND inv_rkd.bmdm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthBegin.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthEnd.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("rc_cbjz").Rows(i).Item("bmdm")
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If Not rcDataSet.Tables("inv_rkd1") Is Nothing Then
                        rcDataSet.Tables("inv_rkd1").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataSet, "inv_rkd1")
                    If rcDataSet.Tables("inv_rkd1").Rows(0).Item("je") <> dblBmzje Then
                        '取最大的入库金额的单据
                        rcOleDbCommand.CommandText = "SELECT djh,xh,je FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND SUBSTR(inv_rkd.djh,5,6) >= ? AND SUBSTR(inv_rkd.djh,5,6) <= ? AND inv_rkd.bmdm = ? ORDER BY je DESC"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthBegin.Value.ToString.PadLeft(2, "0")
                        rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthEnd.Value.ToString.PadLeft(2, "0")
                        rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("rc_cbjz").Rows(i).Item("bmdm")
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If Not rcDataSet.Tables("inv_rkd2") Is Nothing Then
                            rcDataSet.Tables("inv_rkd2").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataSet, "inv_rkd2")
                        If rcDataSet.Tables("inv_rkd2").Rows.Count > 0 Then
                            rcOleDbCommand.CommandText = "UPDATE inv_rkd SET inv_rkd.je = inv_rkd.je - " & rcDataSet.Tables("inv_rkd1").Rows(0).Item("je") & "+" & dblBmzje & " WHERE inv_rkd.djh = ? AND inv_rkd.xh = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataSet.Tables("inv_rkd2").Rows(0).Item("djh")
                            rcOleDbCommand.Parameters.Add("@xh", OleDbType.Numeric, 4).Value = rcDataSet.Tables("inv_rkd2").Rows(0).Item("xh")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                Else
                    rcOleDbCommand.CommandText = "UPDATE inv_rkd SET inv_rkd.dj = 0.0,inv_rkd.je = 0.0 WHERE SUBSTR(inv_rkd.djh,5,6) >= ? AND SUBSTR(inv_rkd.djh,5,6) <= ? AND inv_rkd.bmdm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthBegin.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthEnd.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("rc_cbjz").Rows(i).Item("bmdm")
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            Next
            ''分配产成品的人工成本
            ''更新产品分配标准
            'rcOleDbCommand.CommandText = "UPDATE inv_rkd SET inv_rkd.je = inv_rkd.je + inv_rkd.rgcb * inv_rkd.sl WHERE SUBSTR(inv_rkd.djh,5,6) >= ? AND SUBSTR(inv_rkd.djh,5,6) <= ?"
            'rcOleDbCommand.Parameters.Clear()
            'rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthBegin.Value.ToString.PadLeft(2, "0")
            'rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthEnd.Value.ToString.PadLeft(2, "0")
            'rcOleDbCommand.ExecuteNonQuery()
            'rcOleDbCommand.CommandText = "UPDATE inv_rkd SET inv_rkd.dj = CASE WHEN inv_rkd.sl <> 0  THEN inv_rkd.je / inv_rkd.sl ELSE 0.0 END WHERE SUBSTR(inv_rkd.djh,5,6) >= ? AND SUBSTR(inv_rkd.djh,5,6) <= ?"
            'rcOleDbCommand.Parameters.Clear()
            'rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthBegin.Value.ToString.PadLeft(2, "0")
            'rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthEnd.Value.ToString.PadLeft(2, "0")
            'rcOleDbCommand.ExecuteNonQuery()
            '结转产成品的出库成本
            For i = 0 To rcDataSet.Tables("cpxx").Rows.Count - 1
                Me.ProgressBar1.Value = 100 / rcDataSet.Tables("cpxx").Rows.Count * (i + 1)
                '分仓库汇总,不含调拨单的入库数量与金额，用来计算调调拨单的出库成本
                rcOleDbCommand.CommandText = "SELECT cpdm,ckdm,COALESCE(sum(qcsl),0.0) as qcsl,COALESCE(sum(qcje),0.0) as qcje,COALESCE(sum(qccgrksl),0.0) as qccgrksl,COALESCE(sum(qccgrkje),0.0) as qccgrkje,COALESCE(sum(qcscrksl),0.0) as qcscrksl,COALESCE(sum(qcscrkje),0.0) as qcscrkje,COALESCE(sum(qcdbrksl),0.0) as qcdbrksl,COALESCE(sum(qcdbrkje),0.0) as qcdbrkje,COALESCE(sum(qcxscksl),0.0) as qcxscksl,COALESCE(sum(qcxsckje),0.0) as qcxsckje,COALESCE(sum(qcckcksl),0.0) as qcckcksl,COALESCE(sum(qcckckje),0.0) as qcckckje,COALESCE(sum(qcdbcksl),0.0) as qcdbcksl,COALESCE(sum(qcdbckje),0.0) as qcdbckje FROM (SELECT clnc.cpdm,clnc.ckdm,clnc.qcsl,clnc.qcje,qccgrk.qccgrksl,qccgrk.qccgrkje,qcscrk.qcscrksl,qcscrk.qcscrkje,qcdbrk.qcdbrksl,qcdbrk.qcdbrkje,qcxsck.qcxscksl,qcxsck.qcxsckje,qcckck.qcckcksl,qcckck.qcckckje,qcdbck.qcdbcksl,qcdbck.qcdbckje FROM" & _
                    " (SELECT inv_cpyeb.cpdm,inv_cpyeb.ckdm,sum(qcsl) as qcsl,sum(qcje) as qcje FROM inv_cpyeb WHERE kjnd = ? AND cpdm = ? GROUP by inv_cpyeb.cpdm,inv_cpyeb.ckdm) clnc" & _
                    " Left join (SELECT po_rkd.cpdm,po_rkd.ckdm,sum(po_rkd.sl) as qccgrksl,sum(po_rkd.je) as qccgrkje FROM po_rkd WHERE po_rkd.bdelete = 0 AND po_rkd.rkrq >= ? and po_rkd.rkrq >= ? and po_rkd.rkrq <= ? AND cpdm = ? GROUP BY po_rkd.cpdm,po_rkd.ckdm) qccgrk ON clnc.cpdm = qccgrk.cpdm AND clnc.ckdm = qccgrk.ckdm" & _
                    " Left join (SELECT inv_rkd.cpdm,inv_rkd.ckdm,sum(inv_rkd.sl) as qcscrksl,sum(inv_rkd.je) as qcscrkje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND inv_rkd.rkrq >= ? and inv_rkd.rkrq >= ? and inv_rkd.rkrq <= ? AND cpdm = ? GROUP BY inv_rkd.cpdm,inv_rkd.ckdm) qcscrk ON clnc.cpdm = qcscrk.cpdm AND clnc.ckdm = qcscrk.ckdm" & _
                    " Left join (SELECT inv_dbd.cpdm,inv_dbd.rckdm AS ckdm,sum(inv_dbd.sl) as qcdbrksl,sum(inv_dbd.je) as qcdbrkje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ? AND cpdm = ? GROUP BY inv_dbd.cpdm,inv_dbd.rckdm) qcdbrk ON clnc.cpdm = qcdbrk.cpdm AND clnc.ckdm = qcdbrk.ckdm" & _
                    " Left join (SELECT oe_xsd.cpdm,oe_xsd.ckdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq < ? AND cpdm = ? GROUP BY oe_xsd.cpdm,oe_xsd.ckdm) qcxsck ON clnc.cpdm = qcxsck.cpdm AND clnc.ckdm = qcxsck.ckdm" & _
                    " Left join (SELECT inv_ckd.cpdm,inv_ckd.ckdm,sum(inv_ckd.sl) as qcckcksl,sum(inv_ckd.je) as qcckckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND inv_ckd.ckrq >= ? and inv_ckd.ckrq >= ? and inv_ckd.ckrq <= ? AND cpdm = ? GROUP BY inv_ckd.cpdm,inv_ckd.ckdm) qcckck ON clnc.cpdm = qcckck.cpdm AND clnc.ckdm = qcckck.ckdm" & _
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
                If Not rcDataSet.Tables("clqcye") Is Nothing Then
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
                    ''按平均单价进行更新当月产品调拨单的调拨金额=成本单价*退货数量
                    rcOleDbCommand.CommandText = "UPDATE inv_dbd SET inv_dbd.je = inv_dbd.sl * ?,inv_dbd.dj = ? WHERE inv_dbd.cpdm = ? AND cckdm = ? AND SUBSTR(inv_dbd.djh,5,6) >= ? AND SUBSTR(inv_dbd.djh,5,6) <= ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                    rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("cpxx").Rows(i).Item("cpdm")
                    rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("clqcye").Rows(j).Item("ckdm")
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthBegin.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthEnd.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.ExecuteNonQuery()
                Next
                '分仓库汇总,含调拨单的入库数量与金额，用来计算出库单的出库成本
                rcOleDbCommand.CommandText = "SELECT cpdm,ckdm,COALESCE(sum(qcsl),0.0) as qcsl,COALESCE(sum(qcje),0.0) as qcje,COALESCE(sum(qccgrksl),0.0) as qccgrksl,COALESCE(sum(qccgrkje),0.0) as qccgrkje,COALESCE(sum(qcscrksl),0.0) as qcscrksl,COALESCE(sum(qcscrkje),0.0) as qcscrkje,COALESCE(sum(qcdbrksl),0.0) as qcdbrksl,COALESCE(sum(qcdbrkje),0.0) as qcdbrkje,COALESCE(sum(qcxscksl),0.0) as qcxscksl,COALESCE(sum(qcxsckje),0.0) as qcxsckje,COALESCE(sum(qcckcksl),0.0) as qcckcksl,COALESCE(sum(qcckckje),0.0) as qcckckje,COALESCE(sum(qcdbcksl),0.0) as qcdbcksl,COALESCE(sum(qcdbckje),0.0) as qcdbckje FROM (SELECT clnc.cpdm,clnc.ckdm,clnc.qcsl,clnc.qcje,qccgrk.qccgrksl,qccgrk.qccgrkje,qcscrk.qcscrksl,qcscrk.qcscrkje,qcdbrk.qcdbrksl,qcdbrk.qcdbrkje,qcxsck.qcxscksl,qcxsck.qcxsckje,qcckck.qcckcksl,qcckck.qcckckje,qcdbck.qcdbcksl,qcdbck.qcdbckje FROM" & _
                    " (SELECT inv_cpyeb.cpdm,inv_cpyeb.ckdm,sum(qcsl) as qcsl,sum(qcje) as qcje FROM inv_cpyeb WHERE kjnd = ? AND cpdm = ? GROUP by inv_cpyeb.cpdm,inv_cpyeb.ckdm) clnc" & _
                    " Left join (SELECT po_rkd.cpdm,po_rkd.ckdm,sum(po_rkd.sl) as qccgrksl,sum(po_rkd.je) as qccgrkje FROM po_rkd WHERE po_rkd.bdelete = 0 AND po_rkd.rkrq >= ? and po_rkd.rkrq >= ? and po_rkd.rkrq <= ? AND cpdm = ? GROUP BY po_rkd.cpdm,po_rkd.ckdm) qccgrk ON clnc.cpdm = qccgrk.cpdm AND clnc.ckdm = qccgrk.ckdm" & _
                    " Left join (SELECT inv_rkd.cpdm,inv_rkd.ckdm,sum(inv_rkd.sl) as qcscrksl,sum(inv_rkd.je) as qcscrkje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND inv_rkd.rkrq >= ? and inv_rkd.rkrq >= ? and inv_rkd.rkrq <= ? AND cpdm = ? GROUP BY inv_rkd.cpdm,inv_rkd.ckdm) qcscrk ON clnc.cpdm = qcscrk.cpdm AND clnc.ckdm = qcscrk.ckdm" & _
                    " Left join (SELECT inv_dbd.cpdm,inv_dbd.rckdm AS ckdm,sum(inv_dbd.sl) as qcdbrksl,sum(inv_dbd.je) as qcdbrkje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ? AND cpdm = ? GROUP BY inv_dbd.cpdm,inv_dbd.rckdm) qcdbrk ON clnc.cpdm = qcdbrk.cpdm AND clnc.ckdm = qcdbrk.ckdm" & _
                    " Left join (SELECT oe_xsd.cpdm,oe_xsd.ckdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq < ? AND cpdm = ? GROUP BY oe_xsd.cpdm,oe_xsd.ckdm) qcxsck ON clnc.cpdm = qcxsck.cpdm AND clnc.ckdm = qcxsck.ckdm" & _
                    " Left join (SELECT inv_ckd.cpdm,inv_ckd.ckdm,sum(inv_ckd.sl) as qcckcksl,sum(inv_ckd.je) as qcckckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND inv_ckd.ckrq >= ? and inv_ckd.ckrq >= ? and inv_ckd.ckrq <= ? AND cpdm = ? GROUP BY inv_ckd.cpdm,inv_ckd.ckdm) qcckck ON clnc.cpdm = qcckck.cpdm AND clnc.ckdm = qcckck.ckdm" & _
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
                If Not rcDataSet.Tables("clqcye") Is Nothing Then
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

                    ''按平均单价进行更新当月产品出库单的调拨金额=成本单价*退货数量
                    rcOleDbCommand.CommandText = "UPDATE oe_xsd SET oe_xsd.cbje = oe_xsd.sl * ?,oe_xsd.cbdj = ? WHERE oe_xsd.cpdm = ? AND ckdm = ? AND SUBSTR(oe_xsd.djh,5,6) >= ? AND SUBSTR(oe_xsd.djh,5,6) <= ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                    rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("cpxx").Rows(i).Item("cpdm")
                    rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("clqcye").Rows(j).Item("ckdm")
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthBegin.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthEnd.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.ExecuteNonQuery()
                    ''按平均单价进行更新当月产品出库单的调拨金额=成本单价*退货数量
                    rcOleDbCommand.CommandText = "UPDATE inv_ckd SET inv_ckd.je = inv_ckd.sl * ?,inv_ckd.dj = ? WHERE inv_ckd.cpdm = ? AND ckdm = ? AND SUBSTR(inv_ckd.djh,5,6) >= ? AND SUBSTR(inv_ckd.djh,5,6) <= ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                    rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("cpxx").Rows(i).Item("cpdm")
                    rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("clqcye").Rows(j).Item("ckdm")
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthBegin.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthEnd.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.ExecuteNonQuery()
                Next
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
        Me.Close()
    End Sub

    Private Sub TxtZclcb_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtZclcb.Validating, TxtZrgcb.Validating, TxtZglcb.Validating
        Me.TxtZcb.Text = Val(Me.TxtZclcb.Text) + Val(Me.TxtZrgcb.Text) + Val(Me.TxtZglcb.Text)
    End Sub

    Private Sub DataGridView1_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DataGridView1.RowValidating
        '计算合计数
        Dim dblTotClcb As Double = 0.0
        Dim dblTotRgcb As Double = 0.0
        Dim dblTotGlcb As Double = 0.0
        If dtBom.Rows.Count > 0 Then
            dblTotClcb = dtBom.Compute("Sum(clcb)", "")
            dblTotRgcb = dtBom.Compute("Sum(rgcb)", "")
            dblTotGlcb = dtBom.Compute("Sum(glcb)", "")
        End If
        Me.TxtZclcb.Text = Format(dblTotClcb, g_FormatJe)
        Me.TxtZrgcb.Text = Format(dblTotRgcb, g_FormatJe)
        Me.TxtZglcb.Text = Format(dblTotGlcb, g_FormatJe)
        Me.TxtZcb.Text = Format(dblTotClcb + dblTotRgcb + dblTotGlcb, g_FormatJe)

    End Sub
End Class