Imports System.Data.OleDb

Public Class FrmCostRegionEdit

#Region "定义变量"

    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    Dim rcDataset As New DataSet
    '数据更新传递
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '数据视图
    Dim rcDataView As DataView
    '新增标志
    Dim isAdding As Boolean = False
    '当前记录号
    Dim currentPos As Integer

#End Region

#Region "初始化"

    Overloads Property ParaDataSet() As DataSet
        Get
            ParaDataSet = rcDataset
        End Get
        Set(ByVal Value As DataSet)
            rcDataset = Value
        End Set
    End Property

    Overloads Property ParaDataView() As DataView
        Get
            ParaDataView = rcDataView
        End Get
        Set(ByVal Value As DataView)
            rcDataView = Value
        End Set
    End Property

    Overloads Property ParaAdding() As Boolean
        Get
            ParaAdding = isAdding
        End Get
        Set(ByVal Value As Boolean)
            isAdding = Value
        End Set
    End Property

    Overloads Property ParaCurrentPos() As Integer
        Get
            ParaCurrentPos = currentPos
        End Get
        Set(ByVal Value As Integer)
            currentPos = Value
        End Set
    End Property

    Private Sub FrmCostRegionEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.TxtCrdm.DataBindings.Add("Text", rcDataView, "crdm")
        Me.TxtCrmc.DataBindings.Add("Text", rcDataView, "crmc")
        Me.TxtCrsm.DataBindings.Add("Text", rcDataView, "crsm")
        BindingContext(rcDataView, "").Position = currentPos
        SetAll(True)
        If isAdding Then
            '清除当前编辑内容
            BindingContext(rcDataView, "").EndCurrentEdit()
            '增加一行
            BindingContext(rcDataView, "").AddNew()
        Else
            Me.TxtCrdm.Enabled = False
        End If
    End Sub

#End Region

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCrdm.KeyPress, TxtCrsm.KeyPress, TxtCrmc.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "设置控件"

    Private Sub SetAll(ByVal medit As Boolean)
        If Not medit Then
            Me.TxtCrdm.Enabled = False
            Me.TxtCrsm.Enabled = False
            Me.TxtCrmc.Enabled = False
            Me.BtnTop.Enabled = True
            Me.BtnPrevious.Enabled = True
            Me.BtnNext.Enabled = True
            Me.BtnBottom.Enabled = True
            Me.BtnNew.Enabled = True
            Me.BtnEdit.Enabled = True
            Me.BtnSave.Enabled = False
            Me.BtnCancel.Enabled = False
            Me.BtnExit.Enabled = True
            Me.MnuiNew.Enabled = True
            Me.MnuiEdit.Enabled = True
            Me.MnuiSave.Enabled = False
            Me.MnuiCancel.Enabled = False
            Me.MnuiExit.Enabled = True
        Else
            Me.TxtCrdm.Enabled = True
            Me.TxtCrsm.Enabled = True
            Me.TxtCrmc.Enabled = True
            Me.BtnTop.Enabled = False
            Me.BtnPrevious.Enabled = False
            Me.BtnNext.Enabled = False
            Me.BtnBottom.Enabled = False
            Me.BtnNew.Enabled = False
            Me.BtnEdit.Enabled = False
            Me.BtnSave.Enabled = True
            Me.BtnCancel.Enabled = True
            Me.BtnExit.Enabled = False
            Me.MnuiNew.Enabled = False
            Me.MnuiEdit.Enabled = False
            Me.MnuiSave.Enabled = True
            Me.MnuiCancel.Enabled = True
            Me.MnuiExit.Enabled = False
            Me.TxtCrdm.Focus()
        End If
    End Sub

#End Region

#Region "成本域名称事件"

    Private Sub TxtCrmc_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCrmc.Validating
        Me.TxtCrsm.Text = Trim(Mid(GetChineseSpell(Me.TxtCrmc.Text), 1, 12))
    End Sub

#End Region

