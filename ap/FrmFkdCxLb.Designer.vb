<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFkdCxLb
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
        Me.DgtbcFkrq = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCsdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCsmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcKmdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcKmmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcYspz = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJe = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcRkje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcFkmemo = New System.Windows.Forms.DataGridTextBoxColumn
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
        Me.Label1.Location = New System.Drawing.Point(430, 8)
        Me.Label1.Size = New System.Drawing.Size(120, 23)
        Me.Label1.Text = "付款单列表"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.rcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcDjh, Me.DgtbcFkrq, Me.DgtbcCsdm, Me.DgtbcCsmc, Me.DgtbcKmdm, Me.DgtbcKmmc, Me.DgtbcYspz, Me.DgtbcJe, Me.DgtbcRkje, Me.DgtbcFkmemo, Me.DgtbcSrr, Me.DgtbcShr, Me.DgtbcJzr})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "fkdlb"
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
        'DgtbcFkrq
        '
        Me.DgtbcFkrq.Format = ""
        Me.DgtbcFkrq.FormatInfo = Nothing
        Me.DgtbcFkrq.HeaderText = "付款日期"
        Me.DgtbcFkrq.MappingName = "fkrq"
        Me.DgtbcFkrq.NullText = ""
        Me.DgtbcFkrq.Width = 75
        '
        'DgtbcCsdm
        '
        Me.DgtbcCsdm.Format = ""
        Me.DgtbcCsdm.FormatInfo = Nothing
        Me.DgtbcCsdm.HeaderText = "供应商编码"
        Me.DgtbcCsdm.MappingName = "csdm"
        Me.DgtbcCsdm.NullText = ""
        Me.DgtbcCsdm.Width = 75
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
        'DgtbcKmdm
        '
        Me.DgtbcKmdm.Format = ""
        Me.DgtbcKmdm.FormatInfo = Nothing
        Me.DgtbcKmdm.HeaderText = "科目编码"
        Me.DgtbcKmdm.MappingName = "kmdm"
        Me.DgtbcKmdm.NullText = ""
        Me.DgtbcKmdm.Width = 75
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
        'DgtbcYspz
        '
        Me.DgtbcYspz.Format = ""
        Me.DgtbcYspz.FormatInfo = Nothing
        Me.DgtbcYspz.HeaderText = "原始凭证"
        Me.DgtbcYspz.MappingName = "yspz"
        Me.DgtbcYspz.NullText = ""
        Me.DgtbcYspz.Width = 75
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
        'DgtbcRkje
        '
        Me.DgtbcRkje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcRkje.Format = ""
        Me.DgtbcRkje.FormatInfo = Nothing
        Me.DgtbcRkje.HeaderText = "核销金额"
        Me.DgtbcRkje.MappingName = "rkje"
        Me.DgtbcRkje.NullText = ""
        Me.DgtbcRkje.Width = 75
        '
        'DgtbcFkmemo
        '
        Me.DgtbcFkmemo.Format = ""
        Me.DgtbcFkmemo.FormatInfo = Nothing
        Me.DgtbcFkmemo.HeaderText = "备注"
        Me.DgtbcFkmemo.MappingName = "fkmemo"
        Me.DgtbcFkmemo.NullText = ""
        Me.DgtbcFkmemo.Width = 120
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
        'DgtbcJzr
        '
        Me.DgtbcJzr.Format = ""
        Me.DgtbcJzr.FormatInfo = Nothing
        Me.DgtbcJzr.HeaderText = "记账人"
        Me.DgtbcJzr.MappingName = "jzr"
        Me.DgtbcJzr.NullText = ""
        Me.DgtbcJzr.Width = 75
        '
        'FrmFkdCxLb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmFkdCxLb"
        Me.Text = "付款单列表"
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
    Friend WithEvents DgtbcFkrq As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCsdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCsmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcRkje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJe As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcFkmemo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSrr As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcKmdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcKmmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcYspz As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcShr As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJzr As System.Windows.Forms.DataGridTextBoxColumn
End Class
