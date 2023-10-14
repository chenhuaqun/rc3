Imports System.Math
Imports System.Data.OleDb

Public Class FrmPoCkdSrz
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable '我们要利用该datatable进行金额计算
    ReadOnly dtCkd As New DataTable("rc_ckdnr")
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
    '库存数量
    Dim dblKcsl As Double = 0.0
    Dim dblCskcsl As Double = 0.0
    Dim dblPhkcsl As Double = 0.0
    '合计变量
    Dim dblTotSl As Double = 0.0
    Dim dblTotFzsl As Double = 0.0
    Dim dblTotJe As Double = 0.0


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

    Private Sub FrmPoCkdSrz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        '取物料出库单输入项显示设备编码
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT paradblvalue FROM rc_para WHERE dwdm = ? AND paraid = '物料出库单输入项显示设备编码' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count > 0 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("paradblvalue").GetType.ToString <> "System.DBNull" Then
                    If rcDataset.Tables("rc_para").Rows(0).Item("paradblvalue") = 1 Then
                        '显示
                        Me.ColBrecycling.Visible = True
                        Me.ColBFadm.Visible = True
                        Me.ColFadm.Visible = True
                        Me.ColFamc.Visible = True
                    Else
                        '不显示
                        Me.ColBrecycling.Visible = False
                        Me.ColBFadm.Visible = False
                        Me.ColFadm.Visible = False
                        Me.ColFamc.Visible = False
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '取单据类型数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE kjnd = ? AND pzlxdm <> 'CKTZ' AND lxgs = '物料出库单' ORDER BY pzlxdm"
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
            If rcDataset.Tables("rc_lx").Rows(i).Item("pzlxdm") = "CKDJ" Then
                Me.CmbPzlxjc.SelectedValue = "CKDJ"
                Exit For
            End If
        Next
        '数据绑定
        dtCkd.Columns.Add("cpdm", Type.GetType("System.String"))
        dtCkd.Columns.Add("oldcpdm", Type.GetType("System.String"))
        dtCkd.Columns.Add("cpmc", Type.GetType("System.String"))
        dtCkd.Columns.Add("csdm", Type.GetType("System.String"))
        dtCkd.Columns.Add("csmc", Type.GetType("System.String"))
        dtCkd.Columns.Add("brecycling", Type.GetType("System.Boolean"))
        dtCkd.Columns.Add("bfadm", Type.GetType("System.Boolean"))
        dtCkd.Columns.Add("fadm", Type.GetType("System.String"))
        dtCkd.Columns.Add("famc", Type.GetType("System.String"))
        dtCkd.Columns.Add("kuwei", Type.GetType("System.String"))
        dtCkd.Columns.Add("pihao", Type.GetType("System.String"))
        dtCkd.Columns.Add("sl", Type.GetType("System.Double"))
        dtCkd.Columns.Add("dw", Type.GetType("System.String"))
        dtCkd.Columns.Add("mjsl", Type.GetType("System.Double"))
        dtCkd.Columns.Add("fzsl", Type.GetType("System.Double"))
        dtCkd.Columns.Add("fzdw", Type.GetType("System.String"))
        dtCkd.Columns.Add("dj", Type.GetType("System.Double"))
        dtCkd.Columns.Add("je", Type.GetType("System.Double"))
        dtCkd.Columns.Add("ckmemo", Type.GetType("System.String"))
        dtCkd.Columns.Add("llsqdjh", Type.GetType("System.String"))
        dtCkd.Columns.Add("llsqxh", Type.GetType("System.Int32"))
        rcDataset.Tables.Add(dtCkd)
        With rcDataset.Tables("rc_ckdnr")
            .Columns("cpdm").DefaultValue = ""
            .Columns("oldcpdm").DefaultValue = ""
            .Columns("cpmc").DefaultValue = ""
            .Columns("csdm").DefaultValue = ""
            .Columns("csmc").DefaultValue = ""
            .Columns("brecycling").DefaultValue = False
            .Columns("bfadm").DefaultValue = False
            .Columns("fadm").DefaultValue = ""
            .Columns("famc").DefaultValue = ""
            .Columns("kuwei").DefaultValue = ""
            .Columns("pihao").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("mjsl").DefaultValue = 0.0
            .Columns("fzsl").DefaultValue = 0.0
            .Columns("dj").DefaultValue = 0.0
            .Columns("je").DefaultValue = 0.0
            .Columns("ckmemo").DefaultValue = ""
            .Columns("llsqdjh").DefaultValue = ""
            .Columns("llsqxh").DefaultValue = 0
        End With
        '绑定数据the DataGridview to the DataTable.
        rcBindingSource.DataSource = dtCkd
        Me.rcDataGridView.DataSource = rcBindingSource
        rcBmb = Me.BindingContext(rcDataset, "rc_ckdnr")
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
            If dtCkd.Rows.Count > 0 Then
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

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbPzlxjc.KeyPress, TxtDjh.KeyPress, DtpCkrq.KeyPress, TxtCkdm.KeyPress, TxtBmdm.KeyPress, TxtZydm.KeyPress
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
        dblTotJe = 0.0
        If rcDataset.Tables("rc_ckdnr").Rows.Count > 0 Then
            dblTotSl = rcDataset.Tables("rc_ckdnr").Compute("Sum(sl)", "")
            dblTotFzsl = rcDataset.Tables("rc_ckdnr").Compute("Sum(fzsl)", "")
            dblTotJe = rcDataset.Tables("rc_ckdnr").Compute("Sum(je)", "")
        End If
        Me.LblSl.Text = "数量合计：" + Format(dblTotSl, g_FormatSl)
        Me.LblFzsl.Text = "辅数量合计：" + Format(dblTotFzsl, g_FormatSl)
        Me.LblJe.Text = "金额合计：" + Format(dblTotJe, g_FormatJe)
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
                        rcOleDbCommand.CommandText = "USP_DELETE_INV_CKD"
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
                    rcOleDbCommand.CommandText = "SELECT inv_ckd.djh,inv_ckd.ckrq,inv_ckd.bdelete,inv_ckd.ckdm,inv_ckd.ckmc,inv_ckd.bmdm,inv_ckd.bmmc,inv_ckd.zydm,inv_ckd.zymc,inv_ckd.srr,inv_ckd.shr FROM inv_ckd WHERE (inv_ckd.djh = ? )"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.TxtDjh.Text
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("rc_ckdnr") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_ckdnr").Clear()
                    End If
                    If rcDataset.Tables("rc_ckdml") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_ckdml").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "rc_ckdml")
                    If rcDataset.Tables("rc_ckdml").Rows.Count > 0 Then
                        If rcDataset.Tables("rc_ckdml").Rows(0).Item("shr").GetType.ToString <> "System.DBNull" Then
                            MsgBox("该单据已经审核，不能修改。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                            Me.TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                            IsAdding = True
                        Else
                            Me.DtpCkrq.Value = rcDataset.Tables("rc_ckdml").Rows(0).Item("ckrq")
                            Me.LblBdelete.Text = IIf(rcDataset.Tables("rc_ckdml").Rows(0).Item("bdelete"), "作废", "")
                            If rcDataset.Tables("rc_ckdml").Rows(0).Item("ckdm").GetType.ToString <> "System.DBNull" Then
                                Me.TxtCkdm.Text = rcDataset.Tables("rc_ckdml").Rows(0).Item("ckdm")
                            Else
                                Me.TxtCkdm.Text = ""
                            End If
                            If rcDataset.Tables("rc_ckdml").Rows(0).Item("ckmc").GetType.ToString <> "System.DBNull" Then
                                Me.LblCkmc.Text = rcDataset.Tables("rc_ckdml").Rows(0).Item("ckmc")
                            Else
                                Me.LblCkmc.Text = ""
                            End If
                            If rcDataset.Tables("rc_ckdml").Rows(0).Item("bmdm").GetType.ToString <> "System.DBNull" Then
                                Me.TxtBmdm.Text = rcDataset.Tables("rc_ckdml").Rows(0).Item("bmdm")
                            End If
                            If rcDataset.Tables("rc_ckdml").Rows(0).Item("bmmc").GetType.ToString <> "System.DBNull" Then
                                Me.LblBmmc.Text = rcDataset.Tables("rc_ckdml").Rows(0).Item("bmmc")
                            End If
                            If rcDataset.Tables("rc_ckdml").Rows(0).Item("zydm").GetType.ToString <> "System.DBNull" Then
                                Me.TxtZydm.Text = rcDataset.Tables("rc_ckdml").Rows(0).Item("zydm")
                            Else
                                Me.TxtZydm.Text = ""
                            End If
                            If rcDataset.Tables("rc_ckdml").Rows(0).Item("zymc").GetType.ToString <> "System.DBNull" Then
                                Me.LblZymc.Text = rcDataset.Tables("rc_ckdml").Rows(0).Item("zymc")
                            Else
                                Me.LblZymc.Text = ""
                            End If
                            '修改单据
                            rcOleDbCommand.CommandText = "SELECT inv_ckd.cpdm,rc_cpxx.oldcpdm,inv_ckd.cpmc,inv_ckd.csdm,inv_ckd.csmc,rc_cpxx.kuwei,rc_cpxx.brecycling,rc_cpxx.bfadm,inv_ckd.fadm,inv_ckd.famc,inv_ckd.pihao,inv_ckd.sl,inv_ckd.dw,inv_ckd.mjsl,inv_ckd.fzsl,inv_ckd.fzdw,inv_ckd.dj,inv_ckd.je,inv_ckd.ckmemo,inv_ckd.llsqdjh,inv_ckd.llsqxh FROM inv_ckd,rc_cpxx WHERE inv_ckd.cpdm = rc_cpxx.cpdm AND (inv_ckd.djh = ?) ORDER BY inv_ckd.xh"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.TxtDjh.Text
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("rc_ckdnr") IsNot Nothing Then
                                rcDataset.Tables("rc_ckdnr").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "rc_ckdnr")
                            If rcDataset.Tables("rc_ckdnr").Rows.Count > 0 Then
                                If rcDataset.Tables("rc_ckdnr").Rows(0).Item("llsqdjh").GetType.ToString <> "System.DBNull" Then
                                    Me.TxtCkdm.Enabled = False
                                    Me.TxtBmdm.Enabled = False
                                    Me.TxtZydm.Enabled = False
                                    Me.rcDataGridView.AllowUserToAddRows = False
                                    Me.ColCpdm.ReadOnly = True
                                    Me.ColFadm.ReadOnly = True
                                    Me.ColKuwei.ReadOnly = True
                                    Me.ColSl.ReadOnly = True
                                    Me.ColMjsl.ReadOnly = True
                                    Me.ColFzsl.ReadOnly = True
                                    Me.BtnIns.Enabled = False
                                    Me.MnuiIns.Enabled = False
                                Else
                                    Me.TxtCkdm.Enabled = True
                                    Me.TxtBmdm.Enabled = True
                                    Me.TxtZydm.Enabled = True
                                    Me.rcDataGridView.AllowUserToAddRows = True
                                    Me.ColCpdm.ReadOnly = False
                                    Me.ColFadm.ReadOnly = False
                                    Me.ColKuwei.ReadOnly = False
                                    Me.ColSl.ReadOnly = False
                                    Me.ColMjsl.ReadOnly = False
                                    Me.ColFzsl.ReadOnly = False
                                    Me.BtnIns.Enabled = True
                                    Me.MnuiIns.Enabled = True
                                End If
                            End If
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

