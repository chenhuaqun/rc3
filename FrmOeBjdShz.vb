Imports System.IO
Imports System.Data.OleDb
Imports System.Net.Mail

Public Class FrmOeBjdShz
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    Dim rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '数据绑定
    Dim bmbBjdml As BindingManagerBase
    '建立打印文档
    ReadOnly rcRps As RPS.Document
    '客户联系人
    Dim strLxr As String = ""
    '客户地址
    Dim strAddress As String = ""

#Region "初始化"

    Public Property ParaDataSet() As DataSet
        Get
            ParaDataSet = rcDataset
        End Get
        Set(ByVal Value As DataSet)
            rcDataset = Value
        End Set
    End Property

    Private Sub FrmOeBjdShz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '设置DataGridView
        Me.rcDataGridView.AutoGenerateColumns = False
        Me.rcDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.rcDataGridView.Columns("ColZl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColZl").DefaultCellStyle.Format = g_FormatDj
        Me.rcDataGridView.Columns("ColDj").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'Me.rcDataGridView.Columns("ColDj").DefaultCellStyle.Format = g_FormatDj
        Me.rcDataGridView.Columns("ColSpq").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColSpq").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColMoq").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColMoq").DefaultCellStyle.Format = g_FormatSl

        bmbBjdml = Me.BindingContext(rcDataset, "djhml")
        If rcDataset.Tables("djhml").Rows.Count > 0 Then
            ShowBjd(rcDataset.Tables("djhml").Rows(0).Item("djh"))
        End If
    End Sub

#End Region

#Region "显示单据"

    Private Sub ShowBjd(ByVal bjDjh As String)
        '判断bjDjh

        '取oe_bjd数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT oe_bjd.djh,oe_bjd.bjrq,oe_bjd.wbdm,oe_bjd.wbhl,oe_bjd.khdm,rc_khxx.khmc,rc_khxx.lxr,rc_khxx.address,oe_bjd.zydm,oe_bjd.zymc,oe_bjd.email,oe_bjd.bjtk,oe_bjd.memo1,oe_bjd.memo2,oe_bjd.memo3,oe_bjd.memo4,oe_bjd.memo5,oe_bjd.srr,oe_bjd.shr,oe_bjd.jzr FROM oe_bjd,rc_khxx WHERE oe_bjd.khdm = rc_khxx.khdm AND djh = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = bjDjh
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_bjdml") IsNot Nothing Then
                rcDataset.Tables("rc_bjdml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_bjdml")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '赋值
        Me.TxtDjh.Text = rcDataset.Tables("rc_bjdml").Rows(0).Item("djh")
        Me.DtpBjrq.Value = rcDataset.Tables("rc_bjdml").Rows(0).Item("bjrq")
        If rcDataset.Tables("rc_bjdml").Rows(0).Item("wbdm").GetType.ToString <> "System.DBNull" Then
            Me.TxtWbdm.Text = rcDataset.Tables("rc_bjdml").Rows(0).Item("wbdm")
        Else
            Me.TxtWbdm.Text = ""
        End If
        Me.TxtWbhl.Text = rcDataset.Tables("rc_bjdml").Rows(0).Item("wbhl")
        If rcDataset.Tables("rc_bjdml").Rows(0).Item("khdm").GetType.ToString <> "System.DBNull" Then
            Me.TxtKhdm.Text = rcDataset.Tables("rc_bjdml").Rows(0).Item("khdm")
        Else
            Me.TxtKhdm.Text = ""
        End If
        If rcDataset.Tables("rc_bjdml").Rows(0).Item("khmc").GetType.ToString <> "System.DBNull" Then
            Me.LblKhmc.Text = rcDataset.Tables("rc_bjdml").Rows(0).Item("khmc")
        Else
            Me.LblKhmc.Text = ""
        End If
        If rcDataset.Tables("rc_bjdml").Rows(0).Item("lxr").GetType.ToString <> "System.DBNull" Then
            strLxr = rcDataset.Tables("rc_bjdml").Rows(0).Item("lxr")
        Else
            strLxr = ""
        End If
        If rcDataset.Tables("rc_bjdml").Rows(0).Item("address").GetType.ToString <> "System.DBNull" Then
            strAddress = rcDataset.Tables("rc_bjdml").Rows(0).Item("address")
        Else
            strAddress = ""
        End If
        If rcDataset.Tables("rc_bjdml").Rows(0).Item("zydm").GetType.ToString <> "System.DBNull" Then
            Me.TxtZydm.Text = rcDataset.Tables("rc_bjdml").Rows(0).Item("zydm")
        Else
            Me.TxtZydm.Text = ""
        End If
        If rcDataset.Tables("rc_bjdml").Rows(0).Item("zymc").GetType.ToString <> "System.DBNull" Then
            Me.LblZymc.Text = rcDataset.Tables("rc_bjdml").Rows(0).Item("zymc")
        Else
            Me.LblZymc.Text = ""
        End If
        If rcDataset.Tables("rc_bjdml").Rows(0).Item("email").GetType.ToString <> "System.DBNull" Then
            Me.TxtEmail.Text = rcDataset.Tables("rc_bjdml").Rows(0).Item("email")
        Else
            Me.TxtEmail.Text = ""
        End If
        If rcDataset.Tables("rc_bjdml").Rows(0).Item("bjtk").GetType.ToString <> "System.DBNull" Then
            TxtBjtk.Text = Trim(rcDataset.Tables("rc_bjdml").Rows(0).Item("bjtk"))
        Else
            TxtBjtk.Text = ""
        End If
        If rcDataset.Tables("rc_bjdml").Rows(0).Item("memo1").GetType.ToString <> "System.DBNull" Then
            TxtMemo1.Text = Trim(rcDataset.Tables("rc_bjdml").Rows(0).Item("memo1"))
        Else
            TxtMemo1.Text = "1、本报价自即日起1个月内有效；"
        End If
        If rcDataset.Tables("rc_bjdml").Rows(0).Item("memo2").GetType.ToString <> "System.DBNull" Then
            TxtMemo2.Text = Trim(rcDataset.Tables("rc_bjdml").Rows(0).Item("memo2"))
        Else
            TxtMemo2.Text = "2、无特殊说明，RMB报价为含税单价，外币报价为FOB上海价；"
        End If
        If rcDataset.Tables("rc_bjdml").Rows(0).Item("memo3").GetType.ToString <> "System.DBNull" Then
            TxtMemo3.Text = Trim(rcDataset.Tables("rc_bjdml").Rows(0).Item("memo3"))
        Else
            TxtMemo3.Text = "3、若汇率波动+/-3%以上时，需重新确认单价；"
        End If
        If rcDataset.Tables("rc_bjdml").Rows(0).Item("memo4").GetType.ToString <> "System.DBNull" Then
            TxtMemo4.Text = Trim(rcDataset.Tables("rc_bjdml").Rows(0).Item("memo4"))
        Else
            TxtMemo4.Text = "4、以上SPQ仅供参考，具体按实际；"
        End If
        If rcDataset.Tables("rc_bjdml").Rows(0).Item("memo5").GetType.ToString <> "System.DBNull" Then
            TxtMemo5.Text = Trim(rcDataset.Tables("rc_bjdml").Rows(0).Item("memo5"))
        Else
            TxtMemo5.Text = "5、无特殊说明，报价为东磁标准包装。"
        End If
        Me.LblSrr.Text = "输入：" + rcDataset.Tables("rc_bjdml").Rows(0).Item("srr")
        If rcDataset.Tables("rc_bjdml").Rows(0).Item("shr").GetType.ToString <> "System.DBNull" Then
            Me.LblShr.Text = "审核：" + rcDataset.Tables("rc_bjdml").Rows(0).Item("shr")
        Else
            LblShr.Text = "审核："
        End If
        If rcDataset.Tables("rc_bjdml").Rows(0).Item("jzr").GetType.ToString <> "System.DBNull" Then
            Me.LblJzr.Text = "记账：" + rcDataset.Tables("rc_bjdml").Rows(0).Item("jzr")
        Else
            LblJzr.Text = "记账："
        End If
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT oe_bjd.khlh,oe_bjd.khcz,oe_bjd.cpdm,oe_bjd.cpmc,oe_bjd.cpgg,oe_bjd.dw,oe_bjd.zl,oe_bjd.dj,oe_bjd.spq,oe_bjd.moq,oe_bjd.bjmemo FROM oe_bjd WHERE oe_bjd.djh = ? order by oe_bjd.xh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = bjDjh
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_bjdnr") IsNot Nothing Then
                rcDataset.Tables("rc_bjdnr").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_bjdnr")
            rcDataGridView.DataSource = rcDataset.Tables("rc_bjdnr")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
    End Sub

