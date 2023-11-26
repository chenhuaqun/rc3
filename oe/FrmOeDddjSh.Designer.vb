<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeDddjSh
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
        Me.TxtLbdm = New System.Windows.Forms.TextBox
        Me.LblLbdm = New System.Windows.Forms.Label
        Me.DlgPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(83, 135)
        '
        'TxtDjh
        '
        Me.TxtDjh.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtDjh.Location = New System.Drawing.Point(152, 38)
        Me.TxtDjh.MaxLength = 15
        Me.TxtDjh.Name = "TxtDjh"
        Me.TxtDjh.Size = New System.Drawing.Size(136, 26)
        Me.TxtDjh.TabIndex = 1
        '
        'LblDjh
        '
        Me.LblDjh.AutoSize = True
        Me.LblDjh.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblDjh.Location = New System.Drawing.Point(39, 41)
        Me.LblDjh.Name = "LblDjh"
        Me.LblDjh.Size = New System.Drawing.Size(104, 16)
        Me.LblDjh.TabIndex = 0
        Me.LblDjh.Text = "合同单据号："
        '
        'TxtLbdm
        '
        Me.TxtLbdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtLbdm.Location = New System.Drawing.Point(152, 70)
        Me.TxtLbdm.MaxLength = 12
        Me.TxtLbdm.Name = "TxtLbdm"
        Me.TxtLbdm.Size = New System.Drawing.Size(136, 26)
        Me.TxtLbdm.TabIndex = 3
        '
        'LblLbdm
        '
        Me.LblLbdm.AutoSize = True
        Me.LblLbdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblLbdm.Location = New System.Drawing.Point(39, 73)
        Me.LblLbdm.Name = "LblLbdm"
        Me.LblLbdm.Size = New System.Drawing.Size(120, 16)
        Me.LblLbdm.TabIndex = 2
        Me.LblLbdm.Text = "物料类别编码："
        '
        'FrmOeDddjSh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(336, 178)
        Me.Controls.Add(Me.TxtLbdm)
        Me.Controls.Add(Me.LblLbdm)
        Me.Controls.Add(Me.TxtDjh)
        Me.Controls.Add(Me.LblDjh)
        Me.Name = "FrmOeDddjSh"
        Me.Text = "产品销售订单单价审核"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.LblDjh, 0)
        Me.Controls.SetChildIndex(Me.TxtDjh, 0)
        Me.Controls.SetChildIndex(Me.LblLbdm, 0)
        Me.Controls.SetChildIndex(Me.TxtLbdm, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents TxtDjh As System.Windows.Forms.TextBox
    Public WithEvents LblDjh As System.Windows.Forms.Label
    Public WithEvents TxtLbdm As System.Windows.Forms.TextBox
    Public WithEvents LblLbdm As System.Windows.Forms.Label
End Class
