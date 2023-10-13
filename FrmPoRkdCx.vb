Imports System.Data.OleDb

Public Class FrmPoRkdCx
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable '我们要利用该datatable进行金额计算
    ReadOnly dtRkd As New DataTable("rkdlb")

    Private Sub FrmPoRkdCx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        DtpBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '取单据类型数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE kjnd = ? AND lxgs = '物料收货单' ORDER BY pzlxdm"
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
        dtRkd.Columns.Add("djh", Type.GetType("System.String"))
        dtRkd.Columns.Add("xh", Type.GetType("System.Int32"))
        dtRkd.Columns.Add("rkrq", Type.GetType("System.DateTime"))
        dtRkd.Columns.Add("bdelete", Type.GetType("System.Boolean"))
        dtRkd.Columns.Add("zydm", Type.GetType("System.String"))
        dtRkd.Columns.Add("zymc", Type.GetType("System.String"))
        dtRkd.Columns.Add("csdm", Type.GetType("System.String"))
        dtRkd.Columns.Add("csmc", Type.GetType("System.String"))
        dtRkd.Columns.Add("yspz", Type.GetType("System.String"))
        dtRkd.Columns.Add("ckdm", Type.GetType("System.String"))
        dtRkd.Columns.Add("ckmc", Type.GetType("System.String"))
        dtRkd.Columns.Add("cpdm", Type.GetType("System.String"))
        dtRkd.Columns.Add("cpmc", Type.GetType("System.String"))
        dtRkd.Columns.Add("kuwei", Type.GetType("System.String"))
        dtRkd.Columns.Add("sgddh", Type.GetType("System.String"))
        dtRkd.Columns.Add("pihao", Type.GetType("System.String"))
        dtRkd.Columns.Add("sl", Type.GetType("System.Double"))
        dtRkd.Columns.Add("dw", Type.GetType("System.String"))
        dtRkd.Columns.Add("mjsl", Type.GetType("System.Double"))
        dtRkd.Columns.Add("fzsl", Type.GetType("System.Double"))
        dtRkd.Columns.Add("fzdw", Type.GetType("System.String"))
        dtRkd.Columns.Add("dj", Type.GetType("System.Double"))
        dtRkd.Columns.Add("hsdj", Type.GetType("System.Double"))
        dtRkd.Columns.Add("je", Type.GetType("System.Double"))
        dtRkd.Columns.Add("shlv", Type.GetType("System.Double"))
        dtRkd.Columns.Add("se", Type.GetType("System.Double"))
        dtRkd.Columns.Add("jese", Type.GetType("System.Double"))
        dtRkd.Columns.Add("fkje", Type.GetType("System.Double"))
        dtRkd.Columns.Add("rkmemo", Type.GetType("System.String"))
        dtRkd.Columns.Add("cgddjh", Type.GetType("System.String"))
        dtRkd.Columns.Add("cgdxh", Type.GetType("System.Int32"))
        dtRkd.Columns.Add("cksl", Type.GetType("System.Double"))
        dtRkd.Columns.Add("ckje", Type.GetType("System.Double"))
        dtRkd.Columns.Add("fpsl", Type.GetType("System.Double"))
        dtRkd.Columns.Add("fpje", Type.GetType("System.Double"))
        dtRkd.Columns.Add("srr", Type.GetType("System.String"))
        dtRkd.Columns.Add("srrq", Type.GetType("System.DateTime"))
        dtRkd.Columns.Add("shr", Type.GetType("System.String"))
        dtRkd.Columns.Add("shrq", Type.GetType("System.DateTime"))
        rcDataSet.Tables.Add(dtRkd)
        With rcDataSet.Tables("rkdlb")
            .Columns("bdelete").DefaultValue = False
            .Columns("zydm").DefaultValue = ""
            .Columns("csdm").DefaultValue = ""
            .Columns("yspz").DefaultValue = ""
            .Columns("ckdm").DefaultValue = ""
            .Columns("cpdm").DefaultValue = ""
            .Columns("kuwei").DefaultValue = ""
            .Columns("sgddh").DefaultValue = ""
            .Columns("pihao").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("mjsl").DefaultValue = 0.0
            .Columns("fzsl").DefaultValue = 0.0
            .Columns("dj").DefaultValue = 0
            .Columns("hsdj").DefaultValue = 0
            .Columns("je").DefaultValue = 0.0
            .Columns("shlv").DefaultValue = getParaValue("增值税默认税率", False)
            .Columns("se").DefaultValue = 0
            .Columns("jese").DefaultValue = 0
            .Columns("rkmemo").DefaultValue = ""
            .Columns("cgddjh").DefaultValue = ""
            .Columns("cgdxh").DefaultValue = 0
            .Columns("cksl").DefaultValue = 0
            .Columns("ckje").DefaultValue = 0
            .Columns("fpsl").DefaultValue = 0
            .Columns("fpje").DefaultValue = 0
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
                rcOleDbCommand.CommandText = "SELECT cpdm,cpmc,dw,kuwei FROM rc_cpxx WHERE (cpdm = ?)"
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

