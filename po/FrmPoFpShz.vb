Imports System.Math
Imports System.Data.OleDb

Public Class FrmPoFpShz
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    Dim rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    ''建立Datatable '我们要利用该datatable进行金额计算
    'Dim dtFp As New DataTable("rc_fpnr")
    '数据绑定
    Dim rcBmb As BindingManagerBase
    '打印文档
    Dim rcRps As RPS.Document = Nothing
    '合计变量
    Dim dblTotSl As Double = 0.0
    Dim dblTotFzsl As Double = 0.0
    Dim dblTotJe As Double = 0.0
    Dim dblTotSe As Double = 0.0

#Region "窗体初始化"

    Public Property ParaDataSet() As DataSet
        Get
            ParaDataSet = rcDataSet
        End Get
        Set(ByVal Value As DataSet)
            rcDataSet = Value
        End Set
    End Property

    Private Sub FrmPoFpShz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '设置DataGridView
        Me.rcDataGridView.AutoGenerateColumns = False
        Me.rcDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColMjsl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColMjsl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColFzsl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColFzsl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColDj").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColDj").DefaultCellStyle.Format = g_FormatDj
        Me.rcDataGridView.Columns("ColHsdj").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColHsdj").DefaultCellStyle.Format = g_FormatDj
        Me.rcDataGridView.Columns("ColJe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColJe").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColShlv").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColShlv").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColSe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColSe").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColJese").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColJese").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColRkdDj").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColRkdDj").DefaultCellStyle.Format = g_FormatDj
        Me.rcDataGridView.Columns("ColRkdHsdj").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColRkdHsdj").DefaultCellStyle.Format = g_FormatDj
        Me.rcDataGridView.Columns("ColRkdJe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColRkdJe").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColRkdShlv").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColRkdShlv").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColRkdSe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColRkdSe").DefaultCellStyle.Format = g_FormatJe
        rcBmb = Me.BindingContext(rcDataSet, "fpml")
        If rcDataSet.Tables("fpml").Rows.Count > 0 Then
            ShowFp(rcDataSet.Tables("fpml").Rows(0).Item("djh"))
        End If
    End Sub

#End Region

#Region "显示入库单"

    Private Sub ShowFp(ByVal fpDjh As String)
        '判断fpDjh

        '取po_fp数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT po_fp.djh,po_fp.fprq,po_fp.bdelete,po_fp.csdm,po_fp.csmc,po_fp.yspz,po_fp.zydm,po_fp.zymc,po_fp.srr,po_fp.shr FROM po_fp WHERE (djh = ? )"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = fpDjh
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_fpml") IsNot Nothing Then
                rcDataSet.Tables("rc_fpml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_fpml")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '赋值
        Me.TxtDjh.Text = rcDataSet.Tables("rc_fpml").Rows(0).Item("djh")
        Me.DtpFprq.Value = rcDataSet.Tables("rc_fpml").Rows(0).Item("fprq")
        Me.LblBdelete.Text = IIf(rcDataSet.Tables("rc_fpml").Rows(0).Item("bdelete"), "作废", "")
        Me.TxtZydm.Text = Trim(rcDataSet.Tables("rc_fpml").Rows(0).Item("zydm"))
        Me.LblZymc.Text = rcDataSet.Tables("rc_fpml").Rows(0).Item("zymc")
        If rcDataSet.Tables("rc_fpml").Rows(0).Item("csdm").GetType.ToString <> "System.DBNull" Then
            Me.TxtCsdm.Text = Trim(rcDataSet.Tables("rc_fpml").Rows(0).Item("csdm"))
        Else
            Me.TxtCsdm.Text = ""
        End If
        If rcDataSet.Tables("rc_fpml").Rows(0).Item("csmc").GetType.ToString <> "System.DBNull" Then
            Me.LblCsmc.Text = rcDataSet.Tables("rc_fpml").Rows(0).Item("csmc")
        Else
            Me.LblCsmc.Text = ""
        End If
        If rcDataSet.Tables("rc_fpml").Rows(0).Item("yspz").GetType.ToString <> "System.DBNull" Then
            Me.TxtYspz.Text = rcDataSet.Tables("rc_fpml").Rows(0).Item("yspz")
        Else
            Me.TxtYspz.Text = ""
        End If
        LblSrr.Text = "输入：" + rcDataSet.Tables("rc_fpml").Rows(0).Item("srr")
        LblShr.Text = "审核：" + rcDataSet.Tables("rc_fpml").Rows(0).Item("shr")
        '取po_fp数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT po_fp.cpdm,rc_cpxx.oldcpdm,rc_cpxx.cpmc,po_fp.sgddh,po_fp.sl,rc_cpxx.dw,po_fp.mjsl,po_fp.fzsl,rc_cpxx.fzdw,po_fp.dj,po_fp.hsdj,po_fp.je,po_fp.shlv,po_fp.se,(po_fp.je + po_fp.se) AS jese,po_fp.fpmemo,po_fp.cgddjh,po_fp.cgdxh,po_fp.rkddjh,po_fp.rkdxh,po_fp.rkddj,po_fp.rkdhsdj,po_fp.rkdje,po_fp.rkdshlv,po_fp.rkdse FROM po_fp,rc_cpxx WHERE po_fp.cpdm = rc_cpxx.cpdm AND (po_fp.djh = ?) ORDER BY po_fp.xh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = fpDjh
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_fpnr") IsNot Nothing Then
                rcDataSet.Tables("rc_fpnr").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_fpnr")
            rcDataGridView.DataSource = rcDataSet.Tables("rc_fpnr")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        SumSlJe()
    End Sub

