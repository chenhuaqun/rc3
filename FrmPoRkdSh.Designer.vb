﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPoRkdSh
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
        Me.TxtCkdm = New System.Windows.Forms.TextBox
        Me.LblCkdm = New System.Windows.Forms.Label
        Me.TxtCsdm = New System.Windows.Forms.TextBox
        Me.LblCsdm = New System.Windows.Forms.Label
        Me.CmbPzlxjc = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtZydm = New System.Windows.Forms.TextBox
        Me.LblZydm = New System.Windows.Forms.Label
        Me.ChbSh = New System.Windows.Forms.CheckBox
        Me.LblRkrqEnd = New System.Windows.Forms.Label
        Me.DtpEnd = New System.Windows.Forms.DateTimePicker
        Me.LblRkrqBegin = New System.Windows.Forms.Label
        Me.DtpBegin = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.NudDjhEnd = New System.Windows.Forms.NumericUpDown
        Me.NudDjhBegin = New System.Windows.Forms.NumericUpDown
        Me.Label4 = New System.Windows.Forms.Label
        Me.ChbJe = New System.Windows.Forms.CheckBox
        Me.TxtYspz = New System.Windows.Forms.TextBox
        Me.LblYspz = New System.Windows.Forms.Label
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
        Me.DlgPanel.Location = New System.Drawing.Point(217, 218)
        Me.DlgPanel.TabIndex = 20
        '
        'TxtCkdm
        '
        Me.TxtCkdm.Location = New System.Drawing.Point(100, 108)
        Me.TxtCkdm.MaxLength = 12
        Me.TxtCkdm.Name = "TxtCkdm"
        Me.TxtCkdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtCkdm.TabIndex = 11
        '
        'LblCkdm
        '
        Me.LblCkdm.AutoSize = True
        Me.LblCkdm.Location = New System.Drawing.Point(29, 112)
        Me.LblCkdm.Name = "LblCkdm"
        Me.LblCkdm.Size = New System.Drawing.Size(65, 12)
        Me.LblCkdm.TabIndex = 10
        Me.LblCkdm.Text = "仓库编码："
        '
        'TxtCsdm
        '
        Me.TxtCsdm.Location = New System.Drawing.Point(100, 137)
        Me.TxtCsdm.MaxLength = 12
        Me.TxtCsdm.Name = "TxtCsdm"
        Me.TxtCsdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtCsdm.TabIndex = 15
        '
        'LblCsdm
        '
        Me.LblCsdm.AutoSize = True
        Me.LblCsdm.Location = New System.Drawing.Point(29, 141)
        Me.LblCsdm.Name = "LblCsdm"
        Me.LblCsdm.Size = New System.Drawing.Size(77, 12)
        Me.LblCsdm.TabIndex = 14
        Me.LblCsdm.Text = "供应商编码："
        '
        'CmbPzlxjc
        '
        Me.CmbPzlxjc.Location = New System.Drawing.Point(100, 51)
        Me.CmbPzlxjc.Name = "CmbPzlxjc"
        Me.CmbPzlxjc.Size = New System.Drawing.Size(72, 20)
        Me.CmbPzlxjc.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "单据类型："
        '
        'TxtZydm
        '
        Me.TxtZydm.Location = New System.Drawing.Point(291, 108)
        Me.TxtZydm.MaxLength = 12
        Me.TxtZydm.Name = "TxtZydm"
        Me.TxtZydm.Size = New System.Drawing.Size(104, 21)
        Me.TxtZydm.TabIndex = 13
        '
        'LblZydm
        '
        Me.LblZydm.AutoSize = True
        Me.LblZydm.Location = New System.Drawing.Point(220, 112)
        Me.LblZydm.Name = "LblZydm"
        Me.LblZydm.Size = New System.Drawing.Size(65, 12)
        Me.LblZydm.TabIndex = 12
        Me.LblZydm.Text = "职员编码："
        '
        'ChbSh
        '
        Me.ChbSh.Checked = True
        Me.ChbSh.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChbSh.ForeColor = System.Drawing.Color.Teal
        Me.ChbSh.Location = New System.Drawing.Point(244, 175)
        Me.ChbSh.Name = "ChbSh"
        Me.ChbSh.Size = New System.Drawing.Size(151, 24)
        Me.ChbSh.TabIndex = 19
        Me.ChbSh.Text = "包含未审核的入库单"
        '
        'LblRkrqEnd
        '
        Me.LblRkrqEnd.AutoSize = True
        Me.LblRkrqEnd.Location = New System.Drawing.Point(261, 26)
        Me.LblRkrqEnd.Name = "LblRkrqEnd"
        Me.LblRkrqEnd.Size = New System.Drawing.Size(17, 12)
        Me.LblRkrqEnd.TabIndex = 2
        Me.LblRkrqEnd.Text = "至"
        '
        'DtpEnd
        '
        Me.DtpEnd.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpEnd.Location = New System.Drawing.Point(286, 22)
        Me.DtpEnd.Name = "DtpEnd"
        Me.DtpEnd.Size = New System.Drawing.Size(151, 21)
        Me.DtpEnd.TabIndex = 3
        '
        'LblRkrqBegin
        '
        Me.LblRkrqBegin.AutoSize = True
        Me.LblRkrqBegin.Location = New System.Drawing.Point(29, 26)
        Me.LblRkrqBegin.Name = "LblRkrqBegin"
        Me.LblRkrqBegin.Size = New System.Drawing.Size(65, 12)
        Me.LblRkrqBegin.TabIndex = 0
        Me.LblRkrqBegin.Text = "入库日期："
        '
        'DtpBegin
        '
        Me.DtpBegin.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpBegin.Location = New System.Drawing.Point(102, 22)
        Me.DtpBegin.Name = "DtpBegin"
        Me.DtpBegin.Size = New System.Drawing.Size(151, 21)
        Me.DtpBegin.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(164, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 12)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "至"
        '
        'NudDjhEnd
        '
        Me.NudDjhEnd.Location = New System.Drawing.Point(188, 79)
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
        Me.NudDjhBegin.Location = New System.Drawing.Point(100, 79)
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
        Me.Label4.Location = New System.Drawing.Point(29, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "单据编号："
        '
        'ChbJe
        '
        Me.ChbJe.ForeColor = System.Drawing.Color.Teal
        Me.ChbJe.Location = New System.Drawing.Point(69, 175)
        Me.ChbJe.Name = "ChbJe"
        Me.ChbJe.Size = New System.Drawing.Size(143, 24)
        Me.ChbJe.TabIndex = 18
        Me.ChbJe.Text = "入库金额不为0的单据"
        '
        'TxtYspz
        '
        Me.TxtYspz.Location = New System.Drawing.Point(291, 137)
        Me.TxtYspz.MaxLength = 15
        Me.TxtYspz.Name = "TxtYspz"
        Me.TxtYspz.Size = New System.Drawing.Size(104, 21)
        Me.TxtYspz.TabIndex = 17
        '
        'LblYspz
        '
        Me.LblYspz.AutoSize = True
        Me.LblYspz.Location = New System.Drawing.Point(220, 141)
        Me.LblYspz.Name = "LblYspz"
        Me.LblYspz.Size = New System.Drawing.Size(77, 12)
        Me.LblYspz.TabIndex = 16
        Me.LblYspz.Text = "原始凭证号："
        '
        'FrmPoRkdSh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(470, 261)
        Me.Controls.Add(Me.TxtYspz)
        Me.Controls.Add(Me.LblYspz)
        Me.Controls.Add(Me.ChbJe)
        Me.Controls.Add(Me.TxtCkdm)
        Me.Controls.Add(Me.LblCkdm)
        Me.Controls.Add(Me.TxtCsdm)
        Me.Controls.Add(Me.LblCsdm)
        Me.Controls.Add(Me.CmbPzlxjc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtZydm)
        Me.Controls.Add(Me.LblZydm)
        Me.Controls.Add(Me.ChbSh)
        Me.Controls.Add(Me.LblRkrqEnd)
        Me.Controls.Add(Me.DtpEnd)
        Me.Controls.Add(Me.LblRkrqBegin)
        Me.Controls.Add(Me.DtpBegin)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.NudDjhEnd)
        Me.Controls.Add(Me.NudDjhBegin)
        Me.Controls.Add(Me.Label4)
        Me.Name = "FrmPoRkdSh"
        Me.Text = "物料收货单审核"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.NudDjhBegin, 0)
        Me.Controls.SetChildIndex(Me.NudDjhEnd, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.DtpBegin, 0)
        Me.Controls.SetChildIndex(Me.LblRkrqBegin, 0)
        Me.Controls.SetChildIndex(Me.DtpEnd, 0)
        Me.Controls.SetChildIndex(Me.LblRkrqEnd, 0)
        Me.Controls.SetChildIndex(Me.ChbSh, 0)
        Me.Controls.SetChildIndex(Me.LblZydm, 0)
        Me.Controls.SetChildIndex(Me.TxtZydm, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.CmbPzlxjc, 0)
        Me.Controls.SetChildIndex(Me.LblCsdm, 0)
        Me.Controls.SetChildIndex(Me.TxtCsdm, 0)
        Me.Controls.SetChildIndex(Me.LblCkdm, 0)
        Me.Controls.SetChildIndex(Me.TxtCkdm, 0)
        Me.Controls.SetChildIndex(Me.ChbJe, 0)
        Me.Controls.SetChildIndex(Me.LblYspz, 0)
        Me.Controls.SetChildIndex(Me.TxtYspz, 0)
        Me.DlgPanel.ResumeLayout(False)
        CType(Me.NudDjhEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudDjhBegin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents TxtCkdm As System.Windows.Forms.TextBox
    Public WithEvents LblCkdm As System.Windows.Forms.Label
    Public WithEvents TxtCsdm As System.Windows.Forms.TextBox
    Public WithEvents LblCsdm As System.Windows.Forms.Label
    Friend WithEvents CmbPzlxjc As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents TxtZydm As System.Windows.Forms.TextBox
    Public WithEvents LblZydm As System.Windows.Forms.Label
    Friend WithEvents ChbSh As System.Windows.Forms.CheckBox
    Public WithEvents LblRkrqEnd As System.Windows.Forms.Label
    Public WithEvents DtpEnd As System.Windows.Forms.DateTimePicker
    Public WithEvents LblRkrqBegin As System.Windows.Forms.Label
    Public WithEvents DtpBegin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents NudDjhEnd As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudDjhBegin As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ChbJe As System.Windows.Forms.CheckBox
    Public WithEvents TxtYspz As System.Windows.Forms.TextBox
    Public WithEvents LblYspz As System.Windows.Forms.Label
End Class
