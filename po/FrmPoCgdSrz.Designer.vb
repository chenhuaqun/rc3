<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPoCgdSrz
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
        Me.MnuMain = New System.Windows.Forms.MenuStrip
        Me.MnuiFile = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiNew = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiSave = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiCancel = New System.Windows.Forms.ToolStripMenuItem
        Me.Mnui11 = New System.Windows.Forms.ToolStripSeparator
        Me.MnuiIns = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiDelete = New System.Windows.Forms.ToolStripMenuItem
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
        Me.ToolStripPanel1 = New System.Windows.Forms.ToolStripPanel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TxtSgddh = New System.Windows.Forms.TextBox
        Me.LblSgddh = New System.Windows.Forms.Label
        Me.LblCsmc = New System.Windows.Forms.Label
        Me.TxtCsdm = New System.Windows.Forms.TextBox
        Me.LblCsdm = New System.Windows.Forms.Label
        Me.CmbPzlxjc = New System.Windows.Forms.ComboBox
        Me.LblCgrq = New System.Windows.Forms.Label
        Me.DtpCgrq = New System.Windows.Forms.DateTimePicker
        Me.TxtDjh = New System.Windows.Forms.TextBox
        Me.LblDjh = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.LblCgd = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.BtnImpDd = New System.Windows.Forms.Button
        Me.BtnImp = New System.Windows.Forms.Button
        Me.BtnIns = New System.Windows.Forms.Button
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.LblJese = New System.Windows.Forms.Label
        Me.LblSe = New System.Windows.Forms.Label
        Me.LblFzsl = New System.Windows.Forms.Label
        Me.LblMsg = New System.Windows.Forms.Label
        Me.LblJe = New System.Windows.Forms.Label
        Me.LblSl = New System.Windows.Forms.Label
        Me.BtnDelete = New System.Windows.Forms.Button
        Me.BtnExit = New System.Windows.Forms.Button
        Me.BtnNew = New System.Windows.Forms.Button
        Me.BtnHelp = New System.Windows.Forms.Button
        Me.BtnPrint = New System.Windows.Forms.Button
        Me.BtnPrintView = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.rcDataGridView = New System.Windows.Forms.DataGridView
        Me.ColCpdm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCpmc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColOldCpdm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColJhshrq = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColSl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColDw = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColMjsl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColFzsl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColFzdw = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColDj = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColHsdj = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColJe = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColShlv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColSe = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColJese = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCgmemo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCgjhDjh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCgjhXh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.rcBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MnuMain.SuspendLayout()
        Me.ToolStripPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MnuMain
        '
        Me.MnuMain.Dock = System.Windows.Forms.DockStyle.None
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiFile, Me.MnuiEdit, Me.MnuiHelp})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(1008, 25)
        Me.MnuMain.TabIndex = 1
        '
        'MnuiFile
        '
        Me.MnuiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiNew, Me.MnuiSave, Me.MnuiCancel, Me.Mnui11, Me.MnuiIns, Me.MnuiDelete, Me.Mnui12, Me.MnuiPageSetup, Me.MnuiPrintView, Me.MnuiPrint, Me.Mnui13, Me.MnuiExit})
        Me.MnuiFile.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiFile.Name = "MnuiFile"
        Me.MnuiFile.Size = New System.Drawing.Size(58, 21)
        Me.MnuiFile.Text = "文件(&F)"
        '
        'MnuiNew
        '
        Me.MnuiNew.Name = "MnuiNew"
        Me.MnuiNew.Size = New System.Drawing.Size(141, 22)
        Me.MnuiNew.Text = "新单(&A)"
        '
        'MnuiSave
        '
        Me.MnuiSave.Enabled = False
        Me.MnuiSave.Name = "MnuiSave"
        Me.MnuiSave.Size = New System.Drawing.Size(141, 22)
        Me.MnuiSave.Text = "保存(&S)"
        '
        'MnuiCancel
        '
        Me.MnuiCancel.Enabled = False
        Me.MnuiCancel.Name = "MnuiCancel"
        Me.MnuiCancel.Size = New System.Drawing.Size(141, 22)
        Me.MnuiCancel.Text = "取消(&C)"
        '
        'Mnui11
        '
        Me.Mnui11.Name = "Mnui11"
        Me.Mnui11.Size = New System.Drawing.Size(138, 6)
        '
        'MnuiIns
        '
        Me.MnuiIns.Name = "MnuiIns"
        Me.MnuiIns.Size = New System.Drawing.Size(141, 22)
        Me.MnuiIns.Text = "插入行(&I)"
        '
        'MnuiDelete
        '
        Me.MnuiDelete.Name = "MnuiDelete"
        Me.MnuiDelete.Size = New System.Drawing.Size(141, 22)
        Me.MnuiDelete.Text = "删除行(&D)"
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
        'ToolStripPanel1
        '
        Me.ToolStripPanel1.Controls.Add(Me.MnuMain)
        Me.ToolStripPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ToolStripPanel1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripPanel1.Name = "ToolStripPanel1"
        Me.ToolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.ToolStripPanel1.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ToolStripPanel1.Size = New System.Drawing.Size(1008, 25)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FloralWhite
        Me.Panel1.Controls.Add(Me.TxtSgddh)
        Me.Panel1.Controls.Add(Me.LblSgddh)
        Me.Panel1.Controls.Add(Me.LblCsmc)
        Me.Panel1.Controls.Add(Me.TxtCsdm)
        Me.Panel1.Controls.Add(Me.LblCsdm)
        Me.Panel1.Controls.Add(Me.CmbPzlxjc)
        Me.Panel1.Controls.Add(Me.LblCgrq)
        Me.Panel1.Controls.Add(Me.DtpCgrq)
        Me.Panel1.Controls.Add(Me.TxtDjh)
        Me.Panel1.Controls.Add(Me.LblDjh)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1008, 120)
        Me.Panel1.TabIndex = 0
        '
        'TxtSgddh
        '
        Me.TxtSgddh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSgddh.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSgddh.Location = New System.Drawing.Point(815, 58)
        Me.TxtSgddh.MaxLength = 20
        Me.TxtSgddh.Name = "TxtSgddh"
        Me.TxtSgddh.Size = New System.Drawing.Size(170, 21)
        Me.TxtSgddh.TabIndex = 10
        '
        'LblSgddh
        '
        Me.LblSgddh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSgddh.AutoSize = True
        Me.LblSgddh.Location = New System.Drawing.Point(730, 62)
        Me.LblSgddh.Name = "LblSgddh"
        Me.LblSgddh.Size = New System.Drawing.Size(77, 12)
        Me.LblSgddh.TabIndex = 9
        Me.LblSgddh.Text = "手工订单号："
        '
        'LblCsmc
        '
        Me.LblCsmc.AutoSize = True
        Me.LblCsmc.Location = New System.Drawing.Point(184, 90)
        Me.LblCsmc.Name = "LblCsmc"
        Me.LblCsmc.Size = New System.Drawing.Size(0, 12)
        Me.LblCsmc.TabIndex = 8
        '
        'TxtCsdm
        '
        Me.TxtCsdm.Location = New System.Drawing.Point(88, 86)
        Me.TxtCsdm.MaxLength = 12
        Me.TxtCsdm.Name = "TxtCsdm"
        Me.TxtCsdm.Size = New System.Drawing.Size(87, 21)
        Me.TxtCsdm.TabIndex = 7
        '
        'LblCsdm
        '
        Me.LblCsdm.AutoSize = True
        Me.LblCsdm.Location = New System.Drawing.Point(16, 90)
        Me.LblCsdm.Name = "LblCsdm"
        Me.LblCsdm.Size = New System.Drawing.Size(77, 12)
        Me.LblCsdm.TabIndex = 6
        Me.LblCsdm.Text = "供应商编码："
        '
        'CmbPzlxjc
        '
        Me.CmbPzlxjc.Location = New System.Drawing.Point(88, 58)
        Me.CmbPzlxjc.Name = "CmbPzlxjc"
        Me.CmbPzlxjc.Size = New System.Drawing.Size(72, 20)
        Me.CmbPzlxjc.TabIndex = 2
        '
        'LblCgrq
        '
        Me.LblCgrq.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblCgrq.AutoSize = True
        Me.LblCgrq.Location = New System.Drawing.Point(387, 62)
        Me.LblCgrq.Name = "LblCgrq"
        Me.LblCgrq.Size = New System.Drawing.Size(65, 12)
        Me.LblCgrq.TabIndex = 4
        Me.LblCgrq.Text = "采购日期："
        '
        'DtpCgrq
        '
        Me.DtpCgrq.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.DtpCgrq.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpCgrq.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpCgrq.Location = New System.Drawing.Point(459, 58)
        Me.DtpCgrq.Name = "DtpCgrq"
        Me.DtpCgrq.Size = New System.Drawing.Size(162, 21)
        Me.DtpCgrq.TabIndex = 5
        '
        'TxtDjh
        '
        Me.TxtDjh.Location = New System.Drawing.Point(160, 58)
        Me.TxtDjh.MaxLength = 15
        Me.TxtDjh.Name = "TxtDjh"
        Me.TxtDjh.Size = New System.Drawing.Size(104, 21)
        Me.TxtDjh.TabIndex = 3
        '
        'LblDjh
        '
        Me.LblDjh.AutoSize = True
        Me.LblDjh.Location = New System.Drawing.Point(16, 62)
        Me.LblDjh.Name = "LblDjh"
        Me.LblDjh.Size = New System.Drawing.Size(65, 12)
        Me.LblDjh.TabIndex = 1
        Me.LblDjh.Text = "单 据 号："
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.LblCgd)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1008, 48)
        Me.Panel3.TabIndex = 0
        '
        'LblCgd
        '
        Me.LblCgd.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblCgd.AutoSize = True
        Me.LblCgd.Font = New System.Drawing.Font("华文行楷", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblCgd.ForeColor = System.Drawing.Color.SteelBlue
        Me.LblCgd.Location = New System.Drawing.Point(423, 9)
        Me.LblCgd.Name = "LblCgd"
        Me.LblCgd.Size = New System.Drawing.Size(162, 25)
        Me.LblCgd.TabIndex = 0
        Me.LblCgd.Text = "物料采购订单"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtnImpDd)
        Me.Panel2.Controls.Add(Me.BtnImp)
        Me.Panel2.Controls.Add(Me.BtnIns)
        Me.Panel2.Controls.Add(Me.BtnCancel)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.BtnDelete)
        Me.Panel2.Controls.Add(Me.BtnExit)
        Me.Panel2.Controls.Add(Me.BtnNew)
        Me.Panel2.Controls.Add(Me.BtnHelp)
        Me.Panel2.Controls.Add(Me.BtnPrint)
        Me.Panel2.Controls.Add(Me.BtnPrintView)
        Me.Panel2.Controls.Add(Me.BtnSave)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 398)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1008, 99)
        Me.Panel2.TabIndex = 2
        '
        'BtnImpDd
        '
        Me.BtnImpDd.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnImpDd.Location = New System.Drawing.Point(188, 58)
        Me.BtnImpDd.Name = "BtnImpDd"
        Me.BtnImpDd.Size = New System.Drawing.Size(98, 23)
        Me.BtnImpDd.TabIndex = 11
        Me.BtnImpDd.Text = "导入销售订单"
        '
        'BtnImp
        '
        Me.BtnImp.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnImp.Location = New System.Drawing.Point(90, 58)
        Me.BtnImp.Name = "BtnImp"
        Me.BtnImp.Size = New System.Drawing.Size(98, 23)
        Me.BtnImp.TabIndex = 10
        Me.BtnImp.Text = "导入采购需求单"
        '
        'BtnIns
        '
        Me.BtnIns.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnIns.Location = New System.Drawing.Point(511, 58)
        Me.BtnIns.Name = "BtnIns"
        Me.BtnIns.Size = New System.Drawing.Size(75, 23)
        Me.BtnIns.TabIndex = 3
        Me.BtnIns.Text = "插入行(&I)"
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnCancel.Enabled = False
        Me.BtnCancel.Location = New System.Drawing.Point(436, 58)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 2
        Me.BtnCancel.Text = "取消(&C)"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.LblJese)
        Me.Panel4.Controls.Add(Me.LblSe)
        Me.Panel4.Controls.Add(Me.LblFzsl)
        Me.Panel4.Controls.Add(Me.LblMsg)
        Me.Panel4.Controls.Add(Me.LblJe)
        Me.Panel4.Controls.Add(Me.LblSl)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1008, 43)
        Me.Panel4.TabIndex = 0
        '
        'LblJese
        '
        Me.LblJese.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblJese.AutoSize = True
        Me.LblJese.Location = New System.Drawing.Point(838, 17)
        Me.LblJese.Name = "LblJese"
        Me.LblJese.Size = New System.Drawing.Size(65, 12)
        Me.LblJese.TabIndex = 15
        Me.LblJese.Text = "价税合计："
        '
        'LblSe
        '
        Me.LblSe.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSe.AutoSize = True
        Me.LblSe.Location = New System.Drawing.Point(674, 17)
        Me.LblSe.Name = "LblSe"
        Me.LblSe.Size = New System.Drawing.Size(65, 12)
        Me.LblSe.TabIndex = 14
        Me.LblSe.Text = "税额合计："
        '
        'LblFzsl
        '
        Me.LblFzsl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblFzsl.AutoSize = True
        Me.LblFzsl.Location = New System.Drawing.Point(334, 17)
        Me.LblFzsl.Name = "LblFzsl"
        Me.LblFzsl.Size = New System.Drawing.Size(77, 12)
        Me.LblFzsl.TabIndex = 13
        Me.LblFzsl.Text = "辅数量合计："
        '
        'LblMsg
        '
        Me.LblMsg.AutoSize = True
        Me.LblMsg.ForeColor = System.Drawing.Color.SteelBlue
        Me.LblMsg.Location = New System.Drawing.Point(16, 5)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(65, 12)
        Me.LblMsg.TabIndex = 12
        Me.LblMsg.Text = "提示信息。"
        '
        'LblJe
        '
        Me.LblJe.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblJe.AutoSize = True
        Me.LblJe.Location = New System.Drawing.Point(510, 17)
        Me.LblJe.Name = "LblJe"
        Me.LblJe.Size = New System.Drawing.Size(65, 12)
        Me.LblJe.TabIndex = 11
        Me.LblJe.Text = "金额合计："
        '
        'LblSl
        '
        Me.LblSl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSl.AutoSize = True
        Me.LblSl.Location = New System.Drawing.Point(170, 17)
        Me.LblSl.Name = "LblSl"
        Me.LblSl.Size = New System.Drawing.Size(65, 12)
        Me.LblSl.TabIndex = 10
        Me.LblSl.Text = "数量合计："
        '
        'BtnDelete
        '
        Me.BtnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnDelete.Location = New System.Drawing.Point(586, 58)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(75, 23)
        Me.BtnDelete.TabIndex = 4
        Me.BtnDelete.Text = "删除行(&D)"
        '
        'BtnExit
        '
        Me.BtnExit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnExit.Location = New System.Drawing.Point(886, 58)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 23)
        Me.BtnExit.TabIndex = 8
        Me.BtnExit.Text = "退出(&X)"
        '
        'BtnNew
        '
        Me.BtnNew.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnNew.Location = New System.Drawing.Point(286, 58)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(75, 23)
        Me.BtnNew.TabIndex = 0
        Me.BtnNew.Text = "新单(&A)"
        '
        'BtnHelp
        '
        Me.BtnHelp.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnHelp.Location = New System.Drawing.Point(811, 58)
        Me.BtnHelp.Name = "BtnHelp"
        Me.BtnHelp.Size = New System.Drawing.Size(75, 23)
        Me.BtnHelp.TabIndex = 7
        Me.BtnHelp.Text = "帮助(&H)"
        '
        'BtnPrint
        '
        Me.BtnPrint.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnPrint.Location = New System.Drawing.Point(661, 58)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrint.TabIndex = 5
        Me.BtnPrint.Text = "打印(&P)"
        '
        'BtnPrintView
        '
        Me.BtnPrintView.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnPrintView.Location = New System.Drawing.Point(736, 58)
        Me.BtnPrintView.Name = "BtnPrintView"
        Me.BtnPrintView.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrintView.TabIndex = 6
        Me.BtnPrintView.Text = "预览(&V)"
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnSave.Enabled = False
        Me.BtnSave.Location = New System.Drawing.Point(361, 58)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 1
        Me.BtnSave.Text = "保存(&S)"
        '
        'rcDataGridView
        '
        Me.rcDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.rcDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColCpdm, Me.ColCpmc, Me.ColOldCpdm, Me.ColJhshrq, Me.ColSl, Me.ColDw, Me.ColMjsl, Me.ColFzsl, Me.ColFzdw, Me.ColDj, Me.ColHsdj, Me.ColJe, Me.ColShlv, Me.ColSe, Me.ColJese, Me.ColCgmemo, Me.ColCgjhDjh, Me.ColCgjhXh})
        Me.rcDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rcDataGridView.Location = New System.Drawing.Point(0, 145)
        Me.rcDataGridView.Name = "rcDataGridView"
        Me.rcDataGridView.RowTemplate.Height = 23
        Me.rcDataGridView.Size = New System.Drawing.Size(1008, 253)
        Me.rcDataGridView.TabIndex = 1
        '
        'ColCpdm
        '
        Me.ColCpdm.DataPropertyName = "cpdm"
        Me.ColCpdm.Frozen = True
        Me.ColCpdm.HeaderText = "物料编码"
        Me.ColCpdm.MaxInputLength = 15
        Me.ColCpdm.Name = "ColCpdm"
        Me.ColCpdm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColCpdm.Width = 110
        '
        'ColCpmc
        '
        Me.ColCpmc.DataPropertyName = "cpmc"
        Me.ColCpmc.Frozen = True
        Me.ColCpmc.HeaderText = "物料名称"
        Me.ColCpmc.MaxInputLength = 200
        Me.ColCpmc.Name = "ColCpmc"
        Me.ColCpmc.ReadOnly = True
        Me.ColCpmc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColCpmc.Width = 240
        '
        'ColOldCpdm
        '
        Me.ColOldCpdm.DataPropertyName = "oldcpdm"
        Me.ColOldCpdm.HeaderText = "旧物料编码"
        Me.ColOldCpdm.MaxInputLength = 15
        Me.ColOldCpdm.Name = "ColOldCpdm"
        Me.ColOldCpdm.ReadOnly = True
        Me.ColOldCpdm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColOldCpdm.Width = 90
        '
        'ColJhshrq
        '
        Me.ColJhshrq.DataPropertyName = "jhshrq"
        Me.ColJhshrq.HeaderText = "计划收货日期"
        Me.ColJhshrq.Name = "ColJhshrq"
        Me.ColJhshrq.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColSl
        '
        Me.ColSl.DataPropertyName = "sl"
        Me.ColSl.HeaderText = "订货数量"
        Me.ColSl.MaxInputLength = 18
        Me.ColSl.Name = "ColSl"
        Me.ColSl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColSl.Width = 90
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
        'ColMjsl
        '
        Me.ColMjsl.DataPropertyName = "mjsl"
        Me.ColMjsl.HeaderText = "换算系数"
        Me.ColMjsl.MaxInputLength = 18
        Me.ColMjsl.Name = "ColMjsl"
        Me.ColMjsl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColFzsl
        '
        Me.ColFzsl.DataPropertyName = "fzsl"
        Me.ColFzsl.HeaderText = "辅数量"
        Me.ColFzsl.MaxInputLength = 18
        Me.ColFzsl.Name = "ColFzsl"
        Me.ColFzsl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColFzdw
        '
        Me.ColFzdw.DataPropertyName = "fzdw"
        Me.ColFzdw.HeaderText = "辅单位"
        Me.ColFzdw.MaxInputLength = 8
        Me.ColFzdw.Name = "ColFzdw"
        Me.ColFzdw.ReadOnly = True
        Me.ColFzdw.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColFzdw.Width = 45
        '
        'ColDj
        '
        Me.ColDj.DataPropertyName = "dj"
        Me.ColDj.HeaderText = "不含税单价"
        Me.ColDj.MaxInputLength = 18
        Me.ColDj.Name = "ColDj"
        Me.ColDj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColDj.Width = 90
        '
        'ColHsdj
        '
        Me.ColHsdj.DataPropertyName = "hsdj"
        Me.ColHsdj.HeaderText = "含税单价"
        Me.ColHsdj.MaxInputLength = 18
        Me.ColHsdj.Name = "ColHsdj"
        Me.ColHsdj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColHsdj.Width = 90
        '
        'ColJe
        '
        Me.ColJe.DataPropertyName = "je"
        Me.ColJe.HeaderText = "金额"
        Me.ColJe.MaxInputLength = 14
        Me.ColJe.Name = "ColJe"
        Me.ColJe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColJe.Width = 90
        '
        'ColShlv
        '
        Me.ColShlv.DataPropertyName = "shlv"
        Me.ColShlv.HeaderText = "税率"
        Me.ColShlv.MaxInputLength = 6
        Me.ColShlv.Name = "ColShlv"
        Me.ColShlv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColShlv.Width = 90
        '
        'ColSe
        '
        Me.ColSe.DataPropertyName = "se"
        Me.ColSe.HeaderText = "税额"
        Me.ColSe.MaxInputLength = 14
        Me.ColSe.Name = "ColSe"
        Me.ColSe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColSe.Width = 90
        '
        'ColJese
        '
        Me.ColJese.DataPropertyName = "jese"
        Me.ColJese.HeaderText = "价税合计"
        Me.ColJese.MaxInputLength = 14
        Me.ColJese.Name = "ColJese"
        Me.ColJese.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColJese.Width = 90
        '
        'ColCgmemo
        '
        Me.ColCgmemo.DataPropertyName = "cgmemo"
        Me.ColCgmemo.HeaderText = "备注"
        Me.ColCgmemo.MaxInputLength = 50
        Me.ColCgmemo.Name = "ColCgmemo"
        Me.ColCgmemo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColCgmemo.Width = 135
        '
        'ColCgjhDjh
        '
        Me.ColCgjhDjh.DataPropertyName = "cgjhdjh"
        Me.ColCgjhDjh.HeaderText = "需求单单据号"
        Me.ColCgjhDjh.MaxInputLength = 15
        Me.ColCgjhDjh.Name = "ColCgjhDjh"
        Me.ColCgjhDjh.ReadOnly = True
        Me.ColCgjhDjh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColCgjhDjh.Width = 110
        '
        'ColCgjhXh
        '
        Me.ColCgjhXh.DataPropertyName = "cgjhxh"
        Me.ColCgjhXh.HeaderText = "需求单行号"
        Me.ColCgjhXh.MaxInputLength = 4
        Me.ColCgjhXh.Name = "ColCgjhXh"
        Me.ColCgjhXh.ReadOnly = True
        Me.ColCgjhXh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColCgjhXh.Width = 60
        '
        'FrmPoCgdSrz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 497)
        Me.Controls.Add(Me.rcDataGridView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStripPanel1)
        Me.Name = "FrmPoCgdSrz"
        Me.Text = "物料采购订单输入"
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.ToolStripPanel1.ResumeLayout(False)
        Me.ToolStripPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuiFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Mnui11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuiIns As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiDelete As System.Windows.Forms.ToolStripMenuItem
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
    Friend WithEvents ToolStripPanel1 As System.Windows.Forms.ToolStripPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CmbPzlxjc As System.Windows.Forms.ComboBox
    Public WithEvents LblCgrq As System.Windows.Forms.Label
    Public WithEvents DtpCgrq As System.Windows.Forms.DateTimePicker
    Public WithEvents TxtDjh As System.Windows.Forms.TextBox
    Public WithEvents LblDjh As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents LblCgd As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnIns As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Public WithEvents LblSl As System.Windows.Forms.Label
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents BtnHelp As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents BtnPrintView As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents rcDataGridView As System.Windows.Forms.DataGridView
    Public WithEvents LblJe As System.Windows.Forms.Label
    Friend WithEvents rcBindingSource As System.Windows.Forms.BindingSource
    Public WithEvents LblMsg As System.Windows.Forms.Label
    Public WithEvents LblFzsl As System.Windows.Forms.Label
    Friend WithEvents BtnImp As System.Windows.Forms.Button
    Public WithEvents LblJese As System.Windows.Forms.Label
    Public WithEvents LblSe As System.Windows.Forms.Label
    Public WithEvents LblCsmc As System.Windows.Forms.Label
    Public WithEvents TxtCsdm As System.Windows.Forms.TextBox
    Public WithEvents LblCsdm As System.Windows.Forms.Label
    Friend WithEvents ColCpdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCpmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOldCpdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJhshrq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDw As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMjsl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFzsl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFzdw As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColHsdj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColShlv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJese As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCgmemo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCgjhDjh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCgjhXh As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents TxtSgddh As System.Windows.Forms.TextBox
    Public WithEvents LblSgddh As System.Windows.Forms.Label
    Friend WithEvents BtnImpDd As System.Windows.Forms.Button
End Class
