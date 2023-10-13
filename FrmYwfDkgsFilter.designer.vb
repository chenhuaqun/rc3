<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmYwfDkgsFilter
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
        Me.LblDkgsdm = New System.Windows.Forms.Label
        Me.LblDkgsmc = New System.Windows.Forms.Label
        Me.TxtDkgsdm = New System.Windows.Forms.TextBox
        Me.TxtDkgsmc = New System.Windows.Forms.TextBox
        Me.DlgPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(133, 107)
        '
        'LblDkgsdm
        '
        Me.LblDkgsdm.AutoSize = True
        Me.LblDkgsdm.Location = New System.Drawing.Point(39, 32)
        Me.LblDkgsdm.Name = "LblDkgsdm"
        Me.LblDkgsdm.Size = New System.Drawing.Size(89, 12)
        Me.LblDkgsdm.TabIndex = 102
        Me.LblDkgsdm.Text = "抵扣规则编码："
        '
        'LblDkgsmc
        '
        Me.LblDkgsmc.AutoSize = True
        Me.LblDkgsmc.Location = New System.Drawing.Point(39, 56)
        Me.LblDkgsmc.Name = "LblDkgsmc"
        Me.LblDkgsmc.Size = New System.Drawing.Size(89, 12)
        Me.LblDkgsmc.TabIndex = 103
        Me.LblDkgsmc.Text = "抵扣规则名称："
        '
        'TxtDkgsdm
        '
        Me.TxtDkgsdm.Location = New System.Drawing.Point(136, 29)
        Me.TxtDkgsdm.MaxLength = 12
        Me.TxtDkgsdm.Name = "TxtDkgsdm"
        Me.TxtDkgsdm.Size = New System.Drawing.Size(96, 21)
        Me.TxtDkgsdm.TabIndex = 104
        '
        'TxtDkgsmc
        '
        Me.TxtDkgsmc.Location = New System.Drawing.Point(136, 53)
        Me.TxtDkgsmc.MaxLength = 30
        Me.TxtDkgsmc.Name = "TxtDkgsmc"
        Me.TxtDkgsmc.Size = New System.Drawing.Size(208, 21)
        Me.TxtDkgsmc.TabIndex = 105
        '
        'FrmYwfDkgsFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(386, 150)
        Me.Controls.Add(Me.LblDkgsdm)
        Me.Controls.Add(Me.LblDkgsmc)
        Me.Controls.Add(Me.TxtDkgsdm)
        Me.Controls.Add(Me.TxtDkgsmc)
        Me.Name = "FrmYwfDkgsFilter"
        Me.Text = "条件筛选"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.TxtDkgsmc, 0)
        Me.Controls.SetChildIndex(Me.TxtDkgsdm, 0)
        Me.Controls.SetChildIndex(Me.LblDkgsmc, 0)
        Me.Controls.SetChildIndex(Me.LblDkgsdm, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblDkgsdm As Label
    Friend WithEvents LblDkgsmc As Label
    Friend WithEvents TxtDkgsdm As TextBox
    Friend WithEvents TxtDkgsmc As TextBox
End Class
