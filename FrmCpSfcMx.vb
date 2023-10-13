Imports System.Data.OleDb

Public Class FrmCpSfcMx
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '����Datatable
    ReadOnly dtCpsfcMx As New DataTable("cpsfcmx")

    Private Sub FrmCpSfcMx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        NudYear.Value = Mid(g_Kjqj, 1, 4)
        NudMonthBegin.Value = 1
        NudMonthEnd.Value = Mid(g_Kjqj, 5, 2)
        '����datatable
        dtCpsfcMx.Columns.Add("rq", Type.GetType("System.DateTime"))
        dtCpsfcMx.Columns.Add("djh", Type.GetType("System.String"))
        dtCpsfcMx.Columns.Add("zy", Type.GetType("System.String"))
        dtCpsfcMx.Columns.Add("rksl", Type.GetType("System.Double"))
        dtCpsfcMx.Columns.Add("rkdj", Type.GetType("System.Double"))
        dtCpsfcMx.Columns.Add("rkje", Type.GetType("System.Double"))
        dtCpsfcMx.Columns.Add("cksl", Type.GetType("System.Double"))
        dtCpsfcMx.Columns.Add("ckdj", Type.GetType("System.Double"))
        dtCpsfcMx.Columns.Add("ckje", Type.GetType("System.Double"))
        dtCpsfcMx.Columns.Add("jcsl", Type.GetType("System.Double"))
        dtCpsfcMx.Columns.Add("jcdj", Type.GetType("System.Double"))
        dtCpsfcMx.Columns.Add("jcje", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtCpsfcMx)
        With rcDataset.Tables("cpsfcmx")
            .Columns("djh").DefaultValue = ""
            .Columns("zy").DefaultValue = ""
            .Columns("rksl").DefaultValue = 0.0
            .Columns("rkdj").DefaultValue = 0.0
            .Columns("rkje").DefaultValue = 0.0
            .Columns("cksl").DefaultValue = 0.0
            .Columns("ckdj").DefaultValue = 0.0
            .Columns("ckje").DefaultValue = 0.0
            .Columns("jcsl").DefaultValue = 0.0
            .Columns("jcdj").DefaultValue = 0.0
            .Columns("jcje").DefaultValue = 0.0
        End With
    End Sub

