<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmKhFilter
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
        Me.LblKhmc = New System.Windows.Forms.Label
        Me.TxtKhdm = New System.Windows.Forms.TextBox
        Me.TxtKhmc = New System.Windows.Forms.TextBox
        Me.LblZydm = New System.Windows.Forms.Label
        Me.LblZymc = New System.Windows.Forms.Label
        Me.TxtZydm = New System.Windows.Forms.TextBox
        Me.TxtZymc = New System.Windows.Forms.TextBox
        Me.DlgPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(188, 160)
        Me.DlgPanel.TabIndex = 8
        '
        'LblKhdm
        '
        Me.LblKhdm.AutoSize = True
        Me.LblKhdm.Location = New System.Drawing.Point(30, 28)
        Me.LblKhdm.Name = "LblKhdm"
        Me.LblKhdm.Size = New System.Drawing.Size(65, 12)
        Me.LblKhdm.TabIndex = 0
        Me.LblKhdm.Text = "客户编码："
        '
        'LblKhmc
        '
        Me.LblKhmc.AutoSize = True
        Me.LblKhmc.Location = New System.Drawing.Point(30, 57)
        Me.LblKhmc.Name = "LblKhmc"
        Me.LblKhmc.Size = New System.Drawing.Size(65, 12)
        Me.LblKhmc.TabIndex = 2
        Me.LblKhmc.Text = "客户名称："
        '
        'TxtKhdm
        '
        Me.TxtKhdm.Location = New System.Drawing.Point(102, 24)
        Me.TxtKhdm.MaxLength = 15
        Me.TxtKhdm.Name = "TxtKhdm"
        Me.TxtKhdm.Size = New System.Drawing.Size(87, 21)
        Me.TxtKhdm.TabIndex = 1
        '
        'TxtKhmc
        '
        Me.TxtKhmc.Location = New System.Drawing.Point(102, 53)
        Me.TxtKhmc.MaxLength = 40
        Me.TxtKhmc.Name = "TxtKhmc"
        Me.TxtKhmc.Size = New System.Drawing.Size(304, 21)
        Me.TxtKhmc.TabIndex = 3
        '
        'LblZydm
        '
        Me.LblZydm.AutoSize = True
        Me.LblZydm.Location = New System.Drawing.Point(30, 86)
        Me.LblZydm.Name = "LblZydm"
        Me.LblZydm.Size = New System.Drawing.Size(65, 12)
        Me.LblZydm.TabIndex = 4
        Me.LblZydm.Text = "职员编码："
        '
        'LblZymc
        '
        Me.LblZymc.AutoSize = True
        Me.LblZymc.Location = New System.Drawing.Point(30, 115)
        Me.LblZymc.Name = "LblZymc"
        Me.LblZymc.Size = New System.Drawing.Size(65, 12)
        Me.LblZymc.TabIndex = 6
        Me.LblZymc.Text = "职员姓名："
        '
        'TxtZydm
        '
        Me.TxtZydm.Location = New System.Drawing.Point(102, 82)
        Me.TxtZydm.MaxLength = 15
        Me.TxtZydm.Name = "TxtZydm"
        Me.TxtZydm.Size = New System.Drawing.Size(87, 21)
        Me.TxtZydm.TabIndex = 5
        '
        'TxtZymc
        '
        Me.TxtZymc.Location = New System.Drawing.Point(102, 111)
        Me.TxtZymc.MaxLength = 40
        Me.TxtZymc.Name = "TxtZymc"
        Me.TxtZymc.Size = New System.Drawing.Size(87, 21)
        Me.TxtZymc.TabIndex = 7
        '
        'FrmKhFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 203)
        Me.Controls.Add(Me.LblZydm)
        Me.Controls.Add(Me.LblZymc)
        Me.Controls.Add(Me.TxtZydm)
        Me.Controls.Add(Me.TxtZymc)
        Me.Controls.Add(Me.LblKhdm)
        Me.Controls.Add(Me.LblKhmc)
        Me.Controls.Add(Me.TxtKhdm)
        Me.Controls.Add(Me.TxtKhmc)
        Me.Name = "FrmKhFilter"
        Me.Text = "条件筛选"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.TxtKhmc, 0)
        Me.Controls.SetChildIndex(Me.TxtKhdm, 0)
        Me.Controls.SetChildIndex(Me.LblKhmc, 0)
        Me.Controls.SetChildIndex(Me.LblKhdm, 0)
        Me.Controls.SetChildIndex(Me.TxtZymc, 0)
        Me.Controls.SetChildIndex(Me.TxtZydm, 0)
        Me.Controls.SetChildIndex(Me.LblZymc, 0)
        Me.Controls.SetChildIndex(Me.LblZydm, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblKhdm As System.Windows.Forms.Label
    Friend WithEvents LblKhmc As System.Windows.Forms.Label
    Friend WithEvents TxtKhdm As System.Windows.Forms.TextBox
    Friend WithEvents TxtKhmc As System.Windows.Forms.TextBox
    Friend WithEvents LblZydm As System.Windows.Forms.Label
    Friend WithEvents LblZymc As System.Windows.Forms.Label
    Friend WithEvents TxtZydm As System.Windows.Forms.TextBox
    Friend WithEvents TxtZymc As System.Windows.Forms.TextBox
End Class
