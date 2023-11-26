Public Class FrmPoCgdCxLb

    Private Sub FrmCgdCxLb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        rcDataGrid.SetDataBinding(ParaDataView, "")
        Me.DgtbcSl.Format = g_FormatSl0
        Me.DgtbcDj.Format = g_FormatDj0
        Me.DgtbcMjsl.Format = g_FormatSl0
        Me.DgtbcFzsl.Format = g_FormatSl0
        Me.DgtbcJe.Format = g_FormatJe0
        Me.DgtbcRksl.Format = g_FormatSl0
        Me.DgtbcRkje.Format = g_FormatJe0
        Me.DgtbcFpsl.Format = g_FormatSl0
        Me.DgtbcFpje.Format = g_FormatJe0
        Me.DgtbcWrksl.Format = g_FormatSl0
        Me.DgtbcWrkje.Format = g_FormatJe0
    End Sub
End Class