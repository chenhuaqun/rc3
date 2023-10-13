Imports System.Data.OleDb
Imports System.Math
Imports System.IO

Public Class FrmOeFpSrz

    '建立OLEDB数据适配器对象
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDb传递对象
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDb命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable '我们要利用该datatable进行金额计算
    ReadOnly dtXsd As New DataTable("rc_fpnr")
    '建立Datatable '我们要利用该datatable进行金额计算
    ReadOnly dtXsdref As New DataTable("rc_xsdref")
    '建立DataGridViewTextBoxEditingControl对象
    Dim EditingControl As DataGridViewTextBoxEditingControl
    '会计期间
    Dim strKjqj As String = g_Kjqj
    '年
    Dim strYear As String = ""
    '月
    Dim strMonth As String = ""
    '增加单据的变量
    Dim IsAdding As Boolean = False
    '修改单据的变量
    Dim IsEditing As Boolean = False
    '合计变量
    Dim dblTotalSl As Double = 0.0
    Dim dblTotalFzsl As Double = 0.0
    Dim dblTotalJe As Double = 0.0
    Dim dblTotalSe As Double = 0.0
    '打印文档
    Dim rcRps As RPS.Document = Nothing
    ''打印格式
    'Dim blnDygs As Integer = 0
    ''套打标志
    'Dim blnTd As Boolean = False
    Dim blnReCalculate As Boolean = True

