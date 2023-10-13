Imports System.Data.OleDb
Public Class FrmPoCkdImpXls
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '���ݸ��´���
    Dim rcOleDbTrans As OleDbTransaction
    '��������
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '����ڼ�
    Dim strKjqj As String = g_Kjqj
    '��������
    Dim strPzlxdm As String = ""

#Region "��ʼ��"

    Public Property ParaStrKjqj() As String
        Get
            ParaStrKjqj = strKjqj
        End Get
        Set(ByVal Value As String)
            strKjqj = Value
        End Set
    End Property

    Public Property ParaStrPzlxdm() As String
        Get
            ParaStrPzlxdm = strPzlxdm
        End Get
        Set(ByVal Value As String)
            strPzlxdm = Value
        End Set
    End Property

#End Region

#Region "��������"

    Private Sub BtnXzwj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXzwj.Click
        If Me.OfdSourceExcelFileName.ShowDialog = DialogResult.OK Then
            Me.TxtSourceExcelFileName.Text = Me.OfdSourceExcelFileName.FileName
        End If
    End Sub

    Function ReadExcel(ByVal strFileName As String, ByVal strSheetName As String) As Boolean
        Dim strConnection As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = " + strFileName + ";Extended Properties = Excel 12.0"
        Dim oleConnection As New OleDbConnection(strConnection)
        Try
            oleConnection.Open()
            Dim oleAdper As New OleDbDataAdapter(" SELECT * FROM [" + strSheetName + "$]", oleConnection)
            If rcDataset.Tables("result") IsNot Nothing Then
                rcDataset.Tables("result").Clear()
                rcDataset.Tables("result").Columns.Clear()
            End If
            oleAdper.Fill(rcDataset, "result")
        Catch ex As Exception
            MsgBox("��ѡ����ļ�����Excel�ļ���ʽ��������ѡ��" & Chr(13) & ex.ToString(), MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return False
        Finally
            oleConnection.Close()
        End Try
        Return True
    End Function

    Private Sub TsbImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsbImp.Click, MnuiImp.Click
        If ReadExcel(Me.TxtSourceExcelFileName.Text, Me.TxtSheetName.Text) = True Then
            Me.DataGridView1.DataSource = rcDataset.Tables("result")
            Dim i As Integer
            For i = 0 To Me.DataGridView1.Columns.Count - 1
                Me.DataGridView1.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        End If
    End Sub

#End Region

#Region "�����¼�"

    Private Sub TsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsbSave.Click
        Dim i As Integer
        'For i = 0 To rcDataset.Tables("result").Rows.Count - 1
        '    If rcDataset.Tables("result").Rows(i).Item("ְԱ����").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("ְԱ����") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("ְԱ����").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("ְԱ����") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("���ű���").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("���ű���") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("��������").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("��������") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("�ֿ����").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("�ֿ����") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("�ֿ�����").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("�ֿ�����") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("���ϱ���").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("���ϱ���") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("��������").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("��������") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("������").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("������") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("����").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("����") = 0.0
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("��λ").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("��λ") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("����ϵ��").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("����ϵ��") = 0.0
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("������").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("������") = 0.0
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("����λ").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("����λ") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("����").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("����") = 0.0
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("���").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("���") = 0.0
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("��ע").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("��ע") = ""
        '    End If
        'Next
        If Me.RadioButton1.Checked Then
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                'ɾ���ѱ��������
                rcOleDbCommand.CommandText = "DELETE FROM inv_ckd WHERE SUBSTR(djh,1,10) = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@pzlxdmkjqj", OleDbType.VarChar, 10).Value = strPzlxdm & strKjqj
                rcOleDbCommand.ExecuteNonQuery()
                '���µ��ݺ�
                rcOleDbCommand.CommandText = "UPDATE rc_lx SET pzno" & Mid(strKjqj, 5, 2) & " = 0 WHERE kjnd = ? AND pzlxdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(strKjqj, 1, 4)
                rcOleDbCommand.Parameters.Add("@pzpxdm", OleDbType.VarChar, 4).Value = strPzlxdm
                rcOleDbCommand.ExecuteNonQuery()
                '��������
                rcOleDbCommand.CommandText = "DROP SEQUENCE " & strPzlxdm & strKjqj
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "CREATE SEQUENCE " & strPzlxdm & strKjqj & " INCREMENT BY 1 START WITH 1 MAXVALUE 99999 MINVALUE 1 NOCYCLE NOCACHE NOORDER"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbTrans.Commit()
            Catch ex As Exception
                MsgBox("ִ�г���ʱ�����˴���" & Chr(13) & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        End If
        For i = 0 To rcDataset.Tables("result").Rows.Count - 1
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.StoredProcedure
                rcOleDbCommand.CommandText = "USP3_SAVE_INV_CKD"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = strPzlxdm & strKjqj & "00001"
                rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = 1
                rcOleDbCommand.Parameters.Add("@paraDateCkrq", OleDbType.Date, 8).Value = rcDataset.Tables("result").Rows(i).Item("��������")
                rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                rcOleDbCommand.Parameters.Add("@ParaStrCkdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("�ֿ����")
                rcOleDbCommand.Parameters.Add("@paraStrCkmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("result").Rows(i).Item("�ֿ�����")
                rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("���ű���")
                rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("result").Rows(i).Item("��������")
                rcOleDbCommand.Parameters.Add("@paraStrZydm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("ְԱ����")
                rcOleDbCommand.Parameters.Add("@paraStrZymc", OleDbType.VarChar, 30).Value = rcDataset.Tables("result").Rows(i).Item("ְԱ����")
                rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("���ϱ���")).ToUpper
                rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("result").Rows(i).Item("��������")
                rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("��Ӧ�̱���")
                rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("result").Rows(i).Item("��Ӧ������")
                rcOleDbCommand.Parameters.Add("@paraStrBrecycling", OleDbType.Numeric, 1).Value = 0
                rcOleDbCommand.Parameters.Add("@paraStrBfadm", OleDbType.Numeric, 1).Value = 0
                rcOleDbCommand.Parameters.Add("@ParaStrFadm", OleDbType.VarChar, 12).Value = ""
                rcOleDbCommand.Parameters.Add("@paraStrFamc", OleDbType.VarChar, 30).Value = ""
                rcOleDbCommand.Parameters.Add("@paraStrKuwei", OleDbType.VarChar, 40).Value = rcDataset.Tables("result").Rows(i).Item("��λ")
                rcOleDbCommand.Parameters.Add("@paraStrPiHao", OleDbType.VarChar, 40).Value = ""
                rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("����")
                rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = rcDataset.Tables("result").Rows(i).Item("��λ")
                rcOleDbCommand.Parameters.Add("@paraDblMjsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("����ϵ��")
                rcOleDbCommand.Parameters.Add("@paraDblFzsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("������")
                rcOleDbCommand.Parameters.Add("@paraStrFzdw", OleDbType.VarChar, 8).Value = rcDataset.Tables("result").Rows(i).Item("����λ")
                rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("����")
                rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("result").Rows(i).Item("���")
                rcOleDbCommand.Parameters.Add("@paraStrRkmemo", OleDbType.VarChar, 50).Value = rcDataset.Tables("result").Rows(i).Item("��ע")
                rcOleDbCommand.Parameters.Add("@paraStrLlsqDjh", OleDbType.VarChar, 15).Value = ""
                rcOleDbCommand.Parameters.Add("@paraIntLlsqXh", OleDbType.Integer, 4).Value = 0
                rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                rcOleDbCommand.Parameters.Add("@paraCbill_bid", OleDbType.VarChar, 20).Value = ""
                rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                rcOleDbCommand.ExecuteNonQuery()
                If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                    If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                        MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                        Return
                    End If
                End If
                rcOleDbTrans.Commit()
            Catch ex As Exception
                MsgBox("ִ�г���ʱ�����˴���" & Chr(13) & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        Next
        MsgBox("���ϳ��ⵥ�������,�������ݡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
        Me.Close()
    End Sub

#End Region

#Region "�˳��¼�"

    Private Sub TsbExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TsbExit.Click, MnuiExit.Click
        Me.Close()
    End Sub

#End Region

End Class