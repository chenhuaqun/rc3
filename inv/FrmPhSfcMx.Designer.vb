<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPhSfcMx
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
        Me.TxtCpdm = New System.Windows.Forms.TextBox
        Me.LblCpdm = New System.Windows.Forms.Label
        Me.TxtPiHao = New System.Windows.Forms.TextBox
        Me.LblCkdm = New System.Windows.Forms.Label
        Me.DlgPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(106, 123)
        Me.DlgPanel.TabIndex = 10
        '
        'TxtCpdm
        '
        Me.TxtCpdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCpdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtCpdm.Location = New System.Drawing.Point(150, 27)
        Me.TxtCpdm.MaxLength = 15
        Me.TxtCpdm.Name = "TxtCpdm"
        Me.TxtCpdm.Size = New System.Drawing.Size(112, 26)
        Me.TxtCpdm.TabIndex = 7
        '
        'LblCpdm
        '
        Me.LblCpdm.AutoSize = True
        Me.LblCpdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblCpdm.Location = New System.Drawing.Point(54, 32)
        Me.LblCpdm.Name = "LblCpdm"
        Me.LblCpdm.Size = New System.Drawing.Size(88, 16)
        Me.LblCpdm.TabIndex = 6
        Me.LblCpdm.Text = "物料编码："
        '
        'TxtPiHao
        '
        Me.TxtPiHao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPiHao.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtPiHao.Location = New System.Drawing.Point(150, 62)
        Me.TxtPiHao.MaxLength = 20
        Me.TxtPiHao.Name = "TxtPiHao"
        Me.TxtPiHao.Size = New System.Drawing.Size(112, 26)
        Me.TxtPiHao.TabIndex = 9
        '
        'LblCkdm
        '
        Me.LblCkdm.AutoSize = True
        Me.LblCkdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblCkdm.Location = New System.Drawing.Point(54, 67)
        Me.LblCkdm.Name = "LblCkdm"
        Me.LblCkdm.Size = New System.Drawing.Size(88, 16)
        Me.LblCkdm.TabIndex = 8
        Me.LblCkdm.Text = "批 次 号："
        '
        'FrmPhSfcMx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(359, 166)
        Me.Controls.Add(Me.TxtPiHao)
        Me.Controls.Add(Me.LblCkdm)
        Me.Controls.Add(Me.TxtCpdm)
        Me.Controls.Add(Me.LblCpdm)
        Me.Name = "FrmPhSfcMx"
        Me.Text = "物料批次收发存明细账"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.LblCpdm, 0)
        Me.Controls.SetChildIndex(Me.TxtCpdm, 0)
        Me.Controls.SetChildIndex(Me.LblCkdm, 0)
        Me.Controls.SetChildIndex(Me.TxtPiHao, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents TxtCpdm As System.Windows.Forms.TextBox
    Public WithEvents LblCpdm As System.Windows.Forms.Label
    Public WithEvents TxtPiHao As System.Windows.Forms.TextBox
    Public WithEvents LblCkdm As System.Windows.Forms.Label
End Class
