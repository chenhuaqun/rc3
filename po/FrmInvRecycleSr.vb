Imports System.Data.OleDb

Public Class FrmInvRecycleSr

#Region "定义变量"

    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable '我们要利用该datatable进行金额计算
    ReadOnly dtCkd As New DataTable("rc_ckdnr")
    '数据绑定
    Dim rcBmb As BindingManagerBase

#End Region


#Region "窗体初始化"

    Private Sub FrmInvRecycleSr_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '默认值
        Me.DtpBegin.Value = GetInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        Me.DtpEnd.Value = GetInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
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
        '取物料回收单输入项显示设备编码
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT paradblvalue FROM rc_para WHERE dwdm = ? AND paraid = '物料回收单输入项显示设备编码' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count > 0 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("paradblvalue").GetType.ToString <> "System.DBNull" Then
                    If rcDataset.Tables("rc_para").Rows(0).Item("paradblvalue") = 1 Then
                        '显示
                        Me.ColBrecycling.Visible = True
                        Me.ColBFadm.Visible = True
                        Me.ColFadm.Visible = True
                        Me.ColFamc.Visible = True
                    Else
                        '不显示
                        Me.ColBrecycling.Visible = False
                        Me.ColBFadm.Visible = False
                        Me.ColFadm.Visible = False
                        Me.ColFamc.Visible = False
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '数据绑定
        dtCkd.Columns.Add("buttontext", Type.GetType("System.String"))
        dtCkd.Columns.Add("cpdm", Type.GetType("System.String"))
        dtCkd.Columns.Add("oldcpdm", Type.GetType("System.String"))
        dtCkd.Columns.Add("cpmc", Type.GetType("System.String"))
        dtCkd.Columns.Add("csdm", Type.GetType("System.String"))
        dtCkd.Columns.Add("csmc", Type.GetType("System.String"))
        dtCkd.Columns.Add("brecycling", Type.GetType("System.Boolean"))
        dtCkd.Columns.Add("bfadm", Type.GetType("System.Boolean"))
        dtCkd.Columns.Add("fadm", Type.GetType("System.String"))
        dtCkd.Columns.Add("famc", Type.GetType("System.String"))
        dtCkd.Columns.Add("kuwei", Type.GetType("System.String"))
        dtCkd.Columns.Add("pihao", Type.GetType("System.String"))
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
            .Columns("buttontext").DefaultValue = "回收"
            .Columns("cpdm").DefaultValue = ""
            .Columns("oldcpdm").DefaultValue = ""
            .Columns("cpmc").DefaultValue = ""
            .Columns("csdm").DefaultValue = ""
            .Columns("csmc").DefaultValue = ""
            .Columns("brecycling").DefaultValue = False
            .Columns("bfadm").DefaultValue = False
            .Columns("fadm").DefaultValue = ""
            .Columns("famc").DefaultValue = ""
            .Columns("kuwei").DefaultValue = ""
            .Columns("pihao").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("mjsl").DefaultValue = 0.0
            .Columns("fzsl").DefaultValue = 0.0
            .Columns("dj").DefaultValue = 0.0
            .Columns("je").DefaultValue = 0.0
            .Columns("ckmemo").DefaultValue = ""
            .Columns("llsqdjh").DefaultValue = ""
            .Columns("llsqxh").DefaultValue = 0
        End With
        '绑定数据the DataGridview to the DataTable.
        rcBindingSource.DataSource = dtCkd
        Me.rcDataGridView.DataSource = rcBindingSource
        rcBmb = Me.BindingContext(rcDataset, "rc_ckdnr")
    End Sub

#End Region

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpBegin.KeyPress, DtpEnd.KeyPress, TxtCpdm.KeyPress
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
                    .ParaOleDbConn = rcOleDbConn
                    .ParaTableName = "rc_cpxx"
                    .ParaField1 = "cpdm"
                    .ParaField2 = "cpmc"
                    .ParaField3 = "dw"
                    .ParaField4 = "cpsm"
                    .ParaOrderField = "cpmc"
                    .ParaTitle = "物料"
                    .ParaOldValue = ""
                    .ParaAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtCpdm.Text = Trim(.ParaField1)
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

