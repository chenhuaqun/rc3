Imports System.Data.OleDb

Public Class FrmPoLlsqCx
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '����Datatable '����Ҫ���ø�datatable���н�����
    ReadOnly dtLlsqLb As New DataTable("llsqlb")

    Private Sub FrmCgdCx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Ĭ��ֵ
        DtpBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        'ȡ������������
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE kjnd = ? AND lxgs = '�����������뵥' ORDER BY pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_lx") IsNot Nothing Then
                Me.rcDataset.Tables("rc_lx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_lx")
        Catch ex As Exception
            MsgBox("������󡣶�ȡ�������͡�" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Dim rcDataRow As DataRow
        rcDataRow = rcDataSet.Tables("rc_lx").NewRow
        rcDataRow.Item("pzlxdm") = "0000"
        rcDataRow.Item("pzlxjc") = "ȫ������"
        rcDataSet.Tables("rc_lx").Rows.Add(rcDataRow)
        If rcDataSet.Tables("rc_lx").Rows.Count = 0 Then
            MsgBox("�붨�嵥�����͡�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        BindDropDownList(CmbPzlxjc, rcDataSet.Tables("rc_lx"), "pzlxdm", "pzlxjc")
        CmbPzlxjc.SelectedValue = "0000"
        '���ݰ�
        dtLlsqLb.Columns.Add("djh", Type.GetType("System.String"))
        dtLlsqLb.Columns.Add("xh", Type.GetType("System.Int32"))
        dtLlsqLb.Columns.Add("sqrq", Type.GetType("System.DateTime"))
        dtLlsqLb.Columns.Add("zydm", Type.GetType("System.String"))
        dtLlsqLb.Columns.Add("zymc", Type.GetType("System.String"))
        dtLlsqLb.Columns.Add("bmdm", Type.GetType("System.String"))
        dtLlsqLb.Columns.Add("bmmc", Type.GetType("System.String"))
        dtLlsqLb.Columns.Add("cpdm", Type.GetType("System.String"))
        dtLlsqLb.Columns.Add("cpmc", Type.GetType("System.String"))
        dtLlsqLb.Columns.Add("csdm", Type.GetType("System.String"))
        dtLlsqLb.Columns.Add("csmc", Type.GetType("System.String"))
        dtLlsqLb.Columns.Add("bfadm", Type.GetType("System.Boolean"))
        dtLlsqLb.Columns.Add("fadm", Type.GetType("System.String"))
        dtLlsqLb.Columns.Add("famc", Type.GetType("System.String"))
        dtLlsqLb.Columns.Add("sl", Type.GetType("System.Double"))
        dtLlsqLb.Columns.Add("dw", Type.GetType("System.String"))
        dtLlsqLb.Columns.Add("mjsl", Type.GetType("System.Double"))
        dtLlsqLb.Columns.Add("fzsl", Type.GetType("System.Double"))
        dtLlsqLb.Columns.Add("fzdw", Type.GetType("System.String"))
        dtLlsqLb.Columns.Add("sqmemo", Type.GetType("System.String"))
        dtLlsqLb.Columns.Add("srr", Type.GetType("System.String"))
        dtLlsqLb.Columns.Add("srrq", Type.GetType("System.String"))
        dtLlsqLb.Columns.Add("shr", Type.GetType("System.String"))
        dtLlsqLb.Columns.Add("shrq", Type.GetType("System.String"))
        dtLlsqLb.Columns.Add("cksl", Type.GetType("System.Double"))
        dtLlsqLb.Columns.Add("bclosed", Type.GetType("System.Boolean"))
        rcDataSet.Tables.Add(dtLlsqLb)
        With dtLlsqLb
            .Columns("cpdm").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("mjsl").DefaultValue = 0.0
            .Columns("fzsl").DefaultValue = 0.0
            .Columns("sqmemo").DefaultValue = ""
            .Columns("bclosed").DefaultValue = False
        End With

    End Sub

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
        End Select
    End Sub

    Private Sub TxtBmdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtBmdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtBmdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT bmdm,bmmc FROM rc_bmxx WHERE (bmdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(TxtBmdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_bmxx") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_bmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_bmxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_bmxx").Rows.Count <= 0 Then
                MsgBox("���ű��벻���ڣ��밴F3��ѡ��", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If Me.ChbLbfs.Checked Then
            'ȡ����
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT inv_llsq.djh,inv_llsq.xh,inv_llsq.sqrq,inv_llsq.zydm,inv_llsq.zymc,inv_llsq.bmdm,inv_llsq.bmmc,inv_llsq.cpdm,inv_llsq.cpmc,inv_llsq.csdm,inv_llsq.csmc,inv_llsq.bfadm,inv_llsq.fadm,inv_llsq.famc,inv_llsq.sl,inv_llsq.dw,inv_llsq.mjsl,inv_llsq.fzsl,inv_llsq.fzdw,inv_llsq.sqmemo,inv_llsq.cksl,inv_llsq.srr,inv_llsq.srrq,inv_llsq.shr,inv_llsq.shrq,inv_llsq.bclosed FROM inv_llsq WHERE 0=0" & IIf(Me.ChbSh.Checked, " AND inv_llsq.shr IS NULL", "") & IIf(Me.ChbCk.Checked, " AND inv_llsq.cksl <> inv_llsq.sl AND inv_llsq.bclosed <> 1", " AND inv_llsq.sqrq >= ? AND inv_llsq.sqrq <= ?") & " AND SUBSTR(inv_llsq.djh,11, 5) >= ?  AND SUBSTR(inv_llsq.djh,11,5) <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " and inv_llsq.cpdm = '" & Trim(Me.TxtCpdm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpmc.Text), " and inv_llsq.cpmc Like '%" & Trim(Me.TxtCpmc.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND inv_llsq.bmdm LIKE '" & Trim(Me.TxtBmdm.Text) & "%'", "") & IIf(Me.CmbPzlxjc.SelectedValue <> "0000", " AND SUBSTR(inv_llsq.djh,1, 4) ='" & Me.CmbPzlxjc.SelectedValue & "'", "") & " ORDER BY inv_llsq.djh,inv_llsq.xh"
                rcOleDbCommand.Parameters.Clear()
                If Not Me.ChbCk.Checked Then
                    rcOleDbCommand.Parameters.Add("@sqrq1", OleDbType.Date, 8).Value = DtpBegin.Value
                    rcOleDbCommand.Parameters.Add("@sqrq2", OleDbType.Date, 8).Value = Me.DtpEnd.Value
                End If
                rcOleDbCommand.Parameters.Add("@djh1", OleDbType.VarChar, 5).Value = NudDjhBegin.Value.ToString.PadLeft(5, "0")
                rcOleDbCommand.Parameters.Add("@djh2", OleDbType.VarChar, 5).Value = NudDjhEnd.Value.ToString.PadLeft(5, "0")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("llsqlb") IsNot Nothing Then
                    rcDataSet.Tables("llsqlb").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "llsqlb")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("llsqlb").Rows.Count <= 0 Then
                MsgBox("û���������������ݡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            End If
            Dim rcDataRow As DataRow
            rcDataRow = rcDataSet.Tables("llsqlb").NewRow
            rcDataRow.Item("djh") = "�ϼ�"
            rcDataRow.Item("sl") = rcDataSet.Tables("llsqlb").Compute("Sum(sl)", "")
            rcDataRow.Item("fzsl") = rcDataSet.Tables("llsqlb").Compute("Sum(fzsl)", "")
            rcDataRow.Item("cksl") = rcDataSet.Tables("llsqlb").Compute("Sum(cksl)", "")
            rcDataSet.Tables("llsqlb").Rows.Add(rcDataRow)
            '���ñ�
            Dim rcFrm As New FrmPoLlsqCxLb
            With rcFrm
                .ParaDataSet = rcDataSet
                .ParaDataView = New DataView(rcDataSet.Tables("llsqlb"), "TRUE", "djh,xh", DataViewRowState.CurrentRows)
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
                rcOleDbCommand.CommandText = "SELECT djh FROM inv_llsq WHERE sqrq >= ? AND sqrq <= ? AND SUBSTR(djh,11,5) >= ?  AND SUBSTR(djh,11,5) <= ? " & IIf(Me.ChbSh.Checked, " AND inv_llsq.shr IS NULL", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " and inv_llsq.bmdm LIKE '" & Trim(Me.TxtBmdm.Text) & "%'", "") & " GROUP BY djh ORDER BY djh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@sqrq1", OleDbType.Date, 8).Value = DtpBegin.Value
                rcOleDbCommand.Parameters.Add("@sqrq2", OleDbType.Date, 8).Value = Me.DtpEnd.Value
                rcOleDbCommand.Parameters.Add("@djh1", OleDbType.VarChar, 5).Value = NudDjhBegin.Value.ToString.PadLeft(5, "0")
                rcOleDbCommand.Parameters.Add("@djh2", OleDbType.VarChar, 5).Value = NudDjhEnd.Value.ToString.PadLeft(5, "0")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("ckdml") IsNot Nothing Then
                    rcDataSet.Tables("ckdml").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "ckdml")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("ckdml").Rows.Count <= 0 Then
                MsgBox("û���������������ݡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            End If
            '���ñ�
            Dim rcFrm As New FrmPoLlsqCxz
            With rcFrm
                .ParaDataSet = rcDataSet
                .WindowState = FormWindowState.Maximized
                .MdiParent = Me.MdiParent
                .Show()
            End With
        End If
    End Sub

    Private Sub ChbLbfs_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbLbfs.CheckedChanged
        If Me.ChbLbfs.Checked Then
            Me.TxtCpdm.Enabled = True
            Me.TxtCpmc.Enabled = True
        Else
            Me.TxtCpdm.Enabled = False
            Me.TxtCpmc.Enabled = False
            Me.ChbCk.Checked = False
        End If
    End Sub

    Private Sub ChbCk_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbCk.CheckedChanged
        If Me.ChbCk.Checked Then
            Me.DtpBegin.Enabled = False
            Me.DtpEnd.Enabled = False
        Else
            Me.DtpBegin.Enabled = True
            Me.DtpEnd.Enabled = True
        End If
    End Sub
End Class