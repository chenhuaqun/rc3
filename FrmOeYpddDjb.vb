Imports System.Data.OleDb
Public Class FrmOeYpddDjb

#Region "�������"

    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '���ݸ��´���
    Dim rcOleDbTrans As OleDbTransaction
    '��������
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

#End Region

#Region "��ʼ��"

    Private Sub FrmOeYpddDjb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Ĭ��ֵ
        DtpQdrqBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpQdrqEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
    End Sub

#End Region

#Region "�ؼ��س����Ĵ���"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpQdrqBegin.KeyPress, DtpQdrqEnd.KeyPress, NudDjhBegin.KeyPress, NudDjhEnd.KeyPress, TxtCpdm.KeyPress, TxtCpmc.KeyPress, TxtCpgg.KeyPress, TxtCpmemo.KeyPress, TxtBmdm.KeyPress, TxtHth.KeyPress, TxtKhdm.KeyPress, TxtKhlh.KeyPress, TxtKhcz.KeyPress, TxtZydm.KeyPress
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
                Dim rcFrm As New models.FrmF36
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_cpxx"
                    .paraField1 = "cpdm"
                    .paraField2 = "cpmc"
                    .paraField3 = "cpgg"
                    .paraField4 = "cpmemo"
                    .paraField5 = "cpsm"
                    .paraField6 = "dw"
                    .paraOrderField = "cpmc"
                    .paraTitle = "��Ʒ"
                    .paraOldValue = TxtCpdm.Text
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtCpdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
            Case Keys.Up
                SendKeys.Send("+{TAB}")
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "��Ʒ�����¼�"

    Private Sub TxtCpmc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCpmc.KeyDown, TxtCpgg.KeyDown, TxtCpmemo.KeyDown, TxtHth.KeyDown, TxtKhlh.KeyDown, TxtKhcz.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                SendKeys.Send("{TAB}")
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
            Case Keys.Up
                SendKeys.Send("+{TAB}")
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "���ű����¼�"

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
                    .paraOrderField = "bmdm"
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
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
            Case Keys.Up
                SendKeys.Send("+{TAB}")
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "����ҵ��Ա�¼�"

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
                        TxtZydm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
            Case Keys.Up
                SendKeys.Send("+{TAB}")
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "ȷ���¼�"

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        'Ȩ�޿���
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "select code as bmdm from rc_userqx where righttype = 'BMDM' and User_Account = ?" & IIf(Trim(TxtBmdm.Text).Length > 0, " and code ='" & Trim(TxtBmdm.Text) & "'", "")
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = g_User_Account
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_bmxx") IsNot Nothing Then
                rcDataset.Tables("rc_bmxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_bmxx")
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Catch ey As OleDbException
                MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_bmxx").Rows.Count <= 0 Then
            MsgBox("����Ȩ�鿴�ñ���", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
            Return
        End If
        Dim strExpBmdm As String = " ���ű��� = ''"
        Dim j As Integer
        If rcDataset.Tables("rc_bmxx").Rows.Count = 1 Then
            TxtBmdm.Text = Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmdm"))
            strExpBmdm = strExpBmdm & " OR ���ű��� = '" & Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmdm")) & "'"
        Else
            For j = 0 To rcDataset.Tables("rc_bmxx").Rows.Count - 1
                strExpBmdm = strExpBmdm & " OR ���ű��� = '" & Trim(rcDataset.Tables("rc_bmxx").Rows(j).Item("bmdm")) & "'"
            Next
        End If
        If strExpBmdm.Length = 0 Then
            strExpBmdm = " 0=0"
        End If
        If strExpBmdm.Length > 0 Then
            If strExpBmdm.Substring(0, 3) = " OR" Then
                strExpBmdm = strExpBmdm.Substring(3)
            End If
        End If
        If Me.ChbLbfs.Checked Then
            'ȡ����
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                If Me.RadioBtnQdrq.Checked Then
                    rcOleDbCommand.CommandText = "Select ��������,�ͻ�����,�ͻ�����,��Ʒ����,��������,����,'' AS Ŀ�ĵس���,'" & g_User_DspName & "' AS �ļ���ǩ��,'' AS �ʼ�����,'' AS �ʼķ���,'' AS ����������,'' AS �ʼ�רԱǩ�� From view_oe_ypdd Where ǩ������ >= ? And ǩ������ <= ?" & IIf(Trim(TxtCpdm.Text).Length > 0, " and ��Ʒ���� LIKE '" & Trim(TxtCpdm.Text) & "%'", "") & IIf(TxtKhlh.TextLength > 0, " and �ͻ��Ϻ� LIKE '" & Trim(TxtKhlh.Text) & "%'", "") & IIf(TxtKhcz.TextLength > 0, " and �ͻ����� LIKE '" & Trim(TxtKhcz.Text) & "%'", "") & IIf(TxtZydm.TextLength > 0, " and ����ְԱ���� LIKE '" & TxtZydm.Text & "%'", "") & IIf(TxtHth.TextLength > 0, " and ��ͬ���� LIKE '" & TxtHth.Text & "%'", "") & IIf(Trim(TxtKhdm.Text).Length > 0, " and �ͻ����� LIKE '" & LTrim(TxtKhdm.Text) & "%'", "") & IIf(Trim(TxtBmdm.Text).Length > 0, " and ���ű��� LIKE '" & TxtBmdm.Text & "%'", "") & IIf(Me.ChbHx.Checked, "", " AND �������� <> ��������") & IIf(Me.ChbShdh.Checked, " AND �ͻ����� <> ''", "") & IIf(Trim(TxtCpmc.Text).Length > 0, " AND ��Ʒ���� LIKE '" & TxtCpmc.Text & "%'", "") & IIf(Trim(TxtCpgg.Text).Length > 0, " and �ͺŹ�� LIKE '" & Trim(TxtCpgg.Text) & "%'", "") & IIf(Trim(Me.TxtCpmemo.Text).Length > 0, " and ��Ʒ���� LIKE '" & Trim(Me.TxtCpmemo.Text) & "%'", "") & " AND SUBSTR(���ݺ�,11,5) >= ?  AND SUBSTR(���ݺ�,11,5) <= ? AND (" & strExpBmdm & ")"
                Else
                    If Me.RadioBtnScjhrq.Checked Then
                        rcOleDbCommand.CommandText = "Select ��������,�ͻ�����,�ͻ�����,��Ʒ����,��������,����,'' AS Ŀ�ĵس���,'" & g_User_DspName & "' AS �ļ���ǩ��,'' AS �ʼ�����,'' AS �ʼķ���,'' AS ����������,'' AS �ʼ�רԱǩ�� From view_oe_ypdd Where �������� >= ? AND �������� <= ?" & IIf(Trim(TxtCpdm.Text).Length > 0, " and ��Ʒ���� LIKE '" & Trim(TxtCpdm.Text) & "%'", "") & IIf(TxtKhlh.TextLength > 0, " and �ͻ��Ϻ� LIKE '" & Trim(TxtKhlh.Text) & "%'", "") & IIf(TxtKhcz.TextLength > 0, " and �ͻ����� LIKE '" & Trim(TxtKhcz.Text) & "%'", "") & IIf(TxtZydm.TextLength > 0, " and ����ְԱ���� LIKE '" & TxtZydm.Text & "%'", "") & IIf(TxtHth.TextLength > 0, " and ��ͬ���� LIKE '" & TxtHth.Text & "%'", "") & IIf(Trim(TxtKhdm.Text).Length > 0, " and �ͻ����� LIKE '" & LTrim(TxtKhdm.Text) & "%'", "") & IIf(Trim(TxtBmdm.Text).Length > 0, " and ���ű��� LIKE '" & TxtBmdm.Text & "%'", "") & IIf(Me.ChbHx.Checked, "", " AND �������� <> ��������") & IIf(Me.ChbShdh.Checked, " AND �ͻ����� <> ''", "") & IIf(Trim(TxtCpmc.Text).Length > 0, " AND ��Ʒ���� LIKE '" & TxtCpmc.Text & "%'", "") & IIf(Trim(TxtCpgg.Text).Length > 0, " and �ͺŹ�� LIKE '" & Trim(TxtCpgg.Text) & "%'", "") & IIf(Trim(Me.TxtCpmemo.Text).Length > 0, " and ��Ʒ���� LIKE '" & Trim(Me.TxtCpmemo.Text) & "%'", "") & " AND SUBSTR(���ݺ�,11,5) >= ?  AND SUBSTR(���ݺ�,11,5) <= ? AND (" & strExpBmdm & ")"
                    Else
                        rcOleDbCommand.CommandText = "Select ��������,�ͻ�����,�ͻ�����,��Ʒ����,��������,����,'' AS Ŀ�ĵس���,'" & g_User_DspName & "' AS �ļ���ǩ��,'' AS �ʼ�����,'' AS �ʼķ���,'' AS ����������,'' AS �ʼ�רԱǩ�� From view_oe_ypdd Where �������� >= ? AND �������� <= ?" & IIf(Trim(TxtCpdm.Text).Length > 0, " and ��Ʒ���� LIKE '" & Trim(TxtCpdm.Text) & "%'", "") & IIf(TxtKhlh.TextLength > 0, " and �ͻ��Ϻ� LIKE '" & Trim(TxtKhlh.Text) & "%'", "") & IIf(TxtKhcz.TextLength > 0, " and �ͻ����� LIKE '" & Trim(TxtKhcz.Text) & "%'", "") & IIf(TxtZydm.TextLength > 0, " and ����ְԱ���� LIKE '" & TxtZydm.Text & "%'", "") & IIf(TxtHth.TextLength > 0, " and ��ͬ���� LIKE '" & TxtHth.Text & "%'", "") & IIf(Trim(TxtKhdm.Text).Length > 0, " and �ͻ����� LIKE '" & LTrim(TxtKhdm.Text) & "%'", "") & IIf(Trim(TxtBmdm.Text).Length > 0, " and ���ű��� LIKE '" & TxtBmdm.Text & "%'", "") & IIf(Me.ChbHx.Checked, "", " AND �������� <> ��������") & IIf(Me.ChbShdh.Checked, " AND �ͻ����� <> ''", "") & IIf(Trim(TxtCpmc.Text).Length > 0, " AND ��Ʒ���� LIKE '" & TxtCpmc.Text & "%'", "") & IIf(Trim(TxtCpgg.Text).Length > 0, " and �ͺŹ�� LIKE '" & Trim(TxtCpgg.Text) & "%'", "") & IIf(Trim(Me.TxtCpmemo.Text).Length > 0, " and ��Ʒ���� LIKE '" & Trim(Me.TxtCpmemo.Text) & "%'", "") & " AND SUBSTR(���ݺ�,11,5) >= ?  AND SUBSTR(���ݺ�,11,5) <= ? AND (" & strExpBmdm & ")"
                    End If
                End If
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@qdrq1", OleDbType.Date, 8).Value = DtpQdrqBegin.Value.Date
                rcOleDbCommand.Parameters.Add("@qdrq2", OleDbType.Date, 8).Value = DtpQdrqEnd.Value.Date
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
            '���ñ�
            Dim rcFrm As New FrmOeYpddCxLb
            With rcFrm
                .ParaDataSet = rcDataset
                .ParaDataView = New DataView(rcDataset.Tables("ddlb"), "TRUE", "��������,�ͻ�����", DataViewRowState.CurrentRows)
                .WindowState = FormWindowState.Maximized
                .MdiParent = Me.MdiParent
                .Show()
            End With
        End If
    End Sub

#End Region
End Class