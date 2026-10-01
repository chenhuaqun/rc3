Imports models

Public Class FrmOeDdCxLb

    Private Sub FrmOeDdCxLb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcSl.Format = g_FormatSl0
        Me.DgtbcHxsl.Format = g_FormatSl0
        Me.DgtbcRksl.Format = g_FormatSl0
        Me.DgtbcWrk.Format = g_FormatSl0
        Me.DgtbcCksl.Format = g_FormatSl0
        Me.DgtbcWck.Format = g_FormatSl0
        Me.DgtbcFpsl.Format = g_FormatSl0
        Me.DgtbcWfp.Format = g_FormatSl0
        Me.DgtbcMjsl.Format = g_FormatSl0
        Me.DgtbcFzsl.Format = g_FormatSl0
        Me.DgtbcDj.Format = g_FormatDj0
        Me.DgtbcHsdj.Format = g_FormatDj0
        Me.DgtbcJe.Format = g_FormatJe0
        Me.DgtbcShlv.Format = g_FormatJe0
        Me.DgtbcSe.Format = g_FormatJe0
        Me.DgtbcJese.Format = g_FormatJe0
        Me.DgtbcBzcb.Format = g_FormatDj0
        Me.DgtbcWckje.Format = g_FormatJe0
        rcDataGrid.SetDataBinding(ParaDataView, "")
    End Sub

    Overrides Sub PrintViewEvent()
        MdlGridPrint.Preview(rcDataGrid, ParaDataView, MakePrintOption())
    End Sub

    Overrides Sub PrintEvent()
        MdlGridPrint.Print(rcDataGrid, ParaDataView, MakePrintOption())
    End Sub

    '列表方式没有固定版式，用通用网格打印：列取自表样式，行取自绑定用的 DataView
    Private Function MakePrintOption() As ClsGridPrintOption
        Dim opt As New ClsGridPrintOption()
        opt.Title = Label1.Text
        opt.Landscape = True
        opt.MarginMM = 10
        opt.RepeatHeader = True

        '只排界面专用的标志、编码、条款与延续字段，业务列全部保留
        opt.ExcludeColumns.AddRange(New String() { _
            "bclosed", "zydm", "ddtk", "sktj", "skqx", "wrk", "wck", "wfp", _
            "mjsl", "fzsl", "fzdw", "bzcb", "khddh", "khlh", "zxgg", _
            "sczydm", "sczymc", "srr", "sdjh", "sxh"})

        AddSum(opt, "sl", g_FormatSl0)
        AddSum(opt, "hxsl", g_FormatSl0)
        AddSum(opt, "rksl", g_FormatSl0)
        AddSum(opt, "cksl", g_FormatSl0)
        AddSum(opt, "fpsl", g_FormatSl0)
        AddSum(opt, "je", g_FormatJe0)
        AddSum(opt, "se", g_FormatJe0)
        AddSum(opt, "jese", g_FormatJe0)
        AddSum(opt, "wckje", g_FormatJe0)
        Return opt
    End Function

    '登记一个合计列。列上标了 Sum 即视为需要合计
    Private Sub AddSum(ByVal opt As ClsGridPrintOption, ByVal strField As String,
                       ByVal strFormat As String)
        Dim cfg As New ClsGridPrintColumn()
        cfg.Format = strFormat
        cfg.Align = ClsGridPrintColumn.ClsGridPrintAlign.Right
        cfg.Sum = True
        opt.ColumnSettings(strField) = cfg
    End Sub

End Class