#End Region

#Region "计算合计数"

    Private Sub SumSlJe()
        '计算合计数
        dblTotSl = 0.0
        dblTotFzsl = 0.0
        dblTotJe = 0.0
        dblTotSe = 0.0
        If rcDataSet.Tables("rc_fpnr").Rows.Count > 0 Then
            dblTotSl = rcDataSet.Tables("rc_fpnr").Compute("Sum(sl)", "")
            dblTotFzsl = rcDataSet.Tables("rc_fpnr").Compute("Sum(fzsl)", "")
            dblTotJe = rcDataSet.Tables("rc_fpnr").Compute("Sum(je)", "")
            dblTotSe = rcDataSet.Tables("rc_fpnr").Compute("Sum(se)", "")
        End If
        Me.LblSl.Text = "数量合计：" + Format(dblTotSl, g_FormatSl)
        Me.LblFzsl.Text = "辅数量合计：" + Format(dblTotFzsl, g_FormatSl)
        Me.LblJe.Text = "金额合计：" + Format(dblTotJe, g_FormatJe)
        Me.LblSe.Text = "税额合计：" + Format(dblTotSe, g_FormatJe)
        Me.LblJese.Text = "价税合计：" + Format(dblTotJe + dblTotSe, g_FormatJe)
    End Sub

#End Region

#Region "审核"

    Private Sub BtnSh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSh.Click, MnuiSh.Click
        ShEvent(rcBmb.Current("djh"))
        ShowFp(rcBmb.Current("djh"))
    End Sub

    Private Sub ShEvent(ByVal fpDjh As String)
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "UPDATE po_fp SET shr = ?,shrq = SYSDATE WHERE djh = ? AND shr IS NULL"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@shr", OleDbType.VarChar, 30).Value = g_User_DspName
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = fpDjh
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
        ShowFp(Me.TxtDjh.Text)
    End Sub

#End Region

#Region "消审"

    Private Sub BtnXs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXs.Click, MnuiXs.Click
        XsEvent(rcBmb.Current("djh"))
        ShowFp(rcBmb.Current("djh"))
    End Sub

    Private Sub XsEvent(ByVal fpDjh As String)
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "UPDATE po_fp SET shr = ?,shrq = SYSDATE WHERE NOT EXISTS (SELECT 1 FROM po_fp a WHERE a.fkje <> 0 AND a.djh = ?) AND djh = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@shr", OleDbType.VarChar, 30).Value = ""
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = fpDjh
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = fpDjh
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
        ShowFp(Me.TxtDjh.Text)
    End Sub

#End Region

#Region "全审"

    Private Sub BtnQs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQs.Click, MnuiQs.Click
        If MsgBox("是否全审所有选择的单据？", MsgBoxStyle.YesNo + MsgBoxStyle.Information + MsgBoxStyle.DefaultButton2, "提示信息") <> MsgBoxResult.Yes Then
            Return
        End If
        QsEvent()
        ShowFp(rcBmb.Current("djh"))
    End Sub

    Private Sub QsEvent()
        Dim i As Integer
        For i = 0 To rcDataSet.Tables("fpml").Rows.Count - 1
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "UPDATE po_fp SET shr = ?,shrq = SYSDATE WHERE djh = ? AND shr IS NULL"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@shr", OleDbType.VarChar, 30).Value = g_User_DspName
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Trim(rcDataSet.Tables("fpml").Rows(i).Item("djh"))
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
        Next
        ShowFp(Me.TxtDjh.Text)
    End Sub

#End Region

