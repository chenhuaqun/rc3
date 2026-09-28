Public Class FrmYwfZyMxHzz
    ReadOnly i As Integer = 0

    Private Sub FrmYwfZyMxHzz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcBnqc.Format = g_FormatJe0
        Me.DgtbcBnjf.Format = g_FormatJe0
        Me.DgtbcBndf.Format = g_FormatJe0
        Me.DgtbcBndj.Format = g_FormatJe0
        Me.DgtbcBnHl.Format = g_FormatJe0
        Me.DgtbcYwf_bz.Format = g_FormatJe0
        Me.DgtbcSnhl.Format = g_FormatJe0
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
