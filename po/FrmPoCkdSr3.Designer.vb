<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPoCkdSr3
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
        Me.components = New System.ComponentModel.Container
        Me.TxtZydm = New System.Windows.Forms.TextBox
        Me.LblZydm = New System.Windows.Forms.Label
        Me.TimerReadCard = New System.Windows.Forms.Timer(Me.components)
        Me.ChbSh = New System.Windows.Forms.CheckBox
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
        Me.DlgPanel.Location = New System.Drawing.Point(100, 135)
        Me.DlgPanel.TabIndex = 3
        '
        'TxtZydm
        '
        Me.TxtZydm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtZydm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtZydm.Location = New System.Drawing.Point(172, 32)
        Me.TxtZydm.MaxLength = 12
        Me.TxtZydm.Name = "TxtZydm"
        Me.TxtZydm.Size = New System.Drawing.Size(104, 26)
        Me.TxtZydm.TabIndex = 1
        '
        'LblZydm
        '
        Me.LblZydm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblZydm.AutoSize = True
        Me.LblZydm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblZydm.Location = New System.Drawing.Point(76, 36)
        Me.LblZydm.Name = "LblZydm"
        Me.LblZydm.Size = New System.Drawing.Size(88, 16)
        Me.LblZydm.TabIndex = 0
        Me.LblZydm.Text = "职员编码："
        '
        'TimerReadCard
        '
        Me.TimerReadCard.Interval = 1000
        '
        'ChbSh
        '
        Me.ChbSh.Checked = True
        Me.ChbSh.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChbSh.ForeColor = System.Drawing.Color.SteelBlue
        Me.ChbSh.Location = New System.Drawing.Point(86, 81)
        Me.ChbSh.Name = "ChbSh"
        Me.ChbSh.Size = New System.Drawing.Size(180, 24)
        Me.ChbSh.TabIndex = 2
        Me.ChbSh.Text = "领料申请单审核后才能发料"
        '
        'FrmPoCkdSr2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(353, 178)
        Me.Controls.Add(Me.ChbSh)
        Me.Controls.Add(Me.TxtZydm)
        Me.Controls.Add(Me.LblZydm)
        Me.Name = "FrmPoCkdSr2"
        Me.Text = "物料领用发货"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.LblZydm, 0)
        Me.Controls.SetChildIndex(Me.TxtZydm, 0)
        Me.Controls.SetChildIndex(Me.ChbSh, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents TxtZydm As System.Windows.Forms.TextBox
    Public WithEvents LblZydm As System.Windows.Forms.Label
    Friend WithEvents TimerReadCard As System.Windows.Forms.Timer
    Friend WithEvents ChbSh As System.Windows.Forms.CheckBox
End Class
