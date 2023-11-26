Public Class FrmOeBjdCxLb

    Private Sub FrmOeBjdCxLb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.DgtbcDj.Format = g_FormatDj0
        Me.DgtbcCkdw.Format = g_FormatDj0
        rcDataGrid.SetDataBinding(ParaDataView, "")
    End Sub
End Class