Imports System.Data.OleDb

Public Class FrmCpEdit

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

    Private Sub FrmCpEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.TxtLbdm.DataBindings.Add("Text", rcDataView, "lbdm")
        Me.LblLbmc.DataBindings.Add("Text", rcDataView, "lbmc")
        Me.TxtCpdm.DataBindings.Add("Text", rcDataView, "cpdm")
        Me.TxtCpmc.DataBindings.Add("Text", rcDataView, "cpmc")
        Me.TxtDw.DataBindings.Add("Text", rcDataView, "dw")
        Me.TxtCkdm.DataBindings.Add("Text", rcDataView, "ckdm")
        Me.LblCkmc.DataBindings.Add("Text", rcDataView, "ckmc")
        Me.CmbHsfl.DataBindings.Add("SelectedItem", rcDataView, "hsfl")
        Me.TxtMjsl.DataBindings.Add("Text", rcDataView, "mjsl")
        Me.TxtFzdw.DataBindings.Add("Text", rcDataView, "fzdw")
        Me.TxtCpsm.DataBindings.Add("Text", rcDataView, "cpsm")
        Me.TxtKuwei.DataBindings.Add("Text", rcDataView, "kuwei")
        Me.TxtOldCpdm.DataBindings.Add("Text", rcDataView, "oldcpdm")
        Me.TxtKhdm.DataBindings.Add("Text", rcDataView, "khdm")
        Me.LblKhmc.DataBindings.Add("Text", rcDataView, "khmc")
        Me.TxtXsdj.DataBindings.Add("Text", rcDataView, "xsdj")
        Me.TxtCgdj.DataBindings.Add("Text", rcDataView, "cgdj")
        Me.TxtBeiShu.DataBindings.Add("Text", rcDataView, "beishu")
        Me.TxtBzcb.DataBindings.Add("Text", rcDataView, "bzcb")
        Me.TxtClcb.DataBindings.Add("Text", rcDataView, "clcb")
        Me.TxtRgcb.DataBindings.Add("Text", rcDataView, "rgcb")
        Me.TxtNycb.DataBindings.Add("Text", rcDataView, "nycb")
        Me.TxtZjcb.DataBindings.Add("Text", rcDataView, "zjcb")
        Me.TxtGlcb.DataBindings.Add("Text", rcDataView, "glcb")
        Me.TxtXstcbl.DataBindings.Add("Text", rcDataView, "xstcbl")
        Me.TxtZdcb.DataBindings.Add("Text", rcDataView, "zdcb")
        Me.TxtZgcb.DataBindings.Add("Text", rcDataView, "zgcb")
        Me.TxtCgts.DataBindings.Add("Text", rcDataView, "cgts")
        Me.TxtCpWeight.DataBindings.Add("Text", rcDataView, "cpweight")
        Me.TxtLength.DataBindings.Add("Text", rcDataView, "length")
        Me.TxtWidth.DataBindings.Add("Text", rcDataView, "width")
        Me.TxtHeight.DataBindings.Add("Text", rcDataView, "height")
        Me.ChbBRecycling.DataBindings.Add("Checked", rcDataView, "brecycling")
        Me.ChbBFadm.DataBindings.Add("Checked", rcDataView, "bfadm")
        Me.ChbBBatch.DataBindings.Add("Checked", rcDataView, "bbatch")
        BindingContext(rcDataView, "").Position = currentPos
        SetAll(True)
        If isAdding Then
            '�����ǰ�༭����
            BindingContext(rcDataView, "").EndCurrentEdit()
            '����һ��
            BindingContext(rcDataView, "").AddNew()
            'Me.BtnAutoCpdm.Enabled = True
        Else
            Me.TxtCpdm.Enabled = False
            'Me.BtnAutoCpdm.Enabled = False
        End If
    End Sub

#End Region

