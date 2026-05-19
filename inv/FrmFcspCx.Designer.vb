<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFcspCx
    Inherits models.FrmDlgPortrait

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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NudMonth = New System.Windows.Forms.NumericUpDown()
        Me.NudYear = New System.Windows.Forms.NumericUpDown()
        Me.ChbSc = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.DlgPanel.SuspendLayout()
        CType(Me.NudMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancel
        '
        Me.BtnCancel.TabIndex = 1
        '
        'BtnHelp
        '
        Me.BtnHelp.TabIndex = 2
        '
        'BtnOk
        '
        Me.BtnOk.TabIndex = 0
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(163, 142)
        Me.DlgPanel.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(295, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "月"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(200, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "年"
        '
        'NudMonth
        '
        Me.NudMonth.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NudMonth.Location = New System.Drawing.Point(239, 34)
        Me.NudMonth.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NudMonth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudMonth.Name = "NudMonth"
        Me.NudMonth.Size = New System.Drawing.Size(40, 26)
        Me.NudMonth.TabIndex = 10
        Me.NudMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudMonth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NudYear
        '
        Me.NudYear.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NudYear.Location = New System.Drawing.Point(120, 34)
        Me.NudYear.Maximum = New Decimal(New Integer() {2050, 0, 0, 0})
        Me.NudYear.Minimum = New Decimal(New Integer() {1990, 0, 0, 0})
        Me.NudYear.Name = "NudYear"
        Me.NudYear.Size = New System.Drawing.Size(64, 26)
        Me.NudYear.TabIndex = 8
        Me.NudYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudYear.Value = New Decimal(New Integer() {1990, 0, 0, 0})
        '
        'ChbSc
        '
        Me.ChbSc.AutoSize = True
        Me.ChbSc.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ChbSc.ForeColor = System.Drawing.Color.SteelBlue
        Me.ChbSc.Location = New System.Drawing.Point(85, 79)
        Me.ChbSc.Name = "ChbSc"
        Me.ChbSc.Size = New System.Drawing.Size(266, 20)
        Me.ChbSc.TabIndex = 25
        Me.ChbSc.Text = "查询结果根据NC导入单据直接生成"
        Me.ChbSc.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.SteelBlue
        Me.CheckBox1.Location = New System.Drawing.Point(85, 105)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(106, 20)
        Me.CheckBox1.TabIndex = 26
        Me.CheckBox1.Text = "按部门汇总"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'FrmFcspCx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(416, 185)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.ChbSc)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NudMonth)
        Me.Controls.Add(Me.NudYear)
        Me.Name = "FrmFcspCx"
        Me.Text = "发出商品查询"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.NudYear, 0)
        Me.Controls.SetChildIndex(Me.NudMonth, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.ChbSc, 0)
        Me.Controls.SetChildIndex(Me.CheckBox1, 0)
        Me.DlgPanel.ResumeLayout(False)
        CType(Me.NudMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NudMonth As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudYear As System.Windows.Forms.NumericUpDown
    Friend WithEvents ChbSc As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
End Class
