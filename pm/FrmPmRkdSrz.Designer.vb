<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPmRkdSrz
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
        Me.ToolStripPanel1 = New System.Windows.Forms.ToolStripPanel
        Me.MnuMain = New System.Windows.Forms.MenuStrip
        Me.MnuiFile = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiNew = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiSave = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiCancel = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiZf = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.MnuiIns = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiDelete = New System.Windows.Forms.ToolStripMenuItem
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
        Me.自定义显示列ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiHelp = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.LblFzsl = New System.Windows.Forms.Label
        Me.BtnReference = New System.Windows.Forms.Button
        Me.LblSl = New System.Windows.Forms.Label
        Me.LblJe = New System.Windows.Forms.Label
        Me.BtnIns = New System.Windows.Forms.Button
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.LblMsg = New System.Windows.Forms.Label
        Me.BtnDelete = New System.Windows.Forms.Button
        Me.BtnExit = New System.Windows.Forms.Button
        Me.BtnNew = New System.Windows.Forms.Button
        Me.BtnHelp = New System.Windows.Forms.Button
        Me.BtnPrint = New System.Windows.Forms.Button
        Me.BtnPrintView = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.rcDataGridView = New System.Windows.Forms.DataGridView
        Me.rcBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.LblBdelete = New System.Windows.Forms.Label
        Me.LblRkd = New System.Windows.Forms.Label
        Me.LblDjh = New System.Windows.Forms.Label
        Me.TxtDjh = New System.Windows.Forms.TextBox
        Me.DtpRkrq = New System.Windows.Forms.DateTimePicker
        Me.LblRkrq = New System.Windows.Forms.Label
        Me.CmbPzlxjc = New System.Windows.Forms.ComboBox
        Me.LblZydm = New System.Windows.Forms.Label
        Me.TxtZydm = New System.Windows.Forms.TextBox
        Me.LblZymc = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblGxmc = New System.Windows.Forms.Label
        Me.TxtGxdm = New System.Windows.Forms.TextBox
        Me.LblGxdm = New System.Windows.Forms.Label
        Me.LblBmmc = New System.Windows.Forms.Label
        Me.TxtBmdm = New System.Windows.Forms.TextBox
        Me.LblBmdm = New System.Windows.Forms.Label
        Me.LblCkmc = New System.Windows.Forms.Label
        Me.TxtCkdm = New System.Windows.Forms.TextBox
        Me.LblCkdm = New System.Windows.Forms.Label
        Me.ColCpdm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCpmc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColHth = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColScph = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColSl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColDw = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColMjsl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColFzsl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColFzdw = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColRgdj = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColRgcb = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColDj = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColJe = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColRkmemo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStripPanel1.SuspendLayout()
        Me.MnuMain.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
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
        Me.ToolStripPanel1.Size = New System.Drawing.Size(1008, 25)
        '
        'MnuMain
        '
        Me.MnuMain.Dock = System.Windows.Forms.DockStyle.None
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiFile, Me.MnuiEdit, Me.MnuiHelp})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(1008, 25)
        Me.MnuMain.TabIndex = 0
        '
        'MnuiFile
        '
        Me.MnuiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiNew, Me.MnuiSave, Me.MnuiCancel, Me.MnuiZf, Me.ToolStripMenuItem1, Me.MnuiIns, Me.MnuiDelete, Me.Mnui11, Me.MnuiPageSetup, Me.MnuiPrintView, Me.MnuiPrint, Me.Mnui12, Me.MnuiExit})
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
        Me.MnuiSave.Enabled = False
        Me.MnuiSave.Name = "MnuiSave"
        Me.MnuiSave.Size = New System.Drawing.Size(166, 22)
        Me.MnuiSave.Text = "保存(&S)"
        '
        'MnuiCancel
        '
        Me.MnuiCancel.Enabled = False
        Me.MnuiCancel.Name = "MnuiCancel"
        Me.MnuiCancel.Size = New System.Drawing.Size(166, 22)
        Me.MnuiCancel.Text = "取消(&C)"
        '
        'MnuiZf
        '
        Me.MnuiZf.Name = "MnuiZf"
        Me.MnuiZf.Size = New System.Drawing.Size(166, 22)
        Me.MnuiZf.Text = "作废/恢复"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(163, 6)
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
        'Mnui11
        '
        Me.Mnui11.Name = "Mnui11"
        Me.Mnui11.Size = New System.Drawing.Size(163, 6)
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
        Me.MnuiEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiCut, Me.MnuiCopy, Me.MnuiPaste, Me.自定义显示列ToolStripMenuItem, Me.ToolStripMenuItem3})
        Me.MnuiEdit.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiEdit.Name = "MnuiEdit"
        Me.MnuiEdit.Size = New System.Drawing.Size(59, 21)
        Me.MnuiEdit.Text = "编辑(&E)"
        '
        'MnuiCut
        '
        Me.MnuiCut.Name = "MnuiCut"
        Me.MnuiCut.Size = New System.Drawing.Size(148, 22)
        Me.MnuiCut.Text = "剪切(&T)"
        '
        'MnuiCopy
        '
        Me.MnuiCopy.Name = "MnuiCopy"
        Me.MnuiCopy.Size = New System.Drawing.Size(148, 22)
        Me.MnuiCopy.Text = "复制(&C)"
        '
        'MnuiPaste
        '
        Me.MnuiPaste.Name = "MnuiPaste"
        Me.MnuiPaste.Size = New System.Drawing.Size(148, 22)
        Me.MnuiPaste.Text = "粘贴(&P)"
        '
        '自定义显示列ToolStripMenuItem
        '
        Me.自定义显示列ToolStripMenuItem.Name = "自定义显示列ToolStripMenuItem"
        Me.自定义显示列ToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.自定义显示列ToolStripMenuItem.Text = "自定义显示列"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(148, 22)
        Me.ToolStripMenuItem3.Text = "－"
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
        Me.Panel2.Controls.Add(Me.LblFzsl)
        Me.Panel2.Controls.Add(Me.BtnReference)
        Me.Panel2.Controls.Add(Me.LblSl)
        Me.Panel2.Controls.Add(Me.LblJe)
        Me.Panel2.Controls.Add(Me.BtnIns)
        Me.Panel2.Controls.Add(Me.BtnCancel)
        Me.Panel2.Controls.Add(Me.LblMsg)
        Me.Panel2.Controls.Add(Me.BtnDelete)
        Me.Panel2.Controls.Add(Me.BtnExit)
        Me.Panel2.Controls.Add(Me.BtnNew)
        Me.Panel2.Controls.Add(Me.BtnHelp)
        Me.Panel2.Controls.Add(Me.BtnPrint)
        Me.Panel2.Controls.Add(Me.BtnPrintView)
        Me.Panel2.Controls.Add(Me.BtnSave)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 433)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1008, 96)
        Me.Panel2.TabIndex = 2
        '
        'LblFzsl
        '
        Me.LblFzsl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblFzsl.AutoSize = True
        Me.LblFzsl.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblFzsl.Location = New System.Drawing.Point(607, 40)
        Me.LblFzsl.Name = "LblFzsl"
        Me.LblFzsl.Size = New System.Drawing.Size(104, 16)
        Me.LblFzsl.TabIndex = 19
        Me.LblFzsl.Text = "辅数量合计："
        '
        'BtnReference
        '
        Me.BtnReference.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnReference.Location = New System.Drawing.Point(229, 64)
        Me.BtnReference.Name = "BtnReference"
        Me.BtnReference.Size = New System.Drawing.Size(80, 23)
        Me.BtnReference.TabIndex = 18
        Me.BtnReference.Text = "参照录入(&R)"
        '
        'LblSl
        '
        Me.LblSl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSl.AutoSize = True
        Me.LblSl.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblSl.Location = New System.Drawing.Point(439, 40)
        Me.LblSl.Name = "LblSl"
        Me.LblSl.Size = New System.Drawing.Size(88, 16)
        Me.LblSl.TabIndex = 17
        Me.LblSl.Text = "数量合计："
        '
        'LblJe
        '
        Me.LblJe.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblJe.AutoSize = True
        Me.LblJe.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblJe.Location = New System.Drawing.Point(780, 40)
        Me.LblJe.Name = "LblJe"
        Me.LblJe.Size = New System.Drawing.Size(88, 16)
        Me.LblJe.TabIndex = 1
        Me.LblJe.Text = "金额合计："
        '
        'BtnIns
        '
        Me.BtnIns.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnIns.Location = New System.Drawing.Point(501, 64)
        Me.BtnIns.Name = "BtnIns"
        Me.BtnIns.Size = New System.Drawing.Size(64, 23)
        Me.BtnIns.TabIndex = 9
        Me.BtnIns.Text = "插入行(&I)"
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnCancel.Enabled = False
        Me.BtnCancel.Location = New System.Drawing.Point(437, 64)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(64, 23)
        Me.BtnCancel.TabIndex = 8
        Me.BtnCancel.Text = "取消(&C)"
        '
        'LblMsg
        '
        Me.LblMsg.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblMsg.AutoSize = True
        Me.LblMsg.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblMsg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblMsg.Location = New System.Drawing.Point(136, 8)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(280, 16)
        Me.LblMsg.TabIndex = 0
        Me.LblMsg.Text = "（此处显示各入库要素的详细内容。）"
        '
        'BtnDelete
        '
        Me.BtnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnDelete.Location = New System.Drawing.Point(565, 64)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(64, 23)
        Me.BtnDelete.TabIndex = 10
        Me.BtnDelete.Text = "删除行(&D)"
        '
        'BtnExit
        '
        Me.BtnExit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnExit.Location = New System.Drawing.Point(821, 64)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(64, 23)
        Me.BtnExit.TabIndex = 15
        Me.BtnExit.Text = "退出(&X)"
        '
        'BtnNew
        '
        Me.BtnNew.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnNew.Location = New System.Drawing.Point(309, 64)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(64, 23)
        Me.BtnNew.TabIndex = 6
        Me.BtnNew.Text = "新单(&A)"
        '
        'BtnHelp
        '
        Me.BtnHelp.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnHelp.Location = New System.Drawing.Point(757, 64)
        Me.BtnHelp.Name = "BtnHelp"
        Me.BtnHelp.Size = New System.Drawing.Size(64, 23)
        Me.BtnHelp.TabIndex = 14
        Me.BtnHelp.Text = "帮助(&H)"
        '
        'BtnPrint
        '
        Me.BtnPrint.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnPrint.Location = New System.Drawing.Point(629, 64)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(64, 23)
        Me.BtnPrint.TabIndex = 11
        Me.BtnPrint.Text = "打印(&P)"
        '
        'BtnPrintView
        '
        Me.BtnPrintView.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnPrintView.Location = New System.Drawing.Point(693, 64)
        Me.BtnPrintView.Name = "BtnPrintView"
        Me.BtnPrintView.Size = New System.Drawing.Size(64, 23)
        Me.BtnPrintView.TabIndex = 12
        Me.BtnPrintView.Text = "预览(&V)"
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnSave.Enabled = False
        Me.BtnSave.Location = New System.Drawing.Point(373, 64)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(64, 23)
        Me.BtnSave.TabIndex = 7
        Me.BtnSave.Text = "保存(&S)"
        '
        'rcDataGridView
        '
        Me.rcDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.rcDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColCpdm, Me.ColCpmc, Me.ColHth, Me.ColScph, Me.ColSl, Me.ColDw, Me.ColMjsl, Me.ColFzsl, Me.ColFzdw, Me.ColRgdj, Me.ColRgcb, Me.ColDj, Me.ColJe, Me.ColRkmemo})
        Me.rcDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rcDataGridView.Location = New System.Drawing.Point(0, 145)
        Me.rcDataGridView.Name = "rcDataGridView"
        Me.rcDataGridView.RowTemplate.Height = 23
        Me.rcDataGridView.Size = New System.Drawing.Size(1008, 288)
        Me.rcDataGridView.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.LblBdelete)
        Me.Panel3.Controls.Add(Me.LblRkd)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1008, 48)
        Me.Panel3.TabIndex = 0
        '
        'LblBdelete
        '
        Me.LblBdelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblBdelete.AutoSize = True
        Me.LblBdelete.Font = New System.Drawing.Font("黑体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblBdelete.ForeColor = System.Drawing.Color.Red
        Me.LblBdelete.Location = New System.Drawing.Point(864, 9)
        Me.LblBdelete.Name = "LblBdelete"
        Me.LblBdelete.Size = New System.Drawing.Size(60, 24)
        Me.LblBdelete.TabIndex = 1
        Me.LblBdelete.Text = "作废"
        '
        'LblRkd
        '
        Me.LblRkd.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblRkd.AutoSize = True
        Me.LblRkd.Font = New System.Drawing.Font("楷体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblRkd.ForeColor = System.Drawing.Color.SteelBlue
        Me.LblRkd.Location = New System.Drawing.Point(437, 9)
        Me.LblRkd.Name = "LblRkd"
        Me.LblRkd.Size = New System.Drawing.Size(135, 24)
        Me.LblRkd.TabIndex = 0
        Me.LblRkd.Text = "工序入库单"
        '
        'LblDjh
        '
        Me.LblDjh.AutoSize = True
        Me.LblDjh.Location = New System.Drawing.Point(16, 56)
        Me.LblDjh.Name = "LblDjh"
        Me.LblDjh.Size = New System.Drawing.Size(65, 12)
        Me.LblDjh.TabIndex = 1
        Me.LblDjh.Text = "单 据 号："
        '
        'TxtDjh
        '
        Me.TxtDjh.Location = New System.Drawing.Point(160, 56)
        Me.TxtDjh.MaxLength = 19
        Me.TxtDjh.Name = "TxtDjh"
        Me.TxtDjh.Size = New System.Drawing.Size(102, 21)
        Me.TxtDjh.TabIndex = 3
        '
        'DtpRkrq
        '
        Me.DtpRkrq.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.DtpRkrq.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpRkrq.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpRkrq.Location = New System.Drawing.Point(465, 56)
        Me.DtpRkrq.Name = "DtpRkrq"
        Me.DtpRkrq.Size = New System.Drawing.Size(151, 21)
        Me.DtpRkrq.TabIndex = 5
        '
        'LblRkrq
        '
        Me.LblRkrq.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblRkrq.AutoSize = True
        Me.LblRkrq.Location = New System.Drawing.Point(393, 60)
        Me.LblRkrq.Name = "LblRkrq"
        Me.LblRkrq.Size = New System.Drawing.Size(65, 12)
        Me.LblRkrq.TabIndex = 4
        Me.LblRkrq.Text = "入库日期："
        '
        'CmbPzlxjc
        '
        Me.CmbPzlxjc.Location = New System.Drawing.Point(88, 56)
        Me.CmbPzlxjc.Name = "CmbPzlxjc"
        Me.CmbPzlxjc.Size = New System.Drawing.Size(72, 20)
        Me.CmbPzlxjc.TabIndex = 2
        '
        'LblZydm
        '
        Me.LblZydm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblZydm.AutoSize = True
        Me.LblZydm.Location = New System.Drawing.Point(748, 62)
        Me.LblZydm.Name = "LblZydm"
        Me.LblZydm.Size = New System.Drawing.Size(65, 12)
        Me.LblZydm.TabIndex = 6
        Me.LblZydm.Text = "经 手 人："
        '
        'TxtZydm
        '
        Me.TxtZydm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtZydm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtZydm.Location = New System.Drawing.Point(820, 56)
        Me.TxtZydm.MaxLength = 12
        Me.TxtZydm.Name = "TxtZydm"
        Me.TxtZydm.Size = New System.Drawing.Size(87, 21)
        Me.TxtZydm.TabIndex = 7
        '
        'LblZymc
        '
        Me.LblZymc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblZymc.AutoSize = True
        Me.LblZymc.Location = New System.Drawing.Point(911, 62)
        Me.LblZymc.Name = "LblZymc"
        Me.LblZymc.Size = New System.Drawing.Size(0, 12)
        Me.LblZymc.TabIndex = 8
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FloralWhite
        Me.Panel1.Controls.Add(Me.LblGxmc)
        Me.Panel1.Controls.Add(Me.TxtGxdm)
        Me.Panel1.Controls.Add(Me.LblGxdm)
        Me.Panel1.Controls.Add(Me.LblBmmc)
        Me.Panel1.Controls.Add(Me.TxtBmdm)
        Me.Panel1.Controls.Add(Me.LblBmdm)
        Me.Panel1.Controls.Add(Me.LblCkmc)
        Me.Panel1.Controls.Add(Me.TxtCkdm)
        Me.Panel1.Controls.Add(Me.LblCkdm)
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
        Me.Panel1.Size = New System.Drawing.Size(1008, 120)
        Me.Panel1.TabIndex = 0
        '
        'LblGxmc
        '
        Me.LblGxmc.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblGxmc.AutoSize = True
        Me.LblGxmc.Location = New System.Drawing.Point(578, 89)
        Me.LblGxmc.Name = "LblGxmc"
        Me.LblGxmc.Size = New System.Drawing.Size(0, 12)
        Me.LblGxmc.TabIndex = 14
        '
        'TxtGxdm
        '
        Me.TxtGxdm.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtGxdm.Location = New System.Drawing.Point(488, 85)
        Me.TxtGxdm.MaxLength = 12
        Me.TxtGxdm.Name = "TxtGxdm"
        Me.TxtGxdm.Size = New System.Drawing.Size(87, 21)
        Me.TxtGxdm.TabIndex = 13
        '
        'LblGxdm
        '
        Me.LblGxdm.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblGxdm.AutoSize = True
        Me.LblGxdm.Location = New System.Drawing.Point(416, 89)
        Me.LblGxdm.Name = "LblGxdm"
        Me.LblGxdm.Size = New System.Drawing.Size(65, 12)
        Me.LblGxdm.TabIndex = 12
        Me.LblGxdm.Text = "工序编码："
        '
        'LblBmmc
        '
        Me.LblBmmc.AutoSize = True
        Me.LblBmmc.Location = New System.Drawing.Point(181, 89)
        Me.LblBmmc.Name = "LblBmmc"
        Me.LblBmmc.Size = New System.Drawing.Size(0, 12)
        Me.LblBmmc.TabIndex = 11
        '
        'TxtBmdm
        '
        Me.TxtBmdm.Location = New System.Drawing.Point(88, 85)
        Me.TxtBmdm.MaxLength = 12
        Me.TxtBmdm.Name = "TxtBmdm"
        Me.TxtBmdm.Size = New System.Drawing.Size(87, 21)
        Me.TxtBmdm.TabIndex = 10
        '
        'LblBmdm
        '
        Me.LblBmdm.AutoSize = True
        Me.LblBmdm.Location = New System.Drawing.Point(16, 89)
        Me.LblBmdm.Name = "LblBmdm"
        Me.LblBmdm.Size = New System.Drawing.Size(65, 12)
        Me.LblBmdm.TabIndex = 9
        Me.LblBmdm.Text = "部门编码："
        '
        'LblCkmc
        '
        Me.LblCkmc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCkmc.AutoSize = True
        Me.LblCkmc.Location = New System.Drawing.Point(911, 89)
        Me.LblCkmc.Name = "LblCkmc"
        Me.LblCkmc.Size = New System.Drawing.Size(0, 12)
        Me.LblCkmc.TabIndex = 17
        '
        'TxtCkdm
        '
        Me.TxtCkdm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCkdm.Location = New System.Drawing.Point(820, 85)
        Me.TxtCkdm.MaxLength = 30
        Me.TxtCkdm.Name = "TxtCkdm"
        Me.TxtCkdm.Size = New System.Drawing.Size(87, 21)
        Me.TxtCkdm.TabIndex = 16
        '
        'LblCkdm
        '
        Me.LblCkdm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCkdm.AutoSize = True
        Me.LblCkdm.Location = New System.Drawing.Point(748, 89)
        Me.LblCkdm.Name = "LblCkdm"
        Me.LblCkdm.Size = New System.Drawing.Size(65, 12)
        Me.LblCkdm.TabIndex = 15
        Me.LblCkdm.Text = "仓库编码："
        '
        'ColCpdm
        '
        Me.ColCpdm.DataPropertyName = "cpdm"
        Me.ColCpdm.HeaderText = "物料编码"
        Me.ColCpdm.Name = "ColCpdm"
        Me.ColCpdm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColCpdm.Width = 110
        '
        'ColCpmc
        '
        Me.ColCpmc.DataPropertyName = "cpmc"
        Me.ColCpmc.HeaderText = "物料名称"
        Me.ColCpmc.Name = "ColCpmc"
        Me.ColCpmc.ReadOnly = True
        Me.ColCpmc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColCpmc.Width = 240
        '
        'ColHth
        '
        Me.ColHth.DataPropertyName = "hth"
        Me.ColHth.HeaderText = "订单编码"
        Me.ColHth.Name = "ColHth"
        Me.ColHth.Width = 80
        '
        'ColScph
        '
        Me.ColScph.DataPropertyName = "scph"
        Me.ColScph.HeaderText = "生产批号"
        Me.ColScph.MaxInputLength = 20
        Me.ColScph.Name = "ColScph"
        Me.ColScph.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColScph.Width = 80
        '
        'ColSl
        '
        Me.ColSl.DataPropertyName = "sl"
        Me.ColSl.HeaderText = "数量"
        Me.ColSl.Name = "ColSl"
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
        'ColRgdj
        '
        Me.ColRgdj.DataPropertyName = "rgdj"
        Me.ColRgdj.HeaderText = "人工单价"
        Me.ColRgdj.Name = "ColRgdj"
        Me.ColRgdj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColRgdj.Width = 80
        '
        'ColRgcb
        '
        Me.ColRgcb.DataPropertyName = "rgcb"
        Me.ColRgcb.HeaderText = "人工工资"
        Me.ColRgcb.Name = "ColRgcb"
        Me.ColRgcb.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColRgcb.Width = 80
        '
        'ColDj
        '
        Me.ColDj.DataPropertyName = "dj"
        Me.ColDj.HeaderText = "单价"
        Me.ColDj.Name = "ColDj"
        Me.ColDj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColDj.Width = 90
        '
        'ColJe
        '
        Me.ColJe.DataPropertyName = "je"
        Me.ColJe.HeaderText = "金额"
        Me.ColJe.Name = "ColJe"
        Me.ColJe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColJe.Width = 90
        '
        'ColRkmemo
        '
        Me.ColRkmemo.DataPropertyName = "rkmemo"
        Me.ColRkmemo.HeaderText = "备注"
        Me.ColRkmemo.Name = "ColRkmemo"
        Me.ColRkmemo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColRkmemo.Width = 135
        '
        'FrmPmRkdSrz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 529)
        Me.Controls.Add(Me.rcDataGridView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStripPanel1)
        Me.Name = "FrmPmRkdSrz"
        Me.Text = "工序入库单输入"
        Me.ToolStripPanel1.ResumeLayout(False)
        Me.ToolStripPanel1.PerformLayout()
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripPanel1 As System.Windows.Forms.ToolStripPanel
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
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Public WithEvents LblMsg As System.Windows.Forms.Label
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents BtnHelp As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents BtnPrintView As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents rcDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents rcBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents MnuiCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnIns As System.Windows.Forms.Button
    Public WithEvents LblJe As System.Windows.Forms.Label
    Friend WithEvents MnuiIns As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiZf As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents LblSl As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents LblBdelete As System.Windows.Forms.Label
    Friend WithEvents LblRkd As System.Windows.Forms.Label
    Public WithEvents LblDjh As System.Windows.Forms.Label
    Public WithEvents TxtDjh As System.Windows.Forms.TextBox
    Public WithEvents DtpRkrq As System.Windows.Forms.DateTimePicker
    Public WithEvents LblRkrq As System.Windows.Forms.Label
    Friend WithEvents CmbPzlxjc As System.Windows.Forms.ComboBox
    Public WithEvents LblZydm As System.Windows.Forms.Label
    Public WithEvents TxtZydm As System.Windows.Forms.TextBox
    Public WithEvents LblZymc As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents LblCkmc As System.Windows.Forms.Label
    Public WithEvents TxtCkdm As System.Windows.Forms.TextBox
    Public WithEvents LblCkdm As System.Windows.Forms.Label
    Friend WithEvents BtnReference As System.Windows.Forms.Button
    Public WithEvents LblFzsl As System.Windows.Forms.Label
    Friend WithEvents TxtBmdm As System.Windows.Forms.TextBox
    Friend WithEvents LblBmdm As System.Windows.Forms.Label
    Friend WithEvents LblBmmc As System.Windows.Forms.Label
    Friend WithEvents LblGxmc As System.Windows.Forms.Label
    Friend WithEvents TxtGxdm As System.Windows.Forms.TextBox
    Friend WithEvents LblGxdm As System.Windows.Forms.Label
    Friend WithEvents 自定义显示列ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColCpdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCpmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColHth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColScph As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDw As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMjsl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFzsl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFzdw As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRgdj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRgcb As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRkmemo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
