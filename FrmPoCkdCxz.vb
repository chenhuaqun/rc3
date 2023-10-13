Imports System.Math
Imports System.Data.OleDb

Public Class FrmPoCkdCxz
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

    Private Sub FrmPoCkdSrz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Me.rcDataGridView.Columns("ColJe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColJe").DefaultCellStyle.Format = g_FormatJe

        rcBmb = Me.BindingContext(rcDataSet, "ckdml")
        If rcDataSet.Tables("ckdml").Rows.Count > 0 Then
            ShowCkd(rcDataSet.Tables("ckdml").Rows(0).Item("djh"))
        End If
    End Sub

#End Region

#Region "��ʾ��ⵥ"

    Private Sub ShowCkd(ByVal ckDjh As String)
        '�ж�ckDjh

        'ȡinv_ckd����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT inv_ckd.djh,inv_ckd.ckrq,inv_ckd.ckdm,inv_ckd.ckmc,inv_ckd.bmdm,inv_ckd.bmmc,inv_ckd.zydm,inv_ckd.zymc,inv_ckd.srr,inv_ckd.shr FROM inv_ckd WHERE (inv_ckd.djh = ? )"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = ckDjh
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_ckdml") IsNot Nothing Then
                rcDataSet.Tables("rc_ckdml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_ckdml")
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '��ֵ
        Me.TxtDjh.Text = rcDataSet.Tables("rc_ckdml").Rows(0).Item("djh")
        Me.DtpCkrq.Value = rcDataSet.Tables("rc_ckdml").Rows(0).Item("Ckrq")
        If rcDataSet.Tables("rc_ckdml").Rows(0).Item("ckdm").GetType.ToString <> "System.DBNull" Then
            Me.TxtCkdm.Text = rcDataSet.Tables("rc_ckdml").Rows(0).Item("ckdm")
        Else
            Me.TxtCkdm.Text = ""
        End If
        If rcDataSet.Tables("rc_ckdml").Rows(0).Item("ckmc").GetType.ToString <> "System.DBNull" Then
            Me.LblCkmc.Text = rcDataSet.Tables("rc_ckdml").Rows(0).Item("ckmc")
        Else
            Me.LblCkmc.Text = ""
        End If
        If rcDataSet.Tables("rc_ckdml").Rows(0).Item("bmdm").GetType.ToString <> "System.DBNull" Then
            Me.TxtBmdm.Text = rcDataSet.Tables("rc_ckdml").Rows(0).Item("bmdm")
        Else
            Me.TxtBmdm.Text = ""
        End If
        If rcDataSet.Tables("rc_ckdml").Rows(0).Item("bmmc").GetType.ToString <> "System.DBNull" Then
            Me.LblBmmc.Text = rcDataSet.Tables("rc_ckdml").Rows(0).Item("bmmc")
        Else
            Me.LblBmmc.Text = ""
        End If
        If rcDataSet.Tables("rc_ckdml").Rows(0).Item("zydm").GetType.ToString <> "System.DBNull" Then
            Me.TxtZydm.Text = rcDataSet.Tables("rc_ckdml").Rows(0).Item("zydm")
        Else
            Me.TxtZydm.Text = ""
        End If
        If rcDataSet.Tables("rc_ckdml").Rows(0).Item("zymc").GetType.ToString <> "System.DBNull" Then
            Me.LblZymc.Text = rcDataSet.Tables("rc_ckdml").Rows(0).Item("zymc")
        Else
            Me.LblZymc.Text = ""
        End If
        Me.LblSrr.Text = "���룺" + rcDataSet.Tables("rc_ckdml").Rows(0).Item("srr")
        Me.LblShr.Text = "��ˣ�" + rcDataSet.Tables("rc_ckdml").Rows(0).Item("shr")
        'ȡinv_ckd����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            'rcOleDbCommand.CommandText = "SELECT inv_ckd.cpdm,inv_ckd.cpmc,inv_ckd.csdm,inv_ckd.csmc,inv_ckd.brecycling,inv_ckd.bfadm,inv_ckd.fadm,inv_ckd.famc,inv_ckd.kuwei,inv_ckd.sl,inv_ckd.dw,inv_ckd.mjsl,inv_ckd.fzsl,inv_ckd.fzdw,inv_ckd.dj,inv_ckd.je,inv_ckd.ckmemo,inv_ckd.llsqdjh,inv_ckd.llsqxh FROM inv_ckd WHERE (inv_ckd.djh = ?) ORDER BY inv_ckd.xh"
            rcOleDbCommand.CommandText = "SELECT inv_ckd.cpdm,rc_cpxx.oldcpdm,rc_cpxx.cpmc,inv_ckd.csdm,inv_ckd.csmc,rc_cpxx.kuwei,rc_cpxx.brecycling,rc_cpxx.bfadm,inv_ckd.fadm,inv_ckd.famc,inv_ckd.sl,inv_ckd.dw,inv_ckd.mjsl,inv_ckd.fzsl,inv_ckd.fzdw,inv_ckd.dj,inv_ckd.je,inv_ckd.ckmemo,inv_ckd.llsqdjh,inv_ckd.llsqxh FROM inv_ckd,rc_cpxx WHERE inv_ckd.cpdm = rc_cpxx.cpdm AND (inv_ckd.djh = ?) ORDER BY inv_ckd.xh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = ckDjh
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_ckdnr") IsNot Nothing Then
                rcDataSet.Tables("rc_ckdnr").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_ckdnr")
            rcDataGridView.DataSource = rcDataSet.Tables("rc_ckdnr")
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
        If rcDataSet.Tables("rc_ckdnr").Rows.Count > 0 Then
            dblTotSl = rcDataSet.Tables("rc_ckdnr").Compute("Sum(sl)", "")
            dblTotFzsl = rcDataSet.Tables("rc_ckdnr").Compute("Sum(fzsl)", "")
            dblTotJe = rcDataSet.Tables("rc_ckdnr").Compute("Sum(je)", "")
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

