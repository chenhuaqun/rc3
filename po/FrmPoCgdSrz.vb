Imports System.Math
Imports System.Data.OleDb

Public Class FrmPoCgdSrz
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable '我们要利用该datatable进行金额计算
    ReadOnly dtCgd As New DataTable("rc_cgdnr")
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
    '打印格式
    Dim blnhs As Boolean = False


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

    Private Sub FrmCgdSrz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        '取单据类型数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE kjnd = ? AND lxgs = '物料采购订单' ORDER BY pzlxdm"
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
            If rcDataset.Tables("rc_lx").Rows(i).Item("pzlxdm") = "CGDJ" Then
                Me.CmbPzlxjc.SelectedValue = "CGDJ"
                Exit For
            End If
        Next
        '数据绑定
        dtCgd.Columns.Add("cpdm", Type.GetType("System.String"))
        dtCgd.Columns.Add("cpmc", Type.GetType("System.String"))
        dtCgd.Columns.Add("oldcpdm", Type.GetType("System.String"))
        dtCgd.Columns.Add("jhshrq", Type.GetType("System.DateTime"))
        dtCgd.Columns.Add("sl", Type.GetType("System.Double"))
        dtCgd.Columns.Add("dw", Type.GetType("System.String"))
        dtCgd.Columns.Add("mjsl", Type.GetType("System.Double"))
        dtCgd.Columns.Add("fzsl", Type.GetType("System.Double"))
        dtCgd.Columns.Add("fzdw", Type.GetType("System.String"))
        dtCgd.Columns.Add("dj", Type.GetType("System.Double"))
        dtCgd.Columns.Add("hsdj", Type.GetType("System.Double"))
        dtCgd.Columns.Add("je", Type.GetType("System.Double"))
        dtCgd.Columns.Add("shlv", Type.GetType("System.Double"))
        dtCgd.Columns.Add("se", Type.GetType("System.Double"))
        dtCgd.Columns.Add("jese", Type.GetType("System.Double"))
        dtCgd.Columns.Add("cgmemo", Type.GetType("System.String"))
        dtCgd.Columns.Add("cgjhdjh", Type.GetType("System.String"))
        dtCgd.Columns.Add("cgjhxh", Type.GetType("System.Int32"))
        rcDataset.Tables.Add(dtCgd)
        With rcDataset.Tables("rc_cgdnr")
            .Columns("cpdm").DefaultValue = ""
            .Columns("oldcpdm").DefaultValue = ""
            .Columns("jhshrq").DefaultValue = Now.Date.AddDays(7)
            .Columns("sl").DefaultValue = 0.0
            .Columns("mjsl").DefaultValue = 0.0
            .Columns("fzsl").DefaultValue = 0.0
            .Columns("dj").DefaultValue = 0.0
            .Columns("hsdj").DefaultValue = 0.0
            .Columns("je").DefaultValue = 0.0
            .Columns("shlv").DefaultValue = GetParaValue("增值税默认税率", False)
            .Columns("se").DefaultValue = 0.0
            .Columns("jese").DefaultValue = 0.0
            .Columns("cgmemo").DefaultValue = ""
            .Columns("cgjhdjh").DefaultValue = ""
            .Columns("cgjhxh").DefaultValue = 0
        End With
        '绑定数据the DataGridview to the DataTable.
        rcBindingSource.DataSource = dtCgd
        Me.rcDataGridView.DataSource = rcBindingSource
        rcBmb = Me.BindingContext(rcDataset, "rc_cgdnr")
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
            If dtCgd.Rows.Count > 0 Then
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

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbPzlxjc.KeyPress, TxtDjh.KeyPress, DtpCgrq.KeyPress, TxtSgddh.KeyPress, TxtCsdm.KeyPress
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
                        rcOleDbCommand.CommandText = "USP3_DELETE_PO_CGD"
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
                    rcOleDbCommand.CommandText = "SELECT po_cgd.djh,po_cgd.cgrq,po_cgd.sgddh,po_cgd.csdm,po_cgd.csmc,po_cgd.srr,po_cgd.shr FROM po_cgd WHERE NOT EXISTS (SELECT 1 FROM po_cgd WHERE po_cgd.rksl <> 0 AND po_cgd.djh = ?) AND po_cgd.djh = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.TxtDjh.Text
                    rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.TxtDjh.Text
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("rc_cgdnr") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_cgdnr").Clear()
                    End If
                    If rcDataset.Tables("rc_cgdml") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_cgdml").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "rc_cgdml")
                    If rcDataset.Tables("rc_cgdml").Rows.Count > 0 Then
                        If rcDataset.Tables("rc_cgdml").Rows(0).Item("shr").GetType.ToString <> "System.DBNull" Then
                            MsgBox("该单据已经审核，不能修改。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                            TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                            IsAdding = True
                        Else
                            Me.DtpCgrq.Value = rcDataset.Tables("rc_cgdml").Rows(0).Item("cgrq")
                            If rcDataset.Tables("rc_cgdml").Rows(0).Item("sgddh").GetType.ToString <> "System.DBNull" Then
                                Me.TxtSgddh.Text = rcDataset.Tables("rc_cgdml").Rows(0).Item("sgddh")
                            Else
                                Me.TxtSgddh.Text = ""
                            End If
                            If rcDataset.Tables("rc_cgdml").Rows(0).Item("csdm").GetType.ToString <> "System.DBNull" Then
                                Me.TxtCsdm.Text = Trim(rcDataset.Tables("rc_cgdml").Rows(0).Item("csdm"))
                            Else
                                Me.TxtCsdm.Text = ""
                            End If
                            If rcDataset.Tables("rc_cgdml").Rows(0).Item("csmc").GetType.ToString <> "System.DBNull" Then
                                Me.LblCsmc.Text = rcDataset.Tables("rc_cgdml").Rows(0).Item("csmc")
                            Else
                                Me.LblCsmc.Text = ""
                            End If
                            '修改单据
                            rcOleDbCommand.CommandText = "SELECT po_cgd.cpdm,rc_cpxx.cpmc,rc_cpxx.oldcpdm,po_cgd.jhshrq,po_cgd.sl,po_cgd.dw,po_cgd.mjsl,po_cgd.fzsl,po_cgd.fzdw,po_cgd.dj,po_cgd.hsdj,po_cgd.je,po_cgd.shlv,po_cgd.se,po_cgd.je+po_cgd.se AS jese,po_cgd.cgmemo,po_cgd.cgjhdjh,po_cgd.cgjhxh FROM po_cgd,rc_cpxx WHERE po_cgd.cpdm = rc_cpxx.cpdm AND po_cgd.djh = ? ORDER BY po_cgd.xh"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = TxtDjh.Text
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("rc_cgdnr") IsNot Nothing Then
                                Me.rcDataset.Tables("rc_cgdnr").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "rc_cgdnr")
                            If rcDataset.Tables("rc_cgdnr").Rows.Count > 0 Then
                                If rcDataset.Tables("rc_cgdnr").Rows(0).Item("cgjhdjh").GetType.ToString <> "System.DBNull" Then
                                    Me.BtnImp.Enabled = False
                                    Me.rcDataGridView.AllowUserToAddRows = False
                                    'Me.ColCpdm.ReadOnly = True
                                    'Me.ColSl.ReadOnly = True
                                    Me.ColMjsl.ReadOnly = True
                                    Me.ColFzsl.ReadOnly = True
                                    Me.BtnIns.Enabled = False
                                End If
                            End If
                            Me.rcDataGridView.ClearSelection()
                            SumSlJe()
                            IsAdding = False
                        End If
                    Else
                        MsgBox("物料采购订单已入库或物料采购订单不存在。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                        Return
                    End If
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
        If dtCgd.Rows.Count > 0 Then
            dblTotSl = dtCgd.Compute("Sum(sl)", "")
            dblTotFzsl = dtCgd.Compute("Sum(fzsl)", "")
            dblTotJe = dtCgd.Compute("Sum(je)", "")
            dblTotSe = dtCgd.Compute("Sum(se)", "")
        End If
        Me.LblSl.Text = "数量合计：" + Format(dblTotSl, g_FormatSl)
        Me.LblFzsl.Text = "辅数量合计：" + Format(dblTotFzsl, g_FormatSl)
        Me.LblJe.Text = "金额合计：" + Format(dblTotJe, g_FormatJe)
        Me.LblSe.Text = "税额合计：" + Format(dblTotSe, g_FormatJe)
        Me.LblJese.Text = "价税合计：" + Format(dblTotJe + dblTotSe, g_FormatJe)
    End Sub

#End Region

#Region "采购日期的事件"

    Private Sub DtpCgrq_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DtpCgrq.Validating
        Dim dateBegin As DateTime
        Dim dateEnd As DateTime
        dateBegin = GetInvBegin(strYear, strMonth)
        dateEnd = GetInvEnd(strYear, strMonth)
        If DtpCgrq.Value > dateEnd Or DtpCgrq.Value < dateBegin Then
            MsgBox("您输入的日期不在当前会计期间中，请重输入。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Me.DtpCgrq.Focus()
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
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtCsdm.Text)
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
            IsEditing = True
            SetControlEnableEvent()
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
                        rcOleDbCommand.CommandText = "SELECT rc_cpxx.cpdm,rc_cpxx.cpmc,rc_cpxx.oldcpdm,rc_cpxx.dw,rc_cpxx.mjsl,rc_cpxx.fzdw FROM rc_cpxx WHERE (rc_cpxx.cpdm = ? OR rc_cpxx.oldcpdm = ?)"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.AddWithValue("@cpdm", rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue)
                        rcOleDbCommand.Parameters.AddWithValue("@oldcpdm", rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue)
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                            rcDataset.Tables("rc_cpxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
                        '查找未下采购订单的数据
                    Catch ex As Exception
                        MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                    If rcDataset.Tables("rc_cpxx").Rows.Count > 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColCpdm").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("cpdm")
                        Me.rcDataGridView.CurrentRow.Cells("ColCpmc").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("cpmc")
                        Me.rcDataGridView.CurrentRow.Cells("ColOldCpdm").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("oldcpdm")
                        Me.rcDataGridView.CurrentRow.Cells("ColDw").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("dw")
                        If rcDataset.Tables("rc_cpxx").Rows(0).Item("mjsl").GetType.ToString <> "System.DBNull" And Me.rcDataGridView.CurrentRow.Cells("ColMjsl").Value = 0 Then
                            Me.rcDataGridView.CurrentRow.Cells("ColMjsl").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("mjsl")
                        End If
                        If rcDataset.Tables("rc_cpxx").Rows(0).Item("fzdw").GetType.ToString <> "System.DBNull" Then
                            Me.rcDataGridView.CurrentRow.Cells("ColFzdw").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("fzdw")
                        End If
                        '读取最近一次采购单价
                        If Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = 0 Then
                            If Not String.IsNullOrEmpty(Me.TxtCsdm.Text) Then
                                Try
                                    rcOleDbConn.Open()
                                    rcOleDbCommand.Connection = rcOleDbConn
                                    rcOleDbCommand.CommandTimeout = 300
                                    rcOleDbCommand.CommandType = CommandType.Text
                                    rcOleDbCommand.CommandText = "SELECT COALESCE(po_cscpcgdj.cgdj,0.0) AS cgdj FROM po_cscpcgdj WHERE (po_cscpcgdj.cpdm = ? AND po_cscpcgdj.csdm = ?)"
                                    rcOleDbCommand.Parameters.Clear()
                                    rcOleDbCommand.Parameters.AddWithValue("@cpdm", rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue)
                                    rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Me.TxtCsdm.Text
                                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                    If rcDataset.Tables("po_cscpcgdj") IsNot Nothing Then
                                        rcDataset.Tables("po_cscpcgdj").Clear()
                                    End If
                                    rcOleDbDataAdpt.Fill(rcDataset, "po_cscpcgdj")
                                Catch ex As Exception
                                    MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                                    Return
                                Finally
                                    rcOleDbConn.Close()
                                End Try
                                If rcDataset.Tables("po_cscpcgdj").Rows.Count > 0 Then
                                    Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = rcDataset.Tables("po_cscpcgdj").Rows(0).Item("cgdj")
                                    Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value = rcDataset.Tables("po_cscpcgdj").Rows(0).Item("cgdj") * (1 + Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value / 100)
                                End If
                            End If
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
                    If Me.rcDataGridView.CurrentRow.Cells("ColMjsl").Value <> 0 Then
                        If e.FormattedValue <> 0 Then
                            If Me.rcDataGridView.CurrentRow.Cells("ColFzsl").Value = 0 Then
                                Me.rcDataGridView.CurrentRow.Cells("ColFzsl").Value = e.FormattedValue * Me.rcDataGridView.CurrentRow.Cells("ColMjsl").Value
                            End If
                        End If
                    End If
                End If
                '采购数量只能小于等于,不能大于需求数量
                If Me.rcDataGridView.CurrentRow.Cells("ColCgjhDjh").Value.GetType.ToString <> "System.DBNull" Then
                    If Me.rcDataGridView.CurrentRow.Cells("ColCgjhDjh").Value <> "" Then
                        Try
                            rcOleDbConn.Open()
                            rcOleDbCommand.Connection = rcOleDbConn
                            rcOleDbCommand.CommandTimeout = 300
                            rcOleDbCommand.CommandType = CommandType.Text
                            '取物料采购/维修需求单的数量
                            rcOleDbCommand.CommandText = "SELECT COALESCE(SUM(sl),0.0) AS jhsl FROM po_cgjh WHERE djh = ? AND xh = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.rcDataGridView.CurrentRow.Cells("ColCgjhDjh").Value
                            rcOleDbCommand.Parameters.Add("@xh", OleDbType.Numeric, 4).Value = Me.rcDataGridView.CurrentRow.Cells("ColCgjhXh").Value
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("t_cgjh") IsNot Nothing Then
                                rcDataset.Tables("t_cgjh").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "t_cgjh")
                            '取物料采购订单的已采购数量
                            rcOleDbCommand.CommandText = "SELECT COALESCE(SUM(sl),0.0) AS cgsl FROM po_cgd WHERE djh <> ? AND cgjhdjh = ? AND cgjhxh = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.TxtDjh.Text
                            rcOleDbCommand.Parameters.Add("@cgjhdjh", OleDbType.VarChar, 15).Value = Me.rcDataGridView.CurrentRow.Cells("ColCgjhDjh").Value
                            rcOleDbCommand.Parameters.Add("@cgjhxh", OleDbType.Numeric, 4).Value = Me.rcDataGridView.CurrentRow.Cells("ColCgjhXh").Value
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("t_cgd") IsNot Nothing Then
                                rcDataset.Tables("t_cgd").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "t_cgd")
                        Catch ex As Exception
                            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                            Return
                        Finally
                            rcOleDbConn.Close()
                        End Try
                        If rcDataset.Tables("t_cgjh").Rows(0).Item("jhsl") - rcDataset.Tables("t_cgd").Rows(0).Item("cgsl") < e.FormattedValue And e.FormattedValue > 0 Then
                            If MsgBox("采购数量大于需求数量，是否继续？", MsgBoxStyle.YesNo, "提示信息") = MsgBoxResult.No Then
                                e.Cancel = True
                            End If
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
                    Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value = GetParaValue("增值税默认税率", False)
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColJe" Then
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
        'If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColCsdm" And Me.ColCsdm.ReadOnly = False Then
        '    Select Case e.KeyCode
        '        Case Keys.F3
        '            Dim rcFrm As New models.FrmF3KeyPress
        '            With rcFrm
        '                .paraOleDbConn = rcOleDbConn
        '                .paraTableName = "rc_csxx"
        '                .paraField1 = "csdm"
        '                .paraField2 = "csmc"
        '                .paraField3 = "cssm"
        '                .paraCondition = "0=0"
        '                .paraOrderField = "csmc"
        '                .paraTitle = "供应商"
        '                .paraOldValue = ""
        '                .paraAddName = ""
        '                If .ShowDialog = DialogResult.OK Then
        '                    '将用户在rcfrmselectcsdm所选择的csdm带入rcdatarid'
        '                    Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value = .paraField1
        '                    Me.rcDataGridView.EndEdit()
        '                    Me.rcBindingSource.EndEdit()
        '                End If
        '            End With
        '    End Select
        'End If
    End Sub

    Private Sub RcDataGridView_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles rcDataGridView.EditingControlShowing
        EditingControl = e.Control
        If Not EditingControl.IsHandleCreated Then
            AddHandler EditingControl.KeyDown, New KeyEventHandler(AddressOf EditingControl_KeyDown)
        End If
        If Me.rcDataGridView.CurrentCell.OwningColumn.Name = "ColCpdm" Then 'Or Me.rcDataGridView.CurrentCell.OwningColumn.Name = "ColCsdm"
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
        'If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColCsdm" And Me.ColCsdm.ReadOnly = False Then
        '    Select Case e.KeyCode
        '        Case Keys.F3
        '            Dim rcFrm As New models.FrmF3KeyPress
        '            With rcFrm
        '                .paraOleDbConn = rcOleDbConn
        '                .paraTableName = "rc_csxx"
        '                .paraField1 = "csdm"
        '                .paraField2 = "csmc"
        '                .paraField3 = "cssm"
        '                .paraCondition = "0=0"
        '                .paraOrderField = "csmc"
        '                .paraTitle = "供应商"
        '                .paraOldValue = ""
        '                .paraAddName = ""
        '                If .ShowDialog = DialogResult.OK Then
        '                    '将用户在rcfrmselectcsdm所选择的csdm带入rcdatarid'
        '                    Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value = .paraField1
        '                    Me.rcDataGridView.EndEdit()
        '                    Me.rcBindingSource.EndEdit()
        '                End If
        '            End With
        '            e.Handled = True
        '    End Select
        'End If
    End Sub

    Private Sub RcDataGridView_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles rcDataGridView.Leave
        Me.rcDataGridView.ClearSelection()
    End Sub

    Private Sub RcDataGridView_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles rcDataGridView.RowValidating
        If Not Me.rcDataGridView.CurrentRow.IsNewRow Then
            Me.rcDataGridView.EndEdit()
            Me.rcBindingSource.EndEdit()
        End If
        If dtCgd.Rows.Count > 0 Then
            IsEditing = True
            SetControlEnableEvent()
            SumSlJe()
        End If
    End Sub

