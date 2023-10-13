<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmKhYszkHzz
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
        Me.DgtbcKhdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcKhmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcQcje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcYsje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSkje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcQmje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcZs = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcZydm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcZymc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSktj = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSkqx = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcWkpje = New System.Windows.Forms.DataGridTextBoxColumn
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
        Me.Label1.Text = "客户应收账款汇总表"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.rcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcKhdm, Me.DgtbcKhmc, Me.DgtbcZydm, Me.DgtbcZymc, Me.DgtbcSktj, Me.DgtbcSkqx, Me.DgtbcQcje, Me.DgtbcYsje, Me.DgtbcSkje, Me.DgtbcQmje, Me.DgtbcWkpje, Me.DgtbcZs})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "khyszkhz"
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
        Me.DgtbcKhmc.Width = 180
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
        Me.DgtbcYsje.HeaderText = "应收金额"
        Me.DgtbcYsje.MappingName = "ysje"
        Me.DgtbcYsje.NullText = ""
        Me.DgtbcYsje.Width = 75
        '
        'DgtbcSkje
        '
        Me.DgtbcSkje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSkje.Format = ""
        Me.DgtbcSkje.FormatInfo = Nothing
        Me.DgtbcSkje.HeaderText = "收款金额"
        Me.DgtbcSkje.MappingName = "skje"
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
        'DgtbcZs
        '
        Me.DgtbcZs.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DgtbcZs.Format = ""
        Me.DgtbcZs.FormatInfo = Nothing
        Me.DgtbcZs.HeaderText = "未结算票据张数"
        Me.DgtbcZs.MappingName = "zs"
        Me.DgtbcZs.NullText = ""
        Me.DgtbcZs.Width = 75
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
        Me.DgtbcZymc.MappingName = "zymc"
        Me.DgtbcZymc.NullText = "职员姓名"
        Me.DgtbcZymc.Width = 75
        '
        'DgtbcSktj
        '
        Me.DgtbcSktj.Format = ""
        Me.DgtbcSktj.FormatInfo = Nothing
        Me.DgtbcSktj.HeaderText = "收款条件"
        Me.DgtbcSktj.MappingName = "sktj"
        Me.DgtbcSktj.NullText = ""
        Me.DgtbcSktj.Width = 75
        '
        'DgtbcSkqx
        '
        Me.DgtbcSkqx.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSkqx.Format = ""
        Me.DgtbcSkqx.FormatInfo = Nothing
        Me.DgtbcSkqx.HeaderText = "收款期限"
        Me.DgtbcSkqx.MappingName = "skqx"
        Me.DgtbcSkqx.NullText = ""
        Me.DgtbcSkqx.Width = 75
        '
        'DgtbcWkpje
        '
        Me.DgtbcWkpje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcWkpje.Format = ""
        Me.DgtbcWkpje.FormatInfo = Nothing
        Me.DgtbcWkpje.HeaderText = "未开票金额"
        Me.DgtbcWkpje.MappingName = "wkpje"
        Me.DgtbcWkpje.NullText = ""
        Me.DgtbcWkpje.Width = 75
        '
        'FrmKhYszkHzz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmKhYszkHzz"
        Me.Text = "客户应收账款汇总表"
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DgtbcKhdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcKhmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcQcje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcYsje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSkje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcQmje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZs As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZydm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZymc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSktj As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSkqx As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcWkpje As System.Windows.Forms.DataGridTextBoxColumn
End Class
