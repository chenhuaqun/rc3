Imports System.Data.OleDb
Public Class FrmOeYpddSh

#Region "�������"
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '���ݸ��´���
    Dim rcOleDbTrans As OleDbTransaction
    '��������
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
#End Region

#Region "��ʼ��"

    Private Sub FrmOeYpddSh_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Ĭ��ֵ
        Me.DtpQdrqBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        Me.DtpQdrqEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
    End Sub

#End Region

#Region "ȷ���¼�"

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        'ȡ����
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT djh FROM oe_ypdd WHERE qdrq >= ? And qdrq <= ? AND SUBSTR(djh,11,5) >= ?  And SUBSTR(djh,11,5) <= ?" & IIf(Me.ChbSh.Checked, " AND oe_ypdd.shr IS NULL", "") & " GROUP BY oe_ypdd.djh ORDER BY djh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@qdrq1", OleDbType.Date, 8).Value = DtpQdrqBegin.Value.Date
            rcOleDbCommand.Parameters.Add("@qdrq2", OleDbType.Date, 8).Value = DtpQdrqEnd.Value.Date
            rcOleDbCommand.Parameters.Add("@djh1", OleDbType.VarChar, 5).Value = NudDjhBegin.Value.ToString.PadLeft(5, "0")
            rcOleDbCommand.Parameters.Add("@djh2", OleDbType.VarChar, 5).Value = NudDjhEnd.Value.ToString.PadLeft(5, "0")
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("ddml") IsNot Nothing Then
                rcDataset.Tables("ddml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "ddml")
        Catch ex As Exception
            Try
                MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Catch ey As OleDbException
                MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            End Try
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("ddml").Rows.Count <= 0 Then
            MsgBox("û���������������ݡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        '���ñ�
        Dim rcFrm As New FrmOeYpddShz
        With rcFrm
            .ParaDataSet = rcDataset
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

#End Region
End Class