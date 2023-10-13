Imports System.Data.OleDb

Public Class FrmPmDdGxPgz
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    Dim rcDataset As New DataSet
    '����dataview����
    Dim rcDataView As New DataView
    '��ʾҪ������Դִ�е� SQL ����
    Dim rcOleDbTrans As OleDbTransaction
    '��������
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '
    Dim EditingControl As DataGridViewTextBoxEditingControl

    Public Property ParaDataSet() As DataSet
        Get
            ParaDataSet = rcDataset
        End Get
        Set(ByVal Value As DataSet)
            rcDataset = Value
        End Set
    End Property

    Private Sub FrmPmDdGxPgz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '����DataGridView
        Me.rcDataGridView.AutoGenerateColumns = False
        Me.rcDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColMjsl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColMjsl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColFzsl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColFzsl").DefaultCellStyle.Format = g_FormatSl
        rcDataView = New DataView(rcDataset.Tables("rc_ddnr"))
        rcDataGridView.DataSource = rcDataView
        rcDataView.AllowNew = False
    End Sub

#Region "�ؼ��س����Ĵ���"

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

#Region "DataGridView���¼�"

    Private Sub RcDataGridView_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles rcDataGridView.CellValidating
        If Me.rcDataGridView.CurrentRow.IsNewRow = False Then
            If rcDataGridView.IsCurrentCellDirty Then
                rcDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColSczydm" Then
                If Not String.IsNullOrEmpty(e.FormattedValue) Then
                    'ȡ��Ʒ��Ϣ
                    rcOleDbConn.Open()
                    rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.Transaction = rcOleDbTrans
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    Try
                        rcOleDbCommand.CommandText = "SELECT * FROM rc_zyxx WHERE zydm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.AddWithValue("@zydm", rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColSczydm").EditedFormattedValue)
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_zyxx") IsNot Nothing Then
                            rcDataset.Tables("rc_zyxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_zyxx")
                        rcOleDbTrans.Commit()
                    Catch ex As Exception
                        Try
                            rcOleDbTrans.Rollback()
                            MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                        Catch ey As OleDbException
                            MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                        End Try
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                    If rcDataset.Tables("rc_zyxx").Rows.Count > 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColSczydm").Value = rcDataset.Tables("rc_zyxx").Rows(0).Item("zydm")
                        Me.rcDataGridView.CurrentRow.Cells("ColSczymc").Value = rcDataset.Tables("rc_zyxx").Rows(0).Item("zymc")
                    Else
                        Me.LblMsg.Text = "����ְԱ���벻���ڡ�"
                        e.Cancel = True
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub RcDataGridView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rcDataGridView.KeyDown
        Select Case e.KeyCode
            Case Keys.C And e.Control
                '����
                Clipboard.SetDataObject(Me.rcDataGridView.GetClipboardContent())
            Case Keys.V And e.Control
                'ճ��
                Me.rcDataGridView.CurrentCell.Value = Clipboard.GetText()
                Me.rcDataGridView.EndEdit()
                Me.rcBindingSource.EndEdit()
        End Select
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColSczydm" Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF3KeyPress
                    With rcFrm
                        .paraOleDbConn = rcOleDbConn
                        .paraTableName = "rc_zyxx"
                        .paraField1 = "zydm"
                        .paraField2 = "zymc"
                        .paraField3 = "zysm"
                        .paraOrderField = "zydm"
                        .paraTitle = "ְԱ"
                        .paraOldValue = ""
                        .paraAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            '���û���rcfrmselectzydm��ѡ���zydm����rcdatarid'
                            Me.rcDataGridView.CurrentRow.Cells("ColSczydm").Value = .paraField1
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
        If Me.rcDataGridView.CurrentCell.OwningColumn.Name = "ColSczydm" Then
            EditingControl.CharacterCasing = CharacterCasing.Upper
        Else
            EditingControl.CharacterCasing = CharacterCasing.Normal
        End If
    End Sub

    Private Sub EditingControl_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColSczydm" Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF3KeyPress
                    With rcFrm
                        .paraOleDbConn = rcOleDbConn
                        .paraTableName = "rc_zyxx"
                        .paraField1 = "zydm"
                        .paraField2 = "zymc"
                        .paraField3 = "zysm"
                        .paraOrderField = "zydm"
                        .paraTitle = "ְԱ"
                        .paraOldValue = ""
                        .paraAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            '���û���rcfrmselectzydm��ѡ���zydm����rcdatarid'
                            Me.rcDataGridView.CurrentRow.Cells("ColSczydm").Value = .paraField1
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
    End Sub

#End Region

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click, MnuiExit.Click
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim i As Integer
        'Dim blnUpdBzcb As Boolean = True
        '����
        For i = 0 To rcDataSet.Tables("rc_ddnr").Rows.Count - 1
            If rcDataSet.Tables("rc_ddnr").Rows(i).Item("scjhrq").GetType.ToString <> "System.DBNull" And rcDataSet.Tables("rc_ddnr").Rows(i).Item("sczydm").GetType.ToString <> "System.DBNull" Then
                Try
                    rcOleDbConn.Open()
                    rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)        ' Start a local transaction
                    rcOleDbCommand.Connection = rcOleDbConn        ' Assign transaction object for a pending local transaction
                    rcOleDbCommand.Transaction = rcOleDbTrans
                    rcOleDbCommand.CommandType = CommandType.Text
                    rcOleDbCommand.CommandText = "UPDATE pm_gxlz SET sczydm = ?,sczymc = ?,scjhrq = ? WHERE dddjh = ? and ddxh = ? and cpdm = ? AND xh = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@sczydm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("sczydm")
                    rcOleDbCommand.Parameters.Add("@sczymc", OleDbType.VarChar, 30).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("sczymc")
                    rcOleDbCommand.Parameters.Add("@scjhrq", OleDbType.Date, 8).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("scjhrq")
                    rcOleDbCommand.Parameters.Add("@dddjh", OleDbType.VarChar, 15).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("dddjh")
                    rcOleDbCommand.Parameters.Add("@ddxh", OleDbType.Integer, 4).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("ddxh")
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataSet.Tables("rc_ddnr").Rows(i).Item("cpdm"))
                    rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("xh")
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbTrans.Commit()
                Catch ex As Exception
                    Try
                        rcOleDbTrans.Rollback()
                        MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                    Catch ey As OleDbException
                        MsgBox("�������" + ey.Message)
                    End Try
                Finally
                    rcOleDbConn.Close()
                End Try
            End If
        Next
        MsgBox("������ϡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
        Me.Close()
    End Sub

End Class