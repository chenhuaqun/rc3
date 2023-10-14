Imports System.Data.OleDb

Public Class FrmPoCkdImpLlsq
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    Dim rcDataset As New DataSet
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '�ֿ����
    Dim strCkdm As String = ""
    Dim strBmdm As String = ""
    Dim strBmmc As String = ""
    Dim strZydm As String = ""
    Dim strZymc As String = ""

    Public Property ParaCkdm() As String
        Get
            ParaCkdm = strCkdm
        End Get
        Set(ByVal Value As String)
            strCkdm = Value
        End Set
    End Property

    Public Property ParaBmdm() As String
        Get
            ParaBmdm = strBmdm
        End Get
        Set(ByVal Value As String)
            strBmdm = Value
        End Set
    End Property

    Public Property ParaBmmc() As String
        Get
            ParaBmmc = strBmmc
        End Get
        Set(ByVal Value As String)
            strBmmc = Value
        End Set
    End Property

    Public Property ParaZydm() As String
        Get
            ParaZydm = strZydm
        End Get
        Set(ByVal Value As String)
            strZydm = Value
        End Set
    End Property

    Public Property ParaZymc() As String
        Get
            ParaZymc = strZymc
        End Get
        Set(ByVal Value As String)
            strZymc = Value
        End Set
    End Property

    Public Property ParaDataSet() As DataSet
        Get
            ParaDataSet = rcDataSet
        End Get
        Set(ByVal Value As DataSet)
            rcDataSet = Value
        End Set
    End Property

