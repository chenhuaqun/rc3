<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeBjdSaveAs
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
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.BtnXzwj = New System.Windows.Forms.Button
        Me.TxtFolderName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.DlgPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(165, 93)
        '
        'BtnXzwj
        '
        Me.BtnXzwj.Location = New System.Drawing.Point(365, 34)
        Me.BtnXzwj.Name = "BtnXzwj"
        Me.BtnXzwj.Size = New System.Drawing.Size(24, 23)
        Me.BtnXzwj.TabIndex = 15
        Me.BtnXzwj.Text = "…"
        Me.BtnXzwj.UseVisualStyleBackColor = True
        '
        'TxtFolderName
        '
        Me.TxtFolderName.Location = New System.Drawing.Point(39, 34)
        Me.TxtFolderName.Name = "TxtFolderName"
        Me.TxtFolderName.Size = New System.Drawing.Size(320, 21)
        Me.TxtFolderName.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(37, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 12)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "源文件(Excel格式)："
        '
        'FrmOeBjdSaveAs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(418, 136)
        Me.Controls.Add(Me.TxtFolderName)
        Me.Controls.Add(Me.BtnXzwj)
        Me.Controls.Add(Me.Label2)
        Me.Name = "FrmOeBjdSaveAs"
        Me.Text = "另存为…"
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.BtnXzwj, 0)
        Me.Controls.SetChildIndex(Me.TxtFolderName, 0)
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents BtnXzwj As System.Windows.Forms.Button
    Friend WithEvents TxtFolderName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
