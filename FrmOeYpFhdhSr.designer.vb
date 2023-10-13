<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeYpFhdhSr
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
        Me.LblQdrqEnd = New System.Windows.Forms.Label
        Me.DtpQdrqEnd = New System.Windows.Forms.DateTimePicker
        Me.LblQdrqBegin = New System.Windows.Forms.Label
        Me.DtpQdrqBegin = New System.Windows.Forms.DateTimePicker
        Me.DlgPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(182, 160)
        '
        'TxtHth
        '
        Me.TxtHth.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtHth.Location = New System.Drawing.Point(292, 64)
        Me.TxtHth.MaxLength = 11
        Me.TxtHth.Name = "TxtHth"
        Me.TxtHth.Size = New System.Drawing.Size(105, 21)
        Me.TxtHth.TabIndex = 7
        '
        'LblHth
        '
        Me.LblHth.AutoSize = True
        Me.LblHth.Location = New System.Drawing.Point(221, 67)
        Me.LblHth.Name = "LblHth"
        Me.LblHth.Size = New System.Drawing.Size(65, 12)
        Me.LblHth.TabIndex = 6
        Me.LblHth.Text = "合同编码："
        '
        'TxtKhdm
        '
        Me.TxtKhdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtKhdm.Location = New System.Drawing.Point(109, 64)
        Me.TxtKhdm.MaxLength = 12
        Me.TxtKhdm.Name = "TxtKhdm"
        Me.TxtKhdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtKhdm.TabIndex = 5
        '
        'LblKhdm
        '
        Me.LblKhdm.AutoSize = True
        Me.LblKhdm.Location = New System.Drawing.Point(38, 67)
        Me.LblKhdm.Name = "LblKhdm"
        Me.LblKhdm.Size = New System.Drawing.Size(65, 12)
        Me.LblKhdm.TabIndex = 4
        Me.LblKhdm.Text = "客户编码："
        '
        'TxtCpmc
        '
        Me.TxtCpmc.Location = New System.Drawing.Point(109, 106)
        Me.TxtCpmc.MaxLength = 15
        Me.TxtCpmc.Name = "TxtCpmc"
        Me.TxtCpmc.Size = New System.Drawing.Size(104, 21)
        Me.TxtCpmc.TabIndex = 9
        '
        'LblCpmc
        '
        Me.LblCpmc.AutoSize = True
        Me.LblCpmc.Location = New System.Drawing.Point(38, 106)
        Me.LblCpmc.Name = "LblCpmc"
        Me.LblCpmc.Size = New System.Drawing.Size(65, 12)
        Me.LblCpmc.TabIndex = 8
        Me.LblCpmc.Text = "产品名称："
        '
        'TxtCpgg
        '
        Me.TxtCpgg.Location = New System.Drawing.Point(292, 103)
        Me.TxtCpgg.MaxLength = 15
        Me.TxtCpgg.Name = "TxtCpgg"
        Me.TxtCpgg.Size = New System.Drawing.Size(104, 21)
        Me.TxtCpgg.TabIndex = 11
        '
        'LblCpgg
        '
        Me.LblCpgg.AutoSize = True
        Me.LblCpgg.Location = New System.Drawing.Point(221, 106)
        Me.LblCpgg.Name = "LblCpgg"
        Me.LblCpgg.Size = New System.Drawing.Size(65, 12)
        Me.LblCpgg.TabIndex = 10
        Me.LblCpgg.Text = "规格型号："
        '
        'LblQdrqEnd
        '
        Me.LblQdrqEnd.AutoSize = True
        Me.LblQdrqEnd.Location = New System.Drawing.Point(229, 31)
        Me.LblQdrqEnd.Name = "LblQdrqEnd"
        Me.LblQdrqEnd.Size = New System.Drawing.Size(17, 12)
        Me.LblQdrqEnd.TabIndex = 2
        Me.LblQdrqEnd.Text = "至"
        '
        'DtpQdrqEnd
        '
        Me.DtpQdrqEnd.Location = New System.Drawing.Point(252, 25)
        Me.DtpQdrqEnd.Name = "DtpQdrqEnd"
        Me.DtpQdrqEnd.Size = New System.Drawing.Size(112, 21)
        Me.DtpQdrqEnd.TabIndex = 3
        '
        'LblQdrqBegin
        '
        Me.LblQdrqBegin.AutoSize = True
        Me.LblQdrqBegin.Location = New System.Drawing.Point(38, 31)
        Me.LblQdrqBegin.Name = "LblQdrqBegin"
        Me.LblQdrqBegin.Size = New System.Drawing.Size(65, 12)
        Me.LblQdrqBegin.TabIndex = 0
        Me.LblQdrqBegin.Text = "寄样日期："
        '
        'DtpQdrqBegin
        '
        Me.DtpQdrqBegin.Location = New System.Drawing.Point(109, 25)
        Me.DtpQdrqBegin.Name = "DtpQdrqBegin"
        Me.DtpQdrqBegin.Size = New System.Drawing.Size(112, 21)
        Me.DtpQdrqBegin.TabIndex = 1
        '
        'FrmOeYpFhdhSr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 203)
        Me.Controls.Add(Me.LblQdrqEnd)
        Me.Controls.Add(Me.DtpQdrqEnd)
        Me.Controls.Add(Me.LblQdrqBegin)
        Me.Controls.Add(Me.DtpQdrqBegin)
        Me.Controls.Add(Me.TxtCpgg)
        Me.Controls.Add(Me.LblCpgg)
        Me.Controls.Add(Me.TxtCpmc)
        Me.Controls.Add(Me.LblCpmc)
        Me.Controls.Add(Me.TxtKhdm)
        Me.Controls.Add(Me.LblKhdm)
        Me.Controls.Add(Me.TxtHth)
        Me.Controls.Add(Me.LblHth)
        Me.Name = "FrmOeYpFhdhSr"
        Me.Text = "样品寄样单号输入"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.LblHth, 0)
        Me.Controls.SetChildIndex(Me.TxtHth, 0)
        Me.Controls.SetChildIndex(Me.LblKhdm, 0)
        Me.Controls.SetChildIndex(Me.TxtKhdm, 0)
        Me.Controls.SetChildIndex(Me.LblCpmc, 0)
        Me.Controls.SetChildIndex(Me.TxtCpmc, 0)
        Me.Controls.SetChildIndex(Me.LblCpgg, 0)
        Me.Controls.SetChildIndex(Me.TxtCpgg, 0)
        Me.Controls.SetChildIndex(Me.DtpQdrqBegin, 0)
        Me.Controls.SetChildIndex(Me.LblQdrqBegin, 0)
        Me.Controls.SetChildIndex(Me.DtpQdrqEnd, 0)
        Me.Controls.SetChildIndex(Me.LblQdrqEnd, 0)
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
    Public WithEvents LblQdrqEnd As System.Windows.Forms.Label
    Public WithEvents DtpQdrqEnd As System.Windows.Forms.DateTimePicker
    Public WithEvents LblQdrqBegin As System.Windows.Forms.Label
    Public WithEvents DtpQdrqBegin As System.Windows.Forms.DateTimePicker
End Class
