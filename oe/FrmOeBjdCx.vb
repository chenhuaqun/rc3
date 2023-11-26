Imports System.Data.OleDb

Public Class FrmOeBjdCx
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Private Sub FrmOeBjdCx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        DtpBjrqBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpBjrqEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '取单据类型数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE kjnd = ? AND lxgs = '产品报价单' ORDER BY pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_lx") IsNot Nothing Then
                Me.rcDataSet.Tables("rc_lx").Clear()
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
    End Sub

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
                    .paraOrderField = "cpdm"
                    .paraTitle = "物料"
                    .paraOldValue = Me.TxtCpdm.Text
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtCpdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Return
                Me.TxtKhdm.Focus()
            Case Keys.Down
                Me.TxtKhdm.Focus()
            Case Keys.Up
                Me.NudDjhEnd.Focus()
        End Select
    End Sub

    Private Sub TxtKhdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtKhdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_khxx"
                    .paraField1 = "khdm"
                    .paraField2 = "khmc"
                    .paraField3 = "khsm"
                    .paraTitle = "客户"
                    .paraOldValue = ""
                    .paraAddName = ""
                    .paraOrderField = "khmc"
                    If .ShowDialog = DialogResult.OK Then
                        TxtKhdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Return
                Me.BtnOk.Focus()
            Case Keys.Down
                Me.BtnOk.Focus()
            Case Keys.Up
                Me.TxtCpdm.Focus()
        End Select
    End Sub

    'Private Sub ChbLbfs_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbLbfs.CheckedChanged
    '    If Me.ChbLbfs.Checked Then
    '        Me.TxtCpdm.Enabled = True
    '    Else
    '        Me.TxtCpdm.Enabled = False
    '        Me.TxtCpdm.Text = ""
    '    End If
    'End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        '权限控制
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT code AS pzlxdm FROM rc_userqx WHERE righttype = 'PZLX' AND User_Account = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = g_User_Account
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_lx") IsNot Nothing Then
                rcDataSet.Tables("rc_lx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_lx")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("rc_lx").Rows.Count <= 0 Then
            MsgBox("你无权查看该报表。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Return
        End If
        Dim strExpPzlxdm As String = ""
        Dim j As Integer
        For j = 0 To rcDataSet.Tables("rc_lx").Rows.Count - 1
            strExpPzlxdm = strExpPzlxdm & IIf(j = 0, "", " OR") & " SUBSTR(oe_bjd.djh,1,4) = '" & Trim(rcDataSet.Tables("rc_lx").Rows(j).Item("pzlxdm")) & "'"
        Next
        If String.IsNullOrEmpty(strExpPzlxdm) Then
            strExpPzlxdm = "0=0"
        End If
        If Me.ChbLbfs.Checked Then
            '取数据
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT oe_bjd.djh,oe_bjd.xh,oe_bjd.bjrq,oe_bjd.wbdm,oe_bjd.wbhl,oe_bjd.khdm,oe_bjd.khmc,oe_bjd.zydm,oe_bjd.zymc,oe_bjd.email,oe_bjd.bjtk,oe_bjd.khlh,oe_bjd.khcz,oe_bjd.cpdm,oe_bjd.cpmc,oe_bjd.cpgg,oe_bjd.dw,oe_bjd.zl,oe_bjd.dj,Case When oe_bjd.zl = 0 Then 0 Else Case When oe_bjd.wbhl = 1 Then oe_bjd.dj*oe_bjd.wbhl/oe_bjd.zl * 100 Else oe_bjd.dj * oe_bjd.wbhl * 1.1 / oe_bjd.zl * 100 End End As ckdw,oe_bjd.spq,oe_bjd.moq,oe_bjd.bjmemo,oe_bjd.srr,oe_bjd.shr,oe_bjd.jzr FROM oe_bjd WHERE oe_bjd.bjrq >= ? AND oe_bjd.bjrq <= ? AND SUBSTR(oe_bjd.djh,11, 5) >= ? AND SUBSTR(oe_bjd.djh,11,5) <= ? AND (" & strExpPzlxdm & ")" & IIf(Me.CmbPzlxjc.SelectedValue <> "0000", " AND SUBSTR(oe_bjd.djh,1, 4) ='" & Me.CmbPzlxjc.SelectedValue & "'", "") & IIf(Trim(TxtCpdm.Text).Length > 0, " and oe_bjd.cpdm = '" & Trim(TxtCpdm.Text) & "'", "") & IIf(Trim(TxtCpmc.Text).Length > 0, " and oe_bjd.cpmc LIKE '%" & TxtCpmc.Text & "%'", "") & IIf(Trim(TxtCpgg.Text).Length > 0, " and oe_bjd.cpgg LIKE '%" & Trim(TxtCpgg.Text) & "%'", "") & IIf(Trim(Me.TxtKhdm.Text).Length > 0, " and oe_bjd.khdm LIKE '" & LTrim(Me.TxtKhdm.Text) & "%'", "") & IIf(Trim(Me.TxtKhmc.Text).Length > 0, " AND oe_bjd.khmc LIKE '%" & Trim(Me.TxtKhmc.Text) & "%'", "") & IIf(Trim(TxtKhlh.Text).Length > 0, " and oe_bjd.khlh LIKE '%" & Trim(TxtKhlh.Text) & "%'", "") & " ORDER BY oe_bjd.djh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@bjrq1", OleDbType.Date, 8).Value = Me.DtpBjrqBegin.Value.Date
                rcOleDbCommand.Parameters.Add("@bjrq2", OleDbType.Date, 8).Value = Me.DtpBjrqEnd.Value.Date
                rcOleDbCommand.Parameters.Add("@djh1", OleDbType.VarChar, 5).Value = Me.NudDjhBegin.Value.ToString.PadLeft(5, "0")
                rcOleDbCommand.Parameters.Add("@djh2", OleDbType.VarChar, 5).Value = Me.NudDjhEnd.Value.ToString.PadLeft(5, "0")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("bjdlb") IsNot Nothing Then
                    rcDataSet.Tables("bjdlb").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "bjdlb")
            Catch ex As Exception
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("bjdlb").Rows.Count <= 0 Then
                MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            '调用表单
            Dim rcFrm As New FrmOeBjdCxLb
            With rcFrm
                .ParaDataSet = rcDataSet
                .ParaDataView = New DataView(rcDataSet.Tables("bjdlb"), "TRUE", "djh", DataViewRowState.CurrentRows)
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
                rcOleDbCommand.CommandText = "SELECT djh FROM oe_bjd WHERE oe_bjd.bjrq >= ? AND oe_bjd.bjrq <= ? AND SUBSTR(djh,11,5) >= ?  AND SUBSTR(djh,11,5) <= ? AND (" & strExpPzlxdm & ")" & IIf(Me.CmbPzlxjc.SelectedValue <> "0000", " AND SUBSTR(oe_bjd.djh,1, 4) ='" & Me.CmbPzlxjc.SelectedValue & "'", "") & IIf(Trim(TxtCpdm.Text).Length > 0, " and oe_bjd.cpdm = '" & Trim(TxtCpdm.Text) & "'", "") & IIf(Trim(TxtCpmc.Text).Length > 0, " and oe_bjd.cpmc LIKE '%" & TxtCpmc.Text & "%'", "") & IIf(Trim(TxtCpgg.Text).Length > 0, " and oe_bjd.cpgg LIKE '%" & Trim(TxtCpgg.Text) & "%'", "") & IIf(Trim(Me.TxtKhdm.Text).Length > 0, " and oe_bjd.khdm LIKE '" & LTrim(Me.TxtKhdm.Text) & "%'", "") & IIf(Trim(Me.TxtKhmc.Text).Length > 0, " AND oe_bjd.khmc LIKE '%" & Trim(Me.TxtKhmc.Text) & "%'", "") & IIf(Trim(TxtKhlh.Text).Length > 0, " and oe_bjd.khlh LIKE '%" & Trim(TxtKhlh.Text) & "%'", "") & " GROUP BY djh ORDER BY djh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@bjrq1", OleDbType.Date, 8).Value = DtpBjrqBegin.Value.Date
                rcOleDbCommand.Parameters.Add("@bjrq2", OleDbType.Date, 8).Value = DtpBjrqEnd.Value.Date
                rcOleDbCommand.Parameters.Add("@djh1", OleDbType.VarChar, 5).Value = NudDjhBegin.Value.ToString.PadLeft(5, "0")
                rcOleDbCommand.Parameters.Add("@djh2", OleDbType.VarChar, 5).Value = NudDjhEnd.Value.ToString.PadLeft(5, "0")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("djhml") IsNot Nothing Then
                    rcDataSet.Tables("djhml").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "djhml")
            Catch ex As Exception
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("djhml").Rows.Count <= 0 Then
                MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            '调用表单
            Dim rcFrm As New FrmOeBjdCxz
            With rcFrm
                .ParaDataSet = rcDataSet
                .WindowState = FormWindowState.Maximized
                .MdiParent = Me.MdiParent
                .Show()
            End With
        End If
    End Sub

End Class