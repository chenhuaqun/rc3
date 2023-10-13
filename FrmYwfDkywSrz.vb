Imports System.Data.OleDb
Imports System.Math
Imports System.IO

Public Class FrmYwfDkywSrz
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '增加单据的变量
    Dim IsAdding As Boolean = False
    '修改单据的变量
    Dim IsEditing As Boolean = False
    '会计期间
    Dim strKjqj As String = g_Kjqj
    '年
    Dim strYear As String = ""
    '月
    Dim strMonth As String = ""
    '打印文档
    ReadOnly rcRps As RPS.Document = Nothing

#Region "初始化"

    Public Property ParaStrYear() As String
        Get
            ParaStrYear = strYear
        End Get
        Set(ByVal Value As String)
            strYear = Value
        End Set
    End Property

    Public Property ParaStrMonth() As String
        Get
            ParaStrMonth = strMonth
        End Get
        Set(ByVal Value As String)
            strMonth = Value
        End Set
    End Property

    Private Sub FrmYwfDkywSrz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '单据类型数据检测
        Dim i As Integer
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_lx WHERE pzlxdm = 'DKYW' AND kjnd = '" & strYear & "' order by pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_lx") IsNot Nothing Then
                rcDataset.Tables("rc_lx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_lx")
            If rcDataset.Tables("rc_lx").Rows.Count <= 0 Then
                rcOleDbCommand.CommandText = "Insert Into rc_lx (kjnd,pzlxdm,pzlxjc,pzlxmc,lxgs,bfushu,pzno01,pzno02,pzno03,pzno04,pzno05,pzno06,pzno07,pzno08,pzno09,pzno10,pzno11,pzno12,pzno13) VALUES ('" & strYear & "',?,?,?,?,?,0,0,0,0,0,0,0,0,0,0,0,0,0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@pzlxdm", OleDbType.VarChar, 4).Value = "DKYW"
                rcOleDbCommand.Parameters.Add("@pzlxjc", OleDbType.VarChar, 8).Value = "抵扣业务"
                rcOleDbCommand.Parameters.Add("@pzlxmc", OleDbType.VarChar, 18).Value = "抵扣业务"
                rcOleDbCommand.Parameters.Add("@lxgs", OleDbType.VarChar, 12).Value = "抵扣业务"
                rcOleDbCommand.Parameters.Add("@bfushu", OleDbType.Numeric, 1).Value = 0
                rcOleDbCommand.ExecuteNonQuery()
                '添加序列
                For i = 1 To 12
                    rcOleDbCommand.CommandText = "CREATE SEQUENCE " & "DKYW" & strYear & i.ToString.PadLeft(2, "0") & " INCREMENT BY 1 START WITH 1 MAXVALUE 99999 MINVALUE 1 NOCYCLE NOCACHE NOORDER"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Next
            End If
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误1。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
        Finally
            rcOleDbConn.Close()
        End Try

        '取单据类型数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_lx WHERE pzlxdm = 'DKYW' AND kjnd = '" & strYear & "' ORDER BY pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_lx") IsNot Nothing Then
                Me.rcDataset.Tables("rc_lx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_lx")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message)
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_lx").Rows.Count = 0 Then
            MsgBox("请定义单据类型。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        strKjqj = strYear & strMonth
        If GetInvKjqj(g_Kjrq) = strKjqj Then
            DtpDkrq.Value = g_Kjrq
        Else
            DtpDkrq.Value = GetInvEnd(strYear, strMonth)
        End If

        NewEvent()
    End Sub

#End Region

#Region "设置控件"

    Private Sub SetControlEnableEvent()
        If IsEditing = True Then
            Me.TxtDjh.Enabled = False
            Me.BtnNew.Enabled = False
            Me.BtnSave.Enabled = True
            Me.BtnCancel.Enabled = True
            Me.BtnExit.Enabled = False
            Me.MnuiNew.Enabled = False
            Me.MnuiSave.Enabled = True
            Me.MnuiCancel.Enabled = True
            Me.MnuiExit.Enabled = False
        Else
            Me.TxtDjh.Enabled = True
            Me.BtnNew.Enabled = True
            Me.BtnSave.Enabled = False
            Me.BtnCancel.Enabled = False
            Me.BtnExit.Enabled = True
            Me.MnuiNew.Enabled = True
            Me.MnuiSave.Enabled = False
            Me.MnuiCancel.Enabled = False
            Me.MnuiExit.Enabled = True
        End If
    End Sub

#End Region

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDjh.KeyPress, DtpDkrq.KeyPress, TxtKhdm.KeyPress, TxtDkgsdm.KeyPress, TxtSkje.KeyPress, TxtFyje.KeyPress, TxtDkmemo.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "单据号的事件"

    Private Sub TxtDjh_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtDjh.Validating
        If IsEditing Then
            Return
        End If
        '取单据类型数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzno" & strMonth & " As pzno FROM rc_lx WHERE kjnd = ? AND pzlxdm = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = strYear
            rcOleDbCommand.Parameters.Add("@pzlxdm", OleDbType.VarChar, 4).Value = "DKYW"
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_pzno") IsNot Nothing Then
                Me.rcDataset.Tables("rc_pzno").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_pzno")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '检查单据号是否存在
        If rcDataset.Tables("rc_pzno") Is Nothing Then
            Return
        End If
        '判断增加还是修改
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            If rcDataset.Tables("rc_pzno").Rows.Count > 0 Then
                If rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") >= Me.TxtDjh.Text Then
                    '修改单据
                    rcOleDbCommand.CommandText = "SELECT gl_ywfdkyw.djh,gl_ywfdkyw.dkrq,gl_ywfdkyw.khdm,gl_ywfdkyw.khmc,gl_ywfdkyw.dkgsdm,gl_ywfdkyw.dkgsmc,gl_ywfdkyw.skje,gl_ywfdkyw.fyje,gl_ywfdkyw.dkmemo,gl_ywfdkyw.srr,gl_ywfdkyw.srrq FROM gl_ywfdkyw WHERE (gl_ywfdkyw.djh = ? )"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = "DKYW" & strKjqj & Me.TxtDjh.Text.ToString.PadLeft(5, "0")
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("rc_rkdml") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_rkdml").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "rc_rkdml")
                    If rcDataset.Tables("rc_rkdml").Rows.Count > 0 Then
                        Me.DtpDkrq.Value = rcDataset.Tables("rc_rkdml").Rows(0).Item("dkrq")
                        If rcDataset.Tables("rc_rkdml").Rows(0).Item("khdm").GetType.ToString <> "System.DBNull" Then
                            Me.TxtKhdm.Text = rcDataset.Tables("rc_rkdml").Rows(0).Item("khdm")
                        Else
                            Me.TxtKhdm.Text = ""
                        End If
                        If rcDataset.Tables("rc_rkdml").Rows(0).Item("khmc").GetType.ToString <> "System.DBNull" Then
                            Me.LblKhmc.Text = rcDataset.Tables("rc_rkdml").Rows(0).Item("khmc")
                        Else
                            Me.LblKhmc.Text = ""
                        End If
                        If rcDataset.Tables("rc_rkdml").Rows(0).Item("dkgsdm").GetType.ToString <> "System.DBNull" Then
                            Me.TxtDkgsdm.Text = rcDataset.Tables("rc_rkdml").Rows(0).Item("dkgsdm")
                        Else
                            Me.TxtDkgsdm.Text = ""
                        End If
                        If rcDataset.Tables("rc_rkdml").Rows(0).Item("dkgsmc").GetType.ToString <> "System.DBNull" Then
                            Me.LblDkgsmc.Text = rcDataset.Tables("rc_rkdml").Rows(0).Item("dkgsmc")
                        Else
                            Me.LblDkgsmc.Text = ""
                        End If
                        If rcDataset.Tables("rc_rkdml").Rows(0).Item("skje").GetType.ToString <> "System.DBNull" Then
                            Me.TxtSkje.Text = rcDataset.Tables("rc_rkdml").Rows(0).Item("skje")
                        Else
                            Me.TxtSkje.Text = ""
                        End If
                        If rcDataset.Tables("rc_rkdml").Rows(0).Item("fyje").GetType.ToString <> "System.DBNull" Then
                            Me.TxtFyje.Text = rcDataset.Tables("rc_rkdml").Rows(0).Item("fyje")
                        Else
                            Me.TxtFyje.Text = ""
                        End If
                        If rcDataset.Tables("rc_rkdml").Rows(0).Item("dkmemo").GetType.ToString <> "System.DBNull" Then
                            Me.TxtDkmemo.Text = rcDataset.Tables("rc_rkdml").Rows(0).Item("dkmemo")
                        Else
                            Me.TxtDkmemo.Text = ""
                        End If
                        IsAdding = False
                    End If
                    'End If
                Else
                    '新增单据
                    IsAdding = True
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If IsAdding Then
            NewEvent()
        End If
        SetControlEnableEvent()
    End Sub

#End Region

#Region "抵扣日期的事件"

    Private Sub DtpDkrq_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DtpDkrq.Validating
        '检查会计期间
        Dim dateBegin As DateTime
        Dim dateEnd As DateTime
        dateBegin = GetInvBegin(strYear, strMonth)
        dateEnd = GetInvEnd(strYear, strMonth)
        If DtpDkrq.Value.Date > dateEnd Or DtpDkrq.Value.Date < dateBegin Then
            MsgBox("您输入的日期不在当前会计期间中，请重输入。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Me.DtpDkrq.Focus()
        End If
    End Sub

#End Region

#Region "客户编码的事件"

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
                    .paraTitle = "客户"
                    .paraOldValue = ""
                    .paraAddName = ""
                    .paraOrderField = "khmc"
                    If .ShowDialog = DialogResult.OK Then
                        TxtKhdm.Text = Trim(.paraField1)
                        LblKhmc.Text = Trim(.paraField2)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtKhdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtKhdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtKhdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT rc_khxx.khdm,rc_khxx.khmc FROM rc_khxx WHERE (rc_khxx.khdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtKhdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_khxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_khxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_khxx")
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_khxx").Rows.Count > 0 Then
                Me.TxtKhdm.Text = Trim(rcDataset.Tables("rc_khxx").Rows(0).Item("khdm"))
                Me.LblKhmc.Text = rcDataset.Tables("rc_khxx").Rows(0).Item("khmc")
            Else
                e.Cancel = True
            End If
            If Not IsEditing Then
                IsEditing = True
                SetControlEnableEvent()
            End If
        End If
    End Sub

#End Region

#Region "抵扣规则编码的事件"

    Private Sub TxtDkgsdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDkgsdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "gl_ywfdkgs"
                    .paraField1 = "dkgsdm"
                    .paraField2 = "dkgsmc"
                    .paraField3 = "dkgssm"
                    .paraTitle = "抵扣规则"
                    .paraOldValue = ""
                    .paraAddName = ""
                    .paraOrderField = "dkgsdm"
                    If .ShowDialog = DialogResult.OK Then
                        TxtDkgsdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtDkgsdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtDkgsdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtDkgsdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT gl_ywfdkgs.dkgsdm,gl_ywfdkgs.dkgsmc FROM gl_ywfdkgs WHERE (gl_ywfdkgs.dkgsdm = ?) ORDER BY gl_ywfdkgs.dkgsdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dkgsdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtDkgsdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("gl_ywfdkgs") IsNot Nothing Then
                    Me.rcDataset.Tables("gl_ywfdkgs").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "gl_ywfdkgs")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("gl_ywfdkgs").Rows.Count = 1 Then
                Me.TxtDkgsdm.Text = Trim(rcDataset.Tables("gl_ywfdkgs").Rows(0).Item("dkgsdm"))
                Me.LblDkgsmc.Text = Trim(rcDataset.Tables("gl_ywfdkgs").Rows(0).Item("dkgsmc"))
                If Not IsEditing Then
                    IsEditing = True
                    SetControlEnableEvent()
                End If
            Else
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "gl_ywfdkgs"
                    .paraField1 = "dkgsdm"
                    .paraField2 = "dkgsmc"
                    .paraField3 = "dkgssm"
                    .paraTitle = "抵扣规则"
                    .paraOldValue = ""
                    .paraAddName = ""
                    .paraOrderField = "dkgsdm"
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtDkgsdm.Text = Trim(.paraField1)
                        Me.TxtDkgsdm.Focus()
                    End If
                End With
            End If
        Else
            Me.LblDkgsmc.Text = ""
        End If
    End Sub

#End Region

#Region "新单事件"

    Private Sub MnuiNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiNew.Click, BtnNew.Click
        NewEvent()
        Me.TxtDjh.Focus()
    End Sub

    Private Sub NewEvent()
        '清空数据
        Me.TxtKhdm.Text = ""
        Me.LblKhmc.Text = ""
        Me.TxtDkgsdm.Text = ""
        Me.LblDkgsmc.Text = ""
        Me.TxtSkje.Text = 0.0
        Me.TxtFyje.Text = 0.0
        Me.TxtDkmemo.Text = ""
        '显示新单据号
        IsAdding = True
        IsEditing = False
        ShowNewDjh()
    End Sub

    Private Sub ShowNewDjh()
        If Not IsEditing Then
            '取单据类型数据
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT pzno" & strMonth & " As pzno FROM rc_lx WHERE kjnd = ? AND pzlxdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = strYear
                rcOleDbCommand.Parameters.Add("@pzlxdm", OleDbType.VarChar, 4).Value = "DKYW"
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_pzno") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_pzno").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_pzno")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_pzno").Rows.Count = 0 Then
                MsgBox("请定义单据类型。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            Me.TxtDjh.Text = rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1
        End If
    End Sub

#End Region

#Region "保存单据数据事件"

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        SaveEvent()
    End Sub

    Private Sub MnuiSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiSave.Click
        SaveEvent()
    End Sub

    Private Sub SaveEvent()
        '(一)数据合法性检查
        '(3)检查
        If String.IsNullOrEmpty(Me.TxtKhdm.Text) Then
            MsgBox("客户编码不能为空。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        '(2)抵扣规则编码检查
        If String.IsNullOrEmpty(Me.TxtDkgsdm.Text) Then
            MsgBox("抵扣规则编码不能为空。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Trim(Me.TxtKhdm.Text)
            rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_khxx"
            rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "khdm"
            rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
            rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
            rcOleDbCommand.ExecuteNonQuery()
            If rcOleDbCommand.Parameters.Item("@paraIntRecordCount").Value <> 1 Then
                MsgBox(Trim(Me.TxtKhdm.Text) & "客户编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                Me.TxtKhdm.Text = ""
                Me.LblKhmc.Text = ""
                Me.TxtKhdm.Focus()
                Return
            End If
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Trim(Me.TxtDkgsdm.Text)
            rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "gl_ywfdkgs"
            rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "dkgsdm"
            rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
            rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
            rcOleDbCommand.ExecuteNonQuery()
            If rcOleDbCommand.Parameters.Item("@paraIntRecordCount").Value <> 1 Then
                MsgBox(Trim(Me.TxtDkgsdm.Text) & "抵扣规则编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                Me.TxtDkgsdm.Text = ""
                Me.LblDkgsmc.Text = ""
                Me.TxtDkgsdm.Focus()
                Return
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '(二)存储
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP3_SAVE_GL_YWFDKYW"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = IIf(IsAdding, 1, 0)
            rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = "DKYW" & strKjqj & Trim(Me.TxtDjh.Text).PadLeft(5, "0")
            rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
            rcOleDbCommand.Parameters.Add("@paraDateDkrq", OleDbType.Date, 8).Value = Me.DtpDkrq.Value.Date
            rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = Me.TxtKhdm.Text
            rcOleDbCommand.Parameters.Add("@paraStrKhmc", OleDbType.VarChar, 100).Value = Me.LblKhmc.Text
            rcOleDbCommand.Parameters.Add("@paraStrDkgsdm", OleDbType.VarChar, 12).Value = Me.TxtDkgsdm.Text
            rcOleDbCommand.Parameters.Add("@paraStrDkgsmc", OleDbType.VarChar, 30).Value = Me.LblDkgsmc.Text
            rcOleDbCommand.Parameters.Add("@paraStrSkje", OleDbType.Numeric, 14).Value = Me.TxtSkje.Text
            rcOleDbCommand.Parameters.Add("@paraStrFyje", OleDbType.Numeric, 14).Value = Me.TxtFyje.Text
            rcOleDbCommand.Parameters.Add("@paraStrDkmemo", OleDbType.VarChar, 50).Value = Me.TxtDkmemo.Text
            rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
            rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
            rcOleDbCommand.ExecuteNonQuery()
            If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                    MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                    Return
                End If
            End If
            If rcOleDbCommand.Parameters("@paraStrDjh").Value.GetType.ToString <> "System.DBNull" Then
                If rcOleDbCommand.Parameters("@paraStrDjh").Value <> "" Then
                    Me.TxtDjh.Text = Val(Mid(rcOleDbCommand.Parameters("@paraStrDjh").Value, 11, 5))
                End If
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
        ''打印
        'If blnPrint Then
        '    PrintEvent()
        'End If
        IsAdding = False
        IsEditing = False
        '新单据号
        NewEvent()
        '控件设置
        SetControlEnableEvent()
        '设置焦点
        Me.TxtDjh.Focus()
    End Sub

#End Region

#Region "取消修改事件"

    Private Sub BtnCancelEvent(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click, MnuiCancel.Click
        If MsgBox("是否放弃所做的修改？", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "提示信息") = MsgBoxResult.Yes Then
            IsAdding = False
            IsEditing = False
            NewEvent()
            SetControlEnableEvent()
            Me.TxtDjh.Focus()
        End If
    End Sub

#End Region

#Region "退出表单事件"

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        ExitEvent()
    End Sub

    Private Sub MnuiExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiExit.Click
        ExitEvent()
    End Sub

    Private Sub ExitEvent()
        Me.Close()
    End Sub

    Private Sub FrmYwfDkywSrz_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If IsEditing Then
            MsgBox("已经编辑过数据，请保存数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            e.Cancel = True
        End If
    End Sub

#End Region

End Class