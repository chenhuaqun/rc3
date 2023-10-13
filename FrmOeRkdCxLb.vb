Public Class FrmOeRkdCxLb

    Private Sub FrmOeRkdCxLb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcSl.Format = g_FormatSl0
        Me.DgtbcFzsl.Format = g_FormatDj0
        Me.DgtbcFzdw.Format = g_FormatJe0
        Me.DgtbcDj.Format = g_FormatDj0
        Me.DgtbcJe.Format = g_FormatJe0
        rcDataGrid.SetDataBinding(ParaDataView, "")
    End Sub
End Class