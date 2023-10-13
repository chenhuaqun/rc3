Imports System.Data.OleDb

Public Class FrmRoleQx

#Region "�������"

    '����OLEDB��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '����OleDb���ݶ���
    Dim rcOleDbTrans As OleDbTransaction
    '����OleDb����
    ReadOnly rcOleDbCommand As OleDbCommand = sysOleDbConn.CreateCommand()
    '����Ա����
    Dim strAccount As String = ""

#End Region

    Public Property paraStrAccount() As String
        Get
            paraStrAccount = strAccount
        End Get
        Set(ByVal Value As String)
            strAccount = Value
        End Set
    End Property

    Private Sub FrmRoleQx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim i As Integer

        Try
            'ȡRC3��rc_menu����()
            sysOleDbConn.Open()
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid in (SELECT code AS mnuiid FROM rc_roleqx WHERE righttype = 'RC3' and roleid = ?) ORDER BY mnuiId"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@roleid", OleDbType.VarChar, 30).Value = strAccount
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("oe_menu") IsNot Nothing Then
                rcDataSet.Tables("oe_menu").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "oe_menu")
        Catch ex As Exception
            MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            sysOleDbConn.Close()
        End Try
        For i = 0 To rcDataSet.Tables("oe_menu").Rows.Count - 1
            ListBoxYixuanRC3.Items.Add(rcDataSet.Tables("oe_menu").Rows(i).Item("mnuiid") & " " & rcDataSet.Tables("oe_menu").Rows(i).Item("mnuicaption"))
        Next
        sysOleDbConn.Open()
        rcOleDbCommand.Connection = sysOleDbConn
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT * FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid not in (SELECT code AS mnuiid FROM rc_roleqx WHERE righttype = 'RC3' and roleid = ?) ORDER BY mnuiId"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@roleid", OleDbType.VarChar, 30).Value = strAccount
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("oe_menu") IsNot Nothing Then
                rcDataSet.Tables("oe_menu").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "oe_menu")
        Catch ex As Exception
            MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            sysOleDbConn.Close()
        End Try
        For i = 0 To rcDataSet.Tables("oe_menu").Rows.Count - 1
            ListBoxYuxuanRC3.Items.Add(rcDataSet.Tables("oe_menu").Rows(i).Item("mnuiid") & " " & rcDataSet.Tables("oe_menu").Rows(i).Item("mnuicaption"))
        Next
    End Sub

    Private Sub ListBoxYuxuanOe_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBoxYuxuanRC3.DoubleClick
        If Me.ListBoxYuxuanRC3.SelectedItem IsNot Nothing Then
            Me.ListBoxYixuanRC3.Items.Add(Me.ListBoxYuxuanRC3.SelectedItem)
            Me.ListBoxYuxuanRC3.Items.Remove(Me.ListBoxYuxuanRC3.SelectedItem)
        End If
    End Sub

    Private Sub ListBoxYixuanOe_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBoxYixuanRC3.DoubleClick
        If Me.ListBoxYixuanRC3.SelectedItem IsNot Nothing Then
            Me.ListBoxYuxuanRC3.Items.Add(Me.ListBoxYixuanRC3.SelectedItem)
            Me.ListBoxYixuanRC3.Items.Remove(Me.ListBoxYixuanRC3.SelectedItem)
        End If
    End Sub

    Private Sub BtnSelectAllOe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectAllRC3.Click
        Dim i As Integer
        For i = 0 To Me.ListBoxYuxuanRC3.Items.Count - 1
            Me.ListBoxYixuanRC3.Items.Add(Me.ListBoxYuxuanRC3.Items(0))
            Me.ListBoxYuxuanRC3.Items.Remove(Me.ListBoxYuxuanRC3.Items(0))
        Next
    End Sub

    Private Sub BtnSelectOneOe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectOneRC3.Click
        If Me.ListBoxYuxuanRC3.SelectedItems.Count > 0 Then
            Me.ListBoxYixuanRC3.Items.Add(Me.ListBoxYuxuanRC3.SelectedItem)
            Me.ListBoxYuxuanRC3.Items.Remove(Me.ListBoxYuxuanRC3.SelectedItem)
        End If
    End Sub

    Private Sub BtnUnSelectOneOe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUnSelectOneRC3.Click
        If Me.ListBoxYixuanRC3.SelectedItems.Count > 0 Then
            Me.ListBoxYuxuanRC3.Items.Add(Me.ListBoxYixuanRC3.SelectedItem)
            Me.ListBoxYixuanRC3.Items.Remove(Me.ListBoxYixuanRC3.SelectedItem)
        End If
    End Sub

    Private Sub BtnUnSelectAllOe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUnSelectAllRC3.Click
        Dim i As Integer
        For i = 0 To Me.ListBoxYixuanRC3.Items.Count - 1
            Me.ListBoxYuxuanRC3.Items.Add(Me.ListBoxYixuanRC3.Items(0))
            Me.ListBoxYixuanRC3.Items.Remove(Me.ListBoxYixuanRC3.Items(0))
        Next
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim i As Integer
        'ɾ������
        sysOleDbConn.Open()
        rcOleDbTrans = sysOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
        rcOleDbCommand.Connection = sysOleDbConn
        rcOleDbCommand.CommandType = CommandType.Text
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        Try
            rcOleDbCommand.CommandText = "DELETE FROM rc_roleqx WHERE roleid = ? AND righttype = 'RC3'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@roleid", OleDbType.VarChar, 30).Value = strAccount
            rcOleDbCommand.ExecuteNonQuery()
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
            sysOleDbConn.Close()
        End Try
        '��ӿ�������Ȩ��
        For i = 0 To Me.ListBoxYixuanRC3.Items.Count - 1
            sysOleDbConn.Open()
            rcOleDbTrans = sysOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            Try
                rcOleDbCommand.CommandText = "INSERT INTO rc_roleqx (roleid,code,righttype) VALUES (?,?,'RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@roleid", OleDbType.VarChar, 30).Value = strAccount
                rcOleDbCommand.Parameters.Add("@code", OleDbType.VarChar, 20).Value = Mid(Me.ListBoxYixuanRC3.Items(i), 1, InStr(Me.ListBoxYixuanRC3.Items(i), " ") - 1)
                rcOleDbCommand.ExecuteNonQuery()
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
                sysOleDbConn.Close()
            End Try
        Next
    End Sub
End Class