Imports System.Data.OleDb
Imports System.Math
Imports System.IO

Public Class FrmFcspSrz

    '建立OLEDB数据适配器对象
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDb传递对象
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDb命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable '我们要利用该datatable进行金额计算
    ReadOnly dtPc As New DataTable("rc_fcspnr")
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
    Dim dblTotSl As Double = 0.0
    Dim dblTotJe As Double = 0.0
    Dim dblTotSe As Double = 0.0
    Dim dblTotCbje As Double = 0.0
    '打印文档
    Dim rcRps As RPS.Document = Nothing

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

    Private Sub FrmFcspSrz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '会计期间
        strKjqj = strYear & strMonth.PadLeft(2, "0")
        '设置DataGridView
        Me.rcDataGridView.AutoGenerateColumns = False
        Me.rcDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColJe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColJe").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColSe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColSe").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColCbje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColCbje").DefaultCellStyle.Format = g_FormatJe
        '数据绑定
        dtPc.Columns.Add("ckkjqj", Type.GetType("System.String"))
        dtPc.Columns.Add("djh", Type.GetType("System.String"))
        dtPc.Columns.Add("xh", Type.GetType("System.Integer"))
        dtPc.Columns.Add("shkhdm", Type.GetType("System.String"))
        dtPc.Columns.Add("fpkhdm", Type.GetType("System.String"))
        dtPc.Columns.Add("bmdm", Type.GetType("System.String"))
        dtPc.Columns.Add("cpdm", Type.GetType("System.String"))
        dtPc.Columns.Add("cpmc", Type.GetType("System.String"))
        dtPc.Columns.Add("dw", Type.GetType("System.String"))
        dtPc.Columns.Add("sl", Type.GetType("System.Double"))
        dtPc.Columns.Add("je", Type.GetType("System.Double"))
        dtPc.Columns.Add("se", Type.GetType("System.Double"))
        dtPc.Columns.Add("cbje", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtPc)
        With rcDataset.Tables("rc_fcspnr")
            .Columns("shkhdm").DefaultValue = ""
            .Columns("fpkhdm").DefaultValue = ""
            .Columns("bmdm").DefaultValue = ""
            .Columns("cpdm").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("je").DefaultValue = 0.0
            .Columns("se").DefaultValue = 0.0
            .Columns("cbje").DefaultValue = 0.0
        End With
        '读取已有数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT a.ckkjqj,a.cperiod,a.djh,a.xh,a.shkhdm,k.khmc as shkhmc,a.fpkhdm,h.khmc as fpkhmc,a.bmdm,b.bmmc,a.cpdm,c.cpmc,c.dw,a.sl,a.je,a.se,a.cbje FROM oe_xsd_fcsp a LEFT JOIN rc_khxx k ON k.khdm = a.shkhdm LEFT JOIN rc_khxx h ON h.khdm = a.fpkhdm LEFT JOIN rc_bmxx b ON b.bmdm = a.bmdm LEFT JOIN rc_cpxx c ON c.cpdm = a.cpdm WHERE a.cperiod = ? ORDER BY a.djh,a.xh,a.shkhdm,a.fpkhdm,a.bmdm,a.cpdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strKjqj
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            rcDataset.Tables("rc_fcspnr")?.Clear()
            rcOleDbDataAdpt.Fill(rcDataset, "rc_fcspnr")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '绑定数据the DataGrid to the DataSet.
        Me.rcBindingSource.DataSource = dtPc
        Me.rcDataGridView.DataSource = Me.rcBindingSource

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

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
        dblTotJe = 0.0
        dblTotSe = 0.0
        dblTotCbje = 0.0

        If dtPc.Rows.Count > 0 Then
            dblTotSl = dtPc.Compute("Sum(sl)", "")
            dblTotJe = dtPc.Compute("Sum(je)", "")
            dblTotSe = dtPc.Compute("Sum(se)", "")
            dblTotCbje = dtPc.Compute("Sum(cbje)", "")
        End If
        Me.LblSl.Text = "盘存数量合计：" + Format(dblTotSl, g_FormatSl)
        Me.LblJe.Text = "金额合计：" + Format(dblTotJe, g_FormatJe)
        Me.LblSe.Text = "税额合计：" + Format(dblTotSe, g_FormatJe)
        Me.LblCbje.Text = "成本金额合计：" + Format(dblTotCbje, g_FormatJe)
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
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColShKhdm" Then
                If Not String.IsNullOrEmpty(e.FormattedValue) Then
                    '取客户名称
                    Try
                        rcOleDbConn.Open()
                        rcOleDbCommand.Connection = rcOleDbConn
                        rcOleDbCommand.CommandTimeout = 300
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT * FROM rc_khxx WHERE khdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.AddWithValue("@khdm", Me.rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColShKhdm").EditedFormattedValue)
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_khxx") IsNot Nothing Then
                            rcDataset.Tables("rc_khxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_khxx")
                    Catch ex As Exception
                        Try
                            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        Catch ey As OleDbException
                            MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        End Try
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                    If rcDataset.Tables("rc_khxx").Rows.Count > 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColShKhdm").Value = rcDataset.Tables("rc_khxx").Rows(0).Item("khdm")
                        Me.rcDataGridView.CurrentRow.Cells("ColShKhmc").Value = rcDataset.Tables("rc_khxx").Rows(0).Item("khmc")
                    Else
                        Me.LblMsg.Text = "客户编码不存在。"
                        e.Cancel = True
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColFpKhdm" Then
                If Not String.IsNullOrEmpty(e.FormattedValue) Then
                    '取客户名称
                    Try
                        rcOleDbConn.Open()
                        rcOleDbCommand.Connection = rcOleDbConn
                        rcOleDbCommand.CommandTimeout = 300
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT * FROM rc_khxx WHERE khdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.AddWithValue("@khdm", Me.rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColFpKhdm").EditedFormattedValue)
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_khxx") IsNot Nothing Then
                            rcDataset.Tables("rc_khxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_khxx")
                    Catch ex As Exception
                        Try
                            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        Catch ey As OleDbException
                            MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        End Try
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                    If rcDataset.Tables("rc_khxx").Rows.Count > 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColFpKhdm").Value = rcDataset.Tables("rc_khxx").Rows(0).Item("khdm")
                        Me.rcDataGridView.CurrentRow.Cells("ColFpKhmc").Value = rcDataset.Tables("rc_khxx").Rows(0).Item("khmc")
                    Else
                        Me.LblMsg.Text = "客户编码不存在。"
                        e.Cancel = True
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColBmdm" Then
                If Not String.IsNullOrEmpty(e.FormattedValue) Then
                    Try
                        rcOleDbConn.Open()
                        rcOleDbCommand.Connection = rcOleDbConn
                        rcOleDbCommand.CommandTimeout = 300
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT * FROM rc_bmxx WHERE bmdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.AddWithValue("@bmdm", Me.rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColBmdm").EditedFormattedValue)
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_bmxx") IsNot Nothing Then
                            rcDataset.Tables("rc_bmxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_bmxx")
                    Catch ex As Exception
                        Try
                            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        Catch ey As OleDbException
                            MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        End Try
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                    If rcDataset.Tables("rc_bmxx").Rows.Count > 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColBmdm").Value = rcDataset.Tables("rc_bmxx").Rows(0).Item("bmdm")
                        Me.rcDataGridView.CurrentRow.Cells("ColBmmc").Value = rcDataset.Tables("rc_bmxx").Rows(0).Item("bmmc")
                    Else
                        Me.LblMsg.Text = "部门编码不存在。"
                        e.Cancel = True
                    End If
                End If
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
                            rcDataset.Tables("rc_cpxx")?.Clear()
                            rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
                            If rcDataset.Tables("rc_cpxx").Rows.Count > 0 Then
                                Me.rcDataGridView.CurrentRow.Cells("ColCpdm").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("cpdm")
                                Me.rcDataGridView.CurrentRow.Cells("ColCpmc").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("cpmc")
                                Me.rcDataGridView.CurrentRow.Cells("ColDw").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("dw")
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
            'If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColSl" Then
            '    If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
            '        Me.rcDataGridView.CurrentRow.Cells("ColCe").Value = e.FormattedValue - Me.rcDataGridView.CurrentRow.Cells("ColJcsl").Value
            '        If Me.rcDataGridView.CurrentRow.Cells("ColCe").Value > 0 Then
            '            Me.rcDataGridView.CurrentRow.Cells("ColByk").Value = "盘盈"
            '        Else
            '            If Me.rcDataGridView.CurrentRow.Cells("ColCe").Value = 0 Then
            '                Me.rcDataGridView.CurrentRow.Cells("ColByk").Value = "平"
            '            Else
            '                Me.rcDataGridView.CurrentRow.Cells("ColByk").Value = "盘亏"
            '            End If
            '        End If
            '    Else
            '        Me.rcDataGridView.CurrentRow.Cells("ColSl").Value = 0.0
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
                Me.rcBindingSource.EndEdit()
                Me.rcDataGridView.EndEdit()
        End Select
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColShKhdm" Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF3KeyPress
                    With rcFrm
                        .ParaOleDbConn = rcOleDbConn
                        .ParaTableName = "rc_khxx"
                        .ParaField1 = "khdm"
                        .ParaField2 = "khmc"
                        .ParaField3 = "khsm"
                        .ParaTitle = "客户"
                        .ParaOldValue = ""
                        .ParaAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            Me.rcDataGridView.CurrentRow.Cells("ColShKhdm").Value = .ParaField1
                            Me.rcDataGridView.EndEdit()
                            Me.rcBindingSource.EndEdit()
                        End If
                    End With
            End Select
        End If
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColFpKhdm" Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF3KeyPress
                    With rcFrm
                        .ParaOleDbConn = rcOleDbConn
                        .ParaTableName = "rc_khxx"
                        .ParaField1 = "khdm"
                        .ParaField2 = "khmc"
                        .ParaField3 = "khsm"
                        .ParaTitle = "客户"
                        .ParaOldValue = ""
                        .ParaAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            Me.rcDataGridView.CurrentRow.Cells("ColFpKhdm").Value = .ParaField1
                            Me.rcDataGridView.EndEdit()
                            Me.rcBindingSource.EndEdit()
                        End If
                    End With
            End Select
        End If
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColBmdm" Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF3KeyPress
                    With rcFrm
                        .ParaOleDbConn = rcOleDbConn
                        .ParaTableName = "rc_bmxx"
                        .ParaField1 = "bmdm"
                        .ParaField2 = "bmmc"
                        .ParaField3 = "bmsm"
                        .ParaTitle = "部门"
                        .ParaOldValue = ""
                        .ParaAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            Me.rcDataGridView.CurrentRow.Cells("ColBmdm").Value = .ParaField1
                            Me.rcDataGridView.EndEdit()
                            Me.rcBindingSource.EndEdit()
                        End If
                    End With
            End Select
        End If

        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColCpdm" And Me.ColCpdm.ReadOnly = False Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF34
                    With rcFrm
                        .ParaOleDbConn = rcOleDbConn
                        .ParaTableName = "rc_cpxx"
                        .ParaField1 = "cpdm"
                        .ParaField2 = "cpmc"
                        .ParaField3 = "dw"
                        .ParaField4 = "cpsm"
                        .ParaOrderField = "cpmc"
                        .ParaTitle = "物料"
                        .ParaOldValue = ""
                        .ParaAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            '将用户在rcfrmselectcpdm所选择的cpdm带入rcdatarid'
                            Me.rcDataGridView.CurrentRow.Cells("ColCpdm").Value = .ParaField1
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
        If Me.rcDataGridView.CurrentCell.OwningColumn.Name = "ColCpdm" Or Me.rcDataGridView.CurrentCell.OwningColumn.Name = "ColShKhdm" Or Me.rcDataGridView.CurrentCell.OwningColumn.Name = "ColFpKhdm" Or Me.rcDataGridView.CurrentCell.OwningColumn.Name = "ColBmdm" Then
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
                        .ParaOleDbConn = rcOleDbConn
                        .ParaTableName = "rc_cpxx"
                        .ParaField1 = "cpdm"
                        .ParaField2 = "cpmc"
                        .ParaField3 = "dw"
                        .ParaField4 = "cpsm"
                        .ParaOrderField = "cpmc"
                        .ParaTitle = "物料"
                        .ParaOldValue = ""
                        .ParaAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            '将用户在rcfrmselectcpdm所选择的cpdm带入rcdatarid'
                            Me.rcDataGridView.CurrentRow.Cells("ColCpdm").Value = .ParaField1
                            Me.rcDataGridView.EndEdit()
                            Me.rcBindingSource.EndEdit()
                        End If
                    End With
                    e.Handled = True
            End Select
        End If
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColBmdm" Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF3KeyPress
                    With rcFrm
                        .ParaOleDbConn = rcOleDbConn
                        .ParaTableName = "rc_bmxx"
                        .ParaField1 = "bmdm"
                        .ParaField2 = "bmmc"
                        .ParaField3 = "bmsm"
                        .ParaTitle = "部门"
                        .ParaOldValue = ""
                        .ParaAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            '将用户在FrmF3KeyPress所选择的bmdm带入rcdatarid'
                            Me.rcDataGridView.CurrentRow.Cells("ColBmdm").Value = .ParaField1
                            Me.rcDataGridView.EndEdit()
                            Me.rcBindingSource.EndEdit()
                        End If
                    End With
                    e.Handled = True
            End Select
        End If
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColShKhdm" Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF3KeyPress
                    With rcFrm
                        .ParaOleDbConn = rcOleDbConn
                        .ParaTableName = "rc_khxx"
                        .ParaField1 = "khdm"
                        .ParaField2 = "khmc"
                        .ParaField3 = "khsm"
                        .ParaTitle = "客户"
                        .ParaOldValue = ""
                        .ParaAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            '将用户在FrmF3KeyPress所选择的bmdm带入rcdatarid'
                            Me.rcDataGridView.CurrentRow.Cells("ColShKhdm").Value = .ParaField1
                            Me.rcDataGridView.EndEdit()
                            Me.rcBindingSource.EndEdit()
                        End If
                    End With
                    e.Handled = True
            End Select
        End If
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColFpKhdm" Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF3KeyPress
                    With rcFrm
                        .ParaOleDbConn = rcOleDbConn
                        .ParaTableName = "rc_khxx"
                        .ParaField1 = "khdm"
                        .ParaField2 = "khmc"
                        .ParaField3 = "khsm"
                        .ParaTitle = "客户"
                        .ParaOldValue = ""
                        .ParaAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            '将用户在FrmF3KeyPress所选择的bmdm带入rcdatarid'
                            Me.rcDataGridView.CurrentRow.Cells("ColFpKhdm").Value = .ParaField1
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
        '(1)是否有需要存储的数据
        If rcDataset.Tables("rc_fcspnr").Rows.Count = 0 Then
            MsgBox("没有相应的业务，请输入。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Return
        End If
        '(3)物料编码
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            For i = 0 To rcDataset.Tables("rc_fcspnr").Rows.Count - 1
                If rcDataset.Tables("rc_fcspnr").Rows(i).RowState <> DataRowState.Deleted Then
                    rcOleDbCommand.CommandType = CommandType.Text
                    rcOleDbCommand.CommandText = "SELECT * FROM rc_cpxx WHERE cpdm = ? AND ty <> 1"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.AddWithValue("@cpdm", Trim(rcDataset.Tables("rc_fcspnr").Rows(i).Item("cpdm")))
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("cpdmcnt") IsNot Nothing Then
                        Me.rcDataset.Tables("cpdmcnt").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "cpdmcnt")

                    If rcDataset.Tables("cpdmcnt").Rows.Count <> 1 Then
                        MsgBox(Trim(rcDataset.Tables("rc_fcspnr").Rows(i).Item("cpdm")) & "物料编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
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
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "DELETE FROM oe_xsd_fcsp WHERE cperiod = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strKjqj
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "INSERT INTO oe_xsd_fcsp (cperiod,ckkjqj,djh,xh,shkhdm,fpkhdm,bmdm,cpdm,sl,je,se,cbje) " &
                                         "VALUES (?,?,?,?,?,?,?,?,?,?,?)"
            For i = 0 To rcDataset.Tables("rc_fcspnr").Rows.Count - 1
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strKjqj
                rcOleDbCommand.Parameters.Add("@ckkjqj", OleDbType.VarChar, 6).Value = rcDataset.Tables("rc_fcspnr").Rows(i).Item("ckkjqj")
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 20).Value = rcDataset.Tables("rc_fcspnr").Rows(i).Item("djh")
                rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = rcDataset.Tables("rc_fcspnr").Rows(i).Item("xh")
                rcOleDbCommand.Parameters.Add("@shkhdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rc_fcspnr").Rows(i).Item("shkhdm")
                rcOleDbCommand.Parameters.Add("@fpkhdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rc_fcspnr").Rows(i).Item("fpkhdm")
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rc_fcspnr").Rows(i).Item("bmdm")
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("rc_fcspnr").Rows(i).Item("cpdm")).ToUpper
                rcOleDbCommand.Parameters.Add("@sl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_fcspnr").Rows(i).Item("sl")
                rcOleDbCommand.Parameters.Add("@je", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_fcspnr").Rows(i).Item("je")
                rcOleDbCommand.Parameters.Add("@se", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_fcspnr").Rows(i).Item("se")
                rcOleDbCommand.Parameters.Add("@cbje", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_fcspnr").Rows(i).Item("cbje")
                rcOleDbCommand.ExecuteNonQuery()
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
        ''打印
        'If blnPrint Then
        '    PrintEvent()
        'End If
        '控件设置
        SetControlEnableEvent()
        '设置焦点
        'Me.TxtDjh.Focus()
        Me.Close()
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

#Region "读入excel"

    Private Sub BtnImpXls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiImpXls.Click
        '调用表单
        Dim rcFrm As New FrmFcspImpXls
        With rcFrm
            .ParaStrKjqj = strKjqj
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

#End Region

    '#Region "打印设置、打印、打印预览事件"

    '    Private Sub PageSetupEvent()
    '        Dim rcFrmPageSetup As New models.FrmPageSetup
    '        With rcFrmPageSetup
    '            .ParaOleDbConn = rcOleDbConn
    '            .ParaRpsId = "PCBBZ"
    '            .ParaRpsName = "盘存表标准格式"
    '            .ShowDialog()
    '        End With
    '    End Sub

    '    Private Sub PrintEvent()
    '        If g_Demo = 1 Then
    '            MsgBox("对不起，试用软件不能打印。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
    '            Return
    '        End If
    '        PreparePrintData()
    '        Dim rcFrmPrint As New models.FrmPrint
    '        With rcFrmPrint
    '            .ParaRps = rcRps
    '            .ShowDialog()
    '        End With
    '    End Sub

    '    Private Sub PrintViewEvent()
    '        PreparePrintData()
    '        rcRps.Preview()
    '    End Sub

    '    Private Sub PreparePrintData()
    '        If rcRps Is Nothing Then
    '            rcRps = New RPS.Document
    '        End If
    '        Dim rft As String = Application.StartupPath + "\reports\rkdbz.rft"
    '        rcRps.LoadTemplate(rft)
    '        '取RPS打印参数
    '        rcOleDbConn.Open()
    '        rcOleDbCommand.Connection = rcOleDbConn
    '        rcOleDbCommand.CommandTimeout = 300
    '        rcOleDbCommand.CommandType = CommandType.Text
    '        Try
    '            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps WHERE rpsid = 'PCBBZ'"
    '            rcOleDbCommand.Parameters.Clear()
    '            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
    '            rcDataset.Tables("rc_rps")?.Clear()
    '            rcOleDbDataAdpt.Fill(rcDataset, "rc_rps")
    '        Catch ex As Exception
    '            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
    '            Return
    '        Finally
    '            rcOleDbConn.Close()
    '        End Try
    '        If rcDataset.Tables("rc_rps").Rows.Count > 0 Then
    '            '设定值
    '            rcRps.Scale = rcDataset.Tables("rc_rps").Rows(0).Item("scale")
    '            rcRps.Orientation = rcDataset.Tables("rc_rps").Rows(0).Item("orientation")
    '            rcRps.PaperWidth = rcDataset.Tables("rc_rps").Rows(0).Item("paperwidth")
    '            rcRps.PaperHeight = rcDataset.Tables("rc_rps").Rows(0).Item("paperheight")
    '            rcRps.PrinterLeft = rcDataset.Tables("rc_rps").Rows(0).Item("printerleft")
    '            rcRps.PrinterTop = rcDataset.Tables("rc_rps").Rows(0).Item("printertop")
    '        Else
    '            '默认值
    '            rcRps.Scale = 100
    '            rcRps.Orientation = 1
    '        End If
    '        '套打
    '        'rcRps.PaperType = 1
    '        rcRps.Text(-1, 1) = g_PrnDwmc & "物料盘存表"
    '        'rcRps.Text(-1, 2) = "单据号：" & Trim(Me.TxtDjh.Text) & "  %p/%t"
    '        'rcRps.Text(-1, 3) = "供应商：(" & Trim(Me.TxtKhdm.Text) & ")" & Trim(Me.LblKhmc.Text)
    '        'rcRps.Text(-1, 4) = "库存地点：(" & Trim(Me.TxtCkdm.Text) & ")" & Trim(LblCkmc.Text)
    '        'rcRps.Text(-1, 5) = "日期：" & DtpPcrq.Value.Date.ToLongDateString
    '        'rcRps.Text(-1, 22) = "工资"
    '        Dim i As Integer
    '        Dim j As Integer
    '        Dim intPage As Integer
    '        Dim dblTotalSl As Double = 0.0
    '        Dim dblTotalJe As Double = 0.0
    '        For intPage = 1 To System.Math.Ceiling(rcDataset.Tables("rc_fcspnr").Rows.Count / rcRps.LinesPerPage.ToString)
    '            For i = (intPage - 1) * rcRps.LinesPerPage.ToString To System.Math.Min(intPage * rcRps.LinesPerPage.ToString - 1, rcDataset.Tables("rc_fcspnr").Rows.Count - 1)
    '                If rcDataset.Tables("rc_fcspnr").Rows(i).RowState <> 8 Then
    '                    If Not rcDataset.Tables("rc_fcspnr").Rows(i).Item("cpdm").GetType.ToString = "System.DBNull" Then
    '                        rcRps.Text(j + 1, 1) = Trim(rcDataset.Tables("rc_fcspnr").Rows(i).Item("cpdm"))
    '                    End If
    '                    If Not rcDataset.Tables("rc_fcspnr").Rows(i).Item("cpmc").GetType.ToString = "System.DBNull" Then
    '                        rcRps.Text(j + 1, 2) = Trim(rcDataset.Tables("rc_fcspnr").Rows(i).Item("cpmc"))
    '                    End If
    '                    If Not rcDataset.Tables("rc_fcspnr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
    '                        rcRps.Text(j + 1, 4) = Trim(rcDataset.Tables("rc_fcspnr").Rows(i).Item("dw"))
    '                    End If
    '                    If Not rcDataset.Tables("rc_fcspnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
    '                        rcRps.Text(j + 1, 5) = Format(rcDataset.Tables("rc_fcspnr").Rows(i).Item("sl"), g_FormatSl)
    '                        dblTotalSl += rcDataset.Tables("rc_fcspnr").Rows(i).Item("sl")
    '                    End If
    '                    If Not rcDataset.Tables("rc_fcspnr").Rows(i).Item("jcsl").GetType.ToString = "System.DBNull" Then
    '                        rcRps.Text(j + 1, 6) = Format(rcDataset.Tables("rc_fcspnr").Rows(i).Item("jcsl"), g_FormatDj)
    '                    End If
    '                    If Not rcDataset.Tables("rc_fcspnr").Rows(i).Item("jcje").GetType.ToString = "System.DBNull" Then
    '                        rcRps.Text(j + 1, 7) = Format(rcDataset.Tables("rc_fcspnr").Rows(i).Item("jcje"), g_FormatJe)
    '                        dblTotalJe += rcDataset.Tables("rc_fcspnr").Rows(i).Item("jcje")
    '                    End If
    '                    If Not rcDataset.Tables("rc_fcspnr").Rows(i).Item("rkmemo").GetType.ToString = "System.DBNull" Then
    '                        rcRps.Text(j + 1, 8) = Trim(rcDataset.Tables("rc_fcspnr").Rows(i).Item("rkmemo"))
    '                    End If
    '                    j += 1
    '                End If
    '            Next

    '            Dim m As New models.ChineseNum With {
    '                .InputString = dblTotalJe
    '            }
    '            rcRps.PerPageText(intPage, 6) = IIf(intPage = Math.Ceiling(rcDataset.Tables("rc_fcspnr").Rows.Count / rcRps.LinesPerPage.ToString), "合计", "小计")
    '            rcRps.PerPageText(intPage, 7) = m.OutString '大写
    '            rcRps.PerPageText(intPage, 8) = Format(dblTotalSl, g_FormatSl)
    '            rcRps.PerPageText(intPage, 10) = Format(dblTotalJe, g_FormatJe)
    '            'dblTotalJe = 0.0
    '        Next
    '        If Decimal.op_Modulus(rcDataset.Tables("rc_fcspnr").Rows.Count, rcRps.LinesPerPage.ToString) <> 0 Then
    '            For i = Decimal.op_Modulus(rcDataset.Tables("rc_fcspnr").Rows.Count, rcRps.LinesPerPage.ToString) + 1 To rcRps.LinesPerPage.ToString
    '                rcRps.Text(j + 1, 1) = ""
    '                j += 1
    '            Next
    '        End If
    '        rcRps.Text(-1, 13) = "收货人（仓管）：" & g_User_DspName
    '    End Sub

    '    Private Sub MnuiPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrint.Click
    '        SaveEvent(True)
    '    End Sub

    '    Private Sub MnuiPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPageSetup.Click
    '        PageSetupEvent()
    '    End Sub

    '    Private Sub MnuiPrintView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrintView.Click
    '        PrintViewEvent()
    '    End Sub

    '    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
    '        SaveEvent(True)
    '    End Sub

    '    Private Sub BtnPrintView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrintView.Click
    '        PrintViewEvent()
    '    End Sub

    '#End Region

#Region "退出表单事件"

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click, MnuiExit.Click
        Me.Close()
    End Sub

    'Private Sub FrmFcspSrz2_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
    '    If IsEditing Then
    '        MsgBox("已经编辑过数据，请保存数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
    '        e.Cancel = True
    '    End If
    'End Sub

#End Region

End Class