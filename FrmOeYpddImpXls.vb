Imports System.Data.OleDb
Public Class FrmOeYpddImpXls
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
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
        Dim strKjqj As String = g_Kjqj
        Dim strDjh As String = "YPHT" & strKjqj & "00001"
        For i = 0 To rcDataset.Tables("result").Rows.Count - 1
            If rcDataset.Tables("result").Rows(i).Item("��������").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("��������") = Now.Date
            End If
            If rcDataset.Tables("result").Rows(i).Item("��ͬ����").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("��ͬ����") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("�ͻ�����").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("�ͻ�����") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("�ռ���").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("�ռ���") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("��Ʒ����").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("��Ʒ����") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("�����ͺ�").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("�����ͺ�") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("����").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("����") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("��Ʒ����").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("��Ʒ����") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("��λ").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("��λ") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("�ͻ��Ϻ�").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("�ͻ��Ϻ�") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("�ͻ�����").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("�ͻ�����") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("�ͻ�����").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("�ͻ�����") = 0.0
            End If
            If rcDataset.Tables("result").Rows(i).Item("ϵ��").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("ϵ��") = 1
            End If
            If rcDataset.Tables("result").Rows(i).Item("��������").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("��������") = 0.0
            End If
            If rcDataset.Tables("result").Rows(i).Item("�ͻ�����").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("�ͻ�����") = Now.Date
            End If
            If rcDataset.Tables("result").Rows(i).Item("���ű���").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("���ű���") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("��ע").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("��ע") = ""
            End If
            strKjqj = getInvKjqj(rcDataset.Tables("result").Rows(i).Item("��������"))
            strDjh = "YPHT" & strKjqj & "00001"
            '(��)�洢ml
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            Try
                rcOleDbCommand.CommandText = "USP_SAVE_oe_ypdd"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                rcOleDbCommand.Parameters.Add("@pStrDjh", OleDbType.VarChar, 15).Value = strDjh
                rcOleDbCommand.Parameters("@pStrDjh").Direction = ParameterDirection.InputOutput
                rcOleDbCommand.Parameters.Add("@pDateQdrq", OleDbType.Date, 8).Value = rcDataset.Tables("result").Rows(i).Item("��������")
                rcOleDbCommand.Parameters.Add("@pStrHth", OleDbType.VarChar, 11).Value = rcDataset.Tables("result").Rows(i).Item("��ͬ����")
                rcOleDbCommand.Parameters.Add("@pStrKhdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("�ͻ�����")
                rcOleDbCommand.Parameters.Add("@pStrLxr", OleDbType.VarChar, 30).Value = rcDataset.Tables("result").Rows(i).Item("�ռ���")
                rcOleDbCommand.Parameters.Add("@pStrDdmemo", OleDbType.VarChar, 40).Value = rcDataset.Tables("result").Rows(i).Item("��ͬ��������") '��ͬ��������
                rcOleDbCommand.Parameters.Add("@pStrUserDspName", OleDbType.VarChar, 10).Value = g_User_DspName
                rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                rcOleDbCommand.Parameters.Add("@paraIntError", OleDbType.Integer, 4).Direction = ParameterDirection.Output
                rcOleDbCommand.ExecuteNonQuery()
                If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                    If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                        MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                        Return
                    End If
                End If
                If rcOleDbCommand.Parameters("@pStrDjh").Value.GetType.ToString <> "System.DBNull" Then
                    If rcOleDbCommand.Parameters("@pStrDjh").Value <> "" Then
                        strDjh = Trim(rcOleDbCommand.Parameters("@pStrDjh").Value)
                    End If
                End If
                '(��)�洢nr
                rcOleDbCommand.CommandText = "USP_SAVE_oe_ypdd"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@pStrDjh", OleDbType.VarChar, 15).Value = strDjh
                rcOleDbCommand.Parameters.Add("@pStrHth", OleDbType.VarChar, 11).Value = rcDataset.Tables("result").Rows(i).Item("��ͬ����")
                rcOleDbCommand.Parameters.Add("@pStrKhdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("�ͻ�����")
                rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = 1
                rcOleDbCommand.Parameters.Add("@pStrCpdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("result").Rows(i).Item("��Ʒ����")).ToUpper
                rcOleDbCommand.Parameters.Add("@pStrCpmc", OleDbType.VarChar, 40).Value = Trim(rcDataset.Tables("result").Rows(i).Item("�����ͺ�"))
                rcOleDbCommand.Parameters.Add("@pStrCpgg", OleDbType.VarChar, 40).Value = Trim(rcDataset.Tables("result").Rows(i).Item("����"))
                rcOleDbCommand.Parameters.Add("@pStrCpmemo", OleDbType.VarChar, 50).Value = Trim(rcDataset.Tables("result").Rows(i).Item("��Ʒ����"))
                rcOleDbCommand.Parameters.Add("@pStrDw", OleDbType.VarChar, 8).Value = Trim(rcDataset.Tables("result").Rows(i).Item("��λ"))
                rcOleDbCommand.Parameters.Add("@pStrKhlh", OleDbType.VarChar, 50).Value = Trim(rcDataset.Tables("result").Rows(i).Item("�ͻ��Ϻ�"))
                rcOleDbCommand.Parameters.Add("@pStrKhcz", OleDbType.VarChar, 30).Value = Trim(rcDataset.Tables("result").Rows(i).Item("�ͻ�����"))
                rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("��������")
                rcOleDbCommand.Parameters.Add("@pDateKhjhrq", OleDbType.Date).Value = rcDataset.Tables("result").Rows(i).Item("�ͻ�����")
                rcOleDbCommand.Parameters.Add("@pDateScjhrq", OleDbType.Date).Value = rcDataset.Tables("result").Rows(i).Item("�ͻ�����")
                rcOleDbCommand.Parameters.Add("@pDateFhrq", OleDbType.Date).Value = rcDataset.Tables("result").Rows(i).Item("�ͻ�����")
                rcOleDbCommand.Parameters.Add("@pStrBmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("���ű���")
                rcOleDbCommand.Parameters.Add("@pStrDdmemo", OleDbType.VarChar, 50).Value = rcDataset.Tables("result").Rows(i).Item("��ע")
                rcOleDbCommand.Parameters.Add("@pStrSrr", OleDbType.VarChar, 10).Value = ""
                rcOleDbCommand.Parameters.Add("@paraIntZt", OleDbType.Integer, 1).Value = 0
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
        MsgBox("��Ʒ�����������,�������ݡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
    End Sub

#End Region

#Region "�˳��¼�"

    Private Sub TsbExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TsbExit.Click, MnuiExit.Click
        Me.Close()
    End Sub

#End Region
End Class