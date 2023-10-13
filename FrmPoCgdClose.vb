Imports System.Data.OleDb

Public Class FrmPoCgdClose
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '数据更新传递
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable
    ReadOnly dtCgjhlb As New DataTable("cgjhlb")

    Private Sub FrmPoCgdClose_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '设置DataGridView
        Me.rcDataGridView.AutoGenerateColumns = False
        Me.rcDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("Colrksl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("Colrksl").DefaultCellStyle.Format = g_FormatSl
        '数据绑定
        dtCgjhlb.Columns.Add("buttontext", Type.GetType("System.String"))
        dtCgjhlb.Columns.Add("bclosed", Type.GetType("System.Boolean"))
        dtCgjhlb.Columns.Add("djh", Type.GetType("System.String"))
        dtCgjhlb.Columns.Add("xh", Type.GetType("System.Double"))
        dtCgjhlb.Columns.Add("cpdm", Type.GetType("System.String"))
        dtCgjhlb.Columns.Add("cpmc", Type.GetType("System.String"))
        dtCgjhlb.Columns.Add("dw", Type.GetType("System.String"))
        dtCgjhlb.Columns.Add("sl", Type.GetType("System.Double"))
        dtCgjhlb.Columns.Add("rksl", Type.GetType("System.Double"))
        dtCgjhlb.Columns.Add("cgmemo", Type.GetType("System.String"))
        rcDataset.Tables.Add(dtCgjhlb)
        With dtCgjhlb
            .Columns("buttontext").DefaultValue = ""
            .Columns("bclosed").DefaultValue = False
            .Columns("djh").DefaultValue = ""
            .Columns("xh").DefaultValue = 0.0
            .Columns("cpdm").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("rksl").DefaultValue = 0.0
            .Columns("cgmemo").DefaultValue = ""
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
                rcOleDbCommand.CommandText = "SELECT CASE WHEN bclosed = 1 THEN '取消关闭' ELSE '关闭' END AS buttontext,bclosed,djh,xh,csdm,csmc,cpdm,cpmc,dw,sl,rksl,cgmemo FROM po_cgd WHERE (cpdm = ? AND sl <> rksl)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtCpdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("cgjhlb") IsNot Nothing Then
                    Me.rcDataset.Tables("cgjhlb").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "cgjhlb")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            Me.rcDataGridView.DataSource = rcDataset.Tables("cgjhlb")
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
                rcOleDbCommand.CommandText = "UPDATE po_cgd SET bclosed = ? WHERE (djh = ? AND xh = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("bclosed", OleDbType.Numeric, 1).Value = IIf(rcDataset.Tables("cgjhlb").Rows(e.RowIndex).Item("bclosed"), 0, 1)
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("cgjhlb").Rows(e.RowIndex).Item("djh")
                rcOleDbCommand.Parameters.Add("@xh", OleDbType.Numeric, 4).Value = rcDataset.Tables("cgjhlb").Rows(e.RowIndex).Item("xh")
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