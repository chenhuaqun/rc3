Public Class FrmSlSfcHzz2

    Private Sub FrmSlSfcHzz2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcQcsl.Format = g_FormatSl0
        Me.DgtbcRksl.Format = g_FormatSl0
        Me.DgtbcCksl.Format = g_FormatSl0
        Me.DgtbcJcsl.Format = g_FormatSl0
        Me.DgtbcQcFzsl.Format = g_FormatSl0
        Me.DgtbcRkFzsl.Format = g_FormatSl0
        Me.DgtbcCkFzsl.Format = g_FormatSl0
        Me.DgtbcJcFzsl.Format = g_FormatSl0
        rcDataGrid.SetDataBinding(ParaDataView, "")
    End Sub
End Class