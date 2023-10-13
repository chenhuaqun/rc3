Imports System.IO
Imports System.Data.OleDb
Imports System.Net.Mail

Public Class FrmOeBjdSrz

#Region "定义变量"

    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立DatbTable '我们要利用该datbTable进行金额计算
    ReadOnly dtBjd As New DataTable("rc_bjdnr")
    '增加单据的变量
    Dim IsAdding As Boolean = False
    '修改单据的变量
    Dim IsEditing As Boolean = False
    '数据绑定
    ReadOnly bmbDataGrid As BindingManagerBase
    '会计期间
    Dim strKjqj As String = g_Kjqj
    '年
    Dim strYear As String = ""
    '月
    Dim strMonth As String = ""
    '打印文档
    Dim rcRps As RPS.Document = Nothing
    '修改变量
    ReadOnly blnChangedEvent As Boolean = False
    Dim EditingControl As DataGridViewTextBoxEditingControl
    '打印格式变量
    ReadOnly blnChEn As Boolean = True
    '含税标志
    ReadOnly blnHs As Boolean = True
    '客户联系人
    Dim strLxr As String = ""
    '客户地址
    Dim strAddress As String = ""

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

    Private Sub FrmOeBjdSrz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '设置DataGridView
        Me.rcDataGridView.AutoGenerateColumns = False
        Me.rcDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.rcDataGridView.Columns("ColZl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColZl").DefaultCellStyle.Format = g_FormatDj
        Me.rcDataGridView.Columns("ColDj").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'Me.rcDataGridView.Columns("ColDj").DefaultCellStyle.Format = g_FormatDj
        Me.rcDataGridView.Columns("ColSpq").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColSpq").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColMoq").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColMoq").DefaultCellStyle.Format = g_FormatSl
        '取单据类型数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc From rc_lx WHERE rc_lx.lxgs = '产品报价单' and kjnd = '" & strYear & "' ORDER BY pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_lx") IsNot Nothing Then
                Me.rcDataset.Tables("rc_lx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_lx")
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            End Try
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

        '数据绑定
        dtBjd.Columns.Add("khlh", Type.GetType("System.String"))
        dtBjd.Columns.Add("khcz", Type.GetType("System.String"))
        dtBjd.Columns.Add("cpdm", Type.GetType("System.String"))
        dtBjd.Columns.Add("cpmc", Type.GetType("System.String"))
        dtBjd.Columns.Add("cpgg", Type.GetType("System.String"))
        dtBjd.Columns.Add("dw", Type.GetType("System.String"))
        dtBjd.Columns.Add("zl", Type.GetType("System.Double"))
        dtBjd.Columns.Add("dj", Type.GetType("System.Double"))
        dtBjd.Columns.Add("wbdm", Type.GetType("System.String"))
        dtBjd.Columns.Add("wbhl", Type.GetType("System.Double"))
        dtBjd.Columns.Add("spq", Type.GetType("System.Double"))
        dtBjd.Columns.Add("moq", Type.GetType("System.Double"))
        dtBjd.Columns.Add("bjmemo", Type.GetType("System.String"))
        rcDataset.Tables.Add(dtBjd)
        With dtBjd
            .Columns("khlh").DefaultValue = ""
            .Columns("khcz").DefaultValue = ""
            .Columns("cpdm").DefaultValue = ""
            .Columns("cpmc").DefaultValue = ""
            .Columns("cpgg").DefaultValue = ""
            .Columns("dw").DefaultValue = ""
            .Columns("zl").DefaultValue = 0.0
            .Columns("dj").DefaultValue = 0.0
            .Columns("wbdm").DefaultValue = ""
            .Columns("wbhl").DefaultValue = 0.0
            .Columns("spq").DefaultValue = 0.0
            .Columns("moq").DefaultValue = 0.0
            .Columns("bjmemo").DefaultValue = ""
        End With
        '绑定数据the DataGridview to the DatbTable.
        rcBindingSource.DataSource = dtBjd
        Me.rcDataGridView.DataSource = rcBindingSource
        strKjqj = strYear & strMonth
        If getInvKjqj(g_Kjrq) = strKjqj Then
            DtpBjrq.Value = g_Kjrq
        Else
            DtpBjrq.Value = getInvEnd(strYear, strMonth)
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
            Me.BtnImpXls.Enabled = False
            Me.BtnExit.Enabled = False
            Me.MnuiNew.Enabled = False
            Me.MnuiSave.Enabled = True
            Me.MnuiCancel.Enabled = True
            Me.MnuiImpXls.Enabled = False
            Me.MnuiExit.Enabled = False
        Else
            If dtBjd.Rows.Count > 0 Then
                Me.CmbPzlxjc.Enabled = False
            Else
                Me.CmbPzlxjc.Enabled = True
            End If
            Me.TxtDjh.Enabled = True
            Me.BtnNew.Enabled = True
            Me.BtnSave.Enabled = False
            Me.BtnCancel.Enabled = False
            Me.BtnImpXls.Enabled = True
            Me.BtnExit.Enabled = True
            Me.MnuiNew.Enabled = True
            Me.MnuiSave.Enabled = False
            Me.MnuiCancel.Enabled = False
            Me.MnuiImpXls.Enabled = True
            Me.MnuiExit.Enabled = True
        End If
    End Sub

