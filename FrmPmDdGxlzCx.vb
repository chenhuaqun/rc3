Imports System.Data.OleDb

Public Class FrmPmDdGxlzCx

#Region "�������"

    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

#End Region

#Region "��ʼ���¼�"
    Private Sub FrmPmDdGxlzCx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Ĭ��ֵ
        Me.DtpQdrqBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        Me.DtpQdrqEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
    End Sub

#End Region

#Region "�ؼ��س����Ĵ���"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpQdrqBegin.KeyPress, DtpQdrqEnd.KeyPress, NudDjhBegin.KeyPress, NudDjhEnd.KeyPress, TxtCpdm.KeyPress, TxtCpmc.KeyPress, TxtSczydm.KeyPress, TxtHth.KeyPress, TxtKhdm.KeyPress, TxtZydm.KeyPress
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

#Region "�н����¼�"

    Private Sub TxtSczydm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSczydm.KeyDown
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
                        TxtSczydm.Text = Trim(.paraField1)
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

#Region "ȷ���¼�"

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        ''ȡ����
        rcOleDbConn.Open()
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            If Me.RadioBtnQdrq.Checked Then
                rcOleDbCommand.CommandText = "SELECT oe_dd.djh,oe_dd.xh,oe_dd.qdrq,oe_dd.hth,oe_dd.khdm,oe_dd.khmc,oe_dd.zydm,oe_dd.zymc,oe_dd.ddtk,oe_dd.cpdm,oe_dd.cpmc,oe_dd.dw,oe_dd.sl,oe_dd.dj,oe_dd.je,oe_dd.bzcb,oe_dd.khjhrq,oe_dd.zxgg,oe_dd.ddmemo,oe_dd.scjhrq,oe_dd.fhrq,oe_dd.sczydm,oe_dd.sczymc,oe_dd.srr,oe_dd.shr,(CASE WHEN oe_dd.zt = 3 THEN '�����' ELSE CASE WHEN oe_dd.zt = 4 THEN '������' ELSE CASE WHEN oe_dd.zt = 5 THEN '�ѳ���' ELSE CASE WHEN oe_dd.zt = 6 THEN '�ѿ�Ʊ' ELSE 'δ���' END END END END) AS zt,oe_dd.hxsl,oe_dd.rksl,oe_dd.cerk,oe_dd.cksl,oe_dd.ceck,oe_dd.fpsl,oe_dd.srr,oe_dd.shr FROM oe_dd,rc_cpxx WHERE oe_dd.cpdm = rc_cpxx.cpdm" & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " and oe_dd.cpdm LIKE '" & Trim(TxtCpdm.Text) & "%'", "") & IIf(TxtZydm.TextLength > 0, " and oe_dd.zydm LIKE '" & TxtZydm.Text & "%'", "") & IIf(TxtHth.TextLength > 0, " and oe_dd.hth LIKE '" & TxtHth.Text & "%'", "") & IIf(Trim(TxtKhdm.Text).Length > 0, " and oe_dd.khdm LIKE '" & LTrim(TxtKhdm.Text) & "%'", "") & IIf(Trim(Me.TxtKhmc.Text).Length > 0, " and oe_dd.khmc LIKE '%" & Trim(Me.TxtKhmc.Text) & "%'", "") & IIf(Trim(TxtSczydm.Text).Length > 0, " and oe_dd.sczydm LIKE '" & TxtSczydm.Text & "%'", "") & IIf(Trim(TxtCpmc.Text).Length > 0, " AND oe_dd.cpmc Like '%" & Trim(Me.TxtCpmc.Text) & "%'", "") & " and qdrq >= ? AND qdrq <= ? AND SUBSTR(oe_dd.djh,11,5) >= ? AND SUBSTR(oe_dd.djh,11,5) <= ? ORDER BY oe_dd.djh,oe_dd.xh"
            Else
                rcOleDbCommand.CommandText = "SELECT oe_dd.djh,oe_dd.xh,oe_dd.qdrq,oe_dd.hth,oe_dd.khdm,oe_dd.khmc,oe_dd.zydm,oe_dd.zymc,oe_dd.ddtk,oe_dd.cpdm,oe_dd.cpmc,oe_dd.dw,oe_dd.sl,oe_dd.dj,oe_dd.je,oe_dd.bzcb,oe_dd.khjhrq,oe_dd.zxgg,oe_dd.ddmemo,oe_dd.scjhrq,oe_dd.fhrq,oe_dd.sczydm,oe_dd.sczymc,oe_dd.srr,oe_dd.shr,(CASE WHEN oe_dd.zt = 3 THEN '�����' ELSE CASE WHEN oe_dd.zt = 4 THEN '������' ELSE CASE WHEN oe_dd.zt = 5 THEN '�ѳ���' ELSE CASE WHEN oe_dd.zt = 6 THEN '�ѿ�Ʊ' ELSE 'δ���' END END END END) AS zt,oe_dd.hxsl,oe_dd.rksl,oe_dd.cerk,oe_dd.cksl,oe_dd.ceck,oe_dd.fpsl,oe_dd.srr,oe_dd.shr FROM oe_dd,rc_cpxx WHERE oe_dd.cpdm = rc_cpxx.cpdm" & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " and oe_dd.cpdm LIKE '" & Trim(TxtCpdm.Text) & "%'", "") & IIf(TxtZydm.TextLength > 0, " and oe_dd.zydm LIKE '" & TxtZydm.Text & "%'", "") & IIf(TxtHth.TextLength > 0, " and oe_dd.hth LIKE '" & TxtHth.Text & "%'", "") & IIf(Trim(TxtKhdm.Text).Length > 0, " and oe_dd.khdm LIKE '" & LTrim(TxtKhdm.Text) & "%'", "") & IIf(Trim(Me.TxtKhmc.Text).Length > 0, " and oe_dd.khmc LIKE '%" & Trim(Me.TxtKhmc.Text) & "%'", "") & IIf(Trim(TxtSczydm.Text).Length > 0, " and oe_dd.sczydm LIKE '" & TxtSczydm.Text & "%'", "") & IIf(Trim(TxtCpmc.Text).Length > 0, " AND oe_dd.cpmc Like '%" & Trim(Me.TxtCpmc.Text) & "%'", "") & " and (scjhrq >= ? AND scjhrq <= ? OR scjhrq IS NULL) AND SUBSTR(oe_dd.djh,11,5) >= ?  AND SUBSTR(oe_dd.djh,11,5) <= ? ORDER BY oe_dd.djh,oe_dd.xh"
            End If
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@qdrq1", OleDbType.Date, 8).Value = DtpQdrqBegin.Value
            rcOleDbCommand.Parameters.Add("@qdrq2", OleDbType.Date, 8).Value = DtpQdrqEnd.Value
            rcOleDbCommand.Parameters.Add("@djh1", OleDbType.VarChar, 5).Value = NudDjhBegin.Value.ToString.PadLeft(5, "0")
            rcOleDbCommand.Parameters.Add("@djh2", OleDbType.VarChar, 5).Value = NudDjhEnd.Value.ToString.PadLeft(5, "0")
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("ddlb") IsNot Nothing Then
                rcDataset.Tables("ddlb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "ddlb")
        Catch ex As Exception
            MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("ddlb").Rows.Count <= 0 Then
            MsgBox("û���������������ݡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        Dim rcDataRow As DataRow
        rcDataRow = rcDataset.Tables("ddlb").NewRow
        rcDataRow.Item("djh") = "�ϼ�"
        rcDataRow.Item("sl") = rcDataset.Tables("ddlb").Compute("Sum(sl)", "")
        rcDataRow.Item("je") = rcDataset.Tables("ddlb").Compute("Sum(je)", "")
        rcDataset.Tables("ddlb").Rows.Add(rcDataRow)
        '���ñ�
        Dim rcFrm As New FrmOeDdCxLb
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("ddlb"), "TRUE", "djh,xh", DataViewRowState.CurrentRows)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With

    End Sub

#End Region

End Class