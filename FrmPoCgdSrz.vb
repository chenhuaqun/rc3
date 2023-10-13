Imports System.Math
Imports System.Data.OleDb

Public Class FrmPoCgdSrz
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '��ʾҪ������Դִ�е� SQL ����
    Dim rcOleDbTrans As OleDbTransaction
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '����Datatable '����Ҫ���ø�datatable���н�����
    ReadOnly dtCgd As New DataTable("rc_cgdnr")
    '���ӵ��ݵı���
    Dim IsAdding As Boolean = False
    '�޸ĵ��ݵı���
    Dim IsEditing As Boolean = False
    '���ݰ�
    Dim rcBmb As BindingManagerBase
    '����ڼ�
    Dim strKjqj As String = g_Kjqj
    '��
    Dim strYear As String = ""
    '��
    Dim strMonth As String = ""
    '��ӡ�ĵ�
    Dim rcRps As RPS.Document = Nothing
    '
    Dim EditingControl As DataGridViewTextBoxEditingControl
    '�ϼƱ���
    Dim dblTotSl As Double = 0.0
    Dim dblTotFzsl As Double = 0.0
    Dim dblTotJe As Double = 0.0
    Dim dblTotSe As Double = 0.0
    '��ӡ��ʽ
    Dim blnhs As Boolean = False


