Imports System.Data.OleDb

Public Class FrmPoCgjhSrz

#Region "定义变量"
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable '我们要利用该datatable进行金额计算
    ReadOnly dtCgjh As New DataTable("rc_cgjhnr")
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
    '增加单据的变量
    Dim IsAdding As Boolean = False
    '修改单据的变量
    Dim IsEditing As Boolean = False
    '
    Dim EditingControl As DataGridViewTextBoxEditingControl
    '合计变量
    Dim dblTotSl As Double = 0.0
    Dim dblTotFzsl As Double = 0.0
    '修改变量
    ReadOnly bInChangedEvent As Boolean = False

#End Region

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

    Private Sub FrmPoCgjhSrz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '设置DataGridView
        Me.rcDataGridView.AutoGenerateColumns = False
        Me.rcDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.rcDataGridView.Columns("ColKcsl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColKcsl").DefaultCellStyle.Format = g_FormatSl0
        Me.rcDataGridView.Columns("ColWrksl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColWrksl").DefaultCellStyle.Format = g_FormatSl0
        Me.rcDataGridView.Columns("ColZdcb").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColZdcb").DefaultCellStyle.Format = g_FormatSl0
        Me.rcDataGridView.Columns("ColZgcb").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColZgcb").DefaultCellStyle.Format = g_FormatSl0
        Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColMjsl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColMjsl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColFzsl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColFzsl").DefaultCellStyle.Format = g_FormatSl
        '取单据类型数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE lxgs = '物料需求单' AND kjnd = ? ORDER BY pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = strYear
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_lx") IsNot Nothing Then
                Me.rcDataset.Tables("rc_lx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_lx")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message)
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_lx").Rows.Count = 0 Then
            MsgBox("请定义单据类型。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        BindDropDownList(CmbPzlxjc, rcDataset.Tables("rc_lx"), "pzlxdm", "pzlxjc")

        '数据绑定
        dtCgjh.Columns.Add("cpdm", Type.GetType("System.String"))
        dtCgjh.Columns.Add("oldcpdm", Type.GetType("System.String"))
        dtCgjh.Columns.Add("cpmc", Type.GetType("System.String"))
        dtCgjh.Columns.Add("kcsl", Type.GetType("System.Double"))
        dtCgjh.Columns.Add("wrksl", Type.GetType("System.Double"))
        dtCgjh.Columns.Add("zdcb", Type.GetType("System.Double"))
        dtCgjh.Columns.Add("zgcb", Type.GetType("System.Double"))
        dtCgjh.Columns.Add("sl", Type.GetType("System.Double"))
        dtCgjh.Columns.Add("dw", Type.GetType("System.String"))
        dtCgjh.Columns.Add("mjsl", Type.GetType("System.Double"))
        dtCgjh.Columns.Add("fzsl", Type.GetType("System.Double"))
        dtCgjh.Columns.Add("fzdw", Type.GetType("System.String"))
        dtCgjh.Columns.Add("jhshrq", Type.GetType("System.DateTime"))
        dtCgjh.Columns.Add("jhmemo", Type.GetType("System.String"))
        rcDataset.Tables.Add(dtCgjh)
        With dtCgjh
            .Columns("cpdm").DefaultValue = ""
            .Columns("oldcpdm").DefaultValue = ""
            .Columns("kcsl").DefaultValue = 0.0
            .Columns("wrksl").DefaultValue = 0.0
            .Columns("zdcb").DefaultValue = 0.0
            .Columns("zgcb").DefaultValue = 0.0
            .Columns("sl").DefaultValue = 0.0
            .Columns("mjsl").DefaultValue = 0.0
            .Columns("fzsl").DefaultValue = 0.0
            .Columns("jhshrq").DefaultValue = Now.Date()
            .Columns("jhmemo").DefaultValue = ""
        End With
        '绑定数据the DataGrid to the DataSet.
        '绑定数据the DataGridview to the DataTable.
        rcBindingSource.DataSource = dtCgjh
        Me.rcDataGridView.DataSource = rcBindingSource
        rcBmb = Me.BindingContext(rcDataset, "rc_cgjhnr")
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
            If dtCgjh.Rows.Count > 0 Then
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

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbPzlxjc.KeyPress, TxtDjh.KeyPress, DtpJhrq.KeyPress, TxtBmdm.KeyPress
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

#Region "计算合计数"

    Private Sub SumSlJe()
        '计算合计数
        dblTotSl = 0.0
        dblTotFzsl = 0.0
        If rcDataset.Tables("rc_cgjhnr").Rows.Count > 0 Then
            dblTotSl = rcDataset.Tables("rc_cgjhnr").Compute("Sum(sl)", "")
            dblTotFzsl = rcDataset.Tables("rc_cgjhnr").Compute("Sum(fzsl)", "")
        End If
        Me.LblSl.Text = "数量合计：" + Format(dblTotSl, g_FormatSl)
        Me.LblFzsl.Text = "辅数量合计：" + Format(dblTotFzsl, g_FormatSl)
    End Sub

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
                        rcOleDbCommand.CommandText = "USP3_DELETE_PO_CGJH"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = Trim(Me.TxtDjh.Text)
                        rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                        rcOleDbCommand.Parameters.Add("@paraIntError", OleDbType.Integer, 4).Direction = ParameterDirection.Output
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
                            MsgBox("程序错误。" & Chr(13) & ex.Message & Chr(13) & rcOleDbCommand.Parameters("@paraIntError").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
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
        Dim i As Integer
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
                    rcOleDbCommand.CommandText = "SELECT po_cgjh.djh,po_cgjh.jhrq,po_cgjh.bmdm,po_cgjh.bmmc,po_cgjh.srr,po_cgjh.shr FROM po_cgjh WHERE (po_cgjh.djh = ? )"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.TxtDjh.Text
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("rc_cgjhnr") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_cgjhnr").Clear()
                    End If
                    If rcDataset.Tables("rc_cgjhml") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_cgjhml").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "rc_cgjhml")
                    If rcDataset.Tables("rc_cgjhml").Rows.Count > 0 Then
                        If rcDataset.Tables("rc_cgjhml").Rows(0).Item("shr").GetType.ToString <> "System.DBNull" Then
                            MsgBox("该单据已经审核，不能修改。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                            Me.TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                            IsAdding = True
                        Else
                            Me.DtpJhrq.Value = rcDataset.Tables("rc_cgjhml").Rows(0).Item("jhrq")
                            If rcDataset.Tables("rc_cgjhml").Rows(0).Item("bmdm").GetType.ToString <> "System.DBNull" Then
                                Me.TxtBmdm.Text = rcDataset.Tables("rc_cgjhml").Rows(0).Item("bmdm")
                            End If
                            If rcDataset.Tables("rc_cgjhml").Rows(0).Item("bmmc").GetType.ToString <> "System.DBNull" Then
                                Me.LblBmmc.Text = rcDataset.Tables("rc_cgjhml").Rows(0).Item("bmmc")
                            End If
                            '修改单据
                            rcOleDbCommand.CommandText = "SELECT po_cgjh.cpdm,rc_cpxx.oldcpdm,rc_cpxx.cpmc,rc_cpxx.zdcb,rc_cpxx.zgcb,po_cgjh.sl,po_cgjh.dw,po_cgjh.mjsl,po_cgjh.fzsl,po_cgjh.fzdw,po_cgjh.jhshrq,po_cgjh.jhmemo FROM po_cgjh,rc_cpxx WHERE (po_cgjh.cpdm = rc_cpxx.cpdm AND po_cgjh.djh = ?) ORDER BY po_cgjh.xh"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.TxtDjh.Text
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("rc_cgjhnr") IsNot Nothing Then
                                rcDataset.Tables("rc_cgjhnr").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "rc_cgjhnr")
                            For i = 0 To rcDataset.Tables("rc_cgjhnr").Rows.Count - 1
                                '取最新库存数量
                                rcOleDbCommand.CommandText = "SELECT COALESCE(Sum(qcsl + idsl),0.0) AS kcsl FROM inv_cpyeb WHERE kjnd = ? AND cpdm = ?"
                                rcOleDbCommand.Parameters.Clear()
                                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = strYear
                                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rc_cgjhnr").Rows(i).Item("cpdm")
                                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                If rcDataset.Tables("inv_cpyeb") IsNot Nothing Then
                                    rcDataset.Tables("inv_cpyeb").Clear()
                                End If
                                rcOleDbDataAdpt.Fill(rcDataset, "inv_cpyeb")
                                If rcDataset.Tables("inv_cpyeb").Rows.Count = 1 Then
                                    rcDataset.Tables("rc_cgjhnr").Rows(i).Item("kcsl") = rcDataset.Tables("inv_cpyeb").Rows(0).Item("kcsl")
                                Else
                                    rcDataset.Tables("rc_cgjhnr").Rows(i).Item("kcsl") = 0.0
                                End If
                                '取未入库数量
                                rcOleDbCommand.CommandText = "SELECT COALESCE(SUM(sl - cgsl),0.0) AS wrksl FROM po_cgjh WHERE bclosed = 0 AND djh <> ? AND cpdm = ? AND bcg = 0"
                                rcOleDbCommand.Parameters.Clear()
                                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.TxtDjh.Text
                                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_cgjhnr").Rows(i).Item("cpdm")
                                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                If rcDataset.Tables("po_cgjh") IsNot Nothing Then
                                    rcDataset.Tables("po_cgjh").Clear()
                                End If
                                rcOleDbDataAdpt.Fill(rcDataset, "po_cgjh")
                                If rcDataset.Tables("po_cgjh").Rows.Count = 1 Then
                                    rcDataset.Tables("rc_cgjhnr").Rows(i).Item("wrksl") = rcDataset.Tables("po_cgjh").Rows(0).Item("wrksl")
                                End If
                                rcOleDbCommand.CommandText = "SELECT COALESCE(SUM(sl - rksl),0.0) AS wrksl FROM po_cgd WHERE bclosed = 0 AND cpdm = ? AND sl <> rksl"
                                rcOleDbCommand.Parameters.Clear()
                                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_cgjhnr").Rows(i).Item("cpdm")
                                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                If rcDataset.Tables("po_cgd") IsNot Nothing Then
                                    rcDataset.Tables("po_cgd").Clear()
                                End If
                                rcOleDbDataAdpt.Fill(rcDataset, "po_cgd")
                                If rcDataset.Tables("po_cgd").Rows.Count = 1 Then
                                    rcDataset.Tables("rc_cgjhnr").Rows(i).Item("wrksl") = rcDataset.Tables("rc_cgjhnr").Rows(i).Item("wrksl") + rcDataset.Tables("po_cgd").Rows(0).Item("wrksl")
                                End If
                            Next
                            Me.rcDataGridView.ClearSelection()
                            SumSlJe()
                            IsAdding = False
                        End If
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

#Region "需求日期的事件"

    Private Sub DtpJhrq_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DtpJhrq.Validating
        Dim dateBegin As DateTime
        Dim dateEnd As DateTime
        dateBegin = getInvBegin(strYear, strMonth)
        dateEnd = getInvEnd(strYear, strMonth)
        If DtpJhrq.Value > dateEnd Or DtpJhrq.Value < dateBegin Then
            MsgBox("您输入的日期不在当前会计期间中，请重输入。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Me.DtpJhrq.Focus()
        End If
    End Sub

#End Region

#Region "部门编码的事件"

    Private Sub TxtBmdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBmdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_bmxx"
                    .paraField1 = "bmdm"
                    .paraField2 = "bmmc"
                    .paraField3 = "bmsm"
                    .paraTitle = "部门"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtBmdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtBmdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtBmdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtBmdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT bmdm,bmmc FROM rc_bmxx WHERE (bmdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(TxtBmdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_bmxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_bmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_bmxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_bmxx").Rows.Count > 0 Then
                TxtBmdm.Text = Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmdm"))
                LblBmmc.Text = Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmmc"))
            Else
                MsgBox("部门编码不存在，请按F3键选择。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                e.Cancel = True
            End If
            '检测是否最明细记录
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT COUNT(*) AS gs FROM rc_bmxx WHERE (parentid = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtBmdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("reccnt") IsNot Nothing Then
                    Me.rcDataset.Tables("reccnt").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "reccnt")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("reccnt").Rows(0).Item("gs") > 0 Then
                MsgBox("请输入最明细部门编码。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                e.Cancel = True
            End If
            If Not IsEditing Then
                IsEditing = True
                SetControlEnableEvent()
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
                    Try
                        '取物料信息
                        rcOleDbConn.Open()
                        rcOleDbCommand.Connection = rcOleDbConn
                        rcOleDbCommand.CommandTimeout = 300
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT cpdm,oldcpdm,cpmc,dw,mjsl,fzdw,zdcb,zgcb,cgts FROM rc_cpxx WHERE cpdm = ? OR oldcpdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.AddWithValue("@cpdm", rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue)
                        rcOleDbCommand.Parameters.AddWithValue("@oldcpdm", rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue)
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                            rcDataset.Tables("rc_cpxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
                        '取最新库存数量
                        rcOleDbCommand.CommandText = "SELECT COALESCE(Sum(qcsl + idsl),0.0) AS kcsl FROM inv_cpyeb WHERE kjnd = ? AND cpdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = strYear
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("inv_cpyeb") IsNot Nothing Then
                            rcDataset.Tables("inv_cpyeb").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "inv_cpyeb")
                        '取未入库数量
                        rcOleDbCommand.CommandText = "SELECT COALESCE(SUM(sl - cgsl),0.0) AS wrksl FROM po_cgjh WHERE bclosed = 0 AND djh <> ? AND cpdm = ? AND bcg = 0"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.TxtDjh.Text
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("po_cgjh") IsNot Nothing Then
                            rcDataset.Tables("po_cgjh").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "po_cgjh")
                        rcOleDbCommand.CommandText = "SELECT COALESCE(SUM(sl - rksl),0.0) AS wrksl FROM po_cgd WHERE bclosed = 0 AND cpdm = ? AND sl <> rksl"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("po_cgd") IsNot Nothing Then
                            rcDataset.Tables("po_cgd").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "po_cgd")
                    Catch ex As Exception
                        MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                    If rcDataset.Tables("rc_cpxx").Rows.Count > 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColCpdm").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("cpdm")
                        Me.rcDataGridView.CurrentRow.Cells("ColOldCpdm").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("oldcpdm")
                        Me.rcDataGridView.CurrentRow.Cells("ColCpmc").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("cpmc")
                        Me.rcDataGridView.CurrentRow.Cells("ColDw").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("dw")
                        If rcDataset.Tables("rc_cpxx").Rows(0).Item("mjsl").GetType.ToString <> "System.DBNull" And Me.rcDataGridView.CurrentRow.Cells("ColMjsl").Value = 0 Then
                            Me.rcDataGridView.CurrentRow.Cells("ColMjsl").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("mjsl")
                        Else
                            Me.rcDataGridView.CurrentRow.Cells("ColMjsl").Value = 0.0
                        End If
                        If rcDataset.Tables("rc_cpxx").Rows(0).Item("zdcb").GetType.ToString <> "System.DBNull" Then
                            Me.rcDataGridView.CurrentRow.Cells("ColZdcb").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("zdcb")
                        Else
                            Me.rcDataGridView.CurrentRow.Cells("ColZdcb").Value = 0.0
                        End If
                        If rcDataset.Tables("rc_cpxx").Rows(0).Item("Zgcb").GetType.ToString <> "System.DBNull" Then
                            Me.rcDataGridView.CurrentRow.Cells("ColZgcb").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("zgcb")
                        Else
                            Me.rcDataGridView.CurrentRow.Cells("ColZgcb").Value = 0.0
                        End If
                        If rcDataset.Tables("rc_cpxx").Rows(0).Item("fzdw").GetType.ToString <> "System.DBNull" Then
                            Me.rcDataGridView.CurrentRow.Cells("ColFzdw").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("fzdw")
                        Else
                            Me.rcDataGridView.CurrentRow.Cells("ColFzdw").Value = ""
                        End If
                        If rcDataset.Tables("rc_cpxx").Rows(0).Item("fzdw").GetType.ToString <> "System.DBNull" Then
                            Me.rcDataGridView.CurrentRow.Cells("ColFzdw").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("fzdw")
                        Else
                            Me.rcDataGridView.CurrentRow.Cells("ColFzdw").Value = ""
                        End If
                        If rcDataset.Tables("rc_cpxx").Rows(0).Item("cgts").GetType.ToString <> "System.DBNull" Then
                            Me.rcDataGridView.CurrentRow.Cells("ColJhshrq").Value = Now.Date().AddDays(rcDataset.Tables("rc_cpxx").Rows(0).Item("cgts"))
                        Else
                            Me.rcDataGridView.CurrentRow.Cells("ColJhshrq").Value = Now.Date()
                        End If
                        If rcDataset.Tables("inv_cpyeb").Rows.Count = 1 Then
                            Me.rcDataGridView.CurrentRow.Cells("ColKcsl").Value = rcDataset.Tables("inv_cpyeb").Rows(0).Item("kcsl")
                        Else
                            Me.rcDataGridView.CurrentRow.Cells("ColKcsl").Value = 0.0
                        End If
                        If rcDataset.Tables("po_cgjh").Rows.Count = 1 Then
                            Me.rcDataGridView.CurrentRow.Cells("ColWrksl").Value = rcDataset.Tables("po_cgjh").Rows(0).Item("wrksl")
                        End If
                        If rcDataset.Tables("po_cgd").Rows.Count = 1 Then
                            Me.rcDataGridView.CurrentRow.Cells("ColWrksl").Value = Me.rcDataGridView.CurrentRow.Cells("ColWrksl").Value + rcDataset.Tables("po_cgd").Rows(0).Item("wrksl")
                        End If
                    Else
                        Me.LblMsg.Text = "物料编码不存在。"
                        e.Cancel = True
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColSl" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    'If Me.rcDataGridView.CurrentRow.Cells("ColDj").Value <> 0 Then
                    '    Me.rcDataGridView.CurrentRow.Cells("ColJe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColDj").Value * e.FormattedValue, 2, MidpointRounding.AwayFromZero)
                    'End If
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
        If dtCgjh.Rows.Count > 0 Then
            IsEditing = True
            SetControlEnableEvent()
            SumSlJe()
        End If
    End Sub

#End Region

#Region "新单事件"

    Private Sub MnuiNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiNew.Click, BtnNew.Click
        NewEvent()
    End Sub

    Private Sub NewEvent()
        '清空数据
        Me.TxtBmdm.Text = ""
        Me.LblBmmc.Text = ""
        Me.LblMsg.Text = "提示信息。"
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
            Me.DtpJhrq.Value = rcDataSet.Tables("rc_sysdate").Rows(0).Item("sysdate")
        Else
            Me.DtpJhrq.Value = Now()
        End If
        If getInvKjqj(Me.DtpJhrq.Value) <> strKjqj Then
            Me.DtpJhrq.Value = getInvEnd(strYear, strMonth)
        End If
        '清空数据
        If rcDataSet.Tables("rc_cgjhnr") IsNot Nothing Then
            Me.rcDataSet.Tables("rc_cgjhnr").Clear()
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
                rcOleDbCommand.CommandText = "SELECT pzno" & strMonth & " As pzno FROM rc_lx WHERE kjnd = ? AND pzlxdm = ? and lxgs = '物料需求单'"
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
            TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataSet.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
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
        If rcDataSet.Tables("rc_cgjhnr").Rows.Count = 0 Then
            MsgBox("没有相应的业务，请输入。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If

        '(3)部门编码检查
        If String.IsNullOrEmpty(Me.TxtBmdm.Text) Then
            MsgBox("部门编码不能为空。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Trim(Me.TxtBmdm.Text)
            rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_bmxx"
            rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "bmdm"
            rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
            rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
            rcOleDbCommand.ExecuteNonQuery()
            If rcOleDbCommand.Parameters.Item("@paraIntRecordCount").Value <> 1 Then
                MsgBox(Trim(TxtBmdm.Text) & "部门编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                Me.TxtBmdm.Text = ""
                Me.LblBmmc.Text = ""
                Me.TxtBmdm.Focus()
                Return
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '(4)DataTable赋默认值
        For i = 0 To rcDataSet.Tables("rc_cgjhnr").Rows.Count - 1
            If rcDataSet.Tables("rc_cgjhnr").Rows(i).Item("cpdm").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_cgjhnr").Rows(i).Item("cpdm") = ""
            End If
            If rcDataSet.Tables("rc_cgjhnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_cgjhnr").Rows(i).Item("sl") = 0.0
            End If
            If rcDataSet.Tables("rc_cgjhnr").Rows(i).Item("mjsl").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_cgjhnr").Rows(i).Item("mjsl") = 0.0
            End If
            If rcDataSet.Tables("rc_cgjhnr").Rows(i).Item("fzsl").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_cgjhnr").Rows(i).Item("fzsl") = 0.0
            End If
            If rcDataSet.Tables("rc_cgjhnr").Rows(i).Item("jhmemo").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_cgjhnr").Rows(i).Item("jhmemo") = ""
            End If
        Next
        '(5)物料编码检查
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            For i = 0 To rcDataSet.Tables("rc_cgjhnr").Rows.Count - 1
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Trim(rcDataSet.Tables("rc_cgjhnr").Rows(i).Item("cpdm"))
                rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_cpxx"
                rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "cpdm"
                rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
                rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
                rcOleDbCommand.ExecuteNonQuery()
                If rcOleDbCommand.Parameters.Item("@paraIntRecordCount").Value <> 1 Then
                    MsgBox(Trim(rcDataSet.Tables("rc_cgjhnr").Rows(i).Item("cpdm")) & "物料编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                    Return
                End If
                If rcDataSet.Tables("rc_cgjhnr").Rows(i).Item("sl") = 0.0 Then
                    MsgBox("物料编码：" & rcDataSet.Tables("rc_cgjhnr").Rows(i).Item("cpdm") & "对应的数量为【零】，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                    Return
                End If
            Next
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '(6)单据号长度检查
        If Trim(Me.TxtDjh.Text).Length <> 15 Then
            MsgBox("单据号长度不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Return
        End If

        '(二)存储
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP3_SAVE_PO_CGJH"
            For i = 0 To rcDataSet.Tables("rc_cgjhnr").Rows.Count - 1
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = IIf(IsAdding, 1, 0)
                rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = Trim(Me.TxtDjh.Text)
                rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = i + 1
                rcOleDbCommand.Parameters.Add("@paraDateJhrq", OleDbType.Date, 8).Value = Me.DtpJhrq.Value
                rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = Me.TxtBmdm.Text
                rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 50).Value = Me.LblBmmc.Text
                rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = Trim(rcDataSet.Tables("rc_cgjhnr").Rows(i).Item("cpdm")).ToUpper
                rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 200).Value = rcDataSet.Tables("rc_cgjhnr").Rows(i).Item("cpmc")
                rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataSet.Tables("rc_cgjhnr").Rows(i).Item("sl")
                rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = rcDataSet.Tables("rc_cgjhnr").Rows(i).Item("dw")
                rcOleDbCommand.Parameters.Add("@paraDblMjsl", OleDbType.Numeric, 18).Value = rcDataSet.Tables("rc_cgjhnr").Rows(i).Item("mjsl")
                rcOleDbCommand.Parameters.Add("@paraDblFzsl", OleDbType.Numeric, 18).Value = rcDataSet.Tables("rc_cgjhnr").Rows(i).Item("fzsl")
                rcOleDbCommand.Parameters.Add("@paraStrFzdw", OleDbType.VarChar, 8).Value = rcDataSet.Tables("rc_cgjhnr").Rows(i).Item("fzdw")
                rcOleDbCommand.Parameters.Add("@paraDateJhshrq", OleDbType.Date, 8).Value = rcDataSet.Tables("rc_cgjhnr").Rows(i).Item("jhshrq")
                rcOleDbCommand.Parameters.Add("@paraStrJhmemo", OleDbType.VarChar, 50).Value = rcDataSet.Tables("rc_cgjhnr").Rows(i).Item("jhmemo")
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
            If dtCgjh.Rows.Count > 0 Then
                Dim row As DataRow = dtCgjh.NewRow
                dtCgjh.Rows.InsertAt(row, rcDataGridView.CurrentCell.RowIndex)
                dtCgjh.AcceptChanges()
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
            If rcDataSet.Tables("rc_cgjhnr").Rows.Count > 0 Then
                rcDataSet.Tables("rc_cgjhnr").Rows(rcDataGridView.CurrentRow.Index).Delete()
                rcDataSet.Tables("rc_cgjhnr").AcceptChanges()
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
        rcRps.Text(-1, 5) = "制单：" & g_User_DspName
    End Sub

#End Region

#Region "打印设置事件"

    Private Sub PageSetupEvent()
        Dim rcFrmPageSetup As New models.FrmPageSetup
        With rcFrmPageSetup
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = "CGJHBZ"
            .paraRpsName = "物料需求单标准格式"
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

    Private Sub FrmPoCkdSrz_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If IsEditing Then
            MsgBox("已经编辑过数据，请保存数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            e.Cancel = True
        End If
    End Sub

#End Region

End Class