#Region "׼����ӡ�����¼�"

    Private Sub PreparePrintData()
        If rcRps Is Nothing Then
            rcRps = New RPS.Document
        End If
        Dim rft As String = CurDir() + "\reports\pockdbz.rft"
        rcRps.LoadTemplate(rft)
        'ȡRPS����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps WHERE rpsid = 'POCKDBZ'"
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

        rcRps.Text(-1, 1) = g_PrnDwmc & "���ϳ��ⵥ"
        rcRps.Text(-1, 2) = "�ֿ⣺(" & Trim(Me.TxtCkdm.Text) & ")" & Trim(LblCkmc.Text)
        rcRps.Text(-1, 3) = "�����ˣ�(" & Trim(Me.TxtZydm.Text) & ")" & Trim(LblZymc.Text)
        rcRps.Text(-1, 4) = "���ݺţ�" & Trim(Me.TxtDjh.Text) & "  %p/%t"
        rcRps.Text(-1, 5) = "���ţ�(" & Trim(Me.TxtBmdm.Text) & ")" & Trim(LblBmmc.Text)
        rcRps.Text(-1, 6) = ""
        rcRps.Text(-1, 7) = "���ڣ�" & DtpCkrq.Value.Date.ToLongDateString
        Dim i As Integer
        Dim j As Integer
        Dim intPage As Integer
        Dim dblTotalSl As Double = 0.0
        Dim dblTotalFzsl As Double = 0.0
        For intPage = 1 To System.Math.Ceiling(rcDataSet.Tables("rc_ckdnr").Rows.Count / rcRps.LinesPerPage.ToString)
            For i = (intPage - 1) * rcRps.LinesPerPage.ToString To System.Math.Min(intPage * rcRps.LinesPerPage.ToString - 1, rcDataSet.Tables("rc_ckdnr").Rows.Count - 1)
                If rcDataSet.Tables("rc_ckdnr").Rows(i).RowState <> 8 Then
                    If Not rcDataSet.Tables("rc_ckdnr").Rows(i).Item("cpdm").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 1) = Trim(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("cpdm"))
                    End If
                    If Not rcDataSet.Tables("rc_ckdnr").Rows(i).Item("cpmc").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 2) = Trim(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("cpmc"))
                    End If
                    'If Not rcDataSet.Tables("rc_ckdnr").Rows(i).Item("scph").GetType.ToString = "System.DBNull" Then
                    '    rcRps.Text(j + 1, 3) = Trim(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("scph"))
                    'End If
                    If Not rcDataSet.Tables("rc_ckdnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 4) = Format(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("sl"), g_FormatSl)
                        dblTotalSl += rcDataSet.Tables("rc_ckdnr").Rows(i).Item("sl")
                    End If
                    If Not rcDataSet.Tables("rc_ckdnr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 5) = Trim(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("dw"))
                    End If
                    If Not rcDataSet.Tables("rc_ckdnr").Rows(i).Item("fzsl").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 6) = Format(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("fzsl"), g_FormatSl)
                        dblTotalFzsl += rcDataSet.Tables("rc_ckdnr").Rows(i).Item("fzsl")
                    End If
                    If Not rcDataSet.Tables("rc_ckdnr").Rows(i).Item("fzdw").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 7) = Trim(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("fzdw"))
                    End If
                    If Not rcDataSet.Tables("rc_ckdnr").Rows(i).Item("oldcpdm").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 8) = Trim(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("oldcpdm"))
                        If Not rcDataSet.Tables("rc_ckdnr").Rows(i).Item("ckmemo").GetType.ToString = "System.DBNull" Then
                            rcRps.Text(j + 1, 8) = Trim(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("oldcpdm")) & " " & Trim(rcDataSet.Tables("rc_ckdnr").Rows(i).Item("ckmemo"))
                        End If
                    End If
                    j += 1
                End If
            Next
            Dim m As New models.ChineseNum
            'm.InputString = dblTotalJe
            rcRps.PerPageText(intPage, 8) = IIf(intPage = Math.Ceiling(rcDataSet.Tables("rc_ckdnr").Rows.Count / rcRps.LinesPerPage.ToString), "�ϼ�", "С��")
            'rcRps.PerPageText(intPage, 7) = m.OutString '��д
            rcRps.PerPageText(intPage, 10) = Format(dblTotalSl, g_FormatSl)
            rcRps.PerPageText(intPage, 12) = Format(dblTotalFzsl, g_FormatSl)
            'dblTotalJe = 0.0
        Next
        If Decimal.op_Modulus(rcDataSet.Tables("rc_ckdnr").Rows.Count, rcRps.LinesPerPage.ToString) <> 0 Then
            For i = Decimal.op_Modulus(rcDataSet.Tables("rc_ckdnr").Rows.Count, rcRps.LinesPerPage.ToString) + 1 To rcRps.LinesPerPage.ToString
                rcRps.Text(j + 1, 1) = ""
                j += 1
            Next
        End If
        rcRps.Text(-1, 12) = "�Ƶ���" & rcDataSet.Tables("rc_ckdml").Rows(0).Item("srr")
    End Sub

#End Region

#Region "��ӡ�����¼�"

    Private Sub PageSetupEvent()
        Dim rcFrmPageSetup As New models.FrmPageSetup
        With rcFrmPageSetup
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = "POCKDBZ"
            .paraRpsName = "���ϳ��ⵥ��׼��ʽ"
            .ShowDialog()
        End With
    End Sub

    Private Sub MnuiPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPageSetup.Click
        PageSetupEvent()
    End Sub

#End Region

#Region "��ӡ�¼�"

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        PrintEvent()
    End Sub

    Private Sub MnuiPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrint.Click
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

#End Region

#Region "��ӡԤ���¼�"

    Private Sub PrintViewEvent()
        PreparePrintData()
        rcRps.Preview()
    End Sub

    Private Sub MnuiPrintView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrintView.Click
        PrintViewEvent()
    End Sub

    'Private Sub BtnPrintView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrintView.Click
    '    PrintViewEvent()
    'End Sub

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