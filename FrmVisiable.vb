Public Class FrmVisiable

    Private Sub FrmVisiable_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim list As ArrayList = Properties.Settings.[Default].DataGridViewDisplay
        If list IsNot Nothing Then
            For i As Integer = 0 To list.Count - 1
                rcDataGridView.Columns(i).DisplayIndex = CInt(list(i))
            Next
        End If
    End Sub
End Class