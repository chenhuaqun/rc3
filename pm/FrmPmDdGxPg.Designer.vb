<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPmDdGxPg
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
        Me.LblBmdm = New System.Windows.Forms.Label
        Me.TxtBmdm = New System.Windows.Forms.TextBox
        Me.LblBmmc = New System.Windows.Forms.Label
        Me.DlgPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(41, 105)
        Me.DlgPanel.TabIndex = 3
        '
        'LblBmdm
        '
        Me.LblBmdm.AutoSize = True
        Me.LblBmdm.Location = New System.Drawing.Point(67, 35)
        Me.LblBmdm.Name = "LblBmdm"
        Me.LblBmdm.Size = New System.Drawing.Size(65, 12)
        Me.LblBmdm.TabIndex = 0
        Me.LblBmdm.Text = "部门编码："
        '
        'TxtBmdm
        '
        Me.TxtBmdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBmdm.Location = New System.Drawing.Point(138, 32)
        Me.TxtBmdm.MaxLength = 12
        Me.TxtBmdm.Name = "TxtBmdm"
        Me.TxtBmdm.Size = New System.Drawing.Size(87, 21)
        Me.TxtBmdm.TabIndex = 1
        '
        'LblBmmc
        '
        Me.LblBmmc.AutoSize = True
        Me.LblBmmc.Location = New System.Drawing.Point(136, 70)
        Me.LblBmmc.Name = "LblBmmc"
        Me.LblBmmc.Size = New System.Drawing.Size(0, 12)
        Me.LblBmmc.TabIndex = 2
        '
        'FrmPmDdGxPg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 146)
        Me.Controls.Add(Me.LblBmmc)
        Me.Controls.Add(Me.LblBmdm)
        Me.Controls.Add(Me.TxtBmdm)
        Me.Name = "FrmPmDdGxPg"
        Me.Text = "工序派工"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.TxtBmdm, 0)
        Me.Controls.SetChildIndex(Me.LblBmdm, 0)
        Me.Controls.SetChildIndex(Me.LblBmmc, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblBmdm As System.Windows.Forms.Label
    Friend WithEvents TxtBmdm As System.Windows.Forms.TextBox
    Public WithEvents LblBmmc As System.Windows.Forms.Label
End Class
