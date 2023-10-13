Imports System.Data.OleDb
Public Class FrmZcpslImpXls
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
        'For i = 0 To rcDataset.Tables("result").Rows.Count - 1
        '    If rcDataset.Tables("result").Rows(i).Item("���ϱ���").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("���ϱ���") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("��������").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("��������") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("��λ").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("��λ") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("�������").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("�������") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("��������").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("��������") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("�ڲ�Ʒ����").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("�ڲ�Ʒ����") = 0.0
        '    End If
        'Next
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            If Me.RadioButton1.Checked Then
                'ɾ���ѱ��������
                rcOleDbCommand.CommandText = "DELETE FROM pm_zcp WHERE cperiod = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strKjqj
                rcOleDbCommand.ExecuteNonQuery()
            End If
            For i = 0 To rcDataset.Tables("result").Rows.Count - 1
                rcOleDbCommand.CommandText = "SELECT * FROM pm_zcp WHERE cperiod = ? AND bmdm = ? AND cpdm = ? AND gxdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strKjqj
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("result").Rows(i).Item("���ű���")).ToUpper
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("���ϱ���")).ToUpper
                rcOleDbCommand.Parameters.Add("@gxdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("result").Rows(i).Item("�������")).ToUpper
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("pm_zcp") IsNot Nothing Then
                    rcDataset.Tables("pm_zcp").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "pm_zcp")
                If rcDataset.Tables("pm_zcp").Rows.Count = 0 Then
                    rcOleDbCommand.CommandText = "INSERT INTO pm_zcp (cperiod,bmdm,cpdm,gxdm,zcpsl,ydsl,zcpje) values (?,?,?,?,?,0.0,0.0)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strKjqj
                    rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("result").Rows(i).Item("���ű���")).ToUpper
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("���ϱ���")).ToUpper
                    rcOleDbCommand.Parameters.Add("@gxdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("result").Rows(i).Item("�������")).ToUpper
                    rcOleDbCommand.Parameters.Add("@zcpsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("�ڲ�Ʒ����")
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "UPDATE pm_zcp SET zcpsl = zcpsl + ? WHERE cperiod = ? AND bmdm = ? AND cpdm = ? AND gxdm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@zcpsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("�ڲ�Ʒ����")
                    rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strKjqj
                    rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("result").Rows(i).Item("���ű���")).ToUpper
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("���ϱ���")).ToUpper
                    rcOleDbCommand.Parameters.Add("@gxdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("result").Rows(i).Item("�������")).ToUpper
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            Next
            rcOleDbTrans.Commit()
        Catch ex As Exception
            MsgBox("ִ�г���ʱ�����˴���" & Chr(13) & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        MsgBox("��ĩ�ڲ�Ʒ�����������,�������ݡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
        Me.Close()
    End Sub

#End Region

#Region "�˳��¼�"

    Private Sub TsbExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TsbExit.Click, MnuiExit.Click
        Me.Close()
    End Sub

#End Region

End Class