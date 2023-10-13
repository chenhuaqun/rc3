<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmKhzyxx
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.rcDataGridView = New System.Windows.Forms.DataGridView()
        Me.ColZydm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColZymc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColKhdm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColKhmc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColKsPeriod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColJsPeriod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColXslbdm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColXslbmc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LblXslbmc = New System.Windows.Forms.Label()
        Me.LblXslbdm = New System.Windows.Forms.Label()
        Me.TxtXslbdm = New System.Windows.Forms.TextBox()
        Me.CmbJsPeriod = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmbKsPeriod = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtKhdm = New System.Windows.Forms.TextBox()
        Me.LblKhdm = New System.Windows.Forms.Label()
        Me.LblKhmc = New System.Windows.Forms.Label()
        Me.LblZymc = New System.Windows.Forms.Label()
        Me.TxtZydm = New System.Windows.Forms.TextBox()
        Me.LblZydm = New System.Windows.Forms.Label()
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.MenuStripMain = New System.Windows.Forms.MenuStrip()
        Me.MnuiFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuiExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.BtnNew = New System.Windows.Forms.ToolStripButton()
        Me.BtnEdit = New System.Windows.Forms.ToolStripButton()
        Me.BtnSave = New System.Windows.Forms.ToolStripButton()
        Me.BtnCancel = New System.Windows.Forms.ToolStripButton()
        Me.BtnDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnExit = New System.Windows.Forms.ToolStripButton()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.MenuStripMain.SuspendLayout()
        Me.ToolStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'rcDataGridView
        '
        Me.rcDataGridView.AllowUserToAddRows = False
        Me.rcDataGridView.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.rcDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.rcDataGridView.ColumnHeadersHeight = 30
        Me.rcDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColZydm, Me.ColZymc, Me.ColKhdm, Me.ColKhmc, Me.ColKsPeriod, Me.ColJsPeriod, Me.ColXslbdm, Me.ColXslbmc})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.rcDataGridView.DefaultCellStyle = DataGridViewCellStyle2
        Me.rcDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rcDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.rcDataGridView.Name = "rcDataGridView"
        Me.rcDataGridView.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.rcDataGridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.rcDataGridView.RowHeadersWidth = 62
        Me.rcDataGridView.RowTemplate.Height = 30
        Me.rcDataGridView.Size = New System.Drawing.Size(420, 369)
        Me.rcDataGridView.TabIndex = 0
        '
        'ColZydm
        '
        Me.ColZydm.DataPropertyName = "zydm"
        Me.ColZydm.HeaderText = "职员编码"
        Me.ColZydm.MinimumWidth = 8
        Me.ColZydm.Name = "ColZydm"
        Me.ColZydm.ReadOnly = True
        Me.ColZydm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColZydm.Width = 150
        '
        'ColZymc
        '
        Me.ColZymc.DataPropertyName = "zymc"
        Me.ColZymc.HeaderText = "职员姓名"
        Me.ColZymc.MinimumWidth = 8
        Me.ColZymc.Name = "ColZymc"
        Me.ColZymc.ReadOnly = True
        Me.ColZymc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColZymc.Width = 150
        '
        'ColKhdm
        '
        Me.ColKhdm.DataPropertyName = "khdm"
        Me.ColKhdm.HeaderText = "客户编码"
        Me.ColKhdm.MinimumWidth = 8
        Me.ColKhdm.Name = "ColKhdm"
        Me.ColKhdm.ReadOnly = True
        Me.ColKhdm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColKhdm.Width = 150
        '
        'ColKhmc
        '
        Me.ColKhmc.DataPropertyName = "khmc"
        Me.ColKhmc.HeaderText = "客户名称"
        Me.ColKhmc.MinimumWidth = 8
        Me.ColKhmc.Name = "ColKhmc"
        Me.ColKhmc.ReadOnly = True
        Me.ColKhmc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColKhmc.Width = 150
        '
        'ColKsPeriod
        '
        Me.ColKsPeriod.DataPropertyName = "ksperiod"
        Me.ColKsPeriod.HeaderText = "开始会计期间"
        Me.ColKsPeriod.MinimumWidth = 8
        Me.ColKsPeriod.Name = "ColKsPeriod"
        Me.ColKsPeriod.ReadOnly = True
        Me.ColKsPeriod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColKsPeriod.Width = 150
        '
        'ColJsPeriod
        '
        Me.ColJsPeriod.DataPropertyName = "jsperiod"
        Me.ColJsPeriod.HeaderText = "结束会计期间"
        Me.ColJsPeriod.MinimumWidth = 8
        Me.ColJsPeriod.Name = "ColJsPeriod"
        Me.ColJsPeriod.ReadOnly = True
        Me.ColJsPeriod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColJsPeriod.Width = 150
        '
        'ColXslbdm
        '
        Me.ColXslbdm.DataPropertyName = "xslbdm"
        Me.ColXslbdm.HeaderText = "销售类别编码"
        Me.ColXslbdm.MinimumWidth = 8
        Me.ColXslbdm.Name = "ColXslbdm"
        Me.ColXslbdm.ReadOnly = True
        Me.ColXslbdm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColXslbdm.Width = 150
        '
        'ColXslbmc
        '
        Me.ColXslbmc.DataPropertyName = "xslbmc"
        Me.ColXslbmc.HeaderText = "销售类别名称"
        Me.ColXslbmc.MinimumWidth = 8
        Me.ColXslbmc.Name = "ColXslbmc"
        Me.ColXslbmc.ReadOnly = True
        Me.ColXslbmc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColXslbmc.Width = 150
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LblXslbmc)
        Me.Panel1.Controls.Add(Me.LblXslbdm)
        Me.Panel1.Controls.Add(Me.TxtXslbdm)
        Me.Panel1.Controls.Add(Me.CmbJsPeriod)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.CmbKsPeriod)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TxtKhdm)
        Me.Panel1.Controls.Add(Me.LblKhdm)
        Me.Panel1.Controls.Add(Me.LblKhmc)
        Me.Panel1.Controls.Add(Me.LblZymc)
        Me.Panel1.Controls.Add(Me.TxtZydm)
        Me.Panel1.Controls.Add(Me.LblZydm)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(420, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(380, 369)
        Me.Panel1.TabIndex = 1
        '
        'LblXslbmc
        '
        Me.LblXslbmc.AutoSize = True
        Me.LblXslbmc.Location = New System.Drawing.Point(141, 308)
        Me.LblXslbmc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblXslbmc.Name = "LblXslbmc"
        Me.LblXslbmc.Size = New System.Drawing.Size(0, 18)
        Me.LblXslbmc.TabIndex = 58
        '
        'LblXslbdm
        '
        Me.LblXslbdm.AutoSize = True
        Me.LblXslbdm.Location = New System.Drawing.Point(35, 269)
        Me.LblXslbdm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblXslbdm.Name = "LblXslbdm"
        Me.LblXslbdm.Size = New System.Drawing.Size(134, 18)
        Me.LblXslbdm.TabIndex = 56
        Me.LblXslbdm.Text = "客户销售类别："
        '
        'TxtXslbdm
        '
        Me.TxtXslbdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtXslbdm.Enabled = False
        Me.TxtXslbdm.Location = New System.Drawing.Point(177, 264)
        Me.TxtXslbdm.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtXslbdm.MaxLength = 12
        Me.TxtXslbdm.Name = "TxtXslbdm"
        Me.TxtXslbdm.Size = New System.Drawing.Size(128, 28)
        Me.TxtXslbdm.TabIndex = 57
        '
        'CmbJsPeriod
        '
        Me.CmbJsPeriod.Enabled = False
        Me.CmbJsPeriod.FormattingEnabled = True
        Me.CmbJsPeriod.Location = New System.Drawing.Point(177, 222)
        Me.CmbJsPeriod.Name = "CmbJsPeriod"
        Me.CmbJsPeriod.Size = New System.Drawing.Size(121, 26)
        Me.CmbJsPeriod.TabIndex = 55
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 226)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 18)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "结束会计期间："
        '
        'CmbKsPeriod
        '
        Me.CmbKsPeriod.Enabled = False
        Me.CmbKsPeriod.FormattingEnabled = True
        Me.CmbKsPeriod.Location = New System.Drawing.Point(177, 180)
        Me.CmbKsPeriod.Name = "CmbKsPeriod"
        Me.CmbKsPeriod.Size = New System.Drawing.Size(121, 26)
        Me.CmbKsPeriod.TabIndex = 53
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 184)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 18)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "开始会计期间："
        '
        'TxtKhdm
        '
        Me.TxtKhdm.Enabled = False
        Me.TxtKhdm.Location = New System.Drawing.Point(141, 102)
        Me.TxtKhdm.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtKhdm.MaxLength = 12
        Me.TxtKhdm.Name = "TxtKhdm"
        Me.TxtKhdm.Size = New System.Drawing.Size(128, 28)
        Me.TxtKhdm.TabIndex = 50
        '
        'LblKhdm
        '
        Me.LblKhdm.AutoSize = True
        Me.LblKhdm.Location = New System.Drawing.Point(35, 107)
        Me.LblKhdm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblKhdm.Name = "LblKhdm"
        Me.LblKhdm.Size = New System.Drawing.Size(98, 18)
        Me.LblKhdm.TabIndex = 49
        Me.LblKhdm.Text = "客户编码："
        '
        'LblKhmc
        '
        Me.LblKhmc.AutoSize = True
        Me.LblKhmc.Location = New System.Drawing.Point(141, 146)
        Me.LblKhmc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblKhmc.Name = "LblKhmc"
        Me.LblKhmc.Size = New System.Drawing.Size(0, 18)
        Me.LblKhmc.TabIndex = 51
        '
        'LblZymc
        '
        Me.LblZymc.AutoSize = True
        Me.LblZymc.Location = New System.Drawing.Point(141, 68)
        Me.LblZymc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblZymc.Name = "LblZymc"
        Me.LblZymc.Size = New System.Drawing.Size(0, 18)
        Me.LblZymc.TabIndex = 48
        '
        'TxtZydm
        '
        Me.TxtZydm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtZydm.Enabled = False
        Me.TxtZydm.Location = New System.Drawing.Point(141, 24)
        Me.TxtZydm.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtZydm.MaxLength = 12
        Me.TxtZydm.Name = "TxtZydm"
        Me.TxtZydm.Size = New System.Drawing.Size(128, 28)
        Me.TxtZydm.TabIndex = 46
        '
        'LblZydm
        '
        Me.LblZydm.AutoSize = True
        Me.LblZydm.Location = New System.Drawing.Point(35, 29)
        Me.LblZydm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblZydm.Name = "LblZydm"
        Me.LblZydm.Size = New System.Drawing.Size(98, 18)
        Me.LblZydm.TabIndex = 45
        Me.LblZydm.Text = "职员编码："
        '
        'ToolStripContainer1
        '
        Me.ToolStripContainer1.BottomToolStripPanelVisible = False
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.AutoScroll = True
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.rcDataGridView)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Panel1)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(800, 369)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.LeftToolStripPanelVisible = False
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.RightToolStripPanelVisible = False
        Me.ToolStripContainer1.Size = New System.Drawing.Size(800, 450)
        Me.ToolStripContainer1.TabIndex = 56
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.MenuStripMain)
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStripMain)
        '
        'MenuStripMain
        '
        Me.MenuStripMain.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStripMain.GripMargin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.MenuStripMain.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiFile, Me.MnuiHelp})
        Me.MenuStripMain.Location = New System.Drawing.Point(0, 0)
        Me.MenuStripMain.Name = "MenuStripMain"
        Me.MenuStripMain.Size = New System.Drawing.Size(800, 36)
        Me.MenuStripMain.TabIndex = 0
        Me.MenuStripMain.Text = "MenuStrip1"
        '
        'MnuiFile
        '
        Me.MnuiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiNew, Me.MnuiEdit, Me.MnuiSave, Me.MnuiCancel, Me.MnuiDelete, Me.ToolStripMenuItem1, Me.MnuiExit})
        Me.MnuiFile.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiFile.Name = "MnuiFile"
        Me.MnuiFile.Size = New System.Drawing.Size(84, 30)
        Me.MnuiFile.Text = "文件(&F)"
        '
        'MnuiNew
        '
        Me.MnuiNew.Name = "MnuiNew"
        Me.MnuiNew.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.MnuiNew.Size = New System.Drawing.Size(245, 34)
        Me.MnuiNew.Text = "新增(&N)"
        '
        'MnuiEdit
        '
        Me.MnuiEdit.Name = "MnuiEdit"
        Me.MnuiEdit.Size = New System.Drawing.Size(245, 34)
        Me.MnuiEdit.Text = "修改(&E)"
        '
        'MnuiSave
        '
        Me.MnuiSave.Enabled = False
        Me.MnuiSave.Name = "MnuiSave"
        Me.MnuiSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.MnuiSave.Size = New System.Drawing.Size(245, 34)
        Me.MnuiSave.Text = "保存(&S)"
        '
        'MnuiCancel
        '
        Me.MnuiCancel.Enabled = False
        Me.MnuiCancel.Name = "MnuiCancel"
        Me.MnuiCancel.Size = New System.Drawing.Size(245, 34)
        Me.MnuiCancel.Text = "取消(&C)"
        '
        'MnuiDelete
        '
        Me.MnuiDelete.Name = "MnuiDelete"
        Me.MnuiDelete.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.MnuiDelete.Size = New System.Drawing.Size(245, 34)
        Me.MnuiDelete.Text = "删除(&D)"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(242, 6)
        '
        'MnuiExit
        '
        Me.MnuiExit.Name = "MnuiExit"
        Me.MnuiExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.MnuiExit.Size = New System.Drawing.Size(245, 34)
        Me.MnuiExit.Text = "退出(&X)"
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
        Me.ToolStripMain.ImageScalingSize = New System.Drawing.Size(36, 36)
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnNew, Me.BtnEdit, Me.BtnSave, Me.BtnCancel, Me.BtnDelete, Me.ToolStripSeparator1, Me.BtnExit})
        Me.ToolStripMain.Location = New System.Drawing.Point(4, 36)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(402, 45)
        Me.ToolStripMain.TabIndex = 1
        '
        'BtnNew
        '
        Me.BtnNew.Image = Global.rc3.My.Resources.Resources.ImgNew
        Me.BtnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(86, 40)
        Me.BtnNew.Text = "新增"
        '
        'BtnEdit
        '
        Me.BtnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnEdit.Image = Global.rc3.My.Resources.Resources.ImgEdit
        Me.BtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(40, 40)
        Me.BtnEdit.Text = "编辑"
        '
        'BtnSave
        '
        Me.BtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnSave.Enabled = False
        Me.BtnSave.Image = Global.rc3.My.Resources.Resources.ImgSave
        Me.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(40, 40)
        Me.BtnSave.Text = "保存"
        '
        'BtnCancel
        '
        Me.BtnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnCancel.Enabled = False
        Me.BtnCancel.Image = Global.rc3.My.Resources.Resources.ImgCancel
        Me.BtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(40, 40)
        Me.BtnCancel.Text = "取消"
        '
        'BtnDelete
        '
        Me.BtnDelete.Image = Global.rc3.My.Resources.Resources.ImgDelete
        Me.BtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(86, 40)
        Me.BtnDelete.Text = "删除"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 45)
        '
        'BtnExit
        '
        Me.BtnExit.Image = Global.rc3.My.Resources.Resources.ImgExit
        Me.BtnExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(86, 40)
        Me.BtnExit.Text = "退出"
        '
        'FrmKhzyxx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.MainMenuStrip = Me.MenuStripMain
        Me.Name = "FrmKhzyxx"
        Me.Text = "客户专管理业务员设置"
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.MenuStripMain.ResumeLayout(False)
        Me.MenuStripMain.PerformLayout()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rcDataGridView As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LblZymc As Label
    Friend WithEvents TxtZydm As TextBox
    Friend WithEvents LblZydm As Label
    Friend WithEvents CmbJsPeriod As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CmbKsPeriod As ComboBox
    Friend WithEvents Label1 As Label
    Public WithEvents TxtKhdm As TextBox
    Public WithEvents LblKhdm As Label
    Public WithEvents LblKhmc As Label
    Friend WithEvents ToolStripContainer1 As ToolStripContainer
    Friend WithEvents MenuStripMain As MenuStrip
    Friend WithEvents MnuiFile As ToolStripMenuItem
    Friend WithEvents MnuiHelp As ToolStripMenuItem
    Friend WithEvents ToolStripMain As ToolStrip
    Friend WithEvents BtnNew As ToolStripButton
    Friend WithEvents BtnDelete As ToolStripButton
    Friend WithEvents MnuiNew As ToolStripMenuItem
    Friend WithEvents MnuiExit As ToolStripMenuItem
    Friend WithEvents MnuiDelete As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents BtnEdit As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BtnExit As ToolStripButton
    Friend WithEvents MnuiEdit As ToolStripMenuItem
    Friend WithEvents MnuiSave As ToolStripMenuItem
    Friend WithEvents MnuiCancel As ToolStripMenuItem
    Friend WithEvents BtnSave As ToolStripButton
    Friend WithEvents BtnCancel As ToolStripButton
    Friend WithEvents MnuiAbout As ToolStripMenuItem
    Friend WithEvents LblXslbdm As Label
    Friend WithEvents TxtXslbdm As TextBox
    Friend WithEvents LblXslbmc As Label
    Friend WithEvents ColZydm As DataGridViewTextBoxColumn
    Friend WithEvents ColZymc As DataGridViewTextBoxColumn
    Friend WithEvents ColKhdm As DataGridViewTextBoxColumn
    Friend WithEvents ColKhmc As DataGridViewTextBoxColumn
    Friend WithEvents ColKsPeriod As DataGridViewTextBoxColumn
    Friend WithEvents ColJsPeriod As DataGridViewTextBoxColumn
    Friend WithEvents ColXslbdm As DataGridViewTextBoxColumn
    Friend WithEvents ColXslbmc As DataGridViewTextBoxColumn
End Class
