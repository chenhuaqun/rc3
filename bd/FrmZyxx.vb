Imports System.Data.OleDb

Public Class FrmZyxx

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
    '建立Datatable '我们要利用该datatable进行金额计算
    ReadOnly dtZy As New DataTable("rc_zyxx")
    '打印文档
    Dim rcRps As RPS.Document = Nothing
    '管理绑定到相同数据源和数据成员的所有Binding对象
    'Dim rcBmb As BindingManagerBase
    '当前记录号
    Dim currentPos As Integer

#End Region

#Region "初始化"

    Private Sub FrmZyxx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '数据绑定
        dtZy.Columns.Add("zydm", Type.GetType("System.String"))
        dtZy.Columns.Add("zymc", Type.GetType("System.String"))
        dtZy.Columns.Add("zysm", Type.GetType("System.String"))
        dtZy.Columns.Add("bmdm", Type.GetType("System.String"))
        dtZy.Columns.Add("bmmc", Type.GetType("System.String"))
        dtZy.Columns.Add("icno", Type.GetType("System.String"))
        dtZy.Columns.Add("email", Type.GetType("System.String"))
        rcDataset.Tables.Add(dtZy)
        With dtZy
            .Columns("zydm").DefaultValue = ""
            .Columns("zymc").DefaultValue = ""
            .Columns("zysm").DefaultValue = ""
            .Columns("bmdm").DefaultValue = ""
            .Columns("bmmc").DefaultValue = ""
            .Columns("icno").DefaultValue = ""
            .Columns("email").DefaultValue = ""
        End With
        '显示等待样式鼠标
        Cursor.Current = New Cursor(Application.StartupPath & "\" & "Wait.cur")
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT rc_zyxx.zydm,rc_zyxx.zymc,rc_zyxx.zysm,rc_zyxx.bmdm,rc_bmxx.bmmc,rc_zyxx.icno,rc_zyxx.email FROM rc_zyxx Left Join rc_bmxx On rc_zyxx.bmdm = rc_bmxx.bmdm ORDER BY zydm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_zyxx") IsNot Nothing Then
                rcDataset.Tables("rc_zyxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_zyxx")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        rcDataView = New DataView(rcDataset.Tables("rc_zyxx"))
        rcDataGridView.DataSource = rcDataView
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
            .paraRpsId = "ZYXX"
            .paraRpsName = "职员信息"
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
        'Dim rft1 As String = CurDir() + "\reports\zyxx.csv"
        Dim rft As String = CurDir() + "\reports\zyxx.rft"
        If rcRps Is Nothing Then
            rcRps = New RPS.Document
        End If
        'rcRps.LoadCsvTemplate(rft1)
        'rcRps.SaveTemplate(rft)
        rcRps.LoadTemplate(rft)
        rcRps.Text(-1, 2) = "单位：" + g_Dwmc
        rcRps.Text(-1, 4) = "打印人：" + g_User_DspName
        Dim i As Integer
        For i = 0 To rcDataset.Tables("rc_zyxx").Rows.Count - 1
            rcRps.Text(i + 1, 1) = Trim(rcDataset.Tables("rc_zyxx").Rows(i).Item("zydm"))
            rcRps.Text(i + 1, 2) = Trim(rcDataset.Tables("rc_zyxx").Rows(i).Item("zymc"))
            rcRps.Text(i + 1, 3) = Trim(rcDataset.Tables("rc_zyxx").Rows(i).Item("zysm"))
            rcRps.Text(i + 1, 4) = Trim(rcDataset.Tables("rc_zyxx").Rows(i).Item("bmdm"))
            rcRps.Text(i + 1, 5) = Trim(rcDataset.Tables("rc_zyxx").Rows(i).Item("bmmc"))
        Next
        '取RPS数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps WHERE rpsid = 'ZYXX'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_rps") IsNot Nothing Then
                rcDataset.Tables("rc_rps").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_rps")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
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
        Exports2Excel(rcDataset.Tables("rc_zyxx"))
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
        Dim rcFrm As New FrmZyEdit
        With rcFrm
            .ParaAdding = True
            .ParaCurrentPos = BindingContext(rcDataView, "").Position
            .ParaDataSet = rcDataset
            .ParaDataView = rcDataView
            .ShowDialog()
        End With
        Me.rcDataGridView.Refresh()
    End Sub

#End Region

#Region "修改"

    Private Sub BtnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnEdit.Click, MnuiEdit.Click
        '修改
        Dim rcFrm As New FrmZyEdit
        With rcFrm
            .ParaAdding = False
            .ParaDataSet = rcDataset
            .ParaDataView = rcDataView
            .ParaCurrentPos = BindingContext(rcDataView, "").Position
            .ShowDialog()
        End With
        Me.rcDataGridView.Refresh()
    End Sub

#End Region

#Region "删除"

    Private Sub BtnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, MnuiDelete.Click
        '删除
        Dim i As Integer
        '删除数据
        If MessageBox.Show("您真地要删除吗？" & Trim(BindingContext(rcDataView, "").Current("zydm")), "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then
            currentPos = BindingContext(rcDataView, "").Position
            If Trim(BindingContext(rcDataView, "").Current("zydm")) = "" Then
                MessageBox.Show("编码不能为空。")
                Return
            End If
            '检测使用状态
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                '取带zydm字段的表
                rcOleDbCommand.CommandText = "SELECT table_name,column_name FROM user_tab_columns WHERE column_name = 'ZYDM' AND table_name <> 'RC_ZYXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                '
                For i = 0 To rcDataset.Tables("user_tab_columns").Rows.Count - 1
                    rcOleDbCommand.CommandText = "SELECT Count(*) As cpcnt FROM " & rcDataset.Tables("user_tab_columns").Rows(i).Item("table_name") & " WHERE zydm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = BindingContext(rcDataView, "").Current("zydm")
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("cpcnt") IsNot Nothing Then
                        rcDataset.Tables("cpcnt").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "cpcnt")
                    If rcDataset.Tables("cpcnt").Rows.Count > 0 Then
                        If rcDataset.Tables("cpcnt").Rows(0).Item("cpcnt") > 0 Then
                            MsgBox("该编码在表" & rcDataset.Tables("user_tab_columns").Rows(i).Item("table_name") & "有业务发生，不能删除。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                            Return
                        End If
                    End If
                Next
                '取带zydm1字段的表
                rcOleDbCommand.CommandText = "SELECT table_name,column_name FROM user_tab_columns WHERE column_name = 'ZYDM1' AND table_name <> 'RC_ZYXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                '
                For i = 0 To rcDataset.Tables("user_tab_columns").Rows.Count - 1
                    rcOleDbCommand.CommandText = "SELECT Count(*) As cpcnt FROM " & rcDataset.Tables("user_tab_columns").Rows(i).Item("table_name") & " WHERE zydm1 = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@zydm1", OleDbType.VarChar, 12).Value = BindingContext(rcDataView, "").Current("zydm")
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("cpcnt") IsNot Nothing Then
                        rcDataset.Tables("cpcnt").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "cpcnt")
                    If rcDataset.Tables("cpcnt").Rows.Count > 0 Then
                        If rcDataset.Tables("cpcnt").Rows(0).Item("cpcnt") > 0 Then
                            MsgBox("该编码在表" & rcDataset.Tables("user_tab_columns").Rows(i).Item("table_name") & "有业务发生，不能删除。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                            Return
                        End If
                    End If
                Next
                '取带zydm2字段的表
                rcOleDbCommand.CommandText = "SELECT table_name,column_name FROM user_tab_columns WHERE column_name = 'ZYDM2' AND table_name <> 'RC_ZYXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                '
                For i = 0 To rcDataset.Tables("user_tab_columns").Rows.Count - 1
                    rcOleDbCommand.CommandText = "SELECT Count(*) As cpcnt FROM " & rcDataset.Tables("user_tab_columns").Rows(i).Item("table_name") & " WHERE zydm2 = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@zydm2", OleDbType.VarChar, 12).Value = BindingContext(rcDataView, "").Current("zydm")
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("cpcnt") IsNot Nothing Then
                        rcDataset.Tables("cpcnt").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "cpcnt")
                    If rcDataset.Tables("cpcnt").Rows.Count > 0 Then
                        If rcDataset.Tables("cpcnt").Rows(0).Item("cpcnt") > 0 Then
                            MsgBox("该编码在表" & rcDataset.Tables("user_tab_columns").Rows(i).Item("table_name") & "有业务发生，不能删除。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                            Return
                        End If
                    End If
                Next
            Catch ex As Exception
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "Delete FROM rc_zyxx WHERE zydm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.AddWithValue("@zydm", BindingContext(rcDataView, "").Current("zydm"))
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "SELECT rc_zyxx.zydm,rc_zyxx.zymc,rc_zyxx.zysm,rc_zyxx.bmdm,rc_bmxx.bmmc,rc_zyxx.icno,rc_zyxx.email FROM rc_zyxx Left Join rc_bmxx On rc_zyxx.bmdm = rc_bmxx.bmdm ORDER BY zydm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_zyxx") IsNot Nothing Then
                    rcDataset.Tables("rc_zyxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_zyxx")
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
            BindingContext(rcDataView, "").Position = currentPos
        End If

    End Sub

#End Region

#Region "查找"

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiSearch.Click, BtnSearch.Click
        '查找
        Dim rcFrm As New FrmZyFilter
        With rcFrm
            '.ParaCurrentPos = rcBmb.Position
            .ParaDataView = rcDataView
            .ShowDialog()
        End With
        Me.rcDataGridView.Refresh()

    End Sub

#End Region

#Region "刷新"

    Private Sub BtnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRefresh.Click, MnuiRefresh.Click
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT rc_zyxx.zydm,rc_zyxx.zymc,rc_zyxx.zysm,rc_zyxx.bmdm,rc_bmxx.bmmc,rc_zyxx.icno,rc_zyxx.email FROM rc_zyxx Left Join rc_bmxx On rc_zyxx.bmdm = rc_bmxx.bmdm ORDER BY zydm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_zyxx") IsNot Nothing Then
                rcDataset.Tables("rc_zyxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_zyxx")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
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