#End Region

#Region "审核"

    Private Sub BtnSh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSh.Click
        ShEvent(bmbBjdml.Current("djh"))
    End Sub

    Private Sub MnuiSh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiSh.Click
        ShEvent(bmbBjdml.Current("djh"))
    End Sub

    Private Sub ShEvent(ByVal bjDjh As String)
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "UPDATE oe_bjd SET shr = ? WHERE djh = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@shr", OleDbType.VarChar, 10).Value = g_User_DspName
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = bjDjh
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
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
        LblShr.Text = "审核：" + g_User_DspName
    End Sub

#End Region

    Private Sub BtnXs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXs.Click
        XsEvent(bmbBjdml.Current("djh"))
    End Sub

    Private Sub MnuiXs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiXs.Click
        XsEvent(bmbBjdml.Current("djh"))
    End Sub

    Private Sub XsEvent(ByVal bjDjh As String)
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "UPDATE oe_bjd SET shr = ? WHERE djh = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@shr", OleDbType.VarChar, 10).Value = ""
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = bjDjh
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
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
        LblShr.Text = "审核："
    End Sub

    Private Sub BtnQs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQs.Click
        QsEvent()
    End Sub

    Private Sub MnuiQs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiQs.Click
        QsEvent()
    End Sub

    Private Sub QsEvent()
        Dim i As Integer
        For i = 0 To rcDataset.Tables("djhml").Rows.Count - 1
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "UPDATE oe_bjd SET shr = ? WHERE djh = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@shr", OleDbType.VarChar, 10).Value = g_User_DspName
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataset.Tables("djhml").Rows(i).Item("djh")
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbTrans.Commit()
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
        Next
        LblShr.Text = "审核：" + g_User_DspName
    End Sub

    Private Sub BtnQx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQx.Click
        QxEvent()
    End Sub

    Private Sub MnuiQx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiQx.Click
        QxEvent()
    End Sub

    Private Sub QxEvent()
        Dim i As Integer
        For i = 0 To rcDataset.Tables("djhml").Rows.Count - 1
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "UPDATE oe_bjd SET shr = ? WHERE djh = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@shr", OleDbType.VarChar, 10).Value = ""
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataset.Tables("djhml").Rows(i).Item("djh")
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbTrans.Commit()
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
        Next
        LblShr.Text = "审核："
    End Sub

    Private Sub BtnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevious.Click
        If bmbBjdml.Count > 0 Then
            If bmbBjdml.Position <> 0 Then
                bmbBjdml.Position -= 1
            End If
            ShowBjd(bmbBjdml.Current("djh"))
        End If
    End Sub

    Private Sub MnuiPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrevious.Click
        If bmbBjdml.Count > 0 Then
            If bmbBjdml.Position <> 0 Then
                bmbBjdml.Position -= 1
            End If
            ShowBjd(bmbBjdml.Current("djh"))
        End If
    End Sub

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
        If bmbBjdml.Count > 0 Then
            If bmbBjdml.Position <> bmbBjdml.Count Then
                bmbBjdml.Position += 1
                ShowBjd(bmbBjdml.Current("djh"))
            End If
        End If
    End Sub

    Private Sub MnuiNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiNext.Click
        If bmbBjdml.Count > 0 Then
            If bmbBjdml.Position <> bmbBjdml.Count Then
                bmbBjdml.Position += 1
            End If
            ShowBjd(bmbBjdml.Current("djh"))
        End If
    End Sub

    Private Sub PageSetupEvent()
        Dim rcFrmPageSetup As New models.FrmPageSetup
        With rcFrmPageSetup
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = "BJDBZ"
            .paraRpsName = "报价单标准格式"
            .ShowDialog()
        End With
    End Sub

    Private Sub PrintEvent()
        Try
            Me.rcPrintDocument.Print()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        'If g_Demo = 1 Then
        '    MsgBox("对不起，试用软件不能打印。", MsgBoxStyle.OKOnly + MsgBoxStyle.Question, "提示信息")
        '    Return
        'End If
        'PreparePrintData()
        'Dim rcFrmPrint As New models.FrmPrint
        'With rcFrmPrint
        '    .paraRps = rcRps
        '    .ShowDialog()
        'End With
    End Sub

    Private Sub PrintViewEvent()
        'PreparePrintData()
        Try
            'PrevDialog.Size = New System.Drawing.Size(600, 329)
            Dim PrevDialog As New PrintPreviewDialog With {
                .Document = rcPrintDocument,
                .WindowState = FormWindowState.Maximized
            }
            PrevDialog.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        'rcRps.Preview()
    End Sub

    Private Sub MnuiPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrint.Click
        PrintEvent()
    End Sub

    Private Sub MnuiPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPageSetup.Click
        PageSetupEvent()
    End Sub

    Private Sub MnuiPrintView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrintView.Click
        PrintViewEvent()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        PrintEvent()
    End Sub

    'Private Sub BtnPrintView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrintView.Click
    '    PrintViewEvent()
    'End Sub

    Private Sub RcPrintDocument_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles rcPrintDocument.PrintPage
        ' Create image.
        Dim imageFile As Image = Image.FromFile("reports\logo.bmp")
        ' Draw image to screen.
        e.Graphics.DrawImage(imageFile, New PointF(100.0F, 30.0F))
        ' Create font and brush.
        Dim drawFont As New Font("宋体", 18)
        Dim drawBrush As New SolidBrush(Color.Black)
        ' Create point for upper-left corner of drawing.
        Dim x As Single = 200.0F
        Dim y As Single = 65.0F
        ' Draw string to screen.
        e.Graphics.DrawString("横店集团东磁股份有限公司软磁事业本部", drawFont, drawBrush, x, y)
        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 1)
        ' Create location and size of rectangle.
        'x = 100.0F
        'y = 110.0F
        Dim width As Single = 357.0F
        Dim height As Single = 31.5F
        Dim i As Integer
        Dim j As Integer
        For i = 0 To 1
            x = 50.0F + 357.0F * i
            For j = 0 To 2
                y = 110.0F + 31.5F * j
                ' Draw rectangle to screen.
                e.Graphics.DrawRectangle(blackPen, x, y, width, height)
            Next
        Next
        height = 45.0F
        For i = 0 To 8
            x = 50.0F
            y = 250.0F + height * i
            width = 150.0F
            '客户型号'客户材质
            e.Graphics.DrawRectangle(blackPen, x, y, width, height)
            x += width
            width = 200.0F
            '产品名称'规格型号'产品属性'单位
            e.Graphics.DrawRectangle(blackPen, x, y, width, height)
            x += width
            width = 50.0F
            '重量
            e.Graphics.DrawRectangle(blackPen, x, y, width, height)
            x += width
            width = 50.0F
            '币种
            e.Graphics.DrawRectangle(blackPen, x, y, width, height)
            x += width
            width = 75.0F
            '单价
            e.Graphics.DrawRectangle(blackPen, x, y, width, height)
            x += width
            width = 50.0F
            '最小包装量
            e.Graphics.DrawRectangle(blackPen, x, y, width, height)
            x += width
            width = 50.0F
            '最小订单量
            e.Graphics.DrawRectangle(blackPen, x, y, width, height)
            x += width
            width = 100.0F
            '备注
            e.Graphics.DrawRectangle(blackPen, x, y, width, height)
        Next
        y = 655.0F
        x = 50.0F
        width = 725.0F
        height = 70.0F
        '备注说明
        e.Graphics.DrawRectangle(blackPen, x, y, width, height)
        y = 725.0F
        x = 50.0F
        width = 725.0F
        height = 55.0F
        '其他事项
        e.Graphics.DrawRectangle(blackPen, x, y, width, height)
        '报价单
        drawFont = New Font("黑体", 20, FontStyle.Bold)
        x = 250.0F
        y = 208.0F
        e.Graphics.DrawString("软磁事业本部报价单", drawFont, drawBrush, x, y)
        '单位名称
        drawFont = New Font("宋体", 12)
        x = 50.5F
        y = 115.0F
        e.Graphics.DrawString("TO：" & Trim(LblKhmc.Text), drawFont, drawBrush, x, y)
        x = 50.5F + 357.0F
        e.Graphics.DrawString("REF NO：" & Trim(Me.TxtDjh.Text), drawFont, drawBrush, x, y)
        x = 50.5F
        y = 115.0F + 31.5F
        e.Graphics.DrawString("ATTN：" & IIf(rcDataset.Tables("rc_khxx").Rows(0).Item("lxr").GetType.ToString <> "System.DBNull", Trim(rcDataset.Tables("rc_khxx").Rows(0).Item("lxr")), ""), drawFont, drawBrush, x, y)
        x = 50.5F + 357.0F
        e.Graphics.DrawString("DATE：" & Trim(DtpBjrq.Value.Date.ToLongDateString), drawFont, drawBrush, x, y)
        x = 50.5F
        y = 115.0F + 31.5F + 31.5F
        e.Graphics.DrawString("FAX NO：" & IIf(rcDataset.Tables("rc_khxx").Rows(0).Item("fax").GetType.ToString <> "System.DBNull", Trim(rcDataset.Tables("rc_khxx").Rows(0).Item("fax")), ""), drawFont, drawBrush, x, y)
        x = 50.5F + 357.0F
        e.Graphics.DrawString("PAGES：1", drawFont, drawBrush, x, y)
        '客户型号
        x = 75.0F
        y = 265.0F
        e.Graphics.DrawString("客户型号", drawFont, drawBrush, x, y)
        '产品名称
        x = 250.0F
        y = 265.0F
        e.Graphics.DrawString("产品名称", drawFont, drawBrush, x, y)
        '重量
        x = 405.0F
        y = 265.0F
        e.Graphics.DrawString("重量", drawFont, drawBrush, x, y)
        '币种
        x = 455.0F
        y = 265.0F
        e.Graphics.DrawString("币种", drawFont, drawBrush, x, y)
        '单价
        x = 505.0F
        y = 265.0F
        e.Graphics.DrawString("单价", drawFont, drawBrush, x, y)
        '最小包装数量
        x = 580.0F
        y = 265.0F
        e.Graphics.DrawString("SPQ", drawFont, drawBrush, x, y)
        '最小订单数量
        x = 630.0F
        y = 265.0F
        e.Graphics.DrawString("MOQ", drawFont, drawBrush, x, y)
        '备注
        x = 680.0F
        y = 265.0F
        e.Graphics.DrawString("备注", drawFont, drawBrush, x, y)
        height = 45.0F

        'Dim unused As New RectangleF

        Dim drawRect As RectangleF
        For i = 0 To rcDataset.Tables("rc_bjdnr").Rows.Count - 1
            '客户型号
            x = 50.5F
            y = 252.0F + (i + 1) * height
            width = 150.0F
            drawRect = New RectangleF(x, y, width, height)
            e.Graphics.DrawString(Trim(rcDataset.Tables("rc_bjdnr").Rows(i).Item("khlh")) & "  " & Trim(rcDataset.Tables("rc_bjdnr").Rows(i).Item("khcz")), drawFont, drawBrush, drawRect)
            '产品名称
            x = 200.5F
            y = 252.0F + (i + 1) * height
            width = 200.0F
            drawRect = New RectangleF(x, y, width, height)
            'e.Graphics.DrawString(Trim(rcDataset.Tables("rc_bjdnr").Rows(i).Item("cpmc")) & "  " & Trim(rcDataset.Tables("rc_bjdnr").Rows(i).Item("cpgg")) & "  " & Trim(rcDataset.Tables("rc_bjdnr").Rows(i).Item("cpmemo")) & "  " & Trim(rcDataset.Tables("rc_bjdnr").Rows(i).Item("dw")), drawFont, drawBrush, drawRect)
            e.Graphics.DrawString(Trim(rcDataset.Tables("rc_bjdnr").Rows(i).Item("cpmc")) & IIf(Trim(rcDataset.Tables("rc_bjdnr").Rows(i).Item("cpgg")).Length > 0, "  " & Trim(rcDataset.Tables("rc_bjdnr").Rows(i).Item("cpgg")), "") & IIf(Trim(rcDataset.Tables("rc_bjdnr").Rows(i).Item("cpmemo")).Length > 0, "  " & Trim(rcDataset.Tables("rc_bjdnr").Rows(i).Item("cpmemo")), "") & IIf(Trim(rcDataset.Tables("rc_bjdnr").Rows(i).Item("dw")).Length > 0, "  " & Trim(rcDataset.Tables("rc_bjdnr").Rows(i).Item("dw")), ""), drawFont, drawBrush, drawRect)
            '重量
            x = 400.5F
            y = 265.0F + (i + 1) * height
            e.Graphics.DrawString(Format(rcDataset.Tables("rc_bjdnr").Rows(i).Item("zl"), IIf(rcDataset.Tables("rc_bjdnr").Rows(i).Item("zl") >= 10, "0.00;;#.#", "0.0000;;#.#")), drawFont, drawBrush, x, y)
            'e.Graphics.DrawString(Format(rcDataset.Tables("rc_bjdnr").Rows(i).Item("zl"), "0.000;;#.#"), drawFont, drawBrush, x, y)
            '币种
            x = 450.5F
            y = 265.0F + (i + 1) * height
            e.Graphics.DrawString(Trim(rcDataset.Tables("rc_bjdnr").Rows(i).Item("wbdm")), drawFont, drawBrush, x, y)
            '单价
            x = 500.5F
            y = 265.0F + (i + 1) * height
            e.Graphics.DrawString(Format(rcDataset.Tables("rc_bjdnr").Rows(i).Item("dj"), IIf(rcDataset.Tables("rc_bjdnr").Rows(i).Item("dj") >= 10, "0.00;;#.#", "0.00000;;#.#")), drawFont, drawBrush, x, y)
            '最小包装数量
            x = 575.5F
            y = 265.0F + (i + 1) * height
            e.Graphics.DrawString(rcDataset.Tables("rc_bjdnr").Rows(i).Item("spq"), drawFont, drawBrush, x, y)
            '最小订单数量
            x = 625.5F
            y = 265.0F + (i + 1) * height
            e.Graphics.DrawString(rcDataset.Tables("rc_bjdnr").Rows(i).Item("moq"), drawFont, drawBrush, x, y)
            '备注
            x = 675.5F
            y = 252.0F + (i + 1) * height
            width = 75.0F
            drawRect = New RectangleF(x, y, width, height)
            e.Graphics.DrawString(Trim(rcDataset.Tables("rc_bjdnr").Rows(i).Item("bjmemo")), drawFont, drawBrush, drawRect)
        Next
        '备注内容
        x = 50.5F
        y = 655.5F
        drawFont = New Font("宋体", 9)
        e.Graphics.DrawString("备注：1、本报价自即日起1个月内有效；", drawFont, drawBrush, x, y)
        y = 675.5F
        e.Graphics.DrawString("      2、无特殊说明，RMB报价为含税单价，外币报价为FOB上海价；", drawFont, drawBrush, x, y)
        y = 700.5F
        e.Graphics.DrawString("      3、USD对RMB汇率6.62，HKD对RMB汇率0.85，若汇率波动+/-3%以上时，需重新确认单价。", drawFont, drawBrush, x, y)
        'y = 725.5F
        'e.Graphics.DrawString("      ；", drawFont, drawBrush, x, y)
        y = 725.5F
        width = 625.0F
        height = 96.0F
        drawRect = New RectangleF(x, y, width, height)
        e.Graphics.DrawString("其他事项：" & Trim(TxtBjtk.Text), drawFont, drawBrush, drawRect)
        '客户签章:
        drawFont = New Font("黑体", 16, FontStyle.Bold)
        x = 50.5F
        y = 850.0F
        e.Graphics.DrawString("客户确", drawFont, drawBrush, x, y)
        x = 50.5F
        y = 875.0F
        e.Graphics.DrawString("认反馈____________", drawFont, drawBrush, x, y)
        drawFont = New Font("黑体", 16, FontStyle.Bold)
        x = 400.0F
        y = 850.0F
        e.Graphics.DrawString("软磁事业本部", drawFont, drawBrush, x, y)
        x = 425.0F
        y = 875.0F
        e.Graphics.DrawString("副总经理", drawFont, drawBrush, x, y)
        x = 50.0F
        y = 940.0F
        e.Graphics.DrawLine(blackPen, x, y, x + 625.0F, y)
        x = 55.0F
        y = 950.0F
        e.Graphics.DrawString("公司地址：浙江省东阳市横店工业区", drawFont, drawBrush, x, y)
        y = 980.0F
        e.Graphics.DrawString("电话：0086-579-86588318", drawFont, drawBrush, x, y)
        y = 1010.0F
        e.Graphics.DrawString("传真：0086-579-86550621", drawFont, drawBrush, x, y)
        y = 1040.0F
        e.Graphics.DrawString("E-mail：sales@dmegc.com.cn", drawFont, drawBrush, x, y)
        imageFile = Image.FromFile("reports\qm.bmp")
        ' Draw image to screen.
        e.Graphics.DrawImage(imageFile, New PointF(560.0F, 835.0F))
    End Sub

