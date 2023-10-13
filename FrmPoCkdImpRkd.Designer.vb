<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPoCkdImpRkd
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
        Me.TxtHth = New System.Windows.Forms.TextBox
        Me.LblSgdh = New System.Windows.Forms.Label
        Me.DlgPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(41, 96)
        '
        'TxtHth
        '
        Me.TxtHth.Location = New System.Drawing.Point(124, 38)
        Me.TxtHth.MaxLength = 11
        Me.TxtHth.Name = "TxtHth"
        Me.TxtHth.Size = New System.Drawing.Size(104, 21)
        Me.TxtHth.TabIndex = 1
        '
        'LblSgdh
        '
        Me.LblSgdh.AutoSize = True
        Me.LblSgdh.Location = New System.Drawing.Point(53, 42)
        Me.LblSgdh.Name = "LblSgdh"
        Me.LblSgdh.Size = New System.Drawing.Size(65, 12)
        Me.LblSgdh.TabIndex = 0
        Me.LblSgdh.Text = "订 单 号："
        '
        'FrmPoCkdImpRkd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(294, 139)
        Me.Controls.Add(Me.TxtHth)
        Me.Controls.Add(Me.LblSgdh)
        Me.Name = "FrmPoCkdImpRkd"
        Me.Text = "出库单导入入库单"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.LblSgdh, 0)
        Me.Controls.SetChildIndex(Me.TxtHth, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents TxtHth As System.Windows.Forms.TextBox
    Public WithEvents LblSgdh As System.Windows.Forms.Label
End Class
