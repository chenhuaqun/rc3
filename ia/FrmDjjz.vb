Imports System.Data.OleDb

Public Class FrmDjjz
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '启用会计期间
    Dim strDwKjqj As String = ""
    '建立Datatable '我们要利用该datatable进行金额计算
    ReadOnly dtDjjz As New DataTable("djjz")
    '会计期起始日期
    Dim dateKsrq As Date = Now().Date
    '会计期终止日期
    Dim dateZzrq As Date = Now().Date

#Region "初始化"

    Private Sub FrmDjjz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        strDwKjqj = getInvKjqj(g_Dwrq)
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT ny,jzbz,invbegin,invend FROM rc_yj WHERE jzbz = 0 AND ny >= ? ORDER BY ny"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = strDwKjqj
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_yj") IsNot Nothing Then
                rcDataSet.Tables("rc_yj").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_yj")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("rc_yj").Rows.Count = 0 Then
            MsgBox("会计期间设置有错误，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        '默认值
        NudYear.Value = Mid(rcDataSet.Tables("rc_yj").Rows(0).Item("ny"), 1, 4)
        NudMonth.Value = Mid(rcDataSet.Tables("rc_yj").Rows(0).Item("ny"), 5, 2)
        dateKsrq = rcDataSet.Tables("rc_yj").Rows(0).Item("invbegin")
        dateZzrq = rcDataSet.Tables("rc_yj").Rows(0).Item("invend")
        '数据绑定
        dtDjjz.Columns.Add("xm", Type.GetType("System.String"))
        dtDjjz.Columns.Add("bqzs", Type.GetType("System.Double"))
        dtDjjz.Columns.Add("wjzzs", Type.GetType("System.Double"))
        dtDjjz.Columns.Add("yjzzs", Type.GetType("System.Double"))
        dtDjjz.Columns.Add("bcjzzs", Type.GetType("System.Double"))
        rcDataSet.Tables.Add(dtDjjz)
        With dtDjjz
            .Columns("xm").DefaultValue = ""
            .Columns("bqzs").DefaultValue = 0.0
            .Columns("wjzzs").DefaultValue = 0.0
            .Columns("yjzzs").DefaultValue = 0.0
            .Columns("bcjzzs").DefaultValue = 0.0
        End With
        rcBindingSource.DataSource = dtDjjz
        Me.rcDataGridView.DataSource = rcBindingSource
        '物料采购订单
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '取入库单本期张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As bqzs FROM po_cgd WHERE TRUNC(cgrq,'dd')>= ? AND TRUNC(cgrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cgrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@cgrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("bqzs") IsNot Nothing Then
                rcDataSet.Tables("bqzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "bqzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As wjzzs FROM po_cgd WHERE TRUNC(cgrq,'dd')>= ? AND TRUNC(cgrq,'dd') <= ? And jzr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cgrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@cgrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("wjzzs") IsNot Nothing Then
                rcDataSet.Tables("wjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "wjzzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As yjzzs FROM po_cgd WHERE TRUNC(cgrq,'dd')>= ? AND TRUNC(cgrq,'dd') <= ? And Not jzr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cgrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@cgrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("yjzzs") IsNot Nothing Then
                rcDataSet.Tables("yjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "yjzzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As bcjzzs FROM po_cgd WHERE TRUNC(cgrq,'dd')>= ? AND TRUNC(cgrq,'dd') <= ? And jzr Is Null And Not shr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cgrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@cgrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("bcjzzs") IsNot Nothing Then
                rcDataSet.Tables("bcjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "bcjzzs")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("bqzs").Rows.Count > 0 And rcDataSet.Tables("wjzzs").Rows.Count > 0 And rcDataSet.Tables("yjzzs").Rows.Count > 0 And rcDataSet.Tables("bcjzzs").Rows.Count > 0 Then
            '添加数据
            Dim rcDataRow As DataRow
            rcDataRow = rcDataSet.Tables("djjz").NewRow
            rcDataRow.Item("xm") = "物料采购订单"
            rcDataRow.Item("bqzs") = rcDataSet.Tables("bqzs").Rows(0).Item("bqzs")
            rcDataRow.Item("wjzzs") = rcDataSet.Tables("wjzzs").Rows(0).Item("wjzzs")
            rcDataRow.Item("yjzzs") = rcDataSet.Tables("yjzzs").Rows(0).Item("yjzzs")
            rcDataRow.Item("bcjzzs") = rcDataSet.Tables("bcjzzs").Rows(0).Item("bcjzzs")
            rcDataSet.Tables("djjz").Rows.Add(rcDataRow)
        End If
        '物料收货单
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '取入库单本期张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As bqzs FROM po_rkd WHERE TRUNC(rkrq,'dd')>= ? AND TRUNC(rkrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("bqzs") IsNot Nothing Then
                rcDataSet.Tables("bqzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "bqzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As wjzzs FROM po_rkd WHERE TRUNC(rkrq,'dd')>= ? AND TRUNC(rkrq,'dd') <= ? And jzr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("wjzzs") IsNot Nothing Then
                rcDataSet.Tables("wjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "wjzzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As yjzzs FROM po_rkd WHERE TRUNC(rkrq,'dd')>= ? AND TRUNC(rkrq,'dd') <= ? And Not jzr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("yjzzs") IsNot Nothing Then
                rcDataSet.Tables("yjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "yjzzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As bcjzzs FROM po_rkd WHERE TRUNC(rkrq,'dd')>= ? AND TRUNC(rkrq,'dd') <= ? And jzr Is Null And Not shr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("bcjzzs") IsNot Nothing Then
                rcDataSet.Tables("bcjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "bcjzzs")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("bqzs").Rows.Count > 0 And rcDataSet.Tables("wjzzs").Rows.Count > 0 And rcDataSet.Tables("yjzzs").Rows.Count > 0 And rcDataSet.Tables("bcjzzs").Rows.Count > 0 Then
            '添加数据
            Dim rcDataRow As DataRow
            rcDataRow = rcDataSet.Tables("djjz").NewRow
            rcDataRow.Item("xm") = "物料收货单"
            rcDataRow.Item("bqzs") = rcDataSet.Tables("bqzs").Rows(0).Item("bqzs")
            rcDataRow.Item("wjzzs") = rcDataSet.Tables("wjzzs").Rows(0).Item("wjzzs")
            rcDataRow.Item("yjzzs") = rcDataSet.Tables("yjzzs").Rows(0).Item("yjzzs")
            rcDataRow.Item("bcjzzs") = rcDataSet.Tables("bcjzzs").Rows(0).Item("bcjzzs")
            rcDataSet.Tables("djjz").Rows.Add(rcDataRow)
        End If
        '物料入库单(采购发票)
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '取入库单本期张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As bqzs FROM po_fp WHERE TRUNC(fprq,'dd')>= ? AND TRUNC(fprq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("bqzs") IsNot Nothing Then
                rcDataSet.Tables("bqzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "bqzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As wjzzs FROM po_fp WHERE TRUNC(fprq,'dd')>= ? AND TRUNC(fprq,'dd') <= ? And jzr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("wjzzs") IsNot Nothing Then
                rcDataSet.Tables("wjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "wjzzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As yjzzs FROM po_fp WHERE TRUNC(fprq,'dd')>= ? AND TRUNC(fprq,'dd') <= ? And Not jzr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("yjzzs") IsNot Nothing Then
                rcDataSet.Tables("yjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "yjzzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As bcjzzs FROM po_fp WHERE TRUNC(fprq,'dd')>= ? AND TRUNC(fprq,'dd') <= ? And jzr Is Null And Not shr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("bcjzzs") IsNot Nothing Then
                rcDataSet.Tables("bcjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "bcjzzs")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("bqzs").Rows.Count > 0 And rcDataSet.Tables("wjzzs").Rows.Count > 0 And rcDataSet.Tables("yjzzs").Rows.Count > 0 And rcDataSet.Tables("bcjzzs").Rows.Count > 0 Then
            '添加数据
            Dim rcDataRow As DataRow
            rcDataRow = rcDataSet.Tables("djjz").NewRow
            rcDataRow.Item("xm") = "物料入库单(采购发票)(含其他应付单)"
            rcDataRow.Item("bqzs") = rcDataSet.Tables("bqzs").Rows(0).Item("bqzs")
            rcDataRow.Item("wjzzs") = rcDataSet.Tables("wjzzs").Rows(0).Item("wjzzs")
            rcDataRow.Item("yjzzs") = rcDataSet.Tables("yjzzs").Rows(0).Item("yjzzs")
            rcDataRow.Item("bcjzzs") = rcDataSet.Tables("bcjzzs").Rows(0).Item("bcjzzs")
            rcDataSet.Tables("djjz").Rows.Add(rcDataRow)
        End If
        '付款单
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '取入库单本期张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As bqzs FROM ap_fkd WHERE TRUNC(fkrq,'dd')>= ? AND TRUNC(fkrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("bqzs") IsNot Nothing Then
                rcDataSet.Tables("bqzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "bqzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As wjzzs FROM ap_fkd WHERE TRUNC(fkrq,'dd')>= ? AND TRUNC(fkrq,'dd') <= ? And jzr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("wjzzs") IsNot Nothing Then
                rcDataSet.Tables("wjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "wjzzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As yjzzs FROM ap_fkd WHERE TRUNC(fkrq,'dd')>= ? AND TRUNC(fkrq,'dd') <= ? And Not jzr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("yjzzs") IsNot Nothing Then
                rcDataSet.Tables("yjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "yjzzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As bcjzzs FROM ap_fkd WHERE TRUNC(fkrq,'dd')>= ? AND TRUNC(fkrq,'dd') <= ? And jzr Is Null And Not shr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("bcjzzs") IsNot Nothing Then
                rcDataSet.Tables("bcjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "bcjzzs")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("bqzs").Rows.Count > 0 And rcDataSet.Tables("wjzzs").Rows.Count > 0 And rcDataSet.Tables("yjzzs").Rows.Count > 0 And rcDataSet.Tables("bcjzzs").Rows.Count > 0 Then
            '添加数据
            Dim rcDataRow As DataRow
            rcDataRow = rcDataSet.Tables("djjz").NewRow
            rcDataRow.Item("xm") = "付款单"
            rcDataRow.Item("bqzs") = rcDataSet.Tables("bqzs").Rows(0).Item("bqzs")
            rcDataRow.Item("wjzzs") = rcDataSet.Tables("wjzzs").Rows(0).Item("wjzzs")
            rcDataRow.Item("yjzzs") = rcDataSet.Tables("yjzzs").Rows(0).Item("yjzzs")
            rcDataRow.Item("bcjzzs") = rcDataSet.Tables("bcjzzs").Rows(0).Item("bcjzzs")
            rcDataSet.Tables("djjz").Rows.Add(rcDataRow)
        End If
        '物料出库单
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '取入库单本期张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As bqzs FROM inv_ckd WHERE TRUNC(ckrq,'dd')>= ? AND TRUNC(ckrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("bqzs") IsNot Nothing Then
                rcDataSet.Tables("bqzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "bqzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As wjzzs FROM inv_ckd WHERE TRUNC(ckrq,'dd')>= ? AND TRUNC(ckrq,'dd') <= ? And jzr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("wjzzs") IsNot Nothing Then
                rcDataSet.Tables("wjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "wjzzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As yjzzs FROM inv_ckd WHERE TRUNC(ckrq,'dd')>= ? AND TRUNC(ckrq,'dd') <= ? And Not jzr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("yjzzs") IsNot Nothing Then
                rcDataSet.Tables("yjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "yjzzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As bcjzzs FROM inv_ckd WHERE TRUNC(ckrq,'dd')>= ? AND TRUNC(ckrq,'dd') <= ? And jzr Is Null And Not shr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("bcjzzs") IsNot Nothing Then
                rcDataSet.Tables("bcjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "bcjzzs")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("bqzs").Rows.Count > 0 And rcDataSet.Tables("wjzzs").Rows.Count > 0 And rcDataSet.Tables("yjzzs").Rows.Count > 0 And rcDataSet.Tables("bcjzzs").Rows.Count > 0 Then
            '添加数据
            Dim rcDataRow As DataRow
            rcDataRow = rcDataSet.Tables("djjz").NewRow
            rcDataRow.Item("xm") = "物料出库单"
            rcDataRow.Item("bqzs") = rcDataSet.Tables("bqzs").Rows(0).Item("bqzs")
            rcDataRow.Item("wjzzs") = rcDataSet.Tables("wjzzs").Rows(0).Item("wjzzs")
            rcDataRow.Item("yjzzs") = rcDataSet.Tables("yjzzs").Rows(0).Item("yjzzs")
            rcDataRow.Item("bcjzzs") = rcDataSet.Tables("bcjzzs").Rows(0).Item("bcjzzs")
            rcDataSet.Tables("djjz").Rows.Add(rcDataRow)
        End If
        '物料调拨单
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '取入库单本期张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As bqzs FROM inv_dbd WHERE TRUNC(dbrq,'dd')>= ? AND TRUNC(dbrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("bqzs") IsNot Nothing Then
                rcDataSet.Tables("bqzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "bqzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As wjzzs FROM inv_dbd WHERE TRUNC(dbrq,'dd')>= ? AND TRUNC(dbrq,'dd') <= ? And jzr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("wjzzs") IsNot Nothing Then
                rcDataSet.Tables("wjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "wjzzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As yjzzs FROM inv_dbd WHERE TRUNC(dbrq,'dd')>= ? AND TRUNC(dbrq,'dd') <= ? And Not jzr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("yjzzs") IsNot Nothing Then
                rcDataSet.Tables("yjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "yjzzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As bcjzzs FROM inv_dbd WHERE TRUNC(dbrq,'dd')>= ? AND TRUNC(dbrq,'dd') <= ? And jzr Is Null And Not shr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("bcjzzs") IsNot Nothing Then
                rcDataSet.Tables("bcjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "bcjzzs")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("bqzs").Rows.Count > 0 And rcDataSet.Tables("wjzzs").Rows.Count > 0 And rcDataSet.Tables("yjzzs").Rows.Count > 0 And rcDataSet.Tables("bcjzzs").Rows.Count > 0 Then
            '添加数据
            Dim rcDataRow As DataRow
            rcDataRow = rcDataSet.Tables("djjz").NewRow
            rcDataRow.Item("xm") = "物料调拨单"
            rcDataRow.Item("bqzs") = rcDataSet.Tables("bqzs").Rows(0).Item("bqzs")
            rcDataRow.Item("wjzzs") = rcDataSet.Tables("wjzzs").Rows(0).Item("wjzzs")
            rcDataRow.Item("yjzzs") = rcDataSet.Tables("yjzzs").Rows(0).Item("yjzzs")
            rcDataRow.Item("bcjzzs") = rcDataSet.Tables("bcjzzs").Rows(0).Item("bcjzzs")
            rcDataSet.Tables("djjz").Rows.Add(rcDataRow)
        End If
        '产品销售订单
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '取入库单本期张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As bqzs FROM oe_dd WHERE TRUNC(qdrq,'dd')>= ? AND TRUNC(qdrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@qdrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@qdrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("bqzs") IsNot Nothing Then
                rcDataSet.Tables("bqzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "bqzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As wjzzs FROM oe_dd WHERE TRUNC(qdrq,'dd')>= ? AND TRUNC(qdrq,'dd') <= ? And jzr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@qdrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@qdrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("wjzzs") IsNot Nothing Then
                rcDataSet.Tables("wjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "wjzzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As yjzzs FROM oe_dd WHERE TRUNC(qdrq,'dd')>= ? AND TRUNC(qdrq,'dd') <= ? And Not jzr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@qdrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@qdrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("yjzzs") IsNot Nothing Then
                rcDataSet.Tables("yjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "yjzzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As bcjzzs FROM oe_dd WHERE TRUNC(qdrq,'dd')>= ? AND TRUNC(qdrq,'dd') <= ? And jzr Is Null And Not shr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@qdrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@qdrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("bcjzzs") IsNot Nothing Then
                rcDataSet.Tables("bcjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "bcjzzs")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("bqzs").Rows.Count > 0 And rcDataSet.Tables("wjzzs").Rows.Count > 0 And rcDataSet.Tables("yjzzs").Rows.Count > 0 And rcDataSet.Tables("bcjzzs").Rows.Count > 0 Then
            '添加数据
            Dim rcDataRow As DataRow
            rcDataRow = rcDataSet.Tables("djjz").NewRow
            rcDataRow.Item("xm") = "产品销售订单"
            rcDataRow.Item("bqzs") = rcDataSet.Tables("bqzs").Rows(0).Item("bqzs")
            rcDataRow.Item("wjzzs") = rcDataSet.Tables("wjzzs").Rows(0).Item("wjzzs")
            rcDataRow.Item("yjzzs") = rcDataSet.Tables("yjzzs").Rows(0).Item("yjzzs")
            rcDataRow.Item("bcjzzs") = rcDataSet.Tables("bcjzzs").Rows(0).Item("bcjzzs")
            rcDataSet.Tables("djjz").Rows.Add(rcDataRow)
        End If
        '产品入库单
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '取入库单本期张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As bqzs FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND TRUNC(rkrq,'dd')>= ? AND TRUNC(rkrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("bqzs") IsNot Nothing Then
                rcDataSet.Tables("bqzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "bqzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As wjzzs FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND TRUNC(rkrq,'dd')>= ? AND TRUNC(rkrq,'dd') <= ? And jzr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("wjzzs") IsNot Nothing Then
                rcDataSet.Tables("wjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "wjzzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As yjzzs FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND TRUNC(rkrq,'dd')>= ? AND TRUNC(rkrq,'dd') <= ? And Not jzr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("yjzzs") IsNot Nothing Then
                rcDataSet.Tables("yjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "yjzzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As bcjzzs FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND TRUNC(rkrq,'dd')>= ? AND TRUNC(rkrq,'dd') <= ? And jzr Is Null And Not shr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("bcjzzs") IsNot Nothing Then
                rcDataSet.Tables("bcjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "bcjzzs")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("bqzs").Rows.Count > 0 And rcDataSet.Tables("wjzzs").Rows.Count > 0 And rcDataSet.Tables("yjzzs").Rows.Count > 0 And rcDataSet.Tables("bcjzzs").Rows.Count > 0 Then
            '添加数据
            Dim rcDataRow As DataRow
            rcDataRow = rcDataSet.Tables("djjz").NewRow
            rcDataRow.Item("xm") = "产品入库单"
            rcDataRow.Item("bqzs") = rcDataSet.Tables("bqzs").Rows(0).Item("bqzs")
            rcDataRow.Item("wjzzs") = rcDataSet.Tables("wjzzs").Rows(0).Item("wjzzs")
            rcDataRow.Item("yjzzs") = rcDataSet.Tables("yjzzs").Rows(0).Item("yjzzs")
            rcDataRow.Item("bcjzzs") = rcDataSet.Tables("bcjzzs").Rows(0).Item("bcjzzs")
            rcDataSet.Tables("djjz").Rows.Add(rcDataRow)
        End If
        '产品送货单
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '取入库单本期张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As bqzs FROM oe_xsd WHERE TRUNC(xsrq,'dd')>= ? AND TRUNC(xsrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("bqzs") IsNot Nothing Then
                rcDataSet.Tables("bqzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "bqzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As wjzzs FROM oe_xsd WHERE TRUNC(xsrq,'dd')>= ? AND TRUNC(xsrq,'dd') <= ? And jzr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("wjzzs") IsNot Nothing Then
                rcDataSet.Tables("wjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "wjzzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As yjzzs FROM oe_xsd WHERE TRUNC(xsrq,'dd')>= ? AND TRUNC(xsrq,'dd') <= ? And Not jzr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("yjzzs") IsNot Nothing Then
                rcDataSet.Tables("yjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "yjzzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As bcjzzs FROM oe_xsd WHERE TRUNC(xsrq,'dd')>= ? AND TRUNC(xsrq,'dd') <= ? And jzr Is Null And Not shr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("bcjzzs") IsNot Nothing Then
                rcDataSet.Tables("bcjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "bcjzzs")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("bqzs").Rows.Count > 0 And rcDataSet.Tables("wjzzs").Rows.Count > 0 And rcDataSet.Tables("yjzzs").Rows.Count > 0 And rcDataSet.Tables("bcjzzs").Rows.Count > 0 Then
            '添加数据
            Dim rcDataRow As DataRow
            rcDataRow = rcDataSet.Tables("djjz").NewRow
            rcDataRow.Item("xm") = "产品送货单"
            rcDataRow.Item("bqzs") = rcDataSet.Tables("bqzs").Rows(0).Item("bqzs")
            rcDataRow.Item("wjzzs") = rcDataSet.Tables("wjzzs").Rows(0).Item("wjzzs")
            rcDataRow.Item("yjzzs") = rcDataSet.Tables("yjzzs").Rows(0).Item("yjzzs")
            rcDataRow.Item("bcjzzs") = rcDataSet.Tables("bcjzzs").Rows(0).Item("bcjzzs")
            rcDataSet.Tables("djjz").Rows.Add(rcDataRow)
        End If
        '产品销售发票(含其他应收单)
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '取入库单本期张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As bqzs FROM oe_fp WHERE bdelete = 0 AND TRUNC(fprq,'dd')>= ? AND TRUNC(fprq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("bqzs") IsNot Nothing Then
                rcDataSet.Tables("bqzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "bqzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As wjzzs FROM oe_fp WHERE bdelete = 0 AND TRUNC(fprq,'dd')>= ? AND TRUNC(fprq,'dd') <= ? And jzr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("wjzzs") IsNot Nothing Then
                rcDataSet.Tables("wjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "wjzzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As yjzzs FROM oe_fp WHERE bdelete = 0 AND TRUNC(fprq,'dd')>= ? AND TRUNC(fprq,'dd') <= ? And Not jzr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("yjzzs") IsNot Nothing Then
                rcDataSet.Tables("yjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "yjzzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As bcjzzs FROM oe_fp WHERE bdelete = 0 AND TRUNC(fprq,'dd')>= ? AND TRUNC(fprq,'dd') <= ? And jzr Is Null And Not shr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("bcjzzs") IsNot Nothing Then
                rcDataSet.Tables("bcjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "bcjzzs")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("bqzs").Rows.Count > 0 And rcDataSet.Tables("wjzzs").Rows.Count > 0 And rcDataSet.Tables("yjzzs").Rows.Count > 0 And rcDataSet.Tables("bcjzzs").Rows.Count > 0 Then
            '添加数据
            Dim rcDataRow As DataRow
            rcDataRow = rcDataSet.Tables("djjz").NewRow
            rcDataRow.Item("xm") = "产品销售发票（含其他应收单）"
            rcDataRow.Item("bqzs") = rcDataSet.Tables("bqzs").Rows(0).Item("bqzs")
            rcDataRow.Item("wjzzs") = rcDataSet.Tables("wjzzs").Rows(0).Item("wjzzs")
            rcDataRow.Item("yjzzs") = rcDataSet.Tables("yjzzs").Rows(0).Item("yjzzs")
            rcDataRow.Item("bcjzzs") = rcDataSet.Tables("bcjzzs").Rows(0).Item("bcjzzs")
            rcDataSet.Tables("djjz").Rows.Add(rcDataRow)
        End If
        '收款单
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '取入库单本期张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As bqzs FROM ar_skd WHERE TRUNC(skrq,'dd')>= ? AND TRUNC(skrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("bqzs") IsNot Nothing Then
                rcDataSet.Tables("bqzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "bqzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As wjzzs FROM ar_skd WHERE TRUNC(skrq,'dd')>= ? AND TRUNC(skrq,'dd') <= ? And jzr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("wjzzs") IsNot Nothing Then
                rcDataSet.Tables("wjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "wjzzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As yjzzs FROM ar_skd WHERE TRUNC(skrq,'dd')>= ? AND TRUNC(skrq,'dd') <= ? And Not jzr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("yjzzs") IsNot Nothing Then
                rcDataSet.Tables("yjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "yjzzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As bcjzzs FROM ar_skd WHERE TRUNC(skrq,'dd')>= ? AND TRUNC(skrq,'dd') <= ? And jzr Is Null And Not shr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("bcjzzs") IsNot Nothing Then
                rcDataSet.Tables("bcjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "bcjzzs")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("bqzs").Rows.Count > 0 And rcDataSet.Tables("wjzzs").Rows.Count > 0 And rcDataSet.Tables("yjzzs").Rows.Count > 0 And rcDataSet.Tables("bcjzzs").Rows.Count > 0 Then
            '添加数据
            Dim rcDataRow As DataRow
            rcDataRow = rcDataSet.Tables("djjz").NewRow
            rcDataRow.Item("xm") = "收款单"
            rcDataRow.Item("bqzs") = rcDataSet.Tables("bqzs").Rows(0).Item("bqzs")
            rcDataRow.Item("wjzzs") = rcDataSet.Tables("wjzzs").Rows(0).Item("wjzzs")
            rcDataRow.Item("yjzzs") = rcDataSet.Tables("yjzzs").Rows(0).Item("yjzzs")
            rcDataRow.Item("bcjzzs") = rcDataSet.Tables("bcjzzs").Rows(0).Item("bcjzzs")
            rcDataSet.Tables("djjz").Rows.Add(rcDataRow)
        End If
        '记账凭证
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '取入库单本期张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As bqzs FROM gl_pz WHERE TRUNC(pzrq,'dd')>= ? AND TRUNC(pzrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@pzrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@pzrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("bqzs") IsNot Nothing Then
                rcDataSet.Tables("bqzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "bqzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As wjzzs FROM gl_pz WHERE TRUNC(pzrq,'dd')>= ? AND TRUNC(pzrq,'dd') <= ? And jzr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@pzrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@pzrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("wjzzs") IsNot Nothing Then
                rcDataSet.Tables("wjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "wjzzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As yjzzs FROM gl_pz WHERE TRUNC(pzrq,'dd')>= ? AND TRUNC(pzrq,'dd') <= ? And Not jzr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@pzrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@pzrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("yjzzs") IsNot Nothing Then
                rcDataSet.Tables("yjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "yjzzs")
            '取入库单本期未记账张数
            rcOleDbCommand.CommandText = "SELECT Nvl(Count(*),0) As bcjzzs FROM gl_pz WHERE TRUNC(pzrq,'dd')>= ? AND TRUNC(pzrq,'dd') <= ? And jzr Is Null And Not shr Is Null"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@pzrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@pzrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("bcjzzs") IsNot Nothing Then
                rcDataSet.Tables("bcjzzs").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "bcjzzs")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("bqzs").Rows.Count > 0 And rcDataSet.Tables("wjzzs").Rows.Count > 0 And rcDataSet.Tables("yjzzs").Rows.Count > 0 And rcDataSet.Tables("bcjzzs").Rows.Count > 0 Then
            '添加数据
            Dim rcDataRow As DataRow
            rcDataRow = rcDataSet.Tables("djjz").NewRow
            rcDataRow.Item("xm") = "记账凭证"
            rcDataRow.Item("bqzs") = rcDataSet.Tables("bqzs").Rows(0).Item("bqzs")
            rcDataRow.Item("wjzzs") = rcDataSet.Tables("wjzzs").Rows(0).Item("wjzzs")
            rcDataRow.Item("yjzzs") = rcDataSet.Tables("yjzzs").Rows(0).Item("yjzzs")
            rcDataRow.Item("bcjzzs") = rcDataSet.Tables("bcjzzs").Rows(0).Item("bcjzzs")
            rcDataSet.Tables("djjz").Rows.Add(rcDataRow)
        End If

    End Sub

#End Region

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NudYear.KeyPress, NudYear.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "单据记账"

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            'po_cgd
            rcOleDbCommand.CommandText = "UPDATE po_cgd SET jzr = ?,jzrq = SYSDATE WHERE NOT po_cgd.shr IS NULL AND TRUNC(cgrq,'dd')>= ? AND TRUNC(cgrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@jzr", OleDbType.VarChar, 30).Value = g_User_DspName
            rcOleDbCommand.Parameters.Add("@cgrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@cgrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbCommand.ExecuteNonQuery()
            'po_rkd
            rcOleDbCommand.CommandText = "INSERT INTO inv_cpyeb (kjnd,cpdm,ckdm,qcsl,qcje,idsl,idje) (SELECT ? AS kjnd,po_rkd.cpdm,po_rkd.ckdm,0.0 As qcsl,0.0 As qcje,0.0 AS idsl,0.0 AS idje FROM po_rkd WHERE po_rkd.bdelete = 0 AND NOT po_rkd.cpdm IS NULL AND NOT po_rkd.ckdm IS NULL AND NOT po_rkd.shr IS NULL AND NOT EXISTS (SELECT 1 FROM inv_cpyeb WHERE inv_cpyeb.cpdm = po_rkd.cpdm AND inv_cpyeb.ckdm = po_rkd.ckdm) AND TRUNC(rkrq,'dd')>= ? AND TRUNC(rkrq,'dd') <= ? GROUP BY po_rkd.cpdm,po_rkd.ckdm)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "UPDATE po_rkd SET jzr = ?,jzrq = SYSDATE WHERE NOT po_rkd.shr IS NULL AND TRUNC(rkrq,'dd')>= ? AND TRUNC(rkrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@jzr", OleDbType.VarChar, 30).Value = g_User_DspName
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbCommand.ExecuteNonQuery()
            'po_fp
            rcOleDbCommand.CommandText = "UPDATE po_fp SET jzr = ?,jzrq = SYSDATE WHERE NOT po_fp.shr IS NULL AND TRUNC(fprq,'dd')>= ? AND TRUNC(fprq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@jzr", OleDbType.VarChar, 30).Value = g_User_DspName
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbCommand.ExecuteNonQuery()
            'ap_fkd
            rcOleDbCommand.CommandText = "UPDATE ap_fkd SET jzr = ?,jzrq = SYSDATE WHERE NOT ap_fkd.shr IS NULL AND TRUNC(fkrq,'dd')>= ? AND TRUNC(fkrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@jzr", OleDbType.VarChar, 30).Value = g_User_DspName
            rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbCommand.ExecuteNonQuery()
            'inv_ckd
            rcOleDbCommand.CommandText = "INSERT INTO inv_cpyeb (kjnd,cpdm,ckdm,qcsl,qcje,idsl,idje) (SELECT ? AS kjnd,inv_ckd.cpdm,inv_ckd.ckdm,0.0 As qcsl,0.0 As qcje,0.0 AS idsl,0.0 AS idje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND NOT inv_ckd.cpdm IS NULL AND NOT inv_ckd.ckdm IS NULL AND NOT inv_ckd.shr IS NULL AND NOT EXISTS (SELECT 1 FROM inv_cpyeb WHERE inv_cpyeb.cpdm = inv_ckd.cpdm AND inv_cpyeb.ckdm = inv_ckd.ckdm) AND TRUNC(ckrq,'dd')>= ? AND TRUNC(ckrq,'dd') <= ? GROUP BY inv_ckd.cpdm,inv_ckd.ckdm)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "UPDATE inv_ckd SET jzr = ?,jzrq = SYSDATE WHERE Not inv_ckd.shr IS NULL AND TRUNC(ckrq,'dd')>= ? AND TRUNC(ckrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@jzr", OleDbType.VarChar, 30).Value = g_User_DspName
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbCommand.ExecuteNonQuery()
            'inv_dbd
            rcOleDbCommand.CommandText = "INSERT INTO inv_cpyeb (kjnd,cpdm,ckdm,qcsl,qcje,idsl,idje) (SELECT ? AS kjnd,inv_dbd.cpdm,inv_dbd.rckdm AS ckdm,0.0 As qcsl,0.0 As qcje,0.0 AS idsl,0.0 AS idje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND NOT inv_dbd.cpdm IS NULL AND NOT inv_dbd.rckdm IS NULL AND NOT inv_dbd.shr IS NULL AND NOT EXISTS (SELECT 1 FROM inv_cpyeb WHERE inv_cpyeb.cpdm = inv_dbd.cpdm AND inv_cpyeb.ckdm = inv_dbd.rckdm) AND TRUNC(dbrq,'dd')>= ? AND TRUNC(dbrq,'dd') <= ? GROUP BY inv_dbd.cpdm,inv_dbd.rckdm)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "INSERT INTO inv_cpyeb (kjnd,cpdm,ckdm,qcsl,qcje,idsl,idje) (SELECT ? AS kjnd,inv_dbd.cpdm,inv_dbd.cckdm AS ckdm,0.0 As qcsl,0.0 As qcje,0.0 AS idsl,0.0 AS idje FROM inv_dbd WHERE NOT inv_dbd.cpdm IS NULL AND NOT inv_dbd.cckdm IS NULL AND NOT inv_dbd.shr IS NULL AND NOT EXISTS (SELECT 1 FROM inv_cpyeb WHERE inv_cpyeb.cpdm = inv_dbd.cpdm AND inv_cpyeb.ckdm = inv_dbd.cckdm) AND TRUNC(dbrq,'dd')>= ? AND TRUNC(dbrq,'dd') <= ? GROUP BY inv_dbd.cpdm,inv_dbd.cckdm)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "UPDATE inv_dbd SET jzr = ?,jzrq = SYSDATE WHERE Not inv_dbd.shr IS NULL AND TRUNC(dbrq,'dd')>= ? AND TRUNC(dbrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@jzr", OleDbType.VarChar, 30).Value = g_User_DspName
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbCommand.ExecuteNonQuery()
            'inv_pc
            rcOleDbCommand.CommandText = "INSERT INTO inv_cpyeb (kjnd,cpdm,ckdm,qcsl,qcje,idsl,idje) (SELECT ? AS kjnd,inv_pc.cpdm,inv_pc.ckdm,0.0 As qcsl,0.0 As qcje,0.0 AS idsl,0.0 AS idje FROM inv_pc WHERE NOT inv_pc.cpdm IS NULL AND NOT inv_pc.ckdm IS NULL AND NOT inv_pc.shr IS NULL AND NOT EXISTS (SELECT 1 FROM inv_cpyeb WHERE inv_cpyeb.cpdm = inv_pc.cpdm AND inv_cpyeb.ckdm = inv_pc.ckdm) AND TRUNC(pcrq,'dd')>= ? AND TRUNC(pcrq,'dd') <= ? GROUP BY inv_pc.cpdm,inv_pc.ckdm)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
            rcOleDbCommand.Parameters.Add("@pcrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@pcrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "UPDATE inv_pc SET jzr = ?,jzrq = SYSDATE WHERE NOT inv_pc.shr IS NULL AND TRUNC(pcrq,'dd')>= ? AND TRUNC(pcrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@jzr", OleDbType.VarChar, 30).Value = g_User_DspName
            rcOleDbCommand.Parameters.Add("@pcrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@pcrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbCommand.ExecuteNonQuery()
            'pm_dd
            rcOleDbCommand.CommandText = "UPDATE pm_dd SET jzr = ?,jzrq = SYSDATE WHERE NOT pm_dd.shr IS NULL AND TRUNC(qdrq,'dd')>= ? AND TRUNC(qdrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@jzr", OleDbType.VarChar, 30).Value = g_User_DspName
            rcOleDbCommand.Parameters.Add("@qdrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@qdrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbCommand.ExecuteNonQuery()
            'inv_rkd
            rcOleDbCommand.CommandText = "INSERT INTO inv_cpyeb (kjnd,cpdm,ckdm,qcsl,qcje,idsl,idje) (SELECT ? AS kjnd,inv_rkd.cpdm,inv_rkd.ckdm,0.0 As qcsl,0.0 As qcje,0.0 AS idsl,0.0 AS idje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND NOT inv_rkd.cpdm IS NULL AND NOT inv_rkd.ckdm IS NULL AND NOT inv_rkd.shr IS NULL AND NOT EXISTS (SELECT 1 FROM inv_cpyeb WHERE inv_cpyeb.cpdm = inv_rkd.cpdm AND inv_cpyeb.ckdm = inv_rkd.ckdm) AND TRUNC(rkrq,'dd')>= ? AND TRUNC(rkrq,'dd') <= ? GROUP BY inv_rkd.cpdm,inv_rkd.ckdm)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "UPDATE inv_rkd SET jzr = ?,jzrq = SYSDATE WHERE NOT inv_rkd.shr IS NULL AND TRUNC(rkrq,'dd')>= ? AND TRUNC(rkrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@jzr", OleDbType.VarChar, 30).Value = g_User_DspName
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbCommand.ExecuteNonQuery()
            'oe_dd
            rcOleDbCommand.CommandText = "UPDATE oe_dd SET jzr = ?,jzrq = SYSDATE WHERE NOT oe_dd.shr IS NULL AND TRUNC(qdrq,'dd')>= ? AND TRUNC(qdrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@jzr", OleDbType.VarChar, 30).Value = g_User_DspName
            rcOleDbCommand.Parameters.Add("@qdrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@qdrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbCommand.ExecuteNonQuery()
            'oe_xsd
            rcOleDbCommand.CommandText = "INSERT INTO inv_cpyeb (kjnd,cpdm,ckdm,qcsl,qcje,idsl,idje) (SELECT ? AS kjnd,oe_xsd.cpdm,oe_xsd.ckdm,0.0 As qcsl,0.0 As qcje,0.0 AS idsl,0.0 AS idje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND NOT oe_xsd.cpdm IS NULL AND NOT oe_xsd.ckdm IS NULL AND NOT oe_xsd.shr IS NULL AND NOT EXISTS (SELECT 1 FROM inv_cpyeb WHERE inv_cpyeb.cpdm = oe_xsd.cpdm AND inv_cpyeb.ckdm = oe_xsd.ckdm) AND TRUNC(xsrq,'dd')>= ? AND TRUNC(xsrq,'dd') <= ? GROUP BY oe_xsd.cpdm,oe_xsd.ckdm)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "UPDATE oe_xsd SET jzr = ?,jzrq = SYSDATE WHERE NOT oe_xsd.shr IS NULL AND TRUNC(xsrq,'dd')>= ? AND TRUNC(xsrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@jzr", OleDbType.VarChar, 30).Value = g_User_DspName
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbCommand.ExecuteNonQuery()
            'oe_fp
            rcOleDbCommand.CommandText = "UPDATE oe_fp SET jzr = ?,jzrq = SYSDATE WHERE NOT oe_fp.shr IS NULL AND TRUNC(fprq,'dd')>= ? AND TRUNC(fprq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@jzr", OleDbType.VarChar, 30).Value = g_User_DspName
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbCommand.ExecuteNonQuery()
            'ar_skd
            rcOleDbCommand.CommandText = "UPDATE ar_skd SET jzr = ?,jzrq = SYSDATE WHERE NOT ar_skd.shr IS NULL AND TRUNC(skrq,'dd')>= ? AND TRUNC(skrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@jzr", OleDbType.VarChar, 30).Value = g_User_DspName
            rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbCommand.ExecuteNonQuery()
            'gl_pz
            rcOleDbCommand.CommandText = "UPDATE gl_pz SET jzr = ?,jzrq = SYSDATE WHERE NOT gl_pz.shr IS NULL AND TRUNC(pzrq,'dd')>= ? AND TRUNC(pzrq,'dd') <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@jzr", OleDbType.VarChar, 30).Value = g_User_DspName
            rcOleDbCommand.Parameters.Add("@pzrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@pzrq", OleDbType.Date, 8).Value = dateZzrq.Date
            rcOleDbCommand.ExecuteNonQuery()
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
            rcOleDbConn.Close()
        End Try
        MsgBox("本月记账完成。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        Me.Close()
    End Sub

#End Region
End Class