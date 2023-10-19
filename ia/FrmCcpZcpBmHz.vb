Imports System.Data.OleDb

Public Class FrmCcpZcpBmHz
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '按成本域
    Dim bCostRegion As Boolean = False

    Private Sub FrmCcpZcpBmHz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '是否按成本域计算成本
        bCostRegion = GetParaValue("是否按成本域计算成本", False)
        If bCostRegion Then
            Me.LblBmdm.Text = "成本域编码："
        Else
            Me.LblBmdm.Text = "部门编码："
        End If
        '默认值
        Me.NudYear.Value = Mid(g_Kjqj, 1, 4)
        Me.NudMonth.Value = Mid(g_Kjqj, 5, 2)
    End Sub

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NudYear.KeyPress, NudYear.KeyPress, TxtBmdm.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "部门编码的事件"

    Private Sub TxtBmdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBmdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                If bCostRegion Then
                    Dim rcFrm As New models.FrmF3KeyPress
                    With rcFrm
                        .paraOleDbConn = rcOleDbConn
                        .paraTableName = "rc_costregion"
                        .paraField1 = "crdm"
                        .paraField2 = "crmc"
                        .paraField3 = "crsm"
                        .paraTitle = "成本域"
                        .paraOldValue = ""
                        .paraAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            TxtBmdm.Text = Trim(.paraField1)
                        End If
                    End With
                Else
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
                End If
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtBmdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtBmdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtBmdm.Text) Then
            If bCostRegion Then
                Try
                    rcOleDbConn.Open()
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    rcOleDbCommand.CommandText = "SELECT crdm,crmc FROM rc_costregion WHERE (crdm = ?)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@crdm", OleDbType.VarChar, 12).Value = Trim(TxtBmdm.Text)
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("rc_costregion") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_costregion").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "rc_costregion")
                Catch ex As Exception
                    MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                    Return
                Finally
                    rcOleDbConn.Close()
                End Try
                If rcDataset.Tables("rc_costregion").Rows.Count > 0 Then
                    TxtBmdm.Text = Trim(rcDataset.Tables("rc_costregion").Rows(0).Item("crdm"))
                    'LblBmmc.Text = Trim(rcDataset.Tables("rc_costregion").Rows(0).Item("crmc"))
                Else
                    MsgBox("成本域编码不存在，请按F3键选择。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                    e.Cancel = True
                End If
            Else
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
                    'LblBmmc.Text = Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmmc"))
                Else
                    MsgBox("部门编码不存在，请按F3键选择。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                    e.Cancel = True
                End If
                '检测是否最明细记录
                Try
                    rcOleDbConn.Open()
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    rcOleDbCommand.CommandText = "SELECT COUNT(*) AS gs FROM rc_bmxx WHERE (parentid = ?)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtBmdm.Text)
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("reccnt") IsNot Nothing Then
                        Me.rcDataset.Tables("reccnt").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "reccnt")
                Catch ex As Exception
                    MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                    Return
                Finally
                    rcOleDbConn.Close()
                End Try
                If rcDataset.Tables("reccnt").Rows(0).Item("gs") > 0 Then
                    MsgBox("请输入最明细部门编码。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim dateKsrq As Date '成本结转开始日期
        Dim dateJsrq As Date '成本结转结束日期
        dateKsrq = getInvBegin(Me.NudYear.Value, Me.NudMonth.Value)
        dateJsrq = getInvEnd(Me.NudYear.Value, Me.NudMonth.Value)
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT ccpzcphzb.bmdm,ccpzcphzb.bmmc,SUM(ccpzcphzb.qczcpsl*ccpzcphzb.cpweight) AS qczcpsl,SUM(ccpzcphzb.qczcpje) AS qczcpje,SUM(ccpzcphzb.zcbje) AS zcbje,SUM(ccpzcphzb.ccpsl * ccpzcphzb.cpweight) AS ccpsl,SUM(ccpje) AS ccpje,SUM(ccpzcphzb.qmzcpsl*ccpzcphzb.cpweight) AS qmzcpsl,SUM(ccpzcphzb.qmzcpje) AS qmzcpje" & _
                " FROM (SELECT ccpzcphza.bmdm,rc_bmxx.bmmc,ccpzcphza.cpdm,rc_cpxx.cpmc,rc_cpxx.dw,rc_cpxx.cpweight,rc_cpxx.bzcb,ccpzcphza.qczcpsl,ccpzcphza.qczcpje,(ccpzcphza.qmzcpje+ccpzcphza.ccpje - ccpzcphza.qczcpje) AS zcbje,ccpzcphza.ccpsl,ccpzcphza.ccpje,ccpzcphza.qmzcpsl,ccpzcphza.qmzcpje FROM (SELECT CASE WHEN NOT pm_zcpc.bmdm IS NULL THEN pm_zcpc.bmdm ELSE inv_rkda.bmdm END AS bmdm,CASE WHEN NOT pm_zcpc.cpdm IS NULL THEN pm_zcpc.cpdm ELSE inv_rkda.cpdm END AS cpdm,COALESCE(pm_zcpc.qczcpsl,0.0) AS qczcpsl,COALESCE(pm_zcpc.qczcpje,0.0) AS qczcpje,0.0 AS zcbje,COALESCE(inv_rkda.ccpsl,0.0) AS ccpsl,COALESCE(inv_rkda.ccpje,0.0) AS ccpje,COALESCE(pm_zcpc.qmzcpsl,0.0) AS qmzcpsl,COALESCE(pm_zcpc.qmzcpje,0.0) AS qmzcpje FROM " & _
                "(SELECT CASE WHEN NOT pm_zcpa.bmdm IS NULL THEN pm_zcpa.bmdm ELSE pm_zcpb.bmdm END AS bmdm,CASE WHEN NOT pm_zcpa.cpdm IS NULL THEN pm_zcpa.cpdm ELSE pm_zcpb.cpdm END AS cpdm,pm_zcpa.qczcpsl,pm_zcpa.qczcpje,pm_zcpb.qmzcpsl,pm_zcpb.qmzcpje FROM " & _
                "(SELECT pm_zcp.bmdm,pm_zcp.cpdm,SUM(pm_zcp.zcpsl) AS qczcpsl,SUM(pm_zcp.zcpje) AS qczcpje FROM pm_zcp WHERE cperiod = ?" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND pm_zcp.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " GROUP BY pm_zcp.bmdm,pm_zcp.cpdm) pm_zcpa FULL JOIN (SELECT pm_zcp.bmdm,pm_zcp.cpdm,SUM(pm_zcp.zcpsl) AS qmzcpsl,SUM(pm_zcp.zcpje) AS qmzcpje FROM pm_zcp WHERE cperiod = ?" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND pm_zcp.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " GROUP BY pm_zcp.bmdm,pm_zcp.cpdm) pm_zcpb ON pm_zcpa.bmdm = pm_zcpb.bmdm AND pm_zcpa.cpdm = pm_zcpb.cpdm) pm_zcpc" & _
                " FULL JOIN (SELECT inv_rkd.bmdm,inv_rkd.cpdm,SUM(sl) AS ccpsl,SUM(je) AS ccpje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND EXISTS (SELECT 1 FROM rc_lx WHERE SUBSTR(inv_rkd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(inv_rkd.djh,5,4) = rc_lx.kjnd AND lxgs = '产品入库单') AND inv_rkd.rkrq <= ? AND inv_rkd.rkrq >= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND inv_rkd.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " GROUP BY inv_rkd.bmdm,inv_rkd.cpdm) inv_rkda ON pm_zcpc.bmdm = inv_rkda.bmdm AND pm_zcpc.cpdm = inv_rkda.cpdm) ccpzcphza LEFT JOIN rc_bmxx ON rc_bmxx.bmdm = ccpzcphza.bmdm LEFT JOIN rc_cpxx ON rc_cpxx.cpdm = ccpzcphza.cpdm) ccpzcphzb GROUP BY ccpzcphzb.bmdm,ccpzcphzb.bmmc"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = IIf(Me.NudMonth.Value = 1, (Me.NudYear.Value - 1).ToString.PadLeft(4, "0") & "12", Me.NudYear.Value.ToString.PadLeft(4, "0") & (Me.NudMonth.Value - 1).ToString.PadLeft(2, "0"))
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString.PadLeft(4, "0") & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("ccpzcphz") IsNot Nothing Then
                Me.rcDataset.Tables("ccpzcphz").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "ccpzcphz")
        Catch ex As Exception
            MsgBox("执行程序时发生了错误。" & Chr(13) & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("ccpzcphz").Rows.Count > 0 Then
            Dim rcDataRow As DataRow
            rcDataRow = rcDataset.Tables("ccpzcphz").NewRow
            rcDataRow.Item("bmdm") = "合计"
            rcDataRow.Item("qczcpsl") = rcDataset.Tables("ccpzcphz").Compute("Sum(qczcpsl)", "")
            rcDataRow.Item("qczcpje") = rcDataset.Tables("ccpzcphz").Compute("Sum(qczcpje)", "")
            rcDataRow.Item("zcbje") = rcDataset.Tables("ccpzcphz").Compute("Sum(zcbje)", "")
            rcDataRow.Item("ccpsl") = rcDataset.Tables("ccpzcphz").Compute("Sum(ccpsl)", "")
            rcDataRow.Item("ccpje") = rcDataset.Tables("ccpzcphz").Compute("Sum(ccpje)", "")
            rcDataRow.Item("qmzcpsl") = rcDataset.Tables("ccpzcphz").Compute("Sum(qmzcpsl)", "")
            rcDataRow.Item("qmzcpje") = rcDataset.Tables("ccpzcphz").Compute("Sum(qmzcpje)", "")
            rcDataset.Tables("ccpzcphz").Rows.Add(rcDataRow)

        End If
        '调用表单
        Dim rcFrm As New FrmCcpZcpBmHzz
        With rcFrm
            '.ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("ccpzcphz"), "TRUE", "bmdm", DataViewRowState.CurrentRows)
            .Label2.Text = "日期：" & Me.NudYear.Value & "年" & Me.NudMonth.Value & "月"
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With

    End Sub

End Class