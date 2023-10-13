Imports System.Data.OleDb

Public Class FrmRoles

#Region "�������"

    '����OLEDB��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '����OleDb���ݶ���
    Dim rcOleDbTrans As OleDbTransaction
    '����OleDb����
    ReadOnly rcOleDbCommand As OleDbCommand = sysOleDbConn.CreateCommand()
    '����DataView������ͼ
    Dim rcDataView As DataView
    '����DataTable���ݱ�
    ReadOnly dtRoles As New DataTable("rc_roles")

#End Region

#Region "�����ʼ��"

    Private Sub FrmRoles_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '������
        dtRoles.Columns.Add("roleid", Type.GetType("System.String"))
        dtRoles.Columns.Add("rolename", Type.GetType("System.String"))
        dtRoles.Columns.Add("rolesm", Type.GetType("System.String"))
        rcDataSet.Tables.Add(dtRoles)
        With dtRoles
            .Columns("roleid").DefaultValue = ""
            .Columns("rolename").DefaultValue = ""
            .Columns("rolesm").DefaultValue = ""
        End With
        sysOleDbConn.Open()
        rcOleDbCommand.Connection = sysOleDbConn
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT * FROM rc_roles ORDER BY roleid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_roles") IsNot Nothing Then
                rcDataSet.Tables("rc_roles").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_roles")
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
        rcDataView = New DataView(rcDataSet.Tables("rc_roles"))
        Me.rcDataGridView.DataSource = rcDataView
    End Sub

#End Region

#Region "����"

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        '����
        Dim rcFrm As New FrmRoleEdit
        With rcFrm
            .ParaAdding = True
            .ParaDataView = rcDataView
            .ParaDataSet = rcDataset
            .PcurrentPos = BindingContext(rcDataView, "").Position
            .ShowDialog()
        End With
        Me.rcDataGridView.Refresh()
    End Sub

#End Region

#Region "�޸�"

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        '�޸�
        Dim rcFrm As New FrmRoleEdit
        With rcFrm
            .ParaAdding = False
            .ParaDataView = rcDataView
            .ParaDataSet = rcDataset
            .PcurrentPos = BindingContext(rcDataView, "").Position
            .ShowDialog()
        End With
        Me.rcDataGridView.Refresh()
    End Sub

#End Region

#Region "ɾ��"

    Private Sub BtnDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        Dim currentPos As Integer
        'ɾ������
        If MessageBox.Show("�����Ҫɾ����" & BindingContext(rcDataView, "").Current("roleid"), "��ʾ��Ϣ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then
            currentPos = BindingContext(rcDataView, "").Position
            If Trim(BindingContext(rcDataView, "").Current("roleid")) = "" Then
                MessageBox.Show("���벻��Ϊ�ա�")
                Return
            End If
            '��������Ƿ���ڣ�
            'rc_roleqx
            sysOleDbConn.Open()
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "SELECT * FROM rc_roleqx WHERE roleid = ? "
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@roleid", OleDbType.VarChar, 12).Value = BindingContext(rcDataView, "").Current("roleid")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_roleqx") IsNot Nothing Then
                    rcDataSet.Tables("rc_roleqx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_roleqx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                sysOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_roleqx").Rows.Count > 0 Then
                MsgBox("�ý�ɫ����ʹ�ã�����ɾ��������ȡ���ý�ɫ����Ȩ��", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            End If
            'rc_userinrole
            sysOleDbConn.Open()
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "SELECT * FROM rc_userinrole WHERE roleid = ? "
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@roleid", OleDbType.VarChar, 12).Value = BindingContext(rcDataView, "").Current("roleid")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_userinrole") IsNot Nothing Then
                    rcDataSet.Tables("rc_userinrole").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_userinrole")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                sysOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_userinrole").Rows.Count > 0 Then
                MsgBox("���û�����ʹ�øý�ɫ������ɾ��������ȡ���Ըý�ɫ����Ȩ��", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            End If
            sysOleDbConn.Open()
            rcOleDbTrans = sysOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "DELETE FROM rc_roles WHERE roleid = ? "
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@roleid", OleDbType.VarChar, 12).Value = BindingContext(rcDataView, "").Current("roleid")
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "SELECT * FROM rc_roles ORDER BY roleid"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_roles") IsNot Nothing Then
                    rcDataSet.Tables("rc_roles").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_roles")
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
                sysOleDbConn.Close()
            End Try
            BindingContext(rcDataView, "").Position = currentPos
        End If
    End Sub

#End Region

#Region "Ȩ��"

    Private Sub BtnQx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQx.Click
        '�޸�
        Dim rcFrm As New FrmRoleQx
        With rcFrm
            .paraStrAccount = BindingContext(rcDataView, "").Current("roleid")
            .Label1.Text = "��ɫ��(" & BindingContext(rcDataView, "").Current("roleid") & ")" & BindingContext(rcDataView, "").Current("rolename")
            .ShowDialog()
        End With
        Me.rcDataGridView.Refresh()
    End Sub

#End Region

#Region "�˳�"

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

#End Region

#Region "�����excel"

    Private Sub MnuiExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExport.Click
        '��������
        Exports2Excel(rcDataSet.Tables("rc_roles").DefaultView)
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