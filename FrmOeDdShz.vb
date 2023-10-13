Imports System.Data.OleDb

Public Class FrmOeDdShz
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    Dim rcDataset As New DataSet
    '��ʾҪ������Դִ�е� SQL ����
    Dim rcOleDbTrans As OleDbTransaction
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
    Dim dblTotSe As Double = 0.0

#Region "�����ʼ��"

    Public Property ParaDataSet() As DataSet
        Get
            ParaDataSet = rcDataSet
        End Get
        Set(ByVal Value As DataSet)
            rcDataSet = Value
        End Set
    End Property

    Private Sub FrmOeDdShz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        rcBmb = Me.BindingContext(rcDataSet, "ddml")
        If rcDataSet.Tables("ddml").Rows.Count > 0 Then
            ShowDd(rcDataSet.Tables("ddml").Rows(0).Item("djh"))
        End If
    End Sub

#End Region

#Region "��ʾ��ⵥ"

    Private Sub ShowDd(ByVal ddDjh As String)
        '�ж�ddDjh

        'ȡoe_dd����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT oe_dd.djh,oe_dd.qdrq,oe_dd.hth,oe_dd.khdm,oe_dd.khmc,oe_dd.zydm,oe_dd.zymc,oe_dd.ddtk,oe_dd.sktj,oe_dd.skqx,oe_dd.srr,oe_dd.shr,oe_dd.jzr FROM oe_dd WHERE (djh = ?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = ddDjh
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_ddml") IsNot Nothing Then
                rcDataSet.Tables("rc_ddml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_ddml")
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '��ֵ
        Me.TxtDjh.Text = rcDataSet.Tables("rc_ddml").Rows(0).Item("djh")
        Me.DtpQdrq.Value = rcDataSet.Tables("rc_ddml").Rows(0).Item("qdrq")
        Me.TxtHth.Text = Trim(rcDataSet.Tables("rc_ddml").Rows(0).Item("hth"))
        Me.TxtKhdm.Text = rcDataSet.Tables("rc_ddml").Rows(0).Item("khdm")
        Me.LblKhmc.Text = Trim(rcDataSet.Tables("rc_ddml").Rows(0).Item("khmc"))
        If rcDataSet.Tables("rc_ddml").Rows(0).Item("zydm").GetType.ToString <> "System.DBNull" Then
            Me.TxtZydm.Text = Trim(rcDataSet.Tables("rc_ddml").Rows(0).Item("zydm"))
        Else
            Me.TxtZydm.Text = ""
        End If
        If rcDataSet.Tables("rc_ddml").Rows(0).Item("zymc").GetType.ToString <> "System.DBNull" Then
            Me.LblZymc.Text = rcDataSet.Tables("rc_ddml").Rows(0).Item("zymc")
        Else
            Me.LblZymc.Text = ""
        End If
        If rcDataSet.Tables("rc_ddml").Rows(0).Item("ddtk").GetType.ToString <> "System.DBNull" Then
            Me.TxtDdtk.Text = Trim(rcDataSet.Tables("rc_ddml").Rows(0).Item("ddtk"))
        Else
            Me.TxtDdtk.Text = ""
        End If
        If rcDataSet.Tables("rc_ddml").Rows(0).Item("sktj").GetType.ToString <> "System.DBNull" Then
            Me.CmbSktj.SelectedItem = rcDataSet.Tables("rc_ddml").Rows(0).Item("sktj")
        Else
            Me.CmbSktj.SelectedItem = "�½�"
        End If
        If rcDataSet.Tables("rc_ddml").Rows(0).Item("skqx").GetType.ToString <> "System.DBNull" Then
            Me.TxtSkqx.Text = rcDataSet.Tables("rc_ddml").Rows(0).Item("skqx")
        Else
            Me.TxtSkqx.Text = 0
        End If
        If rcDataSet.Tables("rc_ddml").Rows(0).Item("srr").GetType.ToString <> "System.DBNull" Then
            Me.LblSrr.Text = "���룺" + rcDataSet.Tables("rc_ddml").Rows(0).Item("srr")
        Else
            Me.LblSrr.Text = "���룺"
        End If
        If rcDataSet.Tables("rc_ddml").Rows(0).Item("shr").GetType.ToString <> "System.DBNull" Then
            Me.LblShr.Text = "��ˣ�" + rcDataSet.Tables("rc_ddml").Rows(0).Item("shr")
        Else
            Me.LblShr.Text = "��ˣ�"
        End If
        If rcDataSet.Tables("rc_ddml").Rows(0).Item("jzr").GetType.ToString <> "System.DBNull" Then
            Me.LblJzr.Text = "���ˣ�" + rcDataSet.Tables("rc_ddml").Rows(0).Item("jzr")
        Else
            Me.LblJzr.Text = "���ˣ�"
        End If
        'ȡoe_dd����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT oe_dd.djh,oe_dd.xh,oe_dd.cpdm,oe_dd.cpmc,oe_dd.sl,oe_dd.dw,oe_dd.mjsl,oe_dd.fzsl,oe_dd.fzdw,oe_dd.dj,oe_dd.hsdj,oe_dd.je,oe_dd.shlv,oe_dd.se,oe_dd.je+ oe_dd.se AS jese,oe_dd.khddh,oe_dd.khlh,oe_dd.khjhrq,oe_dd.scjhrq,oe_dd.zxgg,oe_dd.ddmemo,oe_dd.sdjh,oe_dd.sxh FROM oe_dd,rc_cpxx WHERE (oe_dd.cpdm = rc_cpxx.cpdm" & IIf(String.IsNullOrEmpty(Me.LblLbdm.Text), "", " AND rc_cpxx.lbdm = '" & Me.LblLbdm.Text & "'") & " AND oe_dd.djh = ?) order by xh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = ddDjh
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_ddnr") IsNot Nothing Then
                rcDataSet.Tables("rc_ddnr").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_ddnr")
            rcDataGridView.DataSource = rcDataSet.Tables("rc_ddnr")
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
        dblTotSe = 0.0
        If rcDataSet.Tables("rc_ddnr").Rows.Count > 0 Then
            dblTotSl = rcDataSet.Tables("rc_ddnr").Compute("Sum(sl)", "")
            dblTotFzsl = rcDataSet.Tables("rc_ddnr").Compute("Sum(fzsl)", "")
            dblTotJe = rcDataSet.Tables("rc_ddnr").Compute("Sum(je)", "")
            dblTotSe = rcDataSet.Tables("rc_ddnr").Compute("Sum(se)", "")
        End If
        Me.LblSl.Text = "�����ϼƣ�" + Format(dblTotSl, g_FormatSl)
        Me.LblFzsl.Text = "�������ϼƣ�" + Format(dblTotFzsl, g_FormatSl)
        Me.LblJe.Text = "���ϼƣ�" + Format(dblTotJe, g_FormatJe)
        Me.LblSe.Text = "˰��ϼƣ�" + Format(dblTotSe, g_FormatJe)
        Me.LblJese.Text = "��˰�ϼƣ�" + Format(dblTotJe + dblTotSe, g_FormatJe)
    End Sub

