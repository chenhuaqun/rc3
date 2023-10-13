Public Class FrmOeFpCxLb

    Private Sub FrmOeFpCxLb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcMjsl.Format = g_FormatSl0
        Me.DgtbcSl.Format = g_FormatSl0
        Me.DgtbcFzsl.Format = g_FormatSl0
        Me.DgtbcDj.Format = g_FormatDj0
        Me.DgtbcHsdj.Format = g_FormatDj0
        Me.DgtbcJe.Format = g_FormatJe0
        Me.DgtbcShlv.Format = g_FormatJe0
        Me.DgtbcSe.Format = g_FormatJe0
        Me.DgtbcJese.Format = g_FormatJe0
        Me.DgtbcSkje.Format = g_FormatJe0
        Me.DgtbcXsdDj.Format = g_FormatDj0
        Me.DgtbcXsdHsdj.Format = g_FormatDj0
        Me.DgtbcXsdJe.Format = g_FormatJe0
        Me.DgtbcXsdShlv.Format = g_FormatJe0
        Me.DgtbcXsdSe.Format = g_FormatJe0
        Me.DgtbcXsdJece.Format = g_FormatJe0
        Me.DgtbcXsdSece.Format = g_FormatJe0
        rcDataGrid.SetDataBinding(ParaDataView, "")
    End Sub
End Class