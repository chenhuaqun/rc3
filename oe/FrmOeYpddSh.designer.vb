<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeYpddSh
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
        Me.LblQdrqEnd = New System.Windows.Forms.Label
        Me.DtpQdrqEnd = New System.Windows.Forms.DateTimePicker
        Me.LblQdrqBegin = New System.Windows.Forms.Label
        Me.DtpQdrqBegin = New System.Windows.Forms.DateTimePicker
        Me.ChbSh = New System.Windows.Forms.CheckBox
        Me.LblDjhEnd = New System.Windows.Forms.Label
        Me.NudDjhEnd = New System.Windows.Forms.NumericUpDown
        Me.NudDjhBegin = New System.Windows.Forms.NumericUpDown
        Me.LblDjhBegin = New System.Windows.Forms.Label
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
        Me.DlgPanel.Location = New System.Drawing.Point(254, 164)
        '
        'LblQdrqEnd
        '
        Me.LblQdrqEnd.AutoSize = True
        Me.LblQdrqEnd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblQdrqEnd.Location = New System.Drawing.Point(288, 29)
        Me.LblQdrqEnd.Name = "LblQdrqEnd"
        Me.LblQdrqEnd.Size = New System.Drawing.Size(24, 16)
        Me.LblQdrqEnd.TabIndex = 109
        Me.LblQdrqEnd.Text = "至"
        '
        'DtpQdrqEnd
        '
        Me.DtpQdrqEnd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.DtpQdrqEnd.Location = New System.Drawing.Point(320, 24)
        Me.DtpQdrqEnd.Name = "DtpQdrqEnd"
        Me.DtpQdrqEnd.Size = New System.Drawing.Size(139, 26)
        Me.DtpQdrqEnd.TabIndex = 110
        '
        'LblQdrqBegin
        '
        Me.LblQdrqBegin.AutoSize = True
        Me.LblQdrqBegin.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblQdrqBegin.Location = New System.Drawing.Point(45, 29)
        Me.LblQdrqBegin.Name = "LblQdrqBegin"
        Me.LblQdrqBegin.Size = New System.Drawing.Size(88, 16)
        Me.LblQdrqBegin.TabIndex = 107
        Me.LblQdrqBegin.Text = "签单日期："
        '
        'DtpQdrqBegin
        '
        Me.DtpQdrqBegin.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.DtpQdrqBegin.Location = New System.Drawing.Point(141, 24)
        Me.DtpQdrqBegin.Name = "DtpQdrqBegin"
        Me.DtpQdrqBegin.Size = New System.Drawing.Size(139, 26)
        Me.DtpQdrqBegin.TabIndex = 108
        '
        'ChbSh
        '
        Me.ChbSh.AutoSize = True
        Me.ChbSh.Checked = True
        Me.ChbSh.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChbSh.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ChbSh.ForeColor = System.Drawing.Color.Teal
        Me.ChbSh.Location = New System.Drawing.Point(133, 112)
        Me.ChbSh.Name = "ChbSh"
        Me.ChbSh.Size = New System.Drawing.Size(155, 20)
        Me.ChbSh.TabIndex = 106
        Me.ChbSh.Text = "未审核的样品订单"
        '
        'LblDjhEnd
        '
        Me.LblDjhEnd.AutoSize = True
        Me.LblDjhEnd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblDjhEnd.Location = New System.Drawing.Point(216, 70)
        Me.LblDjhEnd.Name = "LblDjhEnd"
        Me.LblDjhEnd.Size = New System.Drawing.Size(24, 16)
        Me.LblDjhEnd.TabIndex = 105
        Me.LblDjhEnd.Text = "至"
        '
        'NudDjhEnd
        '
        Me.NudDjhEnd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NudDjhEnd.Location = New System.Drawing.Point(248, 65)
        Me.NudDjhEnd.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.NudDjhEnd.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudDjhEnd.Name = "NudDjhEnd"
        Me.NudDjhEnd.Size = New System.Drawing.Size(67, 26)
        Me.NudDjhEnd.TabIndex = 104
        Me.NudDjhEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudDjhEnd.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        '
        'NudDjhBegin
        '
        Me.NudDjhBegin.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NudDjhBegin.Location = New System.Drawing.Point(141, 65)
        Me.NudDjhBegin.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.NudDjhBegin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudDjhBegin.Name = "NudDjhBegin"
        Me.NudDjhBegin.Size = New System.Drawing.Size(67, 26)
        Me.NudDjhBegin.TabIndex = 103
        Me.NudDjhBegin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudDjhBegin.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'LblDjhBegin
        '
        Me.LblDjhBegin.AutoSize = True
        Me.LblDjhBegin.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblDjhBegin.Location = New System.Drawing.Point(45, 70)
        Me.LblDjhBegin.Name = "LblDjhBegin"
        Me.LblDjhBegin.Size = New System.Drawing.Size(88, 16)
        Me.LblDjhBegin.TabIndex = 102
        Me.LblDjhBegin.Text = "单 据 号："
        '
        'FrmOeYpddSh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(505, 205)
        Me.Controls.Add(Me.LblQdrqEnd)
        Me.Controls.Add(Me.DtpQdrqEnd)
        Me.Controls.Add(Me.LblQdrqBegin)
        Me.Controls.Add(Me.DtpQdrqBegin)
        Me.Controls.Add(Me.ChbSh)
        Me.Controls.Add(Me.LblDjhEnd)
        Me.Controls.Add(Me.NudDjhEnd)
        Me.Controls.Add(Me.NudDjhBegin)
        Me.Controls.Add(Me.LblDjhBegin)
        Me.Name = "FrmOeYpddSh"
        Me.Text = "样品订单审核"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.LblDjhBegin, 0)
        Me.Controls.SetChildIndex(Me.NudDjhBegin, 0)
        Me.Controls.SetChildIndex(Me.NudDjhEnd, 0)
        Me.Controls.SetChildIndex(Me.LblDjhEnd, 0)
        Me.Controls.SetChildIndex(Me.ChbSh, 0)
        Me.Controls.SetChildIndex(Me.DtpQdrqBegin, 0)
        Me.Controls.SetChildIndex(Me.LblQdrqBegin, 0)
        Me.Controls.SetChildIndex(Me.DtpQdrqEnd, 0)
        Me.Controls.SetChildIndex(Me.LblQdrqEnd, 0)
        Me.DlgPanel.ResumeLayout(False)
        CType(Me.NudDjhEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudDjhBegin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents LblQdrqEnd As System.Windows.Forms.Label
    Public WithEvents DtpQdrqEnd As System.Windows.Forms.DateTimePicker
    Public WithEvents LblQdrqBegin As System.Windows.Forms.Label
    Public WithEvents DtpQdrqBegin As System.Windows.Forms.DateTimePicker
    Friend WithEvents ChbSh As System.Windows.Forms.CheckBox
    Friend WithEvents LblDjhEnd As System.Windows.Forms.Label
    Friend WithEvents NudDjhEnd As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudDjhBegin As System.Windows.Forms.NumericUpDown
    Friend WithEvents LblDjhBegin As System.Windows.Forms.Label
End Class
