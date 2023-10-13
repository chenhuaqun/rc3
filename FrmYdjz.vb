Imports System.Data.OleDb

Public Class FrmYdjz
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '���ݸ��´���
    Dim rcOleDbTrans As OleDbTransaction
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '���û���ڼ�
    Dim strDwKjqj As String = ""
    '�������ʼ����
    Dim dateKsrq As Date = Now().Date
    '�������ֹ����
    Dim dateZzrq As Date = Now().Date

    Private Sub FrmYdjz_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        strDwKjqj = getInvKjqj(g_Dwrq)
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT ny,jzbz,invbegin,invend FROM rc_yj WHERE jzbz = 0 AND ny >= ? ORDER BY ny"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = strDwKjqj
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_yj") IsNot Nothing Then
                rcDataset.Tables("rc_yj").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_yj")
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_yj").Rows.Count = 0 Then
            MsgBox("����ڼ������д������顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        'Ĭ��ֵ
        NudYear.Value = Mid(rcDataset.Tables("rc_yj").Rows(0).Item("ny"), 1, 4)
        NudMonth.Value = Mid(rcDataset.Tables("rc_yj").Rows(0).Item("ny"), 5, 2)
        dateKsrq = rcDataset.Tables("rc_yj").Rows(0).Item("invbegin")
        dateZzrq = rcDataset.Tables("rc_yj").Rows(0).Item("invend")
    End Sub

    Private Sub NudYear_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles NudYear.KeyDown
        Select Case e.KeyCode
            Case Keys.Return, Keys.Right
                SendKeys.Send("{TAB}")
            Case Keys.Left
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub NudMonth_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles NudMonth.KeyDown
        Select Case e.KeyCode
            Case Keys.Return, Keys.Right
                SendKeys.Send("{TAB}")
            Case Keys.Left
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        '������ֵ
        Dim dInvBegin As Date = getInvBegin(NudYear.Value, Me.NudMonth.Value)
        Dim dInvEnd As Date ' = getInvEnd(NudYear.Value, Me.NudMonth.Value)
        '(1)�����Ƿ����
        LblMsg.Text = "���ڼ�鱾���Ƿ���ˣ����Ժ򡭡�"
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT ny,jzbz FROM rc_yj WHERE ny = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_yj") IsNot Nothing Then
                rcDataset.Tables("rc_yj").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_yj")
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_yj").Rows.Count = 0 Then
            MsgBox("����ڼ������д������顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        If rcDataset.Tables("rc_yj").Rows(0).Item("jzbz") = 1 Then
            MsgBox("�����ѽ��ˡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        '(2)��������Ƿ����
        LblMsg.Text = "���ڼ�������Ƿ���ˣ����Ժ򡭡�"
        Dim strDwKjqj As String
        Dim strKjqj As String = NudYear.Value & Trim(Str(NudMonth.Value)).PadLeft(2, "0")
        strDwKjqj = getInvKjqj(g_Dwrq)
        If strDwKjqj > strKjqj Then
            MsgBox("��λ���û���ڼ�֮ǰ�Ļ���ڼ䲻�ؽ��ˡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            Return
        End If
        '���������û���ڼ�ʱ,��Ҫ��������Ƿ����
        If strDwKjqj <> strKjqj Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT ny,jzbz FROM rc_yj WHERE ny = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = IIf(NudMonth.Value <> 1, NudYear.Value & (NudMonth.Value - 1).ToString.PadLeft(2, "0"), (NudYear.Value - 1) & "12")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_yj") IsNot Nothing Then
                    rcDataset.Tables("rc_yj").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_yj")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_yj").Rows.Count = 0 Then
                MsgBox("����ڼ������д������顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            End If
            If rcDataset.Tables("rc_yj").Rows(0).Item("jzbz") <> 1 Then
                MsgBox("����δ���ˣ����Ƚ����µ��ˡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            End If
        End If
        '(3)������е����Ƿ��Ѿ�����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '(a)���
            LblMsg.Text = "���ڼ�鸶��Ƿ��Ѿ����ˣ����Ժ򡭡�"
            rcOleDbCommand.CommandText = "SELECT 1 FROM ap_fkd WHERE (jzr IS NULL) AND TRUNC(fkrq,'dd') >= ? AND TRUNC(fkrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("fkdml") IsNot Nothing Then
                rcDataset.Tables("fkdml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "fkdml")
            If rcDataset.Tables("fkdml").Rows.Count <> 0 Then
                MsgBox("����û�м��˵ĸ�������顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            End If
            '(b)�տ
            LblMsg.Text = "���ڼ���տ�Ƿ��Ѿ����ˣ����Ժ򡭡�"
            rcOleDbCommand.CommandText = "SELECT 1 FROM ar_skd WHERE (jzr IS NULL) AND TRUNC(skrq,'dd') >= ? AND TRUNC(skrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("skdml") IsNot Nothing Then
                rcDataset.Tables("skdml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "skdml")
            If rcDataset.Tables("skdml").Rows.Count <> 0 Then
                MsgBox("����û�м��˵��տ�����顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            End If
            '(c)����ƾ֤
            LblMsg.Text = "���ڼ�����ƾ֤�Ƿ��Ѿ����ˣ����Ժ򡭡�"
            rcOleDbCommand.CommandText = "SELECT 1 FROM gl_pz WHERE (jzr IS NULL) AND TRUNC(pzrq,'dd') >= ? AND TRUNC(pzrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@pzrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@pzrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("pzml") IsNot Nothing Then
                rcDataset.Tables("pzml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "pzml")
            If rcDataset.Tables("pzml").Rows.Count <> 0 Then
                MsgBox("����û�м��˵ļ���ƾ֤�����顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            End If
            '(d)���ⵥ
            LblMsg.Text = "���ڼ�����ϳ��ⵥ�Ƿ��Ѿ����ˣ����Ժ򡭡�"
            rcOleDbCommand.CommandText = "SELECT 1 FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND (jzr IS NULL) AND TRUNC(ckrq,'dd') >= ? AND TRUNC(ckrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("ckdml") IsNot Nothing Then
                rcDataset.Tables("ckdml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "ckdml")
            If rcDataset.Tables("ckdml").Rows.Count <> 0 Then
                MsgBox("����û�м��˵����ϳ��ⵥ�����顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            End If
            '(e)������
            LblMsg.Text = "���ڼ�����ϵ������Ƿ��Ѿ����ˣ����Ժ򡭡�"
            rcOleDbCommand.CommandText = "SELECT 1 FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND (jzr IS NULL) AND TRUNC(dbrq,'dd') >= ? AND TRUNC(dbrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("dbdml") IsNot Nothing Then
                rcDataset.Tables("dbdml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "dbdml")
            If rcDataset.Tables("dbdml").Rows.Count <> 0 Then
                MsgBox("����û�м��˵����ϵ����������顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            End If
            '(f)�̴浥
            LblMsg.Text = "���ڼ�������̴浥�Ƿ��Ѿ����ˣ����Ժ򡭡�"
            rcOleDbCommand.CommandText = "SELECT 1 FROM inv_pc WHERE (jzr IS NULL) AND TRUNC(pcrq,'dd') >= ? AND TRUNC(pcrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@pcrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@pcrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("pcml") IsNot Nothing Then
                rcDataset.Tables("pcml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "pcml")
            If rcDataset.Tables("pcml").Rows.Count <> 0 Then
                MsgBox("����û�м��˵������̴浥�����顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            End If
            '(g)��Ʒ��ⵥ
            LblMsg.Text = "���ڼ���Ʒ��ⵥ�Ƿ��Ѿ����ˣ����Ժ򡭡�"
            rcOleDbCommand.CommandText = "SELECT 1 FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND (jzr IS NULL) AND TRUNC(rkrq,'dd') >= ? AND TRUNC(rkrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rkdml") IsNot Nothing Then
                rcDataset.Tables("rkdml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rkdml")
            If rcDataset.Tables("rkdml").Rows.Count <> 0 Then
                MsgBox("����û�м��˵Ĳ�Ʒ��ⵥ�����顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            End If
            '(h)��Ʒ���۶���
            LblMsg.Text = "���ڼ���Ʒ���۶����Ƿ��Ѿ����ˣ����Ժ򡭡�"
            rcOleDbCommand.CommandText = "SELECT 1 FROM oe_dd WHERE (jzr IS NULL) AND TRUNC(qdrq,'dd') >= ? AND TRUNC(qdrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@qdrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@qdrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("ddml") IsNot Nothing Then
                rcDataset.Tables("ddml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "ddml")
            If rcDataset.Tables("ddml").Rows.Count <> 0 Then
                MsgBox("����û�м��˵Ĳ�Ʒ���۶��������顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            End If
            '(i)��Ʒ�ͻ���
            LblMsg.Text = "���ڼ���Ʒ�ͻ����Ƿ��Ѿ����ˣ����Ժ򡭡�"
            rcOleDbCommand.CommandText = "SELECT 1 FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND (jzr IS NULL) AND TRUNC(xsrq,'dd') >= ? AND TRUNC(xsrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("xsdml") IsNot Nothing Then
                rcDataset.Tables("xsdml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "xsdml")
            If rcDataset.Tables("xsdml").Rows.Count <> 0 Then
                MsgBox("����û�м��˵Ĳ�Ʒ�ͻ��������顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            End If
            '(j)���۷�Ʊ
            LblMsg.Text = "���ڼ�����۷�Ʊ�Ƿ��Ѿ����ˣ����Ժ򡭡�"
            rcOleDbCommand.CommandText = "SELECT 1 FROM oe_fp WHERE oe_fp.bdelete = 0 AND (jzr IS NULL) AND TRUNC(fprq,'dd') >= ? AND TRUNC(fprq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("fpml") IsNot Nothing Then
                rcDataset.Tables("fpml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "fpml")
            If rcDataset.Tables("fpml").Rows.Count <> 0 Then
                MsgBox("����û�м��˵Ĳ�Ʒ���۷�Ʊ�����顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            End If
            ''(k)��Ʒ��������
            'LblMsg.Text = "���ڼ���Ʒ���������Ƿ��Ѿ����ˣ����Ժ򡭡�"
            'rcOleDbCommand.CommandText = "SELECT 1 FROM pm_dd WHERE (jzr IS NULL) AND TRUNC(qdrq,'dd') >= ? AND TRUNC(qdrq,'dd') <= ?"
            'rcOleDbCommand.Parameters.Clear()
            'rcOleDbCommand.Parameters.Add("@qdrq", OleDbType.Date, 8).Value = dateKsrq.Date
            'rcOleDbCommand.Parameters.Add("@qdrq", OleDbType.Date, 8).Value = dateZzrq.Date
            'rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            'If rcDataset.Tables("ddml") IsNot Nothing Then
            '    rcDataset.Tables("ddml").Clear()
            'End If
            'rcOleDbDataAdpt.Fill(rcDataset, "ddml")
            'If rcDataset.Tables("ddml").Rows.Count <> 0 Then
            '    MsgBox("����û�м��˵Ĳ�Ʒ�������������顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            '    Return
            'End If
            '(l)���ϲɹ���
            LblMsg.Text = "���ڼ�����ϲɹ������Ƿ��Ѿ����ˣ����Ժ򡭡�"
            rcOleDbCommand.CommandText = "SELECT 1 FROM po_cgd WHERE (jzr IS NULL) AND TRUNC(cgrq,'dd') >= ? AND TRUNC(cgrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cgrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@cgrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("cgdml") IsNot Nothing Then
                rcDataset.Tables("cgdml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "cgdml")
            If rcDataset.Tables("cgdml").Rows.Count <> 0 Then
                MsgBox("����û�м��˵����ϲɹ����������顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            End If
            '(m)�����ջ���
            LblMsg.Text = "���ڼ�������ջ����Ƿ��Ѿ����ˣ����Ժ򡭡�"
            rcOleDbCommand.CommandText = "SELECT 1 FROM po_rkd WHERE po_rkd.bdelete = 0 AND (jzr IS NULL) AND TRUNC(rkrq,'dd') >= ? AND TRUNC(rkrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rkdml") IsNot Nothing Then
                rcDataset.Tables("rkdml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rkdml")
            If rcDataset.Tables("rkdml").Rows.Count <> 0 Then
                MsgBox("����û�м��˵������ջ��������顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            End If
            '(o)������ⵥ
            LblMsg.Text = "���ڼ��������ⵥ���ɹ���Ʊ���Ƿ��Ѿ����ˣ����Ժ򡭡�"
            rcOleDbCommand.CommandText = "SELECT 1 FROM po_fp WHERE po_fp.bdelete = 0 AND (jzr IS NULL) AND TRUNC(fprq,'dd') >= ? AND TRUNC(fprq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("fpml") IsNot Nothing Then
                rcDataset.Tables("fpml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "fpml")
            If rcDataset.Tables("fpml").Rows.Count <> 0 Then
                MsgBox("����û�м��˵�������⣨�ɹ���Ʊ�������顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            End If
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try

        '(4)�ǲ��ǽ�12�·ݵ���
        If Me.NudMonth.Value = 12 Then
            Dim i As Integer
            Dim j As Integer
            dInvBegin = getInvBegin(NudYear.Value, 1)
            dInvEnd = getInvEnd(NudYear.Value, 12)
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                '(5)����
                '(A)���»�������
                LblMsg.Text = "�������»������ʣ����Ժ򡭡�"
                rcOleDbCommand.CommandType = CommandType.StoredProcedure
                rcOleDbCommand.CommandText = "USP3_REDO_CPYEHZ"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                rcOleDbCommand.Parameters.Add("@dwrq", OleDbType.Date, 8).Value = g_Dwrq
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                rcOleDbCommand.CommandType = CommandType.StoredProcedure
                rcOleDbCommand.CommandText = "USP3_REDO_CSYEHZ"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                rcOleDbCommand.Parameters.Add("@dwrq", OleDbType.Date, 8).Value = g_Dwrq
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                rcOleDbCommand.CommandType = CommandType.StoredProcedure
                rcOleDbCommand.CommandText = "USP3_REDO_KHYEHZ"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                rcOleDbCommand.Parameters.Add("@dwrq", OleDbType.Date, 8).Value = g_Dwrq
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                '(B)ȡ����һ������Ѽ��˵ĵ���
                LblMsg.Text = "����ȡ����һ������Ѽ��˵ĵ��ݣ����Ժ򡭡�"
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "UPDATE ap_fkd SET jzr = '' WHERE SUBSTR(DJH,5,4) = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                rcOleDbCommand.CommandText = "UPDATE ar_skd SET jzr = '' WHERE SUBSTR(DJH,5,4) = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                rcOleDbCommand.CommandText = "UPDATE gl_pz SET jzr = '' WHERE SUBSTR(DJH,5,4) = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                rcOleDbCommand.CommandText = "UPDATE inv_ckd SET jzr = '' WHERE SUBSTR(DJH,5,4) = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                rcOleDbCommand.CommandText = "UPDATE inv_dbd SET jzr = '' WHERE SUBSTR(DJH,5,4) = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                rcOleDbCommand.CommandText = "UPDATE inv_pc SET jzr = '' WHERE pcrq > ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@pcrq", OleDbType.Date, 8).Value = dInvEnd
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                rcOleDbCommand.CommandText = "UPDATE inv_rkd SET jzr = '' WHERE inv_rkd.bdelete = 0 AND SUBSTR(DJH,5,4) = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                rcOleDbCommand.CommandText = "UPDATE oe_dd SET jzr = '' WHERE SUBSTR(DJH,5,4) = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                rcOleDbCommand.CommandText = "UPDATE oe_xsd SET jzr = '' WHERE SUBSTR(DJH,5,4) = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                'rcOleDbCommand.CommandText = "UPDATE pm_dd SET jzr = '' WHERE SUBSTR(DJH,5,4) = ?"
                'rcOleDbCommand.Parameters.Clear()
                'rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                'rcOleDbCommand.ExecuteNonQuery()
                'Application.DoEvents()
                rcOleDbCommand.CommandText = "UPDATE po_cgd SET jzr = '' WHERE SUBSTR(DJH,5,4) = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                rcOleDbCommand.CommandText = "UPDATE po_rkd SET jzr = '' WHERE SUBSTR(DJH,5,4) = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                '(C)ɾ����һ��ȵ�inv_cpyeb�е��������ϱ��롢�ͻ����롢�ֿ����
                LblMsg.Text = "����ɾ����һ��ȵ�inv_cpyeb�е����ݣ����Ժ򡭡�"
                rcOleDbCommand.CommandText = "DELETE FROM inv_cpyeb WHERE kjnd = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                LblMsg.Text = "����д����һ��ȵ�inv_cpyeb�е����ݣ����Ժ򡭡�"
                '(D)����inv_cpyeb������
                rcOleDbCommand.CommandText = "INSERT INTO inv_cpyeb (kjnd,cpdm,ckdm,qcsl,qcfzsl,qcje,idsl,idje) SELECT ? AS kjnd,cpdm,ckdm,COALESCE(qcsl,0.0)+COALESCE(idsl,0.0) AS qcsl,COALESCE(qcfzsl,0.0)+COALESCE(idfzsl,0.0) AS qcfzsl,COALESCE(qcje,0.0)+COALESCE(idje,0.0) AS qcje,0 AS idsl,0 AS idje FROM inv_cpyeb WHERE kjnd = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd1", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.Parameters.Add("@kjnd2", OleDbType.VarChar, 4).Value = NudYear.Value
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                '(E)ɾ����һ��ȵ�ap_csyeb�е��������ϱ��롢�ͻ����롢�ֿ����
                LblMsg.Text = "����ɾ����һ��ȵ�ap_csyeb�е����ݣ����Ժ򡭡�"
                rcOleDbCommand.CommandText = "DELETE FROM ap_csyeb WHERE kjnd = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                LblMsg.Text = "����д����һ��ȵ�ap_csyeb�е����ݣ����Ժ򡭡�"
                '(F)����ap_csyeb������
                rcOleDbCommand.CommandText = "INSERT INTO ap_csyeb (kjnd,csdm,qcfpje,idfpje) SELECT ? AS kjnd,csdm,COALESCE(qcfpje,0.0)+COALESCE(idfpje,0.0) AS qcfpje,0 AS idfpje FROM ap_csyeb WHERE kjnd = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd1", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.Parameters.Add("@kjnd2", OleDbType.VarChar, 4).Value = NudYear.Value
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                '(G)ɾ����һ��ȵ�ar_khyeb�е��������ϱ��롢�ͻ����롢�ֿ����
                LblMsg.Text = "����ɾ����һ��ȵ�ar_khyeb�е����ݣ����Ժ򡭡�"
                rcOleDbCommand.CommandText = "DELETE FROM ar_khyeb WHERE kjnd = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                LblMsg.Text = "����д����һ��ȵ�ar_khyeb�е����ݣ����Ժ򡭡�"
                '(H)����ar_khyeb������
                rcOleDbCommand.CommandText = "INSERT INTO ar_khyeb (kjnd,khdm,qcfpje,idfpje) SELECT ? AS kjnd,khdm,COALESCE(qcfpje,0.0)+COALESCE(idfpje,0.0) AS qcfpje,0 AS idfpje FROM ar_khyeb WHERE kjnd = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd1", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.Parameters.Add("@kjnd2", OleDbType.VarChar, 4).Value = NudYear.Value
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                '(I)���ɵ�������
                LblMsg.Text = "�������ɵ������ͣ����Ժ򡭡�"
                'ȡδ��ӵ�����
                rcOleDbCommand.CommandText = "SELECT pzlxdm,lxgs FROM rc_lx WHERE kjnd = ? AND NOT EXISTS (SELECT 1 FROM (SELECT pzlxdm FROM rc_lx WHERE kjnd = ?) llll WHERE llll.pzlxdm = rc_lx.pzlxdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = NudYear.Value
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_lx") IsNot Nothing Then
                    rcDataset.Tables("rc_lx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_lx")
                '��������
                For i = 0 To rcDataset.Tables("rc_lx").Rows.Count - 1
                    For j = 1 To 12
                        rcOleDbCommand.CommandText = "CREATE SEQUENCE " & Trim(rcDataset.Tables("rc_lx").Rows(i).Item("pzlxdm")) & (Me.NudYear.Value + 1).ToString & j.ToString.PadLeft(2, "0") & " INCREMENT BY 1 START WITH 1 MAXVALUE 99999 MINVALUE 1 NOCYCLE NOCACHE NOORDER"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.ExecuteNonQuery()
                    Next
                Next
                Application.DoEvents()
                rcOleDbCommand.CommandText = "INSERT INTO rc_lx (kjnd,pzlxdm,pzlxjc,pzlxmc,lxgs,pzno01,pzno02,pzno03,pzno04,pzno05,pzno06,pzno07,pzno08,pzno09,pzno10,pzno11,pzno12,pzno13,bfushu) SELECT '" & NudYear.Value + 1 & "' as kjnd,pzlxdm,pzlxjc,pzlxmc,lxgs,0 as pzno01,0 as pzno02,0 as pzno03,0 as pzno04,0 as pzno05,0 as pzno06,0 as pzno07,0 as pzno08,0 as pzno09,0 as pzno10,0 as pzno11,0 as pzno12,0 AS pzno13,bfushu FROM rc_lx WHERE kjnd = ? AND NOT EXISTS (SELECT 1 FROM (SELECT pzlxdm FROM rc_lx WHERE kjnd = ?) llll WHERE llll.pzlxdm = rc_lx.pzlxdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = NudYear.Value
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = NudYear.Value + 1
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                '(J)���ɻ���ڼ���˱�־
                LblMsg.Text = "�������ɻ���ڼ䣬���Ժ򡭡�"
                rcOleDbCommand.CommandText = "INSERT INTO rc_yj (ny,jzbz,glbegin,glend,invbegin,invend,pobegin,poend) SELECT ? || SUBSTR(ny,5,2) AS ny,0 AS jzbz,add_months(glbegin,12),add_months(glend,12),add_months(invbegin,12),add_months(invend,12),add_months(pobegin,12),add_months(poend,12) FROM rc_yj WHERE SUBSTR(ny,1,4) = ? AND NOT EXISTS (SELECT 1 FROM (SELECT ny FROM rc_yj WHERE SUBSTR(ny,1,4) = ?) llll WHERE SUBSTR(llll.ny,5,2) = SUBSTR(rc_yj.ny,5,2))"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 4).Value = Me.NudYear.Value + 1
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 4).Value = Me.NudYear.Value + 1
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                '(K)
                LblMsg.Text = "����������һ��������ʣ����Ժ򡭡�"
                rcOleDbCommand.CommandType = CommandType.StoredProcedure
                rcOleDbCommand.CommandText = "USP3_REDO_CPYEHZ"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value + 1
                rcOleDbCommand.Parameters.Add("@dwrq", OleDbType.Date, 8).Value = g_Dwrq
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                rcOleDbCommand.CommandType = CommandType.StoredProcedure
                rcOleDbCommand.CommandText = "USP3_REDO_CSYEHZ"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value + 1
                rcOleDbCommand.Parameters.Add("@dwrq", OleDbType.Date, 8).Value = g_Dwrq
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
                rcOleDbCommand.CommandType = CommandType.StoredProcedure
                rcOleDbCommand.CommandText = "USP3_REDO_KHYEHZ"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value + 1
                rcOleDbCommand.Parameters.Add("@dwrq", OleDbType.Date, 8).Value = g_Dwrq
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
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
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            '(5)����
            LblMsg.Text = "���ڽ����µ׽��ˣ����Ժ򡭡�"
            rcOleDbCommand.CommandText = "UPDATE rc_yj SET jzbz = 1 WHERE ny = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
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
        LblMsg.Text = "������ɡ�"
        MsgBox("���½�������ɡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
        Me.Close()
    End Sub

#Region "ȡ������"

    Private Sub BtnFjz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFjz.Click
        '������
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT MAX(ny) AS ny FROM rc_yj WHERE jzbz = '1'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_yj") IsNot Nothing Then
                rcDataset.Tables("rc_yj").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_yj")
        Catch ex As Exception
            Try
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Catch ey As OleDbException
                MsgBox("�������" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            End Try
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_yj").Rows.Count > 0 Then
            If MsgBox("���Ƿ�Ҫȡ������" & rcDataset.Tables("rc_yj").Rows(0).Item("ny") & "��", MsgBoxStyle.YesNo, "��ʾ��Ϣ") = MsgBoxResult.Yes Then
                Try
                    rcOleDbConn.Open()
                    rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.Transaction = rcOleDbTrans
                    rcOleDbCommand.CommandType = CommandType.Text
                    rcOleDbCommand.CommandText = "UPDATE rc_yj SET jzbz = '0' WHERE ny = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = rcDataset.Tables("rc_yj").Rows(0).Item("ny")
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
                MsgBox("ȡ��������ɡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Me.Close()
            End If
        End If
    End Sub

#End Region
End Class