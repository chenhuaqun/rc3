Public Class FrmOeBmFpHzbz

    Private Sub FrmOeBmFpHzbz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcSl.Format = g_FormatSl0
        Me.DgtbcJe.Format = g_FormatJe0
        Me.DgtbcSe.Format = g_FormatJe0
        Me.DgtbcJese.Format = g_FormatJe0
        Me.DgtbcCbje.Format = g_FormatJe0
        RcDataGrid.SetDataBinding(ParaDataView, "")
    End Sub
End Class