Imports System.Data.OleDb
Public Class FrmPzlxEdit

#Region "�������"

    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    Dim rcDataset As New DataSet
    '���ݸ��´���
    Dim rcOleDbTrans As OleDbTransaction
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '������ͼ
    Dim rcDataView As DataView
    '������־
    Dim isAdding As Boolean = False
    '��ǰ��¼��
    Dim currentPos As Integer

#End Region

#Region "��ʼ��"

    Overloads Property ParaDataSet() As DataSet
        Get
            ParaDataSet = rcDataset
        End Get
        Set(ByVal Value As DataSet)
            rcDataset = Value
        End Set
    End Property

    Overloads Property ParaDataView() As DataView
        Get
            ParaDataView = rcDataView
        End Get
        Set(ByVal Value As DataView)
            rcDataView = Value
        End Set
    End Property

    Overloads Property ParaAdding() As Boolean
        Get
            ParaAdding = isAdding
        End Get
        Set(ByVal Value As Boolean)
            isAdding = Value
        End Set
    End Property

    Overloads Property ParaCurrentPos() As Integer
        Get
            ParaCurrentPos = currentPos
        End Get
        Set(ByVal Value As Integer)
            currentPos = Value
        End Set
    End Property

    Private Sub FrmPzlxEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.TxtPzlxdm.DataBindings.Add("Text", rcDataView, "pzlxdm")
        Me.TxtPzlxjc.DataBindings.Add("Text", rcDataView, "pzlxjc")
        Me.TxtPzlxmc.DataBindings.Add("Text", rcDataView, "pzlxmc")
        Me.CmbLxgs.DataBindings.Add("Text", rcDataView, "lxgs")
        Me.ChbFushu.DataBindings.Add("Checked", rcDataView, "bfushu")
        BindingContext(rcDataView, "").Position = currentPos
        SetAll(True)
        If isAdding Then
            '�����ǰ�༭����
            BindingContext(rcDataView, "").EndCurrentEdit()
            '����һ��
            BindingContext(rcDataView, "").AddNew()
        Else
            Me.TxtPzlxdm.Enabled = False
        End If
    End Sub

#End Region

#Region "�ؼ��س����Ĵ���"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPzlxdm.KeyPress, TxtPzlxjc.KeyPress, TxtPzlxmc.KeyPress, CmbLxgs.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "���ÿؼ�"

    Private Sub SetAll(ByVal medit As Boolean)
        If Not medit Then
            Me.TxtPzlxdm.Enabled = False
            Me.TxtPzlxjc.Enabled = False
            Me.TxtPzlxmc.Enabled = False
            Me.CmbLxgs.Enabled = False
            Me.ChbFushu.Enabled = False
            Me.BtnTop.Enabled = True
            Me.BtnPrevious.Enabled = True
            Me.BtnNext.Enabled = True
            Me.BtnBottom.Enabled = True
            Me.BtnNew.Enabled = True
            Me.BtnEdit.Enabled = True
            Me.BtnSave.Enabled = False
            Me.BtnCancel.Enabled = False
            Me.BtnExit.Enabled = True
            Me.MnuiNew.Enabled = True
            Me.MnuiEdit.Enabled = True
            Me.MnuiSave.Enabled = False
            Me.MnuiCancel.Enabled = False
            Me.MnuiExit.Enabled = True
        Else
            Me.TxtPzlxdm.Enabled = True
            Me.TxtPzlxjc.Enabled = True
            Me.TxtPzlxmc.Enabled = True
            Me.CmbLxgs.Enabled = True
            Me.ChbFushu.Enabled = True
            Me.BtnTop.Enabled = False
            Me.BtnPrevious.Enabled = False
            Me.BtnNext.Enabled = False
            Me.BtnBottom.Enabled = False
            Me.BtnNew.Enabled = False
            Me.BtnEdit.Enabled = False
            Me.BtnSave.Enabled = True
            Me.BtnCancel.Enabled = True
            Me.BtnExit.Enabled = False
            Me.MnuiNew.Enabled = False
            Me.MnuiEdit.Enabled = False
            Me.MnuiSave.Enabled = True
            Me.MnuiCancel.Enabled = True
            Me.MnuiExit.Enabled = False
            Me.TxtPzlxdm.Focus()
        End If
    End Sub

