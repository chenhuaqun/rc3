<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInvDbdShz
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
        Me.components = New System.ComponentModel.Container
        Me.MnuMain = New System.Windows.Forms.MenuStrip
        Me.MnuiFile = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiSh = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiXs = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiQs = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiQx = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.MnuiPrevious = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiNext = New System.Windows.Forms.ToolStripMenuItem
        Me.Mnui12 = New System.Windows.Forms.ToolStripSeparator
        Me.MnuiPageSetup = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiPrintView = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiPrint = New System.Windows.Forms.ToolStripMenuItem
        Me.Mnui13 = New System.Windows.Forms.ToolStripSeparator
        Me.MnuiExit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiCut = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiCopy = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiPaste = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiHelp = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripPanel1 = New System.Windows.Forms.ToolStripPanel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblRckmc = New System.Windows.Forms.Label
        Me.TxtRckdm = New System.Windows.Forms.TextBox
        Me.LblRckdm = New System.Windows.Forms.Label
        Me.LblCckmc = New System.Windows.Forms.Label
        Me.TxtCckdm = New System.Windows.Forms.TextBox
        Me.LblCckdm = New System.Windows.Forms.Label
        Me.LblZymc = New System.Windows.Forms.Label
        Me.TxtZydm = New System.Windows.Forms.TextBox
        Me.LblZydm = New System.Windows.Forms.Label
        Me.LblRkrq = New System.Windows.Forms.Label
        Me.DtpDbrq = New System.Windows.Forms.DateTimePicker
        Me.TxtDjh = New System.Windows.Forms.TextBox
        Me.LblDjh = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.LblCkd = New System.Windows.Forms.Label
        Me.rcDataGridView = New System.Windows.Forms.DataGridView
        Me.ColCpdm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCpmc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCsdm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCsmc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColKuwei = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColPiHao = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColSl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColDw = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColMjsl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColFzsl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColFzdw = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColDj = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColJe = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColRkmemo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColLlsqDjh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColLlsqXh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.rcBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.LblJzr = New System.Windows.Forms.Label
        Me.LblShr = New System.Windows.Forms.Label
        Me.LblSrr = New System.Windows.Forms.Label
        Me.BtnPrevious = New System.Windows.Forms.Button
        Me.BtnNext = New System.Windows.Forms.Button
        Me.BtnExit = New System.Windows.Forms.Button
        Me.BtnSh = New System.Windows.Forms.Button
        Me.BtnPrint = New System.Windows.Forms.Button
        Me.BtnHelp = New System.Windows.Forms.Button
        Me.BtnQs = New System.Windows.Forms.Button
        Me.BtnQx = New System.Windows.Forms.Button
        Me.BtnXs = New System.Windows.Forms.Button
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.LblFzsl = New System.Windows.Forms.Label
        Me.LblJe = New System.Windows.Forms.Label
        Me.LblSl = New System.Windows.Forms.Label
        Me.LblBdelete = New System.Windows.Forms.Label
        Me.MnuMain.SuspendLayout()
        Me.ToolStripPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'MnuMain
        '
        Me.MnuMain.Dock = System.Windows.Forms.DockStyle.None
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiFile, Me.MnuiEdit, Me.MnuiHelp})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(984, 25)
        Me.MnuMain.TabIndex = 1
        '
        'MnuiFile
        '
        Me.MnuiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiSh, Me.MnuiXs, Me.MnuiQs, Me.MnuiQx, Me.ToolStripSeparator1, Me.MnuiPrevious, Me.MnuiNext, Me.Mnui12, Me.MnuiPageSetup, Me.MnuiPrintView, Me.MnuiPrint, Me.Mnui13, Me.MnuiExit})
        Me.MnuiFile.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiFile.Name = "MnuiFile"
        Me.MnuiFile.Size = New System.Drawing.Size(58, 21)
        Me.MnuiFile.Text = "文件(&F)"
        '
        'MnuiSh
        '
        Me.MnuiSh.Name = "MnuiSh"
        Me.MnuiSh.Size = New System.Drawing.Size(141, 22)
        Me.MnuiSh.Text = "审核(&S)"
        '
        'MnuiXs
        '
        Me.MnuiXs.Name = "MnuiXs"
        Me.MnuiXs.Size = New System.Drawing.Size(141, 22)
        Me.MnuiXs.Text = "消审(&C)"
        '
        'MnuiQs
        '
        Me.MnuiQs.Name = "MnuiQs"
        Me.MnuiQs.Size = New System.Drawing.Size(141, 22)
        Me.MnuiQs.Text = "全审(&Q)"
        '
        'MnuiQx
        '
        Me.MnuiQx.Name = "MnuiQx"
        Me.MnuiQx.Size = New System.Drawing.Size(141, 22)
        Me.MnuiQx.Text = "全消(&Y)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(138, 6)
        '
        'MnuiPrevious
        '
        Me.MnuiPrevious.Name = "MnuiPrevious"
        Me.MnuiPrevious.Size = New System.Drawing.Size(141, 22)
        Me.MnuiPrevious.Text = "上张(&F)"
        '
        'MnuiNext
        '
        Me.MnuiNext.Name = "MnuiNext"
        Me.MnuiNext.Size = New System.Drawing.Size(141, 22)
        Me.MnuiNext.Text = "下张(&B)"
        '
        'Mnui12
        '
        Me.Mnui12.Name = "Mnui12"
        Me.Mnui12.Size = New System.Drawing.Size(138, 6)
        '
        'MnuiPageSetup
        '
        Me.MnuiPageSetup.Name = "MnuiPageSetup"
        Me.MnuiPageSetup.Size = New System.Drawing.Size(141, 22)
        Me.MnuiPageSetup.Text = "页面设置(&U)"
        '
        'MnuiPrintView
        '
        Me.MnuiPrintView.Name = "MnuiPrintView"
        Me.MnuiPrintView.Size = New System.Drawing.Size(141, 22)
        Me.MnuiPrintView.Text = "打印预览(&V)"
        '
        'MnuiPrint
        '
        Me.MnuiPrint.Name = "MnuiPrint"
        Me.MnuiPrint.Size = New System.Drawing.Size(141, 22)
        Me.MnuiPrint.Text = "打印(&P)"
        '
        'Mnui13
        '
        Me.Mnui13.Name = "Mnui13"
        Me.Mnui13.Size = New System.Drawing.Size(138, 6)
        '
        'MnuiExit
        '
        Me.MnuiExit.Name = "MnuiExit"
        Me.MnuiExit.Size = New System.Drawing.Size(141, 22)
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
        Me.MnuiCut.Size = New System.Drawing.Size(116, 22)
        Me.MnuiCut.Text = "剪切(&T)"
        '
        'MnuiCopy
        '
        Me.MnuiCopy.Name = "MnuiCopy"
        Me.MnuiCopy.Size = New System.Drawing.Size(116, 22)
        Me.MnuiCopy.Text = "复制(&C)"
        '
        'MnuiPaste
        '
        Me.MnuiPaste.Name = "MnuiPaste"
        Me.MnuiPaste.Size = New System.Drawing.Size(116, 22)
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
        Me.Panel1.Controls.Add(Me.LblRckmc)
        Me.Panel1.Controls.Add(Me.TxtRckdm)
        Me.Panel1.Controls.Add(Me.LblRckdm)
        Me.Panel1.Controls.Add(Me.LblCckmc)
        Me.Panel1.Controls.Add(Me.TxtCckdm)
        Me.Panel1.Controls.Add(Me.LblCckdm)
        Me.Panel1.Controls.Add(Me.LblZymc)
        Me.Panel1.Controls.Add(Me.TxtZydm)
        Me.Panel1.Controls.Add(Me.LblZydm)
        Me.Panel1.Controls.Add(Me.LblRkrq)
        Me.Panel1.Controls.Add(Me.DtpDbrq)
        Me.Panel1.Controls.Add(Me.TxtDjh)
        Me.Panel1.Controls.Add(Me.LblDjh)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(984, 112)
        Me.Panel1.TabIndex = 0
        '
        'LblRckmc
        '
        Me.LblRckmc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblRckmc.AutoSize = True
        Me.LblRckmc.Location = New System.Drawing.Point(900, 91)
        Me.LblRckmc.Name = "LblRckmc"
        Me.LblRckmc.Size = New System.Drawing.Size(0, 12)
        Me.LblRckmc.TabIndex = 28
        '
        'TxtRckdm
        '
        Me.TxtRckdm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtRckdm.Enabled = False
        Me.TxtRckdm.Location = New System.Drawing.Point(792, 85)
        Me.TxtRckdm.MaxLength = 30
        Me.TxtRckdm.Name = "TxtRckdm"
        Me.TxtRckdm.Size = New System.Drawing.Size(102, 21)
        Me.TxtRckdm.TabIndex = 27
        '
        'LblRckdm
        '
        Me.LblRckdm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblRckdm.AutoSize = True
        Me.LblRckdm.Location = New System.Drawing.Point(720, 89)
        Me.LblRckdm.Name = "LblRckdm"
        Me.LblRckdm.Size = New System.Drawing.Size(65, 12)
        Me.LblRckdm.TabIndex = 26
        Me.LblRckdm.Text = "调入仓库："
        '
        'LblCckmc
        '
        Me.LblCckmc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCckmc.AutoSize = True
        Me.LblCckmc.Location = New System.Drawing.Point(902, 60)
        Me.LblCckmc.Name = "LblCckmc"
        Me.LblCckmc.Size = New System.Drawing.Size(0, 12)
        Me.LblCckmc.TabIndex = 22
        '
        'TxtCckdm
        '
        Me.TxtCckdm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCckdm.Enabled = False
        Me.TxtCckdm.Location = New System.Drawing.Point(792, 56)
        Me.TxtCckdm.MaxLength = 30
        Me.TxtCckdm.Name = "TxtCckdm"
        Me.TxtCckdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtCckdm.TabIndex = 18
        '
        'LblCckdm
        '
        Me.LblCckdm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCckdm.AutoSize = True
        Me.LblCckdm.Location = New System.Drawing.Point(720, 60)
        Me.LblCckdm.Name = "LblCckdm"
        Me.LblCckdm.Size = New System.Drawing.Size(65, 12)
        Me.LblCckdm.TabIndex = 17
        Me.LblCckdm.Text = "调出仓库："
        '
        'LblZymc
        '
        Me.LblZymc.AutoSize = True
        Me.LblZymc.Location = New System.Drawing.Point(182, 81)
        Me.LblZymc.Name = "LblZymc"
        Me.LblZymc.Size = New System.Drawing.Size(0, 12)
        Me.LblZymc.TabIndex = 14
        '
        'TxtZydm
        '
        Me.TxtZydm.Enabled = False
        Me.TxtZydm.Location = New System.Drawing.Point(86, 81)
        Me.TxtZydm.MaxLength = 12
        Me.TxtZydm.Name = "TxtZydm"
        Me.TxtZydm.Size = New System.Drawing.Size(87, 21)
        Me.TxtZydm.TabIndex = 13
        '
        'LblZydm
        '
        Me.LblZydm.AutoSize = True
        Me.LblZydm.Location = New System.Drawing.Point(15, 84)
        Me.LblZydm.Name = "LblZydm"
        Me.LblZydm.Size = New System.Drawing.Size(65, 12)
        Me.LblZydm.TabIndex = 12
        Me.LblZydm.Text = "职员编码："
        '
        'LblRkrq
        '
        Me.LblRkrq.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblRkrq.AutoSize = True
        Me.LblRkrq.Location = New System.Drawing.Point(381, 60)
        Me.LblRkrq.Name = "LblRkrq"
        Me.LblRkrq.Size = New System.Drawing.Size(65, 12)
        Me.LblRkrq.TabIndex = 4
        Me.LblRkrq.Text = "调拨日期："
        '
        'DtpDbrq
        '
        Me.DtpDbrq.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.DtpDbrq.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpDbrq.Enabled = False
        Me.DtpDbrq.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpDbrq.Location = New System.Drawing.Point(453, 56)
        Me.DtpDbrq.Name = "DtpDbrq"
        Me.DtpDbrq.Size = New System.Drawing.Size(151, 21)
        Me.DtpDbrq.TabIndex = 5
        '
        'TxtDjh
        '
        Me.TxtDjh.Enabled = False
        Me.TxtDjh.Location = New System.Drawing.Point(88, 54)
        Me.TxtDjh.MaxLength = 15
        Me.TxtDjh.Name = "TxtDjh"
        Me.TxtDjh.Size = New System.Drawing.Size(104, 21)
        Me.TxtDjh.TabIndex = 3
        '
        'LblDjh
        '
        Me.LblDjh.AutoSize = True
        Me.LblDjh.Location = New System.Drawing.Point(17, 59)
        Me.LblDjh.Name = "LblDjh"
        Me.LblDjh.Size = New System.Drawing.Size(65, 12)
        Me.LblDjh.TabIndex = 1
        Me.LblDjh.Text = "单 据 号："
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.LblBdelete)
        Me.Panel3.Controls.Add(Me.LblCkd)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(984, 48)
        Me.Panel3.TabIndex = 0
        '
        'LblCkd
        '
        Me.LblCkd.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblCkd.AutoSize = True
        Me.LblCkd.Font = New System.Drawing.Font("华文行楷", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblCkd.ForeColor = System.Drawing.Color.SteelBlue
        Me.LblCkd.Location = New System.Drawing.Point(426, 9)
        Me.LblCkd.Name = "LblCkd"
        Me.LblCkd.Size = New System.Drawing.Size(137, 25)
        Me.LblCkd.TabIndex = 0
        Me.LblCkd.Text = "物料调拨单"
        '
        'rcDataGridView
        '
        Me.rcDataGridView.AllowUserToAddRows = False
        Me.rcDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.rcDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColCpdm, Me.ColCpmc, Me.ColCsdm, Me.ColCsmc, Me.ColKuwei, Me.ColPiHao, Me.ColSl, Me.ColDw, Me.ColMjsl, Me.ColFzsl, Me.ColFzdw, Me.ColDj, Me.ColJe, Me.ColRkmemo, Me.ColLlsqDjh, Me.ColLlsqXh})
        Me.rcDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rcDataGridView.Location = New System.Drawing.Point(0, 137)
        Me.rcDataGridView.Name = "rcDataGridView"
        Me.rcDataGridView.ReadOnly = True
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
        Me.ColCpdm.Name = "ColCpdm"
        Me.ColCpdm.ReadOnly = True
        Me.ColCpdm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColCpdm.Width = 110
        '
        'ColCpmc
        '
        Me.ColCpmc.DataPropertyName = "cpmc"
        Me.ColCpmc.HeaderText = "物料描述"
        Me.ColCpmc.MaxInputLength = 50
        Me.ColCpmc.Name = "ColCpmc"
        Me.ColCpmc.ReadOnly = True
        Me.ColCpmc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColCpmc.Width = 240
        '
        'ColCsdm
        '
        Me.ColCsdm.DataPropertyName = "csdm"
        Me.ColCsdm.HeaderText = "供应商编码"
        Me.ColCsdm.MaxInputLength = 12
        Me.ColCsdm.Name = "ColCsdm"
        Me.ColCsdm.ReadOnly = True
        Me.ColCsdm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColCsdm.Width = 90
        '
        'ColCsmc
        '
        Me.ColCsmc.DataPropertyName = "csmc"
        Me.ColCsmc.HeaderText = "供应商名称"
        Me.ColCsmc.MaxInputLength = 50
        Me.ColCsmc.Name = "ColCsmc"
        Me.ColCsmc.ReadOnly = True
        Me.ColCsmc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColCsmc.Width = 180
        '
        'ColKuwei
        '
        Me.ColKuwei.DataPropertyName = "kuwei"
        Me.ColKuwei.HeaderText = "库位"
        Me.ColKuwei.Name = "ColKuwei"
        Me.ColKuwei.ReadOnly = True
        Me.ColKuwei.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColPiHao
        '
        Me.ColPiHao.DataPropertyName = "pihao"
        Me.ColPiHao.HeaderText = "批号"
        Me.ColPiHao.Name = "ColPiHao"
        Me.ColPiHao.ReadOnly = True
        Me.ColPiHao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColPiHao.Width = 110
        '
        'ColSl
        '
        Me.ColSl.DataPropertyName = "sl"
        Me.ColSl.HeaderText = "数量"
        Me.ColSl.MaxInputLength = 18
        Me.ColSl.Name = "ColSl"
        Me.ColSl.ReadOnly = True
        Me.ColSl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColSl.Width = 90
        '
        'ColDw
        '
        Me.ColDw.DataPropertyName = "dw"
        Me.ColDw.HeaderText = "单位"
        Me.ColDw.MaxInputLength = 10
        Me.ColDw.Name = "ColDw"
        Me.ColDw.ReadOnly = True
        Me.ColDw.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColDw.Width = 45
        '
        'ColMjsl
        '
        Me.ColMjsl.DataPropertyName = "mjsl"
        Me.ColMjsl.HeaderText = "换算系数"
        Me.ColMjsl.Name = "ColMjsl"
        Me.ColMjsl.ReadOnly = True
        Me.ColMjsl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColMjsl.Width = 90
        '
        'ColFzsl
        '
        Me.ColFzsl.DataPropertyName = "fzsl"
        Me.ColFzsl.HeaderText = "辅数量"
        Me.ColFzsl.Name = "ColFzsl"
        Me.ColFzsl.ReadOnly = True
        Me.ColFzsl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColFzsl.Width = 90
        '
        'ColFzdw
        '
        Me.ColFzdw.DataPropertyName = "fzdw"
        Me.ColFzdw.HeaderText = "辅单位"
        Me.ColFzdw.Name = "ColFzdw"
        Me.ColFzdw.ReadOnly = True
        Me.ColFzdw.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColFzdw.Width = 45
        '
        'ColDj
        '
        Me.ColDj.DataPropertyName = "dj"
        Me.ColDj.HeaderText = "单价"
        Me.ColDj.Name = "ColDj"
        Me.ColDj.ReadOnly = True
        Me.ColDj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColDj.Width = 90
        '
        'ColJe
        '
        Me.ColJe.DataPropertyName = "je"
        Me.ColJe.HeaderText = "金额"
        Me.ColJe.Name = "ColJe"
        Me.ColJe.ReadOnly = True
        Me.ColJe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColJe.Width = 90
        '
        'ColRkmemo
        '
        Me.ColRkmemo.DataPropertyName = "rkmemo"
        Me.ColRkmemo.HeaderText = "备注"
        Me.ColRkmemo.MaxInputLength = 50
        Me.ColRkmemo.Name = "ColRkmemo"
        Me.ColRkmemo.ReadOnly = True
        Me.ColRkmemo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColRkmemo.Width = 135
        '
        'ColLlsqDjh
        '
        Me.ColLlsqDjh.DataPropertyName = "llsqdjh"
        Me.ColLlsqDjh.HeaderText = "领料申请单据号"
        Me.ColLlsqDjh.MaxInputLength = 15
        Me.ColLlsqDjh.Name = "ColLlsqDjh"
        Me.ColLlsqDjh.ReadOnly = True
        Me.ColLlsqDjh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColLlsqDjh.Width = 110
        '
        'ColLlsqXh
        '
        Me.ColLlsqXh.DataPropertyName = "llsqxh"
        Me.ColLlsqXh.HeaderText = "领料申请行号"
        Me.ColLlsqXh.MaxInputLength = 4
        Me.ColLlsqXh.Name = "ColLlsqXh"
        Me.ColLlsqXh.ReadOnly = True
        Me.ColLlsqXh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColLlsqXh.Width = 60
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.LblJzr)
        Me.Panel2.Controls.Add(Me.LblShr)
        Me.Panel2.Controls.Add(Me.LblSrr)
        Me.Panel2.Controls.Add(Me.BtnPrevious)
        Me.Panel2.Controls.Add(Me.BtnNext)
        Me.Panel2.Controls.Add(Me.BtnExit)
        Me.Panel2.Controls.Add(Me.BtnSh)
        Me.Panel2.Controls.Add(Me.BtnPrint)
        Me.Panel2.Controls.Add(Me.BtnHelp)
        Me.Panel2.Controls.Add(Me.BtnQs)
        Me.Panel2.Controls.Add(Me.BtnQx)
        Me.Panel2.Controls.Add(Me.BtnXs)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 462)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(984, 99)
        Me.Panel2.TabIndex = 4
        '
        'LblJzr
        '
        Me.LblJzr.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblJzr.AutoSize = True
        Me.LblJzr.Location = New System.Drawing.Point(720, 43)
        Me.LblJzr.Name = "LblJzr"
        Me.LblJzr.Size = New System.Drawing.Size(41, 12)
        Me.LblJzr.TabIndex = 38
        Me.LblJzr.Text = "记账："
        '
        'LblShr
        '
        Me.LblShr.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblShr.AutoSize = True
        Me.LblShr.Location = New System.Drawing.Point(472, 43)
        Me.LblShr.Name = "LblShr"
        Me.LblShr.Size = New System.Drawing.Size(41, 12)
        Me.LblShr.TabIndex = 37
        Me.LblShr.Text = "审核："
        '
        'LblSrr
        '
        Me.LblSrr.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblSrr.AutoSize = True
        Me.LblSrr.Location = New System.Drawing.Point(232, 43)
        Me.LblSrr.Name = "LblSrr"
        Me.LblSrr.Size = New System.Drawing.Size(41, 12)
        Me.LblSrr.TabIndex = 36
        Me.LblSrr.Text = "输入："
        '
        'BtnPrevious
        '
        Me.BtnPrevious.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnPrevious.Location = New System.Drawing.Point(453, 64)
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrevious.TabIndex = 31
        Me.BtnPrevious.Text = "上张(&F)"
        '
        'BtnNext
        '
        Me.BtnNext.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnNext.Location = New System.Drawing.Point(533, 64)
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(75, 23)
        Me.BtnNext.TabIndex = 32
        Me.BtnNext.Text = "下张(&B)"
        '
        'BtnExit
        '
        Me.BtnExit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnExit.Location = New System.Drawing.Point(773, 64)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 23)
        Me.BtnExit.TabIndex = 35
        Me.BtnExit.Text = "退出(&X)"
        '
        'BtnSh
        '
        Me.BtnSh.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnSh.Location = New System.Drawing.Point(133, 64)
        Me.BtnSh.Name = "BtnSh"
        Me.BtnSh.Size = New System.Drawing.Size(75, 23)
        Me.BtnSh.TabIndex = 27
        Me.BtnSh.Text = "审核(&S)"
        '
        'BtnPrint
        '
        Me.BtnPrint.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnPrint.Location = New System.Drawing.Point(613, 64)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrint.TabIndex = 33
        Me.BtnPrint.Text = "打印(&P)"
        '
        'BtnHelp
        '
        Me.BtnHelp.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnHelp.Location = New System.Drawing.Point(693, 64)
        Me.BtnHelp.Name = "BtnHelp"
        Me.BtnHelp.Size = New System.Drawing.Size(75, 23)
        Me.BtnHelp.TabIndex = 34
        Me.BtnHelp.Text = "帮助(&H)"
        '
        'BtnQs
        '
        Me.BtnQs.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnQs.Location = New System.Drawing.Point(293, 64)
        Me.BtnQs.Name = "BtnQs"
        Me.BtnQs.Size = New System.Drawing.Size(75, 23)
        Me.BtnQs.TabIndex = 29
        Me.BtnQs.Text = "全审(&Q)"
        '
        'BtnQx
        '
        Me.BtnQx.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnQx.Location = New System.Drawing.Point(373, 64)
        Me.BtnQx.Name = "BtnQx"
        Me.BtnQx.Size = New System.Drawing.Size(75, 23)
        Me.BtnQx.TabIndex = 30
        Me.BtnQx.Text = "全消(&Y)"
        '
        'BtnXs
        '
        Me.BtnXs.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnXs.Location = New System.Drawing.Point(213, 64)
        Me.BtnXs.Name = "BtnXs"
        Me.BtnXs.Size = New System.Drawing.Size(75, 23)
        Me.BtnXs.TabIndex = 28
        Me.BtnXs.Text = "消审(&C)"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.LblFzsl)
        Me.Panel4.Controls.Add(Me.LblJe)
        Me.Panel4.Controls.Add(Me.LblSl)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(984, 35)
        Me.Panel4.TabIndex = 0
        '
        'LblFzsl
        '
        Me.LblFzsl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblFzsl.AutoSize = True
        Me.LblFzsl.Location = New System.Drawing.Point(638, 11)
        Me.LblFzsl.Name = "LblFzsl"
        Me.LblFzsl.Size = New System.Drawing.Size(77, 12)
        Me.LblFzsl.TabIndex = 15
        Me.LblFzsl.Text = "辅数量合计："
        '
        'LblJe
        '
        Me.LblJe.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblJe.AutoSize = True
        Me.LblJe.Location = New System.Drawing.Point(818, 11)
        Me.LblJe.Name = "LblJe"
        Me.LblJe.Size = New System.Drawing.Size(65, 12)
        Me.LblJe.TabIndex = 14
        Me.LblJe.Text = "金额合计："
        '
        'LblSl
        '
        Me.LblSl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSl.AutoSize = True
        Me.LblSl.Location = New System.Drawing.Point(470, 11)
        Me.LblSl.Name = "LblSl"
        Me.LblSl.Size = New System.Drawing.Size(65, 12)
        Me.LblSl.TabIndex = 10
        Me.LblSl.Text = "数量合计："
        '
        'LblBdelete
        '
        Me.LblBdelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblBdelete.AutoSize = True
        Me.LblBdelete.Font = New System.Drawing.Font("黑体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblBdelete.ForeColor = System.Drawing.Color.Red
        Me.LblBdelete.Location = New System.Drawing.Point(860, 10)
        Me.LblBdelete.Name = "LblBdelete"
        Me.LblBdelete.Size = New System.Drawing.Size(60, 24)
        Me.LblBdelete.TabIndex = 3
        Me.LblBdelete.Text = "作废"
        '
        'FrmInvDbdShz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.rcDataGridView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStripPanel1)
        Me.Name = "FrmInvDbdShz"
        Me.Text = "物料调拨单审核"
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.ToolStripPanel1.ResumeLayout(False)
        Me.ToolStripPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuiFile As System.Windows.Forms.ToolStripMenuItem
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
    Public WithEvents LblRkrq As System.Windows.Forms.Label
    Public WithEvents DtpDbrq As System.Windows.Forms.DateTimePicker
    Public WithEvents TxtDjh As System.Windows.Forms.TextBox
    Public WithEvents LblDjh As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents LblCkd As System.Windows.Forms.Label
    Friend WithEvents rcDataGridView As System.Windows.Forms.DataGridView
    Public WithEvents LblZymc As System.Windows.Forms.Label
    Public WithEvents TxtZydm As System.Windows.Forms.TextBox
    Public WithEvents LblZydm As System.Windows.Forms.Label
    Friend WithEvents rcBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Public WithEvents LblJzr As System.Windows.Forms.Label
    Public WithEvents LblShr As System.Windows.Forms.Label
    Public WithEvents LblSrr As System.Windows.Forms.Label
    Friend WithEvents BtnPrevious As System.Windows.Forms.Button
    Friend WithEvents BtnNext As System.Windows.Forms.Button
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents BtnSh As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents BtnHelp As System.Windows.Forms.Button
    Friend WithEvents BtnQs As System.Windows.Forms.Button
    Friend WithEvents BtnQx As System.Windows.Forms.Button
    Friend WithEvents BtnXs As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Public WithEvents LblSl As System.Windows.Forms.Label
    Friend WithEvents MnuiSh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiXs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiQs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiQx As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuiPrevious As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiNext As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Mnui12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuiPageSetup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiPrintView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiPrint As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents TxtCckdm As System.Windows.Forms.TextBox
    Public WithEvents LblCckdm As System.Windows.Forms.Label
    Public WithEvents LblCckmc As System.Windows.Forms.Label
    Public WithEvents LblJe As System.Windows.Forms.Label
    Public WithEvents LblRckmc As System.Windows.Forms.Label
    Public WithEvents TxtRckdm As System.Windows.Forms.TextBox
    Public WithEvents LblRckdm As System.Windows.Forms.Label
    Public WithEvents LblFzsl As System.Windows.Forms.Label
    Friend WithEvents ColCpdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCpmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCsdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCsmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKuwei As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPiHao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDw As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMjsl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFzsl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFzdw As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRkmemo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLlsqDjh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLlsqXh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LblBdelete As System.Windows.Forms.Label
End Class
