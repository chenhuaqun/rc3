<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeDdSh
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
        Me.CmbPzlxjc = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtKhdm = New System.Windows.Forms.TextBox
        Me.LblKhdm = New System.Windows.Forms.Label
        Me.ChbSh = New System.Windows.Forms.CheckBox
        Me.LblEnd = New System.Windows.Forms.Label
        Me.DtpEnd = New System.Windows.Forms.DateTimePicker
        Me.LblBegin = New System.Windows.Forms.Label
        Me.DtpBegin = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.NudDjhEnd = New System.Windows.Forms.NumericUpDown
        Me.NudDjhBegin = New System.Windows.Forms.NumericUpDown
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtLbdm = New System.Windows.Forms.TextBox
        Me.LblLbdm = New System.Windows.Forms.Label
        Me.TxtKhmc = New System.Windows.Forms.TextBox
        Me.LblKhmc = New System.Windows.Forms.Label
        Me.DlgPanel.SuspendLayout()
        CType(Me.NudDjhEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudDjhBegin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(226, 222)
        Me.DlgPanel.TabIndex = 17
        '
        'TxtHth
        '
        Me.TxtHth.Location = New System.Drawing.Point(105, 130)
        Me.TxtHth.MaxLength = 12
        Me.TxtHth.Name = "TxtHth"
        Me.TxtHth.Size = New System.Drawing.Size(104, 21)
        Me.TxtHth.TabIndex = 13
        '
        'LblHth
        '
        Me.LblHth.AutoSize = True
        Me.LblHth.Location = New System.Drawing.Point(33, 133)
        Me.LblHth.Name = "LblHth"
        Me.LblHth.Size = New System.Drawing.Size(65, 12)
        Me.LblHth.TabIndex = 12
        Me.LblHth.Text = "订 单 号："
        '
        'CmbPzlxjc
        '
        Me.CmbPzlxjc.Location = New System.Drawing.Point(105, 46)
        Me.CmbPzlxjc.Name = "CmbPzlxjc"
        Me.CmbPzlxjc.Size = New System.Drawing.Size(72, 20)
        Me.CmbPzlxjc.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "单据类型："
        '
        'TxtKhdm
        '
        Me.TxtKhdm.Location = New System.Drawing.Point(105, 157)
        Me.TxtKhdm.MaxLength = 12
        Me.TxtKhdm.Name = "TxtKhdm"
        Me.TxtKhdm.Size = New System.Drawing.Size(87, 21)
        Me.TxtKhdm.TabIndex = 15
        '
        'LblKhdm
        '
        Me.LblKhdm.AutoSize = True
        Me.LblKhdm.Location = New System.Drawing.Point(34, 160)
        Me.LblKhdm.Name = "LblKhdm"
        Me.LblKhdm.Size = New System.Drawing.Size(65, 12)
        Me.LblKhdm.TabIndex = 14
        Me.LblKhdm.Text = "客户编码："
        '
        'ChbSh
        '
        Me.ChbSh.Checked = True
        Me.ChbSh.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChbSh.ForeColor = System.Drawing.Color.Teal
        Me.ChbSh.Location = New System.Drawing.Point(128, 192)
        Me.ChbSh.Name = "ChbSh"
        Me.ChbSh.Size = New System.Drawing.Size(190, 24)
        Me.ChbSh.TabIndex = 16
        Me.ChbSh.Text = "只显示未审核的产品销售订单"
        '
        'LblEnd
        '
        Me.LblEnd.AutoSize = True
        Me.LblEnd.Location = New System.Drawing.Point(266, 21)
        Me.LblEnd.Name = "LblEnd"
        Me.LblEnd.Size = New System.Drawing.Size(17, 12)
        Me.LblEnd.TabIndex = 2
        Me.LblEnd.Text = "至"
        '
        'DtpEnd
        '
        Me.DtpEnd.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpEnd.Location = New System.Drawing.Point(291, 15)
        Me.DtpEnd.Name = "DtpEnd"
        Me.DtpEnd.Size = New System.Drawing.Size(151, 21)
        Me.DtpEnd.TabIndex = 3
        '
        'LblBegin
        '
        Me.LblBegin.AutoSize = True
        Me.LblBegin.Location = New System.Drawing.Point(34, 21)
        Me.LblBegin.Name = "LblBegin"
        Me.LblBegin.Size = New System.Drawing.Size(65, 12)
        Me.LblBegin.TabIndex = 0
        Me.LblBegin.Text = "签单日期："
        '
        'DtpBegin
        '
        Me.DtpBegin.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpBegin.Location = New System.Drawing.Point(107, 15)
        Me.DtpBegin.Name = "DtpBegin"
        Me.DtpBegin.Size = New System.Drawing.Size(151, 21)
        Me.DtpBegin.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(166, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 12)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "至"
        '
        'NudDjhEnd
        '
        Me.NudDjhEnd.Location = New System.Drawing.Point(189, 75)
        Me.NudDjhEnd.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.NudDjhEnd.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudDjhEnd.Name = "NudDjhEnd"
        Me.NudDjhEnd.Size = New System.Drawing.Size(56, 21)
        Me.NudDjhEnd.TabIndex = 9
        Me.NudDjhEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudDjhEnd.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        '
        'NudDjhBegin
        '
        Me.NudDjhBegin.Location = New System.Drawing.Point(104, 75)
        Me.NudDjhBegin.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.NudDjhBegin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudDjhBegin.Name = "NudDjhBegin"
        Me.NudDjhBegin.Size = New System.Drawing.Size(56, 21)
        Me.NudDjhBegin.TabIndex = 7
        Me.NudDjhBegin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudDjhBegin.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(33, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "单据编号："
        '
        'TxtLbdm
        '
        Me.TxtLbdm.Location = New System.Drawing.Point(104, 102)
        Me.TxtLbdm.MaxLength = 6
        Me.TxtLbdm.Name = "TxtLbdm"
        Me.TxtLbdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtLbdm.TabIndex = 11
        '
        'LblLbdm
        '
        Me.LblLbdm.AutoSize = True
        Me.LblLbdm.Location = New System.Drawing.Point(34, 105)
        Me.LblLbdm.Name = "LblLbdm"
        Me.LblLbdm.Size = New System.Drawing.Size(65, 12)
        Me.LblLbdm.TabIndex = 10
        Me.LblLbdm.Text = "类别编码："
        '
        'TxtKhmc
        '
        Me.TxtKhmc.Location = New System.Drawing.Point(292, 157)
        Me.TxtKhmc.MaxLength = 15
        Me.TxtKhmc.Name = "TxtKhmc"
        Me.TxtKhmc.Size = New System.Drawing.Size(104, 21)
        Me.TxtKhmc.TabIndex = 129
        '
        'LblKhmc
        '
        Me.LblKhmc.AutoSize = True
        Me.LblKhmc.Location = New System.Drawing.Point(220, 160)
        Me.LblKhmc.Name = "LblKhmc"
        Me.LblKhmc.Size = New System.Drawing.Size(65, 12)
        Me.LblKhmc.TabIndex = 128
        Me.LblKhmc.Text = "客户名称："
        '
        'FrmOeDdSh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(479, 265)
        Me.Controls.Add(Me.TxtKhmc)
        Me.Controls.Add(Me.LblKhmc)
        Me.Controls.Add(Me.TxtLbdm)
        Me.Controls.Add(Me.LblLbdm)
        Me.Controls.Add(Me.TxtHth)
        Me.Controls.Add(Me.LblHth)
        Me.Controls.Add(Me.CmbPzlxjc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtKhdm)
        Me.Controls.Add(Me.LblKhdm)
        Me.Controls.Add(Me.ChbSh)
        Me.Controls.Add(Me.LblEnd)
        Me.Controls.Add(Me.DtpEnd)
        Me.Controls.Add(Me.LblBegin)
        Me.Controls.Add(Me.DtpBegin)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.NudDjhEnd)
        Me.Controls.Add(Me.NudDjhBegin)
        Me.Controls.Add(Me.Label4)
        Me.Name = "FrmOeDdSh"
        Me.Text = "产品销售订单审核"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.NudDjhBegin, 0)
        Me.Controls.SetChildIndex(Me.NudDjhEnd, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.DtpBegin, 0)
        Me.Controls.SetChildIndex(Me.LblBegin, 0)
        Me.Controls.SetChildIndex(Me.DtpEnd, 0)
        Me.Controls.SetChildIndex(Me.LblEnd, 0)
        Me.Controls.SetChildIndex(Me.ChbSh, 0)
        Me.Controls.SetChildIndex(Me.LblKhdm, 0)
        Me.Controls.SetChildIndex(Me.TxtKhdm, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.CmbPzlxjc, 0)
        Me.Controls.SetChildIndex(Me.LblHth, 0)
        Me.Controls.SetChildIndex(Me.TxtHth, 0)
        Me.Controls.SetChildIndex(Me.LblLbdm, 0)
        Me.Controls.SetChildIndex(Me.TxtLbdm, 0)
        Me.Controls.SetChildIndex(Me.LblKhmc, 0)
        Me.Controls.SetChildIndex(Me.TxtKhmc, 0)
        Me.DlgPanel.ResumeLayout(False)
        CType(Me.NudDjhEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudDjhBegin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents TxtHth As System.Windows.Forms.TextBox
    Public WithEvents LblHth As System.Windows.Forms.Label
    Friend WithEvents CmbPzlxjc As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents TxtKhdm As System.Windows.Forms.TextBox
    Public WithEvents LblKhdm As System.Windows.Forms.Label
    Friend WithEvents ChbSh As System.Windows.Forms.CheckBox
    Public WithEvents LblEnd As System.Windows.Forms.Label
    Public WithEvents DtpEnd As System.Windows.Forms.DateTimePicker
    Public WithEvents LblBegin As System.Windows.Forms.Label
    Public WithEvents DtpBegin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents NudDjhEnd As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudDjhBegin As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents TxtLbdm As System.Windows.Forms.TextBox
    Public WithEvents LblLbdm As System.Windows.Forms.Label
    Public WithEvents TxtKhmc As System.Windows.Forms.TextBox
    Public WithEvents LblKhmc As System.Windows.Forms.Label
End Class
