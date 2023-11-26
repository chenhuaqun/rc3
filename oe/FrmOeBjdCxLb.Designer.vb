<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeBjdCxLb
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
        Me.DgtbcBjrq = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcKhdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcKhmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcZydm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcZymc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcEmail = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcBjtk = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcKhlh = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcKhcz = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCpdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCpmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCpgg = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcDw = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcWbdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcWbhl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcDj = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCkdw = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcZl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSpq = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcMoq = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcBjmemo = New System.Windows.Forms.DataGridTextBoxColumn
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
        Me.Label1.Location = New System.Drawing.Point(408, 8)
        Me.Label1.Size = New System.Drawing.Size(164, 23)
        Me.Label1.Text = "产品报价单列表"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.rcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcDjh, Me.DgtbcXh, Me.DgtbcBjrq, Me.DgtbcKhdm, Me.DgtbcKhmc, Me.DgtbcZydm, Me.DgtbcZymc, Me.DgtbcEmail, Me.DgtbcBjtk, Me.DgtbcKhlh, Me.DgtbcKhcz, Me.DgtbcCpdm, Me.DgtbcCpmc, Me.DgtbcCpgg, Me.DgtbcDw, Me.DgtbcZl, Me.DgtbcDj, Me.DgtbcCkdw, Me.DgtbcWbdm, Me.DgtbcWbhl, Me.DgtbcSpq, Me.DgtbcMoq, Me.DgtbcBjmemo, Me.DgtbcSrr, Me.DgtbcShr, Me.DgtbcJzr})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "bjdlb"
        '
        'DgtbcDjh
        '
        Me.DgtbcDjh.Format = ""
        Me.DgtbcDjh.FormatInfo = Nothing
        Me.DgtbcDjh.HeaderText = "报价单号"
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
        'DgtbcBjrq
        '
        Me.DgtbcBjrq.Format = ""
        Me.DgtbcBjrq.FormatInfo = Nothing
        Me.DgtbcBjrq.HeaderText = "报价日期"
        Me.DgtbcBjrq.MappingName = "bjrq"
        Me.DgtbcBjrq.NullText = ""
        Me.DgtbcBjrq.Width = 90
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
        Me.DgtbcKhmc.Width = 180
        '
        'DgtbcZydm
        '
        Me.DgtbcZydm.Format = ""
        Me.DgtbcZydm.FormatInfo = Nothing
        Me.DgtbcZydm.HeaderText = "职员编码"
        Me.DgtbcZydm.MappingName = "zydm"
        Me.DgtbcZydm.NullText = ""
        Me.DgtbcZydm.Width = 75
        '
        'DgtbcZymc
        '
        Me.DgtbcZymc.Format = ""
        Me.DgtbcZymc.FormatInfo = Nothing
        Me.DgtbcZymc.HeaderText = "职员姓名"
        Me.DgtbcZymc.MappingName = "zymc"
        Me.DgtbcZymc.NullText = ""
        Me.DgtbcZymc.Width = 75
        '
        'DgtbcEmail
        '
        Me.DgtbcEmail.Format = ""
        Me.DgtbcEmail.FormatInfo = Nothing
        Me.DgtbcEmail.HeaderText = "Email"
        Me.DgtbcEmail.MappingName = "email"
        Me.DgtbcEmail.NullText = ""
        Me.DgtbcEmail.Width = 75
        '
        'DgtbcBjtk
        '
        Me.DgtbcBjtk.Format = ""
        Me.DgtbcBjtk.FormatInfo = Nothing
        Me.DgtbcBjtk.HeaderText = "报价条款"
        Me.DgtbcBjtk.MappingName = "bjtk"
        Me.DgtbcBjtk.NullText = ""
        Me.DgtbcBjtk.Width = 75
        '
        'DgtbcKhlh
        '
        Me.DgtbcKhlh.Format = ""
        Me.DgtbcKhlh.FormatInfo = Nothing
        Me.DgtbcKhlh.HeaderText = "客户料号"
        Me.DgtbcKhlh.MappingName = "khlh"
        Me.DgtbcKhlh.NullText = ""
        Me.DgtbcKhlh.Width = 75
        '
        'DgtbcKhcz
        '
        Me.DgtbcKhcz.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcKhcz.Format = ""
        Me.DgtbcKhcz.FormatInfo = Nothing
        Me.DgtbcKhcz.HeaderText = "客户材质"
        Me.DgtbcKhcz.MappingName = "khcz"
        Me.DgtbcKhcz.NullText = ""
        Me.DgtbcKhcz.Width = 75
        '
        'DgtbcCpdm
        '
        Me.DgtbcCpdm.Format = ""
        Me.DgtbcCpdm.FormatInfo = Nothing
        Me.DgtbcCpdm.HeaderText = "产品编码"
        Me.DgtbcCpdm.MappingName = "cpdm"
        Me.DgtbcCpdm.NullText = ""
        Me.DgtbcCpdm.Width = 90
        '
        'DgtbcCpmc
        '
        Me.DgtbcCpmc.Format = ""
        Me.DgtbcCpmc.FormatInfo = Nothing
        Me.DgtbcCpmc.HeaderText = "产品名称"
        Me.DgtbcCpmc.MappingName = "cpmc"
        Me.DgtbcCpmc.NullText = ""
        Me.DgtbcCpmc.Width = 135
        '
        'DgtbcCpgg
        '
        Me.DgtbcCpgg.Format = ""
        Me.DgtbcCpgg.FormatInfo = Nothing
        Me.DgtbcCpgg.HeaderText = "规格型号"
        Me.DgtbcCpgg.MappingName = "cpgg"
        Me.DgtbcCpgg.NullText = ""
        Me.DgtbcCpgg.Width = 90
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
        'DgtbcWbdm
        '
        Me.DgtbcWbdm.Format = ""
        Me.DgtbcWbdm.FormatInfo = Nothing
        Me.DgtbcWbdm.HeaderText = "外币编码"
        Me.DgtbcWbdm.MappingName = "wbdm"
        Me.DgtbcWbdm.NullText = ""
        Me.DgtbcWbdm.Width = 75
        '
        'DgtbcWbhl
        '
        Me.DgtbcWbhl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcWbhl.Format = ""
        Me.DgtbcWbhl.FormatInfo = Nothing
        Me.DgtbcWbhl.HeaderText = "外币汇率"
        Me.DgtbcWbhl.MappingName = "wbhl"
        Me.DgtbcWbhl.NullText = ""
        Me.DgtbcWbhl.Width = 75
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
        'DgtbcCkdw
        '
        Me.DgtbcCkdw.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcCkdw.Format = ""
        Me.DgtbcCkdw.FormatInfo = Nothing
        Me.DgtbcCkdw.HeaderText = "参考吨位"
        Me.DgtbcCkdw.MappingName = "ckdw"
        Me.DgtbcCkdw.NullText = ""
        Me.DgtbcCkdw.Width = 75
        '
        'DgtbcZl
        '
        Me.DgtbcZl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcZl.Format = ""
        Me.DgtbcZl.FormatInfo = Nothing
        Me.DgtbcZl.HeaderText = "重量"
        Me.DgtbcZl.MappingName = "zl"
        Me.DgtbcZl.NullText = ""
        Me.DgtbcZl.Width = 75
        '
        'DgtbcSpq
        '
        Me.DgtbcSpq.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSpq.Format = ""
        Me.DgtbcSpq.FormatInfo = Nothing
        Me.DgtbcSpq.HeaderText = "标准包装量"
        Me.DgtbcSpq.MappingName = "spq"
        Me.DgtbcSpq.NullText = ""
        Me.DgtbcSpq.Width = 75
        '
        'DgtbcMoq
        '
        Me.DgtbcMoq.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcMoq.Format = ""
        Me.DgtbcMoq.FormatInfo = Nothing
        Me.DgtbcMoq.HeaderText = "最小订单量"
        Me.DgtbcMoq.MappingName = "moq"
        Me.DgtbcMoq.NullText = ""
        Me.DgtbcMoq.Width = 75
        '
        'DgtbcBjmemo
        '
        Me.DgtbcBjmemo.Format = ""
        Me.DgtbcBjmemo.FormatInfo = Nothing
        Me.DgtbcBjmemo.HeaderText = "备注"
        Me.DgtbcBjmemo.MappingName = "bjmemo"
        Me.DgtbcBjmemo.NullText = ""
        Me.DgtbcBjmemo.Width = 135
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
        'FrmOeBjdCxLb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmOeBjdCxLb"
        Me.Text = "产品报价单列表"
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
    Friend WithEvents DgtbcBjrq As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCpdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCpmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCpgg As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDw As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSrr As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcShr As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJzr As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcKhdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcKhmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcXh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDj As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBjtk As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBjmemo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcWbdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcKhlh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcKhcz As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcWbhl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZydm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZymc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcEmail As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSpq As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcMoq As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCkdw As System.Windows.Forms.DataGridTextBoxColumn
End Class
