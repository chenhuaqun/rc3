<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeKhHzbz
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
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DgtbcLbdm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcLbmc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcKhdm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcKhmc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcZydm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcZymc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcSl = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcJe = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcSe = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcCbje = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcMle = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcMll = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcFzsl = New System.Windows.Forms.DataGridTextBoxColumn()
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
        Me.Label1.Location = New System.Drawing.Point(407, 8)
        Me.Label1.Size = New System.Drawing.Size(166, 26)
        Me.Label1.Text = "客户送货汇总表"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.RcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcLbdm, Me.DgtbcLbmc, Me.DgtbcKhdm, Me.DgtbcKhmc, Me.DgtbcZydm, Me.DgtbcZymc, Me.DgtbcSl, Me.DgtbcFzsl, Me.DgtbcJe, Me.DgtbcSe, Me.DgtbcCbje, Me.DgtbcMle, Me.DgtbcMll})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "oekhhzb"
        '
        'DgtbcLbdm
        '
        Me.DgtbcLbdm.Format = ""
        Me.DgtbcLbdm.FormatInfo = Nothing
        Me.DgtbcLbdm.HeaderText = "客户类别编码"
        Me.DgtbcLbdm.MappingName = "lbdm"
        Me.DgtbcLbdm.NullText = ""
        Me.DgtbcLbdm.Width = 75
        '
        'DgtbcLbmc
        '
        Me.DgtbcLbmc.Format = ""
        Me.DgtbcLbmc.FormatInfo = Nothing
        Me.DgtbcLbmc.HeaderText = "客户类别名称"
        Me.DgtbcLbmc.MappingName = "lbmc"
        Me.DgtbcLbmc.NullText = ""
        Me.DgtbcLbmc.Width = 75
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
        'DgtbcCbje
        '
        Me.DgtbcCbje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcCbje.Format = ""
        Me.DgtbcCbje.FormatInfo = Nothing
        Me.DgtbcCbje.HeaderText = "成本金额"
        Me.DgtbcCbje.MappingName = "cbje"
        Me.DgtbcCbje.NullText = ""
        Me.DgtbcCbje.Width = 75
        '
        'DgtbcMle
        '
        Me.DgtbcMle.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcMle.Format = ""
        Me.DgtbcMle.FormatInfo = Nothing
        Me.DgtbcMle.HeaderText = "毛利额"
        Me.DgtbcMle.MappingName = "mle"
        Me.DgtbcMle.NullText = ""
        Me.DgtbcMle.Width = 75
        '
        'DgtbcMll
        '
        Me.DgtbcMll.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcMll.Format = ""
        Me.DgtbcMll.FormatInfo = Nothing
        Me.DgtbcMll.HeaderText = "毛利率"
        Me.DgtbcMll.MappingName = "mll"
        Me.DgtbcMll.NullText = ""
        Me.DgtbcMll.Width = 75
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
        'FrmOeKhHzbz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmOeKhHzbz"
        Me.Text = "客户送货汇总表"
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RcDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DgtbcKhdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcKhmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJe As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZydm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZymc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSe As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCbje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcMle As DataGridTextBoxColumn
    Friend WithEvents DgtbcMll As DataGridTextBoxColumn
    Friend WithEvents DgtbcLbdm As DataGridTextBoxColumn
    Friend WithEvents DgtbcLbmc As DataGridTextBoxColumn
    Friend WithEvents DgtbcFzsl As DataGridTextBoxColumn
End Class
