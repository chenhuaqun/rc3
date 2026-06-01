<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmUpdateProgress
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.LabelVersion = New System.Windows.Forms.Label()
        Me.ProgressBarMain = New System.Windows.Forms.ProgressBar()
        Me.LabelProgress = New System.Windows.Forms.Label()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.LabelFileSize = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LabelVersion
        '
        Me.LabelVersion.AutoSize = True
        Me.LabelVersion.Location = New System.Drawing.Point(16, 16)
        Me.LabelVersion.Name = "LabelVersion"
        Me.LabelVersion.Size = New System.Drawing.Size(120, 17)
        Me.LabelVersion.TabIndex = 0
        Me.LabelVersion.Text = "最新版本："
        '
        'ProgressBarMain
        '
        Me.ProgressBarMain.Location = New System.Drawing.Point(16, 48)
        Me.ProgressBarMain.Name = "ProgressBarMain"
        Me.ProgressBarMain.Size = New System.Drawing.Size(400, 24)
        Me.ProgressBarMain.TabIndex = 1
        '
        'LabelProgress
        '
        Me.LabelProgress.AutoSize = True
        Me.LabelProgress.Location = New System.Drawing.Point(16, 80)
        Me.LabelProgress.Name = "LabelProgress"
        Me.LabelProgress.Size = New System.Drawing.Size(52, 17)
        Me.LabelProgress.TabIndex = 2
        Me.LabelProgress.Text = "准备中..."
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(336, 112)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(80, 28)
        Me.BtnCancel.TabIndex = 3
        Me.BtnCancel.Text = "取消"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'LabelFileSize
        '
        Me.LabelFileSize.AutoSize = True
        Me.LabelFileSize.Location = New System.Drawing.Point(200, 16)
        Me.LabelFileSize.Name = "LabelFileSize"
        Me.LabelFileSize.Size = New System.Drawing.Size(56, 17)
        Me.LabelFileSize.TabIndex = 4
        Me.LabelFileSize.Text = "文件大小"
        '
        'FrmUpdateProgress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 156)
        Me.ControlBox = False
        Me.Controls.Add(Me.LabelFileSize)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.LabelProgress)
        Me.Controls.Add(Me.ProgressBarMain)
        Me.Controls.Add(Me.LabelVersion)
        Me.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmUpdateProgress"
        Me.ShowIcon = False
        Me.ShowInTaskbar = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "软件更新"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelVersion As System.Windows.Forms.Label
    Friend WithEvents ProgressBarMain As System.Windows.Forms.ProgressBar
    Friend WithEvents LabelProgress As System.Windows.Forms.Label
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents LabelFileSize As System.Windows.Forms.Label
End Class
