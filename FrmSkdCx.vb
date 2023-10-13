Imports System.Data.OleDb

Public Class FrmSkdCx

#Region "�������"

    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

#End Region

#Region "��ʼ���¼�"

    Private Sub FrmSkdCx_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Ĭ��ֵ
        Me.DtpBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        Me.DtpEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
    End Sub

#End Region

#Region "�ؼ��س����Ĵ���"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpBegin.KeyPress, DtpEnd.KeyPress, NudDjhBegin.KeyPress, NudDjhEnd.KeyPress, TxtKhdm.KeyPress, TxtJsfsdm.KeyPress, TxtKmdm.KeyPress, TxtYspz.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
        End Select
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

#End Region

#Region "���㷽ʽ�¼�"

    Private Sub TxtJsfsdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtJsfsdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_jsfs"
                    .paraField1 = "jsfsdm"
                    .paraField2 = "jsfsmc"
                    .paraField3 = "jsfssm"
                    .paraCondition = "0=0"
                    .paraOrderField = "jsfsdm"
                    .paraTitle = "���㷽ʽ"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtJsfsdm.Text = Trim(.paraField1)
                        'LblJsfsmc.Text = Trim(.paraField2)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtJsfsdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtJsfsdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtJsfsdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_jsfs WHERE jsfsdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@jsfsdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtJsfsdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_jsfs") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_jsfs").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_jsfs")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_jsfs").Rows.Count > 0 Then
                TxtJsfsdm.Text = Trim(rcDataset.Tables("rc_jsfs").Rows(0).Item("jsfsdm"))
                'LblJsfsmc.Text = rcDataSet.Tables("rc_jsfs").Rows(0).Item("jsfsmc")
            Else
                MsgBox("���벻���ڡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                e.Cancel = True
                Return
            End If
        End If
    End Sub

#End Region

#Region "��Ŀ������¼�"

    Private Sub TxtKmdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtKmdm.KeyDown
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
                        TxtKmdm.Text = Trim(.paraField1)
                        'LblKmmc.Text = Trim(.paraField2)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtKmdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtKmdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtKmdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM gl_kmxx WHERE (kmdm = ?) AND NOT EXISTS (SELECT 1 FROM gl_kmxx aa WHERE aa.parentid = gl_kmxx.kmdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKmdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("gl_kmxx") IsNot Nothing Then
                    Me.rcDataset.Tables("gl_kmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "gl_kmxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("gl_kmxx").Rows.Count > 0 Then
                TxtKmdm.Text = Trim(rcDataSet.Tables("gl_kmxx").Rows(0).Item("kmdm"))
                'LblKmmc.Text = rcDataSet.Tables("gl_kmxx").Rows(0).Item("kmmc")
            Else
                MsgBox("��Ŀ���벻���ڻ����ϸ��Ŀ��", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                e.Cancel = True
                Return
            End If
        End If
    End Sub

#End Region

#Region "δ�����¼�"

    Private Sub ChbWhx_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbWhx.CheckedChanged
        If Me.ChbWhx.Checked Then
            Me.DtpBegin.Enabled = False
            Me.DtpEnd.Enabled = False
            Me.NudDjhBegin.Enabled = False
            Me.NudDjhEnd.Enabled = False
        Else
            Me.DtpBegin.Enabled = True
            Me.DtpEnd.Enabled = True
            Me.NudDjhBegin.Enabled = True
            Me.NudDjhEnd.Enabled = True
        End If
    End Sub

#End Region

#Region "ȷ���¼�"

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        ''ȡ����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT ar_skd.djh,ar_skd.skrq,ar_skd.khdm,ar_skd.khmc,ar_skd.jsfsdm,ar_skd.jsfsmc,ar_skd.kmdm,ar_skd.kmmc,ar_skd.yspz,ar_skd.je,ar_skd.xsje,ar_skd.skmemo,ar_skd.srr,ar_skd.shr,ar_skd.jzr FROM ar_skd WHERE" & IIf(Me.ChbWhx.Checked, " ar_skd.je <> ar_skd.xsje", " ar_skd.skrq >= ? AND ar_skd.skrq <= ? AND SUBSTR(ar_skd.djh,11,5) >= ?  AND SUBSTR(ar_skd.djh,11,5) <= ?") & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " and ar_skd.khdm LIKE '" & LTrim(Me.TxtKhdm.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtJsfsdm.Text), " and ar_skd.jsfsdm = '" & LTrim(Me.TxtJsfsdm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtKmdm.Text), " and ar_skd.kmdm LIKE '" & LTrim(Me.TxtKmdm.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtYspz.Text), " and ar_skd.yspz LIKE '" & LTrim(Me.TxtYspz.Text) & "%'", "") & " ORDER BY ar_skd.djh"
            rcOleDbCommand.Parameters.Clear()
            If Not Me.ChbWhx.Checked Then
                rcOleDbCommand.Parameters.Add("@skrq1", OleDbType.Date, 8).Value = DtpBegin.Value
                rcOleDbCommand.Parameters.Add("@skrq2", OleDbType.Date, 8).Value = DtpEnd.Value
                rcOleDbCommand.Parameters.Add("@djh1", OleDbType.VarChar, 5).Value = NudDjhBegin.Value.ToString.PadLeft(5, "0")
                rcOleDbCommand.Parameters.Add("@djh2", OleDbType.VarChar, 5).Value = NudDjhEnd.Value.ToString.PadLeft(5, "0")
            End If
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("skdlb") IsNot Nothing Then
                rcDataset.Tables("skdlb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "skdlb")
        Catch ex As Exception
            MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("skdlb").Rows.Count <= 0 Then
            MsgBox("û���������������ݡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        '���ñ�
        Dim rcFrm As New FrmSkdCxLb
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("skdlb"), "TRUE", "djh", DataViewRowState.CurrentRows)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

#End Region
End Class