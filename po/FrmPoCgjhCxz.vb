Imports System.Math
Imports System.Data.OleDb

Public Class FrmPoCgjhCxz
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    Dim rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    ReadOnly rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '数据绑定
    Dim rcBmb As BindingManagerBase
    '打印文档
    Dim rcRps As RPS.Document = Nothing
    '合计变量
    Dim dblTotSl As Double = 0.0
    Dim dblTotFzsl As Double = 0.0

#Region "窗体初始化"

    Public Property ParaDataSet() As DataSet
        Get
            ParaDataSet = rcDataSet
        End Get
        Set(ByVal Value As DataSet)
            rcDataSet = Value
        End Set
    End Property

    Private Sub FrmCgdSrz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '设置DataGridView
        Me.rcDataGridView.AutoGenerateColumns = False
        Me.rcDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Format = g_FormatSl0
        Me.rcDataGridView.Columns("ColMjsl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColMjsl").DefaultCellStyle.Format = g_FormatSl0
        Me.rcDataGridView.Columns("ColFzsl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColFzsl").DefaultCellStyle.Format = g_FormatSl0
        Me.rcDataGridView.Columns("ColCgsl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColCgsl").DefaultCellStyle.Format = g_FormatSl0
        rcBmb = Me.BindingContext(rcDataSet, "ckdml")
        If rcDataSet.Tables("ckdml").Rows.Count > 0 Then
            ShowCkd(rcDataSet.Tables("ckdml").Rows(0).Item("djh"))
        End If
    End Sub

#End Region

#Region "显示入库单"

    Private Sub ShowCkd(ByVal ckDjh As String)
        '判断ckDjh

        '取po_cgjh数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT po_cgjh.djh,po_cgjh.jhrq,po_cgjh.bmdm,po_cgjh.bmmc,po_cgjh.srr,po_cgjh.shr FROM po_cgjh WHERE (djh = ? )"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = ckDjh
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_cgjhml") IsNot Nothing Then
                rcDataSet.Tables("rc_cgjhml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_cgjhml")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '赋值
        Me.TxtDjh.Text = rcDataSet.Tables("rc_cgjhml").Rows(0).Item("djh")
        Me.DtpJhrq.Value = rcDataSet.Tables("rc_cgjhml").Rows(0).Item("jhrq")
        Me.TxtBmdm.Text = Trim(rcDataSet.Tables("rc_cgjhml").Rows(0).Item("bmdm"))
        Me.LblBmmc.Text = rcDataSet.Tables("rc_cgjhml").Rows(0).Item("bmmc")
        Me.LblSrr.Text = "制单：" + rcDataSet.Tables("rc_cgjhml").Rows(0).Item("srr")
        Me.LblShr.Text = "审核：" + rcDataSet.Tables("rc_cgjhml").Rows(0).Item("shr")
        '取po_cgjh数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT po_cgjh.cpdm,rc_cpxx.oldcpdm,rc_cpxx.cpmc,po_cgjh.sl,rc_cpxx.dw,po_cgjh.mjsl,po_cgjh.fzsl,rc_cpxx.fzdw,po_cgjh.jhshrq,po_cgjh.jhmemo,po_cgjh.cgsl,po_cgjh.bcg,po_cgjh.bclosed FROM po_cgjh,rc_cpxx WHERE po_cgjh.cpdm = rc_cpxx.cpdm AND po_cgjh.djh = ? ORDER BY po_cgjh.xh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = ckDjh
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_cgjhnr") IsNot Nothing Then
                rcDataSet.Tables("rc_cgjhnr").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_cgjhnr")
            rcDataGridView.DataSource = rcDataSet.Tables("rc_cgjhnr")
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
        If rcDataSet.Tables("rc_cgjhnr").Rows.Count > 0 Then
            dblTotSl = rcDataSet.Tables("rc_cgjhnr").Compute("Sum(sl)", "")
            dblTotFzsl = rcDataSet.Tables("rc_cgjhnr").Compute("Sum(fzsl)", "")
        End If
        Me.LblSl.Text = "数量合计：" + Format(dblTotSl, g_FormatSl)
        Me.LblFzsl.Text = "辅数量合计：" + Format(dblTotFzsl, g_FormatSl)
    End Sub

#End Region

#Region "首张"

    Private Sub BtnTop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTop.Click, MnuiTop.Click
        If rcBmb.Count > 0 Then
            rcBmb.Position = 0
            ShowCkd(rcBmb.Current("djh"))
        End If
    End Sub

#End Region

#Region "上张"

    Private Sub BtnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevious.Click, MnuiPrevious.Click
        If rcBmb.Count > 0 Then
            If rcBmb.Position <> 0 Then
                rcBmb.Position -= 1
            End If
            ShowCkd(rcBmb.Current("djh"))
        End If
    End Sub

#End Region

