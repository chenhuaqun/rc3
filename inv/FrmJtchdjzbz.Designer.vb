<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmJtchdjzbz
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
        Me.DgtbcKcsl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcKcje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcKcsl_Tot = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcKcje_Tot = New System.Windows.Forms.DataGridTextBoxColumn
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
        Me.Label1.Size = New System.Drawing.Size(186, 23)
        Me.Label1.Text = "计提存货跌价准备"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.rcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcCpdm, Me.DgtbcCpmc, Me.DgtbcDw, Me.DgtbcKcsl, Me.DgtbcKcje, Me.DgtbcKcsl_Tot, Me.DgtbcKcje_Tot})
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
        'DgtbcKcsl
        '
        Me.DgtbcKcsl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcKcsl.Format = ""
        Me.DgtbcKcsl.FormatInfo = Nothing
        Me.DgtbcKcsl.HeaderText = "库存数量"
        Me.DgtbcKcsl.MappingName = "kcsl"
        Me.DgtbcKcsl.NullText = ""
        Me.DgtbcKcsl.Width = 75
        '
        'DgtbcKcje
        '
        Me.DgtbcKcje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcKcje.Format = ""
        Me.DgtbcKcje.FormatInfo = Nothing
        Me.DgtbcKcje.HeaderText = "库存金额"
        Me.DgtbcKcje.MappingName = "kcje"
        Me.DgtbcKcje.NullText = ""
        Me.DgtbcKcje.Width = 75
        '
        'DgtbcKcsl_Tot
        '
        Me.DgtbcKcsl_Tot.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcKcsl_Tot.Format = ""
        Me.DgtbcKcsl_Tot.FormatInfo = Nothing
        Me.DgtbcKcsl_Tot.HeaderText = "结存数量"
        Me.DgtbcKcsl_Tot.MappingName = "kcsl_tot"
        Me.DgtbcKcsl_Tot.NullText = ""
        Me.DgtbcKcsl_Tot.Width = 75
        '
        'DgtbcKcje_Tot
        '
        Me.DgtbcKcje_Tot.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcKcje_Tot.Format = ""
        Me.DgtbcKcje_Tot.FormatInfo = Nothing
        Me.DgtbcKcje_Tot.HeaderText = "结存金额"
        Me.DgtbcKcje_Tot.MappingName = "kcje_tot"
        Me.DgtbcKcje_Tot.NullText = ""
        Me.DgtbcKcje_Tot.Width = 75
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
        'FrmJtchdjzbz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmJtchdjzbz"
        Me.Text = "计提存货跌价准备"
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
    Friend WithEvents DgtbcKcsl_Tot As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcKcje_Tot As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcKcsl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcKcje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