#End Region

#Region "导入物料采购/维修需求单"

    Private Sub BtnImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImp.Click
        If Not String.IsNullOrEmpty(Me.TxtCsdm.Text) Then
            Dim rcFrm As New FrmPoCgdImpCgjh
            With rcFrm
                .ParaStrCsdm = Me.TxtCsdm.Text
                .ParaDataSet = rcDataset
                .ShowDialog()
                Me.rcDataGridView.AllowUserToAddRows = False
                'Me.ColCpdm.ReadOnly = True
                'Me.ColSl.ReadOnly = True
                Me.ColMjsl.ReadOnly = True
                Me.ColFzsl.ReadOnly = True
                Me.BtnIns.Enabled = False
            End With
        Else
            MsgBox("请先选择供应商编码。")
        End If
    End Sub

#End Region

#Region "导入产品销售订单"

    Private Sub BtnImpDd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImpDd.Click
        If Not String.IsNullOrEmpty(Me.TxtCsdm.Text) Then
            Dim rcFrm As New FrmPoCgdImpDd
            With rcFrm
                .ParaStrCsdm = Me.TxtCsdm.Text
                .ParaDataSet = rcDataset
                .ShowDialog()
                Me.rcDataGridView.AllowUserToAddRows = False
                'Me.ColCpdm.ReadOnly = True
                'Me.ColSl.ReadOnly = True
                Me.ColMjsl.ReadOnly = True
                Me.ColFzsl.ReadOnly = True
                Me.BtnIns.Enabled = False
            End With
        Else
            MsgBox("请先选择供应商编码。")
        End If
    End Sub

