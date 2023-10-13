Imports System.Math
Imports System.Data.OleDb

Public Class FrmPoCgdCxz
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    Dim rcDataset As New DataSet
    '��ʾҪ������Դִ�е� SQL ����
    ReadOnly rcOleDbTrans As OleDbTransaction
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '���ݰ�
    Dim rcBmb As BindingManagerBase
    '��ӡ�ĵ�
    Dim rcRps As RPS.Document = Nothing
    '�ϼƱ���
    Dim dblTotSl As Double = 0.0
    Dim dblTotFzsl As Double = 0.0
    Dim dblTotJe As Double = 0.0

#Region "�����ʼ��"

    Public Property ParaDataSet() As DataSet
        Get
            ParaDataSet = rcDataSet
        End Get
        Set(ByVal Value As DataSet)
            rcDataSet = Value
        End Set
    End Property

    Private Sub FrmCgdSrz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '����DataGridView
        Me.rcDataGridView.AutoGenerateColumns = False
        Me.rcDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColMjsl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColMjsl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColFzsl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColFzsl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColDj").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColDj").DefaultCellStyle.Format = g_FormatDj
        Me.rcDataGridView.Columns("ColHsdj").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColHsdj").DefaultCellStyle.Format = g_FormatDj
        Me.rcDataGridView.Columns("ColJe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColJe").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColShlv").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColShlv").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColSe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColSe").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColJese").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColJese").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColRksl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColRksl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColRkje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColRkje").DefaultCellStyle.Format = g_FormatJe
        rcBmb = Me.BindingContext(rcDataSet, "ckdml")
        If rcDataSet.Tables("ckdml").Rows.Count > 0 Then
            ShowCkd(rcDataSet.Tables("ckdml").Rows(0).Item("djh"))
        End If
    End Sub

#End Region

#Region "��ʾ��ⵥ"

    Private Sub ShowCkd(ByVal ckDjh As String)
        '�ж�ckDjh

        'ȡpo_cgd����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT po_cgd.djh,po_cgd.cgrq,po_cgd.sgddh,po_cgd.csdm,po_cgd.csmc,po_cgd.srr,po_cgd.shr FROM po_cgd WHERE (po_cgd.djh = ? )"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = ckDjh
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_cgdml") IsNot Nothing Then
                rcDataSet.Tables("rc_cgdml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_cgdml")
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '��ֵ
        Me.TxtDjh.Text = rcDataSet.Tables("rc_cgdml").Rows(0).Item("djh")
        Me.DtpCgrq.Value = rcDataSet.Tables("rc_cgdml").Rows(0).Item("cgrq")
        If rcDataSet.Tables("rc_cgdml").Rows(0).Item("sgddh").GetType.ToString <> "System.DBNull" Then
            Me.TxtSgddh.Text = rcDataSet.Tables("rc_cgdml").Rows(0).Item("sgddh")
        Else
            Me.TxtSgddh.Text = ""
        End If
        If rcDataSet.Tables("rc_cgdml").Rows(0).Item("csdm").GetType.ToString <> "System.DBNull" Then
            Me.TxtCsdm.Text = Trim(rcDataSet.Tables("rc_cgdml").Rows(0).Item("csdm"))
        Else
            Me.TxtCsdm.Text = ""
        End If
        If rcDataSet.Tables("rc_cgdml").Rows(0).Item("csmc").GetType.ToString <> "System.DBNull" Then
            Me.LblCsmc.Text = rcDataSet.Tables("rc_cgdml").Rows(0).Item("csmc")
        Else
            Me.LblCsmc.Text = ""
        End If
        Me.LblSrr.Text = "���룺" + rcDataSet.Tables("rc_cgdml").Rows(0).Item("srr")
        Me.LblShr.Text = "��ˣ�" + rcDataSet.Tables("rc_cgdml").Rows(0).Item("shr")
        'ȡpo_cgd����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT po_cgd.cpdm,rc_cpxx.cpmc,rc_cpxx.oldcpdm,po_cgd.csdm,po_cgd.csmc,po_cgd.jhshrq,po_cgd.sl,po_cgd.dw,po_cgd.mjsl,po_cgd.fzsl,po_cgd.fzdw,po_cgd.dj,po_cgd.hsdj,po_cgd.je,po_cgd.shlv,po_cgd.se,(po_cgd.je+po_cgd.se) AS jese,po_cgd.cgmemo,po_cgd.cgjhdjh,po_cgd.cgjhxh,po_cgd.rksl,po_cgd.rkje FROM po_cgd,rc_cpxx WHERE po_cgd.cpdm = rc_cpxx.cpdm AND po_cgd.djh = ? ORDER BY po_cgd.xh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = ckDjh
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_cgdnr") IsNot Nothing Then
                rcDataSet.Tables("rc_cgdnr").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_cgdnr")
            rcDataGridView.DataSource = rcDataSet.Tables("rc_cgdnr")
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        SumSlJe()
    End Sub

