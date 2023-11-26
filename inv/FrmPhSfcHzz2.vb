Public Class FrmPhSfcHzz2

    Private Sub FrmPhSfcHzz2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcQcsl.Format = g_FormatSl0
        Me.DgtbcQcje.Format = g_FormatJe0
        Me.DgtbcRksl.Format = g_FormatSl0
        Me.DgtbcRkje.Format = g_FormatJe0
        Me.DgtbcCksl.Format = g_FormatSl0
        Me.DgtbcCkje.Format = g_FormatJe0
        Me.DgtbcJcsl.Format = g_FormatSl0
        Me.DgtbcJcje.Format = g_FormatJe0
        rcDataGrid.SetDataBinding(ParaDataView, "")
    End Sub
End Class