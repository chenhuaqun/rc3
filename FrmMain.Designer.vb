<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents MenuStripMain As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuiZtdl As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStripMain As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripStatusSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripStatusSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BackgroundWorkerMain As System.ComponentModel.BackgroundWorker

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MenuStripMain = New System.Windows.Forms.MenuStrip()
        Me.MnuiZtdl = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStripMain = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripStatusSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripStatusSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BackgroundWorkerMain = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'MenuStripMain
        '
        Me.MenuStripMain.Location = New System.Drawing.Point(0, 0)
        Me.MenuStripMain.Name = "MenuStripMain"
        Me.MenuStripMain.Size = New System.Drawing.Size(1028, 24)
        Me.MenuStripMain.TabIndex = 0
        '
        'StatusStripMain
        '
        Me.ToolStripStatusSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripStatusSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripStatusSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.StatusStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusSeparator1, Me.ToolStripStatusLabel2, Me.ToolStripStatusSeparator2, Me.ToolStripStatusLabel3, Me.ToolStripStatusSeparator3, Me.ToolStripStatusLabel4})
        Me.StatusStripMain.Location = New System.Drawing.Point(0, 615)
        Me.StatusStripMain.Name = "StatusStripMain"
        Me.StatusStripMain.Size = New System.Drawing.Size(1028, 22)
        Me.StatusStripMain.TabIndex = 1
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(68, 17)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "欢迎使用!"
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(48, 17)
        Me.ToolStripStatusLabel2.Text = "单位："
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(60, 17)
        Me.ToolStripStatusLabel3.Text = "操作员："
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(68, 17)
        Me.ToolStripStatusLabel4.Text = "登陆日期："
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1028, 637)
        Me.IsMdiContainer = True
        Me.Text = "杭州锐创软件有限公司（RC3供应链）"
        Me.Controls.Add(Me.MenuStripMain)
        Me.Controls.Add(Me.StatusStripMain)
        Me.MainMenuStrip = Me.MenuStripMain
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

End Class