#End Region

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbPzlxjc.KeyPress, TxtDjh.KeyPress, DtpBjrq.KeyPress, TxtKhdm.KeyPress, TxtZydm.KeyPress, TxtEmail.KeyPress, TxtBjtk.KeyPress
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
                        rcOleDbCommand.CommandText = "USP_DELETE_OE_BJD"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@pStrDjh", OleDbType.VarChar, 15).Value = Trim(Me.TxtDjh.Text)
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
            If rcDataset.Tables("rc_pzno").Rows.Count > 0 Then
                If rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") >= Mid(Trim(Me.TxtDjh.Text), 11, 5) Then
                    '修改单据
                    rcOleDbCommand.CommandText = "SELECT oe_bjd.djh,oe_bjd.bjrq,oe_bjd.wbdm,oe_bjd.wbhl,oe_bjd.khdm,rc_khxx.khmc,rc_khxx.lxr,rc_khxx.address,oe_bjd.zydm,oe_bjd.zymc,oe_bjd.email,oe_bjd.bjtk,oe_bjd.memo1,oe_bjd.memo2,oe_bjd.memo3,oe_bjd.memo4,oe_bjd.memo5,oe_bjd.srr,oe_bjd.shr,oe_bjd.jzr FROM oe_bjd,rc_khxx WHERE oe_bjd.khdm = rc_khxx.khdm AND djh = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Trim(Me.TxtDjh.Text)
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("rc_bjdml") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_bjdml").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "rc_bjdml")
                    If rcDataset.Tables("rc_bjdml").Rows.Count > 0 Then
                        If rcDataset.Tables("rc_bjdml").Rows(0).Item("jzr").GetType.ToString <> "System.DBNull" Then
                            MsgBox("该单据已经记账，不能修改。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                            TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                        Else
                            If rcDataset.Tables("rc_bjdml").Rows(0).Item("shr").GetType.ToString <> "System.DBNull" Then
                                MsgBox("该单据已经审核，不能修改。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                                TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                            Else
                                Me.DtpBjrq.Value = rcDataset.Tables("rc_bjdml").Rows(0).Item("bjrq")
                                'Me.TxtWbdm.Text = rcDataset.Tables("rc_bjdml").Rows(0).Item("wbdm")
                                'Me.TxtWbhl.Text = rcDataset.Tables("rc_bjdml").Rows(0).Item("wbhl")
                                If rcDataset.Tables("rc_bjdml").Rows(0).Item("khdm").GetType.ToString <> "System.DBNull" Then
                                    Me.TxtKhdm.Text = rcDataset.Tables("rc_bjdml").Rows(0).Item("khdm")
                                Else
                                    Me.TxtKhdm.Text = ""
                                End If
                                If rcDataset.Tables("rc_bjdml").Rows(0).Item("khmc").GetType.ToString <> "System.DBNull" Then
                                    Me.LblKhmc.Text = rcDataset.Tables("rc_bjdml").Rows(0).Item("khmc")
                                Else
                                    Me.LblKhmc.Text = ""
                                End If
                                If rcDataset.Tables("rc_bjdml").Rows(0).Item("lxr").GetType.ToString <> "System.DBNull" Then
                                    strLxr = rcDataset.Tables("rc_bjdml").Rows(0).Item("lxr")
                                Else
                                    strLxr = ""
                                End If
                                If rcDataset.Tables("rc_bjdml").Rows(0).Item("address").GetType.ToString <> "System.DBNull" Then
                                    strAddress = rcDataset.Tables("rc_bjdml").Rows(0).Item("address")
                                Else
                                    strAddress = ""
                                End If

                                If rcDataset.Tables("rc_bjdml").Rows(0).Item("zydm").GetType.ToString <> "System.DBNull" Then
                                    Me.TxtZydm.Text = rcDataset.Tables("rc_bjdml").Rows(0).Item("zydm")
                                Else
                                    Me.TxtZydm.Text = ""
                                End If
                                If rcDataset.Tables("rc_bjdml").Rows(0).Item("zymc").GetType.ToString <> "System.DBNull" Then
                                    Me.LblZymc.Text = rcDataset.Tables("rc_bjdml").Rows(0).Item("zymc")
                                Else
                                    Me.LblZymc.Text = ""
                                End If
                                If rcDataset.Tables("rc_bjdml").Rows(0).Item("email").GetType.ToString <> "System.DBNull" Then
                                    Me.TxtEmail.Text = rcDataset.Tables("rc_bjdml").Rows(0).Item("email")
                                Else
                                    Me.TxtEmail.Text = ""
                                End If
                                If rcDataset.Tables("rc_bjdml").Rows(0).Item("bjtk").GetType.ToString <> "System.DBNull" Then
                                    TxtBjtk.Text = Trim(rcDataset.Tables("rc_bjdml").Rows(0).Item("bjtk"))
                                Else
                                    TxtBjtk.Text = ""
                                End If
                                If rcDataset.Tables("rc_bjdml").Rows(0).Item("memo1").GetType.ToString <> "System.DBNull" Then
                                    TxtMemo1.Text = Trim(rcDataset.Tables("rc_bjdml").Rows(0).Item("memo1"))
                                Else
                                    If Me.CmbPzlxjc.SelectedValue = "BJDJ" Then
                                        TxtMemo1.Text = "1、本报价自即日起1个月内有效；"
                                    Else
                                        TxtMemo1.Text = "1、本报价自即日起2个月内有效；"
                                    End If
                                End If
                                If rcDataset.Tables("rc_bjdml").Rows(0).Item("memo2").GetType.ToString <> "System.DBNull" Then
                                    TxtMemo2.Text = Trim(rcDataset.Tables("rc_bjdml").Rows(0).Item("memo2"))
                                Else
                                    TxtMemo2.Text = "2、无特殊说明，RMB报价为未税单价，外币报价为FOB上海价；"
                                End If
                                If rcDataset.Tables("rc_bjdml").Rows(0).Item("memo3").GetType.ToString <> "System.DBNull" Then
                                    TxtMemo3.Text = Trim(rcDataset.Tables("rc_bjdml").Rows(0).Item("memo3"))
                                Else
                                    TxtMemo3.Text = "3、若汇率波动+/-3%以上或原材料价格异常变动时，需重新确认单价；"
                                End If
                                If rcDataset.Tables("rc_bjdml").Rows(0).Item("memo4").GetType.ToString <> "System.DBNull" Then
                                    TxtMemo4.Text = Trim(rcDataset.Tables("rc_bjdml").Rows(0).Item("memo4"))
                                Else
                                    TxtMemo4.Text = "4、以上SPQ仅供参考，具体按实际；"
                                End If
                                If rcDataset.Tables("rc_bjdml").Rows(0).Item("memo5").GetType.ToString <> "System.DBNull" Then
                                    TxtMemo5.Text = Trim(rcDataset.Tables("rc_bjdml").Rows(0).Item("memo5"))
                                Else
                                    If Me.CmbPzlxjc.SelectedValue = "BJDJ" Then
                                        TxtMemo5.Text = "5、无特殊说明，报价为东磁标准包装。"
                                    Else
                                        TxtMemo5.Text = ""
                                    End If
                                End If
                                '修改单据
                                rcOleDbCommand.CommandText = "SELECT oe_bjd.khlh,oe_bjd.khcz,oe_bjd.cpdm,oe_bjd.cpmc,oe_bjd.cpgg,oe_bjd.dw,oe_bjd.zl,oe_bjd.dj,oe_bjd.wbdm,oe_bjd.wbhl,oe_bjd.spq,oe_bjd.moq,oe_bjd.bjmemo FROM oe_bjd WHERE oe_bjd.djh = ? order by oe_bjd.xh"
                                rcOleDbCommand.Parameters.Clear()
                                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.TxtDjh.Text
                                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                If rcDataset.Tables("rc_bjdnr") IsNot Nothing Then
                                    Me.rcDataset.Tables("rc_bjdnr").Clear()
                                End If
                                rcOleDbDataAdpt.Fill(rcDataset, "rc_bjdnr")
                                Me.rcDataGridView.ClearSelection()
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
        If IsAdding Then
            NewEvent()
        End If
        SetControlEnableEvent()
    End Sub

#End Region

#Region "报价日期的事件"

    Private Sub DtpBjrq_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DtpBjrq.Validating
        '检查会计期间
        Dim dateBegin As DateTime
        Dim dateEnd As DateTime
        dateBegin = getInvBegin(strYear, strMonth)
        dateEnd = getInvEnd(strYear, strMonth)
        If DtpBjrq.Value.Date > dateEnd Or DtpBjrq.Value.Date < dateBegin Then
            MsgBox("您输入的日期不在当前会计期间中，请重输入。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Me.DtpBjrq.Focus()
        End If
    End Sub

#End Region

    '#Region "币种编码的事件"

    '    Private Sub TxtWbdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '        Select Case e.KeyCode
    '            Case Keys.F3
    '                Dim rcFrm As New models.FrmF3KeyPress
    '                With rcFrm
    '                    .paraOleDbConn = rcOleDbConn
    '                    .paraTableName = "rc_wbxx"
    '                    .paraField1 = "wbdm"
    '                    .paraField2 = "wbmc"
    '                    .paraField3 = "wbsm"
    '                    .paraTitle = "币种"
    '                    .paraOldValue = ""
    '                    .paraAddName = ""
    '                    .paraOrderField = "wbmc"
    '                    .paraCondition = "kjnd = '" & strYear & "'"
    '                    If .ShowDialog = DialogResult.OK Then
    '                        TxtWbdm.Text = Trim(.paraField1)
    '                    End If
    '                End With
    '            Case Keys.Down
    '                SendKeys.Send("{TAB}")
    '            Case Keys.Up
    '                SendKeys.Send("+{TAB}")
    '        End Select
    '    End Sub

    '    Private Sub TxtWbdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
    '        If Not String.IsNullOrEmpty(Me.TxtWbdm.Text) Then
    '            Try
    '                rcOleDbConn.Open()
    '                rcOleDbCommand.Connection = rcOleDbConn
    '                rcOleDbCommand.CommandTimeout = 300
    '                rcOleDbCommand.CommandType = CommandType.Text
    '                rcOleDbCommand.CommandText = "SELECT wbdm,wbmc,wbhl" & strMonth & " as wbhl FROM rc_wbxx WHERE kjnd = '" & strYear & "' AND wbdm = ?"
    '                rcOleDbCommand.Parameters.Clear()
    '                rcOleDbCommand.Parameters.Add("@wbdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtWbdm.Text)
    '                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
    '                If Not rcDataset.Tables("rc_wbxx") Is Nothing Then
    '                    Me.rcDataset.Tables("rc_wbxx").Clear()
    '                End If
    '                rcOleDbDataAdpt.Fill(rcDataset, "rc_wbxx")
    '            Catch ex As Exception
    '                Try
    '                    rcOleDbTrans.Rollback()
    '                    MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
    '                Catch ey As OleDbException
    '                    MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
    '                End Try
    '                Return
    '            Finally
    '                rcOleDbConn.Close()
    '            End Try
    '            If rcDataset.Tables("rc_wbxx").Rows.Count > 0 Then
    '                Me.TxtWbdm.Text = Trim(rcDataset.Tables("rc_wbxx").Rows(0).Item("wbdm"))
    '                Me.TxtWbhl.Text = rcDataset.Tables("rc_wbxx").Rows(0).Item("wbhl")
    '                If IsAdding Then
    '                    Me.TxtMemo3.Text = "3、" & IIf(Me.TxtWbdm.Text <> "RMB", Me.TxtWbdm.Text & "对人民币汇率" & Me.TxtWbhl.Text & "，", "") & "若汇率波动+/-3%以上时，需重新确认单价；"
    '                End If
    '            Else
    '                e.Cancel = True
    '            End If
    '            If Not IsEditing Then
    '                IsEditing = True
    '                SetControlEnableEvent()
    '            End If
    '        End If
    '    End Sub

    '#End Region

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
                    .paraTitle = "客户"
                    .paraOldValue = ""
                    .paraAddName = ""
                    .paraOrderField = "khmc"
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
                rcOleDbCommand.CommandText = "SELECT rc_khxx.khdm,rc_khxx.khmc,rc_khxx.lxr,rc_khxx.address,rc_khxx.zydm,rc_zyxx.zymc,rc_zyxx.email,rc_khxx.bjtk FROM rc_khxx LEFT JOIN rc_zyxx ON rc_zyxx.zydm = rc_khxx.zydm WHERE (rc_khxx.khdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKhdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_khxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_khxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_khxx")
                rcOleDbCommand.CommandText = "SELECT email FROM (SELECT email FROM oe_bjd WHERE SUBSTR(djh,1,4) = ? AND khdm = ? ORDER BY djh DESC) WHERE rownum <= 1"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@pzlxjc", OleDbType.VarChar, 4).Value = Trim(Me.CmbPzlxjc.SelectedValue)
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKhdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("bjdemail") IsNot Nothing Then
                    Me.rcDataset.Tables("bjdemail").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "bjdemail")
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_khxx").Rows.Count > 0 Then
                Me.TxtKhdm.Text = Trim(rcDataset.Tables("rc_khxx").Rows(0).Item("khdm"))
                Me.LblKhmc.Text = rcDataset.Tables("rc_khxx").Rows(0).Item("khmc")
                If rcDataset.Tables("rc_khxx").Rows(0).Item("lxr").GetType.ToString <> "System.DBNull" Then
                    strLxr = rcDataset.Tables("rc_khxx").Rows(0).Item("lxr")
                Else
                    strLxr = ""
                End If
                If rcDataset.Tables("rc_khxx").Rows(0).Item("address").GetType.ToString <> "System.DBNull" Then
                    strAddress = rcDataset.Tables("rc_khxx").Rows(0).Item("address")
                Else
                    strAddress = ""
                End If
                If rcDataset.Tables("rc_khxx").Rows(0).Item("zydm").GetType.ToString <> "System.DBNull" Then
                    Me.TxtZydm.Text = rcDataset.Tables("rc_khxx").Rows(0).Item("zydm")
                Else
                    Me.TxtZydm.Text = ""
                End If
                If rcDataset.Tables("rc_khxx").Rows(0).Item("zymc").GetType.ToString <> "System.DBNull" Then
                    Me.LblZymc.Text = rcDataset.Tables("rc_khxx").Rows(0).Item("zymc")
                Else
                    Me.LblZymc.Text = ""
                End If
                If rcDataset.Tables("rc_khxx").Rows(0).Item("email").GetType.ToString <> "System.DBNull" Then
                    Me.TxtEmail.Text = rcDataset.Tables("rc_khxx").Rows(0).Item("email")
                Else
                    Me.TxtEmail.Text = ""
                End If
                If String.IsNullOrEmpty(Me.TxtBjtk.Text) Then
                    If rcDataset.Tables("rc_khxx").Rows(0).Item("bjtk").GetType.ToString <> "System.DBNull" Then
                        Me.TxtBjtk.Text = rcDataset.Tables("rc_khxx").Rows(0).Item("bjtk")
                    Else
                        Me.TxtBjtk.Text = ""
                    End If
                End If
                If rcDataset.Tables("bjdemail").Rows.Count > 0 Then
                    Me.TxtEmail.Text = rcDataset.Tables("bjdemail").Rows(0).Item("email")
                End If
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
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
                End Try
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

#Region "报价条款的事件"

    Private Sub TxtBjtk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBjtk.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtBjtk_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtBjtk.Validating
        If Not String.IsNullOrEmpty(Me.TxtBjtk.Text) Then
            If Not IsEditing Then
                IsEditing = True
                SetControlEnableEvent()
            End If
        End If
    End Sub

#End Region

#Region "DataGridView的事件"

    Private Sub RcDataGridView_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles rcDataGridView.CellValidating
        If Me.rcDataGridView.CurrentRow.IsNewRow = False Then
            If Me.rcDataGridView.IsCurrentCellDirty Then
                Me.rcDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColCpdm" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    If Not String.IsNullOrEmpty(e.FormattedValue) Then
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
                            Try
                                rcOleDbTrans.Rollback()
                                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                            Catch ey As OleDbException
                                MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                            End Try
                            Return
                        Finally
                            rcOleDbConn.Close()
                        End Try
                        If rcDataset.Tables("rc_cpxx").Rows.Count > 0 Then
                            Me.rcDataGridView.CurrentRow.Cells("ColCpdm").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("cpdm")
                            Me.rcDataGridView.CurrentRow.Cells("ColCpmc").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("cpmc")
                            Me.rcDataGridView.CurrentRow.Cells("ColCpgg").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("cpgg")
                            Me.rcDataGridView.CurrentRow.Cells("ColDw").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("dw")
                        Else
                            Me.LblMsg.Text = "产品编码不存在。"
                            e.Cancel = True
                        End If
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColCpmc" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    '取科目名称
                    Try
                        rcOleDbConn.Open()
                        rcOleDbCommand.Connection = rcOleDbConn
                        rcOleDbCommand.CommandTimeout = 300
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT * FROM oe_bjd WHERE (oe_bjd.spq <> 0 OR oe_bjd.moq <> 0) AND oe_bjd.khdm = ? AND oe_bjd.cpmc = ? ORDER BY oe_bjd.djh DESC,oe_bjd.xh DESC"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 50).Value = Me.TxtKhdm.Text
                        rcOleDbCommand.Parameters.Add("@cpmc", OleDbType.VarChar, 50).Value = e.FormattedValue
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("lastmoqspq") IsNot Nothing Then
                            rcDataset.Tables("lastmoqspq").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "lastmoqspq")
                        If rcDataset.Tables("lastmoqspq").Rows.Count <= 0 Then
                            rcOleDbCommand.CommandText = "SELECT * FROM oe_bjd WHERE (oe_bjd.spq <> 0 OR oe_bjd.moq <> 0) AND oe_bjd.cpmc = ? ORDER BY oe_bjd.djh DESC,oe_bjd.xh DESC"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@cpmc", OleDbType.VarChar, 50).Value = e.FormattedValue
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("lastmoqspq") IsNot Nothing Then
                                rcDataset.Tables("lastmoqspq").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "lastmoqspq")
                        End If
                    Catch ex As Exception
                        MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                    If Me.rcDataGridView.CurrentRow.Cells("ColMoq").Value = 0 And Me.rcDataGridView.CurrentRow.Cells("ColSpq").Value = 0 Then
                        If rcDataset.Tables("lastmoqspq").Rows.Count > 0 Then
                            Me.rcDataGridView.CurrentRow.Cells("ColMoq").Value = rcDataset.Tables("lastmoqspq").Rows(0).Item("moq")
                            Me.rcDataGridView.CurrentRow.Cells("ColSpq").Value = rcDataset.Tables("lastmoqspq").Rows(0).Item("spq")
                        End If
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColWbdm" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    If Not String.IsNullOrEmpty(e.FormattedValue) Then
                        '取产品信息
                        Try
                            rcOleDbConn.Open()
                            rcOleDbCommand.Connection = rcOleDbConn
                            rcOleDbCommand.CommandTimeout = 300
                            rcOleDbCommand.CommandType = CommandType.Text
                            rcOleDbCommand.CommandText = "SELECT wbdm,wbmc,wbhl" & strMonth & " as wbhl FROM rc_wbxx WHERE kjnd = '" & strYear & "' AND wbdm = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.AddWithValue("@wbdm", rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColWbdm").EditedFormattedValue)
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("rc_wbxx") IsNot Nothing Then
                                rcDataset.Tables("rc_wbxx").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "rc_wbxx")
                        Catch ex As Exception
                            Try
                                rcOleDbTrans.Rollback()
                                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                            Catch ey As OleDbException
                                MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                            End Try
                            Return
                        Finally
                            rcOleDbConn.Close()
                        End Try
                        If rcDataset.Tables("rc_wbxx").Rows.Count > 0 Then
                            Me.rcDataGridView.CurrentRow.Cells("ColWbdm").Value = rcDataset.Tables("rc_wbxx").Rows(0).Item("wbdm")
                            Me.rcDataGridView.CurrentRow.Cells("ColWbhl").Value = rcDataset.Tables("rc_wbxx").Rows(0).Item("wbhl")
                        Else
                            Me.LblMsg.Text = "币种编码不存在。"
                            e.Cancel = True
                        End If
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
                Me.rcDataGridView.EndEdit()
                Me.rcBindingSource.EndEdit()
        End Select
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColCpdm" Then
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
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColWbdm" Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF3KeyPress
                    With rcFrm
                        .paraOleDbConn = rcOleDbConn
                        .paraTableName = "rc_wbxx"
                        .paraField1 = "wbdm"
                        .paraField2 = "wbmc"
                        .paraField3 = "wbsm"
                        .paraTitle = "币种"
                        .paraOldValue = ""
                        .paraAddName = ""
                        .paraOrderField = "wbmc"
                        .paraCondition = "kjnd = '" & strYear & "'"
                        If .ShowDialog = DialogResult.OK Then
                            '将用户在rcfrmselectcpdm所选择的cpdm带入rcdatarid'
                            Me.rcDataGridView.CurrentRow.Cells("ColWbdm").Value = .paraField1
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
        If Me.rcDataGridView.CurrentCell.OwningColumn.Name = "ColCpdm" Or Me.rcDataGridView.CurrentCell.OwningColumn.Name = "ColWbdm" Then
            EditingControl.CharacterCasing = CharacterCasing.Upper
        Else
            EditingControl.CharacterCasing = CharacterCasing.Normal
        End If
    End Sub

    Private Sub EditingControl_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColCpdm" Then
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
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColWbdm" Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF3KeyPress
                    With rcFrm
                        .paraOleDbConn = rcOleDbConn
                        .paraTableName = "rc_wbxx"
                        .paraField1 = "wbdm"
                        .paraField2 = "wbmc"
                        .paraField3 = "wbsm"
                        .paraTitle = "币种"
                        .paraOldValue = ""
                        .paraAddName = ""
                        .paraOrderField = "wbmc"
                        .paraCondition = "kjnd = '" & strYear & "'"
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
        If dtBjd.Rows.Count > 0 Then
            IsEditing = True
            SetControlEnableEvent()
        End If
    End Sub

