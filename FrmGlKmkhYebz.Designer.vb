<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGlKmkhYebz
    Inherits System.Windows.Forms.Form

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
        Me.ToolStripPanel1 = New System.Windows.Forms.ToolStripPanel
        Me.MenuStripMain = New System.Windows.Forms.MenuStrip
        Me.文件FToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiPageSetup = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiPrint = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiPreview = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiExport = New System.Windows.Forms.ToolStripMenuItem
        Me.Tss4 = New System.Windows.Forms.ToolStripSeparator
        Me.MnuiExit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiHelp = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip
        Me.BtnPageSetup = New System.Windows.Forms.ToolStripButton
        Me.BtnPrint = New System.Windows.Forms.ToolStripButton
        Me.BtnPreview = New System.Windows.Forms.ToolStripButton
        Me.BtnExport = New System.Windows.Forms.ToolStripButton
        Me.Tss1 = New System.Windows.Forms.ToolStripSeparator
        Me.BtnExit = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.ColKmdm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColKmmc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColKhdm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColKhmc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColQcjf = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColQcdf = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColBqjf = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColBqdf = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColQmjf = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColQmdf = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColLjjf = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColLjdf = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStripPanel1.SuspendLayout()
        Me.MenuStripMain.SuspendLayout()
        Me.ToolStripMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripPanel1
        '
        Me.ToolStripPanel1.Controls.Add(Me.MenuStripMain)
        Me.ToolStripPanel1.Controls.Add(Me.ToolStripMain)
        Me.ToolStripPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ToolStripPanel1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripPanel1.Name = "ToolStripPanel1"
        Me.ToolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.ToolStripPanel1.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ToolStripPanel1.Size = New System.Drawing.Size(984, 64)
        '
        'MenuStripMain
        '
        Me.MenuStripMain.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.文件FToolStripMenuItem, Me.MnuiHelp})
        Me.MenuStripMain.Location = New System.Drawing.Point(0, 0)
        Me.MenuStripMain.Name = "MenuStripMain"
        Me.MenuStripMain.Size = New System.Drawing.Size(984, 25)
        Me.MenuStripMain.TabIndex = 0
        Me.MenuStripMain.Text = "MenuStripMain"
        '
        '文件FToolStripMenuItem
        '
        Me.文件FToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiPageSetup, Me.MnuiPrint, Me.MnuiPreview, Me.MnuiExport, Me.Tss4, Me.MnuiExit})
        Me.文件FToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem"
        Me.文件FToolStripMenuItem.Size = New System.Drawing.Size(58, 21)
        Me.文件FToolStripMenuItem.Text = "文件(&F)"
        '
        'MnuiPageSetup
        '
        Me.MnuiPageSetup.Name = "MnuiPageSetup"
        Me.MnuiPageSetup.Size = New System.Drawing.Size(159, 22)
        Me.MnuiPageSetup.Text = "页面设置(&U)"
        '
        'MnuiPrint
        '
        Me.MnuiPrint.Name = "MnuiPrint"
        Me.MnuiPrint.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.MnuiPrint.Size = New System.Drawing.Size(159, 22)
        Me.MnuiPrint.Text = "打印(&P)"
        '
        'MnuiPreview
        '
        Me.MnuiPreview.Name = "MnuiPreview"
        Me.MnuiPreview.Size = New System.Drawing.Size(159, 22)
        Me.MnuiPreview.Text = "打印预览(&V)"
        '
        'MnuiExport
        '
        Me.MnuiExport.Name = "MnuiExport"
        Me.MnuiExport.Size = New System.Drawing.Size(159, 22)
        Me.MnuiExport.Text = "输出(&A)"
        '
        'Tss4
        '
        Me.Tss4.Name = "Tss4"
        Me.Tss4.Size = New System.Drawing.Size(156, 6)
        '
        'MnuiExit
        '
        Me.MnuiExit.Name = "MnuiExit"
        Me.MnuiExit.Size = New System.Drawing.Size(159, 22)
        Me.MnuiExit.Text = "关闭(&C)"
        '
        'MnuiHelp
        '
        Me.MnuiHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiAbout})
        Me.MnuiHelp.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiHelp.Name = "MnuiHelp"
        Me.MnuiHelp.Size = New System.Drawing.Size(61, 21)
        Me.MnuiHelp.Text = "帮助(&H)"
        '
        'MnuiAbout
        '
        Me.MnuiAbout.Name = "MnuiAbout"
        Me.MnuiAbout.Size = New System.Drawing.Size(116, 22)
        Me.MnuiAbout.Text = "关于(&A)"
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripMain.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnPageSetup, Me.BtnPrint, Me.BtnPreview, Me.BtnExport, Me.Tss1, Me.BtnExit})
        Me.ToolStripMain.Location = New System.Drawing.Point(3, 25)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(230, 39)
        Me.ToolStripMain.TabIndex = 5
        '
        'BtnPageSetup
        '
        Me.BtnPageSetup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPageSetup.Image = Global.rc3.My.Resources.Resources.ImgPageSetup
        Me.BtnPageSetup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPageSetup.Name = "BtnPageSetup"
        Me.BtnPageSetup.Size = New System.Drawing.Size(36, 36)
        Me.BtnPageSetup.Text = "页面设置"
        '
        'BtnPrint
        '
        Me.BtnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrint.Image = Global.rc3.My.Resources.Resources.ImgPrint
        Me.BtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(36, 36)
        Me.BtnPrint.Text = "打印"
        '
        'BtnPreview
        '
        Me.BtnPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPreview.Image = Global.rc3.My.Resources.Resources.ImgPreview
        Me.BtnPreview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPreview.Name = "BtnPreview"
        Me.BtnPreview.Size = New System.Drawing.Size(36, 36)
        Me.BtnPreview.Text = "预览"
        '
        'BtnExport
        '
        Me.BtnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnExport.Image = Global.rc3.My.Resources.Resources.ImgExport
        Me.BtnExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnExport.Name = "BtnExport"
        Me.BtnExport.Size = New System.Drawing.Size(36, 36)
        Me.BtnExport.Text = "输出"
        '
        'Tss1
        '
        Me.Tss1.Name = "Tss1"
        Me.Tss1.Size = New System.Drawing.Size(6, 39)
        '
        'BtnExit
        '
        Me.BtnExit.Image = Global.rc3.My.Resources.Resources.ImgExit
        Me.BtnExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(68, 36)
        Me.BtnExit.Text = "关闭"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FloralWhite
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 64)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(984, 48)
        Me.Panel1.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("楷体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label1.Location = New System.Drawing.Point(375, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(235, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "科目客户余额汇总表"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColKmdm, Me.ColKmmc, Me.ColKhdm, Me.ColKhmc, Me.ColQcjf, Me.ColQcdf, Me.ColBqjf, Me.ColBqdf, Me.ColQmjf, Me.ColQmdf, Me.ColLjjf, Me.ColLjdf})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 112)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(984, 449)
        Me.DataGridView1.TabIndex = 6
        '
        'ColKmdm
        '
        Me.ColKmdm.DataPropertyName = "kmdm"
        Me.ColKmdm.HeaderText = "科目编码"
        Me.ColKmdm.Name = "ColKmdm"
        Me.ColKmdm.ReadOnly = True
        '
        'ColKmmc
        '
        Me.ColKmmc.DataPropertyName = "kmmc"
        Me.ColKmmc.HeaderText = "科目名称"
        Me.ColKmmc.Name = "ColKmmc"
        Me.ColKmmc.ReadOnly = True
        Me.ColKmmc.Width = 150
        '
        'ColKhdm
        '
        Me.ColKhdm.DataPropertyName = "khdm"
        Me.ColKhdm.HeaderText = "客户编码"
        Me.ColKhdm.Name = "ColKhdm"
        Me.ColKhdm.ReadOnly = True
        '
        'ColKhmc
        '
        Me.ColKhmc.DataPropertyName = "khmc"
        Me.ColKhmc.HeaderText = "客户名称"
        Me.ColKhmc.Name = "ColKhmc"
        Me.ColKhmc.ReadOnly = True
        Me.ColKhmc.Width = 150
        '
        'ColQcjf
        '
        Me.ColQcjf.DataPropertyName = "qcjf"
        Me.ColQcjf.HeaderText = "期初借方余额"
        Me.ColQcjf.Name = "ColQcjf"
        Me.ColQcjf.ReadOnly = True
        Me.ColQcjf.Width = 120
        '
        'ColQcdf
        '
        Me.ColQcdf.DataPropertyName = "qcdf"
        Me.ColQcdf.HeaderText = "期初贷方余额"
        Me.ColQcdf.Name = "ColQcdf"
        Me.ColQcdf.ReadOnly = True
        Me.ColQcdf.Width = 120
        '
        'ColBqjf
        '
        Me.ColBqjf.DataPropertyName = "bqjf"
        Me.ColBqjf.HeaderText = "本期借方发生额"
        Me.ColBqjf.Name = "ColBqjf"
        Me.ColBqjf.ReadOnly = True
        Me.ColBqjf.Width = 120
        '
        'ColBqdf
        '
        Me.ColBqdf.DataPropertyName = "bqdf"
        Me.ColBqdf.HeaderText = "本期贷方发生额"
        Me.ColBqdf.Name = "ColBqdf"
        Me.ColBqdf.ReadOnly = True
        Me.ColBqdf.Width = 120
        '
        'ColQmjf
        '
        Me.ColQmjf.DataPropertyName = "qmjf"
        Me.ColQmjf.HeaderText = "期末借方余额"
        Me.ColQmjf.Name = "ColQmjf"
        Me.ColQmjf.ReadOnly = True
        Me.ColQmjf.Width = 120
        '
        'ColQmdf
        '
        Me.ColQmdf.DataPropertyName = "qmdf"
        Me.ColQmdf.HeaderText = "期末贷方余额"
        Me.ColQmdf.Name = "ColQmdf"
        Me.ColQmdf.ReadOnly = True
        Me.ColQmdf.Width = 120
        '
        'ColLjjf
        '
        Me.ColLjjf.DataPropertyName = "ljjf"
        Me.ColLjjf.HeaderText = "本年借方累计发生额"
        Me.ColLjjf.Name = "ColLjjf"
        Me.ColLjjf.ReadOnly = True
        Me.ColLjjf.Width = 120
        '
        'ColLjdf
        '
        Me.ColLjdf.DataPropertyName = "ljdf"
        Me.ColLjdf.HeaderText = "本年贷方累计发生额"
        Me.ColLjdf.Name = "ColLjdf"
        Me.ColLjdf.ReadOnly = True
        Me.ColLjdf.Width = 120
        '
        'FrmGlKmkhYebz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStripPanel1)
        Me.MainMenuStrip = Me.MenuStripMain
        Me.Name = "FrmGlKmkhYebz"
        Me.Text = "科目客户余额汇总表"
        Me.ToolStripPanel1.ResumeLayout(False)
        Me.ToolStripPanel1.PerformLayout()
        Me.MenuStripMain.ResumeLayout(False)
        Me.MenuStripMain.PerformLayout()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripPanel1 As System.Windows.Forms.ToolStripPanel
    Friend WithEvents MenuStripMain As System.Windows.Forms.MenuStrip
    Friend WithEvents 文件FToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnPageSetup As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnPreview As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tss1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents MnuiHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiPageSetup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiPreview As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tss4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuiExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColKmdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKmmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKhdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKhmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColQcjf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColQcdf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBqjf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBqdf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColQmjf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColQmdf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLjjf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLjdf As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
