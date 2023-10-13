<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeYpddCxLb
    Inherits models.FrmRepView

    '窗体重写释放，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.rcDataGridTableStyle = New System.Windows.Forms.DataGridTableStyle
        Me.Panel1.SuspendLayout()
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblTitle
        '
        Me.LblTitle.Location = New System.Drawing.Point(419, 8)
        Me.LblTitle.Size = New System.Drawing.Size(142, 23)
        Me.LblTitle.Text = "样品订单查询"
        '
        'rcDataGridTableStyle
        '
        Me.rcDataGridTableStyle.DataGrid = Nothing
        Me.rcDataGridTableStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText
        '
        'FrmOeYpddCxLb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmOeYpddCxLb"
        Me.Text = "样品订单查询"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rcDataGridTableStyle As System.Windows.Forms.DataGridTableStyle

End Class
