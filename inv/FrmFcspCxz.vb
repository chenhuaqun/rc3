Public Class FrmFcspCxz

    Private Sub FrmFcspCxz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcSl.Format = g_FormatSl0
        Me.DgtbcFzsl.Format = g_FormatSl0
        Me.DgtbcJe.Format = g_FormatDj0
        RcDataGrid.SetDataBinding(ParaDataView, "")
    End Sub
End Class