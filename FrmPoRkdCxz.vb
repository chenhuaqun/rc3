Imports System.Math
Imports System.Data.OleDb

Public Class FrmPoRkdCxz
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    Dim rcDataset As New DataSet
    ''表示要在数据源执行的 SQL 事务
    'Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    ''建立Datatable '我们要利用该datatable进行金额计算
    'Dim dtRkd As New DataTable("rc_rkdnr")
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

    Private Sub FrmPoRkdSrz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Me.rcDataGridView.Columns("ColCksl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColCksl").DefaultCellStyle.Format = g_FormatDj
        Me.rcDataGridView.Columns("ColCkje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColCkje").DefaultCellStyle.Format = g_FormatJe
        rcBmb = Me.BindingContext(rcDataSet, "rkdml")
        If rcDataSet.Tables("rkdml").Rows.Count > 0 Then
            ShowRkd(rcDataSet.Tables("rkdml").Rows(0).Item("djh"))
        End If
    End Sub

#End Region

#Region "显示入库单"

    Private Sub ShowRkd(ByVal rkDjh As String)
        '判断rkDjh

        '取po_rkd数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT po_rkd.djh,po_rkd.rkrq,po_rkd.bdelete,po_rkd.csdm,po_rkd.csmc,po_rkd.yspz,po_rkd.zydm,po_rkd.zymc,po_rkd.ckdm,po_rkd.ckmc,po_rkd.srr,po_rkd.shr FROM po_rkd WHERE (djh = ? )"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rkDjh
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_rkdml") IsNot Nothing Then
                rcDataSet.Tables("rc_rkdml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_rkdml")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '赋值
        Me.TxtDjh.Text = rcDataSet.Tables("rc_rkdml").Rows(0).Item("djh")
        Me.DtpRkrq.Value = rcDataSet.Tables("rc_rkdml").Rows(0).Item("rkrq")
        Me.LblBdelete.Text = IIf(rcDataSet.Tables("rc_rkdml").Rows(0).Item("bdelete"), "作废", "")
        If rcDataSet.Tables("rc_rkdml").Rows(0).Item("zydm").GetType.ToString <> "System.DBNull" Then
            Me.TxtZydm.Text = rcDataSet.Tables("rc_rkdml").Rows(0).Item("zydm")
        Else
            Me.TxtZydm.Text = ""
        End If
        If rcDataSet.Tables("rc_rkdml").Rows(0).Item("zymc").GetType.ToString <> "System.DBNull" Then
            Me.LblZymc.Text = rcDataSet.Tables("rc_rkdml").Rows(0).Item("zymc")
        Else
            Me.LblZymc.Text = ""
        End If
        If rcDataSet.Tables("rc_rkdml").Rows(0).Item("csdm").GetType.ToString <> "System.DBNull" Then
            Me.TxtCsdm.Text = Trim(rcDataSet.Tables("rc_rkdml").Rows(0).Item("csdm"))
        Else
            Me.TxtCsdm.Text = ""
        End If
        If rcDataSet.Tables("rc_rkdml").Rows(0).Item("csmc").GetType.ToString <> "System.DBNull" Then
            Me.LblCsmc.Text = rcDataSet.Tables("rc_rkdml").Rows(0).Item("csmc")
        Else
            Me.LblCsmc.Text = ""
        End If
        If rcDataSet.Tables("rc_rkdml").Rows(0).Item("yspz").GetType.ToString <> "System.DBNull" Then
            Me.TxtYspz.Text = rcDataSet.Tables("rc_rkdml").Rows(0).Item("yspz")
        Else
            Me.TxtYspz.Text = ""
        End If
        If rcDataSet.Tables("rc_rkdml").Rows(0).Item("ckdm").GetType.ToString <> "System.DBNull" Then
            Me.TxtCkdm.Text = Trim(rcDataSet.Tables("rc_rkdml").Rows(0).Item("ckdm"))
        Else
            Me.TxtCkdm.Text = ""
        End If
        If rcDataSet.Tables("rc_rkdml").Rows(0).Item("ckmc").GetType.ToString <> "System.DBNull" Then
            Me.LblCkmc.Text = rcDataSet.Tables("rc_rkdml").Rows(0).Item("ckmc")
        Else
            Me.LblCkmc.Text = ""
        End If
        LblSrr.Text = "输入：" + rcDataSet.Tables("rc_rkdml").Rows(0).Item("srr")
        LblShr.Text = "审核：" + rcDataSet.Tables("rc_rkdml").Rows(0).Item("shr")
        '取po_rkd数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT po_rkd.cpdm,rc_cpxx.oldcpdm,rc_cpxx.cpmc,rc_cpxx.kuwei,po_rkd.sgddh,po_rkd.pihao,po_rkd.sl,rc_cpxx.dw,po_rkd.mjsl,po_rkd.fzsl,rc_cpxx.fzdw,po_rkd.dj,po_rkd.hsdj,po_rkd.je,po_rkd.shlv,po_rkd.se,(po_rkd.je + po_rkd.se) AS jese,po_rkd.rkmemo,po_rkd.cgddjh,po_rkd.cgdxh,po_rkd.cksl,po_rkd.ckje FROM po_rkd,rc_cpxx WHERE po_rkd.cpdm = rc_cpxx.cpdm AND (po_rkd.djh = ?) ORDER BY po_rkd.xh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rkDjh
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_rkdnr") IsNot Nothing Then
                rcDataSet.Tables("rc_rkdnr").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_rkdnr")
            rcDataGridView.DataSource = rcDataSet.Tables("rc_rkdnr")
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
        If rcDataSet.Tables("rc_rkdnr").Rows.Count > 0 Then
            dblTotSl = rcDataSet.Tables("rc_rkdnr").Compute("Sum(sl)", "")
            dblTotFzsl = rcDataSet.Tables("rc_rkdnr").Compute("Sum(fzsl)", "")
            dblTotJe = rcDataSet.Tables("rc_rkdnr").Compute("Sum(je)", "")
            dblTotSe = rcDataSet.Tables("rc_rkdnr").Compute("Sum(se)", "")
        End If
        Me.LblSl.Text = "数量合计：" + Format(dblTotSl, g_FormatSl)
        Me.LblFzsl.Text = "辅数量合计：" + Format(dblTotFzsl, g_FormatSl)
        Me.LblJe.Text = "金额合计：" + Format(dblTotJe, g_FormatJe)
        Me.LblSe.Text = "税额合计：" + Format(dblTotSe, g_FormatJe)
        Me.LblJese.Text = "价税合计：" + Format(dblTotJe + dblTotSe, g_FormatJe)
    End Sub

