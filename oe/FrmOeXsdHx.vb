Imports System.Data.OleDb

Public Class FrmOeXsdHx
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable '我们要利用该datatable进行金额计算
    ReadOnly dtXsd As New DataTable("rc_xsdnr")

    Private Sub FrmOeXsdHx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '数据绑定
        dtXsd.Columns.Add("bsign", Type.GetType("System.Boolean"))
        dtXsd.Columns.Add("djh", Type.GetType("System.String"))
        dtXsd.Columns.Add("xsrq", Type.GetType("System.DateTime"))
        dtXsd.Columns.Add("khdm", Type.GetType("System.String"))
        dtXsd.Columns.Add("khmc", Type.GetType("System.String"))
        dtXsd.Columns.Add("sl", Type.GetType("System.Double"))
        dtXsd.Columns.Add("je", Type.GetType("System.Double"))
        rcDataSet.Tables.Add(dtXsd)
        With rcDataSet.Tables("rc_xsdnr")
            .Columns("bsign").DefaultValue = 0
            .Columns("djh").DefaultValue = ""
            .Columns("khdm").DefaultValue = ""
            .Columns("khmc").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("je").DefaultValue = 0.0
        End With
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        '取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT oe_xsd.bsign,oe_xsd.djh,oe_xsd.xsrq,oe_xsd.khdm,oe_xsd.khmc,SUM(oe_xsd.sl) AS sl,SUM(oe_xsd.je) AS je FROM oe_xsd,rc_lx WHERE SUBSTR(oe_xsd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_xsd.djh,5,4) = rc_lx.kjnd AND lxgs = '产品送货单' AND oe_xsd.xsrq >= ? AND oe_xsd.bdelete = 0 AND " & IIf(Me.TxtDjh.TextLength > 0, " oe_xsd.djh = '" & Trim(Me.TxtDjh.Text) & "'", " oe_xsd.bsign = 0") & " GROUP BY oe_xsd.bsign,oe_xsd.djh,oe_xsd.xsrq,oe_xsd.khdm,oe_xsd.khmc ORDER BY oe_xsd.djh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_xsdnr") IsNot Nothing Then
                rcDataSet.Tables("rc_xsdnr").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_xsdnr")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("rc_xsdnr").Rows.Count <= 0 Then
            MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        '调用表单
        Dim rcFrm As New FrmOeXsdHxz
        With rcFrm
            .ParaDataSet = rcDataSet
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class