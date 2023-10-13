<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUserEdit
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LblDwdm = New System.Windows.Forms.Label()
        Me.TxtDwdm = New System.Windows.Forms.TextBox()
        Me.LblAccount = New System.Windows.Forms.Label()
        Me.LblDspName = New System.Windows.Forms.Label()
        Me.TxtAccount = New System.Windows.Forms.TextBox()
        Me.TxtDspName = New System.Windows.Forms.TextBox()
        Me.DlgPanel.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(128, 207)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LblDwdm)
        Me.GroupBox2.Controls.Add(Me.TxtDwdm)
        Me.GroupBox2.Controls.Add(Me.LblAccount)
        Me.GroupBox2.Controls.Add(Me.LblDspName)
        Me.GroupBox2.Controls.Add(Me.TxtAccount)
        Me.GroupBox2.Controls.Add(Me.TxtDspName)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 18)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(516, 168)
        Me.GroupBox2.TabIndex = 102
        Me.GroupBox2.TabStop = False
        '
        'LblDwdm
        '
        Me.LblDwdm.AutoSize = True
        Me.LblDwdm.Location = New System.Drawing.Point(48, 108)
        Me.LblDwdm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDwdm.Name = "LblDwdm"
        Me.LblDwdm.Size = New System.Drawing.Size(98, 18)
        Me.LblDwdm.TabIndex = 8
        Me.LblDwdm.Text = "所属单位："
        '
        'TxtDwdm
        '
        Me.TxtDwdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDwdm.Location = New System.Drawing.Point(156, 108)
        Me.TxtDwdm.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtDwdm.MaxLength = 30
        Me.TxtDwdm.Name = "TxtDwdm"
        Me.TxtDwdm.Size = New System.Drawing.Size(190, 28)
        Me.TxtDwdm.TabIndex = 9
        '
        'LblAccount
        '
        Me.LblAccount.AutoSize = True
        Me.LblAccount.Location = New System.Drawing.Point(48, 36)
        Me.LblAccount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblAccount.Name = "LblAccount"
        Me.LblAccount.Size = New System.Drawing.Size(98, 18)
        Me.LblAccount.TabIndex = 0
        Me.LblAccount.Text = "登陆账号："
        '
        'LblDspName
        '
        Me.LblDspName.AutoSize = True
        Me.LblDspName.Location = New System.Drawing.Point(48, 72)
        Me.LblDspName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDspName.Name = "LblDspName"
        Me.LblDspName.Size = New System.Drawing.Size(98, 18)
        Me.LblDspName.TabIndex = 2
        Me.LblDspName.Text = "全    名："
        '
        'TxtAccount
        '
        Me.TxtAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAccount.Enabled = False
        Me.TxtAccount.Location = New System.Drawing.Point(156, 36)
        Me.TxtAccount.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtAccount.MaxLength = 30
        Me.TxtAccount.Name = "TxtAccount"
        Me.TxtAccount.Size = New System.Drawing.Size(310, 28)
        Me.TxtAccount.TabIndex = 1
        '
        'TxtDspName
        '
        Me.TxtDspName.Location = New System.Drawing.Point(156, 72)
        Me.TxtDspName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtDspName.MaxLength = 30
        Me.TxtDspName.Name = "TxtDspName"
        Me.TxtDspName.Size = New System.Drawing.Size(310, 28)
        Me.TxtDspName.TabIndex = 3
        '
        'FrmUserEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 271)
        Me.Controls.Add(Me.GroupBox2)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FrmUserEdit"
        Me.Text = "修改操作员"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LblDwdm As System.Windows.Forms.Label
    Friend WithEvents TxtDwdm As System.Windows.Forms.TextBox
    Friend WithEvents LblAccount As System.Windows.Forms.Label
    Friend WithEvents LblDspName As System.Windows.Forms.Label
    Friend WithEvents TxtAccount As System.Windows.Forms.TextBox
    Friend WithEvents TxtDspName As System.Windows.Forms.TextBox
End Class
