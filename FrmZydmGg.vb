Imports System.Data.OleDb

Public Class FrmZydmGg
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '��ʾҪ������Դִ�е� SQL ����
    Dim rcOleDbTrans As OleDbTransaction
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Private Sub FrmZydmGg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TxtOldZydm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtOldZydm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_zyxx"
                    .paraField1 = "zydm"
                    .paraField2 = "zymc"
                    .paraField3 = "zysm"
                    .paraCondition = "0=0"
                    .paraOrderField = "zymc"
                    .paraTitle = "ְԱ"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtOldZydm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Return, Keys.Down
                Me.TxtNewZydm.Focus()
            Case Keys.Up
                Me.BtnHelp.Focus()
        End Select
    End Sub

    Private Sub TxtNewZydm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNewZydm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_zyxx"
                    .paraField1 = "zydm"
                    .paraField2 = "zymc"
                    .paraField3 = "zysm"
                    .paraCondition = "0=0"
                    .paraOrderField = "zymc"
                    .paraTitle = "ְԱ"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtNewZydm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Return, Keys.Down
                Me.BtnOk.Focus()
            Case Keys.Up
                Me.TxtOldZydm.Focus()
        End Select
    End Sub

    Private Sub TxtOldZydm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtOldZydm.Validating
        If Not String.IsNullOrEmpty(Me.TxtOldZydm.Text) Then
            '��ȡ����
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT  *  From rc_zyxx Where zydm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(Me.TxtOldZydm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("oldcsxx") IsNot Nothing Then
                    rcDataSet.Tables("oldcsxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "oldcsxx")
            Catch ex As Exception
                MsgBox("�������1��" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("oldcsxx").Rows.Count > 0 Then
                If rcDataSet.Tables("oldcsxx").Rows(0).Item("zymc").GetType.ToString <> "System.DBNull" Then
                    TxtOldZymc.Text = rcDataSet.Tables("oldcsxx").Rows(0).Item("zymc")
                End If
            Else
                MsgBox("��ְԱ���벻���ڡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                TxtOldZydm.Focus()
            End If
        End If
    End Sub

    Private Sub TxtNewZydm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNewZydm.Validating
        If Not String.IsNullOrEmpty(Me.TxtNewZydm.Text) Then
            '��ȡ����
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "SELECT  *  From rc_zyxx Where zydm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(Me.TxtNewZydm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("newcsxx") IsNot Nothing Then
                    rcDataSet.Tables("newcsxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "newcsxx")
            Catch ex As Exception
                MsgBox("�������2��" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("newcsxx").Rows.Count > 0 Then
                If rcDataSet.Tables("newcsxx").Rows(0).Item("zymc").GetType.ToString <> "System.DBNull" Then
                    TxtNewZymc.Text = rcDataSet.Tables("newcsxx").Rows(0).Item("zymc")
                End If
            Else
                Me.TxtNewZymc.Text = Me.TxtOldZymc.Text
            End If
        End If
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim i As Integer
        If rcDataSet.Tables("newcsxx") Is Nothing Then
            Return
        End If
        If rcDataSet.Tables("oldcsxx") Is Nothing Then
            Return
        End If
        'ͬһ�����򷵻�
        If Me.TxtOldZydm.Text = Me.TxtNewZydm.Text Then
            MsgBox("ְԱ������ͬ������Ҫ���ġ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            Return
        End If
        If rcDataSet.Tables("newcsxx").Rows.Count > 0 Then
            If Not MsgBox("��ְԱ�����Ѿ����ڡ����Ƿ�Ҫ�ϲ�ְԱ���룿", MsgBoxStyle.YesNo + MsgBoxStyle.Information + MsgBoxStyle.DefaultButton2, "��ʾ��Ϣ") = MsgBoxResult.Yes Then
                TxtNewZydm.Text = ""
                TxtNewZymc.Text = ""
                TxtNewZydm.Focus()
                Return
            End If
        End If
        '���濪ʼ���ı���
        '��ȡ����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            'ȡ��zydm�ֶεı�
            rcOleDbCommand.CommandText = "SELECT table_name,column_name FROM user_tab_columns WHERE column_name = 'ZYDM' AND table_name <> 'RC_ZYXX'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("user_tab_columns") IsNot Nothing Then
                rcDataSet.Tables("user_tab_columns").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "user_tab_columns")
        Catch ex As Exception
            MsgBox("�������10��" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            For i = 0 To rcDataSet.Tables("user_tab_columns").Rows.Count - 1
                rcOleDbCommand.CommandText = "UPDATE " & rcDataSet.Tables("user_tab_columns").Rows(i).Item("table_name") & " SET zydm = ? WHERE zydm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(TxtNewZydm.Text)
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(TxtOldZydm.Text)
                rcOleDbCommand.ExecuteNonQuery()
            Next
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("�������15��" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Catch ey As OleDbException
                MsgBox("�������16��" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        'ZYDM1
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            'ȡ��zydm�ֶεı�
            rcOleDbCommand.CommandText = "SELECT table_name,column_name FROM user_tab_columns WHERE column_name = 'ZYDM1' AND table_name <> 'RC_ZYXX'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("user_tab_columns") IsNot Nothing Then
                rcDataSet.Tables("user_tab_columns").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "user_tab_columns")
        Catch ex As Exception
            MsgBox("�������10��" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            For i = 0 To rcDataSet.Tables("user_tab_columns").Rows.Count - 1
                rcOleDbCommand.CommandText = "UPDATE " & rcDataSet.Tables("user_tab_columns").Rows(i).Item("table_name") & " SET zydm1 = ? WHERE zydm1 = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@zydm1", OleDbType.VarChar, 12).Value = Trim(TxtNewZydm.Text)
                rcOleDbCommand.Parameters.Add("@zydm1", OleDbType.VarChar, 12).Value = Trim(TxtOldZydm.Text)
                rcOleDbCommand.ExecuteNonQuery()
            Next
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("�������15��" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Catch ey As OleDbException
                MsgBox("�������16��" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        'zydm2
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            'ȡ��zydm�ֶεı�
            rcOleDbCommand.CommandText = "SELECT table_name,column_name FROM user_tab_columns WHERE column_name = 'ZYDM2' AND table_name <> 'RC_ZYXX'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("user_tab_columns") IsNot Nothing Then
                rcDataSet.Tables("user_tab_columns").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "user_tab_columns")
        Catch ex As Exception
            MsgBox("�������10��" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            For i = 0 To rcDataSet.Tables("user_tab_columns").Rows.Count - 1
                rcOleDbCommand.CommandText = "UPDATE " & rcDataSet.Tables("user_tab_columns").Rows(i).Item("table_name") & " SET zydm2 = ? WHERE zydm2 = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@zydm2", OleDbType.VarChar, 12).Value = Trim(TxtNewZydm.Text)
                rcOleDbCommand.Parameters.Add("@zydm2", OleDbType.VarChar, 12).Value = Trim(TxtOldZydm.Text)
                rcOleDbCommand.ExecuteNonQuery()
            Next
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("�������15��" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Catch ey As OleDbException
                MsgBox("�������16��" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try

        '(12)rc_zyxx(��Ҫɾ��/�����)
        If rcDataSet.Tables("newcsxx").Rows.Count > 0 Then
            'ɾ���ɱ���
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "DELETE From rc_zyxx Where zydm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(Me.TxtOldZydm.Text)
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("�������17��" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Catch ey As OleDbException
                    MsgBox("�������18��" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        Else
            '���ľɱ���
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "UPDATE rc_zyxx SET zydm = ? WHERE zydm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(Me.TxtNewZydm.Text)
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(Me.TxtOldZydm.Text)
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("�������19��" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Catch ey As OleDbException
                    MsgBox("�������20��" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        End If
        '(13)��¼���Ļ�ϲ���¼
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "INSERT INTO rc_zydmtz (tzrq,oldzydm,oldzymc,newzydm,newzymc,ynhb,srr) VALUES (?,?,?,?,?,?,?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@tzrq", OleDbType.Date, 8).Value = Now.Date
            rcOleDbCommand.Parameters.Add("@oldzydm", OleDbType.VarChar, 12).Value = Me.TxtOldZydm.Text
            rcOleDbCommand.Parameters.Add("@oldzymc", OleDbType.VarChar, 40).Value = Me.TxtOldZymc.Text
            rcOleDbCommand.Parameters.Add("@newzydm", OleDbType.VarChar, 12).Value = Me.TxtNewZydm.Text
            rcOleDbCommand.Parameters.Add("@newzymc", OleDbType.VarChar, 40).Value = Me.TxtNewZymc.Text
            If rcDataSet.Tables("newcsxx").Rows.Count > 0 Then
                rcOleDbCommand.Parameters.Add("@ynhb", OleDbType.VarNumeric, 1).Value = 1
            Else
                rcOleDbCommand.Parameters.Add("@ynhb", OleDbType.VarNumeric, 1).Value = 0
            End If
            rcOleDbCommand.Parameters.Add("@srr", OleDbType.VarChar, 10).Value = g_User_DspName
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("�������21��" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Catch ey As OleDbException
                MsgBox("�������22��" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        MsgBox("������ϲ�ְԱ������ɡ�" & Chr(13) & "��������������Ӧ�ա�Ӧ���ȵ�������ȷ�ԡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
        Me.TxtOldZydm.Text = ""
        Me.TxtNewZydm.Text = ""
        Me.TxtOldZymc.Text = ""
        Me.TxtNewZymc.Text = ""
        Me.TxtOldZydm.Focus()
    End Sub

End Class