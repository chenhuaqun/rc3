Imports System.Math
Imports System.Data.OleDb
Public Class FrmOeYpddSrz

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
    ReadOnly dtYpdd As New DataTable("rc_ddnr")
    '新增单据的变量
    Dim IsAdding As Boolean = False
    '修改单据的变量
    Dim IsEditing As Boolean = False
    '当前位置
    ReadOnly CurrentPos As Integer = 0
    '会计期间
    Dim strKjqj As String = g_Kjqj
    '年
    Dim strYear As String = ""
    '月
    Dim strMonth As String = ""
    '
    Dim EditingControl As DataGridViewTextBoxEditingControl

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

    Private Sub FrmOeYpddSrz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '设置DataGridView
        Me.rcDataGridView.AutoGenerateColumns = False
        Me.rcDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Format = g_FormatSl
        '取单据类型数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc From rc_lx WHERE lxgs = '样品订单' and kjnd = '" & strYear & "' ORDER BY pzlxdm"
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

        dtYpdd.Columns.Add("jhsbm", Type.GetType("System.String"))
        dtYpdd.Columns.Add("cpdm", Type.GetType("System.String"))
        dtYpdd.Columns.Add("cpmc", Type.GetType("System.String"))
        dtYpdd.Columns.Add("cpgg", Type.GetType("System.String"))
        dtYpdd.Columns.Add("cpmemo", Type.GetType("System.String"))
        dtYpdd.Columns.Add("dw", Type.GetType("System.String"))
        dtYpdd.Columns.Add("muju", Type.GetType("System.String"))
        dtYpdd.Columns.Add("khlh", Type.GetType("System.String"))
        dtYpdd.Columns.Add("khcz", Type.GetType("System.String"))
        dtYpdd.Columns.Add("sl", Type.GetType("System.Double"))
        dtYpdd.Columns.Add("khjhrq", Type.GetType("System.DateTime"))
        dtYpdd.Columns.Add("scjhrq", Type.GetType("System.DateTime"))
        dtYpdd.Columns.Add("fhrq", Type.GetType("System.DateTime"))
        dtYpdd.Columns.Add("bmdm", Type.GetType("System.String"))
        dtYpdd.Columns.Add("ddmemo", Type.GetType("System.String"))
        dtYpdd.Columns.Add("zt", Type.GetType("System.Int32"))
        dtYpdd.Columns.Add("sdjh", Type.GetType("System.String"))
        dtYpdd.Columns.Add("sxh", Type.GetType("System.Int32"))
        rcDataset.Tables.Add(dtYpdd)
        With rcDataset.Tables("rc_ddnr")
            .Columns("jhsbm").DefaultValue = ""
            .Columns("cpdm").DefaultValue = ""
            .Columns("cpmc").DefaultValue = ""
            .Columns("cpgg").DefaultValue = ""
            .Columns("cpmemo").DefaultValue = ""
            .Columns("dw").DefaultValue = ""
            .Columns("muju").DefaultValue = ""
            .Columns("khlh").DefaultValue = ""
            .Columns("khcz").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("bmdm").DefaultValue = ""
            .Columns("ddmemo").DefaultValue = ""
            .Columns("zt").DefaultValue = 0
            .Columns("sdjh").DefaultValue = ""
            .Columns("sxh").DefaultValue = 0
        End With
        '绑定数据the DataGridview to the DataTable.
        rcBindingSource.DataSource = dtYpdd
        Me.rcDataGridView.DataSource = rcBindingSource
        strKjqj = strYear & strMonth.PadLeft(2, "0")
        If getInvKjqj(g_Kjrq) = strKjqj Then
            DtpQdrq.Value = g_Kjrq
        Else
            DtpQdrq.Value = getInvEnd(strYear, strMonth)
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
            If dtYpdd.Rows.Count > 0 Then
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

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbPzlxjc.KeyPress, TxtDjh.KeyPress, DtpQdrq.KeyPress, TxtHth.KeyPress, TxtKhdm.KeyPress, TxtZydm.KeyPress, TxtLxr.KeyPress, TxtDdtk.KeyPress
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
                        rcOleDbCommand.CommandText = "USP_DELETE_OE_YPDD"
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
            '取单据号
            If rcDataset.Tables("rc_pzno").Rows.Count > 0 Then
                If rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") >= Mid(Trim(Me.TxtDjh.Text), 11, 5) Then
                    '修改单据
                    rcOleDbCommand.CommandText = "SELECT oe_ypdd.djh,oe_ypdd.qdrq,oe_ypdd.hth,oe_ypdd.khdm,oe_ypdd.khmc,oe_ypdd.zydm,oe_ypdd.zymc,oe_ypdd.lxr,oe_ypdd.ddtk,oe_ypdd.srr,oe_ypdd.shr FROM oe_ypdd WHERE djh = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Trim(Me.TxtDjh.Text)
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("rc_ddml") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_ddml").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "rc_ddml")
                    If rcDataset.Tables("rc_ddml").Rows.Count > 0 Then
                        If rcDataset.Tables("rc_ddml").Rows(0).Item("shr").GetType.ToString <> "System.DBNull" Then
                            MsgBox("该单据已经审核，不能修改。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                            TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                        Else
                            Me.DtpQdrq.Value = rcDataset.Tables("rc_ddml").Rows(0).Item("qdrq")
                            If rcDataset.Tables("rc_ddml").Rows(0).Item("hth").GetType.ToString <> "System.DBNull" Then
                                Me.TxtHth.Text = rcDataset.Tables("rc_ddml").Rows(0).Item("hth")
                            Else
                                Me.TxtHth.Text = ""
                            End If
                            If rcDataset.Tables("rc_ddml").Rows(0).Item("khdm").GetType.ToString <> "System.DBNull" Then
                                Me.TxtKhdm.Text = rcDataset.Tables("rc_ddml").Rows(0).Item("khdm")
                            Else
                                Me.TxtKhdm.Text = ""
                            End If
                            If rcDataset.Tables("rc_ddml").Rows(0).Item("khmc").GetType.ToString <> "System.DBNull" Then
                                Me.LblKhmc.Text = rcDataset.Tables("rc_ddml").Rows(0).Item("khmc")
                            Else
                                Me.LblKhmc.Text = ""
                            End If
                            If rcDataset.Tables("rc_ddml").Rows(0).Item("zydm").GetType.ToString <> "System.DBNull" Then
                                Me.TxtZydm.Text = Trim(rcDataset.Tables("rc_ddml").Rows(0).Item("zydm"))
                            Else
                                Me.TxtZydm.Text = ""
                            End If
                            If rcDataset.Tables("rc_ddml").Rows(0).Item("zymc").GetType.ToString <> "System.DBNull" Then
                                Me.LblZymc.Text = Trim(rcDataset.Tables("rc_ddml").Rows(0).Item("zymc"))
                            Else
                                Me.LblZymc.Text = ""
                            End If
                            If rcDataset.Tables("rc_ddml").Rows(0).Item("lxr").GetType.ToString <> "System.DBNull" Then
                                Me.TxtLxr.Text = rcDataset.Tables("rc_ddml").Rows(0).Item("lxr")
                            Else
                                Me.TxtLxr.Text = ""
                            End If
                            If rcDataset.Tables("rc_ddml").Rows(0).Item("ddtk").GetType.ToString <> "System.DBNull" Then
                                Me.TxtDdtk.Text = rcDataset.Tables("rc_ddml").Rows(0).Item("ddtk")
                            Else
                                Me.TxtDdtk.Text = ""
                            End If
                            '修改单据
                            rcOleDbCommand.CommandText = "SELECT oe_ypdd.jhsbm,oe_ypdd.cpdm,oe_ypdd.cpmc,oe_ypdd.cpgg,oe_ypdd.cpmemo,oe_ypdd.dw,oe_ypdd.muju,oe_ypdd.khlh,oe_ypdd.khcz,oe_ypdd.sl,oe_ypdd.khjhrq,oe_ypdd.scjhrq,oe_ypdd.fhrq,oe_ypdd.bmdm,oe_ypdd.ddmemo,oe_ypdd.zt,oe_ypdd.sdjh,oe_ypdd.sxh FROM oe_ypdd where (oe_ypdd.djh = ?) ORDER BY xh"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Trim(Me.TxtDjh.Text)
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("rc_ddnr") IsNot Nothing Then
                                Me.rcDataset.Tables("rc_ddnr").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "rc_ddnr")
                            Me.rcDataGridView.ClearSelection()
                            If dtYpdd.Rows.Count > 0 Then
                                Me.LblTotSl.Text = "数量合计：" & Format(dtYpdd.Compute("Sum(sl)", ""), g_FormatSl)
                            End If
                        End If
                    End If
                    IsAdding = False
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

