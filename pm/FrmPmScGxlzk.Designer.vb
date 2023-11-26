<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPmScGxlzk
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblDd = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.BtnSelectAll = New System.Windows.Forms.Button
        Me.BtnImp = New System.Windows.Forms.Button
        Me.LblMsg = New System.Windows.Forms.Label
        Me.BtnExit = New System.Windows.Forms.Button
        Me.BtnHelp = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.rcDataGridView = New System.Windows.Forms.DataGridView
        Me.rcBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ColXz = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ColDjh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColXh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColQdrq = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColKhdm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColKhmc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColHth = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCpdm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCpmc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColDw = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColSl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColKcsl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColKhjhrq = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCurXh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCurGxdm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCurGxmc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCurBmdm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCurBmmc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColLastXh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColLastGxdm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColLastGxmc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColLastBmdm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColLastBmmc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStripPanel1.SuspendLayout()
        Me.MnuMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.MnuMain.TabIndex = 1
        '
        'MnuiFile
        '
        Me.MnuiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiPageSetup, Me.MnuiPrintView, Me.MnuiPrint, Me.Mnui13, Me.MnuiExit})
        Me.MnuiFile.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiFile.Name = "MnuiFile"
        Me.MnuiFile.Size = New System.Drawing.Size(58, 21)
        Me.MnuiFile.Text = "文件(&F)"
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FloralWhite
        Me.Panel1.Controls.Add(Me.LblDd)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(786, 48)
        Me.Panel1.TabIndex = 0
        '
        'LblDd
        '
        Me.LblDd.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblDd.AutoSize = True
        Me.LblDd.Font = New System.Drawing.Font("华文行楷", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblDd.ForeColor = System.Drawing.Color.SteelBlue
        Me.LblDd.Location = New System.Drawing.Point(300, 9)
        Me.LblDd.Name = "LblDd"
        Me.LblDd.Size = New System.Drawing.Size(187, 25)
        Me.LblDd.TabIndex = 0
        Me.LblDd.Text = "生成工序流转卡"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtnSelectAll)
        Me.Panel2.Controls.Add(Me.BtnImp)
        Me.Panel2.Controls.Add(Me.LblMsg)
        Me.Panel2.Controls.Add(Me.BtnExit)
        Me.Panel2.Controls.Add(Me.BtnHelp)
        Me.Panel2.Controls.Add(Me.BtnSave)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 441)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(786, 56)
        Me.Panel2.TabIndex = 2
        '
        'BtnSelectAll
        '
        Me.BtnSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSelectAll.Location = New System.Drawing.Point(473, 15)
        Me.BtnSelectAll.Name = "BtnSelectAll"
        Me.BtnSelectAll.Size = New System.Drawing.Size(75, 23)
        Me.BtnSelectAll.TabIndex = 23
        Me.BtnSelectAll.TabStop = False
        Me.BtnSelectAll.Text = "全选(&A)"
        '
        'BtnImp
        '
        Me.BtnImp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImp.Location = New System.Drawing.Point(393, 15)
        Me.BtnImp.Name = "BtnImp"
        Me.BtnImp.Size = New System.Drawing.Size(80, 23)
        Me.BtnImp.TabIndex = 22
        Me.BtnImp.Text = "读取数据(&I)"
        '
        'LblMsg
        '
        Me.LblMsg.ForeColor = System.Drawing.Color.SteelBlue
        Me.LblMsg.Location = New System.Drawing.Point(12, 20)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(319, 27)
        Me.LblMsg.TabIndex = 21
        Me.LblMsg.Text = "核对订单的开始工序，如不正确，到物料清单中修改正确。仓库有库存的检查库存能否安排发货。"
        '
        'BtnExit
        '
        Me.BtnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExit.Location = New System.Drawing.Point(698, 15)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 23)
        Me.BtnExit.TabIndex = 20
        Me.BtnExit.Text = "退出(&X)"
        '
        'BtnHelp
        '
        Me.BtnHelp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnHelp.Location = New System.Drawing.Point(623, 15)
        Me.BtnHelp.Name = "BtnHelp"
        Me.BtnHelp.Size = New System.Drawing.Size(75, 23)
        Me.BtnHelp.TabIndex = 19
        Me.BtnHelp.Text = "帮助(&H)"
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Location = New System.Drawing.Point(548, 15)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 16
        Me.BtnSave.Text = "保存(&S)"
        '
        'rcDataGridView
        '
        Me.rcDataGridView.AllowUserToAddRows = False
        Me.rcDataGridView.ColumnHeadersHeight = 30
        Me.rcDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColXz, Me.ColDjh, Me.ColXh, Me.ColQdrq, Me.ColKhdm, Me.ColKhmc, Me.ColHth, Me.ColCpdm, Me.ColCpmc, Me.ColDw, Me.ColSl, Me.ColKcsl, Me.ColKhjhrq, Me.ColCurXh, Me.ColCurGxdm, Me.ColCurGxmc, Me.ColCurBmdm, Me.ColCurBmmc, Me.ColLastXh, Me.ColLastGxdm, Me.ColLastGxmc, Me.ColLastBmdm, Me.ColLastBmmc})
        Me.rcDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rcDataGridView.Location = New System.Drawing.Point(0, 73)
        Me.rcDataGridView.Name = "rcDataGridView"
        Me.rcDataGridView.RowTemplate.Height = 23
        Me.rcDataGridView.Size = New System.Drawing.Size(786, 368)
        Me.rcDataGridView.TabIndex = 1
        '
        'ColXz
        '
        Me.ColXz.DataPropertyName = "xz"
        Me.ColXz.HeaderText = "选择"
        Me.ColXz.Name = "ColXz"
        Me.ColXz.Width = 60
        '
        'ColDjh
        '
        Me.ColDjh.DataPropertyName = "djh"
        Me.ColDjh.HeaderText = "订单单据号"
        Me.ColDjh.Name = "ColDjh"
        Me.ColDjh.ReadOnly = True
        '
        'ColXh
        '
        Me.ColXh.DataPropertyName = "xh"
        Me.ColXh.HeaderText = "订单行号"
        Me.ColXh.Name = "ColXh"
        Me.ColXh.ReadOnly = True
        Me.ColXh.Width = 45
        '
        'ColQdrq
        '
        Me.ColQdrq.DataPropertyName = "qdrq"
        Me.ColQdrq.HeaderText = "签单日期"
        Me.ColQdrq.Name = "ColQdrq"
        Me.ColQdrq.ReadOnly = True
        Me.ColQdrq.Width = 80
        '
        'ColKhdm
        '
        Me.ColKhdm.DataPropertyName = "khdm"
        Me.ColKhdm.HeaderText = "客户编码"
        Me.ColKhdm.Name = "ColKhdm"
        Me.ColKhdm.ReadOnly = True
        Me.ColKhdm.Width = 80
        '
        'ColKhmc
        '
        Me.ColKhmc.DataPropertyName = "khmc"
        Me.ColKhmc.HeaderText = "客户名称"
        Me.ColKhmc.Name = "ColKhmc"
        Me.ColKhmc.ReadOnly = True
        Me.ColKhmc.Width = 135
        '
        'ColHth
        '
        Me.ColHth.DataPropertyName = "hth"
        Me.ColHth.HeaderText = "合同编码"
        Me.ColHth.Name = "ColHth"
        Me.ColHth.ReadOnly = True
        Me.ColHth.Width = 90
        '
        'ColCpdm
        '
        Me.ColCpdm.DataPropertyName = "cpdm"
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
        'ColKcsl
        '
        Me.ColKcsl.DataPropertyName = "kcsl"
        Me.ColKcsl.HeaderText = "库存数量"
        Me.ColKcsl.Name = "ColKcsl"
        Me.ColKcsl.ReadOnly = True
        Me.ColKcsl.Width = 80
        '
        'ColKhjhrq
        '
        Me.ColKhjhrq.DataPropertyName = "khjhrq"
        Me.ColKhjhrq.HeaderText = "客户交期"
        Me.ColKhjhrq.MaxInputLength = 10
        Me.ColKhjhrq.Name = "ColKhjhrq"
        Me.ColKhjhrq.ReadOnly = True
        Me.ColKhjhrq.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColKhjhrq.Width = 80
        '
        'ColCurXh
        '
        Me.ColCurXh.DataPropertyName = "curxh"
        Me.ColCurXh.HeaderText = "首道工序序号"
        Me.ColCurXh.Name = "ColCurXh"
        Me.ColCurXh.ReadOnly = True
        Me.ColCurXh.Width = 60
        '
        'ColCurGxdm
        '
        Me.ColCurGxdm.DataPropertyName = "curgxdm"
        Me.ColCurGxdm.HeaderText = "首道工序编码"
        Me.ColCurGxdm.Name = "ColCurGxdm"
        Me.ColCurGxdm.ReadOnly = True
        Me.ColCurGxdm.Width = 60
        '
        'ColCurGxmc
        '
        Me.ColCurGxmc.DataPropertyName = "curgxmc"
        Me.ColCurGxmc.HeaderText = "首道工序名称"
        Me.ColCurGxmc.Name = "ColCurGxmc"
        Me.ColCurGxmc.ReadOnly = True
        '
        'ColCurBmdm
        '
        Me.ColCurBmdm.DataPropertyName = "curbmdm"
        Me.ColCurBmdm.HeaderText = "首道部门编码"
        Me.ColCurBmdm.Name = "ColCurBmdm"
        Me.ColCurBmdm.ReadOnly = True
        Me.ColCurBmdm.Width = 60
        '
        'ColCurBmmc
        '
        Me.ColCurBmmc.DataPropertyName = "curbmmc"
        Me.ColCurBmmc.HeaderText = "首道部门名称"
        Me.ColCurBmmc.Name = "ColCurBmmc"
        Me.ColCurBmmc.ReadOnly = True
        '
        'ColLastXh
        '
        Me.ColLastXh.DataPropertyName = "lastxh"
        Me.ColLastXh.HeaderText = "末道工序序号"
        Me.ColLastXh.Name = "ColLastXh"
        Me.ColLastXh.ReadOnly = True
        Me.ColLastXh.Width = 60
        '
        'ColLastGxdm
        '
        Me.ColLastGxdm.DataPropertyName = "lastgxdm"
        Me.ColLastGxdm.HeaderText = "末道工序编码"
        Me.ColLastGxdm.Name = "ColLastGxdm"
        Me.ColLastGxdm.ReadOnly = True
        Me.ColLastGxdm.Width = 60
        '
        'ColLastGxmc
        '
        Me.ColLastGxmc.DataPropertyName = "lastgxmc"
        Me.ColLastGxmc.HeaderText = "末道工序名称"
        Me.ColLastGxmc.Name = "ColLastGxmc"
        Me.ColLastGxmc.ReadOnly = True
        '
        'ColLastBmdm
        '
        Me.ColLastBmdm.DataPropertyName = "lastbmdm"
        Me.ColLastBmdm.HeaderText = "末道部门编码"
        Me.ColLastBmdm.Name = "ColLastBmdm"
        Me.ColLastBmdm.ReadOnly = True
        Me.ColLastBmdm.Width = 60
        '
        'ColLastBmmc
        '
        Me.ColLastBmmc.DataPropertyName = "lastbmmc"
        Me.ColLastBmmc.HeaderText = "末道部门名称"
        Me.ColLastBmmc.Name = "ColLastBmmc"
        Me.ColLastBmmc.ReadOnly = True
        '
        'FrmPmScGxlzk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.rcDataGridView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStripPanel1)
        Me.Name = "FrmPmScGxlzk"
        Me.Text = "生成工序流转卡"
        Me.ToolStripPanel1.ResumeLayout(False)
        Me.ToolStripPanel1.PerformLayout()
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripPanel1 As System.Windows.Forms.ToolStripPanel
    Friend WithEvents MnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuiFile As System.Windows.Forms.ToolStripMenuItem
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
    Friend WithEvents LblDd As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents BtnHelp As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents rcDataGridView As System.Windows.Forms.DataGridView
    Public WithEvents LblMsg As System.Windows.Forms.Label
    Friend WithEvents rcBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BtnImp As System.Windows.Forms.Button
    Friend WithEvents BtnSelectAll As System.Windows.Forms.Button
    Friend WithEvents ColXz As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColDjh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColXh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColQdrq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKhdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKhmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColHth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCpdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCpmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDw As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKcsl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKhjhrq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCurXh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCurGxdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCurGxmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCurBmdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCurBmmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLastXh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLastGxdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLastGxmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLastBmdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLastBmmc As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