#End Region

#Region "������ĩ��¼"

    Private Sub BtnTop_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTop.Click
        If BindingContext(rcDataView, "").Count > 0 Then
            BindingContext(rcDataView, "").Position = 0
        End If
    End Sub

    Private Sub BtnPrevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPrevious.Click
        If BindingContext(rcDataView, "").Count > 0 Then
            If BindingContext(rcDataView, "").Position <> 0 Then
                BindingContext(rcDataView, "").Position -= 1
            End If
        End If
    End Sub

    Private Sub BtnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNext.Click
        If BindingContext(rcDataView, "").Count > 0 Then
            If BindingContext(rcDataView, "").Position <> BindingContext(rcDataView, "").Count Then
                BindingContext(rcDataView, "").Position += 1
            End If
        End If
    End Sub

    Private Sub BtnBottom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBottom.Click
        If BindingContext(rcDataView, "").Count > 0 Then
            BindingContext(rcDataView, "").Position = BindingContext(rcDataView, "").Count - 1
        End If
    End Sub

#End Region

    Private Sub TxtPzlxdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtPzlxdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtPzlxdm.Text) Then
            If Me.TxtPzlxdm.Text.Trim.Length <> 4 Then
                MsgBox("�������ͱ���ĳ���Ҫ����4λ��", MsgBoxStyle.OkOnly, "��ʾ��Ϣ")
                e.Cancel = True
            End If
        End If
    End Sub

#Region "����"

    Private Sub BtnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNew.Click, MnuiNew.Click
        NewEvent()
    End Sub

    Private Sub NewEvent()
        '����
        If Not isAdding Then
            isAdding = True
            Try
                currentPos = BindingContext(rcDataView, "").Position
                '�����ǰ�༭����
                BindingContext(rcDataView, "").EndCurrentEdit()
                BindingContext(rcDataView, "").AddNew()
            Catch eEndEdit As System.Exception
                System.Windows.Forms.MessageBox.Show(eEndEdit.Message)
            End Try
            SetAll(True)
        End If
    End Sub

#End Region

#Region "�޸�"

    Private Sub BtnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnEdit.Click, MnuiEdit.Click
        EditEvent()
    End Sub

    Private Sub EditEvent()
        '�޸�
        If isAdding Then
            isAdding = False
        End If
        Try
            currentPos = BindingContext(rcDataView, "").Position
            '�����ǰ�༭����
            BindingContext(rcDataView, "").EndCurrentEdit()
        Catch eEndEdit As System.Exception
            System.Windows.Forms.MessageBox.Show(eEndEdit.Message)
        End Try
        SetAll(True)
        Me.TxtPzlxdm.Enabled = False
    End Sub

#End Region

