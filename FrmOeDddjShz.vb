Imports System.Data.OleDb

Public Class FrmOeDddjShz
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
    ReadOnly EditingControl As DataGridViewTextBoxEditingControl

    Public Property ParaDataSet() As DataSet
        Get
            ParaDataSet = rcDataset
        End Get
        Set(ByVal Value As DataSet)
            rcDataset = Value
        End Set
    End Property

    Private Sub FrmOeDddjShz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '����DataGridView
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
        Me.rcDataGridView.Columns("ColBzcb").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColBzcb").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColLastBzcb").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColLastBzcb").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColClcb").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColClcb").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColLastClcb").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColLastClcb").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColRgcb").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColRgcb").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColLastRgcb").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColLastRgcb").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColGlcb").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColGlcb").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColLastGlcb").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColLastGlcb").DefaultCellStyle.Format = g_FormatJe
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

    Private Sub RcDataGridView_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles rcDataGridView.CellFormatting
        If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColBzcb" Then
            If e.Value IsNot Nothing Then
                'If e.Value = 0.0 Then
                '    Me.rcDataGridView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.YellowGreen
                'End If
                If e.Value >= Me.rcDataGridView.Rows(e.RowIndex).Cells("ColDj").Value Then
                    Me.rcDataGridView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
                End If
            End If
        End If

    End Sub

    Private Sub RcDataGridView_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles rcDataGridView.CellValidating
        If Me.rcDataGridView.CurrentRow.IsNewRow = False Then
            If rcDataGridView.IsCurrentCellDirty Then
                rcDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColBzcb" Then
                If e.FormattedValue IsNot Nothing Then
                    If e.FormattedValue >= Me.rcDataGridView.Rows(e.RowIndex).Cells("ColDj").Value Then
                        Me.rcDataGridView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
                    Else
                        Me.rcDataGridView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
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
        '����
        For i = 0 To rcDataSet.Tables("rc_ddnr").Rows.Count - 1
            If rcDataSet.Tables("rc_ddnr").Rows(i).Item("bzcb") <> 0 Or rcDataSet.Tables("rc_ddnr").Rows(i).Item("clcb") <> 0 Or rcDataSet.Tables("rc_ddnr").Rows(i).Item("rgcb") <> 0 Or rcDataSet.Tables("rc_ddnr").Rows(i).Item("glcb") <> 0 Then
                Try
                    rcOleDbConn.Open()
                    rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)        ' Start a local transaction
                    rcOleDbCommand.Connection = rcOleDbConn        ' Assign transaction object for a pending local transaction
                    rcOleDbCommand.Transaction = rcOleDbTrans
                    rcOleDbCommand.CommandType = CommandType.Text
                    rcOleDbCommand.CommandText = "UPDATE oe_dd SET bzcb = ? ,clcb = ? ,rgcb = ?,glcb = ? WHERE djh = ? and xh = ? and cpdm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@bzcb", OleDbType.Numeric, 18).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("bzcb")
                    rcOleDbCommand.Parameters.Add("@clcb", OleDbType.Numeric, 14).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("clcb")
                    rcOleDbCommand.Parameters.Add("@rgcb", OleDbType.Numeric, 14).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("rgcb")
                    rcOleDbCommand.Parameters.Add("@glcb", OleDbType.Numeric, 14).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("glcb")
                    rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("djh")
                    rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("xh")
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataSet.Tables("rc_ddnr").Rows(i).Item("cpdm"))
                    rcOleDbCommand.ExecuteNonQuery()
                    If rcDataSet.Tables("rc_ddnr").Rows(i).Item("bzcb").GetType.ToString <> "System.DBNull" Then
                        If rcDataSet.Tables("rc_ddnr").Rows(i).Item("bzcb") <> 0 Then
                            'rcOleDbCommand.CommandText = "SELECT * FROM rc_cpxx WHERE rc_cpxx.cpdm = ?"
                            'rcOleDbCommand.Parameters.Clear()
                            'rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataSet.Tables("rc_ddnr").Rows(i).Item("cpdm"))
                            'rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            'If Not rcDataSet.Tables("rc_cpxx") Is Nothing Then
                            '    rcDataSet.Tables("rc_cpxx").Clear()
                            'End If
                            'rcOleDbDataAdpt.Fill(rcDataSet, "rc_cpxx")
                            'If rcDataSet.Tables("rc_cpxx").Rows.Count = 1 Then
                            '    If rcDataSet.Tables("rc_cpxx").Rows(0).Item("bzcb").GetType.ToString <> "System.DBNull" Then
                            '        If rcDataSet.Tables("rc_cpxx").Rows(0).Item("bzcb") <> rcDataSet.Tables("rc_ddnr").Rows(i).Item("bzcb") And rcDataSet.Tables("rc_cpxx").Rows(0).Item("bzcb") <> 0.0 Then
                            '            If MsgBox("��Ʒ����" & rcDataSet.Tables("rc_ddnr").Rows(i).Item("cpdm") & "�Ѵ��ڱ�׼�ɱ���" & rcDataSet.Tables("rc_cpxx").Rows(0).Item("bzcb") & Chr(13) & "�Ƿ���³��µ�", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "��ʾ��Ϣ") = MsgBoxResult.No Then
                            '                blnUpdBzcb = False
                            '            End If
                            '        End If
                            '    End If
                            'End If
                            'If blnUpdBzcb Then
                            rcOleDbCommand.CommandText = "UPDATE rc_cpxx SET bzcb = ? WHERE rc_cpxx.cpdm = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@bzcb", OleDbType.Numeric, 18).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("bzcb")
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataSet.Tables("rc_ddnr").Rows(i).Item("cpdm"))
                            rcOleDbCommand.ExecuteNonQuery()
                            'End If
                        End If
                    End If
                    If rcDataSet.Tables("rc_ddnr").Rows(i).Item("clcb").GetType.ToString <> "System.DBNull" Then
                        If rcDataSet.Tables("rc_ddnr").Rows(i).Item("clcb") <> 0 Then
                            rcOleDbCommand.CommandText = "UPDATE rc_cpxx SET clcb = ? WHERE rc_cpxx.cpdm = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@clcb", OleDbType.Numeric, 14).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("clcb")
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataSet.Tables("rc_ddnr").Rows(i).Item("cpdm"))
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    If rcDataSet.Tables("rc_ddnr").Rows(i).Item("rgcb").GetType.ToString <> "System.DBNull" Then
                        If rcDataSet.Tables("rc_ddnr").Rows(i).Item("rgcb") <> 0 Then
                            rcOleDbCommand.CommandText = "UPDATE rc_cpxx SET rgcb = ? WHERE rc_cpxx.cpdm = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@rgcb", OleDbType.Numeric, 14).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("rgcb")
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataSet.Tables("rc_ddnr").Rows(i).Item("cpdm"))
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    If rcDataSet.Tables("rc_ddnr").Rows(i).Item("glcb").GetType.ToString <> "System.DBNull" Then
                        If rcDataSet.Tables("rc_ddnr").Rows(i).Item("glcb") <> 0 Then
                            rcOleDbCommand.CommandText = "UPDATE rc_cpxx SET glcb = ? WHERE rc_cpxx.cpdm = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@glcb", OleDbType.Numeric, 14).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("glcb")
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataSet.Tables("rc_ddnr").Rows(i).Item("cpdm"))
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
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

    Private Sub BtnBom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBom.Click
        Dim rcFrm As New FrmOeDddjShBom
        With rcFrm
            .ParaStrCpdm = rcDataset.Tables("rc_ddnr").Rows(rcDataGridView.CurrentRow.Index).Item("cpdm")
            .ShowDialog()
            rcDataSet.Tables("rc_ddnr").Rows(rcDataGridView.CurrentRow.Index).Item("bzcb") = .NudBzcb.Value
            rcDataSet.Tables("rc_ddnr").Rows(rcDataGridView.CurrentRow.Index).Item("clcb") = .NudClcb.Value
            rcDataSet.Tables("rc_ddnr").Rows(rcDataGridView.CurrentRow.Index).Item("rgcb") = .NudRgcb.Value
            rcDataSet.Tables("rc_ddnr").Rows(rcDataGridView.CurrentRow.Index).Item("glcb") = .NudGlcb.Value
        End With
    End Sub
End Class