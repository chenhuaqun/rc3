Imports System.Data.OleDb

Public Class FrmPmRkdCx

#Region "�������"

    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

#End Region

#Region "��ʼ���¼�"

    Private Sub FrmPmRkdCx_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Ĭ��ֵ
        Me.DtpRkrqBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        Me.DtpRkrqEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        'ȡ������������
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE kjnd = ? AND lxgs = '������ⵥ' ORDER BY pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_lx") IsNot Nothing Then
                Me.rcDataset.Tables("rc_lx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_lx")
        Catch ex As Exception
            MsgBox("������󡣶�ȡ�������͡�" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Dim rcDataRow As DataRow
        rcDataRow = rcDataset.Tables("rc_lx").NewRow
        rcDataRow.Item("pzlxdm") = "0000"
        rcDataRow.Item("pzlxjc") = "ȫ������"
        rcDataset.Tables("rc_lx").Rows.Add(rcDataRow)
        If rcDataset.Tables("rc_lx").Rows.Count = 0 Then
            MsgBox("�붨�嵥�����͡�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        BindDropDownList(CmbPzlxjc, rcDataset.Tables("rc_lx"), "pzlxdm", "pzlxjc")
        CmbPzlxjc.SelectedValue = "0000"
    End Sub

#End Region

#Region "�ؼ��س����Ĵ���"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpRkrqBegin.KeyPress, DtpRkrqEnd.KeyPress, NudDjhBegin.KeyPress, NudDjhEnd.KeyPress, TxtCpdm.KeyPress, TxtCpmc.KeyPress, TxtHth.KeyPress, TxtKhdm.KeyPress, TxtZydm.KeyPress, TxtBmdm.KeyPress, TxtCkdm.KeyPress, ChbLbfs.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "���ϱ����¼�"

    Private Sub TxtCpdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCpdm.KeyDown
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
                        Me.TxtCpdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

#End Region

#Region "���������¼�"

    Private Sub TxtCpmc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCpmc.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

#End Region

#Region "���������¼�"

    Private Sub TxtHth_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtHth.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
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

#Region "ҵ��Ա�¼�"

    Private Sub TxtZydm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtZydm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_zyxx"
                    .paraField1 = "zydm"
                    .paraField2 = "zymc"
                    .paraField3 = "zysm"
                    .paraOrderField = "zydm"
                    .paraTitle = "ְԱ"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtZydm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
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
                TxtBmdm.Text = Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmdm"))
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
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
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
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "���������¼�"

    Private Sub TxtGxdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtGxdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_gxxx"
                    .paraField1 = "gxdm"
                    .paraField2 = "gxmc"
                    .paraField3 = "gxsm"
                    .paraTitle = "����"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtGxdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtGxdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtGxdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtGxdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_gxxx WHERE (gxdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@gxdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtGxdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_gxxx") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_gxxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_gxxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_gxxx").Rows.Count > 0 Then
                Me.TxtGxdm.Text = Trim(rcDataSet.Tables("rc_gxxx").Rows(0).Item("gxdm"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "�б�ʽ�¼�"

    Private Sub ChbLbfs_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbLbfs.CheckedChanged
        If Me.ChbLbfs.Checked Then
            Me.TxtCpdm.Enabled = True
            Me.TxtCpmc.Enabled = True
            Me.TxtKhdm.Enabled = True
            Me.TxtHth.Enabled = True
        Else
            Me.TxtCpdm.Enabled = False
            Me.TxtCpmc.Enabled = False
            Me.TxtKhdm.Enabled = False
            Me.TxtHth.Enabled = False
            Me.TxtCpdm.Text = ""
            Me.TxtCpmc.Text = ""
            Me.TxtKhdm.Text = ""
            Me.TxtHth.Text = ""
        End If
    End Sub

#End Region

#Region "ȷ���¼�"

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If Me.ChbLbfs.Checked Then
            ''ȡ����
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT inv_rkd.djh,inv_rkd.xh,TRUNC(inv_rkd.rkrq,'mi') AS rkrq,inv_rkd.bdelete,inv_rkd.zydm,inv_rkd.zymc,inv_rkd.bmdm,inv_rkd.bmmc,inv_rkd.gxdm,inv_rkd.gxmc,inv_rkd.ckdm,inv_rkd.ckmc,inv_rkd.cpdm,inv_rkd.cpmc,inv_rkd.hth,inv_rkd.scph,inv_rkd.khdm,inv_rkd.khmc,inv_rkd.sl,inv_rkd.dw,inv_rkd.mjsl,inv_rkd.fzsl,inv_rkd.fzdw,inv_rkd.rgdj,inv_rkd.rgcb,inv_rkd.dj,inv_rkd.je,inv_rkd.rkmemo,inv_rkd.srr,inv_rkd.shr,inv_rkd.jzr FROM inv_rkd,rc_lx WHERE SUBSTR(inv_rkd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(inv_rkd.djh,5,4) = rc_lx.kjnd AND lxgs = '������ⵥ' AND rkrq >= ? AND rkrq <= ? AND SUBSTR(inv_rkd.djh,11,5) >= ?  AND SUBSTR(inv_rkd.djh,11,5) <= ?" & IIf(Me.CmbPzlxjc.SelectedValue <> "0000", " AND SUBSTR(inv_rkd.djh,1, 4) ='" & Me.CmbPzlxjc.SelectedValue & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " and inv_rkd.cpdm LIKE '" & Trim(TxtCpdm.Text) & "%'", "") & IIf(TxtZydm.TextLength > 0, " and inv_rkd.zydm LIKE '" & TxtZydm.Text & "%'", "") & IIf(TxtBmdm.TextLength > 0, " and inv_rkd.bmdm = '" & TxtBmdm.Text & "'", "") & IIf(TxtCkdm.TextLength > 0, " and inv_rkd.ckdm = '" & TxtCkdm.Text & "'", "") & IIf(TxtGxdm.TextLength > 0, " and inv_rkd.gxdm = '" & TxtGxdm.Text & "'", "") & IIf(TxtHth.TextLength > 0, " and inv_rkd.hth LIKE '" & TxtHth.Text & "%'", "") & IIf(Trim(TxtKhdm.Text).Length > 0, " and inv_rkd.khdm LIKE '" & LTrim(TxtKhdm.Text) & "%'", "") & IIf(Trim(TxtCpmc.Text).Length > 0, " AND inv_rkd.cpmc Like '%" & Trim(Me.TxtCpmc.Text) & "%'", "") & " ORDER BY inv_rkd.djh,inv_rkd.xh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@rkrq1", OleDbType.Date, 8).Value = DtpRkrqBegin.Value
                rcOleDbCommand.Parameters.Add("@rkrq2", OleDbType.Date, 8).Value = DtpRkrqEnd.Value
                rcOleDbCommand.Parameters.Add("@djh1", OleDbType.VarChar, 5).Value = NudDjhBegin.Value.ToString.PadLeft(5, "0")
                rcOleDbCommand.Parameters.Add("@djh2", OleDbType.VarChar, 5).Value = NudDjhEnd.Value.ToString.PadLeft(5, "0")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rkdlb") IsNot Nothing Then
                    rcDataset.Tables("rkdlb").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rkdlb")
            Catch ex As Exception
                MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rkdlb").Rows.Count <= 0 Then
                MsgBox("û���������������ݡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            End If
            Dim rcDataRow As DataRow
            rcDataRow = rcDataset.Tables("rkdlb").NewRow
            rcDataRow.Item("djh") = "�ϼ�"
            rcDataRow.Item("sl") = rcDataset.Tables("rkdlb").Compute("Sum(sl)", "")
            rcDataRow.Item("je") = rcDataset.Tables("rkdlb").Compute("Sum(je)", "")
            rcDataset.Tables("rkdlb").Rows.Add(rcDataRow)
            '���ñ�
            Dim rcFrm As New FrmPmRkdCxLb
            With rcFrm
                .ParaDataSet = rcDataset
                .ParaDataView = New DataView(rcDataset.Tables("rkdlb"), "TRUE", "djh,xh", DataViewRowState.CurrentRows)
                .WindowState = FormWindowState.Maximized
                .MdiParent = Me.MdiParent
                .Show()
            End With

        Else
            'ȡ����
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT djh FROM inv_rkd,rc_lx WHERE SUBSTR(inv_rkd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(inv_rkd.djh,5,4) = rc_lx.kjnd AND lxgs = '������ⵥ' AND rkrq >= ? AND rkrq <= ? AND SUBSTR(djh,11,5) >= ?  AND SUBSTR(djh,11,5) <= ?" & IIf(Me.CmbPzlxjc.SelectedValue <> "0000", " AND SUBSTR(inv_rkd.djh,1, 4) ='" & Me.CmbPzlxjc.SelectedValue & "'", "") & IIf(Me.TxtZydm.TextLength > 0, " and inv_rkd.zydm = '" & TxtZydm.Text & "'", "") & IIf(TxtBmdm.TextLength > 0, " and inv_rkd.bmdm = '" & TxtBmdm.Text & "'", "") & IIf(TxtCkdm.TextLength > 0, " and inv_rkd.ckdm = '" & TxtCkdm.Text & "'", "") & " GROUP BY inv_rkd.djh ORDER BY inv_rkd.djh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@rkrq1", OleDbType.Date, 8).Value = DtpRkrqBegin.Value
                rcOleDbCommand.Parameters.Add("@rkrq2", OleDbType.Date, 8).Value = DtpRkrqEnd.Value
                rcOleDbCommand.Parameters.Add("@djh1", OleDbType.VarChar, 5).Value = NudDjhBegin.Value.ToString.PadLeft(5, "0")
                rcOleDbCommand.Parameters.Add("@djh2", OleDbType.VarChar, 5).Value = NudDjhEnd.Value.ToString.PadLeft(5, "0")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rkdml") IsNot Nothing Then
                    rcDataset.Tables("rkdml").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rkdml")
            Catch ex As Exception
                MsgBox("�������asd��" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rkdml").Rows.Count <= 0 Then
                MsgBox("û���������������ݡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            End If
            '���ñ�
            Dim rcFrm As New FrmPmRkdCxz
            With rcFrm
                .ParaDataSet = rcDataset
                .WindowState = FormWindowState.Maximized
                .MdiParent = Me.MdiParent
                .Show()
            End With
        End If
    End Sub

#End Region

End Class