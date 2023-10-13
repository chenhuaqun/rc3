Imports System.Data.OleDb
Imports System.Math
Imports System.IO

Public Class FrmPmRkdSrz

    '����OLEDB��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '����OleDb���ݶ���
    Dim rcOleDbTrans As OleDbTransaction
    '����OleDb����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '����Datatable '����Ҫ���ø�datatable���н�����
    ReadOnly dtRkd As New DataTable("rc_rkdnr")
    '����Datatable '����Ҫ���ø�datatable���н�����
    ReadOnly dtRkdref As New DataTable("rc_rkdref")
    '����DataGridViewTextBoxEditingControl����
    Dim EditingControl As DataGridViewTextBoxEditingControl
    '����ڼ�
    Dim strKjqj As String = g_Kjqj
    '��
    Dim strYear As String = ""
    '��
    Dim strMonth As String = ""
    '���ӵ��ݵı���
    Dim IsAdding As Boolean = False
    '�޸ĵ��ݵı���
    Dim IsEditing As Boolean = False
    '�ϼƱ���
    Dim dblTotSl As Double = 0.0
    Dim dblTotFzsl As Double = 0.0
    Dim dblTotJe As Double = 0.0
    '��ӡ�ĵ�
    Dim rcRps As RPS.Document = Nothing

