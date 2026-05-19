<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFcspCxz
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
        Me.DgtbcCperiod = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcCkkjqj = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcDjh = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcXh = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcShKhdm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcShKhmc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcFpKhdm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcFpKhmc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcBmdm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcBmmc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcCpdm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcCpmc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcDw = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcSl = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcJe = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcSe = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcCbje = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcFzsl = New System.Windows.Forms.DataGridTextBoxColumn()
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
        Me.Label1.Location = New System.Drawing.Point(408, 8)
        Me.Label1.Size = New System.Drawing.Size(144, 26)
        Me.Label1.Text = "发出商品清单"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.RcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcCperiod, Me.DgtbcCkkjqj, Me.DgtbcDjh, Me.DgtbcXh, Me.DgtbcShKhdm, Me.DgtbcShKhmc, Me.DgtbcFpKhdm, Me.DgtbcFpKhmc, Me.DgtbcBmdm, Me.DgtbcBmmc, Me.DgtbcCpdm, Me.DgtbcCpmc, Me.DgtbcDw, Me.DgtbcSl, Me.DgtbcFzsl, Me.DgtbcJe, Me.DgtbcSe, Me.DgtbcCbje})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "fcsplb"
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
        'DgtbcCkkjqj
        '
        Me.DgtbcCkkjqj.Format = ""
        Me.DgtbcCkkjqj.FormatInfo = Nothing
        Me.DgtbcCkkjqj.HeaderText = "出库会计期间"
        Me.DgtbcCkkjqj.MappingName = "ckkjqj"
        Me.DgtbcCkkjqj.NullText = ""
        Me.DgtbcCkkjqj.Width = 75
        '
        'DgtbcDjh
        '
        Me.DgtbcDjh.Format = ""
        Me.DgtbcDjh.FormatInfo = Nothing
        Me.DgtbcDjh.HeaderText = "单据号"
        Me.DgtbcDjh.MappingName = "djh"
        Me.DgtbcDjh.NullText = ""
        Me.DgtbcDjh.Width = 90
        '
        'DgtbcXh
        '
        Me.DgtbcXh.Format = ""
        Me.DgtbcXh.FormatInfo = Nothing
        Me.DgtbcXh.HeaderText = "行号"
        Me.DgtbcXh.MappingName = "xh"
        Me.DgtbcXh.NullText = ""
        Me.DgtbcXh.Width = 45
        '
        'DgtbcShKhdm
        '
        Me.DgtbcShKhdm.Format = ""
        Me.DgtbcShKhdm.FormatInfo = Nothing
        Me.DgtbcShKhdm.HeaderText = "收货客户编码"
        Me.DgtbcShKhdm.MappingName = "shkhdm"
        Me.DgtbcShKhdm.NullText = ""
        Me.DgtbcShKhdm.Width = 75
        '
        'DgtbcShKhmc
        '
        Me.DgtbcShKhmc.Format = ""
        Me.DgtbcShKhmc.FormatInfo = Nothing
        Me.DgtbcShKhmc.HeaderText = "收货客户名称"
        Me.DgtbcShKhmc.MappingName = "shkhmc"
        Me.DgtbcShKhmc.NullText = ""
        Me.DgtbcShKhmc.Width = 135
        '
        'DgtbcFpKhdm
        '
        Me.DgtbcFpKhdm.Format = ""
        Me.DgtbcFpKhdm.FormatInfo = Nothing
        Me.DgtbcFpKhdm.HeaderText = "开票客户编码"
        Me.DgtbcFpKhdm.MappingName = "fpkhdm"
        Me.DgtbcFpKhdm.NullText = ""
        Me.DgtbcFpKhdm.Width = 75
        '
        'DgtbcFpKhmc
        '
        Me.DgtbcFpKhmc.Format = ""
        Me.DgtbcFpKhmc.FormatInfo = Nothing
        Me.DgtbcFpKhmc.HeaderText = "开票客户名称"
        Me.DgtbcFpKhmc.MappingName = "fpkhmc"
        Me.DgtbcFpKhmc.NullText = ""
        Me.DgtbcFpKhmc.Width = 135
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
        Me.DgtbcBmmc.Width = 90
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
        Me.DgtbcCpmc.Width = 180
        '
        'DgtbcDw
        '
        Me.DgtbcDw.Format = ""
        Me.DgtbcDw.FormatInfo = Nothing
        Me.DgtbcDw.HeaderText = "单位"
        Me.DgtbcDw.MappingName = "dw"
        Me.DgtbcDw.NullText = ""
        Me.DgtbcDw.Width = 45
        '
        'DgtbcSl
        '
        Me.DgtbcSl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSl.Format = ""
        Me.DgtbcSl.FormatInfo = Nothing
        Me.DgtbcSl.HeaderText = "数量"
        Me.DgtbcSl.MappingName = "sl"
        Me.DgtbcSl.NullText = ""
        Me.DgtbcSl.Width = 90
        '
        'DgtbcJe
        '
        Me.DgtbcJe.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcJe.Format = ""
        Me.DgtbcJe.FormatInfo = Nothing
        Me.DgtbcJe.HeaderText = "金额"
        Me.DgtbcJe.MappingName = "je"
        Me.DgtbcJe.NullText = ""
        Me.DgtbcJe.Width = 90
        '
        'DgtbcSe
        '
        Me.DgtbcSe.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSe.Format = ""
        Me.DgtbcSe.FormatInfo = Nothing
        Me.DgtbcSe.HeaderText = "税额"
        Me.DgtbcSe.MappingName = "se"
        Me.DgtbcSe.NullText = ""
        Me.DgtbcSe.Width = 90
        '
        'DgtbcCbje
        '
        Me.DgtbcCbje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcCbje.Format = ""
        Me.DgtbcCbje.FormatInfo = Nothing
        Me.DgtbcCbje.HeaderText = "成本金额"
        Me.DgtbcCbje.MappingName = "cbje"
        Me.DgtbcCbje.NullText = ""
        Me.DgtbcCbje.Width = 90
        '
        'DgtbcFzsl
        '
        Me.DgtbcFzsl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcFzsl.Format = ""
        Me.DgtbcFzsl.FormatInfo = Nothing
        Me.DgtbcFzsl.HeaderText = "重量"
        Me.DgtbcFzsl.MappingName = "fzsl"
        Me.DgtbcFzsl.NullText = ""
        Me.DgtbcFzsl.Width = 90
        '
        'FrmFcspCxz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmFcspCxz"
        Me.Text = "发出商品清单"
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RcDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DgtbcDjh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcXh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcShKhdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCpmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSe As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCbje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDw As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJe As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCperiod As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBmdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCpdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcShKhmc As DataGridTextBoxColumn
    Friend WithEvents DgtbcBmmc As DataGridTextBoxColumn
    Friend WithEvents DgtbcFpKhdm As DataGridTextBoxColumn
    Friend WithEvents DgtbcFpKhmc As DataGridTextBoxColumn
    Friend WithEvents DgtbcCkkjqj As DataGridTextBoxColumn
    Friend WithEvents DgtbcFzsl As DataGridTextBoxColumn
End Class
