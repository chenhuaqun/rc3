Imports System.Data.OleDb

Public Class FrmCpGroup

    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '数据更新传递
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立DataGridViewTextBoxEditingControl对象
    ReadOnly EditingControl1 As DataGridViewTextBoxEditingControl
    ReadOnly i As Integer = 0

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGroupID.KeyPress, TxtGroupName.KeyPress, TxtGroupSm.KeyPress, TxtGuanLiYuan.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If Me.ActiveControl.GetType.Name = "DataGridViewTextBoxEditingControl" Then
            Select Case keyData
                Case Keys.Enter, Keys.Right
                    SendKeys.Send("{TAB}")
                    Return True
                Case Keys.Left
                    SendKeys.Send("+{TAB}")
                    Return True
            End Select
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

#End Region

#Region "物料编码事件"

    Private Sub TxtGroupID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtGroupID.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_cpgroupml"
                    .paraField1 = "groupid"
                    .paraField2 = "groupname"
                    .paraField3 = "groupsm"
                    .paraOrderField = "groupname"
                    .paraTitle = "物料组"
                    .paraOldValue = Me.TxtGroupID.Text
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtGroupID.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtGroupID_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtGroupID.Validating
        Dim i As Integer
        If Not String.IsNullOrEmpty(Me.TxtGroupID.Text) Then
            '读取数据
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * From rc_cpgroupml Where groupid = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@groupid", OleDbType.VarChar, 12).Value = Trim(Me.TxtGroupID.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_cpgroupml") IsNot Nothing Then
                    rcDataset.Tables("rc_cpgroupml").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_cpgroupml")
                'rcOleDbCommand.CommandText = "SELECT rc_cpgroupnr.cpdm,rc_cpxx.cpmc,rc_cpxx.dw FROM rc_cpxx,rc_cpgroupnr WHERE rc_cpxx.cpdm = rc_cpgroupnr.cpdm AND rc_cpgroupnr.groupid = ? ORDER BY rc_cpgroupnr.cpdm"
                'rcOleDbCommand.Parameters.Clear()
                'rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtGroupID.Text)
                'If Not rcDataset.Tables("rc_cpgroupnr") Is Nothing Then
                '    rcDataset.Tables("rc_cpgroupnr").Clear()
                'End If
                'rcOleDbDataAdpt.Fill(rcDataset, "rc_cpgroupnr")
            Catch ex As Exception
                MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_cpgroupml").Rows.Count > 0 Then
                If rcDataset.Tables("rc_cpgroupml").Rows(0).Item("groupname").GetType.ToString <> "System.DBNull" Then
                    Me.TxtGroupName.Text = rcDataset.Tables("rc_cpgroupml").Rows(0).Item("groupname")
                End If
                If rcDataset.Tables("rc_cpgroupml").Rows(0).Item("groupsm").GetType.ToString <> "System.DBNull" Then
                    Me.TxtGroupSm.Text = rcDataset.Tables("rc_cpgroupml").Rows(0).Item("groupsm")
                End If
                If rcDataset.Tables("rc_cpgroupml").Rows(0).Item("guanliyuan").GetType.ToString <> "System.DBNull" Then
                    Me.TxtGuanLiYuan.Text = rcDataset.Tables("rc_cpgroupml").Rows(0).Item("guanliyuan")
                End If
            End If
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT cpdm,cpmc FROM rc_cpxx WHERE EXISTS (SELECT 1 FROM rc_cpgroupnr WHERE rc_cpxx.cpdm = rc_cpgroupnr.cpdm AND rc_cpgroupnr.groupid = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@groupid", OleDbType.VarChar, 12).Value = Me.TxtGroupID.Text
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_cpgroupnr") IsNot Nothing Then
                    rcDataset.Tables("rc_cpgroupnr").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_cpgroupnr")
            Catch ex As Exception
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            Me.ListBoxYixuan.Items.Clear()
            For i = 0 To rcDataset.Tables("rc_cpgroupnr").Rows.Count - 1
                ListBoxYixuan.Items.Add(rcDataset.Tables("rc_cpgroupnr").Rows(i).Item("cpdm") & " " & rcDataset.Tables("rc_cpgroupnr").Rows(i).Item("cpmc"))
            Next
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT cpdm,cpmc FROM rc_cpxx WHERE NOT EXISTS (SELECT 1 FROM rc_cpgroupnr WHERE rc_cpxx.cpdm = rc_cpgroupnr.cpdm AND rc_cpgroupnr.groupid = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@groupid", OleDbType.VarChar, 12).Value = Me.TxtGroupID.Text
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_cpgroupnr") IsNot Nothing Then
                    rcDataset.Tables("rc_cpgroupnr").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_cpgroupnr")
            Catch ex As Exception
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            Me.ListBoxYuxuan.Items.Clear()
            For i = 0 To rcDataset.Tables("rc_cpgroupnr").Rows.Count - 1
                ListBoxYuxuan.Items.Add(rcDataset.Tables("rc_cpgroupnr").Rows(i).Item("cpdm") & " " & rcDataset.Tables("rc_cpgroupnr").Rows(i).Item("cpmc"))
            Next
        End If
    End Sub

#End Region

    Private Sub ListBoxYuxuan_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBoxYuxuan.DoubleClick
        If Me.ListBoxYuxuan.SelectedItem IsNot Nothing Then
            Me.ListBoxYixuan.Items.Add(Me.ListBoxYuxuan.SelectedItem)
            Me.ListBoxYuxuan.Items.Remove(Me.ListBoxYuxuan.SelectedItem)
        End If
    End Sub

    Private Sub ListBoxYixuan_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBoxYixuan.DoubleClick
        If Me.ListBoxYixuan.SelectedItem IsNot Nothing Then
            Me.ListBoxYuxuan.Items.Add(Me.ListBoxYixuan.SelectedItem)
            Me.ListBoxYixuan.Items.Remove(Me.ListBoxYixuan.SelectedItem)
        End If
    End Sub

    Private Sub BtnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectAll.Click
        Dim i As Integer
        For i = 0 To Me.ListBoxYuxuan.Items.Count - 1
            Me.ListBoxYixuan.Items.Add(Me.ListBoxYuxuan.Items(0))
            Me.ListBoxYuxuan.Items.Remove(Me.ListBoxYuxuan.Items(0))
        Next
    End Sub

    Private Sub BtnSelectOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectOne.Click
        If Me.ListBoxYuxuan.SelectedItems.Count > 0 Then
            Me.ListBoxYixuan.Items.Add(Me.ListBoxYuxuan.SelectedItem)
            Me.ListBoxYuxuan.Items.Remove(Me.ListBoxYuxuan.SelectedItem)
        End If
    End Sub

    Private Sub BtnUnSelectOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUnSelectOne.Click
        If Me.ListBoxYixuan.SelectedItems.Count > 0 Then
            Me.ListBoxYuxuan.Items.Add(Me.ListBoxYixuan.SelectedItem)
            Me.ListBoxYixuan.Items.Remove(Me.ListBoxYixuan.SelectedItem)
        End If
    End Sub

    Private Sub BtnUnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUnSelectAll.Click
        Dim i As Integer
        For i = 0 To Me.ListBoxYixuan.Items.Count - 1
            Me.ListBoxYuxuan.Items.Add(Me.ListBoxYixuan.Items(0))
            Me.ListBoxYixuan.Items.Remove(Me.ListBoxYixuan.Items(0))
        Next
    End Sub

#Region "新增"

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, MnuiNew.Click
        NewEvent()
    End Sub

    Private Sub NewEvent()
        Me.TxtGroupID.Text = ""
        Me.TxtGroupName.Text = ""
        Me.TxtGroupSm.Text = ""
        Me.TxtGuanLiYuan.Text = ""
        Me.ListBoxYuxuan.Items.Clear()
        Me.ListBoxYixuan.Items.Clear()
    End Sub
#End Region

#Region "保存事件"

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MnuiSave.Click
        Dim i As Integer
        If String.IsNullOrEmpty(Me.TxtGroupID.Text) Or Me.ListBoxYuxuan.Items.Count <= 0 Then
            Return
        End If
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "DELETE FROM rc_cpgroupml WHERE groupid = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@groupid", OleDbType.VarChar, 12).Value = Me.TxtGroupID.Text
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "DELETE FROM rc_cpgroupnr WHERE groupid = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@groupid", OleDbType.VarChar, 12).Value = Me.TxtGroupID.Text
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "INSERT INTO rc_cpgroupml (groupid,groupname,groupsm,guanliyuan) VALUES (?,?,?,?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@groupid", OleDbType.VarChar, 12).Value = Trim(Me.TxtGroupID.Text)
            rcOleDbCommand.Parameters.Add("@groupname", OleDbType.VarChar, 50).Value = Trim(Me.TxtGroupName.Text)
            rcOleDbCommand.Parameters.Add("@groupsm", OleDbType.VarChar, 12).Value = Trim(Me.TxtGroupSm.Text)
            rcOleDbCommand.Parameters.Add("@guanliyuan", OleDbType.VarChar, 30).Value = Trim(Me.TxtGuanLiYuan.Text)
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "INSERT INTO rc_cpgroupnr (groupid,cpdm) VALUES (?,?)"
            For i = 0 To Me.ListBoxYixuan.Items.Count - 1
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@groupid", OleDbType.VarChar, 12).Value = Trim(Me.TxtGroupID.Text)
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Mid(Me.ListBoxYixuan.Items(i), 1, InStr(Me.ListBoxYixuan.Items(i), " ") - 1)
                rcOleDbCommand.ExecuteNonQuery()
            Next
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        NewEvent()
    End Sub

#End Region

#Region "删除事件"

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, MnuiDelete.Click
        If String.IsNullOrEmpty(Me.TxtGroupID.Text) Then
            Return
        End If
        If MsgBox("您是否要删除该物料清单", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "提示信息") = MsgBoxResult.Yes Then
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "DELETE FROM rc_cpgroupml WHERE groupid = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@groupid", OleDbType.VarChar, 15).Value = Me.TxtGroupID.Text
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "DELETE FROM rc_cpgroupnr WHERE groupid = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@groupid", OleDbType.VarChar, 15).Value = Me.TxtGroupID.Text
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            NewEvent()
        End If
    End Sub

#End Region

#Region "退出表单事件"

    Private Sub MnuiExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiExit.Click, BtnExit.Click
        Me.Close()
    End Sub

#End Region
End Class