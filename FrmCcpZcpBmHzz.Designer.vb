<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCcpZcpBmHzz
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
        Me.DgtbcQcZcpSl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcQcZcpJe = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcZcbje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCcpSl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCcpJe = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcQmZcpSl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcQmZcpJe = New System.Windows.Forms.DataGridTextBoxColumn
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
        Me.Label1.Location = New System.Drawing.Point(331, 8)
        Me.Label1.Size = New System.Drawing.Size(318, 23)
        Me.Label1.Text = "产成品在产品各部门成本汇总表"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.rcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcBmdm, Me.DgtbcBmmc, Me.DgtbcQcZcpSl, Me.DgtbcQcZcpJe, Me.DgtbcZcbje, Me.DgtbcCcpSl, Me.DgtbcCcpJe, Me.DgtbcQmZcpSl, Me.DgtbcQmZcpJe})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "ccpzcphz"
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
        Me.DgtbcBmmc.Width = 135
        '
        'DgtbcQcZcpSl
        '
        Me.DgtbcQcZcpSl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcQcZcpSl.Format = ""
        Me.DgtbcQcZcpSl.FormatInfo = Nothing
        Me.DgtbcQcZcpSl.HeaderText = "期初在产品重量"
        Me.DgtbcQcZcpSl.MappingName = "qczcpsl"
        Me.DgtbcQcZcpSl.NullText = ""
        Me.DgtbcQcZcpSl.Width = 90
        '
        'DgtbcQcZcpJe
        '
        Me.DgtbcQcZcpJe.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcQcZcpJe.Format = ""
        Me.DgtbcQcZcpJe.FormatInfo = Nothing
        Me.DgtbcQcZcpJe.HeaderText = "期初在产品金额"
        Me.DgtbcQcZcpJe.MappingName = "qczcpje"
        Me.DgtbcQcZcpJe.NullText = ""
        Me.DgtbcQcZcpJe.Width = 90
        '
        'DgtbcZcbje
        '
        Me.DgtbcZcbje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcZcbje.Format = ""
        Me.DgtbcZcbje.FormatInfo = Nothing
        Me.DgtbcZcbje.HeaderText = "本期成本耗用"
        Me.DgtbcZcbje.MappingName = "zcbje"
        Me.DgtbcZcbje.NullText = ""
        Me.DgtbcZcbje.Width = 90
        '
        'DgtbcCcpSl
        '
        Me.DgtbcCcpSl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcCcpSl.Format = ""
        Me.DgtbcCcpSl.FormatInfo = Nothing
        Me.DgtbcCcpSl.HeaderText = "本期产成品重量"
        Me.DgtbcCcpSl.MappingName = "ccpsl"
        Me.DgtbcCcpSl.NullText = ""
        Me.DgtbcCcpSl.Width = 90
        '
        'DgtbcCcpJe
        '
        Me.DgtbcCcpJe.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcCcpJe.Format = ""
        Me.DgtbcCcpJe.FormatInfo = Nothing
        Me.DgtbcCcpJe.HeaderText = "本期产成品金额"
        Me.DgtbcCcpJe.MappingName = "ccpje"
        Me.DgtbcCcpJe.NullText = ""
        Me.DgtbcCcpJe.Width = 90
        '
        'DgtbcQmZcpSl
        '
        Me.DgtbcQmZcpSl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcQmZcpSl.Format = ""
        Me.DgtbcQmZcpSl.FormatInfo = Nothing
        Me.DgtbcQmZcpSl.HeaderText = "期末在产品重量"
        Me.DgtbcQmZcpSl.MappingName = "qmzcpsl"
        Me.DgtbcQmZcpSl.NullText = ""
        Me.DgtbcQmZcpSl.Width = 90
        '
        'DgtbcQmZcpJe
        '
        Me.DgtbcQmZcpJe.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcQmZcpJe.Format = ""
        Me.DgtbcQmZcpJe.FormatInfo = Nothing
        Me.DgtbcQmZcpJe.HeaderText = "期末在产品金额"
        Me.DgtbcQmZcpJe.MappingName = "qmzcpje"
        Me.DgtbcQmZcpJe.NullText = ""
        Me.DgtbcQmZcpJe.Width = 90
        '
        'FrmCcpZcpBmHzz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmCcpZcpBmHzz"
        Me.Text = "产成品在产品各部门成本汇总表"
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DgtbcQcZcpSl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcQcZcpJe As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZcbje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCcpSl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCcpJe As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBmdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBmmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcQmZcpSl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcQmZcpJe As System.Windows.Forms.DataGridTextBoxColumn
End Class
