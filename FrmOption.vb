Imports System.Data.OleDb

Public Class FrmOption
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '���ݸ��´���
    Dim rcOleDbTrans As OleDbTransaction
    '����OleDbCommand
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Private Sub FrmOption_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'ȡ������������
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc From rc_lx Where lxgs = '����ƾ֤' AND kjnd = ? ORDER BY pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@year", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_lx") IsNot Nothing Then
                Me.rcDataset.Tables("rc_lx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_lx")
        Catch ex As Exception
            MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_lx").Rows.Count = 0 Then
            MsgBox("�붨�嵥�����͡�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        '��ƾ֤���ͼ��
        BindDropDownList(CmbPzlxjc, rcDataset.Tables("rc_lx"), "pzlxdm", "pzlxjc")
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT paradblvalue FROM rc_para WHERE dwdm = ? AND paraid = '��ֵ˰Ĭ��˰��' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("paradblvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtDefaultShlv.Text = rcDataset.Tables("rc_para").Rows(0).Item("paradblvalue")
                End If
            End If
            rcOleDbCommand.CommandText = "SELECT parastrvalue FROM rc_para WHERE dwdm = ? AND paraid = '���ݴ�ӡ��̧ͷʹ�õĵ�λ����' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TextBox3.Text = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
            End If
            rcOleDbCommand.CommandText = "SELECT parastrvalue FROM rc_para WHERE dwdm = ? AND paraid = '����Ӧ���˿��Ŀ����' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtYszk.Text = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
            End If
            rcOleDbCommand.CommandText = "SELECT parastrvalue FROM rc_para WHERE dwdm = ? AND paraid = '����Ӧ���˿��Ŀ����' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtYfzk.Text = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
            End If
            rcOleDbCommand.CommandText = "SELECT parastrvalue FROM rc_para WHERE dwdm = ? AND paraid = '������Ӫҵ�������Ŀ����' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtZyywsr.Text = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
            End If
            rcOleDbCommand.CommandText = "SELECT parastrvalue FROM rc_para WHERE dwdm = ? AND paraid = '������Ӫҵ��ɱ���Ŀ����' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtZyywcb.Text = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
            End If
            rcOleDbCommand.CommandText = "SELECT parastrvalue FROM rc_para WHERE dwdm = ? AND paraid = '����ԭ���Ͽ�Ŀ����' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtYcl.Text = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
            End If
            rcOleDbCommand.CommandText = "SELECT parastrvalue FROM rc_para WHERE dwdm = ? AND paraid = '���˿����Ʒ��Ŀ����' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtKcsp.Text = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
            End If
            rcOleDbCommand.CommandText = "SELECT parastrvalue FROM rc_para WHERE dwdm = ? AND paraid = '���������ɱ���Ŀ����' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtSccb.Text = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
            End If
            rcOleDbCommand.CommandText = "SELECT parastrvalue FROM rc_para WHERE dwdm = ? AND paraid = 'ƾ֤������ʹ�õ�ƾ֤����' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.CmbPzlxjc.SelectedValue = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
            End If
            rcOleDbCommand.CommandText = "SELECT paradblvalue FROM rc_para WHERE dwdm = ? AND paraid = '�״��ʽ��ӡ���۵�' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("paradblvalue").GetType.ToString <> "System.DBNull" Then
                    Me.ChbXsdDy.Checked = rcDataset.Tables("rc_para").Rows(0).Item("paradblvalue")
                End If
            End If
            rcOleDbCommand.CommandText = "SELECT parastrvalue FROM rc_para WHERE dwdm = ? AND paraid = 'Anyi311����ϵͳ·��' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtGlPath.Text = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
            End If
            rcOleDbCommand.CommandText = "SELECT * FROM rc_para Where dwdm = ? And (paraid = 'NCACCOUNTINGBOOK' or paraid = 'NCHOST' or paraid = 'NCSERVICE_NAME' or paraid = 'NCUser_ID' or paraid = 'NCPASSWORD') ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 5 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtNCAccountingBook.Text = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtNCHost.Text = rcDataset.Tables("rc_para").Rows(1).Item("parastrvalue")
                End If
                If rcDataset.Tables("rc_para").Rows(1).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtNCPwd.Text = rcDataset.Tables("rc_para").Rows(2).Item("parastrvalue")
                End If
                If rcDataset.Tables("rc_para").Rows(2).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtNCService_Name.Text = rcDataset.Tables("rc_para").Rows(3).Item("parastrvalue")
                End If
                If rcDataset.Tables("rc_para").Rows(3).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtNCUser_ID.Text = rcDataset.Tables("rc_para").Rows(4).Item("parastrvalue")
                End If
            End If
            rcOleDbCommand.CommandText = "SELECT * FROM rc_para Where dwdm = ? And (paraid = 'U8Acc_ID' or paraid = 'U8HOST' or paraid = 'U8User_ID' or paraid = 'U8PASSWORD') ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 5 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtU8Acc_ID.Text = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtU8Host.Text = rcDataset.Tables("rc_para").Rows(1).Item("parastrvalue")
                End If
                If rcDataset.Tables("rc_para").Rows(1).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtU8Pwd.Text = rcDataset.Tables("rc_para").Rows(2).Item("parastrvalue")
                End If
                If rcDataset.Tables("rc_para").Rows(3).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtU8User_ID.Text = rcDataset.Tables("rc_para").Rows(4).Item("parastrvalue")
                End If
            End If
            rcOleDbCommand.CommandText = "SELECT paradblvalue FROM rc_para WHERE dwdm = ? AND paraid = '�Ƿ񰴳ɱ������ɱ�' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("paradblvalue").GetType.ToString <> "System.DBNull" Then
                    Me.ChbCostRegion.Checked = rcDataset.Tables("rc_para").Rows(0).Item("paradblvalue")
                End If
            End If
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message)
            Return
        Finally
            rcOleDbConn.Close()
        End Try
    End Sub


#Region "Ӧ���˿��Ŀ������¼�"

    Private Sub TxtYszk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtYszk.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "gl_kmxx"
                    .paraField1 = "kmdm"
                    .paraField2 = "kmmc"
                    .paraField3 = "kmsm"
                    .paraCondition = "0=0"
                    .paraOrderField = "kmdm"
                    .paraTitle = "��Ŀ"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtYszk.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtYszk_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtYszk.Validating
        If Not String.IsNullOrEmpty(Me.TxtYszk.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM gl_kmxx WHERE (kmdm = ?) AND NOT EXISTS (SELECT 1 FROM gl_kmxx aa WHERE aa.parentid = gl_kmxx.kmdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtYszk.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("gl_kmxx") IsNot Nothing Then
                    Me.rcDataset.Tables("gl_kmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "gl_kmxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("gl_kmxx").Rows.Count > 0 Then
                TxtYszk.Text = Trim(rcDataset.Tables("gl_kmxx").Rows(0).Item("kmdm"))
            Else
                MsgBox("��Ŀ���벻���ڻ����ϸ��Ŀ��", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                e.Cancel = True
                Return
            End If
        End If
    End Sub

#End Region

#Region "Ӧ���˿��Ŀ������¼�"

    Private Sub TxtYfzk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtYfzk.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "gl_kmxx"
                    .paraField1 = "kmdm"
                    .paraField2 = "kmmc"
                    .paraField3 = "kmsm"
                    .paraCondition = "0=0"
                    .paraOrderField = "kmdm"
                    .paraTitle = "��Ŀ"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtYfzk.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtYfzk_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtYfzk.Validating
        If Not String.IsNullOrEmpty(Me.TxtYfzk.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM gl_kmxx WHERE (kmdm = ?) AND NOT EXISTS (SELECT 1 FROM gl_kmxx aa WHERE aa.parentid = gl_kmxx.kmdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtYfzk.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("gl_kmxx") IsNot Nothing Then
                    Me.rcDataset.Tables("gl_kmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "gl_kmxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("gl_kmxx").Rows.Count > 0 Then
                TxtYfzk.Text = Trim(rcDataset.Tables("gl_kmxx").Rows(0).Item("kmdm"))
            Else
                MsgBox("��Ŀ���벻���ڻ����ϸ��Ŀ��", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                e.Cancel = True
                Return
            End If
        End If
    End Sub

#End Region

#Region "��Ӫҵ�������Ŀ������¼�"

    Private Sub TxtZyywsr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtZyywsr.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "gl_kmxx"
                    .paraField1 = "kmdm"
                    .paraField2 = "kmmc"
                    .paraField3 = "kmsm"
                    .paraCondition = "0=0"
                    .paraOrderField = "kmdm"
                    .paraTitle = "��Ŀ"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtZyywsr.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtZyywsr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtZyywsr.Validating
        If Not String.IsNullOrEmpty(Me.TxtZyywsr.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM gl_kmxx WHERE (kmdm = ?) AND NOT EXISTS (SELECT 1 FROM gl_kmxx aa WHERE aa.parentid = gl_kmxx.kmdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtZyywsr.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("gl_kmxx") IsNot Nothing Then
                    Me.rcDataset.Tables("gl_kmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "gl_kmxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("gl_kmxx").Rows.Count > 0 Then
                TxtZyywsr.Text = Trim(rcDataset.Tables("gl_kmxx").Rows(0).Item("kmdm"))
            Else
                MsgBox("��Ŀ���벻���ڻ����ϸ��Ŀ��", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                e.Cancel = True
                Return
            End If
        End If
    End Sub

#End Region

#Region "��Ӫҵ��ɱ���Ŀ������¼�"

    Private Sub TxtZyywcb_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtZyywcb.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "gl_kmxx"
                    .paraField1 = "kmdm"
                    .paraField2 = "kmmc"
                    .paraField3 = "kmsm"
                    .paraCondition = "0=0"
                    .paraOrderField = "kmdm"
                    .paraTitle = "��Ŀ"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtZyywcb.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtZyywcb_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtZyywcb.Validating
        If Not String.IsNullOrEmpty(Me.TxtZyywcb.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM gl_kmxx WHERE (kmdm = ?) AND NOT EXISTS (SELECT 1 FROM gl_kmxx aa WHERE aa.parentid = gl_kmxx.kmdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtZyywcb.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("gl_kmxx") IsNot Nothing Then
                    Me.rcDataset.Tables("gl_kmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "gl_kmxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("gl_kmxx").Rows.Count > 0 Then
                TxtZyywcb.Text = Trim(rcDataset.Tables("gl_kmxx").Rows(0).Item("kmdm"))
            Else
                MsgBox("��Ŀ���벻���ڻ����ϸ��Ŀ��", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                e.Cancel = True
                Return
            End If
        End If
    End Sub

#End Region

#Region "ԭ���Ͽ�Ŀ������¼�"

    Private Sub TxtYcl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtYcl.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "gl_kmxx"
                    .paraField1 = "kmdm"
                    .paraField2 = "kmmc"
                    .paraField3 = "kmsm"
                    .paraCondition = "0=0"
                    .paraOrderField = "kmdm"
                    .paraTitle = "��Ŀ"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtYcl.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtYcl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtYcl.Validating
        If Not String.IsNullOrEmpty(Me.TxtYcl.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM gl_kmxx WHERE (kmdm = ?) AND NOT EXISTS (SELECT 1 FROM gl_kmxx aa WHERE aa.parentid = gl_kmxx.kmdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtYcl.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("gl_kmxx") IsNot Nothing Then
                    Me.rcDataset.Tables("gl_kmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "gl_kmxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("gl_kmxx").Rows.Count > 0 Then
                TxtYcl.Text = Trim(rcDataset.Tables("gl_kmxx").Rows(0).Item("kmdm"))
            Else
                MsgBox("��Ŀ���벻���ڻ����ϸ��Ŀ��", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                e.Cancel = True
                Return
            End If
        End If
    End Sub

#End Region

#Region "�����Ʒ��Ŀ������¼�"

    Private Sub TxtKcsp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtKcsp.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "gl_kmxx"
                    .paraField1 = "kmdm"
                    .paraField2 = "kmmc"
                    .paraField3 = "kmsm"
                    .paraCondition = "0=0"
                    .paraOrderField = "kmdm"
                    .paraTitle = "��Ŀ"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtKcsp.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtKcsp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtKcsp.Validating
        If Not String.IsNullOrEmpty(Me.TxtKcsp.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM gl_kmxx WHERE (kmdm = ?) AND NOT EXISTS (SELECT 1 FROM gl_kmxx aa WHERE aa.parentid = gl_kmxx.kmdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKcsp.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("gl_kmxx") IsNot Nothing Then
                    Me.rcDataset.Tables("gl_kmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "gl_kmxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("gl_kmxx").Rows.Count > 0 Then
                TxtKcsp.Text = Trim(rcDataset.Tables("gl_kmxx").Rows(0).Item("kmdm"))
            Else
                MsgBox("��Ŀ���벻���ڻ����ϸ��Ŀ��", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                e.Cancel = True
                Return
            End If
        End If
    End Sub

#End Region

#Region "�����ɱ���Ŀ������¼�"

    Private Sub TxtSccb_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSccb.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "gl_kmxx"
                    .paraField1 = "kmdm"
                    .paraField2 = "kmmc"
                    .paraField3 = "kmsm"
                    .paraCondition = "0=0"
                    .paraOrderField = "kmdm"
                    .paraTitle = "��Ŀ"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtSccb.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtSccb_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtSccb.Validating
        If Not String.IsNullOrEmpty(Me.TxtSccb.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM gl_kmxx WHERE (kmdm = ?) AND NOT EXISTS (SELECT 1 FROM gl_kmxx aa WHERE aa.parentid = gl_kmxx.kmdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtSccb.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("gl_kmxx") IsNot Nothing Then
                    Me.rcDataset.Tables("gl_kmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "gl_kmxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("gl_kmxx").Rows.Count > 0 Then
                TxtSccb.Text = Trim(rcDataset.Tables("gl_kmxx").Rows(0).Item("kmdm"))
            Else
                MsgBox("��Ŀ���벻���ڻ����ϸ��Ŀ��", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                e.Cancel = True
                Return
            End If
        End If
    End Sub

#End Region

    Private Sub BtnFbd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFbd.Click
        If Me.rcFolderBrowserDialog.ShowDialog() = DialogResult.OK Then
            Me.TxtGlPath.Text = Me.rcFolderBrowserDialog.SelectedPath
        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        'дϵͳ����
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            If Not String.IsNullOrEmpty(Me.TxtDefaultShlv.Text) Then
                'ɾ������
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = '��ֵ˰Ĭ��˰��'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '��������
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'��ֵ˰Ĭ��˰��','',?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarNumeric, 14).Value = Trim(Me.TxtDefaultShlv.Text)
                rcOleDbCommand.ExecuteNonQuery()
            End If
            If Not String.IsNullOrEmpty(Me.TextBox3.Text) Then
                'ɾ������
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = '���ݴ�ӡ��̧ͷʹ�õĵ�λ����'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '��������
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'���ݴ�ӡ��̧ͷʹ�õĵ�λ����',?,0.0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 30).Value = Trim(Me.TextBox3.Text)
                rcOleDbCommand.ExecuteNonQuery()
                g_PrnDwmc = Me.TextBox3.Text
            End If
            If Not String.IsNullOrEmpty(Me.TxtYszk.Text) Then
                'ɾ������
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = '����Ӧ���˿��Ŀ����'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '��������
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'����Ӧ���˿��Ŀ����',?,0.0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 30).Value = Trim(Me.TxtYszk.Text)
                rcOleDbCommand.ExecuteNonQuery()
            End If
            If Not String.IsNullOrEmpty(Me.TxtYfzk.Text) Then
                'ɾ������
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = '����Ӧ���˿��Ŀ����'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '��������
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'����Ӧ���˿��Ŀ����',?,0.0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 30).Value = Trim(Me.TxtYfzk.Text)
                rcOleDbCommand.ExecuteNonQuery()
            End If
            If Not String.IsNullOrEmpty(Me.TxtZyywsr.Text) Then
                'ɾ������
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = '������Ӫҵ�������Ŀ����'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '��������
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'������Ӫҵ�������Ŀ����',?,0.0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 30).Value = Trim(Me.TxtZyywsr.Text)
                rcOleDbCommand.ExecuteNonQuery()
            End If
            If Not String.IsNullOrEmpty(Me.TxtZyywcb.Text) Then
                'ɾ������
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = '������Ӫҵ��ɱ���Ŀ����'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '��������
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'������Ӫҵ��ɱ���Ŀ����',?,0.0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 30).Value = Trim(Me.TxtZyywcb.Text)
                rcOleDbCommand.ExecuteNonQuery()
            End If
            If Not String.IsNullOrEmpty(Me.TxtYcl.Text) Then
                'ɾ������
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = '����ԭ���Ͽ�Ŀ����'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '��������
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'����ԭ���Ͽ�Ŀ����',?,0.0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 30).Value = Trim(Me.TxtYcl.Text)
                rcOleDbCommand.ExecuteNonQuery()
            End If
            If Not String.IsNullOrEmpty(Me.TxtKcsp.Text) Then
                'ɾ������
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = '���˿����Ʒ��Ŀ����'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '��������
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'���˿����Ʒ��Ŀ����',?,0.0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 30).Value = Trim(Me.TxtKcsp.Text)
                rcOleDbCommand.ExecuteNonQuery()
            End If
            If Not String.IsNullOrEmpty(Me.TxtSccb.Text) Then
                'ɾ������
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = '���������ɱ���Ŀ����'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '��������
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'���������ɱ���Ŀ����',?,0.0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 30).Value = Trim(Me.TxtSccb.Text)
                rcOleDbCommand.ExecuteNonQuery()
            End If
            If Not String.IsNullOrEmpty(Me.CmbPzlxjc.SelectedValue) Then
                'ɾ������
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = 'ƾ֤������ʹ�õ�ƾ֤����'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '��������
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'ƾ֤������ʹ�õ�ƾ֤����',?,0.0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 30).Value = Me.CmbPzlxjc.SelectedValue
                rcOleDbCommand.ExecuteNonQuery()
            End If
            If Not String.IsNullOrEmpty(Me.CmbPzlxjc.SelectedValue) Then
                'ɾ������
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = '�״��ʽ��ӡ���۵�'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '��������
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'�״��ʽ��ӡ���۵�','',?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraDblValue", OleDbType.Numeric, 1).Value = Me.ChbXsdDy.Checked
                rcOleDbCommand.ExecuteNonQuery()
            End If
            If Not String.IsNullOrEmpty(Me.TxtGlPath.Text) Then
                'ɾ������
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = 'Anyi311����ϵͳ·��'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '��������
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'Anyi311����ϵͳ·��',?,0.0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 30).Value = Trim(Me.TxtGlPath.Text)
                rcOleDbCommand.ExecuteNonQuery()
            End If
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("�������" & Chr(13) & ex.Message)
            Catch ey As OleDbException
                MsgBox("�������" & Chr(13) & ey.Message)
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Me.Close()
    End Sub

    Private Sub BtnNCSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNCSave.Click
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            'ɾ������
            rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? And (paraid = 'NCACCOUNTINGBOOK' OR paraid = 'NCHOST' OR paraid = 'NCSERVICE_NAME' OR paraid = 'NCUser_ID' OR paraid = 'NCPASSWORD')"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbCommand.ExecuteNonQuery()
            '��������
            rcOleDbCommand.CommandText = "INSERT INTO rc_para (paraid,parastrvalue,paradblvalue,dwdm) VALUES ('NCACCOUNTINGBOOK',?,0.0,?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 20).Value = Trim(Me.TxtNCAccountingBook.Text)
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "INSERT INTO rc_para (paraid,parastrvalue,paradblvalue,dwdm) VALUES ('NCHOST',?,0.0,?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 20).Value = Trim(Me.TxtNCHost.Text)
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "INSERT INTO rc_para (paraid,parastrvalue,paradblvalue,dwdm) VALUES ('NCSERVICE_NAME',?,0.0,?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 20).Value = Trim(Me.TxtNCService_Name.Text)
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "INSERT INTO rc_para (paraid,parastrvalue,paradblvalue,dwdm) VALUES ('NCUser_ID',?,0.0,?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 20).Value = Trim(Me.TxtNCUser_ID.Text)
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "INSERT INTO rc_para (paraid,parastrvalue,paradblvalue,dwdm) VALUES ('NCPASSWORD',?,0.0,?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 20).Value = Trim(Me.TxtNCPwd.Text)
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("�������" & Chr(13) & ex.Message)
            Catch ey As OleDbException
                MsgBox("�������" & Chr(13) & ey.Message)
            End Try
        Finally
            rcOleDbConn.Close()
        End Try
    End Sub

#Region "U8���㵥λ����"

    Private Sub BtnU8Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnU8Save.Click
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            'ɾ������
            rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? And (paraid = 'U8Acc_ID' OR paraid = 'U8HOST' OR paraid = 'U8User_ID' OR paraid = 'U8PASSWORD')"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbCommand.ExecuteNonQuery()
            '��������
            rcOleDbCommand.CommandText = "INSERT INTO rc_para (paraid,parastrvalue,paradblvalue,dwdm) VALUES ('U8Acc_ID',?,0.0,?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 20).Value = Trim(Me.TxtU8Acc_ID.Text)
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "INSERT INTO rc_para (paraid,parastrvalue,paradblvalue,dwdm) VALUES ('U8HOST',?,0.0,?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 20).Value = Trim(Me.TxtU8Host.Text)
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "INSERT INTO rc_para (paraid,parastrvalue,paradblvalue,dwdm) VALUES ('U8User_ID',?,0.0,?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 20).Value = Trim(Me.TxtU8User_ID.Text)
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "INSERT INTO rc_para (paraid,parastrvalue,paradblvalue,dwdm) VALUES ('U8PASSWORD',?,0.0,?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 20).Value = Trim(Me.TxtU8Pwd.Text)
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("�������" & Chr(13) & ex.Message)
            Catch ey As OleDbException
                MsgBox("�������" & Chr(13) & ey.Message)
            End Try
        Finally
            rcOleDbConn.Close()
        End Try
    End Sub
#End Region

    Private Sub BtnCostRegion_Click(sender As Object, e As EventArgs) Handles BtnCostRegion.Click
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            'ɾ������
            rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? And paraid = '�Ƿ񰴳ɱ������ɱ�'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbCommand.ExecuteNonQuery()
            '��������
            rcOleDbCommand.CommandText = "INSERT INTO rc_para (paraid,parastrvalue,paradblvalue,dwdm) VALUES ('�Ƿ񰴳ɱ������ɱ�','',?,?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.Numeric, 1).Value = IIf(Me.ChbCostRegion.Checked, 1, 0)
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("�������" & Chr(13) & ex.Message)
            Catch ey As OleDbException
                MsgBox("�������" & Chr(13) & ey.Message)
            End Try
        Finally
            rcOleDbConn.Close()
        End Try

    End Sub
End Class