#Region "��ʼ��"

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

    Private Sub FrmPmRkdSrz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        Me.rcDataGridView.Columns("ColJe").DefaultCellStyle.Format = "0.00"
        'ȡ������������
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE lxgs = '������ⵥ' and kjnd = '" & strYear & "' ORDER BY pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_lx") IsNot Nothing Then
                Me.rcDataset.Tables("rc_lx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_lx")
            rcOleDbCommand.CommandText = "SELECT parastrvalue FROM rc_para WHERE dwdm = ? AND paraid LIKE 'PMRKD��������%' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message)
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_lx").Rows.Count = 0 Then
            MsgBox("�붨�嵥�����͡�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        BindDropDownList(CmbPzlxjc, rcDataset.Tables("rc_lx"), "pzlxdm", "pzlxjc")
        Dim i As Integer
        For i = 0 To rcDataset.Tables("rc_para").Rows.Count - 1
            Me.rcDataGridView.Columns(rcDataset.Tables("rc_para").Rows(i).Item("parastrvalue")).Visible = False
        Next

        'Me.TxtZydm.AutoCompleteSource = AutoCompleteSource.CustomSource
        ''���Y�ρG�M���
        'Dim oArray(rcDataSet.Tables("rc_zyxx").Rows.Count - 1) As String
        'For i As Integer = 0 To rcDataSet.Tables("rc_zyxx").Rows.Count - 1
        '    oArray.SetValue(rcDataSet.Tables("rc_zyxx").Rows(i).Item("zydm") & " " & rcDataSet.Tables("rc_zyxx").Rows(i).Item("zymc"), i)
        'Next
        ''ʹ��TextBox��AutoCompleteCustomSource.AddRange����һ�μ���
        ''����ޒȦ��һ�Pһ�P�����ٶȺ���
        'Me.TxtZydm.AutoCompleteMode = AutoCompleteMode.Suggest
        'Me.TxtZydm.AutoCompleteCustomSource.AddRange(oArray)

        '���ݰ�
        dtRkd.Columns.Add("cpdm", Type.GetType("System.String"))
        dtRkd.Columns.Add("cpmc", Type.GetType("System.String"))
        dtRkd.Columns.Add("hth", Type.GetType("System.String"))
        dtRkd.Columns.Add("scph", Type.GetType("System.String"))
        dtRkd.Columns.Add("sl", Type.GetType("System.Double"))
        dtRkd.Columns.Add("dw", Type.GetType("System.String"))
        dtRkd.Columns.Add("mjsl", Type.GetType("System.Double"))
        dtRkd.Columns.Add("fzsl", Type.GetType("System.Double"))
        dtRkd.Columns.Add("fzdw", Type.GetType("System.String"))
        dtRkd.Columns.Add("rgdj", Type.GetType("System.Double"))
        dtRkd.Columns.Add("rgcb", Type.GetType("System.Double"))
        dtRkd.Columns.Add("dj", Type.GetType("System.Double"))
        dtRkd.Columns.Add("je", Type.GetType("System.Double"))
        dtRkd.Columns.Add("rkmemo", Type.GetType("System.String"))
        rcDataset.Tables.Add(dtRkd)
        With rcDataset.Tables("rc_rkdnr")
            .Columns("cpdm").DefaultValue = ""
            .Columns("hth").DefaultValue = ""
            .Columns("scph").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("mjsl").DefaultValue = 0.0
            .Columns("fzsl").DefaultValue = 0.0
            .Columns("rgdj").DefaultValue = 0.0
            .Columns("rgcb").DefaultValue = 0.0
            .Columns("dj").DefaultValue = 0.0
            .Columns("je").DefaultValue = 0.0
            .Columns("rkmemo").DefaultValue = ""
        End With
        '���ݰ�
        dtRkdref.Columns.Add("xz", Type.GetType("System.Boolean"))
        dtRkdref.Columns.Add("cpdm", Type.GetType("System.String"))
        dtRkdref.Columns.Add("cpmc", Type.GetType("System.String"))
        dtRkdref.Columns.Add("hth", Type.GetType("System.String"))
        dtRkdref.Columns.Add("sl", Type.GetType("System.Double"))
        dtRkdref.Columns.Add("dw", Type.GetType("System.String"))
        dtRkdref.Columns.Add("mjsl", Type.GetType("System.Double"))
        dtRkdref.Columns.Add("fzsl", Type.GetType("System.Double"))
        dtRkdref.Columns.Add("fzdw", Type.GetType("System.String"))
        rcDataset.Tables.Add(dtRkdref)
        With rcDataset.Tables("rc_rkdref")
            .Columns("xz").DefaultValue = 0
            .Columns("cpdm").DefaultValue = ""
            .Columns("cpmc").DefaultValue = ""
            .Columns("dw").DefaultValue = ""
            .Columns("hth").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("mjsl").DefaultValue = 0.0
            .Columns("fzsl").DefaultValue = 0.0
        End With
        '������the DataGrid to the DataSet.
        Me.rcBindingSource.DataSource = dtRkd
        Me.rcDataGridView.DataSource = Me.rcBindingSource
        strKjqj = strYear & strMonth.PadLeft(2, "0")
        If GetInvKjqj(g_Kjrq) = strKjqj Then
            DtpRkrq.Value = Now()
        Else
            DtpRkrq.Value = GetInvEnd(strYear, strMonth)
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
            If dtRkd.Rows.Count > 0 Then
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

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbPzlxjc.KeyPress, TxtDjh.KeyPress, DtpRkrq.KeyPress, TxtZydm.KeyPress, TxtBmdm.KeyPress, TxtGxdm.KeyPress, TxtCkdm.KeyPress
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
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtDjh_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtDjh.Validating
        If Me.TxtDjh.TextLength <> 15 Then
            e.Cancel = True
            Return
        End If
        '�ж����ӻ����޸�
        If rcDataset.Tables("rc_pzno").Rows.Count > 0 Then
            If rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") >= Mid(Trim(Me.TxtDjh.Text), 15, 5) Then
                '1)�޸ĵ���
                Try
                    rcOleDbConn.Open()
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    rcOleDbCommand.CommandText = "SELECT inv_rkd.djh,TRUNC(inv_rkd.rkrq,'mi') AS rkrq,inv_rkd.bdelete,inv_rkd.zydm,inv_rkd.zymc,inv_rkd.bmdm,inv_rkd.bmmc,inv_rkd.gxdm,inv_rkd.gxmc,inv_rkd.ckdm,inv_rkd.ckmc,inv_rkd.bmrp,inv_rkd.srr,inv_rkd.shr,inv_rkd.jzr FROM inv_rkd WHERE (djh = ? )"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.TxtDjh.Text
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("rc_rkdnr") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_rkdnr").Clear()
                    End If
                    If rcDataset.Tables("rc_rkdml") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_rkdml").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "rc_rkdml")
                    If rcDataset.Tables("rc_rkdml").Rows.Count > 0 Then
                        '�ѽ���MRP���㲻���޸�
                        Dim blnMrp As Boolean = False
                        Dim i As Integer
                        For i = 0 To rcDataset.Tables("rc_rkdml").Rows.Count - 1
                            If rcDataset.Tables("rc_rkdml").Rows(i).Item("bmrp").GetType.ToString <> "System.DBNull" Then
                                If rcDataset.Tables("rc_rkdml").Rows(i).Item("bmrp") = 1 Then
                                    blnMrp = True
                                End If
                            End If
                        Next
                        If blnMrp Then
                            MsgBox("�õ����Ѿ�����MRP���㣬�����޸ġ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                            Me.TxtDjh.Text = rcDataset.Tables("rc_pzno").Rows(0).Item("pzlxdm") & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                        Else
                            If rcDataset.Tables("rc_rkdml").Rows(0).Item("jzr").GetType.ToString <> "System.DBNull" Then
                                MsgBox("�õ����Ѿ����ˣ������޸ġ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                                TxtDjh.Text = rcDataset.Tables("rc_pzno").Rows(0).Item("pzlxdm") & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                            Else
                                If rcDataset.Tables("rc_rkdml").Rows(0).Item("shr").GetType.ToString <> "System.DBNull" Then
                                    MsgBox("�õ����Ѿ���ˣ������޸ġ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                                    TxtDjh.Text = rcDataset.Tables("rc_pzno").Rows(0).Item("pzlxdm") & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                                Else
                                    Me.DtpRkrq.Value = rcDataset.Tables("rc_rkdml").Rows(0).Item("rkrq")
                                    Me.LblBdelete.Text = IIf(rcDataset.Tables("rc_rkdml").Rows(0).Item("bdelete"), "����", "")
                                    If rcDataset.Tables("rc_rkdml").Rows(0).Item("ckdm").GetType.ToString <> "System.DBNull" Then
                                        Me.TxtCkdm.Text = rcDataset.Tables("rc_rkdml").Rows(0).Item("ckdm")
                                    End If
                                    If rcDataset.Tables("rc_rkdml").Rows(0).Item("ckmc").GetType.ToString <> "System.DBNull" Then
                                        Me.LblCkmc.Text = rcDataset.Tables("rc_rkdml").Rows(0).Item("ckmc")
                                    End If
                                    If rcDataset.Tables("rc_rkdml").Rows(0).Item("bmdm").GetType.ToString <> "System.DBNull" Then
                                        Me.TxtBmdm.Text = rcDataset.Tables("rc_rkdml").Rows(0).Item("bmdm")
                                    End If
                                    If rcDataset.Tables("rc_rkdml").Rows(0).Item("bmmc").GetType.ToString <> "System.DBNull" Then
                                        Me.LblBmmc.Text = rcDataset.Tables("rc_rkdml").Rows(0).Item("bmmc")
                                    End If
                                    If rcDataset.Tables("rc_rkdml").Rows(0).Item("gxdm").GetType.ToString <> "System.DBNull" Then
                                        Me.TxtGxdm.Text = rcDataset.Tables("rc_rkdml").Rows(0).Item("gxdm")
                                    End If
                                    If rcDataset.Tables("rc_rkdml").Rows(0).Item("gxmc").GetType.ToString <> "System.DBNull" Then
                                        Me.LblGxmc.Text = rcDataset.Tables("rc_rkdml").Rows(0).Item("gxmc")
                                    End If
                                    If rcDataset.Tables("rc_rkdml").Rows(0).Item("zydm").GetType.ToString <> "System.DBNull" Then
                                        Me.TxtZydm.Text = rcDataset.Tables("rc_rkdml").Rows(0).Item("zydm")
                                    Else
                                        Me.TxtZydm.Text = ""
                                    End If
                                    If rcDataset.Tables("rc_rkdml").Rows(0).Item("zymc").GetType.ToString <> "System.DBNull" Then
                                        Me.LblZymc.Text = rcDataset.Tables("rc_rkdml").Rows(0).Item("zymc")
                                    Else
                                        Me.LblZymc.Text = ""
                                    End If
                                    '�޸ĵ���
                                    rcOleDbCommand.CommandText = "SELECT inv_rkd.cpdm,COALESCE(inv_rkd.cpmc,'') as cpmc,inv_rkd.hth,inv_rkd.scph,inv_rkd.sl,COALESCE(inv_rkd.dw,'') as dw,inv_rkd.mjsl,inv_rkd.fzsl,inv_rkd.fzdw,inv_rkd.rgdj,inv_rkd.rgcb,inv_rkd.dj,inv_rkd.je,inv_rkd.rkmemo FROM inv_rkd WHERE (inv_rkd.djh = ?) ORDER BY inv_rkd.XH"
                                    rcOleDbCommand.Parameters.Clear()
                                    rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = TxtDjh.Text
                                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                    If rcDataset.Tables("rc_rkdnr") IsNot Nothing Then
                                        Me.rcDataset.Tables("rc_rkdnr").Clear()
                                    End If
                                    rcOleDbDataAdpt.Fill(rcDataset, "rc_rkdnr")
                                    SumSlJe() '���˰��ϼ�
                                    IsAdding = False
                                End If
                            End If
                        End If
                    End If
                Catch ex As Exception
                    MsgBox("�������" & Chr(13) & ex.Message)
                Finally
                    rcOleDbConn.Close()
                End Try
            Else
                '2)��������
                IsAdding = True
            End If
        End If
        If IsAdding Then
            NewEvent()
        End If
        Me.rcDataGridView.ClearSelection()
    End Sub

#End Region

#Region "����ϼ���"

    Private Sub SumSlJe()
        '����ϼ���
        dblTotSl = 0.0
        dblTotFzsl = 0.0
        dblTotJe = 0.0

        If dtRkd.Rows.Count > 0 Then
            dblTotSl = dtRkd.Compute("Sum(sl)", "")
            dblTotFzsl = dtRkd.Compute("Sum(fzsl)", "")
            dblTotJe = dtRkd.Compute("Sum(je)", "")
        End If
        Me.LblSl.Text = "�����ϼƣ�" + Format(dblTotSl, g_FormatSl)
        Me.LblFzsl.Text = "�������ϼƣ�" + Format(dblTotFzsl, g_FormatSl)
        Me.LblJe.Text = "���ϼƣ�" + Format(dblTotJe, g_FormatJe)
    End Sub

#End Region

#Region "��������¼�"

    Private Sub DtpRkrq_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DtpRkrq.Validating
        '������ڼ�
        Dim dateBegin As DateTime
        Dim dateEnd As DateTime
        dateBegin = GetInvBegin(strYear, strMonth)
        dateEnd = GetInvEnd(strYear, strMonth)
        If Me.DtpRkrq.Value > dateEnd Or Me.DtpRkrq.Value < dateBegin Then
            MsgBox("����������ڲ��ڵ�ǰ����ڼ��У��������롣", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            e.Cancel = True
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
                    .paraOrderField = "zymc"
                    .paraTitle = "ְԱ"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtZydm.Text = Trim(.paraField1)
                        Me.LblZymc.Text = Trim(.paraField2)
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
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "SELECT rc_zyxx.zydm,rc_zyxx.zymc FROM rc_zyxx WHERE (zydm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(Me.TxtZydm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_zyxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_zyxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_zyxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_zyxx").Rows.Count > 0 Then
                Me.TxtZydm.Text = Trim(rcDataset.Tables("rc_zyxx").Rows(0).Item("zydm"))
                Me.LblZymc.Text = Trim(rcDataset.Tables("rc_zyxx").Rows(0).Item("zymc"))
            Else
                MsgBox("ְԱ���벻���ڣ��������롣", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
                e.Cancel = True
            End If
        End If
        If Not String.IsNullOrEmpty(Me.TxtZydm.Text) Then
            If Not IsEditing Then
                IsEditing = True
                SetControlEnableEvent()
            End If
        End If
    End Sub

#End Region

#Region "���ű�����¼�"

    Private Sub TxtBmdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBmdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_bmxx"
                    .paraField1 = "bmdm"
                    .paraField2 = "bmmc"
                    .paraField3 = "bmsm"
                    .paraTitle = "����"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtBmdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtBmdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtBmdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtBmdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT bmdm,bmmc FROM rc_bmxx WHERE (bmdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(TxtBmdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_bmxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_bmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_bmxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_bmxx").Rows.Count > 0 Then
                TxtBmdm.Text = Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmdm"))
                LblBmmc.Text = Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmmc"))
            Else
                MsgBox("���ű��벻���ڣ��밴F3��ѡ��", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                e.Cancel = True
            End If
            '����Ƿ�����ϸ��¼
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT COUNT(*) AS gs FROM rc_bmxx WHERE (parentid = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtBmdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("reccnt") IsNot Nothing Then
                    Me.rcDataset.Tables("reccnt").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "reccnt")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("reccnt").Rows(0).Item("gs") > 0 Then
                MsgBox("����������ϸ���ű��롣", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                e.Cancel = True
            End If
            If Not IsEditing Then
                IsEditing = True
                SetControlEnableEvent()
            End If
        End If
    End Sub

#End Region

#Region "���������¼�"

    Private Sub TxtGxdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtGxdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_gxxx"
                    .paraField1 = "gxdm"
                    .paraField2 = "gxmc"
                    .paraField3 = "gxsm"
                    .paraTitle = "����"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtGxdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtGxdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtGxdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtGxdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_gxxx WHERE (gxdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@gxdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtGxdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_gxxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_gxxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_gxxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_gxxx").Rows.Count > 0 Then
                Me.TxtGxdm.Text = Trim(rcDataset.Tables("rc_gxxx").Rows(0).Item("gxdm"))
                Me.LblGxmc.Text = Trim(rcDataset.Tables("rc_gxxx").Rows(0).Item("gxmc"))
                If rcDataset.Tables("rc_gxxx").Rows(0).Item("gxdm").GetType.ToString <> "System.DBNull" Then
                    Me.TxtGxdm.Text = rcDataset.Tables("rc_gxxx").Rows(0).Item("gxdm")
                End If
                If rcDataset.Tables("rc_gxxx").Rows(0).Item("gxmc").GetType.ToString <> "System.DBNull" Then
                    Me.LblGxmc.Text = rcDataset.Tables("rc_gxxx").Rows(0).Item("gxmc")
                End If
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "�ֿ������¼�"

    Private Sub TxtCkdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCkdm.KeyDown
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
                        TxtCkdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtCkdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCkdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtCkdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_ckxx WHERE (ckdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(TxtCkdm.Text)
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
                Me.TxtCkdm.Text = Trim(rcDataset.Tables("rc_ckxx").Rows(0).Item("ckdm"))
                Me.LblCkmc.Text = Trim(rcDataset.Tables("rc_ckxx").Rows(0).Item("ckmc"))
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
    '    '����˵�Ԫ��ֻ���Ļ����ͻس�����
    '    If Me.rcDataGridView.CurrentCell.ReadOnly Then My.Computer.Keyboard.SendKeys("{Enter}")
    'End Sub

    Private Sub RcDataGridView_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles rcDataGridView.CellValidating
        If Me.rcDataGridView.CurrentRow.IsNewRow = False Then
            If Me.rcDataGridView.IsCurrentCellDirty Then
                Me.rcDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColCpdm" Then
                If Not String.IsNullOrEmpty(e.FormattedValue) Then
                    If Not String.IsNullOrEmpty(e.FormattedValue) Then
                        'ȡ������Ϣ
                        Try
                            rcOleDbConn.Open()
                            rcOleDbCommand.Connection = rcOleDbConn
                            rcOleDbCommand.CommandTimeout = 300
                            rcOleDbCommand.CommandType = CommandType.Text
                            rcOleDbCommand.CommandText = "SELECT * FROM rc_cpxx WHERE (rc_cpxx.cpdm = ? OR rc_cpxx.oldcpdm = ?) AND ty <> 1"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue
                            rcOleDbCommand.Parameters.Add("@oldcpdm", OleDbType.VarChar, 15).Value = rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                                rcDataset.Tables("rc_cpxx").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
                            If rcDataset.Tables("rc_cpxx").Rows.Count > 0 Then
                                Me.rcDataGridView.CurrentRow.Cells("ColCpdm").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("cpdm")
                                Me.rcDataGridView.CurrentRow.Cells("ColCpmc").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("cpmc")
                                Me.rcDataGridView.CurrentRow.Cells("ColDw").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("dw")
                                If rcDataset.Tables("rc_cpxx").Rows(0).Item("mjsl").GetType.ToString <> "System.DBNull" And Me.rcDataGridView.CurrentRow.Cells("ColMjsl").Value = 0 Then
                                    Me.rcDataGridView.CurrentRow.Cells("ColMjsl").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("mjsl")
                                End If
                                If rcDataset.Tables("rc_cpxx").Rows(0).Item("fzdw").GetType.ToString <> "System.DBNull" Then
                                    Me.rcDataGridView.CurrentRow.Cells("ColFzdw").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("fzdw")
                                End If
                                'If rcDataSet.Tables("rc_cpxx").Rows(0).Item("bzcb").GetType.ToString <> "System.DBNull" And Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = 0.0 Then
                                '    Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = rcDataSet.Tables("rc_cpxx").Rows(0).Item("bzcb")
                                'End If
                                'ȡ���¿������
                                rcOleDbCommand.CommandText = "SELECT COALESCE(Sum(qcsl+idsl),0.0) as kcsl FROM inv_cpyeb WHERE kjnd = ? AND cpdm = ?"
                                rcOleDbCommand.Parameters.Clear()
                                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = strYear
                                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue
                                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                If rcDataset.Tables("inv_cpyeb") IsNot Nothing Then
                                    rcDataset.Tables("inv_cpyeb").Clear()
                                End If
                                rcOleDbDataAdpt.Fill(rcDataset, "inv_cpyeb")
                                If rcDataset.Tables("inv_cpyeb").Rows.Count = 1 Then
                                    Me.LblMsg.Text = "��ǰ���������" & rcDataset.Tables("inv_cpyeb").Rows(0).Item("kcsl")
                                Else
                                    Me.LblMsg.Text = "��ǰ��������� 0.00 "
                                End If
                            Else
                                Me.LblMsg.Text = "���ϱ��벻���ڡ�"
                                e.Cancel = True
                            End If
                        Catch ex As Exception
                            MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                            Return
                        Finally
                            rcOleDbConn.Close()
                        End Try
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColSl" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    '��ȡ��浥��
                    Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = ReadBzcb(Me.rcDataGridView.CurrentRow.Cells("ColCpdm").Value)
                    Me.rcDataGridView.CurrentRow.Cells("ColJe").Value = Me.rcDataGridView.CurrentRow.Cells("ColDj").Value * e.FormattedValue
                    If Me.rcDataGridView.CurrentRow.Cells("ColRgdj").Value <> 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColRgcb").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColRgcb").Value * e.FormattedValue, 2, MidpointRounding.AwayFromZero)
                    End If
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
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColDj" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    If e.FormattedValue <> 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColJe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColSl").Value * e.FormattedValue, 2, MidpointRounding.AwayFromZero)
                    End If
                Else
                    Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = 0.0
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColRgdj" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    If e.FormattedValue <> 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColRgcb").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColRgdj").Value * e.FormattedValue, 2, MidpointRounding.AwayFromZero)
                    End If
                Else
                    Me.rcDataGridView.CurrentRow.Cells("ColRgdj").Value = 0.0
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
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColRgcb" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    If e.FormattedValue <> 0 And Me.rcDataGridView.CurrentRow.Cells("ColSl").Value <> 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColRgdj").Value = System.Math.Round(e.FormattedValue / Me.rcDataGridView.CurrentRow.Cells("ColRgsl").Value, 6, MidpointRounding.AwayFromZero)
                    End If
                Else
                    Me.rcDataGridView.CurrentRow.Cells("ColRgcb").Value = 0.0
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
                Me.rcBindingSource.EndEdit()
                Me.rcDataGridView.EndEdit()
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
    End Sub

    Private Sub RcDataGridView_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles rcDataGridView.Leave
        Me.rcDataGridView.ClearSelection()
    End Sub

    Private Sub RcDataGridView_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles rcDataGridView.RowValidating
        If Not Me.rcDataGridView.CurrentRow.IsNewRow Then
            Me.rcBindingSource.EndEdit()
            Me.rcDataGridView.EndEdit()
        End If
        If dtRkd.Rows.Count > 0 Then
            IsEditing = True
            SetControlEnableEvent()
            SumSlJe()
        End If
    End Sub

#End Region

#Region "�µ��¼�"

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, MnuiNew.Click
        NewEvent()
        Me.TxtDjh.Focus()
    End Sub

    Private Sub NewEvent()
        '�������
        Me.LblBdelete.Text = ""
        Me.TxtZydm.Text = ""
        Me.LblZymc.Text = ""
        Me.TxtBmdm.Text = ""
        Me.LblBmmc.Text = ""
        Me.TxtGxdm.Text = ""
        Me.LblGxmc.Text = ""
        Me.TxtCkdm.Text = ""
        Me.LblCkmc.Text = ""
        IsAdding = True
        IsEditing = False
        Me.LblMsg.Text = "���˴���ʾ�����Ҫ�ص���ϸ���ݡ���"
        '��ʾ�µ��ݺ�
        ShowNewDjh()
        '�������
        If rcDataset.Tables("rc_rkdnr") IsNot Nothing Then
            Me.rcDataset.Tables("rc_rkdnr").Clear()
        End If
    End Sub

    Private Sub ShowNewDjh()
        'ȡ������������
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzno" & strMonth & " as pzno FROM rc_lx WHERE pzlxdm = ? and lxgs = '������ⵥ' and kjnd = '" & strYear & "'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@pzlxdm", OleDbType.VarChar, 4).Value = Trim(Me.CmbPzlxjc.SelectedValue)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_pzno") IsNot Nothing Then
                Me.rcDataset.Tables("rc_pzno").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_pzno")
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message)
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_pzno").Rows.Count = 0 Then
            MsgBox("�붨�嵥�����͡�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        Me.TxtDjh.Text = rcDataset.Tables("rc_pzno").Rows(0).Item("pzlxdm") & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
    End Sub

#End Region

#Region "�����¼�"

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MnuiSave.Click
        SaveEvent(False)
    End Sub

    Private Sub SaveEvent(ByVal blnPrint As Boolean)
        Dim i As Integer
        '(һ)���ݺϷ��Լ��
        '(1)
        If String.IsNullOrEmpty(Me.TxtZydm.Text) Then
            MsgBox("�����뾭���ˡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
            Return
        End If
        '(2)
        If String.IsNullOrEmpty(Me.TxtBmdm.Text) Then
            MsgBox("�������������š�", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
            Return
        End If
        '(3)
        If String.IsNullOrEmpty(Me.TxtGxdm.Text) Then
            MsgBox("��������������", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
            Return
        End If
        '(4)�ֿ������
        If String.IsNullOrEmpty(Me.TxtCkdm.Text) Then
            MsgBox("�ֿ���벻��Ϊ�ա�", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            Return
        End If
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Trim(TxtCkdm.Text)
            rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_ckxx"
            rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "ckdm"
            rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
            rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
            rcOleDbCommand.ExecuteNonQuery()
            If rcOleDbCommand.Parameters.Item("@paraIntRecordCount").Value <> 1 Then
                MsgBox(Trim(TxtCkdm.Text) & "�ֿ���벻��ȷ�����顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                Me.TxtCkdm.Text = ""
                Me.LblCkmc.Text = ""
                Me.TxtCkdm.Focus()
                Return
            End If
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '(1)�Ƿ�����Ҫ�洢������
        If rcDataset.Tables("rc_rkdnr").Rows.Count = 0 Then
            MsgBox("û����Ӧ��ҵ�������롣", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
            Return
        End If
        If Not String.IsNullOrEmpty(Me.TxtZydm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.StoredProcedure
                rcOleDbCommand.CommandText = "USP_CHECK_CODE"
                '(2)ְԱ����
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 12).Value = Trim(Me.TxtZydm.Text)
                rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_zyxx"
                rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "zydm"
                rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
                rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
                rcOleDbCommand.ExecuteNonQuery()
                If rcOleDbCommand.Parameters("@paraIntRecordCount").Value <> 1 Then
                    MsgBox("ְԱ���벻��ȷ�����顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                    Return
                End If
                '���ű���
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 12).Value = Trim(Me.TxtBmdm.Text)
                rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_bmxx"
                rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "bmdm"
                rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
                rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
                rcOleDbCommand.ExecuteNonQuery()
                If rcOleDbCommand.Parameters("@paraIntRecordCount").Value <> 1 Then
                    MsgBox("���ű��벻��ȷ�����顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                    Return
                End If
                '�������
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 12).Value = Trim(Me.TxtGxdm.Text)
                rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_gxxx"
                rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "gxdm"
                rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
                rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
                rcOleDbCommand.ExecuteNonQuery()
                If rcOleDbCommand.Parameters("@paraIntRecordCount").Value <> 1 Then
                    MsgBox("������벻��ȷ�����顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                    Return
                End If
                '�ֿ����
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 12).Value = Trim(Me.TxtCkdm.Text)
                rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_ckxx"
                rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "ckdm"
                rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
                rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
                rcOleDbCommand.ExecuteNonQuery()
                If rcOleDbCommand.Parameters("@paraIntRecordCount").Value <> 1 Then
                    MsgBox("�ֿ���벻��ȷ�����顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                    Return
                End If
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        End If
        '(3)���ϱ���
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            For i = 0 To rcDataset.Tables("rc_rkdnr").Rows.Count - 1
                If rcDataset.Tables("rc_rkdnr").Rows(i).RowState <> DataRowState.Deleted Then
                    rcOleDbCommand.CommandType = CommandType.Text
                    rcOleDbCommand.CommandText = "SELECT * FROM rc_cpxx WHERE cpdm = ? AND ty <> 1"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.AddWithValue("@cpdm", Trim(rcDataset.Tables("rc_rkdnr").Rows(i).Item("cpdm")))
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("cpdmcnt") IsNot Nothing Then
                        Me.rcDataset.Tables("cpdmcnt").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "cpdmcnt")

                    If rcDataset.Tables("cpdmcnt").Rows.Count <> 1 Then
                        MsgBox(Trim(rcDataset.Tables("rc_rkdnr").Rows(i).Item("cpdm")) & "���ϱ��벻��ȷ�����顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                        Return
                    Else
                        ''�жϱ�׼�ɱ��ǲ���Ϊ��
                        'If rcDataSet.Tables("cpdmcnt").Rows(0).Item("bzcb") = 0 Then
                        '    MsgBox(Trim(rcDataSet.Tables("rc_rkdnr").Rows(i).Item("cpdm")) & "���ϵı�׼�ɱ�Ϊ�㣬���顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                        'End If
                    End If
                    If rcDataset.Tables("rc_rkdnr").Rows(i).Item("sl").GetType.ToString <> "System.DBNull" Then
                        If rcDataset.Tables("rc_rkdnr").Rows(i).Item("sl") = 0 Then
                            MsgBox("�������Ϊ���㡿��������������", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                            Return
                        End If
                    Else
                        MsgBox("�������Ϊ���㡿��������������", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                        Return
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox("�������3��" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '(4)���ݺų��ȼ��
        If Trim(Me.TxtDjh.Text).Length <> 15 Then
            MsgBox("���ݺų��Ȳ���ȷ�����顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
            Return
        End If
        '(��)�洢ml
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP3_SAVE_PM_RKD"
            For i = 0 To rcDataset.Tables("rc_rkdnr").Rows.Count - 1
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = IIf(IsAdding, 1, 0)
                rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = Trim(Me.TxtDjh.Text)
                rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = i + 1
                rcOleDbCommand.Parameters.Add("@paraDateRkrq", OleDbType.Date, 8).Value = Me.DtpRkrq.Value
                rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = IIf(String.IsNullOrEmpty(Me.LblBdelete.Text), 0, 1)
                rcOleDbCommand.Parameters.Add("@paraStrZydm", OleDbType.VarChar, 12).Value = Me.TxtZydm.Text
                rcOleDbCommand.Parameters.Add("@paraStrZymc", OleDbType.VarChar, 30).Value = Me.LblZymc.Text
                rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = Me.TxtBmdm.Text
                rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 30).Value = Me.LblBmmc.Text
                rcOleDbCommand.Parameters.Add("@paraStrGxdm", OleDbType.VarChar, 12).Value = Me.TxtGxdm.Text
                rcOleDbCommand.Parameters.Add("@paraStrGxmc", OleDbType.VarChar, 30).Value = Me.LblGxmc.Text
                rcOleDbCommand.Parameters.Add("@ParaStrCkdm", OleDbType.VarChar, 12).Value = Me.TxtCkdm.Text
                rcOleDbCommand.Parameters.Add("@paraStrCkmc", OleDbType.VarChar, 30).Value = Me.LblCkmc.Text
                rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("rc_rkdnr").Rows(i).Item("cpdm")).ToUpper
                rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("rc_rkdnr").Rows(i).Item("cpmc")
                rcOleDbCommand.Parameters.Add("@paraStrHth", OleDbType.VarChar, 20).Value = rcDataset.Tables("rc_rkdnr").Rows(i).Item("hth")
                rcOleDbCommand.Parameters.Add("@paraStrScph", OleDbType.VarChar, 20).Value = rcDataset.Tables("rc_rkdnr").Rows(i).Item("scph")
                rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_rkdnr").Rows(i).Item("sl")
                rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = rcDataset.Tables("rc_rkdnr").Rows(i).Item("dw")
                rcOleDbCommand.Parameters.Add("@paraDblMjsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_rkdnr").Rows(i).Item("mjsl")
                rcOleDbCommand.Parameters.Add("@paraDblFzsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_rkdnr").Rows(i).Item("fzsl")
                rcOleDbCommand.Parameters.Add("@paraStrFzdw", OleDbType.VarChar, 8).Value = rcDataset.Tables("rc_rkdnr").Rows(i).Item("fzdw")
                rcOleDbCommand.Parameters.Add("@paraDblRgdj", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_rkdnr").Rows(i).Item("rgdj")
                rcOleDbCommand.Parameters.Add("@paraDblRgcb", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_rkdnr").Rows(i).Item("rgcb")
                rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_rkdnr").Rows(i).Item("dj")
                rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_rkdnr").Rows(i).Item("je")
                rcOleDbCommand.Parameters.Add("@paraStrRkmemo", OleDbType.VarChar, 50).Value = rcDataset.Tables("rc_rkdnr").Rows(i).Item("rkmemo")
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
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
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

#Region "����/�ָ�"

    Private Sub MnuiZf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiZf.Click
        If Me.LblBdelete.Text = "����" Then
            Me.LblBdelete.Text = ""
        Else
            Me.LblBdelete.Text = "����"
        End If
        IsEditing = True
        SetControlEnableEvent()
    End Sub

#End Region

#Region "����DataGridView���¼�"

    Private Sub BtnIns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIns.Click, MnuiIns.Click
        If Me.rcDataGridView.ReadOnly = False Then
            If dtRkd.Rows.Count > 0 Then
                Dim row As DataRow = dtRkd.NewRow
                dtRkd.Rows.InsertAt(row, rcDataGridView.CurrentCell.RowIndex)
                dtRkd.AcceptChanges()
            End If
        End If
    End Sub

#End Region

#Region "ɾ��DataGridView���¼�"

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, MnuiDelete.Click
        DeleteEvent()
    End Sub

    Private Sub DeleteEvent()
        If Me.rcDataGridView.ReadOnly = False Then
            If dtRkd.Rows.Count > 0 Then
                dtRkd.Rows(rcDataGridView.CurrentRow.Index).Delete()
                dtRkd.AcceptChanges()
                IsEditing = True
                SetControlEnableEvent()
            End If
        End If
        'If Me.rcDataGridView.ReadOnly = False Then
        '    If Me.rcBindingSource.Count > 0 Then
        '        'MsgBox(dtrkd.Rows.Count.ToString)
        '        'MsgBox(rcDataGridView.CurrentRow.Index.ToString)
        '        'Me.rcBindingSource.RemoveCurrent()
        '        'Me.rcDataGridView.Refresh()
        '        'rcDataGridView.Rows.Remove(rcDataGridView.CurrentRow)
        '        dtrkd.Rows.RemoveAt(rcDataGridView.CurrentRow.Index)
        '        dtrkd.AcceptChanges()
        '        IsEditing = True
        '        SetControlEnableEvent()
        '    End If
        'End If
    End Sub
#End Region

#Region "׼����ӡ����"

    Private Sub PreparePrintData()
        If rcRps Is Nothing Then
            rcRps = New RPS.Document
        End If
        Dim rft As String = Application.StartupPath + "\reports\gxrkd.rft"
        rcRps.LoadTemplate(rft)
        'ȡRPS��ӡ����
        rcOleDbConn.Open()
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps WHERE rpsid = 'GXRKD'"
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
        rcRps.Text(-1, 1) = g_PrnDwmc & "������ⵥ"
        rcRps.Text(-1, 2) = "�ֿ⣺(" & Me.TxtCkdm.Text & ")" & Me.LblCkmc.Text
        rcRps.Text(-1, 3) = "�����ˣ�(" & Me.TxtZydm.Text & ")" & Me.LblZymc.Text
        rcRps.Text(-1, 4) = "���ݺţ�" & Me.TxtDjh.Text & "  %p/%t"
        rcRps.Text(-1, 5) = "���ţ�(" & Me.TxtBmdm.Text & ")" & Me.LblBmmc.Text
        rcRps.Text(-1, 6) = "����(" & Me.TxtGxdm.Text & ")" & Me.LblGxmc.Text
        rcRps.Text(-1, 7) = "���ڣ�" & Me.DtpRkrq.Value.ToLongDateString
        Dim i As Integer
        Dim j As Integer
        Dim intPage As Integer
        Dim dblTotalSl As Double = 0.0
        Dim dblTotalFzsl As Double = 0.0
        For intPage = 1 To System.Math.Ceiling(rcDataSet.Tables("rc_rkdnr").Rows.Count / rcRps.LinesPerPage.ToString)
            For i = (intPage - 1) * rcRps.LinesPerPage.ToString To System.Math.Min(intPage * rcRps.LinesPerPage.ToString - 1, rcDataSet.Tables("rc_rkdnr").Rows.Count - 1)
                If rcDataSet.Tables("rc_rkdnr").Rows(i).RowState <> 8 Then
                    If Not rcDataSet.Tables("rc_rkdnr").Rows(i).Item("cpdm").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 1) = Trim(rcDataSet.Tables("rc_rkdnr").Rows(i).Item("cpdm"))
                    End If
                    If Not rcDataSet.Tables("rc_rkdnr").Rows(i).Item("cpmc").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 2) = Trim(rcDataSet.Tables("rc_rkdnr").Rows(i).Item("cpmc"))
                    End If
                    If Not rcDataSet.Tables("rc_rkdnr").Rows(i).Item("scph").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 3) = Trim(rcDataSet.Tables("rc_rkdnr").Rows(i).Item("scph"))
                    End If
                    If Not rcDataSet.Tables("rc_rkdnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 4) = Format(rcDataSet.Tables("rc_rkdnr").Rows(i).Item("sl"), g_FormatSl)
                        dblTotalSl += rcDataSet.Tables("rc_rkdnr").Rows(i).Item("sl")
                    End If
                    If Not rcDataSet.Tables("rc_rkdnr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 5) = Trim(rcDataSet.Tables("rc_rkdnr").Rows(i).Item("dw"))
                    End If
                    If Not rcDataSet.Tables("rc_rkdnr").Rows(i).Item("fzsl").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 6) = Format(rcDataSet.Tables("rc_rkdnr").Rows(i).Item("fzsl"), g_FormatSl)
                        dblTotalFzsl += rcDataSet.Tables("rc_rkdnr").Rows(i).Item("fzsl")
                    End If
                    If Not rcDataSet.Tables("rc_rkdnr").Rows(i).Item("fzdw").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 7) = Trim(rcDataSet.Tables("rc_rkdnr").Rows(i).Item("fzdw"))
                    End If
                    If Not rcDataSet.Tables("rc_rkdnr").Rows(i).Item("rkmemo").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 8) = Trim(rcDataSet.Tables("rc_rkdnr").Rows(i).Item("rkmemo"))
                    End If
                    j += 1
                End If
            Next
            'Dim m As New models.ChineseNum
            'm.InputString = dblTotalJe
            rcRps.PerPageText(intPage, 8) = IIf(intPage = Math.Ceiling(rcDataSet.Tables("rc_rkdnr").Rows.Count / rcRps.LinesPerPage.ToString), "�ϼ�", "С��")
            'rcRps.PerPageText(intPage, 7) = m.OutString '��д
            rcRps.PerPageText(intPage, 10) = Format(dblTotalSl, g_FormatSl)
            rcRps.PerPageText(intPage, 12) = Format(dblTotalFzsl, g_FormatSl)
            'dblTotalJe = 0.0
        Next
        If Decimal.op_Modulus(rcDataSet.Tables("rc_rkdnr").Rows.Count, rcRps.LinesPerPage.ToString) <> 0 Then
            For i = Decimal.op_Modulus(rcDataSet.Tables("rc_rkdnr").Rows.Count, rcRps.LinesPerPage.ToString) + 1 To rcRps.LinesPerPage.ToString
                rcRps.Text(j + 1, 1) = ""
                j += 1
            Next
        End If
        rcRps.Text(-1, 15) = "�Ƶ���" & g_User_DspName
    End Sub

#End Region

#Region "��ӡ�����¼�"

    Private Sub PageSetupEvent()
        Dim rcFrmPageSetup As New models.FrmPageSetup
        With rcFrmPageSetup
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = "GXRKD"
            .paraRpsName = "������ⵥ��׼��ʽ"
            .ShowDialog()
        End With
    End Sub

    Private Sub MnuiPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPageSetup.Click
        PageSetupEvent()
    End Sub

#End Region

#Region "��ӡ�¼�"

    Private Sub MnuiPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrint.Click
        SaveEvent(True)
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
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

    Private Sub MnuiPrintView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrintView.Click
        PrintViewEvent()
    End Sub

    Private Sub BtnPrintView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrintView.Click
        PrintViewEvent()
    End Sub

    Private Sub PrintViewEvent()
        PreparePrintData()
        rcRps.Preview()
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

    'Private Sub FrmPmRkdSrz2_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
    '    If IsEditing Then
    '        MsgBox("�Ѿ��༭�����ݣ��뱣�����ݡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
    '        e.Cancel = True
    '    End If
    'End Sub

#End Region

#Region "����¼��"

    Private Sub BtnReference_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReference.Click
        '���ñ�
        Dim rcFrm As New FrmPmRkdReference
        With rcFrm
            .ParaDataSet = rcDataSet
            .MdiParent = Me.MdiParent
            .Show()
        End With
        Me.rcDataGridView.Focus()
    End Sub

#End Region
End Class