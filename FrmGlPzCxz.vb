Imports System.Math
Imports System.Data.OleDb

Public Class FrmGlPzCxz
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    Dim rcDataset As New DataSet
    '��ʾҪ������Դִ�е� SQL ����
    ReadOnly rcOleDbTrans As OleDbTransaction
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '����Datatable '����Ҫ���ø�datatable���н�����
    ReadOnly dtPz As New DataTable("rc_pznr")
    '���ݰ�
    Dim rcBmb As BindingManagerBase
    '��ӡ�ĵ�
    Dim rcRps As RPS.Document = Nothing
    '�ϼƱ���
    Dim dblTotSl As Double = 0.0
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

    Private Sub FrmInvDbdSrz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '����DataGridView
        Me.rcDataGridView.AutoGenerateColumns = False
        Me.rcDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.rcDataGridView.Font = New System.Drawing.Font("����", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.rcDataGridView.Columns("ColJfje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColJfje").DefaultCellStyle.Format = g_FormatJe0
        Me.rcDataGridView.Columns("ColDfje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColDfje").DefaultCellStyle.Format = g_FormatJe0
        rcBmb = Me.BindingContext(rcDataSet, "pzml")
        If rcDataSet.Tables("pzml").Rows.Count > 0 Then
            ShowCkd(rcDataset.Tables("pzml").Rows(0).Item("djh"))
        End If
    End Sub

#End Region

#Region "��ʾ����ƾ֤"

    Private Sub ShowCkd(ByVal ckDjh As String)
        '�ж�ckDjh

        'ȡgl_pz����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT gl_pz.djh,gl_pz.bdelete,gl_pz.pzrq,gl_pz.fjzs,gl_pz.srr,gl_pz.shr,gl_pz.jzr FROM gl_pz WHERE (gl_pz.djh = ?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = ckDjh
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_pzml") IsNot Nothing Then
                Me.rcDataset.Tables("rc_pzml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_pzml")
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '��ֵ
        Me.TxtDjh.Text = rcDataset.Tables("rc_pzml").Rows(0).Item("djh")
        Me.DtpPzrq.Value = rcDataset.Tables("rc_pzml").Rows(0).Item("pzrq")
        Me.TxtFjzs.Text = Trim(rcDataset.Tables("rc_pzml").Rows(0).Item("fjzs"))
        Me.LblBdelete.Text = IIf(rcDataset.Tables("rc_pzml").Rows(0).Item("bdelete"), "����", "")
        Me.LblSrr.Text = "���룺" + rcDataset.Tables("rc_pzml").Rows(0).Item("srr")
        Me.LblShr.Text = "��ˣ�" + rcDataset.Tables("rc_pzml").Rows(0).Item("shr")
        Me.LblJzr.Text = "���ˣ�" + rcDataset.Tables("rc_pzml").Rows(0).Item("jzr")
        'ȡgl_pz����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT gl_pz.xh,gl_pz.zy,gl_pz.kmdm,gl_pz.kmmc,gl_pz.bmdm,gl_pz.bmmc,gl_pz.xmdm,gl_pz.xmmc,gl_pz.khdm,gl_pz.khmc,gl_pz.csdm,gl_pz.csmc,gl_pz.jxzh,gl_pz.sl,gl_pz.dj,gl_pz.wb,gl_pz.hl,Case When jd = '��' Then je Else 0 End As jfje,Case When jd = '��' Then je Else 0 End As dfje FROM gl_pz Where (gl_pz.djh = ?) ORDER BY gl_pz.xh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = ckDjh
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_pznr") IsNot Nothing Then
                rcDataset.Tables("rc_pznr").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_pznr")
            rcDataGridView.DataSource = rcDataset.Tables("rc_pznr")
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
        dblTotJe = 0.0
        If rcDataset.Tables("rc_pznr").Rows.Count > 0 Then
            dblTotSl = rcDataset.Tables("rc_pznr").Compute("Sum(sl)", "")
            dblTotJe = rcDataset.Tables("rc_pznr").Compute("Sum(jfje)", "")
        End If
        Me.LblSl.Text = "�����ϼƣ�" + Format(dblTotSl, g_FormatSl)
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
        Dim rft As String = CurDir() + "\reports\ckdbz.rft"
        rcRps.LoadTemplate(rft)
        'ȡRPS����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps WHERE rpsid = 'CKDBZ'"
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

        rcRps.Text(-1, 1) = g_Dwmc & "������"
        rcRps.Text(-1, 2) = DtpPzrq.Value.Date.ToLongDateString
        rcRps.Text(-1, 3) = "���ݺţ�" & Trim(Me.TxtDjh.Text) & "  %p/%t"
        'rcRps.Text(-1, 4) = "�ͻ����ϣ�" & Trim(TxtCsdm.Text)
        'rcRps.Text(-1, 5) = "�����ˣ�(" & Trim(Me.TxtKhdm.Text) & ")" & Trim(LblKhmc.Text)
        Dim i As Integer
        Dim j As Integer
        For i = 0 To rcDataSet.Tables("rc_pznr").Rows.Count - 1
            If rcDataSet.Tables("rc_pznr").Rows(i).RowState <> 8 Then
                If Not rcDataSet.Tables("rc_pznr").Rows(i).Item("kmdm").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 1) = Trim(rcDataSet.Tables("rc_pznr").Rows(i).Item("kmdm"))
                End If
                If Not rcDataSet.Tables("rc_pznr").Rows(i).Item("kmmc").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 2) = Trim(rcDataSet.Tables("rc_pznr").Rows(i).Item("kmmc"))
                End If
                If Not rcDataSet.Tables("rc_pznr").Rows(i).Item("bmdm").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 3) = Trim(rcDataSet.Tables("rc_pznr").Rows(i).Item("bmdm"))
                End If
                If Not rcDataSet.Tables("rc_pznr").Rows(i).Item("xmdm").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 4) = Trim(rcDataSet.Tables("rc_pznr").Rows(i).Item("xmdm"))
                End If
                If Not rcDataSet.Tables("rc_pznr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 5) = Trim(rcDataSet.Tables("rc_pznr").Rows(i).Item("dw"))
                End If
                If Not rcDataSet.Tables("rc_pznr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 6) = Format(rcDataSet.Tables("rc_pznr").Rows(i).Item("sl"), g_FormatSl)
                End If
                If Not rcDataSet.Tables("rc_pznr").Rows(i).Item("dbmemo").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 7) = Trim(rcDataSet.Tables("rc_pznr").Rows(i).Item("dbmemo"))
                End If
                j += 1
            End If
        Next
        If Decimal.op_Modulus(rcDataSet.Tables("rc_pznr").Rows.Count, rcRps.LinesPerPage.ToString) <> 0 Then
            For i = Decimal.op_Modulus(rcDataSet.Tables("rc_pznr").Rows.Count, rcRps.LinesPerPage.ToString) + 1 To rcRps.LinesPerPage.ToString
                rcRps.Text(j + 1, 1) = ""
                j += 1
            Next
        End If
        rcRps.Text(-1, 6) = "�����ˣ�" & g_User_DspName
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