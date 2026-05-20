Imports System.Data.OleDb

Public Class FrmGxEdit

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

    Private Sub FrmGxEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.TxtGxdm.DataBindings.Add("Text", rcDataView, "gxdm")
        Me.TxtGxmc.DataBindings.Add("Text", rcDataView, "gxmc")
        Me.TxtGxsm.DataBindings.Add("Text", rcDataView, "gxsm")
        Me.TxtBmdm.DataBindings.Add("Text", rcDataView, "bmdm")
        Me.LblBmmc.DataBindings.Add("Text", rcDataView, "bmmc")
        Me.TxtYdcl.DataBindings.Add("Text", rcDataView, "ydcl")
        Me.TxtYdbl_clcb.DataBindings.Add("Text", rcDataView, "ydbl_clcb")
        Me.TxtYdbl_rgcb.DataBindings.Add("Text", rcDataView, "ydbl_rgcb")
        Me.TxtYdbl_nycb.DataBindings.Add("Text", rcDataView, "ydbl_nycb")
        Me.TxtYdbl_zjcb.DataBindings.Add("Text", rcDataView, "ydbl_zjcb")
        Me.TxtYdbl_glcb.DataBindings.Add("Text", rcDataView, "ydbl_glcb")
        BindingContext(rcDataView, "").Position = currentPos
        SetAll(True)
        If isAdding Then
            '�����ǰ�༭����
            BindingContext(rcDataView, "").EndCurrentEdit()
            '����һ��
            BindingContext(rcDataView, "").AddNew()
        Else
            Me.TxtGxdm.Enabled = False
        End If
    End Sub

#End Region

#Region "�ؼ��س����Ĵ���"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGxdm.KeyPress, TxtGxsm.KeyPress, TxtGxmc.KeyPress, TxtBmdm.KeyPress, TxtYdcl.KeyPress, TxtYdbl_clcb.KeyPress, TxtYdbl_rgcb.KeyPress, TxtYdbl_nycb.KeyPress, TxtYdbl_zjcb.KeyPress, TxtYdbl_glcb.KeyPress
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
            Me.TxtGxdm.Enabled = False
            Me.TxtGxmc.Enabled = False
            Me.TxtGxsm.Enabled = False
            Me.TxtBmdm.Enabled = False
            Me.TxtYdcl.Enabled = False
            Me.TxtYdbl_clcb.Enabled = False
            Me.TxtYdbl_rgcb.Enabled = False
            Me.TxtYdbl_nycb.Enabled = False
            Me.TxtYdbl_zjcb.Enabled = False
            Me.TxtYdbl_glcb.Enabled = False
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
            Me.TxtGxdm.Enabled = True
            Me.TxtGxmc.Enabled = True
            Me.TxtGxsm.Enabled = True
            Me.TxtBmdm.Enabled = True
            Me.TxtYdcl.Enabled = True
            Me.TxtYdbl_clcb.Enabled = True
            Me.TxtYdbl_rgcb.Enabled = True
            Me.TxtYdbl_nycb.Enabled = True
            Me.TxtYdbl_zjcb.Enabled = True
            Me.TxtYdbl_glcb.Enabled = True
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
            Me.TxtGxdm.Focus()
        End If
    End Sub

#End Region

