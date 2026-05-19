Imports System.Data.OleDb

Public Class FrmRoles

#Region "定义变量"

    '建立OLEDB数据适配器对象
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDb传递对象
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDb命令
    ReadOnly rcOleDbCommand As OleDbCommand = sysOleDbConn.CreateCommand()
    '建立DataView数据视图
    Dim rcDataView As DataView
    '建立DataTable数据表
    ReadOnly dtRoles As New DataTable("rc_roles")

#End Region

#Region "窗体初始化"

    Private Sub FrmRoles_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '创建列
        dtRoles.Columns.Add("roleid", Type.GetType("System.String"))
        dtRoles.Columns.Add("rolename", Type.GetType("System.String"))
        dtRoles.Columns.Add("rolesm", Type.GetType("System.String"))
        rcDataSet.Tables.Add(dtRoles)
        With dtRoles
            .Columns("roleid").DefaultValue = ""
            .Columns("rolename").DefaultValue = ""
            .Columns("rolesm").DefaultValue = ""
        End With
        sysOleDbConn.Open()
        rcOleDbCommand.Connection = sysOleDbConn
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT * FROM rc_roles ORDER BY roleid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_roles") IsNot Nothing Then
                rcDataSet.Tables("rc_roles").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_roles")
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
        Finally
            sysOleDbConn.Close()
        End Try
        rcDataView = New DataView(rcDataSet.Tables("rc_roles"))
        Me.rcDataGridView.DataSource = rcDataView
    End Sub

#End Region

#Region "新增"

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        '新增
        Dim rcFrm As New FrmRoleEdit
        With rcFrm
            .ParaAdding = True
            .ParaDataView = rcDataView
            .ParaDataSet = rcDataset
            .PcurrentPos = BindingContext(rcDataView, "").Position
            .ShowDialog()
        End With
        Me.rcDataGridView.Refresh()
    End Sub

#End Region

#Region "修改"

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        '修改
        Dim rcFrm As New FrmRoleEdit
        With rcFrm
            .ParaAdding = False
            .ParaDataView = rcDataView
            .ParaDataSet = rcDataset
            .PcurrentPos = BindingContext(rcDataView, "").Position
            .ShowDialog()
        End With
        Me.rcDataGridView.Refresh()
    End Sub

#End Region

#Region "删除"

    Private Sub BtnDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        Dim currentPos As Integer
        '删除数据
        If MessageBox.Show("您真地要删除吗？" & BindingContext(rcDataView, "").Current("roleid"), "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then
            currentPos = BindingContext(rcDataView, "").Position
            If Trim(BindingContext(rcDataView, "").Current("roleid")) = "" Then
                MessageBox.Show("编码不能为空。")
                Return
            End If
            '检查数据是否存在？
            'rc_roleqx
            sysOleDbConn.Open()
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "SELECT * FROM rc_roleqx WHERE roleid = ? "
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@roleid", OleDbType.VarChar, 12).Value = BindingContext(rcDataView, "").Current("roleid")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_roleqx") IsNot Nothing Then
                    rcDataSet.Tables("rc_roleqx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_roleqx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                sysOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_roleqx").Rows.Count > 0 Then
                MsgBox("该角色正被使用，不能删除，请先取消该角色的授权。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            'rc_userinrole
            sysOleDbConn.Open()
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "SELECT * FROM rc_userinrole WHERE roleid = ? "
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@roleid", OleDbType.VarChar, 12).Value = BindingContext(rcDataView, "").Current("roleid")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_userinrole") IsNot Nothing Then
                    rcDataSet.Tables("rc_userinrole").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_userinrole")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                sysOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_userinrole").Rows.Count > 0 Then
                MsgBox("有用户正在使用该角色，不能删除，请先取消对该角色的授权。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            sysOleDbConn.Open()
            rcOleDbTrans = sysOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "DELETE FROM rc_roles WHERE roleid = ? "
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@roleid", OleDbType.VarChar, 12).Value = BindingContext(rcDataView, "").Current("roleid")
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "SELECT * FROM rc_roles ORDER BY roleid"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_roles") IsNot Nothing Then
                    rcDataSet.Tables("rc_roles").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_roles")
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
                sysOleDbConn.Close()
            End Try
            BindingContext(rcDataView, "").Position = currentPos
        End If
    End Sub

#End Region

#Region "权限"

    Private Sub BtnQx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQx.Click
        '修改
        Dim rcFrm As New FrmRoleQx
        With rcFrm
            .paraStrAccount = BindingContext(rcDataView, "").Current("roleid")
            .Label1.Text = "角色：(" & BindingContext(rcDataView, "").Current("roleid") & ")" & BindingContext(rcDataView, "").Current("rolename")
            .ShowDialog()
        End With
        Me.rcDataGridView.Refresh()
    End Sub

#End Region

#Region "退出"

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

#End Region

#Region "输出到excel"

    Private Sub MnuiExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExport.Click
        '导出数据
        Exports2Excel(rcDataSet.Tables("rc_roles").DefaultView)
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