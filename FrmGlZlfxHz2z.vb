Public Class FrmGlZlfxHz2z

    Private Sub FrmGlZlfxHz2z_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcQmye.Format = g_FormatJe0
        Me.DgtbcJe01.Format = g_FormatJe0
        Me.DgtbcJe02.Format = g_FormatJe0
        Me.DgtbcJe03.Format = g_FormatJe0
        Me.DgtbcJe04.Format = g_FormatJe0
        Me.DgtbcJe05.Format = g_FormatJe0
        Me.DgtbcJe06.Format = g_FormatJe0
        Me.DgtbcJe07.Format = g_FormatJe0
        Me.DgtbcDqje.Format = g_FormatJe0
        Me.DgtbcYqje.Format = g_FormatJe0
        Me.DgtbcByjf.Format = g_FormatJe0
        Me.DgtbcBydf.Format = g_FormatJe0
        Me.DgtbcLjjf.Format = g_FormatJe0
        Me.DgtbcLjdf.Format = g_FormatJe0
        ''账龄分段信息
        'For i = 0 To ParaDataSet.Tables("rc_kczlfd").Rows.Count - 1
        '    Dim DgtbcKcsl As New DataGridTextBoxColumn
        '    DgtbcKcsl.MappingName = "kcsl_" & (i + 1).ToString.PadLeft(2, "0")
        '    If i = ParaDataSet.Tables("rc_kczlfd").Rows.Count - 1 And i > 0 Then
        '        DgtbcKcsl.HeaderText = ParaDataSet.Tables("rc_kczlfd").Rows(i - 1).Item("zhangling") & "个月以上库存数量"
        '    Else
        '        DgtbcKcsl.HeaderText = ParaDataSet.Tables("rc_kczlfd").Rows(i).Item("zhangling") & "个月库存数量"
        '    End If
        '    DgtbcKcsl.Format = g_FormatSl0
        '    DgtbcKcsl.Alignment = HorizontalAlignment.Right
        '    DgtbcKcsl.Width = 80
        '    Me.DataGridTableStyle1.GridColumnStyles.Add(DgtbcKcsl)
        '    Dim DgtbcKcje As New DataGridTextBoxColumn
        '    DgtbcKcje.MappingName = "kcje_" & (i + 1).ToString.PadLeft(2, "0")
        '    If i = ParaDataSet.Tables("rc_kczlfd").Rows.Count - 1 And i > 0 Then
        '        DgtbcKcje.HeaderText = ParaDataSet.Tables("rc_kczlfd").Rows(i - 1).Item("zhangling") & "个月以上库存金额"
        '    Else
        '        DgtbcKcje.HeaderText = ParaDataSet.Tables("rc_kczlfd").Rows(i).Item("zhangling") & "个月库存金额"
        '    End If
        '    DgtbcKcje.Format = g_FormatJe0
        '    DgtbcKcje.Alignment = HorizontalAlignment.Right
        '    DgtbcKcje.Width = 80
        '    Me.DataGridTableStyle1.GridColumnStyles.Add(DgtbcKcje)
        'Next
        rcDataGrid.SetDataBinding(ParaDataView, "")
    End Sub


    Overrides Sub PageSetupEvent()
        Dim rcFrm As New models.FrmPageSetup
        With rcFrm
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = "GlZlfx"
            .paraRpsName = "物料盘存表"
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
            .ParaRps = rcRps
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
        'Dim rft1 As String = Application.StartupPath + "\reports\sfchz.csv"
        Dim rft As String = Application.StartupPath + "\reports\sfchz.rft"
        'rcRps.LoadCsvTemplate(rft1)
        'rcRps.SaveTemplate(rft)
        rcRps.LoadTemplate(rft)
        '取RPS打印参数
        rcOleDbConn.Open()
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps WHERE rpsid = 'GlZlfx'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_rps") IsNot Nothing Then
                rcDataSet.Tables("rc_rps").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_rps")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_rps").Rows.Count > 0 Then
            '设定值
            rcRps.Scale = rcDataset.Tables("rc_rps").Rows(0).Item("scale")
            rcRps.Orientation = rcDataset.Tables("rc_rps").Rows(0).Item("orientation")
            rcRps.PaperWidth = rcDataset.Tables("rc_rps").Rows(0).Item("paperwidth")
            rcRps.PaperHeight = rcDataset.Tables("rc_rps").Rows(0).Item("paperheight")
            rcRps.PrinterLeft = rcDataset.Tables("rc_rps").Rows(0).Item("printerleft")
            rcRps.PrinterTop = rcDataset.Tables("rc_rps").Rows(0).Item("printertop")
        Else
            '默认值
            rcRps.Scale = 100
            rcRps.Orientation = 1
        End If
        '套打
        'rcRps.PaperType = 1
        rcRps.Text(-1, 1) = "账龄分析表"
        rcRps.Text(-1, 2) = Trim(Label2.Text)
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
                If Not rcDataView.Item(i).Row.Item("cpgg").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 3) = Trim(rcDataView.Item(i).Row.Item("cpgg"))
                End If
                If Not rcDataView.Item(i).Row.Item("dw").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 4) = Trim(rcDataView.Item(i).Row.Item("dw"))
                End If
                If Not rcDataView.Item(i).Row.Item("qcsl").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 5) = Format(rcDataView.Item(i).Row.Item("qcsl"), g_FormatSl0)
                End If
                If Not rcDataView.Item(i).Row.Item("qcdj").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 6) = Format(rcDataView.Item(i).Row.Item("qcdj"), g_FormatJe0)
                End If
                If Not rcDataView.Item(i).Row.Item("qcje").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 7) = Format(rcDataView.Item(i).Row.Item("qcje"), g_FormatJe0)
                End If
                If Not rcDataView.Item(i).Row.Item("insl").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 8) = Format(rcDataView.Item(i).Row.Item("insl"), g_FormatSl0)
                End If
                If Not rcDataView.Item(i).Row.Item("indj").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 9) = Format(rcDataView.Item(i).Row.Item("indj"), g_FormatJe0)
                End If
                If Not rcDataView.Item(i).Row.Item("inje").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 10) = Format(rcDataView.Item(i).Row.Item("inje"), g_FormatJe0)
                End If
                If Not rcDataView.Item(i).Row.Item("desl").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 11) = Format(rcDataView.Item(i).Row.Item("desl"), g_FormatSl0)
                End If
                If Not rcDataView.Item(i).Row.Item("dedj").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 12) = Format(rcDataView.Item(i).Row.Item("dedj"), g_FormatJe0)
                End If
                If Not rcDataView.Item(i).Row.Item("deje").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 13) = Format(rcDataView.Item(i).Row.Item("deje"), g_FormatJe0)
                End If
                If Not rcDataView.Item(i).Row.Item("jcsl").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 14) = Format(rcDataView.Item(i).Row.Item("jcsl"), g_FormatSl0)
                End If
                If Not rcDataView.Item(i).Row.Item("jcdj").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 15) = Format(rcDataView.Item(i).Row.Item("jcdj"), g_FormatJe0)
                End If
                If Not rcDataView.Item(i).Row.Item("jcje").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 16) = Format(rcDataView.Item(i).Row.Item("jcje"), g_FormatJe0)
                End If
                j += 1
            End If
        Next
    End Sub

End Class