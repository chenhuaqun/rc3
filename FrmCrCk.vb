Imports System.Data.OleDb

Public Class FrmCrCk
    '建立DataSet对象
    Dim rcDataset As New DataSet
    '数据更新传递
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '成本域编码属性
    Dim strCrdm As String

    Overloads Property ParaDataSet() As DataSet
        Get
            ParaDataSet = rcDataset
        End Get
        Set(ByVal Value As DataSet)
            rcDataset = Value
        End Set
    End Property

    Public Property ParaStrCrdm As String
        Get
            ParaStrCrdm = strCrdm
        End Get
        Set(value As String)
            strCrdm = value
        End Set
    End Property

    Private Sub FrmCrCk_Load(sender As Object, e As EventArgs) Handles Me.Load
        '绑定数据the DataGrid to the DataSet.
        Me.rcBindingSource.DataSource = rcDataset.Tables("ckxx")
        Me.rcDataGridView.DataSource = Me.rcBindingSource
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click, MnuiSave.Click
        Dim i As Integer
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "DELETE FROM rc_cr_ck WHERE crdm = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@crdm", OleDbType.VarChar, 12).Value = strCrdm
            rcOleDbCommand.ExecuteNonQuery()
            For i = 0 To rcDataset.Tables("ckxx").Rows.Count - 1
                If rcDataset.Tables("ckxx").Rows(i).Item("xz").GetType.ToString <> "System.DBNull" Then
                    If rcDataset.Tables("ckxx").Rows(i).Item("xz") = 1 Then
                        rcOleDbCommand.CommandText = "INSERT INTO rc_cr_ck (crdm,ckdm) VALUES (?,?)"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@crdm", OleDbType.VarChar, 12).Value = strCrdm
                        rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ckxx").Rows(i).Item("ckdm")
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                End If
            Next
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Me.Close()
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click, MnuiExit.Click
        Me.Close()
    End Sub
End Class