<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPoFpImpRkd
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
        Me.TxtRkdDjh = New System.Windows.Forms.TextBox
        Me.LblRkdDjh = New System.Windows.Forms.Label
        Me.TxtCpmc = New System.Windows.Forms.TextBox
        Me.LblCpmc = New System.Windows.Forms.Label
        Me.TxtCpdm = New System.Windows.Forms.TextBox
        Me.LblCpdm = New System.Windows.Forms.Label
        Me.TxtCgdDjh = New System.Windows.Forms.TextBox
        Me.LblCgdDjh = New System.Windows.Forms.Label
        Me.LblEnd = New System.Windows.Forms.Label
        Me.DtpEnd = New System.Windows.Forms.DateTimePicker
        Me.LblBegin = New System.Windows.Forms.Label
        Me.DtpBegin = New System.Windows.Forms.DateTimePicker
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.TxtSgddh = New System.Windows.Forms.TextBox
        Me.LblSgddh = New System.Windows.Forms.Label
        Me.DlgPanel.SuspendLayout()
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
        Me.DlgPanel.Location = New System.Drawing.Point(221, 188)
        Me.DlgPanel.TabIndex = 15
        '
        'TxtRkdDjh
        '
        Me.TxtRkdDjh.Location = New System.Drawing.Point(142, 86)
        Me.TxtRkdDjh.MaxLength = 15
        Me.TxtRkdDjh.Name = "TxtRkdDjh"
        Me.TxtRkdDjh.Size = New System.Drawing.Size(104, 21)
        Me.TxtRkdDjh.TabIndex = 9
        '
        'LblRkdDjh
        '
        Me.LblRkdDjh.AutoSize = True
        Me.LblRkdDjh.Location = New System.Drawing.Point(34, 90)
        Me.LblRkdDjh.Name = "LblRkdDjh"
        Me.LblRkdDjh.Size = New System.Drawing.Size(89, 12)
        Me.LblRkdDjh.TabIndex = 8
        Me.LblRkdDjh.Text = "收货单单据号："
        '
        'TxtCpmc
        '
        Me.TxtCpmc.Location = New System.Drawing.Point(338, 57)
        Me.TxtCpmc.MaxLength = 100
        Me.TxtCpmc.Name = "TxtCpmc"
        Me.TxtCpmc.Size = New System.Drawing.Size(104, 21)
        Me.TxtCpmc.TabIndex = 7
        '
        'LblCpmc
        '
        Me.LblCpmc.AutoSize = True
        Me.LblCpmc.Location = New System.Drawing.Point(265, 61)
        Me.LblCpmc.Name = "LblCpmc"
        Me.LblCpmc.Size = New System.Drawing.Size(65, 12)
        Me.LblCpmc.TabIndex = 6
        Me.LblCpmc.Text = "物料描述："
        '
        'TxtCpdm
        '
        Me.TxtCpdm.Location = New System.Drawing.Point(107, 57)
        Me.TxtCpdm.MaxLength = 15
        Me.TxtCpdm.Name = "TxtCpdm"
        Me.TxtCpdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtCpdm.TabIndex = 5
        '
        'LblCpdm
        '
        Me.LblCpdm.AutoSize = True
        Me.LblCpdm.Location = New System.Drawing.Point(34, 61)
        Me.LblCpdm.Name = "LblCpdm"
        Me.LblCpdm.Size = New System.Drawing.Size(65, 12)
        Me.LblCpdm.TabIndex = 4
        Me.LblCpdm.Text = "物料编码："
        '
        'TxtCgdDjh
        '
        Me.TxtCgdDjh.Location = New System.Drawing.Point(142, 115)
        Me.TxtCgdDjh.MaxLength = 15
        Me.TxtCgdDjh.Name = "TxtCgdDjh"
        Me.TxtCgdDjh.Size = New System.Drawing.Size(104, 21)
        Me.TxtCgdDjh.TabIndex = 13
        '
        'LblCgdDjh
        '
        Me.LblCgdDjh.AutoSize = True
        Me.LblCgdDjh.Location = New System.Drawing.Point(34, 119)
        Me.LblCgdDjh.Name = "LblCgdDjh"
        Me.LblCgdDjh.Size = New System.Drawing.Size(101, 12)
        Me.LblCgdDjh.TabIndex = 12
        Me.LblCgdDjh.Text = "采购订单单据号："
        '
        'LblEnd
        '
        Me.LblEnd.AutoSize = True
        Me.LblEnd.Location = New System.Drawing.Point(266, 26)
        Me.LblEnd.Name = "LblEnd"
        Me.LblEnd.Size = New System.Drawing.Size(17, 12)
        Me.LblEnd.TabIndex = 2
        Me.LblEnd.Text = "至"
        '
        'DtpEnd
        '
        Me.DtpEnd.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpEnd.Location = New System.Drawing.Point(291, 22)
        Me.DtpEnd.Name = "DtpEnd"
        Me.DtpEnd.Size = New System.Drawing.Size(151, 21)
        Me.DtpEnd.TabIndex = 3
        '
        'LblBegin
        '
        Me.LblBegin.AutoSize = True
        Me.LblBegin.Location = New System.Drawing.Point(34, 26)
        Me.LblBegin.Name = "LblBegin"
        Me.LblBegin.Size = New System.Drawing.Size(65, 12)
        Me.LblBegin.TabIndex = 0
        Me.LblBegin.Text = "日    期："
        '
        'DtpBegin
        '
        Me.DtpBegin.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpBegin.Location = New System.Drawing.Point(107, 22)
        Me.DtpBegin.Name = "DtpBegin"
        Me.DtpBegin.Size = New System.Drawing.Size(151, 21)
        Me.DtpBegin.TabIndex = 1
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CheckBox1.Location = New System.Drawing.Point(142, 153)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(96, 16)
        Me.CheckBox1.TabIndex = 14
        Me.CheckBox1.Text = "清空已选数据"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'TxtSgddh
        '
        Me.TxtSgddh.Location = New System.Drawing.Point(338, 86)
        Me.TxtSgddh.MaxLength = 15
        Me.TxtSgddh.Name = "TxtSgddh"
        Me.TxtSgddh.Size = New System.Drawing.Size(104, 21)
        Me.TxtSgddh.TabIndex = 11
        '
        'LblSgddh
        '
        Me.LblSgddh.AutoSize = True
        Me.LblSgddh.Location = New System.Drawing.Point(265, 90)
        Me.LblSgddh.Name = "LblSgddh"
        Me.LblSgddh.Size = New System.Drawing.Size(77, 12)
        Me.LblSgddh.TabIndex = 10
        Me.LblSgddh.Text = "手工订单号："
        '
        'FrmPoFpImpRkd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(474, 231)
        Me.Controls.Add(Me.TxtSgddh)
        Me.Controls.Add(Me.LblSgddh)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.LblEnd)
        Me.Controls.Add(Me.DtpEnd)
        Me.Controls.Add(Me.LblBegin)
        Me.Controls.Add(Me.DtpBegin)
        Me.Controls.Add(Me.TxtCgdDjh)
        Me.Controls.Add(Me.LblCgdDjh)
        Me.Controls.Add(Me.TxtRkdDjh)
        Me.Controls.Add(Me.LblRkdDjh)
        Me.Controls.Add(Me.TxtCpmc)
        Me.Controls.Add(Me.LblCpmc)
        Me.Controls.Add(Me.TxtCpdm)
        Me.Controls.Add(Me.LblCpdm)
        Me.Name = "FrmPoFpImpRkd"
        Me.Text = "物料入库单读入未入库物料收货单"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.LblCpdm, 0)
        Me.Controls.SetChildIndex(Me.TxtCpdm, 0)
        Me.Controls.SetChildIndex(Me.LblCpmc, 0)
        Me.Controls.SetChildIndex(Me.TxtCpmc, 0)
        Me.Controls.SetChildIndex(Me.LblRkdDjh, 0)
        Me.Controls.SetChildIndex(Me.TxtRkdDjh, 0)
        Me.Controls.SetChildIndex(Me.LblCgdDjh, 0)
        Me.Controls.SetChildIndex(Me.TxtCgdDjh, 0)
        Me.Controls.SetChildIndex(Me.DtpBegin, 0)
        Me.Controls.SetChildIndex(Me.LblBegin, 0)
        Me.Controls.SetChildIndex(Me.DtpEnd, 0)
        Me.Controls.SetChildIndex(Me.LblEnd, 0)
        Me.Controls.SetChildIndex(Me.CheckBox1, 0)
        Me.Controls.SetChildIndex(Me.LblSgddh, 0)
        Me.Controls.SetChildIndex(Me.TxtSgddh, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents TxtRkdDjh As System.Windows.Forms.TextBox
    Public WithEvents LblRkdDjh As System.Windows.Forms.Label
    Public WithEvents TxtCpmc As System.Windows.Forms.TextBox
    Public WithEvents LblCpmc As System.Windows.Forms.Label
    Public WithEvents TxtCpdm As System.Windows.Forms.TextBox
    Public WithEvents LblCpdm As System.Windows.Forms.Label
    Public WithEvents TxtCgdDjh As System.Windows.Forms.TextBox
    Public WithEvents LblCgdDjh As System.Windows.Forms.Label
    Public WithEvents LblEnd As System.Windows.Forms.Label
    Public WithEvents DtpEnd As System.Windows.Forms.DateTimePicker
    Public WithEvents LblBegin As System.Windows.Forms.Label
    Public WithEvents DtpBegin As System.Windows.Forms.DateTimePicker
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Public WithEvents TxtSgddh As System.Windows.Forms.TextBox
    Public WithEvents LblSgddh As System.Windows.Forms.Label
End Class
