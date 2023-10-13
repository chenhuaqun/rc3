Public Class FrmSlSfcHzz1

    Private Sub FrmSlSfcHzz1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcQcsl.Format = g_FormatSl0
        Me.DgtbcRksl.Format = g_FormatSl0
        Me.DgtbcCksl.Format = g_FormatSl0
        Me.DgtbcJcsl.Format = g_FormatSl0
        Me.DgtbcQcFzsl.Format = g_FormatSl0
        Me.DgtbcRkFzsl.Format = g_FormatSl0
        Me.DgtbcCkFzsl.Format = g_FormatSl0
        Me.DgtbcJcFzsl.Format = g_FormatSl0
        rcDataGrid.SetDataBinding(ParaDataView, "")
    End Sub

    Overrides Sub PageSetupEvent()
        Dim rcFrm As New models.FrmPageSetup
        With rcFrm
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = "CKSFCHZ"
            .paraRpsName = "�ֿ��շ�����ܱ�"
            .ShowDialog()
        End With
    End Sub

    Overrides Sub PrintEvent()
        If g_Demo = 1 Then
            MsgBox("�Բ�������������ܴ�ӡ��", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
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
        'Dim rft1 As String = Application.StartupPath + "\reports\cksfchz.csv"
        Dim rft As String = Application.StartupPath + "\reports\cksfchz.rft"
        'rcRps.LoadCsvTemplate(rft1)
        'rcRps.SaveTemplate(rft)
        rcRps.LoadTemplate(rft)
        'ȡRPS��ӡ����
        rcOleDbConn.Open()
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps where rpsid = 'CKSFCHZ'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_rps") IsNot Nothing Then
                rcDataSet.Tables("rc_rps").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_rps")
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("rc_rps").Rows.Count > 0 Then
            '�趨ֵ
            rcRps.Scale = rcDataSet.Tables("rc_rps").Rows(0).Item("scale")
            rcRps.Orientation = rcDataSet.Tables("rc_rps").Rows(0).Item("orientation")
            rcRps.PaperWidth = rcDataSet.Tables("rc_rps").Rows(0).Item("paperwidth")
            rcRps.PaperHeight = rcDataSet.Tables("rc_rps").Rows(0).Item("paperheight")
            rcRps.PrinterLeft = rcDataSet.Tables("rc_rps").Rows(0).Item("printerleft")
            rcRps.PrinterTop = rcDataSet.Tables("rc_rps").Rows(0).Item("printertop")
        Else
            'Ĭ��ֵ
            rcRps.Scale = 100
            rcRps.Orientation = 1
        End If
        '�״�
        'rcRps.PaperType = 1
        rcRps.Text(-1, 1) = "�ֿ��շ�����ܱ�" '�� & "��" & Trim(Label3.Text) & "��"
        rcRps.Text(-1, 2) = Trim(Label2.Text)
        rcRps.Text(-1, 4) = "��ӡ�ˣ�" & Trim(g_User_DspName)
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
                If Not rcDataView.Item(i).Row.Item("rksl").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 5) = Format(rcDataView.Item(i).Row.Item("rksl"), g_FormatSl0)
                End If
                If Not rcDataView.Item(i).Row.Item("cksl").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 6) = Format(rcDataView.Item(i).Row.Item("cksl"), g_FormatSl0)
                End If
                If Not rcDataView.Item(i).Row.Item("jcsl").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 7) = Format(rcDataView.Item(i).Row.Item("jcsl"), g_FormatSl0)
                End If
                j += 1
            End If
        Next
    End Sub
End Class