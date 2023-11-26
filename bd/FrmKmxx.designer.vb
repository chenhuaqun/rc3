<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmKmxx
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmKmxx))
        Me.ToolStripPanel1 = New System.Windows.Forms.ToolStripPanel()
        Me.MenuStripMain = New System.Windows.Forms.MenuStrip()
        Me.MnuiFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiPageSetup = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiPreview = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tss3 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuiNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tss4 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuiExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiAbout = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.BtnSearch = New System.Windows.Forms.ToolStripButton()
        Me.Tss2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnExit = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.rcDataGridView = New System.Windows.Forms.DataGridView()
        Me.ColBmdm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColBmmc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColBmsm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColParentId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColKmxz = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColKmgs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColKmbz = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColKmdw = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColKmbm = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColKmzy = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColKmxm = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColKmkh = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColKmcs = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColKmjx = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColKmyh = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColKmxj = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ToolStripPanel1.SuspendLayout()
        Me.MenuStripMain.SuspendLayout()
        Me.ToolStripMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripPanel1
        '
        Me.ToolStripPanel1.Controls.Add(Me.ToolStripMain)
        Me.ToolStripPanel1.Controls.Add(Me.MenuStripMain)
        Me.ToolStripPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ToolStripPanel1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripPanel1.Name = "ToolStripPanel1"
        Me.ToolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.ToolStripPanel1.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ToolStripPanel1.Size = New System.Drawing.Size(1476, 73)
        '
        'MenuStripMain
        '
        Me.MenuStripMain.GripMargin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.MenuStripMain.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiFile, Me.MnuiHelp})
        Me.MenuStripMain.Location = New System.Drawing.Point(0, 0)
        Me.MenuStripMain.Name = "MenuStripMain"
        Me.MenuStripMain.Size = New System.Drawing.Size(1476, 32)
        Me.MenuStripMain.TabIndex = 3
        Me.MenuStripMain.Text = "MenuStripMain"
        '
        'MnuiFile
        '
        Me.MnuiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiPageSetup, Me.MnuiPrint, Me.MnuiPreview, Me.MnuiExport, Me.Tss3, Me.MnuiNew, Me.MnuiEdit, Me.MnuiDelete, Me.MnuiRefresh, Me.MnuiSearch, Me.Tss4, Me.MnuiExit})
        Me.MnuiFile.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiFile.Name = "MnuiFile"
        Me.MnuiFile.Size = New System.Drawing.Size(84, 30)
        Me.MnuiFile.Text = "文件(&F)"
        '
        'MnuiPageSetup
        '
        Me.MnuiPageSetup.Name = "MnuiPageSetup"
        Me.MnuiPageSetup.Size = New System.Drawing.Size(270, 34)
        Me.MnuiPageSetup.Text = "页面设置"
        '
        'MnuiPrint
        '
        Me.MnuiPrint.Name = "MnuiPrint"
        Me.MnuiPrint.Size = New System.Drawing.Size(270, 34)
        Me.MnuiPrint.Text = "打印"
        '
        'MnuiPreview
        '
        Me.MnuiPreview.Name = "MnuiPreview"
        Me.MnuiPreview.Size = New System.Drawing.Size(270, 34)
        Me.MnuiPreview.Text = "打印预览"
        '
        'MnuiExport
        '
        Me.MnuiExport.Name = "MnuiExport"
        Me.MnuiExport.Size = New System.Drawing.Size(270, 34)
        Me.MnuiExport.Text = "输出"
        '
        'Tss3
        '
        Me.Tss3.Name = "Tss3"
        Me.Tss3.Size = New System.Drawing.Size(267, 6)
        '
        'MnuiNew
        '
        Me.MnuiNew.Name = "MnuiNew"
        Me.MnuiNew.Size = New System.Drawing.Size(270, 34)
        Me.MnuiNew.Text = "新增"
        '
        'MnuiEdit
        '
        Me.MnuiEdit.Name = "MnuiEdit"
        Me.MnuiEdit.Size = New System.Drawing.Size(270, 34)
        Me.MnuiEdit.Text = "修改"
        '
        'MnuiDelete
        '
        Me.MnuiDelete.Name = "MnuiDelete"
        Me.MnuiDelete.Size = New System.Drawing.Size(270, 34)
        Me.MnuiDelete.Text = "删除"
        '
        'MnuiRefresh
        '
        Me.MnuiRefresh.Name = "MnuiRefresh"
        Me.MnuiRefresh.Size = New System.Drawing.Size(270, 34)
        Me.MnuiRefresh.Text = "刷新"
        '
        'MnuiSearch
        '
        Me.MnuiSearch.Name = "MnuiSearch"
        Me.MnuiSearch.Size = New System.Drawing.Size(270, 34)
        Me.MnuiSearch.Text = "查找"
        '
        'Tss4
        '
        Me.Tss4.Name = "Tss4"
        Me.Tss4.Size = New System.Drawing.Size(267, 6)
        '
        'MnuiExit
        '
        Me.MnuiExit.Name = "MnuiExit"
        Me.MnuiExit.Size = New System.Drawing.Size(270, 34)
        Me.MnuiExit.Text = "关闭(&C)"
        '
        'MnuiHelp
        '
        Me.MnuiHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiAbout})
        Me.MnuiHelp.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiHelp.Name = "MnuiHelp"
        Me.MnuiHelp.Size = New System.Drawing.Size(88, 30)
        Me.MnuiHelp.Text = "帮助(&H)"
        '
        'MnuiAbout
        '
        Me.MnuiAbout.Name = "MnuiAbout"
        Me.MnuiAbout.Size = New System.Drawing.Size(171, 34)
        Me.MnuiAbout.Text = "关于(&A)"
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripMain.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnPageSetup, Me.BtnPrint, Me.BtnPreview, Me.BtnExport, Me.Tss1, Me.BtnNew, Me.BtnEdit, Me.BtnDelete, Me.BtnRefresh, Me.BtnSearch, Me.Tss2, Me.BtnExit})
        Me.ToolStripMain.Location = New System.Drawing.Point(3, 32)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(538, 41)
        Me.ToolStripMain.TabIndex = 4
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
        Me.Tss1.Size = New System.Drawing.Size(6, 41)
        '
        'BtnNew
        '
        Me.BtnNew.Image = Global.rc3.My.Resources.Resources.ImgNew
        Me.BtnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(82, 36)
        Me.BtnNew.Text = "新增"
        '
        'BtnEdit
        '
        Me.BtnEdit.Image = Global.rc3.My.Resources.Resources.ImgEdit
        Me.BtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(82, 36)
        Me.BtnEdit.Text = "修改"
        '
        'BtnDelete
        '
        Me.BtnDelete.Image = Global.rc3.My.Resources.Resources.ImgDelete
        Me.BtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(82, 36)
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
        'BtnSearch
        '
        Me.BtnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnSearch.Image = Global.rc3.My.Resources.Resources.ImgSearch
        Me.BtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(36, 36)
        Me.BtnSearch.Text = "查找"
        Me.BtnSearch.Visible = False
        '
        'Tss2
        '
        Me.Tss2.Name = "Tss2"
        Me.Tss2.Size = New System.Drawing.Size(6, 41)
        '
        'BtnExit
        '
        Me.BtnExit.Image = Global.rc3.My.Resources.Resources.ImgExit
        Me.BtnExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(82, 36)
        Me.BtnExit.Text = "关闭"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FloralWhite
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 73)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1476, 72)
        Me.Panel1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("楷体", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label1.Location = New System.Drawing.Point(638, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "科目设置"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FloralWhite
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(1320, 145)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(156, 697)
        Me.Panel3.TabIndex = 6
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(24, 72)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
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
        Me.rcDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColBmdm, Me.ColBmmc, Me.ColBmsm, Me.ColParentId, Me.ColKmxz, Me.ColKmgs, Me.ColKmbz, Me.ColKmdw, Me.ColKmbm, Me.ColKmzy, Me.ColKmxm, Me.ColKmkh, Me.ColKmcs, Me.ColKmjx, Me.ColKmyh, Me.ColKmxj})
        Me.rcDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rcDataGridView.Location = New System.Drawing.Point(0, 145)
        Me.rcDataGridView.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rcDataGridView.Name = "rcDataGridView"
        Me.rcDataGridView.ReadOnly = True
        Me.rcDataGridView.RowHeadersWidth = 62
        Me.rcDataGridView.RowTemplate.Height = 23
        Me.rcDataGridView.Size = New System.Drawing.Size(1320, 697)
        Me.rcDataGridView.TabIndex = 7
        '
        'ColBmdm
        '
        Me.ColBmdm.DataPropertyName = "kmdm"
        Me.ColBmdm.HeaderText = "科目编码"
        Me.ColBmdm.MaxInputLength = 12
        Me.ColBmdm.MinimumWidth = 8
        Me.ColBmdm.Name = "ColBmdm"
        Me.ColBmdm.ReadOnly = True
        Me.ColBmdm.Width = 150
        '
        'ColBmmc
        '
        Me.ColBmmc.DataPropertyName = "kmmc"
        Me.ColBmmc.HeaderText = "科目名称"
        Me.ColBmmc.MaxInputLength = 50
        Me.ColBmmc.MinimumWidth = 8
        Me.ColBmmc.Name = "ColBmmc"
        Me.ColBmmc.ReadOnly = True
        Me.ColBmmc.Width = 200
        '
        'ColBmsm
        '
        Me.ColBmsm.DataPropertyName = "kmsm"
        Me.ColBmsm.HeaderText = "记忆码"
        Me.ColBmsm.MaxInputLength = 12
        Me.ColBmsm.MinimumWidth = 8
        Me.ColBmsm.Name = "ColBmsm"
        Me.ColBmsm.ReadOnly = True
        Me.ColBmsm.Width = 150
        '
        'ColParentId
        '
        Me.ColParentId.DataPropertyName = "parentid"
        Me.ColParentId.HeaderText = "上级科目"
        Me.ColParentId.MaxInputLength = 12
        Me.ColParentId.MinimumWidth = 8
        Me.ColParentId.Name = "ColParentId"
        Me.ColParentId.ReadOnly = True
        Me.ColParentId.Width = 150
        '
        'ColKmxz
        '
        Me.ColKmxz.DataPropertyName = "kmxz"
        Me.ColKmxz.HeaderText = "科目性质"
        Me.ColKmxz.MinimumWidth = 8
        Me.ColKmxz.Name = "ColKmxz"
        Me.ColKmxz.ReadOnly = True
        Me.ColKmxz.Width = 75
        '
        'ColKmgs
        '
        Me.ColKmgs.DataPropertyName = "kmgs"
        Me.ColKmgs.HeaderText = "账簿格式"
        Me.ColKmgs.MinimumWidth = 8
        Me.ColKmgs.Name = "ColKmgs"
        Me.ColKmgs.ReadOnly = True
        Me.ColKmgs.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColKmgs.Width = 75
        '
        'ColKmbz
        '
        Me.ColKmbz.DataPropertyName = "kmbz"
        Me.ColKmbz.HeaderText = "外币币种"
        Me.ColKmbz.MinimumWidth = 8
        Me.ColKmbz.Name = "ColKmbz"
        Me.ColKmbz.ReadOnly = True
        Me.ColKmbz.Width = 75
        '
        'ColKmdw
        '
        Me.ColKmdw.DataPropertyName = "kmdw"
        Me.ColKmdw.HeaderText = "计量单位"
        Me.ColKmdw.MinimumWidth = 8
        Me.ColKmdw.Name = "ColKmdw"
        Me.ColKmdw.ReadOnly = True
        Me.ColKmdw.Width = 75
        '
        'ColKmbm
        '
        Me.ColKmbm.DataPropertyName = "kmbm"
        Me.ColKmbm.HeaderText = "部门核算"
        Me.ColKmbm.MinimumWidth = 8
        Me.ColKmbm.Name = "ColKmbm"
        Me.ColKmbm.ReadOnly = True
        Me.ColKmbm.Width = 75
        '
        'ColKmzy
        '
        Me.ColKmzy.DataPropertyName = "kmzy"
        Me.ColKmzy.HeaderText = "职员核算"
        Me.ColKmzy.MinimumWidth = 8
        Me.ColKmzy.Name = "ColKmzy"
        Me.ColKmzy.ReadOnly = True
        Me.ColKmzy.Width = 75
        '
        'ColKmxm
        '
        Me.ColKmxm.DataPropertyName = "kmxm"
        Me.ColKmxm.HeaderText = "项目核算"
        Me.ColKmxm.MinimumWidth = 8
        Me.ColKmxm.Name = "ColKmxm"
        Me.ColKmxm.ReadOnly = True
        Me.ColKmxm.Width = 75
        '
        'ColKmkh
        '
        Me.ColKmkh.DataPropertyName = "kmkh"
        Me.ColKmkh.HeaderText = "客户管理"
        Me.ColKmkh.MinimumWidth = 8
        Me.ColKmkh.Name = "ColKmkh"
        Me.ColKmkh.ReadOnly = True
        Me.ColKmkh.Width = 75
        '
        'ColKmcs
        '
        Me.ColKmcs.DataPropertyName = "kmcs"
        Me.ColKmcs.HeaderText = "供应商管理"
        Me.ColKmcs.MinimumWidth = 8
        Me.ColKmcs.Name = "ColKmcs"
        Me.ColKmcs.ReadOnly = True
        Me.ColKmcs.Width = 75
        '
        'ColKmjx
        '
        Me.ColKmjx.DataPropertyName = "kmjx"
        Me.ColKmjx.HeaderText = "计息管理"
        Me.ColKmjx.MinimumWidth = 8
        Me.ColKmjx.Name = "ColKmjx"
        Me.ColKmjx.ReadOnly = True
        Me.ColKmjx.Width = 75
        '
        'ColKmyh
        '
        Me.ColKmyh.DataPropertyName = "kmyh"
        Me.ColKmyh.HeaderText = "银行对账"
        Me.ColKmyh.MinimumWidth = 8
        Me.ColKmyh.Name = "ColKmyh"
        Me.ColKmyh.ReadOnly = True
        Me.ColKmyh.Width = 75
        '
        'ColKmxj
        '
        Me.ColKmxj.DataPropertyName = "kmxj"
        Me.ColKmxj.HeaderText = "现金流量"
        Me.ColKmxj.MinimumWidth = 8
        Me.ColKmxj.Name = "ColKmxj"
        Me.ColKmxj.ReadOnly = True
        Me.ColKmxj.Width = 75
        '
        'FrmKmxx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1476, 842)
        Me.Controls.Add(Me.rcDataGridView)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStripPanel1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FrmKmxx"
        Me.Text = "科目设置"
        Me.ToolStripPanel1.ResumeLayout(False)
        Me.ToolStripPanel1.PerformLayout()
        Me.MenuStripMain.ResumeLayout(False)
        Me.MenuStripMain.PerformLayout()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
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
    Friend WithEvents MenuStripMain As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuiFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiPageSetup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiPreview As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tss3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuiNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tss4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuiExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnPageSetup As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnPreview As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tss1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tss2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents rcDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ColBmdm As DataGridViewTextBoxColumn
    Friend WithEvents ColBmmc As DataGridViewTextBoxColumn
    Friend WithEvents ColBmsm As DataGridViewTextBoxColumn
    Friend WithEvents ColParentId As DataGridViewTextBoxColumn
    Friend WithEvents ColKmxz As DataGridViewTextBoxColumn
    Friend WithEvents ColKmgs As DataGridViewTextBoxColumn
    Friend WithEvents ColKmbz As DataGridViewTextBoxColumn
    Friend WithEvents ColKmdw As DataGridViewTextBoxColumn
    Friend WithEvents ColKmbm As DataGridViewCheckBoxColumn
    Friend WithEvents ColKmzy As DataGridViewCheckBoxColumn
    Friend WithEvents ColKmxm As DataGridViewCheckBoxColumn
    Friend WithEvents ColKmkh As DataGridViewCheckBoxColumn
    Friend WithEvents ColKmcs As DataGridViewCheckBoxColumn
    Friend WithEvents ColKmjx As DataGridViewCheckBoxColumn
    Friend WithEvents ColKmyh As DataGridViewCheckBoxColumn
    Friend WithEvents ColKmxj As DataGridViewCheckBoxColumn
End Class
