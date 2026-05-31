<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRegister
    Inherits System.Windows.Forms.Form

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
        Me.gbRegister = New System.Windows.Forms.GroupBox()
        Me.btnRegister = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbActivate = New System.Windows.Forms.GroupBox()
        Me.lblActivationTime = New System.Windows.Forms.Label()
        Me.btnActivate = New System.Windows.Forms.Button()
        Me.txtLicenseKey = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDeviceCodeActivate = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LinkLabelRegister = New System.Windows.Forms.LinkLabel()
        Me.gbRegister.SuspendLayout()
        Me.gbActivate.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbRegister
        '
        Me.gbRegister.Controls.Add(Me.btnRegister)
        Me.gbRegister.Controls.Add(Me.txtPassword)
        Me.gbRegister.Controls.Add(Me.Label2)
        Me.gbRegister.Controls.Add(Me.txtEmail)
        Me.gbRegister.Controls.Add(Me.Label1)
        Me.gbRegister.Location = New System.Drawing.Point(12, 128)
        Me.gbRegister.Name = "gbRegister"
        Me.gbRegister.Size = New System.Drawing.Size(446, 152)
        Me.gbRegister.TabIndex = 0
        Me.gbRegister.TabStop = False
        Me.gbRegister.Text = "产品注册"
        '
        'btnRegister
        '
        Me.btnRegister.Location = New System.Drawing.Point(320, 108)
        Me.btnRegister.Name = "btnRegister"
        Me.btnRegister.Size = New System.Drawing.Size(75, 23)
        Me.btnRegister.TabIndex = 4
        Me.btnRegister.Text = "注册"
        Me.btnRegister.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(117, 71)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(278, 21)
        Me.txtPassword.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "登录密码："
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(117, 35)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(278, 21)
        Me.txtEmail.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "登录邮箱："
        '
        'gbActivate
        '
        Me.gbActivate.Controls.Add(Me.lblActivationTime)
        Me.gbActivate.Controls.Add(Me.btnActivate)
        Me.gbActivate.Controls.Add(Me.txtLicenseKey)
        Me.gbActivate.Controls.Add(Me.Label3)
        Me.gbActivate.Location = New System.Drawing.Point(14, 286)
        Me.gbActivate.Name = "gbActivate"
        Me.gbActivate.Size = New System.Drawing.Size(446, 91)
        Me.gbActivate.TabIndex = 1
        Me.gbActivate.TabStop = False
        Me.gbActivate.Text = "产品激活"
        '
        'lblActivationTime
        '
        Me.lblActivationTime.AutoSize = True
        Me.lblActivationTime.Location = New System.Drawing.Point(36, 64)
        Me.lblActivationTime.Name = "lblActivationTime"
        Me.lblActivationTime.Size = New System.Drawing.Size(65, 12)
        Me.lblActivationTime.TabIndex = 5
        Me.lblActivationTime.Text = "激活时间："
        '
        'btnActivate
        '
        Me.btnActivate.Location = New System.Drawing.Point(318, 30)
        Me.btnActivate.Name = "btnActivate"
        Me.btnActivate.Size = New System.Drawing.Size(75, 23)
        Me.btnActivate.TabIndex = 4
        Me.btnActivate.Text = "激活"
        Me.btnActivate.UseVisualStyleBackColor = True
        '
        'txtLicenseKey
        '
        Me.txtLicenseKey.Location = New System.Drawing.Point(117, 30)
        Me.txtLicenseKey.Name = "txtLicenseKey"
        Me.txtLicenseKey.Size = New System.Drawing.Size(189, 21)
        Me.txtLicenseKey.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "许可证密钥："
        '
        'txtDeviceCodeActivate
        '
        Me.txtDeviceCodeActivate.Location = New System.Drawing.Point(129, 73)
        Me.txtDeviceCodeActivate.Multiline = True
        Me.txtDeviceCodeActivate.Name = "txtDeviceCodeActivate"
        Me.txtDeviceCodeActivate.ReadOnly = True
        Me.txtDeviceCodeActivate.Size = New System.Drawing.Size(278, 49)
        Me.txtDeviceCodeActivate.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(48, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 12)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "本机设备码："
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LinkLabelRegister)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(446, 55)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "账号注册"
        '
        'LinkLabelRegister
        '
        Me.LinkLabelRegister.AutoSize = True
        Me.LinkLabelRegister.Location = New System.Drawing.Point(36, 27)
        Me.LinkLabelRegister.Name = "LinkLabelRegister"
        Me.LinkLabelRegister.Size = New System.Drawing.Size(125, 12)
        Me.LinkLabelRegister.TabIndex = 0
        Me.LinkLabelRegister.TabStop = True
        Me.LinkLabelRegister.Text = "还没有账号？立即注册"
        '
        'FrmRegister
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(472, 389)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbActivate)
        Me.Controls.Add(Me.gbRegister)
        Me.Controls.Add(Me.txtDeviceCodeActivate)
        Me.Controls.Add(Me.Label4)
        Me.Name = "FrmRegister"
        Me.Text = "注册与激活"
        Me.gbRegister.ResumeLayout(False)
        Me.gbRegister.PerformLayout()
        Me.gbActivate.ResumeLayout(False)
        Me.gbActivate.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gbRegister As GroupBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnRegister As Button
    Friend WithEvents gbActivate As GroupBox
    Friend WithEvents btnActivate As Button
    Friend WithEvents txtLicenseKey As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtDeviceCodeActivate As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LinkLabelRegister As LinkLabel
    Friend WithEvents lblActivationTime As Label
End Class
