Imports System.Data.OleDb
Public Class FrmOeYpddDjb

#Region "定义变量"

    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '数据更新传递
    Dim rcOleDbTrans As OleDbTransaction
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

#End Region

#Region "初始化"

    Private Sub FrmOeYpddDjb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        DtpQdrqBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpQdrqEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
    End Sub

#End Region

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpQdrqBegin.KeyPress, DtpQdrqEnd.KeyPress, NudDjhBegin.KeyPress, NudDjhEnd.KeyPress, TxtCpdm.KeyPress, TxtCpmc.KeyPress, TxtCpgg.KeyPress, TxtCpmemo.KeyPress, TxtBmdm.KeyPress, TxtHth.KeyPress, TxtKhdm.KeyPress, TxtKhlh.KeyPress, TxtKhcz.KeyPress, TxtZydm.KeyPress
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
                Dim rcFrm As New models.FrmF36
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_cpxx"
                    .paraField1 = "cpdm"
                    .paraField2 = "cpmc"
                    .paraField3 = "cpgg"
                    .paraField4 = "cpmemo"
                    .paraField5 = "cpsm"
                    .paraField6 = "dw"
                    .paraOrderField = "cpmc"
                    .paraTitle = "产品"
                    .paraOldValue = TxtCpdm.Text
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtCpdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
            Case Keys.Up
                SendKeys.Send("+{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "产品名称事件"

    Private Sub TxtCpmc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCpmc.KeyDown, TxtCpgg.KeyDown, TxtCpmemo.KeyDown, TxtHth.KeyDown, TxtKhlh.KeyDown, TxtKhcz.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
            Case Keys.Up
                SendKeys.Send("+{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "部门编码事件"

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
                    .paraOrderField = "bmdm"
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
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
            Case Keys.Up
                SendKeys.Send("+{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "内销业务员事件"

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
                        TxtZydm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
            Case Keys.Up
                SendKeys.Send("+{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "确定事件"

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        '权限控制
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "select code as bmdm from rc_userqx where righttype = 'BMDM' and User_Account = ?" & IIf(Trim(TxtBmdm.Text).Length > 0, " and code ='" & Trim(TxtBmdm.Text) & "'", "")
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = g_User_Account
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_bmxx") IsNot Nothing Then
                rcDataset.Tables("rc_bmxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_bmxx")
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_bmxx").Rows.Count <= 0 Then
            MsgBox("你无权查看该报表。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Return
        End If
        Dim strExpBmdm As String = " 部门编码 = ''"
        Dim j As Integer
        If rcDataset.Tables("rc_bmxx").Rows.Count = 1 Then
            TxtBmdm.Text = Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmdm"))
            strExpBmdm = strExpBmdm & " OR 部门编码 = '" & Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmdm")) & "'"
        Else
            For j = 0 To rcDataset.Tables("rc_bmxx").Rows.Count - 1
                strExpBmdm = strExpBmdm & " OR 部门编码 = '" & Trim(rcDataset.Tables("rc_bmxx").Rows(j).Item("bmdm")) & "'"
            Next
        End If
        If strExpBmdm.Length = 0 Then
            strExpBmdm = " 0=0"
        End If
        If strExpBmdm.Length > 0 Then
            If strExpBmdm.Substring(0, 3) = " OR" Then
                strExpBmdm = strExpBmdm.Substring(3)
            End If
        End If
        If Me.ChbLbfs.Checked Then
            '取数据
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                If Me.RadioBtnQdrq.Checked Then
                    rcOleDbCommand.CommandText = "Select 发货日期,客户名称,送货单号,产品名称,订单数量,重量,'' AS 目的地城市,'" & g_User_DspName & "' AS 寄件人签名,'' AS 邮寄重量,'' AS 邮寄费用,'' AS 超额审批单,'' AS 邮寄专员签名 From view_oe_ypdd Where 签单日期 >= ? And 签单日期 <= ?" & IIf(Trim(TxtCpdm.Text).Length > 0, " and 产品编码 LIKE '" & Trim(TxtCpdm.Text) & "%'", "") & IIf(TxtKhlh.TextLength > 0, " and 客户料号 LIKE '" & Trim(TxtKhlh.Text) & "%'", "") & IIf(TxtKhcz.TextLength > 0, " and 客户材质 LIKE '" & Trim(TxtKhcz.Text) & "%'", "") & IIf(TxtZydm.TextLength > 0, " and 内销职员编码 LIKE '" & TxtZydm.Text & "%'", "") & IIf(TxtHth.TextLength > 0, " and 合同编码 LIKE '" & TxtHth.Text & "%'", "") & IIf(Trim(TxtKhdm.Text).Length > 0, " and 客户编码 LIKE '" & LTrim(TxtKhdm.Text) & "%'", "") & IIf(Trim(TxtBmdm.Text).Length > 0, " and 部门编码 LIKE '" & TxtBmdm.Text & "%'", "") & IIf(Me.ChbHx.Checked, "", " AND 订单数量 <> 核销数量") & IIf(Me.ChbShdh.Checked, " AND 送货单号 <> ''", "") & IIf(Trim(TxtCpmc.Text).Length > 0, " AND 产品名称 LIKE '" & TxtCpmc.Text & "%'", "") & IIf(Trim(TxtCpgg.Text).Length > 0, " and 型号规格 LIKE '" & Trim(TxtCpgg.Text) & "%'", "") & IIf(Trim(Me.TxtCpmemo.Text).Length > 0, " and 产品属性 LIKE '" & Trim(Me.TxtCpmemo.Text) & "%'", "") & " AND SUBSTR(单据号,11,5) >= ?  AND SUBSTR(单据号,11,5) <= ? AND (" & strExpBmdm & ")"
                Else
                    If Me.RadioBtnScjhrq.Checked Then
                        rcOleDbCommand.CommandText = "Select 发货日期,客户名称,送货单号,产品名称,订单数量,重量,'' AS 目的地城市,'" & g_User_DspName & "' AS 寄件人签名,'' AS 邮寄重量,'' AS 邮寄费用,'' AS 超额审批单,'' AS 邮寄专员签名 From view_oe_ypdd Where 生产交期 >= ? AND 生产交期 <= ?" & IIf(Trim(TxtCpdm.Text).Length > 0, " and 产品编码 LIKE '" & Trim(TxtCpdm.Text) & "%'", "") & IIf(TxtKhlh.TextLength > 0, " and 客户料号 LIKE '" & Trim(TxtKhlh.Text) & "%'", "") & IIf(TxtKhcz.TextLength > 0, " and 客户材质 LIKE '" & Trim(TxtKhcz.Text) & "%'", "") & IIf(TxtZydm.TextLength > 0, " and 内销职员编码 LIKE '" & TxtZydm.Text & "%'", "") & IIf(TxtHth.TextLength > 0, " and 合同编码 LIKE '" & TxtHth.Text & "%'", "") & IIf(Trim(TxtKhdm.Text).Length > 0, " and 客户编码 LIKE '" & LTrim(TxtKhdm.Text) & "%'", "") & IIf(Trim(TxtBmdm.Text).Length > 0, " and 部门编码 LIKE '" & TxtBmdm.Text & "%'", "") & IIf(Me.ChbHx.Checked, "", " AND 订单数量 <> 核销数量") & IIf(Me.ChbShdh.Checked, " AND 送货单号 <> ''", "") & IIf(Trim(TxtCpmc.Text).Length > 0, " AND 产品名称 LIKE '" & TxtCpmc.Text & "%'", "") & IIf(Trim(TxtCpgg.Text).Length > 0, " and 型号规格 LIKE '" & Trim(TxtCpgg.Text) & "%'", "") & IIf(Trim(Me.TxtCpmemo.Text).Length > 0, " and 产品属性 LIKE '" & Trim(Me.TxtCpmemo.Text) & "%'", "") & " AND SUBSTR(单据号,11,5) >= ?  AND SUBSTR(单据号,11,5) <= ? AND (" & strExpBmdm & ")"
                    Else
                        rcOleDbCommand.CommandText = "Select 发货日期,客户名称,送货单号,产品名称,订单数量,重量,'' AS 目的地城市,'" & g_User_DspName & "' AS 寄件人签名,'' AS 邮寄重量,'' AS 邮寄费用,'' AS 超额审批单,'' AS 邮寄专员签名 From view_oe_ypdd Where 发货日期 >= ? AND 发货日期 <= ?" & IIf(Trim(TxtCpdm.Text).Length > 0, " and 产品编码 LIKE '" & Trim(TxtCpdm.Text) & "%'", "") & IIf(TxtKhlh.TextLength > 0, " and 客户料号 LIKE '" & Trim(TxtKhlh.Text) & "%'", "") & IIf(TxtKhcz.TextLength > 0, " and 客户材质 LIKE '" & Trim(TxtKhcz.Text) & "%'", "") & IIf(TxtZydm.TextLength > 0, " and 内销职员编码 LIKE '" & TxtZydm.Text & "%'", "") & IIf(TxtHth.TextLength > 0, " and 合同编码 LIKE '" & TxtHth.Text & "%'", "") & IIf(Trim(TxtKhdm.Text).Length > 0, " and 客户编码 LIKE '" & LTrim(TxtKhdm.Text) & "%'", "") & IIf(Trim(TxtBmdm.Text).Length > 0, " and 部门编码 LIKE '" & TxtBmdm.Text & "%'", "") & IIf(Me.ChbHx.Checked, "", " AND 订单数量 <> 核销数量") & IIf(Me.ChbShdh.Checked, " AND 送货单号 <> ''", "") & IIf(Trim(TxtCpmc.Text).Length > 0, " AND 产品名称 LIKE '" & TxtCpmc.Text & "%'", "") & IIf(Trim(TxtCpgg.Text).Length > 0, " and 型号规格 LIKE '" & Trim(TxtCpgg.Text) & "%'", "") & IIf(Trim(Me.TxtCpmemo.Text).Length > 0, " and 产品属性 LIKE '" & Trim(Me.TxtCpmemo.Text) & "%'", "") & " AND SUBSTR(单据号,11,5) >= ?  AND SUBSTR(单据号,11,5) <= ? AND (" & strExpBmdm & ")"
                    End If
                End If
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@qdrq1", OleDbType.Date, 8).Value = DtpQdrqBegin.Value.Date
                rcOleDbCommand.Parameters.Add("@qdrq2", OleDbType.Date, 8).Value = DtpQdrqEnd.Value.Date
                rcOleDbCommand.Parameters.Add("@djh1", OleDbType.VarChar, 5).Value = NudDjhBegin.Value.ToString.PadLeft(5, "0")
                rcOleDbCommand.Parameters.Add("@djh2", OleDbType.VarChar, 5).Value = NudDjhEnd.Value.ToString.PadLeft(5, "0")
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
            '调用表单
            Dim rcFrm As New FrmOeYpddCxLb
            With rcFrm
                .ParaDataSet = rcDataset
                .ParaDataView = New DataView(rcDataset.Tables("ddlb"), "TRUE", "发货日期,送货单号", DataViewRowState.CurrentRows)
                .WindowState = FormWindowState.Maximized
                .MdiParent = Me.MdiParent
                .Show()
            End With
        End If
    End Sub

#End Region
End Class