Imports System.Data.OleDb

Public Class FrmOeFpCx

#Region "�������"

    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

#End Region

#Region "��ʼ���¼�"

    Private Sub FrmOeFpCx_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Ĭ��ֵ
        Me.DtpBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        Me.DtpEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        'ȡ������������
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE kjnd = ? AND lxgs = '��Ʒ���۵�' ORDER BY pzlxdm"
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

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpBegin.KeyPress, DtpEnd.KeyPress, CmbPzlxjc.KeyPress, NudDjhBegin.KeyPress, NudDjhEnd.KeyPress, TxtCpdm.KeyPress, TxtCpmc.KeyPress, TxtHth.KeyPress, TxtKhdm.KeyPress, TxtYspz.KeyPress, TxtZydm.KeyPress, ChbLbfs.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "��Ʒ�����¼�"

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
        End Select
    End Sub

#End Region

#Region "������������¼�"

    Private Sub Txtlbdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLbdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_cplb"
                    .paraField1 = "lbdm"
                    .paraField2 = "lbmc"
                    .paraField3 = "lbsm"
                    .paraTitle = "�������"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtLbdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub Txtlbdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtLbdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtLbdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_cplb WHERE (lbdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = Trim(TxtLbdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_cplb") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_cplb").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_cplb")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_cplb").Rows.Count <= 0 Then
                e.Cancel = True
            End If
        End If
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
        End Select
    End Sub

#End Region

    Private Sub ChbYjWsk_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbYjWsk.CheckedChanged
        '�½�δ�տ�
        If Me.ChbYjWsk.Checked Or Me.ChbWsk.Checked Then
            Me.DtpBegin.Enabled = False
            Me.DtpEnd.Enabled = False
        Else
            Me.DtpBegin.Enabled = True
            Me.DtpEnd.Enabled = True
        End If
        If Me.ChbYjWsk.Checked Then
            Me.ChbWsk.Checked = False
            Me.ChbDelete.Checked = False
            Me.ChbLbfs.Checked = True
        End If
    End Sub

    Private Sub ChbWsk_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbWsk.CheckedChanged
        'ȫδ�տ�
        If Me.ChbYjWsk.Checked Or Me.ChbWsk.Checked Then
            Me.DtpEnd.Enabled = False
            Me.DtpBegin.Enabled = False
        Else
            Me.DtpBegin.Enabled = True
            Me.DtpEnd.Enabled = True
        End If
        If Me.ChbWsk.Checked Then
            Me.ChbYjWsk.Checked = False
            Me.ChbDelete.Checked = False
            Me.ChbLbfs.Checked = True
        End If
    End Sub

