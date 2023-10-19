Imports System.Data.OleDb

Public Class FrmFkdSrz

#Region "定义变量"

    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '增加单据的变量
    Dim IsAdding As Boolean = False
    '修改单据的变量
    Dim IsEditing As Boolean = False
    '数据绑定
    ReadOnly rcBmb As BindingManagerBase
    '建立打印文档
    ReadOnly rcRps As RPS.Document
    '会计期间
    Dim strKjqj As String = g_Kjqj
    '年
    Dim strYear As String = ""
    '月
    Dim strMonth As String = ""
    '建立Datatable '我们要利用该datatable进行金额计算
    ReadOnly dtFp As New DataTable("rc_fpnr")
    ReadOnly dtFkd As New DataTable("rc_fkdnr")

#End Region

#Region "窗体初始化"

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

    Private Sub FrmFkdSrz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DataGridViewRkd.AutoGenerateColumns = False
        Me.DataGridViewFkd.AutoGenerateColumns = False
        Me.DataGridViewRkd.Columns("ColRkSl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewRkd.Columns("ColRkSl").DefaultCellStyle.Format = g_FormatSl
        Me.DataGridViewRkd.Columns("ColRkDj").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewRkd.Columns("ColRkDj").DefaultCellStyle.Format = g_FormatDj
        Me.DataGridViewRkd.Columns("ColRkHsdj").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewRkd.Columns("ColRkHsdj").DefaultCellStyle.Format = g_FormatDj
        Me.DataGridViewRkd.Columns("ColRkJe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewRkd.Columns("ColRkJe").DefaultCellStyle.Format = g_FormatJe
        Me.DataGridViewRkd.Columns("ColRkShlv").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewRkd.Columns("ColRkShlv").DefaultCellStyle.Format = g_FormatJe
        Me.DataGridViewRkd.Columns("ColRkSe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewRkd.Columns("ColRkSe").DefaultCellStyle.Format = g_FormatJe
        Me.DataGridViewRkd.Columns("ColRkJese").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewRkd.Columns("ColRkJese").DefaultCellStyle.Format = g_FormatJe
        Me.DataGridViewRkd.Columns("ColYifje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewRkd.Columns("ColYifje").DefaultCellStyle.Format = g_FormatJe
        Me.DataGridViewFkd.Columns("ColFkje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewFkd.Columns("ColFkje").DefaultCellStyle.Format = g_FormatJe
        Me.DataGridViewFkd.Columns("ColYufje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewFkd.Columns("ColYufje").DefaultCellStyle.Format = g_FormatJe
        '取单据类型数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE lxgs = '付款单' and kjnd = '" & strYear & "' ORDER BY pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_lx") IsNot Nothing Then
                Me.rcDataset.Tables("rc_lx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_lx")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_lx").Rows.Count = 0 Then
            MsgBox("请定义单据类型。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        '绑定凭证类型简称
        BindDropDownList(CmbPzlxjc, rcDataset.Tables("rc_lx"), "pzlxdm", "pzlxjc")
        strKjqj = strYear & strMonth.PadLeft(2, "0")
        If getInvKjqj(g_Kjrq) = strKjqj Then
            DtpFkrq.Value = g_Kjrq
        Else
            DtpFkrq.Value = getInvEnd(strYear, strMonth)
        End If

        '数据绑定
        dtFp.Columns.Add("xz", Type.GetType("System.Boolean"))
        dtFp.Columns.Add("sqrq", Type.GetType("System.DateTime"))
        dtFp.Columns.Add("rkdjh", Type.GetType("System.String"))
        dtFp.Columns.Add("rkzy", Type.GetType("System.String"))
        dtFp.Columns.Add("rksl", Type.GetType("System.Double"))
        dtFp.Columns.Add("rkdj", Type.GetType("System.Double"))
        dtFp.Columns.Add("rkhsdj", Type.GetType("System.Double"))
        dtFp.Columns.Add("rkje", Type.GetType("System.Double"))
        dtFp.Columns.Add("rkshlv", Type.GetType("System.Double"))
        dtFp.Columns.Add("rkse", Type.GetType("System.Double"))
        dtFp.Columns.Add("rkjese", Type.GetType("System.Double"))
        dtFp.Columns.Add("yifje", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtFp)
        With rcDataset.Tables("rc_fpnr")
            .Columns("xz").DefaultValue = 0
            .Columns("rkdjh").DefaultValue = ""
            .Columns("rkzy").DefaultValue = ""
            .Columns("rksl").DefaultValue = 0.0
            .Columns("rkdj").DefaultValue = 0.0
            .Columns("rkhsdj").DefaultValue = 0.0
            .Columns("rkje").DefaultValue = 0.0
            .Columns("rkshlv").DefaultValue = 0.0
            .Columns("rkse").DefaultValue = 0.0
            .Columns("rkjese").DefaultValue = 0.0
            .Columns("yifje").DefaultValue = 0.0
        End With
        '绑定数据the DataGrid to the DataSet.
        Me.BindingSourceRkd.DataSource = dtFp
        Me.DataGridViewRkd.DataSource = Me.BindingSourceRkd
        '创建表结构
        dtFkd.Columns.Add("xz", Type.GetType("System.Boolean"))
        dtFkd.Columns.Add("fkrq", Type.GetType("System.DateTime"))
        dtFkd.Columns.Add("fkdjh", Type.GetType("System.String"))
        dtFkd.Columns.Add("fkzy", Type.GetType("System.String"))
        dtFkd.Columns.Add("fkje", Type.GetType("System.Double"))
        dtFkd.Columns.Add("yufje", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtFkd)
        With rcDataset.Tables("rc_fkdnr")
            .Columns("xz").DefaultValue = 0
            .Columns("fkdjh").DefaultValue = ""
            .Columns("fkzy").DefaultValue = ""
            .Columns("fkje").DefaultValue = 0.0
            .Columns("yufje").DefaultValue = 0.0
        End With
        '绑定数据the DataGrid to the DataSet.
        Me.BindingSourceFkd.DataSource = dtFkd
        Me.DataGridViewFkd.DataSource = Me.BindingSourceFkd

        NewEvent()
    End Sub

#End Region

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDjh.KeyPress, DtpFkrq.KeyPress, TxtCsdm.KeyPress, TxtKmdm.KeyPress, TxtYspz.KeyPress, TxtYingFuJe.KeyPress, TxtYufje.KeyPress, TxtFkje.KeyPress, TxtWfje.KeyPress, TxtQtyf.KeyPress, TxtFkmemo.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "单据类型的事件"

    Private Sub CmbPzlxjc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbPzlxjc.KeyDown
        Select Case e.KeyCode
            Case Keys.Return, Keys.Right
                TxtDjh.Focus()
            Case Keys.Left
                BtnExit.Focus()
        End Select
    End Sub

    Private Sub CmbPzlxjc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbPzlxjc.Validated
        ShowNewDjh()
    End Sub

#End Region

#Region "单据号的事件"

    Private Sub TxtDjh_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtDjh.Validating
        If IsEditing Then
            Return
        End If
        '检查单据号是否存在
        If rcDataset.Tables("rc_pzno") Is Nothing Then
            Return
        End If
        '判断增加还是修改
        rcOleDbConn.Open()
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            If rcDataset.Tables("rc_pzno").Rows.Count > 0 Then
                If rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") >= Mid(Trim(Me.TxtDjh.Text), 11, 5) Then
                    '修改单据
                    rcOleDbCommand.CommandText = "SELECT ap_fkd.djh,ap_fkd.fkrq,ap_fkd.csdm,ap_fkd.csmc,ap_fkd.kmdm,ap_fkd.kmmc,ap_fkd.yspz,ap_fkd.je,ap_fkd.rkje,ap_fkd.fkmemo,ap_fkd.srr,ap_fkd.shr,ap_fkd.jzr FROM ap_fkd WHERE (djh = ? )"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = TxtDjh.Text
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("rc_fkd") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_fkd").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "rc_fkd")
                    If rcDataset.Tables("rc_fkd").Rows.Count > 0 Then
                        If rcDataset.Tables("rc_fkd").Rows(0).Item("jzr").GetType.ToString <> "System.DBNull" Then
                            MsgBox("该单据已经记账，不能修改。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                            TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                            IsAdding = True
                        Else
                            If rcDataset.Tables("rc_fkd").Rows(0).Item("shr").GetType.ToString <> "System.DBNull" Then
                                MsgBox("该单据已经审核，不能修改。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                                TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                                IsAdding = True
                            Else
                                Me.DtpFkrq.Value = rcDataset.Tables("rc_fkd").Rows(0).Item("fkrq")
                                If rcDataset.Tables("rc_fkd").Rows(0).Item("csdm").GetType.ToString <> "System.DBNull" Then
                                    Me.TxtCsdm.Text = Trim(rcDataset.Tables("rc_fkd").Rows(0).Item("csdm"))
                                Else
                                    Me.TxtCsdm.Text = ""
                                End If
                                If rcDataset.Tables("rc_fkd").Rows(0).Item("csmc").GetType.ToString <> "System.DBNull" Then
                                    Me.LblCsmc.Text = rcDataset.Tables("rc_fkd").Rows(0).Item("csmc")
                                Else
                                    Me.LblCsmc.Text = ""
                                End If
                                Me.TxtKmdm.Text = Trim(rcDataset.Tables("rc_fkd").Rows(0).Item("kmdm"))
                                Me.LblKmmc.Text = rcDataset.Tables("rc_fkd").Rows(0).Item("kmmc")
                                If rcDataset.Tables("rc_fkd").Rows(0).Item("yspz").GetType.ToString <> "System.DBNull" Then
                                    Me.TxtYspz.Text = rcDataset.Tables("rc_fkd").Rows(0).Item("yspz")
                                Else
                                    Me.TxtYspz.Text = ""
                                End If
                                Me.TxtFkje.Text = rcDataset.Tables("rc_fkd").Rows(0).Item("je")
                                If rcDataset.Tables("rc_fkd").Rows(0).Item("fkmemo").GetType.ToString <> "System.DBNull" Then
                                    TxtFkmemo.Text = rcDataset.Tables("rc_fkd").Rows(0).Item("fkmemo")
                                Else
                                    Me.TxtFkmemo.Text = ""
                                End If
                                If rcDataset.Tables("rc_fkd").Rows(0).Item("rkje") <> 0 Then
                                    Me.TxtFkje.ReadOnly = True
                                Else
                                    Me.TxtFkje.ReadOnly = False
                                End If
                                If dtFp IsNot Nothing Then
                                    dtFp.Clear()
                                End If
                                If dtFkd IsNot Nothing Then
                                    dtFkd.Clear()
                                End If
                                IsAdding = False
                            End If
                        End If
                    End If
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
        'SetControlEnableEvent()
    End Sub

#End Region

#Region "付款日期的事件"

    Private Sub DtpFkrq_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DtpFkrq.Validating
        Dim dateBegin As DateTime
        Dim dateEnd As DateTime
        dateBegin = getInvBegin(strYear, strMonth)
        dateEnd = getInvEnd(strYear, strMonth)
        If DtpFkrq.Value > dateEnd Or DtpFkrq.Value < dateBegin Then
            MsgBox("您输入的日期不在当前会计期间中，请重输入。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Me.DtpFkrq.Focus()
        End If
    End Sub

#End Region

#Region "供应商编码的事件"

    Private Sub TxtCsdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCsdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_csxx"
                    .paraField1 = "csdm"
                    .paraField2 = "csmc"
                    .paraField3 = "cssm"
                    .paraCondition = "0=0"
                    .paraOrderField = "csmc"
                    .paraTitle = "供应商"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtCsdm.Text = Trim(.paraField1)
                        LblCsmc.Text = Trim(.paraField2)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtCsdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCsdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtCsdm.Text) And IsAdding Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_csxx WHERE (csdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtCsdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_csxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_csxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_csxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_csxx").Rows.Count > 0 Then
                TxtCsdm.Text = Trim(rcDataset.Tables("rc_csxx").Rows(0).Item("csdm"))
                LblCsmc.Text = rcDataset.Tables("rc_csxx").Rows(0).Item("csmc")
            Else
                e.Cancel = True
                Return
            End If
            '取应付明细
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT 0 AS xz,sqrq,'(' ||cpdm || ')' || cpmc || dw || sqmemo AS rkzy,sl AS rksl,dj AS rkdj,hsdj AS rkhsdj,je AS rkje,shlv AS rkshlv,se As rkse,(je + se) AS rkjese,fkje As yifje,djh,xh,srq,sdjh,sxh,fktj,fkts FROM ap_fksq WHERE je + se <> fkje AND NOT ap_fksq.shr IS NULL AND csdm = ? ORDER BY sqrq,djh,xh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtCsdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_fpnr") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_fpnr").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_fpnr")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            Me.TxtYingFuJe.Text = Format(0.0, g_FormatJe)
            '取付款明细
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT 0 AS xz,fkrq,yspz || fkmemo fkzy,je AS fkje,je - rkje AS yufje,djh FROM ap_fkd WHERE je <> rkje AND csdm = ? ORDER BY fkrq,djh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtCsdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_fkdnr") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_fkdnr").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_fkdnr")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        End If
    End Sub

#End Region

#Region "科目编码的事件"

    Private Sub TxtKmdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtKmdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "gl_kmxx"
                    .paraField1 = "kmdm"
                    .paraField2 = "kmmc"
                    .paraField3 = "kmsm"
                    .paraCondition = "0=0"
                    .paraOrderField = "kmdm"
                    .paraTitle = "科目"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtKmdm.Text = Trim(.paraField1)
                        LblKmmc.Text = Trim(.paraField2)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtKmdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtKmdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtKmdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM gl_kmxx WHERE (kmdm = ?) AND NOT EXISTS (SELECT 1 FROM gl_kmxx aa WHERE aa.parentid = gl_kmxx.kmdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKmdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("gl_kmxx") IsNot Nothing Then
                    Me.rcDataset.Tables("gl_kmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "gl_kmxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("gl_kmxx").Rows.Count > 0 Then
                TxtKmdm.Text = Trim(rcDataSet.Tables("gl_kmxx").Rows(0).Item("kmdm"))
                LblKmmc.Text = rcDataSet.Tables("gl_kmxx").Rows(0).Item("kmmc")
            Else
                MsgBox("科目编码不存在或非明细科目。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                e.Cancel = True
                Return
            End If
        End If
    End Sub

#End Region

#Region "新建单据的事件"

    Private Sub MnuiNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiNew.Click
        NewEvent()
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        NewEvent()
    End Sub

    Private Sub NewEvent()
        '清空数据
        Me.TxtCsdm.Text = ""
        Me.LblCsmc.Text = ""
        Me.TxtKmdm.Text = ""
        Me.LblKmmc.Text = ""
        Me.TxtYspz.Text = ""
        Me.TxtYingFuJe.Text = Format(0.0, g_FormatJe)
        Me.TxtYufje.Text = Format(0.0, g_FormatJe)
        Me.TxtFkje.Text = Format(0.0, g_FormatJe)
        Me.TxtFkmemo.Text = ""
        Me.TxtWfje.Text = Format(0.0, g_FormatJe)
        Me.TxtQtyf.Text = Format(0.0, g_FormatJe)
        Me.TxtFkje.ReadOnly = False
        IsAdding = True
        IsEditing = False
        If dtFp IsNot Nothing Then
            dtFp.Clear()
        End If
        If dtFkd IsNot Nothing Then
            dtFkd.Clear()
        End If
        '显示新单据号
        ShowNewDjh()
    End Sub

    Private Sub ShowNewDjh()
        If Not IsEditing Then
            '取单据类型数据
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "SELECT pzno" & strMonth & " as pzno FROM rc_lx WHERE pzlxdm = ? AND  lxgs = '付款单' AND kjnd = '" & strYear & "'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.AddWithValue("@pzlxdm", Trim(Me.CmbPzlxjc.SelectedValue))
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_pzno") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_pzno").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_pzno")
                rcOleDbTrans.Commit()
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_pzno").Rows.Count = 0 Then
                MsgBox("请定义单据类型。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            Me.TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataSet.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
        End If
    End Sub

#End Region

#Region "保存单据的事件"

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MnuiSave.Click
        SaveEvent(False)
    End Sub

    Private Sub SaveEvent(ByVal blnPrint As Boolean)
        Dim i As Integer
        Dim dblFkje As Double = Val(Me.TxtYufje.Text) + Val(Me.TxtFkje.Text) - Val(Me.TxtQtyf.Text)
        Dim dblRkje As Double = Val(Me.TxtYingFuJe.Text)
        Dim dblHxje As Double = 0.0
        '(一)数据合法性检查
        '(1)是否有需要存储的数据
        If Val(Me.TxtFkje.Text) = 0 Then
            MsgBox("请输入付款金额。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        '(2)供应商检查
        If Trim(Me.TxtCsdm.Text).Length = 0 Then
            MsgBox("请输入供应商编码。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Trim(Me.TxtCsdm.Text)
            rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_csxx"
            rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "csdm"
            rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
            rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
            rcOleDbCommand.ExecuteNonQuery()
            If rcOleDbCommand.Parameters.Item("@paraIntRecordCount").Value <> 1 Then
                MsgBox(Trim(Me.TxtCsdm.Text) & "供应商编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                Me.TxtCsdm.Text = ""
                Me.LblCsmc.Text = ""
                Me.TxtCsdm.Focus()
                Return
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '(2)科目检查
        If Trim(Me.TxtKmdm.Text).Length = 0 Then
            MsgBox("请输入科目编码。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Trim(Me.TxtKmdm.Text)
            rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "gl_kmxx"
            rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "kmdm"
            rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
            rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
            rcOleDbCommand.ExecuteNonQuery()
            If rcOleDbCommand.Parameters.Item("@paraIntRecordCount").Value <> 1 Then
                MsgBox(Trim(Me.TxtKmdm.Text) & "科目编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                Me.TxtKmdm.Text = ""
                Me.LblKmmc.Text = ""
                Me.TxtKmdm.Focus()
                Return
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '(3)单据号长度检查
        If Trim(Me.TxtDjh.Text).Length <> 15 Then
            MsgBox("单据号长度不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Return
        End If
        '(二)存储skd
        '付款金额 ＝ 应付金额 － 预付金额 
        If Val(Me.TxtFkje.Text) = Val(Me.TxtYingFuJe.Text) - Val(Me.TxtYufje.Text) Then
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            Try
                rcOleDbCommand.CommandType = CommandType.Text
                '保存历史入库单上的付款金额
                For i = 0 To rcDataset.Tables("rc_fpnr").Rows.Count - 1
                    If rcDataset.Tables("rc_fpnr").Rows(i).Item("xz") Then
                        rcOleDbCommand.CommandText = "UPDATE ap_fksq SET fkje = je + se WHERE djh = ? AND xh = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("djh")
                        rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("xh")
                        rcOleDbCommand.ExecuteNonQuery()
                        Select Case True
                            Case rcDataset.Tables("rc_fpnr").Rows(i).Item("fktj") = "款到发货"
                                rcOleDbCommand.CommandText = "UPDATE po_cgd SET fkje = je + se WHERE djh = ? AND xh = ?"
                                rcOleDbCommand.Parameters.Clear()
                                rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("sdjh")
                                rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("sxh")
                                rcOleDbCommand.ExecuteNonQuery()
                            Case rcDataset.Tables("rc_fpnr").Rows(i).Item("fktj") = "货到付款"
                                rcOleDbCommand.CommandText = "UPDATE po_rkd SET fkje = je + se WHERE djh = ? AND xh = ?"
                                rcOleDbCommand.Parameters.Clear()
                                rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("sdjh")
                                rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("sxh")
                                rcOleDbCommand.ExecuteNonQuery()
                            Case rcDataset.Tables("rc_fpnr").Rows(i).Item("fktj") = "月结"
                                rcOleDbCommand.CommandText = "UPDATE po_fp SET fkje = je + se WHERE djh = ? AND xh = ?"
                                rcOleDbCommand.Parameters.Clear()
                                rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("sdjh")
                                rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("sxh")
                                rcOleDbCommand.ExecuteNonQuery()
                        End Select
                    End If
                Next
                '保历史付款单上的入库金额
                For i = 0 To rcDataset.Tables("rc_fkdnr").Rows.Count - 1
                    If rcDataset.Tables("rc_fkdnr").Rows(i).Item("xz") Then
                        rcOleDbCommand.CommandText = "UPDATE ap_fkd SET rkje = je WHERE djh = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_fkdnr").Rows(i).Item("djh")
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                Next
                rcOleDbCommand.CommandType = CommandType.StoredProcedure
                rcOleDbCommand.CommandText = "USP3_SAVE_AP_FKD"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = IIf(IsAdding, 1, 0)
                rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = Trim(Me.TxtDjh.Text)
                rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                rcOleDbCommand.Parameters.Add("@paraDateFkrq", OleDbType.Date, 8).Value = DtpFkrq.Value
                rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = Me.TxtCsdm.Text
                rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = Me.LblCsmc.Text
                rcOleDbCommand.Parameters.Add("@paraStrKmdm", OleDbType.VarChar, 12).Value = Me.TxtKmdm.Text
                rcOleDbCommand.Parameters.Add("@paraStrKmmc", OleDbType.VarChar, 50).Value = Me.LblKmmc.Text
                rcOleDbCommand.Parameters.Add("@paraStrYspz", OleDbType.VarChar, 12).Value = Me.TxtYspz.Text
                rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = Val(Me.TxtFkje.Text) '付款金额
                rcOleDbCommand.Parameters.Add("@paraDblRkje", OleDbType.Numeric, 14).Value = Val(Me.TxtFkje.Text) '付款金额
                rcOleDbCommand.Parameters.Add("@paraStrFkmemo", OleDbType.VarChar, 50).Value = Trim(Me.TxtFkmemo.Text) '备注
                rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 10).Value = g_User_DspName
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
                        Me.TxtDjh.Text = Trim(rcOleDbCommand.Parameters("@paraStrDjh").Value)
                    End If
                End If
                rcOleDbTrans.Commit()
            Catch ex As Exception
                MsgBox("执行存储过程发生了错误：" & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        Else
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            Try
                If IsAdding Then
                    rcOleDbCommand.CommandType = CommandType.Text
                    '保存历史入库单上的付款金额
                    For i = 0 To rcDataset.Tables("rc_fpnr").Rows.Count - 1
                        If rcDataset.Tables("rc_fpnr").Rows(i).Item("xz") And dblFkje <> 0 Then
                            rcOleDbCommand.CommandText = "UPDATE ap_fksq SET fkje = fkje + ? WHERE djh = ? AND xh = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@paraDblFkje", OleDbType.Numeric, 14).Value = IIf(dblFkje >= rcDataset.Tables("rc_fpnr").Rows(i).Item("rkjese") - rcDataset.Tables("rc_fpnr").Rows(i).Item("yifje"), rcDataset.Tables("rc_fpnr").Rows(i).Item("rkjese") - rcDataset.Tables("rc_fpnr").Rows(i).Item("yifje"), dblFkje)
                            rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("djh")
                            rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("xh")
                            rcOleDbCommand.ExecuteNonQuery()
                            dblHxje += IIf(dblFkje >= rcDataset.Tables("rc_fpnr").Rows(i).Item("rkjese") - rcDataset.Tables("rc_fpnr").Rows(i).Item("yifje"), rcDataset.Tables("rc_fpnr").Rows(i).Item("rkjese") - rcDataset.Tables("rc_fpnr").Rows(i).Item("yifje"), dblFkje)
                            dblFkje -= IIf(dblFkje >= rcDataset.Tables("rc_fpnr").Rows(i).Item("rkjese") - rcDataset.Tables("rc_fpnr").Rows(i).Item("yifje"), rcDataset.Tables("rc_fpnr").Rows(i).Item("rkjese") - rcDataset.Tables("rc_fpnr").Rows(i).Item("yifje"), dblFkje)
                        End If
                    Next
                    '保历史付款单上的入库金额
                    For i = 0 To rcDataset.Tables("rc_fkdnr").Rows.Count - 1
                        If rcDataset.Tables("rc_fkdnr").Rows(i).Item("xz") Then
                            rcOleDbCommand.CommandText = "UPDATE ap_fkd SET rkje = rkje + ? WHERE djh = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@paraDblRkje", OleDbType.Numeric, 14).Value = IIf(dblRkje >= rcDataset.Tables("rc_fkdnr").Rows(i).Item("yufje"), rcDataset.Tables("rc_fkdnr").Rows(i).Item("yufje"), dblRkje)
                            rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_fkdnr").Rows(i).Item("djh")
                            rcOleDbCommand.ExecuteNonQuery()
                            dblHxje -= IIf(dblRkje >= rcDataset.Tables("rc_fkdnr").Rows(i).Item("yufje"), rcDataset.Tables("rc_fkdnr").Rows(i).Item("yufje"), dblRkje)
                            dblRkje -= IIf(dblRkje >= rcDataset.Tables("rc_fkdnr").Rows(i).Item("yufje"), rcDataset.Tables("rc_fkdnr").Rows(i).Item("yufje"), dblRkje)
                        End If
                    Next
                End If
                rcOleDbCommand.CommandType = CommandType.StoredProcedure
                rcOleDbCommand.CommandText = "USP3_SAVE_AP_FKD"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = IIf(IsAdding, 1, 0)
                rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = Trim(Me.TxtDjh.Text)
                rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                rcOleDbCommand.Parameters.Add("@paraDateFkrq", OleDbType.Date, 8).Value = DtpFkrq.Value
                rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = Me.TxtCsdm.Text
                rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = Me.LblCsmc.Text
                rcOleDbCommand.Parameters.Add("@paraStrKmdm", OleDbType.VarChar, 12).Value = Me.TxtKmdm.Text
                rcOleDbCommand.Parameters.Add("@paraStrKmmc", OleDbType.VarChar, 50).Value = Me.LblKmmc.Text
                rcOleDbCommand.Parameters.Add("@paraStrYspz", OleDbType.VarChar, 12).Value = Me.TxtYspz.Text
                rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = Val(Me.TxtFkje.Text) '付款金额
                If IsAdding Then
                    rcOleDbCommand.Parameters.Add("@paraDblRkje", OleDbType.Numeric, 14).Value = dblHxje + Val(Me.TxtQtyf.Text) '付款金额
                Else
                    If rcDataset.Tables("rc_fkd").Rows(0).Item("rkje").GetType.ToString <> "System.DBNull" Then
                        rcOleDbCommand.Parameters.Add("@paraDblRkje", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_fkd").Rows(0).Item("rkje") '付款金额
                    Else
                        rcOleDbCommand.Parameters.Add("@paraDblRkje", OleDbType.Numeric, 14).Value = 0.0 '付款金额
                    End If
                End If
                rcOleDbCommand.Parameters.Add("@paraStrFkmemo", OleDbType.VarChar, 50).Value = Trim(TxtFkmemo.Text) '备注
                rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 10).Value = g_User_DspName
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
                        Me.TxtDjh.Text = Trim(rcOleDbCommand.Parameters("@paraStrDjh").Value)
                    End If
                End If
                rcOleDbTrans.Commit()
            Catch ex As Exception
                MsgBox("执行存储过程发生了错误：" & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        End If
        If blnPrint Then
            'Print()
        End If

        '新单据号
        NewEvent()
        '控件设置
        'SetControlEnableEvent()
        '设置焦点
        Me.TxtDjh.Focus()
    End Sub

#End Region

#Region "退出表单事件"

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

#End Region

    Private Sub DataGridViewRkd_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DataGridViewRkd.CellValidating
        If Me.DataGridViewRkd.IsCurrentCellDirty Then
            Me.DataGridViewRkd.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
        '汇总本次应付金额
        Me.TxtYingFuJe.Text = Format(0.0, g_FormatJe)
        Me.TxtFkje.Text = Format(0.0, g_FormatJe)
        Me.TxtFkje.Enabled = True
        Dim i As Integer
        For i = 0 To rcDataset.Tables("rc_fpnr").Rows.Count - 1
            If rcDataset.Tables("rc_fpnr").Rows(i).Item("xz").GetType.ToString <> "System.DBNull" Then
                If rcDataset.Tables("rc_fpnr").Rows(i).Item("xz") Then
                    Me.TxtYingFuJe.Text = Val(Me.TxtYingFuJe.Text) + rcDataset.Tables("rc_fpnr").Rows(i).Item("rkjese") - rcDataset.Tables("rc_fpnr").Rows(i).Item("yifje")
                End If
            End If
        Next
        Me.TxtFkje.Text = Val(Me.TxtYingFuJe.Text) - Val(Me.TxtYufje.Text)
        If Me.TxtFkje.Text <> 0 Then
            Me.TxtFkje.Enabled = False
        Else
            Me.TxtFkje.Enabled = True
        End If
        If String.IsNullOrEmpty(Me.TxtYingFuJe.Text) Then
            Me.TxtYingFuJe.Text = Format(0.0, g_FormatJe)
        Else
            Me.TxtYingFuJe.Text = Format(Val(Me.TxtYingFuJe.Text), g_FormatJe0)
        End If
        If String.IsNullOrEmpty(Me.TxtYufje.Text) Then
            Me.TxtYufje.Text = Format(0.0, g_FormatJe)
        End If
        If String.IsNullOrEmpty(Me.TxtQtyf.Text) Then
            Me.TxtQtyf.Text = Format(0.0, g_FormatJe)
        End If
        If String.IsNullOrEmpty(Me.TxtFkje.Text) Then
            Me.TxtFkje.Text = Format(0.0, g_FormatJe)
        End If
        Me.TxtWfje.Text = Val(Me.TxtYingFuJe.Text) - Val(Me.TxtYufje.Text) + Val(Me.TxtQtyf.Text) - Val(Me.TxtFkje.Text)
    End Sub

    Private Sub DataGridViewRkd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewRkd.Leave
        Me.DataGridViewRkd.ClearSelection()
    End Sub

    Private Sub BtnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectAll.Click
        '汇总本次应付金额
        Me.TxtYingFuJe.Text = Format(0.0, g_FormatJe)
        Me.TxtFkje.Text = Format(0.0, g_FormatJe)
        Me.TxtFkje.Enabled = True
        Dim i As Integer
        For i = 0 To rcDataset.Tables("rc_fpnr").Rows.Count - 1
            rcDataset.Tables("rc_fpnr").Rows(i).Item("xz") = True
            Me.TxtYingFuJe.Text = Val(Me.TxtYingFuJe.Text) + rcDataset.Tables("rc_fpnr").Rows(i).Item("rkjese") - rcDataset.Tables("rc_fpnr").Rows(i).Item("yifje")
        Next
        Me.TxtFkje.Text = Val(Me.TxtYingFuJe.Text) - Val(Me.TxtYufje.Text)
        If Me.TxtFkje.Text <> 0 Then
            Me.TxtFkje.Enabled = False
        Else
            Me.TxtFkje.Enabled = True
        End If
        If String.IsNullOrEmpty(Me.TxtYingFuJe.Text) Then
            Me.TxtYingFuJe.Text = Format(0.0, g_FormatJe)
        Else
            Me.TxtYingFuJe.Text = Format(Val(Me.TxtYingFuJe.Text), g_FormatJe0)
        End If
        If String.IsNullOrEmpty(Me.TxtYufje.Text) Then
            Me.TxtYufje.Text = Format(0.0, g_FormatJe)
        End If
        If String.IsNullOrEmpty(Me.TxtQtyf.Text) Then
            Me.TxtQtyf.Text = Format(0.0, g_FormatJe)
        End If
        If String.IsNullOrEmpty(Me.TxtFkje.Text) Then
            Me.TxtFkje.Text = Format(0.0, g_FormatJe)
        End If
        Me.TxtWfje.Text = Val(Me.TxtYingFuJe.Text) - Val(Me.TxtYufje.Text) + Val(Me.TxtQtyf.Text) - Val(Me.TxtFkje.Text)
        If String.IsNullOrEmpty(Me.TxtWfje.Text) Then
            Me.TxtWfje.Text = Format(0.0, g_FormatJe)
        Else
            Me.TxtWfje.Text = Format(Val(Me.TxtWfje.Text), g_FormatJe0)
        End If
    End Sub

    Private Sub DataGridViewFkd_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DataGridViewFkd.CellValidating
        If Me.DataGridViewFkd.IsCurrentCellDirty Then
            Me.DataGridViewFkd.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
        '汇总本次预付金额
        Me.TxtYufje.Text = Format(0.0, g_FormatJe)
        Dim i As Integer
        For i = 0 To rcDataSet.Tables("rc_fkdnr").Rows.Count - 1
            If rcDataSet.Tables("rc_fkdnr").Rows(i).Item("xz").GetType.ToString <> "System.DBNull" Then
                If rcDataSet.Tables("rc_fkdnr").Rows(i).Item("xz") Then
                    Me.TxtYufje.Text = Val(Me.TxtYufje.Text) + rcDataSet.Tables("rc_fkdnr").Rows(i).Item("yufje")
                End If
            End If
        Next
        Me.TxtFkje.Text = Val(Me.TxtYingFuJe.Text) - Val(Me.TxtYufje.Text)
        If Me.TxtFkje.Text <> 0 Then
            Me.TxtFkje.Enabled = False
        Else
            Me.TxtFkje.Enabled = True
        End If
        If String.IsNullOrEmpty(Me.TxtYingFuJe.Text) Then
            Me.TxtYingFuJe.Text = Format(0.0, g_FormatJe)
        End If
        If String.IsNullOrEmpty(Me.TxtYufje.Text) Then
            Me.TxtYufje.Text = Format(0.0, g_FormatJe)
        Else
            Me.TxtYufje.Text = Format(Val(Me.TxtYufje.Text), g_FormatJe0)
        End If
        If String.IsNullOrEmpty(Me.TxtQtyf.Text) Then
            Me.TxtQtyf.Text = Format(0.0, g_FormatJe)
        End If
        If String.IsNullOrEmpty(Me.TxtFkje.Text) Then
            Me.TxtFkje.Text = Format(0.0, g_FormatJe)
        End If
        Me.TxtWfje.Text = Val(Me.TxtYingFuJe.Text) - Val(Me.TxtYufje.Text) + Val(Me.TxtQtyf.Text) - Val(Me.TxtFkje.Text)
        If String.IsNullOrEmpty(Me.TxtWfje.Text) Then
            Me.TxtWfje.Text = Format(0.0, g_FormatJe)
        Else
            Me.TxtWfje.Text = Format(Val(Me.TxtWfje.Text), g_FormatJe0)
        End If
    End Sub

    Private Sub DataGridViewFkd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewFkd.Leave
        Me.DataGridViewFkd.ClearSelection()
    End Sub

    Private Sub TxtFkje_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtFkje.Validating, TxtQtyf.Validating
        '计算未付金额
        If String.IsNullOrEmpty(Me.TxtYingFuJe.Text) Then
            Me.TxtYingFuJe.Text = Format(0.0, g_FormatJe)
        End If
        If String.IsNullOrEmpty(Me.TxtYufje.Text) Then
            Me.TxtYufje.Text = Format(0.0, g_FormatJe)
        End If
        If String.IsNullOrEmpty(Me.TxtQtyf.Text) Then
            Me.TxtQtyf.Text = Format(0.0, g_FormatJe)
        End If
        If String.IsNullOrEmpty(Me.TxtFkje.Text) Then
            Me.TxtFkje.Text = Format(0.0, g_FormatJe)
        Else
            Me.TxtFkje.Text = Format(Val(Me.TxtFkje.Text), g_FormatJe0)
        End If
        Me.TxtWfje.Text = Val(Me.TxtYingFuJe.Text) - Val(Me.TxtYufje.Text) + Val(Me.TxtQtyf.Text) - Val(Me.TxtFkje.Text)
        If String.IsNullOrEmpty(Me.TxtWfje.Text) Then
            Me.TxtWfje.Text = Format(0.0, g_FormatJe)
        Else
            Me.TxtWfje.Text = Format(Val(Me.TxtWfje.Text), g_FormatJe0)
        End If
    End Sub
End Class