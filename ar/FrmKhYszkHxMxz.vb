Public Class FrmKhYszkHxMxz

    Private Sub FrmKhYszkHxMxz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcXssl.Format = g_FormatSl0
        Me.DgtbcXsdj.Format = g_FormatDj0
        Me.DgtbcXsje.Format = g_FormatJe0
        Me.DgtbcSkje.Format = g_FormatJe0
        Me.DgtbcHxje.Format = g_FormatJe0
        Me.DgtbcBzcb.Format = g_FormatJe0
        Me.DgtbcXstcbl.Format = g_FormatJe0
        rcDataGrid.SetDataBinding(ParaDataView, "")
    End Sub
End Class