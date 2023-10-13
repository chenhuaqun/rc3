Imports System.Data.OleDb

Public Class FrmPmScGxlzk
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立dataview对象
    Dim rcDataView As New DataView
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Private Sub FrmPmScGxlzk_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '设置DataGridView
        Me.rcDataGridView.AutoGenerateColumns = False
        Me.rcDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColKcsl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColKcsl").DefaultCellStyle.Format = g_FormatSl
        'Me.rcDataGridView.Columns("ColDj").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'Me.rcDataGridView.Columns("ColDj").DefaultCellStyle.Format = g_FormatDj

    End Sub


#Region "读取数据事件"

    Private Sub BtnImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImp.Click
        Dim j As Integer
        '读取数据未分配首道工序订单
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT 0 as xz,oe_dd.djh,oe_dd.xh,oe_dd.qdrq,oe_dd.khdm,oe_dd.khmc,oe_dd.hth,oe_dd.cpdm,oe_dd.cpmc,oe_dd.dw,oe_dd.sl - oe_dd.hxsl - oe_dd.rksl AS sl,0.0 AS kcsl,oe_dd.khjhrq,oe_dd.curxh,oe_dd.curgxdm,oe_dd.curgxmc,oe_dd.curbmdm,oe_dd.curbmmc,oe_dd.lastxh,oe_dd.lastgxdm,oe_dd.lastgxmc,oe_dd.lastbmdm,oe_dd.lastbmmc FROM oe_dd WHERE NOT oe_dd.shr IS NULL AND oe_dd.sl - oe_dd.hxsl - oe_dd.rksl > 0 AND oe_dd.sl - oe_dd.hxsl - oe_dd.cksl > 0 AND oe_dd.curgxdm IS NULL ORDER BY oe_dd.djh,oe_dd.xh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_ddnr") IsNot Nothing Then
                rcDataset.Tables("rc_ddnr").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_ddnr")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_ddnr").Rows.Count <= 0 Then
            MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        For j = 0 To rcDataset.Tables("rc_ddnr").Rows.Count - 1
            '取数据
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                '取库存数量
                rcOleDbCommand.CommandText = "SELECT qcsl + idsl AS kcsl FROM inv_cpyeb WHERE kjnd = ? AND cpdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_ddnr").Rows(j).Item("cpdm")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("inv_cpyeb") IsNot Nothing Then
                    rcDataset.Tables("inv_cpyeb").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "inv_cpyeb")
                If rcDataset.Tables("inv_cpyeb").Rows.Count > 0 Then
                    If rcDataset.Tables("inv_cpyeb").Rows(0).Item("kcsl").GetType.ToString <> "System.DBNull" Then
                        rcDataset.Tables("rc_ddnr").Rows(j).Item("kcsl") = rcDataset.Tables("inv_cpyeb").Rows(0).Item("kcsl")
                    End If
                End If
                '取首道工序的序号，工序编码，工序名称
                rcOleDbCommand.CommandText = "SELECT xh,gxdm,gxmc,bmdm,bmmc FROM pm_gx WHERE parentcpdm = ? ORDER BY xh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_ddnr").Rows(j).Item("cpdm")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("pm_gx") IsNot Nothing Then
                    rcDataset.Tables("pm_gx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "pm_gx")
                If rcDataset.Tables("pm_gx").Rows.Count > 0 Then
                    If rcDataset.Tables("pm_gx").Rows(0).Item("xh").GetType.ToString <> "System.DBNull" Then
                        rcDataset.Tables("rc_ddnr").Rows(j).Item("curxh") = rcDataset.Tables("pm_gx").Rows(0).Item("xh")
                    End If
                    If rcDataset.Tables("pm_gx").Rows(0).Item("gxdm").GetType.ToString <> "System.DBNull" Then
                        rcDataset.Tables("rc_ddnr").Rows(j).Item("curgxdm") = rcDataset.Tables("pm_gx").Rows(0).Item("gxdm")
                    End If
                    If rcDataset.Tables("pm_gx").Rows(0).Item("gxmc").GetType.ToString <> "System.DBNull" Then
                        rcDataset.Tables("rc_ddnr").Rows(j).Item("curgxmc") = rcDataset.Tables("pm_gx").Rows(0).Item("gxmc")
                    End If
                    If rcDataset.Tables("pm_gx").Rows(0).Item("bmdm").GetType.ToString <> "System.DBNull" Then
                        rcDataset.Tables("rc_ddnr").Rows(j).Item("curbmdm") = rcDataset.Tables("pm_gx").Rows(0).Item("bmdm")
                    End If
                    If rcDataset.Tables("pm_gx").Rows(0).Item("bmmc").GetType.ToString <> "System.DBNull" Then
                        rcDataset.Tables("rc_ddnr").Rows(j).Item("curbmmc") = rcDataset.Tables("pm_gx").Rows(0).Item("bmmc")
                    End If
                    If rcDataset.Tables("pm_gx").Rows(rcDataset.Tables("pm_gx").Rows.Count - 1).Item("xh").GetType.ToString <> "System.DBNull" Then
                        rcDataset.Tables("rc_ddnr").Rows(j).Item("lastxh") = rcDataset.Tables("pm_gx").Rows(rcDataset.Tables("pm_gx").Rows.Count - 1).Item("xh")
                    End If
                    If rcDataset.Tables("pm_gx").Rows(rcDataset.Tables("pm_gx").Rows.Count - 1).Item("gxdm").GetType.ToString <> "System.DBNull" Then
                        rcDataset.Tables("rc_ddnr").Rows(j).Item("lastgxdm") = rcDataset.Tables("pm_gx").Rows(rcDataset.Tables("pm_gx").Rows.Count - 1).Item("gxdm")
                    End If
                    If rcDataset.Tables("pm_gx").Rows(rcDataset.Tables("pm_gx").Rows.Count - 1).Item("gxmc").GetType.ToString <> "System.DBNull" Then
                        rcDataset.Tables("rc_ddnr").Rows(j).Item("lastgxmc") = rcDataset.Tables("pm_gx").Rows(rcDataset.Tables("pm_gx").Rows.Count - 1).Item("gxmc")
                    End If
                    If rcDataset.Tables("pm_gx").Rows(rcDataset.Tables("pm_gx").Rows.Count - 1).Item("bmdm").GetType.ToString <> "System.DBNull" Then
                        rcDataset.Tables("rc_ddnr").Rows(j).Item("lastbmdm") = rcDataset.Tables("pm_gx").Rows(rcDataset.Tables("pm_gx").Rows.Count - 1).Item("bmdm")
                    End If
                    If rcDataset.Tables("pm_gx").Rows(rcDataset.Tables("pm_gx").Rows.Count - 1).Item("bmmc").GetType.ToString <> "System.DBNull" Then
                        rcDataset.Tables("rc_ddnr").Rows(j).Item("lastbmmc") = rcDataset.Tables("pm_gx").Rows(rcDataset.Tables("pm_gx").Rows.Count - 1).Item("bmmc")
                    End If
                End If
            Catch ex As Exception
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        Next
        rcDataView = New DataView(rcDataset.Tables("rc_ddnr"))
        rcDataGridView.DataSource = rcDataView
        rcDataView.AllowNew = False
    End Sub

#End Region

#Region "全选事件"

    Private Sub BtnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectAll.Click
        '汇总本次应付金额
        Dim i As Integer
        For i = 0 To rcDataset.Tables("rc_ddnr").Rows.Count - 1
            rcDataset.Tables("rc_ddnr").Rows(i).Item("xz") = True
        Next
    End Sub

#End Region

#Region "控键回车键的处理"

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

    '#Region "DataGridView的事件"

    '    Private Sub RcDataGridView_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles rcDataGridView.CellValidating
    '        If Me.rcDataGridView.CurrentRow.IsNewRow = False Then
    '            If rcDataGridView.IsCurrentCellDirty Then
    '                rcDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit)
    '            End If
    '            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColCurGxdm" Then
    '                If Not String.IsNullOrEmpty(e.FormattedValue) Then
    '                    '取产品信息
    '                    rcOleDbConn.Open()
    '                    rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
    '                    rcOleDbCommand.Connection = rcOleDbConn
    '                    rcOleDbCommand.Transaction = rcOleDbTrans
    '                    rcOleDbCommand.CommandTimeout = 300
    '                    rcOleDbCommand.CommandType = CommandType.Text
    '                    Try
    '                        rcOleDbCommand.CommandText = "SELECT * FROM rc_gxxx WHERE gxdm = ?"
    '                        rcOleDbCommand.Parameters.Clear()
    '                        rcOleDbCommand.Parameters.AddWithValue("@gxdm", rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCurGxdm").EditedFormattedValue)
    '                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
    '                        If Not rcDataSet.Tables("rc_gxxx") Is Nothing Then
    '                            rcDataSet.Tables("rc_gxxx").Clear()
    '                        End If
    '                        rcOleDbDataAdpt.Fill(rcDataSet, "rc_gxxx")
    '                        rcOleDbTrans.Commit()
    '                    Catch ex As Exception
    '                        Try
    '                            rcOleDbTrans.Rollback()
    '                            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
    '                        Catch ey As OleDbException
    '                            MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
    '                        End Try
    '                        Return
    '                    Finally
    '                        rcOleDbConn.Close()
    '                    End Try
    '                    If rcDataSet.Tables("rc_gxxx").Rows.Count > 0 Then
    '                        Me.rcDataGridView.CurrentRow.Cells("ColCurGxdm").Value = rcDataSet.Tables("rc_gxxx").Rows(0).Item("gxdm")
    '                        Me.rcDataGridView.CurrentRow.Cells("ColCurGxmc").Value = rcDataSet.Tables("rc_gxxx").Rows(0).Item("gxmc")
    '                    Else
    '                        Me.LblMsg.Text = "生产工序编码不存在。"
    '                        e.Cancel = True
    '                    End If
    '                End If
    '            End If
    '        End If
    '    End Sub

    '    Private Sub RcDataGridView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rcDataGridView.KeyDown
    '        Select Case e.KeyCode
    '            Case Keys.C And e.Control
    '                '复制
    '                Clipboard.SetDataObject(Me.rcDataGridView.GetClipboardContent())
    '            Case Keys.V And e.Control
    '                '粘贴
    '                Me.rcDataGridView.CurrentCell.Value = Clipboard.GetText()
    '                Me.rcDataGridView.EndEdit()
    '                Me.rcBindingSource.EndEdit()
    '        End Select
    '        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColCurGxdm" Then
    '            Select Case e.KeyCode
    '                Case Keys.F3
    '                    Dim rcFrm As New models.FrmF3KeyPress
    '                    With rcFrm
    '                        .paraOleDbConn = rcOleDbConn
    '                        .paraTableName = "rc_gxxx"
    '                        .paraField1 = "gxdm"
    '                        .paraField2 = "gxmc"
    '                        .paraField3 = "gxsm"
    '                        .paraOrderField = "gxdm"
    '                        .paraTitle = "工序"
    '                        .paraOldValue = ""
    '                        .paraAddName = ""
    '                        If .ShowDialog = DialogResult.OK Then
    '                            '将用户在rcfrmselectgxdm所选择的gxdm带入rcdatarid'
    '                            Me.rcDataGridView.CurrentRow.Cells("ColCurGxdm").Value = .paraField1
    '                            Me.rcDataGridView.EndEdit()
    '                            Me.rcBindingSource.EndEdit()
    '                        End If
    '                    End With
    '            End Select
    '        End If
    '    End Sub

    '    Private Sub RcDataGridView_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles rcDataGridView.EditingControlShowing
    '        EditingControl = e.Control
    '        If Not EditingControl.IsHandleCreated Then
    '            AddHandler EditingControl.KeyDown, New KeyEventHandler(AddressOf EditingControl_KeyDown)
    '        End If
    '        If Me.rcDataGridView.CurrentCell.OwningColumn.Name = "ColCurGxdm" Then
    '            EditingControl.CharacterCasing = CharacterCasing.Upper
    '        Else
    '            EditingControl.CharacterCasing = CharacterCasing.Normal
    '        End If
    '    End Sub

    '    Private Sub EditingControl_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
    '        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColCurGxdm" Then
    '            Select Case e.KeyCode
    '                Case Keys.F3
    '                    Dim rcFrm As New models.FrmF3KeyPress
    '                    With rcFrm
    '                        .paraOleDbConn = rcOleDbConn
    '                        .paraTableName = "rc_gxxx"
    '                        .paraField1 = "gxdm"
    '                        .paraField2 = "gxmc"
    '                        .paraField3 = "gxsm"
    '                        .paraOrderField = "gxdm"
    '                        .paraTitle = "工序"
    '                        .paraOldValue = ""
    '                        .paraAddName = ""
    '                        If .ShowDialog = DialogResult.OK Then
    '                            '将用户在rcfrmselectgxdm所选择的gxdm带入rcdatarid'
    '                            Me.rcDataGridView.CurrentRow.Cells("ColCurGxdm").Value = .paraField1
    '                            Me.rcDataGridView.EndEdit()
    '                            Me.rcBindingSource.EndEdit()
    '                        End If
    '                    End With
    '            End Select
    '        End If
    '    End Sub

    '    Private Sub RcDataGridView_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles rcDataGridView.Leave
    '        Me.rcDataGridView.ClearSelection()
    '    End Sub

    '    Private Sub RcDataGridView_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles rcDataGridView.RowValidating
    '        If Not Me.rcDataGridView.CurrentRow.IsNewRow Then
    '            Me.rcDataGridView.EndEdit()
    '            Me.rcBindingSource.EndEdit()
    '        End If
    '    End Sub

    '#End Region

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click, MnuiExit.Click
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim i As Integer
        'Dim blnUpdBzcb As Boolean = True
        '保存
        For i = 0 To rcDataSet.Tables("rc_ddnr").Rows.Count - 1
            If rcDataSet.Tables("rc_ddnr").Rows(i).Item("xz") Then
                If rcDataSet.Tables("rc_ddnr").Rows(i).Item("curgxdm").GetType.ToString <> "System.DBNull" Then
                    Try
                        rcOleDbConn.Open()
                        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)        ' Start a local transaction
                        rcOleDbCommand.Connection = rcOleDbConn        ' Assign transaction object for a pending local transaction
                        rcOleDbCommand.Transaction = rcOleDbTrans
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "UPDATE oe_dd SET curxh = ?,curgxdm = ?,curgxmc = ?,curbmdm = ?,curbmmc = ? WHERE djh = ? and xh = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@curxh", OleDbType.Integer, 4).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("curxh")
                        rcOleDbCommand.Parameters.Add("@curgxdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("curgxdm")
                        rcOleDbCommand.Parameters.Add("@curgxmc", OleDbType.VarChar, 30).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("curgxmc")
                        rcOleDbCommand.Parameters.Add("@curbmdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("curbmdm")
                        rcOleDbCommand.Parameters.Add("@curbmmc", OleDbType.VarChar, 30).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("curbmmc")
                        rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("djh")
                        rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("xh")
                        rcOleDbCommand.ExecuteNonQuery()
                        rcOleDbCommand.CommandText = "INSERT INTO pm_gxlz (dddjh,ddxh,hth,cpdm,cpmc,dw,sl,xh,gxdm,gxmc,bmdm,bmmc,bwg) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,0)"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@dddjh", OleDbType.VarChar, 15).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("djh")
                        rcOleDbCommand.Parameters.Add("@ddxh", OleDbType.Integer, 4).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("xh")
                        rcOleDbCommand.Parameters.Add("@hth", OleDbType.VarChar, 30).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("hth")
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("cpdm")
                        rcOleDbCommand.Parameters.Add("@cpmc", OleDbType.VarChar, 50).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("cpmc")
                        rcOleDbCommand.Parameters.Add("@dw", OleDbType.VarChar, 8).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("dw")
                        rcOleDbCommand.Parameters.Add("@sl", OleDbType.VarNumeric, 16).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("sl")
                        rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("curxh")
                        rcOleDbCommand.Parameters.Add("@gxdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("curgxdm")
                        rcOleDbCommand.Parameters.Add("@gxmc", OleDbType.VarChar, 30).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("curgxmc")
                        rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("curbmdm")
                        rcOleDbCommand.Parameters.Add("@bmmc", OleDbType.VarChar, 30).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("curbmmc")
                        rcOleDbCommand.ExecuteNonQuery()
                        rcOleDbTrans.Commit()
                    Catch ex As Exception
                        Try
                            rcOleDbTrans.Rollback()
                            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        Catch ey As OleDbException
                            MsgBox("程序错误。" + ey.Message)
                        End Try
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                End If
            End If
        Next
        MsgBox("保存完毕。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
        Me.Close()
    End Sub

End Class