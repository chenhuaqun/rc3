Imports System.Data.OleDb

Public Class FrmFkdCx

#Region "�������"

    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

#End Region

#Region "��ʼ���¼�"

    Private Sub FrmFkdCx_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Ĭ��ֵ
        Me.DtpBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        Me.DtpEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
    End Sub

#End Region

#Region "�ؼ��س����Ĵ���"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpBegin.KeyPress, DtpEnd.KeyPress, NudDjhBegin.KeyPress, NudDjhEnd.KeyPress, TxtCsdm.KeyPress, TxtKmdm.KeyPress, TxtYspz.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "��Ӧ�̱����¼�"

    Private Sub TxtCsdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCsdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_csxx"
                    .paraField1 = "csdm"
                    .paraField2 = "csmc"
                    .paraField3 = "cssm"
                    .paraCondition = "0=0"
                    .paraOrderField = "csmc"
                    .paraTitle = "��Ӧ��"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtCsdm.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

#End Region

#Region "��Ŀ������¼�"

    Private Sub TxtKmdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtKmdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "gl_kmxx"
                    .paraField1 = "kmdm"
                    .paraField2 = "kmmc"
                    .paraField3 = "kmsm"
                    .paraCondition = "0=0"
                    .paraOrderField = "kmdm"
                    .paraTitle = "��Ŀ"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtKmdm.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

#End Region

#Region "δ�����¼�"

    Private Sub ChbWhx_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbWhx.CheckedChanged
        If Me.ChbWhx.Checked Then
            Me.DtpBegin.Enabled = False
            Me.DtpEnd.Enabled = False
            Me.NudDjhBegin.Enabled = False
            Me.NudDjhEnd.Enabled = False
        Else
            Me.DtpBegin.Enabled = True
            Me.DtpEnd.Enabled = True
            Me.NudDjhBegin.Enabled = True
            Me.NudDjhEnd.Enabled = True
        End If
    End Sub

#End Region


#Region "ȷ���¼�"

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        ''ȡ����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT ap_fkd.djh,ap_fkd.fkrq,ap_fkd.csdm,ap_fkd.csmc,ap_fkd.kmdm,ap_fkd.kmmc,ap_fkd.yspz,ap_fkd.je,ap_fkd.rkje,ap_fkd.fkmemo,ap_fkd.srr,ap_fkd.shr,ap_fkd.jzr FROM ap_fkd WHERE" & IIf(Me.ChbWhx.Checked, " ap_fkd.je <> ap_fkd.rkje", " ap_fkd.fkrq >= ? AND ap_fkd.fkrq <= ? AND SUBSTR(ap_fkd.djh,11,5) >= ?  AND SUBSTR(ap_fkd.djh,11,5) <= ?") & IIf(Not String.IsNullOrEmpty(Me.TxtCsdm.Text), " and ap_fkd.csdm LIKE '" & LTrim(Me.TxtCsdm.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtKmdm.Text), " and ap_fkd.kmdm LIKE '" & LTrim(Me.TxtKmdm.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtYspz.Text), " and ap_fkd.yspz LIKE '" & LTrim(Me.TxtYspz.Text) & "%'", "") & " ORDER BY ap_fkd.djh"
            rcOleDbCommand.Parameters.Clear()
            If Not Me.ChbWhx.Checked Then
                rcOleDbCommand.Parameters.Add("@fkrq1", OleDbType.Date, 8).Value = DtpBegin.Value
                rcOleDbCommand.Parameters.Add("@fkrq2", OleDbType.Date, 8).Value = Me.DtpEnd.Value
                rcOleDbCommand.Parameters.Add("@djh1", OleDbType.VarChar, 5).Value = NudDjhBegin.Value.ToString.PadLeft(5, "0")
                rcOleDbCommand.Parameters.Add("@djh2", OleDbType.VarChar, 5).Value = NudDjhEnd.Value.ToString.PadLeft(5, "0")
            End If
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("fkdlb") IsNot Nothing Then
                rcDataset.Tables("fkdlb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "fkdlb")
        Catch ex As Exception
            MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("fkdlb").Rows.Count <= 0 Then
            MsgBox("û���������������ݡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        '���ñ�
        Dim rcFrm As New FrmFkdCxLb
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("fkdlb"), "TRUE", "djh", DataViewRowState.CurrentRows)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

#End Region
End Class