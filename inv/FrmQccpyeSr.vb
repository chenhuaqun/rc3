Imports System.Data.OleDb

Public Class FrmQccpyeSr
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '先进先出法
    Dim strJjfs As String = "加权平均法"

#Region "初始化事件"

    Private Sub FrmKcslyeSr_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TxtQcsl.Text = 0.0
        Me.TxtQcFzsl.Text = 0.0
        Me.TxtQcje.Text = 0.0
        '取材料出库成本计算方法
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT parastrvalue FROM rc_para WHERE dwdm = ? AND paraid = '材料出库成本计算方法' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_para") IsNot Nothing Then
                Me.rcDataSet.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_para")
            If rcDataSet.Tables("rc_para").Rows.Count > 0 Then
                If rcDataSet.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    strJjfs = rcDataSet.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
    End Sub

#End Region

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCpdm.KeyPress, TxtCkdm.KeyPress, TxtQcje.KeyPress, TxtQcsl.KeyPress, TxtQcFzsl.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "物料编码事件"

    Private Sub TxtCpdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCpdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF34
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_cpxx"
                    .paraField1 = "cpdm"
                    .paraField2 = "cpmc"
                    .paraField3 = "dw"
                    .paraField4 = "cpsm"
                    .paraOrderField = "cpmc"
                    .paraTitle = "物料"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtCpdm.Text = Trim(.paraField1)
                        LblCpmc.Text = "物料描述：" & Trim(.paraField2)
                        LblDw.Text = "单    位：" & Trim(.paraField3)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtCpdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCpdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtCpdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT cpdm,cpmc,dw,khdm FROM rc_cpxx WHERE (cpdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_cpxx") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_cpxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_cpxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_cpxx").Rows.Count > 0 Then
                If rcDataSet.Tables("rc_cpxx").Rows(0).Item("cpmc").GetType.ToString <> "System.DBNull" Then
                    LblCpmc.Text = "物料描述：" & rcDataSet.Tables("rc_cpxx").Rows(0).Item("cpmc")
                End If
                If rcDataSet.Tables("rc_cpxx").Rows(0).Item("dw").GetType.ToString <> "System.DBNull" Then
                    LblDw.Text = "单    位：" & rcDataSet.Tables("rc_cpxx").Rows(0).Item("dw")
                End If
            Else
                Me.TxtCpdm.Focus()
            End If
            LoadSavedQcsl()
        End If
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
                Me.LblCkmc.Text = Trim(rcDataSet.Tables("rc_ckxx").Rows(0).Item("ckmc"))
            Else
                e.Cancel = True
            End If
            LoadSavedQcsl()
        End If
    End Sub

#End Region

#Region "取原来保存的年初数量"

    Private Sub LoadSavedQcsl()
        '取原来的数据
        If Not String.IsNullOrEmpty(Me.TxtCpdm.Text) And Not String.IsNullOrEmpty(Me.TxtCkdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT qcsl,qcfzsl,qcje FROM inv_cpyeb WHERE kjnd = ? AND cpdm = ? AND ckdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text).ToUpper
                rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(TxtCkdm.Text).ToUpper
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("cpye") IsNot Nothing Then
                    rcDataSet.Tables("cpye").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "cpye")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("cpye").Rows.Count > 0 Then
                Me.TxtQcsl.Text = rcDataSet.Tables("cpye").Rows(0).Item("qcsl")
                Me.TxtQcFzsl.Text = rcDataSet.Tables("cpye").Rows(0).Item("qcfzsl")
                Me.TxtQcje.Text = rcDataSet.Tables("cpye").Rows(0).Item("qcje")
            Else
                Me.TxtQcsl.Text = 0.0
                Me.TxtQcFzsl.Text = 0.0
                Me.TxtQcje.Text = 0.0
            End If
        End If
    End Sub

#End Region

#Region "保存数据事件"

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click, MnuiSave.Click
        If String.IsNullOrEmpty(Me.TxtCpdm.Text) Then
            Return
        End If
        '存数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM inv_cpyeb WHERE kjnd = ? AND cpdm = ? AND ckdm = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text).ToUpper
            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtCkdm.Text).ToUpper
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("cpye") IsNot Nothing Then
                rcDataSet.Tables("cpye").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "cpye")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("cpye").Rows.Count <= 0 Then
            '增加新记录
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "INSERT INTO inv_cpyeb (kjnd,cpdm,ckdm,qcsl,qcfzsl,qcje,idsl,idje) values (?,?,?,?,?,?,0.0,0.0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtCpdm.Text).ToUpper
                rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtCkdm.Text).ToUpper
                rcOleDbCommand.Parameters.Add("@qcsl", OleDbType.Numeric, 18).Value = Me.TxtQcsl.Text
                rcOleDbCommand.Parameters.Add("@qcfzsl", OleDbType.Numeric, 18).Value = Me.TxtQcFzsl.Text
                rcOleDbCommand.Parameters.Add("@qcje", OleDbType.Numeric, 14).Value = Me.TxtQcje.Text
                rcOleDbCommand.ExecuteNonQuery()
                '添加入库单记录
                If strJjfs = "先进先出法" Or strJjfs = "后进先出法" Then
                    rcOleDbCommand.CommandText = "INSERT INTO po_rkd (rkmemo,cpdm,ckdm,sl,fzsl,je) values ('期初库存',?,?,?,?,?)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtCpdm.Text).ToUpper
                    rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtCkdm.Text).ToUpper
                    rcOleDbCommand.Parameters.Add("@sl", OleDbType.Numeric, 18).Value = Me.TxtQcsl.Text
                    rcOleDbCommand.Parameters.Add("@fzsl", OleDbType.Numeric, 18).Value = Me.TxtQcFzsl.Text
                    rcOleDbCommand.Parameters.Add("@je", OleDbType.Numeric, 14).Value = Me.TxtQcje.Text
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
                rcOleDbCommand.CommandText = "UPDATE inv_cpyeb set qcsl = ?,qcfzsl = ?,qcje = ? WHERE kjnd = ? AND cpdm = ? AND ckdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@qcsl", OleDbType.Numeric, 18).Value = Me.TxtQcsl.Text
                rcOleDbCommand.Parameters.Add("@qcfzsl", OleDbType.Numeric, 18).Value = Me.TxtQcFzsl.Text
                rcOleDbCommand.Parameters.Add("@qcje", OleDbType.Numeric, 14).Value = Me.TxtQcje.Text
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text).ToUpper
                rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtCkdm.Text).ToUpper
                rcOleDbCommand.ExecuteNonQuery()
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
        TxtCpdm.Text = ""
        LblCpmc.Text = "物料描述："
        LblDw.Text = "单    位："
        TxtQcsl.Text = 0.0
        TxtQcFzsl.Text = 0.0
        TxtQcje.Text = 0.0
        TxtCpdm.Focus()
    End Sub

#End Region

#Region "读入excel"

    Private Sub BtnImpXls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiImpXls.Click
        '调用表单
        Dim rcFrm As New FrmQccpyeImpXls
        With rcFrm
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

#End Region

#Region "关闭"

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click, MnuiExit.Click
        Me.Close()
    End Sub

#End Region

End Class