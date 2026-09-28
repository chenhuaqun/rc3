Public Class FrmYwfZyzzHzHzz
    ReadOnly i As Integer = 0

    Private Sub FrmYwfZyzzHzHzz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcBngjdf.Format = g_FormatJe0
        Me.DgtbcBngjywf.Format = g_FormatJe0
        Me.DgtbcBnfgjdf.Format = g_FormatJe0
        Me.DgtbcBnfgjbjs.Format = g_FormatJe0
        Me.DgtbcBnfgjywf.Format = g_FormatJe0
        Me.DgtbcSngjdf.Format = g_FormatJe0
        Me.DgtbcSngjywf.Format = g_FormatJe0
        Me.DgtbcSnfgjdf.Format = g_FormatJe0
        Me.DgtbcSnfgjbjs.Format = g_FormatJe0
        Me.DgtbcSnfgjywf.Format = g_FormatJe0
        Me.DgtbcZyzzbl.Format = g_FormatDj0
        Me.DgtbcZyzzje.Format = g_FormatJe0
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
