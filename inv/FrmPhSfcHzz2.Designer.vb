<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPhSfcHzz2
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
        Me.DgtbcQcsl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcQcje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcRksl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcRkje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCksl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCkje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJcsl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJcje = New System.Windows.Forms.DataGridTextBoxColumn
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
        Me.Label1.Location = New System.Drawing.Point(397, 8)
        Me.Label1.Size = New System.Drawing.Size(186, 23)
        Me.Label1.Text = "物料批次收发存汇总表"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.rcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcCpdm, Me.DgtbcCpmc, Me.DgtbcDw, Me.DgtbcQcsl, Me.DgtbcQcje, Me.DgtbcRksl, Me.DgtbcRkje, Me.DgtbcCksl, Me.DgtbcCkje, Me.DgtbcJcsl, Me.DgtbcJcje})
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
        'FrmPhSfcHzz2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmPhSfcHzz2"
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
End Class
