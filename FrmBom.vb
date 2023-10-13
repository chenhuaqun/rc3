Imports System.Data.OleDb

Public Class FrmBom

    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '数据更新传递
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable '我们要利用该datatable进行金额计算
    ReadOnly dtBom As New DataTable("rc_bom")
    ReadOnly dtGx As New DataTable("rc_gx")
    '建立DataGridViewTextBoxEditingControl对象
    Dim EditingControl1 As DataGridViewTextBoxEditingControl
    Dim EditingControl2 As DataGridViewTextBoxEditingControl

    Private Sub FrmBom_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '设置DataGridView
        Me.rcDataGridView1.AutoGenerateColumns = False
        Me.rcDataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.rcDataGridView1.Columns("ColSl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView1.Columns("ColSl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView1.Columns("ColDj").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView1.Columns("ColDj").DefaultCellStyle.Format = g_FormatDj
        Me.rcDataGridView1.Columns("ColJe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView1.Columns("ColJe").DefaultCellStyle.Format = g_FormatDj
        Me.rcDataGridView2.Columns("ColGongShi").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView2.Columns("ColGongShi").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView2.Columns("ColXiShu").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView2.Columns("ColXiShu").DefaultCellStyle.Format = g_FormatDj
        Me.rcDataGridView2.Columns("ColRgcb").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView2.Columns("ColRgcb").DefaultCellStyle.Format = g_FormatJe
        '数据绑定
        dtBom.Columns.Add("childcpdm", Type.GetType("System.String"))
        dtBom.Columns.Add("childcpmc", Type.GetType("System.String"))
        dtBom.Columns.Add("childdw", Type.GetType("System.String"))
        dtBom.Columns.Add("sl", Type.GetType("System.Double"))
        dtBom.Columns.Add("dj", Type.GetType("System.Double"))
        dtBom.Columns.Add("je", Type.GetType("System.Double"))
        dtBom.Columns.Add("bommemo", Type.GetType("System.String"))
        rcDataset.Tables.Add(dtBom)
        With dtBom
            .Columns("childcpdm").DefaultValue = ""
            .Columns("childcpmc").DefaultValue = ""
            .Columns("childdw").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("dj").DefaultValue = 0.0
            .Columns("je").DefaultValue = 0.0
            .Columns("bommemo").DefaultValue = ""
        End With
        Me.rcBindingSource1.DataSource = dtBom
        Me.rcDataGridView1.DataSource = Me.rcBindingSource1
        '数据绑定
        dtGx.Columns.Add("xh", Type.GetType("System.Int32"))
        dtGx.Columns.Add("gxdm", Type.GetType("System.String"))
        dtGx.Columns.Add("gxmc", Type.GetType("System.String"))
        dtGx.Columns.Add("bmdm", Type.GetType("System.String"))
        dtGx.Columns.Add("bmmc", Type.GetType("System.String"))
        dtGx.Columns.Add("gongshi", Type.GetType("System.Double"))
        dtGx.Columns.Add("xishu", Type.GetType("System.Double"))
        dtGx.Columns.Add("rgcb", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtGx)
        With dtGx
            .Columns("xh").DefaultValue = 0
            .Columns("gxdm").DefaultValue = ""
            .Columns("gxmc").DefaultValue = ""
            .Columns("bmdm").DefaultValue = ""
            .Columns("bmmc").DefaultValue = ""
            .Columns("gongshi").DefaultValue = 0.0
            .Columns("xishu").DefaultValue = 0.0
            .Columns("rgcb").DefaultValue = 0.0
        End With
        Me.rcBindingSource2.DataSource = dtGx
        Me.rcDataGridView2.DataSource = Me.rcBindingSource2
    End Sub

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtParentCpdm.KeyPress, TxtParentCpmc.KeyPress, TxtParentDw.KeyPress, NudBzcb.KeyPress, NudChengPinLv.KeyPress, NudBeiShu.KeyPress, NudClcb.KeyPress, NudRgcb.KeyPress, NudNycb.KeyPress, NudZjcb.KeyPress, NudGlcb.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If Me.ActiveControl.GetType.Name = "DataGridViewTextBoxEditingControl" Or Me.rcDataGridView1.Focused Or Me.rcDataGridView2.Focused Then
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

#Region "物料编码事件"

    Private Sub TxtParentCpdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtParentCpdm.KeyDown
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
                        Me.TxtParentCpdm.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtParentCpdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtParentCpdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtParentCpdm.Text) Then
            '读取数据
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT  *  From rc_cpxx Where cpdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtParentCpdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("parentcpxx") IsNot Nothing Then
                    rcDataset.Tables("parentcpxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "parentcpxx")
                rcOleDbCommand.CommandText = "SELECT pm_bom.childcpdm,rc_cpxx.cpmc AS childcpmc,rc_cpxx.dw AS childdw,pm_bom.sl,pm_bom.dj,pm_bom.je,pm_bom.bommemo FROM rc_cpxx,pm_bom WHERE rc_cpxx.cpdm = pm_bom.childcpdm AND pm_bom.parentcpdm = ? ORDER BY pm_bom.childcpdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtParentCpdm.Text)
                If rcDataset.Tables("rc_bom") IsNot Nothing Then
                    rcDataset.Tables("rc_bom").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_bom")
                rcOleDbCommand.CommandText = "SELECT pm_gx.xh,rc_gxxx.gxdm AS gxdm,rc_gxxx.gxmc AS gxmc,rc_gxxx.bmdm AS bmdm,rc_gxxx.bmmc AS bmmc,pm_gx.gongshi,pm_gx.xishu,pm_gx.rgcb FROM rc_gxxx,pm_gx WHERE rc_gxxx.gxdm = pm_gx.gxdm AND pm_gx.parentcpdm = ? ORDER BY pm_gx.xh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtParentCpdm.Text)
                If rcDataset.Tables("rc_gx") IsNot Nothing Then
                    rcDataset.Tables("rc_gx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_gx")
            Catch ex As Exception
                MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("parentcpxx").Rows.Count > 0 Then
                If rcDataset.Tables("parentcpxx").Rows(0).Item("cpmc").GetType.ToString <> "System.DBNull" Then
                    Me.TxtParentCpmc.Text = rcDataset.Tables("parentcpxx").Rows(0).Item("cpmc")
                End If
                If rcDataset.Tables("parentcpxx").Rows(0).Item("dw").GetType.ToString <> "System.DBNull" Then
                    Me.TxtParentDw.Text = rcDataset.Tables("parentcpxx").Rows(0).Item("dw")
                End If
                If rcDataset.Tables("parentcpxx").Rows(0).Item("bzcb").GetType.ToString <> "System.DBNull" Then
                    Me.NudBzcb.Value = rcDataset.Tables("parentcpxx").Rows(0).Item("bzcb")
                End If
                If rcDataset.Tables("parentcpxx").Rows(0).Item("clcb").GetType.ToString <> "System.DBNull" Then
                    Me.NudClcb.Value = rcDataset.Tables("parentcpxx").Rows(0).Item("clcb")
                End If
                If rcDataset.Tables("parentcpxx").Rows(0).Item("rgcb").GetType.ToString <> "System.DBNull" Then
                    Me.NudRgcb.Value = rcDataset.Tables("parentcpxx").Rows(0).Item("rgcb")
                End If
                If rcDataset.Tables("parentcpxx").Rows(0).Item("nycb").GetType.ToString <> "System.DBNull" Then
                    Me.NudNycb.Value = rcDataset.Tables("parentcpxx").Rows(0).Item("nycb")
                End If
                If rcDataset.Tables("parentcpxx").Rows(0).Item("zjcb").GetType.ToString <> "System.DBNull" Then
                    Me.NudZjcb.Value = rcDataset.Tables("parentcpxx").Rows(0).Item("zjcb")
                End If
                If rcDataset.Tables("parentcpxx").Rows(0).Item("glcb").GetType.ToString <> "System.DBNull" Then
                    Me.NudGlcb.Value = rcDataset.Tables("parentcpxx").Rows(0).Item("glcb")
                End If
                If rcDataset.Tables("parentcpxx").Rows(0).Item("chengpinlv").GetType.ToString <> "System.DBNull" Then
                    Me.NudChengPinLv.Value = rcDataset.Tables("parentcpxx").Rows(0).Item("chengpinlv")
                End If
                If rcDataset.Tables("parentcpxx").Rows(0).Item("beishu").GetType.ToString <> "System.DBNull" Then
                    Me.NudBeiShu.Value = rcDataset.Tables("parentcpxx").Rows(0).Item("beishu")
                End If
            Else
                MsgBox("该物料编码不存在。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "rcDataGridView1的事件"

    'Private Sub rcDataGridView_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles rcDataGridView.CellEnter
    '    '如果此单元格只读的话则发送回车键。
    '    If Me.rcDataGridView.CurrentCell.ReadOnly Then My.Computer.Keyboard.SendKeys("{Enter}")
    'End Sub

    Private Sub RcDataGridView1_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles rcDataGridView1.CellValidating
        If Me.rcDataGridView1.CurrentRow.IsNewRow = False Then
            If Me.rcDataGridView1.IsCurrentCellDirty Then
                Me.rcDataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
            If Me.rcDataGridView1.Columns(e.ColumnIndex).Name = "ColChildCpdm" Then
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
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataGridView1.Rows(rcDataGridView1.CurrentRow.Index).Cells("ColChildCpdm").EditedFormattedValue
                            rcOleDbCommand.Parameters.Add("@oldcpdm", OleDbType.VarChar, 12).Value = rcDataGridView1.Rows(rcDataGridView1.CurrentRow.Index).Cells("ColChildCpdm").EditedFormattedValue
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                                rcDataset.Tables("rc_cpxx").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
                            If rcDataset.Tables("rc_cpxx").Rows.Count > 0 Then
                                Me.rcDataGridView1.CurrentRow.Cells("ColChildCpdm").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("cpdm")
                                Me.rcDataGridView1.CurrentRow.Cells("ColChildCpmc").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("cpmc")
                                Me.rcDataGridView1.CurrentRow.Cells("ColChildDw").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("dw")
                                Me.rcDataGridView1.CurrentRow.Cells("ColDj").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("cgdj")
                            Else
                                MsgBox("物料编码不存在。")
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
            If Me.rcDataGridView1.Columns(e.ColumnIndex).Name = "ColSl" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    If Me.rcDataGridView1.CurrentRow.Cells("ColDj").Value <> 0 Then
                        Me.rcDataGridView1.CurrentRow.Cells("ColJe").Value = System.Math.Round(Me.rcDataGridView1.CurrentRow.Cells("ColDj").Value * e.FormattedValue, 4, MidpointRounding.AwayFromZero)
                    End If
                Else
                    Me.rcDataGridView1.CurrentRow.Cells("ColSl").Value = 0.0
                End If
            End If
            If Me.rcDataGridView1.Columns(e.ColumnIndex).Name = "ColDj" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    If e.FormattedValue <> 0 Then
                        Me.rcDataGridView1.CurrentRow.Cells("ColJe").Value = System.Math.Round(Me.rcDataGridView1.CurrentRow.Cells("ColSl").Value * e.FormattedValue, 4, MidpointRounding.AwayFromZero)
                    End If
                Else
                    Me.rcDataGridView1.CurrentRow.Cells("ColDj").Value = 0.0
                End If
            End If
            If Me.rcDataGridView1.Columns(e.ColumnIndex).Name = "ColJe" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    If e.FormattedValue <> 0 And Me.rcDataGridView1.CurrentRow.Cells("ColSl").Value <> 0 Then
                        Me.rcDataGridView1.CurrentRow.Cells("ColDj").Value = System.Math.Round(e.FormattedValue / Me.rcDataGridView1.CurrentRow.Cells("ColSl").Value, 6, MidpointRounding.AwayFromZero)
                    End If
                Else
                    Me.rcDataGridView1.CurrentRow.Cells("ColJe").Value = 0.0
                End If
            End If
        End If
    End Sub

    Private Sub RcDataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rcDataGridView1.KeyDown
        Select Case e.KeyCode
            Case Keys.C And e.Control
                '复制
                Clipboard.SetDataObject(Me.rcDataGridView1.GetClipboardContent())
            Case Keys.V And e.Control
                '粘贴
                Me.rcDataGridView1.CurrentCell.Value = Clipboard.GetText()
                Me.rcBindingSource1.EndEdit()
                Me.rcDataGridView1.EndEdit()
        End Select
        If Me.rcDataGridView1.Columns(Me.rcDataGridView1.CurrentCell.ColumnIndex).Name = "ColChildCpdm" Then
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
                            Me.rcDataGridView1.CurrentRow.Cells("ColChildCpdm").Value = .paraField1
                            Me.rcBindingSource1.EndEdit()
                            Me.rcDataGridView1.EndEdit()
                        End If
                    End With
            End Select
        End If
    End Sub

    Private Sub RcDataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles rcDataGridView1.EditingControlShowing
        EditingControl1 = e.Control
        If Not EditingControl1.IsHandleCreated Then
            AddHandler EditingControl1.KeyDown, New KeyEventHandler(AddressOf EditingControl1_KeyDown)
        End If
        If Me.rcDataGridView1.CurrentCell.OwningColumn.Name = "ColChildCpdm" Then
            EditingControl1.CharacterCasing = CharacterCasing.Upper
        Else
            EditingControl1.CharacterCasing = CharacterCasing.Normal
        End If
    End Sub

    Private Sub EditingControl1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If Me.rcDataGridView1.Columns(Me.rcDataGridView1.CurrentCell.ColumnIndex).Name = "ColChildCpdm" Then
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
                            Me.rcDataGridView1.CurrentRow.Cells("ColChildCpdm").Value = .paraField1
                            Me.rcDataGridView1.EndEdit()
                            Me.rcBindingSource1.EndEdit()
                        End If
                    End With
                    e.Handled = True
            End Select
        End If
    End Sub

    Private Sub RcDataGridView1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles rcDataGridView1.Leave
        Me.rcDataGridView1.ClearSelection()
    End Sub

    Private Sub RcDataGridView1_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles rcDataGridView1.RowValidating
        If Not Me.rcDataGridView1.CurrentRow.IsNewRow Then
            Me.rcBindingSource1.EndEdit()
            Me.rcDataGridView1.EndEdit()
            SumJe()
        End If
    End Sub

#End Region

#Region "计算合计数"

    Private Sub SumJe()
        '计算合计数
        If Me.NudChengPinLv.Value <> 0 And Me.NudBeiShu.Value <> 0 Then
            If Me.NudChengPinLv.Value = 0 Then
                Me.NudChengPinLv.Value = 100
            End If
            If dtBom.Rows.Count > 0 Then
                Me.NudClcb.Value = dtBom.Compute("Sum(je)", "") / Me.NudBeiShu.Value
            End If
            If dtGx.Rows.Count > 0 Then
                Me.NudRgcb.Value = dtGx.Compute("Sum(rgcb)", "") / Me.NudBeiShu.Value
            End If
            Me.NudBzcb.Value = (Me.NudClcb.Value + Me.NudRgcb.Value + Me.NudNycb.Value + Me.NudZjcb.Value + Me.NudGlcb.Value) / Me.NudChengPinLv.Value * 100
        End If
    End Sub

#End Region

#Region "rcDataGridView2的事件"

    Private Sub RcDataGridView2_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles rcDataGridView2.CellValidating
        If Me.rcDataGridView2.CurrentRow.IsNewRow = False Then
            If Me.rcDataGridView2.IsCurrentCellDirty Then
                Me.rcDataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
            If Me.rcDataGridView2.Columns(e.ColumnIndex).Name = "ColGxdm" Then
                If Not String.IsNullOrEmpty(e.FormattedValue) Then
                    If Not String.IsNullOrEmpty(e.FormattedValue) Then
                        '取生产工序信息
                        Try
                            rcOleDbConn.Open()
                            rcOleDbCommand.Connection = rcOleDbConn
                            rcOleDbCommand.CommandTimeout = 300
                            rcOleDbCommand.CommandType = CommandType.Text
                            rcOleDbCommand.CommandText = "SELECT * FROM rc_gxxx WHERE gxdm = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@gxdm", OleDbType.VarChar, 12).Value = rcDataGridView2.Rows(rcDataGridView2.CurrentRow.Index).Cells("ColGxdm").EditedFormattedValue
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("rc_gxxx") IsNot Nothing Then
                                rcDataset.Tables("rc_gxxx").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "rc_gxxx")
                            If rcDataset.Tables("rc_gxxx").Rows.Count > 0 Then
                                Me.rcDataGridView2.CurrentRow.Cells("ColGxdm").Value = rcDataset.Tables("rc_gxxx").Rows(0).Item("gxdm")
                                Me.rcDataGridView2.CurrentRow.Cells("ColGxmc").Value = rcDataset.Tables("rc_gxxx").Rows(0).Item("gxmc")
                                Me.rcDataGridView2.CurrentRow.Cells("ColBmdm").Value = rcDataset.Tables("rc_gxxx").Rows(0).Item("bmdm")
                                Me.rcDataGridView2.CurrentRow.Cells("ColBmmc").Value = rcDataset.Tables("rc_gxxx").Rows(0).Item("bmmc")
                            Else
                                MsgBox("生产工序编码不存在。")
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
            If Me.rcDataGridView2.Columns(e.ColumnIndex).Name = "ColGongShi" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    If Me.rcDataGridView2.CurrentRow.Cells("ColXiShu").Value <> 0 Then
                        Me.rcDataGridView2.CurrentRow.Cells("ColRgcb").Value = System.Math.Round(Me.rcDataGridView2.CurrentRow.Cells("ColXiShu").Value * e.FormattedValue, 2, MidpointRounding.AwayFromZero)
                    End If
                Else
                    Me.rcDataGridView2.CurrentRow.Cells("ColGongShi").Value = 0.0
                End If
            End If
            If Me.rcDataGridView2.Columns(e.ColumnIndex).Name = "ColXiShu" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    If e.FormattedValue <> 0 Then
                        Me.rcDataGridView2.CurrentRow.Cells("ColRgcb").Value = System.Math.Round(Me.rcDataGridView2.CurrentRow.Cells("ColGongShi").Value * e.FormattedValue, 2, MidpointRounding.AwayFromZero)
                    End If
                Else
                    Me.rcDataGridView2.CurrentRow.Cells("ColXiShu").Value = 0.0
                End If
            End If
            If Me.rcDataGridView2.Columns(e.ColumnIndex).Name = "ColRgcb" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    If e.FormattedValue <> 0 And Me.rcDataGridView2.CurrentRow.Cells("ColGongShi").Value <> 0 Then
                        Me.rcDataGridView2.CurrentRow.Cells("ColXiShu").Value = System.Math.Round(e.FormattedValue / Me.rcDataGridView2.CurrentRow.Cells("ColGongShi").Value, 6, MidpointRounding.AwayFromZero)
                    End If
                Else
                    Me.rcDataGridView2.CurrentRow.Cells("ColRgcb").Value = 0.0
                End If
            End If
        End If
    End Sub

    Private Sub RcDataGridView2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rcDataGridView2.KeyDown
        Select Case e.KeyCode
            Case Keys.C And e.Control
                '复制
                Clipboard.SetDataObject(Me.rcDataGridView2.GetClipboardContent())
            Case Keys.V And e.Control
                '粘贴
                Me.rcDataGridView2.CurrentCell.Value = Clipboard.GetText()
                Me.rcBindingSource2.EndEdit()
                Me.rcDataGridView2.EndEdit()
        End Select
        If Me.rcDataGridView2.Columns(Me.rcDataGridView2.CurrentCell.ColumnIndex).Name = "ColGxdm" Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF3KeyPress
                    With rcFrm
                        .paraOleDbConn = rcOleDbConn
                        .paraTableName = "rc_gxxx"
                        .paraField1 = "gxdm"
                        .paraField2 = "gxmc"
                        .paraField3 = "gxsm"
                        .paraCondition = ""
                        .paraOrderField = "gxsm"
                        .paraTitle = "生产工序"
                        .paraOldValue = "" 'IIf(rcSrDataGrid(rcSrDataGrid.CurrentRowIndex, 0).GetType.ToString <> "System.DBNull", rcSrDataGrid(rcSrDataGrid.CurrentRowIndex, 0), "")
                        .paraAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            '将用户在rcfrmselectgxdm所选择的gxdm带入rcdatarid'
                            Me.rcDataGridView2.CurrentRow.Cells("ColGxdm").Value = .paraField1
                            Me.rcBindingSource2.EndEdit()
                            Me.rcDataGridView2.EndEdit()
                        End If
                    End With
            End Select
        End If
    End Sub

    Private Sub RcDataGridView2_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles rcDataGridView2.EditingControlShowing
        EditingControl2 = e.Control
        If Not EditingControl2.IsHandleCreated Then
            AddHandler EditingControl2.KeyDown, New KeyEventHandler(AddressOf EditingControl2_KeyDown)
        End If
        If Me.rcDataGridView2.CurrentCell.OwningColumn.Name = "ColGxdm" Then
            EditingControl2.CharacterCasing = CharacterCasing.Upper
        Else
            EditingControl2.CharacterCasing = CharacterCasing.Normal
        End If
    End Sub

    Private Sub EditingControl2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If Me.rcDataGridView2.Columns(Me.rcDataGridView2.CurrentCell.ColumnIndex).Name = "ColGxdm" Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF3KeyPress
                    With rcFrm
                        .paraOleDbConn = rcOleDbConn
                        .paraTableName = "rc_gxxx"
                        .paraField1 = "gxdm"
                        .paraField2 = "gxmc"
                        .paraField3 = "gxsm"
                        .paraCondition = ""
                        .paraOrderField = "gxsm"
                        .paraTitle = "生产工序"
                        .paraOldValue = ""
                        .paraAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            '将用户在rcfrmselectgxdm所选择的gxdm带入rcdatarid'
                            Me.rcDataGridView2.CurrentRow.Cells("ColGxdm").Value = .paraField1
                            Me.rcDataGridView2.EndEdit()
                            Me.rcBindingSource2.EndEdit()
                        End If
                    End With
                    e.Handled = True
            End Select
        End If
    End Sub

    Private Sub RcDataGridView2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles rcDataGridView2.Leave
        Me.rcDataGridView2.ClearSelection()
    End Sub

    Private Sub RcDataGridView2_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles rcDataGridView2.RowValidating
        If Not Me.rcDataGridView2.CurrentRow.IsNewRow Then
            Me.rcBindingSource2.EndEdit()
            Me.rcDataGridView2.EndEdit()
            SumJe()
        End If
    End Sub

#End Region

#Region "输出"

    Private Sub BtnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExport.Click, MnuiExport.Click
        '导出数据
        Exports2Excel(rcDataset.Tables("rc_bom"))
    End Sub

    Public Sub Exports2Excel(ByVal paraDataTable As DataTable)
        If paraDataTable.Rows.Count > 0 Then
            Try
                Me.Cursor = Cursors.WaitCursor
                Dim i, j As Integer
                Dim DataArray(paraDataTable.Rows.Count() - 1, paraDataTable.Columns.Count() - 1) As String
                Dim myExcel As New Microsoft.Office.Interop.Excel.Application
                For i = 0 To paraDataTable.Rows.Count() - 1
                    For j = 0 To paraDataTable.Columns.Count() - 1
                        If paraDataTable.Rows(i).Item(j).GetType.ToString <> "System.DBNull" Then
                            DataArray(i, j) = paraDataTable.Rows(i).Item(j)
                        Else
                            DataArray(i, j) = ""
                        End If
                    Next
                Next
                myExcel.Application.Workbooks.Add(True)
                myExcel.Visible = True
                For j = 0 To paraDataTable.Columns.Count() - 1
                    myExcel.Cells(1, j + 1) = paraDataTable.Columns(j).ColumnName
                Next
                myExcel.Range("A2").Resize(paraDataTable.Rows.Count, paraDataTable.Columns.Count).Value = DataArray
            Catch exp As Exception
                MessageBox.Show("数据导出失败！请查看是否已经安装了Excel。", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        Else
            MessageBox.Show("没有数据！", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

#End Region

#Region "新增"

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, MnuiNew.Click
        NewEvent()
    End Sub

    Private Sub NewEvent()
        Me.TxtParentCpdm.Text = ""
        Me.TxtParentCpmc.Text = ""
        Me.TxtParentDw.Text = ""
        If dtBom IsNot Nothing Then
            dtBom.Clear()
        End If
        If dtGx IsNot Nothing Then
            dtGx.Clear()
        End If
    End Sub
#End Region

#Region "保存事件"

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MnuiSave.Click
        If String.IsNullOrEmpty(Me.TxtParentCpdm.Text) Or dtBom.Rows.Count <= 0 Then
            Return
        End If
        Dim i As Integer
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "DELETE FROM pm_bom WHERE parentcpdm = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@parentcpdm", OleDbType.VarChar, 15).Value = Me.TxtParentCpdm.Text
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "INSERT INTO pm_bom (parentcpdm,childcpdm,sl,dj,je,bommemo) VALUES (?,?,?,?,?,?)"
            For i = 0 To rcDataset.Tables("rc_bom").Rows.Count - 1
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@parentcpdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtParentCpdm.Text)
                rcOleDbCommand.Parameters.Add("@childcpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("rc_bom").Rows(i).Item("childcpdm")).ToUpper
                rcOleDbCommand.Parameters.Add("@sl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_bom").Rows(i).Item("sl")
                rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_bom").Rows(i).Item("dj")
                rcOleDbCommand.Parameters.Add("@je", OleDbType.Numeric, 16).Value = rcDataset.Tables("rc_bom").Rows(i).Item("je")
                rcOleDbCommand.Parameters.Add("@bommemo", OleDbType.VarChar, 50).Value = rcDataset.Tables("rc_bom").Rows(i).Item("bommemo")
                rcOleDbCommand.ExecuteNonQuery()
            Next
            rcOleDbCommand.CommandText = "DELETE FROM pm_gx WHERE parentcpdm = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@parentcpdm", OleDbType.VarChar, 15).Value = Me.TxtParentCpdm.Text
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "INSERT INTO pm_gx (parentcpdm,xh,gxdm,gxmc,bmdm,bmmc,gongshi,xishu,rgcb) VALUES (?,?,?,?,?,?,?,?,?)"
            For i = 0 To rcDataset.Tables("rc_gx").Rows.Count - 1
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@parentcpdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtParentCpdm.Text)
                rcOleDbCommand.Parameters.Add("@xh", OleDbType.Numeric, 4).Value = i + 1
                rcOleDbCommand.Parameters.Add("@gxdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rc_gx").Rows(i).Item("gxdm")
                rcOleDbCommand.Parameters.Add("@gxmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("rc_gx").Rows(i).Item("gxmc")
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rc_gx").Rows(i).Item("bmdm")
                rcOleDbCommand.Parameters.Add("@bmmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("rc_gx").Rows(i).Item("bmmc")
                rcOleDbCommand.Parameters.Add("@gongshi", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_gx").Rows(i).Item("gongshi")
                rcOleDbCommand.Parameters.Add("@xishu", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_gx").Rows(i).Item("xishu")
                rcOleDbCommand.Parameters.Add("@rgcb", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_gx").Rows(i).Item("rgcb")
                rcOleDbCommand.ExecuteNonQuery()
            Next
            rcOleDbCommand.CommandText = "UPDATE rc_cpxx SET bzcb = ?,clcb = ?,rgcb = ?,nycb = ?,zjcb = ?,glcb= ?,chengpinlv = ?,beishu = ? WHERE cpdm = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@bzcb", OleDbType.Numeric, 18).Value = Me.NudBzcb.Value
            rcOleDbCommand.Parameters.Add("@clcb", OleDbType.Numeric, 16).Value = Me.NudClcb.Value
            rcOleDbCommand.Parameters.Add("@rgcb", OleDbType.Numeric, 16).Value = Me.NudRgcb.Value
            rcOleDbCommand.Parameters.Add("@nycb", OleDbType.Numeric, 16).Value = Me.NudNycb.Value
            rcOleDbCommand.Parameters.Add("@zjcb", OleDbType.Numeric, 16).Value = Me.NudZjcb.Value
            rcOleDbCommand.Parameters.Add("@glcb", OleDbType.Numeric, 16).Value = Me.NudGlcb.Value
            rcOleDbCommand.Parameters.Add("@chengpinlv", OleDbType.Numeric, 6).Value = Me.NudChengPinLv.Value
            rcOleDbCommand.Parameters.Add("@beishu", OleDbType.Numeric, 12).Value = Me.NudBeiShu.Value
            rcOleDbCommand.Parameters.Add("@parentcpdm", OleDbType.VarChar, 15).Value = Me.TxtParentCpdm.Text
            rcOleDbCommand.ExecuteNonQuery()
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
        NewEvent()
    End Sub

#End Region

#Region "复制事件"

    Private Sub BtnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCopy.Click
        If String.IsNullOrEmpty(Me.TxtParentCpdm.Text) Or dtBom.Rows.Count <= 0 Then
            Return
        End If
        '调用表单
        Dim rcFrm As New FrmBomCopy
        With rcFrm
            If .ShowDialog() = DialogResult.OK Then
                Try
                    rcOleDbConn.Open()
                    rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.Transaction = rcOleDbTrans
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    rcOleDbCommand.CommandText = "INSERT INTO pm_bom (parentcpdm,childcpdm,sl,dj,je,bommemo) (SELECT '" & .TxtParentCpdm.Text & "' AS parentcpdm,childcpdm,sl,dj,je,bommemo FROM pm_bom WHERE parentcpdm = '" & Me.TxtParentCpdm.Text & "')"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "INSERT INTO pm_gx (parentcpdm,xh,gxdm,gxmc,bmdm,bmmc,gongshi,xishu,rgcb) (SELECT '" & .TxtParentCpdm.Text & "' AS parentcpdm,xh,gxdm,gxmc,bmdm,bmmc,gongshi,xishu,rgcb FROM pm_gx WHERE parentcpdm = '" & Me.TxtParentCpdm.Text & "')"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
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
                NewEvent()
            End If
        End With
        Me.rcDataGridView1.Focus()
    End Sub

#End Region

#Region "删除事件"

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, MnuiDelete.Click
        If String.IsNullOrEmpty(Me.TxtParentCpdm.Text) Then
            Return
        End If
        If MsgBox("您是否要删除该物料清单", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "提示信息") = MsgBoxResult.Yes Then
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "DELETE FROM pm_bom WHERE parentcpdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@parentcpdm", OleDbType.VarChar, 15).Value = Me.TxtParentCpdm.Text
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "DELETE FROM pm_gx WHERE parentcpdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@parentcpdm", OleDbType.VarChar, 15).Value = Me.TxtParentCpdm.Text
                rcOleDbCommand.ExecuteNonQuery()
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
            NewEvent()
        End If
    End Sub

#End Region

#Region "插入DataGridView行事件"

    Private Sub BtnIns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInsRow.Click, MnuiInsRow.Click
        If Me.rcDataGridView1.ReadOnly = False Then
            If dtBom.Rows.Count > 0 Then
                Dim row As DataRow = dtBom.NewRow
                dtBom.Rows.InsertAt(row, rcDataGridView1.CurrentCell.RowIndex)
                dtBom.AcceptChanges()
            End If
        End If
    End Sub

#End Region

#Region "删除DataGridView行事件"

    Private Sub BtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelRow.Click, MnuiDelRow.Click
        If Me.rcDataGridView1.ReadOnly = False Then
            If dtBom.Rows.Count > 0 And dtBom.Rows.Count > rcDataGridView1.CurrentRow.Index Then
                dtBom.Rows(rcDataGridView1.CurrentRow.Index).Delete()
                dtBom.AcceptChanges()
            End If
        End If
    End Sub
#End Region

#Region "读入excel"

    Private Sub BtnImpXls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiImpXls.Click
        '调用表单
        Dim rcFrm As New FrmBomImpXls
        With rcFrm
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

#End Region

#Region "退出表单事件"

    Private Sub MnuiExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiExit.Click, BtnExit.Click
        Me.Close()
    End Sub

#End Region

    Private Sub NudChengPinLv_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles NudChengPinLv.Validating, NudBeiShu.Validating
        Sumje()
    End Sub
End Class