#Region "出库日期的事件"

    Private Sub DtpCkrq_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DtpCkrq.Validating
        Dim dateBegin As DateTime
        Dim dateEnd As DateTime
        dateBegin = getInvBegin(strYear, strMonth)
        dateEnd = getInvEnd(strYear, strMonth)
        If DtpCkrq.Value > dateEnd Or DtpCkrq.Value < dateBegin Then
            MsgBox("您输入的日期不在当前会计期间中，请重输入。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Me.DtpCkrq.Focus()
        End If
    End Sub

#End Region

#Region "仓库编码的事件"

    Private Sub TxtCkdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCkdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_ckxx"
                    .paraField1 = "ckdm"
                    .paraField2 = "ckmc"
                    .paraField3 = "cksm"
                    .paraTitle = "仓库"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtCkdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtCkdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCkdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtCkdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_ckxx WHERE (ckdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(TxtCkdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_ckxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_ckxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_ckxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_ckxx").Rows.Count > 0 Then
                Me.TxtCkdm.Text = Trim(rcDataset.Tables("rc_ckxx").Rows(0).Item("ckdm"))
                Me.LblCkmc.Text = Trim(rcDataset.Tables("rc_ckxx").Rows(0).Item("ckmc"))
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
                rcOleDbCommand.CommandText = "SELECT * FROM rc_zyxx WHERE (zydm = ?)"
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
                        rcOleDbCommand.CommandText = "SELECT cpdm,cpmc,brecycling,bfadm,kuwei,dw,mjsl,fzdw,oldcpdm,bbatch FROM rc_cpxx WHERE (rc_cpxx.cpdm = ? OR rc_cpxx.oldcpdm = ?)"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue
                        rcOleDbCommand.Parameters.Add("@oldcpdm", OleDbType.VarChar, 15).Value = rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                            rcDataset.Tables("rc_cpxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
                        If rcDataset.Tables("rc_cpxx").Rows.Count > 0 Then
                            ''取最新库存数量
                            'rcOleDbCommand.CommandText = "SELECT COALESCE(Sum(qcsl+idsl),0.0) as kcsl FROM inv_cpyeb WHERE kjnd = ? AND cpdm = ? AND ckdm = ?"
                            'rcOleDbCommand.Parameters.Clear()
                            'rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = strYear
                            'rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue
                            'rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Me.TxtCkdm.Text
                            'rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            'If Not rcDataSet.Tables("inv_cpyeb") Is Nothing Then
                            '    rcDataSet.Tables("inv_cpyeb").Clear()
                            'End If
                            'rcOleDbDataAdpt.Fill(rcDataSet, "inv_cpyeb")
                            '取当前仓库未出库库存明细数据
                            rcOleDbCommand.CommandText = "SELECT csdm,csmc,kcsl FROM ((SELECT po_rkd.rkrq,po_rkd.csdm,po_rkd.csmc,(po_rkd.sl-COALESCE(po_rkd.cksl,0.0)) AS kcsl FROM po_rkd WHERE po_rkd.bdelete = 0 AND po_rkd.sl > 0 AND po_rkd.sl > po_rkd.cksl AND po_rkd.ckdm = ? AND po_rkd.cpdm = ?) UNION ALL (SELECT inv_rkd.rkrq, '' AS csdm,'' AS csmc,(inv_rkd.sl-COALESCE(inv_rkd.cksl,0.0)) AS kcsl FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND inv_rkd.sl > 0 AND inv_rkd.sl > inv_rkd.cksl AND inv_rkd.ckdm = ? AND inv_rkd.cpdm = ?) UNION (SELECT inv_dbd.dbrq,inv_dbd.csdm,inv_dbd.csmc,(inv_dbd.sl-COALESCE(inv_dbd.cksl,0.0)) AS kcsl FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND inv_dbd.sl > 0 AND inv_dbd.sl > inv_dbd.cksl AND inv_dbd.rckdm = ? AND inv_dbd.cpdm = ?)) rkd ORDER BY rkd.rkrq"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Me.TxtCkdm.Text
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Me.TxtCkdm.Text
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Me.TxtCkdm.Text
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("po_rkd") IsNot Nothing Then
                                rcDataset.Tables("po_rkd").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "po_rkd")
                            '当没有未出库明细时，取已出库的正数清单,准备红字冲销的数据，按时间倒序排列
                            If rcDataset.Tables("po_rkd").Rows.Count = 0 Then
                                rcOleDbCommand.CommandText = "SELECT csdm,csmc,kcsl FROM ((SELECT po_rkd.rkrq,po_rkd.csdm,po_rkd.csmc,COALESCE(po_rkd.cksl,0.0) AS kcsl FROM po_rkd WHERE po_rkd.bdelete = 0 AND po_rkd.sl > 0 AND po_rkd.cksl > 0 AND po_rkd.ckdm = ? AND po_rkd.cpdm = ?) UNION ALL (SELECT inv_rkd.rkrq, '' AS csdm,'' AS csmc,COALESCE(inv_rkd.cksl,0.0) AS kcsl FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND inv_rkd.sl > 0 AND inv_rkd.cksl > 0 AND inv_rkd.ckdm = ? AND inv_rkd.cpdm = ?) UNION (SELECT inv_dbd.dbrq,inv_dbd.csdm,inv_dbd.csmc,COALESCE(inv_dbd.cksl,0.0) AS kcsl FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND inv_dbd.sl > 0 AND inv_dbd.cksl > 0 AND inv_dbd.rckdm = ? AND inv_dbd.cpdm = ?)) rkd ORDER BY rkd.rkrq DESC"
                                rcOleDbCommand.Parameters.Clear()
                                rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Me.TxtCkdm.Text
                                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue
                                rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Me.TxtCkdm.Text
                                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue
                                rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Me.TxtCkdm.Text
                                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue
                                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                If rcDataset.Tables("po_rkd") IsNot Nothing Then
                                    rcDataset.Tables("po_rkd").Clear()
                                End If
                                rcOleDbDataAdpt.Fill(rcDataset, "po_rkd")
                            End If
                        End If
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
                        Me.rcDataGridView.CurrentRow.Cells("ColBrecycling").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("brecycling")
                        Me.rcDataGridView.CurrentRow.Cells("ColBfadm").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("bfadm")
                        If Me.rcDataGridView.CurrentRow.Cells("ColBfadm").Value = True Then
                            '跟踪设备
                            Me.rcDataGridView.CurrentRow.Cells("ColFadm").ReadOnly = False
                        Else
                            '不跟踪设备
                            Me.rcDataGridView.CurrentRow.Cells("ColFadm").ReadOnly = True
                            Me.rcDataGridView.CurrentRow.Cells("ColFadm").Value = ""
                            Me.rcDataGridView.CurrentRow.Cells("ColFamc").Value = ""
                        End If
                        Me.rcDataGridView.CurrentRow.Cells("ColKuwei").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("kuwei")
                        If rcDataset.Tables("rc_cpxx").Rows(0).Item("bbatch") = 1 Then
                            '批次管理
                            Me.rcDataGridView.CurrentRow.Cells("ColPiHao").ReadOnly = False
                        Else
                            '不批次管理
                            Me.rcDataGridView.CurrentRow.Cells("ColPiHao").ReadOnly = True
                            Me.rcDataGridView.CurrentRow.Cells("ColPiHao").Value = ""
                        End If
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
                        If rcDataset.Tables("po_rkd") IsNot Nothing Then
                            If rcDataset.Tables("po_rkd").Rows.Count > 0 Then
                                If rcDataset.Tables("po_rkd").Rows(0).Item("csdm").GetType.ToString <> "System.DBNull" Then
                                    If String.IsNullOrEmpty(Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value) Then
                                        '供应商为空时才填写
                                        Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value = rcDataset.Tables("po_rkd").Rows(0).Item("csdm")
                                        Me.rcDataGridView.CurrentRow.Cells("ColCsmc").Value = rcDataset.Tables("po_rkd").Rows(0).Item("csmc")
                                    End If
                                Else
                                    Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value = ""
                                    Me.rcDataGridView.CurrentRow.Cells("ColCsmc").Value = ""
                                End If
                            End If
                        Else
                            Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value = ""
                            Me.rcDataGridView.CurrentRow.Cells("ColCsmc").Value = ""
                        End If
                        'If Me.rcDataGridView.CurrentRow.Cells("ColPiHao").Value.GetType.ToString <> "System.DBNull" Then
                        '    dblPhkcsl = ReadPhKcsl(rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue, Me.rcDataGridView.CurrentRow.Cells("ColPiHao").Value, Me.TxtCkdm.Text, Me.TxtDjh.Text)
                        '    Me.LblMsg.Text += " 该批号库存数量：" & Format(dblPhkcsl, g_FormatSl)
                        'End If
                        showKucun(rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue, rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCsdm").Value, rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColPiHao").Value)
                    Else
                        Me.LblMsg.Text = "物料编码不存在。"
                        e.Cancel = True
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColCsdm" Then
                If Not String.IsNullOrEmpty(e.FormattedValue) Then
                    '取物料信息
                    Try
                        rcOleDbConn.Open()
                        rcOleDbCommand.Connection = rcOleDbConn
                        rcOleDbCommand.CommandTimeout = 300
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT rc_csxx.csdm,rc_csxx.csmc FROM rc_csxx WHERE csdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.AddWithValue("@csdm", rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCsdm").EditedFormattedValue)
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_csxx") IsNot Nothing Then
                            rcDataset.Tables("rc_csxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_csxx")
                    Catch ex As Exception
                        MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                    If rcDataset.Tables("rc_csxx").Rows.Count > 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value = rcDataset.Tables("rc_csxx").Rows(0).Item("csdm")
                        Me.rcDataGridView.CurrentRow.Cells("ColCsmc").Value = rcDataset.Tables("rc_csxx").Rows(0).Item("csmc")
                        ''读取仓库库存数量
                        'Me.LblMsg.Text = "仓库库存数量：" & Format(ReadKcsl(strYear, rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue, Me.TxtCkdm.Text, Me.TxtDjh.Text), g_FormatSl)
                        'dblCskcsl = ReadCsKcsl(rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").Value, rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCsdm").EditedFormattedValue, Me.TxtCkdm.Text)
                        'Me.LblMsg.Text += " 该供应商库存数量：" & Format(dblCskcsl, g_FormatSl)
                    Else
                        Me.LblMsg.Text = "供应商编码不存在。"
                        e.Cancel = True
                    End If
                    showKucun(rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").Value, rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCsdm").EditedFormattedValue, rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColPiHao").Value)
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColFadm" Then
                If Not String.IsNullOrEmpty(e.FormattedValue) Then
                    '取物料信息
                    Try
                        rcOleDbConn.Open()
                        rcOleDbCommand.Connection = rcOleDbConn
                        rcOleDbCommand.CommandTimeout = 300
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT rc_faxx.fadm,rc_faxx.famc FROM rc_faxx WHERE fadm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.AddWithValue("@fadm", rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColFadm").EditedFormattedValue)
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_faxx") IsNot Nothing Then
                            rcDataset.Tables("rc_faxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_faxx")
                    Catch ex As Exception
                        MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                    If rcDataset.Tables("rc_faxx").Rows.Count > 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColFadm").Value = rcDataset.Tables("rc_faxx").Rows(0).Item("fadm")
                        Me.rcDataGridView.CurrentRow.Cells("ColFamc").Value = rcDataset.Tables("rc_faxx").Rows(0).Item("famc")
                    Else
                        Me.LblMsg.Text = "设备编码不存在。"
                        e.Cancel = True
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColPiHao" Then
                If Not String.IsNullOrEmpty(e.FormattedValue) Then
                    '取物料信息
                    Try
                        rcOleDbConn.Open()
                        rcOleDbCommand.Connection = rcOleDbConn
                        rcOleDbCommand.CommandTimeout = 300
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT COALESCE(COUNT(*),0) AS gs FROM po_rkd WHERE pihao = ? AND cpdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.AddWithValue("@fadm", Me.rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColPiHao").EditedFormattedValue)
                        rcOleDbCommand.Parameters.AddWithValue("@cpdm", Me.rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").Value)
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("t_pihao") IsNot Nothing Then
                            rcDataset.Tables("t_pihao").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "t_pihao")
                    Catch ex As Exception
                        MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                    If rcDataset.Tables("t_pihao").Rows(0).Item("gs") <= 0 Then
                        Me.LblMsg.Text = "物料的该批次号不存在。"
                        e.Cancel = True
                    End If
                    'dblPhkcsl = ReadPhKcsl(Me.rcDataGridView.CurrentRow.Cells("ColCpdm").Value, Me.rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColPiHao").EditedFormattedValue, Me.TxtCkdm.Text, Me.TxtDjh.Text)
                    'Me.LblMsg.Text += " 该批号库存数量：" & Format(dblPhkcsl, g_FormatSl)
                End If
                showKucun(rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").Value, rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCsdm").Value, rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColPiHao").EditedFormattedValue)
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColSl" Then
                '判断库存数量与出库数量的关系
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    If e.FormattedValue > 0 Then
                        If IsAdding Then
                            If dblKcsl < e.FormattedValue Then
                                Me.LblMsg.Text = "库存数量小于领用数量，不能领料，请检查。"
                                e.Cancel = True
                            End If
                        End If
                    End If
                    '读取库存单价
                    If Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = 0 Then
                        If Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value.GetType.ToString <> "System.DBNull" Then
                            If Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value <> "" Then
                                Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = ReadCsKcdj(Me.rcDataGridView.CurrentRow.Cells("ColCpdm").Value, Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value, Me.TxtCkdm.Text, IIf(e.FormattedValue < 0, True, False))
                            Else
                                Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = ReadKcdj(strYear, Me.rcDataGridView.CurrentRow.Cells("ColCpdm").Value, Me.TxtCkdm.Text, Me.TxtDjh.Text)
                            End If
                            Me.rcDataGridView.CurrentRow.Cells("ColJe").Value = Me.rcDataGridView.CurrentRow.Cells("ColDj").Value * e.FormattedValue
                            If Me.rcDataGridView.CurrentRow.Cells("ColMjsl").Value <> 0 Then
                                If e.FormattedValue <> 0 Then
                                    If Me.rcDataGridView.CurrentRow.Cells("ColFzsl").Value = 0 Then
                                        Me.rcDataGridView.CurrentRow.Cells("ColFzsl").Value = e.FormattedValue * Me.rcDataGridView.CurrentRow.Cells("ColMjsl").Value
                                    End If
                                End If
                            End If
                        End If
                    End If
                    If Me.rcDataGridView.CurrentRow.Cells("ColDj").Value <> 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColJe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColDj").Value * e.FormattedValue, 2, MidpointRounding.AwayFromZero)
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

    'Private Sub rcDataGridView_SelectionChanged(sender As Object, e As EventArgs) Handles rcDataGridView.SelectionChanged
    '    '显示库存
    '    showKucun(Me.rcDataGridView.CurrentRow.Cells("ColCpdm").Value, Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value, Me.rcDataGridView.CurrentRow.Cells("ColPihao").Value)
    'End Sub

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
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColCsdm" And Me.ColCsdm.ReadOnly = False Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF3KeyPress
                    With rcFrm
                        .paraOleDbConn = rcOleDbConn
                        .paraTableName = "rc_csxx"
                        .paraField1 = "csdm"
                        .paraField2 = "csmc"
                        .paraField3 = "cssm"
                        .paraCondition = "0=0"
                        .paraOrderField = "csmc"
                        .paraTitle = "供应商"
                        .paraOldValue = ""
                        .paraAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            '将用户在rcfrmselectcsdm所选择的csdm带入rcdatarid'
                            Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value = .paraField1
                            Me.rcDataGridView.EndEdit()
                            Me.rcBindingSource.EndEdit()
                        End If
                    End With
            End Select
        End If
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColFadm" Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF3KeyPress
                    With rcFrm
                        .ParaOleDbConn = rcOleDbConn
                        .ParaTableName = "rc_faxx"
                        .ParaField1 = "fadm"
                        .ParaField2 = "famc"
                        .ParaField3 = "fasm"
                        .ParaCondition = "0=0"
                        .ParaOrderField = "famc"
                        .ParaTitle = "设备"
                        .ParaOldValue = ""
                        .ParaAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            '将用户在rcfrmselectfadm所选择的fadm带入rcdatarid'
                            Me.rcDataGridView.CurrentRow.Cells("ColFadm").Value = .ParaField1
                            Me.rcDataGridView.EndEdit()
                            Me.rcBindingSource.EndEdit()
                        End If
                    End With
            End Select
        End If
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColPiHao" Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF3KeyPress
                    With rcFrm
                        .ParaOleDbConn = rcOleDbConn
                        .ParaTableName = "v_cppihao"
                        .ParaField1 = "pihao"
                        .ParaField2 = "rkrq"
                        .ParaField3 = "sl"
                        .ParaCondition = "cpdm = '" & Me.rcDataGridView.CurrentRow.Cells("ColCpdm").Value & "'" & IIf(Not String.IsNullOrEmpty(Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value), " and csdm = '" & Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value & "'", "")
                        .ParaOrderField = "rkrq"
                        .ParaTitle = "批次"
                        .ParaOldValue = ""
                        .ParaAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            '将用户在rcfrmselectfadm所选择的fadm带入rcdatarid'
                            Me.rcDataGridView.CurrentRow.Cells("ColPihao").Value = .ParaField1
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
        If Me.rcDataGridView.CurrentCell.OwningColumn.Name = "ColCpdm" Or Me.rcDataGridView.CurrentCell.OwningColumn.Name = "ColCsdm" Or Me.rcDataGridView.CurrentCell.OwningColumn.Name = "ColFadm" Then
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
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColCsdm" And Me.ColCsdm.ReadOnly = False Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF3KeyPress
                    With rcFrm
                        .paraOleDbConn = rcOleDbConn
                        .paraTableName = "rc_csxx"
                        .paraField1 = "csdm"
                        .paraField2 = "csmc"
                        .paraField3 = "cssm"
                        .paraCondition = "0=0"
                        .paraOrderField = "csmc"
                        .paraTitle = "供应商"
                        .paraOldValue = ""
                        .paraAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            '将用户在rcfrmselectcsdm所选择的csdm带入rcdatarid'
                            Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value = .paraField1
                            Me.rcDataGridView.EndEdit()
                            Me.rcBindingSource.EndEdit()
                        End If
                    End With
                    e.Handled = True
            End Select
        End If
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColFadm" Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF3KeyPress
                    With rcFrm
                        .ParaOleDbConn = rcOleDbConn
                        .ParaTableName = "rc_faxx"
                        .ParaField1 = "fadm"
                        .ParaField2 = "famc"
                        .ParaField3 = "fasm"
                        .ParaCondition = "0=0"
                        .ParaOrderField = "famc"
                        .ParaTitle = "设备"
                        .ParaOldValue = ""
                        .ParaAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            '将用户在rcfrmselectfadm所选择的fadm带入rcdatarid'
                            Me.rcDataGridView.CurrentRow.Cells("ColFadm").Value = .ParaField1
                            Me.rcDataGridView.EndEdit()
                            Me.rcBindingSource.EndEdit()
                        End If
                    End With
                    e.Handled = True
            End Select
        End If
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColPiHao" Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF3KeyPress
                    With rcFrm
                        .ParaOleDbConn = rcOleDbConn
                        .ParaTableName = "v_cppihao"
                        .ParaField1 = "pihao"
                        .ParaField2 = "rkrq"
                        .ParaField3 = "sl"
                        .ParaCondition = "cpdm = '" & Me.rcDataGridView.CurrentRow.Cells("ColCpdm").Value & "'" & IIf(Not String.IsNullOrEmpty(Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value), " and csdm = '" & Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value & "'", "")
                        .ParaOrderField = "rkrq"
                        .ParaTitle = "批次"
                        .ParaOldValue = ""
                        .ParaAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            '将用户在rcfrmselectfadm所选择的fadm带入rcdatarid'
                            Me.rcDataGridView.CurrentRow.Cells("ColPihao").Value = .ParaField1
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
        If dtCkd.Rows.Count > 0 Then
            IsEditing = True
            SetControlEnableEvent()
            SumSlJe()
        End If
    End Sub

#End Region

#Region "导入领料申请单"

    Private Sub BtnImpLlsq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImpLlsq.Click
        If Not String.IsNullOrEmpty(Me.TxtCkdm.Text) Then
            Dim rcFrm As New FrmPoCkdImpLlsq
            With rcFrm
                .ParaCkdm = Me.TxtCkdm.Text
                .ParaDataSet = rcDataset
                .ShowDialog()
                Me.TxtCkdm.Enabled = False
                Me.TxtBmdm.Enabled = False
                Me.TxtBmdm.Text = .ParaBmdm
                Me.LblBmmc.Text = .ParaBmmc
                Me.TxtZydm.Enabled = False
                Me.TxtZydm.Text = .ParaZydm
                Me.LblZymc.Text = .ParaZymc
                Me.rcDataGridView.AllowUserToAddRows = False
                Me.ColCpdm.ReadOnly = True
                Me.ColFadm.ReadOnly = True
                Me.ColKuwei.ReadOnly = True
                Me.ColSl.ReadOnly = True
                Me.ColMjsl.ReadOnly = True
                Me.ColFzsl.ReadOnly = True
                Me.BtnIns.Enabled = False
                Me.MnuiIns.Enabled = False
                SumSlJe()
            End With
        Else
            MsgBox("请填仓库编码。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
        End If
    End Sub

#End Region

#Region "导入入库单"

    Private Sub BtnImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImpRkd.Click
        Dim rcFrm As New FrmPoCkdImpRkd
        With rcFrm
            .ParaDataSet = rcDataset
            .ShowDialog()
        End With
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
        Me.TxtCkdm.Enabled = True
        Me.TxtCkdm.Text = ""
        Me.LblCkmc.Text = ""
        Me.TxtBmdm.Enabled = True
        Me.TxtBmdm.Text = ""
        Me.LblBmmc.Text = ""
        Me.TxtZydm.Enabled = True
        Me.TxtZydm.Text = ""
        Me.LblZymc.Text = ""
        Me.LblBdelete.Text = ""

        Me.LblMsg.Text = "提示信息。"
        Me.rcDataGridView.AllowUserToAddRows = True
        Me.ColCpdm.ReadOnly = False
        Me.ColFadm.ReadOnly = False
        Me.ColKuwei.ReadOnly = False
        Me.ColSl.ReadOnly = False
        Me.ColMjsl.ReadOnly = False
        Me.ColFzsl.ReadOnly = False
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
            Me.DtpCkrq.Value = rcDataset.Tables("rc_sysdate").Rows(0).Item("sysdate")
        Else
            Me.DtpCkrq.Value = Now()
        End If
        If getInvKjqj(Me.DtpCkrq.Value) <> strKjqj Then
            DtpCkrq.Value = getInvEnd(strYear, strMonth)
        End If
        '清空数据
        If rcDataset.Tables("rc_ckdnr") IsNot Nothing Then
            Me.rcDataset.Tables("rc_ckdnr").Clear()
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
                rcOleDbCommand.CommandText = "SELECT pzno" & strMonth & " As pzno FROM rc_lx WHERE kjnd = ? AND pzlxdm = ? and lxgs = '物料出库单'"
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
        If rcDataset.Tables("rc_ckdnr").Rows.Count = 0 Then
            MsgBox("没有相应的业务，请输入。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        '(2)仓库编码检查
        If String.IsNullOrEmpty(Me.TxtCkdm.Text) Then
            MsgBox("仓库编码不能为空。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Trim(Me.TxtCkdm.Text)
            rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_ckxx"
            rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "ckdm"
            rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
            rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
            rcOleDbCommand.ExecuteNonQuery()
            If rcOleDbCommand.Parameters.Item("@paraIntRecordCount").Value <> 1 Then
                MsgBox(Trim(TxtCkdm.Text) & "仓库编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                Me.TxtCkdm.Text = ""
                Me.LblCkmc.Text = ""
                Me.TxtCkdm.Focus()
                Return
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
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
        ''(2)设备编码检查
        'If String.IsNullOrEmpty(Me.TxtFadm.Text) Then
        '    MsgBox("设备编码不能为空。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
        '    Return
        'End If
        'Try
        '    rcOleDbConn.Open()
        '    rcOleDbCommand.Connection = rcOleDbConn
        '    rcOleDbCommand.CommandTimeout = 300
        '    rcOleDbCommand.CommandType = CommandType.StoredProcedure
        '    rcOleDbCommand.CommandText = "USP_CHECK_CODE"
        '    rcOleDbCommand.Parameters.Clear()
        '    rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Trim(Me.TxtFadm.Text)
        '    rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_faxx"
        '    rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "fadm"
        '    rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
        '    rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
        '    rcOleDbCommand.ExecuteNonQuery()
        '    If rcOleDbCommand.Parameters.Item("@paraIntRecordCount").Value <> 1 Then
        '        MsgBox(Trim(TxtFadm.Text) & "设备编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
        '        Me.TxtFadm.Text = ""
        '        Me.LblFamc.Text = ""
        '        Me.TxtFadm.Focus()
        '        Return
        '    End If
        'Catch ex As Exception
        '    MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        '    Return
        'Finally
        '    rcOleDbConn.Close()
        'End Try
        '(4)经手人检查
        If String.IsNullOrEmpty(Me.TxtZydm.Text) Then
            MsgBox("经手人不能为空。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Trim(Me.TxtZydm.Text)
            rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_zyxx"
            rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "zydm"
            rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
            rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
            rcOleDbCommand.ExecuteNonQuery()
            If rcOleDbCommand.Parameters.Item("@paraIntRecordCount").Value <> 1 Then
                MsgBox(Trim(TxtZydm.Text) & "经手人编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
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
        '(4)DataTable赋默认值
        For i = 0 To rcDataset.Tables("rc_ckdnr").Rows.Count - 1
            If rcDataset.Tables("rc_ckdnr").Rows(i).Item("cpdm").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_ckdnr").Rows(i).Item("cpdm") = ""
            End If
            If rcDataset.Tables("rc_ckdnr").Rows(i).Item("csdm").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_ckdnr").Rows(i).Item("csdm") = ""
            End If
            If rcDataset.Tables("rc_ckdnr").Rows(i).Item("brecycling").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_ckdnr").Rows(i).Item("brecycling") = False
            End If
            If rcDataset.Tables("rc_ckdnr").Rows(i).Item("brecycling").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_ckdnr").Rows(i).Item("brecycling") = False
            End If
            If rcDataset.Tables("rc_ckdnr").Rows(i).Item("fadm").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_ckdnr").Rows(i).Item("fadm") = ""
            End If
            If rcDataset.Tables("rc_ckdnr").Rows(i).Item("kuwei").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_ckdnr").Rows(i).Item("kuwei") = ""
            End If
            If rcDataset.Tables("rc_ckdnr").Rows(i).Item("pihao").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_ckdnr").Rows(i).Item("pihao") = ""
            End If
            If rcDataset.Tables("rc_ckdnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_ckdnr").Rows(i).Item("sl") = 0.0
            End If
            If rcDataset.Tables("rc_ckdnr").Rows(i).Item("ckmemo").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_ckdnr").Rows(i).Item("ckmemo") = ""
            End If
            If rcDataset.Tables("rc_ckdnr").Rows(i).Item("llsqdjh").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_ckdnr").Rows(i).Item("llsqdjh") = ""
            End If
            If rcDataset.Tables("rc_ckdnr").Rows(i).Item("llsqxh").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_ckdnr").Rows(i).Item("llsqxh") = 0
            End If
        Next
        '(5)物料编码检查
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            For i = 0 To rcDataset.Tables("rc_ckdnr").Rows.Count - 1
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("rc_ckdnr").Rows(i).Item("cpdm"))
                rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_cpxx"
                rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "cpdm"
                rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
                rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
                rcOleDbCommand.ExecuteNonQuery()
                If rcOleDbCommand.Parameters.Item("@paraIntRecordCount").Value <> 1 Then
                    MsgBox(Trim(rcDataset.Tables("rc_ckdnr").Rows(i).Item("cpdm")) & "物料编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                    Return
                End If
                If rcDataset.Tables("rc_ckdnr").Rows(i).Item("csdm") <> "" Then
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("rc_ckdnr").Rows(i).Item("csdm"))
                    rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_csxx"
                    rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "csdm"
                    rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
                    rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
                    rcOleDbCommand.ExecuteNonQuery()
                    If rcOleDbCommand.Parameters.Item("@paraIntRecordCount").Value <> 1 Then
                        MsgBox(Trim(rcDataset.Tables("rc_ckdnr").Rows(i).Item("csdm")) & "供应商编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                        Return
                    End If
                End If
                If rcDataset.Tables("rc_ckdnr").Rows(i).Item("bfadm") = True Then
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("rc_ckdnr").Rows(i).Item("fadm"))
                    rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_faxx"
                    rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "fadm"
                    rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
                    rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
                    rcOleDbCommand.ExecuteNonQuery()
                    If rcOleDbCommand.Parameters.Item("@paraIntRecordCount").Value <> 1 Then
                        MsgBox(Trim(rcDataset.Tables("rc_ckdnr").Rows(i).Item("fadm")) & "设备编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                        Return
                    End If
                End If
                If rcDataset.Tables("rc_ckdnr").Rows(i).Item("sl") = 0.0 Then
                    MsgBox("物料编码：" & rcDataset.Tables("rc_ckdnr").Rows(i).Item("cpdm") & "对应的数量为【零】，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                    Return
                End If
            Next
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '(6)物料编码检查及批次号非空检查
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            For i = 0 To rcDataset.Tables("rc_ckdnr").Rows.Count - 1
                rcOleDbCommand.CommandText = "SELECT cpdm,COALESCE(bbatch,0) AS bbatch FROM rc_cpxx WHERE rc_cpxx.cpdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("rc_ckdnr").Rows(i).Item("cpdm"))
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("t_cpxx") IsNot Nothing Then
                    Me.rcDataset.Tables("t_cpxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "t_cpxx")
                If rcDataset.Tables("t_cpxx").Rows.Count = 1 Then
                    '判断批次号是否填列
                    If rcDataset.Tables("t_cpxx").Rows(0).Item("bbatch") = 1 Then
                        If String.IsNullOrEmpty(rcDataset.Tables("rc_ckdnr").Rows(i).Item("pihao")) Then
                            MsgBox("第" + (i + 1).ToString + "行，批次号不能为空，请填写批次号。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                            Return
                        End If
                    Else
                        If Not String.IsNullOrEmpty(rcDataset.Tables("rc_ckdnr").Rows(i).Item("pihao")) Then
                            MsgBox("第" + (i + 1).ToString + "行，批次号不需要填写。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                            Return
                        End If
                    End If
                Else
                    MsgBox(Trim(rcDataset.Tables("rc_ckdnr").Rows(i).Item("cpdm")) & "物料编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                    Return
                End If
                If IsAdding Then
                    '检查是否有后续领料未回收
                    rcOleDbCommand.CommandText = "SELECT COALESCE(COUNT(*),0) AS gs FROM inv_ckd WHERE inv_ckd.ckrq >= ? AND inv_ckd.fadm = ? AND inv_ckd.cpdm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpCkrq.Value
                    rcOleDbCommand.Parameters.Add("@fadm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("rc_ckdnr").Rows(i).Item("fadm"))
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("rc_ckdnr").Rows(i).Item("cpdm"))
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("ckgs") IsNot Nothing Then
                        rcDataset.Tables("ckgs").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "ckgs")
                    If rcDataset.Tables("ckgs").Rows(0).Item("gs") > 0 Then
                        MsgBox("该物料需要回收才能领用.", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        Return
                    End If
                End If
                If rcDataset.Tables("rc_ckdnr").Rows(i).Item("sl") = 0.0 Then
                    MsgBox("物料编码：" & rcDataset.Tables("rc_ckdnr").Rows(i).Item("cpdm") & "对应的数量为【零】，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
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
            rcOleDbCommand.CommandText = "USP3_SAVE_INV_CKD"
            For i = 0 To rcDataset.Tables("rc_ckdnr").Rows.Count - 1
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = IIf(IsAdding, 1, 0)
                rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = Trim(Me.TxtDjh.Text)
                rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = i + 1
                rcOleDbCommand.Parameters.Add("@paraDateCkrq", OleDbType.Date, 8).Value = Me.DtpCkrq.Value
                rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = IIf(String.IsNullOrEmpty(Me.LblBdelete.Text), 0, 1)
                rcOleDbCommand.Parameters.Add("@ParaStrCkdm", OleDbType.VarChar, 12).Value = Me.TxtCkdm.Text
                rcOleDbCommand.Parameters.Add("@paraStrCkmc", OleDbType.VarChar, 50).Value = Me.LblCkmc.Text
                rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = Me.TxtBmdm.Text
                rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 50).Value = Me.LblBmmc.Text
                rcOleDbCommand.Parameters.Add("@paraStrZydm", OleDbType.VarChar, 12).Value = Me.TxtZydm.Text
                rcOleDbCommand.Parameters.Add("@paraStrZymc", OleDbType.VarChar, 30).Value = Me.LblZymc.Text
                rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("rc_ckdnr").Rows(i).Item("cpdm")).ToUpper
                rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("rc_ckdnr").Rows(i).Item("cpmc")
                rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rc_ckdnr").Rows(i).Item("csdm")
                rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("rc_ckdnr").Rows(i).Item("csmc")
                rcOleDbCommand.Parameters.Add("@paraStrBrecycling", OleDbType.Numeric, 1).Value = IIf(rcDataset.Tables("rc_ckdnr").Rows(i).Item("brecycling"), 1, 0)
                rcOleDbCommand.Parameters.Add("@paraStrBfadm", OleDbType.Numeric, 1).Value = IIf(rcDataset.Tables("rc_ckdnr").Rows(i).Item("bfadm"), 1, 0)
                rcOleDbCommand.Parameters.Add("@ParaStrFadm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rc_ckdnr").Rows(i).Item("fadm")
                rcOleDbCommand.Parameters.Add("@paraStrFamc", OleDbType.VarChar, 30).Value = rcDataset.Tables("rc_ckdnr").Rows(i).Item("famc")
                rcOleDbCommand.Parameters.Add("@paraStrKuwei", OleDbType.VarChar, 40).Value = rcDataset.Tables("rc_ckdnr").Rows(i).Item("kuwei")
                rcOleDbCommand.Parameters.Add("@paraStrPiHao", OleDbType.VarChar, 40).Value = rcDataset.Tables("rc_ckdnr").Rows(i).Item("pihao")
                rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_ckdnr").Rows(i).Item("sl")
                rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = rcDataset.Tables("rc_ckdnr").Rows(i).Item("dw")
                rcOleDbCommand.Parameters.Add("@paraDblMjsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_ckdnr").Rows(i).Item("mjsl")
                rcOleDbCommand.Parameters.Add("@paraDblFzsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_ckdnr").Rows(i).Item("fzsl")
                rcOleDbCommand.Parameters.Add("@paraStrFzdw", OleDbType.VarChar, 8).Value = rcDataset.Tables("rc_ckdnr").Rows(i).Item("fzdw")
                rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_ckdnr").Rows(i).Item("dj")
                rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_ckdnr").Rows(i).Item("je")
                rcOleDbCommand.Parameters.Add("@paraStrCkmemo", OleDbType.VarChar, 50).Value = rcDataset.Tables("rc_ckdnr").Rows(i).Item("ckmemo")
                rcOleDbCommand.Parameters.Add("@paraStrLlsqDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_ckdnr").Rows(i).Item("llsqdjh")
                rcOleDbCommand.Parameters.Add("@paraIntLlsqXh", OleDbType.Integer, 4).Value = rcDataset.Tables("rc_ckdnr").Rows(i).Item("llsqxh")
                rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                rcOleDbCommand.Parameters.Add("@paraCbill_bid", OleDbType.VarChar, 20).Value = ""
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

#Region "冲销"

    Private Sub MnuiWriteOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiWriteOff.Click
        Me.rcDataGridView.Focus()
        If Not IsEditing And IsAdding Then
            '调用表单
            Dim rcFrm As New FrmPoCkdWriteOff
            Dim strDjh As String = ""
            Dim blnFp As Boolean = False
            Dim blnCk As Boolean = False
            With rcFrm
                .ShowDialog()
                strDjh = .paraStrDjh
                '读取红字冲销数据
                Try
                    rcOleDbConn.Open()
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    '修改单据
                    rcOleDbCommand.CommandText = "SELECT inv_ckd.djh,inv_ckd.ckrq,inv_ckd.bdelete,inv_ckd.ckdm,inv_ckd.ckmc,inv_ckd.bmdm,inv_ckd.bmmc,inv_ckd.zydm,inv_ckd.zymc,inv_ckd.srr,inv_ckd.shr FROM inv_ckd WHERE (inv_ckd.djh = ? )"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = strDjh
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("rc_ckdnr") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_ckdnr").Clear()
                    End If
                    If rcDataset.Tables("rc_ckdml") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_ckdml").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "rc_ckdml")
                    If rcDataset.Tables("rc_ckdml").Rows.Count > 0 Then
                        Me.DtpCkrq.Value = rcDataset.Tables("rc_ckdml").Rows(0).Item("ckrq")
                        Me.LblBdelete.Text = IIf(rcDataset.Tables("rc_ckdml").Rows(0).Item("bdelete"), "作废", "")
                        If rcDataset.Tables("rc_ckdml").Rows(0).Item("ckdm").GetType.ToString <> "System.DBNull" Then
                            Me.TxtCkdm.Text = rcDataset.Tables("rc_ckdml").Rows(0).Item("ckdm")
                        Else
                            Me.TxtCkdm.Text = ""
                        End If
                        If rcDataset.Tables("rc_ckdml").Rows(0).Item("ckmc").GetType.ToString <> "System.DBNull" Then
                            Me.LblCkmc.Text = rcDataset.Tables("rc_ckdml").Rows(0).Item("ckmc")
                        Else
                            Me.LblCkmc.Text = ""
                        End If
                        If rcDataset.Tables("rc_ckdml").Rows(0).Item("bmdm").GetType.ToString <> "System.DBNull" Then
                            Me.TxtBmdm.Text = rcDataset.Tables("rc_ckdml").Rows(0).Item("bmdm")
                        End If
                        If rcDataset.Tables("rc_ckdml").Rows(0).Item("bmmc").GetType.ToString <> "System.DBNull" Then
                            Me.LblBmmc.Text = rcDataset.Tables("rc_ckdml").Rows(0).Item("bmmc")
                        End If
                        If rcDataset.Tables("rc_ckdml").Rows(0).Item("zydm").GetType.ToString <> "System.DBNull" Then
                            Me.TxtZydm.Text = rcDataset.Tables("rc_ckdml").Rows(0).Item("zydm")
                        Else
                            Me.TxtZydm.Text = ""
                        End If
                        If rcDataset.Tables("rc_ckdml").Rows(0).Item("zymc").GetType.ToString <> "System.DBNull" Then
                            Me.LblZymc.Text = rcDataset.Tables("rc_ckdml").Rows(0).Item("zymc")
                        Else
                            Me.LblZymc.Text = ""
                        End If
                        '修改单据
                        rcOleDbCommand.CommandText = "SELECT inv_ckd.cpdm,rc_cpxx.oldcpdm,rc_cpxx.cpmc,inv_ckd.csdm,inv_ckd.csmc,rc_cpxx.kuwei,rc_cpxx.brecycling,rc_cpxx.bfadm,inv_ckd.fadm,inv_ckd.famc, 0 - inv_ckd.sl AS sl,inv_ckd.dw,inv_ckd.mjsl,(0 - inv_ckd.fzsl) AS fzsl,inv_ckd.fzdw,inv_ckd.dj,0 - inv_ckd.je AS je,inv_ckd.ckmemo,inv_ckd.llsqdjh,inv_ckd.llsqxh FROM inv_ckd,rc_cpxx WHERE inv_ckd.cpdm = rc_cpxx.cpdm AND (inv_ckd.djh = ?) ORDER BY inv_ckd.xh"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = strDjh
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_ckdnr") IsNot Nothing Then
                            rcDataset.Tables("rc_ckdnr").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_ckdnr")
                        If rcDataset.Tables("rc_ckdnr").Rows.Count > 0 Then
                            If rcDataset.Tables("rc_ckdnr").Rows(0).Item("llsqdjh").GetType.ToString <> "System.DBNull" Then
                                Me.TxtCkdm.Enabled = False
                                Me.TxtBmdm.Enabled = False
                                Me.TxtZydm.Enabled = False
                                Me.rcDataGridView.AllowUserToAddRows = False
                                Me.ColCpdm.ReadOnly = True
                                Me.ColFadm.ReadOnly = True
                                Me.ColKuwei.ReadOnly = True
                                Me.ColSl.ReadOnly = True
                                Me.ColMjsl.ReadOnly = True
                                Me.ColFzsl.ReadOnly = True
                                Me.BtnIns.Enabled = False
                                Me.MnuiIns.Enabled = False
                            Else
                                Me.TxtCkdm.Enabled = True
                                Me.TxtBmdm.Enabled = True
                                Me.TxtZydm.Enabled = True
                                Me.rcDataGridView.AllowUserToAddRows = True
                                Me.ColCpdm.ReadOnly = False
                                Me.ColFadm.ReadOnly = False
                                Me.ColKuwei.ReadOnly = False
                                Me.ColSl.ReadOnly = False
                                Me.ColMjsl.ReadOnly = False
                                Me.ColFzsl.ReadOnly = False
                                Me.BtnIns.Enabled = True
                                Me.MnuiIns.Enabled = True
                            End If
                        End If
                        Me.rcDataGridView.ClearSelection()
                        SumSlJe()
                        IsAdding = True
                        IsEditing = True
                        'blnReCalculate = False 
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
        If Not IsEditing Then
            IsEditing = True
            SetControlEnableEvent()
        End If
    End Sub

#End Region

#Region "插入行事件"

    Private Sub BtnIns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIns.Click, MnuiIns.Click
        If Me.rcDataGridView.ReadOnly = False Then
            If dtCkd.Rows.Count > 0 Then
                Dim row As DataRow = dtCkd.NewRow
                dtCkd.Rows.InsertAt(row, rcDataGridView.CurrentCell.RowIndex)
                dtCkd.AcceptChanges()
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
            If rcDataSet.Tables("rc_ckdnr").Rows.Count > 0 Then
                rcDataSet.Tables("rc_ckdnr").Rows(rcDataGridView.CurrentRow.Index).Delete()
                rcDataSet.Tables("rc_ckdnr").AcceptChanges()
                IsEditing = True
                SetControlEnableEvent()
            End If
        End If
    End Sub
#End Region

#Region "复制行"

    Private Sub Copy_Row_Click(sender As Object, e As EventArgs) Handles BtnCopy_Row.Click, MnuiCopy_Row.Click
        If Me.rcDataGridView.ReadOnly = False Then
            If dtCkd.Rows.Count > 0 Then
                Dim oldRow As DataRow = dtCkd.Rows(rcDataGridView.CurrentCell.RowIndex)
                Dim newRow As DataRow = dtCkd.NewRow()
                newRow.ItemArray = oldRow.ItemArray
                dtCkd.Rows.InsertAt(newRow, rcDataGridView.CurrentCell.RowIndex)
                dtCkd.AcceptChanges()
            End If
        End If
    End Sub

#End Region

#Region "读入excel"

    Private Sub BtnImpXls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiImpXls.Click
        '调用表单
        Dim rcFrm As New FrmPoCkdImpXls
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
        Dim rft As String = CurDir() + "\reports\pockdbz.rft"
        rcRps.LoadTemplate(rft)
        '取RPS数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps WHERE rpsid = 'POCKDBZ'"
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

        rcRps.Text(-1, 1) = g_PrnDwmc & "物料出库单"
        rcRps.Text(-1, 2) = "仓库：(" & Trim(Me.TxtCkdm.Text) & ")" & Trim(LblCkmc.Text)
        rcRps.Text(-1, 3) = "经手人：(" & Trim(Me.TxtZydm.Text) & ")" & Trim(LblZymc.Text)
        rcRps.Text(-1, 4) = "单据号：" & Trim(Me.TxtDjh.Text) & "  %p/%t"
        rcRps.Text(-1, 5) = "部门：(" & Trim(Me.TxtBmdm.Text) & ")" & Trim(LblBmmc.Text)
        rcRps.Text(-1, 6) = ""
        rcRps.Text(-1, 7) = "日期：" & DtpCkrq.Value.Date.ToLongDateString
        Dim i As Integer
        Dim j As Integer
        Dim intPage As Integer
        Dim dblTotalSl As Double = 0.0
        Dim dblTotalFzsl As Double = 0.0
        For intPage = 1 To System.Math.Ceiling(rcDataSet.Tables("rc_ckdnr").Rows.Count / rcRps.LinesPerPage.ToString)
            For i = (intPage - 1) * rcRps.LinesPerPage.ToString To System.Math.Min(intPage * rcRps.LinesPerPage.ToString - 1, rcDataSet.Tables("rc_ckdnr").Rows.Count - 1)
                If rcDataSet.Tables("rc_ckdnr").Rows(i).RowState <> 8 Then
                    If Not rcDataSet.Tables("rc_ckdnr").Rows(i).Item("cpdm").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 1) = Trim(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("cpdm"))
                    End If
                    If Not rcDataSet.Tables("rc_ckdnr").Rows(i).Item("cpmc").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 2) = Trim(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("cpmc"))
                    End If
                    'If Not rcDataSet.Tables("rc_ckdnr").Rows(i).Item("scph").GetType.ToString = "System.DBNull" Then
                    '    rcRps.Text(j + 1, 3) = Trim(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("scph"))
                    'End If
                    If Not rcDataSet.Tables("rc_ckdnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 4) = Format(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("sl"), g_FormatSl)
                        dblTotalSl += rcDataset.Tables("rc_ckdnr").Rows(i).Item("sl")
                    End If
                    If Not rcDataSet.Tables("rc_ckdnr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 5) = Trim(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("dw"))
                    End If
                    If Not rcDataSet.Tables("rc_ckdnr").Rows(i).Item("fzsl").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 6) = Format(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("fzsl"), g_FormatSl)
                        dblTotalFzsl += rcDataset.Tables("rc_ckdnr").Rows(i).Item("fzsl")
                    End If
                    If Not rcDataSet.Tables("rc_ckdnr").Rows(i).Item("fzdw").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 7) = Trim(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("fzdw"))
                    End If
                    If Not rcDataSet.Tables("rc_ckdnr").Rows(i).Item("oldcpdm").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 8) = Trim(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("oldcpdm"))
                        If Not rcDataSet.Tables("rc_ckdnr").Rows(i).Item("ckmemo").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 8) = Trim(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("oldcpdm")) & " " & Trim(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("ckmemo"))
                        End If
                    End If
                    j += 1
                End If
            Next
            Dim m As New models.ChineseNum
            'm.InputString = dblTotalJe
            rcRps.PerPageText(intPage, 8) = IIf(intPage = Math.Ceiling(rcDataSet.Tables("rc_ckdnr").Rows.Count / rcRps.LinesPerPage.ToString), "合计", "小计")
            'rcRps.PerPageText(intPage, 7) = m.OutString '大写
            rcRps.PerPageText(intPage, 10) = Format(dblTotalSl, g_FormatSl)
            rcRps.PerPageText(intPage, 12) = Format(dblTotalFzsl, g_FormatSl)
            'dblTotalJe = 0.0
        Next
        If Decimal.op_Modulus(rcDataSet.Tables("rc_ckdnr").Rows.Count, rcRps.LinesPerPage.ToString) <> 0 Then
            For i = Decimal.op_Modulus(rcDataSet.Tables("rc_ckdnr").Rows.Count, rcRps.LinesPerPage.ToString) + 1 To rcRps.LinesPerPage.ToString
                rcRps.Text(j + 1, 1) = ""
                j += 1
            Next
        End If
        rcRps.Text(-1, 12) = "制单：" & g_User_DspName
    End Sub

#End Region

#Region "打印设置事件"

    Private Sub PageSetupEvent()
        Dim rcFrmPageSetup As New models.FrmPageSetup
        With rcFrmPageSetup
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = "POCKDBZ"
            .paraRpsName = "物料出库单标准格式"
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

    Private Sub showKucun(ByVal strCpdm, ByVal strCsdm, ByVal strPiHao)
        If strCpdm.GetType.ToString <> "System.DBNull" Then
            If Not String.IsNullOrEmpty(strCpdm) Then
                '仓库库存数量
                dblKcsl = ReadKcsl(strYear, strCpdm, Me.TxtCkdm.Text, Me.TxtDjh.Text)
                Me.LblMsg.Text = "仓库库存数量：" & Format(dblKcsl, g_FormatSl)
                If strCsdm.GetType.ToString <> "System.DBNull" Then
                    If Not String.IsNullOrEmpty(strCsdm) Then
                        '计算当前供应商库存
                        dblCskcsl = ReadCsKcsl(rcDataset.Tables("rc_cpxx").Rows(0).Item("cpdm"), rcDataset.Tables("po_rkd").Rows(0).Item("csdm"), Me.TxtCkdm.Text, Me.TxtDjh.Text)
                        Me.LblMsg.Text += " 供应商库存数量：" & Format(dblCskcsl, g_FormatSl)
                    End If
                End If
                If strPiHao.GetType.ToString <> "System.DBNull" Then
                    If Not String.IsNullOrEmpty(strPiHao) Then
                        dblPhkcsl = ReadPhKcsl(rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue, Me.rcDataGridView.CurrentRow.Cells("ColPiHao").Value, Me.TxtCkdm.Text, Me.TxtDjh.Text)
                        Me.LblMsg.Text += " 批次号库存数量：" & Format(dblPhkcsl, g_FormatSl)
                    End If
                End If
            End If
        End If
    End Sub
End Class