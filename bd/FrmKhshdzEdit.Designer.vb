<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmKhshdzEdit
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
        Me.ToolStripPanelMain = New System.Windows.Forms.ToolStripPanel
        Me.MenuStripMain = New System.Windows.Forms.MenuStrip
        Me.MnuiFile = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiNew = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiSave = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiCancel = New System.Windows.Forms.ToolStripMenuItem
        Me.Tss3 = New System.Windows.Forms.ToolStripSeparator
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
        Me.TxtXh = New System.Windows.Forms.TextBox
        Me.ChbLastTimeBz = New System.Windows.Forms.CheckBox
        Me.TxtLxr = New System.Windows.Forms.TextBox
        Me.LblLxr = New System.Windows.Forms.Label
        Me.TxtMobile = New System.Windows.Forms.TextBox
        Me.LblMobile = New System.Windows.Forms.Label
        Me.TxtTel = New System.Windows.Forms.TextBox
        Me.LblTel = New System.Windows.Forms.Label
        Me.TxtPostCode = New System.Windows.Forms.TextBox
        Me.LblPostCode = New System.Windows.Forms.Label
        Me.TxtAddress = New System.Windows.Forms.TextBox
        Me.LblAddress = New System.Windows.Forms.Label
        Me.LblKhmc = New System.Windows.Forms.Label
        Me.TxtKhdm = New System.Windows.Forms.TextBox
        Me.LblKhdm = New System.Windows.Forms.Label
        Me.ToolStripPanelMain.SuspendLayout()
        Me.MenuStripMain.SuspendLayout()
        Me.ToolStripMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripPanelMain
        '
        Me.ToolStripPanelMain.Controls.Add(Me.ToolStripMain)
        Me.ToolStripPanelMain.Controls.Add(Me.MenuStripMain)
        Me.ToolStripPanelMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.ToolStripPanelMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripPanelMain.Name = "ToolStripPanelMain"
        Me.ToolStripPanelMain.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.ToolStripPanelMain.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ToolStripPanelMain.Size = New System.Drawing.Size(493, 64)
        '
        'MenuStripMain
        '
        Me.MenuStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiFile, Me.MnuiHelp})
        Me.MenuStripMain.Location = New System.Drawing.Point(0, 0)
        Me.MenuStripMain.Name = "MenuStripMain"
        Me.MenuStripMain.Size = New System.Drawing.Size(493, 25)
        Me.MenuStripMain.TabIndex = 0
        Me.MenuStripMain.Text = "MenuStripMain"
        '
        'MnuiFile
        '
        Me.MnuiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiNew, Me.MnuiEdit, Me.MnuiSave, Me.MnuiCancel, Me.Tss3, Me.MnuiExit})
        Me.MnuiFile.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiFile.Name = "MnuiFile"
        Me.MnuiFile.Size = New System.Drawing.Size(58, 21)
        Me.MnuiFile.Text = "文件(&F)"
        '
        'MnuiNew
        '
        Me.MnuiNew.Name = "MnuiNew"
        Me.MnuiNew.Size = New System.Drawing.Size(100, 22)
        Me.MnuiNew.Text = "新增"
        '
        'MnuiEdit
        '
        Me.MnuiEdit.Name = "MnuiEdit"
        Me.MnuiEdit.Size = New System.Drawing.Size(100, 22)
        Me.MnuiEdit.Text = "修改"
        '
        'MnuiSave
        '
        Me.MnuiSave.Name = "MnuiSave"
        Me.MnuiSave.Size = New System.Drawing.Size(100, 22)
        Me.MnuiSave.Text = "保存"
        '
        'MnuiCancel
        '
        Me.MnuiCancel.Name = "MnuiCancel"
        Me.MnuiCancel.Size = New System.Drawing.Size(100, 22)
        Me.MnuiCancel.Text = "取消"
        '
        'Tss3
        '
        Me.Tss3.Name = "Tss3"
        Me.Tss3.Size = New System.Drawing.Size(97, 6)
        '
        'MnuiExit
        '
        Me.MnuiExit.Name = "MnuiExit"
        Me.MnuiExit.Size = New System.Drawing.Size(100, 22)
        Me.MnuiExit.Text = "关闭"
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
        Me.BtnTop.Text = "ToolStripButton1"
        '
        'BtnPrevious
        '
        Me.BtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrevious.Image = Global.rc3.My.Resources.Resources.ImgPrevious
        Me.BtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(36, 36)
        Me.BtnPrevious.Text = "ToolStripButton2"
        '
        'BtnNext
        '
        Me.BtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNext.Image = Global.rc3.My.Resources.Resources.ImgNext
        Me.BtnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(36, 36)
        Me.BtnNext.Text = "ToolStripButton3"
        '
        'BtnBottom
        '
        Me.BtnBottom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnBottom.Image = Global.rc3.My.Resources.Resources.ImgBottom
        Me.BtnBottom.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnBottom.Name = "BtnBottom"
        Me.BtnBottom.Size = New System.Drawing.Size(36, 36)
        Me.BtnBottom.Text = "ToolStripButton4"
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
        Me.BtnNew.Text = "ToolStripButton5"
        '
        'BtnEdit
        '
        Me.BtnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnEdit.Image = Global.rc3.My.Resources.Resources.ImgEdit
        Me.BtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(36, 36)
        Me.BtnEdit.Text = "ToolStripButton1"
        '
        'BtnSave
        '
        Me.BtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnSave.Image = Global.rc3.My.Resources.Resources.ImgSave
        Me.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(36, 36)
        Me.BtnSave.Text = "ToolStripButton6"
        '
        'BtnCancel
        '
        Me.BtnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnCancel.Image = Global.rc3.My.Resources.Resources.ImgCancel
        Me.BtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(36, 36)
        Me.BtnCancel.Text = "ToolStripButton7"
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
        Me.BtnExit.Text = "ToolStripButton8"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TxtXh)
        Me.Panel1.Controls.Add(Me.ChbLastTimeBz)
        Me.Panel1.Controls.Add(Me.TxtLxr)
        Me.Panel1.Controls.Add(Me.LblLxr)
        Me.Panel1.Controls.Add(Me.TxtMobile)
        Me.Panel1.Controls.Add(Me.LblMobile)
        Me.Panel1.Controls.Add(Me.TxtTel)
        Me.Panel1.Controls.Add(Me.LblTel)
        Me.Panel1.Controls.Add(Me.TxtPostCode)
        Me.Panel1.Controls.Add(Me.LblPostCode)
        Me.Panel1.Controls.Add(Me.TxtAddress)
        Me.Panel1.Controls.Add(Me.LblAddress)
        Me.Panel1.Controls.Add(Me.LblKhmc)
        Me.Panel1.Controls.Add(Me.TxtKhdm)
        Me.Panel1.Controls.Add(Me.LblKhdm)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 64)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(493, 250)
        Me.Panel1.TabIndex = 1
        '
        'TxtXh
        '
        Me.TxtXh.Enabled = False
        Me.TxtXh.Location = New System.Drawing.Point(240, 24)
        Me.TxtXh.MaxLength = 10
        Me.TxtXh.Name = "TxtXh"
        Me.TxtXh.Size = New System.Drawing.Size(42, 21)
        Me.TxtXh.TabIndex = 15
        '
        'ChbLastTimeBz
        '
        Me.ChbLastTimeBz.AutoSize = True
        Me.ChbLastTimeBz.Location = New System.Drawing.Point(134, 207)
        Me.ChbLastTimeBz.Name = "ChbLastTimeBz"
        Me.ChbLastTimeBz.Size = New System.Drawing.Size(96, 16)
        Me.ChbLastTimeBz.TabIndex = 14
        Me.ChbLastTimeBz.Text = "上次送货标志"
        Me.ChbLastTimeBz.UseVisualStyleBackColor = True
        '
        'TxtLxr
        '
        Me.TxtLxr.Location = New System.Drawing.Point(134, 178)
        Me.TxtLxr.MaxLength = 20
        Me.TxtLxr.Name = "TxtLxr"
        Me.TxtLxr.Size = New System.Drawing.Size(136, 21)
        Me.TxtLxr.TabIndex = 12
        '
        'LblLxr
        '
        Me.LblLxr.AutoSize = True
        Me.LblLxr.Location = New System.Drawing.Point(63, 181)
        Me.LblLxr.Name = "LblLxr"
        Me.LblLxr.Size = New System.Drawing.Size(65, 12)
        Me.LblLxr.TabIndex = 11
        Me.LblLxr.Text = "联 系 人："
        '
        'TxtMobile
        '
        Me.TxtMobile.Location = New System.Drawing.Point(134, 151)
        Me.TxtMobile.MaxLength = 11
        Me.TxtMobile.Name = "TxtMobile"
        Me.TxtMobile.Size = New System.Drawing.Size(136, 21)
        Me.TxtMobile.TabIndex = 10
        '
        'LblMobile
        '
        Me.LblMobile.AutoSize = True
        Me.LblMobile.Location = New System.Drawing.Point(63, 154)
        Me.LblMobile.Name = "LblMobile"
        Me.LblMobile.Size = New System.Drawing.Size(65, 12)
        Me.LblMobile.TabIndex = 9
        Me.LblMobile.Text = "手    机："
        '
        'TxtTel
        '
        Me.TxtTel.Location = New System.Drawing.Point(134, 124)
        Me.TxtTel.MaxLength = 20
        Me.TxtTel.Name = "TxtTel"
        Me.TxtTel.Size = New System.Drawing.Size(136, 21)
        Me.TxtTel.TabIndex = 8
        '
        'LblTel
        '
        Me.LblTel.AutoSize = True
        Me.LblTel.Location = New System.Drawing.Point(63, 127)
        Me.LblTel.Name = "LblTel"
        Me.LblTel.Size = New System.Drawing.Size(65, 12)
        Me.LblTel.TabIndex = 7
        Me.LblTel.Text = "电    话："
        '
        'TxtPostCode
        '
        Me.TxtPostCode.Location = New System.Drawing.Point(134, 97)
        Me.TxtPostCode.MaxLength = 6
        Me.TxtPostCode.Name = "TxtPostCode"
        Me.TxtPostCode.Size = New System.Drawing.Size(58, 21)
        Me.TxtPostCode.TabIndex = 6
        '
        'LblPostCode
        '
        Me.LblPostCode.AutoSize = True
        Me.LblPostCode.Location = New System.Drawing.Point(63, 100)
        Me.LblPostCode.Name = "LblPostCode"
        Me.LblPostCode.Size = New System.Drawing.Size(65, 12)
        Me.LblPostCode.TabIndex = 5
        Me.LblPostCode.Text = "邮政编码："
        '
        'TxtAddress
        '
        Me.TxtAddress.Location = New System.Drawing.Point(134, 70)
        Me.TxtAddress.MaxLength = 200
        Me.TxtAddress.Name = "TxtAddress"
        Me.TxtAddress.Size = New System.Drawing.Size(271, 21)
        Me.TxtAddress.TabIndex = 4
        '
        'LblAddress
        '
        Me.LblAddress.AutoSize = True
        Me.LblAddress.Location = New System.Drawing.Point(63, 73)
        Me.LblAddress.Name = "LblAddress"
        Me.LblAddress.Size = New System.Drawing.Size(65, 12)
        Me.LblAddress.TabIndex = 3
        Me.LblAddress.Text = "收货地址："
        '
        'LblKhmc
        '
        Me.LblKhmc.AutoSize = True
        Me.LblKhmc.Location = New System.Drawing.Point(132, 48)
        Me.LblKhmc.Name = "LblKhmc"
        Me.LblKhmc.Size = New System.Drawing.Size(53, 12)
        Me.LblKhmc.TabIndex = 2
        Me.LblKhmc.Text = "客户名称"
        '
        'TxtKhdm
        '
        Me.TxtKhdm.Location = New System.Drawing.Point(134, 24)
        Me.TxtKhdm.MaxLength = 12
        Me.TxtKhdm.Name = "TxtKhdm"
        Me.TxtKhdm.Size = New System.Drawing.Size(87, 21)
        Me.TxtKhdm.TabIndex = 1
        '
        'LblKhdm
        '
        Me.LblKhdm.AutoSize = True
        Me.LblKhdm.Location = New System.Drawing.Point(63, 27)
        Me.LblKhdm.Name = "LblKhdm"
        Me.LblKhdm.Size = New System.Drawing.Size(65, 12)
        Me.LblKhdm.TabIndex = 0
        Me.LblKhdm.Text = "客户编码："
        '
        'FrmKhshdzEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(493, 314)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStripPanelMain)
        Me.MainMenuStrip = Me.MenuStripMain
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmKhshdzEdit"
        Me.Text = "客户收货地址"
        Me.ToolStripPanelMain.ResumeLayout(False)
        Me.ToolStripPanelMain.PerformLayout()
        Me.MenuStripMain.ResumeLayout(False)
        Me.MenuStripMain.PerformLayout()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LblAddress As System.Windows.Forms.Label
    Friend WithEvents LblKhmc As System.Windows.Forms.Label
    Friend WithEvents TxtKhdm As System.Windows.Forms.TextBox
    Friend WithEvents LblKhdm As System.Windows.Forms.Label
    Friend WithEvents ChbLastTimeBz As System.Windows.Forms.CheckBox
    Friend WithEvents TxtLxr As System.Windows.Forms.TextBox
    Friend WithEvents LblLxr As System.Windows.Forms.Label
    Friend WithEvents TxtMobile As System.Windows.Forms.TextBox
    Friend WithEvents LblMobile As System.Windows.Forms.Label
    Friend WithEvents TxtTel As System.Windows.Forms.TextBox
    Friend WithEvents LblTel As System.Windows.Forms.Label
    Friend WithEvents TxtPostCode As System.Windows.Forms.TextBox
    Friend WithEvents LblPostCode As System.Windows.Forms.Label
    Friend WithEvents TxtAddress As System.Windows.Forms.TextBox
    Friend WithEvents MnuiNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TxtXh As System.Windows.Forms.TextBox
    Friend WithEvents MnuiAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tss3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuiExit As System.Windows.Forms.ToolStripMenuItem
End Class
