Imports System.Data.OleDb

Public Class FrmPoCgjhCx
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable '我们要利用该datatable进行金额计算
    ReadOnly dtCgjhLb As New DataTable("cgjhlb")
    ReadOnly dtCgjhNr As New DataTable("rc_cgjhnr")

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
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE kjnd = ? AND lxgs = '物料需求单' ORDER BY pzlxdm"
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
        dtCgjhLb.Columns.Add("djh", Type.GetType("System.String"))
        dtCgjhLb.Columns.Add("xh", Type.GetType("System.Int32"))
        dtCgjhLb.Columns.Add("jhrq", Type.GetType("System.DateTime"))
        dtCgjhLb.Columns.Add("bmdm", Type.GetType("System.String"))
        dtCgjhLb.Columns.Add("bmmc", Type.GetType("System.String"))
        dtCgjhLb.Columns.Add("cpdm", Type.GetType("System.String"))
        dtCgjhLb.Columns.Add("cpmc", Type.GetType("System.String"))
        dtCgjhLb.Columns.Add("sl", Type.GetType("System.Double"))
        dtCgjhLb.Columns.Add("dw", Type.GetType("System.String"))
        dtCgjhLb.Columns.Add("mjsl", Type.GetType("System.Double"))
        dtCgjhLb.Columns.Add("fzsl", Type.GetType("System.Double"))
        dtCgjhLb.Columns.Add("fzdw", Type.GetType("System.String"))
        dtCgjhLb.Columns.Add("jhshrq", Type.GetType("System.DateTime"))
        dtCgjhLb.Columns.Add("jhmemo", Type.GetType("System.String"))
        dtCgjhLb.Columns.Add("srr", Type.GetType("System.String"))
        dtCgjhLb.Columns.Add("srrq", Type.GetType("System.String"))
        dtCgjhLb.Columns.Add("shr", Type.GetType("System.String"))
        dtCgjhLb.Columns.Add("shrq", Type.GetType("System.String"))
        dtCgjhLb.Columns.Add("cgsl", Type.GetType("System.Double"))
        dtCgjhLb.Columns.Add("bcg", Type.GetType("System.Boolean"))
        dtCgjhLb.Columns.Add("bclosed", Type.GetType("System.Boolean"))
        dtCgjhLb.Columns.Add("rksl", Type.GetType("System.Double"))
        rcDataSet.Tables.Add(dtCgjhLb)
        With dtCgjhLb
            .Columns("cpdm").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("mjsl").DefaultValue = 0.0
            .Columns("fzsl").DefaultValue = 0.0
            .Columns("jhshrq").DefaultValue = Now.Date().AddDays(7)
            .Columns("jhmemo").DefaultValue = ""
            .Columns("cgsl").DefaultValue = 0.0
            .Columns("bcg").DefaultValue = False
            .Columns("bclosed").DefaultValue = False
            .Columns("rksl").DefaultValue = 0.0
        End With
        dtCgjhNr.Columns.Add("cpdm", Type.GetType("System.String"))
        dtCgjhNr.Columns.Add("cpmc", Type.GetType("System.String"))
        dtCgjhNr.Columns.Add("sl", Type.GetType("System.Double"))
        dtCgjhNr.Columns.Add("dw", Type.GetType("System.String"))
        dtCgjhNr.Columns.Add("mjsl", Type.GetType("System.Double"))
        dtCgjhNr.Columns.Add("fzsl", Type.GetType("System.Double"))
        dtCgjhNr.Columns.Add("fzdw", Type.GetType("System.String"))
        dtCgjhNr.Columns.Add("jhshrq", Type.GetType("System.DateTime"))
        dtCgjhNr.Columns.Add("jhmemo", Type.GetType("System.String"))
        dtCgjhNr.Columns.Add("cgsl", Type.GetType("System.Double"))
        dtCgjhNr.Columns.Add("bcg", Type.GetType("System.Boolean"))
        dtCgjhNr.Columns.Add("bclosed", Type.GetType("System.Boolean"))
        dtCgjhNr.Columns.Add("rksl", Type.GetType("System.Double"))
        rcDataSet.Tables.Add(dtCgjhNr)
        With dtCgjhNr
            .Columns("cpdm").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("mjsl").DefaultValue = 0.0
            .Columns("fzsl").DefaultValue = 0.0
            .Columns("jhshrq").DefaultValue = Now.Date().AddDays(7)
            .Columns("jhmemo").DefaultValue = ""
            .Columns("cgsl").DefaultValue = 0.0
            .Columns("bcg").DefaultValue = False
            .Columns("bclosed").DefaultValue = False
            .Columns("rksl").DefaultValue = 0.0
        End With

    End Sub

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
                If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_cpxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_cpxx").Rows.Count = 0 Then
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
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "SELECT * FROM rc_bmxx WHERE (bmdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(TxtBmdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_bmxx") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_bmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_bmxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_bmxx").Rows.Count > 0 Then
                TxtBmdm.Text = Trim(rcDataSet.Tables("rc_bmxx").Rows(0).Item("bmdm"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If Me.ChbLbfs.Checked Then
            '取数据
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT po_cgjh.djh,po_cgjh.xh,po_cgjh.jhrq,po_cgjh.bmdm,po_cgjh.bmmc,po_cgjh.cpdm,rc_cpxx.oldcpdm,rc_cpxx.cpmc,po_cgjh.sl,rc_cpxx.dw,po_cgjh.mjsl,po_cgjh.fzsl,rc_cpxx.fzdw,po_cgjh.jhshrq,po_cgjh.jhmemo,po_cgjh.srr,po_cgjh.srrq,po_cgjh.shr,po_cgjh.shrq,po_cgjh.cgsl,po_cgjh.bcg,po_cgjh.bclosed,po_cgjh.rksl FROM po_cgjh,rc_cpxx WHERE po_cgjh.cpdm = rc_cpxx.cpdm" & IIf(Me.ChbSh.Checked, " AND po_cgjh.shr IS NULL", "") & IIf(Me.ChbCg.Checked, " AND po_cgjh.bcg = 0 AND po_cgjh.bclosed = 0", " AND jhrq >= ? AND jhrq <= ?") & " AND SUBSTR(po_cgjh.djh,11, 5) >= ?  AND SUBSTR(po_cgjh.djh,11,5) <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " and po_cgjh.cpdm = '" & Trim(Me.TxtCpdm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpmc.Text), " AND rc_cpxx.cpmc Like '%" & Trim(Me.TxtCpmc.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " and po_cgjh.bmdm LIKE '" & Trim(Me.TxtBmdm.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtSrr.Text), " and po_cgjh.srr LIKE '%" & Trim(Me.TxtSrr.Text) & "%'", "") & IIf(Me.CmbPzlxjc.SelectedValue <> "0000", " AND SUBSTR(po_cgjh.djh,1, 4) ='" & Me.CmbPzlxjc.SelectedValue & "'", "") & " ORDER BY po_cgjh.djh,po_cgjh.xh" ' AND po_cgjh.cgsl <> po_cgjh.sl
                rcOleDbCommand.Parameters.Clear()
                If Not Me.ChbCg.Checked Then
                    rcOleDbCommand.Parameters.Add("@jhrq1", OleDbType.Date, 8).Value = DtpBegin.Value
                    rcOleDbCommand.Parameters.Add("@jhrq2", OleDbType.Date, 8).Value = Me.DtpEnd.Value
                End If
                rcOleDbCommand.Parameters.Add("@djh1", OleDbType.VarChar, 5).Value = NudDjhBegin.Value.ToString.PadLeft(5, "0")
                rcOleDbCommand.Parameters.Add("@djh2", OleDbType.VarChar, 5).Value = NudDjhEnd.Value.ToString.PadLeft(5, "0")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("cgjhlb") IsNot Nothing Then
                    rcDataSet.Tables("cgjhlb").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "cgjhlb")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("cgjhlb").Rows.Count <= 0 Then
                MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            '调用表单
            Dim rcFrm As New FrmPoCgjhCxLb
            With rcFrm
                .ParaDataSet = rcDataSet
                .ParaDataView = New DataView(rcDataSet.Tables("cgjhlb"), "TRUE", "djh", DataViewRowState.CurrentRows)
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
                rcOleDbCommand.CommandText = "SELECT djh FROM po_cgjh WHERE jhrq >= ? AND jhrq <= ? AND SUBSTR(djh,11,5) >= ?  AND SUBSTR(djh,11,5) <= ? " & IIf(Me.ChbSh.Checked, " AND po_cgjh.shr IS NULL", "") & IIf(Me.CmbPzlxjc.SelectedValue <> "0000", " AND SUBSTR(po_cgjh.djh,1, 4) ='" & Me.CmbPzlxjc.SelectedValue & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " and po_cgjh.bmdm LIKE '" & Trim(Me.TxtBmdm.Text) & "%'", "") & " GROUP BY djh ORDER BY djh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@jhrq1", OleDbType.Date, 8).Value = DtpBegin.Value
                rcOleDbCommand.Parameters.Add("@jhrq2", OleDbType.Date, 8).Value = Me.DtpEnd.Value
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
            Dim rcFrm As New FrmPoCgjhCxz
            With rcFrm
                .ParaDataSet = rcDataSet
                .WindowState = FormWindowState.Maximized
                .MdiParent = Me.MdiParent
                .Show()
            End With
        End If
    End Sub

    Private Sub ChbLbfs_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbLbfs.CheckedChanged
        If Me.ChbLbfs.Checked Then
            Me.TxtCpdm.Enabled = True
            Me.TxtCpmc.Enabled = True
        Else
            Me.TxtCpdm.Enabled = False
            Me.TxtCpmc.Enabled = False
            Me.ChbCg.Checked = False
        End If
    End Sub

    Private Sub ChbCg_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbCg.CheckedChanged
        If Me.ChbCg.Checked Then
            Me.DtpBegin.Enabled = False
            Me.DtpEnd.Enabled = False
        Else
            Me.DtpBegin.Enabled = True
            Me.DtpEnd.Enabled = True
        End If
    End Sub
End Class