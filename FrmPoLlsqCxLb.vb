Public Class FrmPoLlsqCxLb

    Private Sub FrmCgdCxLb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcSl.Format = g_FormatSl0
        Me.DgtbcMjsl.Format = g_FormatSl0
        Me.DgtbcFzsl.Format = g_FormatSl0
        Me.DgtbcCksl.Format = g_FormatSl0
        rcDataGrid.SetDataBinding(ParaDataView, "")
    End Sub
End Class