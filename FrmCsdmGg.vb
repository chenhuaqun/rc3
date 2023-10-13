Imports System.Data.OleDb

Public Class FrmCsdmGg
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '��ʾҪ������Դִ�е� SQL ����
    Dim rcOleDbTrans As OleDbTransaction
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Private Sub FrmCsdmGg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TxtOldCsdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtOldCsdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_csxx"
                    .paraField1 = "csdm"
                    .paraField2 = "csmc"
                    .paraField3 = "cssm"
                    .paraCondition = "0=0"
                    .paraOrderField = "csmc"
                    .paraTitle = "��Ӧ��"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtOldCsdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Return, Keys.Down
                Me.TxtNewCsdm.Focus()
            Case Keys.Up
                Me.BtnHelp.Focus()
        End Select
    End Sub

    Private Sub TxtNewCsdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNewCsdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_csxx"
                    .paraField1 = "csdm"
                    .paraField2 = "csmc"
                    .paraField3 = "cssm"
                    .paraCondition = "0=0"
                    .paraOrderField = "csmc"
                    .paraTitle = "��Ӧ��"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtNewCsdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Return, Keys.Down
                Me.BtnOk.Focus()
            Case Keys.Up
                Me.TxtOldCsdm.Focus()
        End Select
    End Sub

    Private Sub TxtOldCsdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtOldCsdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtOldCsdm.Text) Then
            '��ȡ����
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT  *  From rc_csxx Where csdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtOldCsdm.Text)
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
                If rcDataSet.Tables("oldcsxx").Rows(0).Item("csmc").GetType.ToString <> "System.DBNull" Then
                    TxtOldCsmc.Text = rcDataSet.Tables("oldcsxx").Rows(0).Item("csmc")
                End If
            Else
                MsgBox("�ù�Ӧ�̱��벻���ڡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                TxtOldCsdm.Focus()
            End If
        End If
    End Sub

    Private Sub TxtNewCsdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNewCsdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtNewCsdm.Text) Then
            '��ȡ����
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "SELECT  *  From rc_csxx Where csdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtNewCsdm.Text)
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
                If rcDataSet.Tables("newcsxx").Rows(0).Item("csmc").GetType.ToString <> "System.DBNull" Then
                    TxtNewCsmc.Text = rcDataSet.Tables("newcsxx").Rows(0).Item("csmc")
                End If
            Else
                Me.TxtNewCsmc.Text = Me.TxtOldCsmc.Text
            End If
        End If
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If rcDataSet.Tables("newcsxx") Is Nothing Then
            Return
        End If
        If rcDataSet.Tables("oldcsxx") Is Nothing Then
            Return
        End If
        'ͬһ�����򷵻�
        If Me.TxtOldCsdm.Text = Me.TxtNewCsdm.Text Then
            MsgBox("��Ӧ�̱�����ͬ������Ҫ���ġ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            Return
        End If
        If rcDataSet.Tables("newcsxx").Rows.Count > 0 Then
            If Not MsgBox("�¹�Ӧ�̱����Ѿ����ڡ����Ƿ�Ҫ�ϲ���Ӧ�̱��룿", MsgBoxStyle.YesNo + MsgBoxStyle.Information + MsgBoxStyle.DefaultButton2, "��ʾ��Ϣ") = MsgBoxResult.Yes Then
                TxtNewCsdm.Text = ""
                TxtNewCsmc.Text = ""
                TxtNewCsdm.Focus()
                Return
            End If
        End If
        '���濪ʼ���ı���
        '(1)AP_CSYEB(��Ҫ�ϲ�)
        '��ȡ����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT kjnd,Sum(Nvl(qcje,0.0)) as qcje,Sum(Nvl(idje,0.0)) as idje FROM ap_csyeb WHERE (csdm = ? or csdm = ?) GROUP BY kjnd"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtNewCsdm.Text)
            rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtOldCsdm.Text)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("sumcsyeb") IsNot Nothing Then
                rcDataset.Tables("sumcsyeb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "sumcsyeb")
            'rcOleDbCommand.CommandText = "SELECT kjnd,kmdm,bmdm,zydm,xmdm,khdm,yhzh,jxzh,Sum(CASE WHEN jd = '��' THEN Nvl(ncsl,0.0) ELSE 0 - Nvl(ncsl,0.0) END) as ncsl,Sum(CASE WHEN jd = '��' THEN Nvl(ncwb,0.0) ELSE 0 - Nvl(ncwb,0.0) END) as ncwb,Sum(CASE WHEN jd = '��' THEN Nvl(ncje,0.0) ELSE 0 - Nvl(ncje,0.0) END) as ncje FROM gl_kmyeb WHERE (csdm = ? or csdm = ?) GROUP BY kjnd"
            '��Ŀ����
            rcOleDbCommand.CommandText = "SELECT kjnd,kmdm,bmdm,zydm,xmdm,khdm,yhzh,jxzh,'��' AS jd,SUM(CASE WHEN jd ='��' THEN ncsl ELSE 0 - ncsl END) AS ncsl,SUM(CASE WHEN jd ='��' THEN ncwb ELSE 0 - ncwb END) AS ncwb,SUM(CASE WHEN jd ='��' THEN ncje ELSE 0 - ncje END) AS ncje" &
                    ",SUM(CASE WHEN jd ='��' THEN jfsl01 ELSE 0 - jfsl01 END) AS jfsl01,SUM(CASE WHEN jd ='��' THEN jfwb01 ELSE 0 - jfwb01 END) AS jfwb01,SUM(CASE WHEN jd ='��' THEN jfje01 ELSE 0 - jfje01 END) AS jfje01" &
                    ",SUM(CASE WHEN jd ='��' THEN dfsl01 ELSE 0 - dfsl01 END) AS dfsl01,SUM(CASE WHEN jd ='��' THEN dfwb01 ELSE 0 - dfwb01 END) AS dfwb01,SUM(CASE WHEN jd ='��' THEN dfje01 ELSE 0 - dfje01 END) AS dfje01" &
                    ",SUM(CASE WHEN jd ='��' THEN jfsl02 ELSE 0 - jfsl02 END) AS jfsl02,SUM(CASE WHEN jd ='��' THEN jfwb02 ELSE 0 - jfwb02 END) AS jfwb02,SUM(CASE WHEN jd ='��' THEN jfje02 ELSE 0 - jfje02 END) AS jfje02" &
                    ",SUM(CASE WHEN jd ='��' THEN dfsl02 ELSE 0 - dfsl02 END) AS dfsl02,SUM(CASE WHEN jd ='��' THEN dfwb02 ELSE 0 - dfwb02 END) AS dfwb02,SUM(CASE WHEN jd ='��' THEN dfje02 ELSE 0 - dfje02 END) AS dfje02" &
                    ",SUM(CASE WHEN jd ='��' THEN jfsl03 ELSE 0 - jfsl03 END) AS jfsl03,SUM(CASE WHEN jd ='��' THEN jfwb03 ELSE 0 - jfwb03 END) AS jfwb03,SUM(CASE WHEN jd ='��' THEN jfje03 ELSE 0 - jfje03 END) AS jfje03" &
                    ",SUM(CASE WHEN jd ='��' THEN dfsl03 ELSE 0 - dfsl03 END) AS dfsl03,SUM(CASE WHEN jd ='��' THEN dfwb03 ELSE 0 - dfwb03 END) AS dfwb03,SUM(CASE WHEN jd ='��' THEN dfje03 ELSE 0 - dfje03 END) AS dfje03" &
                    ",SUM(CASE WHEN jd ='��' THEN jfsl04 ELSE 0 - jfsl04 END) AS jfsl04,SUM(CASE WHEN jd ='��' THEN jfwb04 ELSE 0 - jfwb04 END) AS jfwb04,SUM(CASE WHEN jd ='��' THEN jfje04 ELSE 0 - jfje04 END) AS jfje04" &
                    ",SUM(CASE WHEN jd ='��' THEN dfsl04 ELSE 0 - dfsl04 END) AS dfsl04,SUM(CASE WHEN jd ='��' THEN dfwb04 ELSE 0 - dfwb04 END) AS dfwb04,SUM(CASE WHEN jd ='��' THEN dfje04 ELSE 0 - dfje04 END) AS dfje04" &
                    ",SUM(CASE WHEN jd ='��' THEN jfsl05 ELSE 0 - jfsl05 END) AS jfsl05,SUM(CASE WHEN jd ='��' THEN jfwb05 ELSE 0 - jfwb05 END) AS jfwb05,SUM(CASE WHEN jd ='��' THEN jfje05 ELSE 0 - jfje05 END) AS jfje05" &
                    ",SUM(CASE WHEN jd ='��' THEN dfsl05 ELSE 0 - dfsl05 END) AS dfsl05,SUM(CASE WHEN jd ='��' THEN dfwb05 ELSE 0 - dfwb05 END) AS dfwb05,SUM(CASE WHEN jd ='��' THEN dfje05 ELSE 0 - dfje05 END) AS dfje05" &
                    ",SUM(CASE WHEN jd ='��' THEN jfsl06 ELSE 0 - jfsl06 END) AS jfsl06,SUM(CASE WHEN jd ='��' THEN jfwb06 ELSE 0 - jfwb06 END) AS jfwb06,SUM(CASE WHEN jd ='��' THEN jfje06 ELSE 0 - jfje06 END) AS jfje06" &
                    ",SUM(CASE WHEN jd ='��' THEN dfsl06 ELSE 0 - dfsl06 END) AS dfsl06,SUM(CASE WHEN jd ='��' THEN dfwb06 ELSE 0 - dfwb06 END) AS dfwb06,SUM(CASE WHEN jd ='��' THEN dfje06 ELSE 0 - dfje06 END) AS dfje06" &
                    ",SUM(CASE WHEN jd ='��' THEN jfsl07 ELSE 0 - jfsl07 END) AS jfsl07,SUM(CASE WHEN jd ='��' THEN jfwb07 ELSE 0 - jfwb07 END) AS jfwb07,SUM(CASE WHEN jd ='��' THEN jfje07 ELSE 0 - jfje07 END) AS jfje07" &
                    ",SUM(CASE WHEN jd ='��' THEN dfsl07 ELSE 0 - dfsl07 END) AS dfsl07,SUM(CASE WHEN jd ='��' THEN dfwb07 ELSE 0 - dfwb07 END) AS dfwb07,SUM(CASE WHEN jd ='��' THEN dfje07 ELSE 0 - dfje07 END) AS dfje07" &
                    ",SUM(CASE WHEN jd ='��' THEN jfsl08 ELSE 0 - jfsl08 END) AS jfsl08,SUM(CASE WHEN jd ='��' THEN jfwb08 ELSE 0 - jfwb08 END) AS jfwb08,SUM(CASE WHEN jd ='��' THEN jfje08 ELSE 0 - jfje08 END) AS jfje08" &
                    ",SUM(CASE WHEN jd ='��' THEN dfsl08 ELSE 0 - dfsl08 END) AS dfsl08,SUM(CASE WHEN jd ='��' THEN dfwb08 ELSE 0 - dfwb08 END) AS dfwb08,SUM(CASE WHEN jd ='��' THEN dfje08 ELSE 0 - dfje08 END) AS dfje08" &
                    ",SUM(CASE WHEN jd ='��' THEN jfsl09 ELSE 0 - jfsl09 END) AS jfsl09,SUM(CASE WHEN jd ='��' THEN jfwb09 ELSE 0 - jfwb09 END) AS jfwb09,SUM(CASE WHEN jd ='��' THEN jfje09 ELSE 0 - jfje09 END) AS jfje09" &
                    ",SUM(CASE WHEN jd ='��' THEN dfsl09 ELSE 0 - dfsl09 END) AS dfsl09,SUM(CASE WHEN jd ='��' THEN dfwb09 ELSE 0 - dfwb09 END) AS dfwb09,SUM(CASE WHEN jd ='��' THEN dfje09 ELSE 0 - dfje09 END) AS dfje09" &
                    ",SUM(CASE WHEN jd ='��' THEN jfsl10 ELSE 0 - jfsl10 END) AS jfsl10,SUM(CASE WHEN jd ='��' THEN jfwb10 ELSE 0 - jfwb10 END) AS jfwb10,SUM(CASE WHEN jd ='��' THEN jfje10 ELSE 0 - jfje10 END) AS jfje10" &
                    ",SUM(CASE WHEN jd ='��' THEN dfsl10 ELSE 0 - dfsl10 END) AS dfsl10,SUM(CASE WHEN jd ='��' THEN dfwb10 ELSE 0 - dfwb10 END) AS dfwb10,SUM(CASE WHEN jd ='��' THEN dfje10 ELSE 0 - dfje10 END) AS dfje10" &
                    ",SUM(CASE WHEN jd ='��' THEN jfsl11 ELSE 0 - jfsl11 END) AS jfsl11,SUM(CASE WHEN jd ='��' THEN jfwb11 ELSE 0 - jfwb11 END) AS jfwb11,SUM(CASE WHEN jd ='��' THEN jfje11 ELSE 0 - jfje11 END) AS jfje11" &
                    ",SUM(CASE WHEN jd ='��' THEN dfsl11 ELSE 0 - dfsl11 END) AS dfsl11,SUM(CASE WHEN jd ='��' THEN dfwb11 ELSE 0 - dfwb11 END) AS dfwb11,SUM(CASE WHEN jd ='��' THEN dfje11 ELSE 0 - dfje11 END) AS dfje11" &
                    ",SUM(CASE WHEN jd ='��' THEN jfsl12 ELSE 0 - jfsl12 END) AS jfsl12,SUM(CASE WHEN jd ='��' THEN jfwb12 ELSE 0 - jfwb12 END) AS jfwb12,SUM(CASE WHEN jd ='��' THEN jfje12 ELSE 0 - jfje12 END) AS jfje12" &
                    ",SUM(CASE WHEN jd ='��' THEN dfsl12 ELSE 0 - dfsl12 END) AS dfsl12,SUM(CASE WHEN jd ='��' THEN dfwb12 ELSE 0 - dfwb12 END) AS dfwb12,SUM(CASE WHEN jd ='��' THEN dfje12 ELSE 0 - dfje12 END) AS dfje12" &
                    ",SUM(CASE WHEN jd ='��' THEN jfsl13 ELSE 0 - jfsl13 END) AS jfsl13,SUM(CASE WHEN jd ='��' THEN jfwb13 ELSE 0 - jfwb13 END) AS jfwb13,SUM(CASE WHEN jd ='��' THEN jfje13 ELSE 0 - jfje13 END) AS jfje13" &
                    ",SUM(CASE WHEN jd ='��' THEN dfsl13 ELSE 0 - dfsl13 END) AS dfsl13,SUM(CASE WHEN jd ='��' THEN dfwb13 ELSE 0 - dfwb13 END) AS dfwb13,SUM(CASE WHEN jd ='��' THEN dfje13 ELSE 0 - dfje13 END) AS dfje13" &
                    " FROM gl_kmyeb WHERE (csdm = ? or csdm = ?) GROUP BY kjnd,kmdm,bmdm,zydm,xmdm,khdm,yhzh,jxzh"

            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtNewCsdm.Text)
            rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtOldCsdm.Text)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("sumkmyeb") IsNot Nothing Then
                rcDataset.Tables("sumkmyeb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "sumkmyeb")
            'ȡ��csdm�ֶεı�
            rcOleDbCommand.CommandText = "SELECT table_name,column_name FROM user_tab_columns WHERE column_name = 'CSDM' AND table_name <> 'AP_CSYEB' AND table_name <> 'GL_KMYEB' AND table_name <> 'RC_CSXX' AND table_name <> 'PO_CSCPCGDJ'"
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
            'ɾ��ԭ��������ar_csyeb
            rcOleDbCommand.CommandText = "DELETE FROM ap_csyeb WHERE (csdm = ? or csdm = ?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtNewCsdm.Text)
            rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtOldCsdm.Text)
            rcOleDbCommand.ExecuteNonQuery()
            '�������
            For i = 0 To rcDataset.Tables("sumcsyeb").Rows.Count - 1
                rcOleDbCommand.CommandText = "INSERT INTO ap_csyeb (kjnd,csdm,csmc,qcje,idje) VALUES (?,?,?,?,?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = rcDataset.Tables("sumcsyeb").Rows(i).Item("kjnd")
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Me.TxtNewCsdm.Text
                rcOleDbCommand.Parameters.Add("@csmc", OleDbType.VarChar, 50).Value = Me.TxtNewCsmc.Text
                rcOleDbCommand.Parameters.Add("@qcje", OleDbType.VarNumeric, 14).Value = rcDataset.Tables("sumcsyeb").Rows(i).Item("qcje")
                rcOleDbCommand.Parameters.Add("@idje", OleDbType.VarNumeric, 14).Value = rcDataset.Tables("sumcsyeb").Rows(i).Item("idje")
                rcOleDbCommand.ExecuteNonQuery()
            Next
            'ɾ��ԭ��������ar_csyeb
            rcOleDbCommand.CommandText = "DELETE FROM gl_kmyeb WHERE (csdm = ? or csdm = ?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtNewCsdm.Text)
            rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtOldCsdm.Text)
            rcOleDbCommand.ExecuteNonQuery()
            '�������
            For i = 0 To rcDataset.Tables("sumkmyeb").Rows.Count - 1
                rcOleDbCommand.CommandText = "INSERT INTO gl_kmyeb (kjnd,kmdm,bmdm,zydm,xmdm,khdm,csdm,yhzh,jxzh,jd,ncsl,ncwb,ncje" &
                    ",jfsl01,jfwb01,jfje01,dfsl01,dfwb01,dfje01" &
                    ",jfsl02,jfwb02,jfje02,dfsl02,dfwb02,dfje02" &
                    ",jfsl03,jfwb03,jfje03,dfsl03,dfwb03,dfje03" &
                    ",jfsl04,jfwb04,jfje04,dfsl04,dfwb04,dfje04" &
                    ",jfsl05,jfwb05,jfje05,dfsl05,dfwb05,dfje05" &
                    ",jfsl06,jfwb06,jfje06,dfsl06,dfwb06,dfje06" &
                    ",jfsl07,jfwb07,jfje07,dfsl07,dfwb07,dfje07" &
                    ",jfsl08,jfwb08,jfje08,dfsl08,dfwb08,dfje08" &
                    ",jfsl09,jfwb09,jfje09,dfsl09,dfwb09,dfje09" &
                    ",jfsl10,jfwb10,jfje10,dfsl10,dfwb10,dfje10" &
                    ",jfsl11,jfwb11,jfje11,dfsl11,dfwb11,dfje11" &
                    ",jfsl12,jfwb12,jfje12,dfsl12,dfwb12,dfje12" &
                    ",jfsl13,jfwb13,jfje13,dfsl13,dfwb13,dfje13)" &
                    " VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = rcDataset.Tables("sumkmyeb").Rows(i).Item("kjnd")
                rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("sumkmyeb").Rows(i).Item("kmdm")
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("sumkmyeb").Rows(i).Item("bmdm")
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = rcDataset.Tables("sumkmyeb").Rows(i).Item("zydm")
                rcOleDbCommand.Parameters.Add("@xmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("sumkmyeb").Rows(i).Item("xmdm")
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("sumkmyeb").Rows(i).Item("khdm")
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Me.TxtNewCsdm.Text
                rcOleDbCommand.Parameters.Add("@yhzh", OleDbType.VarChar, 12).Value = rcDataset.Tables("sumkmyeb").Rows(i).Item("yhzh")
                rcOleDbCommand.Parameters.Add("@jxzh", OleDbType.VarChar, 12).Value = rcDataset.Tables("sumkmyeb").Rows(i).Item("jxzh")
                rcOleDbCommand.Parameters.Add("@jd", OleDbType.VarChar, 4).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, "��", "��")
                rcOleDbCommand.Parameters.Add("@ncsl", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("ncsl"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("ncsl"))
                rcOleDbCommand.Parameters.Add("@ncwb", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("ncwb"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("ncwb"))
                rcOleDbCommand.Parameters.Add("@ncje", OleDbType.VarNumeric, 14).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje"))
                rcOleDbCommand.Parameters.Add("@jfsl01", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfsl01"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfsl01"))
                rcOleDbCommand.Parameters.Add("@jfwb01", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfwb01"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfwb01"))
                rcOleDbCommand.Parameters.Add("@jfje01", OleDbType.VarNumeric, 14).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfje01"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfje01"))
                rcOleDbCommand.Parameters.Add("@dfsl01", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfsl01"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfsl01"))
                rcOleDbCommand.Parameters.Add("@dfwb01", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfwb01"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfwb01"))
                rcOleDbCommand.Parameters.Add("@dfje01", OleDbType.VarNumeric, 14).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfje01"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfje01"))
                rcOleDbCommand.Parameters.Add("@jfsl02", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfsl02"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfsl02"))
                rcOleDbCommand.Parameters.Add("@jfwb02", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfwb02"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfwb02"))
                rcOleDbCommand.Parameters.Add("@jfje02", OleDbType.VarNumeric, 14).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfje02"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfje02"))
                rcOleDbCommand.Parameters.Add("@dfsl02", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfsl02"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfsl02"))
                rcOleDbCommand.Parameters.Add("@dfwb02", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfwb02"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfwb02"))
                rcOleDbCommand.Parameters.Add("@dfje02", OleDbType.VarNumeric, 14).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfje02"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfje02"))
                rcOleDbCommand.Parameters.Add("@jfsl03", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfsl03"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfsl03"))
                rcOleDbCommand.Parameters.Add("@jfwb03", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfwb03"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfwb03"))
                rcOleDbCommand.Parameters.Add("@jfje03", OleDbType.VarNumeric, 14).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfje03"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfje03"))
                rcOleDbCommand.Parameters.Add("@dfsl03", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfsl03"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfsl03"))
                rcOleDbCommand.Parameters.Add("@dfwb03", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfwb03"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfwb03"))
                rcOleDbCommand.Parameters.Add("@dfje03", OleDbType.VarNumeric, 14).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfje03"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfje03"))
                rcOleDbCommand.Parameters.Add("@jfsl04", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfsl04"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfsl04"))
                rcOleDbCommand.Parameters.Add("@jfwb04", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfwb04"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfwb04"))
                rcOleDbCommand.Parameters.Add("@jfje04", OleDbType.VarNumeric, 14).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfje04"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfje04"))
                rcOleDbCommand.Parameters.Add("@dfsl04", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfsl04"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfsl04"))
                rcOleDbCommand.Parameters.Add("@dfwb04", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfwb04"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfwb04"))
                rcOleDbCommand.Parameters.Add("@dfje04", OleDbType.VarNumeric, 14).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfje04"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfje04"))
                rcOleDbCommand.Parameters.Add("@jfsl05", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfsl05"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfsl05"))
                rcOleDbCommand.Parameters.Add("@jfwb05", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfwb05"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfwb05"))
                rcOleDbCommand.Parameters.Add("@jfje05", OleDbType.VarNumeric, 14).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfje05"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfje05"))
                rcOleDbCommand.Parameters.Add("@dfsl05", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfsl05"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfsl05"))
                rcOleDbCommand.Parameters.Add("@dfwb05", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfwb05"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfwb05"))
                rcOleDbCommand.Parameters.Add("@dfje05", OleDbType.VarNumeric, 14).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfje05"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfje05"))
                rcOleDbCommand.Parameters.Add("@jfsl06", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfsl06"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfsl06"))
                rcOleDbCommand.Parameters.Add("@jfwb06", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfwb06"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfwb06"))
                rcOleDbCommand.Parameters.Add("@jfje06", OleDbType.VarNumeric, 14).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfje06"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfje06"))
                rcOleDbCommand.Parameters.Add("@dfsl06", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfsl06"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfsl06"))
                rcOleDbCommand.Parameters.Add("@dfwb06", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfwb06"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfwb06"))
                rcOleDbCommand.Parameters.Add("@dfje06", OleDbType.VarNumeric, 14).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfje06"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfje06"))
                rcOleDbCommand.Parameters.Add("@jfsl07", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfsl07"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfsl07"))
                rcOleDbCommand.Parameters.Add("@jfwb07", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfwb07"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfwb07"))
                rcOleDbCommand.Parameters.Add("@jfje07", OleDbType.VarNumeric, 14).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfje07"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfje07"))
                rcOleDbCommand.Parameters.Add("@dfsl07", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfsl07"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfsl07"))
                rcOleDbCommand.Parameters.Add("@dfwb07", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfwb07"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfwb07"))
                rcOleDbCommand.Parameters.Add("@dfje07", OleDbType.VarNumeric, 14).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfje07"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfje07"))
                rcOleDbCommand.Parameters.Add("@jfsl08", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfsl08"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfsl08"))
                rcOleDbCommand.Parameters.Add("@jfwb08", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfwb08"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfwb08"))
                rcOleDbCommand.Parameters.Add("@jfje08", OleDbType.VarNumeric, 14).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfje08"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfje08"))
                rcOleDbCommand.Parameters.Add("@dfsl08", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfsl08"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfsl08"))
                rcOleDbCommand.Parameters.Add("@dfwb08", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfwb08"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfwb08"))
                rcOleDbCommand.Parameters.Add("@dfje08", OleDbType.VarNumeric, 14).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfje08"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfje08"))
                rcOleDbCommand.Parameters.Add("@jfsl09", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfsl09"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfsl09"))
                rcOleDbCommand.Parameters.Add("@jfwb09", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfwb09"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfwb09"))
                rcOleDbCommand.Parameters.Add("@jfje09", OleDbType.VarNumeric, 14).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfje09"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfje09"))
                rcOleDbCommand.Parameters.Add("@dfsl09", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfsl09"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfsl09"))
                rcOleDbCommand.Parameters.Add("@dfwb09", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfwb09"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfwb09"))
                rcOleDbCommand.Parameters.Add("@dfje09", OleDbType.VarNumeric, 14).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfje09"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfje09"))
                rcOleDbCommand.Parameters.Add("@jfsl10", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfsl10"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfsl10"))
                rcOleDbCommand.Parameters.Add("@jfwb10", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfwb10"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfwb10"))
                rcOleDbCommand.Parameters.Add("@jfje10", OleDbType.VarNumeric, 14).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfje10"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfje10"))
                rcOleDbCommand.Parameters.Add("@dfsl10", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfsl10"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfsl10"))
                rcOleDbCommand.Parameters.Add("@dfwb10", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfwb10"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfwb10"))
                rcOleDbCommand.Parameters.Add("@dfje10", OleDbType.VarNumeric, 14).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfje10"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfje10"))
                rcOleDbCommand.Parameters.Add("@jfsl11", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfsl11"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfsl11"))
                rcOleDbCommand.Parameters.Add("@jfwb11", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfwb11"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfwb11"))
                rcOleDbCommand.Parameters.Add("@jfje11", OleDbType.VarNumeric, 14).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfje11"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfje11"))
                rcOleDbCommand.Parameters.Add("@dfsl11", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfsl11"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfsl11"))
                rcOleDbCommand.Parameters.Add("@dfwb11", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfwb11"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfwb11"))
                rcOleDbCommand.Parameters.Add("@dfje11", OleDbType.VarNumeric, 14).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfje11"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfje11"))
                rcOleDbCommand.Parameters.Add("@jfsl12", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfsl12"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfsl12"))
                rcOleDbCommand.Parameters.Add("@jfwb12", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfwb12"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfwb12"))
                rcOleDbCommand.Parameters.Add("@jfje12", OleDbType.VarNumeric, 14).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfje12"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfje12"))
                rcOleDbCommand.Parameters.Add("@dfsl12", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfsl12"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfsl12"))
                rcOleDbCommand.Parameters.Add("@dfwb12", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfwb12"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfwb12"))
                rcOleDbCommand.Parameters.Add("@dfje12", OleDbType.VarNumeric, 14).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfje12"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfje12"))
                rcOleDbCommand.Parameters.Add("@jfsl13", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfsl13"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfsl13"))
                rcOleDbCommand.Parameters.Add("@jfwb13", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfwb13"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfwb13"))
                rcOleDbCommand.Parameters.Add("@jfje13", OleDbType.VarNumeric, 14).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("jfje13"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("jfje13"))
                rcOleDbCommand.Parameters.Add("@dfsl13", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfsl13"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfsl13"))
                rcOleDbCommand.Parameters.Add("@dfwb13", OleDbType.VarNumeric, 18).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfwb13"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfwb13"))
                rcOleDbCommand.Parameters.Add("@dfje13", OleDbType.VarNumeric, 14).Value = IIf(rcDataset.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataset.Tables("sumkmyeb").Rows(i).Item("dfje13"), 0 - rcDataset.Tables("sumkmyeb").Rows(i).Item("dfje13"))
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
        '����ҵ���Ĺ�Ӧ�̱���
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            For i = 0 To rcDataSet.Tables("user_tab_columns").Rows.Count - 1
                rcOleDbCommand.CommandText = "UPDATE " & rcDataSet.Tables("user_tab_columns").Rows(i).Item("table_name") & " SET csdm = ? WHERE csdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtNewCsdm.Text)
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtOldCsdm.Text)
                rcOleDbCommand.ExecuteNonQuery()
            Next
            'PO_CSCPCGDJ
            rcOleDbCommand.CommandText = "SELECT COUNT(*) AS gs FROM po_cscpcgdj WHERE csdm = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(TxtNewCsdm.Text)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("newcgdj") IsNot Nothing Then
                rcDataSet.Tables("newcgdj").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "newcgdj")
            rcOleDbCommand.CommandText = "SELECT COUNT(*) AS gs FROM po_cscpcgdj WHERE csdm = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(TxtOldCsdm.Text)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("oldcgdj") IsNot Nothing Then
                rcDataSet.Tables("oldcgdj").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "oldcgdj")
            If rcDataSet.Tables("newcgdj").Rows(0).Item("gs") > 0 And rcDataSet.Tables("oldcgdj").Rows(0).Item("gs") > 0 Then
                'ɾ���ɵĲɹ��۸���Ϣ
                rcOleDbCommand.CommandText = "DELETE FROM po_cscpcgdj WHERE csdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@parentcsdm", OleDbType.VarChar, 12).Value = Trim(TxtOldCsdm.Text)
                rcOleDbCommand.ExecuteNonQuery()
            Else
                rcOleDbCommand.CommandText = "UPDATE po_cscpcgdj SET csdm = ? WHERE csdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(TxtNewCsdm.Text)
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(TxtOldCsdm.Text)
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
        '(12)rc_csxx(��Ҫɾ��/�����)
        If rcDataSet.Tables("newcsxx").Rows.Count > 0 Then
            'ɾ���ɱ���
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "DELETE From rc_csxx Where csdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtOldCsdm.Text)
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
                rcOleDbCommand.CommandText = "UPDATE rc_csxx SET csdm = ? WHERE csdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtNewCsdm.Text)
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtOldCsdm.Text)
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
            rcOleDbCommand.CommandText = "INSERT INTO rc_csdmtz (tzrq,oldcsdm,oldcsmc,newcsdm,newcsmc,ynhb,srr) VALUES (?,?,?,?,?,?,?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@tzrq", OleDbType.Date, 8).Value = Now.Date
            rcOleDbCommand.Parameters.Add("@oldcsdm", OleDbType.VarChar, 12).Value = Me.TxtOldCsdm.Text
            rcOleDbCommand.Parameters.Add("@oldcsmc", OleDbType.VarChar, 40).Value = Me.TxtOldCsmc.Text
            rcOleDbCommand.Parameters.Add("@newcsdm", OleDbType.VarChar, 12).Value = Me.TxtNewCsdm.Text
            rcOleDbCommand.Parameters.Add("@newcsmc", OleDbType.VarChar, 40).Value = Me.TxtNewCsmc.Text
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
        MsgBox("������ϲ���Ӧ�̱�����ɡ�" & Chr(13) & "��������������Ӧ�ա�Ӧ���ȵ�������ȷ�ԡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
        Me.TxtOldCsdm.Text = ""
        Me.TxtNewCsdm.Text = ""
        Me.TxtOldCsmc.Text = ""
        Me.TxtNewCsmc.Text = ""
        Me.TxtOldCsdm.Focus()
    End Sub

End Class