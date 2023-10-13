Imports System.Data.OleDb

Public Class FrmKmEdit

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

    Private Sub FrmKmEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.TxtKmdm.DataBindings.Add("Text", rcDataView, "kmdm")
        Me.TxtKmmc.DataBindings.Add("Text", rcDataView, "kmmc")
        Me.TxtKmsm.DataBindings.Add("Text", rcDataView, "kmsm")
        Me.TxtParentId.DataBindings.Add("Text", rcDataView, "parentid")
        Me.CmbKmxz.DataBindings.Add("SelectedValue", rcDataView, "kmxz")
        Me.CmbKmgs.DataBindings.Add("SelectedValue", rcDataView, "kmgs")
        Me.TxtKmbz.DataBindings.Add("Text", rcDataView, "kmbz")
        Me.TxtKmdw.DataBindings.Add("Text", rcDataView, "kmdw")
        Me.ChbKmbm.DataBindings.Add("Checked", rcDataView, "kmbm")
        Me.ChbKmzy.DataBindings.Add("Checked", rcDataView, "kmzy")
        Me.ChbKmxm.DataBindings.Add("Checked", rcDataView, "kmxm")
        Me.ChbKmkh.DataBindings.Add("Checked", rcDataView, "kmkh")
        Me.ChbKmcs.DataBindings.Add("Checked", rcDataView, "kmcs")
        Me.ChbKmjx.DataBindings.Add("Checked", rcDataView, "kmjx")
        Me.ChbKmyh.DataBindings.Add("Checked", rcDataView, "kmyh")
        Me.ChbKmxj.DataBindings.Add("Checked", rcDataView, "kmxj")
        BindingContext(rcDataView, "").Position = currentPos
        '取内容
        rcOleDbConn.Open()
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT * FROM gl_kmxz Order by xzdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("gl_kmxz") IsNot Nothing Then
                rcDataset.Tables("gl_kmxz").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "gl_kmxz")
            rcOleDbCommand.CommandText = "SELECT * FROM gl_kmgs Order by gsdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("gl_kmgs") IsNot Nothing Then
                rcDataset.Tables("gl_kmgs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "gl_kmgs")
        Catch ex As Exception
            MsgBox("程序错误。取gl_kmxx" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("gl_kmxz").Rows.Count > 0 Then
            BindDropDownList(Me.CmbKmxz, rcDataset.Tables("gl_kmxz"), "xzdm", "xzmc")
        End If
        If rcDataset.Tables("gl_kmgs").Rows.Count > 0 Then
            BindDropDownList(Me.CmbKmgs, rcDataset.Tables("gl_kmgs"), "gsdm", "gsmc")
        End If
        SetAll(True)
        If isAdding Then
            '清除当前编辑内容
            BindingContext(rcDataView, "").EndCurrentEdit()
            '增加一行
            BindingContext(rcDataView, "").AddNew()
        Else
            Me.TxtKmdm.Enabled = False
        End If
    End Sub

#End Region

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKmdm.KeyPress, TxtKmmc.KeyPress, TxtKmsm.KeyPress, CmbKmxz.KeyPress, CmbKmgs.KeyPress, TxtKmbz.KeyPress, TxtKmdw.KeyPress, TxtParentId.KeyPress
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
            Me.TxtKmdm.Enabled = False
            Me.TxtKmmc.Enabled = False
            Me.TxtKmsm.Enabled = False
            Me.TxtParentId.Enabled = False
            Me.CmbKmxz.Enabled = False
            Me.CmbKmgs.Enabled = False
            Me.TxtKmbz.Enabled = False
            Me.TxtKmdw.Enabled = False
            Me.ChbKmbm.Enabled = False
            Me.ChbKmzy.Enabled = False
            Me.ChbKmxm.Enabled = False
            Me.ChbKmkh.Enabled = False
            Me.ChbKmcs.Enabled = False
            Me.ChbKmjx.Enabled = False
            Me.ChbKmyh.Enabled = False
            Me.ChbKmxj.Enabled = False
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
            Me.TxtKmdm.Enabled = True
            Me.TxtKmmc.Enabled = True
            Me.TxtKmsm.Enabled = True
            Me.TxtParentId.Enabled = True
            Me.CmbKmxz.Enabled = True
            Me.CmbKmgs.Enabled = True
            Me.TxtKmbz.Enabled = True
            Me.TxtKmdw.Enabled = True
            Me.ChbKmbm.Enabled = True
            Me.ChbKmzy.Enabled = True
            Me.ChbKmxm.Enabled = True
            Me.ChbKmkh.Enabled = True
            Me.ChbKmcs.Enabled = True
            Me.ChbKmjx.Enabled = True
            Me.ChbKmyh.Enabled = True
            Me.ChbKmxj.Enabled = True
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
            Me.TxtKmdm.Focus()
        End If
    End Sub

#End Region

#Region "科目编码事件"

    Private Sub TxtKmdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtKmdm.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

#End Region

#Region "科目名称事件"

    Private Sub TxtKmmc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtKmmc.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtKmmc_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtKmmc.Validating
        Me.TxtKmsm.Text = Mid(GetChineseSpell(Me.TxtKmmc.Text), 1, Me.TxtKmsm.MaxLength)
    End Sub

#End Region

#Region "记忆码事件"

    Private Sub TxtKmsm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtKmsm.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

#End Region

#Region "上级科目事件"

    Private Sub TxtParentId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtParentId.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
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
        Me.TxtKmdm.Enabled = False
    End Sub

#End Region

#Region "保存"
    Private Sub TsSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MnuiSave.Click
        SaveEvent()
    End Sub

    Private Sub SaveEvent()
        If String.IsNullOrEmpty(Trim(Me.TxtKmdm.Text)) Then
            MsgBox("科目编码不能为空，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        If String.IsNullOrEmpty(Trim(Me.TxtKmmc.Text)) Then
            MsgBox("科目名称不能为空，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        If String.IsNullOrEmpty(Trim(Me.TxtKmbz.Text)) Then
            MsgBox("科目币种不能为空，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        '保存
        If isAdding Then
            'REM 增加保存
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "INSERT INTO gl_kmxx (kmdm,kmmc,kmsm,parentid,kmxz,kmgs,kmbz,kmdw,kmbm,kmzy,kmxm,kmkh,kmcs,kmjx,kmyh,kmxj) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKmdm.Text)
                rcOleDbCommand.Parameters.Add("@kmmc", OleDbType.VarChar, 50).Value = Trim(Me.TxtKmmc.Text)
                rcOleDbCommand.Parameters.Add("@kmsm", OleDbType.VarChar, 12).Value = Trim(Me.TxtKmsm.Text)
                rcOleDbCommand.Parameters.Add("@parentid", OleDbType.VarChar, 12).Value = Trim(Me.TxtParentId.Text)
                rcOleDbCommand.Parameters.Add("@kmxz", OleDbType.TinyInt, 1).Value = IIf(Me.CmbKmxz.SelectedIndex < 0, 0, Me.CmbKmxz.SelectedIndex)
                rcOleDbCommand.Parameters.Add("@kmgs", OleDbType.TinyInt, 1).Value = IIf(Me.CmbKmgs.SelectedIndex < 0, 0, Me.CmbKmgs.SelectedIndex)
                rcOleDbCommand.Parameters.Add("@kmbz", OleDbType.VarChar, 4).Value = Trim(Me.TxtKmbz.Text)
                rcOleDbCommand.Parameters.Add("@kmdw", OleDbType.VarChar, 4).Value = Trim(Me.TxtKmdw.Text)
                rcOleDbCommand.Parameters.Add("@kmbm", OleDbType.Numeric, 1).Value = Me.ChbKmbm.Checked
                rcOleDbCommand.Parameters.Add("@kmzy", OleDbType.Numeric, 1).Value = Me.ChbKmzy.Checked
                rcOleDbCommand.Parameters.Add("@kmxm", OleDbType.Numeric, 1).Value = Me.ChbKmxm.Checked
                rcOleDbCommand.Parameters.Add("@kmkh", OleDbType.Numeric, 1).Value = Me.ChbKmkh.Checked
                rcOleDbCommand.Parameters.Add("@kmcs", OleDbType.Numeric, 1).Value = Me.ChbKmcs.Checked
                rcOleDbCommand.Parameters.Add("@kmjx", OleDbType.Numeric, 1).Value = Me.ChbKmjx.Checked
                rcOleDbCommand.Parameters.Add("@kmyh", OleDbType.Numeric, 1).Value = Me.ChbKmyh.Checked
                rcOleDbCommand.Parameters.Add("@kmxj", OleDbType.Numeric, 1).Value = Me.ChbKmxj.Checked
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "SELECT * FROM gl_kmxx ORDER BY kmdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("gl_kmxx") IsNot Nothing Then
                    rcDataset.Tables("gl_kmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "gl_kmxx")
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
                rcOleDbConn.Close()
            End Try
            isAdding = False
        Else
            REM 修改
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "UPDATE gl_kmxx SET kmmc = ?,kmsm = ?,parentid = ?,kmxz = ?,kmgs=?,kmbz=?,kmdw=?,kmbm=?,kmzy=?,kmxm=?,kmkh=?,kmcs=?,kmjx=?,kmyh=?,kmxj=? WHERE kmdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kmmc", OleDbType.VarChar, 50).Value = Trim(Me.TxtKmmc.Text)
                rcOleDbCommand.Parameters.Add("@kmsm", OleDbType.VarChar, 12).Value = Trim(Me.TxtKmsm.Text)
                rcOleDbCommand.Parameters.Add("@parentid", OleDbType.VarChar, 12).Value = Trim(Me.TxtParentId.Text)
                rcOleDbCommand.Parameters.Add("@kmxz", OleDbType.TinyInt, 1).Value = IIf(Me.CmbKmxz.SelectedIndex < 0, 0, Me.CmbKmxz.SelectedIndex)
                rcOleDbCommand.Parameters.Add("@kmgs", OleDbType.TinyInt, 1).Value = IIf(Me.CmbKmgs.SelectedIndex < 0, 0, Me.CmbKmgs.SelectedIndex)
                rcOleDbCommand.Parameters.Add("@kmbz", OleDbType.VarChar, 4).Value = Trim(Me.TxtKmbz.Text)
                rcOleDbCommand.Parameters.Add("@kmdw", OleDbType.VarChar, 4).Value = Trim(Me.TxtKmdw.Text)
                rcOleDbCommand.Parameters.Add("@kmbm", OleDbType.Numeric, 1).Value = Me.ChbKmbm.Checked
                rcOleDbCommand.Parameters.Add("@kmzy", OleDbType.Numeric, 1).Value = Me.ChbKmzy.Checked
                rcOleDbCommand.Parameters.Add("@kmxm", OleDbType.Numeric, 1).Value = Me.ChbKmxm.Checked
                rcOleDbCommand.Parameters.Add("@kmkh", OleDbType.Numeric, 1).Value = Me.ChbKmkh.Checked
                rcOleDbCommand.Parameters.Add("@kmcs", OleDbType.Numeric, 1).Value = Me.ChbKmcs.Checked
                rcOleDbCommand.Parameters.Add("@kmjx", OleDbType.Numeric, 1).Value = Me.ChbKmjx.Checked
                rcOleDbCommand.Parameters.Add("@kmyh", OleDbType.Numeric, 1).Value = Me.ChbKmyh.Checked
                rcOleDbCommand.Parameters.Add("@kmxj", OleDbType.Numeric, 1).Value = Me.ChbKmxj.Checked
                rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKmdm.Text)
                rcOleDbCommand.ExecuteNonQuery()
                '填充数据
                rcOleDbCommand.CommandText = "SELECT * FROM gl_kmxx ORDER BY kmdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("gl_kmxx") IsNot Nothing Then
                    rcDataset.Tables("gl_kmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "gl_kmxx")
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
                rcOleDbConn.Close()
            End Try
        End If
        BindingContext(rcDataView, "").Position = currentPos
        SetAll(False)
    End Sub

#End Region

#Region "取消"

    Private Sub TsCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click, MnuiCancel.Click
        CancelEvent()
    End Sub

    Private Sub CancelEvent()
        '取消
        isAdding = False
        Try
            '清除当前编辑内容
            BindingContext(rcDataView, "").CancelCurrentEdit()
        Catch eEndEdit As System.Exception
            System.Windows.Forms.MessageBox.Show(eEndEdit.Message)
        End Try

        rcOleDbConn.Open()
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT * FROM gl_kmxx ORDER BY kmdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("gl_kmxx") IsNot Nothing Then
                rcDataset.Tables("gl_kmxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "gl_kmxx")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        'rcDataView = New DataView(rcDataset.Tables("gl_kmxx"))
        BindingContext(rcDataView, "").Position = currentPos
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