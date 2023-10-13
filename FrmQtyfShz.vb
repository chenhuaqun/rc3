Imports System.Data.OleDb

Public Class FrmQtyfShz
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    Dim rcDataset As New DataSet
    '��ʾҪ������Դִ�е� SQL ����
    Dim rcOleDbTrans As OleDbTransaction
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '����Datatable '����Ҫ���ø�datatable���н�����
    ReadOnly dtCkd As New DataTable("rc_xsdnr")
    '�ϼƱ���
    ReadOnly dblTotSl As Double = 0.0
    ReadOnly dblTotJe As Double = 0.0
    '���ݰ�
    Dim rcBmb As BindingManagerBase
    '��ӡ�ĵ�
    ReadOnly rcRps As RPS.Document = Nothing

#Region "�����ʼ��"

    Public Property ParaDataSet() As DataSet
        Get
            ParaDataSet = rcDataSet
        End Get
        Set(ByVal Value As DataSet)
            rcDataSet = Value
        End Set
    End Property

    Private Sub FrmQtyfShz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rcBmb = Me.BindingContext(rcDataSet, "fpml")
        If rcDataSet.Tables("fpml").Rows.Count > 0 Then
            ShowQtyf(rcDataSet.Tables("fpml").Rows(0).Item("djh"))
        End If
    End Sub

#End Region

#Region "��ʾ��ⵥ"

    Private Sub ShowQtyf(ByVal xsdDjh As String)
        '�ж�xsdDjh

        'ȡpo_fp����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT po_fp.djh,po_fp.fprq,po_fp.csdm,po_fp.csmc,po_fp.zydm,po_fp.zymc,po_fp.je,po_fp.fpmemo,po_fp.srr,po_fp.shr,po_fp.jzr FROM po_fp WHERE (djh = ?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = xsdDjh
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_fpml") IsNot Nothing Then
                rcDataSet.Tables("rc_fpml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_fpml")
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '��ֵ
        Me.TxtDjh.Text = rcDataSet.Tables("rc_fpml").Rows(0).Item("djh")
        Me.Dtpfprq.Value = rcDataSet.Tables("rc_fpml").Rows(0).Item("fprq")
        If rcDataSet.Tables("rc_fpml").Rows(0).Item("zydm").GetType.ToString <> "System.DBNull" Then
            Me.TxtZydm.Text = rcDataSet.Tables("rc_fpml").Rows(0).Item("zydm")
        Else
            Me.TxtZydm.Text = ""
        End If
        If rcDataSet.Tables("rc_fpml").Rows(0).Item("zymc").GetType.ToString <> "System.DBNull" Then
            Me.LblZymc.Text = rcDataSet.Tables("rc_fpml").Rows(0).Item("zymc")
        Else
            Me.LblZymc.Text = ""
        End If
        If rcDataSet.Tables("rc_fpml").Rows(0).Item("csdm").GetType.ToString <> "System.DBNull" Then
            Me.TxtCsdm.Text = rcDataSet.Tables("rc_fpml").Rows(0).Item("csdm")
        Else
            Me.TxtCsdm.Text = ""
        End If
        If rcDataSet.Tables("rc_fpml").Rows(0).Item("csmc").GetType.ToString <> "System.DBNull" Then
            Me.LblCsmc.Text = rcDataSet.Tables("rc_fpml").Rows(0).Item("csmc")
        Else
            Me.LblCsmc.Text = ""
        End If
        Me.TxtJe.Text = rcDataSet.Tables("rc_fpml").Rows(0).Item("je")
        If rcDataSet.Tables("rc_fpml").Rows(0).Item("fpmemo").GetType.ToString <> "System.DBNull" Then
            Me.TxtFpmemo.Text = rcDataSet.Tables("rc_fpml").Rows(0).Item("fpmemo")
        Else
            Me.TxtFpmemo.Text = ""
        End If
        Me.LblSrr.Text = "���룺" + rcDataSet.Tables("rc_fpml").Rows(0).Item("srr")
        Me.LblShr.Text = "��ˣ�" + rcDataSet.Tables("rc_fpml").Rows(0).Item("shr")
        Me.LblJzr.Text = "���ˣ�" + rcDataSet.Tables("rc_fpml").Rows(0).Item("jzr")
    End Sub

