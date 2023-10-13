Imports System.Data.OleDb

Public Class FrmOeZyHzb
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '����Datatable
    ReadOnly dtOeZyHzb As New DataTable("oezyhzb")

    Private Sub FrmOeZyHzb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Ĭ��ֵ
        DtpHzrqBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpHzrqEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '����datatable
        dtOeZyHzb.Columns.Add("zydm", Type.GetType("System.String"))
        dtOeZyHzb.Columns.Add("zymc", Type.GetType("System.String"))
        dtOeZyHzb.Columns.Add("sl", Type.GetType("System.Double"))
        dtOeZyHzb.Columns.Add("je", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtOeZyHzb)
        With dtOeZyHzb
            .Columns("zydm").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("je").DefaultValue = 0.0
        End With
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        dtOeZyHzb.Clear()
        'ȡ����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT rc_khxx.zydm,rc_khxx.zymc,SUM(oezyhzba.sl) AS sl,SUM(oezyhzba.je) AS je FROM (SELECT oe_xsd.khdm,SUM(oe_xsd.sl) AS sl,SUM(oe_xsd.je) AS je FROM oe_xsd,rc_lx WHERE SUBSTR(oe_xsd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_xsd.djh,5,4) = rc_lx.kjnd AND lxgs = '��Ʒ�ͻ���' AND oe_xsd.bdelete = 0 AND xsrq >= ? AND xsrq >= ? AND xsrq <= ? GROUP BY oe_xsd.khdm) oezyhzba,rc_khxx WHERE oezyhzba.khdm = rc_khxx.khdm GROUP BY rc_khxx.zydm,rc_khxx.zymc"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("oezyhzb") IsNot Nothing Then
                rcDataset.Tables("oezyhzb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "oezyhzb")
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Dim rcDataRow As DataRow
        rcDataRow = rcDataset.Tables("oezyhzb").NewRow
        rcDataRow.Item("zydm") = "�ϼ�"
        rcDataRow.Item("sl") = dtOeZyHzb.Compute("Sum(sl)", "")
        rcDataRow.Item("je") = dtOeZyHzb.Compute("Sum(je)", "")
        rcDataset.Tables("oezyhzb").Rows.Add(rcDataRow)

        '���ñ�
        Dim rcFrm As New FrmOeZyHzbz
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("oezyhzb"), "TRUE", "zydm", DataViewRowState.CurrentRows)
            .Label2.Text = DtpHzrqBegin.Value & "��" & DtpHzrqEnd.Value
            '.Label3.Text = "�ֿ⣺" & Trim(Me.TxtCkdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class