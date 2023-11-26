Imports System.Data.OleDb

Public Class FrmOeDdCxz
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    Dim rcDataset As New DataSet
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '数据绑定
    Dim rcBmb As BindingManagerBase
    '建立打印文档
    ReadOnly rcRps As RPS.Document
    '合计变量
    Dim dblTotSl As Double = 0.0
    Dim dblTotFzsl As Double = 0.0
    Dim dblTotJe As Double = 0.0
    Dim dblTotSe As Double = 0.0

    Public Property ParaDataSet() As DataSet
        Get
            ParaDataSet = rcDataSet
        End Get
        Set(ByVal Value As DataSet)
            rcDataSet = Value
        End Set
    End Property

    Private Sub FrmOeDdCxz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Me.rcDataGridView.Columns("ColHsdj").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColHsdj").DefaultCellStyle.Format = g_FormatDj
        Me.rcDataGridView.Columns("ColJe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColJe").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColShlv").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColShlv").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColSe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColSe").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColJese").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColJese").DefaultCellStyle.Format = g_FormatJe
        rcBmb = Me.BindingContext(rcDataSet, "ddml")
        If rcDataSet.Tables("ddml").Rows.Count > 0 Then
            ShowDd(rcDataset.Tables("ddml").Rows(0).Item("djh"))
        End If
    End Sub

    Private Sub ShowDd(ByVal ddDjh As String)
        '判断ddDjh
        '取oe_dd数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT oe_dd.djh,oe_dd.qdrq,oe_dd.hth,oe_dd.khdm,oe_dd.khmc,oe_dd.zydm,oe_dd.zymc,oe_dd.ddtk,oe_dd.sktj,oe_dd.skqx,oe_dd.srr,oe_dd.shr,oe_dd.jzr FROM oe_dd WHERE (djh = ?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = ddDjh
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_ddml") IsNot Nothing Then
                rcDataset.Tables("rc_ddml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_ddml")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '赋值
        Me.TxtDjh.Text = rcDataset.Tables("rc_ddml").Rows(0).Item("djh")
        Me.DtpQdrq.Value = rcDataset.Tables("rc_ddml").Rows(0).Item("qdrq")
        Me.TxtSgddh.Text = Trim(rcDataset.Tables("rc_ddml").Rows(0).Item("hth"))
        Me.TxtKhdm.Text = rcDataset.Tables("rc_ddml").Rows(0).Item("khdm")
        Me.LblKhmc.Text = Trim(rcDataset.Tables("rc_ddml").Rows(0).Item("khmc"))
        Me.TxtZydm.Text = Trim(rcDataset.Tables("rc_ddml").Rows(0).Item("zydm"))
        Me.LblZymc.Text = rcDataset.Tables("rc_ddml").Rows(0).Item("zymc")
        If rcDataset.Tables("rc_ddml").Rows(0).Item("ddtk").GetType.ToString <> "System.DBNull" Then
            Me.TxtDdtk.Text = rcDataset.Tables("rc_ddml").Rows(0).Item("ddtk")
        Else
            Me.TxtDdtk.Text = ""
        End If
        If rcDataset.Tables("rc_ddml").Rows(0).Item("sktj").GetType.ToString <> "System.DBNull" Then
            Me.CmbSktj.SelectedItem = rcDataset.Tables("rc_ddml").Rows(0).Item("sktj")
        Else
            Me.CmbSktj.SelectedItem = "月结"
        End If
        If rcDataset.Tables("rc_ddml").Rows(0).Item("skqx").GetType.ToString <> "System.DBNull" Then
            Me.TxtSkqx.Text = rcDataset.Tables("rc_ddml").Rows(0).Item("skqx")
        Else
            Me.TxtSkqx.Text = 0
        End If
        Me.LblSrr.Text = "输入：" + rcDataset.Tables("rc_ddml").Rows(0).Item("srr")
        Me.LblShr.Text = "审核：" + rcDataset.Tables("rc_ddml").Rows(0).Item("shr")
        Me.LblJzr.Text = "记账：" + rcDataset.Tables("rc_ddml").Rows(0).Item("jzr")
        '取oe_dd数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT oe_dd.djh,oe_dd.xh,oe_dd.cpdm,oe_dd.cpmc,oe_dd.sl,oe_dd.dw,oe_dd.mjsl,oe_dd.fzsl,oe_dd.fzdw,oe_dd.dj,oe_dd.hsdj,oe_dd.je,oe_dd.shlv,oe_dd.se,oe_dd.je+ oe_dd.se AS jese,oe_dd.khddh,oe_dd.khjhrq,oe_dd.zxgg,oe_dd.ddmemo,oe_dd.sdjh,oe_dd.sxh FROM oe_dd,rc_cpxx WHERE (oe_dd.cpdm = rc_cpxx.cpdm AND oe_dd.djh = ?) ORDER BY xh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = ddDjh
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_ddnr") IsNot Nothing Then
                rcDataset.Tables("rc_ddnr").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_ddnr")
            rcDataGridView.DataSource = rcDataset.Tables("rc_ddnr")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        SumSlJe()
    End Sub

