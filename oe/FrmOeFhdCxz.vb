Imports System.Data.OleDb

Public Class FrmOeFhdCxz
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
    '套打标志
    ReadOnly blnTd As Boolean = False

    Public Property ParaDataSet() As DataSet
        Get
            ParaDataSet = rcDataSet
        End Get
        Set(ByVal Value As DataSet)
            rcDataSet = Value
        End Set
    End Property

    Private Sub FrmOeFhdCxz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '设置DataGridView
        Me.rcDataGridView.AutoGenerateColumns = False
        Me.rcDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColMjsl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColMjsl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColFzsl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColFzsl").DefaultCellStyle.Format = g_FormatSl

        rcBmb = Me.BindingContext(rcDataSet, "xsdml")
        If rcDataSet.Tables("xsdml").Rows.Count > 0 Then
            ShowXsd(rcDataset.Tables("xsdml").Rows(0).Item("djh"))
        End If
    End Sub

    Private Sub ShowXsd(ByVal xsdDjh As String)
        '判断xsdDjh
        '取oe_fhd数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT oe_fhd.djh,oe_fhd.fhrq,oe_fhd.bdelete,oe_fhd.khdm,oe_fhd.khmc,oe_fhd.zydm,oe_fhd.zymc,oe_fhd.ckdm,oe_fhd.ckmc,oe_fhd.srr,oe_fhd.shr,oe_fhd.jzr FROM oe_fhd WHERE (djh = ?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = xsdDjh
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_fhdml") IsNot Nothing Then
                rcDataset.Tables("rc_fhdml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_fhdml")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '赋值
        Me.TxtDjh.Text = rcDataset.Tables("rc_fhdml").Rows(0).Item("djh")
        Me.DtpFhrq.Value = rcDataset.Tables("rc_fhdml").Rows(0).Item("fhrq")
        Me.LblBdelete.Text = IIf(rcDataset.Tables("rc_fhdml").Rows(0).Item("bdelete"), "作废", "")
        If rcDataset.Tables("rc_fhdml").Rows(0).Item("khdm").GetType.ToString <> "System.DBNull" Then
            Me.TxtKhdm.Text = rcDataset.Tables("rc_fhdml").Rows(0).Item("khdm")
        Else
            Me.TxtKhdm.Text = ""
        End If
        If rcDataset.Tables("rc_fhdml").Rows(0).Item("khmc").GetType.ToString <> "System.DBNull" Then
            Me.LblKhmc.Text = rcDataset.Tables("rc_fhdml").Rows(0).Item("khmc")
        Else
            Me.LblKhmc.Text = ""
        End If
        If rcDataset.Tables("rc_fhdml").Rows(0).Item("zydm").GetType.ToString <> "System.DBNull" Then
            Me.TxtZydm.Text = rcDataset.Tables("rc_fhdml").Rows(0).Item("zydm")
        Else
            Me.TxtZydm.Text = ""
        End If
        If rcDataset.Tables("rc_fhdml").Rows(0).Item("zymc").GetType.ToString <> "System.DBNull" Then
            Me.LblZymc.Text = rcDataset.Tables("rc_fhdml").Rows(0).Item("zymc")
        Else
            Me.LblZymc.Text = ""
        End If
        If rcDataset.Tables("rc_fhdml").Rows(0).Item("ckdm").GetType.ToString <> "System.DBNull" Then
            Me.TxtCkdm.Text = rcDataset.Tables("rc_fhdml").Rows(0).Item("ckdm")
        Else
            Me.TxtCkdm.Text = ""
        End If
        If rcDataset.Tables("rc_fhdml").Rows(0).Item("ckmc").GetType.ToString <> "System.DBNull" Then
            Me.LblCkmc.Text = Trim(rcDataset.Tables("rc_fhdml").Rows(0).Item("ckmc"))
        Else
            Me.LblCkmc.Text = ""
        End If
        Me.LblSrr.Text = "输入：" + rcDataset.Tables("rc_fhdml").Rows(0).Item("srr")
        Me.LblShr.Text = "审核：" + rcDataset.Tables("rc_fhdml").Rows(0).Item("shr")
        Me.LblJzr.Text = "记账：" + rcDataset.Tables("rc_fhdml").Rows(0).Item("jzr")
        '取oe_fhd数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT oe_fhd.cpdm,COALESCE(oe_fhd.cpmc,'') as cpmc,COALESCE(oe_fhd.hth,'') AS hth,oe_fhd.khddh,oe_fhd.khlh,oe_fhd.mjsl,oe_fhd.sl,COALESCE(oe_fhd.dw,'') as dw,oe_fhd.fzsl,oe_fhd.fzdw,oe_fhd.fhmemo FROM oe_fhd WHERE (oe_fhd.djh = ?) ORDER BY oe_fhd.xh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = xsdDjh
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_fhdnr") IsNot Nothing Then
                rcDataset.Tables("rc_fhdnr").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_fhdnr")
            rcDataGridView.DataSource = rcDataset.Tables("rc_fhdnr")
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
        If rcDataset.Tables("rc_fhdnr").Rows.Count > 0 Then
            dblTotSl = rcDataset.Tables("rc_fhdnr").Compute("Sum(sl)", "")
            dblTotFzsl = rcDataset.Tables("rc_fhdnr").Compute("Sum(fzsl)", "")
        End If
        Me.LblSl.Text = "数量合计：" + Format(dblTotSl, g_FormatSl)
        Me.LblFzsl.Text = "辅数量合计：" + Format(dblTotFzsl, g_FormatSl)
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


