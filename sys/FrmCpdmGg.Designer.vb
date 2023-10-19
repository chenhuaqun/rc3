<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCpdmGg
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
        Me.TxtNewCpmc = New System.Windows.Forms.TextBox
        Me.LblNewCpmc = New System.Windows.Forms.Label
        Me.TxtNewDw = New System.Windows.Forms.TextBox
        Me.LblNewDw = New System.Windows.Forms.Label
        Me.LblNewCpdm = New System.Windows.Forms.Label
        Me.TxtNewCpdm = New System.Windows.Forms.TextBox
        Me.GrpOldCp = New System.Windows.Forms.GroupBox
        Me.TxtOldDw = New System.Windows.Forms.TextBox
        Me.LblOldDw = New System.Windows.Forms.Label
        Me.TxtOldCpmc = New System.Windows.Forms.TextBox
        Me.LblOldCpmc = New System.Windows.Forms.Label
        Me.LblOldCpdm = New System.Windows.Forms.Label
        Me.TxtOldCpdm = New System.Windows.Forms.TextBox
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
        Me.DlgPanel.Location = New System.Drawing.Point(213, 263)
        Me.DlgPanel.TabIndex = 2
        '
        'GrpNewCp
        '
        Me.GrpNewCp.Controls.Add(Me.TxtNewCpmc)
        Me.GrpNewCp.Controls.Add(Me.LblNewCpmc)
        Me.GrpNewCp.Controls.Add(Me.TxtNewDw)
        Me.GrpNewCp.Controls.Add(Me.LblNewDw)
        Me.GrpNewCp.Controls.Add(Me.LblNewCpdm)
        Me.GrpNewCp.Controls.Add(Me.TxtNewCpdm)
        Me.GrpNewCp.Location = New System.Drawing.Point(34, 132)
        Me.GrpNewCp.Name = "GrpNewCp"
        Me.GrpNewCp.Size = New System.Drawing.Size(400, 112)
        Me.GrpNewCp.TabIndex = 1
        Me.GrpNewCp.TabStop = False
        Me.GrpNewCp.Text = "新物料信息"
        '
        'TxtNewCpmc
        '
        Me.TxtNewCpmc.Enabled = False
        Me.TxtNewCpmc.Location = New System.Drawing.Point(104, 47)
        Me.TxtNewCpmc.MaxLength = 40
        Me.TxtNewCpmc.Name = "TxtNewCpmc"
        Me.TxtNewCpmc.Size = New System.Drawing.Size(264, 21)
        Me.TxtNewCpmc.TabIndex = 3
        '
        'LblNewCpmc
        '
        Me.LblNewCpmc.AutoSize = True
        Me.LblNewCpmc.Location = New System.Drawing.Point(32, 51)
        Me.LblNewCpmc.Name = "LblNewCpmc"
        Me.LblNewCpmc.Size = New System.Drawing.Size(65, 12)
        Me.LblNewCpmc.TabIndex = 2
        Me.LblNewCpmc.Text = "物料描述："
        '
        'TxtNewDw
        '
        Me.TxtNewDw.Enabled = False
        Me.TxtNewDw.Location = New System.Drawing.Point(103, 76)
        Me.TxtNewDw.MaxLength = 12
        Me.TxtNewDw.Name = "TxtNewDw"
        Me.TxtNewDw.Size = New System.Drawing.Size(72, 21)
        Me.TxtNewDw.TabIndex = 9
        '
        'LblNewDw
        '
        Me.LblNewDw.AutoSize = True
        Me.LblNewDw.Location = New System.Drawing.Point(32, 80)
        Me.LblNewDw.Name = "LblNewDw"
        Me.LblNewDw.Size = New System.Drawing.Size(65, 12)
        Me.LblNewDw.TabIndex = 8
        Me.LblNewDw.Text = "单    位："
        '
        'LblNewCpdm
        '
        Me.LblNewCpdm.AutoSize = True
        Me.LblNewCpdm.Location = New System.Drawing.Point(32, 22)
        Me.LblNewCpdm.Name = "LblNewCpdm"
        Me.LblNewCpdm.Size = New System.Drawing.Size(65, 12)
        Me.LblNewCpdm.TabIndex = 0
        Me.LblNewCpdm.Text = "物料编码："
        '
        'TxtNewCpdm
        '
        Me.TxtNewCpdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNewCpdm.Location = New System.Drawing.Point(104, 18)
        Me.TxtNewCpdm.MaxLength = 12
        Me.TxtNewCpdm.Name = "TxtNewCpdm"
        Me.TxtNewCpdm.Size = New System.Drawing.Size(100, 21)
        Me.TxtNewCpdm.TabIndex = 1
        '
        'GrpOldCp
        '
        Me.GrpOldCp.Controls.Add(Me.TxtOldDw)
        Me.GrpOldCp.Controls.Add(Me.LblOldDw)
        Me.GrpOldCp.Controls.Add(Me.TxtOldCpmc)
        Me.GrpOldCp.Controls.Add(Me.LblOldCpmc)
        Me.GrpOldCp.Controls.Add(Me.LblOldCpdm)
        Me.GrpOldCp.Controls.Add(Me.TxtOldCpdm)
        Me.GrpOldCp.Location = New System.Drawing.Point(34, 12)
        Me.GrpOldCp.Name = "GrpOldCp"
        Me.GrpOldCp.Size = New System.Drawing.Size(400, 107)
        Me.GrpOldCp.TabIndex = 0
        Me.GrpOldCp.TabStop = False
        Me.GrpOldCp.Text = "原物料信息"
        '
        'TxtOldDw
        '
        Me.TxtOldDw.Enabled = False
        Me.TxtOldDw.Location = New System.Drawing.Point(104, 75)
        Me.TxtOldDw.MaxLength = 12
        Me.TxtOldDw.Name = "TxtOldDw"
        Me.TxtOldDw.Size = New System.Drawing.Size(72, 21)
        Me.TxtOldDw.TabIndex = 9
        '
        'LblOldDw
        '
        Me.LblOldDw.AutoSize = True
        Me.LblOldDw.Location = New System.Drawing.Point(32, 79)
        Me.LblOldDw.Name = "LblOldDw"
        Me.LblOldDw.Size = New System.Drawing.Size(65, 12)
        Me.LblOldDw.TabIndex = 8
        Me.LblOldDw.Text = "单    位："
        '
        'TxtOldCpmc
        '
        Me.TxtOldCpmc.Enabled = False
        Me.TxtOldCpmc.Location = New System.Drawing.Point(104, 46)
        Me.TxtOldCpmc.MaxLength = 40
        Me.TxtOldCpmc.Name = "TxtOldCpmc"
        Me.TxtOldCpmc.Size = New System.Drawing.Size(264, 21)
        Me.TxtOldCpmc.TabIndex = 3
        '
        'LblOldCpmc
        '
        Me.LblOldCpmc.AutoSize = True
        Me.LblOldCpmc.Location = New System.Drawing.Point(32, 50)
        Me.LblOldCpmc.Name = "LblOldCpmc"
        Me.LblOldCpmc.Size = New System.Drawing.Size(65, 12)
        Me.LblOldCpmc.TabIndex = 2
        Me.LblOldCpmc.Text = "物料描述："
        '
        'LblOldCpdm
        '
        Me.LblOldCpdm.AutoSize = True
        Me.LblOldCpdm.Location = New System.Drawing.Point(32, 21)
        Me.LblOldCpdm.Name = "LblOldCpdm"
        Me.LblOldCpdm.Size = New System.Drawing.Size(65, 12)
        Me.LblOldCpdm.TabIndex = 0
        Me.LblOldCpdm.Text = "物料编码："
        '
        'TxtOldCpdm
        '
        Me.TxtOldCpdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtOldCpdm.Location = New System.Drawing.Point(104, 17)
        Me.TxtOldCpdm.MaxLength = 12
        Me.TxtOldCpdm.Name = "TxtOldCpdm"
        Me.TxtOldCpdm.Size = New System.Drawing.Size(100, 21)
        Me.TxtOldCpdm.TabIndex = 1
        '
        'FrmCpdmGg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 306)
        Me.Controls.Add(Me.GrpNewCp)
        Me.Controls.Add(Me.GrpOldCp)
        Me.Name = "FrmCpdmGg"
        Me.Text = "物料编码更改与合并"
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
    Friend WithEvents TxtNewCpmc As System.Windows.Forms.TextBox
    Friend WithEvents LblNewCpmc As System.Windows.Forms.Label
    Friend WithEvents TxtNewDw As System.Windows.Forms.TextBox
    Friend WithEvents LblNewDw As System.Windows.Forms.Label
    Friend WithEvents LblNewCpdm As System.Windows.Forms.Label
    Friend WithEvents TxtNewCpdm As System.Windows.Forms.TextBox
    Friend WithEvents GrpOldCp As System.Windows.Forms.GroupBox
    Friend WithEvents TxtOldCpmc As System.Windows.Forms.TextBox
    Friend WithEvents LblOldCpmc As System.Windows.Forms.Label
    Friend WithEvents TxtOldDw As System.Windows.Forms.TextBox
    Friend WithEvents LblOldDw As System.Windows.Forms.Label
    Friend WithEvents LblOldCpdm As System.Windows.Forms.Label
    Friend WithEvents TxtOldCpdm As System.Windows.Forms.TextBox
End Class
