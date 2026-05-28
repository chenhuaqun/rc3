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
    Friend WithEvents MnuiRegister As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiCheckData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiUpdateDB As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiImpNC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiImpU8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiCpdmGg As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiKhdmGg As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiCsdmGg As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiZydmGg As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiRedoCpyeHz As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiRedoFcspyeHz As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiCpRepair As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiUpdate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiUploadFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiModPwd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiZtdl As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStripMain As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BackgroundWorkerMain As System.ComponentModel.BackgroundWorker

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MenuStripMain = New System.Windows.Forms.MenuStrip()
        Me.MnuiRegister = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiCheckData = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiUpdateDB = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiImpNC = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiImpU8 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiCpdmGg = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiKhdmGg = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiCsdmGg = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiZydmGg = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiRedoCpyeHz = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiRedoFcspyeHz = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiCpRepair = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiUpdate = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiUploadFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiModPwd = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiZtdl = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStripMain = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
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
        Me.StatusStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4})
        Me.StatusStripMain.Location = New System.Drawing.Point(0, 615)
        Me.StatusStripMain.Name = "StatusStripMain"
        Me.StatusStripMain.Size = New System.Drawing.Size(1028, 22)
        Me.StatusStripMain.TabIndex = 1
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(68, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(68, 17)
        Me.ToolStripStatusLabel2.Text = "ToolStripStatusLabel2"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(68, 17)
        Me.ToolStripStatusLabel3.Text = "ToolStripStatusLabel3"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(68, 17)
        Me.ToolStripStatusLabel4.Text = "ToolStripStatusLabel4"
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1028, 637)
        Me.Controls.Add(Me.MenuStripMain)
        Me.Controls.Add(Me.StatusStripMain)
        Me.MainMenuStrip = Me.MenuStripMain
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

End Class