#End Region

#Region "新单事件"

    Private Sub MnuiNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiNew.Click, BtnNew.Click
        NewEvent()
    End Sub

    Private Sub NewEvent()
        '清空数据
        Me.LblMsg.Text = "提示信息。"
        Me.TxtCsdm.Text = ""
        Me.LblCsmc.Text = ""
        Me.TxtSgddh.Text = ""
        Me.BtnImp.Enabled = True
        Me.rcDataGridView.AllowUserToAddRows = True
        'Me.ColCpdm.ReadOnly = False
        'Me.ColSl.ReadOnly = False
        Me.ColMjsl.ReadOnly = False
        Me.ColFzsl.ReadOnly = False
        Me.BtnIns.Enabled = True
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
            If rcDataset.Tables("rc_sysdate") IsNot Nothing Then
                rcDataset.Tables("rc_sysdate").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_sysdate")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_sysdate").Rows.Count = 1 Then
            Me.DtpCgrq.Value = rcDataset.Tables("rc_sysdate").Rows(0).Item("sysdate")
        Else
            Me.DtpCgrq.Value = Now()
        End If
        If GetInvKjqj(Me.DtpCgrq.Value) <> strKjqj Then
            DtpCgrq.Value = GetInvEnd(strYear, strMonth)
        End If
        '清空数据
        If rcDataset.Tables("rc_cgdnr") IsNot Nothing Then
            Me.rcDataset.Tables("rc_cgdnr").Clear()
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
                rcOleDbCommand.CommandText = "SELECT pzno" & strMonth & " As pzno FROM rc_lx WHERE kjnd = ? AND pzlxdm = ? and lxgs = '物料采购订单'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = strYear
                rcOleDbCommand.Parameters.AddWithValue("@pzlxdm", Trim(Me.CmbPzlxjc.SelectedValue))
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_pzno") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_pzno").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_pzno")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_pzno").Rows.Count = 0 Then
                MsgBox("请定义单据类型。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
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
        If rcDataset.Tables("rc_cgdnr").Rows.Count = 0 Then
            MsgBox("没有相应的业务，请输入。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        '(5)DataTable赋默认值
        For i = 0 To rcDataset.Tables("rc_cgdnr").Rows.Count - 1
            If rcDataset.Tables("rc_cgdnr").Rows(i).Item("cpdm").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_cgdnr").Rows(i).Item("cpdm") = ""
            End If
            'If rcDataSet.Tables("rc_cgdnr").Rows(i).Item("csdm").GetType.ToString = "System.DBNull" Then
            '    rcDataSet.Tables("rc_cgdnr").Rows(i).Item("csdm") = ""
            'End If
            If rcDataset.Tables("rc_cgdnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_cgdnr").Rows(i).Item("sl") = 0.0
            End If
            If rcDataset.Tables("rc_cgdnr").Rows(i).Item("fzsl").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_cgdnr").Rows(i).Item("fzsl") = 0.0
            End If
            If rcDataset.Tables("rc_cgdnr").Rows(i).Item("dj").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_cgdnr").Rows(i).Item("dj") = 0.0
            End If
            If rcDataset.Tables("rc_cgdnr").Rows(i).Item("hsdj").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_cgdnr").Rows(i).Item("hsdj") = 0.0
            End If
            If rcDataset.Tables("rc_cgdnr").Rows(i).Item("je").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_cgdnr").Rows(i).Item("je") = 0.0
            End If
            If rcDataset.Tables("rc_cgdnr").Rows(i).Item("shlv").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_cgdnr").Rows(i).Item("shlv") = 0.0
            End If
            If rcDataset.Tables("rc_cgdnr").Rows(i).Item("se").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_cgdnr").Rows(i).Item("se") = 0.0
            End If
            If rcDataset.Tables("rc_cgdnr").Rows(i).Item("cgmemo").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_cgdnr").Rows(i).Item("cgmemo") = ""
            End If
        Next
        '(6)物料编码检查
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            For i = 0 To rcDataset.Tables("rc_cgdnr").Rows.Count - 1
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("rc_cgdnr").Rows(i).Item("cpdm"))
                rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_cpxx"
                rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "cpdm"
                rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
                rcOleDbCommand.Parameters.Add("@pIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
                rcOleDbCommand.ExecuteNonQuery()
                If rcOleDbCommand.Parameters.Item("@pIntRecordCount").Value <> 1 Then
                    MsgBox(Trim(rcDataset.Tables("rc_cgdnr").Rows(i).Item("cpdm")) & "物料编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                    Return
                End If
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Me.TxtCsdm.Text
                rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_csxx"
                rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "csdm"
                rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
                rcOleDbCommand.Parameters.Add("@pIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
                rcOleDbCommand.ExecuteNonQuery()
                If rcOleDbCommand.Parameters.Item("@pIntRecordCount").Value <> 1 Then
                    MsgBox(Me.TxtCsdm.Text & "供应商编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                    Return
                End If
                If rcDataset.Tables("rc_cgdnr").Rows(i).Item("sl") = 0.0 Then
                    MsgBox("物料编码：" & rcDataset.Tables("rc_cgdnr").Rows(i).Item("cpdm") & "对应的数量为【零】，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
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

        '(二)存储ml
        'djh,cgrq,srr
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP3_SAVE_PO_CGD"
            For i = 0 To rcDataset.Tables("rc_cgdnr").Rows.Count - 1
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = IIf(IsAdding, 1, 0)
                rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = TxtDjh.Text
                rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = i + 1
                rcOleDbCommand.Parameters.Add("@paraDateCgrq", OleDbType.Date, 8).Value = Me.DtpCgrq.Value
                rcOleDbCommand.Parameters.Add("@paraStrSgddh", OleDbType.VarChar, 20).Value = Me.TxtSgddh.Text
                rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = Me.TxtCsdm.Text
                rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = Me.LblCsmc.Text
                rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("rc_cgdnr").Rows(i).Item("cpdm")).ToUpper
                rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("rc_cgdnr").Rows(i).Item("cpmc")
                rcOleDbCommand.Parameters.Add("@paraDateJhshrq", OleDbType.Date, 8).Value = rcDataset.Tables("rc_cgdnr").Rows(i).Item("jhshrq")
                rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_cgdnr").Rows(i).Item("sl")
                rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = rcDataset.Tables("rc_cgdnr").Rows(i).Item("dw")
                rcOleDbCommand.Parameters.Add("@paraDblMjsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_cgdnr").Rows(i).Item("mjsl")
                rcOleDbCommand.Parameters.Add("@paraDblFzsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_cgdnr").Rows(i).Item("fzsl")
                rcOleDbCommand.Parameters.Add("@paraStrFzdw", OleDbType.VarChar, 8).Value = rcDataset.Tables("rc_cgdnr").Rows(i).Item("fzdw")
                rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_cgdnr").Rows(i).Item("dj")
                rcOleDbCommand.Parameters.Add("@paraDblHsdj", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_cgdnr").Rows(i).Item("hsdj")
                rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_cgdnr").Rows(i).Item("je")
                rcOleDbCommand.Parameters.Add("@paraDblShlv", OleDbType.Numeric, 6).Value = rcDataset.Tables("rc_cgdnr").Rows(i).Item("shlv")
                rcOleDbCommand.Parameters.Add("@paraDblSe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_cgdnr").Rows(i).Item("se")
                rcOleDbCommand.Parameters.Add("@paraStrCgmemo", OleDbType.VarChar, 50).Value = rcDataset.Tables("rc_cgdnr").Rows(i).Item("cgmemo")
                rcOleDbCommand.Parameters.Add("@paraStrCgjhDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_cgdnr").Rows(i).Item("cgjhdjh")
                rcOleDbCommand.Parameters.Add("@paraIntCgjhXh", OleDbType.Integer, 4).Value = rcDataset.Tables("rc_cgdnr").Rows(i).Item("cgjhxh")
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
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
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

#Region "插入行事件"

    Private Sub BtnIns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIns.Click, MnuiIns.Click
        If Me.rcDataGridView.ReadOnly = False Then
            If dtCgd.Rows.Count > 0 Then
                Dim row As DataRow = dtCgd.NewRow
                dtCgd.Rows.InsertAt(row, rcDataGridView.CurrentCell.RowIndex)
                dtCgd.AcceptChanges()
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
            If rcDataset.Tables("rc_cgdnr").Rows.Count > 0 Then
                rcDataset.Tables("rc_cgdnr").Rows(rcDataGridView.CurrentRow.Index).Delete()
                rcDataset.Tables("rc_cgdnr").AcceptChanges()
                IsEditing = True
                SetControlEnableEvent()
            End If
        End If
    End Sub
#End Region

#Region "准备打印数据事件"

    Private Sub PreparePrintData()
        If rcRps Is Nothing Then
            rcRps = New RPS.Document
        End If
        Dim rft As String
        If blnhs Then
            rft = CurDir() + "\reports\cgdbz1.rft"
        Else
            rft = CurDir() + "\reports\cgdbz2.rft"
        End If
        rcRps.LoadTemplate(rft)
        '取RPS数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps WHERE rpsid = 'CGDBZ'"
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
        If Not String.IsNullOrEmpty(Me.TxtCsdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_csxx WHERE (csdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtCsdm.Text)
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
        End If
        '套打
        'rcRps.PaperType = 1
        rcRps.Text(-1, 1) = g_PrnDwmc & "采购单"
        rcRps.Text(-1, 2) = g_PrnDwmc_EN
        rcRps.Text(-1, 5) = "单 据 号：" & Trim(Me.TxtDjh.Text) & "  %p/%t"
        rcRps.Text(-1, 6) = "日    期：" & Me.DtpCgrq.Value.Date.ToLongDateString
        rcRps.Text(-1, 7) = "供 应 商：(" & Trim(Me.TxtCsdm.Text) & ")" & Trim(LblCsmc.Text)
        rcRps.Text(-1, 8) = "订单编号：" & Me.TxtSgddh.Text
        If rcDataset.Tables("rc_csxx") IsNot Nothing Then
            If Me.rcDataset.Tables("rc_csxx").Rows.Count > 0 Then
                rcRps.Text(-1, 9) = "联系人：" & Me.rcDataset.Tables("rc_csxx").Rows(0).Item("lxr") & "    付款天数：" & Me.rcDataset.Tables("rc_csxx").Rows(0).Item("fkts")
                rcRps.Text(-1, 10) = "TEL：" & Me.rcDataset.Tables("rc_csxx").Rows(0).Item("tel")
                rcRps.Text(-1, 11) = "FAX：" & Me.rcDataset.Tables("rc_csxx").Rows(0).Item("fax")
                If Me.rcDataset.Tables("rc_csxx").Rows(0).Item("fkts") <> 0 Then
                    rcRps.Text(-1, 22) = "4、货款结算方式：汇票或电汇，供方开具增值税专用发票，需方入帐后" & Me.rcDataset.Tables("rc_csxx").Rows(0).Item("fkts") & "天后支付货款。"
                End If
            End If
        End If
        Dim i As Integer
        Dim j As Integer
        Dim intPage As Integer
        Dim dblTotalJe As Double = 0.0
        Dim dblTotalSe As Double = 0.0
        For intPage = 1 To System.Math.Ceiling(rcDataSet.Tables("rc_cgdnr").Rows.Count / rcRps.LinesPerPage.ToString)
            For i = (intPage - 1) * rcRps.LinesPerPage.ToString To System.Math.Min(intPage * rcRps.LinesPerPage.ToString - 1, rcDataSet.Tables("rc_cgdnr").Rows.Count - 1)
                If rcDataSet.Tables("rc_cgdnr").Rows(i).RowState <> 8 Then
                    If blnhs Then
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("cpdm").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 1) = Trim(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("cpdm"))
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("cpmc").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 2) = Trim(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("cpmc"))
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 3) = Trim(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("dw"))
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 4) = Format(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("sl"), g_FormatSl)
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("hsdj").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 5) = Format(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("hsdj"), g_FormatDj)
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("je").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 6) = Format(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("je") + rcDataSet.Tables("rc_cgdnr").Rows(i).Item("se"), g_FormatJe)
                            dblTotalJe = dblTotalJe + rcDataSet.Tables("rc_cgdnr").Rows(i).Item("je") + rcDataSet.Tables("rc_cgdnr").Rows(i).Item("se")
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("jhshrq").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 7) = rcDataSet.Tables("rc_cgdnr").Rows(i).Item("jhshrq")
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("cgmemo").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 8) = Trim(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("cgmemo"))
                        End If
                    Else
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("cpdm").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 1) = Trim(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("cpdm"))
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("cpmc").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 2) = Trim(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("cpmc"))
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 3) = Trim(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("dw"))
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 4) = Format(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("sl"), g_FormatSl)
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("dj").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 5) = Format(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("dj"), g_FormatDj)
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("hsdj").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 6) = Format(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("hsdj"), g_FormatDj)
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("je").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 7) = Format(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("je"), g_FormatJe)
                            dblTotalJe += rcDataSet.Tables("rc_cgdnr").Rows(i).Item("je")
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("shlv").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 8) = Format(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("shlv") / 100, "0%")
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("se").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 9) = Format(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("se"), g_FormatJe)
                            dblTotalSe += rcDataSet.Tables("rc_cgdnr").Rows(i).Item("se")
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("jhshrq").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 10) = rcDataSet.Tables("rc_cgdnr").Rows(i).Item("jhshrq")
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("cgmemo").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 11) = Trim(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("cgmemo"))
                        End If
                    End If
                    j += 1
                End If
            Next
            If Decimal.op_Modulus(rcDataSet.Tables("rc_cgdnr").Rows.Count, rcRps.LinesPerPage.ToString) <> 0 Then
                For i = Decimal.op_Modulus(rcDataSet.Tables("rc_cgdnr").Rows.Count, rcRps.LinesPerPage.ToString) + 1 To rcRps.LinesPerPage.ToString
                    rcRps.Text(j + 1, 1) = ""
                    j += 1
                Next
            End If

            Dim m As New models.ChineseNum With {
                .InputString = dblTotalJe + dblTotalSe
            }
            rcRps.PerPageText(intPage, 12) = IIf(intPage = Math.Ceiling(rcDataSet.Tables("rc_cgdnr").Rows.Count / rcRps.LinesPerPage.ToString), "合计", "小计")
            rcRps.PerPageText(intPage, 13) = m.OutString & "   (小写)" & Format(dblTotalJe + dblTotalSe, g_FormatJe) '大写
            rcRps.PerPageText(intPage, 14) = Format(dblTotalJe, g_FormatJe)
            rcRps.PerPageText(intPage, 16) = Format(dblTotalSe, g_FormatJe)
        Next
        'rcRps.Text(-1, 7) = "开单人：" & g_User_DspName
    End Sub

#End Region

#Region "打印设置事件"

    Private Sub PageSetupEvent()
        Dim rcFrmPageSetup As New models.FrmPageSetup
        With rcFrmPageSetup
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = "CGDBZ"
            .paraRpsName = "采购订单标准格式"
            .ShowDialog()
        End With
    End Sub

    Private Sub MnuiPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPageSetup.Click
        PageSetupEvent()
    End Sub

#End Region

#Region "打印事件"

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click, MnuiPrint.Click
        Dim rcFrm As New FrmPoCgdPrint
        With rcFrm
            .ShowDialog()
            blnhs = .paraBlnHs
        End With
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
        Dim rcFrm As New FrmPoCgdPrint
        With rcFrm
            .ShowDialog()
            blnhs = .paraBlnHs
        End With
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

    Private Sub FrmCgdSrz_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If IsEditing Then
            MsgBox("已经编辑过数据，请保存数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            e.Cancel = True
        End If
    End Sub

#End Region

    Private Sub TxtSgddh_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtSgddh.Validating
        If Not String.IsNullOrEmpty(Me.TxtSgddh.Text) Then
            IsEditing = True
            SetControlEnableEvent()
        End If
    End Sub
End Class