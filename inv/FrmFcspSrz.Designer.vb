<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmFcspSrz
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolStripPanel1 = New System.Windows.Forms.ToolStripPanel()
        Me.MnuMain = New System.Windows.Forms.MenuStrip()
        Me.MnuiFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiZf = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuiIns = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiImpXls = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mnui11 = New System.Windows.Forms.ToolStripSeparator()
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LblCbje = New System.Windows.Forms.Label()
        Me.LblJe = New System.Windows.Forms.Label()
        Me.LblSl = New System.Windows.Forms.Label()
        Me.LblSe = New System.Windows.Forms.Label()
        Me.BtnIns = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.BtnHelp = New System.Windows.Forms.Button()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.BtnPrintView = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.rcDataGridView = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.LblRkd = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rcBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ColCkkjqj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDjh = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColXh = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColShKhdm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColShKhmc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFpKhdm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFpKhmc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColBmdm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColBmmc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCpdm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCpmc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDw = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColJe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCbje = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStripPanel1.SuspendLayout()
        Me.MnuMain.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolStripPanel1.Size = New System.Drawing.Size(786, 25)
        '
        'MnuMain
        '
        Me.MnuMain.Dock = System.Windows.Forms.DockStyle.None
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiFile, Me.MnuiEdit, Me.MnuiHelp})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(786, 25)
        Me.MnuMain.TabIndex = 0
        '
        'MnuiFile
        '
        Me.MnuiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiNew, Me.MnuiSave, Me.MnuiCancel, Me.MnuiZf, Me.ToolStripMenuItem1, Me.MnuiIns, Me.MnuiDelete, Me.MnuiImpXls, Me.Mnui11, Me.MnuiPageSetup, Me.MnuiPrintView, Me.MnuiPrint, Me.Mnui12, Me.MnuiExit})
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
        Me.MnuiCancel.Text = "取消(&C)"
        '
        'MnuiZf
        '
        Me.MnuiZf.Name = "MnuiZf"
        Me.MnuiZf.Size = New System.Drawing.Size(189, 22)
        Me.MnuiZf.Text = "作废/恢复"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(186, 6)
        '
        'MnuiIns
        '
        Me.MnuiIns.Name = "MnuiIns"
        Me.MnuiIns.Size = New System.Drawing.Size(189, 22)
        Me.MnuiIns.Text = "插入行(&I)"
        '
        'MnuiDelete
        '
        Me.MnuiDelete.Name = "MnuiDelete"
        Me.MnuiDelete.Size = New System.Drawing.Size(189, 22)
        Me.MnuiDelete.Text = "删除行(&D)"
        '
        'MnuiImpXls
        '
        Me.MnuiImpXls.Name = "MnuiImpXls"
        Me.MnuiImpXls.Size = New System.Drawing.Size(189, 22)
        Me.MnuiImpXls.Text = "导入Excel模板数据(&I)"
        '
        'Mnui11
        '
        Me.Mnui11.Name = "Mnui11"
        Me.Mnui11.Size = New System.Drawing.Size(186, 6)
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
        Me.MnuiPrint.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.MnuiPrint.Size = New System.Drawing.Size(189, 22)
        Me.MnuiPrint.Text = "打印(&P)"
        '
        'Mnui12
        '
        Me.Mnui12.Name = "Mnui12"
        Me.Mnui12.Size = New System.Drawing.Size(186, 6)
        '
        'MnuiExit
        '
        Me.MnuiExit.Name = "MnuiExit"
        Me.MnuiExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
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
        Me.Panel2.Controls.Add(Me.LblCbje)
        Me.Panel2.Controls.Add(Me.LblJe)
        Me.Panel2.Controls.Add(Me.LblSl)
        Me.Panel2.Controls.Add(Me.LblSe)
        Me.Panel2.Controls.Add(Me.BtnIns)
        Me.Panel2.Controls.Add(Me.BtnCancel)
        Me.Panel2.Controls.Add(Me.LblMsg)
        Me.Panel2.Controls.Add(Me.BtnDelete)
        Me.Panel2.Controls.Add(Me.BtnExit)
        Me.Panel2.Controls.Add(Me.BtnHelp)
        Me.Panel2.Controls.Add(Me.BtnPrint)
        Me.Panel2.Controls.Add(Me.BtnPrintView)
        Me.Panel2.Controls.Add(Me.BtnSave)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 380)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(786, 96)
        Me.Panel2.TabIndex = 2
        '
        'LblCbje
        '
        Me.LblCbje.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCbje.AutoSize = True
        Me.LblCbje.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblCbje.Location = New System.Drawing.Point(606, 40)
        Me.LblCbje.Name = "LblCbje"
        Me.LblCbje.Size = New System.Drawing.Size(119, 16)
        Me.LblCbje.TabIndex = 20
        Me.LblCbje.Text = "成本金额合计："
        '
        'LblJe
        '
        Me.LblJe.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblJe.AutoSize = True
        Me.LblJe.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblJe.Location = New System.Drawing.Point(215, 40)
        Me.LblJe.Name = "LblJe"
        Me.LblJe.Size = New System.Drawing.Size(87, 16)
        Me.LblJe.TabIndex = 19
        Me.LblJe.Text = "金额合计："
        '
        'LblSl
        '
        Me.LblSl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSl.AutoSize = True
        Me.LblSl.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblSl.Location = New System.Drawing.Point(7, 40)
        Me.LblSl.Name = "LblSl"
        Me.LblSl.Size = New System.Drawing.Size(87, 16)
        Me.LblSl.TabIndex = 17
        Me.LblSl.Text = "数量合计："
        '
        'LblSe
        '
        Me.LblSe.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSe.AutoSize = True
        Me.LblSe.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblSe.Location = New System.Drawing.Point(423, 40)
        Me.LblSe.Name = "LblSe"
        Me.LblSe.Size = New System.Drawing.Size(87, 16)
        Me.LblSe.TabIndex = 1
        Me.LblSe.Text = "税额合计："
        '
        'BtnIns
        '
        Me.BtnIns.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnIns.Location = New System.Drawing.Point(390, 64)
        Me.BtnIns.Name = "BtnIns"
        Me.BtnIns.Size = New System.Drawing.Size(64, 23)
        Me.BtnIns.TabIndex = 9
        Me.BtnIns.Text = "插入行(&I)"
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnCancel.Enabled = False
        Me.BtnCancel.Location = New System.Drawing.Point(326, 64)
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
        Me.LblMsg.Location = New System.Drawing.Point(25, 8)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(279, 16)
        Me.LblMsg.TabIndex = 0
        Me.LblMsg.Text = "（此处显示各盘存要素的详细内容。）"
        '
        'BtnDelete
        '
        Me.BtnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnDelete.Location = New System.Drawing.Point(454, 64)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(64, 23)
        Me.BtnDelete.TabIndex = 10
        Me.BtnDelete.Text = "删除行(&D)"
        '
        'BtnExit
        '
        Me.BtnExit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnExit.Location = New System.Drawing.Point(710, 64)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(64, 23)
        Me.BtnExit.TabIndex = 15
        Me.BtnExit.Text = "退出(&X)"
        '
        'BtnHelp
        '
        Me.BtnHelp.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnHelp.Location = New System.Drawing.Point(646, 64)
        Me.BtnHelp.Name = "BtnHelp"
        Me.BtnHelp.Size = New System.Drawing.Size(64, 23)
        Me.BtnHelp.TabIndex = 14
        Me.BtnHelp.Text = "帮助(&H)"
        '
        'BtnPrint
        '
        Me.BtnPrint.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnPrint.Location = New System.Drawing.Point(518, 64)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(64, 23)
        Me.BtnPrint.TabIndex = 11
        Me.BtnPrint.Text = "打印(&P)"
        '
        'BtnPrintView
        '
        Me.BtnPrintView.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnPrintView.Location = New System.Drawing.Point(582, 64)
        Me.BtnPrintView.Name = "BtnPrintView"
        Me.BtnPrintView.Size = New System.Drawing.Size(64, 23)
        Me.BtnPrintView.TabIndex = 12
        Me.BtnPrintView.Text = "预览(&V)"
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnSave.Enabled = False
        Me.BtnSave.Location = New System.Drawing.Point(262, 64)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(64, 23)
        Me.BtnSave.TabIndex = 7
        Me.BtnSave.Text = "保存(&S)"
        '
        'rcDataGridView
        '
        Me.rcDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.rcDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColCkkjqj, Me.ColDjh, Me.ColXh, Me.ColShKhdm, Me.ColShKhmc, Me.ColFpKhdm, Me.ColFpKhmc, Me.ColBmdm, Me.ColBmmc, Me.ColCpdm, Me.ColCpmc, Me.ColDw, Me.ColSl, Me.ColJe, Me.ColSe, Me.ColCbje})
        Me.rcDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rcDataGridView.Location = New System.Drawing.Point(0, 84)
        Me.rcDataGridView.Name = "rcDataGridView"
        Me.rcDataGridView.RowTemplate.Height = 23
        Me.rcDataGridView.Size = New System.Drawing.Size(786, 296)
        Me.rcDataGridView.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.LblRkd)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(786, 48)
        Me.Panel3.TabIndex = 0
        '
        'LblRkd
        '
        Me.LblRkd.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblRkd.AutoSize = True
        Me.LblRkd.Font = New System.Drawing.Font("楷体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblRkd.ForeColor = System.Drawing.Color.SteelBlue
        Me.LblRkd.Location = New System.Drawing.Point(326, 9)
        Me.LblRkd.Name = "LblRkd"
        Me.LblRkd.Size = New System.Drawing.Size(160, 24)
        Me.LblRkd.TabIndex = 0
        Me.LblRkd.Text = "期末发出商品"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FloralWhite
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(786, 59)
        Me.Panel1.TabIndex = 0
        '
        'ColCkkjqj
        '
        Me.ColCkkjqj.DataPropertyName = "ckkjqj"
        Me.ColCkkjqj.HeaderText = "出库会计期间"
        Me.ColCkkjqj.MaxInputLength = 6
        Me.ColCkkjqj.Name = "ColCkkjqj"
        Me.ColCkkjqj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColDjh
        '
        Me.ColDjh.DataPropertyName = "djh"
        Me.ColDjh.HeaderText = "单据号"
        Me.ColDjh.Name = "ColDjh"
        Me.ColDjh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColXh
        '
        Me.ColXh.DataPropertyName = "xh"
        Me.ColXh.HeaderText = "行号"
        Me.ColXh.Name = "ColXh"
        Me.ColXh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColShKhdm
        '
        Me.ColShKhdm.DataPropertyName = "shkhdm"
        Me.ColShKhdm.HeaderText = "收货客户编码"
        Me.ColShKhdm.Name = "ColShKhdm"
        Me.ColShKhdm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColShKhdm.Width = 110
        '
        'ColShKhmc
        '
        Me.ColShKhmc.DataPropertyName = "shkhmc"
        Me.ColShKhmc.HeaderText = "收货客户名称"
        Me.ColShKhmc.Name = "ColShKhmc"
        Me.ColShKhmc.ReadOnly = True
        Me.ColShKhmc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColShKhmc.Width = 180
        '
        'ColFpKhdm
        '
        Me.ColFpKhdm.DataPropertyName = "fpkhdm"
        Me.ColFpKhdm.HeaderText = "开票客户编码"
        Me.ColFpKhdm.Name = "ColFpKhdm"
        Me.ColFpKhdm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColFpKhdm.Width = 110
        '
        'ColFpKhmc
        '
        Me.ColFpKhmc.DataPropertyName = "fpkhmc"
        Me.ColFpKhmc.HeaderText = "开票客户名称"
        Me.ColFpKhmc.Name = "ColFpKhmc"
        Me.ColFpKhmc.ReadOnly = True
        Me.ColFpKhmc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColFpKhmc.Width = 180
        '
        'ColBmdm
        '
        Me.ColBmdm.DataPropertyName = "bmdm"
        Me.ColBmdm.HeaderText = "部门编码"
        Me.ColBmdm.Name = "ColBmdm"
        Me.ColBmdm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColBmdm.Width = 110
        '
        'ColBmmc
        '
        Me.ColBmmc.DataPropertyName = "bmmc"
        Me.ColBmmc.HeaderText = "部门名称"
        Me.ColBmmc.Name = "ColBmmc"
        Me.ColBmmc.ReadOnly = True
        Me.ColBmmc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColBmmc.Width = 150
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
        Me.ColCpmc.HeaderText = "物料描述"
        Me.ColCpmc.Name = "ColCpmc"
        Me.ColCpmc.ReadOnly = True
        Me.ColCpmc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColCpmc.Width = 240
        '
        'ColDw
        '
        Me.ColDw.DataPropertyName = "dw"
        Me.ColDw.HeaderText = "单位"
        Me.ColDw.Name = "ColDw"
        Me.ColDw.ReadOnly = True
        Me.ColDw.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColDw.Width = 30
        '
        'ColSl
        '
        Me.ColSl.DataPropertyName = "sl"
        Me.ColSl.HeaderText = "数量"
        Me.ColSl.MaxInputLength = 18
        Me.ColSl.Name = "ColSl"
        Me.ColSl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColSl.Width = 90
        '
        'ColJe
        '
        Me.ColJe.DataPropertyName = "je"
        Me.ColJe.HeaderText = "金额"
        Me.ColJe.MaxInputLength = 14
        Me.ColJe.Name = "ColJe"
        Me.ColJe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColSe
        '
        Me.ColSe.DataPropertyName = "se"
        Me.ColSe.HeaderText = "税额"
        Me.ColSe.MaxInputLength = 14
        Me.ColSe.Name = "ColSe"
        Me.ColSe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColCbje
        '
        Me.ColCbje.DataPropertyName = "cbje"
        Me.ColCbje.HeaderText = "成本金额"
        Me.ColCbje.MaxInputLength = 14
        Me.ColCbje.Name = "ColCbje"
        Me.ColCbje.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColCbje.Width = 80
        '
        'FrmFcspSrz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(786, 476)
        Me.Controls.Add(Me.rcDataGridView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStripPanel1)
        Me.Name = "FrmFcspSrz"
        Me.Text = "期末发出商品输入"
        Me.ToolStripPanel1.ResumeLayout(False)
        Me.ToolStripPanel1.PerformLayout()
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents BtnHelp As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents BtnPrintView As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents rcDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents rcBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents MnuiCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnIns As System.Windows.Forms.Button
    Public WithEvents LblSe As System.Windows.Forms.Label
    Friend WithEvents MnuiIns As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiZf As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents LblSl As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents LblRkd As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents LblJe As System.Windows.Forms.Label
    Public WithEvents LblCbje As Label
    Friend WithEvents MnuiImpXls As ToolStripMenuItem
    Friend WithEvents ColCkkjqj As DataGridViewTextBoxColumn
    Friend WithEvents ColDjh As DataGridViewTextBoxColumn
    Friend WithEvents ColXh As DataGridViewTextBoxColumn
    Friend WithEvents ColShKhdm As DataGridViewTextBoxColumn
    Friend WithEvents ColShKhmc As DataGridViewTextBoxColumn
    Friend WithEvents ColFpKhdm As DataGridViewTextBoxColumn
    Friend WithEvents ColFpKhmc As DataGridViewTextBoxColumn
    Friend WithEvents ColBmdm As DataGridViewTextBoxColumn
    Friend WithEvents ColBmmc As DataGridViewTextBoxColumn
    Friend WithEvents ColCpdm As DataGridViewTextBoxColumn
    Friend WithEvents ColCpmc As DataGridViewTextBoxColumn
    Friend WithEvents ColDw As DataGridViewTextBoxColumn
    Friend WithEvents ColSl As DataGridViewTextBoxColumn
    Friend WithEvents ColJe As DataGridViewTextBoxColumn
    Friend WithEvents ColSe As DataGridViewTextBoxColumn
    Friend WithEvents ColCbje As DataGridViewTextBoxColumn
End Class
