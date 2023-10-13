Imports System.Data.OleDb
Public Class FrmOeDdImpXls
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '���ݸ��´���
    Dim rcOleDbTrans As OleDbTransaction
    '��������
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

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
        Dim strDjh As String = "XSHT" & g_Kjqj & "00001"
        If rcDataset.Tables("result").Rows.Count = 0 Then
            Return
        End If
        For i = 0 To rcDataset.Tables("result").Rows.Count - 1
            If rcDataset.Tables("result").Rows(i).Item("ǩ������").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("ǩ������") = Now.Date
            End If
            If rcDataset.Tables("result").Rows(i).Item("��������").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("��������") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("�ͻ�����").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("�ͻ�����") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("���ʽ").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("���ʽ") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("����").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("����") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("����").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("����") = 1
            End If
            If rcDataset.Tables("result").Rows(i).Item("�ͻ�������").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("�ͻ�������") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("�����ڵ���").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("�����ڵ���") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("��ͬ��������").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("��ͬ��������") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("��Ʒ����").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("��Ʒ����") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("���ű���").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("���ű���") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("�ͻ��Ϻ�").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("�ͻ��Ϻ�") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("��������").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("��������") = 0
            End If
            If rcDataset.Tables("result").Rows(i).Item("ϵ��").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("ϵ��") = 1
            End If
            If rcDataset.Tables("result").Rows(i).Item("����").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("����") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("��˰����").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("��˰����") = 0.0
            End If
            If rcDataset.Tables("result").Rows(i).Item("����").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("����") = 0.0
            End If
            If rcDataset.Tables("result").Rows(i).Item("�ͻ�����").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("�ͻ�����") = Now.Date
            End If
            If rcDataset.Tables("result").Rows(i).Item("��������").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("��������") = 0
            End If
            If rcDataset.Tables("result").Rows(i).Item("������").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("������") = 2
            End If
            If rcDataset.Tables("result").Rows(i).Item("LineNo").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("LineNo") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("��ע").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("��ע") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("���˷���").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("���˷���") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("���䷽ʽ").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("���䷽ʽ") = ""
            End If
            'ȡ��������
            '(��)�洢ml
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            Try
                'If i = 0 Then
                rcOleDbCommand.CommandText = "USP_SAVE_OE_DDML"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = strDjh
                rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                rcOleDbCommand.Parameters.Add("@pDateQdrq", OleDbType.Date, 8).Value = rcDataset.Tables("result").Rows(i).Item("ǩ������")
                rcOleDbCommand.Parameters.Add("@paraStrHth", OleDbType.VarChar, 30).Value = rcDataset.Tables("result").Rows(i).Item("��������")
                rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("�ͻ�����")
                rcOleDbCommand.Parameters.Add("@paraStrSgdh", OleDbType.VarChar, 20).Value = rcDataset.Tables("result").Rows(i).Item("�ͻ�������")
                rcOleDbCommand.Parameters.Add("@paraStrJckdh", OleDbType.VarChar, 20).Value = rcDataset.Tables("result").Rows(i).Item("�����ڵ���")
                rcOleDbCommand.Parameters.Add("@paraStrWbdm", OleDbType.VarChar, 4).Value = rcDataset.Tables("result").Rows(i).Item("����")
                rcOleDbCommand.Parameters.Add("@paraDblWbhl", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("����")
                rcOleDbCommand.Parameters.Add("@paraStrJsfs", OleDbType.VarChar, 20).Value = rcDataset.Tables("result").Rows(i).Item("���ʽ")
                rcOleDbCommand.Parameters.Add("@paraStrDdmemo", OleDbType.VarChar, 40).Value = rcDataset.Tables("result").Rows(i).Item("��ͬ��������") '
                rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 10).Value = g_User_DspName
                rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                rcOleDbCommand.Parameters.Add("@paraIntError", OleDbType.Integer, 4).Direction = ParameterDirection.Output
                rcOleDbCommand.ExecuteNonQuery()
                If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                    If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                        MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                        Return
                    End If
                End If
                If rcOleDbCommand.Parameters("@paraStrDjh").Value.GetType.ToString <> "System.DBNull" Then
                    If rcOleDbCommand.Parameters("@paraStrDjh").Value <> "" Then
                        strDjh = Trim(rcOleDbCommand.Parameters("@paraStrDjh").Value)
                    End If
                End If
                'End If
                '(��)�洢nr
                rcOleDbCommand.CommandText = "USP_SAVE_OE_DDNR"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = strDjh
                rcOleDbCommand.Parameters.Add("@paraStrHth", OleDbType.VarChar, 30).Value = Mid(strDjh, 5, 11)
                rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("�ͻ�����")
                rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = i + 1
                rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("��Ʒ����")).ToUpper
                rcOleDbCommand.Parameters.Add("@paraStrKhlh", OleDbType.VarChar, 50).Value = Trim(rcDataset.Tables("result").Rows(i).Item("�ͻ��Ϻ�")).ToUpper
                rcOleDbCommand.Parameters.Add("@paraDblKhsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("��������")
                rcOleDbCommand.Parameters.Add("@paraIntXs", OleDbType.Integer, 4).Value = rcDataset.Tables("result").Rows(i).Item("ϵ��")
                rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("����")
                rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("����")
                rcOleDbCommand.Parameters.Add("@paraDblHsdj", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("��˰����")
                rcOleDbCommand.Parameters.Add("@pDateKhjhrq", OleDbType.Date).Value = rcDataset.Tables("result").Rows(i).Item("�ͻ�����")
                rcOleDbCommand.Parameters.Add("@pDateScjhrq", OleDbType.Date).Value = DBNull.Value
                rcOleDbCommand.Parameters.Add("@pDateFhrq", OleDbType.Date).Value = DBNull.Value
                rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("���ű���")
                rcOleDbCommand.Parameters.Add("@paraIntTeshu", OleDbType.Integer, 1).Value = rcDataset.Tables("result").Rows(i).Item("��������")
                rcOleDbCommand.Parameters.Add("@paraIntCrs", OleDbType.Integer, 1).Value = rcDataset.Tables("result").Rows(i).Item("������")
                rcOleDbCommand.Parameters.Add("@paraStrLine_no", OleDbType.VarChar, 10).Value = rcDataset.Tables("result").Rows(i).Item("LineNo")
                rcOleDbCommand.Parameters.Add("@paraStrDdmemo", OleDbType.VarChar, 50).Value = rcDataset.Tables("result").Rows(i).Item("��ע")
                rcOleDbCommand.Parameters.Add("@paraStrFyfx", OleDbType.VarChar, 8).Value = rcDataset.Tables("result").Rows(i).Item("���˷���")
                rcOleDbCommand.Parameters.Add("@paraStrYsfs", OleDbType.VarChar, 8).Value = rcDataset.Tables("result").Rows(i).Item("���䷽ʽ")
                rcOleDbCommand.Parameters.Add("@paraStrSrr", OleDbType.VarChar, 10).Value = ""
                rcOleDbCommand.Parameters.Add("@paraIntZt", OleDbType.Integer, 1).Value = 0
                rcOleDbCommand.Parameters.Add("@paraDblCksl", OleDbType.Numeric, 18).Value = 0
                rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                rcOleDbCommand.Parameters.Add("@paraIntError", OleDbType.Integer, 4).Direction = ParameterDirection.Output
                rcOleDbCommand.ExecuteNonQuery()
                If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                    If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                        MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                        Return
                    End If
                End If
                rcOleDbTrans.Commit()
            Catch ex As Exception
                MsgBox("ִ�г���ʱ�����˴���" & Chr(13) & Chr(13) & ex.Message & Chr(13) & Chr(13) & rcOleDbCommand.Parameters("@paraIntError").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        Next
        MsgBox("��Ʒ���۶����������,�������ݡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
    End Sub

#End Region

#Region "�˳��¼�"

    Private Sub TsbExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TsbExit.Click, MnuiExit.Click
        Me.Close()
    End Sub

#End Region
End Class