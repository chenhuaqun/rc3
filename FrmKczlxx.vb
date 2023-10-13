Imports System.Data.OleDb

Public Class FrmKcZlxx
    '建立OLEDB数据适配器对象
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDb传递对象
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDb命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '数据视图
    Dim rcDataView As DataView

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub FrmKczlxx_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT fadm,famc,fasm FROM rc_kczlfa ORDER BY fadm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_kczlfa") IsNot Nothing Then
                rcDataSet.Tables("rc_kczlfa").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_kczlfa")
        Catch ex As Exception
            Try
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
        Finally
            rcOleDbConn.Close()
        End Try
        rcDataView = New DataView(rcDataSet.Tables("rc_kczlfa"))
        rcDataGrid.DataSource = rcDataView
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Dim rcFrm As New FrmKczlFaAdd
        With rcFrm
            '.MdiParent = Me.MdiParent
            If .ShowDialog = DialogResult.OK Then
                If rcDataSet.Tables("rc_kczlfa") IsNot Nothing Then
                    rcDataSet.Tables("rc_kczlfa").Clear()
                End If
                rcOleDbCommand.CommandText = "SELECT fadm,famc,fasm FROM rc_kczlfa ORDER BY fadm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_kczlfa")
            End If
        End With
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        Dim rcFrm As New FrmKczlFaEdit
        With rcFrm
            .TxtFadm.Text = rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("fadm")
            .TxtFamc.Text = rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("famc")
            If rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("fasm").GetType.ToString <> "System.DBNull" Then
                .TxtFasm.Text = rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("fasm")
            End If
            If .ShowDialog = DialogResult.OK Then
                If rcDataSet.Tables("rc_kczlfa") IsNot Nothing Then
                    rcDataSet.Tables("rc_kczlfa").Clear()
                End If
                rcOleDbCommand.CommandText = "SELECT fadm,famc,fasm FROM rc_kczlfa ORDER BY fadm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_kczlfa")
            End If
        End With
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        If MsgBox("您是否要删除库存账龄方案编码：" & rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("fadm") & "方案名称：" & rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("famc"), MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, "提示信息") = MsgBoxResult.Yes Then
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandText = "DELETE FROM rc_kczlfa WHERE fadm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@fadm", OleDbType.VarChar, 12).Value = rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("fadm")
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "DELETE FROM rc_userqx WHERE fadm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@fadm", OleDbType.VarChar, 12).Value = rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("fadm")
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "SELECT fadm,famc,fasm FROM rc_kczlfa ORDER BY fadm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_kczlfa") IsNot Nothing Then
                    rcDataSet.Tables("rc_kczlfa").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_kczlfa")
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
        End If
    End Sub

    Private Sub BtnQx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQx.Click
        Dim rcFrm As New FrmKczlFd
        With rcFrm
            .ParaStrFadm = rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("fadm")
            '.paraStrOeRight = rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("OeRight")
            If .ShowDialog = DialogResult.OK Then
                If rcDataSet.Tables("rc_kczlfa") IsNot Nothing Then
                    rcDataSet.Tables("rc_kczlfa").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_kczlfa")
            End If
        End With
    End Sub

#Region "输出到excel"

    Private Sub MnuiExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExport.Click
        '导出数据
        Exports2Excel(rcDataSet.Tables("rc_kczlfa").DefaultView)
    End Sub

    Public Sub Exports2Excel(ByVal ParaDataView As DataView)
        If ParaDataView.Count > 0 Then
            Try
                Dim rcExcelApp As New Microsoft.Office.Interop.Excel.Application
                Dim rcExcelWorkbook As Microsoft.Office.Interop.Excel.Workbook
                Dim rcExcelWorksheet As Microsoft.Office.Interop.Excel.Worksheet
                Dim rowIndex, colIndex As Integer
                rowIndex = 1
                colIndex = 0
                rcExcelWorkbook = rcExcelApp.Workbooks().Add
                rcExcelWorksheet = rcExcelWorkbook.Worksheets("sheet1")

                '将所得到的表的列名,赋值给单元格
                Dim i As Integer
                Dim rcDataColumn As DataColumn
                Dim rcDataRowView As DataRowView

                rcExcelApp.Visible = True

                For Each rcDataColumn In ParaDataView.Table.Columns
                    colIndex += 1
                    rcExcelApp.Cells(1, colIndex) = rcDataColumn.ColumnName
                Next
                '得到的表所有行,赋值给单元格
                For i = 0 To ParaDataView.Count - 1
                    rcDataRowView = ParaDataView.Item(i)
                    If rcDataRowView.Row.RowState <> DataRowState.Deleted Then
                        rowIndex += 1
                        colIndex = 0
                        For Each rcDataColumn In ParaDataView.Table.Columns
                            colIndex += 1
                            If ParaDataView.Item(i).Row.Item(rcDataColumn.ColumnName).GetType.ToString = "System.String" Then
                                rcExcelApp.Cells(rowIndex, colIndex) = "'" & Trim(ParaDataView.Item(i).Row.Item(rcDataColumn.ColumnName))
                            Else
                                rcExcelApp.Cells(rowIndex, colIndex) = ParaDataView.Item(i).Row.Item(rcDataColumn.ColumnName)
                            End If
                        Next
                    End If
                Next
            Catch ex As Exception
                MessageBox.Show("数据导出失败！请查看是否已经安装了Excel2003以上的版本。", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            Finally
                Me.Cursor = Cursors.Default
            End Try
        Else
            MessageBox.Show("没有数据！", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

#End Region
End Class