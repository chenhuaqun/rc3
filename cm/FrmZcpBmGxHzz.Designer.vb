<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmZcpBmGxHzz
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
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DgtbcBmdm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcBmmc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcGxdm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcGxmc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcZcpsl = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcZcpje = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcZcpzl = New System.Windows.Forms.DataGridTextBoxColumn()
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'rcDataGrid
        '
        Me.rcDataGrid.Location = New System.Drawing.Point(0, 181)
        Me.rcDataGrid.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rcDataGrid.Size = New System.Drawing.Size(1476, 661)
        Me.rcDataGrid.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(0, 75)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Size = New System.Drawing.Size(1476, 106)
        '
        'Panel4
        '
        Me.Panel4.Location = New System.Drawing.Point(436, 60)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel4.Size = New System.Drawing.Size(599, 2)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(36, 72)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(580, 12)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Size = New System.Drawing.Size(335, 33)
        Me.Label1.Text = "在产品部门工序汇总表"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.rcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcBmdm, Me.DgtbcBmmc, Me.DgtbcGxdm, Me.DgtbcGxmc, Me.DgtbcZcpsl, Me.DgtbcZcpzl, Me.DgtbcZcpje})
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
        'DgtbcZcpzl
        '
        Me.DgtbcZcpzl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcZcpzl.Format = ""
        Me.DgtbcZcpzl.FormatInfo = Nothing
        Me.DgtbcZcpzl.HeaderText = "在产品重量"
        Me.DgtbcZcpzl.MappingName = "zcpzl"
        Me.DgtbcZcpzl.NullText = ""
        Me.DgtbcZcpzl.Width = 75
        '
        'FrmZcpBmGxHzz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1476, 842)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FrmZcpBmGxHzz"
        Me.Text = "在产品部门工序汇总表"
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DgtbcGxdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcGxmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZcpsl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZcpje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBmdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBmmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZcpzl As DataGridTextBoxColumn
End Class
