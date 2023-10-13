Imports System.Math
Imports System.Data.OleDb

Public Class FrmInvDbdSrz
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '��ʾҪ������Դִ�е� SQL ����
    Dim rcOleDbTrans As OleDbTransaction
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '����Datatable '����Ҫ���ø�datatable���н�����
    ReadOnly dtDbd As New DataTable("rc_dbdnr")
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
    '�������
    Dim dblKcsl As Double = 0.0
    '�ϼƱ���
    Dim dblTotSl As Double = 0.0
    Dim dblTotFzsl As Double = 0.0
    Dim dblTotJe As Double = 0.0


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

    Private Sub FrmInvDbdSrz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Me.rcDataGridView.Columns("ColJe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColJe").DefaultCellStyle.Format = g_FormatJe
        'ȡ������������
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE kjnd = ? AND lxgs = '���ϵ�����' ORDER BY pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
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
            If rcDataset.Tables("rc_lx").Rows(i).Item("pzlxdm") = "DBDJ" Then
                Me.CmbPzlxjc.SelectedValue = "DBDJ"
                Exit For
            End If
        Next
        '���ݰ�
        dtDbd.Columns.Add("cpdm", Type.GetType("System.String"))
        dtDbd.Columns.Add("oldcpdm", Type.GetType("System.String"))
        dtDbd.Columns.Add("cpmc", Type.GetType("System.String"))
        dtDbd.Columns.Add("csdm", Type.GetType("System.String"))
        dtDbd.Columns.Add("csmc", Type.GetType("System.String"))
        dtDbd.Columns.Add("kuwei", Type.GetType("System.String"))
        dtDbd.Columns.Add("pihao", Type.GetType("System.String"))
        dtDbd.Columns.Add("sl", Type.GetType("System.Double"))
        dtDbd.Columns.Add("dw", Type.GetType("System.String"))
        dtDbd.Columns.Add("mjsl", Type.GetType("System.Double"))
        dtDbd.Columns.Add("fzsl", Type.GetType("System.Double"))
        dtDbd.Columns.Add("fzdw", Type.GetType("System.String"))
        dtDbd.Columns.Add("dj", Type.GetType("System.Double"))
        dtDbd.Columns.Add("je", Type.GetType("System.Double"))
        dtDbd.Columns.Add("dbmemo", Type.GetType("System.String"))
        dtDbd.Columns.Add("llsqdjh", Type.GetType("System.String"))
        dtDbd.Columns.Add("llsqxh", Type.GetType("System.Int32"))
        rcDataset.Tables.Add(dtDbd)
        With rcDataset.Tables("rc_dbdnr")
            .Columns("cpdm").DefaultValue = ""
            .Columns("oldcpdm").DefaultValue = ""
            .Columns("cpmc").DefaultValue = ""
            .Columns("csdm").DefaultValue = ""
            .Columns("csmc").DefaultValue = ""
            .Columns("kuwei").DefaultValue = ""
            .Columns("pihao").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("mjsl").DefaultValue = 0.0
            .Columns("fzsl").DefaultValue = 0.0
            .Columns("dj").DefaultValue = 0.0
            .Columns("je").DefaultValue = 0.0
            .Columns("dbmemo").DefaultValue = ""
            .Columns("llsqdjh").DefaultValue = ""
            .Columns("llsqxh").DefaultValue = 0
        End With
        '������the DataGridview to the DataTable.
        rcBindingSource.DataSource = dtDbd
        Me.rcDataGridView.DataSource = rcBindingSource
        rcBmb = Me.BindingContext(rcDataset, "rc_dbdnr")
        strKjqj = strYear & strMonth.PadLeft(2, "0")
        If GetInvKjqj(g_Kjrq) = strKjqj Then
            DtpDbrq.Value = Now()
        Else
            DtpDbrq.Value = GetInvEnd(strYear, strMonth)
        End If
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
            If dtDbd.Rows.Count > 0 Then
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

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbPzlxjc.KeyPress, TxtDjh.KeyPress, DtpDbrq.KeyPress, TxtCckdm.KeyPress, TxtRckdm.KeyPress, TxtZydm.KeyPress
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

#Region "ʱ��"

    Private Sub RcTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rcTimer.Tick
        Me.DtpDbrq.Value = Me.DtpDbrq.Value.AddMinutes(1)
    End Sub

#End Region

