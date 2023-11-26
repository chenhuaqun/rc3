Public Class FrmOeBmHzbz

    Private Sub FrmOeBmHzbz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcSl.Format = g_FormatSl0
        Me.DgtbcJe.Format = g_FormatJe0
        Me.DgtbcSe.Format = g_FormatJe0
        Me.DgtbcJese.Format = g_FormatJe0
        Me.DgtbcCbje.Format = g_FormatJe0
        rcDataGrid.SetDataBinding(ParaDataView, "")
    End Sub
End Class