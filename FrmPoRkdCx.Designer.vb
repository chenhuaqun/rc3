﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPoRkdCx
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
        Me.TxtCsdm = New System.Windows.Forms.TextBox
        Me.LblCsdm = New System.Windows.Forms.Label
        Me.TxtCpdm = New System.Windows.Forms.TextBox
        Me.LblCpdm = New System.Windows.Forms.Label
        Me.CmbPzlxjc = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtZydm = New System.Windows.Forms.TextBox
        Me.LblZydm = New System.Windows.Forms.Label
        Me.LblRkrqEnd = New System.Windows.Forms.Label
        Me.DtpEnd = New System.Windows.Forms.DateTimePicker
        Me.LblRkrqBegin = New System.Windows.Forms.Label
        Me.DtpBegin = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.NudEnd = New System.Windows.Forms.NumericUpDown
        Me.NudBegin = New System.Windows.Forms.NumericUpDown
        Me.Label4 = New System.Windows.Forms.Label
        Me.ChbSh = New System.Windows.Forms.CheckBox
        Me.ChbLbfs = New System.Windows.Forms.CheckBox
        Me.TxtCsmc = New System.Windows.Forms.TextBox
        Me.LblCsmc = New System.Windows.Forms.Label
        Me.TxtYspz = New System.Windows.Forms.TextBox
        Me.LblYspz = New System.Windows.Forms.Label
        Me.TxtCkdm = New System.Windows.Forms.TextBox
        Me.LblCkdm = New System.Windows.Forms.Label
        Me.ChbCq = New System.Windows.Forms.CheckBox
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.Label1 = New System.Windows.Forms.Label
        Me.ChbFp = New System.Windows.Forms.CheckBox
        Me.ChbZf = New System.Windows.Forms.CheckBox
        Me.ChbWfk = New System.Windows.Forms.CheckBox
        Me.TxtLbdm = New System.Windows.Forms.TextBox
        Me.LblLbdm = New System.Windows.Forms.Label
        Me.DlgPanel.SuspendLayout()
        CType(Me.NudEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudBegin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.DlgPanel.Location = New System.Drawing.Point(222, 346)
        Me.DlgPanel.TabIndex = 34
        '
        'TxtCpmc
        '
        Me.TxtCpmc.Location = New System.Drawing.Point(105, 167)
        Me.TxtCpmc.MaxLength = 100
        Me.TxtCpmc.Name = "TxtCpmc"
        Me.TxtCpmc.Size = New System.Drawing.Size(112, 21)
        Me.TxtCpmc.TabIndex = 17
        '
        'LblCpmc
        '
        Me.LblCpmc.AutoSize = True
        Me.LblCpmc.Location = New System.Drawing.Point(32, 171)
        Me.LblCpmc.Name = "LblCpmc"
        Me.LblCpmc.Size = New System.Drawing.Size(65, 12)
        Me.LblCpmc.TabIndex = 16
        Me.LblCpmc.Text = "物料描述："
        '
        'TxtCsdm
        '
        Me.TxtCsdm.Location = New System.Drawing.Point(105, 196)
        Me.TxtCsdm.MaxLength = 12
        Me.TxtCsdm.Name = "TxtCsdm"
        Me.TxtCsdm.Size = New System.Drawing.Size(112, 21)
        Me.TxtCsdm.TabIndex = 21
        '
        'LblCsdm
        '
        Me.LblCsdm.AutoSize = True
        Me.LblCsdm.Location = New System.Drawing.Point(32, 200)
        Me.LblCsdm.Name = "LblCsdm"
        Me.LblCsdm.Size = New System.Drawing.Size(77, 12)
        Me.LblCsdm.TabIndex = 20
        Me.LblCsdm.Text = "供应商编码："
        '
        'TxtCpdm
        '
        Me.TxtCpdm.Location = New System.Drawing.Point(104, 138)
        Me.TxtCpdm.MaxLength = 15
        Me.TxtCpdm.Name = "TxtCpdm"
        Me.TxtCpdm.Size = New System.Drawing.Size(112, 21)
        Me.TxtCpdm.TabIndex = 13
        '
        'LblCpdm
        '
        Me.LblCpdm.AutoSize = True
        Me.LblCpdm.Location = New System.Drawing.Point(32, 142)
        Me.LblCpdm.Name = "LblCpdm"
        Me.LblCpdm.Size = New System.Drawing.Size(65, 12)
        Me.LblCpdm.TabIndex = 12
        Me.LblCpdm.Text = "物料编码："
        '
        'CmbPzlxjc
        '
        Me.CmbPzlxjc.Location = New System.Drawing.Point(105, 52)
        Me.CmbPzlxjc.Name = "CmbPzlxjc"
        Me.CmbPzlxjc.Size = New System.Drawing.Size(72, 20)
        Me.CmbPzlxjc.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "单据类型："
        '
        'TxtZydm
        '
        Me.TxtZydm.Location = New System.Drawing.Point(297, 138)
        Me.TxtZydm.MaxLength = 12
        Me.TxtZydm.Name = "TxtZydm"
        Me.TxtZydm.Size = New System.Drawing.Size(112, 21)
        Me.TxtZydm.TabIndex = 15
        '
        'LblZydm
        '
        Me.LblZydm.AutoSize = True
        Me.LblZydm.Location = New System.Drawing.Point(224, 142)
        Me.LblZydm.Name = "LblZydm"
        Me.LblZydm.Size = New System.Drawing.Size(65, 12)
        Me.LblZydm.TabIndex = 14
        Me.LblZydm.Text = "职员编码："
        '
        'LblRkrqEnd
        '
        Me.LblRkrqEnd.AutoSize = True
        Me.LblRkrqEnd.Location = New System.Drawing.Point(264, 27)
        Me.LblRkrqEnd.Name = "LblRkrqEnd"
        Me.LblRkrqEnd.Size = New System.Drawing.Size(17, 12)
        Me.LblRkrqEnd.TabIndex = 2
        Me.LblRkrqEnd.Text = "至"
        '
        'DtpEnd
        '
        Me.DtpEnd.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpEnd.Location = New System.Drawing.Point(289, 23)
        Me.DtpEnd.Name = "DtpEnd"
        Me.DtpEnd.Size = New System.Drawing.Size(151, 21)
        Me.DtpEnd.TabIndex = 3
        '
        'LblRkrqBegin
        '
        Me.LblRkrqBegin.AutoSize = True
        Me.LblRkrqBegin.Location = New System.Drawing.Point(32, 27)
        Me.LblRkrqBegin.Name = "LblRkrqBegin"
        Me.LblRkrqBegin.Size = New System.Drawing.Size(65, 12)
        Me.LblRkrqBegin.TabIndex = 0
        Me.LblRkrqBegin.Text = "入库日期："
        '
        'DtpBegin
        '
        Me.DtpBegin.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpBegin.Location = New System.Drawing.Point(105, 23)
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
        'NudEnd
        '
        Me.NudEnd.Location = New System.Drawing.Point(191, 80)
        Me.NudEnd.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.NudEnd.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudEnd.Name = "NudEnd"
        Me.NudEnd.Size = New System.Drawing.Size(56, 21)
        Me.NudEnd.TabIndex = 9
        Me.NudEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudEnd.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        '
        'NudBegin
        '
        Me.NudBegin.Location = New System.Drawing.Point(105, 80)
        Me.NudBegin.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.NudBegin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudBegin.Name = "NudBegin"
        Me.NudBegin.Size = New System.Drawing.Size(56, 21)
        Me.NudBegin.TabIndex = 7
        Me.NudBegin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudBegin.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "单据编号："
        '
        'ChbSh
        '
        Me.ChbSh.ForeColor = System.Drawing.Color.SteelBlue
        Me.ChbSh.Location = New System.Drawing.Point(34, 262)
        Me.ChbSh.Name = "ChbSh"
        Me.ChbSh.Size = New System.Drawing.Size(168, 24)
        Me.ChbSh.TabIndex = 26
        Me.ChbSh.Text = "只显示未审核物料收货单"
        '
        'ChbLbfs
        '
        Me.ChbLbfs.Checked = True
        Me.ChbLbfs.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChbLbfs.ForeColor = System.Drawing.Color.SteelBlue
        Me.ChbLbfs.Location = New System.Drawing.Point(294, 310)
        Me.ChbLbfs.Name = "ChbLbfs"
        Me.ChbLbfs.Size = New System.Drawing.Size(104, 24)
        Me.ChbLbfs.TabIndex = 33
        Me.ChbLbfs.Text = "列表方式查询"
        '
        'TxtCsmc
        '
        Me.TxtCsmc.Location = New System.Drawing.Point(297, 196)
        Me.TxtCsmc.MaxLength = 12
        Me.TxtCsmc.Name = "TxtCsmc"
        Me.TxtCsmc.Size = New System.Drawing.Size(112, 21)
        Me.TxtCsmc.TabIndex = 23
        '
        'LblCsmc
        '
        Me.LblCsmc.AutoSize = True
        Me.LblCsmc.Location = New System.Drawing.Point(224, 200)
        Me.LblCsmc.Name = "LblCsmc"
        Me.LblCsmc.Size = New System.Drawing.Size(77, 12)
        Me.LblCsmc.TabIndex = 22
        Me.LblCsmc.Text = "供应商名称："
        '
        'TxtYspz
        '
        Me.TxtYspz.Location = New System.Drawing.Point(105, 225)
        Me.TxtYspz.MaxLength = 15
        Me.TxtYspz.Name = "TxtYspz"
        Me.TxtYspz.Size = New System.Drawing.Size(112, 21)
        Me.TxtYspz.TabIndex = 25
        '
        'LblYspz
        '
        Me.LblYspz.AutoSize = True
        Me.LblYspz.Location = New System.Drawing.Point(32, 229)
        Me.LblYspz.Name = "LblYspz"
        Me.LblYspz.Size = New System.Drawing.Size(77, 12)
        Me.LblYspz.TabIndex = 24
        Me.LblYspz.Text = "原始凭证号："
        '
        'TxtCkdm
        '
        Me.TxtCkdm.Location = New System.Drawing.Point(297, 167)
        Me.TxtCkdm.MaxLength = 12
        Me.TxtCkdm.Name = "TxtCkdm"
        Me.TxtCkdm.Size = New System.Drawing.Size(112, 21)
        Me.TxtCkdm.TabIndex = 19
        '
        'LblCkdm
        '
        Me.LblCkdm.AutoSize = True
        Me.LblCkdm.Location = New System.Drawing.Point(224, 171)
        Me.LblCkdm.Name = "LblCkdm"
        Me.LblCkdm.Size = New System.Drawing.Size(65, 12)
        Me.LblCkdm.TabIndex = 18
        Me.LblCkdm.Text = "仓库编码："
        '
        'ChbCq
        '
        Me.ChbCq.ForeColor = System.Drawing.Color.SteelBlue
        Me.ChbCq.Location = New System.Drawing.Point(34, 286)
        Me.ChbCq.Name = "ChbCq"
        Me.ChbCq.Size = New System.Drawing.Size(168, 24)
        Me.ChbCq.TabIndex = 28
        Me.ChbCq.Text = "只显示超期库存数据清单"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(200, 288)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(47, 21)
        Me.NumericUpDown1.TabIndex = 29
        Me.NumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown1.Value = New Decimal(New Integer() {90, 0, 0, 0})
        Me.NumericUpDown1.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(255, 292)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 12)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "天"
        Me.Label1.Visible = False
        '
        'ChbFp
        '
        Me.ChbFp.ForeColor = System.Drawing.Color.SteelBlue
        Me.ChbFp.Location = New System.Drawing.Point(294, 262)
        Me.ChbFp.Name = "ChbFp"
        Me.ChbFp.Size = New System.Drawing.Size(141, 24)
        Me.ChbFp.TabIndex = 27
        Me.ChbFp.Text = "只显示未开票数据"
        '
        'ChbZf
        '
        Me.ChbZf.ForeColor = System.Drawing.Color.SteelBlue
        Me.ChbZf.Location = New System.Drawing.Point(34, 310)
        Me.ChbZf.Name = "ChbZf"
        Me.ChbZf.Size = New System.Drawing.Size(104, 24)
        Me.ChbZf.TabIndex = 32
        Me.ChbZf.Text = "包含作废单据"
        '
        'ChbWfk
        '
        Me.ChbWfk.ForeColor = System.Drawing.Color.SteelBlue
        Me.ChbWfk.Location = New System.Drawing.Point(294, 286)
        Me.ChbWfk.Name = "ChbWfk"
        Me.ChbWfk.Size = New System.Drawing.Size(125, 24)
        Me.ChbWfk.TabIndex = 31
        Me.ChbWfk.Text = "只显示待付款清单"
        '
        'TxtLbdm
        '
        Me.TxtLbdm.Location = New System.Drawing.Point(105, 109)
        Me.TxtLbdm.MaxLength = 12
        Me.TxtLbdm.Name = "TxtLbdm"
        Me.TxtLbdm.Size = New System.Drawing.Size(111, 21)
        Me.TxtLbdm.TabIndex = 11
        '
        'LblLbdm
        '
        Me.LblLbdm.AutoSize = True
        Me.LblLbdm.Location = New System.Drawing.Point(32, 113)
        Me.LblLbdm.Name = "LblLbdm"
        Me.LblLbdm.Size = New System.Drawing.Size(65, 12)
        Me.LblLbdm.TabIndex = 10
        Me.LblLbdm.Text = "物料类别："
        '
        'FrmPoRkdCx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(475, 389)
        Me.Controls.Add(Me.TxtLbdm)
        Me.Controls.Add(Me.LblLbdm)
        Me.Controls.Add(Me.ChbWfk)
        Me.Controls.Add(Me.ChbZf)
        Me.Controls.Add(Me.ChbFp)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.ChbCq)
        Me.Controls.Add(Me.TxtCkdm)
        Me.Controls.Add(Me.LblCkdm)
        Me.Controls.Add(Me.TxtYspz)
        Me.Controls.Add(Me.LblYspz)
        Me.Controls.Add(Me.TxtCsmc)
        Me.Controls.Add(Me.LblCsmc)
        Me.Controls.Add(Me.ChbSh)
        Me.Controls.Add(Me.ChbLbfs)
        Me.Controls.Add(Me.TxtCpmc)
        Me.Controls.Add(Me.LblCpmc)
        Me.Controls.Add(Me.TxtCsdm)
        Me.Controls.Add(Me.LblCsdm)
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
        Me.Controls.Add(Me.NudEnd)
        Me.Controls.Add(Me.NudBegin)
        Me.Controls.Add(Me.Label4)
        Me.Name = "FrmPoRkdCx"
        Me.Text = "物料收货单查询"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.NudBegin, 0)
        Me.Controls.SetChildIndex(Me.NudEnd, 0)
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
        Me.Controls.SetChildIndex(Me.LblCsdm, 0)
        Me.Controls.SetChildIndex(Me.TxtCsdm, 0)
        Me.Controls.SetChildIndex(Me.LblCpmc, 0)
        Me.Controls.SetChildIndex(Me.TxtCpmc, 0)
        Me.Controls.SetChildIndex(Me.ChbLbfs, 0)
        Me.Controls.SetChildIndex(Me.ChbSh, 0)
        Me.Controls.SetChildIndex(Me.LblCsmc, 0)
        Me.Controls.SetChildIndex(Me.TxtCsmc, 0)
        Me.Controls.SetChildIndex(Me.LblYspz, 0)
        Me.Controls.SetChildIndex(Me.TxtYspz, 0)
        Me.Controls.SetChildIndex(Me.LblCkdm, 0)
        Me.Controls.SetChildIndex(Me.TxtCkdm, 0)
        Me.Controls.SetChildIndex(Me.ChbCq, 0)
        Me.Controls.SetChildIndex(Me.NumericUpDown1, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.ChbFp, 0)
        Me.Controls.SetChildIndex(Me.ChbZf, 0)
        Me.Controls.SetChildIndex(Me.ChbWfk, 0)
        Me.Controls.SetChildIndex(Me.LblLbdm, 0)
        Me.Controls.SetChildIndex(Me.TxtLbdm, 0)
        Me.DlgPanel.ResumeLayout(False)
        CType(Me.NudEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudBegin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents TxtCpmc As System.Windows.Forms.TextBox
    Public WithEvents LblCpmc As System.Windows.Forms.Label
    Public WithEvents TxtCsdm As System.Windows.Forms.TextBox
    Public WithEvents LblCsdm As System.Windows.Forms.Label
    Public WithEvents TxtCpdm As System.Windows.Forms.TextBox
    Public WithEvents LblCpdm As System.Windows.Forms.Label
    Friend WithEvents CmbPzlxjc As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents TxtZydm As System.Windows.Forms.TextBox
    Public WithEvents LblZydm As System.Windows.Forms.Label
    Public WithEvents LblRkrqEnd As System.Windows.Forms.Label
    Public WithEvents DtpEnd As System.Windows.Forms.DateTimePicker
    Public WithEvents LblRkrqBegin As System.Windows.Forms.Label
    Public WithEvents DtpBegin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents NudEnd As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudBegin As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ChbSh As System.Windows.Forms.CheckBox
    Friend WithEvents ChbLbfs As System.Windows.Forms.CheckBox
    Public WithEvents TxtCsmc As System.Windows.Forms.TextBox
    Public WithEvents LblCsmc As System.Windows.Forms.Label
    Public WithEvents TxtYspz As System.Windows.Forms.TextBox
    Public WithEvents LblYspz As System.Windows.Forms.Label
    Public WithEvents TxtCkdm As System.Windows.Forms.TextBox
    Public WithEvents LblCkdm As System.Windows.Forms.Label
    Friend WithEvents ChbCq As System.Windows.Forms.CheckBox
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ChbFp As System.Windows.Forms.CheckBox
    Friend WithEvents ChbZf As System.Windows.Forms.CheckBox
    Friend WithEvents ChbWfk As System.Windows.Forms.CheckBox
    Public WithEvents TxtLbdm As System.Windows.Forms.TextBox
    Public WithEvents LblLbdm As System.Windows.Forms.Label
End Class