#Region "仓库编码的事件"

    Private Sub TxtCkdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCkdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_ckxx"
                    .paraField1 = "ckdm"
                    .paraField2 = "ckmc"
                    .paraField3 = "cksm"
                    .paraTitle = "仓库"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtCkdm.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtCkdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCkdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtCkdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_ckxx WHERE (ckdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(TxtCkdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_ckxx") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_ckxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_ckxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_ckxx").Rows.Count > 0 Then
                Me.TxtCkdm.Text = Trim(rcDataSet.Tables("rc_ckxx").Rows(0).Item("ckdm"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

    Private Sub ChbSh_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbSh.CheckedChanged
        If Me.ChbSh.Checked Then
            Me.ChbCq.Checked = False
            Me.ChbFp.Checked = False
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

    Private Sub ChbFp_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbFp.CheckedChanged
        If Me.ChbFp.Checked Then
            Me.ChbSh.Checked = False
            Me.ChbCq.Checked = False
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

    Private Sub ChbCq_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbCq.CheckedChanged
        If Me.ChbCq.Checked Then
            Me.ChbSh.Checked = False
            Me.ChbFp.Checked = False
            Me.ChbWfk.Checked = False
            Me.ChbZf.Checked = False
            Me.NumericUpDown1.Visible = True
            Me.DtpEnd.Enabled = True
            Me.Label1.Visible = True
            Me.ChbLbfs.Checked = True
            Me.DtpBegin.Enabled = False
            Me.DtpEnd.Enabled = False
        Else
            Me.DtpBegin.Enabled = True
            Me.DtpEnd.Enabled = True
            Me.NumericUpDown1.Visible = False
            Me.Label1.Visible = False
        End If

    End Sub

    Private Sub ChbWfk_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbWfk.CheckedChanged
        If Me.ChbWfk.Checked Then
            Me.ChbCq.Checked = False
            Me.ChbFp.Checked = False
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
            Me.ChbFp.Checked = False
            Me.ChbCq.Checked = False
            Me.ChbWfk.Checked = False
        End If
    End Sub

    Private Sub ChbLbfs_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbLbfs.CheckedChanged
        If Me.ChbLbfs.Checked Then
            Me.TxtLbdm.Enabled = True
            Me.TxtCpdm.Enabled = True
            Me.TxtCpmc.Enabled = True
            Me.ChbCq.Enabled = True
            Me.ChbFp.Enabled = True
        Else
            Me.TxtLbdm.Enabled = False
            Me.TxtCpdm.Enabled = False
            Me.TxtCpmc.Enabled = False
            Me.ChbCq.Checked = False
            Me.ChbCq.Enabled = False
            Me.ChbFp.Enabled = False
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
                rcOleDbCommand.CommandText = "SELECT po_rkd.djh,po_rkd.xh,po_rkd.rkrq,po_rkd.bdelete,po_rkd.zydm,po_rkd.zymc,po_rkd.csdm,po_rkd.csmc,rc_csxx.fktj,rc_csxx.fkts,po_rkd.yspz,po_rkd.ckdm,po_rkd.ckmc,po_rkd.cpdm,po_rkd.cpmc,po_rkd.kuwei,po_rkd.sgddh,po_rkd.pihao,po_rkd.sl,po_rkd.dw,po_rkd.mjsl,po_rkd.fzsl,po_rkd.fzdw,po_rkd.dj,po_rkd.hsdj,po_rkd.je,po_rkd.shlv,po_rkd.se,(po_rkd.je+po_rkd.se) AS jese,po_rkd.fkje,po_rkd.rkmemo,po_rkd.cgddjh,po_rkd.cgdxh,po_rkd.cksl,po_rkd.ckje,po_rkd.fpsl,po_rkd.fpje,po_rkd.srr,po_rkd.srrq,po_rkd.shr,po_rkd.shrq FROM po_rkd,rc_cpxx,rc_csxx,rc_lx WHERE po_rkd.cpdm = rc_cpxx.cpdm AND po_rkd.csdm = rc_csxx.csdm AND SUBSTR(po_rkd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(po_rkd.djh,5,4) = rc_lx.kjnd AND rc_lx.lxgs = '物料收货单'" & IIf(Me.ChbSh.Checked, " AND po_rkd.shr IS NULL", "") & IIf(Me.ChbFp.Checked, " AND po_rkd.je <> 0 AND (po_rkd.sl > 0 AND po_rkd.sl > po_rkd.fpsl OR po_rkd.sl < 0 AND po_rkd.sl < po_rkd.fpsl) ", "") & IIf(Me.ChbCq.Checked, " AND po_rkd.sl > 0 AND po_rkd.sl > po_rkd.cksl AND po_rkd.rkrq <= ?", "") & IIf(Me.ChbWfk.Checked, " AND rc_csxx.fktj ='货到付款' AND po_rkd.je + po_rkd.se <> po_rkd.fkje AND po_rkd.rkrq + rc_csxx.fkts < SYSDATE", "") & IIf(Me.ChbZf.Checked, "", " AND po_rkd.bdelete = 0") & IIf(Me.DtpBegin.Enabled, " AND po_rkd.rkrq >= ? AND po_rkd.rkrq <= ? AND SUBSTR(po_rkd.djh,11, 5) >= ?  AND SUBSTR(po_rkd.djh,11,5) <= ?", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " AND po_rkd.cpdm = '" & Trim(Me.TxtCpdm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpmc.Text), " and po_rkd.cpmc Like '%" & Trim(Me.TxtCpmc.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " and rc_cpxx.lbdm Like '" & Trim(Me.TxtLbdm.Text) & "%'", "") & IIf(Trim(Me.TxtYspz.Text).Length > 0, " and po_rkd.yspz Like '" & Trim(Me.TxtYspz.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " and po_rkd.ckdm = '" & Trim(Me.TxtCkdm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCsdm.Text), " and po_rkd.csdm = '" & Trim(Me.TxtCsdm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCsmc.Text), " and po_rkd.csmc Like '%" & Trim(Me.TxtCsmc.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtZydm.Text), " and po_rkd.zydm = '" & Trim(TxtZydm.Text) & "'", "") & IIf(Me.CmbPzlxjc.SelectedValue <> "0000", " AND SUBSTR(po_rkd.djh,1, 4) ='" & Me.CmbPzlxjc.SelectedValue & "'", "") & " ORDER BY po_rkd.djh"
                rcOleDbCommand.Parameters.Clear()
                If Me.DtpBegin.Enabled Then
                    rcOleDbCommand.Parameters.Add("@rkrq1", OleDbType.Date, 8).Value = Me.DtpBegin.Value
                    rcOleDbCommand.Parameters.Add("@rkrq2", OleDbType.Date, 8).Value = Me.DtpEnd.Value
                    rcOleDbCommand.Parameters.Add("@djh1", OleDbType.VarChar, 5).Value = Me.NudBegin.Value.ToString.PadLeft(5, "0")
                    rcOleDbCommand.Parameters.Add("@djh2", OleDbType.VarChar, 5).Value = Me.NudEnd.Value.ToString.PadLeft(5, "0")
                Else
                    rcOleDbCommand.Parameters.Add("@rkrq2", OleDbType.Date, 8).Value = Me.DtpEnd.Value.AddDays(0 - Me.NumericUpDown1.Value)
                End If
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rkdlb") IsNot Nothing Then
                    rcDataSet.Tables("rkdlb").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rkdlb")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rkdlb").Rows.Count <= 0 Then
                MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            Dim rcDataRow As DataRow
            rcDataRow = rcDataSet.Tables("rkdlb").NewRow
            rcDataRow.Item("djh") = "合计"
            rcDataRow.Item("sl") = rcDataSet.Tables("rkdlb").Compute("Sum(sl)", "")
            rcDataRow.Item("fzsl") = rcDataSet.Tables("rkdlb").Compute("Sum(fzsl)", "")
            rcDataRow.Item("je") = rcDataSet.Tables("rkdlb").Compute("Sum(je)", "")
            rcDataRow.Item("se") = rcDataSet.Tables("rkdlb").Compute("Sum(se)", "")
            rcDataRow.Item("jese") = rcDataSet.Tables("rkdlb").Compute("Sum(jese)", "")
            rcDataRow.Item("fpsl") = rcDataSet.Tables("rkdlb").Compute("Sum(fpsl)", "")
            rcDataRow.Item("fpje") = rcDataSet.Tables("rkdlb").Compute("Sum(fpje)", "")
            rcDataRow.Item("cksl") = rcDataSet.Tables("rkdlb").Compute("Sum(cksl)", "")
            rcDataRow.Item("ckje") = rcDataSet.Tables("rkdlb").Compute("Sum(ckje)", "")
            rcDataRow.Item("fkje") = rcDataSet.Tables("rkdlb").Compute("Sum(fkje)", "")
            rcDataSet.Tables("rkdlb").Rows.Add(rcDataRow)
            '调用表单
            Dim rcFrm As New FrmPoRkdCxLb
            With rcFrm
                .ParaDataSet = rcDataSet
                .ParaDataView = New DataView(rcDataSet.Tables("rkdlb"), "TRUE", "djh", DataViewRowState.CurrentRows)
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
                rcOleDbCommand.CommandText = "SELECT djh FROM po_rkd,rc_lx WHERE  SUBSTR(po_rkd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(po_rkd.djh,5,4) = rc_lx.kjnd AND lxgs = '物料收货单' AND rkrq >= ? AND rkrq <= ? AND SUBSTR(djh,11,5) >= ?  AND SUBSTR(djh,11,5) <= ? " & IIf(Me.ChbSh.Checked, " AND po_rkd.shr IS NULL", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " and po_rkd.ckdm = '" & Trim(Me.TxtCkdm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCsdm.Text), " and po_rkd.csdm = '" & Trim(Me.TxtCsdm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCsmc.Text), " and po_rkd.csmc Like '%" & Trim(Me.TxtCsmc.Text) & "%'", "") & IIf(Trim(Me.TxtZydm.Text).Length > 0, " and po_rkd.zydm = '" & Trim(TxtZydm.Text) & "'", "") & IIf(Trim(Me.TxtYspz.Text).Length > 0, " and po_rkd.yspz Like '" & Trim(Me.TxtYspz.Text) & "%'", "") & " GROUP BY djh ORDER BY djh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@rkrq1", OleDbType.Date, 8).Value = DtpBegin.Value
                rcOleDbCommand.Parameters.Add("@rkrq2", OleDbType.Date, 8).Value = Me.DtpEnd.Value
                rcOleDbCommand.Parameters.Add("@djh1", OleDbType.VarChar, 5).Value = NudBegin.Value.ToString.PadLeft(5, "0")
                rcOleDbCommand.Parameters.Add("@djh2", OleDbType.VarChar, 5).Value = NudEnd.Value.ToString.PadLeft(5, "0")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rkdml") IsNot Nothing Then
                    rcDataSet.Tables("rkdml").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rkdml")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rkdml").Rows.Count <= 0 Then
                MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            '调用表单
            Dim rcFrm As New FrmPoRkdCxz
            With rcFrm
                .ParaDataSet = rcDataSet
                .WindowState = FormWindowState.Maximized
                .MdiParent = Me.MdiParent
                .Show()
            End With
        End If
    End Sub
End Class