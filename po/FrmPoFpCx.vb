Imports System.Data.OleDb

Public Class FrmPoFpCx
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable '我们要利用该datatable进行金额计算
    ReadOnly dtFp As New DataTable("fplb")

    Private Sub FrmPoFpCx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        DtpBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '取单据类型数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE kjnd = ? AND lxgs = '物料入库单' ORDER BY pzlxdm"
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
        dtFp.Columns.Add("djh", Type.GetType("System.String"))
        dtFp.Columns.Add("xh", Type.GetType("System.Int32"))
        dtFp.Columns.Add("fprq", Type.GetType("System.DateTime"))
        dtFp.Columns.Add("bdelete", Type.GetType("System.Boolean"))
        dtFp.Columns.Add("zydm", Type.GetType("System.String"))
        dtFp.Columns.Add("zymc", Type.GetType("System.String"))
        dtFp.Columns.Add("csdm", Type.GetType("System.String"))
        dtFp.Columns.Add("csmc", Type.GetType("System.String"))
        dtFp.Columns.Add("yspz", Type.GetType("System.String"))
        dtFp.Columns.Add("cpdm", Type.GetType("System.String"))
        dtFp.Columns.Add("cpmc", Type.GetType("System.String"))
        dtFp.Columns.Add("sl", Type.GetType("System.Double"))
        dtFp.Columns.Add("dw", Type.GetType("System.String"))
        dtFp.Columns.Add("mjsl", Type.GetType("System.Double"))
        dtFp.Columns.Add("fzsl", Type.GetType("System.Double"))
        dtFp.Columns.Add("fzdw", Type.GetType("System.String"))
        dtFp.Columns.Add("dj", Type.GetType("System.Double"))
        dtFp.Columns.Add("hsdj", Type.GetType("System.Double"))
        dtFp.Columns.Add("je", Type.GetType("System.Double"))
        dtFp.Columns.Add("shlv", Type.GetType("System.Double"))
        dtFp.Columns.Add("se", Type.GetType("System.Double"))
        dtFp.Columns.Add("jese", Type.GetType("System.Double"))
        dtFp.Columns.Add("fpmemo", Type.GetType("System.String"))
        dtFp.Columns.Add("cgddjh", Type.GetType("System.String"))
        dtFp.Columns.Add("cgdxh", Type.GetType("System.Int32"))
        dtFp.Columns.Add("rkddjh", Type.GetType("System.String"))
        dtFp.Columns.Add("rkdxh", Type.GetType("System.Int32"))
        dtFp.Columns.Add("fkje", Type.GetType("System.Double"))
        dtFp.Columns.Add("wfje", Type.GetType("System.Double"))
        dtFp.Columns.Add("srr", Type.GetType("System.String"))
        dtFp.Columns.Add("srrq", Type.GetType("System.DateTime"))
        dtFp.Columns.Add("shr", Type.GetType("System.String"))
        dtFp.Columns.Add("shrq", Type.GetType("System.DateTime"))
        rcDataSet.Tables.Add(dtFp)
        With rcDataSet.Tables("fplb")
            .Columns("zydm").DefaultValue = ""
            .Columns("csdm").DefaultValue = ""
            .Columns("yspz").DefaultValue = ""
            .Columns("cpdm").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("mjsl").DefaultValue = 0.0
            .Columns("fzsl").DefaultValue = 0.0
            .Columns("dj").DefaultValue = 0
            .Columns("hsdj").DefaultValue = 0
            .Columns("je").DefaultValue = 0.0
            .Columns("shlv").DefaultValue = getParaValue("增值税默认税率", False)
            .Columns("se").DefaultValue = 0
            .Columns("jese").DefaultValue = 0
            .Columns("fpmemo").DefaultValue = ""
            .Columns("cgddjh").DefaultValue = ""
            .Columns("cgdxh").DefaultValue = 0
            .Columns("rkddjh").DefaultValue = ""
            .Columns("rkdxh").DefaultValue = 0
            .Columns("fkje").DefaultValue = 0
            .Columns("wfje").DefaultValue = 0
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
                rcOleDbCommand.CommandText = "SELECT cpdm,cpmc,dw FROM rc_cpxx WHERE (cpdm = ?)"
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
            If rcDataSet.Tables("rc_cpxx").Rows.Count > 0 Then
                Me.TxtCpdm.Text = rcDataSet.Tables("rc_cpxx").Rows(0).Item("cpdm")
            Else
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

