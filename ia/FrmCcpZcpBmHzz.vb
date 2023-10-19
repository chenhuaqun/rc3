Public Class FrmCcpZcpBmHzz

    Private Sub FrmCcpZcpBmHzz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcQcZcpSl.Format = g_FormatSl0
        Me.DgtbcQcZcpJe.Format = g_FormatJe0
        Me.DgtbcZcbje.Format = g_FormatJe0
        Me.DgtbcCcpSl.Format = g_FormatSl0
        Me.DgtbcCcpJe.Format = g_FormatJe0
        Me.DgtbcQmZcpSl.Format = g_FormatSl0
        Me.DgtbcQmZcpJe.Format = g_FormatJe0
        rcDataGrid.SetDataBinding(ParaDataView, "")
    End Sub
End Class