#Region "首上下末记录"

    Private Sub BtnTop_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTop.Click
        If BindingContext(rcDataView, "").Count > 0 Then
            BindingContext(rcDataView, "").Position = 0
        End If
    End Sub

    Private Sub BtnPrevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPrevious.Click
        If BindingContext(rcDataView, "").Count > 0 Then
            If BindingContext(rcDataView, "").Position <> 0 Then
                BindingContext(rcDataView, "").Position -= 1
            End If
        End If
    End Sub

    Private Sub BtnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNext.Click
        If BindingContext(rcDataView, "").Count > 0 Then
            If BindingContext(rcDataView, "").Position <> BindingContext(rcDataView, "").Count Then
                BindingContext(rcDataView, "").Position += 1
            End If
        End If
    End Sub

    Private Sub BtnBottom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBottom.Click
        If BindingContext(rcDataView, "").Count > 0 Then
            BindingContext(rcDataView, "").Position = BindingContext(rcDataView, "").Count - 1
        End If
    End Sub

#End Region

#Region "新增"

    Private Sub BtnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNew.Click, MnuiNew.Click
        NewEvent()
    End Sub

    Private Sub NewEvent()
        '新增
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

#End Region

#Region "修改"

    Private Sub BtnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnEdit.Click, MnuiEdit.Click
        EditEvent()
    End Sub

    Private Sub EditEvent()
        '修改
        If isAdding Then
            isAdding = False
        End If
        Try
            currentPos = BindingContext(rcDataView, "").Position
            '清除当前编辑内容
            BindingContext(rcDataView, "").EndCurrentEdit()
        Catch eEndEdit As System.Exception
            System.Windows.Forms.MessageBox.Show(eEndEdit.Message)
        End Try
        SetAll(True)
        Me.TxtCrdm.Enabled = False
    End Sub

#End Region

#Region "保存"

    Private Sub TsSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MnuiSave.Click
        SaveEvent()
    End Sub

    Private Sub SaveEvent()
        '保存
        If isAdding Then
            If String.IsNullOrEmpty(Me.TxtCrdm.Text) Then
                Return
            End If
            'REM 增加保存
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "Insert Into rc_costregion (crdm,crmc,crsm) VALUES (?,?,?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@crdm", OleDbType.VarChar, 12).Value = Trim(TxtCrdm.Text)
                rcOleDbCommand.Parameters.Add("@crmc", OleDbType.VarChar, 30).Value = Trim(TxtCrmc.Text)
                rcOleDbCommand.Parameters.Add("@crsm", OleDbType.VarChar, 12).Value = Trim(TxtCrsm.Text)
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "SELECT * FROM rc_costregion ORDER BY crdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_costregion") IsNot Nothing Then
                    rcDataset.Tables("rc_costregion").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_costregion")
                BindingContext(rcDataView, "").Position = currentPos
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
            isAdding = False
        Else
            REM 修改账号
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "UPDATE rc_costregion SET crmc = ? , crsm = ?  WHERE  crdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@crmc", OleDbType.VarChar, 30).Value = Trim(TxtCrmc.Text)
                rcOleDbCommand.Parameters.Add("@crsm", OleDbType.VarChar, 12).Value = Trim(TxtCrsm.Text)
                rcOleDbCommand.Parameters.Add("@crdm", OleDbType.VarChar, 12).Value = Trim(TxtCrdm.Text)
                rcOleDbCommand.ExecuteNonQuery()
                '填充数据
                rcOleDbCommand.CommandText = "SELECT * FROM rc_costregion ORDER BY crdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_costregion") IsNot Nothing Then
                    rcDataset.Tables("rc_costregion").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_costregion")
                BindingContext(rcDataView, "").Position = currentPos
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
        SetAll(False)
    End Sub

#End Region

#Region "取消"

    Private Sub TsCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click, MnuiCancel.Click
        CancelEvent()
    End Sub

    Private Sub CancelEvent()
        '取消
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT * FROM rc_costregion ORDER BY crdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_costregion") IsNot Nothing Then
                rcDataset.Tables("rc_costregion").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_costregion")
            BindingContext(rcDataView, "").Position = currentPos
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
        isAdding = False
        SetAll(False)
    End Sub

#End Region

#Region "关闭"

    Private Sub BtnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExit.Click, MnuiExit.Click
        Me.Close()
    End Sub

#End Region

#Region "关于"

    Private Sub MnuiAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuiAbout.Click
        Dim rcFrm As New FrmAbout
        With rcFrm
            .ShowDialog()
        End With
    End Sub

#End Region
End Class