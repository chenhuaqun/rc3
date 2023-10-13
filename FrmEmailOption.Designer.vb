<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEmailOption
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblSmtp = New System.Windows.Forms.Label
        Me.TxtEmail = New System.Windows.Forms.TextBox
        Me.TxtSmtp = New System.Windows.Forms.TextBox
        Me.ChbSfyz = New System.Windows.Forms.CheckBox
        Me.TxtPwd = New System.Windows.Forms.TextBox
        Me.TxtAccount = New System.Windows.Forms.TextBox
        Me.LblPwd = New System.Windows.Forms.Label
        Me.LblAccount = New System.Windows.Forms.Label
        Me.DlgPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(296, 268)
        Me.DlgPanel.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(73, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "电子邮件地址："
        '
        'LblSmtp
        '
        Me.LblSmtp.AutoSize = True
        Me.LblSmtp.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblSmtp.Location = New System.Drawing.Point(89, 85)
        Me.LblSmtp.Name = "LblSmtp"
        Me.LblSmtp.Size = New System.Drawing.Size(104, 16)
        Me.LblSmtp.TabIndex = 2
        Me.LblSmtp.Text = "SMTP服务器："
        '
        'TxtEmail
        '
        Me.TxtEmail.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtEmail.Location = New System.Drawing.Point(198, 38)
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(258, 26)
        Me.TxtEmail.TabIndex = 1
        '
        'TxtSmtp
        '
        Me.TxtSmtp.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtSmtp.Location = New System.Drawing.Point(198, 80)
        Me.TxtSmtp.Name = "TxtSmtp"
        Me.TxtSmtp.Size = New System.Drawing.Size(258, 26)
        Me.TxtSmtp.TabIndex = 3
        '
        'ChbSfyz
        '
        Me.ChbSfyz.AutoSize = True
        Me.ChbSfyz.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ChbSfyz.Location = New System.Drawing.Point(198, 122)
        Me.ChbSfyz.Name = "ChbSfyz"
        Me.ChbSfyz.Size = New System.Drawing.Size(155, 20)
        Me.ChbSfyz.TabIndex = 4
        Me.ChbSfyz.Text = "是否需要身份验证"
        Me.ChbSfyz.UseVisualStyleBackColor = True
        '
        'TxtPwd
        '
        Me.TxtPwd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtPwd.Location = New System.Drawing.Point(198, 200)
        Me.TxtPwd.Name = "TxtPwd"
        Me.TxtPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPwd.Size = New System.Drawing.Size(186, 26)
        Me.TxtPwd.TabIndex = 8
        '
        'TxtAccount
        '
        Me.TxtAccount.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtAccount.Location = New System.Drawing.Point(198, 158)
        Me.TxtAccount.Name = "TxtAccount"
        Me.TxtAccount.Size = New System.Drawing.Size(186, 26)
        Me.TxtAccount.TabIndex = 6
        '
        'LblPwd
        '
        Me.LblPwd.AutoSize = True
        Me.LblPwd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblPwd.Location = New System.Drawing.Point(137, 205)
        Me.LblPwd.Name = "LblPwd"
        Me.LblPwd.Size = New System.Drawing.Size(56, 16)
        Me.LblPwd.TabIndex = 7
        Me.LblPwd.Text = "密码："
        '
        'LblAccount
        '
        Me.LblAccount.AutoSize = True
        Me.LblAccount.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblAccount.Location = New System.Drawing.Point(137, 163)
        Me.LblAccount.Name = "LblAccount"
        Me.LblAccount.Size = New System.Drawing.Size(56, 16)
        Me.LblAccount.TabIndex = 5
        Me.LblAccount.Text = "帐号："
        '
        'FrmEmailOption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(549, 311)
        Me.Controls.Add(Me.TxtPwd)
        Me.Controls.Add(Me.TxtAccount)
        Me.Controls.Add(Me.LblPwd)
        Me.Controls.Add(Me.LblAccount)
        Me.Controls.Add(Me.ChbSfyz)
        Me.Controls.Add(Me.TxtSmtp)
        Me.Controls.Add(Me.TxtEmail)
        Me.Controls.Add(Me.LblSmtp)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmEmailOption"
        Me.Text = "发件人电子邮件参数设置"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.LblSmtp, 0)
        Me.Controls.SetChildIndex(Me.TxtEmail, 0)
        Me.Controls.SetChildIndex(Me.TxtSmtp, 0)
        Me.Controls.SetChildIndex(Me.ChbSfyz, 0)
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.LblAccount, 0)
        Me.Controls.SetChildIndex(Me.LblPwd, 0)
        Me.Controls.SetChildIndex(Me.TxtAccount, 0)
        Me.Controls.SetChildIndex(Me.TxtPwd, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblSmtp As System.Windows.Forms.Label
    Friend WithEvents TxtEmail As System.Windows.Forms.TextBox
    Friend WithEvents TxtSmtp As System.Windows.Forms.TextBox
    Friend WithEvents ChbSfyz As System.Windows.Forms.CheckBox
    Friend WithEvents TxtPwd As System.Windows.Forms.TextBox
    Friend WithEvents TxtAccount As System.Windows.Forms.TextBox
    Friend WithEvents LblPwd As System.Windows.Forms.Label
    Friend WithEvents LblAccount As System.Windows.Forms.Label
End Class
