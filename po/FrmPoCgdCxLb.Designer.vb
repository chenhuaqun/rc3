<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPoCgdCxLb
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
        Me.DgbcBClosed = New System.Windows.Forms.DataGridBoolColumn
        Me.DgtbcCgrq = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSgddh = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCsdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCsmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcFktj = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcFkts = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCpdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCpmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcOldCpdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcRksl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcRkje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcFpsl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcFpje = New System.Windows.Forms.DataGridTextBoxColumn
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
        Me.DgtbcWrksl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcWrkje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcFkje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJhshrq = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCgmemo = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCgjhDjh = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCgjhXh = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSrr = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSrrq = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcShr = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcShrq = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcRkrq = New System.Windows.Forms.DataGridTextBoxColumn
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
        Me.Label1.Text = "物料采购订单列表"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.rcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcDjh, Me.DgtbcXh, Me.DgbcBClosed, Me.DgtbcCgrq, Me.DgtbcSgddh, Me.DgtbcCsdm, Me.DgtbcCsmc, Me.DgtbcFktj, Me.DgtbcFkts, Me.DgtbcCpdm, Me.DgtbcCpmc, Me.DgtbcOldCpdm, Me.DgtbcSl, Me.DgtbcRksl, Me.DgtbcRkje, Me.DgtbcFpsl, Me.DgtbcFpje, Me.DgtbcDw, Me.DgtbcMjsl, Me.DgtbcFzsl, Me.DgtbcFzdw, Me.DgtbcDj, Me.DgtbcHsdj, Me.DgtbcJe, Me.DgtbcShlv, Me.DgtbcSe, Me.DgtbcJese, Me.DgtbcWrksl, Me.DgtbcWrkje, Me.DgtbcFkje, Me.DgtbcJhshrq, Me.DgtbcRkrq, Me.DgtbcCgmemo, Me.DgtbcCgjhDjh, Me.DgtbcCgjhXh, Me.DgtbcSrr, Me.DgtbcSrrq, Me.DgtbcShr, Me.DgtbcShrq})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "cgdlb"
        '
        'DgtbcDjh
        '
        Me.DgtbcDjh.Format = ""
        Me.DgtbcDjh.FormatInfo = Nothing
        Me.DgtbcDjh.HeaderText = "单据号"
        Me.DgtbcDjh.MappingName = "djh"
        Me.DgtbcDjh.NullText = ""
        Me.DgtbcDjh.Width = 110
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
        'DgbcBClosed
        '
        Me.DgbcBClosed.HeaderText = "关闭标志"
        Me.DgbcBClosed.MappingName = "bclosed"
        Me.DgbcBClosed.NullText = ""
        Me.DgbcBClosed.Width = 75
        '
        'DgtbcCgrq
        '
        Me.DgtbcCgrq.Format = ""
        Me.DgtbcCgrq.FormatInfo = Nothing
        Me.DgtbcCgrq.HeaderText = "采购日期"
        Me.DgtbcCgrq.MappingName = "cgrq"
        Me.DgtbcCgrq.NullText = ""
        Me.DgtbcCgrq.Width = 110
        '
        'DgtbcSgddh
        '
        Me.DgtbcSgddh.Format = ""
        Me.DgtbcSgddh.FormatInfo = Nothing
        Me.DgtbcSgddh.HeaderText = "手工订单号"
        Me.DgtbcSgddh.MappingName = "sgddh"
        Me.DgtbcSgddh.NullText = ""
        Me.DgtbcSgddh.Width = 110
        '
        'DgtbcCsdm
        '
        Me.DgtbcCsdm.Format = ""
        Me.DgtbcCsdm.FormatInfo = Nothing
        Me.DgtbcCsdm.HeaderText = "供应商编码"
        Me.DgtbcCsdm.MappingName = "csdm"
        Me.DgtbcCsdm.NullText = ""
        Me.DgtbcCsdm.Width = 90
        '
        'DgtbcCsmc
        '
        Me.DgtbcCsmc.Format = ""
        Me.DgtbcCsmc.FormatInfo = Nothing
        Me.DgtbcCsmc.HeaderText = "供应商名称"
        Me.DgtbcCsmc.MappingName = "csmc"
        Me.DgtbcCsmc.NullText = ""
        Me.DgtbcCsmc.Width = 180
        '
        'DgtbcFktj
        '
        Me.DgtbcFktj.Format = ""
        Me.DgtbcFktj.FormatInfo = Nothing
        Me.DgtbcFktj.HeaderText = "付款条件"
        Me.DgtbcFktj.MappingName = "fktj"
        Me.DgtbcFktj.NullText = ""
        Me.DgtbcFktj.Width = 75
        '
        'DgtbcFkts
        '
        Me.DgtbcFkts.Format = ""
        Me.DgtbcFkts.FormatInfo = Nothing
        Me.DgtbcFkts.HeaderText = "付款天数"
        Me.DgtbcFkts.MappingName = "fkts"
        Me.DgtbcFkts.NullText = ""
        Me.DgtbcFkts.Width = 75
        '
        'DgtbcCpdm
        '
        Me.DgtbcCpdm.Format = ""
        Me.DgtbcCpdm.FormatInfo = Nothing
        Me.DgtbcCpdm.HeaderText = "物料编码"
        Me.DgtbcCpdm.MappingName = "cpdm"
        Me.DgtbcCpdm.NullText = ""
        Me.DgtbcCpdm.Width = 90
        '
        'DgtbcCpmc
        '
        Me.DgtbcCpmc.Format = ""
        Me.DgtbcCpmc.FormatInfo = Nothing
        Me.DgtbcCpmc.HeaderText = "物料描述"
        Me.DgtbcCpmc.MappingName = "cpmc"
        Me.DgtbcCpmc.NullText = ""
        Me.DgtbcCpmc.Width = 240
        '
        'DgtbcOldCpdm
        '
        Me.DgtbcOldCpdm.Format = ""
        Me.DgtbcOldCpdm.FormatInfo = Nothing
        Me.DgtbcOldCpdm.HeaderText = "旧物料编码"
        Me.DgtbcOldCpdm.MappingName = "oldcpdm"
        Me.DgtbcOldCpdm.NullText = ""
        Me.DgtbcOldCpdm.Width = 90
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
        'DgtbcRksl
        '
        Me.DgtbcRksl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcRksl.Format = ""
        Me.DgtbcRksl.FormatInfo = Nothing
        Me.DgtbcRksl.HeaderText = "收货数量"
        Me.DgtbcRksl.MappingName = "rksl"
        Me.DgtbcRksl.NullText = ""
        Me.DgtbcRksl.Width = 90
        '
        'DgtbcRkje
        '
        Me.DgtbcRkje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcRkje.Format = ""
        Me.DgtbcRkje.FormatInfo = Nothing
        Me.DgtbcRkje.HeaderText = "收货金额"
        Me.DgtbcRkje.MappingName = "rkje"
        Me.DgtbcRkje.NullText = ""
        Me.DgtbcRkje.Width = 90
        '
        'DgtbcFpsl
        '
        Me.DgtbcFpsl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcFpsl.Format = ""
        Me.DgtbcFpsl.FormatInfo = Nothing
        Me.DgtbcFpsl.HeaderText = "开票数量"
        Me.DgtbcFpsl.MappingName = "fpsl"
        Me.DgtbcFpsl.NullText = ""
        Me.DgtbcFpsl.Width = 75
        '
        'DgtbcFpje
        '
        Me.DgtbcFpje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcFpje.Format = ""
        Me.DgtbcFpje.FormatInfo = Nothing
        Me.DgtbcFpje.HeaderText = "开票金额"
        Me.DgtbcFpje.MappingName = "fpje"
        Me.DgtbcFpje.NullText = ""
        Me.DgtbcFpje.Width = 75
        '
        'DgtbcDw
        '
        Me.DgtbcDw.Format = ""
        Me.DgtbcDw.FormatInfo = Nothing
        Me.DgtbcDw.HeaderText = "单位"
        Me.DgtbcDw.MappingName = "dw"
        Me.DgtbcDw.NullText = ""
        Me.DgtbcDw.Width = 45
        '
        'DgtbcMjsl
        '
        Me.DgtbcMjsl.Format = ""
        Me.DgtbcMjsl.FormatInfo = Nothing
        Me.DgtbcMjsl.HeaderText = "换算系数"
        Me.DgtbcMjsl.MappingName = "mjsl"
        Me.DgtbcMjsl.NullText = ""
        Me.DgtbcMjsl.Width = 90
        '
        'DgtbcFzsl
        '
        Me.DgtbcFzsl.Format = ""
        Me.DgtbcFzsl.FormatInfo = Nothing
        Me.DgtbcFzsl.HeaderText = "辅数量"
        Me.DgtbcFzsl.MappingName = "fzsl"
        Me.DgtbcFzsl.NullText = ""
        Me.DgtbcFzsl.Width = 90
        '
        'DgtbcFzdw
        '
        Me.DgtbcFzdw.Format = ""
        Me.DgtbcFzdw.FormatInfo = Nothing
        Me.DgtbcFzdw.HeaderText = "辅单位"
        Me.DgtbcFzdw.MappingName = "fzdw"
        Me.DgtbcFzdw.NullText = ""
        Me.DgtbcFzdw.Width = 45
        '
        'DgtbcDj
        '
        Me.DgtbcDj.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcDj.Format = ""
        Me.DgtbcDj.FormatInfo = Nothing
        Me.DgtbcDj.HeaderText = "不含税单价"
        Me.DgtbcDj.MappingName = "dj"
        Me.DgtbcDj.NullText = ""
        Me.DgtbcDj.Width = 90
        '
        'DgtbcHsdj
        '
        Me.DgtbcHsdj.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcHsdj.Format = ""
        Me.DgtbcHsdj.FormatInfo = Nothing
        Me.DgtbcHsdj.HeaderText = "含税单价"
        Me.DgtbcHsdj.MappingName = "hsdj"
        Me.DgtbcHsdj.NullText = ""
        Me.DgtbcHsdj.Width = 90
        '
        'DgtbcJe
        '
        Me.DgtbcJe.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcJe.Format = ""
        Me.DgtbcJe.FormatInfo = Nothing
        Me.DgtbcJe.HeaderText = "金额"
        Me.DgtbcJe.MappingName = "je"
        Me.DgtbcJe.NullText = ""
        Me.DgtbcJe.Width = 110
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
        Me.DgtbcSe.Width = 90
        '
        'DgtbcJese
        '
        Me.DgtbcJese.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcJese.Format = ""
        Me.DgtbcJese.FormatInfo = Nothing
        Me.DgtbcJese.HeaderText = "价税合计"
        Me.DgtbcJese.MappingName = "jese"
        Me.DgtbcJese.NullText = ""
        Me.DgtbcJese.Width = 90
        '
        'DgtbcWrksl
        '
        Me.DgtbcWrksl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcWrksl.Format = ""
        Me.DgtbcWrksl.FormatInfo = Nothing
        Me.DgtbcWrksl.HeaderText = "未入库数量"
        Me.DgtbcWrksl.MappingName = "wrksl"
        Me.DgtbcWrksl.NullText = ""
        Me.DgtbcWrksl.Width = 75
        '
        'DgtbcWrkje
        '
        Me.DgtbcWrkje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcWrkje.Format = ""
        Me.DgtbcWrkje.FormatInfo = Nothing
        Me.DgtbcWrkje.HeaderText = "未入库金额"
        Me.DgtbcWrkje.MappingName = "wrkje"
        Me.DgtbcWrkje.NullText = ""
        Me.DgtbcWrkje.Width = 75
        '
        'DgtbcFkje
        '
        Me.DgtbcFkje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcFkje.Format = ""
        Me.DgtbcFkje.FormatInfo = Nothing
        Me.DgtbcFkje.HeaderText = "付款金额"
        Me.DgtbcFkje.MappingName = "fkje"
        Me.DgtbcFkje.NullText = ""
        Me.DgtbcFkje.Width = 75
        '
        'DgtbcJhshrq
        '
        Me.DgtbcJhshrq.Format = ""
        Me.DgtbcJhshrq.FormatInfo = Nothing
        Me.DgtbcJhshrq.HeaderText = "计划收货日期"
        Me.DgtbcJhshrq.MappingName = "jhshrq"
        Me.DgtbcJhshrq.NullText = ""
        Me.DgtbcJhshrq.Width = 75
        '
        'DgtbcCgmemo
        '
        Me.DgtbcCgmemo.Format = ""
        Me.DgtbcCgmemo.FormatInfo = Nothing
        Me.DgtbcCgmemo.HeaderText = "备注"
        Me.DgtbcCgmemo.MappingName = "cgmemo"
        Me.DgtbcCgmemo.NullText = ""
        Me.DgtbcCgmemo.Width = 135
        '
        'DgtbcCgjhDjh
        '
        Me.DgtbcCgjhDjh.Format = ""
        Me.DgtbcCgjhDjh.FormatInfo = Nothing
        Me.DgtbcCgjhDjh.HeaderText = "物料采购/维修需求单单据号"
        Me.DgtbcCgjhDjh.MappingName = "cgjhdjh"
        Me.DgtbcCgjhDjh.NullText = ""
        Me.DgtbcCgjhDjh.Width = 110
        '
        'DgtbcCgjhXh
        '
        Me.DgtbcCgjhXh.Format = ""
        Me.DgtbcCgjhXh.FormatInfo = Nothing
        Me.DgtbcCgjhXh.HeaderText = "物料采购/维修需求单行号"
        Me.DgtbcCgjhXh.MappingName = "cgjhxh"
        Me.DgtbcCgjhXh.NullText = ""
        Me.DgtbcCgjhXh.Width = 45
        '
        'DgtbcSrr
        '
        Me.DgtbcSrr.Format = ""
        Me.DgtbcSrr.FormatInfo = Nothing
        Me.DgtbcSrr.HeaderText = "输入人"
        Me.DgtbcSrr.MappingName = "srr"
        Me.DgtbcSrr.NullText = ""
        Me.DgtbcSrr.Width = 90
        '
        'DgtbcSrrq
        '
        Me.DgtbcSrrq.Format = ""
        Me.DgtbcSrrq.FormatInfo = Nothing
        Me.DgtbcSrrq.HeaderText = "输入日期"
        Me.DgtbcSrrq.MappingName = "srrq"
        Me.DgtbcSrrq.NullText = ""
        Me.DgtbcSrrq.Width = 110
        '
        'DgtbcShr
        '
        Me.DgtbcShr.Format = ""
        Me.DgtbcShr.FormatInfo = Nothing
        Me.DgtbcShr.HeaderText = "审核人"
        Me.DgtbcShr.MappingName = "shr"
        Me.DgtbcShr.NullText = ""
        Me.DgtbcShr.Width = 90
        '
        'DgtbcShrq
        '
        Me.DgtbcShrq.Format = ""
        Me.DgtbcShrq.FormatInfo = Nothing
        Me.DgtbcShrq.HeaderText = "审核日期"
        Me.DgtbcShrq.MappingName = "shrq"
        Me.DgtbcShrq.NullText = ""
        Me.DgtbcShrq.Width = 110
        '
        'DgtbcRkrq
        '
        Me.DgtbcRkrq.Format = ""
        Me.DgtbcRkrq.FormatInfo = Nothing
        Me.DgtbcRkrq.HeaderText = "收货日期"
        Me.DgtbcRkrq.MappingName = "rkrq"
        Me.DgtbcRkrq.NullText = ""
        Me.DgtbcRkrq.Width = 110
        '
        'FrmPoCgdCxLb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmPoCgdCxLb"
        Me.Text = "物料采购订单列表"
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DgtbcDjh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCgrq As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcMjsl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCpdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCpmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDw As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDj As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCgmemo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSrr As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcShr As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSrrq As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcFzsl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcXh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCsdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJe As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCgjhDjh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCgjhXh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCsmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcShrq As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcRksl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcRkje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcFzdw As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcOldCpdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgbcBClosed As System.Windows.Forms.DataGridBoolColumn
    Friend WithEvents DgtbcJhshrq As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcHsdj As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcShlv As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSe As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJese As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSgddh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcFpsl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcFpje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcFktj As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcFkts As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcFkje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcWrksl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcWrkje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcRkrq As System.Windows.Forms.DataGridTextBoxColumn
End Class
