Imports System.Data.OleDb

Public Class FrmOeDddjShBom

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
    '建立DataGridViewTextBoxEditingControl对象
    Dim EditingControl As DataGridViewTextBoxEditingControl
    Dim strCpdm As String = ""

    Public Property ParaStrCpdm() As String
        Get
            ParaStrCpdm = strCpdm
        End Get
        Set(ByVal Value As String)
            strCpdm = Value
        End Set
    End Property

    Private Sub FrmOeDddjShBom_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        Me.rcBindingSource.DataSource = dtBom
        Me.rcDataGridView.DataSource = Me.rcBindingSource
        Me.TxtParentCpdm.Text = strCpdm
    End Sub

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtParentCpdm.KeyPress, TxtParentCpmc.KeyPress, TxtParentDw.KeyPress, NudBzcb.KeyPress, NudClcb.KeyPress, NudRgcb.KeyPress, NudGlcb.KeyPress
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
                rcOleDbCommand.CommandText = "SELECT pm_bom.childcpdm,rc_cpxx.cpmc AS childcpmc,rc_cpxx.dw AS childdw,pm_bom.sl,rc_cpxx.cgdj AS dj,pm_bom.sl * rc_cpxx.cgdj AS je,pm_bom.bommemo FROM rc_cpxx,pm_bom WHERE rc_cpxx.cpdm = pm_bom.childcpdm AND pm_bom.parentcpdm = ? ORDER BY pm_bom.childcpdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtParentCpdm.Text)
                If rcDataset.Tables("rc_bom") IsNot Nothing Then
                    rcDataset.Tables("rc_bom").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_bom")
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
                If rcDataset.Tables("parentcpxx").Rows(0).Item("glcb").GetType.ToString <> "System.DBNull" Then
                    Me.NudGlcb.Value = rcDataset.Tables("parentcpxx").Rows(0).Item("glcb")
                End If
            Else
                MsgBox("该物料编码不存在。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "DataGridView的事件"

    'Private Sub rcDataGridView_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles rcDataGridView.CellEnter
    '    '如果此单元格只读的话则发送回车键。
    '    If Me.rcDataGridView.CurrentCell.ReadOnly Then My.Computer.Keyboard.SendKeys("{Enter}")
    'End Sub

    Private Sub RcDataGridView_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles rcDataGridView.CellValidating
        If Me.rcDataGridView.CurrentRow.IsNewRow = False Then
            If Me.rcDataGridView.IsCurrentCellDirty Then
                Me.rcDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColChildCpdm" Then
                If Not String.IsNullOrEmpty(e.FormattedValue) Then
                    If Not String.IsNullOrEmpty(e.FormattedValue) Then
                        '取产品信息
                        Try
                            rcOleDbConn.Open()
                            rcOleDbCommand.Connection = rcOleDbConn
                            rcOleDbCommand.CommandTimeout = 300
                            rcOleDbCommand.CommandType = CommandType.Text
                            rcOleDbCommand.CommandText = "SELECT * FROM rc_cpxx WHERE cpdm = ? AND ty <> 1"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColChildCpdm").EditedFormattedValue
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                                rcDataset.Tables("rc_cpxx").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
                            If rcDataset.Tables("rc_cpxx").Rows.Count > 0 Then
                                Me.rcDataGridView.CurrentRow.Cells("ColChildCpdm").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("cpdm")
                                Me.rcDataGridView.CurrentRow.Cells("ColChildCpmc").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("cpmc")
                                Me.rcDataGridView.CurrentRow.Cells("ColChildDw").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("dw")
                                Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("cgdj")
                            Else
                                MsgBox("产品编码不存在。")
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
                    If Me.rcDataGridView.CurrentRow.Cells("ColDj").Value <> 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColJe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColDj").Value * e.FormattedValue, 2, MidpointRounding.AwayFromZero)
                    End If
                Else
                    Me.rcDataGridView.CurrentRow.Cells("ColSl").Value = 0.0
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColDj" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    If e.FormattedValue <> 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColJe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColSl").Value * e.FormattedValue, 2, MidpointRounding.AwayFromZero)
                    End If
                Else
                    Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = 0.0
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColJe" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    If e.FormattedValue <> 0 And Me.rcDataGridView.CurrentRow.Cells("ColSl").Value <> 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = System.Math.Round(e.FormattedValue / Me.rcDataGridView.CurrentRow.Cells("ColSl").Value, 6, MidpointRounding.AwayFromZero)
                    End If
                Else
                    Me.rcDataGridView.CurrentRow.Cells("ColJe").Value = 0.0
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
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColChildCpdm" Then
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
                            Me.rcDataGridView.CurrentRow.Cells("ColChildCpdm").Value = .paraField1
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
        If Me.rcDataGridView.CurrentCell.OwningColumn.Name = "ColChildCpdm" Then
            EditingControl.CharacterCasing = CharacterCasing.Upper
        Else
            EditingControl.CharacterCasing = CharacterCasing.Normal
        End If
    End Sub

    Private Sub EditingControl_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColChildCpdm" Then
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
                            Me.rcDataGridView.CurrentRow.Cells("ColChildCpdm").Value = .paraField1
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
            SumJe()
        End If
    End Sub