#Region "�ؼ��س����Ĵ���"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCpdm.KeyPress, TxtCpmc.KeyPress, TxtBmdm.KeyPress, TxtZydm.KeyPress, TxtFadm.KeyPress, TxtDjh.KeyPress
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
                rcOleDbCommand.CommandText = "SELECT cpdm,cpmc,dw,kuwei FROM rc_cpxx WHERE rc_cpxx.cpdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_cpxx") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_cpxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_cpxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_cpxx").Rows.Count = 0 Then
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "���ű�����¼�"

    Private Sub TxtBmdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBmdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_bmxx"
                    .paraField1 = "bmdm"
                    .paraField2 = "bmmc"
                    .paraField3 = "bmsm"
                    .paraTitle = "����"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtBmdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtBmdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtBmdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtBmdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT bmdm,bmmc FROM rc_bmxx WHERE (bmdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(TxtBmdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_bmxx") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_bmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_bmxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_bmxx").Rows.Count <= 0 Then
                MsgBox("���ű��벻���ڣ��밴F3��ѡ��", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "ְԱ������¼�"

    Private Sub TxtZydm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtZydm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_zyxx"
                    .paraField1 = "zydm"
                    .paraField2 = "zymc"
                    .paraField3 = "zysm"
                    .paraTitle = "ְԱ"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtZydm.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtZydm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtZydm.Validating
        If Not String.IsNullOrEmpty(Me.TxtZydm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_zyxx WHERE (zydm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(TxtZydm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_zyxx") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_zyxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_zyxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_zyxx").Rows.Count <= 0 Then
                MsgBox("ְԱ���벻���ڣ��밴F3��ѡ��", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "�豸������¼�"

    Private Sub TxtFadm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFadm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_faxx"
                    .paraField1 = "fadm"
                    .paraField2 = "famc"
                    .paraField3 = "fasm"
                    .paraTitle = "�豸"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        sender.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtFadm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtFadm.Validating
        If Not String.IsNullOrEmpty(sender.Text) Then
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "SELECT * FROM rc_faxx WHERE (fadm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@fadm", OleDbType.VarChar, 12).Value = sender.Text
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_faxx") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_faxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_faxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_faxx").Rows.Count <= 0 Then
                MsgBox("�豸���벻���ڣ��밴F3��ѡ��", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim i As Integer
        Dim j As Integer
        Dim dblCksl As Double
        Dim dblCkje As Double
        'ȡ����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            'ȡ���š��豸��ְԱ
            rcOleDbCommand.CommandText = "SELECT inv_llsq.zydm,inv_llsq.zymc,inv_llsq.bmdm,inv_llsq.bmmc FROM inv_llsq WHERE ((inv_llsq.sl > inv_llsq.cksl AND inv_llsq.sl > 0) OR (inv_llsq.sl < inv_llsq.cksl AND inv_llsq.sl < 0)) AND inv_llsq.bclosed  = 0" & IIf(Me.ChbSh.Checked, " AND NOT inv_llsq.shr IS NULL", "") & IIf(Not String.IsNullOrEmpty(Me.TxtDjh.Text), " AND inv_llsq.djh = '" & Trim(Me.TxtDjh.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " and inv_llsq.cpdm = '" & Trim(Me.TxtCpdm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpmc.Text), " and inv_llsq.cpmc Like '%" & Trim(Me.TxtCpmc.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " and inv_llsq.bmdm LIKE '" & Trim(Me.TxtBmdm.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtZydm.Text), " and inv_llsq.zydm = '" & Trim(Me.TxtZydm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtFadm.Text), " and inv_llsq.fadm = '" & Trim(Me.TxtFadm.Text) & "'", "") & " ORDER BY inv_llsq.djh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("inv_llsqml") IsNot Nothing Then
                rcDataSet.Tables("inv_llsqml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "inv_llsqml")
            If rcDataSet.Tables("inv_llsqml").Rows.Count > 0 Then
                Me.TxtBmdm.Text = rcDataSet.Tables("inv_llsqml").Rows(0).Item("bmdm")
                strBmdm = rcDataSet.Tables("inv_llsqml").Rows(0).Item("bmdm")
                strBmmc = rcDataSet.Tables("inv_llsqml").Rows(0).Item("bmmc")
                'Me.TxtFadm.Text = rcDataSet.Tables("inv_llsqml").Rows(0).Item("fadm")
                Me.TxtZydm.Text = rcDataSet.Tables("inv_llsqml").Rows(0).Item("zydm")
                strZydm = rcDataSet.Tables("inv_llsqml").Rows(0).Item("zydm")
                strZymc = rcDataSet.Tables("inv_llsqml").Rows(0).Item("zymc")
            End If
            'ȡ������Ϣ
            rcOleDbCommand.CommandText = "SELECT inv_llsq.cpdm,rc_cpxx.oldcpdm,rc_cpxx.cpmc,inv_llsq.csdm,inv_llsq.csmc,rc_cpxx.brecycling,rc_cpxx.bfadm,inv_llsq.fadm,inv_llsq.famc,rc_cpxx.kuwei,'' AS pihao,(inv_llsq.sl - inv_llsq.cksl) As sl,rc_cpxx.dw,0.0 AS dj,0.0 AS je,inv_llsq.sqmemo AS ckmemo,inv_llsq.djh AS llsqdjh,inv_llsq.xh AS llsqxh FROM inv_llsq,rc_cpxx WHERE inv_llsq.cpdm = rc_cpxx.cpdm AND ((inv_llsq.sl > inv_llsq.cksl AND inv_llsq.sl > 0) OR (inv_llsq.sl < inv_llsq.cksl AND inv_llsq.sl < 0)) AND inv_llsq.bclosed  = 0" & IIf(Me.ChbSh.Checked, " AND NOT inv_llsq.shr IS NULL", "") & IIf(Not String.IsNullOrEmpty(Me.TxtDjh.Text), " and inv_llsq.djh = '" & Trim(Me.TxtDjh.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " and inv_llsq.cpdm = '" & Trim(Me.TxtCpdm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpmc.Text), " and inv_llsq.cpmc Like '%" & Trim(Me.TxtCpmc.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " and inv_llsq.bmdm LIKE '" & Trim(Me.TxtBmdm.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtZydm.Text), " and inv_llsq.zydm = '" & Trim(Me.TxtZydm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtFadm.Text), " and inv_llsq.fadm = '" & Trim(Me.TxtFadm.Text) & "'", "") & " ORDER BY inv_llsq.xh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_ckdnr") IsNot Nothing Then
                rcDataSet.Tables("rc_ckdnr").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_ckdnr")
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("rc_ckdnr").Rows.Count <= 0 Then
            MsgBox("û���������������ݡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        'ȡ������Ϣ������
        For i = 0 To rcDataSet.Tables("rc_ckdnr").Rows.Count - 1
            dblCkje = 0.0
            If rcDataSet.Tables("rc_ckdnr").Rows(i).Item("sl") > 0 Then
                If rcDataSet.Tables("rc_ckdnr").Rows(i).Item("csdm").GetType.ToString <> "System.DBNull" Then
                    dblCksl = ReadCsKcsl(rcDataset.Tables("rc_ckdnr").Rows(i).Item("cpdm"), rcDataset.Tables("rc_ckdnr").Rows(i).Item("csdm"), strCkdm, "")
                Else
                    dblCksl = ReadKcsl(Mid(g_Kjqj, 1, 4), rcDataSet.Tables("rc_ckdnr").Rows(i).Item("cpdm"), strCkdm, "")
                End If
                '��������
                Try
                    rcOleDbConn.Open()
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    If rcDataSet.Tables("rc_ckdnr").Rows(i).Item("csdm").GetType.ToString <> "System.DBNull" Then
                        rcOleDbCommand.CommandText = "SELECT COALESCE(SUM(po_rkd.sl),0.0) AS sl,COALESCE(SUM(po_rkd.cksl),0.0) AS cksl,COALESCE(SUM(po_rkd.je),0.0) AS je,COALESCE(SUM(po_rkd.ckje),0.0) AS ckje FROM po_rkd WHERE po_rkd.bdelete = 0 AND po_rkd.sl <> po_rkd.cksl AND po_rkd.ckdm = ? AND po_rkd.cpdm = ? AND po_rkd.csdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = strCkdm
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataSet.Tables("rc_ckdnr").Rows(i).Item("cpdm")
                        rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("rc_ckdnr").Rows(i).Item("csdm")
                    Else
                        rcOleDbCommand.CommandText = "SELECT COALESCE(SUM(inv_rkd.sl),0.0) AS sl,COALESCE(SUM(inv_rkd.cksl),0.0) AS cksl,COALESCE(SUM(inv_rkd.je),0.0) AS je,COALESCE(SUM(inv_rkd.ckje),0.0) AS ckje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND inv_rkd.sl <> inv_rkd.cksl AND inv_rkd.ckdm = ? AND inv_rkd.cpdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = strCkdm
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataSet.Tables("rc_ckdnr").Rows(i).Item("cpdm")
                    End If
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataSet.Tables("po_rkd") IsNot Nothing Then
                        rcDataSet.Tables("po_rkd").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataSet, "po_rkd")
                Catch ex As Exception
                    MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                    Return
                Finally
                    rcOleDbConn.Close()
                End Try
                If rcDataSet.Tables("po_rkd").Rows.Count > 0 Then
                    For j = 0 To rcDataSet.Tables("po_rkd").Rows.Count - 1
                        If rcDataSet.Tables("rc_ckdnr").Rows(i).Item("sl") - dblCksl >= rcDataSet.Tables("po_rkd").Rows(j).Item("sl") - rcDataSet.Tables("po_rkd").Rows(j).Item("cksl") Then
                            dblCksl = dblCksl + rcDataSet.Tables("po_rkd").Rows(j).Item("sl") - rcDataSet.Tables("po_rkd").Rows(j).Item("cksl")
                            dblCkje = dblCkje + rcDataSet.Tables("po_rkd").Rows(j).Item("je") - rcDataSet.Tables("po_rkd").Rows(j).Item("ckje")
                        Else
                            dblCksl = rcDataSet.Tables("rc_ckdnr").Rows(i).Item("sl")
                            dblCkje = (rcDataSet.Tables("po_rkd").Rows(j).Item("je") - rcDataSet.Tables("po_rkd").Rows(j).Item("ckje")) / (rcDataSet.Tables("po_rkd").Rows(j).Item("sl") - rcDataSet.Tables("po_rkd").Rows(j).Item("cksl")) * rcDataSet.Tables("rc_ckdnr").Rows(i).Item("sl")
                            Exit For
                        End If
                    Next
                    '���Ƴ�������
                    rcDataSet.Tables("rc_ckdnr").Rows(i).Item("sl") = dblCksl
                    rcDataSet.Tables("rc_ckdnr").Rows(i).Item("je") = dblCkje
                    If rcDataSet.Tables("rc_ckdnr").Rows(i).Item("sl") <> 0 Then
                        rcDataSet.Tables("rc_ckdnr").Rows(i).Item("dj") = rcDataSet.Tables("rc_ckdnr").Rows(i).Item("je") / rcDataSet.Tables("rc_ckdnr").Rows(i).Item("sl")
                    End If
                Else
                    rcDataSet.Tables("rc_ckdnr").Rows(i).Item("sl") = 0
                    rcDataSet.Tables("rc_ckdnr").Rows(i).Item("je") = 0
                End If
            Else
                'ȡ���һ�ʳ���ĵ���
                Try
                    rcOleDbConn.Open()
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    rcOleDbCommand.CommandText = "SELECT po_rkd.cksl,po_rkd.ckje FROM po_rkd WHERE po_rkd.cksl > 0 AND po_rkd.ckdm = ? AND po_rkd.cpdm = ? AND po_rkd.csdm = ? ORDER BY djh DESC,xh DESC"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = strCkdm
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataSet.Tables("rc_ckdnr").Rows(i).Item("cpdm")
                    rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("rc_ckdnr").Rows(i).Item("csdm")
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataSet.Tables("po_rkd") IsNot Nothing Then
                        rcDataSet.Tables("po_rkd").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataSet, "po_rkd")
                Catch ex As Exception
                    MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                    Return
                Finally
                    rcOleDbConn.Close()
                End Try
                If rcDataSet.Tables("po_rkd").Rows.Count > 0 Then
                    rcDataSet.Tables("rc_ckdnr").Rows(i).Item("dj") = rcDataSet.Tables("po_rkd").Rows(0).Item("ckje") / rcDataSet.Tables("po_rkd").Rows(0).Item("cksl")
                    rcDataSet.Tables("rc_ckdnr").Rows(i).Item("je") = rcDataSet.Tables("rc_ckdnr").Rows(i).Item("dj") * rcDataSet.Tables("rc_ckdnr").Rows(i).Item("sl")
                End If
            End If
        Next
    End Sub
End Class