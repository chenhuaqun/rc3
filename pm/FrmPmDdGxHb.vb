Imports System.Data.OleDb

Public Class FrmPmDdGxHb

    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As New OleDbCommand

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBmdm.KeyPress
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
                        Me.TxtBmdm.Text = Trim(.paraField1)
                        Me.LblBmmc.Text = Trim(.paraField2)
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
                LblBmmc.Text = Trim(rcDataSet.Tables("rc_bmxx").Rows(0).Item("bmmc"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "确定事件"

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If String.IsNullOrEmpty(Me.TxtBmdm.Text) Then
            MsgBox("请输入部门编码。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Return
        End If
        ''权限控制
        'Try
        '    rcOleDbConn.Open()
        '    rcOleDbCommand.Connection = rcOleDbConn
        '    rcOleDbCommand.CommandTimeout = 300
        '    rcOleDbCommand.CommandType = CommandType.Text
        '    rcOleDbCommand.CommandText = "SELECT code AS bmdm from rc_userqx WHERE righttype = 'BMDM' AND User_Account = ?" & IIf(Trim(Me.TxtBmdm.Text).Length > 0, " AND code ='" & Trim(Me.TxtBmdm.Text) & "'", "")
        '    rcOleDbCommand.Parameters.Clear()
        '    rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = g_User_Account
        '    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
        '    If Not rcDataSet.Tables("rc_bmxx") Is Nothing Then
        '        rcDataSet.Tables("rc_bmxx").Clear()
        '    End If
        '    rcOleDbDataAdpt.Fill(rcDataSet, "rc_bmxx")
        'Catch ex As Exception
        '    MsgBox("程序错误2。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        '    Return
        'Finally
        '    rcOleDbConn.Close()
        'End Try
        'If rcDataSet.Tables("rc_bmxx").Rows.Count <= 0 Then
        '    MsgBox("你无权查看该报表。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
        '    Return
        'End If
        'Dim strExpBmdm As String = ""
        'Dim j As Integer
        'If rcDataSet.Tables("rc_bmxx").Rows.Count = 1 Then
        '    Me.TxtBmdm.Text = Trim(rcDataSet.Tables("rc_bmxx").Rows(0).Item("bmdm"))
        '    strExpBmdm = " rc_cpxx.bmdm = '" & Trim(rcDataSet.Tables("rc_bmxx").Rows(0).Item("bmdm")) & "'"
        'Else
        '    For j = 0 To rcDataSet.Tables("rc_bmxx").Rows.Count - 1
        '        strExpBmdm = strExpBmdm & " OR rc_cpxx.bmdm = '" & Trim(rcDataSet.Tables("rc_bmxx").Rows(j).Item("bmdm")) & "'"
        '    Next
        'End If
        'If strExpBmdm.Length = 0 Then
        '    strExpBmdm = " 0=0"
        'End If
        'If strExpBmdm.Length > 0 Then
        '    If strExpBmdm.Substring(0, 3) = " OR" Then
        '        strExpBmdm = strExpBmdm.Substring(3)
        '    End If
        'End If

        '取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            'rcOleDbCommand.CommandText = "SELECT  0 as xz,oe_dd.djh,oe_dd.xh,oe_dd.qdrq,oe_dd.khdm,oe_dd.khmc,oe_dd.ddtk,oe_dd.cpdm,oe_dd.cpmc,oe_dd.dw,oe_dd.sl,oe_dd.dj,oe_dd.khjhrq,oe_dd.zxgg,oe_dd.scjhrq,oe_dd.sczydm,oe_dd.sczymc,0.0 AS kcsl FROM oe_dd,rc_cpxx WHERE oe_dd.cpdm = rc_cpxx.cpdm AND NOT oe_dd.shr IS NULL AND bmdm = ? ORDER BY oe_dd.djh,oe_dd.xh" ' AND (" & strExpBmdm & ")" & "
            rcOleDbCommand.CommandText = "SELECT 0 AS xz,pm_gxlz.dddjh,pm_gxlz.ddxh,pm_gxlz.hth,pm_gxlz.cpdm,pm_gxlz.cpmc,pm_gxlz.dw,pm_gxlz.sl,pm_gxlz.xh,pm_gxlz.gxdm,pm_gxlz.gxmc,pm_gxlz.scjhrq,pm_gxlz.sczydm,pm_gxlz.sczymc,pm_gxlz.dddjh,pm_gxlz.ddxh FROM pm_gxlz,oe_dd WHERE pm_gxlz.dddjh = oe_dd.djh AND pm_gxlz.ddxh = oe_dd.xh AND pm_gxlz.xh = oe_dd.curxh AND NOT pm_gxlz.scjhrq IS NULL AND bmdm = ? AND bwg <> 1 ORDER BY pm_gxlz.dddjh,pm_gxlz.ddxh" ' AND (" & strExpBmdm & ")" & "
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtBmdm.Text)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_ddnr") IsNot Nothing Then
                rcDataSet.Tables("rc_ddnr").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_ddnr")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("rc_ddnr").Rows.Count <= 0 Then
            MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        'For j = 0 To rcDataSet.Tables("rc_ddnr").Rows.Count - 1
        '    '取数据
        '    Try
        '        rcOleDbConn.Open()
        '        rcOleDbCommand.Connection = rcOleDbConn
        '        rcOleDbCommand.CommandTimeout = 300
        '        rcOleDbCommand.CommandType = CommandType.Text
        '        rcOleDbCommand.CommandText = "SELECT qcsl + idsl AS kcsl FROM inv_cpyeb WHERE kjnd = ? AND cpdm = ?"
        '        rcOleDbCommand.Parameters.Clear()
        '        rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
        '        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataSet.Tables("rc_ddnr").Rows(j).Item("cpdm")
        '        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
        '        If Not rcDataSet.Tables("inv_cpyeb") Is Nothing Then
        '            rcDataSet.Tables("inv_cpyeb").Clear()
        '        End If
        '        rcOleDbDataAdpt.Fill(rcDataSet, "inv_cpyeb")
        '        If rcDataSet.Tables("inv_cpyeb").Rows.Count > 0 Then
        '            If rcDataSet.Tables("inv_cpyeb").Rows(0).Item("kcsl").GetType.ToString <> "System.DBNull" Then
        '                rcDataSet.Tables("rc_ddnr").Rows(j).Item("kcsl") = rcDataSet.Tables("inv_cpyeb").Rows(0).Item("kcsl")
        '            End If
        '        End If
        '    Catch ex As Exception
        '        MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        '        Return
        '    Finally
        '        rcOleDbConn.Close()
        '    End Try
        'Next
        '调用表单
        Dim rcFrm As New FrmPmDdGxHbz
        With rcFrm
            .ParaDataSet = rcDataSet
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .LblMsg.Text = "(" & Me.TxtBmdm.Text & ")" & Me.LblBmmc.Text
            .Show()
        End With
    End Sub

#End Region
End Class