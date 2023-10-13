Imports System.Data.OleDb

Public Class FrmKhEdit

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

    Private Sub FrmKhEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.TxtLbdm.DataBindings.Add("Text", rcDataView, "lbdm")
        Me.LblLbmc.DataBindings.Add("Text", rcDataView, "lbmc")
        Me.TxtKhdm.DataBindings.Add("Text", rcDataView, "khdm")
        Me.TxtKhmc.DataBindings.Add("Text", rcDataView, "khmc")
        Me.TxtKhsm.DataBindings.Add("Text", rcDataView, "khsm")
        Me.TxtAddress.DataBindings.Add("Text", rcDataView, "address")
        Me.TxtWaddress.DataBindings.Add("Text", rcDataView, "waddress")
        Me.TxtKhyh.DataBindings.Add("Text", rcDataView, "khyh")
        Me.TxtYhzh.DataBindings.Add("Text", rcDataView, "yhzh")
        Me.TxtSwdjh.DataBindings.Add("Text", rcDataView, "swdjh")
        Me.TxtFddbr.DataBindings.Add("Text", rcDataView, "fddbr")
        Me.TxtGsdjh.DataBindings.Add("Text", rcDataView, "gsdjh")
        Me.TxtZczb.DataBindings.Add("Text", rcDataView, "zczb")
        Me.TxtJyfw.DataBindings.Add("Text", rcDataView, "jyfw")
        Me.TxtLxr.DataBindings.Add("Text", rcDataView, "lxr")
        Me.TxtMobile.DataBindings.Add("Text", rcDataView, "mobile")
        Me.TxtTel.DataBindings.Add("Text", rcDataView, "tel")
        Me.TxtFax.DataBindings.Add("Text", rcDataView, "fax")
        Me.TxtEmail.DataBindings.Add("Text", rcDataView, "email")
        Me.TxtZydm.DataBindings.Add("Text", rcDataView, "zydm")
        Me.LblZymc.DataBindings.Add("Text", rcDataView, "zymc")
        Me.TxtZydm2.DataBindings.Add("Text", rcDataView, "zydm2")
        Me.LblZymc2.DataBindings.Add("Text", rcDataView, "zymc2")
        Me.TxtDengJi.DataBindings.Add("Text", rcDataView, "dengji")
        Me.CmbSktj.DataBindings.Add("Text", rcDataView, "sktj")
        Me.TxtSkqx.DataBindings.Add("Text", rcDataView, "skqx")
        Me.TxtAbc.DataBindings.Add("Text", rcDataView, "abc")
        Me.TxtZtts.DataBindings.Add("Text", rcDataView, "ztts")
        Me.TxtBjtk.DataBindings.Add("Text", rcDataView, "bjtk")
        Me.TxtXslbdm.DataBindings.Add("Text", rcDataView, "xslbdm")
        Me.TxtDjYear.DataBindings.Add("Text", rcDataView, "djyear")
        Me.ChbBJsywf.DataBindings.Add("Checked", rcDataView, "bjsywf")
        Me.ChbBYwfjszz.DataBindings.Add("Checked", rcDataView, "bywfjszz")
        Me.ChbBGuaKao.DataBindings.Add("Checked", rcDataView, "bguakao")
        BindingContext(rcDataView, "").Position = currentPos
        SetAll(True)
        If isAdding Then
            '清除当前编辑内容
            BindingContext(rcDataView, "").EndCurrentEdit()
            '增加一行
            BindingContext(rcDataView, "").AddNew()
        Else
            Me.TxtKhdm.Enabled = False
        End If
    End Sub

