Imports System.Data.OleDb

Public Class FrmZcclMx
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '按成本域
    Dim bCostRegion As Boolean = False

    Private Sub FrmZcclMx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        Me.NudYear.Value = Mid(g_Kjqj, 1, 4)
        Me.NudMonth.Value = Mid(g_Kjqj, 5, 2)
        '是否按成本域计算成本
        bCostRegion = GetParaValue("是否按成本域计算成本", False)
        If bCostRegion Then
            Me.LblBmdm.Text = "成本域编码："
        Else
            Me.LblBmdm.Text = "部门编码："
        End If
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
                        .ParaOleDbConn = rcOleDbConn
                        .ParaTableName = "rc_costregion"
                        .ParaField1 = "crdm"
                        .ParaField2 = "crmc"
                        .ParaField3 = "crsm"
                        .ParaTitle = "成本域"
                        .ParaOldValue = ""
                        .ParaAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            TxtBmdm.Text = Trim(.ParaField1)
                        End If
                    End With
                Else
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
                    Me.TxtBmdm.Text = Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmdm"))
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
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            If bCostRegion Then
                rcOleDbCommand.CommandText = "SELECT pm_zccl.bmdm,rc_costregion.crmc AS bmmc,pm_zccl.cpdm,rc_cpxx.cpmc,rc_cpxx.dw,pm_zccl.gxdm,rc_gxxx.gxmc,pm_zccl.zcclsl,pm_zccl.cldj,pm_zccl.zcclje FROM pm_zccl LEFT JOIN rc_cpxx ON pm_zccl.cpdm = rc_cpxx.cpdm LEFT JOIN rc_gxxx ON pm_zccl.gxdm = rc_gxxx.gxdm LEFT JOIN rc_costregion ON rc_costregion.crdm = pm_zccl.bmdm WHERE cperiod = ?" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND pm_zccl.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " ORDER BY pm_zccl.bmdm,pm_zccl.cpdm,pm_zccl.gxdm"
            Else
                rcOleDbCommand.CommandText = "SELECT pm_zccl.bmdm,rc_bmxx.bmmc,pm_zccl.cpdm,rc_cpxx.cpmc,rc_cpxx.dw,pm_zccl.gxdm,rc_gxxx.gxmc,pm_zccl.zcclsl,pm_zccl.cldj,pm_zccl.zcclje FROM pm_zccl LEFT JOIN rc_cpxx ON pm_zccl.cpdm = rc_cpxx.cpdm LEFT JOIN rc_gxxx ON pm_zccl.gxdm = rc_gxxx.gxdm LEFT JOIN rc_bmxx ON rc_bmxx.bmdm = pm_zccl.bmdm WHERE cperiod = ?" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND pm_zccl.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " ORDER BY pm_zccl.bmdm,pm_zccl.cpdm,pm_zccl.gxdm"
            End If
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString.PadLeft(4, "0") & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("pm_zccl") IsNot Nothing Then
                Me.rcDataset.Tables("pm_zccl").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "pm_zccl")
        Catch ex As Exception
            MsgBox("执行程序时发生了错误。" & Chr(13) & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("pm_zccl").Rows.Count > 0 Then
            Dim rcDataRow As DataRow
            rcDataRow = rcDataset.Tables("pm_zccl").NewRow
            rcDataRow.Item("bmdm") = "合计"
            rcDataRow.Item("zcclsl") = rcDataset.Tables("pm_zccl").Compute("Sum(zcclsl)", "")
            rcDataRow.Item("zcclje") = rcDataset.Tables("pm_zccl").Compute("Sum(zcclje)", "")
            rcDataset.Tables("pm_zccl").Rows.Add(rcDataRow)

        End If
        '调用表单
        Dim rcFrm As New FrmZcclMxz
        With rcFrm
            '.ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("pm_zccl"), "TRUE", "bmdm,cpdm,gxdm", DataViewRowState.CurrentRows)
            .Label2.Text = "日期：" & Me.NudYear.Value & "年" & Me.NudMonth.Value & "月"
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With

    End Sub

End Class