#Region "�����ʼ��"

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

    Private Sub FrmCgdSrz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Me.rcDataGridView.Columns("ColHsdj").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColHsdj").DefaultCellStyle.Format = g_FormatDj
        Me.rcDataGridView.Columns("ColJe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColJe").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColShlv").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColShlv").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColSe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColSe").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColJese").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColJese").DefaultCellStyle.Format = g_FormatJe
        'ȡ������������
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE kjnd = ? AND lxgs = '���ϲɹ�����' ORDER BY pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = strYear
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_lx") IsNot Nothing Then
                Me.rcDataset.Tables("rc_lx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_lx")
        Catch ex As Exception
            MsgBox("�������1��" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_lx").Rows.Count = 0 Then
            MsgBox("�붨�嵥�����͡�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        '��ƾ֤���ͼ��
        BindDropDownList(CmbPzlxjc, rcDataset.Tables("rc_lx"), "pzlxdm", "pzlxjc")
        '����Ĭ��ֵ
        Dim i As Integer
        For i = 0 To rcDataset.Tables("rc_lx").Rows.Count - 1
            If rcDataset.Tables("rc_lx").Rows(i).Item("pzlxdm") = "CGDJ" Then
                Me.CmbPzlxjc.SelectedValue = "CGDJ"
                Exit For
            End If
        Next
        '���ݰ�
        dtCgd.Columns.Add("cpdm", Type.GetType("System.String"))
        dtCgd.Columns.Add("cpmc", Type.GetType("System.String"))
        dtCgd.Columns.Add("oldcpdm", Type.GetType("System.String"))
        dtCgd.Columns.Add("jhshrq", Type.GetType("System.DateTime"))
        dtCgd.Columns.Add("sl", Type.GetType("System.Double"))
        dtCgd.Columns.Add("dw", Type.GetType("System.String"))
        dtCgd.Columns.Add("mjsl", Type.GetType("System.Double"))
        dtCgd.Columns.Add("fzsl", Type.GetType("System.Double"))
        dtCgd.Columns.Add("fzdw", Type.GetType("System.String"))
        dtCgd.Columns.Add("dj", Type.GetType("System.Double"))
        dtCgd.Columns.Add("hsdj", Type.GetType("System.Double"))
        dtCgd.Columns.Add("je", Type.GetType("System.Double"))
        dtCgd.Columns.Add("shlv", Type.GetType("System.Double"))
        dtCgd.Columns.Add("se", Type.GetType("System.Double"))
        dtCgd.Columns.Add("jese", Type.GetType("System.Double"))
        dtCgd.Columns.Add("cgmemo", Type.GetType("System.String"))
        dtCgd.Columns.Add("cgjhdjh", Type.GetType("System.String"))
        dtCgd.Columns.Add("cgjhxh", Type.GetType("System.Int32"))
        rcDataset.Tables.Add(dtCgd)
        With rcDataset.Tables("rc_cgdnr")
            .Columns("cpdm").DefaultValue = ""
            .Columns("oldcpdm").DefaultValue = ""
            .Columns("jhshrq").DefaultValue = Now.Date.AddDays(7)
            .Columns("sl").DefaultValue = 0.0
            .Columns("mjsl").DefaultValue = 0.0
            .Columns("fzsl").DefaultValue = 0.0
            .Columns("dj").DefaultValue = 0.0
            .Columns("hsdj").DefaultValue = 0.0
            .Columns("je").DefaultValue = 0.0
            .Columns("shlv").DefaultValue = GetParaValue("��ֵ˰Ĭ��˰��", False)
            .Columns("se").DefaultValue = 0.0
            .Columns("jese").DefaultValue = 0.0
            .Columns("cgmemo").DefaultValue = ""
            .Columns("cgjhdjh").DefaultValue = ""
            .Columns("cgjhxh").DefaultValue = 0
        End With
        '������the DataGridview to the DataTable.
        rcBindingSource.DataSource = dtCgd
        Me.rcDataGridView.DataSource = rcBindingSource
        rcBmb = Me.BindingContext(rcDataset, "rc_cgdnr")
        strKjqj = strYear & strMonth.PadLeft(2, "0")
        NewEvent()
    End Sub
#End Region

#Region "���ÿؼ�"

    Private Sub SetControlEnableEvent()
        If IsEditing = True Then
            Me.CmbPzlxjc.Enabled = False
            Me.TxtDjh.Enabled = False
            Me.BtnNew.Enabled = False
            Me.BtnSave.Enabled = True
            Me.BtnCancel.Enabled = True
            Me.BtnExit.Enabled = False
            Me.MnuiNew.Enabled = False
            Me.MnuiSave.Enabled = True
            Me.MnuiCancel.Enabled = True
            Me.MnuiExit.Enabled = False
        Else
            If dtCgd.Rows.Count > 0 Then
                Me.CmbPzlxjc.Enabled = False
            Else
                Me.CmbPzlxjc.Enabled = True
            End If
            Me.TxtDjh.Enabled = True
            Me.BtnNew.Enabled = True
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

#Region "�ؼ��س����Ĵ���"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbPzlxjc.KeyPress, TxtDjh.KeyPress, DtpCgrq.KeyPress, TxtSgddh.KeyPress, TxtCsdm.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
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

#Region "�������͵��¼�"

    Private Sub CmbPzlxjc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbPzlxjc.Validated
        ShowNewDjh()
    End Sub

#End Region

#Region "���ݺŵ��¼�"

    Private Sub TxtDjh_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDjh.KeyDown
        Select Case e.KeyCode
            Case Keys.F7
                'ɾ�����һ�ŵ���
                '1.����������ӵ����򷵻�
                If IsAdding Then
                    Return
                End If
                '2.ɾ��
                If MsgBox("�Ƿ�Ҫɾ�����һ�ŵ��ݣ�", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "��ʾ��Ϣ") = MsgBoxResult.Ok Then
                    Try
                        rcOleDbConn.Open()
                        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                        rcOleDbCommand.Connection = rcOleDbConn
                        rcOleDbCommand.Transaction = rcOleDbTrans
                        rcOleDbCommand.CommandTimeout = 300
                        rcOleDbCommand.CommandType = CommandType.StoredProcedure
                        rcOleDbCommand.CommandText = "USP3_DELETE_PO_CGD"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = Trim(Me.TxtDjh.Text)
                        rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                        rcOleDbCommand.Parameters.Add("@pIntError", OleDbType.Integer, 4).Direction = ParameterDirection.Output
                        rcOleDbCommand.ExecuteNonQuery()
                        If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                            If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                                MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                                Return
                            End If
                        End If
                        rcOleDbTrans.Commit()
                    Catch ex As Exception
                        Try
                            rcOleDbTrans.Rollback()
                            MsgBox("�������" & Chr(13) & ex.Message & Chr(13) & rcOleDbCommand.Parameters("@pIntError").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                        Catch ey As OleDbException
                            MsgBox("�������" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                        End Try
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                Else
                    Return
                End If
                '3.��ʾ�µ���
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
        '��鵥�ݺ��Ƿ����
        If rcDataset.Tables("rc_pzno") Is Nothing Then
            Return
        End If
        '�ж����ӻ����޸�
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            If rcDataset.Tables("rc_pzno").Rows.Count > 0 Then
                If rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") >= Mid(Trim(Me.TxtDjh.Text), 11, 5) Then
                    '�޸ĵ���
                    rcOleDbCommand.CommandText = "SELECT po_cgd.djh,po_cgd.cgrq,po_cgd.sgddh,po_cgd.csdm,po_cgd.csmc,po_cgd.srr,po_cgd.shr FROM po_cgd WHERE NOT EXISTS (SELECT 1 FROM po_cgd WHERE po_cgd.rksl <> 0 AND po_cgd.djh = ?) AND po_cgd.djh = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.TxtDjh.Text
                    rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.TxtDjh.Text
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("rc_cgdnr") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_cgdnr").Clear()
                    End If
                    If rcDataset.Tables("rc_cgdml") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_cgdml").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "rc_cgdml")
                    If rcDataset.Tables("rc_cgdml").Rows.Count > 0 Then
                        If rcDataset.Tables("rc_cgdml").Rows(0).Item("shr").GetType.ToString <> "System.DBNull" Then
                            MsgBox("�õ����Ѿ���ˣ������޸ġ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                            TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                            IsAdding = True
                        Else
                            Me.DtpCgrq.Value = rcDataset.Tables("rc_cgdml").Rows(0).Item("cgrq")
                            If rcDataset.Tables("rc_cgdml").Rows(0).Item("sgddh").GetType.ToString <> "System.DBNull" Then
                                Me.TxtSgddh.Text = rcDataset.Tables("rc_cgdml").Rows(0).Item("sgddh")
                            Else
                                Me.TxtSgddh.Text = ""
                            End If
                            If rcDataset.Tables("rc_cgdml").Rows(0).Item("csdm").GetType.ToString <> "System.DBNull" Then
                                Me.TxtCsdm.Text = Trim(rcDataset.Tables("rc_cgdml").Rows(0).Item("csdm"))
                            Else
                                Me.TxtCsdm.Text = ""
                            End If
                            If rcDataset.Tables("rc_cgdml").Rows(0).Item("csmc").GetType.ToString <> "System.DBNull" Then
                                Me.LblCsmc.Text = rcDataset.Tables("rc_cgdml").Rows(0).Item("csmc")
                            Else
                                Me.LblCsmc.Text = ""
                            End If
                            '�޸ĵ���
                            rcOleDbCommand.CommandText = "SELECT po_cgd.cpdm,rc_cpxx.cpmc,rc_cpxx.oldcpdm,po_cgd.jhshrq,po_cgd.sl,po_cgd.dw,po_cgd.mjsl,po_cgd.fzsl,po_cgd.fzdw,po_cgd.dj,po_cgd.hsdj,po_cgd.je,po_cgd.shlv,po_cgd.se,po_cgd.je+po_cgd.se AS jese,po_cgd.cgmemo,po_cgd.cgjhdjh,po_cgd.cgjhxh FROM po_cgd,rc_cpxx WHERE po_cgd.cpdm = rc_cpxx.cpdm AND po_cgd.djh = ? ORDER BY po_cgd.xh"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = TxtDjh.Text
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("rc_cgdnr") IsNot Nothing Then
                                Me.rcDataset.Tables("rc_cgdnr").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "rc_cgdnr")
                            If rcDataset.Tables("rc_cgdnr").Rows.Count > 0 Then
                                If rcDataset.Tables("rc_cgdnr").Rows(0).Item("cgjhdjh").GetType.ToString <> "System.DBNull" Then
                                    Me.BtnImp.Enabled = False
                                    Me.rcDataGridView.AllowUserToAddRows = False
                                    'Me.ColCpdm.ReadOnly = True
                                    'Me.ColSl.ReadOnly = True
                                    Me.ColMjsl.ReadOnly = True
                                    Me.ColFzsl.ReadOnly = True
                                    Me.BtnIns.Enabled = False
                                End If
                            End If
                            Me.rcDataGridView.ClearSelection()
                            SumSlJe()
                            IsAdding = False
                        End If
                    Else
                        MsgBox("���ϲɹ��������������ϲɹ����������ڡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                        TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                        Return
                    End If
                Else
                    '��������
                    IsAdding = True
                End If
            End If
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
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

#Region "����ϼ���"

    Private Sub SumSlJe()
        '����ϼ���
        dblTotSl = 0.0
        dblTotFzsl = 0.0
        dblTotJe = 0.0
        dblTotSe = 0.0
        If dtCgd.Rows.Count > 0 Then
            dblTotSl = dtCgd.Compute("Sum(sl)", "")
            dblTotFzsl = dtCgd.Compute("Sum(fzsl)", "")
            dblTotJe = dtCgd.Compute("Sum(je)", "")
            dblTotSe = dtCgd.Compute("Sum(se)", "")
        End If
        Me.LblSl.Text = "�����ϼƣ�" + Format(dblTotSl, g_FormatSl)
        Me.LblFzsl.Text = "�������ϼƣ�" + Format(dblTotFzsl, g_FormatSl)
        Me.LblJe.Text = "���ϼƣ�" + Format(dblTotJe, g_FormatJe)
        Me.LblSe.Text = "˰��ϼƣ�" + Format(dblTotSe, g_FormatJe)
        Me.LblJese.Text = "��˰�ϼƣ�" + Format(dblTotJe + dblTotSe, g_FormatJe)
    End Sub

#End Region

#Region "�ɹ����ڵ��¼�"

    Private Sub DtpCgrq_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DtpCgrq.Validating
        Dim dateBegin As DateTime
        Dim dateEnd As DateTime
        dateBegin = GetInvBegin(strYear, strMonth)
        dateEnd = GetInvEnd(strYear, strMonth)
        If DtpCgrq.Value > dateEnd Or DtpCgrq.Value < dateBegin Then
            MsgBox("����������ڲ��ڵ�ǰ����ڼ��У��������롣", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            Me.DtpCgrq.Focus()
        End If
    End Sub

#End Region

#Region "��Ӧ�̱����¼�"

    Private Sub TxtCsdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCsdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_csxx"
                    .paraField1 = "csdm"
                    .paraField2 = "csmc"
                    .paraField3 = "cssm"
                    .paraTitle = "��Ӧ��"
                    .paraOldValue = ""
                    .paraAddName = ""
                    .paraOrderField = "csmc"
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtCsdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtCsdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCsdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtCsdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_csxx WHERE (csdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtCsdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_csxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_csxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_csxx")
            Catch ex As Exception
                MsgBox("������󡣶�ȡ��Ӧ�̱��롣" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_csxx").Rows.Count > 0 Then
                Me.TxtCsdm.Text = Trim(rcDataset.Tables("rc_csxx").Rows(0).Item("csdm"))
                Me.LblCsmc.Text = Trim(rcDataset.Tables("rc_csxx").Rows(0).Item("csmc"))
            Else
                e.Cancel = True
            End If
            IsEditing = True
            SetControlEnableEvent()
        End If
    End Sub

#End Region

#Region "DataGridView���¼�"

    'Private Sub rcDataGridView_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles rcDataGridView.CellEnter
    '    If Me.rcDataGridView.CurrentCell.ReadOnly Then My.Computer.Keyboard.SendKeys("{Enter}")
    'End Sub

    Private Sub RcDataGridView_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles rcDataGridView.CellValidating
        If Me.rcDataGridView.CurrentRow.IsNewRow = False Then
            If Me.rcDataGridView.IsCurrentCellDirty Then
                Me.rcDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColCpdm" Then
                If Not String.IsNullOrEmpty(e.FormattedValue) Then
                    'ȡ������Ϣ
                    Try
                        rcOleDbConn.Open()
                        rcOleDbCommand.Connection = rcOleDbConn
                        rcOleDbCommand.CommandTimeout = 300
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT rc_cpxx.cpdm,rc_cpxx.cpmc,rc_cpxx.oldcpdm,rc_cpxx.dw,rc_cpxx.mjsl,rc_cpxx.fzdw FROM rc_cpxx WHERE (rc_cpxx.cpdm = ? OR rc_cpxx.oldcpdm = ?)"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.AddWithValue("@cpdm", rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue)
                        rcOleDbCommand.Parameters.AddWithValue("@oldcpdm", rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue)
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                            rcDataset.Tables("rc_cpxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
                        '����δ�²ɹ�����������
                    Catch ex As Exception
                        MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                    If rcDataset.Tables("rc_cpxx").Rows.Count > 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColCpdm").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("cpdm")
                        Me.rcDataGridView.CurrentRow.Cells("ColCpmc").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("cpmc")
                        Me.rcDataGridView.CurrentRow.Cells("ColOldCpdm").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("oldcpdm")
                        Me.rcDataGridView.CurrentRow.Cells("ColDw").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("dw")
                        If rcDataset.Tables("rc_cpxx").Rows(0).Item("mjsl").GetType.ToString <> "System.DBNull" And Me.rcDataGridView.CurrentRow.Cells("ColMjsl").Value = 0 Then
                            Me.rcDataGridView.CurrentRow.Cells("ColMjsl").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("mjsl")
                        End If
                        If rcDataset.Tables("rc_cpxx").Rows(0).Item("fzdw").GetType.ToString <> "System.DBNull" Then
                            Me.rcDataGridView.CurrentRow.Cells("ColFzdw").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("fzdw")
                        End If
                        '��ȡ���һ�βɹ�����
                        If Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = 0 Then
                            If Not String.IsNullOrEmpty(Me.TxtCsdm.Text) Then
                                Try
                                    rcOleDbConn.Open()
                                    rcOleDbCommand.Connection = rcOleDbConn
                                    rcOleDbCommand.CommandTimeout = 300
                                    rcOleDbCommand.CommandType = CommandType.Text
                                    rcOleDbCommand.CommandText = "SELECT COALESCE(po_cscpcgdj.cgdj,0.0) AS cgdj FROM po_cscpcgdj WHERE (po_cscpcgdj.cpdm = ? AND po_cscpcgdj.csdm = ?)"
                                    rcOleDbCommand.Parameters.Clear()
                                    rcOleDbCommand.Parameters.AddWithValue("@cpdm", rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue)
                                    rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Me.TxtCsdm.Text
                                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                    If rcDataset.Tables("po_cscpcgdj") IsNot Nothing Then
                                        rcDataset.Tables("po_cscpcgdj").Clear()
                                    End If
                                    rcOleDbDataAdpt.Fill(rcDataset, "po_cscpcgdj")
                                Catch ex As Exception
                                    MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                                    Return
                                Finally
                                    rcOleDbConn.Close()
                                End Try
                                If rcDataset.Tables("po_cscpcgdj").Rows.Count > 0 Then
                                    Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = rcDataset.Tables("po_cscpcgdj").Rows(0).Item("cgdj")
                                    Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value = rcDataset.Tables("po_cscpcgdj").Rows(0).Item("cgdj") * (1 + Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value / 100)
                                End If
                            End If
                        End If
                    Else
                        Me.LblMsg.Text = "���ϱ��벻���ڡ�"
                        e.Cancel = True
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColSl" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    If Me.rcDataGridView.CurrentRow.Cells("ColDj").Value <> 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColJe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColDj").Value * e.FormattedValue, 2, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColSe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColDj").Value * e.FormattedValue * Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value / 100, 2, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColJese").Value = Me.rcDataGridView.CurrentRow.Cells("ColJe").Value + Me.rcDataGridView.CurrentRow.Cells("ColSe").Value
                    End If
                    If Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value <> 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColJese").Value = System.Math.Round(e.FormattedValue * Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value, 2, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColJe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColJese").Value / (1 + Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value / 100), 2, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColSe").Value = Me.rcDataGridView.CurrentRow.Cells("ColJese").Value - Me.rcDataGridView.CurrentRow.Cells("ColJe").Value
                    End If
                    If Me.rcDataGridView.CurrentRow.Cells("ColMjsl").Value <> 0 Then
                        If e.FormattedValue <> 0 Then
                            If Me.rcDataGridView.CurrentRow.Cells("ColFzsl").Value = 0 Then
                                Me.rcDataGridView.CurrentRow.Cells("ColFzsl").Value = e.FormattedValue * Me.rcDataGridView.CurrentRow.Cells("ColMjsl").Value
                            End If
                        End If
                    End If
                End If
                '�ɹ�����ֻ��С�ڵ���,���ܴ�����������
                If Me.rcDataGridView.CurrentRow.Cells("ColCgjhDjh").Value.GetType.ToString <> "System.DBNull" Then
                    If Me.rcDataGridView.CurrentRow.Cells("ColCgjhDjh").Value <> "" Then
                        Try
                            rcOleDbConn.Open()
                            rcOleDbCommand.Connection = rcOleDbConn
                            rcOleDbCommand.CommandTimeout = 300
                            rcOleDbCommand.CommandType = CommandType.Text
                            'ȡ���ϲɹ�/ά�����󵥵�����
                            rcOleDbCommand.CommandText = "SELECT COALESCE(SUM(sl),0.0) AS jhsl FROM po_cgjh WHERE djh = ? AND xh = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.rcDataGridView.CurrentRow.Cells("ColCgjhDjh").Value
                            rcOleDbCommand.Parameters.Add("@xh", OleDbType.Numeric, 4).Value = Me.rcDataGridView.CurrentRow.Cells("ColCgjhXh").Value
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("t_cgjh") IsNot Nothing Then
                                rcDataset.Tables("t_cgjh").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "t_cgjh")
                            'ȡ���ϲɹ��������Ѳɹ�����
                            rcOleDbCommand.CommandText = "SELECT COALESCE(SUM(sl),0.0) AS cgsl FROM po_cgd WHERE djh <> ? AND cgjhdjh = ? AND cgjhxh = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.TxtDjh.Text
                            rcOleDbCommand.Parameters.Add("@cgjhdjh", OleDbType.VarChar, 15).Value = Me.rcDataGridView.CurrentRow.Cells("ColCgjhDjh").Value
                            rcOleDbCommand.Parameters.Add("@cgjhxh", OleDbType.Numeric, 4).Value = Me.rcDataGridView.CurrentRow.Cells("ColCgjhXh").Value
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("t_cgd") IsNot Nothing Then
                                rcDataset.Tables("t_cgd").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "t_cgd")
                        Catch ex As Exception
                            MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                            Return
                        Finally
                            rcOleDbConn.Close()
                        End Try
                        If rcDataset.Tables("t_cgjh").Rows(0).Item("jhsl") - rcDataset.Tables("t_cgd").Rows(0).Item("cgsl") < e.FormattedValue And e.FormattedValue > 0 Then
                            If MsgBox("�ɹ��������������������Ƿ������", MsgBoxStyle.YesNo, "��ʾ��Ϣ") = MsgBoxResult.No Then
                                e.Cancel = True
                            End If
                        End If
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColMjsl" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    If e.FormattedValue <> 0 Then
                        If Me.rcDataGridView.CurrentRow.Cells("ColFzsl").Value = 0 Then
                            Me.rcDataGridView.CurrentRow.Cells("ColFzsl").Value = Me.rcDataGridView.CurrentRow.Cells("ColSl").Value * e.FormattedValue
                        End If
                    End If
                Else
                    Me.rcDataGridView.CurrentRow.Cells("ColMjsl").Value = 0.0
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColDj" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    If e.FormattedValue <> 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value = System.Math.Round(e.FormattedValue * (1 + Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value / 100), 6, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColJe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColSl").Value * e.FormattedValue, 2, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColSe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColSl").Value * e.FormattedValue * Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value / 100, 2, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColJese").Value = Me.rcDataGridView.CurrentRow.Cells("ColJe").Value + Me.rcDataGridView.CurrentRow.Cells("ColSe").Value
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColHsdj" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = System.Math.Round(e.FormattedValue / (1 + Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value / 100), 6, MidpointRounding.AwayFromZero)
                    Me.rcDataGridView.CurrentRow.Cells("ColJe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColSl").Value * e.FormattedValue / (1 + Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value / 100), 2, MidpointRounding.AwayFromZero)
                    Me.rcDataGridView.CurrentRow.Cells("ColJese").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColSl").Value * e.FormattedValue, 2, MidpointRounding.AwayFromZero)
                    Me.rcDataGridView.CurrentRow.Cells("ColSe").Value = Me.rcDataGridView.CurrentRow.Cells("ColJese").Value - Me.rcDataGridView.CurrentRow.Cells("ColJe").Value
                Else
                    Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value = 0.0
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColShlv" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    If Me.rcDataGridView.CurrentRow.Cells("ColJe").Value <> 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColJese").Value / Me.rcDataGridView.CurrentRow.Cells("ColSl").Value, 6, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value / (1 + e.FormattedValue / 100), 6, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColJe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColSl").Value * Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value / (1 + e.FormattedValue / 100), 2, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColSe").Value = Me.rcDataGridView.CurrentRow.Cells("ColJese").Value - Me.rcDataGridView.CurrentRow.Cells("ColJe").Value
                        'Me.rcDataGridView.CurrentRow.Cells("ColJese").Value = Me.rcDataGridView.CurrentRow.Cells("ColJe").Value + Me.rcDataGridView.CurrentRow.Cells("ColSe").Value
                    End If
                Else
                    Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value = GetParaValue("��ֵ˰Ĭ��˰��", False)
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColJe" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    If e.FormattedValue <> 0 And Me.rcDataGridView.CurrentRow.Cells("ColSl").Value <> 0 Then
                        If System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColDj").Value * Me.rcDataGridView.CurrentRow.Cells("ColSl").Value, 2, MidpointRounding.AwayFromZero) <> e.FormattedValue Then
                            Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = Round(e.FormattedValue / Me.rcDataGridView.CurrentRow.Cells("ColSl").Value, 6, MidpointRounding.AwayFromZero)
                            Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value = Round(Me.rcDataGridView.CurrentRow.Cells("ColDj").Value * (Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value / 100 + 1), 6, MidpointRounding.AwayFromZero)
                        End If
                        Me.rcDataGridView.CurrentRow.Cells("ColSe").Value = Me.rcDataGridView.CurrentRow.Cells("ColJese").Value - Me.rcDataGridView.CurrentRow.Cells("ColJe").Value
                        'Me.rcDataGridView.CurrentRow.Cells("ColJese").Value = e.FormattedValue + Me.rcDataGridView.CurrentRow.Cells("ColSe").Value
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColSe" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    If Me.rcDataGridView.CurrentRow.Cells("ColJe").Value <> 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColJese").Value = e.FormattedValue + Me.rcDataGridView.CurrentRow.Cells("ColJe").Value
                        'Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColJese").Value / Me.rcDataGridView.CurrentRow.Cells("ColSl").Value, 6, MidpointRounding.AwayFromZero)
                    End If
                Else
                    Me.rcDataGridView.CurrentRow.Cells("ColSe").Value = 0.0
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColJese" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    If Me.rcDataGridView.CurrentRow.Cells("ColSl").Value <> 0 And Me.rcDataGridView.CurrentRow.Cells("ColJe").Value + Me.rcDataGridView.CurrentRow.Cells("ColSe").Value <> e.FormattedValue Then
                        Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = Round(e.FormattedValue / Me.rcDataGridView.CurrentRow.Cells("ColSl").Value / (1 + Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value / 100), 6, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value = Round(e.FormattedValue / Me.rcDataGridView.CurrentRow.Cells("ColSl").Value, 6, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColJe").Value = Round(e.FormattedValue / (1 + Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value / 100), 2, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColSe").Value = e.FormattedValue - Me.rcDataGridView.CurrentRow.Cells("ColJe").Value
                    End If
                Else
                    Me.rcDataGridView.CurrentRow.Cells("ColJese").Value = 0.0
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
                        .paraTitle = "����"
                        .paraOldValue = ""
                        .paraAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            '���û���rcfrmselectcpdm��ѡ���cpdm����rcdatarid'
                            Me.rcDataGridView.CurrentRow.Cells("ColCpdm").Value = .paraField1
                            Me.rcDataGridView.EndEdit()
                            Me.rcBindingSource.EndEdit()
                        End If
                    End With
            End Select
        End If
        'If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColCsdm" And Me.ColCsdm.ReadOnly = False Then
        '    Select Case e.KeyCode
        '        Case Keys.F3
        '            Dim rcFrm As New models.FrmF3KeyPress
        '            With rcFrm
        '                .paraOleDbConn = rcOleDbConn
        '                .paraTableName = "rc_csxx"
        '                .paraField1 = "csdm"
        '                .paraField2 = "csmc"
        '                .paraField3 = "cssm"
        '                .paraCondition = "0=0"
        '                .paraOrderField = "csmc"
        '                .paraTitle = "��Ӧ��"
        '                .paraOldValue = ""
        '                .paraAddName = ""
        '                If .ShowDialog = DialogResult.OK Then
        '                    '���û���rcfrmselectcsdm��ѡ���csdm����rcdatarid'
        '                    Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value = .paraField1
        '                    Me.rcDataGridView.EndEdit()
        '                    Me.rcBindingSource.EndEdit()
        '                End If
        '            End With
        '    End Select
        'End If
    End Sub

    Private Sub RcDataGridView_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles rcDataGridView.EditingControlShowing
        EditingControl = e.Control
        If Not EditingControl.IsHandleCreated Then
            AddHandler EditingControl.KeyDown, New KeyEventHandler(AddressOf EditingControl_KeyDown)
        End If
        If Me.rcDataGridView.CurrentCell.OwningColumn.Name = "ColCpdm" Then 'Or Me.rcDataGridView.CurrentCell.OwningColumn.Name = "ColCsdm"
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
                        .paraTitle = "����"
                        .paraOldValue = ""
                        .paraAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            '���û���rcfrmselectcpdm��ѡ���cpdm����rcdatarid'
                            Me.rcDataGridView.CurrentRow.Cells("ColCpdm").Value = .paraField1
                            Me.rcDataGridView.EndEdit()
                            Me.rcBindingSource.EndEdit()
                        End If
                    End With
                    e.Handled = True
            End Select
        End If
        'If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColCsdm" And Me.ColCsdm.ReadOnly = False Then
        '    Select Case e.KeyCode
        '        Case Keys.F3
        '            Dim rcFrm As New models.FrmF3KeyPress
        '            With rcFrm
        '                .paraOleDbConn = rcOleDbConn
        '                .paraTableName = "rc_csxx"
        '                .paraField1 = "csdm"
        '                .paraField2 = "csmc"
        '                .paraField3 = "cssm"
        '                .paraCondition = "0=0"
        '                .paraOrderField = "csmc"
        '                .paraTitle = "��Ӧ��"
        '                .paraOldValue = ""
        '                .paraAddName = ""
        '                If .ShowDialog = DialogResult.OK Then
        '                    '���û���rcfrmselectcsdm��ѡ���csdm����rcdatarid'
        '                    Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value = .paraField1
        '                    Me.rcDataGridView.EndEdit()
        '                    Me.rcBindingSource.EndEdit()
        '                End If
        '            End With
        '            e.Handled = True
        '    End Select
        'End If
    End Sub

    Private Sub RcDataGridView_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles rcDataGridView.Leave
        Me.rcDataGridView.ClearSelection()
    End Sub

    Private Sub RcDataGridView_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles rcDataGridView.RowValidating
        If Not Me.rcDataGridView.CurrentRow.IsNewRow Then
            Me.rcDataGridView.EndEdit()
            Me.rcBindingSource.EndEdit()
        End If
        If dtCgd.Rows.Count > 0 Then
            IsEditing = True
            SetControlEnableEvent()
            SumSlJe()
        End If
    End Sub

#End Region

#Region "�������ϲɹ�/ά������"

    Private Sub BtnImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImp.Click
        If Not String.IsNullOrEmpty(Me.TxtCsdm.Text) Then
            Dim rcFrm As New FrmPoCgdImpCgjh
            With rcFrm
                .ParaStrCsdm = Me.TxtCsdm.Text
                .ParaDataSet = rcDataset
                .ShowDialog()
                Me.rcDataGridView.AllowUserToAddRows = False
                'Me.ColCpdm.ReadOnly = True
                'Me.ColSl.ReadOnly = True
                Me.ColMjsl.ReadOnly = True
                Me.ColFzsl.ReadOnly = True
                Me.BtnIns.Enabled = False
            End With
        Else
            MsgBox("����ѡ��Ӧ�̱��롣")
        End If
    End Sub

#End Region

#Region "�����Ʒ���۶���"

    Private Sub BtnImpDd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImpDd.Click
        If Not String.IsNullOrEmpty(Me.TxtCsdm.Text) Then
            Dim rcFrm As New FrmPoCgdImpDd
            With rcFrm
                .ParaStrCsdm = Me.TxtCsdm.Text
                .ParaDataSet = rcDataset
                .ShowDialog()
                Me.rcDataGridView.AllowUserToAddRows = False
                'Me.ColCpdm.ReadOnly = True
                'Me.ColSl.ReadOnly = True
                Me.ColMjsl.ReadOnly = True
                Me.ColFzsl.ReadOnly = True
                Me.BtnIns.Enabled = False
            End With
        Else
            MsgBox("����ѡ��Ӧ�̱��롣")
        End If
    End Sub

#End Region

#Region "�µ��¼�"

    Private Sub MnuiNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiNew.Click, BtnNew.Click
        NewEvent()
    End Sub

    Private Sub NewEvent()
        '�������
        Me.LblMsg.Text = "��ʾ��Ϣ��"
        Me.TxtCsdm.Text = ""
        Me.LblCsmc.Text = ""
        Me.TxtSgddh.Text = ""
        Me.BtnImp.Enabled = True
        Me.rcDataGridView.AllowUserToAddRows = True
        'Me.ColCpdm.ReadOnly = False
        'Me.ColSl.ReadOnly = False
        Me.ColMjsl.ReadOnly = False
        Me.ColFzsl.ReadOnly = False
        Me.BtnIns.Enabled = True
        '��ʾ�µ��ݺ�
        IsAdding = True
        IsEditing = False
        ShowNewDjh()
        'ȡ������ϵͳʱ��
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT SYSDATE FROM dual"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_sysdate") IsNot Nothing Then
                rcDataset.Tables("rc_sysdate").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_sysdate")
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_sysdate").Rows.Count = 1 Then
            Me.DtpCgrq.Value = rcDataset.Tables("rc_sysdate").Rows(0).Item("sysdate")
        Else
            Me.DtpCgrq.Value = Now()
        End If
        If GetInvKjqj(Me.DtpCgrq.Value) <> strKjqj Then
            DtpCgrq.Value = GetInvEnd(strYear, strMonth)
        End If
        '�������
        If rcDataset.Tables("rc_cgdnr") IsNot Nothing Then
            Me.rcDataset.Tables("rc_cgdnr").Clear()
        End If
    End Sub

    Private Sub ShowNewDjh()
        If Not IsEditing Then
            'ȡ������������
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT pzno" & strMonth & " As pzno FROM rc_lx WHERE kjnd = ? AND pzlxdm = ? and lxgs = '���ϲɹ�����'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = strYear
                rcOleDbCommand.Parameters.AddWithValue("@pzlxdm", Trim(Me.CmbPzlxjc.SelectedValue))
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_pzno") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_pzno").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_pzno")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_pzno").Rows.Count = 0 Then
                MsgBox("�붨�嵥�����͡�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            End If
            TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
        End If
    End Sub

#End Region

#Region "���浥�������¼�"

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MnuiSave.Click
        SaveEvent(False)
    End Sub

    Private Sub SaveEvent(ByVal blnPrint As Boolean)
        Dim i As Integer
        '(һ)���ݺϷ��Լ��
        '(1)�Ƿ�����Ҫ�洢������
        If rcDataset.Tables("rc_cgdnr").Rows.Count = 0 Then
            MsgBox("û����Ӧ��ҵ�������롣", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            Return
        End If
        '(5)DataTable��Ĭ��ֵ
        For i = 0 To rcDataset.Tables("rc_cgdnr").Rows.Count - 1
            If rcDataset.Tables("rc_cgdnr").Rows(i).Item("cpdm").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_cgdnr").Rows(i).Item("cpdm") = ""
            End If
            'If rcDataSet.Tables("rc_cgdnr").Rows(i).Item("csdm").GetType.ToString = "System.DBNull" Then
            '    rcDataSet.Tables("rc_cgdnr").Rows(i).Item("csdm") = ""
            'End If
            If rcDataset.Tables("rc_cgdnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_cgdnr").Rows(i).Item("sl") = 0.0
            End If
            If rcDataset.Tables("rc_cgdnr").Rows(i).Item("fzsl").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_cgdnr").Rows(i).Item("fzsl") = 0.0
            End If
            If rcDataset.Tables("rc_cgdnr").Rows(i).Item("dj").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_cgdnr").Rows(i).Item("dj") = 0.0
            End If
            If rcDataset.Tables("rc_cgdnr").Rows(i).Item("hsdj").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_cgdnr").Rows(i).Item("hsdj") = 0.0
            End If
            If rcDataset.Tables("rc_cgdnr").Rows(i).Item("je").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_cgdnr").Rows(i).Item("je") = 0.0
            End If
            If rcDataset.Tables("rc_cgdnr").Rows(i).Item("shlv").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_cgdnr").Rows(i).Item("shlv") = 0.0
            End If
            If rcDataset.Tables("rc_cgdnr").Rows(i).Item("se").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_cgdnr").Rows(i).Item("se") = 0.0
            End If
            If rcDataset.Tables("rc_cgdnr").Rows(i).Item("cgmemo").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_cgdnr").Rows(i).Item("cgmemo") = ""
            End If
        Next
        '(6)���ϱ�����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            For i = 0 To rcDataset.Tables("rc_cgdnr").Rows.Count - 1
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("rc_cgdnr").Rows(i).Item("cpdm"))
                rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_cpxx"
                rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "cpdm"
                rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
                rcOleDbCommand.Parameters.Add("@pIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
                rcOleDbCommand.ExecuteNonQuery()
                If rcOleDbCommand.Parameters.Item("@pIntRecordCount").Value <> 1 Then
                    MsgBox(Trim(rcDataset.Tables("rc_cgdnr").Rows(i).Item("cpdm")) & "���ϱ��벻��ȷ�����顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                    Return
                End If
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Me.TxtCsdm.Text
                rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_csxx"
                rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "csdm"
                rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
                rcOleDbCommand.Parameters.Add("@pIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
                rcOleDbCommand.ExecuteNonQuery()
                If rcOleDbCommand.Parameters.Item("@pIntRecordCount").Value <> 1 Then
                    MsgBox(Me.TxtCsdm.Text & "��Ӧ�̱��벻��ȷ�����顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                    Return
                End If
                If rcDataset.Tables("rc_cgdnr").Rows(i).Item("sl") = 0.0 Then
                    MsgBox("���ϱ��룺" & rcDataset.Tables("rc_cgdnr").Rows(i).Item("cpdm") & "��Ӧ������Ϊ���㡿�����顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                    Return
                End If
            Next
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '(7)���ݺų��ȼ��
        If Trim(Me.TxtDjh.Text).Length <> 15 Then
            MsgBox("���ݺų��Ȳ���ȷ�����顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
            Return
        End If

        '(��)�洢ml
        'djh,cgrq,srr
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP3_SAVE_PO_CGD"
            For i = 0 To rcDataset.Tables("rc_cgdnr").Rows.Count - 1
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = IIf(IsAdding, 1, 0)
                rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = TxtDjh.Text
                rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = i + 1
                rcOleDbCommand.Parameters.Add("@paraDateCgrq", OleDbType.Date, 8).Value = Me.DtpCgrq.Value
                rcOleDbCommand.Parameters.Add("@paraStrSgddh", OleDbType.VarChar, 20).Value = Me.TxtSgddh.Text
                rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = Me.TxtCsdm.Text
                rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = Me.LblCsmc.Text
                rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("rc_cgdnr").Rows(i).Item("cpdm")).ToUpper
                rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("rc_cgdnr").Rows(i).Item("cpmc")
                rcOleDbCommand.Parameters.Add("@paraDateJhshrq", OleDbType.Date, 8).Value = rcDataset.Tables("rc_cgdnr").Rows(i).Item("jhshrq")
                rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_cgdnr").Rows(i).Item("sl")
                rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = rcDataset.Tables("rc_cgdnr").Rows(i).Item("dw")
                rcOleDbCommand.Parameters.Add("@paraDblMjsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_cgdnr").Rows(i).Item("mjsl")
                rcOleDbCommand.Parameters.Add("@paraDblFzsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_cgdnr").Rows(i).Item("fzsl")
                rcOleDbCommand.Parameters.Add("@paraStrFzdw", OleDbType.VarChar, 8).Value = rcDataset.Tables("rc_cgdnr").Rows(i).Item("fzdw")
                rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_cgdnr").Rows(i).Item("dj")
                rcOleDbCommand.Parameters.Add("@paraDblHsdj", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_cgdnr").Rows(i).Item("hsdj")
                rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_cgdnr").Rows(i).Item("je")
                rcOleDbCommand.Parameters.Add("@paraDblShlv", OleDbType.Numeric, 6).Value = rcDataset.Tables("rc_cgdnr").Rows(i).Item("shlv")
                rcOleDbCommand.Parameters.Add("@paraDblSe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_cgdnr").Rows(i).Item("se")
                rcOleDbCommand.Parameters.Add("@paraStrCgmemo", OleDbType.VarChar, 50).Value = rcDataset.Tables("rc_cgdnr").Rows(i).Item("cgmemo")
                rcOleDbCommand.Parameters.Add("@paraStrCgjhDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_cgdnr").Rows(i).Item("cgjhdjh")
                rcOleDbCommand.Parameters.Add("@paraIntCgjhXh", OleDbType.Integer, 4).Value = rcDataset.Tables("rc_cgdnr").Rows(i).Item("cgjhxh")
                rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                rcOleDbCommand.ExecuteNonQuery()
                If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                    If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                        MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                        Return
                    End If
                End If
                If rcOleDbCommand.Parameters("@paraStrDjh").Value.GetType.ToString <> "System.DBNull" Then
                    If rcOleDbCommand.Parameters("@paraStrDjh").Value <> "" Then
                        Me.TxtDjh.Text = Trim(rcOleDbCommand.Parameters("@paraStrDjh").Value)
                    End If
                End If
            Next
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Catch ey As OleDbException
                MsgBox("�������" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '��ӡ
        If blnPrint Then
            PrintEvent()
        End If
        IsAdding = False
        IsEditing = False
        '�µ��ݺ�
        NewEvent()
        '�ؼ�����
        SetControlEnableEvent()
        '���ý���
        Me.TxtDjh.Focus()
    End Sub

#End Region

#Region "ȡ���޸��¼�"

    Private Sub BtnCancelEvent(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click, MnuiCancel.Click
        If MsgBox("�Ƿ�����������޸ģ�", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "��ʾ��Ϣ") = MsgBoxResult.Yes Then
            IsAdding = False
            IsEditing = False
            NewEvent()
            SetControlEnableEvent()
            Me.TxtDjh.Focus()
        End If
    End Sub

#End Region

#Region "�������¼�"

    Private Sub BtnIns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIns.Click, MnuiIns.Click
        If Me.rcDataGridView.ReadOnly = False Then
            If dtCgd.Rows.Count > 0 Then
                Dim row As DataRow = dtCgd.NewRow
                dtCgd.Rows.InsertAt(row, rcDataGridView.CurrentCell.RowIndex)
                dtCgd.AcceptChanges()
            End If
        End If
    End Sub

#End Region

#Region "ɾ��DataGridView���¼�"

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        DeleteEvent()
    End Sub

    Private Sub MnuiDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiDelete.Click
        DeleteEvent()
    End Sub

    Private Sub DeleteEvent()
        If Me.rcDataGridView.ReadOnly = False Then
            If rcDataset.Tables("rc_cgdnr").Rows.Count > 0 Then
                rcDataset.Tables("rc_cgdnr").Rows(rcDataGridView.CurrentRow.Index).Delete()
                rcDataset.Tables("rc_cgdnr").AcceptChanges()
                IsEditing = True
                SetControlEnableEvent()
            End If
        End If
    End Sub
#End Region

#Region "׼����ӡ�����¼�"

    Private Sub PreparePrintData()
        If rcRps Is Nothing Then
            rcRps = New RPS.Document
        End If
        Dim rft As String
        If blnhs Then
            rft = CurDir() + "\reports\cgdbz1.rft"
        Else
            rft = CurDir() + "\reports\cgdbz2.rft"
        End If
        rcRps.LoadTemplate(rft)
        'ȡRPS����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps WHERE rpsid = 'CGDBZ'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_rps") IsNot Nothing Then
                rcDataset.Tables("rc_rps").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_rps")
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_rps").Rows.Count > 0 Then
            '�趨ֵ
            rcRps.Scale = rcDataset.Tables("rc_rps").Rows(0).Item("scale")
            rcRps.Orientation = rcDataset.Tables("rc_rps").Rows(0).Item("orientation")
            rcRps.PaperWidth = rcDataset.Tables("rc_rps").Rows(0).Item("paperwidth")
            rcRps.PaperHeight = rcDataset.Tables("rc_rps").Rows(0).Item("paperheight")
            rcRps.PrinterLeft = rcDataset.Tables("rc_rps").Rows(0).Item("printerleft")
            rcRps.PrinterTop = rcDataset.Tables("rc_rps").Rows(0).Item("printertop")
        Else
            'Ĭ��ֵ
            rcRps.Scale = 100
            rcRps.Orientation = 1
        End If
        If Not String.IsNullOrEmpty(Me.TxtCsdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_csxx WHERE (csdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtCsdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_csxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_csxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_csxx")
            Catch ex As Exception
                MsgBox("������󡣶�ȡ��Ӧ�̱��롣" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        End If
        '�״�
        'rcRps.PaperType = 1
        rcRps.Text(-1, 1) = g_PrnDwmc & "�ɹ���"
        rcRps.Text(-1, 2) = g_PrnDwmc_EN
        rcRps.Text(-1, 5) = "�� �� �ţ�" & Trim(Me.TxtDjh.Text) & "  %p/%t"
        rcRps.Text(-1, 6) = "��    �ڣ�" & Me.DtpCgrq.Value.Date.ToLongDateString
        rcRps.Text(-1, 7) = "�� Ӧ �̣�(" & Trim(Me.TxtCsdm.Text) & ")" & Trim(LblCsmc.Text)
        rcRps.Text(-1, 8) = "������ţ�" & Me.TxtSgddh.Text
        If rcDataset.Tables("rc_csxx") IsNot Nothing Then
            If Me.rcDataset.Tables("rc_csxx").Rows.Count > 0 Then
                rcRps.Text(-1, 9) = "��ϵ�ˣ�" & Me.rcDataset.Tables("rc_csxx").Rows(0).Item("lxr") & "    ����������" & Me.rcDataset.Tables("rc_csxx").Rows(0).Item("fkts")
                rcRps.Text(-1, 10) = "TEL��" & Me.rcDataset.Tables("rc_csxx").Rows(0).Item("tel")
                rcRps.Text(-1, 11) = "FAX��" & Me.rcDataset.Tables("rc_csxx").Rows(0).Item("fax")
                If Me.rcDataset.Tables("rc_csxx").Rows(0).Item("fkts") <> 0 Then
                    rcRps.Text(-1, 22) = "4��������㷽ʽ����Ʊ���㣬����������ֵ˰ר�÷�Ʊ���跽���ʺ�" & Me.rcDataset.Tables("rc_csxx").Rows(0).Item("fkts") & "���֧�����"
                End If
            End If
        End If
        Dim i As Integer
        Dim j As Integer
        Dim intPage As Integer
        Dim dblTotalJe As Double = 0.0
        Dim dblTotalSe As Double = 0.0
        For intPage = 1 To System.Math.Ceiling(rcDataSet.Tables("rc_cgdnr").Rows.Count / rcRps.LinesPerPage.ToString)
            For i = (intPage - 1) * rcRps.LinesPerPage.ToString To System.Math.Min(intPage * rcRps.LinesPerPage.ToString - 1, rcDataSet.Tables("rc_cgdnr").Rows.Count - 1)
                If rcDataSet.Tables("rc_cgdnr").Rows(i).RowState <> 8 Then
                    If blnhs Then
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("cpdm").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 1) = Trim(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("cpdm"))
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("cpmc").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 2) = Trim(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("cpmc"))
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 3) = Trim(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("dw"))
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 4) = Format(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("sl"), g_FormatSl)
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("hsdj").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 5) = Format(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("hsdj"), g_FormatDj)
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("je").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 6) = Format(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("je") + rcDataSet.Tables("rc_cgdnr").Rows(i).Item("se"), g_FormatJe)
                            dblTotalJe = dblTotalJe + rcDataSet.Tables("rc_cgdnr").Rows(i).Item("je") + rcDataSet.Tables("rc_cgdnr").Rows(i).Item("se")
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("jhshrq").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 7) = rcDataSet.Tables("rc_cgdnr").Rows(i).Item("jhshrq")
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("cgmemo").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 8) = Trim(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("cgmemo"))
                        End If
                    Else
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("cpdm").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 1) = Trim(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("cpdm"))
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("cpmc").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 2) = Trim(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("cpmc"))
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 3) = Trim(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("dw"))
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 4) = Format(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("sl"), g_FormatSl)
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("dj").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 5) = Format(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("dj"), g_FormatDj)
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("hsdj").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 6) = Format(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("hsdj"), g_FormatDj)
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("je").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 7) = Format(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("je"), g_FormatJe)
                            dblTotalJe += rcDataSet.Tables("rc_cgdnr").Rows(i).Item("je")
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("shlv").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 8) = Format(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("shlv") / 100, "0%")
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("se").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 9) = Format(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("se"), g_FormatJe)
                            dblTotalSe += rcDataSet.Tables("rc_cgdnr").Rows(i).Item("se")
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("jhshrq").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 10) = rcDataSet.Tables("rc_cgdnr").Rows(i).Item("jhshrq")
                        End If
                        If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("cgmemo").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 11) = Trim(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("cgmemo"))
                        End If
                    End If
                    j += 1
                End If
            Next
            If Decimal.op_Modulus(rcDataSet.Tables("rc_cgdnr").Rows.Count, rcRps.LinesPerPage.ToString) <> 0 Then
                For i = Decimal.op_Modulus(rcDataSet.Tables("rc_cgdnr").Rows.Count, rcRps.LinesPerPage.ToString) + 1 To rcRps.LinesPerPage.ToString
                    rcRps.Text(j + 1, 1) = ""
                    j += 1
                Next
            End If

            Dim m As New models.ChineseNum With {
                .InputString = dblTotalJe + dblTotalSe
            }
            rcRps.PerPageText(intPage, 12) = IIf(intPage = Math.Ceiling(rcDataSet.Tables("rc_cgdnr").Rows.Count / rcRps.LinesPerPage.ToString), "�ϼ�", "С��")
            rcRps.PerPageText(intPage, 13) = m.OutString & "   (Сд)" & Format(dblTotalJe + dblTotalSe, g_FormatJe) '��д
            rcRps.PerPageText(intPage, 14) = Format(dblTotalJe, g_FormatJe)
            rcRps.PerPageText(intPage, 16) = Format(dblTotalSe, g_FormatJe)
        Next
        'rcRps.Text(-1, 7) = "�����ˣ�" & g_User_DspName
    End Sub