#End Region

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLbdm.KeyPress, TxtKhdm.KeyPress, TxtKhmc.KeyPress, TxtKhsm.KeyPress, TxtAddress.KeyPress, TxtPostCode.KeyPress, TxtWaddress.KeyPress, TxtKhyh.KeyPress, TxtYhzh.KeyPress, TxtSwdjh.KeyPress, TxtFddbr.KeyPress, TxtGsdjh.KeyPress, TxtZczb.KeyPress, TxtJyfw.KeyPress, TxtLxr.KeyPress, TxtMobile.KeyPress, TxtTel.KeyPress, TxtFax.KeyPress, TxtEmail.KeyPress, TxtZydm.KeyPress, TxtZydm2.KeyPress, CmbSktj.KeyPress, TxtSkqx.KeyPress, TxtAbc.KeyPress, TxtDengJi.KeyPress, TxtZtts.KeyPress, TxtBjtk.KeyPress, TxtXslbdm.KeyPress, TxtDjYear.KeyPress, ChbBJsywf.KeyPress, ChbBYwfjszz.KeyPress, ChbBGuaKao.KeyPress
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
            Me.TxtLbdm.Enabled = False
            Me.TxtKhdm.Enabled = False
            Me.TxtKhmc.Enabled = False
            Me.TxtKhsm.Enabled = False
            Me.TxtAddress.Enabled = False
            Me.TxtPostCode.Enabled = False
            Me.TxtWaddress.Enabled = False
            Me.TxtKhyh.Enabled = False
            Me.TxtYhzh.Enabled = False
            Me.TxtSwdjh.Enabled = False
            Me.TxtFddbr.Enabled = False
            Me.TxtGsdjh.Enabled = False
            Me.TxtZczb.Enabled = False
            Me.TxtJyfw.Enabled = False
            Me.TxtLxr.Enabled = False
            Me.TxtMobile.Enabled = False
            Me.TxtTel.Enabled = False
            Me.TxtFax.Enabled = False
            Me.TxtEmail.Enabled = False
            Me.TxtZydm.Enabled = False
            Me.TxtZydm2.Enabled = False
            Me.CmbSktj.Enabled = False
            Me.TxtSkqx.Enabled = False
            Me.TxtAbc.Enabled = False
            Me.TxtDengJi.Enabled = False
            Me.TxtZtts.Enabled = False
            Me.TxtBjtk.Enabled = False
            Me.TxtXslbdm.Enabled = False
            Me.TxtDjYear.Enabled = False
            Me.ChbBJsywf.Enabled = False
            Me.ChbBYwfjszz.Enabled = False
            Me.ChbBGuaKao.Enabled = False
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
            Me.TxtLbdm.Enabled = True
            Me.TxtKhdm.Enabled = True
            Me.TxtKhmc.Enabled = True
            Me.TxtKhsm.Enabled = True
            Me.TxtAddress.Enabled = True
            Me.TxtPostCode.Enabled = True
            Me.TxtWaddress.Enabled = True
            Me.TxtKhyh.Enabled = True
            Me.TxtYhzh.Enabled = True
            Me.TxtSwdjh.Enabled = True
            Me.TxtFddbr.Enabled = True
            Me.TxtGsdjh.Enabled = True
            Me.TxtZczb.Enabled = True
            Me.TxtJyfw.Enabled = True
            Me.TxtLxr.Enabled = True
            Me.TxtMobile.Enabled = True
            Me.TxtTel.Enabled = True
            Me.TxtFax.Enabled = True
            Me.TxtEmail.Enabled = True
            Me.TxtZydm.Enabled = True
            Me.TxtZydm2.Enabled = True
            Me.CmbSktj.Enabled = True
            Me.TxtSkqx.Enabled = True
            Me.TxtAbc.Enabled = True
            Me.TxtDengJi.Enabled = True
            Me.TxtZtts.Enabled = True
            Me.TxtBjtk.Enabled = True
            Me.TxtXslbdm.Enabled = True
            Me.TxtDjYear.Enabled = True
            Me.ChbBJsywf.Enabled = True
            Me.ChbBYwfjszz.Enabled = True
            Me.ChbBGuaKao.Enabled = True
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
            Me.TxtKhdm.Focus()
        End If
    End Sub

#End Region

