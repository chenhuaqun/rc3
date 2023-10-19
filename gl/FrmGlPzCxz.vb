Imports System.Math
Imports System.Data.OleDb

Public Class FrmGlPzCxz
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    Dim rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    ReadOnly rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable '我们要利用该datatable进行金额计算
    ReadOnly dtPz As New DataTable("rc_pznr")
    '数据绑定
    Dim rcBmb As BindingManagerBase
    '打印文档
    Dim rcRps As RPS.Document = Nothing
    '合计变量
    Dim dblTotSl As Double = 0.0
    Dim dblTotJe As Double = 0.0

#Region "窗体初始化"

    Public Property ParaDataSet() As DataSet
        Get
            ParaDataSet = rcDataSet
        End Get
        Set(ByVal Value As DataSet)
            rcDataSet = Value
        End Set
    End Property

    Private Sub FrmInvDbdSrz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '设置DataGridView
        Me.rcDataGridView.AutoGenerateColumns = False
        Me.rcDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.rcDataGridView.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.rcDataGridView.Columns("ColJfje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColJfje").DefaultCellStyle.Format = g_FormatJe0
        Me.rcDataGridView.Columns("ColDfje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColDfje").DefaultCellStyle.Format = g_FormatJe0
        rcBmb = Me.BindingContext(rcDataSet, "pzml")
        If rcDataSet.Tables("pzml").Rows.Count > 0 Then
            ShowCkd(rcDataset.Tables("pzml").Rows(0).Item("djh"))
        End If
    End Sub

#End Region

#Region "显示记账凭证"

    Private Sub ShowCkd(ByVal ckDjh As String)
        '判断ckDjh

        '取gl_pz数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT gl_pz.djh,gl_pz.bdelete,gl_pz.pzrq,gl_pz.fjzs,gl_pz.srr,gl_pz.shr,gl_pz.jzr FROM gl_pz WHERE (gl_pz.djh = ?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = ckDjh
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_pzml") IsNot Nothing Then
                Me.rcDataset.Tables("rc_pzml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_pzml")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '赋值
        Me.TxtDjh.Text = rcDataset.Tables("rc_pzml").Rows(0).Item("djh")
        Me.DtpPzrq.Value = rcDataset.Tables("rc_pzml").Rows(0).Item("pzrq")
        Me.TxtFjzs.Text = Trim(rcDataset.Tables("rc_pzml").Rows(0).Item("fjzs"))
        Me.LblBdelete.Text = IIf(rcDataset.Tables("rc_pzml").Rows(0).Item("bdelete"), "作废", "")
        Me.LblSrr.Text = "输入：" + rcDataset.Tables("rc_pzml").Rows(0).Item("srr")
        Me.LblShr.Text = "审核：" + rcDataset.Tables("rc_pzml").Rows(0).Item("shr")
        Me.LblJzr.Text = "记账：" + rcDataset.Tables("rc_pzml").Rows(0).Item("jzr")
        '取gl_pz数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT gl_pz.xh,gl_pz.zy,gl_pz.kmdm,gl_pz.kmmc,gl_pz.bmdm,gl_pz.bmmc,gl_pz.xmdm,gl_pz.xmmc,gl_pz.khdm,gl_pz.khmc,gl_pz.csdm,gl_pz.csmc,gl_pz.jxzh,gl_pz.sl,gl_pz.dj,gl_pz.wb,gl_pz.hl,Case When jd = '借' Then je Else 0 End As jfje,Case When jd = '贷' Then je Else 0 End As dfje FROM gl_pz Where (gl_pz.djh = ?) ORDER BY gl_pz.xh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = ckDjh
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_pznr") IsNot Nothing Then
                rcDataset.Tables("rc_pznr").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_pznr")
            rcDataGridView.DataSource = rcDataset.Tables("rc_pznr")
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
        dblTotJe = 0.0
        If rcDataset.Tables("rc_pznr").Rows.Count > 0 Then
            dblTotSl = rcDataset.Tables("rc_pznr").Compute("Sum(sl)", "")
            dblTotJe = rcDataset.Tables("rc_pznr").Compute("Sum(jfje)", "")
        End If
        Me.LblSl.Text = "数量合计：" + Format(dblTotSl, g_FormatSl)
        Me.LblJe.Text = "金额合计：" + Format(dblTotJe, g_FormatJe)
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
            .paraRpsId = "CKDBZ"
            .paraRpsName = "入库单标准格式"
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
        Dim rft As String = CurDir() + "\reports\ckdbz.rft"
        rcRps.LoadTemplate(rft)
        '取RPS数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps WHERE rpsid = 'CKDBZ'"
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

        rcRps.Text(-1, 1) = g_Dwmc & "调拨单"
        rcRps.Text(-1, 2) = DtpPzrq.Value.Date.ToLongDateString
        rcRps.Text(-1, 3) = "单据号：" & Trim(Me.TxtDjh.Text) & "  %p/%t"
        'rcRps.Text(-1, 4) = "客户资料：" & Trim(TxtCsdm.Text)
        'rcRps.Text(-1, 5) = "经手人：(" & Trim(Me.TxtKhdm.Text) & ")" & Trim(LblKhmc.Text)
        Dim i As Integer
        Dim j As Integer
        For i = 0 To rcDataSet.Tables("rc_pznr").Rows.Count - 1
            If rcDataSet.Tables("rc_pznr").Rows(i).RowState <> 8 Then
                If Not rcDataSet.Tables("rc_pznr").Rows(i).Item("kmdm").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 1) = Trim(rcDataSet.Tables("rc_pznr").Rows(i).Item("kmdm"))
                End If
                If Not rcDataSet.Tables("rc_pznr").Rows(i).Item("kmmc").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 2) = Trim(rcDataSet.Tables("rc_pznr").Rows(i).Item("kmmc"))
                End If
                If Not rcDataSet.Tables("rc_pznr").Rows(i).Item("bmdm").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 3) = Trim(rcDataSet.Tables("rc_pznr").Rows(i).Item("bmdm"))
                End If
                If Not rcDataSet.Tables("rc_pznr").Rows(i).Item("xmdm").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 4) = Trim(rcDataSet.Tables("rc_pznr").Rows(i).Item("xmdm"))
                End If
                If Not rcDataSet.Tables("rc_pznr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 5) = Trim(rcDataSet.Tables("rc_pznr").Rows(i).Item("dw"))
                End If
                If Not rcDataSet.Tables("rc_pznr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 6) = Format(rcDataSet.Tables("rc_pznr").Rows(i).Item("sl"), g_FormatSl)
                End If
                If Not rcDataSet.Tables("rc_pznr").Rows(i).Item("dbmemo").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 7) = Trim(rcDataSet.Tables("rc_pznr").Rows(i).Item("dbmemo"))
                End If
                j += 1
            End If
        Next
        If Decimal.op_Modulus(rcDataSet.Tables("rc_pznr").Rows.Count, rcRps.LinesPerPage.ToString) <> 0 Then
            For i = Decimal.op_Modulus(rcDataSet.Tables("rc_pznr").Rows.Count, rcRps.LinesPerPage.ToString) + 1 To rcRps.LinesPerPage.ToString
                rcRps.Text(j + 1, 1) = ""
                j += 1
            Next
        End If
        rcRps.Text(-1, 6) = "开单人：" & g_User_DspName
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