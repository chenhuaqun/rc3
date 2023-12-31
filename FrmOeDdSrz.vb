Imports System.Math
Imports System.Data.OleDb

Public Class FrmOeDdSrz

#Region "定义变量"

    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立命令对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable '我们要利用该datatable进行计算
    ReadOnly dtDd As New DataTable("rc_ddnr")
    '建立Datatable '我们要利用该datatable进行金额计算
    ReadOnly dtDdref As New DataTable("rc_ddref")
    '数据绑定
    Dim bmbDdml As BindingManagerBase
    '新增单据的变量
    Dim IsAdding As Boolean = False
    '修改单据的变量
    Dim IsEditing As Boolean = False
    ''新增订单编码的变量
    'Dim blnNewHth As Boolean = False
    '当前位置
    Dim CurrentPos As Integer = 0
    '会计期间
    Dim strKjqj As String = g_Kjqj
    '年
    Dim strYear As String = ""
    '月
    Dim strMonth As String = ""
    Dim EditingControl As DataGridViewTextBoxEditingControl
    '合计变量
    Dim dblTotSl As Double = 0.0
    Dim dblTotFzsl As Double = 0.0
    Dim dblTotJe As Double = 0.0
    Dim dblTotSe As Double = 0.0

#End Region

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

    Private Sub FrmOeDdSrz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '设置DataGridView
        Me.rcDataGridView.AutoGenerateColumns = False
        Me.rcDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.rcDataGridView.ColumnHeadersHeight = 30
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
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE lxgs = '产品销售订单' and kjnd = '" & strYear & "' ORDER BY pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_lx") IsNot Nothing Then
                Me.rcDataset.Tables("rc_lx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_lx")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
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
            If rcDataset.Tables("rc_lx").Rows(i).Item("pzlxdm") = "XSDD" Then
                Me.CmbPzlxjc.SelectedValue = "XSDD"
                Exit For
            End If
        Next

        dtDd.Columns.Add("cpdm", Type.GetType("System.String"))
        dtDd.Columns.Add("cpmc", Type.GetType("System.String"))
        dtDd.Columns.Add("sl", Type.GetType("System.Double"))
        dtDd.Columns.Add("dw", Type.GetType("System.String"))
        dtDd.Columns.Add("mjsl", Type.GetType("System.Double"))
        dtDd.Columns.Add("fzsl", Type.GetType("System.Double"))
        dtDd.Columns.Add("fzdw", Type.GetType("System.String"))
        dtDd.Columns.Add("dj", Type.GetType("System.Double"))
        dtDd.Columns.Add("hsdj", Type.GetType("System.Double"))
        dtDd.Columns.Add("je", Type.GetType("System.Double"))
        dtDd.Columns.Add("shlv", Type.GetType("System.Double"))
        dtDd.Columns.Add("se", Type.GetType("System.Double"))
        dtDd.Columns.Add("jese", Type.GetType("System.Double"))
        dtDd.Columns.Add("khddh", Type.GetType("System.String"))
        dtDd.Columns.Add("khlh", Type.GetType("System.String"))
        dtDd.Columns.Add("khjhrq", Type.GetType("System.DateTime"))
        dtDd.Columns.Add("scjhrq", Type.GetType("System.DateTime"))
        dtDd.Columns.Add("zxgg", Type.GetType("System.String"))
        dtDd.Columns.Add("ddmemo", Type.GetType("System.String"))
        dtDd.Columns.Add("rksl", Type.GetType("System.Double"))
        dtDd.Columns.Add("hxsl", Type.GetType("System.Double"))
        dtDd.Columns.Add("cksl", Type.GetType("System.Double"))
        dtDd.Columns.Add("fpsl", Type.GetType("System.Double"))
        dtDd.Columns.Add("sdjh", Type.GetType("System.String")) '原订单单据号
        dtDd.Columns.Add("sxh", Type.GetType("System.Int32")) '原订单单据行号
        rcDataset.Tables.Add(dtDd)
        With rcDataset.Tables("rc_ddnr")
            .Columns("cpdm").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("mjsl").DefaultValue = 0.0
            .Columns("fzsl").DefaultValue = 0.0
            .Columns("dj").DefaultValue = 0
            .Columns("hsdj").DefaultValue = 0
            .Columns("je").DefaultValue = 0.0
            .Columns("shlv").DefaultValue = GetParaValue("增值税默认税率", False)
            .Columns("se").DefaultValue = 0
            .Columns("jese").DefaultValue = 0
            .Columns("zxgg").DefaultValue = ""
            .Columns("ddmemo").DefaultValue = ""
            .Columns("rksl").DefaultValue = 0.0
            .Columns("hxsl").DefaultValue = 0.0
            .Columns("cksl").DefaultValue = 0.0
            .Columns("fpsl").DefaultValue = 0.0
            .Columns("sdjh").DefaultValue = ""
            .Columns("sxh").DefaultValue = 0
        End With
        '数据绑定
        dtDdref.Columns.Add("xz", Type.GetType("System.Boolean"))
        dtDdref.Columns.Add("cpdm", Type.GetType("System.String"))
        dtDdref.Columns.Add("cpmc", Type.GetType("System.String"))
        dtDdref.Columns.Add("dw", Type.GetType("System.String"))
        dtDdref.Columns.Add("dj", Type.GetType("System.Double"))
        dtDdref.Columns.Add("hsdj", Type.GetType("System.Double"))
        dtDdref.Columns.Add("shlv", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtDdref)
        With rcDataset.Tables("rc_ddref")
            .Columns("xz").DefaultValue = 0
            .Columns("cpdm").DefaultValue = ""
            .Columns("cpmc").DefaultValue = ""
            .Columns("dw").DefaultValue = ""
            .Columns("dj").DefaultValue = 0.0
            .Columns("hsdj").DefaultValue = 0.0
            .Columns("shlv").DefaultValue = GetParaValue("增值税默认税率", False)
        End With
        '绑定数据the DataGridview to the DataTable.
        rcBindingSource.DataSource = dtDd
        Me.rcDataGridView.DataSource = rcBindingSource
        '绑定数据
        ReadDdml()
        bmbDdml = Me.BindingContext(rcDataset, "ddml")
        strKjqj = strYear & strMonth.PadLeft(2, "0")
        If GetInvKjqj(g_Kjrq) = strKjqj Then
            DtpQdrq.Value = g_Kjrq
        Else
            DtpQdrq.Value = GetInvEnd(strYear, strMonth)
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
            If dtDd.Rows.Count > 0 Then
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

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbPzlxjc.KeyPress, TxtDjh.KeyPress, DtpQdrq.KeyPress, TxtSgddh.KeyPress, TxtKhdm.KeyPress, TxtZydm.KeyPress, TxtDdtk.KeyPress, CmbSktj.KeyPress, TxtSkqx.KeyPress
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
                    rcOleDbConn.Open()
                    rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.Transaction = rcOleDbTrans
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.StoredProcedure
                    Try
                        rcOleDbCommand.CommandText = "USP_DELETE_OE_DD"
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
                        MsgBox("执行存储过程发生了错误：" & rcOleDbCommand.Parameters("@paraIntError").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
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
            '取单据号
            If rcDataset.Tables("rc_pzno").Rows.Count > 0 Then
                If rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") >= Mid(Trim(Me.TxtDjh.Text), 11, 5) Then
                    rcOleDbCommand.CommandText = "SELECT oe_dd.djh,oe_dd.qdrq,oe_dd.hth,oe_dd.khdm,oe_dd.khmc,oe_dd.zydm,oe_dd.zymc,oe_dd.ddtk,oe_dd.sktj,oe_dd.skqx,oe_dd.srr,oe_dd.shr,oe_dd.hxsl,oe_dd.rksl,oe_dd.cksl,oe_dd.fpsl FROM oe_dd WHERE (djh = ?)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Trim(Me.TxtDjh.Text)
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("rc_ddnr") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_ddnr").Clear()
                    End If
                    If rcDataset.Tables("rc_ddml") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_ddml").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "rc_ddml")
                    If rcDataset.Tables("rc_ddml").Rows.Count > 0 Then
                        '已入库、已出库、已开票不能修改
                        'Dim blnHx As Boolean = False
                        Dim blnRk As Boolean = False
                        Dim blnCk As Boolean = False
                        Dim blnFp As Boolean = False
                        Dim i As Integer
                        For i = 0 To rcDataset.Tables("rc_ddml").Rows.Count - 1
                            'If rcDataset.Tables("rc_ddml").Rows(i).Item("hxsl").GetType.ToString <> "System.DBNull" Then
                            '    If rcDataset.Tables("rc_ddml").Rows(i).Item("hxsl") <> 0 Then
                            '        blnHx = True
                            '    End If
                            'End If
                            If rcDataset.Tables("rc_ddml").Rows(i).Item("rksl").GetType.ToString <> "System.DBNull" Then
                                If rcDataset.Tables("rc_ddml").Rows(i).Item("rksl") <> 0 Then
                                    blnRk = True
                                End If
                            End If
                            If rcDataset.Tables("rc_ddml").Rows(i).Item("cksl").GetType.ToString <> "System.DBNull" Then
                                If rcDataset.Tables("rc_ddml").Rows(i).Item("cksl") <> 0 Then
                                    blnCk = True
                                End If
                            End If
                            If rcDataset.Tables("rc_ddml").Rows(i).Item("fpsl").GetType.ToString <> "System.DBNull" Then
                                If rcDataset.Tables("rc_ddml").Rows(i).Item("fpsl") <> 0 Then
                                    blnFp = True
                                End If
                            End If
                        Next
                        'If blnHx Then
                        '    MsgBox("该销售订单已经被冲销，不能修改。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        '    Me.TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                        '    IsAdding = True
                        'Else
                        If blnRk Then
                            MsgBox("该销售订单已经入库，不能修改。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                            Me.TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                            IsAdding = True
                        Else
                            If blnCk Then
                                MsgBox("该销售订单已经出库，不能修改。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                                Me.TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                                IsAdding = True
                            Else
                                If blnFp Then
                                    MsgBox("该销售订单已经开票，不能修改。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                                    Me.TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                                    IsAdding = True
                                Else
                                    If rcDataset.Tables("rc_ddml").Rows(0).Item("shr").GetType.ToString <> "System.DBNull" Then
                                        MsgBox("该单据已经审核，不能修改。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                                        Me.TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                                        IsAdding = True
                                    Else
                                        Me.DtpQdrq.Value = rcDataset.Tables("rc_ddml").Rows(0).Item("qdrq")
                                        If rcDataset.Tables("rc_ddml").Rows(0).Item("hth").GetType.ToString <> "System.DBNull" Then
                                            Me.TxtSgddh.Text = rcDataset.Tables("rc_ddml").Rows(0).Item("hth")
                                        End If
                                        If rcDataset.Tables("rc_ddml").Rows(0).Item("khdm").GetType.ToString <> "System.DBNull" Then
                                            Me.TxtKhdm.Text = rcDataset.Tables("rc_ddml").Rows(0).Item("khdm")
                                        End If
                                        If rcDataset.Tables("rc_ddml").Rows(0).Item("khmc").GetType.ToString <> "System.DBNull" Then
                                            Me.LblKhmc.Text = rcDataset.Tables("rc_ddml").Rows(0).Item("khmc")
                                        End If
                                        If rcDataset.Tables("rc_ddml").Rows(0).Item("zydm").GetType.ToString <> "System.DBNull" Then
                                            Me.TxtZydm.Text = rcDataset.Tables("rc_ddml").Rows(0).Item("zydm")
                                        End If
                                        If rcDataset.Tables("rc_ddml").Rows(0).Item("zymc").GetType.ToString <> "System.DBNull" Then
                                            Me.LblZymc.Text = rcDataset.Tables("rc_ddml").Rows(0).Item("zymc")
                                        End If
                                        If rcDataset.Tables("rc_ddml").Rows(0).Item("ddtk").GetType.ToString <> "System.DBNull" Then
                                            Me.TxtDdtk.Text = rcDataset.Tables("rc_ddml").Rows(0).Item("ddtk")
                                        End If
                                        If rcDataset.Tables("rc_ddml").Rows(0).Item("sktj").GetType.ToString <> "System.DBNull" Then
                                            Me.CmbSktj.SelectedItem = rcDataset.Tables("rc_ddml").Rows(0).Item("sktj")
                                        Else
                                            Me.CmbSktj.SelectedItem = "月结"
                                        End If
                                        If rcDataset.Tables("rc_ddml").Rows(0).Item("skqx").GetType.ToString <> "System.DBNull" Then
                                            Me.TxtSkqx.Text = rcDataset.Tables("rc_ddml").Rows(0).Item("skqx")
                                        Else
                                            Me.TxtSkqx.Text = 0
                                        End If
                                        '修改单据
                                        rcOleDbCommand.CommandText = "SELECT oe_dd.cpdm,oe_dd.cpmc,oe_dd.dw,oe_dd.sl,oe_dd.mjsl,oe_dd.fzsl,oe_dd.dj,oe_dd.hsdj,oe_dd.je,oe_dd.shlv,oe_dd.se,oe_dd.je + oe_dd.se AS jese,oe_dd.khddh,oe_dd.khlh,oe_dd.khjhrq,oe_dd.scjhrq,oe_dd.zxgg,oe_dd.ddmemo,oe_dd.sdjh,oe_dd.sxh FROM oe_dd WHERE (oe_dd.djh = ?) order by xh"
                                        rcOleDbCommand.Parameters.Clear()
                                        rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Trim(Me.TxtDjh.Text)
                                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                        If rcDataset.Tables("rc_ddnr") IsNot Nothing Then
                                            Me.rcDataset.Tables("rc_ddnr").Clear()
                                        End If
                                        rcOleDbDataAdpt.Fill(rcDataset, "rc_ddnr")
                                        Me.rcDataGridView.ClearSelection()
                                        SumSlJe()
                                        IsAdding = False
                                    End If
                                End If
                            End If
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
        If rcDataset.Tables("rc_ddnr").Rows.Count > 0 Then
            dblTotSl = dtDd.Compute("Sum(sl)", "")
            dblTotFzsl = dtDd.Compute("Sum(fzsl)", "")
            dblTotJe = dtDd.Compute("Sum(je)", "")
            dblTotSe = dtDd.Compute("Sum(se)", "")
        End If
        Me.LblSl.Text = "数量合计：" + Format(dblTotSl, g_FormatSl)
        Me.LblFzsl.Text = "辅数量合计：" + Format(dblTotFzsl, g_FormatSl)
        Me.LblJe.Text = "金额合计：" + Format(dblTotJe, g_FormatJe)
        Me.LblSe.Text = "税额合计：" + Format(dblTotSe, g_FormatJe)
        Me.LblJese.Text = "价税合计：" + Format(dblTotJe + dblTotSe, g_FormatJe)
    End Sub

#End Region

#Region "签单日期的事件"

    Private Sub DtpQdrq_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DtpQdrq.Validating
        '检查会计期间
        Dim dateBegin As DateTime
        Dim dateEnd As DateTime
        dateBegin = GetInvBegin(strYear, strMonth)
        dateEnd = GetInvEnd(strYear, strMonth)
        If DtpQdrq.Value > dateEnd Or DtpQdrq.Value < dateBegin Then
            MsgBox("您输入的日期不在当前会计期间中，请重输入。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Me.DtpQdrq.Focus()
        End If
    End Sub

#End Region

#Region "订单编码的事件"

    Private Sub TxtHth_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSgddh.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtHth_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtSgddh.Validating
        If Not String.IsNullOrEmpty(Me.TxtSgddh.Text) And IsAdding Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                '找最近一次的订单
                rcOleDbCommand.CommandText = "SELECT oe_dd.djh,oe_dd.qdrq,oe_dd.hth,oe_dd.khdm,oe_dd.khmc,oe_dd.zydm,oe_dd.zymc,oe_dd.ddtk,oe_dd.sktj,oe_dd.skqx,oe_dd.srr,oe_dd.shr FROM oe_dd WHERE (oe_dd.hth = ?) order by oe_dd.djh DESC"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@hth", OleDbType.VarChar, 30).Value = Trim(Me.TxtSgddh.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_ddml") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_ddml").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_ddml")
                If rcDataset.Tables("rc_ddml").Rows.Count > 0 Then
                    'blnNewHth = False
                    Me.TxtSgddh.Text = Trim(rcDataset.Tables("rc_ddml").Rows(0).Item("hth"))
                    If rcDataset.Tables("rc_ddml").Rows(0).Item("khdm").GetType.ToString <> "System.DBNull" Then
                        Me.TxtKhdm.Text = Trim(rcDataset.Tables("rc_ddml").Rows(0).Item("khdm"))
                    End If
                    If rcDataset.Tables("rc_ddml").Rows(0).Item("khmc").GetType.ToString <> "System.DBNull" Then
                        Me.LblKhmc.Text = Trim(rcDataset.Tables("rc_ddml").Rows(0).Item("khmc"))
                    End If
                    If rcDataset.Tables("rc_ddml").Rows(0).Item("zydm").GetType.ToString <> "System.DBNull" Then
                        Me.TxtZydm.Text = Trim(rcDataset.Tables("rc_ddml").Rows(0).Item("zydm"))
                    End If
                    If rcDataset.Tables("rc_ddml").Rows(0).Item("zymc").GetType.ToString <> "System.DBNull" Then
                        Me.LblZymc.Text = Trim(rcDataset.Tables("rc_ddml").Rows(0).Item("zymc"))
                    End If
                    If rcDataset.Tables("rc_ddml").Rows(0).Item("ddtk").GetType.ToString <> "System.DBNull" Then
                        Me.TxtDdtk.Text = Trim(rcDataset.Tables("rc_ddml").Rows(0).Item("ddtk"))
                    End If
                    If rcDataset.Tables("rc_ddml").Rows(0).Item("sktj").GetType.ToString <> "System.DBNull" Then
                        Me.CmbSktj.SelectedItem = Trim(rcDataset.Tables("rc_ddml").Rows(0).Item("sktj"))
                    Else
                        Me.CmbSktj.SelectedItem = "月结"
                    End If
                    If rcDataset.Tables("rc_ddml").Rows(0).Item("skqx").GetType.ToString <> "System.DBNull" Then
                        Me.TxtSkqx.Text = Trim(rcDataset.Tables("rc_ddml").Rows(0).Item("skqx"))
                    Else
                        Me.TxtSkqx.Text = 0
                    End If
                    '修改单据
                    rcOleDbCommand.CommandText = "SELECT oe_dd.cpdm,oe_dd.cpmc,oe_dd.dw,0 - oe_dd.sl + oe_dd.hxsl + oe_dd.cksl AS sl,oe_dd.dj,oe_dd.hsdj,ROUND((0 - oe_dd.sl + oe_dd.hxsl + oe_dd.cksl) * oe_dd.dj,2) AS je,oe_dd.shlv, ROUND((0 - oe_dd.sl + oe_dd.hxsl + oe_dd.cksl) * oe_dd.dj * oe_dd.shlv / 100,2) AS se,ROUND((0 - oe_dd.sl + oe_dd.hxsl + oe_dd.cksl) * oe_dd.dj,2) + ROUND((0 - oe_dd.sl + oe_dd.hxsl + oe_dd.cksl) * oe_dd.dj * oe_dd.shlv / 100,2) AS jese,oe_dd.khddh,oe_dd.khlh,oe_dd.khjhrq,oe_dd.scjhrq,oe_dd.zxgg,oe_dd.ddmemo,oe_dd.djh AS sdjh,oe_dd.xh AS sxh FROM oe_dd WHERE (oe_dd.sl - oe_dd.hxsl- COALESCE(oe_dd.cksl,0.0) <> 0 AND oe_dd.hth = ?)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@hth", OleDbType.VarChar, 30).Value = Trim(Me.TxtSgddh.Text)
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("rc_ddnr") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_ddnr").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "rc_ddnr")
                    Me.rcDataGridView.ClearSelection()
                    SumSlJe()
                    '控制同一个订单编码只能有一个客户编码
                    Me.TxtKhdm.Enabled = False
                Else
                    Me.TxtKhdm.Enabled = True
                End If
                IsAdding = True
            Catch ex As Exception
                MsgBox("程序错误1。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        End If
        If Not String.IsNullOrEmpty(Me.TxtSgddh.Text) Then
            If Not IsEditing Then
                IsEditing = True
                SetControlEnableEvent()
            End If
        End If
    End Sub

#End Region

#Region "客户编码的事件"

    Private Sub TxtKhdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtKhdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
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
                        Me.TxtKhdm.Text = Trim(.paraField1)
                        Me.LblKhmc.Text = Trim(.paraField2)
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
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "SELECT * FROM rc_khxx WHERE (khdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKhdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_khxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_khxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_khxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_khxx").Rows.Count > 0 Then
                Me.TxtKhdm.Text = Trim(rcDataset.Tables("rc_khxx").Rows(0).Item("khdm"))
                Me.LblKhmc.Text = Trim(rcDataset.Tables("rc_khxx").Rows(0).Item("khmc"))
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

#Region "合同其他条款的事件"

    Private Sub TxtDdmemo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDdtk.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtDdmemo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtDdtk.Validating
        If Not String.IsNullOrEmpty(Me.TxtDdtk.Text) Then
            If Not IsEditing Then
                IsEditing = True
                SetControlEnableEvent()
            End If
        End If
        If Me.rcDataGridView.Rows.Count > 0 And Me.rcDataGridView.Columns.Count > 0 Then
            Me.rcDataGridView.CurrentCell = rcDataGridView.Rows(0).Cells(0)
        End If
    End Sub

#End Region

#Region "DataGridView的事件"

    'Private Sub rcDataGridView_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles rcDataGridView.CellEnter
    '    If Me.rcDataGridView.CurrentCell.ReadOnly Then My.Computer.Keyboard.SendKeys("{Enter}")
    'End Sub

    Private Sub RcDataGridView_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles rcDataGridView.CellValidating
        If Me.rcDataGridView.CurrentRow.IsNewRow = False Then
            If rcDataGridView.IsCurrentCellDirty Then
                rcDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColCpdm" Then
                If Not String.IsNullOrEmpty(e.FormattedValue) Then
                    '取产品信息
                    Try
                        rcOleDbConn.Open()
                        rcOleDbCommand.Connection = rcOleDbConn
                        rcOleDbCommand.CommandTimeout = 300
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT * FROM rc_cpxx WHERE (rc_cpxx.cpdm = ? OR rc_cpxx.oldcpdm = ?)"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.AddWithValue("@cpdm", rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue)
                        rcOleDbCommand.Parameters.AddWithValue("@oldcpdm", rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue)
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                            rcDataset.Tables("rc_cpxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
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
                        Me.rcDataGridView.CurrentRow.Cells("ColMjsl").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("mjsl")
                        Me.rcDataGridView.CurrentRow.Cells("ColFzdw").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("fzdw")
                        '查找上次合同单价
                        If Not Convert.ToString(e.FormattedValue) = "" And Not String.IsNullOrEmpty(Me.TxtKhdm.Text) And Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = 0 Then
                            Try
                                rcOleDbConn.Open()
                                rcOleDbCommand.Connection = rcOleDbConn
                                rcOleDbCommand.CommandTimeout = 300
                                rcOleDbCommand.CommandType = CommandType.Text
                                rcOleDbCommand.CommandText = "SELECT oe_dd.djh,oe_dd.xh,oe_dd.dj,oe_dd.hsdj,oe_dd.shlv FROM oe_dd WHERE oe_dd.cpdm = ? AND oe_dd.khdm = ? AND oe_dd.sl > 0 ORDER BY oe_dd.djh Desc,oe_dd.xh Desc"
                                rcOleDbCommand.Parameters.Clear()
                                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(e.FormattedValue)
                                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKhdm.Text)
                                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                If rcDataset.Tables("ddnr") IsNot Nothing Then
                                    rcDataset.Tables("ddnr").Clear()
                                End If
                                rcOleDbDataAdpt.Fill(rcDataset, "ddnr")
                            Catch ex As Exception
                                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                                Return
                            Finally
                                rcOleDbConn.Close()
                            End Try
                            If rcDataset.Tables("ddnr").Rows.Count > 0 Then
                                Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = rcDataset.Tables("ddnr").Rows(0).Item("dj")
                                Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value = rcDataset.Tables("ddnr").Rows(0).Item("hsdj")
                                Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value = rcDataset.Tables("ddnr").Rows(0).Item("shlv")
                            End If
                        End If
                    Else
                        Me.LblMsg.Text = "产品编码不存在。"
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
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColDj" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    '录入含税单价优先
                    If e.FormattedValue <> 0 And Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value = 0.0 Then
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
        If dtDd.Rows.Count > 0 Then
            IsEditing = True
            SetControlEnableEvent()
        End If
        SumSlJe()
    End Sub

#End Region

#Region "首张的事件"

    Private Sub BtnTop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTop.Click, MnuiTop.Click
        ReadDdml()
        If bmbDdml.Count > 0 Then
            bmbDdml.Position = 0
            ShowDd(bmbDdml.Current("djh"))
        End If
    End Sub

#End Region

#Region "上张的事件"

    Private Sub BtnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevious.Click, MnuiPrevious.Click
        CurrentPos = bmbDdml.Position
        ReadDdml()
        If bmbDdml.Count > 0 Then
            If CurrentPos <= bmbDdml.Count - 1 Then
                bmbDdml.Position = CurrentPos
            End If
            If bmbDdml.Position <> 0 Then
                bmbDdml.Position -= 1
            End If
            ShowDd(bmbDdml.Current("djh"))
        End If
    End Sub

#End Region

#Region "下张的事件"

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click, MnuiNext.Click
        CurrentPos = bmbDdml.Position
        ReadDdml()
        If bmbDdml.Count > 0 Then
            If CurrentPos <= bmbDdml.Count - 1 Then
                bmbDdml.Position = CurrentPos
            End If
            If bmbDdml.Position <> bmbDdml.Count Then
                bmbDdml.Position += 1
                ShowDd(bmbDdml.Current("djh"))
            End If
        End If
    End Sub

#End Region

#Region "末张的事件"

    Private Sub BtnBottom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBottom.Click, MnuiBottom.Click
        ReadDdml()
        If bmbDdml.Count > 0 Then
            bmbDdml.Position = bmbDdml.Count - 1
            ShowDd(bmbDdml.Current("djh"))
        End If
    End Sub

#End Region

#Region "显示单据事件"

    Private Sub ShowDd(ByVal ddDjh As String)
        '如果执行此功能,则
        IsAdding = False
        '判断ddDjh

        '取oe_fhdml数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT oe_dd.djh,oe_dd.qdrq,oe_dd.hth,oe_dd.khdm,oe_dd.khmc,oe_dd.zydm,oe_dd.zymc,oe_dd.ddtk,oe_dd.sktj,oe_dd.skqx,oe_dd.srr,oe_dd.shr FROM oe_dd WHERE djh = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Trim(ddDjh)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_ddml") IsNot Nothing Then
                rcDataset.Tables("rc_ddml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_ddml")
            rcOleDbCommand.CommandText = "SELECT oe_dd.cpdm,oe_dd.cpmc,oe_dd.sl,oe_dd.dw,oe_dd.mjsl,oe_dd.fzsl,oe_dd.fzdw,oe_dd.dj,oe_dd.hsdj,oe_dd.je,oe_dd.shlv,oe_dd.se,oe_dd.je+oe_dd.se AS jese,oe_dd.khddh,oe_dd.khlh,oe_dd.khjhrq,oe_dd.scjhrq,oe_dd.zxgg,oe_dd.ddmemo,oe_dd.sdjh,oe_dd.sxh FROM oe_dd WHERE (oe_dd.djh = ?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Trim(ddDjh)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_ddnr") IsNot Nothing Then
                rcDataset.Tables("rc_ddnr").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_ddnr")
            Me.rcDataGridView.ClearSelection()
            SumSlJe()
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_ddml").Rows.Count > 0 Then
            '赋值
            Me.TxtDjh.Text = Trim(rcDataset.Tables("rc_ddml").Rows(0).Item("djh"))
            Me.DtpQdrq.Value = rcDataset.Tables("rc_ddml").Rows(0).Item("qdrq")
            If rcDataset.Tables("rc_ddml").Rows(0).Item("hth").GetType.ToString <> "System.DBNull" Then
                Me.TxtSgddh.Text = rcDataset.Tables("rc_ddml").Rows(0).Item("hth")
            End If
            If rcDataset.Tables("rc_ddml").Rows(0).Item("khdm").GetType.ToString <> "System.DBNull" Then
                Me.TxtKhdm.Text = rcDataset.Tables("rc_ddml").Rows(0).Item("khdm")
            End If
            If rcDataset.Tables("rc_ddml").Rows(0).Item("khmc").GetType.ToString <> "System.DBNull" Then
                Me.LblKhmc.Text = rcDataset.Tables("rc_ddml").Rows(0).Item("khmc")
            End If
            If rcDataset.Tables("rc_ddml").Rows(0).Item("zydm").GetType.ToString <> "System.DBNull" Then
                Me.TxtZydm.Text = rcDataset.Tables("rc_ddml").Rows(0).Item("zydm")
            End If
            If rcDataset.Tables("rc_ddml").Rows(0).Item("zymc").GetType.ToString <> "System.DBNull" Then
                Me.LblZymc.Text = rcDataset.Tables("rc_ddml").Rows(0).Item("zymc")
            End If
            If rcDataset.Tables("rc_ddml").Rows(0).Item("ddtk").GetType.ToString <> "System.DBNull" Then
                Me.TxtDdtk.Text = rcDataset.Tables("rc_ddml").Rows(0).Item("ddtk")
            End If
            If rcDataset.Tables("rc_ddml").Rows(0).Item("sktj").GetType.ToString <> "System.DBNull" Then
                Me.CmbSktj.SelectedItem = rcDataset.Tables("rc_ddml").Rows(0).Item("sktj")
            Else
                Me.CmbSktj.SelectedItem = "月结"
            End If
            If rcDataset.Tables("rc_ddml").Rows(0).Item("skqx").GetType.ToString <> "System.DBNull" Then
                Me.TxtSkqx.Text = rcDataset.Tables("rc_ddml").Rows(0).Item("skqx")
            Else
                Me.TxtSkqx.Text = 0
            End If
        End If
    End Sub

    Private Sub ReadDdml()
        '检查会计期间
        Dim dateBegin As DateTime
        Dim dateEnd As DateTime
        dateBegin = GetInvBegin(strYear, strMonth)
        dateEnd = GetInvEnd(strYear, strMonth)
        '取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT djh FROM oe_dd WHERE qdrq >= ? AND qdrq <= ? AND shr IS NULL ORDER BY djh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@qdrq1", OleDbType.Date, 8).Value = dateBegin
            rcOleDbCommand.Parameters.Add("@qdrq2", OleDbType.Date, 8).Value = dateEnd
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("ddml") IsNot Nothing Then
                rcDataset.Tables("ddml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "ddml")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
    End Sub

#End Region

#Region "新增单据事件"

    Private Sub MnuiNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiNew.Click
        NewEvent()
        DtpQdrq.Focus()
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        NewEvent()
        DtpQdrq.Focus()
    End Sub

    Private Sub NewEvent()
        '清空数据
        Me.TxtKhdm.Text = ""
        Me.TxtKhdm.Enabled = True
        Me.LblKhmc.Text = ""
        Me.TxtZydm.Text = ""
        Me.LblZymc.Text = ""
        Me.TxtDdtk.Text = ""
        Me.CmbSktj.SelectedItem = "月结"
        Me.TxtSkqx.Text = 0
        '显示新单据号
        ShowNewDjh()
        IsAdding = True
        'blnNewHth = True '新订单编码为真
        IsEditing = False
        Me.TxtSgddh.Text = Mid(Me.TxtDjh.Text, 5, 11)
        '清空数据
        If rcDataset.Tables("rc_ddnr") IsNot Nothing Then
            Me.rcDataset.Tables("rc_ddnr").Clear()
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
                rcOleDbCommand.CommandText = "SELECT pzno" & strMonth & " as pzno FROM rc_lx WHERE pzlxdm = ? and lxgs = '产品销售订单' and kjnd = '" & strYear & "'"
                rcOleDbCommand.Parameters.Clear()
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
            If rcDataset.Tables("rc_pzno").Rows.Count > 0 Then
                Me.TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
            Else
                MsgBox("请定义单据类型。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
        End If
    End Sub

#End Region

#Region "保存单据数据事件"

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MnuiSave.Click
        Dim i As Integer
        '(一)数据合法性检查
        '手工订单号
        If String.IsNullOrEmpty(Me.TxtSgddh.Text) Then
            MsgBox("手工订单号不能为空，请输入。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        '(1)是否有需要存储的数据
        rcDataset.Tables("rc_ddnr").AcceptChanges()
        If rcDataset.Tables("rc_ddnr").Rows.Count = 0 Then
            MsgBox("没有相应的业务，请输入。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.StoredProcedure
        Try
            '(2)客户检查
            If Trim(Me.TxtKhdm.Text).Length = 0 Then
                MsgBox("请输入客户编码。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
                Return
            End If
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 12).Value = Trim(Me.TxtKhdm.Text)
            rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_khxx"
            rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "khdm"
            rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
            rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
            rcOleDbCommand.ExecuteNonQuery()
            If rcOleDbCommand.Parameters.Item("@paraIntRecordCount").Value <> 1 Then
                MsgBox(Trim(Me.TxtKhdm.Text) & "客户编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                Me.TxtKhdm.Text = ""
                Me.LblKhmc.Text = ""
                Me.TxtKhdm.Focus()
                Return
            End If
            '(2)职员检查
            If Trim(Me.TxtZydm.Text).Length = 0 Then
                MsgBox("请输入业务员编码。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
                Return
            End If
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 12).Value = Trim(Me.TxtZydm.Text)
            rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_zyxx"
            rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "zydm"
            rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
            rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
            rcOleDbCommand.ExecuteNonQuery()
            If rcOleDbCommand.Parameters.Item("@paraIntRecordCount").Value <> 1 Then
                MsgBox(Trim(Me.TxtZydm.Text) & "业务员编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                Me.TxtZydm.Text = ""
                Me.LblZymc.Text = ""
                Me.TxtZydm.Focus()
                Return
            End If
            '(4)产品编码检查
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            For i = 0 To rcDataset.Tables("rc_ddnr").Rows.Count - 1
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("rc_ddnr").Rows(i).Item("cpdm"))
                rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_cpxx"
                rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "cpdm"
                rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
                rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
                rcOleDbCommand.ExecuteNonQuery()
                If rcOleDbCommand.Parameters.Item("@paraIntRecordCount").Value <> 1 Then
                    MsgBox(Trim(rcDataset.Tables("rc_ddnr").Rows(i).Item("cpdm")) & "产品编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                    Return
                End If
                If rcDataset.Tables("rc_ddnr").Rows(i).Item("khjhrq").GetType.ToString = "System.DBNull" Then
                    MsgBox("客户交货日期不能为空，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                    Return
                End If
                If rcDataset.Tables("rc_ddnr").Rows(i).Item("scjhrq").GetType.ToString = "System.DBNull" Then
                    MsgBox("生产交货日期不能为空，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                    Return
                End If
            Next
            rcOleDbTrans.Commit()
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '(5)单据号长度检查
        If Trim(Me.TxtDjh.Text).Length <> 15 Then
            MsgBox("单据号长度不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Return
        End If
        '(二)存储ml
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            '(三)存储nr
            rcOleDbCommand.CommandText = "USP3_SAVE_OE_DD"
            For i = 0 To rcDataset.Tables("rc_ddnr").Rows.Count - 1
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = IIf(IsAdding, 1, 0)
                rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = Trim(Me.TxtDjh.Text)
                rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = i + 1
                rcOleDbCommand.Parameters.Add("@paraDateQdrq", OleDbType.Date, 8).Value = Me.DtpQdrq.Value
                rcOleDbCommand.Parameters.Add("@paraStrHth", OleDbType.VarChar, 30).Value = Me.TxtSgddh.Text
                rcOleDbCommand.Parameters("@paraStrHth").Direction = ParameterDirection.InputOutput
                rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = Me.TxtKhdm.Text
                rcOleDbCommand.Parameters.Add("@paraStrKhmc", OleDbType.VarChar, 50).Value = Me.LblKhmc.Text
                rcOleDbCommand.Parameters.Add("@paraStrZydm", OleDbType.VarChar, 12).Value = Me.TxtZydm.Text
                rcOleDbCommand.Parameters.Add("@paraStrZymc", OleDbType.VarChar, 30).Value = Me.LblZymc.Text
                rcOleDbCommand.Parameters.Add("@paraStrDdtk", OleDbType.VarChar, 200).Value = Me.TxtDdtk.Text '合同其他条款
                rcOleDbCommand.Parameters.Add("@paraStrSktj", OleDbType.VarChar, 10).Value = Trim(Me.CmbSktj.SelectedItem)
                rcOleDbCommand.Parameters.Add("@paraIntSkqx", OleDbType.Integer, 4).Value = Me.TxtSkqx.Text
                rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("rc_ddnr").Rows(i).Item("cpdm")).ToUpper
                rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("rc_ddnr").Rows(i).Item("cpmc")
                rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_ddnr").Rows(i).Item("sl")
                rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = rcDataset.Tables("rc_ddnr").Rows(i).Item("dw")
                rcOleDbCommand.Parameters.Add("@paraDblMjsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_ddnr").Rows(i).Item("mjsl")
                rcOleDbCommand.Parameters.Add("@paraDblFzsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_ddnr").Rows(i).Item("fzsl")
                rcOleDbCommand.Parameters.Add("@paraStrFzdw", OleDbType.VarChar, 8).Value = rcDataset.Tables("rc_ddnr").Rows(i).Item("fzdw")
                rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_ddnr").Rows(i).Item("dj")
                rcOleDbCommand.Parameters.Add("@paraDblHsdj", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_ddnr").Rows(i).Item("hsdj")
                rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_ddnr").Rows(i).Item("je")
                rcOleDbCommand.Parameters.Add("@paraDblShlv", OleDbType.Numeric, 6).Value = rcDataset.Tables("rc_ddnr").Rows(i).Item("shlv")
                rcOleDbCommand.Parameters.Add("@paraDblSe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_ddnr").Rows(i).Item("se")
                rcOleDbCommand.Parameters.Add("@paraStrKhddh", OleDbType.VarChar, 30).Value = rcDataset.Tables("rc_ddnr").Rows(i).Item("khddh")
                rcOleDbCommand.Parameters.Add("@paraStrKhlh", OleDbType.VarChar, 30).Value = rcDataset.Tables("rc_ddnr").Rows(i).Item("khlh")
                rcOleDbCommand.Parameters.Add("@paraDateKhjhrq", OleDbType.Date).Value = rcDataset.Tables("rc_ddnr").Rows(i).Item("khjhrq")
                rcOleDbCommand.Parameters.Add("@paraDateScjhrq", OleDbType.Date).Value = rcDataset.Tables("rc_ddnr").Rows(i).Item("scjhrq")
                rcOleDbCommand.Parameters.Add("@paraStrZxgg", OleDbType.VarChar, 50).Value = rcDataset.Tables("rc_ddnr").Rows(i).Item("zxgg")
                rcOleDbCommand.Parameters.Add("@paraStrDdmemo", OleDbType.VarChar, 50).Value = rcDataset.Tables("rc_ddnr").Rows(i).Item("ddmemo")
                rcOleDbCommand.Parameters.Add("@paraStrSdjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_ddnr").Rows(i).Item("sdjh")
                rcOleDbCommand.Parameters.Add("@paraIntSxh", OleDbType.Integer, 4).Value = rcDataset.Tables("rc_ddnr").Rows(i).Item("sxh")
                rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                'rcOleDbCommand.Parameters.Add("@paraIntError", OleDbType.Integer, 4).Direction = ParameterDirection.Output
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
                If rcOleDbCommand.Parameters("@paraStrHth").Value.GetType.ToString <> "System.DBNull" Then
                    If rcOleDbCommand.Parameters("@paraStrHth").Value <> "" Then
                        Me.TxtSgddh.Text = Trim(rcOleDbCommand.Parameters("@paraStrHth").Value)
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
            If dtDd.Rows.Count > 0 Then
                Dim row As DataRow = dtDd.NewRow
                dtDd.Rows.InsertAt(row, rcDataGridView.CurrentCell.RowIndex)
                dtDd.AcceptChanges()
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
            If rcDataset.Tables("rc_ddnr").Rows.Count > 0 Then
                rcDataset.Tables("rc_ddnr").Rows(rcDataGridView.CurrentRow.Index).Delete()
                rcDataset.Tables("rc_ddnr").AcceptChanges()
                IsEditing = True
                SetControlEnableEvent()
            End If
        End If
    End Sub
#End Region

#Region "打印预览事件"

#End Region

#Region "读入excel"

    Private Sub BtnImpXls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImpXls.Click, MnuiImpXls.Click
        '调用表单
        Dim rcFrm As New FrmOeDdImpXls
        With rcFrm
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
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

    Private Sub FrmOeDdSrz_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If IsEditing Then
            MsgBox("已经编辑过数据，请保存数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            e.Cancel = True
        End If
    End Sub

#End Region

#Region "参照录入"

    Private Sub BtnReference_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReference.Click
        If Not String.IsNullOrEmpty(Me.TxtKhdm.Text) Then
            '调用表单
            Dim rcFrm As New FrmOeDdReference
            With rcFrm
                .ParaStrKhdm = Me.TxtKhdm.Text
                .ParaDataSet = rcDataset
                .MdiParent = Me.MdiParent
                .Show()
            End With
            Me.rcDataGridView.Focus()
        End If
    End Sub

#End Region
End Class