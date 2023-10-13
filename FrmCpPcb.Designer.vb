<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCpPcb
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
        Me.TxtCkdm = New System.Windows.Forms.TextBox()
        Me.LblCkdm = New System.Windows.Forms.Label()
        Me.ChbZdcb = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.ChbCq = New System.Windows.Forms.CheckBox()
        Me.ChbXsdj = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.DlgPanel.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(241, 267)
        '
        'ChbYe
        '
        Me.ChbYe.Checked = True
        Me.ChbYe.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChbYe.ForeColor = System.Drawing.Color.SteelBlue
        Me.ChbYe.Location = New System.Drawing.Point(55, 123)
        Me.ChbYe.Name = "ChbYe"
        Me.ChbYe.Size = New System.Drawing.Size(151, 24)
        Me.ChbYe.TabIndex = 10
        Me.ChbYe.Text = "只显示有余额的物料"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(48, 223)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(399, 23)
        Me.ProgressBar1.TabIndex = 18
        '
        'LblPcrq
        '
        Me.LblPcrq.AutoSize = True
        Me.LblPcrq.Location = New System.Drawing.Point(46, 29)
        Me.LblPcrq.Name = "LblPcrq"
        Me.LblPcrq.Size = New System.Drawing.Size(65, 12)
        Me.LblPcrq.TabIndex = 0
        Me.LblPcrq.Text = "盘存日期："
        '
        'DtpPcrq
        '
        Me.DtpPcrq.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpPcrq.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpPcrq.Location = New System.Drawing.Point(119, 25)
        Me.DtpPcrq.Name = "DtpPcrq"
        Me.DtpPcrq.Size = New System.Drawing.Size(151, 21)
        Me.DtpPcrq.TabIndex = 1
        '
        'TxtLbdm
        '
        Me.TxtLbdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLbdm.Location = New System.Drawing.Point(335, 54)
        Me.TxtLbdm.MaxLength = 15
        Me.TxtLbdm.Name = "TxtLbdm"
        Me.TxtLbdm.Size = New System.Drawing.Size(112, 21)
        Me.TxtLbdm.TabIndex = 5
        '
        'LblLbdm
        '
        Me.LblLbdm.AutoSize = True
        Me.LblLbdm.Location = New System.Drawing.Point(264, 58)
        Me.LblLbdm.Name = "LblLbdm"
        Me.LblLbdm.Size = New System.Drawing.Size(65, 12)
        Me.LblLbdm.TabIndex = 4
        Me.LblLbdm.Text = "物料类别："
        '
        'TxtCpmc
        '
        Me.TxtCpmc.Location = New System.Drawing.Point(335, 83)
        Me.TxtCpmc.MaxLength = 100
        Me.TxtCpmc.Name = "TxtCpmc"
        Me.TxtCpmc.Size = New System.Drawing.Size(112, 21)
        Me.TxtCpmc.TabIndex = 9
        '
        'LblCpmc
        '
        Me.LblCpmc.AutoSize = True
        Me.LblCpmc.Location = New System.Drawing.Point(264, 87)
        Me.LblCpmc.Name = "LblCpmc"
        Me.LblCpmc.Size = New System.Drawing.Size(65, 12)
        Me.LblCpmc.TabIndex = 8
        Me.LblCpmc.Text = "物料描述："
        '
        'TxtCpdm
        '
        Me.TxtCpdm.Location = New System.Drawing.Point(119, 83)
        Me.TxtCpdm.MaxLength = 15
        Me.TxtCpdm.Name = "TxtCpdm"
        Me.TxtCpdm.Size = New System.Drawing.Size(112, 21)
        Me.TxtCpdm.TabIndex = 7
        '
        'LblCpdm
        '
        Me.LblCpdm.AutoSize = True
        Me.LblCpdm.Location = New System.Drawing.Point(46, 87)
        Me.LblCpdm.Name = "LblCpdm"
        Me.LblCpdm.Size = New System.Drawing.Size(65, 12)
        Me.LblCpdm.TabIndex = 6
        Me.LblCpdm.Text = "物料编码："
        '
        'TxtCkdm
        '
        Me.TxtCkdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCkdm.Location = New System.Drawing.Point(119, 54)
        Me.TxtCkdm.MaxLength = 15
        Me.TxtCkdm.Name = "TxtCkdm"
        Me.TxtCkdm.Size = New System.Drawing.Size(112, 21)
        Me.TxtCkdm.TabIndex = 3
        '
        'LblCkdm
        '
        Me.LblCkdm.AutoSize = True
        Me.LblCkdm.Location = New System.Drawing.Point(46, 58)
        Me.LblCkdm.Name = "LblCkdm"
        Me.LblCkdm.Size = New System.Drawing.Size(65, 12)
        Me.LblCkdm.TabIndex = 2
        Me.LblCkdm.Text = "仓库编码："
        '
        'ChbZdcb
        '
        Me.ChbZdcb.ForeColor = System.Drawing.Color.SteelBlue
        Me.ChbZdcb.Location = New System.Drawing.Point(221, 123)
        Me.ChbZdcb.Name = "ChbZdcb"
        Me.ChbZdcb.Size = New System.Drawing.Size(224, 24)
        Me.ChbZdcb.TabIndex = 11
        Me.ChbZdcb.Text = "只显示库存余额小于最低储备的物资"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(286, 156)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 12)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "天"
        Me.Label1.Visible = False
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(231, 153)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(47, 21)
        Me.NumericUpDown1.TabIndex = 13
        Me.NumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown1.Value = New Decimal(New Integer() {90, 0, 0, 0})
        Me.NumericUpDown1.Visible = False
        '
        'ChbCq
        '
        Me.ChbCq.ForeColor = System.Drawing.Color.SteelBlue
        Me.ChbCq.Location = New System.Drawing.Point(55, 151)
        Me.ChbCq.Name = "ChbCq"
        Me.ChbCq.Size = New System.Drawing.Size(168, 24)
        Me.ChbCq.TabIndex = 12
        Me.ChbCq.Text = "只显示超期库存数据清单"
        '
        'ChbXsdj
        '
        Me.ChbXsdj.ForeColor = System.Drawing.Color.SteelBlue
        Me.ChbXsdj.Location = New System.Drawing.Point(55, 181)
        Me.ChbXsdj.Name = "ChbXsdj"
        Me.ChbXsdj.Size = New System.Drawing.Size(242, 24)
        Me.ChbXsdj.TabIndex = 15
        Me.ChbXsdj.Text = "按送货单数据重算平均销售不含税单价"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(371, 187)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 12)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "天"
        Me.Label2.Visible = False
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(303, 184)
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumericUpDown2.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(62, 21)
        Me.NumericUpDown2.TabIndex = 16
        Me.NumericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown2.Value = New Decimal(New Integer() {90, 0, 0, 0})
        Me.NumericUpDown2.Visible = False
        '
        'FrmCpPcb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(495, 310)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NumericUpDown2)
        Me.Controls.Add(Me.ChbXsdj)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.ChbCq)
        Me.Controls.Add(Me.ChbZdcb)
        Me.Controls.Add(Me.TxtCkdm)
        Me.Controls.Add(Me.LblCkdm)
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
        Me.Name = "FrmCpPcb"
        Me.Text = "物料盘存表"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
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
        Me.Controls.SetChildIndex(Me.LblCkdm, 0)
        Me.Controls.SetChildIndex(Me.TxtCkdm, 0)
        Me.Controls.SetChildIndex(Me.ChbZdcb, 0)
        Me.Controls.SetChildIndex(Me.ChbCq, 0)
        Me.Controls.SetChildIndex(Me.NumericUpDown1, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.ChbXsdj, 0)
        Me.Controls.SetChildIndex(Me.NumericUpDown2, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.DlgPanel.ResumeLayout(False)
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
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
    Public WithEvents TxtCkdm As System.Windows.Forms.TextBox
    Public WithEvents LblCkdm As System.Windows.Forms.Label
    Friend WithEvents ChbZdcb As System.Windows.Forms.CheckBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents ChbCq As System.Windows.Forms.CheckBox
    Friend WithEvents ChbXsdj As System.Windows.Forms.CheckBox
    Public WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
End Class