#Region "初始化"

    Public Property ParaStrYear() As String
        Get
            ParaStrYear = strYear
        End Get
        Set(ByVal Value As String)
            strYear = Value
        End Set
    End Property

    Public Property ParaStrMonth() As String
        Get
            ParaStrMonth = strMonth
        End Get
        Set(ByVal Value As String)
            strMonth = Value
        End Set
    End Property

    Private Sub FrmOeFpSrz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        Me.rcDataGridView.Columns("ColXsdDj").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColXsdDj").DefaultCellStyle.Format = g_FormatDj
        Me.rcDataGridView.Columns("ColXsdHsdj").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColXsdHsdj").DefaultCellStyle.Format = g_FormatDj
        Me.rcDataGridView.Columns("ColXsdJe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColXsdJe").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColXsdShlv").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColXsdShlv").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColXsdSe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColXsdSe").DefaultCellStyle.Format = g_FormatJe
        ''取套打格式打印销售单
        'Try
        '    rcOleDbConn.Open()
        '    rcOleDbCommand.Connection = rcOleDbConn
        '    rcOleDbCommand.CommandTimeout = 300
        '    rcOleDbCommand.CommandType = CommandType.Text
        '    rcOleDbCommand.CommandText = "SELECT paradblvalue FROM rc_para WHERE dwdm = ? AND paraid = '套打格式打印销售单' ORDER BY paraid"
        '    rcOleDbCommand.Parameters.Clear()
        '    rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
        '    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
        '    If Not rcDataSet.Tables("rc_para") Is Nothing Then
        '        Me.rcDataSet.Tables("rc_para").Clear()
        '    End If
        '    rcOleDbDataAdpt.Fill(rcDataSet, "rc_para")
        '    If rcDataSet.Tables("rc_para").Rows.Count = 1 Then
        '        If rcDataSet.Tables("rc_para").Rows(0).Item("paradblvalue").GetType.ToString <> "System.DBNull" Then
        '            blnTd = rcDataSet.Tables("rc_para").Rows(0).Item("paradblvalue")
        '        End If
        '    End If
        'Catch ex As Exception
        '    MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        '    Return
        'Finally
        '    rcOleDbConn.Close()
        'End Try
        '取单据类型数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE lxgs = '产品销售单' and kjnd = '" & strYear & "' ORDER BY pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_lx") IsNot Nothing Then
                Me.rcDataset.Tables("rc_lx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_lx")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message)
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_lx").Rows.Count = 0 Then
            MsgBox("请定义单据类型。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        BindDropDownList(Me.CmbPzlxjc, rcDataset.Tables("rc_lx"), "pzlxdm", "pzlxjc")

        '数据绑定
        dtXsd.Columns.Add("cpdm", Type.GetType("System.String"))
        dtXsd.Columns.Add("oldcpdm", Type.GetType("System.String"))
        dtXsd.Columns.Add("cpmc", Type.GetType("System.String"))
        dtXsd.Columns.Add("hth", Type.GetType("System.String"))
        dtXsd.Columns.Add("sl", Type.GetType("System.Double"))
        dtXsd.Columns.Add("dw", Type.GetType("System.String"))
        dtXsd.Columns.Add("mjsl", Type.GetType("System.Double"))
        dtXsd.Columns.Add("fzsl", Type.GetType("System.Double"))
        dtXsd.Columns.Add("fzdw", Type.GetType("System.String"))
        dtXsd.Columns.Add("dj", Type.GetType("System.Double"))
        dtXsd.Columns.Add("hsdj", Type.GetType("System.Double"))
        dtXsd.Columns.Add("je", Type.GetType("System.Double"))
        dtXsd.Columns.Add("shlv", Type.GetType("System.Double"))
        dtXsd.Columns.Add("se", Type.GetType("System.Double"))
        dtXsd.Columns.Add("jese", Type.GetType("System.Double"))
        dtXsd.Columns.Add("fpmemo", Type.GetType("System.String"))
        dtXsd.Columns.Add("dddjh", Type.GetType("System.String"))
        dtXsd.Columns.Add("ddxh", Type.GetType("System.Int32"))
        dtXsd.Columns.Add("xsddjh", Type.GetType("System.String"))
        dtXsd.Columns.Add("xsdxh", Type.GetType("System.Int32"))
        dtXsd.Columns.Add("xsddj", Type.GetType("System.Double"))
        dtXsd.Columns.Add("xsdhsdj", Type.GetType("System.Double"))
        dtXsd.Columns.Add("xsdje", Type.GetType("System.Double"))
        dtXsd.Columns.Add("xsdshlv", Type.GetType("System.Double"))
        dtXsd.Columns.Add("xsdse", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtXsd)
        With rcDataset.Tables("rc_fpnr")
            .Columns("cpdm").DefaultValue = ""
            .Columns("oldcpdm").DefaultValue = ""
            .Columns("hth").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("mjsl").DefaultValue = 0.0
            .Columns("fzsl").DefaultValue = 0.0
            .Columns("dj").DefaultValue = 0
            .Columns("hsdj").DefaultValue = 0
            .Columns("je").DefaultValue = 0.0
            .Columns("shlv").DefaultValue = getParaValue("增值税默认税率", False)
            .Columns("se").DefaultValue = 0
            .Columns("jese").DefaultValue = 0
            .Columns("fpmemo").DefaultValue = ""
            .Columns("dddjh").DefaultValue = ""
            .Columns("ddxh").DefaultValue = 0
            .Columns("xsddjh").DefaultValue = ""
            .Columns("xsdxh").DefaultValue = 0
            .Columns("xsddj").DefaultValue = 0.0
            .Columns("xsdhsdj").DefaultValue = 0.0
            .Columns("xsdje").DefaultValue = 0.0
            .Columns("xsdshlv").DefaultValue = 0.0
            .Columns("xsdse").DefaultValue = 0.0
        End With
        ''数据绑定
        'dtXsdref.Columns.Add("xz", Type.GetType("System.Boolean"))
        'dtXsdref.Columns.Add("cpdm", Type.GetType("System.String"))
        'dtXsdref.Columns.Add("cpmc", Type.GetType("System.String"))
        'dtXsdref.Columns.Add("hth", Type.GetType("System.String"))
        'dtXsdref.Columns.Add("sl", Type.GetType("System.Double"))
        'dtXsdref.Columns.Add("dw", Type.GetType("System.String"))
        'dtXsdref.Columns.Add("mjsl", Type.GetType("System.Double"))
        'dtXsdref.Columns.Add("fzsl", Type.GetType("System.Double"))
        'dtXsdref.Columns.Add("fzdw", Type.GetType("System.String"))
        'dtXsdref.Columns.Add("dj", Type.GetType("System.Double"))
        'dtXsdref.Columns.Add("hsdj", Type.GetType("System.Double"))
        'dtXsdref.Columns.Add("je", Type.GetType("System.Double"))
        'dtXsdref.Columns.Add("shlv", Type.GetType("System.Double"))
        'dtXsdref.Columns.Add("se", Type.GetType("System.Double"))
        'dtXsdref.Columns.Add("jese", Type.GetType("System.Double"))
        'dtXsdref.Columns.Add("fpmemo", Type.GetType("System.String"))
        'rcDataSet.Tables.Add(dtXsdref)
        'With rcDataSet.Tables("rc_xsdref")
        '    .Columns("xz").DefaultValue = 0
        '    .Columns("cpdm").DefaultValue = ""
        '    .Columns("cpmc").DefaultValue = ""
        '    .Columns("hth").DefaultValue = ""
        '    .Columns("sl").DefaultValue = 0.0
        '    .Columns("dw").DefaultValue = ""
        '    .Columns("mjsl").DefaultValue = 0.0
        '    .Columns("fzsl").DefaultValue = 0.0
        '    .Columns("fzdw").DefaultValue = ""
        '    .Columns("dj").DefaultValue = 0
        '    .Columns("hsdj").DefaultValue = 0
        '    .Columns("je").DefaultValue = 0.0
        '    .Columns("shlv").DefaultValue = getParaValue("增值税默认税率", False)
        '    .Columns("se").DefaultValue = 0
        '    .Columns("jese").DefaultValue = 0
        'End With
        '绑定数据the DataGrid to the DataSet.
        Me.rcBindingSource.DataSource = dtXsd
        Me.rcDataGridView.DataSource = Me.rcBindingSource
        strKjqj = strYear & strMonth.PadLeft(2, "0")
        If getInvKjqj(g_Kjrq) = strKjqj Then
            DtpFprq.Value = g_Kjrq
        Else
            DtpFprq.Value = getInvEnd(strYear, strMonth)
        End If
        NewEvent()
    End Sub

#End Region

#Region "设置控件"

    Private Sub SetControlEnableEvent()
        If IsEditing = True Then
            Me.CmbPzlxjc.Enabled = False
            Me.TxtDjh.Enabled = False
            Me.BtnNew.Enabled = False
            Me.BtnSave.Enabled = True
            Me.BtnCancel.Enabled = True
            Me.BtnExit.Enabled = False
            Me.MnuiNew.Enabled = False
            Me.MnuiSave.Enabled = True
            Me.MnuiCancel.Enabled = True
            Me.MnuiExit.Enabled = False
        Else
            If dtXsd.Rows.Count > 0 Then
                Me.CmbPzlxjc.Enabled = False
            Else
                Me.CmbPzlxjc.Enabled = True
            End If
            Me.TxtDjh.Enabled = True
            Me.BtnNew.Enabled = True
            Me.BtnSave.Enabled = False
            Me.BtnCancel.Enabled = False
            Me.BtnExit.Enabled = True
            Me.MnuiNew.Enabled = True
            Me.MnuiSave.Enabled = False
            Me.MnuiCancel.Enabled = False
            Me.MnuiExit.Enabled = True
        End If
    End Sub

#End Region

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbPzlxjc.KeyPress, TxtDjh.KeyPress, DtpFprq.KeyPress, TxtZydm.KeyPress, TxtKhdm.KeyPress, TxtYspz.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If (Me.ActiveControl.GetType.Name = "DataGridViewTextBoxEditingControl" Or Me.rcDataGridView.Focused) Then
            Select Case keyData
                Case Keys.Enter, Keys.Right
                    SendKeys.Send("{TAB}")
                    Return True
                Case Keys.Left
                    SendKeys.Send("+{TAB}")
                    Return True
            End Select
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

#End Region

#Region "单据类型的事件"

    Private Sub CmbPzlxjc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbPzlxjc.Validated
        ShowNewDjh()
    End Sub

#End Region

#Region "单据号的事件"

    Private Sub TxtDjh_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDjh.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtDjh_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtDjh.Validating
        If Me.TxtDjh.TextLength <> 15 Then
            e.Cancel = True
            Return
        End If
        '判断增加还是修改
        If rcDataset.Tables("rc_pzno").Rows.Count > 0 Then
            If rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") >= Mid(Trim(Me.TxtDjh.Text), 15, 5) Then
                '1)修改单据
                Try
                    rcOleDbConn.Open()
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    rcOleDbCommand.CommandText = "SELECT oe_fp.djh,oe_fp.fprq,oe_fp.bdelete,oe_fp.zydm,oe_fp.zymc,oe_fp.khdm,oe_fp.khmc,oe_fp.yspz,oe_fp.srr,oe_fp.shr,oe_fp.jzr,oe_fp.skje FROM oe_fp WHERE (djh = ? )"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.TxtDjh.Text
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("rc_fpnr") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_fpnr").Clear()
                    End If
                    If rcDataset.Tables("rc_fpml") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_fpml").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "rc_fpml")
                    If rcDataset.Tables("rc_fpml").Rows.Count > 0 Then
                        '已收款不能修改
                        Dim blnSk As Boolean = False
                        Dim i As Integer
                        For i = 0 To rcDataset.Tables("rc_fpml").Rows.Count - 1
                            If rcDataset.Tables("rc_fpml").Rows(i).Item("skje").GetType.ToString <> "System.DBNull" Then
                                If rcDataset.Tables("rc_fpml").Rows(i).Item("skje") <> 0 Then
                                    blnSk = True
                                End If
                            End If
                        Next
                        If blnSk Then
                            MsgBox("该单据已经收款，不能修改。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                            Me.TxtDjh.Text = rcDataset.Tables("rc_pzno").Rows(0).Item("pzlxdm") & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                        Else
                            If rcDataset.Tables("rc_fpml").Rows(0).Item("jzr").GetType.ToString <> "System.DBNull" Then
                                MsgBox("该单据已经记账，不能修改。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                                Me.TxtDjh.Text = rcDataset.Tables("rc_pzno").Rows(0).Item("pzlxdm") & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                            Else
                                If rcDataset.Tables("rc_fpml").Rows(0).Item("shr").GetType.ToString <> "System.DBNull" Then
                                    MsgBox("该单据已经审核，不能修改。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                                    TxtDjh.Text = rcDataset.Tables("rc_pzno").Rows(0).Item("pzlxdm") & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                                Else

                                    Me.DtpFprq.Value = rcDataset.Tables("rc_fpml").Rows(0).Item("fprq")
                                    Me.LblBdelete.Text = IIf(rcDataset.Tables("rc_fpml").Rows(0).Item("bdelete"), "作废", "")
                                    If rcDataset.Tables("rc_fpml").Rows(0).Item("zydm").GetType.ToString <> "System.DBNull" Then
                                        Me.TxtZydm.Text = rcDataset.Tables("rc_fpml").Rows(0).Item("zydm")
                                    End If
                                    If rcDataset.Tables("rc_fpml").Rows(0).Item("zymc").GetType.ToString <> "System.DBNull" Then
                                        Me.LblZymc.Text = rcDataset.Tables("rc_fpml").Rows(0).Item("zymc")
                                    End If
                                    If rcDataset.Tables("rc_fpml").Rows(0).Item("khdm").GetType.ToString <> "System.DBNull" Then
                                        Me.TxtKhdm.Text = rcDataset.Tables("rc_fpml").Rows(0).Item("khdm")
                                    End If
                                    If rcDataset.Tables("rc_fpml").Rows(0).Item("khmc").GetType.ToString <> "System.DBNull" Then
                                        Me.LblKhmc.Text = rcDataset.Tables("rc_fpml").Rows(0).Item("khmc")
                                    End If
                                    If rcDataset.Tables("rc_fpml").Rows(0).Item("yspz").GetType.ToString <> "System.DBNull" Then
                                        Me.TxtYspz.Text = rcDataset.Tables("rc_fpml").Rows(0).Item("yspz")
                                    End If
                                    '修改单据
                                    rcOleDbCommand.CommandText = "SELECT oe_fp.cpdm,rc_cpxx.oldcpdm,rc_cpxx.cpmc,COALESCE(oe_fp.hth,'') AS hth,oe_fp.sl,oe_fp.dw,oe_fp.mjsl,oe_fp.fzsl,oe_fp.fzdw,oe_fp.dj,oe_fp.hsdj,oe_fp.je,oe_fp.shlv,oe_fp.se,(oe_fp.je+ oe_fp.se) AS jese,oe_fp.fpmemo,oe_fp.dddjh,oe_fp.ddxh,oe_fp.xsddjh,oe_fp.xsdxh,oe_fp.xsddj,oe_fp.xsdhsdj,oe_fp.xsdje,oe_fp.xsdshlv,oe_fp.xsdse FROM oe_fp,rc_cpxx WHERE oe_fp.cpdm = rc_cpxx.cpdm AND (oe_fp.djh = ?) ORDER BY oe_fp.xh"
                                    rcOleDbCommand.Parameters.Clear()
                                    rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = TxtDjh.Text
                                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                    If rcDataset.Tables("rc_fpnr") IsNot Nothing Then
                                        Me.rcDataset.Tables("rc_fpnr").Clear()
                                    End If
                                    rcOleDbDataAdpt.Fill(rcDataset, "rc_fpnr")
                                    If rcDataset.Tables("rc_fpnr").Rows.Count > 0 Then
                                        If rcDataset.Tables("rc_fpnr").Rows(0).Item("dddjh").GetType.ToString <> "System.DBNull" Then
                                            blnReCalculate = False
                                            'Me.BtnImp.Enabled = False
                                            Me.rcDataGridView.AllowUserToAddRows = False
                                            Me.ColCpdm.ReadOnly = True
                                            'Me.ColSl.ReadOnly = True
                                            'Me.ColMjsl.ReadOnly = True
                                            'Me.ColFzsl.ReadOnly = True
                                            Me.BtnIns.Enabled = False
                                            Me.MnuiIns.Enabled = False
                                        Else
                                            blnReCalculate = True
                                        End If
                                    Else
                                        blnReCalculate = True
                                    End If
                                    SumSlJe() '数量金额合计
                                    IsAdding = False
                                End If
                            End If
                        End If
                    End If
                Catch ex As Exception
                    MsgBox("程序错误。" & Chr(13) & ex.Message)
                Finally
                    rcOleDbConn.Close()
                End Try
            Else
                '2)新增单据
                IsAdding = True
            End If
        End If
        If IsAdding Then
            NewEvent()
        End If
        Me.rcDataGridView.ClearSelection()
    End Sub

#End Region

#Region "计算合计数"

    Private Sub SumSlJe()
        '计算合计数
        dblTotalSl = 0.0
        dblTotalFzsl = 0.0
        dblTotalJe = 0.0
        dblTotalSe = 0.0
        If rcDataset.Tables("rc_fpnr").Rows.Count > 0 Then
            dblTotalSl = rcDataset.Tables("rc_fpnr").Compute("Sum(sl)", "")
            dblTotalFzsl = rcDataset.Tables("rc_fpnr").Compute("Sum(fzsl)", "")
            dblTotalJe = rcDataset.Tables("rc_fpnr").Compute("Sum(je)", "")
            dblTotalSe = rcDataset.Tables("rc_fpnr").Compute("Sum(se)", "")
        End If
        Me.LblSl.Text = "数量合计：" + Format(dblTotalSl, g_FormatSl)
        Me.LblFzsl.Text = "辅数量合计：" + Format(dblTotalFzsl, g_FormatSl)
        Me.LblJe.Text = "金额合计：" + Format(dblTotalJe, g_FormatJe)
        Me.LblSe.Text = "税额合计：" + Format(dblTotalSe, g_FormatJe)
        Me.LblJese.Text = "价税合计：" + Format(dblTotalJe + dblTotalSe, g_FormatJe)
    End Sub

#End Region

#Region "发票日期事件"

    Private Sub DtpFprq_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DtpFprq.Validating
        '检查会计期间
        Dim dateBegin As DateTime
        Dim dateEnd As DateTime
        dateBegin = GetInvBegin(strYear, strMonth)
        dateEnd = GetInvEnd(strYear, strMonth)
        If DtpFprq.Value > dateEnd Or DtpFprq.Value < dateBegin Then
            MsgBox("您输入的日期不在当前会计期间中，请重输入。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            e.Cancel = True
        End If
    End Sub

#End Region

#Region "职员编码的事件"

    Private Sub TxtZydm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtZydm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_zyxx"
                    .paraField1 = "zydm"
                    .paraField2 = "zymc"
                    .paraField3 = "zysm"
                    .paraOrderField = "zymc"
                    .paraTitle = "职员"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtZydm.Text = Trim(.paraField1)
                        Me.LblZymc.Text = Trim(.paraField2)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtZydm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtZydm.Validating
        If Not String.IsNullOrEmpty(Me.TxtZydm.Text) Then
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "SELECT rc_zyxx.zydm,rc_zyxx.zymc FROM rc_zyxx WHERE (zydm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(Me.TxtZydm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_zyxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_zyxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_zyxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_zyxx").Rows.Count > 0 Then
                Me.TxtZydm.Text = Trim(rcDataset.Tables("rc_zyxx").Rows(0).Item("zydm"))
                Me.LblZymc.Text = Trim(rcDataset.Tables("rc_zyxx").Rows(0).Item("zymc"))
            Else
                MsgBox("职员编码不存在，请重输入。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
                e.Cancel = True
            End If
        End If
        If Not String.IsNullOrEmpty(Me.TxtZydm.Text) Then
            If Not IsEditing Then
                IsEditing = True
                SetControlEnableEvent()
            End If
        End If
    End Sub

#End Region

#Region "客户编码事件"

    Private Sub TxtKhdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtKhdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrmF3KeyPress As New models.FrmF3KeyPress
                With rcFrmF3KeyPress
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_khxx"
                    .paraField1 = "khdm"
                    .paraField2 = "khmc"
                    .paraField3 = "khsm"
                    .paraCondition = "0=0"
                    .paraOrderField = "khmc"
                    .paraTitle = "客户"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtKhdm.Text = Trim(.paraField1)
                        LblKhmc.Text = Trim(.paraField2)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtKhdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtKhdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtKhdm.Text) Then
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "SELECT * FROM rc_khxx WHERE (khdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(TxtKhdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_khxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_khxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_khxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message)
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_khxx").Rows.Count > 0 Then
                Me.TxtKhdm.Text = Trim(rcDataset.Tables("rc_khxx").Rows(0).Item("khdm"))
                Me.LblKhmc.Text = rcDataset.Tables("rc_khxx").Rows(0).Item("khmc")
                If String.IsNullOrEmpty(Me.TxtZydm.Text) Then
                    If rcDataset.Tables("rc_khxx").Rows(0).Item("zydm").GetType.ToString <> "System.DBNull" Then
                        Me.TxtZydm.Text = rcDataset.Tables("rc_khxx").Rows(0).Item("zydm")
                    End If
                    If rcDataset.Tables("rc_khxx").Rows(0).Item("zymc").GetType.ToString <> "System.DBNull" Then
                        Me.LblZymc.Text = rcDataset.Tables("rc_khxx").Rows(0).Item("zymc")
                    End If
                End If
            Else
                MsgBox("客户编码不存在，请重输入。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
                e.Cancel = True
            End If
        End If
        If Not String.IsNullOrEmpty(Me.TxtKhdm.Text) Then
            If Not IsEditing Then
                IsEditing = True
                SetControlEnableEvent()
            End If
        End If
    End Sub

#End Region

#Region "DataGridView的事件"

    'Private Sub rcDataGridView_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles rcDataGridView.CellEnter
    '    '如果此单元格只读的话则发送回车键。
    '    If Me.rcDataGridView.CurrentCell.ReadOnly Then My.Computer.Keyboard.SendKeys("{Enter}")
    'End Sub

    Private Sub RcDataGridView_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles rcDataGridView.CellValidating
        If Me.rcDataGridView.CurrentRow.IsNewRow = False Then
            If Me.rcDataGridView.IsCurrentCellDirty Then
                Me.rcDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColCpdm" Then
                If Not String.IsNullOrEmpty(e.FormattedValue) Then
                    If Not String.IsNullOrEmpty(e.FormattedValue) Then
                        '取产品信息
                        Try
                            rcOleDbConn.Open()
                            rcOleDbCommand.Connection = rcOleDbConn
                            rcOleDbCommand.CommandTimeout = 300
                            rcOleDbCommand.CommandType = CommandType.Text
                            rcOleDbCommand.CommandText = "SELECT * FROM rc_cpxx WHERE (rc_cpxx.cpdm = ? OR rc_cpxx.oldcpdm = ?) AND ty <> 1"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue
                            rcOleDbCommand.Parameters.Add("@oldcpdm", OleDbType.VarChar, 15).Value = rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                                rcDataset.Tables("rc_cpxx").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
                            If rcDataset.Tables("rc_cpxx").Rows.Count > 0 Then
                                Me.rcDataGridView.CurrentRow.Cells("ColCpdm").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("cpdm")
                                Me.rcDataGridView.CurrentRow.Cells("ColCpmc").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("cpmc")
                                Me.rcDataGridView.CurrentRow.Cells("ColDw").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("dw")
                                If rcDataset.Tables("rc_cpxx").Rows(0).Item("mjsl").GetType.ToString <> "System.DBNull" And Me.rcDataGridView.CurrentRow.Cells("ColMjsl").Value = 0 Then
                                    Me.rcDataGridView.CurrentRow.Cells("ColMjsl").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("mjsl")
                                End If
                                If rcDataset.Tables("rc_cpxx").Rows(0).Item("fzdw").GetType.ToString <> "System.DBNull" Then
                                    Me.rcDataGridView.CurrentRow.Cells("ColFzdw").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("fzdw")
                                End If
                                rcOleDbCommand.CommandText = "SELECT COALESCE(Sum(qcsl+idsl),0.0) as kcsl FROM inv_cpyeb WHERE kjnd = ? AND cpdm = ?"
                                rcOleDbCommand.Parameters.Clear()
                                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = strYear
                                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue
                                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                If rcDataset.Tables("inv_cpyeb") IsNot Nothing Then
                                    rcDataset.Tables("inv_cpyeb").Clear()
                                End If
                                rcOleDbDataAdpt.Fill(rcDataset, "inv_cpyeb")
                                If rcDataset.Tables("inv_cpyeb").Rows.Count = 1 Then
                                    Me.LblMsg.Text = "当前库存数量：" & rcDataset.Tables("inv_cpyeb").Rows(0).Item("kcsl")
                                Else
                                    Me.LblMsg.Text = "当前库存数量： 0.00 "
                                End If
                                'If Me.rcDataGridView.CurrentRow.Cells("ColSl").Value = 0 And Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = 0 Then
                                '    If Not String.IsNullOrEmpty(Me.TxtKhdm.Text) Then
                                '        '取未出库订单号及未出库数量
                                '        rcOleDbCommand.CommandText = "SELECT khdm,cpdm,hth,sl - hxsl - cksl AS wcksl,dj,oe_dd.djh AS dddjh,oe_dd.xh AS ddxh FROM oe_dd WHERE khdm = ? AND cpdm = ? AND sl - hxsl - cksl > 0 ORDER BY qdrq,xh"
                                '        rcOleDbCommand.Parameters.Clear()
                                '        rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Me.TxtKhdm.Text
                                '        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("rc_cpxx").Rows(0).Item("cpdm")
                                '        If Not rcDataSet.Tables("oe_dd") Is Nothing Then
                                '            rcDataSet.Tables("oe_dd").Clear()
                                '        End If
                                '        rcOleDbDataAdpt.Fill(rcDataSet, "oe_dd")
                                '        If rcDataSet.Tables("oe_dd").Rows.Count > 0 Then
                                '            Me.rcDataGridView.CurrentRow.Cells("ColHth").Value = rcDataSet.Tables("oe_dd").Rows(0).Item("hth")
                                '            Me.rcDataGridView.CurrentRow.Cells("ColSl").Value = rcDataSet.Tables("oe_dd").Rows(0).Item("wcksl")
                                '            Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = rcDataSet.Tables("oe_dd").Rows(0).Item("dj")
                                '        End If
                                '    End If
                                'End If
                            Else
                                Me.LblMsg.Text = "产品编码不存在。"
                                e.Cancel = True
                            End If
                        Catch ex As Exception
                            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                            Return
                        Finally
                            rcOleDbConn.Close()
                        End Try
                    End If
                End If
            End If
            '订单号事件
            'If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColHth" Then
            '    If Not String.IsNullOrEmpty(e.FormattedValue) Then
            '        If Not String.IsNullOrEmpty(e.FormattedValue) And Not String.IsNullOrEmpty(Me.rcDataGridView.CurrentRow.Cells("ColCpdm").Value) Then
            '            '取合同未出库数量d
            '            Try
            '                rcOleDbConn.Open()
            '                rcOleDbCommand.Connection = rcOleDbConn
            '                rcOleDbCommand.CommandTimeout = 300
            '                rcOleDbCommand.CommandType = CommandType.Text
            '                rcOleDbCommand.CommandText = "SELECT sl - hxsl - cksl AS wcksl,dj FROM oe_dd WHERE sl-hxsl-cksl > 0 AND khdm = ? AND cpdm = ? AND hth = ? ORDER BY qdrq,xh"
            '                rcOleDbCommand.Parameters.Clear()
            '                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Me.TxtKhdm.Text
            '                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Me.rcDataGridView.CurrentRow.Cells("ColCpdm").Value
            '                rcOleDbCommand.Parameters.Add("@hth", OleDbType.VarChar, 30).Value = rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColHth").EditedFormattedValue
            '                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            '                If Not rcDataSet.Tables("oe_dd") Is Nothing Then
            '                    rcDataSet.Tables("oe_dd").Clear()
            '                End If
            '                rcOleDbDataAdpt.Fill(rcDataSet, "oe_dd")
            '                If rcDataSet.Tables("oe_dd").Rows.Count > 0 Then
            '                    If Me.rcDataGridView.CurrentRow.Cells("ColSl").Value = 0 Then
            '                        Me.rcDataGridView.CurrentRow.Cells("ColSl").Value = rcDataSet.Tables("oe_dd").Rows(0).Item("wcksl")
            '                    End If
            '                    Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = rcDataSet.Tables("oe_dd").Rows(0).Item("dj")
            '                    Me.rcDataGridView.CurrentRow.Cells("ColJe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColDj").Value * Me.rcDataGridView.CurrentRow.Cells("ColSl").Value, 2, MidpointRounding.AwayFromZero)
            '                End If
            '            Catch ex As Exception
            '                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            '                Return
            '            Finally
            '                rcOleDbConn.Close()
            '            End Try
            '        End If
            '    End If
            'End If
            '数量事件
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColSl" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    If Me.rcDataGridView.CurrentRow.Cells("ColDj").Value <> 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColJe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColDj").Value * e.FormattedValue, 2, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColSe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColDj").Value * e.FormattedValue * Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value / 100, 2, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColJese").Value = Me.rcDataGridView.CurrentRow.Cells("ColJe").Value + Me.rcDataGridView.CurrentRow.Cells("ColSe").Value
                    End If
                    If Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value <> 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColJese").Value = System.Math.Round(e.FormattedValue * Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value, 2, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColJe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColJese").Value / (1 + Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value / 100), 2, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColSe").Value = Me.rcDataGridView.CurrentRow.Cells("ColJese").Value - Me.rcDataGridView.CurrentRow.Cells("ColJe").Value
                    End If
                    If Me.rcDataGridView.CurrentRow.Cells("ColXsdDj").Value <> 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColXsdJe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColXsdDj").Value * e.FormattedValue, 2, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColXsdSe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColXsdDj").Value * e.FormattedValue * Me.rcDataGridView.CurrentRow.Cells("ColXsdShlv").Value / 100, 2, MidpointRounding.AwayFromZero)
                    End If
                    If Me.rcDataGridView.CurrentRow.Cells("ColXsdHsdj").Value <> 0 Then
                        Dim dblJese As Double
                        dblJese = System.Math.Round(e.FormattedValue * Me.rcDataGridView.CurrentRow.Cells("ColXsdHsdj").Value, 2, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColXsdJe").Value = System.Math.Round(System.Math.Round(e.FormattedValue * Me.rcDataGridView.CurrentRow.Cells("ColXsdHsdj").Value, 2, MidpointRounding.AwayFromZero) / (1 + Me.rcDataGridView.CurrentRow.Cells("ColXsdShlv").Value / 100), 2, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColXsdSe").Value = System.Math.Round(e.FormattedValue * Me.rcDataGridView.CurrentRow.Cells("ColXsdHsdj").Value - Me.rcDataGridView.CurrentRow.Cells("ColXsdJe").Value, 2, MidpointRounding.AwayFromZero)
                    End If
                    If Me.rcDataGridView.CurrentRow.Cells("ColMjsl").Value <> 0 Then
                        If e.FormattedValue <> 0 Then
                            If Me.rcDataGridView.CurrentRow.Cells("ColFzsl").Value = 0 Then
                                Me.rcDataGridView.CurrentRow.Cells("ColFzsl").Value = e.FormattedValue * Me.rcDataGridView.CurrentRow.Cells("ColMjsl").Value
                            End If
                        End If
                    End If
                Else
                    Me.rcDataGridView.CurrentRow.Cells("ColSl").Value = 0.0
                End If
                '开票数量只能小于等于,不能大于订单数量
                If Me.rcDataGridView.CurrentRow.Cells("ColDdDjh").Value.GetType.ToString <> "System.DBNull" Then
                    If Me.rcDataGridView.CurrentRow.Cells("ColDdDjh").Value <> "" Then
                        Try
                            rcOleDbConn.Open()
                            rcOleDbCommand.Connection = rcOleDbConn
                            rcOleDbCommand.CommandTimeout = 300
                            rcOleDbCommand.CommandType = CommandType.Text
                            '取物料销售订单的数量
                            rcOleDbCommand.CommandText = "SELECT COALESCE(SUM(sl),0.0) AS ddsl,COALESCE(SUM(je),0.0) AS ddje,COALESCE(SUM(se),0.0) AS ddse FROM oe_dd WHERE djh = ? AND xh = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.rcDataGridView.CurrentRow.Cells("ColDdDjh").Value
                            rcOleDbCommand.Parameters.Add("@xh", OleDbType.Numeric, 4).Value = Me.rcDataGridView.CurrentRow.Cells("ColDdXh").Value
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("t_dd") IsNot Nothing Then
                                rcDataset.Tables("t_dd").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "t_dd")
                            '取物料销售订单的已开票数量
                            rcOleDbCommand.CommandText = "SELECT COALESCE(SUM(sl),0.0) AS fpsl,COALESCE(SUM(je),0.0) AS fpje,COALESCE(SUM(se),0.0) AS fpse FROM oe_fp WHERE oe_fp.bdelete = 0 AND djh <> ? AND dddjh = ? AND ddxh = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.TxtDjh.Text
                            rcOleDbCommand.Parameters.Add("@dddjh", OleDbType.VarChar, 15).Value = Me.rcDataGridView.CurrentRow.Cells("ColDdDjh").Value
                            rcOleDbCommand.Parameters.Add("@ddxh", OleDbType.Numeric, 4).Value = Me.rcDataGridView.CurrentRow.Cells("ColDdXh").Value
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("t_fp") IsNot Nothing Then
                                rcDataset.Tables("t_fp").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "t_fp")
                        Catch ex As Exception
                            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                            Return
                        Finally
                            rcOleDbConn.Close()
                        End Try
                        If rcDataset.Tables("t_dd").Rows(0).Item("ddsl") - rcDataset.Tables("t_fp").Rows(0).Item("fpsl") < e.FormattedValue And e.FormattedValue > 0 Then
                            MsgBox("销售发票数量大于销售订单数量，请检查。", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示信息")
                            e.Cancel = True
                            'End If
                        End If
                        '当发票数量为刚好开完时。
                        If rcDataset.Tables("t_dd").Rows(0).Item("ddsl") - rcDataset.Tables("t_fp").Rows(0).Item("fpsl") = e.FormattedValue Then
                            Me.rcDataGridView.CurrentRow.Cells("ColXsdJe").Value = rcDataset.Tables("t_dd").Rows(0).Item("ddje") - rcDataset.Tables("t_fp").Rows(0).Item("fpje")
                            Me.rcDataGridView.CurrentRow.Cells("ColXsdSe").Value = rcDataset.Tables("t_dd").Rows(0).Item("ddse") - rcDataset.Tables("t_fp").Rows(0).Item("fpse")
                        End If
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColMjsl" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    If e.FormattedValue <> 0 Then
                        If Me.rcDataGridView.CurrentRow.Cells("ColFzsl").Value = 0 Then
                            Me.rcDataGridView.CurrentRow.Cells("ColFzsl").Value = Me.rcDataGridView.CurrentRow.Cells("ColSl").Value * e.FormattedValue
                        End If
                    End If
                Else
                    Me.rcDataGridView.CurrentRow.Cells("ColMjsl").Value = 0.0
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColDj" Then
                If blnReCalculate Then
                    If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                        '录入含税单价优先
                        If e.FormattedValue <> 0 Then
                            Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value = System.Math.Round(e.FormattedValue * (1 + Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value / 100), 6, MidpointRounding.AwayFromZero)
                            Me.rcDataGridView.CurrentRow.Cells("ColJe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColSl").Value * e.FormattedValue, 2, MidpointRounding.AwayFromZero)
                            Me.rcDataGridView.CurrentRow.Cells("ColSe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColSl").Value * e.FormattedValue * Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value / 100, 2, MidpointRounding.AwayFromZero)
                            Me.rcDataGridView.CurrentRow.Cells("ColJese").Value = Me.rcDataGridView.CurrentRow.Cells("ColJe").Value + Me.rcDataGridView.CurrentRow.Cells("ColSe").Value
                        End If
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColHsdj" Then
                If blnReCalculate Then
                    If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                        Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = System.Math.Round(e.FormattedValue / (1 + Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value / 100), 6, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColJe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColSl").Value * e.FormattedValue / (1 + Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value / 100), 2, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColJese").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColSl").Value * e.FormattedValue, 2, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColSe").Value = Me.rcDataGridView.CurrentRow.Cells("ColJese").Value - Me.rcDataGridView.CurrentRow.Cells("ColJe").Value
                    Else
                        Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value = 0.0
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColShlv" Then
                If blnReCalculate Then
                    If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                        If Me.rcDataGridView.CurrentRow.Cells("ColJe").Value <> 0 Then
                            Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColJese").Value / Me.rcDataGridView.CurrentRow.Cells("ColSl").Value, 6, MidpointRounding.AwayFromZero)
                            Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value / (1 + e.FormattedValue / 100), 6, MidpointRounding.AwayFromZero)
                            Me.rcDataGridView.CurrentRow.Cells("ColJe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColSl").Value * Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value / (1 + e.FormattedValue / 100), 2, MidpointRounding.AwayFromZero)
                            Me.rcDataGridView.CurrentRow.Cells("ColSe").Value = Me.rcDataGridView.CurrentRow.Cells("ColJese").Value - Me.rcDataGridView.CurrentRow.Cells("ColJe").Value
                            'Me.rcDataGridView.CurrentRow.Cells("ColJese").Value = Me.rcDataGridView.CurrentRow.Cells("ColJe").Value + Me.rcDataGridView.CurrentRow.Cells("ColSe").Value
                        End If
                    Else
                        Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value = GetParaValue("增值税默认税率", False)
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColJe" Then
                If blnReCalculate Then
                    If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                        If e.FormattedValue <> 0 And Me.rcDataGridView.CurrentRow.Cells("ColSl").Value <> 0 Then
                            If System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColDj").Value * Me.rcDataGridView.CurrentRow.Cells("ColSl").Value, 2, MidpointRounding.AwayFromZero) <> e.FormattedValue Then
                                Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = Round(e.FormattedValue / Me.rcDataGridView.CurrentRow.Cells("ColSl").Value, 6, MidpointRounding.AwayFromZero)
                                Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value = Round(Me.rcDataGridView.CurrentRow.Cells("ColDj").Value * (Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value / 100 + 1), 6, MidpointRounding.AwayFromZero)
                            End If
                            Me.rcDataGridView.CurrentRow.Cells("ColSe").Value = Me.rcDataGridView.CurrentRow.Cells("ColJese").Value - Me.rcDataGridView.CurrentRow.Cells("ColJe").Value
                            'Me.rcDataGridView.CurrentRow.Cells("ColJese").Value = e.FormattedValue + Me.rcDataGridView.CurrentRow.Cells("ColSe").Value
                        End If
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColSe" Then
                If blnReCalculate Then
                    If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                        If Me.rcDataGridView.CurrentRow.Cells("ColJe").Value <> 0 Then
                            Me.rcDataGridView.CurrentRow.Cells("ColJese").Value = e.FormattedValue + Me.rcDataGridView.CurrentRow.Cells("ColJe").Value
                            'Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColJese").Value / Me.rcDataGridView.CurrentRow.Cells("ColSl").Value, 6, MidpointRounding.AwayFromZero)
                        End If
                    Else
                        Me.rcDataGridView.CurrentRow.Cells("ColSe").Value = 0.0
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColJese" Then
                If blnReCalculate Then
                    If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                        If Me.rcDataGridView.CurrentRow.Cells("ColSl").Value <> 0 And Me.rcDataGridView.CurrentRow.Cells("ColJe").Value + Me.rcDataGridView.CurrentRow.Cells("ColSe").Value <> e.FormattedValue Then
                            Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = Round(e.FormattedValue / Me.rcDataGridView.CurrentRow.Cells("ColSl").Value / (1 + Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value / 100), 6, MidpointRounding.AwayFromZero)
                            Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value = Round(e.FormattedValue / Me.rcDataGridView.CurrentRow.Cells("ColSl").Value, 6, MidpointRounding.AwayFromZero)
                            Me.rcDataGridView.CurrentRow.Cells("ColJe").Value = Round(e.FormattedValue / (1 + Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value / 100), 2, MidpointRounding.AwayFromZero)
                            Me.rcDataGridView.CurrentRow.Cells("ColSe").Value = e.FormattedValue - Me.rcDataGridView.CurrentRow.Cells("ColJe").Value
                        End If
                    Else
                        Me.rcDataGridView.CurrentRow.Cells("ColJese").Value = 0.0
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub RcDataGridView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rcDataGridView.KeyDown
        Select Case e.KeyCode
            Case Keys.C And e.Control
                '复制
                Clipboard.SetDataObject(Me.rcDataGridView.GetClipboardContent())
            Case Keys.V And e.Control
                '粘贴
                Me.rcDataGridView.CurrentCell.Value = Clipboard.GetText()
                Me.rcBindingSource.EndEdit()
                Me.rcDataGridView.EndEdit()
        End Select
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColCpdm" And Me.ColCpdm.ReadOnly = False Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF34
                    With rcFrm
                        .paraOleDbConn = rcOleDbConn
                        .paraTableName = "rc_cpxx"
                        .paraField1 = "cpdm"
                        .paraField2 = "cpmc"
                        .paraField3 = "dw"
                        .paraField4 = "cpsm"
                        .paraOrderField = "cpmc"
                        .paraTitle = "物料"
                        .paraOldValue = ""
                        .paraAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            '将用户在rcfrmselectcpdm所选择的cpdm带入rcdatarid'
                            Me.rcDataGridView.CurrentRow.Cells("ColCpdm").Value = .paraField1
                            Me.rcBindingSource.EndEdit()
                            Me.rcDataGridView.EndEdit()
                        End If
                    End With
            End Select
        End If
    End Sub

    Private Sub RcDataGridView_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles rcDataGridView.EditingControlShowing
        EditingControl = e.Control
        If Not EditingControl.IsHandleCreated Then
            AddHandler EditingControl.KeyDown, New KeyEventHandler(AddressOf EditingControl_KeyDown)
        End If
        If Me.rcDataGridView.CurrentCell.OwningColumn.Name = "ColCpdm" Or Me.rcDataGridView.CurrentCell.OwningColumn.Name = "ColKhdm" Then
            EditingControl.CharacterCasing = CharacterCasing.Upper
        Else
            EditingControl.CharacterCasing = CharacterCasing.Normal
        End If
    End Sub

    Private Sub EditingControl_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColCpdm" And Me.ColCpdm.ReadOnly = False Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF34
                    With rcFrm
                        .paraOleDbConn = rcOleDbConn
                        .paraTableName = "rc_cpxx"
                        .paraField1 = "cpdm"
                        .paraField2 = "cpmc"
                        .paraField3 = "dw"
                        .paraField4 = "cpsm"
                        .paraOrderField = "cpmc"
                        .paraTitle = "物料"
                        .paraOldValue = ""
                        .paraAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            '将用户在rcfrmselectcpdm所选择的cpdm带入rcdatarid'
                            Me.rcDataGridView.CurrentRow.Cells("ColCpdm").Value = .paraField1
                            Me.rcDataGridView.EndEdit()
                            Me.rcBindingSource.EndEdit()
                        End If
                    End With
                    e.Handled = True
            End Select
        End If
    End Sub

    Private Sub RcDataGridView_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles rcDataGridView.Leave
        Me.rcDataGridView.ClearSelection()
    End Sub

    Private Sub RcDataGridView_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles rcDataGridView.RowValidating
        If Not Me.rcDataGridView.CurrentRow.IsNewRow Then
            Me.rcBindingSource.EndEdit()
            Me.rcDataGridView.EndEdit()
        End If
        If dtXsd.Rows.Count > 0 Then
            IsEditing = True
            SetControlEnableEvent()
            SumSlJe()
        End If
    End Sub

