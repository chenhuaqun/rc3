Imports System.Data.OleDb

Public Class FrmOeCplbHzb
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable
    ReadOnly dtOeCplbHzb As New DataTable("oecphzb")

    Private Sub FrmOeCplbHzb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        DtpHzrqBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpHzrqEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '创建datatable
        dtOeCplbHzb.Columns.Add("lbdm", Type.GetType("System.String"))
        dtOeCplbHzb.Columns.Add("lbmc", Type.GetType("System.String"))
        dtOeCplbHzb.Columns.Add("sl", Type.GetType("System.Double"))
        dtOeCplbHzb.Columns.Add("zl", Type.GetType("System.Double"))
        dtOeCplbHzb.Columns.Add("je", Type.GetType("System.Double"))
        dtOeCplbHzb.Columns.Add("se", Type.GetType("System.Double"))
        dtOeCplbHzb.Columns.Add("cbje", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtOeCplbHzb)
        With dtOeCplbHzb
            .Columns("lbdm").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("zl").DefaultValue = 0.0
            .Columns("je").DefaultValue = 0.0
            .Columns("se").DefaultValue = 0.0
            .Columns("cbje").DefaultValue = 0.0
        End With
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        dtOeCplbHzb.Clear()
        '取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT rc_cplb.lbdm,rc_cplb.lbmc,SUM(oe_xsd.sl) AS sl,ROUND(SUM(oe_xsd.sl * rc_cpxx.cpweight) /1000,4) AS zl,SUM(oe_xsd.je) AS je,SUM(oe_xsd.se) AS se,SUM(oe_xsd.cbje) AS cbje FROM oe_xsd,rc_lx,rc_cpxx,rc_cplb WHERE rc_cpxx.cpdm = oe_xsd.cpdm AND rc_cpxx.lbdm = rc_cplb.lbdm AND SUBSTR(oe_xsd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_xsd.djh,5,4) = rc_lx.kjnd AND lxgs = '产品送货单' AND oe_xsd.bdelete = 0 AND xsrq >= ? AND xsrq >= ? AND xsrq <= ? GROUP BY rc_cplb.lbdm,rc_cplb.lbmc"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("oecphzb") IsNot Nothing Then
                rcDataset.Tables("oecphzb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "oecphzb")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Dim rcDataRow As DataRow
        rcDataRow = rcDataset.Tables("oecphzb").NewRow
        rcDataRow.Item("lbdm") = "合计"
        rcDataRow.Item("sl") = dtOeCplbHzb.Compute("Sum(sl)", "")
        rcDataRow.Item("zl") = dtOeCplbHzb.Compute("Sum(zl)", "")
        rcDataRow.Item("je") = dtOeCplbHzb.Compute("Sum(je)", "")
        rcDataRow.Item("se") = dtOeCplbHzb.Compute("Sum(se)", "")
        rcDataRow.Item("cbje") = dtOeCplbHzb.Compute("Sum(cbje)", "")
        rcDataset.Tables("oecphzb").Rows.Add(rcDataRow)

        '调用表单
        Dim rcFrm As New FrmOeCplbHzbz
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("oecphzb"), "TRUE", "lbdm", DataViewRowState.CurrentRows)
            .Label2.Text = DtpHzrqBegin.Value & "至" & DtpHzrqEnd.Value
            '.Label3.Text = "仓库：" & Trim(Me.TxtCkdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class