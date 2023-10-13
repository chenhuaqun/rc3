Imports System.Data.OleDb

Public Class FrmKhzyxx
#Region "定义变量"
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '数据更新传递
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '数据视图
    Dim rcDataView As DataView
    '新增标志
    Dim bIsAdding As Boolean = False
    '当前记录号
    Dim iCurrentPos As Integer = 0

#End Region

    Private Sub FrmKhzyxx_Load(sender As Object, e As EventArgs) Handles Me.Load
        '读取数据
        '显示等待样式鼠标
        'Cursor.Current = New Cursor(Application.StartupPath & "\" & "Wait.cur")
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT rc_khzyxx.zydm,rc_zyxx.zymc,rc_khzyxx.khdm,rc_khxx.khmc,rc_khzyxx.ksperiod,rc_khzyxx.jsperiod,rc_khzyxx.xslbdm,rc_khxslb.xslbmc FROM rc_khzyxx Left Join rc_zyxx On rc_khzyxx.zydm = rc_zyxx.zydm Left Join rc_khxx On rc_khzyxx.khdm = rc_khxx.khdm LEFT JOIN rc_khxslb on rc_khxslb.xslbdm = rc_khzyxx.xslbdm ORDER BY zydm,khdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_khzyxx") IsNot Nothing Then
                rcDataset.Tables("rc_khzyxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_khzyxx")
            rcOleDbCommand.CommandText = "SELECT ny FROM (SELECT ' ' AS ny FROM dual UNION ALL (SELECT ny FROM rc_yj)) aa ORDER BY ny"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_ksyj") IsNot Nothing Then
                rcDataset.Tables("rc_ksyj").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_ksyj")
            rcOleDbCommand.CommandText = "SELECT ny FROM (SELECT ' ' AS ny FROM dual UNION ALL (SELECT ny FROM rc_yj)) aa ORDER BY ny"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_jsyj") IsNot Nothing Then
                rcDataset.Tables("rc_jsyj").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_jsyj")

        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        rcDataView = New DataView(rcDataset.Tables("rc_khzyxx"))
        rcDataGridView.DataSource = rcDataView
        BindDropDownList(Me.CmbKsPeriod, rcDataset.Tables("rc_ksyj"), "ny")
        BindDropDownList(Me.CmbJsPeriod, rcDataset.Tables("rc_jsyj"), "ny")

        Me.TxtZydm.DataBindings.Add("Text", rcDataView, "zydm")
        Me.LblZymc.DataBindings.Add("Text", rcDataView, "zymc")
        Me.TxtKhdm.DataBindings.Add("Text", rcDataView, "khdm")
        Me.LblKhmc.DataBindings.Add("Text", rcDataView, "khmc")
        Me.CmbKsPeriod.DataBindings.Add("SelectedValue", rcDataView, "ksperiod")
        Me.CmbJsPeriod.DataBindings.Add("SelectedValue", rcDataView, "jsperiod")
        Me.TxtXslbdm.DataBindings.Add("Text", rcDataView, "xslbdm")
        Me.LblXslbmc.DataBindings.Add("Text", rcDataView, "xslbmc")

        'BindingContext(rcDataView, "").Position = currentPos
        'SetAll(True)
        'If isAdding Then
        '    '清除当前编辑内容
        '    BindingContext(rcDataView, "").EndCurrentEdit()
        '    '增加一行
        '    BindingContext(rcDataView, "").AddNew()
        'Else
        '    Me.TxtKhdm.Enabled = False
        'End If
    End Sub

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtZydm.KeyPress, TxtKhdm.KeyPress, CmbKsPeriod.KeyPress, CmbJsPeriod.KeyPress, TxtXslbdm.KeyPress
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
            Me.TxtZydm.Enabled = False
            Me.TxtKhdm.Enabled = False
            Me.CmbKsPeriod.Enabled = False
            Me.CmbJsPeriod.Enabled = False
            Me.TxtXslbdm.Enabled = False
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
            Me.TxtZydm.Enabled = True
            Me.TxtKhdm.Enabled = True
            Me.CmbKsPeriod.Enabled = True
            Me.CmbJsPeriod.Enabled = True
            Me.TxtXslbdm.Enabled = True
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
            Me.TxtZydm.Focus()
        End If
    End Sub

#End Region

#Region "职员编码的事件"

    Private Sub TxtZydm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtZydm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_zyxx"
                    .paraField1 = "zydm"
                    .paraField2 = "zymc"
                    .paraField3 = "zysm"
                    .paraTitle = "职员"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        sender.Text = Trim(.paraField1)
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
                rcOleDbCommand.CommandText = "SELECT * FROM rc_zyxx WHERE (zydm = ?) or (zymc like '%" & Me.TxtZydm.Text & "%' )"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(Me.TxtZydm.Text)
                'rcOleDbCommand.Parameters.Add("@zymc", OleDbType.VarChar, 12).Value = Trim(Me.TxtZydm.Text)
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