#Region "客户类别编码的事件"

    Private Sub Txtlbdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLbdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .ParaOleDbConn = rcOleDbConn
                    .ParaTableName = "rc_khlb"
                    .ParaField1 = "lbdm"
                    .ParaField2 = "lbmc"
                    .ParaField3 = "lbsm"
                    .ParaTitle = "客户类别"
                    .ParaOldValue = ""
                    .ParaAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtLbdm.Text = Trim(.ParaField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub Txtlbdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtLbdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtLbdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_khlb WHERE (lbdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = Trim(TxtLbdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_khlb") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_khlb").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_khlb")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_khlb").Rows.Count > 0 Then
                TxtLbdm.Text = Trim(rcDataset.Tables("rc_khlb").Rows(0).Item("lbdm"))
                LblLbmc.Text = Trim(rcDataset.Tables("rc_khlb").Rows(0).Item("lbmc"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "客户销售类别编码的事件"

    Private Sub TxtXslbdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtXslbdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .ParaOleDbConn = rcOleDbConn
                    .ParaTableName = "rc_khxslb"
                    .ParaField1 = "xslbdm"
                    .ParaField2 = "xslbmc"
                    .ParaField3 = "xslbsm"
                    .ParaTitle = "客户销售类别"
                    .ParaOldValue = ""
                    .ParaAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtXslbdm.Text = Trim(.ParaField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtXslbdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtXslbdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtXslbdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_khxslb WHERE (xslbdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@xslbdm", OleDbType.VarChar, 12).Value = Trim(TxtXslbdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_khxslb") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_khxslb").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_khxslb")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_khxslb").Rows.Count > 0 Then
                TxtXslbdm.Text = Trim(rcDataset.Tables("rc_khxslb").Rows(0).Item("xslbdm"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "自动编码"

    Private Sub BtnAutoKhdm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAutoKhdm.Click
        If Not String.IsNullOrEmpty(Me.TxtLbdm.Text) And Me.TxtLbdm.Text.Length = 2 And Me.TxtKhdm.Enabled Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT Max(khdm) As khdm FROM rc_khxx WHERE lbdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = Trim(TxtLbdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("autokhdm") IsNot Nothing Then
                    rcDataset.Tables("autokhdm").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "autokhdm")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("autokhdm").Rows.Count > 0 Then
                If rcDataset.Tables("autokhdm").Rows(0).Item("khdm").GetType().ToString <> "System.DBNull" Then
                    If Trim(rcDataset.Tables("autokhdm").Rows(0).Item("khdm")).Length = 5 Then
                        Me.TxtKhdm.Text = Trim(Me.TxtLbdm.Text) & (Val(Mid(rcDataset.Tables("autokhdm").Rows(0).Item("khdm"), 3, 3)) + 1).ToString.PadLeft(3, "0")
                    End If
                End If
            End If
            If String.IsNullOrEmpty(Me.TxtKhdm.Text) Then
                Me.TxtKhdm.Text = Trim(Me.TxtLbdm.Text) & "001"
            End If
        End If
    End Sub

#End Region

#Region "客户姓名事件"

    Private Sub TxtKhmc_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtKhmc.Validating
        Me.TxtKhsm.Text = Trim(Mid(GetChineseSpell(Me.TxtKhmc.Text), 1, 12))
    End Sub

#End Region

#Region "职员编码的事件"

    Private Sub TxtZydm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtZydm.KeyDown, TxtZydm2.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .ParaOleDbConn = rcOleDbConn
                    .ParaTableName = "rc_zyxx"
                    .ParaField1 = "zydm"
                    .ParaField2 = "zymc"
                    .ParaField3 = "zysm"
                    .ParaTitle = "职员"
                    .ParaOldValue = ""
                    .ParaAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        sender.Text = Trim(.ParaField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtZydm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtZydm.Validating
        If Not String.IsNullOrEmpty(Me.TxtZydm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_zyxx WHERE (zydm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(TxtZydm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_zyxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_zyxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_zyxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_zyxx").Rows.Count > 0 Then
                TxtZydm.Text = Trim(rcDataset.Tables("rc_zyxx").Rows(0).Item("zydm"))
                LblZymc.Text = Trim(rcDataset.Tables("rc_zyxx").Rows(0).Item("zymc"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub TxtZydm2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtZydm2.Validating
        If Not String.IsNullOrEmpty(Me.TxtZydm2.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_zyxx WHERE (zydm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(TxtZydm2.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_zyxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_zyxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_zyxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_zyxx").Rows.Count > 0 Then
                TxtZydm2.Text = Trim(rcDataset.Tables("rc_zyxx").Rows(0).Item("zydm"))
                LblZymc2.Text = Trim(rcDataset.Tables("rc_zyxx").Rows(0).Item("zymc"))
            Else
                e.Cancel = True
            End If
        End If
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
        Me.TxtKhdm.Enabled = False
    End Sub

#End Region

#Region "保存"

    Private Sub TsSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MnuiSave.Click
        SaveEvent()
    End Sub

    Private Sub SaveEvent()
        Me.TabControl1.SelectedIndex = 1
        Me.TabControl1.SelectedIndex = 0
        '验证数据
        If Not String.IsNullOrEmpty(Me.TxtZydm.Text) Then
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "SELECT * FROM rc_zyxx WHERE (zydm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(TxtZydm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_zyxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_zyxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_zyxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_zyxx").Rows.Count > 0 Then
                Me.TxtZydm.Text = rcDataset.Tables("rc_zyxx").Rows(0).Item("zydm")
                Me.LblZymc.Text = rcDataset.Tables("rc_zyxx").Rows(0).Item("zymc")
            Else
                MsgBox("职员信息不正确。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
                Return
            End If
        Else
            MsgBox("请输入职员信息。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        If Not String.IsNullOrEmpty(Me.TxtZydm2.Text) Then
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "SELECT * FROM rc_zyxx WHERE (zydm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(Me.TxtZydm2.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_zyxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_zyxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_zyxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_zyxx").Rows.Count > 0 Then
                Me.TxtZydm2.Text = rcDataset.Tables("rc_zyxx").Rows(0).Item("zydm")
                Me.LblZymc2.Text = rcDataset.Tables("rc_zyxx").Rows(0).Item("zymc")
            Else
                MsgBox("职员信息不正确。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
                Return
            End If
        End If
        '保存
        If isAdding Then
            If Trim(TxtKhdm.Text).Length = 0 Then
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
                rcOleDbCommand.CommandText = "Insert Into rc_khxx (lbdm,lbmc,khdm,khmc,khsm,address,waddress,khyh,yhzh,swdjh,fddbr,gsdjh,zczb,jyfw,lxr,mobile,tel,fax,email,zydm,zymc,zydm2,zymc2,dengji,sktj,skqx,abc,ztts,bjtk,xslbdm,djyear,bjsywf,bywfjszz,bguakao) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = Trim(TxtLbdm.Text)
                rcOleDbCommand.Parameters.Add("@lbmc", OleDbType.VarChar, 30).Value = Trim(LblLbmc.Text)
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(TxtKhdm.Text)
                rcOleDbCommand.Parameters.Add("@khmc", OleDbType.VarChar, 50).Value = Trim(TxtKhmc.Text)
                rcOleDbCommand.Parameters.Add("@khsm", OleDbType.VarChar, 12).Value = Trim(TxtKhsm.Text)
                rcOleDbCommand.Parameters.Add("@address", OleDbType.VarChar, 50).Value = Trim(TxtAddress.Text)
                rcOleDbCommand.Parameters.Add("@waddress", OleDbType.VarChar, 50).Value = Trim(TxtWaddress.Text)
                rcOleDbCommand.Parameters.Add("@khyh", OleDbType.VarChar, 40).Value = Trim(TxtKhyh.Text)
                rcOleDbCommand.Parameters.Add("@yhzh", OleDbType.VarChar, 25).Value = Trim(TxtYhzh.Text)
                rcOleDbCommand.Parameters.Add("@swdjh", OleDbType.VarChar, 20).Value = Trim(TxtSwdjh.Text)
                rcOleDbCommand.Parameters.Add("@fddbr", OleDbType.VarChar, 30).Value = Trim(TxtFddbr.Text)
                rcOleDbCommand.Parameters.Add("@gsdjh", OleDbType.VarChar, 20).Value = Trim(TxtGsdjh.Text)
                rcOleDbCommand.Parameters.Add("@zczb", OleDbType.Integer, 4).Value = IIf(String.IsNullOrEmpty(Me.TxtZczb.Text), 0, Me.TxtZczb.Text)
                rcOleDbCommand.Parameters.Add("@jyfw", OleDbType.VarChar, 200).Value = Trim(TxtJyfw.Text)
                rcOleDbCommand.Parameters.Add("@lxr", OleDbType.VarChar, 20).Value = Trim(TxtLxr.Text)
                rcOleDbCommand.Parameters.Add("@mobile", OleDbType.VarChar, 12).Value = Trim(TxtMobile.Text)
                rcOleDbCommand.Parameters.Add("@tel", OleDbType.VarChar, 40).Value = Trim(TxtTel.Text)
                rcOleDbCommand.Parameters.Add("@fax", OleDbType.VarChar, 20).Value = Trim(TxtFax.Text)
                rcOleDbCommand.Parameters.Add("@email", OleDbType.VarChar, 30).Value = Trim(TxtEmail.Text)
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(Me.TxtZydm.Text)
                rcOleDbCommand.Parameters.Add("@zymc", OleDbType.VarChar, 30).Value = Trim(Me.LblZymc.Text)
                rcOleDbCommand.Parameters.Add("@zydm2", OleDbType.VarChar, 12).Value = Me.TxtZydm2.Text
                rcOleDbCommand.Parameters.Add("@zymc2", OleDbType.VarChar, 30).Value = Me.LblZymc2.Text
                rcOleDbCommand.Parameters.Add("@dengji", OleDbType.VarChar, 10).Value = Me.TxtDengJi.Text
                rcOleDbCommand.Parameters.Add("@sktj", OleDbType.VarChar, 10).Value = Trim(Me.CmbSktj.SelectedItem)
                rcOleDbCommand.Parameters.Add("@skqx", OleDbType.Integer, 4).Value = Me.TxtSkqx.Text
                rcOleDbCommand.Parameters.Add("@abc", OleDbType.VarChar, 1).Value = Me.TxtAbc.Text
                rcOleDbCommand.Parameters.Add("@ztts", OleDbType.Integer, 4).Value = Me.TxtZtts.Text
                rcOleDbCommand.Parameters.Add("@bjtk", OleDbType.VarChar, 300).Value = Me.TxtBjtk.Text
                rcOleDbCommand.Parameters.Add("@xslbdm", OleDbType.VarChar, 12).Value = Me.TxtXslbdm.Text
                rcOleDbCommand.Parameters.Add("@djyear", OleDbType.Integer, 4).Value = IIf(String.IsNullOrEmpty(Me.TxtDjYear.Text), 0, Me.TxtDjYear.Text)
                rcOleDbCommand.Parameters.Add("@bjsywf", OleDbType.Integer, 1).Value = IIf(Me.ChbBJsywf.Checked, 1, 0)
                rcOleDbCommand.Parameters.Add("@bywfjszz", OleDbType.Integer, 1).Value = IIf(Me.ChbBYwfjszz.Checked, 1, 0)
                rcOleDbCommand.Parameters.Add("@bguakao", OleDbType.Integer, 1).Value = IIf(Me.ChbBGuaKao.Checked, 1, 0)
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "SELECT lbdm,lbmc,khdm,khmc,khsm,address,postcode,waddress,khyh,yhzh,swdjh,fddbr,gsdjh,NVL(zczb,0) AS zczb,jyfw,lxr,mobile,tel,fax,email,zydm,zymc,zydm2,zymc2,dengji,sktj,NVL(skqx,0) AS skqx,abc,NVL(ztts,0) AS ztts,bjtk,xslbdm,djyear,NVL(bjsywf,1) AS bjsywf,NVL(bywfjszz,0) AS bywfjszz,NVL(bguakao,0) AS bguakao,djrq FROM rc_khxx ORDER BY khdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_khxx") IsNot Nothing Then
                    rcDataset.Tables("rc_khxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_khxx")
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
                rcOleDbCommand.CommandText = "UPDATE rc_khxx SET lbdm = ?,lbmc = ?,khmc = ?, khsm = ?,address = ?,waddress = ?,khyh = ?,yhzh=?, swdjh = ?,fddbr = ?,gsdjh = ?,zczb = ?,jyfw = ?,lxr = ?,mobile = ?,tel = ?,fax = ? ,email = ?,zydm= ?,zymc = ?,zydm2 = ?,zymc2 = ?,dengji = ?,sktj = ?,skqx = ?,abc = ?,ztts = ?,bjtk = ?,xslbdm = ?,djyear = ?,bjsywf = ?,bywfjszz = ?,bguakao = ? WHERE  khdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = Trim(TxtLbdm.Text)
                rcOleDbCommand.Parameters.Add("@lbmc", OleDbType.VarChar, 30).Value = Trim(LblLbmc.Text)
                rcOleDbCommand.Parameters.Add("@khmc", OleDbType.VarChar, 30).Value = Trim(TxtKhmc.Text)
                rcOleDbCommand.Parameters.Add("@khsm", OleDbType.VarChar, 12).Value = Trim(TxtKhsm.Text)
                rcOleDbCommand.Parameters.Add("@address", OleDbType.VarChar, 50).Value = Trim(TxtAddress.Text)
                rcOleDbCommand.Parameters.Add("@waddress", OleDbType.VarChar, 50).Value = Trim(TxtWaddress.Text)
                rcOleDbCommand.Parameters.Add("@khyh", OleDbType.VarChar, 40).Value = Trim(TxtKhyh.Text)
                rcOleDbCommand.Parameters.Add("@yhzh", OleDbType.VarChar, 25).Value = Trim(TxtYhzh.Text)
                rcOleDbCommand.Parameters.Add("@swdjh", OleDbType.VarChar, 20).Value = Trim(TxtSwdjh.Text)
                rcOleDbCommand.Parameters.Add("@fddbr", OleDbType.VarChar, 30).Value = Trim(TxtFddbr.Text)
                rcOleDbCommand.Parameters.Add("@gsdjh", OleDbType.VarChar, 20).Value = Trim(TxtGsdjh.Text)
                rcOleDbCommand.Parameters.Add("@zczb", OleDbType.Integer, 4).Value = IIf(String.IsNullOrEmpty(Me.TxtZczb.Text), 0, Me.TxtZczb.Text)
                rcOleDbCommand.Parameters.Add("@jyfw", OleDbType.VarChar, 200).Value = Trim(TxtJyfw.Text)
                rcOleDbCommand.Parameters.Add("@lxr", OleDbType.VarChar, 20).Value = Trim(TxtLxr.Text)
                rcOleDbCommand.Parameters.Add("@mobile", OleDbType.VarChar, 12).Value = Trim(TxtMobile.Text)
                rcOleDbCommand.Parameters.Add("@tel", OleDbType.VarChar, 40).Value = Trim(TxtTel.Text)
                rcOleDbCommand.Parameters.Add("@fax", OleDbType.VarChar, 20).Value = Trim(TxtFax.Text)
                rcOleDbCommand.Parameters.Add("@email", OleDbType.VarChar, 30).Value = Trim(TxtEmail.Text)
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(TxtZydm.Text)
                rcOleDbCommand.Parameters.Add("@zymc", OleDbType.VarChar, 30).Value = Trim(LblZymc.Text)
                rcOleDbCommand.Parameters.Add("@zydm2", OleDbType.VarChar, 12).Value = Me.TxtZydm2.Text
                rcOleDbCommand.Parameters.Add("@zymc2", OleDbType.VarChar, 30).Value = Me.LblZymc2.Text
                rcOleDbCommand.Parameters.Add("@dengji", OleDbType.VarChar, 10).Value = Me.TxtDengJi.Text
                rcOleDbCommand.Parameters.Add("@sktj", OleDbType.VarChar, 10).Value = Trim(Me.CmbSktj.SelectedItem)
                rcOleDbCommand.Parameters.Add("@skqx", OleDbType.Integer, 4).Value = Me.TxtSkqx.Text
                rcOleDbCommand.Parameters.Add("@abc", OleDbType.VarChar, 1).Value = Me.TxtAbc.Text
                rcOleDbCommand.Parameters.Add("@ztts", OleDbType.Integer, 4).Value = Me.TxtZtts.Text
                rcOleDbCommand.Parameters.Add("@bjtk", OleDbType.VarChar, 300).Value = Me.TxtBjtk.Text
                rcOleDbCommand.Parameters.Add("@xslbdm", OleDbType.VarChar, 300).Value = Me.TxtXslbdm.Text
                rcOleDbCommand.Parameters.Add("@djyear", OleDbType.Integer, 4).Value = IIf(String.IsNullOrEmpty(Me.TxtDjYear.Text), 0, Me.TxtDjYear.Text)
                rcOleDbCommand.Parameters.Add("@bjsywf", OleDbType.Integer, 1).Value = IIf(Me.ChbBJsywf.Checked, 1, 0)
                rcOleDbCommand.Parameters.Add("@bywfjszz", OleDbType.Integer, 1).Value = IIf(Me.ChbBYwfjszz.Checked, 1, 0)
                rcOleDbCommand.Parameters.Add("@bguakao", OleDbType.Integer, 1).Value = IIf(Me.ChbBGuaKao.Checked, 1, 0)
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(TxtKhdm.Text)
                rcOleDbCommand.ExecuteNonQuery()
                '填充数据
                rcOleDbCommand.CommandText = "SELECT lbdm,lbmc,khdm,khmc,khsm,address,postcode,waddress,khyh,yhzh,swdjh,fddbr,gsdjh,NVL(zczb,0) AS zczb,jyfw,lxr,mobile,tel,fax,email,zydm,zymc,zydm2,zymc2,dengji,sktj,NVL(skqx,0) AS skqx,abc,NVL(ztts,0) AS ztts,bjtk,xslbdm,NVL(djyear,0) AS djyear,NVL(bjsywf,1) AS bjsywf,NVL(bywfjszz,0) AS bywfjszz,NVL(bguakao,0) AS bguakao,djrq FROM rc_khxx ORDER BY khdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_khxx") IsNot Nothing Then
                    rcDataset.Tables("rc_khxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_khxx")
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
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT lbdm,lbmc,khdm,khmc,khsm,address,postcode,waddress,khyh,yhzh,swdjh,fddbr,gsdjh,NVL(zczb,0) AS zczb,jyfw,lxr,mobile,tel,fax,email,zydm,zymc,zydm2,zymc2,dengji,sktj,NVL(skqx,0) AS skqx,abc,NVL(ztts,0) AS ztts,bjtk,xslbdm,NVL(djyear,0) AS djyear,NVL(bjsywf,1) AS bjsywf,NVL(bywfjszz,0) AS bywfjszz,NVL(bguakao,0) AS bguakao,djrq FROM rc_khxx ORDER BY khdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_khxx") IsNot Nothing Then
                rcDataset.Tables("rc_khxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_khxx")
            BindingContext(rcDataView, "").Position = currentPos
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
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