#End Region

#Region "��ӡ�����¼�"

    Private Sub PageSetupEvent()
        Dim rcFrmPageSetup As New models.FrmPageSetup
        With rcFrmPageSetup
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = "CGDBZ"
            .paraRpsName = "�ɹ�������׼��ʽ"
            .ShowDialog()
        End With
    End Sub

    Private Sub MnuiPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPageSetup.Click
        PageSetupEvent()
    End Sub

#End Region

#Region "��ӡ�¼�"

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click, MnuiPrint.Click
        Dim rcFrm As New FrmPoCgdPrint
        With rcFrm
            .ShowDialog()
            blnhs = .paraBlnHs
        End With
        SaveEvent(True)
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

#End Region

#Region "��ӡԤ���¼�"

    Private Sub PrintViewEvent()
        Dim rcFrm As New FrmPoCgdPrint
        With rcFrm
            .ShowDialog()
            blnhs = .paraBlnHs
        End With
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

#Region "�˳����¼�"

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        ExitEvent()
    End Sub

    Private Sub MnuiExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiExit.Click
        ExitEvent()
    End Sub

    Private Sub ExitEvent()
        Me.Close()
    End Sub

    Private Sub FrmCgdSrz_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If IsEditing Then
            MsgBox("�Ѿ��༭�����ݣ��뱣�����ݡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            e.Cancel = True
        End If
    End Sub

#End Region

    Private Sub TxtSgddh_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtSgddh.Validating
        If Not String.IsNullOrEmpty(Me.TxtSgddh.Text) Then
            IsEditing = True
            SetControlEnableEvent()
        End If
    End Sub
End Class