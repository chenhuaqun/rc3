<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeRkdCx
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
        Me.TxtCpmc = New System.Windows.Forms.TextBox
        Me.LblCpmc = New System.Windows.Forms.Label
        Me.TxtZydm = New System.Windows.Forms.TextBox
        Me.LblZydm = New System.Windows.Forms.Label
        Me.TxtLbdm = New System.Windows.Forms.TextBox
        Me.LblLbdm = New System.Windows.Forms.Label
        Me.ChbLbfs = New System.Windows.Forms.CheckBox
        Me.TxtCpdm = New System.Windows.Forms.TextBox
        Me.LblCpdm = New System.Windows.Forms.Label
        Me.NudDjhEnd = New System.Windows.Forms.NumericUpDown
        Me.LblDjhEnd = New System.Windows.Forms.Label
        Me.NudDjhBegin = New System.Windows.Forms.NumericUpDown
        Me.LblDjhBegin = New System.Windows.Forms.Label
        Me.LblRkrqEnd = New System.Windows.Forms.Label
        Me.DtpRkrqEnd = New System.Windows.Forms.DateTimePicker
        Me.LblRkrqBegin = New System.Windows.Forms.Label
        Me.DtpRkrqBegin = New System.Windows.Forms.DateTimePicker
        Me.CmbPzlxjc = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtCkdm = New System.Windows.Forms.TextBox
        Me.LblCkdm = New System.Windows.Forms.Label
        Me.TxtBmdm = New System.Windows.Forms.TextBox
        Me.LblBmdm = New System.Windows.Forms.Label
        Me.ChbDelete = New System.Windows.Forms.CheckBox
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
        Me.DlgPanel.Location = New System.Drawing.Point(171, 273)
        Me.DlgPanel.TabIndex = 26
        '
        'TxtHth
        '
        Me.TxtHth.Location = New System.Drawing.Point(102, 138)
        Me.TxtHth.MaxLength = 11
        Me.TxtHth.Name = "TxtHth"
        Me.TxtHth.Size = New System.Drawing.Size(104, 21)
        Me.TxtHth.TabIndex = 15
        '
        'LblHth
        '
        Me.LblHth.AutoSize = True
        Me.LblHth.Location = New System.Drawing.Point(31, 142)
        Me.LblHth.Name = "LblHth"
        Me.LblHth.Size = New System.Drawing.Size(65, 12)
        Me.LblHth.TabIndex = 14
        Me.LblHth.Text = "订单编码："
        '
        'TxtCpmc
        '
        Me.TxtCpmc.Location = New System.Drawing.Point(293, 109)
        Me.TxtCpmc.MaxLength = 100
        Me.TxtCpmc.Name = "TxtCpmc"
        Me.TxtCpmc.Size = New System.Drawing.Size(104, 21)
        Me.TxtCpmc.TabIndex = 13
        '
        'LblCpmc
        '
        Me.LblCpmc.AutoSize = True
        Me.LblCpmc.Location = New System.Drawing.Point(221, 113)
        Me.LblCpmc.Name = "LblCpmc"
        Me.LblCpmc.Size = New System.Drawing.Size(65, 12)
        Me.LblCpmc.TabIndex = 12
        Me.LblCpmc.Text = "产品名称："
        '
        'TxtZydm
        '
        Me.TxtZydm.Location = New System.Drawing.Point(293, 167)
        Me.TxtZydm.MaxLength = 12
        Me.TxtZydm.Name = "TxtZydm"
        Me.TxtZydm.Size = New System.Drawing.Size(104, 21)
        Me.TxtZydm.TabIndex = 21
        '
        'LblZydm
        '
        Me.LblZydm.AutoSize = True
        Me.LblZydm.Location = New System.Drawing.Point(222, 171)
        Me.LblZydm.Name = "LblZydm"
        Me.LblZydm.Size = New System.Drawing.Size(65, 12)
        Me.LblZydm.TabIndex = 20
        Me.LblZydm.Text = "经 手 人："
        '
        'TxtLbdm
        '
        Me.TxtLbdm.Location = New System.Drawing.Point(293, 138)
        Me.TxtLbdm.MaxLength = 15
        Me.TxtLbdm.Name = "TxtLbdm"
        Me.TxtLbdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtLbdm.TabIndex = 17
        '
        'LblLbdm
        '
        Me.LblLbdm.AutoSize = True
        Me.LblLbdm.Location = New System.Drawing.Point(222, 142)
        Me.LblLbdm.Name = "LblLbdm"
        Me.LblLbdm.Size = New System.Drawing.Size(65, 12)
        Me.LblLbdm.TabIndex = 16
        Me.LblLbdm.Text = "物料类别："
        '
        'ChbLbfs
        '
        Me.ChbLbfs.AutoSize = True
        Me.ChbLbfs.Checked = True
        Me.ChbLbfs.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChbLbfs.ForeColor = System.Drawing.Color.SteelBlue
        Me.ChbLbfs.Location = New System.Drawing.Point(223, 238)
        Me.ChbLbfs.Name = "ChbLbfs"
        Me.ChbLbfs.Size = New System.Drawing.Size(96, 16)
        Me.ChbLbfs.TabIndex = 25
        Me.ChbLbfs.Text = "列表方式查询"
        '
        'TxtCpdm
        '
        Me.TxtCpdm.Location = New System.Drawing.Point(102, 109)
        Me.TxtCpdm.MaxLength = 15
        Me.TxtCpdm.Name = "TxtCpdm"
        Me.TxtCpdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtCpdm.TabIndex = 11
        '
        'LblCpdm
        '
        Me.LblCpdm.AutoSize = True
        Me.LblCpdm.Location = New System.Drawing.Point(31, 113)
        Me.LblCpdm.Name = "LblCpdm"
        Me.LblCpdm.Size = New System.Drawing.Size(65, 12)
        Me.LblCpdm.TabIndex = 10
        Me.LblCpdm.Text = "产品编码："
        '
        'NudDjhEnd
        '
        Me.NudDjhEnd.Location = New System.Drawing.Point(190, 80)
        Me.NudDjhEnd.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.NudDjhEnd.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudDjhEnd.Name = "NudDjhEnd"
        Me.NudDjhEnd.Size = New System.Drawing.Size(56, 21)
        Me.NudDjhEnd.TabIndex = 9
        Me.NudDjhEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudDjhEnd.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        '
        'LblDjhEnd
        '
        Me.LblDjhEnd.AutoSize = True
        Me.LblDjhEnd.Location = New System.Drawing.Point(166, 80)
        Me.LblDjhEnd.Name = "LblDjhEnd"
        Me.LblDjhEnd.Size = New System.Drawing.Size(17, 12)
        Me.LblDjhEnd.TabIndex = 8
        Me.LblDjhEnd.Text = "至"
        '
        'NudDjhBegin
        '
        Me.NudDjhBegin.Location = New System.Drawing.Point(102, 80)
        Me.NudDjhBegin.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.NudDjhBegin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudDjhBegin.Name = "NudDjhBegin"
        Me.NudDjhBegin.Size = New System.Drawing.Size(56, 21)
        Me.NudDjhBegin.TabIndex = 7
        Me.NudDjhBegin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudDjhBegin.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'LblDjhBegin
        '
        Me.LblDjhBegin.AutoSize = True
        Me.LblDjhBegin.Location = New System.Drawing.Point(31, 82)
        Me.LblDjhBegin.Name = "LblDjhBegin"
        Me.LblDjhBegin.Size = New System.Drawing.Size(65, 12)
        Me.LblDjhBegin.TabIndex = 6
        Me.LblDjhBegin.Text = "单 据 号："
        '
        'LblRkrqEnd
        '
        Me.LblRkrqEnd.AutoSize = True
        Me.LblRkrqEnd.Location = New System.Drawing.Point(222, 27)
        Me.LblRkrqEnd.Name = "LblRkrqEnd"
        Me.LblRkrqEnd.Size = New System.Drawing.Size(17, 12)
        Me.LblRkrqEnd.TabIndex = 2
        Me.LblRkrqEnd.Text = "至"
        '
        'DtpRkrqEnd
        '
        Me.DtpRkrqEnd.Location = New System.Drawing.Point(246, 27)
        Me.DtpRkrqEnd.Name = "DtpRkrqEnd"
        Me.DtpRkrqEnd.Size = New System.Drawing.Size(112, 21)
        Me.DtpRkrqEnd.TabIndex = 3
        '
        'LblRkrqBegin
        '
        Me.LblRkrqBegin.AutoSize = True
        Me.LblRkrqBegin.Location = New System.Drawing.Point(31, 27)
        Me.LblRkrqBegin.Name = "LblRkrqBegin"
        Me.LblRkrqBegin.Size = New System.Drawing.Size(65, 12)
        Me.LblRkrqBegin.TabIndex = 0
        Me.LblRkrqBegin.Text = "日    期："
        '
        'DtpRkrqBegin
        '
        Me.DtpRkrqBegin.Location = New System.Drawing.Point(102, 27)
        Me.DtpRkrqBegin.Name = "DtpRkrqBegin"
        Me.DtpRkrqBegin.Size = New System.Drawing.Size(112, 21)
        Me.DtpRkrqBegin.TabIndex = 1
        '
        'CmbPzlxjc
        '
        Me.CmbPzlxjc.Location = New System.Drawing.Point(102, 54)
        Me.CmbPzlxjc.Name = "CmbPzlxjc"
        Me.CmbPzlxjc.Size = New System.Drawing.Size(72, 20)
        Me.CmbPzlxjc.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "单据类型："
        '
        'TxtCkdm
        '
        Me.TxtCkdm.Location = New System.Drawing.Point(102, 196)
        Me.TxtCkdm.MaxLength = 30
        Me.TxtCkdm.Name = "TxtCkdm"
        Me.TxtCkdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtCkdm.TabIndex = 23
        '
        'LblCkdm
        '
        Me.LblCkdm.AutoSize = True
        Me.LblCkdm.Location = New System.Drawing.Point(30, 200)
        Me.LblCkdm.Name = "LblCkdm"
        Me.LblCkdm.Size = New System.Drawing.Size(65, 12)
        Me.LblCkdm.TabIndex = 22
        Me.LblCkdm.Text = "仓库编码："
        '
        'TxtBmdm
        '
        Me.TxtBmdm.Location = New System.Drawing.Point(102, 167)
        Me.TxtBmdm.MaxLength = 12
        Me.TxtBmdm.Name = "TxtBmdm"
        Me.TxtBmdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtBmdm.TabIndex = 19
        '
        'LblBmdm
        '
        Me.LblBmdm.AutoSize = True
        Me.LblBmdm.Location = New System.Drawing.Point(31, 171)
        Me.LblBmdm.Name = "LblBmdm"
        Me.LblBmdm.Size = New System.Drawing.Size(65, 12)
        Me.LblBmdm.TabIndex = 18
        Me.LblBmdm.Text = "部门编码："
        '
        'ChbDelete
        '
        Me.ChbDelete.AutoSize = True
        Me.ChbDelete.ForeColor = System.Drawing.Color.SteelBlue
        Me.ChbDelete.Location = New System.Drawing.Point(102, 238)
        Me.ChbDelete.Name = "ChbDelete"
        Me.ChbDelete.Size = New System.Drawing.Size(96, 16)
        Me.ChbDelete.TabIndex = 24
        Me.ChbDelete.Text = "包含作废单据"
        '
        'FrmOeRkdCx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 316)
        Me.Controls.Add(Me.ChbDelete)
        Me.Controls.Add(Me.TxtCkdm)
        Me.Controls.Add(Me.LblCkdm)
        Me.Controls.Add(Me.TxtBmdm)
        Me.Controls.Add(Me.LblBmdm)
        Me.Controls.Add(Me.CmbPzlxjc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtHth)
        Me.Controls.Add(Me.LblHth)
        Me.Controls.Add(Me.TxtCpmc)
        Me.Controls.Add(Me.LblCpmc)
        Me.Controls.Add(Me.TxtZydm)
        Me.Controls.Add(Me.LblZydm)
        Me.Controls.Add(Me.TxtLbdm)
        Me.Controls.Add(Me.LblLbdm)
        Me.Controls.Add(Me.ChbLbfs)
        Me.Controls.Add(Me.TxtCpdm)
        Me.Controls.Add(Me.LblCpdm)
        Me.Controls.Add(Me.NudDjhEnd)
        Me.Controls.Add(Me.LblDjhEnd)
        Me.Controls.Add(Me.NudDjhBegin)
        Me.Controls.Add(Me.LblDjhBegin)
        Me.Controls.Add(Me.LblRkrqEnd)
        Me.Controls.Add(Me.DtpRkrqEnd)
        Me.Controls.Add(Me.LblRkrqBegin)
        Me.Controls.Add(Me.DtpRkrqBegin)
        Me.Name = "FrmOeRkdCx"
        Me.Text = "产品入库单查询范围"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.DtpRkrqBegin, 0)
        Me.Controls.SetChildIndex(Me.LblRkrqBegin, 0)
        Me.Controls.SetChildIndex(Me.DtpRkrqEnd, 0)
        Me.Controls.SetChildIndex(Me.LblRkrqEnd, 0)
        Me.Controls.SetChildIndex(Me.LblDjhBegin, 0)
        Me.Controls.SetChildIndex(Me.NudDjhBegin, 0)
        Me.Controls.SetChildIndex(Me.LblDjhEnd, 0)
        Me.Controls.SetChildIndex(Me.NudDjhEnd, 0)
        Me.Controls.SetChildIndex(Me.LblCpdm, 0)
        Me.Controls.SetChildIndex(Me.TxtCpdm, 0)
        Me.Controls.SetChildIndex(Me.ChbLbfs, 0)
        Me.Controls.SetChildIndex(Me.LblLbdm, 0)
        Me.Controls.SetChildIndex(Me.TxtLbdm, 0)
        Me.Controls.SetChildIndex(Me.LblZydm, 0)
        Me.Controls.SetChildIndex(Me.TxtZydm, 0)
        Me.Controls.SetChildIndex(Me.LblCpmc, 0)
        Me.Controls.SetChildIndex(Me.TxtCpmc, 0)
        Me.Controls.SetChildIndex(Me.LblHth, 0)
        Me.Controls.SetChildIndex(Me.TxtHth, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.CmbPzlxjc, 0)
        Me.Controls.SetChildIndex(Me.LblBmdm, 0)
        Me.Controls.SetChildIndex(Me.TxtBmdm, 0)
        Me.Controls.SetChildIndex(Me.LblCkdm, 0)
        Me.Controls.SetChildIndex(Me.TxtCkdm, 0)
        Me.Controls.SetChildIndex(Me.ChbDelete, 0)
        Me.DlgPanel.ResumeLayout(False)
        CType(Me.NudDjhEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudDjhBegin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents TxtHth As System.Windows.Forms.TextBox
    Public WithEvents LblHth As System.Windows.Forms.Label
    Public WithEvents TxtCpmc As System.Windows.Forms.TextBox
    Public WithEvents LblCpmc As System.Windows.Forms.Label
    Public WithEvents TxtZydm As System.Windows.Forms.TextBox
    Public WithEvents LblZydm As System.Windows.Forms.Label
    Public WithEvents TxtLbdm As System.Windows.Forms.TextBox
    Public WithEvents LblLbdm As System.Windows.Forms.Label
    Friend WithEvents ChbLbfs As System.Windows.Forms.CheckBox
    Public WithEvents TxtCpdm As System.Windows.Forms.TextBox
    Public WithEvents LblCpdm As System.Windows.Forms.Label
    Public WithEvents NudDjhEnd As System.Windows.Forms.NumericUpDown
    Public WithEvents LblDjhEnd As System.Windows.Forms.Label
    Public WithEvents NudDjhBegin As System.Windows.Forms.NumericUpDown
    Public WithEvents LblDjhBegin As System.Windows.Forms.Label
    Public WithEvents LblRkrqEnd As System.Windows.Forms.Label
    Public WithEvents DtpRkrqEnd As System.Windows.Forms.DateTimePicker
    Public WithEvents LblRkrqBegin As System.Windows.Forms.Label
    Public WithEvents DtpRkrqBegin As System.Windows.Forms.DateTimePicker
    Friend WithEvents CmbPzlxjc As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents TxtCkdm As System.Windows.Forms.TextBox
    Public WithEvents LblCkdm As System.Windows.Forms.Label
    Public WithEvents TxtBmdm As System.Windows.Forms.TextBox
    Public WithEvents LblBmdm As System.Windows.Forms.Label
    Friend WithEvents ChbDelete As System.Windows.Forms.CheckBox
End Class
