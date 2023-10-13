Imports System.Data.OleDb

Public Class FrmKhYszkMx
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '����Datatable
    ReadOnly dtKhYszkMx As New DataTable("khyszkmx")

    Private Sub FrmKhYszkMx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        NudYear.Value = Mid(g_Kjqj, 1, 4)
        NudMonthBegin.Value = 1
        NudMonthEnd.Value = Mid(g_Kjqj, 5, 2)
        '����datatable
        dtKhYszkMx.Columns.Add("rq", Type.GetType("System.DateTime"))
        dtKhYszkMx.Columns.Add("djh", Type.GetType("System.String"))
        dtKhYszkMx.Columns.Add("zy", Type.GetType("System.String"))
        dtKhYszkMx.Columns.Add("ysje", Type.GetType("System.Double"))
        dtKhYszkMx.Columns.Add("skje", Type.GetType("System.Double"))
        dtKhYszkMx.Columns.Add("ye", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtKhYszkMx)
        With rcDataset.Tables("khyszkmx")
            .Columns("djh").DefaultValue = ""
            .Columns("zy").DefaultValue = ""
            .Columns("ysje").DefaultValue = 0.0
            .Columns("skje").DefaultValue = 0.0
            .Columns("ye").DefaultValue = 0.0
        End With
    End Sub


