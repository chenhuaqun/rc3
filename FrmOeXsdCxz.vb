Imports System.Data.OleDb

Public Class FrmOeXsdCxz
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    Dim rcDataset As New DataSet
    '��������
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '���ݰ�
    Dim rcBmb As BindingManagerBase
    '������ӡ�ĵ�
    Dim rcRps As RPS.Document
    '�ϼƱ���
    Dim dblTotSl As Double = 0.0
    Dim dblTotFzsl As Double = 0.0
    Dim dblTotJe As Double = 0.0
    Dim dblTotSe As Double = 0.0
    '�״��־
    Dim blnTd As Boolean = False

    Public Property ParaDataSet() As DataSet
        Get
            ParaDataSet = rcDataSet
        End Get
        Set(ByVal Value As DataSet)
            rcDataSet = Value
        End Set
    End Property

    Private Sub FrmOeXsdCxz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        'ȡ�״��ʽ��ӡ���۵�
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT paradblvalue FROM rc_para WHERE dwdm = ? AND paraid = '�״��ʽ��ӡ���۵�' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_para") IsNot Nothing Then
                Me.rcDataSet.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_para")
            If rcDataSet.Tables("rc_para").Rows.Count = 1 Then
                If rcDataSet.Tables("rc_para").Rows(0).Item("paradblvalue").GetType.ToString <> "System.DBNull" Then
                    blnTd = rcDataSet.Tables("rc_para").Rows(0).Item("paradblvalue")
                End If
            End If
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        rcBmb = Me.BindingContext(rcDataSet, "xsdml")
        If rcDataSet.Tables("xsdml").Rows.Count > 0 Then
            ShowXsd(rcDataSet.Tables("xsdml").Rows(0).Item("djh"))
        End If
    End Sub

    Private Sub ShowXsd(ByVal xsdDjh As String)
        '�ж�xsdDjh
        'ȡoe_xsd����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT oe_xsd.djh,oe_xsd.xsrq,oe_xsd.bdelete,oe_xsd.khdm,oe_xsd.khmc,oe_xsd.bmdm,oe_xsd.bmmc,oe_xsd.zydm,oe_xsd.zymc,oe_xsd.ckdm,oe_xsd.ckmc,oe_xsd.srr,oe_xsd.shr,oe_xsd.jzr FROM oe_xsd WHERE (djh = ?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = xsdDjh
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_xsdml") IsNot Nothing Then
                rcDataSet.Tables("rc_xsdml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_xsdml")
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '��ֵ
        Me.TxtDjh.Text = rcDataSet.Tables("rc_xsdml").Rows(0).Item("djh")
        Me.DtpXsrq.Value = rcDataSet.Tables("rc_xsdml").Rows(0).Item("xsrq")
        Me.LblBdelete.Text = IIf(rcDataSet.Tables("rc_xsdml").Rows(0).Item("bdelete"), "����", "")
        If rcDataSet.Tables("rc_xsdml").Rows(0).Item("khdm").GetType.ToString <> "System.DBNull" Then
            Me.TxtKhdm.Text = rcDataSet.Tables("rc_xsdml").Rows(0).Item("khdm")
        Else
            Me.TxtKhdm.Text = ""
        End If
        If rcDataSet.Tables("rc_xsdml").Rows(0).Item("khmc").GetType.ToString <> "System.DBNull" Then
            Me.LblKhmc.Text = rcDataSet.Tables("rc_xsdml").Rows(0).Item("khmc")
        Else
            Me.LblKhmc.Text = ""
        End If
        If rcDataSet.Tables("rc_xsdml").Rows(0).Item("bmdm").GetType.ToString <> "System.DBNull" Then
            Me.TxtBmdm.Text = rcDataSet.Tables("rc_xsdml").Rows(0).Item("bmdm")
        Else
            Me.TxtBmdm.Text = ""
        End If
        If rcDataSet.Tables("rc_xsdml").Rows(0).Item("bmmc").GetType.ToString <> "System.DBNull" Then
            Me.LblBmmc.Text = rcDataSet.Tables("rc_xsdml").Rows(0).Item("bmmc")
        Else
            Me.LblBmmc.Text = ""
        End If
        If rcDataSet.Tables("rc_xsdml").Rows(0).Item("zydm").GetType.ToString <> "System.DBNull" Then
            Me.TxtZydm.Text = rcDataSet.Tables("rc_xsdml").Rows(0).Item("zydm")
        Else
            Me.TxtZydm.Text = ""
        End If
        If rcDataSet.Tables("rc_xsdml").Rows(0).Item("zymc").GetType.ToString <> "System.DBNull" Then
            Me.LblZymc.Text = rcDataSet.Tables("rc_xsdml").Rows(0).Item("zymc")
        Else
            Me.LblZymc.Text = ""
        End If
        If rcDataSet.Tables("rc_xsdml").Rows(0).Item("ckdm").GetType.ToString <> "System.DBNull" Then
            Me.TxtCkdm.Text = rcDataSet.Tables("rc_xsdml").Rows(0).Item("ckdm")
        Else
            Me.TxtCkdm.Text = ""
        End If
        If rcDataSet.Tables("rc_xsdml").Rows(0).Item("ckmc").GetType.ToString <> "System.DBNull" Then
            Me.LblCkmc.Text = Trim(rcDataSet.Tables("rc_xsdml").Rows(0).Item("ckmc"))
        Else
            Me.LblCkmc.Text = ""
        End If
        Me.LblSrr.Text = "���룺" + rcDataSet.Tables("rc_xsdml").Rows(0).Item("srr")
        Me.LblShr.Text = "��ˣ�" + rcDataSet.Tables("rc_xsdml").Rows(0).Item("shr")
        Me.LblJzr.Text = "���ˣ�" + rcDataSet.Tables("rc_xsdml").Rows(0).Item("jzr")
        'ȡoe_xsd����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT oe_xsd.cpdm,COALESCE(oe_xsd.cpmc,'') as cpmc,COALESCE(oe_xsd.hth,'') AS hth,oe_xsd.khddh,oe_xsd.khlh,oe_xsd.mjsl,oe_xsd.sl,COALESCE(oe_xsd.dw,'') as dw,oe_xsd.fzsl,oe_xsd.fzdw,oe_xsd.dj,oe_xsd.hsdj,oe_xsd.je,oe_xsd.shlv,oe_xsd.se,oe_xsd.je + oe_xsd.se AS jese,oe_xsd.xsmemo,oe_xsd.dddjh,oe_xsd.ddxh FROM oe_xsd WHERE (oe_xsd.djh = ?) ORDER BY oe_xsd.xh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = xsdDjh
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_xsdnr") IsNot Nothing Then
                rcDataSet.Tables("rc_xsdnr").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_xsdnr")
            rcDataGridView.DataSource = rcDataSet.Tables("rc_xsdnr")
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        SumSlJe()
    End Sub

