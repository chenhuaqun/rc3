<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCsxx
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCsxx))
        Me.ToolStripPanel1 = New System.Windows.Forms.ToolStripPanel
        Me.MnuMain = New System.Windows.Forms.MenuStrip
        Me.MnuiFile = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiPageSetup = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiPreview = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiPrint = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiExport = New System.Windows.Forms.ToolStripMenuItem
        Me.Tss3 = New System.Windows.Forms.ToolStripSeparator
        Me.MnuiNew = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiRefresh = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiImpXls = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem11 = New System.Windows.Forms.ToolStripSeparator
        Me.MnuiExit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiHelp = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip
        Me.BtnPageSetup = New System.Windows.Forms.ToolStripButton
        Me.BtnPrint = New System.Windows.Forms.ToolStripButton
        Me.BtnPreview = New System.Windows.Forms.ToolStripButton
        Me.BtnExport = New System.Windows.Forms.ToolStripButton
        Me.Tss1 = New System.Windows.Forms.ToolStripSeparator
        Me.BtnNew = New System.Windows.Forms.ToolStripButton
        Me.BtnEdit = New System.Windows.Forms.ToolStripButton
        Me.BtnDelete = New System.Windows.Forms.ToolStripButton
        Me.BtnSearch = New System.Windows.Forms.ToolStripButton
        Me.BtnRefresh = New System.Windows.Forms.ToolStripButton
        Me.Tss2 = New System.Windows.Forms.ToolStripSeparator
        Me.BtnExit = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.rcDataGridView = New System.Windows.Forms.DataGridView
        Me.ColLbdm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColLbmc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColKhdm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColKhmc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColKhsm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColAddress = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColPostCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColWaddress = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColKhyh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColYhzh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColSwdjh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColFddbr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColGsdjh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColZczb = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColJyfw = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColLxr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColMobile = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColTel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColFax = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColEmail = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColZydm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColZymc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColFktj = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColFkts = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStripPanel1.SuspendLayout()
        Me.MnuMain.SuspendLayout()
        Me.ToolStripMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripPanel1
        '
        Me.ToolStripPanel1.Controls.Add(Me.MnuMain)
        Me.ToolStripPanel1.Controls.Add(Me.ToolStripMain)
        Me.ToolStripPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ToolStripPanel1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripPanel1.Name = "ToolStripPanel1"
        Me.ToolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.ToolStripPanel1.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ToolStripPanel1.Size = New System.Drawing.Size(984, 64)
        '
        'MnuMain
        '
        Me.MnuMain.Dock = System.Windows.Forms.DockStyle.None
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiFile, Me.MnuiHelp})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(984, 25)
        Me.MnuMain.TabIndex = 6
        '
        'MnuiFile
        '
        Me.MnuiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiPageSetup, Me.MnuiPreview, Me.MnuiPrint, Me.MnuiExport, Me.Tss3, Me.MnuiNew, Me.MnuiEdit, Me.MnuiDelete, Me.MnuiRefresh, Me.MnuiImpXls, Me.MenuItem11, Me.MnuiExit})
        Me.MnuiFile.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiFile.Name = "MnuiFile"
        Me.MnuiFile.Size = New System.Drawing.Size(58, 21)
        Me.MnuiFile.Text = "文件(&F)"
        '
        'MnuiPageSetup
        '
        Me.MnuiPageSetup.Name = "MnuiPageSetup"
        Me.MnuiPageSetup.Size = New System.Drawing.Size(189, 22)
        Me.MnuiPageSetup.Text = "页面设置(&U)"
        '
        'MnuiPreview
        '
        Me.MnuiPreview.Name = "MnuiPreview"
        Me.MnuiPreview.Size = New System.Drawing.Size(189, 22)
        Me.MnuiPreview.Text = "打印预览(&V)"
        '
        'MnuiPrint
        '
        Me.MnuiPrint.Name = "MnuiPrint"
        Me.MnuiPrint.Size = New System.Drawing.Size(189, 22)
        Me.MnuiPrint.Text = "打印(&P)"
        '
        'MnuiExport
        '
        Me.MnuiExport.Name = "MnuiExport"
        Me.MnuiExport.Size = New System.Drawing.Size(189, 22)
        Me.MnuiExport.Text = "输出"
        '
        'Tss3
        '
        Me.Tss3.Name = "Tss3"
        Me.Tss3.Size = New System.Drawing.Size(186, 6)
        '
        'MnuiNew
        '
        Me.MnuiNew.Name = "MnuiNew"
        Me.MnuiNew.Size = New System.Drawing.Size(189, 22)
        Me.MnuiNew.Text = "新增"
        '
        'MnuiEdit
        '
        Me.MnuiEdit.Name = "MnuiEdit"
        Me.MnuiEdit.Size = New System.Drawing.Size(189, 22)
        Me.MnuiEdit.Text = "修改"
        '
        'MnuiDelete
        '
        Me.MnuiDelete.Name = "MnuiDelete"
        Me.MnuiDelete.Size = New System.Drawing.Size(189, 22)
        Me.MnuiDelete.Text = "删除"
        '
        'MnuiRefresh
        '
        Me.MnuiRefresh.Name = "MnuiRefresh"
        Me.MnuiRefresh.Size = New System.Drawing.Size(189, 22)
        Me.MnuiRefresh.Text = "刷新"
        '
        'MnuiImpXls
        '
        Me.MnuiImpXls.Name = "MnuiImpXls"
        Me.MnuiImpXls.Size = New System.Drawing.Size(189, 22)
        Me.MnuiImpXls.Text = "导入Excel模板数据(&I)"
        '
        'MenuItem11
        '
        Me.MenuItem11.Name = "MenuItem11"
        Me.MenuItem11.Size = New System.Drawing.Size(186, 6)
        '
        'MnuiExit
        '
        Me.MnuiExit.Name = "MnuiExit"
        Me.MnuiExit.Size = New System.Drawing.Size(189, 22)
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
        'ToolStripMain
        '
        Me.ToolStripMain.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripMain.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnPageSetup, Me.BtnPrint, Me.BtnPreview, Me.BtnExport, Me.Tss1, Me.BtnNew, Me.BtnEdit, Me.BtnDelete, Me.BtnSearch, Me.BtnRefresh, Me.Tss2, Me.BtnExit})
        Me.ToolStripMain.Location = New System.Drawing.Point(3, 25)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(544, 39)
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
        'BtnSearch
        '
        Me.BtnSearch.Image = Global.rc3.My.Resources.Resources.ImgSearch
        Me.BtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(68, 36)
        Me.BtnSearch.Text = "查找"
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FloralWhite
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 64)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(984, 48)
        Me.Panel1.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("楷体", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label1.Location = New System.Drawing.Point(435, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "供应商信息"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FloralWhite
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(880, 112)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(104, 449)
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
        Me.rcDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColLbdm, Me.ColLbmc, Me.ColKhdm, Me.ColKhmc, Me.ColKhsm, Me.ColAddress, Me.ColPostCode, Me.ColWaddress, Me.ColKhyh, Me.ColYhzh, Me.ColSwdjh, Me.ColFddbr, Me.ColGsdjh, Me.ColZczb, Me.ColJyfw, Me.ColLxr, Me.ColMobile, Me.ColTel, Me.ColFax, Me.ColEmail, Me.ColZydm, Me.ColZymc, Me.ColFktj, Me.ColFkts})
        Me.rcDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rcDataGridView.Location = New System.Drawing.Point(0, 112)
        Me.rcDataGridView.Name = "rcDataGridView"
        Me.rcDataGridView.ReadOnly = True
        Me.rcDataGridView.RowTemplate.Height = 23
        Me.rcDataGridView.Size = New System.Drawing.Size(880, 449)
        Me.rcDataGridView.TabIndex = 9
        '
        'ColLbdm
        '
        Me.ColLbdm.DataPropertyName = "lbdm"
        Me.ColLbdm.HeaderText = "供应商分类编码"
        Me.ColLbdm.Name = "ColLbdm"
        Me.ColLbdm.ReadOnly = True
        Me.ColLbdm.Width = 60
        '
        'ColLbmc
        '
        Me.ColLbmc.DataPropertyName = "lbmc"
        Me.ColLbmc.HeaderText = "供应商分类名称"
        Me.ColLbmc.Name = "ColLbmc"
        Me.ColLbmc.ReadOnly = True
        '
        'ColKhdm
        '
        Me.ColKhdm.DataPropertyName = "csdm"
        Me.ColKhdm.HeaderText = "供应商编码"
        Me.ColKhdm.Name = "ColKhdm"
        Me.ColKhdm.ReadOnly = True
        Me.ColKhdm.Width = 90
        '
        'ColKhmc
        '
        Me.ColKhmc.DataPropertyName = "csmc"
        Me.ColKhmc.HeaderText = "供应商名称"
        Me.ColKhmc.Name = "ColKhmc"
        Me.ColKhmc.ReadOnly = True
        Me.ColKhmc.Width = 200
        '
        'ColKhsm
        '
        Me.ColKhsm.DataPropertyName = "cssm"
        Me.ColKhsm.HeaderText = "记忆码"
        Me.ColKhsm.Name = "ColKhsm"
        Me.ColKhsm.ReadOnly = True
        Me.ColKhsm.Width = 120
        '
        'ColAddress
        '
        Me.ColAddress.DataPropertyName = "address"
        Me.ColAddress.HeaderText = "地址"
        Me.ColAddress.Name = "ColAddress"
        Me.ColAddress.ReadOnly = True
        Me.ColAddress.Width = 120
        '
        'ColPostCode
        '
        Me.ColPostCode.DataPropertyName = "postcode"
        Me.ColPostCode.HeaderText = "邮政编码"
        Me.ColPostCode.Name = "ColPostCode"
        Me.ColPostCode.ReadOnly = True
        Me.ColPostCode.Width = 60
        '
        'ColWaddress
        '
        Me.ColWaddress.DataPropertyName = "waddress"
        Me.ColWaddress.HeaderText = "网址"
        Me.ColWaddress.Name = "ColWaddress"
        Me.ColWaddress.ReadOnly = True
        Me.ColWaddress.Width = 180
        '
        'ColKhyh
        '
        Me.ColKhyh.DataPropertyName = "khyh"
        Me.ColKhyh.HeaderText = "开户银行"
        Me.ColKhyh.Name = "ColKhyh"
        Me.ColKhyh.ReadOnly = True
        '
        'ColYhzh
        '
        Me.ColYhzh.DataPropertyName = "yhzh"
        Me.ColYhzh.HeaderText = "银行账号"
        Me.ColYhzh.Name = "ColYhzh"
        Me.ColYhzh.ReadOnly = True
        '
        'ColSwdjh
        '
        Me.ColSwdjh.DataPropertyName = "swdjh"
        Me.ColSwdjh.HeaderText = "税务登记号"
        Me.ColSwdjh.Name = "ColSwdjh"
        Me.ColSwdjh.ReadOnly = True
        '
        'ColFddbr
        '
        Me.ColFddbr.DataPropertyName = "fddbr"
        Me.ColFddbr.HeaderText = "法定代表人"
        Me.ColFddbr.Name = "ColFddbr"
        Me.ColFddbr.ReadOnly = True
        '
        'ColGsdjh
        '
        Me.ColGsdjh.DataPropertyName = "gsdjh"
        Me.ColGsdjh.HeaderText = "工商登记号"
        Me.ColGsdjh.Name = "ColGsdjh"
        Me.ColGsdjh.ReadOnly = True
        '
        'ColZczb
        '
        Me.ColZczb.DataPropertyName = "zczb"
        Me.ColZczb.HeaderText = "注册资本"
        Me.ColZczb.Name = "ColZczb"
        Me.ColZczb.ReadOnly = True
        '
        'ColJyfw
        '
        Me.ColJyfw.DataPropertyName = "jyfw"
        Me.ColJyfw.HeaderText = "经营范围"
        Me.ColJyfw.Name = "ColJyfw"
        Me.ColJyfw.ReadOnly = True
        '
        'ColLxr
        '
        Me.ColLxr.DataPropertyName = "lxr"
        Me.ColLxr.HeaderText = "联系人"
        Me.ColLxr.Name = "ColLxr"
        Me.ColLxr.ReadOnly = True
        '
        'ColMobile
        '
        Me.ColMobile.DataPropertyName = "mobile"
        Me.ColMobile.HeaderText = "手机"
        Me.ColMobile.Name = "ColMobile"
        Me.ColMobile.ReadOnly = True
        '
        'ColTel
        '
        Me.ColTel.DataPropertyName = "tel"
        Me.ColTel.HeaderText = "电话"
        Me.ColTel.Name = "ColTel"
        Me.ColTel.ReadOnly = True
        '
        'ColFax
        '
        Me.ColFax.DataPropertyName = "fax"
        Me.ColFax.HeaderText = "传真"
        Me.ColFax.Name = "ColFax"
        Me.ColFax.ReadOnly = True
        '
        'ColEmail
        '
        Me.ColEmail.DataPropertyName = "email"
        Me.ColEmail.HeaderText = "Email"
        Me.ColEmail.Name = "ColEmail"
        Me.ColEmail.ReadOnly = True
        '
        'ColZydm
        '
        Me.ColZydm.DataPropertyName = "zydm"
        Me.ColZydm.HeaderText = "职员编码"
        Me.ColZydm.Name = "ColZydm"
        Me.ColZydm.ReadOnly = True
        '
        'ColZymc
        '
        Me.ColZymc.DataPropertyName = "zymc"
        Me.ColZymc.HeaderText = "职员姓名"
        Me.ColZymc.Name = "ColZymc"
        Me.ColZymc.ReadOnly = True
        '
        'ColFktj
        '
        Me.ColFktj.DataPropertyName = "fktj"
        Me.ColFktj.HeaderText = "付款条件"
        Me.ColFktj.MaxInputLength = 10
        Me.ColFktj.Name = "ColFktj"
        Me.ColFktj.ReadOnly = True
        Me.ColFktj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColFkts
        '
        Me.ColFkts.DataPropertyName = "fkts"
        Me.ColFkts.HeaderText = "付款天数"
        Me.ColFkts.MaxInputLength = 4
        Me.ColFkts.Name = "ColFkts"
        Me.ColFkts.ReadOnly = True
        Me.ColFkts.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'FrmCsxx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.rcDataGridView)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStripPanel1)
        Me.Name = "FrmCsxx"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "供应商信息"
        Me.ToolStripPanel1.ResumeLayout(False)
        Me.ToolStripPanel1.PerformLayout()
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
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
    Friend WithEvents BtnSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents MnuiImpXls As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColLbdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLbmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKhdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKhmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKhsm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColAddress As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPostCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColWaddress As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKhyh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColYhzh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSwdjh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFddbr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColGsdjh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColZczb As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJyfw As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLxr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMobile As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColEmail As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColZydm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColZymc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFktj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFkts As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
