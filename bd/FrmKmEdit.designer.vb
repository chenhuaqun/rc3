<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmKmEdit
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
        Me.ToolStripPanelMain = New System.Windows.Forms.ToolStripPanel()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.BtnTop = New System.Windows.Forms.ToolStripButton()
        Me.BtnPrevious = New System.Windows.Forms.ToolStripButton()
        Me.BtnNext = New System.Windows.Forms.ToolStripButton()
        Me.BtnBottom = New System.Windows.Forms.ToolStripButton()
        Me.Tss1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnNew = New System.Windows.Forms.ToolStripButton()
        Me.BtnEdit = New System.Windows.Forms.ToolStripButton()
        Me.BtnSave = New System.Windows.Forms.ToolStripButton()
        Me.BtnCancel = New System.Windows.Forms.ToolStripButton()
        Me.Tss2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnExit = New System.Windows.Forms.ToolStripButton()
        Me.MenuStripMain = New System.Windows.Forms.MenuStrip()
        Me.MnuiFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tss3 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuiExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.LblKmsm = New System.Windows.Forms.Label()
        Me.TxtKmsm = New System.Windows.Forms.TextBox()
        Me.TxtKmmc = New System.Windows.Forms.TextBox()
        Me.TxtKmdm = New System.Windows.Forms.TextBox()
        Me.LblKmmc = New System.Windows.Forms.Label()
        Me.LblKmdm = New System.Windows.Forms.Label()
        Me.LblParentId = New System.Windows.Forms.Label()
        Me.TxtParentId = New System.Windows.Forms.TextBox()
        Me.LblKmxz = New System.Windows.Forms.Label()
        Me.CmbKmxz = New System.Windows.Forms.ComboBox()
        Me.LblKmgs = New System.Windows.Forms.Label()
        Me.CmbKmgs = New System.Windows.Forms.ComboBox()
        Me.LblKmbz = New System.Windows.Forms.Label()
        Me.TxtKmbz = New System.Windows.Forms.TextBox()
        Me.LblKmdw = New System.Windows.Forms.Label()
        Me.TxtKmdw = New System.Windows.Forms.TextBox()
        Me.ChbKmbm = New System.Windows.Forms.CheckBox()
        Me.ChbKmxm = New System.Windows.Forms.CheckBox()
        Me.ChbKmkh = New System.Windows.Forms.CheckBox()
        Me.ChbKmjx = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ChbKmzy = New System.Windows.Forms.CheckBox()
        Me.ChbKmcs = New System.Windows.Forms.CheckBox()
        Me.ChbKmyh = New System.Windows.Forms.CheckBox()
        Me.ChbKmxj = New System.Windows.Forms.CheckBox()
        Me.ToolStripPanelMain.SuspendLayout()
        Me.ToolStripMain.SuspendLayout()
        Me.MenuStripMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripPanelMain
        '
        Me.ToolStripPanelMain.Controls.Add(Me.ToolStripMain)
        Me.ToolStripPanelMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.ToolStripPanelMain.Location = New System.Drawing.Point(0, 32)
        Me.ToolStripPanelMain.Name = "ToolStripPanelMain"
        Me.ToolStripPanelMain.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.ToolStripPanelMain.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ToolStripPanelMain.Size = New System.Drawing.Size(782, 41)
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripMain.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnTop, Me.BtnPrevious, Me.BtnNext, Me.BtnBottom, Me.Tss1, Me.BtnNew, Me.BtnEdit, Me.BtnSave, Me.BtnCancel, Me.Tss2, Me.BtnExit})
        Me.ToolStripMain.Location = New System.Drawing.Point(3, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(354, 41)
        Me.ToolStripMain.TabIndex = 1
        '
        'BtnTop
        '
        Me.BtnTop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnTop.Image = Global.rc3.My.Resources.Resources.ImgTop
        Me.BtnTop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnTop.Name = "BtnTop"
        Me.BtnTop.Size = New System.Drawing.Size(36, 36)
        Me.BtnTop.Text = "首条"
        '
        'BtnPrevious
        '
        Me.BtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrevious.Image = Global.rc3.My.Resources.Resources.ImgPrevious
        Me.BtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(36, 36)
        Me.BtnPrevious.Text = "上条"
        '
        'BtnNext
        '
        Me.BtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNext.Image = Global.rc3.My.Resources.Resources.ImgNext
        Me.BtnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(36, 36)
        Me.BtnNext.Text = "下条"
        '
        'BtnBottom
        '
        Me.BtnBottom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnBottom.Image = Global.rc3.My.Resources.Resources.ImgBottom
        Me.BtnBottom.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnBottom.Name = "BtnBottom"
        Me.BtnBottom.Size = New System.Drawing.Size(36, 36)
        Me.BtnBottom.Text = "末条"
        '
        'Tss1
        '
        Me.Tss1.Name = "Tss1"
        Me.Tss1.Size = New System.Drawing.Size(6, 41)
        '
        'BtnNew
        '
        Me.BtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNew.Image = Global.rc3.My.Resources.Resources.ImgNew
        Me.BtnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(36, 36)
        Me.BtnNew.Text = "新增"
        '
        'BtnEdit
        '
        Me.BtnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnEdit.Image = Global.rc3.My.Resources.Resources.ImgEdit
        Me.BtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(36, 36)
        Me.BtnEdit.Text = "修改"
        '
        'BtnSave
        '
        Me.BtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnSave.Image = Global.rc3.My.Resources.Resources.ImgSave
        Me.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(36, 36)
        Me.BtnSave.Text = "保存"
        '
        'BtnCancel
        '
        Me.BtnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnCancel.Image = Global.rc3.My.Resources.Resources.ImgCancel
        Me.BtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(36, 36)
        Me.BtnCancel.Text = "取消"
        '
        'Tss2
        '
        Me.Tss2.Name = "Tss2"
        Me.Tss2.Size = New System.Drawing.Size(6, 41)
        '
        'BtnExit
        '
        Me.BtnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnExit.Image = Global.rc3.My.Resources.Resources.ImgExit
        Me.BtnExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(36, 36)
        Me.BtnExit.Text = "返回"
        '
        'MenuStripMain
        '
        Me.MenuStripMain.GripMargin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.MenuStripMain.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiFile, Me.MnuiHelp})
        Me.MenuStripMain.Location = New System.Drawing.Point(0, 0)
        Me.MenuStripMain.Name = "MenuStripMain"
        Me.MenuStripMain.Size = New System.Drawing.Size(782, 32)
        Me.MenuStripMain.TabIndex = 0
        Me.MenuStripMain.Text = "MenuStripMain"
        '
        'MnuiFile
        '
        Me.MnuiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiNew, Me.MnuiEdit, Me.MnuiSave, Me.MnuiCancel, Me.Tss3, Me.MnuiExit})
        Me.MnuiFile.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiFile.Name = "MnuiFile"
        Me.MnuiFile.Size = New System.Drawing.Size(84, 28)
        Me.MnuiFile.Text = "文件(&F)"
        '
        'MnuiNew
        '
        Me.MnuiNew.Name = "MnuiNew"
        Me.MnuiNew.Size = New System.Drawing.Size(210, 34)
        Me.MnuiNew.Text = "新增"
        '
        'MnuiEdit
        '
        Me.MnuiEdit.Name = "MnuiEdit"
        Me.MnuiEdit.Size = New System.Drawing.Size(210, 34)
        Me.MnuiEdit.Text = "修改"
        '
        'MnuiSave
        '
        Me.MnuiSave.Name = "MnuiSave"
        Me.MnuiSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.MnuiSave.Size = New System.Drawing.Size(210, 34)
        Me.MnuiSave.Text = "保存"
        '
        'MnuiCancel
        '
        Me.MnuiCancel.Name = "MnuiCancel"
        Me.MnuiCancel.Size = New System.Drawing.Size(210, 34)
        Me.MnuiCancel.Text = "取消"
        '
        'Tss3
        '
        Me.Tss3.Name = "Tss3"
        Me.Tss3.Size = New System.Drawing.Size(207, 6)
        '
        'MnuiExit
        '
        Me.MnuiExit.Name = "MnuiExit"
        Me.MnuiExit.Size = New System.Drawing.Size(210, 34)
        Me.MnuiExit.Text = "关闭"
        '
        'MnuiHelp
        '
        Me.MnuiHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiAbout})
        Me.MnuiHelp.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiHelp.Name = "MnuiHelp"
        Me.MnuiHelp.Size = New System.Drawing.Size(88, 28)
        Me.MnuiHelp.Text = "帮助(&H)"
        '
        'MnuiAbout
        '
        Me.MnuiAbout.Name = "MnuiAbout"
        Me.MnuiAbout.Size = New System.Drawing.Size(171, 34)
        Me.MnuiAbout.Text = "关于(&A)"
        '
        'LblKmsm
        '
        Me.LblKmsm.AutoSize = True
        Me.LblKmsm.Location = New System.Drawing.Point(60, 111)
        Me.LblKmsm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblKmsm.Name = "LblKmsm"
        Me.LblKmsm.Size = New System.Drawing.Size(98, 18)
        Me.LblKmsm.TabIndex = 4
        Me.LblKmsm.Text = "记 忆 码："
        '
        'TxtKmsm
        '
        Me.TxtKmsm.Location = New System.Drawing.Point(188, 106)
        Me.TxtKmsm.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtKmsm.MaxLength = 12
        Me.TxtKmsm.Name = "TxtKmsm"
        Me.TxtKmsm.Size = New System.Drawing.Size(157, 28)
        Me.TxtKmsm.TabIndex = 5
        '
        'TxtKmmc
        '
        Me.TxtKmmc.Location = New System.Drawing.Point(188, 70)
        Me.TxtKmmc.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtKmmc.MaxLength = 50
        Me.TxtKmmc.Name = "TxtKmmc"
        Me.TxtKmmc.Size = New System.Drawing.Size(358, 28)
        Me.TxtKmmc.TabIndex = 3
        '
        'TxtKmdm
        '
        Me.TxtKmdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtKmdm.Location = New System.Drawing.Point(188, 34)
        Me.TxtKmdm.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtKmdm.MaxLength = 12
        Me.TxtKmdm.Name = "TxtKmdm"
        Me.TxtKmdm.Size = New System.Drawing.Size(128, 28)
        Me.TxtKmdm.TabIndex = 1
        '
        'LblKmmc
        '
        Me.LblKmmc.AutoSize = True
        Me.LblKmmc.Location = New System.Drawing.Point(60, 75)
        Me.LblKmmc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblKmmc.Name = "LblKmmc"
        Me.LblKmmc.Size = New System.Drawing.Size(98, 18)
        Me.LblKmmc.TabIndex = 2
        Me.LblKmmc.Text = "科目名称："
        '
        'LblKmdm
        '
        Me.LblKmdm.AutoSize = True
        Me.LblKmdm.Location = New System.Drawing.Point(60, 39)
        Me.LblKmdm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblKmdm.Name = "LblKmdm"
        Me.LblKmdm.Size = New System.Drawing.Size(98, 18)
        Me.LblKmdm.TabIndex = 0
        Me.LblKmdm.Text = "科目编码："
        '
        'LblParentId
        '
        Me.LblParentId.AutoSize = True
        Me.LblParentId.Location = New System.Drawing.Point(60, 272)
        Me.LblParentId.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblParentId.Name = "LblParentId"
        Me.LblParentId.Size = New System.Drawing.Size(98, 18)
        Me.LblParentId.TabIndex = 14
        Me.LblParentId.Text = "上级科目："
        '
        'TxtParentId
        '
        Me.TxtParentId.Location = New System.Drawing.Point(188, 267)
        Me.TxtParentId.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtParentId.MaxLength = 12
        Me.TxtParentId.Name = "TxtParentId"
        Me.TxtParentId.Size = New System.Drawing.Size(157, 28)
        Me.TxtParentId.TabIndex = 15
        '
        'LblKmxz
        '
        Me.LblKmxz.AutoSize = True
        Me.LblKmxz.Location = New System.Drawing.Point(60, 148)
        Me.LblKmxz.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblKmxz.Name = "LblKmxz"
        Me.LblKmxz.Size = New System.Drawing.Size(98, 18)
        Me.LblKmxz.TabIndex = 6
        Me.LblKmxz.Text = "科目性质："
        '
        'CmbKmxz
        '
        Me.CmbKmxz.FormattingEnabled = True
        Me.CmbKmxz.Location = New System.Drawing.Point(188, 148)
        Me.CmbKmxz.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbKmxz.Name = "CmbKmxz"
        Me.CmbKmxz.Size = New System.Drawing.Size(157, 26)
        Me.CmbKmxz.TabIndex = 7
        '
        'LblKmgs
        '
        Me.LblKmgs.AutoSize = True
        Me.LblKmgs.Location = New System.Drawing.Point(60, 188)
        Me.LblKmgs.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblKmgs.Name = "LblKmgs"
        Me.LblKmgs.Size = New System.Drawing.Size(98, 18)
        Me.LblKmgs.TabIndex = 8
        Me.LblKmgs.Text = "账簿格式："
        '
        'CmbKmgs
        '
        Me.CmbKmgs.FormattingEnabled = True
        Me.CmbKmgs.Location = New System.Drawing.Point(188, 188)
        Me.CmbKmgs.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbKmgs.Name = "CmbKmgs"
        Me.CmbKmgs.Size = New System.Drawing.Size(157, 26)
        Me.CmbKmgs.TabIndex = 9
        '
        'LblKmbz
        '
        Me.LblKmbz.AutoSize = True
        Me.LblKmbz.Location = New System.Drawing.Point(60, 231)
        Me.LblKmbz.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblKmbz.Name = "LblKmbz"
        Me.LblKmbz.Size = New System.Drawing.Size(98, 18)
        Me.LblKmbz.TabIndex = 10
        Me.LblKmbz.Text = "币    种："
        '
        'TxtKmbz
        '
        Me.TxtKmbz.Location = New System.Drawing.Point(188, 226)
        Me.TxtKmbz.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtKmbz.MaxLength = 12
        Me.TxtKmbz.Name = "TxtKmbz"
        Me.TxtKmbz.Size = New System.Drawing.Size(80, 28)
        Me.TxtKmbz.TabIndex = 11
        '
        'LblKmdw
        '
        Me.LblKmdw.AutoSize = True
        Me.LblKmdw.Location = New System.Drawing.Point(279, 231)
        Me.LblKmdw.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblKmdw.Name = "LblKmdw"
        Me.LblKmdw.Size = New System.Drawing.Size(98, 18)
        Me.LblKmdw.TabIndex = 12
        Me.LblKmdw.Text = "计量单位："
        '
        'TxtKmdw
        '
        Me.TxtKmdw.Location = New System.Drawing.Point(386, 226)
        Me.TxtKmdw.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtKmdw.MaxLength = 12
        Me.TxtKmdw.Name = "TxtKmdw"
        Me.TxtKmdw.Size = New System.Drawing.Size(92, 28)
        Me.TxtKmdw.TabIndex = 13
        '
        'ChbKmbm
        '
        Me.ChbKmbm.AutoSize = True
        Me.ChbKmbm.Location = New System.Drawing.Point(39, 34)
        Me.ChbKmbm.Margin = New System.Windows.Forms.Padding(4)
        Me.ChbKmbm.Name = "ChbKmbm"
        Me.ChbKmbm.Size = New System.Drawing.Size(106, 22)
        Me.ChbKmbm.TabIndex = 0
        Me.ChbKmbm.Text = "部门核算"
        Me.ChbKmbm.UseVisualStyleBackColor = True
        '
        'ChbKmxm
        '
        Me.ChbKmxm.AutoSize = True
        Me.ChbKmxm.Location = New System.Drawing.Point(39, 94)
        Me.ChbKmxm.Margin = New System.Windows.Forms.Padding(4)
        Me.ChbKmxm.Name = "ChbKmxm"
        Me.ChbKmxm.Size = New System.Drawing.Size(106, 22)
        Me.ChbKmxm.TabIndex = 2
        Me.ChbKmxm.Text = "项目核算"
        Me.ChbKmxm.UseVisualStyleBackColor = True
        '
        'ChbKmkh
        '
        Me.ChbKmkh.AutoSize = True
        Me.ChbKmkh.Location = New System.Drawing.Point(39, 124)
        Me.ChbKmkh.Margin = New System.Windows.Forms.Padding(4)
        Me.ChbKmkh.Name = "ChbKmkh"
        Me.ChbKmkh.Size = New System.Drawing.Size(106, 22)
        Me.ChbKmkh.TabIndex = 3
        Me.ChbKmkh.Text = "客户管理"
        Me.ChbKmkh.UseVisualStyleBackColor = True
        '
        'ChbKmjx
        '
        Me.ChbKmjx.AutoSize = True
        Me.ChbKmjx.Location = New System.Drawing.Point(39, 184)
        Me.ChbKmjx.Margin = New System.Windows.Forms.Padding(4)
        Me.ChbKmjx.Name = "ChbKmjx"
        Me.ChbKmjx.Size = New System.Drawing.Size(106, 22)
        Me.ChbKmjx.TabIndex = 5
        Me.ChbKmjx.Text = "计息管理"
        Me.ChbKmjx.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.TxtKmdw)
        Me.Panel1.Controls.Add(Me.LblKmdw)
        Me.Panel1.Controls.Add(Me.TxtKmbz)
        Me.Panel1.Controls.Add(Me.LblKmbz)
        Me.Panel1.Controls.Add(Me.CmbKmgs)
        Me.Panel1.Controls.Add(Me.LblKmgs)
        Me.Panel1.Controls.Add(Me.CmbKmxz)
        Me.Panel1.Controls.Add(Me.LblKmxz)
        Me.Panel1.Controls.Add(Me.TxtParentId)
        Me.Panel1.Controls.Add(Me.LblParentId)
        Me.Panel1.Controls.Add(Me.LblKmdm)
        Me.Panel1.Controls.Add(Me.LblKmmc)
        Me.Panel1.Controls.Add(Me.TxtKmdm)
        Me.Panel1.Controls.Add(Me.TxtKmmc)
        Me.Panel1.Controls.Add(Me.TxtKmsm)
        Me.Panel1.Controls.Add(Me.LblKmsm)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 73)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(782, 368)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChbKmzy)
        Me.GroupBox1.Controls.Add(Me.ChbKmcs)
        Me.GroupBox1.Controls.Add(Me.ChbKmyh)
        Me.GroupBox1.Controls.Add(Me.ChbKmxj)
        Me.GroupBox1.Controls.Add(Me.ChbKmbm)
        Me.GroupBox1.Controls.Add(Me.ChbKmjx)
        Me.GroupBox1.Controls.Add(Me.ChbKmxm)
        Me.GroupBox1.Controls.Add(Me.ChbKmkh)
        Me.GroupBox1.Location = New System.Drawing.Point(573, 39)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(184, 284)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "辅助核算"
        '
        'ChbKmzy
        '
        Me.ChbKmzy.AutoSize = True
        Me.ChbKmzy.Location = New System.Drawing.Point(39, 64)
        Me.ChbKmzy.Margin = New System.Windows.Forms.Padding(4)
        Me.ChbKmzy.Name = "ChbKmzy"
        Me.ChbKmzy.Size = New System.Drawing.Size(106, 22)
        Me.ChbKmzy.TabIndex = 1
        Me.ChbKmzy.Text = "职员核算"
        Me.ChbKmzy.UseVisualStyleBackColor = True
        '
        'ChbKmcs
        '
        Me.ChbKmcs.AutoSize = True
        Me.ChbKmcs.Location = New System.Drawing.Point(39, 154)
        Me.ChbKmcs.Margin = New System.Windows.Forms.Padding(4)
        Me.ChbKmcs.Name = "ChbKmcs"
        Me.ChbKmcs.Size = New System.Drawing.Size(124, 22)
        Me.ChbKmcs.TabIndex = 4
        Me.ChbKmcs.Text = "供应商管理"
        Me.ChbKmcs.UseVisualStyleBackColor = True
        '
        'ChbKmyh
        '
        Me.ChbKmyh.AutoSize = True
        Me.ChbKmyh.Location = New System.Drawing.Point(39, 214)
        Me.ChbKmyh.Margin = New System.Windows.Forms.Padding(4)
        Me.ChbKmyh.Name = "ChbKmyh"
        Me.ChbKmyh.Size = New System.Drawing.Size(106, 22)
        Me.ChbKmyh.TabIndex = 6
        Me.ChbKmyh.Text = "银行对账"
        Me.ChbKmyh.UseVisualStyleBackColor = True
        '
        'ChbKmxj
        '
        Me.ChbKmxj.AutoSize = True
        Me.ChbKmxj.Location = New System.Drawing.Point(39, 244)
        Me.ChbKmxj.Margin = New System.Windows.Forms.Padding(4)
        Me.ChbKmxj.Name = "ChbKmxj"
        Me.ChbKmxj.Size = New System.Drawing.Size(106, 22)
        Me.ChbKmxj.TabIndex = 7
        Me.ChbKmxj.Text = "现金流量"
        Me.ChbKmxj.UseVisualStyleBackColor = True
        '
        'FrmKmEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 441)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStripPanelMain)
        Me.Controls.Add(Me.MenuStripMain)
        Me.MainMenuStrip = Me.MenuStripMain
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmKmEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "科目设置"
        Me.ToolStripPanelMain.ResumeLayout(False)
        Me.ToolStripPanelMain.PerformLayout()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.MenuStripMain.ResumeLayout(False)
        Me.MenuStripMain.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripPanelMain As System.Windows.Forms.ToolStripPanel
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnTop As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnPrevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnBottom As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tss1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tss2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents MenuStripMain As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuiFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tss3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuiExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LblKmsm As System.Windows.Forms.Label
    Friend WithEvents TxtKmsm As System.Windows.Forms.TextBox
    Friend WithEvents TxtKmmc As System.Windows.Forms.TextBox
    Friend WithEvents TxtKmdm As System.Windows.Forms.TextBox
    Friend WithEvents LblKmmc As System.Windows.Forms.Label
    Friend WithEvents LblKmdm As System.Windows.Forms.Label
    Friend WithEvents LblParentId As System.Windows.Forms.Label
    Friend WithEvents TxtParentId As System.Windows.Forms.TextBox
    Friend WithEvents LblKmxz As System.Windows.Forms.Label
    Friend WithEvents CmbKmxz As System.Windows.Forms.ComboBox
    Friend WithEvents LblKmgs As System.Windows.Forms.Label
    Friend WithEvents CmbKmgs As System.Windows.Forms.ComboBox
    Friend WithEvents LblKmbz As System.Windows.Forms.Label
    Friend WithEvents TxtKmbz As System.Windows.Forms.TextBox
    Friend WithEvents LblKmdw As System.Windows.Forms.Label
    Friend WithEvents TxtKmdw As System.Windows.Forms.TextBox
    Friend WithEvents ChbKmbm As System.Windows.Forms.CheckBox
    Friend WithEvents ChbKmxm As System.Windows.Forms.CheckBox
    Friend WithEvents ChbKmkh As System.Windows.Forms.CheckBox
    Friend WithEvents ChbKmjx As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ChbKmxj As System.Windows.Forms.CheckBox
    Friend WithEvents ChbKmyh As System.Windows.Forms.CheckBox
    Friend WithEvents ChbKmcs As System.Windows.Forms.CheckBox
    Friend WithEvents ChbKmzy As CheckBox
End Class