#Region "����ϼ���"

    Private Sub SumSlJe()
        '����ϼ���
        dblTotSl = 0.0
        dblTotFzsl = 0.0
        dblTotJe = 0.0
        dblTotSe = 0.0
        If rcDataSet.Tables("rc_xsdnr").Rows.Count > 0 Then
            dblTotSl = rcDataSet.Tables("rc_xsdnr").Compute("Sum(sl)", "")
            dblTotFzsl = rcDataSet.Tables("rc_xsdnr").Compute("Sum(fzsl)", "")
            dblTotJe = rcDataSet.Tables("rc_xsdnr").Compute("Sum(je)", "")
            dblTotSe = rcDataSet.Tables("rc_xsdnr").Compute("Sum(se)", "")
        End If
        Me.LblSl.Text = "�����ϼƣ�" + Format(dblTotSl, g_FormatSl)
        Me.LblFzsl.Text = "�������ϼƣ�" + Format(dblTotFzsl, g_FormatSl)
        Me.LblJe.Text = "���ϼƣ�" + Format(dblTotJe, g_FormatJe)
        Me.LblSe.Text = "˰��ϼƣ�" + Format(dblTotSe, g_FormatJe)
        Me.LblJese.Text = "��˰�ϼƣ�" + Format(dblTotJe + dblTotSe, g_FormatJe)
    End Sub