#Region "���������¼�"

    Private Sub TxtGxmc_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtGxmc.Validating
        Dim spell As New ClsGetChineseSpell
        Me.TxtGxsm.Text = Trim(Mid(spell.GetChineseSpell(Me.TxtGxmc.Text), 1, 12))
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
        Me.TxtGxdm.Enabled = False
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
            'Else
            '    MsgBox("�����벿����Ϣ��", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            '    Return
        End If
        '����
        If isAdding Then
            If Trim(TxtGxdm.Text).Length = 0 Then
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
                rcOleDbCommand.CommandText = "Insert Into rc_gxxx (gxdm,gxmc,gxsm,bmdm,bmmc,ydcl,ydbl_clcb,ydbl_rgcb,ydbl_nycb,ydbl_zjcb,ydbl_glcb) VALUES (?,?,?,?,?,?,?,?,?,?,?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@gxdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtGxdm.Text)
                rcOleDbCommand.Parameters.Add("@gxmc", OleDbType.VarChar, 30).Value = Trim(Me.TxtGxmc.Text)
                rcOleDbCommand.Parameters.Add("@gxsm", OleDbType.VarChar, 12).Value = Trim(Me.TxtGxsm.Text)
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtBmdm.Text)
                rcOleDbCommand.Parameters.Add("@bmmc", OleDbType.VarChar, 30).Value = Trim(Me.LblBmmc.Text)
                rcOleDbCommand.Parameters.Add("@ydcl", OleDbType.Numeric, 6).Value = Me.TxtYdcl.Text / 100
                rcOleDbCommand.Parameters.Add("@ydbl_clcb", OleDbType.Numeric, 6).Value = Me.TxtYdbl_clcb.Text / 100
                rcOleDbCommand.Parameters.Add("@ydbl_rgcb", OleDbType.Numeric, 6).Value = Me.TxtYdbl_rgcb.Text / 100
                rcOleDbCommand.Parameters.Add("@ydbl_nycb", OleDbType.Numeric, 6).Value = Me.TxtYdbl_nycb.Text / 100
                rcOleDbCommand.Parameters.Add("@ydbl_zjcb", OleDbType.Numeric, 6).Value = Me.TxtYdbl_zjcb.Text / 100
                rcOleDbCommand.Parameters.Add("@ydbl_glcb", OleDbType.Numeric, 6).Value = Me.TxtYdbl_glcb.Text / 100
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "SELECT gxdm,gxmc,gxsm,bmdm,bmmc,ydcl*100 AS ydcl,ydbl_clcb * 100 AS ydbl_clcb,ydbl_rgcb*100 AS ydbl_rgcb,ydbl_nycb * 100 AS ydbl_nycb,ydbl_zjcb* 100 AS ydbl_zjcb,ydbl_glcb*100 AS ydbl_glcb FROM rc_gxxx ORDER BY gxdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_gxxx") IsNot Nothing Then
                    rcDataset.Tables("rc_gxxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_gxxx")
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
                rcOleDbCommand.CommandText = "UPDATE rc_gxxx SET gxmc = ? , gxsm = ? ,bmdm = ? ,bmmc = ?,ydcl = ?,ydbl_clcb = ?,ydbl_rgcb = ?,ydbl_nycb = ?,ydbl_zjcb = ?,ydbl_glcb = ?  WHERE  gxdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@gxmc", OleDbType.VarChar, 30).Value = Trim(TxtGxmc.Text)
                rcOleDbCommand.Parameters.Add("@gxsm", OleDbType.VarChar, 12).Value = Trim(TxtGxsm.Text)
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(TxtBmdm.Text)
                rcOleDbCommand.Parameters.Add("@bmmc", OleDbType.VarChar, 30).Value = Trim(Me.LblBmmc.Text)
                rcOleDbCommand.Parameters.Add("@ydcl", OleDbType.Numeric, 6).Value = Me.TxtYdcl.Text / 100
                rcOleDbCommand.Parameters.Add("@ydbl_clcb", OleDbType.Numeric, 6).Value = Me.TxtYdbl_clcb.Text / 100
                rcOleDbCommand.Parameters.Add("@ydbl_rgcb", OleDbType.Numeric, 6).Value = Me.TxtYdbl_rgcb.Text / 100
                rcOleDbCommand.Parameters.Add("@ydbl_nycb", OleDbType.Numeric, 6).Value = Me.TxtYdbl_nycb.Text / 100
                rcOleDbCommand.Parameters.Add("@ydbl_zjcb", OleDbType.Numeric, 6).Value = Me.TxtYdbl_zjcb.Text / 100
                rcOleDbCommand.Parameters.Add("@ydbl_glcb", OleDbType.Numeric, 6).Value = Me.TxtYdbl_glcb.Text / 100
                rcOleDbCommand.Parameters.Add("@gxdm", OleDbType.VarChar, 12).Value = Trim(TxtGxdm.Text)
                rcOleDbCommand.ExecuteNonQuery()
                '�������
                rcOleDbCommand.CommandText = "SELECT gxdm,gxmc,gxsm,bmdm,bmmc,ydcl*100 AS ydcl,ydbl_clcb * 100 AS ydbl_clcb,ydbl_rgcb*100 AS ydbl_rgcb,ydbl_nycb * 100 AS ydbl_nycb,ydbl_zjcb* 100 AS ydbl_zjcb,ydbl_glcb*100 AS ydbl_glcb FROM rc_gxxx ORDER BY gxdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_gxxx") IsNot Nothing Then
                    rcDataset.Tables("rc_gxxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_gxxx")
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
            rcOleDbCommand.CommandText = "SELECT gxdm,gxmc,gxsm,bmdm,bmmc,ydcl*100 AS ydcl,ydbl_clcb * 100 AS ydbl_clcb,ydbl_rgcb*100 AS ydbl_rgcb,ydbl_nycb * 100 AS ydbl_nycb,ydbl_zjcb* 100 AS ydbl_zjcb,ydbl_glcb*100 AS ydbl_glcb FROM rc_gxxx ORDER BY gxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_gxxx") IsNot Nothing Then
                rcDataset.Tables("rc_gxxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_gxxx")
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