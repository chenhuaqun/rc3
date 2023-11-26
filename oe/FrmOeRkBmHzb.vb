Imports System.Data.OleDb

Public Class FrmOeRkBmHzb
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable
    ReadOnly dtOeRkCpHzb As New DataTable("oerkcphzb")

    Private Sub FrmOeRkBmHzb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        DtpHzrqBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpHzrqEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '创建datatable
        dtOeRkCpHzb.Columns.Add("bmdm", Type.GetType("System.String"))
        dtOeRkCpHzb.Columns.Add("bmmc", Type.GetType("System.String"))
        dtOeRkCpHzb.Columns.Add("ckdm", Type.GetType("System.String"))
        dtOeRkCpHzb.Columns.Add("ckmc", Type.GetType("System.String"))
        dtOeRkCpHzb.Columns.Add("sl", Type.GetType("System.Double"))
        dtOeRkCpHzb.Columns.Add("je", Type.GetType("System.Double"))
        dtOeRkCpHzb.Columns.Add("zl", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtOeRkCpHzb)
        With dtOeRkCpHzb
            .Columns("bmdm").DefaultValue = ""
            .Columns("bmmc").DefaultValue = ""
            .Columns("ckdm").DefaultValue = ""
            .Columns("ckmc").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("je").DefaultValue = 0.0
            .Columns("zl").DefaultValue = 0.0
        End With
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        dtOeRkCpHzb.Clear()
        '取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT inv_rkd.bmdm,rc_bmxx.bmmc,inv_rkd.ckdm,rc_ckxx.ckmc,SUM(inv_rkd.sl) AS sl,SUM(inv_rkd.sl * rc_cpxx.xsdj) AS je,SUM(inv_rkd.sl * rc_cpxx.cpweight) / 1000000 AS zl FROM inv_rkd,rc_lx,rc_bmxx,rc_ckxx,rc_cpxx WHERE inv_rkd.bdelete = 0 AND rc_bmxx.bmdm = inv_rkd.bmdm AND rc_ckxx.ckdm = inv_rkd.ckdm AND inv_rkd.cpdm = rc_cpxx.cpdm AND SUBSTR(inv_rkd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(inv_rkd.djh,5,4) = rc_lx.kjnd AND lxgs = '产品入库单' AND inv_rkd.bdelete = 0 AND rkrq >= ? AND rkrq >= ? AND rkrq <= ? GROUP BY inv_rkd.bmdm,rc_bmxx.bmmc,inv_rkd.ckdm,rc_ckxx.ckmc"
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
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Dim rcDataRow As DataRow
        rcDataRow = rcDataset.Tables("oerkcphzb").NewRow
        rcDataRow.Item("bmdm") = "合计"
        rcDataRow.Item("sl") = dtOeRkCpHzb.Compute("Sum(sl)", "")
        rcDataRow.Item("je") = dtOeRkCpHzb.Compute("Sum(je)", "")
        rcDataRow.Item("zl") = dtOeRkCpHzb.Compute("Sum(zl)", "")
        rcDataset.Tables("oerkcphzb").Rows.Add(rcDataRow)

        '调用表单
        Dim rcFrm As New FrmOeRkBmHzbz
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("oerkcphzb"), "TRUE", "bmdm,ckdm", DataViewRowState.CurrentRows)
            .Label2.Text = DtpHzrqBegin.Value & "至" & DtpHzrqEnd.Value
            '.Label3.Text = "仓库：" & Trim(Me.TxtCkdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class