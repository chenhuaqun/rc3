Imports System.Data.OleDb

Public Class FrmPmRkdCxz
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    Dim rcDataset As New DataSet
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '数据绑定
    Dim rcBmb As BindingManagerBase
    '建立打印文档
    Dim rcRps As RPS.Document
    '合计变量
    Dim dblTotSl As Double = 0.0
    Dim dblTotFzsl As Double = 0.0
    Dim dblTotJe As Double = 0.0

    Public Property ParaDataSet() As DataSet
        Get
            ParaDataSet = rcDataSet
        End Get
        Set(ByVal Value As DataSet)
            rcDataSet = Value
        End Set
    End Property

    Private Sub FrmPmRkdCxz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Me.rcDataGridView.Columns("ColJe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColJe").DefaultCellStyle.Format = g_FormatJe
        rcBmb = Me.BindingContext(rcDataSet, "rkdml")
        If rcDataSet.Tables("rkdml").Rows.Count > 0 Then
            ShowXsd(rcDataSet.Tables("rkdml").Rows(0).Item("djh"))
        End If
    End Sub

    Private Sub ShowXsd(ByVal rkdDjh As String)
        '判断rkdDjh
        '取inv_rkd数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT inv_rkd.djh,TRUNC(inv_rkd.rkrq,'mi') AS rkrq,inv_rkd.bdelete,inv_rkd.bmdm,inv_rkd.bmmc,inv_rkd.gxdm,inv_rkd.gxmc,inv_rkd.zydm,inv_rkd.zymc,inv_rkd.ckdm,inv_rkd.ckmc,inv_rkd.srr,inv_rkd.shr,inv_rkd.jzr FROM inv_rkd WHERE (djh = ?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rkdDjh
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
            Me.TxtZydm.Text = Trim(rcDataSet.Tables("rc_rkdml").Rows(0).Item("zydm"))
        Else
            Me.TxtZydm.Text = ""
        End If
        If rcDataSet.Tables("rc_rkdml").Rows(0).Item("zymc").GetType.ToString <> "System.DBNull" Then
            Me.LblZymc.Text = rcDataSet.Tables("rc_rkdml").Rows(0).Item("zymc")
        Else
            Me.LblZymc.Text = ""
        End If
        If rcDataSet.Tables("rc_rkdml").Rows(0).Item("bmdm").GetType.ToString <> "System.DBNull" Then
            Me.TxtBmdm.Text = rcDataSet.Tables("rc_rkdml").Rows(0).Item("bmdm")
        Else
            Me.TxtBmdm.Text = ""
        End If
        If rcDataSet.Tables("rc_rkdml").Rows(0).Item("bmmc").GetType.ToString <> "System.DBNull" Then
            Me.LblBmmc.Text = Trim(rcDataSet.Tables("rc_rkdml").Rows(0).Item("bmmc"))
        Else
            Me.LblBmmc.Text = ""
        End If
        If rcDataSet.Tables("rc_rkdml").Rows(0).Item("gxdm").GetType.ToString <> "System.DBNull" Then
            Me.TxtGxdm.Text = rcDataSet.Tables("rc_rkdml").Rows(0).Item("gxdm")
        Else
            Me.TxtGxdm.Text = ""
        End If
        If rcDataSet.Tables("rc_rkdml").Rows(0).Item("gxmc").GetType.ToString <> "System.DBNull" Then
            Me.LblGxmc.Text = Trim(rcDataSet.Tables("rc_rkdml").Rows(0).Item("gxmc"))
        Else
            Me.LblGxmc.Text = ""
        End If
        If rcDataSet.Tables("rc_rkdml").Rows(0).Item("ckdm").GetType.ToString <> "System.DBNull" Then
            Me.TxtCkdm.Text = rcDataSet.Tables("rc_rkdml").Rows(0).Item("ckdm")
        Else
            Me.TxtCkdm.Text = ""
        End If
        If rcDataSet.Tables("rc_rkdml").Rows(0).Item("ckmc").GetType.ToString <> "System.DBNull" Then
            Me.LblCkmc.Text = Trim(rcDataSet.Tables("rc_rkdml").Rows(0).Item("ckmc"))
        Else
            Me.LblCkmc.Text = ""
        End If
        Me.LblSrr.Text = "输入：" + rcDataSet.Tables("rc_rkdml").Rows(0).Item("srr")
        Me.LblShr.Text = "审核：" + rcDataSet.Tables("rc_rkdml").Rows(0).Item("shr")
        Me.LblJzr.Text = "记账：" + rcDataSet.Tables("rc_rkdml").Rows(0).Item("jzr")
        '取inv_rkd数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT inv_rkd.cpdm,COALESCE(inv_rkd.cpmc,'') as cpmc,inv_rkd.hth,inv_rkd.scph,inv_rkd.sl,COALESCE(inv_rkd.dw,'') as dw,inv_rkd.mjsl,inv_rkd.fzsl,inv_rkd.fzdw,inv_rkd.dj,inv_rkd.je,inv_rkd.rkmemo FROM inv_rkd WHERE (inv_rkd.djh = ?) ORDER BY inv_rkd.XH"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rkdDjh
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

