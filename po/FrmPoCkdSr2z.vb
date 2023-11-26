Imports System.Data.OleDb
Imports System.Math

Public Class FrmPoCkdSr2z
    '建立OLEDB数据适配器对象
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDb传递对象
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDb命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '数据绑定
    Dim rcBmb As BindingManagerBase
    '建立Datatable '我们要利用该datatable进行金额计算
    ReadOnly dtCkd As New DataTable("rc_ckdnr")
    '建立打印文档
    Dim rcRps As RPS.Document
    Dim strBmdm As String = ""
    Dim strZydm As String = ""
    '
    Dim dblKcsl As Double = 0.0
    '合计变量
    Dim dblTotSl As Double = 0.0
    Dim dblTotFzsl As Double = 0.0
    Dim dblTotJe As Double = 0.0

#Region "初始化"

    Public Property ParaBmdm() As String
        Get
            ParaBmdm = strBmdm
        End Get
        Set(ByVal Value As String)
            strBmdm = Value
        End Set
    End Property

    Public Property ParaZydm() As String
        Get
            ParaZydm = strZydm
        End Get
        Set(ByVal Value As String)
            strZydm = Value
        End Set
    End Property

    Private Sub FrmImportShdz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '设置DataGridView
        Me.rcDataGridView.AutoGenerateColumns = False
        Me.rcDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColMjsl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColMjsl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColFzsl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColFzsl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColDj").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColDj").DefaultCellStyle.Format = g_FormatDj
        Me.rcDataGridView.Columns("ColJe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColJe").DefaultCellStyle.Format = g_FormatJe
        '数据绑定
        If rcDataset.Tables("rc_ckdnr") IsNot Nothing Then
            rcDataset.Tables.Remove("rc_ckdnr")
            'rcDataSet.Tables("rc_ckdnr").Dispose()
        End If
        dtCkd.Columns.Add("xz", Type.GetType("System.Boolean"))
        dtCkd.Columns.Add("cpdm", Type.GetType("System.String"))
        dtCkd.Columns.Add("cpmc", Type.GetType("System.String"))
        dtCkd.Columns.Add("csdm", Type.GetType("System.String"))
        dtCkd.Columns.Add("csmc", Type.GetType("System.String"))
        dtCkd.Columns.Add("brecycling", Type.GetType("System.Boolean"))
        dtCkd.Columns.Add("bfadm", Type.GetType("System.Boolean"))
        dtCkd.Columns.Add("fadm", Type.GetType("System.String"))
        dtCkd.Columns.Add("famc", Type.GetType("System.String"))
        dtCkd.Columns.Add("kuwei", Type.GetType("System.String"))
        dtCkd.Columns.Add("sl", Type.GetType("System.Double"))
        dtCkd.Columns.Add("dw", Type.GetType("System.String"))
        dtCkd.Columns.Add("mjsl", Type.GetType("System.Double"))
        dtCkd.Columns.Add("fzsl", Type.GetType("System.Double"))
        dtCkd.Columns.Add("fzdw", Type.GetType("System.String"))
        dtCkd.Columns.Add("dj", Type.GetType("System.Double"))
        dtCkd.Columns.Add("je", Type.GetType("System.Double"))
        dtCkd.Columns.Add("ckmemo", Type.GetType("System.String"))
        dtCkd.Columns.Add("llsqdjh", Type.GetType("System.String"))
        dtCkd.Columns.Add("llsqxh", Type.GetType("System.Int32"))
        rcDataset.Tables.Add(dtCkd)
        With rcDataset.Tables("rc_ckdnr")
            .Columns("xz").DefaultValue = True
            .Columns("cpdm").DefaultValue = ""
            .Columns("cpmc").DefaultValue = ""
            .Columns("csdm").DefaultValue = ""
            .Columns("csmc").DefaultValue = ""
            .Columns("brecycling").DefaultValue = False
            .Columns("bfadm").DefaultValue = False
            .Columns("fadm").DefaultValue = ""
            .Columns("famc").DefaultValue = ""
            .Columns("kuwei").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("mjsl").DefaultValue = 0.0
            .Columns("fzsl").DefaultValue = 0.0
            .Columns("dj").DefaultValue = 0.0
            .Columns("je").DefaultValue = 0.0
            .Columns("ckmemo").DefaultValue = ""
            .Columns("llsqdjh").DefaultValue = ""
            .Columns("llsqxh").DefaultValue = 0
        End With
        '取单据类型数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE pzlxdm <> 'CKTZ' AND lxgs = '物料出库单' AND kjnd = '" & Mid(g_Kjqj, 1, 4) & "' ORDER BY pzlxdm"
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
        BindDropDownList(CmbPzlxjc, rcDataset.Tables("rc_lx"), "pzlxdm", "pzlxjc")
        ShowNewDjh()
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT inv_llsq.bmdm,inv_llsq.bmmc,inv_llsq.zydm,inv_llsq.zymc,inv_llsq.djh FROM inv_llsq WHERE inv_llsq.bmdm = ? AND inv_llsq.zydm = ? AND ((inv_llsq.sl > inv_llsq.cksl AND inv_llsq.sl > 0) OR (inv_llsq.sl < inv_llsq.cksl AND inv_llsq.sl < 0)) AND inv_llsq.bclosed  = 0 GROUP BY inv_llsq.bmdm,inv_llsq.bmmc,inv_llsq.zydm,inv_llsq.zymc,inv_llsq.djh ORDER BY inv_llsq.djh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = strBmdm
            rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = strZydm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("llsqml") IsNot Nothing Then
                Me.rcDataset.Tables("llsqml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "llsqml")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message)
        Finally
            rcOleDbConn.Close()
        End Try


        rcBmb = Me.BindingContext(rcDataset, "llsqml")
        rcBmb.Position = 0
        If rcDataset.Tables("llsqml").Rows.Count > 0 Then
            ShowLlsq(rcDataset.Tables("llsqml").Rows(0).Item("djh"))
        End If
    End Sub

    Private Sub ShowNewDjh()
        '取单据类型数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzno" & Mid(g_Kjqj, 5, 2) & " As pzno FROM rc_lx WHERE kjnd = ? AND pzlxdm = ? and lxgs = '物料出库单'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
            rcOleDbCommand.Parameters.AddWithValue("@pzlxdm", Trim(Me.CmbPzlxjc.SelectedValue))
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
        TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & g_Kjqj & (rcDataset.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
    End Sub

#End Region

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDjh.KeyPress, DtpCkrq.KeyPress, CmbPzlxjc.KeyPress, TxtLlsqDjh.KeyPress, TxtCkdm.KeyPress, TxtBmdm.KeyPress, TxtZydm.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "单据类型的事件"

    Private Sub CmbPzlxjc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbPzlxjc.Validated
        ShowNewDjh()
    End Sub

#End Region

#Region "仓库编码的事件"

    Private Sub TxtCkdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCkdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_ckxx"
                    .paraField1 = "ckdm"
                    .paraField2 = "ckmc"
                    .paraField3 = "cksm"
                    .paraTitle = "仓库"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtCkdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtCkdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCkdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtCkdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_ckxx WHERE (ckdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(TxtCkdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_ckxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_ckxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_ckxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_ckxx").Rows.Count > 0 Then
                Me.TxtCkdm.Text = Trim(rcDataset.Tables("rc_ckxx").Rows(0).Item("ckdm"))
                Me.LblCkmc.Text = Trim(rcDataset.Tables("rc_ckxx").Rows(0).Item("ckmc"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "显示单据"

    Private Sub SumSlJe()
        '计算合计数
        dblTotSl = 0.0
        dblTotFzsl = 0.0
        dblTotJe = 0.0
        If rcDataset.Tables("rc_ckdnr").Rows.Count > 0 Then
            dblTotSl = rcDataset.Tables("rc_ckdnr").Compute("Sum(sl)", "")
            dblTotFzsl = rcDataset.Tables("rc_ckdnr").Compute("Sum(fzsl)", "")
            dblTotJe = rcDataset.Tables("rc_ckdnr").Compute("Sum(je)", "")
        End If
        Me.LblSl.Text = "数量合计：" + Format(dblTotSl, g_FormatSl)
        Me.LblFzsl.Text = "辅数量合计：" + Format(dblTotFzsl, g_FormatSl)
        Me.LblJe.Text = "金额合计：" + Format(dblTotJe, g_FormatJe)
    End Sub

    Private Sub BtnTop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTop.Click, MnuiTop.Click
        If rcBmb.Count > 0 Then
            rcBmb.Position = 0
        End If
        ShowLlsq(rcBmb.Current("djh"))
    End Sub

    Private Sub BtnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevious.Click, MnuiPrevious.Click
        If rcBmb.Count > 0 Then
            If rcBmb.Position <> 0 Then
                rcBmb.Position -= 1
            End If
        End If
        ShowLlsq(rcBmb.Current("djh"))
    End Sub

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click, MnuiNext.Click
        If rcBmb.Count > 0 Then
            If rcBmb.Position <> rcBmb.Count Then
                rcBmb.Position += 1
            End If
        End If
        ShowLlsq(rcBmb.Current("djh"))
    End Sub

    Private Sub BtnBottom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBottom.Click, MnuiBottom.Click
        If rcBmb.Count > 0 Then
            rcBmb.Position = rcBmb.Count - 1
        End If
        ShowLlsq(rcBmb.Current("djh"))
    End Sub

    Private Sub ShowLlsq(ByVal ckDjh As String)
        Dim i As Integer
        Dim j As Integer
        Dim dblCksl As Double
        Dim dblCkje As Double
        '取采购计划数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT inv_llsq.djh,inv_llsq.bmdm,inv_llsq.bmmc,inv_llsq.zydm,inv_llsq.zymc FROM inv_llsq WHERE inv_llsq.djh = ? ORDER BY inv_llsq.xh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = ckDjh
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_ckdml") IsNot Nothing Then
                rcDataset.Tables("rc_ckdml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_ckdml")
        Catch ex As Exception
            Try
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
        Finally
            rcOleDbConn.Close()
        End Try
        '赋值
        If rcDataset.Tables("rc_ckdml").Rows.Count > 0 Then
            Me.TxtLlsqDjh.Text = rcDataset.Tables("rc_ckdml").Rows(0).Item("djh")
            Me.TxtBmdm.Text = rcDataset.Tables("rc_ckdml").Rows(0).Item("bmdm")
            Me.LblBmmc.Text = rcDataset.Tables("rc_ckdml").Rows(0).Item("bmmc")
            If rcDataset.Tables("rc_ckdml").Rows(0).Item("zydm").GetType.ToString <> "System.DBNull" Then
                Me.TxtZydm.Text = rcDataset.Tables("rc_ckdml").Rows(0).Item("zydm")
            Else
                Me.TxtZydm.Text = ""
            End If
            If rcDataset.Tables("rc_ckdml").Rows(0).Item("zymc").GetType.ToString <> "System.DBNull" Then
                Me.LblZymc.Text = rcDataset.Tables("rc_ckdml").Rows(0).Item("zymc")
            Else
                Me.LblZymc.Text = ""
            End If
        End If
        Try
            '取inv_ckdnr数据
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT 1 AS xz,inv_llsq.cpdm,rc_cpxx.cpmc,inv_llsq.csdm,inv_llsq.csmc,rc_cpxx.brecycling,rc_cpxx.bfadm,inv_llsq.fadm,inv_llsq.famc,rc_cpxx.kuwei,(inv_llsq.sl - inv_llsq.cksl) As sl,rc_cpxx.dw,0.0 AS dj,0.0 AS je,inv_llsq.sqmemo AS ckmemo,inv_llsq.djh AS llsqdjh,inv_llsq.xh AS llsqxh FROM inv_llsq,rc_cpxx WHERE inv_llsq.cpdm = rc_cpxx.cpdm AND ((inv_llsq.sl > inv_llsq.cksl AND inv_llsq.sl > 0) OR (inv_llsq.sl < inv_llsq.cksl AND inv_llsq.sl < 0)) AND inv_llsq.bclosed  = 0 AND inv_llsq.djh = ? ORDER BY inv_llsq.xh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 19).Value = ckDjh
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_ckdnr") IsNot Nothing Then
                rcDataset.Tables("rc_ckdnr").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_ckdnr")
            Me.rcBindingSource.DataSource = dtCkd
            Me.rcDataGridView.DataSource = Me.rcBindingSource
            SumSlJe()
        Catch ex As Exception
            Try
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
        Finally
            rcOleDbConn.Close()
        End Try
        '取入库存信息，单价
        For i = 0 To rcDataset.Tables("rc_ckdnr").Rows.Count - 1
            dblCksl = 0.0
            dblCkje = 0.0
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT ckdm FROM rc_cpxx WHERE cpdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_ckdnr").Rows(i).Item("cpdm")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                    rcDataset.Tables("rc_cpxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_cpxx").Rows.Count > 0 Then
                If rcDataset.Tables("rc_ckdnr").Rows(i).Item("sl") > 0 Then
                    '正常出库
                    Try
                        rcOleDbConn.Open()
                        rcOleDbCommand.Connection = rcOleDbConn
                        rcOleDbCommand.CommandTimeout = 300
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT COALESCE(SUM(po_rkd.sl),0.0) AS sl,COALESCE(SUM(po_rkd.cksl),0.0) AS cksl,COALESCE(SUM(po_rkd.je),0.0) AS je,COALESCE(SUM(po_rkd.ckje),0.0) AS ckje FROM po_rkd WHERE po_rkd.sl <> po_rkd.cksl AND po_rkd.ckdm = ? AND po_rkd.cpdm = ? AND po_rkd.csdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("ckdm")
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_ckdnr").Rows(i).Item("cpdm")
                        rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rc_ckdnr").Rows(i).Item("csdm")
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("po_rkd") IsNot Nothing Then
                            rcDataset.Tables("po_rkd").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "po_rkd")
                    Catch ex As Exception
                        MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                    If rcDataset.Tables("po_rkd").Rows.Count > 0 Then
                        For j = 0 To rcDataset.Tables("po_rkd").Rows.Count - 1
                            If rcDataset.Tables("rc_ckdnr").Rows(i).Item("sl") - dblCksl >= rcDataset.Tables("po_rkd").Rows(j).Item("sl") - rcDataset.Tables("po_rkd").Rows(j).Item("cksl") Then
                                dblCksl = dblCksl + rcDataset.Tables("po_rkd").Rows(j).Item("sl") - rcDataset.Tables("po_rkd").Rows(j).Item("cksl")
                                dblCkje = dblCkje + rcDataset.Tables("po_rkd").Rows(j).Item("je") - rcDataset.Tables("po_rkd").Rows(j).Item("ckje")
                            Else
                                dblCksl = rcDataset.Tables("rc_ckdnr").Rows(i).Item("sl")
                                dblCkje = (rcDataset.Tables("po_rkd").Rows(j).Item("je") - rcDataset.Tables("po_rkd").Rows(j).Item("ckje")) / (rcDataset.Tables("po_rkd").Rows(j).Item("sl") - rcDataset.Tables("po_rkd").Rows(j).Item("cksl")) * rcDataset.Tables("rc_ckdnr").Rows(i).Item("sl")
                                Exit For
                            End If
                        Next
                        '限制出库数量
                        rcDataset.Tables("rc_ckdnr").Rows(i).Item("sl") = dblCksl
                        rcDataset.Tables("rc_ckdnr").Rows(i).Item("je") = dblCkje
                        If rcDataset.Tables("rc_ckdnr").Rows(i).Item("sl") <> 0 Then
                            rcDataset.Tables("rc_ckdnr").Rows(i).Item("dj") = rcDataset.Tables("rc_ckdnr").Rows(i).Item("je") / rcDataset.Tables("rc_ckdnr").Rows(i).Item("sl")
                        End If
                    Else
                        rcDataset.Tables("rc_ckdnr").Rows(i).Item("sl") = 0
                        rcDataset.Tables("rc_ckdnr").Rows(i).Item("je") = 0
                    End If
                Else
                    '取最后一笔出库的单价
                    Try
                        rcOleDbConn.Open()
                        rcOleDbCommand.Connection = rcOleDbConn
                        rcOleDbCommand.CommandTimeout = 300
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT po_rkd.cksl,po_rkd.ckje FROM po_rkd WHERE po_rkd.cksl > 0 AND po_rkd.ckdm = ? AND po_rkd.cpdm = ? AND po_rkd.csdm = ? ORDER BY djh DESC,xh DESC"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("ckdm")
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_ckdnr").Rows(i).Item("cpdm")
                        rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rc_ckdnr").Rows(i).Item("csdm")
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("po_rkd") IsNot Nothing Then
                            rcDataset.Tables("po_rkd").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "po_rkd")
                    Catch ex As Exception
                        MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                    If rcDataset.Tables("po_rkd").Rows.Count > 0 Then
                        rcDataset.Tables("rc_ckdnr").Rows(i).Item("dj") = rcDataset.Tables("po_rkd").Rows(0).Item("ckje") / rcDataset.Tables("po_rkd").Rows(0).Item("cksl")
                        rcDataset.Tables("rc_ckdnr").Rows(i).Item("je") = rcDataset.Tables("rc_ckdnr").Rows(i).Item("dj") * rcDataset.Tables("rc_ckdnr").Rows(i).Item("sl")
                    End If
                End If
            End If
        Next
    End Sub

#End Region

#Region "DataGridView的事件"

    'Private Sub rcDataGridView_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles rcDataGridView.CellEnter
    '    '如果此单元格只读的话则发送回车键。
    '    If Me.rcDataGridView.CurrentCell.ReadOnly Then My.Computer.Keyboard.SendKeys("{Enter}")
    'End Sub

    Private Sub RcDataGridView_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs)
        If Me.rcDataGridView.CurrentRow.IsNewRow = False Then
            If Me.rcDataGridView.IsCurrentCellDirty Then
                Me.rcDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColCpdm" Then
                If Not String.IsNullOrEmpty(e.FormattedValue) Then
                    Try
                        '取物料信息
                        rcOleDbConn.Open()
                        rcOleDbCommand.Connection = rcOleDbConn
                        rcOleDbCommand.CommandTimeout = 300
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT cpdm,cpmc,brecycling,bfadm,kuwei,dw,mjsl,fzdw,ckdm FROM rc_cpxx WHERE (rc_cpxx.cpdm = ? OR rc_cpxx.oldcpdm = ?)"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue
                        rcOleDbCommand.Parameters.Add("@oldcpdm", OleDbType.VarChar, 15).Value = rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                            rcDataset.Tables("rc_cpxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
                        If rcDataset.Tables("rc_cpxx").Rows.Count > 0 Then
                            ''取最新库存数量
                            'rcOleDbCommand.CommandText = "SELECT COALESCE(Sum(qcsl+idsl),0.0) as kcsl FROM inv_cpyeb WHERE kjnd = ? AND cpdm = ? AND ckdm = ?"
                            'rcOleDbCommand.Parameters.Clear()
                            'rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = strYear
                            'rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue
                            'rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Me.TxtCkdm.Text
                            'rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            'If Not rcDataSet.Tables("inv_cpyeb") Is Nothing Then
                            '    rcDataSet.Tables("inv_cpyeb").Clear()
                            'End If
                            'rcOleDbDataAdpt.Fill(rcDataSet, "inv_cpyeb")
                            '取未出库库存明细数据
                            rcOleDbCommand.CommandText = "SELECT po_rkd.csdm,po_rkd.csmc,(po_rkd.sl-COALESCE(po_rkd.cksl,0.0)) AS kcsl FROM po_rkd WHERE po_rkd.sl > po_rkd.cksl AND po_rkd.cpdm = ? ORDER BY po_rkd.rkrq"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("po_rkd") IsNot Nothing Then
                                rcDataset.Tables("po_rkd").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "po_rkd")
                        End If
                    Catch ex As Exception
                        MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                    If rcDataset.Tables("rc_cpxx").Rows.Count > 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColCpdm").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("cpdm")
                        Me.rcDataGridView.CurrentRow.Cells("ColCpmc").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("cpmc")
                        Me.rcDataGridView.CurrentRow.Cells("ColDw").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("dw")
                        Me.rcDataGridView.CurrentRow.Cells("ColBrecycling").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("brecycling")
                        Me.rcDataGridView.CurrentRow.Cells("ColBfadm").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("bfadm")
                        If Me.rcDataGridView.CurrentRow.Cells("ColBfadm").Value = True Then
                            '跟踪设备
                            Me.rcDataGridView.CurrentRow.Cells("ColFadm").ReadOnly = False
                        Else
                            '不跟踪设备
                            Me.rcDataGridView.CurrentRow.Cells("ColFadm").ReadOnly = True
                            Me.rcDataGridView.CurrentRow.Cells("ColFadm").Value = ""
                            Me.rcDataGridView.CurrentRow.Cells("ColFamc").Value = ""
                        End If
                        Me.rcDataGridView.CurrentRow.Cells("ColKuwei").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("kuwei")
                        If rcDataset.Tables("rc_cpxx").Rows(0).Item("mjsl").GetType.ToString <> "System.DBNull" And Me.rcDataGridView.CurrentRow.Cells("ColMjsl").Value = 0 Then
                            Me.rcDataGridView.CurrentRow.Cells("ColMjsl").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("mjsl")
                        End If
                        If rcDataset.Tables("rc_cpxx").Rows(0).Item("fzdw").GetType.ToString <> "System.DBNull" Then
                            Me.rcDataGridView.CurrentRow.Cells("ColFzdw").Value = rcDataset.Tables("rc_cpxx").Rows(0).Item("fzdw")
                        End If
                        'If Not rcDataSet.Tables("inv_cpyeb") Is Nothing Then
                        '    If rcDataSet.Tables("inv_cpyeb").Rows.Count = 1 Then
                        '        dblKcsl = rcDataSet.Tables("inv_cpyeb").Rows(0).Item("kcsl")
                        '        Me.LblMsg.Text = "当前仓库库存数量：" & rcDataSet.Tables("inv_cpyeb").Rows(0).Item("kcsl")
                        '    Else
                        '        dblKcsl = 0.0
                        '        Me.LblMsg.Text = "当前仓库库存数量： 0.00 "
                        '    End If
                        'Else
                        '    dblKcsl = 0.0
                        '    Me.LblMsg.Text = "当前仓库库存数量： 0.00 "
                        'End If
                        dblKcsl = ReadKcsl(Mid(g_Kjqj, 1, 4), rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCpdm").EditedFormattedValue, Me.TxtCkdm.Text, Me.TxtDjh.Text)
                        Me.LblMsg.Text = "仓库库存数量：" & Format(dblKcsl, g_FormatSl)
                        If rcDataset.Tables("po_rkd") IsNot Nothing Then
                            If rcDataset.Tables("po_rkd").Rows.Count > 0 And String.IsNullOrEmpty(Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value) Then
                                Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value = rcDataset.Tables("po_rkd").Rows(0).Item("csdm")
                                Me.rcDataGridView.CurrentRow.Cells("ColCsmc").Value = rcDataset.Tables("po_rkd").Rows(0).Item("csmc")
                                '计算当前供应商库存
                                dblKcsl = rcDataset.Tables("po_rkd").Compute("SUM(kcsl)", "csdm = '" & rcDataset.Tables("po_rkd").Rows(0).Item("csdm") & "'")
                                Me.LblMsg.Text += " 该供应商库存数量：" & Format(dblKcsl, g_FormatSl)
                            Else
                                Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value = ""
                                Me.rcDataGridView.CurrentRow.Cells("ColCsmc").Value = ""
                            End If
                        Else
                            Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value = ""
                            Me.rcDataGridView.CurrentRow.Cells("ColCsmc").Value = ""
                        End If
                    Else
                        Me.LblMsg.Text = "物料编码不存在。"
                        e.Cancel = True
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColSl" Then
                If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
                    Me.rcDataGridView.CurrentRow.Cells("ColJhje").Value = Round(Me.rcDataGridView.CurrentRow.Cells("ColJhdj").Value * e.FormattedValue, 2, MidpointRounding.AwayFromZero)
                    Me.rcDataGridView.CurrentRow.Cells("ColJe").Value = Round(Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value * e.FormattedValue, 2, MidpointRounding.AwayFromZero)
                    If Me.rcDataGridView.CurrentRow.Cells("ColSl").Value > Me.rcDataGridView.CurrentRow.Cells("ColShsl").Value Then
                        Me.LblMsg.Text = "收货数量不能大于送货数量。"
                        e.Cancel = True
                    End If
                Else
                    Me.rcDataGridView.CurrentRow.Cells("ColSl").Value = 0.0
                End If
            End If
            'If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColHsdj" Then
            '    If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
            '        Me.rcDataGridView.CurrentRow.Cells("ColJe").Value = Round(Me.rcDataGridView.CurrentRow.Cells("ColSl").Value * e.FormattedValue, 2, MidpointRounding.AwayFromZero)
            '    Else
            '        Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value = 0.0
            '    End If
            'End If
            'If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColJe" Then
            '    If e.FormattedValue.GetType.ToString <> "System.DBNull" Then
            '        If Me.rcDataGridView.CurrentRow.Cells("ColSl").Value <> 0 Then
            '            Me.rcDataGridView.CurrentRow.Cells("ColHsdj").Value = Round(e.FormattedValue / Me.rcDataGridView.CurrentRow.Cells("ColSl").Value, 6, MidpointRounding.AwayFromZero)
            '        End If
            '    Else
            '        Me.rcDataGridView.CurrentRow.Cells("ColJe").Value = 0.0
            '    End If
            'End If
        End If
    End Sub

    Private Sub RcDataGridView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.C And e.Control
                '复制
                Clipboard.SetDataObject(Me.rcDataGridView.GetClipboardContent())
            Case Keys.V And e.Control
                '粘贴
                Me.rcDataGridView.CurrentCell.Value = Clipboard.GetText()
                Me.rcBindingSource.EndEdit()
                Me.rcDataGridView.EndEdit()
        End Select
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColCpdm" Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF34
                    With rcFrm
                        .paraOleDbConn = rcOleDbConn
                        .paraTableName = "rc_cpxx"
                        .paraField1 = "cpdm"
                        .paraField2 = "cpmc"
                        .paraField3 = "dw"
                        .paraField4 = "cpsm"
                        .paraOrderField = "cpmc"
                        .paraTitle = "物料"
                        .paraOldValue = ""
                        .paraAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            '将用户在rcfrmselectcpdm所选择的cpdm带入rcdatarid'
                            Me.rcDataGridView.CurrentRow.Cells("ColCpdm").Value = .paraField1
                            Me.rcDataGridView.EndEdit()
                            Me.rcBindingSource.EndEdit()
                        End If
                    End With
            End Select
        End If
    End Sub

    Private Sub RcDataGridView_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.rcDataGridView.ClearSelection()
    End Sub

    Private Sub RcDataGridView_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)
        If Not Me.rcDataGridView.CurrentRow.IsNewRow Then
            Me.rcBindingSource.EndEdit()
            Me.rcDataGridView.EndEdit()
        End If
        If dtCkd.Rows.Count > 0 Then
            SumSlJe()
        End If
    End Sub

#End Region

#Region "保存事件"

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MnuiSave.Click
        SaveEvent(False)
    End Sub

    Private Sub SaveEvent(ByVal blnPrint As Boolean)
        Dim i As Integer
        '(一)数据合法性检查
        '(1)是否有需要存储的数据
        If rcDataSet.Tables("rc_ckdnr").Rows.Count = 0 Then
            MsgBox("没有相应的业务，请输入。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        '(2)仓库编码检查
        If String.IsNullOrEmpty(Me.TxtCkdm.Text) Then
            MsgBox("仓库编码不能为空。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Trim(Me.TxtCkdm.Text)
            rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_ckxx"
            rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "ckdm"
            rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
            rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
            rcOleDbCommand.ExecuteNonQuery()
            If rcOleDbCommand.Parameters.Item("@paraIntRecordCount").Value <> 1 Then
                MsgBox(Trim(TxtCkdm.Text) & "仓库编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                Me.TxtCkdm.Text = ""
                Me.LblCkmc.Text = ""
                Me.TxtCkdm.Focus()
                Return
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '(3)部门编码检查
        If String.IsNullOrEmpty(Me.TxtBmdm.Text) Then
            MsgBox("部门编码不能为空。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Trim(Me.TxtBmdm.Text)
            rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_bmxx"
            rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "bmdm"
            rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
            rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
            rcOleDbCommand.ExecuteNonQuery()
            If rcOleDbCommand.Parameters.Item("@paraIntRecordCount").Value <> 1 Then
                MsgBox(Trim(TxtBmdm.Text) & "部门编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                Me.TxtBmdm.Text = ""
                Me.LblBmmc.Text = ""
                Me.TxtBmdm.Focus()
                Return
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        ''(2)设备编码检查
        'If String.IsNullOrEmpty(Me.TxtFadm.Text) Then
        '    MsgBox("设备编码不能为空。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
        '    Return
        'End If
        'Try
        '    rcOleDbConn.Open()
        '    rcOleDbCommand.Connection = rcOleDbConn
        '    rcOleDbCommand.CommandTimeout = 300
        '    rcOleDbCommand.CommandType = CommandType.StoredProcedure
        '    rcOleDbCommand.CommandText = "USP_CHECK_CODE"
        '    rcOleDbCommand.Parameters.Clear()
        '    rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Trim(Me.TxtFadm.Text)
        '    rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_faxx"
        '    rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "fadm"
        '    rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
        '    rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
        '    rcOleDbCommand.ExecuteNonQuery()
        '    If rcOleDbCommand.Parameters.Item("@paraIntRecordCount").Value <> 1 Then
        '        MsgBox(Trim(TxtFadm.Text) & "设备编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
        '        Me.TxtFadm.Text = ""
        '        Me.LblFamc.Text = ""
        '        Me.TxtFadm.Focus()
        '        Return
        '    End If
        'Catch ex As Exception
        '    MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        '    Return
        'Finally
        '    rcOleDbConn.Close()
        'End Try
        '(4)经手人检查
        If String.IsNullOrEmpty(Me.TxtZydm.Text) Then
            MsgBox("经手人不能为空。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Trim(Me.TxtZydm.Text)
            rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_zyxx"
            rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "zydm"
            rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
            rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
            rcOleDbCommand.ExecuteNonQuery()
            If rcOleDbCommand.Parameters.Item("@paraIntRecordCount").Value <> 1 Then
                MsgBox(Trim(TxtZydm.Text) & "经手人编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                Me.TxtZydm.Text = ""
                Me.LblZymc.Text = ""
                Me.TxtZydm.Focus()
                Return
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '(4)DataTable赋默认值
        For i = 0 To rcDataSet.Tables("rc_ckdnr").Rows.Count - 1
            If rcDataSet.Tables("rc_ckdnr").Rows(i).Item("cpdm").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_ckdnr").Rows(i).Item("cpdm") = ""
            End If
            If rcDataSet.Tables("rc_ckdnr").Rows(i).Item("csdm").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_ckdnr").Rows(i).Item("csdm") = ""
            End If
            If rcDataSet.Tables("rc_ckdnr").Rows(i).Item("brecycling").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_ckdnr").Rows(i).Item("brecycling") = False
            End If
            If rcDataSet.Tables("rc_ckdnr").Rows(i).Item("brecycling").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_ckdnr").Rows(i).Item("brecycling") = False
            End If
            If rcDataSet.Tables("rc_ckdnr").Rows(i).Item("fadm").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_ckdnr").Rows(i).Item("fadm") = ""
            End If
            If rcDataSet.Tables("rc_ckdnr").Rows(i).Item("kuwei").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_ckdnr").Rows(i).Item("kuwei") = ""
            End If
            If rcDataSet.Tables("rc_ckdnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_ckdnr").Rows(i).Item("sl") = 0.0
            End If
            If rcDataSet.Tables("rc_ckdnr").Rows(i).Item("ckmemo").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_ckdnr").Rows(i).Item("ckmemo") = ""
            End If
            If rcDataSet.Tables("rc_ckdnr").Rows(i).Item("llsqdjh").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_ckdnr").Rows(i).Item("llsqdjh") = ""
            End If
            If rcDataSet.Tables("rc_ckdnr").Rows(i).Item("llsqxh").GetType.ToString = "System.DBNull" Then
                rcDataSet.Tables("rc_ckdnr").Rows(i).Item("llsqxh") = 0
            End If
        Next
        '(5)物料编码检查
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            For i = 0 To rcDataSet.Tables("rc_ckdnr").Rows.Count - 1
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Trim(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("cpdm"))
                rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_cpxx"
                rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "cpdm"
                rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
                rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
                rcOleDbCommand.ExecuteNonQuery()
                If rcOleDbCommand.Parameters.Item("@paraIntRecordCount").Value <> 1 Then
                    MsgBox(Trim(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("cpdm")) & "物料编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                    Return
                End If
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("csdm"))
                rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_csxx"
                rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "csdm"
                rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
                rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
                rcOleDbCommand.ExecuteNonQuery()
                If rcOleDbCommand.Parameters.Item("@paraIntRecordCount").Value <> 1 Then
                    MsgBox(Trim(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("csdm")) & "供应商编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                    Return
                End If
                If rcDataSet.Tables("rc_ckdnr").Rows(i).Item("bfadm") = True Then
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Trim(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("fadm"))
                    rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "rc_faxx"
                    rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "fadm"
                    rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
                    rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
                    rcOleDbCommand.ExecuteNonQuery()
                    If rcOleDbCommand.Parameters.Item("@paraIntRecordCount").Value <> 1 Then
                        MsgBox(Trim(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("fadm")) & "设备编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                        Return
                    End If
                End If
                If rcDataSet.Tables("rc_ckdnr").Rows(i).Item("sl") = 0.0 Then
                    MsgBox("物料编码：" & rcDataSet.Tables("rc_ckdnr").Rows(i).Item("cpdm") & "对应的数量为【零】，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                    Return
                End If
            Next
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '(6)单据号长度检查
        If Trim(Me.TxtDjh.Text).Length <> 15 Then
            MsgBox("单据号长度不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Return
        End If

        '(二)存储
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP3_SAVE_INV_CKD"
            For i = 0 To rcDataSet.Tables("rc_ckdnr").Rows.Count - 1
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1 'IIf(IsAdding, 1, 0)
                rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = Trim(Me.TxtDjh.Text)
                rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = i + 1
                rcOleDbCommand.Parameters.Add("@paraDateCkrq", OleDbType.Date, 8).Value = Me.DtpCkrq.Value
                rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                rcOleDbCommand.Parameters.Add("@ParaStrCkdm", OleDbType.VarChar, 12).Value = Me.TxtCkdm.Text
                rcOleDbCommand.Parameters.Add("@paraStrCkmc", OleDbType.VarChar, 50).Value = Me.LblCkmc.Text
                rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = Me.TxtBmdm.Text
                rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 50).Value = Me.LblBmmc.Text
                rcOleDbCommand.Parameters.Add("@paraStrZydm", OleDbType.VarChar, 12).Value = Me.TxtZydm.Text
                rcOleDbCommand.Parameters.Add("@paraStrZymc", OleDbType.VarChar, 30).Value = Me.LblZymc.Text
                rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = Trim(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("cpdm")).ToUpper
                rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 200).Value = rcDataSet.Tables("rc_ckdnr").Rows(i).Item("cpmc")
                rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("rc_ckdnr").Rows(i).Item("csdm")
                rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = rcDataSet.Tables("rc_ckdnr").Rows(i).Item("csmc")
                rcOleDbCommand.Parameters.Add("@paraStrBrecycling", OleDbType.Numeric, 1).Value = IIf(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("brecycling"), 1, 0)
                rcOleDbCommand.Parameters.Add("@paraStrBfadm", OleDbType.Numeric, 1).Value = IIf(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("bfadm"), 1, 0)
                rcOleDbCommand.Parameters.Add("@ParaStrFadm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("rc_ckdnr").Rows(i).Item("fadm")
                rcOleDbCommand.Parameters.Add("@paraStrFamc", OleDbType.VarChar, 30).Value = rcDataSet.Tables("rc_ckdnr").Rows(i).Item("famc")
                rcOleDbCommand.Parameters.Add("@paraStrKuwei", OleDbType.VarChar, 40).Value = rcDataset.Tables("rc_ckdnr").Rows(i).Item("kuwei")
                rcOleDbCommand.Parameters.Add("@paraStrPiHao", OleDbType.VarChar, 40).Value = rcDataset.Tables("rc_ckdnr").Rows(i).Item("pihao")
                rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_ckdnr").Rows(i).Item("sl")
                rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = rcDataSet.Tables("rc_ckdnr").Rows(i).Item("dw")
                rcOleDbCommand.Parameters.Add("@paraDblMjsl", OleDbType.Numeric, 18).Value = rcDataSet.Tables("rc_ckdnr").Rows(i).Item("mjsl")
                rcOleDbCommand.Parameters.Add("@paraDblFzsl", OleDbType.Numeric, 18).Value = rcDataSet.Tables("rc_ckdnr").Rows(i).Item("fzsl")
                rcOleDbCommand.Parameters.Add("@paraStrFzdw", OleDbType.VarChar, 8).Value = rcDataSet.Tables("rc_ckdnr").Rows(i).Item("fzdw")
                rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = rcDataSet.Tables("rc_ckdnr").Rows(i).Item("dj")
                rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataSet.Tables("rc_ckdnr").Rows(i).Item("je")
                rcOleDbCommand.Parameters.Add("@paraStrCkmemo", OleDbType.VarChar, 50).Value = rcDataSet.Tables("rc_ckdnr").Rows(i).Item("ckmemo")
                rcOleDbCommand.Parameters.Add("@paraStrLlsqDjh", OleDbType.VarChar, 15).Value = rcDataSet.Tables("rc_ckdnr").Rows(i).Item("llsqdjh")
                rcOleDbCommand.Parameters.Add("@paraIntLlsqXh", OleDbType.Integer, 4).Value = rcDataSet.Tables("rc_ckdnr").Rows(i).Item("llsqxh")
                rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                rcOleDbCommand.Parameters.Add("@paraCbill_bid", OleDbType.VarChar, 20).Value = ""
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
            Next
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
        '打印
        If blnPrint Then
            PrintEvent()
        End If
        '设置焦点
        Me.TxtDjh.Focus()
    End Sub

#End Region

#Region "准备打印数据事件"

    Private Sub PreparePrintData()
        If rcRps Is Nothing Then
            rcRps = New RPS.Document
        End If
        Dim rft As String = CurDir() + "\reports\ckdbz.rft"
        rcRps.LoadTemplate(rft)
        '取RPS数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps WHERE rpsid = 'CKDBZ'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_rps") IsNot Nothing Then
                rcDataSet.Tables("rc_rps").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_rps")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("rc_rps").Rows.Count > 0 Then
            '设定值
            rcRps.Scale = rcDataSet.Tables("rc_rps").Rows(0).Item("scale")
            rcRps.Orientation = rcDataSet.Tables("rc_rps").Rows(0).Item("orientation")
            rcRps.PaperWidth = rcDataSet.Tables("rc_rps").Rows(0).Item("paperwidth")
            rcRps.PaperHeight = rcDataSet.Tables("rc_rps").Rows(0).Item("paperheight")
            rcRps.PrinterLeft = rcDataSet.Tables("rc_rps").Rows(0).Item("printerleft")
            rcRps.PrinterTop = rcDataSet.Tables("rc_rps").Rows(0).Item("printertop")
        Else
            '默认值
            rcRps.Scale = 100
            rcRps.Orientation = 1
        End If
        '套打
        'rcRps.PaperType = 1

        rcRps.Text(-1, 1) = g_PrnDwmc & "出库单"
        rcRps.Text(-1, 2) = "仓库：(" & Trim(Me.TxtCkdm.Text) & ")" & Trim(LblCkmc.Text)
        rcRps.Text(-1, 3) = "经手人：(" & Trim(Me.TxtZydm.Text) & ")" & Trim(LblZymc.Text)
        rcRps.Text(-1, 4) = "单据号：" & Trim(Me.TxtDjh.Text) & "  %p/%t"
        rcRps.Text(-1, 5) = "部门：(" & Trim(Me.TxtBmdm.Text) & ")" & Trim(LblBmmc.Text)
        rcRps.Text(-1, 6) = ""
        rcRps.Text(-1, 7) = "日期：" & DtpCkrq.Value.Date.ToLongDateString
        Dim i As Integer
        Dim j As Integer
        Dim intPage As Integer
        Dim dblTotalSl As Double = 0.0
        For intPage = 1 To System.Math.Ceiling(rcDataSet.Tables("rc_ckdnr").Rows.Count / rcRps.LinesPerPage.ToString)
            For i = (intPage - 1) * rcRps.LinesPerPage.ToString To System.Math.Min(intPage * rcRps.LinesPerPage.ToString - 1, rcDataSet.Tables("rc_ckdnr").Rows.Count - 1)
                If rcDataSet.Tables("rc_ckdnr").Rows(i).RowState <> 8 Then
                    If Not rcDataSet.Tables("rc_ckdnr").Rows(i).Item("cpdm").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 1) = Trim(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("cpdm"))
                    End If
                    If Not rcDataSet.Tables("rc_ckdnr").Rows(i).Item("cpmc").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 2) = Trim(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("cpmc"))
                    End If
                    If Not rcDataSet.Tables("rc_ckdnr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 3) = Trim(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("dw"))
                    End If
                    If Not rcDataSet.Tables("rc_ckdnr").Rows(i).Item("kuwei").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 4) = Trim(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("kuwei"))
                    End If
                    If Not rcDataSet.Tables("rc_ckdnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 5) = Format(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("sl"), g_FormatSl)
                        dblTotalSl += rcDataSet.Tables("rc_ckdnr").Rows(i).Item("sl")
                    End If
                    If Not rcDataSet.Tables("rc_ckdnr").Rows(i).Item("oldcpdm").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 6) = Trim(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("oldcpdm"))
                    End If
                    If Not rcDataSet.Tables("rc_ckdnr").Rows(i).Item("ckmemo").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 6) += Trim(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("ckmemo"))
                    End If
                    j += 1
                End If
            Next
            Dim m As New models.ChineseNum
            'm.InputString = dblTotalJe
            rcRps.PerPageText(intPage, 8) = IIf(intPage = Math.Ceiling(rcDataSet.Tables("rc_ckdnr").Rows.Count / rcRps.LinesPerPage.ToString), "合计", "小计")
            'rcRps.PerPageText(intPage, 7) = m.OutString '大写
            rcRps.PerPageText(intPage, 10) = Format(dblTotalSl, g_FormatSl)
            'rcRps.PerPageText(intPage, 10) = Format(dblTotalJe, g_FormatJe)
            'dblTotalJe = 0.0
        Next
        If Decimal.op_Modulus(rcDataSet.Tables("rc_ckdnr").Rows.Count, rcRps.LinesPerPage.ToString) <> 0 Then
            For i = Decimal.op_Modulus(rcDataSet.Tables("rc_ckdnr").Rows.Count, rcRps.LinesPerPage.ToString) + 1 To rcRps.LinesPerPage.ToString
                rcRps.Text(j + 1, 1) = ""
                j += 1
            Next
        End If
        rcRps.Text(-1, 12) = "制单：" & g_User_DspName
    End Sub

#End Region

#Region "打印设置事件"

    Private Sub PageSetupEvent()
        Dim rcFrmPageSetup As New models.FrmPageSetup
        With rcFrmPageSetup
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = "CKDBZ"
            .paraRpsName = "出库单标准格式"
            .ShowDialog()
        End With
    End Sub

    Private Sub MnuiPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPageSetup.Click
        PageSetupEvent()
    End Sub

#End Region

#Region "打印事件"

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        PrintEvent()
    End Sub

    Private Sub MnuiPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrint.Click
        PrintEvent()
    End Sub

    Private Sub PrintEvent()
        If g_Demo = 1 Then
            MsgBox("对不起，试用软件不能打印。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        PreparePrintData()
        Dim rcFrmPrint As New models.FrmPrint
        With rcFrmPrint
            .paraRps = rcRps
            .ShowDialog()
            SaveEvent(True)
        End With
    End Sub

#End Region

#Region "打印预览事件"

    Private Sub PrintViewEvent()
        PreparePrintData()
        rcRps.Preview()
    End Sub

    Private Sub MnuiPrintView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrintView.Click
        PrintViewEvent()
    End Sub

#End Region

#Region "退出"

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click, MnuiExit.Click
        ExitEvent()
    End Sub

    Private Sub ExitEvent()
        Me.Close()
    End Sub

#End Region
End Class