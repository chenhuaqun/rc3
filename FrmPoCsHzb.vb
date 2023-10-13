Imports System.Data.OleDb

Public Class FrmPoCsHzb
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '����Datatable
    ReadOnly dtPoCsHzb As New DataTable("pocshzb")

    Private Sub FrmPoCsHzb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Ĭ��ֵ
        DtpHzrqBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpHzrqEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '����datatable
        dtPoCsHzb.Columns.Add("csdm", Type.GetType("System.String"))
        dtPoCsHzb.Columns.Add("csmc", Type.GetType("System.String"))
        dtPoCsHzb.Columns.Add("zydm", Type.GetType("System.String"))
        dtPoCsHzb.Columns.Add("zymc", Type.GetType("System.String"))
        dtPoCsHzb.Columns.Add("sl", Type.GetType("System.Double"))
        dtPoCsHzb.Columns.Add("je", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtPoCsHzb)
        With dtPoCsHzb
            .Columns("csdm").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("je").DefaultValue = 0.0
        End With
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        dtPoCsHzb.Clear()
        'ȡ����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pocshzba.csdm,pocshzba.csmc,rc_csxx.zydm,rc_csxx.zymc,pocshzba.sl,pocshzba.je FROM(SELECT po_rkd.csdm,po_rkd.csmc,SUM(po_rkd.sl) AS sl,SUM(po_rkd.je) AS je FROM po_rkd,rc_lx WHERE SUBSTR(po_rkd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(po_rkd.djh,5,4) = rc_lx.kjnd AND lxgs = '������ⵥ' AND po_rkd.bdelete = 0 AND rkrq >= ? AND rkrq >= ? AND rkrq <= ? GROUP BY po_rkd.csdm,po_rkd.csmc) pocshzba LEFT JOIN rc_csxx ON pocshzba.csdm = rc_csxx.csdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("pocshzb") IsNot Nothing Then
                rcDataset.Tables("pocshzb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "pocshzb")
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Dim rcDataRow As DataRow
        rcDataRow = rcDataset.Tables("pocshzb").NewRow
        rcDataRow.Item("csdm") = "�ϼ�"
        rcDataRow.Item("sl") = dtPoCsHzb.Compute("Sum(sl)", "")
        rcDataRow.Item("je") = dtPoCsHzb.Compute("Sum(je)", "")
        rcDataset.Tables("pocshzb").Rows.Add(rcDataRow)

        '���ñ�
        Dim rcFrm As New FrmPoCsHzbz
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("pocshzb"), "TRUE", "csdm", DataViewRowState.CurrentRows)
            .Label2.Text = DtpHzrqBegin.Value & "��" & DtpHzrqEnd.Value
            '.Label3.Text = "�ֿ⣺" & Trim(Me.TxtCkdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class