Imports System.Data.OleDb
Public Class FrmOeYpddJqSrz

#Region "�������"
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    Dim rcDataset As New DataSet
    '��ʾҪ������Դִ�е� SQL ����
    Dim rcOleDbTrans As OleDbTransaction
#End Region

#Region "��ʼ��"

    Public Property ParaDataSet() As DataSet
        Get
            ParaDataSet = rcDataset
        End Get
        Set(ByVal Value As DataSet)
            rcDataset = Value
        End Set
    End Property

    Private Sub FrmOeYpddJqSrz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '����DataGridView
        Me.rcDataGridView.AutoGenerateColumns = False
        '������the DataGridview to the DataTable.
        rcBindingSource.DataSource = rcDataset.Tables("rc_ddnr")
        Me.rcDataGridView.DataSource = rcBindingSource
    End Sub

#End Region

#Region "�ؼ��س����Ĵ���"

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If (Me.ActiveControl.GetType.Name = "DataGridViewTextBoxEditingControl" Or Me.rcDataGridView.Focused) Then
            Select Case keyData
                Case Keys.Enter, Keys.Right
                    SendKeys.Send("{TAB}")
                    Return True
                Case Keys.Left
                    SendKeys.Send("+{TAB}")
                    Return True
            End Select
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

#End Region

#Region "DataGridView���¼�"

    Private Sub RcDataGridView_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles rcDataGridView.CellValidating
        If Me.rcDataGridView.CurrentRow.IsNewRow = False Then
            If rcDataGridView.IsCurrentCellDirty Then
                rcDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
        End If
    End Sub

    Private Sub RcDataGridView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rcDataGridView.KeyDown
        Select Case e.KeyCode
            Case Keys.C And e.Control
                '����
                Clipboard.SetDataObject(Me.rcDataGridView.GetClipboardContent())
            Case Keys.V And e.Control
                'ճ��
                Me.rcDataGridView.CurrentCell.Value = Clipboard.GetText()
                Me.rcDataGridView.EndEdit()
                Me.rcBindingSource.EndEdit()
        End Select
    End Sub

    Private Sub RcDataGridView_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles rcDataGridView.Leave
        Me.rcDataGridView.ClearSelection()
    End Sub

    Private Sub RcDataGridView_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles rcDataGridView.RowValidating
        If Not Me.rcDataGridView.CurrentRow.IsNewRow Then
            Me.rcDataGridView.EndEdit()
            Me.rcBindingSource.EndEdit()
        End If
    End Sub

#End Region

#Region "�����¼�"

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim i As Integer
        Dim rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
        '���ǹ����յ�����
        For i = 0 To rcDataSet.Tables("rc_ddnr").Rows.Count - 1
            If rcDataSet.Tables("rc_ddnr").Rows(i).Item("scjhrq").GetType.ToString <> "System.DBNull" Then
                Try
                    rcOleDbConn.Open()
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    rcOleDbCommand.CommandText = "SELECT * FROM rc_fgzrxx WHERE rq = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@rq", OleDbType.Date, 8).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("scjhrq")
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataSet.Tables("rc_fgzrxx") IsNot Nothing Then
                        rcDataSet.Tables("rc_fgzrxx").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataSet, "rc_fgzrxx")
                Catch ex As Exception
                    Try
                        MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                    Catch ey As OleDbException
                        MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                    End Try
                Finally
                    rcOleDbConn.Close()
                End Try
                If rcDataSet.Tables("rc_fgzrxx").Rows.Count > 0 Then
                    MsgBox(rcDataSet.Tables("rc_ddnr").Rows(i).Item("scjhrq") & "������Ϊ�ǹ����ա�" & Chr(13) & "�����޸����������ٱ��档", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                    Return
                End If
            End If
        Next
        '����
        For i = 0 To rcDataSet.Tables("rc_ddnr").Rows.Count - 1
            If rcDataSet.Tables("rc_ddnr").Rows(i).Item("scjhrq").GetType.ToString <> "System.DBNull" And rcDataSet.Tables("rc_ddnr").Rows(i).Item("bmdm").GetType.ToString <> "System.DBNull" Then
                Try
                    rcOleDbConn.Open()
                    rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)        ' Start a local transaction
                    rcOleDbCommand.Connection = rcOleDbConn        ' Assign transaction object for a pending local transaction
                    rcOleDbCommand.Transaction = rcOleDbTrans
                    rcOleDbCommand.CommandText = "UPDATE oe_ypdd SET scjhrq = ? WHERE djh = ? and xh = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@khjhrq", OleDbType.Date, 8).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("scjhrq")
                    rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("djh")
                    rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("xh")
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbTrans.Commit()
                Catch ex As Exception
                    Try
                        rcOleDbTrans.Rollback()
                        MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                    Catch ey As OleDbException
                        MsgBox("�������" + ey.Message)
                    End Try
                Finally
                    rcOleDbConn.Close()
                End Try
            End If
        Next
        MsgBox("������ϡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
        Me.Close()
    End Sub

#End Region

#Region "�˳��¼�"

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click, MnuiExit.Click
        Me.Close()
    End Sub

#End Region
End Class