<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSkdCx
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
        Me.TxtKhdm = New System.Windows.Forms.TextBox
        Me.LblKhdm = New System.Windows.Forms.Label
        Me.NudDjhEnd = New System.Windows.Forms.NumericUpDown
        Me.LblDjhEnd = New System.Windows.Forms.Label
        Me.NudDjhBegin = New System.Windows.Forms.NumericUpDown
        Me.LblDjhBegin = New System.Windows.Forms.Label
        Me.LblEnd = New System.Windows.Forms.Label
        Me.DtpEnd = New System.Windows.Forms.DateTimePicker
        Me.LblBegin = New System.Windows.Forms.Label
        Me.DtpBegin = New System.Windows.Forms.DateTimePicker
        Me.TxtYspz = New System.Windows.Forms.TextBox
        Me.LblYspz = New System.Windows.Forms.Label
        Me.TxtKmdm = New System.Windows.Forms.TextBox
        Me.LblKmdm = New System.Windows.Forms.Label
        Me.ChbWhx = New System.Windows.Forms.CheckBox
        Me.LblJsfsdm = New System.Windows.Forms.Label
        Me.TxtJsfsdm = New System.Windows.Forms.TextBox
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
        Me.DlgPanel.Location = New System.Drawing.Point(230, 197)
        Me.DlgPanel.TabIndex = 17
        '
        'TxtKhdm
        '
        Me.TxtKhdm.Location = New System.Drawing.Point(102, 96)
        Me.TxtKhdm.MaxLength = 15
        Me.TxtKhdm.Name = "TxtKhdm"
        Me.TxtKhdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtKhdm.TabIndex = 9
        '
        'LblKhdm
        '
        Me.LblKhdm.AutoSize = True
        Me.LblKhdm.Location = New System.Drawing.Point(30, 100)
        Me.LblKhdm.Name = "LblKhdm"
        Me.LblKhdm.Size = New System.Drawing.Size(65, 12)
        Me.LblKhdm.TabIndex = 8
        Me.LblKhdm.Text = "客户编码："
        '
        'NudDjhEnd
        '
        Me.NudDjhEnd.Location = New System.Drawing.Point(190, 59)
        Me.NudDjhEnd.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.NudDjhEnd.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudDjhEnd.Name = "NudDjhEnd"
        Me.NudDjhEnd.Size = New System.Drawing.Size(56, 21)
        Me.NudDjhEnd.TabIndex = 7
        Me.NudDjhEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudDjhEnd.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        '
        'LblDjhEnd
        '
        Me.LblDjhEnd.AutoSize = True
        Me.LblDjhEnd.Location = New System.Drawing.Point(166, 63)
        Me.LblDjhEnd.Name = "LblDjhEnd"
        Me.LblDjhEnd.Size = New System.Drawing.Size(17, 12)
        Me.LblDjhEnd.TabIndex = 6
        Me.LblDjhEnd.Text = "至"
        '
        'NudDjhBegin
        '
        Me.NudDjhBegin.Location = New System.Drawing.Point(102, 59)
        Me.NudDjhBegin.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.NudDjhBegin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudDjhBegin.Name = "NudDjhBegin"
        Me.NudDjhBegin.Size = New System.Drawing.Size(56, 21)
        Me.NudDjhBegin.TabIndex = 5
        Me.NudDjhBegin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudDjhBegin.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'LblDjhBegin
        '
        Me.LblDjhBegin.AutoSize = True
        Me.LblDjhBegin.Location = New System.Drawing.Point(30, 63)
        Me.LblDjhBegin.Name = "LblDjhBegin"
        Me.LblDjhBegin.Size = New System.Drawing.Size(65, 12)
        Me.LblDjhBegin.TabIndex = 4
        Me.LblDjhBegin.Text = "单 据 号："
        '
        'LblEnd
        '
        Me.LblEnd.AutoSize = True
        Me.LblEnd.Location = New System.Drawing.Point(262, 31)
        Me.LblEnd.Name = "LblEnd"
        Me.LblEnd.Size = New System.Drawing.Size(17, 12)
        Me.LblEnd.TabIndex = 2
        Me.LblEnd.Text = "至"
        '
        'DtpEnd
        '
        Me.DtpEnd.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpEnd.Location = New System.Drawing.Point(287, 27)
        Me.DtpEnd.Name = "DtpEnd"
        Me.DtpEnd.Size = New System.Drawing.Size(151, 21)
        Me.DtpEnd.TabIndex = 3
        '
        'LblBegin
        '
        Me.LblBegin.AutoSize = True
        Me.LblBegin.Location = New System.Drawing.Point(30, 31)
        Me.LblBegin.Name = "LblBegin"
        Me.LblBegin.Size = New System.Drawing.Size(65, 12)
        Me.LblBegin.TabIndex = 0
        Me.LblBegin.Text = "日    期："
        '
        'DtpBegin
        '
        Me.DtpBegin.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpBegin.Location = New System.Drawing.Point(103, 27)
        Me.DtpBegin.Name = "DtpBegin"
        Me.DtpBegin.Size = New System.Drawing.Size(151, 21)
        Me.DtpBegin.TabIndex = 1
        '
        'TxtYspz
        '
        Me.TxtYspz.Location = New System.Drawing.Point(289, 125)
        Me.TxtYspz.MaxLength = 15
        Me.TxtYspz.Name = "TxtYspz"
        Me.TxtYspz.Size = New System.Drawing.Size(104, 21)
        Me.TxtYspz.TabIndex = 15
        '
        'LblYspz
        '
        Me.LblYspz.AutoSize = True
        Me.LblYspz.Location = New System.Drawing.Point(217, 129)
        Me.LblYspz.Name = "LblYspz"
        Me.LblYspz.Size = New System.Drawing.Size(65, 12)
        Me.LblYspz.TabIndex = 14
        Me.LblYspz.Text = "原始凭证："
        '
        'TxtKmdm
        '
        Me.TxtKmdm.Location = New System.Drawing.Point(102, 125)
        Me.TxtKmdm.MaxLength = 15
        Me.TxtKmdm.Name = "TxtKmdm"
        Me.TxtKmdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtKmdm.TabIndex = 13
        '
        'LblKmdm
        '
        Me.LblKmdm.AutoSize = True
        Me.LblKmdm.Location = New System.Drawing.Point(32, 129)
        Me.LblKmdm.Name = "LblKmdm"
        Me.LblKmdm.Size = New System.Drawing.Size(65, 12)
        Me.LblKmdm.TabIndex = 12
        Me.LblKmdm.Text = "科目编码："
        '
        'ChbWhx
        '
        Me.ChbWhx.ForeColor = System.Drawing.Color.Navy
        Me.ChbWhx.Location = New System.Drawing.Point(168, 160)
        Me.ChbWhx.Name = "ChbWhx"
        Me.ChbWhx.Size = New System.Drawing.Size(157, 24)
        Me.ChbWhx.TabIndex = 16
        Me.ChbWhx.Text = "只显示未核销收款单"
        '
        'LblJsfsdm
        '
        Me.LblJsfsdm.AutoSize = True
        Me.LblJsfsdm.Location = New System.Drawing.Point(216, 100)
        Me.LblJsfsdm.Name = "LblJsfsdm"
        Me.LblJsfsdm.Size = New System.Drawing.Size(65, 12)
        Me.LblJsfsdm.TabIndex = 10
        Me.LblJsfsdm.Text = "结算方式："
        '
        'TxtJsfsdm
        '
        Me.TxtJsfsdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtJsfsdm.Location = New System.Drawing.Point(289, 96)
        Me.TxtJsfsdm.MaxLength = 12
        Me.TxtJsfsdm.Name = "TxtJsfsdm"
        Me.TxtJsfsdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtJsfsdm.TabIndex = 11
        '
        'FrmSkdCx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 240)
        Me.Controls.Add(Me.LblJsfsdm)
        Me.Controls.Add(Me.TxtJsfsdm)
        Me.Controls.Add(Me.ChbWhx)
        Me.Controls.Add(Me.TxtKmdm)
        Me.Controls.Add(Me.LblKmdm)
        Me.Controls.Add(Me.TxtYspz)
        Me.Controls.Add(Me.LblYspz)
        Me.Controls.Add(Me.TxtKhdm)
        Me.Controls.Add(Me.LblKhdm)
        Me.Controls.Add(Me.NudDjhEnd)
        Me.Controls.Add(Me.LblDjhEnd)
        Me.Controls.Add(Me.NudDjhBegin)
        Me.Controls.Add(Me.LblDjhBegin)
        Me.Controls.Add(Me.LblEnd)
        Me.Controls.Add(Me.DtpEnd)
        Me.Controls.Add(Me.LblBegin)
        Me.Controls.Add(Me.DtpBegin)
        Me.Name = "FrmSkdCx"
        Me.Text = "收款单查询范围"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.DtpBegin, 0)
        Me.Controls.SetChildIndex(Me.LblBegin, 0)
        Me.Controls.SetChildIndex(Me.DtpEnd, 0)
        Me.Controls.SetChildIndex(Me.LblEnd, 0)
        Me.Controls.SetChildIndex(Me.LblDjhBegin, 0)
        Me.Controls.SetChildIndex(Me.NudDjhBegin, 0)
        Me.Controls.SetChildIndex(Me.LblDjhEnd, 0)
        Me.Controls.SetChildIndex(Me.NudDjhEnd, 0)
        Me.Controls.SetChildIndex(Me.LblKhdm, 0)
        Me.Controls.SetChildIndex(Me.TxtKhdm, 0)
        Me.Controls.SetChildIndex(Me.LblYspz, 0)
        Me.Controls.SetChildIndex(Me.TxtYspz, 0)
        Me.Controls.SetChildIndex(Me.LblKmdm, 0)
        Me.Controls.SetChildIndex(Me.TxtKmdm, 0)
        Me.Controls.SetChildIndex(Me.ChbWhx, 0)
        Me.Controls.SetChildIndex(Me.TxtJsfsdm, 0)
        Me.Controls.SetChildIndex(Me.LblJsfsdm, 0)
        Me.DlgPanel.ResumeLayout(False)
        CType(Me.NudDjhEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudDjhBegin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents TxtKhdm As System.Windows.Forms.TextBox
    Public WithEvents LblKhdm As System.Windows.Forms.Label
    Public WithEvents NudDjhEnd As System.Windows.Forms.NumericUpDown
    Public WithEvents LblDjhEnd As System.Windows.Forms.Label
    Public WithEvents NudDjhBegin As System.Windows.Forms.NumericUpDown
    Public WithEvents LblDjhBegin As System.Windows.Forms.Label
    Public WithEvents LblEnd As System.Windows.Forms.Label
    Public WithEvents DtpEnd As System.Windows.Forms.DateTimePicker
    Public WithEvents LblBegin As System.Windows.Forms.Label
    Public WithEvents DtpBegin As System.Windows.Forms.DateTimePicker
    Public WithEvents TxtYspz As System.Windows.Forms.TextBox
    Public WithEvents LblYspz As System.Windows.Forms.Label
    Public WithEvents TxtKmdm As System.Windows.Forms.TextBox
    Public WithEvents LblKmdm As System.Windows.Forms.Label
    Friend WithEvents ChbWhx As System.Windows.Forms.CheckBox
    Friend WithEvents LblJsfsdm As System.Windows.Forms.Label
    Friend WithEvents TxtJsfsdm As System.Windows.Forms.TextBox
End Class
