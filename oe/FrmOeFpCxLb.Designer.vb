<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeFpCxLb
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
        Me.DgtbcFprq = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcBdelete = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcKhdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcKhmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcYspz = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcZydm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcZymc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCpdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCpmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcHth = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSl = New System.Windows.Forms.DataGridTextBoxColumn
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
        Me.DgtbcSkje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcFpmemo = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcDddjh = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcDdxh = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcXsddjh = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcXsdxh = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcXsdDj = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcXsdHsdj = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcXsdJe = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcXsdShlv = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcXsdSe = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcXsdJece = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcXsdSece = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSrr = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSrrq = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcShr = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcShrq = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJzr = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCbje = New System.Windows.Forms.DataGridTextBoxColumn
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
        Me.Label1.Location = New System.Drawing.Point(357, 8)
        Me.Label1.Size = New System.Drawing.Size(266, 23)
        Me.Label1.Text = "产品销售单(销售发票)列表"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.rcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcDjh, Me.DgtbcXh, Me.DgtbcFprq, Me.DgtbcBdelete, Me.DgtbcKhdm, Me.DgtbcKhmc, Me.DgtbcYspz, Me.DgtbcZydm, Me.DgtbcZymc, Me.DgtbcCpdm, Me.DgtbcCpmc, Me.DgtbcHth, Me.DgtbcSl, Me.DgtbcDw, Me.DgtbcMjsl, Me.DgtbcFzsl, Me.DgtbcFzdw, Me.DgtbcDj, Me.DgtbcHsdj, Me.DgtbcJe, Me.DgtbcShlv, Me.DgtbcSe, Me.DgtbcJese, Me.DgtbcSkje, Me.DgtbcFpmemo, Me.DgtbcDddjh, Me.DgtbcDdxh, Me.DgtbcXsddjh, Me.DgtbcXsdxh, Me.DgtbcXsdDj, Me.DgtbcXsdHsdj, Me.DgtbcXsdJe, Me.DgtbcXsdShlv, Me.DgtbcXsdSe, Me.DgtbcXsdJece, Me.DgtbcXsdSece, Me.DgtbcSrr, Me.DgtbcSrrq, Me.DgtbcShr, Me.DgtbcShrq, Me.DgtbcJzr, Me.DgtbcCbje})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "xsdlb"
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
        'DgtbcFprq
        '
        Me.DgtbcFprq.Format = ""
        Me.DgtbcFprq.FormatInfo = Nothing
        Me.DgtbcFprq.HeaderText = "发票日期"
        Me.DgtbcFprq.MappingName = "fprq"
        Me.DgtbcFprq.NullText = ""
        Me.DgtbcFprq.Width = 110
        '
        'DgtbcBdelete
        '
        Me.DgtbcBdelete.Format = ""
        Me.DgtbcBdelete.FormatInfo = Nothing
        Me.DgtbcBdelete.HeaderText = "作废"
        Me.DgtbcBdelete.MappingName = "bdelete"
        Me.DgtbcBdelete.NullText = ""
        Me.DgtbcBdelete.Width = 45
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
        'DgtbcYspz
        '
        Me.DgtbcYspz.Format = ""
        Me.DgtbcYspz.FormatInfo = Nothing
        Me.DgtbcYspz.HeaderText = "发票号码"
        Me.DgtbcYspz.MappingName = "yspz"
        Me.DgtbcYspz.NullText = ""
        Me.DgtbcYspz.Width = 75
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
        Me.DgtbcCpmc.HeaderText = "产品描述"
        Me.DgtbcCpmc.MappingName = "cpmc"
        Me.DgtbcCpmc.NullText = ""
        Me.DgtbcCpmc.Width = 250
        '
        'DgtbcHth
        '
        Me.DgtbcHth.Format = ""
        Me.DgtbcHth.FormatInfo = Nothing
        Me.DgtbcHth.HeaderText = "订单编码"
        Me.DgtbcHth.MappingName = "hth"
        Me.DgtbcHth.NullText = ""
        Me.DgtbcHth.Width = 75
        '
        'DgtbcSl
        '
        Me.DgtbcSl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSl.Format = ""
        Me.DgtbcSl.FormatInfo = Nothing
        Me.DgtbcSl.HeaderText = "数量"
        Me.DgtbcSl.MappingName = "sl"
        Me.DgtbcSl.NullText = ""
        Me.DgtbcSl.Width = 75
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
        Me.DgtbcMjsl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcMjsl.Format = ""
        Me.DgtbcMjsl.FormatInfo = Nothing
        Me.DgtbcMjsl.HeaderText = "换算系数"
        Me.DgtbcMjsl.MappingName = "mjsl"
        Me.DgtbcMjsl.NullText = ""
        Me.DgtbcMjsl.Width = 75
        '
        'DgtbcFzsl
        '
        Me.DgtbcFzsl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.DgtbcDj.HeaderText = "单价"
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
        'DgtbcSkje
        '
        Me.DgtbcSkje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSkje.Format = ""
        Me.DgtbcSkje.FormatInfo = Nothing
        Me.DgtbcSkje.HeaderText = "收款金额"
        Me.DgtbcSkje.MappingName = "skje"
        Me.DgtbcSkje.NullText = ""
        Me.DgtbcSkje.Width = 75
        '
        'DgtbcFpmemo
        '
        Me.DgtbcFpmemo.Format = ""
        Me.DgtbcFpmemo.FormatInfo = Nothing
        Me.DgtbcFpmemo.HeaderText = "备注"
        Me.DgtbcFpmemo.MappingName = "fpmemo"
        Me.DgtbcFpmemo.NullText = ""
        Me.DgtbcFpmemo.Width = 90
        '
        'DgtbcDddjh
        '
        Me.DgtbcDddjh.Format = ""
        Me.DgtbcDddjh.FormatInfo = Nothing
        Me.DgtbcDddjh.HeaderText = "订单单据号"
        Me.DgtbcDddjh.MappingName = "dddjh"
        Me.DgtbcDddjh.NullText = ""
        Me.DgtbcDddjh.Width = 105
        '
        'DgtbcDdxh
        '
        Me.DgtbcDdxh.Format = ""
        Me.DgtbcDdxh.FormatInfo = Nothing
        Me.DgtbcDdxh.HeaderText = "订单行号"
        Me.DgtbcDdxh.MappingName = "ddxh"
        Me.DgtbcDdxh.NullText = ""
        Me.DgtbcDdxh.Width = 45
        '
        'DgtbcXsddjh
        '
        Me.DgtbcXsddjh.Format = ""
        Me.DgtbcXsddjh.FormatInfo = Nothing
        Me.DgtbcXsddjh.HeaderText = "送货单单据号"
        Me.DgtbcXsddjh.MappingName = "xsddjh"
        Me.DgtbcXsddjh.NullText = ""
        Me.DgtbcXsddjh.Width = 105
        '
        'DgtbcXsdxh
        '
        Me.DgtbcXsdxh.Format = ""
        Me.DgtbcXsdxh.FormatInfo = Nothing
        Me.DgtbcXsdxh.HeaderText = "送货单行号"
        Me.DgtbcXsdxh.MappingName = "xsdxh"
        Me.DgtbcXsdxh.NullText = ""
        Me.DgtbcXsdxh.Width = 45
        '
        'DgtbcXsdDj
        '
        Me.DgtbcXsdDj.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcXsdDj.Format = ""
        Me.DgtbcXsdDj.FormatInfo = Nothing
        Me.DgtbcXsdDj.HeaderText = "送货单不含税单价"
        Me.DgtbcXsdDj.MappingName = "xsddj"
        Me.DgtbcXsdDj.NullText = ""
        Me.DgtbcXsdDj.Width = 90
        '
        'DgtbcXsdHsdj
        '
        Me.DgtbcXsdHsdj.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcXsdHsdj.Format = ""
        Me.DgtbcXsdHsdj.FormatInfo = Nothing
        Me.DgtbcXsdHsdj.HeaderText = "送货单含税单价"
        Me.DgtbcXsdHsdj.MappingName = "xsdhsdj"
        Me.DgtbcXsdHsdj.NullText = ""
        Me.DgtbcXsdHsdj.Width = 90
        '
        'DgtbcXsdJe
        '
        Me.DgtbcXsdJe.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcXsdJe.Format = ""
        Me.DgtbcXsdJe.FormatInfo = Nothing
        Me.DgtbcXsdJe.HeaderText = "送货单金额"
        Me.DgtbcXsdJe.MappingName = "xsdje"
        Me.DgtbcXsdJe.NullText = ""
        Me.DgtbcXsdJe.Width = 90
        '
        'DgtbcXsdShlv
        '
        Me.DgtbcXsdShlv.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcXsdShlv.Format = ""
        Me.DgtbcXsdShlv.FormatInfo = Nothing
        Me.DgtbcXsdShlv.HeaderText = "送货单税率"
        Me.DgtbcXsdShlv.MappingName = "xsdshlv"
        Me.DgtbcXsdShlv.NullText = ""
        Me.DgtbcXsdShlv.Width = 60
        '
        'DgtbcXsdSe
        '
        Me.DgtbcXsdSe.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcXsdSe.Format = ""
        Me.DgtbcXsdSe.FormatInfo = Nothing
        Me.DgtbcXsdSe.HeaderText = "送货单税额"
        Me.DgtbcXsdSe.MappingName = "xsdse"
        Me.DgtbcXsdSe.NullText = ""
        Me.DgtbcXsdSe.Width = 90
        '
        'DgtbcXsdJece
        '
        Me.DgtbcXsdJece.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcXsdJece.Format = ""
        Me.DgtbcXsdJece.FormatInfo = Nothing
        Me.DgtbcXsdJece.HeaderText = "金额差额"
        Me.DgtbcXsdJece.MappingName = "xsdjece"
        Me.DgtbcXsdJece.NullText = ""
        Me.DgtbcXsdJece.Width = 90
        '
        'DgtbcXsdSece
        '
        Me.DgtbcXsdSece.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcXsdSece.Format = ""
        Me.DgtbcXsdSece.FormatInfo = Nothing
        Me.DgtbcXsdSece.HeaderText = "税额差额"
        Me.DgtbcXsdSece.MappingName = "xsdsece"
        Me.DgtbcXsdSece.NullText = ""
        Me.DgtbcXsdSece.Width = 90
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
        'DgtbcSrrq
        '
        Me.DgtbcSrrq.Format = ""
        Me.DgtbcSrrq.FormatInfo = Nothing
        Me.DgtbcSrrq.HeaderText = "输入时间"
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
        Me.DgtbcShr.Width = 75
        '
        'DgtbcShrq
        '
        Me.DgtbcShrq.Format = ""
        Me.DgtbcShrq.FormatInfo = Nothing
        Me.DgtbcShrq.HeaderText = "审核时间"
        Me.DgtbcShrq.MappingName = "shrq"
        Me.DgtbcShrq.NullText = ""
        Me.DgtbcShrq.Width = 110
        '
        'DgtbcJzr
        '
        Me.DgtbcJzr.Format = ""
        Me.DgtbcJzr.FormatInfo = Nothing
        Me.DgtbcJzr.HeaderText = "记账人"
        Me.DgtbcJzr.MappingName = "jzr"
        Me.DgtbcJzr.NullText = ""
        Me.DgtbcJzr.Width = 75
        '
        'DgtbcCbje
        '
        Me.DgtbcCbje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcCbje.Format = ""
        Me.DgtbcCbje.FormatInfo = Nothing
        Me.DgtbcCbje.HeaderText = "成本金额"
        Me.DgtbcCbje.MappingName = "cbje"
        Me.DgtbcCbje.NullText = ""
        Me.DgtbcCbje.Width = 90
        '
        'FrmOeFpCxLb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmOeFpCxLb"
        Me.Text = "产品销售单(销售发票)列表"
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
    Friend WithEvents DgtbcFprq As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcXh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcKhdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcKhmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZydm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZymc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCpdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCpmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDw As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJzr As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDj As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJe As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcFpmemo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcHth As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcMjsl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSrr As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcShr As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBdelete As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSkje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcFzsl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcFzdw As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcYspz As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcHsdj As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcShlv As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSe As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJese As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSrrq As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcShrq As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDddjh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDdxh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcXsddjh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcXsdxh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcXsdDj As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcXsdHsdj As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcXsdJe As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcXsdShlv As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcXsdSe As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcXsdJece As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcXsdSece As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCbje As System.Windows.Forms.DataGridTextBoxColumn
End Class