#End Region

#Region "新增单据事件"

    Private Sub MnuiNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiNew.Click
        NewEvent()
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        NewEvent()
    End Sub

    Private Sub NewEvent()
        '清空数据
        'Me.TxtWbdm.Text = ""
        'Me.TxtWbhl.Text = 0.0
        Me.TxtKhdm.Text = ""
        Me.LblKhmc.Text = ""
        Me.TxtZydm.Text = ""
        Me.LblZymc.Text = ""
        Me.TxtEmail.Text = ""
        Me.TxtBjtk.Text = ""
        If Me.CmbPzlxjc.SelectedValue = "BJDJ" Then
            Me.TxtMemo1.Text = "1、本报价自即日起1个月内有效；"
        Else
            Me.TxtMemo1.Text = "1、本报价自即日起2个月内有效；"
        End If
        Me.TxtMemo2.Text = "2、无特殊说明，RMB报价为未税单价，外币报价为FOB上海价；"
        Me.TxtMemo3.Text = "3、若汇率波动+/-3%以上或原材料价格异常变动时，需重新确认单价；"
        Me.TxtMemo4.Text = "4、以上SPQ仅供参考，具体按实际；"
        If Me.CmbPzlxjc.SelectedValue = "BJDJ" Then
            Me.TxtMemo5.Text = "5、无特殊说明，报价为东磁标准包装。"
        Else
            Me.TxtMemo5.Text = ""
        End If
        '显示新单据号
        ShowNewDjh()
        IsAdding = True
        IsEditing = False
        '清空数据
        If rcDataset.Tables("rc_bjdnr") IsNot Nothing Then
            Me.rcDataset.Tables("rc_bjdnr").Clear()
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
                rcOleDbCommand.CommandText = "SELECT pzno" & strMonth & " as pzno FROM rc_lx WHERE pzlxdm = ? and lxgs = '产品报价单' and kjnd = '" & strYear & "'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.AddWithValue("@pzlxdm", Trim(Me.CmbPzlxjc.SelectedValue))
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_pzno") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_pzno").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_pzno")
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_pzno").Rows.Count = 0 Then
                MsgBox("请定义单据类型。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            Me.TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
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
        If rcDataset.Tables("rc_bjdnr").Rows.Count = 0 Then
            MsgBox("没有相应的业务，请输入。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        '(2)客户检查
        If Trim(Me.TxtKhdm.Text).Length = 0 Then
            MsgBox("请输入客户编码。", MsgBoxStyle.OkOnly, "提示信息")
            Return
        End If
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@pStrCode", OleDbType.VarChar, 15).Value = Trim(Me.TxtKhdm.Text)
            rcOleDbCommand.Parameters.Add("@pStrTable", OleDbType.VarChar, 30).Value = "rc_khxx"
            rcOleDbCommand.Parameters.Add("@pStrField", OleDbType.VarChar, 30).Value = "khdm"
            rcOleDbCommand.Parameters.Add("@pStrCondition", OleDbType.VarChar, 100).Value = ""
            rcOleDbCommand.Parameters.Add("@pIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
            rcOleDbCommand.ExecuteNonQuery()
            If rcOleDbCommand.Parameters.Item("@pIntRecordCount").Value <> 1 Then
                MsgBox(Trim(Me.TxtKhdm.Text) & "客户编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                Me.TxtKhdm.Text = ""
                Me.LblKhmc.Text = ""
                Me.TxtKhdm.Focus()
                Return
            End If
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        ''(2)币种检查
        'If Trim(Me.TxtWbdm.Text).Length = 0 Then
        '    MsgBox("请输入币种编码。", MsgBoxStyle.OkOnly, "提示信息")
        '    Return
        'End If
        'Try
        '    rcOleDbConn.Open()
        '    rcOleDbCommand.Connection = rcOleDbConn
        '    rcOleDbCommand.CommandTimeout = 300
        '    rcOleDbCommand.CommandType = CommandType.StoredProcedure
        '    rcOleDbCommand.CommandText = "USP_CHECK_CODE"
        '    rcOleDbCommand.Parameters.Clear()
        '    rcOleDbCommand.Parameters.Add("@pStrCode", OleDbType.VarChar, 15).Value = Trim(Me.TxtWbdm.Text)
        '    rcOleDbCommand.Parameters.Add("@pStrTable", OleDbType.VarChar, 30).Value = "rc_wbxx"
        '    rcOleDbCommand.Parameters.Add("@pStrField", OleDbType.VarChar, 30).Value = "wbdm"
        '    rcOleDbCommand.Parameters.Add("@pStrCondition", OleDbType.VarChar, 100).Value = ""
        '    rcOleDbCommand.Parameters.Add("@pIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
        '    rcOleDbCommand.ExecuteNonQuery()
        '    If rcOleDbCommand.Parameters.Item("@pIntRecordCount").Value <= 0 Then
        '        MsgBox(Trim(Me.TxtWbdm.Text) & "币种编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
        '        Me.TxtWbdm.Text = ""
        '        Me.TxtWbhl.Text = 0.0
        '        Me.TxtWbdm.Focus()
        '        Return
        '    End If
        'Catch ex As Exception
        '    Try
        '        rcOleDbTrans.Rollback()
        '        MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
        '    Catch ey As OleDbException
        '        MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
        '    End Try
        '    Return
        'Finally
        '    rcOleDbConn.Close()
        'End Try

        '(3)单据号长度检查
        If Trim(Me.TxtDjh.Text).Length <> 15 Then
            MsgBox("单据号长度不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Return
        End If
        For i = 0 To rcDataset.Tables("rc_bjdnr").Rows.Count - 1
            If rcDataset.Tables("rc_bjdnr").Rows(i).RowState <> DataRowState.Deleted Then
                If rcDataset.Tables("rc_bjdnr").Rows(i).Item("cpdm").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_bjdnr").Rows(i).Item("cpdm") = ""
            End If
            If rcDataset.Tables("rc_bjdnr").Rows(i).Item("cpmc").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_bjdnr").Rows(i).Item("cpmc") = ""
            End If
            If rcDataset.Tables("rc_bjdnr").Rows(i).Item("cpgg").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_bjdnr").Rows(i).Item("cpgg") = ""
            End If
            If rcDataset.Tables("rc_bjdnr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_bjdnr").Rows(i).Item("dw") = ""
            End If
            If rcDataset.Tables("rc_bjdnr").Rows(i).Item("khlh").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_bjdnr").Rows(i).Item("khlh") = ""
            End If
            If rcDataset.Tables("rc_bjdnr").Rows(i).Item("khcz").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_bjdnr").Rows(i).Item("khcz") = ""
            End If
            If rcDataset.Tables("rc_bjdnr").Rows(i).Item("zl").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_bjdnr").Rows(i).Item("zl") = 0.0
            End If
            If rcDataset.Tables("rc_bjdnr").Rows(i).Item("dj").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_bjdnr").Rows(i).Item("dj") = 0.0
            End If
            If rcDataset.Tables("rc_bjdnr").Rows(i).Item("spq").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_bjdnr").Rows(i).Item("spq") = 0.0
            End If
            If rcDataset.Tables("rc_bjdnr").Rows(i).Item("moq").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_bjdnr").Rows(i).Item("moq") = 0.0
            End If
                If rcDataset.Tables("rc_bjdnr").Rows(i).Item("bjmemo").GetType.ToString = "System.DBNull" Then
                    rcDataset.Tables("rc_bjdnr").Rows(i).Item("bjmemo") = ""
                End If
            End If
        Next
        '(二)存储
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP3_SAVE_OE_BJD"
            For i = 0 To rcDataset.Tables("rc_bjdnr").Rows.Count - 1
                If rcDataset.Tables("rc_bjdnr").Rows(i).RowState <> DataRowState.Deleted Then
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = IIf(IsAdding, 1, 0)
                rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = Trim(Me.TxtDjh.Text)
                rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = i + 1
                rcOleDbCommand.Parameters.Add("@paraDateBjrq", OleDbType.Date, 8).Value = Me.DtpBjrq.Value.Date
                rcOleDbCommand.Parameters.Add("@paraStrWbdm", OleDbType.VarChar, 4).Value = Trim(rcDataset.Tables("rc_bjdnr").Rows(i).Item("wbdm"))
                rcOleDbCommand.Parameters.Add("@paraDblWbhl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_bjdnr").Rows(i).Item("wbhl")
                rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtKhdm.Text)
                rcOleDbCommand.Parameters.Add("@paraStrKhmc", OleDbType.VarChar, 100).Value = Me.LblKhmc.Text
                rcOleDbCommand.Parameters.Add("@paraStrZydm", OleDbType.VarChar, 12).Value = Trim(Me.TxtZydm.Text)
                rcOleDbCommand.Parameters.Add("@paraStrZymc", OleDbType.VarChar, 30).Value = Me.LblZymc.Text
                rcOleDbCommand.Parameters.Add("@paraStrEmail", OleDbType.VarChar, 300).Value = Trim(Me.TxtEmail.Text)
                rcOleDbCommand.Parameters.Add("@paraStrBjtk", OleDbType.VarChar, 200).Value = Trim(Me.TxtBjtk.Text)
                rcOleDbCommand.Parameters.Add("@paraStrKhlh", OleDbType.VarChar, 50).Value = Trim(rcDataset.Tables("rc_bjdnr").Rows(i).Item("khlh"))
                rcOleDbCommand.Parameters.Add("@paraStrKhcz", OleDbType.VarChar, 30).Value = Trim(rcDataset.Tables("rc_bjdnr").Rows(i).Item("khcz"))
                rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("rc_bjdnr").Rows(i).Item("cpdm")).ToUpper
                rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 40).Value = Trim(rcDataset.Tables("rc_bjdnr").Rows(i).Item("cpmc"))
                rcOleDbCommand.Parameters.Add("@paraStrCpgg", OleDbType.VarChar, 40).Value = Trim(rcDataset.Tables("rc_bjdnr").Rows(i).Item("cpgg"))
                rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = Trim(rcDataset.Tables("rc_bjdnr").Rows(i).Item("dw"))
                rcOleDbCommand.Parameters.Add("@paraDblZl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_bjdnr").Rows(i).Item("zl")
                rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_bjdnr").Rows(i).Item("dj")
                rcOleDbCommand.Parameters.Add("@paraDblSpq", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_bjdnr").Rows(i).Item("spq")
                rcOleDbCommand.Parameters.Add("@paraDblMoq", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_bjdnr").Rows(i).Item("moq")
                rcOleDbCommand.Parameters.Add("@paraStrBjmemo", OleDbType.VarChar, 50).Value = Trim(rcDataset.Tables("rc_bjdnr").Rows(i).Item("bjmemo"))
                rcOleDbCommand.Parameters.Add("@paraStrMemo1", OleDbType.VarChar, 300).Value = Me.TxtMemo1.Text
                rcOleDbCommand.Parameters.Add("@paraStrMemo2", OleDbType.VarChar, 300).Value = Me.TxtMemo2.Text
                rcOleDbCommand.Parameters.Add("@paraStrMemo3", OleDbType.VarChar, 300).Value = Me.TxtMemo3.Text
                rcOleDbCommand.Parameters.Add("@paraStrMemo4", OleDbType.VarChar, 300).Value = Me.TxtMemo4.Text
                rcOleDbCommand.Parameters.Add("@paraStrMemo5", OleDbType.VarChar, 300).Value = Me.TxtMemo5.Text
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
                End If
            Next
            rcOleDbTrans.Commit()
        Catch ex As Exception
            MsgBox("执行程序时发生了错误。" & Chr(13) & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
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
        Dim row As DataRow = dtBjd.NewRow
        dtBjd.Rows.InsertAt(row, rcDataGridView.CurrentCell.RowIndex)
        dtBjd.AcceptChanges()
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
            If rcDataset.Tables("rc_bjdnr").Rows.Count > 0 Then
                rcDataset.Tables("rc_bjdnr").Rows(rcDataGridView.CurrentRow.Index).Delete()
                rcDataset.Tables("rc_bjdnr").AcceptChanges()
                IsEditing = True
                SetControlEnableEvent()
            End If
        End If
    End Sub
#End Region

    '发送电子邮件参数设置
    Private Sub MnuiEmailOption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiEmailOption.Click
        Dim rcFrm As New FrmEmailOption
        With rcFrm
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

#Region "读入excel"

    Private Sub BtnImpXls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImpXls.Click, MnuiImpXls.Click
        '调用表单
        Dim rcFrm As New FrmOeBjdImpXls
        With rcFrm
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
        Dim rft As String = CurDir() + "\reports\oebjdbz.rft"
        rcRps.LoadTemplate(rft)
        '取RPS数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps WHERE rpsid = 'OEBJDBZ'"
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
        '套打
        'rcRps.PaperType = 1

        rcRps.Text(-1, 1) = g_PrnDwmc & "报价单"
        rcRps.Text(-1, 2) = "单据号：" & Trim(Me.TxtDjh.Text) & "  %p/%t"
        rcRps.Text(-1, 3) = "报价日期：" & DtpBjrq.Value.Date.ToLongDateString
        rcRps.Text(-1, 4) = "客户：(" & Trim(Me.TxtKhdm.Text) & ")" & Me.LblKhmc.Text
        'rcRps.Text(-1, 5) = "币种：(" & Trim(Me.TxtWbdm.Text) & ")" & Me.TxtWbhl.Text
        rcRps.Text(-1, 6) = "报价条款：(" & Trim(Me.TxtBjtk.Text) & ")"
        Dim i As Integer
        Dim j As Integer
        Dim intPage As Integer
        For intPage = 1 To System.Math.Ceiling(rcDataset.Tables("rc_bjdnr").Rows.Count / rcRps.LinesPerPage.ToString)
            For i = (intPage - 1) * rcRps.LinesPerPage.ToString To System.Math.Min(intPage * rcRps.LinesPerPage.ToString - 1, rcDataset.Tables("rc_bjdnr").Rows.Count - 1)
                If rcDataset.Tables("rc_bjdnr").Rows(i).RowState <> 8 Then
                    If Not rcDataset.Tables("rc_bjdnr").Rows(i).Item("khlh").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 1) = rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("khlh") & IIf(Not String.IsNullOrEmpty(rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("khcz")), "," & rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("khcz"), "")
                    End If
                    If Not rcDataset.Tables("rc_bjdnr").Rows(i).Item("cpmc").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 2) = rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("cpmc") & IIf(Not String.IsNullOrEmpty(rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("cpgg")), "," & rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("cpgg"), "")
                    End If
                    If Not rcDataset.Tables("rc_bjdnr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 3) = Trim(rcDataset.Tables("rc_bjdnr").Rows(i).Item("dw"))
                    End If
                    If Not rcDataset.Tables("rc_bjdnr").Rows(i).Item("zl").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 4) = Format(rcDataset.Tables("rc_bjdnr").Rows(i).Item("zl"), g_FormatSl)
                    End If
                    'If Not rcDataset.Tables("rc_bjdnr").Rows(i).Item("dj").GetType.ToString = "System.DBNull" Then
                    '    rcRps.Text(j + 1, 5) = Me.TxtWbdm.Text & Format(rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("dj"), IIf(rcDataset.Tables("rc_bjdnr").Rows(i).Item("dj") >= 10, "0.00;;#.#", "0.00000;;#.#"))
                    'End If
                    If Not rcDataset.Tables("rc_bjdnr").Rows(i).Item("spq").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 6) = rcDataset.Tables("rc_bjdnr").Rows(i).Item("spq")
                    End If
                    If Not rcDataset.Tables("rc_bjdnr").Rows(i).Item("moq").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 7) = Trim(rcDataset.Tables("rc_bjdnr").Rows(i).Item("moq"))
                    End If
                    If Not rcDataset.Tables("rc_bjdnr").Rows(i).Item("bjmemo").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 8) = Trim(rcDataset.Tables("rc_bjdnr").Rows(i).Item("bjmemo"))
                    End If
                    j += 1
                End If
            Next
            'Dim m As New models.ChineseNum
            'm.InputString = dblTotalSl
            'rcRps.PerPageText(intPage, 7) = IIf(intPage = Math.Ceiling(rcDataset.Tables("rc_bjdnr").Rows.Count / rcRps.LinesPerPage.ToString), "合计", "小计")
            'rcRps.PerPageText(intPage, 8) = m.OutString '大写
            'rcRps.PerPageText(intPage, 9) = Format(dblTotalSl, g_FormatSl)
            'rcRps.PerPageText(intPage, 11) = Format(dblTotalFzsl, g_FormatSl)
        Next
        If Decimal.op_Modulus(rcDataset.Tables("rc_bjdnr").Rows.Count, rcRps.LinesPerPage.ToString) <> 0 Then
            For i = Decimal.op_Modulus(rcDataset.Tables("rc_bjdnr").Rows.Count, rcRps.LinesPerPage.ToString) + 1 To rcRps.LinesPerPage.ToString
                rcRps.Text(j + 1, 1) = ""
                j += 1
            Next
        End If
        rcRps.Text(-1, 14) = "制单：" & g_User_DspName
    End Sub