#Region "计算合计数"

    Private Sub SumSlJe()
        '计算合计数
        dblTotSl = 0.0
        dblTotFzsl = 0.0
        dblTotJe = 0.0
        If rcDataSet.Tables("rc_rkdnr").Rows.Count > 0 Then
            dblTotSl = rcDataSet.Tables("rc_rkdnr").Compute("Sum(sl)", "")
            dblTotFzsl = rcDataSet.Tables("rc_rkdnr").Compute("Sum(fzsl)", "")
            dblTotJe = rcDataSet.Tables("rc_rkdnr").Compute("Sum(je)", "")
        End If
        Me.LblSl.Text = "数量合计：" + Format(dblTotSl, g_FormatSl)
        Me.LblFzsl.Text = "辅数量合计：" + Format(dblTotFzsl, g_FormatJe)
        Me.LblJe.Text = "金额合计：" + Format(dblTotJe, g_FormatJe)
    End Sub

#End Region

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        ExitEvent()
    End Sub

    Private Sub MnuiExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiExit.Click
        ExitEvent()
    End Sub

    Private Sub ExitEvent()
        Me.Close()
    End Sub

    Private Sub BtnTop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTop.Click
        If rcBmb.Count > 0 Then
            rcBmb.Position = 0
            ShowXsd(rcBmb.Current("djh"))
        End If
    End Sub

    Private Sub MnuiTop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiTop.Click
        If rcBmb.Count > 0 Then
            rcBmb.Position = 0
            ShowXsd(rcBmb.Current("djh"))
        End If
    End Sub

    Private Sub BtnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevious.Click
        If rcBmb.Count > 0 Then
            If rcBmb.Position <> 0 Then
                rcBmb.Position -= 1
            End If
            ShowXsd(rcBmb.Current("djh"))
        End If
    End Sub

    Private Sub MnuiPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrevious.Click
        If rcBmb.Count > 0 Then
            If rcBmb.Position <> 0 Then
                rcBmb.Position -= 1
            End If
            ShowXsd(rcBmb.Current("djh"))
        End If
    End Sub

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
        If rcBmb.Count > 0 Then
            If rcBmb.Position <> rcBmb.Count Then
                rcBmb.Position += 1
            End If
            ShowXsd(rcBmb.Current("djh"))
        End If
    End Sub

    Private Sub MnuiNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiNext.Click
        If rcBmb.Count > 0 Then
            If rcBmb.Position <> rcBmb.Count Then
                rcBmb.Position += 1
            End If
            ShowXsd(rcBmb.Current("djh"))
        End If
    End Sub

    Private Sub BtnBottom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBottom.Click
        If rcBmb.Count > 0 Then
            rcBmb.Position = rcBmb.Count - 1
            ShowXsd(rcBmb.Current("djh"))
        End If
    End Sub

    Private Sub MnuiBottom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiBottom.Click
        If rcBmb.Count > 0 Then
            rcBmb.Position = rcBmb.Count - 1
            ShowXsd(rcBmb.Current("djh"))
        End If
    End Sub


