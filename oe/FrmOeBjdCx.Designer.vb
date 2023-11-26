<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeBjdCx
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
        Me.TxtCpgg = New System.Windows.Forms.TextBox
        Me.LblCpgg = New System.Windows.Forms.Label
        Me.TxtKhlh = New System.Windows.Forms.TextBox
        Me.LblKhlh = New System.Windows.Forms.Label
        Me.TxtCpmc = New System.Windows.Forms.TextBox
        Me.LblCpmc = New System.Windows.Forms.Label
        Me.TxtKhdm = New System.Windows.Forms.TextBox
        Me.LblKhdm = New System.Windows.Forms.Label
        Me.ChbLbfs = New System.Windows.Forms.CheckBox
        Me.TxtCpdm = New System.Windows.Forms.TextBox
        Me.LblCpdm = New System.Windows.Forms.Label
        Me.NudDjhEnd = New System.Windows.Forms.NumericUpDown
        Me.LblDjhEnd = New System.Windows.Forms.Label
        Me.NudDjhBegin = New System.Windows.Forms.NumericUpDown
        Me.LblDjhBegin = New System.Windows.Forms.Label
        Me.LblBjrqEnd = New System.Windows.Forms.Label
        Me.DtpBjrqEnd = New System.Windows.Forms.DateTimePicker
        Me.LblBjrqBegin = New System.Windows.Forms.Label
        Me.DtpBjrqBegin = New System.Windows.Forms.DateTimePicker
        Me.CmbPzlxjc = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.DlgPanel.SuspendLayout()
        CType(Me.NudDjhEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudDjhBegin, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.DlgPanel.Location = New System.Drawing.Point(192, 243)
        Me.DlgPanel.TabIndex = 23
        '
        'TxtKhmc
        '
        Me.TxtKhmc.Location = New System.Drawing.Point(302, 138)
        Me.TxtKhmc.MaxLength = 15
        Me.TxtKhmc.Name = "TxtKhmc"
        Me.TxtKhmc.Size = New System.Drawing.Size(104, 21)
        Me.TxtKhmc.TabIndex = 17
        '
        'LblKhmc
        '
        Me.LblKhmc.AutoSize = True
        Me.LblKhmc.Location = New System.Drawing.Point(231, 142)
        Me.LblKhmc.Name = "LblKhmc"
        Me.LblKhmc.Size = New System.Drawing.Size(65, 12)
        Me.LblKhmc.TabIndex = 16
        Me.LblKhmc.Text = "客户名称："
        '
        'TxtCpgg
        '
        Me.TxtCpgg.Location = New System.Drawing.Point(110, 167)
        Me.TxtCpgg.MaxLength = 15
        Me.TxtCpgg.Name = "TxtCpgg"
        Me.TxtCpgg.Size = New System.Drawing.Size(104, 21)
        Me.TxtCpgg.TabIndex = 19
        '
        'LblCpgg
        '
        Me.LblCpgg.AutoSize = True
        Me.LblCpgg.Location = New System.Drawing.Point(39, 171)
        Me.LblCpgg.Name = "LblCpgg"
        Me.LblCpgg.Size = New System.Drawing.Size(65, 12)
        Me.LblCpgg.TabIndex = 18
        Me.LblCpgg.Text = "规格型号："
        '
        'TxtKhlh
        '
        Me.TxtKhlh.Location = New System.Drawing.Point(302, 167)
        Me.TxtKhlh.MaxLength = 50
        Me.TxtKhlh.Name = "TxtKhlh"
        Me.TxtKhlh.Size = New System.Drawing.Size(104, 21)
        Me.TxtKhlh.TabIndex = 21
        '
        'LblKhlh
        '
        Me.LblKhlh.AutoSize = True
        Me.LblKhlh.Location = New System.Drawing.Point(231, 171)
        Me.LblKhlh.Name = "LblKhlh"
        Me.LblKhlh.Size = New System.Drawing.Size(65, 12)
        Me.LblKhlh.TabIndex = 20
        Me.LblKhlh.Text = "客户型号："
        '
        'TxtCpmc
        '
        Me.TxtCpmc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCpmc.Location = New System.Drawing.Point(110, 138)
        Me.TxtCpmc.MaxLength = 15
        Me.TxtCpmc.Name = "TxtCpmc"
        Me.TxtCpmc.Size = New System.Drawing.Size(104, 21)
        Me.TxtCpmc.TabIndex = 15
        '
        'LblCpmc
        '
        Me.LblCpmc.AutoSize = True
        Me.LblCpmc.Location = New System.Drawing.Point(38, 142)
        Me.LblCpmc.Name = "LblCpmc"
        Me.LblCpmc.Size = New System.Drawing.Size(65, 12)
        Me.LblCpmc.TabIndex = 14
        Me.LblCpmc.Text = "产品名称："
        '
        'TxtKhdm
        '
        Me.TxtKhdm.Location = New System.Drawing.Point(302, 109)
        Me.TxtKhdm.MaxLength = 12
        Me.TxtKhdm.Name = "TxtKhdm"
        Me.TxtKhdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtKhdm.TabIndex = 13
        '
        'LblKhdm
        '
        Me.LblKhdm.AutoSize = True
        Me.LblKhdm.Location = New System.Drawing.Point(231, 113)
        Me.LblKhdm.Name = "LblKhdm"
        Me.LblKhdm.Size = New System.Drawing.Size(65, 12)
        Me.LblKhdm.TabIndex = 12
        Me.LblKhdm.Text = "客户编码："
        '
        'ChbLbfs
        '
        Me.ChbLbfs.Checked = True
        Me.ChbLbfs.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChbLbfs.Location = New System.Drawing.Point(176, 202)
        Me.ChbLbfs.Name = "ChbLbfs"
        Me.ChbLbfs.Size = New System.Drawing.Size(104, 24)
        Me.ChbLbfs.TabIndex = 22
        Me.ChbLbfs.Text = "列表方式查询"
        '
        'TxtCpdm
        '
        Me.TxtCpdm.Location = New System.Drawing.Point(110, 109)
        Me.TxtCpdm.MaxLength = 15
        Me.TxtCpdm.Name = "TxtCpdm"
        Me.TxtCpdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtCpdm.TabIndex = 11
        '
        'LblCpdm
        '
        Me.LblCpdm.AutoSize = True
        Me.LblCpdm.Location = New System.Drawing.Point(38, 113)
        Me.LblCpdm.Name = "LblCpdm"
        Me.LblCpdm.Size = New System.Drawing.Size(65, 12)
        Me.LblCpdm.TabIndex = 10
        Me.LblCpdm.Text = "产品编码："
        '
        'NudDjhEnd
        '
        Me.NudDjhEnd.Location = New System.Drawing.Point(198, 80)
        Me.NudDjhEnd.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.NudDjhEnd.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudDjhEnd.Name = "NudDjhEnd"
        Me.NudDjhEnd.Size = New System.Drawing.Size(56, 21)
        Me.NudDjhEnd.TabIndex = 9
        Me.NudDjhEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudDjhEnd.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        '
        'LblDjhEnd
        '
        Me.LblDjhEnd.AutoSize = True
        Me.LblDjhEnd.Location = New System.Drawing.Point(174, 84)
        Me.LblDjhEnd.Name = "LblDjhEnd"
        Me.LblDjhEnd.Size = New System.Drawing.Size(17, 12)
        Me.LblDjhEnd.TabIndex = 8
        Me.LblDjhEnd.Text = "至"
        '
        'NudDjhBegin
        '
        Me.NudDjhBegin.Location = New System.Drawing.Point(110, 80)
        Me.NudDjhBegin.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.NudDjhBegin.Name = "NudDjhBegin"
        Me.NudDjhBegin.Size = New System.Drawing.Size(56, 21)
        Me.NudDjhBegin.TabIndex = 7
        Me.NudDjhBegin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudDjhBegin.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'LblDjhBegin
        '
        Me.LblDjhBegin.AutoSize = True
        Me.LblDjhBegin.Location = New System.Drawing.Point(38, 84)
        Me.LblDjhBegin.Name = "LblDjhBegin"
        Me.LblDjhBegin.Size = New System.Drawing.Size(65, 12)
        Me.LblDjhBegin.TabIndex = 6
        Me.LblDjhBegin.Text = "单 据 号："
        '
        'LblBjrqEnd
        '
        Me.LblBjrqEnd.AutoSize = True
        Me.LblBjrqEnd.Location = New System.Drawing.Point(230, 23)
        Me.LblBjrqEnd.Name = "LblBjrqEnd"
        Me.LblBjrqEnd.Size = New System.Drawing.Size(17, 12)
        Me.LblBjrqEnd.TabIndex = 2
        Me.LblBjrqEnd.Text = "至"
        '
        'DtpBjrqEnd
        '
        Me.DtpBjrqEnd.Location = New System.Drawing.Point(254, 23)
        Me.DtpBjrqEnd.Name = "DtpBjrqEnd"
        Me.DtpBjrqEnd.Size = New System.Drawing.Size(112, 21)
        Me.DtpBjrqEnd.TabIndex = 3
        '
        'LblBjrqBegin
        '
        Me.LblBjrqBegin.AutoSize = True
        Me.LblBjrqBegin.Location = New System.Drawing.Point(38, 23)
        Me.LblBjrqBegin.Name = "LblBjrqBegin"
        Me.LblBjrqBegin.Size = New System.Drawing.Size(65, 12)
        Me.LblBjrqBegin.TabIndex = 0
        Me.LblBjrqBegin.Text = "报价日期："
        '
        'DtpBjrqBegin
        '
        Me.DtpBjrqBegin.Location = New System.Drawing.Point(110, 23)
        Me.DtpBjrqBegin.Name = "DtpBjrqBegin"
        Me.DtpBjrqBegin.Size = New System.Drawing.Size(112, 21)
        Me.DtpBjrqBegin.TabIndex = 1
        '
        'CmbPzlxjc
        '
        Me.CmbPzlxjc.Location = New System.Drawing.Point(110, 52)
        Me.CmbPzlxjc.Name = "CmbPzlxjc"
        Me.CmbPzlxjc.Size = New System.Drawing.Size(72, 20)
        Me.CmbPzlxjc.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(39, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "单据类型："
        '
        'FrmOeBjdCx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(445, 286)
        Me.Controls.Add(Me.CmbPzlxjc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtKhmc)
        Me.Controls.Add(Me.LblKhmc)
        Me.Controls.Add(Me.TxtCpgg)
        Me.Controls.Add(Me.LblCpgg)
        Me.Controls.Add(Me.TxtKhlh)
        Me.Controls.Add(Me.LblKhlh)
        Me.Controls.Add(Me.TxtCpmc)
        Me.Controls.Add(Me.LblCpmc)
        Me.Controls.Add(Me.TxtKhdm)
        Me.Controls.Add(Me.LblKhdm)
        Me.Controls.Add(Me.ChbLbfs)
        Me.Controls.Add(Me.TxtCpdm)
        Me.Controls.Add(Me.LblCpdm)
        Me.Controls.Add(Me.NudDjhEnd)
        Me.Controls.Add(Me.LblDjhEnd)
        Me.Controls.Add(Me.NudDjhBegin)
        Me.Controls.Add(Me.LblDjhBegin)
        Me.Controls.Add(Me.LblBjrqEnd)
        Me.Controls.Add(Me.DtpBjrqEnd)
        Me.Controls.Add(Me.LblBjrqBegin)
        Me.Controls.Add(Me.DtpBjrqBegin)
        Me.Name = "FrmOeBjdCx"
        Me.Text = "报价单查询范围"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.DtpBjrqBegin, 0)
        Me.Controls.SetChildIndex(Me.LblBjrqBegin, 0)
        Me.Controls.SetChildIndex(Me.DtpBjrqEnd, 0)
        Me.Controls.SetChildIndex(Me.LblBjrqEnd, 0)
        Me.Controls.SetChildIndex(Me.LblDjhBegin, 0)
        Me.Controls.SetChildIndex(Me.NudDjhBegin, 0)
        Me.Controls.SetChildIndex(Me.LblDjhEnd, 0)
        Me.Controls.SetChildIndex(Me.NudDjhEnd, 0)
        Me.Controls.SetChildIndex(Me.LblCpdm, 0)
        Me.Controls.SetChildIndex(Me.TxtCpdm, 0)
        Me.Controls.SetChildIndex(Me.ChbLbfs, 0)
        Me.Controls.SetChildIndex(Me.LblKhdm, 0)
        Me.Controls.SetChildIndex(Me.TxtKhdm, 0)
        Me.Controls.SetChildIndex(Me.LblCpmc, 0)
        Me.Controls.SetChildIndex(Me.TxtCpmc, 0)
        Me.Controls.SetChildIndex(Me.LblKhlh, 0)
        Me.Controls.SetChildIndex(Me.TxtKhlh, 0)
        Me.Controls.SetChildIndex(Me.LblCpgg, 0)
        Me.Controls.SetChildIndex(Me.TxtCpgg, 0)
        Me.Controls.SetChildIndex(Me.LblKhmc, 0)
        Me.Controls.SetChildIndex(Me.TxtKhmc, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.CmbPzlxjc, 0)
        Me.DlgPanel.ResumeLayout(False)
        CType(Me.NudDjhEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudDjhBegin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents TxtKhmc As System.Windows.Forms.TextBox
    Public WithEvents LblKhmc As System.Windows.Forms.Label
    Public WithEvents TxtCpgg As System.Windows.Forms.TextBox
    Public WithEvents LblCpgg As System.Windows.Forms.Label
    Public WithEvents TxtKhlh As System.Windows.Forms.TextBox
    Public WithEvents LblKhlh As System.Windows.Forms.Label
    Public WithEvents TxtCpmc As System.Windows.Forms.TextBox
    Public WithEvents LblCpmc As System.Windows.Forms.Label
    Public WithEvents TxtKhdm As System.Windows.Forms.TextBox
    Public WithEvents LblKhdm As System.Windows.Forms.Label
    Friend WithEvents ChbLbfs As System.Windows.Forms.CheckBox
    Public WithEvents TxtCpdm As System.Windows.Forms.TextBox
    Public WithEvents LblCpdm As System.Windows.Forms.Label
    Public WithEvents NudDjhEnd As System.Windows.Forms.NumericUpDown
    Public WithEvents LblDjhEnd As System.Windows.Forms.Label
    Public WithEvents NudDjhBegin As System.Windows.Forms.NumericUpDown
    Public WithEvents LblDjhBegin As System.Windows.Forms.Label
    Public WithEvents LblBjrqEnd As System.Windows.Forms.Label
    Public WithEvents DtpBjrqEnd As System.Windows.Forms.DateTimePicker
    Public WithEvents LblBjrqBegin As System.Windows.Forms.Label
    Public WithEvents DtpBjrqBegin As System.Windows.Forms.DateTimePicker
    Friend WithEvents CmbPzlxjc As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