#End Region

#Region "����ϼ���"

    Private Sub SumSlJe()
        '����ϼ���
        dblTotSl = 0.0
        dblTotFzsl = 0.0
        dblTotJe = 0.0
        If rcDataSet.Tables("rc_cgdnr").Rows.Count > 0 Then
            dblTotSl = rcDataSet.Tables("rc_cgdnr").Compute("Sum(sl)", "")
            dblTotFzsl = rcDataSet.Tables("rc_cgdnr").Compute("Sum(fzsl)", "")
            dblTotJe = rcDataSet.Tables("rc_cgdnr").Compute("Sum(je)", "")
        End If
        Me.LblSl.Text = "�����ϼƣ�" + Format(dblTotSl, g_FormatSl)
        Me.LblFzsl.Text = "�������ϼƣ�" + Format(dblTotFzsl, g_FormatSl)
        Me.LblJe.Text = "���ϼƣ�" + Format(dblTotJe, g_FormatJe)
    End Sub

#End Region

#Region "����"

    Private Sub BtnTop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTop.Click, MnuiTop.Click
        If rcBmb.Count > 0 Then
            rcBmb.Position = 0
            ShowCkd(rcBmb.Current("djh"))
        End If
    End Sub

#End Region

#Region "����"

    Private Sub BtnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevious.Click, MnuiPrevious.Click
        If rcBmb.Count > 0 Then
            If rcBmb.Position <> 0 Then
                rcBmb.Position -= 1
            End If
            ShowCkd(rcBmb.Current("djh"))
        End If
    End Sub

#End Region

#Region "����"

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click, MnuiNext.Click
        If rcBmb.Count > 0 Then
            If rcBmb.Position <> rcBmb.Count Then
                rcBmb.Position += 1
            End If
            ShowCkd(rcBmb.Current("djh"))
        End If
    End Sub

#End Region

#Region "ĩ��"

    Private Sub BtnBottom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBottom.Click, MnuiBottom.Click
        If rcBmb.Count > 0 Then
            rcBmb.Position = rcBmb.Count - 1
            ShowCkd(rcBmb.Current("djh"))
        End If
    End Sub

#End Region

#Region "��ӡ����"

    Private Sub MnuiPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PageSetupEvent()
    End Sub

    Private Sub PageSetupEvent()
        Dim rcFrmPageSetup As New models.FrmPageSetup
        With rcFrmPageSetup
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = "CKDBZ"
            .paraRpsName = "��ⵥ��׼��ʽ"
            .ShowDialog()
        End With
    End Sub

#End Region

#Region "��ӡ/��ӡԤ��"

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click, MnuiPrint.Click
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

    Private Sub MnuiPrintView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrintView.Click
        PrintViewEvent()
    End Sub

    Private Sub PrintViewEvent()
        PreparePrintData()
        rcRps.Preview()
    End Sub

#End Region