#Region "����"

    Private Sub TsSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MnuiSave.Click
        SaveEvent()
    End Sub

    Private Sub SaveEvent()
        Dim i As Integer 'ѭ��������
        '����
        If isAdding Then
            If Trim(TxtPzlxdm.Text).Length <> 4 Then
                MsgBox("�������ͱ��볤��Ҫ����4λ������ȷ�����޸ġ�")
                Return
            End If
            'REM ���ӱ���
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "Insert Into rc_lx (kjnd,pzlxdm,pzlxjc,pzlxmc,lxgs,bfushu,pzno01,pzno02,pzno03,pzno04,pzno05,pzno06,pzno07,pzno08,pzno09,pzno10,pzno11,pzno12,pzno13) VALUES ('" & g_Kjrq.Year & "',?,?,?,?,?,0,0,0,0,0,0,0,0,0,0,0,0,0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@pzlxdm", OleDbType.VarChar, 4).Value = Trim(Me.TxtPzlxdm.Text)
                rcOleDbCommand.Parameters.Add("@pzlxjc", OleDbType.VarChar, 8).Value = Trim(TxtPzlxjc.Text)
                rcOleDbCommand.Parameters.Add("@pzlxmc", OleDbType.VarChar, 18).Value = Trim(TxtPzlxmc.Text)
                rcOleDbCommand.Parameters.Add("@lxgs", OleDbType.VarChar, 12).Value = Trim(Me.CmbLxgs.Text)
                rcOleDbCommand.Parameters.Add("@bfushu", OleDbType.Numeric, 1).Value = IIf(Me.ChbFushu.Checked, 1, 0)
                rcOleDbCommand.ExecuteNonQuery()
                '�������
                For i = 1 To 12
                    rcOleDbCommand.CommandText = "CREATE SEQUENCE " & Trim(TxtPzlxdm.Text) & Mid(g_Kjqj, 1, 4) & i.ToString.PadLeft(2, "0") & " INCREMENT BY 1 START WITH 1 MAXVALUE 99999 MINVALUE 1 NOCYCLE NOCACHE NOORDER"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Next
                rcOleDbCommand.CommandText = "SELECT * FROM rc_lx WHERE (lxgs = '���ϲɹ�����' OR  lxgs = '��������' OR lxgs = '�����ջ���' OR lxgs = '������ⵥ' OR lxgs = '�����������뵥' OR lxgs = '���ϳ��ⵥ' OR lxgs = '���ϵ�����' OR lxgs = '��Ʒ����' OR lxgs = '��Ʒ���۵�' OR lxgs = '��Ʒ���۶���' OR lxgs = '��Ʒ��������' or lxgs = '��Ʒ��ⵥ'or lxgs = '������ⵥ'or lxgs = '������ⵥ' OR lxgs = '����֪ͨ��' OR lxgs = '��Ʒ�ͻ���' OR lxgs = '��Ʒ���۵�' Or lxgs = '����Ӧ�յ�' OR lxgs = '����Ӧ����' OR lxgs = '�տ'  OR lxgs = '�������뵥' OR lxgs = '���' OR lxgs = '����ƾ֤') and kjnd = '" & g_Kjrq.Year & "' order by pzlxdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_lx") IsNot Nothing Then
                    rcDataset.Tables("rc_lx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_lx")
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("�������1��" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Catch ey As OleDbException
                    MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                End Try
            Finally
                rcOleDbConn.Close()
            End Try
            BindingContext(rcDataView, "").Position = currentPos
            isAdding = False
        Else
            REM �޸��˺�
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "UPDATE rc_lx SET pzlxjc = ?, pzlxmc = ?,bfushu = ?,lxgs = ? WHERE kjnd = ? AND pzlxdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@pzlxjc", OleDbType.VarChar, 8).Value = Trim(TxtPzlxjc.Text)
                rcOleDbCommand.Parameters.Add("@pzlxmc", OleDbType.VarChar, 18).Value = Trim(TxtPzlxmc.Text)
                rcOleDbCommand.Parameters.Add("@bfushu", OleDbType.Numeric, 1).Value = IIf(Me.ChbFushu.Checked, 1, 0)
                rcOleDbCommand.Parameters.AddWithValue("@lxgs", Trim(Me.CmbLxgs.Text))
                rcOleDbCommand.Parameters.AddWithValue("@kjnd", g_Kjrq.Year)
                rcOleDbCommand.Parameters.AddWithValue("@pzlxdm", Trim(Me.TxtPzlxdm.Text))
                rcOleDbCommand.ExecuteNonQuery()
                '�������,�����ڣ����½�
                For i = 1 To 12
                    rcOleDbCommand.CommandText = "SELECT * FROM user_sequences WHERE sequence_name = '" & Trim(TxtPzlxdm.Text) & Mid(g_Kjqj, 1, 4) & i.ToString.PadLeft(2, "0") & "'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("user_sequences") IsNot Nothing Then
                        rcDataset.Tables("user_sequences").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "user_sequences")
                    If rcDataset.Tables("user_sequences").Rows.Count <= 0 Then
                        rcOleDbCommand.CommandText = "CREATE SEQUENCE " & Trim(TxtPzlxdm.Text) & Mid(g_Kjqj, 1, 4) & i.ToString.PadLeft(2, "0") & " INCREMENT BY 1 START WITH 1 MAXVALUE 99999 MINVALUE 1 NOCYCLE NOCACHE NOORDER"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                Next
                '�������
                rcOleDbCommand.CommandText = "SELECT * FROM rc_lx WHERE (lxgs = '���ϲɹ�����' OR  lxgs = '��������' OR lxgs = '�����ջ���' OR lxgs = '������ⵥ' OR lxgs = '�����������뵥' OR lxgs = '���ϳ��ⵥ' OR lxgs = '���ϵ�����' OR lxgs = '��Ʒ����' OR lxgs = '��Ʒ���۵�' OR lxgs = '��Ʒ���۶���' OR lxgs = '��Ʒ��������' or lxgs = '��Ʒ��ⵥ'or lxgs = '������ⵥ'or lxgs = '������ⵥ' OR lxgs = '����֪ͨ��' OR lxgs = '��Ʒ�ͻ���' OR lxgs = '��Ʒ���۵�' Or lxgs = '����Ӧ�յ�' OR lxgs = '����Ӧ����' OR lxgs = '�տ'  OR lxgs = '�������뵥' OR lxgs = '���' OR lxgs = '����ƾ֤') and kjnd = '" & g_Kjrq.Year & "' order by pzlxdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_lx") IsNot Nothing Then
                    rcDataset.Tables("rc_lx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_lx")
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
            BindingContext(rcDataView, "").Position = currentPos
        End If
        SetAll(False)
    End Sub