#Region "全消"

    Private Sub BtnQx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQx.Click, MnuiQx.Click
        QxEvent()
        ShowFp(rcBmb.Current("djh"))
    End Sub

    Private Sub QxEvent()
        Dim i As Integer
        For i = 0 To rcDataSet.Tables("fpml").Rows.Count - 1
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "UPDATE po_fp SET shr = ?,shrq = SYSDATE WHERE NOT EXISTS (SELECT 1 FROM po_fp a WHERE a.fkje <> 0 AND a.djh = ?) AND djh = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@shr", OleDbType.VarChar, 30).Value = ""
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Trim(rcDataSet.Tables("fpml").Rows(i).Item("djh"))
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Trim(rcDataSet.Tables("fpml").Rows(i).Item("djh"))
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
        Next
        ShowFp(Me.TxtDjh.Text)
    End Sub

#End Region

#Region "上张"

    Private Sub BtnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevious.Click, MnuiPrevious.Click
        If rcBmb.Count > 0 Then
            If rcBmb.Position <> 0 Then
                rcBmb.Position -= 1
            End If
            ShowFp(rcBmb.Current("djh"))
        End If
    End Sub

#End Region

#Region "下张"

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click, MnuiNext.Click
        If rcBmb.Count > 0 Then
            If rcBmb.Position <> rcBmb.Count Then
                rcBmb.Position += 1
            End If
            ShowFp(rcBmb.Current("djh"))
        End If
    End Sub

#End Region

#Region "准备打印数据事件"

    Private Sub PreparePrintData()
        If rcRps Is Nothing Then
            rcRps = New RPS.Document
        End If
        Dim rft As String = CurDir() + "\reports\fpbz.rft"
        rcRps.LoadTemplate(rft)
        '取RPS数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps WHERE rpsid = 'FPBZ'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_rps") IsNot Nothing Then
                rcDataSet.Tables("rc_rps").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_rps")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("rc_rps").Rows.Count > 0 Then
            '设定值
            rcRps.Scale = rcDataSet.Tables("rc_rps").Rows(0).Item("scale")
            rcRps.Orientation = rcDataSet.Tables("rc_rps").Rows(0).Item("orientation")
            rcRps.PaperWidth = rcDataSet.Tables("rc_rps").Rows(0).Item("paperwidth")
            rcRps.PaperHeight = rcDataSet.Tables("rc_rps").Rows(0).Item("paperheight")
            rcRps.PrinterLeft = rcDataSet.Tables("rc_rps").Rows(0).Item("printerleft")
            rcRps.PrinterTop = rcDataSet.Tables("rc_rps").Rows(0).Item("printertop")
        Else
            '默认值
            rcRps.Scale = 100
            rcRps.Orientation = 1
        End If

        '套打
        'rcRps.PaperType = 1
        rcRps.Text(-1, 1) = g_PrnDwmc & "物料入库单"
        rcRps.Text(-1, 2) = "单据号：" & Trim(Me.TxtDjh.Text) & "  %p/%t"
        rcRps.Text(-1, 3) = "日期：" & Me.DtpFprq.Value.ToLongDateString
        rcRps.Text(-1, 4) = "供应商：(" & Trim(Me.TxtCsdm.Text) & ")" & Trim(LblCsmc.Text)
        rcRps.Text(-1, 5) = "经办人：(" & Trim(Me.TxtZydm.Text) & ")" & Trim(LblZymc.Text)
        Dim i As Integer
        Dim j As Integer
        Dim intPage As Integer
        Dim dblTotalSl As Double = 0.0
        Dim dblTotalJe As Double = 0.0
        Dim dblTotalSe As Double = 0.0
        For intPage = 1 To System.Math.Ceiling(rcDataSet.Tables("rc_fpnr").Rows.Count / rcRps.LinesPerPage.ToString)
            For i = (intPage - 1) * rcRps.LinesPerPage.ToString To System.Math.Min(intPage * rcRps.LinesPerPage.ToString - 1, rcDataSet.Tables("rc_fpnr").Rows.Count - 1)
                If rcDataSet.Tables("rc_fpnr").Rows(i).RowState <> 8 Then
                    If rcDataset.Tables("rc_fpnr").Rows(i).Item("oldcpdm").GetType.ToString <> "System.DBNull" Then
                        rcRps.Text(j + 1, 1) = Trim(rcDataset.Tables("rc_fpnr").Rows(i).Item("oldcpdm"))
                    Else
                        If rcDataset.Tables("rc_fpnr").Rows(i).Item("cpdm").GetType.ToString <> "System.DBNull" Then
                            rcRps.Text(j + 1, 1) = Trim(rcDataset.Tables("rc_fpnr").Rows(i).Item("cpdm"))
                        End If
                    End If
                    If Not rcDataset.Tables("rc_fpnr").Rows(i).Item("cpmc").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 2) = Trim(rcDataset.Tables("rc_fpnr").Rows(i).Item("cpmc"))
                        If Not rcDataset.Tables("rc_fpnr").Rows(i).Item("sgddh").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 2) = Trim(rcDataset.Tables("rc_fpnr").Rows(i).Item("cpmc")) + " " + Trim(rcDataset.Tables("rc_fpnr").Rows(i).Item("sgddh"))
                        End If
                    End If
                    If Not rcDataSet.Tables("rc_fpnr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 3) = Trim(rcDataSet.Tables("rc_fpnr").Rows(i).Item("dw"))
                    End If
                    If Not rcDataSet.Tables("rc_fpnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 4) = Format(rcDataSet.Tables("rc_fpnr").Rows(i).Item("sl"), g_FormatSl)
                        dblTotalSl += rcDataSet.Tables("rc_fpnr").Rows(i).Item("sl")
                    End If
                    If Not rcDataSet.Tables("rc_fpnr").Rows(i).Item("dj").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 5) = Format(rcDataSet.Tables("rc_fpnr").Rows(i).Item("dj"), g_FormatDj)
                    End If
                    If Not rcDataSet.Tables("rc_fpnr").Rows(i).Item("je").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 6) = Format(rcDataSet.Tables("rc_fpnr").Rows(i).Item("je"), g_FormatJe)
                        dblTotalJe += rcDataSet.Tables("rc_fpnr").Rows(i).Item("je")
                    End If
                    If Not rcDataSet.Tables("rc_fpnr").Rows(i).Item("shlv").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 7) = Format(rcDataSet.Tables("rc_fpnr").Rows(i).Item("shlv") / 100, "0%")
                    End If
                    If Not rcDataSet.Tables("rc_fpnr").Rows(i).Item("se").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 8) = Format(rcDataSet.Tables("rc_fpnr").Rows(i).Item("se"), g_FormatJe)
                        dblTotalSe += rcDataSet.Tables("rc_fpnr").Rows(i).Item("se")
                    End If
                    If Not rcDataset.Tables("rc_fpnr").Rows(i).Item("fpmemo").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 9) = Trim(rcDataset.Tables("rc_fpnr").Rows(i).Item("fpmemo"))
                    End If
                    j += 1
                End If
            Next

            Dim m As New models.ChineseNum With {
                .InputString = dblTotalJe + dblTotalSe
            }
            rcRps.PerPageText(intPage, 6) = IIf(intPage = Math.Ceiling(rcDataSet.Tables("rc_fpnr").Rows.Count / rcRps.LinesPerPage.ToString), "合计", "小计")
            rcRps.PerPageText(intPage, 7) = m.OutString & "   (小写)" & Format(dblTotalJe + dblTotalSe, g_FormatJe) '大写
            rcRps.PerPageText(intPage, 8) = Format(dblTotalJe, g_FormatJe)
            rcRps.PerPageText(intPage, 10) = Format(dblTotalSe, g_FormatJe)
            'rcRps.PerPageText(intPage, 11) = Format(dblTotalJe + dblTotalSe, g_FormatJe)
        Next
        If Decimal.op_Modulus(rcDataSet.Tables("rc_fpnr").Rows.Count, rcRps.LinesPerPage.ToString) <> 0 Then
            For i = Decimal.op_Modulus(rcDataSet.Tables("rc_fpnr").Rows.Count, rcRps.LinesPerPage.ToString) + 1 To rcRps.LinesPerPage.ToString
                rcRps.Text(j + 1, 1) = ""
                j += 1
            Next
        End If
        rcRps.Text(-1, 13) = "制单：" & g_User_DspName
    End Sub

