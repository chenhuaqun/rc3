Public Class FrmKhYszkHzz

    Private Sub FrmKhYszkHzz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcQcje.Format = g_FormatJe0
        Me.DgtbcYsje.Format = g_FormatJe0
        Me.DgtbcSkje.Format = g_FormatJe0
        Me.DgtbcQmje.Format = g_FormatJe0
        Me.DgtbcWkpje.Format = g_FormatJe0
        rcDataGrid.SetDataBinding(ParaDataView, "")
    End Sub

    Overrides Sub PageSetupEvent()
        Dim rcFrm As New models.FrmPageSetup
        With rcFrm
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = "YSZKHZ"
            .paraRpsName = "客户应收账款汇总表"
            .ShowDialog()
        End With
    End Sub

    Overrides Sub PrintEvent()
        If g_Demo = 1 Then
            MsgBox("对不起，试用软件不能打印。", MsgBoxStyle.OKOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        PreparePrintData()
        Dim rcFrmPrint As New models.FrmPrint
        With rcFrmPrint
            .paraRps = rcRps
            .ShowDialog()
        End With
    End Sub

    Overrides Sub PrintViewEvent()
        PreparePrintData()
        rcRps.Preview()
    End Sub

    Private Sub PreparePrintData()
        If rcRps Is Nothing Then
            rcRps = New RPS.Document
        End If
        'Dim rft1 As String = CurDir() + "\reports\yszkhz.csv"
        Dim rft As String = CurDir() + "\reports\yszkhz.rft"
        'rcRps.LoadCsvTemplate(rft1)
        'rcRps.SaveTemplate(rft)
        rcRps.LoadTemplate(rft)
        rcRps.Text(-1, 2) = Trim(Label2.Text)
        rcRps.Text(-1, 4) = "打印人：" & Trim(g_User_DspName)
        Dim i As Integer
        Dim j As Integer
        For i = 0 To rcDataView.Count - 1
            If rcDataView.Item(i).Row.RowState <> 8 Then
                If Not rcDataView.Item(i).Row.Item("khdm").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 1) = Trim(rcDataView.Item(i).Row.Item("khdm"))
                End If
                If Not rcDataView.Item(i).Row.Item("khmc").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 2) = Trim(rcDataView.Item(i).Row.Item("khmc"))
                End If
                If Not rcDataView.Item(i).Row.Item("qcje").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 3) = Format(rcDataView.Item(i).Row.Item("qcje"), g_FormatJe0)
                End If
                If Not rcDataView.Item(i).Row.Item("ysje").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 4) = Format(rcDataView.Item(i).Row.Item("ysje"), g_FormatJe0)
                End If
                If Not rcDataView.Item(i).Row.Item("skje").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 5) = Format(rcDataView.Item(i).Row.Item("skje"), g_FormatJe0)
                End If
                If Not rcDataView.Item(i).Row.Item("qmje").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 6) = Format(rcDataView.Item(i).Row.Item("qmje"), g_FormatJe0)
                End If
                j += 1
            End If
        Next
        Try
            '取RPS数据
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps WHERE rpsid = 'YSZKHZ'"
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