#Region "职员编码的事件"

    Private Sub TxtZydm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtZydm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_zyxx"
                    .paraField1 = "zydm"
                    .paraField2 = "zymc"
                    .paraField3 = "zysm"
                    .paraTitle = "职员"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtZydm.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtZydm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtZydm.Validating
        If Not String.IsNullOrEmpty(Me.TxtZydm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT zydm,zymc FROM rc_zyxx WHERE (zydm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(TxtZydm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_zyxx") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_zyxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_zyxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_zyxx").Rows.Count > 0 Then
                Me.TxtZydm.Text = Trim(rcDataSet.Tables("rc_zyxx").Rows(0).Item("zydm"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

    Private Sub ChbSh_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbSh.CheckedChanged
        If Me.ChbSh.Checked Then
            Me.ChbWfk.Checked = False
            Me.ChbZf.Checked = False
            Me.ChbLbfs.Checked = True
            Me.DtpBegin.Enabled = False
            Me.DtpEnd.Enabled = False
        Else
            Me.DtpBegin.Enabled = True
            Me.DtpEnd.Enabled = True
        End If
    End Sub

    Private Sub ChbWfk_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbWfk.CheckedChanged
        If Me.ChbWfk.Checked Then
            Me.ChbSh.Checked = False
            Me.ChbZf.Checked = False
            Me.ChbLbfs.Checked = True
            Me.DtpBegin.Enabled = False
            Me.DtpEnd.Enabled = False
        Else
            Me.DtpBegin.Enabled = True
            Me.DtpEnd.Enabled = True
        End If
    End Sub

    Private Sub ChbZf_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbZf.CheckedChanged
        If Me.ChbZf.Checked Then
            Me.ChbSh.Checked = False
            Me.ChbWfk.Checked = False
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
                rcOleDbCommand.CommandText = "SELECT po_fp.djh,po_fp.xh,po_fp.fprq,po_fp.bdelete,po_fp.zydm,po_fp.zymc,po_fp.csdm,po_fp.csmc,rc_csxx.fktj,rc_csxx.fkts,po_fp.yspz,po_fp.cpdm,po_fp.cpmc,po_fp.sl,po_fp.dw,po_fp.mjsl,po_fp.fzsl,po_fp.fzdw,po_fp.dj,po_fp.hsdj,po_fp.je,po_fp.shlv,po_fp.se,(po_fp.je+po_fp.se) AS jese,po_fp.fkje,(po_fp.je+ po_fp.se - po_fp.fkje) AS wfje,po_fp.fpmemo,po_fp.cgddjh,po_fp.cgdxh,po_fp.rkddjh,po_fp.rkdxh,po_fp.rkddj,po_fp.rkdhsdj,po_fp.rkdje,po_fp.rkdshlv,po_fp.rkdse,(po_fp.je - po_fp.rkdje) AS rkdjece,(po_fp.se - po_fp.rkdse) AS rkdsece,po_fp.srr,po_fp.srrq,po_fp.shr,po_fp.shrq FROM po_fp,rc_cpxx,rc_csxx,rc_lx WHERE po_fp.cpdm = rc_cpxx.cpdm AND po_fp.csdm = rc_csxx.csdm AND SUBSTR(po_fp.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(po_fp.djh,5,4) = rc_lx.kjnd AND rc_lx.lxgs = '物料入库单'" & IIf(Me.ChbSh.Checked, " AND po_fp.shr IS NULL", "") & IIf(Me.ChbWfk.Checked, " AND rc_csxx.fktj ='月结' AND po_fp.je + po_fp.se <> po_fp.fkje AND po_fp.fprq + rc_csxx.fkts < SYSDATE", "") & IIf(Me.ChbZf.Checked, "", " AND po_fp.bdelete = 0") & IIf(Me.DtpBegin.Enabled, " AND TRUNC(po_fp.fprq,'dd') >= ? AND TRUNC(po_fp.fprq,'dd') <= ? AND SUBSTR(po_fp.djh,11, 5) >= ?  AND SUBSTR(po_fp.djh,11,5) <= ?", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " and po_fp.cpdm = '" & Trim(Me.TxtCpdm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpmc.Text), " and po_fp.cpmc Like '%" & Trim(Me.TxtCpmc.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " and rc_cpxx.lbdm Like '" & Trim(Me.TxtLbdm.Text) & "%'", "") & IIf(Trim(Me.TxtYspz.Text).Length > 0, " and po_fp.yspz Like '" & Trim(Me.TxtYspz.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCsdm.Text), " and po_fp.csdm = '" & Trim(Me.TxtCsdm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCsmc.Text), " and po_fp.csmc Like '%" & Trim(Me.TxtCsmc.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtZydm.Text), " and po_fp.zydm = '" & Trim(TxtZydm.Text) & "'", "") & IIf(Me.CmbPzlxjc.SelectedValue <> "0000", " AND SUBSTR(po_fp.djh,1, 4) ='" & Me.CmbPzlxjc.SelectedValue & "'", "") & " ORDER BY po_fp.djh"
                rcOleDbCommand.Parameters.Clear()
                If Me.DtpBegin.Enabled Then
                    rcOleDbCommand.Parameters.Add("@fprq1", OleDbType.Date, 8).Value = Me.DtpBegin.Value.Date
                    rcOleDbCommand.Parameters.Add("@fprq2", OleDbType.Date, 8).Value = Me.DtpEnd.Value.Date
                    rcOleDbCommand.Parameters.Add("@djh1", OleDbType.VarChar, 5).Value = Me.NudDjhBegin.Value.ToString.PadLeft(5, "0")
                    rcOleDbCommand.Parameters.Add("@djh2", OleDbType.VarChar, 5).Value = Me.NudDjhEnd.Value.ToString.PadLeft(5, "0")
                End If
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("fplb") IsNot Nothing Then
                    rcDataSet.Tables("fplb").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "fplb")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("fplb").Rows.Count <= 0 Then
                MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            Dim rcDataRow As DataRow
            rcDataRow = rcDataSet.Tables("fplb").NewRow
            rcDataRow.Item("djh") = "合计"
            rcDataRow.Item("sl") = rcDataSet.Tables("fplb").Compute("Sum(sl)", "")
            rcDataRow.Item("je") = rcDataSet.Tables("fplb").Compute("Sum(je)", "")
            rcDataRow.Item("se") = rcDataSet.Tables("fplb").Compute("Sum(se)", "")
            rcDataRow.Item("jese") = rcDataSet.Tables("fplb").Compute("Sum(jese)", "")
            rcDataRow.Item("rkdje") = rcDataSet.Tables("fplb").Compute("Sum(rkdje)", "")
            rcDataRow.Item("rkdse") = rcDataSet.Tables("fplb").Compute("Sum(rkdse)", "")
            rcDataRow.Item("rkdjece") = rcDataSet.Tables("fplb").Compute("Sum(rkdjece)", "")
            rcDataRow.Item("rkdsece") = rcDataSet.Tables("fplb").Compute("Sum(rkdsece)", "")
            rcDataRow.Item("fkje") = rcDataSet.Tables("fplb").Compute("Sum(fkje)", "")
            rcDataRow.Item("wfje") = rcDataSet.Tables("fplb").Compute("Sum(wfje)", "")
            rcDataSet.Tables("fplb").Rows.Add(rcDataRow)
            '调用表单
            Dim rcFrm As New FrmPoFpCxLb
            With rcFrm
                .ParaDataSet = rcDataSet
                .ParaDataView = New DataView(rcDataSet.Tables("fplb"), "TRUE", "djh", DataViewRowState.CurrentRows)
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
                rcOleDbCommand.CommandText = "SELECT djh FROM po_fp,rc_lx WHERE  SUBSTR(po_fp.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(po_fp.djh,5,4) = rc_lx.kjnd AND lxgs = '物料入库单' AND TRUNC(po_fp.fprq,'dd') >= ? AND TRUNC(po_fp.fprq,'dd') <= ? AND SUBSTR(djh,11,5) >= ?  AND SUBSTR(djh,11,5) <= ? " & IIf(Me.ChbZf.Checked, "", " AND po_fp.bdelete = 0") & IIf(Me.ChbSh.Checked, " AND po_fp.shr IS NULL", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCsdm.Text), " and po_fp.csdm = '" & Trim(Me.TxtCsdm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCsmc.Text), " and po_fp.csmc Like '%" & Trim(Me.TxtCsmc.Text) & "%'", "") & IIf(Trim(Me.TxtZydm.Text).Length > 0, " and po_fp.zydm = '" & Trim(TxtZydm.Text) & "'", "") & IIf(Trim(Me.TxtYspz.Text).Length > 0, " and po_fp.yspz Like '" & Trim(Me.TxtYspz.Text) & "%'", "") & " GROUP BY djh ORDER BY djh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@fprq1", OleDbType.Date, 8).Value = Me.DtpBegin.Value.Date
                rcOleDbCommand.Parameters.Add("@fprq2", OleDbType.Date, 8).Value = Me.DtpEnd.Value.Date
                rcOleDbCommand.Parameters.Add("@djh1", OleDbType.VarChar, 5).Value = NudDjhBegin.Value.ToString.PadLeft(5, "0")
                rcOleDbCommand.Parameters.Add("@djh2", OleDbType.VarChar, 5).Value = NudDjhEnd.Value.ToString.PadLeft(5, "0")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("fpml") IsNot Nothing Then
                    rcDataSet.Tables("fpml").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "fpml")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("fpml").Rows.Count <= 0 Then
                MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            '调用表单
            Dim rcFrm As New FrmPoFpCxz
            With rcFrm
                .ParaDataSet = rcDataSet
                .WindowState = FormWindowState.Maximized
                .MdiParent = Me.MdiParent
                .Show()
            End With
        End If
    End Sub
End Class