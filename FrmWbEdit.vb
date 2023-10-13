Imports System.Data.OleDb

Public Class FrmWbEdit

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

    Private Sub FrmWbEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.TxtWbdm.DataBindings.Add("Text", rcDataView, "wbdm")
        Me.TxtWbmc.DataBindings.Add("Text", rcDataView, "wbmc")
        Me.TxtWbsm.DataBindings.Add("Text", rcDataView, "Wbsm")
        Me.TxtWbhl01.DataBindings.Add("Text", rcDataView, "wbhl01")
        Me.TxtWbhl02.DataBindings.Add("Text", rcDataView, "wbhl02")
        Me.TxtWbhl03.DataBindings.Add("Text", rcDataView, "wbhl03")
        Me.TxtWbhl04.DataBindings.Add("Text", rcDataView, "wbhl04")
        Me.TxtWbhl05.DataBindings.Add("Text", rcDataView, "wbhl05")
        Me.TxtWbhl06.DataBindings.Add("Text", rcDataView, "wbhl06")
        Me.TxtWbhl07.DataBindings.Add("Text", rcDataView, "wbhl07")
        Me.TxtWbhl08.DataBindings.Add("Text", rcDataView, "wbhl08")
        Me.TxtWbhl09.DataBindings.Add("Text", rcDataView, "wbhl09")
        Me.TxtWbhl10.DataBindings.Add("Text", rcDataView, "wbhl10")
        Me.TxtWbhl11.DataBindings.Add("Text", rcDataView, "wbhl11")
        Me.TxtWbhl12.DataBindings.Add("Text", rcDataView, "wbhl12")
        Me.TxtYwftzbl.DataBindings.Add("Text", rcDataView, "ywftzbl")
        BindingContext(rcDataView, "").Position = currentPos
        SetAll(True)
        If isAdding Then
            '清除当前编辑内容
            BindingContext(rcDataView, "").EndCurrentEdit()
            '增加一行
            BindingContext(rcDataView, "").AddNew()
        Else
            Me.TxtWbdm.Enabled = False
        End If
    End Sub

#End Region

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtWbdm.KeyPress, TxtWbmc.KeyPress, TxtWbsm.KeyPress, TxtWbhl01.KeyPress, TxtWbhl02.KeyPress, TxtWbhl03.KeyPress, TxtWbhl04.KeyPress, TxtWbhl05.KeyPress, TxtWbhl06.KeyPress, TxtWbhl07.KeyPress, TxtWbhl08.KeyPress, TxtWbhl09.KeyPress, TxtWbhl10.KeyPress, TxtWbhl11.KeyPress, TxtWbhl12.KeyPress, TxtYwftzbl.KeyPress
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
            Me.TxtWbdm.Enabled = False
            Me.TxtWbmc.Enabled = False
            Me.TxtWbsm.Enabled = False
            Me.TxtWbhl01.Enabled = False
            Me.TxtWbhl02.Enabled = False
            Me.TxtWbhl03.Enabled = False
            Me.TxtWbhl04.Enabled = False
            Me.TxtWbhl05.Enabled = False
            Me.TxtWbhl06.Enabled = False
            Me.TxtWbhl07.Enabled = False
            Me.TxtWbhl08.Enabled = False
            Me.TxtWbhl09.Enabled = False
            Me.TxtWbhl10.Enabled = False
            Me.TxtWbhl11.Enabled = False
            Me.TxtWbhl12.Enabled = False
            Me.txtYwftzbl.Enabled = False
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
            Me.TxtWbdm.Enabled = True
            Me.TxtWbmc.Enabled = True
            Me.TxtWbsm.Enabled = True
            Me.TxtWbhl01.Enabled = True
            Me.TxtWbhl02.Enabled = True
            Me.TxtWbhl03.Enabled = True
            Me.TxtWbhl04.Enabled = True
            Me.TxtWbhl05.Enabled = True
            Me.TxtWbhl06.Enabled = True
            Me.TxtWbhl07.Enabled = True
            Me.TxtWbhl08.Enabled = True
            Me.TxtWbhl09.Enabled = True
            Me.TxtWbhl10.Enabled = True
            Me.TxtWbhl11.Enabled = True
            Me.TxtWbhl12.Enabled = True
            Me.TxtYwftzbl.Enabled = True
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
            Me.TxtWbdm.Focus()
        End If
    End Sub

