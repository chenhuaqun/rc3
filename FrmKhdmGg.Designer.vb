<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmKhdmGg
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
        Me.GrpNewCp = New System.Windows.Forms.GroupBox
        Me.TxtNewKhmc = New System.Windows.Forms.TextBox
        Me.LblNewKhmc = New System.Windows.Forms.Label
        Me.LblNewKhdm = New System.Windows.Forms.Label
        Me.TxtNewKhdm = New System.Windows.Forms.TextBox
        Me.GrpOldCp = New System.Windows.Forms.GroupBox
        Me.TxtOldKhmc = New System.Windows.Forms.TextBox
        Me.LblOldKhmc = New System.Windows.Forms.Label
        Me.LblOldKhdm = New System.Windows.Forms.Label
        Me.TxtOldKhdm = New System.Windows.Forms.TextBox
        Me.DlgPanel.SuspendLayout()
        Me.GrpNewCp.SuspendLayout()
        Me.GrpOldCp.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(213, 202)
        Me.DlgPanel.TabIndex = 2
        '
        'GrpNewCp
        '
        Me.GrpNewCp.Controls.Add(Me.TxtNewKhmc)
        Me.GrpNewCp.Controls.Add(Me.LblNewKhmc)
        Me.GrpNewCp.Controls.Add(Me.LblNewKhdm)
        Me.GrpNewCp.Controls.Add(Me.TxtNewKhdm)
        Me.GrpNewCp.Location = New System.Drawing.Point(34, 102)
        Me.GrpNewCp.Name = "GrpNewCp"
        Me.GrpNewCp.Size = New System.Drawing.Size(400, 84)
        Me.GrpNewCp.TabIndex = 1
        Me.GrpNewCp.TabStop = False
        Me.GrpNewCp.Text = "新客户信息"
        '
        'TxtNewKhmc
        '
        Me.TxtNewKhmc.Enabled = False
        Me.TxtNewKhmc.Location = New System.Drawing.Point(104, 47)
        Me.TxtNewKhmc.MaxLength = 40
        Me.TxtNewKhmc.Name = "TxtNewKhmc"
        Me.TxtNewKhmc.Size = New System.Drawing.Size(264, 21)
        Me.TxtNewKhmc.TabIndex = 3
        '
        'LblNewKhmc
        '
        Me.LblNewKhmc.AutoSize = True
        Me.LblNewKhmc.Location = New System.Drawing.Point(32, 51)
        Me.LblNewKhmc.Name = "LblNewKhmc"
        Me.LblNewKhmc.Size = New System.Drawing.Size(65, 12)
        Me.LblNewKhmc.TabIndex = 2
        Me.LblNewKhmc.Text = "客户名称："
        '
        'LblNewKhdm
        '
        Me.LblNewKhdm.AutoSize = True
        Me.LblNewKhdm.Location = New System.Drawing.Point(32, 22)
        Me.LblNewKhdm.Name = "LblNewKhdm"
        Me.LblNewKhdm.Size = New System.Drawing.Size(65, 12)
        Me.LblNewKhdm.TabIndex = 0
        Me.LblNewKhdm.Text = "客户编码："
        '
        'TxtNewKhdm
        '
        Me.TxtNewKhdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNewKhdm.Location = New System.Drawing.Point(104, 18)
        Me.TxtNewKhdm.MaxLength = 12
        Me.TxtNewKhdm.Name = "TxtNewKhdm"
        Me.TxtNewKhdm.Size = New System.Drawing.Size(100, 21)
        Me.TxtNewKhdm.TabIndex = 1
        '
        'GrpOldCp
        '
        Me.GrpOldCp.Controls.Add(Me.TxtOldKhmc)
        Me.GrpOldCp.Controls.Add(Me.LblOldKhmc)
        Me.GrpOldCp.Controls.Add(Me.LblOldKhdm)
        Me.GrpOldCp.Controls.Add(Me.TxtOldKhdm)
        Me.GrpOldCp.Location = New System.Drawing.Point(34, 12)
        Me.GrpOldCp.Name = "GrpOldCp"
        Me.GrpOldCp.Size = New System.Drawing.Size(400, 84)
        Me.GrpOldCp.TabIndex = 0
        Me.GrpOldCp.TabStop = False
        Me.GrpOldCp.Text = "原客户信息"
        '
        'TxtOldKhmc
        '
        Me.TxtOldKhmc.Enabled = False
        Me.TxtOldKhmc.Location = New System.Drawing.Point(104, 46)
        Me.TxtOldKhmc.MaxLength = 40
        Me.TxtOldKhmc.Name = "TxtOldKhmc"
        Me.TxtOldKhmc.Size = New System.Drawing.Size(264, 21)
        Me.TxtOldKhmc.TabIndex = 3
        '
        'LblOldKhmc
        '
        Me.LblOldKhmc.AutoSize = True
        Me.LblOldKhmc.Location = New System.Drawing.Point(32, 50)
        Me.LblOldKhmc.Name = "LblOldKhmc"
        Me.LblOldKhmc.Size = New System.Drawing.Size(65, 12)
        Me.LblOldKhmc.TabIndex = 2
        Me.LblOldKhmc.Text = "客户名称："
        '
        'LblOldKhdm
        '
        Me.LblOldKhdm.AutoSize = True
        Me.LblOldKhdm.Location = New System.Drawing.Point(32, 21)
        Me.LblOldKhdm.Name = "LblOldKhdm"
        Me.LblOldKhdm.Size = New System.Drawing.Size(65, 12)
        Me.LblOldKhdm.TabIndex = 0
        Me.LblOldKhdm.Text = "客户编码："
        '
        'TxtOldKhdm
        '
        Me.TxtOldKhdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtOldKhdm.Location = New System.Drawing.Point(104, 17)
        Me.TxtOldKhdm.MaxLength = 12
        Me.TxtOldKhdm.Name = "TxtOldKhdm"
        Me.TxtOldKhdm.Size = New System.Drawing.Size(100, 21)
        Me.TxtOldKhdm.TabIndex = 1
        '
        'FrmKhdmGg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 245)
        Me.Controls.Add(Me.GrpNewCp)
        Me.Controls.Add(Me.GrpOldCp)
        Me.Name = "FrmKhdmGg"
        Me.Text = "客户编码更改与合并"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.GrpOldCp, 0)
        Me.Controls.SetChildIndex(Me.GrpNewCp, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.GrpNewCp.ResumeLayout(False)
        Me.GrpNewCp.PerformLayout()
        Me.GrpOldCp.ResumeLayout(False)
        Me.GrpOldCp.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpNewCp As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNewKhmc As System.Windows.Forms.TextBox
    Friend WithEvents LblNewKhmc As System.Windows.Forms.Label
    Friend WithEvents LblNewKhdm As System.Windows.Forms.Label
    Friend WithEvents TxtNewKhdm As System.Windows.Forms.TextBox
    Friend WithEvents GrpOldCp As System.Windows.Forms.GroupBox
    Friend WithEvents TxtOldKhmc As System.Windows.Forms.TextBox
    Friend WithEvents LblOldKhmc As System.Windows.Forms.Label
    Friend WithEvents LblOldKhdm As System.Windows.Forms.Label
    Friend WithEvents TxtOldKhdm As System.Windows.Forms.TextBox
End Class