#End Region

#Region "���"

    Private Sub BtnSh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSh.Click, MnuiSh.Click
        ShEvent(rcBmb.Current("djh"))
    End Sub

    Private Sub ShEvent(ByVal xsdDjh As String)
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "UPDATE po_fp SET shr = ? WHERE djh = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@shr", OleDbType.VarChar, 30).Value = g_User_DspName
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = xsdDjh
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Catch ey As OleDbException
                MsgBox("�������" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        LblShr.Text = "��ˣ�" + g_User_DspName
    End Sub

#End Region

#Region "����"

    Private Sub BtnXs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXs.Click, MnuiXs.Click
        XsEvent(rcBmb.Current("djh"))
    End Sub

    Private Sub XsEvent(ByVal xsdDjh As String)
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "UPDATE po_fp SET shr = ? WHERE djh = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@shr", OleDbType.VarChar, 30).Value = ""
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = xsdDjh
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Catch ey As OleDbException
                MsgBox("�������" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        LblShr.Text = "��ˣ�"
    End Sub

#End Region

#Region "ȫ��"

    Private Sub BtnQs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQs.Click, MnuiQs.Click
        If MsgBox("�Ƿ�ȫ������ѡ��ĵ��ݣ�", MsgBoxStyle.YesNo + MsgBoxStyle.Information + MsgBoxStyle.DefaultButton2, "��ʾ��Ϣ") <> MsgBoxResult.Yes Then
            Return
        End If
        QsEvent()
    End Sub

    Private Sub QsEvent()
        Dim i As Integer
        For i = 0 To rcDataSet.Tables("fpml").Rows.Count - 1
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "UPDATE po_fp SET shr = ? WHERE djh = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@shr", OleDbType.VarChar, 30).Value = g_User_DspName
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Trim(rcDataSet.Tables("fpml").Rows(i).Item("djh"))
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Catch ey As OleDbException
                    MsgBox("�������" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        Next
        LblShr.Text = "��ˣ�" + g_User_DspName
    End Sub

#End Region

#Region "ȫ��"

    Private Sub BtnQx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQx.Click, MnuiQx.Click
        QxEvent()
    End Sub

    Private Sub QxEvent()
        Dim i As Integer
        For i = 0 To rcDataSet.Tables("fpml").Rows.Count - 1
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "UPDATE po_fp SET shr = ? WHERE djh = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@shr", OleDbType.VarChar, 30).Value = ""
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Trim(rcDataSet.Tables("fpml").Rows(i).Item("djh"))
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Catch ey As OleDbException
                    MsgBox("�������" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        Next
        LblShr.Text = "��ˣ�"
    End Sub

#End Region

#Region "����"

    Private Sub BtnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevious.Click, MnuiPrevious.Click
        If rcBmb.Count > 0 Then
            If rcBmb.Position <> 0 Then
                rcBmb.Position -= 1
            End If
            ShowQtyf(rcBmb.Current("djh"))
        End If
    End Sub

#End Region

#Region "����"

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click, MnuiNext.Click
        If rcBmb.Count > 0 Then
            If rcBmb.Position <> rcBmb.Count Then
                rcBmb.Position += 1
            End If
            ShowQtyf(rcBmb.Current("djh"))
        End If
    End Sub

#End Region

    '#Region "��ӡ����"

    '    Private Sub MnuiPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPageSetup.Click
    '        PageSetupEvent()
    '    End Sub

    '    Private Sub PageSetupEvent()
    '        Dim rcFrmPageSetup As New models.FrmPageSetup
    '        With rcFrmPageSetup
    '            .paraOleDbConn = rcOleDbConn
    '            .paraRpsId = "XSDBZ"
    '            .paraRpsName = "���۵���׼��ʽ"
    '            .ShowDialog()
    '        End With
    '    End Sub

    '#End Region

    '#Region "��ӡ/��ӡԤ��"

    '    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click, MnuiPrint.Click
    '        PrintEvent()
    '    End Sub

    '    Private Sub PrintEvent()
    '        If g_Demo = 1 Then
    '            MsgBox("�Բ�������������ܴ�ӡ��", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
    '            Return
    '        End If
    '        PreparePrintData()
    '        Dim rcFrmPrint As New models.FrmPrint
    '        With rcFrmPrint
    '            .paraRps = rcRps
    '            .ShowDialog()
    '        End With
    '    End Sub

    '    Private Sub MnuiPrintView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrintView.Click
    '        PrintViewEvent()
    '    End Sub

    '    Private Sub PrintViewEvent()
    '        PreparePrintData()
    '        rcRps.Preview()
    '    End Sub

    '#End Region

    '#Region "׼����ӡ�����¼�"
    '    Private Sub PreparePrintData()
    '        If rcRps Is Nothing Then
    '            rcRps = New RPS.Document
    '        End If
    '        Dim rft As String = Application.StartupPath + "\reports\xsdbz.rft"
    '        rcRps.LoadTemplate(rft)
    '        'ȡRPS��ӡ����
    '        Try
    '            rcOleDbConn.Open()
    '            rcOleDbCommand.Connection = rcOleDbConn
    '            rcOleDbCommand.CommandTimeout = 300
    '            rcOleDbCommand.CommandType = CommandType.Text
    '            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps WHERE rpsid = 'XSDBZ'"
    '            rcOleDbCommand.Parameters.Clear()
    '            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
    '            If Not rcDataSet.Tables("rc_rps") Is Nothing Then
    '                rcDataSet.Tables("rc_rps").Clear()
    '            End If
    '            rcOleDbDataAdpt.Fill(rcDataSet, "rc_rps")
    '        Catch ex As Exception
    '            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
    '            Return
    '        Finally
    '            rcOleDbConn.Close()
    '        End Try
    '        If rcDataSet.Tables("rc_rps").Rows.Count > 0 Then
    '            '�趨ֵ
    '            rcRps.Scale = rcDataSet.Tables("rc_rps").Rows(0).Item("scale")
    '            rcRps.Orientation = rcDataSet.Tables("rc_rps").Rows(0).Item("orientation")
    '            rcRps.PaperWidth = rcDataSet.Tables("rc_rps").Rows(0).Item("paperwidth")
    '            rcRps.PaperHeight = rcDataSet.Tables("rc_rps").Rows(0).Item("paperheight")
    '            rcRps.PrinterLeft = rcDataSet.Tables("rc_rps").Rows(0).Item("printerleft")
    '            rcRps.PrinterTop = rcDataSet.Tables("rc_rps").Rows(0).Item("printertop")
    '        Else
    '            'Ĭ��ֵ
    '            rcRps.Scale = 100
    '            rcRps.Orientation = 1
    '        End If
    '        '�״�
    '        'rcRps.PaperType = 1
    '        rcRps.Text(-1, 1) = g_PrnDwmc & "���۵�"
    '        rcRps.Text(-1, 2) = "���ݺţ�" & Trim(Me.TxtDjh.Text) & "  %p/%t"
    '        rcRps.Text(-1, 3) = "��Ӧ�̣�(" & Trim(Me.TxtCsdm.Text) & ")" & Trim(Me.LblCsmc.Text)
    '        rcRps.Text(-1, 4) = "���ڣ�" & Me.Dtpfprq.Value.ToLongDateString
    '        Dim i As Integer
    '        Dim j As Integer
    '        Dim intPage As Integer
    '        Dim dblTotalSl As Double = 0.0
    '        Dim dblTotalJe As Double = 0.0
    '        For intPage = 1 To System.Math.Ceiling(rcDataSet.Tables("rc_xsdnr").Rows.Count / rcRps.LinesPerPage.ToString)
    '            For i = (intPage - 1) * rcRps.LinesPerPage.ToString To System.Math.Min(intPage * rcRps.LinesPerPage.ToString - 1, rcDataSet.Tables("rc_xsdnr").Rows.Count - 1)
    '                If rcDataSet.Tables("rc_xsdnr").Rows(i).RowState <> 8 Then
    '                    If Not rcDataSet.Tables("rc_xsdnr").Rows(i).Item("cpdm").GetType.ToString = "System.DBNull" Then
    '                        rcRps.Text(j + 1, 1) = Trim(rcDataSet.Tables("rc_xsdnr").Rows(i).Item("cpdm"))
    '                    End If
    '                    If Not rcDataSet.Tables("rc_xsdnr").Rows(i).Item("cpmc").GetType.ToString = "System.DBNull" Then
    '                        rcRps.Text(j + 1, 2) = Trim(rcDataSet.Tables("rc_xsdnr").Rows(i).Item("cpmc"))
    '                    End If
    '                    If Not rcDataSet.Tables("rc_xsdnr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
    '                        rcRps.Text(j + 1, 4) = Trim(rcDataSet.Tables("rc_xsdnr").Rows(i).Item("dw"))
    '                    End If
    '                    If Not rcDataSet.Tables("rc_xsdnr").Rows(i).Item("mjsl").GetType.ToString = "System.DBNull" Then
    '                        rcRps.Text(j + 1, 5) = Format(rcDataSet.Tables("rc_xsdnr").Rows(i).Item("mjsl"), g_FormatSl)
    '                    End If
    '                    'If Not rcDataSet.Tables("rc_xsdnr").Rows(i).Item("lt").GetType.ToString = "System.DBNull" Then
    '                    '    rcRps.Text(j + 1, 6) = Format(rcDataSet.Tables("rc_xsdnr").Rows(i).Item("lt"), g_FormatSl)
    '                    'End If
    '                    If Not rcDataSet.Tables("rc_xsdnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
    '                        rcRps.Text(j + 1, 6) = Format(rcDataSet.Tables("rc_xsdnr").Rows(i).Item("sl"), g_FormatSl)
    '                        dblTotalSl = dblTotalSl + rcDataSet.Tables("rc_xsdnr").Rows(i).Item("sl")
    '                    End If
    '                    If Not rcDataSet.Tables("rc_xsdnr").Rows(i).Item("dj").GetType.ToString = "System.DBNull" Then
    '                        rcRps.Text(j + 1, 7) = Format(rcDataSet.Tables("rc_xsdnr").Rows(i).Item("dj"), g_FormatDj)
    '                    End If
    '                    If Not rcDataSet.Tables("rc_xsdnr").Rows(i).Item("je").GetType.ToString = "System.DBNull" Then
    '                        rcRps.Text(j + 1, 8) = Format(rcDataSet.Tables("rc_xsdnr").Rows(i).Item("je"), g_FormatJe)
    '                        dblTotalJe = dblTotalJe + rcDataSet.Tables("rc_xsdnr").Rows(i).Item("je")
    '                    End If
    '                    If Not rcDataSet.Tables("rc_xsdnr").Rows(i).Item("fpmemo").GetType.ToString = "System.DBNull" Then
    '                        rcRps.Text(j + 1, 9) = Trim(rcDataSet.Tables("rc_xsdnr").Rows(i).Item("fpmemo"))
    '                    End If
    '                    j = j + 1
    '                End If
    '            Next
    '            Dim m As New models.ChineseNum
    '            m.InputString = dblTotalJe
    '            rcRps.PerPageText(intPage, 8) = m.OutString '��д
    '            rcRps.PerPageText(intPage, 9) = Format(dblTotalSl, g_FormatSl)
    '            rcRps.PerPageText(intPage, 11) = Format(dblTotalJe, g_FormatJe)
    '            'dblTotalJe = 0.0
    '        Next
    '        If Decimal.op_Modulus(rcDataSet.Tables("rc_xsdnr").Rows.Count, rcRps.LinesPerPage.ToString) <> 0 Then
    '            For i = Decimal.op_Modulus(rcDataSet.Tables("rc_xsdnr").Rows.Count, rcRps.LinesPerPage.ToString) + 1 To rcRps.LinesPerPage.ToString
    '                rcRps.Text(j + 1, 1) = ""
    '                j = j + 1
    '            Next
    '        End If
    '        rcRps.Text(-1, 13) = "�ֹܣ�" & g_User_DspName
    '    End Sub

    '#End Region

#Region "�˳�"

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click, MnuiExit.Click
        ExitEvent()
    End Sub

    Private Sub ExitEvent()
        Me.Close()
    End Sub

#End Region

End Class