<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCpPcbz
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
        Me.DgtbcCkdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCkmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcKuwei = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcZdcb = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcZgcb = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCgdj = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJcsl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJcje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcXsdj = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcXsje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcMll = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Label3 = New System.Windows.Forms.Label
        Me.DgtbcJcfzsl = New System.Windows.Forms.DataGridTextBoxColumn
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
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.SetChildIndex(Me.Label3, 0)
        Me.Panel1.Controls.SetChildIndex(Me.Label1, 0)
        Me.Panel1.Controls.SetChildIndex(Me.Label2, 0)
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(430, 8)
        Me.Label1.Size = New System.Drawing.Size(120, 23)
        Me.Label1.Text = "物料盘存表"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.rcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcCpdm, Me.DgtbcCpmc, Me.DgtbcDw, Me.DgtbcCkdm, Me.DgtbcCkmc, Me.DgtbcKuwei, Me.DgtbcZdcb, Me.DgtbcZgcb, Me.DgtbcCgdj, Me.DgtbcJcsl, Me.DgtbcJcfzsl, Me.DgtbcJcje, Me.DgtbcXsdj, Me.DgtbcXsje, Me.DgtbcMll})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "cpsfchz"
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
        Me.DgtbcCpmc.Width = 250
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
        'DgtbcCkdm
        '
        Me.DgtbcCkdm.Format = ""
        Me.DgtbcCkdm.FormatInfo = Nothing
        Me.DgtbcCkdm.HeaderText = "仓库编码"
        Me.DgtbcCkdm.MappingName = "ckdm"
        Me.DgtbcCkdm.NullText = ""
        Me.DgtbcCkdm.Width = 60
        '
        'DgtbcCkmc
        '
        Me.DgtbcCkmc.Format = ""
        Me.DgtbcCkmc.FormatInfo = Nothing
        Me.DgtbcCkmc.HeaderText = "仓库名称"
        Me.DgtbcCkmc.MappingName = "ckmc"
        Me.DgtbcCkmc.NullText = ""
        Me.DgtbcCkmc.Width = 90
        '
        'DgtbcKuwei
        '
        Me.DgtbcKuwei.Format = ""
        Me.DgtbcKuwei.FormatInfo = Nothing
        Me.DgtbcKuwei.HeaderText = "库位"
        Me.DgtbcKuwei.MappingName = "kuwei"
        Me.DgtbcKuwei.NullText = ""
        Me.DgtbcKuwei.Width = 90
        '
        'DgtbcZdcb
        '
        Me.DgtbcZdcb.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcZdcb.Format = ""
        Me.DgtbcZdcb.FormatInfo = Nothing
        Me.DgtbcZdcb.HeaderText = "最低储备"
        Me.DgtbcZdcb.MappingName = "zdcb"
        Me.DgtbcZdcb.NullText = ""
        Me.DgtbcZdcb.Width = 75
        '
        'DgtbcZgcb
        '
        Me.DgtbcZgcb.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcZgcb.Format = ""
        Me.DgtbcZgcb.FormatInfo = Nothing
        Me.DgtbcZgcb.HeaderText = "最高储备"
        Me.DgtbcZgcb.MappingName = "zgcb"
        Me.DgtbcZgcb.NullText = ""
        Me.DgtbcZgcb.Width = 75
        '
        'DgtbcCgdj
        '
        Me.DgtbcCgdj.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcCgdj.Format = ""
        Me.DgtbcCgdj.FormatInfo = Nothing
        Me.DgtbcCgdj.HeaderText = "采购单价"
        Me.DgtbcCgdj.MappingName = "cgdj"
        Me.DgtbcCgdj.NullText = ""
        Me.DgtbcCgdj.Width = 75
        '
        'DgtbcJcsl
        '
        Me.DgtbcJcsl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcJcsl.Format = ""
        Me.DgtbcJcsl.FormatInfo = Nothing
        Me.DgtbcJcsl.HeaderText = "结存数量"
        Me.DgtbcJcsl.MappingName = "jcsl"
        Me.DgtbcJcsl.NullText = ""
        Me.DgtbcJcsl.Width = 75
        '
        'DgtbcJcje
        '
        Me.DgtbcJcje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcJcje.Format = ""
        Me.DgtbcJcje.FormatInfo = Nothing
        Me.DgtbcJcje.HeaderText = "结存金额"
        Me.DgtbcJcje.MappingName = "jcje"
        Me.DgtbcJcje.NullText = ""
        Me.DgtbcJcje.Width = 75
        '
        'DgtbcXsdj
        '
        Me.DgtbcXsdj.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcXsdj.Format = ""
        Me.DgtbcXsdj.FormatInfo = Nothing
        Me.DgtbcXsdj.HeaderText = "销售单价"
        Me.DgtbcXsdj.MappingName = "xsdj"
        Me.DgtbcXsdj.NullText = ""
        Me.DgtbcXsdj.Width = 75
        '
        'DgtbcXsje
        '
        Me.DgtbcXsje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcXsje.Format = ""
        Me.DgtbcXsje.FormatInfo = Nothing
        Me.DgtbcXsje.HeaderText = "销售金额"
        Me.DgtbcXsje.MappingName = "xsje"
        Me.DgtbcXsje.NullText = ""
        Me.DgtbcXsje.Width = 75
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(496, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "仓库："
        '
        'DgtbcJcfzsl
        '
        Me.DgtbcJcfzsl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcJcfzsl.Format = ""
        Me.DgtbcJcfzsl.FormatInfo = Nothing
        Me.DgtbcJcfzsl.HeaderText = "结存辅数量"
        Me.DgtbcJcfzsl.MappingName = "jcfzsl"
        Me.DgtbcJcfzsl.NullText = ""
        Me.DgtbcJcfzsl.Width = 75
        '
        'FrmCpPcbz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmCpPcbz"
        Me.Text = "物料盘存表"
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
    Friend WithEvents DgtbcZdcb As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZgcb As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCgdj As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJcsl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJcje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCkdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCkmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DgtbcKuwei As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcXsdj As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcXsje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcMll As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJcfzsl As System.Windows.Forms.DataGridTextBoxColumn
End Class
