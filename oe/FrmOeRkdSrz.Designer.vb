<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeRkdSrz
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
        Me.LblFzsl = New System.Windows.Forms.Label()
        Me.BtnReference = New System.Windows.Forms.Button()
        Me.LblSl = New System.Windows.Forms.Label()
        Me.LblJe = New System.Windows.Forms.Label()
        Me.BtnIns = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.BtnNew = New System.Windows.Forms.Button()
        Me.BtnHelp = New System.Windows.Forms.Button()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.BtnPrintView = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.rcDataGridView = New System.Windows.Forms.DataGridView()
        Me.ColCpdm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCpmc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColHth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDw = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMjsl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFzsl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFzdw = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColJe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRkmemo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rcBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.LblBdelete = New System.Windows.Forms.Label()
        Me.LblRkd = New System.Windows.Forms.Label()
        Me.LblDjh = New System.Windows.Forms.Label()
        Me.TxtDjh = New System.Windows.Forms.TextBox()
        Me.DtpRkrq = New System.Windows.Forms.DateTimePicker()
        Me.LblRkrq = New System.Windows.Forms.Label()
        Me.CmbPzlxjc = New System.Windows.Forms.ComboBox()
        Me.LblZydm = New System.Windows.Forms.Label()
        Me.TxtZydm = New System.Windows.Forms.TextBox()
        Me.LblZymc = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LblBmmc = New System.Windows.Forms.Label()
        Me.TxtBmdm = New System.Windows.Forms.TextBox()
        Me.LblBmdm = New System.Windows.Forms.Label()
        Me.LblCkmc = New System.Windows.Forms.Label()
        Me.TxtCkdm = New System.Windows.Forms.TextBox()
        Me.LblCkdm = New System.Windows.Forms.Label()
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
        Me.ToolStripPanel1.Size = New System.Drawing.Size(1476, 36)
        '
        'MnuMain
        '
        Me.MnuMain.Dock = System.Windows.Forms.DockStyle.None
        Me.MnuMain.GripMargin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.MnuMain.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiFile, Me.MnuiEdit, Me.MnuiHelp})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(1476, 36)
        Me.MnuMain.TabIndex = 0
        '
        'MnuiFile
        '
        Me.MnuiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiNew, Me.MnuiSave, Me.MnuiCancel, Me.MnuiZf, Me.ToolStripMenuItem1, Me.MnuiIns, Me.MnuiDelete, Me.MnuiImpXls, Me.Mnui11, Me.MnuiPageSetup, Me.MnuiPrintView, Me.MnuiPrint, Me.Mnui12, Me.MnuiExit})
        Me.MnuiFile.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiFile.Name = "MnuiFile"
        Me.MnuiFile.Size = New System.Drawing.Size(84, 30)
        Me.MnuiFile.Text = "文件(&F)"
        '
        'MnuiNew
        '
        Me.MnuiNew.Name = "MnuiNew"
        Me.MnuiNew.Size = New System.Drawing.Size(278, 34)
        Me.MnuiNew.Text = "新单(&A)"
        '
        'MnuiSave
        '
        Me.MnuiSave.Enabled = False
        Me.MnuiSave.Name = "MnuiSave"
        Me.MnuiSave.Size = New System.Drawing.Size(278, 34)
        Me.MnuiSave.Text = "保存(&S)"
        '
        'MnuiCancel
        '
        Me.MnuiCancel.Enabled = False
        Me.MnuiCancel.Name = "MnuiCancel"
        Me.MnuiCancel.Size = New System.Drawing.Size(278, 34)
        Me.MnuiCancel.Text = "取消(&C)"
        '
        'MnuiZf
        '
        Me.MnuiZf.Name = "MnuiZf"
        Me.MnuiZf.Size = New System.Drawing.Size(278, 34)
        Me.MnuiZf.Text = "作废/恢复"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(275, 6)
        '
        'MnuiIns
        '
        Me.MnuiIns.Name = "MnuiIns"
        Me.MnuiIns.Size = New System.Drawing.Size(278, 34)
        Me.MnuiIns.Text = "插入行(&I)"
        '
        'MnuiDelete
        '
        Me.MnuiDelete.Name = "MnuiDelete"
        Me.MnuiDelete.Size = New System.Drawing.Size(278, 34)
        Me.MnuiDelete.Text = "删除行(&D)"
        '
        'MnuiImpXls
        '
        Me.MnuiImpXls.Name = "MnuiImpXls"
        Me.MnuiImpXls.Size = New System.Drawing.Size(278, 34)
        Me.MnuiImpXls.Text = "导入Excel模板数据(&I)"
        '
        'Mnui11
        '
        Me.Mnui11.Name = "Mnui11"
        Me.Mnui11.Size = New System.Drawing.Size(275, 6)
        '
        'MnuiPageSetup
        '
        Me.MnuiPageSetup.Name = "MnuiPageSetup"
        Me.MnuiPageSetup.Size = New System.Drawing.Size(278, 34)
        Me.MnuiPageSetup.Text = "页面设置(&U)"
        '
        'MnuiPrintView
        '
        Me.MnuiPrintView.Name = "MnuiPrintView"
        Me.MnuiPrintView.Size = New System.Drawing.Size(278, 34)
        Me.MnuiPrintView.Text = "打印预览(&V)"
        '
        'MnuiPrint
        '
        Me.MnuiPrint.Name = "MnuiPrint"
        Me.MnuiPrint.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.MnuiPrint.Size = New System.Drawing.Size(278, 34)
        Me.MnuiPrint.Text = "打印(&P)"
        '
        'Mnui12
        '
        Me.Mnui12.Name = "Mnui12"
        Me.Mnui12.Size = New System.Drawing.Size(275, 6)
        '
        'MnuiExit
        '
        Me.MnuiExit.Name = "MnuiExit"
        Me.MnuiExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.MnuiExit.Size = New System.Drawing.Size(278, 34)
        Me.MnuiExit.Text = "退出(&X)"
        '
        'MnuiEdit
        '
        Me.MnuiEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiCut, Me.MnuiCopy, Me.MnuiPaste})
        Me.MnuiEdit.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiEdit.Name = "MnuiEdit"
        Me.MnuiEdit.Size = New System.Drawing.Size(84, 30)
        Me.MnuiEdit.Text = "编辑(&E)"
        '
        'MnuiCut
        '
        Me.MnuiCut.Name = "MnuiCut"
        Me.MnuiCut.Size = New System.Drawing.Size(170, 34)
        Me.MnuiCut.Text = "剪切(&T)"
        '
        'MnuiCopy
        '
        Me.MnuiCopy.Name = "MnuiCopy"
        Me.MnuiCopy.Size = New System.Drawing.Size(170, 34)
        Me.MnuiCopy.Text = "复制(&C)"
        '
        'MnuiPaste
        '
        Me.MnuiPaste.Name = "MnuiPaste"
        Me.MnuiPaste.Size = New System.Drawing.Size(170, 34)
        Me.MnuiPaste.Text = "粘贴(&P)"
        '
        'MnuiHelp
        '
        Me.MnuiHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiAbout})
        Me.MnuiHelp.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiHelp.Name = "MnuiHelp"
        Me.MnuiHelp.Size = New System.Drawing.Size(88, 30)
        Me.MnuiHelp.Text = "帮助(&H)"
        '
        'MnuiAbout
        '
        Me.MnuiAbout.Name = "MnuiAbout"
        Me.MnuiAbout.Size = New System.Drawing.Size(171, 34)
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
        Me.Panel2.Location = New System.Drawing.Point(0, 698)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1476, 144)
        Me.Panel2.TabIndex = 2
        '
        'LblFzsl
        '
        Me.LblFzsl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblFzsl.AutoSize = True
        Me.LblFzsl.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblFzsl.Location = New System.Drawing.Point(874, 60)
        Me.LblFzsl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblFzsl.Name = "LblFzsl"
        Me.LblFzsl.Size = New System.Drawing.Size(154, 24)
        Me.LblFzsl.TabIndex = 19
        Me.LblFzsl.Text = "辅数量合计："
        '
        'BtnReference
        '
        Me.BtnReference.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnReference.Location = New System.Drawing.Point(326, 96)
        Me.BtnReference.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnReference.Name = "BtnReference"
        Me.BtnReference.Size = New System.Drawing.Size(120, 34)
        Me.BtnReference.TabIndex = 18
        Me.BtnReference.Text = "参照录入(&R)"
        '
        'LblSl
        '
        Me.LblSl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSl.AutoSize = True
        Me.LblSl.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblSl.Location = New System.Drawing.Point(622, 60)
        Me.LblSl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblSl.Name = "LblSl"
        Me.LblSl.Size = New System.Drawing.Size(130, 24)
        Me.LblSl.TabIndex = 17
        Me.LblSl.Text = "数量合计："
        '
        'LblJe
        '
        Me.LblJe.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblJe.AutoSize = True
        Me.LblJe.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblJe.Location = New System.Drawing.Point(1134, 60)
        Me.LblJe.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblJe.Name = "LblJe"
        Me.LblJe.Size = New System.Drawing.Size(130, 24)
        Me.LblJe.TabIndex = 1
        Me.LblJe.Text = "金额合计："
        '
        'BtnIns
        '
        Me.BtnIns.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnIns.Location = New System.Drawing.Point(734, 96)
        Me.BtnIns.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnIns.Name = "BtnIns"
        Me.BtnIns.Size = New System.Drawing.Size(96, 34)
        Me.BtnIns.TabIndex = 9
        Me.BtnIns.Text = "插入行(&I)"
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnCancel.Enabled = False
        Me.BtnCancel.Location = New System.Drawing.Point(638, 96)
        Me.BtnCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(96, 34)
        Me.BtnCancel.TabIndex = 8
        Me.BtnCancel.Text = "取消(&C)"
        '
        'LblMsg
        '
        Me.LblMsg.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblMsg.AutoSize = True
        Me.LblMsg.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblMsg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblMsg.Location = New System.Drawing.Point(186, 12)
        Me.LblMsg.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(418, 24)
        Me.LblMsg.TabIndex = 0
        Me.LblMsg.Text = "（此处显示各入库要素的详细内容。）"
        '
        'BtnDelete
        '
        Me.BtnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnDelete.Location = New System.Drawing.Point(830, 96)
        Me.BtnDelete.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(96, 34)
        Me.BtnDelete.TabIndex = 10
        Me.BtnDelete.Text = "删除行(&D)"
        '
        'BtnExit
        '
        Me.BtnExit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnExit.Location = New System.Drawing.Point(1214, 96)
        Me.BtnExit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(96, 34)
        Me.BtnExit.TabIndex = 15
        Me.BtnExit.Text = "退出(&X)"
        '
        'BtnNew
        '
        Me.BtnNew.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnNew.Location = New System.Drawing.Point(446, 96)
        Me.BtnNew.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(96, 34)
        Me.BtnNew.TabIndex = 6
        Me.BtnNew.Text = "新单(&A)"
        '
        'BtnHelp
        '
        Me.BtnHelp.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnHelp.Location = New System.Drawing.Point(1118, 96)
        Me.BtnHelp.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnHelp.Name = "BtnHelp"
        Me.BtnHelp.Size = New System.Drawing.Size(96, 34)
        Me.BtnHelp.TabIndex = 14
        Me.BtnHelp.Text = "帮助(&H)"
        '
        'BtnPrint
        '
        Me.BtnPrint.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnPrint.Location = New System.Drawing.Point(926, 96)
        Me.BtnPrint.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(96, 34)
        Me.BtnPrint.TabIndex = 11
        Me.BtnPrint.Text = "打印(&P)"
        '
        'BtnPrintView
        '
        Me.BtnPrintView.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnPrintView.Location = New System.Drawing.Point(1022, 96)
        Me.BtnPrintView.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnPrintView.Name = "BtnPrintView"
        Me.BtnPrintView.Size = New System.Drawing.Size(96, 34)
        Me.BtnPrintView.TabIndex = 12
        Me.BtnPrintView.Text = "预览(&V)"
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnSave.Enabled = False
        Me.BtnSave.Location = New System.Drawing.Point(542, 96)
        Me.BtnSave.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(96, 34)
        Me.BtnSave.TabIndex = 7
        Me.BtnSave.Text = "保存(&S)"
        '
        'rcDataGridView
        '
        Me.rcDataGridView.ColumnHeadersHeight = 30
        Me.rcDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColCpdm, Me.ColCpmc, Me.ColHth, Me.ColSl, Me.ColDw, Me.ColMjsl, Me.ColFzsl, Me.ColFzdw, Me.ColDj, Me.ColJe, Me.ColRkmemo})
        Me.rcDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rcDataGridView.Location = New System.Drawing.Point(0, 216)
        Me.rcDataGridView.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rcDataGridView.Name = "rcDataGridView"
        Me.rcDataGridView.RowHeadersWidth = 62
        Me.rcDataGridView.RowTemplate.Height = 23
        Me.rcDataGridView.Size = New System.Drawing.Size(1476, 482)
        Me.rcDataGridView.TabIndex = 1
        '
        'ColCpdm
        '
        Me.ColCpdm.DataPropertyName = "cpdm"
        Me.ColCpdm.HeaderText = "物料编码"
        Me.ColCpdm.MinimumWidth = 8
        Me.ColCpdm.Name = "ColCpdm"
        Me.ColCpdm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColCpdm.Width = 110
        '
        'ColCpmc
        '
        Me.ColCpmc.DataPropertyName = "cpmc"
        Me.ColCpmc.HeaderText = "物料描述"
        Me.ColCpmc.MinimumWidth = 8
        Me.ColCpmc.Name = "ColCpmc"
        Me.ColCpmc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColCpmc.Width = 240
        '
        'ColHth
        '
        Me.ColHth.DataPropertyName = "hth"
        Me.ColHth.HeaderText = "订单号"
        Me.ColHth.MinimumWidth = 8
        Me.ColHth.Name = "ColHth"
        Me.ColHth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColHth.Width = 150
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
        'ColDw
        '
        Me.ColDw.DataPropertyName = "dw"
        Me.ColDw.HeaderText = "单位"
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
        Me.ColDj.HeaderText = "单价"
        Me.ColDj.MinimumWidth = 8
        Me.ColDj.Name = "ColDj"
        Me.ColDj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColDj.Width = 90
        '
        'ColJe
        '
        Me.ColJe.DataPropertyName = "je"
        Me.ColJe.HeaderText = "金额"
        Me.ColJe.MinimumWidth = 8
        Me.ColJe.Name = "ColJe"
        Me.ColJe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColJe.Width = 90
        '
        'ColRkmemo
        '
        Me.ColRkmemo.DataPropertyName = "rkmemo"
        Me.ColRkmemo.HeaderText = "备注"
        Me.ColRkmemo.MinimumWidth = 8
        Me.ColRkmemo.Name = "ColRkmemo"
        Me.ColRkmemo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColRkmemo.Width = 135
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.LblBdelete)
        Me.Panel3.Controls.Add(Me.LblRkd)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1476, 72)
        Me.Panel3.TabIndex = 0
        '
        'LblBdelete
        '
        Me.LblBdelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblBdelete.AutoSize = True
        Me.LblBdelete.Font = New System.Drawing.Font("黑体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblBdelete.ForeColor = System.Drawing.Color.Red
        Me.LblBdelete.Location = New System.Drawing.Point(1260, 14)
        Me.LblBdelete.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBdelete.Name = "LblBdelete"
        Me.LblBdelete.Size = New System.Drawing.Size(89, 36)
        Me.LblBdelete.TabIndex = 1
        Me.LblBdelete.Text = "作废"
        '
        'LblRkd
        '
        Me.LblRkd.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblRkd.AutoSize = True
        Me.LblRkd.Font = New System.Drawing.Font("楷体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblRkd.ForeColor = System.Drawing.Color.SteelBlue
        Me.LblRkd.Location = New System.Drawing.Point(638, 14)
        Me.LblRkd.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblRkd.Name = "LblRkd"
        Me.LblRkd.Size = New System.Drawing.Size(200, 36)
        Me.LblRkd.TabIndex = 0
        Me.LblRkd.Text = "产品入库单"
        '
        'LblDjh
        '
        Me.LblDjh.AutoSize = True
        Me.LblDjh.Location = New System.Drawing.Point(24, 90)
        Me.LblDjh.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDjh.Name = "LblDjh"
        Me.LblDjh.Size = New System.Drawing.Size(98, 18)
        Me.LblDjh.TabIndex = 1
        Me.LblDjh.Text = "单 据 号："
        '
        'TxtDjh
        '
        Me.TxtDjh.Location = New System.Drawing.Point(254, 84)
        Me.TxtDjh.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtDjh.MaxLength = 19
        Me.TxtDjh.Name = "TxtDjh"
        Me.TxtDjh.Size = New System.Drawing.Size(151, 28)
        Me.TxtDjh.TabIndex = 3
        '
        'DtpRkrq
        '
        Me.DtpRkrq.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.DtpRkrq.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpRkrq.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpRkrq.Location = New System.Drawing.Point(681, 84)
        Me.DtpRkrq.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DtpRkrq.Name = "DtpRkrq"
        Me.DtpRkrq.Size = New System.Drawing.Size(224, 28)
        Me.DtpRkrq.TabIndex = 5
        '
        'LblRkrq
        '
        Me.LblRkrq.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblRkrq.AutoSize = True
        Me.LblRkrq.Location = New System.Drawing.Point(572, 90)
        Me.LblRkrq.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblRkrq.Name = "LblRkrq"
        Me.LblRkrq.Size = New System.Drawing.Size(98, 18)
        Me.LblRkrq.TabIndex = 4
        Me.LblRkrq.Text = "入库日期："
        '
        'CmbPzlxjc
        '
        Me.CmbPzlxjc.Location = New System.Drawing.Point(134, 84)
        Me.CmbPzlxjc.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CmbPzlxjc.Name = "CmbPzlxjc"
        Me.CmbPzlxjc.Size = New System.Drawing.Size(106, 26)
        Me.CmbPzlxjc.TabIndex = 2
        '
        'LblZydm
        '
        Me.LblZydm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblZydm.AutoSize = True
        Me.LblZydm.Location = New System.Drawing.Point(1086, 90)
        Me.LblZydm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblZydm.Name = "LblZydm"
        Me.LblZydm.Size = New System.Drawing.Size(98, 18)
        Me.LblZydm.TabIndex = 6
        Me.LblZydm.Text = "经 手 人："
        '
        'TxtZydm
        '
        Me.TxtZydm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtZydm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtZydm.Location = New System.Drawing.Point(1196, 84)
        Me.TxtZydm.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtZydm.MaxLength = 12
        Me.TxtZydm.Name = "TxtZydm"
        Me.TxtZydm.Size = New System.Drawing.Size(128, 28)
        Me.TxtZydm.TabIndex = 7
        '
        'LblZymc
        '
        Me.LblZymc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblZymc.AutoSize = True
        Me.LblZymc.Location = New System.Drawing.Point(1338, 90)
        Me.LblZymc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblZymc.Name = "LblZymc"
        Me.LblZymc.Size = New System.Drawing.Size(0, 18)
        Me.LblZymc.TabIndex = 8
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FloralWhite
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
        Me.Panel1.Location = New System.Drawing.Point(0, 36)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1476, 180)
        Me.Panel1.TabIndex = 0
        '
        'LblBmmc
        '
        Me.LblBmmc.AutoSize = True
        Me.LblBmmc.Location = New System.Drawing.Point(276, 134)
        Me.LblBmmc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBmmc.Name = "LblBmmc"
        Me.LblBmmc.Size = New System.Drawing.Size(0, 18)
        Me.LblBmmc.TabIndex = 11
        '
        'TxtBmdm
        '
        Me.TxtBmdm.Location = New System.Drawing.Point(134, 128)
        Me.TxtBmdm.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtBmdm.MaxLength = 12
        Me.TxtBmdm.Name = "TxtBmdm"
        Me.TxtBmdm.Size = New System.Drawing.Size(128, 28)
        Me.TxtBmdm.TabIndex = 10
        '
        'LblBmdm
        '
        Me.LblBmdm.AutoSize = True
        Me.LblBmdm.Location = New System.Drawing.Point(24, 134)
        Me.LblBmdm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBmdm.Name = "LblBmdm"
        Me.LblBmdm.Size = New System.Drawing.Size(98, 18)
        Me.LblBmdm.TabIndex = 9
        Me.LblBmdm.Text = "部门编码："
        '
        'LblCkmc
        '
        Me.LblCkmc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCkmc.AutoSize = True
        Me.LblCkmc.Location = New System.Drawing.Point(1338, 134)
        Me.LblCkmc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCkmc.Name = "LblCkmc"
        Me.LblCkmc.Size = New System.Drawing.Size(0, 18)
        Me.LblCkmc.TabIndex = 14
        '
        'TxtCkdm
        '
        Me.TxtCkdm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCkdm.Location = New System.Drawing.Point(1196, 128)
        Me.TxtCkdm.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCkdm.MaxLength = 30
        Me.TxtCkdm.Name = "TxtCkdm"
        Me.TxtCkdm.Size = New System.Drawing.Size(128, 28)
        Me.TxtCkdm.TabIndex = 13
        '
        'LblCkdm
        '
        Me.LblCkdm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCkdm.AutoSize = True
        Me.LblCkdm.Location = New System.Drawing.Point(1086, 134)
        Me.LblCkdm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCkdm.Name = "LblCkdm"
        Me.LblCkdm.Size = New System.Drawing.Size(98, 18)
        Me.LblCkdm.TabIndex = 12
        Me.LblCkdm.Text = "仓库编码："
        '
        'FrmOeRkdSrz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1476, 842)
        Me.Controls.Add(Me.rcDataGridView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStripPanel1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FrmOeRkdSrz"
        Me.Text = "产品入库单输入"
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
    Friend WithEvents MnuiImpXls As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColCpdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCpmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColHth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDw As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMjsl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFzsl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFzdw As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRkmemo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
