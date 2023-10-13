<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPmDdGxlzCx
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
        Me.TxtKhmc = New System.Windows.Forms.TextBox
        Me.LblKhmc = New System.Windows.Forms.Label
        Me.TxtHth = New System.Windows.Forms.TextBox
        Me.LblHth = New System.Windows.Forms.Label
        Me.TxtCpmc = New System.Windows.Forms.TextBox
        Me.LblCpmc = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RadioBtnQdrq = New System.Windows.Forms.RadioButton
        Me.RadioBtnScjhrq = New System.Windows.Forms.RadioButton
        Me.TxtSczydm = New System.Windows.Forms.TextBox
        Me.LblSczydm = New System.Windows.Forms.Label
        Me.TxtZydm = New System.Windows.Forms.TextBox
        Me.LblZydm = New System.Windows.Forms.Label
        Me.TxtKhdm = New System.Windows.Forms.TextBox
        Me.LblKhdm = New System.Windows.Forms.Label
        Me.TxtCpdm = New System.Windows.Forms.TextBox
        Me.LblCpdm = New System.Windows.Forms.Label
        Me.NudDjhEnd = New System.Windows.Forms.NumericUpDown
        Me.LblDjhEnd = New System.Windows.Forms.Label
        Me.NudDjhBegin = New System.Windows.Forms.NumericUpDown
        Me.LblDjhBegin = New System.Windows.Forms.Label
        Me.LblQdrqEnd = New System.Windows.Forms.Label
        Me.DtpQdrqEnd = New System.Windows.Forms.DateTimePicker
        Me.LblQdrqBegin = New System.Windows.Forms.Label
        Me.DtpQdrqBegin = New System.Windows.Forms.DateTimePicker
        Me.DlgPanel.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NudDjhEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudDjhBegin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(173, 289)
        '
        'TxtKhmc
        '
        Me.TxtKhmc.Location = New System.Drawing.Point(292, 215)
        Me.TxtKhmc.MaxLength = 15
        Me.TxtKhmc.Name = "TxtKhmc"
        Me.TxtKhmc.Size = New System.Drawing.Size(104, 21)
        Me.TxtKhmc.TabIndex = 167
        '
        'LblKhmc
        '
        Me.LblKhmc.AutoSize = True
        Me.LblKhmc.Location = New System.Drawing.Point(220, 218)
        Me.LblKhmc.Name = "LblKhmc"
        Me.LblKhmc.Size = New System.Drawing.Size(65, 12)
        Me.LblKhmc.TabIndex = 166
        Me.LblKhmc.Text = "客户名称："
        '
        'TxtHth
        '
        Me.TxtHth.Location = New System.Drawing.Point(292, 187)
        Me.TxtHth.MaxLength = 11
        Me.TxtHth.Name = "TxtHth"
        Me.TxtHth.Size = New System.Drawing.Size(104, 21)
        Me.TxtHth.TabIndex = 163
        '
        'LblHth
        '
        Me.LblHth.AutoSize = True
        Me.LblHth.Location = New System.Drawing.Point(220, 190)
        Me.LblHth.Name = "LblHth"
        Me.LblHth.Size = New System.Drawing.Size(65, 12)
        Me.LblHth.TabIndex = 162
        Me.LblHth.Text = "订单编码："
        '
        'TxtCpmc
        '
        Me.TxtCpmc.Location = New System.Drawing.Point(292, 158)
        Me.TxtCpmc.MaxLength = 100
        Me.TxtCpmc.Name = "TxtCpmc"
        Me.TxtCpmc.Size = New System.Drawing.Size(104, 21)
        Me.TxtCpmc.TabIndex = 155
        '
        'LblCpmc
        '
        Me.LblCpmc.AutoSize = True
        Me.LblCpmc.Location = New System.Drawing.Point(220, 161)
        Me.LblCpmc.Name = "LblCpmc"
        Me.LblCpmc.Size = New System.Drawing.Size(65, 12)
        Me.LblCpmc.TabIndex = 154
        Me.LblCpmc.Text = "物料描述："
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RadioBtnQdrq)
        Me.GroupBox2.Controls.Add(Me.RadioBtnScjhrq)
        Me.GroupBox2.Location = New System.Drawing.Point(28, 22)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(368, 48)
        Me.GroupBox2.TabIndex = 143
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "选择按何日期"
        '
        'RadioBtnQdrq
        '
        Me.RadioBtnQdrq.Checked = True
        Me.RadioBtnQdrq.Location = New System.Drawing.Point(48, 16)
        Me.RadioBtnQdrq.Name = "RadioBtnQdrq"
        Me.RadioBtnQdrq.Size = New System.Drawing.Size(72, 24)
        Me.RadioBtnQdrq.TabIndex = 0
        Me.RadioBtnQdrq.TabStop = True
        Me.RadioBtnQdrq.Text = "签单日期"
        '
        'RadioBtnScjhrq
        '
        Me.RadioBtnScjhrq.Location = New System.Drawing.Point(232, 16)
        Me.RadioBtnScjhrq.Name = "RadioBtnScjhrq"
        Me.RadioBtnScjhrq.Size = New System.Drawing.Size(72, 24)
        Me.RadioBtnScjhrq.TabIndex = 1
        Me.RadioBtnScjhrq.Text = "生产交期"
        '
        'TxtSczydm
        '
        Me.TxtSczydm.Location = New System.Drawing.Point(100, 187)
        Me.TxtSczydm.MaxLength = 12
        Me.TxtSczydm.Name = "TxtSczydm"
        Me.TxtSczydm.Size = New System.Drawing.Size(104, 21)
        Me.TxtSczydm.TabIndex = 161
        '
        'LblSczydm
        '
        Me.LblSczydm.AutoSize = True
        Me.LblSczydm.Location = New System.Drawing.Point(29, 190)
        Me.LblSczydm.Name = "LblSczydm"
        Me.LblSczydm.Size = New System.Drawing.Size(65, 12)
        Me.LblSczydm.TabIndex = 160
        Me.LblSczydm.Text = "承 接 人："
        '
        'TxtZydm
        '
        Me.TxtZydm.Location = New System.Drawing.Point(100, 243)
        Me.TxtZydm.MaxLength = 12
        Me.TxtZydm.Name = "TxtZydm"
        Me.TxtZydm.Size = New System.Drawing.Size(87, 21)
        Me.TxtZydm.TabIndex = 169
        '
        'LblZydm
        '
        Me.LblZydm.AutoSize = True
        Me.LblZydm.Location = New System.Drawing.Point(29, 246)
        Me.LblZydm.Name = "LblZydm"
        Me.LblZydm.Size = New System.Drawing.Size(65, 12)
        Me.LblZydm.TabIndex = 168
        Me.LblZydm.Text = "业 务 员："
        '
        'TxtKhdm
        '
        Me.TxtKhdm.Location = New System.Drawing.Point(100, 215)
        Me.TxtKhdm.MaxLength = 15
        Me.TxtKhdm.Name = "TxtKhdm"
        Me.TxtKhdm.Size = New System.Drawing.Size(87, 21)
        Me.TxtKhdm.TabIndex = 165
        '
        'LblKhdm
        '
        Me.LblKhdm.AutoSize = True
        Me.LblKhdm.Location = New System.Drawing.Point(30, 218)
        Me.LblKhdm.Name = "LblKhdm"
        Me.LblKhdm.Size = New System.Drawing.Size(65, 12)
        Me.LblKhdm.TabIndex = 164
        Me.LblKhdm.Text = "客户编码："
        '
        'TxtCpdm
        '
        Me.TxtCpdm.Location = New System.Drawing.Point(100, 158)
        Me.TxtCpdm.MaxLength = 15
        Me.TxtCpdm.Name = "TxtCpdm"
        Me.TxtCpdm.Size = New System.Drawing.Size(112, 21)
        Me.TxtCpdm.TabIndex = 153
        '
        'LblCpdm
        '
        Me.LblCpdm.AutoSize = True
        Me.LblCpdm.Location = New System.Drawing.Point(29, 161)
        Me.LblCpdm.Name = "LblCpdm"
        Me.LblCpdm.Size = New System.Drawing.Size(65, 12)
        Me.LblCpdm.TabIndex = 152
        Me.LblCpdm.Text = "物料编码："
        '
        'NudDjhEnd
        '
        Me.NudDjhEnd.Location = New System.Drawing.Point(188, 118)
        Me.NudDjhEnd.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.NudDjhEnd.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudDjhEnd.Name = "NudDjhEnd"
        Me.NudDjhEnd.Size = New System.Drawing.Size(56, 21)
        Me.NudDjhEnd.TabIndex = 151
        Me.NudDjhEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudDjhEnd.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        '
        'LblDjhEnd
        '
        Me.LblDjhEnd.AutoSize = True
        Me.LblDjhEnd.Location = New System.Drawing.Point(164, 118)
        Me.LblDjhEnd.Name = "LblDjhEnd"
        Me.LblDjhEnd.Size = New System.Drawing.Size(17, 12)
        Me.LblDjhEnd.TabIndex = 150
        Me.LblDjhEnd.Text = "至"
        '
        'NudDjhBegin
        '
        Me.NudDjhBegin.Location = New System.Drawing.Point(100, 118)
        Me.NudDjhBegin.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.NudDjhBegin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudDjhBegin.Name = "NudDjhBegin"
        Me.NudDjhBegin.Size = New System.Drawing.Size(56, 21)
        Me.NudDjhBegin.TabIndex = 149
        Me.NudDjhBegin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudDjhBegin.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'LblDjhBegin
        '
        Me.LblDjhBegin.AutoSize = True
        Me.LblDjhBegin.Location = New System.Drawing.Point(30, 120)
        Me.LblDjhBegin.Name = "LblDjhBegin"
        Me.LblDjhBegin.Size = New System.Drawing.Size(65, 12)
        Me.LblDjhBegin.TabIndex = 148
        Me.LblDjhBegin.Text = "单 据 号："
        '
        'LblQdrqEnd
        '
        Me.LblQdrqEnd.AutoSize = True
        Me.LblQdrqEnd.Location = New System.Drawing.Point(220, 86)
        Me.LblQdrqEnd.Name = "LblQdrqEnd"
        Me.LblQdrqEnd.Size = New System.Drawing.Size(17, 12)
        Me.LblQdrqEnd.TabIndex = 146
        Me.LblQdrqEnd.Text = "至"
        '
        'DtpQdrqEnd
        '
        Me.DtpQdrqEnd.Location = New System.Drawing.Point(244, 86)
        Me.DtpQdrqEnd.Name = "DtpQdrqEnd"
        Me.DtpQdrqEnd.Size = New System.Drawing.Size(112, 21)
        Me.DtpQdrqEnd.TabIndex = 147
        '
        'LblQdrqBegin
        '
        Me.LblQdrqBegin.AutoSize = True
        Me.LblQdrqBegin.Location = New System.Drawing.Point(28, 86)
        Me.LblQdrqBegin.Name = "LblQdrqBegin"
        Me.LblQdrqBegin.Size = New System.Drawing.Size(65, 12)
        Me.LblQdrqBegin.TabIndex = 144
        Me.LblQdrqBegin.Text = "日    期："
        '
        'DtpQdrqBegin
        '
        Me.DtpQdrqBegin.Location = New System.Drawing.Point(100, 86)
        Me.DtpQdrqBegin.Name = "DtpQdrqBegin"
        Me.DtpQdrqBegin.Size = New System.Drawing.Size(112, 21)
        Me.DtpQdrqBegin.TabIndex = 145
        '
        'FrmPmDdGxlzCx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 330)
        Me.Controls.Add(Me.TxtKhmc)
        Me.Controls.Add(Me.LblKhmc)
        Me.Controls.Add(Me.TxtHth)
        Me.Controls.Add(Me.LblHth)
        Me.Controls.Add(Me.TxtCpmc)
        Me.Controls.Add(Me.LblCpmc)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TxtSczydm)
        Me.Controls.Add(Me.LblSczydm)
        Me.Controls.Add(Me.TxtZydm)
        Me.Controls.Add(Me.LblZydm)
        Me.Controls.Add(Me.TxtKhdm)
        Me.Controls.Add(Me.LblKhdm)
        Me.Controls.Add(Me.TxtCpdm)
        Me.Controls.Add(Me.LblCpdm)
        Me.Controls.Add(Me.NudDjhEnd)
        Me.Controls.Add(Me.LblDjhEnd)
        Me.Controls.Add(Me.NudDjhBegin)
        Me.Controls.Add(Me.LblDjhBegin)
        Me.Controls.Add(Me.LblQdrqEnd)
        Me.Controls.Add(Me.DtpQdrqEnd)
        Me.Controls.Add(Me.LblQdrqBegin)
        Me.Controls.Add(Me.DtpQdrqBegin)
        Me.Name = "FrmPmDdGxlzCx"
        Me.Text = "订单生产跟踪查询范围"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.DtpQdrqBegin, 0)
        Me.Controls.SetChildIndex(Me.LblQdrqBegin, 0)
        Me.Controls.SetChildIndex(Me.DtpQdrqEnd, 0)
        Me.Controls.SetChildIndex(Me.LblQdrqEnd, 0)
        Me.Controls.SetChildIndex(Me.LblDjhBegin, 0)
        Me.Controls.SetChildIndex(Me.NudDjhBegin, 0)
        Me.Controls.SetChildIndex(Me.LblDjhEnd, 0)
        Me.Controls.SetChildIndex(Me.NudDjhEnd, 0)
        Me.Controls.SetChildIndex(Me.LblCpdm, 0)
        Me.Controls.SetChildIndex(Me.TxtCpdm, 0)
        Me.Controls.SetChildIndex(Me.LblKhdm, 0)
        Me.Controls.SetChildIndex(Me.TxtKhdm, 0)
        Me.Controls.SetChildIndex(Me.LblZydm, 0)
        Me.Controls.SetChildIndex(Me.TxtZydm, 0)
        Me.Controls.SetChildIndex(Me.LblSczydm, 0)
        Me.Controls.SetChildIndex(Me.TxtSczydm, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.LblCpmc, 0)
        Me.Controls.SetChildIndex(Me.TxtCpmc, 0)
        Me.Controls.SetChildIndex(Me.LblHth, 0)
        Me.Controls.SetChildIndex(Me.TxtHth, 0)
        Me.Controls.SetChildIndex(Me.LblKhmc, 0)
        Me.Controls.SetChildIndex(Me.TxtKhmc, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.NudDjhEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudDjhBegin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents TxtKhmc As System.Windows.Forms.TextBox
    Public WithEvents LblKhmc As System.Windows.Forms.Label
    Public WithEvents TxtHth As System.Windows.Forms.TextBox
    Public WithEvents LblHth As System.Windows.Forms.Label
    Public WithEvents TxtCpmc As System.Windows.Forms.TextBox
    Public WithEvents LblCpmc As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioBtnQdrq As System.Windows.Forms.RadioButton
    Friend WithEvents RadioBtnScjhrq As System.Windows.Forms.RadioButton
    Public WithEvents TxtSczydm As System.Windows.Forms.TextBox
    Public WithEvents LblSczydm As System.Windows.Forms.Label
    Public WithEvents TxtZydm As System.Windows.Forms.TextBox
    Public WithEvents LblZydm As System.Windows.Forms.Label
    Public WithEvents TxtKhdm As System.Windows.Forms.TextBox
    Public WithEvents LblKhdm As System.Windows.Forms.Label
    Public WithEvents TxtCpdm As System.Windows.Forms.TextBox
    Public WithEvents LblCpdm As System.Windows.Forms.Label
    Public WithEvents NudDjhEnd As System.Windows.Forms.NumericUpDown
    Public WithEvents LblDjhEnd As System.Windows.Forms.Label
    Public WithEvents NudDjhBegin As System.Windows.Forms.NumericUpDown
    Public WithEvents LblDjhBegin As System.Windows.Forms.Label
    Public WithEvents LblQdrqEnd As System.Windows.Forms.Label
    Public WithEvents DtpQdrqEnd As System.Windows.Forms.DateTimePicker
    Public WithEvents LblQdrqBegin As System.Windows.Forms.Label
    Public WithEvents DtpQdrqBegin As System.Windows.Forms.DateTimePicker
End Class
