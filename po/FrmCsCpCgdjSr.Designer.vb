<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCsCpCgdjSr
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
        Me.LblDw = New System.Windows.Forms.Label
        Me.LblCpmc = New System.Windows.Forms.Label
        Me.TxtCgdj = New System.Windows.Forms.TextBox
        Me.LblCgdj = New System.Windows.Forms.Label
        Me.TxtCpdm = New System.Windows.Forms.TextBox
        Me.LblCpdm = New System.Windows.Forms.Label
        Me.LblCsmc = New System.Windows.Forms.Label
        Me.TxtCsdm = New System.Windows.Forms.TextBox
        Me.LblCsdm = New System.Windows.Forms.Label
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
        Me.DlgPanel.Location = New System.Drawing.Point(141, 243)
        Me.DlgPanel.TabIndex = 15
        '
        'LblDw
        '
        Me.LblDw.AutoSize = True
        Me.LblDw.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblDw.Location = New System.Drawing.Point(75, 156)
        Me.LblDw.Name = "LblDw"
        Me.LblDw.Size = New System.Drawing.Size(88, 16)
        Me.LblDw.TabIndex = 5
        Me.LblDw.Text = "单    位："
        '
        'LblCpmc
        '
        Me.LblCpmc.AutoSize = True
        Me.LblCpmc.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblCpmc.Location = New System.Drawing.Point(75, 122)
        Me.LblCpmc.Name = "LblCpmc"
        Me.LblCpmc.Size = New System.Drawing.Size(88, 16)
        Me.LblCpmc.TabIndex = 2
        Me.LblCpmc.Text = "物料描述："
        '
        'TxtCgdj
        '
        Me.TxtCgdj.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtCgdj.Location = New System.Drawing.Point(171, 185)
        Me.TxtCgdj.MaxLength = 16
        Me.TxtCgdj.Name = "TxtCgdj"
        Me.TxtCgdj.Size = New System.Drawing.Size(104, 26)
        Me.TxtCgdj.TabIndex = 10
        '
        'LblCgdj
        '
        Me.LblCgdj.AutoSize = True
        Me.LblCgdj.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblCgdj.Location = New System.Drawing.Point(75, 190)
        Me.LblCgdj.Name = "LblCgdj"
        Me.LblCgdj.Size = New System.Drawing.Size(88, 16)
        Me.LblCgdj.TabIndex = 9
        Me.LblCgdj.Text = "采购单价："
        '
        'TxtCpdm
        '
        Me.TxtCpdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCpdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtCpdm.Location = New System.Drawing.Point(171, 83)
        Me.TxtCpdm.MaxLength = 15
        Me.TxtCpdm.Name = "TxtCpdm"
        Me.TxtCpdm.Size = New System.Drawing.Size(104, 26)
        Me.TxtCpdm.TabIndex = 1
        '
        'LblCpdm
        '
        Me.LblCpdm.AutoSize = True
        Me.LblCpdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblCpdm.Location = New System.Drawing.Point(75, 88)
        Me.LblCpdm.Name = "LblCpdm"
        Me.LblCpdm.Size = New System.Drawing.Size(88, 16)
        Me.LblCpdm.TabIndex = 0
        Me.LblCpdm.Text = "物料编码："
        '
        'LblCsmc
        '
        Me.LblCsmc.AutoSize = True
        Me.LblCsmc.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblCsmc.Location = New System.Drawing.Point(59, 54)
        Me.LblCsmc.Name = "LblCsmc"
        Me.LblCsmc.Size = New System.Drawing.Size(104, 16)
        Me.LblCsmc.TabIndex = 8
        Me.LblCsmc.Text = "供应商名称："
        '
        'TxtCsdm
        '
        Me.TxtCsdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCsdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtCsdm.Location = New System.Drawing.Point(171, 15)
        Me.TxtCsdm.MaxLength = 15
        Me.TxtCsdm.Name = "TxtCsdm"
        Me.TxtCsdm.Size = New System.Drawing.Size(104, 26)
        Me.TxtCsdm.TabIndex = 17
        '
        'LblCsdm
        '
        Me.LblCsdm.AutoSize = True
        Me.LblCsdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblCsdm.Location = New System.Drawing.Point(59, 18)
        Me.LblCsdm.Name = "LblCsdm"
        Me.LblCsdm.Size = New System.Drawing.Size(104, 16)
        Me.LblCsdm.TabIndex = 16
        Me.LblCsdm.Text = "供应商编码："
        '
        'FrmCsCpCgdjSr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 286)
        Me.Controls.Add(Me.TxtCsdm)
        Me.Controls.Add(Me.LblCsdm)
        Me.Controls.Add(Me.LblCsmc)
        Me.Controls.Add(Me.LblDw)
        Me.Controls.Add(Me.LblCpmc)
        Me.Controls.Add(Me.TxtCgdj)
        Me.Controls.Add(Me.LblCgdj)
        Me.Controls.Add(Me.TxtCpdm)
        Me.Controls.Add(Me.LblCpdm)
        Me.Name = "FrmCsCpCgdjSr"
        Me.Text = "供应商物料采购价格目录维护"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.LblCpdm, 0)
        Me.Controls.SetChildIndex(Me.TxtCpdm, 0)
        Me.Controls.SetChildIndex(Me.LblCgdj, 0)
        Me.Controls.SetChildIndex(Me.TxtCgdj, 0)
        Me.Controls.SetChildIndex(Me.LblCpmc, 0)
        Me.Controls.SetChildIndex(Me.LblDw, 0)
        Me.Controls.SetChildIndex(Me.LblCsmc, 0)
        Me.Controls.SetChildIndex(Me.LblCsdm, 0)
        Me.Controls.SetChildIndex(Me.TxtCsdm, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents LblDw As System.Windows.Forms.Label
    Public WithEvents LblCpmc As System.Windows.Forms.Label
    Public WithEvents TxtCgdj As System.Windows.Forms.TextBox
    Public WithEvents LblCgdj As System.Windows.Forms.Label
    Public WithEvents TxtCpdm As System.Windows.Forms.TextBox
    Public WithEvents LblCpdm As System.Windows.Forms.Label
    Public WithEvents LblCsmc As System.Windows.Forms.Label
    Public WithEvents TxtCsdm As System.Windows.Forms.TextBox
    Public WithEvents LblCsdm As System.Windows.Forms.Label
End Class