#Region "读取物料出库单"

    Private Sub BtnImpCkd_Click(sender As Object, e As EventArgs) Handles BtnImpCkd.Click, MnuiImpCkd.Click
        QueryCkd()
    End Sub

    Private Sub QueryCkd()
        '判断增加还是修改
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT inv_ckd.djh,inv_ckd.ckrq,inv_ckd.bdelete,inv_ckd.ckdm,inv_ckd.ckmc,inv_ckd.bmdm,inv_ckd.bmmc,inv_ckd.zydm,inv_ckd.zymc,inv_ckd.srr,inv_ckd.shr FROM inv_ckd WHERE (inv_ckd.djh = ? )"
            rcOleDbCommand.CommandText = "SELECT CASE WHEN inv_ckd.brecycle = 1 THEN '取消回收' ELSE '回收' END AS buttontext,inv_ckd.brecycle,inv_ckd.ckrq,inv_ckd.bmdm,inv_ckd.bmmc,inv_ckd.zydm,inv_ckd.zymc,inv_ckd.cpdm,inv_ckd.cpmc,inv_ckd.csdm,inv_ckd.csmc,rc_cpxx.kuwei,rc_cpxx.brecycling,rc_cpxx.bfadm,inv_ckd.fadm,inv_ckd.famc,inv_ckd.sl,inv_ckd.dw,inv_ckd.mjsl,inv_ckd.fzsl,inv_ckd.fzdw,inv_ckd.dj,inv_ckd.je,inv_ckd.ckmemo,inv_ckd.djh,inv_ckd.xh FROM inv_ckd,rc_cpxx WHERE inv_ckd.cpdm = rc_cpxx.cpdm AND rc_cpxx.brecycling = 1 AND inv_ckd.ckrq <= ? AND inv_ckd.ckrq >= ? AND inv_ckd.cpdm = ? ORDER BY inv_ckd.djh,inv_ckd.xh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@ckrq2", OleDbType.Date, 8).Value = Me.DtpEnd.Value
            rcOleDbCommand.Parameters.Add("@ckrq1", OleDbType.Date, 8).Value = Me.DtpBegin.Value
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Me.TxtCpdm.Text
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_ckdnr") IsNot Nothing Then
                rcDataset.Tables("rc_ckdnr").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_ckdnr")
            Me.rcDataGridView.ClearSelection()
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try

    End Sub


#End Region

#Region "回收"

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
                If rcDataset.Tables("rc_ckdnr").Rows(e.RowIndex).Item("brecycle") = 1 Then
                    '检查是否有后续领料如有,则不能取消
                    rcOleDbCommand.CommandText = "SELECT COALESCE(COUNT(*),0) AS gs FROM inv_ckd WHERE inv_ckd.ckrq >= ? AND inv_ckd.fadm AND inv_ckd.cpdm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = rcDataset.Tables("rc_ckdnr").Rows(e.RowIndex).Item("ckrq")
                    rcOleDbCommand.Parameters.Add("@fadm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rc_ckdnr").Rows(e.RowIndex).Item("fadm")
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Me.TxtCpdm.Text
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("ckgs") IsNot Nothing Then
                        rcDataset.Tables("ckgs").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "ckgs")
                    If rcDataset.Tables("ckgs").Rows(0).Item("gs") <= 0 Then
                        '更新回收标志
                        rcOleDbCommand.CommandText = "UPDATE inv_ckd SET brecycle = ?,recyclerq = '',recycler = '' WHERE (djh = ? AND xh = ?)"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("brecycle", OleDbType.Numeric, 1).Value = IIf(rcDataset.Tables("rc_ckdnr").Rows(e.RowIndex).Item("brecycle"), 0, 1)
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_ckdnr").Rows(e.RowIndex).Item("djh")
                        rcOleDbCommand.Parameters.Add("@xh", OleDbType.Numeric, 4).Value = rcDataset.Tables("rc_ckdnr").Rows(e.RowIndex).Item("xh")
                        intRows = rcOleDbCommand.ExecuteNonQuery()
                    Else
                        intRows = 1
                        MsgBox("不能取消回收,该设备已存在后续出库业务.", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                    End If
                Else
                    '更新回收标志
                    rcOleDbCommand.CommandText = "UPDATE inv_ckd SET brecycle = ?,recyclerq = SYSDATE,recycler = ? WHERE (djh = ? AND xh = ?)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("brecycle", OleDbType.Numeric, 1).Value = IIf(rcDataset.Tables("rc_ckdnr").Rows(e.RowIndex).Item("brecycle"), 0, 1)
                    rcOleDbCommand.Parameters.Add("recycler", OleDbType.VarChar, 30).Value = g_User_DspName
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_ckdnr").Rows(e.RowIndex).Item("djh")
                    rcOleDbCommand.Parameters.Add("@xh", OleDbType.Numeric, 4).Value = rcDataset.Tables("rc_ckdnr").Rows(e.RowIndex).Item("xh")
                    intRows = rcOleDbCommand.ExecuteNonQuery()
                End If
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
                MsgBox("注意:更新记录行数有" & intRows.ToString & "行，请检查原因。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            End If
            QueryCkd()
        End If
    End Sub

#End Region

#Region "退出表单事件"

    Private Sub MnuiExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiExit.Click
        Me.Close()
    End Sub

#End Region

End Class