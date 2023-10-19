<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCsYfzkHzz
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
        Me.DgtbcFktj = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcFkts = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcQcje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcYsje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSkje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcQmje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcWkpje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcZydm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcZymc = New System.Windows.Forms.DataGridTextBoxColumn
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
        Me.Label1.Location = New System.Drawing.Point(375, 8)
        Me.Label1.Size = New System.Drawing.Size(230, 23)
        Me.Label1.Text = "供应商应付账款汇总表"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.rcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcCsdm, Me.DgtbcCsmc, Me.DgtbcZydm, Me.DgtbcZymc, Me.DgtbcFktj, Me.DgtbcFkts, Me.DgtbcQcje, Me.DgtbcYsje, Me.DgtbcSkje, Me.DgtbcQmje, Me.DgtbcWkpje})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "csyfzkhz"
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
        Me.DgtbcCsmc.Width = 270
        '
        'DgtbcFktj
        '
        Me.DgtbcFktj.Format = ""
        Me.DgtbcFktj.FormatInfo = Nothing
        Me.DgtbcFktj.HeaderText = "付款条件"
        Me.DgtbcFktj.MappingName = "fktj"
        Me.DgtbcFktj.NullText = ""
        Me.DgtbcFktj.Width = 75
        '
        'DgtbcFkts
        '
        Me.DgtbcFkts.Format = ""
        Me.DgtbcFkts.FormatInfo = Nothing
        Me.DgtbcFkts.HeaderText = "付款天数"
        Me.DgtbcFkts.MappingName = "fkts"
        Me.DgtbcFkts.NullText = ""
        Me.DgtbcFkts.Width = 75
        '
        'DgtbcQcje
        '
        Me.DgtbcQcje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcQcje.Format = ""
        Me.DgtbcQcje.FormatInfo = Nothing
        Me.DgtbcQcje.HeaderText = "期初余额"
        Me.DgtbcQcje.MappingName = "qcje"
        Me.DgtbcQcje.NullText = ""
        Me.DgtbcQcje.Width = 90
        '
        'DgtbcYsje
        '
        Me.DgtbcYsje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcYsje.Format = ""
        Me.DgtbcYsje.FormatInfo = Nothing
        Me.DgtbcYsje.HeaderText = "应付金额"
        Me.DgtbcYsje.MappingName = "yfje"
        Me.DgtbcYsje.NullText = ""
        Me.DgtbcYsje.Width = 90
        '
        'DgtbcSkje
        '
        Me.DgtbcSkje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSkje.Format = ""
        Me.DgtbcSkje.FormatInfo = Nothing
        Me.DgtbcSkje.HeaderText = "付款金额"
        Me.DgtbcSkje.MappingName = "fkje"
        Me.DgtbcSkje.NullText = ""
        Me.DgtbcSkje.Width = 90
        '
        'DgtbcQmje
        '
        Me.DgtbcQmje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcQmje.Format = ""
        Me.DgtbcQmje.FormatInfo = Nothing
        Me.DgtbcQmje.HeaderText = "期末余额"
        Me.DgtbcQmje.MappingName = "qmje"
        Me.DgtbcQmje.NullText = ""
        Me.DgtbcQmje.Width = 90
        '
        'DgtbcWkpje
        '
        Me.DgtbcWkpje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcWkpje.Format = ""
        Me.DgtbcWkpje.FormatInfo = Nothing
        Me.DgtbcWkpje.HeaderText = "未开票金额"
        Me.DgtbcWkpje.MappingName = "wkpje"
        Me.DgtbcWkpje.NullText = ""
        Me.DgtbcWkpje.Width = 90
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
        'FrmCsYfzkHzz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmCsYfzkHzz"
        Me.Text = "供应商应付账款汇总表"
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
    Friend WithEvents DgtbcWkpje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcFktj As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcFkts As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZydm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZymc As System.Windows.Forms.DataGridTextBoxColumn
End Class
