<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSlSfcHz
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
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.LblhzrqEnd = New System.Windows.Forms.Label()
        Me.DtpHzrqEnd = New System.Windows.Forms.DateTimePicker()
        Me.LblhzrqBegin = New System.Windows.Forms.Label()
        Me.DtpHzrqBegin = New System.Windows.Forms.DateTimePicker()
        Me.TxtLbdm = New System.Windows.Forms.TextBox()
        Me.LblLbdm = New System.Windows.Forms.Label()
        Me.TxtCpmc = New System.Windows.Forms.TextBox()
        Me.LblCpmc = New System.Windows.Forms.Label()
        Me.TxtCpdmBegin = New System.Windows.Forms.TextBox()
        Me.LblCpdm = New System.Windows.Forms.Label()
        Me.TxtCkdmBegin = New System.Windows.Forms.TextBox()
        Me.LblCkdm = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdoHz = New System.Windows.Forms.RadioButton()
        Me.rdoCk = New System.Windows.Forms.RadioButton()
        Me.TxtCpdmEnd = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtCkdmEnd = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DlgPanel.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(238, 296)
        Me.DlgPanel.TabIndex = 19
        '
        'CheckBox1
        '
        Me.CheckBox1.ForeColor = System.Drawing.Color.SteelBlue
        Me.CheckBox1.Location = New System.Drawing.Point(143, 225)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(206, 24)
        Me.CheckBox1.TabIndex = 17
        Me.CheckBox1.Text = "只显示有余额或有发生额的产品"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(34, 255)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(418, 23)
        Me.ProgressBar1.TabIndex = 18
        '
        'LblhzrqEnd
        '
        Me.LblhzrqEnd.AutoSize = True
        Me.LblhzrqEnd.Location = New System.Drawing.Point(264, 84)
        Me.LblhzrqEnd.Name = "LblhzrqEnd"
        Me.LblhzrqEnd.Size = New System.Drawing.Size(29, 12)
        Me.LblhzrqEnd.TabIndex = 3
        Me.LblhzrqEnd.Text = "至："
        '
        'DtpHzrqEnd
        '
        Me.DtpHzrqEnd.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpHzrqEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpHzrqEnd.Location = New System.Drawing.Point(301, 80)
        Me.DtpHzrqEnd.Name = "DtpHzrqEnd"
        Me.DtpHzrqEnd.Size = New System.Drawing.Size(151, 21)
        Me.DtpHzrqEnd.TabIndex = 4
        '
        'LblhzrqBegin
        '
        Me.LblhzrqBegin.AutoSize = True
        Me.LblhzrqBegin.Location = New System.Drawing.Point(32, 84)
        Me.LblhzrqBegin.Name = "LblhzrqBegin"
        Me.LblhzrqBegin.Size = New System.Drawing.Size(65, 12)
        Me.LblhzrqBegin.TabIndex = 1
        Me.LblhzrqBegin.Text = "汇总日期："
        '
        'DtpHzrqBegin
        '
        Me.DtpHzrqBegin.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpHzrqBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpHzrqBegin.Location = New System.Drawing.Point(105, 80)
        Me.DtpHzrqBegin.Name = "DtpHzrqBegin"
        Me.DtpHzrqBegin.Size = New System.Drawing.Size(151, 21)
        Me.DtpHzrqBegin.TabIndex = 2
        '
        'TxtLbdm
        '
        Me.TxtLbdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLbdm.Location = New System.Drawing.Point(105, 109)
        Me.TxtLbdm.MaxLength = 15
        Me.TxtLbdm.Name = "TxtLbdm"
        Me.TxtLbdm.Size = New System.Drawing.Size(112, 21)
        Me.TxtLbdm.TabIndex = 6
        '
        'LblLbdm
        '
        Me.LblLbdm.AutoSize = True
        Me.LblLbdm.Location = New System.Drawing.Point(32, 113)
        Me.LblLbdm.Name = "LblLbdm"
        Me.LblLbdm.Size = New System.Drawing.Size(65, 12)
        Me.LblLbdm.TabIndex = 5
        Me.LblLbdm.Text = "物料类别："
        '
        'TxtCpmc
        '
        Me.TxtCpmc.Location = New System.Drawing.Point(105, 196)
        Me.TxtCpmc.MaxLength = 100
        Me.TxtCpmc.Name = "TxtCpmc"
        Me.TxtCpmc.Size = New System.Drawing.Size(308, 21)
        Me.TxtCpmc.TabIndex = 16
        '
        'LblCpmc
        '
        Me.LblCpmc.AutoSize = True
        Me.LblCpmc.Location = New System.Drawing.Point(32, 200)
        Me.LblCpmc.Name = "LblCpmc"
        Me.LblCpmc.Size = New System.Drawing.Size(65, 12)
        Me.LblCpmc.TabIndex = 15
        Me.LblCpmc.Text = "物料描述："
        '
        'TxtCpdmBegin
        '
        Me.TxtCpdmBegin.Location = New System.Drawing.Point(105, 167)
        Me.TxtCpdmBegin.MaxLength = 15
        Me.TxtCpdmBegin.Name = "TxtCpdmBegin"
        Me.TxtCpdmBegin.Size = New System.Drawing.Size(112, 21)
        Me.TxtCpdmBegin.TabIndex = 12
        '
        'LblCpdm
        '
        Me.LblCpdm.AutoSize = True
        Me.LblCpdm.Location = New System.Drawing.Point(32, 171)
        Me.LblCpdm.Name = "LblCpdm"
        Me.LblCpdm.Size = New System.Drawing.Size(65, 12)
        Me.LblCpdm.TabIndex = 11
        Me.LblCpdm.Text = "物料编码："
        '
        'TxtCkdmBegin
        '
        Me.TxtCkdmBegin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCkdmBegin.Location = New System.Drawing.Point(105, 138)
        Me.TxtCkdmBegin.MaxLength = 15
        Me.TxtCkdmBegin.Name = "TxtCkdmBegin"
        Me.TxtCkdmBegin.Size = New System.Drawing.Size(112, 21)
        Me.TxtCkdmBegin.TabIndex = 8
        '
        'LblCkdm
        '
        Me.LblCkdm.AutoSize = True
        Me.LblCkdm.Location = New System.Drawing.Point(32, 142)
        Me.LblCkdm.Name = "LblCkdm"
        Me.LblCkdm.Size = New System.Drawing.Size(65, 12)
        Me.LblCkdm.TabIndex = 7
        Me.LblCkdm.Text = "仓库编码："
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdoHz)
        Me.GroupBox1.Controls.Add(Me.rdoCk)
        Me.GroupBox1.Location = New System.Drawing.Point(34, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(418, 53)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'rdoHz
        '
        Me.rdoHz.AutoSize = True
        Me.rdoHz.Location = New System.Drawing.Point(267, 20)
        Me.rdoHz.Name = "rdoHz"
        Me.rdoHz.Size = New System.Drawing.Size(71, 16)
        Me.rdoHz.TabIndex = 1
        Me.rdoHz.Text = "汇总显示"
        Me.rdoHz.UseVisualStyleBackColor = True
        '
        'rdoCk
        '
        Me.rdoCk.AutoSize = True
        Me.rdoCk.Checked = True
        Me.rdoCk.Location = New System.Drawing.Point(73, 20)
        Me.rdoCk.Name = "rdoCk"
        Me.rdoCk.Size = New System.Drawing.Size(83, 16)
        Me.rdoCk.TabIndex = 0
        Me.rdoCk.TabStop = True
        Me.rdoCk.Text = "分仓库显示"
        Me.rdoCk.UseVisualStyleBackColor = True
        '
        'TxtCpdmEnd
        '
        Me.TxtCpdmEnd.Location = New System.Drawing.Point(301, 167)
        Me.TxtCpdmEnd.MaxLength = 15
        Me.TxtCpdmEnd.Name = "TxtCpdmEnd"
        Me.TxtCpdmEnd.Size = New System.Drawing.Size(112, 21)
        Me.TxtCpdmEnd.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(264, 171)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "至："
        '
        'TxtCkdmEnd
        '
        Me.TxtCkdmEnd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCkdmEnd.Location = New System.Drawing.Point(301, 138)
        Me.TxtCkdmEnd.MaxLength = 15
        Me.TxtCkdmEnd.Name = "TxtCkdmEnd"
        Me.TxtCkdmEnd.Size = New System.Drawing.Size(112, 21)
        Me.TxtCkdmEnd.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(264, 142)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "至："
        '
        'FrmSlSfcHz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 339)
        Me.Controls.Add(Me.TxtCkdmEnd)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtCpdmEnd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TxtCkdmBegin)
        Me.Controls.Add(Me.LblCkdm)
        Me.Controls.Add(Me.TxtCpmc)
        Me.Controls.Add(Me.LblCpmc)
        Me.Controls.Add(Me.TxtCpdmBegin)
        Me.Controls.Add(Me.LblCpdm)
        Me.Controls.Add(Me.TxtLbdm)
        Me.Controls.Add(Me.LblLbdm)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.LblhzrqEnd)
        Me.Controls.Add(Me.DtpHzrqEnd)
        Me.Controls.Add(Me.LblhzrqBegin)
        Me.Controls.Add(Me.DtpHzrqBegin)
        Me.Name = "FrmSlSfcHz"
        Me.Text = "仓库收发存汇总表"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.DtpHzrqBegin, 0)
        Me.Controls.SetChildIndex(Me.LblhzrqBegin, 0)
        Me.Controls.SetChildIndex(Me.DtpHzrqEnd, 0)
        Me.Controls.SetChildIndex(Me.LblhzrqEnd, 0)
        Me.Controls.SetChildIndex(Me.ProgressBar1, 0)
        Me.Controls.SetChildIndex(Me.CheckBox1, 0)
        Me.Controls.SetChildIndex(Me.LblLbdm, 0)
        Me.Controls.SetChildIndex(Me.TxtLbdm, 0)
        Me.Controls.SetChildIndex(Me.LblCpdm, 0)
        Me.Controls.SetChildIndex(Me.TxtCpdmBegin, 0)
        Me.Controls.SetChildIndex(Me.LblCpmc, 0)
        Me.Controls.SetChildIndex(Me.TxtCpmc, 0)
        Me.Controls.SetChildIndex(Me.LblCkdm, 0)
        Me.Controls.SetChildIndex(Me.TxtCkdmBegin, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.TxtCpdmEnd, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.TxtCkdmEnd, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Public WithEvents LblhzrqEnd As System.Windows.Forms.Label
    Public WithEvents DtpHzrqEnd As System.Windows.Forms.DateTimePicker
    Public WithEvents LblhzrqBegin As System.Windows.Forms.Label
    Public WithEvents DtpHzrqBegin As System.Windows.Forms.DateTimePicker
    Public WithEvents TxtLbdm As System.Windows.Forms.TextBox
    Public WithEvents LblLbdm As System.Windows.Forms.Label
    Public WithEvents TxtCpmc As System.Windows.Forms.TextBox
    Public WithEvents LblCpmc As System.Windows.Forms.Label
    Public WithEvents TxtCpdmBegin As System.Windows.Forms.TextBox
    Public WithEvents LblCpdm As System.Windows.Forms.Label
    Public WithEvents TxtCkdmBegin As System.Windows.Forms.TextBox
    Public WithEvents LblCkdm As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoHz As System.Windows.Forms.RadioButton
    Friend WithEvents rdoCk As System.Windows.Forms.RadioButton
    Public WithEvents TxtCpdmEnd As System.Windows.Forms.TextBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents TxtCkdmEnd As System.Windows.Forms.TextBox
    Public WithEvents Label2 As System.Windows.Forms.Label
End Class