#End Region

#Region "计算合计数"

    Private Sub SumJe()
        '计算合计数
        If dtBom.Rows.Count > 0 Then
            Me.NudClcb.Value = dtBom.Compute("Sum(je)", "")
            Me.NudBzcb.Value = Me.NudClcb.Value + Me.NudRgcb.Value + Me.NudGlcb.Value
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
                rcOleDbCommand.Parameters.Add("@je", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_bom").Rows(i).Item("je")
                rcOleDbCommand.Parameters.Add("@bommemo", OleDbType.VarChar, 50).Value = rcDataset.Tables("rc_bom").Rows(i).Item("bommemo")
                rcOleDbCommand.ExecuteNonQuery()
            Next
            rcOleDbCommand.CommandText = "UPDATE rc_cpxx SET bzcb = ?,clcb = ?,rgcb = ?,glcb= ? WHERE cpdm = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@bzcb", OleDbType.Numeric, 18).Value = Me.NudBzcb.Value
            rcOleDbCommand.Parameters.Add("@clcb", OleDbType.Numeric, 14).Value = Me.NudClcb.Value
            rcOleDbCommand.Parameters.Add("@rgcb", OleDbType.Numeric, 14).Value = Me.NudRgcb.Value
            rcOleDbCommand.Parameters.Add("@glcb", OleDbType.Numeric, 14).Value = Me.NudGlcb.Value
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
        Me.Close()
    End Sub

#End Region

#Region "插入DataGridView行事件"

    Private Sub BtnIns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInsRow.Click, MnuiInsRow.Click
        If Me.rcDataGridView.ReadOnly = False Then
            If dtBom.Rows.Count > 0 Then
                Dim row As DataRow = dtBom.NewRow
                dtBom.Rows.InsertAt(row, rcDataGridView.CurrentCell.RowIndex)
                dtBom.AcceptChanges()
            End If
        End If
    End Sub

#End Region

#Region "删除DataGridView行事件"

    Private Sub BtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelRow.Click, MnuiDelRow.Click
        If Me.rcDataGridView.ReadOnly = False Then
            If dtBom.Rows.Count > 0 Then
                dtBom.Rows(rcDataGridView.CurrentRow.Index).Delete()
                dtBom.AcceptChanges()
            End If
        End If
    End Sub
#End Region

    Private Sub NudGlcb_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles NudGlcb.Validating, NudRgcb.Validating
        SumJe()
    End Sub

#Region "退出表单事件"

    Private Sub MnuiExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiExit.Click, BtnExit.Click
        Me.Close()
    End Sub

#End Region
End Class