Imports System.Data.OleDb

Public Class FrmRoleEdit

#Region "定义变量"

    '建立OLEDB数据适配器对象
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    Dim rcDataset As New DataSet
    '建立OleDb传递对象
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDb命令
    ReadOnly rcOleDbCommand As OleDbCommand = sysOleDbConn.CreateCommand()
    '建立DataView数据视图
    Dim rcDataView As DataView
    '变量是否增加
    Dim isAdding As Boolean = False
    '变量当前位置
    Dim currentPos As Integer

#End Region

    Public Property ParaDataSet() As DataSet
        Get
            ParaDataSet = rcDataSet
        End Get
        Set(ByVal Value As DataSet)
            rcDataSet = Value
        End Set
    End Property

    Public Property ParaDataView() As DataView
        Get
            ParaDataView = rcDataView
        End Get
        Set(ByVal Value As DataView)
            rcDataView = Value
        End Set
    End Property

    Public Property ParaAdding() As Boolean
        Get
            ParaAdding = isAdding
        End Get
        Set(ByVal Value As Boolean)
            isAdding = Value
        End Set
    End Property

    Public Property PcurrentPos() As Integer
        Get
            PcurrentPos = currentPos
        End Get
        Set(ByVal Value As Integer)
            currentPos = Value
        End Set
    End Property

    Private Sub FrmRoleEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BindingContext(rcDataView, "").Position = currentPos
        Me.TxtRoleId.DataBindings.Add("Text", rcDataView, "roleid")
        Me.TxtRoleName.DataBindings.Add("Text", rcDataView, "rolename")
        Me.TxtRoleSm.DataBindings.Add("Text", rcDataView, "rolesm")
        SetAll(True)
        If isAdding Then
            isAdding = False
            NewEvent()
        Else
            EditEvent()
        End If
        Me.TxtRoleId.Focus()
    End Sub

    Private Sub SetAll(ByVal medit As Boolean)
        If Not medit Then
            Me.TxtRoleId.Enabled = False
            TxtRoleName.Enabled = False
            TxtRoleSm.Enabled = False
            Me.BtnTop.Enabled = True
            Me.BtnPrevious.Enabled = True
            Me.BtnNext.Enabled = True
            Me.BtnBottom.Enabled = True
            Me.BtnNew.Enabled = True
            Me.BtnEdit.Enabled = True
            Me.BtnSave.Enabled = False
            Me.BtnCancel.Enabled = False
            Me.BtnExit.Enabled = True
        Else
            TxtRoleId.Enabled = True
            TxtRoleName.Enabled = True
            Me.TxtRoleSm.Enabled = True
            Me.BtnTop.Enabled = False
            Me.BtnPrevious.Enabled = False
            Me.BtnNext.Enabled = False
            Me.BtnBottom.Enabled = False
            Me.BtnNew.Enabled = False
            Me.BtnEdit.Enabled = False
            Me.BtnSave.Enabled = True
            Me.BtnCancel.Enabled = True
            Me.BtnExit.Enabled = False
            Me.TxtRoleId.Focus()
        End If
    End Sub

    Private Sub MnuiNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiNew.Click
        NewEvent()
    End Sub

    Private Sub MnuiSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiSave.Click
        SaveEvent()
    End Sub

    Private Sub NewEvent()
        If Not isAdding Then
            isAdding = True
            Try
                currentPos = BindingContext(rcDataView, "").Position
                '清除当前编辑内容
                BindingContext(rcDataView, "").EndCurrentEdit()
                BindingContext(rcDataView, "").AddNew()
            Catch eEndEdit As System.Exception
                System.Windows.Forms.MessageBox.Show(eEndEdit.Message)
            End Try
            SetAll(True)
        End If
    End Sub

    Private Sub MnuiCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCancel.Click
        CancelEvent()
    End Sub

    Private Sub CancelEvent()
        '取消
        BindingContext(rcDataView, "").CancelCurrentEdit()
        BindingContext(rcDataView, "").Position = currentPos
        isAdding = False
        SetAll(False)
    End Sub

    Private Sub EditEvent()
        If isAdding Then
            Return
        End If
        currentPos = BindingContext(rcDataView, "").Position
        SetAll(True)
        Me.TxtRoleId.Enabled = False
    End Sub

    Private Sub SaveEvent()
        If isAdding Then
            If Trim(TxtRoleId.Text).Length = 0 Then
                MsgBox("角色编码不能为空。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            '检查重复名称规格
            sysOleDbConn.Open()
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "SELECT  *  FROM rc_roles WHERE RoleName = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@RoleName", OleDbType.VarChar, 40).Value = Trim(TxtRoleName.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("recpxx") IsNot Nothing Then
                    rcDataSet.Tables("recpxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "recpxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                sysOleDbConn.Close()
            End Try
            If rcDataSet.Tables("recpxx").Rows.Count > 0 Then
                If MsgBox("已经存在相同名称规格的角色，编码是" & rcDataSet.Tables("recpxx").Rows(0).Item("RoleId") & "，您是否要保存？", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "提示信息") = MsgBoxResult.No Then
                    sysOleDbConn.Open()
                    rcOleDbCommand.Connection = sysOleDbConn
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    Try
                        rcOleDbCommand.CommandText = "SELECT * FROM rc_roles ORDER BY roleid"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataSet.Tables("rc_roles") IsNot Nothing Then
                            rcDataSet.Tables("rc_roles").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataSet, "rc_roles")
                        BindingContext(rcDataView, "").Position = currentPos
                    Catch ex As Exception
                        Try
                            rcOleDbTrans.Rollback()
                            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        Catch ey As OleDbException
                            MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        End Try
                    Finally
                        sysOleDbConn.Close()
                    End Try
                    isAdding = False
                    SetAll(False)
                    Return
                End If
            End If
            'REM 增加保存
            sysOleDbConn.Open()
            rcOleDbTrans = sysOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "INSERT INTO rc_roles(roleid,rolename,rolesm) VALUES (?,?,?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@RoleId", OleDbType.VarChar, 12).Value = Trim(TxtRoleId.Text).ToUpper
                rcOleDbCommand.Parameters.Add("@RoleName", OleDbType.VarChar, 40).Value = Trim(TxtRoleName.Text)
                rcOleDbCommand.Parameters.Add("@RoleSm", OleDbType.VarChar, 12).Value = Trim(TxtRoleSm.Text).ToUpper
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "SELECT * FROM rc_roles ORDER BY RoleId"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_roles") IsNot Nothing Then
                    rcDataSet.Tables("rc_roles").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_roles")
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
                sysOleDbConn.Close()
            End Try
            BindingContext(rcDataView, "").Position = currentPos
            isAdding = False
        Else
            REM 修改账号
            sysOleDbConn.Open()
            rcOleDbTrans = sysOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "UPDATE rc_roles SET rolename = ?,rolesm = ? WHERE roleid = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@RoleName", OleDbType.VarChar, 40).Value = Trim(TxtRoleName.Text)
                rcOleDbCommand.Parameters.Add("@RoleSm", OleDbType.VarChar, 12).Value = Trim(TxtRoleSm.Text).ToUpper
                rcOleDbCommand.Parameters.Add("@RoleId", OleDbType.VarChar, 12).Value = Trim(TxtRoleId.Text)
                rcOleDbCommand.ExecuteNonQuery()
                '填充数据
                rcOleDbCommand.CommandText = "SELECT  * FROM rc_roles ORDER BY RoleId"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_roles") IsNot Nothing Then
                    rcDataSet.Tables("rc_roles").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_roles")
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
                sysOleDbConn.Close()
            End Try
            BindingContext(rcDataView, "").Position = currentPos
        End If
        SetAll(False)
    End Sub

    Private Sub MnuiExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiExit.Click
        Me.Close()
    End Sub

    Private Sub TxtRoleId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtRoleId.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtRoleName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtRoleName.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtRoleSm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtRoleSm.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtRoleName_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtRoleName.Validating
        Dim rcGetChineseSpell As New ClsGetChineseSpell
        Me.TxtRoleSm.Text = Mid(rcGetChineseSpell.GetChineseSpell(Me.TxtRoleName.Text), 1, Me.TxtRoleSm.MaxLength)
    End Sub

#Region "首上下末"

    Private Sub BtnTop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTop.Click
        If BindingContext(rcDataView, "").Count > 0 Then
            BindingContext(rcDataView, "").Position = 0
        End If
    End Sub

    Private Sub BtnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevious.Click
        If BindingContext(rcDataView, "").Count > 0 Then
            If BindingContext(rcDataView, "").Position <> 0 Then
                BindingContext(rcDataView, "").Position -= 1
            End If
        End If
    End Sub

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
        If BindingContext(rcDataView, "").Count > 0 Then
            If BindingContext(rcDataView, "").Position <> BindingContext(rcDataView, "").Count Then
                BindingContext(rcDataView, "").Position += 1
            End If
        End If
    End Sub

    Private Sub BtnBottom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBottom.Click
        If BindingContext(rcDataView, "").Count > 0 Then
            BindingContext(rcDataView, "").Position = BindingContext(rcDataView, "").Count - 1
        End If
    End Sub

#End Region

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        NewEvent()
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        EditEvent()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        SaveEvent()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        CancelEvent()
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

End Class