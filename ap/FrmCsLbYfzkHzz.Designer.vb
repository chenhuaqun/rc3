<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCsLbYfzkHzz
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
        Me.DgtbcCsdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCsmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcQcje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcYsje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSkje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcQmje = New System.Windows.Forms.DataGridTextBoxColumn
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
        Me.Label1.Location = New System.Drawing.Point(353, 8)
        Me.Label1.Size = New System.Drawing.Size(274, 23)
        Me.Label1.Text = "供应商类别应付账款汇总表"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.rcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcCsdm, Me.DgtbcCsmc, Me.DgtbcQcje, Me.DgtbcYsje, Me.DgtbcSkje, Me.DgtbcQmje})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "csyfzkhz"
        '
        'DgtbcCsdm
        '
        Me.DgtbcCsdm.Format = ""
        Me.DgtbcCsdm.FormatInfo = Nothing
        Me.DgtbcCsdm.HeaderText = "供应商类别编码"
        Me.DgtbcCsdm.MappingName = "lbdm"
        Me.DgtbcCsdm.NullText = ""
        Me.DgtbcCsdm.Width = 75
        '
        'DgtbcCsmc
        '
        Me.DgtbcCsmc.Format = ""
        Me.DgtbcCsmc.FormatInfo = Nothing
        Me.DgtbcCsmc.HeaderText = "供应商类别名称"
        Me.DgtbcCsmc.MappingName = "lbmc"
        Me.DgtbcCsmc.NullText = ""
        Me.DgtbcCsmc.Width = 180
        '
        'DgtbcQcje
        '
        Me.DgtbcQcje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcQcje.Format = ""
        Me.DgtbcQcje.FormatInfo = Nothing
        Me.DgtbcQcje.HeaderText = "期初余额"
        Me.DgtbcQcje.MappingName = "qcje"
        Me.DgtbcQcje.NullText = ""
        Me.DgtbcQcje.Width = 75
        '
        'DgtbcYsje
        '
        Me.DgtbcYsje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcYsje.Format = ""
        Me.DgtbcYsje.FormatInfo = Nothing
        Me.DgtbcYsje.HeaderText = "应付金额"
        Me.DgtbcYsje.MappingName = "yfje"
        Me.DgtbcYsje.NullText = ""
        Me.DgtbcYsje.Width = 75
        '
        'DgtbcSkje
        '
        Me.DgtbcSkje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSkje.Format = ""
        Me.DgtbcSkje.FormatInfo = Nothing
        Me.DgtbcSkje.HeaderText = "付款金额"
        Me.DgtbcSkje.MappingName = "fkje"
        Me.DgtbcSkje.NullText = ""
        Me.DgtbcSkje.Width = 75
        '
        'DgtbcQmje
        '
        Me.DgtbcQmje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcQmje.Format = ""
        Me.DgtbcQmje.FormatInfo = Nothing
        Me.DgtbcQmje.HeaderText = "期末余额"
        Me.DgtbcQmje.MappingName = "qmje"
        Me.DgtbcQmje.NullText = ""
        Me.DgtbcQmje.Width = 75
        '
        'FrmCsLbYfzkHzz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmCsLbYfzkHzz"
        Me.Text = "供应商类别应付账款汇总表"
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DgtbcCsdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCsmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcQcje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcYsje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSkje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcQmje As System.Windows.Forms.DataGridTextBoxColumn
End Class
