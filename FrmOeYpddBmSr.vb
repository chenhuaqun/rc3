Imports System.Data.OleDb
Public Class FrmOeYpddBmSr
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

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        'ȡ����
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT ddnr.djh,ddnr.qdrq,ddnr.hth,ddnr.ddmemo,ddnr.bmdm,rc_bmxx.bmmc,ddnr.cpdm,ddnr.cpmc,ddnr.cpgg,ddnr.cpmemo,ddnr.khlh,ddnr.khcz,ddnr.khjhrq,ddnr.sl,ddnr.khdm,ddnr.khmc,ddnr.xh FROM (SELECT oe_ypdd.djh,oe_ypdd.qdrq,oe_ypdd.hth,REPLACE(oe_ypdd.ddtk || oe_ypdd.ddmemo,' ','') as ddmemo,oe_ypdd.xh,oe_ypdd.bmdm,oe_ypdd.cpdm,oe_ypdd.cpmc,oe_ypdd.cpgg,oe_ypdd.cpmemo,oe_ypdd.dw,oe_ypdd.khlh,oe_ypdd.khcz,oe_ypdd.sl,oe_ypdd.khjhrq,oe_ypdd.khdm,oe_ypdd.khmc FROM oe_ypdd WHERE oe_ypdd.shr IS NULL" & IIf(TxtHth.TextLength > 0, " and oe_ypdd.hth = '" & Trim(Me.TxtHth.Text) & "'", " AND oe_ypdd.scjhrq IS NULl") & IIf(ChbNewDd.Checked, " AND oe_ypdd.bmdm =''", "") & ") ddnr left outer join rc_bmxx on ddnr.bmdm = rc_bmxx.bmdm  ORDER BY ddnr.hth,ddnr.xh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_ddnr") IsNot Nothing Then
                rcDataset.Tables("rc_ddnr").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_ddnr")
        Catch ex As Exception
            Try
                MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Catch ey As OleDbException
                MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            End Try
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_ddnr").Rows.Count <= 0 Then
            MsgBox("û���������������ݡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        '���ñ�
        Dim rcFrm As New FrmOeYpddBmSrz
        With rcFrm
            .ParaDataSet = rcDataset
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

End Class