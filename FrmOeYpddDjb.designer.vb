<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeYpddDjb
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
        Me.ChbHx = New System.Windows.Forms.CheckBox
        Me.TxtHth = New System.Windows.Forms.TextBox
        Me.LblHth = New System.Windows.Forms.Label
        Me.TxtCpgg = New System.Windows.Forms.TextBox
        Me.LblCpgg = New System.Windows.Forms.Label
        Me.TxtCpmc = New System.Windows.Forms.TextBox
        Me.LblCpmc = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RadioBtnFhrq = New System.Windows.Forms.RadioButton
        Me.RadioBtnQdrq = New System.Windows.Forms.RadioButton
        Me.RadioBtnScjhrq = New System.Windows.Forms.RadioButton
        Me.TxtBmdm = New System.Windows.Forms.TextBox
        Me.LblBmdm = New System.Windows.Forms.Label
        Me.TxtKhlh = New System.Windows.Forms.TextBox
        Me.LblKhlh = New System.Windows.Forms.Label
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
        Me.DtpQdrqEnd = New System.Windows.Forms.DateTimePicker
        Me.LblQdrqBegin = New System.Windows.Forms.Label
        Me.DtpQdrqBegin = New System.Windows.Forms.DateTimePicker
        Me.TxtCpmemo = New System.Windows.Forms.TextBox
        Me.LblCpmemo = New System.Windows.Forms.Label
        Me.TxtKhcz = New System.Windows.Forms.TextBox
        Me.LblKhcz = New System.Windows.Forms.Label
        Me.ChbShdh = New System.Windows.Forms.CheckBox
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
        Me.DlgPanel.Location = New System.Drawing.Point(171, 362)
        '
        'ChbHx
        '
        Me.ChbHx.AutoSize = True
        Me.ChbHx.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ChbHx.Location = New System.Drawing.Point(25, 322)
        Me.ChbHx.Name = "ChbHx"
        Me.ChbHx.Size = New System.Drawing.Size(120, 16)
        Me.ChbHx.TabIndex = 31
        Me.ChbHx.Text = "包含全额冲销订单"
        '
        'TxtHth
        '
        Me.TxtHth.Location = New System.Drawing.Point(287, 195)
        Me.TxtHth.MaxLength = 11
        Me.TxtHth.Name = "TxtHth"
        Me.TxtHth.Size = New System.Drawing.Size(104, 21)
        Me.TxtHth.TabIndex = 20
        '
        'LblHth
        '
        Me.LblHth.AutoSize = True
        Me.LblHth.Location = New System.Drawing.Point(215, 195)
        Me.LblHth.Name = "LblHth"
        Me.LblHth.Size = New System.Drawing.Size(65, 12)
        Me.LblHth.TabIndex = 19
        Me.LblHth.Text = "合同编码："
        '
        'TxtCpgg
        '
        Me.TxtCpgg.Location = New System.Drawing.Point(95, 174)
        Me.TxtCpgg.MaxLength = 15
        Me.TxtCpgg.Name = "TxtCpgg"
        Me.TxtCpgg.Size = New System.Drawing.Size(104, 21)
        Me.TxtCpgg.TabIndex = 14
        '
        'LblCpgg
        '
        Me.LblCpgg.AutoSize = True
        Me.LblCpgg.Location = New System.Drawing.Point(23, 174)
        Me.LblCpgg.Name = "LblCpgg"
        Me.LblCpgg.Size = New System.Drawing.Size(65, 12)
        Me.LblCpgg.TabIndex = 13
        Me.LblCpgg.Text = "规格型号："
        '
        'TxtCpmc
        '
        Me.TxtCpmc.Location = New System.Drawing.Point(287, 153)
        Me.TxtCpmc.MaxLength = 15
        Me.TxtCpmc.Name = "TxtCpmc"
        Me.TxtCpmc.Size = New System.Drawing.Size(104, 21)
        Me.TxtCpmc.TabIndex = 12
        '
        'LblCpmc
        '
        Me.LblCpmc.AutoSize = True
        Me.LblCpmc.Location = New System.Drawing.Point(215, 153)
        Me.LblCpmc.Name = "LblCpmc"
        Me.LblCpmc.Size = New System.Drawing.Size(65, 12)
        Me.LblCpmc.TabIndex = 11
        Me.LblCpmc.Text = "产品名称："
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RadioBtnFhrq)
        Me.GroupBox2.Controls.Add(Me.RadioBtnQdrq)
        Me.GroupBox2.Controls.Add(Me.RadioBtnScjhrq)
        Me.GroupBox2.Location = New System.Drawing.Point(26, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(368, 48)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "选择按何日期"
        '
        'RadioBtnFhrq
        '
        Me.RadioBtnFhrq.Location = New System.Drawing.Point(261, 16)
        Me.RadioBtnFhrq.Name = "RadioBtnFhrq"
        Me.RadioBtnFhrq.Size = New System.Drawing.Size(72, 24)
        Me.RadioBtnFhrq.TabIndex = 2
        Me.RadioBtnFhrq.Text = "寄样交期"
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
        Me.RadioBtnScjhrq.Location = New System.Drawing.Point(157, 16)
        Me.RadioBtnScjhrq.Name = "RadioBtnScjhrq"
        Me.RadioBtnScjhrq.Size = New System.Drawing.Size(72, 24)
        Me.RadioBtnScjhrq.TabIndex = 1
        Me.RadioBtnScjhrq.Text = "生产交期"
        '
        'TxtBmdm
        '
        Me.TxtBmdm.Location = New System.Drawing.Point(95, 195)
        Me.TxtBmdm.MaxLength = 12
        Me.TxtBmdm.Name = "TxtBmdm"
        Me.TxtBmdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtBmdm.TabIndex = 18
        '
        'LblBmdm
        '
        Me.LblBmdm.AutoSize = True
        Me.LblBmdm.Location = New System.Drawing.Point(23, 195)
        Me.LblBmdm.Name = "LblBmdm"
        Me.LblBmdm.Size = New System.Drawing.Size(65, 12)
        Me.LblBmdm.TabIndex = 17
        Me.LblBmdm.Text = "生 产 厂："
        '
        'TxtKhlh
        '
        Me.TxtKhlh.Location = New System.Drawing.Point(95, 237)
        Me.TxtKhlh.MaxLength = 50
        Me.TxtKhlh.Name = "TxtKhlh"
        Me.TxtKhlh.Size = New System.Drawing.Size(104, 21)
        Me.TxtKhlh.TabIndex = 24
        '
        'LblKhlh
        '
        Me.LblKhlh.AutoSize = True
        Me.LblKhlh.Location = New System.Drawing.Point(23, 237)
        Me.LblKhlh.Name = "LblKhlh"
        Me.LblKhlh.Size = New System.Drawing.Size(65, 12)
        Me.LblKhlh.TabIndex = 23
        Me.LblKhlh.Text = "客户料号："
        '
        'TxtZydm
        '
        Me.TxtZydm.Location = New System.Drawing.Point(95, 258)
        Me.TxtZydm.MaxLength = 12
        Me.TxtZydm.Name = "TxtZydm"
        Me.TxtZydm.Size = New System.Drawing.Size(104, 21)
        Me.TxtZydm.TabIndex = 28
        '
        'LblZydm
        '
        Me.LblZydm.AutoSize = True
        Me.LblZydm.Location = New System.Drawing.Point(23, 258)
        Me.LblZydm.Name = "LblZydm"
        Me.LblZydm.Size = New System.Drawing.Size(77, 12)
        Me.LblZydm.TabIndex = 27
        Me.LblZydm.Text = "内销业务员："
        '
        'TxtKhdm
        '
        Me.TxtKhdm.Location = New System.Drawing.Point(95, 216)
        Me.TxtKhdm.MaxLength = 15
        Me.TxtKhdm.Name = "TxtKhdm"
        Me.TxtKhdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtKhdm.TabIndex = 22
        '
        'LblKhdm
        '
        Me.LblKhdm.AutoSize = True
        Me.LblKhdm.Location = New System.Drawing.Point(23, 216)
        Me.LblKhdm.Name = "LblKhdm"
        Me.LblKhdm.Size = New System.Drawing.Size(65, 12)
        Me.LblKhdm.TabIndex = 21
        Me.LblKhdm.Text = "客户编码："
        '
        'ChbLbfs
        '
        Me.ChbLbfs.AutoSize = True
        Me.ChbLbfs.Checked = True
        Me.ChbLbfs.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChbLbfs.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ChbLbfs.Location = New System.Drawing.Point(287, 322)
        Me.ChbLbfs.Name = "ChbLbfs"
        Me.ChbLbfs.Size = New System.Drawing.Size(96, 16)
        Me.ChbLbfs.TabIndex = 32
        Me.ChbLbfs.Text = "列表方式查询"
        '
        'TxtCpdm
        '
        Me.TxtCpdm.Location = New System.Drawing.Point(95, 153)
        Me.TxtCpdm.MaxLength = 15
        Me.TxtCpdm.Name = "TxtCpdm"
        Me.TxtCpdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtCpdm.TabIndex = 10
        '
        'LblCpdm
        '
        Me.LblCpdm.AutoSize = True
        Me.LblCpdm.Location = New System.Drawing.Point(23, 153)
        Me.LblCpdm.Name = "LblCpdm"
        Me.LblCpdm.Size = New System.Drawing.Size(65, 12)
        Me.LblCpdm.TabIndex = 9
        Me.LblCpdm.Text = "产品编码："
        '
        'NudDjhEnd
        '
        Me.NudDjhEnd.Location = New System.Drawing.Point(183, 113)
        Me.NudDjhEnd.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.NudDjhEnd.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudDjhEnd.Name = "NudDjhEnd"
        Me.NudDjhEnd.Size = New System.Drawing.Size(56, 21)
        Me.NudDjhEnd.TabIndex = 8
        Me.NudDjhEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudDjhEnd.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        '
        'LblDjhEnd
        '
        Me.LblDjhEnd.AutoSize = True
        Me.LblDjhEnd.Location = New System.Drawing.Point(159, 113)
        Me.LblDjhEnd.Name = "LblDjhEnd"
        Me.LblDjhEnd.Size = New System.Drawing.Size(17, 12)
        Me.LblDjhEnd.TabIndex = 7
        Me.LblDjhEnd.Text = "至"
        '
        'NudDjhBegin
        '
        Me.NudDjhBegin.Location = New System.Drawing.Point(95, 113)
        Me.NudDjhBegin.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.NudDjhBegin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudDjhBegin.Name = "NudDjhBegin"
        Me.NudDjhBegin.Size = New System.Drawing.Size(56, 21)
        Me.NudDjhBegin.TabIndex = 6
        Me.NudDjhBegin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudDjhBegin.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'LblDjhBegin
        '
        Me.LblDjhBegin.AutoSize = True
        Me.LblDjhBegin.Location = New System.Drawing.Point(23, 113)
        Me.LblDjhBegin.Name = "LblDjhBegin"
        Me.LblDjhBegin.Size = New System.Drawing.Size(65, 12)
        Me.LblDjhBegin.TabIndex = 5
        Me.LblDjhBegin.Text = "单 据 号："
        '
        'LblQdrqEnd
        '
        Me.LblQdrqEnd.AutoSize = True
        Me.LblQdrqEnd.Location = New System.Drawing.Point(215, 81)
        Me.LblQdrqEnd.Name = "LblQdrqEnd"
        Me.LblQdrqEnd.Size = New System.Drawing.Size(17, 12)
        Me.LblQdrqEnd.TabIndex = 3
        Me.LblQdrqEnd.Text = "至"
        '
        'DtpQdrqEnd
        '
        Me.DtpQdrqEnd.Location = New System.Drawing.Point(239, 81)
        Me.DtpQdrqEnd.Name = "DtpQdrqEnd"
        Me.DtpQdrqEnd.Size = New System.Drawing.Size(112, 21)
        Me.DtpQdrqEnd.TabIndex = 4
        '
        'LblQdrqBegin
        '
        Me.LblQdrqBegin.AutoSize = True
        Me.LblQdrqBegin.Location = New System.Drawing.Point(23, 81)
        Me.LblQdrqBegin.Name = "LblQdrqBegin"
        Me.LblQdrqBegin.Size = New System.Drawing.Size(65, 12)
        Me.LblQdrqBegin.TabIndex = 1
        Me.LblQdrqBegin.Text = "日    期："
        '
        'DtpQdrqBegin
        '
        Me.DtpQdrqBegin.Location = New System.Drawing.Point(95, 81)
        Me.DtpQdrqBegin.Name = "DtpQdrqBegin"
        Me.DtpQdrqBegin.Size = New System.Drawing.Size(112, 21)
        Me.DtpQdrqBegin.TabIndex = 2
        '
        'TxtCpmemo
        '
        Me.TxtCpmemo.Location = New System.Drawing.Point(287, 174)
        Me.TxtCpmemo.MaxLength = 15
        Me.TxtCpmemo.Name = "TxtCpmemo"
        Me.TxtCpmemo.Size = New System.Drawing.Size(104, 21)
        Me.TxtCpmemo.TabIndex = 16
        '
        'LblCpmemo
        '
        Me.LblCpmemo.AutoSize = True
        Me.LblCpmemo.Location = New System.Drawing.Point(215, 174)
        Me.LblCpmemo.Name = "LblCpmemo"
        Me.LblCpmemo.Size = New System.Drawing.Size(65, 12)
        Me.LblCpmemo.TabIndex = 15
        Me.LblCpmemo.Text = "产品属性："
        '
        'TxtKhcz
        '
        Me.TxtKhcz.Location = New System.Drawing.Point(287, 237)
        Me.TxtKhcz.MaxLength = 15
        Me.TxtKhcz.Name = "TxtKhcz"
        Me.TxtKhcz.Size = New System.Drawing.Size(104, 21)
        Me.TxtKhcz.TabIndex = 26
        '
        'LblKhcz
        '
        Me.LblKhcz.AutoSize = True
        Me.LblKhcz.Location = New System.Drawing.Point(215, 237)
        Me.LblKhcz.Name = "LblKhcz"
        Me.LblKhcz.Size = New System.Drawing.Size(65, 12)
        Me.LblKhcz.TabIndex = 25
        Me.LblKhcz.Text = "客户材质："
        '
        'ChbShdh
        '
        Me.ChbShdh.AutoSize = True
        Me.ChbShdh.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ChbShdh.Location = New System.Drawing.Point(161, 322)
        Me.ChbShdh.Name = "ChbShdh"
        Me.ChbShdh.Size = New System.Drawing.Size(108, 16)
        Me.ChbShdh.TabIndex = 102
        Me.ChbShdh.Text = "送货单号不为空"
        '
        'FrmOeYpddDjb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 405)
        Me.Controls.Add(Me.ChbShdh)
        Me.Controls.Add(Me.TxtKhcz)
        Me.Controls.Add(Me.LblKhcz)
        Me.Controls.Add(Me.TxtCpmemo)
        Me.Controls.Add(Me.LblCpmemo)
        Me.Controls.Add(Me.ChbHx)
        Me.Controls.Add(Me.TxtHth)
        Me.Controls.Add(Me.TxtCpgg)
        Me.Controls.Add(Me.LblCpgg)
        Me.Controls.Add(Me.LblHth)
        Me.Controls.Add(Me.TxtCpmc)
        Me.Controls.Add(Me.LblCpmc)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TxtBmdm)
        Me.Controls.Add(Me.LblBmdm)
        Me.Controls.Add(Me.TxtKhlh)
        Me.Controls.Add(Me.LblKhlh)
        Me.Controls.Add(Me.TxtKhdm)
        Me.Controls.Add(Me.LblKhdm)
        Me.Controls.Add(Me.TxtZydm)
        Me.Controls.Add(Me.LblZydm)
        Me.Controls.Add(Me.ChbLbfs)
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
        Me.Name = "FrmOeYpddDjb"
        Me.Text = "样品订单查询"
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
        Me.Controls.SetChildIndex(Me.ChbLbfs, 0)
        Me.Controls.SetChildIndex(Me.LblZydm, 0)
        Me.Controls.SetChildIndex(Me.TxtZydm, 0)
        Me.Controls.SetChildIndex(Me.LblKhdm, 0)
        Me.Controls.SetChildIndex(Me.TxtKhdm, 0)
        Me.Controls.SetChildIndex(Me.LblKhlh, 0)
        Me.Controls.SetChildIndex(Me.TxtKhlh, 0)
        Me.Controls.SetChildIndex(Me.LblBmdm, 0)
        Me.Controls.SetChildIndex(Me.TxtBmdm, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.LblCpmc, 0)
        Me.Controls.SetChildIndex(Me.TxtCpmc, 0)
        Me.Controls.SetChildIndex(Me.LblHth, 0)
        Me.Controls.SetChildIndex(Me.LblCpgg, 0)
        Me.Controls.SetChildIndex(Me.TxtCpgg, 0)
        Me.Controls.SetChildIndex(Me.TxtHth, 0)
        Me.Controls.SetChildIndex(Me.ChbHx, 0)
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.LblCpmemo, 0)
        Me.Controls.SetChildIndex(Me.TxtCpmemo, 0)
        Me.Controls.SetChildIndex(Me.LblKhcz, 0)
        Me.Controls.SetChildIndex(Me.TxtKhcz, 0)
        Me.Controls.SetChildIndex(Me.ChbShdh, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.NudDjhEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudDjhBegin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ChbHx As System.Windows.Forms.CheckBox
    Public WithEvents TxtHth As System.Windows.Forms.TextBox
    Public WithEvents LblHth As System.Windows.Forms.Label
    Public WithEvents TxtCpgg As System.Windows.Forms.TextBox
    Public WithEvents LblCpgg As System.Windows.Forms.Label
    Public WithEvents TxtCpmc As System.Windows.Forms.TextBox
    Public WithEvents LblCpmc As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioBtnQdrq As System.Windows.Forms.RadioButton
    Friend WithEvents RadioBtnScjhrq As System.Windows.Forms.RadioButton
    Public WithEvents TxtBmdm As System.Windows.Forms.TextBox
    Public WithEvents LblBmdm As System.Windows.Forms.Label
    Public WithEvents TxtKhlh As System.Windows.Forms.TextBox
    Public WithEvents LblKhlh As System.Windows.Forms.Label
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
    Public WithEvents DtpQdrqEnd As System.Windows.Forms.DateTimePicker
    Public WithEvents LblQdrqBegin As System.Windows.Forms.Label
    Public WithEvents DtpQdrqBegin As System.Windows.Forms.DateTimePicker
    Public WithEvents TxtCpmemo As System.Windows.Forms.TextBox
    Public WithEvents LblCpmemo As System.Windows.Forms.Label
    Public WithEvents TxtKhcz As System.Windows.Forms.TextBox
    Public WithEvents LblKhcz As System.Windows.Forms.Label
    Friend WithEvents RadioBtnFhrq As System.Windows.Forms.RadioButton
    Friend WithEvents ChbShdh As System.Windows.Forms.CheckBox
End Class
