Imports System.Data.OleDb

Public Class FrmMrpJs
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable '我们要利用该datatable进行金额计算
    ReadOnly dtBom As New DataTable("rc_bom")
    Dim dateKsrq As Date '成本结转开始日期
    Dim dateJsrq As Date '成本结转结束日期
    '
    Dim EditingControl As DataGridViewTextBoxEditingControl

#Region "初始化"

    Private Sub FrmMrpJs_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        Me.DtpRq.Value = g_Kjrq
        '设置DataGridView
        Me.rcDataGridView1.AutoGenerateColumns = False
        Me.rcDataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.rcDataGridView1.Columns("ColSl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Format = g_FormatSl
        '数据绑定
        dtBom.Columns.Add("ckdm", Type.GetType("System.String"))
        dtBom.Columns.Add("ckmc", Type.GetType("System.String"))
        dtBom.Columns.Add("bmdm", Type.GetType("System.String"))
        dtBom.Columns.Add("bmmc", Type.GetType("System.String"))
        dtBom.Columns.Add("cpdm", Type.GetType("System.String"))
        dtBom.Columns.Add("cpmc", Type.GetType("System.String"))
        dtBom.Columns.Add("dw", Type.GetType("System.String"))
        dtBom.Columns.Add("sl", Type.GetType("System.Double"))
        dtBom.Columns.Add("bommemo", Type.GetType("System.String"))
        rcDataset.Tables.Add(dtBom)
        With dtBom
            .Columns("ckdm").DefaultValue = ""
            .Columns("ckmc").DefaultValue = ""
            .Columns("bmdm").DefaultValue = ""
            .Columns("bmmc").DefaultValue = ""
            .Columns("cpdm").DefaultValue = ""
            .Columns("cpmc").DefaultValue = ""
            .Columns("dw").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("bommemo").DefaultValue = ""
        End With
        Me.rcBindingSource.DataSource = dtBom
        Me.rcDataGridView1.DataSource = Me.rcBindingSource
    End Sub

#End Region

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpRq.KeyPress, TxtZydm.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
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
        End If
    End Sub

#End Region

#Region "DataGridView的事件"

    Private Sub RcDataGridView_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles rcDataGridView1.CellValidating
        If Me.rcDataGridView1.CurrentRow.IsNewRow = False Then
            If Me.rcDataGridView1.IsCurrentCellDirty Then
                Me.rcDataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
            If Me.rcDataGridView1.Columns(e.ColumnIndex).Name = "ColCkdm" Then
                If Not String.IsNullOrEmpty(e.FormattedValue) Then
                    Try
                        '取物料信息
                        rcOleDbConn.Open()
                        rcOleDbCommand.Connection = rcOleDbConn
                        rcOleDbCommand.CommandTimeout = 300
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT ckdm,ckmc FROM rc_ckxx WHERE ckdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.AddWithValue("@ckdm", rcDataGridView1.Rows(rcDataGridView1.CurrentRow.Index).Cells("ColCkdm").EditedFormattedValue)
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_ckxx") IsNot Nothing Then
                            rcDataset.Tables("rc_ckxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_ckxx")
                    Catch ex As Exception
                        MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                    If rcDataset.Tables("rc_ckxx").Rows.Count > 0 Then
                        Me.rcDataGridView1.CurrentRow.Cells("ColCkdm").Value = rcDataset.Tables("rc_ckxx").Rows(0).Item("ckdm")
                        Me.rcDataGridView1.CurrentRow.Cells("ColCkmc").Value = rcDataset.Tables("rc_ckxx").Rows(0).Item("ckmc")
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub RcDataGridView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rcDataGridView1.KeyDown
        Select Case e.KeyCode
            Case Keys.C And e.Control
                '复制
                Clipboard.SetDataObject(Me.rcDataGridView1.GetClipboardContent())
            Case Keys.V And e.Control
                '粘贴
                Me.rcDataGridView1.CurrentCell.Value = Clipboard.GetText()
                Me.rcDataGridView1.EndEdit()
                Me.rcBindingSource.EndEdit()
        End Select
        If Me.rcDataGridView1.Columns(Me.rcDataGridView1.CurrentCell.ColumnIndex).Name = "ColCkdm" Then
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
                            Me.rcDataGridView1.CurrentRow.Cells("ColCpdm").Value = Trim(.paraField1)
                        End If
                    End With
            End Select
        End If
    End Sub

    Private Sub RcDataGridView_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles rcDataGridView1.EditingControlShowing
        EditingControl = e.Control
        If Not EditingControl.IsHandleCreated Then
            AddHandler EditingControl.KeyDown, New KeyEventHandler(AddressOf EditingControl_KeyDown)
        End If
        If Me.rcDataGridView1.CurrentCell.OwningColumn.Name = "ColCkdm" Then
            EditingControl.CharacterCasing = CharacterCasing.Upper
        Else
            EditingControl.CharacterCasing = CharacterCasing.Normal
        End If
    End Sub

    Private Sub EditingControl_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If Me.rcDataGridView1.Columns(Me.rcDataGridView1.CurrentCell.ColumnIndex).Name = "ColCkdm" Then
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
                            Me.rcDataGridView1.CurrentRow.Cells("ColCpdm").Value = Trim(.paraField1)
                        End If
                    End With
                    e.Handled = True
            End Select
        End If
    End Sub

    Private Sub RcDataGridView_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles rcDataGridView1.Leave
        Me.rcDataGridView1.ClearSelection()
    End Sub

    Private Sub RcDataGridView_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles rcDataGridView1.RowValidating
        If Not Me.rcDataGridView1.CurrentRow.IsNewRow Then
            Me.rcDataGridView1.EndEdit()
            Me.rcBindingSource.EndEdit()
        End If
    End Sub

#End Region

#Region "读入数据"

    Private Sub BtnImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImp.Click
        dateKsrq = Me.DtpRq.Value 'getInvBegin(Me.NudYear.Value, Me.NudMonth.Value)
        dateJsrq = Me.DtpRq.Value 'getInvEnd(Me.NudYear.Value, Me.NudMonth.Value)
        Me.BtnSavePo_cgd.Enabled = False
        Me.BtnSaveInv_ckd.Enabled = False
        Select Case True
            Case Me.RadioButton1.Checked
                '取数据
                Try
                    rcOleDbConn.Open()
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    rcOleDbCommand.CommandText = "SELECT abom.ckdm,rc_ckxx.ckmc,abom.cpdm,abom.cpmc,abom.dw,abom.sl,abom.bommemo FROM (SELECT rc_cpxx.ckdm,pm_bom.childcpdm AS cpdm,rc_cpxx.cpmc,rc_cpxx.dw,SUM(oe_dd.sl*pm_bom.sl) AS sl,pm_bom.bommemo FROM rc_cpxx,pm_bom,oe_dd WHERE rc_cpxx.cpdm = pm_bom.childcpdm AND pm_bom.parentcpdm = oe_dd.cpdm AND oe_dd.qdrq >= ? AND oe_dd.qdrq <= ? GROUP BY rc_cpxx.ckdm,pm_bom.childcpdm,rc_cpxx.cpmc,rc_cpxx.dw,pm_bom.bommemo) abom LEFT JOIN rc_ckxx ON rc_ckxx.ckdm = abom.ckdm ORDER BY abom.cpdm"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@qdrq", OleDbType.Date, 8).Value = dateKsrq
                    rcOleDbCommand.Parameters.Add("@qdrq", OleDbType.Date, 8).Value = dateJsrq
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataSet.Tables("rc_bom") IsNot Nothing Then
                        rcDataSet.Tables("rc_bom").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataSet, "rc_bom")
                    rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE kjnd = ? AND lxgs = '物料采购订单' ORDER BY pzlxdm"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataSet.Tables("rc_lx") IsNot Nothing Then
                        Me.rcDataSet.Tables("rc_lx").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataSet, "rc_lx")
                Catch ex As Exception
                    MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Finally
                    rcOleDbConn.Close()
                End Try
                If rcDataSet.Tables("rc_bom").Rows.Count > 0 Then
                    Me.BtnSavePo_cgd.Enabled = True
                End If
                '绑定凭证类型简称
                BindDropDownList(CmbPzlxjc, rcDataSet.Tables("rc_lx"), "pzlxdm", "pzlxjc")
            Case Me.RadioButton2.Checked
                '取数据
                Try
                    rcOleDbConn.Open()
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    rcOleDbCommand.CommandText = "SELECT abom.ckdm,rc_ckxx.ckmc,abom.bmdm,rc_bmxx.bmmc,abom.cpdm,abom.cpmc,abom.dw,abom.sl,abom.bommemo FROM (SELECT rc_cpxx.ckdm,inv_rkd.bmdm,pm_bom.childcpdm AS cpdm,rc_cpxx.cpmc,rc_cpxx.dw,SUM(inv_rkd.sl*pm_bom.sl) AS sl,pm_bom.bommemo FROM rc_cpxx,pm_bom,inv_rkd WHERE rc_cpxx.cpdm = pm_bom.childcpdm AND pm_bom.parentcpdm = inv_rkd.cpdm AND bmrp <> 1 AND inv_rkd.rkrq >= ? AND inv_rkd.rkrq <= ? GROUP BY rc_cpxx.ckdm,inv_rkd.bmdm,pm_bom.childcpdm,rc_cpxx.cpmc,rc_cpxx.dw,pm_bom.bommemo) abom LEFT JOIN rc_ckxx ON rc_ckxx.ckdm = abom.ckdm LEFT JOIN rc_bmxx ON rc_bmxx.bmdm = abom.bmdm ORDER BY abom.cpdm"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataSet.Tables("rc_bom") IsNot Nothing Then
                        rcDataSet.Tables("rc_bom").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataSet, "rc_bom")
                    rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE kjnd = ? AND lxgs = '物料出库单' ORDER BY pzlxdm"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataSet.Tables("rc_lx") IsNot Nothing Then
                        Me.rcDataSet.Tables("rc_lx").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataSet, "rc_lx")
                Catch ex As Exception
                    MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Finally
                    rcOleDbConn.Close()
                End Try
                If rcDataSet.Tables("rc_bom").Rows.Count > 0 Then
                    Me.BtnSaveInv_ckd.Enabled = True
                End If
                If rcDataSet.Tables("rc_lx").Rows.Count = 0 Then
                    MsgBox("请定义单据类型。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                    Return
                End If
                '绑定凭证类型简称
                BindDropDownList(CmbPzlxjc, rcDataSet.Tables("rc_lx"), "pzlxdm", "pzlxjc")
        End Select
    End Sub

#End Region

#Region "保存为物料采购订单"

    Private Sub BtnSavePo_cgd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSavePo_cgd.Click
        '清空数据
        If rcDataSet.Tables("rc_bom") IsNot Nothing Then
            rcDataSet.Tables("rc_bom").Clear()
        End If
    End Sub

#End Region

#Region "保存为物料出库单"

    Private Sub BtnSaveInv_ckd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveInv_ckd.Click
        If String.IsNullOrEmpty(Me.TxtZydm.Text) Then
            MsgBox("职员编码不能为空。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        If String.IsNullOrEmpty(Me.LblZymc.Text) Then
            MsgBox("职员名称不能为空。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        Dim i As Integer
        Dim strKjqj As String = getInvKjqj(Me.DtpRq.Value)
        '数据检测
        For i = 0 To rcDataSet.Tables("rc_bom").Rows.Count - 1
            If rcDataSet.Tables("rc_bom").Rows(i).Item("ckdm").GetType.ToString = "System.DBNull" Then
                MsgBox("仓库编码不能为空。第" & (i + 1).ToString & "行。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
                Return
            End If
            If rcDataSet.Tables("rc_bom").Rows(i).Item("ckmc").GetType.ToString = "System.DBNull" Then
                MsgBox("仓库名称不能为空。第" & (i + 1).ToString & "行。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
                Return
            End If
        Next
        '
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            For i = 0 To rcDataSet.Tables("rc_bom").Rows.Count - 1
                If rcDataSet.Tables("rc_bom").Rows(i).Item("sl") <> 0 Then
                    rcOleDbCommand.CommandType = CommandType.StoredProcedure
                    '存储单据
                    rcOleDbCommand.CommandText = "USP_SAVE_INV_CKD"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                    rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & "00001"
                    rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                    rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = 1
                    rcOleDbCommand.Parameters.Add("@paraDateCkrq", OleDbType.Date, 8).Value = dateJsrq
                    rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                    rcOleDbCommand.Parameters.Add("@ParaStrCkdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rc_bom").Rows(i).Item("ckdm")
                    rcOleDbCommand.Parameters.Add("@paraStrCkmc", OleDbType.VarChar, 50).Value = rcDataSet.Tables("rc_bom").Rows(i).Item("ckmc")
                    rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rc_bom").Rows(i).Item("bmdm")
                    rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("rc_bom").Rows(i).Item("bmmc")
                    rcOleDbCommand.Parameters.Add("@paraStrZydm", OleDbType.VarChar, 12).Value = Me.TxtZydm.Text
                    rcOleDbCommand.Parameters.Add("@paraStrZymc", OleDbType.VarChar, 30).Value = Me.LblZymc.Text
                    rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("rc_bom").Rows(i).Item("cpdm")).ToUpper
                    rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 200).Value = rcDataSet.Tables("rc_bom").Rows(i).Item("cpmc")
                    rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = rcDataSet.Tables("rc_bom").Rows(i).Item("dw")
                    rcOleDbCommand.Parameters.Add("@paraStrKuwei", OleDbType.VarChar, 40).Value = ""
                    rcOleDbCommand.Parameters.Add("@paraStrHth", OleDbType.VarChar, 30).Value = ""
                    rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataSet.Tables("rc_bom").Rows(i).Item("sl")
                    rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = 0.0
                    rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = 0.0
                    rcOleDbCommand.Parameters.Add("@paraStrCkmemo", OleDbType.VarChar, 50).Value = rcDataSet.Tables("rc_bom").Rows(i).Item("bommemo")
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
            '更新inv_rkd bmrp标志
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "UPDATE inv_rkd SET bmrp = 1 WHERE rkrq = ? AND EXISTS (SELECT 1 FROM pm_bom WHERE pm_bom.sl <> 0 AND pm_bom.parentcpdm = inv_rkd.cpdm)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = Me.DtpRq.Value
            rcOleDbCommand.ExecuteNonQuery()
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
        '清空数据
        If rcDataSet.Tables("rc_bom") IsNot Nothing Then
            rcDataSet.Tables("rc_bom").Clear()
        End If
    End Sub

#End Region

#Region "退出表单事件"

    Private Sub MnuiExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiExit.Click, BtnExit.Click
        Me.Close()
    End Sub

#End Region
End Class