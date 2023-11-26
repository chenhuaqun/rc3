<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPoRkdImpCgd
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
        Me.TxtDjh = New System.Windows.Forms.TextBox
        Me.LblDjh = New System.Windows.Forms.Label
        Me.TxtCpmc = New System.Windows.Forms.TextBox
        Me.LblCpmc = New System.Windows.Forms.Label
        Me.TxtCpdm = New System.Windows.Forms.TextBox
        Me.LblCpdm = New System.Windows.Forms.Label
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
        Me.DlgPanel.Location = New System.Drawing.Point(191, 98)
        Me.DlgPanel.TabIndex = 8
        '
        'TxtDjh
        '
        Me.TxtDjh.Location = New System.Drawing.Point(106, 52)
        Me.TxtDjh.MaxLength = 15
        Me.TxtDjh.Name = "TxtDjh"
        Me.TxtDjh.Size = New System.Drawing.Size(104, 21)
        Me.TxtDjh.TabIndex = 5
        '
        'LblDjh
        '
        Me.LblDjh.AutoSize = True
        Me.LblDjh.Location = New System.Drawing.Point(33, 56)
        Me.LblDjh.Name = "LblDjh"
        Me.LblDjh.Size = New System.Drawing.Size(65, 12)
        Me.LblDjh.TabIndex = 4
        Me.LblDjh.Text = "单 据 号："
        '
        'TxtCpmc
        '
        Me.TxtCpmc.Location = New System.Drawing.Point(307, 23)
        Me.TxtCpmc.MaxLength = 100
        Me.TxtCpmc.Name = "TxtCpmc"
        Me.TxtCpmc.Size = New System.Drawing.Size(104, 21)
        Me.TxtCpmc.TabIndex = 3
        '
        'LblCpmc
        '
        Me.LblCpmc.AutoSize = True
        Me.LblCpmc.Location = New System.Drawing.Point(234, 27)
        Me.LblCpmc.Name = "LblCpmc"
        Me.LblCpmc.Size = New System.Drawing.Size(65, 12)
        Me.LblCpmc.TabIndex = 2
        Me.LblCpmc.Text = "物料描述："
        '
        'TxtCpdm
        '
        Me.TxtCpdm.Location = New System.Drawing.Point(106, 23)
        Me.TxtCpdm.MaxLength = 15
        Me.TxtCpdm.Name = "TxtCpdm"
        Me.TxtCpdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtCpdm.TabIndex = 1
        '
        'LblCpdm
        '
        Me.LblCpdm.AutoSize = True
        Me.LblCpdm.Location = New System.Drawing.Point(33, 27)
        Me.LblCpdm.Name = "LblCpdm"
        Me.LblCpdm.Size = New System.Drawing.Size(65, 12)
        Me.LblCpdm.TabIndex = 0
        Me.LblCpdm.Text = "物料编码："
        '
        'TxtSgddh
        '
        Me.TxtSgddh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSgddh.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSgddh.Location = New System.Drawing.Point(307, 52)
        Me.TxtSgddh.MaxLength = 20
        Me.TxtSgddh.Name = "TxtSgddh"
        Me.TxtSgddh.Size = New System.Drawing.Size(104, 21)
        Me.TxtSgddh.TabIndex = 7
        '
        'LblSgddh
        '
        Me.LblSgddh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSgddh.AutoSize = True
        Me.LblSgddh.Location = New System.Drawing.Point(222, 56)
        Me.LblSgddh.Name = "LblSgddh"
        Me.LblSgddh.Size = New System.Drawing.Size(77, 12)
        Me.LblSgddh.TabIndex = 6
        Me.LblSgddh.Text = "手工订单号："
        '
        'FrmPoRkdImpCgd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(444, 141)
        Me.Controls.Add(Me.TxtSgddh)
        Me.Controls.Add(Me.LblSgddh)
        Me.Controls.Add(Me.TxtDjh)
        Me.Controls.Add(Me.LblDjh)
        Me.Controls.Add(Me.TxtCpmc)
        Me.Controls.Add(Me.LblCpmc)
        Me.Controls.Add(Me.TxtCpdm)
        Me.Controls.Add(Me.LblCpdm)
        Me.Name = "FrmPoRkdImpCgd"
        Me.Text = "物料收货单读入物料采购订单"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.LblCpdm, 0)
        Me.Controls.SetChildIndex(Me.TxtCpdm, 0)
        Me.Controls.SetChildIndex(Me.LblCpmc, 0)
        Me.Controls.SetChildIndex(Me.TxtCpmc, 0)
        Me.Controls.SetChildIndex(Me.LblDjh, 0)
        Me.Controls.SetChildIndex(Me.TxtDjh, 0)
        Me.Controls.SetChildIndex(Me.LblSgddh, 0)
        Me.Controls.SetChildIndex(Me.TxtSgddh, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents TxtDjh As System.Windows.Forms.TextBox
    Public WithEvents LblDjh As System.Windows.Forms.Label
    Public WithEvents TxtCpmc As System.Windows.Forms.TextBox
    Public WithEvents LblCpmc As System.Windows.Forms.Label
    Public WithEvents TxtCpdm As System.Windows.Forms.TextBox
    Public WithEvents LblCpdm As System.Windows.Forms.Label
    Public WithEvents TxtSgddh As System.Windows.Forms.TextBox
    Public WithEvents LblSgddh As System.Windows.Forms.Label
End Class
