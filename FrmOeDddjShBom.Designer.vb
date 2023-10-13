<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeDddjShBom
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
        Me.Tss3 = New System.Windows.Forms.ToolStripSeparator
        Me.MnuiSave = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiInsRow = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiDelRow = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem11 = New System.Windows.Forms.ToolStripSeparator
        Me.MnuiExit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiHelp = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip
        Me.BtnSave = New System.Windows.Forms.ToolStripButton
        Me.BtnInsRow = New System.Windows.Forms.ToolStripButton
        Me.BtnDelRow = New System.Windows.Forms.ToolStripButton
        Me.Tss2 = New System.Windows.Forms.ToolStripSeparator
        Me.BtnExit = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TxtParentDw = New System.Windows.Forms.TextBox
        Me.NudGlcb = New System.Windows.Forms.NumericUpDown
        Me.LblGlcb = New System.Windows.Forms.Label
        Me.NudRgcb = New System.Windows.Forms.NumericUpDown
        Me.NudClcb = New System.Windows.Forms.NumericUpDown
        Me.NudBzcb = New System.Windows.Forms.NumericUpDown
        Me.LblRgcb = New System.Windows.Forms.Label
        Me.LblClcb = New System.Windows.Forms.Label
        Me.LblBzcb = New System.Windows.Forms.Label
        Me.LblDw = New System.Windows.Forms.Label
        Me.TxtParentCpmc = New System.Windows.Forms.TextBox
        Me.LblCpmc = New System.Windows.Forms.Label
        Me.TxtParentCpdm = New System.Windows.Forms.TextBox
        Me.LblCpdm = New System.Windows.Forms.Label
        Me.rcDataGridView = New System.Windows.Forms.DataGridView
        Me.rcBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ColChildCpdm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColChildCpmc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColChildDw = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColSl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColDj = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColJe = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColBomMemo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStripPanel1.SuspendLayout()
        Me.MnuMain.SuspendLayout()
        Me.ToolStripMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.NudGlcb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudRgcb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudClcb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudBzcb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripPanel1
        '
        Me.ToolStripPanel1.Controls.Add(Me.ToolStripMain)
        Me.ToolStripPanel1.Controls.Add(Me.MnuMain)
        Me.ToolStripPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ToolStripPanel1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripPanel1.Name = "ToolStripPanel1"
        Me.ToolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.ToolStripPanel1.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ToolStripPanel1.Size = New System.Drawing.Size(786, 64)
        '
        'MnuMain
        '
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiFile, Me.MnuiHelp})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(786, 25)
        Me.MnuMain.TabIndex = 7
        '
        'MnuiFile
        '
        Me.MnuiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Tss3, Me.MnuiSave, Me.MnuiInsRow, Me.MnuiDelRow, Me.MenuItem11, Me.MnuiExit})
        Me.MnuiFile.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiFile.Name = "MnuiFile"
        Me.MnuiFile.Size = New System.Drawing.Size(58, 21)
        Me.MnuiFile.Text = "文件(&F)"
        '
        'Tss3
        '
        Me.Tss3.Name = "Tss3"
        Me.Tss3.Size = New System.Drawing.Size(113, 6)
        '
        'MnuiSave
        '
        Me.MnuiSave.Name = "MnuiSave"
        Me.MnuiSave.Size = New System.Drawing.Size(116, 22)
        Me.MnuiSave.Text = "保存(&S)"
        '
        'MnuiInsRow
        '
        Me.MnuiInsRow.Name = "MnuiInsRow"
        Me.MnuiInsRow.Size = New System.Drawing.Size(116, 22)
        Me.MnuiInsRow.Text = "插入行"
        '
        'MnuiDelRow
        '
        Me.MnuiDelRow.Name = "MnuiDelRow"
        Me.MnuiDelRow.Size = New System.Drawing.Size(116, 22)
        Me.MnuiDelRow.Text = "删除行"
        '
        'MenuItem11
        '
        Me.MenuItem11.Name = "MenuItem11"
        Me.MenuItem11.Size = New System.Drawing.Size(113, 6)
        '
        'MnuiExit
        '
        Me.MnuiExit.Name = "MnuiExit"
        Me.MnuiExit.Size = New System.Drawing.Size(116, 22)
        Me.MnuiExit.Text = "退出(&X)"
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
        'ToolStripMain
        '
        Me.ToolStripMain.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnSave, Me.BtnInsRow, Me.BtnDelRow, Me.Tss2, Me.BtnExit})
        Me.ToolStripMain.Location = New System.Drawing.Point(3, 25)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(314, 39)
        Me.ToolStripMain.TabIndex = 8
        '
        'BtnSave
        '
        Me.BtnSave.Image = Global.rc3.My.Resources.Resources.ImgSave
        Me.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(68, 36)
        Me.BtnSave.Text = "保存"
        '
        'BtnInsRow
        '
        Me.BtnInsRow.Image = Global.rc3.My.Resources.Resources.ImgEdit
        Me.BtnInsRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnInsRow.Name = "BtnInsRow"
        Me.BtnInsRow.Size = New System.Drawing.Size(80, 36)
        Me.BtnInsRow.Text = "插入行"
        '
        'BtnDelRow
        '
        Me.BtnDelRow.Image = Global.rc3.My.Resources.Resources.ImgDelRow
        Me.BtnDelRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDelRow.Name = "BtnDelRow"
        Me.BtnDelRow.Size = New System.Drawing.Size(80, 36)
        Me.BtnDelRow.Text = "删除行"
        '
        'Tss2
        '
        Me.Tss2.Name = "Tss2"
        Me.Tss2.Size = New System.Drawing.Size(6, 39)
        '
        'BtnExit
        '
        Me.BtnExit.Image = Global.rc3.My.Resources.Resources.ImgExit
        Me.BtnExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(68, 36)
        Me.BtnExit.Text = "关闭"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FloralWhite
        Me.Panel1.Controls.Add(Me.TxtParentDw)
        Me.Panel1.Controls.Add(Me.NudGlcb)
        Me.Panel1.Controls.Add(Me.LblGlcb)
        Me.Panel1.Controls.Add(Me.NudRgcb)
        Me.Panel1.Controls.Add(Me.NudClcb)
        Me.Panel1.Controls.Add(Me.NudBzcb)
        Me.Panel1.Controls.Add(Me.LblRgcb)
        Me.Panel1.Controls.Add(Me.LblClcb)
        Me.Panel1.Controls.Add(Me.LblBzcb)
        Me.Panel1.Controls.Add(Me.LblDw)
        Me.Panel1.Controls.Add(Me.TxtParentCpmc)
        Me.Panel1.Controls.Add(Me.LblCpmc)
        Me.Panel1.Controls.Add(Me.TxtParentCpdm)
        Me.Panel1.Controls.Add(Me.LblCpdm)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 64)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(786, 86)
        Me.Panel1.TabIndex = 8
        '
        'TxtParentDw
        '
        Me.TxtParentDw.Enabled = False
        Me.TxtParentDw.Location = New System.Drawing.Point(678, 19)
        Me.TxtParentDw.MaxLength = 8
        Me.TxtParentDw.Name = "TxtParentDw"
        Me.TxtParentDw.Size = New System.Drawing.Size(96, 21)
        Me.TxtParentDw.TabIndex = 129
        '
        'NudGlcb
        '
        Me.NudGlcb.DecimalPlaces = 2
        Me.NudGlcb.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NudGlcb.Location = New System.Drawing.Point(607, 49)
        Me.NudGlcb.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 131072})
        Me.NudGlcb.Name = "NudGlcb"
        Me.NudGlcb.Size = New System.Drawing.Size(86, 21)
        Me.NudGlcb.TabIndex = 140
        Me.NudGlcb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblGlcb
        '
        Me.LblGlcb.AutoSize = True
        Me.LblGlcb.Location = New System.Drawing.Point(545, 53)
        Me.LblGlcb.Name = "LblGlcb"
        Me.LblGlcb.Size = New System.Drawing.Size(65, 12)
        Me.LblGlcb.TabIndex = 139
        Me.LblGlcb.Text = "管理成本："
        '
        'NudRgcb
        '
        Me.NudRgcb.DecimalPlaces = 2
        Me.NudRgcb.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NudRgcb.Location = New System.Drawing.Point(451, 49)
        Me.NudRgcb.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 131072})
        Me.NudRgcb.Name = "NudRgcb"
        Me.NudRgcb.Size = New System.Drawing.Size(86, 21)
        Me.NudRgcb.TabIndex = 138
        Me.NudRgcb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NudClcb
        '
        Me.NudClcb.DecimalPlaces = 2
        Me.NudClcb.Enabled = False
        Me.NudClcb.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NudClcb.Location = New System.Drawing.Point(297, 49)
        Me.NudClcb.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 131072})
        Me.NudClcb.Name = "NudClcb"
        Me.NudClcb.Size = New System.Drawing.Size(86, 21)
        Me.NudClcb.TabIndex = 137
        Me.NudClcb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NudBzcb
        '
        Me.NudBzcb.DecimalPlaces = 2
        Me.NudBzcb.Enabled = False
        Me.NudBzcb.Location = New System.Drawing.Point(130, 49)
        Me.NudBzcb.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 131072})
        Me.NudBzcb.Name = "NudBzcb"
        Me.NudBzcb.Size = New System.Drawing.Size(87, 21)
        Me.NudBzcb.TabIndex = 136
        Me.NudBzcb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblRgcb
        '
        Me.LblRgcb.AutoSize = True
        Me.LblRgcb.Location = New System.Drawing.Point(389, 53)
        Me.LblRgcb.Name = "LblRgcb"
        Me.LblRgcb.Size = New System.Drawing.Size(65, 12)
        Me.LblRgcb.TabIndex = 134
        Me.LblRgcb.Text = "人工成本："
        '
        'LblClcb
        '
        Me.LblClcb.AutoSize = True
        Me.LblClcb.Location = New System.Drawing.Point(226, 53)
        Me.LblClcb.Name = "LblClcb"
        Me.LblClcb.Size = New System.Drawing.Size(65, 12)
        Me.LblClcb.TabIndex = 132
        Me.LblClcb.Text = "材料成本："
        '
        'LblBzcb
        '
        Me.LblBzcb.AutoSize = True
        Me.LblBzcb.Location = New System.Drawing.Point(35, 53)
        Me.LblBzcb.Name = "LblBzcb"
        Me.LblBzcb.Size = New System.Drawing.Size(89, 12)
        Me.LblBzcb.TabIndex = 130
        Me.LblBzcb.Text = "单位标准成本："
        '
        'LblDw
        '
        Me.LblDw.AutoSize = True
        Me.LblDw.Location = New System.Drawing.Point(589, 23)
        Me.LblDw.Name = "LblDw"
        Me.LblDw.Size = New System.Drawing.Size(89, 12)
        Me.LblDw.TabIndex = 128
        Me.LblDw.Text = "基础计量单位："
        '
        'TxtParentCpmc
        '
        Me.TxtParentCpmc.Enabled = False
        Me.TxtParentCpmc.Location = New System.Drawing.Point(320, 19)
        Me.TxtParentCpmc.MaxLength = 15
        Me.TxtParentCpmc.Name = "TxtParentCpmc"
        Me.TxtParentCpmc.Size = New System.Drawing.Size(263, 21)
        Me.TxtParentCpmc.TabIndex = 123
        '
        'LblCpmc
        '
        Me.LblCpmc.AutoSize = True
        Me.LblCpmc.Location = New System.Drawing.Point(226, 22)
        Me.LblCpmc.Name = "LblCpmc"
        Me.LblCpmc.Size = New System.Drawing.Size(89, 12)
        Me.LblCpmc.TabIndex = 122
        Me.LblCpmc.Text = "父项物料名称："
        '
        'TxtParentCpdm
        '
        Me.TxtParentCpdm.Location = New System.Drawing.Point(130, 19)
        Me.TxtParentCpdm.MaxLength = 15
        Me.TxtParentCpdm.Name = "TxtParentCpdm"
        Me.TxtParentCpdm.Size = New System.Drawing.Size(87, 21)
        Me.TxtParentCpdm.TabIndex = 121
        '
        'LblCpdm
        '
        Me.LblCpdm.AutoSize = True
        Me.LblCpdm.Location = New System.Drawing.Point(35, 22)
        Me.LblCpdm.Name = "LblCpdm"
        Me.LblCpdm.Size = New System.Drawing.Size(89, 12)
        Me.LblCpdm.TabIndex = 120
        Me.LblCpdm.Text = "父项物料编码："
        '
        'rcDataGridView
        '
        Me.rcDataGridView.ColumnHeadersHeight = 30
        Me.rcDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColChildCpdm, Me.ColChildCpmc, Me.ColChildDw, Me.ColSl, Me.ColDj, Me.ColJe, Me.ColBomMemo})
        Me.rcDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rcDataGridView.Location = New System.Drawing.Point(0, 150)
        Me.rcDataGridView.Name = "rcDataGridView"
        Me.rcDataGridView.RowTemplate.Height = 23
        Me.rcDataGridView.Size = New System.Drawing.Size(786, 327)
        Me.rcDataGridView.TabIndex = 10
        '
        'ColChildCpdm
        '
        Me.ColChildCpdm.DataPropertyName = "childcpdm"
        Me.ColChildCpdm.HeaderText = "子项物料编码"
        Me.ColChildCpdm.Name = "ColChildCpdm"
        Me.ColChildCpdm.Width = 85
        '
        'ColChildCpmc
        '
        Me.ColChildCpmc.DataPropertyName = "childcpmc"
        Me.ColChildCpmc.HeaderText = "子项物料名称"
        Me.ColChildCpmc.Name = "ColChildCpmc"
        Me.ColChildCpmc.ReadOnly = True
        Me.ColChildCpmc.Width = 150
        '
        'ColChildDw
        '
        Me.ColChildDw.DataPropertyName = "childdw"
        Me.ColChildDw.HeaderText = "单位"
        Me.ColChildDw.Name = "ColChildDw"
        Me.ColChildDw.ReadOnly = True
        Me.ColChildDw.Width = 45
        '
        'ColSl
        '
        Me.ColSl.DataPropertyName = "sl"
        Me.ColSl.HeaderText = "数量"
        Me.ColSl.Name = "ColSl"
        Me.ColSl.Width = 90
        '
        'ColDj
        '
        Me.ColDj.DataPropertyName = "dj"
        Me.ColDj.HeaderText = "最新采购单价"
        Me.ColDj.Name = "ColDj"
        '
        'ColJe
        '
        Me.ColJe.DataPropertyName = "je"
        Me.ColJe.HeaderText = "金额"
        Me.ColJe.Name = "ColJe"
        '
        'ColBomMemo
        '
        Me.ColBomMemo.DataPropertyName = "bommemo"
        Me.ColBomMemo.HeaderText = "备注"
        Me.ColBomMemo.Name = "ColBomMemo"
        Me.ColBomMemo.Width = 120
        '
        'FrmOeDddjShBom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(786, 477)
        Me.Controls.Add(Me.rcDataGridView)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStripPanel1)
        Me.Name = "FrmOeDddjShBom"
        Me.Text = "物料清单维护"
        Me.ToolStripPanel1.ResumeLayout(False)
        Me.ToolStripPanel1.PerformLayout()
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.NudGlcb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudRgcb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudClcb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudBzcb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripPanel1 As System.Windows.Forms.ToolStripPanel
    Friend WithEvents MnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuiFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tss3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuiSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiInsRow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuiHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnInsRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnDelRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tss2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rcDataGridView As System.Windows.Forms.DataGridView
    Public WithEvents TxtParentCpmc As System.Windows.Forms.TextBox
    Public WithEvents LblCpmc As System.Windows.Forms.Label
    Public WithEvents TxtParentCpdm As System.Windows.Forms.TextBox
    Public WithEvents LblCpdm As System.Windows.Forms.Label
    Friend WithEvents LblDw As System.Windows.Forms.Label
    Friend WithEvents TxtParentDw As System.Windows.Forms.TextBox
    Friend WithEvents rcBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MnuiDelRow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LblRgcb As System.Windows.Forms.Label
    Friend WithEvents LblClcb As System.Windows.Forms.Label
    Public WithEvents LblBzcb As System.Windows.Forms.Label
    Friend WithEvents NudGlcb As System.Windows.Forms.NumericUpDown
    Friend WithEvents LblGlcb As System.Windows.Forms.Label
    Friend WithEvents NudRgcb As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudClcb As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudBzcb As System.Windows.Forms.NumericUpDown
    Public WithEvents MnuiExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ColChildCpdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColChildCpmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColChildDw As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBomMemo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
