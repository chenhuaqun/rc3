<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCpFilter
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
        Me.LblCpdm = New System.Windows.Forms.Label
        Me.LblCpmc = New System.Windows.Forms.Label
        Me.TxtCpdm = New System.Windows.Forms.TextBox
        Me.TxtCpmc = New System.Windows.Forms.TextBox
        Me.LblKhdm = New System.Windows.Forms.Label
        Me.LblKhmc = New System.Windows.Forms.Label
        Me.TxtKhdm = New System.Windows.Forms.TextBox
        Me.TxtKhmc = New System.Windows.Forms.TextBox
        Me.TxtOldCpdm = New System.Windows.Forms.TextBox
        Me.LblOldCpdm = New System.Windows.Forms.Label
        Me.DlgPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnCancel
        '
        Me.BtnCancel.TabIndex = 1
        '
        'BtnHelp
        '
        Me.BtnHelp.TabIndex = 2
        '
        'BtnOk
        '
        Me.BtnOk.TabIndex = 0
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(188, 198)
        Me.DlgPanel.TabIndex = 10
        '
        'LblCpdm
        '
        Me.LblCpdm.AutoSize = True
        Me.LblCpdm.Location = New System.Drawing.Point(33, 32)
        Me.LblCpdm.Name = "LblCpdm"
        Me.LblCpdm.Size = New System.Drawing.Size(65, 12)
        Me.LblCpdm.TabIndex = 0
        Me.LblCpdm.Text = "物料编码："
        '
        'LblCpmc
        '
        Me.LblCpmc.AutoSize = True
        Me.LblCpmc.Location = New System.Drawing.Point(33, 61)
        Me.LblCpmc.Name = "LblCpmc"
        Me.LblCpmc.Size = New System.Drawing.Size(65, 12)
        Me.LblCpmc.TabIndex = 2
        Me.LblCpmc.Text = "物料描述："
        '
        'TxtCpdm
        '
        Me.TxtCpdm.Location = New System.Drawing.Point(105, 28)
        Me.TxtCpdm.MaxLength = 15
        Me.TxtCpdm.Name = "TxtCpdm"
        Me.TxtCpdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtCpdm.TabIndex = 1
        '
        'TxtCpmc
        '
        Me.TxtCpmc.Location = New System.Drawing.Point(105, 57)
        Me.TxtCpmc.MaxLength = 100
        Me.TxtCpmc.Name = "TxtCpmc"
        Me.TxtCpmc.Size = New System.Drawing.Size(304, 21)
        Me.TxtCpmc.TabIndex = 3
        '
        'LblKhdm
        '
        Me.LblKhdm.AutoSize = True
        Me.LblKhdm.Location = New System.Drawing.Point(33, 119)
        Me.LblKhdm.Name = "LblKhdm"
        Me.LblKhdm.Size = New System.Drawing.Size(65, 12)
        Me.LblKhdm.TabIndex = 6
        Me.LblKhdm.Text = "客户编码："
        '
        'LblKhmc
        '
        Me.LblKhmc.AutoSize = True
        Me.LblKhmc.Location = New System.Drawing.Point(33, 148)
        Me.LblKhmc.Name = "LblKhmc"
        Me.LblKhmc.Size = New System.Drawing.Size(65, 12)
        Me.LblKhmc.TabIndex = 8
        Me.LblKhmc.Text = "客户名称："
        '
        'TxtKhdm
        '
        Me.TxtKhdm.Location = New System.Drawing.Point(105, 115)
        Me.TxtKhdm.MaxLength = 15
        Me.TxtKhdm.Name = "TxtKhdm"
        Me.TxtKhdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtKhdm.TabIndex = 7
        '
        'TxtKhmc
        '
        Me.TxtKhmc.Location = New System.Drawing.Point(105, 144)
        Me.TxtKhmc.MaxLength = 40
        Me.TxtKhmc.Name = "TxtKhmc"
        Me.TxtKhmc.Size = New System.Drawing.Size(304, 21)
        Me.TxtKhmc.TabIndex = 9
        '
        'TxtOldCpdm
        '
        Me.TxtOldCpdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtOldCpdm.Location = New System.Drawing.Point(105, 86)
        Me.TxtOldCpdm.MaxLength = 12
        Me.TxtOldCpdm.Name = "TxtOldCpdm"
        Me.TxtOldCpdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtOldCpdm.TabIndex = 5
        '
        'LblOldCpdm
        '
        Me.LblOldCpdm.AutoSize = True
        Me.LblOldCpdm.Location = New System.Drawing.Point(21, 90)
        Me.LblOldCpdm.Name = "LblOldCpdm"
        Me.LblOldCpdm.Size = New System.Drawing.Size(77, 12)
        Me.LblOldCpdm.TabIndex = 4
        Me.LblOldCpdm.Text = "旧物料编码："
        '
        'FrmCpFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 241)
        Me.Controls.Add(Me.TxtOldCpdm)
        Me.Controls.Add(Me.LblOldCpdm)
        Me.Controls.Add(Me.LblKhdm)
        Me.Controls.Add(Me.LblKhmc)
        Me.Controls.Add(Me.TxtKhdm)
        Me.Controls.Add(Me.TxtKhmc)
        Me.Controls.Add(Me.LblCpdm)
        Me.Controls.Add(Me.LblCpmc)
        Me.Controls.Add(Me.TxtCpdm)
        Me.Controls.Add(Me.TxtCpmc)
        Me.Name = "FrmCpFilter"
        Me.Text = "条件筛选"
        Me.Controls.SetChildIndex(Me.TxtCpmc, 0)
        Me.Controls.SetChildIndex(Me.TxtCpdm, 0)
        Me.Controls.SetChildIndex(Me.LblCpmc, 0)
        Me.Controls.SetChildIndex(Me.LblCpdm, 0)
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.TxtKhmc, 0)
        Me.Controls.SetChildIndex(Me.TxtKhdm, 0)
        Me.Controls.SetChildIndex(Me.LblKhmc, 0)
        Me.Controls.SetChildIndex(Me.LblKhdm, 0)
        Me.Controls.SetChildIndex(Me.LblOldCpdm, 0)
        Me.Controls.SetChildIndex(Me.TxtOldCpdm, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblCpdm As System.Windows.Forms.Label
    Friend WithEvents LblCpmc As System.Windows.Forms.Label
    Friend WithEvents TxtCpdm As System.Windows.Forms.TextBox
    Friend WithEvents TxtCpmc As System.Windows.Forms.TextBox
    Friend WithEvents LblKhdm As System.Windows.Forms.Label
    Friend WithEvents LblKhmc As System.Windows.Forms.Label
    Friend WithEvents TxtKhdm As System.Windows.Forms.TextBox
    Friend WithEvents TxtKhmc As System.Windows.Forms.TextBox
    Friend WithEvents TxtOldCpdm As System.Windows.Forms.TextBox
    Friend WithEvents LblOldCpdm As System.Windows.Forms.Label
End Class
