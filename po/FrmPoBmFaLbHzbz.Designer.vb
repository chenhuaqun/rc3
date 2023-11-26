<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPoBmFaLbHzbz
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
        Me.DgtbcBmdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcBmmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJe = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcFadm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcFamc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcLbdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcLbmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcDanHao = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcChanLiang = New System.Windows.Forms.DataGridTextBoxColumn
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
        Me.Label1.Location = New System.Drawing.Point(342, 8)
        Me.Label1.Size = New System.Drawing.Size(296, 23)
        Me.Label1.Text = "部门设备物料类别消耗汇总表"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.rcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcBmdm, Me.DgtbcBmmc, Me.DgtbcFadm, Me.DgtbcFamc, Me.DgtbcLbdm, Me.DgtbcLbmc, Me.DgtbcSl, Me.DgtbcJe, Me.DgtbcChanLiang, Me.DgtbcDanHao})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "pobmfalbhzb"
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
        Me.DgtbcBmmc.Width = 75
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
        'DgtbcFadm
        '
        Me.DgtbcFadm.Format = ""
        Me.DgtbcFadm.FormatInfo = Nothing
        Me.DgtbcFadm.HeaderText = "设备编码"
        Me.DgtbcFadm.MappingName = "fadm"
        Me.DgtbcFadm.NullText = ""
        Me.DgtbcFadm.Width = 75
        '
        'DgtbcFamc
        '
        Me.DgtbcFamc.Format = ""
        Me.DgtbcFamc.FormatInfo = Nothing
        Me.DgtbcFamc.HeaderText = "设备名称"
        Me.DgtbcFamc.MappingName = "famc"
        Me.DgtbcFamc.NullText = ""
        Me.DgtbcFamc.Width = 90
        '
        'DgtbcLbdm
        '
        Me.DgtbcLbdm.Format = ""
        Me.DgtbcLbdm.FormatInfo = Nothing
        Me.DgtbcLbdm.HeaderText = "物料类别编码"
        Me.DgtbcLbdm.MappingName = "lbdm"
        Me.DgtbcLbdm.NullText = ""
        Me.DgtbcLbdm.Width = 75
        '
        'DgtbcLbmc
        '
        Me.DgtbcLbmc.Format = ""
        Me.DgtbcLbmc.FormatInfo = Nothing
        Me.DgtbcLbmc.HeaderText = "物料类别名称"
        Me.DgtbcLbmc.MappingName = "lbmc"
        Me.DgtbcLbmc.NullText = ""
        Me.DgtbcLbmc.Width = 90
        '
        'DgtbcDanHao
        '
        Me.DgtbcDanHao.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcDanHao.Format = ""
        Me.DgtbcDanHao.FormatInfo = Nothing
        Me.DgtbcDanHao.HeaderText = "单耗"
        Me.DgtbcDanHao.MappingName = "danhao"
        Me.DgtbcDanHao.NullText = ""
        Me.DgtbcDanHao.Width = 75
        '
        'DgtbcChanLiang
        '
        Me.DgtbcChanLiang.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcChanLiang.Format = ""
        Me.DgtbcChanLiang.FormatInfo = Nothing
        Me.DgtbcChanLiang.HeaderText = "设备产量"
        Me.DgtbcChanLiang.MappingName = "chanliang"
        Me.DgtbcChanLiang.NullText = ""
        Me.DgtbcChanLiang.Width = 75
        '
        'FrmPoBmFaLbHzbz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmPoBmFaLbHzbz"
        Me.Text = "部门设备物料类别消耗汇总表"
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DgtbcBmdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBmmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJe As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcFadm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcFamc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcLbdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcLbmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDanHao As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcChanLiang As System.Windows.Forms.DataGridTextBoxColumn
End Class
