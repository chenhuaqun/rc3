Imports System.Data.OleDb
Public Class FrmKhshdzEdit

#Region "���x׃��"

    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
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

    Private Sub FrmKhshdzEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.TxtKhdm.DataBindings.Add("Text", rcDataView, "khdm")
        Me.LblKhmc.DataBindings.Add("Text", rcDataView, "khmc")
        Me.TxtXh.DataBindings.Add("Text", rcDataView, "xh")
        Me.TxtAddress.DataBindings.Add("Text", rcDataView, "address")
        Me.TxtPostCode.DataBindings.Add("Text", rcDataView, "postcode")
        Me.TxtTel.DataBindings.Add("Text", rcDataView, "tel")
        Me.TxtMobile.DataBindings.Add("Text", rcDataView, "mobile")
        Me.TxtLxr.DataBindings.Add("Text", rcDataView, "lxr")
        Me.ChbLastTimeBz.DataBindings.Add("Checked", rcDataView, "lasttimebz")
        BindingContext(rcDataView, "").Position = currentPos
        SetAll(True)
        If isAdding Then
            '�����ǰ�༭����
            BindingContext(rcDataView, "").EndCurrentEdit()
            '����һ��
            BindingContext(rcDataView, "").AddNew()
        Else
            Me.TxtKhdm.Enabled = False
        End If
    End Sub

#End Region


    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKhdm.KeyPress, TxtAddress.KeyPress, TxtPostCode.KeyPress, TxtTel.KeyPress, TxtMobile.KeyPress, TxtLxr.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return), Chr(Keys.Down)
                SendKeys.Send("{TAB}")
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
            Case Chr(Keys.Up)
                SendKeys.Send("+{TAB}")
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
        End Select
    End Sub

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

    Private Sub SetAll(ByVal medit As Boolean)
        If Not medit Then
            Me.TxtKhdm.Enabled = False
            Me.TxtAddress.Enabled = False
            Me.TxtPostCode.Enabled = False
            Me.TxtTel.Enabled = False
            Me.TxtMobile.Enabled = False
            Me.TxtLxr.Enabled = False
            Me.ChbLastTimeBz.Enabled = False
        Else
            Me.TxtKhdm.Enabled = True
            Me.TxtAddress.Enabled = True
            Me.TxtPostCode.Enabled = True
            Me.TxtTel.Enabled = True
            Me.TxtMobile.Enabled = True
            Me.TxtLxr.Enabled = True
            Me.ChbLastTimeBz.Enabled = True
            TxtKhdm.Focus()
        End If
    End Sub

#Region "������ĩ"

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
        Me.TxtKhdm.Enabled = False
    End Sub

#End Region