#Region "另存为"

    Private Sub BtnSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveAs.Click
        '调用表单
        Dim rcFrm As New FrmOeBjdSaveAs
        With rcFrm
            If .ShowDialog() = DialogResult.OK Then
                Dim strPath As String = .TxtFolderName.Text
                GeneratePdfFile()
                If System.IO.File.Exists(Application.StartupPath & "\quotation.pdf") Then
                    System.IO.File.Copy(Application.StartupPath & "\quotation.pdf", strPath & "\quotation.pdf", True)
                    MsgBox("已保存。")
                End If
            End If
        End With
    End Sub

#End Region

#Region "发送邮件"

    Private Function GeneratePdfFile() As Boolean

        'Dim rcDocument As New iTextSharp.text.Document
        'Dim s As String
        's = Application.StartupPath & "\quotation.pdf"
        'If IO.File.Exists(s) Then
        '    IO.File.Delete(s)
        'End If
        'Dim fs As IO.FileStream
        'fs = New IO.FileStream(s, IO.FileMode.CreateNew)
        'Dim rcWriter As iTextSharp.text.pdf.PdfWriter
        'rcWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(rcDocument, fs)
        ''打开目标文档对象
        'Dim baseFont As iTextSharp.text.pdf.BaseFont = iTextSharp.text.pdf.BaseFont.CreateFont("宋体", iTextSharp.text.pdf.BaseFont.IDENTITY_H, iTextSharp.text.pdf.BaseFont.EMBEDDED)
        ''要设置字体和大小
        'Dim p As New iTextSharp.text.Paragraph("软磁部", New Font(baseFont, 13))
        'Dim cell As New iTextSharp.text.pdf.PdfPCell(p)
        ''设置cell属性
        'cell.Border = iTextSharp.text.Rectangle.NO_BORDER
        'table.addcell(cell)

        Dim baseFont As iTextSharp.text.pdf.BaseFont = iTextSharp.text.pdf.BaseFont.CreateFont("C:\\WINDOWS\\FONTS\\STSONG.TTF", iTextSharp.text.pdf.BaseFont.IDENTITY_H, iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED)
        Dim drawBigFont As New iTextSharp.text.Font(baseFont, 18)
        Dim drawFont As New iTextSharp.text.Font(baseFont, 12)
        Dim drawSmallFont As New iTextSharp.text.Font(baseFont, 9)
        Dim doc As New iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 20, 20, 40, 40)
        Try
            iTextSharp.text.pdf.PdfWriter.GetInstance(doc, New FileStream("quotation.pdf", FileMode.Create))
            doc.Open()
            '公司logo
            Dim imgLogo As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(Application.StartupPath + IIf(Mid(Me.TxtDjh.Text, 1, 4) = "BJDJ", "\reports\logo.jpg", "\reports\logo_jc.jpg"))
            Dim imgQm As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(Application.StartupPath + IIf(Mid(Me.TxtDjh.Text, 1, 4) = "BJDJ", "\reports\qm.bmp", "\reports\qm_jc.png"))
            Dim imgLine As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(Application.StartupPath + "\reports\line.jpg")

            'img.SetAbsolutePosition(20, 20) '(iTextSharp.text.PageSize.POSTCARD.Width - img.ScaledWidth) / 2, (iTextSharp.text.PageSize.POSTCARD.Height - img.ScaledHeight) / 2)
            'doc.Add(img)
            imgLogo.ScalePercent(30)
            imgQm.ScalePercent(85)


            Dim aTable As New iTextSharp.text.pdf.PdfPTable(4)
            Dim aHeaderWidths As Single() = {20, 56, 8, 16}
            aTable.SetWidths(aHeaderWidths)
            Dim aCell1 As New iTextSharp.text.pdf.PdfPCell()
            aCell1.AddElement(imgLogo)
            aCell1.Border = iTextSharp.text.Rectangle.NO_BORDER ' Or iTextSharp.text.Rectangle.LEFT_BORDER Or iTextSharp.text.Rectangle.RIGHT_BORDER Or iTextSharp.text.Rectangle.BOTTOM_BORDER
            aCell1.Rowspan = (4)
            aTable.AddCell(aCell1)

            Dim aCell2 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(IIf(Mid(Me.TxtDjh.Text, 1, 4) = "BJDJ", "横店集团东磁股份有限公司", "宜宾金川电子有限责任公司"), drawBigFont)) With {
                .Border = iTextSharp.text.Rectangle.NO_BORDER,
                .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            }
            aTable.AddCell(aCell2)

            '报价单号
            Dim aCell6 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("", drawSmallFont)) With {
                .Border = iTextSharp.text.Rectangle.NO_BORDER,
                .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                .Rowspan = (2),
                .Colspan = (2)
            }
            aTable.AddCell(aCell6)

            Dim aCell3 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(IIf(Mid(Me.TxtDjh.Text, 1, 4) = "BJDJ", "HengDian Group DMEGC Magnetics Co.,Ltd", "Yibin Jinchuan Electronics Co., Ltd"), drawFont)) With {
                .Border = iTextSharp.text.Rectangle.NO_BORDER,
                .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            }
            aTable.AddCell(aCell3)

            Dim aCell4 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(IIf(Mid(Me.TxtDjh.Text, 1, 4) = "BJDJ", "软磁事业本部报价单", "报  价  单"), drawBigFont)) With {
                .Border = iTextSharp.text.Rectangle.NO_BORDER,
                .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
            }
            aTable.AddCell(aCell4)

            '报价单号
            'aCell8.Border = iTextSharp.text.Rectangle.NO_BORDER
            Dim aCell8 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("RefNO.", drawSmallFont)) With {
                .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
            }
            'aCell8.Rowspan = (2)
            aTable.AddCell(aCell8)

            '报价单号
            'aCell10.Border = iTextSharp.text.Rectangle.NO_BORDER
            Dim aCell10 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(Me.TxtDjh.Text, drawSmallFont)) With {
                .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
            }
            'aCell10.Rowspan = (2)
            aTable.AddCell(aCell10)

            Dim aCell5 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(IIf(Mid(Me.TxtDjh.Text, 1, 4) = "BJDJ", "Soft Ferrite Division Quotation", "Quotation"), drawFont)) With {
                .Border = iTextSharp.text.Rectangle.NO_BORDER,
                .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
            }
            aTable.AddCell(aCell5)

            'aCell7.Border = iTextSharp.text.Rectangle.NO_BORDER
            Dim aCell7 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("DATE:", drawSmallFont)) With {
                .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
            }
            'aCell7.Rowspan = (2)
            aTable.AddCell(aCell7)

            '报价日期
            'aCell9.Border = iTextSharp.text.Rectangle.NO_BORDER
            Dim aCell9 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(Me.DtpBjrq.Value.ToShortDateString, drawSmallFont)) With {
                .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
            }
            'aCell9.Rowspan = (2)
            aTable.AddCell(aCell9)

            doc.Add(aTable)
            '
            Dim bTable As New iTextSharp.text.pdf.PdfPTable(1)
            Dim bHeaderWidths As Single() = {100}
            bTable.SetWidths(bHeaderWidths)

            Dim cell1 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("---------------------------------------------------------------------------------------------------------------------", drawFont))
            'cell1.BackgroundColor = iTextSharp.text.BaseColor.BLACK
            cell1.AddElement(imgLine)
            cell1.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
            cell1.Border = iTextSharp.text.Rectangle.NO_BORDER
            bTable.AddCell(cell1)
            Dim cell2 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("To：" & Me.LblKhmc.Text, drawFont)) With {
                .Border = iTextSharp.text.Rectangle.NO_BORDER,
                .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
            }
            bTable.AddCell(cell2)
            Dim cell4 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("Address：" & strAddress, drawFont)) With {
                .Border = iTextSharp.text.Rectangle.NO_BORDER,
                .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
            }
            bTable.AddCell(cell4)
            Dim cell3 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("Attn:" & strLxr, drawFont)) With {
                .Border = iTextSharp.text.Rectangle.NO_BORDER,
                .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
            }
            bTable.AddCell(cell3)
            Dim cell5 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("Remarks：" & Me.TxtBjtk.Text, drawFont)) With {
                .Border = iTextSharp.text.Rectangle.NO_BORDER,
                .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
            }
            bTable.AddCell(cell5)
            Dim cell6 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(" ", drawFont)) With {
                .Border = iTextSharp.text.Rectangle.NO_BORDER,
                .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
            }
            bTable.AddCell(cell6)
            Dim cell7 As New iTextSharp.text.pdf.PdfPCell()
            'cell7.AddElement(New iTextSharp.text.Phrase("REF NO：" & Trim(Me.TxtDjh.Text), drawFont))
            'bTable.AddCell(cell7)
            doc.Add(bTable)
            '
            Dim cTable As New iTextSharp.text.pdf.PdfPTable(8)

            Dim cHeaderWidths As Single() = {20, 20, 5.5, 6, 10.5, 6.5, 6.5, 18}
            cTable.SetWidths(cHeaderWidths)
            'cTable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            'cTable.DefaultCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
            'cTable.DefaultCell.PaddingLeft = 4
            'cTable.DefaultCell.PaddingTop = 0
            'cTable.DefaultCell.PaddingBottom = 4
            For i As Integer = 0 To rcDataset.Tables("rc_bjdnr").Rows.Count
                If i = 0 Then
                    '报价单标题
                    '客户料号
                    Dim caTable As New iTextSharp.text.pdf.PdfPTable(1) With {
                        .PaddingTop = 0
                    }
                    Dim cellaa As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("Customer P/N", drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                        .Border = iTextSharp.text.Rectangle.NO_BORDER
                    }
                    caTable.AddCell(cellaa)
                    Dim cellab As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("客户料号", drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                        .Border = iTextSharp.text.Rectangle.NO_BORDER
                    }
                    caTable.AddCell(cellab)
                    cTable.AddCell(caTable)

                    '品名规格
                    Dim cbTable As New iTextSharp.text.pdf.PdfPTable(1)
                    Dim cellba As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("Description", drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                        .Border = iTextSharp.text.Rectangle.NO_BORDER
                    }
                    Dim cellbb As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("品名/规格", drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                        .Border = iTextSharp.text.Rectangle.NO_BORDER
                    }
                    cbTable.AddCell(cellba)
                    cbTable.AddCell(cellbb)
                    cTable.AddCell(cbTable)

                    '单位
                    Dim ccTable As New iTextSharp.text.pdf.PdfPTable(1)
                    Dim cellca As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("Unit", drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                        .Border = iTextSharp.text.Rectangle.NO_BORDER
                    }
                    Dim cellcb As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("单位", drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                        .Border = iTextSharp.text.Rectangle.NO_BORDER
                    }
                    ccTable.AddCell(cellca)
                    ccTable.AddCell(cellcb)
                    cTable.AddCell(ccTable)

                    '重量
                    Dim cdTable As New iTextSharp.text.pdf.PdfPTable(1)
                    Dim cellda As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("N.W", drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                        .Border = iTextSharp.text.Rectangle.NO_BORDER
                    }
                    Dim celldb As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("重量", drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                        .Border = iTextSharp.text.Rectangle.NO_BORDER
                    }
                    cdTable.AddCell(cellda)
                    cdTable.AddCell(celldb)
                    cTable.AddCell(cdTable)

                    '单价
                    Dim ceTable As New iTextSharp.text.pdf.PdfPTable(1)
                    Dim cellea As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("Unit Price", drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                        .Border = iTextSharp.text.Rectangle.NO_BORDER
                    }
                    Dim celleb As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("单价", drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                        .Border = iTextSharp.text.Rectangle.NO_BORDER
                    }
                    ceTable.AddCell(cellea)
                    ceTable.AddCell(celleb)
                    cTable.AddCell(ceTable)

                    'SPQ
                    Dim cfTable As New iTextSharp.text.pdf.PdfPTable(1)
                    Dim cellfa As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("SPQ", drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                        .Border = iTextSharp.text.Rectangle.NO_BORDER
                    }
                    'Dim cellfb As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("最小包装量", drawSmallFont))
                    'cellfb.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    'cellfb.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                    'cellfb.Border = iTextSharp.text.Rectangle.NO_BORDER
                    cfTable.AddCell(cellfa)
                    'cfTable.AddCell(cellfb)
                    cTable.AddCell(cfTable)

                    'MOQ
                    Dim cgTable As New iTextSharp.text.pdf.PdfPTable(1)
                    Dim cellga As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("MOQ", drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                        .Border = iTextSharp.text.Rectangle.NO_BORDER
                    }
                    'Dim cellgb As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("最小起订量", drawSmallFont))
                    'cellgb.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    'cellgb.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                    'cellgb.Border = iTextSharp.text.Rectangle.NO_BORDER
                    cgTable.AddCell(cellga)
                    'cgTable.AddCell(cellgb)
                    cTable.AddCell(cgTable)

                    '备注
                    Dim chTable As New iTextSharp.text.pdf.PdfPTable(1)
                    Dim cellha As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("Note", drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                        .Border = iTextSharp.text.Rectangle.NO_BORDER
                    }
                    Dim cellhb As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("备注", drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                        .Border = iTextSharp.text.Rectangle.NO_BORDER
                    }
                    chTable.AddCell(cellha)
                    chTable.AddCell(cellhb)
                    cTable.AddCell(chTable)
                Else
                    If rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("khlh").GetType.ToString = "System.DBNull" Then
                        rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("khlh") = ""
                    End If
                    If rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("khcz").GetType.ToString = "System.DBNull" Then
                        rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("khcz") = ""
                    End If
                    If rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("cpmc").GetType.ToString = "System.DBNull" Then
                        rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("cpmc") = ""
                    End If
                    If rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("cpgg").GetType.ToString = "System.DBNull" Then
                        rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("cpgg") = ""
                    End If
                    If rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("dw").GetType.ToString = "System.DBNull" Then
                        rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("dw") = ""
                    End If
                    If rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("zl").GetType.ToString = "System.DBNull" Then
                        rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("zl") = 0.0
                    End If
                    If rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("dj").GetType.ToString = "System.DBNull" Then
                        rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("dj") = 0.0
                    End If
                    If rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("spq").GetType.ToString = "System.DBNull" Then
                        rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("spq") = 0
                    End If
                    If rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("moq").GetType.ToString = "System.DBNull" Then
                        rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("moq") = 0
                    End If
                    If rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("bjmemo").GetType.ToString = "System.DBNull" Then
                        rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("bjmemo") = ""
                    End If
                    '报价单内容
                    Dim cella As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("khlh") & IIf(Not String.IsNullOrEmpty(rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("khcz")), "," & rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("khcz"), ""), drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                        .MinimumHeight = 25
                    }
                    'cella.FixedHeight = 25
                    cTable.AddCell(cella)

                    Dim cellb As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("cpmc") & IIf(Not String.IsNullOrEmpty(rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("cpgg")), "," & rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("cpgg"), ""), drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                    }
                    cTable.AddCell(cellb)

                    Dim cellc As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("dw"), drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                    }
                    cTable.AddCell(cellc)

                    Dim celld As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("zl"), drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                    }
                    cTable.AddCell(celld)

                    Dim celle As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(Me.TxtWbdm.Text & " " & rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("dj"), drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                    }
                    cTable.AddCell(celle)

                    Dim cellf As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("spq"), drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                    }
                    cTable.AddCell(cellf)

                    Dim cellg As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("moq"), drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, '水平
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE '垂直
                        }
                    cTable.AddCell(cellg)

                    Dim cellh As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(rcDataset.Tables("rc_bjdnr").Rows(i - 1).Item("bjmemo"), drawSmallFont)) With {
                        .HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,
                        .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                    }
                    cTable.AddCell(cellh)
                End If
            Next
            For i As Integer = rcDataset.Tables("rc_bjdnr").Rows.Count + 1 To 10
                '报价单空行
                Dim cella As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("", drawSmallFont)) With {
                    .HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,
                    .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                    .MinimumHeight = 25
                }
                'cella.FixedHeight = 25
                cTable.AddCell(cella)

                Dim cellb As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("", drawSmallFont)) With {
                    .HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,
                    .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                }
                cTable.AddCell(cellb)

                Dim cellc As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("", drawSmallFont)) With {
                    .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                    .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                }
                cTable.AddCell(cellc)

                Dim celld As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("", drawSmallFont)) With {
                    .HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT,
                    .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                }
                cTable.AddCell(celld)

                Dim celle As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("", drawSmallFont)) With {
                    .HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT,
                    .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                }
                cTable.AddCell(celle)

                Dim cellf As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("", drawSmallFont)) With {
                    .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                    .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                }
                cTable.AddCell(cellf)

                Dim cellg As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("", drawSmallFont)) With {
                    .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, '水平
                    .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE '垂直
                    }
                cTable.AddCell(cellg)

                Dim cellh As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("", drawSmallFont)) With {
                    .HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,
                    .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                }
                cTable.AddCell(cellh)

            Next

            doc.Add(cTable)
            '
            Dim dTable As New iTextSharp.text.pdf.PdfPTable(1)
            Dim dCell1 As New iTextSharp.text.pdf.PdfPCell()
            dCell1.AddElement(New iTextSharp.text.Phrase("备注：" & Me.TxtMemo1.Text, drawSmallFont))
            dCell1.AddElement(New iTextSharp.text.Phrase("            " & Me.TxtMemo2.Text, drawSmallFont))
            dCell1.AddElement(New iTextSharp.text.Phrase("            " & Me.TxtMemo3.Text, drawSmallFont))
            dCell1.AddElement(New iTextSharp.text.Phrase("            " & Me.TxtMemo4.Text, drawSmallFont))
            If Mid(Me.TxtDjh.Text, 1, 4) = "BJDJ" Then
                dCell1.AddElement(New iTextSharp.text.Phrase("            " & Me.TxtMemo5.Text, drawSmallFont))
            End If
            dTable.AddCell(dCell1)
            doc.Add(dTable)
            ''
            'Dim eTable As New iTextSharp.text.pdf.PdfPTable(1)
            'Dim eCell1 As New iTextSharp.text.pdf.PdfPCell()
            'eCell1.AddElement(New iTextSharp.text.Phrase("其他事项：" & Trim(Me.TxtBjtk.Text), drawFont))
            'eTable.AddCell(eCell1)
            'doc.Add(eTable)
            '
            Dim fTable As New iTextSharp.text.pdf.PdfPTable(3)
            Dim fHeaderWidths As Single() = {40, 30, 40}
            fTable.SetWidths(fHeaderWidths)
            Dim fCell1 As New iTextSharp.text.pdf.PdfPCell()
            fCell1.AddElement(New iTextSharp.text.Phrase(IIf(Mid(Me.TxtDjh.Text, 1, 4) = "BJDJ", "公司地址：浙江省东阳市横店工业区", "公司地址：四川省宜宾市临港经济技术开发区港园西路63号"), drawSmallFont))
            fCell1.AddElement(New iTextSharp.text.Phrase(IIf(Mid(Me.TxtDjh.Text, 1, 4) = "BJDJ", "电话：0086-579-86588318", "Western Section 63, Gangyuan Road, Ligang Economic & Technology Development Zone, Yibin, Sichuan, China"), drawSmallFont))
            fCell1.AddElement(New iTextSharp.text.Phrase(IIf(Mid(Me.TxtDjh.Text, 1, 4) = "BJDJ", "传真：0086-579-86550621", "传真：0086-831-3620814"), drawSmallFont))
            fCell1.AddElement(New iTextSharp.text.Phrase(IIf(Mid(Me.TxtDjh.Text, 1, 4) = "BJDJ", "E-mail：sales@dmegc.com.cn", ""), drawSmallFont))
            'fCell1.Border = iTextSharp.text.Rectangle.NO_BORDER
            fCell1.Rowspan = 2
            fTable.AddCell(fCell1)
            Dim fCell2 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(IIf(Mid(Me.TxtDjh.Text, 1, 4) = "BJDJ", "软磁事业本部", "软磁部"), drawFont)) With {
                .MinimumHeight = 40,
                .Border = iTextSharp.text.Rectangle.LEFT_BORDER,
                .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
            }
            fTable.AddCell(fCell2)

            Dim fCell4 As New iTextSharp.text.pdf.PdfPCell()
            fCell4.AddElement(imgQm)
            'fCell4.Border = iTextSharp.text.Rectangle.NO_BORDER
            fCell4.Rowspan = 2
            fTable.AddCell(fCell4)

            'fCell3.Border = iTextSharp.text.Rectangle.NO_BORDER
            Dim fCell3 As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(IIf(Mid(Me.TxtDjh.Text, 1, 4) = "BJDJ", "副总经理", "部长"), drawFont)) With {
                .MinimumHeight = 40,
                .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
            }
            fTable.AddCell(fCell3)
            doc.Add(fTable)

        Catch de As iTextSharp.text.DocumentException
            MsgBox("程序错误。" + de.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
        Catch ioe As IOException
            MsgBox("程序错误。" + ioe.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
        End Try
        doc.Close()
    End Function

    Private Sub BtnToEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnToEmail.Click
        GeneratePdfFile()
        sendEmail()
        'mailList, "TEST", "TEST", AttachFile
    End Sub

    '发送电子邮件
    Function SendEmail() As Boolean
        '取发件人信息
        Dim i As Integer
        Dim strEmail As String = ""
        Dim strSmtp As String = ""
        Dim strAccount As String = ""
        Dim strPwd As String = ""
        Dim blnSfyz As Boolean = False
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT paraid,parastrvalue,paradblvalue FROM rc_para WHERE SUBSTR(paraid,1,3) = '发件人' Order by paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            rcOleDbCommand.CommandText = "SELECT rc_khxx.khdm,rc_khxx.khmc,rc_zyxx.email FROM rc_khxx LEFT JOIN rc_zyxx ON rc_zyxx.zydm = rc_khxx.zydm WHERE khdm = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKhdm.Text)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("khemail") IsNot Nothing Then
                rcDataset.Tables("khemail").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "khemail")
        Catch ex As Exception
            MsgBox("程序错误2。" & Chr(13) & ex.Message)
            Return False
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_para").Rows.Count = 5 Then
            If rcDataset.Tables("rc_para").Rows(3).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                strEmail = rcDataset.Tables("rc_para").Rows(3).Item("parastrvalue")
            End If
            If rcDataset.Tables("rc_para").Rows(2).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                strSmtp = rcDataset.Tables("rc_para").Rows(2).Item("parastrvalue")
            End If
            If rcDataset.Tables("rc_para").Rows(1).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                strAccount = rcDataset.Tables("rc_para").Rows(1).Item("parastrvalue")
            End If
            If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                strPwd = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
            End If
            If rcDataset.Tables("rc_para").Rows(4).Item("paradblvalue").GetType.ToString <> "System.DBNull" Then
                blnSfyz = rcDataset.Tables("rc_para").Rows(4).Item("paradblvalue")
            End If
        Else
            MsgBox("请检查发件人邮件参数设置。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return False
        End If
        If rcDataset.Tables("khemail").Rows.Count = 0 Then
            Return False
        Else
            If rcDataset.Tables("khemail").Rows(0).Item("email").GetType.ToString = "System.DBNull" Then
                Return False
            End If
        End If
        '设置邮件内容 
        ''设置电子邮件优先级 
        Dim mail As New MailMessage With {
            .From = New MailAddress(strEmail),
            .Subject = "软磁部产品报价单",
            .Body = "您好：详细报价请查看邮件附件。",
            .Priority = MailPriority.High
        }
        ''获取与此电子邮件传输的标头 
        'mail.Headers.Add("杭州公交", "物资供应部")
        'mail.Headers.Add("位置", "杭州")
        'mail.Headers.Add("YourCompany", "yourname")
        'mail.Headers.Add("YourLocation", "yourlocation")
        Dim asd As String() = Me.TxtEmail.Text.Split(";")
        mail.To.Clear()
        'mail.To.Add(strEmail)
        'mail.To.Add(rcDataset.Tables("khemail").Rows(0).Item("email"))
        For i = 0 To asd.Length - 1
            mail.To.Add(asd(i))
        Next
        '附件文件名,用于收件人收到附件时显示的名称  
        Dim objFile As New System.Net.Mail.Attachment("quotation.pdf") With {
            .Name = "quotation.pdf"
        }
        '加入附件,可以多次添加  
        mail.Attachments.Add(objFile)
        Dim Mysmtp As New SmtpClient(strSmtp)
        If blnSfyz Then
            Mysmtp.Credentials = New System.Net.NetworkCredential(strAccount, strPwd)
        End If
        Try
            Mysmtp.Send(mail)
            MsgBox("邮件发送成功！", MsgBoxStyle.Information, "提示信息")
            mail.Attachments.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message & mail.To.ToString, MsgBoxStyle.Critical, "抱歉。邮件发送失败")
            Return False
        End Try
        Return True
        'MsgBox("邮件已经发出，邮件已经发送到指定的邮件地址.", MsgBoxStyle.Information, "提示信息")
    End Function

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