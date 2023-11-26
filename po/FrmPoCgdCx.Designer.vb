<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPoCgdCx
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
        Me.TxtCpmc = New System.Windows.Forms.TextBox
        Me.LblCpmc = New System.Windows.Forms.Label
        Me.TxtCpdm = New System.Windows.Forms.TextBox
        Me.LblCpdm = New System.Windows.Forms.Label
        Me.CmbPzlxjc = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblRkrqEnd = New System.Windows.Forms.Label
        Me.DtpEnd = New System.Windows.Forms.DateTimePicker
        Me.LblBegin = New System.Windows.Forms.Label
        Me.DtpBegin = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.NudDjhEnd = New System.Windows.Forms.NumericUpDown
        Me.NudDjhBegin = New System.Windows.Forms.NumericUpDown
        Me.Label4 = New System.Windows.Forms.Label
        Me.ChbSh = New System.Windows.Forms.CheckBox
        Me.ChbLbfs = New System.Windows.Forms.CheckBox
        Me.TxtCsdm = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.ChbRk = New System.Windows.Forms.CheckBox
        Me.ChbWfk = New System.Windows.Forms.CheckBox
        Me.TxtLbdm = New System.Windows.Forms.TextBox
        Me.LblLbdm = New System.Windows.Forms.Label
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
        Me.DlgPanel.Location = New System.Drawing.Point(226, 271)
        Me.DlgPanel.TabIndex = 22
        '
        'TxtCpmc
        '
        Me.TxtCpmc.Location = New System.Drawing.Point(314, 138)
        Me.TxtCpmc.MaxLength = 100
        Me.TxtCpmc.Name = "TxtCpmc"
        Me.TxtCpmc.Size = New System.Drawing.Size(111, 21)
        Me.TxtCpmc.TabIndex = 15
        '
        'LblCpmc
        '
        Me.LblCpmc.AutoSize = True
        Me.LblCpmc.Location = New System.Drawing.Point(241, 142)
        Me.LblCpmc.Name = "LblCpmc"
        Me.LblCpmc.Size = New System.Drawing.Size(65, 12)
        Me.LblCpmc.TabIndex = 14
        Me.LblCpmc.Text = "物料描述："
        '
        'TxtCpdm
        '
        Me.TxtCpdm.Location = New System.Drawing.Point(106, 138)
        Me.TxtCpdm.MaxLength = 15
        Me.TxtCpdm.Name = "TxtCpdm"
        Me.TxtCpdm.Size = New System.Drawing.Size(111, 21)
        Me.TxtCpdm.TabIndex = 13
        '
        'LblCpdm
        '
        Me.LblCpdm.AutoSize = True
        Me.LblCpdm.Location = New System.Drawing.Point(33, 142)
        Me.LblCpdm.Name = "LblCpdm"
        Me.LblCpdm.Size = New System.Drawing.Size(65, 12)
        Me.LblCpdm.TabIndex = 12
        Me.LblCpdm.Text = "物料编码："
        '
        'CmbPzlxjc
        '
        Me.CmbPzlxjc.Location = New System.Drawing.Point(106, 52)
        Me.CmbPzlxjc.Name = "CmbPzlxjc"
        Me.CmbPzlxjc.Size = New System.Drawing.Size(72, 20)
        Me.CmbPzlxjc.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "单据类型："
        '
        'LblRkrqEnd
        '
        Me.LblRkrqEnd.AutoSize = True
        Me.LblRkrqEnd.Location = New System.Drawing.Point(265, 27)
        Me.LblRkrqEnd.Name = "LblRkrqEnd"
        Me.LblRkrqEnd.Size = New System.Drawing.Size(17, 12)
        Me.LblRkrqEnd.TabIndex = 2
        Me.LblRkrqEnd.Text = "至"
        '
        'DtpEnd
        '
        Me.DtpEnd.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpEnd.Location = New System.Drawing.Point(290, 23)
        Me.DtpEnd.Name = "DtpEnd"
        Me.DtpEnd.Size = New System.Drawing.Size(151, 21)
        Me.DtpEnd.TabIndex = 3
        '
        'LblBegin
        '
        Me.LblBegin.AutoSize = True
        Me.LblBegin.Location = New System.Drawing.Point(33, 27)
        Me.LblBegin.Name = "LblBegin"
        Me.LblBegin.Size = New System.Drawing.Size(65, 12)
        Me.LblBegin.TabIndex = 0
        Me.LblBegin.Text = "签单日期："
        '
        'DtpBegin
        '
        Me.DtpBegin.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpBegin.Location = New System.Drawing.Point(106, 23)
        Me.DtpBegin.Name = "DtpBegin"
        Me.DtpBegin.Size = New System.Drawing.Size(151, 21)
        Me.DtpBegin.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(167, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 12)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "至"
        '
        'NudDjhEnd
        '
        Me.NudDjhEnd.Location = New System.Drawing.Point(191, 80)
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
        Me.NudDjhBegin.Location = New System.Drawing.Point(106, 80)
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
        Me.Label4.Location = New System.Drawing.Point(33, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "单据编号："
        '
        'ChbSh
        '
        Me.ChbSh.ForeColor = System.Drawing.Color.SteelBlue
        Me.ChbSh.Location = New System.Drawing.Point(56, 202)
        Me.ChbSh.Name = "ChbSh"
        Me.ChbSh.Size = New System.Drawing.Size(153, 24)
        Me.ChbSh.TabIndex = 18
        Me.ChbSh.Text = "只显示未审核采购订单"
        '
        'ChbLbfs
        '
        Me.ChbLbfs.Checked = True
        Me.ChbLbfs.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChbLbfs.ForeColor = System.Drawing.Color.SteelBlue
        Me.ChbLbfs.Location = New System.Drawing.Point(245, 226)
        Me.ChbLbfs.Name = "ChbLbfs"
        Me.ChbLbfs.Size = New System.Drawing.Size(104, 24)
        Me.ChbLbfs.TabIndex = 21
        Me.ChbLbfs.Text = "列表方式查询"
        '
        'TxtCsdm
        '
        Me.TxtCsdm.Location = New System.Drawing.Point(106, 167)
        Me.TxtCsdm.MaxLength = 15
        Me.TxtCsdm.Name = "TxtCsdm"
        Me.TxtCsdm.Size = New System.Drawing.Size(111, 21)
        Me.TxtCsdm.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 171)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 12)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "供应商编码："
        '
        'ChbRk
        '
        Me.ChbRk.ForeColor = System.Drawing.Color.SteelBlue
        Me.ChbRk.Location = New System.Drawing.Point(245, 202)
        Me.ChbRk.Name = "ChbRk"
        Me.ChbRk.Size = New System.Drawing.Size(164, 24)
        Me.ChbRk.TabIndex = 19
        Me.ChbRk.Text = "只显示未收货的采购订单"
        '
        'ChbWfk
        '
        Me.ChbWfk.ForeColor = System.Drawing.Color.SteelBlue
        Me.ChbWfk.Location = New System.Drawing.Point(56, 226)
        Me.ChbWfk.Name = "ChbWfk"
        Me.ChbWfk.Size = New System.Drawing.Size(164, 24)
        Me.ChbWfk.TabIndex = 20
        Me.ChbWfk.Text = "只显示待付款清单"
        '
        'TxtLbdm
        '
        Me.TxtLbdm.Location = New System.Drawing.Point(106, 109)
        Me.TxtLbdm.MaxLength = 12
        Me.TxtLbdm.Name = "TxtLbdm"
        Me.TxtLbdm.Size = New System.Drawing.Size(111, 21)
        Me.TxtLbdm.TabIndex = 11
        '
        'LblLbdm
        '
        Me.LblLbdm.AutoSize = True
        Me.LblLbdm.Location = New System.Drawing.Point(33, 113)
        Me.LblLbdm.Name = "LblLbdm"
        Me.LblLbdm.Size = New System.Drawing.Size(65, 12)
        Me.LblLbdm.TabIndex = 10
        Me.LblLbdm.Text = "物料类别："
        '
        'FrmPoCgdCx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(479, 314)
        Me.Controls.Add(Me.TxtLbdm)
        Me.Controls.Add(Me.LblLbdm)
        Me.Controls.Add(Me.ChbWfk)
        Me.Controls.Add(Me.NudDjhBegin)
        Me.Controls.Add(Me.ChbRk)
        Me.Controls.Add(Me.TxtCsdm)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ChbSh)
        Me.Controls.Add(Me.ChbLbfs)
        Me.Controls.Add(Me.TxtCpmc)
        Me.Controls.Add(Me.LblCpmc)
        Me.Controls.Add(Me.TxtCpdm)
        Me.Controls.Add(Me.LblCpdm)
        Me.Controls.Add(Me.CmbPzlxjc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblRkrqEnd)
        Me.Controls.Add(Me.DtpEnd)
        Me.Controls.Add(Me.LblBegin)
        Me.Controls.Add(Me.DtpBegin)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.NudDjhEnd)
        Me.Controls.Add(Me.Label4)
        Me.Name = "FrmPoCgdCx"
        Me.Text = "物料采购订单查询"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.NudDjhEnd, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.DtpBegin, 0)
        Me.Controls.SetChildIndex(Me.LblBegin, 0)
        Me.Controls.SetChildIndex(Me.DtpEnd, 0)
        Me.Controls.SetChildIndex(Me.LblRkrqEnd, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.CmbPzlxjc, 0)
        Me.Controls.SetChildIndex(Me.LblCpdm, 0)
        Me.Controls.SetChildIndex(Me.TxtCpdm, 0)
        Me.Controls.SetChildIndex(Me.LblCpmc, 0)
        Me.Controls.SetChildIndex(Me.TxtCpmc, 0)
        Me.Controls.SetChildIndex(Me.ChbLbfs, 0)
        Me.Controls.SetChildIndex(Me.ChbSh, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.TxtCsdm, 0)
        Me.Controls.SetChildIndex(Me.ChbRk, 0)
        Me.Controls.SetChildIndex(Me.NudDjhBegin, 0)
        Me.Controls.SetChildIndex(Me.ChbWfk, 0)
        Me.Controls.SetChildIndex(Me.LblLbdm, 0)
        Me.Controls.SetChildIndex(Me.TxtLbdm, 0)
        Me.DlgPanel.ResumeLayout(False)
        CType(Me.NudDjhEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudDjhBegin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents TxtCpmc As System.Windows.Forms.TextBox
    Public WithEvents LblCpmc As System.Windows.Forms.Label
    Public WithEvents TxtCpdm As System.Windows.Forms.TextBox
    Public WithEvents LblCpdm As System.Windows.Forms.Label
    Friend WithEvents CmbPzlxjc As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents LblRkrqEnd As System.Windows.Forms.Label
    Public WithEvents DtpEnd As System.Windows.Forms.DateTimePicker
    Public WithEvents LblBegin As System.Windows.Forms.Label
    Public WithEvents DtpBegin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents NudDjhEnd As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudDjhBegin As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ChbSh As System.Windows.Forms.CheckBox
    Friend WithEvents ChbLbfs As System.Windows.Forms.CheckBox
    Public WithEvents TxtCsdm As System.Windows.Forms.TextBox
    Public WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ChbRk As System.Windows.Forms.CheckBox
    Friend WithEvents ChbWfk As System.Windows.Forms.CheckBox
    Public WithEvents TxtLbdm As System.Windows.Forms.TextBox
    Public WithEvents LblLbdm As System.Windows.Forms.Label
End Class