#Region "�ؼ��س����Ĵ���"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLbdm.KeyPress, TxtCpdm.KeyPress, TxtCpmc.KeyPress, TxtDw.KeyPress, TxtCkdm.KeyPress, CmbHsfl.KeyPress, TxtFzdw.KeyPress, TxtCpsm.KeyPress, TxtKuwei.KeyPress, TxtOldCpdm.KeyPress, TxtKhdm.KeyPress, TxtXsdj.KeyPress, TxtCgdj.KeyPress, TxtBeiShu.KeyPress, TxtBzcb.KeyPress, TxtClcb.KeyPress, TxtRgcb.KeyPress, TxtNycb.KeyPress, TxtZjcb.KeyPress, TxtGlcb.KeyPress, TxtXstcbl.KeyPress, TxtZdcb.KeyPress, TxtZgcb.KeyPress, TxtCgts.KeyPress, TxtCpWeight.KeyPress, TxtLength.KeyPress, TxtWidth.KeyPress, TxtHeight.KeyPress, TxtMjsl.KeyPress
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
            Me.TxtCpdm.Enabled = False
            Me.TxtCpmc.Enabled = False
            Me.TxtDw.Enabled = False
            Me.TxtCkdm.Enabled = False
            Me.CmbHsfl.Enabled = False
            Me.TxtMjsl.Enabled = False
            Me.TxtFzdw.Enabled = False
            Me.TxtCpsm.Enabled = False
            Me.TxtKuwei.Enabled = False
            Me.TxtOldCpdm.Enabled = False
            Me.TxtKhdm.Enabled = False
            Me.TxtXsdj.Enabled = False
            Me.TxtCgdj.Enabled = False
            Me.TxtBeiShu.Enabled = False
            Me.TxtBzcb.Enabled = False
            Me.TxtClcb.Enabled = False
            Me.TxtRgcb.Enabled = False
            Me.TxtNycb.Enabled = False
            Me.TxtZjcb.Enabled = False
            Me.TxtGlcb.Enabled = False
            Me.TxtXstcbl.Enabled = False
            Me.TxtZdcb.Enabled = False
            Me.TxtZgcb.Enabled = False
            Me.TxtCgts.Enabled = False
            Me.TxtCpWeight.Enabled = False
            Me.TxtLength.Enabled = False
            Me.TxtWidth.Enabled = False
            Me.TxtHeight.Enabled = False
            Me.ChbBRecycling.Enabled = False
            Me.ChbBFadm.Enabled = False
            Me.ChbBBatch.Enabled = False
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
            Me.TxtCpdm.Enabled = True
            Me.TxtCpmc.Enabled = True
            Me.TxtDw.Enabled = True
            Me.TxtCkdm.Enabled = True
            Me.CmbHsfl.Enabled = True
            Me.TxtMjsl.Enabled = True
            Me.TxtFzdw.Enabled = True
            Me.TxtCpsm.Enabled = True
            Me.TxtKuwei.Enabled = True
            Me.TxtOldCpdm.Enabled = True
            Me.TxtKhdm.Enabled = True
            Me.TxtXsdj.Enabled = True
            Me.TxtCgdj.Enabled = True
            Me.TxtBeiShu.Enabled = True
            Me.TxtBzcb.Enabled = True
            Me.TxtClcb.Enabled = True
            Me.TxtRgcb.Enabled = True
            Me.TxtNycb.Enabled = True
            Me.TxtZjcb.Enabled = True
            Me.TxtGlcb.Enabled = True
            Me.TxtXstcbl.Enabled = True
            Me.TxtZdcb.Enabled = True
            Me.TxtZgcb.Enabled = True
            Me.TxtCgts.Enabled = True
            Me.TxtCpWeight.Enabled = True
            Me.TxtLength.Enabled = True
            Me.TxtWidth.Enabled = True
            Me.TxtHeight.Enabled = True
            Me.ChbBRecycling.Enabled = True
            Me.ChbBFadm.Enabled = True
            Me.ChbBBatch.Enabled = True
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
            Me.TxtCpdm.Focus()
            If Not String.IsNullOrEmpty(Me.TxtLbdm.Text) Then
                Try
                    rcOleDbConn.Open()
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    rcOleDbCommand.CommandText = "SELECT * FROM rc_cplb WHERE (lbdm = ?)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = Trim(TxtLbdm.Text)
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("rc_cplb") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_cplb").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "rc_cplb")
                Catch ex As Exception
                    MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                    Return
                Finally
                    rcOleDbConn.Close()
                End Try
                If rcDataset.Tables("rc_cplb").Rows.Count > 0 Then
                    TxtLbdm.Text = Trim(rcDataset.Tables("rc_cplb").Rows(0).Item("lbdm"))
                    LblLbmc.Text = Trim(rcDataset.Tables("rc_cplb").Rows(0).Item("lbmc"))
                End If
            End If
        End If
    End Sub

