Public Class FrmCpSfcHzz1

    Private Sub FrmCpSfcHzz1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcQcsl.Format = g_FormatSl0
        Me.DgtbcQczl.Format = g_FormatSl0
        Me.DgtbcQcje.Format = g_FormatJe0
        Me.DgtbcRksl.Format = g_FormatSl0
        Me.DgtbcRkzl.Format = g_FormatSl0
        Me.DgtbcRkje.Format = g_FormatJe0
        Me.DgtbcCksl.Format = g_FormatSl0
        Me.DgtbcCkzl.Format = g_FormatSl0
        Me.DgtbcCkje.Format = g_FormatJe0
        Me.DgtbcJcsl.Format = g_FormatSl0
        Me.DgtbcJczl.Format = g_FormatSl0
        Me.DgtbcJcje.Format = g_FormatJe0
        rcDataGrid.SetDataBinding(ParaDataView, "")
    End Sub


    Overrides Sub PageSetupEvent()
        Dim rcFrm As New models.FrmPageSetup
        With rcFrm
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = "CPSFCHZ"
            .paraRpsName = "物料收发存汇总表"
            .ShowDialog()
        End With
    End Sub

    Overrides Sub PrintEvent()
        If g_Demo = 1 Then
            MsgBox("对不起，试用软件不能打印。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        PreparePrintData()
        Dim rcFrm As New models.FrmPrint
        With rcFrm
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
        'Dim rft1 As String = Application.StartupPath + "\reports\cpsfchz.csv"
        Dim rft As String = Application.StartupPath + "\reports\cpsfchz.rft"
        'rcRps.LoadCsvTemplate(rft1)
        'rcRps.SaveTemplate(rft)
        rcRps.LoadTemplate(rft)
        '取RPS打印参数
        rcOleDbConn.Open()
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps where rpsid = 'CPSFCHZ'"
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
        '套打
        'rcRps.PaperType = 1
        rcRps.Text(-1, 1) = "物料收发存汇总表" & "（" & Trim(Label3.Text) & "）"
        rcRps.Text(-1, 2) = Trim(Me.Label2.Text)
        rcRps.Text(-1, 4) = "打印人：" & Trim(g_User_DspName)
        Dim i As Integer
        Dim j As Integer
        For i = 0 To rcDataView.Count - 1
            If rcDataView.Item(i).Row.RowState <> DataRowState.Deleted Then
                If Not rcDataView.Item(i).Row.Item("cpdm").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 1) = Trim(rcDataView.Item(i).Row.Item("cpdm"))
                End If
                If Not rcDataView.Item(i).Row.Item("cpmc").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 2) = Trim(rcDataView.Item(i).Row.Item("cpmc"))
                End If
                If Not rcDataView.Item(i).Row.Item("dw").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 3) = Trim(rcDataView.Item(i).Row.Item("dw"))
                End If
                If Not rcDataView.Item(i).Row.Item("qcsl").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 4) = Format(rcDataView.Item(i).Row.Item("qcsl"), g_FormatSl0)
                End If
                If rcDataView.Item(i).Row.Item("qcsl") <> 0 Then
                    rcRps.Text(j + 1, 5) = Format(rcDataView.Item(i).Row.Item("qcje") / rcDataView.Item(i).Row.Item("qcsl"), g_FormatDj0)
                End If
                If Not rcDataView.Item(i).Row.Item("qcje").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 6) = Format(rcDataView.Item(i).Row.Item("qcje"), g_FormatJe0)
                End If
                If Not rcDataView.Item(i).Row.Item("rksl").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 7) = Format(rcDataView.Item(i).Row.Item("rksl"), g_FormatSl0)
                End If
                If rcDataView.Item(i).Row.Item("rksl") <> 0 Then
                    rcRps.Text(j + 1, 8) = Format(rcDataView.Item(i).Row.Item("rkje") / rcDataView.Item(i).Row.Item("rksl"), g_FormatDj0)
                End If
                If Not rcDataView.Item(i).Row.Item("rkje").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 9) = Format(rcDataView.Item(i).Row.Item("rkje"), g_FormatJe0)
                End If
                If Not rcDataView.Item(i).Row.Item("cksl").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 10) = Format(rcDataView.Item(i).Row.Item("cksl"), g_FormatSl0)
                End If
                If rcDataView.Item(i).Row.Item("cksl") <> 0 Then
                    rcRps.Text(j + 1, 11) = Format(rcDataView.Item(i).Row.Item("ckje") / rcDataView.Item(i).Row.Item("cksl"), g_FormatDj0)
                End If
                If Not rcDataView.Item(i).Row.Item("ckje").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 12) = Format(rcDataView.Item(i).Row.Item("ckje"), g_FormatJe0)
                End If
                If Not rcDataView.Item(i).Row.Item("jcsl").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 13) = Format(rcDataView.Item(i).Row.Item("jcsl"), g_FormatSl0)
                End If
                If rcDataView.Item(i).Row.Item("jcsl") <> 0 Then
                    rcRps.Text(j + 1, 14) = Format(rcDataView.Item(i).Row.Item("jcje") / rcDataView.Item(i).Row.Item("jcsl"), g_FormatDj0)
                End If
                If Not rcDataView.Item(i).Row.Item("jcje").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 15) = Format(rcDataView.Item(i).Row.Item("jcje"), g_FormatJe0)
                End If
                j += 1
            End If
        Next
    End Sub

End Class