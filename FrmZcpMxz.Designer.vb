<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmZcpMxz
    Inherits models.FrmReportView

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DgtbcBmdm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcBmmc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcCpdm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcCpmc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcDw = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcGxdm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcGxmc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcZcpsl = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcClcb = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcZcpje = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcRgcb = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcNycb = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcZjcb = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcGlcb = New System.Windows.Forms.DataGridTextBoxColumn()
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RcDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RcDataGrid
        '
        Me.RcDataGrid.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(396, 8)
        Me.Label1.Size = New System.Drawing.Size(188, 26)
        Me.Label1.Text = "在产品成本明细表"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.RcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcBmdm, Me.DgtbcBmmc, Me.DgtbcCpdm, Me.DgtbcCpmc, Me.DgtbcDw, Me.DgtbcGxdm, Me.DgtbcGxmc, Me.DgtbcZcpsl, Me.DgtbcZcpje, Me.DgtbcClcb, Me.DgtbcRgcb, Me.DgtbcNycb, Me.DgtbcZjcb, Me.DgtbcGlcb})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "pm_zcp"
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
        'DgtbcZcpsl
        '
        Me.DgtbcZcpsl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcZcpsl.Format = ""
        Me.DgtbcZcpsl.FormatInfo = Nothing
        Me.DgtbcZcpsl.HeaderText = "在产品数量"
        Me.DgtbcZcpsl.MappingName = "zcpsl"
        Me.DgtbcZcpsl.NullText = ""
        Me.DgtbcZcpsl.Width = 75
        '
        'DgtbcClcb
        '
        Me.DgtbcClcb.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcClcb.Format = ""
        Me.DgtbcClcb.FormatInfo = Nothing
        Me.DgtbcClcb.HeaderText = "其中：材料成本"
        Me.DgtbcClcb.MappingName = "clcb"
        Me.DgtbcClcb.NullText = ""
        Me.DgtbcClcb.Width = 75
        '
        'DgtbcZcpje
        '
        Me.DgtbcZcpje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcZcpje.Format = ""
        Me.DgtbcZcpje.FormatInfo = Nothing
        Me.DgtbcZcpje.HeaderText = "在产品金额"
        Me.DgtbcZcpje.MappingName = "zcpje"
        Me.DgtbcZcpje.NullText = ""
        Me.DgtbcZcpje.Width = 75
        '
        'DgtbcRgcb
        '
        Me.DgtbcRgcb.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcRgcb.Format = ""
        Me.DgtbcRgcb.FormatInfo = Nothing
        Me.DgtbcRgcb.HeaderText = "人工成本"
        Me.DgtbcRgcb.MappingName = "rgcb"
        Me.DgtbcRgcb.NullText = ""
        Me.DgtbcRgcb.Width = 75
        '
        'DgtbcNycb
        '
        Me.DgtbcNycb.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcNycb.Format = ""
        Me.DgtbcNycb.FormatInfo = Nothing
        Me.DgtbcNycb.HeaderText = "能源成本"
        Me.DgtbcNycb.MappingName = "nycb"
        Me.DgtbcNycb.NullText = ""
        Me.DgtbcNycb.Width = 75
        '
        'DgtbcZjcb
        '
        Me.DgtbcZjcb.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcZjcb.Format = ""
        Me.DgtbcZjcb.FormatInfo = Nothing
        Me.DgtbcZjcb.HeaderText = "折旧成本"
        Me.DgtbcZjcb.MappingName = "zjcb"
        Me.DgtbcZjcb.NullText = ""
        Me.DgtbcZjcb.Width = 75
        '
        'DgtbcGlcb
        '
        Me.DgtbcGlcb.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcGlcb.Format = ""
        Me.DgtbcGlcb.FormatInfo = Nothing
        Me.DgtbcGlcb.HeaderText = "管理成本"
        Me.DgtbcGlcb.MappingName = "glcb"
        Me.DgtbcGlcb.NullText = ""
        Me.DgtbcGlcb.Width = 75
        '
        'FrmZcpMxz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmZcpMxz"
        Me.Text = "在产品成本明细表"
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RcDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents DgtbcZcpsl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcClcb As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZcpje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBmdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBmmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcRgcb As DataGridTextBoxColumn
    Friend WithEvents DgtbcNycb As DataGridTextBoxColumn
    Friend WithEvents DgtbcZjcb As DataGridTextBoxColumn
    Friend WithEvents DgtbcGlcb As DataGridTextBoxColumn
End Class
