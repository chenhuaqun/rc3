Imports System.Data.OleDb

Public Class FrmPoCgdCx
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable '我们要利用该datatable进行金额计算
    ReadOnly dtCgdLb As New DataTable("cgdlb")

    Private Sub FrmCgdCx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        DtpBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '取单据类型数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE kjnd = ? AND lxgs = '物料采购订单' ORDER BY pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_lx") IsNot Nothing Then
                Me.rcDataset.Tables("rc_lx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_lx")
        Catch ex As Exception
            MsgBox("程序错误。读取单据类型。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Dim rcDataRow As DataRow
        rcDataRow = rcDataSet.Tables("rc_lx").NewRow
        rcDataRow.Item("pzlxdm") = "0000"
        rcDataRow.Item("pzlxjc") = "全部单据"
        rcDataSet.Tables("rc_lx").Rows.Add(rcDataRow)
        If rcDataSet.Tables("rc_lx").Rows.Count = 0 Then
            MsgBox("请定义单据类型。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        BindDropDownList(CmbPzlxjc, rcDataSet.Tables("rc_lx"), "pzlxdm", "pzlxjc")
        CmbPzlxjc.SelectedValue = "0000"
        '数据绑定
        dtCgdLb.Columns.Add("djh", Type.GetType("System.String"))
        dtCgdLb.Columns.Add("xh", Type.GetType("System.Int32"))
        dtCgdLb.Columns.Add("cgrq", Type.GetType("System.DateTime"))
        dtCgdLb.Columns.Add("sgddh", Type.GetType("System.String"))
        dtCgdLb.Columns.Add("csdm", Type.GetType("System.String"))
        dtCgdLb.Columns.Add("csmc", Type.GetType("System.String"))
        dtCgdLb.Columns.Add("cpdm", Type.GetType("System.String"))
        dtCgdLb.Columns.Add("cpmc", Type.GetType("System.String"))
        dtCgdLb.Columns.Add("oldcpdm", Type.GetType("System.String"))
        dtCgdLb.Columns.Add("sl", Type.GetType("System.Double"))
        dtCgdLb.Columns.Add("dw", Type.GetType("System.String"))
        dtCgdLb.Columns.Add("mjsl", Type.GetType("System.Double"))
        dtCgdLb.Columns.Add("fzsl", Type.GetType("System.Double"))
        dtCgdLb.Columns.Add("fzdw", Type.GetType("System.String"))
        dtCgdLb.Columns.Add("dj", Type.GetType("System.Double"))
        dtCgdLb.Columns.Add("hsdj", Type.GetType("System.Double"))
        dtCgdLb.Columns.Add("je", Type.GetType("System.Double"))
        dtCgdLb.Columns.Add("shlv", Type.GetType("System.Double"))
        dtCgdLb.Columns.Add("se", Type.GetType("System.Double"))
        dtCgdLb.Columns.Add("jese", Type.GetType("System.Double"))
        dtCgdLb.Columns.Add("jhshrq", Type.GetType("System.DateTime"))
        dtCgdLb.Columns.Add("jhmemo", Type.GetType("System.String"))
        dtCgdLb.Columns.Add("cgjhdjh", Type.GetType("System.String"))
        dtCgdLb.Columns.Add("cgjhxh", Type.GetType("System.Int32"))
        dtCgdLb.Columns.Add("srr", Type.GetType("System.String"))
        dtCgdLb.Columns.Add("srrq", Type.GetType("System.String"))
        dtCgdLb.Columns.Add("shr", Type.GetType("System.String"))
        dtCgdLb.Columns.Add("shrq", Type.GetType("System.String"))
        dtCgdLb.Columns.Add("rksl", Type.GetType("System.Double"))
        dtCgdLb.Columns.Add("rkje", Type.GetType("System.Double"))
        dtCgdLb.Columns.Add("rkrq", Type.GetType("System.String"))
        dtCgdLb.Columns.Add("fpsl", Type.GetType("System.Double"))
        dtCgdLb.Columns.Add("fpje", Type.GetType("System.Double"))
        dtCgdLb.Columns.Add("wrksl", Type.GetType("System.Double"))
        dtCgdLb.Columns.Add("wrkje", Type.GetType("System.Double"))
        dtCgdLb.Columns.Add("bclosed", Type.GetType("System.Boolean"))
        rcDataSet.Tables.Add(dtCgdLb)
        With dtCgdLb
            .Columns("sgddh").DefaultValue = ""
            .Columns("csdm").DefaultValue = ""
            .Columns("cpdm").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("mjsl").DefaultValue = 0.0
            .Columns("fzsl").DefaultValue = 0.0
            '.Columns("jhshrq").DefaultValue = Now.Date().AddDays(7)
            .Columns("jhmemo").DefaultValue = ""
            .Columns("bclosed").DefaultValue = False
        End With

    End Sub

#Region "物料类别编码的事件"

    Private Sub Txtlbdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLbdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_cplb"
                    .paraField1 = "lbdm"
                    .paraField2 = "lbmc"
                    .paraField3 = "lbsm"
                    .paraTitle = "物料类别"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtLbdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub Txtlbdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtLbdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtLbdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_cplb WHERE (lbdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = Trim(TxtLbdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_cplb") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_cplb").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_cplb")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_cplb").Rows.Count > 0 Then
                TxtLbdm.Text = Trim(rcDataset.Tables("rc_cplb").Rows(0).Item("lbdm"))
                'LblLbmc.Text = Trim(rcDataset.Tables("rc_cplb").Rows(0).Item("lbmc"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "物料编码事件"

    Private Sub TxtCpdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCpdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF34
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_cpxx"
                    .paraField1 = "cpdm"
                    .paraField2 = "cpmc"
                    .paraField3 = "dw"
                    .paraField4 = "cpsm"
                    .paraOrderField = "cpmc"
                    .paraTitle = "物料"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtCpdm.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtCpdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCpdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtCpdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT cpdm,cpmc,dw,kuwei FROM rc_cpxx WHERE rc_cpxx.cpdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_cpxx") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_cpxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_cpxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_cpxx").Rows.Count = 0 Then
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "供应商编码事件"

    Private Sub TxtCsdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCsdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_csxx"
                    .paraField1 = "csdm"
                    .paraField2 = "csmc"
                    .paraField3 = "cssm"
                    .paraTitle = "供应商"
                    .paraOldValue = ""
                    .paraAddName = ""
                    .paraOrderField = "csmc"
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtCsdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtCsdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCsdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtCsdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_csxx WHERE (csdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(TxtCsdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_csxx") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_csxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_csxx")
            Catch ex As Exception
                MsgBox("程序错误。读取供应商编码。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_csxx").Rows.Count > 0 Then
                Me.TxtCsdm.Text = Trim(rcDataSet.Tables("rc_csxx").Rows(0).Item("csdm"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

    Private Sub ChbRk_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbRk.CheckedChanged
        If Me.ChbRk.Checked Or Me.ChbSh.Checked Or Me.ChbWfk.Checked Then
            Me.DtpBegin.Enabled = False
            Me.DtpEnd.Enabled = False
        Else
            Me.DtpBegin.Enabled = True
            Me.DtpEnd.Enabled = True
        End If
        If Me.ChbRk.Checked Then
            Me.ChbSh.Checked = False
            Me.ChbWfk.Checked = False
            Me.ChbLbfs.Checked = True
        End If
    End Sub

    Private Sub ChbSh_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbSh.CheckedChanged
        If Me.ChbRk.Checked Or Me.ChbSh.Checked Or Me.ChbWfk.Checked Then
            Me.DtpBegin.Enabled = False
            Me.DtpEnd.Enabled = False
        Else
            Me.DtpBegin.Enabled = True
            Me.DtpEnd.Enabled = True
        End If
        If Me.ChbSh.Checked Then
            Me.ChbRk.Checked = False
            Me.ChbWfk.Checked = False
            Me.ChbLbfs.Checked = True
        End If
    End Sub

    Private Sub ChbWfk_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbWfk.CheckedChanged
        If Me.ChbRk.Checked Or Me.ChbSh.Checked Or Me.ChbWfk.Checked Then
            Me.DtpBegin.Enabled = False
            Me.DtpEnd.Enabled = False
        Else
            Me.DtpBegin.Enabled = True
            Me.DtpEnd.Enabled = True
        End If
        If Me.ChbWfk.Checked Then
            Me.ChbRk.Checked = False
            Me.ChbSh.Checked = False
            Me.ChbLbfs.Checked = True
        End If
    End Sub

    Private Sub ChbLbfs_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbLbfs.CheckedChanged
        If Me.ChbLbfs.Checked Then
            Me.TxtLbdm.Enabled = True
            Me.TxtCpdm.Enabled = True
            Me.TxtCpmc.Enabled = True
        Else
            Me.TxtLbdm.Enabled = False
            Me.TxtCpdm.Enabled = False
            Me.TxtCpmc.Enabled = False
        End If
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If Me.ChbLbfs.Checked Then
            '取数据
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT po_cgd.djh,po_cgd.xh,po_cgd.cgrq,po_cgd.sgddh,po_cgd.csdm,po_cgd.csmc,rc_csxx.fktj,rc_csxx.fkts,po_cgd.cpdm,rc_cpxx.cpmc,rc_cpxx.oldcpdm,po_cgd.jhshrq,po_cgd.sl,po_cgd.dw,po_cgd.mjsl,po_cgd.fzsl,po_cgd.fzdw,po_cgd.dj,po_cgd.hsdj,po_cgd.je,po_cgd.shlv,po_cgd.se,po_cgd.je+po_cgd.se AS jese,po_cgd.cgmemo,po_cgd.cgjhdjh,po_cgd.cgjhxh,po_cgd.rksl,po_cgd.rkje,po_cgd.rkrq,po_cgd.fpsl,po_cgd.fpje,po_cgd.fkje,po_cgd.sl - po_cgd.rksl AS wrksl,ROUND((po_cgd.sl - po_cgd.rksl)* po_cgd.hsdj,2) AS wrkje,po_cgd.srr,po_cgd.srrq,po_cgd.shr,po_cgd.shrq,po_cgd.bclosed FROM po_cgd,rc_cpxx,rc_csxx WHERE po_cgd.cpdm = rc_cpxx.cpdm AND po_cgd.csdm = rc_csxx.csdm" & IIf(Me.ChbWfk.Checked, " AND rc_csxx.fktj ='款到发货' AND po_cgd.je + po_cgd.se <> po_cgd.fkje AND po_cgd.bclosed = 0", IIf(Me.ChbSh.Checked, " AND po_cgd.shr IS NULL AND po_cgd.bclosed = 0", IIf(Me.ChbRk.Checked, " AND po_cgd.sl <> po_cgd.rksl AND po_cgd.bclosed = 0", " AND po_cgd.cgrq >= ? AND po_cgd.cgrq <= ?"))) & " AND SUBSTR(po_cgd.djh,11, 5) >= ?  AND SUBSTR(po_cgd.djh,11,5) <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " AND po_cgd.cpdm = '" & Trim(Me.TxtCpdm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpmc.Text), " and po_cgd.cpmc Like '%" & Trim(Me.TxtCpmc.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND rc_cpxx.lbdm Like '" & Trim(Me.TxtLbdm.Text) & "%'", "") & IIf(Trim(Me.TxtCsdm.Text).Length > 0, " and po_cgd.csdm = '" & Trim(Me.TxtCsdm.Text) & "'", "") & IIf(Me.CmbPzlxjc.SelectedValue <> "0000", " AND SUBSTR(po_cgd.djh,1, 4) ='" & Me.CmbPzlxjc.SelectedValue & "'", "") & " ORDER BY po_cgd.djh,po_cgd.xh"
                rcOleDbCommand.Parameters.Clear()
                If Not ChbRk.Checked And Not Me.ChbSh.Checked And Not Me.ChbWfk.Checked Then
                    rcOleDbCommand.Parameters.Add("@cgrq1", OleDbType.Date, 8).Value = DtpBegin.Value
                    rcOleDbCommand.Parameters.Add("@cgrq2", OleDbType.Date, 8).Value = Me.DtpEnd.Value
                End If
                rcOleDbCommand.Parameters.Add("@djh1", OleDbType.VarChar, 5).Value = NudDjhBegin.Value.ToString.PadLeft(5, "0")
                rcOleDbCommand.Parameters.Add("@djh2", OleDbType.VarChar, 5).Value = NudDjhEnd.Value.ToString.PadLeft(5, "0")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("cgdlb") IsNot Nothing Then
                    rcDataSet.Tables("cgdlb").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "cgdlb")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("cgdlb").Rows.Count <= 0 Then
                MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            Dim rcDataRow As DataRow
            rcDataRow = rcDataSet.Tables("cgdlb").NewRow
            rcDataRow.Item("djh") = "合计"
            rcDataRow.Item("sl") = dtCgdLb.Compute("Sum(sl)", "")
            rcDataRow.Item("fzsl") = dtCgdLb.Compute("Sum(fzsl)", "")
            rcDataRow.Item("je") = dtCgdLb.Compute("Sum(je)", "")
            rcDataRow.Item("se") = dtCgdLb.Compute("Sum(se)", "")
            rcDataRow.Item("jese") = dtCgdLb.Compute("Sum(jese)", "")
            rcDataRow.Item("rksl") = dtCgdLb.Compute("Sum(rksl)", "")
            rcDataRow.Item("rkje") = dtCgdLb.Compute("Sum(rkje)", "")
            rcDataRow.Item("fpsl") = dtCgdLb.Compute("Sum(fpsl)", "")
            rcDataRow.Item("fpje") = dtCgdLb.Compute("Sum(fpje)", "")
            rcDataRow.Item("wrksl") = dtCgdLb.Compute("Sum(rksl)", "")
            rcDataRow.Item("wrkje") = dtCgdLb.Compute("Sum(rkje)", "")
            rcDataSet.Tables("cgdlb").Rows.Add(rcDataRow)
            '调用表单
            Dim rcFrm As New FrmPoCgdCxLb
            With rcFrm
                .ParaDataSet = rcDataSet
                .ParaDataView = New DataView(rcDataSet.Tables("cgdlb"), "TRUE", "djh", DataViewRowState.CurrentRows)
                .WindowState = FormWindowState.Maximized
                .MdiParent = Me.MdiParent
                .Show()
            End With
        Else
            '取数据
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT djh FROM po_cgd WHERE" & IIf(Me.ChbRk.Checked, " po_cgd.sl <> po_cgd.rksl AND po_cgd.bclosed = 0", " po_cgd.cgrq >= ? AND po_cgd.cgrq <= ?") & " AND SUBSTR(djh,11,5) >= ?  AND SUBSTR(djh,11,5) <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " AND po_cgd.cpdm = '" & Trim(Me.TxtCpdm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpmc.Text), " and po_cgd.cpmc Like '%" & Trim(Me.TxtCpmc.Text) & "%'", "") & IIf(Trim(Me.TxtCsdm.Text).Length > 0, " and po_cgd.csdm = '" & Trim(Me.TxtCsdm.Text) & "'", "") & IIf(Me.ChbSh.Checked, " AND po_cgd.shr IS NULL", "") & IIf(Me.CmbPzlxjc.SelectedValue <> "0000", " AND SUBSTR(po_cgd.djh,1, 4) ='" & Me.CmbPzlxjc.SelectedValue & "'", "") & " GROUP BY djh ORDER BY djh"
                rcOleDbCommand.Parameters.Clear()
                If Not Me.ChbRk.Checked Then
                    rcOleDbCommand.Parameters.Add("@cgrq1", OleDbType.Date, 8).Value = DtpBegin.Value
                    rcOleDbCommand.Parameters.Add("@cgrq2", OleDbType.Date, 8).Value = Me.DtpEnd.Value
                End If
                rcOleDbCommand.Parameters.Add("@djh1", OleDbType.VarChar, 5).Value = NudDjhBegin.Value.ToString.PadLeft(5, "0")
                rcOleDbCommand.Parameters.Add("@djh2", OleDbType.VarChar, 5).Value = NudDjhEnd.Value.ToString.PadLeft(5, "0")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("ckdml") IsNot Nothing Then
                    rcDataSet.Tables("ckdml").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "ckdml")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("ckdml").Rows.Count <= 0 Then
                MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            '调用表单
            Dim rcFrm As New FrmPoCgdCxz
            With rcFrm
                .ParaDataSet = rcDataSet
                .WindowState = FormWindowState.Maximized
                .MdiParent = Me.MdiParent
                .Show()
            End With
        End If
    End Sub

End Class