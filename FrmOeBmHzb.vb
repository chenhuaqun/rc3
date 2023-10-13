Imports System.Data.OleDb

Public Class FrmOeBmHzb
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '����Datatable
    ReadOnly dtOeBmHzb As New DataTable("oebmhzb")

    Private Sub FrmOeBmHzb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Ĭ��ֵ
        DtpHzrqBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpHzrqEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '����datatable
        dtOeBmHzb.Columns.Add("bmdm", Type.GetType("System.String"))
        dtOeBmHzb.Columns.Add("bmmc", Type.GetType("System.String"))
        dtOeBmHzb.Columns.Add("sl", Type.GetType("System.Double"))
        dtOeBmHzb.Columns.Add("je", Type.GetType("System.Double"))
        dtOeBmHzb.Columns.Add("se", Type.GetType("System.Double"))
        dtOeBmHzb.Columns.Add("cbje", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtOeBmHzb)
        With dtOeBmHzb
            .Columns("bmdm").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("je").DefaultValue = 0.0
            .Columns("se").DefaultValue = 0.0
            .Columns("cbje").DefaultValue = 0.0
        End With
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        dtOeBmHzb.Clear()
        'ȡ����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT oe_xsd.bmdm,rc_bmxx.bmmc,SUM(oe_xsd.sl) AS sl,SUM(oe_xsd.je) AS je,SUM(oe_xsd.se) AS se,SUM(oe_xsd.je + oe_xsd.se) AS jese,SUM(oe_xsd.cbje) AS cbje FROM oe_xsd,rc_lx,rc_bmxx WHERE rc_bmxx.bmdm = oe_xsd.bmdm AND SUBSTR(oe_xsd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_xsd.djh,5,4) = rc_lx.kjnd AND lxgs = '��Ʒ�ͻ���' AND oe_xsd.bdelete = 0 AND xsrq >= ? AND xsrq >= ? AND xsrq <= ? GROUP BY oe_xsd.bmdm,rc_bmxx.bmmc"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("oebmhzb") IsNot Nothing Then
                rcDataset.Tables("oebmhzb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "oebmhzb")
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Dim rcDataRow As DataRow
        rcDataRow = rcDataset.Tables("oebmhzb").NewRow
        rcDataRow.Item("bmdm") = "�ϼ�"
        rcDataRow.Item("sl") = dtOeBmHzb.Compute("Sum(sl)", "")
        rcDataRow.Item("je") = dtOeBmHzb.Compute("Sum(je)", "")
        rcDataRow.Item("se") = dtOeBmHzb.Compute("Sum(se)", "")
        rcDataRow.Item("jese") = dtOeBmHzb.Compute("Sum(jese)", "")
        rcDataRow.Item("cbje") = dtOeBmHzb.Compute("Sum(cbje)", "")
        rcDataset.Tables("oebmhzb").Rows.Add(rcDataRow)

        '���ñ�
        Dim rcFrm As New FrmOeBmHzbz
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("oebmhzb"), "TRUE", "bmdm", DataViewRowState.CurrentRows)
            .Label2.Text = DtpHzrqBegin.Value & "��" & DtpHzrqEnd.Value
            '.Label3.Text = "�ֿ⣺" & Trim(Me.TxtCkdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class