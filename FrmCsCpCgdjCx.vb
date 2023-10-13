Imports System.Data.OleDb

Public Class FrmCsCpCgdjCx
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        'ȡ����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT po_cscpcgdj.csdm,rc_csxx.csmc,po_cscpcgdj.cpdm,rc_cpxx.cpmc,rc_cpxx.dw,po_cscpcgdj.cgdj FROM po_cscpcgdj,rc_cpxx,rc_csxx WHERE po_cscpcgdj.csdm = rc_csxx.csdm AND po_cscpcgdj.cpdm = rc_cpxx.cpdm" & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " and po_cscpcgdj.cpdm = '" & Trim(Me.TxtCpdm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpmc.Text), " and po_cscpcgdj.cpmc Like '%" & Trim(Me.TxtCpmc.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCsdm.Text), " and po_cscpcgdj.csdm = '" & Trim(TxtCsdm.Text) & "'", "") & " ORDER BY po_cscpcgdj.csdm,po_cscpcgdj.cpdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("po_cscpcgdj") IsNot Nothing Then
                rcDataSet.Tables("po_cscpcgdj").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "po_cscpcgdj")
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("po_cscpcgdj").Rows.Count <= 0 Then
            MsgBox("û���������������ݡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        '���ñ�
        Dim rcFrm As New FrmCsCpCgdjCxz
        With rcFrm
            .ParaDataSet = rcDataSet
            .ParaDataView = New DataView(rcDataSet.Tables("po_cscpcgdj"), "TRUE", "csdm,cpdm", DataViewRowState.CurrentRows)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

End Class