Imports System.Data.OleDb
Public Class FrmOeYpddJqShz

#Region "定义变量"
    '建立数据适配器
    Dim rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    Dim rcDataSet As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立命令
    Dim rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    'DataGridViewTextBoxEditingControl
    Dim EditingControl As DataGridViewTextBoxEditingControl
    '建立打印文档
    Dim rcRps As RPS.Document
#End Region

#Region "初始化"

    Public Property paraDataSet() As DataSet
        Get
            paraDataSet = rcDataSet
        End Get
        Set(ByVal Value As DataSet)
            rcDataSet = Value
        End Set
    End Property

    Private Sub FrmOeYpddJqShz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '设置DataGridView
        Me.rcDataGridView.AutoGenerateColumns = False
        '绑定数据the DataGridview to the DataTable.
        rcBindingSource.DataSource = rcDataSet.Tables("rc_ddnr")
        Me.rcDataGridView.DataSource = rcBindingSource
    End Sub

#End Region

#Region "审核事件"
    Private Sub BtnSh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSh.Click
        ShEvent()
    End Sub

    Private Sub MnuiSh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiSh.Click
        ShEvent()
    End Sub

    Private Sub ShEvent()
        If String.IsNullOrEmpty(Me.rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColBmdm").Value) Or Me.rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColScjhrq").GetType.ToString = "System.DBNull" Then
            MsgBox("存在没有录入生产厂或没有确认交期的数据，不能进行审核。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        '检查非工作日情况
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT * FROM rc_fgzrxx WHERE rq = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@rq", OleDbType.Date, 8).Value = Me.rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColScjhrq").Value
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If Not rcDataSet.Tables("rc_fgzrxx") Is Nothing Then
                rcDataSet.Tables("rc_fgzrxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_fgzrxx")
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
        If rcDataSet.Tables("rc_fgzrxx").Rows.Count > 0 Then
            If MsgBox("该日期为非工作日，是否安排该生产交期？", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "提示信息") = MsgBoxResult.No Then
                Return
            End If
        End If
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "UPDATE oe_ypdd SET jqshr = ?,jqshrq = SYSDATE() WHERE djh = ? and xh = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@jqshr", OleDbType.VarChar, 30).Value = g_User_DspName
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColDjh").Value
            rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = Me.rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColXh").Value
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
    End Sub

#End Region

#Region "消审事件"

    Private Sub BtnXs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXs.Click
        XsEvent()
    End Sub

    Private Sub MnuiXs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiXs.Click
        XsEvent()
    End Sub

    Private Sub XsEvent()
        '检查数据
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT zt FROM oe_ypdd where zt > 3 and djh = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColDjh").Value
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If Not rcDataSet.Tables("nobm") Is Nothing Then
                rcDataSet.Tables("nobm").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "nobm")
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
        If rcDataSet.Tables("nobm").Rows.Count > 0 Then
            MsgBox("存在已经出库的数据，不能取消审核。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        '
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "UPDATE oe_ypdd SET jqshr = ?,jqshrq = NULL WHERE djh = ? and xh = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@jqshr", OleDbType.VarChar, 30).Value = ""
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColDjh").Value
            rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = Me.rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColXh").Value
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
    End Sub

#End Region

#Region "全审事件"

    Private Sub BtnQs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQs.Click
        QsEvent()
    End Sub

    Private Sub MnuiQs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiQs.Click
        QsEvent()
    End Sub

    Private Sub QsEvent()
        Dim i As Integer = 0.0
        For i = 0 To rcDataSet.Tables("rc_ddnr").Rows.Count - 1
            If rcDataSet.Tables("rc_ddnr").Rows(i).Item("bmdm") = "" Or rcDataSet.Tables("rc_ddnr").Rows(i).Item("scjhrq").GetType.ToString = "System.DBNull" Then
                MsgBox("存在没有录入生产厂或没有确认交期的数据，不能进行审核。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            '检查非工作日情况
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "SELECT * FROM rc_fgzrxx WHERE rq = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@rq", OleDbType.Date, 8).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("scjhrq")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If Not rcDataSet.Tables("rc_fgzrxx") Is Nothing Then
                    rcDataSet.Tables("rc_fgzrxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_fgzrxx")
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
            If rcDataSet.Tables("rc_fgzrxx").Rows.Count > 0 Then
                If MsgBox("该日期为非工作日，是否安排该生产交期？", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "提示信息") = MsgBoxResult.No Then
                    Return
                End If
            End If
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "UPDATE oe_ypdd SET jqshr = ?,jqshrq = SYSDATE() WHERE djh = ? and xh = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@jqshr", OleDbType.VarChar, 30).Value = g_User_DspName
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("djh")
                rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("xh")
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
        MsgBox("审核完成。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
    End Sub

#End Region

#Region "全消事件"

    Private Sub BtnQx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQx.Click
        QxEvent()
    End Sub

    Private Sub MnuiQx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiQx.Click
        QxEvent()
    End Sub

    Private Sub QxEvent()
        Dim i As Integer = 0
        For i = 0 To rcDataSet.Tables("rc_ddnr").Rows.Count - 1
            '检查数据
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "SELECT zt FROM oe_ypdd where zt > 3 and djh = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("djh")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If Not rcDataSet.Tables("nobm") Is Nothing Then
                    rcDataSet.Tables("nobm").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "nobm")
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
            If rcDataSet.Tables("nobm").Rows.Count > 0 Then
                MsgBox("存在已经出库的数据，不能取消审核。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            '
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "UPDATE oe_ypdd SET jqshr = ?,jqshrq = NULL WHERE djh = ? and xh = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@jqshr", OleDbType.VarChar, 30).Value = ""
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("djh")
                rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("xh")
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
        MsgBox("取消审核完成。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
    End Sub

#End Region

#Region "退出事件"

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiExit.Click, BtnExit.Click
        Me.Close()
    End Sub

#End Region
End Class