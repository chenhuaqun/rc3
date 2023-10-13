<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmQccsyeSr
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
        Me.TxtCsdm = New System.Windows.Forms.TextBox
        Me.LblKhdm = New System.Windows.Forms.Label
        Me.LblCsmc = New System.Windows.Forms.Label
        Me.TxtXh = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblXsrq = New System.Windows.Forms.Label
        Me.DtpRkrq = New System.Windows.Forms.DateTimePicker
        Me.TxtJe = New System.Windows.Forms.TextBox
        Me.LblJe = New System.Windows.Forms.Label
        Me.LblXsmemo = New System.Windows.Forms.Label
        Me.TxtRkmemo = New System.Windows.Forms.TextBox
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
        'TxtCsdm
        '
        Me.TxtCsdm.Location = New System.Drawing.Point(123, 12)
        Me.TxtCsdm.MaxLength = 12
        Me.TxtCsdm.Name = "TxtCsdm"
        Me.TxtCsdm.Size = New System.Drawing.Size(87, 21)
        Me.TxtCsdm.TabIndex = 9
        '
        'LblKhdm
        '
        Me.LblKhdm.AutoSize = True
        Me.LblKhdm.Location = New System.Drawing.Point(51, 15)
        Me.LblKhdm.Name = "LblKhdm"
        Me.LblKhdm.Size = New System.Drawing.Size(77, 12)
        Me.LblKhdm.TabIndex = 8
        Me.LblKhdm.Text = "供应商编码："
        '
        'LblCsmc
        '
        Me.LblCsmc.AutoSize = True
        Me.LblCsmc.Location = New System.Drawing.Point(223, 16)
        Me.LblCsmc.Name = "LblCsmc"
        Me.LblCsmc.Size = New System.Drawing.Size(0, 12)
        Me.LblCsmc.TabIndex = 10
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
        Me.LblXsrq.Text = "购买日期："
        '
        'DtpRkrq
        '
        Me.DtpRkrq.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpRkrq.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpRkrq.Location = New System.Drawing.Point(123, 66)
        Me.DtpRkrq.Name = "DtpRkrq"
        Me.DtpRkrq.Size = New System.Drawing.Size(151, 21)
        Me.DtpRkrq.TabIndex = 14
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
        Me.LblJe.Text = "应付金额："
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
        'TxtRkmemo
        '
        Me.TxtRkmemo.Location = New System.Drawing.Point(123, 120)
        Me.TxtRkmemo.MaxLength = 50
        Me.TxtRkmemo.Name = "TxtRkmemo"
        Me.TxtRkmemo.Size = New System.Drawing.Size(208, 21)
        Me.TxtRkmemo.TabIndex = 18
        '
        'FrmQccsyeSr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(387, 207)
        Me.Controls.Add(Me.LblXsmemo)
        Me.Controls.Add(Me.TxtRkmemo)
        Me.Controls.Add(Me.TxtJe)
        Me.Controls.Add(Me.LblJe)
        Me.Controls.Add(Me.DtpRkrq)
        Me.Controls.Add(Me.LblXsrq)
        Me.Controls.Add(Me.TxtXh)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtCsdm)
        Me.Controls.Add(Me.LblKhdm)
        Me.Controls.Add(Me.LblCsmc)
        Me.Name = "FrmQccsyeSr"
        Me.Text = "期初供应商应付明细装入"
        Me.Controls.SetChildIndex(Me.LblCsmc, 0)
        Me.Controls.SetChildIndex(Me.LblKhdm, 0)
        Me.Controls.SetChildIndex(Me.TxtCsdm, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.TxtXh, 0)
        Me.Controls.SetChildIndex(Me.LblXsrq, 0)
        Me.Controls.SetChildIndex(Me.DtpRkrq, 0)
        Me.Controls.SetChildIndex(Me.LblJe, 0)
        Me.Controls.SetChildIndex(Me.TxtJe, 0)
        Me.Controls.SetChildIndex(Me.TxtRkmemo, 0)
        Me.Controls.SetChildIndex(Me.LblXsmemo, 0)
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents TxtCsdm As System.Windows.Forms.TextBox
    Public WithEvents LblKhdm As System.Windows.Forms.Label
    Public WithEvents LblCsmc As System.Windows.Forms.Label
    Public WithEvents TxtXh As System.Windows.Forms.TextBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents LblXsrq As System.Windows.Forms.Label
    Public WithEvents DtpRkrq As System.Windows.Forms.DateTimePicker
    Public WithEvents TxtJe As System.Windows.Forms.TextBox
    Public WithEvents LblJe As System.Windows.Forms.Label
    Public WithEvents LblXsmemo As System.Windows.Forms.Label
    Public WithEvents TxtRkmemo As System.Windows.Forms.TextBox
End Class
