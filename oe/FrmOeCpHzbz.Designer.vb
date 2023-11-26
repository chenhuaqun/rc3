<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeCpHzbz
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
        Me.components = New System.ComponentModel.Container()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DgtbcCpdm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcCpmc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcDw = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcCpweight = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcBzcb = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcCkdm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcCkmc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcSl = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcJe = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcSe = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcCbje = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcDj = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcCbdj = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcMle = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcMll = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.rcContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuiOeXsdcx = New System.Windows.Forms.ToolStripMenuItem()
        Me.DgtbcFzsl = New System.Windows.Forms.DataGridTextBoxColumn()
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RcDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.rcContextMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'RcDataGrid
        '
        Me.RcDataGrid.ContextMenuStrip = Me.rcContextMenuStrip
        Me.RcDataGrid.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(408, 8)
        Me.Label1.Size = New System.Drawing.Size(166, 26)
        Me.Label1.Text = "产品送货汇总表"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.RcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcCpdm, Me.DgtbcCpmc, Me.DgtbcDw, Me.DgtbcCpweight, Me.DgtbcBzcb, Me.DgtbcCkdm, Me.DgtbcCkmc, Me.DgtbcSl, Me.DgtbcFzsl, Me.DgtbcJe, Me.DgtbcSe, Me.DgtbcCbje, Me.DgtbcDj, Me.DgtbcCbdj, Me.DgtbcMle, Me.DgtbcMll})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "oecphzb"
        '
        'DgtbcCpdm
        '
        Me.DgtbcCpdm.Format = ""
        Me.DgtbcCpdm.FormatInfo = Nothing
        Me.DgtbcCpdm.HeaderText = "产品编码"
        Me.DgtbcCpdm.MappingName = "cpdm"
        Me.DgtbcCpdm.NullText = ""
        Me.DgtbcCpdm.Width = 75
        '
        'DgtbcCpmc
        '
        Me.DgtbcCpmc.Format = ""
        Me.DgtbcCpmc.FormatInfo = Nothing
        Me.DgtbcCpmc.HeaderText = "产品名称"
        Me.DgtbcCpmc.MappingName = "cpmc"
        Me.DgtbcCpmc.NullText = ""
        Me.DgtbcCpmc.Width = 240
        '
        'DgtbcDw
        '
        Me.DgtbcDw.Format = ""
        Me.DgtbcDw.FormatInfo = Nothing
        Me.DgtbcDw.HeaderText = "单位"
        Me.DgtbcDw.MappingName = "dw"
        Me.DgtbcDw.NullText = ""
        Me.DgtbcDw.Width = 30
        '
        'DgtbcCpweight
        '
        Me.DgtbcCpweight.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcCpweight.Format = ""
        Me.DgtbcCpweight.FormatInfo = Nothing
        Me.DgtbcCpweight.HeaderText = "克重"
        Me.DgtbcCpweight.MappingName = "cpweight"
        Me.DgtbcCpweight.NullText = ""
        Me.DgtbcCpweight.Width = 75
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
        'DgtbcCkdm
        '
        Me.DgtbcCkdm.Format = ""
        Me.DgtbcCkdm.FormatInfo = Nothing
        Me.DgtbcCkdm.HeaderText = "仓库编码"
        Me.DgtbcCkdm.MappingName = "ckdm"
        Me.DgtbcCkdm.NullText = ""
        Me.DgtbcCkdm.Width = 75
        '
        'DgtbcCkmc
        '
        Me.DgtbcCkmc.Format = ""
        Me.DgtbcCkmc.FormatInfo = Nothing
        Me.DgtbcCkmc.HeaderText = "仓库名称"
        Me.DgtbcCkmc.MappingName = "ckmc"
        Me.DgtbcCkmc.NullText = ""
        Me.DgtbcCkmc.Width = 75
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
        'DgtbcSe
        '
        Me.DgtbcSe.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSe.Format = ""
        Me.DgtbcSe.FormatInfo = Nothing
        Me.DgtbcSe.HeaderText = "税额"
        Me.DgtbcSe.MappingName = "se"
        Me.DgtbcSe.NullText = ""
        Me.DgtbcSe.Width = 75
        '
        'DgtbcCbje
        '
        Me.DgtbcCbje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcCbje.Format = ""
        Me.DgtbcCbje.FormatInfo = Nothing
        Me.DgtbcCbje.HeaderText = "成本金额"
        Me.DgtbcCbje.MappingName = "cbje"
        Me.DgtbcCbje.NullText = ""
        Me.DgtbcCbje.Width = 75
        '
        'DgtbcDj
        '
        Me.DgtbcDj.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcDj.Format = ""
        Me.DgtbcDj.FormatInfo = Nothing
        Me.DgtbcDj.HeaderText = "单位售价"
        Me.DgtbcDj.MappingName = "dj"
        Me.DgtbcDj.NullText = ""
        Me.DgtbcDj.Width = 75
        '
        'DgtbcCbdj
        '
        Me.DgtbcCbdj.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcCbdj.Format = ""
        Me.DgtbcCbdj.FormatInfo = Nothing
        Me.DgtbcCbdj.HeaderText = "成本单价"
        Me.DgtbcCbdj.MappingName = "cbdj"
        Me.DgtbcCbdj.NullText = ""
        Me.DgtbcCbdj.Width = 75
        '
        'DgtbcMle
        '
        Me.DgtbcMle.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcMle.Format = ""
        Me.DgtbcMle.FormatInfo = Nothing
        Me.DgtbcMle.HeaderText = "毛利额"
        Me.DgtbcMle.MappingName = "mle"
        Me.DgtbcMle.NullText = ""
        Me.DgtbcMle.Width = 75
        '
        'DgtbcMll
        '
        Me.DgtbcMll.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcMll.Format = ""
        Me.DgtbcMll.FormatInfo = Nothing
        Me.DgtbcMll.HeaderText = "毛利率"
        Me.DgtbcMll.MappingName = "mll"
        Me.DgtbcMll.NullText = ""
        Me.DgtbcMll.Width = 75
        '
        'rcContextMenuStrip
        '
        Me.rcContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiOeXsdcx})
        Me.rcContextMenuStrip.Name = "rcContextMenuStrip"
        Me.rcContextMenuStrip.Size = New System.Drawing.Size(161, 26)
        '
        'MnuiOeXsdcx
        '
        Me.MnuiOeXsdcx.Name = "MnuiOeXsdcx"
        Me.MnuiOeXsdcx.Size = New System.Drawing.Size(160, 22)
        Me.MnuiOeXsdcx.Text = "查询送货单清单"
        '
        'DgtbcFzsl
        '
        Me.DgtbcFzsl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcFzsl.Format = ""
        Me.DgtbcFzsl.FormatInfo = Nothing
        Me.DgtbcFzsl.HeaderText = "辅数量"
        Me.DgtbcFzsl.MappingName = "fzsl"
        Me.DgtbcFzsl.NullText = ""
        Me.DgtbcFzsl.Width = 75
        '
        'FrmOeCpHzbz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmOeCpHzbz"
        Me.Text = "产品送货汇总表"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.RcDataGrid, 0)
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RcDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.rcContextMenuStrip.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DgtbcCpdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCpmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDw As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJe As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCbje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSe As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDj As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCbdj As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcMll As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcMle As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents rcContextMenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MnuiOeXsdcx As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DgtbcCpweight As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBzcb As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCkdm As DataGridTextBoxColumn
    Friend WithEvents DgtbcCkmc As DataGridTextBoxColumn
    Friend WithEvents DgtbcFzsl As DataGridTextBoxColumn
End Class
