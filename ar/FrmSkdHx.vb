Imports System.Data.OleDb

Public Class FrmSkdHx

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
    ReadOnly IsAdding As Boolean = False
    '修改单据的变量
    ReadOnly IsEditing As Boolean = False
    '数据绑定
    ReadOnly rcBmb As BindingManagerBase
    '建立打印文档
    ReadOnly rcRps As RPS.Document
    '会计期间
    ReadOnly strKjqj As String = g_Kjqj
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

    Private Sub FrmSkdHx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    End Sub

#End Region

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKhdm.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
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
        If Not String.IsNullOrEmpty(Me.TxtKhdm.Text) Then
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
            ReadData()
        End If
    End Sub

#End Region

#Region "包含已核销数据选项"

    Private Sub ChbHx_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbHx.CheckedChanged
        If Me.ChbHx.Checked Then
            Me.BtnCancel.Enabled = True
        Else
            Me.BtnCancel.Enabled = False
        End If
        ReadData()
    End Sub

#End Region

#Region "读取数据"

    Private Sub ReadData()
        If Not String.IsNullOrEmpty(Me.TxtKhdm.Text) Then
            '取应收明细
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT 0 AS xz,oe_fp.fprq,'(' ||cpdm || ')' || cpmc || dw || fpmemo AS xszy,sl AS xssl,oe_fp.dj AS xsdj,oe_fp.hsdj AS xshsdj,oe_fp.je AS xsje,oe_fp.shlv AS xsshlv,oe_fp.se AS xsse,oe_fp.je + oe_fp.se AS xsjese,oe_fp.skje As yisje,oe_fp.djh,oe_fp.xh FROM oe_fp WHERE oe_fp.bdelete = 0" & IIf(Me.ChbHx.Checked, "", " AND oe_fp.je + oe_fp.se <> skje") & " AND khdm = ? ORDER BY fprq,djh,xh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKhdm.Text)
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
            Me.NudYisje.Value = 0.0
            Me.NudYsyh.Value = 0.0
            '取收款明细
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT 1 AS xz,skrq,yspz || skmemo skzy,je AS skje,je - xsje AS yusje,djh FROM ar_skd WHERE" & IIf(Me.ChbHx.Checked, "", " je <> xsje AND") & " khdm = ? ORDER BY skrq,djh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKhdm.Text)
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
            If rcDataSet.Tables("rc_skdnr").Rows.Count > 0 Then
                Me.NudYusje.Value = dtSkd.Compute("Sum(yusje)", "")
                Me.NudSkyh.Value = dtSkd.Compute("Sum(skje)-Sum(yusje)", "")
            Else
                Me.NudYusje.Value = 0.0
                Me.NudSkyh.Value = 0.0
            End If
        End If
    End Sub
#End Region

