<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCplbSfcHzz
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
        Me.DgtbcLbdm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcLbmc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcQcje = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcRkje = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcCkje = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcJcje = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcQcsl = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcQczl = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcRksl = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcRkzl = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcCksl = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcCkzl = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcJcsl = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcJczl = New System.Windows.Forms.DataGridTextBoxColumn()
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'rcDataGrid
        '
        Me.rcDataGrid.Location = New System.Drawing.Point(0, 235)
        Me.rcDataGrid.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rcDataGrid.Size = New System.Drawing.Size(1476, 607)
        Me.rcDataGrid.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(0, 75)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Size = New System.Drawing.Size(1476, 160)
        '
        'Panel4
        '
        Me.Panel4.Location = New System.Drawing.Point(233, 90)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel4.Size = New System.Drawing.Size(1000, 4)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(60, 108)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(563, 12)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Size = New System.Drawing.Size(335, 33)
        Me.Label1.Text = "物料类别收发存汇总表"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.rcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcLbdm, Me.DgtbcLbmc, Me.DgtbcQcsl, Me.DgtbcQczl, Me.DgtbcQcje, Me.DgtbcRksl, Me.DgtbcRkzl, Me.DgtbcRkje, Me.DgtbcCksl, Me.DgtbcCkzl, Me.DgtbcCkje, Me.DgtbcJcsl, Me.DgtbcJczl, Me.DgtbcJcje})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "CplbSfchz"
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
        Me.DgtbcLbmc.Width = 135
        '
        'DgtbcQcje
        '
        Me.DgtbcQcje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcQcje.Format = ""
        Me.DgtbcQcje.FormatInfo = Nothing
        Me.DgtbcQcje.HeaderText = "期初金额"
        Me.DgtbcQcje.MappingName = "qcje"
        Me.DgtbcQcje.NullText = ""
        Me.DgtbcQcje.Width = 75
        '
        'DgtbcRkje
        '
        Me.DgtbcRkje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcRkje.Format = ""
        Me.DgtbcRkje.FormatInfo = Nothing
        Me.DgtbcRkje.HeaderText = "入库金额"
        Me.DgtbcRkje.MappingName = "rkje"
        Me.DgtbcRkje.NullText = ""
        Me.DgtbcRkje.Width = 75
        '
        'DgtbcCkje
        '
        Me.DgtbcCkje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcCkje.Format = ""
        Me.DgtbcCkje.FormatInfo = Nothing
        Me.DgtbcCkje.HeaderText = "出库金额"
        Me.DgtbcCkje.MappingName = "ckje"
        Me.DgtbcCkje.NullText = ""
        Me.DgtbcCkje.Width = 75
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
        'DgtbcQcsl
        '
        Me.DgtbcQcsl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcQcsl.Format = ""
        Me.DgtbcQcsl.FormatInfo = Nothing
        Me.DgtbcQcsl.HeaderText = "期初数量"
        Me.DgtbcQcsl.MappingName = "qcsl"
        Me.DgtbcQcsl.NullText = ""
        Me.DgtbcQcsl.Width = 75
        '
        'DgtbcQczl
        '
        Me.DgtbcQczl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcQczl.Format = ""
        Me.DgtbcQczl.FormatInfo = Nothing
        Me.DgtbcQczl.HeaderText = "期初重量"
        Me.DgtbcQczl.MappingName = "qczl"
        Me.DgtbcQczl.NullText = ""
        Me.DgtbcQczl.Width = 75
        '
        'DgtbcRksl
        '
        Me.DgtbcRksl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcRksl.Format = ""
        Me.DgtbcRksl.FormatInfo = Nothing
        Me.DgtbcRksl.HeaderText = "入库数量"
        Me.DgtbcRksl.MappingName = "rksl"
        Me.DgtbcRksl.NullText = ""
        Me.DgtbcRksl.Width = 75
        '
        'DgtbcRkzl
        '
        Me.DgtbcRkzl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcRkzl.Format = ""
        Me.DgtbcRkzl.FormatInfo = Nothing
        Me.DgtbcRkzl.HeaderText = "入库重量"
        Me.DgtbcRkzl.MappingName = "rkzl"
        Me.DgtbcRkzl.NullText = ""
        Me.DgtbcRkzl.Width = 75
        '
        'DgtbcCksl
        '
        Me.DgtbcCksl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcCksl.Format = ""
        Me.DgtbcCksl.FormatInfo = Nothing
        Me.DgtbcCksl.HeaderText = "出库数量"
        Me.DgtbcCksl.MappingName = "cksl"
        Me.DgtbcCksl.NullText = ""
        Me.DgtbcCksl.Width = 75
        '
        'DgtbcCkzl
        '
        Me.DgtbcCkzl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcCkzl.Format = ""
        Me.DgtbcCkzl.FormatInfo = Nothing
        Me.DgtbcCkzl.HeaderText = "出库重量"
        Me.DgtbcCkzl.MappingName = "ckzl"
        Me.DgtbcCkzl.NullText = ""
        Me.DgtbcCkzl.Width = 75
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
        'DgtbcJczl
        '
        Me.DgtbcJczl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcJczl.Format = ""
        Me.DgtbcJczl.FormatInfo = Nothing
        Me.DgtbcJczl.HeaderText = "结存重量"
        Me.DgtbcJczl.MappingName = "jczl"
        Me.DgtbcJczl.NullText = ""
        Me.DgtbcJczl.Width = 75
        '
        'FrmCplbSfcHzz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1476, 842)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FrmCplbSfcHzz"
        Me.Text = "物料类别收发存汇总表"
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DgtbcLbdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcLbmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcQcje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcRkje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCkje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJcje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcQcsl As DataGridTextBoxColumn
    Friend WithEvents DgtbcQczl As DataGridTextBoxColumn
    Friend WithEvents DgtbcRksl As DataGridTextBoxColumn
    Friend WithEvents DgtbcRkzl As DataGridTextBoxColumn
    Friend WithEvents DgtbcCksl As DataGridTextBoxColumn
    Friend WithEvents DgtbcCkzl As DataGridTextBoxColumn
    Friend WithEvents DgtbcJcsl As DataGridTextBoxColumn
    Friend WithEvents DgtbcJczl As DataGridTextBoxColumn
End Class
