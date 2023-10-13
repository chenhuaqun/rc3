Imports System.Data.OleDb

Public Class FrmOeFhdSh
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Private Sub FrmOeFhdSh_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Ĭ��ֵ
        DtpBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        'ȡ������������
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE kjnd = ? AND lxgs = '����֪ͨ��' ORDER BY pzlxdm"
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
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        '���ݷ�ʽ
        'ȡ����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT oe_fhd.djh FROM oe_fhd,rc_lx WHERE SUBSTR(oe_fhd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_fhd.djh,5,4) = rc_lx.kjnd AND lxgs = '����֪ͨ��' AND oe_fhd.bdelete = 0 AND oe_fhd.fhrq >= ? AND oe_fhd.fhrq <= ? AND SUBSTR(oe_fhd.djh,11, 5) >= ?  AND SUBSTR(oe_fhd.djh,11, 5) <= ?" & IIf(ChbSh.Checked, " and oe_fhd.shr IS NULL", "") & IIf(Not String.IsNullOrEmpty(Me.TxtHth.Text), " and oe_fhd.hth = '" & Trim(Me.TxtHth.Text) & "'", "") & IIf(Trim(Me.TxtKhdm.Text).Length > 0, " and oe_fhd.khdm = '" & Trim(Me.TxtKhdm.Text) & "'", "") & IIf(Me.CmbPzlxjc.SelectedValue <> "0000", " AND SUBSTR(oe_fhd.djh,1, 4) ='" & Me.CmbPzlxjc.SelectedValue & "'", "") & " GROUP BY oe_fhd.djh ORDER BY oe_fhd.djh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@fhrq", OleDbType.Date, 8).Value = DtpBegin.Value
            rcOleDbCommand.Parameters.Add("@fhrq", OleDbType.Date, 8).Value = Me.DtpEnd.Value
            rcOleDbCommand.Parameters.Add("@djh1", OleDbType.VarChar, 5).Value = NudDjhBegin.Value.ToString.PadLeft(5, "0")
            rcOleDbCommand.Parameters.Add("@djh2", OleDbType.VarChar, 5).Value = NudDjhEnd.Value.ToString.PadLeft(5, "0")
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("xsdml") IsNot Nothing Then
                rcDataSet.Tables("xsdml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "xsdml")
        Catch ex As Exception
            MsgBox("������󡣶�ȡ�������ݡ�" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("xsdml").Rows.Count <= 0 Then
            MsgBox("û���������������ݡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        '���ñ�
        Dim rcFrm As New FrmOeFhdShz
        With rcFrm
            .ParaDataSet = rcDataSet
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class