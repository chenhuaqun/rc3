Public Class FrmPoFpCxLb

    Private Sub FrmPoFpCxLb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcSl.Format = g_FormatSl0
        Me.DgtbcMjsl.Format = g_FormatSl0
        Me.DgtbcFzsl.Format = g_FormatSl0
        Me.DgtbcDj.Format = g_FormatDj0
        Me.DgtbcHsdj.Format = g_FormatDj0
        Me.DgtbcJe.Format = g_FormatJe0
        Me.DgtbcShlv.Format = g_FormatJe0
        Me.DgtbcSe.Format = g_FormatJe0
        Me.DgtbcJese.Format = g_FormatJe0
        Me.DgtbcFkje.Format = g_FormatJe0
        Me.DgtbcWfje.Format = g_FormatJe0
        Me.DgtbcRkdDj.Format = g_FormatDj0
        Me.DgtbcRkdHsdj.Format = g_FormatDj0
        Me.DgtbcRkdJe.Format = g_FormatJe0
        Me.DgtbcRkdShlv.Format = g_FormatJe0
        Me.DgtbcRkdSe.Format = g_FormatJe0
        Me.DgtbcRkdJece.Format = g_FormatJe0
        Me.DgtbcRkdSece.Format = g_FormatJe0
        rcDataGrid.SetDataBinding(ParaDataView, "")
    End Sub
End Class