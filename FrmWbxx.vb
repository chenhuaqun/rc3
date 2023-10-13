Imports System.Data.OleDb

Public Class FrmWbxx

#Region "�������"

    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '���ݸ��´���
    Dim rcOleDbTrans As OleDbTransaction
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '������ͼ
    Dim rcDataView As DataView
    '����Datatable '����Ҫ���ø�datatable���н�����
    ReadOnly dtWb As New DataTable("rc_wbxx")
    '��ӡ�ĵ�
    Dim rcRps As RPS.Document = Nothing
    '��ǰ��¼��
    Dim currentPos As Integer

#End Region

#Region "��ʼ��"

    Private Sub FrmWbxx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '���ݰ�
        dtWb.Columns.Add("wbdm", Type.GetType("System.String"))
        dtWb.Columns.Add("wbmc", Type.GetType("System.String"))
        dtWb.Columns.Add("wbsm", Type.GetType("System.String"))
        dtWb.Columns.Add("wbhl01", Type.GetType("System.Double"))
        dtWb.Columns.Add("wbhl02", Type.GetType("System.Double"))
        dtWb.Columns.Add("wbhl03", Type.GetType("System.Double"))
        dtWb.Columns.Add("wbhl04", Type.GetType("System.Double"))
        dtWb.Columns.Add("wbhl05", Type.GetType("System.Double"))
        dtWb.Columns.Add("wbhl06", Type.GetType("System.Double"))
        dtWb.Columns.Add("wbhl07", Type.GetType("System.Double"))
        dtWb.Columns.Add("wbhl08", Type.GetType("System.Double"))
        dtWb.Columns.Add("wbhl09", Type.GetType("System.Double"))
        dtWb.Columns.Add("wbhl10", Type.GetType("System.Double"))
        dtWb.Columns.Add("wbhl11", Type.GetType("System.Double"))
        dtWb.Columns.Add("wbhl12", Type.GetType("System.Double"))
        dtWb.Columns.Add("ywftzbl", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtWb)
        With dtWb
            .Columns("wbdm").DefaultValue = ""
            .Columns("wbmc").DefaultValue = ""
            .Columns("wbsm").DefaultValue = ""
            .Columns("wbhl01").DefaultValue = 0.0
            .Columns("wbhl02").DefaultValue = 0.0
            .Columns("wbhl03").DefaultValue = 0.0
            .Columns("wbhl04").DefaultValue = 0.0
            .Columns("wbhl05").DefaultValue = 0.0
            .Columns("wbhl06").DefaultValue = 0.0
            .Columns("wbhl07").DefaultValue = 0.0
            .Columns("wbhl08").DefaultValue = 0.0
            .Columns("wbhl09").DefaultValue = 0.0
            .Columns("wbhl10").DefaultValue = 0.0
            .Columns("wbhl11").DefaultValue = 0.0
            .Columns("wbhl12").DefaultValue = 0.0
            .Columns("ywftzbl").DefaultValue = 0.0
        End With
        '��ʾ�ȴ���ʽ���
        Cursor.Current = New Cursor(Application.StartupPath & "\" & "Wait.cur")
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT wbdm,wbmc,wbsm,wbhl01,wbhl02,wbhl03,wbhl04,wbhl05,wbhl06,wbhl07,wbhl08,wbhl09,wbhl10,wbhl11,wbhl12,ywftzbl FROM rc_wbxx WHERE kjnd = ? ORDER BY wbdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_wbxx") IsNot Nothing Then
                rcDataset.Tables("rc_wbxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_wbxx")
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        rcDataView = New DataView(rcDataset.Tables("rc_wbxx"))
        rcDataGridView.DataSource = rcDataView
    End Sub

#End Region

#Region "ҳ������"

    Private Sub BtnPageSetup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPageSetup.Click, MnuiPageSetup.Click
        PageSetupEvent()
    End Sub

    Private Sub PageSetupEvent()
        Dim rcFrm As New models.FrmPageSetup
        With rcFrm
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = "WBXX"
            .paraRpsName = "������Ϣ"
            .ShowDialog()
        End With
    End Sub

#End Region

#Region "��ӡ����ӡԤ��"

    Private Sub BtnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPrint.Click, MnuiPrint.Click
        PrintEvent()
    End Sub

    Private Sub PrintEvent()
        If g_Demo = 1 Then
            MsgBox("�Բ��������������ܴ�ӡ��", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        PreparePrintData()
        Dim rcFrmPrint As New models.FrmPrint
        With rcFrmPrint
            .paraRps = rcRps
            .ShowDialog()
        End With
    End Sub

    Private Sub BtnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPreview.Click, MnuiPreview.Click
        PreviewEvent()
    End Sub

    Private Sub PreviewEvent()
        PreparePrintData()
        rcRps.Preview()
    End Sub

    Private Sub PreparePrintData()
        'Dim rft1 As String = CurDir() + "\reports\wbxx.csv"
        Dim rft As String = CurDir() + "\reports\wbxx.rft"
        If rcRps Is Nothing Then
            rcRps = New RPS.Document
        End If
        'rcRps.LoadCsvTemplate(rft1)
        'rcRps.SaveTemplate(rft)
        rcRps.LoadTemplate(rft)
        rcRps.Text(-1, 2) = "��λ��" + g_Dwmc
        rcRps.Text(-1, 4) = "��ӡ�ˣ�" + g_User_DspName
        Dim i As Integer
        For i = 0 To rcDataset.Tables("rc_wbxx").Rows.Count - 1
            rcRps.Text(i + 1, 1) = Trim(rcDataset.Tables("rc_wbxx").Rows(i).Item("wbdm"))
            rcRps.Text(i + 1, 2) = Trim(rcDataset.Tables("rc_wbxx").Rows(i).Item("wbmc"))
            rcRps.Text(i + 1, 3) = Trim(rcDataset.Tables("rc_wbxx").Rows(i).Item("wbsm"))
        Next
        'ȡRPS����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps WHERE rpsid = 'WBXX'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_rps") IsNot Nothing Then
                rcDataset.Tables("rc_rps").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_rps")
        Catch ex As Exception
            MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_rps").Rows.Count > 0 Then
            '�趨ֵ
            rcRps.Scale = rcDataset.Tables("rc_rps").Rows(0).Item("scale")
            rcRps.Orientation = rcDataset.Tables("rc_rps").Rows(0).Item("orientation")
            rcRps.PaperWidth = rcDataset.Tables("rc_rps").Rows(0).Item("paperwidth")
            rcRps.PaperHeight = rcDataset.Tables("rc_rps").Rows(0).Item("paperheight")
            rcRps.PrinterLeft = rcDataset.Tables("rc_rps").Rows(0).Item("printerleft")
            rcRps.PrinterTop = rcDataset.Tables("rc_rps").Rows(0).Item("printertop")
        Else
            'Ĭ��ֵ
            rcRps.Scale = 100
            rcRps.Orientation = 1
        End If
    End Sub

#End Region

#Region "���"

    Private Sub BtnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExport.Click, MnuiExport.Click
        '��������
        Exports2Excel(rcDataset.Tables("rc_wbxx"))
    End Sub

    Public Sub Exports2Excel(ByVal paraDataTable As DataTable)
        If paraDataTable.Rows.Count > 0 Then
            Try
                Me.Cursor = Cursors.WaitCursor
                Dim i, j As Integer
                Dim DataArray(paraDataTable.Rows.Count() - 1, paraDataTable.Columns.Count() - 1) As String
                Dim myExcel As New Microsoft.Office.Interop.Excel.Application
                For i = 0 To paraDataTable.Rows.Count() - 1
                    For j = 0 To paraDataTable.Columns.Count() - 1
                        If paraDataTable.Rows(i).Item(j).GetType.ToString <> "System.DBNull" Then
                            DataArray(i, j) = Trim(paraDataTable.Rows(i).Item(j))
                        Else
                            DataArray(i, j) = ""
                        End If
                    Next
                Next
                myExcel.Application.Workbooks.Add(True)
                myExcel.Visible = True
                For j = 0 To paraDataTable.Columns.Count() - 1
                    myExcel.Cells(1, j + 1) = paraDataTable.Columns(j).ColumnName
                Next
                myExcel.Range("A2").Resize(paraDataTable.Rows.Count, paraDataTable.Columns.Count).Value = DataArray
            Catch exp As Exception
                MessageBox.Show("���ݵ���ʧ�ܣ���鿴�Ƿ��Ѿ���װ��Excel��", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        Else
            MessageBox.Show("û�����ݣ�", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

#End Region

#Region "����"

    Private Sub BtnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNew.Click, MnuiNew.Click
        '����
        Dim rcFrm As New FrmWbEdit
        With rcFrm
            .ParaAdding = True
            .ParaCurrentPos = BindingContext(rcDataView, "").Position
            .ParaDataSet = rcDataset
            .ParaDataView = rcDataView
            .ShowDialog()
        End With
        Me.rcDataGridView.Refresh()
    End Sub

#End Region

#Region "�޸�"

    Private Sub BtnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnEdit.Click, MnuiEdit.Click
        '�޸�
        Dim rcFrm As New FrmWbEdit
        With rcFrm
            .ParaAdding = False
            .ParaDataSet = rcDataset
            .ParaDataView = rcDataView
            .ParaCurrentPos = BindingContext(rcDataView, "").Position
            .ShowDialog()
        End With
        Me.rcDataGridView.Refresh()
    End Sub

#End Region

#Region "ɾ��"

    Private Sub BtnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, MnuiDelete.Click
        'ɾ��
        'ɾ������
        If MessageBox.Show("�����Ҫɾ����" & Trim(BindingContext(rcDataView, "").Current("wbdm")), "��ʾ��Ϣ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then
            currentPos = BindingContext(rcDataView, "").Position
            If Trim(BindingContext(rcDataView, "").Current("wbdm")) = "" Then
                MessageBox.Show("���벻��Ϊ�ա�")
                Return
            End If
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "DELETE FROM rc_wbxx WHERE wbdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.AddWithValue("@wbdm", BindingContext(rcDataView, "").Current("wbdm"))
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "SELECT wbdm,wbmc,wbsm,wbhl01,wbhl02,wbhl03,wbhl04,wbhl05,wbhl06,wbhl07,wbhl08,wbhl09,wbhl10,wbhl11,wbhl12,ywftzbl FROM rc_wbxx WHERE kjnd = ? ORDER BY wbdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_wbxx") IsNot Nothing Then
                    rcDataset.Tables("rc_wbxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_wbxx")
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Catch ey As OleDbException
                    MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            BindingContext(rcDataView, "").Position = currentPos
        End If

    End Sub

#End Region

#Region "ˢ��"

    Private Sub BtnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRefresh.Click, MnuiRefresh.Click
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT wbdm,wbmc,wbsm,wbhl01,wbhl02,wbhl03,wbhl04,wbhl05,wbhl06,wbhl07,wbhl08,wbhl09,wbhl10,wbhl11,wbhl12,ywftzbl FROM rc_wbxx WHERE kjnd = ? ORDER BY wbdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_wbxx") IsNot Nothing Then
                rcDataset.Tables("rc_wbxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_wbxx")
        Catch ex As Exception
            MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
    End Sub

#End Region

#Region "�ر�"

    Private Sub BtnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExit.Click, MnuiExit.Click
        '�ر�
        Me.Close()
    End Sub

#End Region

#Region "����"

    Private Sub MnuiAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuiAbout.Click
        Dim rcFrm As New FrmAbout
        With rcFrm
            .ShowDialog()
        End With
    End Sub

#End Region


End Class