#Region "�б�ʽ�¼�"

    Private Sub ChbLbfs_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbLbfs.CheckedChanged
        If Me.ChbLbfs.Checked Then
            Me.TxtCpdm.Enabled = True
            Me.TxtCpmc.Enabled = True
        Else
            Me.TxtCpdm.Enabled = False
            Me.TxtCpmc.Enabled = False
            Me.ChbYjWsk.Checked = False
            Me.TxtCpdm.Text = ""
            Me.TxtCpmc.Text = ""
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
                If Me.ChbYjWsk.Checked Then
                    rcOleDbCommand.CommandText = "SELECT oe_fpa.*,oe_dd.sktj,oe_dd.skqx FROM (SELECT oe_fp.djh,oe_fp.xh,oe_fp.fprq,oe_fp.bdelete,oe_fp.zydm,oe_fp.zymc,oe_fp.khdm,oe_fp.khmc,oe_fp.yspz,oe_fp.cpdm,oe_fp.cpmc,oe_fp.hth,oe_fp.sl,oe_fp.dw,oe_fp.mjsl,oe_fp.fzsl,oe_fp.fzdw,oe_fp.dj,oe_fp.hsdj,oe_fp.je,oe_fp.shlv,oe_fp.se,oe_fp.je + oe_fp.se AS jese,oe_fp.skje,oe_fp.fpmemo,oe_fp.dddjh,oe_fp.ddxh,oe_fp.xsddjh,oe_fp.xsdxh,oe_fp.xsddj,oe_fp.xsdhsdj,oe_fp.xsdje,oe_fp.xsdshlv,oe_fp.xsdse,oe_fp.je -  oe_fp.xsdje AS xsdjece,oe_fp.se - oe_fp.xsdse AS xsdsece,oe_fp.srr,oe_fp.srrq,oe_fp.shr,oe_fp.shrq,oe_fp.jzr FROM rc_cpxx,oe_fp,rc_lx WHERE rc_cpxx.cpdm = oe_fp.cpdm AND SUBSTR(oe_fp.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_fp.djh,5,4) = rc_lx.kjnd AND lxgs = '��Ʒ���۵�'" & IIf(Me.ChbDelete.Checked, "", " AND oe_fp.bdelete = 0") & IIf(Trim(Me.TxtLbdm.Text).Length > 0, " and rc_cpxx.lbdm = '" & Trim(Me.TxtLbdm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " and oe_fp.cpdm LIKE '" & Trim(TxtCpdm.Text) & "%'", "") & IIf(TxtZydm.TextLength > 0, " and oe_fp.zydm LIKE '" & TxtZydm.Text & "%'", "") & IIf(TxtHth.TextLength > 0, " and oe_fp.hth LIKE '" & TxtHth.Text & "%'", "") & IIf(Trim(TxtKhdm.Text).Length > 0, " and oe_fp.khdm LIKE '" & LTrim(TxtKhdm.Text) & "%'", "") & IIf(Trim(TxtYspz.Text).Length > 0, " and oe_fp.yspz LIKE '" & LTrim(TxtYspz.Text) & "%'", "") & IIf(Trim(TxtCpmc.Text).Length > 0, " AND oe_fp.cpmc Like '%" & Trim(Me.TxtCpmc.Text) & "%'", "") & IIf(Me.ChbYjWsk.Checked, " AND oe_fp.je + oe_fp.se  <> oe_fp.skje", "") & ") oe_fpa,oe_dd WHERE oe_fpa.ddxh = oe_dd.xh AND oe_fpa.dddjh = oe_dd.djh AND oe_dd.sktj = '�½�' AND oe_fpa.je + oe_fpa.se <> oe_fpa.skje AND oe_fpa.fprq + oe_dd.skqx < SYSDATE ORDER BY oe_fpa.djh,oe_fpa.xh"
                Else
                    If ChbWsk.Checked Then
                        rcOleDbCommand.CommandText = "SELECT oe_fp.djh,oe_fp.xh,oe_fp.fprq,oe_fp.bdelete,oe_fp.zydm,oe_fp.zymc,oe_fp.khdm,oe_fp.khmc,oe_fp.yspz,oe_fp.cpdm,oe_fp.cpmc,oe_fp.hth,oe_fp.sl,oe_fp.dw,oe_fp.mjsl,oe_fp.fzsl,oe_fp.fzdw,oe_fp.dj,oe_fp.hsdj,oe_fp.je,oe_fp.shlv,oe_fp.se,oe_fp.je + oe_fp.se AS jese,oe_fp.skje,oe_fp.fpmemo,oe_fp.dddjh,oe_fp.ddxh,oe_fp.xsddjh,oe_fp.xsdxh,oe_fp.xsddj,oe_fp.xsdhsdj,oe_fp.xsdje,oe_fp.xsdshlv,oe_fp.xsdse,oe_fp.je -  oe_fp.xsdje AS xsdjece,oe_fp.se - oe_fp.xsdse AS xsdsece,oe_fp.srr,oe_fp.srrq,oe_fp.shr,oe_fp.shrq,oe_fp.jzr FROM rc_cpxx,oe_fp,rc_lx WHERE rc_cpxx.cpdm = oe_fp.cpdm AND SUBSTR(oe_fp.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_fp.djh,5,4) = rc_lx.kjnd AND lxgs = '��Ʒ���۵�'" & IIf(Me.ChbDelete.Checked, "", " AND oe_fp.bdelete = 0") & IIf(Trim(Me.TxtLbdm.Text).Length > 0, " and rc_cpxx.lbdm = '" & Trim(Me.TxtLbdm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " and oe_fp.cpdm LIKE '" & Trim(TxtCpdm.Text) & "%'", "") & IIf(TxtZydm.TextLength > 0, " and oe_fp.zydm LIKE '" & TxtZydm.Text & "%'", "") & IIf(TxtHth.TextLength > 0, " and oe_fp.hth LIKE '" & TxtHth.Text & "%'", "") & IIf(Trim(TxtKhdm.Text).Length > 0, " and oe_fp.khdm LIKE '" & LTrim(TxtKhdm.Text) & "%'", "") & IIf(Trim(TxtYspz.Text).Length > 0, " and oe_fp.yspz LIKE '" & LTrim(TxtYspz.Text) & "%'", "") & IIf(Trim(TxtCpmc.Text).Length > 0, " AND oe_fp.cpmc Like '%" & Trim(Me.TxtCpmc.Text) & "%'", "") & IIf(Me.ChbWsk.Checked, " AND oe_fp.je + oe_fp.se <> oe_fp.skje", "")
                    Else
                        rcOleDbCommand.CommandText = "SELECT oe_fpa.*,oe_xsd.cbje FROM (SELECT oe_fp.djh,oe_fp.xh,oe_fp.fprq,oe_fp.bdelete,oe_fp.zydm,oe_fp.zymc,oe_fp.khdm,oe_fp.khmc,oe_fp.yspz,oe_fp.cpdm,oe_fp.cpmc,oe_fp.hth,oe_fp.sl,oe_fp.dw,oe_fp.mjsl,oe_fp.fzsl,oe_fp.fzdw,oe_fp.dj,oe_fp.hsdj,oe_fp.je,oe_fp.shlv,oe_fp.se,oe_fp.je + oe_fp.se AS jese,oe_fp.skje,oe_fp.fpmemo,oe_fp.dddjh,oe_fp.ddxh,oe_fp.xsddjh,oe_fp.xsdxh,oe_fp.xsddj,oe_fp.xsdhsdj,oe_fp.xsdje,oe_fp.xsdshlv,oe_fp.xsdse,oe_fp.je -  oe_fp.xsdje AS xsdjece,oe_fp.se - oe_fp.xsdse AS xsdsece,oe_fp.srr,oe_fp.srrq,oe_fp.shr,oe_fp.shrq,oe_fp.jzr FROM rc_cpxx,oe_fp,rc_lx WHERE rc_cpxx.cpdm = oe_fp.cpdm AND SUBSTR(oe_fp.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_fp.djh,5,4) = rc_lx.kjnd AND lxgs = '��Ʒ���۵�'" & IIf(Me.ChbDelete.Checked, "", " AND oe_fp.bdelete = 0") & " AND fprq >= ? AND fprq <= ? AND SUBSTR(oe_fp.djh,11,5) >= ?  AND SUBSTR(oe_fp.djh,11,5) <= ?" & IIf(Me.CmbPzlxjc.SelectedValue <> "0000", " AND SUBSTR(oe_fp.djh,1, 4) ='" & Me.CmbPzlxjc.SelectedValue & "'", "") & IIf(Trim(Me.TxtLbdm.Text).Length > 0, " and rc_cpxx.lbdm = '" & Trim(Me.TxtLbdm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " and oe_fp.cpdm LIKE '" & Trim(TxtCpdm.Text) & "%'", "") & IIf(TxtZydm.TextLength > 0, " and oe_fp.zydm LIKE '" & TxtZydm.Text & "%'", "") & IIf(TxtHth.TextLength > 0, " and oe_fp.hth LIKE '" & TxtHth.Text & "%'", "") & IIf(Trim(TxtKhdm.Text).Length > 0, " and oe_fp.khdm LIKE '" & LTrim(TxtKhdm.Text) & "%'", "") & IIf(Trim(TxtYspz.Text).Length > 0, " and oe_fp.yspz LIKE '" & LTrim(TxtYspz.Text) & "%'", "") & IIf(Trim(TxtCpmc.Text).Length > 0, " AND oe_fp.cpmc Like '%" & Trim(Me.TxtCpmc.Text) & "%'", "") & ") oe_fpa LEFT JOIN oe_xsd ON oe_xsd.xh = oe_fpa.xsdxh AND  oe_xsd.djh = oe_fpa.xsddjh ORDER BY oe_fpa.djh,oe_fpa.xh"
                    End If
                End If
                rcOleDbCommand.Parameters.Clear()
                If Me.DtpBegin.Enabled Then
                    rcOleDbCommand.Parameters.Add("@fprq1", OleDbType.Date, 8).Value = DtpBegin.Value
                    rcOleDbCommand.Parameters.Add("@fprq2", OleDbType.Date, 8).Value = DtpEnd.Value
                    rcOleDbCommand.Parameters.Add("@djh1", OleDbType.VarChar, 5).Value = NudDjhBegin.Value.ToString.PadLeft(5, "0")
                    rcOleDbCommand.Parameters.Add("@djh2", OleDbType.VarChar, 5).Value = NudDjhEnd.Value.ToString.PadLeft(5, "0")
                End If
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("xsdlb") IsNot Nothing Then
                    rcDataset.Tables("xsdlb").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "xsdlb")
            Catch ex As Exception
                MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("xsdlb").Rows.Count <= 0 Then
                MsgBox("û���������������ݡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            End If
            Dim rcDataRow As DataRow
            rcDataRow = rcDataset.Tables("xsdlb").NewRow
            rcDataRow.Item("djh") = "�ϼ�"
            rcDataRow.Item("sl") = rcDataset.Tables("xsdlb").Compute("Sum(sl)", "")
            rcDataRow.Item("je") = rcDataset.Tables("xsdlb").Compute("Sum(je)", "")
            rcDataRow.Item("se") = rcDataset.Tables("xsdlb").Compute("Sum(se)", "")
            rcDataRow.Item("jese") = rcDataset.Tables("xsdlb").Compute("Sum(jese)", "")
            rcDataRow.Item("skje") = rcDataset.Tables("xsdlb").Compute("Sum(skje)", "")
            If Not Me.ChbYjWsk.Checked And Not Me.ChbWsk.Checked Then
                rcDataRow.Item("cbje") = rcDataset.Tables("xsdlb").Compute("Sum(cbje)", "")
            End If
            rcDataset.Tables("xsdlb").Rows.Add(rcDataRow)
            '���ñ�
            Dim rcFrm As New FrmOeFpCxLb
            With rcFrm
                .ParaDataSet = rcDataset
                .ParaDataView = New DataView(rcDataset.Tables("xsdlb"), "TRUE", "djh,xh", DataViewRowState.CurrentRows)
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
                rcOleDbCommand.CommandText = "SELECT djh FROM oe_fp,rc_lx WHERE SUBSTR(oe_fp.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_fp.djh,5,4) = rc_lx.kjnd AND lxgs = '��Ʒ���۵�' AND fprq >= ? AND fprq <= ? AND SUBSTR(djh,11,5) >= ?  AND SUBSTR(djh,11,5) <= ?" & IIf(Me.CmbPzlxjc.SelectedValue <> "0000", " AND SUBSTR(inv_rkd.djh,1, 4) ='" & Me.CmbPzlxjc.SelectedValue & "'", "") & IIf(Me.TxtZydm.TextLength > 0, " and oe_fp.zydm = '" & TxtZydm.Text & "'", "") & IIf(Trim(TxtKhdm.Text).Length > 0, " and oe_fp.khdm LIKE '" & LTrim(TxtKhdm.Text) & "%'", "") & IIf(Trim(TxtYspz.Text).Length > 0, " and oe_fp.yspz LIKE '" & LTrim(TxtYspz.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtHth.Text), " and oe_fp.hth LIKE '" & LTrim(Me.TxtHth.Text) & "%'", "") & " GROUP BY oe_fp.djh ORDER BY oe_fp.djh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@fprq1", OleDbType.Date, 8).Value = Me.DtpBegin.Value
                rcOleDbCommand.Parameters.Add("@fprq2", OleDbType.Date, 8).Value = Me.DtpEnd.Value
                rcOleDbCommand.Parameters.Add("@djh1", OleDbType.VarChar, 5).Value = NudDjhBegin.Value.ToString.PadLeft(5, "0")
                rcOleDbCommand.Parameters.Add("@djh2", OleDbType.VarChar, 5).Value = NudDjhEnd.Value.ToString.PadLeft(5, "0")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("xsdml") IsNot Nothing Then
                    rcDataset.Tables("xsdml").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "xsdml")
            Catch ex As Exception
                MsgBox("�������asd��" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("xsdml").Rows.Count <= 0 Then
                MsgBox("û���������������ݡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            End If
            '���ñ�
            Dim rcFrm As New FrmOeFpCxz
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