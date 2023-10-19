<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCkCkCpHzbz
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
        Me.DgtbcBmdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcBmmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCkdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCkmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCpdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCpmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcDw = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJe = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcOldCpdm = New System.Windows.Forms.DataGridTextBoxColumn
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
        Me.Label1.Text = "仓库领用物料汇总表"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.rcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcBmdm, Me.DgtbcBmmc, Me.DgtbcCkdm, Me.DgtbcCkmc, Me.DgtbcCpdm, Me.DgtbcCpmc, Me.DgtbcDw, Me.DgtbcSl, Me.DgtbcJe, Me.DgtbcOldCpdm})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "ckckcphzb"
        '
        'DgtbcBmdm
        '
        Me.DgtbcBmdm.Format = ""
        Me.DgtbcBmdm.FormatInfo = Nothing
        Me.DgtbcBmdm.HeaderText = "部门编码"
        Me.DgtbcBmdm.MappingName = "bmdm"
        Me.DgtbcBmdm.NullText = ""
        Me.DgtbcBmdm.Width = 75
        '
        'DgtbcBmmc
        '
        Me.DgtbcBmmc.Format = ""
        Me.DgtbcBmmc.FormatInfo = Nothing
        Me.DgtbcBmmc.HeaderText = "部门名称"
        Me.DgtbcBmmc.MappingName = "bmmc"
        Me.DgtbcBmmc.NullText = ""
        Me.DgtbcBmmc.Width = 90
        '
        'DgtbcCkdm
        '
        Me.DgtbcCkdm.Format = ""
        Me.DgtbcCkdm.FormatInfo = Nothing
        Me.DgtbcCkdm.HeaderText = "仓库编码"
        Me.DgtbcCkdm.MappingName = "ckdm"
        Me.DgtbcCkdm.NullText = ""
        Me.DgtbcCkdm.Width = 75
        '
        'DgtbcCkmc
        '
        Me.DgtbcCkmc.Format = ""
        Me.DgtbcCkmc.FormatInfo = Nothing
        Me.DgtbcCkmc.HeaderText = "仓库名称"
        Me.DgtbcCkmc.MappingName = "ckmc"
        Me.DgtbcCkmc.NullText = ""
        Me.DgtbcCkmc.Width = 90
        '
        'DgtbcCpdm
        '
        Me.DgtbcCpdm.Format = ""
        Me.DgtbcCpdm.FormatInfo = Nothing
        Me.DgtbcCpdm.HeaderText = "物料编码"
        Me.DgtbcCpdm.MappingName = "cpdm"
        Me.DgtbcCpdm.NullText = ""
        Me.DgtbcCpdm.Width = 75
        '
        'DgtbcCpmc
        '
        Me.DgtbcCpmc.Format = ""
        Me.DgtbcCpmc.FormatInfo = Nothing
        Me.DgtbcCpmc.HeaderText = "物料描述"
        Me.DgtbcCpmc.MappingName = "cpmc"
        Me.DgtbcCpmc.NullText = ""
        Me.DgtbcCpmc.Width = 210
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
        Me.DgtbcSl.Width = 110
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
        'DgtbcOldCpdm
        '
        Me.DgtbcOldCpdm.Format = ""
        Me.DgtbcOldCpdm.FormatInfo = Nothing
        Me.DgtbcOldCpdm.HeaderText = "旧物料编码"
        Me.DgtbcOldCpdm.MappingName = "oldcpdm"
        Me.DgtbcOldCpdm.NullText = ""
        Me.DgtbcOldCpdm.Width = 75
        '
        'FrmCkCkCpHzbz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmCkCkCpHzbz"
        Me.Text = "仓库领用物料汇总表"
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DgtbcCkdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCkmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJe As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCpdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCpmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDw As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBmdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBmmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcOldCpdm As System.Windows.Forms.DataGridTextBoxColumn
End Class
