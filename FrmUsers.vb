Imports System.Data.OleDb

Public Class FrmUsers
    '����OLEDB��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '����OleDb���ݶ���
    Dim rcOleDbTrans As OleDbTransaction
    '����OleDb����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '������ͼ
    Dim rcDataView As DataView

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub FrmCzygl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            sysOleDbConn.Open()
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT User_Account,User_DspName,User_Dwdm FROM rc_users ORDER BY User_Account"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_users") IsNot Nothing Then
                rcDataSet.Tables("rc_users").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_users")
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Catch ey As OleDbException
                MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            End Try
        Finally
            sysOleDbConn.Close()
        End Try
        rcDataView = New DataView(rcDataSet.Tables("rc_users"))
        rcDataGrid.DataSource = rcDataView
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Dim rcFrm As New FrmUserAdd
        With rcFrm
            '.MdiParent = Me.MdiParent
            If .ShowDialog = DialogResult.OK Then
                If rcDataSet.Tables("rc_users") IsNot Nothing Then
                    rcDataSet.Tables("rc_users").Clear()
                End If
                rcOleDbCommand.CommandText = "SELECT User_Account,User_DspName,User_Dwdm FROM rc_users ORDER BY User_Account"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_users")
            End If
        End With
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        Dim rcFrm As New FrmUserEdit
        With rcFrm
            .TxtAccount.Text = rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("User_Account")
            .TxtDspName.Text = rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("User_DspName")
            If rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("User_Dwdm").GetType.ToString <> "System.DBNull" Then
                .TxtDwdm.Text = rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("User_Dwdm")
            End If
            If .ShowDialog = DialogResult.OK Then
                If rcDataSet.Tables("rc_users") IsNot Nothing Then
                    rcDataSet.Tables("rc_users").Clear()
                End If
                rcOleDbCommand.CommandText = "SELECT User_Account,User_DspName,User_Dwdm FROM rc_users ORDER BY User_Account"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_users")
            End If
        End With
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        If rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("User_Account") = g_User_Account Then
            MsgBox("������ɾ�����ѡ�����ϵϵͳ����Ա��", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        If rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("User_Account") = "ADMIN" Then
            MsgBox("������ɾ��ϵͳ����Ա��", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        If MsgBox("���Ƿ�Ҫɾ����½�˺ţ�" & rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("User_Account") & "ȫ����" & rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("User_DspName") & "����Ա��", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, "��ʾ��Ϣ") = MsgBoxResult.Yes Then
            Try
                sysOleDbConn.Open()
                rcOleDbTrans = sysOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = sysOleDbConn
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandText = "DELETE FROM rc_users WHERE User_Account = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("User_Account")
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "DELETE FROM rc_userqx WHERE User_Account = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("User_Account")
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "SELECT User_Account,User_DspName,User_Dwdm FROM rc_users ORDER BY User_Account"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_users") IsNot Nothing Then
                    rcDataSet.Tables("rc_users").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_users")
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Catch ey As OleDbException
                    MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                End Try
                Return
            Finally
                sysOleDbConn.Close()
            End Try
        End If
    End Sub

    Private Sub BtnQx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQx.Click
        Dim rcFrm As New FrmUserQx
        With rcFrm
            .paraStrAccount = rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("User_Account")
            '.paraStrOeRight = rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("OeRight")
            If .ShowDialog = DialogResult.OK Then
                If rcDataSet.Tables("rc_users") IsNot Nothing Then
                    rcDataSet.Tables("rc_users").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_users")
            End If
        End With
    End Sub

#Region "�����excel"

    Private Sub MnuiExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExport.Click
        '��������
        Exports2Excel(rcDataSet.Tables("rc_users").DefaultView)
    End Sub

    Public Sub Exports2Excel(ByVal ParaDataView As DataView)
        If ParaDataView.Count > 0 Then
            Try
                Dim rcExcelApp As New Microsoft.Office.Interop.Excel.Application
                Dim rcExcelWorkbook As Microsoft.Office.Interop.Excel.Workbook
                Dim rcExcelWorksheet As Microsoft.Office.Interop.Excel.Worksheet
                Dim rowIndex, colIndex As Integer
                rowIndex = 1
                colIndex = 0
                rcExcelWorkbook = rcExcelApp.Workbooks().Add
                rcExcelWorksheet = rcExcelWorkbook.Worksheets("sheet1")

                '�����õ��ı������,��ֵ����Ԫ��
                Dim i As Integer
                Dim rcDataColumn As DataColumn
                Dim rcDataRowView As DataRowView

                rcExcelApp.Visible = True

                For Each rcDataColumn In ParaDataView.Table.Columns
                    colIndex += 1
                    rcExcelApp.Cells(1, colIndex) = rcDataColumn.ColumnName
                Next
                '�õ��ı�������,��ֵ����Ԫ��
                For i = 0 To ParaDataView.Count - 1
                    rcDataRowView = ParaDataView.Item(i)
                    If rcDataRowView.Row.RowState <> DataRowState.Deleted Then
                        rowIndex += 1
                        colIndex = 0
                        For Each rcDataColumn In ParaDataView.Table.Columns
                            colIndex += 1
                            If ParaDataView.Item(i).Row.Item(rcDataColumn.ColumnName).GetType.ToString = "System.String" Then
                                rcExcelApp.Cells(rowIndex, colIndex) = "'" & Trim(ParaDataView.Item(i).Row.Item(rcDataColumn.ColumnName))
                            Else
                                rcExcelApp.Cells(rowIndex, colIndex) = ParaDataView.Item(i).Row.Item(rcDataColumn.ColumnName)
                            End If
                        Next
                    End If
                Next
            Catch ex As Exception
                MessageBox.Show("���ݵ���ʧ�ܣ���鿴�Ƿ��Ѿ���װ��Excel2003���ϵİ汾��", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            Finally
                Me.Cursor = Cursors.Default
            End Try
        Else
            MessageBox.Show("û�����ݣ�", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

#End Region
End Class