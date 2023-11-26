<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeDdCx
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
        Me.ChbWck = New System.Windows.Forms.CheckBox
        Me.ChbWhx = New System.Windows.Forms.CheckBox
        Me.ChbHx = New System.Windows.Forms.CheckBox
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
        Me.ChbLbfs = New System.Windows.Forms.CheckBox
        Me.TxtCpdm = New System.Windows.Forms.TextBox
        Me.LblCpdm = New System.Windows.Forms.Label
        Me.NudDjhEnd = New System.Windows.Forms.NumericUpDown
        Me.LblDjhEnd = New System.Windows.Forms.Label
        Me.NudDjhBegin = New System.Windows.Forms.NumericUpDown
        Me.LblDjhBegin = New System.Windows.Forms.Label
        Me.LblQdrqEnd = New System.Windows.Forms.Label
        Me.DtpEnd = New System.Windows.Forms.DateTimePicker
        Me.LblQdrqBegin = New System.Windows.Forms.Label
        Me.DtpBegin = New System.Windows.Forms.DateTimePicker
        Me.ChbSh = New System.Windows.Forms.CheckBox
        Me.CmbPzlxjc = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtKhddh = New System.Windows.Forms.TextBox
        Me.LblKhddh = New System.Windows.Forms.Label
        Me.TxtKhlh = New System.Windows.Forms.TextBox
        Me.LblKhlh = New System.Windows.Forms.Label
        Me.ChbWsk = New System.Windows.Forms.CheckBox
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
        Me.DlgPanel.Location = New System.Drawing.Point(171, 412)
        Me.DlgPanel.TabIndex = 35
        '
        'TxtKhmc
        '
        Me.TxtKhmc.Location = New System.Drawing.Point(293, 234)
        Me.TxtKhmc.MaxLength = 15
        Me.TxtKhmc.Name = "TxtKhmc"
        Me.TxtKhmc.Size = New System.Drawing.Size(104, 21)
        Me.TxtKhmc.TabIndex = 22
        '
        'LblKhmc
        '
        Me.LblKhmc.AutoSize = True
        Me.LblKhmc.Location = New System.Drawing.Point(222, 238)
        Me.LblKhmc.Name = "LblKhmc"
        Me.LblKhmc.Size = New System.Drawing.Size(65, 12)
        Me.LblKhmc.TabIndex = 21
        Me.LblKhmc.Text = "客户名称："
        '
        'ChbWck
        '
        Me.ChbWck.ForeColor = System.Drawing.Color.SteelBlue
        Me.ChbWck.Location = New System.Drawing.Point(254, 327)
        Me.ChbWck.Name = "ChbWck"
        Me.ChbWck.Size = New System.Drawing.Size(143, 16)
        Me.ChbWck.TabIndex = 30
        Me.ChbWck.Text = "只显示未发货的订单"
        '
        'ChbWhx
        '
        Me.ChbWhx.ForeColor = System.Drawing.Color.SteelBlue
        Me.ChbWhx.Location = New System.Drawing.Point(37, 351)
        Me.ChbWhx.Name = "ChbWhx"
        Me.ChbWhx.Size = New System.Drawing.Size(211, 16)
        Me.ChbWhx.TabIndex = 31
        Me.ChbWhx.Text = "只显示退货（红字未核销）的订单"
        '
        'ChbHx
        '
        Me.ChbHx.ForeColor = System.Drawing.Color.SteelBlue
        Me.ChbHx.Location = New System.Drawing.Point(254, 351)
        Me.ChbHx.Name = "ChbHx"
        Me.ChbHx.Size = New System.Drawing.Size(143, 16)
        Me.ChbHx.TabIndex = 32
        Me.ChbHx.Text = "包含全额冲销订单"
        '
        'TxtHth
        '
        Me.TxtHth.Location = New System.Drawing.Point(293, 205)
        Me.TxtHth.MaxLength = 11
        Me.TxtHth.Name = "TxtHth"
        Me.TxtHth.Size = New System.Drawing.Size(104, 21)
        Me.TxtHth.TabIndex = 18
        '
        'LblHth
        '
        Me.LblHth.AutoSize = True
        Me.LblHth.Location = New System.Drawing.Point(210, 209)
        Me.LblHth.Name = "LblHth"
        Me.LblHth.Size = New System.Drawing.Size(77, 12)
        Me.LblHth.TabIndex = 17
        Me.LblHth.Text = "手工订单号："
        '
        'TxtCpmc
        '
        Me.TxtCpmc.Location = New System.Drawing.Point(293, 176)
        Me.TxtCpmc.MaxLength = 100
        Me.TxtCpmc.Name = "TxtCpmc"
        Me.TxtCpmc.Size = New System.Drawing.Size(104, 21)
        Me.TxtCpmc.TabIndex = 14
        '
        'LblCpmc
        '
        Me.LblCpmc.AutoSize = True
        Me.LblCpmc.Location = New System.Drawing.Point(222, 180)
        Me.LblCpmc.Name = "LblCpmc"
        Me.LblCpmc.Size = New System.Drawing.Size(65, 12)
        Me.LblCpmc.TabIndex = 13
        Me.LblCpmc.Text = "产品描述："
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RadioBtnQdrq)
        Me.GroupBox2.Controls.Add(Me.RadioBtnScjhrq)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 19)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(368, 48)
        Me.GroupBox2.TabIndex = 0
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
        Me.TxtSczydm.Location = New System.Drawing.Point(101, 205)
        Me.TxtSczydm.MaxLength = 12
        Me.TxtSczydm.Name = "TxtSczydm"
        Me.TxtSczydm.Size = New System.Drawing.Size(104, 21)
        Me.TxtSczydm.TabIndex = 16
        '
        'LblSczydm
        '
        Me.LblSczydm.AutoSize = True
        Me.LblSczydm.Location = New System.Drawing.Point(30, 209)
        Me.LblSczydm.Name = "LblSczydm"
        Me.LblSczydm.Size = New System.Drawing.Size(65, 12)
        Me.LblSczydm.TabIndex = 15
        Me.LblSczydm.Text = "承 接 人："
        '
        'TxtZydm
        '
        Me.TxtZydm.Location = New System.Drawing.Point(101, 263)
        Me.TxtZydm.MaxLength = 12
        Me.TxtZydm.Name = "TxtZydm"
        Me.TxtZydm.Size = New System.Drawing.Size(104, 21)
        Me.TxtZydm.TabIndex = 24
        '
        'LblZydm
        '
        Me.LblZydm.AutoSize = True
        Me.LblZydm.Location = New System.Drawing.Point(30, 267)
        Me.LblZydm.Name = "LblZydm"
        Me.LblZydm.Size = New System.Drawing.Size(65, 12)
        Me.LblZydm.TabIndex = 23
        Me.LblZydm.Text = "业 务 员："
        '
        'TxtKhdm
        '
        Me.TxtKhdm.Location = New System.Drawing.Point(101, 234)
        Me.TxtKhdm.MaxLength = 15
        Me.TxtKhdm.Name = "TxtKhdm"
        Me.TxtKhdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtKhdm.TabIndex = 20
        '
        'LblKhdm
        '
        Me.LblKhdm.AutoSize = True
        Me.LblKhdm.Location = New System.Drawing.Point(30, 238)
        Me.LblKhdm.Name = "LblKhdm"
        Me.LblKhdm.Size = New System.Drawing.Size(65, 12)
        Me.LblKhdm.TabIndex = 19
        Me.LblKhdm.Text = "客户编码："
        '
        'ChbLbfs
        '
        Me.ChbLbfs.Checked = True
        Me.ChbLbfs.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChbLbfs.ForeColor = System.Drawing.Color.SteelBlue
        Me.ChbLbfs.Location = New System.Drawing.Point(254, 375)
        Me.ChbLbfs.Name = "ChbLbfs"
        Me.ChbLbfs.Size = New System.Drawing.Size(113, 16)
        Me.ChbLbfs.TabIndex = 34
        Me.ChbLbfs.Text = "列表方式查询"
        '
        'TxtCpdm
        '
        Me.TxtCpdm.Location = New System.Drawing.Point(101, 176)
        Me.TxtCpdm.MaxLength = 15
        Me.TxtCpdm.Name = "TxtCpdm"
        Me.TxtCpdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtCpdm.TabIndex = 12
        '
        'LblCpdm
        '
        Me.LblCpdm.AutoSize = True
        Me.LblCpdm.Location = New System.Drawing.Point(30, 180)
        Me.LblCpdm.Name = "LblCpdm"
        Me.LblCpdm.Size = New System.Drawing.Size(65, 12)
        Me.LblCpdm.TabIndex = 11
        Me.LblCpdm.Text = "产品编码："
        '
        'NudDjhEnd
        '
        Me.NudDjhEnd.Location = New System.Drawing.Point(189, 136)
        Me.NudDjhEnd.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.NudDjhEnd.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudDjhEnd.Name = "NudDjhEnd"
        Me.NudDjhEnd.Size = New System.Drawing.Size(56, 21)
        Me.NudDjhEnd.TabIndex = 10
        Me.NudDjhEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudDjhEnd.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        '
        'LblDjhEnd
        '
        Me.LblDjhEnd.AutoSize = True
        Me.LblDjhEnd.Location = New System.Drawing.Point(165, 136)
        Me.LblDjhEnd.Name = "LblDjhEnd"
        Me.LblDjhEnd.Size = New System.Drawing.Size(17, 12)
        Me.LblDjhEnd.TabIndex = 9
        Me.LblDjhEnd.Text = "至"
        '
        'NudDjhBegin
        '
        Me.NudDjhBegin.Location = New System.Drawing.Point(101, 136)
        Me.NudDjhBegin.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.NudDjhBegin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudDjhBegin.Name = "NudDjhBegin"
        Me.NudDjhBegin.Size = New System.Drawing.Size(56, 21)
        Me.NudDjhBegin.TabIndex = 8
        Me.NudDjhBegin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudDjhBegin.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'LblDjhBegin
        '
        Me.LblDjhBegin.AutoSize = True
        Me.LblDjhBegin.Location = New System.Drawing.Point(31, 138)
        Me.LblDjhBegin.Name = "LblDjhBegin"
        Me.LblDjhBegin.Size = New System.Drawing.Size(65, 12)
        Me.LblDjhBegin.TabIndex = 7
        Me.LblDjhBegin.Text = "单 据 号："
        '
        'LblQdrqEnd
        '
        Me.LblQdrqEnd.AutoSize = True
        Me.LblQdrqEnd.Location = New System.Drawing.Point(221, 87)
        Me.LblQdrqEnd.Name = "LblQdrqEnd"
        Me.LblQdrqEnd.Size = New System.Drawing.Size(17, 12)
        Me.LblQdrqEnd.TabIndex = 3
        Me.LblQdrqEnd.Text = "至"
        '
        'DtpEnd
        '
        Me.DtpEnd.Location = New System.Drawing.Point(245, 83)
        Me.DtpEnd.Name = "DtpEnd"
        Me.DtpEnd.Size = New System.Drawing.Size(112, 21)
        Me.DtpEnd.TabIndex = 4
        '
        'LblQdrqBegin
        '
        Me.LblQdrqBegin.AutoSize = True
        Me.LblQdrqBegin.Location = New System.Drawing.Point(29, 87)
        Me.LblQdrqBegin.Name = "LblQdrqBegin"
        Me.LblQdrqBegin.Size = New System.Drawing.Size(65, 12)
        Me.LblQdrqBegin.TabIndex = 1
        Me.LblQdrqBegin.Text = "日    期："
        '
        'DtpBegin
        '
        Me.DtpBegin.Location = New System.Drawing.Point(101, 83)
        Me.DtpBegin.Name = "DtpBegin"
        Me.DtpBegin.Size = New System.Drawing.Size(112, 21)
        Me.DtpBegin.TabIndex = 2
        '
        'ChbSh
        '
        Me.ChbSh.Checked = True
        Me.ChbSh.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChbSh.ForeColor = System.Drawing.Color.SteelBlue
        Me.ChbSh.Location = New System.Drawing.Point(37, 327)
        Me.ChbSh.Name = "ChbSh"
        Me.ChbSh.Size = New System.Drawing.Size(120, 16)
        Me.ChbSh.TabIndex = 29
        Me.ChbSh.Text = "包含未审核订单"
        '
        'CmbPzlxjc
        '
        Me.CmbPzlxjc.Location = New System.Drawing.Point(101, 110)
        Me.CmbPzlxjc.Name = "CmbPzlxjc"
        Me.CmbPzlxjc.Size = New System.Drawing.Size(72, 20)
        Me.CmbPzlxjc.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "单据类型："
        '
        'TxtKhddh
        '
        Me.TxtKhddh.Location = New System.Drawing.Point(101, 292)
        Me.TxtKhddh.MaxLength = 12
        Me.TxtKhddh.Name = "TxtKhddh"
        Me.TxtKhddh.Size = New System.Drawing.Size(104, 21)
        Me.TxtKhddh.TabIndex = 26
        '
        'LblKhddh
        '
        Me.LblKhddh.AutoSize = True
        Me.LblKhddh.Location = New System.Drawing.Point(18, 296)
        Me.LblKhddh.Name = "LblKhddh"
        Me.LblKhddh.Size = New System.Drawing.Size(77, 12)
        Me.LblKhddh.TabIndex = 25
        Me.LblKhddh.Text = "客户订单号："
        '
        'TxtKhlh
        '
        Me.TxtKhlh.Location = New System.Drawing.Point(293, 292)
        Me.TxtKhlh.MaxLength = 12
        Me.TxtKhlh.Name = "TxtKhlh"
        Me.TxtKhlh.Size = New System.Drawing.Size(104, 21)
        Me.TxtKhlh.TabIndex = 28
        '
        'LblKhlh
        '
        Me.LblKhlh.AutoSize = True
        Me.LblKhlh.Location = New System.Drawing.Point(222, 296)
        Me.LblKhlh.Name = "LblKhlh"
        Me.LblKhlh.Size = New System.Drawing.Size(65, 12)
        Me.LblKhlh.TabIndex = 27
        Me.LblKhlh.Text = "客户料号："
        '
        'ChbWsk
        '
        Me.ChbWsk.ForeColor = System.Drawing.Color.SteelBlue
        Me.ChbWsk.Location = New System.Drawing.Point(37, 375)
        Me.ChbWsk.Name = "ChbWsk"
        Me.ChbWsk.Size = New System.Drawing.Size(143, 16)
        Me.ChbWsk.TabIndex = 33
        Me.ChbWsk.Text = "只显示待收款清单"
        '
        'FrmOeDdCx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 455)
        Me.Controls.Add(Me.ChbWsk)
        Me.Controls.Add(Me.TxtKhlh)
        Me.Controls.Add(Me.LblKhlh)
        Me.Controls.Add(Me.TxtKhddh)
        Me.Controls.Add(Me.LblKhddh)
        Me.Controls.Add(Me.CmbPzlxjc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ChbSh)
        Me.Controls.Add(Me.TxtKhmc)
        Me.Controls.Add(Me.LblKhmc)
        Me.Controls.Add(Me.ChbWck)
        Me.Controls.Add(Me.ChbWhx)
        Me.Controls.Add(Me.ChbHx)
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
        Me.Controls.Add(Me.ChbLbfs)
        Me.Controls.Add(Me.TxtCpdm)
        Me.Controls.Add(Me.LblCpdm)
        Me.Controls.Add(Me.NudDjhEnd)
        Me.Controls.Add(Me.LblDjhEnd)
        Me.Controls.Add(Me.NudDjhBegin)
        Me.Controls.Add(Me.LblDjhBegin)
        Me.Controls.Add(Me.LblQdrqEnd)
        Me.Controls.Add(Me.DtpEnd)
        Me.Controls.Add(Me.LblQdrqBegin)
        Me.Controls.Add(Me.DtpBegin)
        Me.Name = "FrmOeDdCx"
        Me.Text = "产品销售订单查询范围"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.DtpBegin, 0)
        Me.Controls.SetChildIndex(Me.LblQdrqBegin, 0)
        Me.Controls.SetChildIndex(Me.DtpEnd, 0)
        Me.Controls.SetChildIndex(Me.LblQdrqEnd, 0)
        Me.Controls.SetChildIndex(Me.LblDjhBegin, 0)
        Me.Controls.SetChildIndex(Me.NudDjhBegin, 0)
        Me.Controls.SetChildIndex(Me.LblDjhEnd, 0)
        Me.Controls.SetChildIndex(Me.NudDjhEnd, 0)
        Me.Controls.SetChildIndex(Me.LblCpdm, 0)
        Me.Controls.SetChildIndex(Me.TxtCpdm, 0)
        Me.Controls.SetChildIndex(Me.ChbLbfs, 0)
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
        Me.Controls.SetChildIndex(Me.ChbHx, 0)
        Me.Controls.SetChildIndex(Me.ChbWhx, 0)
        Me.Controls.SetChildIndex(Me.ChbWck, 0)
        Me.Controls.SetChildIndex(Me.LblKhmc, 0)
        Me.Controls.SetChildIndex(Me.TxtKhmc, 0)
        Me.Controls.SetChildIndex(Me.ChbSh, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.CmbPzlxjc, 0)
        Me.Controls.SetChildIndex(Me.LblKhddh, 0)
        Me.Controls.SetChildIndex(Me.TxtKhddh, 0)
        Me.Controls.SetChildIndex(Me.LblKhlh, 0)
        Me.Controls.SetChildIndex(Me.TxtKhlh, 0)
        Me.Controls.SetChildIndex(Me.ChbWsk, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.NudDjhEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudDjhBegin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents TxtKhmc As System.Windows.Forms.TextBox
    Public WithEvents LblKhmc As System.Windows.Forms.Label
    Friend WithEvents ChbWck As System.Windows.Forms.CheckBox
    Friend WithEvents ChbWhx As System.Windows.Forms.CheckBox
    Friend WithEvents ChbHx As System.Windows.Forms.CheckBox
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
    Friend WithEvents ChbLbfs As System.Windows.Forms.CheckBox
    Public WithEvents TxtCpdm As System.Windows.Forms.TextBox
    Public WithEvents LblCpdm As System.Windows.Forms.Label
    Public WithEvents NudDjhEnd As System.Windows.Forms.NumericUpDown
    Public WithEvents LblDjhEnd As System.Windows.Forms.Label
    Public WithEvents NudDjhBegin As System.Windows.Forms.NumericUpDown
    Public WithEvents LblDjhBegin As System.Windows.Forms.Label
    Public WithEvents LblQdrqEnd As System.Windows.Forms.Label
    Public WithEvents DtpEnd As System.Windows.Forms.DateTimePicker
    Public WithEvents LblQdrqBegin As System.Windows.Forms.Label
    Public WithEvents DtpBegin As System.Windows.Forms.DateTimePicker
    Friend WithEvents ChbSh As System.Windows.Forms.CheckBox
    Friend WithEvents CmbPzlxjc As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents TxtKhddh As System.Windows.Forms.TextBox
    Public WithEvents LblKhddh As System.Windows.Forms.Label
    Public WithEvents TxtKhlh As System.Windows.Forms.TextBox
    Public WithEvents LblKhlh As System.Windows.Forms.Label
    Friend WithEvents ChbWsk As System.Windows.Forms.CheckBox
End Class
