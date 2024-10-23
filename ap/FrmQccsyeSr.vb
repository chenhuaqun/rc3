Imports System.Data.OleDb
Public Class FrmQccsyeSr
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Private Sub FrmQccsyeSr_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DtpRkrq.Value = g_Dwrq.Date.AddDays(-1)
        Me.TxtJe.Text = 0.0
        Me.TxtRkmemo.Text = ""
    End Sub

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCsdm.KeyPress, TxtXh.KeyPress, DtpRkrq.KeyPress, TxtJe.KeyPress, TxtRkmemo.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "供应商编码的事件"

    Private Sub TxtCsdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCsdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_csxx"
                    .paraField1 = "csdm"
                    .paraField2 = "csmc"
                    .paraField3 = "cssm"
                    .paraCondition = "0=0"
                    .paraOrderField = "csmc"
                    .paraTitle = "供应商"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtCsdm.Text = Trim(.paraField1)
                        LblCsmc.Text = Trim(.paraField2)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtCsdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCsdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtCsdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_csxx WHERE (csdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtCsdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_csxx") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_csxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_csxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_csxx").Rows.Count > 0 Then
                TxtCsdm.Text = Trim(rcDataSet.Tables("rc_csxx").Rows(0).Item("csdm"))
                LblCsmc.Text = rcDataSet.Tables("rc_csxx").Rows(0).Item("csmc")
            Else
                e.Cancel = True
                Return
            End If
            LoadSavedQcsl()
        End If
    End Sub

#End Region

    Private Sub TxtXh_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtXh.Validating
        LoadSavedQcsl()
    End Sub

#Region "取原来保存的年初数量"

    Private Sub LoadSavedQcsl()
        '取原来的数据
        If Not String.IsNullOrEmpty(Me.TxtCsdm.Text) And Not String.IsNullOrEmpty(Me.TxtXh.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT rkrq,je,rkmemo FROM po_rkd WHERE csdm = ? AND xh = ? AND djh = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 15).Value = Trim(Me.Txtcsdm.Text).ToUpper
                rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = Me.TxtXh.Text
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtCsdm.Text).ToUpper
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("csmx") IsNot Nothing Then
                    rcDataSet.Tables("csmx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "csmx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("csmx").Rows.Count > 0 Then
                Me.DtpRkrq.Value = rcDataSet.Tables("csmx").Rows(0).Item("rkrq")
                Me.TxtJe.Text = rcDataSet.Tables("csmx").Rows(0).Item("je")
                Me.TxtRkmemo.Text = rcDataSet.Tables("csmx").Rows(0).Item("rkmemo")
            Else
                Me.DtpRkrq.Value = g_Dwrq.Date.AddDays(-1)
                Me.TxtJe.Text = 0.0
                Me.TxtRkmemo.Text = ""
            End If
        End If
    End Sub

#End Region


#Region "保存数据事件"

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If String.IsNullOrEmpty(Me.TxtCsdm.Text) Or String.IsNullOrEmpty(Me.TxtXh.Text) Then
            Return
        End If
        '存数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM ap_csyeb WHERE kjnd = ? AND csdm = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
            rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtCsdm.Text).ToUpper
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("khyeb") IsNot Nothing Then
                rcDataSet.Tables("khyeb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "khyeb")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("csmx").Rows.Count <= 0 Then
            '增加新记录
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "INSERT INTO po_rkd (djh,xh,rkrq,csdm,csmc,je,rkmemo) values (?,?,?,?,?,?,?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Trim(Me.TxtCsdm.Text).ToUpper
                rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = Me.TxtXh.Text
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = Me.DtpRkrq.Value
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtCsdm.Text).ToUpper
                rcOleDbCommand.Parameters.Add("@csmc", OleDbType.VarChar, 50).Value = Me.LblCsmc.Text
                rcOleDbCommand.Parameters.Add("@je", OleDbType.Numeric, 18).Value = Me.TxtJe.Text
                rcOleDbCommand.Parameters.Add("@rkmemo", OleDbType.VarChar, 50).Value = Me.TxtRkmemo.Text
                rcOleDbCommand.ExecuteNonQuery()
                If rcDataSet.Tables("khyeb").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "UPDATE ap_csyeb SET qcje = qcje + ?,csmc = ? WHERE kjnd = ? AND csdm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@qcje", OleDbType.Numeric, 18).Value = Me.TxtJe.Text
                    rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
                    rcOleDbCommand.Parameters.Add("@csmc", OleDbType.VarChar, 50).Value = Me.LblCsmc.Text
                    rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtCsdm.Text).ToUpper
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "INSERT INTO ap_csyeb (kjnd,csdm,csmc,qcje,idje) values (?,?,?,?,0.0)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
                    rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtCsdm.Text).ToUpper
                    rcOleDbCommand.Parameters.Add("@csmc", OleDbType.VarChar, 50).Value = Me.LblCsmc.Text
                    rcOleDbCommand.Parameters.Add("@qcje", OleDbType.Numeric, 18).Value = Me.TxtJe.Text
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        Else
            '修改记录
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "UPDATE po_rkd SET rkrq = ?,csdm = ?,csmc = ?,je = ?,rkmemo = ? WHERE djh = ? AND xh = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = Me.DtpRkrq.Value
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtCsdm.Text).ToUpper
                rcOleDbCommand.Parameters.Add("@csmc", OleDbType.VarChar, 50).Value = Me.LblCsmc.Text
                rcOleDbCommand.Parameters.Add("@je", OleDbType.Numeric, 18).Value = Me.TxtJe.Text
                rcOleDbCommand.Parameters.Add("@rkmemo", OleDbType.VarChar, 50).Value = Me.TxtRkmemo.Text
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Trim(Me.TxtCsdm.Text).ToUpper
                rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = Me.TxtXh.Text
                rcOleDbCommand.ExecuteNonQuery()
                If rcDataSet.Tables("khyeb").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "UPDATE ap_csyeb SET qcje = qcje + ?,csmc = ? WHERE kjnd = ? AND csdm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@qcje", OleDbType.Numeric, 18).Value = Me.TxtJe.Text - rcDataSet.Tables("csmx").Rows(0).Item("je")
                    rcOleDbCommand.Parameters.Add("@csmc", OleDbType.VarChar, 50).Value = Me.LblCsmc.Text
                    rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
                    rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtCsdm.Text).ToUpper
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "INSERT INTO ap_csyeb (kjnd,csdm,csmc,qcje,idje) values (?,?,?,?,0.0)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
                    rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtCsdm.Text).ToUpper
                    rcOleDbCommand.Parameters.Add("@csmc", OleDbType.VarChar, 50).Value = Me.LblCsmc.Text
                    rcOleDbCommand.Parameters.Add("@qcje", OleDbType.Numeric, 18).Value = Me.TxtJe.Text '- rcDataSet.Tables("csmx").Rows(0).Item("je")
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        End If
        TxtCsdm.Text = ""
        LblCsmc.Text = ""
        TxtJe.Text = 0.0
        Me.TxtRkmemo.Text = ""
        Me.TxtCsdm.Focus()
    End Sub

#End Region

End Class