#End Region

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        ExitEvent()
    End Sub

    Private Sub MnuiExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiExit.Click
        ExitEvent()
    End Sub

    Private Sub ExitEvent()
        Me.Close()
    End Sub

    Private Sub BtnTop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTop.Click
        If rcBmb.Count > 0 Then
            rcBmb.Position = 0
            ShowXsd(rcBmb.Current("djh"))
        End If
    End Sub

    Private Sub MnuiTop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiTop.Click
        If rcBmb.Count > 0 Then
            rcBmb.Position = 0
            ShowXsd(rcBmb.Current("djh"))
        End If
    End Sub

    Private Sub BtnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevious.Click
        If rcBmb.Count > 0 Then
            If rcBmb.Position <> 0 Then
                rcBmb.Position -= 1
            End If
            ShowXsd(rcBmb.Current("djh"))
        End If
    End Sub

    Private Sub MnuiPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrevious.Click
        If rcBmb.Count > 0 Then
            If rcBmb.Position <> 0 Then
                rcBmb.Position -= 1
            End If
            ShowXsd(rcBmb.Current("djh"))
        End If
    End Sub

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
        If rcBmb.Count > 0 Then
            If rcBmb.Position <> rcBmb.Count Then
                rcBmb.Position += 1
            End If
            ShowXsd(rcBmb.Current("djh"))
        End If
    End Sub

    Private Sub MnuiNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiNext.Click
        If rcBmb.Count > 0 Then
            If rcBmb.Position <> rcBmb.Count Then
                rcBmb.Position += 1
            End If
            ShowXsd(rcBmb.Current("djh"))
        End If
    End Sub

    Private Sub BtnBottom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBottom.Click
        If rcBmb.Count > 0 Then
            rcBmb.Position = rcBmb.Count - 1
            ShowXsd(rcBmb.Current("djh"))
        End If
    End Sub

    Private Sub MnuiBottom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiBottom.Click
        If rcBmb.Count > 0 Then
            rcBmb.Position = rcBmb.Count - 1
            ShowXsd(rcBmb.Current("djh"))
        End If
    End Sub


#Region "��ӡ����"

    Private Sub MnuiPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPageSetup.Click
        PageSetupEvent()
    End Sub

    Private Sub PageSetupEvent()
        Dim rcFrmPageSetup As New models.FrmPageSetup
        With rcFrmPageSetup
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = "SHDBZ"
            .paraRpsName = "�ͻ�����׼��ʽ"
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

    Private Sub MnuiPrintView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrintView.Click, BtnPrintView.Click
        PrintViewEvent()
    End Sub

    Private Sub PrintViewEvent()
        PreparePrintData()
        rcRps.Preview()
    End Sub

#End Region

