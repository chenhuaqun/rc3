<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmZydmGg
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
        Me.TxtNewZymc = New System.Windows.Forms.TextBox
        Me.LblNewZymc = New System.Windows.Forms.Label
        Me.LblNewZydm = New System.Windows.Forms.Label
        Me.TxtNewZydm = New System.Windows.Forms.TextBox
        Me.GrpOldCp = New System.Windows.Forms.GroupBox
        Me.TxtOldZymc = New System.Windows.Forms.TextBox
        Me.LblOldZymc = New System.Windows.Forms.Label
        Me.LblOldZydm = New System.Windows.Forms.Label
        Me.TxtOldZydm = New System.Windows.Forms.TextBox
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
        Me.GrpNewCp.Controls.Add(Me.TxtNewZydm)
        Me.GrpNewCp.Controls.Add(Me.TxtNewZymc)
        Me.GrpNewCp.Controls.Add(Me.LblNewZymc)
        Me.GrpNewCp.Controls.Add(Me.LblNewZydm)
        Me.GrpNewCp.Location = New System.Drawing.Point(34, 102)
        Me.GrpNewCp.Name = "GrpNewCp"
        Me.GrpNewCp.Size = New System.Drawing.Size(400, 84)
        Me.GrpNewCp.TabIndex = 1
        Me.GrpNewCp.TabStop = False
        Me.GrpNewCp.Text = "新职员信息"
        '
        'TxtNewZymc
        '
        Me.TxtNewZymc.Enabled = False
        Me.TxtNewZymc.Location = New System.Drawing.Point(104, 47)
        Me.TxtNewZymc.MaxLength = 40
        Me.TxtNewZymc.Name = "TxtNewZymc"
        Me.TxtNewZymc.Size = New System.Drawing.Size(264, 21)
        Me.TxtNewZymc.TabIndex = 3
        '
        'LblNewZymc
        '
        Me.LblNewZymc.AutoSize = True
        Me.LblNewZymc.Location = New System.Drawing.Point(32, 51)
        Me.LblNewZymc.Name = "LblNewZymc"
        Me.LblNewZymc.Size = New System.Drawing.Size(77, 12)
        Me.LblNewZymc.TabIndex = 2
        Me.LblNewZymc.Text = "职员名称："
        '
        'LblNewZydm
        '
        Me.LblNewZydm.AutoSize = True
        Me.LblNewZydm.Location = New System.Drawing.Point(32, 22)
        Me.LblNewZydm.Name = "LblNewZydm"
        Me.LblNewZydm.Size = New System.Drawing.Size(77, 12)
        Me.LblNewZydm.TabIndex = 0
        Me.LblNewZydm.Text = "职员编码："
        '
        'TxtNewZydm
        '
        Me.TxtNewZydm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNewZydm.Location = New System.Drawing.Point(104, 18)
        Me.TxtNewZydm.MaxLength = 12
        Me.TxtNewZydm.Name = "TxtNewZydm"
        Me.TxtNewZydm.Size = New System.Drawing.Size(100, 21)
        Me.TxtNewZydm.TabIndex = 1
        '
        'GrpOldCp
        '
        Me.GrpOldCp.Controls.Add(Me.TxtOldZydm)
        Me.GrpOldCp.Controls.Add(Me.TxtOldZymc)
        Me.GrpOldCp.Controls.Add(Me.LblOldZymc)
        Me.GrpOldCp.Controls.Add(Me.LblOldZydm)
        Me.GrpOldCp.Location = New System.Drawing.Point(34, 12)
        Me.GrpOldCp.Name = "GrpOldCp"
        Me.GrpOldCp.Size = New System.Drawing.Size(400, 84)
        Me.GrpOldCp.TabIndex = 0
        Me.GrpOldCp.TabStop = False
        Me.GrpOldCp.Text = "原职员信息"
        '
        'TxtOldZymc
        '
        Me.TxtOldZymc.Enabled = False
        Me.TxtOldZymc.Location = New System.Drawing.Point(104, 46)
        Me.TxtOldZymc.MaxLength = 40
        Me.TxtOldZymc.Name = "TxtOldZymc"
        Me.TxtOldZymc.Size = New System.Drawing.Size(264, 21)
        Me.TxtOldZymc.TabIndex = 3
        '
        'LblOldZymc
        '
        Me.LblOldZymc.AutoSize = True
        Me.LblOldZymc.Location = New System.Drawing.Point(32, 50)
        Me.LblOldZymc.Name = "LblOldZymc"
        Me.LblOldZymc.Size = New System.Drawing.Size(77, 12)
        Me.LblOldZymc.TabIndex = 2
        Me.LblOldZymc.Text = "职员名称："
        '
        'LblOldZydm
        '
        Me.LblOldZydm.AutoSize = True
        Me.LblOldZydm.Location = New System.Drawing.Point(32, 21)
        Me.LblOldZydm.Name = "LblOldZydm"
        Me.LblOldZydm.Size = New System.Drawing.Size(77, 12)
        Me.LblOldZydm.TabIndex = 0
        Me.LblOldZydm.Text = "职员编码："
        '
        'TxtOldZydm
        '
        Me.TxtOldZydm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtOldZydm.Location = New System.Drawing.Point(104, 17)
        Me.TxtOldZydm.MaxLength = 12
        Me.TxtOldZydm.Name = "TxtOldZydm"
        Me.TxtOldZydm.Size = New System.Drawing.Size(100, 21)
        Me.TxtOldZydm.TabIndex = 1
        '
        'FrmZydmGg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 245)
        Me.Controls.Add(Me.GrpNewCp)
        Me.Controls.Add(Me.GrpOldCp)
        Me.Name = "FrmZydmGg"
        Me.Text = "职员编码更改与合并"
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
    Friend WithEvents TxtNewZymc As System.Windows.Forms.TextBox
    Friend WithEvents LblNewZymc As System.Windows.Forms.Label
    Friend WithEvents LblNewZydm As System.Windows.Forms.Label
    Friend WithEvents TxtNewZydm As System.Windows.Forms.TextBox
    Friend WithEvents GrpOldCp As System.Windows.Forms.GroupBox
    Friend WithEvents TxtOldZymc As System.Windows.Forms.TextBox
    Friend WithEvents LblOldZymc As System.Windows.Forms.Label
    Friend WithEvents LblOldZydm As System.Windows.Forms.Label
    Friend WithEvents TxtOldZydm As System.Windows.Forms.TextBox
End Class
