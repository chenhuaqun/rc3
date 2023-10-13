<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmYwfZyMxz
    Inherits models.FrmReportView

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DgtbcKhdm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcKhmc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcXslbdm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgbcGjxslb = New System.Windows.Forms.DataGridBoolColumn()
        Me.DgtbcYwfbl = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcBnqc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcBnjf = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcBndf = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcBndj = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcBnHl = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcYwf_bz = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcSnhl = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DbgcBywfjszz = New System.Windows.Forms.DataGridBoolColumn()
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RcDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RcDataGrid
        '
        Me.RcDataGrid.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(364, 8)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Size = New System.Drawing.Size(252, 23)
        Me.Label1.Text = "业务费业务员计算明细表"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.RcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcKhdm, Me.DgtbcKhmc, Me.DgtbcXslbdm, Me.DgbcGjxslb, Me.DbgcBywfjszz, Me.DgtbcYwfbl, Me.DgtbcBnqc, Me.DgtbcBnjf, Me.DgtbcBndf, Me.DgtbcBndj, Me.DgtbcBnHl, Me.DgtbcYwf_bz, Me.DgtbcSnhl})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "ywfzymx"
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
        Me.DgtbcKhmc.Width = 150
        '
        'DgtbcXslbdm
        '
        Me.DgtbcXslbdm.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DgtbcXslbdm.Format = ""
        Me.DgtbcXslbdm.FormatInfo = Nothing
        Me.DgtbcXslbdm.HeaderText = "客户类别"
        Me.DgtbcXslbdm.MappingName = "xslbdm"
        Me.DgtbcXslbdm.NullText = ""
        Me.DgtbcXslbdm.Width = 75
        '
        'DgbcGjxslb
        '
        Me.DgbcGjxslb.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DgbcGjxslb.HeaderText = "关键销售类别"
        Me.DgbcGjxslb.MappingName = "gjxslb"
        Me.DgbcGjxslb.NullText = ""
        Me.DgbcGjxslb.Width = 75
        '
        'DgtbcYwfbl
        '
        Me.DgtbcYwfbl.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DgtbcYwfbl.Format = ""
        Me.DgtbcYwfbl.FormatInfo = Nothing
        Me.DgtbcYwfbl.HeaderText = "结算系数"
        Me.DgtbcYwfbl.MappingName = "ywfbl"
        Me.DgtbcYwfbl.NullText = ""
        Me.DgtbcYwfbl.Width = 75
        '
        'DgtbcBnqc
        '
        Me.DgtbcBnqc.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcBnqc.Format = ""
        Me.DgtbcBnqc.FormatInfo = Nothing
        Me.DgtbcBnqc.HeaderText = "期初余额"
        Me.DgtbcBnqc.MappingName = "bnqc"
        Me.DgtbcBnqc.NullText = ""
        Me.DgtbcBnqc.Width = 75
        '
        'DgtbcBnjf
        '
        Me.DgtbcBnjf.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcBnjf.Format = ""
        Me.DgtbcBnjf.FormatInfo = Nothing
        Me.DgtbcBnjf.HeaderText = "本年发出额"
        Me.DgtbcBnjf.MappingName = "bnjf"
        Me.DgtbcBnjf.NullText = ""
        Me.DgtbcBnjf.Width = 75
        '
        'DgtbcBndf
        '
        Me.DgtbcBndf.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcBndf.Format = ""
        Me.DgtbcBndf.FormatInfo = Nothing
        Me.DgtbcBndf.HeaderText = "本年收款额"
        Me.DgtbcBndf.MappingName = "bndf"
        Me.DgtbcBndf.NullText = ""
        Me.DgtbcBndf.Width = 75
        '
        'DgtbcBndj
        '
        Me.DgtbcBndj.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcBndj.Format = ""
        Me.DgtbcBndj.FormatInfo = Nothing
        Me.DgtbcBndj.HeaderText = "佣金贴息等抵减"
        Me.DgtbcBndj.MappingName = "bndj"
        Me.DgtbcBndj.NullText = ""
        Me.DgtbcBndj.Width = 75
        '
        'DgtbcBnHl
        '
        Me.DgtbcBnHl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcBnHl.Format = ""
        Me.DgtbcBnHl.FormatInfo = Nothing
        Me.DgtbcBnHl.HeaderText = "本年可结回笼额"
        Me.DgtbcBnHl.MappingName = "bnhl"
        Me.DgtbcBnHl.NullText = ""
        Me.DgtbcBnHl.Width = 75
        '
        'DgtbcYwf_bz
        '
        Me.DgtbcYwf_bz.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcYwf_bz.Format = ""
        Me.DgtbcYwf_bz.FormatInfo = Nothing
        Me.DgtbcYwf_bz.HeaderText = "标准业务费"
        Me.DgtbcYwf_bz.MappingName = "ywf_bz"
        Me.DgtbcYwf_bz.NullText = ""
        Me.DgtbcYwf_bz.Width = 75
        '
        'DgtbcSnhl
        '
        Me.DgtbcSnhl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSnhl.Format = ""
        Me.DgtbcSnhl.FormatInfo = Nothing
        Me.DgtbcSnhl.HeaderText = "上年可结回笼"
        Me.DgtbcSnhl.MappingName = "snhl"
        Me.DgtbcSnhl.NullText = ""
        Me.DgtbcSnhl.Width = 75
        '
        'DbgcBywfjszz
        '
        Me.DbgcBywfjszz.HeaderText = "计算增长标志"
        Me.DbgcBywfjszz.MappingName = "bywfjszz"
        Me.DbgcBywfjszz.NullText = ""
        Me.DbgcBywfjszz.Width = 75
        '
        'FrmYwfZyMxz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmYwfZyMxz"
        Me.Text = "业务费业务员计算明细表"
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RcDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DgtbcBnHl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSnhl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcKhdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcKhmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBndj As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcYwf_bz As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBndf As DataGridTextBoxColumn
    Friend WithEvents DgtbcBnjf As DataGridTextBoxColumn
    Friend WithEvents DgtbcBnqc As DataGridTextBoxColumn
    Friend WithEvents DgtbcXslbdm As DataGridTextBoxColumn
    Friend WithEvents DgtbcYwfbl As DataGridTextBoxColumn
    Friend WithEvents DgbcGjxslb As DataGridBoolColumn
    Friend WithEvents DbgcBywfjszz As DataGridBoolColumn
End Class