#Region "�ͻ������¼�"

    Private Sub TxtKhdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtKhdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_khxx"
                    .paraField1 = "khdm"
                    .paraField2 = "khmc"
                    .paraField3 = "khsm"
                    .paraCondition = "0=0"
                    .paraOrderField = "khmc"
                    .paraTitle = "�ͻ�"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtKhdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub


    Private Sub TxtKhdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtKhdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtKhdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_khxx WHERE (khdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(TxtKhdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_khxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_khxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_khxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_khxx").Rows.Count > 0 Then
                Me.TxtKhdm.Text = Trim(rcDataset.Tables("rc_khxx").Rows(0).Item("khdm"))
                'LblKhmc.Text = Trim(rcDataset.Tables("rc_khxx").Rows(0).Item("khmc"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If String.IsNullOrEmpty(Me.TxtKhdm.Text) Then
            Return
        End If
        '�������
        rcDataset.Tables("khyszkmx").Clear()
        'Dim i As Integer
        Dim j As Integer
        Dim rqBegin As Date
        Dim rqEnd As Date
        Dim dblQcje As Double
        Dim dblYe As Double = 0.0
        'ȡ�ڳ���
        rqBegin = getInvBegin(Me.NudYear.Value, 1)
        rqEnd = getInvBegin(Me.NudYear.Value, Me.NudMonthBegin.Value)
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT COALESCE(Sum(ysje),0.0) As ysje,COALESCE(Sum(skje),0.0) As skje FROM((SELECT (oe_fp.je + oe_fp.se) As ysje,0.0 As skje FROM oe_fp WHERE oe_fp.bdelete = 0 AND khdm = ? and TRUNC(oe_fp.fprq,'dd') >= ? and TRUNC(oe_fp.fprq,'dd') >= ? and oe_fp.fprq < ?) UNION ALL (SELECT 0.0 As ysje,ar_skd.je As skje FROM ar_skd WHERE khdm = ? and ar_skd.skrq >= ? and ar_skd.skrq >= ? and ar_skd.skrq < ?)) tmpmxz "
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(TxtKhdm.Text)
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(TxtKhdm.Text)
            rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = rqEnd
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
        If rcDataset.Tables("qcrkck").Rows(0).Item("ysje").GetType.ToString = "System.DBNull" Then
            rcDataset.Tables("qcrkck").Rows(0).Item("ysje") = 0.0
        End If
        If rcDataset.Tables("qcrkck").Rows(0).Item("skje").GetType.ToString = "System.DBNull" Then
            rcDataset.Tables("qcrkck").Rows(0).Item("skje") = 0.0
        End If
        rqBegin = getInvBegin(NudYear.Value, NudMonthBegin.Value)
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT '" & rqBegin.ToString & "' As rq,'�ڳ����' As zy ,(COALESCE(sum(qcfpje),0.0)+" & rcDataset.Tables("qcrkck").Rows(0).Item("ysje") & "-" & rcDataset.Tables("qcrkck").Rows(0).Item("skje") & ") As ye FROM ar_khyeb WHERE kjnd = ? AND khdm = ? "
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(TxtKhdm.Text)
            If rcDataset.Tables("khyszkmx") IsNot Nothing Then
                rcDataset.Tables("khyszkmx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "khyszkmx")
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If dtKhYszkMx.Rows(dtKhYszkMx.Rows.Count - 1).Item("ye").GetType.ToString <> "System.DBNull" Then
            dblQcje = dtKhYszkMx.Rows(dtKhYszkMx.Rows.Count - 1).Item("ye")
        End If
        dblYe = dblQcje
        rqBegin = getInvBegin(NudYear.Value, NudMonthBegin.Value)
        rqEnd = getInvEnd(NudYear.Value, NudMonthEnd.Value)
        '��ȡ����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "(SELECT oe_fp.fprq As rq,oe_fp.djh,oe_fp.fpmemo || oe_fp.cpdm || oe_fp.cpmc || oe_fp.dw || '��' || oe_fp.xh || '��' As zy,(oe_fp.je + oe_fp.se) As ysje,0.0 As skje FROM oe_fp WHERE oe_fp.bdelete = 0 AND khdm = ? and TRUNC(oe_fp.fprq,'dd') >= ? and TRUNC(oe_fp.fprq,'dd') >= ? and TRUNC(oe_fp.fprq,'dd') <= ?) UNION ALL (SELECT ar_skd.skrq As rq,ar_skd.djh,ar_skd.skmemo As zy,0.0 As ysje,ar_skd.je As skje FROM ar_skd WHERE khdm = ? and ar_skd.skrq >= ? and ar_skd.skrq >= ? and ar_skd.skrq <= ?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(TxtKhdm.Text)
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(TxtKhdm.Text)
            rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            rcOleDbDataAdpt.Fill(rcDataset, "khyszkmx")
        Catch ex As Exception
            MsgBox("�������1��" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '���ºϼ�
        For j = Me.NudMonthBegin.Value To Me.NudMonthEnd.Value
            rqBegin = getInvBegin(Me.NudYear.Value, j)
            rqEnd = getInvEnd(Me.NudYear.Value, j)
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT '" & rqEnd.ToString & "' As rq,'���ºϼ�' As zy ,Coalesce(Sum(ysje),0.0) As ysje,Coalesce(Sum(skje),0.0) As skje," & dblYe & " + Sum(ysje) - Sum(skje) As ye FROM ((SELECT Sum(oe_fp.je + oe_fp.se) As ysje,0.0 As skje FROM oe_fp WHERE oe_fp.bdelete = 0 AND khdm = ? AND TRUNC(oe_fp.fprq,'dd') >= ? AND TRUNC(oe_fp.fprq,'dd') >= ? AND TRUNC(oe_fp.fprq,'dd') <= ?) UNION ALL (SELECT 0.0 As ysje,Sum(ar_skd.je) As skje FROM ar_skd WHERE khdm = ? AND ar_skd.skrq >= ? AND ar_skd.skrq >= ? AND ar_skd.skrq <= ?)) tmpmxz "
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(TxtKhdm.Text)
                rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(TxtKhdm.Text)
                rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                rcOleDbDataAdpt.Fill(rcDataset, "khyszkmx")
                If dtKhYszkMx.Rows(dtKhYszkMx.Rows.Count - 1).Item("ye").GetType.ToString <> "System.DBNull" Then
                    dblYe = dtKhYszkMx.Rows(dtKhYszkMx.Rows.Count - 1).Item("ye")
                Else
                    dtKhYszkMx.Rows(dtKhYszkMx.Rows.Count - 1).Item("ye") = dblYe
                End If
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        Next
        '�����ۼ�
        rqBegin = getInvBegin(NudYear.Value, NudMonthBegin.Value)
        For j = Me.NudMonthBegin.Value To Me.NudMonthEnd.Value
            rqEnd = getInvEnd(Me.NudYear.Value, j)
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT '" & rqEnd.ToString & "' As rq,'�����ۼ�' As zy ,Coalesce(Sum(ysje),0.0) As ysje,Coalesce(Sum(skje),0.0) As skje,0.0 As ye FROM ((SELECT Sum(oe_fp.je + oe_fp.se) As ysje,0.0 As skje FROM oe_fp WHERE oe_fp.bdelete = 0 AND khdm = ? AND TRUNC(oe_fp.fprq,'dd') >= ? AND TRUNC(oe_fp.fprq,'dd') >= ? AND TRUNC(oe_fp.fprq,'dd') <= ?) UNION ALL (SELECT 0.0 As ysje,Sum(ar_skd.je) As skje FROM ar_skd WHERE khdm = ? AND ar_skd.skrq >= ? AND ar_skd.skrq >= ? AND ar_skd.skrq <= ?)) tmpmxz "
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(TxtKhdm.Text)
                rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(TxtKhdm.Text)
                rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                rcOleDbDataAdpt.Fill(rcDataset, "khyszkmx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        Next

        If rcDataset.Tables("khyszkmx").Rows.Count <= 0 Then
            MsgBox("û���������������ݡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        '���ñ�
        Dim rcFrm As New FrmKhYszkMxz
        With rcFrm
            .ParaDataSet = rcDataset
            .paraDataView = New DataView(rcDataset.Tables("khyszkmx"), "TRUE", "rq", DataViewRowState.CurrentRows)
            '.paraDataTable = rcDataset.Tables("khyszkmx")
            .Label2.Text = NudYear.Value & "��" & NudMonthBegin.Value & "����" & NudMonthEnd.Value & "��"
            '.Label3.Text = "��Ʒ��" & Trim(TxtCpdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class