Imports System.Data.OleDb

Public Class FrmCsEdit

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

    Private Sub FrmCsEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.TxtLbdm.DataBindings.Add("Text", rcDataView, "lbdm")
        Me.LblLbmc.DataBindings.Add("Text", rcDataView, "lbmc")
        Me.TxtCsdm.DataBindings.Add("Text", rcDataView, "csdm")
        Me.TxtCsmc.DataBindings.Add("Text", rcDataView, "csmc")
        Me.TxtKhsm.DataBindings.Add("Text", rcDataView, "cssm")
        Me.TxtAddress.DataBindings.Add("Text", rcDataView, "address")
        Me.TxtWaddress.DataBindings.Add("Text", rcDataView, "waddress")
        Me.TxtKhyh.DataBindings.Add("Text", rcDataView, "khyh")
        Me.TxtYhzh.DataBindings.Add("Text", rcDataView, "yhzh")
        Me.TxtSwdjh.DataBindings.Add("Text", rcDataView, "swdjh")
        Me.TxtFddbr.DataBindings.Add("Text", rcDataView, "fddbr")
        Me.TxtGsdjh.DataBindings.Add("Text", rcDataView, "gsdjh")
        Me.TxtZczb.DataBindings.Add("Text", rcDataView, "zczb")
        Me.TxtJyfw.DataBindings.Add("Text", rcDataView, "jyfw")
        Me.TxtLxr.DataBindings.Add("Text", rcDataView, "lxr")
        Me.TxtMobile.DataBindings.Add("Text", rcDataView, "mobile")
        Me.TxtTel.DataBindings.Add("Text", rcDataView, "tel")
        Me.TxtFax.DataBindings.Add("Text", rcDataView, "fax")
        Me.TxtEmail.DataBindings.Add("Text", rcDataView, "email")
        Me.TxtZydm.DataBindings.Add("Text", rcDataView, "zydm")
        Me.LblZymc.DataBindings.Add("Text", rcDataView, "zymc")
        Me.CmbFktj.DataBindings.Add("Text", rcDataView, "fktj")
        Me.NudFkts.DataBindings.Add("Value", rcDataView, "fkts")
        BindingContext(rcDataView, "").Position = currentPos
        SetAll(True)
        If isAdding Then
            '�����ǰ�༭����
            BindingContext(rcDataView, "").EndCurrentEdit()
            '����һ��
            BindingContext(rcDataView, "").AddNew()
        Else
            Me.TxtCsdm.Enabled = False
        End If
    End Sub

#End Region

#Region "�ؼ��س����Ĵ���"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLbdm.KeyPress, TxtCsdm.KeyPress, TxtCsmc.KeyPress, TxtKhsm.KeyPress, TxtAddress.KeyPress, TxtPostCode.KeyPress, TxtWaddress.KeyPress, TxtKhyh.KeyPress, TxtYhzh.KeyPress, TxtSwdjh.KeyPress, TxtFddbr.KeyPress, TxtGsdjh.KeyPress, TxtZczb.KeyPress, TxtJyfw.KeyPress, TxtLxr.KeyPress, TxtMobile.KeyPress, TxtTel.KeyPress, TxtFax.KeyPress, TxtEmail.KeyPress, TxtZydm.KeyPress, CmbFktj.KeyPress, NudFkts.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                'ָʾ KeyPress �¼��Ѵ�����ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "���ÿؼ�"

    Private Sub SetAll(ByVal medit As Boolean)
        If Not medit Then
            Me.TxtLbdm.Enabled = False
            Me.TxtCsdm.Enabled = False
            Me.TxtCsmc.Enabled = False
            Me.TxtKhsm.Enabled = False
            Me.TxtAddress.Enabled = False
            Me.TxtPostCode.Enabled = False
            Me.TxtWaddress.Enabled = False
            Me.TxtKhyh.Enabled = False
            Me.TxtYhzh.Enabled = False
            Me.TxtSwdjh.Enabled = False
            Me.TxtFddbr.Enabled = False
            Me.TxtGsdjh.Enabled = False
            Me.TxtZczb.Enabled = False
            Me.TxtJyfw.Enabled = False
            Me.TxtLxr.Enabled = False
            Me.TxtMobile.Enabled = False
            Me.TxtTel.Enabled = False
            Me.TxtFax.Enabled = False
            Me.TxtEmail.Enabled = False
            Me.TxtZydm.Enabled = False
            Me.CmbFktj.Enabled = False
            Me.NudFkts.Enabled = False
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
            Me.TxtLbdm.Enabled = True
            Me.TxtCsdm.Enabled = True
            Me.TxtCsmc.Enabled = True
            Me.TxtKhsm.Enabled = True
            Me.TxtAddress.Enabled = True
            Me.TxtPostCode.Enabled = True
            Me.TxtWaddress.Enabled = True
            Me.TxtKhyh.Enabled = True
            Me.TxtYhzh.Enabled = True
            Me.TxtSwdjh.Enabled = True
            Me.TxtFddbr.Enabled = True
            Me.TxtGsdjh.Enabled = True
            Me.TxtZczb.Enabled = True
            Me.TxtJyfw.Enabled = True
            Me.TxtLxr.Enabled = True
            Me.TxtMobile.Enabled = True
            Me.TxtTel.Enabled = True
            Me.TxtFax.Enabled = True
            Me.TxtEmail.Enabled = True
            Me.TxtZydm.Enabled = True
            Me.CmbFktj.Enabled = True
            Me.NudFkts.Enabled = True
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
            Me.TxtCsdm.Focus()
        End If
    End Sub

