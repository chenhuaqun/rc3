Imports System.Data.OleDb

Public Class FrmPmCkdSr
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    ''表示要在数据源执行的 SQL 事务
    'Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Private Sub FrmPmCkdSr_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        NudYear.Value = Mid(g_Kjqj, 1, 4)
        NudMonth.Value = Mid(g_Kjqj, 5, 2)
    End Sub

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NudYear.KeyPress, NudMonth.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region


    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT ny,jzbz FROM rc_yj WHERE ny = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
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
        '调用表单
        Dim rcFrm As New FrmPmCkdSrz
        With rcFrm
            .ParaStrYear = NudYear.Value.ToString.PadLeft(4, "0")
            .ParaStrMonth = NudMonth.Value.ToString.PadLeft(2, "0")
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class