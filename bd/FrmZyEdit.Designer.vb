<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmZyEdit
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
        Me.MnuMain = New System.Windows.Forms.MenuStrip
        Me.MnuiFile = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiNew = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiSave = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiCancel = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiCom1 = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiCom2 = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem11 = New System.Windows.Forms.ToolStripSeparator
        Me.MnuiExit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiHelp = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblIcno = New System.Windows.Forms.Label
        Me.TxtIcno = New System.Windows.Forms.TextBox
        Me.LblBmmc = New System.Windows.Forms.Label
        Me.TxtBmdm = New System.Windows.Forms.TextBox
        Me.LblBmdm = New System.Windows.Forms.Label
        Me.LblZymc = New System.Windows.Forms.Label
        Me.TxtZymc = New System.Windows.Forms.TextBox
        Me.LblZydm = New System.Windows.Forms.Label
        Me.LblZysm = New System.Windows.Forms.Label
        Me.TxtZydm = New System.Windows.Forms.TextBox
        Me.TxtZysm = New System.Windows.Forms.TextBox
        Me.TimerReadCard = New System.Windows.Forms.Timer(Me.components)
        Me.LblEmail = New System.Windows.Forms.Label
        Me.TxtEmail = New System.Windows.Forms.TextBox
        Me.ToolStripPanel1.SuspendLayout()
        Me.ToolStripMain.SuspendLayout()
        Me.MnuMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripPanel1
        '
        Me.ToolStripPanel1.Controls.Add(Me.ToolStripMain)
        Me.ToolStripPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ToolStripPanel1.Location = New System.Drawing.Point(0, 25)
        Me.ToolStripPanel1.Name = "ToolStripPanel1"
        Me.ToolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.ToolStripPanel1.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ToolStripPanel1.Size = New System.Drawing.Size(404, 39)
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
        'MnuMain
        '
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiFile, Me.MnuiHelp})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(404, 25)
        Me.MnuMain.TabIndex = 1
        '
        'MnuiFile
        '
        Me.MnuiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiNew, Me.MnuiEdit, Me.MnuiSave, Me.MnuiCancel, Me.MnuiCom1, Me.MnuiCom2, Me.MenuItem11, Me.MnuiExit})
        Me.MnuiFile.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiFile.Name = "MnuiFile"
        Me.MnuiFile.Size = New System.Drawing.Size(58, 21)
        Me.MnuiFile.Text = "文件(&F)"
        '
        'MnuiNew
        '
        Me.MnuiNew.Name = "MnuiNew"
        Me.MnuiNew.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.MnuiNew.Size = New System.Drawing.Size(197, 22)
        Me.MnuiNew.Text = "新增(&A)"
        '
        'MnuiEdit
        '
        Me.MnuiEdit.Name = "MnuiEdit"
        Me.MnuiEdit.Size = New System.Drawing.Size(197, 22)
        Me.MnuiEdit.Text = "修改(&E)"
        '
        'MnuiSave
        '
        Me.MnuiSave.Name = "MnuiSave"
        Me.MnuiSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.MnuiSave.Size = New System.Drawing.Size(197, 22)
        Me.MnuiSave.Text = "保存(&S)"
        '
        'MnuiCancel
        '
        Me.MnuiCancel.Name = "MnuiCancel"
        Me.MnuiCancel.Size = New System.Drawing.Size(197, 22)
        Me.MnuiCancel.Text = "取消(&C)"
        '
        'MnuiCom1
        '
        Me.MnuiCom1.Checked = True
        Me.MnuiCom1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MnuiCom1.Name = "MnuiCom1"
        Me.MnuiCom1.Size = New System.Drawing.Size(197, 22)
        Me.MnuiCom1.Text = "读卡器使用COM1端口"
        '
        'MnuiCom2
        '
        Me.MnuiCom2.Name = "MnuiCom2"
        Me.MnuiCom2.Size = New System.Drawing.Size(197, 22)
        Me.MnuiCom2.Text = "读卡器使用COM2端口"
        '
        'MenuItem11
        '
        Me.MenuItem11.Name = "MenuItem11"
        Me.MenuItem11.Size = New System.Drawing.Size(194, 6)
        '
        'MnuiExit
        '
        Me.MnuiExit.Name = "MnuiExit"
        Me.MnuiExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.MnuiExit.Size = New System.Drawing.Size(197, 22)
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
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.LblEmail)
        Me.Panel1.Controls.Add(Me.TxtEmail)
        Me.Panel1.Controls.Add(Me.LblIcno)
        Me.Panel1.Controls.Add(Me.TxtIcno)
        Me.Panel1.Controls.Add(Me.LblBmmc)
        Me.Panel1.Controls.Add(Me.TxtBmdm)
        Me.Panel1.Controls.Add(Me.LblBmdm)
        Me.Panel1.Controls.Add(Me.LblZymc)
        Me.Panel1.Controls.Add(Me.TxtZymc)
        Me.Panel1.Controls.Add(Me.LblZydm)
        Me.Panel1.Controls.Add(Me.LblZysm)
        Me.Panel1.Controls.Add(Me.TxtZydm)
        Me.Panel1.Controls.Add(Me.TxtZysm)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 64)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(404, 217)
        Me.Panel1.TabIndex = 0
        '
        'LblIcno
        '
        Me.LblIcno.AutoSize = True
        Me.LblIcno.Location = New System.Drawing.Point(59, 144)
        Me.LblIcno.Name = "LblIcno"
        Me.LblIcno.Size = New System.Drawing.Size(65, 12)
        Me.LblIcno.TabIndex = 9
        Me.LblIcno.Text = "IC卡号码："
        '
        'TxtIcno
        '
        Me.TxtIcno.Enabled = False
        Me.TxtIcno.Location = New System.Drawing.Point(132, 140)
        Me.TxtIcno.MaxLength = 12
        Me.TxtIcno.Name = "TxtIcno"
        Me.TxtIcno.Size = New System.Drawing.Size(96, 21)
        Me.TxtIcno.TabIndex = 10
        Me.TxtIcno.TabStop = False
        '
        'LblBmmc
        '
        Me.LblBmmc.AutoSize = True
        Me.LblBmmc.Location = New System.Drawing.Point(227, 115)
        Me.LblBmmc.Name = "LblBmmc"
        Me.LblBmmc.Size = New System.Drawing.Size(0, 12)
        Me.LblBmmc.TabIndex = 8
        '
        'TxtBmdm
        '
        Me.TxtBmdm.Location = New System.Drawing.Point(132, 111)
        Me.TxtBmdm.MaxLength = 12
        Me.TxtBmdm.Name = "TxtBmdm"
        Me.TxtBmdm.Size = New System.Drawing.Size(87, 21)
        Me.TxtBmdm.TabIndex = 7
        '
        'LblBmdm
        '
        Me.LblBmdm.AutoSize = True
        Me.LblBmdm.Location = New System.Drawing.Point(59, 115)
        Me.LblBmdm.Name = "LblBmdm"
        Me.LblBmdm.Size = New System.Drawing.Size(65, 12)
        Me.LblBmdm.TabIndex = 6
        Me.LblBmdm.Text = "部门编码："
        '
        'LblZymc
        '
        Me.LblZymc.AutoSize = True
        Me.LblZymc.Location = New System.Drawing.Point(59, 57)
        Me.LblZymc.Name = "LblZymc"
        Me.LblZymc.Size = New System.Drawing.Size(65, 12)
        Me.LblZymc.TabIndex = 2
        Me.LblZymc.Text = "职员姓名："
        '
        'TxtZymc
        '
        Me.TxtZymc.Location = New System.Drawing.Point(132, 53)
        Me.TxtZymc.MaxLength = 40
        Me.TxtZymc.Name = "TxtZymc"
        Me.TxtZymc.Size = New System.Drawing.Size(183, 21)
        Me.TxtZymc.TabIndex = 3
        '
        'LblZydm
        '
        Me.LblZydm.AutoSize = True
        Me.LblZydm.Location = New System.Drawing.Point(59, 28)
        Me.LblZydm.Name = "LblZydm"
        Me.LblZydm.Size = New System.Drawing.Size(65, 12)
        Me.LblZydm.TabIndex = 0
        Me.LblZydm.Text = "职员编码："
        '
        'LblZysm
        '
        Me.LblZysm.AutoSize = True
        Me.LblZysm.Location = New System.Drawing.Point(59, 86)
        Me.LblZysm.Name = "LblZysm"
        Me.LblZysm.Size = New System.Drawing.Size(65, 12)
        Me.LblZysm.TabIndex = 4
        Me.LblZysm.Text = "记 忆 码："
        '
        'TxtZydm
        '
        Me.TxtZydm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtZydm.Location = New System.Drawing.Point(132, 24)
        Me.TxtZydm.MaxLength = 12
        Me.TxtZydm.Name = "TxtZydm"
        Me.TxtZydm.Size = New System.Drawing.Size(87, 21)
        Me.TxtZydm.TabIndex = 1
        '
        'TxtZysm
        '
        Me.TxtZysm.Location = New System.Drawing.Point(132, 82)
        Me.TxtZysm.MaxLength = 8
        Me.TxtZysm.Name = "TxtZysm"
        Me.TxtZysm.Size = New System.Drawing.Size(96, 21)
        Me.TxtZysm.TabIndex = 5
        '
        'TimerReadCard
        '
        Me.TimerReadCard.Interval = 1000
        '
        'LblEmail
        '
        Me.LblEmail.AutoSize = True
        Me.LblEmail.Location = New System.Drawing.Point(77, 173)
        Me.LblEmail.Name = "LblEmail"
        Me.LblEmail.Size = New System.Drawing.Size(47, 12)
        Me.LblEmail.TabIndex = 11
        Me.LblEmail.Text = "Email："
        '
        'TxtEmail
        '
        Me.TxtEmail.Location = New System.Drawing.Point(132, 169)
        Me.TxtEmail.MaxLength = 50
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(208, 21)
        Me.TxtEmail.TabIndex = 12
        '
        'FrmZyEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(404, 281)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStripPanel1)
        Me.Controls.Add(Me.MnuMain)
        Me.Name = "FrmZyEdit"
        Me.Text = "职员信息编辑"
        Me.ToolStripPanel1.ResumeLayout(False)
        Me.ToolStripPanel1.PerformLayout()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripPanel1 As System.Windows.Forms.ToolStripPanel
    Friend WithEvents MnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuiFile As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuiNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiEdit As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuiSave As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuiCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents MnuiExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnTop As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnPrevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnBottom As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tss1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tss2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LblZymc As System.Windows.Forms.Label
    Friend WithEvents TxtZymc As System.Windows.Forms.TextBox
    Friend WithEvents LblZydm As System.Windows.Forms.Label
    Friend WithEvents LblZysm As System.Windows.Forms.Label
    Friend WithEvents TxtZydm As System.Windows.Forms.TextBox
    Friend WithEvents TxtZysm As System.Windows.Forms.TextBox
    Public WithEvents LblBmmc As System.Windows.Forms.Label
    Public WithEvents TxtBmdm As System.Windows.Forms.TextBox
    Public WithEvents LblBmdm As System.Windows.Forms.Label
    Friend WithEvents LblIcno As System.Windows.Forms.Label
    Friend WithEvents TxtIcno As System.Windows.Forms.TextBox
    Friend WithEvents MnuiCom1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiCom2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TimerReadCard As System.Windows.Forms.Timer
    Friend WithEvents LblEmail As System.Windows.Forms.Label
    Friend WithEvents TxtEmail As System.Windows.Forms.TextBox
End Class
