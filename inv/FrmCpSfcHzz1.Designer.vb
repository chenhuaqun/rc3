<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCpSfcHzz1
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
        Me.DgtbcQcsl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcQcje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcRksl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcRkje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCksl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCkje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJcsl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJcje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Label3 = New System.Windows.Forms.Label
        Me.DgtbcCpweight = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcBzcb = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcQczl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcRkzl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCkzl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJczl = New System.Windows.Forms.DataGridTextBoxColumn
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
        Me.Label1.Location = New System.Drawing.Point(397, 8)
        Me.Label1.Size = New System.Drawing.Size(186, 23)
        Me.Label1.Text = "物料收发存汇总表"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.rcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcCpdm, Me.DgtbcCpmc, Me.DgtbcDw, Me.DgtbcCkdm, Me.DgtbcCkmc, Me.DgtbcCpweight, Me.DgtbcBzcb, Me.DgtbcQcsl, Me.DgtbcQczl, Me.DgtbcQcje, Me.DgtbcRksl, Me.DgtbcRkzl, Me.DgtbcRkje, Me.DgtbcCksl, Me.DgtbcCkzl, Me.DgtbcCkje, Me.DgtbcJcsl, Me.DgtbcJczl, Me.DgtbcJcje})
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
        'DgtbcQcsl
        '
        Me.DgtbcQcsl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcQcsl.Format = ""
        Me.DgtbcQcsl.FormatInfo = Nothing
        Me.DgtbcQcsl.HeaderText = "期初数量"
        Me.DgtbcQcsl.MappingName = "qcsl"
        Me.DgtbcQcsl.NullText = ""
        Me.DgtbcQcsl.Width = 90
        '
        'DgtbcQcje
        '
        Me.DgtbcQcje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcQcje.Format = ""
        Me.DgtbcQcje.FormatInfo = Nothing
        Me.DgtbcQcje.HeaderText = "期初金额"
        Me.DgtbcQcje.MappingName = "qcje"
        Me.DgtbcQcje.NullText = ""
        Me.DgtbcQcje.Width = 90
        '
        'DgtbcRksl
        '
        Me.DgtbcRksl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcRksl.Format = ""
        Me.DgtbcRksl.FormatInfo = Nothing
        Me.DgtbcRksl.HeaderText = "入库数量"
        Me.DgtbcRksl.MappingName = "rksl"
        Me.DgtbcRksl.NullText = ""
        Me.DgtbcRksl.Width = 90
        '
        'DgtbcRkje
        '
        Me.DgtbcRkje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcRkje.Format = ""
        Me.DgtbcRkje.FormatInfo = Nothing
        Me.DgtbcRkje.HeaderText = "入库金额"
        Me.DgtbcRkje.MappingName = "rkje"
        Me.DgtbcRkje.NullText = ""
        Me.DgtbcRkje.Width = 90
        '
        'DgtbcCksl
        '
        Me.DgtbcCksl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcCksl.Format = ""
        Me.DgtbcCksl.FormatInfo = Nothing
        Me.DgtbcCksl.HeaderText = "出库数量"
        Me.DgtbcCksl.MappingName = "cksl"
        Me.DgtbcCksl.NullText = ""
        Me.DgtbcCksl.Width = 90
        '
        'DgtbcCkje
        '
        Me.DgtbcCkje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcCkje.Format = ""
        Me.DgtbcCkje.FormatInfo = Nothing
        Me.DgtbcCkje.HeaderText = "出库金额"
        Me.DgtbcCkje.MappingName = "ckje"
        Me.DgtbcCkje.NullText = ""
        Me.DgtbcCkje.Width = 90
        '
        'DgtbcJcsl
        '
        Me.DgtbcJcsl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcJcsl.Format = ""
        Me.DgtbcJcsl.FormatInfo = Nothing
        Me.DgtbcJcsl.HeaderText = "结存数量"
        Me.DgtbcJcsl.MappingName = "jcsl"
        Me.DgtbcJcsl.NullText = ""
        Me.DgtbcJcsl.Width = 90
        '
        'DgtbcJcje
        '
        Me.DgtbcJcje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcJcje.Format = ""
        Me.DgtbcJcje.FormatInfo = Nothing
        Me.DgtbcJcje.HeaderText = "结存金额"
        Me.DgtbcJcje.MappingName = "jcje"
        Me.DgtbcJcje.NullText = ""
        Me.DgtbcJcje.Width = 90
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
        'DgtbcCpweight
        '
        Me.DgtbcCpweight.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcCpweight.Format = ""
        Me.DgtbcCpweight.FormatInfo = Nothing
        Me.DgtbcCpweight.HeaderText = "单位克重"
        Me.DgtbcCpweight.MappingName = "cpweight"
        Me.DgtbcCpweight.NullText = ""
        Me.DgtbcCpweight.Width = 90
        '
        'DgtbcBzcb
        '
        Me.DgtbcBzcb.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcBzcb.Format = ""
        Me.DgtbcBzcb.FormatInfo = Nothing
        Me.DgtbcBzcb.HeaderText = "标准成本"
        Me.DgtbcBzcb.MappingName = "bzcb"
        Me.DgtbcBzcb.NullText = ""
        Me.DgtbcBzcb.Width = 90
        '
        'DgtbcQczl
        '
        Me.DgtbcQczl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcQczl.Format = ""
        Me.DgtbcQczl.FormatInfo = Nothing
        Me.DgtbcQczl.HeaderText = "期初重量"
        Me.DgtbcQczl.MappingName = "qczl"
        Me.DgtbcQczl.NullText = ""
        Me.DgtbcQczl.Width = 90
        '
        'DgtbcRkzl
        '
        Me.DgtbcRkzl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcRkzl.Format = ""
        Me.DgtbcRkzl.FormatInfo = Nothing
        Me.DgtbcRkzl.HeaderText = "入库重量"
        Me.DgtbcRkzl.MappingName = "rkzl"
        Me.DgtbcRkzl.NullText = ""
        Me.DgtbcRkzl.Width = 90
        '
        'DgtbcCkzl
        '
        Me.DgtbcCkzl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcCkzl.Format = ""
        Me.DgtbcCkzl.FormatInfo = Nothing
        Me.DgtbcCkzl.HeaderText = "出库重量"
        Me.DgtbcCkzl.MappingName = "ckzl"
        Me.DgtbcCkzl.NullText = ""
        Me.DgtbcCkzl.Width = 90
        '
        'DgtbcJczl
        '
        Me.DgtbcJczl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcJczl.Format = ""
        Me.DgtbcJczl.FormatInfo = Nothing
        Me.DgtbcJczl.HeaderText = "结存重量"
        Me.DgtbcJczl.MappingName = "jczl"
        Me.DgtbcJczl.NullText = ""
        Me.DgtbcJczl.Width = 90
        '
        'FrmCpSfcHzz1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmCpSfcHzz1"
        Me.Text = "物料收发存汇总表"
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
    Friend WithEvents DgtbcQcsl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcQcje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcRksl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcRkje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCksl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCkje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJcsl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJcje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCkdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCkmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DgtbcCpweight As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBzcb As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcQczl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcRkzl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCkzl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJczl As System.Windows.Forms.DataGridTextBoxColumn
End Class
