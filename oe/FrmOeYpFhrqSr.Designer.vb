<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeYpFhrqSr
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
        Me.TxtHth = New System.Windows.Forms.TextBox
        Me.LblHth = New System.Windows.Forms.Label
        Me.TxtKhdm = New System.Windows.Forms.TextBox
        Me.LblKhdm = New System.Windows.Forms.Label
        Me.TxtCpmc = New System.Windows.Forms.TextBox
        Me.LblCpmc = New System.Windows.Forms.Label
        Me.TxtCpgg = New System.Windows.Forms.TextBox
        Me.LblCpgg = New System.Windows.Forms.Label
        Me.DlgPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(182, 131)
        '
        'TxtHth
        '
        Me.TxtHth.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtHth.Location = New System.Drawing.Point(277, 33)
        Me.TxtHth.MaxLength = 11
        Me.TxtHth.Name = "TxtHth"
        Me.TxtHth.Size = New System.Drawing.Size(105, 21)
        Me.TxtHth.TabIndex = 3
        '
        'LblHth
        '
        Me.LblHth.AutoSize = True
        Me.LblHth.Location = New System.Drawing.Point(216, 36)
        Me.LblHth.Name = "LblHth"
        Me.LblHth.Size = New System.Drawing.Size(65, 12)
        Me.LblHth.TabIndex = 2
        Me.LblHth.Text = "合同编码："
        '
        'TxtKhdm
        '
        Me.TxtKhdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtKhdm.Location = New System.Drawing.Point(104, 33)
        Me.TxtKhdm.MaxLength = 12
        Me.TxtKhdm.Name = "TxtKhdm"
        Me.TxtKhdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtKhdm.TabIndex = 1
        '
        'LblKhdm
        '
        Me.LblKhdm.AutoSize = True
        Me.LblKhdm.Location = New System.Drawing.Point(42, 36)
        Me.LblKhdm.Name = "LblKhdm"
        Me.LblKhdm.Size = New System.Drawing.Size(65, 12)
        Me.LblKhdm.TabIndex = 0
        Me.LblKhdm.Text = "客户编码："
        '
        'TxtCpmc
        '
        Me.TxtCpmc.Location = New System.Drawing.Point(104, 75)
        Me.TxtCpmc.MaxLength = 15
        Me.TxtCpmc.Name = "TxtCpmc"
        Me.TxtCpmc.Size = New System.Drawing.Size(104, 21)
        Me.TxtCpmc.TabIndex = 5
        '
        'LblCpmc
        '
        Me.LblCpmc.AutoSize = True
        Me.LblCpmc.Location = New System.Drawing.Point(42, 75)
        Me.LblCpmc.Name = "LblCpmc"
        Me.LblCpmc.Size = New System.Drawing.Size(65, 12)
        Me.LblCpmc.TabIndex = 4
        Me.LblCpmc.Text = "产品名称："
        '
        'TxtCpgg
        '
        Me.TxtCpgg.Location = New System.Drawing.Point(278, 72)
        Me.TxtCpgg.MaxLength = 15
        Me.TxtCpgg.Name = "TxtCpgg"
        Me.TxtCpgg.Size = New System.Drawing.Size(104, 21)
        Me.TxtCpgg.TabIndex = 7
        '
        'LblCpgg
        '
        Me.LblCpgg.AutoSize = True
        Me.LblCpgg.Location = New System.Drawing.Point(216, 75)
        Me.LblCpgg.Name = "LblCpgg"
        Me.LblCpgg.Size = New System.Drawing.Size(65, 12)
        Me.LblCpgg.TabIndex = 6
        Me.LblCpgg.Text = "规格型号："
        '
        'FrmOeYpFhrqSr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 174)
        Me.Controls.Add(Me.TxtCpgg)
        Me.Controls.Add(Me.LblCpgg)
        Me.Controls.Add(Me.TxtCpmc)
        Me.Controls.Add(Me.LblCpmc)
        Me.Controls.Add(Me.TxtKhdm)
        Me.Controls.Add(Me.LblKhdm)
        Me.Controls.Add(Me.TxtHth)
        Me.Controls.Add(Me.LblHth)
        Me.Name = "FrmOeYpFhrqSr"
        Me.Text = "样品寄样日期输入"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.LblHth, 0)
        Me.Controls.SetChildIndex(Me.TxtHth, 0)
        Me.Controls.SetChildIndex(Me.LblKhdm, 0)
        Me.Controls.SetChildIndex(Me.TxtKhdm, 0)
        Me.Controls.SetChildIndex(Me.LblCpmc, 0)
        Me.Controls.SetChildIndex(Me.TxtCpmc, 0)
        Me.Controls.SetChildIndex(Me.LblCpgg, 0)
        Me.Controls.SetChildIndex(Me.TxtCpgg, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents TxtHth As System.Windows.Forms.TextBox
    Public WithEvents LblHth As System.Windows.Forms.Label
    Public WithEvents TxtKhdm As System.Windows.Forms.TextBox
    Public WithEvents LblKhdm As System.Windows.Forms.Label
    Public WithEvents TxtCpmc As System.Windows.Forms.TextBox
    Public WithEvents LblCpmc As System.Windows.Forms.Label
    Public WithEvents TxtCpgg As System.Windows.Forms.TextBox
    Public WithEvents LblCpgg As System.Windows.Forms.Label
End Class
