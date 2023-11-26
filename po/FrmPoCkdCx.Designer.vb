<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPoCkdCx
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
        Me.TxtCpmc = New System.Windows.Forms.TextBox()
        Me.LblCpmc = New System.Windows.Forms.Label()
        Me.TxtHth = New System.Windows.Forms.TextBox()
        Me.LblHth = New System.Windows.Forms.Label()
        Me.TxtCpdm = New System.Windows.Forms.TextBox()
        Me.LblCpdm = New System.Windows.Forms.Label()
        Me.CmbPzlxjc = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtZydm = New System.Windows.Forms.TextBox()
        Me.LblZydm = New System.Windows.Forms.Label()
        Me.LblRkrqEnd = New System.Windows.Forms.Label()
        Me.DtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.DtpBegin = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NudDjhEnd = New System.Windows.Forms.NumericUpDown()
        Me.NudDjhBegin = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ChbSh = New System.Windows.Forms.CheckBox()
        Me.ChbLbfs = New System.Windows.Forms.CheckBox()
        Me.TxtCkdm = New System.Windows.Forms.TextBox()
        Me.LblCkdm = New System.Windows.Forms.Label()
        Me.TxtBmdm = New System.Windows.Forms.TextBox()
        Me.LblBmdm = New System.Windows.Forms.Label()
        Me.TxtFadmBegin = New System.Windows.Forms.TextBox()
        Me.LblFadmBegin = New System.Windows.Forms.Label()
        Me.TxtFadmEnd = New System.Windows.Forms.TextBox()
        Me.LblFadmEnd = New System.Windows.Forms.Label()
        Me.TxtLbdm = New System.Windows.Forms.TextBox()
        Me.LblLbdm = New System.Windows.Forms.Label()
        Me.ChbZf = New System.Windows.Forms.CheckBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.LblRkrqBegin = New System.Windows.Forms.Label()
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
        Me.DlgPanel.Location = New System.Drawing.Point(217, 334)
        Me.DlgPanel.TabIndex = 33
        '
        'TxtCpmc
        '
        Me.TxtCpmc.Location = New System.Drawing.Point(104, 201)
        Me.TxtCpmc.MaxLength = 100
        Me.TxtCpmc.Name = "TxtCpmc"
        Me.TxtCpmc.Size = New System.Drawing.Size(104, 21)
        Me.TxtCpmc.TabIndex = 19
        '
        'LblCpmc
        '
        Me.LblCpmc.AutoSize = True
        Me.LblCpmc.Location = New System.Drawing.Point(32, 205)
        Me.LblCpmc.Name = "LblCpmc"
        Me.LblCpmc.Size = New System.Drawing.Size(65, 12)
        Me.LblCpmc.TabIndex = 18
        Me.LblCpmc.Text = "物料名称："
        '
        'TxtHth
        '
        Me.TxtHth.Location = New System.Drawing.Point(104, 230)
        Me.TxtHth.MaxLength = 11
        Me.TxtHth.Name = "TxtHth"
        Me.TxtHth.Size = New System.Drawing.Size(104, 21)
        Me.TxtHth.TabIndex = 23
        '
        'LblHth
        '
        Me.LblHth.AutoSize = True
        Me.LblHth.Location = New System.Drawing.Point(33, 234)
        Me.LblHth.Name = "LblHth"
        Me.LblHth.Size = New System.Drawing.Size(65, 12)
        Me.LblHth.TabIndex = 22
        Me.LblHth.Text = "订 单 号："
        '
        'TxtCpdm
        '
        Me.TxtCpdm.Location = New System.Drawing.Point(104, 172)
        Me.TxtCpdm.MaxLength = 15
        Me.TxtCpdm.Name = "TxtCpdm"
        Me.TxtCpdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtCpdm.TabIndex = 15
        '
        'LblCpdm
        '
        Me.LblCpdm.AutoSize = True
        Me.LblCpdm.Location = New System.Drawing.Point(32, 176)
        Me.LblCpdm.Name = "LblCpdm"
        Me.LblCpdm.Size = New System.Drawing.Size(65, 12)
        Me.LblCpdm.TabIndex = 14
        Me.LblCpdm.Text = "物料编码："
        '
        'CmbPzlxjc
        '
        Me.CmbPzlxjc.Location = New System.Drawing.Point(104, 86)
        Me.CmbPzlxjc.Name = "CmbPzlxjc"
        Me.CmbPzlxjc.Size = New System.Drawing.Size(72, 20)
        Me.CmbPzlxjc.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "单据类型："
        '
        'TxtZydm
        '
        Me.TxtZydm.Location = New System.Drawing.Point(295, 230)
        Me.TxtZydm.MaxLength = 12
        Me.TxtZydm.Name = "TxtZydm"
        Me.TxtZydm.Size = New System.Drawing.Size(104, 21)
        Me.TxtZydm.TabIndex = 25
        '
        'LblZydm
        '
        Me.LblZydm.AutoSize = True
        Me.LblZydm.Location = New System.Drawing.Point(224, 234)
        Me.LblZydm.Name = "LblZydm"
        Me.LblZydm.Size = New System.Drawing.Size(65, 12)
        Me.LblZydm.TabIndex = 24
        Me.LblZydm.Text = "职员编码："
        '
        'LblRkrqEnd
        '
        Me.LblRkrqEnd.AutoSize = True
        Me.LblRkrqEnd.Location = New System.Drawing.Point(264, 61)
        Me.LblRkrqEnd.Name = "LblRkrqEnd"
        Me.LblRkrqEnd.Size = New System.Drawing.Size(17, 12)
        Me.LblRkrqEnd.TabIndex = 4
        Me.LblRkrqEnd.Text = "至"
        '
        'DtpEnd
        '
        Me.DtpEnd.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpEnd.Location = New System.Drawing.Point(289, 57)
        Me.DtpEnd.Name = "DtpEnd"
        Me.DtpEnd.Size = New System.Drawing.Size(151, 21)
        Me.DtpEnd.TabIndex = 5
        '
        'DtpBegin
        '
        Me.DtpBegin.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpBegin.Location = New System.Drawing.Point(105, 57)
        Me.DtpBegin.Name = "DtpBegin"
        Me.DtpBegin.Size = New System.Drawing.Size(151, 21)
        Me.DtpBegin.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(168, 118)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 12)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "至"
        '
        'NudDjhEnd
        '
        Me.NudDjhEnd.Location = New System.Drawing.Point(192, 114)
        Me.NudDjhEnd.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.NudDjhEnd.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudDjhEnd.Name = "NudDjhEnd"
        Me.NudDjhEnd.Size = New System.Drawing.Size(56, 21)
        Me.NudDjhEnd.TabIndex = 11
        Me.NudDjhEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudDjhEnd.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        '
        'NudDjhBegin
        '
        Me.NudDjhBegin.Location = New System.Drawing.Point(104, 114)
        Me.NudDjhBegin.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.NudDjhBegin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudDjhBegin.Name = "NudDjhBegin"
        Me.NudDjhBegin.Size = New System.Drawing.Size(56, 21)
        Me.NudDjhBegin.TabIndex = 9
        Me.NudDjhBegin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudDjhBegin.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "单据编号："
        '
        'ChbSh
        '
        Me.ChbSh.Checked = True
        Me.ChbSh.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChbSh.ForeColor = System.Drawing.Color.SteelBlue
        Me.ChbSh.Location = New System.Drawing.Point(34, 286)
        Me.ChbSh.Name = "ChbSh"
        Me.ChbSh.Size = New System.Drawing.Size(122, 24)
        Me.ChbSh.TabIndex = 30
        Me.ChbSh.Text = "包含未审核单据"
        '
        'ChbLbfs
        '
        Me.ChbLbfs.Checked = True
        Me.ChbLbfs.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChbLbfs.ForeColor = System.Drawing.Color.SteelBlue
        Me.ChbLbfs.Location = New System.Drawing.Point(296, 286)
        Me.ChbLbfs.Name = "ChbLbfs"
        Me.ChbLbfs.Size = New System.Drawing.Size(104, 24)
        Me.ChbLbfs.TabIndex = 32
        Me.ChbLbfs.Text = "列表方式查询"
        '
        'TxtCkdm
        '
        Me.TxtCkdm.Location = New System.Drawing.Point(296, 172)
        Me.TxtCkdm.MaxLength = 30
        Me.TxtCkdm.Name = "TxtCkdm"
        Me.TxtCkdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtCkdm.TabIndex = 17
        '
        'LblCkdm
        '
        Me.LblCkdm.AutoSize = True
        Me.LblCkdm.Location = New System.Drawing.Point(224, 176)
        Me.LblCkdm.Name = "LblCkdm"
        Me.LblCkdm.Size = New System.Drawing.Size(65, 12)
        Me.LblCkdm.TabIndex = 16
        Me.LblCkdm.Text = "仓库编码："
        '
        'TxtBmdm
        '
        Me.TxtBmdm.Location = New System.Drawing.Point(296, 201)
        Me.TxtBmdm.MaxLength = 12
        Me.TxtBmdm.Name = "TxtBmdm"
        Me.TxtBmdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtBmdm.TabIndex = 21
        '
        'LblBmdm
        '
        Me.LblBmdm.AutoSize = True
        Me.LblBmdm.Location = New System.Drawing.Point(224, 205)
        Me.LblBmdm.Name = "LblBmdm"
        Me.LblBmdm.Size = New System.Drawing.Size(65, 12)
        Me.LblBmdm.TabIndex = 20
        Me.LblBmdm.Text = "部门编码："
        '
        'TxtFadmBegin
        '
        Me.TxtFadmBegin.Location = New System.Drawing.Point(104, 259)
        Me.TxtFadmBegin.MaxLength = 11
        Me.TxtFadmBegin.Name = "TxtFadmBegin"
        Me.TxtFadmBegin.Size = New System.Drawing.Size(104, 21)
        Me.TxtFadmBegin.TabIndex = 27
        '
        'LblFadmBegin
        '
        Me.LblFadmBegin.AutoSize = True
        Me.LblFadmBegin.Location = New System.Drawing.Point(33, 263)
        Me.LblFadmBegin.Name = "LblFadmBegin"
        Me.LblFadmBegin.Size = New System.Drawing.Size(77, 12)
        Me.LblFadmBegin.TabIndex = 26
        Me.LblFadmBegin.Text = "设备编码从："
        '
        'TxtFadmEnd
        '
        Me.TxtFadmEnd.Location = New System.Drawing.Point(295, 259)
        Me.TxtFadmEnd.MaxLength = 6
        Me.TxtFadmEnd.Name = "TxtFadmEnd"
        Me.TxtFadmEnd.Size = New System.Drawing.Size(104, 21)
        Me.TxtFadmEnd.TabIndex = 29
        '
        'LblFadmEnd
        '
        Me.LblFadmEnd.AutoSize = True
        Me.LblFadmEnd.Location = New System.Drawing.Point(245, 263)
        Me.LblFadmEnd.Name = "LblFadmEnd"
        Me.LblFadmEnd.Size = New System.Drawing.Size(17, 12)
        Me.LblFadmEnd.TabIndex = 28
        Me.LblFadmEnd.Text = "至"
        '
        'TxtLbdm
        '
        Me.TxtLbdm.Location = New System.Drawing.Point(104, 143)
        Me.TxtLbdm.MaxLength = 12
        Me.TxtLbdm.Name = "TxtLbdm"
        Me.TxtLbdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtLbdm.TabIndex = 13
        '
        'LblLbdm
        '
        Me.LblLbdm.AutoSize = True
        Me.LblLbdm.Location = New System.Drawing.Point(34, 147)
        Me.LblLbdm.Name = "LblLbdm"
        Me.LblLbdm.Size = New System.Drawing.Size(65, 12)
        Me.LblLbdm.TabIndex = 12
        Me.LblLbdm.Text = "物料类别："
        '
        'ChbZf
        '
        Me.ChbZf.ForeColor = System.Drawing.Color.SteelBlue
        Me.ChbZf.Location = New System.Drawing.Point(159, 286)
        Me.ChbZf.Name = "ChbZf"
        Me.ChbZf.Size = New System.Drawing.Size(122, 24)
        Me.ChbZf.TabIndex = 31
        Me.ChbZf.Text = "包含已作废单据"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(105, 25)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(71, 16)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "出库日期"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(247, 25)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(71, 16)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "回收日期"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'LblRkrqBegin
        '
        Me.LblRkrqBegin.AutoSize = True
        Me.LblRkrqBegin.Location = New System.Drawing.Point(68, 61)
        Me.LblRkrqBegin.Name = "LblRkrqBegin"
        Me.LblRkrqBegin.Size = New System.Drawing.Size(29, 12)
        Me.LblRkrqBegin.TabIndex = 2
        Me.LblRkrqBegin.Text = "从："
        '
        'FrmPoCkdCx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(470, 377)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.ChbZf)
        Me.Controls.Add(Me.TxtLbdm)
        Me.Controls.Add(Me.LblLbdm)
        Me.Controls.Add(Me.TxtFadmBegin)
        Me.Controls.Add(Me.LblFadmBegin)
        Me.Controls.Add(Me.TxtFadmEnd)
        Me.Controls.Add(Me.LblFadmEnd)
        Me.Controls.Add(Me.TxtBmdm)
        Me.Controls.Add(Me.LblBmdm)
        Me.Controls.Add(Me.TxtCkdm)
        Me.Controls.Add(Me.LblCkdm)
        Me.Controls.Add(Me.ChbSh)
        Me.Controls.Add(Me.ChbLbfs)
        Me.Controls.Add(Me.TxtCpmc)
        Me.Controls.Add(Me.LblCpmc)
        Me.Controls.Add(Me.TxtHth)
        Me.Controls.Add(Me.LblHth)
        Me.Controls.Add(Me.TxtCpdm)
        Me.Controls.Add(Me.LblCpdm)
        Me.Controls.Add(Me.CmbPzlxjc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtZydm)
        Me.Controls.Add(Me.LblZydm)
        Me.Controls.Add(Me.LblRkrqEnd)
        Me.Controls.Add(Me.DtpEnd)
        Me.Controls.Add(Me.LblRkrqBegin)
        Me.Controls.Add(Me.DtpBegin)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.NudDjhEnd)
        Me.Controls.Add(Me.NudDjhBegin)
        Me.Controls.Add(Me.Label4)
        Me.Name = "FrmPoCkdCx"
        Me.Text = "物料出库单查询"
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.NudDjhBegin, 0)
        Me.Controls.SetChildIndex(Me.NudDjhEnd, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.DtpBegin, 0)
        Me.Controls.SetChildIndex(Me.LblRkrqBegin, 0)
        Me.Controls.SetChildIndex(Me.DtpEnd, 0)
        Me.Controls.SetChildIndex(Me.LblRkrqEnd, 0)
        Me.Controls.SetChildIndex(Me.LblZydm, 0)
        Me.Controls.SetChildIndex(Me.TxtZydm, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.CmbPzlxjc, 0)
        Me.Controls.SetChildIndex(Me.LblCpdm, 0)
        Me.Controls.SetChildIndex(Me.TxtCpdm, 0)
        Me.Controls.SetChildIndex(Me.LblHth, 0)
        Me.Controls.SetChildIndex(Me.TxtHth, 0)
        Me.Controls.SetChildIndex(Me.LblCpmc, 0)
        Me.Controls.SetChildIndex(Me.TxtCpmc, 0)
        Me.Controls.SetChildIndex(Me.ChbLbfs, 0)
        Me.Controls.SetChildIndex(Me.ChbSh, 0)
        Me.Controls.SetChildIndex(Me.LblCkdm, 0)
        Me.Controls.SetChildIndex(Me.TxtCkdm, 0)
        Me.Controls.SetChildIndex(Me.LblBmdm, 0)
        Me.Controls.SetChildIndex(Me.TxtBmdm, 0)
        Me.Controls.SetChildIndex(Me.LblFadmEnd, 0)
        Me.Controls.SetChildIndex(Me.TxtFadmEnd, 0)
        Me.Controls.SetChildIndex(Me.LblFadmBegin, 0)
        Me.Controls.SetChildIndex(Me.TxtFadmBegin, 0)
        Me.Controls.SetChildIndex(Me.LblLbdm, 0)
        Me.Controls.SetChildIndex(Me.TxtLbdm, 0)
        Me.Controls.SetChildIndex(Me.ChbZf, 0)
        Me.Controls.SetChildIndex(Me.RadioButton1, 0)
        Me.Controls.SetChildIndex(Me.RadioButton2, 0)
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.DlgPanel.ResumeLayout(False)
        CType(Me.NudDjhEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudDjhBegin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents TxtCpmc As System.Windows.Forms.TextBox
    Public WithEvents LblCpmc As System.Windows.Forms.Label
    Public WithEvents TxtHth As System.Windows.Forms.TextBox
    Public WithEvents LblHth As System.Windows.Forms.Label
    Public WithEvents TxtCpdm As System.Windows.Forms.TextBox
    Public WithEvents LblCpdm As System.Windows.Forms.Label
    Friend WithEvents CmbPzlxjc As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents TxtZydm As System.Windows.Forms.TextBox
    Public WithEvents LblZydm As System.Windows.Forms.Label
    Public WithEvents LblRkrqEnd As System.Windows.Forms.Label
    Public WithEvents DtpEnd As System.Windows.Forms.DateTimePicker
    Public WithEvents DtpBegin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents NudDjhEnd As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudDjhBegin As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ChbSh As System.Windows.Forms.CheckBox
    Friend WithEvents ChbLbfs As System.Windows.Forms.CheckBox
    Public WithEvents TxtCkdm As System.Windows.Forms.TextBox
    Public WithEvents LblCkdm As System.Windows.Forms.Label
    Public WithEvents TxtBmdm As System.Windows.Forms.TextBox
    Public WithEvents LblBmdm As System.Windows.Forms.Label
    Public WithEvents TxtFadmBegin As System.Windows.Forms.TextBox
    Public WithEvents LblFadmBegin As System.Windows.Forms.Label
    Public WithEvents TxtFadmEnd As System.Windows.Forms.TextBox
    Public WithEvents LblFadmEnd As System.Windows.Forms.Label
    Public WithEvents TxtLbdm As System.Windows.Forms.TextBox
    Public WithEvents LblLbdm As System.Windows.Forms.Label
    Friend WithEvents ChbZf As System.Windows.Forms.CheckBox
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Public WithEvents LblRkrqBegin As Label
End Class
