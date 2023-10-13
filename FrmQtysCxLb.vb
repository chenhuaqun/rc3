Public Class FrmQtysCxLb

    Private Sub FrmQtysCxLb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcJe.Format = g_FormatJe0
        Me.DgtbcSkje.Format = g_FormatJe0
        rcDataGrid.SetDataBinding(ParaDataView, "")
    End Sub
End Class