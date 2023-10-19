Imports System.Data.OleDb
Public Class FrmCpImpXls
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
        Dim j As Integer
        'For i = 0 To rcDataset.Tables("result").Rows.Count - 1
        '    If rcDataset.Tables("result").Rows(i).Item("����������").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("����������") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("�����������").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("�����������") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("���ϱ���").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("���ϱ���") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("��������").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("��������") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("��λ").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("��λ") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("����ϵ��").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("����ϵ��") = 0.0
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("����λ").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("����λ") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("Ĭ�ϲֿ����").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("Ĭ�ϲֿ����") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("Ĭ�ϲֿ�����").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("Ĭ�ϲֿ�����") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("��׼�ɱ�").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("��׼�ɱ�") = 0.0
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("����").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("����") = 0.0
        '    End If
        'Next
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            'ȡ��cpdm�ֶεı�
            rcOleDbCommand.CommandText = "SELECT table_name,column_name FROM user_tab_columns WHERE column_name = 'CPDM' AND table_name <> 'RC_CPXX' AND table_name <> 'PO_CSCPCGDJ'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                rcDataset.Tables("user_tab_columns").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
            For i = 0 To rcDataset.Tables("result").Rows.Count - 1
                If Me.RadioButton1.Checked Then
                    '�����ѱ��������
                    rcOleDbCommand.CommandText = "SELECT * FROM rc_cpxx WHERE cpdm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("���ϱ���")).ToUpper
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("cntcpxx") IsNot Nothing Then
                        rcDataset.Tables("cntcpxx").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "cntcpxx")
                    If rcDataset.Tables("cntcpxx").Rows.Count > 0 Then
                        '����
                        '��׼�ɱ�
                        If rcDataset.Tables("result").Rows(i).Item("��׼�ɱ�").GetType.ToString <> "System.DBNull" Then
                            If rcDataset.Tables("result").Rows(i).Item("���ϳɱ�").GetType.ToString = "System.DBNull" Then
                                rcDataset.Tables("result").Rows(i).Item("���ϳɱ�") = 0.0
                            End If
                            If rcDataset.Tables("result").Rows(i).Item("����").GetType.ToString = "System.DBNull" Then
                                rcDataset.Tables("result").Rows(i).Item("����") = 1
                            End If
                            If rcDataset.Tables("result").Rows(i).Item("��׼�ɱ�") <> 0 Then
                                rcOleDbCommand.CommandText = "UPDATE rc_cpxx SET bzcb = ?,clcb = ?,beishu = ? WHERE cpdm = ?"
                                rcOleDbCommand.Parameters.Clear()
                                rcOleDbCommand.Parameters.Add("@bzcb", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("��׼�ɱ�")
                                rcOleDbCommand.Parameters.Add("@clcb", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("���ϳɱ�")
                                rcOleDbCommand.Parameters.Add("@beishu", OleDbType.Numeric, 12).Value = rcDataset.Tables("result").Rows(i).Item("����")
                                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("���ϱ���")).ToUpper
                                rcOleDbCommand.ExecuteNonQuery()
                            End If
                        End If
                        '���¿���
                        If rcDataset.Tables("result").Rows(i).Item("����").GetType.ToString <> "System.DBNull" Then
                            If rcDataset.Tables("result").Rows(i).Item("����") <> 0 Then
                                rcOleDbCommand.CommandText = "UPDATE rc_cpxx SET cpweight = ? WHERE cpdm = ?"
                                rcOleDbCommand.Parameters.Clear()
                                rcOleDbCommand.Parameters.Add("@cpweight", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("����")
                                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("���ϱ���")).ToUpper
                                rcOleDbCommand.ExecuteNonQuery()
                            End If
                        End If
                        '�������۵���
                        If rcDataset.Tables("result").Rows(i).Item("���۵���").GetType.ToString <> "System.DBNull" Then
                            If rcDataset.Tables("result").Rows(i).Item("���۵���") <> 0 Then
                                rcOleDbCommand.CommandText = "UPDATE rc_cpxx SET xsdj = ? WHERE cpdm = ?"
                                rcOleDbCommand.Parameters.Clear()
                                rcOleDbCommand.Parameters.Add("@cpweight", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("���۵���")
                                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("���ϱ���")).ToUpper
                                rcOleDbCommand.ExecuteNonQuery()
                            End If
                        End If
                    Else
                        '������,�򲻲���
                    End If
                End If
                If Me.RadioButton2.Checked Then
                    rcOleDbCommand.CommandText = "SELECT * FROM rc_cpxx WHERE cpdm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("���ϱ���")).ToUpper
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("cntcpxx") IsNot Nothing Then
                        rcDataset.Tables("cntcpxx").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "cntcpxx")
                    If rcDataset.Tables("cntcpxx").Rows.Count = 0 Then
                        Dim blnExists As Boolean
                        '������,�������û��ҵ����
                        For j = 0 To rcDataset.Tables("user_tab_columns").Rows.Count - 1
                            rcOleDbCommand.CommandText = "SELECT COUNT(*) AS gs FROM " & rcDataset.Tables("user_tab_columns").Rows(j).Item("table_name") & " WHERE cpdm = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("���ϱ���")).ToUpper
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("cntgs") IsNot Nothing Then
                                rcDataset.Tables("cntgs").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "cntgs")
                            If rcDataset.Tables("cntgs").Rows(0).Item("gs") > 0 Then
                                blnExists = True
                                'MsgBox(Trim(rcDataset.Tables("result").Rows(i).Item("���ϱ���")).ToUpper)
                            End If
                            If blnExists = True Then
                                Exit For
                            End If
                        Next
                        If blnExists Then
                            '�������������Ϣ
                            rcOleDbCommand.CommandText = "INSERT INTO rc_cpxx (lbdm,cpdm,cpmc,dw,ckdm,mjsl,fzdw,bzcb,clcb,beishu,cpweight,srr,srrq) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,SYSDATE)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("result").Rows(i).Item("����������")).ToUpper
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("���ϱ���")).ToUpper
                            rcOleDbCommand.Parameters.Add("@cpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("result").Rows(i).Item("��������")
                            rcOleDbCommand.Parameters.Add("@dw", OleDbType.VarChar, 8).Value = rcDataset.Tables("result").Rows(i).Item("��λ")
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("Ĭ�ϲֿ����")
                            rcOleDbCommand.Parameters.Add("@mjsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("����ϵ��")
                            rcOleDbCommand.Parameters.Add("@fzdw", OleDbType.VarChar, 8).Value = rcDataset.Tables("result").Rows(i).Item("����λ")
                            rcOleDbCommand.Parameters.Add("@bzcb", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("��׼�ɱ�")
                            rcOleDbCommand.Parameters.Add("@clcb", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("���ϳɱ�")
                            rcOleDbCommand.Parameters.Add("@beishu", OleDbType.Numeric, 12).Value = rcDataset.Tables("result").Rows(i).Item("����")
                            rcOleDbCommand.Parameters.Add("@cpweight", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("����")
                            rcOleDbCommand.Parameters.Add("@srr", OleDbType.VarChar, 30).Value = g_User_DspName
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    Else
                        '����,������
                    End If
                End If
                If Me.RadioButton3.Checked Or Me.RadioButton4.Checked Then
                    '�����ѱ��������
                    rcOleDbCommand.CommandText = "SELECT * FROM rc_cpxx WHERE cpdm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("���ϱ���")).ToUpper
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("cntcpxx") IsNot Nothing Then
                        rcDataset.Tables("cntcpxx").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "cntcpxx")
                    If rcDataset.Tables("cntcpxx").Rows.Count > 0 Then
                        If RadioButton3.Checked Then
                            '����
                            '���¿��أ���׼�ɱ�
                            'rcOleDbCommand.CommandText = "UPDATE rc_cpxx SET bzcb = ?,clcb = ?,cpweight = ?,beishu = ? WHERE cpdm = ?"
                            'rcOleDbCommand.Parameters.Clear()
                            'rcOleDbCommand.Parameters.Add("@bzcb", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("��׼�ɱ�")
                            'rcOleDbCommand.Parameters.Add("@clcb", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("���ϳɱ�")
                            'rcOleDbCommand.Parameters.Add("@cpweight", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("����")
                            'rcOleDbCommand.Parameters.Add("@beishu", OleDbType.Numeric, 12).Value = rcDataset.Tables("result").Rows(i).Item("����")
                            'rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("���ϱ���")).ToUpper
                            'rcOleDbCommand.ExecuteNonQuery()
                            If rcDataset.Tables("result").Rows(i).Item("��׼�ɱ�").GetType.ToString <> "System.DBNull" Then
                                If rcDataset.Tables("result").Rows(i).Item("��׼�ɱ�") <> 0 Then
                                    rcOleDbCommand.CommandText = "UPDATE rc_cpxx SET bzcb = ?,clcb = ?,beishu = ? WHERE cpdm = ?"
                                    rcOleDbCommand.Parameters.Clear()
                                    rcOleDbCommand.Parameters.Add("@bzcb", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("��׼�ɱ�")
                                    rcOleDbCommand.Parameters.Add("@clcb", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("���ϳɱ�")
                                    rcOleDbCommand.Parameters.Add("@beishu", OleDbType.Numeric, 12).Value = rcDataset.Tables("result").Rows(i).Item("����")
                                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("���ϱ���")).ToUpper
                                    rcOleDbCommand.ExecuteNonQuery()
                                End If
                            End If
                            If rcDataset.Tables("result").Rows(i).Item("����").GetType.ToString <> "System.DBNull" Then
                                If rcDataset.Tables("result").Rows(i).Item("����") <> 0 Then
                                    rcOleDbCommand.CommandText = "UPDATE rc_cpxx SET cpweight = ? WHERE cpdm = ?"
                                    rcOleDbCommand.Parameters.Clear()
                                    rcOleDbCommand.Parameters.Add("@cpweight", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("����")
                                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("���ϱ���")).ToUpper
                                    rcOleDbCommand.ExecuteNonQuery()
                                End If
                            End If
                        End If
                    Else
                        '������,��׷��
                        rcOleDbCommand.CommandText = "INSERT INTO rc_cpxx (lbdm,cpdm,cpmc,dw,ckdm,mjsl,fzdw,bzcb,clcb,beishu,cpweight,srr,srrq) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,SYSDATE)"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("result").Rows(i).Item("����������")).ToUpper
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("���ϱ���")).ToUpper
                        rcOleDbCommand.Parameters.Add("@cpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("result").Rows(i).Item("��������")
                        rcOleDbCommand.Parameters.Add("@dw", OleDbType.VarChar, 8).Value = rcDataset.Tables("result").Rows(i).Item("��λ")
                        rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("Ĭ�ϲֿ����")
                        rcOleDbCommand.Parameters.Add("@mjsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("����ϵ��")
                        rcOleDbCommand.Parameters.Add("@fzdw", OleDbType.VarChar, 8).Value = rcDataset.Tables("result").Rows(i).Item("����λ")
                        rcOleDbCommand.Parameters.Add("@bzcb", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("��׼�ɱ�")
                        rcOleDbCommand.Parameters.Add("@clcb", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("���ϳɱ�")
                        rcOleDbCommand.Parameters.Add("@beishu", OleDbType.Numeric, 12).Value = rcDataset.Tables("result").Rows(i).Item("����")
                        rcOleDbCommand.Parameters.Add("@cpweight", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("����")
                        rcOleDbCommand.Parameters.Add("@srr", OleDbType.VarChar, 30).Value = g_User_DspName
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                End If
                If Me.RadioButton5.Checked Then
                    If rcDataset.Tables("result").Rows(i).Item("����������").GetType.ToString <> "System.DBNull" Then
                        rcOleDbCommand.CommandText = "UPDATE rc_cpxx SET lbdm = ? WHERE cpdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("����������")
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("���ϱ���")).ToUpper
                        rcOleDbCommand.ExecuteNonQuery()
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
        MsgBox("�������Զ������,�������ݡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
        Me.Close()
    End Sub

#End Region

#Region "�˳��¼�"

    Private Sub TsbExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TsbExit.Click, MnuiExit.Click
        Me.Close()
    End Sub

#End Region

End Class