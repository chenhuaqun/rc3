<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeZyHzb
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
        Me.LblhzrqEnd = New System.Windows.Forms.Label
        Me.DtpHzrqEnd = New System.Windows.Forms.DateTimePicker
        Me.LblhzrqBegin = New System.Windows.Forms.Label
        Me.DtpHzrqBegin = New System.Windows.Forms.DateTimePicker
        Me.DlgPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(354, 86)
        '
        'LblhzrqEnd
        '
        Me.LblhzrqEnd.AutoSize = True
        Me.LblhzrqEnd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblhzrqEnd.Location = New System.Drawing.Point(337, 33)
        Me.LblhzrqEnd.Name = "LblhzrqEnd"
        Me.LblhzrqEnd.Size = New System.Drawing.Size(40, 16)
        Me.LblhzrqEnd.TabIndex = 104
        Me.LblhzrqEnd.Text = "至："
        '
        'DtpHzrqEnd
        '
        Me.DtpHzrqEnd.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpHzrqEnd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.DtpHzrqEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpHzrqEnd.Location = New System.Drawing.Point(385, 28)
        Me.DtpHzrqEnd.Name = "DtpHzrqEnd"
        Me.DtpHzrqEnd.Size = New System.Drawing.Size(186, 26)
        Me.DtpHzrqEnd.TabIndex = 105
        '
        'LblhzrqBegin
        '
        Me.LblhzrqBegin.AutoSize = True
        Me.LblhzrqBegin.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblhzrqBegin.Location = New System.Drawing.Point(31, 33)
        Me.LblhzrqBegin.Name = "LblhzrqBegin"
        Me.LblhzrqBegin.Size = New System.Drawing.Size(104, 16)
        Me.LblhzrqBegin.TabIndex = 102
        Me.LblhzrqBegin.Text = "汇总日期从："
        '
        'DtpHzrqBegin
        '
        Me.DtpHzrqBegin.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpHzrqBegin.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.DtpHzrqBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpHzrqBegin.Location = New System.Drawing.Point(143, 28)
        Me.DtpHzrqBegin.Name = "DtpHzrqBegin"
        Me.DtpHzrqBegin.Size = New System.Drawing.Size(186, 26)
        Me.DtpHzrqBegin.TabIndex = 103
        '
        'FrmOeZyHzb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(607, 129)
        Me.Controls.Add(Me.LblhzrqEnd)
        Me.Controls.Add(Me.DtpHzrqEnd)
        Me.Controls.Add(Me.LblhzrqBegin)
        Me.Controls.Add(Me.DtpHzrqBegin)
        Me.Name = "FrmOeZyHzb"
        Me.Text = "职员销售汇总表"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.DtpHzrqBegin, 0)
        Me.Controls.SetChildIndex(Me.LblhzrqBegin, 0)
        Me.Controls.SetChildIndex(Me.DtpHzrqEnd, 0)
        Me.Controls.SetChildIndex(Me.LblhzrqEnd, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents LblhzrqEnd As System.Windows.Forms.Label
    Public WithEvents DtpHzrqEnd As System.Windows.Forms.DateTimePicker
    Public WithEvents LblhzrqBegin As System.Windows.Forms.Label
    Public WithEvents DtpHzrqBegin As System.Windows.Forms.DateTimePicker
End Class
