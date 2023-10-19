<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmKczlFaEdit
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.LblFasm = New System.Windows.Forms.Label
        Me.TxtFasm = New System.Windows.Forms.TextBox
        Me.LblFadm = New System.Windows.Forms.Label
        Me.LblFamc = New System.Windows.Forms.Label
        Me.TxtFadm = New System.Windows.Forms.TextBox
        Me.TxtFamc = New System.Windows.Forms.TextBox
        Me.DlgPanel.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(116, 146)
        Me.DlgPanel.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LblFasm)
        Me.GroupBox2.Controls.Add(Me.TxtFasm)
        Me.GroupBox2.Controls.Add(Me.LblFadm)
        Me.GroupBox2.Controls.Add(Me.LblFamc)
        Me.GroupBox2.Controls.Add(Me.TxtFadm)
        Me.GroupBox2.Controls.Add(Me.TxtFamc)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(344, 116)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'LblFasm
        '
        Me.LblFasm.AutoSize = True
        Me.LblFasm.Location = New System.Drawing.Point(32, 86)
        Me.LblFasm.Name = "LblFasm"
        Me.LblFasm.Size = New System.Drawing.Size(65, 12)
        Me.LblFasm.TabIndex = 4
        Me.LblFasm.Text = "记 忆 码："
        '
        'TxtFasm
        '
        Me.TxtFasm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFasm.Location = New System.Drawing.Point(104, 82)
        Me.TxtFasm.MaxLength = 12
        Me.TxtFasm.Name = "TxtFasm"
        Me.TxtFasm.Size = New System.Drawing.Size(94, 21)
        Me.TxtFasm.TabIndex = 5
        '
        'LblFadm
        '
        Me.LblFadm.AutoSize = True
        Me.LblFadm.Location = New System.Drawing.Point(32, 28)
        Me.LblFadm.Name = "LblFadm"
        Me.LblFadm.Size = New System.Drawing.Size(65, 12)
        Me.LblFadm.TabIndex = 0
        Me.LblFadm.Text = "方案编码："
        '
        'LblFamc
        '
        Me.LblFamc.AutoSize = True
        Me.LblFamc.Location = New System.Drawing.Point(32, 57)
        Me.LblFamc.Name = "LblFamc"
        Me.LblFamc.Size = New System.Drawing.Size(65, 12)
        Me.LblFamc.TabIndex = 2
        Me.LblFamc.Text = "方案名称："
        '
        'TxtFadm
        '
        Me.TxtFadm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFadm.Enabled = False
        Me.TxtFadm.Location = New System.Drawing.Point(104, 24)
        Me.TxtFadm.MaxLength = 12
        Me.TxtFadm.Name = "TxtFadm"
        Me.TxtFadm.Size = New System.Drawing.Size(94, 21)
        Me.TxtFadm.TabIndex = 1
        '
        'TxtFamc
        '
        Me.TxtFamc.Location = New System.Drawing.Point(104, 53)
        Me.TxtFamc.MaxLength = 30
        Me.TxtFamc.Name = "TxtFamc"
        Me.TxtFamc.Size = New System.Drawing.Size(208, 21)
        Me.TxtFamc.TabIndex = 3
        '
        'FrmKczlFaEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(369, 189)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "FrmKczlFaEdit"
        Me.Text = "库存账龄方案编辑"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LblFasm As System.Windows.Forms.Label
    Friend WithEvents TxtFasm As System.Windows.Forms.TextBox
    Friend WithEvents LblFadm As System.Windows.Forms.Label
    Friend WithEvents LblFamc As System.Windows.Forms.Label
    Friend WithEvents TxtFadm As System.Windows.Forms.TextBox
    Friend WithEvents TxtFamc As System.Windows.Forms.TextBox
End Class
