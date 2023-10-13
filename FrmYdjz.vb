Imports System.Data.OleDb

Public Class FrmYdjz
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '数据更新传递
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '启用会计期间
    Dim strDwKjqj As String = ""
    '会计期起始日期
    Dim dateKsrq As Date = Now().Date
    '会计期终止日期
    Dim dateZzrq As Date = Now().Date

    Private Sub FrmYdjz_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        strDwKjqj = getInvKjqj(g_Dwrq)
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
        dateKsrq = rcDataset.Tables("rc_yj").Rows(0).Item("invbegin")
        dateZzrq = rcDataset.Tables("rc_yj").Rows(0).Item("invend")
    End Sub

    Private Sub NudYear_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles NudYear.KeyDown
        Select Case e.KeyCode
            Case Keys.Return, Keys.Right
                SendKeys.Send("{TAB}")
            Case Keys.Left
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub NudMonth_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles NudMonth.KeyDown
        Select Case e.KeyCode
            Case Keys.Return, Keys.Right
                SendKeys.Send("{TAB}")
            Case Keys.Left
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        '变量赋值
        Dim dInvBegin As Date = getInvBegin(NudYear.Value, Me.NudMonth.Value)
        Dim dInvEnd As Date ' = getInvEnd(NudYear.Value, Me.NudMonth.Value)
        '(1)本月是否结账
        LblMsg.Text = "正在检查本月是否结账，请稍候……"
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT ny,jzbz FROM rc_yj WHERE ny = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
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
        If rcDataset.Tables("rc_yj").Rows(0).Item("jzbz") = 1 Then
            MsgBox("本月已结账。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        '(2)检查上月是否结账
        LblMsg.Text = "正在检查上月是否结账，请稍候……"
        Dim strDwKjqj As String
        Dim strKjqj As String = NudYear.Value & Trim(Str(NudMonth.Value)).PadLeft(2, "0")
        strDwKjqj = getInvKjqj(g_Dwrq)
        If strDwKjqj > strKjqj Then
            MsgBox("单位启用会计期间之前的会计期间不必结账。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        '当不是启用会计期间时,需要检查上月是否结账
        If strDwKjqj <> strKjqj Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT ny,jzbz FROM rc_yj WHERE ny = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = IIf(NudMonth.Value <> 1, NudYear.Value & (NudMonth.Value - 1).ToString.PadLeft(2, "0"), (NudYear.Value - 1) & "12")
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
            If rcDataset.Tables("rc_yj").Rows(0).Item("jzbz") <> 1 Then
                MsgBox("上月未结账，请先结上月的账。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
        End If
        '(3)检查所有单据是否已经记账
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '(a)付款单
            LblMsg.Text = "正在检查付款单是否已经记账，请稍候……"
            rcOleDbCommand.CommandText = "SELECT 1 FROM ap_fkd WHERE (jzr IS NULL) AND TRUNC(fkrq,'dd') >= ? AND TRUNC(fkrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("fkdml") IsNot Nothing Then
                rcDataset.Tables("fkdml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "fkdml")
            If rcDataset.Tables("fkdml").Rows.Count <> 0 Then
                MsgBox("存在没有记账的付款单，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            '(b)收款单
            LblMsg.Text = "正在检查收款单是否已经记账，请稍候……"
            rcOleDbCommand.CommandText = "SELECT 1 FROM ar_skd WHERE (jzr IS NULL) AND TRUNC(skrq,'dd') >= ? AND TRUNC(skrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("skdml") IsNot Nothing Then
                rcDataset.Tables("skdml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "skdml")
            If rcDataset.Tables("skdml").Rows.Count <> 0 Then
                MsgBox("存在没有记账的收款单，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            '(c)记帐凭证
            LblMsg.Text = "正在检查记帐凭证是否已经记账，请稍候……"
            rcOleDbCommand.CommandText = "SELECT 1 FROM gl_pz WHERE (jzr IS NULL) AND TRUNC(pzrq,'dd') >= ? AND TRUNC(pzrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@pzrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@pzrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("pzml") IsNot Nothing Then
                rcDataset.Tables("pzml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "pzml")
            If rcDataset.Tables("pzml").Rows.Count <> 0 Then
                MsgBox("存在没有记账的记帐凭证，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            '(d)出库单
            LblMsg.Text = "正在检查物料出库单是否已经记账，请稍候……"
            rcOleDbCommand.CommandText = "SELECT 1 FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND (jzr IS NULL) AND TRUNC(ckrq,'dd') >= ? AND TRUNC(ckrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("ckdml") IsNot Nothing Then
                rcDataset.Tables("ckdml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "ckdml")
            If rcDataset.Tables("ckdml").Rows.Count <> 0 Then
                MsgBox("存在没有记账的物料出库单，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            '(e)调拨单
            LblMsg.Text = "正在检查物料调拨单是否已经记账，请稍候……"
            rcOleDbCommand.CommandText = "SELECT 1 FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND (jzr IS NULL) AND TRUNC(dbrq,'dd') >= ? AND TRUNC(dbrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("dbdml") IsNot Nothing Then
                rcDataset.Tables("dbdml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "dbdml")
            If rcDataset.Tables("dbdml").Rows.Count <> 0 Then
                MsgBox("存在没有记账的物料调拨单，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            '(f)盘存单
            LblMsg.Text = "正在检查物料盘存单是否已经记账，请稍候……"
            rcOleDbCommand.CommandText = "SELECT 1 FROM inv_pc WHERE (jzr IS NULL) AND TRUNC(pcrq,'dd') >= ? AND TRUNC(pcrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@pcrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@pcrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("pcml") IsNot Nothing Then
                rcDataset.Tables("pcml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "pcml")
            If rcDataset.Tables("pcml").Rows.Count <> 0 Then
                MsgBox("存在没有记账的物料盘存单，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            '(g)产品入库单
            LblMsg.Text = "正在检查产品入库单是否已经记账，请稍候……"
            rcOleDbCommand.CommandText = "SELECT 1 FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND (jzr IS NULL) AND TRUNC(rkrq,'dd') >= ? AND TRUNC(rkrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rkdml") IsNot Nothing Then
                rcDataset.Tables("rkdml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rkdml")
            If rcDataset.Tables("rkdml").Rows.Count <> 0 Then
                MsgBox("存在没有记账的产品入库单，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            '(h)产品销售订单
            LblMsg.Text = "正在检查产品销售订单是否已经记账，请稍候……"
            rcOleDbCommand.CommandText = "SELECT 1 FROM oe_dd WHERE (jzr IS NULL) AND TRUNC(qdrq,'dd') >= ? AND TRUNC(qdrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@qdrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@qdrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("ddml") IsNot Nothing Then
                rcDataset.Tables("ddml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "ddml")
            If rcDataset.Tables("ddml").Rows.Count <> 0 Then
                MsgBox("存在没有记账的产品销售订单，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            '(i)产品送货单
            LblMsg.Text = "正在检查产品送货单是否已经记账，请稍候……"
            rcOleDbCommand.CommandText = "SELECT 1 FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND (jzr IS NULL) AND TRUNC(xsrq,'dd') >= ? AND TRUNC(xsrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("xsdml") IsNot Nothing Then
                rcDataset.Tables("xsdml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "xsdml")
            If rcDataset.Tables("xsdml").Rows.Count <> 0 Then
                MsgBox("存在没有记账的产品送货单，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            '(j)销售发票
            LblMsg.Text = "正在检查销售发票是否已经记账，请稍候……"
            rcOleDbCommand.CommandText = "SELECT 1 FROM oe_fp WHERE oe_fp.bdelete = 0 AND (jzr IS NULL) AND TRUNC(fprq,'dd') >= ? AND TRUNC(fprq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("fpml") IsNot Nothing Then
                rcDataset.Tables("fpml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "fpml")
            If rcDataset.Tables("fpml").Rows.Count <> 0 Then
                MsgBox("存在没有记账的产品销售发票，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            ''(k)产品生产订单
            'LblMsg.Text = "正在检查产品生产订单是否已经记账，请稍候……"
            'rcOleDbCommand.CommandText = "SELECT 1 FROM pm_dd WHERE (jzr IS NULL) AND TRUNC(qdrq,'dd') >= ? AND TRUNC(qdrq,'dd') <= ?"
            'rcOleDbCommand.Parameters.Clear()
            'rcOleDbCommand.Parameters.Add("@qdrq", OleDbType.Date, 8).Value = dateKsrq.Date
            'rcOleDbCommand.Parameters.Add("@qdrq", OleDbType.Date, 8).Value = dateZzrq.Date
            'rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            'If rcDataset.Tables("ddml") IsNot Nothing Then
            '    rcDataset.Tables("ddml").Clear()
            'End If
            'rcOleDbDataAdpt.Fill(rcDataset, "ddml")
            'If rcDataset.Tables("ddml").Rows.Count <> 0 Then
            '    MsgBox("存在没有记账的产品生产订单，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            '    Return
            'End If
            '(l)物料采购单
            LblMsg.Text = "正在检查物料采购订单是否已经记账，请稍候……"
            rcOleDbCommand.CommandText = "SELECT 1 FROM po_cgd WHERE (jzr IS NULL) AND TRUNC(cgrq,'dd') >= ? AND TRUNC(cgrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cgrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@cgrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("cgdml") IsNot Nothing Then
                rcDataset.Tables("cgdml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "cgdml")
            If rcDataset.Tables("cgdml").Rows.Count <> 0 Then
                MsgBox("存在没有记账的物料采购订单，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            '(m)物料收货单
            LblMsg.Text = "正在检查物料收货单是否已经记账，请稍候……"
            rcOleDbCommand.CommandText = "SELECT 1 FROM po_rkd WHERE po_rkd.bdelete = 0 AND (jzr IS NULL) AND TRUNC(rkrq,'dd') >= ? AND TRUNC(rkrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rkdml") IsNot Nothing Then
                rcDataset.Tables("rkdml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rkdml")
            If rcDataset.Tables("rkdml").Rows.Count <> 0 Then
                MsgBox("存在没有记账的物料收货单，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            '(o)物料入库单
            LblMsg.Text = "正在检查物料入库单（采购发票）是否已经记账，请稍候……"
            rcOleDbCommand.CommandText = "SELECT 1 FROM po_fp WHERE po_fp.bdelete = 0 AND (jzr IS NULL) AND TRUNC(fprq,'dd') >= ? AND TRUNC(fprq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("fpml") IsNot Nothing Then
                rcDataset.Tables("fpml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "fpml")
            If rcDataset.Tables("fpml").Rows.Count <> 0 Then
                MsgBox("存在没有记账的物料入库（采购发票），请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try

        '(4)是不是结12月份的账
        If Me.NudMonth.Value = 12 Then
            Dim i As Integer
            Dim j As Integer
            dInvBegin = getInvBegin(NudYear.Value, 1)
            dInvEnd = getInvEnd(NudYear.Value, 12)
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                '(5)结账
                '(A)重新汇总总帐
                LblMsg.Text = "正在重新汇总总帐，请稍候……"
                rcOleDbCommand.CommandType = CommandType.StoredProcedure
                rcOleDbCommand.CommandText = "USP3_REDO_CPYEHZ"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                rcOleDbCommand.Parameters.Add("@dwrq", OleDbType.Date, 8).Value = g_Dwrq
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                rcOleDbCommand.CommandType = CommandType.StoredProcedure
                rcOleDbCommand.CommandText = "USP3_REDO_CSYEHZ"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                rcOleDbCommand.Parameters.Add("@dwrq", OleDbType.Date, 8).Value = g_Dwrq
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                rcOleDbCommand.CommandType = CommandType.StoredProcedure
                rcOleDbCommand.CommandText = "USP3_REDO_KHYEHZ"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                rcOleDbCommand.Parameters.Add("@dwrq", OleDbType.Date, 8).Value = g_Dwrq
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                '(B)取消下一年度中已记账的单据
                LblMsg.Text = "正在取消下一年度中已记账的单据，请稍候……"
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "UPDATE ap_fkd SET jzr = '' WHERE SUBSTR(DJH,5,4) = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                rcOleDbCommand.CommandText = "UPDATE ar_skd SET jzr = '' WHERE SUBSTR(DJH,5,4) = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                rcOleDbCommand.CommandText = "UPDATE gl_pz SET jzr = '' WHERE SUBSTR(DJH,5,4) = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                rcOleDbCommand.CommandText = "UPDATE inv_ckd SET jzr = '' WHERE SUBSTR(DJH,5,4) = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                rcOleDbCommand.CommandText = "UPDATE inv_dbd SET jzr = '' WHERE SUBSTR(DJH,5,4) = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                rcOleDbCommand.CommandText = "UPDATE inv_pc SET jzr = '' WHERE pcrq > ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@pcrq", OleDbType.Date, 8).Value = dInvEnd
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                rcOleDbCommand.CommandText = "UPDATE inv_rkd SET jzr = '' WHERE inv_rkd.bdelete = 0 AND SUBSTR(DJH,5,4) = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                rcOleDbCommand.CommandText = "UPDATE oe_dd SET jzr = '' WHERE SUBSTR(DJH,5,4) = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                rcOleDbCommand.CommandText = "UPDATE oe_xsd SET jzr = '' WHERE SUBSTR(DJH,5,4) = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                'rcOleDbCommand.CommandText = "UPDATE pm_dd SET jzr = '' WHERE SUBSTR(DJH,5,4) = ?"
                'rcOleDbCommand.Parameters.Clear()
                'rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                'rcOleDbCommand.ExecuteNonQuery()
                'Application.DoEvents()
                rcOleDbCommand.CommandText = "UPDATE po_cgd SET jzr = '' WHERE SUBSTR(DJH,5,4) = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                rcOleDbCommand.CommandText = "UPDATE po_rkd SET jzr = '' WHERE SUBSTR(DJH,5,4) = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                '(C)删除下一年度的inv_cpyeb中的数据物料编码、客户编码、仓库编码
                LblMsg.Text = "正在删除下一年度的inv_cpyeb中的数据，请稍候……"
                rcOleDbCommand.CommandText = "DELETE FROM inv_cpyeb WHERE kjnd = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                LblMsg.Text = "正在写入下一年度的inv_cpyeb中的数据，请稍候……"
                '(D)插入inv_cpyeb的数据
                rcOleDbCommand.CommandText = "INSERT INTO inv_cpyeb (kjnd,cpdm,ckdm,qcsl,qcfzsl,qcje,idsl,idje) SELECT ? AS kjnd,cpdm,ckdm,COALESCE(qcsl,0.0)+COALESCE(idsl,0.0) AS qcsl,COALESCE(qcfzsl,0.0)+COALESCE(idfzsl,0.0) AS qcfzsl,COALESCE(qcje,0.0)+COALESCE(idje,0.0) AS qcje,0 AS idsl,0 AS idje FROM inv_cpyeb WHERE kjnd = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd1", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.Parameters.Add("@kjnd2", OleDbType.VarChar, 4).Value = NudYear.Value
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                '(E)删除下一年度的ap_csyeb中的数据物料编码、客户编码、仓库编码
                LblMsg.Text = "正在删除下一年度的ap_csyeb中的数据，请稍候……"
                rcOleDbCommand.CommandText = "DELETE FROM ap_csyeb WHERE kjnd = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                LblMsg.Text = "正在写入下一年度的ap_csyeb中的数据，请稍候……"
                '(F)插入ap_csyeb的数据
                rcOleDbCommand.CommandText = "INSERT INTO ap_csyeb (kjnd,csdm,qcfpje,idfpje) SELECT ? AS kjnd,csdm,COALESCE(qcfpje,0.0)+COALESCE(idfpje,0.0) AS qcfpje,0 AS idfpje FROM ap_csyeb WHERE kjnd = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd1", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.Parameters.Add("@kjnd2", OleDbType.VarChar, 4).Value = NudYear.Value
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                '(G)删除下一年度的ar_khyeb中的数据物料编码、客户编码、仓库编码
                LblMsg.Text = "正在删除下一年度的ar_khyeb中的数据，请稍候……"
                rcOleDbCommand.CommandText = "DELETE FROM ar_khyeb WHERE kjnd = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                LblMsg.Text = "正在写入下一年度的ar_khyeb中的数据，请稍候……"
                '(H)插入ar_khyeb的数据
                rcOleDbCommand.CommandText = "INSERT INTO ar_khyeb (kjnd,khdm,qcfpje,idfpje) SELECT ? AS kjnd,khdm,COALESCE(qcfpje,0.0)+COALESCE(idfpje,0.0) AS qcfpje,0 AS idfpje FROM ar_khyeb WHERE kjnd = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd1", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.Parameters.Add("@kjnd2", OleDbType.VarChar, 4).Value = NudYear.Value
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                '(I)生成单据类型
                LblMsg.Text = "正在生成单据类型，请稍候……"
                '取未添加的类型
                rcOleDbCommand.CommandText = "SELECT pzlxdm,lxgs FROM rc_lx WHERE kjnd = ? AND NOT EXISTS (SELECT 1 FROM (SELECT pzlxdm FROM rc_lx WHERE kjnd = ?) llll WHERE llll.pzlxdm = rc_lx.pzlxdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = NudYear.Value
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_lx") IsNot Nothing Then
                    rcDataset.Tables("rc_lx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_lx")
                '生成序列
                For i = 0 To rcDataset.Tables("rc_lx").Rows.Count - 1
                    For j = 1 To 12
                        rcOleDbCommand.CommandText = "CREATE SEQUENCE " & Trim(rcDataset.Tables("rc_lx").Rows(i).Item("pzlxdm")) & (Me.NudYear.Value + 1).ToString & j.ToString.PadLeft(2, "0") & " INCREMENT BY 1 START WITH 1 MAXVALUE 99999 MINVALUE 1 NOCYCLE NOCACHE NOORDER"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.ExecuteNonQuery()
                    Next
                Next
                Application.DoEvents()
                rcOleDbCommand.CommandText = "INSERT INTO rc_lx (kjnd,pzlxdm,pzlxjc,pzlxmc,lxgs,pzno01,pzno02,pzno03,pzno04,pzno05,pzno06,pzno07,pzno08,pzno09,pzno10,pzno11,pzno12,pzno13,bfushu) SELECT '" & NudYear.Value + 1 & "' as kjnd,pzlxdm,pzlxjc,pzlxmc,lxgs,0 as pzno01,0 as pzno02,0 as pzno03,0 as pzno04,0 as pzno05,0 as pzno06,0 as pzno07,0 as pzno08,0 as pzno09,0 as pzno10,0 as pzno11,0 as pzno12,0 AS pzno13,bfushu FROM rc_lx WHERE kjnd = ? AND NOT EXISTS (SELECT 1 FROM (SELECT pzlxdm FROM rc_lx WHERE kjnd = ?) llll WHERE llll.pzlxdm = rc_lx.pzlxdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = NudYear.Value
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                '(J)生成会计期间结账标志
                LblMsg.Text = "正在生成会计期间，请稍候……"
                rcOleDbCommand.CommandText = "INSERT INTO rc_yj (ny,jzbz,glbegin,glend,invbegin,invend,pobegin,poend) SELECT ? || SUBSTR(ny,5,2) AS ny,0 AS jzbz,add_months(glbegin,12),add_months(glend,12),add_months(invbegin,12),add_months(invend,12),add_months(pobegin,12),add_months(poend,12) FROM rc_yj WHERE SUBSTR(ny,1,4) = ? AND NOT EXISTS (SELECT 1 FROM (SELECT ny FROM rc_yj WHERE SUBSTR(ny,1,4) = ?) llll WHERE SUBSTR(llll.ny,5,2) = SUBSTR(rc_yj.ny,5,2))"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 4).Value = Me.NudYear.Value + 1
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 4).Value = Me.NudYear.Value + 1
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                '(K)
                LblMsg.Text = "正在重新下一年汇总总帐，请稍候……"
                rcOleDbCommand.CommandType = CommandType.StoredProcedure
                rcOleDbCommand.CommandText = "USP3_REDO_CPYEHZ"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value + 1
                rcOleDbCommand.Parameters.Add("@dwrq", OleDbType.Date, 8).Value = g_Dwrq
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                rcOleDbCommand.CommandType = CommandType.StoredProcedure
                rcOleDbCommand.CommandText = "USP3_REDO_CSYEHZ"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value + 1
                rcOleDbCommand.Parameters.Add("@dwrq", OleDbType.Date, 8).Value = g_Dwrq
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                rcOleDbCommand.CommandType = CommandType.StoredProcedure
                rcOleDbCommand.CommandText = "USP3_REDO_KHYEHZ"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value + 1
                rcOleDbCommand.Parameters.Add("@dwrq", OleDbType.Date, 8).Value = g_Dwrq
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        End If
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            '(5)结账
            LblMsg.Text = "正在进行月底结账，请稍候……"
            rcOleDbCommand.CommandText = "UPDATE rc_yj SET jzbz = 1 WHERE ny = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        LblMsg.Text = "结账完成。"
        MsgBox("本月结账已完成。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
        Me.Close()
    End Sub

#Region "取消结帐"

    Private Sub BtnFjz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFjz.Click
        '反结帐
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT MAX(ny) AS ny FROM rc_yj WHERE jzbz = '1'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_yj") IsNot Nothing Then
                rcDataset.Tables("rc_yj").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_yj")
        Catch ex As Exception
            Try
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_yj").Rows.Count > 0 Then
            If MsgBox("您是否要取消结账" & rcDataset.Tables("rc_yj").Rows(0).Item("ny") & "吗？", MsgBoxStyle.YesNo, "提示信息") = MsgBoxResult.Yes Then
                Try
                    rcOleDbConn.Open()
                    rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.Transaction = rcOleDbTrans
                    rcOleDbCommand.CommandType = CommandType.Text
                    rcOleDbCommand.CommandText = "UPDATE rc_yj SET jzbz = '0' WHERE ny = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = rcDataset.Tables("rc_yj").Rows(0).Item("ny")
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbTrans.Commit()
                Catch ex As Exception
                    Try
                        rcOleDbTrans.Rollback()
                        MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                    Catch ey As OleDbException
                        MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                    End Try
                    Return
                Finally
                    rcOleDbConn.Close()
                End Try
                MsgBox("取消结账完成。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Me.Close()
            End If
        End If
    End Sub

#End Region
End Class