Imports System.Data.OleDb

Public Class FrmOeDddjSh
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

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
                Me.TxtLbdm.Text = Trim(rcDataset.Tables("rc_cplb").Rows(0).Item("lbdm"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "单据号事件"

    Private Sub TxtDjh_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDjh.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        '权限控制
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT code AS lbdm from rc_userqx WHERE righttype = 'LBDM' AND User_Account = ?" & IIf(Trim(Me.TxtLbdm.Text).Length > 0, " AND code ='" & Trim(Me.TxtLbdm.Text) & "'", "")
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = g_User_Account
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_cplb") IsNot Nothing Then
                rcDataset.Tables("rc_cplb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_cplb")
        Catch ex As Exception
            MsgBox("程序错误2。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_cplb").Rows.Count <= 0 Then
            MsgBox("你无权查看该报表。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Return
        End If
        Dim strExpLbdm As String = ""
        Dim j As Integer
        If rcDataset.Tables("rc_cplb").Rows.Count = 1 Then
            Me.TxtLbdm.Text = Trim(rcDataset.Tables("rc_cplb").Rows(0).Item("lbdm"))
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

        '取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT oe_dd.djh,oe_dd.xh,oe_dd.qdrq,oe_dd.khdm,oe_dd.khmc,oe_dd.cpdm,oe_dd.cpmc,oe_dd.dw,oe_dd.sl,oe_dd.dj,oe_dd.bzcb,oe_dd.clcb,oe_dd.rgcb,oe_dd.glcb,rc_cpxx.bzcb AS lastbzcb,rc_cpxx.clcb AS lastclcb,rc_cpxx.rgcb AS lastrgcb,rc_cpxx.glcb AS lastglcb FROM oe_dd,rc_cpxx WHERE oe_dd.cpdm = rc_cpxx.cpdm AND NOT oe_dd.shr IS NULL AND (" & strExpLbdm & ")" & IIf(Me.TxtDjh.TextLength > 0, " AND oe_dd.djh = '" & Trim(Me.TxtDjh.Text) & "'", " AND oe_dd.bzcb = 0.0 AND oe_dd.sl - oe_dd.hxsl > 0") & " ORDER BY oe_dd.djh,oe_dd.xh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_ddnr") IsNot Nothing Then
                rcDataset.Tables("rc_ddnr").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_ddnr")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_ddnr").Rows.Count <= 0 Then
            MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        'For j = 0 To rcDataset.Tables("rc_ddnr").Rows.Count - 1
        '    '取数据
        '    Try
        '        rcOleDbConn.Open()
        '        rcOleDbCommand.Connection = rcOleDbConn
        '        rcOleDbCommand.CommandTimeout = 300
        '        rcOleDbCommand.CommandType = CommandType.Text
        '        rcOleDbCommand.CommandText = "SELECT bzcb FROM rc_cpxx WHERE cpdm = ? AND bzcb <> 0"
        '        rcOleDbCommand.Parameters.Clear()
        '        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_ddnr").Rows(j).Item("cpdm")
        '        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
        '        If Not rcDataset.Tables("rc_cpxx") Is Nothing Then
        '            rcDataset.Tables("rc_cpxx").Clear()
        '        End If
        '        rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
        '        If rcDataset.Tables("rc_cpxx").Rows.Count > 0 Then
        '            If rcDataset.Tables("rc_cpxx").Rows(0).Item("bzcb").GetType.ToString <> "System.DBNull" Then
        '                rcDataset.Tables("rc_ddnr").Rows(j).Item("bzcb") = rcDataset.Tables("rc_cpxx").Rows(0).Item("bzcb")
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
        Dim rcFrm As New FrmOeDddjShz
        With rcFrm
            .ParaDataSet = rcDataset
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class