#End Region

#Region "打印设置事件"

    Private Sub PageSetupEvent()
        Dim rcFrmPageSetup As New models.FrmPageSetup
        With rcFrmPageSetup
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = "OEBJDBZ"
            .paraRpsName = "产品报价单标准格式"
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
            .ParaRps = rcRps
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

    '#Region "打印预览事件"

    '    Private Sub MnuiPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPageSetup.Click
    '        PageSetupEvent()
    '    End Sub

    '    Private Sub PageSetupEvent()
    '        Dim rcFrmPageSetup As New models.FrmPageSetup
    '        With rcFrmPageSetup
    '            .paraOleDbConn = rcOleDbConn
    '            .paraRpsId = "BJDBZ"
    '            .paraRpsName = "报价单标准格式"
    '            .ShowDialog()
    '        End With
    '    End Sub

    '    Private Sub MnuiPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrint.Click
    '        PrintEvent()
    '    End Sub

    '    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
    '        PrintEvent()
    '    End Sub

    '    Private Sub PrintEvent()
    '        If MsgBox("是否使用标准格式打印报价单?", MsgBoxStyle.YesNo + MsgBoxStyle.Information + MsgBoxStyle.DefaultButton1, "提示信息") = MsgBoxResult.Yes Then
    '            blnChEn = True
    '        Else
    '            blnChEn = False
    '            If MsgBox("是否含税?", MsgBoxStyle.YesNo + MsgBoxStyle.Information + MsgBoxStyle.DefaultButton1, "提示信息") = MsgBoxResult.Yes Then
    '                blnHs = True
    '            Else
    '                blnHs = False
    '            End If
    '        End If
    '        Try
    '            If blnChEn = True Then
    '                rcPrintDocument.DefaultPageSettings.Landscape = True
    '            Else
    '                rcPrintDocument.DefaultPageSettings.Landscape = False
    '            End If
    '            Me.rcPrintDocument.Print()
    '        Catch ex As Exception
    '            MessageBox.Show(ex.ToString)
    '        End Try
    '        'If g_Demo = 1 Then
    '        '    MsgBox("对不起，试用软件不能打印。", MsgBoxStyle.OKOnly + MsgBoxStyle.Question, "提示信息")
    '        '    Return
    '        'End If
    '        'Dim rcFrmPrint As New models.FrmPrint
    '        'With rcFrmPrint
    '        '    .paraRps = rcRps
    '        '    .ShowDialog()
    '        'End With
    '    End Sub

    '    Private Sub MnuiPrintView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrintView.Click
    '        PrintViewEvent()
    '    End Sub

    '    Private Sub BtnPrintView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrintView.Click
    '        PrintViewEvent()
    '    End Sub

    '    Private Sub PrintViewEvent()
    '        If MsgBox("是否使用标准格式打印报价单?", MsgBoxStyle.YesNo + MsgBoxStyle.Information + MsgBoxStyle.DefaultButton1, "提示信息") = MsgBoxResult.Yes Then
    '            blnChEn = True
    '        Else
    '            blnChEn = False
    '            If MsgBox("是否含税?", MsgBoxStyle.YesNo + MsgBoxStyle.Information + MsgBoxStyle.DefaultButton1, "提示信息") = MsgBoxResult.Yes Then
    '                blnHs = True
    '            Else
    '                blnHs = False
    '            End If
    '        End If
    '        Try
    '            Dim ps As New Printing.PageSettings
    '            'Dim myPaperSize As System.Drawing.Printing.PaperSize
    '            'myPaperSize = New System.Drawing.Printing.PaperSize("A4+", 826, 1169)
    '            'ps.PaperSize = myPaperSize         '设置为指定的纸张   
    '            'ps.Landscape = True
    '            'rcPrintDocument.DefaultPageSettings = ps
    '            'rcPrintDocument.PrinterSettings.PrinterName = ps.PrinterSettings.PrinterName
    '            'rcPrintDocument.DefaultPageSettings.Landscape = True
    '            Dim PrevDialog As New PrintPreviewDialog
    '            If blnChEn = True Then
    '                rcPrintDocument.DefaultPageSettings.Landscape = True
    '            Else
    '                rcPrintDocument.DefaultPageSettings.Landscape = False
    '            End If
    '            PrevDialog.Document = rcPrintDocument
    '            PrevDialog.WindowState = FormWindowState.Maximized
    '            PrevDialog.ShowDialog()
    '        Catch ex As Exception
    '            MessageBox.Show(ex.ToString)
    '        End Try
    '        'rcRps.Preview()
    '    End Sub

    '    Private Sub RcPrintDocument_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles rcPrintDocument.PrintPage
    '        If rcDataset.Tables("rc_bjdnr").Rows.Count <= 0 Then
    '            Return
    '        End If
    '        '每页行数
    '        Dim linesPerPage As Single = 8
    '        '页数
    '        Dim countPage As Integer = 0
    '        countPage = Math.Floor((rcDataset.Tables("rc_bjdnr").Rows.Count - 1) / linesPerPage) + 1
    '        Dim currentPage As Integer = 0
    '        For currentPage = 1 To countPage
    '            If blnChEn Then
    '                ' Create image.
    '                Dim imageFile As System.Drawing.Image = System.Drawing.Image.FromFile("reports\logo.bmp")
    '                ' Draw image to screen.
    '                e.Graphics.DrawImage(imageFile, New PointF(100.0F, 30.0F))
    '                ' Create font and brush.
    '                Dim drawFont As New System.Drawing.Font("宋体", 18)
    '                Dim drawBrush As New System.Drawing.SolidBrush(Color.Black)
    '                ' Create point for upper-left corner of drawing.
    '                Dim x As Single = 400.0F
    '                Dim y As Single = 30.0F
    '                ' Draw string to screen.
    '                e.Graphics.DrawString("横店集团东磁股份有限公司", drawFont, drawBrush, x, y)
    '                '报价单
    '                drawFont = New System.Drawing.Font("黑体", 20, FontStyle.Bold)
    '                x = 420.0F
    '                y = 60.0F
    '                e.Graphics.DrawString("软磁事业本部报价单", drawFont, drawBrush, x, y)
    '                ' Create pen.
    '                Dim blackPen As New Pen(Color.Black, 1)
    '                ' Create location and size of rectangle.
    '                x = 100.0F
    '                y = 110.0F
    '                Dim width As Single = 330.0F
    '                Dim height As Single = 31.5F
    '                '画表头
    '                Dim i As Integer
    '                Dim j As Integer
    '                'For i = 0 To 2
    '                '    x = 100.0F + 330.0F * i
    '                For j = 0 To 1
    '                    y = 110.0F + 31.5F * j
    '                    x = 100.0F
    '                    width = 440.0F
    '                    ' Draw rectangle to screen.
    '                    e.Graphics.DrawRectangle(blackPen, x, y, width, height)
    '                    x = 540.0F
    '                    width = 220.0F
    '                    ' Draw rectangle to screen.
    '                    e.Graphics.DrawRectangle(blackPen, x, y, width, height)
    '                    x = 760.0F
    '                    width = 330.0F
    '                    ' Draw rectangle to screen.
    '                    e.Graphics.DrawRectangle(blackPen, x, y, width, height)

    '                    'Next
    '                Next
    '                height = 45.0F
    '                For i = 0 To 8
    '                    x = 100.0F
    '                    y = 173.0F + height * i
    '                    width = 200.0F
    '                    '客户料号'客户材质
    '                    e.Graphics.DrawRectangle(blackPen, x, y, width, height)
    '                    x = x + width
    '                    width = 180.0F
    '                    '东磁型号'产品属性
    '                    e.Graphics.DrawRectangle(blackPen, x, y, width, height)
    '                    x = x + width
    '                    width = 60.0F
    '                    '材质
    '                    e.Graphics.DrawRectangle(blackPen, x, y, width, height)
    '                    x = x + width
    '                    width = 60.0F
    '                    '单位
    '                    e.Graphics.DrawRectangle(blackPen, x, y, width, height)
    '                    x = x + width
    '                    width = 65.0F
    '                    '重量
    '                    e.Graphics.DrawRectangle(blackPen, x, y, width, height)
    '                    x = x + width
    '                    width = 50.0F
    '                    '币种
    '                    e.Graphics.DrawRectangle(blackPen, x, y, width, height)
    '                    x = x + width
    '                    width = 75.0F
    '                    '单价
    '                    e.Graphics.DrawRectangle(blackPen, x, y, width, height)
    '                    x = x + width
    '                    width = 50.0F
    '                    '最小包装量
    '                    e.Graphics.DrawRectangle(blackPen, x, y, width, height)
    '                    x = x + width
    '                    width = 50.0F
    '                    '最小订单量
    '                    e.Graphics.DrawRectangle(blackPen, x, y, width, height)
    '                    x = x + width
    '                    width = 200.0F
    '                    '备注
    '                    e.Graphics.DrawRectangle(blackPen, x, y, width, height)
    '                Next
    '                x = 100.0F
    '                y = 578.0F
    '                width = 990.0F
    '                height = 40.0F
    '                '备注说明
    '                e.Graphics.DrawRectangle(blackPen, x, y, width, height)
    '                x = 100.0F
    '                y = 618.0F
    '                width = 990.0F
    '                height = 40.0F
    '                '其他事项
    '                e.Graphics.DrawRectangle(blackPen, x, y, width, height)
    '                '单位名称
    '                drawFont = New Font("宋体", 12)
    '                x = 100.5F
    '                y = 115.0F
    '                e.Graphics.DrawString("TO：" & Trim(LblKhmc.Text), drawFont, drawBrush, x, y)
    '                x = 100.5F + 440.0F
    '                y = 115.0F
    '                e.Graphics.DrawString("ATTN：" & IIf(rcDataset.Tables("rc_khxx").Rows(0).Item("lxr").GetType.ToString <> "System.DBNull", Trim(rcDataset.Tables("rc_khxx").Rows(0).Item("lxr")), ""), drawFont, drawBrush, x, y)
    '                x = 100.5F + 440.0F + 220.0F
    '                y = 115.0F
    '                e.Graphics.DrawString("FAX NO：" & IIf(rcDataset.Tables("rc_khxx").Rows(0).Item("fax").GetType.ToString <> "System.DBNull", Trim(rcDataset.Tables("rc_khxx").Rows(0).Item("fax")), ""), drawFont, drawBrush, x, y)
    '                x = 100.5F
    '                y = 115.0F + 31.5F
    '                e.Graphics.DrawString("DATE：" & Trim(DtpBjrq.Value.Date.ToLongDateString), drawFont, drawBrush, x, y)
    '                x = 100.5F + 330.0F + 330.0F
    '                y = 115.0F + 31.5F
    '                e.Graphics.DrawString("REF NO：" & Trim(Me.TxtDjh.Text) & " " & currentPage & "/" & countPage, drawFont, drawBrush, x, y)

    '                'x = 100.5F + 357.0F
    '                'e.Graphics.DrawString("PAGES：1", drawFont, drawBrush, x, y)
    '                '客户料号
    '                x = 160.0F
    '                y = 190.0F
    '                e.Graphics.DrawString("客户料号", drawFont, drawBrush, x, y)
    '                '东磁型号
    '                x = 350.0F
    '                y = 190.0F
    '                e.Graphics.DrawString("东磁型号", drawFont, drawBrush, x, y)
    '                '东磁型号
    '                x = 490.0F
    '                y = 190.0F
    '                e.Graphics.DrawString("材质", drawFont, drawBrush, x, y)
    '                '东磁型号
    '                x = 550.0F
    '                y = 190.0F
    '                e.Graphics.DrawString("单位", drawFont, drawBrush, x, y)
    '                '重量
    '                x = 615.0F
    '                y = 190.0F
    '                e.Graphics.DrawString("重量", drawFont, drawBrush, x, y)
    '                '币种
    '                x = 675.0F
    '                y = 190.0F
    '                e.Graphics.DrawString("币种", drawFont, drawBrush, x, y)
    '                '单价
    '                x = 735.0F
    '                y = 190.0F
    '                e.Graphics.DrawString("单价", drawFont, drawBrush, x, y)
    '                '最小包装数量
    '                x = 795.0F
    '                y = 190.0F
    '                e.Graphics.DrawString("SPQ", drawFont, drawBrush, x, y)
    '                '最小订单数量
    '                x = 845.0F
    '                y = 190.0F
    '                e.Graphics.DrawString("MOQ", drawFont, drawBrush, x, y)
    '                '备注
    '                x = 980.0F
    '                y = 190.0F
    '                e.Graphics.DrawString("备注", drawFont, drawBrush, x, y)
    '                height = 45.0F
    '                Dim drawRect As New RectangleF
    '                For i = 0 To If(currentPage < countPage, 7, rcDataset.Tables("rc_bjdnr").Rows.Count - (currentPage - 1) * 8 - 1)
    '                    '客户料号
    '                    x = 100.5F
    '                    y = 178.0F + (i + 1) * height
    '                    width = 200.0F
    '                    drawRect = New RectangleF(x, y, width, height)
    '                    e.Graphics.DrawString(Trim(rcDataset.Tables("rc_bjdnr").Rows(i + currentPage * 8 - 8).Item("khlh")) & "  " & Trim(rcDataset.Tables("rc_bjdnr").Rows(i + currentPage * 8 - 8).Item("khcz")), drawFont, drawBrush, drawRect)
    '                    '东磁型号
    '                    x = 300.5F
    '                    y = 178.0F + (i + 1) * height
    '                    width = 180.0F
    '                    drawRect = New RectangleF(x, y, width, height)
    '                    e.Graphics.DrawString(Trim(rcDataset.Tables("rc_bjdnr").Rows(i + currentPage * 8 - 8).Item("cpmc")), drawFont, drawBrush, drawRect)
    '                    '材质
    '                    x = 480.5F
    '                    y = 190.0F + (i + 1) * height
    '                    width = 60.0F
    '                    drawRect = New RectangleF(x, y, width, height)
    '                    e.Graphics.DrawString(Trim(rcDataset.Tables("rc_bjdnr").Rows(i + currentPage * 8 - 8).Item("cpgg")), drawFont, drawBrush, drawRect)
    '                    '单位
    '                    x = 540.5F
    '                    y = 190.0F + (i + 1) * height
    '                    width = 60.0F
    '                    drawRect = New RectangleF(x, y, width, height)
    '                    e.Graphics.DrawString(Trim(rcDataset.Tables("rc_bjdnr").Rows(i + currentPage * 8 - 8).Item("dw")), drawFont, drawBrush, drawRect)
    '                    '重量
    '                    x = 600.5F
    '                    y = 190.0F + (i + 1) * height
    '                    e.Graphics.DrawString(Format(rcDataset.Tables("rc_bjdnr").Rows(i + currentPage * 8 - 8).Item("zl"), IIf(rcDataset.Tables("rc_bjdnr").Rows(i + currentPage * 8 - 8).Item("zl") >= 10, "0.00;;#.#", "0.0000;;#.#")), drawFont, drawBrush, x, y)
    '                    '币种
    '                    x = 665.5F
    '                    y = 190.0F + (i + 1) * height
    '                    e.Graphics.DrawString(Trim(rcDataset.Tables("rc_bjdnr").Rows(i + currentPage * 8 - 8).Item("wbdm")), drawFont, drawBrush, x, y)
    '                    '单价
    '                    x = 715.5F
    '                    y = 190.0F + (i + 1) * height
    '                    e.Graphics.DrawString(Format(rcDataset.Tables("rc_bjdnr").Rows(i + currentPage * 8 - 8).Item("dj"), IIf(rcDataset.Tables("rc_bjdnr").Rows(i + currentPage * 8 - 8).Item("dj") >= 10, "0.00;;#.#", "0.00000;;#.#")), drawFont, drawBrush, x, y)
    '                    '最小包装数量
    '                    x = 790.5F
    '                    y = 190.0F + (i + 1) * height
    '                    e.Graphics.DrawString(Format(rcDataset.Tables("rc_bjdnr").Rows(i + currentPage * 8 - 8).Item("spq"), "0;;#"), drawFont, drawBrush, x, y)
    '                    '最小订单数量
    '                    x = 840.5F
    '                    y = 190.0F + (i + 1) * height
    '                    e.Graphics.DrawString(Format(rcDataset.Tables("rc_bjdnr").Rows(i + currentPage * 8 - 8).Item("moq"), "0;;#"), drawFont, drawBrush, x, y)
    '                    '备注
    '                    x = 890.5F
    '                    y = 178.0F + (i + 1) * height
    '                    width = 200.0F
    '                    drawRect = New RectangleF(x, y, width, height)
    '                    e.Graphics.DrawString(Trim(rcDataset.Tables("rc_bjdnr").Rows(i + currentPage * 8 - 8).Item("bjmemo")), drawFont, drawBrush, drawRect)
    '                Next
    '                drawFont = New Font("宋体", 9)
    '                '备注内容
    '                x = 100.5F
    '                y = 578.5F
    '                drawFont = New Font("宋体", 9)
    '                e.Graphics.DrawString("备注：1、本报价自即日起1个月内有效；", drawFont, drawBrush, x, y)
    '                x = 665.5F
    '                y = 578.5F
    '                e.Graphics.DrawString("      2、无特殊说明，RMB报价为未税单价，外币报价为FOB上海价；", drawFont, drawBrush, x, y)
    '                x = 100.5F
    '                y = 598.5F
    '                e.Graphics.DrawString("      3、USD对RMB汇率6.62，HKD对RMB汇率0.85，若汇率波动+/-3%以上时，需重新确认单价；", drawFont, drawBrush, x, y)
    '                x = 665.5F
    '                y = 598.5F
    '                e.Graphics.DrawString("      4、以上SPQ仅供参考，具体按实际。", drawFont, drawBrush, x, y)
    '                x = 100.5F
    '                y = 630.5F
    '                width = 990.0F
    '                height = 20.0F
    '                drawRect = New RectangleF(x, y, width, height)
    '                e.Graphics.DrawString("其他事项：" & Trim(TxtBjtk.Text), drawFont, drawBrush, drawRect)
    '                drawFont = New Font("宋体", 12)


    '                'drawFont = New Font("黑体", 15, FontStyle.Bold)
    '                'x = 100.0F
    '                'y = 990.0F
    '                'e.Graphics.DrawLine(blackPen, x, y, x + 625.0F, y)
    '                x = 100.0F
    '                y = 680.0F
    '                e.Graphics.DrawString("公司地址：浙江省东阳市横店工业区", drawFont, drawBrush, x, y)
    '                x = 100.0F
    '                y = 700.0F
    '                e.Graphics.DrawString("电话：0086-579-86588318", drawFont, drawBrush, x, y)
    '                x = 100.0F
    '                y = 720.0F
    '                e.Graphics.DrawString("传真：0086-579-86550621", drawFont, drawBrush, x, y)
    '                x = 100.0F
    '                y = 740.0F
    '                e.Graphics.DrawString("E-mail：sales@dmegc.com.cn", drawFont, drawBrush, x, y)

    '                '客户签章:
    '                drawFont = New Font("黑体", 16, FontStyle.Bold)
    '                x = 700.0F
    '                y = 710.0F
    '                e.Graphics.DrawString("软磁事业本部", drawFont, drawBrush, x, y)
    '                x = 730.0F
    '                y = 740.0F
    '                e.Graphics.DrawString("副总经理", drawFont, drawBrush, x, y)
    '                imageFile = Image.FromFile("reports\qm.bmp")
    '                ' Draw image to screen.
    '                e.Graphics.DrawImage(imageFile, New PointF(860.0F, 680.0F))

    '                'x = 800.0F
    '                'y = 710.0F
    '                'e.Graphics.DrawString("客户确", drawFont, drawBrush, x, y)
    '                'x = 800.0F
    '                'y = 740.0F
    '                'e.Graphics.DrawString("认反馈____________", drawFont, drawBrush, x, y)
    '            Else
    '                '英文格式
    '                Dim i As Integer
    '                ' Create image.
    '                Dim imageFile As Image = Image.FromFile("reports\logo.bmp")
    '                ' Draw image to screen.
    '                e.Graphics.DrawImage(imageFile, New PointF(50.0F, 30.0F))
    '                ' Create font and brush.
    '                Dim drawFont As New Font("宋体", 18)
    '                Dim drawBrush As New SolidBrush(Color.Black)
    '                ' Create point for upper-left corner of drawing.
    '                Dim x As Single = 150.0F
    '                Dim y As Single = 85.0F
    '                Dim width As Single = 307.0F
    '                Dim height As Single = 31.5F
    '                Dim drawRect As New RectangleF
    '                ' Create pen.
    '                Dim blackPen As New Pen(Color.Black, 1)
    '                ' Draw string to screen.
    '                e.Graphics.DrawString("横店集团东磁股份有限公司", drawFont, drawBrush, x, y)
    '                drawFont = New Font("Arial", 12, FontStyle.Bold)
    '                x = 50.0F
    '                y = 110.0F
    '                e.Graphics.DrawString("HENGDIAN GROUP DMEGC MAGNETICS CO。，LTD", drawFont, drawBrush, x, y)
    '                ' Create location and size of rectangle.
    '                x = 50.0F
    '                y = 135.0F
    '                e.Graphics.DrawLine(blackPen, x, y, x + 675.0F, y)
    '                x = 50.0F
    '                y = 110.0F + 25.0F
    '                e.Graphics.DrawString("Addr:7F Hengdian Dmegc Mansion,Dongyang City,Zhejiang Province China", drawFont, drawBrush, x, y)
    '                x = 50.0F
    '                y = 110.0F + 25.0F + 25.0F
    '                e.Graphics.DrawString("Tel: 0579-86551200   Fax:0579-86550621   Cp:13605721968", drawFont, drawBrush, x, y)
    '                x = 50.0F
    '                y = 110.0F + 25.0F + 25.0F + 25.0F
    '                e.Graphics.DrawString("E-mail: wang_zhengtang@dmegc.com.cn      Post code:322118", drawFont, drawBrush, x, y)
    '                '报价单
    '                drawFont = New Font("黑体", 20, FontStyle.Bold)
    '                x = 350.0F
    '                y = 208.0F
    '                e.Graphics.DrawString("Quotation", drawFont, drawBrush, x, y)
    '                drawFont = New Font("Arial", 12, FontStyle.Bold)
    '                x = 50.0F
    '                y = 243.0F
    '                e.Graphics.DrawString("Quotation No:" & Trim(Me.TxtDjh.Text), drawFont, drawBrush, x, y)
    '                x = 450.0F
    '                y = 243.0F
    '                e.Graphics.DrawString("Date:" & Me.DtpBjrq.Value.ToShortDateString, drawFont, drawBrush, x, y)
    '                x = 50.0F
    '                y = 268.0F
    '                e.Graphics.DrawString("Company:" & Trim(LblKhmc.Text), drawFont, drawBrush, x, y) ' Falco electronics(Xiamen) Co., Ltd
    '                x = 50.0F
    '                y = 293.0F
    '                e.Graphics.DrawString("Attn:" & IIf(rcDataset.Tables("rc_khxx").Rows(0).Item("lxr").GetType.ToString <> "System.DBNull", Trim(rcDataset.Tables("rc_khxx").Rows(0).Item("lxr")), ""), drawFont, drawBrush, x, y) ' Steven Liu/Allen Chen
    '                For i = 0 To 8
    '                    If i = 0 Then
    '                        height = 90.0F
    '                    Else
    '                        height = 45.0F
    '                    End If
    '                    x = 50.0F
    '                    y = 350.0F + height * IIf(i = 0, 0, i + 1)
    '                    width = 20.0F
    '                    'No
    '                    e.Graphics.DrawRectangle(blackPen, x, y, width, height)
    '                    x = x + width
    '                    width = 100.0F
    '                    'Description
    '                    e.Graphics.DrawRectangle(blackPen, x, y, width, height)
    '                    x = x + width
    '                    width = 150.0F
    '                    'FSN
    '                    e.Graphics.DrawRectangle(blackPen, x, y, width, height)
    '                    x = x + width
    '                    width = 150.0F
    '                    'VPN
    '                    e.Graphics.DrawRectangle(blackPen, x, y, width, height)
    '                    'x = x + width
    '                    'width = 50.0F
    '                    ''ORIGIN原产地
    '                    'e.Graphics.DrawRectangle(blackPen, x, y, width, height)
    '                    x = x + width
    '                    width = 30.0F
    '                    'UoM
    '                    e.Graphics.DrawRectangle(blackPen, x, y, width, height)
    '                    x = x + width
    '                    width = 30.0F
    '                    'FCY
    '                    e.Graphics.DrawRectangle(blackPen, x, y, width, height)
    '                    x = x + width
    '                    width = 50.0F
    '                    'Price
    '                    e.Graphics.DrawRectangle(blackPen, x, y, width, height)
    '                    x = x + width
    '                    width = 50.0F
    '                    'Standard or Customer Item(S/C)
    '                    e.Graphics.DrawRectangle(blackPen, x, y, width, height)
    '                    x = x + width
    '                    width = 50.0F
    '                    'Remarks
    '                    e.Graphics.DrawRectangle(blackPen, x, y, width, height)
    '                    x = x + width
    '                    width = 50.0F
    '                    'N.W
    '                    e.Graphics.DrawRectangle(blackPen, x, y, width, height)
    '                    x = x + width
    '                    width = 50.0F
    '                    'SPQ
    '                    e.Graphics.DrawRectangle(blackPen, x, y, width, height)
    '                Next
    '                drawFont = New Font("Arial", 9)
    '                height = 90.0F
    '                'No.
    '                x = 50.0F
    '                y = 365.0F
    '                e.Graphics.DrawString("No.", drawFont, drawBrush, x, y)
    '                'Description
    '                x = 70.0F
    '                y = 365.0F
    '                width = 100.0F
    '                drawRect = New RectangleF(x, y, width, height)
    '                e.Graphics.DrawString("Description", drawFont, drawBrush, drawRect)
    '                'FSN
    '                x = 170.0F
    '                y = 365.0F
    '                e.Graphics.DrawString("FSN", drawFont, drawBrush, x, y)
    '                'VPN
    '                x = 320.0F
    '                y = 365.0F
    '                e.Graphics.DrawString("VPN", drawFont, drawBrush, x, y)
    '                ''ORIGIN
    '                'x = 370.0F
    '                'y = 365.0F
    '                'e.Graphics.DrawString("Origin", drawFont, drawBrush, x, y)
    '                'UoM
    '                x = 470.0F
    '                y = 365.0F
    '                e.Graphics.DrawString("UoM", drawFont, drawBrush, x, y)
    '                'FCY
    '                x = 500.0F
    '                y = 365.0F
    '                e.Graphics.DrawString("FCY", drawFont, drawBrush, x, y)
    '                'Price
    '                x = 530.0F
    '                y = 365.0F
    '                e.Graphics.DrawString("Price", drawFont, drawBrush, x, y)
    '                'Standard or Customer Item(S/C)
    '                x = 580.0F
    '                y = 365.0F
    '                width = 50.0F
    '                drawRect = New RectangleF(x, y, width, height)
    '                e.Graphics.DrawString("Standard/Customized", drawFont, drawBrush, drawRect)
    '                'Remarks
    '                x = 630.0F
    '                y = 365.0F
    '                width = 50.0F
    '                drawRect = New RectangleF(x, y, width, height)
    '                e.Graphics.DrawString("Remarks", drawFont, drawBrush, drawRect)
    '                'N.W
    '                x = 680.0F
    '                y = 365.0F
    '                e.Graphics.DrawString("N.W", drawFont, drawBrush, x, y)
    '                'SPQ
    '                x = 730.0F
    '                y = 365.0F
    '                e.Graphics.DrawString("SPQ", drawFont, drawBrush, x, y)
    '                height = 45.0F
    '                For i = 0 To rcDataset.Tables("rc_bjdnr").Rows.Count - 1
    '                    'No.
    '                    x = 50.5F
    '                    y = 397.0F + (i + 1) * height
    '                    width = 150.0F
    '                    drawRect = New RectangleF(x, y, width, height)
    '                    e.Graphics.DrawString(Trim(Str(i + 1)), drawFont, drawBrush, drawRect)
    '                    'Description产品描述
    '                    x = 70.5F
    '                    y = 397.0F + (i + 1) * height
    '                    width = 100.0F
    '                    drawRect = New RectangleF(x, y, width, height)
    '                    e.Graphics.DrawString("", drawFont, drawBrush, drawRect)
    '                    'FSN客户料号
    '                    x = 170.5F
    '                    y = 397.0F + (i + 1) * height
    '                    width = 150.0F
    '                    drawRect = New RectangleF(x, y, width, height)
    '                    e.Graphics.DrawString(Trim(rcDataset.Tables("rc_bjdnr").Rows(i + currentPage * 8 - 8).Item("khlh")) & "  " & Trim(rcDataset.Tables("rc_bjdnr").Rows(i + currentPage * 8 - 8).Item("khcz")), drawFont, drawBrush, drawRect)
    '                    'VPN东磁型号
    '                    x = 320.5F
    '                    y = 397.0F + (i + 1) * height
    '                    width = 150.0F
    '                    drawRect = New RectangleF(x, y, width, height)
    '                    'e.Graphics.DrawString(Trim(rcDataset.Tables("rc_bjdnr").Rows(i + currentPage * 8 - 8).Item("cpmc")) & "  " & Trim(rcDataset.Tables("rc_bjdnr").Rows(i + currentPage * 8 - 8).Item("cpgg")), drawFont, drawBrush, drawRect)
    '                    e.Graphics.DrawString(Trim(rcDataset.Tables("rc_bjdnr").Rows(i + currentPage * 8 - 8).Item("cpmc")) & IIf(Trim(rcDataset.Tables("rc_bjdnr").Rows(i + currentPage * 8 - 8).Item("cpgg")).Length > 0, "  " & Trim(rcDataset.Tables("rc_bjdnr").Rows(i + currentPage * 8 - 8).Item("cpgg")), "") & IIf(Trim(rcDataset.Tables("rc_bjdnr").Rows(i + currentPage * 8 - 8).Item("dw")).Length > 0, "  " & Trim(rcDataset.Tables("rc_bjdnr").Rows(i + currentPage * 8 - 8).Item("dw")), ""), drawFont, drawBrush, drawRect)
    '                    'UoM单位
    '                    x = 470.5F
    '                    y = 397.0F + (i + 1) * height
    '                    width = 30.0F
    '                    drawRect = New RectangleF(x, y, width, height)
    '                    e.Graphics.DrawString(Trim(rcDataset.Tables("rc_bjdnr").Rows(i + currentPage * 8 - 8).Item("dw")), drawFont, drawBrush, drawRect)
    '                    'FCY币种
    '                    x = 500.5F
    '                    y = 410.0F + (i + 1) * height
    '                    e.Graphics.DrawString(Trim(rcDataset.Tables("rc_bjdnr").Rows(i + currentPage * 8 - 8).Item("wbdm")), drawFont, drawBrush, x, y)
    '                    'Price不含税单价
    '                    x = 530.5F
    '                    y = 410.0F + (i + 1) * height
    '                    e.Graphics.DrawString(Format(rcDataset.Tables("rc_bjdnr").Rows(i + currentPage * 8 - 8).Item("dj"), IIf(rcDataset.Tables("rc_bjdnr").Rows(i + currentPage * 8 - 8).Item("dj") >= 10, "0.00;;#.#", "0.00000;;#.#")), drawFont, drawBrush, x, y)
    '                    'Standard or Customer Item(S/C)

    '                    'S/C
    '                    x = 580.5F
    '                    y = 410.0F + (i + 1) * height
    '                    width = 50.0F
    '                    drawRect = New RectangleF(x, y, width, height)
    '                    e.Graphics.DrawString(Trim(rcDataset.Tables("rc_bjdnr").Rows(i + currentPage * 8 - 8).Item("khcz")), drawFont, drawBrush, drawRect)
    '                    'remarks
    '                    x = 630.5F
    '                    y = 410.0F + (i + 1) * height
    '                    drawRect = New RectangleF(x, y, width, height)
    '                    e.Graphics.DrawString(Trim(rcDataset.Tables("rc_bjdnr").Rows(i + currentPage * 8 - 8).Item("bjmemo")), drawFont, drawBrush, drawRect)
    '                    'N.W 克重
    '                    x = 680.5F
    '                    y = 410.0F + (i + 1) * height
    '                    e.Graphics.DrawString(Format(rcDataset.Tables("rc_bjdnr").Rows(i + currentPage * 8 - 8).Item("zl"), IIf(rcDataset.Tables("rc_bjdnr").Rows(i + currentPage * 8 - 8).Item("zl") >= 10, "0.00;;#.#", "0.0000;;#.#")), drawFont, drawBrush, x, y)
    '                    'SPQ包装数量

    '                Next
    '                '备注内容
    '                x = 50.5F
    '                y = 815.0F
    '                If blnHs Then
    '                    e.Graphics.DrawString("Note: All the above price include the 17% VAT.", drawFont, drawBrush, x, y)
    '                Else
    '                    e.Graphics.DrawString("Note: All the above price do not include the 17% VAT.", drawFont, drawBrush, x, y)
    '                End If
    '                y = 835.0F
    '                e.Graphics.DrawString("Origin:DMEGC China", drawFont, drawBrush, x, y)
    '                y = 855.0F
    '                e.Graphics.DrawString("Payment Term: N60E", drawFont, drawBrush, x, y)
    '                y = 875.0F
    '                e.Graphics.DrawString("Trade Term: DDP FEX", drawFont, drawBrush, x, y)
    '                y = 895.0F
    '                e.Graphics.DrawString("Remarks:" & Trim(Me.TxtBjtk.Text), drawFont, drawBrush, x, y)
    '                y = 915.0F
    '                e.Graphics.DrawString("Cancellation Term: 3 weeks before confirmed ship date.(un-cancellable for Customer Item)", drawFont, drawBrush, x, y)
    '                x = 50.5F
    '                y = 935.0F
    '                e.Graphics.DrawString("Manufacturing L/T: In 2-3 weeks from we confirm the order.", drawFont, drawBrush, x, y)
    '                x = 50.0F
    '                y = 955.0F
    '                e.Graphics.DrawString("Status of seller: Manufacture Ltd company", drawFont, drawBrush, x, y)
    '                x = 50.0F
    '                y = 975.0F
    '                e.Graphics.DrawString("Metal Base Price: N/A", drawFont, drawBrush, x, y)
    '                x = 50.0F
    '                y = 995.0F
    '                e.Graphics.DrawString("Validity: The quotation will be valid within 6month unless special request.", drawFont, drawBrush, x, y)
    '                y = 1015.0F
    '                e.Graphics.DrawString("Thank you!", drawFont, drawBrush, x, y)
    '                y = 1040.0F
    '                e.Graphics.DrawString("V.P. of DMEGC", drawFont, drawBrush, x, y)
    '                imageFile = Image.FromFile("reports\qm.bmp")
    '                ' Draw image to screen.
    '                e.Graphics.DrawImage(imageFile, New PointF(560.0F, 950.0F))
    '            End If
    '            'MsgBox(countPage.ToString & currentPage.ToString)
    '            If currentPage < countPage Then
    '                e.HasMorePages = True

    '            Else
    '                e.HasMorePages = False
    '            End If
    '        Next

    '    End Sub

    '    '' The Click event is raised when the user clicks the Print button.
    '    'Private Sub printButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles printButton.Click
    '    '    Try
    '    '        streamToPrint = New StreamReader("C:\My Documents\MyFile.txt")
    '    '        Try
    '    '            printFont = New Font("Arial", 10)
    '    '            Dim pd As New PrintDocument()
    '    '            AddHandler pd.PrintPage, AddressOf Me.pd_PrintPage
    '    '            pd.Print()
    '    '        Finally
    '    '            streamToPrint.Close()
    '    '        End Try
    '    '    Catch ex As Exception
    '    '        MessageBox.Show(ex.Message)
    '    '    End Try
    '    'End Sub

    '    ' The PrintPage event is raised for each page to be printed.
    '    'Private Sub pd_PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
    '    '    Dim linesPerPage As Single = 0
    '    '    Dim yPos As Single = 0
    '    '    Dim count As Integer = 0
    '    '    Dim leftMargin As Single = ev.MarginBounds.Left
    '    '    Dim topMargin As Single = ev.MarginBounds.Top
    '    '    Dim line As String = Nothing

    '    '    ' Calculate the number of lines per page.
    '    '    linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics)

    '    '    ' Print each line of the file.
    '    '    While count < linesPerPage
    '    '        line = streamToPrint.ReadLine()
    '    '        If line Is Nothing Then
    '    '            Exit While
    '    '        End If
    '    '        yPos = topMargin + count * printFont.GetHeight(ev.Graphics)
    '    '        ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, New StringFormat())
    '    '        count += 1
    '    '    End While

    '    '    ' If more lines exist, print another page.
    '    '    If (line IsNot Nothing) Then
    '    '        ev.HasMorePages = True
    '    '    Else
    '    '        ev.HasMorePages = False
    '    '    End If
    '    'End Sub


    '#End Region

