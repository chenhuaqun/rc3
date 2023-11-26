<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPoCgjhSrz
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
        Me.Mnui11 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuiIns = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuiPageSetup = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiPrintView = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mnui12 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuiExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LblBmmc = New System.Windows.Forms.Label()
        Me.TxtBmdm = New System.Windows.Forms.TextBox()
        Me.LblBmdm = New System.Windows.Forms.Label()
        Me.CmbPzlxjc = New System.Windows.Forms.ComboBox()
        Me.LblJhrq = New System.Windows.Forms.Label()
        Me.DtpJhrq = New System.Windows.Forms.DateTimePicker()
        Me.TxtDjh = New System.Windows.Forms.TextBox()
        Me.LblDjh = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.LblCgjh = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnIns = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.LblFzsl = New System.Windows.Forms.Label()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.LblSl = New System.Windows.Forms.Label()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.BtnNew = New System.Windows.Forms.Button()
        Me.BtnHelp = New System.Windows.Forms.Button()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.BtnPrintView = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.rcDataGridView = New System.Windows.Forms.DataGridView()
        Me.rcBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ColCpdm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOldCpdm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCpmc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColKcsl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColWrksl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColZdcb = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColZgcb = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDw = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMjsl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFzsl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFzdw = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColJhshrq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColJhmemo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MnuMain.SuspendLayout()
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
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiFile, Me.MnuiEdit, Me.MnuiHelp})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(984, 25)
        Me.MnuMain.TabIndex = 1
        '
        'MnuiFile
        '
        Me.MnuiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiNew, Me.MnuiSave, Me.MnuiCancel, Me.Mnui11, Me.MnuiIns, Me.MnuiDelete, Me.ToolStripMenuItem1, Me.MnuiPageSetup, Me.MnuiPrintView, Me.MnuiPrint, Me.Mnui12, Me.MnuiExit})
        Me.MnuiFile.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiFile.Name = "MnuiFile"
        Me.MnuiFile.Size = New System.Drawing.Size(58, 21)
        Me.MnuiFile.Text = "文件(&F)"
        '
        'MnuiNew
        '
        Me.MnuiNew.Name = "MnuiNew"
        Me.MnuiNew.Size = New System.Drawing.Size(166, 22)
        Me.MnuiNew.Text = "新单(&A)"
        '
        'MnuiSave
        '
        Me.MnuiSave.Name = "MnuiSave"
        Me.MnuiSave.Size = New System.Drawing.Size(166, 22)
        Me.MnuiSave.Text = "保存(&S)"
        '
        'MnuiCancel
        '
        Me.MnuiCancel.Name = "MnuiCancel"
        Me.MnuiCancel.Size = New System.Drawing.Size(166, 22)
        Me.MnuiCancel.Text = "取消(&C)"
        '
        'Mnui11
        '
        Me.Mnui11.Name = "Mnui11"
        Me.Mnui11.Size = New System.Drawing.Size(163, 6)
        '
        'MnuiIns
        '
        Me.MnuiIns.Name = "MnuiIns"
        Me.MnuiIns.Size = New System.Drawing.Size(166, 22)
        Me.MnuiIns.Text = "插入行(&I)"
        '
        'MnuiDelete
        '
        Me.MnuiDelete.Name = "MnuiDelete"
        Me.MnuiDelete.Size = New System.Drawing.Size(166, 22)
        Me.MnuiDelete.Text = "删除行(&D)"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(163, 6)
        '
        'MnuiPageSetup
        '
        Me.MnuiPageSetup.Name = "MnuiPageSetup"
        Me.MnuiPageSetup.Size = New System.Drawing.Size(166, 22)
        Me.MnuiPageSetup.Text = "页面设置(&U)"
        '
        'MnuiPrintView
        '
        Me.MnuiPrintView.Name = "MnuiPrintView"
        Me.MnuiPrintView.Size = New System.Drawing.Size(166, 22)
        Me.MnuiPrintView.Text = "打印预览(&V)"
        '
        'MnuiPrint
        '
        Me.MnuiPrint.Name = "MnuiPrint"
        Me.MnuiPrint.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.MnuiPrint.Size = New System.Drawing.Size(166, 22)
        Me.MnuiPrint.Text = "打印(&P)"
        '
        'Mnui12
        '
        Me.Mnui12.Name = "Mnui12"
        Me.Mnui12.Size = New System.Drawing.Size(163, 6)
        '
        'MnuiExit
        '
        Me.MnuiExit.Name = "MnuiExit"
        Me.MnuiExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.MnuiExit.Size = New System.Drawing.Size(166, 22)
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
        Me.Panel1.Controls.Add(Me.LblBmmc)
        Me.Panel1.Controls.Add(Me.TxtBmdm)
        Me.Panel1.Controls.Add(Me.LblBmdm)
        Me.Panel1.Controls.Add(Me.CmbPzlxjc)
        Me.Panel1.Controls.Add(Me.LblJhrq)
        Me.Panel1.Controls.Add(Me.DtpJhrq)
        Me.Panel1.Controls.Add(Me.TxtDjh)
        Me.Panel1.Controls.Add(Me.LblDjh)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(984, 120)
        Me.Panel1.TabIndex = 0
        '
        'LblBmmc
        '
        Me.LblBmmc.AutoSize = True
        Me.LblBmmc.Location = New System.Drawing.Point(200, 88)
        Me.LblBmmc.Name = "LblBmmc"
        Me.LblBmmc.Size = New System.Drawing.Size(0, 12)
        Me.LblBmmc.TabIndex = 7
        '
        'TxtBmdm
        '
        Me.TxtBmdm.Location = New System.Drawing.Point(88, 84)
        Me.TxtBmdm.MaxLength = 12
        Me.TxtBmdm.Name = "TxtBmdm"
        Me.TxtBmdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtBmdm.TabIndex = 6
        '
        'LblBmdm
        '
        Me.LblBmdm.AutoSize = True
        Me.LblBmdm.Location = New System.Drawing.Point(16, 88)
        Me.LblBmdm.Name = "LblBmdm"
        Me.LblBmdm.Size = New System.Drawing.Size(65, 12)
        Me.LblBmdm.TabIndex = 5
        Me.LblBmdm.Text = "需求部门："
        '
        'CmbPzlxjc
        '
        Me.CmbPzlxjc.Location = New System.Drawing.Point(88, 56)
        Me.CmbPzlxjc.Name = "CmbPzlxjc"
        Me.CmbPzlxjc.Size = New System.Drawing.Size(72, 20)
        Me.CmbPzlxjc.TabIndex = 1
        '
        'LblJhrq
        '
        Me.LblJhrq.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblJhrq.AutoSize = True
        Me.LblJhrq.Location = New System.Drawing.Point(428, 60)
        Me.LblJhrq.Name = "LblJhrq"
        Me.LblJhrq.Size = New System.Drawing.Size(65, 12)
        Me.LblJhrq.TabIndex = 3
        Me.LblJhrq.Text = "需求日期："
        '
        'DtpJhrq
        '
        Me.DtpJhrq.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.DtpJhrq.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpJhrq.Enabled = False
        Me.DtpJhrq.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpJhrq.Location = New System.Drawing.Point(500, 56)
        Me.DtpJhrq.Name = "DtpJhrq"
        Me.DtpJhrq.Size = New System.Drawing.Size(162, 21)
        Me.DtpJhrq.TabIndex = 4
        '
        'TxtDjh
        '
        Me.TxtDjh.Location = New System.Drawing.Point(160, 56)
        Me.TxtDjh.MaxLength = 19
        Me.TxtDjh.Name = "TxtDjh"
        Me.TxtDjh.Size = New System.Drawing.Size(120, 21)
        Me.TxtDjh.TabIndex = 2
        '
        'LblDjh
        '
        Me.LblDjh.AutoSize = True
        Me.LblDjh.Location = New System.Drawing.Point(16, 60)
        Me.LblDjh.Name = "LblDjh"
        Me.LblDjh.Size = New System.Drawing.Size(65, 12)
        Me.LblDjh.TabIndex = 0
        Me.LblDjh.Text = "单 据 号："
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.LblCgjh)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(984, 48)
        Me.Panel3.TabIndex = 0
        '
        'LblCgjh
        '
        Me.LblCgjh.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblCgjh.AutoSize = True
        Me.LblCgjh.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblCgjh.ForeColor = System.Drawing.Color.SteelBlue
        Me.LblCgjh.Location = New System.Drawing.Point(370, 9)
        Me.LblCgjh.Name = "LblCgjh"
        Me.LblCgjh.Size = New System.Drawing.Size(246, 29)
        Me.LblCgjh.TabIndex = 0
        Me.LblCgjh.Text = "物料采购/维修需求单"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtnIns)
        Me.Panel2.Controls.Add(Me.BtnCancel)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.BtnDelete)
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
        'BtnIns
        '
        Me.BtnIns.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnIns.Location = New System.Drawing.Point(521, 58)
        Me.BtnIns.Name = "BtnIns"
        Me.BtnIns.Size = New System.Drawing.Size(75, 23)
        Me.BtnIns.TabIndex = 4
        Me.BtnIns.Text = "插入行(&I)"
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Enabled = False
        Me.BtnCancel.Location = New System.Drawing.Point(446, 58)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 3
        Me.BtnCancel.Text = "取消(&C)"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.LblFzsl)
        Me.Panel4.Controls.Add(Me.LblMsg)
        Me.Panel4.Controls.Add(Me.LblSl)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(984, 43)
        Me.Panel4.TabIndex = 0
        '
        'LblFzsl
        '
        Me.LblFzsl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblFzsl.AutoSize = True
        Me.LblFzsl.Location = New System.Drawing.Point(773, 24)
        Me.LblFzsl.Name = "LblFzsl"
        Me.LblFzsl.Size = New System.Drawing.Size(77, 12)
        Me.LblFzsl.TabIndex = 14
        Me.LblFzsl.Text = "辅数量合计："
        '
        'LblMsg
        '
        Me.LblMsg.AutoSize = True
        Me.LblMsg.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblMsg.ForeColor = System.Drawing.Color.SteelBlue
        Me.LblMsg.Location = New System.Drawing.Point(12, 7)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(88, 16)
        Me.LblMsg.TabIndex = 12
        Me.LblMsg.Text = "提示信息。"
        '
        'LblSl
        '
        Me.LblSl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSl.AutoSize = True
        Me.LblSl.Location = New System.Drawing.Point(583, 24)
        Me.LblSl.Name = "LblSl"
        Me.LblSl.Size = New System.Drawing.Size(65, 12)
        Me.LblSl.TabIndex = 10
        Me.LblSl.Text = "数量合计："
        '
        'BtnDelete
        '
        Me.BtnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDelete.Location = New System.Drawing.Point(596, 58)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(75, 23)
        Me.BtnDelete.TabIndex = 5
        Me.BtnDelete.Text = "删除行(&D)"
        '
        'BtnExit
        '
        Me.BtnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExit.Location = New System.Drawing.Point(896, 58)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 23)
        Me.BtnExit.TabIndex = 9
        Me.BtnExit.Text = "退出(&X)"
        '
        'BtnNew
        '
        Me.BtnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnNew.Location = New System.Drawing.Point(296, 58)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(75, 23)
        Me.BtnNew.TabIndex = 1
        Me.BtnNew.Text = "新单(&A)"
        '
        'BtnHelp
        '
        Me.BtnHelp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnHelp.Location = New System.Drawing.Point(821, 58)
        Me.BtnHelp.Name = "BtnHelp"
        Me.BtnHelp.Size = New System.Drawing.Size(75, 23)
        Me.BtnHelp.TabIndex = 8
        Me.BtnHelp.Text = "帮助(&H)"
        '
        'BtnPrint
        '
        Me.BtnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPrint.Location = New System.Drawing.Point(671, 58)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrint.TabIndex = 6
        Me.BtnPrint.Text = "打印(&P)"
        '
        'BtnPrintView
        '
        Me.BtnPrintView.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPrintView.Location = New System.Drawing.Point(746, 58)
        Me.BtnPrintView.Name = "BtnPrintView"
        Me.BtnPrintView.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrintView.TabIndex = 7
        Me.BtnPrintView.Text = "预览(&V)"
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Enabled = False
        Me.BtnSave.Location = New System.Drawing.Point(371, 58)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 2
        Me.BtnSave.Text = "保存(&S)"
        '
        'rcDataGridView
        '
        Me.rcDataGridView.ColumnHeadersHeight = 35
        Me.rcDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColCpdm, Me.ColOldCpdm, Me.ColCpmc, Me.ColKcsl, Me.ColWrksl, Me.ColZdcb, Me.ColZgcb, Me.ColSl, Me.ColDw, Me.ColMjsl, Me.ColFzsl, Me.ColFzdw, Me.ColJhshrq, Me.ColJhmemo})
        Me.rcDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rcDataGridView.Location = New System.Drawing.Point(0, 145)
        Me.rcDataGridView.Name = "rcDataGridView"
        Me.rcDataGridView.RowTemplate.Height = 23
        Me.rcDataGridView.Size = New System.Drawing.Size(984, 317)
        Me.rcDataGridView.TabIndex = 1
        '
        'ColCpdm
        '
        Me.ColCpdm.DataPropertyName = "cpdm"
        Me.ColCpdm.Frozen = True
        Me.ColCpdm.HeaderText = "物料编码"
        Me.ColCpdm.MaxInputLength = 15
        Me.ColCpdm.Name = "ColCpdm"
        Me.ColCpdm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColCpdm.Width = 110
        '
        'ColOldCpdm
        '
        Me.ColOldCpdm.DataPropertyName = "oldcpdm"
        Me.ColOldCpdm.HeaderText = "旧物料号"
        Me.ColOldCpdm.MaxInputLength = 15
        Me.ColOldCpdm.Name = "ColOldCpdm"
        Me.ColOldCpdm.ReadOnly = True
        Me.ColOldCpdm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColOldCpdm.Width = 110
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
        'ColKcsl
        '
        Me.ColKcsl.DataPropertyName = "kcsl"
        Me.ColKcsl.HeaderText = "库存数量"
        Me.ColKcsl.MaxInputLength = 18
        Me.ColKcsl.Name = "ColKcsl"
        Me.ColKcsl.ReadOnly = True
        Me.ColKcsl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColKcsl.Width = 90
        '
        'ColWrksl
        '
        Me.ColWrksl.DataPropertyName = "wrksl"
        Me.ColWrksl.HeaderText = "未采购入库数量"
        Me.ColWrksl.MaxInputLength = 18
        Me.ColWrksl.Name = "ColWrksl"
        Me.ColWrksl.ReadOnly = True
        Me.ColWrksl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColWrksl.Width = 90
        '
        'ColZdcb
        '
        Me.ColZdcb.DataPropertyName = "zdcb"
        Me.ColZdcb.HeaderText = "最低储备数量"
        Me.ColZdcb.MaxInputLength = 18
        Me.ColZdcb.Name = "ColZdcb"
        Me.ColZdcb.ReadOnly = True
        Me.ColZdcb.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColZdcb.Width = 90
        '
        'ColZgcb
        '
        Me.ColZgcb.DataPropertyName = "zgcb"
        Me.ColZgcb.HeaderText = "最高储备数量"
        Me.ColZgcb.MaxInputLength = 18
        Me.ColZgcb.Name = "ColZgcb"
        Me.ColZgcb.ReadOnly = True
        Me.ColZgcb.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColZgcb.Width = 90
        '
        'ColSl
        '
        Me.ColSl.DataPropertyName = "sl"
        Me.ColSl.HeaderText = "需求数量"
        Me.ColSl.MaxInputLength = 18
        Me.ColSl.Name = "ColSl"
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
        Me.ColMjsl.MaxInputLength = 18
        Me.ColMjsl.Name = "ColMjsl"
        Me.ColMjsl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColMjsl.Width = 90
        '
        'ColFzsl
        '
        Me.ColFzsl.DataPropertyName = "fzsl"
        Me.ColFzsl.HeaderText = "辅数量"
        Me.ColFzsl.MaxInputLength = 18
        Me.ColFzsl.Name = "ColFzsl"
        Me.ColFzsl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColFzsl.Width = 90
        '
        'ColFzdw
        '
        Me.ColFzdw.DataPropertyName = "fzdw"
        Me.ColFzdw.HeaderText = "辅单位"
        Me.ColFzdw.MaxInputLength = 10
        Me.ColFzdw.Name = "ColFzdw"
        Me.ColFzdw.ReadOnly = True
        Me.ColFzdw.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColFzdw.Width = 45
        '
        'ColJhshrq
        '
        Me.ColJhshrq.DataPropertyName = "jhshrq"
        Me.ColJhshrq.HeaderText = "计划收货日期"
        Me.ColJhshrq.Name = "ColJhshrq"
        Me.ColJhshrq.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColJhshrq.Width = 90
        '
        'ColJhmemo
        '
        Me.ColJhmemo.DataPropertyName = "jhmemo"
        Me.ColJhmemo.HeaderText = "备注"
        Me.ColJhmemo.MaxInputLength = 50
        Me.ColJhmemo.Name = "ColJhmemo"
        Me.ColJhmemo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColJhmemo.Width = 135
        '
        'FrmPoCgjhSrz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.rcDataGridView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MnuMain)
        Me.Name = "FrmPoCgjhSrz"
        Me.Text = "物料采购/维修需求单输入与修改"
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
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
    Friend WithEvents MnuiDelete As System.Windows.Forms.ToolStripMenuItem
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
    Friend WithEvents CmbPzlxjc As System.Windows.Forms.ComboBox
    Public WithEvents LblJhrq As System.Windows.Forms.Label
    Public WithEvents DtpJhrq As System.Windows.Forms.DateTimePicker
    Public WithEvents TxtDjh As System.Windows.Forms.TextBox
    Public WithEvents LblDjh As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents LblCgjh As System.Windows.Forms.Label
    Friend WithEvents LblBmmc As System.Windows.Forms.Label
    Friend WithEvents TxtBmdm As System.Windows.Forms.TextBox
    Friend WithEvents LblBmdm As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnIns As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Public WithEvents LblFzsl As System.Windows.Forms.Label
    Public WithEvents LblMsg As System.Windows.Forms.Label
    Public WithEvents LblSl As System.Windows.Forms.Label
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents BtnHelp As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents BtnPrintView As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents rcDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents rcBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MnuiCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiIns As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ColCpdm As DataGridViewTextBoxColumn
    Friend WithEvents ColOldCpdm As DataGridViewTextBoxColumn
    Friend WithEvents ColCpmc As DataGridViewTextBoxColumn
    Friend WithEvents ColKcsl As DataGridViewTextBoxColumn
    Friend WithEvents ColWrksl As DataGridViewTextBoxColumn
    Friend WithEvents ColZdcb As DataGridViewTextBoxColumn
    Friend WithEvents ColZgcb As DataGridViewTextBoxColumn
    Friend WithEvents ColSl As DataGridViewTextBoxColumn
    Friend WithEvents ColDw As DataGridViewTextBoxColumn
    Friend WithEvents ColMjsl As DataGridViewTextBoxColumn
    Friend WithEvents ColFzsl As DataGridViewTextBoxColumn
    Friend WithEvents ColFzdw As DataGridViewTextBoxColumn
    Friend WithEvents ColJhshrq As DataGridViewTextBoxColumn
    Friend WithEvents ColJhmemo As DataGridViewTextBoxColumn
End Class