#Region "����"
    Private Sub TsSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MnuiSave.Click
        SaveEvent()
    End Sub

    Private Sub SaveEvent()
        '����
        If isAdding Then
            If Trim(Me.TxtKhdm.Text).Length = 0 Then
                Return
            End If
            'REM ���ӱ���
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "SELECT Coalesce(Max(xh),0.0) As xh FROM oe_khshdz WHERE khdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKhdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("khxh") IsNot Nothing Then
                    rcDataset.Tables("khxh").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "khxh")
                If rcDataset.Tables("khxh").Rows.Count > 0 Then
                    Me.TxtXh.Text = rcDataset.Tables("khxh").Rows(0).Item("xh") + 1
                Else
                    Me.TxtXh.Text = 1
                End If
                If Me.ChbLastTimeBz.Checked Then
                    rcOleDbCommand.CommandText = "UPDATE oe_khshdz Set lasttimebz = 0 WHERE khdm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKhdm.Text)
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "INSERT INTO oe_khshdz (khdm,khmc,xh,address,postcode,tel,mobile,lxr,lasttimebz) VALUES (?,?,?,?,?,?,?,?,?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKhdm.Text)
                rcOleDbCommand.Parameters.Add("@khmc", OleDbType.VarChar, 12).Value = Me.LblKhmc.Text
                rcOleDbCommand.Parameters.Add("@xh", OleDbType.Numeric, 4).Value = Int(Me.TxtXh.Text)
                rcOleDbCommand.Parameters.Add("@address", OleDbType.VarChar, 200).Value = Trim(Me.TxtAddress.Text)
                rcOleDbCommand.Parameters.Add("@postcode", OleDbType.VarChar, 6).Value = Trim(Me.TxtPostCode.Text)
                rcOleDbCommand.Parameters.Add("@tel", OleDbType.VarChar, 40).Value = Trim(Me.TxtTel.Text)
                rcOleDbCommand.Parameters.Add("@mobile", OleDbType.VarChar, 12).Value = Trim(Me.TxtMobile.Text)
                rcOleDbCommand.Parameters.Add("@lxr", OleDbType.VarChar, 20).Value = Trim(Me.TxtLxr.Text)
                rcOleDbCommand.Parameters.Add("@lasttimebz", OleDbType.Numeric, 1).Value = IIf(Me.ChbLastTimeBz.Checked, 1, 0)
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "SELECT * FROM oe_khshdz ORDER BY oe_khshdz.khdm,oe_khshdz.xh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("oe_khshdz") IsNot Nothing Then
                    rcDataset.Tables("oe_khshdz").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "oe_khshdz")
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Catch ey As OleDbException
                    MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
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
                rcOleDbCommand.CommandText = "UPDATE oe_khshdz SET address = ?, postcode = ?, tel = ?, mobile = ?, lxr=?, lasttimebz = ? WHERE khdm = ? AND xh = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@address", OleDbType.VarChar, 200).Value = Trim(Me.TxtAddress.Text)
                rcOleDbCommand.Parameters.Add("@postcode", OleDbType.VarChar, 6).Value = Trim(Me.TxtPostCode.Text)
                rcOleDbCommand.Parameters.Add("@tel", OleDbType.VarChar, 40).Value = Trim(Me.TxtTel.Text)
                rcOleDbCommand.Parameters.Add("@mobile", OleDbType.VarChar, 12).Value = Trim(Me.TxtMobile.Text)
                rcOleDbCommand.Parameters.Add("@lxr", OleDbType.VarChar, 20).Value = Trim(Me.TxtLxr.Text)
                rcOleDbCommand.Parameters.Add("@lasttimebz", OleDbType.Numeric, 1).Value = IIf(Me.ChbLastTimeBz.Checked, 1, 0)
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKhdm.Text)
                rcOleDbCommand.Parameters.Add("@xh", OleDbType.Numeric, 4).Value = Int(Me.TxtXh.Text)
                rcOleDbCommand.ExecuteNonQuery()
                '�������
                rcOleDbCommand.CommandText = "SELECT * FROM oe_khshdz ORDER BY oe_khshdz.khdm,oe_khshdz.xh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("oe_khshdz") IsNot Nothing Then
                    rcDataset.Tables("oe_khshdz").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "oe_khshdz")
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Catch ey As OleDbException
                    MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        End If
        BindingContext(rcDataView, "").Position = currentPos
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
            rcOleDbCommand.CommandText = "SELECT * FROM oe_khshdz ORDER BY oe_khshdz.khdm,oe_khshdz.xh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("oe_khshdz") IsNot Nothing Then
                rcDataset.Tables("oe_khshdz").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "oe_khshdz")
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Catch ey As OleDbException
                MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        BindingContext(rcDataView, "").Position = currentPos
        SetAll(False)
    End Sub

#End Region

#Region "�ر�"

    Private Sub BtnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExit.Click, MnuiExit.Click
        Me.Close()
    End Sub

#End Region

#Region "�P�"

    Private Sub MnuiAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuiAbout.Click
        Dim rcFrm As New FrmAbout
        With rcFrm
            .ShowDialog()
        End With
    End Sub

#End Region
End Class