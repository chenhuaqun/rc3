<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmQckhyeSr
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
        Me.LblKhmc = New System.Windows.Forms.Label
        Me.TxtXh = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblXsrq = New System.Windows.Forms.Label
        Me.DtpXsrq = New System.Windows.Forms.DateTimePicker
        Me.TxtJe = New System.Windows.Forms.TextBox
        Me.LblJe = New System.Windows.Forms.Label
        Me.LblXsmemo = New System.Windows.Forms.Label
        Me.TxtXsmemo = New System.Windows.Forms.TextBox
        Me.DlgPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(134, 164)
        '
        'TxtKhdm
        '
        Me.TxtKhdm.Location = New System.Drawing.Point(123, 12)
        Me.TxtKhdm.MaxLength = 12
        Me.TxtKhdm.Name = "TxtKhdm"
        Me.TxtKhdm.Size = New System.Drawing.Size(87, 21)
        Me.TxtKhdm.TabIndex = 9
        '
        'LblKhdm
        '
        Me.LblKhdm.AutoSize = True
        Me.LblKhdm.Location = New System.Drawing.Point(51, 15)
        Me.LblKhdm.Name = "LblKhdm"
        Me.LblKhdm.Size = New System.Drawing.Size(65, 12)
        Me.LblKhdm.TabIndex = 8
        Me.LblKhdm.Text = "客户编码："
        '
        'LblKhmc
        '
        Me.LblKhmc.AutoSize = True
        Me.LblKhmc.Location = New System.Drawing.Point(223, 16)
        Me.LblKhmc.Name = "LblKhmc"
        Me.LblKhmc.Size = New System.Drawing.Size(0, 12)
        Me.LblKhmc.TabIndex = 10
        '
        'TxtXh
        '
        Me.TxtXh.Location = New System.Drawing.Point(123, 39)
        Me.TxtXh.MaxLength = 12
        Me.TxtXh.Name = "TxtXh"
        Me.TxtXh.Size = New System.Drawing.Size(96, 21)
        Me.TxtXh.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(51, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "序    号："
        '
        'LblXsrq
        '
        Me.LblXsrq.AutoSize = True
        Me.LblXsrq.Location = New System.Drawing.Point(51, 72)
        Me.LblXsrq.Name = "LblXsrq"
        Me.LblXsrq.Size = New System.Drawing.Size(65, 12)
        Me.LblXsrq.TabIndex = 13
        Me.LblXsrq.Text = "销售日期："
        '
        'DtpXsrq
        '
        Me.DtpXsrq.Location = New System.Drawing.Point(123, 66)
        Me.DtpXsrq.Name = "DtpXsrq"
        Me.DtpXsrq.Size = New System.Drawing.Size(112, 21)
        Me.DtpXsrq.TabIndex = 14
        '
        'TxtJe
        '
        Me.TxtJe.Location = New System.Drawing.Point(123, 93)
        Me.TxtJe.MaxLength = 14
        Me.TxtJe.Name = "TxtJe"
        Me.TxtJe.Size = New System.Drawing.Size(96, 21)
        Me.TxtJe.TabIndex = 16
        Me.TxtJe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblJe
        '
        Me.LblJe.AutoSize = True
        Me.LblJe.Location = New System.Drawing.Point(51, 96)
        Me.LblJe.Name = "LblJe"
        Me.LblJe.Size = New System.Drawing.Size(65, 12)
        Me.LblJe.TabIndex = 15
        Me.LblJe.Text = "应收金额："
        '
        'LblXsmemo
        '
        Me.LblXsmemo.AutoSize = True
        Me.LblXsmemo.Location = New System.Drawing.Point(51, 123)
        Me.LblXsmemo.Name = "LblXsmemo"
        Me.LblXsmemo.Size = New System.Drawing.Size(65, 12)
        Me.LblXsmemo.TabIndex = 17
        Me.LblXsmemo.Text = "备    注："
        '
        'TxtXsmemo
        '
        Me.TxtXsmemo.Location = New System.Drawing.Point(123, 120)
        Me.TxtXsmemo.MaxLength = 50
        Me.TxtXsmemo.Name = "TxtXsmemo"
        Me.TxtXsmemo.Size = New System.Drawing.Size(208, 21)
        Me.TxtXsmemo.TabIndex = 18
        '
        'FrmQckhyeSr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(387, 207)
        Me.Controls.Add(Me.LblXsmemo)
        Me.Controls.Add(Me.TxtXsmemo)
        Me.Controls.Add(Me.TxtJe)
        Me.Controls.Add(Me.LblJe)
        Me.Controls.Add(Me.DtpXsrq)
        Me.Controls.Add(Me.LblXsrq)
        Me.Controls.Add(Me.TxtXh)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtKhdm)
        Me.Controls.Add(Me.LblKhdm)
        Me.Controls.Add(Me.LblKhmc)
        Me.Name = "FrmQckhyeSr"
        Me.Text = "期初客户应收明细装入"
        Me.Controls.SetChildIndex(Me.LblKhmc, 0)
        Me.Controls.SetChildIndex(Me.LblKhdm, 0)
        Me.Controls.SetChildIndex(Me.TxtKhdm, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.TxtXh, 0)
        Me.Controls.SetChildIndex(Me.LblXsrq, 0)
        Me.Controls.SetChildIndex(Me.DtpXsrq, 0)
        Me.Controls.SetChildIndex(Me.LblJe, 0)
        Me.Controls.SetChildIndex(Me.TxtJe, 0)
        Me.Controls.SetChildIndex(Me.TxtXsmemo, 0)
        Me.Controls.SetChildIndex(Me.LblXsmemo, 0)
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents TxtKhdm As System.Windows.Forms.TextBox
    Public WithEvents LblKhdm As System.Windows.Forms.Label
    Public WithEvents LblKhmc As System.Windows.Forms.Label
    Public WithEvents TxtXh As System.Windows.Forms.TextBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents LblXsrq As System.Windows.Forms.Label
    Public WithEvents DtpXsrq As System.Windows.Forms.DateTimePicker
    Public WithEvents TxtJe As System.Windows.Forms.TextBox
    Public WithEvents LblJe As System.Windows.Forms.Label
    Public WithEvents LblXsmemo As System.Windows.Forms.Label
    Public WithEvents TxtXsmemo As System.Windows.Forms.TextBox
End Class
