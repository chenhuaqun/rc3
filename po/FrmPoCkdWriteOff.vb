Imports System.Data.OleDb

Public Class FrmPoCkdWriteOff
    '建立OLEDB数据适配器对象
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDb传递对象
    ReadOnly rcOleDbTrans As OleDbTransaction
    '建立OleDb命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '
    Dim strDjh As String = ""
    ReadOnly blnFp As Boolean = False
    ReadOnly blnCk As Boolean = False

    Public Property paraStrDjh() As String
        Get
            paraStrDjh = strDjh
        End Get
        Set(ByVal Value As String)
            strDjh = Value
        End Set
    End Property

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If Not String.IsNullOrEmpty(Me.TxtDjh.Text) Then
            strDjh = Trim(Me.TxtDjh.Text)
        End If
    End Sub
End Class