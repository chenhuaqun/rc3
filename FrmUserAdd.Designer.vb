<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUserAdd
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
        Me.LblDwdm = New System.Windows.Forms.Label
        Me.TxtDwdm = New System.Windows.Forms.TextBox
        Me.TxtPWDConfirm = New System.Windows.Forms.TextBox
        Me.LblPWDConfirm = New System.Windows.Forms.Label
        Me.LblPWD = New System.Windows.Forms.Label
        Me.TxtPWD = New System.Windows.Forms.TextBox
        Me.LblAccount = New System.Windows.Forms.Label
        Me.LblDspName = New System.Windows.Forms.Label
        Me.TxtAccount = New System.Windows.Forms.TextBox
        Me.TxtDspName = New System.Windows.Forms.TextBox
        Me.DlgPanel.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(116, 176)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LblDwdm)
        Me.GroupBox2.Controls.Add(Me.TxtDwdm)
        Me.GroupBox2.Controls.Add(Me.TxtPWDConfirm)
        Me.GroupBox2.Controls.Add(Me.LblPWDConfirm)
        Me.GroupBox2.Controls.Add(Me.LblPWD)
        Me.GroupBox2.Controls.Add(Me.TxtPWD)
        Me.GroupBox2.Controls.Add(Me.LblAccount)
        Me.GroupBox2.Controls.Add(Me.LblDspName)
        Me.GroupBox2.Controls.Add(Me.TxtAccount)
        Me.GroupBox2.Controls.Add(Me.TxtDspName)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 9)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(344, 152)
        Me.GroupBox2.TabIndex = 102
        Me.GroupBox2.TabStop = False
        '
        'LblDwdm
        '
        Me.LblDwdm.AutoSize = True
        Me.LblDwdm.Location = New System.Drawing.Point(32, 120)
        Me.LblDwdm.Name = "LblDwdm"
        Me.LblDwdm.Size = New System.Drawing.Size(65, 12)
        Me.LblDwdm.TabIndex = 8
        Me.LblDwdm.Text = "所属单位："
        '
        'TxtDwdm
        '
        Me.TxtDwdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDwdm.Location = New System.Drawing.Point(104, 120)
        Me.TxtDwdm.MaxLength = 30
        Me.TxtDwdm.Name = "TxtDwdm"
        Me.TxtDwdm.Size = New System.Drawing.Size(128, 21)
        Me.TxtDwdm.TabIndex = 9
        '
        'TxtPWDConfirm
        '
        Me.TxtPWDConfirm.Location = New System.Drawing.Point(104, 96)
        Me.TxtPWDConfirm.MaxLength = 20
        Me.TxtPWDConfirm.Name = "TxtPWDConfirm"
        Me.TxtPWDConfirm.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPWDConfirm.Size = New System.Drawing.Size(128, 21)
        Me.TxtPWDConfirm.TabIndex = 7
        '
        'LblPWDConfirm
        '
        Me.LblPWDConfirm.AutoSize = True
        Me.LblPWDConfirm.Location = New System.Drawing.Point(32, 96)
        Me.LblPWDConfirm.Name = "LblPWDConfirm"
        Me.LblPWDConfirm.Size = New System.Drawing.Size(65, 12)
        Me.LblPWDConfirm.TabIndex = 6
        Me.LblPWDConfirm.Text = "密码确认："
        '
        'LblPWD
        '
        Me.LblPWD.AutoSize = True
        Me.LblPWD.Location = New System.Drawing.Point(32, 72)
        Me.LblPWD.Name = "LblPWD"
        Me.LblPWD.Size = New System.Drawing.Size(65, 12)
        Me.LblPWD.TabIndex = 4
        Me.LblPWD.Text = "密    码："
        '
        'TxtPWD
        '
        Me.TxtPWD.Location = New System.Drawing.Point(104, 72)
        Me.TxtPWD.MaxLength = 20
        Me.TxtPWD.Name = "TxtPWD"
        Me.TxtPWD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPWD.Size = New System.Drawing.Size(128, 21)
        Me.TxtPWD.TabIndex = 5
        '
        'LblAccount
        '
        Me.LblAccount.AutoSize = True
        Me.LblAccount.Location = New System.Drawing.Point(32, 24)
        Me.LblAccount.Name = "LblAccount"
        Me.LblAccount.Size = New System.Drawing.Size(65, 12)
        Me.LblAccount.TabIndex = 0
        Me.LblAccount.Text = "登陆账号："
        '
        'LblDspName
        '
        Me.LblDspName.AutoSize = True
        Me.LblDspName.Location = New System.Drawing.Point(32, 48)
        Me.LblDspName.Name = "LblDspName"
        Me.LblDspName.Size = New System.Drawing.Size(65, 12)
        Me.LblDspName.TabIndex = 2
        Me.LblDspName.Text = "全    名："
        '
        'TxtAccount
        '
        Me.TxtAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAccount.Location = New System.Drawing.Point(104, 24)
        Me.TxtAccount.MaxLength = 30
        Me.TxtAccount.Name = "TxtAccount"
        Me.TxtAccount.Size = New System.Drawing.Size(208, 21)
        Me.TxtAccount.TabIndex = 1
        '
        'TxtDspName
        '
        Me.TxtDspName.Location = New System.Drawing.Point(104, 48)
        Me.TxtDspName.MaxLength = 30
        Me.TxtDspName.Name = "TxtDspName"
        Me.TxtDspName.Size = New System.Drawing.Size(208, 21)
        Me.TxtDspName.TabIndex = 3
        '
        'FrmUserAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(369, 219)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "FrmUserAdd"
        Me.Text = "增加操作员"
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
    Public WithEvents TxtPWDConfirm As System.Windows.Forms.TextBox
    Public WithEvents LblPWDConfirm As System.Windows.Forms.Label
    Friend WithEvents LblPWD As System.Windows.Forms.Label
    Friend WithEvents TxtPWD As System.Windows.Forms.TextBox
    Friend WithEvents LblAccount As System.Windows.Forms.Label
    Friend WithEvents LblDspName As System.Windows.Forms.Label
    Friend WithEvents TxtAccount As System.Windows.Forms.TextBox
    Friend WithEvents TxtDspName As System.Windows.Forms.TextBox
End Class
