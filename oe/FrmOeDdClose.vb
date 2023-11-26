Imports System.Data.OleDb

Public Class FrmOeDdClose
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '数据更新传递
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable
    ReadOnly dtDdlb As New DataTable("ddlb")

    Private Sub FrmOeDdClose_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '设置DataGridView
        Me.rcDataGridView.AutoGenerateColumns = False
        Me.rcDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColHxsl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColHxsl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColRksl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColRksl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColXssl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColXssl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColFpsl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColFpsl").DefaultCellStyle.Format = g_FormatSl
        '数据绑定
        dtDdlb.Columns.Add("buttontext", Type.GetType("System.String"))
        dtDdlb.Columns.Add("bclosed", Type.GetType("System.Boolean"))
        dtDdlb.Columns.Add("djh", Type.GetType("System.String"))
        dtDdlb.Columns.Add("xh", Type.GetType("System.Double"))
        dtDdlb.Columns.Add("cpdm", Type.GetType("System.String"))
        dtDdlb.Columns.Add("cpmc", Type.GetType("System.String"))
        dtDdlb.Columns.Add("dw", Type.GetType("System.String"))
        dtDdlb.Columns.Add("sl", Type.GetType("System.Double"))
        dtDdlb.Columns.Add("hxsl", Type.GetType("System.Double"))
        dtDdlb.Columns.Add("rksl", Type.GetType("System.Double"))
        dtDdlb.Columns.Add("xssl", Type.GetType("System.Double"))
        dtDdlb.Columns.Add("fpsl", Type.GetType("System.Double"))
        dtDdlb.Columns.Add("ddmemo", Type.GetType("System.String"))
        rcDataset.Tables.Add(dtDdlb)
        With dtDdlb
            .Columns("buttontext").DefaultValue = ""
            .Columns("bclosed").DefaultValue = False
            .Columns("djh").DefaultValue = ""
            .Columns("xh").DefaultValue = 0.0
            .Columns("cpdm").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("rksl").DefaultValue = 0.0
            .Columns("ddmemo").DefaultValue = ""
        End With

    End Sub

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCpdm.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "物料编码事件"

    Private Sub TxtCpdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCpdm.KeyDown
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
                        Me.TxtCpdm.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtCpdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCpdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtCpdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT cpdm,cpmc,dw,kuwei FROM rc_cpxx WHERE (cpdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_cpxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_cpxx").Rows.Count = 0 Then
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

    Private Sub BtnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQuery.Click
        QueryCgjh()
    End Sub

    Private Sub QueryCgjh()
        If Not String.IsNullOrEmpty(Me.TxtCpdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT CASE WHEN bclosed = 1 THEN '取消关闭' ELSE '关闭' END AS buttontext,bclosed,djh,xh,khdm,khmc,cpdm,cpmc,dw,sl,hxsl,rksl,cksl AS xssl,fpsl,ddmemo FROM oe_dd WHERE oe_dd.cpdm = ? AND (oe_dd.sl - oe_dd.hxsl <> oe_dd.rksl OR oe_dd.sl - oe_dd.hxsl <> oe_dd.cksl OR oe_dd.sl - oe_dd.hxsl <> fpsl)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtCpdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("ddlb") IsNot Nothing Then
                    Me.rcDataset.Tables("ddlb").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "ddlb")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            Me.rcDataGridView.DataSource = rcDataset.Tables("ddlb")
            Me.rcDataGridView.ClearSelection()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles rcDataGridView.CellContentClick
        Dim intRows As Integer = 0
        If rcDataGridView.Columns(e.ColumnIndex).Name = "ColButtonText" And e.RowIndex > -1 Then
            'MessageBox.Show("行: " + e.RowIndex.ToString() + ", 列: " + e.ColumnIndex.ToString() + "; 被点击了")
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "UPDATE oe_dd SET bclosed = ? WHERE (djh = ? AND xh = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("bclosed", OleDbType.Numeric, 1).Value = IIf(rcDataset.Tables("ddlb").Rows(e.RowIndex).Item("bclosed"), 0, 1)
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("ddlb").Rows(e.RowIndex).Item("djh")
                rcOleDbCommand.Parameters.Add("@xh", OleDbType.Numeric, 4).Value = rcDataset.Tables("ddlb").Rows(e.RowIndex).Item("xh")
                intRows = rcOleDbCommand.ExecuteNonQuery()
                If intRows <> 1 Then
                    Try
                        rcOleDbTrans.Rollback()
                    Catch ey As OleDbException
                        MsgBox("程序错误1。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                    End Try
                Else
                    rcOleDbTrans.Commit()
                End If
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If intRows <> 1 Then
                MsgBox("该条形码更新记录行数有" & intRows.ToString & "行，请检查原因。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            End If
            QueryCgjh()
        End If
    End Sub
End Class