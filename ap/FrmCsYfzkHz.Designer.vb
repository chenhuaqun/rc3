<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCsYfzkHz
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
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.LblhzrqEnd = New System.Windows.Forms.Label
        Me.DtpHzrqEnd = New System.Windows.Forms.DateTimePicker
        Me.LblhzrqBegin = New System.Windows.Forms.Label
        Me.DtpHzrqBegin = New System.Windows.Forms.DateTimePicker
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.TxtZydm = New System.Windows.Forms.TextBox
        Me.LblZydm = New System.Windows.Forms.Label
        Me.DlgPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(260, 205)
        Me.DlgPanel.TabIndex = 9
        '
        'CheckBox1
        '
        Me.CheckBox1.ForeColor = System.Drawing.Color.SteelBlue
        Me.CheckBox1.Location = New System.Drawing.Point(129, 93)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(279, 24)
        Me.CheckBox1.TabIndex = 6
        Me.CheckBox1.Text = "只显示有余额或有发生额的供应商"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(46, 163)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(414, 23)
        Me.ProgressBar1.TabIndex = 8
        '
        'LblhzrqEnd
        '
        Me.LblhzrqEnd.AutoSize = True
        Me.LblhzrqEnd.Location = New System.Drawing.Point(280, 34)
        Me.LblhzrqEnd.Name = "LblhzrqEnd"
        Me.LblhzrqEnd.Size = New System.Drawing.Size(29, 12)
        Me.LblhzrqEnd.TabIndex = 2
        Me.LblhzrqEnd.Text = "至："
        '
        'DtpHzrqEnd
        '
        Me.DtpHzrqEnd.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpHzrqEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpHzrqEnd.Location = New System.Drawing.Point(317, 29)
        Me.DtpHzrqEnd.Name = "DtpHzrqEnd"
        Me.DtpHzrqEnd.Size = New System.Drawing.Size(143, 21)
        Me.DtpHzrqEnd.TabIndex = 3
        '
        'LblhzrqBegin
        '
        Me.LblhzrqBegin.AutoSize = True
        Me.LblhzrqBegin.Location = New System.Drawing.Point(44, 34)
        Me.LblhzrqBegin.Name = "LblhzrqBegin"
        Me.LblhzrqBegin.Size = New System.Drawing.Size(77, 12)
        Me.LblhzrqBegin.TabIndex = 0
        Me.LblhzrqBegin.Text = "汇总日期从："
        '
        'DtpHzrqBegin
        '
        Me.DtpHzrqBegin.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpHzrqBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpHzrqBegin.Location = New System.Drawing.Point(129, 29)
        Me.DtpHzrqBegin.Name = "DtpHzrqBegin"
        Me.DtpHzrqBegin.Size = New System.Drawing.Size(143, 21)
        Me.DtpHzrqBegin.TabIndex = 1
        '
        'CheckBox2
        '
        Me.CheckBox2.ForeColor = System.Drawing.Color.SteelBlue
        Me.CheckBox2.Location = New System.Drawing.Point(129, 123)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(197, 24)
        Me.CheckBox2.TabIndex = 7
        Me.CheckBox2.Text = "只显示有余额的供应商"
        '
        'TxtZydm
        '
        Me.TxtZydm.Location = New System.Drawing.Point(129, 58)
        Me.TxtZydm.MaxLength = 12
        Me.TxtZydm.Name = "TxtZydm"
        Me.TxtZydm.Size = New System.Drawing.Size(112, 21)
        Me.TxtZydm.TabIndex = 5
        '
        'LblZydm
        '
        Me.LblZydm.AutoSize = True
        Me.LblZydm.Location = New System.Drawing.Point(58, 62)
        Me.LblZydm.Name = "LblZydm"
        Me.LblZydm.Size = New System.Drawing.Size(65, 12)
        Me.LblZydm.TabIndex = 4
        Me.LblZydm.Text = "职员编码："
        '
        'FrmCsYfzkHz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(513, 248)
        Me.Controls.Add(Me.TxtZydm)
        Me.Controls.Add(Me.LblZydm)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.LblhzrqEnd)
        Me.Controls.Add(Me.DtpHzrqEnd)
        Me.Controls.Add(Me.LblhzrqBegin)
        Me.Controls.Add(Me.DtpHzrqBegin)
        Me.Name = "FrmCsYfzkHz"
        Me.Text = "供应商应付账款汇总表"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.DtpHzrqBegin, 0)
        Me.Controls.SetChildIndex(Me.LblhzrqBegin, 0)
        Me.Controls.SetChildIndex(Me.DtpHzrqEnd, 0)
        Me.Controls.SetChildIndex(Me.LblhzrqEnd, 0)
        Me.Controls.SetChildIndex(Me.ProgressBar1, 0)
        Me.Controls.SetChildIndex(Me.CheckBox1, 0)
        Me.Controls.SetChildIndex(Me.CheckBox2, 0)
        Me.Controls.SetChildIndex(Me.LblZydm, 0)
        Me.Controls.SetChildIndex(Me.TxtZydm, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Public WithEvents LblhzrqEnd As System.Windows.Forms.Label
    Public WithEvents DtpHzrqEnd As System.Windows.Forms.DateTimePicker
    Public WithEvents LblhzrqBegin As System.Windows.Forms.Label
    Public WithEvents DtpHzrqBegin As System.Windows.Forms.DateTimePicker
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Public WithEvents TxtZydm As System.Windows.Forms.TextBox
    Public WithEvents LblZydm As System.Windows.Forms.Label
End Class
