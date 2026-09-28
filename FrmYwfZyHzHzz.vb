Public Class FrmYwfZyHzHzz
    ReadOnly i As Integer = 0

    Private Sub FrmYwfZyHzHzz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcByjf.Format = g_FormatJe0
        Me.DgtbcBydf.Format = g_FormatJe0
        Me.DgtbcYwf_Bz.Format = g_FormatJe0
        Me.DgtbcYwf_Newkh.Format = g_FormatJe0
        Me.DgtbcYwf_Zl.Format = g_FormatJe0
        Me.DgtbcCdhpje.Format = g_FormatJe0
        Me.DgtbcYwf_cdhp.Format = g_FormatJe0
        Me.Dgtbcgylpjje.Format = g_FormatJe0
        Me.DgtbcYwf_gylpj.Format = g_FormatJe0
        Me.DgtbcYwf_Tx.Format = g_FormatJe0
        Me.DgtbcYongJinJe.Format = g_FormatJe0
        Me.DgtbcYwf_Yj.Format = g_FormatJe0
        Me.DgtbcDaiZhang.Format = g_FormatJe0
        Me.DgtbcYwf_Dz.Format = g_FormatJe0
        Me.DgtbcSuSong.Format = g_FormatJe0
        Me.DgtbcYwf_Ss.Format = g_FormatJe0
        Me.DgtbcYwf_Hj.Format = g_FormatJe0
        rcDataGrid.SetDataBinding(ParaDataView, "")
    End Sub

    Overrides Sub PageSetupEvent()
        MsgBox("打印暂未启用。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
    End Sub

    Overrides Sub PrintEvent()
        MsgBox("打印暂未启用。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
    End Sub

    Overrides Sub PrintViewEvent()
        MsgBox("打印暂未启用。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
    End Sub

End Class
