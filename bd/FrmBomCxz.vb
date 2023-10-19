Public Class FrmBomCxz

    Private Sub FrmBomCxz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.DgtbcDj.Format = g_FormatDj0
        Me.DgtbcJe.Format = g_FormatDj0
        rcDataGrid.SetDataBinding(ParaDataView, "")
    End Sub
End Class