#End Region

#Region "���"

    Private Sub BtnSh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSh.Click, MnuiSh.Click
        ShEvent(rcBmb.Current("djh"))
    End Sub

    Private Sub ShEvent(ByVal ddDjh As String)
        Dim i As Integer
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            For i = 0 To rcDataSet.Tables("rc_ddnr").Rows.Count - 1
                rcOleDbCommand.CommandText = "UPDATE oe_dd SET shr = ? WHERE djh = ? AND xh = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@shr", OleDbType.VarChar, 30).Value = g_User_DspName
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = ddDjh
                rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("xh")
                rcOleDbCommand.ExecuteNonQuery()
            Next
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

    Private Sub XsEvent(ByVal ddDjh As String)
        Dim i As Integer
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            For i = 0 To rcDataSet.Tables("rc_ddnr").Rows.Count - 1
                rcOleDbCommand.CommandText = "UPDATE oe_dd SET shr = ? WHERE djh = ? AND xh = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@shr", OleDbType.VarChar, 30).Value = ""
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = ddDjh
                rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("xh")
                rcOleDbCommand.ExecuteNonQuery()
            Next
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
        For i = 0 To rcDataSet.Tables("ddml").Rows.Count - 1
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "UPDATE oe_dd SET shr = ? WHERE djh = ?" & IIf(String.IsNullOrEmpty(Me.LblLbdm.Text), "", " AND EXISTS (SELECT 1 FROM rc_cpxx WHERE rc_cpxx.lbdm = '" & Me.LblLbdm.Text & "' AND rc_cpxx.cpdm = oe_dd.cpdm)")
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@shr", OleDbType.VarChar, 30).Value = g_User_DspName
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Trim(rcDataSet.Tables("ddml").Rows(i).Item("djh"))
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
        For i = 0 To rcDataSet.Tables("ddml").Rows.Count - 1
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "UPDATE oe_dd SET shr = ? WHERE djh = ?" & IIf(String.IsNullOrEmpty(Me.LblLbdm.Text), "", " AND EXISTS (SELECT 1 FROM rc_cpxx WHERE rc_cpxx.lbdm = '" & Me.LblLbdm.Text & "' AND rc_cpxx.cpdm = oe_dd.cpdm)")
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@shr", OleDbType.VarChar, 30).Value = ""
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Trim(rcDataSet.Tables("ddml").Rows(i).Item("djh"))
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
            ShowDd(rcBmb.Current("djh"))
        End If
    End Sub

