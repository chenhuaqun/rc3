<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAbout
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAbout))
        Me.butInfo = New System.Windows.Forms.Button()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblHomePage = New System.Windows.Forms.LinkLabel()
        Me.LblEmail = New System.Windows.Forms.LinkLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'butInfo
        '
        Me.butInfo.AccessibleDescription = "System Info"
        Me.butInfo.AccessibleName = "System Info"
        Me.butInfo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.butInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.butInfo.Location = New System.Drawing.Point(337, 228)
        Me.butInfo.Name = "butInfo"
        Me.butInfo.Size = New System.Drawing.Size(96, 24)
        Me.butInfo.TabIndex = 25
        Me.butInfo.Text = "系统信息..."
        '
        'BtnExit
        '
        Me.BtnExit.Location = New System.Drawing.Point(337, 196)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(96, 23)
        Me.BtnExit.TabIndex = 23
        Me.BtnExit.Text = "关闭(&C)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(34, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 12)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "软件版本：V3.0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(34, 218)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(167, 12)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "技术支持热线:(0571)88485828"
        '
        'LblHomePage
        '
        Me.LblHomePage.AutoSize = True
        Me.LblHomePage.LinkArea = New System.Windows.Forms.LinkArea(3, 21)
        Me.LblHomePage.Location = New System.Drawing.Point(33, 188)
        Me.LblHomePage.Name = "LblHomePage"
        Me.LblHomePage.Size = New System.Drawing.Size(165, 19)
        Me.LblHomePage.TabIndex = 19
        Me.LblHomePage.TabStop = True
        Me.LblHomePage.Text = "网址:http://www.richen.net"
        Me.LblHomePage.UseCompatibleTextRendering = True
        '
        'LblEmail
        '
        Me.LblEmail.AutoSize = True
        Me.LblEmail.LinkArea = New System.Windows.Forms.LinkArea(6, 24)
        Me.LblEmail.Location = New System.Drawing.Point(33, 172)
        Me.LblEmail.Name = "LblEmail"
        Me.LblEmail.Size = New System.Drawing.Size(147, 19)
        Me.LblEmail.TabIndex = 18
        Me.LblEmail.TabStop = True
        Me.LblEmail.Text = "Email:chenhuaqun@qq.com"
        Me.LblEmail.UseCompatibleTextRendering = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 140)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(239, 12)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Copyright(C) 2021. All rights reserved."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(197, 12)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "版权所有(C) 2021. 保留所有权利。"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("黑体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(33, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(183, 16)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "库存管理（Inventory ）"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(273, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(154, 44)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'FrmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 268)
        Me.Controls.Add(Me.butInfo)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LblHomePage)
        Me.Controls.Add(Me.LblEmail)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAbout"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "关于......"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents butInfo As System.Windows.Forms.Button
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LblHomePage As System.Windows.Forms.LinkLabel
    Friend WithEvents LblEmail As System.Windows.Forms.LinkLabel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
