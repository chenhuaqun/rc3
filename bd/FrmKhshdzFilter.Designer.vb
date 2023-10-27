<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmKhshdzFilter
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
        Me.TxtKhmc = New System.Windows.Forms.TextBox
        Me.LblKhmc = New System.Windows.Forms.Label
        Me.TxtKhdm = New System.Windows.Forms.TextBox
        Me.TxtAddress = New System.Windows.Forms.TextBox
        Me.LblAddress = New System.Windows.Forms.Label
        Me.LblZydm = New System.Windows.Forms.Label
        Me.TxtZydm = New System.Windows.Forms.TextBox
        Me.DlgPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(156, 178)
        '
        'LblKhdm
        '
        Me.LblKhdm.AutoSize = True
        Me.LblKhdm.Location = New System.Drawing.Point(37, 37)
        Me.LblKhdm.Name = "LblKhdm"
        Me.LblKhdm.Size = New System.Drawing.Size(65, 12)
        Me.LblKhdm.TabIndex = 0
        Me.LblKhdm.Text = "客户编码："
        '
        'TxtKhmc
        '
        Me.TxtKhmc.Location = New System.Drawing.Point(109, 58)
        Me.TxtKhmc.MaxLength = 200
        Me.TxtKhmc.Name = "TxtKhmc"
        Me.TxtKhmc.Size = New System.Drawing.Size(256, 21)
        Me.TxtKhmc.TabIndex = 3
        '
        'LblKhmc
        '
        Me.LblKhmc.AutoSize = True
        Me.LblKhmc.Location = New System.Drawing.Point(37, 61)
        Me.LblKhmc.Name = "LblKhmc"
        Me.LblKhmc.Size = New System.Drawing.Size(65, 12)
        Me.LblKhmc.TabIndex = 2
        Me.LblKhmc.Text = "客户名称："
        '
        'TxtKhdm
        '
        Me.TxtKhdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtKhdm.Location = New System.Drawing.Point(109, 34)
        Me.TxtKhdm.MaxLength = 12
        Me.TxtKhdm.Name = "TxtKhdm"
        Me.TxtKhdm.Size = New System.Drawing.Size(87, 21)
        Me.TxtKhdm.TabIndex = 1
        '
        'TxtAddress
        '
        Me.TxtAddress.Location = New System.Drawing.Point(109, 107)
        Me.TxtAddress.MaxLength = 200
        Me.TxtAddress.Name = "TxtAddress"
        Me.TxtAddress.Size = New System.Drawing.Size(256, 21)
        Me.TxtAddress.TabIndex = 7
        '
        'LblAddress
        '
        Me.LblAddress.AutoSize = True
        Me.LblAddress.Location = New System.Drawing.Point(38, 110)
        Me.LblAddress.Name = "LblAddress"
        Me.LblAddress.Size = New System.Drawing.Size(65, 12)
        Me.LblAddress.TabIndex = 6
        Me.LblAddress.Text = "收货地址："
        '
        'LblZydm
        '
        Me.LblZydm.AutoSize = True
        Me.LblZydm.Location = New System.Drawing.Point(37, 85)
        Me.LblZydm.Name = "LblZydm"
        Me.LblZydm.Size = New System.Drawing.Size(65, 12)
        Me.LblZydm.TabIndex = 4
        Me.LblZydm.Text = "职员编码："
        '
        'TxtZydm
        '
        Me.TxtZydm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtZydm.Location = New System.Drawing.Point(109, 82)
        Me.TxtZydm.MaxLength = 12
        Me.TxtZydm.Name = "TxtZydm"
        Me.TxtZydm.Size = New System.Drawing.Size(87, 21)
        Me.TxtZydm.TabIndex = 5
        '
        'FrmKhshdzFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(407, 219)
        Me.ControlBox = False
        Me.Controls.Add(Me.LblZydm)
        Me.Controls.Add(Me.TxtZydm)
        Me.Controls.Add(Me.TxtAddress)
        Me.Controls.Add(Me.LblAddress)
        Me.Controls.Add(Me.LblKhdm)
        Me.Controls.Add(Me.TxtKhmc)
        Me.Controls.Add(Me.LblKhmc)
        Me.Controls.Add(Me.TxtKhdm)
        Me.Name = "FrmKhshdzFilter"
        Me.Text = "条件筛选"
        Me.Controls.SetChildIndex(Me.TxtKhdm, 0)
        Me.Controls.SetChildIndex(Me.LblKhmc, 0)
        Me.Controls.SetChildIndex(Me.TxtKhmc, 0)
        Me.Controls.SetChildIndex(Me.LblKhdm, 0)
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.LblAddress, 0)
        Me.Controls.SetChildIndex(Me.TxtAddress, 0)
        Me.Controls.SetChildIndex(Me.TxtZydm, 0)
        Me.Controls.SetChildIndex(Me.LblZydm, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblKhdm As System.Windows.Forms.Label
    Friend WithEvents TxtKhmc As System.Windows.Forms.TextBox
    Friend WithEvents LblKhmc As System.Windows.Forms.Label
    Friend WithEvents TxtKhdm As System.Windows.Forms.TextBox
    Friend WithEvents TxtAddress As System.Windows.Forms.TextBox
    Friend WithEvents LblAddress As System.Windows.Forms.Label
    Friend WithEvents LblZydm As System.Windows.Forms.Label
    Friend WithEvents TxtZydm As System.Windows.Forms.TextBox
End Class
