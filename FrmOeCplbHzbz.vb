Public Class FrmOeCplbHzbz

    Private Sub FrmOeCplbHzbz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcSl.Format = g_FormatSl
        Me.DgtbcZl.Format = g_FormatSl
        Me.DgtbcJe.Format = g_FormatJe
        Me.DgtbcSe.Format = g_FormatJe
        Me.DgtbcCbje.Format = g_FormatJe
        rcDataGrid.SetDataBinding(ParaDataView, "")
    End Sub
End Class