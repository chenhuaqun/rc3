Imports System.Math
Imports System.Data.OleDb
Imports System.IO

Public Class FrmPoFpSrz
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable '我们要利用该datatable进行金额计算
    ReadOnly dtRkd As New DataTable("rc_fpnr")
    '增加单据的变量
    Dim IsAdding As Boolean = False
    '修改单据的变量
    Dim IsEditing As Boolean = False
    '数据绑定
    Dim rcBmb As BindingManagerBase
    '会计期间
    Dim strKjqj As String = g_Kjqj
    '年
    Dim strYear As String = ""
    '月
    Dim strMonth As String = ""
    '打印文档
    Dim rcRps As RPS.Document = Nothing
    '
    Dim EditingControl As DataGridViewTextBoxEditingControl
    '合计变量
    Dim dblTotSl As Double = 0.0
    Dim dblTotFzsl As Double = 0.0
    Dim dblTotJe As Double = 0.0
    Dim dblTotSe As Double = 0.0


#Region "窗体初始化"

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

    Private Sub FrmPoFpSrz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        ''取单晶多晶参数
        'If System.IO.File.Exists(My.Application.Info.DirectoryPath & "\" & "hsconfig.xml") Then
        '    Try
        '        Dim xmlTxm As New System.Xml.XmlDocument
        '        xmlTxm.Load(My.Application.Info.DirectoryPath & "\" & "hsconfig.xml")
        '        Me.MnuiHsOption.Checked = IIf(xmlTxm.SelectSingleNode("hsconfig").InnerText = "1", True, False)
        '    Catch ex As Exception
        '        MsgBox("读取参数有误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        '        System.IO.File.Delete(My.Application.Info.DirectoryPath & "\" & "hsconfig.xml")
        '    End Try
        'End If
        'setMnuiHsOption(Not Me.MnuiHsOption.Checked)

        '取单据类型数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE kjnd = ? AND lxgs = '物料入库单' ORDER BY pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = strYear
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_lx") IsNot Nothing Then
                Me.rcDataset.Tables("rc_lx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_lx")
        Catch ex As Exception
            MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_lx").Rows.Count = 0 Then
            MsgBox("请定义单据类型。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        '绑定凭证类型简称
        BindDropDownList(CmbPzlxjc, rcDataset.Tables("rc_lx"), "pzlxdm", "pzlxjc")
        '设置默认值
        Dim i As Integer
        For i = 0 To rcDataset.Tables("rc_lx").Rows.Count - 1
            If rcDataset.Tables("rc_lx").Rows(i).Item("pzlxdm") = "CGRK" Then
                Me.CmbPzlxjc.SelectedValue = "CGRK"
                Exit For
            End If
        Next
        '数据绑定
        dtRkd.Columns.Add("cpdm", Type.GetType("System.String"))
        dtRkd.Columns.Add("oldcpdm", Type.GetType("System.String"))
        dtRkd.Columns.Add("cpmc", Type.GetType("System.String"))
        dtRkd.Columns.Add("sgddh", Type.GetType("System.String"))
        dtRkd.Columns.Add("sl", Type.GetType("System.Double"))
        dtRkd.Columns.Add("dw", Type.GetType("System.String"))
        dtRkd.Columns.Add("mjsl", Type.GetType("System.Double"))
        dtRkd.Columns.Add("fzsl", Type.GetType("System.Double"))
        dtRkd.Columns.Add("fzdw", Type.GetType("System.String"))
        dtRkd.Columns.Add("dj", Type.GetType("System.Double"))
        dtRkd.Columns.Add("hsdj", Type.GetType("System.Double"))
        dtRkd.Columns.Add("je", Type.GetType("System.Double"))
        dtRkd.Columns.Add("shlv", Type.GetType("System.Double"))
        dtRkd.Columns.Add("se", Type.GetType("System.Double"))
        dtRkd.Columns.Add("jese", Type.GetType("System.Double"))
        dtRkd.Columns.Add("fpmemo", Type.GetType("System.String"))
        dtRkd.Columns.Add("cgddjh", Type.GetType("System.String"))
        dtRkd.Columns.Add("cgdxh", Type.GetType("System.Int32"))
        dtRkd.Columns.Add("rkddjh", Type.GetType("System.String"))
        dtRkd.Columns.Add("rkdxh", Type.GetType("System.Int32"))
        dtRkd.Columns.Add("rkddj", Type.GetType("System.Double"))
        dtRkd.Columns.Add("rkdhsdj", Type.GetType("System.Double"))
        dtRkd.Columns.Add("rkdje", Type.GetType("System.Double"))
        dtRkd.Columns.Add("rkdshlv", Type.GetType("System.Double"))
        dtRkd.Columns.Add("rkdse", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtRkd)
        With rcDataset.Tables("rc_fpnr")
            .Columns("cpdm").DefaultValue = ""
            .Columns("oldcpdm").DefaultValue = ""
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
            .Columns("cgddjh").DefaultValue = ""
            .Columns("cgdxh").DefaultValue = 0
            .Columns("rkddjh").DefaultValue = ""
            .Columns("rkdxh").DefaultValue = 0
            .Columns("rkddj").DefaultValue = 0.0
            .Columns("rkdhsdj").DefaultValue = 0.0
            .Columns("rkdje").DefaultValue = 0.0
            .Columns("rkdshlv").DefaultValue = 0.0
            .Columns("rkdse").DefaultValue = 0.0
        End With
        '绑定数据the DataGridview to the DataTable.
        rcBindingSource.DataSource = dtRkd
        Me.rcDataGridView.DataSource = rcBindingSource
        rcBmb = Me.BindingContext(rcDataset, "rc_fpnr")
        strKjqj = strYear & strMonth.PadLeft(2, "0")
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
            If dtRkd.Rows.Count > 0 Then
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

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbPzlxjc.KeyPress, TxtDjh.KeyPress, DtpFprq.KeyPress, TxtCsdm.KeyPress, TxtYspz.KeyPress, TxtZydm.KeyPress
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
            Case Keys.F7
                '删除最后一张单据
                '1.如果正在增加单据则返回
                If IsAdding Then
                    Return
                End If
                '2.删除
                If MsgBox("是否要删除最后一张单据？", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "提示信息") = MsgBoxResult.Ok Then
                    Try
                        rcOleDbConn.Open()
                        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                        rcOleDbCommand.Connection = rcOleDbConn
                        rcOleDbCommand.Transaction = rcOleDbTrans
                        rcOleDbCommand.CommandTimeout = 300
                        rcOleDbCommand.CommandType = CommandType.StoredProcedure
                        rcOleDbCommand.CommandText = "USP_DELETE_po_fp"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = Trim(Me.TxtDjh.Text)
                        rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                        rcOleDbCommand.Parameters.Add("@pIntError", OleDbType.Integer, 4).Direction = ParameterDirection.Output
                        rcOleDbCommand.ExecuteNonQuery()
                        If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                            If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                                MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                                Return
                            End If
                        End If
                        rcOleDbTrans.Commit()
                    Catch ex As Exception
                        Try
                            rcOleDbTrans.Rollback()
                            MsgBox("程序错误。" & Chr(13) & ex.Message & Chr(13) & rcOleDbCommand.Parameters("@pIntError").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        Catch ey As OleDbException
                            MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        End Try
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                Else
                    Return
                End If
                '3.显示新单据
                NewEvent()
                Me.TxtDjh.Focus()
                SetControlEnableEvent()
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtDjh_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtDjh.Validating
        If IsEditing Then
            Return
        End If
        '检查单据号是否存在
        If rcDataset.Tables("rc_pzno") Is Nothing Then
            Return
        End If
        '判断增加还是修改
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            If rcDataset.Tables("rc_pzno").Rows.Count > 0 Then
                If rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") >= Mid(Trim(Me.TxtDjh.Text), 11, 5) Then
                    '修改单据
                    rcOleDbCommand.CommandText = "SELECT po_fp.djh,po_fp.fprq,po_fp.bdelete,po_fp.zydm,po_fp.zymc,po_fp.csdm,po_fp.csmc,po_fp.yspz,po_fp.srr,po_fp.shr,po_fp.fkje FROM po_fp WHERE (po_fp.djh = ? )"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = TxtDjh.Text
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("rc_fpnr") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_fpnr").Clear()
                    End If
                    If rcDataset.Tables("rc_fpml") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_fpml").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "rc_fpml")
                    If rcDataset.Tables("rc_fpml").Rows.Count > 0 Then
                        ''已付款不能修改
                        'Dim blnFk As Boolean = False
                        'Dim i As Integer
                        'For i = 0 To rcDataSet.Tables("rc_fpml").Rows.Count - 1
                        '    If rcDataSet.Tables("rc_fpml").Rows(i).Item("fkje").GetType.ToString <> "System.DBNull" Then
                        '        If rcDataSet.Tables("rc_fpml").Rows(i).Item("fkje") <> 0 Then
                        '            blnFk = True
                        '        End If
                        '    End If
                        'Next
                        'If blnFk Then
                        '    MsgBox("该单据已经出库或已付款，不能修改。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        '    Me.TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataSet.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                        'Else
                        If rcDataset.Tables("rc_fpml").Rows(0).Item("shr").GetType.ToString <> "System.DBNull" Then
                            MsgBox("该单据已经审核，不能修改。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                            Me.TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                            IsAdding = True
                        Else
                            Me.DtpFprq.Value = rcDataset.Tables("rc_fpml").Rows(0).Item("fprq")
                            Me.LblBdelete.Text = IIf(rcDataset.Tables("rc_fpml").Rows(0).Item("bdelete"), "作废", "")
                            Me.TxtZydm.Text = Trim(rcDataset.Tables("rc_fpml").Rows(0).Item("zydm"))
                            Me.LblZymc.Text = rcDataset.Tables("rc_fpml").Rows(0).Item("zymc")
                            If rcDataset.Tables("rc_fpml").Rows(0).Item("csdm").GetType.ToString <> "System.DBNull" Then
                                Me.TxtCsdm.Text = Trim(rcDataset.Tables("rc_fpml").Rows(0).Item("csdm"))
                            Else
                                Me.TxtCsdm.Text = ""
                            End If
                            If rcDataset.Tables("rc_fpml").Rows(0).Item("csmc").GetType.ToString <> "System.DBNull" Then
                                Me.LblCsmc.Text = rcDataset.Tables("rc_fpml").Rows(0).Item("csmc")
                            Else
                                Me.LblCsmc.Text = ""
                            End If
                            If rcDataset.Tables("rc_fpml").Rows(0).Item("yspz").GetType.ToString <> "System.DBNull" Then
                                Me.TxtYspz.Text = rcDataset.Tables("rc_fpml").Rows(0).Item("yspz")
                            Else
                                Me.TxtYspz.Text = ""
                            End If
                            '修改单据
                            rcOleDbCommand.CommandText = "SELECT po_fp.cpdm,rc_cpxx.oldcpdm,rc_cpxx.cpmc,po_fp.sgddh,po_fp.sl,rc_cpxx.dw,po_fp.mjsl,po_fp.fzsl,rc_cpxx.fzdw,po_fp.dj,po_fp.hsdj,po_fp.je,po_fp.shlv,po_fp.se,(po_fp.je + po_fp.se) AS jese,po_fp.fpmemo,po_fp.cgddjh,po_fp.cgdxh,po_fp.rkddjh,po_fp.rkdxh,po_fp.rkddj,po_fp.rkdhsdj,po_fp.rkdje,po_fp.rkdshlv,po_fp.rkdse FROM po_fp,rc_cpxx WHERE po_fp.cpdm = rc_cpxx.cpdm AND (po_fp.djh = ?) ORDER BY po_fp.xh"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = TxtDjh.Text
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("rc_fpnr") IsNot Nothing Then
                                Me.rcDataset.Tables("rc_fpnr").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "rc_fpnr")
                            If rcDataset.Tables("rc_fpnr").Rows.Count > 0 Then
                                If rcDataset.Tables("rc_fpnr").Rows(0).Item("rkddjh").GetType.ToString <> "System.DBNull" Then
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
                            Me.rcDataGridView.ClearSelection()
                            SumSlJe()
                            IsAdding = False
                        End If
                    End If
                    'End If
                Else
                    '新增单据
                    IsAdding = True
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If IsAdding Then
            NewEvent()
        End If
        SetControlEnableEvent()
    End Sub

#End Region

#Region "计算合计数"

    Private Sub SumSlJe()
        '计算合计数
        dblTotSl = 0.0
        dblTotFzsl = 0.0
        dblTotJe = 0.0
        dblTotSe = 0.0
        If rcDataset.Tables("rc_fpnr").Rows.Count > 0 Then
            dblTotSl = dtRkd.Compute("Sum(sl)", "")
            dblTotFzsl = dtRkd.Compute("Sum(fzsl)", "")
            dblTotJe = dtRkd.Compute("Sum(je)", "")
            dblTotSe = dtRkd.Compute("Sum(se)", "")
        End If
        Me.LblSl.Text = "数量合计：" + Format(dblTotSl, g_FormatSl)
        Me.LblFzsl.Text = "辅数量合计：" + Format(dblTotFzsl, g_FormatSl)
        Me.LblJe.Text = "金额合计：" + Format(dblTotJe, g_FormatJe)
        Me.LblSe.Text = "税额合计：" + Format(dblTotSe, g_FormatJe)
        Me.LblJese.Text = "价税合计：" + Format(dblTotJe + dblTotSe, g_FormatJe)
    End Sub

#End Region

#Region "发票日期的事件"

    Private Sub DtpFprq_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DtpFprq.Validating
        Dim dateBegin As DateTime
        Dim dateEnd As DateTime
        dateBegin = getInvBegin(strYear, strMonth)
        dateEnd = getInvEnd(strYear, strMonth)
        If Me.DtpFprq.Value > dateEnd Or Me.DtpFprq.Value < dateBegin Then
            MsgBox("您输入的日期不在当前会计期间中，请重输入。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Me.DtpFprq.Focus()
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
                    .paraTitle = "职员"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtZydm.Text = Trim(.paraField1)
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
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT zydm,zymc FROM rc_zyxx WHERE (zydm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(TxtZydm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_zyxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_zyxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_zyxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_zyxx").Rows.Count > 0 Then
                Me.TxtZydm.Text = Trim(rcDataset.Tables("rc_zyxx").Rows(0).Item("zydm"))
                Me.LblZymc.Text = Trim(rcDataset.Tables("rc_zyxx").Rows(0).Item("zymc"))
            Else
                e.Cancel = True
            End If
            If Not IsEditing Then
                IsEditing = True
                SetControlEnableEvent()
            End If
        End If
    End Sub

#End Region

#Region "供应商编码事件"

    Private Sub TxtCsdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCsdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_csxx"
                    .paraField1 = "csdm"
                    .paraField2 = "csmc"
                    .paraField3 = "cssm"
                    .paraTitle = "供应商"
                    .paraOldValue = ""
                    .paraAddName = ""
                    .paraOrderField = "csmc"
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtCsdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtCsdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCsdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtCsdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_csxx WHERE (csdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(TxtCsdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_csxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_csxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_csxx")
            Catch ex As Exception
                MsgBox("程序错误。读取供应商编码。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_csxx").Rows.Count > 0 Then
                Me.TxtCsdm.Text = Trim(rcDataset.Tables("rc_csxx").Rows(0).Item("csdm"))
                Me.LblCsmc.Text = Trim(rcDataset.Tables("rc_csxx").Rows(0).Item("csmc"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "DataGridView的事件"

    'Private Sub rcDataGridView_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles rcDataGridView.CellEnter
    '    If Me.rcDataGridView.CurrentCell.ReadOnly Then My.Computer.Keyboard.SendKeys("{Enter}")
    'End Sub

    Private Sub RcDataGridView_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles rcDataGridView.CellValidating
        If Me.rcDataGridView.CurrentRow.IsNewRow = False Then
            If Me.rcDataGridView.IsCurrentCellDirty Then
                Me.rcDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColCpdm" Then
                If Not String.IsNullOrEmpty(e.FormattedValue) Then
                    '取物料信息
                    Try
                        rcOleDbConn.Open()
                        rcOleDbCommand.Connection = rcOleDbConn
                        rcOleDbCommand.CommandTimeout = 300
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT cpdm,cpmc,dw,mjsl,fzdw,oldcpdm FROM rc_cpxx WHERE (rc_cpxx.cpdm = ? OR rc_cpxx.oldcpdm = ?)"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.AddWithValue("@cpdm", rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue)
                        rcOleDbCommand.Parameters.AddWithValue("@oldcpdm", rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue)
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                            rcDataset.Tables("rc_cpxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
                        '取最新库存数量
                        rcOleDbCommand.CommandText = "SELECT COALESCE(Sum(qcsl+idsl),0.0) as kcsl FROM inv_cpyeb WHERE kjnd = ? AND cpdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = strYear
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("inv_cpyeb") IsNot Nothing Then
                            rcDataset.Tables("inv_cpyeb").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "inv_cpyeb")
                    Catch ex As Exception
                        MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
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
                        '旧物料编码
                        If rcDataset.Tables("rc_cpxx").Rows(0).Item("oldcpdm").GetType.ToString <> "System.DBNull" Then
                            Me.rcDataGridView.CurrentRow.Cells("ColOldCpdm").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("oldcpdm")
                        End If
                        If rcDataset.Tables("inv_cpyeb").Rows.Count = 1 Then
                            Me.LblMsg.Text = "当前库存数量：" & rcDataset.Tables("inv_cpyeb").Rows(0).Item("kcsl")
                        Else
                            Me.LblMsg.Text = "当前库存数量： 0.00 "
                        End If
                    Else
                        Me.LblMsg.Text = "物料编码不存在。"
                        e.Cancel = True
                    End If
                End If
            End If
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
                    If Me.rcDataGridView.CurrentRow.Cells("ColRkdDj").Value <> 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColRkdJe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColRkdDj").Value * e.FormattedValue, 2, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColRkdSe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColRkdDj").Value * e.FormattedValue * Me.rcDataGridView.CurrentRow.Cells("ColRkdShlv").Value / 100, 2, MidpointRounding.AwayFromZero)
                    End If
                    If Me.rcDataGridView.CurrentRow.Cells("ColRkdHsdj").Value <> 0 Then
                        Dim dblJese As Double
                        dblJese = System.Math.Round(e.FormattedValue * Me.rcDataGridView.CurrentRow.Cells("ColRkdHsdj").Value, 2, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColRkdJe").Value = System.Math.Round(System.Math.Round(e.FormattedValue * Me.rcDataGridView.CurrentRow.Cells("ColRkdHsdj").Value, 2, MidpointRounding.AwayFromZero) / (1 + Me.rcDataGridView.CurrentRow.Cells("ColRkdShlv").Value / 100), 2, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColRkdSe").Value = System.Math.Round(e.FormattedValue * Me.rcDataGridView.CurrentRow.Cells("ColRkdHsdj").Value - Me.rcDataGridView.CurrentRow.Cells("ColRkdJe").Value, 2, MidpointRounding.AwayFromZero)
                    End If
                    If Me.rcDataGridView.CurrentRow.Cells("ColMjsl").Value <> 0 Then
                        If e.FormattedValue <> 0 Then
                            If Me.rcDataGridView.CurrentRow.Cells("ColFzsl").Value = 0 Then
                                Me.rcDataGridView.CurrentRow.Cells("ColFzsl").Value = e.FormattedValue * Me.rcDataGridView.CurrentRow.Cells("ColMjsl").Value
                            End If
                        End If
                    End If
                End If
                '发票数量只能小于等于,不能大于入库数量
                If Me.rcDataGridView.CurrentRow.Cells("ColRkdDjh").Value.GetType.ToString <> "System.DBNull" Then
                    If Me.rcDataGridView.CurrentRow.Cells("ColRkdDjh").Value <> "" Then
                        Try
                            rcOleDbConn.Open()
                            rcOleDbCommand.Connection = rcOleDbConn
                            rcOleDbCommand.CommandTimeout = 300
                            rcOleDbCommand.CommandType = CommandType.Text
                            '取物料入库的数量
                            rcOleDbCommand.CommandText = "SELECT COALESCE(SUM(sl),0.0) AS rksl,COALESCE(SUM(je),0.0) AS rkje,COALESCE(SUM(se),0.0) AS rkse FROM po_rkd WHERE po_rkd.bdelete = 0 AND djh = ? AND xh = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.rcDataGridView.CurrentRow.Cells("ColRkdDjh").Value
                            rcOleDbCommand.Parameters.Add("@xh", OleDbType.Numeric, 4).Value = Me.rcDataGridView.CurrentRow.Cells("ColRkdXh").Value
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("t_rkd") IsNot Nothing Then
                                rcDataset.Tables("t_rkd").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "t_rkd")
                            '取物料已开票数据
                            rcOleDbCommand.CommandText = "SELECT COALESCE(SUM(sl),0.0) AS rksl,COALESCE(SUM(rkdje),0.0) AS rkje,COALESCE(SUM(rkdse),0.0) AS rkse FROM po_fp WHERE po_fp.bdelete = 0 AND djh <> ? AND rkddjh = ? AND rkdxh = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.TxtDjh.Text
                            rcOleDbCommand.Parameters.Add("@rkddjh", OleDbType.VarChar, 15).Value = Me.rcDataGridView.CurrentRow.Cells("ColRkdDjh").Value
                            rcOleDbCommand.Parameters.Add("@rkdxh", OleDbType.Numeric, 4).Value = Me.rcDataGridView.CurrentRow.Cells("ColRkdXh").Value
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
                        If rcDataset.Tables("t_rkd").Rows(0).Item("rksl") - rcDataset.Tables("t_fp").Rows(0).Item("rksl") < e.FormattedValue And e.FormattedValue > 0 Or rcDataset.Tables("t_rkd").Rows(0).Item("rksl") - rcDataset.Tables("t_fp").Rows(0).Item("rksl") > e.FormattedValue And e.FormattedValue < 0 Then
                            MsgBox("发票数量大于入库数量，请检查。", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示信息")
                            e.Cancel = True
                        End If
                        '当发票数量为刚好开完时。
                        If rcDataset.Tables("t_rkd").Rows(0).Item("rksl") - rcDataset.Tables("t_fp").Rows(0).Item("rksl") = e.FormattedValue Then
                            Me.rcDataGridView.CurrentRow.Cells("ColRkdJe").Value = rcDataset.Tables("t_rkd").Rows(0).Item("rkje") - rcDataset.Tables("t_fp").Rows(0).Item("rkje")
                            Me.rcDataGridView.CurrentRow.Cells("ColRkdSe").Value = rcDataset.Tables("t_rkd").Rows(0).Item("rkse") - rcDataset.Tables("t_fp").Rows(0).Item("rkse")
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
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    If e.FormattedValue <> 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value = System.Math.Round(e.FormattedValue * (1 + Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value / 100), 6, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColJe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColSl").Value * e.FormattedValue, 2, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColSe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColSl").Value * e.FormattedValue * Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value / 100, 2, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColJese").Value = Me.rcDataGridView.CurrentRow.Cells("ColJe").Value + Me.rcDataGridView.CurrentRow.Cells("ColSe").Value
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColHsdj" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = System.Math.Round(e.FormattedValue / (1 + Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value / 100), 6, MidpointRounding.AwayFromZero)
                    Me.rcDataGridView.CurrentRow.Cells("ColJe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColSl").Value * e.FormattedValue / (1 + Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value / 100), 2, MidpointRounding.AwayFromZero)
                    Me.rcDataGridView.CurrentRow.Cells("ColJese").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColSl").Value * e.FormattedValue, 2, MidpointRounding.AwayFromZero)
                    Me.rcDataGridView.CurrentRow.Cells("ColSe").Value = Me.rcDataGridView.CurrentRow.Cells("ColJese").Value - Me.rcDataGridView.CurrentRow.Cells("ColJe").Value
                Else
                    Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value = 0.0
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColShlv" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    If Me.rcDataGridView.CurrentRow.Cells("ColJe").Value <> 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColJese").Value / Me.rcDataGridView.CurrentRow.Cells("ColSl").Value, 6, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value / (1 + e.FormattedValue / 100), 6, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColJe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColSl").Value * Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value / (1 + e.FormattedValue / 100), 2, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColSe").Value = Me.rcDataGridView.CurrentRow.Cells("ColJese").Value - Me.rcDataGridView.CurrentRow.Cells("ColJe").Value
                        'Me.rcDataGridView.CurrentRow.Cells("ColJese").Value = Me.rcDataGridView.CurrentRow.Cells("ColJe").Value + Me.rcDataGridView.CurrentRow.Cells("ColSe").Value
                    End If
                Else
                    Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value = getParaValue("增值税默认税率", False)
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColJe" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    If e.FormattedValue <> 0 And Me.rcDataGridView.CurrentRow.Cells("ColSl").Value <> 0 Then
                        If System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColDj").Value * Me.rcDataGridView.CurrentRow.Cells("ColSl").Value, 2, MidpointRounding.AwayFromZero) <> e.FormattedValue Then
                            Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = Round(e.FormattedValue / Me.rcDataGridView.CurrentRow.Cells("ColSl").Value, 6, MidpointRounding.AwayFromZero)
                            Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value = Round(Me.rcDataGridView.CurrentRow.Cells("ColDj").Value * (Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value / 100 + 1), 6, MidpointRounding.AwayFromZero)
                        End If
                        'Me.rcDataGridView.CurrentRow.Cells("ColSe").Value = Round(Me.rcDataGridView.CurrentRow.Cells("ColSl").Value * Me.rcDataGridView.CurrentRow.Cells("ColDj").Value * Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value / 100, 2, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColSe").Value = Me.rcDataGridView.CurrentRow.Cells("ColJese").Value - Me.rcDataGridView.CurrentRow.Cells("ColJe").Value
                        'Me.rcDataGridView.CurrentRow.Cells("ColJese").Value = e.FormattedValue + Me.rcDataGridView.CurrentRow.Cells("ColSe").Value
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColSe" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    If Me.rcDataGridView.CurrentRow.Cells("ColJe").Value <> 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColJese").Value = e.FormattedValue + Me.rcDataGridView.CurrentRow.Cells("ColJe").Value
                        'Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColJese").Value / Me.rcDataGridView.CurrentRow.Cells("ColSl").Value, 6, MidpointRounding.AwayFromZero)
                    End If
                Else
                    Me.rcDataGridView.CurrentRow.Cells("ColSe").Value = 0.0
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColJese" Then
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
    End Sub

    Private Sub RcDataGridView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rcDataGridView.KeyDown
        Select Case e.KeyCode
            Case Keys.C And e.Control
                '复制
                Clipboard.SetDataObject(Me.rcDataGridView.GetClipboardContent())
            Case Keys.V And e.Control
                '粘贴
                Me.rcDataGridView.CurrentCell.Value = Clipboard.GetText()
                Me.rcDataGridView.EndEdit()
                Me.rcBindingSource.EndEdit()
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
                            Me.rcDataGridView.EndEdit()
                            Me.rcBindingSource.EndEdit()
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
        If Me.rcDataGridView.CurrentCell.OwningColumn.Name = "ColCpdm" Then
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
            Me.rcDataGridView.EndEdit()
            Me.rcBindingSource.EndEdit()
        End If
        If dtRkd.Rows.Count > 0 Then
            IsEditing = True
            SetControlEnableEvent()
            SumSlJe()
        End If
    End Sub

#End Region

#Region "导入收货记录"

    Private Sub BtnImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImp.Click
        If Not String.IsNullOrEmpty(Me.TxtCsdm.Text) Then
            Dim rcFrm As New FrmPoFpImpRkd
            With rcFrm
                .ParaStrCsdm = Me.TxtCsdm.Text
                .ParaDataSet = rcDataSet
                .ShowDialog()
                Me.rcDataGridView.AllowUserToAddRows = False
                Me.ColCpdm.ReadOnly = True
                'Me.ColSl.ReadOnly = True
                'Me.ColMjsl.ReadOnly = True
                'Me.ColFzsl.ReadOnly = True
                Me.BtnIns.Enabled = False
                Me.MnuiIns.Enabled = False
            End With
        Else
            MsgBox("请先选择供应商编码。")
        End If
    End Sub

#End Region

#Region "新单事件"

    Private Sub MnuiNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiNew.Click
        NewEvent()
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        NewEvent()
    End Sub

    Private Sub NewEvent()
        '清空数据
        Me.LblBdelete.Text = ""
        'Me.TxtBmdm.Text = ""
        'Me.LblBmmc.Text = ""
        Me.TxtZydm.Text = ""
        Me.LblZymc.Text = ""
        Me.TxtCsdm.Text = ""
        Me.LblCsmc.Text = ""
        Me.TxtYspz.Text = ""
        Me.LblMsg.Text = "提示信息。"
        Me.LblSl.Text = "数量合计："
        Me.LblFzsl.Text = "辅数量合计："
        Me.LblJe.Text = "金额合计："
        Me.LblSe.Text = "税额合计："
        Me.LblJese.Text = "价税合计："
        Me.BtnImp.Enabled = True
        Me.rcDataGridView.AllowUserToAddRows = True
        Me.ColCpdm.ReadOnly = False
        Me.BtnIns.Enabled = True
        Me.MnuiIns.Enabled = True
        '显示新单据号
        IsAdding = True
        IsEditing = False
        ShowNewDjh()
        '取服务器系统时间
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT SYSDATE FROM dual"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_sysdate") IsNot Nothing Then
                rcDataSet.Tables("rc_sysdate").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_sysdate")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("rc_sysdate").Rows.Count = 1 Then
            Me.DtpFprq.Value = rcDataSet.Tables("rc_sysdate").Rows(0).Item("sysdate")
        Else
            Me.DtpFprq.Value = Now()
        End If
        If getInvKjqj(Me.DtpFprq.Value) <> strKjqj Then
            DtpFprq.Value = getInvEnd(strYear, strMonth)
        End If
        '清空数据
        If rcDataSet.Tables("rc_fpnr") IsNot Nothing Then
            Me.rcDataSet.Tables("rc_fpnr").Clear()
        End If
    End Sub

    Private Sub ShowNewDjh()
        If Not IsEditing Then
            '取单据类型数据
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT pzlxdm,pzno" & strMonth & " As pzno FROM rc_lx WHERE kjnd = ? AND pzlxdm = ? AND lxgs = '物料入库单'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = strYear
                rcOleDbCommand.Parameters.AddWithValue("@pzlxdm", Trim(Me.CmbPzlxjc.SelectedValue))
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_pzno") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_pzno").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_pzno")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_pzno").Rows.Count = 0 Then
                MsgBox("请定义单据类型。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            Me.TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataSet.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
        End If
    End Sub

#End Region

#Region "保存单据数据事件"

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MnuiSave.Click
        SaveEvent(False)
    End Sub

    Private Sub SaveEvent(ByVal blnPrint As Boolean)
        Dim i As Integer
        '(一)数据合法性检查
        '(1)是否有需要存储的数据
        If rcDataSet.Tables("rc_fpnr").Rows.Count = 0 Then
            MsgBox("没有相应的业务，请输入。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        '(3)职员编码检查
        If String.IsNullOrEmpty(Me.TxtZydm.Text) Then
            MsgBox("职员编码不能为空。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Trim(TxtZydm.Text)
            rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_zyxx"
            rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "zydm"
            rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
            rcOleDbCommand.Parameters.Add("@pIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
            rcOleDbCommand.ExecuteNonQuery()
            If rcOleDbCommand.Parameters.Item("@pIntRecordCount").Value <> 1 Then
                MsgBox(Trim(TxtZydm.Text) & "职员编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                Me.TxtZydm.Text = ""
                Me.LblZymc.Text = ""
                Me.TxtZydm.Focus()
                Return
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '(4)供应商编码检查
        If String.IsNullOrEmpty(Me.TxtCsdm.Text) Then
            MsgBox("供应商编码不能为空。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Trim(Me.TxtCsdm.Text)
            rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_csxx"
            rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "csdm"
            rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
            rcOleDbCommand.Parameters.Add("@pIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
            rcOleDbCommand.ExecuteNonQuery()
            If rcOleDbCommand.Parameters.Item("@pIntRecordCount").Value <> 1 Then
                MsgBox(Trim(Me.TxtCsdm.Text) & "供应商编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                Me.TxtCsdm.Text = ""
                Me.LblCsmc.Text = ""
                Me.TxtCsdm.Focus()
                Return
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '(5)DataTable赋默认值
        For i = 0 To rcDataSet.Tables("rc_fpnr").Rows.Count - 1
            If rcDataSet.Tables("rc_fpnr").Rows(i).Item("cpdm").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_fpnr").Rows(i).Item("cpdm") = ""
            End If
            If rcDataSet.Tables("rc_fpnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_fpnr").Rows(i).Item("sl") = 0.0
            End If
            If rcDataSet.Tables("rc_fpnr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_fpnr").Rows(i).Item("dw") = ""
            End If
            If rcDataSet.Tables("rc_fpnr").Rows(i).Item("mjsl").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_fpnr").Rows(i).Item("mjsl") = 0.0
            End If
            If rcDataSet.Tables("rc_fpnr").Rows(i).Item("fzsl").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_fpnr").Rows(i).Item("fzsl") = 0.0
            End If
            If rcDataSet.Tables("rc_fpnr").Rows(i).Item("fzdw").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_fpnr").Rows(i).Item("fzdw") = ""
            End If
            If rcDataSet.Tables("rc_fpnr").Rows(i).Item("dj").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_fpnr").Rows(i).Item("dj") = 0.0
            End If
            If rcDataSet.Tables("rc_fpnr").Rows(i).Item("hsdj").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_fpnr").Rows(i).Item("hsdj") = 0.0
            End If
            If rcDataSet.Tables("rc_fpnr").Rows(i).Item("je").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_fpnr").Rows(i).Item("je") = 0.0
            End If
            If rcDataSet.Tables("rc_fpnr").Rows(i).Item("shlv").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_fpnr").Rows(i).Item("shlv") = 0.0
            End If
            If rcDataSet.Tables("rc_fpnr").Rows(i).Item("se").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_fpnr").Rows(i).Item("se") = 0.0
            End If
            If rcDataSet.Tables("rc_fpnr").Rows(i).Item("jese").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_fpnr").Rows(i).Item("jese") = 0.0
            End If
            If rcDataSet.Tables("rc_fpnr").Rows(i).Item("fpmemo").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_fpnr").Rows(i).Item("fpmemo") = ""
            End If
            If rcDataSet.Tables("rc_fpnr").Rows(i).Item("cgddjh").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_fpnr").Rows(i).Item("cgddjh") = ""
            End If
            If rcDataSet.Tables("rc_fpnr").Rows(i).Item("cgdxh").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_fpnr").Rows(i).Item("cgdxh") = 0
            End If
            If rcDataSet.Tables("rc_fpnr").Rows(i).Item("rkddjh").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_fpnr").Rows(i).Item("rkddjh") = ""
            End If
            If rcDataSet.Tables("rc_fpnr").Rows(i).Item("rkdxh").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_fpnr").Rows(i).Item("rkdxh") = 0
            End If
            If rcDataSet.Tables("rc_fpnr").Rows(i).Item("rkddj").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_fpnr").Rows(i).Item("rkddj") = 0.0
            End If
            If rcDataSet.Tables("rc_fpnr").Rows(i).Item("rkdhsdj").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_fpnr").Rows(i).Item("rkdhsdj") = 0.0
            End If
            If rcDataSet.Tables("rc_fpnr").Rows(i).Item("rkdje").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_fpnr").Rows(i).Item("rkdje") = 0.0
            End If
            If rcDataSet.Tables("rc_fpnr").Rows(i).Item("rkdshlv").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_fpnr").Rows(i).Item("rkdshlv") = 0.0
            End If
            If rcDataSet.Tables("rc_fpnr").Rows(i).Item("rkdse").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_fpnr").Rows(i).Item("rkdse") = 0.0
            End If
        Next
        '(6)物料编码检查
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            For i = 0 To rcDataSet.Tables("rc_fpnr").Rows.Count - 1
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Trim(rcDataSet.Tables("rc_fpnr").Rows(i).Item("cpdm"))
                rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_cpxx"
                rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "cpdm"
                rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
                rcOleDbCommand.Parameters.Add("@pIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
                rcOleDbCommand.ExecuteNonQuery()
                If rcOleDbCommand.Parameters.Item("@pIntRecordCount").Value <> 1 Then
                    MsgBox(Trim(rcDataSet.Tables("rc_fpnr").Rows(i).Item("cpdm")) & "物料编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                    Return
                End If
                If rcDataSet.Tables("rc_fpnr").Rows(i).Item("sl") = 0.0 Then
                    MsgBox("物料编码：" & rcDataSet.Tables("rc_fpnr").Rows(i).Item("cpdm") & "对应的数量为【零】，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                    Return
                End If
            Next
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '(7)单据号长度检查
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
        dtCopy = rcDataSet.Tables("rc_fpnr").Clone
        '倒数据
        '本月数据
        For j = 0 To rcDataSet.Tables("rc_fpnr").Rows.Count - 1
            blnExists = False
            For i = 0 To dtCopy.Rows.Count - 1
                If dtCopy.Rows(i).Item("cgddjh").GetType.ToString <> "System.DBNull" And rcDataSet.Tables("rc_fpnr").Rows(j).Item("cgddjh").GetType.ToString <> "System.DBNull" And dtCopy.Rows(i).Item("cgdxh").GetType.ToString <> "System.DBNull" And rcDataSet.Tables("rc_fpnr").Rows(j).Item("cgdxh").GetType.ToString <> "System.DBNull" Then
                    If dtCopy.Rows(i).Item("cgddjh") = rcDataSet.Tables("rc_fpnr").Rows(j).Item("cgddjh") And dtCopy.Rows(i).Item("cgdxh") = rcDataSet.Tables("rc_fpnr").Rows(j).Item("cgdxh") Then
                        blnExists = True
                    End If
                End If
            Next
            If Not blnExists Then
                rcDataRow = dtCopy.NewRow
                rcDataRow.Item("cpdm") = rcDataSet.Tables("rc_fpnr").Rows(j).Item("cpdm")
                rcDataRow.Item("cpmc") = rcDataSet.Tables("rc_fpnr").Rows(j).Item("cpmc")
                rcDataRow.Item("sl") = 0
                rcDataRow.Item("cgddjh") = rcDataSet.Tables("rc_fpnr").Rows(j).Item("cgddjh")
                rcDataRow.Item("cgdxh") = rcDataSet.Tables("rc_fpnr").Rows(j).Item("cgdxh")
                dtCopy.Rows.Add(rcDataRow)
            End If
        Next
        If String.IsNullOrEmpty(Me.LblBdelete.Text) Then
            For j = 0 To dtCopy.Rows.Count - 1
                dtCopy.Rows(j).Item("sl") = System.Math.Round(rcDataSet.Tables("rc_fpnr").Compute("SUM(sl)", "cgddjh = '" & dtCopy.Rows(j).Item("cgddjh") & "' and cgdxh =" & dtCopy.Rows(j).Item("cgdxh")), 6, MidpointRounding.AwayFromZero)
            Next
        End If
        '检查销售订单是否存在
        For i = 0 To dtCopy.Rows.Count - 1
            If Not String.IsNullOrEmpty(dtCopy.Rows(i).Item("cgddjh")) Then
                Dim dblWrksl As Double
                dblWrksl = ReadPoWfpsl(dtCopy.Rows(i).Item("cpdm"), dtCopy.Rows(i).Item("cgddjh"), dtCopy.Rows(i).Item("cgdxh"), Me.TxtDjh.Text)
                If dblWrksl >= 0 And dtCopy.Rows(i).Item("sl") > 0 And dblWrksl < dtCopy.Rows(i).Item("sl") Then
                    MsgBox("该物料的采购订单可开票数量小于开票数量，请检查。" & Chr(13) & "物料编码：" & dtCopy.Rows(i).Item("cpdm") & Chr(13) & "订单单据号：" & dtCopy.Rows(i).Item("cgddjh") & Chr(13) & "订单行号：" & dtCopy.Rows(i).Item("cgdxh") & Chr(13) & "当前开票数量：" & dtCopy.Rows(i).Item("sl").ToString & Chr(13) & "可开票数量：" & dblWrksl.ToString, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                    Return
                End If
                If dblWrksl < 0 And dtCopy.Rows(i).Item("sl") < 0 And dblWrksl > dtCopy.Rows(i).Item("sl") Then
                    MsgBox("该物料的采购订单可开票数量小于开票数量，请检查。" & Chr(13) & "物料编码：" & dtCopy.Rows(i).Item("cpdm") & Chr(13) & "订单单据号：" & dtCopy.Rows(i).Item("cgddjh") & Chr(13) & "订单行号：" & dtCopy.Rows(i).Item("cgdxh") & Chr(13) & "当前开票数量：" & dtCopy.Rows(i).Item("sl").ToString & "可开票数量：" & dblWrksl.ToString, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                    Return
                End If
            End If
        Next
        ''检查采购订单是否存在
        'For i = 0 To rcDataSet.Tables("rc_fpnr").Rows.Count - 1
        '    If Not String.IsNullOrEmpty(rcDataSet.Tables("rc_fpnr").Rows(i).Item("cgddjh")) Then
        '        Dim dblWrksl As Double = 0.0
        '        dblWrksl = ReadPoWfpsl(rcDataSet.Tables("rc_fpnr").Rows(i).Item("cpdm"), rcDataSet.Tables("rc_fpnr").Rows(i).Item("cgddjh"), rcDataSet.Tables("rc_fpnr").Rows(i).Item("cgdxh"), Me.TxtDjh.Text)
        '        If dblWrksl >= 0 And rcDataSet.Tables("rc_fpnr").Rows(i).Item("sl") > 0 And dblWrksl < rcDataSet.Tables("rc_fpnr").Rows(i).Item("sl") Then
        '            MsgBox("该物料的订单可开票数量小于发票数量，请检查。" & Chr(13) & "物料编码：" & rcDataSet.Tables("rc_fpnr").Rows(i).Item("cpdm") & Chr(13) & "订单号：" & rcDataSet.Tables("rc_fpnr").Rows(i).Item("cgddjh"), MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
        '            Return
        '        End If
        '        If dblWrksl < 0 And rcDataSet.Tables("rc_fpnr").Rows(i).Item("sl") < 0 And dblWrksl > rcDataSet.Tables("rc_fpnr").Rows(i).Item("sl") Then
        '            MsgBox("该物料的订单可开票数量小于发票数量，请检查。" & Chr(13) & "物料编码：" & rcDataSet.Tables("rc_fpnr").Rows(i).Item("cpdm") & Chr(13) & "订单号：" & rcDataSet.Tables("rc_fpnr").Rows(i).Item("cgddjh"), MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
        '            Return
        '        End If
        '    End If
        'Next

        '(二)存储ml
        'djh,fprq,zydm,srr
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP3_SAVE_PO_FP"
            For i = 0 To rcDataSet.Tables("rc_fpnr").Rows.Count - 1
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = IIf(IsAdding, 1, 0)
                rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = Trim(Me.TxtDjh.Text)
                rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = i + 1
                rcOleDbCommand.Parameters.Add("@paraDateFprq", OleDbType.Date, 8).Value = Me.DtpFprq.Value
                rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = IIf(String.IsNullOrEmpty(Me.LblBdelete.Text), 0, 1)
                rcOleDbCommand.Parameters.Add("@paraStrZydm", OleDbType.VarChar, 12).Value = Me.TxtZydm.Text
                rcOleDbCommand.Parameters.Add("@paraStrZymc", OleDbType.VarChar, 30).Value = Me.LblZymc.Text
                rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = Me.TxtCsdm.Text
                rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = Me.LblCsmc.Text
                rcOleDbCommand.Parameters.Add("@paraStrYspz", OleDbType.VarChar, 30).Value = Me.TxtYspz.Text
                rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("rc_fpnr").Rows(i).Item("cpdm")).ToUpper
                rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 200).Value = rcDataSet.Tables("rc_fpnr").Rows(i).Item("cpmc")
                rcOleDbCommand.Parameters.Add("@paraStrSgddh", OleDbType.VarChar, 30).Value = rcDataSet.Tables("rc_fpnr").Rows(i).Item("sgddh")
                rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataSet.Tables("rc_fpnr").Rows(i).Item("sl")
                rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = rcDataSet.Tables("rc_fpnr").Rows(i).Item("dw")
                rcOleDbCommand.Parameters.Add("@paraDblMjsl", OleDbType.Numeric, 18).Value = rcDataSet.Tables("rc_fpnr").Rows(i).Item("mjsl")
                rcOleDbCommand.Parameters.Add("@paraDblFzsl", OleDbType.Numeric, 18).Value = rcDataSet.Tables("rc_fpnr").Rows(i).Item("fzsl")
                rcOleDbCommand.Parameters.Add("@paraStrFzdw", OleDbType.VarChar, 8).Value = rcDataSet.Tables("rc_fpnr").Rows(i).Item("fzdw")
                rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = rcDataSet.Tables("rc_fpnr").Rows(i).Item("dj")
                rcOleDbCommand.Parameters.Add("@paraDblHsdj", OleDbType.Numeric, 18).Value = rcDataSet.Tables("rc_fpnr").Rows(i).Item("hsdj")
                rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataSet.Tables("rc_fpnr").Rows(i).Item("je")
                rcOleDbCommand.Parameters.Add("@paraDblShlv", OleDbType.Numeric, 6).Value = rcDataSet.Tables("rc_fpnr").Rows(i).Item("shlv")
                rcOleDbCommand.Parameters.Add("@paraDblSe", OleDbType.Numeric, 14).Value = rcDataSet.Tables("rc_fpnr").Rows(i).Item("se")
                rcOleDbCommand.Parameters.Add("@paraStrFpmemo", OleDbType.VarChar, 50).Value = rcDataSet.Tables("rc_fpnr").Rows(i).Item("fpmemo")
                rcOleDbCommand.Parameters.Add("@paraStrCgdDjh", OleDbType.VarChar, 15).Value = rcDataSet.Tables("rc_fpnr").Rows(i).Item("cgddjh")
                rcOleDbCommand.Parameters.Add("@paraIntCgdXh", OleDbType.Integer, 4).Value = rcDataSet.Tables("rc_fpnr").Rows(i).Item("cgdxh")
                rcOleDbCommand.Parameters.Add("@paraStrRkdDjh", OleDbType.VarChar, 15).Value = rcDataSet.Tables("rc_fpnr").Rows(i).Item("rkddjh")
                rcOleDbCommand.Parameters.Add("@paraIntRkdXh", OleDbType.Integer, 4).Value = rcDataSet.Tables("rc_fpnr").Rows(i).Item("rkdxh")
                rcOleDbCommand.Parameters.Add("@paraDblRkdDj", OleDbType.Numeric, 18).Value = rcDataSet.Tables("rc_fpnr").Rows(i).Item("rkddj")
                rcOleDbCommand.Parameters.Add("@paraDblRkdHsdj", OleDbType.Numeric, 18).Value = rcDataSet.Tables("rc_fpnr").Rows(i).Item("rkdhsdj")
                rcOleDbCommand.Parameters.Add("@paraDblRkdJe", OleDbType.Numeric, 14).Value = rcDataSet.Tables("rc_fpnr").Rows(i).Item("rkdje")
                rcOleDbCommand.Parameters.Add("@paraDblRkdShlv", OleDbType.Numeric, 6).Value = rcDataSet.Tables("rc_fpnr").Rows(i).Item("rkdshlv")
                rcOleDbCommand.Parameters.Add("@paraDblRkdSe", OleDbType.Numeric, 14).Value = rcDataSet.Tables("rc_fpnr").Rows(i).Item("rkdse")
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
                MsgBox("程序错误。" & Chr(13) & ex.Message & Chr(13), MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息") ''& rcOleDbCommand.Parameters("@pIntError").Value
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
        IsAdding = False
        IsEditing = False
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
            Dim rcFrm As New FrmPoFpWriteOff
            Dim strDjh As String = ""
            Dim blnFk As Boolean = False
            With rcFrm
                .ShowDialog()
                blnFk = .parablnFk
                strDjh = .paraStrDjh
                If blnFk Then
                    MsgBox("该单据已经付款，不能冲销，请先冲销收款单。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                    Return
                End If
                '读取红字冲销数据
                Try
                    rcOleDbConn.Open()
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    '修改单据
                    rcOleDbCommand.CommandText = "SELECT po_fp.djh,po_fp.fprq,po_fp.zydm,po_fp.zymc,po_fp.csdm,po_fp.csmc,po_fp.yspz,po_fp.srr,po_fp.shr,po_fp.fkje FROM po_fp WHERE (po_fp.djh = ? )"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = strDjh
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataSet.Tables("rc_fpnr") IsNot Nothing Then
                        Me.rcDataSet.Tables("rc_fpnr").Clear()
                    End If
                    If rcDataSet.Tables("rc_fpml") IsNot Nothing Then
                        Me.rcDataSet.Tables("rc_fpml").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataSet, "rc_fpml")
                    If rcDataSet.Tables("rc_fpml").Rows.Count > 0 Then
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
                        '修改单据
                        rcOleDbCommand.CommandText = "SELECT po_fp.cpdm,rc_cpxx.oldcpdm,rc_cpxx.cpmc,po_fp.sgddh,(0 － po_fp.sl) AS sl,rc_cpxx.dw,po_fp.mjsl,(0 - po_fp.fzsl) AS fzsl,rc_cpxx.fzdw,po_fp.dj,po_fp.hsdj,0 - po_fp.je AS je,po_fp.shlv,0 - po_fp.se AS se,0 - (po_fp.je + po_fp.se) AS jese,po_fp.fpmemo,po_fp.cgddjh,po_fp.cgdxh,po_fp.rkddjh,po_fp.rkdxh,po_fp.rkddj,po_fp.rkdhsdj,po_fp.rkdje,po_fp.rkdshlv,po_fp.rkdse FROM po_fp,rc_cpxx WHERE po_fp.cpdm = rc_cpxx.cpdm AND (po_fp.djh = ?) ORDER BY po_fp.xh"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = strDjh
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataSet.Tables("rc_fpnr") IsNot Nothing Then
                            Me.rcDataSet.Tables("rc_fpnr").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataSet, "rc_fpnr")
                        If rcDataSet.Tables("rc_fpnr").Rows.Count > 0 Then
                            If rcDataSet.Tables("rc_fpnr").Rows(0).Item("rkddjh").GetType.ToString <> "System.DBNull" Then
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
                        Me.rcDataGridView.ClearSelection()
                        SumSlJe()
                        IsAdding = True
                        IsEditing = True
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

#Region "插入行事件"

    Private Sub BtnIns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIns.Click, MnuiIns.Click
        If Me.rcDataGridView.ReadOnly = False Then
            If dtRkd.Rows.Count > 0 Then
                Dim row As DataRow = dtRkd.NewRow
                dtRkd.Rows.InsertAt(row, rcDataGridView.CurrentCell.RowIndex)
                dtRkd.AcceptChanges()
            End If
        End If
    End Sub

#End Region

#Region "删除DataGridView行事件"

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        DeleteEvent()
    End Sub

    Private Sub MnuiDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiDelete.Click
        DeleteEvent()
    End Sub

    Private Sub DeleteEvent()
        If Me.rcDataGridView.ReadOnly = False Then
            If rcDataSet.Tables("rc_fpnr").Rows.Count > 0 Then
                rcDataSet.Tables("rc_fpnr").Rows(rcDataGridView.CurrentRow.Index).Delete()
                rcDataSet.Tables("rc_fpnr").AcceptChanges()
                IsEditing = True
                SetControlEnableEvent()
            End If
        End If
    End Sub
#End Region

#Region "读入excel"

    Private Sub BtnImpXls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiImpXls.Click
        '调用表单
        Dim rcFrm As New FrmPoRkdImpXls
        With rcFrm
            .ParaStrPzlxdm = Me.CmbPzlxjc.SelectedValue
            .ParaStrKjqj = strKjqj
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
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

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click, MnuiPrint.Click
        SaveEvent(True)
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

    Private Sub BtnPrintView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrintView.Click
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

    Private Sub FrmPoFpSrz_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If IsEditing Then
            MsgBox("已经编辑过数据，请保存数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            e.Cancel = True
        End If
    End Sub

#End Region

    'Private Sub MnuiHsOption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiHsOption.Click
    '    If Me.MnuiHsOption.Checked Then
    '        '切换到含税
    '        setMnuiHsOption(True)
    '    Else
    '        '切换到价税分离
    '        setMnuiHsOption(False)
    '    End If
    '    '保存参数
    '    If System.IO.File.Exists(My.Application.Info.DirectoryPath & "\hsconfig.xml") Then
    '        System.IO.File.Delete(My.Application.Info.DirectoryPath & "\hsconfig.xml")
    '    End If
    '    '写xml文件
    '    Dim rcStreamWriter As StreamWriter
    '    rcStreamWriter = File.CreateText(My.Application.Info.DirectoryPath & "\hsconfig.xml")
    '    rcStreamWriter.WriteLine("<?xml version=""1.0"" encoding=""utf-8"" ?> ")
    '    rcStreamWriter.WriteLine("<hsconfig>" & IIf(Me.MnuiHsOption.Checked, "1", "0") & "</hsconfig>")
    '    rcStreamWriter.Close()
    'End Sub

    'Private Sub setMnuiHsOption(ByVal blnHs As Boolean)
    '    If blnHs Then
    '        Me.rcDataGridView.Columns("ColDj").Visible = False
    '        Me.rcDataGridView.Columns("ColHsdj").Visible = True
    '        Me.rcDataGridView.Columns("ColJe").Visible = False
    '        Me.rcDataGridView.Columns("ColShlv").Visible = False
    '        Me.rcDataGridView.Columns("ColSe").Visible = False
    '        Me.MnuiHsOption.Checked = False
    '    Else
    '        Me.rcDataGridView.Columns("ColDj").Visible = True
    '        Me.rcDataGridView.Columns("ColHsdj").Visible = False
    '        Me.rcDataGridView.Columns("ColJe").Visible = True
    '        Me.rcDataGridView.Columns("ColShlv").Visible = True
    '        Me.rcDataGridView.Columns("ColSe").Visible = True
    '        Me.MnuiHsOption.Checked = True
    '    End If
    '    Me.rcDataGridView.Refresh()
    'End Sub

End Class