#End Region

#Region "首张"

    Private Sub BtnTop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTop.Click, MnuiTop.Click
        If rcBmb.Count > 0 Then
            rcBmb.Position = 0
            ShowRkd(rcBmb.Current("djh"))
        End If
    End Sub

#End Region

#Region "上张"

    Private Sub BtnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevious.Click, MnuiPrevious.Click
        If rcBmb.Count > 0 Then
            If rcBmb.Position <> 0 Then
                rcBmb.Position -= 1
            End If
            ShowRkd(rcBmb.Current("djh"))
        End If
    End Sub

#End Region

#Region "下张"

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click, MnuiNext.Click
        If rcBmb.Count > 0 Then
            If rcBmb.Position <> rcBmb.Count Then
                rcBmb.Position += 1
            End If
            ShowRkd(rcBmb.Current("djh"))
        End If
    End Sub

#End Region

#Region "末张"

    Private Sub BtnBottom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBottom.Click, MnuiBottom.Click
        If rcBmb.Count > 0 Then
            rcBmb.Position = rcBmb.Count - 1
            ShowRkd(rcBmb.Current("djh"))
        End If
    End Sub

#End Region

#Region "准备打印数据事件"

    Private Sub PreparePrintData()
        If rcRps Is Nothing Then
            rcRps = New RPS.Document
        End If
        Dim rft As String = CurDir() + "\reports\rkdbz.rft"
        rcRps.LoadTemplate(rft)
        '取RPS数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps WHERE rpsid = 'RKDBZ'"
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
        rcRps.Text(-1, 1) = g_PrnDwmc & "物料收货单"
        rcRps.Text(-1, 2) = "单据号：" & Trim(Me.TxtDjh.Text) & "  %p/%t"
        rcRps.Text(-1, 3) = "日期：" & Me.DtpRkrq.Value.ToLongDateString
        rcRps.Text(-1, 4) = "供应商：(" & Trim(Me.TxtCsdm.Text) & ")" & Trim(LblCsmc.Text)
        rcRps.Text(-1, 5) = "仓库：(" & Trim(Me.TxtCkdm.Text) & ")" & Trim(LblCkmc.Text)
        rcRps.Text(-1, 6) = "经办人：(" & Trim(Me.TxtZydm.Text) & ")" & Trim(LblZymc.Text)
        Dim i As Integer
        Dim j As Integer
        Dim intPage As Integer
        Dim dblTotalSl As Double = 0.0
        Dim dblTotalJe As Double = 0.0
        For intPage = 1 To System.Math.Ceiling(rcDataSet.Tables("rc_rkdnr").Rows.Count / rcRps.LinesPerPage.ToString)
            For i = (intPage - 1) * rcRps.LinesPerPage.ToString To System.Math.Min(intPage * rcRps.LinesPerPage.ToString - 1, rcDataSet.Tables("rc_rkdnr").Rows.Count - 1)
                If rcDataSet.Tables("rc_rkdnr").Rows(i).RowState <> 8 Then
                    If Not rcDataSet.Tables("rc_rkdnr").Rows(i).Item("cpdm").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 1) = Trim(rcDataSet.Tables("rc_rkdnr").Rows(i).Item("cpdm"))
                    End If
                    If Not rcDataSet.Tables("rc_rkdnr").Rows(i).Item("cpmc").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 2) = Trim(rcDataSet.Tables("rc_rkdnr").Rows(i).Item("cpmc"))
                    End If
                    If Not rcDataSet.Tables("rc_rkdnr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 3) = Trim(rcDataSet.Tables("rc_rkdnr").Rows(i).Item("dw"))
                    End If
                    If Not rcDataSet.Tables("rc_rkdnr").Rows(i).Item("kuwei").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 4) = rcDataSet.Tables("rc_rkdnr").Rows(i).Item("kuwei")
                    End If
                    If Not rcDataSet.Tables("rc_rkdnr").Rows(i).Item("sgddh").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 5) = rcDataSet.Tables("rc_rkdnr").Rows(i).Item("sgddh")
                    End If
                    If Not rcDataSet.Tables("rc_rkdnr").Rows(i).Item("pihao").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 6) = rcDataSet.Tables("rc_rkdnr").Rows(i).Item("pihao")
                    End If
                    If Not rcDataSet.Tables("rc_rkdnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 7) = Format(rcDataSet.Tables("rc_rkdnr").Rows(i).Item("sl"), g_FormatSl)
                        dblTotalSl += rcDataSet.Tables("rc_rkdnr").Rows(i).Item("sl")
                    End If
                    'If Not rcDataSet.Tables("rc_rkdnr").Rows(i).Item("hsdj").GetType.ToString = "System.DBNull" Then
                    '    rcRps.Text(j + 1, 6) = Format(rcDataSet.Tables("rc_rkdnr").Rows(i).Item("hsdj"), g_FormatDj)
                    'End If
                    'If Not rcDataSet.Tables("rc_rkdnr").Rows(i).Item("jese").GetType.ToString = "System.DBNull" Then
                    '    rcRps.Text(j + 1, 7) = Format(rcDataSet.Tables("rc_rkdnr").Rows(i).Item("jese"), g_FormatJe)
                    '    dblTotalJe = dblTotalJe + rcDataSet.Tables("rc_rkdnr").Rows(i).Item("jese")
                    'End If
                    If Not rcDataset.Tables("rc_rkdnr").Rows(i).Item("oldcpdm").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 8) = Trim(rcDataset.Tables("rc_rkdnr").Rows(i).Item("oldcpdm"))
                    End If
                    If Not rcDataset.Tables("rc_rkdnr").Rows(i).Item("rkmemo").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 8) = Trim(rcDataset.Tables("rc_rkdnr").Rows(i).Item("rkmemo"))
                    End If
                    If Not rcDataset.Tables("rc_rkdnr").Rows(i).Item("oldcpdm").GetType.ToString = "System.DBNull" And Not rcDataset.Tables("rc_rkdnr").Rows(i).Item("rkmemo").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 8) = Trim(rcDataset.Tables("rc_rkdnr").Rows(i).Item("oldcpdm")) & " " & Trim(rcDataset.Tables("rc_rkdnr").Rows(i).Item("rkmemo"))
                    End If
                    j += 1
                End If
            Next

            Dim m As New models.ChineseNum With {
                .InputString = dblTotalJe
            }
            rcRps.PerPageText(intPage, 7) = IIf(intPage = Math.Ceiling(rcDataSet.Tables("rc_rkdnr").Rows.Count / rcRps.LinesPerPage.ToString), "合计", "小计")
            '’、rcRps.PerPageText(intPage, 8) = m.OutString '大写
            rcRps.PerPageText(intPage, 11) = Format(dblTotalSl, g_FormatSl)
            'rcRps.PerPageText(intPage, 11) = Format(dblTotalJe, g_FormatJe)
            'dblTotalJe = 0.0
        Next
        If Decimal.op_Modulus(rcDataSet.Tables("rc_rkdnr").Rows.Count, rcRps.LinesPerPage.ToString) <> 0 Then
            For i = Decimal.op_Modulus(rcDataSet.Tables("rc_rkdnr").Rows.Count, rcRps.LinesPerPage.ToString) + 1 To rcRps.LinesPerPage.ToString
                rcRps.Text(j + 1, 1) = ""
                j += 1
            Next
        End If
        rcRps.Text(-1, 14) = "制单：" & rcDataSet.Tables("rc_rkdml").Rows(0).Item("srr")
    End Sub

#End Region

#Region "打印设置事件"

    Private Sub PageSetupEvent()
        Dim rcFrmPageSetup As New models.FrmPageSetup
        With rcFrmPageSetup
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = "RKDBZ"
            .paraRpsName = "入库单标准格式"
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