#End Region

#Region "客户编码事件"

    Private Sub TxtKhdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtKhdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_khxx"
                    .paraField1 = "khdm"
                    .paraField2 = "khmc"
                    .paraField3 = "khsm"
                    .paraCondition = "0=0"
                    .paraOrderField = "khmc"
                    .paraTitle = "客户"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtKhdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtKhdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtKhdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtKhdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_khxx WHERE (khdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(TxtKhdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_khxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_khxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_khxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_khxx").Rows.Count > 0 Then
                Me.TxtKhdm.Text = Trim(rcDataset.Tables("rc_khxx").Rows(0).Item("khdm"))
                Me.LblKhmc.Text = Trim(rcDataset.Tables("rc_khxx").Rows(0).Item("khmc"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "客户销售类别事件"

    Private Sub TxtXslbdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtXslbdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_khxslb"
                    .paraField1 = "xslbdm"
                    .paraField2 = "xslbmc"
                    .paraField3 = "xslbsm"
                    .paraCondition = "0=0"
                    .paraOrderField = "xslbmc"
                    .paraTitle = "客户销售类别"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtXslbdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
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
                Me.TxtXslbdm.Text = Trim(rcDataset.Tables("rc_khxslb").Rows(0).Item("xslbdm"))
                Me.LblXslbmc.Text = Trim(rcDataset.Tables("rc_khxslb").Rows(0).Item("xslbmc"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region
#Region "新增"

    Private Sub BtnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNew.Click, MnuiNew.Click
        '新增
        If Not bIsAdding Then
            bIsAdding = True
            Try
                iCurrentPos = BindingContext(rcDataView, "").Position
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
        '修改
        If bIsAdding Then
            bIsAdding = False
        End If
        Try
            iCurrentPos = BindingContext(rcDataView, "").Position
            '清除当前编辑内容
            BindingContext(rcDataView, "").EndCurrentEdit()
        Catch eEndEdit As System.Exception
            System.Windows.Forms.MessageBox.Show(eEndEdit.Message)
        End Try
        SetAll(True)
        Me.TxtZydm.Enabled = False
        Me.TxtKhdm.Enabled = False
    End Sub

#End Region

#Region "保存"

    Private Sub TsSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MnuiSave.Click
        SaveEvent()
    End Sub

    Private Sub SaveEvent()
        '验证数据
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
        If Not String.IsNullOrEmpty(Me.TxtKhdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_khxx WHERE (khdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtKhdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_khxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_khxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_khxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_khxx").Rows.Count > 0 Then
                Me.TxtKhdm.Text = rcDataset.Tables("rc_khxx").Rows(0).Item("khdm")
                Me.LblKhmc.Text = rcDataset.Tables("rc_khxx").Rows(0).Item("khmc")
            Else
                MsgBox("客户信息不正确。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
                Return
            End If
        End If
        If Not String.IsNullOrEmpty(Me.TxtXslbdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_khxslb WHERE (xslbdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@xslbdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtXslbdm.Text)
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
                Me.TxtXslbdm.Text = rcDataset.Tables("rc_khxslb").Rows(0).Item("xslbdm")
                Me.LblXslbmc.Text = rcDataset.Tables("rc_khxslb").Rows(0).Item("xslbmc")
            Else
                MsgBox("客户销售类别信息不正确。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
                Return
            End If
        End If
        '保存
        If bIsAdding Then
            If Trim(TxtZydm.Text).Length = 0 Then
                Return
            End If
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
                rcOleDbCommand.CommandText = "INSERT INTO rc_khzyxx (zydm,khdm,ksperiod,jsperiod,xslbdm) VALUES (?,?,?,?,?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(Me.TxtZydm.Text)
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtKhdm.Text)
                rcOleDbCommand.Parameters.Add("@ksperiod", OleDbType.VarChar, 6).Value = Me.CmbKsPeriod.SelectedValue
                rcOleDbCommand.Parameters.Add("@jsperiod", OleDbType.VarChar, 6).Value = Me.CmbJsPeriod.SelectedValue
                rcOleDbCommand.Parameters.Add("@xslbdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtXslbdm.Text)
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "SELECT rc_khzyxx.zydm,rc_zyxx.zymc,rc_khzyxx.khdm,rc_khxx.khmc,rc_khzyxx.ksperiod,rc_khzyxx.jsperiod,rc_khzyxx.xslbdm,rc_khxslb.xslbmc FROM rc_khzyxx Left Join rc_zyxx On rc_khzyxx.zydm = rc_zyxx.zydm Left Join rc_khxx On rc_khzyxx.khdm = rc_khxx.khdm LEFT JOIN rc_khxslb on rc_khxslb.xslbdm = rc_khzyxx.xslbdm ORDER BY zydm,khdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_khzyxx") IsNot Nothing Then
                    rcDataset.Tables("rc_khzyxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_khzyxx")
                BindingContext(rcDataView, "").Position = iCurrentPos
                rcDataGridView.Refresh()
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
            bIsAdding = False
        Else
            REM 修改账号
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "UPDATE rc_khzyxx SET ksperiod = ?,jsperiod = ?,xslbdm = ? WHERE  khdm = ? AND zydm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ksperiod", OleDbType.VarChar, 6).Value = Me.CmbKsPeriod.SelectedValue
                rcOleDbCommand.Parameters.Add("@jsperiod", OleDbType.VarChar, 6).Value = Me.CmbJsPeriod.SelectedValue
                rcOleDbCommand.Parameters.Add("@xslbdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtXslbdm.Text)
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtKhdm.Text)
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(Me.TxtZydm.Text)
                rcOleDbCommand.ExecuteNonQuery()
                '填充数据
                rcOleDbCommand.CommandText = "SELECT rc_khzyxx.zydm,rc_zyxx.zymc,rc_khzyxx.khdm,rc_khxx.khmc,rc_khzyxx.ksperiod,rc_khzyxx.jsperiod,rc_khzyxx.xslbdm,rc_khxslb.xslbmc FROM rc_khzyxx Left Join rc_zyxx On rc_khzyxx.zydm = rc_zyxx.zydm Left Join rc_khxx On rc_khzyxx.khdm = rc_khxx.khdm LEFT JOIN rc_khxslb on rc_khxslb.xslbdm = rc_khzyxx.xslbdm ORDER BY zydm,khdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_khzyxx") IsNot Nothing Then
                    rcDataset.Tables("rc_khzyxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_khzyxx")
                BindingContext(rcDataView, "").Position = iCurrentPos
                rcDataGridView.Refresh()
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
        '取消
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT rc_khzyxx.zydm,rc_zyxx.zymc,rc_khzyxx.khdm,rc_khxx.khmc,rc_khzyxx.ksperiod,rc_khzyxx.jsperiod FROM rc_khzyxx Left Join rc_zyxx On rc_khzyxx.zydm = rc_zyxx.zydm Left Join rc_khxx On rc_khzyxx.khdm = rc_khxx.khdm ORDER BY zydm,khdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_khzyxx") IsNot Nothing Then
                rcDataset.Tables("rc_khzyxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_khzyxx")
            BindingContext(rcDataView, "").Position = iCurrentPos
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        bIsAdding = False
        SetAll(False)
    End Sub

#End Region

#Region "删除"

    Private Sub BtnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, MnuiDelete.Click
        '删除
        '删除数据
        If MessageBox.Show("您真地要删除吗？" & Trim(BindingContext(rcDataView, "").Current("zydm")) & " " & Trim(BindingContext(rcDataView, "").Current("khdm")), "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then
            iCurrentPos = BindingContext(rcDataView, "").Position
            If Trim(BindingContext(rcDataView, "").Current("zydm")) = "" Or Trim(BindingContext(rcDataView, "").Current("khdm")) = "" Then
                MessageBox.Show("编码不能为空。")
                Return
            End If

            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "Delete FROM rc_khzyxx WHERE khdm = ? AND zydm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 12).Value = BindingContext(rcDataView, "").Current("khdm")
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = BindingContext(rcDataView, "").Current("zydm")
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "SELECT rc_khzyxx.zydm,rc_zyxx.zymc,rc_khzyxx.khdm,rc_khxx.khmc,rc_khzyxx.ksperiod,rc_khzyxx.jsperiod,rc_khzyxx.xslbdm,rc_khxslb.xslbmc FROM rc_khzyxx Left Join rc_zyxx On rc_khzyxx.zydm = rc_zyxx.zydm Left Join rc_khxx On rc_khzyxx.khdm = rc_khxx.khdm LEFT JOIN rc_khxslb on rc_khxslb.xslbdm = rc_khzyxx.xslbdm ORDER BY zydm,khdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_khzyxx") IsNot Nothing Then
                    rcDataset.Tables("rc_khzyxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_khzyxx")
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
            BindingContext(rcDataView, "").Position = iCurrentPos
        End If

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