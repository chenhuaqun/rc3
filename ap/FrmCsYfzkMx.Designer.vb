<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCsYfzkMx
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
        Me.TxtCsdm = New System.Windows.Forms.TextBox
        Me.LblCsdm = New System.Windows.Forms.Label
        Me.LblMonthEnd = New System.Windows.Forms.Label
        Me.NudMonthEnd = New System.Windows.Forms.NumericUpDown
        Me.LblMonthBegin = New System.Windows.Forms.Label
        Me.LblYearBegin = New System.Windows.Forms.Label
        Me.NudMonthBegin = New System.Windows.Forms.NumericUpDown
        Me.NudYear = New System.Windows.Forms.NumericUpDown
        Me.DlgPanel.SuspendLayout()
        CType(Me.NudMonthEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudMonthBegin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(106, 129)
        Me.DlgPanel.TabIndex = 8
        '
        'TxtCsdm
        '
        Me.TxtCsdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCsdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtCsdm.Location = New System.Drawing.Point(142, 72)
        Me.TxtCsdm.MaxLength = 15
        Me.TxtCsdm.Name = "TxtCsdm"
        Me.TxtCsdm.Size = New System.Drawing.Size(104, 26)
        Me.TxtCsdm.TabIndex = 7
        '
        'LblCsdm
        '
        Me.LblCsdm.AutoSize = True
        Me.LblCsdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblCsdm.Location = New System.Drawing.Point(54, 75)
        Me.LblCsdm.Name = "LblCsdm"
        Me.LblCsdm.Size = New System.Drawing.Size(104, 16)
        Me.LblCsdm.TabIndex = 6
        Me.LblCsdm.Text = "供应商编码："
        '
        'LblMonthEnd
        '
        Me.LblMonthEnd.AutoSize = True
        Me.LblMonthEnd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblMonthEnd.Location = New System.Drawing.Point(280, 34)
        Me.LblMonthEnd.Name = "LblMonthEnd"
        Me.LblMonthEnd.Size = New System.Drawing.Size(24, 16)
        Me.LblMonthEnd.TabIndex = 5
        Me.LblMonthEnd.Text = "月"
        '
        'NudMonthEnd
        '
        Me.NudMonthEnd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NudMonthEnd.Location = New System.Drawing.Point(234, 29)
        Me.NudMonthEnd.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NudMonthEnd.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudMonthEnd.Name = "NudMonthEnd"
        Me.NudMonthEnd.Size = New System.Drawing.Size(46, 26)
        Me.NudMonthEnd.TabIndex = 4
        Me.NudMonthEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudMonthEnd.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'LblMonthBegin
        '
        Me.LblMonthBegin.AutoSize = True
        Me.LblMonthBegin.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblMonthBegin.Location = New System.Drawing.Point(188, 34)
        Me.LblMonthBegin.Name = "LblMonthBegin"
        Me.LblMonthBegin.Size = New System.Drawing.Size(40, 16)
        Me.LblMonthBegin.TabIndex = 3
        Me.LblMonthBegin.Text = "月至"
        '
        'LblYearBegin
        '
        Me.LblYearBegin.AutoSize = True
        Me.LblYearBegin.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblYearBegin.Location = New System.Drawing.Point(118, 34)
        Me.LblYearBegin.Name = "LblYearBegin"
        Me.LblYearBegin.Size = New System.Drawing.Size(24, 16)
        Me.LblYearBegin.TabIndex = 1
        Me.LblYearBegin.Text = "年"
        '
        'NudMonthBegin
        '
        Me.NudMonthBegin.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NudMonthBegin.Location = New System.Drawing.Point(142, 29)
        Me.NudMonthBegin.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NudMonthBegin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudMonthBegin.Name = "NudMonthBegin"
        Me.NudMonthBegin.Size = New System.Drawing.Size(46, 26)
        Me.NudMonthBegin.TabIndex = 2
        Me.NudMonthBegin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudMonthBegin.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NudYear
        '
        Me.NudYear.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NudYear.Location = New System.Drawing.Point(57, 29)
        Me.NudYear.Maximum = New Decimal(New Integer() {2050, 0, 0, 0})
        Me.NudYear.Minimum = New Decimal(New Integer() {1990, 0, 0, 0})
        Me.NudYear.Name = "NudYear"
        Me.NudYear.Size = New System.Drawing.Size(61, 26)
        Me.NudYear.TabIndex = 0
        Me.NudYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudYear.Value = New Decimal(New Integer() {1990, 0, 0, 0})
        '
        'FrmCsYfzkMx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(359, 172)
        Me.Controls.Add(Me.TxtCsdm)
        Me.Controls.Add(Me.LblCsdm)
        Me.Controls.Add(Me.LblMonthEnd)
        Me.Controls.Add(Me.NudMonthEnd)
        Me.Controls.Add(Me.LblMonthBegin)
        Me.Controls.Add(Me.LblYearBegin)
        Me.Controls.Add(Me.NudMonthBegin)
        Me.Controls.Add(Me.NudYear)
        Me.Name = "FrmCsYfzkMx"
        Me.Text = "供应商应付账款明细账"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.NudYear, 0)
        Me.Controls.SetChildIndex(Me.NudMonthBegin, 0)
        Me.Controls.SetChildIndex(Me.LblYearBegin, 0)
        Me.Controls.SetChildIndex(Me.LblMonthBegin, 0)
        Me.Controls.SetChildIndex(Me.NudMonthEnd, 0)
        Me.Controls.SetChildIndex(Me.LblMonthEnd, 0)
        Me.Controls.SetChildIndex(Me.LblCsdm, 0)
        Me.Controls.SetChildIndex(Me.TxtCsdm, 0)
        Me.DlgPanel.ResumeLayout(False)
        CType(Me.NudMonthEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudMonthBegin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents TxtCsdm As System.Windows.Forms.TextBox
    Public WithEvents LblCsdm As System.Windows.Forms.Label
    Friend WithEvents LblMonthEnd As System.Windows.Forms.Label
    Friend WithEvents NudMonthEnd As System.Windows.Forms.NumericUpDown
    Friend WithEvents LblMonthBegin As System.Windows.Forms.Label
    Friend WithEvents LblYearBegin As System.Windows.Forms.Label
    Friend WithEvents NudMonthBegin As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudYear As System.Windows.Forms.NumericUpDown
End Class