#End Region

#Region "打印设置事件"

    Private Sub PageSetupEvent()
        Dim rcFrmPageSetup As New models.FrmPageSetup
        With rcFrmPageSetup
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = "FPBZ"
            .paraRpsName = "物料入库单标准格式"
            .ShowDialog()
        End With
    End Sub

    Private Sub MnuiPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPageSetup.Click
        PageSetupEvent()
    End Sub

#End Region

#Region "打印事件"

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        PrintEvent()
    End Sub

    Private Sub MnuiPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrint.Click
        PrintEvent()
    End Sub

    Private Sub PrintEvent()
        If g_Demo = 1 Then
            MsgBox("对不起，试用软件不能打印。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        PreparePrintData()
        Dim rcFrmPrint As New models.FrmPrint
        With rcFrmPrint
            .paraRps = rcRps
            .ShowDialog()
        End With
    End Sub

#End Region

#Region "打印预览事件"

    Private Sub PrintViewEvent()
        PreparePrintData()
        rcRps.Preview()
    End Sub

    Private Sub MnuiPrintView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrintView.Click
        PrintViewEvent()
    End Sub

#End Region

#Region "退出"

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click, MnuiExit.Click
        ExitEvent()
    End Sub

    Private Sub ExitEvent()
        Me.Close()
    End Sub

#End Region
End Class