Imports System.Data.OleDb

Public Class FrmOeXsdCx

#Region "�������"

    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

#End Region

#Region "��ʼ���¼�"

    Private Sub FrmOeXsdCx_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Ĭ��ֵ
        Me.DtpBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        Me.DtpEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        'ȡ������������
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE kjnd = ? AND lxgs = '��Ʒ�ͻ���' ORDER BY pzlxdm"
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

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpBegin.KeyPress, DtpEnd.KeyPress, CmbPzlxjc.KeyPress, NudDjhBegin.KeyPress, NudDjhEnd.KeyPress, TxtCpdm.KeyPress, TxtCpmc.KeyPress, TxtHth.KeyPress, TxtKhdm.KeyPress, TxtBmdm.KeyPress, TxtZydm.KeyPress, ChbLbfs.KeyPress
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

#Region "ְԱ�����¼�"

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

    Private Sub TxtZydm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtZydm.Validating
        If Not String.IsNullOrEmpty(Me.TxtZydm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT rc_zyxx.zydm,rc_zyxx.zymc FROM rc_zyxx WHERE (zydm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(Me.TxtZydm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_zyxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_zyxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_zyxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_zyxx").Rows.Count > 0 Then
                Me.TxtZydm.Text = Trim(rcDataSet.Tables("rc_zyxx").Rows(0).Item("zydm"))
                'Me.LblZymc.Text = Trim(rcDataSet.Tables("rc_zyxx").Rows(0).Item("zymc"))
            Else
                MsgBox("ְԱ���벻���ڣ��������롣", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
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

    Private Sub TxtKhdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtKhdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtKhdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_khxx WHERE (khdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(TxtKhdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_khxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_khxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_khxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message)
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_khxx").Rows.Count > 0 Then
                Me.TxtKhdm.Text = Trim(rcDataSet.Tables("rc_khxx").Rows(0).Item("khdm"))
            Else
                MsgBox("�ͻ����벻���ڣ��������롣", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
                e.Cancel = True
            End If
        End If
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
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
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
                If rcDataSet.Tables("rc_ckxx") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_ckxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_ckxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_ckxx").Rows.Count > 0 Then
                Me.TxtCkdm.Text = Trim(rcDataSet.Tables("rc_ckxx").Rows(0).Item("ckdm"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

    Private Sub ChbFp_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbFp.CheckedChanged
        If Me.ChbFp.Checked Or Me.ChbWsk.Checked Then
            Me.DtpBegin.Enabled = False
            Me.DtpEnd.Enabled = False
        Else
            Me.DtpBegin.Enabled = True
            Me.DtpEnd.Enabled = True
        End If
        If Me.ChbFp.Checked Then
            Me.ChbWsk.Checked = False
            Me.ChbLbfs.Checked = True
        End If
    End Sub

    Private Sub ChbWsk_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbWsk.CheckedChanged
        If Me.ChbFp.Checked Or Me.ChbWsk.Checked Then
            Me.DtpBegin.Enabled = False
            Me.DtpEnd.Enabled = False
        Else
            Me.DtpBegin.Enabled = True
            Me.DtpEnd.Enabled = True
        End If
        If Me.ChbWsk.Checked Then
            Me.ChbFp.Checked = False
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
            Me.ChbFp.Checked = False
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
                If Me.ChbWsk.Checked Then
                    rcOleDbCommand.CommandText = "SELECT oe_xsda.*,oe_dd.sktj,oe_dd.skqx FROM (SELECT oe_xsd.djh,oe_xsd.xh,oe_xsd.xsrq,oe_xsd.bdelete,oe_xsd.zydm,oe_xsd.zymc,oe_xsd.khdm,oe_xsd.khmc,oe_xsd.bmdm,oe_xsd.bmmc,oe_xsd.ckdm,oe_xsd.ckmc,oe_xsd.cpdm,oe_xsd.cpmc,oe_xsd.hth,oe_xsd.khddh,oe_xsd.khlh,oe_xsd.sl,oe_xsd.fpsl,oe_xsd.sl - oe_xsd.fpsl AS wfp,oe_xsd.dw,oe_xsd.mjsl,oe_xsd.fzsl,oe_xsd.fzdw,oe_xsd.dj,oe_xsd.hsdj,oe_xsd.je,oe_xsd.shlv,oe_xsd.se,oe_xsd.je + oe_xsd.se AS jese,oe_xsd.cbje,oe_xsd.xsmemo,oe_xsd.dddjh,oe_xsd.ddxh,oe_xsd.skje,oe_xsd.bsign,oe_xsd.srr,oe_xsd.shr,oe_xsd.jzr FROM rc_cpxx,oe_xsd,rc_lx WHERE rc_cpxx.cpdm = oe_xsd.cpdm AND SUBSTR(oe_xsd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_xsd.djh,5,4) = rc_lx.kjnd AND rc_lx.lxgs = '��Ʒ�ͻ���'" & IIf(Me.ChbDelete.Checked, "", " AND oe_xsd.bdelete = 0") & IIf(Me.ChbFp.Checked, " AND oe_xsd.sl <> oe_xsd.fpsl", " AND xsrq >= ? AND xsrq <= ? AND SUBSTR(oe_xsd.djh,11,5) >= ?  AND SUBSTR(oe_xsd.djh,11,5) <= ?") & IIf(Me.CmbPzlxjc.SelectedValue <> "0000", " AND SUBSTR(oe_xsd.djh,1, 4) ='" & Me.CmbPzlxjc.SelectedValue & "'", "") & IIf(Trim(Me.TxtLbdm.Text).Length > 0, " and rc_cpxx.lbdm = '" & Trim(Me.TxtLbdm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " and oe_xsd.cpdm LIKE '" & Trim(TxtCpdm.Text) & "%'", "") & IIf(TxtZydm.TextLength > 0, " and oe_xsd.zydm LIKE '" & TxtZydm.Text & "%'", "") & IIf(TxtHth.TextLength > 0, " and oe_xsd.hth LIKE '" & TxtHth.Text & "%'", "") & IIf(Trim(TxtKhdm.Text).Length > 0, " and oe_xsd.khdm LIKE '" & LTrim(TxtKhdm.Text) & "%'", "") & IIf(Trim(Me.TxtBmdm.Text).Length > 0, " and oe_xsd.bmdm LIKE '" & LTrim(TxtBmdm.Text) & "%'", "") & IIf(Trim(Me.TxtCkdm.Text).Length > 0, " and oe_xsd.ckdm = '" & Trim(Me.TxtCkdm.Text) & "'", "") & IIf(Trim(TxtCpmc.Text).Length > 0, " AND oe_xsd.cpmc Like '%" & Trim(Me.TxtCpmc.Text) & "%'", "") & ") oe_xsda,oe_dd WHERE oe_xsda.ddxh = oe_dd.xh AND oe_xsda.dddjh = oe_dd.djh AND oe_dd.sktj = '��������' AND oe_xsda.je + oe_xsda.se <> oe_xsda.skje AND oe_xsda.xsrq + oe_dd.skqx < SYSDATE ORDER BY oe_xsda.djh,oe_xsda.xh"
                Else
                    rcOleDbCommand.CommandText = "SELECT oe_xsd.djh,oe_xsd.xh,oe_xsd.xsrq,oe_xsd.bdelete,oe_xsd.zydm,oe_xsd.zymc,oe_xsd.khdm,oe_xsd.khmc,'' AS sktj,0 AS skqx,oe_xsd.bmdm,oe_xsd.bmmc,oe_xsd.ckdm,oe_xsd.ckmc,oe_xsd.cpdm,oe_xsd.cpmc,oe_xsd.hth,oe_xsd.khddh,oe_xsd.khlh,oe_xsd.sl,oe_xsd.fpsl,oe_xsd.sl - oe_xsd.fpsl AS wfp,oe_xsd.dw,oe_xsd.mjsl,oe_xsd.fzsl,oe_xsd.fzdw,oe_xsd.dj,oe_xsd.hsdj,oe_xsd.je,oe_xsd.shlv,oe_xsd.se,oe_xsd.je + oe_xsd.se AS jese,oe_xsd.cbje,oe_xsd.xsmemo,oe_xsd.dddjh,oe_xsd.ddxh,oe_xsd.skje,oe_xsd.bsign,oe_xsd.srr,oe_xsd.shr,oe_xsd.jzr FROM rc_cpxx,oe_xsd,rc_lx WHERE rc_cpxx.cpdm = oe_xsd.cpdm AND SUBSTR(oe_xsd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_xsd.djh,5,4) = rc_lx.kjnd AND rc_lx.lxgs = '��Ʒ�ͻ���'" & IIf(Me.ChbDelete.Checked, "", " AND oe_xsd.bdelete = 0") & IIf(Me.ChbFp.Checked, " AND oe_xsd.sl <> oe_xsd.fpsl", " AND xsrq >= ? AND xsrq <= ? AND SUBSTR(oe_xsd.djh,11,5) >= ?  AND SUBSTR(oe_xsd.djh,11,5) <= ?") & IIf(Me.CmbPzlxjc.SelectedValue <> "0000", " AND SUBSTR(oe_xsd.djh,1, 4) ='" & Me.CmbPzlxjc.SelectedValue & "'", "") & IIf(Trim(Me.TxtLbdm.Text).Length > 0, " and rc_cpxx.lbdm = '" & Trim(Me.TxtLbdm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " and oe_xsd.cpdm LIKE '" & Trim(TxtCpdm.Text) & "%'", "") & IIf(TxtZydm.TextLength > 0, " and oe_xsd.zydm LIKE '" & TxtZydm.Text & "%'", "") & IIf(TxtHth.TextLength > 0, " and oe_xsd.hth LIKE '" & TxtHth.Text & "%'", "") & IIf(Trim(TxtKhdm.Text).Length > 0, " and oe_xsd.khdm LIKE '" & LTrim(TxtKhdm.Text) & "%'", "") & IIf(Trim(Me.TxtBmdm.Text).Length > 0, " and oe_xsd.bmdm LIKE '" & LTrim(TxtBmdm.Text) & "%'", "") & IIf(Trim(Me.TxtCkdm.Text).Length > 0, " and oe_xsd.ckdm = '" & Trim(Me.TxtCkdm.Text) & "'", "") & IIf(Trim(TxtCpmc.Text).Length > 0, " AND oe_xsd.cpmc Like '%" & Trim(Me.TxtCpmc.Text) & "%'", "") & " ORDER BY oe_xsd.djh,oe_xsd.xh"
                End If
                rcOleDbCommand.Parameters.Clear()
                If Not Me.ChbFp.Checked Then
                    rcOleDbCommand.Parameters.Add("@xsrq1", OleDbType.Date, 8).Value = DtpBegin.Value
                    rcOleDbCommand.Parameters.Add("@xsrq2", OleDbType.Date, 8).Value = DtpEnd.Value
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
            rcDataRow.Item("fzsl") = rcDataset.Tables("xsdlb").Compute("Sum(fzsl)", "")
            rcDataRow.Item("je") = rcDataset.Tables("xsdlb").Compute("Sum(je)", "")
            rcDataRow.Item("se") = rcDataset.Tables("xsdlb").Compute("Sum(se)", "")
            rcDataRow.Item("jese") = rcDataset.Tables("xsdlb").Compute("Sum(jese)", "")
            rcDataRow.Item("cbje") = rcDataset.Tables("xsdlb").Compute("Sum(cbje)", "")
            rcDataRow.Item("skje") = rcDataset.Tables("xsdlb").Compute("Sum(skje)", "")
            rcDataset.Tables("xsdlb").Rows.Add(rcDataRow)
            '���ñ�
            Dim rcFrm As New FrmOeXsdCxLb
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
                rcOleDbCommand.CommandText = "SELECT djh FROM oe_xsd,rc_lx WHERE SUBSTR(oe_xsd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_xsd.djh,5,4) = rc_lx.kjnd AND lxgs = '��Ʒ�ͻ���' AND xsrq >= ? AND xsrq <= ? AND SUBSTR(djh,11,5) >= ?  AND SUBSTR(djh,11,5) <= ?" & IIf(Me.CmbPzlxjc.SelectedValue <> "0000", " AND SUBSTR(inv_rkd.djh,1, 4) ='" & Me.CmbPzlxjc.SelectedValue & "'", "") & IIf(Me.TxtZydm.TextLength > 0, " and oe_xsd.zydm = '" & TxtZydm.Text & "'", "") & IIf(Trim(TxtKhdm.Text).Length > 0, " and oe_xsd.khdm LIKE '" & LTrim(TxtKhdm.Text) & "%'", "") & IIf(Trim(TxtBmdm.Text).Length > 0, " and oe_xsd.bmdm LIKE '" & LTrim(TxtBmdm.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtHth.Text), " and oe_xsd.hth LIKE '" & LTrim(Me.TxtHth.Text) & "%'", "") & " GROUP BY oe_xsd.djh ORDER BY oe_xsd.djh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@xsrq1", OleDbType.Date, 8).Value = DtpBegin.Value
                rcOleDbCommand.Parameters.Add("@xsrq2", OleDbType.Date, 8).Value = DtpEnd.Value
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
            Dim rcFrm As New FrmOeXsdCxz
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