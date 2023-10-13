<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmYwfDkywCxz
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
        Me.DgtbcDkrq = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcKhdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcKhmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcDkgsdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcDkgsmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSkje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcFyje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcDkmemo = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcYwfbl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcDkje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSrr = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSrrq = New System.Windows.Forms.DataGridTextBoxColumn
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
        Me.Label1.Text = "业务费抵扣业务查询"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.rcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcDjh, Me.DgtbcDkrq, Me.DgtbcKhdm, Me.DgtbcKhmc, Me.DgtbcDkgsdm, Me.DgtbcDkgsmc, Me.DgtbcSkje, Me.DgtbcFyje, Me.DgtbcDkmemo, Me.DgtbcYwfbl, Me.DgtbcDkje, Me.DgtbcSrr, Me.DgtbcSrrq})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "gl_ywfdkyw"
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
        'DgtbcDkrq
        '
        Me.DgtbcDkrq.Format = ""
        Me.DgtbcDkrq.FormatInfo = Nothing
        Me.DgtbcDkrq.HeaderText = "抵扣日期"
        Me.DgtbcDkrq.MappingName = "dkrq"
        Me.DgtbcDkrq.NullText = ""
        Me.DgtbcDkrq.Width = 75
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
        Me.DgtbcKhmc.Width = 250
        '
        'DgtbcDkgsdm
        '
        Me.DgtbcDkgsdm.Format = ""
        Me.DgtbcDkgsdm.FormatInfo = Nothing
        Me.DgtbcDkgsdm.HeaderText = "抵扣规则编码"
        Me.DgtbcDkgsdm.MappingName = "dkgsdm"
        Me.DgtbcDkgsdm.NullText = ""
        Me.DgtbcDkgsdm.Width = 75
        '
        'DgtbcDkgsmc
        '
        Me.DgtbcDkgsmc.Format = ""
        Me.DgtbcDkgsmc.FormatInfo = Nothing
        Me.DgtbcDkgsmc.HeaderText = "抵扣规则名称"
        Me.DgtbcDkgsmc.MappingName = "dkgsmc"
        Me.DgtbcDkgsmc.NullText = ""
        Me.DgtbcDkgsmc.Width = 75
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
        'DgtbcFyje
        '
        Me.DgtbcFyje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcFyje.Format = ""
        Me.DgtbcFyje.FormatInfo = Nothing
        Me.DgtbcFyje.HeaderText = "费用金额"
        Me.DgtbcFyje.MappingName = "fyje"
        Me.DgtbcFyje.NullText = ""
        Me.DgtbcFyje.Width = 75
        '
        'DgtbcDkmemo
        '
        Me.DgtbcDkmemo.Format = ""
        Me.DgtbcDkmemo.FormatInfo = Nothing
        Me.DgtbcDkmemo.HeaderText = "备注"
        Me.DgtbcDkmemo.MappingName = "dkmemo"
        Me.DgtbcDkmemo.NullText = ""
        Me.DgtbcDkmemo.Width = 135
        '
        'DgtbcYwfbl
        '
        Me.DgtbcYwfbl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcYwfbl.Format = ""
        Me.DgtbcYwfbl.FormatInfo = Nothing
        Me.DgtbcYwfbl.HeaderText = "结算系数"
        Me.DgtbcYwfbl.MappingName = "ywfbl"
        Me.DgtbcYwfbl.NullText = ""
        Me.DgtbcYwfbl.Width = 75
        '
        'DgtbcDkje
        '
        Me.DgtbcDkje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcDkje.Format = ""
        Me.DgtbcDkje.FormatInfo = Nothing
        Me.DgtbcDkje.HeaderText = "下降金额"
        Me.DgtbcDkje.MappingName = "dkje"
        Me.DgtbcDkje.NullText = ""
        Me.DgtbcDkje.Width = 75
        '
        'DgtbcSrr
        '
        Me.DgtbcSrr.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DgtbcSrr.Format = ""
        Me.DgtbcSrr.FormatInfo = Nothing
        Me.DgtbcSrr.HeaderText = "录入"
        Me.DgtbcSrr.MappingName = "srr"
        Me.DgtbcSrr.NullText = ""
        Me.DgtbcSrr.Width = 75
        '
        'DgtbcSrrq
        '
        Me.DgtbcSrrq.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSrrq.Format = ""
        Me.DgtbcSrrq.FormatInfo = Nothing
        Me.DgtbcSrrq.HeaderText = "录入日期"
        Me.DgtbcSrrq.MappingName = "srrq"
        Me.DgtbcSrrq.NullText = ""
        Me.DgtbcSrrq.Width = 75
        '
        'FrmYwfDkywCxz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmYwfDkywCxz"
        Me.Text = "业务费抵扣业务查询"
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
    Friend WithEvents DgtbcDkmemo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDkje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSrr As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSrrq As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSkje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcFyje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDkgsdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDkgsmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDkrq As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcYwfbl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDjh As System.Windows.Forms.DataGridTextBoxColumn
End Class
