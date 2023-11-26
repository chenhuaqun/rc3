Imports System.Data.OleDb

Public Class FrmInvPcSr

    '建立OLEDB数据适配器对象
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDb命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Private Sub FrmInvPcSr_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DtpPcrq.Value = g_Kjrq
    End Sub

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpPcrq.KeyPress, TxtCkdm.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "仓库编码的事件"

    Private Sub TxtCkdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCkdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_ckxx"
                    .paraField1 = "ckdm"
                    .paraField2 = "ckmc"
                    .paraField3 = "cksm"
                    .paraTitle = "仓库"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtCkdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtCkdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCkdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtCkdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_ckxx WHERE (ckdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(TxtCkdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_ckxx") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_ckxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_ckxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_ckxx").Rows.Count > 0 Then
                Me.TxtCkdm.Text = Trim(rcDataSet.Tables("rc_ckxx").Rows(0).Item("ckdm"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim strKjqj As String = getInvKjqj(Me.DtpPcrq.Value.Date)
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT ny,jzbz FROM rc_yj WHERE ny = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = strKjqj
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_yj") IsNot Nothing Then
                rcDataSet.Tables("rc_yj").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_yj")
        Catch ex As Exception
            MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("rc_yj").Rows.Count = 0 Then
            MsgBox("会计期间设置有错误，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        If rcDataSet.Tables("rc_yj").Rows(0).Item("jzbz") Then
            MsgBox("本月已结账。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        If String.IsNullOrEmpty(Me.TxtCkdm.Text) Then
            MsgBox("仓库编码不能为空。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        '调用表单
        Dim rcFrm As New FrmInvPcSrz
        With rcFrm
            .ParaDatePcrq = Me.DtpPcrq.Value
            .ParaStrCkdm = Me.TxtCkdm.Text
            If rcDataSet.Tables("rc_ckxx").Rows.Count > 0 Then
                .LblCkmc.Text = rcDataSet.Tables("rc_ckxx").Rows(0).Item("ckmc")
            End If
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class