<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeCplbHzbz
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
        Me.DgtbcLbdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcLbmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJe = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSe = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCbje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcZl = New System.Windows.Forms.DataGridTextBoxColumn
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
        Me.Label1.Location = New System.Drawing.Point(386, 8)
        Me.Label1.Size = New System.Drawing.Size(208, 23)
        Me.Label1.Text = "物料类别送货汇总表"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.rcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcLbdm, Me.DgtbcLbmc, Me.DgtbcSl, Me.DgtbcZl, Me.DgtbcJe, Me.DgtbcSe, Me.DgtbcCbje})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "oecphzb"
        '
        'DgtbcLbdm
        '
        Me.DgtbcLbdm.Format = ""
        Me.DgtbcLbdm.FormatInfo = Nothing
        Me.DgtbcLbdm.HeaderText = "物料类别编码"
        Me.DgtbcLbdm.MappingName = "lbdm"
        Me.DgtbcLbdm.NullText = ""
        Me.DgtbcLbdm.Width = 75
        '
        'DgtbcLbmc
        '
        Me.DgtbcLbmc.Format = ""
        Me.DgtbcLbmc.FormatInfo = Nothing
        Me.DgtbcLbmc.HeaderText = "物料类别名称"
        Me.DgtbcLbmc.MappingName = "lbmc"
        Me.DgtbcLbmc.NullText = ""
        Me.DgtbcLbmc.Width = 135
        '
        'DgtbcSl
        '
        Me.DgtbcSl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSl.Format = ""
        Me.DgtbcSl.FormatInfo = Nothing
        Me.DgtbcSl.HeaderText = "数量"
        Me.DgtbcSl.MappingName = "sl"
        Me.DgtbcSl.NullText = ""
        Me.DgtbcSl.Width = 120
        '
        'DgtbcJe
        '
        Me.DgtbcJe.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcJe.Format = ""
        Me.DgtbcJe.FormatInfo = Nothing
        Me.DgtbcJe.HeaderText = "销售金额"
        Me.DgtbcJe.MappingName = "je"
        Me.DgtbcJe.NullText = ""
        Me.DgtbcJe.Width = 120
        '
        'DgtbcSe
        '
        Me.DgtbcSe.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSe.Format = ""
        Me.DgtbcSe.FormatInfo = Nothing
        Me.DgtbcSe.HeaderText = "税额"
        Me.DgtbcSe.MappingName = "se"
        Me.DgtbcSe.NullText = ""
        Me.DgtbcSe.Width = 120
        '
        'DgtbcCbje
        '
        Me.DgtbcCbje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcCbje.Format = ""
        Me.DgtbcCbje.FormatInfo = Nothing
        Me.DgtbcCbje.HeaderText = "成本金额"
        Me.DgtbcCbje.MappingName = "cbje"
        Me.DgtbcCbje.NullText = ""
        Me.DgtbcCbje.Width = 120
        '
        'DgtbcZl
        '
        Me.DgtbcZl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcZl.Format = ""
        Me.DgtbcZl.FormatInfo = Nothing
        Me.DgtbcZl.HeaderText = "重量"
        Me.DgtbcZl.MappingName = "zl"
        Me.DgtbcZl.NullText = ""
        Me.DgtbcZl.Width = 120
        '
        'FrmOeCplbHzbz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmOeCplbHzbz"
        Me.Text = "物料类别送货汇总表"
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DgtbcLbdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcLbmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJe As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCbje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSe As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZl As System.Windows.Forms.DataGridTextBoxColumn
End Class
