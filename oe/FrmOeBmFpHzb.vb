Imports System.Data.OleDb

Public Class FrmOeBmFpHzb
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable
    ReadOnly dtOeBmFpHzb As New DataTable("oebmfphzb")

    Private Sub FrmOeBmFpHzb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        DtpHzrqBegin.Value = GetInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpHzrqEnd.Value = GetInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '创建datatable
        dtOeBmFpHzb.Columns.Add("bmdm", Type.GetType("System.String"))
        dtOeBmFpHzb.Columns.Add("bmmc", Type.GetType("System.String"))
        dtOeBmFpHzb.Columns.Add("sl", Type.GetType("System.Double"))
        dtOeBmFpHzb.Columns.Add("je", Type.GetType("System.Double"))
        dtOeBmFpHzb.Columns.Add("se", Type.GetType("System.Double"))
        dtOeBmFpHzb.Columns.Add("cbje", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtOeBmFpHzb)
        With dtOeBmFpHzb
            .Columns("bmdm").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("je").DefaultValue = 0.0
            .Columns("se").DefaultValue = 0.0
            .Columns("cbje").DefaultValue = 0.0
        End With
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        dtOeBmFpHzb.Clear()
        '取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT oe_fp.bmdm,rc_bmxx.bmmc,SUM(oe_fp.sl) AS sl,SUM(oe_fp.je) AS je,SUM(oe_fp.se) AS se,SUM(oe_fp.je + oe_fp.se) AS jese,SUM(oe_fp.cbje) AS cbje FROM oe_fp,rc_lx,rc_bmxx WHERE rc_bmxx.bmdm = oe_fp.bmdm AND SUBSTR(oe_fp.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_fp.djh,5,4) = rc_lx.kjnd AND lxgs = '产品销售单' AND oe_fp.bdelete = 0 AND fprq >= ? AND fprq >= ? AND fprq <= ? GROUP BY oe_fp.bmdm,rc_bmxx.bmmc"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("oebmfphzb") IsNot Nothing Then
                rcDataset.Tables("oebmfphzb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "oebmfphzb")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Dim rcDataRow As DataRow
        rcDataRow = rcDataset.Tables("oebmfphzb").NewRow
        rcDataRow.Item("bmdm") = "合计"
        rcDataRow.Item("sl") = dtOeBmFpHzb.Compute("Sum(sl)", "")
        rcDataRow.Item("je") = dtOeBmFpHzb.Compute("Sum(je)", "")
        rcDataRow.Item("se") = dtOeBmFpHzb.Compute("Sum(se)", "")
        rcDataRow.Item("jese") = dtOeBmFpHzb.Compute("Sum(jese)", "")
        rcDataRow.Item("cbje") = dtOeBmFpHzb.Compute("Sum(cbje)", "")
        rcDataset.Tables("oebmfphzb").Rows.Add(rcDataRow)

        '调用表单
        Dim rcFrm As New FrmOeBmFpHzbz
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("oebmfphzb"), "TRUE", "bmdm", DataViewRowState.CurrentRows)
            .Label2.Text = DtpHzrqBegin.Value & "至" & DtpHzrqEnd.Value
            '.Label3.Text = "仓库：" & Trim(Me.TxtCkdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class