#End Region

#Region "ȡ��"

    Private Sub TsCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click, MnuiCancel.Click
        CancelEvent()
    End Sub

    Private Sub CancelEvent()
        'ȡ��
        rcOleDbCommand.CommandText = "SELECT * FROM rc_lx WHERE (lxgs = '���ϲɹ�����' OR  lxgs = '��������' OR lxgs = '�����ջ���' OR lxgs = '������ⵥ' OR lxgs = '�����������뵥' OR lxgs = '���ϳ��ⵥ' OR lxgs = '���ϵ�����' OR lxgs = '��Ʒ����' OR lxgs = '��Ʒ���۵�' OR lxgs = '��Ʒ���۶���' OR lxgs = '��Ʒ��������' or lxgs = '��Ʒ��ⵥ'or lxgs = '������ⵥ'or lxgs = '������ⵥ' OR lxgs = '����֪ͨ��' OR lxgs = '��Ʒ�ͻ���' OR lxgs = '��Ʒ���۵�' Or lxgs = '����Ӧ�յ�' OR lxgs = '����Ӧ����' OR lxgs = '�տ'  OR lxgs = '�������뵥' OR lxgs = '���' OR lxgs = '����ƾ֤') and kjnd = '" & g_Kjrq.Year & "' order by pzlxdm"
        rcOleDbCommand.Parameters.Clear()
        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
        If rcDataset.Tables("rc_lx") IsNot Nothing Then
            rcDataset.Tables("rc_lx").Clear()
        End If
        rcOleDbDataAdpt.Fill(rcDataset, "rc_lx")
        BindingContext(rcDataView, "").Position = currentPos
        isAdding = False
        SetAll(False)
    End Sub

#End Region

#Region "�ر�"

    Private Sub BtnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExit.Click, MnuiExit.Click
        Me.Close()
    End Sub

#End Region

#Region "����"

    Private Sub MnuiAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuiAbout.Click
        Dim rcFrm As New FrmAbout
        With rcFrm
            .ShowDialog()
        End With
    End Sub

#End Region

End Class