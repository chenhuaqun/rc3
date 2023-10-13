Imports System.Data.OleDb
Public Class FrmOeYpddJqShz

#Region "�������"
    '��������������
    Dim rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    Dim rcDataSet As New DataSet
    '��ʾҪ������Դִ�е� SQL ����
    Dim rcOleDbTrans As OleDbTransaction
    '��������
    Dim rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    'DataGridViewTextBoxEditingControl
    Dim EditingControl As DataGridViewTextBoxEditingControl
    '������ӡ�ĵ�
    Dim rcRps As RPS.Document
#End Region

#Region "��ʼ��"

    Public Property paraDataSet() As DataSet
        Get
            paraDataSet = rcDataSet
        End Get
        Set(ByVal Value As DataSet)
            rcDataSet = Value
        End Set
    End Property

    Private Sub FrmOeYpddJqShz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '����DataGridView
        Me.rcDataGridView.AutoGenerateColumns = False
        '������the DataGridview to the DataTable.
        rcBindingSource.DataSource = rcDataSet.Tables("rc_ddnr")
        Me.rcDataGridView.DataSource = rcBindingSource
    End Sub

#End Region

#Region "����¼�"
    Private Sub BtnSh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSh.Click
        ShEvent()
    End Sub

    Private Sub MnuiSh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiSh.Click
        ShEvent()
    End Sub

    Private Sub ShEvent()
        If String.IsNullOrEmpty(Me.rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColBmdm").Value) Or Me.rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColScjhrq").GetType.ToString = "System.DBNull" Then
            MsgBox("����û��¼����������û��ȷ�Ͻ��ڵ����ݣ����ܽ�����ˡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        '���ǹ��������
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT * FROM rc_fgzrxx WHERE rq = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@rq", OleDbType.Date, 8).Value = Me.rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColScjhrq").Value
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If Not rcDataSet.Tables("rc_fgzrxx") Is Nothing Then
                rcDataSet.Tables("rc_fgzrxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_fgzrxx")
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            Catch ey As OleDbException
                MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("rc_fgzrxx").Rows.Count > 0 Then
            If MsgBox("������Ϊ�ǹ����գ��Ƿ��Ÿ��������ڣ�", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "��ʾ��Ϣ") = MsgBoxResult.No Then
                Return
            End If
        End If
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "UPDATE oe_ypdd SET jqshr = ?,jqshrq = SYSDATE() WHERE djh = ? and xh = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@jqshr", OleDbType.VarChar, 30).Value = g_User_DspName
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColDjh").Value
            rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = Me.rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColXh").Value
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            Catch ey As OleDbException
                MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
    End Sub

#End Region

#Region "�����¼�"

    Private Sub BtnXs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXs.Click
        XsEvent()
    End Sub

    Private Sub MnuiXs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiXs.Click
        XsEvent()
    End Sub

    Private Sub XsEvent()
        '�������
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT zt FROM oe_ypdd where zt > 3 and djh = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColDjh").Value
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If Not rcDataSet.Tables("nobm") Is Nothing Then
                rcDataSet.Tables("nobm").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "nobm")
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            Catch ey As OleDbException
                MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("nobm").Rows.Count > 0 Then
            MsgBox("�����Ѿ���������ݣ�����ȡ����ˡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        '
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "UPDATE oe_ypdd SET jqshr = ?,jqshrq = NULL WHERE djh = ? and xh = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@jqshr", OleDbType.VarChar, 30).Value = ""
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColDjh").Value
            rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = Me.rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColXh").Value
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            Catch ey As OleDbException
                MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
    End Sub

#End Region

#Region "ȫ���¼�"

    Private Sub BtnQs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQs.Click
        QsEvent()
    End Sub

    Private Sub MnuiQs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiQs.Click
        QsEvent()
    End Sub

    Private Sub QsEvent()
        Dim i As Integer = 0.0
        For i = 0 To rcDataSet.Tables("rc_ddnr").Rows.Count - 1
            If rcDataSet.Tables("rc_ddnr").Rows(i).Item("bmdm") = "" Or rcDataSet.Tables("rc_ddnr").Rows(i).Item("scjhrq").GetType.ToString = "System.DBNull" Then
                MsgBox("����û��¼����������û��ȷ�Ͻ��ڵ����ݣ����ܽ�����ˡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            End If
            '���ǹ��������
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "SELECT * FROM rc_fgzrxx WHERE rq = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@rq", OleDbType.Date, 8).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("scjhrq")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If Not rcDataSet.Tables("rc_fgzrxx") Is Nothing Then
                    rcDataSet.Tables("rc_fgzrxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_fgzrxx")
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
                Catch ey As OleDbException
                    MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_fgzrxx").Rows.Count > 0 Then
                If MsgBox("������Ϊ�ǹ����գ��Ƿ��Ÿ��������ڣ�", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "��ʾ��Ϣ") = MsgBoxResult.No Then
                    Return
                End If
            End If
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "UPDATE oe_ypdd SET jqshr = ?,jqshrq = SYSDATE() WHERE djh = ? and xh = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@jqshr", OleDbType.VarChar, 30).Value = g_User_DspName
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("djh")
                rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("xh")
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
                Catch ey As OleDbException
                    MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        Next
        MsgBox("�����ɡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
    End Sub

#End Region

#Region "ȫ���¼�"

    Private Sub BtnQx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQx.Click
        QxEvent()
    End Sub

    Private Sub MnuiQx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiQx.Click
        QxEvent()
    End Sub

    Private Sub QxEvent()
        Dim i As Integer = 0
        For i = 0 To rcDataSet.Tables("rc_ddnr").Rows.Count - 1
            '�������
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "SELECT zt FROM oe_ypdd where zt > 3 and djh = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("djh")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If Not rcDataSet.Tables("nobm") Is Nothing Then
                    rcDataSet.Tables("nobm").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "nobm")
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
                Catch ey As OleDbException
                    MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("nobm").Rows.Count > 0 Then
                MsgBox("�����Ѿ���������ݣ�����ȡ����ˡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            End If
            '
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "UPDATE oe_ypdd SET jqshr = ?,jqshrq = NULL WHERE djh = ? and xh = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@jqshr", OleDbType.VarChar, 30).Value = ""
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("djh")
                rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = rcDataSet.Tables("rc_ddnr").Rows(i).Item("xh")
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
                Catch ey As OleDbException
                    MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        Next
        MsgBox("ȡ�������ɡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
    End Sub

#End Region

#Region "�˳��¼�"

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiExit.Click, BtnExit.Click
        Me.Close()
    End Sub

#End Region
End Class