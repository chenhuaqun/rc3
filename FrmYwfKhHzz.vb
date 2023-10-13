Public Class FrmYwfKhHzz
    ReadOnly i As Integer = 0

    Private Sub FrmYwfKhHzz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcYwfbl.Format = g_FormatJe0
        Me.DgtbcNewkhBl.Format = g_FormatJe0
        Me.DgtbcByjf.Format = g_FormatJe0
        Me.DgtbcBydf.Format = g_FormatJe0
        Me.DgtbcYwf_Bz.Format = g_FormatJe0
        Me.DgtbcYwf_Newkh.Format = g_FormatJe0
        Me.DgtbcYwf_Zl.Format = g_FormatJe0
        Me.DgtbcCdhpje.Format = g_FormatJe0
        Me.DgtbcYwf_cdhp.Format = g_FormatJe0
        Me.DgtbcYwf_Tx.Format = g_FormatJe0
        Me.DgtbcYongJinJe.Format = g_FormatJe0
        Me.DgtbcYwf_Yj.Format = g_FormatJe0
        Me.DgtbcDaiZhang.Format = g_FormatJe0
        Me.DgtbcYwf_Dz.Format = g_FormatJe0
        Me.DgtbcSuSong.Format = g_FormatJe0
        Me.DgtbcYwf_Ss.Format = g_FormatJe0
        Me.DgtbcYwf_Hj.Format = g_FormatJe0
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
        rcRps.Text(-1, 1) = "物料账面收发存汇总表"
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