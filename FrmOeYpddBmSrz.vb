Imports System.Data.OleDb
Public Class FrmOeYpddBmSrz

#Region "�������"
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    Dim rcDataset As New DataSet
    '��ʾҪ������Դִ�е� SQL ����
    Dim rcOleDbTrans As OleDbTransaction
    '��������
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    'DataGridViewTextBoxEditingControl
    Dim EditingControl As DataGridViewTextBoxEditingControl
    '������ӡ�ĵ�
    Dim rcRps As RPS.Document
#End Region

#Region "��ʼ��"

    Public Property ParaDataSet() As DataSet
        Get
            ParaDataSet = rcDataset
        End Get
        Set(ByVal Value As DataSet)
            rcDataset = Value
        End Set
    End Property

    Private Sub FrmOeYpddBmSrz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '����DataGridView
        Me.rcDataGridView.AutoGenerateColumns = False
        '������the DataGridview to the DataTable.
        rcBindingSource.DataSource = rcDataset.Tables("rc_ddnr")
        Me.rcDataGridView.DataSource = rcBindingSource
    End Sub

#End Region

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
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColBmdm" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    If Not String.IsNullOrEmpty(e.FormattedValue) Then
                        'ȡ��Ʒ��Ϣ
                        rcOleDbConn.Open()
                        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                        rcOleDbCommand.Connection = rcOleDbConn
                        rcOleDbCommand.Transaction = rcOleDbTrans
                        rcOleDbCommand.CommandTimeout = 300
                        rcOleDbCommand.CommandType = CommandType.Text
                        Try
                            rcOleDbCommand.CommandText = "SELECT * FROM rc_bmxx WHERE bmdm = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.AddWithValue("@bmdm", rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColBmdm").EditedFormattedValue)
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("rc_bmxx") IsNot Nothing Then
                                rcDataset.Tables("rc_bmxx").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "rc_bmxx")
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
                        If rcDataset.Tables("rc_bmxx").Rows.Count > 0 Then
                            Me.rcDataGridView.CurrentRow.Cells("ColBmdm").Value = rcDataset.Tables("rc_bmxx").Rows(0).Item("bmdm")
                            Me.rcDataGridView.CurrentRow.Cells("ColBmmc").Value = rcDataset.Tables("rc_bmxx").Rows(0).Item("bmmc")
                        Else
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
                '����
                Clipboard.SetDataObject(Me.rcDataGridView.GetClipboardContent())
            Case Keys.V And e.Control
                'ճ��
                Me.rcDataGridView.CurrentCell.Value = Clipboard.GetText()
                Me.rcDataGridView.EndEdit()
                Me.rcBindingSource.EndEdit()
        End Select
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColBmdm" Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF3KeyPress
                    With rcFrm
                        .paraOleDbConn = rcOleDbConn
                        .paraTableName = "rc_bmxx"
                        .paraField1 = "bmdm"
                        .paraField2 = "bmmc"
                        .paraField3 = "bmsm"
                        .paraOrderField = "bmdm"
                        .paraTitle = "����"
                        .paraOldValue = ""
                        .paraAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            '���û���rcfrmselectbmdm��ѡ���bmdm����rcdatarid'
                            Me.rcDataGridView.CurrentRow.Cells("ColBmdm").Value = .paraField1
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
        If Me.rcDataGridView.CurrentCell.OwningColumn.Name = "ColBmdm" Then
            EditingControl.CharacterCasing = CharacterCasing.Upper
        Else
            EditingControl.CharacterCasing = CharacterCasing.Normal
        End If
    End Sub

    Private Sub EditingControl_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColBmdm" Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF3KeyPress
                    With rcFrm
                        .paraOleDbConn = rcOleDbConn
                        .paraTableName = "rc_bmxx"
                        .paraField1 = "bmdm"
                        .paraField2 = "bmmc"
                        .paraField3 = "bmsm"
                        .paraOrderField = "bmdm"
                        .paraTitle = "����"
                        .paraOldValue = ""
                        .paraAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            '���û���rcfrmselectbmdm��ѡ���bmdm����rcdatarid'
                            Me.rcDataGridView.CurrentRow.Cells("ColBmdm").Value = .paraField1
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

