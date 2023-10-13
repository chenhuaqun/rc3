Imports System.Data.OleDb

Public Class FrmQtysSrz

#Region "�������"

    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '��ʾҪ������Դִ�е� SQL ����
    Dim rcOleDbTrans As OleDbTransaction
    '��������
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '���ӵ��ݵı���
    Dim IsAdding As Boolean = False
    '�޸ĵ��ݵı���
    Dim IsEditing As Boolean = False
    '���ݰ�
    ReadOnly rcBmb As BindingManagerBase
    '������ӡ�ĵ�
    ReadOnly rcRps As RPS.Document
    '����ڼ�
    Dim strKjqj As String = g_Kjqj
    '��
    Dim strYear As String = ""
    '��
    Dim strMonth As String = ""

#End Region

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

    Private Sub FrmQtysSrz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ȡ������������
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE lxgs = '����Ӧ�յ�' and kjnd = '" & strYear & "' ORDER BY pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_lx") IsNot Nothing Then
                Me.rcDataset.Tables("rc_lx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_lx")
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("rc_lx").Rows.Count = 0 Then
            MsgBox("�붨�嵥�����͡�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        '��ƾ֤���ͼ��
        BindDropDownList(CmbPzlxjc, rcDataSet.Tables("rc_lx"), "pzlxdm", "pzlxjc")
        strKjqj = strYear & strMonth.PadLeft(2, "0")
        If getInvKjqj(g_Kjrq) = strKjqj Then
            DtpFprq.Value = g_Kjrq
        Else
            DtpFprq.Value = getInvEnd(strYear, strMonth)
        End If

        NewEvent()
    End Sub

#End Region

#Region "�ؼ��س����Ĵ���"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDjh.KeyPress, DtpFprq.KeyPress, TxtKhdm.KeyPress, TxtZydm.KeyPress, TxtJe.KeyPress, TxtFpmemo.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "�������͵��¼�"

    Private Sub CmbPzlxjc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbPzlxjc.KeyDown
        Select Case e.KeyCode
            Case Keys.Return, Keys.Right
                TxtDjh.Focus()
            Case Keys.Left
                BtnExit.Focus()
        End Select
    End Sub

    Private Sub CmbPzlxjc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbPzlxjc.Validated
        ShowNewDjh()
    End Sub

#End Region

#Region "���ݺŵ��¼�"

    Private Sub TxtDjh_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtDjh.Validating
        If IsEditing Then
            Return
        End If
        '��鵥�ݺ��Ƿ����
        If rcDataSet.Tables("rc_pzno") Is Nothing Then
            Return
        End If
        '�ж����ӻ����޸�
        rcOleDbConn.Open()
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            If rcDataSet.Tables("rc_pzno").Rows.Count > 0 Then
                If rcDataSet.Tables("rc_pzno").Rows(0).Item("pzno") >= Mid(Trim(Me.TxtDjh.Text), 11, 5) Then
                    '�޸ĵ���
                    rcOleDbCommand.CommandText = "SELECT oe_fp.djh,oe_fp.fprq,oe_fp.khdm,oe_fp.khmc,oe_fp.zydm,oe_fp.zymc,oe_fp.je,oe_fp.skje,oe_fp.fpmemo,oe_fp.srr,oe_fp.shr,oe_fp.jzr FROM oe_fp WHERE (djh = ? )"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = TxtDjh.Text
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataSet.Tables("rc_fp") IsNot Nothing Then
                        Me.rcDataSet.Tables("rc_fp").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataSet, "rc_fp")
                    If rcDataSet.Tables("rc_fp").Rows.Count > 0 Then
                        If rcDataSet.Tables("rc_fp").Rows(0).Item("skje") <> 0 Then
                            MsgBox("�õ����Ѿ��տ�����޸ġ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                            TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataSet.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                            IsAdding = True
                        Else
                            If rcDataSet.Tables("rc_fp").Rows(0).Item("jzr").GetType.ToString <> "System.DBNull" Then
                                MsgBox("�õ����Ѿ����ˣ������޸ġ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                                TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataSet.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                                IsAdding = True
                            Else
                                If rcDataSet.Tables("rc_fp").Rows(0).Item("shr").GetType.ToString <> "System.DBNull" Then
                                    MsgBox("�õ����Ѿ���ˣ������޸ġ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                                    TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataSet.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                                    IsAdding = True
                                Else
                                    Me.DtpFprq.Value = rcDataSet.Tables("rc_fp").Rows(0).Item("fprq")
                                    Me.TxtKhdm.Text = Trim(rcDataSet.Tables("rc_fp").Rows(0).Item("khdm"))
                                    Me.LblKhmc.Text = rcDataSet.Tables("rc_fp").Rows(0).Item("khmc")
                                    Me.TxtZydm.Text = Trim(rcDataSet.Tables("rc_fp").Rows(0).Item("zydm"))
                                    Me.LblZymc.Text = rcDataSet.Tables("rc_fp").Rows(0).Item("zymc")
                                    Me.TxtJe.Text = rcDataSet.Tables("rc_fp").Rows(0).Item("je")
                                    If rcDataSet.Tables("rc_fp").Rows(0).Item("fpmemo").GetType.ToString <> "System.DBNull" Then
                                        TxtFpmemo.Text = rcDataSet.Tables("rc_fp").Rows(0).Item("fpmemo")
                                    Else
                                        Me.TxtFpmemo.Text = ""
                                    End If
                                    IsAdding = False
                                End If
                            End If
                        End If
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
        'SetControlEnableEvent()
    End Sub

#End Region

#Region "�տ����ڵ��¼�"

    Private Sub DtpFprq_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DtpFprq.Validating
        Dim dateBegin As DateTime
        Dim dateEnd As DateTime
        dateBegin = getInvBegin(strYear, strMonth)
        dateEnd = getInvEnd(strYear, strMonth)
        If DtpFprq.Value > dateEnd Or DtpFprq.Value < dateBegin Then
            MsgBox("����������ڲ��ڵ�ǰ����ڼ��У��������롣", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            Me.DtpFprq.Focus()
        End If
    End Sub

#End Region

#Region "�ͻ�������¼�"

    Private Sub TxtKhdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtKhdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
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
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKhdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_khxx") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_khxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_khxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_khxx").Rows.Count > 0 Then
                TxtKhdm.Text = Trim(rcDataSet.Tables("rc_khxx").Rows(0).Item("khdm"))
                LblKhmc.Text = rcDataSet.Tables("rc_khxx").Rows(0).Item("khmc")
                If String.IsNullOrEmpty(Me.TxtZydm.Text) Then
                    If rcDataSet.Tables("rc_khxx").Rows(0).Item("zydm").GetType.ToString <> "System.DBNull" Then
                        Me.TxtZydm.Text = rcDataSet.Tables("rc_khxx").Rows(0).Item("zydm")
                    End If
                    If rcDataSet.Tables("rc_khxx").Rows(0).Item("zymc").GetType.ToString <> "System.DBNull" Then
                        Me.LblZymc.Text = rcDataSet.Tables("rc_khxx").Rows(0).Item("zymc")
                    End If
                End If
            Else
                e.Cancel = True
                Return
            End If
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
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "SELECT rc_zyxx.zydm,rc_zyxx.zymc FROM rc_zyxx WHERE (zydm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(Me.TxtZydm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_zyxx") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_zyxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_zyxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_zyxx").Rows.Count > 0 Then
                Me.TxtZydm.Text = Trim(rcDataSet.Tables("rc_zyxx").Rows(0).Item("zydm"))
                Me.LblZymc.Text = Trim(rcDataSet.Tables("rc_zyxx").Rows(0).Item("zymc"))
            Else
                MsgBox("ְԱ���벻���ڣ��������롣", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "�½����ݵ��¼�"

    Private Sub MnuiNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiNew.Click
        NewEvent()
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        NewEvent()
    End Sub

    Private Sub NewEvent()
        '�������
        Me.TxtKhdm.Text = ""
        Me.LblKhmc.Text = ""
        Me.TxtZydm.Text = ""
        Me.LblZymc.Text = ""
        Me.TxtJe.Text = 0.0
        Me.TxtFpmemo.Text = ""
        IsAdding = True
        IsEditing = False
        '��ʾ�µ��ݺ�
        ShowNewDjh()
    End Sub

    Private Sub ShowNewDjh()
        If Not IsEditing Then
            'ȡ������������
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "SELECT pzno" & strMonth & " as pzno FROM rc_lx WHERE pzlxdm = ? AND  lxgs = '����Ӧ�յ�' AND kjnd = '" & strYear & "'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.AddWithValue("@pzlxdm", Trim(Me.CmbPzlxjc.SelectedValue))
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_pzno") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_pzno").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_pzno")
                rcOleDbTrans.Commit()
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_pzno").Rows.Count = 0 Then
                MsgBox("�붨�嵥�����͡�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            End If
            TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataSet.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
        End If
    End Sub

#End Region

#Region "���浥�ݵ��¼�"

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MnuiSave.Click
        SaveEvent(False)
    End Sub

    Private Sub SaveEvent(ByVal blnPrint As Boolean)
        Dim i As Integer
        '(һ)���ݺϷ��Լ��
        '(1)�Ƿ�����Ҫ�洢������
        If Me.TxtJe.Text = 0 Then
            MsgBox("������Ӧ�ս�", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            Return
        End If
        '(2)�ͻ����
        If Trim(Me.TxtKhdm.Text).Length = 0 Then
            MsgBox("������ͻ����롣", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            Return
        End If
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.StoredProcedure
        Try
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Trim(Me.TxtKhdm.Text)
            rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_khxx"
            rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "khdm"
            rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
            rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
            rcOleDbCommand.ExecuteNonQuery()
            If rcOleDbCommand.Parameters.Item("@paraIntRecordCount").Value <> 1 Then
                MsgBox(Trim(Me.TxtKhdm.Text) & "�ͻ����벻��ȷ�����顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                Me.TxtKhdm.Text = ""
                Me.LblKhmc.Text = ""
                Me.TxtKhdm.Focus()
                Return
            End If
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '(3)���ݺų��ȼ��
        If Trim(Me.TxtDjh.Text).Length <> 15 Then
            MsgBox("���ݺų��Ȳ���ȷ�����顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
            Return
        End If
        '(��)�洢skd
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP3_SAVE_OE_FP"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = IIf(IsAdding, 1, 0)
            rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = Trim(Me.TxtDjh.Text)
            rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
            rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = i + 1
            rcOleDbCommand.Parameters.Add("@paraDateFprq", OleDbType.Date, 8).Value = Me.DtpFprq.Value
            rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
            rcOleDbCommand.Parameters.Add("@paraStrZydm", OleDbType.VarChar, 12).Value = Me.TxtZydm.Text
            rcOleDbCommand.Parameters.Add("@paraStrZymc", OleDbType.VarChar, 30).Value = Me.LblZymc.Text
            rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = Me.TxtKhdm.Text
            rcOleDbCommand.Parameters.Add("@paraStrKhmc", OleDbType.VarChar, 50).Value = Me.LblKhmc.Text
            rcOleDbCommand.Parameters.Add("@paraStrYspz", OleDbType.VarChar, 30).Value = ""
            rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = ""
            rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 200).Value = ""
            rcOleDbCommand.Parameters.Add("@paraStrSgddh", OleDbType.VarChar, 30).Value = ""
            rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = 0.0
            rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = ""
            rcOleDbCommand.Parameters.Add("@paraDblMjsl", OleDbType.Numeric, 18).Value = 0.0
            rcOleDbCommand.Parameters.Add("@paraDblFzsl", OleDbType.Numeric, 18).Value = 0.0
            rcOleDbCommand.Parameters.Add("@paraStrFzdw", OleDbType.VarChar, 8).Value = ""
            rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = 0.0
            rcOleDbCommand.Parameters.Add("@paraDblHsdj", OleDbType.Numeric, 18).Value = 0.0
            rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = Me.TxtJe.Text
            rcOleDbCommand.Parameters.Add("@paraDblShlv", OleDbType.Numeric, 6).Value = 0.0
            rcOleDbCommand.Parameters.Add("@paraDblSe", OleDbType.Numeric, 14).Value = 0.0
            rcOleDbCommand.Parameters.Add("@paraStrFpmemo", OleDbType.VarChar, 50).Value = Me.TxtFpmemo.Text
            rcOleDbCommand.Parameters.Add("@paraStrDdDjh", OleDbType.VarChar, 15).Value = ""
            rcOleDbCommand.Parameters.Add("@paraIntDdXh", OleDbType.Integer, 4).Value = 0
            rcOleDbCommand.Parameters.Add("@paraStrXsdDjh", OleDbType.VarChar, 15).Value = ""
            rcOleDbCommand.Parameters.Add("@paraIntXsdXh", OleDbType.Integer, 4).Value = 0
            rcOleDbCommand.Parameters.Add("@paraDblXsdDj", OleDbType.Numeric, 18).Value = 0.0
            rcOleDbCommand.Parameters.Add("@paraDblXsdHsdj", OleDbType.Numeric, 18).Value = 0.0
            rcOleDbCommand.Parameters.Add("@paraDblXsdJe", OleDbType.Numeric, 14).Value = 0.0
            rcOleDbCommand.Parameters.Add("@paraDblXsdShlv", OleDbType.Numeric, 6).Value = 0.0
            rcOleDbCommand.Parameters.Add("@paraDblXsdSe", OleDbType.Numeric, 14).Value = 0.0
            rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
            rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
            rcOleDbCommand.ExecuteNonQuery()
            If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                    MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                    Return
                End If
            End If
            rcOleDbTrans.Commit()
        Catch ex As Exception
            MsgBox("ִ�д洢���̷����˴���" & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If blnPrint Then
            'Print()
        End If
        '�µ��ݺ�
        NewEvent()
        '�ؼ�����
        'SetControlEnableEvent()
        '���ý���
        Me.TxtDjh.Focus()
    End Sub

#End Region

#Region "�˳����¼�"

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

#End Region

End Class