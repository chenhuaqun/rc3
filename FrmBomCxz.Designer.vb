<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBomCxz
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
        Me.DgtbcCperiod = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcParentCpdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcParentCpmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcParentDw = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcChildCpdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcChildCpmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcChildDw = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcDj = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJe = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcBommemo = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcBzcb = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcBeishu = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcClcb = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcRgcb = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcZjcb = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcGlcb = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcNycb = New System.Windows.Forms.DataGridTextBoxColumn
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
        Me.Label1.Size = New System.Drawing.Size(142, 23)
        Me.Label1.Text = "物料清单列表"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.rcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcCperiod, Me.DgtbcParentCpdm, Me.DgtbcParentCpmc, Me.DgtbcParentDw, Me.DgtbcBzcb, Me.DgtbcBeishu, Me.DgtbcClcb, Me.DgtbcRgcb, Me.DgtbcNycb, Me.DgtbcZjcb, Me.DgtbcGlcb, Me.DgtbcChildCpdm, Me.DgtbcChildCpmc, Me.DgtbcChildDw, Me.DgtbcSl, Me.DgtbcDj, Me.DgtbcJe, Me.DgtbcBommemo})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "bomlb"
        '
        'DgtbcCperiod
        '
        Me.DgtbcCperiod.Format = ""
        Me.DgtbcCperiod.FormatInfo = Nothing
        Me.DgtbcCperiod.HeaderText = "会计期间"
        Me.DgtbcCperiod.MappingName = "cperiod"
        Me.DgtbcCperiod.NullText = ""
        Me.DgtbcCperiod.Width = 75
        '
        'DgtbcParentCpdm
        '
        Me.DgtbcParentCpdm.Format = ""
        Me.DgtbcParentCpdm.FormatInfo = Nothing
        Me.DgtbcParentCpdm.HeaderText = "父项物料编码"
        Me.DgtbcParentCpdm.MappingName = "parentcpdm"
        Me.DgtbcParentCpdm.NullText = ""
        Me.DgtbcParentCpdm.Width = 90
        '
        'DgtbcParentCpmc
        '
        Me.DgtbcParentCpmc.Format = ""
        Me.DgtbcParentCpmc.FormatInfo = Nothing
        Me.DgtbcParentCpmc.HeaderText = "父项物料描述"
        Me.DgtbcParentCpmc.MappingName = "parentcpmc"
        Me.DgtbcParentCpmc.NullText = ""
        Me.DgtbcParentCpmc.Width = 135
        '
        'DgtbcParentDw
        '
        Me.DgtbcParentDw.Format = ""
        Me.DgtbcParentDw.FormatInfo = Nothing
        Me.DgtbcParentDw.HeaderText = "父项单位"
        Me.DgtbcParentDw.MappingName = "parentdw"
        Me.DgtbcParentDw.NullText = ""
        Me.DgtbcParentDw.Width = 45
        '
        'DgtbcChildCpdm
        '
        Me.DgtbcChildCpdm.Format = ""
        Me.DgtbcChildCpdm.FormatInfo = Nothing
        Me.DgtbcChildCpdm.HeaderText = "子项物料编码"
        Me.DgtbcChildCpdm.MappingName = "childcpdm"
        Me.DgtbcChildCpdm.NullText = ""
        Me.DgtbcChildCpdm.Width = 90
        '
        'DgtbcChildCpmc
        '
        Me.DgtbcChildCpmc.Format = ""
        Me.DgtbcChildCpmc.FormatInfo = Nothing
        Me.DgtbcChildCpmc.HeaderText = "子项物料描述"
        Me.DgtbcChildCpmc.MappingName = "childcpmc"
        Me.DgtbcChildCpmc.NullText = ""
        Me.DgtbcChildCpmc.Width = 180
        '
        'DgtbcChildDw
        '
        Me.DgtbcChildDw.Format = ""
        Me.DgtbcChildDw.FormatInfo = Nothing
        Me.DgtbcChildDw.HeaderText = "子项单位"
        Me.DgtbcChildDw.MappingName = "childdw"
        Me.DgtbcChildDw.NullText = ""
        Me.DgtbcChildDw.Width = 45
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
        'DgtbcDj
        '
        Me.DgtbcDj.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcDj.Format = ""
        Me.DgtbcDj.FormatInfo = Nothing
        Me.DgtbcDj.HeaderText = "单价"
        Me.DgtbcDj.MappingName = "dj"
        Me.DgtbcDj.NullText = ""
        Me.DgtbcDj.Width = 75
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
        'DgtbcBommemo
        '
        Me.DgtbcBommemo.Format = ""
        Me.DgtbcBommemo.FormatInfo = Nothing
        Me.DgtbcBommemo.HeaderText = "备注"
        Me.DgtbcBommemo.MappingName = "bommemo"
        Me.DgtbcBommemo.NullText = ""
        Me.DgtbcBommemo.Width = 135
        '
        'DgtbcBzcb
        '
        Me.DgtbcBzcb.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcBzcb.Format = ""
        Me.DgtbcBzcb.FormatInfo = Nothing
        Me.DgtbcBzcb.HeaderText = "标准成本"
        Me.DgtbcBzcb.MappingName = "bzcb"
        Me.DgtbcBzcb.NullText = ""
        Me.DgtbcBzcb.Width = 75
        '
        'DgtbcBeishu
        '
        Me.DgtbcBeishu.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcBeishu.Format = ""
        Me.DgtbcBeishu.FormatInfo = Nothing
        Me.DgtbcBeishu.HeaderText = "倍数"
        Me.DgtbcBeishu.MappingName = "beishu"
        Me.DgtbcBeishu.NullText = ""
        Me.DgtbcBeishu.Width = 75
        '
        'DgtbcClcb
        '
        Me.DgtbcClcb.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcClcb.Format = ""
        Me.DgtbcClcb.FormatInfo = Nothing
        Me.DgtbcClcb.HeaderText = "材料"
        Me.DgtbcClcb.MappingName = "clcb"
        Me.DgtbcClcb.NullText = ""
        Me.DgtbcClcb.Width = 75
        '
        'DgtbcRgcb
        '
        Me.DgtbcRgcb.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcRgcb.Format = ""
        Me.DgtbcRgcb.FormatInfo = Nothing
        Me.DgtbcRgcb.HeaderText = "人工"
        Me.DgtbcRgcb.MappingName = "rgcb"
        Me.DgtbcRgcb.NullText = ""
        Me.DgtbcRgcb.Width = 75
        '
        'DgtbcZjcb
        '
        Me.DgtbcZjcb.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcZjcb.Format = ""
        Me.DgtbcZjcb.FormatInfo = Nothing
        Me.DgtbcZjcb.HeaderText = "折旧"
        Me.DgtbcZjcb.MappingName = "zjcb"
        Me.DgtbcZjcb.NullText = ""
        Me.DgtbcZjcb.Width = 75
        '
        'DgtbcGlcb
        '
        Me.DgtbcGlcb.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcGlcb.Format = ""
        Me.DgtbcGlcb.FormatInfo = Nothing
        Me.DgtbcGlcb.HeaderText = "管理"
        Me.DgtbcGlcb.MappingName = "glcb"
        Me.DgtbcGlcb.NullText = ""
        Me.DgtbcGlcb.Width = 75
        '
        'DgtbcNycb
        '
        Me.DgtbcNycb.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcNycb.Format = ""
        Me.DgtbcNycb.FormatInfo = Nothing
        Me.DgtbcNycb.HeaderText = "能源"
        Me.DgtbcNycb.MappingName = "nycb"
        Me.DgtbcNycb.NullText = ""
        Me.DgtbcNycb.Width = 75
        '
        'FrmBomCxz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmBomCxz"
        Me.Text = "物料清单列表"
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DgtbcParentCpdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcParentCpmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcParentDw As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcChildCpdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcChildCpmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDj As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBommemo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcChildDw As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJe As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCperiod As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBzcb As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBeishu As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcClcb As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcRgcb As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZjcb As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcGlcb As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcNycb As System.Windows.Forms.DataGridTextBoxColumn
End Class
