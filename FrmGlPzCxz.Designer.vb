<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGlPzCxz
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
        Me.MnuiTop = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiPrevious = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiNext = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiBottom = New System.Windows.Forms.ToolStripMenuItem
        Me.Mnui11 = New System.Windows.Forms.ToolStripSeparator
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
        Me.TxtFjzs = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.LblPzrq = New System.Windows.Forms.Label
        Me.DtpPzrq = New System.Windows.Forms.DateTimePicker
        Me.TxtDjh = New System.Windows.Forms.TextBox
        Me.LblDjh = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.LblBdelete = New System.Windows.Forms.Label
        Me.LblCkd = New System.Windows.Forms.Label
        Me.rcDataGridView = New System.Windows.Forms.DataGridView
        Me.ColZy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColKmdm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColKmmc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColBmdm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColBmmc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColKhdm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColKhmc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColYspz = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColJsr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColWldqr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColXmdm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColXmmc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColSl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColDj = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColWb = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColHl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColJfje = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColDfje = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.rcBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.BtnExit = New System.Windows.Forms.Button
        Me.BtnTop = New System.Windows.Forms.Button
        Me.BtnPrint = New System.Windows.Forms.Button
        Me.BtnHelp = New System.Windows.Forms.Button
        Me.BtnNext = New System.Windows.Forms.Button
        Me.BtnBottom = New System.Windows.Forms.Button
        Me.BtnPrevious = New System.Windows.Forms.Button
        Me.LblJzr = New System.Windows.Forms.Label
        Me.LblShr = New System.Windows.Forms.Label
        Me.LblSrr = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.LblJe = New System.Windows.Forms.Label
        Me.LblSl = New System.Windows.Forms.Label
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
        Me.MnuMain.Size = New System.Drawing.Size(786, 25)
        Me.MnuMain.TabIndex = 1
        '
        'MnuiFile
        '
        Me.MnuiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiTop, Me.MnuiPrevious, Me.MnuiNext, Me.MnuiBottom, Me.Mnui11, Me.MnuiPageSetup, Me.MnuiPrintView, Me.MnuiPrint, Me.Mnui13, Me.MnuiExit})
        Me.MnuiFile.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiFile.Name = "MnuiFile"
        Me.MnuiFile.Size = New System.Drawing.Size(58, 21)
        Me.MnuiFile.Text = "文件(&F)"
        '
        'MnuiTop
        '
        Me.MnuiTop.Name = "MnuiTop"
        Me.MnuiTop.Size = New System.Drawing.Size(141, 22)
        Me.MnuiTop.Text = "首张(&S)"
        '
        'MnuiPrevious
        '
        Me.MnuiPrevious.Name = "MnuiPrevious"
        Me.MnuiPrevious.Size = New System.Drawing.Size(141, 22)
        Me.MnuiPrevious.Text = "上张(&C)"
        '
        'MnuiNext
        '
        Me.MnuiNext.Name = "MnuiNext"
        Me.MnuiNext.Size = New System.Drawing.Size(141, 22)
        Me.MnuiNext.Text = "下张(&Q)"
        '
        'MnuiBottom
        '
        Me.MnuiBottom.Name = "MnuiBottom"
        Me.MnuiBottom.Size = New System.Drawing.Size(141, 22)
        Me.MnuiBottom.Text = "末张(&Y)"
        '
        'Mnui11
        '
        Me.Mnui11.Name = "Mnui11"
        Me.Mnui11.Size = New System.Drawing.Size(138, 6)
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
        Me.ToolStripPanel1.Size = New System.Drawing.Size(786, 25)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FloralWhite
        Me.Panel1.Controls.Add(Me.TxtFjzs)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.LblPzrq)
        Me.Panel1.Controls.Add(Me.DtpPzrq)
        Me.Panel1.Controls.Add(Me.TxtDjh)
        Me.Panel1.Controls.Add(Me.LblDjh)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(786, 94)
        Me.Panel1.TabIndex = 0
        '
        'TxtFjzs
        '
        Me.TxtFjzs.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtFjzs.Enabled = False
        Me.TxtFjzs.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtFjzs.Location = New System.Drawing.Point(666, 54)
        Me.TxtFjzs.Name = "TxtFjzs"
        Me.TxtFjzs.Size = New System.Drawing.Size(63, 26)
        Me.TxtFjzs.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label5.Location = New System.Drawing.Point(735, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 16)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "张"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.Location = New System.Drawing.Point(620, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "附件"
        '
        'LblPzrq
        '
        Me.LblPzrq.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblPzrq.AutoSize = True
        Me.LblPzrq.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblPzrq.Location = New System.Drawing.Point(315, 59)
        Me.LblPzrq.Name = "LblPzrq"
        Me.LblPzrq.Size = New System.Drawing.Size(56, 16)
        Me.LblPzrq.TabIndex = 4
        Me.LblPzrq.Text = "日期："
        '
        'DtpPzrq
        '
        Me.DtpPzrq.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.DtpPzrq.Enabled = False
        Me.DtpPzrq.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.DtpPzrq.Location = New System.Drawing.Point(375, 54)
        Me.DtpPzrq.Name = "DtpPzrq"
        Me.DtpPzrq.Size = New System.Drawing.Size(136, 26)
        Me.DtpPzrq.TabIndex = 5
        '
        'TxtDjh
        '
        Me.TxtDjh.Enabled = False
        Me.TxtDjh.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtDjh.Location = New System.Drawing.Point(85, 54)
        Me.TxtDjh.MaxLength = 15
        Me.TxtDjh.Name = "TxtDjh"
        Me.TxtDjh.Size = New System.Drawing.Size(127, 26)
        Me.TxtDjh.TabIndex = 3
        '
        'LblDjh
        '
        Me.LblDjh.AutoSize = True
        Me.LblDjh.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblDjh.Location = New System.Drawing.Point(17, 59)
        Me.LblDjh.Name = "LblDjh"
        Me.LblDjh.Size = New System.Drawing.Size(72, 16)
        Me.LblDjh.TabIndex = 1
        Me.LblDjh.Text = "凭证号："
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.LblBdelete)
        Me.Panel3.Controls.Add(Me.LblCkd)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(786, 48)
        Me.Panel3.TabIndex = 0
        '
        'LblBdelete
        '
        Me.LblBdelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblBdelete.AutoSize = True
        Me.LblBdelete.Font = New System.Drawing.Font("黑体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblBdelete.ForeColor = System.Drawing.Color.Red
        Me.LblBdelete.Location = New System.Drawing.Point(662, 9)
        Me.LblBdelete.Name = "LblBdelete"
        Me.LblBdelete.Size = New System.Drawing.Size(60, 24)
        Me.LblBdelete.TabIndex = 10
        Me.LblBdelete.Text = "作废"
        '
        'LblCkd
        '
        Me.LblCkd.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblCkd.AutoSize = True
        Me.LblCkd.Font = New System.Drawing.Font("楷体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblCkd.ForeColor = System.Drawing.Color.SteelBlue
        Me.LblCkd.Location = New System.Drawing.Point(338, 9)
        Me.LblCkd.Name = "LblCkd"
        Me.LblCkd.Size = New System.Drawing.Size(110, 24)
        Me.LblCkd.TabIndex = 0
        Me.LblCkd.Text = "记账凭证"
        '
        'rcDataGridView
        '
        Me.rcDataGridView.AllowUserToAddRows = False
        Me.rcDataGridView.AllowUserToDeleteRows = False
        Me.rcDataGridView.ColumnHeadersHeight = 30
        Me.rcDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.rcDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColZy, Me.ColKmdm, Me.ColKmmc, Me.ColBmdm, Me.ColBmmc, Me.ColKhdm, Me.ColKhmc, Me.ColYspz, Me.ColJsr, Me.ColWldqr, Me.ColXmdm, Me.ColXmmc, Me.ColSl, Me.ColDj, Me.ColWb, Me.ColHl, Me.ColJfje, Me.ColDfje})
        Me.rcDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rcDataGridView.Location = New System.Drawing.Point(0, 119)
        Me.rcDataGridView.MultiSelect = False
        Me.rcDataGridView.Name = "rcDataGridView"
        Me.rcDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.rcDataGridView.RowTemplate.Height = 23
        Me.rcDataGridView.Size = New System.Drawing.Size(786, 279)
        Me.rcDataGridView.TabIndex = 1
        '
        'ColZy
        '
        Me.ColZy.DataPropertyName = "zy"
        Me.ColZy.HeaderText = "摘        要"
        Me.ColZy.MaxInputLength = 200
        Me.ColZy.Name = "ColZy"
        Me.ColZy.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColZy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColZy.ToolTipText = "摘要"
        Me.ColZy.Width = 190
        '
        'ColKmdm
        '
        Me.ColKmdm.DataPropertyName = "kmdm"
        Me.ColKmdm.HeaderText = "科目编码"
        Me.ColKmdm.MaxInputLength = 15
        Me.ColKmdm.Name = "ColKmdm"
        Me.ColKmdm.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColKmdm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColKmdm.ToolTipText = "科目编码"
        '
        'ColKmmc
        '
        Me.ColKmmc.DataPropertyName = "kmmc"
        Me.ColKmmc.HeaderText = "科目名称"
        Me.ColKmmc.MaxInputLength = 200
        Me.ColKmmc.Name = "ColKmmc"
        Me.ColKmmc.ReadOnly = True
        Me.ColKmmc.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColKmmc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColKmmc.ToolTipText = "科目名称"
        Me.ColKmmc.Width = 200
        '
        'ColBmdm
        '
        Me.ColBmdm.DataPropertyName = "bmdm"
        Me.ColBmdm.HeaderText = "部门编码"
        Me.ColBmdm.Name = "ColBmdm"
        Me.ColBmdm.Visible = False
        '
        'ColBmmc
        '
        Me.ColBmmc.DataPropertyName = "bmmc"
        Me.ColBmmc.HeaderText = "部门名称"
        Me.ColBmmc.Name = "ColBmmc"
        Me.ColBmmc.Visible = False
        Me.ColBmmc.Width = 200
        '
        'ColKhdm
        '
        Me.ColKhdm.DataPropertyName = "khdm"
        Me.ColKhdm.HeaderText = "客户编码"
        Me.ColKhdm.Name = "ColKhdm"
        Me.ColKhdm.Visible = False
        '
        'ColKhmc
        '
        Me.ColKhmc.DataPropertyName = "khmc"
        Me.ColKhmc.HeaderText = "客户名称"
        Me.ColKhmc.Name = "ColKhmc"
        Me.ColKhmc.Visible = False
        Me.ColKhmc.Width = 200
        '
        'ColYspz
        '
        Me.ColYspz.DataPropertyName = "yspz"
        Me.ColYspz.HeaderText = "原始凭证号"
        Me.ColYspz.Name = "ColYspz"
        Me.ColYspz.Visible = False
        '
        'ColJsr
        '
        Me.ColJsr.DataPropertyName = "jsr"
        Me.ColJsr.HeaderText = "经手人"
        Me.ColJsr.Name = "ColJsr"
        Me.ColJsr.Visible = False
        '
        'ColWldqr
        '
        Me.ColWldqr.DataPropertyName = "wldqr"
        Me.ColWldqr.HeaderText = "到期日"
        Me.ColWldqr.Name = "ColWldqr"
        Me.ColWldqr.Visible = False
        '
        'ColXmdm
        '
        Me.ColXmdm.DataPropertyName = "xmdm"
        Me.ColXmdm.HeaderText = "项目编码"
        Me.ColXmdm.Name = "ColXmdm"
        Me.ColXmdm.Visible = False
        '
        'ColXmmc
        '
        Me.ColXmmc.DataPropertyName = "xmmc"
        Me.ColXmmc.HeaderText = "项目名称"
        Me.ColXmmc.Name = "ColXmmc"
        Me.ColXmmc.Visible = False
        Me.ColXmmc.Width = 200
        '
        'ColSl
        '
        Me.ColSl.DataPropertyName = "sl"
        Me.ColSl.HeaderText = "数量"
        Me.ColSl.Name = "ColSl"
        Me.ColSl.Visible = False
        '
        'ColDj
        '
        Me.ColDj.DataPropertyName = "dj"
        Me.ColDj.HeaderText = "单价"
        Me.ColDj.Name = "ColDj"
        Me.ColDj.Visible = False
        '
        'ColWb
        '
        Me.ColWb.DataPropertyName = "wb"
        Me.ColWb.HeaderText = "外币"
        Me.ColWb.Name = "ColWb"
        Me.ColWb.Visible = False
        '
        'ColHl
        '
        Me.ColHl.DataPropertyName = "hl"
        Me.ColHl.HeaderText = "汇率"
        Me.ColHl.Name = "ColHl"
        Me.ColHl.Visible = False
        '
        'ColJfje
        '
        Me.ColJfje.DataPropertyName = "jfje"
        Me.ColJfje.HeaderText = "借方金额"
        Me.ColJfje.MaxInputLength = 18
        Me.ColJfje.Name = "ColJfje"
        Me.ColJfje.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColJfje.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColJfje.ToolTipText = "借方金额"
        Me.ColJfje.Width = 125
        '
        'ColDfje
        '
        Me.ColDfje.DataPropertyName = "dfje"
        Me.ColDfje.HeaderText = "贷方金额"
        Me.ColDfje.MaxInputLength = 18
        Me.ColDfje.Name = "ColDfje"
        Me.ColDfje.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColDfje.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColDfje.ToolTipText = "贷方金额"
        Me.ColDfje.Width = 125
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtnExit)
        Me.Panel2.Controls.Add(Me.BtnTop)
        Me.Panel2.Controls.Add(Me.BtnPrint)
        Me.Panel2.Controls.Add(Me.BtnHelp)
        Me.Panel2.Controls.Add(Me.BtnNext)
        Me.Panel2.Controls.Add(Me.BtnBottom)
        Me.Panel2.Controls.Add(Me.BtnPrevious)
        Me.Panel2.Controls.Add(Me.LblJzr)
        Me.Panel2.Controls.Add(Me.LblShr)
        Me.Panel2.Controls.Add(Me.LblSrr)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 398)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(786, 99)
        Me.Panel2.TabIndex = 4
        '
        'BtnExit
        '
        Me.BtnExit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnExit.Location = New System.Drawing.Point(676, 64)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 23)
        Me.BtnExit.TabIndex = 45
        Me.BtnExit.Text = "退出(&X)"
        '
        'BtnTop
        '
        Me.BtnTop.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnTop.Location = New System.Drawing.Point(36, 64)
        Me.BtnTop.Name = "BtnTop"
        Me.BtnTop.Size = New System.Drawing.Size(75, 23)
        Me.BtnTop.TabIndex = 39
        Me.BtnTop.Text = "首张(&S)"
        '
        'BtnPrint
        '
        Me.BtnPrint.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnPrint.Location = New System.Drawing.Point(516, 64)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrint.TabIndex = 43
        Me.BtnPrint.Text = "打印(&P)"
        '
        'BtnHelp
        '
        Me.BtnHelp.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnHelp.Location = New System.Drawing.Point(596, 64)
        Me.BtnHelp.Name = "BtnHelp"
        Me.BtnHelp.Size = New System.Drawing.Size(75, 23)
        Me.BtnHelp.TabIndex = 44
        Me.BtnHelp.Text = "帮助(&H)"
        '
        'BtnNext
        '
        Me.BtnNext.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnNext.Location = New System.Drawing.Point(196, 64)
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(75, 23)
        Me.BtnNext.TabIndex = 41
        Me.BtnNext.Text = "下张(&Q)"
        '
        'BtnBottom
        '
        Me.BtnBottom.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnBottom.Location = New System.Drawing.Point(276, 64)
        Me.BtnBottom.Name = "BtnBottom"
        Me.BtnBottom.Size = New System.Drawing.Size(75, 23)
        Me.BtnBottom.TabIndex = 42
        Me.BtnBottom.Text = "末张(&Y)"
        '
        'BtnPrevious
        '
        Me.BtnPrevious.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnPrevious.Location = New System.Drawing.Point(116, 64)
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrevious.TabIndex = 40
        Me.BtnPrevious.Text = "上张(&C)"
        '
        'LblJzr
        '
        Me.LblJzr.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblJzr.AutoSize = True
        Me.LblJzr.Location = New System.Drawing.Point(621, 43)
        Me.LblJzr.Name = "LblJzr"
        Me.LblJzr.Size = New System.Drawing.Size(41, 12)
        Me.LblJzr.TabIndex = 38
        Me.LblJzr.Text = "记账："
        '
        'LblShr
        '
        Me.LblShr.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblShr.AutoSize = True
        Me.LblShr.Location = New System.Drawing.Point(373, 43)
        Me.LblShr.Name = "LblShr"
        Me.LblShr.Size = New System.Drawing.Size(41, 12)
        Me.LblShr.TabIndex = 37
        Me.LblShr.Text = "审核："
        '
        'LblSrr
        '
        Me.LblSrr.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblSrr.AutoSize = True
        Me.LblSrr.Location = New System.Drawing.Point(133, 43)
        Me.LblSrr.Name = "LblSrr"
        Me.LblSrr.Size = New System.Drawing.Size(41, 12)
        Me.LblSrr.TabIndex = 36
        Me.LblSrr.Text = "输入："
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.LblJe)
        Me.Panel4.Controls.Add(Me.LblSl)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(786, 35)
        Me.Panel4.TabIndex = 0
        '
        'LblJe
        '
        Me.LblJe.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblJe.AutoSize = True
        Me.LblJe.Location = New System.Drawing.Point(629, 12)
        Me.LblJe.Name = "LblJe"
        Me.LblJe.Size = New System.Drawing.Size(65, 12)
        Me.LblJe.TabIndex = 13
        Me.LblJe.Text = "金额合计："
        '
        'LblSl
        '
        Me.LblSl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSl.AutoSize = True
        Me.LblSl.Location = New System.Drawing.Point(479, 12)
        Me.LblSl.Name = "LblSl"
        Me.LblSl.Size = New System.Drawing.Size(65, 12)
        Me.LblSl.TabIndex = 12
        Me.LblSl.Text = "数量合计："
        '
        'FrmGlPzCxz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.rcDataGridView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStripPanel1)
        Me.Name = "FrmGlPzCxz"
        Me.Text = "记账凭证查询"
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
    Public WithEvents LblPzrq As System.Windows.Forms.Label
    Public WithEvents DtpPzrq As System.Windows.Forms.DateTimePicker
    Public WithEvents TxtDjh As System.Windows.Forms.TextBox
    Public WithEvents LblDjh As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents LblCkd As System.Windows.Forms.Label
    Friend WithEvents rcDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents rcBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Public WithEvents LblJzr As System.Windows.Forms.Label
    Public WithEvents LblShr As System.Windows.Forms.Label
    Public WithEvents LblSrr As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents MnuiTop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiPrevious As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiNext As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiBottom As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Mnui11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuiPageSetup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiPrintView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents BtnTop As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents BtnHelp As System.Windows.Forms.Button
    Friend WithEvents BtnNext As System.Windows.Forms.Button
    Friend WithEvents BtnBottom As System.Windows.Forms.Button
    Friend WithEvents BtnPrevious As System.Windows.Forms.Button
    Public WithEvents LblJe As System.Windows.Forms.Label
    Public WithEvents LblSl As System.Windows.Forms.Label
    Friend WithEvents TxtFjzs As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LblBdelete As System.Windows.Forms.Label
    Friend WithEvents ColZy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKmdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKmmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBmdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBmmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKhdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKhmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColYspz As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJsr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColWldqr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColXmdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColXmmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColWb As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColHl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJfje As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDfje As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
