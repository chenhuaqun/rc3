Imports System.Data.OleDb

Public Class FrmZcpBmGxHz
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Private Sub FrmZcpBmGxHz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
                MsgBox("部门编码不存在，请按F3键选择。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pm_zcpa.bmdm,rc_bmxx.bmmc,pm_zcpa.gxdm,rc_gxxx.gxmc,pm_zcpa.zcpsl,pm_zcpa.zcpzl,pm_zcpa.zcpje FROM (SELECT pm_zcp.bmdm,pm_zcp.gxdm,SUM(pm_zcp.zcpsl) AS zcpsl,SUM(pm_zcp.zcpsl * rc_cpxx.cpweight)/1000 AS zcpzl,SUM(pm_zcp.zcpje) AS zcpje FROM pm_zcp,rc_cpxx WHERE cperiod = ? AND pm_zcp.cpdm = rc_cpxx.cpdm" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND pm_zcp.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " GROUP BY pm_zcp.bmdm,pm_zcp.gxdm) pm_zcpa LEFT JOIN rc_gxxx ON pm_zcpa.gxdm = rc_gxxx.gxdm LEFT JOIN rc_bmxx ON rc_bmxx.bmdm = pm_zcpa.bmdm ORDER BY pm_zcpa.bmdm,pm_zcpa.gxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString.PadLeft(4, "0") & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("pm_zcp") IsNot Nothing Then
                Me.rcDataset.Tables("pm_zcp").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "pm_zcp")
        Catch ex As Exception
            MsgBox("执行程序时发生了错误。" & Chr(13) & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("pm_zcp").Rows.Count > 0 Then
            Dim rcDataRow As DataRow
            rcDataRow = rcDataset.Tables("pm_zcp").NewRow
            rcDataRow.Item("bmdm") = "合计"
            rcDataRow.Item("zcpsl") = rcDataset.Tables("pm_zcp").Compute("Sum(zcpsl)", "")
            rcDataRow.Item("zcpzl") = rcDataset.Tables("pm_zcp").Compute("Sum(zcpzl)", "")
            rcDataRow.Item("zcpje") = rcDataset.Tables("pm_zcp").Compute("Sum(zcpje)", "")
            rcDataset.Tables("pm_zcp").Rows.Add(rcDataRow)

        End If
        '调用表单
        Dim rcFrm As New FrmZcpBmGxHzz
        With rcFrm
            '.ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("pm_zcp"), "TRUE", "bmdm,gxdm", DataViewRowState.CurrentRows)
            .Label2.Text = "日期：" & Me.NudYear.Value & "年" & Me.NudMonth.Value & "月"
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With

    End Sub

End Class