#Region "下张"

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click, MnuiNext.Click
        If rcBmb.Count > 0 Then
            If rcBmb.Position <> rcBmb.Count Then
                rcBmb.Position += 1
            End If
            ShowCkd(rcBmb.Current("djh"))
        End If
    End Sub

#End Region

#Region "末张"

    Private Sub BtnBottom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBottom.Click, MnuiBottom.Click
        If rcBmb.Count > 0 Then
            rcBmb.Position = rcBmb.Count - 1
            ShowCkd(rcBmb.Current("djh"))
        End If
    End Sub

#End Region

#Region "打印设置"

    Private Sub MnuiPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PageSetupEvent()
    End Sub

    Private Sub PageSetupEvent()
        Dim rcFrmPageSetup As New models.FrmPageSetup
        With rcFrmPageSetup
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = "CGJHBZ"
            .paraRpsName = "物料需求单标准格式"
            .ShowDialog()
        End With
    End Sub

#End Region

#Region "打印/打印预览"

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click, MnuiPrint.Click
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

    Private Sub MnuiPrintView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrintView.Click
        PrintViewEvent()
    End Sub

    Private Sub PrintViewEvent()
        PreparePrintData()
        rcRps.Preview()
    End Sub

#End Region

#Region "准备打印数据事件"

    Private Sub PreparePrintData()
        If rcRps Is Nothing Then
            rcRps = New RPS.Document
        End If
        Dim rft As String = CurDir() + "\reports\cgjhbz.rft"
        rcRps.LoadTemplate(rft)
        '取RPS数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps WHERE rpsid = 'CGJHBZ'"
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

        rcRps.Text(-1, 1) = g_PrnDwmc & "物料需求单"
        rcRps.Text(-1, 2) = "需求部门：(" & Trim(Me.TxtBmdm.Text) & ")" & Trim(LblBmmc.Text)
        rcRps.Text(-1, 3) = "日期：" & DtpJhrq.Value
        rcRps.Text(-1, 4) = "单据号：" & Trim(Me.TxtDjh.Text) & "  %p/%t"
        Dim i As Integer
        Dim j As Integer
        Dim intPage As Integer
        For intPage = 1 To System.Math.Ceiling(rcDataset.Tables("rc_cgjhnr").Rows.Count / rcRps.LinesPerPage.ToString)
            For i = (intPage - 1) * rcRps.LinesPerPage.ToString To System.Math.Min(intPage * rcRps.LinesPerPage.ToString - 1, rcDataset.Tables("rc_cgjhnr").Rows.Count - 1)
                If rcDataset.Tables("rc_cgjhnr").Rows(i).RowState <> 8 Then
                    If Not rcDataset.Tables("rc_cgjhnr").Rows(i).Item("cpdm").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 1) = Trim(rcDataset.Tables("rc_cgjhnr").Rows(i).Item("cpdm"))
                    End If
                    If Not rcDataset.Tables("rc_cgjhnr").Rows(i).Item("oldcpdm").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 2) = Trim(rcDataset.Tables("rc_cgjhnr").Rows(i).Item("oldcpdm"))
                    End If
                    If Not rcDataset.Tables("rc_cgjhnr").Rows(i).Item("cpmc").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 3) = Trim(rcDataset.Tables("rc_cgjhnr").Rows(i).Item("cpmc"))
                    End If
                    If Not rcDataset.Tables("rc_cgjhnr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 4) = Trim(rcDataset.Tables("rc_cgjhnr").Rows(i).Item("dw"))
                    End If
                    If Not rcDataset.Tables("rc_cgjhnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 5) = Format(rcDataset.Tables("rc_cgjhnr").Rows(i).Item("sl"), g_FormatSl)
                    End If
                    If Not rcDataset.Tables("rc_cgjhnr").Rows(i).Item("jhshrq").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 6) = Trim(rcDataset.Tables("rc_cgjhnr").Rows(i).Item("jhshrq"))
                    End If
                    If Not rcDataset.Tables("rc_cgjhnr").Rows(i).Item("jhmemo").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 7) = Trim(rcDataset.Tables("rc_cgjhnr").Rows(i).Item("jhmemo"))
                    End If
                    j += 1
                End If
            Next
        Next
        If Decimal.op_Modulus(rcDataSet.Tables("rc_cgjhnr").Rows.Count, rcRps.LinesPerPage.ToString) <> 0 Then
            For i = Decimal.op_Modulus(rcDataSet.Tables("rc_cgjhnr").Rows.Count, rcRps.LinesPerPage.ToString) + 1 To rcRps.LinesPerPage.ToString
                rcRps.Text(j + 1, 1) = ""
                j += 1
            Next
        End If
        rcRps.Text(-1, 5) = Me.LblSrr.Text
        rcRps.Text(-1, 6) = Me.LblShr.Text
    End Sub

#End Region

#Region "退出"

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiExit.Click, BtnExit.Click
        ExitEvent()
    End Sub

    Private Sub ExitEvent()
        Me.Close()
    End Sub

#End Region
End Class