#Region "打印设置、打印、打印预览事件"

    Private Sub PageSetupEvent()
        Dim rcFrmPageSetup As New models.FrmPageSetup
        With rcFrmPageSetup
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = "FHDBZ"
            .paraRpsName = "发货通知书标准格式"
            .ShowDialog()
        End With
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

    Private Sub PrintViewEvent()
        PreparePrintData()
        rcRps.Preview()
    End Sub
    Private Sub PreparePrintData()

        If rcRps Is Nothing Then
            rcRps = New RPS.Document
        End If
        Dim rft As String
        rft = Application.StartupPath + "\reports\fhdbz.rft"
        rcRps.LoadTemplate(rft)
        '取RPS打印参数
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps WHERE rpsid = 'FHDBZ'"
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
        rcRps.Text(-1, 1) = g_PrnDwmc
        rcRps.Text(-1, 2) = "发货通知书"
        rcRps.Text(-1, 3) = "单据号：" & Trim(Me.TxtDjh.Text) & "  %p/%t"
        rcRps.Text(-1, 4) = "客户：" & "(" & Trim(Me.TxtKhdm.Text) & ")" & Trim(Me.LblKhmc.Text)
        rcRps.Text(-1, 5) = "日期：" & Me.DtpFhrq.Value.Date.ToLongDateString

        Dim i As Integer
        Dim j As Integer
        Dim intPage As Integer
        dblTotSl = 0.0
        dblTotFzsl = 0
        For intPage = 1 To System.Math.Ceiling(rcDataSet.Tables("rc_fhdnr").Rows.Count / rcRps.LinesPerPage.ToString)
            For i = (intPage - 1) * rcRps.LinesPerPage.ToString To System.Math.Min(intPage * rcRps.LinesPerPage.ToString - 1, rcDataSet.Tables("rc_fhdnr").Rows.Count - 1)
                If rcDataSet.Tables("rc_fhdnr").Rows(i).RowState <> 8 Then
                    '送货单格式
                    If Not rcDataSet.Tables("rc_fhdnr").Rows(i).Item("cpdm").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 1) = Trim(rcDataSet.Tables("rc_fhdnr").Rows(i).Item("cpdm"))
                    End If
                    If Not rcDataSet.Tables("rc_fhdnr").Rows(i).Item("cpmc").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 2) = Trim(rcDataSet.Tables("rc_fhdnr").Rows(i).Item("cpmc"))
                    End If
                    If Not rcDataSet.Tables("rc_fhdnr").Rows(i).Item("khddh").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 3) = Trim(rcDataSet.Tables("rc_fhdnr").Rows(i).Item("khddh"))
                    End If
                    If Not rcDataSet.Tables("rc_fhdnr").Rows(i).Item("khlh").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 4) = Trim(rcDataSet.Tables("rc_fhdnr").Rows(i).Item("khlh"))
                    End If
                    If Not rcDataSet.Tables("rc_fhdnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 5) = Format(rcDataSet.Tables("rc_fhdnr").Rows(i).Item("sl"), g_FormatSl)
                        dblTotSl += rcDataSet.Tables("rc_fhdnr").Rows(i).Item("sl")
                    End If
                    If Not rcDataSet.Tables("rc_fhdnr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 6) = Trim(rcDataSet.Tables("rc_fhdnr").Rows(i).Item("dw"))
                    End If
                    If Not rcDataSet.Tables("rc_fhdnr").Rows(i).Item("fzsl").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 7) = Format(rcDataSet.Tables("rc_fhdnr").Rows(i).Item("fzsl"), g_FormatSl)
                        dblTotFzsl += rcDataSet.Tables("rc_fhdnr").Rows(i).Item("fzsl")
                    End If
                    If Not rcDataSet.Tables("rc_fhdnr").Rows(i).Item("fzdw").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 8) = Trim(rcDataSet.Tables("rc_fhdnr").Rows(i).Item("fzdw"))
                    End If
                    If Not rcDataSet.Tables("rc_fhdnr").Rows(i).Item("fhmemo").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 9) = rcDataSet.Tables("rc_fhdnr").Rows(i).Item("fhmemo")
                    End If
                    j += 1
                End If
            Next
            rcRps.PerPageText(intPage, 9) = Format(dblTotSl, g_FormatSl)
            rcRps.PerPageText(intPage, 11) = Format(dblTotFzsl, g_FormatSl)
        Next
        If Decimal.op_Modulus(rcDataSet.Tables("rc_fhdnr").Rows.Count, rcRps.LinesPerPage.ToString) <> 0 Then
            For i = Decimal.op_Modulus(rcDataSet.Tables("rc_fhdnr").Rows.Count, rcRps.LinesPerPage.ToString) + 1 To rcRps.LinesPerPage.ToString
                rcRps.Text(j + 1, 1) = ""
                j += 1
            Next
        End If
        rcRps.Text(-1, 14) = "制单：" & g_User_DspName
    End Sub

    Private Sub MnuiPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrint.Click
        PrintEvent()
    End Sub

    Private Sub MnuiPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPageSetup.Click
        PageSetupEvent()
    End Sub

    Private Sub MnuiPrintView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrintView.Click
        PrintViewEvent()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        PrintEvent()
    End Sub

    Private Sub BtnPrintView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrintView.Click
        PrintViewEvent()
    End Sub

#End Region

End Class