#End Region

#Region "��Ӧ����������¼�"

    Private Sub Txtlbdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLbdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_cslb"
                    .paraField1 = "lbdm"
                    .paraField2 = "lbmc"
                    .paraField3 = "lbsm"
                    .paraTitle = "��Ӧ�����"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtLbdm.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub Txtlbdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtLbdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtLbdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_cslb WHERE (lbdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = Trim(TxtLbdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_cslb") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_cslb").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_cslb")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_cslb").Rows.Count > 0 Then
                TxtLbdm.Text = Trim(rcDataset.Tables("rc_cslb").Rows(0).Item("lbdm"))
                LblLbmc.Text = Trim(rcDataset.Tables("rc_cslb").Rows(0).Item("lbmc"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "�Զ�����"

    Private Sub BtnAutoKhdm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAutoKhdm.Click
        If Not String.IsNullOrEmpty(Me.TxtLbdm.Text) And Me.TxtLbdm.Text.Length = 2 And Me.TxtCsdm.Enabled Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT Max(csdm) As csdm FROM rc_csxx WHERE lbdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = Trim(TxtLbdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("autocsdm") IsNot Nothing Then
                    rcDataset.Tables("autocsdm").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "autocsdm")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("autocsdm").Rows.Count > 0 Then
                If rcDataset.Tables("autocsdm").Rows(0).Item("csdm").GetType().ToString <> "System.DBNull" Then
                    If Trim(rcDataset.Tables("autocsdm").Rows(0).Item("csdm")).Length = 5 Then
                        Me.TxtCsdm.Text = Trim(Me.TxtLbdm.Text) & (Val(Mid(rcDataset.Tables("autocsdm").Rows(0).Item("csdm"), 3, 3)) + 1).ToString.PadLeft(3, "0")
                    End If
                End If
            End If
            If String.IsNullOrEmpty(Me.TxtCsdm.Text) Then
                Me.TxtCsdm.Text = Trim(Me.TxtLbdm.Text) & "001"
            End If
        End If
    End Sub

#End Region

#Region "��Ӧ�������¼�"

    Private Sub TxtKhmc_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCsmc.Validating
        Dim spell As New ClsGetChineseSpell
        Me.TxtKhsm.Text = Trim(Mid(spell.GetChineseSpell(Me.TxtCsmc.Text), 1, 12))
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
                TxtZydm.Text = Trim(rcDataset.Tables("rc_zyxx").Rows(0).Item("zydm"))
                LblZymc.Text = Trim(rcDataset.Tables("rc_zyxx").Rows(0).Item("zymc"))
            Else
                e.Cancel = True
            End If
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
        Me.TxtCsdm.Enabled = False
    End Sub

#End Region

#Region "����"

    Private Sub TsSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MnuiSave.Click
        SaveEvent()
    End Sub

    Private Sub SaveEvent()
        If String.IsNullOrEmpty(Me.TxtCsdm.Text) Then
            MsgBox("��Ӧ�̱��벻��Ϊ�ա�", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            Return
        End If
        If String.IsNullOrEmpty(Me.CmbFktj.Text) Then
            MsgBox("������������Ϊ�ա�", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            Return
        End If
        If Me.CmbFktj.SelectedItem = "�����" Or Me.CmbFktj.SelectedItem = "��������" Then
            Me.NudFkts.Value = 0
        End If
        If Me.CmbFktj.SelectedItem = "�½�" And Me.NudFkts.Value = 0 Then
            MsgBox("�����������½�ʱ��������������Ϊ0��", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            Return
        End If
        '����
        If isAdding Then
            'REM ���ӱ���
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "Insert Into rc_csxx (lbdm,lbmc,csdm,csmc,cssm,address,waddress,khyh,yhzh,swdjh,fddbr,gsdjh,zczb,jyfw,lxr,mobile,tel,fax,email,zydm,zymc,fktj,fkts) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = Trim(TxtLbdm.Text)
                rcOleDbCommand.Parameters.Add("@lbmc", OleDbType.VarChar, 30).Value = Trim(LblLbmc.Text)
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(TxtCsdm.Text)
                rcOleDbCommand.Parameters.Add("@csmc", OleDbType.VarChar, 50).Value = Trim(TxtCsmc.Text)
                rcOleDbCommand.Parameters.Add("@cssm", OleDbType.VarChar, 12).Value = Trim(TxtKhsm.Text)
                rcOleDbCommand.Parameters.Add("@address", OleDbType.VarChar, 50).Value = Trim(TxtAddress.Text)
                rcOleDbCommand.Parameters.Add("@waddress", OleDbType.VarChar, 50).Value = Trim(TxtWaddress.Text)
                rcOleDbCommand.Parameters.Add("@khyh", OleDbType.VarChar, 40).Value = Trim(TxtKhyh.Text)
                rcOleDbCommand.Parameters.Add("@yhzh", OleDbType.VarChar, 25).Value = Trim(TxtYhzh.Text)
                rcOleDbCommand.Parameters.Add("@swdjh", OleDbType.VarChar, 20).Value = Trim(TxtSwdjh.Text)
                rcOleDbCommand.Parameters.Add("@gsdjh", OleDbType.VarChar, 20).Value = Trim(TxtGsdjh.Text)
                rcOleDbCommand.Parameters.Add("@fddbr", OleDbType.VarChar, 30).Value = Trim(TxtFddbr.Text)
                rcOleDbCommand.Parameters.Add("@zczb", OleDbType.Integer, 4).Value = TxtZczb.Text
                rcOleDbCommand.Parameters.Add("@jyfw", OleDbType.VarChar, 200).Value = Trim(TxtJyfw.Text)
                rcOleDbCommand.Parameters.Add("@lxr", OleDbType.VarChar, 20).Value = Trim(TxtLxr.Text)
                rcOleDbCommand.Parameters.Add("@mobile", OleDbType.VarChar, 12).Value = Trim(TxtMobile.Text)
                rcOleDbCommand.Parameters.Add("@tel", OleDbType.VarChar, 40).Value = Trim(TxtTel.Text)
                rcOleDbCommand.Parameters.Add("@fax", OleDbType.VarChar, 20).Value = Trim(TxtFax.Text)
                rcOleDbCommand.Parameters.Add("@email", OleDbType.VarChar, 30).Value = Trim(TxtEmail.Text)
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(TxtZydm.Text)
                rcOleDbCommand.Parameters.Add("@zymc", OleDbType.VarChar, 30).Value = Trim(LblZymc.Text)
                rcOleDbCommand.Parameters.Add("@fktj", OleDbType.VarChar, 10).Value = Trim(Me.CmbFktj.SelectedItem)
                rcOleDbCommand.Parameters.Add("@fkts", OleDbType.Integer, 4).Value = Me.NudFkts.Text
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "SELECT * FROM rc_csxx ORDER BY csdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_csxx") IsNot Nothing Then
                    rcDataset.Tables("rc_csxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_csxx")
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
                rcOleDbCommand.CommandText = "UPDATE rc_csxx SET lbdm = ?,lbmc = ?,csmc = ?, cssm = ?,address = ?,waddress = ?,khyh = ?,yhzh=?, swdjh = ?,fddbr = ?,gsdjh = ?,zczb = ?,jyfw = ?,lxr = ?,mobile = ?,tel = ?,fax = ? ,email = ?,zydm= ?,zymc = ?,fktj = ?,fkts = ?  WHERE  csdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = Trim(TxtLbdm.Text)
                rcOleDbCommand.Parameters.Add("@lbmc", OleDbType.VarChar, 30).Value = Trim(LblLbmc.Text)
                rcOleDbCommand.Parameters.Add("@csmc", OleDbType.VarChar, 30).Value = Trim(TxtCsmc.Text)
                rcOleDbCommand.Parameters.Add("@cssm", OleDbType.VarChar, 12).Value = Trim(TxtKhsm.Text)
                rcOleDbCommand.Parameters.Add("@address", OleDbType.VarChar, 50).Value = Trim(TxtAddress.Text)
                rcOleDbCommand.Parameters.Add("@waddress", OleDbType.VarChar, 50).Value = Trim(TxtWaddress.Text)
                rcOleDbCommand.Parameters.Add("@khyh", OleDbType.VarChar, 40).Value = Trim(TxtKhyh.Text)
                rcOleDbCommand.Parameters.Add("@yhzh", OleDbType.VarChar, 25).Value = Trim(TxtYhzh.Text)
                rcOleDbCommand.Parameters.Add("@swdjh", OleDbType.VarChar, 20).Value = Trim(TxtSwdjh.Text)
                rcOleDbCommand.Parameters.Add("@gsdjh", OleDbType.VarChar, 20).Value = Trim(TxtGsdjh.Text)
                rcOleDbCommand.Parameters.Add("@fddbr", OleDbType.VarChar, 30).Value = Trim(TxtFddbr.Text)
                rcOleDbCommand.Parameters.Add("@zczb", OleDbType.Integer, 4).Value = TxtZczb.Text
                rcOleDbCommand.Parameters.Add("@jyfw", OleDbType.VarChar, 200).Value = Trim(TxtJyfw.Text)
                rcOleDbCommand.Parameters.Add("@lxr", OleDbType.VarChar, 20).Value = Trim(TxtLxr.Text)
                rcOleDbCommand.Parameters.Add("@mobile", OleDbType.VarChar, 12).Value = Trim(TxtMobile.Text)
                rcOleDbCommand.Parameters.Add("@tel", OleDbType.VarChar, 40).Value = Trim(TxtTel.Text)
                rcOleDbCommand.Parameters.Add("@fax", OleDbType.VarChar, 20).Value = Trim(TxtFax.Text)
                rcOleDbCommand.Parameters.Add("@email", OleDbType.VarChar, 30).Value = Trim(TxtEmail.Text)
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(TxtZydm.Text)
                rcOleDbCommand.Parameters.Add("@zymc", OleDbType.VarChar, 30).Value = Trim(LblZymc.Text)
                rcOleDbCommand.Parameters.Add("@fktj", OleDbType.VarChar, 10).Value = Trim(Me.CmbFktj.SelectedItem)
                rcOleDbCommand.Parameters.Add("@fkts", OleDbType.Integer, 4).Value = Me.NudFkts.Text
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(TxtCsdm.Text)
                rcOleDbCommand.ExecuteNonQuery()
                '�������
                rcOleDbCommand.CommandText = "SELECT * FROM rc_csxx ORDER BY csdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_csxx") IsNot Nothing Then
                    rcDataset.Tables("rc_csxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_csxx")
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
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_csxx ORDER BY csdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_csxx") IsNot Nothing Then
                rcDataset.Tables("rc_csxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_csxx")
            BindingContext(rcDataView, "").Position = currentPos
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
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

    Private Sub CmbFktj_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbFktj.SelectedValueChanged
        If Me.CmbFktj.Text = "�����" Or Me.CmbFktj.Text = "��������" Then
            Me.NudFkts.Value = 0
        End If
    End Sub
End Class