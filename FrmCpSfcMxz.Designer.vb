<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCpSfcMxz
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
        Me.DgtbcRq = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcDjh = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcZy = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcRksl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcRkje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCksl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCkje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJcsl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJcje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Label3 = New System.Windows.Forms.Label
        Me.DgtbcRkdj = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCkdj = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJcdj = New System.Windows.Forms.DataGridTextBoxColumn
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
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(186, 23)
        Me.Label1.Text = "物料收发存明细账"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.rcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcRq, Me.DgtbcDjh, Me.DgtbcZy, Me.DgtbcRksl, Me.DgtbcRkdj, Me.DgtbcRkje, Me.DgtbcCksl, Me.DgtbcCkdj, Me.DgtbcCkje, Me.DgtbcJcsl, Me.DgtbcJcdj, Me.DgtbcJcje})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "cpsfcmx"
        '
        'DgtbcRq
        '
        Me.DgtbcRq.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DgtbcRq.Format = ""
        Me.DgtbcRq.FormatInfo = Nothing
        Me.DgtbcRq.HeaderText = "日期"
        Me.DgtbcRq.MappingName = "rq"
        Me.DgtbcRq.NullText = ""
        Me.DgtbcRq.Width = 110
        '
        'DgtbcDjh
        '
        Me.DgtbcDjh.Format = ""
        Me.DgtbcDjh.FormatInfo = Nothing
        Me.DgtbcDjh.HeaderText = "单据号"
        Me.DgtbcDjh.MappingName = "djh"
        Me.DgtbcDjh.NullText = ""
        Me.DgtbcDjh.Width = 110
        '
        'DgtbcZy
        '
        Me.DgtbcZy.Format = ""
        Me.DgtbcZy.FormatInfo = Nothing
        Me.DgtbcZy.HeaderText = "摘要"
        Me.DgtbcZy.MappingName = "zy"
        Me.DgtbcZy.NullText = ""
        Me.DgtbcZy.Width = 180
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
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(470, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 12)
        Me.Label3.TabIndex = 15
        '
        'DgtbcRkdj
        '
        Me.DgtbcRkdj.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcRkdj.Format = ""
        Me.DgtbcRkdj.FormatInfo = Nothing
        Me.DgtbcRkdj.HeaderText = "入库单价"
        Me.DgtbcRkdj.MappingName = "rkdj"
        Me.DgtbcRkdj.NullText = ""
        Me.DgtbcRkdj.Width = 90
        '
        'DgtbcCkdj
        '
        Me.DgtbcCkdj.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcCkdj.Format = ""
        Me.DgtbcCkdj.FormatInfo = Nothing
        Me.DgtbcCkdj.HeaderText = "出库单价"
        Me.DgtbcCkdj.MappingName = "ckdj"
        Me.DgtbcCkdj.NullText = ""
        Me.DgtbcCkdj.Width = 90
        '
        'DgtbcJcdj
        '
        Me.DgtbcJcdj.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcJcdj.Format = ""
        Me.DgtbcJcdj.FormatInfo = Nothing
        Me.DgtbcJcdj.HeaderText = "结存单价"
        Me.DgtbcJcdj.MappingName = "jcdj"
        Me.DgtbcJcdj.NullText = ""
        Me.DgtbcJcdj.Width = 90
        '
        'FrmCpSfcMxz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmCpSfcMxz"
        Me.Text = "物料收发存明细账"
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DgtbcDjh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcRq As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZy As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcRksl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCksl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJcsl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcRkje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCkje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJcje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DgtbcRkdj As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCkdj As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJcdj As System.Windows.Forms.DataGridTextBoxColumn
End Class
