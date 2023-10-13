<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWbxx
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmWbxx))
        Me.ToolStripPanel1 = New System.Windows.Forms.ToolStripPanel()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.BtnPageSetup = New System.Windows.Forms.ToolStripButton()
        Me.BtnPrint = New System.Windows.Forms.ToolStripButton()
        Me.BtnPreview = New System.Windows.Forms.ToolStripButton()
        Me.BtnExport = New System.Windows.Forms.ToolStripButton()
        Me.Tss1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnNew = New System.Windows.Forms.ToolStripButton()
        Me.BtnEdit = New System.Windows.Forms.ToolStripButton()
        Me.BtnDelete = New System.Windows.Forms.ToolStripButton()
        Me.BtnRefresh = New System.Windows.Forms.ToolStripButton()
        Me.Tss2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnExit = New System.Windows.Forms.ToolStripButton()
        Me.MnuMain = New System.Windows.Forms.MenuStrip()
        Me.MnuiFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiPageSetup = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiPreview = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tss3 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuiNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItem11 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuiExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.rcDataGridView = New System.Windows.Forms.DataGridView()
        Me.ColWbdm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColWbmc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColWbsm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColWbhl01 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColWbhl2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColWbhl03 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColWbhl04 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColWbhl05 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColWbhl06 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColWbhl07 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColWbhl08 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColWbhl09 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColWbhl10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColWbhl11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColWbhl12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColYwftzbl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStripPanel1.SuspendLayout()
        Me.ToolStripMain.SuspendLayout()
        Me.MnuMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripPanel1
        '
        Me.ToolStripPanel1.Controls.Add(Me.ToolStripMain)
        Me.ToolStripPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ToolStripPanel1.Location = New System.Drawing.Point(0, 25)
        Me.ToolStripPanel1.Name = "ToolStripPanel1"
        Me.ToolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.ToolStripPanel1.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ToolStripPanel1.Size = New System.Drawing.Size(786, 39)
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripMain.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnPageSetup, Me.BtnPrint, Me.BtnPreview, Me.BtnExport, Me.Tss1, Me.BtnNew, Me.BtnEdit, Me.BtnDelete, Me.BtnRefresh, Me.Tss2, Me.BtnExit})
        Me.ToolStripMain.Location = New System.Drawing.Point(3, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(476, 39)
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
        'BtnNew
        '
        Me.BtnNew.Image = Global.rc3.My.Resources.Resources.ImgNew
        Me.BtnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(68, 36)
        Me.BtnNew.Text = "新增"
        '
        'BtnEdit
        '
        Me.BtnEdit.Image = Global.rc3.My.Resources.Resources.ImgEdit
        Me.BtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(68, 36)
        Me.BtnEdit.Text = "修改"
        '
        'BtnDelete
        '
        Me.BtnDelete.Image = Global.rc3.My.Resources.Resources.ImgDelete
        Me.BtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(68, 36)
        Me.BtnDelete.Text = "删除"
        '
        'BtnRefresh
        '
        Me.BtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnRefresh.Image = Global.rc3.My.Resources.Resources.ImgRefresh
        Me.BtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(36, 36)
        Me.BtnRefresh.Text = "刷新"
        '
        'Tss2
        '
        Me.Tss2.Name = "Tss2"
        Me.Tss2.Size = New System.Drawing.Size(6, 39)
        '
        'BtnExit
        '
        Me.BtnExit.Image = Global.rc3.My.Resources.Resources.ImgExit
        Me.BtnExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(68, 36)
        Me.BtnExit.Text = "关闭"
        '
        'MnuMain
        '
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiFile, Me.MnuiHelp})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(786, 25)
        Me.MnuMain.TabIndex = 6
        '
        'MnuiFile
        '
        Me.MnuiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiPageSetup, Me.MnuiPreview, Me.MnuiPrint, Me.MnuiExport, Me.Tss3, Me.MnuiNew, Me.MnuiEdit, Me.MnuiDelete, Me.MnuiRefresh, Me.MenuItem11, Me.MnuiExit})
        Me.MnuiFile.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiFile.Name = "MnuiFile"
        Me.MnuiFile.Size = New System.Drawing.Size(58, 21)
        Me.MnuiFile.Text = "文件(&F)"
        '
        'MnuiPageSetup
        '
        Me.MnuiPageSetup.Name = "MnuiPageSetup"
        Me.MnuiPageSetup.Size = New System.Drawing.Size(141, 22)
        Me.MnuiPageSetup.Text = "页面设置(&U)"
        '
        'MnuiPreview
        '
        Me.MnuiPreview.Name = "MnuiPreview"
        Me.MnuiPreview.Size = New System.Drawing.Size(141, 22)
        Me.MnuiPreview.Text = "打印预览(&V)"
        '
        'MnuiPrint
        '
        Me.MnuiPrint.Name = "MnuiPrint"
        Me.MnuiPrint.Size = New System.Drawing.Size(141, 22)
        Me.MnuiPrint.Text = "打印(&P)"
        '
        'MnuiExport
        '
        Me.MnuiExport.Name = "MnuiExport"
        Me.MnuiExport.Size = New System.Drawing.Size(141, 22)
        Me.MnuiExport.Text = "输出"
        '
        'Tss3
        '
        Me.Tss3.Name = "Tss3"
        Me.Tss3.Size = New System.Drawing.Size(138, 6)
        '
        'MnuiNew
        '
        Me.MnuiNew.Name = "MnuiNew"
        Me.MnuiNew.Size = New System.Drawing.Size(141, 22)
        Me.MnuiNew.Text = "新增"
        '
        'MnuiEdit
        '
        Me.MnuiEdit.Name = "MnuiEdit"
        Me.MnuiEdit.Size = New System.Drawing.Size(141, 22)
        Me.MnuiEdit.Text = "修改"
        '
        'MnuiDelete
        '
        Me.MnuiDelete.Name = "MnuiDelete"
        Me.MnuiDelete.Size = New System.Drawing.Size(141, 22)
        Me.MnuiDelete.Text = "删除"
        '
        'MnuiRefresh
        '
        Me.MnuiRefresh.Name = "MnuiRefresh"
        Me.MnuiRefresh.Size = New System.Drawing.Size(141, 22)
        Me.MnuiRefresh.Text = "刷新"
        '
        'MenuItem11
        '
        Me.MenuItem11.Name = "MenuItem11"
        Me.MenuItem11.Size = New System.Drawing.Size(138, 6)
        '
        'MnuiExit
        '
        Me.MnuiExit.Name = "MnuiExit"
        Me.MnuiExit.Size = New System.Drawing.Size(141, 22)
        Me.MnuiExit.Text = "退出(&X)"
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FloralWhite
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 64)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(786, 48)
        Me.Panel1.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("楷体", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label1.Location = New System.Drawing.Point(347, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "币种信息"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FloralWhite
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(682, 112)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(104, 365)
        Me.Panel3.TabIndex = 8
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(16, 48)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(80, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'rcDataGridView
        '
        Me.rcDataGridView.AllowUserToAddRows = False
        Me.rcDataGridView.AllowUserToDeleteRows = False
        Me.rcDataGridView.ColumnHeadersHeight = 30
        Me.rcDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColWbdm, Me.ColWbmc, Me.ColWbsm, Me.ColWbhl01, Me.ColWbhl2, Me.ColWbhl03, Me.ColWbhl04, Me.ColWbhl05, Me.ColWbhl06, Me.ColWbhl07, Me.ColWbhl08, Me.ColWbhl09, Me.ColWbhl10, Me.ColWbhl11, Me.ColWbhl12, Me.ColYwftzbl})
        Me.rcDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rcDataGridView.Location = New System.Drawing.Point(0, 112)
        Me.rcDataGridView.Name = "rcDataGridView"
        Me.rcDataGridView.ReadOnly = True
        Me.rcDataGridView.RowTemplate.Height = 23
        Me.rcDataGridView.Size = New System.Drawing.Size(682, 365)
        Me.rcDataGridView.TabIndex = 9
        '
        'ColWbdm
        '
        Me.ColWbdm.DataPropertyName = "wbdm"
        Me.ColWbdm.HeaderText = "币种编码"
        Me.ColWbdm.Name = "ColWbdm"
        Me.ColWbdm.ReadOnly = True
        Me.ColWbdm.Width = 120
        '
        'ColWbmc
        '
        Me.ColWbmc.DataPropertyName = "wbmc"
        Me.ColWbmc.HeaderText = "币种名称"
        Me.ColWbmc.Name = "ColWbmc"
        Me.ColWbmc.ReadOnly = True
        Me.ColWbmc.Width = 200
        '
        'ColWbsm
        '
        Me.ColWbsm.DataPropertyName = "wbsm"
        Me.ColWbsm.HeaderText = "记忆码"
        Me.ColWbsm.Name = "ColWbsm"
        Me.ColWbsm.ReadOnly = True
        Me.ColWbsm.Width = 120
        '
        'ColWbhl01
        '
        Me.ColWbhl01.DataPropertyName = "wbhl01"
        Me.ColWbhl01.HeaderText = "1月份"
        Me.ColWbhl01.MaxInputLength = 12
        Me.ColWbhl01.Name = "ColWbhl01"
        Me.ColWbhl01.ReadOnly = True
        Me.ColWbhl01.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColWbhl2
        '
        Me.ColWbhl2.DataPropertyName = "wbhl02"
        Me.ColWbhl2.HeaderText = "2月份"
        Me.ColWbhl2.Name = "ColWbhl2"
        Me.ColWbhl2.ReadOnly = True
        '
        'ColWbhl03
        '
        Me.ColWbhl03.DataPropertyName = "wbhl03"
        Me.ColWbhl03.HeaderText = "3月份"
        Me.ColWbhl03.Name = "ColWbhl03"
        Me.ColWbhl03.ReadOnly = True
        '
        'ColWbhl04
        '
        Me.ColWbhl04.DataPropertyName = "wbhl04"
        Me.ColWbhl04.HeaderText = "4月份"
        Me.ColWbhl04.Name = "ColWbhl04"
        Me.ColWbhl04.ReadOnly = True
        '
        'ColWbhl05
        '
        Me.ColWbhl05.DataPropertyName = "wbhl05"
        Me.ColWbhl05.HeaderText = "5月份"
        Me.ColWbhl05.Name = "ColWbhl05"
        Me.ColWbhl05.ReadOnly = True
        '
        'ColWbhl06
        '
        Me.ColWbhl06.DataPropertyName = "wbhl06"
        Me.ColWbhl06.HeaderText = "6月份"
        Me.ColWbhl06.Name = "ColWbhl06"
        Me.ColWbhl06.ReadOnly = True
        '
        'ColWbhl07
        '
        Me.ColWbhl07.DataPropertyName = "wbhl07"
        Me.ColWbhl07.HeaderText = "7月份"
        Me.ColWbhl07.Name = "ColWbhl07"
        Me.ColWbhl07.ReadOnly = True
        '
        'ColWbhl08
        '
        Me.ColWbhl08.DataPropertyName = "wbhl08"
        Me.ColWbhl08.HeaderText = "8月份"
        Me.ColWbhl08.Name = "ColWbhl08"
        Me.ColWbhl08.ReadOnly = True
        '
        'ColWbhl09
        '
        Me.ColWbhl09.DataPropertyName = "wbhl09"
        Me.ColWbhl09.HeaderText = "9月份"
        Me.ColWbhl09.Name = "ColWbhl09"
        Me.ColWbhl09.ReadOnly = True
        '
        'ColWbhl10
        '
        Me.ColWbhl10.DataPropertyName = "wbhl10"
        Me.ColWbhl10.HeaderText = "10月份"
        Me.ColWbhl10.Name = "ColWbhl10"
        Me.ColWbhl10.ReadOnly = True
        '
        'ColWbhl11
        '
        Me.ColWbhl11.DataPropertyName = "wbhl11"
        Me.ColWbhl11.HeaderText = "11月份"
        Me.ColWbhl11.Name = "ColWbhl11"
        Me.ColWbhl11.ReadOnly = True
        '
        'ColWbhl12
        '
        Me.ColWbhl12.DataPropertyName = "wbhl12"
        Me.ColWbhl12.HeaderText = "12月份"
        Me.ColWbhl12.Name = "ColWbhl12"
        Me.ColWbhl12.ReadOnly = True
        '
        'ColYwftzbl
        '
        Me.ColYwftzbl.DataPropertyName = "ywftzbl"
        Me.ColYwftzbl.HeaderText = "业务费调整比例"
        Me.ColYwftzbl.MaxInputLength = 6
        Me.ColYwftzbl.Name = "ColYwftzbl"
        Me.ColYwftzbl.ReadOnly = True
        '
        'FrmWbxx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(786, 477)
        Me.Controls.Add(Me.rcDataGridView)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStripPanel1)
        Me.Controls.Add(Me.MnuMain)
        Me.Name = "FrmWbxx"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "币种信息"
        Me.ToolStripPanel1.ResumeLayout(False)
        Me.ToolStripPanel1.PerformLayout()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripPanel1 As System.Windows.Forms.ToolStripPanel
    Friend WithEvents MnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuiFile As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuiPageSetup As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuiPreview As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuiPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tss3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuiNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents MnuiExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnPreview As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tss1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tss2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents rcDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents BtnPageSetup As System.Windows.Forms.ToolStripButton
    Friend WithEvents ColWbdm As DataGridViewTextBoxColumn
    Friend WithEvents ColWbmc As DataGridViewTextBoxColumn
    Friend WithEvents ColWbsm As DataGridViewTextBoxColumn
    Friend WithEvents ColWbhl01 As DataGridViewTextBoxColumn
    Friend WithEvents ColWbhl2 As DataGridViewTextBoxColumn
    Friend WithEvents ColWbhl03 As DataGridViewTextBoxColumn
    Friend WithEvents ColWbhl04 As DataGridViewTextBoxColumn
    Friend WithEvents ColWbhl05 As DataGridViewTextBoxColumn
    Friend WithEvents ColWbhl06 As DataGridViewTextBoxColumn
    Friend WithEvents ColWbhl07 As DataGridViewTextBoxColumn
    Friend WithEvents ColWbhl08 As DataGridViewTextBoxColumn
    Friend WithEvents ColWbhl09 As DataGridViewTextBoxColumn
    Friend WithEvents ColWbhl10 As DataGridViewTextBoxColumn
    Friend WithEvents ColWbhl11 As DataGridViewTextBoxColumn
    Friend WithEvents ColWbhl12 As DataGridViewTextBoxColumn
    Friend WithEvents ColYwftzbl As DataGridViewTextBoxColumn
End Class
