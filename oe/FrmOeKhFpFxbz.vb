Public Class FrmOeKhFpFxbz

    Private Sub FrmOeKhFpFxbz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcBySl.Format = g_FormatSl0
        Me.DgtbcByFzsl.Format = g_FormatSl0
        Me.DgtbcByJe.Format = g_FormatJe0
        Me.DgtbcBySe.Format = g_FormatJe0
        Me.DgtbcByCbje.Format = g_FormatJe0
        Me.DgtbcByMle.Format = g_FormatJe0
        Me.DgtbcByMll.Format = g_FormatPer
        Me.DgtbcSySl.Format = g_FormatSl0
        Me.DgtbcSyFzsl.Format = g_FormatSl0
        Me.DgtbcSyJe.Format = g_FormatJe0
        Me.DgtbcSySe.Format = g_FormatJe0
        Me.DgtbcSyCbje.Format = g_FormatJe0
        Me.DgtbcSyMle.Format = g_FormatJe0
        Me.DgtbcSyMll.Format = g_FormatPer
        Me.DgtbcSnSl.Format = g_FormatSl0
        Me.DgtbcSnFzsl.Format = g_FormatSl0
        Me.DgtbcSnJe.Format = g_FormatJe0
        Me.DgtbcSnSe.Format = g_FormatJe0
        Me.DgtbcSnCbje.Format = g_FormatJe0
        Me.DgtbcSnMle.Format = g_FormatJe0
        Me.DgtbcSnMll.Format = g_FormatPer
        'Me.DgtbcHbFzsl.Format = g_FormatPer
        'Me.DgtbcTbFzsl.Format = g_FormatPer
        'Me.DgtbcHbJe.Format = g_FormatPer
        'Me.DgtbcTbJe.Format = g_FormatPer
        RcDataGrid.SetDataBinding(ParaDataView, "")
    End Sub
End Class