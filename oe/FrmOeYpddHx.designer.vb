<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeYpddHx
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
        Me.TxtHth = New System.Windows.Forms.TextBox
        Me.LblHth = New System.Windows.Forms.Label
        Me.TxtKhdm = New System.Windows.Forms.TextBox
        Me.LblKhdm = New System.Windows.Forms.Label
        Me.DlgPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(41, 136)
        '
        'TxtHth
        '
        Me.TxtHth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtHth.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtHth.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtHth.Location = New System.Drawing.Point(128, 70)
        Me.TxtHth.MaxLength = 11
        Me.TxtHth.Name = "TxtHth"
        Me.TxtHth.Size = New System.Drawing.Size(116, 26)
        Me.TxtHth.TabIndex = 3
        '
        'LblHth
        '
        Me.LblHth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblHth.AutoSize = True
        Me.LblHth.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblHth.Location = New System.Drawing.Point(41, 73)
        Me.LblHth.Name = "LblHth"
        Me.LblHth.Size = New System.Drawing.Size(88, 16)
        Me.LblHth.TabIndex = 2
        Me.LblHth.Text = "合同编码："
        '
        'TxtKhdm
        '
        Me.TxtKhdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtKhdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtKhdm.Location = New System.Drawing.Point(128, 33)
        Me.TxtKhdm.MaxLength = 12
        Me.TxtKhdm.Name = "TxtKhdm"
        Me.TxtKhdm.Size = New System.Drawing.Size(116, 26)
        Me.TxtKhdm.TabIndex = 1
        '
        'LblKhdm
        '
        Me.LblKhdm.AutoSize = True
        Me.LblKhdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblKhdm.Location = New System.Drawing.Point(41, 36)
        Me.LblKhdm.Name = "LblKhdm"
        Me.LblKhdm.Size = New System.Drawing.Size(88, 16)
        Me.LblKhdm.TabIndex = 0
        Me.LblKhdm.Text = "客户编码："
        '
        'FrmOeYpddHx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(294, 179)
        Me.Controls.Add(Me.TxtKhdm)
        Me.Controls.Add(Me.LblKhdm)
        Me.Controls.Add(Me.TxtHth)
        Me.Controls.Add(Me.LblHth)
        Me.Name = "FrmOeYpddHx"
        Me.Text = "样品订单反馈结果输入"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.LblHth, 0)
        Me.Controls.SetChildIndex(Me.TxtHth, 0)
        Me.Controls.SetChildIndex(Me.LblKhdm, 0)
        Me.Controls.SetChildIndex(Me.TxtKhdm, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents TxtHth As System.Windows.Forms.TextBox
    Public WithEvents LblHth As System.Windows.Forms.Label
    Public WithEvents TxtKhdm As System.Windows.Forms.TextBox
    Public WithEvents LblKhdm As System.Windows.Forms.Label
End Class
