<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeDdCxLb
    Inherits models.FrmReportView

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DgtbcDjh = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcXh = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcBclosed = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcQdrq = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcHth = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcKhdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcKhmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcZydm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcZymc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcDdtk = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSktj = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSkqx = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCpdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCpmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcHxsl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcRksl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcWrk = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCksl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcWck = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcFpsl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcWfp = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcDw = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcMjsl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcFzsl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcFzdw = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcDj = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcHsdj = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJe = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcShlv = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSe = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJese = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcBzcb = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcWckje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcKhddh = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcKhlh = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcKhjhrq = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcZxgg = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcDdmemo = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcScjhrq = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCkrq = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSczydm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSczymc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSrr = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcShr = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSdjh = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSxh = New System.Windows.Forms.DataGridTextBoxColumn
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'rcDataGrid
        '
        Me.rcDataGrid.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(397, 8)
        Me.Label1.Size = New System.Drawing.Size(186, 23)
        Me.Label1.Text = "产品销售订单列表"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.rcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcDjh, Me.DgtbcXh, Me.DgtbcBclosed, Me.DgtbcQdrq, Me.DgtbcHth, Me.DgtbcKhdm, Me.DgtbcKhmc, Me.DgtbcZydm, Me.DgtbcZymc, Me.DgtbcDdtk, Me.DgtbcSktj, Me.DgtbcSkqx, Me.DgtbcCpdm, Me.DgtbcCpmc, Me.DgtbcSl, Me.DgtbcHxsl, Me.DgtbcRksl, Me.DgtbcWrk, Me.DgtbcCksl, Me.DgtbcWck, Me.DgtbcFpsl, Me.DgtbcWfp, Me.DgtbcDw, Me.DgtbcMjsl, Me.DgtbcFzsl, Me.DgtbcFzdw, Me.DgtbcDj, Me.DgtbcHsdj, Me.DgtbcJe, Me.DgtbcShlv, Me.DgtbcSe, Me.DgtbcJese, Me.DgtbcBzcb, Me.DgtbcWckje, Me.DgtbcKhddh, Me.DgtbcKhlh, Me.DgtbcKhjhrq, Me.DgtbcZxgg, Me.DgtbcDdmemo, Me.DgtbcSdjh, Me.DgtbcSxh, Me.DgtbcScjhrq, Me.DgtbcCkrq, Me.DgtbcSczydm, Me.DgtbcSczymc, Me.DgtbcSrr, Me.DgtbcShr})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "ddlb"
        '
        'DgtbcDjh
        '
        Me.DgtbcDjh.Format = ""
        Me.DgtbcDjh.FormatInfo = Nothing
        Me.DgtbcDjh.HeaderText = "单据号"
        Me.DgtbcDjh.MappingName = "djh"
        Me.DgtbcDjh.NullText = ""
        Me.DgtbcDjh.Width = 105
        '
        'DgtbcXh
        '
        Me.DgtbcXh.Format = ""
        Me.DgtbcXh.FormatInfo = Nothing
        Me.DgtbcXh.HeaderText = "行号"
        Me.DgtbcXh.MappingName = "xh"
        Me.DgtbcXh.NullText = ""
        Me.DgtbcXh.Width = 45
        '
        'DgtbcBclosed
        '
        Me.DgtbcBclosed.Format = ""
        Me.DgtbcBclosed.FormatInfo = Nothing
        Me.DgtbcBclosed.HeaderText = "关闭标志"
        Me.DgtbcBclosed.MappingName = "bclosed"
        Me.DgtbcBclosed.NullText = ""
        Me.DgtbcBclosed.Width = 45
        '
        'DgtbcQdrq
        '
        Me.DgtbcQdrq.Format = ""
        Me.DgtbcQdrq.FormatInfo = Nothing
        Me.DgtbcQdrq.HeaderText = "签单日期"
        Me.DgtbcQdrq.MappingName = "qdrq"
        Me.DgtbcQdrq.NullText = ""
        Me.DgtbcQdrq.Width = 110
        '
        'DgtbcHth
        '
        Me.DgtbcHth.Format = ""
        Me.DgtbcHth.FormatInfo = Nothing
        Me.DgtbcHth.HeaderText = "订单号"
        Me.DgtbcHth.MappingName = "hth"
        Me.DgtbcHth.NullText = ""
        Me.DgtbcHth.Width = 75
        '
        'DgtbcKhdm
        '
        Me.DgtbcKhdm.Format = ""
        Me.DgtbcKhdm.FormatInfo = Nothing
        Me.DgtbcKhdm.HeaderText = "客户编码"
        Me.DgtbcKhdm.MappingName = "khdm"
        Me.DgtbcKhdm.NullText = ""
        Me.DgtbcKhdm.Width = 75
        '
        'DgtbcKhmc
        '
        Me.DgtbcKhmc.Format = ""
        Me.DgtbcKhmc.FormatInfo = Nothing
        Me.DgtbcKhmc.HeaderText = "客户名称"
        Me.DgtbcKhmc.MappingName = "khmc"
        Me.DgtbcKhmc.NullText = ""
        Me.DgtbcKhmc.Width = 210
        '
        'DgtbcZydm
        '
        Me.DgtbcZydm.Format = ""
        Me.DgtbcZydm.FormatInfo = Nothing
        Me.DgtbcZydm.HeaderText = "职员编码"
        Me.DgtbcZydm.MappingName = "zydm"
        Me.DgtbcZydm.NullText = ""
        Me.DgtbcZydm.Width = 45
        '
        'DgtbcZymc
        '
        Me.DgtbcZymc.Format = ""
        Me.DgtbcZymc.FormatInfo = Nothing
        Me.DgtbcZymc.HeaderText = "职员姓名"
        Me.DgtbcZymc.MappingName = "zymc"
        Me.DgtbcZymc.NullText = ""
        Me.DgtbcZymc.Width = 90
        '
        'DgtbcDdtk
        '
        Me.DgtbcDdtk.Format = ""
        Me.DgtbcDdtk.FormatInfo = Nothing
        Me.DgtbcDdtk.HeaderText = "订单条款"
        Me.DgtbcDdtk.MappingName = "ddtk"
        Me.DgtbcDdtk.NullText = ""
        Me.DgtbcDdtk.Width = 135
        '
        'DgtbcSktj
        '
        Me.DgtbcSktj.Format = ""
        Me.DgtbcSktj.FormatInfo = Nothing
        Me.DgtbcSktj.HeaderText = "收款条件"
        Me.DgtbcSktj.MappingName = "sktj"
        Me.DgtbcSktj.NullText = ""
        Me.DgtbcSktj.Width = 75
        '
        'DgtbcSkqx
        '
        Me.DgtbcSkqx.Format = ""
        Me.DgtbcSkqx.FormatInfo = Nothing
        Me.DgtbcSkqx.HeaderText = "收款期限"
        Me.DgtbcSkqx.MappingName = "skqx"
        Me.DgtbcSkqx.NullText = ""
        Me.DgtbcSkqx.Width = 75
        '
        'DgtbcCpdm
        '
        Me.DgtbcCpdm.Format = ""
        Me.DgtbcCpdm.FormatInfo = Nothing
        Me.DgtbcCpdm.HeaderText = "产品编码"
        Me.DgtbcCpdm.MappingName = "cpdm"
        Me.DgtbcCpdm.NullText = ""
        Me.DgtbcCpdm.Width = 75
        '
        'DgtbcCpmc
        '
        Me.DgtbcCpmc.Format = ""
        Me.DgtbcCpmc.FormatInfo = Nothing
        Me.DgtbcCpmc.HeaderText = "产品名称"
        Me.DgtbcCpmc.MappingName = "cpmc"
        Me.DgtbcCpmc.NullText = ""
        Me.DgtbcCpmc.Width = 240
        '
        'DgtbcSl
        '
        Me.DgtbcSl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSl.Format = ""
        Me.DgtbcSl.FormatInfo = Nothing
        Me.DgtbcSl.HeaderText = "数量"
        Me.DgtbcSl.MappingName = "sl"
        Me.DgtbcSl.NullText = ""
        Me.DgtbcSl.Width = 110
        '
        'DgtbcHxsl
        '
        Me.DgtbcHxsl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcHxsl.Format = ""
        Me.DgtbcHxsl.FormatInfo = Nothing
        Me.DgtbcHxsl.HeaderText = "核销数量"
        Me.DgtbcHxsl.MappingName = "hxsl"
        Me.DgtbcHxsl.NullText = ""
        Me.DgtbcHxsl.Width = 90
        '
        'DgtbcRksl
        '
        Me.DgtbcRksl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcRksl.Format = ""
        Me.DgtbcRksl.FormatInfo = Nothing
        Me.DgtbcRksl.HeaderText = "入库数量"
        Me.DgtbcRksl.MappingName = "rksl"
        Me.DgtbcRksl.NullText = ""
        Me.DgtbcRksl.Width = 90
        '
        'DgtbcWrk
        '
        Me.DgtbcWrk.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcWrk.Format = ""
        Me.DgtbcWrk.FormatInfo = Nothing
        Me.DgtbcWrk.HeaderText = "未入库"
        Me.DgtbcWrk.MappingName = "wrk"
        Me.DgtbcWrk.NullText = ""
        Me.DgtbcWrk.Width = 90
        '
        'DgtbcCksl
        '
        Me.DgtbcCksl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcCksl.Format = ""
        Me.DgtbcCksl.FormatInfo = Nothing
        Me.DgtbcCksl.HeaderText = "送货数量"
        Me.DgtbcCksl.MappingName = "cksl"
        Me.DgtbcCksl.NullText = ""
        Me.DgtbcCksl.Width = 90
        '
        'DgtbcWck
        '
        Me.DgtbcWck.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcWck.Format = ""
        Me.DgtbcWck.FormatInfo = Nothing
        Me.DgtbcWck.HeaderText = "未送货数量"
        Me.DgtbcWck.MappingName = "wck"
        Me.DgtbcWck.NullText = ""
        Me.DgtbcWck.Width = 90
        '
        'DgtbcFpsl
        '
        Me.DgtbcFpsl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcFpsl.Format = ""
        Me.DgtbcFpsl.FormatInfo = Nothing
        Me.DgtbcFpsl.HeaderText = "开票数量"
        Me.DgtbcFpsl.MappingName = "fpsl"
        Me.DgtbcFpsl.NullText = ""
        Me.DgtbcFpsl.Width = 90
        '
        'DgtbcWfp
        '
        Me.DgtbcWfp.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcWfp.Format = ""
        Me.DgtbcWfp.FormatInfo = Nothing
        Me.DgtbcWfp.HeaderText = "未开票数量"
        Me.DgtbcWfp.MappingName = "wfp"
        Me.DgtbcWfp.NullText = ""
        Me.DgtbcWfp.Width = 90
        '
        'DgtbcDw
        '
        Me.DgtbcDw.Format = ""
        Me.DgtbcDw.FormatInfo = Nothing
        Me.DgtbcDw.HeaderText = "单位"
        Me.DgtbcDw.MappingName = "dw"
        Me.DgtbcDw.NullText = ""
        Me.DgtbcDw.Width = 30
        '
        'DgtbcMjsl
        '
        Me.DgtbcMjsl.Format = ""
        Me.DgtbcMjsl.FormatInfo = Nothing
        Me.DgtbcMjsl.HeaderText = "换算系数"
        Me.DgtbcMjsl.MappingName = "mjsl"
        Me.DgtbcMjsl.NullText = ""
        Me.DgtbcMjsl.Width = 75
        '
        'DgtbcFzsl
        '
        Me.DgtbcFzsl.Format = ""
        Me.DgtbcFzsl.FormatInfo = Nothing
        Me.DgtbcFzsl.HeaderText = "辅数量"
        Me.DgtbcFzsl.MappingName = "fzsl"
        Me.DgtbcFzsl.NullText = ""
        Me.DgtbcFzsl.Width = 75
        '
        'DgtbcFzdw
        '
        Me.DgtbcFzdw.Format = ""
        Me.DgtbcFzdw.FormatInfo = Nothing
        Me.DgtbcFzdw.HeaderText = "辅单位"
        Me.DgtbcFzdw.MappingName = "fzdw"
        Me.DgtbcFzdw.NullText = ""
        Me.DgtbcFzdw.Width = 30
        '
        'DgtbcDj
        '
        Me.DgtbcDj.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcDj.Format = ""
        Me.DgtbcDj.FormatInfo = Nothing
        Me.DgtbcDj.HeaderText = "不含税单价"
        Me.DgtbcDj.MappingName = "dj"
        Me.DgtbcDj.NullText = ""
        Me.DgtbcDj.Width = 75
        '
        'DgtbcHsdj
        '
        Me.DgtbcHsdj.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcHsdj.Format = ""
        Me.DgtbcHsdj.FormatInfo = Nothing
        Me.DgtbcHsdj.HeaderText = "含税单价"
        Me.DgtbcHsdj.MappingName = "hsdj"
        Me.DgtbcHsdj.NullText = ""
        Me.DgtbcHsdj.Width = 75
        '
        'DgtbcJe
        '
        Me.DgtbcJe.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcJe.Format = ""
        Me.DgtbcJe.FormatInfo = Nothing
        Me.DgtbcJe.HeaderText = "金额"
        Me.DgtbcJe.MappingName = "je"
        Me.DgtbcJe.NullText = ""
        Me.DgtbcJe.Width = 75
        '
        'DgtbcShlv
        '
        Me.DgtbcShlv.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcShlv.Format = ""
        Me.DgtbcShlv.FormatInfo = Nothing
        Me.DgtbcShlv.HeaderText = "税率"
        Me.DgtbcShlv.MappingName = "shlv"
        Me.DgtbcShlv.NullText = ""
        Me.DgtbcShlv.Width = 75
        '
        'DgtbcSe
        '
        Me.DgtbcSe.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSe.Format = ""
        Me.DgtbcSe.FormatInfo = Nothing
        Me.DgtbcSe.HeaderText = "税额"
        Me.DgtbcSe.MappingName = "se"
        Me.DgtbcSe.NullText = ""
        Me.DgtbcSe.Width = 75
        '
        'DgtbcJese
        '
        Me.DgtbcJese.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcJese.Format = ""
        Me.DgtbcJese.FormatInfo = Nothing
        Me.DgtbcJese.HeaderText = "价税合计"
        Me.DgtbcJese.MappingName = "jese"
        Me.DgtbcJese.NullText = ""
        Me.DgtbcJese.Width = 75
        '
        'DgtbcBzcb
        '
        Me.DgtbcBzcb.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcBzcb.Format = ""
        Me.DgtbcBzcb.FormatInfo = Nothing
        Me.DgtbcBzcb.HeaderText = "标准成本"
        Me.DgtbcBzcb.MappingName = "bzcb"
        Me.DgtbcBzcb.NullText = ""
        Me.DgtbcBzcb.Width = 75
        '
        'DgtbcWckje
        '
        Me.DgtbcWckje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcWckje.Format = ""
        Me.DgtbcWckje.FormatInfo = Nothing
        Me.DgtbcWckje.HeaderText = "未送货金额"
        Me.DgtbcWckje.MappingName = "wckje"
        Me.DgtbcWckje.NullText = ""
        Me.DgtbcWckje.Width = 90
        '
        'DgtbcKhddh
        '
        Me.DgtbcKhddh.Format = ""
        Me.DgtbcKhddh.FormatInfo = Nothing
        Me.DgtbcKhddh.HeaderText = "客户订单号"
        Me.DgtbcKhddh.MappingName = "khddh"
        Me.DgtbcKhddh.NullText = ""
        Me.DgtbcKhddh.Width = 90
        '
        'DgtbcKhlh
        '
        Me.DgtbcKhlh.Format = ""
        Me.DgtbcKhlh.FormatInfo = Nothing
        Me.DgtbcKhlh.HeaderText = "客户料号"
        Me.DgtbcKhlh.MappingName = "khlh"
        Me.DgtbcKhlh.NullText = ""
        Me.DgtbcKhlh.Width = 90
        '
        'DgtbcKhjhrq
        '
        Me.DgtbcKhjhrq.Format = ""
        Me.DgtbcKhjhrq.FormatInfo = Nothing
        Me.DgtbcKhjhrq.HeaderText = "客户交期"
        Me.DgtbcKhjhrq.MappingName = "khjhrq"
        Me.DgtbcKhjhrq.NullText = ""
        Me.DgtbcKhjhrq.Width = 75
        '
        'DgtbcZxgg
        '
        Me.DgtbcZxgg.Format = ""
        Me.DgtbcZxgg.FormatInfo = Nothing
        Me.DgtbcZxgg.HeaderText = "纸箱规格"
        Me.DgtbcZxgg.MappingName = "zxgg"
        Me.DgtbcZxgg.NullText = ""
        Me.DgtbcZxgg.Width = 90
        '
        'DgtbcDdmemo
        '
        Me.DgtbcDdmemo.Format = ""
        Me.DgtbcDdmemo.FormatInfo = Nothing
        Me.DgtbcDdmemo.HeaderText = "备注"
        Me.DgtbcDdmemo.MappingName = "ddmemo"
        Me.DgtbcDdmemo.NullText = ""
        Me.DgtbcDdmemo.Width = 90
        '
        'DgtbcScjhrq
        '
        Me.DgtbcScjhrq.Format = ""
        Me.DgtbcScjhrq.FormatInfo = Nothing
        Me.DgtbcScjhrq.HeaderText = "生产交期"
        Me.DgtbcScjhrq.MappingName = "scjhrq"
        Me.DgtbcScjhrq.NullText = ""
        Me.DgtbcScjhrq.Width = 90
        '
        'DgtbcCkrq
        '
        Me.DgtbcCkrq.Format = ""
        Me.DgtbcCkrq.FormatInfo = Nothing
        Me.DgtbcCkrq.HeaderText = "送货日期"
        Me.DgtbcCkrq.MappingName = "ckrq"
        Me.DgtbcCkrq.NullText = ""
        Me.DgtbcCkrq.Width = 90
        '
        'DgtbcSczydm
        '
        Me.DgtbcSczydm.Format = ""
        Me.DgtbcSczydm.FormatInfo = Nothing
        Me.DgtbcSczydm.HeaderText = "承接人编码"
        Me.DgtbcSczydm.MappingName = "sczydm"
        Me.DgtbcSczydm.NullText = ""
        Me.DgtbcSczydm.Width = 75
        '
        'DgtbcSczymc
        '
        Me.DgtbcSczymc.Format = ""
        Me.DgtbcSczymc.FormatInfo = Nothing
        Me.DgtbcSczymc.HeaderText = "承接人姓名"
        Me.DgtbcSczymc.MappingName = "sczymc"
        Me.DgtbcSczymc.NullText = ""
        Me.DgtbcSczymc.Width = 90
        '
        'DgtbcSrr
        '
        Me.DgtbcSrr.Format = ""
        Me.DgtbcSrr.FormatInfo = Nothing
        Me.DgtbcSrr.HeaderText = "输入人"
        Me.DgtbcSrr.MappingName = "srr"
        Me.DgtbcSrr.NullText = ""
        Me.DgtbcSrr.Width = 75
        '
        'DgtbcShr
        '
        Me.DgtbcShr.Format = ""
        Me.DgtbcShr.FormatInfo = Nothing
        Me.DgtbcShr.HeaderText = "审核人"
        Me.DgtbcShr.MappingName = "shr"
        Me.DgtbcShr.NullText = ""
        Me.DgtbcShr.Width = 75
        '
        'DgtbcSdjh
        '
        Me.DgtbcSdjh.Format = ""
        Me.DgtbcSdjh.FormatInfo = Nothing
        Me.DgtbcSdjh.HeaderText = "原订单单据号"
        Me.DgtbcSdjh.MappingName = "sdjh"
        Me.DgtbcSdjh.NullText = ""
        Me.DgtbcSdjh.Width = 110
        '
        'DgtbcSxh
        '
        Me.DgtbcSxh.Format = ""
        Me.DgtbcSxh.FormatInfo = Nothing
        Me.DgtbcSxh.HeaderText = "原订单单据行号"
        Me.DgtbcSxh.MappingName = "sxh"
        Me.DgtbcSxh.NullText = ""
        Me.DgtbcSxh.Width = 60
        '
        'FrmOeDdCxLb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmOeDdCxLb"
        Me.Text = "产品销售订单列表"
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DgtbcSl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDjh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcQdrq As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcXh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcKhdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcKhmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZydm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZymc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCpdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCpmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDw As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZxgg As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcKhjhrq As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcScjhrq As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSczydm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSczymc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDj As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJe As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDdmemo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcHxsl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcHth As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcRksl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCksl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDdtk As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcWrk As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcWck As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSrr As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcShr As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBzcb As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcKhddh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcMjsl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcFzsl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcFzdw As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcHsdj As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcShlv As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSe As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJese As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcKhlh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcFpsl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcWfp As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSktj As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSkqx As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcWckje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBclosed As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCkrq As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSdjh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSxh As System.Windows.Forms.DataGridTextBoxColumn
End Class
