Imports System.Data.OleDb

Public Class FrmOeDdCx

#Region "定义变量"

    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

#End Region

#Region "初始化事件"

    Private Sub FrmOeDdCx_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '默认值
        Me.DtpBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        Me.DtpEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '取单据类型数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE kjnd = ? AND lxgs = '产品销售订单' ORDER BY pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_lx") IsNot Nothing Then
                Me.rcDataset.Tables("rc_lx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_lx")
        Catch ex As Exception
            MsgBox("程序错误。读取单据类型。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Dim rcDataRow As DataRow
        rcDataRow = rcDataset.Tables("rc_lx").NewRow
        rcDataRow.Item("pzlxdm") = "0000"
        rcDataRow.Item("pzlxjc") = "全部单据"
        rcDataset.Tables("rc_lx").Rows.Add(rcDataRow)
        If rcDataset.Tables("rc_lx").Rows.Count = 0 Then
            MsgBox("请定义单据类型。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        BindDropDownList(CmbPzlxjc, rcDataset.Tables("rc_lx"), "pzlxdm", "pzlxjc")
        CmbPzlxjc.SelectedValue = "0000"
    End Sub

#End Region

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpBegin.KeyPress, DtpEnd.KeyPress, NudDjhBegin.KeyPress, NudDjhEnd.KeyPress, TxtCpdm.KeyPress, TxtCpmc.KeyPress, TxtSczydm.KeyPress, TxtHth.KeyPress, TxtKhdm.KeyPress, TxtZydm.KeyPress, ChbHx.KeyPress, ChbLbfs.KeyPress, ChbWhx.KeyPress, ChbWck.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "产品编码事件"

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
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

#End Region

#Region "产品名称事件"

    Private Sub TxtCpmc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCpmc.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

#End Region

#Region "承接人事件"

    Private Sub TxtSczydm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSczydm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_zyxx"
                    .paraField1 = "zydm"
                    .paraField2 = "zymc"
                    .paraField3 = "zysm"
                    .paraOrderField = "zydm"
                    .paraTitle = "职员"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtSczydm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

#End Region

#Region "订单号事件"

    Private Sub TxtHth_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtHth.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

#End Region

#Region "客户编码事件"

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
                    .paraCondition = "0=0"
                    .paraOrderField = "khmc"
                    .paraTitle = "客户"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtKhdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

#End Region

#Region "业务员事件"

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
                    .paraOrderField = "zydm"
                    .paraTitle = "职员"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtZydm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

#End Region

#Region "未出库事件"

    Private Sub ChbWck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbWck.CheckedChanged
        If Me.ChbWck.Checked Or Me.ChbWhx.Checked Or Me.ChbHx.Checked Or Me.ChbWsk.Checked Then
            Me.DtpBegin.Enabled = False
            Me.DtpEnd.Enabled = False
        Else
            Me.DtpBegin.Enabled = True
            Me.DtpEnd.Enabled = True
        End If
        If Me.ChbWck.Checked Then
            Me.RadioBtnScjhrq.Checked = True
            Me.ChbWhx.Checked = False
            Me.ChbHx.Checked = False
            Me.ChbWsk.Checked = False
        Else
            Me.RadioBtnQdrq.Checked = True
        End If
    End Sub

#End Region

#Region "未核销事件"

    Private Sub ChbWhx_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbWhx.CheckedChanged
        If Me.ChbWck.Checked Or Me.ChbWhx.Checked Or Me.ChbHx.Checked Or Me.ChbWsk.Checked Then
            Me.DtpBegin.Enabled = False
            Me.DtpEnd.Enabled = False
        Else
            Me.DtpBegin.Enabled = True
            Me.DtpEnd.Enabled = True
        End If
        If Me.ChbWhx.Checked Then
            Me.ChbWck.Checked = False
            Me.ChbHx.Checked = False
            Me.ChbWsk.Checked = False
        End If
    End Sub

#End Region

#Region "包含全额冲销事件"

    Private Sub ChbHx_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbHx.CheckedChanged
        If Me.ChbWck.Checked Or Me.ChbWhx.Checked Or Me.ChbHx.Checked Or Me.ChbWsk.Checked Then
            Me.DtpBegin.Enabled = False
            Me.DtpEnd.Enabled = False
        Else
            Me.DtpBegin.Enabled = True
            Me.DtpEnd.Enabled = True
        End If
        If Me.ChbHx.Checked Then
            Me.ChbWck.Checked = False
            Me.ChbWhx.Checked = False
            Me.ChbWsk.Checked = False
        End If
    End Sub

#End Region

#Region "未收款事件"

    Private Sub ChbWsk_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbWsk.CheckedChanged
        If Me.ChbWck.Checked Or Me.ChbWhx.Checked Or Me.ChbHx.Checked Or Me.ChbWsk.Checked Then
            Me.DtpBegin.Enabled = False
            Me.DtpEnd.Enabled = False
        Else
            Me.DtpBegin.Enabled = True
            Me.DtpEnd.Enabled = True
        End If
        If Me.ChbWsk.Checked Then
            Me.ChbWck.Checked = False
            Me.ChbWhx.Checked = False
            Me.ChbHx.Checked = False
        End If
    End Sub

#End Region


#Region "列表方式事件"

    Private Sub ChbLbfs_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbLbfs.CheckedChanged
        If Me.ChbLbfs.Checked Then
            Me.TxtKhmc.Enabled = True
            Me.TxtCpdm.Enabled = True
            Me.TxtSczydm.Enabled = True
            Me.TxtCpmc.Enabled = True
            Me.TxtKhddh.Enabled = True
            Me.TxtKhlh.Enabled = True
        Else
            Me.TxtKhmc.Enabled = False
            Me.TxtCpdm.Enabled = False
            Me.TxtSczydm.Enabled = False
            Me.TxtCpmc.Enabled = False
            Me.TxtKhmc.Text = ""
            Me.TxtCpdm.Text = ""
            Me.TxtSczydm.Text = ""
            Me.TxtCpmc.Text = ""
            Me.TxtKhddh.Enabled = False
            Me.TxtKhddh.Text = ""
            Me.TxtKhlh.Enabled = False
            Me.TxtKhlh.Text = ""
        End If
    End Sub

#End Region

#Region "确定事件"

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        '权限控制
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT code AS lbdm FROM rc_userqx WHERE righttype = 'LBDM' AND User_Account = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = g_User_Account
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_cplb") IsNot Nothing Then
                rcDataset.Tables("rc_cplb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_cplb")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_cplb").Rows.Count > 0 Then
            Me.ChbLbfs.Checked = True
        End If
        Dim strExpLbdm As String = ""
        Dim j As Integer
        If rcDataset.Tables("rc_cplb").Rows.Count = 1 Then
            strExpLbdm = " rc_cpxx.lbdm = '" & Trim(rcDataset.Tables("rc_cplb").Rows(0).Item("lbdm")) & "'"
        Else
            For j = 0 To rcDataset.Tables("rc_cplb").Rows.Count - 1
                strExpLbdm = strExpLbdm & " OR rc_cpxx.lbdm = '" & Trim(rcDataset.Tables("rc_cplb").Rows(j).Item("lbdm")) & "'"
            Next
        End If
        If strExpLbdm.Length = 0 Then
            strExpLbdm = " 0=0"
        End If
        If strExpLbdm.Length > 0 Then
            If strExpLbdm.Substring(0, 3) = " OR" Then
                strExpLbdm = strExpLbdm.Substring(3)
            End If
        End If
        '
        If Me.ChbLbfs.Checked Then
            Try
                ''取数据
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                If Me.RadioBtnQdrq.Checked Then
                    rcOleDbCommand.CommandText = "SELECT oe_dd.djh,oe_dd.xh,oe_dd.qdrq,oe_dd.hth,oe_dd.khdm,oe_dd.khmc,oe_dd.zydm,oe_dd.zymc,oe_dd.ddtk,oe_dd.sktj,oe_dd.skqx,oe_dd.cpdm,oe_dd.cpmc,oe_dd.sl,oe_dd.hxsl,oe_dd.rksl,oe_dd.sl- oe_dd.hxsl - oe_dd.rksl AS wrk,oe_dd.cksl,oe_dd.sl - oe_dd.hxsl - oe_dd.cksl AS wck,ROUND((oe_dd.sl - oe_dd.hxsl - oe_dd.cksl) * oe_dd.hsdj,2) AS wckje,oe_dd.fpsl,oe_dd.sl - oe_dd.hxsl - oe_dd.fpsl AS wfp,oe_dd.dw,oe_dd.mjsl,oe_dd.fzsl,oe_dd.fzdw,oe_dd.dj,oe_dd.hsdj,oe_dd.je,oe_dd.shlv,oe_dd.se,oe_dd.je + oe_dd.se AS jese,rc_cpxx.bzcb,oe_dd.khddh,oe_dd.khlh,oe_dd.khjhrq,oe_dd.zxgg,oe_dd.ddmemo,oe_dd.sdjh,oe_dd.sxh,oe_dd.scjhrq,oe_dd.ckrq,oe_dd.sczydm,oe_dd.sczymc,oe_dd.srr,oe_dd.shr,oe_dd.srr,oe_dd.srrq,oe_dd.shr,oe_dd.shrq,oe_dd.bclosed FROM oe_dd,rc_cpxx WHERE oe_dd.cpdm = rc_cpxx.cpdm AND (" & strExpLbdm & ")" & IIf(Me.CmbPzlxjc.SelectedValue <> "0000", " AND SUBSTR(oe_dd.djh,1, 4) ='" & Me.CmbPzlxjc.SelectedValue & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " and oe_dd.cpdm LIKE '" & Trim(TxtCpdm.Text) & "%'", "") & IIf(TxtZydm.TextLength > 0, " and oe_dd.zydm LIKE '" & TxtZydm.Text & "%'", "") & IIf(TxtHth.TextLength > 0, " and oe_dd.hth LIKE '" & TxtHth.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtKhddh.Text), " and oe_dd.khddh LIKE '%" & Me.TxtKhddh.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtKhlh.Text), " and oe_dd.khlh LIKE '%" & Me.TxtKhlh.Text & "%'", "") & IIf(Trim(TxtKhdm.Text).Length > 0, " and oe_dd.khdm LIKE '" & LTrim(TxtKhdm.Text) & "%'", "") & IIf(Trim(Me.TxtKhmc.Text).Length > 0, " and oe_dd.khmc LIKE '%" & Trim(Me.TxtKhmc.Text) & "%'", "") & IIf(Trim(TxtSczydm.Text).Length > 0, " and oe_dd.sczydm LIKE '" & TxtSczydm.Text & "%'", "") & IIf(Me.ChbHx.Checked, "", " AND oe_dd.sl <> oe_dd.hxsl AND oe_dd.sl > 0") & IIf(Me.ChbWhx.Checked, " AND oe_dd.sl < 0 AND oe_dd.sl <> oe_dd.hxsl", "") & IIf(Me.ChbWck.Checked, " AND oe_dd.bclosed = 0 AND oe_dd.sl - oe_dd.hxsl - oe_dd.cksl <> 0", "") & IIf(Trim(TxtCpmc.Text).Length > 0, " AND oe_dd.cpmc Like '%" & Trim(Me.TxtCpmc.Text) & "%'", "") & IIf(Me.ChbSh.Checked, "", " AND NOT oe_dd.shr IS NULL") & IIf(Me.ChbWsk.Checked, " AND oe_dd.sktj ='款到发货' AND oe_dd.je + oe_dd.se <> oe_dd.skje", "") & IIf(Me.DtpBegin.Enabled, " AND TRUNC(oe_dd.qdrq,'dd') >= ? AND TRUNC(oe_dd.qdrq,'dd') <= ? AND SUBSTR(oe_dd.djh,11,5) >= ? AND SUBSTR(oe_dd.djh,11,5) <= ?", "") & " ORDER BY oe_dd.djh,oe_dd.xh"
                Else
                    rcOleDbCommand.CommandText = "SELECT oe_dd.djh,oe_dd.xh,oe_dd.qdrq,oe_dd.hth,oe_dd.khdm,oe_dd.khmc,oe_dd.zydm,oe_dd.zymc,oe_dd.ddtk,oe_dd.sktj,oe_dd.skqx,oe_dd.cpdm,oe_dd.cpmc,oe_dd.sl,oe_dd.hxsl,oe_dd.rksl,oe_dd.sl- oe_dd.hxsl - oe_dd.rksl AS wrk,oe_dd.cksl,oe_dd.sl - oe_dd.hxsl - oe_dd.cksl AS wck,ROUND((oe_dd.sl - oe_dd.hxsl - oe_dd.cksl) * oe_dd.hsdj,2) AS wckje,oe_dd.fpsl,oe_dd.sl - oe_dd.hxsl - oe_dd.fpsl AS wfp,oe_dd.dw,oe_dd.mjsl,oe_dd.fzsl,oe_dd.fzdw,oe_dd.dj,oe_dd.hsdj,oe_dd.je,oe_dd.shlv,oe_dd.se,oe_dd.je + oe_dd.se AS jese,rc_cpxx.bzcb,oe_dd.khddh,oe_dd.khlh,oe_dd.khjhrq,oe_dd.zxgg,oe_dd.ddmemo,oe_dd.sdjh,oe_dd.sxh,oe_dd.scjhrq,oe_dd.ckrq,oe_dd.sczydm,oe_dd.sczymc,oe_dd.srr,oe_dd.shr,oe_dd.srr,oe_dd.srrq,oe_dd.shr,oe_dd.shrq,oe_dd.bclosed FROM oe_dd,rc_cpxx WHERE oe_dd.cpdm = rc_cpxx.cpdm AND (" & strExpLbdm & ")" & IIf(Me.CmbPzlxjc.SelectedValue <> "0000", " AND SUBSTR(oe_dd.djh,1, 4) ='" & Me.CmbPzlxjc.SelectedValue & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " and oe_dd.cpdm LIKE '" & Trim(TxtCpdm.Text) & "%'", "") & IIf(TxtZydm.TextLength > 0, " and oe_dd.zydm LIKE '" & TxtZydm.Text & "%'", "") & IIf(TxtHth.TextLength > 0, " and oe_dd.hth LIKE '" & TxtHth.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtKhddh.Text), " and oe_dd.khddh LIKE '%" & Me.TxtKhddh.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtKhlh.Text), " and oe_dd.khlh LIKE '%" & Me.TxtKhlh.Text & "%'", "") & IIf(Trim(TxtKhdm.Text).Length > 0, " and oe_dd.khdm LIKE '" & LTrim(TxtKhdm.Text) & "%'", "") & IIf(Trim(Me.TxtKhmc.Text).Length > 0, " and oe_dd.khmc LIKE '%" & Trim(Me.TxtKhmc.Text) & "%'", "") & IIf(Trim(TxtSczydm.Text).Length > 0, " and oe_dd.sczydm LIKE '" & TxtSczydm.Text & "%'", "") & IIf(Me.ChbHx.Checked, "", " AND oe_dd.sl <> oe_dd.hxsl AND oe_dd.sl > 0") & IIf(Me.ChbWhx.Checked, " AND oe_dd.sl < 0 AND oe_dd.sl <> oe_dd.hxsl", "") & IIf(Me.ChbWck.Checked, " AND oe_dd.bclosed = 0 AND oe_dd.sl - oe_dd.hxsl - oe_dd.cksl <> 0", "") & IIf(Me.ChbSh.Checked, "", " AND NOT oe_dd.shr IS NULL") & IIf(Me.ChbWsk.Checked, " AND oe_dd.sktj ='款到发货' AND oe_dd.je + oe_dd.se <> oe_dd.skje", "") & IIf(Trim(TxtCpmc.Text).Length > 0, " AND oe_dd.cpmc Like '%" & Trim(Me.TxtCpmc.Text) & "%'", "") & IIf(Me.DtpBegin.Enabled, " and (oe_dd.scjhrq >= ? AND oe_dd.scjhrq <= ? OR oe_dd.scjhrq IS NULL) AND SUBSTR(oe_dd.djh,11,5) >= ?  AND SUBSTR(oe_dd.djh,11,5) <= ?", "") & " ORDER BY oe_dd.djh,oe_dd.xh"
                End If
                rcOleDbCommand.Parameters.Clear()
                If Me.DtpBegin.Enabled Then
                    rcOleDbCommand.Parameters.Add("@qdrq1", OleDbType.Date, 8).Value = DtpBegin.Value.Date
                    rcOleDbCommand.Parameters.Add("@qdrq2", OleDbType.Date, 8).Value = DtpEnd.Value.Date
                    rcOleDbCommand.Parameters.Add("@djh1", OleDbType.VarChar, 5).Value = NudDjhBegin.Value.ToString.PadLeft(5, "0")
                    rcOleDbCommand.Parameters.Add("@djh2", OleDbType.VarChar, 5).Value = NudDjhEnd.Value.ToString.PadLeft(5, "0")
                End If
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("ddlb") IsNot Nothing Then
                    rcDataset.Tables("ddlb").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "ddlb")
            Catch ex As Exception
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("ddlb").Rows.Count <= 0 Then
                MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            Dim rcDataRow As DataRow
            rcDataRow = rcDataset.Tables("ddlb").NewRow
            rcDataRow.Item("djh") = "合计"
            rcDataRow.Item("sl") = rcDataset.Tables("ddlb").Compute("Sum(sl)", "")
            rcDataRow.Item("fzsl") = rcDataset.Tables("ddlb").Compute("Sum(fzsl)", "")
            rcDataRow.Item("je") = rcDataset.Tables("ddlb").Compute("Sum(je)", "")
            rcDataRow.Item("se") = rcDataset.Tables("ddlb").Compute("Sum(se)", "")
            rcDataRow.Item("jese") = rcDataset.Tables("ddlb").Compute("Sum(jese)", "")
            rcDataRow.Item("hxsl") = rcDataset.Tables("ddlb").Compute("Sum(hxsl)", "")
            rcDataRow.Item("rksl") = rcDataset.Tables("ddlb").Compute("Sum(rksl)", "")
            rcDataRow.Item("wrk") = rcDataset.Tables("ddlb").Compute("Sum(wrk)", "")
            rcDataRow.Item("cksl") = rcDataset.Tables("ddlb").Compute("Sum(cksl)", "")
            rcDataRow.Item("wck") = rcDataset.Tables("ddlb").Compute("Sum(wck)", "")
            rcDataRow.Item("wckje") = rcDataset.Tables("ddlb").Compute("Sum(wckje)", "")
            rcDataRow.Item("fpsl") = rcDataset.Tables("ddlb").Compute("Sum(fpsl)", "")
            rcDataRow.Item("wfp") = rcDataset.Tables("ddlb").Compute("Sum(wfp)", "")
            rcDataset.Tables("ddlb").Rows.Add(rcDataRow)
            '调用表单
            Dim rcFrm As New FrmOeDdCxLb
            With rcFrm
                .ParaDataSet = rcDataset
                .ParaDataView = New DataView(rcDataset.Tables("ddlb"), "TRUE", "djh,xh", DataViewRowState.CurrentRows)
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
                rcOleDbCommand.CommandText = "SELECT djh FROM oe_dd WHERE TRUNC(oe_dd.qdrq,'dd') >= ? AND TRUNC(oe_dd.qdrq,'dd') <= ?" & IIf(Me.CmbPzlxjc.SelectedValue <> "0000", " AND SUBSTR(oe_dd.djh,1, 4) ='" & Me.CmbPzlxjc.SelectedValue & "'", "") & " AND SUBSTR(djh,11,5) >= ?  AND SUBSTR(djh,11,5) <= ?" & IIf(Me.TxtZydm.TextLength > 0, " and oe_dd.zydm = '" & TxtZydm.Text & "'", "") & IIf(Trim(TxtKhdm.Text).Length > 0, " and oe_dd.khdm LIKE '" & LTrim(TxtKhdm.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtHth.Text), " and oe_dd.hth LIKE '" & LTrim(Me.TxtHth.Text) & "%'", "") & " GROUP BY oe_dd.djh ORDER BY oe_dd.djh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@qdrq1", OleDbType.Date, 8).Value = DtpBegin.Value.Date
                rcOleDbCommand.Parameters.Add("@qdrq2", OleDbType.Date, 8).Value = DtpEnd.Value.Date
                rcOleDbCommand.Parameters.Add("@djh1", OleDbType.VarChar, 5).Value = NudDjhBegin.Value.ToString.PadLeft(5, "0")
                rcOleDbCommand.Parameters.Add("@djh2", OleDbType.VarChar, 5).Value = NudDjhEnd.Value.ToString.PadLeft(5, "0")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("ddml") IsNot Nothing Then
                    rcDataset.Tables("ddml").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "ddml")
            Catch ex As Exception
                MsgBox("程序错误asd。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("ddml").Rows.Count <= 0 Then
                MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            '调用表单
            Dim rcFrm As New FrmOeDdCxz
            With rcFrm
                .ParaDataSet = rcDataset
                .WindowState = FormWindowState.Maximized
                .MdiParent = Me.MdiParent
                .Show()
            End With
        End If
    End Sub

#End Region
End Class