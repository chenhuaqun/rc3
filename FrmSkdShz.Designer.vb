<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSkdShz
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
        Me.MnuiSh = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiXs = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiQs = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiQx = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.MnuiPrevious = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiNext = New System.Windows.Forms.ToolStripMenuItem
        Me.Mnui12 = New System.Windows.Forms.ToolStripSeparator
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
        Me.TxtYspz = New System.Windows.Forms.TextBox
        Me.LblYspz = New System.Windows.Forms.Label
        Me.LblSkmemo = New System.Windows.Forms.Label
        Me.TxtSkmemo = New System.Windows.Forms.TextBox
        Me.TxtJe = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblKhmc = New System.Windows.Forms.Label
        Me.TxtKhdm = New System.Windows.Forms.TextBox
        Me.LblKhdm = New System.Windows.Forms.Label
        Me.LblKmmc = New System.Windows.Forms.Label
        Me.LblSkrq = New System.Windows.Forms.Label
        Me.DtpSkrq = New System.Windows.Forms.DateTimePicker
        Me.TxtDjh = New System.Windows.Forms.TextBox
        Me.LblDjh = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.LblDd = New System.Windows.Forms.Label
        Me.TxtKmdm = New System.Windows.Forms.TextBox
        Me.LblKmdm = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.LblJzr = New System.Windows.Forms.Label
        Me.LblShr = New System.Windows.Forms.Label
        Me.LblSrr = New System.Windows.Forms.Label
        Me.BtnPrevious = New System.Windows.Forms.Button
        Me.BtnNext = New System.Windows.Forms.Button
        Me.BtnExit = New System.Windows.Forms.Button
        Me.BtnSh = New System.Windows.Forms.Button
        Me.BtnPrint = New System.Windows.Forms.Button
        Me.BtnHelp = New System.Windows.Forms.Button
        Me.BtnQs = New System.Windows.Forms.Button
        Me.BtnQx = New System.Windows.Forms.Button
        Me.BtnXs = New System.Windows.Forms.Button
        Me.LblJsfsmc = New System.Windows.Forms.Label
        Me.LblJsfsdm = New System.Windows.Forms.Label
        Me.TxtJsfsdm = New System.Windows.Forms.TextBox
        Me.ToolStripPanel1.SuspendLayout()
        Me.MnuMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
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
        Me.ToolStripPanel1.Size = New System.Drawing.Size(754, 25)
        '
        'MnuMain
        '
        Me.MnuMain.Dock = System.Windows.Forms.DockStyle.None
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiFile, Me.MnuiEdit, Me.MnuiHelp})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(754, 25)
        Me.MnuMain.TabIndex = 2
        '
        'MnuiFile
        '
        Me.MnuiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiSh, Me.MnuiXs, Me.MnuiQs, Me.MnuiQx, Me.ToolStripSeparator1, Me.MnuiPrevious, Me.MnuiNext, Me.Mnui12, Me.MnuiPageSetup, Me.MnuiPrintView, Me.MnuiPrint, Me.Mnui13, Me.MnuiExit})
        Me.MnuiFile.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiFile.Name = "MnuiFile"
        Me.MnuiFile.Size = New System.Drawing.Size(58, 21)
        Me.MnuiFile.Text = "文件(&F)"
        '
        'MnuiSh
        '
        Me.MnuiSh.Name = "MnuiSh"
        Me.MnuiSh.Size = New System.Drawing.Size(141, 22)
        Me.MnuiSh.Text = "审核(&S)"
        '
        'MnuiXs
        '
        Me.MnuiXs.Name = "MnuiXs"
        Me.MnuiXs.Size = New System.Drawing.Size(141, 22)
        Me.MnuiXs.Text = "消审(&C)"
        '
        'MnuiQs
        '
        Me.MnuiQs.Name = "MnuiQs"
        Me.MnuiQs.Size = New System.Drawing.Size(141, 22)
        Me.MnuiQs.Text = "全审(&Q)"
        '
        'MnuiQx
        '
        Me.MnuiQx.Name = "MnuiQx"
        Me.MnuiQx.Size = New System.Drawing.Size(141, 22)
        Me.MnuiQx.Text = "全消(&Y)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(138, 6)
        '
        'MnuiPrevious
        '
        Me.MnuiPrevious.Name = "MnuiPrevious"
        Me.MnuiPrevious.Size = New System.Drawing.Size(141, 22)
        Me.MnuiPrevious.Text = "上张(&F)"
        '
        'MnuiNext
        '
        Me.MnuiNext.Name = "MnuiNext"
        Me.MnuiNext.Size = New System.Drawing.Size(141, 22)
        Me.MnuiNext.Text = "下张(&B)"
        '
        'Mnui12
        '
        Me.Mnui12.Name = "Mnui12"
        Me.Mnui12.Size = New System.Drawing.Size(138, 6)
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
        Me.Panel1.Controls.Add(Me.LblJsfsmc)
        Me.Panel1.Controls.Add(Me.LblJsfsdm)
        Me.Panel1.Controls.Add(Me.TxtJsfsdm)
        Me.Panel1.Controls.Add(Me.TxtYspz)
        Me.Panel1.Controls.Add(Me.LblYspz)
        Me.Panel1.Controls.Add(Me.LblSkmemo)
        Me.Panel1.Controls.Add(Me.TxtSkmemo)
        Me.Panel1.Controls.Add(Me.TxtJe)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.LblKhmc)
        Me.Panel1.Controls.Add(Me.TxtKhdm)
        Me.Panel1.Controls.Add(Me.LblKhdm)
        Me.Panel1.Controls.Add(Me.LblKmmc)
        Me.Panel1.Controls.Add(Me.LblSkrq)
        Me.Panel1.Controls.Add(Me.DtpSkrq)
        Me.Panel1.Controls.Add(Me.TxtDjh)
        Me.Panel1.Controls.Add(Me.LblDjh)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.TxtKmdm)
        Me.Panel1.Controls.Add(Me.LblKmdm)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(754, 399)
        Me.Panel1.TabIndex = 1
        '
        'TxtYspz
        '
        Me.TxtYspz.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtYspz.Enabled = False
        Me.TxtYspz.Location = New System.Drawing.Point(327, 214)
        Me.TxtYspz.MaxLength = 12
        Me.TxtYspz.Name = "TxtYspz"
        Me.TxtYspz.Size = New System.Drawing.Size(96, 21)
        Me.TxtYspz.TabIndex = 20
        '
        'LblYspz
        '
        Me.LblYspz.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblYspz.AutoSize = True
        Me.LblYspz.Location = New System.Drawing.Point(242, 218)
        Me.LblYspz.Name = "LblYspz"
        Me.LblYspz.Size = New System.Drawing.Size(77, 12)
        Me.LblYspz.TabIndex = 19
        Me.LblYspz.Text = "原始凭证号："
        '
        'LblSkmemo
        '
        Me.LblSkmemo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblSkmemo.AutoSize = True
        Me.LblSkmemo.Location = New System.Drawing.Point(254, 276)
        Me.LblSkmemo.Name = "LblSkmemo"
        Me.LblSkmemo.Size = New System.Drawing.Size(65, 12)
        Me.LblSkmemo.TabIndex = 17
        Me.LblSkmemo.Text = "备    注："
        '
        'TxtSkmemo
        '
        Me.TxtSkmemo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtSkmemo.Enabled = False
        Me.TxtSkmemo.Location = New System.Drawing.Point(327, 272)
        Me.TxtSkmemo.MaxLength = 50
        Me.TxtSkmemo.Name = "TxtSkmemo"
        Me.TxtSkmemo.Size = New System.Drawing.Size(208, 21)
        Me.TxtSkmemo.TabIndex = 18
        '
        'TxtJe
        '
        Me.TxtJe.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtJe.Enabled = False
        Me.TxtJe.Location = New System.Drawing.Point(327, 243)
        Me.TxtJe.MaxLength = 11
        Me.TxtJe.Name = "TxtJe"
        Me.TxtJe.Size = New System.Drawing.Size(96, 21)
        Me.TxtJe.TabIndex = 16
        Me.TxtJe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(254, 247)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "收款金额："
        '
        'LblKhmc
        '
        Me.LblKhmc.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblKhmc.AutoSize = True
        Me.LblKhmc.Location = New System.Drawing.Point(421, 127)
        Me.LblKhmc.Name = "LblKhmc"
        Me.LblKhmc.Size = New System.Drawing.Size(0, 12)
        Me.LblKhmc.TabIndex = 10
        '
        'TxtKhdm
        '
        Me.TxtKhdm.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtKhdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtKhdm.Enabled = False
        Me.TxtKhdm.Location = New System.Drawing.Point(327, 127)
        Me.TxtKhdm.MaxLength = 12
        Me.TxtKhdm.Name = "TxtKhdm"
        Me.TxtKhdm.Size = New System.Drawing.Size(87, 21)
        Me.TxtKhdm.TabIndex = 9
        '
        'LblKhdm
        '
        Me.LblKhdm.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblKhdm.AutoSize = True
        Me.LblKhdm.Location = New System.Drawing.Point(254, 131)
        Me.LblKhdm.Name = "LblKhdm"
        Me.LblKhdm.Size = New System.Drawing.Size(65, 12)
        Me.LblKhdm.TabIndex = 8
        Me.LblKhdm.Text = "客户编码："
        '
        'LblKmmc
        '
        Me.LblKmmc.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblKmmc.AutoSize = True
        Me.LblKmmc.Location = New System.Drawing.Point(428, 189)
        Me.LblKmmc.Name = "LblKmmc"
        Me.LblKmmc.Size = New System.Drawing.Size(0, 12)
        Me.LblKmmc.TabIndex = 13
        '
        'LblSkrq
        '
        Me.LblSkrq.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblSkrq.AutoSize = True
        Me.LblSkrq.Location = New System.Drawing.Point(254, 102)
        Me.LblSkrq.Name = "LblSkrq"
        Me.LblSkrq.Size = New System.Drawing.Size(65, 12)
        Me.LblSkrq.TabIndex = 4
        Me.LblSkrq.Text = "收款日期："
        '
        'DtpSkrq
        '
        Me.DtpSkrq.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.DtpSkrq.Enabled = False
        Me.DtpSkrq.Location = New System.Drawing.Point(327, 98)
        Me.DtpSkrq.Name = "DtpSkrq"
        Me.DtpSkrq.Size = New System.Drawing.Size(112, 21)
        Me.DtpSkrq.TabIndex = 5
        '
        'TxtDjh
        '
        Me.TxtDjh.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtDjh.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDjh.Enabled = False
        Me.TxtDjh.Location = New System.Drawing.Point(327, 69)
        Me.TxtDjh.MaxLength = 15
        Me.TxtDjh.Name = "TxtDjh"
        Me.TxtDjh.Size = New System.Drawing.Size(104, 21)
        Me.TxtDjh.TabIndex = 3
        '
        'LblDjh
        '
        Me.LblDjh.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblDjh.AutoSize = True
        Me.LblDjh.Location = New System.Drawing.Point(254, 73)
        Me.LblDjh.Name = "LblDjh"
        Me.LblDjh.Size = New System.Drawing.Size(65, 12)
        Me.LblDjh.TabIndex = 1
        Me.LblDjh.Text = "单 据 号："
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.LblDd)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(754, 48)
        Me.Panel3.TabIndex = 0
        '
        'LblDd
        '
        Me.LblDd.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblDd.AutoSize = True
        Me.LblDd.Font = New System.Drawing.Font("楷体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblDd.ForeColor = System.Drawing.Color.SteelBlue
        Me.LblDd.Location = New System.Drawing.Point(335, 9)
        Me.LblDd.Name = "LblDd"
        Me.LblDd.Size = New System.Drawing.Size(85, 24)
        Me.LblDd.TabIndex = 0
        Me.LblDd.Text = "收款单"
        '
        'TxtKmdm
        '
        Me.TxtKmdm.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtKmdm.Enabled = False
        Me.TxtKmdm.Location = New System.Drawing.Point(327, 185)
        Me.TxtKmdm.MaxLength = 15
        Me.TxtKmdm.Name = "TxtKmdm"
        Me.TxtKmdm.Size = New System.Drawing.Size(93, 21)
        Me.TxtKmdm.TabIndex = 12
        '
        'LblKmdm
        '
        Me.LblKmdm.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblKmdm.AutoSize = True
        Me.LblKmdm.Location = New System.Drawing.Point(254, 189)
        Me.LblKmdm.Name = "LblKmdm"
        Me.LblKmdm.Size = New System.Drawing.Size(65, 12)
        Me.LblKmdm.TabIndex = 11
        Me.LblKmdm.Text = "收款科目："
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.LblJzr)
        Me.Panel2.Controls.Add(Me.LblShr)
        Me.Panel2.Controls.Add(Me.LblSrr)
        Me.Panel2.Controls.Add(Me.BtnPrevious)
        Me.Panel2.Controls.Add(Me.BtnNext)
        Me.Panel2.Controls.Add(Me.BtnExit)
        Me.Panel2.Controls.Add(Me.BtnSh)
        Me.Panel2.Controls.Add(Me.BtnPrint)
        Me.Panel2.Controls.Add(Me.BtnHelp)
        Me.Panel2.Controls.Add(Me.BtnQs)
        Me.Panel2.Controls.Add(Me.BtnQx)
        Me.Panel2.Controls.Add(Me.BtnXs)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 332)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(754, 74)
        Me.Panel2.TabIndex = 5
        '
        'LblJzr
        '
        Me.LblJzr.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblJzr.AutoSize = True
        Me.LblJzr.Location = New System.Drawing.Point(506, 9)
        Me.LblJzr.Name = "LblJzr"
        Me.LblJzr.Size = New System.Drawing.Size(41, 12)
        Me.LblJzr.TabIndex = 38
        Me.LblJzr.Text = "记账："
        '
        'LblShr
        '
        Me.LblShr.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblShr.AutoSize = True
        Me.LblShr.Location = New System.Drawing.Point(383, 9)
        Me.LblShr.Name = "LblShr"
        Me.LblShr.Size = New System.Drawing.Size(41, 12)
        Me.LblShr.TabIndex = 37
        Me.LblShr.Text = "审核："
        '
        'LblSrr
        '
        Me.LblSrr.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblSrr.AutoSize = True
        Me.LblSrr.Location = New System.Drawing.Point(242, 9)
        Me.LblSrr.Name = "LblSrr"
        Me.LblSrr.Size = New System.Drawing.Size(41, 12)
        Me.LblSrr.TabIndex = 36
        Me.LblSrr.Text = "输入："
        '
        'BtnPrevious
        '
        Me.BtnPrevious.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnPrevious.Location = New System.Drawing.Point(338, 35)
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrevious.TabIndex = 31
        Me.BtnPrevious.Text = "上张(&F)"
        '
        'BtnNext
        '
        Me.BtnNext.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnNext.Location = New System.Drawing.Point(418, 35)
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(75, 23)
        Me.BtnNext.TabIndex = 32
        Me.BtnNext.Text = "下张(&B)"
        '
        'BtnExit
        '
        Me.BtnExit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnExit.Location = New System.Drawing.Point(658, 35)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 23)
        Me.BtnExit.TabIndex = 35
        Me.BtnExit.Text = "退出(&X)"
        '
        'BtnSh
        '
        Me.BtnSh.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnSh.Location = New System.Drawing.Point(18, 35)
        Me.BtnSh.Name = "BtnSh"
        Me.BtnSh.Size = New System.Drawing.Size(75, 23)
        Me.BtnSh.TabIndex = 27
        Me.BtnSh.Text = "审核(&S)"
        '
        'BtnPrint
        '
        Me.BtnPrint.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnPrint.Location = New System.Drawing.Point(498, 35)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrint.TabIndex = 33
        Me.BtnPrint.Text = "打印(&P)"
        '
        'BtnHelp
        '
        Me.BtnHelp.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnHelp.Location = New System.Drawing.Point(578, 35)
        Me.BtnHelp.Name = "BtnHelp"
        Me.BtnHelp.Size = New System.Drawing.Size(75, 23)
        Me.BtnHelp.TabIndex = 34
        Me.BtnHelp.Text = "帮助(&H)"
        '
        'BtnQs
        '
        Me.BtnQs.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnQs.Location = New System.Drawing.Point(178, 35)
        Me.BtnQs.Name = "BtnQs"
        Me.BtnQs.Size = New System.Drawing.Size(75, 23)
        Me.BtnQs.TabIndex = 29
        Me.BtnQs.Text = "全审(&Q)"
        '
        'BtnQx
        '
        Me.BtnQx.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnQx.Location = New System.Drawing.Point(258, 35)
        Me.BtnQx.Name = "BtnQx"
        Me.BtnQx.Size = New System.Drawing.Size(75, 23)
        Me.BtnQx.TabIndex = 30
        Me.BtnQx.Text = "全消(&Y)"
        '
        'BtnXs
        '
        Me.BtnXs.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnXs.Location = New System.Drawing.Point(98, 35)
        Me.BtnXs.Name = "BtnXs"
        Me.BtnXs.Size = New System.Drawing.Size(75, 23)
        Me.BtnXs.TabIndex = 28
        Me.BtnXs.Text = "消审(&C)"
        '
        'LblJsfsmc
        '
        Me.LblJsfsmc.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblJsfsmc.AutoSize = True
        Me.LblJsfsmc.Location = New System.Drawing.Point(431, 160)
        Me.LblJsfsmc.Name = "LblJsfsmc"
        Me.LblJsfsmc.Size = New System.Drawing.Size(89, 12)
        Me.LblJsfsmc.TabIndex = 23
        Me.LblJsfsmc.Text = "结算方式名称："
        '
        'LblJsfsdm
        '
        Me.LblJsfsdm.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblJsfsdm.AutoSize = True
        Me.LblJsfsdm.Location = New System.Drawing.Point(254, 160)
        Me.LblJsfsdm.Name = "LblJsfsdm"
        Me.LblJsfsdm.Size = New System.Drawing.Size(65, 12)
        Me.LblJsfsdm.TabIndex = 21
        Me.LblJsfsdm.Text = "结算方式："
        '
        'TxtJsfsdm
        '
        Me.TxtJsfsdm.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtJsfsdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtJsfsdm.Enabled = False
        Me.TxtJsfsdm.Location = New System.Drawing.Point(327, 156)
        Me.TxtJsfsdm.MaxLength = 12
        Me.TxtJsfsdm.Name = "TxtJsfsdm"
        Me.TxtJsfsdm.Size = New System.Drawing.Size(96, 21)
        Me.TxtJsfsdm.TabIndex = 22
        '
        'FrmSkdShz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 406)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStripPanel1)
        Me.Name = "FrmSkdShz"
        Me.Text = "收款单审核"
        Me.ToolStripPanel1.ResumeLayout(False)
        Me.ToolStripPanel1.PerformLayout()
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripPanel1 As System.Windows.Forms.ToolStripPanel
    Friend WithEvents MnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuiFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiSh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiXs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiQs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiQx As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuiPrevious As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiNext As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Mnui12 As System.Windows.Forms.ToolStripSeparator
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
    Public WithEvents LblKhmc As System.Windows.Forms.Label
    Public WithEvents TxtKhdm As System.Windows.Forms.TextBox
    Public WithEvents LblKhdm As System.Windows.Forms.Label
    Public WithEvents LblKmmc As System.Windows.Forms.Label
    Public WithEvents LblSkrq As System.Windows.Forms.Label
    Public WithEvents DtpSkrq As System.Windows.Forms.DateTimePicker
    Public WithEvents TxtDjh As System.Windows.Forms.TextBox
    Public WithEvents LblDjh As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents LblDd As System.Windows.Forms.Label
    Public WithEvents TxtKmdm As System.Windows.Forms.TextBox
    Public WithEvents LblKmdm As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Public WithEvents LblJzr As System.Windows.Forms.Label
    Public WithEvents LblShr As System.Windows.Forms.Label
    Public WithEvents LblSrr As System.Windows.Forms.Label
    Friend WithEvents BtnPrevious As System.Windows.Forms.Button
    Friend WithEvents BtnNext As System.Windows.Forms.Button
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents BtnSh As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents BtnHelp As System.Windows.Forms.Button
    Friend WithEvents BtnQs As System.Windows.Forms.Button
    Friend WithEvents BtnQx As System.Windows.Forms.Button
    Friend WithEvents BtnXs As System.Windows.Forms.Button
    Public WithEvents LblSkmemo As System.Windows.Forms.Label
    Public WithEvents TxtSkmemo As System.Windows.Forms.TextBox
    Public WithEvents TxtJe As System.Windows.Forms.TextBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents TxtYspz As System.Windows.Forms.TextBox
    Public WithEvents LblYspz As System.Windows.Forms.Label
    Friend WithEvents LblJsfsmc As System.Windows.Forms.Label
    Friend WithEvents LblJsfsdm As System.Windows.Forms.Label
    Friend WithEvents TxtJsfsdm As System.Windows.Forms.TextBox
End Class
