Imports System.Data.OleDb

Public Class FrmOeYpddXdb

#Region "定义变量"

    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立命令对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

#End Region

#Region "确定事件"

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        '取数据
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "Select 单据号,合同编码,客户编码,客户名称,收货人,客户料号,产品名称,型号规格,订单数量,部门名称,生产交期,产品属性,合同其他条款 From view_oe_ypdd Where 签单日期 >= ? And 签单日期 <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.AddWithValue("@qdrq", Me.DtpQdrqBegin.Value.Date)
            rcOleDbCommand.Parameters.AddWithValue("@qdrq", Me.DtpQdrqEnd.Value.Date)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_ypdd") IsNot Nothing Then
                Me.rcDataset.Tables("rc_ypdd").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_ypdd")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_ypdd").Rows.Count = 0 Then
            MsgBox("请定义产品信息。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        '调用表单
        Dim rcFrm As New FrmOeYpddXdbz
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("rc_ypdd"), "TRUE", "单据号", DataViewRowState.CurrentRows)
            .Label2.Text = Me.DtpQdrqBegin.Value.Date.ToLongDateString & "至" & Me.DtpQdrqEnd.Value.Date.ToLongDateString
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

#End Region
End Class