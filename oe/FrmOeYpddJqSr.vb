Imports System.Data.OleDb
Public Class FrmOeYpddJqSr

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

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBmdm.KeyPress, TxtDjh.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
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

#Region "确定事件 "

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        'If Me.TxtBmdm.TextLength = 0 Then
        '    MsgBox("请输入部门编码", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
        '    Return
        'End If
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
        Dim strExpBmdm As String = " oe_ypdd.bmdm = ''"
        Dim j As Integer
        If rcDataset.Tables("rc_bmxx").Rows.Count = 1 Then
            TxtBmdm.Text = Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmdm"))
            strExpBmdm = strExpBmdm & " OR oe_ypdd.bmdm = '" & Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmdm")) & "'"
        Else
            For j = 0 To rcDataset.Tables("rc_bmxx").Rows.Count - 1
                strExpBmdm = strExpBmdm & " OR oe_ypdd.bmdm = '" & Trim(rcDataset.Tables("rc_bmxx").Rows(j).Item("bmdm")) & "'"
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

        '取数据
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT ddnr.*,rc_bmxx.bmmc FROM (SELECT oe_ypdd.djh,oe_ypdd.qdrq,oe_ypdd.hth,REPLACE(oe_ypdd.ddtk || oe_ypdd.ddmemo,' ','') as ddmemo,oe_ypdd.jhsbm,oe_ypdd.xh,oe_ypdd.cpdm,oe_ypdd.cpmc,oe_ypdd.cpgg,oe_ypdd.cpmemo,oe_ypdd.dw,oe_ypdd.muju,oe_ypdd.khlh,oe_ypdd.khcz,oe_ypdd.sl,oe_ypdd.khjhrq,oe_ypdd.scjhrq,oe_ypdd.bmdm,oe_ypdd.khdm,oe_ypdd.khmc FROM oe_ypdd WHERE (" & strExpBmdm & ") AND oe_ypdd.shr IS NULL AND NOT oe_ypdd.bmdm IS NULL" & IIf(TxtDjh.TextLength > 0, " and oe_ypdd.djh = '" & Trim(Me.TxtDjh.Text) & "'", " and oe_ypdd.scjhrq IS NULL") & IIf(TxtBmdm.TextLength > 0, " and oe_ypdd.bmdm = '" & Trim(TxtBmdm.Text) & "'", "") & ") ddnr left outer join rc_bmxx on ddnr.bmdm = rc_bmxx.bmdm ORDER BY ddnr.bmdm,ddnr.hth,ddnr.xh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_ddnr") IsNot Nothing Then
                rcDataset.Tables("rc_ddnr").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_ddnr")
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
        If rcDataset.Tables("rc_ddnr").Rows.Count <= 0 Then
            MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        '调用表单
        Dim rcFrm As New FrmOeYpddJqSrz
        With rcFrm
            .ParaDataSet = rcDataset
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

#End Region

End Class