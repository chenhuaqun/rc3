Public Class FrmOeYpddCxLb

#Region "定义变量"
    '打印文档
    Dim rcRps As RPS.Document = Nothing

#End Region

    Private Sub FrmOeYpddCxLb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'LoadDgcs(Me.rcDataGridTableStyle, "OEYPDDCXLB")
        rcDataGridView.DataSource = ParaDataView
    End Sub


    Overrides Sub PageSetupEvent()
        Dim rcFrm As New models.FrmPageSetup
        With rcFrm
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = "YPDDDJB"
            .paraRpsName = "样品订单发货登记表"
            .ShowDialog()
        End With
    End Sub

    Overrides Sub PrintEvent()
        If g_Demo = 1 Then
            MsgBox("对不起，试用软件不能打印。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        PreparePrintData()
        Dim rcFrmPrint As New models.FrmPrint
        With rcFrmPrint
            '.paraRps = rcRps
            .ShowDialog()
        End With
    End Sub

    Overrides Sub Printviewevent()
        PreparePrintData()
        rcRps.Preview()
    End Sub

    Private Sub PreparePrintData()
        Dim rft As String = CurDir() + "\reports\ypdddjb.rft"
        If rcRps Is Nothing Then
            rcRps = New RPS.Document
        End If
        rcRps.LoadTemplate(rft)
        rcRps.Text(-1, 2) = Me.Label2.Text
        rcRps.Text(-1, 4) = "打印人：" + g_User_DspName
        Dim i As Integer
        Dim j As Integer
        For i = 0 To rcDataView.Count - 1
            If rcDataView.Item(i).Row.RowState <> 8 Then
                '单据号,合同编码,客户编码,客户名称,收货人,客户料号,产品名称,型号规格,订单数量,部门名称,生产交期,产品属性,合同其他条款
                If Not rcDataView.Item(i).Row.Item("发货日期").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 1) = rcDataView.Item(i).Row.Item("发货日期")
                End If
                If Not rcDataView.Item(i).Row.Item("客户名称").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 2) = Trim(rcDataView.Item(i).Row.Item("客户名称"))
                End If
                If Not rcDataView.Item(i).Row.Item("送货单号").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 3) = Trim(rcDataView.Item(i).Row.Item("送货单号"))
                End If
                If Not rcDataView.Item(i).Row.Item("产品名称").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 4) = Trim(rcDataView.Item(i).Row.Item("产品名称"))
                End If
                If Not rcDataView.Item(i).Row.Item("订单数量").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 5) = rcDataView.Item(i).Row.Item("订单数量")
                End If
                If Not rcDataView.Item(i).Row.Item("重量").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 6) = Trim(rcDataView.Item(i).Row.Item("重量"))
                End If
                If Not rcDataView.Item(i).Row.Item("寄件人签名").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 8) = Trim(rcDataView.Item(i).Row.Item("寄件人签名"))
                End If
                j += 1
            End If
        Next
        '取RPS数据
        rcOleDbConn.Open()
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps where rpsid = 'YPDDDJB'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_rps") IsNot Nothing Then
                rcDataSet.Tables("rc_rps").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_rps")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("rc_rps").Rows.Count > 0 Then
            '设定值
            rcRps.Scale = rcDataSet.Tables("rc_rps").Rows(0).Item("scale")
            rcRps.Orientation = rcDataSet.Tables("rc_rps").Rows(0).Item("orientation")
            rcRps.PaperWidth = rcDataSet.Tables("rc_rps").Rows(0).Item("paperwidth")
            rcRps.PaperHeight = rcDataSet.Tables("rc_rps").Rows(0).Item("paperheight")
            rcRps.PrinterLeft = rcDataSet.Tables("rc_rps").Rows(0).Item("printerleft")
            rcRps.PrinterTop = rcDataSet.Tables("rc_rps").Rows(0).Item("printertop")
        Else
            '默认值
            rcRps.Scale = 100
            rcRps.Orientation = 1
        End If
    End Sub

End Class
