<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBom
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
        Me.components = New System.ComponentModel.Container()
        Me.ToolStripPanel1 = New System.Windows.Forms.ToolStripPanel()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.BtnPageSetup = New System.Windows.Forms.ToolStripButton()
        Me.BtnPrint = New System.Windows.Forms.ToolStripButton()
        Me.BtnPreview = New System.Windows.Forms.ToolStripButton()
        Me.BtnExport = New System.Windows.Forms.ToolStripButton()
        Me.Tss1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnNew = New System.Windows.Forms.ToolStripButton()
        Me.BtnSave = New System.Windows.Forms.ToolStripButton()
        Me.BtnCopy = New System.Windows.Forms.ToolStripButton()
        Me.BtnDelete = New System.Windows.Forms.ToolStripButton()
        Me.BtnInsRow = New System.Windows.Forms.ToolStripButton()
        Me.BtnDelRow = New System.Windows.Forms.ToolStripButton()
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
        Me.MnuiSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiInsRow = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiDelRow = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiImpXls = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItem11 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuiExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.NudZjcb = New System.Windows.Forms.NumericUpDown()
        Me.LblZjcb = New System.Windows.Forms.Label()
        Me.NudNycb = New System.Windows.Forms.NumericUpDown()
        Me.LblNycb = New System.Windows.Forms.Label()
        Me.NudBeiShu = New System.Windows.Forms.NumericUpDown()
        Me.LblBeiShu = New System.Windows.Forms.Label()
        Me.NudChengPinLv = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NudGlcb = New System.Windows.Forms.NumericUpDown()
        Me.LblGlcb = New System.Windows.Forms.Label()
        Me.NudRgcb = New System.Windows.Forms.NumericUpDown()
        Me.NudClcb = New System.Windows.Forms.NumericUpDown()
        Me.NudBzcb = New System.Windows.Forms.NumericUpDown()
        Me.LblRgcb = New System.Windows.Forms.Label()
        Me.LblClcb = New System.Windows.Forms.Label()
        Me.LblBzcb = New System.Windows.Forms.Label()
        Me.TxtParentDw = New System.Windows.Forms.TextBox()
        Me.LblDw = New System.Windows.Forms.Label()
        Me.TxtParentCpmc = New System.Windows.Forms.TextBox()
        Me.LblCpmc = New System.Windows.Forms.Label()
        Me.TxtParentCpdm = New System.Windows.Forms.TextBox()
        Me.LblCpdm = New System.Windows.Forms.Label()
        Me.rcDataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ColChildCpdm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColChildCpmc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColChildDw = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColJe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColBomMemo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rcBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.rcDataGridView2 = New System.Windows.Forms.DataGridView()
        Me.ColXh = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColGxdm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColGxmc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColBmdm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColBmmc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColGongShi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColXiShu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRgcb = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.rcBindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.ToolStripPanel1.SuspendLayout()
        Me.ToolStripMain.SuspendLayout()
        Me.MnuMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.NudZjcb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudNycb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudBeiShu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudChengPinLv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudGlcb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudRgcb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudClcb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudBzcb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcDataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcDataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.rcBindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripPanel1
        '
        Me.ToolStripPanel1.Controls.Add(Me.ToolStripMain)
        Me.ToolStripPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ToolStripPanel1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStripPanel1.Name = "ToolStripPanel1"
        Me.ToolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.ToolStripPanel1.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ToolStripPanel1.Size = New System.Drawing.Size(856, 39)
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripMain.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnPageSetup, Me.BtnPrint, Me.BtnPreview, Me.BtnExport, Me.Tss1, Me.BtnNew, Me.BtnSave, Me.BtnCopy, Me.BtnDelete, Me.BtnInsRow, Me.BtnDelRow, Me.Tss2, Me.BtnExit})
        Me.ToolStripMain.Location = New System.Drawing.Point(3, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(668, 39)
        Me.ToolStripMain.TabIndex = 8
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
        'BtnSave
        '
        Me.BtnSave.Image = Global.rc3.My.Resources.Resources.ImgSave
        Me.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(68, 36)
        Me.BtnSave.Text = "保存"
        '
        'BtnCopy
        '
        Me.BtnCopy.Image = Global.rc3.My.Resources.Resources.ImgCopy
        Me.BtnCopy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCopy.Name = "BtnCopy"
        Me.BtnCopy.Size = New System.Drawing.Size(68, 36)
        Me.BtnCopy.Text = "复制"
        '
        'BtnDelete
        '
        Me.BtnDelete.Image = Global.rc3.My.Resources.Resources.ImgDelete
        Me.BtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(68, 36)
        Me.BtnDelete.Text = "删除"
        '
        'BtnInsRow
        '
        Me.BtnInsRow.Image = Global.rc3.My.Resources.Resources.ImgEdit
        Me.BtnInsRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnInsRow.Name = "BtnInsRow"
        Me.BtnInsRow.Size = New System.Drawing.Size(80, 36)
        Me.BtnInsRow.Text = "插入行"
        '
        'BtnDelRow
        '
        Me.BtnDelRow.Image = Global.rc3.My.Resources.Resources.ImgDelRow
        Me.BtnDelRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDelRow.Name = "BtnDelRow"
        Me.BtnDelRow.Size = New System.Drawing.Size(80, 36)
        Me.BtnDelRow.Text = "删除行"
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
        Me.MnuMain.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiFile, Me.MnuiHelp})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Padding = New System.Windows.Forms.Padding(4, 1, 0, 1)
        Me.MnuMain.Size = New System.Drawing.Size(856, 24)
        Me.MnuMain.TabIndex = 0
        '
        'MnuiFile
        '
        Me.MnuiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiPageSetup, Me.MnuiPreview, Me.MnuiPrint, Me.MnuiExport, Me.Tss3, Me.MnuiNew, Me.MnuiSave, Me.MnuiCopy, Me.MnuiDelete, Me.MnuiInsRow, Me.MnuiDelRow, Me.MnuiImpXls, Me.MenuItem11, Me.MnuiExit})
        Me.MnuiFile.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiFile.Name = "MnuiFile"
        Me.MnuiFile.Size = New System.Drawing.Size(58, 22)
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
        Me.MnuiNew.Text = "新增(&N)"
        '
        'MnuiSave
        '
        Me.MnuiSave.Name = "MnuiSave"
        Me.MnuiSave.Size = New System.Drawing.Size(189, 22)
        Me.MnuiSave.Text = "保存(&S)"
        '
        'MnuiCopy
        '
        Me.MnuiCopy.Name = "MnuiCopy"
        Me.MnuiCopy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.MnuiCopy.Size = New System.Drawing.Size(189, 22)
        Me.MnuiCopy.Text = "复制(&C)"
        Me.MnuiCopy.ToolTipText = "复制"
        '
        'MnuiDelete
        '
        Me.MnuiDelete.Name = "MnuiDelete"
        Me.MnuiDelete.Size = New System.Drawing.Size(189, 22)
        Me.MnuiDelete.Text = "删除(&D)"
        '
        'MnuiInsRow
        '
        Me.MnuiInsRow.Name = "MnuiInsRow"
        Me.MnuiInsRow.Size = New System.Drawing.Size(189, 22)
        Me.MnuiInsRow.Text = "插入行"
        '
        'MnuiDelRow
        '
        Me.MnuiDelRow.Name = "MnuiDelRow"
        Me.MnuiDelRow.Size = New System.Drawing.Size(189, 22)
        Me.MnuiDelRow.Text = "删除行"
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
        Me.MnuiHelp.Size = New System.Drawing.Size(61, 22)
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
        Me.Panel1.Controls.Add(Me.NudZjcb)
        Me.Panel1.Controls.Add(Me.LblZjcb)
        Me.Panel1.Controls.Add(Me.NudNycb)
        Me.Panel1.Controls.Add(Me.LblNycb)
        Me.Panel1.Controls.Add(Me.NudBeiShu)
        Me.Panel1.Controls.Add(Me.LblBeiShu)
        Me.Panel1.Controls.Add(Me.NudChengPinLv)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.NudGlcb)
        Me.Panel1.Controls.Add(Me.LblGlcb)
        Me.Panel1.Controls.Add(Me.NudRgcb)
        Me.Panel1.Controls.Add(Me.NudClcb)
        Me.Panel1.Controls.Add(Me.NudBzcb)
        Me.Panel1.Controls.Add(Me.LblRgcb)
        Me.Panel1.Controls.Add(Me.LblClcb)
        Me.Panel1.Controls.Add(Me.LblBzcb)
        Me.Panel1.Controls.Add(Me.TxtParentDw)
        Me.Panel1.Controls.Add(Me.LblDw)
        Me.Panel1.Controls.Add(Me.TxtParentCpmc)
        Me.Panel1.Controls.Add(Me.LblCpmc)
        Me.Panel1.Controls.Add(Me.TxtParentCpdm)
        Me.Panel1.Controls.Add(Me.LblCpdm)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 63)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(856, 118)
        Me.Panel1.TabIndex = 1
        '
        'NudZjcb
        '
        Me.NudZjcb.DecimalPlaces = 4
        Me.NudZjcb.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NudZjcb.Location = New System.Drawing.Point(633, 75)
        Me.NudZjcb.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 131072})
        Me.NudZjcb.Name = "NudZjcb"
        Me.NudZjcb.Size = New System.Drawing.Size(86, 21)
        Me.NudZjcb.TabIndex = 19
        Me.NudZjcb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblZjcb
        '
        Me.LblZjcb.AutoSize = True
        Me.LblZjcb.Location = New System.Drawing.Point(560, 79)
        Me.LblZjcb.Name = "LblZjcb"
        Me.LblZjcb.Size = New System.Drawing.Size(65, 12)
        Me.LblZjcb.TabIndex = 18
        Me.LblZjcb.Text = "折旧成本："
        '
        'NudNycb
        '
        Me.NudNycb.DecimalPlaces = 4
        Me.NudNycb.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NudNycb.Location = New System.Drawing.Point(466, 75)
        Me.NudNycb.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 131072})
        Me.NudNycb.Name = "NudNycb"
        Me.NudNycb.Size = New System.Drawing.Size(86, 21)
        Me.NudNycb.TabIndex = 17
        Me.NudNycb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblNycb
        '
        Me.LblNycb.AutoSize = True
        Me.LblNycb.Location = New System.Drawing.Point(393, 79)
        Me.LblNycb.Name = "LblNycb"
        Me.LblNycb.Size = New System.Drawing.Size(65, 12)
        Me.LblNycb.TabIndex = 16
        Me.LblNycb.Text = "能源成本："
        '
        'NudBeiShu
        '
        Me.NudBeiShu.Location = New System.Drawing.Point(275, 46)
        Me.NudBeiShu.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.NudBeiShu.Name = "NudBeiShu"
        Me.NudBeiShu.Size = New System.Drawing.Size(86, 21)
        Me.NudBeiShu.TabIndex = 9
        Me.NudBeiShu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblBeiShu
        '
        Me.LblBeiShu.AutoSize = True
        Me.LblBeiShu.Location = New System.Drawing.Point(234, 50)
        Me.LblBeiShu.Name = "LblBeiShu"
        Me.LblBeiShu.Size = New System.Drawing.Size(41, 12)
        Me.LblBeiShu.TabIndex = 8
        Me.LblBeiShu.Text = "倍数："
        '
        'NudChengPinLv
        '
        Me.NudChengPinLv.DecimalPlaces = 2
        Me.NudChengPinLv.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NudChengPinLv.Location = New System.Drawing.Point(466, 46)
        Me.NudChengPinLv.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 131072})
        Me.NudChengPinLv.Name = "NudChengPinLv"
        Me.NudChengPinLv.Size = New System.Drawing.Size(86, 21)
        Me.NudChengPinLv.TabIndex = 11
        Me.NudChengPinLv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(393, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "成 品 率："
        '
        'NudGlcb
        '
        Me.NudGlcb.DecimalPlaces = 4
        Me.NudGlcb.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NudGlcb.Location = New System.Drawing.Point(800, 75)
        Me.NudGlcb.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 131072})
        Me.NudGlcb.Name = "NudGlcb"
        Me.NudGlcb.Size = New System.Drawing.Size(86, 21)
        Me.NudGlcb.TabIndex = 21
        Me.NudGlcb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblGlcb
        '
        Me.LblGlcb.AutoSize = True
        Me.LblGlcb.Location = New System.Drawing.Point(727, 79)
        Me.LblGlcb.Name = "LblGlcb"
        Me.LblGlcb.Size = New System.Drawing.Size(65, 12)
        Me.LblGlcb.TabIndex = 20
        Me.LblGlcb.Text = "管理成本："
        '
        'NudRgcb
        '
        Me.NudRgcb.DecimalPlaces = 4
        Me.NudRgcb.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NudRgcb.Location = New System.Drawing.Point(299, 75)
        Me.NudRgcb.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 131072})
        Me.NudRgcb.Name = "NudRgcb"
        Me.NudRgcb.Size = New System.Drawing.Size(86, 21)
        Me.NudRgcb.TabIndex = 15
        Me.NudRgcb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NudClcb
        '
        Me.NudClcb.DecimalPlaces = 4
        Me.NudClcb.Enabled = False
        Me.NudClcb.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NudClcb.Location = New System.Drawing.Point(132, 75)
        Me.NudClcb.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 131072})
        Me.NudClcb.Name = "NudClcb"
        Me.NudClcb.Size = New System.Drawing.Size(86, 21)
        Me.NudClcb.TabIndex = 13
        Me.NudClcb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NudBzcb
        '
        Me.NudBzcb.DecimalPlaces = 4
        Me.NudBzcb.Enabled = False
        Me.NudBzcb.Location = New System.Drawing.Point(132, 46)
        Me.NudBzcb.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 131072})
        Me.NudBzcb.Name = "NudBzcb"
        Me.NudBzcb.Size = New System.Drawing.Size(87, 21)
        Me.NudBzcb.TabIndex = 7
        Me.NudBzcb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblRgcb
        '
        Me.LblRgcb.AutoSize = True
        Me.LblRgcb.Location = New System.Drawing.Point(226, 79)
        Me.LblRgcb.Name = "LblRgcb"
        Me.LblRgcb.Size = New System.Drawing.Size(65, 12)
        Me.LblRgcb.TabIndex = 14
        Me.LblRgcb.Text = "人工成本："
        '
        'LblClcb
        '
        Me.LblClcb.AutoSize = True
        Me.LblClcb.Location = New System.Drawing.Point(59, 79)
        Me.LblClcb.Name = "LblClcb"
        Me.LblClcb.Size = New System.Drawing.Size(65, 12)
        Me.LblClcb.TabIndex = 12
        Me.LblClcb.Text = "材料成本："
        '
        'LblBzcb
        '
        Me.LblBzcb.AutoSize = True
        Me.LblBzcb.Location = New System.Drawing.Point(35, 50)
        Me.LblBzcb.Name = "LblBzcb"
        Me.LblBzcb.Size = New System.Drawing.Size(89, 12)
        Me.LblBzcb.TabIndex = 6
        Me.LblBzcb.Text = "单位标准成本："
        '
        'TxtParentDw
        '
        Me.TxtParentDw.Enabled = False
        Me.TxtParentDw.Location = New System.Drawing.Point(644, 19)
        Me.TxtParentDw.MaxLength = 8
        Me.TxtParentDw.Name = "TxtParentDw"
        Me.TxtParentDw.Size = New System.Drawing.Size(96, 21)
        Me.TxtParentDw.TabIndex = 5
        '
        'LblDw
        '
        Me.LblDw.AutoSize = True
        Me.LblDw.Location = New System.Drawing.Point(579, 23)
        Me.LblDw.Name = "LblDw"
        Me.LblDw.Size = New System.Drawing.Size(65, 12)
        Me.LblDw.TabIndex = 4
        Me.LblDw.Text = "计量单位："
        '
        'TxtParentCpmc
        '
        Me.TxtParentCpmc.Enabled = False
        Me.TxtParentCpmc.Location = New System.Drawing.Point(320, 19)
        Me.TxtParentCpmc.MaxLength = 15
        Me.TxtParentCpmc.Name = "TxtParentCpmc"
        Me.TxtParentCpmc.Size = New System.Drawing.Size(253, 21)
        Me.TxtParentCpmc.TabIndex = 3
        '
        'LblCpmc
        '
        Me.LblCpmc.AutoSize = True
        Me.LblCpmc.Location = New System.Drawing.Point(226, 22)
        Me.LblCpmc.Name = "LblCpmc"
        Me.LblCpmc.Size = New System.Drawing.Size(89, 12)
        Me.LblCpmc.TabIndex = 2
        Me.LblCpmc.Text = "父项物料描述："
        '
        'TxtParentCpdm
        '
        Me.TxtParentCpdm.Location = New System.Drawing.Point(130, 19)
        Me.TxtParentCpdm.MaxLength = 15
        Me.TxtParentCpdm.Name = "TxtParentCpdm"
        Me.TxtParentCpdm.Size = New System.Drawing.Size(87, 21)
        Me.TxtParentCpdm.TabIndex = 1
        '
        'LblCpdm
        '
        Me.LblCpdm.AutoSize = True
        Me.LblCpdm.Location = New System.Drawing.Point(35, 22)
        Me.LblCpdm.Name = "LblCpdm"
        Me.LblCpdm.Size = New System.Drawing.Size(89, 12)
        Me.LblCpdm.TabIndex = 0
        Me.LblCpdm.Text = "父项物料编码："
        '
        'rcDataGridView1
        '
        Me.rcDataGridView1.ColumnHeadersHeight = 30
        Me.rcDataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColChildCpdm, Me.ColChildCpmc, Me.ColChildDw, Me.ColSl, Me.ColDj, Me.ColJe, Me.ColBomMemo})
        Me.rcDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rcDataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.rcDataGridView1.Name = "rcDataGridView1"
        Me.rcDataGridView1.RowHeadersWidth = 62
        Me.rcDataGridView1.RowTemplate.Height = 23
        Me.rcDataGridView1.Size = New System.Drawing.Size(842, 254)
        Me.rcDataGridView1.TabIndex = 0
        '
        'ColChildCpdm
        '
        Me.ColChildCpdm.DataPropertyName = "childcpdm"
        Me.ColChildCpdm.HeaderText = "子项物料编码"
        Me.ColChildCpdm.MinimumWidth = 8
        Me.ColChildCpdm.Name = "ColChildCpdm"
        Me.ColChildCpdm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColChildCpdm.Width = 85
        '
        'ColChildCpmc
        '
        Me.ColChildCpmc.DataPropertyName = "childcpmc"
        Me.ColChildCpmc.HeaderText = "子项物料描述"
        Me.ColChildCpmc.MinimumWidth = 8
        Me.ColChildCpmc.Name = "ColChildCpmc"
        Me.ColChildCpmc.ReadOnly = True
        Me.ColChildCpmc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColChildCpmc.Width = 150
        '
        'ColChildDw
        '
        Me.ColChildDw.DataPropertyName = "childdw"
        Me.ColChildDw.HeaderText = "单位"
        Me.ColChildDw.MinimumWidth = 8
        Me.ColChildDw.Name = "ColChildDw"
        Me.ColChildDw.ReadOnly = True
        Me.ColChildDw.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColChildDw.Width = 45
        '
        'ColSl
        '
        Me.ColSl.DataPropertyName = "sl"
        Me.ColSl.HeaderText = "数量"
        Me.ColSl.MinimumWidth = 8
        Me.ColSl.Name = "ColSl"
        Me.ColSl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColSl.Width = 90
        '
        'ColDj
        '
        Me.ColDj.DataPropertyName = "dj"
        Me.ColDj.HeaderText = "最新采购单价"
        Me.ColDj.MinimumWidth = 8
        Me.ColDj.Name = "ColDj"
        Me.ColDj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColDj.Width = 150
        '
        'ColJe
        '
        Me.ColJe.DataPropertyName = "je"
        Me.ColJe.HeaderText = "金额"
        Me.ColJe.MinimumWidth = 8
        Me.ColJe.Name = "ColJe"
        Me.ColJe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColJe.Width = 150
        '
        'ColBomMemo
        '
        Me.ColBomMemo.DataPropertyName = "bommemo"
        Me.ColBomMemo.HeaderText = "备注"
        Me.ColBomMemo.MinimumWidth = 8
        Me.ColBomMemo.Name = "ColBomMemo"
        Me.ColBomMemo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColBomMemo.Width = 120
        '
        'rcDataGridView2
        '
        Me.rcDataGridView2.ColumnHeadersHeight = 30
        Me.rcDataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColXh, Me.ColGxdm, Me.ColGxmc, Me.ColBmdm, Me.ColBmmc, Me.ColGongShi, Me.ColXiShu, Me.ColRgcb})
        Me.rcDataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rcDataGridView2.Location = New System.Drawing.Point(3, 3)
        Me.rcDataGridView2.Name = "rcDataGridView2"
        Me.rcDataGridView2.RowHeadersWidth = 62
        Me.rcDataGridView2.RowTemplate.Height = 23
        Me.rcDataGridView2.Size = New System.Drawing.Size(970, 355)
        Me.rcDataGridView2.TabIndex = 0
        '
        'ColXh
        '
        Me.ColXh.DataPropertyName = "xh"
        Me.ColXh.HeaderText = "工序顺序"
        Me.ColXh.MinimumWidth = 8
        Me.ColXh.Name = "ColXh"
        Me.ColXh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColXh.Width = 80
        '
        'ColGxdm
        '
        Me.ColGxdm.DataPropertyName = "gxdm"
        Me.ColGxdm.HeaderText = "工序编码"
        Me.ColGxdm.MaxInputLength = 12
        Me.ColGxdm.MinimumWidth = 8
        Me.ColGxdm.Name = "ColGxdm"
        Me.ColGxdm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColGxdm.Width = 80
        '
        'ColGxmc
        '
        Me.ColGxmc.DataPropertyName = "gxmc"
        Me.ColGxmc.HeaderText = "工序名称"
        Me.ColGxmc.MinimumWidth = 8
        Me.ColGxmc.Name = "ColGxmc"
        Me.ColGxmc.ReadOnly = True
        Me.ColGxmc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColGxmc.Width = 150
        '
        'ColBmdm
        '
        Me.ColBmdm.DataPropertyName = "bmdm"
        Me.ColBmdm.HeaderText = "部门编码"
        Me.ColBmdm.MaxInputLength = 12
        Me.ColBmdm.MinimumWidth = 8
        Me.ColBmdm.Name = "ColBmdm"
        Me.ColBmdm.ReadOnly = True
        Me.ColBmdm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColBmdm.Width = 80
        '
        'ColBmmc
        '
        Me.ColBmmc.DataPropertyName = "bmmc"
        Me.ColBmmc.HeaderText = "部门名称"
        Me.ColBmmc.MinimumWidth = 8
        Me.ColBmmc.Name = "ColBmmc"
        Me.ColBmmc.ReadOnly = True
        Me.ColBmmc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColBmmc.Width = 150
        '
        'ColGongShi
        '
        Me.ColGongShi.DataPropertyName = "gongshi"
        Me.ColGongShi.HeaderText = "加工工时"
        Me.ColGongShi.MaxInputLength = 18
        Me.ColGongShi.MinimumWidth = 8
        Me.ColGongShi.Name = "ColGongShi"
        Me.ColGongShi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColGongShi.Width = 80
        '
        'ColXiShu
        '
        Me.ColXiShu.DataPropertyName = "xishu"
        Me.ColXiShu.HeaderText = "单位成本"
        Me.ColXiShu.MaxInputLength = 18
        Me.ColXiShu.MinimumWidth = 8
        Me.ColXiShu.Name = "ColXiShu"
        Me.ColXiShu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColXiShu.Width = 80
        '
        'ColRgcb
        '
        Me.ColRgcb.DataPropertyName = "rgcb"
        Me.ColRgcb.HeaderText = "加工成本"
        Me.ColRgcb.MaxInputLength = 14
        Me.ColRgcb.MinimumWidth = 8
        Me.ColRgcb.Name = "ColRgcb"
        Me.ColRgcb.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColRgcb.Width = 80
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 181)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(856, 286)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.rcDataGridView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.TabPage1.Size = New System.Drawing.Size(848, 260)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "子项物料"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.rcDataGridView2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.TabPage2.Size = New System.Drawing.Size(976, 361)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "生产工艺路线"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'FrmBom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(856, 467)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStripPanel1)
        Me.Controls.Add(Me.MnuMain)
        Me.Name = "FrmBom"
        Me.Text = "物料清单维护"
        Me.ToolStripPanel1.ResumeLayout(False)
        Me.ToolStripPanel1.PerformLayout()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.NudZjcb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudNycb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudBeiShu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudChengPinLv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudGlcb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudRgcb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudClcb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudBzcb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.rcBindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents MnuiSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiInsRow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents MnuiExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnPageSetup As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnPreview As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tss1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnInsRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnDelRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tss2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rcDataGridView1 As System.Windows.Forms.DataGridView
    Public WithEvents TxtParentCpmc As System.Windows.Forms.TextBox
    Public WithEvents LblCpmc As System.Windows.Forms.Label
    Public WithEvents TxtParentCpdm As System.Windows.Forms.TextBox
    Public WithEvents LblCpdm As System.Windows.Forms.Label
    Friend WithEvents LblDw As System.Windows.Forms.Label
    Friend WithEvents TxtParentDw As System.Windows.Forms.TextBox
    Friend WithEvents rcBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents MnuiDelRow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnCopy As System.Windows.Forms.ToolStripButton
    Friend WithEvents MnuiCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NudGlcb As System.Windows.Forms.NumericUpDown
    Friend WithEvents LblGlcb As System.Windows.Forms.Label
    Friend WithEvents NudRgcb As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudClcb As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudBzcb As System.Windows.Forms.NumericUpDown
    Friend WithEvents LblRgcb As System.Windows.Forms.Label
    Friend WithEvents LblClcb As System.Windows.Forms.Label
    Public WithEvents LblBzcb As System.Windows.Forms.Label
    Friend WithEvents rcDataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents rcBindingSource2 As System.Windows.Forms.BindingSource
    Friend WithEvents ColChildCpdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColChildCpmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColChildDw As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBomMemo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NudChengPinLv As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ColXh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColGxdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColGxmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBmdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBmmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColGongShi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColXiShu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRgcb As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NudBeiShu As System.Windows.Forms.NumericUpDown
    Friend WithEvents LblBeiShu As System.Windows.Forms.Label
    Friend WithEvents NudZjcb As System.Windows.Forms.NumericUpDown
    Friend WithEvents LblZjcb As System.Windows.Forms.Label
    Friend WithEvents NudNycb As System.Windows.Forms.NumericUpDown
    Friend WithEvents LblNycb As System.Windows.Forms.Label
    Friend WithEvents MnuiImpXls As System.Windows.Forms.ToolStripMenuItem
End Class
