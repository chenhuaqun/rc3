Imports System.Data.OleDb

Public Class FrmSkdSrz

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
    ReadOnly dtSkd As New DataTable("rc_skdnr")

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

    Private Sub FrmSkdSrz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DataGridViewXsd.AutoGenerateColumns = False
        Me.DataGridViewSkd.AutoGenerateColumns = False
        Me.DataGridViewXsd.Columns("ColXsSl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewXsd.Columns("ColXsSl").DefaultCellStyle.Format = g_FormatSl
        Me.DataGridViewXsd.Columns("ColXsDj").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewXsd.Columns("ColXsDj").DefaultCellStyle.Format = g_FormatDj
        Me.DataGridViewXsd.Columns("ColXsHsdj").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewXsd.Columns("ColXsHsdj").DefaultCellStyle.Format = g_FormatDj
        Me.DataGridViewXsd.Columns("ColXsJe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewXsd.Columns("ColXsJe").DefaultCellStyle.Format = g_FormatJe
        Me.DataGridViewXsd.Columns("ColXsShlv").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewXsd.Columns("ColXsShlv").DefaultCellStyle.Format = g_FormatJe
        Me.DataGridViewXsd.Columns("ColXsSe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewXsd.Columns("ColXsSe").DefaultCellStyle.Format = g_FormatJe
        Me.DataGridViewXsd.Columns("ColXsJese").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewXsd.Columns("ColXsJese").DefaultCellStyle.Format = g_FormatJe
        Me.DataGridViewXsd.Columns("ColYisje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewXsd.Columns("ColYisje").DefaultCellStyle.Format = g_FormatJe
        Me.DataGridViewSkd.Columns("ColSkje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewSkd.Columns("ColSkje").DefaultCellStyle.Format = g_FormatJe
        Me.DataGridViewSkd.Columns("ColYusje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewSkd.Columns("ColYusje").DefaultCellStyle.Format = g_FormatJe
        '取单据类型数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE lxgs = '收款单' and kjnd = '" & strYear & "' ORDER BY pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_lx") IsNot Nothing Then
                Me.rcDataSet.Tables("rc_lx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_lx")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("rc_lx").Rows.Count = 0 Then
            MsgBox("请定义单据类型。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        '绑定凭证类型简称
        BindDropDownList(CmbPzlxjc, rcDataSet.Tables("rc_lx"), "pzlxdm", "pzlxjc")
        strKjqj = strYear & strMonth.PadLeft(2, "0")
        If getInvKjqj(g_Kjrq) = strKjqj Then
            DtpSkrq.Value = g_Kjrq
        Else
            DtpSkrq.Value = getInvEnd(strYear, strMonth)
        End If

        '数据绑定
        dtFp.Columns.Add("xz", Type.GetType("System.Boolean"))
        dtFp.Columns.Add("fprq", Type.GetType("System.DateTime"))
        dtFp.Columns.Add("xsdjh", Type.GetType("System.String"))
        dtFp.Columns.Add("xszy", Type.GetType("System.String"))
        dtFp.Columns.Add("xssl", Type.GetType("System.Double"))
        dtFp.Columns.Add("xsdj", Type.GetType("System.Double"))
        dtFp.Columns.Add("xshsdj", Type.GetType("System.Double"))
        dtFp.Columns.Add("xsje", Type.GetType("System.Double"))
        dtFp.Columns.Add("xsshlv", Type.GetType("System.Double"))
        dtFp.Columns.Add("xsse", Type.GetType("System.Double"))
        dtFp.Columns.Add("xsjese", Type.GetType("System.Double"))
        dtFp.Columns.Add("yisje", Type.GetType("System.Double"))
        rcDataSet.Tables.Add(dtFp)
        With rcDataSet.Tables("rc_fpnr")
            .Columns("xz").DefaultValue = 0
            .Columns("xsdjh").DefaultValue = ""
            .Columns("xszy").DefaultValue = ""
            .Columns("xssl").DefaultValue = 0.0
            .Columns("xsdj").DefaultValue = 0.0
            .Columns("xshsdj").DefaultValue = 0.0
            .Columns("xsje").DefaultValue = 0.0
            .Columns("xsshlv").DefaultValue = 0.0
            .Columns("xsse").DefaultValue = 0.0
            .Columns("xsjese").DefaultValue = 0.0
            .Columns("yisje").DefaultValue = 0.0
        End With
        '绑定数据the DataGrid to the DataSet.
        Me.BindingSourceXsd.DataSource = dtFp
        Me.DataGridViewXsd.DataSource = Me.BindingSourceXsd
        '创建表结构
        dtSkd.Columns.Add("xz", Type.GetType("System.Boolean"))
        dtSkd.Columns.Add("skrq", Type.GetType("System.DateTime"))
        dtSkd.Columns.Add("skdjh", Type.GetType("System.String"))
        dtSkd.Columns.Add("skzy", Type.GetType("System.String"))
        dtSkd.Columns.Add("skje", Type.GetType("System.Double"))
        dtSkd.Columns.Add("yusje", Type.GetType("System.Double"))
        rcDataSet.Tables.Add(dtSkd)
        With rcDataSet.Tables("rc_skdnr")
            .Columns("xz").DefaultValue = 0
            .Columns("skdjh").DefaultValue = ""
            .Columns("skzy").DefaultValue = ""
            .Columns("skje").DefaultValue = 0.0
            .Columns("yusje").DefaultValue = 0.0
        End With
        '绑定数据the DataGrid to the DataSet.
        Me.BindingSourceSkd.DataSource = dtSkd
        Me.DataGridViewSkd.DataSource = Me.BindingSourceSkd

        NewEvent()
    End Sub

#End Region

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDjh.KeyPress, DtpSkrq.KeyPress, TxtKhdm.KeyPress, TxtJsfsdm.KeyPress, TxtKmdm.KeyPress, TxtYspz.KeyPress, TxtYisje.KeyPress, TxtYusje.KeyPress, TxtSkje.KeyPress, TxtWsje.KeyPress, TxtQtys.KeyPress, TxtSkmemo.KeyPress
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
        If rcDataSet.Tables("rc_pzno") Is Nothing Then
            Return
        End If
        '判断增加还是修改
        rcOleDbConn.Open()
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            If rcDataSet.Tables("rc_pzno").Rows.Count > 0 Then
                If rcDataSet.Tables("rc_pzno").Rows(0).Item("pzno") >= Mid(Trim(Me.TxtDjh.Text), 11, 5) Then
                    '修改单据
                    rcOleDbCommand.CommandText = "SELECT ar_skd.djh,ar_skd.skrq,ar_skd.khdm,ar_skd.khmc,ar_skd.jsfsdm,ar_skd.jsfsmc,ar_skd.kmdm,ar_skd.kmmc,ar_skd.yspz,ar_skd.je,ar_skd.xsje,ar_skd.skmemo,ar_skd.srr,ar_skd.shr,ar_skd.jzr FROM ar_skd WHERE (ar_skd.djh = ? )"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.TxtDjh.Text
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataSet.Tables("rc_skd") IsNot Nothing Then
                        Me.rcDataSet.Tables("rc_skd").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataSet, "rc_skd")
                    If rcDataSet.Tables("rc_skd").Rows.Count > 0 Then
                        If rcDataSet.Tables("rc_skd").Rows(0).Item("jzr").GetType.ToString <> "System.DBNull" Then
                            MsgBox("该单据已经记账，不能修改。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                            Me.TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataSet.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                            IsAdding = True
                        Else
                            If rcDataSet.Tables("rc_skd").Rows(0).Item("shr").GetType.ToString <> "System.DBNull" Then
                                MsgBox("该单据已经审核，不能修改。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                                Me.TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataSet.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                                IsAdding = True
                            Else
                                If rcDataSet.Tables("rc_skd").Rows(0).Item("xsje") <> 0 Then
                                    MsgBox("该单据已经被核销，不能修改。如需修改请先取消核销。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                                    Me.TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataSet.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
                                    IsAdding = True
                                Else
                                    Me.DtpSkrq.Value = rcDataSet.Tables("rc_skd").Rows(0).Item("skrq")
                                    Me.TxtKhdm.Text = Trim(rcDataSet.Tables("rc_skd").Rows(0).Item("khdm"))
                                    Me.LblKhmc.Text = rcDataSet.Tables("rc_skd").Rows(0).Item("khmc")
                                    If rcDataSet.Tables("rc_skd").Rows(0).Item("jsfsdm").GetType.ToString <> "System.DBNull" Then
                                        Me.TxtJsfsdm.Text = rcDataSet.Tables("rc_skd").Rows(0).Item("jsfsdm")
                                    Else
                                        Me.TxtJsfsdm.Text = ""
                                    End If
                                    If rcDataSet.Tables("rc_skd").Rows(0).Item("jsfsmc").GetType.ToString <> "System.DBNull" Then
                                        Me.LblJsfsmc.Text = rcDataSet.Tables("rc_skd").Rows(0).Item("jsfsmc")
                                    Else
                                        Me.LblJsfsmc.Text = ""
                                    End If
                                    If rcDataSet.Tables("rc_skd").Rows(0).Item("kmdm").GetType.ToString <> "System.DBNull" Then
                                        Me.TxtKmdm.Text = rcDataSet.Tables("rc_skd").Rows(0).Item("kmdm")
                                    Else
                                        Me.TxtKmdm.Text = ""
                                    End If
                                    If rcDataSet.Tables("rc_skd").Rows(0).Item("kmmc").GetType.ToString <> "System.DBNull" Then
                                        Me.LblKmmc.Text = rcDataSet.Tables("rc_skd").Rows(0).Item("kmmc")
                                    Else
                                        Me.LblKmmc.Text = ""
                                    End If
                                    If rcDataSet.Tables("rc_skd").Rows(0).Item("yspz").GetType.ToString <> "System.DBNull" Then
                                        Me.TxtYspz.Text = rcDataSet.Tables("rc_skd").Rows(0).Item("yspz")
                                    Else
                                        Me.TxtYspz.Text = ""
                                    End If
                                    Me.TxtSkje.Text = rcDataSet.Tables("rc_skd").Rows(0).Item("je")
                                    If rcDataSet.Tables("rc_skd").Rows(0).Item("skmemo").GetType.ToString <> "System.DBNull" Then
                                        Me.TxtSkmemo.Text = rcDataSet.Tables("rc_skd").Rows(0).Item("skmemo")
                                    Else
                                        Me.TxtSkmemo.Text = ""
                                    End If
                                    If rcDataSet.Tables("rc_skd").Rows(0).Item("xsje") <> 0 Then
                                        Me.TxtSkje.ReadOnly = True
                                    Else
                                        Me.TxtSkje.ReadOnly = False
                                    End If
                                    If dtFp IsNot Nothing Then
                                        dtFp.Clear()
                                    End If
                                    If dtSkd IsNot Nothing Then
                                        dtSkd.Clear()
                                    End If
                                    IsAdding = False
                                End If
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

#Region "收款日期的事件"

    Private Sub DtpSkrq_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DtpSkrq.Validating
        Dim dateBegin As DateTime
        Dim dateEnd As DateTime
        dateBegin = getInvBegin(strYear, strMonth)
        dateEnd = getInvEnd(strYear, strMonth)
        If DtpSkrq.Value > dateEnd Or DtpSkrq.Value < dateBegin Then
            MsgBox("您输入的日期不在当前会计期间中，请重输入。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Me.DtpSkrq.Focus()
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
                    .paraCondition = "0=0"
                    .paraOrderField = "khmc"
                    .paraTitle = "客户"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtKhdm.Text = Trim(.paraField1)
                        LblKhmc.Text = Trim(.paraField2)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtKhdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtKhdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtKhdm.Text) And IsAdding Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_khxx WHERE (khdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKhdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_khxx") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_khxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_khxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_khxx").Rows.Count > 0 Then
                TxtKhdm.Text = Trim(rcDataSet.Tables("rc_khxx").Rows(0).Item("khdm"))
                LblKhmc.Text = rcDataSet.Tables("rc_khxx").Rows(0).Item("khmc")
            Else
                e.Cancel = True
                Return
            End If
            '取应收明细
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT 0 AS xz,oe_fp.fprq,'(' ||cpdm || ')' || cpmc || dw || fpmemo AS xszy,sl AS xssl,oe_fp.dj AS xsdj,oe_fp.hsdj AS xshsdj,oe_fp.je AS xsje,oe_fp.shlv AS xsshlv,oe_fp.se AS xsse,oe_fp.je + oe_fp.se AS xsjese,oe_fp.skje As yisje,oe_fp.djh,oe_fp.xh FROM oe_fp WHERE oe_fp.bdelete = 0 AND oe_fp.je + oe_fp.se <> skje AND khdm = ? ORDER BY fprq,djh,xh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtKhdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_fpnr") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_fpnr").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_fpnr")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            Me.TxtYisje.Text = Format(0.0, g_FormatJe)
            '取收款明细
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT 0 AS xz,skrq,yspz || skmemo skzy,je AS skje,je - xsje AS yusje,djh FROM ar_skd WHERE je <> xsje AND khdm = ? ORDER BY skrq,djh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtKhdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_skdnr") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_skdnr").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_skdnr")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            'If rcDataSet.Tables("rc_skdnr").Rows.Count > 0 Then
            '    Me.TxtYusje.Text = dtSkd.Compute("Sum(yusje)", "")
            'Else
            '    Me.TxtYusje.Text = 0.0
            'End If

        End If
    End Sub

#End Region

#Region "结算方式事件"

    Private Sub TxtJsfsdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtJsfsdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_jsfs"
                    .paraField1 = "jsfsdm"
                    .paraField2 = "jsfsmc"
                    .paraField3 = "jsfssm"
                    .paraCondition = "0=0"
                    .paraOrderField = "jsfsdm"
                    .paraTitle = "结算方式"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtJsfsdm.Text = Trim(.paraField1)
                        LblJsfsmc.Text = Trim(.paraField2)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtJsfsdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtJsfsdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtJsfsdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_jsfs WHERE jsfsdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@jsfsdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtJsfsdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_jsfs") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_jsfs").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_jsfs")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_jsfs").Rows.Count > 0 Then
                TxtJsfsdm.Text = Trim(rcDataSet.Tables("rc_jsfs").Rows(0).Item("jsfsdm"))
                LblJsfsmc.Text = rcDataSet.Tables("rc_jsfs").Rows(0).Item("jsfsmc")
            Else
                MsgBox("编码不存在。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                e.Cancel = True
                Return
            End If
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
                If rcDataSet.Tables("gl_kmxx") IsNot Nothing Then
                    Me.rcDataSet.Tables("gl_kmxx").Clear()
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
        Me.TxtKhdm.Text = ""
        Me.LblKhmc.Text = ""
        Me.TxtJsfsdm.Text = ""
        Me.LblJsfsmc.Text = ""
        Me.TxtKmdm.Text = ""
        Me.LblKmmc.Text = ""
        Me.TxtYspz.Text = ""
        Me.TxtYisje.Text = Format(0.0, g_FormatJe)
        Me.TxtYusje.Text = Format(0.0, g_FormatJe)
        Me.TxtSkje.Text = Format(0.0, g_FormatJe)
        Me.TxtSkmemo.Text = ""
        Me.TxtWsje.Text = Format(0.0, g_FormatJe)
        Me.TxtQtys.Text = Format(0.0, g_FormatJe)
        Me.TxtSkje.ReadOnly = False
        IsAdding = True
        IsEditing = False
        If dtFp IsNot Nothing Then
            dtFp.Clear()
        End If
        If dtSkd IsNot Nothing Then
            dtSkd.Clear()
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
                rcOleDbCommand.CommandText = "SELECT pzno" & strMonth & " as pzno FROM rc_lx WHERE pzlxdm = ? AND  lxgs = '收款单' AND kjnd = '" & strYear & "'"
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
        Dim j As Integer
        Dim dblSkje As Double = Val(Me.TxtYusje.Text) + Val(Me.TxtSkje.Text) - Val(Me.TxtQtys.Text)
        Dim dblXsje As Double = Val(Me.TxtYisje.Text)
        Dim dblHxje As Double = 0.0
        '(一)数据合法性检查
        '(1)是否有需要存储的数据
        If Val(Me.TxtSkje.Text) = 0 Then
            MsgBox("请输入收款金额。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        '(2)客户检查
        If Trim(Me.TxtKhdm.Text).Length = 0 Then
            MsgBox("请输入客户编码。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
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
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '(2)结算方式检查
        If Trim(Me.TxtJsfsdm.Text).Length = 0 Then
            MsgBox("请输入结算方式。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Trim(Me.TxtJsfsdm.Text)
            rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_jsfs"
            rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "jsfsdm"
            rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
            rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
            rcOleDbCommand.ExecuteNonQuery()
            If rcOleDbCommand.Parameters.Item("@paraIntRecordCount").Value <> 1 Then
                MsgBox(Trim(Me.TxtJsfsdm.Text) & "结算方式编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                Me.TxtJsfsdm.Text = ""
                Me.LblJsfsmc.Text = ""
                Me.TxtJsfsdm.Focus()
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
        If Val(Me.TxtSkje.Text) = Val(Me.TxtYisje.Text) - Val(Me.TxtYusje.Text) Then
            '(1)收款金额 ＝ 应收金额 － 预收金额
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            Try
                rcOleDbCommand.CommandType = CommandType.Text
                '保存历史销售单上的收款金额
                For i = 0 To rcDataset.Tables("rc_fpnr").Rows.Count - 1
                    If rcDataset.Tables("rc_fpnr").Rows(i).Item("xz") Then
                        rcOleDbCommand.CommandText = "UPDATE oe_fp SET skje = je + se WHERE djh = ? AND xh = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("djh")
                        rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("xh")
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                Next
                '保历史收款单上的销售金额
                rcOleDbCommand.CommandType = CommandType.Text
                For i = 0 To rcDataset.Tables("rc_skdnr").Rows.Count - 1
                    If rcDataset.Tables("rc_skdnr").Rows(i).Item("xz") Then
                        rcOleDbCommand.CommandText = "UPDATE ar_skd SET xsje = je WHERE djh = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_skdnr").Rows(i).Item("djh")
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                Next
                If Val(Me.TxtSkje.Text) <> 0 Then
                    rcOleDbCommand.CommandType = CommandType.StoredProcedure
                    rcOleDbCommand.CommandText = "USP3_SAVE_AR_SKD"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = IIf(IsAdding, 1, 0)
                    rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = Trim(Me.TxtDjh.Text)
                    rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                    rcOleDbCommand.Parameters.Add("@paraDateSkrq", OleDbType.Date, 8).Value = DtpSkrq.Value
                    rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = Me.TxtKhdm.Text
                    rcOleDbCommand.Parameters.Add("@paraStrKhmc", OleDbType.VarChar, 50).Value = Me.LblKhmc.Text
                    rcOleDbCommand.Parameters.Add("@paraStrJsfsdm", OleDbType.VarChar, 12).Value = Me.TxtJsfsdm.Text
                    rcOleDbCommand.Parameters.Add("@paraStrJsfsmc", OleDbType.VarChar, 30).Value = Me.LblJsfsmc.Text
                    rcOleDbCommand.Parameters.Add("@paraStrKmdm", OleDbType.VarChar, 12).Value = Me.TxtKmdm.Text
                    rcOleDbCommand.Parameters.Add("@paraStrKmmc", OleDbType.VarChar, 50).Value = Me.LblKmmc.Text
                    rcOleDbCommand.Parameters.Add("@paraStrYspz", OleDbType.VarChar, 12).Value = Me.TxtYspz.Text
                    rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = Val(Me.TxtSkje.Text) '收款金额
                    rcOleDbCommand.Parameters.Add("@paraDblXsje", OleDbType.Numeric, 14).Value = Val(Me.TxtSkje.Text) '收款金额
                    rcOleDbCommand.Parameters.Add("@paraStrSkmemo", OleDbType.VarChar, 50).Value = Trim(TxtSkmemo.Text) '备注
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
                    '保存核销记录
                    rcOleDbCommand.CommandType = CommandType.Text
                    For i = 0 To rcDataset.Tables("rc_skdnr").Rows.Count - 1
                        If rcDataset.Tables("rc_skdnr").Rows(i).Item("xz") Then
                            For j = 0 To rcDataset.Tables("rc_fpnr").Rows.Count - 1
                                If rcDataset.Tables("rc_fpnr").Rows(j).Item("xz") And rcDataset.Tables("rc_skdnr").Rows(i).Item("yusje") <> 0 And rcDataset.Tables("rc_fpnr").Rows(j).Item("xsjese") - rcDataset.Tables("rc_fpnr").Rows(j).Item("yisje") <> 0 Then
                                    dblHxje = IIf(rcDataset.Tables("rc_fpnr").Rows(j).Item("xsjese") - rcDataset.Tables("rc_fpnr").Rows(j).Item("yisje") <= rcDataset.Tables("rc_skdnr").Rows(i).Item("yusje"), rcDataset.Tables("rc_fpnr").Rows(j).Item("xsjese") - rcDataset.Tables("rc_fpnr").Rows(j).Item("yisje"), rcDataset.Tables("rc_skdnr").Rows(i).Item("yusje"))
                                    rcDataset.Tables("rc_fpnr").Rows(j).Item("yisje") = rcDataset.Tables("rc_fpnr").Rows(j).Item("yisje") + dblHxje
                                    rcDataset.Tables("rc_skdnr").Rows(i).Item("yusje") = rcDataset.Tables("rc_skdnr").Rows(i).Item("yusje") - dblHxje
                                    rcOleDbCommand.CommandText = "INSERT INTO ar_xsdskd (xsddjh,xsdxh,skddjh,je) VALUES (?,?,?,?)"
                                    rcOleDbCommand.Parameters.Clear()
                                    rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_fpnr").Rows(j).Item("djh")
                                    rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = rcDataset.Tables("rc_fpnr").Rows(j).Item("xh")
                                    rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_skdnr").Rows(i).Item("djh")
                                    rcOleDbCommand.Parameters.Add("@paraDblXsje", OleDbType.Numeric, 14).Value = dblHxje
                                    rcOleDbCommand.ExecuteNonQuery()
                                End If
                            Next
                        End If
                    Next
                    '
                    For j = 0 To rcDataset.Tables("rc_fpnr").Rows.Count - 1
                        If rcDataset.Tables("rc_fpnr").Rows(j).Item("xz") And Val(Me.TxtSkje.Text) <> 0 And Not Me.TxtSkje.ReadOnly And rcDataset.Tables("rc_fpnr").Rows(j).Item("xsjese") - rcDataset.Tables("rc_fpnr").Rows(j).Item("yisje") <> 0 Then
                            dblHxje = IIf(rcDataset.Tables("rc_fpnr").Rows(j).Item("xsjese") - rcDataset.Tables("rc_fpnr").Rows(j).Item("yisje") <= Val(Me.TxtSkje.Text), rcDataset.Tables("rc_fpnr").Rows(j).Item("xsjese") - rcDataset.Tables("rc_fpnr").Rows(j).Item("yisje"), Val(Me.TxtSkje.Text))
                            rcDataset.Tables("rc_fpnr").Rows(j).Item("yisje") = rcDataset.Tables("rc_fpnr").Rows(j).Item("yisje") + dblHxje
                            Me.TxtSkje.Text = Val(Me.TxtSkje.Text) - dblHxje
                            rcOleDbCommand.CommandText = "INSERT INTO ar_xsdskd (xsddjh,xsdxh,skddjh,je) VALUES (?,?,?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_fpnr").Rows(j).Item("djh")
                            rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = rcDataset.Tables("rc_fpnr").Rows(j).Item("xh")
                            rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = Me.TxtDjh.Text
                            rcOleDbCommand.Parameters.Add("@paraDblXsje", OleDbType.Numeric, 14).Value = dblHxje
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    Next
                End If
                rcOleDbTrans.Commit()
            Catch ex As Exception
                MsgBox("执行存储过程发生了错误：" & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        Else
            '(2)收款金额 <> 应收金额 － 预收金额 (进行按时间顺序核销)
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            Try
                If IsAdding Then
                    rcOleDbCommand.CommandType = CommandType.Text
                    '保存历史销售单上的收款金额
                    For i = 0 To rcDataset.Tables("rc_fpnr").Rows.Count - 1
                        If rcDataset.Tables("rc_fpnr").Rows(i).Item("xz") And dblSkje <> 0 Then
                            rcOleDbCommand.CommandText = "UPDATE oe_fp SET skje = skje + ? WHERE djh = ? AND xh = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@paraDblSkje", OleDbType.Numeric, 14).Value = IIf(dblSkje >= rcDataset.Tables("rc_fpnr").Rows(i).Item("xsjese") - rcDataset.Tables("rc_fpnr").Rows(i).Item("yisje"), rcDataset.Tables("rc_fpnr").Rows(i).Item("xsjese") - rcDataset.Tables("rc_fpnr").Rows(i).Item("yisje"), dblSkje)
                            rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("djh")
                            rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("xh")
                            rcOleDbCommand.ExecuteNonQuery()
                            dblHxje += IIf(dblSkje >= rcDataset.Tables("rc_fpnr").Rows(i).Item("xsjese") - rcDataset.Tables("rc_fpnr").Rows(i).Item("yisje"), rcDataset.Tables("rc_fpnr").Rows(i).Item("xsjese") - rcDataset.Tables("rc_fpnr").Rows(i).Item("yisje"), dblSkje)
                            dblSkje -= IIf(dblSkje >= rcDataset.Tables("rc_fpnr").Rows(i).Item("xsjese") - rcDataset.Tables("rc_fpnr").Rows(i).Item("yisje"), rcDataset.Tables("rc_fpnr").Rows(i).Item("xsjese") - rcDataset.Tables("rc_fpnr").Rows(i).Item("yisje"), dblSkje)
                        End If
                    Next
                    '保历史收款单上的销售金额
                    rcOleDbCommand.CommandType = CommandType.Text
                    For i = 0 To rcDataset.Tables("rc_skdnr").Rows.Count - 1
                        If rcDataset.Tables("rc_skdnr").Rows(i).Item("xz") Then
                            rcOleDbCommand.CommandText = "UPDATE ar_skd SET xsje = xsje + ? WHERE djh = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@paraDblXsje", OleDbType.Numeric, 14).Value = IIf(dblXsje >= rcDataset.Tables("rc_skdnr").Rows(i).Item("yusje"), rcDataset.Tables("rc_skdnr").Rows(i).Item("yusje"), dblXsje)
                            rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_skdnr").Rows(i).Item("djh")
                            rcOleDbCommand.ExecuteNonQuery()
                            dblHxje -= IIf(dblXsje >= rcDataset.Tables("rc_skdnr").Rows(i).Item("yusje"), rcDataset.Tables("rc_skdnr").Rows(i).Item("yusje"), dblXsje)
                            dblXsje -= IIf(dblXsje >= rcDataset.Tables("rc_skdnr").Rows(i).Item("yusje"), rcDataset.Tables("rc_skdnr").Rows(i).Item("yusje"), dblXsje)
                        End If
                    Next
                End If
                rcOleDbCommand.CommandType = CommandType.StoredProcedure
                rcOleDbCommand.CommandText = "USP3_SAVE_AR_SKD"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = IIf(IsAdding, 1, 0)
                rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = Trim(Me.TxtDjh.Text)
                rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                rcOleDbCommand.Parameters.Add("@paraDateSkrq", OleDbType.Date, 8).Value = DtpSkrq.Value
                rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = Me.TxtKhdm.Text
                rcOleDbCommand.Parameters.Add("@paraStrKhmc", OleDbType.VarChar, 50).Value = Me.LblKhmc.Text
                rcOleDbCommand.Parameters.Add("@paraStrJsfsdm", OleDbType.VarChar, 12).Value = Me.TxtJsfsdm.Text
                rcOleDbCommand.Parameters.Add("@paraStrJsfsmc", OleDbType.VarChar, 30).Value = Me.LblJsfsmc.Text
                rcOleDbCommand.Parameters.Add("@paraStrKmdm", OleDbType.VarChar, 12).Value = Me.TxtKmdm.Text
                rcOleDbCommand.Parameters.Add("@paraStrKmmc", OleDbType.VarChar, 50).Value = Me.LblKmmc.Text
                rcOleDbCommand.Parameters.Add("@paraStrYspz", OleDbType.VarChar, 12).Value = Me.TxtYspz.Text
                rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = Val(Me.TxtSkje.Text) '收款金额
                If IsAdding Then
                    rcOleDbCommand.Parameters.Add("@paraDblXsje", OleDbType.Numeric, 14).Value = dblHxje + Val(Me.TxtQtys.Text) '收款金额
                Else
                    If rcDataset.Tables("rc_skd").Rows(0).Item("xsje").GetType.ToString <> "System.DBNull" Then
                        rcOleDbCommand.Parameters.Add("@paraDblXsje", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_skd").Rows(0).Item("xsje") '收款金额
                    Else
                        rcOleDbCommand.Parameters.Add("@paraDblXsje", OleDbType.Numeric, 14).Value = 0.0 '收款金额
                    End If
                End If
                rcOleDbCommand.Parameters.Add("@paraStrSkmemo", OleDbType.VarChar, 50).Value = Trim(TxtSkmemo.Text) '备注
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
                '保存核销记录
                rcOleDbCommand.CommandType = CommandType.Text
                For i = 0 To rcDataset.Tables("rc_skdnr").Rows.Count - 1
                    If rcDataset.Tables("rc_skdnr").Rows(i).Item("xz") Then
                        For j = 0 To rcDataset.Tables("rc_fpnr").Rows.Count - 1
                            If rcDataset.Tables("rc_fpnr").Rows(j).Item("xz") And rcDataset.Tables("rc_skdnr").Rows(i).Item("yusje") <> 0 And rcDataset.Tables("rc_fpnr").Rows(j).Item("xsjese") - rcDataset.Tables("rc_fpnr").Rows(j).Item("yisje") <> 0 Then
                                dblHxje = IIf(rcDataset.Tables("rc_fpnr").Rows(j).Item("xsjese") - rcDataset.Tables("rc_fpnr").Rows(j).Item("yisje") <= rcDataset.Tables("rc_skdnr").Rows(i).Item("yusje"), rcDataset.Tables("rc_fpnr").Rows(j).Item("xsjese") - rcDataset.Tables("rc_fpnr").Rows(j).Item("yisje"), rcDataset.Tables("rc_skdnr").Rows(i).Item("yusje"))
                                rcDataset.Tables("rc_fpnr").Rows(j).Item("yisje") = rcDataset.Tables("rc_fpnr").Rows(j).Item("yisje") + dblHxje
                                rcDataset.Tables("rc_skdnr").Rows(i).Item("yusje") = rcDataset.Tables("rc_skdnr").Rows(i).Item("yusje") - dblHxje
                                rcOleDbCommand.CommandText = "INSERT INTO ar_xsdskd (xsddjh,xsdxh,skddjh,je) VALUES (?,?,?,?)"
                                rcOleDbCommand.Parameters.Clear()
                                rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_fpnr").Rows(j).Item("djh")
                                rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = rcDataset.Tables("rc_fpnr").Rows(j).Item("xh")
                                rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_skdnr").Rows(i).Item("djh")
                                rcOleDbCommand.Parameters.Add("@paraDblXsje", OleDbType.Numeric, 14).Value = dblHxje
                                rcOleDbCommand.ExecuteNonQuery()
                            End If
                        Next
                    End If
                Next
                '
                For j = 0 To rcDataset.Tables("rc_fpnr").Rows.Count - 1
                    If rcDataset.Tables("rc_fpnr").Rows(j).Item("xz") And Val(Me.TxtSkje.Text) <> 0 And Not Me.TxtSkje.ReadOnly And rcDataset.Tables("rc_fpnr").Rows(j).Item("xsjese") - rcDataset.Tables("rc_fpnr").Rows(j).Item("yisje") <> 0 Then
                        dblHxje = IIf(rcDataset.Tables("rc_fpnr").Rows(j).Item("xsjese") - rcDataset.Tables("rc_fpnr").Rows(j).Item("yisje") <= Val(Me.TxtSkje.Text), rcDataset.Tables("rc_fpnr").Rows(j).Item("xsjese") - rcDataset.Tables("rc_fpnr").Rows(j).Item("yisje"), Val(Me.TxtSkje.Text))
                        rcDataset.Tables("rc_fpnr").Rows(j).Item("yisje") = rcDataset.Tables("rc_fpnr").Rows(j).Item("yisje") + dblHxje
                        Me.TxtSkje.Text = Val(Me.TxtSkje.Text) - dblHxje
                        rcOleDbCommand.CommandText = "INSERT INTO ar_xsdskd (xsddjh,xsdxh,skddjh,je) VALUES (?,?,?,?)"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_fpnr").Rows(j).Item("djh")
                        rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = rcDataset.Tables("rc_fpnr").Rows(j).Item("xh")
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = Me.TxtDjh.Text
                        rcOleDbCommand.Parameters.Add("@paraDblXsje", OleDbType.Numeric, 14).Value = dblHxje
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                Next
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

    Private Sub DataGridViewXsd_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DataGridViewXsd.CellValidating
        If Me.DataGridViewXsd.IsCurrentCellDirty Then
            Me.DataGridViewXsd.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
        '汇总本次应收金额
        Me.TxtYisje.Text = Format(0.0, g_FormatJe)
        Dim i As Integer
        For i = 0 To rcDataset.Tables("rc_fpnr").Rows.Count - 1
            If rcDataset.Tables("rc_fpnr").Rows(i).Item("xz").GetType.ToString <> "System.DBNull" Then
                If rcDataset.Tables("rc_fpnr").Rows(i).Item("xz") Then
                    Me.TxtYisje.Text = Val(Me.TxtYisje.Text) + rcDataset.Tables("rc_fpnr").Rows(i).Item("xsjese") - rcDataset.Tables("rc_fpnr").Rows(i).Item("yisje")
                End If
            End If
        Next
        If String.IsNullOrEmpty(Me.TxtYisje.Text) Then
            Me.TxtYisje.Text = Format(0.0, g_FormatJe)
        Else
            Me.TxtYisje.Text = Format(Val(Me.TxtYisje.Text), g_FormatJe0)
        End If
        If String.IsNullOrEmpty(Me.TxtYusje.Text) Then
            Me.TxtYusje.Text = Format(0.0, g_FormatJe)
        End If
        If String.IsNullOrEmpty(Me.TxtQtys.Text) Then
            Me.TxtQtys.Text = Format(0.0, g_FormatJe)
        End If
        If String.IsNullOrEmpty(Me.TxtSkje.Text) Then
            Me.TxtSkje.Text = Format(0.0, g_FormatJe)
        End If
        Me.TxtWsje.Text = Val(Me.TxtYisje.Text) - Val(Me.TxtYusje.Text) + Val(Me.TxtQtys.Text) - Val(Me.TxtSkje.Text)
    End Sub

    Private Sub DataGridViewXsd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewXsd.Leave
        Me.DataGridViewXsd.ClearSelection()
    End Sub

    Private Sub BtnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectAll.Click
        '汇总本次应收金额
        Me.TxtYisje.Text = Format(0.0, g_FormatJe)
        Dim i As Integer
        For i = 0 To rcDataset.Tables("rc_fpnr").Rows.Count - 1
            rcDataset.Tables("rc_fpnr").Rows(i).Item("xz") = True
            Me.TxtYisje.Text = Val(Me.TxtYisje.Text) + rcDataset.Tables("rc_fpnr").Rows(i).Item("xsjese") - rcDataset.Tables("rc_fpnr").Rows(i).Item("yisje")
        Next
        If String.IsNullOrEmpty(Me.TxtYisje.Text) Then
            Me.TxtYisje.Text = Format(0.0, g_FormatJe)
        Else
            Me.TxtYisje.Text = Format(Val(Me.TxtYisje.Text), g_FormatJe0)
        End If
        If String.IsNullOrEmpty(Me.TxtYusje.Text) Then
            Me.TxtYusje.Text = Format(0.0, g_FormatJe)
        End If
        If String.IsNullOrEmpty(Me.TxtQtys.Text) Then
            Me.TxtQtys.Text = Format(0.0, g_FormatJe)
        End If
        If String.IsNullOrEmpty(Me.TxtSkje.Text) Then
            Me.TxtSkje.Text = Format(0.0, g_FormatJe)
        End If
        Me.TxtWsje.Text = Val(Me.TxtYisje.Text) - Val(Me.TxtYusje.Text) + Val(Me.TxtQtys.Text) - Val(Me.TxtSkje.Text)
        If String.IsNullOrEmpty(Me.TxtWsje.Text) Then
            Me.TxtWsje.Text = Format(0.0, g_FormatJe)
        Else
            Me.TxtWsje.Text = Format(Val(Me.TxtWsje.Text), g_FormatJe0)
        End If
    End Sub

    Private Sub DataGridViewSkd_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DataGridViewSkd.CellValidating
        If Me.DataGridViewSkd.IsCurrentCellDirty Then
            Me.DataGridViewSkd.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
        '汇总本次应收金额
        Me.TxtYusje.Text = Format(0.0, g_FormatJe)
        Dim i As Integer
        For i = 0 To rcDataSet.Tables("rc_skdnr").Rows.Count - 1
            If rcDataSet.Tables("rc_skdnr").Rows(i).Item("xz").GetType.ToString <> "System.DBNull" Then
                If rcDataSet.Tables("rc_skdnr").Rows(i).Item("xz") Then
                    Me.TxtYusje.Text = Val(Me.TxtYusje.Text) + rcDataSet.Tables("rc_skdnr").Rows(i).Item("yusje")
                End If
            End If
        Next
        If String.IsNullOrEmpty(Me.TxtYisje.Text) Then
            Me.TxtYisje.Text = Format(0.0, g_FormatJe)
        End If
        If String.IsNullOrEmpty(Me.TxtYusje.Text) Then
            Me.TxtYusje.Text = Format(0.0, g_FormatJe)
        Else
            Me.TxtYusje.Text = Format(Val(Me.TxtYusje.Text), g_FormatJe0)
        End If
        If String.IsNullOrEmpty(Me.TxtQtys.Text) Then
            Me.TxtQtys.Text = Format(0.0, g_FormatJe)
        End If
        If String.IsNullOrEmpty(Me.TxtSkje.Text) Then
            Me.TxtSkje.Text = Format(0.0, g_FormatJe)
        End If
        Me.TxtWsje.Text = Val(Me.TxtYisje.Text) - Val(Me.TxtYusje.Text) + Val(Me.TxtQtys.Text) - Val(Me.TxtSkje.Text)
        If String.IsNullOrEmpty(Me.TxtWsje.Text) Then
            Me.TxtWsje.Text = Format(0.0, g_FormatJe)
        Else
            Me.TxtWsje.Text = Format(Val(Me.TxtWsje.Text), g_FormatJe0)
        End If
    End Sub

    Private Sub DataGridViewSkd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewSkd.Leave
        Me.DataGridViewSkd.ClearSelection()
    End Sub

    Private Sub TxtSkje_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtSkje.Validating, TxtQtys.Validating
        '计算未收金额
        If String.IsNullOrEmpty(Me.TxtYisje.Text) Then
            Me.TxtYisje.Text = Format(0.0, g_FormatJe)
        End If
        If String.IsNullOrEmpty(Me.TxtYusje.Text) Then
            Me.TxtYusje.Text = Format(0.0, g_FormatJe)
        End If
        If String.IsNullOrEmpty(Me.TxtQtys.Text) Then
            Me.TxtQtys.Text = Format(0.0, g_FormatJe)
        End If
        If String.IsNullOrEmpty(Me.TxtSkje.Text) Then
            Me.TxtSkje.Text = Format(0.0, g_FormatJe)
        Else
            Me.TxtSkje.Text = Format(Val(Me.TxtSkje.Text), g_FormatJe0)
        End If
        Me.TxtWsje.Text = Val(Me.TxtYisje.Text) - Val(Me.TxtYusje.Text) + Val(Me.TxtQtys.Text) - Val(Me.TxtSkje.Text)
        If String.IsNullOrEmpty(Me.TxtWsje.Text) Then
            Me.TxtWsje.Text = Format(0.0, g_FormatJe)
        Else
            Me.TxtWsje.Text = Format(Val(Me.TxtWsje.Text), g_FormatJe0)
        End If
    End Sub

End Class