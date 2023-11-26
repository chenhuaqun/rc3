<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeZyHzbz
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
        Me.DgtbcZydm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcZymc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJe = New System.Windows.Forms.DataGridTextBoxColumn
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
        Me.Label1.Text = "职员销售汇总表"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.rcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcZydm, Me.DgtbcZymc, Me.DgtbcSl, Me.DgtbcJe})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "oezyhzb"
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
        'FrmOeZyHzbz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmOeZyHzbz"
        Me.Text = "职员销售汇总表"
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
    Friend WithEvents DgtbcJe As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZydm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZymc As System.Windows.Forms.DataGridTextBoxColumn
End Class