#End Region

#Region "������������¼�"

    Private Sub Txtlbdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLbdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_cplb"
                    .paraField1 = "lbdm"
                    .paraField2 = "lbmc"
                    .paraField3 = "lbsm"
                    .paraTitle = "�������"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtLbdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub Txtlbdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtLbdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtLbdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_cplb WHERE (lbdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = Trim(TxtLbdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_cplb") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_cplb").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_cplb")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_cplb").Rows.Count > 0 Then
                TxtLbdm.Text = Trim(rcDataset.Tables("rc_cplb").Rows(0).Item("lbdm"))
                LblLbmc.Text = Trim(rcDataset.Tables("rc_cplb").Rows(0).Item("lbmc"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "�Զ������¼�"

    Private Sub BtnAutoCpdm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAutoCpdm.Click
        If Me.TxtCpdm.Enabled Then
            If Not String.IsNullOrEmpty(TxtKhdm.Text) And Me.TxtKhdm.Text.Length = 5 And Me.TxtCpdm.Enabled Then
                Try
                    rcOleDbConn.Open()
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    rcOleDbCommand.CommandText = "SELECT Max(cpdm) As cpdm FROM rc_cpxx WHERE khdm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKhdm.Text)
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("autocpdm") IsNot Nothing Then
                        rcDataset.Tables("autocpdm").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "autocpdm")
                Catch ex As Exception
                    MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                    Return
                Finally
                    rcOleDbConn.Close()
                End Try
                If rcDataset.Tables("autocpdm").Rows.Count > 0 Then
                    If rcDataset.Tables("autocpdm").Rows(0).Item("cpdm").GetType().ToString <> "System.DBNull" Then
                        If Trim(rcDataset.Tables("autocpdm").Rows(0).Item("cpdm")).Length = 9 Then
                            Me.TxtCpdm.Text = Trim(Me.TxtKhdm.Text) & (Val(Mid(rcDataset.Tables("autocpdm").Rows(0).Item("cpdm"), 6, 4)) + 1).ToString.PadLeft(4, "0")
                        End If
                    End If
                End If
                If String.IsNullOrEmpty(Me.TxtCpdm.Text) Then
                    Me.TxtCpdm.Text = Trim(Me.TxtKhdm.Text) & "0001"
                End If
            Else
                '����������Զ�����
                If Not String.IsNullOrEmpty(Me.TxtLbdm.Text) Then
                    Try
                        rcOleDbConn.Open()
                        rcOleDbCommand.Connection = rcOleDbConn
                        rcOleDbCommand.CommandTimeout = 300
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT MAX(cpdm) As cpdm FROM rc_cpxx WHERE lbdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtLbdm.Text)
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("autocpdm") IsNot Nothing Then
                            rcDataset.Tables("autocpdm").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "autocpdm")
                    Catch ex As Exception
                        MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                    If rcDataset.Tables("autocpdm").Rows.Count > 0 Then
                        If rcDataset.Tables("autocpdm").Rows(0).Item("cpdm").GetType().ToString <> "System.DBNull" Then
                            Me.TxtCpdm.Text = (Val(rcDataset.Tables("autocpdm").Rows(0).Item("cpdm")) + 1).ToString.PadLeft(5, "0")
                        End If
                    End If
                    If String.IsNullOrEmpty(Me.TxtCpdm.Text) Then
                        Me.TxtCpdm.Text = Trim(Me.TxtLbdm.Text) & "001"
                    End If
                End If
            End If
        End If
    End Sub

#End Region

#Region "���������¼�"

    Private Sub TxtCpmc_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCpmc.Validating
        Dim spell As New ClsGetChineseSpell
        Me.TxtCpsm.Text = Trim(Mid(spell.GetChineseSpell(Me.TxtCpmc.Text), 1, 12))
    End Sub

#End Region

