<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPoRkdSrz
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
        Me.MnuMain = New System.Windows.Forms.MenuStrip()
        Me.MnuiFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiWriteOff = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiZf = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mnui11 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuiInsert_Row = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiDelete_Row = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiCopy_Row = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiImpXls = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mnui12 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuiPageSetup = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiPrintView = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mnui13 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuiExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripPanel1 = New System.Windows.Forms.ToolStripPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtYspz = New System.Windows.Forms.TextBox()
        Me.LblYspz = New System.Windows.Forms.Label()
        Me.LblCkmc = New System.Windows.Forms.Label()
        Me.TxtCkdm = New System.Windows.Forms.TextBox()
        Me.LblCkdm = New System.Windows.Forms.Label()
        Me.LblCsmc = New System.Windows.Forms.Label()
        Me.TxtCsdm = New System.Windows.Forms.TextBox()
        Me.LblCsdm = New System.Windows.Forms.Label()
        Me.LblZymc = New System.Windows.Forms.Label()
        Me.TxtZydm = New System.Windows.Forms.TextBox()
        Me.LblZydm = New System.Windows.Forms.Label()
        Me.CmbPzlxjc = New System.Windows.Forms.ComboBox()
        Me.LblRkrq = New System.Windows.Forms.Label()
        Me.DtpRkrq = New System.Windows.Forms.DateTimePicker()
        Me.TxtDjh = New System.Windows.Forms.TextBox()
        Me.LblDjh = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.LblBdelete = New System.Windows.Forms.Label()
        Me.LblRkd = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnCopy_Row = New System.Windows.Forms.Button()
        Me.BtnImp = New System.Windows.Forms.Button()
        Me.BtnInsert_Row = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.LblJese = New System.Windows.Forms.Label()
        Me.LblSe = New System.Windows.Forms.Label()
        Me.LblFzsl = New System.Windows.Forms.Label()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.LblJe = New System.Windows.Forms.Label()
        Me.LblSl = New System.Windows.Forms.Label()
        Me.BtnDelete_Row = New System.Windows.Forms.Button()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.BtnNew = New System.Windows.Forms.Button()
        Me.BtnHelp = New System.Windows.Forms.Button()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.BtnPrintView = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.rcDataGridView = New System.Windows.Forms.DataGridView()
        Me.ColCpdm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOldCpdm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCpmc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColKuwei = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSgddh = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPiHao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDw = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMjsl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFzsl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFzdw = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColHsdj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColJe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColShlv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColJese = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRkmemo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCgdDjh = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCgdXh = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rcBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MnuMain.SuspendLayout()
        Me.ToolStripPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MnuMain
        '
        Me.MnuMain.Dock = System.Windows.Forms.DockStyle.None
        Me.MnuMain.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiFile, Me.MnuiEdit, Me.MnuiHelp})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(984, 25)
        Me.MnuMain.TabIndex = 1
        '
        'MnuiFile
        '
        Me.MnuiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiNew, Me.MnuiSave, Me.MnuiCancel, Me.MnuiWriteOff, Me.MnuiZf, Me.Mnui11, Me.MnuiInsert_Row, Me.MnuiDelete_Row, Me.MnuiCopy_Row, Me.MnuiImpXls, Me.Mnui12, Me.MnuiPageSetup, Me.MnuiPrintView, Me.MnuiPrint, Me.Mnui13, Me.MnuiExit})
        Me.MnuiFile.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiFile.Name = "MnuiFile"
        Me.MnuiFile.Size = New System.Drawing.Size(58, 21)
        Me.MnuiFile.Text = "文件(&F)"
        '
        'MnuiNew
        '
        Me.MnuiNew.Name = "MnuiNew"
        Me.MnuiNew.Size = New System.Drawing.Size(189, 22)
        Me.MnuiNew.Text = "新单(&A)"
        '
        'MnuiSave
        '
        Me.MnuiSave.Enabled = False
        Me.MnuiSave.Name = "MnuiSave"
        Me.MnuiSave.Size = New System.Drawing.Size(189, 22)
        Me.MnuiSave.Text = "保存(&S)"
        '
        'MnuiCancel
        '
        Me.MnuiCancel.Enabled = False
        Me.MnuiCancel.Name = "MnuiCancel"
        Me.MnuiCancel.Size = New System.Drawing.Size(189, 22)
        Me.MnuiCancel.Text = "取消(&Q)"
        '
        'MnuiWriteOff
        '
        Me.MnuiWriteOff.Name = "MnuiWriteOff"
        Me.MnuiWriteOff.Size = New System.Drawing.Size(189, 22)
        Me.MnuiWriteOff.Text = "冲销"
        '
        'MnuiZf
        '
        Me.MnuiZf.Name = "MnuiZf"
        Me.MnuiZf.Size = New System.Drawing.Size(189, 22)
        Me.MnuiZf.Text = "作废/恢复"
        '
        'Mnui11
        '
        Me.Mnui11.Name = "Mnui11"
        Me.Mnui11.Size = New System.Drawing.Size(186, 6)
        '
        'MnuiInsert_Row
        '
        Me.MnuiInsert_Row.Name = "MnuiInsert_Row"
        Me.MnuiInsert_Row.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.MnuiInsert_Row.Size = New System.Drawing.Size(189, 22)
        Me.MnuiInsert_Row.Text = "插入行(&I)"
        '
        'MnuiDelete_Row
        '
        Me.MnuiDelete_Row.Name = "MnuiDelete_Row"
        Me.MnuiDelete_Row.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.MnuiDelete_Row.Size = New System.Drawing.Size(189, 22)
        Me.MnuiDelete_Row.Text = "删除行(&D)"
        '
        'MnuiCopy_Row
        '
        Me.MnuiCopy_Row.Name = "MnuiCopy_Row"
        Me.MnuiCopy_Row.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.MnuiCopy_Row.Size = New System.Drawing.Size(189, 22)
        Me.MnuiCopy_Row.Text = "复制行(&C)"
        '
        'MnuiImpXls
        '
        Me.MnuiImpXls.Name = "MnuiImpXls"
        Me.MnuiImpXls.Size = New System.Drawing.Size(189, 22)
        Me.MnuiImpXls.Text = "导入Excel模板数据(&I)"
        '
        'Mnui12
        '
        Me.Mnui12.Name = "Mnui12"
        Me.Mnui12.Size = New System.Drawing.Size(186, 6)
        '
        'MnuiPageSetup
        '
        Me.MnuiPageSetup.Name = "MnuiPageSetup"
        Me.MnuiPageSetup.Size = New System.Drawing.Size(189, 22)
        Me.MnuiPageSetup.Text = "页面设置(&U)"
        '
        'MnuiPrintView
        '
        Me.MnuiPrintView.Name = "MnuiPrintView"
        Me.MnuiPrintView.Size = New System.Drawing.Size(189, 22)
        Me.MnuiPrintView.Text = "打印预览(&V)"
        '
        'MnuiPrint
        '
        Me.MnuiPrint.Name = "MnuiPrint"
        Me.MnuiPrint.Size = New System.Drawing.Size(189, 22)
        Me.MnuiPrint.Text = "打印(&P)"
        '
        'Mnui13
        '
        Me.Mnui13.Name = "Mnui13"
        Me.Mnui13.Size = New System.Drawing.Size(186, 6)
        '
        'MnuiExit
        '
        Me.MnuiExit.Name = "MnuiExit"
        Me.MnuiExit.Size = New System.Drawing.Size(189, 22)
        Me.MnuiExit.Text = "退出(&X)"
        '
        'MnuiEdit
        '
        Me.MnuiEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiCut, Me.MnuiCopy, Me.MnuiPaste})
        Me.MnuiEdit.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiEdit.Name = "MnuiEdit"
        Me.MnuiEdit.Size = New System.Drawing.Size(59, 21)
        Me.MnuiEdit.Text = "编辑(&E)"
        '
        'MnuiCut
        '
        Me.MnuiCut.Name = "MnuiCut"
        Me.MnuiCut.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.MnuiCut.Size = New System.Drawing.Size(161, 22)
        Me.MnuiCut.Text = "剪切(&T)"
        '
        'MnuiCopy
        '
        Me.MnuiCopy.Name = "MnuiCopy"
        Me.MnuiCopy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.MnuiCopy.Size = New System.Drawing.Size(161, 22)
        Me.MnuiCopy.Text = "复制(&C)"
        '
        'MnuiPaste
        '
        Me.MnuiPaste.Name = "MnuiPaste"
        Me.MnuiPaste.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.MnuiPaste.Size = New System.Drawing.Size(161, 22)
        Me.MnuiPaste.Text = "粘贴(&P)"
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
        'ToolStripPanel1
        '
        Me.ToolStripPanel1.Controls.Add(Me.MnuMain)
        Me.ToolStripPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ToolStripPanel1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripPanel1.Name = "ToolStripPanel1"
        Me.ToolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.ToolStripPanel1.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ToolStripPanel1.Size = New System.Drawing.Size(984, 25)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FloralWhite
        Me.Panel1.Controls.Add(Me.TxtYspz)
        Me.Panel1.Controls.Add(Me.LblYspz)
        Me.Panel1.Controls.Add(Me.LblCkmc)
        Me.Panel1.Controls.Add(Me.TxtCkdm)
        Me.Panel1.Controls.Add(Me.LblCkdm)
        Me.Panel1.Controls.Add(Me.LblCsmc)
        Me.Panel1.Controls.Add(Me.TxtCsdm)
        Me.Panel1.Controls.Add(Me.LblCsdm)
        Me.Panel1.Controls.Add(Me.LblZymc)
        Me.Panel1.Controls.Add(Me.TxtZydm)
        Me.Panel1.Controls.Add(Me.LblZydm)
        Me.Panel1.Controls.Add(Me.CmbPzlxjc)
        Me.Panel1.Controls.Add(Me.LblRkrq)
        Me.Panel1.Controls.Add(Me.DtpRkrq)
        Me.Panel1.Controls.Add(Me.TxtDjh)
        Me.Panel1.Controls.Add(Me.LblDjh)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(984, 112)
        Me.Panel1.TabIndex = 0
        '
        'TxtYspz
        '
        Me.TxtYspz.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtYspz.Location = New System.Drawing.Point(476, 82)
        Me.TxtYspz.MaxLength = 15
        Me.TxtYspz.Name = "TxtYspz"
        Me.TxtYspz.Size = New System.Drawing.Size(87, 21)
        Me.TxtYspz.TabIndex = 12
        '
        'LblYspz
        '
        Me.LblYspz.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblYspz.AutoSize = True
        Me.LblYspz.Location = New System.Drawing.Point(406, 86)
        Me.LblYspz.Name = "LblYspz"
        Me.LblYspz.Size = New System.Drawing.Size(65, 12)
        Me.LblYspz.TabIndex = 11
        Me.LblYspz.Text = "原始凭证："
        '
        'LblCkmc
        '
        Me.LblCkmc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCkmc.AutoSize = True
        Me.LblCkmc.Location = New System.Drawing.Point(888, 86)
        Me.LblCkmc.Name = "LblCkmc"
        Me.LblCkmc.Size = New System.Drawing.Size(0, 12)
        Me.LblCkmc.TabIndex = 15
        '
        'TxtCkdm
        '
        Me.TxtCkdm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCkdm.Location = New System.Drawing.Point(797, 82)
        Me.TxtCkdm.MaxLength = 30
        Me.TxtCkdm.Name = "TxtCkdm"
        Me.TxtCkdm.Size = New System.Drawing.Size(87, 21)
        Me.TxtCkdm.TabIndex = 14
        '
        'LblCkdm
        '
        Me.LblCkdm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCkdm.AutoSize = True
        Me.LblCkdm.Location = New System.Drawing.Point(724, 86)
        Me.LblCkdm.Name = "LblCkdm"
        Me.LblCkdm.Size = New System.Drawing.Size(65, 12)
        Me.LblCkdm.TabIndex = 13
        Me.LblCkdm.Text = "仓库编码："
        '
        'LblCsmc
        '
        Me.LblCsmc.AutoSize = True
        Me.LblCsmc.Location = New System.Drawing.Point(184, 86)
        Me.LblCsmc.Name = "LblCsmc"
        Me.LblCsmc.Size = New System.Drawing.Size(0, 12)
        Me.LblCsmc.TabIndex = 10
        '
        'TxtCsdm
        '
        Me.TxtCsdm.Location = New System.Drawing.Point(88, 82)
        Me.TxtCsdm.MaxLength = 12
        Me.TxtCsdm.Name = "TxtCsdm"
        Me.TxtCsdm.Size = New System.Drawing.Size(87, 21)
        Me.TxtCsdm.TabIndex = 9
        '
        'LblCsdm
        '
        Me.LblCsdm.AutoSize = True
        Me.LblCsdm.Location = New System.Drawing.Point(16, 86)
        Me.LblCsdm.Name = "LblCsdm"
        Me.LblCsdm.Size = New System.Drawing.Size(77, 12)
        Me.LblCsdm.TabIndex = 8
        Me.LblCsdm.Text = "供应商编码："
        '
        'LblZymc
        '
        Me.LblZymc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblZymc.AutoSize = True
        Me.LblZymc.Location = New System.Drawing.Point(892, 58)
        Me.LblZymc.Name = "LblZymc"
        Me.LblZymc.Size = New System.Drawing.Size(0, 12)
        Me.LblZymc.TabIndex = 7
        '
        'TxtZydm
        '
        Me.TxtZydm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtZydm.Location = New System.Drawing.Point(796, 54)
        Me.TxtZydm.MaxLength = 12
        Me.TxtZydm.Name = "TxtZydm"
        Me.TxtZydm.Size = New System.Drawing.Size(87, 21)
        Me.TxtZydm.TabIndex = 6
        '
        'LblZydm
        '
        Me.LblZydm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblZydm.AutoSize = True
        Me.LblZydm.Location = New System.Drawing.Point(724, 58)
        Me.LblZydm.Name = "LblZydm"
        Me.LblZydm.Size = New System.Drawing.Size(65, 12)
        Me.LblZydm.TabIndex = 5
        Me.LblZydm.Text = "职员编码："
        '
        'CmbPzlxjc
        '
        Me.CmbPzlxjc.Location = New System.Drawing.Point(88, 54)
        Me.CmbPzlxjc.Name = "CmbPzlxjc"
        Me.CmbPzlxjc.Size = New System.Drawing.Size(72, 20)
        Me.CmbPzlxjc.TabIndex = 1
        '
        'LblRkrq
        '
        Me.LblRkrq.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblRkrq.AutoSize = True
        Me.LblRkrq.Location = New System.Drawing.Point(381, 58)
        Me.LblRkrq.Name = "LblRkrq"
        Me.LblRkrq.Size = New System.Drawing.Size(65, 12)
        Me.LblRkrq.TabIndex = 3
        Me.LblRkrq.Text = "入库日期："
        '
        'DtpRkrq
        '
        Me.DtpRkrq.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.DtpRkrq.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpRkrq.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpRkrq.Location = New System.Drawing.Point(453, 54)
        Me.DtpRkrq.Name = "DtpRkrq"
        Me.DtpRkrq.Size = New System.Drawing.Size(151, 21)
        Me.DtpRkrq.TabIndex = 4
        '
        'TxtDjh
        '
        Me.TxtDjh.Location = New System.Drawing.Point(160, 54)
        Me.TxtDjh.MaxLength = 15
        Me.TxtDjh.Name = "TxtDjh"
        Me.TxtDjh.Size = New System.Drawing.Size(104, 21)
        Me.TxtDjh.TabIndex = 2
        '
        'LblDjh
        '
        Me.LblDjh.AutoSize = True
        Me.LblDjh.Location = New System.Drawing.Point(16, 58)
        Me.LblDjh.Name = "LblDjh"
        Me.LblDjh.Size = New System.Drawing.Size(65, 12)
        Me.LblDjh.TabIndex = 0
        Me.LblDjh.Text = "单 据 号："
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.LblBdelete)
        Me.Panel3.Controls.Add(Me.LblRkd)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(984, 48)
        Me.Panel3.TabIndex = 0
        '
        'LblBdelete
        '
        Me.LblBdelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblBdelete.AutoSize = True
        Me.LblBdelete.Font = New System.Drawing.Font("黑体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblBdelete.ForeColor = System.Drawing.Color.Red
        Me.LblBdelete.Location = New System.Drawing.Point(793, 10)
        Me.LblBdelete.Name = "LblBdelete"
        Me.LblBdelete.Size = New System.Drawing.Size(60, 24)
        Me.LblBdelete.TabIndex = 3
        Me.LblBdelete.Text = "作废"
        '
        'LblRkd
        '
        Me.LblRkd.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblRkd.AutoSize = True
        Me.LblRkd.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblRkd.ForeColor = System.Drawing.Color.SteelBlue
        Me.LblRkd.Location = New System.Drawing.Point(423, 10)
        Me.LblRkd.Name = "LblRkd"
        Me.LblRkd.Size = New System.Drawing.Size(138, 29)
        Me.LblRkd.TabIndex = 0
        Me.LblRkd.Text = "物料入库单"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtnCopy_Row)
        Me.Panel2.Controls.Add(Me.BtnImp)
        Me.Panel2.Controls.Add(Me.BtnInsert_Row)
        Me.Panel2.Controls.Add(Me.BtnCancel)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.BtnDelete_Row)
        Me.Panel2.Controls.Add(Me.BtnExit)
        Me.Panel2.Controls.Add(Me.BtnNew)
        Me.Panel2.Controls.Add(Me.BtnHelp)
        Me.Panel2.Controls.Add(Me.BtnPrint)
        Me.Panel2.Controls.Add(Me.BtnPrintView)
        Me.Panel2.Controls.Add(Me.BtnSave)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 462)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(984, 99)
        Me.Panel2.TabIndex = 2
        '
        'BtnCopy_Row
        '
        Me.BtnCopy_Row.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCopy_Row.Image = Global.rc3.My.Resources.Resources.copy_row
        Me.BtnCopy_Row.Location = New System.Drawing.Point(613, 58)
        Me.BtnCopy_Row.Name = "BtnCopy_Row"
        Me.BtnCopy_Row.Size = New System.Drawing.Size(28, 23)
        Me.BtnCopy_Row.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.BtnCopy_Row, "复制行ALT+C")
        '
        'BtnImp
        '
        Me.BtnImp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImp.Location = New System.Drawing.Point(202, 58)
        Me.BtnImp.Name = "BtnImp"
        Me.BtnImp.Size = New System.Drawing.Size(89, 23)
        Me.BtnImp.TabIndex = 1
        Me.BtnImp.Text = "导入采购订单"
        '
        'BtnInsert_Row
        '
        Me.BtnInsert_Row.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnInsert_Row.Image = Global.rc3.My.Resources.Resources.insert_row
        Me.BtnInsert_Row.Location = New System.Drawing.Point(557, 58)
        Me.BtnInsert_Row.Name = "BtnInsert_Row"
        Me.BtnInsert_Row.Size = New System.Drawing.Size(28, 23)
        Me.BtnInsert_Row.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.BtnInsert_Row, "插入行ALT+I")
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Enabled = False
        Me.BtnCancel.Location = New System.Drawing.Point(446, 58)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "取消(&Q)"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.LblJese)
        Me.Panel4.Controls.Add(Me.LblSe)
        Me.Panel4.Controls.Add(Me.LblFzsl)
        Me.Panel4.Controls.Add(Me.LblMsg)
        Me.Panel4.Controls.Add(Me.LblJe)
        Me.Panel4.Controls.Add(Me.LblSl)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(984, 43)
        Me.Panel4.TabIndex = 0
        '
        'LblJese
        '
        Me.LblJese.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblJese.AutoSize = True
        Me.LblJese.Location = New System.Drawing.Point(798, 26)
        Me.LblJese.Name = "LblJese"
        Me.LblJese.Size = New System.Drawing.Size(65, 12)
        Me.LblJese.TabIndex = 15
        Me.LblJese.Text = "价税合计："
        '
        'LblSe
        '
        Me.LblSe.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSe.AutoSize = True
        Me.LblSe.Location = New System.Drawing.Point(618, 26)
        Me.LblSe.Name = "LblSe"
        Me.LblSe.Size = New System.Drawing.Size(65, 12)
        Me.LblSe.TabIndex = 14
        Me.LblSe.Text = "税额合计："
        '
        'LblFzsl
        '
        Me.LblFzsl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblFzsl.AutoSize = True
        Me.LblFzsl.Location = New System.Drawing.Point(246, 26)
        Me.LblFzsl.Name = "LblFzsl"
        Me.LblFzsl.Size = New System.Drawing.Size(77, 12)
        Me.LblFzsl.TabIndex = 13
        Me.LblFzsl.Text = "辅数量合计："
        '
        'LblMsg
        '
        Me.LblMsg.ForeColor = System.Drawing.Color.SteelBlue
        Me.LblMsg.Location = New System.Drawing.Point(16, 5)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(758, 16)
        Me.LblMsg.TabIndex = 12
        Me.LblMsg.Text = "提示信息。"
        '
        'LblJe
        '
        Me.LblJe.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblJe.AutoSize = True
        Me.LblJe.Location = New System.Drawing.Point(438, 26)
        Me.LblJe.Name = "LblJe"
        Me.LblJe.Size = New System.Drawing.Size(65, 12)
        Me.LblJe.TabIndex = 11
        Me.LblJe.Text = "金额合计："
        '
        'LblSl
        '
        Me.LblSl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSl.AutoSize = True
        Me.LblSl.Location = New System.Drawing.Point(66, 26)
        Me.LblSl.Name = "LblSl"
        Me.LblSl.Size = New System.Drawing.Size(65, 12)
        Me.LblSl.TabIndex = 10
        Me.LblSl.Text = "数量合计："
        '
        'BtnDelete_Row
        '
        Me.BtnDelete_Row.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDelete_Row.Image = Global.rc3.My.Resources.Resources.delete_row
        Me.BtnDelete_Row.Location = New System.Drawing.Point(585, 58)
        Me.BtnDelete_Row.Name = "BtnDelete_Row"
        Me.BtnDelete_Row.Size = New System.Drawing.Size(28, 23)
        Me.BtnDelete_Row.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.BtnDelete_Row, "删除行CTRL+D")
        '
        'BtnExit
        '
        Me.BtnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExit.Location = New System.Drawing.Point(896, 58)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 23)
        Me.BtnExit.TabIndex = 11
        Me.BtnExit.Text = "退出(&X)"
        '
        'BtnNew
        '
        Me.BtnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnNew.Location = New System.Drawing.Point(296, 58)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(75, 23)
        Me.BtnNew.TabIndex = 2
        Me.BtnNew.Text = "新单(&A)"
        '
        'BtnHelp
        '
        Me.BtnHelp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnHelp.Location = New System.Drawing.Point(821, 58)
        Me.BtnHelp.Name = "BtnHelp"
        Me.BtnHelp.Size = New System.Drawing.Size(75, 23)
        Me.BtnHelp.TabIndex = 10
        Me.BtnHelp.Text = "帮助(&H)"
        '
        'BtnPrint
        '
        Me.BtnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPrint.Location = New System.Drawing.Point(671, 58)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrint.TabIndex = 8
        Me.BtnPrint.Text = "打印(&P)"
        '
        'BtnPrintView
        '
        Me.BtnPrintView.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPrintView.Location = New System.Drawing.Point(746, 58)
        Me.BtnPrintView.Name = "BtnPrintView"
        Me.BtnPrintView.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrintView.TabIndex = 9
        Me.BtnPrintView.Text = "预览(&V)"
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Enabled = False
        Me.BtnSave.Location = New System.Drawing.Point(371, 58)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 3
        Me.BtnSave.Text = "保存(&S)"
        '
        'rcDataGridView
        '
        Me.rcDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.rcDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColCpdm, Me.ColOldCpdm, Me.ColCpmc, Me.ColKuwei, Me.ColSgddh, Me.ColPiHao, Me.ColSl, Me.ColDw, Me.ColMjsl, Me.ColFzsl, Me.ColFzdw, Me.ColDj, Me.ColHsdj, Me.ColJe, Me.ColShlv, Me.ColSe, Me.ColJese, Me.ColRkmemo, Me.ColCgdDjh, Me.ColCgdXh})
        Me.rcDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rcDataGridView.Location = New System.Drawing.Point(0, 137)
        Me.rcDataGridView.Name = "rcDataGridView"
        Me.rcDataGridView.RowHeadersWidth = 62
        Me.rcDataGridView.RowTemplate.Height = 23
        Me.rcDataGridView.Size = New System.Drawing.Size(984, 325)
        Me.rcDataGridView.TabIndex = 1
        '
        'ColCpdm
        '
        Me.ColCpdm.DataPropertyName = "cpdm"
        Me.ColCpdm.Frozen = True
        Me.ColCpdm.HeaderText = "物料编码"
        Me.ColCpdm.MaxInputLength = 15
        Me.ColCpdm.MinimumWidth = 8
        Me.ColCpdm.Name = "ColCpdm"
        Me.ColCpdm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColCpdm.Width = 110
        '
        'ColOldCpdm
        '
        Me.ColOldCpdm.DataPropertyName = "oldcpdm"
        Me.ColOldCpdm.Frozen = True
        Me.ColOldCpdm.HeaderText = "旧物料号"
        Me.ColOldCpdm.MaxInputLength = 15
        Me.ColOldCpdm.MinimumWidth = 8
        Me.ColOldCpdm.Name = "ColOldCpdm"
        Me.ColOldCpdm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColOldCpdm.Visible = False
        Me.ColOldCpdm.Width = 90
        '
        'ColCpmc
        '
        Me.ColCpmc.DataPropertyName = "cpmc"
        Me.ColCpmc.Frozen = True
        Me.ColCpmc.HeaderText = "物料描述"
        Me.ColCpmc.MaxInputLength = 200
        Me.ColCpmc.MinimumWidth = 8
        Me.ColCpmc.Name = "ColCpmc"
        Me.ColCpmc.ReadOnly = True
        Me.ColCpmc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColCpmc.Width = 240
        '
        'ColKuwei
        '
        Me.ColKuwei.DataPropertyName = "kuwei"
        Me.ColKuwei.HeaderText = "库位"
        Me.ColKuwei.MaxInputLength = 50
        Me.ColKuwei.MinimumWidth = 8
        Me.ColKuwei.Name = "ColKuwei"
        Me.ColKuwei.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColKuwei.Width = 90
        '
        'ColSgddh
        '
        Me.ColSgddh.DataPropertyName = "sgddh"
        Me.ColSgddh.HeaderText = "手工订单号"
        Me.ColSgddh.MaxInputLength = 20
        Me.ColSgddh.MinimumWidth = 8
        Me.ColSgddh.Name = "ColSgddh"
        Me.ColSgddh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColSgddh.Width = 150
        '
        'ColPiHao
        '
        Me.ColPiHao.DataPropertyName = "pihao"
        Me.ColPiHao.HeaderText = "批次号"
        Me.ColPiHao.MinimumWidth = 8
        Me.ColPiHao.Name = "ColPiHao"
        Me.ColPiHao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColPiHao.Width = 90
        '
        'ColSl
        '
        Me.ColSl.DataPropertyName = "sl"
        Me.ColSl.HeaderText = "数量"
        Me.ColSl.MaxInputLength = 18
        Me.ColSl.MinimumWidth = 8
        Me.ColSl.Name = "ColSl"
        Me.ColSl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColSl.Width = 90
        '
        'ColDw
        '
        Me.ColDw.DataPropertyName = "dw"
        Me.ColDw.HeaderText = "单位"
        Me.ColDw.MaxInputLength = 10
        Me.ColDw.MinimumWidth = 8
        Me.ColDw.Name = "ColDw"
        Me.ColDw.ReadOnly = True
        Me.ColDw.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColDw.Width = 45
        '
        'ColMjsl
        '
        Me.ColMjsl.DataPropertyName = "mjsl"
        Me.ColMjsl.HeaderText = "换算系数"
        Me.ColMjsl.MinimumWidth = 8
        Me.ColMjsl.Name = "ColMjsl"
        Me.ColMjsl.ReadOnly = True
        Me.ColMjsl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColMjsl.Width = 90
        '
        'ColFzsl
        '
        Me.ColFzsl.DataPropertyName = "fzsl"
        Me.ColFzsl.HeaderText = "辅数量"
        Me.ColFzsl.MinimumWidth = 8
        Me.ColFzsl.Name = "ColFzsl"
        Me.ColFzsl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColFzsl.Width = 90
        '
        'ColFzdw
        '
        Me.ColFzdw.DataPropertyName = "fzdw"
        Me.ColFzdw.HeaderText = "辅单位"
        Me.ColFzdw.MinimumWidth = 8
        Me.ColFzdw.Name = "ColFzdw"
        Me.ColFzdw.ReadOnly = True
        Me.ColFzdw.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColFzdw.Width = 45
        '
        'ColDj
        '
        Me.ColDj.DataPropertyName = "dj"
        Me.ColDj.HeaderText = "不含税单价"
        Me.ColDj.MaxInputLength = 18
        Me.ColDj.MinimumWidth = 8
        Me.ColDj.Name = "ColDj"
        Me.ColDj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColDj.Width = 90
        '
        'ColHsdj
        '
        Me.ColHsdj.DataPropertyName = "hsdj"
        Me.ColHsdj.HeaderText = "含税单价"
        Me.ColHsdj.MaxInputLength = 18
        Me.ColHsdj.MinimumWidth = 8
        Me.ColHsdj.Name = "ColHsdj"
        Me.ColHsdj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColHsdj.Width = 90
        '
        'ColJe
        '
        Me.ColJe.DataPropertyName = "je"
        Me.ColJe.HeaderText = "金额"
        Me.ColJe.MaxInputLength = 14
        Me.ColJe.MinimumWidth = 8
        Me.ColJe.Name = "ColJe"
        Me.ColJe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColJe.Width = 90
        '
        'ColShlv
        '
        Me.ColShlv.DataPropertyName = "shlv"
        Me.ColShlv.HeaderText = "税率"
        Me.ColShlv.MaxInputLength = 6
        Me.ColShlv.MinimumWidth = 8
        Me.ColShlv.Name = "ColShlv"
        Me.ColShlv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColShlv.Width = 60
        '
        'ColSe
        '
        Me.ColSe.DataPropertyName = "se"
        Me.ColSe.HeaderText = "税额"
        Me.ColSe.MaxInputLength = 14
        Me.ColSe.MinimumWidth = 8
        Me.ColSe.Name = "ColSe"
        Me.ColSe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColSe.Width = 150
        '
        'ColJese
        '
        Me.ColJese.DataPropertyName = "jese"
        Me.ColJese.HeaderText = "价税合计"
        Me.ColJese.MaxInputLength = 14
        Me.ColJese.MinimumWidth = 8
        Me.ColJese.Name = "ColJese"
        Me.ColJese.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColJese.Width = 150
        '
        'ColRkmemo
        '
        Me.ColRkmemo.DataPropertyName = "rkmemo"
        Me.ColRkmemo.HeaderText = "备注"
        Me.ColRkmemo.MaxInputLength = 50
        Me.ColRkmemo.MinimumWidth = 8
        Me.ColRkmemo.Name = "ColRkmemo"
        Me.ColRkmemo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColRkmemo.Width = 135
        '
        'ColCgdDjh
        '
        Me.ColCgdDjh.DataPropertyName = "cgddjh"
        Me.ColCgdDjh.HeaderText = "采购订单单据号"
        Me.ColCgdDjh.MaxInputLength = 15
        Me.ColCgdDjh.MinimumWidth = 8
        Me.ColCgdDjh.Name = "ColCgdDjh"
        Me.ColCgdDjh.ReadOnly = True
        Me.ColCgdDjh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColCgdDjh.Width = 110
        '
        'ColCgdXh
        '
        Me.ColCgdXh.DataPropertyName = "cgdxh"
        Me.ColCgdXh.HeaderText = "采购订单行号"
        Me.ColCgdXh.MaxInputLength = 4
        Me.ColCgdXh.MinimumWidth = 8
        Me.ColCgdXh.Name = "ColCgdXh"
        Me.ColCgdXh.ReadOnly = True
        Me.ColCgdXh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColCgdXh.Width = 60
        '
        'FrmPoRkdSrz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.rcDataGridView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStripPanel1)
        Me.Name = "FrmPoRkdSrz"
        Me.Text = "物料入库单输入"
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.ToolStripPanel1.ResumeLayout(False)
        Me.ToolStripPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuiFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Mnui11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuiInsert_Row As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiDelete_Row As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Mnui12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuiPageSetup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiPrintView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Mnui13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuiExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiCut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiPaste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripPanel1 As System.Windows.Forms.ToolStripPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CmbPzlxjc As System.Windows.Forms.ComboBox
    Public WithEvents LblRkrq As System.Windows.Forms.Label
    Public WithEvents DtpRkrq As System.Windows.Forms.DateTimePicker
    Public WithEvents TxtDjh As System.Windows.Forms.TextBox
    Public WithEvents LblDjh As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents LblRkd As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnInsert_Row As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Public WithEvents LblSl As System.Windows.Forms.Label
    Friend WithEvents BtnDelete_Row As System.Windows.Forms.Button
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents BtnHelp As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents BtnPrintView As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents rcDataGridView As System.Windows.Forms.DataGridView
    Public WithEvents LblJe As System.Windows.Forms.Label
    Public WithEvents LblZymc As System.Windows.Forms.Label
    Public WithEvents TxtZydm As System.Windows.Forms.TextBox
    Public WithEvents LblZydm As System.Windows.Forms.Label
    Friend WithEvents rcBindingSource As System.Windows.Forms.BindingSource
    Public WithEvents LblMsg As System.Windows.Forms.Label
    Public WithEvents LblCsmc As System.Windows.Forms.Label
    Public WithEvents TxtCsdm As System.Windows.Forms.TextBox
    Public WithEvents LblCsdm As System.Windows.Forms.Label
    Friend WithEvents BtnImp As System.Windows.Forms.Button
    Public WithEvents LblCkmc As System.Windows.Forms.Label
    Public WithEvents TxtCkdm As System.Windows.Forms.TextBox
    Public WithEvents LblCkdm As System.Windows.Forms.Label
    Public WithEvents TxtYspz As System.Windows.Forms.TextBox
    Public WithEvents LblYspz As System.Windows.Forms.Label
    Public WithEvents LblFzsl As System.Windows.Forms.Label
    Public WithEvents LblJese As System.Windows.Forms.Label
    Public WithEvents LblSe As System.Windows.Forms.Label
    Friend WithEvents MnuiImpXls As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiZf As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiWriteOff As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LblBdelete As System.Windows.Forms.Label
    Friend WithEvents ColCpdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOldCpdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCpmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKuwei As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSgddh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPiHao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDw As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMjsl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFzsl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFzdw As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColHsdj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColShlv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJese As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRkmemo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCgdDjh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCgdXh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnCopy_Row As Button
    Friend WithEvents MnuiCopy_Row As ToolStripMenuItem
    Friend WithEvents ToolTip1 As ToolTip
End Class
