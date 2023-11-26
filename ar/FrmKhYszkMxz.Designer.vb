<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmKhYszkMxz
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
        Me.DgtbcYsje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSkje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcYe = New System.Windows.Forms.DataGridTextBoxColumn
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
        Me.Label1.Location = New System.Drawing.Point(386, 8)
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(208, 23)
        Me.Label1.Text = "客户应收账款明细账"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.rcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcRq, Me.DgtbcDjh, Me.DgtbcZy, Me.DgtbcYsje, Me.DgtbcSkje, Me.DgtbcYe})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "khyszkmx"
        '
        'DgtbcRq
        '
        Me.DgtbcRq.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DgtbcRq.Format = ""
        Me.DgtbcRq.FormatInfo = Nothing
        Me.DgtbcRq.HeaderText = "日期"
        Me.DgtbcRq.MappingName = "rq"
        Me.DgtbcRq.NullText = ""
        Me.DgtbcRq.Width = 90
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
        'DgtbcYsje
        '
        Me.DgtbcYsje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcYsje.Format = ""
        Me.DgtbcYsje.FormatInfo = Nothing
        Me.DgtbcYsje.HeaderText = "应收金额"
        Me.DgtbcYsje.MappingName = "ysje"
        Me.DgtbcYsje.NullText = ""
        Me.DgtbcYsje.Width = 90
        '
        'DgtbcSkje
        '
        Me.DgtbcSkje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSkje.Format = ""
        Me.DgtbcSkje.FormatInfo = Nothing
        Me.DgtbcSkje.HeaderText = "收款金额"
        Me.DgtbcSkje.MappingName = "skje"
        Me.DgtbcSkje.NullText = ""
        Me.DgtbcSkje.Width = 90
        '
        'DgtbcYe
        '
        Me.DgtbcYe.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcYe.Format = ""
        Me.DgtbcYe.FormatInfo = Nothing
        Me.DgtbcYe.HeaderText = "余额"
        Me.DgtbcYe.MappingName = "ye"
        Me.DgtbcYe.NullText = ""
        Me.DgtbcYe.Width = 90
        '
        'FrmKhYszkMxz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmKhYszkMxz"
        Me.Text = "客户应收账款明细账"
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
    Friend WithEvents DgtbcYsje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSkje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcYe As System.Windows.Forms.DataGridTextBoxColumn
End Class
