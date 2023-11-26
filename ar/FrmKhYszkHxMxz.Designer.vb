<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmKhYszkHxMxz
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
        Me.DgtbcKhdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcKhmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcFprq = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcXsdDjh = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcXsdXh = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCpdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCpmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcDw = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcXssl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcXsdj = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcXsje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcHxje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcBzcb = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcXstcbl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSkrq = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSkdDjh = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSkje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSkts = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSkqx = New System.Windows.Forms.DataGridTextBoxColumn
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
        Me.Label1.Location = New System.Drawing.Point(364, 8)
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(252, 23)
        Me.Label1.Text = "客户应收账款核销明细账"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.rcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcKhdm, Me.DgtbcKhmc, Me.DgtbcFprq, Me.DgtbcXsdDjh, Me.DgtbcXsdXh, Me.DgtbcCpdm, Me.DgtbcCpmc, Me.DgtbcDw, Me.DgtbcXssl, Me.DgtbcXsdj, Me.DgtbcXsje, Me.DgtbcHxje, Me.DgtbcBzcb, Me.DgtbcXstcbl, Me.DgtbcSkrq, Me.DgtbcSkdDjh, Me.DgtbcSkje, Me.DgtbcSkts, Me.DgtbcSkqx})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "khyszkhxmx"
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
        Me.DgtbcKhmc.Width = 180
        '
        'DgtbcFprq
        '
        Me.DgtbcFprq.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DgtbcFprq.Format = ""
        Me.DgtbcFprq.FormatInfo = Nothing
        Me.DgtbcFprq.HeaderText = "发票日期"
        Me.DgtbcFprq.MappingName = "fprq"
        Me.DgtbcFprq.NullText = ""
        Me.DgtbcFprq.Width = 75
        '
        'DgtbcXsdDjh
        '
        Me.DgtbcXsdDjh.Format = ""
        Me.DgtbcXsdDjh.FormatInfo = Nothing
        Me.DgtbcXsdDjh.HeaderText = "销售单单据号"
        Me.DgtbcXsdDjh.MappingName = "xsddjh"
        Me.DgtbcXsdDjh.NullText = ""
        Me.DgtbcXsdDjh.Width = 110
        '
        'DgtbcXsdXh
        '
        Me.DgtbcXsdXh.Format = ""
        Me.DgtbcXsdXh.FormatInfo = Nothing
        Me.DgtbcXsdXh.HeaderText = "销售单行号"
        Me.DgtbcXsdXh.MappingName = "xsdxh"
        Me.DgtbcXsdXh.NullText = ""
        Me.DgtbcXsdXh.Width = 45
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
        'DgtbcDw
        '
        Me.DgtbcDw.Format = ""
        Me.DgtbcDw.FormatInfo = Nothing
        Me.DgtbcDw.HeaderText = "单位"
        Me.DgtbcDw.MappingName = "dw"
        Me.DgtbcDw.NullText = ""
        Me.DgtbcDw.Width = 30
        '
        'DgtbcXssl
        '
        Me.DgtbcXssl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcXssl.Format = ""
        Me.DgtbcXssl.FormatInfo = Nothing
        Me.DgtbcXssl.HeaderText = "销售数量"
        Me.DgtbcXssl.MappingName = "xssl"
        Me.DgtbcXssl.NullText = ""
        Me.DgtbcXssl.Width = 90
        '
        'DgtbcXsdj
        '
        Me.DgtbcXsdj.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcXsdj.Format = ""
        Me.DgtbcXsdj.FormatInfo = Nothing
        Me.DgtbcXsdj.HeaderText = "销售单价"
        Me.DgtbcXsdj.MappingName = "xsdj"
        Me.DgtbcXsdj.NullText = ""
        Me.DgtbcXsdj.Width = 90
        '
        'DgtbcXsje
        '
        Me.DgtbcXsje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcXsje.Format = ""
        Me.DgtbcXsje.FormatInfo = Nothing
        Me.DgtbcXsje.HeaderText = "销售金额"
        Me.DgtbcXsje.MappingName = "xsje"
        Me.DgtbcXsje.NullText = ""
        Me.DgtbcXsje.Width = 90
        '
        'DgtbcHxje
        '
        Me.DgtbcHxje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcHxje.Format = ""
        Me.DgtbcHxje.FormatInfo = Nothing
        Me.DgtbcHxje.HeaderText = "核销金额"
        Me.DgtbcHxje.MappingName = "hxje"
        Me.DgtbcHxje.NullText = ""
        Me.DgtbcHxje.Width = 90
        '
        'DgtbcBzcb
        '
        Me.DgtbcBzcb.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcBzcb.Format = ""
        Me.DgtbcBzcb.FormatInfo = Nothing
        Me.DgtbcBzcb.HeaderText = "标准成本"
        Me.DgtbcBzcb.MappingName = "bzcb"
        Me.DgtbcBzcb.NullText = ""
        Me.DgtbcBzcb.Width = 90
        '
        'DgtbcXstcbl
        '
        Me.DgtbcXstcbl.Format = ""
        Me.DgtbcXstcbl.FormatInfo = Nothing
        Me.DgtbcXstcbl.HeaderText = "销售提成比例"
        Me.DgtbcXstcbl.MappingName = "xstcbl"
        Me.DgtbcXstcbl.NullText = ""
        Me.DgtbcXstcbl.Width = 75
        '
        'DgtbcSkrq
        '
        Me.DgtbcSkrq.Format = ""
        Me.DgtbcSkrq.FormatInfo = Nothing
        Me.DgtbcSkrq.HeaderText = "收款日期"
        Me.DgtbcSkrq.MappingName = "skrq"
        Me.DgtbcSkrq.NullText = ""
        Me.DgtbcSkrq.Width = 75
        '
        'DgtbcSkdDjh
        '
        Me.DgtbcSkdDjh.Format = ""
        Me.DgtbcSkdDjh.FormatInfo = Nothing
        Me.DgtbcSkdDjh.HeaderText = "收款单单据号"
        Me.DgtbcSkdDjh.MappingName = "skddjh"
        Me.DgtbcSkdDjh.NullText = ""
        Me.DgtbcSkdDjh.Width = 110
        '
        'DgtbcSkje
        '
        Me.DgtbcSkje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSkje.Format = ""
        Me.DgtbcSkje.FormatInfo = Nothing
        Me.DgtbcSkje.HeaderText = "收款金额"
        Me.DgtbcSkje.MappingName = "skje"
        Me.DgtbcSkje.NullText = ""
        Me.DgtbcSkje.Width = 90
        '
        'DgtbcSkts
        '
        Me.DgtbcSkts.Format = ""
        Me.DgtbcSkts.FormatInfo = Nothing
        Me.DgtbcSkts.HeaderText = "收款天数"
        Me.DgtbcSkts.MappingName = "skts"
        Me.DgtbcSkts.NullText = ""
        Me.DgtbcSkts.Width = 75
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
        'FrmKhYszkHxMxz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmKhYszkHxMxz"
        Me.Text = "客户应收账款核销明细账"
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DgtbcXsdDjh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcFprq As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcXsdXh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCpdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCpmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDw As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcXsje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSkje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcHxje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSkrq As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSkdDjh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBzcb As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcKhdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcKhmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcXssl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcXsdj As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcXstcbl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSkts As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSkqx As System.Windows.Forms.DataGridTextBoxColumn
End Class