#Region "�ؼ��س����Ĵ���"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NudYear.KeyPress, NudMonthBegin.KeyPress, NudMonthEnd.KeyPress, TxtCkdm.KeyPress, TxtCpdm.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "���ϱ����¼�"

    Private Sub TxtCpdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCpdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF34
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_cpxx"
                    .paraField1 = "cpdm"
                    .paraField2 = "cpmc"
                    .paraField3 = "dw"
                    .paraField4 = "cpsm"
                    .paraOrderField = "cpmc"
                    .paraTitle = "����"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtCpdm.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtCpdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCpdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtCpdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT cpdm,cpmc,dw,kuwei FROM rc_cpxx WHERE (cpdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_cpxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_cpxx").Rows.Count = 0 Then
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "�ֿ������¼�"

    Private Sub TxtCkdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCkdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_ckxx"
                    .paraField1 = "ckdm"
                    .paraField2 = "ckmc"
                    .paraField3 = "cksm"
                    .paraTitle = "�ֿ�"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtCkdm.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtCkdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCkdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtCkdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_ckxx WHERE (ckdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(TxtCkdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_ckxx") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_ckxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_ckxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_ckxx").Rows.Count > 0 Then
                Me.TxtCkdm.Text = Trim(rcDataSet.Tables("rc_ckxx").Rows(0).Item("ckdm"))
                'Me.LblCkmc.Text = Trim(rcDataSet.Tables("rc_ckxx").Rows(0).Item("ckmc"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If String.IsNullOrEmpty(Me.TxtCpdm.Text) Then
            MsgBox("���ϱ��벻��Ϊ�ա�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        '�������
        rcDataset.Tables("cpsfcmx").Clear()
        'Dim i As Integer
        Dim j As Integer
        Dim rqBegin As Date
        Dim rqEnd As Date
        Dim dblQcsl As Double
        Dim dblQcje As Double
        Dim dblJcsl As Double = 0.0
        Dim dblJcje As Double = 0.0
        rqBegin = GetInvBegin(NudYear.Value, NudMonthBegin.Value)
        rqEnd = GetInvEnd(NudYear.Value, NudMonthEnd.Value)
        '��ȡ����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "(SELECT inv_rkd.rkrq As rq,inv_rkd.djh,inv_rkd.rkmemo || '�ͻ�:' || inv_rkd.khdm || '��' || inv_rkd.xh || '��' As zy,inv_rkd.sl As rksl,inv_rkd.dj AS rkdj,inv_rkd.je As rkje,0.0 As cksl,0.0 AS ckdj,0.0 As ckje FROM inv_rkd WHERE inv_rkd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? and inv_rkd.rkrq >= ? and inv_rkd.rkrq >= ? and inv_rkd.rkrq <= ?)" &
                " UNION ALL (SELECT po_rkd.rkrq As rq,po_rkd.djh,po_rkd.rkmemo || '��Ӧ��:(' || po_rkd.csdm || ')' || po_rkd.csmc || '��' || po_rkd.xh || '��' As zy,po_rkd.sl As rksl,po_rkd.dj AS rkdj,po_rkd.je As rkje,0.0 As cksl,0.0 AS ckdj,0.0 As ckje FROM po_rkd WHERE po_rkd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND po_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? and po_rkd.rkrq >= ? and po_rkd.rkrq >= ? and po_rkd.rkrq <= ?)" &
                " UNION ALL (SELECT TRUNC(inv_dbd.dbrq,'mi') As rq,inv_dbd.djh,inv_dbd.dbmemo || '�����ֿ�' || inv_dbd.cckdm || '��' || inv_dbd.xh || '��' As zy,inv_dbd.sl As rksl,inv_dbd.dj AS rkdj,inv_dbd.je As rkje,0.0 As cksl,0.0 AS ckdj,0.0 As ckje FROM inv_dbd WHERE inv_dbd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.rckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ?)" &
                " UNION ALL (SELECT oe_xsd.xsrq As rq,oe_xsd.djh,oe_xsd.xsmemo || '�ͻ�:(' || oe_xsd.khdm  || ')' || oe_xsd.khmc|| '��' || oe_xsd.xh || '��' AS zy,0.0 As rksl,0.0 AS rkdj,0.0 As rkje,oe_xsd.sl As cksl,oe_xsd.cbdj AS ckdj,oe_xsd.cbje As ckje FROM oe_xsd WHERE oe_xsd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND oe_xsd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq <= ?)" &
                " UNION ALL (SELECT inv_ckd.ckrq As rq,inv_ckd.djh,inv_ckd.ckmemo || '��' || inv_ckd.xh || '��' || '��Ӧ��:' || inv_ckd.csdm AS zy,0.0 As rksl,0.0 AS rkdj,0.0 As rkje,inv_ckd.sl As cksl,inv_ckd.dj AS ckdj,inv_ckd.je As ckje FROM inv_ckd WHERE inv_ckd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_ckd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? and inv_ckd.ckrq >= ? and inv_ckd.ckrq >= ? and inv_ckd.ckrq <= ?)" &
                " UNION ALL (SELECT TRUNC(inv_dbd.dbrq,'mi') As rq,inv_dbd.djh,inv_dbd.dbmemo || '����ֿ�' || inv_dbd.rckdm || '��' || inv_dbd.xh || '��' AS zy,0.0 As rksl,0.0 AS rkdj,0.0 As rkje,inv_dbd.sl As cksl,inv_dbd.dj AS ckdj,inv_dbd.je As ckje FROM inv_dbd WHERE inv_dbd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.cckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("cpsfcmx") IsNot Nothing Then
                rcDataset.Tables("cpsfcmx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "cpsfcmx")
        Catch ex As Exception
            MsgBox("�������1��" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        'ȡ�ڳ���
        rqBegin = GetInvBegin(Me.NudYear.Value, 1)
        rqEnd = GetInvBegin(Me.NudYear.Value, Me.NudMonthBegin.Value)
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT sum(rksl) As rksl,Sum(rkje) As rkje,sum(cksl) As cksl,Sum(ckje) As ckje FROM (" &
                "(SELECT inv_rkd.sl As rksl,inv_rkd.je As rkje,0.0 As cksl,0.0 As ckje FROM inv_rkd WHERE inv_rkd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? and inv_rkd.rkrq >= ? and inv_rkd.rkrq >= ? and inv_rkd.rkrq < ?)" &
                " UNION ALL (SELECT po_rkd.sl As rksl,po_rkd.je As rkje,0.0 As cksl,0.0 As ckje FROM po_rkd WHERE po_rkd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND po_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? and po_rkd.rkrq >= ? and po_rkd.rkrq >= ? and po_rkd.rkrq < ?)" &
                " UNION ALL (SELECT inv_dbd.sl As rksl,inv_dbd.je As rkje,0.0 As cksl,0.0 As ckje FROM inv_dbd WHERE inv_dbd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.rckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ?)" &
                " UNION ALL (SELECT 0.0 As rksl,0.0 As rkje,oe_xsd.sl As cksl,oe_xsd.cbje As ckje FROM oe_xsd WHERE oe_xsd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND oe_xsd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq < ?)" &
                " UNION ALL (SELECT 0.0 As rksl,0.0 As rkje,inv_ckd.sl As cksl,inv_ckd.je As ckje FROM inv_ckd WHERE inv_ckd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_ckd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? and inv_ckd.ckrq >= ? and inv_ckd.ckrq >= ? and inv_ckd.ckrq < ?)" &
                " UNION ALL (SELECT 0.0 As rksl,0.0 As rkje,inv_dbd.sl As cksl,inv_dbd.je As ckje FROM inv_dbd WHERE inv_dbd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.cckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ?)) tmpmxz "
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("qcrkck") IsNot Nothing Then
                rcDataset.Tables("qcrkck").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "qcrkck")
        Catch ex As Exception
            MsgBox("�������2��" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("qcrkck").Rows(0).Item("rksl").GetType.ToString = "System.DBNull" Then
            rcDataset.Tables("qcrkck").Rows(0).Item("rksl") = 0.0
        End If
        If rcDataset.Tables("qcrkck").Rows(0).Item("rkje").GetType.ToString = "System.DBNull" Then
            rcDataset.Tables("qcrkck").Rows(0).Item("rkje") = 0.0
        End If
        If rcDataset.Tables("qcrkck").Rows(0).Item("cksl").GetType.ToString = "System.DBNull" Then
            rcDataset.Tables("qcrkck").Rows(0).Item("cksl") = 0.0
        End If
        If rcDataset.Tables("qcrkck").Rows(0).Item("ckje").GetType.ToString = "System.DBNull" Then
            rcDataset.Tables("qcrkck").Rows(0).Item("ckje") = 0.0
        End If
        rqBegin = GetInvBegin(NudYear.Value, NudMonthBegin.Value)
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT '" & rqBegin.ToString & "' As rq,'�ڳ����' As zy ,(sum(qcsl)+" & rcDataset.Tables("qcrkck").Rows(0).Item("rksl") & "-" & rcDataset.Tables("qcrkck").Rows(0).Item("cksl") & ") As jcsl,CASE WHEN (sum(qcsl)+" & rcDataset.Tables("qcrkck").Rows(0).Item("rksl") & "-" & rcDataset.Tables("qcrkck").Rows(0).Item("cksl") & ") <> 0 THEN (sum(qcje)+" & rcDataset.Tables("qcrkck").Rows(0).Item("rkje") & "-" & rcDataset.Tables("qcrkck").Rows(0).Item("ckje") & ") / (sum(qcsl)+" & rcDataset.Tables("qcrkck").Rows(0).Item("rksl") & "-" & rcDataset.Tables("qcrkck").Rows(0).Item("cksl") & ") ELSE 0 END AS jcdj,(sum(qcje)+" & rcDataset.Tables("qcrkck").Rows(0).Item("rkje") & "-" & rcDataset.Tables("qcrkck").Rows(0).Item("ckje") & ") As jcje FROM inv_cpyeb WHERE kjnd = ? AND cpdm = ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_cpyeb.ckdm ='" & Me.TxtCkdm.Text & "'", "")
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
            rcOleDbDataAdpt.Fill(rcDataset, "cpsfcmx")
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If dtCpsfcMx.Rows(dtCpsfcMx.Rows.Count - 1).Item("jcsl").GetType.ToString <> "System.DBNull" Then
            dblQcsl = dtCpsfcMx.Rows(dtCpsfcMx.Rows.Count - 1).Item("jcsl")
            dblQcje = dtCpsfcMx.Rows(dtCpsfcMx.Rows.Count - 1).Item("jcje")
        End If
        dblJcsl = dblQcsl
        dblJcje = dblQcje
        '���ºϼ�
        For j = Me.NudMonthBegin.Value To Me.NudMonthEnd.Value
            rqBegin = GetInvBegin(Me.NudYear.Value, j)
            rqEnd = GetInvEnd(Me.NudYear.Value, j)
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT '" & rqEnd.ToString & "' As rq,'���ºϼ�' As zy ,Coalesce(Sum(rksl),0.0) As rksl,CASE WHEN Coalesce(Sum(rksl),0.0) <> 0 THEN Coalesce(Sum(rkje),0.0) / Coalesce(Sum(rksl),0.0) ELSE 0.0 END AS rkdj,Coalesce(Sum(rkje),0.0) As rkje,Coalesce(sum(cksl),0.0) As cksl,CASE WHEN Coalesce(Sum(cksl),0.0) <> 0 THEN Coalesce(Sum(ckje),0.0) / Coalesce(Sum(cksl),0.0) ELSE 0.0 END AS ckdj,Coalesce(Sum(ckje),0.0) As ckje," & dblJcsl & " + Sum(rksl) - Sum(cksl) As jcsl,CASE WHEN " & dblJcsl & " + Sum(rksl) - Sum(cksl) <> 0 THEN (" & dblJcje & " + Sum(rkje) - Sum(ckje)) / (" & dblJcsl & " + Sum(rksl) - Sum(cksl)) ELSE 0 END AS jcdj," & dblJcje & " + Sum(rkje) - Sum(ckje) As jcje FROM (" &
                    "(SELECT Sum(inv_rkd.sl) As rksl,Sum(inv_rkd.je) As rkje,0.0 As cksl,0.0 As ckje FROM inv_rkd WHERE inv_rkd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? AND inv_rkd.rkrq >= ? AND inv_rkd.rkrq >= ? AND inv_rkd.rkrq <= ?)" &
                    " UNION ALL (SELECT Sum(po_rkd.sl) As rksl,Sum(po_rkd.je) As rkje,0.0 As cksl,0.0 As ckje FROM po_rkd WHERE po_rkd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND po_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? AND po_rkd.rkrq >= ? AND po_rkd.rkrq >= ? AND po_rkd.rkrq <= ?)" &
                    " UNION ALL (SELECT Sum(inv_dbd.sl) As rksl,Sum(inv_dbd.je) As rkje,0.0 As cksl,0.0 As ckje FROM inv_dbd WHERE inv_dbd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.rckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? AND TRUNC(inv_dbd.dbrq,'mi') >= ? AND TRUNC(inv_dbd.dbrq,'mi') >= ? AND TRUNC(inv_dbd.dbrq,'mi') <= ?)" &
                    " UNION ALL (SELECT 0.0 As rksl,0.0 As rkje,Sum(oe_xsd.sl) As cksl,Sum(oe_xsd.cbje) As ckje FROM oe_xsd WHERE oe_xsd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND oe_xsd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? AND oe_xsd.xsrq >= ? AND oe_xsd.xsrq >= ? AND oe_xsd.xsrq <= ?)" &
                    " UNION ALL (SELECT 0.0 As rksl,0.0 As rkje,Sum(inv_ckd.sl) As cksl,Sum(inv_ckd.je) As ckje FROM inv_ckd WHERE inv_ckd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_ckd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? AND inv_ckd.ckrq >= ? AND inv_ckd.ckrq >= ? AND inv_ckd.ckrq <= ?)" &
                    " UNION ALL (SELECT 0.0 As rksl,0.0 As rkje,Sum(inv_dbd.sl) As cksl,Sum(inv_dbd.je) As ckje FROM inv_dbd WHERE inv_dbd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.cckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? AND TRUNC(inv_dbd.dbrq,'mi') >= ? AND TRUNC(inv_dbd.dbrq,'mi') >= ? AND TRUNC(inv_dbd.dbrq,'mi') <= ?)) tmpmxz "
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                rcOleDbDataAdpt.Fill(rcDataset, "cpsfcmx")
                If dtCpsfcMx.Rows(dtCpsfcMx.Rows.Count - 1).Item("jcsl").GetType.ToString <> "System.DBNull" Then
                    dblJcsl = dtCpsfcMx.Rows(dtCpsfcMx.Rows.Count - 1).Item("jcsl")
                    dblJcje = dtCpsfcMx.Rows(dtCpsfcMx.Rows.Count - 1).Item("jcje")
                Else
                    dtCpsfcMx.Rows(dtCpsfcMx.Rows.Count - 1).Item("jcsl") = dblJcsl
                    dtCpsfcMx.Rows(dtCpsfcMx.Rows.Count - 1).Item("jcje") = dblJcje
                End If
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        Next
        '�����ۼ�
        rqBegin = GetInvBegin(NudYear.Value, NudMonthBegin.Value)
        For j = Me.NudMonthBegin.Value To Me.NudMonthEnd.Value
            rqEnd = GetInvEnd(Me.NudYear.Value, j)
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT '" & rqEnd.ToString & "' As rq,'�����ۼ�' As zy ,Coalesce(Sum(rksl),0.0) As rksl,CASE WHEN Coalesce(Sum(rksl),0.0) <> 0 THEN Coalesce(Sum(rkje),0.0) / Coalesce(Sum(rksl),0.0) ELSE 0.0 END AS rkdj,Coalesce(Sum(rkje),0.0) As rkje,Coalesce(sum(cksl),0.0) As cksl,CASE WHEN Coalesce(Sum(cksl),0.0) <> 0 THEN Coalesce(Sum(ckje),0.0) / Coalesce(Sum(cksl),0.0) ELSE 0.0 END AS ckdj,Coalesce(Sum(ckje),0.0) As ckje,0.0 As jcsl,0.0 As jcje FROM (" &
                    "(SELECT Sum(inv_rkd.sl) As rksl,Sum(inv_rkd.je) As rkje,0.0 As cksl,0.0 As ckje FROM inv_rkd WHERE inv_rkd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? AND inv_rkd.rkrq >= ? AND inv_rkd.rkrq >= ? AND inv_rkd.rkrq <= ?)" &
                    " UNION ALL (SELECT Sum(po_rkd.sl) As rksl,Sum(po_rkd.je) As rkje,0.0 As cksl,0.0 As ckje FROM po_rkd WHERE po_rkd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND po_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? AND po_rkd.rkrq >= ? AND po_rkd.rkrq >= ? AND po_rkd.rkrq <= ?)" &
                    " UNION ALL (SELECT Sum(inv_dbd.sl) As rksl,Sum(inv_dbd.je) As rkje,0.0 As cksl,0.0 As ckje FROM inv_dbd WHERE inv_dbd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.rckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? AND TRUNC(inv_dbd.dbrq,'mi') >= ? AND TRUNC(inv_dbd.dbrq,'mi') >= ? AND TRUNC(inv_dbd.dbrq,'mi') <= ?)" &
                    " UNION ALL (SELECT 0.0 As rksl,0.0 As rkje,Sum(oe_xsd.sl) As cksl,Sum(oe_xsd.cbje) As ckje FROM oe_xsd WHERE oe_xsd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND oe_xsd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? AND oe_xsd.xsrq >= ? AND oe_xsd.xsrq >= ? AND oe_xsd.xsrq <= ?)" &
                    " UNION ALL (SELECT 0.0 As rksl,0.0 As rkje,Sum(inv_ckd.sl) As cksl,Sum(inv_ckd.je) As ckje FROM inv_ckd WHERE inv_ckd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_ckd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? AND inv_ckd.ckrq >= ? AND inv_ckd.ckrq >= ? AND inv_ckd.ckrq <= ?)" &
                    " UNION ALL (SELECT 0.0 As rksl,0.0 As rkje,Sum(inv_dbd.sl) As cksl,Sum(inv_dbd.je) As ckje FROM inv_dbd WHERE inv_dbd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.cckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? AND TRUNC(inv_dbd.dbrq,'mi') >= ? AND TRUNC(inv_dbd.dbrq,'mi') >= ? AND TRUNC(inv_dbd.dbrq,'mi') <= ?)) tmpmxz "
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                rcOleDbDataAdpt.Fill(rcDataset, "cpsfcmx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        Next

        If rcDataset.Tables("cpsfcmx").Rows.Count <= 0 Then
            MsgBox("û���������������ݡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        '���ñ�
        Dim rcFrm As New FrmCpSfcMxz
        With rcFrm
            .paraDataSet = rcDataset
            .paraDataView = New DataView(rcDataset.Tables("cpsfcmx"), "TRUE", "rq,zy", DataViewRowState.CurrentRows)
            '.paraDataTable = rcDataset.Tables("cpsfcmx")
            .Label2.Text = NudYear.Value & "��" & NudMonthBegin.Value & "����" & NudMonthEnd.Value & "��"
            If rcDataset.Tables("rc_cpxx").Rows.Count > 0 Then
                .Label3.Text = "���ϣ�(" & Me.TxtCpdm.Text & ")" & rcDataset.Tables("rc_cpxx").Rows(0).Item("cpmc") & " " & rcDataset.Tables("rc_cpxx").Rows(0).Item("dw")
            End If
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class