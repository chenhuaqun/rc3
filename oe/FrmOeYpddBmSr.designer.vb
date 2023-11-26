<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeYpddBmSr
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
        Me.ChbNewDd = New System.Windows.Forms.CheckBox
        Me.TxtHth = New System.Windows.Forms.TextBox
        Me.LblHth = New System.Windows.Forms.Label
        Me.DlgPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(43, 143)
        '
        'ChbNewDd
        '
        Me.ChbNewDd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ChbNewDd.ForeColor = System.Drawing.Color.Teal
        Me.ChbNewDd.Location = New System.Drawing.Point(79, 76)
        Me.ChbNewDd.Name = "ChbNewDd"
        Me.ChbNewDd.Size = New System.Drawing.Size(112, 24)
        Me.ChbNewDd.TabIndex = 103
        Me.ChbNewDd.Text = "新销售合同"
        '
        'TxtHth
        '
        Me.TxtHth.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtHth.Location = New System.Drawing.Point(135, 36)
        Me.TxtHth.MaxLength = 11
        Me.TxtHth.Name = "TxtHth"
        Me.TxtHth.Size = New System.Drawing.Size(104, 26)
        Me.TxtHth.TabIndex = 102
        '
        'LblHth
        '
        Me.LblHth.AutoSize = True
        Me.LblHth.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblHth.Location = New System.Drawing.Point(47, 36)
        Me.LblHth.Name = "LblHth"
        Me.LblHth.Size = New System.Drawing.Size(88, 16)
        Me.LblHth.TabIndex = 104
        Me.LblHth.Text = "合同编码："
        '
        'FrmOeYpddBmSr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(294, 184)
        Me.Controls.Add(Me.ChbNewDd)
        Me.Controls.Add(Me.TxtHth)
        Me.Controls.Add(Me.LblHth)
        Me.Name = "FrmOeYpddBmSr"
        Me.Text = "样品生产厂录入"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.LblHth, 0)
        Me.Controls.SetChildIndex(Me.TxtHth, 0)
        Me.Controls.SetChildIndex(Me.ChbNewDd, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ChbNewDd As System.Windows.Forms.CheckBox
    Public WithEvents TxtHth As System.Windows.Forms.TextBox
    Public WithEvents LblHth As System.Windows.Forms.Label
End Class
