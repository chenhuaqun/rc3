Imports System.IO 
Imports System.Data.OleDb

Public Class FrmZyEdit

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
    'shCommPort为串口号从0开始，dwBaudrate为波特率通常9600
    '如果寻读卡成功，返回卡片系列号dwSerialNo和制造商shManu
    'Phillips 0	Siemens 1
    Public Declare Function GetCSN Lib "READCARD.DLL" (ByVal shCommPort As Short, ByVal dwBaudrate As Integer, ByRef dwSerialNo As Integer, ByRef shManu As Short) As Short

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

    Private Sub FrmZyEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.TxtZydm.DataBindings.Add("Text", rcDataView, "zydm")
        Me.TxtZymc.DataBindings.Add("Text", rcDataView, "zymc")
        Me.TxtZysm.DataBindings.Add("Text", rcDataView, "zysm")
        Me.TxtBmdm.DataBindings.Add("Text", rcDataView, "bmdm")
        Me.LblBmmc.DataBindings.Add("Text", rcDataView, "bmmc")
        Me.TxtIcno.DataBindings.Add("Text", rcDataView, "icno")
        Me.TxtEmail.DataBindings.Add("Text", rcDataView, "email")
        BindingContext(rcDataView, "").Position = currentPos
        SetAll(True)
        If isAdding Then
            '清除当前编辑内容
            BindingContext(rcDataView, "").EndCurrentEdit()
            '增加一行
            BindingContext(rcDataView, "").AddNew()
        Else
            Me.TxtZydm.Enabled = False
        End If
        '取端口设置
        Try
            If System.IO.File.Exists(Application.StartupPath & "\" & "COMport.xml") Then
                Dim xmlCom As New System.Xml.XmlDocument
                Dim intCom As Integer = 0
                xmlCom.Load(Application.StartupPath & "\" & "COMport.xml")
                intCom = xmlCom.SelectSingleNode("COMport").InnerText
                Me.MnuiCom1.Checked = IIf(intCom = 0, True, False)
                Me.MnuiCom2.Checked = Not Me.MnuiCom1.Checked
            End If
        Catch ex As Exception
            MsgBox("请设置读卡程序商品参数。程序错误：" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End Try
    End Sub

#End Region

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtZydm.KeyPress, TxtZysm.KeyPress, TxtZymc.KeyPress, TxtBmdm.KeyPress, TxtIcno.KeyPress, TxtEmail.KeyPress
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
            Me.TxtZysm.Enabled = False
            Me.TxtZymc.Enabled = False
            Me.TxtBmdm.Enabled = False
            Me.TxtIcno.Enabled = False
            Me.TxtEmail.Enabled = False
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
            Me.TxtZydm.Enabled = True
            Me.TxtZysm.Enabled = True
            Me.TxtZymc.Enabled = True
            Me.TxtBmdm.Enabled = True
            Me.TxtIcno.Enabled = True
            Me.TxtEmail.Enabled = True
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
            Me.TxtZydm.Focus()
        End If
    End Sub

#End Region

#Region "职员姓名事件"

    Private Sub TxtZymc_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtZymc.Validating
        Me.TxtZysm.Text = Trim(Mid(GetChineseSpell(Me.TxtZymc.Text), 1, 12))
    End Sub

#End Region

#Region "部门编码的事件"

    Private Sub TxtBmdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBmdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_bmxx"
                    .paraField1 = "bmdm"
                    .paraField2 = "bmmc"
                    .paraField3 = "bmsm"
                    .paraTitle = "部门"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtBmdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtBmdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtBmdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtBmdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT bmdm,bmmc FROM rc_bmxx WHERE (bmdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(TxtBmdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_bmxx") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_bmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_bmxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_bmxx").Rows.Count > 0 Then
                TxtBmdm.Text = Trim(rcDataSet.Tables("rc_bmxx").Rows(0).Item("bmdm"))
                LblBmmc.Text = Trim(rcDataSet.Tables("rc_bmxx").Rows(0).Item("bmmc"))
            Else
                MsgBox("部门编码不存在，请按F3键选择。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                e.Cancel = True
            End If
            '检测是否最明细记录
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT COUNT(*) AS gs FROM rc_bmxx WHERE (parentid = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtBmdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("reccnt") IsNot Nothing Then
                    Me.rcDataSet.Tables("reccnt").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "reccnt")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("reccnt").Rows(0).Item("gs") > 0 Then
                MsgBox("请输入最明细部门编码。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

    Private Sub TimerReadCard_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerReadCard.Tick
        Dim shCommPort As Short = IIf(Me.MnuiCom1.Checked, 0, 1)
        Dim dwBaudrate As Integer = 9600
        Dim dwSerialNo As Integer = 0
        Dim shManu As Short = 0
        Dim mm As Short
        mm = GetCSN(shCommPort, dwBaudrate, dwSerialNo, shManu)
        If mm <> 1 Then
            Me.TxtIcno.Text = IIf(dwSerialNo < 0, 4294967296 + dwSerialNo, dwSerialNo)
            Me.TimerReadCard.Enabled = False
        End If
    End Sub

    Private Sub TxtIcno_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtIcno.LostFocus
        Me.TimerReadCard.Enabled = False
    End Sub
    
    Private Sub TxtIcno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtIcno.GotFocus
        Me.TimerReadCard.Enabled = True
    End Sub

    Private Sub TxtIcno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtIcno.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                If Me.TimerReadCard.Enabled = True Then
                    Me.TimerReadCard.Enabled = False
                Else
                    Me.TimerReadCard.Enabled = True
                End If
        End Select
    End Sub
    
    Private Sub MnuiCom1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCom1.Click
        If Not Me.MnuiCom1.Checked Then
            Me.MnuiCom1.Checked = True
            Me.MnuiCom2.Checked = False
            '保存设置
            If System.IO.File.Exists(Application.StartupPath & "\COMport.xml") Then
                System.IO.File.Delete(Application.StartupPath & "\COMport.xml")
            End If
            '写xml文件
            Dim rcStreamWriter As StreamWriter
            rcStreamWriter = File.CreateText(Application.StartupPath & "\COMport.xml")
            rcStreamWriter.WriteLine("<?xml version=""1.0"" encoding=""utf-8"" ?> ")
            rcStreamWriter.WriteLine("<COMport>" & IIf(Me.MnuiCom1.Checked, 0, 1) & "</COMport>")
            rcStreamWriter.Close()
        End If
    End Sub

    Private Sub MnuiCom2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCom2.Click
        If Not MnuiCom2.Checked Then
            Me.MnuiCom1.Checked = False
            Me.MnuiCom2.Checked = True
            '保存设置
            If System.IO.File.Exists(Application.StartupPath & "\COMport.xml") Then
                System.IO.File.Delete(Application.StartupPath & "\COMport.xml")
            End If
            '写xml文件
            Dim rcStreamWriter As StreamWriter
            rcStreamWriter = File.CreateText(Application.StartupPath & "\COMport.xml")
            rcStreamWriter.WriteLine("<?xml version=""1.0"" encoding=""utf-8"" ?> ")
            rcStreamWriter.WriteLine("<COMport>" & IIf(Me.MnuiCom2.Checked, 1, 0) & "</COMport>")
            rcStreamWriter.Close()
        End If
    End Sub

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
        Me.TxtZydm.Enabled = False
    End Sub

#End Region

#Region "保存"

    Private Sub TsSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MnuiSave.Click
        SaveEvent()
    End Sub

    Private Sub SaveEvent()
        '验证数据
        If Not String.IsNullOrEmpty(Me.TxtBmdm.Text) Then
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "SELECT * FROM rc_bmxx WHERE (bmdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(TxtBmdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_bmxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_bmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_bmxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_bmxx").Rows.Count > 0 Then
                Me.TxtBmdm.Text = rcDataset.Tables("rc_bmxx").Rows(0).Item("bmdm")
                Me.LblBmmc.Text = rcDataset.Tables("rc_bmxx").Rows(0).Item("bmmc")
            Else
                MsgBox("部门信息不正确。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
                Return
            End If
        Else
            MsgBox("请输入部门信息。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        '保存
        If isAdding Then
            If String.IsNullOrEmpty(Me.TxtZydm.Text) Then
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
                rcOleDbCommand.CommandText = "Insert Into rc_zyxx (zydm,zymc,zysm,bmdm,icno,email) VALUES (?,?,?,?,?,?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(TxtZydm.Text)
                rcOleDbCommand.Parameters.Add("@zymc", OleDbType.VarChar, 30).Value = Trim(TxtZymc.Text)
                rcOleDbCommand.Parameters.Add("@zysm", OleDbType.VarChar, 12).Value = Trim(TxtZysm.Text)
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(TxtBmdm.Text)
                rcOleDbCommand.Parameters.Add("@icno", OleDbType.VarChar, 12).Value = Trim(TxtIcno.Text)
                rcOleDbCommand.Parameters.Add("@email", OleDbType.VarChar, 50).Value = Trim(TxtEmail.Text)
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "SELECT rc_zyxx.zydm,rc_zyxx.zymc,rc_zyxx.zysm,rc_zyxx.bmdm,rc_bmxx.bmmc,rc_zyxx.icno,rc_zyxx.email FROM rc_zyxx Left Join rc_bmxx ON rc_zyxx.bmdm = rc_bmxx.bmdm ORDER BY zydm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_zyxx") IsNot Nothing Then
                    rcDataset.Tables("rc_zyxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_zyxx")
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
                rcOleDbCommand.CommandText = "UPDATE rc_zyxx SET zymc = ? , zysm = ? ,bmdm = ? ,icno = ?,email = ?  WHERE  zydm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@zymc", OleDbType.VarChar, 30).Value = Trim(TxtZymc.Text)
                rcOleDbCommand.Parameters.Add("@zysm", OleDbType.VarChar, 12).Value = Trim(TxtZysm.Text)
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(TxtBmdm.Text)
                rcOleDbCommand.Parameters.Add("@icno", OleDbType.VarChar, 12).Value = Trim(TxtIcno.Text)
                rcOleDbCommand.Parameters.Add("@email", OleDbType.VarChar, 50).Value = Trim(TxtEmail.Text)
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(Me.TxtZydm.Text)
                rcOleDbCommand.ExecuteNonQuery()
                '填充数据
                rcOleDbCommand.CommandText = "SELECT rc_zyxx.zydm,rc_zyxx.zymc,rc_zyxx.zysm,rc_zyxx.bmdm,rc_bmxx.bmmc,rc_zyxx.icno,rc_zyxx.email FROM rc_zyxx Left Join rc_bmxx On rc_zyxx.bmdm = rc_bmxx.bmdm ORDER BY zydm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_zyxx") IsNot Nothing Then
                    rcDataset.Tables("rc_zyxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_zyxx")
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
            rcOleDbCommand.CommandText = "SELECT rc_zyxx.zydm,rc_zyxx.zymc,rc_zyxx.zysm,rc_zyxx.bmdm,rc_bmxx.bmmc,rc_zyxx.icno,rc_zyxx.email FROM rc_zyxx Left Join rc_bmxx On rc_zyxx.bmdm = rc_bmxx.bmdm ORDER BY zydm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_zyxx") IsNot Nothing Then
                rcDataset.Tables("rc_zyxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_zyxx")
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