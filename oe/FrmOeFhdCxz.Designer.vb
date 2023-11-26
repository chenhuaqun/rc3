<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeFhdCxz
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
        Me.MnuMain = New System.Windows.Forms.MenuStrip
        Me.MnuiFile = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiTop = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiPrevious = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiNext = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiBottom = New System.Windows.Forms.ToolStripMenuItem
        Me.Mnui11 = New System.Windows.Forms.ToolStripSeparator
        Me.MnuiPageSetup = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiPrintView = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiPrint = New System.Windows.Forms.ToolStripMenuItem
        Me.Mnui12 = New System.Windows.Forms.ToolStripSeparator
        Me.MnuiExit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiCut = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiCopy = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiPaste = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiHelp = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblCkmc = New System.Windows.Forms.Label
        Me.TxtCkdm = New System.Windows.Forms.TextBox
        Me.LblCkdm = New System.Windows.Forms.Label
        Me.LblKhmc = New System.Windows.Forms.Label
        Me.TxtKhdm = New System.Windows.Forms.TextBox
        Me.LblKhdm = New System.Windows.Forms.Label
        Me.LblZymc = New System.Windows.Forms.Label
        Me.LblFhrq = New System.Windows.Forms.Label
        Me.DtpFhrq = New System.Windows.Forms.DateTimePicker
        Me.TxtDjh = New System.Windows.Forms.TextBox
        Me.LblDjh = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.LblBdelete = New System.Windows.Forms.Label
        Me.LblDd = New System.Windows.Forms.Label
        Me.TxtZydm = New System.Windows.Forms.TextBox
        Me.LblZydm = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.LblFzsl = New System.Windows.Forms.Label
        Me.LblSl = New System.Windows.Forms.Label
        Me.BtnPrintView = New System.Windows.Forms.Button
        Me.LblJzr = New System.Windows.Forms.Label
        Me.LblShr = New System.Windows.Forms.Label
        Me.LblSrr = New System.Windows.Forms.Label
        Me.BtnExit = New System.Windows.Forms.Button
        Me.BtnTop = New System.Windows.Forms.Button
        Me.BtnPrint = New System.Windows.Forms.Button
        Me.BtnHelp = New System.Windows.Forms.Button
        Me.BtnNext = New System.Windows.Forms.Button
        Me.BtnBottom = New System.Windows.Forms.Button
        Me.BtnPrevious = New System.Windows.Forms.Button
        Me.rcDataGridView = New System.Windows.Forms.DataGridView
        Me.ColCpdm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCpmc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColHth = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColKhddh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColKhlh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColSl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColDw = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColMjsl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColFzsl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColFzdw = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColFhmemo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStripPanel1.SuspendLayout()
        Me.MnuMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.MnuiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiTop, Me.MnuiPrevious, Me.MnuiNext, Me.MnuiBottom, Me.Mnui11, Me.MnuiPageSetup, Me.MnuiPrintView, Me.MnuiPrint, Me.Mnui12, Me.MnuiExit})
        Me.MnuiFile.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiFile.Name = "MnuiFile"
        Me.MnuiFile.Size = New System.Drawing.Size(58, 21)
        Me.MnuiFile.Text = "文件(&F)"
        '
        'MnuiTop
        '
        Me.MnuiTop.Name = "MnuiTop"
        Me.MnuiTop.Size = New System.Drawing.Size(160, 22)
        Me.MnuiTop.Text = "首张(&S)"
        '
        'MnuiPrevious
        '
        Me.MnuiPrevious.Name = "MnuiPrevious"
        Me.MnuiPrevious.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.MnuiPrevious.Size = New System.Drawing.Size(160, 22)
        Me.MnuiPrevious.Text = "上张(&C)"
        '
        'MnuiNext
        '
        Me.MnuiNext.Name = "MnuiNext"
        Me.MnuiNext.Size = New System.Drawing.Size(160, 22)
        Me.MnuiNext.Text = "下张(&Q)"
        '
        'MnuiBottom
        '
        Me.MnuiBottom.Name = "MnuiBottom"
        Me.MnuiBottom.Size = New System.Drawing.Size(160, 22)
        Me.MnuiBottom.Text = "末张(&Y)"
        '
        'Mnui11
        '
        Me.Mnui11.Name = "Mnui11"
        Me.Mnui11.Size = New System.Drawing.Size(157, 6)
        '
        'MnuiPageSetup
        '
        Me.MnuiPageSetup.Name = "MnuiPageSetup"
        Me.MnuiPageSetup.Size = New System.Drawing.Size(160, 22)
        Me.MnuiPageSetup.Text = "页面设置(&U)"
        '
        'MnuiPrintView
        '
        Me.MnuiPrintView.Name = "MnuiPrintView"
        Me.MnuiPrintView.Size = New System.Drawing.Size(160, 22)
        Me.MnuiPrintView.Text = "打印预览(&V)"
        '
        'MnuiPrint
        '
        Me.MnuiPrint.Name = "MnuiPrint"
        Me.MnuiPrint.Size = New System.Drawing.Size(160, 22)
        Me.MnuiPrint.Text = "打印(&P)"
        '
        'Mnui12
        '
        Me.Mnui12.Name = "Mnui12"
        Me.Mnui12.Size = New System.Drawing.Size(157, 6)
        '
        'MnuiExit
        '
        Me.MnuiExit.Name = "MnuiExit"
        Me.MnuiExit.Size = New System.Drawing.Size(160, 22)
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FloralWhite
        Me.Panel1.Controls.Add(Me.LblCkmc)
        Me.Panel1.Controls.Add(Me.TxtCkdm)
        Me.Panel1.Controls.Add(Me.LblCkdm)
        Me.Panel1.Controls.Add(Me.LblKhmc)
        Me.Panel1.Controls.Add(Me.TxtKhdm)
        Me.Panel1.Controls.Add(Me.LblKhdm)
        Me.Panel1.Controls.Add(Me.LblZymc)
        Me.Panel1.Controls.Add(Me.LblFhrq)
        Me.Panel1.Controls.Add(Me.DtpFhrq)
        Me.Panel1.Controls.Add(Me.TxtDjh)
        Me.Panel1.Controls.Add(Me.LblDjh)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.TxtZydm)
        Me.Panel1.Controls.Add(Me.LblZydm)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(984, 117)
        Me.Panel1.TabIndex = 2
        '
        'LblCkmc
        '
        Me.LblCkmc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCkmc.AutoSize = True
        Me.LblCkmc.Location = New System.Drawing.Point(915, 90)
        Me.LblCkmc.Name = "LblCkmc"
        Me.LblCkmc.Size = New System.Drawing.Size(0, 12)
        Me.LblCkmc.TabIndex = 31
        '
        'TxtCkdm
        '
        Me.TxtCkdm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCkdm.Enabled = False
        Me.TxtCkdm.Location = New System.Drawing.Point(807, 83)
        Me.TxtCkdm.MaxLength = 30
        Me.TxtCkdm.Name = "TxtCkdm"
        Me.TxtCkdm.Size = New System.Drawing.Size(87, 21)
        Me.TxtCkdm.TabIndex = 30
        '
        'LblCkdm
        '
        Me.LblCkdm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCkdm.AutoSize = True
        Me.LblCkdm.Location = New System.Drawing.Point(735, 87)
        Me.LblCkdm.Name = "LblCkdm"
        Me.LblCkdm.Size = New System.Drawing.Size(65, 12)
        Me.LblCkdm.TabIndex = 29
        Me.LblCkdm.Text = "仓库编码："
        '
        'LblKhmc
        '
        Me.LblKhmc.AutoSize = True
        Me.LblKhmc.Location = New System.Drawing.Point(184, 87)
        Me.LblKhmc.Name = "LblKhmc"
        Me.LblKhmc.Size = New System.Drawing.Size(0, 12)
        Me.LblKhmc.TabIndex = 10
        '
        'TxtKhdm
        '
        Me.TxtKhdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtKhdm.Enabled = False
        Me.TxtKhdm.Location = New System.Drawing.Point(88, 83)
        Me.TxtKhdm.MaxLength = 12
        Me.TxtKhdm.Name = "TxtKhdm"
        Me.TxtKhdm.Size = New System.Drawing.Size(87, 21)
        Me.TxtKhdm.TabIndex = 9
        '
        'LblKhdm
        '
        Me.LblKhdm.AutoSize = True
        Me.LblKhdm.Location = New System.Drawing.Point(16, 87)
        Me.LblKhdm.Name = "LblKhdm"
        Me.LblKhdm.Size = New System.Drawing.Size(65, 12)
        Me.LblKhdm.TabIndex = 8
        Me.LblKhdm.Text = "客户编码："
        '
        'LblZymc
        '
        Me.LblZymc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblZymc.AutoSize = True
        Me.LblZymc.Location = New System.Drawing.Point(901, 59)
        Me.LblZymc.Name = "LblZymc"
        Me.LblZymc.Size = New System.Drawing.Size(0, 12)
        Me.LblZymc.TabIndex = 13
        '
        'LblFhrq
        '
        Me.LblFhrq.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblFhrq.AutoSize = True
        Me.LblFhrq.Location = New System.Drawing.Point(396, 59)
        Me.LblFhrq.Name = "LblFhrq"
        Me.LblFhrq.Size = New System.Drawing.Size(65, 12)
        Me.LblFhrq.TabIndex = 4
        Me.LblFhrq.Text = "发货日期："
        '
        'DtpFhrq
        '
        Me.DtpFhrq.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.DtpFhrq.Enabled = False
        Me.DtpFhrq.Location = New System.Drawing.Point(468, 55)
        Me.DtpFhrq.Name = "DtpFhrq"
        Me.DtpFhrq.Size = New System.Drawing.Size(112, 21)
        Me.DtpFhrq.TabIndex = 5
        '
        'TxtDjh
        '
        Me.TxtDjh.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDjh.Enabled = False
        Me.TxtDjh.Location = New System.Drawing.Point(88, 55)
        Me.TxtDjh.MaxLength = 15
        Me.TxtDjh.Name = "TxtDjh"
        Me.TxtDjh.Size = New System.Drawing.Size(104, 21)
        Me.TxtDjh.TabIndex = 3
        '
        'LblDjh
        '
        Me.LblDjh.AutoSize = True
        Me.LblDjh.Location = New System.Drawing.Point(16, 59)
        Me.LblDjh.Name = "LblDjh"
        Me.LblDjh.Size = New System.Drawing.Size(65, 12)
        Me.LblDjh.TabIndex = 1
        Me.LblDjh.Text = "单 据 号："
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.LblBdelete)
        Me.Panel3.Controls.Add(Me.LblDd)
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
        Me.LblBdelete.Location = New System.Drawing.Point(836, 9)
        Me.LblBdelete.Name = "LblBdelete"
        Me.LblBdelete.Size = New System.Drawing.Size(60, 24)
        Me.LblBdelete.TabIndex = 3
        Me.LblBdelete.Text = "作废"
        '
        'LblDd
        '
        Me.LblDd.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblDd.AutoSize = True
        Me.LblDd.Font = New System.Drawing.Font("楷体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblDd.ForeColor = System.Drawing.Color.SteelBlue
        Me.LblDd.Location = New System.Drawing.Point(425, 9)
        Me.LblDd.Name = "LblDd"
        Me.LblDd.Size = New System.Drawing.Size(135, 24)
        Me.LblDd.TabIndex = 0
        Me.LblDd.Text = "发货通知书"
        '
        'TxtZydm
        '
        Me.TxtZydm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtZydm.Enabled = False
        Me.TxtZydm.Location = New System.Drawing.Point(807, 55)
        Me.TxtZydm.MaxLength = 15
        Me.TxtZydm.Name = "TxtZydm"
        Me.TxtZydm.Size = New System.Drawing.Size(87, 21)
        Me.TxtZydm.TabIndex = 12
        '
        'LblZydm
        '
        Me.LblZydm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblZydm.AutoSize = True
        Me.LblZydm.Location = New System.Drawing.Point(735, 59)
        Me.LblZydm.Name = "LblZydm"
        Me.LblZydm.Size = New System.Drawing.Size(65, 12)
        Me.LblZydm.TabIndex = 11
        Me.LblZydm.Text = "业 务 员："
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.BtnPrintView)
        Me.Panel2.Controls.Add(Me.LblJzr)
        Me.Panel2.Controls.Add(Me.LblShr)
        Me.Panel2.Controls.Add(Me.LblSrr)
        Me.Panel2.Controls.Add(Me.BtnExit)
        Me.Panel2.Controls.Add(Me.BtnTop)
        Me.Panel2.Controls.Add(Me.BtnPrint)
        Me.Panel2.Controls.Add(Me.BtnHelp)
        Me.Panel2.Controls.Add(Me.BtnNext)
        Me.Panel2.Controls.Add(Me.BtnBottom)
        Me.Panel2.Controls.Add(Me.BtnPrevious)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 462)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(984, 99)
        Me.Panel2.TabIndex = 7
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.LblFzsl)
        Me.Panel4.Controls.Add(Me.LblSl)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(984, 39)
        Me.Panel4.TabIndex = 11
        '
        'LblFzsl
        '
        Me.LblFzsl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblFzsl.AutoSize = True
        Me.LblFzsl.Location = New System.Drawing.Point(756, 13)
        Me.LblFzsl.Name = "LblFzsl"
        Me.LblFzsl.Size = New System.Drawing.Size(77, 12)
        Me.LblFzsl.TabIndex = 13
        Me.LblFzsl.Text = "辅数量合计："
        '
        'LblSl
        '
        Me.LblSl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSl.AutoSize = True
        Me.LblSl.Location = New System.Drawing.Point(576, 13)
        Me.LblSl.Name = "LblSl"
        Me.LblSl.Size = New System.Drawing.Size(65, 12)
        Me.LblSl.TabIndex = 10
        Me.LblSl.Text = "数量合计："
        '
        'BtnPrintView
        '
        Me.BtnPrintView.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnPrintView.Location = New System.Drawing.Point(637, 67)
        Me.BtnPrintView.Name = "BtnPrintView"
        Me.BtnPrintView.Size = New System.Drawing.Size(64, 23)
        Me.BtnPrintView.TabIndex = 8
        Me.BtnPrintView.Text = "预览(&V)"
        '
        'LblJzr
        '
        Me.LblJzr.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblJzr.AutoSize = True
        Me.LblJzr.Location = New System.Drawing.Point(664, 42)
        Me.LblJzr.Name = "LblJzr"
        Me.LblJzr.Size = New System.Drawing.Size(41, 12)
        Me.LblJzr.TabIndex = 2
        Me.LblJzr.Text = "记账："
        '
        'LblShr
        '
        Me.LblShr.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblShr.AutoSize = True
        Me.LblShr.Location = New System.Drawing.Point(416, 42)
        Me.LblShr.Name = "LblShr"
        Me.LblShr.Size = New System.Drawing.Size(41, 12)
        Me.LblShr.TabIndex = 1
        Me.LblShr.Text = "审核："
        '
        'LblSrr
        '
        Me.LblSrr.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblSrr.AutoSize = True
        Me.LblSrr.Location = New System.Drawing.Point(176, 42)
        Me.LblSrr.Name = "LblSrr"
        Me.LblSrr.Size = New System.Drawing.Size(41, 12)
        Me.LblSrr.TabIndex = 0
        Me.LblSrr.Text = "输入："
        '
        'BtnExit
        '
        Me.BtnExit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnExit.Location = New System.Drawing.Point(792, 67)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 23)
        Me.BtnExit.TabIndex = 10
        Me.BtnExit.Text = "退出(&X)"
        '
        'BtnTop
        '
        Me.BtnTop.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnTop.Location = New System.Drawing.Point(142, 67)
        Me.BtnTop.Name = "BtnTop"
        Me.BtnTop.Size = New System.Drawing.Size(75, 23)
        Me.BtnTop.TabIndex = 3
        Me.BtnTop.Text = "首张(&S)"
        '
        'BtnPrint
        '
        Me.BtnPrint.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnPrint.Location = New System.Drawing.Point(554, 67)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrint.TabIndex = 7
        Me.BtnPrint.Text = "打印(&P)"
        '
        'BtnHelp
        '
        Me.BtnHelp.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnHelp.Location = New System.Drawing.Point(709, 67)
        Me.BtnHelp.Name = "BtnHelp"
        Me.BtnHelp.Size = New System.Drawing.Size(75, 23)
        Me.BtnHelp.TabIndex = 9
        Me.BtnHelp.Text = "帮助(&H)"
        '
        'BtnNext
        '
        Me.BtnNext.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnNext.Location = New System.Drawing.Point(302, 67)
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(75, 23)
        Me.BtnNext.TabIndex = 5
        Me.BtnNext.Text = "下张(&Q)"
        '
        'BtnBottom
        '
        Me.BtnBottom.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnBottom.Location = New System.Drawing.Point(382, 67)
        Me.BtnBottom.Name = "BtnBottom"
        Me.BtnBottom.Size = New System.Drawing.Size(75, 23)
        Me.BtnBottom.TabIndex = 6
        Me.BtnBottom.Text = "末张(&Y)"
        '
        'BtnPrevious
        '
        Me.BtnPrevious.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnPrevious.Location = New System.Drawing.Point(222, 67)
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrevious.TabIndex = 4
        Me.BtnPrevious.Text = "上张(&C)"
        '
        'rcDataGridView
        '
        Me.rcDataGridView.AllowUserToAddRows = False
        Me.rcDataGridView.ColumnHeadersHeight = 30
        Me.rcDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColCpdm, Me.ColCpmc, Me.ColHth, Me.ColKhddh, Me.ColKhlh, Me.ColSl, Me.ColDw, Me.ColMjsl, Me.ColFzsl, Me.ColFzdw, Me.ColFhmemo})
        Me.rcDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rcDataGridView.Location = New System.Drawing.Point(0, 142)
        Me.rcDataGridView.Name = "rcDataGridView"
        Me.rcDataGridView.ReadOnly = True
        Me.rcDataGridView.RowTemplate.Height = 23
        Me.rcDataGridView.Size = New System.Drawing.Size(984, 320)
        Me.rcDataGridView.TabIndex = 8
        '
        'ColCpdm
        '
        Me.ColCpdm.DataPropertyName = "cpdm"
        Me.ColCpdm.HeaderText = "产品编码"
        Me.ColCpdm.Name = "ColCpdm"
        Me.ColCpdm.ReadOnly = True
        Me.ColCpdm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColCpdm.Width = 110
        '
        'ColCpmc
        '
        Me.ColCpmc.DataPropertyName = "cpmc"
        Me.ColCpmc.HeaderText = "产品描述"
        Me.ColCpmc.Name = "ColCpmc"
        Me.ColCpmc.ReadOnly = True
        Me.ColCpmc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColCpmc.Width = 240
        '
        'ColHth
        '
        Me.ColHth.DataPropertyName = "hth"
        Me.ColHth.HeaderText = "手工订单号"
        Me.ColHth.Name = "ColHth"
        Me.ColHth.ReadOnly = True
        Me.ColHth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColKhddh
        '
        Me.ColKhddh.DataPropertyName = "khddh"
        Me.ColKhddh.HeaderText = "客户订单号"
        Me.ColKhddh.Name = "ColKhddh"
        Me.ColKhddh.ReadOnly = True
        Me.ColKhddh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColKhlh
        '
        Me.ColKhlh.DataPropertyName = "khlh"
        Me.ColKhlh.HeaderText = "客户料号"
        Me.ColKhlh.MaxInputLength = 30
        Me.ColKhlh.Name = "ColKhlh"
        Me.ColKhlh.ReadOnly = True
        Me.ColKhlh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColSl
        '
        Me.ColSl.DataPropertyName = "sl"
        Me.ColSl.HeaderText = "数量"
        Me.ColSl.Name = "ColSl"
        Me.ColSl.ReadOnly = True
        Me.ColSl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColSl.Width = 90
        '
        'ColDw
        '
        Me.ColDw.DataPropertyName = "dw"
        Me.ColDw.HeaderText = "单位"
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
        'ColFhmemo
        '
        Me.ColFhmemo.DataPropertyName = "fhmemo"
        Me.ColFhmemo.HeaderText = "备注"
        Me.ColFhmemo.MaxInputLength = 50
        Me.ColFhmemo.Name = "ColFhmemo"
        Me.ColFhmemo.ReadOnly = True
        Me.ColFhmemo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColFhmemo.Width = 135
        '
        'FrmOeFhdCxz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.rcDataGridView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStripPanel1)
        Me.Name = "FrmOeFhdCxz"
        Me.Text = "发货通知书查询"
        Me.ToolStripPanel1.ResumeLayout(False)
        Me.ToolStripPanel1.PerformLayout()
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripPanel1 As System.Windows.Forms.ToolStripPanel
    Friend WithEvents MnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuiFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiTop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiPrevious As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiNext As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiBottom As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Mnui11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuiPageSetup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiPrintView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Mnui12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuiExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiCut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiPaste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents LblKhmc As System.Windows.Forms.Label
    Public WithEvents TxtKhdm As System.Windows.Forms.TextBox
    Public WithEvents LblKhdm As System.Windows.Forms.Label
    Public WithEvents LblZymc As System.Windows.Forms.Label
    Public WithEvents LblFhrq As System.Windows.Forms.Label
    Public WithEvents DtpFhrq As System.Windows.Forms.DateTimePicker
    Public WithEvents TxtDjh As System.Windows.Forms.TextBox
    Public WithEvents LblDjh As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents LblDd As System.Windows.Forms.Label
    Public WithEvents TxtZydm As System.Windows.Forms.TextBox
    Public WithEvents LblZydm As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents BtnTop As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents BtnHelp As System.Windows.Forms.Button
    Friend WithEvents BtnNext As System.Windows.Forms.Button
    Friend WithEvents BtnBottom As System.Windows.Forms.Button
    Friend WithEvents BtnPrevious As System.Windows.Forms.Button
    Friend WithEvents rcDataGridView As System.Windows.Forms.DataGridView
    Public WithEvents LblJzr As System.Windows.Forms.Label
    Public WithEvents LblShr As System.Windows.Forms.Label
    Public WithEvents LblSrr As System.Windows.Forms.Label
    Friend WithEvents BtnPrintView As System.Windows.Forms.Button
    Friend WithEvents LblBdelete As System.Windows.Forms.Label
    Public WithEvents LblCkmc As System.Windows.Forms.Label
    Public WithEvents TxtCkdm As System.Windows.Forms.TextBox
    Public WithEvents LblCkdm As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Public WithEvents LblFzsl As System.Windows.Forms.Label
    Public WithEvents LblSl As System.Windows.Forms.Label
    Friend WithEvents ColCpdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCpmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColHth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKhddh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKhlh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDw As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMjsl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFzsl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFzdw As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFhmemo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
