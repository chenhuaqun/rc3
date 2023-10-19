Imports System.Data.OleDb

Public Class FrmCostRegionxx

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
    ReadOnly dtCostRegion As New DataTable("rc_costregion")
    '建立Datatable '我们要利用该datatable进行金额计算
    ReadOnly dtCkxx As New DataTable("ckxx")
    '打印文档
    Dim rcRps As RPS.Document = Nothing
    '管理绑定到相同数据源和数据成员的所有Binding对象
    'Dim rcBmb As BindingManagerBase
    '当前记录号
    Dim currentPos As Integer

#End Region

#Region "初始化"

    Private Sub FrmCostRegionxx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '数据绑定
        dtCostRegion.Columns.Add("crdm", Type.GetType("System.String"))
        dtCostRegion.Columns.Add("crmc", Type.GetType("System.String"))
        dtCostRegion.Columns.Add("crsm", Type.GetType("System.String"))
        rcDataset.Tables.Add(dtCostRegion)
        With dtCostRegion
            .Columns("crdm").DefaultValue = ""
            .Columns("crmc").DefaultValue = ""
            .Columns("crsm").DefaultValue = ""
        End With
        '显示等待样式鼠标
        Cursor.Current = New Cursor(Application.StartupPath & "\" & "Wait.cur")
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_costregion ORDER BY crdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_costregion") IsNot Nothing Then
                rcDataset.Tables("rc_costregion").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_costregion")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        rcDataView = New DataView(rcDataset.Tables("rc_costregion"))
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
            .paraRpsId = "CKXX"
            .paraRpsName = "仓库信息"
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
            .ParaRps = rcRps
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
        'Dim rft1 As String = CurDir() + "\reports\bmxx.csv"
        Dim rft As String = CurDir() + "\reports\bmxx.rft"
        If rcRps Is Nothing Then
            rcRps = New RPS.Document
        End If
        'rcRps.LoadCsvTemplate(rft1)
        'rcRps.SaveTemplate(rft)
        rcRps.LoadTemplate(rft)
        rcRps.Text(-1, 2) = "单位：" + g_Dwmc
        rcRps.Text(-1, 4) = "打印人：" + g_User_DspName
        Dim i As Integer
        For i = 0 To rcDataset.Tables("rc_costregion").Rows.Count - 1
            rcRps.Text(i + 1, 1) = Trim(rcDataset.Tables("rc_costregion").Rows(i).Item("crdm"))
            rcRps.Text(i + 1, 2) = Trim(rcDataset.Tables("rc_costregion").Rows(i).Item("crmc"))
            rcRps.Text(i + 1, 3) = Trim(rcDataset.Tables("rc_costregion").Rows(i).Item("crsm"))
        Next
        '取RPS数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps WHERE rpsid = 'CKXX'"
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
        Exports2Excel(rcDataset.Tables("rc_costregion"))
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
        Dim rcFrm As New FrmCostRegionEdit
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
        Dim rcFrm As New FrmCostRegionEdit
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
        '删除数据
        If MessageBox.Show("您真地要删除吗？" & Trim(BindingContext(rcDataView, "").Current("crdm")), "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then
            currentPos = BindingContext(rcDataView, "").Position
            If Trim(BindingContext(rcDataView, "").Current("crdm")) = "" Then
                MessageBox.Show("编码不能为空。")
                Return
            End If
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                '删除成本域关联仓库的数据
                rcOleDbCommand.CommandText = "DELETE FROM rc_cr_ck WHERE crdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.AddWithValue("@crdm", BindingContext(rcDataView, "").Current("crdm"))
                rcOleDbCommand.ExecuteNonQuery()
                '删除成本域编码
                rcOleDbCommand.CommandText = "DELETE FROM rc_costregion WHERE crdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.AddWithValue("@crdm", BindingContext(rcDataView, "").Current("crdm"))
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "SELECT * FROM rc_costregion ORDER BY crdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_costregion") IsNot Nothing Then
                    rcDataset.Tables("rc_costregion").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_costregion")
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

#Region "刷新"

    Private Sub BtnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRefresh.Click, MnuiRefresh.Click
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_costregion ORDER BY crdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_costregion") IsNot Nothing Then
                rcDataset.Tables("rc_costregion").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_costregion")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
    End Sub

#End Region

#Region "关联仓库"

    Private Sub BtnRelation_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRelation.Click, MnuiRelation.Click
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT xz,ckdm,ckmc FROM ((SELECT 1 AS xz,ckdm,ckmc FROM rc_ckxx WHERE EXISTS (SELECT 1 FROM rc_cr_ck WHERE rc_cr_ck.ckdm = rc_ckxx.ckdm AND rc_cr_ck.crdm = ?)) UNION (SELECT 0 AS xz,ckdm,ckmc FROM rc_ckxx WHERE NOT EXISTS (SELECT 1 FROM rc_cr_ck WHERE rc_cr_ck.ckdm = rc_ckxx.ckdm))) aa ORDER BY aa.ckdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@crdm", OleDbType.VarChar, 12).Value = BindingContext(rcDataView, "").Current("crdm")
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("ckxx") IsNot Nothing Then
                rcDataset.Tables("ckxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "ckxx")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Dim rcFrm As New FrmCrCk
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaStrCrdm = BindingContext(rcDataView, "").Current("crdm")
            .ShowDialog()
        End With
        Me.rcDataGridView.Refresh()
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