#Region "����ϼ���"

    Private Sub SumSlJe()
        '����ϼ���
        dblTotSl = 0.0
        dblTotFzsl = 0.0
        dblTotJe = 0.0
        If rcDataset.Tables("rc_dbdnr").Rows.Count > 0 Then
            dblTotSl = rcDataset.Tables("rc_dbdnr").Compute("Sum(sl)", "")
            dblTotFzsl = rcDataset.Tables("rc_dbdnr").Compute("Sum(fzsl)", "")
            dblTotJe = rcDataset.Tables("rc_dbdnr").Compute("Sum(je)", "")
        End If
        Me.LblSl.Text = "�����ϼƣ�" + Format(dblTotSl, g_FormatSl)
        Me.LblFzsl.Text = "�������ϼƣ�" + Format(dblTotFzsl, g_FormatSl)
        Me.LblJe.Text = "���ϼƣ�" + Format(dblTotJe, g_FormatJe)
    End Sub

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
                        rcOleDbCommand.CommandText = "USP_DELETE_INV_DBD"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = Trim(Me.TxtDjh.Text)
                        rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                        rcOleDbCommand.Parameters.Add("@paraIntError", OleDbType.Integer, 4).Direction = ParameterDirection.Output
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
                            MsgBox("�������" & Chr(13) & ex.Message & Chr(13) & rcOleDbCommand.Parameters("@paraIntError").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
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
                    rcOleDbCommand.CommandText = "SELECT inv_dbd.djh,TRUNC(inv_dbd.dbrq,'mi') AS dbrq,inv_dbd.bdelete,inv_dbd.cckdm,inv_dbd.cckmc,inv_dbd.rckdm,inv_dbd.rckmc,inv_dbd.zydm,inv_dbd.zymc,inv_dbd.srr,inv_dbd.shr,inv_dbd.jzr FROM inv_dbd WHERE (inv_dbd.djh = ? )"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.TxtDjh.Text
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("rc_dbdnr") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_dbdnr").Clear()
                    End If
                    If rcDataset.Tables("rc_dbdml") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_dbdml").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "rc_dbdml")
                    If rcDataset.Tables("rc_dbdml").Rows.Count > 0 Then
                        If rcDataset.Tables("rc_dbdml").Rows(0).Item("jzr").GetType.ToString <> "System.DBNull" Then
                            MsgBox("�õ����Ѿ����ˣ������޸ġ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                            Me.TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                            IsAdding = True
                        Else
                            If rcDataset.Tables("rc_dbdml").Rows(0).Item("shr").GetType.ToString <> "System.DBNull" Then
                                MsgBox("�õ����Ѿ���ˣ������޸ġ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                                Me.TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                                IsAdding = True
                            Else
                                Me.DtpDbrq.Value = rcDataset.Tables("rc_dbdml").Rows(0).Item("dbrq")
                                Me.LblBdelete.Text = IIf(rcDataset.Tables("rc_dbdml").Rows(0).Item("bdelete"), "����", "")
                                Me.TxtCckdm.Text = Trim(rcDataset.Tables("rc_dbdml").Rows(0).Item("cckdm"))
                                Me.LblCckmc.Text = Trim(rcDataset.Tables("rc_dbdml").Rows(0).Item("cckmc"))
                                Me.TxtRckdm.Text = Trim(rcDataset.Tables("rc_dbdml").Rows(0).Item("rckdm"))
                                Me.LblRckmc.Text = Trim(rcDataset.Tables("rc_dbdml").Rows(0).Item("rckmc"))
                                TxtZydm.Text = Trim(rcDataset.Tables("rc_dbdml").Rows(0).Item("zydm"))
                                LblZymc.Text = rcDataset.Tables("rc_dbdml").Rows(0).Item("zymc")
                                '�޸ĵ���
                                rcOleDbCommand.CommandText = "SELECT inv_dbd.cpdm,rc_cpxx.oldcpdm,inv_dbd.cpmc,inv_dbd.csdm,inv_dbd.csmc,inv_dbd.kuwei,inv_dbd.pihao,inv_dbd.sl,rc_cpxx.dw,inv_dbd.mjsl,inv_dbd.fzsl,rc_cpxx.fzdw,inv_dbd.dj,inv_dbd.je,inv_dbd.dbmemo,inv_dbd.llsqdjh,inv_dbd.llsqxh FROM inv_dbd,rc_cpxx WHERE inv_dbd.cpdm = rc_cpxx.cpdm AND (inv_dbd.djh = ?) ORDER BY inv_dbd.xh"
                                rcOleDbCommand.Parameters.Clear()
                                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.TxtDjh.Text
                                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                If rcDataset.Tables("rc_dbdnr") IsNot Nothing Then
                                    Me.rcDataset.Tables("rc_dbdnr").Clear()
                                End If
                                rcOleDbDataAdpt.Fill(rcDataset, "rc_dbdnr")
                                If rcDataset.Tables("rc_dbdnr").Rows.Count > 0 Then
                                    If rcDataset.Tables("rc_dbdnr").Rows(0).Item("llsqdjh").GetType.ToString <> "System.DBNull" Then
                                        Me.TxtCckdm.Enabled = False
                                        Me.TxtZydm.Enabled = False
                                        Me.rcDataGridView.AllowUserToAddRows = False
                                        Me.ColCpdm.ReadOnly = True
                                        Me.ColKuwei.ReadOnly = True
                                        Me.ColSl.ReadOnly = True
                                        Me.ColMjsl.ReadOnly = True
                                        Me.ColFzsl.ReadOnly = True
                                        Me.BtnIns.Enabled = False
                                        Me.MnuiIns.Enabled = False
                                    Else
                                        Me.TxtCckdm.Enabled = True
                                        Me.TxtZydm.Enabled = True
                                        Me.rcDataGridView.AllowUserToAddRows = True
                                        Me.ColCpdm.ReadOnly = False
                                        Me.ColKuwei.ReadOnly = False
                                        Me.ColSl.ReadOnly = False
                                        Me.ColMjsl.ReadOnly = False
                                        Me.ColFzsl.ReadOnly = False
                                        Me.BtnIns.Enabled = True
                                        Me.MnuiIns.Enabled = True
                                    End If
                                End If
                                Me.rcDataGridView.ClearSelection()
                                SumSlJe()
                                IsAdding = False
                                Me.rcTimer.Enabled = False
                            End If
                        End If
                    End If
                Else
                    '��������
                    IsAdding = True
                    Me.rcTimer.Enabled = True
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

#Region "�������ڵ��¼�"

    Private Sub DtpDbrq_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DtpDbrq.Validating
        Dim dateBegin As DateTime
        Dim dateEnd As DateTime
        dateBegin = GetInvBegin(strYear, strMonth)
        dateEnd = GetInvEnd(strYear, strMonth)
        If DtpDbrq.Value > dateEnd Or DtpDbrq.Value < dateBegin Then
            MsgBox("����������ڲ��ڵ�ǰ����ڼ��У��������롣", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            Me.DtpDbrq.Focus()
        End If
    End Sub

#End Region

#Region "ְԱ������¼�"

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
                    .paraTitle = "ְԱ"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtZydm.Text = Trim(.paraField1)
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
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
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
            If Not IsEditing Then
                IsEditing = True
                SetControlEnableEvent()
            End If
        End If
    End Sub

#End Region

#Region "�����ֿ���¼�"

    Private Sub TxtCckdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCckdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_ckxx"
                    .paraField1 = "ckdm"
                    .paraField2 = "ckmc"
                    .paraField3 = "cksm"
                    .paraTitle = "�ֿ�"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtCckdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtCckdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCckdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtCckdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_ckxx WHERE (ckdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(TxtCckdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_ckxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_ckxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_ckxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_ckxx").Rows.Count > 0 Then
                Me.TxtCckdm.Text = Trim(rcDataset.Tables("rc_ckxx").Rows(0).Item("ckdm"))
                Me.LblCckmc.Text = Trim(rcDataset.Tables("rc_ckxx").Rows(0).Item("ckmc"))
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

#Region "����ֿ���¼�"

    Private Sub TxtRckdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtRckdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_ckxx"
                    .paraField1 = "ckdm"
                    .paraField2 = "ckmc"
                    .paraField3 = "cksm"
                    .paraTitle = "�ֿ�"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtRckdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtRckdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtRckdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtRckdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_ckxx WHERE (ckdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(TxtRckdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_ckxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_ckxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_ckxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_ckxx").Rows.Count > 0 Then
                Me.TxtRckdm.Text = Trim(rcDataset.Tables("rc_ckxx").Rows(0).Item("ckdm"))
                Me.LblRckmc.Text = Trim(rcDataset.Tables("rc_ckxx").Rows(0).Item("ckmc"))
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
                    Try
                        'ȡ������Ϣ
                        rcOleDbConn.Open()
                        rcOleDbCommand.Connection = rcOleDbConn
                        rcOleDbCommand.CommandTimeout = 300
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT cpdm,cpmc,kuwei,dw,mjsl,fzdw,oldcpdm FROM rc_cpxx WHERE (rc_cpxx.cpdm = ? OR rc_cpxx.oldcpdm = ?)"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.AddWithValue("@cpdm", rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue)
                        rcOleDbCommand.Parameters.AddWithValue("@oldcpdm", rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue)
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                            rcDataset.Tables("rc_cpxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
                        If rcDataset.Tables("rc_cpxx").Rows.Count > 0 And Not String.IsNullOrEmpty(Me.TxtCckdm.Text) Then
                            ''ȡ���¿������
                            'rcOleDbCommand.CommandText = "SELECT COALESCE(Sum(qcsl+idsl),0.0) as kcsl FROM inv_cpyeb WHERE kjnd = ? AND cpdm = ? AND ckdm = ?"
                            'rcOleDbCommand.Parameters.Clear()
                            'rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = strYear
                            'rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue
                            'rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Me.TxtCkdm.Text
                            'rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            'If Not rcDataSet.Tables("inv_cpyeb") Is Nothing Then
                            '    rcDataSet.Tables("inv_cpyeb").Clear()
                            'End If
                            'rcOleDbDataAdpt.Fill(rcDataSet, "inv_cpyeb")
                            'ȡ��ǰ�ֿ�δ��������ϸ����
                            rcOleDbCommand.CommandText = "SELECT csdm,csmc,kcsl FROM ((SELECT po_rkd.rkrq,po_rkd.csdm,po_rkd.csmc,(po_rkd.sl-COALESCE(po_rkd.cksl,0.0)) AS kcsl FROM po_rkd WHERE po_rkd.bdelete = 0 AND po_rkd.sl > 0 AND po_rkd.sl > po_rkd.cksl AND po_rkd.ckdm = ? AND po_rkd.cpdm = ?) UNION (SELECT inv_rkd.rkrq, '' AS csdm,'' AS csmc,(inv_rkd.sl-COALESCE(inv_rkd.cksl,0.0)) AS kcsl FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND inv_rkd.sl > 0 AND inv_rkd.sl > inv_rkd.cksl AND inv_rkd.ckdm = ? AND inv_rkd.cpdm = ?) UNION (SELECT inv_dbd.dbrq,inv_dbd.csdm,inv_dbd.csmc,(inv_dbd.sl-COALESCE(inv_dbd.cksl,0.0)) AS kcsl FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND inv_dbd.sl > 0 AND inv_dbd.sl > inv_dbd.cksl AND inv_dbd.cckdm = ? AND inv_dbd.cpdm = ?)) rkd ORDER BY rkd.rkrq"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Me.TxtCckdm.Text
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Me.TxtCckdm.Text
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Me.TxtCckdm.Text
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("po_rkd") IsNot Nothing Then
                                rcDataset.Tables("po_rkd").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "po_rkd")
                        End If
                    Catch ex As Exception
                        MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                    If rcDataset.Tables("rc_cpxx").Rows.Count > 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColCpdm").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("cpdm")
                        Me.rcDataGridView.CurrentRow.Cells("ColCpmc").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("cpmc")
                        Me.rcDataGridView.CurrentRow.Cells("ColDw").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("dw")
                        Me.rcDataGridView.CurrentRow.Cells("ColKuwei").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("kuwei")
                        If rcDataset.Tables("rc_cpxx").Rows(0).Item("mjsl").GetType.ToString <> "System.DBNull" And Me.rcDataGridView.CurrentRow.Cells("ColMjsl").Value = 0 Then
                            Me.rcDataGridView.CurrentRow.Cells("ColMjsl").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("mjsl")
                        End If
                        If rcDataset.Tables("rc_cpxx").Rows(0).Item("fzdw").GetType.ToString <> "System.DBNull" Then
                            Me.rcDataGridView.CurrentRow.Cells("ColFzdw").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("fzdw")
                        End If
                        '�����ϱ���
                        If rcDataset.Tables("rc_cpxx").Rows(0).Item("oldcpdm").GetType.ToString <> "System.DBNull" Then
                            Me.rcDataGridView.CurrentRow.Cells("ColOldCpdm").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("oldcpdm")
                        End If
                        dblKcsl = ReadKcsl(strYear, rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue, Me.TxtCckdm.Text, Me.TxtDjh.Text)
                        Me.LblMsg.Text = "�ֿ���������" & Format(dblKcsl, g_FormatSl)
                        If rcDataset.Tables("po_rkd") IsNot Nothing Then
                            If rcDataset.Tables("po_rkd").Rows.Count > 0 Then
                                If rcDataset.Tables("po_rkd").Rows(0).Item("csdm").GetType.ToString <> "System.DBNull" Then
                                    Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value = rcDataset.Tables("po_rkd").Rows(0).Item("csdm")
                                    Me.rcDataGridView.CurrentRow.Cells("ColCsmc").Value = rcDataset.Tables("po_rkd").Rows(0).Item("csmc")
                                    '���㵱ǰ��Ӧ�̿��
                                    dblKcsl = rcDataset.Tables("po_rkd").Compute("SUM(kcsl)", "csdm ='" & rcDataset.Tables("po_rkd").Rows(0).Item("csdm") & "'")
                                    Me.LblMsg.Text += " �ù�Ӧ�̿��������" & Format(dblKcsl, g_FormatSl)
                                Else
                                    Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value = ""
                                    Me.rcDataGridView.CurrentRow.Cells("ColCsmc").Value = ""
                                End If
                            End If
                        Else
                            Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value = ""
                            Me.rcDataGridView.CurrentRow.Cells("ColCsmc").Value = ""
                        End If
                    Else
                        Me.LblMsg.Text = "���ϱ��벻���ڡ�"
                        e.Cancel = True
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColSl" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    '��ȡ��浥��
                    Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = ReadKcdj(strYear, Me.rcDataGridView.CurrentRow.Cells("ColCpdm").Value, Me.TxtCckdm.Text, Me.TxtDjh.Text)
                    Me.rcDataGridView.CurrentRow.Cells("ColJe").Value = Me.rcDataGridView.CurrentRow.Cells("ColDj").Value * e.FormattedValue
                    If Me.rcDataGridView.CurrentRow.Cells("ColMjsl").Value <> 0 Then
                        If e.FormattedValue <> 0 Then
                            If Me.rcDataGridView.CurrentRow.Cells("ColFzsl").Value = 0 Then
                                Me.rcDataGridView.CurrentRow.Cells("ColFzsl").Value = e.FormattedValue * Me.rcDataGridView.CurrentRow.Cells("ColMjsl").Value
                            End If
                        End If
                    End If
                Else
                    Me.rcDataGridView.CurrentRow.Cells("ColSl").Value = 0.0
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
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColCsdm" And Me.ColCsdm.ReadOnly = False Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF3KeyPress
                    With rcFrm
                        .paraOleDbConn = rcOleDbConn
                        .paraTableName = "rc_csxx"
                        .paraField1 = "csdm"
                        .paraField2 = "csmc"
                        .paraField3 = "cssm"
                        .paraCondition = "0=0"
                        .paraOrderField = "csmc"
                        .paraTitle = "��Ӧ��"
                        .paraOldValue = ""
                        .paraAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            '���û���rcfrmselectcsdm��ѡ���csdm����rcdatarid'
                            Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value = .paraField1
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
        If Me.rcDataGridView.CurrentCell.OwningColumn.Name = "ColCpdm" Then
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
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColCsdm" And Me.ColCsdm.ReadOnly = False Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF3KeyPress
                    With rcFrm
                        .paraOleDbConn = rcOleDbConn
                        .paraTableName = "rc_csxx"
                        .paraField1 = "csdm"
                        .paraField2 = "csmc"
                        .paraField3 = "cssm"
                        .paraCondition = "0=0"
                        .paraOrderField = "csmc"
                        .paraTitle = "��Ӧ��"
                        .paraOldValue = ""
                        .paraAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            '���û���rcfrmselectcsdm��ѡ���csdm����rcdatarid'
                            Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value = .paraField1
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
            Me.rcDataGridView.EndEdit()
            Me.rcBindingSource.EndEdit()
        End If
        If dtDbd.Rows.Count > 0 Then
            IsEditing = True
            SetControlEnableEvent()
            SumSlJe()
        End If
    End Sub

#End Region

#Region "�����������뵥"

    Private Sub BtnImpLlsq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImpLlsq.Click
        If Not String.IsNullOrEmpty(Me.TxtCckdm.Text) Then
            Dim rcFrm As New FrmInvDbdImpLlsq
            With rcFrm
                .ParaCkdm = Me.TxtCckdm.Text
                .ParaDataSet = rcDataset
                .ShowDialog()
                Me.TxtCckdm.Enabled = False
                Me.TxtZydm.Enabled = False
                Me.TxtZydm.Text = .ParaZydm
                Me.LblZymc.Text = .ParaZymc
                Me.rcDataGridView.AllowUserToAddRows = False
                Me.ColCpdm.ReadOnly = True
                'Me.ColFadm.ReadOnly = True
                Me.ColKuwei.ReadOnly = True
                Me.ColSl.ReadOnly = True
                Me.ColMjsl.ReadOnly = True
                Me.ColFzsl.ReadOnly = True
                Me.BtnIns.Enabled = False
                Me.MnuiIns.Enabled = False
            End With
        Else
            MsgBox("����ֿ���롣", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
        End If
    End Sub

#End Region

#Region "������ⵥ"

    Private Sub BtnImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImp.Click
        Dim rcFrm As New FrmInvDbdImpRkd
        With rcFrm
            .ParaDataSet = rcDataset
            .ShowDialog()
        End With
    End Sub

#End Region

#Region "�µ��¼�"

    Private Sub MnuiNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiNew.Click
        NewEvent()
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        NewEvent()
    End Sub

    Private Sub NewEvent()
        '�������
        Me.TxtCckdm.Enabled = True
        Me.TxtCckdm.Text = ""
        Me.LblCckmc.Text = ""
        Me.TxtRckdm.Text = ""
        Me.LblRckmc.Text = ""
        Me.TxtZydm.Enabled = True
        Me.TxtZydm.Text = ""
        Me.LblZymc.Text = ""
        Me.LblBdelete.Text = ""
        Me.LblMsg.Text = "��ʾ��Ϣ��"
        Me.rcDataGridView.AllowUserToAddRows = True
        Me.ColCpdm.ReadOnly = False
        Me.ColKuwei.ReadOnly = False
        Me.ColSl.ReadOnly = False
        Me.ColMjsl.ReadOnly = False
        Me.ColFzsl.ReadOnly = False
        Me.BtnIns.Enabled = True
        Me.MnuiIns.Enabled = True
        '��ʾ�µ��ݺ�
        ShowNewDjh()
        IsAdding = True
        IsEditing = False
        '�������
        If rcDataset.Tables("rc_dbdnr") IsNot Nothing Then
            Me.rcDataset.Tables("rc_dbdnr").Clear()
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
                rcOleDbCommand.CommandText = "SELECT pzno" & strMonth & " As pzno FROM rc_lx WHERE kjnd = ? AND pzlxdm = ? and lxgs = '���ϵ�����'"
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
        If rcDataset.Tables("rc_dbdnr").Rows.Count = 0 Then
            MsgBox("û����Ӧ��ҵ�������롣", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            Return
        End If
        '(2)�����ֿ���
        If Trim(TxtCckdm.Text).Length = 0 Then
            MsgBox("�����ֿⲻ��Ϊ�ա�", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            Return
        End If
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Trim(TxtCckdm.Text)
            rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_ckxx"
            rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "ckdm"
            rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
            rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
            rcOleDbCommand.ExecuteNonQuery()
            If rcOleDbCommand.Parameters.Item("@paraIntRecordCount").Value <> 1 Then
                MsgBox(Trim(TxtCckdm.Text) & "�����ֿⲻ��ȷ�����顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                Me.TxtCckdm.Text = ""
                Me.LblCckmc.Text = ""
                Me.TxtCckdm.Focus()
                Return
            End If
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '(2)����ֿ���
        If Trim(TxtRckdm.Text).Length = 0 Then
            MsgBox("����ֿⲻ��Ϊ�ա�", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            Return
        End If
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Trim(TxtRckdm.Text)
            rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_ckxx"
            rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "ckdm"
            rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
            rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
            rcOleDbCommand.ExecuteNonQuery()
            If rcOleDbCommand.Parameters.Item("@paraIntRecordCount").Value <> 1 Then
                MsgBox(Trim(TxtRckdm.Text) & "�����ֿⲻ��ȷ�����顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                Me.TxtRckdm.Text = ""
                Me.LblRckmc.Text = ""
                Me.TxtRckdm.Focus()
                Return
            End If
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If Trim(Me.TxtCckdm.Text) = Trim(Me.TxtRckdm.Text) Then
            MsgBox("�����ֿⲻ�������ֿ���ͬ��", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            Return
        End If
        '(3)�����˼��
        If String.IsNullOrEmpty(Me.TxtZydm.Text) Then
            MsgBox("�����˲���Ϊ�ա�", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            Return
        End If
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Trim(TxtZydm.Text)
            rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_zyxx"
            rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "zydm"
            rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
            rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
            rcOleDbCommand.ExecuteNonQuery()
            If rcOleDbCommand.Parameters.Item("@paraIntRecordCount").Value <> 1 Then
                MsgBox(Trim(TxtZydm.Text) & "�����˱��벻��ȷ�����顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                Me.TxtZydm.Text = ""
                Me.LblZymc.Text = ""
                Me.TxtZydm.Focus()
                Return
            End If
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '(4)DataTable��Ĭ��ֵ
        For i = 0 To rcDataset.Tables("rc_dbdnr").Rows.Count - 1
            If rcDataset.Tables("rc_dbdnr").Rows(i).Item("cpdm").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_dbdnr").Rows(i).Item("cpdm") = ""
            End If
            If rcDataset.Tables("rc_dbdnr").Rows(i).Item("kuwei").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_dbdnr").Rows(i).Item("kuwei") = ""
            End If
            If rcDataset.Tables("rc_dbdnr").Rows(i).Item("pihao").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_dbdnr").Rows(i).Item("pihao") = ""
            End If
            If rcDataset.Tables("rc_dbdnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_dbdnr").Rows(i).Item("sl") = 0.0
            End If
            If rcDataset.Tables("rc_dbdnr").Rows(i).Item("dbmemo").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_dbdnr").Rows(i).Item("dbmemo") = ""
            End If
            If rcDataset.Tables("rc_dbdnr").Rows(i).Item("llsqdjh").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_dbdnr").Rows(i).Item("llsqdjh") = ""
            End If
            If rcDataset.Tables("rc_dbdnr").Rows(i).Item("llsqxh").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_dbdnr").Rows(i).Item("llsqxh") = 0
            End If
        Next
        '(5)���ϱ�����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            For i = 0 To rcDataset.Tables("rc_dbdnr").Rows.Count - 1
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("rc_dbdnr").Rows(i).Item("cpdm"))
                rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_cpxx"
                rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "cpdm"
                rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
                rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
                rcOleDbCommand.ExecuteNonQuery()
                If rcOleDbCommand.Parameters.Item("@paraIntRecordCount").Value <> 1 Then
                    MsgBox(Trim(rcDataset.Tables("rc_dbdnr").Rows(i).Item("cpdm")) & "���ϱ��벻��ȷ�����顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                    Return
                End If
                If rcDataset.Tables("rc_dbdnr").Rows(i).Item("sl") = 0.0 Then
                    MsgBox("���ϱ��룺" & rcDataset.Tables("rc_dbdnr").Rows(i).Item("cpdm") & "��Ӧ������Ϊ���㡿�����顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                    Return
                End If
            Next
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '(6)���ݺų��ȼ��
        If Trim(Me.TxtDjh.Text).Length <> 15 Then
            MsgBox("���ݺų��Ȳ���ȷ�����顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
            Return
        End If

        '(��)�洢ml
        'djh,rkrq,bdelete,zydm,srr
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP3_SAVE_INV_DBD"
            For i = 0 To rcDataset.Tables("rc_dbdnr").Rows.Count - 1
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = IIf(IsAdding, 1, 0)
                rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = Trim(Me.TxtDjh.Text)
                rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = i + 1
                rcOleDbCommand.Parameters.Add("@paraDateDbrq", OleDbType.Date, 8).Value = Me.DtpDbrq.Value
                rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = IIf(String.IsNullOrEmpty(Me.LblBdelete.Text), 0, 1)
                rcOleDbCommand.Parameters.Add("@paraStrCckdm", OleDbType.VarChar, 12).Value = Me.TxtCckdm.Text
                rcOleDbCommand.Parameters.Add("@paraStrCckmc", OleDbType.VarChar, 50).Value = Me.LblCckmc.Text
                rcOleDbCommand.Parameters.Add("@paraStrRkdm", OleDbType.VarChar, 12).Value = Me.TxtRckdm.Text
                rcOleDbCommand.Parameters.Add("@paraStrRkmc", OleDbType.VarChar, 50).Value = Me.LblRckmc.Text
                rcOleDbCommand.Parameters.Add("@paraStrZydm", OleDbType.VarChar, 12).Value = Me.TxtZydm.Text
                rcOleDbCommand.Parameters.Add("@paraStrZymc", OleDbType.VarChar, 30).Value = Me.LblZymc.Text
                rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("rc_dbdnr").Rows(i).Item("cpdm")).ToUpper
                rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("rc_dbdnr").Rows(i).Item("cpmc")
                rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rc_dbdnr").Rows(i).Item("csdm")
                rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("rc_dbdnr").Rows(i).Item("csmc")
                rcOleDbCommand.Parameters.Add("@paraStrKuwei", OleDbType.VarChar, 40).Value = rcDataset.Tables("rc_dbdnr").Rows(i).Item("kuwei")
                rcOleDbCommand.Parameters.Add("@paraStrPiHao", OleDbType.VarChar, 30).Value = rcDataset.Tables("rc_dbdnr").Rows(i).Item("pihao")
                rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_dbdnr").Rows(i).Item("sl")
                rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = rcDataset.Tables("rc_dbdnr").Rows(i).Item("dw")
                rcOleDbCommand.Parameters.Add("@paraDblMjsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_dbdnr").Rows(i).Item("mjsl")
                rcOleDbCommand.Parameters.Add("@paraDblFzsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_dbdnr").Rows(i).Item("fzsl")
                rcOleDbCommand.Parameters.Add("@paraStrFzdw", OleDbType.VarChar, 8).Value = rcDataset.Tables("rc_dbdnr").Rows(i).Item("fzdw")
                rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_dbdnr").Rows(i).Item("dj")
                rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_dbdnr").Rows(i).Item("je")
                rcOleDbCommand.Parameters.Add("@paraStrDbmemo", OleDbType.VarChar, 50).Value = rcDataset.Tables("rc_dbdnr").Rows(i).Item("dbmemo")
                rcOleDbCommand.Parameters.Add("@paraStrLlsqDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_dbdnr").Rows(i).Item("llsqdjh")
                rcOleDbCommand.Parameters.Add("@paraIntLlsqXh", OleDbType.Integer, 4).Value = rcDataset.Tables("rc_dbdnr").Rows(i).Item("llsqxh")
                rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                rcOleDbCommand.Parameters.Add("@paraCbill_bid", OleDbType.VarChar, 20).Value = "~"
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

#Region "����"

    Private Sub MnuiWriteOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiWriteOff.Click
        Me.rcDataGridView.Focus()
        If Not IsEditing And IsAdding Then
            '���ñ�
            Dim rcFrm As New FrmInvDbdWriteOff
            Dim strDjh As String = ""
            Dim blnCk As Boolean = False
            With rcFrm
                .ShowDialog()
                blnCk = .parablnCk
                strDjh = .paraStrDjh
                If blnCk Then
                    MsgBox("�õ����Ѿ����⣬���ܳ��������ȳ������ϳ��ⵥ��", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                    Return
                End If
                '��ȡ���ֳ�������
                Try
                    rcOleDbConn.Open()
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    '�޸ĵ���
                    rcOleDbCommand.CommandText = "SELECT inv_dbd.djh,TRUNC(inv_dbd.dbrq,'mi') AS dbrq,inv_dbd.cckdm,inv_dbd.cckmc,inv_dbd.rckdm,inv_dbd.rckmc,inv_dbd.zydm,inv_dbd.zymc,inv_dbd.srr,inv_dbd.shr,inv_dbd.jzr FROM inv_dbd WHERE (inv_dbd.djh = ? )"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = strDjh
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("rc_dbdnr") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_dbdnr").Clear()
                    End If
                    If rcDataset.Tables("rc_dbdml") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_dbdml").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "rc_dbdml")
                    If rcDataset.Tables("rc_dbdml").Rows.Count > 0 Then
                        Me.DtpDbrq.Value = rcDataset.Tables("rc_dbdml").Rows(0).Item("dbrq")
                        Me.TxtCckdm.Text = Trim(rcDataset.Tables("rc_dbdml").Rows(0).Item("cckdm"))
                        Me.LblCckmc.Text = Trim(rcDataset.Tables("rc_dbdml").Rows(0).Item("cckmc"))
                        Me.TxtRckdm.Text = Trim(rcDataset.Tables("rc_dbdml").Rows(0).Item("rckdm"))
                        Me.LblRckmc.Text = Trim(rcDataset.Tables("rc_dbdml").Rows(0).Item("rckmc"))
                        TxtZydm.Text = Trim(rcDataset.Tables("rc_dbdml").Rows(0).Item("zydm"))
                        LblZymc.Text = rcDataset.Tables("rc_dbdml").Rows(0).Item("zymc")
                        '�޸ĵ���
                        rcOleDbCommand.CommandText = "SELECT inv_dbd.cpdm,rc_cpxx.oldcpdm,inv_dbd.cpmc,inv_dbd.csdm,inv_dbd.csmc,inv_dbd.kuwei,inv_dbd.pihao, (0 - inv_dbd.sl) AS sl,rc_cpxx.dw,inv_dbd.mjsl,(0 - inv_dbd.fzsl) AS fzsl,rc_cpxx.fzdw,inv_dbd.dj,(0 - inv_dbd.je) AS je,inv_dbd.dbmemo,inv_dbd.llsqdjh,inv_dbd.llsqxh FROM inv_dbd,rc_cpxx WHERE inv_dbd.cpdm = rc_cpxx.cpdm AND (inv_dbd.djh = ?) ORDER BY inv_dbd.xh"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = strDjh
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_dbdnr") IsNot Nothing Then
                            Me.rcDataset.Tables("rc_dbdnr").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_dbdnr")
                        If rcDataset.Tables("rc_dbdnr").Rows.Count > 0 Then
                            If rcDataset.Tables("rc_dbdnr").Rows(0).Item("cgddjh").GetType.ToString <> "System.DBNull" Then
                                'Me.BtnImp.Enabled = False
                                Me.rcDataGridView.AllowUserToAddRows = False
                                Me.ColCpdm.ReadOnly = True
                                'Me.ColSl.ReadOnly = True
                                'Me.ColMjsl.ReadOnly = True
                                'Me.ColFzsl.ReadOnly = True
                                Me.BtnIns.Enabled = False
                                Me.MnuiIns.Enabled = False
                            End If
                        End If
                        Me.rcDataGridView.ClearSelection()
                        SumSlJe()
                        IsAdding = True
                        SumSlJe() '�������ϼ�
                        IsEditing = True
                        'blnReCalculate = False 
                        SetControlEnableEvent()
                    End If
                Catch ex As Exception
                    MsgBox("�������" & Chr(13) & ex.Message)
                Finally
                    rcOleDbConn.Close()
                End Try
            End With
        End If
    End Sub

#End Region

#Region "����/�ָ�"

    Private Sub MnuiZf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiZf.Click
        If Me.LblBdelete.Text = "����" Then
            Me.LblBdelete.Text = ""
        Else
            Me.LblBdelete.Text = "����"
        End If
        If Not IsEditing Then
            IsEditing = True
            SetControlEnableEvent()
        End If
    End Sub

#End Region

#Region "�������¼�"

    Private Sub BtnIns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIns.Click, MnuiIns.Click
        If Me.rcDataGridView.ReadOnly = False Then
            If dtDbd.Rows.Count > 0 Then
                Dim row As DataRow = dtDbd.NewRow
                dtDbd.Rows.InsertAt(row, rcDataGridView.CurrentCell.RowIndex)
                dtDbd.AcceptChanges()
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
            If rcDataset.Tables("rc_dbdnr").Rows.Count > 0 Then
                rcDataset.Tables("rc_dbdnr").Rows(rcDataGridView.CurrentRow.Index).Delete()
                rcDataset.Tables("rc_dbdnr").AcceptChanges()
                IsEditing = True
                SetControlEnableEvent()
            End If
        End If
    End Sub
#End Region

#Region "����excel"

    Private Sub BtnImpXls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiImpXls.Click
        '���ñ�
        Dim rcFrm As New FrmInvDbdImpXls
        With rcFrm
            .ParaStrPzlxdm = Me.CmbPzlxjc.SelectedValue
            .ParaStrKjqj = strKjqj
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

#End Region

#Region "׼����ӡ�����¼�"

    Private Sub PreparePrintData()
        If rcRps Is Nothing Then
            rcRps = New RPS.Document
        End If
        Dim rft As String = CurDir() + "\reports\dbdbz.rft"
        rcRps.LoadTemplate(rft)
        'ȡRPS����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps WHERE rpsid = 'DBDBZ'"
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
        '�״�
        'rcRps.PaperType = 1

        rcRps.Text(-1, 1) = g_PrnDwmc & "������"
        rcRps.Text(-1, 2) = "���ݺţ�" & Trim(Me.TxtDjh.Text) & "  %p/%t"
        rcRps.Text(-1, 3) = "�������ڣ�" & DtpDbrq.Value.Date.ToLongDateString
        rcRps.Text(-1, 4) = "�����ֿ⣺(" & Trim(Me.TxtCckdm.Text) & ")" & Me.LblCckmc.Text
        rcRps.Text(-1, 5) = "����ֿ⣺(" & Trim(Me.TxtRckdm.Text) & ")" & Me.LblRckmc.Text
        rcRps.Text(-1, 6) = "�����ˣ�(" & Trim(Me.TxtZydm.Text) & ")" & Me.LblZymc.Text
        Dim i As Integer
        Dim j As Integer
        Dim intPage As Integer
        Dim dblTotalSl As Double = 0.0
        Dim dblTotalFzsl As Double = 0.0
        For intPage = 1 To System.Math.Ceiling(rcDataSet.Tables("rc_dbdnr").Rows.Count / rcRps.LinesPerPage.ToString)
            For i = (intPage - 1) * rcRps.LinesPerPage.ToString To System.Math.Min(intPage * rcRps.LinesPerPage.ToString - 1, rcDataSet.Tables("rc_dbdnr").Rows.Count - 1)
                If rcDataSet.Tables("rc_dbdnr").Rows(i).RowState <> 8 Then
                    If Not rcDataSet.Tables("rc_dbdnr").Rows(i).Item("cpdm").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 1) = Trim(rcDataSet.Tables("rc_dbdnr").Rows(i).Item("cpdm"))
                    End If
                    If Not rcDataSet.Tables("rc_dbdnr").Rows(i).Item("cpmc").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 2) = Trim(rcDataSet.Tables("rc_dbdnr").Rows(i).Item("cpmc"))
                    End If
                    If Not rcDataSet.Tables("rc_dbdnr").Rows(i).Item("pihao").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 3) = Trim(rcDataSet.Tables("rc_dbdnr").Rows(i).Item("pihao"))
                    End If
                    If Not rcDataSet.Tables("rc_dbdnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 4) = Format(rcDataSet.Tables("rc_dbdnr").Rows(i).Item("sl"), g_FormatSl)
                        dblTotalSl += rcDataSet.Tables("rc_dbdnr").Rows(i).Item("sl")
                    End If
                    If Not rcDataSet.Tables("rc_dbdnr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 5) = Trim(rcDataSet.Tables("rc_dbdnr").Rows(i).Item("dw"))
                    End If
                    If Not rcDataSet.Tables("rc_dbdnr").Rows(i).Item("fzsl").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 6) = Format(rcDataSet.Tables("rc_dbdnr").Rows(i).Item("fzsl"), g_FormatSl)
                        dblTotalFzsl += rcDataSet.Tables("rc_dbdnr").Rows(i).Item("fzsl")
                    End If
                    If Not rcDataSet.Tables("rc_dbdnr").Rows(i).Item("fzdw").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 7) = Trim(rcDataSet.Tables("rc_dbdnr").Rows(i).Item("fzdw"))
                    End If
                    If Not rcDataSet.Tables("rc_dbdnr").Rows(i).Item("oldcpdm").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 8) = Trim(rcDataSet.Tables("rc_dbdnr").Rows(i).Item("oldcpdm"))
                    End If
                    If Not rcDataSet.Tables("rc_dbdnr").Rows(i).Item("dbmemo").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 8) = Trim(rcDataSet.Tables("rc_dbdnr").Rows(i).Item("dbmemo"))
                    End If
                    If Not rcDataSet.Tables("rc_dbdnr").Rows(i).Item("oldcpdm").GetType.ToString = "System.DBNull" And Not rcDataSet.Tables("rc_dbdnr").Rows(i).Item("dbmemo").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 8) = Trim(rcDataSet.Tables("rc_dbdnr").Rows(i).Item("oldcpdm")) & " " & Trim(rcDataSet.Tables("rc_dbdnr").Rows(i).Item("dbmemo"))
                    End If
                    j += 1
                End If
            Next

            Dim m As New models.ChineseNum With {
                .InputString = dblTotalSl
            }
            rcRps.PerPageText(intPage, 7) = IIf(intPage = Math.Ceiling(rcDataSet.Tables("rc_dbdnr").Rows.Count / rcRps.LinesPerPage.ToString), "�ϼ�", "С��")
            '��rcRps.PerPageText(intPage, 8) = m.OutString '��д
            rcRps.PerPageText(intPage, 9) = Format(dblTotalSl, g_FormatSl)
            rcRps.PerPageText(intPage, 11) = Format(dblTotalFzsl, g_FormatSl)
        Next
        If Decimal.op_Modulus(rcDataSet.Tables("rc_dbdnr").Rows.Count, rcRps.LinesPerPage.ToString) <> 0 Then
            For i = Decimal.op_Modulus(rcDataSet.Tables("rc_dbdnr").Rows.Count, rcRps.LinesPerPage.ToString) + 1 To rcRps.LinesPerPage.ToString
                rcRps.Text(j + 1, 1) = ""
                j += 1
            Next
        End If
        rcRps.Text(-1, 14) = "�Ƶ���" & g_User_DspName
    End Sub

#End Region

#Region "��ӡ�����¼�"

    Private Sub PageSetupEvent()
        Dim rcFrmPageSetup As New models.FrmPageSetup
        With rcFrmPageSetup
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = "DBDBZ"
            .paraRpsName = "��������׼��ʽ"
            .ShowDialog()
        End With
    End Sub

    Private Sub MnuiPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPageSetup.Click
        PageSetupEvent()
    End Sub

#End Region

#Region "��ӡ�¼�"

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click, MnuiPrint.Click
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

    Private Sub FrmInvDbdSrz_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If IsEditing Then
            MsgBox("�Ѿ��༭�����ݣ��뱣�����ݡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            e.Cancel = True
        End If
    End Sub

#End Region

End Class