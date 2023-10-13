Imports System.Data.OleDb

Public Class FrmCpdmGg
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '��ʾҪ������Դִ�е� SQL ����
    Dim rcOleDbTrans As OleDbTransaction
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Private Sub FrmCpdmGg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TxtOldCpdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtOldCpdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF34
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_cpxx"
                    .paraField1 = "cpdm"
                    .paraField2 = "cpmc"
                    .paraField3 = "dw"
                    .paraField4 = "cpsm"
                    .paraOrderField = "cpmc"
                    .paraTitle = "����"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtOldCpdm.Text = Trim(.paraField1)
                        TxtOldCpmc.Text = Trim(.paraField2)
                        TxtOldDw.Text = Trim(.paraField3)
                    End If
                End With
            Case Keys.Return, Keys.Down
                Me.TxtNewCpdm.Focus()
            Case Keys.Up
                Me.BtnHelp.Focus()
        End Select
    End Sub

    Private Sub TxtNewCpdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNewCpdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF34
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_cpxx"
                    .paraField1 = "cpdm"
                    .paraField2 = "cpmc"
                    .paraField3 = "dw"
                    .paraField4 = "cpsm"
                    .paraOrderField = "cpmc"
                    .paraTitle = "����"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtNewCpdm.Text = Trim(.paraField1)
                        TxtNewCpmc.Text = Trim(.paraField2)
                        TxtNewDw.Text = Trim(.paraField3)
                    End If
                End With
            Case Keys.Return, Keys.Down
                Me.BtnOk.Focus()
            Case Keys.Up
                Me.TxtOldCpdm.Focus()
        End Select
    End Sub

    Private Sub TxtOldCpdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtOldCpdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtOldCpdm.Text) Then
            '��ȡ����
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT  *  From rc_cpxx Where cpdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(TxtOldCpdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("oldcpxx") IsNot Nothing Then
                    rcDataSet.Tables("oldcpxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "oldcpxx")
            Catch ex As Exception
                MsgBox("�������1��" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("oldcpxx").Rows.Count > 0 Then
                If rcDataSet.Tables("oldcpxx").Rows(0).Item("cpmc").GetType.ToString <> "System.DBNull" Then
                    TxtOldCpmc.Text = rcDataSet.Tables("oldcpxx").Rows(0).Item("cpmc")
                End If
                If rcDataSet.Tables("oldcpxx").Rows(0).Item("dw").GetType.ToString <> "System.DBNull" Then
                    TxtOldDw.Text = rcDataSet.Tables("oldcpxx").Rows(0).Item("dw")
                End If
            Else
                MsgBox("�����ϱ��벻���ڡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                TxtOldCpdm.Focus()
            End If
        End If
    End Sub

    Private Sub TxtNewCpdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNewCpdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtNewCpdm.Text) Then
            '��ȡ����
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "SELECT * From rc_cpxx Where cpdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(TxtNewCpdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("newcpxx") IsNot Nothing Then
                    rcDataSet.Tables("newcpxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "newcpxx")
            Catch ex As Exception
                MsgBox("�������2��" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("newcpxx").Rows.Count > 0 Then
                If rcDataSet.Tables("newcpxx").Rows(0).Item("cpmc").GetType.ToString <> "System.DBNull" Then
                    TxtNewCpmc.Text = rcDataSet.Tables("newcpxx").Rows(0).Item("cpmc")
                End If
                If rcDataSet.Tables("newcpxx").Rows(0).Item("dw").GetType.ToString <> "System.DBNull" Then
                    TxtNewDw.Text = rcDataSet.Tables("newcpxx").Rows(0).Item("dw")
                End If
            Else
                Me.TxtNewCpmc.Text = Me.TxtOldCpmc.Text
                Me.TxtNewDw.Text = Me.TxtOldDw.Text
            End If
        End If
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If rcDataSet.Tables("newcpxx") Is Nothing Then
            Return
        End If
        If rcDataSet.Tables("oldcpxx") Is Nothing Then
            Return
        End If
        'ͬһ�����򷵻�
        If Me.TxtOldCpdm.Text = Me.TxtNewCpdm.Text Then
            MsgBox("���ϱ�����ͬ������Ҫ���ġ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            Return
        End If
        If rcDataSet.Tables("newcpxx").Rows.Count > 0 Then
            If Not MsgBox("�����ϱ����Ѿ����ڡ����Ƿ�Ҫ�ϲ����ϱ��룿", MsgBoxStyle.YesNo + MsgBoxStyle.Information + MsgBoxStyle.DefaultButton2, "��ʾ��Ϣ") = MsgBoxResult.Yes Then
                Me.TxtNewCpdm.Text = ""
                Me.TxtNewCpmc.Text = ""
                Me.TxtNewDw.Text = ""
                Me.TxtNewCpdm.Focus()
                Return
            End If
        End If
        '���濪ʼ���ı���
        '(1)INV_CPYEB(��Ҫ�ϲ�)
        '��ȡ����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT kjnd,ckdm,Sum(Nvl(qcsl,0.0)) as qcsl,Sum(Nvl(qcje,0.0)) as qcje,Sum(Nvl(idsl,0.0)) as idsl,Sum(Nvl(idje,0.0)) as idje FROM inv_cpyeb WHERE (cpdm = ? or cpdm = ?) GROUP BY kjnd,ckdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtNewCpdm.Text)
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtOldCpdm.Text)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("sumcpxx") IsNot Nothing Then
                rcDataSet.Tables("sumcpxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "sumcpxx")
            'ȡ��cpdm�ֶεı�
            rcOleDbCommand.CommandText = "SELECT table_name,column_name FROM user_tab_columns WHERE column_name = 'CPDM' AND table_name <> 'INV_CPYEB' AND table_name <> 'RC_CPXX' AND table_name <> 'PO_CSCPCGDJ'"
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
        Dim i As Integer
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            'ɾ��ԭ��������
            rcOleDbCommand.CommandText = "DELETE FROM inv_cpyeb WHERE (cpdm = ? or cpdm = ?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(TxtNewCpdm.Text)
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(TxtOldCpdm.Text)
            rcOleDbCommand.ExecuteNonQuery()
            '�������
            For i = 0 To rcDataSet.Tables("sumcpxx").Rows.Count - 1
                rcOleDbCommand.CommandText = "INSERT INTO inv_cpyeb (kjnd,cpdm,ckdm,qcsl,qcje,idsl,idje) VALUES (?,?,?,?,?,?,?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Trim(rcDataSet.Tables("sumcpxx").Rows(i).Item("kjnd"))
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(TxtNewCpdm.Text)
                rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("sumcpxx").Rows(i).Item("ckdm")
                rcOleDbCommand.Parameters.Add("@qcsl", OleDbType.VarNumeric, 18).Value = rcDataSet.Tables("sumcpxx").Rows(i).Item("qcsl")
                rcOleDbCommand.Parameters.Add("@qcje", OleDbType.VarNumeric, 14).Value = rcDataSet.Tables("sumcpxx").Rows(i).Item("qcje")
                rcOleDbCommand.Parameters.Add("@idsl", OleDbType.VarNumeric, 18).Value = rcDataSet.Tables("sumcpxx").Rows(i).Item("idsl")
                rcOleDbCommand.Parameters.Add("@idje", OleDbType.VarNumeric, 14).Value = rcDataSet.Tables("sumcpxx").Rows(i).Item("idje")
                rcOleDbCommand.ExecuteNonQuery()
            Next
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("�������13��" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Catch ey As OleDbException
                MsgBox("�������14��" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '����ҵ�������ϱ���
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            For i = 0 To rcDataSet.Tables("user_tab_columns").Rows.Count - 1
                rcOleDbCommand.CommandText = "UPDATE " & rcDataSet.Tables("user_tab_columns").Rows(i).Item("table_name") & " SET cpdm = ? WHERE cpdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(TxtNewCpdm.Text)
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(TxtOldCpdm.Text)
                rcOleDbCommand.ExecuteNonQuery()
            Next
            '(9)PM_BOM(ֱ�Ӹ���)
            rcOleDbCommand.CommandText = "SELECT COUNT(*) AS gs FROM pm_bom WHERE parentcpdm = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@parentcpdm", OleDbType.VarChar, 12).Value = Trim(TxtNewCpdm.Text)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("sumbom") IsNot Nothing Then
                rcDataSet.Tables("sumbom").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "sumbom")
            If rcDataSet.Tables("sumbom").Rows(0).Item("gs") > 0 Then
                'ɾ���ɵ�BOM�嵥
                rcOleDbCommand.CommandText = "DELETE FROM pm_bom WHERE parentcpdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@parentcpdm", OleDbType.VarChar, 12).Value = Trim(TxtOldCpdm.Text)
                rcOleDbCommand.ExecuteNonQuery()
            Else
                rcOleDbCommand.CommandText = "UPDATE pm_bom SET parentcpdm = ? WHERE parentcpdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@parentcpdm", OleDbType.VarChar, 12).Value = Trim(TxtNewCpdm.Text)
                rcOleDbCommand.Parameters.Add("@parentcpdm", OleDbType.VarChar, 12).Value = Trim(TxtOldCpdm.Text)
                rcOleDbCommand.ExecuteNonQuery()
            End If
            rcOleDbCommand.CommandText = "UPDATE pm_bom SET childcpdm = ? WHERE childcpdm = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@childcpdm", OleDbType.VarChar, 12).Value = Trim(TxtNewCpdm.Text)
            rcOleDbCommand.Parameters.Add("@childcpdm", OleDbType.VarChar, 12).Value = Trim(TxtOldCpdm.Text)
            rcOleDbCommand.ExecuteNonQuery()
            '(10)PM_GX(ֱ�Ӹ���)
            rcOleDbCommand.CommandText = "UPDATE pm_gx SET parentcpdm = ? WHERE parentcpdm = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@parentcpdm", OleDbType.VarChar, 12).Value = Trim(TxtNewCpdm.Text)
            rcOleDbCommand.Parameters.Add("@parentcpdm", OleDbType.VarChar, 12).Value = Trim(TxtOldCpdm.Text)
            rcOleDbCommand.ExecuteNonQuery()
            'PO_CSCPCGDJ
            rcOleDbCommand.CommandText = "SELECT COUNT(*) AS gs FROM po_cscpcgdj WHERE cpdm = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(TxtNewCpdm.Text)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("newcgdj") IsNot Nothing Then
                rcDataSet.Tables("newcgdj").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "newcgdj")
            rcOleDbCommand.CommandText = "SELECT COUNT(*) AS gs FROM po_cscpcgdj WHERE cpdm = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(TxtOldCpdm.Text)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("oldcgdj") IsNot Nothing Then
                rcDataSet.Tables("oldcgdj").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "oldcgdj")
            If rcDataSet.Tables("newcgdj").Rows(0).Item("gs") > 0 And rcDataSet.Tables("oldcgdj").Rows(0).Item("gs") > 0 Then
                'ɾ���ɵĲɹ��۸���Ϣ
                rcOleDbCommand.CommandText = "DELETE FROM po_cscpcgdj WHERE cpdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@parentcpdm", OleDbType.VarChar, 12).Value = Trim(TxtOldCpdm.Text)
                rcOleDbCommand.ExecuteNonQuery()
            Else
                rcOleDbCommand.CommandText = "UPDATE po_cscpcgdj SET cpdm = ? WHERE cpdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(TxtNewCpdm.Text)
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(TxtOldCpdm.Text)
                rcOleDbCommand.ExecuteNonQuery()
            End If
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
        '(12)RC_CPXX(��Ҫɾ��/�����)
        If rcDataSet.Tables("newcpxx").Rows.Count > 0 Then
            'ɾ���ɱ���
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "DELETE From rc_cpxx Where cpdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(TxtOldCpdm.Text)
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
                rcOleDbCommand.CommandText = "UPDATE rc_cpxx SET cpdm = ? WHERE cpdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(TxtNewCpdm.Text)
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(TxtOldCpdm.Text)
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
            rcOleDbCommand.CommandText = "INSERT INTO rc_cpdmtz (tzrq,oldcpdm,oldcpmc,olddw,newcpdm,newcpmc,newdw,ynhb,srr) VALUES (?,?,?,?,?,?,?,?,?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@tzrq", OleDbType.Date, 8).Value = Now.Date
            rcOleDbCommand.Parameters.Add("@oldcpdm", OleDbType.VarChar, 12).Value = Me.TxtOldCpdm.Text
            rcOleDbCommand.Parameters.Add("@oldcpmc", OleDbType.VarChar, 40).Value = Me.TxtOldCpmc.Text
            rcOleDbCommand.Parameters.Add("@olddw", OleDbType.VarChar, 8).Value = Me.TxtOldDw.Text
            rcOleDbCommand.Parameters.Add("@newcpdm", OleDbType.VarChar, 12).Value = Me.TxtNewCpdm.Text
            rcOleDbCommand.Parameters.Add("@newcpmc", OleDbType.VarChar, 40).Value = Me.TxtNewCpmc.Text
            rcOleDbCommand.Parameters.Add("@newdw", OleDbType.VarChar, 8).Value = Me.TxtNewDw.Text
            If rcDataSet.Tables("newcpxx").Rows.Count > 0 Then
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
        MsgBox("������ϲ����ϱ�����ɡ�" & Chr(13) & "��������������Ӧ�ա�Ӧ���ȵ�������ȷ�ԡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
        Me.TxtOldCpdm.Text = ""
        Me.TxtNewCpdm.Text = ""
        Me.TxtOldCpmc.Text = ""
        Me.TxtNewCpmc.Text = ""
        Me.TxtOldDw.Text = ""
        Me.TxtNewDw.Text = ""
        Me.TxtOldCpdm.Focus()
    End Sub

End Class