#Region "签单日期的事件"

    Private Sub DtpQdrq_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DtpQdrq.Validating
        '检查会计期间
        Dim dateBegin As DateTime
        Dim dateEnd As DateTime
        dateBegin = getInvBegin(strYear, strMonth)
        dateEnd = getInvEnd(strYear, strMonth)
        If DtpQdrq.Value.Date > dateEnd Or DtpQdrq.Value.Date < dateBegin Then
            MsgBox("您输入的日期不在当前会计期间中，请重输入。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Me.DtpQdrq.Focus()
        End If
    End Sub

#End Region

#Region "合同编码的事件"

    Private Sub TxtHth_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtHth.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtHth_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtHth.Validating
        If Not String.IsNullOrEmpty(Me.TxtHth.Text) And IsAdding Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                '找最近一次的订单
                rcOleDbCommand.CommandText = "SELECT oe_ypdd.djh,oe_ypdd.qdrq,oe_ypdd.hth,oe_ypdd.khdm,rc_khxx.khmc,rc_khxx.zydm,rc_zyxx.zymc,oe_ypdd.ddtk,oe_ypdd.srr,oe_ypdd.shr FROM oe_ypdd,rc_zyxx,rc_khxx WHERE (rc_khxx.zydm = rc_zyxx.zydm and oe_ypdd.khdm = rc_khxx.khdm and oe_ypdd.hth = ? ) ORDER BY oe_ypdd.djh DESC"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@hth", OleDbType.VarChar, 11).Value = Trim(Me.TxtHth.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_ddml") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_ddml").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_ddml")
                If rcDataset.Tables("rc_ddml").Rows.Count > 0 Then
                    'blnNewHth = False
                    Me.TxtHth.Text = Trim(rcDataset.Tables("rc_ddml").Rows(0).Item("hth"))
                    TxtKhdm.Text = Trim(rcDataset.Tables("rc_ddml").Rows(0).Item("khdm"))
                    LblKhmc.Text = Trim(rcDataset.Tables("rc_ddml").Rows(0).Item("khmc"))
                    If rcDataset.Tables("rc_ddml").Rows(0).Item("zydm").GetType.ToString <> "System.DBNull" Then
                        Me.TxtZydm.Text = Trim(rcDataset.Tables("rc_ddml").Rows(0).Item("zydm"))
                    Else
                        Me.TxtZydm.Text = ""
                    End If
                    If rcDataset.Tables("rc_ddml").Rows(0).Item("zymc").GetType.ToString <> "System.DBNull" Then
                        Me.LblZymc.Text = rcDataset.Tables("rc_ddml").Rows(0).Item("zymc")
                    Else
                        Me.LblZymc.Text = ""
                    End If
                    If rcDataset.Tables("rc_ddml").Rows(0).Item("ddtk").GetType.ToString <> "System.DBNull" Then
                        TxtDdtk.Text = rcDataset.Tables("rc_ddml").Rows(0).Item("ddtk")
                    Else
                        Me.TxtDdtk.Text = ""
                    End If
                    '修改单据
                    rcOleDbCommand.CommandText = "SELECT oe_ypdd.jhsbm,oe_ypdd.cpdm,oe_ypdd.cpmc,oe_ypdd.cpgg,oe_ypdd.cpmemo,oe_ypdd.dw,oe_ypdd.muju,oe_ypdd.khlh,oe_ypdd.khcz,oe_ypdd.hxsl -oe_ypdd.sl AS sl,oe_ypdd.scjhrq as khjhrq,oe_ypdd.bmdm,'('||oe_ypdd.bmdm||')'|| oe_ypdd.ddmemo || TO_CHAR(oe_ypdd.qdrq,'dd') AS ddmemo,oe_ypdd.zt,oe_ypdd.djh AS sdjh,oe_ypdd.xh AS sxh FROM oe_ypdd WHERE (oe_ypdd.sl - oe_ypdd.hxsl <> 0 AND NOT oe_ypdd.bmdm IS NULL AND oe_ypdd.zt <= 4 and oe_ypdd.hth = ?)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@hth", OleDbType.VarChar, 11).Value = Trim(Me.TxtHth.Text)
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("rc_ddnr") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_ddnr").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "rc_ddnr")
                    Me.rcDataGridView.ClearSelection()
                    If dtYpdd.Rows.Count > 0 Then
                        Me.LblTotSl.Text = "数量合计：" & Format(dtYpdd.Compute("Sum(sl)", ""), g_FormatSl)
                    End If
                    '控制同一个合同编码只能有一个客户编码
                    Me.TxtKhdm.Enabled = False
                Else
                    Me.TxtKhdm.Enabled = True
                End If
                IsAdding = True
            Catch ex As Exception
                Try
                    MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End Try
            Finally
                rcOleDbConn.Close()
            End Try
        End If
        If Not String.IsNullOrEmpty(Me.TxtHth.Text) Then
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
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT rc_khxx.khdm,rc_khxx.khmc,rc_khxx.zydm,rc_zyxx.zymc FROM rc_khxx LEFT JOIN rc_zyxx ON rc_khxx.zydm = rc_zyxx.zydm WHERE (khdm = ?)"
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
                TxtKhdm.Text = Trim(rcDataset.Tables("rc_khxx").Rows(0).Item("khdm"))
                LblKhmc.Text = Trim(rcDataset.Tables("rc_khxx").Rows(0).Item("khmc"))
                If rcDataset.Tables("rc_khxx").Rows(0).Item("zydm").GetType.ToString <> "System.DBNull" Then
                    Me.TxtZydm.Text = Trim(rcDataset.Tables("rc_khxx").Rows(0).Item("zydm"))
                Else
                    Me.TxtZydm.Text = ""
                End If
                If rcDataset.Tables("rc_khxx").Rows(0).Item("zymc").GetType.ToString <> "System.DBNull" Then
                    Me.LblZymc.Text = Trim(rcDataset.Tables("rc_khxx").Rows(0).Item("zymc"))
                Else
                    Me.LblZymc.Text = ""
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
                    .paraTitle = "职员"
                    .paraOldValue = ""
                    .paraAddName = ""
                    .paraOrderField = "zymc"
                    If .ShowDialog = DialogResult.OK Then
                        TxtZydm.Text = Trim(.paraField1)
                        LblZymc.Text = Trim(.paraField2)
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
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(Me.TxtZydm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_zyxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_zyxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_zyxx")
            Catch ex As Exception
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_zyxx").Rows.Count > 0 Then
                Me.TxtZydm.Text = Trim(rcDataset.Tables("rc_zyxx").Rows(0).Item("zydm"))
                Me.LblZymc.Text = rcDataset.Tables("rc_zyxx").Rows(0).Item("zymc")
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

#Region "收件人的事件"

    Private Sub TxtLxr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLxr.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtLxr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtLxr.Validating
        If Not String.IsNullOrEmpty(Me.TxtLxr.Text) Then
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

    Private Sub RcDataGridView_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles rcDataGridView.CellValidating
        If Me.rcDataGridView.CurrentRow.IsNewRow = False Then
            If rcDataGridView.IsCurrentCellDirty Then
                rcDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColCpdm" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    '取产品信息
                    Try
                        rcOleDbConn.Open()
                        rcOleDbCommand.Connection = rcOleDbConn
                        rcOleDbCommand.CommandTimeout = 300
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT * FROM rc_cpxx WHERE cpdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.AddWithValue("@cpdm", rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue)
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
                        Me.rcDataGridView.CurrentRow.Cells("ColCpgg").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("cpgg")
                        Me.rcDataGridView.CurrentRow.Cells("ColCpmemo").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("cpmemo")
                        Me.rcDataGridView.CurrentRow.Cells("ColDw").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("dw")
                        'If Me.rcDataGridView.CurrentRow.Cells("ColDw").Value = "只" Then
                        '    Me.rcDataGridView.CurrentRow.Cells("ColXs").ReadOnly = True
                        'Else
                        '    Me.rcDataGridView.CurrentRow.Cells("ColXs").ReadOnly = False
                        'End If
                    Else
                        Me.LblMsg.Text = "产品编码不存在。"
                        'e.Cancel = True
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColCpmc" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    Try
                        rcOleDbConn.Open()
                        rcOleDbCommand.Connection = rcOleDbConn
                        rcOleDbCommand.CommandTimeout = 300
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "Select muju From oe_ypdd Where cpmc = ? AND NOT muju IS NULL"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.AddWithValue("@cpmc", rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpmc").EditedFormattedValue)
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("muju") IsNot Nothing Then
                            rcDataset.Tables("muju").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "muju")
                    Catch ex As Exception
                        MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                    If rcDataset.Tables("muju").Rows.Count > 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColMuju").Value = rcDataset.Tables("muju").Rows(0).Item("muju")
                    End If
                End If
            End If
            'If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColKhsl" Then
            '    If  e.FormattedValue.GetType.ToString <> "System.DBNull" Then
            '        If Me.rcDataGridView.CurrentRow.Cells("ColXs").Value <> 0 Then
            '            Me.rcDataGridView.CurrentRow.Cells("ColSl").Value = Round(e.FormattedValue / Me.rcDataGridView.CurrentRow.Cells("ColXs").Value, 6, MidpointRounding.AwayFromZero)
            '        End If
            '    End If
            'End If
            'If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColXs" Then
            '    If  e.FormattedValue.GetType.ToString <> "System.DBNull" Then
            '        If e.FormattedValue <> 0 Then
            '            Me.rcDataGridView.CurrentRow.Cells("ColSl").Value = Round(Me.rcDataGridView.CurrentRow.Cells("ColKhsl").Value / e.FormattedValue, 6, MidpointRounding.AwayFromZero)
            '        End If
            '    End If
            'End If
            'If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColSl" Then
            '    If  e.FormattedValue.GetType.ToString <> "System.DBNull" Then
            '        If Me.rcDataGridView.CurrentRow.Cells("ColXs").Value <> 0 Then
            '            Me.rcDataGridView.CurrentRow.Cells("ColKhsl").Value = Round(e.FormattedValue * Me.rcDataGridView.CurrentRow.Cells("ColXs").Value, 6, MidpointRounding.AwayFromZero)
            '        End If
            '    End If
            'End If
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
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColCpdm" Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF36
                    With rcFrm
                        .paraOleDbConn = rcOleDbConn
                        .paraTableName = "rc_cpxx"
                        .paraField1 = "cpdm"
                        .paraField2 = "cpmc"
                        .paraField3 = "cpgg"
                        .paraField4 = "cpmemo"
                        .paraField5 = "cpsm"
                        .paraField6 = "dw"
                        .paraOrderField = "cpmc"
                        .paraTitle = "产品"
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
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColCpdm" Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF36
                    With rcFrm
                        .paraOleDbConn = rcOleDbConn
                        .paraTableName = "rc_cpxx"
                        .paraField1 = "cpdm"
                        .paraField2 = "cpmc"
                        .paraField3 = "cpgg"
                        .paraField4 = "cpmemo"
                        .paraField5 = "cpsm"
                        .paraField6 = "dw"
                        .paraOrderField = "cpmc"
                        .paraTitle = "产品"
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
        If dtYpdd.Rows.Count > 0 Then
            IsEditing = True
            SetControlEnableEvent()
            If dtYpdd.Rows.Count > 0 Then
                Me.LblTotSl.Text = "数量合计：" & Format(dtYpdd.Compute("Sum(sl)", ""), g_FormatSl)
            End If
        End If
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
        Me.TxtLxr.Text = ""
        Me.TxtDdtk.Text = ""
        '显示新单据号
        ShowNewDjh()
        IsAdding = True
        'blnNewHth = True '新合同编码为真
        IsEditing = False
        Me.TxtHth.Text = Mid(Me.TxtDjh.Text, 5, 11)
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
                rcOleDbCommand.CommandText = "SELECT pzno" & strMonth & " as pzno From rc_lx Where pzlxdm = ? and lxgs = '样品订单' and kjnd = '" & strYear & "'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.AddWithValue("@pzlxdm", Trim(Me.CmbPzlxjc.SelectedValue))
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_pzno") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_pzno").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_pzno")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
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
        '(1)是否有需要存储的数据
        rcDataset.Tables("rc_ddnr").AcceptChanges()
        If rcDataset.Tables("rc_ddnr").Rows.Count = 0 Then
            MsgBox("没有相应的业务，请输入。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            '(2)客户检查
            If Trim(Me.TxtKhdm.Text).Length = 0 Then
                MsgBox("请输入客户编码。", MsgBoxStyle.OkOnly, "提示信息")
                Return
            End If
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@pStrCode", OleDbType.VarChar, 15).Value = Trim(Me.TxtKhdm.Text)
            rcOleDbCommand.Parameters.Add("@pStrTable", OleDbType.VarChar, 30).Value = "rc_khxx"
            rcOleDbCommand.Parameters.Add("@pStrField", OleDbType.VarChar, 30).Value = "khdm"
            rcOleDbCommand.Parameters.Add("@pStrCondition", OleDbType.VarChar, 100).Value = ""
            rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
            rcOleDbCommand.ExecuteNonQuery()
            If rcOleDbCommand.Parameters.Item("@paraIntRecordCount").Value <> 1 Then
                MsgBox(Trim(Me.TxtKhdm.Text) & "客户编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                Me.TxtKhdm.Text = ""
                Me.LblKhmc.Text = ""
                Me.TxtKhdm.Focus()
                Return
            End If
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
        For i = 0 To rcDataset.Tables("rc_ddnr").Rows.Count - 1
            If rcDataset.Tables("rc_ddnr").Rows(i).Item("jhsbm").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_ddnr").Rows(i).Item("jhsbm") = ""
            End If
            If rcDataset.Tables("rc_ddnr").Rows(i).Item("cpdm").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_ddnr").Rows(i).Item("cpdm") = ""
            End If
            If rcDataset.Tables("rc_ddnr").Rows(i).Item("cpmc").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_ddnr").Rows(i).Item("cpmc") = ""
            End If
            If rcDataset.Tables("rc_ddnr").Rows(i).Item("cpgg").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_ddnr").Rows(i).Item("cpgg") = ""
            End If
            If rcDataset.Tables("rc_ddnr").Rows(i).Item("cpmemo").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_ddnr").Rows(i).Item("cpmemo") = ""
            End If
            If rcDataset.Tables("rc_ddnr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_ddnr").Rows(i).Item("dw") = ""
            End If
            If rcDataset.Tables("rc_ddnr").Rows(i).Item("muju").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_ddnr").Rows(i).Item("muju") = ""
            End If
            If rcDataset.Tables("rc_ddnr").Rows(i).Item("khlh").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_ddnr").Rows(i).Item("khlh") = ""
            End If
            If rcDataset.Tables("rc_ddnr").Rows(i).Item("khcz").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_ddnr").Rows(i).Item("khcz") = ""
            End If
            If rcDataset.Tables("rc_ddnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_ddnr").Rows(i).Item("sl") = 0.0
            End If
            If rcDataset.Tables("rc_ddnr").Rows(i).Item("khjhrq").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_ddnr").Rows(i).Item("khjhrq") = Now().Date()
            End If
            If rcDataset.Tables("rc_ddnr").Rows(i).Item("bmdm").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_ddnr").Rows(i).Item("bmdm") = ""
            End If
            If rcDataset.Tables("rc_ddnr").Rows(i).Item("ddmemo").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_ddnr").Rows(i).Item("ddmemo") = ""
            End If

        Next

        '(二)存储ml
        'djh,qdrq,hth,khdm,ddmemo,srr
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP3_SAVE_OE_YPDD"
            For i = 0 To rcDataset.Tables("rc_ddnr").Rows.Count - 1
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = IIf(IsAdding, 1, 0)
                rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = Trim(Me.TxtDjh.Text)
                rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = i + 1
                rcOleDbCommand.Parameters.Add("@paraDateQdrq", OleDbType.Date, 8).Value = DtpQdrq.Value.Date
                rcOleDbCommand.Parameters.Add("@paraStrHth", OleDbType.VarChar, 30).Value = Trim(Me.TxtHth.Text)
                rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtKhdm.Text)
                rcOleDbCommand.Parameters.Add("@paraStrKhmc", OleDbType.VarChar, 100).Value = Me.LblKhmc.Text
                rcOleDbCommand.Parameters.Add("@paraStrZydm", OleDbType.VarChar, 12).Value = Trim(Me.TxtZydm.Text)
                rcOleDbCommand.Parameters.Add("@paraStrZymc", OleDbType.VarChar, 30).Value = Me.LblZymc.Text
                rcOleDbCommand.Parameters.Add("@paraStrLxr", OleDbType.VarChar, 30).Value = Trim(Me.TxtLxr.Text)
                rcOleDbCommand.Parameters.Add("@paraStrDdtk", OleDbType.VarChar, 50).Value = Trim(Me.TxtDdtk.Text) '合同其他条款
                rcOleDbCommand.Parameters.Add("@paraStrJhsbm", OleDbType.VarChar, 20).Value = rcDataset.Tables("rc_ddnr").Rows(i).Item("jhsbm")
                rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("rc_ddnr").Rows(i).Item("cpdm")).ToUpper
                rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 40).Value = Trim(rcDataset.Tables("rc_ddnr").Rows(i).Item("cpmc"))
                rcOleDbCommand.Parameters.Add("@paraStrCpgg", OleDbType.VarChar, 40).Value = Trim(rcDataset.Tables("rc_ddnr").Rows(i).Item("cpgg"))
                rcOleDbCommand.Parameters.Add("@paraStrCpmemo", OleDbType.VarChar, 50).Value = Trim(rcDataset.Tables("rc_ddnr").Rows(i).Item("cpmemo"))
                rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = Trim(rcDataset.Tables("rc_ddnr").Rows(i).Item("dw"))
                rcOleDbCommand.Parameters.Add("@paraStrMuju", OleDbType.VarChar, 50).Value = rcDataset.Tables("rc_ddnr").Rows(i).Item("muju")
                rcOleDbCommand.Parameters.Add("@paraStrKhlh", OleDbType.VarChar, 50).Value = Trim(rcDataset.Tables("rc_ddnr").Rows(i).Item("khlh")).ToUpper
                rcOleDbCommand.Parameters.Add("@paraStrKhcz", OleDbType.VarChar, 30).Value = Trim(rcDataset.Tables("rc_ddnr").Rows(i).Item("khcz")).ToUpper
                rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_ddnr").Rows(i).Item("sl")
                rcOleDbCommand.Parameters.Add("@paraDateKhjhrq", OleDbType.Date).Value = rcDataset.Tables("rc_ddnr").Rows(i).Item("khjhrq")
                rcOleDbCommand.Parameters.Add("@paraDateScjhrq", OleDbType.Date).Value = rcDataset.Tables("rc_ddnr").Rows(i).Item("scjhrq")
                rcOleDbCommand.Parameters.Add("@paraDateFhrq", OleDbType.Date).Value = rcDataset.Tables("rc_ddnr").Rows(i).Item("fhrq")
                rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rc_ddnr").Rows(i).Item("bmdm")
                rcOleDbCommand.Parameters.Add("@paraStrDdmemo", OleDbType.VarChar, 50).Value = Trim(rcDataset.Tables("rc_ddnr").Rows(i).Item("ddmemo"))
                rcOleDbCommand.Parameters.Add("@paraIntZt", OleDbType.Integer, 1).Value = 0
                rcOleDbCommand.Parameters.Add("@paraStrSDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_ddnr").Rows(i).Item("sdjh")
                rcOleDbCommand.Parameters.Add("@paraIntSXh", OleDbType.Integer, 4).Value = rcDataset.Tables("rc_ddnr").Rows(i).Item("sxh")
                rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 10).Value = g_User_DspName
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
                '(三)存储nr
                'rcOleDbCommand.Parameters.Add("@paraStrKhmc", OleDbType.VarChar, 50).Value = Trim(rcDataset.Tables("rc_ddnr").Rows(i).Item("khmc"))
                'rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                'rcOleDbCommand.Parameters.Add("@paraIntError", OleDbType.Integer, 4).Direction = ParameterDirection.Output
                'rcOleDbCommand.ExecuteNonQuery()
            Next
            rcOleDbTrans.Commit()
        Catch ex As Exception
            MsgBox("执行程序时发生了错误。" & Chr(13) & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
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
            If dtYpdd.Rows.Count > 0 Then
                Dim row As DataRow = dtYpdd.NewRow
                dtYpdd.Rows.InsertAt(row, rcDataGridView.CurrentCell.RowIndex)
                dtYpdd.AcceptChanges()
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
        Dim rcFrm As New FrmOeYpddImpXls
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

    Private Sub FrmOeYpddSrz_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If IsEditing Then
            MsgBox("已经编辑过数据，请保存数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            e.Cancel = True
        End If
    End Sub

#End Region
End Class