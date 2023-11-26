Imports System.Data.OleDb

Public Class FrmOeKhHzb
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable
    ReadOnly dtOeKhHzb As New DataTable("oekhhzb")

    Private Sub FrmOeKhHzb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        DtpHzrqBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpHzrqEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '创建datatable
        dtOeKhHzb.Columns.Add("lbdm", Type.GetType("System.String"))
        dtOeKhHzb.Columns.Add("lbmc", Type.GetType("System.String"))
        dtOeKhHzb.Columns.Add("khdm", Type.GetType("System.String"))
        dtOeKhHzb.Columns.Add("khmc", Type.GetType("System.String"))
        dtOeKhHzb.Columns.Add("zydm", Type.GetType("System.String"))
        dtOeKhHzb.Columns.Add("zymc", Type.GetType("System.String"))
        dtOeKhHzb.Columns.Add("sl", Type.GetType("System.Double"))
        dtOeKhHzb.Columns.Add("je", Type.GetType("System.Double"))
        dtOeKhHzb.Columns.Add("se", Type.GetType("System.Double"))
        dtOeKhHzb.Columns.Add("cbje", Type.GetType("System.Double"))
        dtOeKhHzb.Columns.Add("mle", Type.GetType("System.Double"))
        dtOeKhHzb.Columns.Add("mll", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtOeKhHzb)
        With dtOeKhHzb
            .Columns("khdm").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("je").DefaultValue = 0.0
            .Columns("se").DefaultValue = 0.0
            .Columns("cbje").DefaultValue = 0.0
            .Columns("mle").DefaultValue = 0.0
            .Columns("mll").DefaultValue = 0.0
        End With
    End Sub

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpHzrqBegin.KeyPress, DtpHzrqEnd.KeyPress, TxtLbdm.KeyPress, TxtBmdm.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#Region "客户类别编码的事件"

    Private Sub Txtlbdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLbdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_khlb"
                    .paraField1 = "lbdm"
                    .paraField2 = "lbmc"
                    .paraField3 = "lbsm"
                    .paraTitle = "客户类别"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtLbdm.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub Txtlbdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtLbdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtLbdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_khlb WHERE (lbdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = Trim(TxtLbdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_khlb") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_khlb").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_khlb")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_khlb").Rows.Count > 0 Then
                TxtLbdm.Text = Trim(rcDataset.Tables("rc_khlb").Rows(0).Item("lbdm"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "部门编码的事件"

    Private Sub TxtBmdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBmdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_bmxx"
                    .paraField1 = "bmdm"
                    .paraField2 = "bmmc"
                    .paraField3 = "bmsm"
                    .paraTitle = "部门"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtBmdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtBmdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtBmdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtBmdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT bmdm,bmmc FROM rc_bmxx WHERE (bmdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(TxtBmdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_bmxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_bmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_bmxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_bmxx").Rows.Count > 0 Then
                TxtBmdm.Text = Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmdm"))
            Else
                MsgBox("部门编码不存在，请按F3键选择。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        dtOeKhHzb.Clear()
        '取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT oekhhzbc.lbdm,rc_khlb.lbmc,oekhhzbc.khdm,oekhhzbc.khmc,oekhhzbc.zydm,oekhhzbc.zymc,oekhhzbc.sl,oekhhzbc.fzsl,oekhhzbc.je,oekhhzbc.se,oekhhzbc.cbje,oekhhzbc.mle,oekhhzbc.mll FROM (SELECT oekhhzbb.lbdm,oekhhzbb.khdm,oekhhzbb.khmc,oekhhzbb.zydm,oekhhzbb.zymc,oekhhzbb.sl,oekhhzbb.fzsl,oekhhzbb.je,oekhhzbb.se,oekhhzbb.cbje,(oekhhzbb.je-oekhhzbb.cbje) AS mle,CASE WHEN oekhhzbb.je <> 0 THEN (oekhhzbb.je-oekhhzbb.cbje) / oekhhzbb.je ELSE 0 END AS mll FROM (SELECT oekhhzba.khdm,oekhhzba.khmc,rc_khxx.zydm,rc_khxx.zymc,oekhhzba.sl,oekhhzba.fzsl,oekhhzba.je,oekhhzba.se,oekhhzba.cbje,rc_khxx.lbdm FROM (SELECT oe_xsd.khdm,oe_xsd.khmc,SUM(oe_xsd.sl) AS sl,SUM(oe_xsd.fzsl) AS fzsl,SUM(oe_xsd.je) AS je,SUM(oe_xsd.se) AS se,SUM(oe_xsd.cbje) AS cbje FROM oe_xsd,rc_lx WHERE SUBSTR(oe_xsd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_xsd.djh,5,4) = rc_lx.kjnd AND lxgs = '产品送货单' AND oe_xsd.bdelete = 0 AND oe_xsd.xsrq >= ? AND oe_xsd.xsrq >= ? AND oe_xsd.xsrq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_xsd.bmdm = '" & Me.TxtBmdm.Text & "'", "") & " GROUP BY oe_xsd.khdm,oe_xsd.khmc) oekhhzba LEFT JOIN rc_khxx ON oekhhzba.khdm = rc_khxx.khdm) oekhhzbb " & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " WHERE lbdm = '" & Me.TxtLbdm.Text & "'", "") & ") oekhhzbc LEFT JOIN rc_khlb ON oekhhzbc.lbdm = rc_khlb.lbdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("oekhhzb") IsNot Nothing Then
                rcDataset.Tables("oekhhzb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "oekhhzb")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Dim rcDataRow As DataRow
        rcDataRow = rcDataset.Tables("oekhhzb").NewRow
        rcDataRow.Item("khdm") = "合计"
        rcDataRow.Item("sl") = dtOeKhHzb.Compute("Sum(sl)", "")
        rcDataRow.Item("fzsl") = dtOeKhHzb.Compute("Sum(fzsl)", "")
        rcDataRow.Item("je") = dtOeKhHzb.Compute("Sum(je)", "")
        rcDataRow.Item("se") = dtOeKhHzb.Compute("Sum(se)", "")
        rcDataRow.Item("cbje") = dtOeKhHzb.Compute("Sum(cbje)", "")
        rcDataRow.Item("mle") = dtOeKhHzb.Compute("Sum(mll)", "")
        rcDataset.Tables("oekhhzb").Rows.Add(rcDataRow)

        '调用表单
        Dim rcFrm As New FrmOeKhHzbz
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("oekhhzb"), "TRUE", "khdm", DataViewRowState.CurrentRows)
            .Label2.Text = DtpHzrqBegin.Value & "至" & DtpHzrqEnd.Value
            '.Label3.Text = "仓库：" & Trim(Me.TxtCkdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class