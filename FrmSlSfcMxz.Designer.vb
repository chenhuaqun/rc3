<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSlSfcMxz
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
        Me.DgtbcRkfzsl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCksl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCkfzsl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJcsl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJcfzsl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Label3 = New System.Windows.Forms.Label
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
        Me.Label1.Text = "仓库收发存明细账"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.rcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcRq, Me.DgtbcDjh, Me.DgtbcZy, Me.DgtbcRksl, Me.DgtbcRkfzsl, Me.DgtbcCksl, Me.DgtbcCkfzsl, Me.DgtbcJcsl, Me.DgtbcJcfzsl})
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
        Me.DgtbcZy.Width = 135
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
        'DgtbcRkfzsl
        '
        Me.DgtbcRkfzsl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcRkfzsl.Format = ""
        Me.DgtbcRkfzsl.FormatInfo = Nothing
        Me.DgtbcRkfzsl.HeaderText = "入库辅数量"
        Me.DgtbcRkfzsl.MappingName = "rkfzsl"
        Me.DgtbcRkfzsl.NullText = ""
        Me.DgtbcRkfzsl.Width = 90
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
        'DgtbcCkfzsl
        '
        Me.DgtbcCkfzsl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcCkfzsl.Format = ""
        Me.DgtbcCkfzsl.FormatInfo = Nothing
        Me.DgtbcCkfzsl.HeaderText = "出库辅数量"
        Me.DgtbcCkfzsl.MappingName = "ckfzsl"
        Me.DgtbcCkfzsl.NullText = ""
        Me.DgtbcCkfzsl.Width = 90
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
        'DgtbcJcfzsl
        '
        Me.DgtbcJcfzsl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcJcfzsl.Format = ""
        Me.DgtbcJcfzsl.FormatInfo = Nothing
        Me.DgtbcJcfzsl.HeaderText = "结存辅数量"
        Me.DgtbcJcfzsl.MappingName = "jcfzsl"
        Me.DgtbcJcfzsl.NullText = ""
        Me.DgtbcJcfzsl.Width = 90
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(372, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 12)
        Me.Label3.TabIndex = 15
        '
        'FrmSlSfcMxz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmSlSfcMxz"
        Me.Text = "仓库收发存明细账"
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DgtbcRkfzsl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCkfzsl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJcfzsl As System.Windows.Forms.DataGridTextBoxColumn
End Class
