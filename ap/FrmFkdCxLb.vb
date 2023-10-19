Public Class FrmFkdCxLb

    Private Sub FrmFkdCxLb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcJe.Format = g_FormatJe0
        Me.DgtbcRkje.Format = g_FormatJe0
        rcDataGrid.SetDataBinding(ParaDataView, "")
    End Sub
End Class