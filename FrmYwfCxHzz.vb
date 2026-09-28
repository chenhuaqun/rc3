Public Class FrmYwfCxHzz
    ReadOnly i As Integer = 0

    Private Sub FrmYwfCxHzz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcYwfbl.Format = g_FormatJe0
        Me.DgtbcNewkhBl.Format = g_FormatJe0
        Me.DgtbcByjf.Format = g_FormatJe0
        Me.DgtbcBydf.Format = g_FormatJe0
        Me.DgtbcQmye.Format = g_FormatJe0
        Me.DgtbcJf01.Format = g_FormatJe0
        Me.DgtbcJf02.Format = g_FormatJe0
        Me.DgtbcJf03.Format = g_FormatJe0
        Me.DgtbcJf04.Format = g_FormatJe0
        Me.DgtbcJf05.Format = g_FormatJe0
        Me.DgtbcJf06.Format = g_FormatJe0
        Me.DgtbcJf07.Format = g_FormatJe0
        Me.DgtbcJf08.Format = g_FormatJe0
        Me.DgtbcJf09.Format = g_FormatJe0
        Me.DgtbcJf10.Format = g_FormatJe0
        Me.DgtbcJf11.Format = g_FormatJe0
        Me.DgtbcJf12.Format = g_FormatJe0
        Me.DgtbcJf13.Format = g_FormatJe0
        Me.DgtbcJf14.Format = g_FormatJe0
        Me.DgtbcDf01.Format = g_FormatJe0
        Me.DgtbcDf02.Format = g_FormatJe0
        Me.DgtbcDf03.Format = g_FormatJe0
        Me.DgtbcDf04.Format = g_FormatJe0
        Me.DgtbcDf05.Format = g_FormatJe0
        Me.DgtbcDf06.Format = g_FormatJe0
        Me.DgtbcDf07.Format = g_FormatJe0
        Me.DgtbcDf08.Format = g_FormatJe0
        Me.DgtbcDf09.Format = g_FormatJe0
        Me.DgtbcDf10.Format = g_FormatJe0
        Me.DgtbcDf11.Format = g_FormatJe0
        Me.DgtbcDf12.Format = g_FormatJe0
        Me.DgtbcDf13.Format = g_FormatJe0
        Me.DgtbcDf14.Format = g_FormatJe0
        Me.DgtbcYwf_Bz.Format = g_FormatJe0
        Me.DgtbcYwf_Newkh.Format = g_FormatJe0
        Me.DgtbcYwf_Zl.Format = g_FormatJe0
        Me.DgtbcCdhpje.Format = g_FormatJe0
        Me.DgtbcYwf_cdhp.Format = g_FormatJe0
        Me.DgtbcGylpjje.Format = g_FormatJe0
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
