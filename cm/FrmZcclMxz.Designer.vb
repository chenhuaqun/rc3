<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmZcclMxz
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
        Me.DgtbcCpdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCpmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcDw = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcGxdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcGxmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcZcclsl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCldj = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcZcclje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcBmdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcBmmc = New System.Windows.Forms.DataGridTextBoxColumn
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
        Me.Label1.Text = "在产材料成本明细表"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.rcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcBmdm, Me.DgtbcBmmc, Me.DgtbcCpdm, Me.DgtbcCpmc, Me.DgtbcDw, Me.DgtbcGxdm, Me.DgtbcGxmc, Me.DgtbcZcclsl, Me.DgtbcCldj, Me.DgtbcZcclje})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "pm_zccl"
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
        Me.DgtbcDw.Width = 75
        '
        'DgtbcGxdm
        '
        Me.DgtbcGxdm.Format = ""
        Me.DgtbcGxdm.FormatInfo = Nothing
        Me.DgtbcGxdm.HeaderText = "工序编码"
        Me.DgtbcGxdm.MappingName = "gxdm"
        Me.DgtbcGxdm.NullText = ""
        Me.DgtbcGxdm.Width = 75
        '
        'DgtbcGxmc
        '
        Me.DgtbcGxmc.Format = ""
        Me.DgtbcGxmc.FormatInfo = Nothing
        Me.DgtbcGxmc.HeaderText = "工序名称"
        Me.DgtbcGxmc.MappingName = "gxmc"
        Me.DgtbcGxmc.NullText = ""
        Me.DgtbcGxmc.Width = 75
        '
        'DgtbcZcclsl
        '
        Me.DgtbcZcclsl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcZcclsl.Format = ""
        Me.DgtbcZcclsl.FormatInfo = Nothing
        Me.DgtbcZcclsl.HeaderText = "在产材料数量"
        Me.DgtbcZcclsl.MappingName = "zcclsl"
        Me.DgtbcZcclsl.NullText = ""
        Me.DgtbcZcclsl.Width = 75
        '
        'DgtbcCldj
        '
        Me.DgtbcCldj.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcCldj.Format = ""
        Me.DgtbcCldj.FormatInfo = Nothing
        Me.DgtbcCldj.HeaderText = "材料单价"
        Me.DgtbcCldj.MappingName = "cldj"
        Me.DgtbcCldj.NullText = ""
        Me.DgtbcCldj.Width = 75
        '
        'DgtbcZcclje
        '
        Me.DgtbcZcclje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcZcclje.Format = ""
        Me.DgtbcZcclje.FormatInfo = Nothing
        Me.DgtbcZcclje.HeaderText = "材料金额"
        Me.DgtbcZcclje.MappingName = "zcclje"
        Me.DgtbcZcclje.NullText = ""
        Me.DgtbcZcclje.Width = 75
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
        'FrmZcclMxz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmZcclMxz"
        Me.Text = "在产材料成本明细表"
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DgtbcCpdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCpmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDw As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcGxdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcGxmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZcclsl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCldj As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZcclje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBmdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBmmc As System.Windows.Forms.DataGridTextBoxColumn
End Class