#End Region

#Region "导入产品送货单"

    Private Sub BtnImpXsd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImpXsd.Click
        If Not String.IsNullOrEmpty(Me.TxtKhdm.Text) Then
            '调用表单
            Dim rcFrm As New FrmOeFpImpXsd
            With rcFrm
                .ParaStrKhdm = Me.TxtKhdm.Text
                .ParaDataSet = rcDataset
                .ShowDialog()
                Me.rcDataGridView.AllowUserToAddRows = False
                Me.ColCpdm.ReadOnly = True
                'Me.ColSl.ReadOnly = True
                'Me.ColMjsl.ReadOnly = True
                'Me.ColFzsl.ReadOnly = True
                Me.BtnIns.Enabled = False
                Me.MnuiIns.Enabled = False
                blnReCalculate = False
            End With
            Me.rcDataGridView.Focus()
        Else
            MsgBox("请先选择客户编码。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
        End If
    End Sub

#End Region

#Region "导入产品销售订单"

    Private Sub BtnImpDd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImpDd.Click
        If Not String.IsNullOrEmpty(Me.TxtKhdm.Text) Then
            '调用表单
            Dim rcFrm As New FrmOeFpImpDd
            With rcFrm
                .ParaStrKhdm = Me.TxtKhdm.Text
                .ParaDataSet = rcDataset
                .ShowDialog()
                Me.rcDataGridView.AllowUserToAddRows = False
                Me.ColCpdm.ReadOnly = True
                'Me.ColSl.ReadOnly = True
                'Me.ColMjsl.ReadOnly = True
                'Me.ColFzsl.ReadOnly = True
                Me.BtnIns.Enabled = False
                Me.MnuiIns.Enabled = False
                blnReCalculate = False
            End With
            Me.rcDataGridView.Focus()
        Else
            MsgBox("请先选择客户编码。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
        End If
    End Sub

#End Region

#Region "新单事件"

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, MnuiNew.Click
        NewEvent()
        Me.TxtDjh.Focus()
    End Sub

    Private Sub NewEvent()
        '清空数据
        Me.LblBdelete.Text = ""
        Me.TxtZydm.Text = ""
        Me.LblZymc.Text = ""
        Me.TxtKhdm.Text = ""
        Me.LblKhmc.Text = ""
        Me.TxtYspz.Text = ""
        IsAdding = True
        IsEditing = False
        Me.LblMsg.Text = "（此处显示各销售要素的详细内容。）"
        Me.LblSl.Text = "数量合计："
        Me.LblFzsl.Text = "辅数量合计："
        Me.LblJe.Text = "金额合计："
        Me.LblSe.Text = "税额合计："
        Me.LblJese.Text = "价税合计："
        Me.BtnImpXsd.Enabled = True
        Me.BtnImpDd.Enabled = True
        Me.rcDataGridView.AllowUserToAddRows = True
        Me.ColCpdm.ReadOnly = False
        Me.BtnIns.Enabled = True
        Me.MnuiIns.Enabled = True
        blnReCalculate = True
        '显示新单据号
        ShowNewDjh()
        '清空数据
        If rcDataset.Tables("rc_fpnr") IsNot Nothing Then
            Me.rcDataset.Tables("rc_fpnr").Clear()
        End If
    End Sub

    Private Sub ShowNewDjh()
        '取单据类型数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzno" & strMonth & " as pzno,bfushu FROM rc_lx WHERE pzlxdm = ? and lxgs = '产品销售单' and kjnd = '" & strYear & "'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@pzlxdm", OleDbType.VarChar, 4).Value = Trim(Me.CmbPzlxjc.SelectedValue)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_pzno") IsNot Nothing Then
                Me.rcDataset.Tables("rc_pzno").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_pzno")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message)
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_pzno").Rows.Count = 0 Then
            MsgBox("请定义单据类型。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        Me.TxtDjh.Text = rcDataset.Tables("rc_pzno").Rows(0).Item("pzlxdm") & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
    End Sub

#End Region

#Region "保存事件"

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MnuiSave.Click
        SaveEvent(False)
    End Sub

    Private Sub SaveEvent(ByVal blnPrint As Boolean)
        Dim i As Integer
        '(一)数据合法性检查
        If String.IsNullOrEmpty(Me.TxtZydm.Text) Then
            MsgBox("请输入经手人。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Return
        End If
        '(2)客户编码
        If String.IsNullOrEmpty(Me.TxtKhdm.Text) Then
            MsgBox("请输入客户编码。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Return
        End If
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 12).Value = Trim(Me.TxtKhdm.Text)
            rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_khxx"
            rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "khdm"
            rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
            rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
            rcOleDbCommand.ExecuteNonQuery()
            If rcOleDbCommand.Parameters("@paraIntRecordCount").Value <> 1 Then
                MsgBox("客户编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                Return
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '(5)DataTable赋默认值
        For i = 0 To rcDataset.Tables("rc_fpnr").Rows.Count - 1
            If rcDataset.Tables("rc_fpnr").Rows(i).Item("cpdm").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_fpnr").Rows(i).Item("cpdm") = ""
            End If
            If rcDataset.Tables("rc_fpnr").Rows(i).Item("cpmc").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_fpnr").Rows(i).Item("cpmc") = ""
            End If
            If rcDataset.Tables("rc_fpnr").Rows(i).Item("hth").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_fpnr").Rows(i).Item("hth") = ""
            End If
            If rcDataset.Tables("rc_fpnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_fpnr").Rows(i).Item("sl") = 0.0
            End If
            If rcDataset.Tables("rc_fpnr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_fpnr").Rows(i).Item("dw") = ""
            End If
            If rcDataset.Tables("rc_fpnr").Rows(i).Item("mjsl").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_fpnr").Rows(i).Item("mjsl") = 0.0
            End If
            If rcDataset.Tables("rc_fpnr").Rows(i).Item("fzsl").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_fpnr").Rows(i).Item("fzsl") = 0.0
            End If
            If rcDataset.Tables("rc_fpnr").Rows(i).Item("fzdw").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_fpnr").Rows(i).Item("fzdw") = ""
            End If
            If rcDataset.Tables("rc_fpnr").Rows(i).Item("dj").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_fpnr").Rows(i).Item("dj") = 0.0
            End If
            If rcDataset.Tables("rc_fpnr").Rows(i).Item("hsdj").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_fpnr").Rows(i).Item("hsdj") = 0.0
            End If
            If rcDataset.Tables("rc_fpnr").Rows(i).Item("je").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_fpnr").Rows(i).Item("je") = 0.0
            End If
            If rcDataset.Tables("rc_fpnr").Rows(i).Item("shlv").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_fpnr").Rows(i).Item("shlv") = 0.0
            End If
            If rcDataset.Tables("rc_fpnr").Rows(i).Item("se").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_fpnr").Rows(i).Item("se") = 0.0
            End If
            If rcDataset.Tables("rc_fpnr").Rows(i).Item("jese").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_fpnr").Rows(i).Item("jese") = 0.0
            End If
            If rcDataset.Tables("rc_fpnr").Rows(i).Item("fpmemo").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_fpnr").Rows(i).Item("fpmemo") = ""
            End If
            If rcDataset.Tables("rc_fpnr").Rows(i).Item("dddjh").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_fpnr").Rows(i).Item("dddjh") = ""
            End If
            If rcDataset.Tables("rc_fpnr").Rows(i).Item("ddxh").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_fpnr").Rows(i).Item("ddxh") = 0
            End If
            If rcDataset.Tables("rc_fpnr").Rows(i).Item("xsddjh").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_fpnr").Rows(i).Item("xsddjh") = ""
            End If
            If rcDataset.Tables("rc_fpnr").Rows(i).Item("xsdxh").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_fpnr").Rows(i).Item("xsdxh") = 0
            End If
            If rcDataset.Tables("rc_fpnr").Rows(i).Item("xsddj").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_fpnr").Rows(i).Item("xsddj") = 0.0
            End If
            If rcDataset.Tables("rc_fpnr").Rows(i).Item("xsdhsdj").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_fpnr").Rows(i).Item("xsdhsdj") = 0.0
            End If
            If rcDataset.Tables("rc_fpnr").Rows(i).Item("xsdje").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_fpnr").Rows(i).Item("xsdje") = 0.0
            End If
            If rcDataset.Tables("rc_fpnr").Rows(i).Item("xsdshlv").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_fpnr").Rows(i).Item("xsdshlv") = 0.0
            End If
            If rcDataset.Tables("rc_fpnr").Rows(i).Item("xsdse").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_fpnr").Rows(i).Item("xsdse") = 0.0
            End If
        Next

        '(1)是否有需要存储的数据
        If rcDataset.Tables("rc_fpnr").Rows.Count = 0 Then
            MsgBox("没有相应的业务，请输入。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Return
        End If

        '(3)产品编码
        rcOleDbConn.Open()
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            For i = 0 To rcDataset.Tables("rc_fpnr").Rows.Count - 1
                If rcDataset.Tables("rc_fpnr").Rows(i).RowState <> DataRowState.Deleted Then
                    rcOleDbCommand.CommandText = "SELECT * FROM rc_cpxx WHERE cpdm = ? AND ty <> 1"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.AddWithValue("@cpdm", Trim(rcDataset.Tables("rc_fpnr").Rows(i).Item("cpdm")))
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("cpdmcnt") IsNot Nothing Then
                        Me.rcDataset.Tables("cpdmcnt").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "cpdmcnt")

                    If rcDataset.Tables("cpdmcnt").Rows.Count <> 1 Then
                        MsgBox(Trim(rcDataset.Tables("rc_fpnr").Rows(i).Item("cpdm")) & "产品编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                        Return
                    End If
                    If rcDataset.Tables("rc_fpnr").Rows(i).Item("sl").GetType.ToString <> "System.DBNull" Then
                        If rcDataset.Tables("rc_fpnr").Rows(i).Item("sl") = 0 Then
                            MsgBox("销售数量为【零】，请输入数量。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                            Return
                        End If
                    Else
                        MsgBox("销售数量为【零】，请输入数量。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        Return
                    End If
                    If rcDataset.Tables("rc_pzno").Rows(0).Item("bfushu") = 1 And rcDataset.Tables("rc_fpnr").Rows(i).Item("sl") < 0 Then
                        MsgBox("销售数量禁止【小于零】，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        Return
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '(4)单据号长度检查
        If Trim(Me.TxtDjh.Text).Length <> 15 Then
            MsgBox("单据号长度不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Return
        End If
        '按订单号汇总
        '倒数据
        Dim dtCopy As DataTable
        Dim j As Integer
        Dim rcDataRow As DataRow
        Dim blnExists As Boolean
        dtCopy = rcDataset.Tables("rc_fpnr").Clone
        '倒数据
        '本月数据
        For j = 0 To rcDataset.Tables("rc_fpnr").Rows.Count - 1
            blnExists = False
            For i = 0 To dtCopy.Rows.Count - 1
                If dtCopy.Rows(i).Item("dddjh").GetType.ToString <> "System.DBNull" And rcDataset.Tables("rc_fpnr").Rows(j).Item("dddjh").GetType.ToString <> "System.DBNull" And dtCopy.Rows(i).Item("ddxh").GetType.ToString <> "System.DBNull" And rcDataset.Tables("rc_fpnr").Rows(j).Item("ddxh").GetType.ToString <> "System.DBNull" Then
                    If dtCopy.Rows(i).Item("dddjh") = rcDataset.Tables("rc_fpnr").Rows(j).Item("dddjh") And dtCopy.Rows(i).Item("ddxh") = rcDataset.Tables("rc_fpnr").Rows(j).Item("ddxh") Then
                        blnExists = True
                    End If
                End If
            Next
            If Not blnExists Then
                rcDataRow = dtCopy.NewRow
                rcDataRow.Item("cpdm") = rcDataset.Tables("rc_fpnr").Rows(j).Item("cpdm")
                rcDataRow.Item("cpmc") = rcDataset.Tables("rc_fpnr").Rows(j).Item("cpmc")
                rcDataRow.Item("sl") = 0
                rcDataRow.Item("dddjh") = rcDataset.Tables("rc_fpnr").Rows(j).Item("dddjh")
                rcDataRow.Item("ddxh") = rcDataset.Tables("rc_fpnr").Rows(j).Item("ddxh")
                dtCopy.Rows.Add(rcDataRow)
            End If
        Next
        If String.IsNullOrEmpty(Me.LblBdelete.Text) Then
            For j = 0 To dtCopy.Rows.Count - 1
                dtCopy.Rows(j).Item("sl") = System.Math.Round(rcDataset.Tables("rc_fpnr").Compute("SUM(sl)", "dddjh = '" & dtCopy.Rows(j).Item("dddjh") & "' and ddxh =" & dtCopy.Rows(j).Item("ddxh")), 6, MidpointRounding.AwayFromZero)
            Next
        End If

        '检查销售订单是否存在
        For i = 0 To dtCopy.Rows.Count - 1
            If Not String.IsNullOrEmpty(dtCopy.Rows(i).Item("dddjh")) Then
                Dim dblWrksl As Double
                dblWrksl = ReadOeWfpsl(dtCopy.Rows(i).Item("cpdm"), dtCopy.Rows(i).Item("dddjh"), dtCopy.Rows(i).Item("ddxh"), Me.TxtDjh.Text)
                If dblWrksl >= 0 And dtCopy.Rows(i).Item("sl") > 0 And dblWrksl < dtCopy.Rows(i).Item("sl") Then
                    MsgBox("该物料的销售订单可开票数量小于开票数量，请检查。" & Chr(13) & "物料编码：" & dtCopy.Rows(i).Item("cpdm") & Chr(13) & "订单单据号：" & dtCopy.Rows(i).Item("dddjh") & Chr(13) & "订单行号：" & dtCopy.Rows(i).Item("ddxh") & Chr(13) & "当前开票数量：" & dtCopy.Rows(i).Item("sl").ToString & Chr(13) & "可开票数量：" & dblWrksl.ToString, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                    Return
                End If
                If dblWrksl < 0 And dtCopy.Rows(i).Item("sl") < 0 And dblWrksl > dtCopy.Rows(i).Item("sl") Then
                    MsgBox("该物料的订单可开票数量小于开票数量，请检查。" & Chr(13) & "物料编码：" & dtCopy.Rows(i).Item("cpdm") & Chr(13) & "订单单据号：" & dtCopy.Rows(i).Item("dddjh") & Chr(13) & "订单行号：" & dtCopy.Rows(i).Item("ddxh") & Chr(13) & "当前开票数量：" & dtCopy.Rows(i).Item("sl").ToString & "可开票数量：" & dblWrksl.ToString, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                    Return
                End If
            End If
        Next


        '(二)存储ml
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP3_SAVE_OE_FP"
            For i = 0 To rcDataset.Tables("rc_fpnr").Rows.Count - 1
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = IIf(IsAdding, 1, 0)
                rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = Trim(Me.TxtDjh.Text)
                rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = i + 1
                rcOleDbCommand.Parameters.Add("@paraDateFprq", OleDbType.Date, 8).Value = Me.DtpFprq.Value
                rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = IIf(String.IsNullOrEmpty(Me.LblBdelete.Text), 0, 1)
                rcOleDbCommand.Parameters.Add("@paraStrZydm", OleDbType.VarChar, 12).Value = Me.TxtZydm.Text
                rcOleDbCommand.Parameters.Add("@paraStrZymc", OleDbType.VarChar, 30).Value = Me.LblZymc.Text
                rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = Me.TxtKhdm.Text
                rcOleDbCommand.Parameters.Add("@paraStrKhmc", OleDbType.VarChar, 50).Value = Me.LblKhmc.Text
                rcOleDbCommand.Parameters.Add("@paraStrYspz", OleDbType.VarChar, 30).Value = Me.TxtYspz.Text
                rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("rc_fpnr").Rows(i).Item("cpdm")).ToUpper
                rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("cpmc")
                rcOleDbCommand.Parameters.Add("@paraStrSgddh", OleDbType.VarChar, 30).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("hth")
                rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("sl")
                rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("dw")
                rcOleDbCommand.Parameters.Add("@paraDblMjsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("mjsl")
                rcOleDbCommand.Parameters.Add("@paraDblFzsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("fzsl")
                rcOleDbCommand.Parameters.Add("@paraStrFzdw", OleDbType.VarChar, 8).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("fzdw")
                rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("dj")
                rcOleDbCommand.Parameters.Add("@paraDblHsdj", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("hsdj")
                rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("je")
                rcOleDbCommand.Parameters.Add("@paraDblShlv", OleDbType.Numeric, 6).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("shlv")
                rcOleDbCommand.Parameters.Add("@paraDblSe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("se")
                rcOleDbCommand.Parameters.Add("@paraStrFpmemo", OleDbType.VarChar, 50).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("fpmemo")
                rcOleDbCommand.Parameters.Add("@paraStrDdDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("dddjh")
                rcOleDbCommand.Parameters.Add("@paraIntDdXh", OleDbType.Integer, 4).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("ddxh")
                rcOleDbCommand.Parameters.Add("@paraStrXsdDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("xsddjh")
                rcOleDbCommand.Parameters.Add("@paraIntXsdXh", OleDbType.Integer, 4).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("xsdxh")
                rcOleDbCommand.Parameters.Add("@paraDblXsdDj", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("xsddj")
                rcOleDbCommand.Parameters.Add("@paraDblXsdHsdj", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("xsdhsdj")
                rcOleDbCommand.Parameters.Add("@paraDblXsdJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("xsdje")
                rcOleDbCommand.Parameters.Add("@paraDblXsdShlv", OleDbType.Numeric, 6).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("xsdshlv")
                rcOleDbCommand.Parameters.Add("@paraDblXsdSe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("xsdse")
                rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                rcOleDbCommand.ExecuteNonQuery()
                If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                    If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                        MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                        Return
                    End If
                End If
                If rcOleDbCommand.Parameters("@paraStrDjh").Value.GetType.ToString <> "System.DBNull" Then
                    If rcOleDbCommand.Parameters("@paraStrDjh").Value <> "" Then
                        Me.TxtDjh.Text = Trim(rcOleDbCommand.Parameters("@paraStrDjh").Value)
                    End If
                End If
            Next
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '打印
        If blnPrint Then
            PrintEvent()
        End If
        '新单据号
        NewEvent()
        '控件设置
        SetControlEnableEvent()
        '设置焦点
        Me.TxtDjh.Focus()
    End Sub

#End Region

#Region "取消修改事件"

    Private Sub BtnCancelEvent(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click, MnuiCancel.Click
        If MsgBox("是否放弃所做的修改？", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "提示信息") = MsgBoxResult.Yes Then
            IsAdding = False
            IsEditing = False
            NewEvent()
            SetControlEnableEvent()
            Me.TxtDjh.Focus()
        End If
    End Sub

#End Region

#Region "冲销"

    Private Sub MnuiWriteOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiWriteOff.Click
        Me.rcDataGridView.Focus()
        If Not IsEditing And IsAdding Then
            '调用表单
            Dim rcFrm As New FrmOeFpWriteOff
            Dim strDjh As String = ""
            Dim blnSk As Boolean = False
            With rcFrm
                .ShowDialog()
                blnSk = .parablnSk
                strDjh = .paraStrDjh
                If blnSk Then
                    MsgBox("该单据已经收款，不能冲销，请先冲销收款单。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                    Return
                End If
                '读取红字冲销数据
                Try
                    rcOleDbConn.Open()
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    rcOleDbCommand.CommandText = "SELECT oe_fp.djh,oe_fp.fprq,oe_fp.bdelete,oe_fp.zydm,oe_fp.zymc,oe_fp.khdm,oe_fp.khmc,oe_fp.yspz,oe_fp.srr,oe_fp.shr,oe_fp.jzr,oe_fp.skje FROM oe_fp WHERE (djh = ? )"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = strDjh
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("rc_fpnr") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_fpnr").Clear()
                    End If
                    If rcDataset.Tables("rc_fpml") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_fpml").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "rc_fpml")
                    If rcDataset.Tables("rc_fpml").Rows.Count > 0 Then
                        If rcDataset.Tables("rc_fpml").Rows(0).Item("zydm").GetType.ToString <> "System.DBNull" Then
                            Me.TxtZydm.Text = rcDataset.Tables("rc_fpml").Rows(0).Item("zydm")
                        End If
                        If rcDataset.Tables("rc_fpml").Rows(0).Item("zymc").GetType.ToString <> "System.DBNull" Then
                            Me.LblZymc.Text = rcDataset.Tables("rc_fpml").Rows(0).Item("zymc")
                        End If
                        If rcDataset.Tables("rc_fpml").Rows(0).Item("khdm").GetType.ToString <> "System.DBNull" Then
                            Me.TxtKhdm.Text = rcDataset.Tables("rc_fpml").Rows(0).Item("khdm")
                        End If
                        If rcDataset.Tables("rc_fpml").Rows(0).Item("khmc").GetType.ToString <> "System.DBNull" Then
                            Me.LblKhmc.Text = rcDataset.Tables("rc_fpml").Rows(0).Item("khmc")
                        End If
                        If rcDataset.Tables("rc_fpml").Rows(0).Item("yspz").GetType.ToString <> "System.DBNull" Then
                            Me.TxtYspz.Text = rcDataset.Tables("rc_fpml").Rows(0).Item("yspz")
                        End If
                        '修改单据
                        rcOleDbCommand.CommandText = "SELECT oe_fp.cpdm,rc_cpxx.oldcpdm,rc_cpxx.cpmc,COALESCE(oe_fp.hth,'') AS hth,(0 - oe_fp.sl) AS sl,oe_fp.dw,oe_fp.mjsl,(0 - oe_fp.fzsl) AS fzsl,oe_fp.fzdw,oe_fp.dj,oe_fp.hsdj,0 - oe_fp.je AS je,oe_fp.shlv,0 - oe_fp.se AS se,0 - (oe_fp.je+ oe_fp.se) AS jese,oe_fp.fpmemo || oe_fp.djh AS fpmemo,oe_fp.dddjh,oe_fp.ddxh,oe_fp.xsddjh,oe_fp.xsdxh,oe_fp.xsddj,oe_fp.xsdhsdj,oe_fp.xsdje,oe_fp.xsdshlv,oe_fp.xsdse FROM oe_fp,rc_cpxx WHERE oe_fp.cpdm = rc_cpxx.cpdm AND (oe_fp.djh = ?) ORDER BY oe_fp.xh"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = strDjh
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_fpnr") IsNot Nothing Then
                            Me.rcDataset.Tables("rc_fpnr").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_fpnr")
                        If rcDataset.Tables("rc_fpnr").Rows.Count > 0 Then
                            If rcDataset.Tables("rc_fpnr").Rows(0).Item("dddjh").GetType.ToString <> "System.DBNull" Then
                                'Me.BtnImp.Enabled = False
                                Me.rcDataGridView.AllowUserToAddRows = False
                                Me.ColCpdm.ReadOnly = True
                                'Me.ColSl.ReadOnly = True
                                'Me.ColMjsl.ReadOnly = True
                                'Me.ColFzsl.ReadOnly = True
                                Me.BtnIns.Enabled = False
                                Me.MnuiIns.Enabled = False
                            End If
                        End If
                        SumSlJe() '数量金额合计
                        IsAdding = True
                        IsEditing = True
                        blnReCalculate = False
                        SetControlEnableEvent()
                    End If
                Catch ex As Exception
                    MsgBox("程序错误。" & Chr(13) & ex.Message)
                Finally
                    rcOleDbConn.Close()
                End Try
            End With
        End If

    End Sub

#End Region

#Region "作废/恢复"

    Private Sub MnuiZf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiZf.Click
        If Me.LblBdelete.Text = "作废" Then
            Me.LblBdelete.Text = ""
        Else
            Me.LblBdelete.Text = "作废"
        End If
        IsEditing = True
        SetControlEnableEvent()
    End Sub

#End Region

#Region "插入DataGridView行事件"

    Private Sub BtnIns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIns.Click, MnuiIns.Click
        If Me.rcDataGridView.ReadOnly = False Then
            If dtXsd.Rows.Count > 0 Then
                Dim row As DataRow = dtXsd.NewRow
                dtXsd.Rows.InsertAt(row, rcDataGridView.CurrentCell.RowIndex)
                dtXsd.AcceptChanges()
            End If
        End If
    End Sub

#End Region

#Region "删除DataGridView行事件"

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, MnuiDelete.Click
        DeleteEvent()
    End Sub

    Private Sub DeleteEvent()
        If Me.rcDataGridView.ReadOnly = False Then
            If dtXsd.Rows.Count > 0 Then
                dtXsd.Rows(rcDataGridView.CurrentRow.Index).Delete()
                dtXsd.AcceptChanges()
                IsEditing = True
                SetControlEnableEvent()
            End If
        End If
        'If Me.rcDataGridView.ReadOnly = False Then
        '    If Me.rcBindingSource.Count > 0 Then
        '        'MsgBox(dtxsd.Rows.Count.ToString)
        '        'MsgBox(rcDataGridView.CurrentRow.Index.ToString)
        '        'Me.rcBindingSource.RemoveCurrent()
        '        'Me.rcDataGridView.Refresh()
        '        'rcDataGridView.Rows.Remove(rcDataGridView.CurrentRow)
        '        dtxsd.Rows.RemoveAt(rcDataGridView.CurrentRow.Index)
        '        dtxsd.AcceptChanges()
        '        IsEditing = True
        '        SetControlEnableEvent()
        '    End If
        'End If
    End Sub
#End Region

    '#Region "读入excel"

    '    Private Sub BtnImpXls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiImpXls.Click
    '        '调用表单
    '        Dim rcFrm As New FrmOeFpImpXls
    '        With rcFrm
    '            .ParaStrPzlxdm = Me.CmbPzlxjc.SelectedValue
    '            .ParaStrKjqj = strKjqj
    '            .WindowState = FormWindowState.Maximized
    '            .MdiParent = Me.MdiParent
    '            .Show()
    '        End With
    '    End Sub

    '#End Region

#Region "打印设置、打印、打印预览事件"

    Private Sub PageSetupEvent()
        Dim rcFrmPageSetup As New models.FrmPageSetup
        With rcFrmPageSetup
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = "OEFPBZ"
            .paraRpsName = "销售单标准格式"
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
            .ParaRps = rcRps
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
        rft = Application.StartupPath + "\reports\oefpbz.rft"
        rcRps.LoadTemplate(rft)
        '取RPS打印参数
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps WHERE rpsid = 'OEFPBZ'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_rps") IsNot Nothing Then
                rcDataset.Tables("rc_rps").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_rps")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_rps").Rows.Count > 0 Then
            '设定值
            rcRps.Scale = rcDataset.Tables("rc_rps").Rows(0).Item("scale")
            rcRps.Orientation = rcDataset.Tables("rc_rps").Rows(0).Item("orientation")
            rcRps.PaperWidth = rcDataset.Tables("rc_rps").Rows(0).Item("paperwidth")
            rcRps.PaperHeight = rcDataset.Tables("rc_rps").Rows(0).Item("paperheight")
            rcRps.PrinterLeft = rcDataset.Tables("rc_rps").Rows(0).Item("printerleft")
            rcRps.PrinterTop = rcDataset.Tables("rc_rps").Rows(0).Item("printertop")
        Else
            '默认值
            rcRps.Scale = 100
            rcRps.Orientation = 1
        End If
        ''套打
        ''If blnTd Then
        '    rcRps.PaperType = 1
        'End If
        rcRps.Text(-1, 1) = g_PrnDwmc & "产品销售单"
        rcRps.Text(-1, 2) = "单据号：" & Trim(Me.TxtDjh.Text) & "  %p/%t"
        rcRps.Text(-1, 3) = "日期：" & Me.DtpFprq.Value.ToLongDateString
        rcRps.Text(-1, 4) = "客户：(" & Trim(Me.TxtKhdm.Text) & ")" & Trim(LblKhmc.Text)
        rcRps.Text(-1, 5) = "经办人：(" & Trim(Me.TxtZydm.Text) & ")" & Trim(LblZymc.Text)
        Dim i As Integer
        Dim j As Integer
        Dim intPage As Integer
        dblTotalSl = 0.0
        dblTotalFzsl = 0
        dblTotalJe = 0.0
        dblTotalSe = 0.0
        For intPage = 1 To System.Math.Ceiling(rcDataSet.Tables("rc_fpnr").Rows.Count / rcRps.LinesPerPage.ToString)
            For i = (intPage - 1) * rcRps.LinesPerPage.ToString To System.Math.Min(intPage * rcRps.LinesPerPage.ToString - 1, rcDataSet.Tables("rc_fpnr").Rows.Count - 1)
                If rcDataSet.Tables("rc_fpnr").Rows(i).RowState <> 8 Then
                    If Not rcDataSet.Tables("rc_fpnr").Rows(i).Item("cpdm").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 1) = Trim(rcDataSet.Tables("rc_fpnr").Rows(i).Item("cpdm"))
                    End If
                    If Not rcDataSet.Tables("rc_fpnr").Rows(i).Item("cpmc").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 2) = Trim(rcDataSet.Tables("rc_fpnr").Rows(i).Item("cpmc"))
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
                    If Not rcDataSet.Tables("rc_fpnr").Rows(i).Item("oldcpdm").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 9) = Trim(rcDataSet.Tables("rc_fpnr").Rows(i).Item("oldcpdm"))
                    End If
                    If Not rcDataSet.Tables("rc_fpnr").Rows(i).Item("fpmemo").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 9) += Trim(rcDataSet.Tables("rc_fpnr").Rows(i).Item("fpmemo"))
                    End If
                    j += 1
                End If
            Next

            Dim m As New models.ChineseNum With {
                .InputString = dblTotalJe + dblTotalSe
            }
            rcRps.PerPageText(intPage, 6) = IIf(intPage = Math.Ceiling(rcDataset.Tables("rc_fpnr").Rows.Count / rcRps.LinesPerPage.ToString), "合计", "小计")
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

    Private Sub MnuiPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrint.Click, BtnPrint.Click
        SaveEvent(True)
    End Sub

    Private Sub MnuiPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPageSetup.Click
        PageSetupEvent()
    End Sub

    Private Sub MnuiPrintView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrintView.Click, BtnPrintView.Click
        PrintViewEvent()
    End Sub

#End Region

#Region "退出表单事件"

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        ExitEvent()
    End Sub

    Private Sub MnuiExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiExit.Click
        ExitEvent()
    End Sub

    Private Sub ExitEvent()
        Me.Close()
    End Sub

    'Private Sub FrmxsdSrz2_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
    '    If IsEditing Then
    '        MsgBox("已经编辑过数据，请保存数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
    '        e.Cancel = True
    '    End If
    'End Sub

#End Region

End Class