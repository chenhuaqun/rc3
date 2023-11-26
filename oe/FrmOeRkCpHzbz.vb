Public Class FrmOeRkCpHzbz

    Private Sub FrmOeRkCpHzbz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcSl.Format = g_FormatSl0
        Me.DgtbcJe.Format = g_FormatJe0
        Me.DgtbcZl.Format = g_FormatJe0
        rcDataGrid.SetDataBinding(ParaDataView, "")
    End Sub
End Class