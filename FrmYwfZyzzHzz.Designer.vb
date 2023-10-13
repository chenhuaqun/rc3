<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmYwfZyzzHzz
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
        Me.DgtbcZydm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcZymc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcBngjdf = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcBngjywf = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcBnfgjdf = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcBnfgjywf = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcBnfgjbjs = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcSngjdf = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcSngjywf = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcSnfgjdf = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcSnfgjywf = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcSnfgjbjs = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcZyzzbl = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcZyzzje = New System.Windows.Forms.DataGridTextBoxColumn()
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
        Me.Label1.Location = New System.Drawing.Point(364, 8)
        Me.Label1.Size = New System.Drawing.Size(252, 23)
        Me.Label1.Text = "业务费业务员增长汇总表"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.RcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcZydm, Me.DgtbcZymc, Me.DgtbcBngjdf, Me.DgtbcBngjywf, Me.DgtbcBnfgjdf, Me.DgtbcBnfgjbjs, Me.DgtbcBnfgjywf, Me.DgtbcSngjdf, Me.DgtbcSngjywf, Me.DgtbcSnfgjdf, Me.DgtbcSnfgjbjs, Me.DgtbcSnfgjywf, Me.DgtbcZyzzbl, Me.DgtbcZyzzje})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "ywfzyzzhz"
        '
        'DgtbcZydm
        '
        Me.DgtbcZydm.Format = ""
        Me.DgtbcZydm.FormatInfo = Nothing
        Me.DgtbcZydm.HeaderText = "职员编码"
        Me.DgtbcZydm.MappingName = "zydm"
        Me.DgtbcZydm.NullText = ""
        Me.DgtbcZydm.Width = 75
        '
        'DgtbcZymc
        '
        Me.DgtbcZymc.Format = ""
        Me.DgtbcZymc.FormatInfo = Nothing
        Me.DgtbcZymc.HeaderText = "职员姓名"
        Me.DgtbcZymc.MappingName = "zymc"
        Me.DgtbcZymc.NullText = ""
        Me.DgtbcZymc.Width = 75
        '
        'DgtbcBngjdf
        '
        Me.DgtbcBngjdf.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcBngjdf.Format = ""
        Me.DgtbcBngjdf.FormatInfo = Nothing
        Me.DgtbcBngjdf.HeaderText = "本年关键客户回笼"
        Me.DgtbcBngjdf.MappingName = "bngjdf"
        Me.DgtbcBngjdf.NullText = ""
        Me.DgtbcBngjdf.Width = 75
        '
        'DgtbcBngjywf
        '
        Me.DgtbcBngjywf.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcBngjywf.Format = ""
        Me.DgtbcBngjywf.FormatInfo = Nothing
        Me.DgtbcBngjywf.HeaderText = "本年关键客户业务费"
        Me.DgtbcBngjywf.MappingName = "bngjywf"
        Me.DgtbcBngjywf.NullText = ""
        Me.DgtbcBngjywf.Width = 75
        '
        'DgtbcBnfgjdf
        '
        Me.DgtbcBnfgjdf.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcBnfgjdf.Format = ""
        Me.DgtbcBnfgjdf.FormatInfo = Nothing
        Me.DgtbcBnfgjdf.HeaderText = "本年非关键客户回笼"
        Me.DgtbcBnfgjdf.MappingName = "bnfgjdf"
        Me.DgtbcBnfgjdf.NullText = ""
        Me.DgtbcBnfgjdf.Width = 75
        '
        'DgtbcBnfgjywf
        '
        Me.DgtbcBnfgjywf.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcBnfgjywf.Format = ""
        Me.DgtbcBnfgjywf.FormatInfo = Nothing
        Me.DgtbcBnfgjywf.HeaderText = "本年非关键客户业务费"
        Me.DgtbcBnfgjywf.MappingName = "bnfgjywf"
        Me.DgtbcBnfgjywf.NullText = ""
        Me.DgtbcBnfgjywf.Width = 75
        '
        'DgtbcBnfgjbjs
        '
        Me.DgtbcBnfgjbjs.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcBnfgjbjs.Format = ""
        Me.DgtbcBnfgjbjs.FormatInfo = Nothing
        Me.DgtbcBnfgjbjs.HeaderText = "其中：本年非关键不计算"
        Me.DgtbcBnfgjbjs.MappingName = "bnfgjbjs"
        Me.DgtbcBnfgjbjs.NullText = ""
        Me.DgtbcBnfgjbjs.Width = 75
        '
        'DgtbcSngjdf
        '
        Me.DgtbcSngjdf.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSngjdf.Format = ""
        Me.DgtbcSngjdf.FormatInfo = Nothing
        Me.DgtbcSngjdf.HeaderText = "上年关键客户回笼"
        Me.DgtbcSngjdf.MappingName = "sngjdf"
        Me.DgtbcSngjdf.NullText = ""
        Me.DgtbcSngjdf.Width = 75
        '
        'DgtbcSngjywf
        '
        Me.DgtbcSngjywf.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSngjywf.Format = ""
        Me.DgtbcSngjywf.FormatInfo = Nothing
        Me.DgtbcSngjywf.HeaderText = "上年关键客户业务费"
        Me.DgtbcSngjywf.MappingName = "sngjywf"
        Me.DgtbcSngjywf.NullText = ""
        Me.DgtbcSngjywf.Width = 75
        '
        'DgtbcSnfgjdf
        '
        Me.DgtbcSnfgjdf.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSnfgjdf.Format = ""
        Me.DgtbcSnfgjdf.FormatInfo = Nothing
        Me.DgtbcSnfgjdf.HeaderText = "上年非关键客户回笼"
        Me.DgtbcSnfgjdf.MappingName = "snfgjdf"
        Me.DgtbcSnfgjdf.NullText = ""
        Me.DgtbcSnfgjdf.Width = 75
        '
        'DgtbcSnfgjywf
        '
        Me.DgtbcSnfgjywf.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSnfgjywf.Format = ""
        Me.DgtbcSnfgjywf.FormatInfo = Nothing
        Me.DgtbcSnfgjywf.HeaderText = "上年非关键客户业务费"
        Me.DgtbcSnfgjywf.MappingName = "snfgjywf"
        Me.DgtbcSnfgjywf.NullText = ""
        Me.DgtbcSnfgjywf.Width = 75
        '
        'DgtbcSnfgjbjs
        '
        Me.DgtbcSnfgjbjs.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSnfgjbjs.Format = ""
        Me.DgtbcSnfgjbjs.FormatInfo = Nothing
        Me.DgtbcSnfgjbjs.HeaderText = "其中：上年非关键不计算"
        Me.DgtbcSnfgjbjs.MappingName = "snfgjbjs"
        Me.DgtbcSnfgjbjs.NullText = ""
        Me.DgtbcSnfgjbjs.Width = 75
        '
        'DgtbcZyzzbl
        '
        Me.DgtbcZyzzbl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcZyzzbl.Format = ""
        Me.DgtbcZyzzbl.FormatInfo = Nothing
        Me.DgtbcZyzzbl.HeaderText = "奖惩系数"
        Me.DgtbcZyzzbl.MappingName = "zyzzbl"
        Me.DgtbcZyzzbl.NullText = ""
        Me.DgtbcZyzzbl.Width = 75
        '
        'DgtbcZyzzje
        '
        Me.DgtbcZyzzje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcZyzzje.Format = ""
        Me.DgtbcZyzzje.FormatInfo = Nothing
        Me.DgtbcZyzzje.HeaderText = "奖惩金额"
        Me.DgtbcZyzzje.MappingName = "zyzzje"
        Me.DgtbcZyzzje.NullText = ""
        Me.DgtbcZyzzje.Width = 75
        '
        'FrmYwfZyzzHzz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmYwfZyzzHzz"
        Me.Text = "业务费业务员增长汇总表"
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RcDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DgtbcSngjdf As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSnfgjdf As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZydm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZymc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBnfgjywf As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZyzzbl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZyzzje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSnfgjywf As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSngjywf As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBnfgjdf As DataGridTextBoxColumn
    Friend WithEvents DgtbcBngjywf As DataGridTextBoxColumn
    Friend WithEvents DgtbcBngjdf As DataGridTextBoxColumn
    Friend WithEvents DgtbcBnfgjbjs As DataGridTextBoxColumn
    Friend WithEvents DgtbcSnfgjbjs As DataGridTextBoxColumn
End Class
