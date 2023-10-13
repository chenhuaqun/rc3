Imports System.Data.OleDb

Public Class FrmArKhHzb
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '����Datatable
    ReadOnly dtArKhHzb As New DataTable("arkhhzb")

    Private Sub FrmArKhHzb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Ĭ��ֵ
        DtpHzrqBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpHzrqEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '����datatable
        dtArKhHzb.Columns.Add("khdm", Type.GetType("System.String"))
        dtArKhHzb.Columns.Add("khmc", Type.GetType("System.String"))
        dtArKhHzb.Columns.Add("zydm", Type.GetType("System.String"))
        dtArKhHzb.Columns.Add("zymc", Type.GetType("System.String"))
        dtArKhHzb.Columns.Add("je", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtArKhHzb)
        With dtArKhHzb
            .Columns("khdm").DefaultValue = ""
            .Columns("je").DefaultValue = 0.0
        End With
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        dtArKhHzb.Clear()
        'ȡ����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT arkhhzba.khdm,arkhhzba.khmc,rc_khxx.zydm,rc_khxx.zymc,arkhhzba.je FROM(SELECT ar_skd.khdm,ar_skd.khmc,SUM(ar_skd.je) AS je FROM ar_skd,rc_lx WHERE SUBSTR(ar_skd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(ar_skd.djh,5,4) = rc_lx.kjnd AND lxgs = '�տ' AND skrq >= ? AND skrq >= ? AND skrq <= ? GROUP BY ar_skd.khdm,ar_skd.khmc) arkhhzba LEFT JOIN rc_khxx ON arkhhzba.khdm = rc_khxx.khdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("arkhhzb") IsNot Nothing Then
                rcDataset.Tables("arkhhzb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "arkhhzb")
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Dim rcDataRow As DataRow
        rcDataRow = rcDataset.Tables("arkhhzb").NewRow
        rcDataRow.Item("khdm") = "�ϼ�"
        rcDataRow.Item("je") = dtArKhHzb.Compute("Sum(je)", "")
        rcDataset.Tables("arkhhzb").Rows.Add(rcDataRow)

        '���ñ�
        Dim rcFrm As New FrmArKhHzbz
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("arkhhzb"), "TRUE", "khdm", DataViewRowState.CurrentRows)
            .Label2.Text = DtpHzrqBegin.Value & "��" & DtpHzrqEnd.Value
            '.Label3.Text = "�ֿ⣺" & Trim(Me.TxtCkdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class