<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmYwfDkywSrz
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
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.LblMsg = New System.Windows.Forms.Label
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.BtnExit = New System.Windows.Forms.Button
        Me.BtnNew = New System.Windows.Forms.Button
        Me.BtnHelp = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.MnuMain = New System.Windows.Forms.MenuStrip
        Me.MnuiFile = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiNew = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiSave = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiCancel = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.MnuiPageSetup = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiPrintView = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiPrint = New System.Windows.Forms.ToolStripMenuItem
        Me.Mnui12 = New System.Windows.Forms.ToolStripSeparator
        Me.MnuiExit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiCut = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiCopy = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiPaste = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiHelp = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.rcBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TxtFyje = New System.Windows.Forms.TextBox
        Me.DtpDkrq = New System.Windows.Forms.DateTimePicker
        Me.LblFyje = New System.Windows.Forms.Label
        Me.LblDkrq = New System.Windows.Forms.Label
        Me.LblDjh = New System.Windows.Forms.Label
        Me.TxtDjh = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label8 = New System.Windows.Forms.Label
        Me.LblDkgsmc = New System.Windows.Forms.Label
        Me.TxtDkmemo = New System.Windows.Forms.TextBox
        Me.LblScmemo = New System.Windows.Forms.Label
        Me.LblKhdm = New System.Windows.Forms.Label
        Me.TxtKhdm = New System.Windows.Forms.TextBox
        Me.LblKhmc = New System.Windows.Forms.Label
        Me.LblSkje = New System.Windows.Forms.Label
        Me.TxtSkje = New System.Windows.Forms.TextBox
        Me.LblZydm = New System.Windows.Forms.Label
        Me.TxtDkgsdm = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.rcPrintDocument = New System.Drawing.Printing.PrintDocument
        Me.Panel3.SuspendLayout()
        Me.MnuMain.SuspendLayout()
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.LblMsg)
        Me.Panel3.Controls.Add(Me.BtnCancel)
        Me.Panel3.Controls.Add(Me.BtnExit)
        Me.Panel3.Controls.Add(Me.BtnNew)
        Me.Panel3.Controls.Add(Me.BtnHelp)
        Me.Panel3.Controls.Add(Me.BtnSave)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 661)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1008, 68)
        Me.Panel3.TabIndex = 1
        '
        'LblMsg
        '
        Me.LblMsg.AutoSize = True
        Me.LblMsg.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblMsg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblMsg.Location = New System.Drawing.Point(12, 26)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(184, 16)
        Me.LblMsg.TabIndex = 13
        Me.LblMsg.Text = "此处显示的是提示信息。"
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnCancel.Enabled = False
        Me.BtnCancel.Location = New System.Drawing.Point(539, 23)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(64, 23)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "取消(&C)"
        '
        'BtnExit
        '
        Me.BtnExit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnExit.Location = New System.Drawing.Point(667, 23)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(64, 23)
        Me.BtnExit.TabIndex = 10
        Me.BtnExit.Text = "退出(&X)"
        '
        'BtnNew
        '
        Me.BtnNew.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnNew.Location = New System.Drawing.Point(411, 23)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(64, 23)
        Me.BtnNew.TabIndex = 2
        Me.BtnNew.Text = "新单(&A)"
        '
        'BtnHelp
        '
        Me.BtnHelp.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnHelp.Location = New System.Drawing.Point(603, 23)
        Me.BtnHelp.Name = "BtnHelp"
        Me.BtnHelp.Size = New System.Drawing.Size(64, 23)
        Me.BtnHelp.TabIndex = 9
        Me.BtnHelp.Text = "帮助(&H)"
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnSave.Enabled = False
        Me.BtnSave.Location = New System.Drawing.Point(475, 23)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(64, 23)
        Me.BtnSave.TabIndex = 3
        Me.BtnSave.Text = "保存(&S)"
        '
        'MnuMain
        '
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiFile, Me.MnuiEdit, Me.MnuiHelp})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(1008, 25)
        Me.MnuMain.TabIndex = 1
        '
        'MnuiFile
        '
        Me.MnuiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiNew, Me.MnuiSave, Me.MnuiCancel, Me.ToolStripMenuItem1, Me.MnuiPageSetup, Me.MnuiPrintView, Me.MnuiPrint, Me.Mnui12, Me.MnuiExit})
        Me.MnuiFile.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiFile.Name = "MnuiFile"
        Me.MnuiFile.Size = New System.Drawing.Size(58, 21)
        Me.MnuiFile.Text = "文件(&F)"
        '
        'MnuiNew
        '
        Me.MnuiNew.Name = "MnuiNew"
        Me.MnuiNew.Size = New System.Drawing.Size(166, 22)
        Me.MnuiNew.Text = "新单(&A)"
        '
        'MnuiSave
        '
        Me.MnuiSave.Enabled = False
        Me.MnuiSave.Name = "MnuiSave"
        Me.MnuiSave.Size = New System.Drawing.Size(166, 22)
        Me.MnuiSave.Text = "保存(&S)"
        '
        'MnuiCancel
        '
        Me.MnuiCancel.Enabled = False
        Me.MnuiCancel.Name = "MnuiCancel"
        Me.MnuiCancel.Size = New System.Drawing.Size(166, 22)
        Me.MnuiCancel.Text = "取消(&C)"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(163, 6)
        '
        'MnuiPageSetup
        '
        Me.MnuiPageSetup.Name = "MnuiPageSetup"
        Me.MnuiPageSetup.Size = New System.Drawing.Size(166, 22)
        Me.MnuiPageSetup.Text = "页面设置(&U)"
        '
        'MnuiPrintView
        '
        Me.MnuiPrintView.Name = "MnuiPrintView"
        Me.MnuiPrintView.Size = New System.Drawing.Size(166, 22)
        Me.MnuiPrintView.Text = "打印预览(&V)"
        '
        'MnuiPrint
        '
        Me.MnuiPrint.Name = "MnuiPrint"
        Me.MnuiPrint.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.MnuiPrint.Size = New System.Drawing.Size(166, 22)
        Me.MnuiPrint.Text = "打印(&P)"
        '
        'Mnui12
        '
        Me.Mnui12.Name = "Mnui12"
        Me.Mnui12.Size = New System.Drawing.Size(163, 6)
        '
        'MnuiExit
        '
        Me.MnuiExit.Name = "MnuiExit"
        Me.MnuiExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.MnuiExit.Size = New System.Drawing.Size(166, 22)
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
        'TxtFyje
        '
        Me.TxtFyje.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtFyje.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFyje.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtFyje.Location = New System.Drawing.Point(389, 235)
        Me.TxtFyje.Name = "TxtFyje"
        Me.TxtFyje.Size = New System.Drawing.Size(110, 26)
        Me.TxtFyje.TabIndex = 13
        '
        'DtpDkrq
        '
        Me.DtpDkrq.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.DtpDkrq.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.DtpDkrq.Location = New System.Drawing.Point(389, 99)
        Me.DtpDkrq.Name = "DtpDkrq"
        Me.DtpDkrq.Size = New System.Drawing.Size(154, 26)
        Me.DtpDkrq.TabIndex = 3
        Me.DtpDkrq.TabStop = False
        '
        'LblFyje
        '
        Me.LblFyje.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblFyje.AutoSize = True
        Me.LblFyje.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblFyje.Location = New System.Drawing.Point(293, 240)
        Me.LblFyje.Name = "LblFyje"
        Me.LblFyje.Size = New System.Drawing.Size(88, 16)
        Me.LblFyje.TabIndex = 12
        Me.LblFyje.Text = "费用金额："
        '
        'LblDkrq
        '
        Me.LblDkrq.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblDkrq.AutoSize = True
        Me.LblDkrq.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblDkrq.Location = New System.Drawing.Point(293, 104)
        Me.LblDkrq.Name = "LblDkrq"
        Me.LblDkrq.Size = New System.Drawing.Size(88, 16)
        Me.LblDkrq.TabIndex = 2
        Me.LblDkrq.Text = "抵扣日期："
        '
        'LblDjh
        '
        Me.LblDjh.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblDjh.AutoSize = True
        Me.LblDjh.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblDjh.Location = New System.Drawing.Point(293, 70)
        Me.LblDjh.Name = "LblDjh"
        Me.LblDjh.Size = New System.Drawing.Size(88, 16)
        Me.LblDjh.TabIndex = 0
        Me.LblDjh.Text = "单 据 号："
        '
        'TxtDjh
        '
        Me.TxtDjh.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtDjh.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtDjh.Location = New System.Drawing.Point(389, 65)
        Me.TxtDjh.MaxLength = 5
        Me.TxtDjh.Name = "TxtDjh"
        Me.TxtDjh.Size = New System.Drawing.Size(110, 26)
        Me.TxtDjh.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1008, 46)
        Me.Panel1.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("楷体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label8.Location = New System.Drawing.Point(412, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(185, 24)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "业务费抵扣业务"
        '
        'LblDkgsmc
        '
        Me.LblDkgsmc.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblDkgsmc.AutoSize = True
        Me.LblDkgsmc.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblDkgsmc.Location = New System.Drawing.Point(507, 172)
        Me.LblDkgsmc.Name = "LblDkgsmc"
        Me.LblDkgsmc.Size = New System.Drawing.Size(104, 16)
        Me.LblDkgsmc.TabIndex = 9
        Me.LblDkgsmc.Text = "抵扣规则名称"
        '
        'TxtDkmemo
        '
        Me.TxtDkmemo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtDkmemo.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtDkmemo.Location = New System.Drawing.Point(389, 269)
        Me.TxtDkmemo.Name = "TxtDkmemo"
        Me.TxtDkmemo.Size = New System.Drawing.Size(165, 26)
        Me.TxtDkmemo.TabIndex = 15
        '
        'LblScmemo
        '
        Me.LblScmemo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblScmemo.AutoSize = True
        Me.LblScmemo.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblScmemo.Location = New System.Drawing.Point(293, 274)
        Me.LblScmemo.Name = "LblScmemo"
        Me.LblScmemo.Size = New System.Drawing.Size(88, 16)
        Me.LblScmemo.TabIndex = 14
        Me.LblScmemo.Text = "备    注："
        '
        'LblKhdm
        '
        Me.LblKhdm.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblKhdm.AutoSize = True
        Me.LblKhdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblKhdm.Location = New System.Drawing.Point(293, 138)
        Me.LblKhdm.Name = "LblKhdm"
        Me.LblKhdm.Size = New System.Drawing.Size(88, 16)
        Me.LblKhdm.TabIndex = 4
        Me.LblKhdm.Text = "客户编码："
        '
        'TxtKhdm
        '
        Me.TxtKhdm.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtKhdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtKhdm.Location = New System.Drawing.Point(389, 133)
        Me.TxtKhdm.Name = "TxtKhdm"
        Me.TxtKhdm.Size = New System.Drawing.Size(110, 26)
        Me.TxtKhdm.TabIndex = 5
        '
        'LblKhmc
        '
        Me.LblKhmc.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblKhmc.AutoSize = True
        Me.LblKhmc.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblKhmc.Location = New System.Drawing.Point(507, 138)
        Me.LblKhmc.Name = "LblKhmc"
        Me.LblKhmc.Size = New System.Drawing.Size(72, 16)
        Me.LblKhmc.TabIndex = 6
        Me.LblKhmc.Text = "客户名称"
        '
        'LblSkje
        '
        Me.LblSkje.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblSkje.AutoSize = True
        Me.LblSkje.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblSkje.Location = New System.Drawing.Point(261, 206)
        Me.LblSkje.Name = "LblSkje"
        Me.LblSkje.Size = New System.Drawing.Size(120, 16)
        Me.LblSkje.TabIndex = 10
        Me.LblSkje.Text = "客户收款金额："
        '
        'TxtSkje
        '
        Me.TxtSkje.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtSkje.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtSkje.Location = New System.Drawing.Point(389, 201)
        Me.TxtSkje.MaxLength = 20
        Me.TxtSkje.Name = "TxtSkje"
        Me.TxtSkje.Size = New System.Drawing.Size(110, 26)
        Me.TxtSkje.TabIndex = 11
        '
        'LblZydm
        '
        Me.LblZydm.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblZydm.AutoSize = True
        Me.LblZydm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblZydm.Location = New System.Drawing.Point(261, 172)
        Me.LblZydm.Name = "LblZydm"
        Me.LblZydm.Size = New System.Drawing.Size(120, 16)
        Me.LblZydm.TabIndex = 7
        Me.LblZydm.Text = "抵扣规则编码："
        '
        'TxtDkgsdm
        '
        Me.TxtDkgsdm.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtDkgsdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDkgsdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtDkgsdm.Location = New System.Drawing.Point(389, 167)
        Me.TxtDkgsdm.Name = "TxtDkgsdm"
        Me.TxtDkgsdm.Size = New System.Drawing.Size(110, 26)
        Me.TxtDkgsdm.TabIndex = 8
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FloralWhite
        Me.Panel2.Controls.Add(Me.TxtDkgsdm)
        Me.Panel2.Controls.Add(Me.LblZydm)
        Me.Panel2.Controls.Add(Me.TxtSkje)
        Me.Panel2.Controls.Add(Me.LblSkje)
        Me.Panel2.Controls.Add(Me.LblKhmc)
        Me.Panel2.Controls.Add(Me.TxtKhdm)
        Me.Panel2.Controls.Add(Me.LblKhdm)
        Me.Panel2.Controls.Add(Me.LblScmemo)
        Me.Panel2.Controls.Add(Me.TxtDkmemo)
        Me.Panel2.Controls.Add(Me.LblDkgsmc)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.TxtDjh)
        Me.Panel2.Controls.Add(Me.LblDjh)
        Me.Panel2.Controls.Add(Me.LblDkrq)
        Me.Panel2.Controls.Add(Me.LblFyje)
        Me.Panel2.Controls.Add(Me.DtpDkrq)
        Me.Panel2.Controls.Add(Me.TxtFyje)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 25)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1008, 636)
        Me.Panel2.TabIndex = 0
        '
        'rcPrintDocument
        '
        Me.rcPrintDocument.DocumentName = "Richen Print System"
        '
        'FrmYwfDkywSrz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.MnuMain)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "FrmYwfDkywSrz"
        Me.Text = "业务费抵扣业务输入与修改"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents MnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuiFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuiPageSetup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiPrintView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Mnui12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuiExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiCut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiPaste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents BtnHelp As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents rcBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TxtFyje As System.Windows.Forms.TextBox
    Friend WithEvents DtpDkrq As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblFyje As System.Windows.Forms.Label
    Friend WithEvents LblDkrq As System.Windows.Forms.Label
    Friend WithEvents LblDjh As System.Windows.Forms.Label
    Friend WithEvents TxtDjh As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents LblDkgsmc As System.Windows.Forms.Label
    Friend WithEvents TxtDkmemo As System.Windows.Forms.TextBox
    Friend WithEvents LblScmemo As System.Windows.Forms.Label
    Friend WithEvents LblKhdm As System.Windows.Forms.Label
    Friend WithEvents TxtKhdm As System.Windows.Forms.TextBox
    Friend WithEvents LblKhmc As System.Windows.Forms.Label
    Friend WithEvents LblSkje As System.Windows.Forms.Label
    Friend WithEvents TxtSkje As System.Windows.Forms.TextBox
    Friend WithEvents LblZydm As System.Windows.Forms.Label
    Friend WithEvents TxtDkgsdm As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rcPrintDocument As System.Drawing.Printing.PrintDocument
    Public WithEvents LblMsg As System.Windows.Forms.Label
End Class