#Region "�ͻ������¼�"

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
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_khxx").Rows.Count > 0 Then
                Me.TxtKhdm.Text = Trim(rcDataset.Tables("rc_khxx").Rows(0).Item("khdm"))
                Me.LblKhmc.Text = Trim(rcDataset.Tables("rc_khxx").Rows(0).Item("khmc"))
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
        Me.rcOpenFileDialog.FileName = ""
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
        Me.rcOpenFileDialog.FileName = ""
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
        Me.TxtCpdm.Enabled = False
    End Sub

#End Region

#Region "����"

    Private Sub TsSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MnuiSave.Click
        SaveEvent()
    End Sub

    Private Sub SaveEvent()
        Me.TabControl1.SelectedIndex = 4
        Me.TabControl1.SelectedIndex = 3
        Me.TabControl1.SelectedIndex = 2
        Me.TabControl1.SelectedIndex = 1
        Me.TabControl1.SelectedIndex = 0
        '
        If String.IsNullOrEmpty(Me.TxtLbdm.Text) Then
            MsgBox("���������Ϊ�ա�", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            Return
        End If
        If String.IsNullOrEmpty(Me.TxtCpdm.Text) Then
            MsgBox("���ϱ��벻��Ϊ�ա�", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            Return
        End If
        If String.IsNullOrEmpty(Me.TxtDw.Text) Then
            MsgBox("������λ����Ϊ�ա�", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            Return
        End If
        If String.IsNullOrEmpty(Me.TxtCkdm.Text) Then
            MsgBox("Ĭ�ϲֿⲻ��Ϊ�ա�", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            Return
        End If
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 12).Value = Trim(Me.TxtCkdm.Text)
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
        '�滻����
        Me.TxtCpmc.Text = Me.TxtCpmc.Text.Replace("��", ",")
        '����
        If isAdding Then
            If String.IsNullOrEmpty(Me.TxtCpdm.Text) Then
                Return
            End If
            '�ظ������ѯ
            If Not String.IsNullOrEmpty(Me.TxtCpdm.Text) Then
                Try
                    rcOleDbConn.Open()
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    rcOleDbCommand.CommandText = "SELECT * FROM rc_cpxx WHERE (COALESCE(cpmc,' ') = ? AND COALESCE(dw,' ') = ?)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@cpmc", OleDbType.VarChar, 100).Value = IIf(Not String.IsNullOrEmpty(Me.TxtCpmc.Text), Me.TxtCpmc.Text, " ")
                    rcOleDbCommand.Parameters.Add("@dw", OleDbType.VarChar, 8).Value = IIf(Not String.IsNullOrEmpty(Me.TxtDw.Text), Me.TxtDw.Text, " ")
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("repcpxx") IsNot Nothing Then
                        Me.rcDataset.Tables("repcpxx").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "repcpxx")
                Catch ex As Exception
                    MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                    Return
                Finally
                    rcOleDbConn.Close()
                End Try
                If rcDataset.Tables("repcpxx").Rows.Count > 0 Then
                    MsgBox("�ظ����룬�����ٱ��롣", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                    Return
                End If
            End If
            'REM ���ӱ���
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "Insert Into rc_cpxx (lbdm,cpdm,cpmc,dw,ckdm,hsfl,mjsl,fzdw,cpsm,kuwei,oldcpdm,khdm,xsdj,cgdj,beishu,bzcb,clcb,rgcb,nycb,zjcb,glcb,xstcbl,zdcb,zgcb,cgts,cpweight,length,width,height,brecycling,bfadm,bbatch,srr,srrq) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,SYSDATE)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = Trim(TxtLbdm.Text)
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(TxtCpdm.Text)
                rcOleDbCommand.Parameters.Add("@cpmc", OleDbType.VarChar, 100).Value = Trim(TxtCpmc.Text)
                rcOleDbCommand.Parameters.Add("@dw", OleDbType.VarChar, 8).Value = Trim(Me.TxtDw.Text)
                rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtCkdm.Text)
                rcOleDbCommand.Parameters.Add("@hsfl", OleDbType.VarChar, 12).Value = Me.CmbHsfl.SelectedItem
                rcOleDbCommand.Parameters.Add("@mjsl", OleDbType.Numeric, 18).Value = Val(Me.TxtMjsl.Text)
                rcOleDbCommand.Parameters.Add("@fzdw", OleDbType.VarChar, 8).Value = Trim(Me.TxtFzdw.Text)
                rcOleDbCommand.Parameters.Add("@cpsm", OleDbType.VarChar, 12).Value = Trim(TxtCpsm.Text)
                rcOleDbCommand.Parameters.Add("@kuwei", OleDbType.VarChar, 50).Value = Trim(TxtKuwei.Text)
                rcOleDbCommand.Parameters.Add("@oldcpdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtOldCpdm.Text)
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(TxtKhdm.Text)
                rcOleDbCommand.Parameters.Add("@xsdj", OleDbType.Numeric, 14).Value = Val(Me.TxtXsdj.Text)
                rcOleDbCommand.Parameters.Add("@cgdj", OleDbType.Numeric, 14).Value = Val(Me.TxtCgdj.Text)
                rcOleDbCommand.Parameters.Add("@beishu", OleDbType.Numeric, 4).Value = Val(Me.TxtBeiShu.Text)
                rcOleDbCommand.Parameters.Add("@bzcb", OleDbType.Numeric, 18).Value = Val(Me.TxtBzcb.Text)
                rcOleDbCommand.Parameters.Add("@clcb", OleDbType.Numeric, 14).Value = Val(Me.TxtClcb.Text)
                rcOleDbCommand.Parameters.Add("@rgcb", OleDbType.Numeric, 14).Value = Val(Me.TxtRgcb.Text)
                rcOleDbCommand.Parameters.Add("@nycb", OleDbType.Numeric, 14).Value = Val(Me.TxtNycb.Text)
                rcOleDbCommand.Parameters.Add("@zjcb", OleDbType.Numeric, 14).Value = Val(Me.TxtZjcb.Text)
                rcOleDbCommand.Parameters.Add("@glcb", OleDbType.Numeric, 14).Value = Val(Me.TxtGlcb.Text)
                rcOleDbCommand.Parameters.Add("@xstcbl", OleDbType.Numeric, 14).Value = Val(Me.TxtXstcbl.Text)
                rcOleDbCommand.Parameters.Add("@zdcb", OleDbType.Numeric, 14).Value = Val(Me.TxtZdcb.Text)
                rcOleDbCommand.Parameters.Add("@zgcb", OleDbType.Numeric, 14).Value = Val(Me.TxtZgcb.Text)
                rcOleDbCommand.Parameters.Add("@cgts", OleDbType.Numeric, 14).Value = Val(Me.TxtCgts.Text)
                rcOleDbCommand.Parameters.Add("@cpweight", OleDbType.Numeric, 14).Value = Val(Me.TxtCpWeight.Text)
                rcOleDbCommand.Parameters.Add("@length", OleDbType.Numeric, 14).Value = Val(Me.TxtLength.Text)
                rcOleDbCommand.Parameters.Add("@width", OleDbType.Numeric, 14).Value = Val(Me.TxtWidth.Text)
                rcOleDbCommand.Parameters.Add("@height", OleDbType.Numeric, 14).Value = Val(Me.TxtHeight.Text)
                rcOleDbCommand.Parameters.Add("@brecycling", OleDbType.Numeric, 1).Value = IIf(Me.ChbBRecycling.Checked, 1, 0)
                rcOleDbCommand.Parameters.Add("@bfadm", OleDbType.Numeric, 1).Value = IIf(Me.ChbBFadm.Checked, 1, 0)
                rcOleDbCommand.Parameters.Add("@bbatch", OleDbType.Numeric, 1).Value = IIf(Me.ChbBBatch.Checked, 1, 0)
                rcOleDbCommand.Parameters.Add("@srr", OleDbType.VarChar, 30).Value = g_User_DspName
                rcOleDbCommand.ExecuteNonQuery()
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
                rcOleDbCommand.CommandText = "UPDATE rc_cpxx SET lbdm = ?,cpmc = ?,dw = ?,ckdm = ?,hsfl = ?,mjsl = ?,fzdw= ?,cpsm = ?,kuwei = ?,oldcpdm = ?,khdm = ?,xsdj = ?,cgdj = ?,beishu = ?,bzcb = ?,clcb = ?,rgcb = ?,nycb = ?,zjcb = ?,glcb = ?,xstcbl = ?,zdcb = ?,zgcb = ?,cgts = ?,cpweight = ?,length = ?,width = ?,height = ?,brecycling = ?,bfadm = ?,bbatch = ?,srr = ?,srrq = SYSDATE WHERE  cpdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = Trim(TxtLbdm.Text)
                rcOleDbCommand.Parameters.Add("@cpmc", OleDbType.VarChar, 100).Value = Trim(TxtCpmc.Text)
                rcOleDbCommand.Parameters.Add("@dw", OleDbType.VarChar, 8).Value = Trim(TxtDw.Text)
                rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtCkdm.Text)
                rcOleDbCommand.Parameters.Add("@hsfl", OleDbType.VarChar, 12).Value = Me.CmbHsfl.SelectedItem
                rcOleDbCommand.Parameters.Add("@mjsl", OleDbType.Numeric, 18).Value = Val(Me.TxtMjsl.Text)
                rcOleDbCommand.Parameters.Add("@fzdw", OleDbType.VarChar, 8).Value = Trim(Me.TxtFzdw.Text)
                rcOleDbCommand.Parameters.Add("@cpsm", OleDbType.VarChar, 12).Value = Trim(TxtCpsm.Text)
                rcOleDbCommand.Parameters.Add("@kuwei", OleDbType.VarChar, 50).Value = Trim(TxtKuwei.Text)
                rcOleDbCommand.Parameters.Add("@oldcpdm", OleDbType.VarChar, 15).Value = Trim(TxtOldCpdm.Text)
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(TxtKhdm.Text)
                rcOleDbCommand.Parameters.Add("@xsdj", OleDbType.Numeric, 14).Value = Val(Me.TxtXsdj.Text)
                rcOleDbCommand.Parameters.Add("@cgdj", OleDbType.Numeric, 14).Value = Val(Me.TxtCgdj.Text)
                rcOleDbCommand.Parameters.Add("@beishu", OleDbType.Numeric, 4).Value = Val(Me.TxtBeiShu.Text)
                rcOleDbCommand.Parameters.Add("@bzcb", OleDbType.Numeric, 18).Value = Val(Me.TxtBzcb.Text)
                rcOleDbCommand.Parameters.Add("@clcb", OleDbType.Numeric, 14).Value = Val(Me.TxtClcb.Text)
                rcOleDbCommand.Parameters.Add("@rgcb", OleDbType.Numeric, 14).Value = Val(Me.TxtRgcb.Text)
                rcOleDbCommand.Parameters.Add("@nycb", OleDbType.Numeric, 14).Value = Val(Me.TxtNycb.Text)
                rcOleDbCommand.Parameters.Add("@zjcb", OleDbType.Numeric, 14).Value = Val(Me.TxtZjcb.Text)
                rcOleDbCommand.Parameters.Add("@glcb", OleDbType.Numeric, 14).Value = Val(Me.TxtGlcb.Text)
                rcOleDbCommand.Parameters.Add("@xstcbl", OleDbType.Numeric, 14).Value = Val(Me.TxtXstcbl.Text)
                rcOleDbCommand.Parameters.Add("@zdcb", OleDbType.Numeric, 14).Value = Val(Me.TxtZdcb.Text)
                rcOleDbCommand.Parameters.Add("@zgcb", OleDbType.Numeric, 14).Value = Val(Me.TxtZgcb.Text)
                rcOleDbCommand.Parameters.Add("@cgts", OleDbType.Numeric, 14).Value = Val(Me.TxtCgts.Text)
                rcOleDbCommand.Parameters.Add("@cpweight", OleDbType.Numeric, 14).Value = Val(Me.TxtCpWeight.Text)
                rcOleDbCommand.Parameters.Add("@length", OleDbType.Numeric, 14).Value = Val(Me.TxtLength.Text)
                rcOleDbCommand.Parameters.Add("@width", OleDbType.Numeric, 14).Value = Val(Me.TxtWidth.Text)
                rcOleDbCommand.Parameters.Add("@height", OleDbType.Numeric, 14).Value = Val(Me.TxtHeight.Text)
                rcOleDbCommand.Parameters.Add("@brecycling", OleDbType.Numeric, 1).Value = IIf(Me.ChbBRecycling.Checked, 1, 0)
                rcOleDbCommand.Parameters.Add("@bfadm", OleDbType.Numeric, 1).Value = IIf(Me.ChbBFadm.Checked, 1, 0)
                rcOleDbCommand.Parameters.Add("@bbatch", OleDbType.Numeric, 1).Value = IIf(Me.ChbBBatch.Checked, 1, 0)
                rcOleDbCommand.Parameters.Add("@srr", OleDbType.VarChar, 30).Value = g_User_DspName
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(TxtCpdm.Text)
                rcOleDbCommand.ExecuteNonQuery()
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
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT rc_cpxx.lbdm,rc_cplb.lbmc,rc_cpxx.cpdm,rc_cpxx.cpmc,rc_cpxx.dw,rc_cpxx.ckdm,rc_ckxx.ckmc,rc_cpxx.hsfl,rc_cpxx.mjsl,rc_cpxx.fzdw,rc_cpxx.cpsm,rc_cpxx.kuwei,rc_cpxx.oldcpdm,rc_cpxx.khdm,rc_khxx.khmc,rc_cpxx.xsdj,rc_cpxx.cgdj,rc_cpxx.beishu,rc_cpxx.bzcb,rc_cpxx.clcb,rc_cpxx.rgcb,rc_cpxx.nycb,rc_cpxx.zjcb,rc_cpxx.glcb,rc_cpxx.xstcbl,rc_cpxx.zdcb,rc_cpxx.zgcb,rc_cpxx.cgts,rc_cpxx.cpweight,rc_cpxx.length,rc_cpxx.width,rc_cpxx.height,rc_cpxx.brecycling,rc_cpxx.bfadm,rc_cpxx.bbatch,rc_cpxx.srr,rc_cpxx.srrq FROM rc_cpxx Left Join rc_cplb On rc_cpxx.lbdm = rc_cplb.lbdm Left Join rc_khxx On rc_cpxx.khdm = rc_khxx.khdm LEFT JOIN rc_ckxx ON rc_cpxx.ckdm = rc_ckxx.ckdm ORDER BY cpdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                rcDataset.Tables("rc_cpxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
            BindingContext(rcDataView, "").Position = currentPos
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
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
            rcOleDbCommand.CommandText = "SELECT rc_cpxx.lbdm,rc_cplb.lbmc,rc_cpxx.cpdm,rc_cpxx.cpmc,rc_cpxx.dw,rc_cpxx.ckdm,rc_ckxx.ckmc,rc_cpxx.hsfl,rc_cpxx.mjsl,rc_cpxx.fzdw,rc_cpxx.cpsm,rc_cpxx.kuwei,rc_cpxx.oldcpdm,rc_cpxx.khdm,rc_khxx.khmc,rc_cpxx.xsdj,rc_cpxx.cgdj,rc_cpxx.beishu,rc_cpxx.bzcb,rc_cpxx.clcb,rc_cpxx.rgcb,rc_cpxx.nycb,rc_cpxx.zjcb,rc_cpxx.glcb,rc_cpxx.xstcbl,rc_cpxx.zdcb,rc_cpxx.zgcb,rc_cpxx.cgts,rc_cpxx.cpweight,rc_cpxx.length,rc_cpxx.width,rc_cpxx.height,rc_cpxx.brecycling,rc_cpxx.bfadm,rc_cpxx.bbatch,rc_cpxx.srr,rc_cpxx.srrq FROM rc_cpxx Left Join rc_cplb On rc_cpxx.lbdm = rc_cplb.lbdm Left Join rc_khxx On rc_cpxx.khdm = rc_khxx.khdm LEFT JOIN rc_ckxx ON rc_cpxx.ckdm = rc_ckxx.ckdm ORDER BY cpdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                rcDataset.Tables("rc_cpxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
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

    Private Sub ChbBBatch_CheckedChanged(sender As Object, e As EventArgs) Handles ChbBBatch.CheckedChanged

    End Sub
End Class