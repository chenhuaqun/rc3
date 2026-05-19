<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmFcspPcb
    Inherits models.FrmDlgPortrait

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ChbYe = New System.Windows.Forms.CheckBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.LblPcrq = New System.Windows.Forms.Label()
        Me.DtpPcrq = New System.Windows.Forms.DateTimePicker()
        Me.TxtLbdm = New System.Windows.Forms.TextBox()
        Me.LblLbdm = New System.Windows.Forms.Label()
        Me.TxtCpmc = New System.Windows.Forms.TextBox()
        Me.LblCpmc = New System.Windows.Forms.Label()
        Me.TxtCpdm = New System.Windows.Forms.TextBox()
        Me.LblCpdm = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.ChbCq = New System.Windows.Forms.CheckBox()
        Me.LblBmdm = New System.Windows.Forms.Label()
        Me.TxtBmdm = New System.Windows.Forms.TextBox()
        Me.TxtKhdm = New System.Windows.Forms.TextBox()
        Me.LblKhdm = New System.Windows.Forms.Label()
        Me.DlgPanel.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(124, 4)
        Me.BtnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnCancel.Size = New System.Drawing.Size(111, 34)
        '
        'BtnHelp
        '
        Me.BtnHelp.Location = New System.Drawing.Point(244, 4)
        Me.BtnHelp.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnHelp.Size = New System.Drawing.Size(112, 34)
        '
        'BtnOk
        '
        Me.BtnOk.Location = New System.Drawing.Point(4, 4)
        Me.BtnOk.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnOk.Size = New System.Drawing.Size(111, 34)
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(362, 395)
        Me.DlgPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.DlgPanel.Size = New System.Drawing.Size(363, 46)
        Me.DlgPanel.TabIndex = 17
        '
        'ChbYe
        '
        Me.ChbYe.Checked = True
        Me.ChbYe.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChbYe.ForeColor = System.Drawing.Color.SteelBlue
        Me.ChbYe.Location = New System.Drawing.Point(82, 216)
        Me.ChbYe.Margin = New System.Windows.Forms.Padding(4)
        Me.ChbYe.Name = "ChbYe"
        Me.ChbYe.Size = New System.Drawing.Size(226, 36)
        Me.ChbYe.TabIndex = 12
        Me.ChbYe.Text = "只显示有余额的物料"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(72, 317)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(4)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(598, 34)
        Me.ProgressBar1.TabIndex = 16
        '
        'LblPcrq
        '
        Me.LblPcrq.AutoSize = True
        Me.LblPcrq.Location = New System.Drawing.Point(69, 44)
        Me.LblPcrq.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPcrq.Name = "LblPcrq"
        Me.LblPcrq.Size = New System.Drawing.Size(98, 18)
        Me.LblPcrq.TabIndex = 0
        Me.LblPcrq.Text = "盘存日期："
        '
        'DtpPcrq
        '
        Me.DtpPcrq.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpPcrq.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpPcrq.Location = New System.Drawing.Point(178, 38)
        Me.DtpPcrq.Margin = New System.Windows.Forms.Padding(4)
        Me.DtpPcrq.Name = "DtpPcrq"
        Me.DtpPcrq.Size = New System.Drawing.Size(224, 28)
        Me.DtpPcrq.TabIndex = 1
        '
        'TxtLbdm
        '
        Me.TxtLbdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLbdm.Location = New System.Drawing.Point(178, 117)
        Me.TxtLbdm.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtLbdm.MaxLength = 15
        Me.TxtLbdm.Name = "TxtLbdm"
        Me.TxtLbdm.Size = New System.Drawing.Size(166, 28)
        Me.TxtLbdm.TabIndex = 7
        '
        'LblLbdm
        '
        Me.LblLbdm.AutoSize = True
        Me.LblLbdm.Location = New System.Drawing.Point(72, 123)
        Me.LblLbdm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblLbdm.Name = "LblLbdm"
        Me.LblLbdm.Size = New System.Drawing.Size(98, 18)
        Me.LblLbdm.TabIndex = 6
        Me.LblLbdm.Text = "物料类别："
        '
        'TxtCpmc
        '
        Me.TxtCpmc.Location = New System.Drawing.Point(502, 156)
        Me.TxtCpmc.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCpmc.MaxLength = 100
        Me.TxtCpmc.Name = "TxtCpmc"
        Me.TxtCpmc.Size = New System.Drawing.Size(166, 28)
        Me.TxtCpmc.TabIndex = 11
        '
        'LblCpmc
        '
        Me.LblCpmc.AutoSize = True
        Me.LblCpmc.Location = New System.Drawing.Point(396, 162)
        Me.LblCpmc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCpmc.Name = "LblCpmc"
        Me.LblCpmc.Size = New System.Drawing.Size(98, 18)
        Me.LblCpmc.TabIndex = 10
        Me.LblCpmc.Text = "物料描述："
        '
        'TxtCpdm
        '
        Me.TxtCpdm.Location = New System.Drawing.Point(178, 156)
        Me.TxtCpdm.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCpdm.MaxLength = 15
        Me.TxtCpdm.Name = "TxtCpdm"
        Me.TxtCpdm.Size = New System.Drawing.Size(166, 28)
        Me.TxtCpdm.TabIndex = 9
        '
        'LblCpdm
        '
        Me.LblCpdm.AutoSize = True
        Me.LblCpdm.Location = New System.Drawing.Point(69, 162)
        Me.LblCpdm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCpdm.Name = "LblCpdm"
        Me.LblCpdm.Size = New System.Drawing.Size(98, 18)
        Me.LblCpdm.TabIndex = 8
        Me.LblCpdm.Text = "物料编码："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(476, 266)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 18)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "天"
        Me.Label1.Visible = False
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(393, 262)
        Me.NumericUpDown1.Margin = New System.Windows.Forms.Padding(4)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(70, 28)
        Me.NumericUpDown1.TabIndex = 14
        Me.NumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown1.Value = New Decimal(New Integer() {90, 0, 0, 0})
        Me.NumericUpDown1.Visible = False
        '
        'ChbCq
        '
        Me.ChbCq.ForeColor = System.Drawing.Color.SteelBlue
        Me.ChbCq.Location = New System.Drawing.Point(82, 258)
        Me.ChbCq.Margin = New System.Windows.Forms.Padding(4)
        Me.ChbCq.Name = "ChbCq"
        Me.ChbCq.Size = New System.Drawing.Size(276, 36)
        Me.ChbCq.TabIndex = 13
        Me.ChbCq.Text = "只显示超期发出商品数据清单"
        '
        'LblBmdm
        '
        Me.LblBmdm.AutoSize = True
        Me.LblBmdm.Location = New System.Drawing.Point(69, 87)
        Me.LblBmdm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBmdm.Name = "LblBmdm"
        Me.LblBmdm.Size = New System.Drawing.Size(98, 18)
        Me.LblBmdm.TabIndex = 2
        Me.LblBmdm.Text = "部门编码："
        '
        'TxtBmdm
        '
        Me.TxtBmdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBmdm.Location = New System.Drawing.Point(178, 81)
        Me.TxtBmdm.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtBmdm.MaxLength = 15
        Me.TxtBmdm.Name = "TxtBmdm"
        Me.TxtBmdm.Size = New System.Drawing.Size(166, 28)
        Me.TxtBmdm.TabIndex = 3
        '
        'TxtKhdm
        '
        Me.TxtKhdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtKhdm.Location = New System.Drawing.Point(502, 77)
        Me.TxtKhdm.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtKhdm.MaxLength = 15
        Me.TxtKhdm.Name = "TxtKhdm"
        Me.TxtKhdm.Size = New System.Drawing.Size(166, 28)
        Me.TxtKhdm.TabIndex = 5
        '
        'LblKhdm
        '
        Me.LblKhdm.AutoSize = True
        Me.LblKhdm.Location = New System.Drawing.Point(396, 83)
        Me.LblKhdm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblKhdm.Name = "LblKhdm"
        Me.LblKhdm.Size = New System.Drawing.Size(98, 18)
        Me.LblKhdm.TabIndex = 4
        Me.LblKhdm.Text = "客户编码："
        '
        'FrmFcspPcb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(742, 460)
        Me.Controls.Add(Me.TxtKhdm)
        Me.Controls.Add(Me.LblKhdm)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.ChbCq)
        Me.Controls.Add(Me.TxtBmdm)
        Me.Controls.Add(Me.LblBmdm)
        Me.Controls.Add(Me.TxtCpmc)
        Me.Controls.Add(Me.LblCpmc)
        Me.Controls.Add(Me.TxtCpdm)
        Me.Controls.Add(Me.LblCpdm)
        Me.Controls.Add(Me.TxtLbdm)
        Me.Controls.Add(Me.LblLbdm)
        Me.Controls.Add(Me.ChbYe)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.LblPcrq)
        Me.Controls.Add(Me.DtpPcrq)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmFcspPcb"
        Me.Text = "发出商品盘存表"
        Me.Controls.SetChildIndex(Me.DtpPcrq, 0)
        Me.Controls.SetChildIndex(Me.LblPcrq, 0)
        Me.Controls.SetChildIndex(Me.ProgressBar1, 0)
        Me.Controls.SetChildIndex(Me.ChbYe, 0)
        Me.Controls.SetChildIndex(Me.LblLbdm, 0)
        Me.Controls.SetChildIndex(Me.TxtLbdm, 0)
        Me.Controls.SetChildIndex(Me.LblCpdm, 0)
        Me.Controls.SetChildIndex(Me.TxtCpdm, 0)
        Me.Controls.SetChildIndex(Me.LblCpmc, 0)
        Me.Controls.SetChildIndex(Me.TxtCpmc, 0)
        Me.Controls.SetChildIndex(Me.LblBmdm, 0)
        Me.Controls.SetChildIndex(Me.TxtBmdm, 0)
        Me.Controls.SetChildIndex(Me.ChbCq, 0)
        Me.Controls.SetChildIndex(Me.NumericUpDown1, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.LblKhdm, 0)
        Me.Controls.SetChildIndex(Me.TxtKhdm, 0)
        Me.DlgPanel.ResumeLayout(False)
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ChbYe As System.Windows.Forms.CheckBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Public WithEvents LblPcrq As System.Windows.Forms.Label
    Public WithEvents DtpPcrq As System.Windows.Forms.DateTimePicker
    Public WithEvents TxtLbdm As System.Windows.Forms.TextBox
    Public WithEvents LblLbdm As System.Windows.Forms.Label
    Public WithEvents TxtCpmc As System.Windows.Forms.TextBox
    Public WithEvents LblCpmc As System.Windows.Forms.Label
    Public WithEvents TxtCpdm As System.Windows.Forms.TextBox
    Public WithEvents LblCpdm As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents ChbCq As System.Windows.Forms.CheckBox
    Public WithEvents LblBmdm As Label
    Public WithEvents TxtBmdm As TextBox
    Public WithEvents TxtKhdm As TextBox
    Public WithEvents LblKhdm As Label
End Class
