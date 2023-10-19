<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBomCx
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
        Me.TxtChildCpmc = New System.Windows.Forms.TextBox
        Me.LblChildCpmc = New System.Windows.Forms.Label
        Me.TxtParentCpmc = New System.Windows.Forms.TextBox
        Me.LblParentCpmc = New System.Windows.Forms.Label
        Me.TxtChildCpdm = New System.Windows.Forms.TextBox
        Me.LblChildCpdm = New System.Windows.Forms.Label
        Me.TxtParentCpdm = New System.Windows.Forms.TextBox
        Me.LblParentCpdm = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.NudMonth = New System.Windows.Forms.NumericUpDown
        Me.NudYear = New System.Windows.Forms.NumericUpDown
        Me.DlgPanel.SuspendLayout()
        CType(Me.NudMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudYear, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.DlgPanel.Location = New System.Drawing.Point(192, 191)
        Me.DlgPanel.TabIndex = 12
        '
        'TxtChildCpmc
        '
        Me.TxtChildCpmc.Location = New System.Drawing.Point(141, 110)
        Me.TxtChildCpmc.MaxLength = 50
        Me.TxtChildCpmc.Name = "TxtChildCpmc"
        Me.TxtChildCpmc.Size = New System.Drawing.Size(252, 21)
        Me.TxtChildCpmc.TabIndex = 7
        '
        'LblChildCpmc
        '
        Me.LblChildCpmc.AutoSize = True
        Me.LblChildCpmc.Location = New System.Drawing.Point(46, 114)
        Me.LblChildCpmc.Name = "LblChildCpmc"
        Me.LblChildCpmc.Size = New System.Drawing.Size(89, 12)
        Me.LblChildCpmc.TabIndex = 6
        Me.LblChildCpmc.Text = "子项物料描述："
        '
        'TxtParentCpmc
        '
        Me.TxtParentCpmc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtParentCpmc.Location = New System.Drawing.Point(141, 52)
        Me.TxtParentCpmc.MaxLength = 50
        Me.TxtParentCpmc.Name = "TxtParentCpmc"
        Me.TxtParentCpmc.Size = New System.Drawing.Size(252, 21)
        Me.TxtParentCpmc.TabIndex = 3
        '
        'LblParentCpmc
        '
        Me.LblParentCpmc.AutoSize = True
        Me.LblParentCpmc.Location = New System.Drawing.Point(46, 56)
        Me.LblParentCpmc.Name = "LblParentCpmc"
        Me.LblParentCpmc.Size = New System.Drawing.Size(89, 12)
        Me.LblParentCpmc.TabIndex = 2
        Me.LblParentCpmc.Text = "父项物料描述："
        '
        'TxtChildCpdm
        '
        Me.TxtChildCpdm.Location = New System.Drawing.Point(141, 81)
        Me.TxtChildCpdm.MaxLength = 15
        Me.TxtChildCpdm.Name = "TxtChildCpdm"
        Me.TxtChildCpdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtChildCpdm.TabIndex = 5
        '
        'LblChildCpdm
        '
        Me.LblChildCpdm.AutoSize = True
        Me.LblChildCpdm.Location = New System.Drawing.Point(46, 85)
        Me.LblChildCpdm.Name = "LblChildCpdm"
        Me.LblChildCpdm.Size = New System.Drawing.Size(89, 12)
        Me.LblChildCpdm.TabIndex = 4
        Me.LblChildCpdm.Text = "子项物料编码："
        '
        'TxtParentCpdm
        '
        Me.TxtParentCpdm.Location = New System.Drawing.Point(141, 23)
        Me.TxtParentCpdm.MaxLength = 15
        Me.TxtParentCpdm.Name = "TxtParentCpdm"
        Me.TxtParentCpdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtParentCpdm.TabIndex = 1
        '
        'LblParentCpdm
        '
        Me.LblParentCpdm.AutoSize = True
        Me.LblParentCpdm.Location = New System.Drawing.Point(46, 27)
        Me.LblParentCpdm.Name = "LblParentCpdm"
        Me.LblParentCpdm.Size = New System.Drawing.Size(89, 12)
        Me.LblParentCpdm.TabIndex = 0
        Me.LblParentCpdm.Text = "父项物料编码："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(285, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "月"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(213, 150)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 12)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "年"
        '
        'NudMonth
        '
        Me.NudMonth.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NudMonth.Location = New System.Drawing.Point(237, 146)
        Me.NudMonth.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NudMonth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudMonth.Name = "NudMonth"
        Me.NudMonth.Size = New System.Drawing.Size(40, 21)
        Me.NudMonth.TabIndex = 10
        Me.NudMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudMonth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NudYear
        '
        Me.NudYear.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NudYear.Location = New System.Drawing.Point(141, 146)
        Me.NudYear.Maximum = New Decimal(New Integer() {2050, 0, 0, 0})
        Me.NudYear.Minimum = New Decimal(New Integer() {1990, 0, 0, 0})
        Me.NudYear.Name = "NudYear"
        Me.NudYear.Size = New System.Drawing.Size(64, 21)
        Me.NudYear.TabIndex = 8
        Me.NudYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudYear.Value = New Decimal(New Integer() {1990, 0, 0, 0})
        '
        'FrmBomCx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(445, 234)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NudMonth)
        Me.Controls.Add(Me.NudYear)
        Me.Controls.Add(Me.TxtChildCpmc)
        Me.Controls.Add(Me.LblChildCpmc)
        Me.Controls.Add(Me.TxtParentCpmc)
        Me.Controls.Add(Me.LblParentCpmc)
        Me.Controls.Add(Me.TxtChildCpdm)
        Me.Controls.Add(Me.LblChildCpdm)
        Me.Controls.Add(Me.TxtParentCpdm)
        Me.Controls.Add(Me.LblParentCpdm)
        Me.Name = "FrmBomCx"
        Me.Text = "物料清单查询"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.LblParentCpdm, 0)
        Me.Controls.SetChildIndex(Me.TxtParentCpdm, 0)
        Me.Controls.SetChildIndex(Me.LblChildCpdm, 0)
        Me.Controls.SetChildIndex(Me.TxtChildCpdm, 0)
        Me.Controls.SetChildIndex(Me.LblParentCpmc, 0)
        Me.Controls.SetChildIndex(Me.TxtParentCpmc, 0)
        Me.Controls.SetChildIndex(Me.LblChildCpmc, 0)
        Me.Controls.SetChildIndex(Me.TxtChildCpmc, 0)
        Me.Controls.SetChildIndex(Me.NudYear, 0)
        Me.Controls.SetChildIndex(Me.NudMonth, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.DlgPanel.ResumeLayout(False)
        CType(Me.NudMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents TxtChildCpmc As System.Windows.Forms.TextBox
    Public WithEvents LblChildCpmc As System.Windows.Forms.Label
    Public WithEvents TxtParentCpmc As System.Windows.Forms.TextBox
    Public WithEvents LblParentCpmc As System.Windows.Forms.Label
    Public WithEvents TxtChildCpdm As System.Windows.Forms.TextBox
    Public WithEvents LblChildCpdm As System.Windows.Forms.Label
    Public WithEvents TxtParentCpdm As System.Windows.Forms.TextBox
    Public WithEvents LblParentCpdm As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NudMonth As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudYear As System.Windows.Forms.NumericUpDown
End Class
