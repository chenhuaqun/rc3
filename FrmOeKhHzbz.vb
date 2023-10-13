Public Class FrmOeKhHzbz

    Private Sub FrmOeKhHzbz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcSl.Format = g_FormatSl0
        Me.DgtbcFzsl.Format = g_FormatSl0
        Me.DgtbcJe.Format = g_FormatJe0
        Me.DgtbcSe.Format = g_FormatJe0
        Me.DgtbcCbje.Format = g_FormatJe0
        Me.DgtbcMle.Format = g_FormatJe0
        Me.DgtbcMll.Format = g_FormatPer
        rcDataGrid.SetDataBinding(ParaDataView, "")
    End Sub
End Class