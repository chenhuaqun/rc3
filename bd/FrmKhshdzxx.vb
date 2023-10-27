Imports System.Data.OleDb

Public Class FrmKhshdzxx

#Region "定义变量"

    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '数据更新传递
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '管理绑定到相同数据源和数据成员的所有Binding对象
    Dim rcBmb As BindingManagerBase
    '当前记录号
    Dim currentPos As Integer
    '打印文档
    Dim rcRps As RPS.Document = Nothing
    '建立Datatable
    ReadOnly dtKhshdz As New DataTable("oe_khshdz")
    '数据视图
    Dim rcDataView As DataView

#End Region

#Region "初始化"

    Private Sub FrmKhshdzxx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '创建datatable
        dtKhshdz.Columns.Add("khdm", Type.GetType("System.String"))
        dtKhshdz.Columns.Add("khmc", Type.GetType("System.String"))
        dtKhshdz.Columns.Add("xh", Type.GetType("System.Int32"))
        dtKhshdz.Columns.Add("address", Type.GetType("System.String"))
        dtKhshdz.Columns.Add("postcode", Type.GetType("System.String"))
        dtKhshdz.Columns.Add("tel", Type.GetType("System.String"))
        dtKhshdz.Columns.Add("mobile", Type.GetType("System.String"))
        dtKhshdz.Columns.Add("lxr", Type.GetType("System.String"))
        dtKhshdz.Columns.Add("lasttimebz", Type.GetType("System.Boolean"))
        rcDataset.Tables.Add(dtKhshdz)
        With dtKhshdz
            .Columns("khdm").DefaultValue = ""
            .Columns("khmc").DefaultValue = ""
            .Columns("xh").DefaultValue = 1
            .Columns("address").DefaultValue = ""
            .Columns("lasttimebz").DefaultValue = 1
        End With
        '取内容
        rcOleDbConn.Open()
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT * FROM oe_khshdz ORDER BY oe_khshdz.khdm,oe_khshdz.xh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("oe_khshdz") IsNot Nothing Then
                rcDataset.Tables("oe_khshdz").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "oe_khshdz")
        Catch ex As Exception
            MsgBox("程序错误。取oe_khshdz" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        rcDataView = New DataView(rcDataset.Tables("oe_khshdz"))
        rcDataGrid.SetDataBinding(rcDataView, "")
        rcBmb = BindingContext(rcDataView, "")
    End Sub

#End Region

#Region "页面设置"

    Private Sub BtnPageSetup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPageSetup.Click, MnuiPageSetup.Click
        PageSetupEvent()
    End Sub

    Private Sub PageSetupEvent()
        Dim rcFrm As New models.FrmPageSetup
        With rcFrm
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = "KHSHDZ"
            .paraRpsName = "客户收货地址"
            .ShowDialog()
        End With
    End Sub

#End Region

#Region "打印、打印预览"

    Private Sub BtnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPrint.Click, MnuiPrint.Click
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
        End With
    End Sub

    Private Sub BtnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPreview.Click, MnuiPreview.Click
        PreviewEvent()
    End Sub

    Private Sub PreviewEvent()
        PreparePrintData()
        rcRps.Preview()
    End Sub

    Private Sub PreparePrintData()
        Dim rft As String = CurDir() + "\reports\KHSHDZ.rft"
        If rcRps Is Nothing Then
            rcRps = New RPS.Document
        End If
        rcRps.LoadTemplate(rft)
        rcRps.Text(-1, 2) = "单位：" + g_Dwmc
        rcRps.Text(-1, 4) = "打印人：" + g_User_DspName
        Dim i As Integer
        For i = 0 To rcDataset.Tables("oe_khshdz").Rows.Count - 1
            rcRps.Text(i + 1, 1) = rcDataset.Tables("oe_khshdz").Rows(i).Item("khdm")
            rcRps.Text(i + 1, 2) = rcDataset.Tables("oe_khshdz").Rows(i).Item("khmc")
            rcRps.Text(i + 1, 3) = rcDataset.Tables("oe_khshdz").Rows(i).Item("address")
        Next
        '取RPS数据
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps WHERE rpsid = 'KHSHDZ'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_rps") IsNot Nothing Then
                rcDataset.Tables("rc_rps").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_rps")
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
        If rcDataset.Tables("rc_rps").Rows.Count > 0 Then
            '设定值
            rcRps.Scale = rcDataset.Tables("rc_rps").Rows(0).Item("scale")
            rcRps.Orientation = rcDataset.Tables("rc_rps").Rows(0).Item("orientation")
            rcRps.PaperWidth = rcDataset.Tables("rc_rps").Rows(0).Item("paperwidth")
            rcRps.PaperHeight = rcDataset.Tables("rc_rps").Rows(0).Item("paperheight")
            rcRps.PrinterLeft = rcDataset.Tables("rc_rps").Rows(0).Item("printerleft")
            rcRps.PrinterTop = rcDataset.Tables("rc_rps").Rows(0).Item("printertop")
        Else
            '默认值
            rcRps.Scale = 100
            rcRps.Orientation = 1
        End If
    End Sub

#End Region

#Region "输出"

    Private Sub BtnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExport.Click, MnuiExport.Click
        '导出数据
        Exports2Excel(rcDataset.Tables("oe_khshdz"))
    End Sub

    Public Sub Exports2Excel(ByVal paraDataTable As DataTable)
        If paraDataTable.Rows.Count > 0 Then
            Try
                Me.Cursor = Cursors.WaitCursor
                Dim i, j As Integer
                Dim DataArray(paraDataTable.Rows.Count() - 1, paraDataTable.Columns.Count() - 1) As String
                Dim myExcel As New Microsoft.Office.Interop.Excel.Application
                For i = 0 To paraDataTable.Rows.Count() - 1
                    For j = 0 To paraDataTable.Columns.Count() - 1
                        If paraDataTable.Rows(i).Item(j).GetType.ToString <> "System.DBNull" Then
                            DataArray(i, j) = Trim(paraDataTable.Rows(i).Item(j))
                        Else
                            DataArray(i, j) = ""
                        End If
                    Next
                Next
                myExcel.Application.Workbooks.Add(True)
                myExcel.Visible = True
                For j = 0 To paraDataTable.Columns.Count() - 1
                    myExcel.Cells(1, j + 1) = paraDataTable.Columns(j).ColumnName
                Next
                myExcel.Range("A2").Resize(paraDataTable.Rows.Count, paraDataTable.Columns.Count).Value = DataArray
            Catch exp As Exception
                MessageBox.Show("数据导出失败！请查看是否已经安装了Excel。", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        Else
            MessageBox.Show("没有数据！", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

#End Region

#Region "新增"

    Private Sub BtnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNew.Click, MnuiNew.Click
        '新增
        Dim rcFrm As New FrmKhshdzEdit
        With rcFrm
            .ParaAdding = True
            .ParaCurrentPos = rcBmb.Position
            .ParaDataView = rcDataView
            .ShowDialog()
        End With
        Me.rcDataGrid.Refresh()
    End Sub

#End Region

#Region "修改"

    Private Sub BtnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnEdit.Click, MnuiEdit.Click
        '修改
        Dim rcFrm As New FrmKhshdzEdit
        With rcFrm
            .ParaAdding = False
            .ParaDataView = rcDataView
            .ParaCurrentPos = rcBmb.Position
            .ShowDialog()
        End With
        Me.rcDataGrid.Refresh()
    End Sub

#End Region

#Region "删除"

    Private Sub BtnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, MnuiDelete.Click
        '删除
        '删除数据
        If MessageBox.Show("您真地要删除吗？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then
            currentPos = rcBmb.Position
            If Trim(rcBmb.Current("khdm")) = "" Then
                MessageBox.Show("编码不能为空。")
                Return
            End If
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "DELETE FROM oe_khshdz WHERE khdm = ? AND xh = ? "
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = rcBmb.Current("khdm")
                rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = rcBmb.Current("xh")
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "SELECT * FROM oe_khshdz ORDER BY oe_khshdz.khdm,oe_khshdz.xh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("oe_khshdz") IsNot Nothing Then
                    rcDataset.Tables("oe_khshdz").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "oe_khshdz")
                rcBmb.Position = currentPos
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
        End If
    End Sub

#End Region

#Region "刷新"

    Private Sub BtnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRefresh.Click, MnuiRefresh.Click
        '取内容
        rcOleDbConn.Open()
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT * FROM oe_khshdz ORDER BY oe_khshdz.khdm,oe_khshdz.xh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("oe_khshdz") IsNot Nothing Then
                rcDataset.Tables("oe_khshdz").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "oe_khshdz")
        Catch ex As Exception
            MsgBox("程序错误。取oe_khshdz" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
    End Sub

#End Region

#Region "查找"

    Private Sub BtnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSearch.Click, MnuiSearch.Click
        '查找
        Dim rcFrm As New FrmKhshdzFilter
        With rcFrm
            .ParaDataView = rcDataView
            .ShowDialog()
        End With
    End Sub

#End Region

#Region "关闭"

    Private Sub BtnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExit.Click, MnuiExit.Click
        '关闭
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