#Region "׼����ӡ�����¼�"

    Private Sub PreparePrintData()
        If rcRps Is Nothing Then
            rcRps = New RPS.Document
        End If
        Dim rft As String = CurDir() + "\reports\cgdbz.rft"
        rcRps.LoadTemplate(rft)
        'ȡRPS����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps WHERE rpsid = 'CGDBZ'"
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

        rcRps.Text(-1, 1) = g_PrnDwmc & "�ɹ���"
        rcRps.Text(-1, 2) = g_PrnDwmc_EN
        rcRps.Text(-1, 5) = "�� �� �ţ�" & Trim(Me.TxtDjh.Text) & "  %p/%t"
        rcRps.Text(-1, 6) = "��    �ڣ�" & Me.DtpCgrq.Value.Date.ToLongDateString
        rcRps.Text(-1, 7) = "�� Ӧ �̣�(" & Trim(Me.TxtCsdm.Text) & ")" & Trim(LblCsmc.Text)
        rcRps.Text(-1, 8) = "������ţ�" & Me.TxtSgddh.Text
        Dim i As Integer
        Dim j As Integer
        Dim intPage As Integer
        Dim dblTotalJe As Double = 0.0
        Dim dblTotalSe As Double = 0.0
        For intPage = 1 To System.Math.Ceiling(rcDataSet.Tables("rc_cgdnr").Rows.Count / rcRps.LinesPerPage.ToString)
            For i = (intPage - 1) * rcRps.LinesPerPage.ToString To System.Math.Min(intPage * rcRps.LinesPerPage.ToString - 1, rcDataSet.Tables("rc_cgdnr").Rows.Count - 1)
                If rcDataSet.Tables("rc_cgdnr").Rows(i).RowState <> 8 Then
                    If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("cpdm").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 1) = Trim(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("cpdm"))
                    End If
                    If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("cpmc").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 2) = Trim(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("cpmc"))
                    End If
                    If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 3) = Trim(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("dw"))
                    End If
                    If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 4) = Format(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("sl"), g_FormatSl)
                    End If
                    If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("dj").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 5) = Format(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("dj"), g_FormatDj)
                    End If
                    If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("hsdj").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 6) = Format(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("hsdj"), g_FormatDj)
                    End If
                    If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("je").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 7) = Format(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("je"), g_FormatJe)
                        dblTotalJe += rcDataSet.Tables("rc_cgdnr").Rows(i).Item("je")
                    End If
                    If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("shlv").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 8) = Format(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("shlv") / 100, "0%")
                    End If
                    If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("se").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 9) = Format(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("se"), g_FormatJe)
                        dblTotalSe += rcDataSet.Tables("rc_cgdnr").Rows(i).Item("se")
                    End If
                    If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("jhshrq").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 10) = rcDataSet.Tables("rc_cgdnr").Rows(i).Item("jhshrq")
                    End If
                    If Not rcDataSet.Tables("rc_cgdnr").Rows(i).Item("cgmemo").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 11) = Trim(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("cgmemo"))
                    End If
                    j += 1
                End If
            Next
            If Decimal.op_Modulus(rcDataSet.Tables("rc_cgdnr").Rows.Count, rcRps.LinesPerPage.ToString) <> 0 Then
                For i = Decimal.op_Modulus(rcDataSet.Tables("rc_cgdnr").Rows.Count, rcRps.LinesPerPage.ToString) + 1 To rcRps.LinesPerPage.ToString
                    rcRps.Text(j + 1, 1) = ""
                    j += 1
                Next
            End If

            Dim m As New models.ChineseNum With {
                .InputString = dblTotalJe + dblTotalSe
            }
            rcRps.PerPageText(intPage, 12) = IIf(intPage = Math.Ceiling(rcDataSet.Tables("rc_cgdnr").Rows.Count / rcRps.LinesPerPage.ToString), "�ϼ�", "С��")
            rcRps.PerPageText(intPage, 13) = m.OutString & "   (Сд)" & Format(dblTotalJe + dblTotalSe, g_FormatJe) '��д
            rcRps.PerPageText(intPage, 14) = Format(dblTotalJe, g_FormatJe)
            rcRps.PerPageText(intPage, 16) = Format(dblTotalSe, g_FormatJe)
        Next
        'rcRps.Text(-1, 7) = "�����ˣ�" & g_User_DspName
    End Sub

#End Region

#Region "�˳�"

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiExit.Click, BtnExit.Click
        ExitEvent()
    End Sub

    Private Sub ExitEvent()
        Me.Close()
    End Sub

#End Region
End Class