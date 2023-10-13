Imports System.Data.OleDb
Imports System.Math
Imports System.IO

Public Class FrmOeXsdSrz

    '����OLEDB��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '����OleDb���ݶ���
    Dim rcOleDbTrans As OleDbTransaction
    '����OleDb����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '����Datatable '����Ҫ���ø�datatable���н�����
    ReadOnly dtXsd As New DataTable("rc_xsdnr")
    '����Datatable '����Ҫ���ø�datatable���н�����
    ReadOnly dtXsdref As New DataTable("rc_xsdref")
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
    Dim dblTotSe As Double = 0.0
    '��ӡ�ĵ�
    Dim rcRps As RPS.Document = Nothing
    ''��ӡ��ʽ
    'Dim intdygs As Integer = 0
    ''�״��־
    'Dim blnTd As Boolean = False
    Dim blnReCalculate As Boolean = True
    '��ӡ��ʽ
    Dim strRpsId As String = "SHDBZ"

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

    Private Sub FrmOeXsdSrz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '����DataGridView
        Me.rcDataGridView.AutoGenerateColumns = False
        Me.rcDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColMjsl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColMjsl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColFzsl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColFzsl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColJs").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColJs").DefaultCellStyle.Format = g_FormatInt
        Me.rcDataGridView.Columns("ColLt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColLt").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColTs").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColTs").DefaultCellStyle.Format = g_FormatInt
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
        ''ȡ�״��ʽ��ӡ���۵�
        'Try
        '    rcOleDbConn.Open()
        '    rcOleDbCommand.Connection = rcOleDbConn
        '    rcOleDbCommand.CommandTimeout = 300
        '    rcOleDbCommand.CommandType = CommandType.Text
        '    rcOleDbCommand.CommandText = "SELECT paradblvalue FROM rc_para WHERE dwdm = ? AND paraid = '�״��ʽ��ӡ���۵�' ORDER BY paraid"
        '    rcOleDbCommand.Parameters.Clear()
        '    rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
        '    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
        '    If Not rcDataSet.Tables("rc_para") Is Nothing Then
        '        Me.rcDataSet.Tables("rc_para").Clear()
        '    End If
        '    rcOleDbDataAdpt.Fill(rcDataSet, "rc_para")
        '    If rcDataSet.Tables("rc_para").Rows.Count = 1 Then
        '        If rcDataSet.Tables("rc_para").Rows(0).Item("paradblvalue").GetType.ToString <> "System.DBNull" Then
        '            blnTd = rcDataSet.Tables("rc_para").Rows(0).Item("paradblvalue")
        '        End If
        '    End If
        'Catch ex As Exception
        '    MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
        '    Return
        'Finally
        '    rcOleDbConn.Close()
        'End Try
        'ȡ������������
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE lxgs = '��Ʒ�ͻ���' and kjnd = '" & strYear & "' ORDER BY pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_lx") IsNot Nothing Then
                Me.rcDataset.Tables("rc_lx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_lx")
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
        BindDropDownList(Me.CmbPzlxjc, rcDataset.Tables("rc_lx"), "pzlxdm", "pzlxjc")

        '���ݰ�
        dtXsd.Columns.Add("cpdm", Type.GetType("System.String"))
        dtXsd.Columns.Add("oldcpdm", Type.GetType("System.String"))
        dtXsd.Columns.Add("cpmc", Type.GetType("System.String"))
        dtXsd.Columns.Add("hth", Type.GetType("System.String"))
        dtXsd.Columns.Add("khddh", Type.GetType("System.String"))
        dtXsd.Columns.Add("khlh", Type.GetType("System.String"))
        dtXsd.Columns.Add("sl", Type.GetType("System.Double"))
        dtXsd.Columns.Add("dw", Type.GetType("System.String"))
        dtXsd.Columns.Add("mjsl", Type.GetType("System.Double"))
        dtXsd.Columns.Add("fzsl", Type.GetType("System.Double"))
        dtXsd.Columns.Add("fzdw", Type.GetType("System.String"))
        dtXsd.Columns.Add("js", Type.GetType("System.Int32"))
        dtXsd.Columns.Add("lt", Type.GetType("System.Double"))
        dtXsd.Columns.Add("ts", Type.GetType("System.Int32"))
        dtXsd.Columns.Add("dj", Type.GetType("System.Double"))
        dtXsd.Columns.Add("hsdj", Type.GetType("System.Double"))
        dtXsd.Columns.Add("je", Type.GetType("System.Double"))
        dtXsd.Columns.Add("shlv", Type.GetType("System.Double"))
        dtXsd.Columns.Add("se", Type.GetType("System.Double"))
        dtXsd.Columns.Add("jese", Type.GetType("System.Double"))
        dtXsd.Columns.Add("xsmemo", Type.GetType("System.String"))
        dtXsd.Columns.Add("dddjh", Type.GetType("System.String"))
        dtXsd.Columns.Add("ddxh", Type.GetType("System.Int32"))
        rcDataset.Tables.Add(dtXsd)
        With rcDataset.Tables("rc_xsdnr")
            .Columns("cpdm").DefaultValue = ""
            .Columns("oldcpdm").DefaultValue = ""
            .Columns("hth").DefaultValue = ""
            .Columns("khddh").DefaultValue = ""
            .Columns("khlh").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("mjsl").DefaultValue = 0.0
            .Columns("fzsl").DefaultValue = 0.0
            .Columns("js").DefaultValue = 0
            .Columns("lt").DefaultValue = 0.0
            .Columns("ts").DefaultValue = 0
            .Columns("dj").DefaultValue = 0
            .Columns("hsdj").DefaultValue = 0
            .Columns("je").DefaultValue = 0.0
            .Columns("shlv").DefaultValue = getParaValue("��ֵ˰Ĭ��˰��", False)
            .Columns("se").DefaultValue = 0
            .Columns("jese").DefaultValue = 0
            .Columns("xsmemo").DefaultValue = ""
            .Columns("dddjh").DefaultValue = ""
            .Columns("ddxh").DefaultValue = 0
        End With
        '���ݰ�
        dtXsdref.Columns.Add("xz", Type.GetType("System.Boolean"))
        dtXsdref.Columns.Add("cpdm", Type.GetType("System.String"))
        dtXsdref.Columns.Add("cpmc", Type.GetType("System.String"))
        dtXsdref.Columns.Add("hth", Type.GetType("System.String"))
        dtXsdref.Columns.Add("khddh", Type.GetType("System.String"))
        dtXsdref.Columns.Add("khlh", Type.GetType("System.String"))
        dtXsdref.Columns.Add("scjhrq", Type.GetType("System.DateTime"))
        dtXsdref.Columns.Add("sl", Type.GetType("System.Double"))
        dtXsdref.Columns.Add("dw", Type.GetType("System.String"))
        dtXsdref.Columns.Add("mjsl", Type.GetType("System.Double"))
        dtXsdref.Columns.Add("fzsl", Type.GetType("System.Double"))
        dtXsdref.Columns.Add("fzdw", Type.GetType("System.String"))
        dtXsdref.Columns.Add("dj", Type.GetType("System.Double"))
        dtXsdref.Columns.Add("hsdj", Type.GetType("System.Double"))
        dtXsdref.Columns.Add("je", Type.GetType("System.Double"))
        dtXsdref.Columns.Add("shlv", Type.GetType("System.Double"))
        dtXsdref.Columns.Add("se", Type.GetType("System.Double"))
        dtXsdref.Columns.Add("jese", Type.GetType("System.Double"))
        dtXsdref.Columns.Add("xsmemo", Type.GetType("System.String"))
        rcDataset.Tables.Add(dtXsdref)
        With rcDataset.Tables("rc_xsdref")
            .Columns("xz").DefaultValue = 0
            .Columns("cpdm").DefaultValue = ""
            .Columns("cpmc").DefaultValue = ""
            .Columns("hth").DefaultValue = ""
            .Columns("khddh").DefaultValue = ""
            .Columns("khlh").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("dw").DefaultValue = ""
            .Columns("mjsl").DefaultValue = 0.0
            .Columns("fzsl").DefaultValue = 0.0
            .Columns("fzdw").DefaultValue = ""
            .Columns("dj").DefaultValue = 0
            .Columns("hsdj").DefaultValue = 0
            .Columns("je").DefaultValue = 0.0
            .Columns("shlv").DefaultValue = getParaValue("��ֵ˰Ĭ��˰��", False)
            .Columns("se").DefaultValue = 0
            .Columns("jese").DefaultValue = 0
        End With
        '������the DataGrid to the DataSet.
        Me.rcBindingSource.DataSource = dtXsd
        Me.rcDataGridView.DataSource = Me.rcBindingSource
        strKjqj = strYear & strMonth.PadLeft(2, "0")
        If getInvKjqj(g_Kjrq) = strKjqj Then
            DtpXsrq.Value = g_Kjrq
        Else
            DtpXsrq.Value = getInvEnd(strYear, strMonth)
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
            If dtXsd.Rows.Count > 0 Then
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

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbPzlxjc.KeyPress, TxtDjh.KeyPress, DtpXsrq.KeyPress, TxtZydm.KeyPress, TxtKhdm.KeyPress, TxtBmdm.KeyPress, TxtCkdm.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                'ָʾ KeyPress �¼��Ѵ�����ȥ�� Windows ȱʡ�Ķ�������
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
                    rcOleDbCommand.CommandText = "SELECT oe_xsd.djh,oe_xsd.xsrq,oe_xsd.bdelete,oe_xsd.zydm,oe_xsd.zymc,oe_xsd.khdm,oe_xsd.khmc,oe_xsd.bmdm,oe_xsd.bmmc,oe_xsd.ckdm,oe_xsd.ckmc,oe_xsd.srr,oe_xsd.shr,oe_xsd.jzr,oe_xsd.bsign,oe_xsd.fpsl FROM oe_xsd WHERE (djh = ? )"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.TxtDjh.Text
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("rc_xsdnr") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_xsdnr").Clear()
                    End If
                    If rcDataset.Tables("rc_xsdml") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_xsdml").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "rc_xsdml")
                    If rcDataset.Tables("rc_xsdml").Rows.Count > 0 Then
                        '���տ���޸�
                        Dim blnFp As Boolean = False
                        Dim i As Integer
                        For i = 0 To rcDataset.Tables("rc_xsdml").Rows.Count - 1
                            If rcDataset.Tables("rc_xsdml").Rows(i).Item("fpsl").GetType.ToString <> "System.DBNull" Then
                                If rcDataset.Tables("rc_xsdml").Rows(i).Item("fpsl") <> 0 Then
                                    blnFp = True
                                End If
                            End If
                        Next
                        If blnFp Then
                            MsgBox("�õ����Ѿ���Ʊ�������޸ġ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                            Me.TxtDjh.Text = rcDataset.Tables("rc_pzno").Rows(0).Item("pzlxdm") & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                            IsAdding = True
                        Else
                            '�ص��ջأ������޸�
                            If rcDataset.Tables("rc_xsdml").Rows(0).Item("bsign") = 1 Then
                                MsgBox("�õ����Ѿ��ջػص��������޸ġ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                                Me.TxtDjh.Text = rcDataset.Tables("rc_pzno").Rows(0).Item("pzlxdm") & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                                IsAdding = True
                            Else
                                If rcDataset.Tables("rc_xsdml").Rows(0).Item("jzr").GetType.ToString <> "System.DBNull" Then
                                    MsgBox("�õ����Ѿ����ˣ������޸ġ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                                    Me.TxtDjh.Text = rcDataset.Tables("rc_pzno").Rows(0).Item("pzlxdm") & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                                    IsAdding = True
                                Else
                                    If rcDataset.Tables("rc_xsdml").Rows(0).Item("shr").GetType.ToString <> "System.DBNull" Then
                                        MsgBox("�õ����Ѿ���ˣ������޸ġ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                                        TxtDjh.Text = rcDataset.Tables("rc_pzno").Rows(0).Item("pzlxdm") & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                                        IsAdding = True
                                    Else

                                        Me.DtpXsrq.Value = rcDataset.Tables("rc_xsdml").Rows(0).Item("xsrq")
                                        Me.LblBdelete.Text = IIf(rcDataset.Tables("rc_xsdml").Rows(0).Item("bdelete"), "����", "")
                                        If rcDataset.Tables("rc_xsdml").Rows(0).Item("zydm").GetType.ToString <> "System.DBNull" Then
                                            Me.TxtZydm.Text = rcDataset.Tables("rc_xsdml").Rows(0).Item("zydm")
                                        End If
                                        If rcDataset.Tables("rc_xsdml").Rows(0).Item("zymc").GetType.ToString <> "System.DBNull" Then
                                            Me.LblZymc.Text = rcDataset.Tables("rc_xsdml").Rows(0).Item("zymc")
                                        End If
                                        If rcDataset.Tables("rc_xsdml").Rows(0).Item("khdm").GetType.ToString <> "System.DBNull" Then
                                            Me.TxtKhdm.Text = rcDataset.Tables("rc_xsdml").Rows(0).Item("khdm")
                                        End If
                                        If rcDataset.Tables("rc_xsdml").Rows(0).Item("khmc").GetType.ToString <> "System.DBNull" Then
                                            Me.LblKhmc.Text = rcDataset.Tables("rc_xsdml").Rows(0).Item("khmc")
                                        End If
                                        If rcDataset.Tables("rc_xsdml").Rows(0).Item("bmdm").GetType.ToString <> "System.DBNull" Then
                                            Me.TxtBmdm.Text = rcDataset.Tables("rc_xsdml").Rows(0).Item("bmdm")
                                        End If
                                        If rcDataset.Tables("rc_xsdml").Rows(0).Item("bmmc").GetType.ToString <> "System.DBNull" Then
                                            Me.LblBmmc.Text = rcDataset.Tables("rc_xsdml").Rows(0).Item("bmmc")
                                        End If
                                        If rcDataset.Tables("rc_xsdml").Rows(0).Item("ckdm").GetType.ToString <> "System.DBNull" Then
                                            Me.TxtCkdm.Text = rcDataset.Tables("rc_xsdml").Rows(0).Item("ckdm")
                                        End If
                                        If rcDataset.Tables("rc_xsdml").Rows(0).Item("ckmc").GetType.ToString <> "System.DBNull" Then
                                            Me.LblCkmc.Text = rcDataset.Tables("rc_xsdml").Rows(0).Item("ckmc")
                                        End If
                                        '�޸ĵ���
                                        rcOleDbCommand.CommandText = "SELECT oe_xsd.cpdm,rc_cpxx.oldcpdm,rc_cpxx.cpmc,COALESCE(oe_xsd.hth,'') AS hth,oe_xsd.khddh,oe_xsd.khlh,oe_xsd.sl,rc_cpxx.dw,rc_cpxx.mjsl,oe_xsd.fzsl,rc_cpxx.fzdw,oe_xsd.js,oe_xsd.lt,oe_xsd.ts,oe_xsd.dj,oe_xsd.hsdj,oe_xsd.je,oe_xsd.shlv,oe_xsd.se,(oe_xsd.je+ oe_xsd.se) AS jese,oe_xsd.xsmemo,oe_xsd.dddjh,oe_xsd.ddxh FROM oe_xsd,rc_cpxx WHERE oe_xsd.cpdm = rc_cpxx.cpdm AND (oe_xsd.djh = ?) ORDER BY oe_xsd.XH"
                                        rcOleDbCommand.Parameters.Clear()
                                        rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = TxtDjh.Text
                                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                        If rcDataset.Tables("rc_xsdnr") IsNot Nothing Then
                                            Me.rcDataset.Tables("rc_xsdnr").Clear()
                                        End If
                                        rcOleDbDataAdpt.Fill(rcDataset, "rc_xsdnr")
                                        If rcDataset.Tables("rc_xsdnr").Rows.Count > 0 Then
                                            If rcDataset.Tables("rc_xsdnr").Rows(0).Item("dddjh").GetType.ToString <> "System.DBNull" Then
                                                blnReCalculate = False
                                                'Me.BtnImp.Enabled = False
                                                Me.rcDataGridView.AllowUserToAddRows = False
                                                Me.ColCpdm.ReadOnly = True
                                                'Me.ColSl.ReadOnly = True
                                                'Me.ColMjsl.ReadOnly = True
                                                'Me.ColFzsl.ReadOnly = True
                                                Me.BtnIns.Enabled = False
                                                Me.MnuiIns.Enabled = False
                                            Else
                                                blnReCalculate = True
                                            End If
                                        Else
                                            blnReCalculate = True
                                        End If
                                        SumSlJe() '�������ϼ�
                                        IsAdding = False
                                    End If
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
        dblTotSe = 0.0
        If rcDataset.Tables("rc_xsdnr").Rows.Count > 0 Then
            dblTotSl = rcDataset.Tables("rc_xsdnr").Compute("Sum(sl)", "")
            dblTotFzsl = rcDataset.Tables("rc_xsdnr").Compute("Sum(fzsl)", "")
            dblTotJe = rcDataset.Tables("rc_xsdnr").Compute("Sum(je)", "")
            dblTotSe = rcDataset.Tables("rc_xsdnr").Compute("Sum(se)", "")
        End If
        Me.LblSl.Text = "�����ϼƣ�" + Format(dblTotSl, g_FormatSl)
        Me.LblFzsl.Text = "�������ϼƣ�" + Format(dblTotFzsl, g_FormatSl)
        Me.LblJe.Text = "���ϼƣ�" + Format(dblTotJe, g_FormatJe)
        Me.LblSe.Text = "˰��ϼƣ�" + Format(dblTotSe, g_FormatJe)
        Me.LblJese.Text = "��˰�ϼƣ�" + Format(dblTotJe + dblTotSe, g_FormatJe)
    End Sub

#End Region

#Region "���������¼�"

    Private Sub DtpXsrq_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DtpXsrq.Validating
        '������ڼ�
        Dim dateBegin As DateTime
        Dim dateEnd As DateTime
        dateBegin = GetInvBegin(strYear, strMonth)
        dateEnd = GetInvEnd(strYear, strMonth)
        If DtpXsrq.Value > dateEnd Or DtpXsrq.Value < dateBegin Then
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
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
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

#Region "�ͻ������¼�"

    Private Sub TxtKhdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtKhdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrmF3KeyPress As New models.FrmF3KeyPress
                With rcFrmF3KeyPress
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_khxx"
                    .paraField1 = "khdm"
                    .paraField2 = "khmc"
                    .paraField3 = "khsm"
                    .paraCondition = "0=0"
                    .paraOrderField = "khmc"
                    .paraTitle = "�ͻ�"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtKhdm.Text = Trim(.paraField1)
                        LblKhmc.Text = Trim(.paraField2)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtKhdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtKhdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtKhdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_khxx WHERE (khdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(TxtKhdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_khxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_khxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_khxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message)
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_khxx").Rows.Count > 0 Then
                Me.TxtKhdm.Text = Trim(rcDataset.Tables("rc_khxx").Rows(0).Item("khdm"))
                Me.LblKhmc.Text = rcDataset.Tables("rc_khxx").Rows(0).Item("khmc")
                If String.IsNullOrEmpty(Me.TxtZydm.Text) Then
                    If rcDataset.Tables("rc_khxx").Rows(0).Item("zydm").GetType.ToString <> "System.DBNull" Then
                        Me.TxtZydm.Text = rcDataset.Tables("rc_khxx").Rows(0).Item("zydm")
                    End If
                    If rcDataset.Tables("rc_khxx").Rows(0).Item("zymc").GetType.ToString <> "System.DBNull" Then
                        Me.LblZymc.Text = rcDataset.Tables("rc_khxx").Rows(0).Item("zymc")
                    End If
                End If
            Else
                MsgBox("�ͻ����벻���ڣ��������롣", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
                e.Cancel = True
            End If
        End If
        If Not String.IsNullOrEmpty(Me.TxtKhdm.Text) Then
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
    '    'If Me.rcDataGridView.CurrentCell.ReadOnly Then My.Computer.Keyboard.SendKeys("{Enter}")
    'End Sub

    Private Sub RcDataGridView_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles rcDataGridView.CellValidating
        If Me.rcDataGridView.CurrentRow.IsNewRow = False Then
            If Me.rcDataGridView.IsCurrentCellDirty Then
                Me.rcDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColCpdm" Then
                If Not String.IsNullOrEmpty(e.FormattedValue) Then
                    If Not String.IsNullOrEmpty(e.FormattedValue) Then
                        'ȡ��Ʒ��Ϣ
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
                                If blnReCalculate Then
                                    If Me.rcDataGridView.CurrentRow.Cells("ColSl").Value = 0 And Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = 0 Then
                                        If Not String.IsNullOrEmpty(Me.TxtKhdm.Text) Then
                                            'ȡδ���ⶩ���ż�δ��������
                                            rcOleDbCommand.CommandText = "SELECT khdm,cpdm,hth,sl - hxsl - cksl AS wcksl,dj,hsdj,shlv,khddh,khlh,djh,xh FROM oe_dd WHERE oe_dd.bclosed = 0 AND khdm = ? AND cpdm = ? AND sl - hxsl - cksl > 0 ORDER BY qdrq,xh"
                                            rcOleDbCommand.Parameters.Clear()
                                            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Me.TxtKhdm.Text
                                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("cpdm")
                                            If rcDataset.Tables("oe_dd") IsNot Nothing Then
                                                rcDataset.Tables("oe_dd").Clear()
                                            End If
                                            rcOleDbDataAdpt.Fill(rcDataset, "oe_dd")
                                            If rcDataset.Tables("oe_dd").Rows.Count > 0 Then
                                                Me.rcDataGridView.CurrentRow.Cells("ColHth").Value = rcDataset.Tables("oe_dd").Rows(0).Item("hth")
                                                Me.rcDataGridView.CurrentRow.Cells("ColKhddh").Value = rcDataset.Tables("oe_dd").Rows(0).Item("khddh")
                                                Me.rcDataGridView.CurrentRow.Cells("ColKhlh").Value = rcDataset.Tables("oe_dd").Rows(0).Item("khlh")
                                                If Me.rcDataGridView.CurrentRow.Cells("ColSl").Value = 0 Then
                                                    Me.rcDataGridView.CurrentRow.Cells("ColSl").Value = rcDataset.Tables("oe_dd").Rows(0).Item("wcksl")
                                                End If
                                                Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = rcDataset.Tables("oe_dd").Rows(0).Item("dj")
                                                Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value = rcDataset.Tables("oe_dd").Rows(0).Item("hsdj")
                                                Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value = rcDataset.Tables("oe_dd").Rows(0).Item("shlv")
                                                Me.rcDataGridView.CurrentRow.Cells("ColJe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColDj").Value * Me.rcDataGridView.CurrentRow.Cells("ColSl").Value, 2, MidpointRounding.AwayFromZero)
                                                Me.rcDataGridView.CurrentRow.Cells("ColJese").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value * Me.rcDataGridView.CurrentRow.Cells("ColSl").Value, 2, MidpointRounding.AwayFromZero)
                                                Me.rcDataGridView.CurrentRow.Cells("ColSe").Value = Me.rcDataGridView.CurrentRow.Cells("ColJese").Value - Me.rcDataGridView.CurrentRow.Cells("ColJe").Value
                                                Me.rcDataGridView.CurrentRow.Cells("ColDdDjh").Value = rcDataset.Tables("oe_dd").Rows(0).Item("djh")
                                                Me.rcDataGridView.CurrentRow.Cells("ColDdXh").Value = rcDataset.Tables("oe_dd").Rows(0).Item("xh")
                                            End If
                                        End If
                                    End If
                                End If
                            Else
                                Me.LblMsg.Text = "��Ʒ���벻���ڡ�"
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
            '�������¼�
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColHth" Then
                If Not String.IsNullOrEmpty(e.FormattedValue) Then
                    If blnReCalculate Then
                        If Not String.IsNullOrEmpty(e.FormattedValue) And Not String.IsNullOrEmpty(Me.rcDataGridView.CurrentRow.Cells("ColCpdm").Value) Then
                            'ȡ��ͬδ��������d
                            Try
                                rcOleDbConn.Open()
                                rcOleDbCommand.Connection = rcOleDbConn
                                rcOleDbCommand.CommandTimeout = 300
                                rcOleDbCommand.CommandType = CommandType.Text
                                rcOleDbCommand.CommandText = "SELECT sl - hxsl - cksl AS wcksl,dj,hsdj,shlv,khddh,khlh,djh,xh FROM oe_dd WHERE oe_dd.sl - oe_dd.hxsl - oe_dd.cksl > 0 AND oe_dd.bclosed = 0 AND khdm = ? AND cpdm = ? AND hth = ? ORDER BY qdrq,xh"
                                rcOleDbCommand.Parameters.Clear()
                                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Me.TxtKhdm.Text
                                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Me.rcDataGridView.CurrentRow.Cells("ColCpdm").Value
                                rcOleDbCommand.Parameters.Add("@hth", OleDbType.VarChar, 30).Value = rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColHth").EditedFormattedValue
                                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                If rcDataset.Tables("oe_dd") IsNot Nothing Then
                                    rcDataset.Tables("oe_dd").Clear()
                                End If
                                rcOleDbDataAdpt.Fill(rcDataset, "oe_dd")
                                If rcDataset.Tables("oe_dd").Rows.Count > 0 Then
                                    Me.rcDataGridView.CurrentRow.Cells("ColKhddh").Value = rcDataset.Tables("oe_dd").Rows(0).Item("khddh")
                                    Me.rcDataGridView.CurrentRow.Cells("ColKhlh").Value = rcDataset.Tables("oe_dd").Rows(0).Item("khlh")
                                    If Me.rcDataGridView.CurrentRow.Cells("ColSl").Value = 0 Then
                                        Me.rcDataGridView.CurrentRow.Cells("ColSl").Value = rcDataset.Tables("oe_dd").Rows(0).Item("wcksl")
                                    End If
                                    Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = rcDataset.Tables("oe_dd").Rows(0).Item("dj")
                                    Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value = rcDataset.Tables("oe_dd").Rows(0).Item("hsdj")
                                    Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value = rcDataset.Tables("oe_dd").Rows(0).Item("shlv")
                                    Me.rcDataGridView.CurrentRow.Cells("ColJe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColDj").Value * Me.rcDataGridView.CurrentRow.Cells("ColSl").Value, 2, MidpointRounding.AwayFromZero)
                                    Me.rcDataGridView.CurrentRow.Cells("ColJese").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value * Me.rcDataGridView.CurrentRow.Cells("ColSl").Value, 2, MidpointRounding.AwayFromZero)
                                    Me.rcDataGridView.CurrentRow.Cells("ColSe").Value = Me.rcDataGridView.CurrentRow.Cells("ColJese").Value - Me.rcDataGridView.CurrentRow.Cells("ColJe").Value
                                    Me.rcDataGridView.CurrentRow.Cells("ColDdDjh").Value = rcDataset.Tables("oe_dd").Rows(0).Item("djh")
                                    Me.rcDataGridView.CurrentRow.Cells("ColDdXh").Value = rcDataset.Tables("oe_dd").Rows(0).Item("xh")
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
            End If
            '�����¼�
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
                Else
                    Me.rcDataGridView.CurrentRow.Cells("ColSl").Value = 0.0
                End If
                '��������ֻ��С�ڵ���,���ܴ��ڶ�������
                If Me.rcDataGridView.CurrentRow.Cells("ColDdDjh").Value.GetType.ToString <> "System.DBNull" Then
                    If Me.rcDataGridView.CurrentRow.Cells("ColDdDjh").Value <> "" Then
                        Try
                            rcOleDbConn.Open()
                            rcOleDbCommand.Connection = rcOleDbConn
                            rcOleDbCommand.CommandTimeout = 300
                            rcOleDbCommand.CommandType = CommandType.Text
                            'ȡ�������۶���������
                            rcOleDbCommand.CommandText = "SELECT COALESCE(SUM(sl),0.0) AS ddsl FROM oe_dd WHERE djh = ? AND xh = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.rcDataGridView.CurrentRow.Cells("ColDdDjh").Value
                            rcOleDbCommand.Parameters.Add("@xh", OleDbType.Numeric, 4).Value = Me.rcDataGridView.CurrentRow.Cells("ColDdXh").Value
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("t_dd") IsNot Nothing Then
                                rcDataset.Tables("t_dd").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "t_dd")
                            'ȡ�������۶��������ͻ�����
                            rcOleDbCommand.CommandText = "SELECT COALESCE(SUM(sl),0.0) AS shsl FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND djh <> ? AND dddjh = ? AND ddxh = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.TxtDjh.Text
                            rcOleDbCommand.Parameters.Add("@dddjh", OleDbType.VarChar, 15).Value = Me.rcDataGridView.CurrentRow.Cells("ColDdDjh").Value
                            rcOleDbCommand.Parameters.Add("@ddxh", OleDbType.Numeric, 4).Value = Me.rcDataGridView.CurrentRow.Cells("ColDdXh").Value
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("t_xsd") IsNot Nothing Then
                                rcDataset.Tables("t_xsd").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "t_xsd")
                        Catch ex As Exception
                            MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                            Return
                        Finally
                            rcOleDbConn.Close()
                        End Try
                        If rcDataset.Tables("t_dd").Rows(0).Item("ddsl") - rcDataset.Tables("t_xsd").Rows(0).Item("shsl") < e.FormattedValue And e.FormattedValue > 0 Then
                            MsgBox("�ͻ������������۶������������顣", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "��ʾ��Ϣ")
                            e.Cancel = True
                            'End If
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
                If blnReCalculate Then
                    If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                        '¼�뺬˰��������
                        If e.FormattedValue <> 0 Then
                            Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value = System.Math.Round(e.FormattedValue * (1 + Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value / 100), 6, MidpointRounding.AwayFromZero)
                            Me.rcDataGridView.CurrentRow.Cells("ColJe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColSl").Value * e.FormattedValue, 2, MidpointRounding.AwayFromZero)
                            Me.rcDataGridView.CurrentRow.Cells("ColSe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColSl").Value * e.FormattedValue * Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value / 100, 2, MidpointRounding.AwayFromZero)
                            Me.rcDataGridView.CurrentRow.Cells("ColJese").Value = Me.rcDataGridView.CurrentRow.Cells("ColJe").Value + Me.rcDataGridView.CurrentRow.Cells("ColSe").Value
                        End If
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColHsdj" Then
                If blnReCalculate Then
                    If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                        Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = System.Math.Round(e.FormattedValue / (1 + Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value / 100), 6, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColJe").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColSl").Value * e.FormattedValue / (1 + Me.rcDataGridView.CurrentRow.Cells("ColShlv").Value / 100), 2, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColJese").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColSl").Value * e.FormattedValue, 2, MidpointRounding.AwayFromZero)
                        Me.rcDataGridView.CurrentRow.Cells("ColSe").Value = Me.rcDataGridView.CurrentRow.Cells("ColJese").Value - Me.rcDataGridView.CurrentRow.Cells("ColJe").Value
                    Else
                        Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value = 0.0
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColShlv" Then
                If blnReCalculate Then
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
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColJe" Then
                If blnReCalculate Then
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
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColSe" Then
                If blnReCalculate Then
                    If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                        If Me.rcDataGridView.CurrentRow.Cells("ColJe").Value <> 0 Then
                            Me.rcDataGridView.CurrentRow.Cells("ColJese").Value = e.FormattedValue + Me.rcDataGridView.CurrentRow.Cells("ColJe").Value
                            'Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value = System.Math.Round(Me.rcDataGridView.CurrentRow.Cells("ColJese").Value / Me.rcDataGridView.CurrentRow.Cells("ColSl").Value, 6, MidpointRounding.AwayFromZero)
                        End If
                    Else
                        Me.rcDataGridView.CurrentRow.Cells("ColSe").Value = 0.0
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColJese" Then
                If blnReCalculate Then
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
        If Me.rcDataGridView.CurrentCell.OwningColumn.Name = "ColCpdm" Or Me.rcDataGridView.CurrentCell.OwningColumn.Name = "ColKhdm" Then
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
        If dtXsd.Rows.Count > 0 Then
            IsEditing = True
            SetControlEnableEvent()
            SumSlJe()
        End If
    End Sub

