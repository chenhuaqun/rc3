Imports System.Data.OleDb

Public Class FrmEmailOption
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '数据更新传递
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Private Sub FrmEmailOption_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '取系统参数
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT paraid,parastrvalue,paradblvalue FROM rc_para WHERE SUBSTR(paraid,1,3) = '发件人' Order by paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
        Catch ex As Exception
            MsgBox("程序错误2。" & Chr(13) & ex.Message)
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_para").Rows.Count = 5 Then
            If rcDataset.Tables("rc_para").Rows(3).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                Me.TxtEmail.Text = rcDataset.Tables("rc_para").Rows(3).Item("parastrvalue")
            End If
            If rcDataset.Tables("rc_para").Rows(2).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                Me.TxtSmtp.Text = rcDataset.Tables("rc_para").Rows(2).Item("parastrvalue")
            End If
            If rcDataset.Tables("rc_para").Rows(1).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                Me.TxtAccount.Text = rcDataset.Tables("rc_para").Rows(1).Item("parastrvalue")
            End If
            If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                Me.TxtPwd.Text = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
            End If
            If rcDataset.Tables("rc_para").Rows(4).Item("paradblvalue").GetType.ToString <> "System.DBNull" Then
                Me.ChbSfyz.Checked = rcDataset.Tables("rc_para").Rows(4).Item("paradblvalue")
            End If
        End If
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        '写系统参数
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)        ' Start a local transaction
            rcOleDbCommand.Connection = rcOleDbConn        ' Assign transaction object for a pending local transaction
            rcOleDbCommand.Transaction = rcOleDbTrans
            '删除数据
            rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE (paraid = '发件人电子邮件地址' or paraid = '发件人SMTP服务器' or paraid = '发件人身份验证标志' or paraid = '发件人Email帐号' or paraid ='发件人Email密码')"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.ExecuteNonQuery()
            '插入数据
            rcOleDbCommand.CommandText = "INSERT INTO rc_para (paraid,parastrvalue,paradblvalue) VALUES ('发件人电子邮件地址',?,0.0)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 30).Value = Me.TxtEmail.Text
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "INSERT INTO rc_para (paraid,parastrvalue,paradblvalue) VALUES ('发件人SMTP服务器',?,0.0)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 30).Value = Me.TxtSmtp.Text
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "INSERT INTO rc_para (paraid,parastrvalue,paradblvalue) VALUES ('发件人身份验证标志','',?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.Integer, 1).Value = IIf(Me.ChbSfyz.Checked, 1, 0)
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "INSERT INTO rc_para (paraid,parastrvalue,paradblvalue) VALUES ('发件人Email帐号',?,0.0)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 30).Value = Me.TxtAccount.Text
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "INSERT INTO rc_para (paraid,parastrvalue,paradblvalue) VALUES ('发件人Email密码',?,0.0)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 30).Value = Me.TxtPwd.Text
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误。" & Chr(13) & ex.Message)
            Catch ey As OleDbException
                MsgBox("程序错误。" & Chr(13) & ey.Message)
            End Try
        Finally
            rcOleDbConn.Close()
        End Try
        Me.Close()

    End Sub
End Class