#Region "计算合计数"

    Private Sub SumSlJe()
        '计算合计数
        dblTotSl = 0.0
        dblTotFzsl = 0.0
        dblTotJe = 0.0
        dblTotSe = 0.0
        If rcDataset.Tables("rc_ddnr").Rows.Count > 0 Then
            dblTotSl = rcDataset.Tables("rc_ddnr").Compute("Sum(sl)", "")
            dblTotFzsl = rcDataset.Tables("rc_ddnr").Compute("Sum(fzsl)", "")
            dblTotJe = rcDataset.Tables("rc_ddnr").Compute("Sum(je)", "")
            dblTotSe = rcDataset.Tables("rc_ddnr").Compute("Sum(se)", "")
        End If
        Me.LblSl.Text = "数量合计：" + Format(dblTotSl, g_FormatSl)
        Me.LblFzsl.Text = "辅数量合计：" + Format(dblTotFzsl, g_FormatSl)
        Me.LblJe.Text = "金额合计：" + Format(dblTotJe, g_FormatJe)
        Me.LblSe.Text = "税额合计：" + Format(dblTotSe, g_FormatJe)
        Me.LblJese.Text = "价税合计：" + Format(dblTotJe + dblTotSe, g_FormatJe)
    End Sub

#End Region

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        ExitEvent()
    End Sub

    Private Sub MnuiExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiExit.Click
        ExitEvent()
    End Sub

    Private Sub ExitEvent()
        Me.Close()
    End Sub

    Private Sub BtnTop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTop.Click
        If rcBmb.Count > 0 Then
            rcBmb.Position = 0
            ShowDd(rcBmb.Current("djh"))
        End If
    End Sub

    Private Sub MnuiTop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiTop.Click
        If rcBmb.Count > 0 Then
            rcBmb.Position = 0
            ShowDd(rcBmb.Current("djh"))
        End If
    End Sub

    Private Sub BtnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevious.Click
        If rcBmb.Count > 0 Then
            If rcBmb.Position <> 0 Then
                rcBmb.Position -= 1
            End If
            ShowDd(rcBmb.Current("djh"))
        End If
    End Sub

    Private Sub MnuiPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrevious.Click
        If rcBmb.Count > 0 Then
            If rcBmb.Position <> 0 Then
                rcBmb.Position -= 1
            End If
            ShowDd(rcBmb.Current("djh"))
        End If
    End Sub

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
        If rcBmb.Count > 0 Then
            If rcBmb.Position <> rcBmb.Count Then
                rcBmb.Position += 1
            End If
            ShowDd(rcBmb.Current("djh"))
        End If
    End Sub

    Private Sub MnuiNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiNext.Click
        If rcBmb.Count > 0 Then
            If rcBmb.Position <> rcBmb.Count Then
                rcBmb.Position += 1
            End If
            ShowDd(rcBmb.Current("djh"))
        End If
    End Sub

    Private Sub BtnBottom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBottom.Click
        If rcBmb.Count > 0 Then
            rcBmb.Position = rcBmb.Count - 1
            ShowDd(rcBmb.Current("djh"))
        End If
    End Sub

    Private Sub MnuiBottom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiBottom.Click
        If rcBmb.Count > 0 Then
            rcBmb.Position = rcBmb.Count - 1
            ShowDd(rcBmb.Current("djh"))
        End If
    End Sub
End Class