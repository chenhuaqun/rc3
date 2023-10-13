<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGlPzCxLb
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
        Me.DgtbcBdelete = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcPzrq = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcFjzs = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJd = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcZy = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcKmdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcKmmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcBmdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcBmmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcXmdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcXmmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcKhdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcKhmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCsdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCsmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJxzh = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcDfkm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcDw = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcDj = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcBz = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcWb = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcHl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJe = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcYspz = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJsr = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcWldqr = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSrr = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcShr = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJzr = New System.Windows.Forms.DataGridTextBoxColumn
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
        Me.Label1.Location = New System.Drawing.Point(419, 8)
        Me.Label1.Size = New System.Drawing.Size(142, 23)
        Me.Label1.Text = "记账凭证列表"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.rcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcDjh, Me.DgtbcXh, Me.DgtbcBdelete, Me.DgtbcPzrq, Me.DgtbcFjzs, Me.DgtbcJd, Me.DgtbcZy, Me.DgtbcKmdm, Me.DgtbcKmmc, Me.DgtbcBmdm, Me.DgtbcBmmc, Me.DgtbcXmdm, Me.DgtbcXmmc, Me.DgtbcKhdm, Me.DgtbcKhmc, Me.DgtbcCsdm, Me.DgtbcCsmc, Me.DgtbcJxzh, Me.DgtbcDfkm, Me.DgtbcDw, Me.DgtbcSl, Me.DgtbcDj, Me.DgtbcBz, Me.DgtbcWb, Me.DgtbcHl, Me.DgtbcJe, Me.DgtbcYspz, Me.DgtbcJsr, Me.DgtbcWldqr, Me.DgtbcSrr, Me.DgtbcShr, Me.DgtbcJzr})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "pzlb"
        '
        'DgtbcDjh
        '
        Me.DgtbcDjh.Format = ""
        Me.DgtbcDjh.FormatInfo = Nothing
        Me.DgtbcDjh.HeaderText = "凭证号"
        Me.DgtbcDjh.MappingName = "djh"
        Me.DgtbcDjh.NullText = ""
        Me.DgtbcDjh.Width = 120
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
        'DgtbcBdelete
        '
        Me.DgtbcBdelete.Format = ""
        Me.DgtbcBdelete.FormatInfo = Nothing
        Me.DgtbcBdelete.HeaderText = "作废"
        Me.DgtbcBdelete.MappingName = "bdelete"
        Me.DgtbcBdelete.NullText = ""
        Me.DgtbcBdelete.Width = 45
        '
        'DgtbcPzrq
        '
        Me.DgtbcPzrq.Format = ""
        Me.DgtbcPzrq.FormatInfo = Nothing
        Me.DgtbcPzrq.HeaderText = "凭证日期"
        Me.DgtbcPzrq.MappingName = "pzrq"
        Me.DgtbcPzrq.NullText = ""
        Me.DgtbcPzrq.Width = 90
        '
        'DgtbcFjzs
        '
        Me.DgtbcFjzs.Format = ""
        Me.DgtbcFjzs.FormatInfo = Nothing
        Me.DgtbcFjzs.HeaderText = "附件张数"
        Me.DgtbcFjzs.MappingName = "fjzs"
        Me.DgtbcFjzs.NullText = ""
        Me.DgtbcFjzs.Width = 45
        '
        'DgtbcJd
        '
        Me.DgtbcJd.Format = ""
        Me.DgtbcJd.FormatInfo = Nothing
        Me.DgtbcJd.HeaderText = "借贷"
        Me.DgtbcJd.MappingName = "jd"
        Me.DgtbcJd.NullText = ""
        Me.DgtbcJd.Width = 45
        '
        'DgtbcZy
        '
        Me.DgtbcZy.Format = ""
        Me.DgtbcZy.FormatInfo = Nothing
        Me.DgtbcZy.HeaderText = "摘要"
        Me.DgtbcZy.MappingName = "zy"
        Me.DgtbcZy.NullText = ""
        Me.DgtbcZy.Width = 135
        '
        'DgtbcKmdm
        '
        Me.DgtbcKmdm.Format = ""
        Me.DgtbcKmdm.FormatInfo = Nothing
        Me.DgtbcKmdm.HeaderText = "科目编码"
        Me.DgtbcKmdm.MappingName = "kmdm"
        Me.DgtbcKmdm.NullText = ""
        Me.DgtbcKmdm.Width = 90
        '
        'DgtbcKmmc
        '
        Me.DgtbcKmmc.Format = ""
        Me.DgtbcKmmc.FormatInfo = Nothing
        Me.DgtbcKmmc.HeaderText = "科目名称"
        Me.DgtbcKmmc.MappingName = "kmmc"
        Me.DgtbcKmmc.NullText = ""
        Me.DgtbcKmmc.Width = 135
        '
        'DgtbcBmdm
        '
        Me.DgtbcBmdm.Format = ""
        Me.DgtbcBmdm.FormatInfo = Nothing
        Me.DgtbcBmdm.HeaderText = "部门编码"
        Me.DgtbcBmdm.MappingName = "bmdm"
        Me.DgtbcBmdm.NullText = ""
        Me.DgtbcBmdm.Width = 90
        '
        'DgtbcBmmc
        '
        Me.DgtbcBmmc.Format = ""
        Me.DgtbcBmmc.FormatInfo = Nothing
        Me.DgtbcBmmc.HeaderText = "部门名称"
        Me.DgtbcBmmc.MappingName = "bmmc"
        Me.DgtbcBmmc.NullText = ""
        Me.DgtbcBmmc.Width = 135
        '
        'DgtbcXmdm
        '
        Me.DgtbcXmdm.Format = ""
        Me.DgtbcXmdm.FormatInfo = Nothing
        Me.DgtbcXmdm.HeaderText = "项目编码"
        Me.DgtbcXmdm.MappingName = "xmdm"
        Me.DgtbcXmdm.NullText = ""
        Me.DgtbcXmdm.Width = 90
        '
        'DgtbcXmmc
        '
        Me.DgtbcXmmc.Format = ""
        Me.DgtbcXmmc.FormatInfo = Nothing
        Me.DgtbcXmmc.HeaderText = "项目名称"
        Me.DgtbcXmmc.MappingName = "xmmc"
        Me.DgtbcXmmc.NullText = ""
        Me.DgtbcXmmc.Width = 135
        '
        'DgtbcKhdm
        '
        Me.DgtbcKhdm.Format = ""
        Me.DgtbcKhdm.FormatInfo = Nothing
        Me.DgtbcKhdm.HeaderText = "客户编码"
        Me.DgtbcKhdm.MappingName = "khdm"
        Me.DgtbcKhdm.NullText = ""
        Me.DgtbcKhdm.Width = 90
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
        'DgtbcJxzh
        '
        Me.DgtbcJxzh.Format = ""
        Me.DgtbcJxzh.FormatInfo = Nothing
        Me.DgtbcJxzh.HeaderText = "计息账号"
        Me.DgtbcJxzh.MappingName = "rckdm"
        Me.DgtbcJxzh.NullText = ""
        Me.DgtbcJxzh.Width = 90
        '
        'DgtbcDfkm
        '
        Me.DgtbcDfkm.Format = ""
        Me.DgtbcDfkm.FormatInfo = Nothing
        Me.DgtbcDfkm.HeaderText = "对方科目"
        Me.DgtbcDfkm.MappingName = "dfkm"
        Me.DgtbcDfkm.NullText = ""
        Me.DgtbcDfkm.Width = 135
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
        'DgtbcBz
        '
        Me.DgtbcBz.Format = ""
        Me.DgtbcBz.FormatInfo = Nothing
        Me.DgtbcBz.HeaderText = "币种"
        Me.DgtbcBz.MappingName = "bz"
        Me.DgtbcBz.NullText = ""
        Me.DgtbcBz.Width = 45
        '
        'DgtbcWb
        '
        Me.DgtbcWb.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcWb.Format = ""
        Me.DgtbcWb.FormatInfo = Nothing
        Me.DgtbcWb.HeaderText = "外币"
        Me.DgtbcWb.MappingName = "wb"
        Me.DgtbcWb.NullText = ""
        Me.DgtbcWb.Width = 75
        '
        'DgtbcHl
        '
        Me.DgtbcHl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcHl.Format = ""
        Me.DgtbcHl.FormatInfo = Nothing
        Me.DgtbcHl.HeaderText = "汇率"
        Me.DgtbcHl.MappingName = "hl"
        Me.DgtbcHl.NullText = ""
        Me.DgtbcHl.Width = 75
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
        'DgtbcYspz
        '
        Me.DgtbcYspz.Format = ""
        Me.DgtbcYspz.FormatInfo = Nothing
        Me.DgtbcYspz.HeaderText = "原始凭证号"
        Me.DgtbcYspz.MappingName = "yspz"
        Me.DgtbcYspz.NullText = ""
        Me.DgtbcYspz.Width = 75
        '
        'DgtbcJsr
        '
        Me.DgtbcJsr.Format = ""
        Me.DgtbcJsr.FormatInfo = Nothing
        Me.DgtbcJsr.HeaderText = "经手人"
        Me.DgtbcJsr.MappingName = "jsr"
        Me.DgtbcJsr.NullText = ""
        Me.DgtbcJsr.Width = 75
        '
        'DgtbcWldqr
        '
        Me.DgtbcWldqr.Format = ""
        Me.DgtbcWldqr.FormatInfo = Nothing
        Me.DgtbcWldqr.HeaderText = "往来到期日"
        Me.DgtbcWldqr.MappingName = "wldqr"
        Me.DgtbcWldqr.NullText = ""
        Me.DgtbcWldqr.Width = 75
        '
        'DgtbcSrr
        '
        Me.DgtbcSrr.Format = ""
        Me.DgtbcSrr.FormatInfo = Nothing
        Me.DgtbcSrr.HeaderText = "输入"
        Me.DgtbcSrr.MappingName = "srr"
        Me.DgtbcSrr.NullText = ""
        Me.DgtbcSrr.Width = 75
        '
        'DgtbcShr
        '
        Me.DgtbcShr.Format = ""
        Me.DgtbcShr.FormatInfo = Nothing
        Me.DgtbcShr.HeaderText = "审核"
        Me.DgtbcShr.MappingName = "shr"
        Me.DgtbcShr.NullText = ""
        Me.DgtbcShr.Width = 75
        '
        'DgtbcJzr
        '
        Me.DgtbcJzr.Format = ""
        Me.DgtbcJzr.FormatInfo = Nothing
        Me.DgtbcJzr.HeaderText = "记账"
        Me.DgtbcJzr.MappingName = "jzr"
        Me.DgtbcJzr.NullText = ""
        Me.DgtbcJzr.Width = 75
        '
        'FrmGlPzCxLb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmGlPzCxLb"
        Me.Text = "记账凭证列表"
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
    Friend WithEvents DgtbcPzrq As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcKhdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcKmdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcKmmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBmdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcXmdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDw As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDj As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBmmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSrr As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcShr As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJzr As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcKhmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCsdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJd As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJe As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJxzh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCsmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcFjzs As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcXh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBdelete As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZy As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcXmmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDfkm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBz As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcWb As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcHl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcYspz As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJsr As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcWldqr As System.Windows.Forms.DataGridTextBoxColumn
End Class