#Region "��ӡ�¼�"

    Private Sub PageSetupEvent()
        Dim rcFrm As New models.FrmPageSetup
        With rcFrm
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = "SCJHZXD"
            .paraRpsName = "�����ƻ���ѯ��"
            .ShowDialog()
        End With
    End Sub

    Private Sub PrintEvent()
        If g_Demo = 1 Then
            MsgBox("�Բ�������������ܴ�ӡ��", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        PreparePrintData()
        Dim rcFrmPrint As New models.FrmPrint
        With rcFrmPrint
            .paraRps = rcRps
            .ShowDialog()
        End With
    End Sub

    Private Sub PreviewEvent()
        PreparePrintData()
        rcRps.Preview()
    End Sub

    Private Sub PreparePrintData()
        'Dim rft1 As String = CurDir() + "\reports\scjhzxd.csv"
        Dim rft As String = CurDir() + "\reports\scjhzxd.rft"
        If rcRps Is Nothing Then
            rcRps = New RPS.Document
        End If
        'rcRps.LoadCsvTemplate(rft1)
        'rcRps.SaveTemplate(rft)
        rcRps.LoadTemplate(rft)
        rcRps.Text(-1, 2) = "��λ��" + g_Dwmc
        rcRps.Text(-1, 5) = "��ӡ�ˣ�" + g_User_DspName
        Dim i As Integer
        Dim j As Integer
        For i = 0 To rcDataSet.Tables("rc_ddnr").Rows.Count - 1
            If rcDataSet.Tables("rc_ddnr").Rows(i).RowState <> 8 Then
                rcRps.Text(j + 1, 1) = Trim(rcDataSet.Tables("rc_ddnr").Rows(i).Item("hth"))
                rcRps.Text(j + 1, 2) = Trim(rcDataSet.Tables("rc_ddnr").Rows(i).Item("sgdh"))
                rcRps.Text(j + 1, 3) = Trim(rcDataSet.Tables("rc_ddnr").Rows(i).Item("cpdm"))
                rcRps.Text(j + 1, 4) = Trim(rcDataSet.Tables("rc_ddnr").Rows(i).Item("cpmc"))
                rcRps.Text(j + 1, 5) = Trim(rcDataSet.Tables("rc_ddnr").Rows(i).Item("cpgg"))
                rcRps.Text(j + 1, 6) = Trim(rcDataSet.Tables("rc_ddnr").Rows(i).Item("cpmemo"))
                rcRps.Text(j + 1, 7) = Trim(rcDataSet.Tables("rc_ddnr").Rows(i).Item("dw"))
                rcRps.Text(j + 1, 8) = Trim(rcDataSet.Tables("rc_ddnr").Rows(i).Item("khlh"))
                If Not rcDataSet.Tables("rc_ddnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 9) = Format(rcDataSet.Tables("rc_ddnr").Rows(i).Item("sl"), g_FormatSl)
                End If
                If Not rcDataSet.Tables("rc_ddnr").Rows(i).Item("bmdm").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 11) = Trim(rcDataSet.Tables("rc_ddnr").Rows(i).Item("bmdm"))
                End If
                If Not rcDataSet.Tables("rc_ddnr").Rows(i).Item("khjhrq").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 12) = rcDataSet.Tables("rc_ddnr").Rows(i).Item("khjhrq")
                End If
                If Not rcDataSet.Tables("rc_ddnr").Rows(i).Item("scjhrq").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 13) = rcDataSet.Tables("rc_ddnr").Rows(i).Item("scjhrq")
                End If
                rcRps.Text(j + 1, 14) = Trim(rcDataSet.Tables("rc_ddnr").Rows(i).Item("khdm"))
                rcRps.Text(j + 1, 15) = Trim(rcDataSet.Tables("rc_ddnr").Rows(i).Item("khmc"))
                rcRps.Text(j + 1, 16) = Trim(rcDataSet.Tables("rc_ddnr").Rows(i).Item("ddmemo"))
                i += 1
            End If
        Next
        'ȡRPS����
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps where rpsid = 'SCJHZXD'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_rps") IsNot Nothing Then
                rcDataSet.Tables("rc_rps").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_rps")
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Catch ey As OleDbException
                MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            End Try
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("rc_rps").Rows.Count > 0 Then
            '�趨ֵ
            rcRps.Scale = rcDataSet.Tables("rc_rps").Rows(0).Item("scale")
            rcRps.Orientation = rcDataSet.Tables("rc_rps").Rows(0).Item("orientation")
            rcRps.PaperWidth = rcDataSet.Tables("rc_rps").Rows(0).Item("paperwidth")
            rcRps.PaperHeight = rcDataSet.Tables("rc_rps").Rows(0).Item("paperheight")
            rcRps.PrinterLeft = rcDataSet.Tables("rc_rps").Rows(0).Item("printerleft")
            rcRps.PrinterTop = rcDataSet.Tables("rc_rps").Rows(0).Item("printertop")
        Else
            'Ĭ��ֵ
            rcRps.Scale = 100
            rcRps.Orientation = 1
        End If
    End Sub

    Private Sub MnuiPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPageSetup.Click
        PageSetupEvent()
    End Sub

    Private Sub MnuiPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPreview.Click
        PreviewEvent()
    End Sub

    Private Sub MnuiPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrint.Click
        PrintEvent()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        PrintEvent()
    End Sub

    Private Sub BtnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPreview.Click
        PreviewEvent()
    End Sub

#End Region

#Region "�����¼�"

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim i As Integer
        Dim rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
        For i = 0 To rcDataSet.Tables("rc_ddnr").Rows.Count - 1
            If rcDataSet.Tables("rc_ddnr").Rows(i).Item("bmdm").GetType.ToString <> "System.DBNull" Then
                If rcDataSet.Tables("rc_ddnr").Rows(i).Item("bmdm") <> "" Then
                    rcOleDbConn.Open()
                    rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)        ' Start a local transaction
                    rcOleDbCommand.Connection = rcOleDbConn        ' Assign transaction object for a pending local transaction
                    rcOleDbCommand.Transaction = rcOleDbTrans
                    Try
                        rcOleDbCommand.CommandText = "UPDATE oe_ypdd SET bmdm = ?,srr = ? WHERE djh = ? and xh = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("rc_ddnr").Rows(i).Item("bmdm")).ToUpper
                        rcOleDbCommand.Parameters.Add("@srr", OleDbType.VarChar, 30).Value = g_User_DspName
                        rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("djh")
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
            End If
        Next
        MsgBox("������ϣ����ӡ��ǰ�����ƻ���ѯ����", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "��ʾ��Ϣ")
    End Sub

#End Region

#Region "�˳��¼�"

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

#End Region
End Class