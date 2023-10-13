<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCpGroup
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
        Me.MnuiPreview = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiPrint = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiExport = New System.Windows.Forms.ToolStripMenuItem
        Me.Tss3 = New System.Windows.Forms.ToolStripSeparator
        Me.MnuiNew = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiSave = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem11 = New System.Windows.Forms.ToolStripSeparator
        Me.MnuiExit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiHelp = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip
        Me.BtnPageSetup = New System.Windows.Forms.ToolStripButton
        Me.BtnPrint = New System.Windows.Forms.ToolStripButton
        Me.BtnPreview = New System.Windows.Forms.ToolStripButton
        Me.BtnExport = New System.Windows.Forms.ToolStripButton
        Me.Tss1 = New System.Windows.Forms.ToolStripSeparator
        Me.BtnNew = New System.Windows.Forms.ToolStripButton
        Me.BtnSave = New System.Windows.Forms.ToolStripButton
        Me.BtnDelete = New System.Windows.Forms.ToolStripButton
        Me.Tss2 = New System.Windows.Forms.ToolStripSeparator
        Me.BtnExit = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TxtGuanLiYuan = New System.Windows.Forms.TextBox
        Me.LblGuanLiYuan = New System.Windows.Forms.Label
        Me.TxtGroupSm = New System.Windows.Forms.TextBox
        Me.LblGroupSm = New System.Windows.Forms.Label
        Me.TxtGroupName = New System.Windows.Forms.TextBox
        Me.LblGroupName = New System.Windows.Forms.Label
        Me.TxtGroupID = New System.Windows.Forms.TextBox
        Me.LblGroupID = New System.Windows.Forms.Label
        Me.rcBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.rcBindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.ListBoxYuxuan = New System.Windows.Forms.ListBox
        Me.ListBoxYixuan = New System.Windows.Forms.ListBox
        Me.BtnSelectAll = New System.Windows.Forms.Button
        Me.BtnSelectOne = New System.Windows.Forms.Button
        Me.BtnUnSelectOne = New System.Windows.Forms.Button
        Me.BtnUnSelectAll = New System.Windows.Forms.Button
        Me.LblYuxuan = New System.Windows.Forms.Label
        Me.LblYixuan = New System.Windows.Forms.Label
        Me.ToolStripPanel1.SuspendLayout()
        Me.MnuMain.SuspendLayout()
        Me.ToolStripMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.rcBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcBindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripPanel1
        '
        Me.ToolStripPanel1.Controls.Add(Me.MnuMain)
        Me.ToolStripPanel1.Controls.Add(Me.ToolStripMain)
        Me.ToolStripPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ToolStripPanel1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripPanel1.Name = "ToolStripPanel1"
        Me.ToolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.ToolStripPanel1.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ToolStripPanel1.Size = New System.Drawing.Size(984, 64)
        '
        'MnuMain
        '
        Me.MnuMain.Dock = System.Windows.Forms.DockStyle.None
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiFile, Me.MnuiHelp})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(984, 25)
        Me.MnuMain.TabIndex = 7
        '
        'MnuiFile
        '
        Me.MnuiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiPageSetup, Me.MnuiPreview, Me.MnuiPrint, Me.MnuiExport, Me.Tss3, Me.MnuiNew, Me.MnuiSave, Me.MnuiDelete, Me.MenuItem11, Me.MnuiExit})
        Me.MnuiFile.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiFile.Name = "MnuiFile"
        Me.MnuiFile.Size = New System.Drawing.Size(58, 21)
        Me.MnuiFile.Text = "文件(&F)"
        '
        'MnuiPageSetup
        '
        Me.MnuiPageSetup.Name = "MnuiPageSetup"
        Me.MnuiPageSetup.Size = New System.Drawing.Size(152, 22)
        Me.MnuiPageSetup.Text = "页面设置(&U)"
        '
        'MnuiPreview
        '
        Me.MnuiPreview.Name = "MnuiPreview"
        Me.MnuiPreview.Size = New System.Drawing.Size(152, 22)
        Me.MnuiPreview.Text = "打印预览(&V)"
        '
        'MnuiPrint
        '
        Me.MnuiPrint.Name = "MnuiPrint"
        Me.MnuiPrint.Size = New System.Drawing.Size(152, 22)
        Me.MnuiPrint.Text = "打印(&P)"
        '
        'MnuiExport
        '
        Me.MnuiExport.Name = "MnuiExport"
        Me.MnuiExport.Size = New System.Drawing.Size(152, 22)
        Me.MnuiExport.Text = "输出"
        '
        'Tss3
        '
        Me.Tss3.Name = "Tss3"
        Me.Tss3.Size = New System.Drawing.Size(149, 6)
        '
        'MnuiNew
        '
        Me.MnuiNew.Name = "MnuiNew"
        Me.MnuiNew.Size = New System.Drawing.Size(152, 22)
        Me.MnuiNew.Text = "新增(&N)"
        '
        'MnuiSave
        '
        Me.MnuiSave.Name = "MnuiSave"
        Me.MnuiSave.Size = New System.Drawing.Size(152, 22)
        Me.MnuiSave.Text = "保存(&S)"
        '
        'MnuiDelete
        '
        Me.MnuiDelete.Name = "MnuiDelete"
        Me.MnuiDelete.Size = New System.Drawing.Size(152, 22)
        Me.MnuiDelete.Text = "删除(&D)"
        '
        'MenuItem11
        '
        Me.MenuItem11.Name = "MenuItem11"
        Me.MenuItem11.Size = New System.Drawing.Size(149, 6)
        '
        'MnuiExit
        '
        Me.MnuiExit.Name = "MnuiExit"
        Me.MnuiExit.Size = New System.Drawing.Size(152, 22)
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
        Me.ToolStripMain.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripMain.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnPageSetup, Me.BtnPrint, Me.BtnPreview, Me.BtnExport, Me.Tss1, Me.BtnNew, Me.BtnSave, Me.BtnDelete, Me.Tss2, Me.BtnExit})
        Me.ToolStripMain.Location = New System.Drawing.Point(3, 25)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(440, 39)
        Me.ToolStripMain.TabIndex = 8
        '
        'BtnPageSetup
        '
        Me.BtnPageSetup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPageSetup.Image = Global.rc3.My.Resources.Resources.ImgPageSetup
        Me.BtnPageSetup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPageSetup.Name = "BtnPageSetup"
        Me.BtnPageSetup.Size = New System.Drawing.Size(36, 36)
        Me.BtnPageSetup.Text = "页面设置"
        '
        'BtnPrint
        '
        Me.BtnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrint.Image = Global.rc3.My.Resources.Resources.ImgPrint
        Me.BtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(36, 36)
        Me.BtnPrint.Text = "打印"
        '
        'BtnPreview
        '
        Me.BtnPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPreview.Image = Global.rc3.My.Resources.Resources.ImgPreview
        Me.BtnPreview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPreview.Name = "BtnPreview"
        Me.BtnPreview.Size = New System.Drawing.Size(36, 36)
        Me.BtnPreview.Text = "预览"
        '
        'BtnExport
        '
        Me.BtnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnExport.Image = Global.rc3.My.Resources.Resources.ImgExport
        Me.BtnExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnExport.Name = "BtnExport"
        Me.BtnExport.Size = New System.Drawing.Size(36, 36)
        Me.BtnExport.Text = "输出"
        '
        'Tss1
        '
        Me.Tss1.Name = "Tss1"
        Me.Tss1.Size = New System.Drawing.Size(6, 39)
        '
        'BtnNew
        '
        Me.BtnNew.Image = Global.rc3.My.Resources.Resources.ImgNew
        Me.BtnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(68, 36)
        Me.BtnNew.Text = "新增"
        '
        'BtnSave
        '
        Me.BtnSave.Image = Global.rc3.My.Resources.Resources.ImgSave
        Me.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(68, 36)
        Me.BtnSave.Text = "保存"
        '
        'BtnDelete
        '
        Me.BtnDelete.Image = Global.rc3.My.Resources.Resources.ImgDelete
        Me.BtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(68, 36)
        Me.BtnDelete.Text = "删除"
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
        Me.Panel1.Controls.Add(Me.TxtGuanLiYuan)
        Me.Panel1.Controls.Add(Me.LblGuanLiYuan)
        Me.Panel1.Controls.Add(Me.TxtGroupSm)
        Me.Panel1.Controls.Add(Me.LblGroupSm)
        Me.Panel1.Controls.Add(Me.TxtGroupName)
        Me.Panel1.Controls.Add(Me.LblGroupName)
        Me.Panel1.Controls.Add(Me.TxtGroupID)
        Me.Panel1.Controls.Add(Me.LblGroupID)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 64)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(984, 62)
        Me.Panel1.TabIndex = 8
        '
        'TxtGuanLiYuan
        '
        Me.TxtGuanLiYuan.Location = New System.Drawing.Point(785, 18)
        Me.TxtGuanLiYuan.MaxLength = 30
        Me.TxtGuanLiYuan.Name = "TxtGuanLiYuan"
        Me.TxtGuanLiYuan.Size = New System.Drawing.Size(96, 21)
        Me.TxtGuanLiYuan.TabIndex = 131
        '
        'LblGuanLiYuan
        '
        Me.LblGuanLiYuan.AutoSize = True
        Me.LblGuanLiYuan.Location = New System.Drawing.Point(700, 22)
        Me.LblGuanLiYuan.Name = "LblGuanLiYuan"
        Me.LblGuanLiYuan.Size = New System.Drawing.Size(77, 12)
        Me.LblGuanLiYuan.TabIndex = 130
        Me.LblGuanLiYuan.Text = "物料管理员："
        '
        'TxtGroupSm
        '
        Me.TxtGroupSm.Location = New System.Drawing.Point(596, 18)
        Me.TxtGroupSm.MaxLength = 12
        Me.TxtGroupSm.Name = "TxtGroupSm"
        Me.TxtGroupSm.Size = New System.Drawing.Size(96, 21)
        Me.TxtGroupSm.TabIndex = 129
        '
        'LblGroupSm
        '
        Me.LblGroupSm.AutoSize = True
        Me.LblGroupSm.Location = New System.Drawing.Point(535, 22)
        Me.LblGroupSm.Name = "LblGroupSm"
        Me.LblGroupSm.Size = New System.Drawing.Size(53, 12)
        Me.LblGroupSm.TabIndex = 128
        Me.LblGroupSm.Text = "记忆码："
        '
        'TxtGroupName
        '
        Me.TxtGroupName.Location = New System.Drawing.Point(300, 18)
        Me.TxtGroupName.MaxLength = 200
        Me.TxtGroupName.Name = "TxtGroupName"
        Me.TxtGroupName.Size = New System.Drawing.Size(227, 21)
        Me.TxtGroupName.TabIndex = 123
        '
        'LblGroupName
        '
        Me.LblGroupName.AutoSize = True
        Me.LblGroupName.Location = New System.Drawing.Point(215, 22)
        Me.LblGroupName.Name = "LblGroupName"
        Me.LblGroupName.Size = New System.Drawing.Size(77, 12)
        Me.LblGroupName.TabIndex = 122
        Me.LblGroupName.Text = "物料组描述："
        '
        'TxtGroupID
        '
        Me.TxtGroupID.Location = New System.Drawing.Point(120, 18)
        Me.TxtGroupID.MaxLength = 12
        Me.TxtGroupID.Name = "TxtGroupID"
        Me.TxtGroupID.Size = New System.Drawing.Size(87, 21)
        Me.TxtGroupID.TabIndex = 121
        '
        'LblGroupID
        '
        Me.LblGroupID.AutoSize = True
        Me.LblGroupID.Location = New System.Drawing.Point(35, 22)
        Me.LblGroupID.Name = "LblGroupID"
        Me.LblGroupID.Size = New System.Drawing.Size(77, 12)
        Me.LblGroupID.TabIndex = 120
        Me.LblGroupID.Text = "物料组编码："
        '
        'ListBoxYuxuan
        '
        Me.ListBoxYuxuan.ItemHeight = 12
        Me.ListBoxYuxuan.Location = New System.Drawing.Point(44, 173)
        Me.ListBoxYuxuan.Name = "ListBoxYuxuan"
        Me.ListBoxYuxuan.Size = New System.Drawing.Size(400, 376)
        Me.ListBoxYuxuan.Sorted = True
        Me.ListBoxYuxuan.TabIndex = 23
        '
        'ListBoxYixuan
        '
        Me.ListBoxYixuan.ItemHeight = 12
        Me.ListBoxYixuan.Location = New System.Drawing.Point(545, 173)
        Me.ListBoxYixuan.Name = "ListBoxYixuan"
        Me.ListBoxYixuan.Size = New System.Drawing.Size(400, 376)
        Me.ListBoxYixuan.Sorted = True
        Me.ListBoxYixuan.TabIndex = 24
        '
        'BtnSelectAll
        '
        Me.BtnSelectAll.Location = New System.Drawing.Point(457, 181)
        Me.BtnSelectAll.Name = "BtnSelectAll"
        Me.BtnSelectAll.Size = New System.Drawing.Size(75, 23)
        Me.BtnSelectAll.TabIndex = 17
        Me.BtnSelectAll.Text = "-->>"
        '
        'BtnSelectOne
        '
        Me.BtnSelectOne.Location = New System.Drawing.Point(457, 221)
        Me.BtnSelectOne.Name = "BtnSelectOne"
        Me.BtnSelectOne.Size = New System.Drawing.Size(75, 23)
        Me.BtnSelectOne.TabIndex = 18
        Me.BtnSelectOne.Text = "-->"
        '
        'BtnUnSelectOne
        '
        Me.BtnUnSelectOne.Location = New System.Drawing.Point(457, 261)
        Me.BtnUnSelectOne.Name = "BtnUnSelectOne"
        Me.BtnUnSelectOne.Size = New System.Drawing.Size(75, 23)
        Me.BtnUnSelectOne.TabIndex = 19
        Me.BtnUnSelectOne.Text = "<--"
        '
        'BtnUnSelectAll
        '
        Me.BtnUnSelectAll.Location = New System.Drawing.Point(457, 301)
        Me.BtnUnSelectAll.Name = "BtnUnSelectAll"
        Me.BtnUnSelectAll.Size = New System.Drawing.Size(75, 23)
        Me.BtnUnSelectAll.TabIndex = 20
        Me.BtnUnSelectAll.Text = "<<--"
        '
        'LblYuxuan
        '
        Me.LblYuxuan.AutoSize = True
        Me.LblYuxuan.Location = New System.Drawing.Point(191, 149)
        Me.LblYuxuan.Name = "LblYuxuan"
        Me.LblYuxuan.Size = New System.Drawing.Size(77, 12)
        Me.LblYuxuan.TabIndex = 21
        Me.LblYuxuan.Text = "预选物料信息"
        '
        'LblYixuan
        '
        Me.LblYixuan.AutoSize = True
        Me.LblYixuan.Location = New System.Drawing.Point(682, 149)
        Me.LblYixuan.Name = "LblYixuan"
        Me.LblYixuan.Size = New System.Drawing.Size(77, 12)
        Me.LblYixuan.TabIndex = 22
        Me.LblYixuan.Text = "已选物料信息"
        '
        'FrmCpGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.ListBoxYuxuan)
        Me.Controls.Add(Me.ListBoxYixuan)
        Me.Controls.Add(Me.BtnSelectAll)
        Me.Controls.Add(Me.BtnSelectOne)
        Me.Controls.Add(Me.BtnUnSelectOne)
        Me.Controls.Add(Me.BtnUnSelectAll)
        Me.Controls.Add(Me.LblYuxuan)
        Me.Controls.Add(Me.LblYixuan)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStripPanel1)
        Me.Name = "FrmCpGroup"
        Me.Text = "物料组维护"
        Me.ToolStripPanel1.ResumeLayout(False)
        Me.ToolStripPanel1.PerformLayout()
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.rcBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcBindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripPanel1 As System.Windows.Forms.ToolStripPanel
    Friend WithEvents MnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuiFile As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuiPageSetup As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuiPreview As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuiPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tss3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuiNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents MnuiExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnPageSetup As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnPreview As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tss1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tss2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnExit As System.Windows.Forms.ToolStripButton
    Public WithEvents TxtGroupName As System.Windows.Forms.TextBox
    Public WithEvents LblGroupName As System.Windows.Forms.Label
    Public WithEvents TxtGroupID As System.Windows.Forms.TextBox
    Public WithEvents LblGroupID As System.Windows.Forms.Label
    Friend WithEvents LblGroupSm As System.Windows.Forms.Label
    Friend WithEvents TxtGroupSm As System.Windows.Forms.TextBox
    Friend WithEvents rcBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents rcBindingSource2 As System.Windows.Forms.BindingSource
    Friend WithEvents TxtGuanLiYuan As System.Windows.Forms.TextBox
    Friend WithEvents LblGuanLiYuan As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ListBoxYuxuan As System.Windows.Forms.ListBox
    Friend WithEvents ListBoxYixuan As System.Windows.Forms.ListBox
    Friend WithEvents BtnSelectAll As System.Windows.Forms.Button
    Friend WithEvents BtnSelectOne As System.Windows.Forms.Button
    Friend WithEvents BtnUnSelectOne As System.Windows.Forms.Button
    Friend WithEvents BtnUnSelectAll As System.Windows.Forms.Button
    Friend WithEvents LblYuxuan As System.Windows.Forms.Label
    Friend WithEvents LblYixuan As System.Windows.Forms.Label
End Class
