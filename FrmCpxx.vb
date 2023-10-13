Imports System.Data.OleDb

Public Class FrmCpxx

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
    ReadOnly dtCp As New DataTable("rc_cpxx")
    '��ӡ�ĵ�
    Dim rcRps As RPS.Document = Nothing
    '����󶨵���ͬ����Դ�����ݳ�Ա������Binding����
    'Dim rcBmb As BindingManagerBase
    '��ǰ��¼��
    Dim currentPos As Integer

#End Region

#Region "��ʼ��"

    Private Sub FrmCpxx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.rcDataGridView.AutoGenerateColumns = False
        Me.rcDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.rcDataGridView.Columns("ColMjsl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColMjsl").DefaultCellStyle.Format = g_FormatSl0
        Me.rcDataGridView.Columns("ColXsdj").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColXsdj").DefaultCellStyle.Format = g_FormatDj0
        Me.rcDataGridView.Columns("ColCgdj").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColCgdj").DefaultCellStyle.Format = g_FormatDj0
        Me.rcDataGridView.Columns("ColBzcb").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColBzcb").DefaultCellStyle.Format = g_FormatDj0
        Me.rcDataGridView.Columns("ColClcb").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColClcb").DefaultCellStyle.Format = g_FormatJe0
        Me.rcDataGridView.Columns("ColRgcb").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColRgcb").DefaultCellStyle.Format = g_FormatJe0
        Me.rcDataGridView.Columns("ColGlcb").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColGlcb").DefaultCellStyle.Format = g_FormatJe0
        Me.rcDataGridView.Columns("ColXstcbl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColXstcbl").DefaultCellStyle.Format = g_FormatJe0
        Me.rcDataGridView.Columns("ColZdcb").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColZdcb").DefaultCellStyle.Format = g_FormatSl0
        Me.rcDataGridView.Columns("ColZgcb").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColZgcb").DefaultCellStyle.Format = g_FormatSl0
        Me.rcDataGridView.Columns("ColCgts").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColCgts").DefaultCellStyle.Format = g_FormatSl0
        Me.rcDataGridView.Columns("ColCpWeight").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColCpWeight").DefaultCellStyle.Format = g_FormatSl0
        Me.rcDataGridView.Columns("ColLength").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColLength").DefaultCellStyle.Format = g_FormatJe0
        Me.rcDataGridView.Columns("ColWidth").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColWidth").DefaultCellStyle.Format = g_FormatJe0
        Me.rcDataGridView.Columns("ColHeight").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColHeight").DefaultCellStyle.Format = g_FormatJe0

        '���ݰ�
        dtCp.Columns.Add("lbdm", Type.GetType("System.String"))
        dtCp.Columns.Add("lbmc", Type.GetType("System.String"))
        dtCp.Columns.Add("cpdm", Type.GetType("System.String"))
        dtCp.Columns.Add("cpmc", Type.GetType("System.String"))
        dtCp.Columns.Add("dw", Type.GetType("System.String"))
        dtCp.Columns.Add("ckdm", Type.GetType("System.String"))
        dtCp.Columns.Add("ckmc", Type.GetType("System.String"))
        dtCp.Columns.Add("hsfl", Type.GetType("System.String"))
        dtCp.Columns.Add("mjsl", Type.GetType("System.Double"))
        dtCp.Columns.Add("fzdw", Type.GetType("System.String"))
        dtCp.Columns.Add("cpsm", Type.GetType("System.String"))
        dtCp.Columns.Add("kuwei", Type.GetType("System.String"))
        dtCp.Columns.Add("oldcpdm", Type.GetType("System.String"))
        dtCp.Columns.Add("khdm", Type.GetType("System.String"))
        dtCp.Columns.Add("khmc", Type.GetType("System.String"))
        dtCp.Columns.Add("xsdj", Type.GetType("System.Double"))
        dtCp.Columns.Add("cgdj", Type.GetType("System.Double"))
        dtCp.Columns.Add("beishu", Type.GetType("System.Int32"))
        dtCp.Columns.Add("bzcb", Type.GetType("System.Double"))
        dtCp.Columns.Add("clcb", Type.GetType("System.Double"))
        dtCp.Columns.Add("rgcb", Type.GetType("System.Double"))
        dtCp.Columns.Add("glcb", Type.GetType("System.Double"))
        dtCp.Columns.Add("xstcbl", Type.GetType("System.Double"))
        dtCp.Columns.Add("zdcb", Type.GetType("System.Double"))
        dtCp.Columns.Add("zgcb", Type.GetType("System.Double"))
        dtCp.Columns.Add("cgts", Type.GetType("System.Double"))
        dtCp.Columns.Add("cpweight", Type.GetType("System.Double"))
        dtCp.Columns.Add("length", Type.GetType("System.Double"))
        dtCp.Columns.Add("width", Type.GetType("System.Double"))
        dtCp.Columns.Add("height", Type.GetType("System.Double"))
        dtCp.Columns.Add("brecycling", Type.GetType("System.Boolean"))
        dtCp.Columns.Add("bfadm", Type.GetType("System.Boolean"))
        dtCp.Columns.Add("bbatch", Type.GetType("System.Boolean"))
        dtCp.Columns.Add("srr", Type.GetType("System.String"))
        dtCp.Columns.Add("srrq", Type.GetType("System.DateTime"))
        rcDataset.Tables.Add(dtCp)
        With dtCp
            .Columns("lbdm").DefaultValue = ""
            .Columns("lbmc").DefaultValue = ""
            .Columns("cpdm").DefaultValue = ""
            .Columns("cpmc").DefaultValue = ""
            .Columns("dw").DefaultValue = ""
            .Columns("ckdm").DefaultValue = ""
            .Columns("ckmc").DefaultValue = ""
            .Columns("hsfl").DefaultValue = ""
            .Columns("mjsl").DefaultValue = 0.0
            .Columns("fzdw").DefaultValue = ""
            .Columns("cpsm").DefaultValue = ""
            .Columns("kuwei").DefaultValue = ""
            .Columns("oldcpdm").DefaultValue = ""
            .Columns("khdm").DefaultValue = ""
            .Columns("khmc").DefaultValue = ""
            .Columns("xsdj").DefaultValue = 0.0
            .Columns("cgdj").DefaultValue = 0.0
            .Columns("beishu").DefaultValue = 0
            .Columns("bzcb").DefaultValue = 0.0
            .Columns("clcb").DefaultValue = 0.0
            .Columns("rgcb").DefaultValue = 0.0
            .Columns("glcb").DefaultValue = 0.0
            .Columns("xstcbl").DefaultValue = 0.0
            .Columns("zdcb").DefaultValue = 0.0
            .Columns("zgcb").DefaultValue = 0.0
            .Columns("cgts").DefaultValue = 0.0
            .Columns("cpweight").DefaultValue = 0.0
            .Columns("length").DefaultValue = 0.0
            .Columns("width").DefaultValue = 0.0
            .Columns("height").DefaultValue = 0.0
            .Columns("brecycling").DefaultValue = False
            .Columns("bfadm").DefaultValue = False
            .Columns("bbatch").DefaultValue = False
            .Columns("srr").DefaultValue = ""
        End With
        '��ʾ�ȴ���ʽ���
        Cursor.Current = New Cursor(Application.StartupPath & "\" & "Wait.cur")
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT rc_cpxx.lbdm,rc_cplb.lbmc,rc_cpxx.cpdm,rc_cpxx.cpmc,rc_cpxx.dw,rc_cpxx.ckdm,rc_ckxx.ckmc,rc_cpxx.hsfl,rc_cpxx.mjsl,rc_cpxx.fzdw,rc_cpxx.cpsm,rc_cpxx.kuwei,rc_cpxx.oldcpdm,rc_cpxx.khdm,rc_khxx.khmc,rc_cpxx.xsdj,rc_cpxx.cgdj,rc_cpxx.beishu,rc_cpxx.bzcb,rc_cpxx.clcb,rc_cpxx.rgcb,rc_cpxx.glcb,rc_cpxx.xstcbl,rc_cpxx.zdcb,rc_cpxx.zgcb,rc_cpxx.cgts,rc_cpxx.cpweight,rc_cpxx.length,rc_cpxx.width,rc_cpxx.height,rc_cpxx.brecycling,rc_cpxx.bfadm,rc_cpxx.bbatch,rc_cpxx.srr,rc_cpxx.srrq FROM rc_cpxx Left Join rc_cplb On rc_cpxx.lbdm = rc_cplb.lbdm Left Join rc_khxx On rc_cpxx.khdm = rc_khxx.khdm LEFT JOIN rc_ckxx ON rc_cpxx.ckdm = rc_ckxx.ckdm ORDER BY cpdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                rcDataset.Tables("rc_cpxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        rcDataView = New DataView(rcDataset.Tables("rc_cpxx"))
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
            .paraRpsId = "CPXX"
            .paraRpsName = "��Ʒ��Ϣ"
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
            MsgBox("�Բ�������������ܴ�ӡ��", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
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
        'Dim rft1 As String = CurDir() + "\reports\cpxx.csv"
        Dim rft As String = CurDir() + "\reports\cpxx.rft"
        If rcRps Is Nothing Then
            rcRps = New RPS.Document
        End If
        'rcRps.LoadCsvTemplate(rft1)
        'rcRps.SaveTemplate(rft)
        rcRps.LoadTemplate(rft)
        rcRps.Text(-1, 2) = "��λ��" + g_Dwmc
        rcRps.Text(-1, 4) = "��ӡ�ˣ�" + g_User_DspName
        Dim i As Integer
        For i = 0 To rcDataset.Tables("rc_cpxx").Rows.Count - 1
            rcRps.Text(i + 1, 1) = Trim(rcDataset.Tables("rc_cpxx").Rows(i).Item("lbdm"))
            rcRps.Text(i + 1, 2) = Trim(rcDataset.Tables("rc_cpxx").Rows(i).Item("lbmc"))
            rcRps.Text(i + 1, 3) = Trim(rcDataset.Tables("rc_cpxx").Rows(i).Item("cpdm"))
            rcRps.Text(i + 1, 4) = Trim(rcDataset.Tables("rc_cpxx").Rows(i).Item("cpmc"))
            rcRps.Text(i + 1, 7) = Trim(rcDataset.Tables("rc_cpxx").Rows(i).Item("dw"))
            rcRps.Text(i + 1, 8) = Trim(rcDataset.Tables("rc_cpxx").Rows(i).Item("mjsl"))
            rcRps.Text(i + 1, 9) = Trim(rcDataset.Tables("rc_cpxx").Rows(i).Item("fzdw"))
            rcRps.Text(i + 1, 10) = Trim(rcDataset.Tables("rc_cpxx").Rows(i).Item("cpsm"))
            rcRps.Text(i + 1, 11) = Trim(rcDataset.Tables("rc_cpxx").Rows(i).Item("khdm"))
            rcRps.Text(i + 1, 12) = Trim(rcDataset.Tables("rc_cpxx").Rows(i).Item("khmc"))
            rcRps.Text(i + 1, 13) = Trim(rcDataset.Tables("rc_cpxx").Rows(i).Item("xsdj"))
            rcRps.Text(i + 1, 14) = Trim(rcDataset.Tables("rc_cpxx").Rows(i).Item("cgdj"))
            rcRps.Text(i + 1, 15) = Trim(rcDataset.Tables("rc_cpxx").Rows(i).Item("bzcb"))
            rcRps.Text(i + 1, 16) = Trim(rcDataset.Tables("rc_cpxx").Rows(i).Item("clcb"))
            rcRps.Text(i + 1, 17) = Trim(rcDataset.Tables("rc_cpxx").Rows(i).Item("rgcb"))
            rcRps.Text(i + 1, 18) = Trim(rcDataset.Tables("rc_cpxx").Rows(i).Item("glcb"))
            rcRps.Text(i + 1, 19) = Trim(rcDataset.Tables("rc_cpxx").Rows(i).Item("xstcbl"))
            rcRps.Text(i + 1, 20) = Trim(rcDataset.Tables("rc_cpxx").Rows(i).Item("cpweight"))
            rcRps.Text(i + 1, 21) = Trim(rcDataset.Tables("rc_cpxx").Rows(i).Item("length"))
            rcRps.Text(i + 1, 22) = Trim(rcDataset.Tables("rc_cpxx").Rows(i).Item("width"))
            rcRps.Text(i + 1, 23) = Trim(rcDataset.Tables("rc_cpxx").Rows(i).Item("height"))
        Next
        'ȡRPS����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps WHERE rpsid = 'CPXX'"
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
        Exports2Excel(rcDataset.Tables("rc_cpxx").DefaultView)
    End Sub
    'Private Sub Exports2Excel()
    '    Dim oXLApp As New Microsoft.Office.Interop.Excel.Application()
    '    Dim oXLBook As Microsoft.Office.Interop.Excel.Workbook = oXLApp.Workbooks.Add()
    '    Dim oXLSheet As Microsoft.Office.Interop.Excel.Worksheet = oXLBook.Worksheets("Sheet1") 'Work with the first worksheet

    '    Dim cn As New OdbcConnection(strCon)
    '    cn.Open()

    '    Dim strSql As String = "SELECT * from products "

    '    Dim cmd As New OdbcCommand(strSql, cn)
    '    Dim dr As OdbcDataReader = cmd.ExecuteReader

    '    With oXLSheet
    '        .Columns("A:A").ColumnWidth = 22.25
    '        While dr.Read
    '            .Rows(intRow.ToString() + ":" + intRow.ToString()).RowHeight = 102
    '            .Range("B" + (intRow).ToString() + ":B" + (intRow).ToString()).Value = dr("products_model")
    '            .Range("C" + (intRow).ToString() + ":C" + (intRow).ToString()).Value = dr("products_image")

    '            .Range("A" + (intRow).ToString() + ":A" + (intRow).ToString()).SELECT()

    '            .Pictures.Insert(dr("products_image")).SELECT()

    '            intRow += 1
    '        End While
    '    End With

    '    oXLApp.Visible = True 'Show it to the user
    'End Sub

    Private Sub Exports2Excel(ByVal ParaDataView As DataView)
        If ParaDataView.Count > 0 Then
            Try
                Dim rcExcelApp As New Microsoft.Office.Interop.Excel.Application
                Dim rcExcelWorkbook As Microsoft.Office.Interop.Excel.Workbook
                Dim rcExcelWorksheet As Microsoft.Office.Interop.Excel.Worksheet
                Dim rowIndex, colIndex As Integer
                rowIndex = 1
                colIndex = 0
                rcExcelWorkbook = rcExcelApp.Workbooks().Add
                rcExcelWorksheet = rcExcelWorkbook.Worksheets("sheet1")

                '�����õ��ı������,��ֵ����Ԫ��
                Dim i As Integer
                Dim rcDataColumn As DataColumn
                Dim rcDataRowView As DataRowView

                rcExcelApp.Visible = True

                For Each rcDataColumn In ParaDataView.Table.Columns
                    colIndex += 1
                    rcExcelApp.Cells(1, colIndex) = rcDataColumn.ColumnName
                Next
                '�õ��ı�������,��ֵ����Ԫ��
                For i = 0 To ParaDataView.Count - 1
                    rcDataRowView = rcDataView.Item(i)
                    If rcDataRowView.Row.RowState <> DataRowState.Deleted Then
                        rowIndex += 1
                        colIndex = 0
                        For Each rcDataColumn In ParaDataView.Table.Columns
                            colIndex += 1
                            Select Case True
                                Case rcDataView.Item(i).Row.Item(rcDataColumn.ColumnName).GetType.ToString = "System.String"
                                    rcExcelApp.Cells(rowIndex, colIndex) = "'" & Trim(rcDataView.Item(i).Row.Item(rcDataColumn.ColumnName))
                                Case rcDataView.Item(i).Row.Item(rcDataColumn.ColumnName).GetType.ToString = "System.Byte[]"
                                    '�����и�
                                    rcExcelWorksheet.Rows().RowHeight = 100
                                    '�����п�
                                    rcExcelWorksheet.Columns().ColumnWidth = 16
                                    '
                                    Dim s As String
                                    s = Application.StartupPath & "\tmptoexcel.jpg"
                                    If IO.File.Exists(s) Then
                                        IO.File.Delete(s)
                                    End If
                                    Dim size() As Byte = rcDataView.Item(i).Row.Item(rcDataColumn.ColumnName)
                                    Dim fs As IO.FileStream
                                    fs = New IO.FileStream(s, IO.FileMode.CreateNew)
                                    fs.Write(size, 0, size.Length - 0)
                                    fs.Close()

                                    'Dim im As Image = Image.FromFile("D:\Pictures\4.jpg")   '���Image
                                    'System.Windows.Forms.Clipboard.SetDataObject(im, True)  '���Ƶ�������
                                    Dim range As Microsoft.Office.Interop.Excel.Range = rcExcelWorksheet.Range(rcExcelApp.Cells(rowIndex, colIndex), rcExcelApp.Cells(rowIndex, colIndex))  'ճ��ͼƬ��λ��
                                    range.Select()
                                    'rcExcelWorksheet.Paste(range, im)  '��ͼƬ����Exce
                                    rcExcelApp.ActiveSheet.Pictures.Insert(s).SELECT()
                                Case Else
                                    rcExcelApp.Cells(rowIndex, colIndex) = rcDataView.Item(i).Row.Item(rcDataColumn.ColumnName)

                            End Select
                        Next
                    End If
                Next
                For Each pic As Microsoft.Office.Interop.Excel.Shape In rcExcelApp.ActiveSheet.Shapes
                    pic.Height = 100
                Next
                ''���ô�ӡ��ʾ��ʽ
                'With rcExcelWorksheet
                '    .Range(.cell(1, 1), .cell(1, colIndex)).borderstyle.font = True '����Ӵ�
                '    .Range(.cell(1, 1), .cell(1, colIndex)).borderstyle.color = RGB(125, 25, 27)
                '    .Range(.cell(1, 1), .cell(rowIndex, colIndex)).borderstyle.linestyle = 1 '���ñ߿���ʽ
                'End With
                'rcExcelApp.close()
            Catch ex As Exception
                MessageBox.Show("���ݵ���ʧ�ܣ���鿴�Ƿ��Ѿ���װ��Excel��", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        Else
            MessageBox.Show("û�����ݣ�", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    'Public Sub Exports2Excel(ByVal paraDataTable As DataTable)
    '    If paraDataTable.Rows.Count > 0 Then
    '        Try
    '            Me.Cursor = Cursors.WaitCursor
    '            Dim i, j As Integer
    '            Dim DataArray(paraDataTable.Rows.Count() - 1, paraDataTable.Columns.Count() - 1) As String
    '            Dim myExcel As New Microsoft.Office.Interop.Excel.Application
    '            For i = 0 To paraDataTable.Rows.Count() - 1
    '                For j = 0 To paraDataTable.Columns.Count() - 1
    '                    'If paraDataTable.Rows(i).Item(j).GetType.ToString <> "System.DBNull" Then
    '                    '    DataArray(i, j) = paraDataTable.Rows(i).Item(j)
    '                    'Else
    '                    '    DataArray(i, j) = ""
    '                    'End If
    '                    SELECT Case True
    '                        Case paraDataTable.Rows(i).Item(j).GetType.ToString = "System.String"
    '                            DataArray(i, j) = "'" & Trim(paraDataTable.Rows(i).Item(j))
    '                        Case paraDataTable.Rows(i).Item(j).GetType.ToString = "System.Byte[]"
    '                            'DataArray(i, j).SELECT()
    '                            'myExcel.Pictures.Insert("D:\Pictures\4.jpg")
    '                        Case Else
    '                            DataArray(i, j) = ""
    '                    End SELECT
    '                Next
    '            Next
    '            myExcel.Application.Workbooks.Add(True)
    '            myExcel.Visible = True
    '            For j = 0 To paraDataTable.Columns.Count() - 1
    '                myExcel.Cells(1, j + 1) = paraDataTable.Columns(j).ColumnName
    '            Next
    '            myExcel.Range("A2").Resize(paraDataTable.Rows.Count, paraDataTable.Columns.Count).Value = DataArray
    '        Catch exp As Exception
    '            MessageBox.Show("���ݵ���ʧ�ܣ���鿴�Ƿ��Ѿ���װ��Excel��", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Finally
    '            Me.Cursor = Cursors.Default
    '        End Try
    '    Else
    '        MessageBox.Show("û�����ݣ�", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End If
    'End Sub

#End Region

#Region "����"

    Private Sub BtnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNew.Click, MnuiNew.Click
        '����
        Dim rcFrm As New FrmCpEdit
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
        Dim rcFrm As New FrmCpEdit
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
        Dim i As Integer
        'ɾ������
        If MessageBox.Show("�����Ҫɾ����" & Trim(BindingContext(rcDataView, "").Current("cpdm")), "��ʾ��Ϣ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then
            currentPos = BindingContext(rcDataView, "").Position
            If Trim(BindingContext(rcDataView, "").Current("cpdm")) = "" Then
                MessageBox.Show("���벻��Ϊ�ա�")
                Return
            End If
            '���ʹ��״̬
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM inv_cpyeb WHERE cpdm = ? AND (qcsl <> 0 OR qcje <> 0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = BindingContext(rcDataView, "").Current("cpdm")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("inv_cpyeb") IsNot Nothing Then
                    rcDataset.Tables("inv_cpyeb").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "inv_cpyeb")
                If rcDataset.Tables("inv_cpyeb").Rows.Count > 0 Then
                    If rcDataset.Tables("inv_cpyeb").Rows(0).Item("qcsl") <> 0 Or rcDataset.Tables("inv_cpyeb").Rows(0).Item("qcje") <> 0 Then
                        MsgBox("�ñ������ڳ�������ɾ����", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                        Return
                    End If
                End If
                'ȡ��cpdm�ֶεı�
                rcOleDbCommand.CommandText = "SELECT table_name,column_name FROM user_tab_columns WHERE column_name = 'CPDM' AND table_name <> 'INV_CPYEB' AND table_name <> 'RC_CPXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                '
                For i = 0 To rcDataset.Tables("user_tab_columns").Rows.Count - 1
                    rcOleDbCommand.CommandText = "SELECT Count(*) As cpcnt FROM " & rcDataset.Tables("user_tab_columns").Rows(i).Item("table_name") & " WHERE cpdm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = BindingContext(rcDataView, "").Current("cpdm")
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("cpcnt") IsNot Nothing Then
                        rcDataset.Tables("cpcnt").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "cpcnt")
                    If rcDataset.Tables("cpcnt").Rows.Count > 0 Then
                        If rcDataset.Tables("cpcnt").Rows(0).Item("cpcnt") > 0 Then
                            MsgBox("�ñ����ڱ�" & rcDataset.Tables("user_tab_columns").Rows(i).Item("table_name") & "��ҵ����������ɾ����", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                            Return
                        End If
                    End If
                Next
            Catch ex As Exception
                MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "Delete FROM rc_cpxx WHERE cpdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = BindingContext(rcDataView, "").Current("cpdm")
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "Delete FROM inv_cpyeb WHERE cpdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = BindingContext(rcDataView, "").Current("cpdm")
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "SELECT rc_cpxx.lbdm,rc_cplb.lbmc,rc_cpxx.cpdm,rc_cpxx.cpmc,rc_cpxx.dw,rc_cpxx.ckdm,rc_ckxx.ckmc,rc_cpxx.hsfl,rc_cpxx.mjsl,rc_cpxx.fzdw,rc_cpxx.cpsm,rc_cpxx.kuwei,rc_cpxx.oldcpdm,rc_cpxx.khdm,rc_khxx.khmc,rc_cpxx.xsdj,rc_cpxx.cgdj,rc_cpxx.beishu,rc_cpxx.bzcb,rc_cpxx.clcb,rc_cpxx.rgcb,rc_cpxx.glcb,rc_cpxx.xstcbl,rc_cpxx.zdcb,rc_cpxx.zgcb,rc_cpxx.cgts,rc_cpxx.cpweight,rc_cpxx.length,rc_cpxx.width,rc_cpxx.height,rc_cpxx.brecycling,rc_cpxx.bfadm,rc_cpxx.bbatch,rc_cpxx.srr,rc_cpxx.srrq FROM rc_cpxx Left Join rc_cplb On rc_cpxx.lbdm = rc_cplb.lbdm Left Join rc_khxx On rc_cpxx.khdm = rc_khxx.khdm LEFT JOIN rc_ckxx ON rc_cpxx.ckdm = rc_ckxx.ckdm ORDER BY cpdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                    rcDataset.Tables("rc_cpxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
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

#Region "����"

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiSearch.Click, BtnSearch.Click
        '����
        Dim rcFrm As New FrmCpFilter
        With rcFrm
            '.ParaCurrentPos = rcBmb.Position
            .ParaDataView = rcDataView
            .ShowDialog()
        End With
        Me.rcDataGridView.Refresh()

    End Sub

#End Region

#Region "ˢ��"

    Private Sub BtnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRefresh.Click, MnuiRefresh.Click
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT rc_cpxx.lbdm,rc_cplb.lbmc,rc_cpxx.cpdm,rc_cpxx.cpmc,rc_cpxx.dw,rc_cpxx.ckdm,rc_ckxx.ckmc,rc_cpxx.hsfl,rc_cpxx.mjsl,rc_cpxx.fzdw,rc_cpxx.cpsm,rc_cpxx.kuwei,rc_cpxx.oldcpdm,rc_cpxx.khdm,rc_khxx.khmc,rc_cpxx.xsdj,rc_cpxx.cgdj,rc_cpxx.beishu,rc_cpxx.bzcb,rc_cpxx.clcb,rc_cpxx.rgcb,rc_cpxx.glcb,rc_cpxx.xstcbl,rc_cpxx.zdcb,rc_cpxx.zgcb,rc_cpxx.cgts,rc_cpxx.cpweight,rc_cpxx.length,rc_cpxx.width,rc_cpxx.height,rc_cpxx.brecycling,rc_cpxx.bfadm,rc_cpxx.bbatch,rc_cpxx.srr,rc_cpxx.srrq FROM rc_cpxx Left Join rc_cplb On rc_cpxx.lbdm = rc_cplb.lbdm Left Join rc_khxx On rc_cpxx.khdm = rc_khxx.khdm LEFT JOIN rc_ckxx ON rc_cpxx.ckdm = rc_ckxx.ckdm ORDER BY cpdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                rcDataset.Tables("rc_cpxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
        Catch ex As Exception
            MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
    End Sub

#End Region

#Region "����excel"

    Private Sub BtnImpXls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiImpXls.Click
        '���ñ�
        Dim rcFrm As New FrmCpImpXls
        With rcFrm
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
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