#End Region

#Region "���뷢֪ͨ��"

    Private Sub BtnImpFhd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImpFhd.Click
        Me.rcDataGridView.Focus()
        If Not String.IsNullOrEmpty(Me.TxtKhdm.Text) Then
            '���ñ���
            Dim rcFrm As New FrmOeXsdImpFhd
            With rcFrm
                .ParaStrKhdm = Me.TxtKhdm.Text
                .ParaDataSet = rcDataset
                .ShowDialog()
                Me.rcDataGridView.AllowUserToAddRows = False
                Me.ColCpdm.ReadOnly = True
                Me.BtnIns.Enabled = False
                Me.MnuiIns.Enabled = False
                blnReCalculate = False
            End With
        Else
            MsgBox("����д�ͻ�����", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "��ʾ��Ϣ")
        End If
    End Sub

#End Region

#Region "�������۶���"

    Private Sub BtnImpDd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImpDd.Click
        Me.rcDataGridView.Focus()
        If Not String.IsNullOrEmpty(Me.TxtKhdm.Text) Then
            '���ñ���
            Dim rcFrm As New FrmOeXsdImpDd
            With rcFrm
                .ParaStrKhdm = Me.TxtKhdm.Text
                .ParaDataSet = rcDataset
                .ShowDialog()
                Me.rcDataGridView.AllowUserToAddRows = False
                Me.ColCpdm.ReadOnly = True
                Me.BtnIns.Enabled = False
                Me.MnuiIns.Enabled = False
                blnReCalculate = False
            End With
        Else
            MsgBox("����д�ͻ�����", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "��ʾ��Ϣ")
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
        Me.rcDataGridView.AllowUserToAddRows = True
        Me.LblBdelete.Text = ""
        Me.TxtZydm.Text = ""
        Me.LblZymc.Text = ""
        Me.TxtKhdm.Text = ""
        Me.LblKhmc.Text = ""
        Me.TxtBmdm.Text = ""
        Me.LblBmmc.Text = ""
        Me.TxtCkdm.Text = ""
        Me.LblCkmc.Text = ""
        Me.LblSl.Text = "�����ϼƣ�"
        Me.LblFzsl.Text = "�������ϼƣ�"
        Me.LblJe.Text = "���ϼƣ�"
        Me.LblSe.Text = "˰��ϼƣ�"
        Me.LblJese.Text = "��˰�ϼƣ�"
        IsAdding = True
        IsEditing = False
        blnReCalculate = True
        Me.LblMsg.Text = "���˴���ʾ������Ҫ�ص���ϸ���ݡ���"
        '��ʾ�µ��ݺ�
        ShowNewDjh()
        '�������
        If rcDataset.Tables("rc_xsdnr") IsNot Nothing Then
            Me.rcDataset.Tables("rc_xsdnr").Clear()
        End If
    End Sub

    Private Sub ShowNewDjh()
        'ȡ������������
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzno" & strMonth & " as pzno,bfushu FROM rc_lx WHERE pzlxdm = ? and lxgs = '��Ʒ�ͻ���' and kjnd = '" & strYear & "'"
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
        If String.IsNullOrEmpty(Me.TxtZydm.Text) Then
            MsgBox("�����뾭���ˡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
            Return
        End If
        '(2)�ֿ������
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
        '(2)�ͻ�����
        If String.IsNullOrEmpty(Me.TxtKhdm.Text) Then
            MsgBox("������ͻ����롣", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
            Return
        End If
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 12).Value = Trim(Me.TxtKhdm.Text)
            rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_khxx"
            rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "khdm"
            rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
            rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
            rcOleDbCommand.ExecuteNonQuery()
            If rcOleDbCommand.Parameters("@paraIntRecordCount").Value <> 1 Then
                MsgBox("�ͻ����벻��ȷ�����顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                Return
            End If
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '(2)�ͻ�����
        If String.IsNullOrEmpty(Me.TxtBmdm.Text) Then
            MsgBox("�����벿�ű��롣", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
            Return
        End If
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 12).Value = Trim(Me.TxtBmdm.Text)
            rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_bmxx"
            rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "bmdm"
            rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
            rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
            rcOleDbCommand.ExecuteNonQuery()
            If rcOleDbCommand.Parameters("@paraIntRecordCount").Value <> 1 Then
                MsgBox("�ͻ����벻��ȷ�����顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                Return
            End If
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '(5)DataTable��Ĭ��ֵ
        For i = 0 To rcDataset.Tables("rc_xsdnr").Rows.Count - 1
            If rcDataset.Tables("rc_xsdnr").Rows(i).Item("cpdm").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_xsdnr").Rows(i).Item("cpdm") = ""
            End If
            If rcDataset.Tables("rc_xsdnr").Rows(i).Item("cpmc").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_xsdnr").Rows(i).Item("cpmc") = ""
            End If
            If rcDataset.Tables("rc_xsdnr").Rows(i).Item("hth").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_xsdnr").Rows(i).Item("hth") = ""
            End If
            If rcDataset.Tables("rc_xsdnr").Rows(i).Item("khddh").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_xsdnr").Rows(i).Item("khddh") = ""
            End If
            If rcDataset.Tables("rc_xsdnr").Rows(i).Item("khlh").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_xsdnr").Rows(i).Item("khlh") = ""
            End If
            If rcDataset.Tables("rc_xsdnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_xsdnr").Rows(i).Item("sl") = 0.0
            End If
            If rcDataset.Tables("rc_xsdnr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_xsdnr").Rows(i).Item("dw") = ""
            End If
            If rcDataset.Tables("rc_xsdnr").Rows(i).Item("mjsl").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_xsdnr").Rows(i).Item("mjsl") = 0.0
            End If
            If rcDataset.Tables("rc_xsdnr").Rows(i).Item("fzsl").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_xsdnr").Rows(i).Item("fzsl") = 0.0
            End If
            If rcDataset.Tables("rc_xsdnr").Rows(i).Item("fzdw").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_xsdnr").Rows(i).Item("fzdw") = ""
            End If
            If rcDataset.Tables("rc_xsdnr").Rows(i).Item("dj").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_xsdnr").Rows(i).Item("dj") = 0.0
            End If
            If rcDataset.Tables("rc_xsdnr").Rows(i).Item("hsdj").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_xsdnr").Rows(i).Item("hsdj") = 0.0
            End If
            If rcDataset.Tables("rc_xsdnr").Rows(i).Item("je").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_xsdnr").Rows(i).Item("je") = 0.0
            End If
            If rcDataset.Tables("rc_xsdnr").Rows(i).Item("shlv").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_xsdnr").Rows(i).Item("shlv") = 16.0
            End If
            If rcDataset.Tables("rc_xsdnr").Rows(i).Item("se").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_xsdnr").Rows(i).Item("se") = 0.0
            End If
            If rcDataset.Tables("rc_xsdnr").Rows(i).Item("jese").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_xsdnr").Rows(i).Item("jese") = 0.0
            End If
            If rcDataset.Tables("rc_xsdnr").Rows(i).Item("xsmemo").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_xsdnr").Rows(i).Item("xsmemo") = ""
            End If
            If rcDataset.Tables("rc_xsdnr").Rows(i).Item("dddjh").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_xsdnr").Rows(i).Item("dddjh") = ""
            End If
            If rcDataset.Tables("rc_xsdnr").Rows(i).Item("ddxh").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_xsdnr").Rows(i).Item("ddxh") = 0
            End If
        Next

        '(1)�Ƿ�����Ҫ�洢������
        If rcDataset.Tables("rc_xsdnr").Rows.Count = 0 Then
            MsgBox("û����Ӧ��ҵ�������롣", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
            Return
        End If

        '(3)��Ʒ����
        rcOleDbConn.Open()
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            For i = 0 To rcDataset.Tables("rc_xsdnr").Rows.Count - 1
                If rcDataset.Tables("rc_xsdnr").Rows(i).RowState <> DataRowState.Deleted Then
                    rcOleDbCommand.CommandText = "SELECT * FROM rc_cpxx WHERE cpdm = ? AND ty <> 1"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.AddWithValue("@cpdm", Trim(rcDataset.Tables("rc_xsdnr").Rows(i).Item("cpdm")))
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("cpdmcnt") IsNot Nothing Then
                        Me.rcDataset.Tables("cpdmcnt").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "cpdmcnt")

                    If rcDataset.Tables("cpdmcnt").Rows.Count <> 1 Then
                        MsgBox(Trim(rcDataset.Tables("rc_xsdnr").Rows(i).Item("cpdm")) & "��Ʒ���벻��ȷ�����顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                        Return
                    End If
                    If rcDataset.Tables("rc_xsdnr").Rows(i).Item("sl").GetType.ToString <> "System.DBNull" Then
                        If rcDataset.Tables("rc_xsdnr").Rows(i).Item("sl") = 0 Then
                            MsgBox("��������Ϊ���㡿��������������", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                            Return
                        End If
                    Else
                        MsgBox("��������Ϊ���㡿��������������", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                        Return
                    End If
                    If rcDataset.Tables("rc_pzno").Rows(0).Item("bfushu") = 1 And rcDataset.Tables("rc_xsdnr").Rows(i).Item("sl") < 0 Then
                        MsgBox("����������ֹ��С���㡿�����顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                        Return
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '(4)���ݺų��ȼ��
        If Trim(Me.TxtDjh.Text).Length <> 15 Then
            MsgBox("���ݺų��Ȳ���ȷ�����顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
            Return
        End If
        '�������Ż���
        '������
        Dim dtCopy As DataTable
        Dim j As Integer
        Dim rcDataRow As DataRow
        Dim blnExists As Boolean
        dtCopy = rcDataset.Tables("rc_xsdnr").Clone
        '������
        '��������
        For j = 0 To rcDataset.Tables("rc_xsdnr").Rows.Count - 1
            blnExists = False
            For i = 0 To dtCopy.Rows.Count - 1
                If dtCopy.Rows(i).Item("dddjh").GetType.ToString <> "System.DBNull" And rcDataset.Tables("rc_xsdnr").Rows(j).Item("dddjh").GetType.ToString <> "System.DBNull" And dtCopy.Rows(i).Item("ddxh").GetType.ToString <> "System.DBNull" And rcDataset.Tables("rc_xsdnr").Rows(j).Item("ddxh").GetType.ToString <> "System.DBNull" Then
                    If dtCopy.Rows(i).Item("dddjh") = rcDataset.Tables("rc_xsdnr").Rows(j).Item("dddjh") And dtCopy.Rows(i).Item("ddxh") = rcDataset.Tables("rc_xsdnr").Rows(j).Item("ddxh") Then
                        blnExists = True
                    End If
                End If
            Next
            If Not blnExists Then
                rcDataRow = dtCopy.NewRow
                rcDataRow.Item("cpdm") = rcDataset.Tables("rc_xsdnr").Rows(j).Item("cpdm")
                rcDataRow.Item("cpmc") = rcDataset.Tables("rc_xsdnr").Rows(j).Item("cpmc")
                rcDataRow.Item("sl") = 0
                rcDataRow.Item("dddjh") = rcDataset.Tables("rc_xsdnr").Rows(j).Item("dddjh")
                rcDataRow.Item("ddxh") = rcDataset.Tables("rc_xsdnr").Rows(j).Item("ddxh")
                dtCopy.Rows.Add(rcDataRow)
            End If
        Next
        If String.IsNullOrEmpty(Me.LblBdelete.Text) Then
            For j = 0 To dtCopy.Rows.Count - 1
                dtCopy.Rows(j).Item("sl") = System.Math.Round(rcDataset.Tables("rc_xsdnr").Compute("SUM(sl)", "dddjh = '" & dtCopy.Rows(j).Item("dddjh") & "' and ddxh =" & dtCopy.Rows(j).Item("ddxh")), 6, MidpointRounding.AwayFromZero)
            Next
        End If

        '������۶����Ƿ����
        For i = 0 To dtCopy.Rows.Count - 1
            If Not String.IsNullOrEmpty(dtCopy.Rows(i).Item("dddjh")) Then
                Dim dblWrksl As Double
                dblWrksl = ReadOeWxssl(dtCopy.Rows(i).Item("cpdm"), dtCopy.Rows(i).Item("dddjh"), dtCopy.Rows(i).Item("ddxh"), Me.TxtDjh.Text)
                If dblWrksl >= 0 And dtCopy.Rows(i).Item("sl") > 0 And dblWrksl < dtCopy.Rows(i).Item("sl") Then
                    MsgBox("�����ϵ����۶������ͻ�����С���ͻ����������顣" & Chr(13) & "���ϱ��룺" & dtCopy.Rows(i).Item("cpdm") & Chr(13) & "�������ݺţ�" & dtCopy.Rows(i).Item("dddjh") & Chr(13) & "�����кţ�" & dtCopy.Rows(i).Item("ddxh") & Chr(13) & "��ǰ�ͻ�������" & dtCopy.Rows(i).Item("sl").ToString & Chr(13) & "���ͻ�������" & dblWrksl.ToString, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                    Return
                End If
                If dblWrksl < 0 And dtCopy.Rows(i).Item("sl") < 0 And dblWrksl > dtCopy.Rows(i).Item("sl") Then
                    MsgBox("�����ϵĶ������ͻ�����С���ͻ����������顣" & Chr(13) & "���ϱ��룺" & dtCopy.Rows(i).Item("cpdm") & Chr(13) & "�������ݺţ�" & dtCopy.Rows(i).Item("dddjh") & Chr(13) & "�����кţ�" & dtCopy.Rows(i).Item("ddxh") & Chr(13) & "��ǰ�ͻ�������" & dtCopy.Rows(i).Item("sl").ToString & "���ͻ�������" & dblWrksl.ToString, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                    Return
                End If
            End If
        Next
        ''������۶����Ƿ����
        'For i = 0 To rcDataSet.Tables("rc_xsdnr").Rows.Count - 1
        '    If Not String.IsNullOrEmpty(rcDataSet.Tables("rc_xsdnr").Rows(i).Item("dddjh")) Then
        '        Dim dblWrksl As Double = 0.0
        '        dblWrksl = ReadOeWxssl(rcDataSet.Tables("rc_xsdnr").Rows(i).Item("cpdm"), rcDataSet.Tables("rc_xsdnr").Rows(i).Item("dddjh"), rcDataSet.Tables("rc_xsdnr").Rows(i).Item("ddxh"), Me.TxtDjh.Text)
        '        If dblWrksl >= 0 And rcDataSet.Tables("rc_xsdnr").Rows(i).Item("sl") > 0 And dblWrksl < rcDataSet.Tables("rc_xsdnr").Rows(i).Item("sl") Then
        '            MsgBox("�����ϵĶ������ͻ�����С���ͻ����������顣" & rcDataSet.Tables("rc_xsdnr").Rows(i).Item("cpdm"), MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
        '            Return
        '        End If
        '        If dblWrksl < 0 And rcDataSet.Tables("rc_xsdnr").Rows(i).Item("sl") < 0 And dblWrksl > rcDataSet.Tables("rc_xsdnr").Rows(i).Item("sl") Then
        '            MsgBox("�����ϵĶ������ͻ�����С���ͻ����������顣" & rcDataSet.Tables("rc_xsdnr").Rows(i).Item("cpdm"), MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
        '            Return
        '        End If
        '    End If
        'Next


        '(��)�洢ml
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP3_SAVE_OE_XSD"
            For i = 0 To rcDataset.Tables("rc_xsdnr").Rows.Count - 1
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = IIf(IsAdding, 1, 0)
                rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = Trim(Me.TxtDjh.Text)
                rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = i + 1
                rcOleDbCommand.Parameters.Add("@paraDateXsrq", OleDbType.Date, 8).Value = Me.DtpXsrq.Value
                rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = IIf(String.IsNullOrEmpty(Me.LblBdelete.Text), 0, 1)
                rcOleDbCommand.Parameters.Add("@paraStrZydm", OleDbType.VarChar, 12).Value = Me.TxtZydm.Text
                rcOleDbCommand.Parameters.Add("@paraStrZymc", OleDbType.VarChar, 30).Value = Me.LblZymc.Text
                rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = Me.TxtKhdm.Text
                rcOleDbCommand.Parameters.Add("@paraStrKhmc", OleDbType.VarChar, 50).Value = Me.LblKhmc.Text
                rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = Me.TxtBmdm.Text
                rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 50).Value = Me.LblBmmc.Text
                rcOleDbCommand.Parameters.Add("@ParaStrCkdm", OleDbType.VarChar, 12).Value = Me.TxtCkdm.Text
                rcOleDbCommand.Parameters.Add("@paraStrCkmc", OleDbType.VarChar, 30).Value = Me.LblCkmc.Text
                rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("rc_xsdnr").Rows(i).Item("cpdm")).ToUpper
                rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("rc_xsdnr").Rows(i).Item("cpmc")
                rcOleDbCommand.Parameters.Add("@paraStrHth", OleDbType.VarChar, 30).Value = rcDataset.Tables("rc_xsdnr").Rows(i).Item("hth")
                rcOleDbCommand.Parameters.Add("@paraStrKhddh", OleDbType.VarChar, 30).Value = rcDataset.Tables("rc_xsdnr").Rows(i).Item("khddh")
                rcOleDbCommand.Parameters.Add("@paraStrKhlh", OleDbType.VarChar, 30).Value = rcDataset.Tables("rc_xsdnr").Rows(i).Item("khlh")
                rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_xsdnr").Rows(i).Item("sl")
                rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = rcDataset.Tables("rc_xsdnr").Rows(i).Item("dw")
                rcOleDbCommand.Parameters.Add("@paraDblMjsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_xsdnr").Rows(i).Item("mjsl")
                rcOleDbCommand.Parameters.Add("@paraDblFzsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_xsdnr").Rows(i).Item("fzsl")
                rcOleDbCommand.Parameters.Add("@paraStrFzdw", OleDbType.VarChar, 8).Value = rcDataset.Tables("rc_xsdnr").Rows(i).Item("fzdw")
                rcOleDbCommand.Parameters.Add("@paraIntJs", OleDbType.Integer, 12).Value = rcDataset.Tables("rc_xsdnr").Rows(i).Item("js")
                rcOleDbCommand.Parameters.Add("@paraDblLt", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_xsdnr").Rows(i).Item("lt")
                rcOleDbCommand.Parameters.Add("@paraIntTs", OleDbType.Integer, 12).Value = rcDataset.Tables("rc_xsdnr").Rows(i).Item("ts")
                rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_xsdnr").Rows(i).Item("dj")
                rcOleDbCommand.Parameters.Add("@paraDblHsdj", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_xsdnr").Rows(i).Item("hsdj")
                rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_xsdnr").Rows(i).Item("je")
                rcOleDbCommand.Parameters.Add("@paraDblShlv", OleDbType.Numeric, 6).Value = rcDataset.Tables("rc_xsdnr").Rows(i).Item("shlv")
                rcOleDbCommand.Parameters.Add("@paraDblSe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_xsdnr").Rows(i).Item("se")
                rcOleDbCommand.Parameters.Add("@paraStrXsmemo", OleDbType.VarChar, 50).Value = rcDataset.Tables("rc_xsdnr").Rows(i).Item("xsmemo")
                rcOleDbCommand.Parameters.Add("@paraStrDdDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_xsdnr").Rows(i).Item("dddjh")
                rcOleDbCommand.Parameters.Add("@paraIntDdXh", OleDbType.Integer, 4).Value = rcDataset.Tables("rc_xsdnr").Rows(i).Item("ddxh")
                rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                rcOleDbCommand.Parameters.Add("@paraCbill_bid", OleDbType.VarChar, 50).Value = ""
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

#Region "����"

    Private Sub MnuiWriteOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiWriteOff.Click
        Me.rcDataGridView.Focus()
        If Not IsEditing And IsAdding Then
            '���ñ���
            Dim rcFrm As New FrmOeXsdWriteOff
            Dim strDjh As String = ""
            Dim blnFp As Boolean = False
            With rcFrm
                .ShowDialog()
                blnFp = .paraBlnFp
                strDjh = .paraStrDjh
                If blnFp Then
                    MsgBox("�õ����Ѿ���Ʊ�����ܳ��������ȳ�����Ʒ���۵���", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                    Return
                End If
                '��ȡ���ֳ�������
                Try
                    rcOleDbConn.Open()
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    rcOleDbCommand.CommandText = "SELECT oe_xsd.djh,oe_xsd.xsrq,oe_xsd.bdelete,oe_xsd.zydm,oe_xsd.zymc,oe_xsd.khdm,oe_xsd.khmc,oe_xsd.bmdm,oe_xsd.bmmc,oe_xsd.ckdm,oe_xsd.ckmc,oe_xsd.srr,oe_xsd.shr,oe_xsd.jzr,oe_xsd.bsign,oe_xsd.fpsl FROM oe_xsd WHERE (djh = ? )"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = strDjh
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("rc_xsdnr") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_xsdnr").Clear()
                    End If
                    If rcDataset.Tables("rc_xsdml") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_xsdml").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "rc_xsdml")
                    If rcDataset.Tables("rc_xsdml").Rows.Count > 0 Then
                        'Me.DtpXsrq.Value = rcDataSet.Tables("rc_xsdml").Rows(0).Item("xsrq")
                        'Me.LblBdelete.Text = IIf(rcDataSet.Tables("rc_xsdml").Rows(0).Item("bdelete"), "����", "")
                        If rcDataset.Tables("rc_xsdml").Rows(0).Item("zydm").GetType.ToString <> "System.DBNull" Then
                            Me.TxtZydm.Text = rcDataset.Tables("rc_xsdml").Rows(0).Item("zydm")
                        End If
                        If rcDataset.Tables("rc_xsdml").Rows(0).Item("zymc").GetType.ToString <> "System.DBNull" Then
                            Me.LblZymc.Text = rcDataset.Tables("rc_xsdml").Rows(0).Item("zymc")
                        End If
                        If rcDataset.Tables("rc_xsdml").Rows(0).Item("khdm").GetType.ToString <> "System.DBNull" Then
                            Me.TxtKhdm.Text = rcDataset.Tables("rc_xsdml").Rows(0).Item("khdm")
                        End If
                        If rcDataset.Tables("rc_xsdml").Rows(0).Item("khmc").GetType.ToString <> "System.DBNull" Then
                            Me.LblKhmc.Text = rcDataset.Tables("rc_xsdml").Rows(0).Item("khmc")
                        End If
                        If rcDataset.Tables("rc_xsdml").Rows(0).Item("bmdm").GetType.ToString <> "System.DBNull" Then
                            Me.TxtBmdm.Text = rcDataset.Tables("rc_xsdml").Rows(0).Item("bmdm")
                        End If
                        If rcDataset.Tables("rc_xsdml").Rows(0).Item("bmmc").GetType.ToString <> "System.DBNull" Then
                            Me.LblBmmc.Text = rcDataset.Tables("rc_xsdml").Rows(0).Item("bmmc")
                        End If
                        If rcDataset.Tables("rc_xsdml").Rows(0).Item("ckdm").GetType.ToString <> "System.DBNull" Then
                            Me.TxtCkdm.Text = rcDataset.Tables("rc_xsdml").Rows(0).Item("ckdm")
                        End If
                        If rcDataset.Tables("rc_xsdml").Rows(0).Item("ckmc").GetType.ToString <> "System.DBNull" Then
                            Me.LblCkmc.Text = rcDataset.Tables("rc_xsdml").Rows(0).Item("ckmc")
                        End If
                        '�޸ĵ���
                        rcOleDbCommand.CommandText = "SELECT oe_xsd.cpdm,rc_cpxx.oldcpdm,rc_cpxx.cpmc,COALESCE(oe_xsd.hth,'') AS hth,oe_xsd.khddh,oe_xsd.khlh,0 �� oe_xsd.sl AS sl,rc_cpxx.dw,oe_xsd.mjsl,(0 - oe_xsd.fzsl) AS fzsl,rc_cpxx.fzdw,0- oe_xsd.js AS js,0- oe_xsd.lt AS lt,0- oe_xsd.ts AS ts,oe_xsd.dj,oe_xsd.hsdj,0 - oe_xsd.je AS je,oe_xsd.shlv,0 - oe_xsd.se AS se,0 - (oe_xsd.je+ oe_xsd.se) AS jese,oe_xsd.xsmemo || oe_xsd.djh AS xsmemo,oe_xsd.dddjh,oe_xsd.ddxh FROM oe_xsd,rc_cpxx WHERE oe_xsd.cpdm = rc_cpxx.cpdm AND (oe_xsd.djh = ?) ORDER BY oe_xsd.XH"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = strDjh
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_xsdnr") IsNot Nothing Then
                            Me.rcDataset.Tables("rc_xsdnr").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_xsdnr")
                        If rcDataset.Tables("rc_xsdnr").Rows.Count > 0 Then
                            If rcDataset.Tables("rc_xsdnr").Rows(0).Item("dddjh").GetType.ToString <> "System.DBNull" Then
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
                        SumSlJe() '�������ϼ�
                        IsAdding = True
                        IsEditing = True
                        blnReCalculate = False
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
        IsEditing = True
        SetControlEnableEvent()
    End Sub

#End Region

#Region "����DataGridView���¼�"

    Private Sub BtnIns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIns.Click, MnuiIns.Click
        If Me.rcDataGridView.ReadOnly = False Then
            If dtXsd.Rows.Count > 0 Then
                Dim row As DataRow = dtXsd.NewRow
                dtXsd.Rows.InsertAt(row, rcDataGridView.CurrentCell.RowIndex)
                dtXsd.AcceptChanges()
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
            If dtXsd.Rows.Count > 0 Then
                dtXsd.Rows(rcDataGridView.CurrentRow.Index).Delete()
                dtXsd.AcceptChanges()
                IsEditing = True
                SetControlEnableEvent()
            End If
        End If
        'If Me.rcDataGridView.ReadOnly = False Then
        '    If Me.rcBindingSource.Count > 0 Then
        '        'MsgBox(dtxsd.Rows.Count.ToString)
        '        'MsgBox(rcDataGridView.CurrentRow.Index.ToString)
        '        'Me.rcBindingSource.RemoveCurrent()
        '        'Me.rcDataGridView.Refresh()
        '        'rcDataGridView.Rows.Remove(rcDataGridView.CurrentRow)
        '        dtxsd.Rows.RemoveAt(rcDataGridView.CurrentRow.Index)
        '        dtxsd.AcceptChanges()
        '        IsEditing = True
        '        SetControlEnableEvent()
        '    End If
        'End If
    End Sub
#End Region

#Region "����excel"

    Private Sub BtnImpXls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiImpXls.Click
        '���ñ���
        Dim rcFrm As New FrmOeXsdImpXls
        With rcFrm
            .ParaStrPzlxdm = Me.CmbPzlxjc.SelectedValue
            .ParaStrKjqj = strKjqj
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

#End Region

#Region "��ӡ���á���ӡ����ӡԤ���¼�"

    Private Sub PageSetupEvent()
        Dim rcFrmPageSetup As New models.FrmPageSetup
        With rcFrmPageSetup
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = strRpsId
            .paraRpsName = "�ͻ�����׼��ʽ"
            .ShowDialog()
        End With
    End Sub

    Private Sub PrintEvent()
        If g_Demo = 1 Then
            MsgBox("�Բ��������������ܴ�ӡ��", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        PreparePrintData()
        Dim rcFrmPrint As New models.FrmPrint
        With rcFrmPrint
            .ParaRps = rcRps
            .ShowDialog()
        End With
    End Sub

    Private Sub PrintViewEvent()
        PreparePrintData()
        rcRps.Preview()
    End Sub

    Private Sub PreparePrintData()
        Dim slFormat As String = g_FormatSl
        Dim fzslFormat As String = g_FormatSl
        Dim slMaxFormat As String = " "
        Dim fzslMaxFormat As String = " "
        If rcRps Is Nothing Then
            rcRps = New RPS.Document
        End If
        Dim rft As String
        rft = Application.StartupPath + "\reports\" & strRpsId & ".rft"
        rcRps.LoadTemplate(rft)
        'ȡRPS��ӡ����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps WHERE rpsid = '" & strRpsId & "'"
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
        'If blnTd Then
        '    rcRps.PaperType = 1
        'End If
        Select Case True
            Case strRpsId = "SHDBZ"
                rcRps.Text(-1, 1) = g_PrnDwmc
                rcRps.Text(-1, 2) = "��  ��  ��"
                rcRps.Text(-1, 3) = "���ݺţ�" & Trim(Me.TxtDjh.Text) & "  %p/%t"
                rcRps.Text(-1, 4) = "�ͻ���" & "(" & Trim(Me.TxtKhdm.Text) & ")" & Trim(Me.LblKhmc.Text)
                rcRps.Text(-1, 5) = "���ڣ�" & Me.DtpXsrq.Value.Date.ToLongDateString
                Dim i As Integer
                Dim j As Integer
                Dim intPage As Integer
                dblTotSl = 0.0
                dblTotFzsl = 0
                dblTotJe = 0.0
                For intPage = 1 To System.Math.Ceiling(rcDataset.Tables("rc_xsdnr").Rows.Count / rcRps.LinesPerPage.ToString)
                    For i = (intPage - 1) * rcRps.LinesPerPage.ToString To System.Math.Min(intPage * rcRps.LinesPerPage.ToString - 1, rcDataset.Tables("rc_xsdnr").Rows.Count - 1)
                        If rcDataset.Tables("rc_xsdnr").Rows(i).RowState <> 8 Then
                            If Not rcDataset.Tables("rc_xsdnr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
                                slFormat = ReadJldwXsws(rcDataset.Tables("rc_xsdnr").Rows(i).Item("dw"))
                                If slFormat > slMaxFormat Then
                                    slMaxFormat = slFormat
                                End If
                            End If
                            If Not rcDataset.Tables("rc_xsdnr").Rows(i).Item("fzdw").GetType.ToString = "System.DBNull" Then
                                fzslFormat = ReadJldwXsws(rcDataset.Tables("rc_xsdnr").Rows(i).Item("fzdw"))
                                If fzslFormat > fzslMaxFormat Then
                                    fzslMaxFormat = fzslFormat
                                End If
                            End If
                            '�ͻ�����ʽ
                            If Not rcDataset.Tables("rc_xsdnr").Rows(i).Item("cpdm").GetType.ToString = "System.DBNull" Then
                                rcRps.Text(j + 1, 1) = Trim(rcDataset.Tables("rc_xsdnr").Rows(i).Item("cpdm"))
                            End If
                            If Not rcDataset.Tables("rc_xsdnr").Rows(i).Item("cpmc").GetType.ToString = "System.DBNull" Then
                                rcRps.Text(j + 1, 2) = Trim(rcDataset.Tables("rc_xsdnr").Rows(i).Item("cpmc"))
                            End If
                            If Not rcDataset.Tables("rc_xsdnr").Rows(i).Item("khddh").GetType.ToString = "System.DBNull" Then
                                rcRps.Text(j + 1, 3) = Trim(rcDataset.Tables("rc_xsdnr").Rows(i).Item("khddh"))
                            End If
                            If Not rcDataset.Tables("rc_xsdnr").Rows(i).Item("khlh").GetType.ToString = "System.DBNull" Then
                                rcRps.Text(j + 1, 4) = Trim(rcDataset.Tables("rc_xsdnr").Rows(i).Item("khlh"))
                            End If
                            If Not rcDataset.Tables("rc_xsdnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                                rcRps.Text(j + 1, 5) = Format(rcDataset.Tables("rc_xsdnr").Rows(i).Item("sl"), slFormat)
                                dblTotSl += rcDataset.Tables("rc_xsdnr").Rows(i).Item("sl")
                            End If
                            If Not rcDataset.Tables("rc_xsdnr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
                                rcRps.Text(j + 1, 6) = Trim(rcDataset.Tables("rc_xsdnr").Rows(i).Item("dw"))
                            End If
                            If Not rcDataset.Tables("rc_xsdnr").Rows(i).Item("fzsl").GetType.ToString = "System.DBNull" Then
                                rcRps.Text(j + 1, 7) = Format(rcDataset.Tables("rc_xsdnr").Rows(i).Item("fzsl"), fzslFormat)
                                dblTotFzsl += rcDataset.Tables("rc_xsdnr").Rows(i).Item("fzsl")
                            End If
                            If Not rcDataset.Tables("rc_xsdnr").Rows(i).Item("fzdw").GetType.ToString = "System.DBNull" Then
                                rcRps.Text(j + 1, 8) = Trim(rcDataset.Tables("rc_xsdnr").Rows(i).Item("fzdw"))
                            End If
                            If Not rcDataset.Tables("rc_xsdnr").Rows(i).Item("xsmemo").GetType.ToString = "System.DBNull" Then
                                rcRps.Text(j + 1, 9) = rcDataset.Tables("rc_xsdnr").Rows(i).Item("xsmemo")
                            End If
                            j += 1
                        End If
                    Next
                    If slFormat > slMaxFormat Then
                        slMaxFormat = slFormat
                    End If
                    If fzslFormat > fzslMaxFormat Then
                        fzslMaxFormat = fzslFormat
                    End If
                    rcRps.PerPageText(intPage, 9) = Format(dblTotSl, slMaxFormat)
                    rcRps.PerPageText(intPage, 11) = Format(dblTotFzsl, fzslMaxFormat)
                Next
                If Decimal.op_Modulus(rcDataset.Tables("rc_xsdnr").Rows.Count, rcRps.LinesPerPage.ToString) <> 0 Then
                    For i = Decimal.op_Modulus(rcDataset.Tables("rc_xsdnr").Rows.Count, rcRps.LinesPerPage.ToString) + 1 To rcRps.LinesPerPage.ToString
                        rcRps.Text(j + 1, 1) = ""
                        j += 1
                    Next
                End If
                rcRps.Text(-1, 14) = "�ֹܣ�" & g_User_DspName
            Case strRpsId = "SHD_DC"
                rcRps.Text(-1, 1) = g_PrnDwmc & "�ͻ�ƾ��"
                rcRps.Text(-1, 2) = "�ͻ���" & "(" & Trim(Me.TxtKhdm.Text) & ")" & Trim(Me.LblKhmc.Text)
                rcRps.Text(-1, 3) = "���ڣ�" & Me.DtpXsrq.Value.Date.ToLongDateString
                rcRps.Text(-1, 4) = "���ݺţ�" & Trim(Me.TxtDjh.Text) & "  %p/%t"
                Dim i As Integer
                Dim j As Integer
                Dim intPage As Integer
                dblTotSl = 0.0
                dblTotFzsl = 0
                dblTotJe = 0.0
                For intPage = 1 To System.Math.Ceiling(rcDataset.Tables("rc_xsdnr").Rows.Count / rcRps.LinesPerPage.ToString)
                    For i = (intPage - 1) * rcRps.LinesPerPage.ToString To System.Math.Min(intPage * rcRps.LinesPerPage.ToString - 1, rcDataset.Tables("rc_xsdnr").Rows.Count - 1)
                        If rcDataset.Tables("rc_xsdnr").Rows(i).RowState <> 8 Then
                            If Not rcDataset.Tables("rc_xsdnr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
                                slFormat = ReadJldwXsws(rcDataset.Tables("rc_xsdnr").Rows(i).Item("dw"))
                                If slFormat > slMaxFormat Then
                                    slMaxFormat = slFormat
                                End If
                            End If
                            If Not rcDataset.Tables("rc_xsdnr").Rows(i).Item("fzdw").GetType.ToString = "System.DBNull" Then
                                fzslFormat = ReadJldwXsws(rcDataset.Tables("rc_xsdnr").Rows(i).Item("fzdw"))
                                If fzslFormat > fzslMaxFormat Then
                                    fzslMaxFormat = fzslFormat
                                End If
                            End If
                            '�ͻ�����ʽ
                            If Not rcDataSet.Tables("rc_xsdnr").Rows(i).Item("khddh").GetType.ToString = "System.DBNull" Then
                                rcRps.Text(j + 1, 1) = Trim(rcDataSet.Tables("rc_xsdnr").Rows(i).Item("khddh"))
                            End If
                            If Not rcDataSet.Tables("rc_xsdnr").Rows(i).Item("khlh").GetType.ToString = "System.DBNull" Then
                                rcRps.Text(j + 1, 2) = Trim(rcDataSet.Tables("rc_xsdnr").Rows(i).Item("khlh"))
                            End If
                            If Not rcDataSet.Tables("rc_xsdnr").Rows(i).Item("cpmc").GetType.ToString = "System.DBNull" Then
                                rcRps.Text(j + 1, 3) = Trim(rcDataSet.Tables("rc_xsdnr").Rows(i).Item("cpmc"))
                            End If
                            If Not rcDataSet.Tables("rc_xsdnr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
                                rcRps.Text(j + 1, 4) = Trim(rcDataSet.Tables("rc_xsdnr").Rows(i).Item("dw"))
                            End If
                            If Not rcDataSet.Tables("rc_xsdnr").Rows(i).Item("js").GetType.ToString = "System.DBNull" Then
                                rcRps.Text(j + 1, 5) = Format(rcDataSet.Tables("rc_xsdnr").Rows(i).Item("js"), g_FormatInt0)
                            End If
                            If Not rcDataSet.Tables("rc_xsdnr").Rows(i).Item("lt").GetType.ToString = "System.DBNull" Then
                                rcRps.Text(j + 1, 6) = Format(rcDataSet.Tables("rc_xsdnr").Rows(i).Item("lt"), g_FormatSl0)
                            End If
                            If Not rcDataSet.Tables("rc_xsdnr").Rows(i).Item("ts").GetType.ToString = "System.DBNull" Then
                                rcRps.Text(j + 1, 7) = Format(rcDataSet.Tables("rc_xsdnr").Rows(i).Item("ts"), g_FormatInt0)
                            End If
                            If Not rcDataSet.Tables("rc_xsdnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                                rcRps.Text(j + 1, 8) = Format(rcDataSet.Tables("rc_xsdnr").Rows(i).Item("sl"), slFormat)
                                dblTotSl += rcDataSet.Tables("rc_xsdnr").Rows(i).Item("sl")
                            End If
                            If Not rcDataSet.Tables("rc_xsdnr").Rows(i).Item("xsmemo").GetType.ToString = "System.DBNull" Then
                                'rcRps.Text(j + 1, 10) = rcDataSet.Tables("rc_xsdnr").Rows(i).Item("xsmemo")
                            End If
                            j += 1
                        End If
                    Next
                    If slFormat > slMaxFormat Then
                        slMaxFormat = slFormat
                    End If
                    rcRps.PerPageText(intPage, 19) = Format(dblTotSl, slMaxFormat)
                Next
                If Decimal.op_Modulus(rcDataSet.Tables("rc_xsdnr").Rows.Count, rcRps.LinesPerPage.ToString) <> 0 Then
                    For i = Decimal.op_Modulus(rcDataSet.Tables("rc_xsdnr").Rows.Count, rcRps.LinesPerPage.ToString) + 1 To rcRps.LinesPerPage.ToString
                        rcRps.Text(j + 1, 1) = ""
                        j += 1
                    Next
                End If
                rcRps.Text(-1, 23) = "��Ʊ�ˣ�" & g_User_DspName
            Case strRpsId = "XSDBZ"
            Case strRpsId = "XSDPT"
            Case Else
                MsgBox("s")
        End Select
    End Sub

    Private Sub MnuiPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrint.Click, BtnPrint.Click
        Dim rcFrm As New FrmOeXsdDy
        With rcFrm
            .ShowDialog()
            strRpsId = IIf(.RadioButton1.Checked, "SHDBZ", strRpsId)
            strRpsId = IIf(.RadioButton2.Checked, "SHD_DC", strRpsId)
            strRpsId = IIf(.RadioButton3.Checked, "XSDBZ", strRpsId)
            strRpsId = IIf(.RadioButton4.Checked, "XSDPT", strRpsId)
        End With
        SaveEvent(True)
    End Sub

    Private Sub MnuiPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPageSetup.Click
        Dim rcFrm As New FrmOeXsdDy
        With rcFrm
            .ShowDialog()
            strRpsId = IIf(.RadioButton1.Checked, "SHDBZ", strRpsId)
            strRpsId = IIf(.RadioButton2.Checked, "SHD_DC", strRpsId)
            strRpsId = IIf(.RadioButton3.Checked, "XSDBZ", strRpsId)
            strRpsId = IIf(.RadioButton4.Checked, "XSDPT", strRpsId)
        End With
        PageSetupEvent()
    End Sub

    Private Sub BtnPrintView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrintView.Click, MnuiPrintView.Click
        Dim rcFrm As New FrmOeXsdDy
        With rcFrm
            .ShowDialog()
            strRpsId = IIf(.RadioButton1.Checked, "SHDBZ", strRpsId)
            strRpsId = IIf(.RadioButton2.Checked, "SHD_DC", strRpsId)
            strRpsId = IIf(.RadioButton3.Checked, "XSDBZ", strRpsId)
            strRpsId = IIf(.RadioButton4.Checked, "XSDPT", strRpsId)
        End With
        PrintViewEvent()
    End Sub

#End Region

#Region "�˳������¼�"

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        ExitEvent()
    End Sub

    Private Sub MnuiExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiExit.Click
        ExitEvent()
    End Sub

    Private Sub ExitEvent()
        Me.Close()
    End Sub

    'Private Sub FrmxsdSrz2_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
    '    If IsEditing Then
    '        MsgBox("�Ѿ��༭�����ݣ��뱣�����ݡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
    '        e.Cancel = True
    '    End If
    'End Sub

#End Region
End Class