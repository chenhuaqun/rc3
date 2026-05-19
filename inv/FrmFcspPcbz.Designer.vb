<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmFcspPcbz
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
        Me.DgtbcCpdm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcCpmc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcDw = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcBmdm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcBmmc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcCgdj = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcJcsl = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcJcfzsl = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcJcje = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcXsdj = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcXsje = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcMll = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DgtbcKhdm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcKhmc = New System.Windows.Forms.DataGridTextBoxColumn()
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RcDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RcDataGrid
        '
        Me.RcDataGrid.Location = New System.Drawing.Point(0, 183)
        Me.RcDataGrid.Size = New System.Drawing.Size(1476, 659)
        Me.RcDataGrid.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(0, 77)
        Me.Panel1.Controls.SetChildIndex(Me.Panel4, 0)
        Me.Panel1.Controls.SetChildIndex(Me.Label3, 0)
        Me.Panel1.Controls.SetChildIndex(Me.Label1, 0)
        Me.Panel1.Controls.SetChildIndex(Me.Label2, 0)
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(616, 12)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Size = New System.Drawing.Size(241, 37)
        Me.Label1.Text = "发出商品盘存表"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.RcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcCpdm, Me.DgtbcCpmc, Me.DgtbcDw, Me.DgtbcBmdm, Me.DgtbcBmmc, Me.DgtbcKhdm, Me.DgtbcKhmc, Me.DgtbcCgdj, Me.DgtbcJcsl, Me.DgtbcJcfzsl, Me.DgtbcJcje, Me.DgtbcXsdj, Me.DgtbcXsje, Me.DgtbcMll})
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
        Me.Label3.Location = New System.Drawing.Point(744, 72)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 18)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "仓库："
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
        'FrmFcspPcbz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1476, 842)
        Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Name = "FrmFcspPcbz"
        Me.Text = "发出商品盘存表"
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
    Friend WithEvents DgtbcCgdj As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJcsl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJcje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBmdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBmmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DgtbcXsdj As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcXsje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcMll As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJcfzsl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcKhdm As DataGridTextBoxColumn
    Friend WithEvents DgtbcKhmc As DataGridTextBoxColumn
End Class
