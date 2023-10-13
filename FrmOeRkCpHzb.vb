Imports System.Data.OleDb

Public Class FrmOeRkCpHzb
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '����Datatable
    ReadOnly dtOeRkCpHzb As New DataTable("oerkcphzb")

    Private Sub FrmOeRkCpHzb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Ĭ��ֵ
        DtpHzrqBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpHzrqEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '����datatable
        dtOeRkCpHzb.Columns.Add("bmdm", Type.GetType("System.String"))
        dtOeRkCpHzb.Columns.Add("bmmc", Type.GetType("System.String"))
        dtOeRkCpHzb.Columns.Add("ckdm", Type.GetType("System.String"))
        dtOeRkCpHzb.Columns.Add("ckmc", Type.GetType("System.String"))
        dtOeRkCpHzb.Columns.Add("lbdm", Type.GetType("System.String"))
        dtOeRkCpHzb.Columns.Add("cpdm", Type.GetType("System.String"))
        dtOeRkCpHzb.Columns.Add("cpmc", Type.GetType("System.String"))
        dtOeRkCpHzb.Columns.Add("dw", Type.GetType("System.String"))
        dtOeRkCpHzb.Columns.Add("sl", Type.GetType("System.Double"))
        dtOeRkCpHzb.Columns.Add("je", Type.GetType("System.Double"))
        dtOeRkCpHzb.Columns.Add("zl", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtOeRkCpHzb)
        With dtOeRkCpHzb
            .Columns("bmdm").DefaultValue = ""
            .Columns("bmmc").DefaultValue = ""
            .Columns("ckdm").DefaultValue = ""
            .Columns("ckmc").DefaultValue = ""
            .Columns("lbdm").DefaultValue = ""
            .Columns("cpdm").DefaultValue = ""
            .Columns("cpmc").DefaultValue = ""
            .Columns("dw").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("je").DefaultValue = 0.0
            .Columns("zl").DefaultValue = 0.0
        End With
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        dtOeRkCpHzb.Clear()
        'ȡ����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            If Not Me.CheckBox1.Checked Then
                If Not Me.CheckBox2.Checked Then
                    rcOleDbCommand.CommandText = "SELECT oerkcphzba.bmdm,oerkcphzba.bmmc,oerkcphzba.ckdm,oerkcphzba.ckmc,oerkcphzba.lbdm,rc_cplb.lbmc,oerkcphzba.cpdm,oerkcphzba.cpmc,oerkcphzba.dw,oerkcphzba.sl,oerkcphzba.je,oerkcphzba.zl FROM (SELECT inv_rkd.bmdm,rc_bmxx.bmmc,inv_rkd.ckdm,rc_ckxx.ckmc,rc_cpxx.lbdm,inv_rkd.cpdm,rc_cpxx.cpmc,rc_cpxx.dw,SUM(inv_rkd.sl) AS sl,SUM(inv_rkd.sl * rc_cpxx.xsdj) AS je,SUM(inv_rkd.sl * rc_cpxx.cpweight) / 1000000 AS zl FROM inv_rkd,rc_lx,rc_bmxx,rc_ckxx,rc_cpxx WHERE inv_rkd.bdelete = 0 AND rc_bmxx.bmdm = inv_rkd.bmdm AND rc_ckxx.ckdm = inv_rkd.ckdm AND rc_cpxx.cpdm = inv_rkd.cpdm AND SUBSTR(inv_rkd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(inv_rkd.djh,5,4) = rc_lx.kjnd AND lxgs = '��Ʒ��ⵥ' AND inv_rkd.bdelete = 0 AND rkrq >= ? AND rkrq >= ? AND rkrq <= ? GROUP BY inv_rkd.bmdm,rc_bmxx.bmmc,inv_rkd.ckdm,rc_ckxx.ckmc,rc_cpxx.lbdm,inv_rkd.cpdm,rc_cpxx.cpmc,rc_cpxx.dw) oerkcphzba LEFT JOIN rc_cplb ON oerkcphzba.lbdm = rc_cplb.lbdm"
                Else
                    rcOleDbCommand.CommandText = "SELECT oerkcphzba.lbdm,rc_cplb.lbmc,oerkcphzba.sl,oerkcphzba.je,oerkcphzba.zl FROM (SELECT rc_cpxx.lbdm,SUM(inv_rkd.sl) AS sl,SUM(inv_rkd.sl * rc_cpxx.xsdj) AS je,SUM(inv_rkd.sl * rc_cpxx.cpweight) / 1000000 AS zl FROM inv_rkd,rc_lx,rc_cpxx WHERE inv_rkd.bdelete = 0 AND rc_cpxx.cpdm = inv_rkd.cpdm AND SUBSTR(inv_rkd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(inv_rkd.djh,5,4) = rc_lx.kjnd AND lxgs = '��Ʒ��ⵥ' AND inv_rkd.bdelete = 0 AND rkrq >= ? AND rkrq >= ? AND rkrq <= ? GROUP BY rc_cpxx.lbdm) oerkcphzba LEFT JOIN rc_cplb ON oerkcphzba.lbdm = rc_cplb.lbdm"
                End If
            Else
                    rcOleDbCommand.CommandText = "SELECT oerkcphzba.bmdm,oerkcphzba.bmmc,oerkcphzba.ckdm,oerkcphzba.ckmc,oerkcphzba.lbdm,rc_cplb.lbmc,oerkcphzba.sl,oerkcphzba.je,oerkcphzba.zl FROM (SELECT inv_rkd.bmdm,rc_bmxx.bmmc,inv_rkd.ckdm,rc_ckxx.ckmc,rc_cpxx.lbdm,SUM(inv_rkd.sl) AS sl,SUM(inv_rkd.sl * rc_cpxx.xsdj) AS je,SUM(inv_rkd.sl * rc_cpxx.cpweight) / 1000000 AS zl FROM inv_rkd,rc_lx,rc_bmxx,rc_ckxx,rc_cpxx WHERE inv_rkd.bdelete = 0 AND rc_bmxx.bmdm = inv_rkd.bmdm AND rc_ckxx.ckdm = inv_rkd.ckdm AND rc_cpxx.cpdm = inv_rkd.cpdm AND SUBSTR(inv_rkd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(inv_rkd.djh,5,4) = rc_lx.kjnd AND lxgs = '��Ʒ��ⵥ' AND inv_rkd.bdelete = 0 AND rkrq >= ? AND rkrq >= ? AND rkrq <= ? GROUP BY inv_rkd.bmdm,rc_bmxx.bmmc,inv_rkd.ckdm,rc_ckxx.ckmc,rc_cpxx.lbdm) oerkcphzba LEFT JOIN rc_cplb ON oerkcphzba.lbdm = rc_cplb.lbdm"
            End If
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("oerkcphzb") IsNot Nothing Then
                rcDataset.Tables("oerkcphzb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "oerkcphzb")
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Dim rcDataRow As DataRow
        rcDataRow = rcDataset.Tables("oerkcphzb").NewRow
        rcDataRow.Item("bmdm") = "�ϼ�"
        rcDataRow.Item("sl") = dtOeRkCpHzb.Compute("Sum(sl)", "")
        rcDataRow.Item("je") = dtOeRkCpHzb.Compute("Sum(je)", "")
        rcDataRow.Item("zl") = dtOeRkCpHzb.Compute("Sum(zl)", "")
        rcDataset.Tables("oerkcphzb").Rows.Add(rcDataRow)

        '���ñ�
        Dim rcFrm As New FrmOeRkCpHzbz
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("oerkcphzb"), "TRUE", "bmdm,ckdm,lbdm,cpdm", DataViewRowState.CurrentRows)
            .Label2.Text = DtpHzrqBegin.Value & "��" & DtpHzrqEnd.Value
            '.Label3.Text = "�ֿ⣺" & Trim(Me.TxtCkdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class