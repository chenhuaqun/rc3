Imports System.Data.OleDb
Imports System.Math
Imports System.IO

Public Class FrmInvPcSrz

    '建立OLEDB数据适配器对象
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDb传递对象
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDb命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable '我们要利用该datatable进行金额计算
    ReadOnly dtPc As New DataTable("rc_pcnr")
    '建立DataGridViewTextBoxEditingControl对象
    Dim EditingControl As DataGridViewTextBoxEditingControl
    '会计期间
    Dim strKjqj As String = g_Kjqj
    '盘存日期
    Dim datePcrq As Date = Now.Date()
    '仓库编码
    Dim strCkdm As String = ""
    '增加单据的变量
    Dim IsAdding As Boolean = False
    '修改单据的变量
    Dim IsEditing As Boolean = False
    '合计变量
    Dim dblTotSl As Double = 0.0
    Dim dblTotJcsl As Double = 0.0
    Dim dblTotJcje As Double = 0.0
    '打印文档
    Dim rcRps As RPS.Document = Nothing

#Region "初始化"

    Public Property ParaDatePcrq() As String
        Get
            ParaDatePcrq = datePcrq
        End Get
        Set(ByVal Value As String)
            datePcrq = Value
        End Set
    End Property

    Public Property ParaStrCkdm() As String
        Get
            ParaStrCkdm = strCkdm
        End Get
        Set(ByVal Value As String)
            strCkdm = Value
        End Set
    End Property

    Private Sub FrmInvPcSrz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '设置DataGridView
        Me.rcDataGridView.AutoGenerateColumns = False
        Me.rcDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColMjsl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColMjsl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColFzsl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColFzsl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColJcsl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColJcsl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColJcje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColJcje").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColCe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColCe").DefaultCellStyle.Format = g_FormatSl

        '数据绑定
        dtPc.Columns.Add("cpdm", Type.GetType("System.String"))
        dtPc.Columns.Add("cpmc", Type.GetType("System.String"))
        dtPc.Columns.Add("dw", Type.GetType("System.String"))
        dtPc.Columns.Add("sl", Type.GetType("System.Double"))
        dtPc.Columns.Add("jcsl", Type.GetType("System.Double"))
        dtPc.Columns.Add("jcje", Type.GetType("System.Double"))
        dtPc.Columns.Add("byk", Type.GetType("System.String"))
        dtPc.Columns.Add("ce", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtPc)
        With rcDataset.Tables("rc_pcnr")
            .Columns("cpdm").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("jcsl").DefaultValue = 0.0
            .Columns("jcje").DefaultValue = 0.0
            .Columns("byk").DefaultValue = "平"
            .Columns("ce").DefaultValue = 0.0
        End With
        '绑定数据the DataGrid to the DataSet.
        Me.rcBindingSource.DataSource = dtPc
        Me.rcDataGridView.DataSource = Me.rcBindingSource
        Me.DtpPcrq.Value = datePcrq
        Me.TxtCkdm.Text = strCkdm
        strKjqj = GetInvKjqj(datePcrq)
    End Sub

#End Region

#Region "设置控件"

    Private Sub SetControlEnableEvent()
        If IsEditing = True Then
            Me.BtnSave.Enabled = True
            Me.BtnCancel.Enabled = True
            Me.BtnExit.Enabled = False
            Me.MnuiNew.Enabled = False
            Me.MnuiSave.Enabled = True
            Me.MnuiCancel.Enabled = True
            Me.MnuiExit.Enabled = False
        Else
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

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpPcrq.KeyPress, TxtZydm.KeyPress, TxtCkdm.KeyPress
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
        dblTotJcsl = 0.0
        dblTotJcje = 0.0

        If dtPc.Rows.Count > 0 Then
            dblTotSl = dtPc.Compute("Sum(sl)", "")
            dblTotJcsl = dtPc.Compute("Sum(jcsl)", "")
            dblTotJcje = dtPc.Compute("Sum(jcje)", "")
        End If
        Me.LblSl.Text = "盘存数量合计：" + Format(dblTotSl, g_FormatSl)
        Me.LblJcsl.Text = "结存数量合计：" + Format(dblTotJcsl, g_FormatSl)
        Me.LblJcje.Text = "结存金额合计：" + Format(dblTotJcje, g_FormatJe)
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