#End Region

#Region "����"

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click, MnuiNext.Click
        If rcBmb.Count > 0 Then
            If rcBmb.Position <> rcBmb.Count Then
                rcBmb.Position += 1
            End If
            ShowDd(rcBmb.Current("djh"))
        End If
    End Sub

#End Region

#Region "��ӡ����"

    Private Sub MnuiPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPageSetup.Click
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

        rcRps.Text(-1, 1) = g_Dwmc & "�ɹ���"
        rcRps.Text(-1, 2) = DtpQdrq.Value.ToLongDateString
        rcRps.Text(-1, 3) = "���ݺţ�" & Trim(Me.TxtDjh.Text) & "  %p/%t"
        rcRps.Text(-1, 4) = "�ͻ����ϣ�" & Trim(LblKhmc.Text)
        rcRps.Text(-1, 5) = "�����ˣ�(" & Trim(Me.TxtZydm.Text) & ")" & Trim(LblZymc.Text)
        Dim i As Integer
        Dim j As Integer
        For i = 0 To rcDataSet.Tables("rc_ddnr").Rows.Count - 1
            If rcDataSet.Tables("rc_ddnr").Rows(i).RowState <> 8 Then
                If Not rcDataSet.Tables("rc_ddnr").Rows(i).Item("cpdm").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 1) = Trim(rcDataSet.Tables("rc_ddnr").Rows(i).Item("cpdm"))
                End If
                If Not rcDataSet.Tables("rc_ddnr").Rows(i).Item("cpmc").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 2) = Trim(rcDataSet.Tables("rc_ddnr").Rows(i).Item("cpmc"))
                End If
                If Not rcDataSet.Tables("rc_ddnr").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 5) = Trim(rcDataSet.Tables("rc_ddnr").Rows(i).Item("dw"))
                End If
                If Not rcDataSet.Tables("rc_ddnr").Rows(i).Item("hth").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 6) = Trim(rcDataSet.Tables("rc_ddnr").Rows(i).Item("hth"))
                End If
                If Not rcDataSet.Tables("rc_ddnr").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 7) = Format(rcDataSet.Tables("rc_ddnr").Rows(i).Item("sl"), g_FormatSl)
                End If
                If Not rcDataSet.Tables("rc_ddnr").Rows(i).Item("ddmemo").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 8) = Trim(rcDataSet.Tables("rc_ddnr").Rows(i).Item("ddmemo"))
                End If
                j += 1
            End If
        Next
        If Decimal.op_Modulus(rcDataSet.Tables("rc_ddnr").Rows.Count, rcRps.LinesPerPage.ToString) <> 0 Then
            For i = Decimal.op_Modulus(rcDataSet.Tables("rc_ddnr").Rows.Count, rcRps.LinesPerPage.ToString) + 1 To rcRps.LinesPerPage.ToString
                rcRps.Text(j + 1, 1) = ""
                j += 1
            Next
        End If
        rcRps.Text(-1, 6) = "�����ˣ�" & g_User_DspName
    End Sub

#End Region

#Region "�˳�"

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click, MnuiExit.Click
        ExitEvent()
    End Sub

    Private Sub ExitEvent()
        Me.Close()
    End Sub

#End Region

End Class