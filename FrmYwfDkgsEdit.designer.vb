<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmYwfDkgsEdit
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
        Me.MnuMain = New System.Windows.Forms.MenuStrip
        Me.MnuiFile = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiNew = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiSave = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiCancel = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem11 = New System.Windows.Forms.ToolStripSeparator
        Me.MnuiExit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiHelp = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripPanel1 = New System.Windows.Forms.ToolStripPanel
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip
        Me.BtnTop = New System.Windows.Forms.ToolStripButton
        Me.BtnPrevious = New System.Windows.Forms.ToolStripButton
        Me.BtnNext = New System.Windows.Forms.ToolStripButton
        Me.BtnBottom = New System.Windows.Forms.ToolStripButton
        Me.Tss1 = New System.Windows.Forms.ToolStripSeparator
        Me.BtnNew = New System.Windows.Forms.ToolStripButton
        Me.BtnEdit = New System.Windows.Forms.ToolStripButton
        Me.BtnSave = New System.Windows.Forms.ToolStripButton
        Me.BtnCancel = New System.Windows.Forms.ToolStripButton
        Me.Tss2 = New System.Windows.Forms.ToolStripSeparator
        Me.BtnExit = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblDkgssm = New System.Windows.Forms.Label
        Me.TxtDkgssm = New System.Windows.Forms.TextBox
        Me.LblJsgs = New System.Windows.Forms.Label
        Me.TxtJsgs = New System.Windows.Forms.TextBox
        Me.LblDkgsdm = New System.Windows.Forms.Label
        Me.LblDkgsmc = New System.Windows.Forms.Label
        Me.TxtDkgsdm = New System.Windows.Forms.TextBox
        Me.TxtDkgsmc = New System.Windows.Forms.TextBox
        Me.MnuMain.SuspendLayout()
        Me.ToolStripPanel1.SuspendLayout()
        Me.ToolStripMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MnuMain
        '
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiFile, Me.MnuiHelp})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(590, 25)
        Me.MnuMain.TabIndex = 1
        '
        'MnuiFile
        '
        Me.MnuiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiNew, Me.MnuiEdit, Me.MnuiSave, Me.MnuiCancel, Me.MenuItem11, Me.MnuiExit})
        Me.MnuiFile.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiFile.Name = "MnuiFile"
        Me.MnuiFile.Size = New System.Drawing.Size(58, 21)
        Me.MnuiFile.Text = "文件(&F)"
        '
        'MnuiNew
        '
        Me.MnuiNew.Name = "MnuiNew"
        Me.MnuiNew.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.MnuiNew.Size = New System.Drawing.Size(166, 22)
        Me.MnuiNew.Text = "新增(&A)"
        '
        'MnuiEdit
        '
        Me.MnuiEdit.Name = "MnuiEdit"
        Me.MnuiEdit.Size = New System.Drawing.Size(166, 22)
        Me.MnuiEdit.Text = "修改(&E)"
        '
        'MnuiSave
        '
        Me.MnuiSave.Name = "MnuiSave"
        Me.MnuiSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.MnuiSave.Size = New System.Drawing.Size(166, 22)
        Me.MnuiSave.Text = "保存(&S)"
        '
        'MnuiCancel
        '
        Me.MnuiCancel.Name = "MnuiCancel"
        Me.MnuiCancel.Size = New System.Drawing.Size(166, 22)
        Me.MnuiCancel.Text = "取消(&C)"
        '
        'MenuItem11
        '
        Me.MenuItem11.Name = "MenuItem11"
        Me.MenuItem11.Size = New System.Drawing.Size(163, 6)
        '
        'MnuiExit
        '
        Me.MnuiExit.Name = "MnuiExit"
        Me.MnuiExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.MnuiExit.Size = New System.Drawing.Size(166, 22)
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
        'ToolStripPanel1
        '
        Me.ToolStripPanel1.Controls.Add(Me.ToolStripMain)
        Me.ToolStripPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ToolStripPanel1.Location = New System.Drawing.Point(0, 25)
        Me.ToolStripPanel1.Name = "ToolStripPanel1"
        Me.ToolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.ToolStripPanel1.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ToolStripPanel1.Size = New System.Drawing.Size(590, 39)
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripMain.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnTop, Me.BtnPrevious, Me.BtnNext, Me.BtnBottom, Me.Tss1, Me.BtnNew, Me.BtnEdit, Me.BtnSave, Me.BtnCancel, Me.Tss2, Me.BtnExit})
        Me.ToolStripMain.Location = New System.Drawing.Point(3, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(348, 39)
        Me.ToolStripMain.TabIndex = 0
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
        Me.Tss1.Size = New System.Drawing.Size(6, 39)
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
        Me.Tss2.Size = New System.Drawing.Size(6, 39)
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
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LblDkgssm)
        Me.Panel1.Controls.Add(Me.TxtDkgssm)
        Me.Panel1.Controls.Add(Me.LblJsgs)
        Me.Panel1.Controls.Add(Me.TxtJsgs)
        Me.Panel1.Controls.Add(Me.LblDkgsdm)
        Me.Panel1.Controls.Add(Me.LblDkgsmc)
        Me.Panel1.Controls.Add(Me.TxtDkgsdm)
        Me.Panel1.Controls.Add(Me.TxtDkgsmc)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 64)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(590, 259)
        Me.Panel1.TabIndex = 1
        '
        'LblDkgssm
        '
        Me.LblDkgssm.AutoSize = True
        Me.LblDkgssm.Location = New System.Drawing.Point(18, 73)
        Me.LblDkgssm.Name = "LblDkgssm"
        Me.LblDkgssm.Size = New System.Drawing.Size(89, 12)
        Me.LblDkgssm.TabIndex = 4
        Me.LblDkgssm.Text = "记   忆   码："
        '
        'TxtDkgssm
        '
        Me.TxtDkgssm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDkgssm.Location = New System.Drawing.Point(114, 69)
        Me.TxtDkgssm.MaxLength = 4
        Me.TxtDkgssm.Name = "TxtDkgssm"
        Me.TxtDkgssm.Size = New System.Drawing.Size(96, 21)
        Me.TxtDkgssm.TabIndex = 5
        '
        'LblJsgs
        '
        Me.LblJsgs.AutoSize = True
        Me.LblJsgs.Location = New System.Drawing.Point(42, 134)
        Me.LblJsgs.Name = "LblJsgs"
        Me.LblJsgs.Size = New System.Drawing.Size(65, 12)
        Me.LblJsgs.TabIndex = 6
        Me.LblJsgs.Text = "计算公式："
        '
        'TxtJsgs
        '
        Me.TxtJsgs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtJsgs.Location = New System.Drawing.Point(114, 108)
        Me.TxtJsgs.MaxLength = 500
        Me.TxtJsgs.Multiline = True
        Me.TxtJsgs.Name = "TxtJsgs"
        Me.TxtJsgs.Size = New System.Drawing.Size(432, 109)
        Me.TxtJsgs.TabIndex = 7
        '
        'LblDkgsdm
        '
        Me.LblDkgsdm.AutoSize = True
        Me.LblDkgsdm.Location = New System.Drawing.Point(18, 17)
        Me.LblDkgsdm.Name = "LblDkgsdm"
        Me.LblDkgsdm.Size = New System.Drawing.Size(89, 12)
        Me.LblDkgsdm.TabIndex = 0
        Me.LblDkgsdm.Text = "抵扣规则编码："
        '
        'LblDkgsmc
        '
        Me.LblDkgsmc.AutoSize = True
        Me.LblDkgsmc.Location = New System.Drawing.Point(18, 46)
        Me.LblDkgsmc.Name = "LblDkgsmc"
        Me.LblDkgsmc.Size = New System.Drawing.Size(89, 12)
        Me.LblDkgsmc.TabIndex = 2
        Me.LblDkgsmc.Text = "抵扣规则名称："
        '
        'TxtDkgsdm
        '
        Me.TxtDkgsdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDkgsdm.Location = New System.Drawing.Point(114, 13)
        Me.TxtDkgsdm.MaxLength = 4
        Me.TxtDkgsdm.Name = "TxtDkgsdm"
        Me.TxtDkgsdm.Size = New System.Drawing.Size(96, 21)
        Me.TxtDkgsdm.TabIndex = 1
        '
        'TxtDkgsmc
        '
        Me.TxtDkgsmc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDkgsmc.Location = New System.Drawing.Point(114, 42)
        Me.TxtDkgsmc.MaxLength = 10
        Me.TxtDkgsmc.Name = "TxtDkgsmc"
        Me.TxtDkgsmc.Size = New System.Drawing.Size(175, 21)
        Me.TxtDkgsmc.TabIndex = 3
        '
        'FrmYwfDkgsEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(590, 323)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStripPanel1)
        Me.Controls.Add(Me.MnuMain)
        Me.Name = "FrmYwfDkgsEdit"
        Me.Text = "业务费抵扣规则信息"
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.ToolStripPanel1.ResumeLayout(False)
        Me.ToolStripPanel1.PerformLayout()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MnuMain As MenuStrip
    Friend WithEvents MnuiFile As ToolStripMenuItem
    Public WithEvents MnuiNew As ToolStripMenuItem
    Friend WithEvents MnuiEdit As ToolStripMenuItem
    Public WithEvents MnuiSave As ToolStripMenuItem
    Public WithEvents MnuiCancel As ToolStripMenuItem
    Friend WithEvents MenuItem11 As ToolStripSeparator
    Public WithEvents MnuiExit As ToolStripMenuItem
    Friend WithEvents MnuiHelp As ToolStripMenuItem
    Friend WithEvents MnuiAbout As ToolStripMenuItem
    Friend WithEvents ToolStripPanel1 As ToolStripPanel
    Friend WithEvents ToolStripMain As ToolStrip
    Friend WithEvents BtnTop As ToolStripButton
    Friend WithEvents BtnPrevious As ToolStripButton
    Friend WithEvents BtnNext As ToolStripButton
    Friend WithEvents BtnBottom As ToolStripButton
    Friend WithEvents Tss1 As ToolStripSeparator
    Friend WithEvents BtnNew As ToolStripButton
    Friend WithEvents BtnEdit As ToolStripButton
    Friend WithEvents BtnSave As ToolStripButton
    Friend WithEvents BtnCancel As ToolStripButton
    Friend WithEvents Tss2 As ToolStripSeparator
    Friend WithEvents BtnExit As ToolStripButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LblJsgs As Label
    Friend WithEvents TxtJsgs As TextBox
    Friend WithEvents LblDkgsdm As Label
    Friend WithEvents LblDkgsmc As Label
    Friend WithEvents TxtDkgsdm As TextBox
    Friend WithEvents TxtDkgsmc As TextBox
    Friend WithEvents LblDkgssm As System.Windows.Forms.Label
    Friend WithEvents TxtDkgssm As System.Windows.Forms.TextBox
End Class