#Region "DataGridView的事件"

    'Private Sub rcDataGridView_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles rcDataGridView.CellEnter
    '    If Me.rcDataGridView.CurrentCell.ReadOnly Then My.Computer.Keyboard.SendKeys("{Enter}")
    'End Sub

    Private Sub RcDataGridView_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles rcDataGridView.CellValidating
        Dim dInvBegin1 As Date = GetInvBegin(Mid(strKjqj, 1, 4), 1)
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
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue
                            rcOleDbCommand.Parameters.Add("@oldcpdm", OleDbType.VarChar, 12).Value = rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                                rcDataset.Tables("rc_cpxx").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
                            If rcDataset.Tables("rc_cpxx").Rows.Count > 0 Then
                                Me.rcDataGridView.CurrentRow.Cells("ColCpdm").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("cpdm")
                                Me.rcDataGridView.CurrentRow.Cells("ColCpmc").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("cpmc")
                                Me.rcDataGridView.CurrentRow.Cells("ColDw").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("dw")
                                rcOleDbCommand.CommandText = "SELECT bsfchz.cpdm,bsfchz.cpmc,bsfchz.dw,COALESCE(bsfchz.qcsl,0.0) + COALESCE(bsfchz.bqscrksl,0.0) + COALESCE(bsfchz.bqcgrksl,0.0) + COALESCE(bsfchz.bqdbrksl,0.0) - COALESCE(bsfchz.bqxscksl,0.0) - COALESCE(bsfchz.bqckcksl,0.0) - COALESCE(bsfchz.bqdbcksl,0.0) as jcsl,COALESCE(bsfchz.qcje,0.0) + COALESCE(bsfchz.bqscrkje,0.0) +COALESCE(bsfchz.bqcgrkje,0.0) +COALESCE(bsfchz.bqdbrkje,0.0) - COALESCE(bsfchz.bqxsckje,0.0) - COALESCE(bsfchz.bqckckje,0.0) - COALESCE(bsfchz.bqdbckje,0.0) as jcje FROM" &
                                    " (SELECT asfchz.*,rc_cpxx.cpmc,rc_cpxx.dw,rc_cpxx.lbdm FROM" &
                                    " (SELECT cpnc.cpdm,cpnc.qcsl,cpnc.qcje,bqscrk.bqscrksl,bqscrk.bqscrkje,bqcgrk.bqcgrksl,bqcgrk.bqcgrkje,bqdbrk.bqdbrksl,bqdbrk.bqdbrkje,bqxsck.bqxscksl,bqxsck.bqxsckje,bqckck.bqckcksl,bqckck.bqckckje,bqdbck.bqdbcksl,bqdbck.bqdbckje FROM" &
                                    " (SELECT inv_cpyeb.cpdm,sum(qcsl) as qcsl,sum(qcje) as qcje FROM inv_cpyeb WHERE kjnd = ? AND inv_cpyeb.ckdm = ? GROUP BY inv_cpyeb.cpdm) cpnc" &
                                    " Left join (SELECT inv_rkd.cpdm,sum(inv_rkd.sl) as bqscrksl,sum(inv_rkd.je) as bqscrkje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND inv_rkd.rkrq >= ? and inv_rkd.rkrq >= ? and inv_rkd.rkrq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_rkd.cpdm) bqscrk ON cpnc.cpdm = bqscrk.cpdm" &
                                    " Left join (SELECT po_rkd.cpdm,sum(po_rkd.sl) as bqcgrksl,sum(po_rkd.je) as bqcgrkje FROM po_rkd WHERE po_rkd.bdelete = 0 AND po_rkd.rkrq >= ? and po_rkd.rkrq >= ? and po_rkd.rkrq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND po_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY po_rkd.cpdm) bqcgrk ON cpnc.cpdm = bqcgrk.cpdm" &
                                    " Left join (SELECT inv_dbd.cpdm,sum(inv_dbd.sl) as bqdbrksl,sum(inv_dbd.je) as bqdbrkje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.rckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_dbd.cpdm) bqdbrk ON cpnc.cpdm = bqdbrk.cpdm" &
                                    " Left join (SELECT oe_xsd.cpdm,sum(oe_xsd.sl) as bqxscksl,sum(oe_xsd.cbje) as bqxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND oe_xsd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY oe_xsd.cpdm) bqxsck ON cpnc.cpdm = bqxsck.cpdm" &
                                    " Left join (SELECT inv_ckd.cpdm,sum(inv_ckd.sl) as bqckcksl,sum(inv_ckd.je) as bqckckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND inv_ckd.ckrq >= ? and inv_ckd.ckrq >= ? and inv_ckd.ckrq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_ckd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_ckd.cpdm) bqckck ON cpnc.cpdm = bqckck.cpdm" &
                                    " Left join (SELECT inv_dbd.cpdm,sum(inv_dbd.sl) as bqdbcksl,sum(inv_dbd.je) as bqdbckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.cckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_dbd.cpdm) bqdbck ON cpnc.cpdm = bqdbck.cpdm) asfchz LEFT JOIN rc_cpxx ON asfchz.cpdm = rc_cpxx.cpdm) bsfchz WHERE cpdm = ?"
                                rcOleDbCommand.Parameters.Clear()
                                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(strKjqj, 1, 4)
                                rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Me.TxtCkdm.Text
                                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dInvBegin1
                                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = Me.DtpPcrq.Value
                                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dInvBegin1
                                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = Me.DtpPcrq.Value
                                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dInvBegin1
                                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = Me.DtpPcrq.Value
                                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dInvBegin1
                                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = Me.DtpPcrq.Value
                                rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                                rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dInvBegin1
                                rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpPcrq.Value
                                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dInvBegin1
                                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = Me.DtpPcrq.Value
                                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("cpdm")
                                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                If rcDataset.Tables("cpsfchz") IsNot Nothing Then
                                    rcDataset.Tables("cpsfchz").Clear()
                                End If
                                rcOleDbDataAdpt.Fill(rcDataset, "cpsfchz")
                                Me.rcDataGridView.CurrentRow.Cells("ColJcsl").Value = rcDataset.Tables("cpsfchz").Rows(0).Item("jcsl")
                                Me.rcDataGridView.CurrentRow.Cells("ColJcje").Value = rcDataset.Tables("cpsfchz").Rows(0).Item("jcje")

                                '取最新库存数量
                                rcOleDbCommand.CommandText = "SELECT COALESCE(Sum(qcsl+idsl),0.0) as kcsl FROM inv_cpyeb WHERE kjnd = ? AND ckdm = ? AND cpdm = ?"
                                rcOleDbCommand.Parameters.Clear()
                                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = datePcrq.Date
                                rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Me.TxtCkdm.Text
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
                            Else
                                Me.LblMsg.Text = "物料编码不存在。"
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
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColSl" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    Me.rcDataGridView.CurrentRow.Cells("ColCe").Value = e.FormattedValue - Me.rcDataGridView.CurrentRow.Cells("ColJcsl").Value
                    If Me.rcDataGridView.CurrentRow.Cells("ColCe").Value > 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColByk").Value = "盘盈"
                    Else
                        If Me.rcDataGridView.CurrentRow.Cells("ColCe").Value = 0 Then
                            Me.rcDataGridView.CurrentRow.Cells("ColByk").Value = "平"
                        Else
                            Me.rcDataGridView.CurrentRow.Cells("ColByk").Value = "盘亏"
                        End If
                    End If
                Else
                    Me.rcDataGridView.CurrentRow.Cells("ColSl").Value = 0.0
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
        If dtPc.Rows.Count > 0 Then
            IsEditing = True
            SetControlEnableEvent()
            SumSlJe()
        End If
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
            rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Trim(TxtCkdm.Text)
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
        '(1)是否有需要存储的数据
        If rcDataset.Tables("rc_pcnr").Rows.Count = 0 Then
            MsgBox("没有相应的业务，请输入。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Return
        End If
        '(2)职员编码
        If Not String.IsNullOrEmpty(Me.TxtZydm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.StoredProcedure
                rcOleDbCommand.CommandText = "USP_CHECK_CODE"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 12).Value = Trim(Me.TxtZydm.Text)
                rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_zyxx"
                rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "zydm"
                rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
                rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
                rcOleDbCommand.ExecuteNonQuery()
                If rcOleDbCommand.Parameters("@paraIntRecordCount").Value <> 1 Then
                    MsgBox("职员编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                    Return
                End If
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        End If
        '(3)物料编码
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            For i = 0 To rcDataset.Tables("rc_pcnr").Rows.Count - 1
                If rcDataset.Tables("rc_pcnr").Rows(i).RowState <> DataRowState.Deleted Then
                    rcOleDbCommand.CommandType = CommandType.Text
                    rcOleDbCommand.CommandText = "SELECT * FROM rc_cpxx WHERE cpdm = ? AND ty <> 1"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.AddWithValue("@cpdm", Trim(rcDataset.Tables("rc_pcnr").Rows(i).Item("cpdm")))
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("cpdmcnt") IsNot Nothing Then
                        Me.rcDataset.Tables("cpdmcnt").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "cpdmcnt")

                    If rcDataset.Tables("cpdmcnt").Rows.Count <> 1 Then
                        MsgBox(Trim(rcDataset.Tables("rc_pcnr").Rows(i).Item("cpdm")) & "物料编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
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
        '(二)存储
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP3_SAVE_INV_PC"
            For i = 0 To rcDataset.Tables("rc_pcnr").Rows.Count - 1
                If rcDataset.Tables("rc_pcnr").Rows(i).Item("byk") <> "平" Then
                    rcOleDbCommand.Parameters.Clear()
                    'rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = IIf(IsAdding, 1, 0)
                    rcOleDbCommand.Parameters.Add("@paraDateRkrq", OleDbType.Date, 8).Value = Me.DtpPcrq.Value
                    rcOleDbCommand.Parameters.Add("@ParaStrCkdm", OleDbType.VarChar, 12).Value = Me.TxtCkdm.Text
                    rcOleDbCommand.Parameters.Add("@paraStrCkmc", OleDbType.VarChar, 30).Value = Me.LblCkmc.Text
                    rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = i + 1
                    rcOleDbCommand.Parameters.Add("@paraStrZydm", OleDbType.VarChar, 12).Value = Me.TxtZydm.Text
                    rcOleDbCommand.Parameters.Add("@paraStrZymc", OleDbType.VarChar, 30).Value = Me.LblZymc.Text
                    rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("rc_pcnr").Rows(i).Item("cpdm")).ToUpper
                    rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("rc_pcnr").Rows(i).Item("cpmc")
                    rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = rcDataset.Tables("rc_pcnr").Rows(i).Item("dw")
                    rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_pcnr").Rows(i).Item("sl")
                    rcOleDbCommand.Parameters.Add("@paraDblJcsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_pcnr").Rows(i).Item("jcsl")
                    rcOleDbCommand.Parameters.Add("@paraDblJcje", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_pcnr").Rows(i).Item("jcje")
                    rcOleDbCommand.Parameters.Add("@paraBlnByk", OleDbType.Numeric, 1).Value = IIf(rcDataset.Tables("rc_pcnr").Rows(i).Item("byk") = "盘盈", 1, 0)
                    rcOleDbCommand.Parameters.Add("@paraDblCe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_pcnr").Rows(i).Item("ce")
                    rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                    rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                    rcOleDbCommand.ExecuteNonQuery()
                    If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                        If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                            MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                            Return
                        End If
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
        '控件设置
        SetControlEnableEvent()
        '设置焦点
        'Me.TxtDjh.Focus()
    End Sub

#End Region

#Region "取消修改事件"

    Private Sub BtnCancelEvent(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click, MnuiCancel.Click
        If MsgBox("是否放弃所做的修改？", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "提示信息") = MsgBoxResult.Yes Then
            IsAdding = False
            IsEditing = False
            SetControlEnableEvent()
            'Me.TxtDjh.Focus()
        End If
    End Sub

#End Region

#Region "插入DataGridView行事件"

    Private Sub BtnIns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIns.Click, MnuiIns.Click
        If Me.rcDataGridView.ReadOnly = False Then
            If dtPc.Rows.Count > 0 Then
                Dim row As DataRow = dtPc.NewRow
                dtPc.Rows.InsertAt(row, rcDataGridView.CurrentCell.RowIndex)
                dtPc.AcceptChanges()
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
            If dtPc.Rows.Count > 0 Then
                dtPc.Rows(rcDataGridView.CurrentRow.Index).Delete()
                dtPc.AcceptChanges()
                IsEditing = True
                SetControlEnableEvent()
            End If
        End If
        'If Me.rcDataGridView.ReadOnly = False Then
        '    If Me.rcBindingSource.Count > 0 Then
        '        'MsgBox(dtPc.Rows.Count.ToString)
        '        'MsgBox(rcDataGridView.CurrentRow.Index.ToString)
        '        'Me.rcBindingSource.RemoveCurrent()
        '        'Me.rcDataGridView.Refresh()
        '        'rcDataGridView.Rows.Remove(rcDataGridView.CurrentRow)
        '        dtPc.Rows.RemoveAt(rcDataGridView.CurrentRow.Index)
        '        dtPc.AcceptChanges()
        '        IsEditing = True
        '        SetControlEnableEvent()
        '    End If
        'End If
    End Sub
#End Region

#Region "打印设置、打印、打印预览事件"

    Private Sub PageSetupEvent()
        Dim rcFrmPageSetup As New models.FrmPageSetup
        With rcFrmPageSetup
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = "PCBBZ"
            .paraRpsName = "盘存表标准格式"
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
        Dim rft As String = Application.StartupPath + "\reports\rkdbz.rft"
        rcRps.LoadTemplate(rft)
        '取RPS打印参数
        rcOleDbConn.Open()
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps WHERE rpsid = 'PCBBZ'"
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
        rcRps.Text(-1, 1) = g_PrnDwmc & "物料盘存表"
        'rcRps.Text(-1, 2) = "单据号：" & Trim(Me.TxtDjh.Text) & "  %p/%t"
        'rcRps.Text(-1, 3) = "供应商：(" & Trim(Me.TxtKhdm.Text) & ")" & Trim(Me.LblKhmc.Text)
        rcRps.Text(-1, 4) = "库存地点：(" & Trim(Me.TxtCkdm.Text) & ")" & Trim(LblCkmc.Text)
        rcRps.Text(-1, 5) = "日期：" & DtpPcrq.Value.Date.ToLongDateString
        rcRps.Text(-1, 22) = "工资"
        Dim i As Integer
        Dim j As Integer
        Dim intPage As Integer
        Dim dblTotalSl As Double = 0.0
        Dim dblTotalJe As Double = 0.0
        For intPage = 1 To System.Math.Ceiling(rcDataSet.Tables("rc_pcnr").Rows.Count / rcRps.LinesPerPage.ToString)
            For i = (intPage - 1) * rcRps.LinesPerPage.ToString To System.Math.Min(intPage * rcRps.LinesPerPage.ToString - 1, rcDataSet.Tables("rc_pcnr").Rows.Count - 1)
                If rcDataSet.Tables("rc_pcnr").Rows(i).RowState <> 8 Then
                    If Not rcDataSet.Tables("rc_pcnr").Rows(i).Item("cpdm").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 1) = Trim(rcDataSet.Tables("rc_pcnr").Rows(i).Item("cpdm"))
                    End If
                    If Not rcDataSet.Tables("rc_pcnr").Rows(i).Item("cpmc").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 2) = Trim(rcDataSet.Tables("rc_pcnr").Rows(i).Item("cpmc"))
                    End If
                    If Not rcDataSet.Tables("rc_pcnr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 4) = Trim(rcDataSet.Tables("rc_pcnr").Rows(i).Item("dw"))
                    End If
                    If Not rcDataSet.Tables("rc_pcnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 5) = Format(rcDataSet.Tables("rc_pcnr").Rows(i).Item("sl"), g_FormatSl)
                        dblTotalSl += rcDataSet.Tables("rc_pcnr").Rows(i).Item("sl")
                    End If
                    If Not rcDataSet.Tables("rc_pcnr").Rows(i).Item("jcsl").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 6) = Format(rcDataSet.Tables("rc_pcnr").Rows(i).Item("jcsl"), g_FormatDj)
                    End If
                    If Not rcDataSet.Tables("rc_pcnr").Rows(i).Item("jcje").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 7) = Format(rcDataSet.Tables("rc_pcnr").Rows(i).Item("jcje"), g_FormatJe)
                        dblTotalJe += rcDataSet.Tables("rc_pcnr").Rows(i).Item("jcje")
                    End If
                    If Not rcDataSet.Tables("rc_pcnr").Rows(i).Item("rkmemo").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 8) = Trim(rcDataSet.Tables("rc_pcnr").Rows(i).Item("rkmemo"))
                    End If
                    j += 1
                End If
            Next

            Dim m As New models.ChineseNum With {
                .InputString = dblTotalJe
            }
            rcRps.PerPageText(intPage, 6) = IIf(intPage = Math.Ceiling(rcDataSet.Tables("rc_pcnr").Rows.Count / rcRps.LinesPerPage.ToString), "合计", "小计")
            rcRps.PerPageText(intPage, 7) = m.OutString '大写
            rcRps.PerPageText(intPage, 8) = Format(dblTotalSl, g_FormatSl)
            rcRps.PerPageText(intPage, 10) = Format(dblTotalJe, g_FormatJe)
            'dblTotalJe = 0.0
        Next
        If Decimal.op_Modulus(rcDataSet.Tables("rc_pcnr").Rows.Count, rcRps.LinesPerPage.ToString) <> 0 Then
            For i = Decimal.op_Modulus(rcDataSet.Tables("rc_pcnr").Rows.Count, rcRps.LinesPerPage.ToString) + 1 To rcRps.LinesPerPage.ToString
                rcRps.Text(j + 1, 1) = ""
                j += 1
            Next
        End If
        rcRps.Text(-1, 13) = "收货人（仓管）：" & g_User_DspName
    End Sub

    Private Sub MnuiPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrint.Click
        SaveEvent(True)
    End Sub

    Private Sub MnuiPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPageSetup.Click
        PageSetupEvent()
    End Sub

    Private Sub MnuiPrintView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrintView.Click
        PrintViewEvent()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        SaveEvent(True)
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

    'Private Sub FrmInvPcSrz2_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
    '    If IsEditing Then
    '        MsgBox("已经编辑过数据，请保存数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
    '        e.Cancel = True
    '    End If
    'End Sub

#End Region

End Class