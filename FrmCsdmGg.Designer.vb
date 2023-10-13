<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCsdmGg
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
        Me.TxtNewCsmc = New System.Windows.Forms.TextBox
        Me.LblNewCsmc = New System.Windows.Forms.Label
        Me.LblNewCsdm = New System.Windows.Forms.Label
        Me.TxtNewCsdm = New System.Windows.Forms.TextBox
        Me.GrpOldCp = New System.Windows.Forms.GroupBox
        Me.TxtOldCsmc = New System.Windows.Forms.TextBox
        Me.LblOldCsmc = New System.Windows.Forms.Label
        Me.LblOldCsdm = New System.Windows.Forms.Label
        Me.TxtOldCsdm = New System.Windows.Forms.TextBox
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
        Me.GrpNewCp.Controls.Add(Me.TxtNewCsdm)
        Me.GrpNewCp.Controls.Add(Me.TxtNewCsmc)
        Me.GrpNewCp.Controls.Add(Me.LblNewCsmc)
        Me.GrpNewCp.Controls.Add(Me.LblNewCsdm)
        Me.GrpNewCp.Location = New System.Drawing.Point(34, 102)
        Me.GrpNewCp.Name = "GrpNewCp"
        Me.GrpNewCp.Size = New System.Drawing.Size(400, 84)
        Me.GrpNewCp.TabIndex = 1
        Me.GrpNewCp.TabStop = False
        Me.GrpNewCp.Text = "新供应商信息"
        '
        'TxtNewCsmc
        '
        Me.TxtNewCsmc.Enabled = False
        Me.TxtNewCsmc.Location = New System.Drawing.Point(104, 47)
        Me.TxtNewCsmc.MaxLength = 40
        Me.TxtNewCsmc.Name = "TxtNewCsmc"
        Me.TxtNewCsmc.Size = New System.Drawing.Size(264, 21)
        Me.TxtNewCsmc.TabIndex = 3
        '
        'LblNewCsmc
        '
        Me.LblNewCsmc.AutoSize = True
        Me.LblNewCsmc.Location = New System.Drawing.Point(32, 51)
        Me.LblNewCsmc.Name = "LblNewCsmc"
        Me.LblNewCsmc.Size = New System.Drawing.Size(77, 12)
        Me.LblNewCsmc.TabIndex = 2
        Me.LblNewCsmc.Text = "供应商名称："
        '
        'LblNewCsdm
        '
        Me.LblNewCsdm.AutoSize = True
        Me.LblNewCsdm.Location = New System.Drawing.Point(32, 22)
        Me.LblNewCsdm.Name = "LblNewCsdm"
        Me.LblNewCsdm.Size = New System.Drawing.Size(77, 12)
        Me.LblNewCsdm.TabIndex = 0
        Me.LblNewCsdm.Text = "供应商编码："
        '
        'TxtNewCsdm
        '
        Me.TxtNewCsdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNewCsdm.Location = New System.Drawing.Point(104, 18)
        Me.TxtNewCsdm.MaxLength = 12
        Me.TxtNewCsdm.Name = "TxtNewCsdm"
        Me.TxtNewCsdm.Size = New System.Drawing.Size(100, 21)
        Me.TxtNewCsdm.TabIndex = 1
        '
        'GrpOldCp
        '
        Me.GrpOldCp.Controls.Add(Me.TxtOldCsdm)
        Me.GrpOldCp.Controls.Add(Me.TxtOldCsmc)
        Me.GrpOldCp.Controls.Add(Me.LblOldCsmc)
        Me.GrpOldCp.Controls.Add(Me.LblOldCsdm)
        Me.GrpOldCp.Location = New System.Drawing.Point(34, 12)
        Me.GrpOldCp.Name = "GrpOldCp"
        Me.GrpOldCp.Size = New System.Drawing.Size(400, 84)
        Me.GrpOldCp.TabIndex = 0
        Me.GrpOldCp.TabStop = False
        Me.GrpOldCp.Text = "原供应商信息"
        '
        'TxtOldCsmc
        '
        Me.TxtOldCsmc.Enabled = False
        Me.TxtOldCsmc.Location = New System.Drawing.Point(104, 46)
        Me.TxtOldCsmc.MaxLength = 40
        Me.TxtOldCsmc.Name = "TxtOldCsmc"
        Me.TxtOldCsmc.Size = New System.Drawing.Size(264, 21)
        Me.TxtOldCsmc.TabIndex = 3
        '
        'LblOldCsmc
        '
        Me.LblOldCsmc.AutoSize = True
        Me.LblOldCsmc.Location = New System.Drawing.Point(32, 50)
        Me.LblOldCsmc.Name = "LblOldCsmc"
        Me.LblOldCsmc.Size = New System.Drawing.Size(77, 12)
        Me.LblOldCsmc.TabIndex = 2
        Me.LblOldCsmc.Text = "供应商名称："
        '
        'LblOldCsdm
        '
        Me.LblOldCsdm.AutoSize = True
        Me.LblOldCsdm.Location = New System.Drawing.Point(32, 21)
        Me.LblOldCsdm.Name = "LblOldCsdm"
        Me.LblOldCsdm.Size = New System.Drawing.Size(77, 12)
        Me.LblOldCsdm.TabIndex = 0
        Me.LblOldCsdm.Text = "供应商编码："
        '
        'TxtOldCsdm
        '
        Me.TxtOldCsdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtOldCsdm.Location = New System.Drawing.Point(104, 17)
        Me.TxtOldCsdm.MaxLength = 12
        Me.TxtOldCsdm.Name = "TxtOldCsdm"
        Me.TxtOldCsdm.Size = New System.Drawing.Size(100, 21)
        Me.TxtOldCsdm.TabIndex = 1
        '
        'FrmCsdmGg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 245)
        Me.Controls.Add(Me.GrpNewCp)
        Me.Controls.Add(Me.GrpOldCp)
        Me.Name = "FrmCsdmGg"
        Me.Text = "供应商编码更改与合并"
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
    Friend WithEvents TxtNewCsmc As System.Windows.Forms.TextBox
    Friend WithEvents LblNewCsmc As System.Windows.Forms.Label
    Friend WithEvents LblNewCsdm As System.Windows.Forms.Label
    Friend WithEvents TxtNewCsdm As System.Windows.Forms.TextBox
    Friend WithEvents GrpOldCp As System.Windows.Forms.GroupBox
    Friend WithEvents TxtOldCsmc As System.Windows.Forms.TextBox
    Friend WithEvents LblOldCsmc As System.Windows.Forms.Label
    Friend WithEvents LblOldCsdm As System.Windows.Forms.Label
    Friend WithEvents TxtOldCsdm As System.Windows.Forms.TextBox
End Class
