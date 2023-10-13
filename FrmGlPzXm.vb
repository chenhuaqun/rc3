Imports System.Data.OleDb

Public Class FrmGlPzXm

#Region "定义变量"

    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '数据更新传递
    ReadOnly rcOleDbTrans As OleDbTransaction

#End Region

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtXmdm.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "项目编码事件"

    Private Sub TxtXmdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtXmdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "gl_xmxx"
                    .paraField1 = "xmdm"
                    .paraField2 = "xmmc"
                    .paraField3 = "xmsm"
                    .paraTitle = "项目"
                    .paraOldValue = ""
                    .paraAddName = ""
                    .paraCondition = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtXmdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtXmdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtXmdm.Validating
        If String.IsNullOrEmpty(Me.TxtXmdm.Text) Then
            e.Cancel = True
            Return
        End If
        rcOleDbConn.Open()
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT * FROM gl_xmxx where (xmdm = ?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@xmdm", OleDbType.VarChar, 12).Value = Trim(TxtXmdm.Text)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("gl_xmxx") IsNot Nothing Then
                Me.rcDataSet.Tables("gl_xmxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "gl_xmxx")
        Catch ex As Exception
            Try
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("gl_xmxx").Rows.Count > 0 Then
            Me.TxtXmdm.Text = Trim(rcDataSet.Tables("gl_xmxx").Rows(0).Item("xmdm"))
            Me.TxtXmmc.Text = rcDataSet.Tables("gl_xmxx").Rows(0).Item("xmmc")
        Else
            MsgBox("项目编码不存在。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            e.Cancel = True
        End If
    End Sub

#End Region

#Region "确定事件"

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Me.DialogResult = DialogResult.OK
    End Sub

#End Region

End Class