#Region "׼����ӡ�����¼�"
    Private Sub PreparePrintData()
        Dim slFormat As String = g_FormatSl
        Dim fzslFormat As String = g_FormatSl
        Dim slMaxFormat As String = " "
        Dim fzslMaxFormat As String = " "
        If rcRps Is Nothing Then
            rcRps = New RPS.Document
        End If
        Dim rft As String
        rft = Application.StartupPath + "\reports\shdbz.rft"
        rcRps.LoadTemplate(rft)
        'ȡRPS��ӡ����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps WHERE rpsid = 'SHDBZ'"
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
        'If blnTd Then
        '    rcRps.PaperType = 1
        'End If
        rcRps.Text(-1, 1) = g_PrnDwmc
        rcRps.Text(-1, 2) = "��  ��  ��"
        rcRps.Text(-1, 3) = "���ݺţ�" & Trim(Me.TxtDjh.Text) & "  %p/%t"
        rcRps.Text(-1, 4) = "�ͻ���" & "(" & Trim(Me.TxtKhdm.Text) & ")" & Trim(Me.LblKhmc.Text)
        rcRps.Text(-1, 5) = "���ڣ�" & Me.DtpXsrq.Value.Date.ToLongDateString
        Dim i As Integer
        Dim j As Integer
        Dim intPage As Integer
        dblTotSl = 0.0
        dblTotFzsl = 0.0
        For intPage = 1 To System.Math.Ceiling(rcDataSet.Tables("rc_xsdnr").Rows.Count / rcRps.LinesPerPage.ToString)
            For i = (intPage - 1) * rcRps.LinesPerPage.ToString To System.Math.Min(intPage * rcRps.LinesPerPage.ToString - 1, rcDataSet.Tables("rc_xsdnr").Rows.Count - 1)
                If rcDataSet.Tables("rc_xsdnr").Rows(i).RowState <> 8 Then
                    If Not rcDataSet.Tables("rc_xsdnr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
                        slFormat = ReadJldwXsws(rcDataSet.Tables("rc_xsdnr").Rows(i).Item("dw"))
                        If slFormat > slMaxFormat Then
                            slMaxFormat = slFormat
                        End If
                    End If
                    If Not rcDataSet.Tables("rc_xsdnr").Rows(i).Item("fzdw").GetType.ToString = "System.DBNull" Then
                        fzslFormat = ReadJldwXsws(rcDataSet.Tables("rc_xsdnr").Rows(i).Item("fzdw"))
                        If fzslFormat > fzslMaxFormat Then
                            fzslMaxFormat = fzslFormat
                        End If
                    End If
                    If Not rcDataSet.Tables("rc_xsdnr").Rows(i).Item("cpdm").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 1) = Trim(rcDataSet.Tables("rc_xsdnr").Rows(i).Item("cpdm"))
                    End If
                    If Not rcDataSet.Tables("rc_xsdnr").Rows(i).Item("cpmc").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 2) = Trim(rcDataSet.Tables("rc_xsdnr").Rows(i).Item("cpmc"))
                    End If
                    If Not rcDataSet.Tables("rc_xsdnr").Rows(i).Item("khddh").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 3) = Trim(rcDataSet.Tables("rc_xsdnr").Rows(i).Item("khddh"))
                    End If
                    If Not rcDataSet.Tables("rc_xsdnr").Rows(i).Item("khlh").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 4) = Trim(rcDataSet.Tables("rc_xsdnr").Rows(i).Item("khlh"))
                    End If
                    If Not rcDataSet.Tables("rc_xsdnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 5) = Format(rcDataSet.Tables("rc_xsdnr").Rows(i).Item("sl"), slFormat)
                        dblTotSl += rcDataSet.Tables("rc_xsdnr").Rows(i).Item("sl")
                    End If
                    If Not rcDataSet.Tables("rc_xsdnr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 6) = Trim(rcDataSet.Tables("rc_xsdnr").Rows(i).Item("dw"))
                    End If
                    If Not rcDataSet.Tables("rc_xsdnr").Rows(i).Item("fzsl").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 7) = Format(rcDataSet.Tables("rc_xsdnr").Rows(i).Item("fzsl"), fzslFormat)
                        dblTotFzsl += rcDataSet.Tables("rc_xsdnr").Rows(i).Item("fzsl")
                    End If
                    If Not rcDataSet.Tables("rc_xsdnr").Rows(i).Item("fzdw").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 8) = Trim(rcDataSet.Tables("rc_xsdnr").Rows(i).Item("fzdw"))
                    End If
                    If Not rcDataSet.Tables("rc_xsdnr").Rows(i).Item("xsmemo").GetType.ToString = "System.DBNull" Then
                        rcRps.Text(j + 1, 9) = rcDataSet.Tables("rc_xsdnr").Rows(i).Item("xsmemo")
                    End If
                    j += 1
                End If
            Next
            If slFormat > slMaxFormat Then
                slMaxFormat = slFormat
            End If
            If fzslFormat > fzslMaxFormat Then
                fzslMaxFormat = fzslFormat
            End If
            rcRps.PerPageText(intPage, 9) = Format(dblTotSl, g_FormatSl)
            rcRps.PerPageText(intPage, 11) = Format(dblTotFzsl, g_FormatSl)
        Next
        If Decimal.op_Modulus(rcDataSet.Tables("rc_xsdnr").Rows.Count, rcRps.LinesPerPage.ToString) <> 0 Then
            For i = Decimal.op_Modulus(rcDataSet.Tables("rc_xsdnr").Rows.Count, rcRps.LinesPerPage.ToString) + 1 To rcRps.LinesPerPage.ToString
                rcRps.Text(j + 1, 1) = ""
                j += 1
            Next
        End If
        rcRps.Text(-1, 14) = "�ֹܣ�" & g_User_DspName
    End Sub

#End Region


End Class