#Region "另存为"

    Private Sub BtnSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveAs.Click
        '调用表单
        Dim rcFrm As New FrmOeBjdSaveAs
        With rcFrm
            If .ShowDialog() = DialogResult.OK Then
                Dim strPath As String = .TxtFolderName.Text
                GeneratePdfFile()
                If System.IO.File.Exists(Application.StartupPath & "\quotation.pdf") Then
                    System.IO.File.Copy(Application.StartupPath & "\quotation.pdf", strPath & "\quotation.pdf", True)
                    MsgBox("已保存。")
                End If
            End If
        End With
    End Sub

#End Region

#Region "发送邮件"

    Private Function GeneratePdfFile() As Boolean

        'Dim rcDocument As New iTextSharp.text.Document
        'Dim s As String
        's = Application.StartupPath & "\quotation.pdf"
        'If IO.File.Exists(s) Then
        '    IO.File.Delete(s)
        'End If
        'Dim fs As IO.FileStream
        'fs = New IO.FileStream(s, IO.FileMode.CreateNew)
        'Dim rcWriter As iTextSharp.text.pdf.PdfWriter
        'rcWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(rcDocument, fs)
        ''打开目标文档对象
        'Dim baseFont As iTextSharp.text.pdf.BaseFont = iTextSharp.text.pdf.BaseFont.CreateFont("宋体", iTextSharp.text.pdf.BaseFont.IDENTITY_H, iTextSharp.text.pdf.BaseFont.EMBEDDED)
        ''要设置字体和大小
        'Dim p As New iTextSharp.text.Paragraph("软磁部", New Font(baseFont, 13))
        'Dim cell As New iTextSharp.text.pdf.PdfPCell(p)
        ''设置cell属性
        'cell.Border = iTextSharp.text.Rectangle.NO_BORDER
        'table.addcell(cell)

        Dim baseFont As iTextSharp.text.pdf.BaseFont = iTextSharp.text.pdf.BaseFont.CreateFont("C:\\WINDOWS\\FONTS\\STSONG.TTF", iTextSharp.text.pdf.BaseFont.IDENTITY_H, iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED)
        Dim drawBigFont As New iTextSharp.text.Font(baseFont, 18)
        Dim drawFont As New iTextSharp.text.Font(baseFont, 12)
        Dim drawSmallFont As New iTextSharp.text.Font(baseFont, 9)
        Dim doc As New iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 20, 20, 40, 40)
        Try
            iTextSharp.text.pdf.PdfWriter.GetInstance(doc, New FileStream("quotation.pdf", FileMode.Create))
            doc.Open()
            '公司logo
            Dim imgLogo As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(Application.StartupPath + IIf(Me.CmbPzlxjc.SelectedValue = "BJDJ", "\reports\logo.jpg", "\reports\logo_jc.jpg"))
            Dim imgQm As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(Application.StartupPath + IIf(Me.CmbPzlxjc.SelectedValue = "BJDJ", "\reports\qm.bmp", "\reports\qm_jc.png"))
            Dim imgLine As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(Application.StartupPath + "\reports\line.jpg")

            'img.SetAbsolutePosition(20, 20) '(iTextSharp.text.PageSize.POSTCARD.Width - img.ScaledWidth) / 2, (iTextSharp.text.PageSize.POSTCARD.Height - img.ScaledHeight) / 2)
            'doc.Add(img)
            imgLogo.ScalePercent(30)
            imgQm.ScalePercent(85)


            Dim aTable As New iTextSharp.text.pdf.PdfPTable(4)
            Dim aHeaderWidths As Single() = {20, 56, 8, 16}
            aTable.SetWidths(aHeaderWidths)
            Dim aCell1 As New iTextSharp.text.pdf.PdfPCell()
            aCell1.AddElement(imgLogo)
            aCell1.Border = iTextSharp.text.Rectangle.NO_BORDER ' Or iTextSharp.text.Rectangle.LEFT_BORDER Or iTextSharp.text.Rectangle.RIGHT_BORDER Or iTextSharp.text.Rectangle.BOTTOM_BORDER
            aCell1.Rowspan = (4)
            aTable.AddCell(aCell1)

            Dim aCell2 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(IIf(Me.CmbPzlxjc.SelectedValue = "BJDJ", "横店集团东磁股份有限公司", "宜宾金川电子有限责任公司"), drawBigFont)) With {
                .Border = iTextSharp.text.Rectangle.NO_BORDER,
                .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            }
            aTable.AddCell(aCell2)

            '报价单号
            Dim aCell6 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("", drawSmallFont)) With {
                .Border = iTextSharp.text.Rectangle.NO_BORDER,
                .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                .Rowspan = (2),
                .Colspan = (2)
            }
            aTable.AddCell(aCell6)

            Dim aCell3 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(IIf(Me.CmbPzlxjc.SelectedValue = "BJDJ", "HengDian Group DMEGC Magnetics Co.,Ltd", "Yibin Jinchuan Electronics Co., Ltd"), drawFont)) With {
                .Border = iTextSharp.text.Rectangle.NO_BORDER,
                .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            }
            aTable.AddCell(aCell3)

            Dim aCell4 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(IIf(Me.CmbPzlxjc.SelectedValue = "BJDJ", "软磁事业本部报价单", "报  价  单"), drawBigFont)) With {
                .Border = iTextSharp.text.Rectangle.NO_BORDER,
                .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
            }
            aTable.AddCell(aCell4)

            '报价单号
            'aCell8.Border = iTextSharp.text.Rectangle.NO_BORDER
            Dim aCell8 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("RefNO.", drawSmallFont)) With {
                .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
            }
            'aCell8.Rowspan = (2)
            aTable.AddCell(aCell8)

            '报价单号
            'aCell10.Border = iTextSharp.text.Rectangle.NO_BORDER
            Dim aCell10 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(Me.TxtDjh.Text, drawSmallFont)) With {
                .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
            }
            'aCell10.Rowspan = (2)
            aTable.AddCell(aCell10)

            Dim aCell5 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(IIf(Me.CmbPzlxjc.SelectedValue = "BJDJ", "Soft Ferrite Division Quotation", "Quotation"), drawFont)) With {
                .Border = iTextSharp.text.Rectangle.NO_BORDER,
                .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
            }
            aTable.AddCell(aCell5)

            'aCell7.Border = iTextSharp.text.Rectangle.NO_BORDER
            Dim aCell7 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("DATE:", drawSmallFont)) With {
                .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
            }
            'aCell7.Rowspan = (2)
            aTable.AddCell(aCell7)

            '报价日期
            'aCell9.Border = iTextSharp.text.Rectangle.NO_BORDER
            Dim aCell9 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(Me.DtpBjrq.Value.ToShortDateString, drawSmallFont)) With {
                .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
            }
            'aCell9.Rowspan = (2)
            aTable.AddCell(aCell9)

            doc.Add(aTable)
            '
            Dim bTable As New iTextSharp.text.pdf.PdfPTable(1)
            Dim bHeaderWidths As Single() = {100}
            bTable.SetWidths(bHeaderWidths)

            Dim cell1 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("---------------------------------------------------------------------------------------------------------------------", drawFont))
            'cell1.BackgroundColor = iTextSharp.text.BaseColor.BLACK
            cell1.AddElement(imgLine)
            cell1.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
            cell1.Border = iTextSharp.text.Rectangle.NO_BORDER
            bTable.AddCell(cell1)
            Dim cell2 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("To：" & Me.LblKhmc.Text, drawFont)) With {
                .Border = iTextSharp.text.Rectangle.NO_BORDER,
                .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
            }
            bTable.AddCell(cell2)
            Dim cell4 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("Address：" & strAddress, drawFont)) With {
                .Border = iTextSharp.text.Rectangle.NO_BORDER,
                .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
            }
            bTable.AddCell(cell4)
            Dim cell3 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("Attn:" & strLxr, drawFont)) With {
                .Border = iTextSharp.text.Rectangle.NO_BORDER,
                .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
            }
            bTable.AddCell(cell3)
            Dim cell5 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("Remarks：" & Me.TxtBjtk.Text, drawFont)) With {
                .Border = iTextSharp.text.Rectangle.NO_BORDER,
                .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
            }
            bTable.AddCell(cell5)
            Dim cell6 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(" ", drawFont)) With {
                .Border = iTextSharp.text.Rectangle.NO_BORDER,
                .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
            }
            bTable.AddCell(cell6)
            Dim cell7 As New iTextSharp.text.pdf.PdfPCell()
            'cell7.AddElement(New iTextSharp.text.Phrase("REF NO：" & Trim(Me.TxtDjh.Text), drawFont))
            'bTable.AddCell(cell7)
            doc.Add(bTable)
            '
            Dim cTable As New iTextSharp.text.pdf.PdfPTable(8)

            Dim cHeaderWidths As Single() = {20, 20, 5.5, 6, 10.5, 6.5, 6.5, 18}
            cTable.SetWidths(cHeaderWidths)
            'cTable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            'cTable.DefaultCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
            'cTable.DefaultCell.PaddingLeft = 4
            'cTable.DefaultCell.PaddingTop = 0
            'cTable.DefaultCell.PaddingBottom = 4
            For i As Integer = 0 To rcDataset.Tables("rc_bjdnr").Rows.Count
                If i = 0 Then
                    '报价单标题
                    '客户料号
                    Dim caTable As New iTextSharp.text.pdf.PdfPTable(1) With {
                        .PaddingTop = 0
                    }
                    Dim cellaa As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("Customer P/N", drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                        .Border = iTextSharp.text.Rectangle.NO_BORDER
                    }
                    caTable.AddCell(cellaa)
                    Dim cellab As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("客户料号", drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                        .Border = iTextSharp.text.Rectangle.NO_BORDER
                    }
                    caTable.AddCell(cellab)
                    cTable.AddCell(caTable)

                    '品名规格
                    Dim cbTable As New iTextSharp.text.pdf.PdfPTable(1)
                    Dim cellba As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("Description", drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                        .Border = iTextSharp.text.Rectangle.NO_BORDER
                    }
                    Dim cellbb As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("品名/规格", drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                        .Border = iTextSharp.text.Rectangle.NO_BORDER
                    }
                    cbTable.AddCell(cellba)
                    cbTable.AddCell(cellbb)
                    cTable.AddCell(cbTable)

                    '单位
                    Dim ccTable As New iTextSharp.text.pdf.PdfPTable(1)
                    Dim cellca As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("Unit", drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                        .Border = iTextSharp.text.Rectangle.NO_BORDER
                    }
                    Dim cellcb As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("单位", drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                        .Border = iTextSharp.text.Rectangle.NO_BORDER
                    }
                    ccTable.AddCell(cellca)
                    ccTable.AddCell(cellcb)
                    cTable.AddCell(ccTable)

                    '重量
                    Dim cdTable As New iTextSharp.text.pdf.PdfPTable(1)
                    Dim cellda As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("N.W", drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                        .Border = iTextSharp.text.Rectangle.NO_BORDER
                    }
                    Dim celldb As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("重量", drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                        .Border = iTextSharp.text.Rectangle.NO_BORDER
                    }
                    cdTable.AddCell(cellda)
                    cdTable.AddCell(celldb)
                    cTable.AddCell(cdTable)

                    '单价
                    Dim ceTable As New iTextSharp.text.pdf.PdfPTable(1)
                    Dim cellea As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("Unit Price", drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                        .Border = iTextSharp.text.Rectangle.NO_BORDER
                    }
                    Dim celleb As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("单价", drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                        .Border = iTextSharp.text.Rectangle.NO_BORDER
                    }
                    ceTable.AddCell(cellea)
                    ceTable.AddCell(celleb)
                    cTable.AddCell(ceTable)

                    'SPQ
                    Dim cfTable As New iTextSharp.text.pdf.PdfPTable(1)
                    Dim cellfa As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("SPQ", drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                        .Border = iTextSharp.text.Rectangle.NO_BORDER
                    }
                    'Dim cellfb As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("最小包装量", drawSmallFont))
                    'cellfb.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    'cellfb.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                    'cellfb.Border = iTextSharp.text.Rectangle.NO_BORDER
                    cfTable.AddCell(cellfa)
                    'cfTable.AddCell(cellfb)
                    cTable.AddCell(cfTable)

                    'MOQ
                    Dim cgTable As New iTextSharp.text.pdf.PdfPTable(1)
                    Dim cellga As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("MOQ", drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                        .Border = iTextSharp.text.Rectangle.NO_BORDER
                    }
                    'Dim cellgb As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("最小起订量", drawSmallFont))
                    'cellgb.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    'cellgb.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                    'cellgb.Border = iTextSharp.text.Rectangle.NO_BORDER
                    cgTable.AddCell(cellga)
                    'cgTable.AddCell(cellgb)
                    cTable.AddCell(cgTable)

                    '备注
                    Dim chTable As New iTextSharp.text.pdf.PdfPTable(1)
                    Dim cellha As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("Note", drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                        .Border = iTextSharp.text.Rectangle.NO_BORDER
                    }
                    Dim cellhb As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("备注", drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                        .Border = iTextSharp.text.Rectangle.NO_BORDER
                    }
                    chTable.AddCell(cellha)
                    chTable.AddCell(cellhb)
                    cTable.AddCell(chTable)
                Else
                    If rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("khlh").GetType.ToString = "System.DBNull" Then
                        rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("khlh") = ""
                    End If
                    If rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("khcz").GetType.ToString = "System.DBNull" Then
                        rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("khcz") = ""
                    End If
                    If rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("cpmc").GetType.ToString = "System.DBNull" Then
                        rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("cpmc") = ""
                    End If
                    If rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("cpgg").GetType.ToString = "System.DBNull" Then
                        rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("cpgg") = ""
                    End If
                    If rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("dw").GetType.ToString = "System.DBNull" Then
                        rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("dw") = ""
                    End If
                    If rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("zl").GetType.ToString = "System.DBNull" Then
                        rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("zl") = 0.0
                    End If
                    If rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("dj").GetType.ToString = "System.DBNull" Then
                        rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("dj") = 0.0
                    End If
                    If rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("spq").GetType.ToString = "System.DBNull" Then
                        rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("spq") = 0
                    End If
                    If rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("moq").GetType.ToString = "System.DBNull" Then
                        rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("moq") = 0
                    End If
                    If rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("bjmemo").GetType.ToString = "System.DBNull" Then
                        rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("bjmemo") = ""
                    End If
                    '报价单内容
                    Dim cella As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("khlh") & IIf(Not String.IsNullOrEmpty(rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("khcz")), "," & rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("khcz"), ""), drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                        .MinimumHeight = 25
                    }
                    'cella.FixedHeight = 25
                    cTable.AddCell(cella)

                    Dim cellb As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("cpmc") & IIf(Not String.IsNullOrEmpty(rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("cpgg")), "," & rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("cpgg"), ""), drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                    }
                    cTable.AddCell(cellb)

                    Dim cellc As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("dw"), drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                    }
                    cTable.AddCell(cellc)

                    Dim celld As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("zl"), drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                    }
                    cTable.AddCell(celld)

                    Dim celle As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("wbdm") & " " & rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("dj"), drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                    }
                    cTable.AddCell(celle)

                    Dim cellf As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("spq"), drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                    }
                    cTable.AddCell(cellf)

                    Dim cellg As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("moq"), drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, '水平
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE '垂直
                        }
                    cTable.AddCell(cellg)

                    Dim cellh As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("bjmemo"), drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                    }
                    cTable.AddCell(cellh)
                End If
            Next
            For i As Integer = rcDataset.Tables("rc_bjdnr").Rows.Count + 1 To 10
                '报价单空行
                Dim cella As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("", drawSmallFont)) With {
                    .HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,
                    .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                    .MinimumHeight = 25
                }
                'cella.FixedHeight = 25
                cTable.AddCell(cella)

                Dim cellb As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("", drawSmallFont)) With {
                    .HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,
                    .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                }
                cTable.AddCell(cellb)

                Dim cellc As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("", drawSmallFont)) With {
                    .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                    .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                }
                cTable.AddCell(cellc)

                Dim celld As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("", drawSmallFont)) With {
                    .HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT,
                    .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                }
                cTable.AddCell(celld)

                Dim celle As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("", drawSmallFont)) With {
                    .HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT,
                    .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                }
                cTable.AddCell(celle)

                Dim cellf As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("", drawSmallFont)) With {
                    .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                    .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                }
                cTable.AddCell(cellf)

                Dim cellg As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("", drawSmallFont)) With {
                    .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, '水平
                    .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE '垂直
                    }
                cTable.AddCell(cellg)

                Dim cellh As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("", drawSmallFont)) With {
                    .HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,
                    .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                }
                cTable.AddCell(cellh)

            Next

            doc.Add(cTable)
            '
            Dim dTable As New iTextSharp.text.pdf.PdfPTable(1)
            Dim dCell1 As New iTextSharp.text.pdf.PdfPCell()
            dCell1.AddElement(New iTextSharp.text.Phrase("备注：" & Me.TxtMemo1.Text, drawSmallFont))
            dCell1.AddElement(New iTextSharp.text.Phrase("            " & Me.TxtMemo2.Text, drawSmallFont))
            dCell1.AddElement(New iTextSharp.text.Phrase("            " & Me.TxtMemo3.Text, drawSmallFont))
            dCell1.AddElement(New iTextSharp.text.Phrase("            " & Me.TxtMemo4.Text, drawSmallFont))
            If Me.CmbPzlxjc.SelectedValue = "BJDJ" Then
                dCell1.AddElement(New iTextSharp.text.Phrase("            " & Me.TxtMemo5.Text, drawSmallFont))
            End If
            dTable.AddCell(dCell1)
            doc.Add(dTable)
            ''
            'Dim eTable As New iTextSharp.text.pdf.PdfPTable(1)
            'Dim eCell1 As New iTextSharp.text.pdf.PdfPCell()
            'eCell1.AddElement(New iTextSharp.text.Phrase("其他事项：" & Trim(Me.TxtBjtk.Text), drawFont))
            'eTable.AddCell(eCell1)
            'doc.Add(eTable)
            '
            Dim fTable As New iTextSharp.text.pdf.PdfPTable(3)
            Dim fHeaderWidths As Single() = {40, 30, 40}
            fTable.SetWidths(fHeaderWidths)
            Dim fCell1 As New iTextSharp.text.pdf.PdfPCell()
            fCell1.AddElement(New iTextSharp.text.Phrase(IIf(Me.CmbPzlxjc.SelectedValue = "BJDJ", "公司地址：浙江省东阳市横店工业区", "公司地址：四川省宜宾市临港经济技术开发区港园西路63号"), drawSmallFont))
            fCell1.AddElement(New iTextSharp.text.Phrase(IIf(Me.CmbPzlxjc.SelectedValue = "BJDJ", "电话：0086-579-86588318", "Western Section 63, Gangyuan Road, Ligang Economic & Technology Development Zone, Yibin, Sichuan, China"), drawSmallFont))
            fCell1.AddElement(New iTextSharp.text.Phrase(IIf(Me.CmbPzlxjc.SelectedValue = "BJDJ", "传真：0086-579-86550621", "传真：0086-831-3620814"), drawSmallFont))
            fCell1.AddElement(New iTextSharp.text.Phrase(IIf(Me.CmbPzlxjc.SelectedValue = "BJDJ", "E-mail：sales@dmegc.com.cn", ""), drawSmallFont))
            'fCell1.Border = iTextSharp.text.Rectangle.NO_BORDER
            fCell1.Rowspan = 2
            fTable.AddCell(fCell1)
            Dim fCell2 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(IIf(Me.CmbPzlxjc.SelectedValue = "BJDJ", "软磁事业本部", "软磁部"), drawFont)) With {
                .MinimumHeight = 40,
                .Border = iTextSharp.text.Rectangle.LEFT_BORDER,
                .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
            }
            fTable.AddCell(fCell2)

            Dim fCell4 As New iTextSharp.text.pdf.PdfPCell()
            fCell4.AddElement(imgQm)
            'fCell4.Border = iTextSharp.text.Rectangle.NO_BORDER
            fCell4.Rowspan = 2
            fTable.AddCell(fCell4)

            'fCell3.Border = iTextSharp.text.Rectangle.NO_BORDER
            Dim fCell3 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(IIf(Me.CmbPzlxjc.SelectedValue = "BJDJ", "副总经理", "部长"), drawFont)) With {
                .MinimumHeight = 40,
                .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
            }
            fTable.AddCell(fCell3)
            doc.Add(fTable)

        Catch de As iTextSharp.text.DocumentException
            MsgBox("程序错误。" + de.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
        Catch ioe As IOException
            MsgBox("程序错误。" + ioe.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
        End Try
        doc.Close()
    End Function

    Private Sub BtnToEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnToEmail.Click
        GeneratePdfFile()
        sendEmail()
        'mailList, "TEST", "TEST", AttachFile
    End Sub

    '发送电子邮件
    Function SendEmail() As Boolean
        '取发件人信息
        Dim i As Integer
        Dim strEmail As String = ""
        Dim strSmtp As String = ""
        Dim strAccount As String = ""
        Dim strPwd As String = ""
        Dim blnSfyz As Boolean = False
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT paraid,parastrvalue,paradblvalue FROM rc_para WHERE SUBSTR(paraid,1,3) = '发件人' Order by paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            rcOleDbCommand.CommandText = "SELECT rc_khxx.khdm,rc_khxx.khmc,rc_zyxx.email FROM rc_khxx LEFT JOIN rc_zyxx ON rc_zyxx.zydm = rc_khxx.zydm WHERE khdm = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKhdm.Text)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("khemail") IsNot Nothing Then
                rcDataset.Tables("khemail").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "khemail")
        Catch ex As Exception
            MsgBox("程序错误2。" & Chr(13) & ex.Message)
            Return False
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_para").Rows.Count = 5 Then
            If rcDataset.Tables("rc_para").Rows(3).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                strEmail = rcDataset.Tables("rc_para").Rows(3).Item("parastrvalue")
            End If
            If rcDataset.Tables("rc_para").Rows(2).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                strSmtp = rcDataset.Tables("rc_para").Rows(2).Item("parastrvalue")
            End If
            If rcDataset.Tables("rc_para").Rows(1).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                strAccount = rcDataset.Tables("rc_para").Rows(1).Item("parastrvalue")
            End If
            If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                strPwd = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
            End If
            If rcDataset.Tables("rc_para").Rows(4).Item("paradblvalue").GetType.ToString <> "System.DBNull" Then
                blnSfyz = rcDataset.Tables("rc_para").Rows(4).Item("paradblvalue")
            End If
        Else
            MsgBox("请检查发件人邮件参数设置。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return False
        End If
        'If rcDataset.Tables("khemail").Rows.Count = 0 Then
        '    Return False
        'Else
        '    If rcDataset.Tables("khemail").Rows(0).Item("email").GetType.ToString = "System.DBNull" Then
        '        Return False
        '    End If
        'End If
        '设置邮件内容 
        ''设置电子邮件优先级 
        Dim mail As New MailMessage With {
            .From = New MailAddress(strEmail),
            .Subject = "软磁部产品报价单",
            .Body = "您好：详细报价请查看邮件附件。",
            .Priority = MailPriority.High
        }
        ''获取与此电子邮件传输的标头 
        'mail.Headers.Add("杭州公交", "物资供应部")
        'mail.Headers.Add("位置", "杭州")
        'mail.Headers.Add("YourCompany", "yourname")
        'mail.Headers.Add("YourLocation", "yourlocation")
        Dim asd As String() = Me.TxtEmail.Text.Split(";")
        mail.To.Clear()
        'mail.To.Add(strEmail)
        'mail.To.Add(rcDataset.Tables("khemail").Rows(0).Item("email"))
        For i = 0 To asd.Length - 1
            mail.To.Add(asd(i))
        Next
        '附件文件名,用于收件人收到附件时显示的名称  
        Dim objFile As New System.Net.Mail.Attachment("quotation.pdf") With {
            .Name = "quotation.pdf"
        }
        '加入附件,可以多次添加  
        mail.Attachments.Add(objFile)
        Dim Mysmtp As New SmtpClient(strSmtp)
        If blnSfyz Then
            Mysmtp.Credentials = New System.Net.NetworkCredential(strAccount, strPwd)
        End If
        Try
            Mysmtp.Send(mail)
            MsgBox("邮件发送成功！", MsgBoxStyle.Information, "提示信息")
            mail.Attachments.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message & mail.To.ToString, MsgBoxStyle.Critical, "抱歉。邮件发送失败")
            Return False
        End Try
        Return True
        'MsgBox("邮件已经发出，邮件已经发送到指定的邮件地址.", MsgBoxStyle.Information, "提示信息")
    End Function

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

    Private Sub FrmBjdSrz_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If IsEditing Then
            MsgBox("已经编辑过数据，请保存数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            e.Cancel = True
        End If
    End Sub

#End Region
End Class