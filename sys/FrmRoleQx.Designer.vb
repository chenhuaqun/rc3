<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRoleQx
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
        Me.rcTabControl = New System.Windows.Forms.TabControl
        Me.TabPageRC3 = New System.Windows.Forms.TabPage
        Me.ListBoxYuxuanRC3 = New System.Windows.Forms.ListBox
        Me.ListBoxYixuanRC3 = New System.Windows.Forms.ListBox
        Me.BtnSelectAllRC3 = New System.Windows.Forms.Button
        Me.BtnSelectOneRC3 = New System.Windows.Forms.Button
        Me.BtnUnSelectOneRC3 = New System.Windows.Forms.Button
        Me.BtnUnSelectAllRC3 = New System.Windows.Forms.Button
        Me.LblYuxuanRC3 = New System.Windows.Forms.Label
        Me.LblYixuanRC3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DlgPanel.SuspendLayout()
        Me.rcTabControl.SuspendLayout()
        Me.TabPageRC3.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(505, 388)
        '
        'rcTabControl
        '
        Me.rcTabControl.Controls.Add(Me.TabPageRC3)
        Me.rcTabControl.Location = New System.Drawing.Point(12, 47)
        Me.rcTabControl.Name = "rcTabControl"
        Me.rcTabControl.SelectedIndex = 0
        Me.rcTabControl.Size = New System.Drawing.Size(729, 328)
        Me.rcTabControl.TabIndex = 102
        '
        'TabPageRC3
        '
        Me.TabPageRC3.Controls.Add(Me.ListBoxYuxuanRC3)
        Me.TabPageRC3.Controls.Add(Me.ListBoxYixuanRC3)
        Me.TabPageRC3.Controls.Add(Me.BtnSelectAllRC3)
        Me.TabPageRC3.Controls.Add(Me.BtnSelectOneRC3)
        Me.TabPageRC3.Controls.Add(Me.BtnUnSelectOneRC3)
        Me.TabPageRC3.Controls.Add(Me.BtnUnSelectAllRC3)
        Me.TabPageRC3.Controls.Add(Me.LblYuxuanRC3)
        Me.TabPageRC3.Controls.Add(Me.LblYixuanRC3)
        Me.TabPageRC3.Location = New System.Drawing.Point(4, 22)
        Me.TabPageRC3.Name = "TabPageRC3"
        Me.TabPageRC3.Size = New System.Drawing.Size(721, 302)
        Me.TabPageRC3.TabIndex = 1
        Me.TabPageRC3.Text = "RC3(供应链)"
        Me.TabPageRC3.UseVisualStyleBackColor = True
        '
        'ListBoxYuxuanRC3
        '
        Me.ListBoxYuxuanRC3.ItemHeight = 12
        Me.ListBoxYuxuanRC3.Location = New System.Drawing.Point(14, 32)
        Me.ListBoxYuxuanRC3.Name = "ListBoxYuxuanRC3"
        Me.ListBoxYuxuanRC3.Size = New System.Drawing.Size(300, 256)
        Me.ListBoxYuxuanRC3.Sorted = True
        Me.ListBoxYuxuanRC3.TabIndex = 23
        '
        'ListBoxYixuanRC3
        '
        Me.ListBoxYixuanRC3.ItemHeight = 12
        Me.ListBoxYixuanRC3.Location = New System.Drawing.Point(406, 32)
        Me.ListBoxYixuanRC3.Name = "ListBoxYixuanRC3"
        Me.ListBoxYixuanRC3.Size = New System.Drawing.Size(300, 256)
        Me.ListBoxYixuanRC3.Sorted = True
        Me.ListBoxYixuanRC3.TabIndex = 24
        '
        'BtnSelectAllRC3
        '
        Me.BtnSelectAllRC3.Location = New System.Drawing.Point(320, 41)
        Me.BtnSelectAllRC3.Name = "BtnSelectAllRC3"
        Me.BtnSelectAllRC3.Size = New System.Drawing.Size(75, 23)
        Me.BtnSelectAllRC3.TabIndex = 17
        Me.BtnSelectAllRC3.Text = "-->>"
        '
        'BtnSelectOneRC3
        '
        Me.BtnSelectOneRC3.Location = New System.Drawing.Point(320, 81)
        Me.BtnSelectOneRC3.Name = "BtnSelectOneRC3"
        Me.BtnSelectOneRC3.Size = New System.Drawing.Size(75, 23)
        Me.BtnSelectOneRC3.TabIndex = 18
        Me.BtnSelectOneRC3.Text = "-->"
        '
        'BtnUnSelectOneRC3
        '
        Me.BtnUnSelectOneRC3.Location = New System.Drawing.Point(320, 121)
        Me.BtnUnSelectOneRC3.Name = "BtnUnSelectOneRC3"
        Me.BtnUnSelectOneRC3.Size = New System.Drawing.Size(75, 23)
        Me.BtnUnSelectOneRC3.TabIndex = 19
        Me.BtnUnSelectOneRC3.Text = "<--"
        '
        'BtnUnSelectAllRC3
        '
        Me.BtnUnSelectAllRC3.Location = New System.Drawing.Point(320, 161)
        Me.BtnUnSelectAllRC3.Name = "BtnUnSelectAllRC3"
        Me.BtnUnSelectAllRC3.Size = New System.Drawing.Size(75, 23)
        Me.BtnUnSelectAllRC3.TabIndex = 20
        Me.BtnUnSelectAllRC3.Text = "<<--"
        '
        'LblYuxuanRC3
        '
        Me.LblYuxuanRC3.AutoSize = True
        Me.LblYuxuanRC3.Location = New System.Drawing.Point(29, 8)
        Me.LblYuxuanRC3.Name = "LblYuxuanRC3"
        Me.LblYuxuanRC3.Size = New System.Drawing.Size(77, 12)
        Me.LblYuxuanRC3.TabIndex = 21
        Me.LblYuxuanRC3.Text = "预选功能权限"
        '
        'LblYixuanRC3
        '
        Me.LblYixuanRC3.AutoSize = True
        Me.LblYixuanRC3.Location = New System.Drawing.Point(411, 8)
        Me.LblYixuanRC3.Name = "LblYixuanRC3"
        Me.LblYixuanRC3.Size = New System.Drawing.Size(77, 12)
        Me.LblYixuanRC3.TabIndex = 22
        Me.LblYixuanRC3.Text = "已选功能权限"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = "角色："
        '
        'FrmRoleQx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(758, 431)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.rcTabControl)
        Me.Name = "FrmRoleQx"
        Me.Text = "角色权限设置"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.rcTabControl, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.rcTabControl.ResumeLayout(False)
        Me.TabPageRC3.ResumeLayout(False)
        Me.TabPageRC3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rcTabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabPageRC3 As System.Windows.Forms.TabPage
    Friend WithEvents ListBoxYuxuanRC3 As System.Windows.Forms.ListBox
    Friend WithEvents ListBoxYixuanRC3 As System.Windows.Forms.ListBox
    Friend WithEvents BtnSelectAllRC3 As System.Windows.Forms.Button
    Friend WithEvents BtnSelectOneRC3 As System.Windows.Forms.Button
    Friend WithEvents BtnUnSelectOneRC3 As System.Windows.Forms.Button
    Friend WithEvents BtnUnSelectAllRC3 As System.Windows.Forms.Button
    Friend WithEvents LblYuxuanRC3 As System.Windows.Forms.Label
    Friend WithEvents LblYixuanRC3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
