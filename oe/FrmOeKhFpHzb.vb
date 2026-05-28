Imports System.Data.OleDb

Public Class FrmOeKhFpHzb
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable
    ReadOnly dtOeKhFpHzb As New DataTable("oekhfphzb")

    Private Sub FrmOeKhFpHzb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        DtpHzrqBegin.Value = GetInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpHzrqEnd.Value = GetInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '创建datatable
        dtOeKhFpHzb.Columns.Add("khlbdm", Type.GetType("System.String"))
        dtOeKhFpHzb.Columns.Add("khlbmc", Type.GetType("System.String"))
        dtOeKhFpHzb.Columns.Add("khdm", Type.GetType("System.String"))
        dtOeKhFpHzb.Columns.Add("khmc", Type.GetType("System.String"))
        dtOeKhFpHzb.Columns.Add("zydm", Type.GetType("System.String"))
        dtOeKhFpHzb.Columns.Add("zymc", Type.GetType("System.String"))
        dtOeKhFpHzb.Columns.Add("cplbdm", Type.GetType("System.String"))
        dtOeKhFpHzb.Columns.Add("cplbmc", Type.GetType("System.String"))
        dtOeKhFpHzb.Columns.Add("sl", Type.GetType("System.Double"))
        dtOeKhFpHzb.Columns.Add("je", Type.GetType("System.Double"))
        dtOeKhFpHzb.Columns.Add("se", Type.GetType("System.Double"))
        dtOeKhFpHzb.Columns.Add("cbje", Type.GetType("System.Double"))
        dtOeKhFpHzb.Columns.Add("mle", Type.GetType("System.Double"))
        dtOeKhFpHzb.Columns.Add("mll", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtOeKhFpHzb)
        With dtOeKhFpHzb
            .Columns("khlbdm").DefaultValue = ""
            .Columns("khdm").DefaultValue = ""
            .Columns("zydm").DefaultValue = ""
            .Columns("cplbdm").DefaultValue = ""
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
                    .ParaOleDbConn = rcOleDbConn
                    .ParaTableName = "rc_khlb"
                    .ParaField1 = "lbdm"
                    .ParaField2 = "lbmc"
                    .ParaField3 = "lbsm"
                    .ParaTitle = "客户类别"
                    .ParaOldValue = ""
                    .ParaAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtLbdm.Text = Trim(.ParaField1)
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
                    .ParaOleDbConn = rcOleDbConn
                    .ParaTableName = "rc_bmxx"
                    .ParaField1 = "bmdm"
                    .ParaField2 = "bmmc"
                    .ParaField3 = "bmsm"
                    .ParaTitle = "部门"
                    .ParaOldValue = ""
                    .ParaAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtBmdm.Text = Trim(.ParaField1)
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
        dtOeKhFpHzb.Clear()
        '取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            If Me.ChbLb.Checked Then
                rcOleDbCommand.CommandText = "SELECT oekhfphzbc.khlbdm,rc_khlb.lbmc AS khlbmc,oekhfphzbc.khdm,oekhfphzbc.khmc,oekhfphzbc.zydm,oekhfphzbc.zymc,oekhfphzbc.cplbdm,rc_cplb.lbmc AS cplbmc,oekhfphzbc.sl,oekhfphzbc.fzsl,oekhfphzbc.je,oekhfphzbc.se,oekhfphzbc.cbje,oekhfphzbc.mle,oekhfphzbc.mll FROM" &
                    " (SELECT oekhfphzbb.khlbdm,oekhfphzbb.khdm,oekhfphzbb.khmc,oekhfphzbb.zydm,oekhfphzbb.zymc,oekhfphzbb.cplbdm,oekhfphzbb.sl,oekhfphzbb.fzsl,oekhfphzbb.je,oekhfphzbb.se,oekhfphzbb.cbje,(oekhfphzbb.je-oekhfphzbb.cbje) AS mle,CASE WHEN oekhfphzbb.je <> 0 THEN (oekhfphzbb.je-oekhfphzbb.cbje) / oekhfphzbb.je ELSE 0 END AS mll FROM" &
                    " (SELECT oekhfphzba.khdm,oekhfphzba.khmc,rc_khxx.zydm,rc_khxx.zymc,oekhfphzba.cplbdm,oekhfphzba.sl,oekhfphzba.fzsl,oekhfphzba.je,oekhfphzba.se,oekhfphzba.cbje,rc_khxx.lbdm AS khlbdm FROM" &
                    " (SELECT oekhfphzbd.khdm,oekhfphzbd.khmc,oekhfphzbd.cplbdm,SUM(oekhfphzbd.sl) AS sl,SUM(oekhfphzbd.fzsl) AS fzsl,SUM(oekhfphzbd.je) AS je,SUM(oekhfphzbd.se) AS se,SUM(oekhfphzbd.cbje) AS cbje FROM" &
                    " ((SELECT oe_fp.khdm,oe_fp.khmc,rc_cpxx.lbdm AS cplbdm,oe_fp.sl,(oe_fp.sl * rc_cpxx.cpweight/1000) AS fzsl,oe_fp.je,oe_fp.se,oe_fp.cbje FROM oe_fp,rc_lx,rc_cpxx WHERE SUBSTR(oe_fp.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_fp.djh,5,4) = rc_lx.kjnd AND lxgs = '产品销售单' AND oe_fp.cpdm = rc_cpxx.cpdm AND oe_fp.bdelete = 0 AND oe_fp.fprq >= ? AND oe_fp.fprq >= ? AND oe_fp.fprq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_fp.bmdm = '" & Me.TxtBmdm.Text & "'", "") & ")" &
                    IIf(Me.CheckBox1.Checked, " UNION ALL (SELECT oe_xsd.fpkhdm AS khdm,oe_xsd.fpkhmc AS khmc,rc_cpxx.lbdm AS cplbdm,oe_xsd.sl,(oe_xsd.sl * rc_cpxx.cpweight/1000) AS fzsl,oe_xsd.je,oe_xsd.se,oe_xsd.cbje FROM oe_xsd,rc_lx,rc_cpxx WHERE SUBSTR(oe_xsd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_xsd.djh,5,4) = rc_lx.kjnd AND lxgs = '产品送货单' AND oe_xsd.cpdm = rc_cpxx.cpdm AND oe_xsd.bdelete = 0 AND oe_xsd.sl <> 0 AND oe_xsd.je = 0 AND oe_xsd.xsrq >= ? AND oe_xsd.xsrq >= ? AND oe_xsd.xsrq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_xsd.bmdm = '" & Me.TxtBmdm.Text & "'", "") & ")", "") & ") oekhfphzbd GROUP BY oekhfphzbd.khdm,oekhfphzbd.khmc,oekhfphzbd.cplbdm) oekhfphzba LEFT JOIN rc_khxx ON oekhfphzba.khdm = rc_khxx.khdm) oekhfphzbb " & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " WHERE khlbdm = '" & Me.TxtLbdm.Text & "'", "") & ") oekhfphzbc LEFT JOIN rc_khlb ON oekhfphzbc.khlbdm = rc_khlb.lbdm LEFT JOIN rc_cplb ON oekhfphzbc.cplbdm = rc_cplb.lbdm"
            Else
                rcOleDbCommand.CommandText = "SELECT oekhfphzbc.khlbdm,rc_khlb.lbmc AS khlbmc,oekhfphzbc.khdm,oekhfphzbc.khmc,oekhfphzbc.zydm,oekhfphzbc.zymc,oekhfphzbc.sl,oekhfphzbc.fzsl,oekhfphzbc.je,oekhfphzbc.se,oekhfphzbc.cbje,oekhfphzbc.mle,oekhfphzbc.mll FROM" &
                    " (SELECT oekhfphzbb.khlbdm,oekhfphzbb.khdm,oekhfphzbb.khmc,oekhfphzbb.zydm,oekhfphzbb.zymc,oekhfphzbb.sl,oekhfphzbb.fzsl,oekhfphzbb.je,oekhfphzbb.se,oekhfphzbb.cbje,(oekhfphzbb.je-oekhfphzbb.cbje) AS mle,CASE WHEN oekhfphzbb.je <> 0 THEN (oekhfphzbb.je-oekhfphzbb.cbje) / oekhfphzbb.je ELSE 0 END AS mll FROM" &
                    " (SELECT oekhfphzba.khdm,oekhfphzba.khmc,rc_khxx.zydm,rc_khxx.zymc,oekhfphzba.sl,oekhfphzba.fzsl,oekhfphzba.je,oekhfphzba.se,oekhfphzba.cbje,rc_khxx.lbdm AS khlbdm FROM" &
                    " (SELECT oekhfphzbd.khdm,oekhfphzbd.khmc,SUM(oekhfphzbd.sl) AS sl,SUM(oekhfphzbd.fzsl) AS fzsl,SUM(oekhfphzbd.je) AS je,SUM(oekhfphzbd.se) AS se,SUM(oekhfphzbd.cbje) AS cbje FROM" &
                    " ((SELECT oe_fp.khdm,oe_fp.khmc,oe_fp.sl,(oe_fp.sl * rc_cpxx.cpweight/1000) AS fzsl,oe_fp.je,oe_fp.se,oe_fp.cbje FROM oe_fp,rc_lx,rc_cpxx WHERE SUBSTR(oe_fp.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_fp.djh,5,4) = rc_lx.kjnd AND lxgs = '产品销售单' AND oe_fp.cpdm = rc_cpxx.cpdm AND oe_fp.bdelete = 0 AND oe_fp.fprq >= ? AND oe_fp.fprq >= ? AND oe_fp.fprq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_fp.bmdm = '" & Me.TxtBmdm.Text & "'", "") & ")" &
                    IIf(Me.CheckBox1.Checked, " UNION ALL (SELECT oe_xsd.fpkhdm AS khdm,oe_xsd.fpkhmc AS khmc,oe_xsd.sl,(oe_xsd.sl * rc_cpxx.cpweight/1000) AS fzsl,oe_xsd.je,oe_xsd.se,oe_xsd.cbje FROM oe_xsd,rc_lx,rc_cpxx WHERE SUBSTR(oe_xsd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_xsd.djh,5,4) = rc_lx.kjnd AND lxgs = '产品送货单' AND oe_xsd.cpdm = rc_cpxx.cpdm AND oe_xsd.bdelete = 0 AND oe_xsd.sl <> 0 AND oe_xsd.je = 0 AND oe_xsd.xsrq >= ? AND oe_xsd.xsrq >= ? AND oe_xsd.xsrq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_xsd.bmdm = '" & Me.TxtBmdm.Text & "'", "") & ")", "") & ") oekhfphzbd GROUP BY oekhfphzbd.khdm,oekhfphzbd.khmc) oekhfphzba LEFT JOIN rc_khxx ON oekhfphzba.khdm = rc_khxx.khdm) oekhfphzbb " & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " WHERE khlbdm = '" & Me.TxtLbdm.Text & "'", "") & ") oekhfphzbc LEFT JOIN rc_khlb ON oekhfphzbc.khlbdm = rc_khlb.lbdm"
            End If
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
            If Me.CheckBox1.Checked Then
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
            End If
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("oekhfphzb") IsNot Nothing Then
                rcDataset.Tables("oekhfphzb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "oekhfphzb")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Dim rcDataRow As DataRow
        rcDataRow = rcDataset.Tables("oekhfphzb").NewRow
        rcDataRow.Item("khdm") = "合计"
        rcDataRow.Item("sl") = dtOeKhFpHzb.Compute("Sum(sl)", "")
        rcDataRow.Item("fzsl") = dtOeKhFpHzb.Compute("Sum(fzsl)", "")
        rcDataRow.Item("je") = dtOeKhFpHzb.Compute("Sum(je)", "")
        rcDataRow.Item("se") = dtOeKhFpHzb.Compute("Sum(se)", "")
        rcDataRow.Item("cbje") = dtOeKhFpHzb.Compute("Sum(cbje)", "")
        rcDataRow.Item("mle") = dtOeKhFpHzb.Compute("Sum(mll)", "")
        rcDataset.Tables("oekhfphzb").Rows.Add(rcDataRow)

        '调用表单
        Dim rcFrm As New FrmOeKhFpHzbz
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("oekhfphzb"), "TRUE", "khdm", DataViewRowState.CurrentRows)
            .Label2.Text = DtpHzrqBegin.Value & "至" & DtpHzrqEnd.Value
            '.Label3.Text = "仓库：" & Trim(Me.TxtCkdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class