<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmUserLogin
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DtpKjrq = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LblDwmc = New System.Windows.Forms.Label()
        Me.LblYtdm = New System.Windows.Forms.Label()
        Me.LblYtmc = New System.Windows.Forms.Label()
        Me.TxtUser_Account = New System.Windows.Forms.TextBox()
        Me.TxtUser_PWD = New System.Windows.Forms.TextBox()
        Me.CmbDwmc = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnOk = New System.Windows.Forms.Button()
        Me.BtnHelp = New System.Windows.Forms.Button()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.DtpKjrq)
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Controls.Add(Me.LblDwmc)
        Me.Panel3.Controls.Add(Me.LblYtdm)
        Me.Panel3.Controls.Add(Me.LblYtmc)
        Me.Panel3.Controls.Add(Me.TxtUser_Account)
        Me.Panel3.Controls.Add(Me.TxtUser_PWD)
        Me.Panel3.Controls.Add(Me.CmbDwmc)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 56)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(450, 175)
        Me.Panel3.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(153, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "业务日期："
        '
        'DtpKjrq
        '
        Me.DtpKjrq.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpKjrq.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpKjrq.Location = New System.Drawing.Point(225, 132)
        Me.DtpKjrq.Name = "DtpKjrq"
        Me.DtpKjrq.Size = New System.Drawing.Size(151, 21)
        Me.DtpKjrq.TabIndex = 9
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Image = Global.rc3.My.Resources.Resources.ImgQm
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(122, 171)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 41
        Me.PictureBox1.TabStop = False
        '
        'LblDwmc
        '
        Me.LblDwmc.AutoSize = True
        Me.LblDwmc.Location = New System.Drawing.Point(153, 100)
        Me.LblDwmc.Name = "LblDwmc"
        Me.LblDwmc.Size = New System.Drawing.Size(65, 12)
        Me.LblDwmc.TabIndex = 4
        Me.LblDwmc.Text = "核算单位："
        '
        'LblYtdm
        '
        Me.LblYtdm.AutoSize = True
        Me.LblYtdm.Location = New System.Drawing.Point(153, 26)
        Me.LblYtdm.Name = "LblYtdm"
        Me.LblYtdm.Size = New System.Drawing.Size(65, 12)
        Me.LblYtdm.TabIndex = 0
        Me.LblYtdm.Text = "登陆账号："
        '
        'LblYtmc
        '
        Me.LblYtmc.AutoSize = True
        Me.LblYtmc.Location = New System.Drawing.Point(153, 63)
        Me.LblYtmc.Name = "LblYtmc"
        Me.LblYtmc.Size = New System.Drawing.Size(65, 12)
        Me.LblYtmc.TabIndex = 2
        Me.LblYtmc.Text = "口    令："
        '
        'TxtUser_Account
        '
        Me.TxtUser_Account.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtUser_Account.Location = New System.Drawing.Point(225, 22)
        Me.TxtUser_Account.MaxLength = 12
        Me.TxtUser_Account.Name = "TxtUser_Account"
        Me.TxtUser_Account.Size = New System.Drawing.Size(184, 21)
        Me.TxtUser_Account.TabIndex = 1
        '
        'TxtUser_PWD
        '
        Me.TxtUser_PWD.Location = New System.Drawing.Point(225, 59)
        Me.TxtUser_PWD.MaxLength = 30
        Me.TxtUser_PWD.Name = "TxtUser_PWD"
        Me.TxtUser_PWD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtUser_PWD.Size = New System.Drawing.Size(184, 21)
        Me.TxtUser_PWD.TabIndex = 3
        '
        'CmbDwmc
        '
        Me.CmbDwmc.FormattingEnabled = True
        Me.CmbDwmc.Location = New System.Drawing.Point(225, 96)
        Me.CmbDwmc.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CmbDwmc.Name = "CmbDwmc"
        Me.CmbDwmc.Size = New System.Drawing.Size(184, 20)
        Me.CmbDwmc.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FloralWhite
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(450, 56)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("楷体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label1.Location = New System.Drawing.Point(24, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "锐创软件-RC3"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.BtnOk)
        Me.Panel2.Controls.Add(Me.BtnHelp)
        Me.Panel2.Controls.Add(Me.BtnExit)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 231)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(450, 56)
        Me.Panel2.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "版本：V3.0"
        '
        'BtnOk
        '
        Me.BtnOk.Location = New System.Drawing.Point(176, 16)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(75, 23)
        Me.BtnOk.TabIndex = 0
        Me.BtnOk.Text = "确定(&O)"
        '
        'BtnHelp
        '
        Me.BtnHelp.Location = New System.Drawing.Point(256, 16)
        Me.BtnHelp.Name = "BtnHelp"
        Me.BtnHelp.Size = New System.Drawing.Size(75, 23)
        Me.BtnHelp.TabIndex = 1
        Me.BtnHelp.Text = "帮助(&H)"
        '
        'BtnExit
        '
        Me.BtnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnExit.Location = New System.Drawing.Point(336, 16)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 23)
        Me.BtnExit.TabIndex = 2
        Me.BtnExit.Text = "退出(&X)"
        '
        'FrmUserLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 287)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmUserLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.TopMost = True
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LblDwmc As System.Windows.Forms.Label
    Friend WithEvents LblYtdm As System.Windows.Forms.Label
    Friend WithEvents LblYtmc As System.Windows.Forms.Label
    Friend WithEvents TxtUser_Account As System.Windows.Forms.TextBox
    Friend WithEvents TxtUser_PWD As System.Windows.Forms.TextBox
    Friend WithEvents CmbDwmc As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents BtnHelp As System.Windows.Forms.Button
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DtpKjrq As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
