Public Class FrmCpSfcMxz

    Private Sub FrmCpSfcMxz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcRksl.Format = g_FormatSl0
        Me.DgtbcCksl.Format = g_FormatSl0
        Me.DgtbcJcsl.Format = g_FormatSl0
        Me.DgtbcRkdj.Format = g_FormatDj0
        Me.DgtbcCkdj.Format = g_FormatDj0
        Me.DgtbcJcdj.Format = g_FormatDj0
        Me.DgtbcRkje.Format = g_FormatJe0
        Me.DgtbcCkje.Format = g_FormatJe0
        Me.DgtbcJcje.Format = g_FormatJe0
        rcDataGrid.SetDataBinding(ParaDataView, "")
    End Sub
End Class