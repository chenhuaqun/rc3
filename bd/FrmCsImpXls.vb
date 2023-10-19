Imports System.Data.OleDb
Public Class FrmCsImpXls
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '���ݸ��´���
    Dim rcOleDbTrans As OleDbTransaction
    '��������
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '����ڼ�
    Dim strKjqj As String = g_Kjqj

#Region "��ʼ��"

    Public Property ParaStrKjqj() As String
        Get
            ParaStrKjqj = strKjqj
        End Get
        Set(ByVal Value As String)
            strKjqj = Value
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
        For i = 0 To rcDataset.Tables("result").Rows.Count - 1
            If rcDataset.Tables("result").Rows(i).Item("��Ӧ�̷������").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("��Ӧ�̷������") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("��Ӧ�̷�������").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("��Ӧ�̷�������") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("��Ӧ�̱���").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("��Ӧ�̱���") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("��Ӧ������").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("��Ӧ������") = ""
            End If
        Next
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            For i = 0 To rcDataset.Tables("result").Rows.Count - 1
                'ɾ���ѱ��������
                rcOleDbCommand.CommandText = "SELECT * FROM rc_csxx WHERE csdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("result").Rows(i).Item("��Ӧ�̱���")).ToUpper
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("cntcpxx") IsNot Nothing Then
                    rcDataset.Tables("cntcpxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "cntcpxx")
                '����
                If Me.RadioButton1.Checked Then
                    If rcDataset.Tables("cntcpxx").Rows.Count > 0 Then
                        '����
                        '���¿��أ���׼�ɱ�
                        rcOleDbCommand.CommandText = "UPDATE rc_csxx SET csmc = ?,lbdm = ?,lbmc = ? WHERE csdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("result").Rows(i).Item("��Ӧ�̷������")).ToUpper
                        rcOleDbCommand.Parameters.Add("@lbmc", OleDbType.VarChar, 30).Value = Trim(rcDataset.Tables("result").Rows(i).Item("��Ӧ�̷�������")).ToUpper
                        rcOleDbCommand.Parameters.Add("@csmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("result").Rows(i).Item("��Ӧ������")
                        rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("result").Rows(i).Item("��Ӧ�̱���")).ToUpper
                        rcOleDbCommand.ExecuteNonQuery()
                    Else
                        '������,�򲻲���
                    End If
                Else
                    '׷��
                    If rcDataset.Tables("cntcpxx").Rows.Count = 0 Then
                        '��ӹ�Ӧ����Ϣ��Ϣ
                        rcOleDbCommand.CommandText = "INSERT INTO rc_csxx (lbdm,lbmc,csdm,csmc,zczb) VALUES (?,?,?,?,0)"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("result").Rows(i).Item("��Ӧ�̷������")).ToUpper
                        rcOleDbCommand.Parameters.Add("@lbmc", OleDbType.VarChar, 30).Value = Trim(rcDataset.Tables("result").Rows(i).Item("��Ӧ�̷�������")).ToUpper
                        rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("��Ӧ�̱���")).ToUpper
                        rcOleDbCommand.Parameters.Add("@csmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("result").Rows(i).Item("��Ӧ������")
                        rcOleDbCommand.ExecuteNonQuery()
                    Else
                        '�����򲻲���
                    End If

                End If
            Next
            rcOleDbTrans.Commit()
        Catch ex As Exception
            MsgBox("ִ�г���ʱ�����˴���" & Chr(13) & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        MsgBox("��Ӧ����Ϣ�������,�������ݡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
        Me.Close()
    End Sub

#End Region

#Region "�˳��¼�"

    Private Sub TsbExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TsbExit.Click, MnuiExit.Click
        Me.Close()
    End Sub

#End Region

End Class