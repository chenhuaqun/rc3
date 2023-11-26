<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeBjdShz
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
        Me.rcPrintDocument = New System.Drawing.Printing.PrintDocument
        Me.MnuMain = New System.Windows.Forms.MenuStrip
        Me.MnuiFile = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiSh = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiXs = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiQs = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiQx = New System.Windows.Forms.ToolStripMenuItem
        Me.Mnui11 = New System.Windows.Forms.ToolStripSeparator
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
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.TxtMemo4 = New System.Windows.Forms.TextBox
        Me.TxtMemo3 = New System.Windows.Forms.TextBox
        Me.TxtMemo2 = New System.Windows.Forms.TextBox
        Me.TxtMemo1 = New System.Windows.Forms.TextBox
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnSaveAs = New System.Windows.Forms.Button
        Me.BtnToEmail = New System.Windows.Forms.Button
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
        Me.rcDataGridView = New System.Windows.Forms.DataGridView
        Me.ColKhlh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColKhcz = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCpdm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCpmc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCpgg = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColDw = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColZl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColDj = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColSpq = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColMoq = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColBjmemo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.LblBjd = New System.Windows.Forms.Label
        Me.LblDjh = New System.Windows.Forms.Label
        Me.TxtDjh = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TxtWbhl = New System.Windows.Forms.TextBox
        Me.LblWbhl = New System.Windows.Forms.Label
        Me.TxtWbdm = New System.Windows.Forms.TextBox
        Me.LblWbdm = New System.Windows.Forms.Label
        Me.TxtEmail = New System.Windows.Forms.TextBox
        Me.LblEmail = New System.Windows.Forms.Label
        Me.LblZymc = New System.Windows.Forms.Label
        Me.TxtZydm = New System.Windows.Forms.TextBox
        Me.LblZydm = New System.Windows.Forms.Label
        Me.TxtBjtk = New System.Windows.Forms.TextBox
        Me.LblBjtk = New System.Windows.Forms.Label
        Me.LblKhmc = New System.Windows.Forms.Label
        Me.TxtKhdm = New System.Windows.Forms.TextBox
        Me.LblKhdm = New System.Windows.Forms.Label
        Me.LblBjrq = New System.Windows.Forms.Label
        Me.DtpBjrq = New System.Windows.Forms.DateTimePicker
        Me.TxtMemo5 = New System.Windows.Forms.TextBox
        Me.MnuMain.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'rcPrintDocument
        '
        Me.rcPrintDocument.DocumentName = "Richen Print System"
        '
        'MnuMain
        '
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiFile, Me.MnuiEdit, Me.MnuiHelp})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(984, 25)
        Me.MnuMain.TabIndex = 1
        '
        'MnuiFile
        '
        Me.MnuiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiSh, Me.MnuiXs, Me.MnuiQs, Me.MnuiQx, Me.Mnui11, Me.MnuiPrevious, Me.MnuiNext, Me.Mnui12, Me.MnuiPageSetup, Me.MnuiPrintView, Me.MnuiPrint, Me.Mnui13, Me.MnuiExit})
        Me.MnuiFile.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiFile.Name = "MnuiFile"
        Me.MnuiFile.Size = New System.Drawing.Size(58, 21)
        Me.MnuiFile.Text = "文件(&F)"
        '
        'MnuiSh
        '
        Me.MnuiSh.Name = "MnuiSh"
        Me.MnuiSh.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.MnuiSh.Size = New System.Drawing.Size(159, 22)
        Me.MnuiSh.Text = "审核(&S)"
        '
        'MnuiXs
        '
        Me.MnuiXs.Name = "MnuiXs"
        Me.MnuiXs.Size = New System.Drawing.Size(159, 22)
        Me.MnuiXs.Text = "消审(&C)"
        '
        'MnuiQs
        '
        Me.MnuiQs.Name = "MnuiQs"
        Me.MnuiQs.Size = New System.Drawing.Size(159, 22)
        Me.MnuiQs.Text = "全审(&Q)"
        '
        'MnuiQx
        '
        Me.MnuiQx.Name = "MnuiQx"
        Me.MnuiQx.Size = New System.Drawing.Size(159, 22)
        Me.MnuiQx.Text = "全消(&Y)"
        '
        'Mnui11
        '
        Me.Mnui11.Name = "Mnui11"
        Me.Mnui11.Size = New System.Drawing.Size(156, 6)
        '
        'MnuiPrevious
        '
        Me.MnuiPrevious.Name = "MnuiPrevious"
        Me.MnuiPrevious.Size = New System.Drawing.Size(159, 22)
        Me.MnuiPrevious.Text = "上张(&F)"
        '
        'MnuiNext
        '
        Me.MnuiNext.Name = "MnuiNext"
        Me.MnuiNext.Size = New System.Drawing.Size(159, 22)
        Me.MnuiNext.Text = "下张(&B)"
        '
        'Mnui12
        '
        Me.Mnui12.Name = "Mnui12"
        Me.Mnui12.Size = New System.Drawing.Size(156, 6)
        '
        'MnuiPageSetup
        '
        Me.MnuiPageSetup.Name = "MnuiPageSetup"
        Me.MnuiPageSetup.Size = New System.Drawing.Size(159, 22)
        Me.MnuiPageSetup.Text = "页面设置(&U)"
        '
        'MnuiPrintView
        '
        Me.MnuiPrintView.Name = "MnuiPrintView"
        Me.MnuiPrintView.Size = New System.Drawing.Size(159, 22)
        Me.MnuiPrintView.Text = "打印预览(&V)"
        '
        'MnuiPrint
        '
        Me.MnuiPrint.Name = "MnuiPrint"
        Me.MnuiPrint.Size = New System.Drawing.Size(159, 22)
        Me.MnuiPrint.Text = "打印(&P)"
        '
        'Mnui13
        '
        Me.Mnui13.Name = "Mnui13"
        Me.Mnui13.Size = New System.Drawing.Size(156, 6)
        '
        'MnuiExit
        '
        Me.MnuiExit.Name = "MnuiExit"
        Me.MnuiExit.Size = New System.Drawing.Size(159, 22)
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
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.BtnSaveAs)
        Me.Panel2.Controls.Add(Me.BtnToEmail)
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
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 383)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(984, 178)
        Me.Panel2.TabIndex = 27
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.TxtMemo5)
        Me.Panel4.Controls.Add(Me.TxtMemo4)
        Me.Panel4.Controls.Add(Me.TxtMemo3)
        Me.Panel4.Controls.Add(Me.TxtMemo2)
        Me.Panel4.Controls.Add(Me.TxtMemo1)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(984, 106)
        Me.Panel4.TabIndex = 36
        '
        'TxtMemo4
        '
        Me.TxtMemo4.Dock = System.Windows.Forms.DockStyle.Top
        Me.TxtMemo4.Location = New System.Drawing.Point(43, 63)
        Me.TxtMemo4.MaxLength = 150
        Me.TxtMemo4.Multiline = True
        Me.TxtMemo4.Name = "TxtMemo4"
        Me.TxtMemo4.ReadOnly = True
        Me.TxtMemo4.Size = New System.Drawing.Size(941, 21)
        Me.TxtMemo4.TabIndex = 24
        Me.TxtMemo4.Text = "4、以上SPQ仅供参考，具体按实际；"
        '
        'TxtMemo3
        '
        Me.TxtMemo3.Dock = System.Windows.Forms.DockStyle.Top
        Me.TxtMemo3.Location = New System.Drawing.Point(43, 42)
        Me.TxtMemo3.MaxLength = 150
        Me.TxtMemo3.Multiline = True
        Me.TxtMemo3.Name = "TxtMemo3"
        Me.TxtMemo3.ReadOnly = True
        Me.TxtMemo3.Size = New System.Drawing.Size(941, 21)
        Me.TxtMemo3.TabIndex = 23
        Me.TxtMemo3.Text = "3、若汇率波动+/-3%以上时，需重新确认单价；"
        '
        'TxtMemo2
        '
        Me.TxtMemo2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TxtMemo2.Location = New System.Drawing.Point(43, 21)
        Me.TxtMemo2.MaxLength = 150
        Me.TxtMemo2.Multiline = True
        Me.TxtMemo2.Name = "TxtMemo2"
        Me.TxtMemo2.ReadOnly = True
        Me.TxtMemo2.Size = New System.Drawing.Size(941, 21)
        Me.TxtMemo2.TabIndex = 22
        Me.TxtMemo2.Text = "2、无特殊说明，RMB报价为含税单价，外币报价为FOB上海价；"
        '
        'TxtMemo1
        '
        Me.TxtMemo1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TxtMemo1.Location = New System.Drawing.Point(43, 0)
        Me.TxtMemo1.MaxLength = 150
        Me.TxtMemo1.Multiline = True
        Me.TxtMemo1.Name = "TxtMemo1"
        Me.TxtMemo1.ReadOnly = True
        Me.TxtMemo1.Size = New System.Drawing.Size(941, 21)
        Me.TxtMemo1.TabIndex = 21
        Me.TxtMemo1.Text = "1、本报价自即日起1个月内有效；"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(43, 106)
        Me.Panel5.TabIndex = 25
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "备注"
        '
        'BtnSaveAs
        '
        Me.BtnSaveAs.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnSaveAs.Location = New System.Drawing.Point(605, 143)
        Me.BtnSaveAs.Name = "BtnSaveAs"
        Me.BtnSaveAs.Size = New System.Drawing.Size(75, 23)
        Me.BtnSaveAs.TabIndex = 35
        Me.BtnSaveAs.Text = "另存为…"
        '
        'BtnToEmail
        '
        Me.BtnToEmail.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnToEmail.Location = New System.Drawing.Point(680, 143)
        Me.BtnToEmail.Name = "BtnToEmail"
        Me.BtnToEmail.Size = New System.Drawing.Size(75, 23)
        Me.BtnToEmail.TabIndex = 33
        Me.BtnToEmail.Text = "发送&Email"
        '
        'LblJzr
        '
        Me.LblJzr.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblJzr.AutoSize = True
        Me.LblJzr.Location = New System.Drawing.Point(659, 119)
        Me.LblJzr.Name = "LblJzr"
        Me.LblJzr.Size = New System.Drawing.Size(41, 12)
        Me.LblJzr.TabIndex = 32
        Me.LblJzr.Text = "记账："
        '
        'LblShr
        '
        Me.LblShr.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblShr.AutoSize = True
        Me.LblShr.Location = New System.Drawing.Point(419, 119)
        Me.LblShr.Name = "LblShr"
        Me.LblShr.Size = New System.Drawing.Size(41, 12)
        Me.LblShr.TabIndex = 31
        Me.LblShr.Text = "审核："
        '
        'LblSrr
        '
        Me.LblSrr.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblSrr.AutoSize = True
        Me.LblSrr.Location = New System.Drawing.Point(187, 119)
        Me.LblSrr.Name = "LblSrr"
        Me.LblSrr.Size = New System.Drawing.Size(41, 12)
        Me.LblSrr.TabIndex = 30
        Me.LblSrr.Text = "输入："
        '
        'BtnPrevious
        '
        Me.BtnPrevious.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnPrevious.Location = New System.Drawing.Point(380, 143)
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrevious.TabIndex = 22
        Me.BtnPrevious.Text = "上张(&F)"
        '
        'BtnNext
        '
        Me.BtnNext.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnNext.Location = New System.Drawing.Point(455, 143)
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(75, 23)
        Me.BtnNext.TabIndex = 23
        Me.BtnNext.Text = "下张(&B)"
        '
        'BtnExit
        '
        Me.BtnExit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnExit.Location = New System.Drawing.Point(830, 143)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 23)
        Me.BtnExit.TabIndex = 26
        Me.BtnExit.Text = "退出(&X)"
        '
        'BtnSh
        '
        Me.BtnSh.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnSh.Location = New System.Drawing.Point(80, 143)
        Me.BtnSh.Name = "BtnSh"
        Me.BtnSh.Size = New System.Drawing.Size(75, 23)
        Me.BtnSh.TabIndex = 18
        Me.BtnSh.Text = "审核(&S)"
        '
        'BtnPrint
        '
        Me.BtnPrint.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnPrint.Location = New System.Drawing.Point(530, 143)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrint.TabIndex = 24
        Me.BtnPrint.Text = "打印(&P)"
        '
        'BtnHelp
        '
        Me.BtnHelp.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnHelp.Location = New System.Drawing.Point(755, 143)
        Me.BtnHelp.Name = "BtnHelp"
        Me.BtnHelp.Size = New System.Drawing.Size(75, 23)
        Me.BtnHelp.TabIndex = 25
        Me.BtnHelp.Text = "帮助(&H)"
        '
        'BtnQs
        '
        Me.BtnQs.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnQs.Location = New System.Drawing.Point(230, 143)
        Me.BtnQs.Name = "BtnQs"
        Me.BtnQs.Size = New System.Drawing.Size(75, 23)
        Me.BtnQs.TabIndex = 20
        Me.BtnQs.Text = "全审(&Q)"
        '
        'BtnQx
        '
        Me.BtnQx.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnQx.Location = New System.Drawing.Point(305, 143)
        Me.BtnQx.Name = "BtnQx"
        Me.BtnQx.Size = New System.Drawing.Size(75, 23)
        Me.BtnQx.TabIndex = 21
        Me.BtnQx.Text = "全消(&Y)"
        '
        'BtnXs
        '
        Me.BtnXs.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnXs.Location = New System.Drawing.Point(155, 143)
        Me.BtnXs.Name = "BtnXs"
        Me.BtnXs.Size = New System.Drawing.Size(75, 23)
        Me.BtnXs.TabIndex = 19
        Me.BtnXs.Text = "消审(&C)"
        '
        'rcDataGridView
        '
        Me.rcDataGridView.AllowUserToAddRows = False
        Me.rcDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.rcDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColKhlh, Me.ColKhcz, Me.ColCpdm, Me.ColCpmc, Me.ColCpgg, Me.ColDw, Me.ColZl, Me.ColDj, Me.ColSpq, Me.ColMoq, Me.ColBjmemo})
        Me.rcDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rcDataGridView.Location = New System.Drawing.Point(0, 214)
        Me.rcDataGridView.Name = "rcDataGridView"
        Me.rcDataGridView.ReadOnly = True
        Me.rcDataGridView.RowTemplate.Height = 23
        Me.rcDataGridView.Size = New System.Drawing.Size(984, 169)
        Me.rcDataGridView.TabIndex = 28
        '
        'ColKhlh
        '
        Me.ColKhlh.DataPropertyName = "khlh"
        Me.ColKhlh.HeaderText = "客户料号"
        Me.ColKhlh.MaxInputLength = 50
        Me.ColKhlh.Name = "ColKhlh"
        Me.ColKhlh.ReadOnly = True
        Me.ColKhlh.Width = 90
        '
        'ColKhcz
        '
        Me.ColKhcz.DataPropertyName = "khcz"
        Me.ColKhcz.HeaderText = "客户材质"
        Me.ColKhcz.MaxInputLength = 30
        Me.ColKhcz.Name = "ColKhcz"
        Me.ColKhcz.ReadOnly = True
        Me.ColKhcz.Width = 90
        '
        'ColCpdm
        '
        Me.ColCpdm.DataPropertyName = "cpdm"
        Me.ColCpdm.HeaderText = "产品编码"
        Me.ColCpdm.MaxInputLength = 15
        Me.ColCpdm.Name = "ColCpdm"
        Me.ColCpdm.ReadOnly = True
        Me.ColCpdm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColCpdm.Width = 80
        '
        'ColCpmc
        '
        Me.ColCpmc.DataPropertyName = "cpmc"
        Me.ColCpmc.HeaderText = "东磁型号"
        Me.ColCpmc.MaxInputLength = 50
        Me.ColCpmc.Name = "ColCpmc"
        Me.ColCpmc.ReadOnly = True
        Me.ColCpmc.Width = 135
        '
        'ColCpgg
        '
        Me.ColCpgg.DataPropertyName = "cpgg"
        Me.ColCpgg.HeaderText = "规格型号"
        Me.ColCpgg.MaxInputLength = 50
        Me.ColCpgg.Name = "ColCpgg"
        Me.ColCpgg.ReadOnly = True
        Me.ColCpgg.Width = 90
        '
        'ColDw
        '
        Me.ColDw.DataPropertyName = "dw"
        Me.ColDw.HeaderText = "单位"
        Me.ColDw.MaxInputLength = 10
        Me.ColDw.Name = "ColDw"
        Me.ColDw.ReadOnly = True
        Me.ColDw.Width = 35
        '
        'ColZl
        '
        Me.ColZl.DataPropertyName = "zl"
        Me.ColZl.HeaderText = "重量"
        Me.ColZl.MaxInputLength = 18
        Me.ColZl.Name = "ColZl"
        Me.ColZl.ReadOnly = True
        Me.ColZl.Width = 80
        '
        'ColDj
        '
        Me.ColDj.DataPropertyName = "dj"
        Me.ColDj.HeaderText = "单价"
        Me.ColDj.MaxInputLength = 18
        Me.ColDj.Name = "ColDj"
        Me.ColDj.ReadOnly = True
        Me.ColDj.Width = 80
        '
        'ColSpq
        '
        Me.ColSpq.DataPropertyName = "spq"
        Me.ColSpq.HeaderText = "最小包装量"
        Me.ColSpq.Name = "ColSpq"
        Me.ColSpq.ReadOnly = True
        Me.ColSpq.Width = 90
        '
        'ColMoq
        '
        Me.ColMoq.DataPropertyName = "moq"
        Me.ColMoq.HeaderText = "最小订单量"
        Me.ColMoq.Name = "ColMoq"
        Me.ColMoq.ReadOnly = True
        Me.ColMoq.Width = 90
        '
        'ColBjmemo
        '
        Me.ColBjmemo.DataPropertyName = "bjmemo"
        Me.ColBjmemo.HeaderText = "备注"
        Me.ColBjmemo.MaxInputLength = 50
        Me.ColBjmemo.Name = "ColBjmemo"
        Me.ColBjmemo.ReadOnly = True
        Me.ColBjmemo.Width = 135
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.LblBjd)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(984, 48)
        Me.Panel3.TabIndex = 0
        '
        'LblBjd
        '
        Me.LblBjd.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblBjd.AutoSize = True
        Me.LblBjd.Font = New System.Drawing.Font("华文行楷", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblBjd.ForeColor = System.Drawing.Color.SteelBlue
        Me.LblBjd.Location = New System.Drawing.Point(438, 9)
        Me.LblBjd.Name = "LblBjd"
        Me.LblBjd.Size = New System.Drawing.Size(115, 25)
        Me.LblBjd.TabIndex = 0
        Me.LblBjd.Text = "报  价  单"
        '
        'LblDjh
        '
        Me.LblDjh.AutoSize = True
        Me.LblDjh.Location = New System.Drawing.Point(24, 67)
        Me.LblDjh.Name = "LblDjh"
        Me.LblDjh.Size = New System.Drawing.Size(65, 12)
        Me.LblDjh.TabIndex = 48
        Me.LblDjh.Text = "单 据 号："
        '
        'TxtDjh
        '
        Me.TxtDjh.Enabled = False
        Me.TxtDjh.Location = New System.Drawing.Point(96, 63)
        Me.TxtDjh.MaxLength = 15
        Me.TxtDjh.Name = "TxtDjh"
        Me.TxtDjh.Size = New System.Drawing.Size(104, 21)
        Me.TxtDjh.TabIndex = 50
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FloralWhite
        Me.Panel1.Controls.Add(Me.TxtWbhl)
        Me.Panel1.Controls.Add(Me.LblWbhl)
        Me.Panel1.Controls.Add(Me.TxtWbdm)
        Me.Panel1.Controls.Add(Me.LblWbdm)
        Me.Panel1.Controls.Add(Me.TxtEmail)
        Me.Panel1.Controls.Add(Me.LblEmail)
        Me.Panel1.Controls.Add(Me.LblZymc)
        Me.Panel1.Controls.Add(Me.TxtZydm)
        Me.Panel1.Controls.Add(Me.LblZydm)
        Me.Panel1.Controls.Add(Me.TxtBjtk)
        Me.Panel1.Controls.Add(Me.LblBjtk)
        Me.Panel1.Controls.Add(Me.LblKhmc)
        Me.Panel1.Controls.Add(Me.TxtKhdm)
        Me.Panel1.Controls.Add(Me.LblKhdm)
        Me.Panel1.Controls.Add(Me.LblBjrq)
        Me.Panel1.Controls.Add(Me.DtpBjrq)
        Me.Panel1.Controls.Add(Me.TxtDjh)
        Me.Panel1.Controls.Add(Me.LblDjh)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(984, 189)
        Me.Panel1.TabIndex = 3
        '
        'TxtWbhl
        '
        Me.TxtWbhl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtWbhl.Enabled = False
        Me.TxtWbhl.Location = New System.Drawing.Point(892, 63)
        Me.TxtWbhl.MaxLength = 18
        Me.TxtWbhl.Name = "TxtWbhl"
        Me.TxtWbhl.Size = New System.Drawing.Size(80, 21)
        Me.TxtWbhl.TabIndex = 56
        Me.TxtWbhl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblWbhl
        '
        Me.LblWbhl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblWbhl.AutoSize = True
        Me.LblWbhl.Location = New System.Drawing.Point(844, 67)
        Me.LblWbhl.Name = "LblWbhl"
        Me.LblWbhl.Size = New System.Drawing.Size(41, 12)
        Me.LblWbhl.TabIndex = 55
        Me.LblWbhl.Text = "汇率："
        '
        'TxtWbdm
        '
        Me.TxtWbdm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtWbdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtWbdm.Enabled = False
        Me.TxtWbdm.Location = New System.Drawing.Point(764, 63)
        Me.TxtWbdm.MaxLength = 4
        Me.TxtWbdm.Name = "TxtWbdm"
        Me.TxtWbdm.Size = New System.Drawing.Size(40, 21)
        Me.TxtWbdm.TabIndex = 54
        '
        'LblWbdm
        '
        Me.LblWbdm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblWbdm.AutoSize = True
        Me.LblWbdm.Location = New System.Drawing.Point(709, 67)
        Me.LblWbdm.Name = "LblWbdm"
        Me.LblWbdm.Size = New System.Drawing.Size(41, 12)
        Me.LblWbdm.TabIndex = 53
        Me.LblWbdm.Text = "币种："
        '
        'TxtEmail
        '
        Me.TxtEmail.Enabled = False
        Me.TxtEmail.Location = New System.Drawing.Point(96, 121)
        Me.TxtEmail.MaxLength = 150
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(674, 21)
        Me.TxtEmail.TabIndex = 64
        '
        'LblEmail
        '
        Me.LblEmail.AutoSize = True
        Me.LblEmail.Location = New System.Drawing.Point(42, 125)
        Me.LblEmail.Name = "LblEmail"
        Me.LblEmail.Size = New System.Drawing.Size(47, 12)
        Me.LblEmail.TabIndex = 63
        Me.LblEmail.Text = "Email："
        '
        'LblZymc
        '
        Me.LblZymc.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblZymc.AutoSize = True
        Me.LblZymc.Location = New System.Drawing.Point(564, 96)
        Me.LblZymc.Name = "LblZymc"
        Me.LblZymc.Size = New System.Drawing.Size(0, 12)
        Me.LblZymc.TabIndex = 62
        '
        'TxtZydm
        '
        Me.TxtZydm.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtZydm.Enabled = False
        Me.TxtZydm.Location = New System.Drawing.Point(468, 92)
        Me.TxtZydm.MaxLength = 12
        Me.TxtZydm.Name = "TxtZydm"
        Me.TxtZydm.Size = New System.Drawing.Size(88, 21)
        Me.TxtZydm.TabIndex = 61
        '
        'LblZydm
        '
        Me.LblZydm.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblZydm.AutoSize = True
        Me.LblZydm.Location = New System.Drawing.Point(396, 96)
        Me.LblZydm.Name = "LblZydm"
        Me.LblZydm.Size = New System.Drawing.Size(65, 12)
        Me.LblZydm.TabIndex = 60
        Me.LblZydm.Text = "业 务 员："
        '
        'TxtBjtk
        '
        Me.TxtBjtk.Enabled = False
        Me.TxtBjtk.Location = New System.Drawing.Point(96, 150)
        Me.TxtBjtk.MaxLength = 150
        Me.TxtBjtk.Multiline = True
        Me.TxtBjtk.Name = "TxtBjtk"
        Me.TxtBjtk.Size = New System.Drawing.Size(876, 21)
        Me.TxtBjtk.TabIndex = 67
        '
        'LblBjtk
        '
        Me.LblBjtk.AutoSize = True
        Me.LblBjtk.Location = New System.Drawing.Point(24, 154)
        Me.LblBjtk.Name = "LblBjtk"
        Me.LblBjtk.Size = New System.Drawing.Size(65, 12)
        Me.LblBjtk.TabIndex = 66
        Me.LblBjtk.Text = "报价条款："
        '
        'LblKhmc
        '
        Me.LblKhmc.AutoSize = True
        Me.LblKhmc.Location = New System.Drawing.Point(192, 96)
        Me.LblKhmc.Name = "LblKhmc"
        Me.LblKhmc.Size = New System.Drawing.Size(0, 12)
        Me.LblKhmc.TabIndex = 59
        '
        'TxtKhdm
        '
        Me.TxtKhdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtKhdm.Enabled = False
        Me.TxtKhdm.Location = New System.Drawing.Point(96, 92)
        Me.TxtKhdm.MaxLength = 12
        Me.TxtKhdm.Name = "TxtKhdm"
        Me.TxtKhdm.Size = New System.Drawing.Size(88, 21)
        Me.TxtKhdm.TabIndex = 58
        '
        'LblKhdm
        '
        Me.LblKhdm.AutoSize = True
        Me.LblKhdm.Location = New System.Drawing.Point(24, 96)
        Me.LblKhdm.Name = "LblKhdm"
        Me.LblKhdm.Size = New System.Drawing.Size(65, 12)
        Me.LblKhdm.TabIndex = 57
        Me.LblKhdm.Text = "客户编码："
        '
        'LblBjrq
        '
        Me.LblBjrq.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblBjrq.AutoSize = True
        Me.LblBjrq.Location = New System.Drawing.Point(396, 67)
        Me.LblBjrq.Name = "LblBjrq"
        Me.LblBjrq.Size = New System.Drawing.Size(65, 12)
        Me.LblBjrq.TabIndex = 51
        Me.LblBjrq.Text = "报价日期："
        '
        'DtpBjrq
        '
        Me.DtpBjrq.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.DtpBjrq.Enabled = False
        Me.DtpBjrq.Location = New System.Drawing.Point(468, 63)
        Me.DtpBjrq.Name = "DtpBjrq"
        Me.DtpBjrq.Size = New System.Drawing.Size(112, 21)
        Me.DtpBjrq.TabIndex = 52
        '
        'TxtMemo5
        '
        Me.TxtMemo5.Dock = System.Windows.Forms.DockStyle.Top
        Me.TxtMemo5.Location = New System.Drawing.Point(43, 84)
        Me.TxtMemo5.MaxLength = 150
        Me.TxtMemo5.Multiline = True
        Me.TxtMemo5.Name = "TxtMemo5"
        Me.TxtMemo5.ReadOnly = True
        Me.TxtMemo5.Size = New System.Drawing.Size(941, 21)
        Me.TxtMemo5.TabIndex = 26
        Me.TxtMemo5.Text = "5、无特殊说明，报价为东磁标准包装。"
        '
        'FrmOeBjdShz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.rcDataGridView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MnuMain)
        Me.Name = "FrmOeBjdShz"
        Me.Text = "报价单审核"
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rcPrintDocument As System.Drawing.Printing.PrintDocument
    Friend WithEvents MnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuiFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiSh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiXs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiQs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiQx As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Mnui11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuiPrevious As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiNext As System.Windows.Forms.ToolStripMenuItem
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
    Friend WithEvents rcDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ColKhlh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKhcz As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCpdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCpmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCpgg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDw As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColZl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSpq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMoq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBjmemo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents LblBjd As System.Windows.Forms.Label
    Public WithEvents LblDjh As System.Windows.Forms.Label
    Public WithEvents TxtDjh As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents TxtWbhl As System.Windows.Forms.TextBox
    Public WithEvents LblWbhl As System.Windows.Forms.Label
    Public WithEvents TxtWbdm As System.Windows.Forms.TextBox
    Public WithEvents LblWbdm As System.Windows.Forms.Label
    Public WithEvents TxtEmail As System.Windows.Forms.TextBox
    Public WithEvents LblEmail As System.Windows.Forms.Label
    Public WithEvents LblZymc As System.Windows.Forms.Label
    Public WithEvents TxtZydm As System.Windows.Forms.TextBox
    Public WithEvents LblZydm As System.Windows.Forms.Label
    Public WithEvents TxtBjtk As System.Windows.Forms.TextBox
    Public WithEvents LblBjtk As System.Windows.Forms.Label
    Public WithEvents LblKhmc As System.Windows.Forms.Label
    Public WithEvents TxtKhdm As System.Windows.Forms.TextBox
    Public WithEvents LblKhdm As System.Windows.Forms.Label
    Public WithEvents LblBjrq As System.Windows.Forms.Label
    Public WithEvents DtpBjrq As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnToEmail As System.Windows.Forms.Button
    Friend WithEvents BtnSaveAs As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Public WithEvents TxtMemo4 As System.Windows.Forms.TextBox
    Public WithEvents TxtMemo3 As System.Windows.Forms.TextBox
    Public WithEvents TxtMemo2 As System.Windows.Forms.TextBox
    Public WithEvents TxtMemo1 As System.Windows.Forms.TextBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents TxtMemo5 As System.Windows.Forms.TextBox
End Class
