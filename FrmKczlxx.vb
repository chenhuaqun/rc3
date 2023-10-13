Imports System.Data.OleDb

Public Class FrmKcZlxx
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

    Private Sub FrmKczlxx_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT fadm,famc,fasm FROM rc_kczlfa ORDER BY fadm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_kczlfa") IsNot Nothing Then
                rcDataSet.Tables("rc_kczlfa").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_kczlfa")
        Catch ex As Exception
            Try
                MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Catch ey As OleDbException
                MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            End Try
        Finally
            rcOleDbConn.Close()
        End Try
        rcDataView = New DataView(rcDataSet.Tables("rc_kczlfa"))
        rcDataGrid.DataSource = rcDataView
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Dim rcFrm As New FrmKczlFaAdd
        With rcFrm
            '.MdiParent = Me.MdiParent
            If .ShowDialog = DialogResult.OK Then
                If rcDataSet.Tables("rc_kczlfa") IsNot Nothing Then
                    rcDataSet.Tables("rc_kczlfa").Clear()
                End If
                rcOleDbCommand.CommandText = "SELECT fadm,famc,fasm FROM rc_kczlfa ORDER BY fadm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_kczlfa")
            End If
        End With
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        Dim rcFrm As New FrmKczlFaEdit
        With rcFrm
            .TxtFadm.Text = rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("fadm")
            .TxtFamc.Text = rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("famc")
            If rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("fasm").GetType.ToString <> "System.DBNull" Then
                .TxtFasm.Text = rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("fasm")
            End If
            If .ShowDialog = DialogResult.OK Then
                If rcDataSet.Tables("rc_kczlfa") IsNot Nothing Then
                    rcDataSet.Tables("rc_kczlfa").Clear()
                End If
                rcOleDbCommand.CommandText = "SELECT fadm,famc,fasm FROM rc_kczlfa ORDER BY fadm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_kczlfa")
            End If
        End With
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        If MsgBox("���Ƿ�Ҫɾ��������䷽�����룺" & rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("fadm") & "�������ƣ�" & rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("famc"), MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, "��ʾ��Ϣ") = MsgBoxResult.Yes Then
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandText = "DELETE FROM rc_kczlfa WHERE fadm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@fadm", OleDbType.VarChar, 12).Value = rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("fadm")
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "DELETE FROM rc_userqx WHERE fadm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@fadm", OleDbType.VarChar, 12).Value = rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("fadm")
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "SELECT fadm,famc,fasm FROM rc_kczlfa ORDER BY fadm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_kczlfa") IsNot Nothing Then
                    rcDataSet.Tables("rc_kczlfa").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_kczlfa")
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
                rcOleDbConn.Close()
            End Try
        End If
    End Sub

    Private Sub BtnQx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQx.Click
        Dim rcFrm As New FrmKczlFd
        With rcFrm
            .ParaStrFadm = rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("fadm")
            '.paraStrOeRight = rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("OeRight")
            If .ShowDialog = DialogResult.OK Then
                If rcDataSet.Tables("rc_kczlfa") IsNot Nothing Then
                    rcDataSet.Tables("rc_kczlfa").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_kczlfa")
            End If
        End With
    End Sub

#Region "�����excel"

    Private Sub MnuiExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExport.Click
        '��������
        Exports2Excel(rcDataSet.Tables("rc_kczlfa").DefaultView)
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