#Region "准备打印数据"

    Private Sub PreparePrintData()
        If rcRps Is Nothing Then
            rcRps = New RPS.Document
        End If
        Dim rft As String = Application.StartupPath + "\reports\gxrkd.rft"
        rcRps.LoadTemplate(rft)
        '取RPS打印参数
        rcOleDbConn.Open()
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps WHERE rpsid = 'GXRKD'"
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
        rcRps.Text(-1, 1) = g_PrnDwmc & "工序入库单"
        rcRps.Text(-1, 2) = "仓库：(" & Me.TxtCkdm.Text & ")" & Me.LblCkmc.Text
        rcRps.Text(-1, 3) = "经手人：(" & Me.TxtZydm.Text & ")" & Me.LblZymc.Text
        rcRps.Text(-1, 4) = "单据号：" & Me.TxtDjh.Text & "  %p/%t"
        rcRps.Text(-1, 5) = "部门：(" & Me.TxtBmdm.Text & ")" & Me.LblBmmc.Text
        rcRps.Text(-1, 6) = "工序：(" & Me.TxtGxdm.Text & ")" & Me.LblGxmc.Text
        rcRps.Text(-1, 7) = "日期：" & Me.DtpRkrq.Value.ToLongDateString
        Dim i As Integer
        Dim j As Integer
        Dim intPage As Integer
        Dim dblTotalSl As Double = 0.0
        Dim dblTotalFzsl As Double = 0.0
        For intPage = 1 To System.Math.Ceiling(rcDataSet.Tables("rc_rkdnr").Rows.Count / rcRps.LinesPerPage.ToString)
            For i = (intPage - 1) * rcRps.LinesPerPage.ToString To System.Math.Min(intPage * rcRps.LinesPerPage.ToString - 1, rcDataSet.Tables("rc_rkdnr").Rows.Count - 1)
                If rcDataSet.Tables("rc_rkdnr").Rows(i).RowState <> 8 Then
                    If Not rcDataSet.Tables("rc_rkdnr").Rows(i).Item("cpdm").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 1) = Trim(rcDataSet.Tables("rc_rkdnr").Rows(i).Item("cpdm"))
                    End If
                    If Not rcDataSet.Tables("rc_rkdnr").Rows(i).Item("cpmc").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 2) = Trim(rcDataSet.Tables("rc_rkdnr").Rows(i).Item("cpmc"))
                    End If
                    If Not rcDataSet.Tables("rc_rkdnr").Rows(i).Item("scph").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 3) = Trim(rcDataSet.Tables("rc_rkdnr").Rows(i).Item("scph"))
                    End If
                    If Not rcDataSet.Tables("rc_rkdnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 4) = Format(rcDataSet.Tables("rc_rkdnr").Rows(i).Item("sl"), g_FormatSl)
                        dblTotalSl += rcDataSet.Tables("rc_rkdnr").Rows(i).Item("sl")
                    End If
                    If Not rcDataSet.Tables("rc_rkdnr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 5) = Trim(rcDataSet.Tables("rc_rkdnr").Rows(i).Item("dw"))
                    End If
                    If Not rcDataSet.Tables("rc_rkdnr").Rows(i).Item("fzsl").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 6) = Format(rcDataSet.Tables("rc_rkdnr").Rows(i).Item("fzsl"), g_FormatSl)
                        dblTotalFzsl += rcDataSet.Tables("rc_rkdnr").Rows(i).Item("fzsl")
                    End If
                    If Not rcDataSet.Tables("rc_rkdnr").Rows(i).Item("fzdw").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 7) = Trim(rcDataSet.Tables("rc_rkdnr").Rows(i).Item("fzdw"))
                    End If
                    If Not rcDataSet.Tables("rc_rkdnr").Rows(i).Item("rkmemo").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 8) = Trim(rcDataSet.Tables("rc_rkdnr").Rows(i).Item("rkmemo"))
                    End If
                    j += 1
                End If
            Next
            'Dim m As New models.ChineseNum
            'm.InputString = dblTotalJe
            rcRps.PerPageText(intPage, 8) = IIf(intPage = Math.Ceiling(rcDataSet.Tables("rc_rkdnr").Rows.Count / rcRps.LinesPerPage.ToString), "合计", "小计")
            'rcRps.PerPageText(intPage, 7) = m.OutString '大写
            rcRps.PerPageText(intPage, 10) = Format(dblTotalSl, g_FormatSl)
            rcRps.PerPageText(intPage, 12) = Format(dblTotalFzsl, g_FormatSl)
            'dblTotalJe = 0.0
        Next
        If Decimal.op_Modulus(rcDataSet.Tables("rc_rkdnr").Rows.Count, rcRps.LinesPerPage.ToString) <> 0 Then
            For i = Decimal.op_Modulus(rcDataSet.Tables("rc_rkdnr").Rows.Count, rcRps.LinesPerPage.ToString) + 1 To rcRps.LinesPerPage.ToString
                rcRps.Text(j + 1, 1) = ""
                j += 1
            Next
        End If
        rcRps.Text(-1, 15) = "制单：" & g_User_DspName
    End Sub

#End Region

#Region "打印设置事件"

    Private Sub PageSetupEvent()
        Dim rcFrmPageSetup As New models.FrmPageSetup
        With rcFrmPageSetup
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = "GXRKD"
            .paraRpsName = "工序入库单标准格式"
            .ShowDialog()
        End With
    End Sub

    Private Sub MnuiPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPageSetup.Click
        PageSetupEvent()
    End Sub

#End Region

#Region "打印事件"

    Private Sub MnuiPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrint.Click
        PrintEvent()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
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

    Private Sub MnuiPrintView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrintView.Click
        PrintViewEvent()
    End Sub

    Private Sub BtnPrintView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrintView.Click
        PrintViewEvent()
    End Sub

    Private Sub PrintViewEvent()
        PreparePrintData()
        rcRps.Preview()
    End Sub

#End Region

End Class