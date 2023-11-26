<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeYpddXdb
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
        Me.DlgPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(157, 105)
        '
        'LblQdrqEnd
        '
        Me.LblQdrqEnd.AutoSize = True
        Me.LblQdrqEnd.Location = New System.Drawing.Point(232, 42)
        Me.LblQdrqEnd.Name = "LblQdrqEnd"
        Me.LblQdrqEnd.Size = New System.Drawing.Size(17, 12)
        Me.LblQdrqEnd.TabIndex = 104
        Me.LblQdrqEnd.Text = "至"
        '
        'DtpQdrqEnd
        '
        Me.DtpQdrqEnd.Location = New System.Drawing.Point(256, 42)
        Me.DtpQdrqEnd.Name = "DtpQdrqEnd"
        Me.DtpQdrqEnd.Size = New System.Drawing.Size(112, 21)
        Me.DtpQdrqEnd.TabIndex = 105
        '
        'LblQdrqBegin
        '
        Me.LblQdrqBegin.AutoSize = True
        Me.LblQdrqBegin.Location = New System.Drawing.Point(40, 42)
        Me.LblQdrqBegin.Name = "LblQdrqBegin"
        Me.LblQdrqBegin.Size = New System.Drawing.Size(65, 12)
        Me.LblQdrqBegin.TabIndex = 102
        Me.LblQdrqBegin.Text = "签单日期："
        '
        'DtpQdrqBegin
        '
        Me.DtpQdrqBegin.Location = New System.Drawing.Point(112, 42)
        Me.DtpQdrqBegin.Name = "DtpQdrqBegin"
        Me.DtpQdrqBegin.Size = New System.Drawing.Size(112, 21)
        Me.DtpQdrqBegin.TabIndex = 103
        '
        'FrmOeYpddXdb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(410, 148)
        Me.Controls.Add(Me.LblQdrqEnd)
        Me.Controls.Add(Me.DtpQdrqEnd)
        Me.Controls.Add(Me.LblQdrqBegin)
        Me.Controls.Add(Me.DtpQdrqBegin)
        Me.Name = "FrmOeYpddXdb"
        Me.Text = "样品订单下达表"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.DtpQdrqBegin, 0)
        Me.Controls.SetChildIndex(Me.LblQdrqBegin, 0)
        Me.Controls.SetChildIndex(Me.DtpQdrqEnd, 0)
        Me.Controls.SetChildIndex(Me.LblQdrqEnd, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents LblQdrqEnd As System.Windows.Forms.Label
    Public WithEvents DtpQdrqEnd As System.Windows.Forms.DateTimePicker
    Public WithEvents LblQdrqBegin As System.Windows.Forms.Label
    Public WithEvents DtpQdrqBegin As System.Windows.Forms.DateTimePicker
End Class