#End Region

#Region "币种名称事件"

    Private Sub TxtWbmc_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtWbmc.Validating
        Me.TxtWbsm.Text = Trim(Mid(GetChineseSpell(Me.TxtWbmc.Text), 1, 12))
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
        Me.TxtWbdm.Enabled = False
    End Sub

#End Region

#Region "保存"

    Private Sub TsSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MnuiSave.Click
        SaveEvent()
    End Sub

    Private Sub SaveEvent()
        '保存
        If isAdding Then
            If String.IsNullOrEmpty(Me.TxtWbdm.Text) Then
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
                rcOleDbCommand.CommandText = "INSERT INTO rc_wbxx (kjnd,wbdm,wbmc,wbsm,wbhl01,wbhl02,wbhl03,wbhl04,wbhl05,wbhl06,wbhl07,wbhl08,wbhl09,wbhl10,wbhl11,wbhl12,ywftzbl) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
                rcOleDbCommand.Parameters.Add("@wbdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtWbdm.Text)
                rcOleDbCommand.Parameters.Add("@wbmc", OleDbType.VarChar, 30).Value = Trim(Me.TxtWbmc.Text)
                rcOleDbCommand.Parameters.Add("@wbsm", OleDbType.VarChar, 12).Value = Trim(Me.TxtWbsm.Text)
                rcOleDbCommand.Parameters.Add("@wbhl01", OleDbType.Numeric, 18).Value = Me.TxtWbhl01.Text
                rcOleDbCommand.Parameters.Add("@wbhl02", OleDbType.Numeric, 18).Value = Me.TxtWbhl02.Text
                rcOleDbCommand.Parameters.Add("@wbhl03", OleDbType.Numeric, 18).Value = Me.TxtWbhl03.Text
                rcOleDbCommand.Parameters.Add("@wbhl04", OleDbType.Numeric, 18).Value = Me.TxtWbhl04.Text
                rcOleDbCommand.Parameters.Add("@wbhl05", OleDbType.Numeric, 18).Value = Me.TxtWbhl05.Text
                rcOleDbCommand.Parameters.Add("@wbhl06", OleDbType.Numeric, 18).Value = Me.TxtWbhl06.Text
                rcOleDbCommand.Parameters.Add("@wbhl07", OleDbType.Numeric, 18).Value = Me.TxtWbhl07.Text
                rcOleDbCommand.Parameters.Add("@wbhl08", OleDbType.Numeric, 18).Value = Me.TxtWbhl08.Text
                rcOleDbCommand.Parameters.Add("@wbhl09", OleDbType.Numeric, 18).Value = Me.TxtWbhl09.Text
                rcOleDbCommand.Parameters.Add("@wbhl10", OleDbType.Numeric, 18).Value = Me.TxtWbhl10.Text
                rcOleDbCommand.Parameters.Add("@wbhl11", OleDbType.Numeric, 18).Value = Me.TxtWbhl11.Text
                rcOleDbCommand.Parameters.Add("@wbhl12", OleDbType.Numeric, 18).Value = Me.TxtWbhl12.Text
                rcOleDbCommand.Parameters.Add("@ywftzbl", OleDbType.Numeric, 18).Value = Me.TxtYwftzbl.Text
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "SELECT wbdm,wbmc,wbsm,wbhl01,wbhl02,wbhl03,wbhl04,wbhl05,wbhl06,wbhl07,wbhl08,wbhl09,wbhl10,wbhl11,wbhl12,ywftzbl FROM rc_wbxx WHERE kjnd = ? ORDER BY wbdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_wbxx") IsNot Nothing Then
                    rcDataset.Tables("rc_wbxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_wbxx")
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
                rcOleDbCommand.CommandText = "UPDATE rc_wbxx SET wbmc = ?,wbsm = ?,wbhl01 = ?,wbhl02 = ?,wbhl03 = ?,wbhl04 = ?,wbhl05 = ?,wbhl06 = ?,wbhl07 = ?,wbhl08 = ?,wbhl09 = ?,wbhl10 = ?,wbhl11 = ?,wbhl12 = ?,ywftzbl = ?  WHERE  kjnd = ? AND wbdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@wbmc", OleDbType.VarChar, 30).Value = Trim(TxtWbmc.Text)
                rcOleDbCommand.Parameters.Add("@wbsm", OleDbType.VarChar, 12).Value = Trim(TxtWbsm.Text)
                rcOleDbCommand.Parameters.Add("@wbhl01", OleDbType.Numeric, 18).Value = Me.TxtWbhl01.Text
                rcOleDbCommand.Parameters.Add("@wbhl02", OleDbType.Numeric, 18).Value = Me.TxtWbhl02.Text
                rcOleDbCommand.Parameters.Add("@wbhl03", OleDbType.Numeric, 18).Value = Me.TxtWbhl03.Text
                rcOleDbCommand.Parameters.Add("@wbhl04", OleDbType.Numeric, 18).Value = Me.TxtWbhl04.Text
                rcOleDbCommand.Parameters.Add("@wbhl05", OleDbType.Numeric, 18).Value = Me.TxtWbhl05.Text
                rcOleDbCommand.Parameters.Add("@wbhl06", OleDbType.Numeric, 18).Value = Me.TxtWbhl06.Text
                rcOleDbCommand.Parameters.Add("@wbhl07", OleDbType.Numeric, 18).Value = Me.TxtWbhl07.Text
                rcOleDbCommand.Parameters.Add("@wbhl08", OleDbType.Numeric, 18).Value = Me.TxtWbhl08.Text
                rcOleDbCommand.Parameters.Add("@wbhl09", OleDbType.Numeric, 18).Value = Me.TxtWbhl09.Text
                rcOleDbCommand.Parameters.Add("@wbhl10", OleDbType.Numeric, 18).Value = Me.TxtWbhl10.Text
                rcOleDbCommand.Parameters.Add("@wbhl11", OleDbType.Numeric, 18).Value = Me.TxtWbhl11.Text
                rcOleDbCommand.Parameters.Add("@wbhl12", OleDbType.Numeric, 18).Value = Me.TxtWbhl12.Text
                rcOleDbCommand.Parameters.Add("@ywftzbl", OleDbType.Numeric, 18).Value = Me.TxtYwftzbl.Text
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
                rcOleDbCommand.Parameters.Add("@wbdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtWbdm.Text)
                rcOleDbCommand.ExecuteNonQuery()
                '填充数据
                rcOleDbCommand.CommandText = "SELECT wbdm,wbmc,wbsm,wbhl01,wbhl02,wbhl03,wbhl04,wbhl05,wbhl06,wbhl07,wbhl08,wbhl09,wbhl10,wbhl11,wbhl12,ywftzbl FROM rc_wbxx WHERE kjnd = ? ORDER BY wbdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_wbxx") IsNot Nothing Then
                    rcDataset.Tables("rc_wbxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_wbxx")
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
            rcOleDbCommand.CommandText = "SELECT wbdm,wbmc,wbsm,wbhl01,wbhl02,wbhl03,wbhl04,wbhl05,wbhl06,wbhl07,wbhl08,wbhl09,wbhl10,wbhl11,wbhl12,ywftzbl FROM rc_wbxx WHERE kjnd = ? ORDER BY wbdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_wbxx") IsNot Nothing Then
                rcDataset.Tables("rc_wbxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_wbxx")
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