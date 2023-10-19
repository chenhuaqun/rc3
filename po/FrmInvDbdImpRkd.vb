Imports System.Data.OleDb

Public Class FrmInvDbdImpRkd
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    Dim rcDataset As New DataSet
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Public Property ParaDataSet() As DataSet
        Get
            ParaDataSet = rcDataSet
        End Get
        Set(ByVal Value As DataSet)
            rcDataSet = Value
        End Set
    End Property

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If Not String.IsNullOrEmpty(Me.TxtHth.Text) Then
            'ȡ����
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT inv_rkdnr.cpdm,rc_cpxx.cpmc,rc_cpxx.dw,rc_cpxx.kuwei,inv_rkdnr.sl,inv_rkdnr.rkmemo as dbmemo FROM inv_rkdml,inv_rkdnr,rc_cpxx WHERE inv_rkdml.djh = inv_rkdnr.djh and inv_rkdnr.cpdm = rc_cpxx.cpdm and inv_rkdnr.hth = ? ORDER BY inv_rkdnr.xh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@hth", OleDbType.VarChar, 12).Value = Me.TxtHth.Text
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                'If Not rcDataSet.Tables("rc_rkdnr") Is Nothing Then
                '    rcDataSet.Tables("rc_rkdnr").Clear()
                'End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_dbdnr")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_dbdnr").Rows.Count <= 0 Then
                MsgBox("û���������������ݡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            End If
        End If
    End Sub
End Class