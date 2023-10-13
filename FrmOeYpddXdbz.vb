Imports System.Data.OleDb

Public Class FrmOeYpddXdbz

#Region "�������"
    '��ӡ�ĵ�
    Dim rcRps As RPS.Document = Nothing

#End Region

#Region "��ʼ��"

    Private Sub FrmOeYpddXdbz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        rcDataGridView.DataSource = ParaDataView
    End Sub

#End Region

    Overrides Sub PageSetupEvent()
        Dim rcFrm As New models.FrmPageSetup
        With rcFrm
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = "YPDDXDB"
            .paraRpsName = "��Ʒ�����´��"
            .ShowDialog()
        End With
    End Sub

    Overrides Sub PrintEvent()
        If g_Demo = 1 Then
            MsgBox("�Բ�������������ܴ�ӡ��", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
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
        Dim rft As String = CurDir() + "\reports\ypddxdb.rft"
        If rcRps Is Nothing Then
            rcRps = New RPS.Document
        End If
        rcRps.LoadTemplate(rft)
        rcRps.Text(-1, 2) = Me.Label2.Text
        rcRps.Text(-1, 4) = "��ӡ�ˣ�" + g_User_DspName
        Dim i As Integer
        Dim j As Integer
        For i = 0 To rcDataView.Count - 1
            If rcDataView.Item(i).Row.RowState <> 8 Then
                '���ݺ�,��ͬ����,�ͻ�����,�ͻ�����,�ջ���,�ͻ��Ϻ�,��Ʒ����,�ͺŹ��,��������,��������,��������,��Ʒ����,��ͬ��������
                If Not rcDataView.Item(i).Row.Item("���ݺ�").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 1) = Trim(rcDataView.Item(i).Row.Item("���ݺ�"))
                End If
                If Not rcDataView.Item(i).Row.Item("��ͬ����").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 2) = Trim(rcDataView.Item(i).Row.Item("��ͬ����"))
                End If
                If Not rcDataView.Item(i).Row.Item("�ͻ�����").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 3) = Trim(rcDataView.Item(i).Row.Item("�ͻ�����"))
                End If
                If Not rcDataView.Item(i).Row.Item("�ͻ�����").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 4) = Trim(rcDataView.Item(i).Row.Item("�ͻ�����"))
                End If
                If Not rcDataView.Item(i).Row.Item("�ջ���").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 5) = Trim(rcDataView.Item(i).Row.Item("�ջ���"))
                End If
                If Not rcDataView.Item(i).Row.Item("�ͻ��Ϻ�").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 6) = Trim(rcDataView.Item(i).Row.Item("�ͻ��Ϻ�"))
                End If
                If Not rcDataView.Item(i).Row.Item("��Ʒ����").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 7) = Trim(rcDataView.Item(i).Row.Item("��Ʒ����"))
                End If
                If Not rcDataView.Item(i).Row.Item("�ͺŹ��").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 8) = Trim(rcDataView.Item(i).Row.Item("�ͺŹ��"))
                End If
                If Not rcDataView.Item(i).Row.Item("��������").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 9) = rcDataView.Item(i).Row.Item("��������")
                End If
                If Not rcDataView.Item(i).Row.Item("��������").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 10) = Trim(rcDataView.Item(i).Row.Item("��������"))
                End If
                If Not rcDataView.Item(i).Row.Item("��������").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 11) = Trim(rcDataView.Item(i).Row.Item("��������"))
                End If
                If Not rcDataView.Item(i).Row.Item("��Ʒ����").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 12) = rcDataView.Item(i).Row.Item("��Ʒ����")
                End If
                If Not rcDataView.Item(i).Row.Item("��ͬ��������").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 13) = Trim(rcDataView.Item(i).Row.Item("��ͬ��������"))
                End If
                j += 1
            End If
        Next
        'ȡRPS����
        rcOleDbConn.Open()
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps where rpsid = 'YPDDXDB'"
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
    End Sub
End Class