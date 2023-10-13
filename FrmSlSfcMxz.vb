Public Class FrmSlSfcMxz

    Private Sub FrmSlSfcMxz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcRksl.Format = g_FormatSl0
        Me.DgtbcCksl.Format = g_FormatSl0
        Me.DgtbcJcsl.Format = g_FormatSl0
        Me.DgtbcRkfzsl.Format = g_FormatSl0
        Me.DgtbcCkfzsl.Format = g_FormatSl0
        Me.DgtbcJcfzsl.Format = g_FormatSl0
        rcDataGrid.SetDataBinding(ParaDataView, "")
    End Sub

    Overrides Sub PageSetupEvent()
        Dim rcFrm As New models.FrmPageSetup
        With rcFrm
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = "CKSFCMX"
            .paraRpsName = "�ֿ��շ�����ϸ��"
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
        'Dim rft1 As String = Application.StartupPath + "\reports\cksfcmx.csv"
        Dim rft As String = Application.StartupPath + "\reports\cksfcmx.rft"
        'rcRps.LoadCsvTemplate(rft1)
        'rcRps.SaveTemplate(rft)
        rcRps.LoadTemplate(rft)
        'ȡRPS��ӡ����
        rcOleDbConn.Open()
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps where rpsid = 'CKSFCMX'"
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
        rcRps.Text(-1, 1) = "�ֿ��շ�����ϸ��"
        rcRps.Text(-1, 2) = Trim(Label3.Text)
        rcRps.Text(-1, 3) = Trim(Label2.Text)
        rcRps.Text(-1, 5) = "��ӡ�ˣ�" & Trim(g_User_DspName)
        Dim i As Integer
        Dim j As Integer
        For i = 0 To rcDataView.Count - 1
            If rcDataView.Item(i).Row.RowState <> DataRowState.Deleted Then
                If Not rcDataView.Item(i).Row.Item("rq").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 1) = Trim(rcDataView.Item(i).Row.Item("rq"))
                End If
                If Not rcDataView.Item(i).Row.Item("djh").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 2) = Trim(rcDataView.Item(i).Row.Item("djh"))
                End If
                If Not rcDataView.Item(i).Row.Item("zy").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 3) = Trim(rcDataView.Item(i).Row.Item("zy"))
                End If
                If Not rcDataView.Item(i).Row.Item("rksl").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 4) = Format(rcDataView.Item(i).Row.Item("rksl"), g_FormatSl0)
                End If
                If Not rcDataView.Item(i).Row.Item("cksl").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 5) = Format(rcDataView.Item(i).Row.Item("cksl"), g_FormatSl0)
                End If
                If Not rcDataView.Item(i).Row.Item("jcsl").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 6) = Format(rcDataView.Item(i).Row.Item("jcsl"), g_FormatSl0)
                End If
                j += 1
            End If
        Next
    End Sub

End Class