﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmJsfsEdit
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
        Me.ToolStripPanel1 = New System.Windows.Forms.ToolStripPanel
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
        Me.LblJsfsmc = New System.Windows.Forms.Label
        Me.TxtJsfsmc = New System.Windows.Forms.TextBox
        Me.LblJsfsdm = New System.Windows.Forms.Label
        Me.LblJsfssm = New System.Windows.Forms.Label
        Me.TxtJsfsdm = New System.Windows.Forms.TextBox
        Me.TxtJsfssm = New System.Windows.Forms.TextBox
        Me.ChbBkywf = New System.Windows.Forms.CheckBox
        Me.ToolStripPanel1.SuspendLayout()
        Me.MnuMain.SuspendLayout()
        Me.ToolStripMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
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
        Me.ToolStripPanel1.Size = New System.Drawing.Size(376, 64)
        '
        'MnuMain
        '
        Me.MnuMain.Dock = System.Windows.Forms.DockStyle.None
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiFile, Me.MnuiHelp})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(376, 25)
        Me.MnuMain.TabIndex = 0
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
        'ToolStripMain
        '
        Me.ToolStripMain.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripMain.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnTop, Me.BtnPrevious, Me.BtnNext, Me.BtnBottom, Me.Tss1, Me.BtnNew, Me.BtnEdit, Me.BtnSave, Me.BtnCancel, Me.Tss2, Me.BtnExit})
        Me.ToolStripMain.Location = New System.Drawing.Point(3, 25)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(348, 39)
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
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.ChbBkywf)
        Me.Panel1.Controls.Add(Me.LblJsfsmc)
        Me.Panel1.Controls.Add(Me.TxtJsfsmc)
        Me.Panel1.Controls.Add(Me.LblJsfsdm)
        Me.Panel1.Controls.Add(Me.LblJsfssm)
        Me.Panel1.Controls.Add(Me.TxtJsfsdm)
        Me.Panel1.Controls.Add(Me.TxtJsfssm)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 64)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(376, 148)
        Me.Panel1.TabIndex = 0
        '
        'LblJsfsmc
        '
        Me.LblJsfsmc.AutoSize = True
        Me.LblJsfsmc.Location = New System.Drawing.Point(48, 57)
        Me.LblJsfsmc.Name = "LblJsfsmc"
        Me.LblJsfsmc.Size = New System.Drawing.Size(89, 12)
        Me.LblJsfsmc.TabIndex = 2
        Me.LblJsfsmc.Text = "结算方式名称："
        '
        'TxtJsfsmc
        '
        Me.TxtJsfsmc.Location = New System.Drawing.Point(143, 54)
        Me.TxtJsfsmc.MaxLength = 40
        Me.TxtJsfsmc.Name = "TxtJsfsmc"
        Me.TxtJsfsmc.Size = New System.Drawing.Size(183, 21)
        Me.TxtJsfsmc.TabIndex = 3
        '
        'LblJsfsdm
        '
        Me.LblJsfsdm.AutoSize = True
        Me.LblJsfsdm.Location = New System.Drawing.Point(48, 28)
        Me.LblJsfsdm.Name = "LblJsfsdm"
        Me.LblJsfsdm.Size = New System.Drawing.Size(89, 12)
        Me.LblJsfsdm.TabIndex = 0
        Me.LblJsfsdm.Text = "结算方式编码："
        '
        'LblJsfssm
        '
        Me.LblJsfssm.AutoSize = True
        Me.LblJsfssm.Location = New System.Drawing.Point(48, 86)
        Me.LblJsfssm.Name = "LblJsfssm"
        Me.LblJsfssm.Size = New System.Drawing.Size(89, 12)
        Me.LblJsfssm.TabIndex = 4
        Me.LblJsfssm.Text = "记   忆   码："
        '
        'TxtJsfsdm
        '
        Me.TxtJsfsdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtJsfsdm.Location = New System.Drawing.Point(143, 25)
        Me.TxtJsfsdm.MaxLength = 12
        Me.TxtJsfsdm.Name = "TxtJsfsdm"
        Me.TxtJsfsdm.Size = New System.Drawing.Size(96, 21)
        Me.TxtJsfsdm.TabIndex = 1
        '
        'TxtJsfssm
        '
        Me.TxtJsfssm.Location = New System.Drawing.Point(143, 83)
        Me.TxtJsfssm.MaxLength = 8
        Me.TxtJsfssm.Name = "TxtJsfssm"
        Me.TxtJsfssm.Size = New System.Drawing.Size(96, 21)
        Me.TxtJsfssm.TabIndex = 5
        '
        'ChbBkywf
        '
        Me.ChbBkywf.AutoSize = True
        Me.ChbBkywf.Location = New System.Drawing.Point(143, 118)
        Me.ChbBkywf.Name = "ChbBkywf"
        Me.ChbBkywf.Size = New System.Drawing.Size(108, 16)
        Me.ChbBkywf.TabIndex = 16
        Me.ChbBkywf.Text = "是否倒扣业务费"
        Me.ChbBkywf.UseVisualStyleBackColor = True
        '
        'FrmJsfsEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(376, 212)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStripPanel1)
        Me.Name = "FrmJsfsEdit"
        Me.Text = "结算方式信息编辑"
        Me.ToolStripPanel1.ResumeLayout(False)
        Me.ToolStripPanel1.PerformLayout()
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
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
    Friend WithEvents LblJsfsmc As System.Windows.Forms.Label
    Friend WithEvents TxtJsfsmc As System.Windows.Forms.TextBox
    Friend WithEvents LblJsfsdm As System.Windows.Forms.Label
    Friend WithEvents LblJsfssm As System.Windows.Forms.Label
    Friend WithEvents TxtJsfsdm As System.Windows.Forms.TextBox
    Friend WithEvents TxtJsfssm As System.Windows.Forms.TextBox
    Friend WithEvents ChbBkywf As System.Windows.Forms.CheckBox
End Class
