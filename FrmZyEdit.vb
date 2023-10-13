Imports System.IO 
Imports System.Data.OleDb

Public Class FrmZyEdit

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
    'shCommPortΪ���ںŴ�0��ʼ��dwBaudrateΪ������ͨ��9600
    '���Ѱ�����ɹ������ؿ�Ƭϵ�к�dwSerialNo��������shManu
    'Phillips 0	Siemens 1
    Public Declare Function GetCSN Lib "READCARD.DLL" (ByVal shCommPort As Short, ByVal dwBaudrate As Integer, ByRef dwSerialNo As Integer, ByRef shManu As Short) As Short

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

    Private Sub FrmZyEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.TxtZydm.DataBindings.Add("Text", rcDataView, "zydm")
        Me.TxtZymc.DataBindings.Add("Text", rcDataView, "zymc")
        Me.TxtZysm.DataBindings.Add("Text", rcDataView, "zysm")
        Me.TxtBmdm.DataBindings.Add("Text", rcDataView, "bmdm")
        Me.LblBmmc.DataBindings.Add("Text", rcDataView, "bmmc")
        Me.TxtIcno.DataBindings.Add("Text", rcDataView, "icno")
        Me.TxtEmail.DataBindings.Add("Text", rcDataView, "email")
        BindingContext(rcDataView, "").Position = currentPos
        SetAll(True)
        If isAdding Then
            '�����ǰ�༭����
            BindingContext(rcDataView, "").EndCurrentEdit()
            '����һ��
            BindingContext(rcDataView, "").AddNew()
        Else
            Me.TxtZydm.Enabled = False
        End If
        'ȡ�˿�����
        Try
            If System.IO.File.Exists(Application.StartupPath & "\" & "COMport.xml") Then
                Dim xmlCom As New System.Xml.XmlDocument
                Dim intCom As Integer = 0
                xmlCom.Load(Application.StartupPath & "\" & "COMport.xml")
                intCom = xmlCom.SelectSingleNode("COMport").InnerText
                Me.MnuiCom1.Checked = IIf(intCom = 0, True, False)
                Me.MnuiCom2.Checked = Not Me.MnuiCom1.Checked
            End If
        Catch ex As Exception
            MsgBox("�����ö���������Ʒ�������������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End Try
    End Sub

#End Region

#Region "�ؼ��س����Ĵ���"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtZydm.KeyPress, TxtZysm.KeyPress, TxtZymc.KeyPress, TxtBmdm.KeyPress, TxtIcno.KeyPress, TxtEmail.KeyPress
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
            Me.TxtZydm.Enabled = False
            Me.TxtZysm.Enabled = False
            Me.TxtZymc.Enabled = False
            Me.TxtBmdm.Enabled = False
            Me.TxtIcno.Enabled = False
            Me.TxtEmail.Enabled = False
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
            Me.TxtZydm.Enabled = True
            Me.TxtZysm.Enabled = True
            Me.TxtZymc.Enabled = True
            Me.TxtBmdm.Enabled = True
            Me.TxtIcno.Enabled = True
            Me.TxtEmail.Enabled = True
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
            Me.TxtZydm.Focus()
        End If
    End Sub

#End Region

#Region "ְԱ�����¼�"

    Private Sub TxtZymc_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtZymc.Validating
        Me.TxtZysm.Text = Trim(Mid(GetChineseSpell(Me.TxtZymc.Text), 1, 12))
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
                If rcDataSet.Tables("rc_bmxx") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_bmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_bmxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_bmxx").Rows.Count > 0 Then
                TxtBmdm.Text = Trim(rcDataSet.Tables("rc_bmxx").Rows(0).Item("bmdm"))
                LblBmmc.Text = Trim(rcDataSet.Tables("rc_bmxx").Rows(0).Item("bmmc"))
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
                If rcDataSet.Tables("reccnt") IsNot Nothing Then
                    Me.rcDataSet.Tables("reccnt").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "reccnt")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("reccnt").Rows(0).Item("gs") > 0 Then
                MsgBox("����������ϸ���ű��롣", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

    Private Sub TimerReadCard_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerReadCard.Tick
        Dim shCommPort As Short = IIf(Me.MnuiCom1.Checked, 0, 1)
        Dim dwBaudrate As Integer = 9600
        Dim dwSerialNo As Integer = 0
        Dim shManu As Short = 0
        Dim mm As Short
        mm = GetCSN(shCommPort, dwBaudrate, dwSerialNo, shManu)
        If mm <> 1 Then
            Me.TxtIcno.Text = IIf(dwSerialNo < 0, 4294967296 + dwSerialNo, dwSerialNo)
            Me.TimerReadCard.Enabled = False
        End If
    End Sub

    Private Sub TxtIcno_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtIcno.LostFocus
        Me.TimerReadCard.Enabled = False
    End Sub
    
    Private Sub TxtIcno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtIcno.GotFocus
        Me.TimerReadCard.Enabled = True
    End Sub

    Private Sub TxtIcno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtIcno.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                If Me.TimerReadCard.Enabled = True Then
                    Me.TimerReadCard.Enabled = False
                Else
                    Me.TimerReadCard.Enabled = True
                End If
        End Select
    End Sub
    
    Private Sub MnuiCom1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCom1.Click
        If Not Me.MnuiCom1.Checked Then
            Me.MnuiCom1.Checked = True
            Me.MnuiCom2.Checked = False
            '��������
            If System.IO.File.Exists(Application.StartupPath & "\COMport.xml") Then
                System.IO.File.Delete(Application.StartupPath & "\COMport.xml")
            End If
            'дxml�ļ�
            Dim rcStreamWriter As StreamWriter
            rcStreamWriter = File.CreateText(Application.StartupPath & "\COMport.xml")
            rcStreamWriter.WriteLine("<?xml version=""1.0"" encoding=""utf-8"" ?> ")
            rcStreamWriter.WriteLine("<COMport>" & IIf(Me.MnuiCom1.Checked, 0, 1) & "</COMport>")
            rcStreamWriter.Close()
        End If
    End Sub

    Private Sub MnuiCom2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCom2.Click
        If Not MnuiCom2.Checked Then
            Me.MnuiCom1.Checked = False
            Me.MnuiCom2.Checked = True
            '��������
            If System.IO.File.Exists(Application.StartupPath & "\COMport.xml") Then
                System.IO.File.Delete(Application.StartupPath & "\COMport.xml")
            End If
            'дxml�ļ�
            Dim rcStreamWriter As StreamWriter
            rcStreamWriter = File.CreateText(Application.StartupPath & "\COMport.xml")
            rcStreamWriter.WriteLine("<?xml version=""1.0"" encoding=""utf-8"" ?> ")
            rcStreamWriter.WriteLine("<COMport>" & IIf(Me.MnuiCom2.Checked, 1, 0) & "</COMport>")
            rcStreamWriter.Close()
        End If
    End Sub

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
        Me.TxtZydm.Enabled = False
    End Sub

#End Region

#Region "����"

    Private Sub TsSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MnuiSave.Click
        SaveEvent()
    End Sub

    Private Sub SaveEvent()
        '��֤����
        If Not String.IsNullOrEmpty(Me.TxtBmdm.Text) Then
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "SELECT * FROM rc_bmxx WHERE (bmdm = ?)"
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
                Me.TxtBmdm.Text = rcDataset.Tables("rc_bmxx").Rows(0).Item("bmdm")
                Me.LblBmmc.Text = rcDataset.Tables("rc_bmxx").Rows(0).Item("bmmc")
            Else
                MsgBox("������Ϣ����ȷ��", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
                Return
            End If
        Else
            MsgBox("�����벿����Ϣ��", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            Return
        End If
        '����
        If isAdding Then
            If String.IsNullOrEmpty(Me.TxtZydm.Text) Then
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
                rcOleDbCommand.CommandText = "Insert Into rc_zyxx (zydm,zymc,zysm,bmdm,icno,email) VALUES (?,?,?,?,?,?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(TxtZydm.Text)
                rcOleDbCommand.Parameters.Add("@zymc", OleDbType.VarChar, 30).Value = Trim(TxtZymc.Text)
                rcOleDbCommand.Parameters.Add("@zysm", OleDbType.VarChar, 12).Value = Trim(TxtZysm.Text)
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(TxtBmdm.Text)
                rcOleDbCommand.Parameters.Add("@icno", OleDbType.VarChar, 12).Value = Trim(TxtIcno.Text)
                rcOleDbCommand.Parameters.Add("@email", OleDbType.VarChar, 50).Value = Trim(TxtEmail.Text)
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "SELECT rc_zyxx.zydm,rc_zyxx.zymc,rc_zyxx.zysm,rc_zyxx.bmdm,rc_bmxx.bmmc,rc_zyxx.icno,rc_zyxx.email FROM rc_zyxx Left Join rc_bmxx ON rc_zyxx.bmdm = rc_bmxx.bmdm ORDER BY zydm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_zyxx") IsNot Nothing Then
                    rcDataset.Tables("rc_zyxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_zyxx")
                BindingContext(rcDataView, "").Position = currentPos
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
            isAdding = False
        Else
            REM �޸��˺�
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "UPDATE rc_zyxx SET zymc = ? , zysm = ? ,bmdm = ? ,icno = ?,email = ?  WHERE  zydm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@zymc", OleDbType.VarChar, 30).Value = Trim(TxtZymc.Text)
                rcOleDbCommand.Parameters.Add("@zysm", OleDbType.VarChar, 12).Value = Trim(TxtZysm.Text)
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(TxtBmdm.Text)
                rcOleDbCommand.Parameters.Add("@icno", OleDbType.VarChar, 12).Value = Trim(TxtIcno.Text)
                rcOleDbCommand.Parameters.Add("@email", OleDbType.VarChar, 50).Value = Trim(TxtEmail.Text)
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(Me.TxtZydm.Text)
                rcOleDbCommand.ExecuteNonQuery()
                '�������
                rcOleDbCommand.CommandText = "SELECT rc_zyxx.zydm,rc_zyxx.zymc,rc_zyxx.zysm,rc_zyxx.bmdm,rc_bmxx.bmmc,rc_zyxx.icno,rc_zyxx.email FROM rc_zyxx Left Join rc_bmxx On rc_zyxx.bmdm = rc_bmxx.bmdm ORDER BY zydm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_zyxx") IsNot Nothing Then
                    rcDataset.Tables("rc_zyxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_zyxx")
                BindingContext(rcDataView, "").Position = currentPos
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
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT rc_zyxx.zydm,rc_zyxx.zymc,rc_zyxx.zysm,rc_zyxx.bmdm,rc_bmxx.bmmc,rc_zyxx.icno,rc_zyxx.email FROM rc_zyxx Left Join rc_bmxx On rc_zyxx.bmdm = rc_bmxx.bmdm ORDER BY zydm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_zyxx") IsNot Nothing Then
                rcDataset.Tables("rc_zyxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_zyxx")
            BindingContext(rcDataView, "").Position = currentPos
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