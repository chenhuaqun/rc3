Public Class FrmPoBmLbHzbz

    Private Sub FrmPoBmLbHzbz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcBysl.Format = g_FormatSl0
        Me.DgtbcByje.Format = g_FormatJe0
        rcDataGrid.SetDataBinding(paraDataView, "")
    End Sub
End Class