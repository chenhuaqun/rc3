Public Class FrmOeDdCxLb

    Private Sub FrmOeDdCxLb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcSl.Format = g_FormatSl0
        Me.DgtbcHxsl.Format = g_FormatSl0
        Me.DgtbcRksl.Format = g_FormatSl0
        Me.DgtbcWrk.Format = g_FormatSl0
        Me.DgtbcCksl.Format = g_FormatSl0
        Me.DgtbcWck.Format = g_FormatSl0
        Me.DgtbcFpsl.Format = g_FormatSl0
        Me.DgtbcWfp.Format = g_FormatSl0
        Me.DgtbcMjsl.Format = g_FormatSl0
        Me.DgtbcFzsl.Format = g_FormatSl0
        Me.DgtbcDj.Format = g_FormatDj0
        Me.DgtbcHsdj.Format = g_FormatDj0
        Me.DgtbcJe.Format = g_FormatJe0
        Me.DgtbcShlv.Format = g_FormatJe0
        Me.DgtbcSe.Format = g_FormatJe0
        Me.DgtbcJese.Format = g_FormatJe0
        Me.DgtbcBzcb.Format = g_FormatDj0
        rcDataGrid.SetDataBinding(ParaDataView, "")
    End Sub
End Class