#Region "核销的事件"

    Private Sub MnuiSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiSave.Click, BtnSave.Click
        SaveEvent()
    End Sub

    Private Sub SaveEvent()
        Dim i As Integer
        Dim j As Integer
        Dim dblSkje As Double = Me.NudYusje.Value
        Dim dblXsje As Double = Me.NudYisje.Value
        Dim dblHxje As Double = 0.0
        '(一)数据合法性检查
        '(2)客户检查
        If Trim(Me.TxtKhdm.Text).Length = 0 Then
            MsgBox("请输入客户编码。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        '(二)存储skd
        If Me.NudYisje.Value - Me.NudYusje.Value = 0 Then
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
                '保存历史收款单上的销售金额
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
                rcOleDbTrans.Commit()
            Catch ex As Exception
                MsgBox("程序错误：" & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        End If
        '清空数据
        Me.TxtKhdm.Text = ""
        Me.LblKhmc.Text = ""
        Me.NudYisje.Value = 0.0
        Me.NudYusje.Value = 0.0
        Me.NudWsje.Value = 0.0
        Me.NudYsyh.Value = 0.0
        Me.NudSkyh.Value = 0.0
        If dtFp IsNot Nothing Then
            dtFp.Clear()
        End If
        If dtSkd IsNot Nothing Then
            dtSkd.Clear()
        End If
        '设置焦点
        Me.TxtKhdm.Focus()

    End Sub

#End Region

#Region "消核"

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click, MnuiCancel.Click
        Dim i As Integer
        '付款金额 ＝ 应付金额 － 预付金额 
        If Me.NudYsyh.Value - Me.NudSkyh.Value = 0 Then
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                '保存历史销售单上的收款金额
                For i = 0 To rcDataset.Tables("rc_fpnr").Rows.Count - 1
                    If rcDataset.Tables("rc_fpnr").Rows(i).Item("xz") Then
                        rcOleDbCommand.CommandText = "UPDATE oe_fp SET skje = 0.0 WHERE djh = ? AND xh = ?"
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
                        rcOleDbCommand.CommandText = "UPDATE ar_skd SET xsje = 0.0 WHERE djh = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_skdnr").Rows(i).Item("djh")
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                Next
                '保存核销记录
                rcOleDbCommand.CommandType = CommandType.Text
                For i = 0 To rcDataset.Tables("rc_fpnr").Rows.Count - 1
                    If rcDataset.Tables("rc_fpnr").Rows(i).Item("xz") Then
                        rcOleDbCommand.CommandText = "DELETE FROM ar_xsdskd WHERE xsddjh = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("djh")
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                Next
                rcOleDbTrans.Commit()
            Catch ex As Exception
                MsgBox("程序错误1：" & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            '清空数据
            Me.TxtKhdm.Text = ""
            Me.LblKhmc.Text = ""
            Me.NudYisje.Value = 0.0
            Me.NudYusje.Value = 0.0
            Me.NudWsje.Value = 0.0
            Me.NudYsyh.Value = 0.0
            Me.NudSkyh.Value = 0.0
            If dtFp IsNot Nothing Then
                dtFp.Clear()
            End If
            If dtSkd IsNot Nothing Then
                dtSkd.Clear()
            End If
            '设置焦点
            Me.TxtKhdm.Focus()
        Else
            MsgBox("应收账款已核金额与收款单已核金额不等，不能取消核销。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Return
        End If
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
        Me.NudYisje.Value = 0.0
        Me.NudYsyh.Value = 0.0
        Dim i As Integer
        For i = 0 To rcDataset.Tables("rc_fpnr").Rows.Count - 1
            If rcDataset.Tables("rc_fpnr").Rows(i).Item("xz").GetType.ToString <> "System.DBNull" Then
                If rcDataset.Tables("rc_fpnr").Rows(i).Item("xz") Then
                    Me.NudYisje.Value = Me.NudYisje.Value + rcDataset.Tables("rc_fpnr").Rows(i).Item("xsjese") - rcDataset.Tables("rc_fpnr").Rows(i).Item("yisje")
                    Me.NudYsyh.Value = Me.NudYsyh.Value + rcDataset.Tables("rc_fpnr").Rows(i).Item("yisje")
                End If
            End If
        Next
        Me.NudWsje.Value = Me.NudYisje.Value - Me.NudYusje.Value
    End Sub

    Private Sub DataGridViewXsd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewXsd.Leave
        Me.DataGridViewXsd.ClearSelection()
    End Sub

    Private Sub BtnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectAll.Click
        '汇总本次应收金额
        Me.NudYisje.Value = 0.0
        Me.NudYsyh.Value = 0.0
        Dim i As Integer
        For i = 0 To rcDataset.Tables("rc_fpnr").Rows.Count - 1
            rcDataset.Tables("rc_fpnr").Rows(i).Item("xz") = True
            Me.NudYisje.Value = Me.NudYisje.Value + rcDataset.Tables("rc_fpnr").Rows(i).Item("xsjese") - rcDataset.Tables("rc_fpnr").Rows(i).Item("yisje")
            Me.NudYsyh.Value = Me.NudYsyh.Value + rcDataset.Tables("rc_fpnr").Rows(i).Item("yisje")
        Next
        Me.NudWsje.Value = Me.NudYisje.Value - Me.NudYusje.Value
    End Sub

    Private Sub DataGridViewSkd_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DataGridViewSkd.CellValidating
        If Me.DataGridViewSkd.IsCurrentCellDirty Then
            Me.DataGridViewSkd.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
        '汇总本次应收金额
        Me.NudYusje.Value = 0.0
        Me.NudSkyh.Value = 0.0
        Dim i As Integer
        For i = 0 To rcDataSet.Tables("rc_skdnr").Rows.Count - 1
            If rcDataSet.Tables("rc_skdnr").Rows(i).Item("xz").GetType.ToString <> "System.DBNull" Then
                If rcDataSet.Tables("rc_skdnr").Rows(i).Item("xz") Then
                    Me.NudYusje.Value = Me.NudYusje.Value + rcDataSet.Tables("rc_skdnr").Rows(i).Item("yusje")
                    Me.NudSkyh.Value = Me.NudSkyh.Value + rcDataSet.Tables("rc_skdnr").Rows(i).Item("skje") - rcDataSet.Tables("rc_skdnr").Rows(i).Item("yusje")
                End If
            End If
        Next
        Me.NudWsje.Value = Me.NudYisje.Value - Me.NudYusje.Value


    End Sub

    Private Sub DataGridViewSkd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewSkd.Leave
        Me.DataGridViewSkd.ClearSelection()
    End Sub

    Private Sub TxtSkje_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        '计算未收金额
        Me.NudWsje.Value = Me.NudYisje.Value - Me.NudYusje.Value
    End Sub

End Class