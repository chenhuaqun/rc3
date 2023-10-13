Imports System.Data.OleDb

Public Class FrmOeYpddXdb

#Region "�������"

    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '��ʾҪ������Դִ�е� SQL ����
    Dim rcOleDbTrans As OleDbTransaction
    '�����������
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

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
            rcOleDbCommand.CommandText = "Select ���ݺ�,��ͬ����,�ͻ�����,�ͻ�����,�ջ���,�ͻ��Ϻ�,��Ʒ����,�ͺŹ��,��������,��������,��������,��Ʒ����,��ͬ�������� From view_oe_ypdd Where ǩ������ >= ? And ǩ������ <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.AddWithValue("@qdrq", Me.DtpQdrqBegin.Value.Date)
            rcOleDbCommand.Parameters.AddWithValue("@qdrq", Me.DtpQdrqEnd.Value.Date)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_ypdd") IsNot Nothing Then
                Me.rcDataset.Tables("rc_ypdd").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_ypdd")
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_ypdd").Rows.Count = 0 Then
            MsgBox("�붨���Ʒ��Ϣ��", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        '���ñ�
        Dim rcFrm As New FrmOeYpddXdbz
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("rc_ypdd"), "TRUE", "���ݺ�", DataViewRowState.CurrentRows)
            .Label2.Text = Me.DtpQdrqBegin.Value.Date.ToLongDateString & "��" & Me.DtpQdrqEnd.Value.Date.ToLongDateString
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

#End Region
End Class