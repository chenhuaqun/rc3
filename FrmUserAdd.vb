Imports System.Data.OleDb

Public Class FrmUserAdd
    '建立OLEDB数据适配器对象
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDb传递对象
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDb命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAccount.KeyPress, TxtDspName.KeyPress, TxtPWD.KeyPress, TxtPWDConfirm.KeyPress, TxtDwdm.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region


    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        '加密
        Dim strPwdE As String
        Dim c As New models.rcCryptography
        strPwdE = c.EnCryptography(TxtPWD.Text)
        If TxtPWD.Text = Me.TxtPWDConfirm.Text Then
            Try
                sysOleDbConn.Open()
                rcOleDbTrans = sysOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = sysOleDbConn
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandText = "INSERT INTO rc_users (User_Account,User_PWD,User_DspName,User_Delete,User_Dwdm) values (?,?,?,0,?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = Trim(Me.TxtAccount.Text)
                rcOleDbCommand.Parameters.Add("@User_PWD", OleDbType.VarChar, 20).Value = strPwdE
                rcOleDbCommand.Parameters.Add("@User_DspName", OleDbType.VarChar, 30).Value = Trim(Me.TxtDspName.Text)
                rcOleDbCommand.Parameters.Add("@User_Dwdm", OleDbType.VarChar, 30).Value = Trim(Me.TxtDwdm.Text)
                rcOleDbCommand.ExecuteNonQuery()
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
                sysOleDbConn.Close()
            End Try
        End If
        Me.Close()
    End Sub

End Class