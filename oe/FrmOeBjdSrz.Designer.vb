<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeBjdSrz
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
        Me.rcPrintDocument = New System.Drawing.Printing.PrintDocument()
        Me.rcBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MnuMain = New System.Windows.Forms.MenuStrip()
        Me.MnuiFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mnui11 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuiIns = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mnui12 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuiEmailOption = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiImpXls = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtEmail = New System.Windows.Forms.TextBox()
        Me.LblEmail = New System.Windows.Forms.Label()
        Me.LblZymc = New System.Windows.Forms.Label()
        Me.TxtZydm = New System.Windows.Forms.TextBox()
        Me.LblZydm = New System.Windows.Forms.Label()
        Me.CmbPzlxjc = New System.Windows.Forms.ComboBox()
        Me.TxtBjtk = New System.Windows.Forms.TextBox()
        Me.LblBjtk = New System.Windows.Forms.Label()
        Me.LblKhmc = New System.Windows.Forms.Label()
        Me.TxtKhdm = New System.Windows.Forms.TextBox()
        Me.LblKhdm = New System.Windows.Forms.Label()
        Me.LblBjrq = New System.Windows.Forms.Label()
        Me.DtpBjrq = New System.Windows.Forms.DateTimePicker()
        Me.TxtDjh = New System.Windows.Forms.TextBox()
        Me.LblDjh = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.LblBjd = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.TxtMemo5 = New System.Windows.Forms.TextBox()
        Me.TxtMemo4 = New System.Windows.Forms.TextBox()
        Me.TxtMemo3 = New System.Windows.Forms.TextBox()
        Me.TxtMemo2 = New System.Windows.Forms.TextBox()
        Me.TxtMemo1 = New System.Windows.Forms.TextBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnSaveAs = New System.Windows.Forms.Button()
        Me.BtnToEmail = New System.Windows.Forms.Button()
        Me.BtnImpXls = New System.Windows.Forms.Button()
        Me.BtnIns = New System.Windows.Forms.Button()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.BtnNew = New System.Windows.Forms.Button()
        Me.BtnHelp = New System.Windows.Forms.Button()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.BtnPrintView = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.rcDataGridView = New System.Windows.Forms.DataGridView()
        Me.ColKhlh = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColKhcz = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCpdm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCpmc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCpgg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDw = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColZl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColWbdm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColWbhl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSpq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMoq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColBjmemo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MnuMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.MnuMain.TabIndex = 0
        '
        'MnuiFile
        '
        Me.MnuiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiNew, Me.MnuiSave, Me.MnuiCancel, Me.Mnui11, Me.MnuiIns, Me.MnuiDelete, Me.Mnui12, Me.MnuiEmailOption, Me.MnuiImpXls, Me.ToolStripMenuItem1, Me.MnuiPageSetup, Me.MnuiPrintView, Me.MnuiPrint, Me.Mnui13, Me.MnuiExit})
        Me.MnuiFile.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiFile.Name = "MnuiFile"
        Me.MnuiFile.Size = New System.Drawing.Size(58, 21)
        Me.MnuiFile.Text = "文件(&F)"
        '
        'MnuiNew
        '
        Me.MnuiNew.Name = "MnuiNew"
        Me.MnuiNew.Size = New System.Drawing.Size(196, 22)
        Me.MnuiNew.Text = "新单(&A)"
        '
        'MnuiSave
        '
        Me.MnuiSave.Enabled = False
        Me.MnuiSave.Name = "MnuiSave"
        Me.MnuiSave.Size = New System.Drawing.Size(196, 22)
        Me.MnuiSave.Text = "保存(&S)"
        '
        'MnuiCancel
        '
        Me.MnuiCancel.Enabled = False
        Me.MnuiCancel.Name = "MnuiCancel"
        Me.MnuiCancel.Size = New System.Drawing.Size(196, 22)
        Me.MnuiCancel.Text = "取消(&C)"
        '
        'Mnui11
        '
        Me.Mnui11.Name = "Mnui11"
        Me.Mnui11.Size = New System.Drawing.Size(193, 6)
        '
        'MnuiIns
        '
        Me.MnuiIns.Name = "MnuiIns"
        Me.MnuiIns.Size = New System.Drawing.Size(196, 22)
        Me.MnuiIns.Text = "插入行(&I)"
        '
        'MnuiDelete
        '
        Me.MnuiDelete.Name = "MnuiDelete"
        Me.MnuiDelete.Size = New System.Drawing.Size(196, 22)
        Me.MnuiDelete.Text = "删除行(&D)"
        '
        'Mnui12
        '
        Me.Mnui12.Name = "Mnui12"
        Me.Mnui12.Size = New System.Drawing.Size(193, 6)
        '
        'MnuiEmailOption
        '
        Me.MnuiEmailOption.Name = "MnuiEmailOption"
        Me.MnuiEmailOption.Size = New System.Drawing.Size(196, 22)
        Me.MnuiEmailOption.Text = "发送电子邮件参数设置"
        '
        'MnuiImpXls
        '
        Me.MnuiImpXls.Name = "MnuiImpXls"
        Me.MnuiImpXls.Size = New System.Drawing.Size(196, 22)
        Me.MnuiImpXls.Text = "导入Excel模板数据(&I)"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(193, 6)
        '
        'MnuiPageSetup
        '
        Me.MnuiPageSetup.Name = "MnuiPageSetup"
        Me.MnuiPageSetup.Size = New System.Drawing.Size(196, 22)
        Me.MnuiPageSetup.Text = "页面设置(&U)"
        '
        'MnuiPrintView
        '
        Me.MnuiPrintView.Name = "MnuiPrintView"
        Me.MnuiPrintView.Size = New System.Drawing.Size(196, 22)
        Me.MnuiPrintView.Text = "打印预览(&V)"
        '
        'MnuiPrint
        '
        Me.MnuiPrint.Name = "MnuiPrint"
        Me.MnuiPrint.Size = New System.Drawing.Size(196, 22)
        Me.MnuiPrint.Text = "打印(&P)"
        '
        'Mnui13
        '
        Me.Mnui13.Name = "Mnui13"
        Me.Mnui13.Size = New System.Drawing.Size(193, 6)
        '
        'MnuiExit
        '
        Me.MnuiExit.Name = "MnuiExit"
        Me.MnuiExit.Size = New System.Drawing.Size(196, 22)
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
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TxtEmail)
        Me.Panel1.Controls.Add(Me.LblEmail)
        Me.Panel1.Controls.Add(Me.LblZymc)
        Me.Panel1.Controls.Add(Me.TxtZydm)
        Me.Panel1.Controls.Add(Me.LblZydm)
        Me.Panel1.Controls.Add(Me.CmbPzlxjc)
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
        Me.Panel1.Size = New System.Drawing.Size(984, 180)
        Me.Panel1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(768, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(161, 12)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "*多个邮箱请用半角"";""隔开。"
        '
        'TxtEmail
        '
        Me.TxtEmail.Location = New System.Drawing.Point(88, 114)
        Me.TxtEmail.MaxLength = 150
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(674, 21)
        Me.TxtEmail.TabIndex = 17
        '
        'LblEmail
        '
        Me.LblEmail.AutoSize = True
        Me.LblEmail.Location = New System.Drawing.Point(34, 118)
        Me.LblEmail.Name = "LblEmail"
        Me.LblEmail.Size = New System.Drawing.Size(47, 12)
        Me.LblEmail.TabIndex = 16
        Me.LblEmail.Text = "Email："
        '
        'LblZymc
        '
        Me.LblZymc.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblZymc.AutoSize = True
        Me.LblZymc.Location = New System.Drawing.Point(556, 89)
        Me.LblZymc.Name = "LblZymc"
        Me.LblZymc.Size = New System.Drawing.Size(0, 12)
        Me.LblZymc.TabIndex = 15
        '
        'TxtZydm
        '
        Me.TxtZydm.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtZydm.Location = New System.Drawing.Point(460, 85)
        Me.TxtZydm.MaxLength = 12
        Me.TxtZydm.Name = "TxtZydm"
        Me.TxtZydm.Size = New System.Drawing.Size(88, 21)
        Me.TxtZydm.TabIndex = 14
        '
        'LblZydm
        '
        Me.LblZydm.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblZydm.AutoSize = True
        Me.LblZydm.Location = New System.Drawing.Point(388, 89)
        Me.LblZydm.Name = "LblZydm"
        Me.LblZydm.Size = New System.Drawing.Size(65, 12)
        Me.LblZydm.TabIndex = 13
        Me.LblZydm.Text = "业 务 员："
        '
        'CmbPzlxjc
        '
        Me.CmbPzlxjc.Location = New System.Drawing.Point(88, 56)
        Me.CmbPzlxjc.Name = "CmbPzlxjc"
        Me.CmbPzlxjc.Size = New System.Drawing.Size(72, 20)
        Me.CmbPzlxjc.TabIndex = 2
        '
        'TxtBjtk
        '
        Me.TxtBjtk.Location = New System.Drawing.Point(88, 143)
        Me.TxtBjtk.MaxLength = 150
        Me.TxtBjtk.Multiline = True
        Me.TxtBjtk.Name = "TxtBjtk"
        Me.TxtBjtk.Size = New System.Drawing.Size(876, 21)
        Me.TxtBjtk.TabIndex = 20
        '
        'LblBjtk
        '
        Me.LblBjtk.AutoSize = True
        Me.LblBjtk.Location = New System.Drawing.Point(16, 147)
        Me.LblBjtk.Name = "LblBjtk"
        Me.LblBjtk.Size = New System.Drawing.Size(65, 12)
        Me.LblBjtk.TabIndex = 19
        Me.LblBjtk.Text = "报价条款："
        '
        'LblKhmc
        '
        Me.LblKhmc.AutoSize = True
        Me.LblKhmc.Location = New System.Drawing.Point(184, 89)
        Me.LblKhmc.Name = "LblKhmc"
        Me.LblKhmc.Size = New System.Drawing.Size(0, 12)
        Me.LblKhmc.TabIndex = 12
        '
        'TxtKhdm
        '
        Me.TxtKhdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtKhdm.Location = New System.Drawing.Point(88, 85)
        Me.TxtKhdm.MaxLength = 12
        Me.TxtKhdm.Name = "TxtKhdm"
        Me.TxtKhdm.Size = New System.Drawing.Size(88, 21)
        Me.TxtKhdm.TabIndex = 11
        '
        'LblKhdm
        '
        Me.LblKhdm.AutoSize = True
        Me.LblKhdm.Location = New System.Drawing.Point(16, 89)
        Me.LblKhdm.Name = "LblKhdm"
        Me.LblKhdm.Size = New System.Drawing.Size(65, 12)
        Me.LblKhdm.TabIndex = 10
        Me.LblKhdm.Text = "客户编码："
        '
        'LblBjrq
        '
        Me.LblBjrq.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblBjrq.AutoSize = True
        Me.LblBjrq.Location = New System.Drawing.Point(388, 60)
        Me.LblBjrq.Name = "LblBjrq"
        Me.LblBjrq.Size = New System.Drawing.Size(65, 12)
        Me.LblBjrq.TabIndex = 4
        Me.LblBjrq.Text = "报价日期："
        '
        'DtpBjrq
        '
        Me.DtpBjrq.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.DtpBjrq.Location = New System.Drawing.Point(460, 56)
        Me.DtpBjrq.Name = "DtpBjrq"
        Me.DtpBjrq.Size = New System.Drawing.Size(112, 21)
        Me.DtpBjrq.TabIndex = 5
        '
        'TxtDjh
        '
        Me.TxtDjh.Location = New System.Drawing.Point(160, 56)
        Me.TxtDjh.MaxLength = 15
        Me.TxtDjh.Name = "TxtDjh"
        Me.TxtDjh.Size = New System.Drawing.Size(104, 21)
        Me.TxtDjh.TabIndex = 3
        '
        'LblDjh
        '
        Me.LblDjh.AutoSize = True
        Me.LblDjh.Location = New System.Drawing.Point(16, 60)
        Me.LblDjh.Name = "LblDjh"
        Me.LblDjh.Size = New System.Drawing.Size(65, 12)
        Me.LblDjh.TabIndex = 1
        Me.LblDjh.Text = "单 据 号："
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
        Me.LblBjd.Location = New System.Drawing.Point(424, 9)
        Me.LblBjd.Name = "LblBjd"
        Me.LblBjd.Size = New System.Drawing.Size(137, 25)
        Me.LblBjd.TabIndex = 0
        Me.LblBjd.Text = "产品报价单"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.BtnSaveAs)
        Me.Panel2.Controls.Add(Me.BtnToEmail)
        Me.Panel2.Controls.Add(Me.BtnImpXls)
        Me.Panel2.Controls.Add(Me.BtnIns)
        Me.Panel2.Controls.Add(Me.LblMsg)
        Me.Panel2.Controls.Add(Me.BtnCancel)
        Me.Panel2.Controls.Add(Me.BtnDelete)
        Me.Panel2.Controls.Add(Me.BtnExit)
        Me.Panel2.Controls.Add(Me.BtnNew)
        Me.Panel2.Controls.Add(Me.BtnHelp)
        Me.Panel2.Controls.Add(Me.BtnPrint)
        Me.Panel2.Controls.Add(Me.BtnPrintView)
        Me.Panel2.Controls.Add(Me.BtnSave)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 382)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(984, 179)
        Me.Panel2.TabIndex = 3
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
        Me.Panel4.Size = New System.Drawing.Size(984, 107)
        Me.Panel4.TabIndex = 25
        '
        'TxtMemo5
        '
        Me.TxtMemo5.Dock = System.Windows.Forms.DockStyle.Top
        Me.TxtMemo5.Location = New System.Drawing.Point(43, 84)
        Me.TxtMemo5.MaxLength = 150
        Me.TxtMemo5.Multiline = True
        Me.TxtMemo5.Name = "TxtMemo5"
        Me.TxtMemo5.Size = New System.Drawing.Size(941, 21)
        Me.TxtMemo5.TabIndex = 26
        '
        'TxtMemo4
        '
        Me.TxtMemo4.Dock = System.Windows.Forms.DockStyle.Top
        Me.TxtMemo4.Location = New System.Drawing.Point(43, 63)
        Me.TxtMemo4.MaxLength = 150
        Me.TxtMemo4.Multiline = True
        Me.TxtMemo4.Name = "TxtMemo4"
        Me.TxtMemo4.Size = New System.Drawing.Size(941, 21)
        Me.TxtMemo4.TabIndex = 24
        '
        'TxtMemo3
        '
        Me.TxtMemo3.Dock = System.Windows.Forms.DockStyle.Top
        Me.TxtMemo3.Location = New System.Drawing.Point(43, 42)
        Me.TxtMemo3.MaxLength = 150
        Me.TxtMemo3.Multiline = True
        Me.TxtMemo3.Name = "TxtMemo3"
        Me.TxtMemo3.Size = New System.Drawing.Size(941, 21)
        Me.TxtMemo3.TabIndex = 23
        '
        'TxtMemo2
        '
        Me.TxtMemo2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TxtMemo2.Location = New System.Drawing.Point(43, 21)
        Me.TxtMemo2.MaxLength = 150
        Me.TxtMemo2.Multiline = True
        Me.TxtMemo2.Name = "TxtMemo2"
        Me.TxtMemo2.Size = New System.Drawing.Size(941, 21)
        Me.TxtMemo2.TabIndex = 22
        '
        'TxtMemo1
        '
        Me.TxtMemo1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TxtMemo1.Location = New System.Drawing.Point(43, 0)
        Me.TxtMemo1.MaxLength = 150
        Me.TxtMemo1.Multiline = True
        Me.TxtMemo1.Name = "TxtMemo1"
        Me.TxtMemo1.Size = New System.Drawing.Size(941, 21)
        Me.TxtMemo1.TabIndex = 21
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(43, 107)
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
        Me.BtnSaveAs.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSaveAs.Location = New System.Drawing.Point(595, 147)
        Me.BtnSaveAs.Name = "BtnSaveAs"
        Me.BtnSaveAs.Size = New System.Drawing.Size(75, 23)
        Me.BtnSaveAs.TabIndex = 8
        Me.BtnSaveAs.Text = "另存为…"
        '
        'BtnToEmail
        '
        Me.BtnToEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnToEmail.Location = New System.Drawing.Point(670, 147)
        Me.BtnToEmail.Name = "BtnToEmail"
        Me.BtnToEmail.Size = New System.Drawing.Size(75, 23)
        Me.BtnToEmail.TabIndex = 9
        Me.BtnToEmail.Text = "发送&Email"
        '
        'BtnImpXls
        '
        Me.BtnImpXls.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImpXls.Location = New System.Drawing.Point(745, 147)
        Me.BtnImpXls.Name = "BtnImpXls"
        Me.BtnImpXls.Size = New System.Drawing.Size(75, 23)
        Me.BtnImpXls.TabIndex = 10
        Me.BtnImpXls.Text = "读入Xls(&I)"
        '
        'BtnIns
        '
        Me.BtnIns.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnIns.Location = New System.Drawing.Point(295, 147)
        Me.BtnIns.Name = "BtnIns"
        Me.BtnIns.Size = New System.Drawing.Size(75, 23)
        Me.BtnIns.TabIndex = 4
        Me.BtnIns.Text = "插入行(&I)"
        '
        'LblMsg
        '
        Me.LblMsg.AutoSize = True
        Me.LblMsg.ForeColor = System.Drawing.Color.SteelBlue
        Me.LblMsg.Location = New System.Drawing.Point(14, 121)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(65, 12)
        Me.LblMsg.TabIndex = 0
        Me.LblMsg.Text = "提示信息。"
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Enabled = False
        Me.BtnCancel.Location = New System.Drawing.Point(220, 147)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 3
        Me.BtnCancel.Text = "取消(&C)"
        '
        'BtnDelete
        '
        Me.BtnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDelete.Location = New System.Drawing.Point(370, 147)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(75, 23)
        Me.BtnDelete.TabIndex = 5
        Me.BtnDelete.Text = "删除行(&D)"
        '
        'BtnExit
        '
        Me.BtnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExit.Location = New System.Drawing.Point(895, 147)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 23)
        Me.BtnExit.TabIndex = 12
        Me.BtnExit.Text = "退出(&X)"
        '
        'BtnNew
        '
        Me.BtnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnNew.Location = New System.Drawing.Point(70, 147)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(75, 23)
        Me.BtnNew.TabIndex = 1
        Me.BtnNew.Text = "新单(&A)"
        '
        'BtnHelp
        '
        Me.BtnHelp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnHelp.Location = New System.Drawing.Point(820, 147)
        Me.BtnHelp.Name = "BtnHelp"
        Me.BtnHelp.Size = New System.Drawing.Size(75, 23)
        Me.BtnHelp.TabIndex = 11
        Me.BtnHelp.Text = "帮助(&H)"
        '
        'BtnPrint
        '
        Me.BtnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPrint.Location = New System.Drawing.Point(445, 147)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrint.TabIndex = 6
        Me.BtnPrint.Text = "打印(&P)"
        '
        'BtnPrintView
        '
        Me.BtnPrintView.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPrintView.Location = New System.Drawing.Point(520, 147)
        Me.BtnPrintView.Name = "BtnPrintView"
        Me.BtnPrintView.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrintView.TabIndex = 7
        Me.BtnPrintView.Text = "预览(&V)"
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Enabled = False
        Me.BtnSave.Location = New System.Drawing.Point(145, 147)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 2
        Me.BtnSave.Text = "保存(&S)"
        '
        'rcDataGridView
        '
        Me.rcDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.rcDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColKhlh, Me.ColKhcz, Me.ColCpdm, Me.ColCpmc, Me.ColCpgg, Me.ColDw, Me.ColZl, Me.ColDj, Me.ColWbdm, Me.ColWbhl, Me.ColSpq, Me.ColMoq, Me.ColBjmemo})
        Me.rcDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rcDataGridView.Location = New System.Drawing.Point(0, 205)
        Me.rcDataGridView.Name = "rcDataGridView"
        Me.rcDataGridView.RowTemplate.Height = 23
        Me.rcDataGridView.Size = New System.Drawing.Size(984, 177)
        Me.rcDataGridView.TabIndex = 2
        '
        'ColKhlh
        '
        Me.ColKhlh.DataPropertyName = "khlh"
        Me.ColKhlh.HeaderText = "客户料号"
        Me.ColKhlh.MaxInputLength = 50
        Me.ColKhlh.Name = "ColKhlh"
        Me.ColKhlh.Width = 90
        '
        'ColKhcz
        '
        Me.ColKhcz.DataPropertyName = "khcz"
        Me.ColKhcz.HeaderText = "客户材质"
        Me.ColKhcz.MaxInputLength = 30
        Me.ColKhcz.Name = "ColKhcz"
        Me.ColKhcz.Width = 90
        '
        'ColCpdm
        '
        Me.ColCpdm.DataPropertyName = "cpdm"
        Me.ColCpdm.HeaderText = "产品编码"
        Me.ColCpdm.MaxInputLength = 15
        Me.ColCpdm.Name = "ColCpdm"
        Me.ColCpdm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColCpdm.Width = 80
        '
        'ColCpmc
        '
        Me.ColCpmc.DataPropertyName = "cpmc"
        Me.ColCpmc.HeaderText = "东磁型号"
        Me.ColCpmc.MaxInputLength = 50
        Me.ColCpmc.Name = "ColCpmc"
        Me.ColCpmc.Width = 135
        '
        'ColCpgg
        '
        Me.ColCpgg.DataPropertyName = "cpgg"
        Me.ColCpgg.HeaderText = "规格型号"
        Me.ColCpgg.MaxInputLength = 50
        Me.ColCpgg.Name = "ColCpgg"
        Me.ColCpgg.Width = 90
        '
        'ColDw
        '
        Me.ColDw.DataPropertyName = "dw"
        Me.ColDw.HeaderText = "单位"
        Me.ColDw.MaxInputLength = 10
        Me.ColDw.Name = "ColDw"
        Me.ColDw.Width = 35
        '
        'ColZl
        '
        Me.ColZl.DataPropertyName = "zl"
        Me.ColZl.HeaderText = "重量"
        Me.ColZl.MaxInputLength = 18
        Me.ColZl.Name = "ColZl"
        Me.ColZl.Width = 80
        '
        'ColDj
        '
        Me.ColDj.DataPropertyName = "dj"
        Me.ColDj.HeaderText = "单价"
        Me.ColDj.MaxInputLength = 18
        Me.ColDj.Name = "ColDj"
        Me.ColDj.Width = 80
        '
        'ColWbdm
        '
        Me.ColWbdm.DataPropertyName = "wbdm"
        Me.ColWbdm.HeaderText = "币种"
        Me.ColWbdm.Name = "ColWbdm"
        '
        'ColWbhl
        '
        Me.ColWbhl.DataPropertyName = "wbhl"
        Me.ColWbhl.HeaderText = "汇率"
        Me.ColWbhl.Name = "ColWbhl"
        '
        'ColSpq
        '
        Me.ColSpq.DataPropertyName = "spq"
        Me.ColSpq.HeaderText = "最小包装量"
        Me.ColSpq.Name = "ColSpq"
        Me.ColSpq.Width = 90
        '
        'ColMoq
        '
        Me.ColMoq.DataPropertyName = "moq"
        Me.ColMoq.HeaderText = "最小订单量"
        Me.ColMoq.Name = "ColMoq"
        Me.ColMoq.Width = 90
        '
        'ColBjmemo
        '
        Me.ColBjmemo.DataPropertyName = "bjmemo"
        Me.ColBjmemo.HeaderText = "备注"
        Me.ColBjmemo.MaxInputLength = 50
        Me.ColBjmemo.Name = "ColBjmemo"
        Me.ColBjmemo.Width = 135
        '
        'FrmOeBjdSrz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.rcDataGridView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MnuMain)
        Me.Name = "FrmOeBjdSrz"
        Me.Text = "产品报价单输入与修改"
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rcPrintDocument As System.Drawing.Printing.PrintDocument
    Friend WithEvents rcBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuiFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiImpXls As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Mnui11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuiIns As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiDelete As System.Windows.Forms.ToolStripMenuItem
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents TxtEmail As System.Windows.Forms.TextBox
    Public WithEvents LblEmail As System.Windows.Forms.Label
    Public WithEvents LblZymc As System.Windows.Forms.Label
    Public WithEvents TxtZydm As System.Windows.Forms.TextBox
    Public WithEvents LblZydm As System.Windows.Forms.Label
    Friend WithEvents CmbPzlxjc As System.Windows.Forms.ComboBox
    Public WithEvents TxtBjtk As System.Windows.Forms.TextBox
    Public WithEvents LblBjtk As System.Windows.Forms.Label
    Public WithEvents LblKhmc As System.Windows.Forms.Label
    Public WithEvents TxtKhdm As System.Windows.Forms.TextBox
    Public WithEvents LblKhdm As System.Windows.Forms.Label
    Public WithEvents LblBjrq As System.Windows.Forms.Label
    Public WithEvents DtpBjrq As System.Windows.Forms.DateTimePicker
    Public WithEvents TxtDjh As System.Windows.Forms.TextBox
    Public WithEvents LblDjh As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents LblBjd As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnToEmail As System.Windows.Forms.Button
    Friend WithEvents BtnImpXls As System.Windows.Forms.Button
    Friend WithEvents BtnIns As System.Windows.Forms.Button
    Public WithEvents LblMsg As System.Windows.Forms.Label
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents BtnHelp As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents BtnPrintView As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents rcDataGridView As System.Windows.Forms.DataGridView
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MnuiEmailOption As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnSaveAs As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Public WithEvents TxtMemo4 As System.Windows.Forms.TextBox
    Public WithEvents TxtMemo3 As System.Windows.Forms.TextBox
    Public WithEvents TxtMemo2 As System.Windows.Forms.TextBox
    Public WithEvents TxtMemo1 As System.Windows.Forms.TextBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents TxtMemo5 As System.Windows.Forms.TextBox
    Friend WithEvents ColKhlh As DataGridViewTextBoxColumn
    Friend WithEvents ColKhcz As DataGridViewTextBoxColumn
    Friend WithEvents ColCpdm As DataGridViewTextBoxColumn
    Friend WithEvents ColCpmc As DataGridViewTextBoxColumn
    Friend WithEvents ColCpgg As DataGridViewTextBoxColumn
    Friend WithEvents ColDw As DataGridViewTextBoxColumn
    Friend WithEvents ColZl As DataGridViewTextBoxColumn
    Friend WithEvents ColDj As DataGridViewTextBoxColumn
    Friend WithEvents ColWbdm As DataGridViewTextBoxColumn
    Friend WithEvents ColWbhl As DataGridViewTextBoxColumn
    Friend WithEvents ColSpq As DataGridViewTextBoxColumn
    Friend WithEvents ColMoq As DataGridViewTextBoxColumn
    Friend WithEvents ColBjmemo As DataGridViewTextBoxColumn
End Class
