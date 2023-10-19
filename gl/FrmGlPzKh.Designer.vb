<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGlPzKh
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
        Me.LblKhdm = New System.Windows.Forms.Label
        Me.TxtKhdm = New System.Windows.Forms.TextBox
        Me.TxtKhmc = New System.Windows.Forms.TextBox
        Me.LblKhmc = New System.Windows.Forms.Label
        Me.TxtYspz = New System.Windows.Forms.TextBox
        Me.LblYspz = New System.Windows.Forms.Label
        Me.LblWldqr = New System.Windows.Forms.Label
        Me.TxtJsr = New System.Windows.Forms.TextBox
        Me.LblJsr = New System.Windows.Forms.Label
        Me.DtpWldqr = New System.Windows.Forms.DateTimePicker
        Me.DlgPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(133, 211)
        Me.DlgPanel.TabIndex = 10
        '
        'LblKhdm
        '
        Me.LblKhdm.AutoSize = True
        Me.LblKhdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblKhdm.Location = New System.Drawing.Point(41, 31)
        Me.LblKhdm.Name = "LblKhdm"
        Me.LblKhdm.Size = New System.Drawing.Size(88, 16)
        Me.LblKhdm.TabIndex = 0
        Me.LblKhdm.Text = "客户编码："
        '
        'TxtKhdm
        '
        Me.TxtKhdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtKhdm.Location = New System.Drawing.Point(136, 28)
        Me.TxtKhdm.MaxLength = 12
        Me.TxtKhdm.Name = "TxtKhdm"
        Me.TxtKhdm.Size = New System.Drawing.Size(87, 21)
        Me.TxtKhdm.TabIndex = 1
        '
        'TxtKhmc
        '
        Me.TxtKhmc.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtKhmc.Location = New System.Drawing.Point(136, 62)
        Me.TxtKhmc.Name = "TxtKhmc"
        Me.TxtKhmc.ReadOnly = True
        Me.TxtKhmc.Size = New System.Drawing.Size(201, 26)
        Me.TxtKhmc.TabIndex = 3
        Me.TxtKhmc.TabStop = False
        '
        'LblKhmc
        '
        Me.LblKhmc.AutoSize = True
        Me.LblKhmc.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblKhmc.Location = New System.Drawing.Point(41, 65)
        Me.LblKhmc.Name = "LblKhmc"
        Me.LblKhmc.Size = New System.Drawing.Size(88, 16)
        Me.LblKhmc.TabIndex = 2
        Me.LblKhmc.Text = "客户名称："
        '
        'TxtYspz
        '
        Me.TxtYspz.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtYspz.Location = New System.Drawing.Point(136, 93)
        Me.TxtYspz.MaxLength = 16
        Me.TxtYspz.Name = "TxtYspz"
        Me.TxtYspz.Size = New System.Drawing.Size(128, 26)
        Me.TxtYspz.TabIndex = 5
        '
        'LblYspz
        '
        Me.LblYspz.AutoSize = True
        Me.LblYspz.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblYspz.Location = New System.Drawing.Point(42, 96)
        Me.LblYspz.Name = "LblYspz"
        Me.LblYspz.Size = New System.Drawing.Size(104, 16)
        Me.LblYspz.TabIndex = 4
        Me.LblYspz.Text = "原始凭证号："
        '
        'LblWldqr
        '
        Me.LblWldqr.AutoSize = True
        Me.LblWldqr.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblWldqr.Location = New System.Drawing.Point(42, 163)
        Me.LblWldqr.Name = "LblWldqr"
        Me.LblWldqr.Size = New System.Drawing.Size(88, 16)
        Me.LblWldqr.TabIndex = 8
        Me.LblWldqr.Text = "到 期 日："
        '
        'TxtJsr
        '
        Me.TxtJsr.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtJsr.Location = New System.Drawing.Point(136, 125)
        Me.TxtJsr.MaxLength = 30
        Me.TxtJsr.Name = "TxtJsr"
        Me.TxtJsr.Size = New System.Drawing.Size(128, 26)
        Me.TxtJsr.TabIndex = 7
        '
        'LblJsr
        '
        Me.LblJsr.AutoSize = True
        Me.LblJsr.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblJsr.Location = New System.Drawing.Point(42, 128)
        Me.LblJsr.Name = "LblJsr"
        Me.LblJsr.Size = New System.Drawing.Size(88, 16)
        Me.LblJsr.TabIndex = 6
        Me.LblJsr.Text = "经 手 人："
        '
        'DtpWldqr
        '
        Me.DtpWldqr.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.DtpWldqr.Location = New System.Drawing.Point(136, 156)
        Me.DtpWldqr.Name = "DtpWldqr"
        Me.DtpWldqr.Size = New System.Drawing.Size(136, 26)
        Me.DtpWldqr.TabIndex = 9
        '
        'FrmGlPzKh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(386, 254)
        Me.Controls.Add(Me.DtpWldqr)
        Me.Controls.Add(Me.TxtJsr)
        Me.Controls.Add(Me.LblJsr)
        Me.Controls.Add(Me.LblWldqr)
        Me.Controls.Add(Me.TxtYspz)
        Me.Controls.Add(Me.LblYspz)
        Me.Controls.Add(Me.TxtKhmc)
        Me.Controls.Add(Me.LblKhmc)
        Me.Controls.Add(Me.TxtKhdm)
        Me.Controls.Add(Me.LblKhdm)
        Me.Name = "FrmGlPzKh"
        Me.Text = "选择客户"
        Me.Controls.SetChildIndex(Me.LblKhdm, 0)
        Me.Controls.SetChildIndex(Me.TxtKhdm, 0)
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.LblKhmc, 0)
        Me.Controls.SetChildIndex(Me.TxtKhmc, 0)
        Me.Controls.SetChildIndex(Me.LblYspz, 0)
        Me.Controls.SetChildIndex(Me.TxtYspz, 0)
        Me.Controls.SetChildIndex(Me.LblWldqr, 0)
        Me.Controls.SetChildIndex(Me.LblJsr, 0)
        Me.Controls.SetChildIndex(Me.TxtJsr, 0)
        Me.Controls.SetChildIndex(Me.DtpWldqr, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblKhdm As System.Windows.Forms.Label
    Friend WithEvents TxtKhdm As System.Windows.Forms.TextBox
    Friend WithEvents TxtKhmc As System.Windows.Forms.TextBox
    Friend WithEvents LblKhmc As System.Windows.Forms.Label
    Friend WithEvents TxtYspz As System.Windows.Forms.TextBox
    Friend WithEvents LblYspz As System.Windows.Forms.Label
    Friend WithEvents LblWldqr As System.Windows.Forms.Label
    Friend WithEvents TxtJsr As System.Windows.Forms.TextBox
    Friend WithEvents LblJsr As System.Windows.Forms.Label
    Friend WithEvents DtpWldqr As System.Windows.Forms.DateTimePicker
End Class
