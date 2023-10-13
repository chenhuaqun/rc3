Imports System.Data.OleDb
Public Class FrmNewYear
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '��ʾҪ������Դִ�е� SQL ����
    Dim rcOleDbTrans As OleDbTransaction
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As New OleDbCommand ' = rcOleDbConn.CreateCommand()

    Private Sub FrmNewYear_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Ĭ��ֵ
        Me.NudYear.Value = Mid(g_Kjqj, 1, 4) + 1
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        '�ж��ǲ��Ƿ�����

        '�����������
        If MsgBox("�Ƿ���������ˣ�", MsgBoxStyle.YesNo + MsgBoxStyle.Information + MsgBoxStyle.DefaultButton2, "��ʾ��Ϣ") = MsgBoxResult.Yes Then
            Dim i As Integer
            Dim j As Integer
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                '(5)����
                '(A)���»�������
                'LblMsg.Text = "�������»������ʣ����Ժ򡭡�"
                rcOleDbCommand.CommandType = CommandType.StoredProcedure
                rcOleDbCommand.CommandText = "USP3_REDO_CPYEHZ"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value - 1
                rcOleDbCommand.Parameters.Add("@dwrq", OleDbType.Date, 8).Value = g_Dwrq
                rcOleDbCommand.ExecuteNonQuery()
                '(E)���ɵ�������
                'LblMsg.Text = "�������ɵ������ͣ����Ժ򡭡�"
                'ȡδ��ӵ�����
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT pzlxdm,lxgs FROM rc_lx WHERE kjnd = ? AND NOT EXISTS (SELECT 1 FROM (SELECT pzlxdm FROM rc_lx WHERE kjnd = ?) llll WHERE llll.pzlxdm = rc_lx.pzlxdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = NudYear.Value - 1
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = NudYear.Value
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_lx") IsNot Nothing Then
                    rcDataSet.Tables("rc_lx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_lx")
                '��������
                For i = 0 To rcDataSet.Tables("rc_lx").Rows.Count - 1
                    For j = 1 To 12
                        rcOleDbCommand.CommandText = "CREATE SEQUENCE " & Trim(rcDataSet.Tables("rc_lx").Rows(i).Item("pzlxdm")) & (Me.NudYear.Value).ToString & j.ToString.PadLeft(2, "0") & " INCREMENT BY 1 START WITH 1 MAXVALUE 99999 MINVALUE 1 NOCYCLE NOCACHE NOORDER"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.ExecuteNonQuery()
                    Next
                Next
                rcOleDbCommand.CommandText = "INSERT INTO rc_lx (kjnd,pzlxdm,pzlxjc,pzlxmc,lxgs,pzno01,pzno02,pzno03,pzno04,pzno05,pzno06,pzno07,pzno08,pzno09,pzno10,pzno11,pzno12,pzno13,bfushu) SELECT '" & NudYear.Value & "' as kjnd,pzlxdm,pzlxjc,pzlxmc,lxgs,0 as pzno01,0 as pzno02,0 as pzno03,0 as pzno04,0 as pzno05,0 as pzno06,0 as pzno07,0 as pzno08,0 as pzno09,0 as pzno10,0 as pzno11,0 as pzno12,0 AS pzno13,bfushu FROM rc_lx WHERE kjnd = ? AND NOT EXISTS (SELECT 1 FROM (SELECT pzlxdm FROM rc_lx WHERE kjnd = ?) llll WHERE llll.pzlxdm = rc_lx.pzlxdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = NudYear.Value - 1
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = NudYear.Value
                rcOleDbCommand.ExecuteNonQuery()
                '(J)���ɻ���ڼ���˱�־
                'LblMsg.Text = "�������ɻ���ڼ䣬���Ժ򡭡�"
                rcOleDbCommand.CommandText = "INSERT INTO rc_yj (ny,jzbz,glbegin,glend,invbegin,invend,pobegin,poend) SELECT ? || SUBSTR(ny,5,2) AS ny,0 AS jzbz,add_months(glbegin,12),add_months(glend,12),add_months(invbegin,12),add_months(invend,12),add_months(pobegin,12),add_months(poend,12) FROM rc_yj WHERE SUBSTR(ny,1,4) = ? AND NOT EXISTS (SELECT 1 FROM (SELECT ny FROM rc_yj WHERE SUBSTR(ny,1,4) = ?) llll WHERE SUBSTR(llll.ny,5,2) = SUBSTR(rc_yj.ny,5,2))"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 4).Value = Me.NudYear.Value - 1
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                rcOleDbCommand.ExecuteNonQuery()
                Application.DoEvents()
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
        End If
        MsgBox("��������Ѿ�����,�������������û���ڼ䡣", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
        Me.Close()
    End Sub
End Class