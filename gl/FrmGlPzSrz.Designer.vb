<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGlPzSrz
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
        Me.components = New System.ComponentModel.Container()
        Me.ToolStripPanel1 = New System.Windows.Forms.ToolStripPanel()
        Me.MenuStripMain = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mnui11 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuiIns = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mnui12 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuiPageSetup = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiPrintView = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mnui13 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuiExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LblBdelete = New System.Windows.Forms.Label()
        Me.TxtDjh = New System.Windows.Forms.TextBox()
        Me.TxtFjzs = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DtpPzrq = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmbPzlxjc = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnPrintView = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.BtnHelp = New System.Windows.Forms.Button()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnIns = New System.Windows.Forms.Button()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.BtnNew = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.LblJe = New System.Windows.Forms.Label()
        Me.TxtDfje = New System.Windows.Forms.TextBox()
        Me.TxtJfje = New System.Windows.Forms.TextBox()
        Me.rcDataGridView = New System.Windows.Forms.DataGridView()
        Me.ColZy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColKmdm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColKmmc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColBmdm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColBmmc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColKhdm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColKhmc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColYspz = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColJsr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColWldqr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColXmdm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColXmmc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColWb = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColHl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColJfje = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDfje = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rcBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ToolStripPanel1.SuspendLayout()
        Me.MenuStripMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripPanel1
        '
        Me.ToolStripPanel1.Controls.Add(Me.MenuStripMain)
        Me.ToolStripPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ToolStripPanel1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripPanel1.Name = "ToolStripPanel1"
        Me.ToolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.ToolStripPanel1.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ToolStripPanel1.Size = New System.Drawing.Size(1230, 36)
        '
        'MenuStripMain
        '
        Me.MenuStripMain.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStripMain.GripMargin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.MenuStripMain.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2})
        Me.MenuStripMain.Location = New System.Drawing.Point(0, 0)
        Me.MenuStripMain.Name = "MenuStripMain"
        Me.MenuStripMain.Size = New System.Drawing.Size(1230, 32)
        Me.MenuStripMain.TabIndex = 0
        Me.MenuStripMain.Text = "MenuStripMain"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiNew, Me.MnuiSave, Me.MnuiCancel, Me.Mnui11, Me.MnuiIns, Me.MnuiDelete, Me.Mnui12, Me.MnuiPageSetup, Me.MnuiPrintView, Me.MnuiPrint, Me.Mnui13, Me.MnuiExit})
        Me.ToolStripMenuItem1.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(84, 28)
        Me.ToolStripMenuItem1.Text = "文件(&F)"
        '
        'MnuiNew
        '
        Me.MnuiNew.Name = "MnuiNew"
        Me.MnuiNew.Size = New System.Drawing.Size(207, 34)
        Me.MnuiNew.Text = "新单(&A)"
        '
        'MnuiSave
        '
        Me.MnuiSave.Enabled = False
        Me.MnuiSave.Name = "MnuiSave"
        Me.MnuiSave.Size = New System.Drawing.Size(207, 34)
        Me.MnuiSave.Text = "保存(&S)"
        '
        'MnuiCancel
        '
        Me.MnuiCancel.Enabled = False
        Me.MnuiCancel.Name = "MnuiCancel"
        Me.MnuiCancel.Size = New System.Drawing.Size(207, 34)
        Me.MnuiCancel.Text = "取消(&C)"
        '
        'Mnui11
        '
        Me.Mnui11.Name = "Mnui11"
        Me.Mnui11.Size = New System.Drawing.Size(204, 6)
        '
        'MnuiIns
        '
        Me.MnuiIns.Name = "MnuiIns"
        Me.MnuiIns.Size = New System.Drawing.Size(207, 34)
        Me.MnuiIns.Text = "插入行(&I)"
        '
        'MnuiDelete
        '
        Me.MnuiDelete.Name = "MnuiDelete"
        Me.MnuiDelete.Size = New System.Drawing.Size(207, 34)
        Me.MnuiDelete.Text = "删除行(&D)"
        '
        'Mnui12
        '
        Me.Mnui12.Name = "Mnui12"
        Me.Mnui12.Size = New System.Drawing.Size(204, 6)
        '
        'MnuiPageSetup
        '
        Me.MnuiPageSetup.Name = "MnuiPageSetup"
        Me.MnuiPageSetup.Size = New System.Drawing.Size(207, 34)
        Me.MnuiPageSetup.Text = "页面设置(&U)"
        '
        'MnuiPrintView
        '
        Me.MnuiPrintView.Name = "MnuiPrintView"
        Me.MnuiPrintView.Size = New System.Drawing.Size(207, 34)
        Me.MnuiPrintView.Text = "打印预览(&V)"
        '
        'MnuiPrint
        '
        Me.MnuiPrint.Name = "MnuiPrint"
        Me.MnuiPrint.Size = New System.Drawing.Size(207, 34)
        Me.MnuiPrint.Text = "打印(&P)"
        '
        'Mnui13
        '
        Me.Mnui13.Name = "Mnui13"
        Me.Mnui13.Size = New System.Drawing.Size(204, 6)
        '
        'MnuiExit
        '
        Me.MnuiExit.Name = "MnuiExit"
        Me.MnuiExit.Size = New System.Drawing.Size(207, 34)
        Me.MnuiExit.Text = "退出(&X)"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(88, 28)
        Me.ToolStripMenuItem2.Text = "帮助(H)"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LblBdelete)
        Me.Panel1.Controls.Add(Me.TxtDjh)
        Me.Panel1.Controls.Add(Me.TxtFjzs)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.DtpPzrq)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.CmbPzlxjc)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 36)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1230, 150)
        Me.Panel1.TabIndex = 0
        '
        'LblBdelete
        '
        Me.LblBdelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblBdelete.AutoSize = True
        Me.LblBdelete.Font = New System.Drawing.Font("黑体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblBdelete.ForeColor = System.Drawing.Color.Red
        Me.LblBdelete.Location = New System.Drawing.Point(1056, 22)
        Me.LblBdelete.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBdelete.Name = "LblBdelete"
        Me.LblBdelete.Size = New System.Drawing.Size(89, 36)
        Me.LblBdelete.TabIndex = 9
        Me.LblBdelete.Text = "作废"
        '
        'TxtDjh
        '
        Me.TxtDjh.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtDjh.Location = New System.Drawing.Point(274, 88)
        Me.TxtDjh.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtDjh.MaxLength = 15
        Me.TxtDjh.Name = "TxtDjh"
        Me.TxtDjh.Size = New System.Drawing.Size(188, 35)
        Me.TxtDjh.TabIndex = 3
        '
        'TxtFjzs
        '
        Me.TxtFjzs.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtFjzs.Location = New System.Drawing.Point(1000, 88)
        Me.TxtFjzs.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtFjzs.Name = "TxtFjzs"
        Me.TxtFjzs.Size = New System.Drawing.Size(92, 35)
        Me.TxtFjzs.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label5.Location = New System.Drawing.Point(1104, 93)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 24)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "张"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.Location = New System.Drawing.Point(932, 93)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 24)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "附件"
        '
        'DtpPzrq
        '
        Me.DtpPzrq.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.DtpPzrq.Location = New System.Drawing.Point(567, 86)
        Me.DtpPzrq.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DtpPzrq.Name = "DtpPzrq"
        Me.DtpPzrq.Size = New System.Drawing.Size(202, 35)
        Me.DtpPzrq.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(490, 93)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 24)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "日期："
        '
        'CmbPzlxjc
        '
        Me.CmbPzlxjc.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CmbPzlxjc.FormattingEnabled = True
        Me.CmbPzlxjc.Location = New System.Drawing.Point(128, 88)
        Me.CmbPzlxjc.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CmbPzlxjc.Name = "CmbPzlxjc"
        Me.CmbPzlxjc.Size = New System.Drawing.Size(136, 32)
        Me.CmbPzlxjc.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(34, 93)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "凭证号："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("楷体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label1.Location = New System.Drawing.Point(507, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(163, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "记账凭证"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtnPrintView)
        Me.Panel2.Controls.Add(Me.BtnCancel)
        Me.Panel2.Controls.Add(Me.BtnExit)
        Me.Panel2.Controls.Add(Me.BtnHelp)
        Me.Panel2.Controls.Add(Me.BtnPrint)
        Me.Panel2.Controls.Add(Me.BtnSave)
        Me.Panel2.Controls.Add(Me.BtnIns)
        Me.Panel2.Controls.Add(Me.BtnDelete)
        Me.Panel2.Controls.Add(Me.BtnNew)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 492)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1230, 208)
        Me.Panel2.TabIndex = 2
        '
        'BtnPrintView
        '
        Me.BtnPrintView.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnPrintView.Location = New System.Drawing.Point(699, 150)
        Me.BtnPrintView.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnPrintView.Name = "BtnPrintView"
        Me.BtnPrintView.Size = New System.Drawing.Size(112, 34)
        Me.BtnPrintView.TabIndex = 8
        Me.BtnPrintView.Text = "预览(&V)"
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnCancel.Enabled = False
        Me.BtnCancel.Location = New System.Drawing.Point(249, 150)
        Me.BtnCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(112, 34)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "取消(&C)"
        '
        'BtnExit
        '
        Me.BtnExit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnExit.Location = New System.Drawing.Point(924, 150)
        Me.BtnExit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(112, 34)
        Me.BtnExit.TabIndex = 10
        Me.BtnExit.Text = "退出(&X)"
        Me.BtnExit.UseVisualStyleBackColor = True
        '
        'BtnHelp
        '
        Me.BtnHelp.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnHelp.Location = New System.Drawing.Point(812, 150)
        Me.BtnHelp.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnHelp.Name = "BtnHelp"
        Me.BtnHelp.Size = New System.Drawing.Size(112, 34)
        Me.BtnHelp.TabIndex = 9
        Me.BtnHelp.Text = "帮助(&H)"
        Me.BtnHelp.UseVisualStyleBackColor = True
        '
        'BtnPrint
        '
        Me.BtnPrint.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnPrint.Location = New System.Drawing.Point(586, 150)
        Me.BtnPrint.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(112, 34)
        Me.BtnPrint.TabIndex = 7
        Me.BtnPrint.Text = "打印"
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnSave.Enabled = False
        Me.BtnSave.Location = New System.Drawing.Point(136, 150)
        Me.BtnSave.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(112, 34)
        Me.BtnSave.TabIndex = 3
        Me.BtnSave.Text = "保存(&S)"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnIns
        '
        Me.BtnIns.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnIns.Location = New System.Drawing.Point(362, 150)
        Me.BtnIns.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnIns.Name = "BtnIns"
        Me.BtnIns.Size = New System.Drawing.Size(112, 34)
        Me.BtnIns.TabIndex = 5
        Me.BtnIns.Text = "插入行"
        Me.BtnIns.UseVisualStyleBackColor = True
        '
        'BtnDelete
        '
        Me.BtnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnDelete.Location = New System.Drawing.Point(474, 150)
        Me.BtnDelete.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(112, 34)
        Me.BtnDelete.TabIndex = 6
        Me.BtnDelete.Text = "删除行"
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'BtnNew
        '
        Me.BtnNew.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnNew.Location = New System.Drawing.Point(24, 150)
        Me.BtnNew.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(112, 34)
        Me.BtnNew.TabIndex = 2
        Me.BtnNew.Text = "新单(&A)"
        Me.BtnNew.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.LblMsg)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 51)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1230, 70)
        Me.Panel4.TabIndex = 0
        '
        'LblMsg
        '
        Me.LblMsg.AutoSize = True
        Me.LblMsg.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblMsg.Location = New System.Drawing.Point(9, 3)
        Me.LblMsg.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(0, 24)
        Me.LblMsg.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.LblJe)
        Me.Panel3.Controls.Add(Me.TxtDfje)
        Me.Panel3.Controls.Add(Me.TxtJfje)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1230, 51)
        Me.Panel3.TabIndex = 1
        '
        'LblJe
        '
        Me.LblJe.AutoSize = True
        Me.LblJe.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblJe.Location = New System.Drawing.Point(10, 9)
        Me.LblJe.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblJe.Name = "LblJe"
        Me.LblJe.Size = New System.Drawing.Size(130, 24)
        Me.LblJe.TabIndex = 0
        Me.LblJe.Text = "合计金额："
        '
        'TxtDfje
        '
        Me.TxtDfje.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtDfje.Location = New System.Drawing.Point(981, 4)
        Me.TxtDfje.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtDfje.Name = "TxtDfje"
        Me.TxtDfje.ReadOnly = True
        Me.TxtDfje.Size = New System.Drawing.Size(187, 35)
        Me.TxtDfje.TabIndex = 2
        Me.TxtDfje.TabStop = False
        Me.TxtDfje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtJfje
        '
        Me.TxtJfje.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtJfje.Location = New System.Drawing.Point(794, 4)
        Me.TxtJfje.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtJfje.Name = "TxtJfje"
        Me.TxtJfje.ReadOnly = True
        Me.TxtJfje.Size = New System.Drawing.Size(176, 35)
        Me.TxtJfje.TabIndex = 1
        Me.TxtJfje.TabStop = False
        Me.TxtJfje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'rcDataGridView
        '
        Me.rcDataGridView.ColumnHeadersHeight = 30
        Me.rcDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.rcDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColZy, Me.ColKmdm, Me.ColKmmc, Me.ColBmdm, Me.ColBmmc, Me.ColKhdm, Me.ColKhmc, Me.ColYspz, Me.ColJsr, Me.ColWldqr, Me.ColXmdm, Me.ColXmmc, Me.ColSl, Me.ColDj, Me.ColWb, Me.ColHl, Me.ColJfje, Me.ColDfje})
        Me.rcDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rcDataGridView.Location = New System.Drawing.Point(0, 186)
        Me.rcDataGridView.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rcDataGridView.MultiSelect = False
        Me.rcDataGridView.Name = "rcDataGridView"
        Me.rcDataGridView.RowHeadersWidth = 62
        Me.rcDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.rcDataGridView.RowTemplate.Height = 23
        Me.rcDataGridView.Size = New System.Drawing.Size(1230, 514)
        Me.rcDataGridView.TabIndex = 1
        '
        'ColZy
        '
        Me.ColZy.DataPropertyName = "zy"
        Me.ColZy.HeaderText = "摘        要"
        Me.ColZy.MaxInputLength = 200
        Me.ColZy.MinimumWidth = 8
        Me.ColZy.Name = "ColZy"
        Me.ColZy.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColZy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColZy.ToolTipText = "摘要"
        Me.ColZy.Width = 190
        '
        'ColKmdm
        '
        Me.ColKmdm.DataPropertyName = "kmdm"
        Me.ColKmdm.HeaderText = "科目编码"
        Me.ColKmdm.MaxInputLength = 15
        Me.ColKmdm.MinimumWidth = 8
        Me.ColKmdm.Name = "ColKmdm"
        Me.ColKmdm.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColKmdm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColKmdm.ToolTipText = "科目编码"
        Me.ColKmdm.Width = 150
        '
        'ColKmmc
        '
        Me.ColKmmc.DataPropertyName = "kmmc"
        Me.ColKmmc.HeaderText = "科目名称"
        Me.ColKmmc.MaxInputLength = 200
        Me.ColKmmc.MinimumWidth = 8
        Me.ColKmmc.Name = "ColKmmc"
        Me.ColKmmc.ReadOnly = True
        Me.ColKmmc.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColKmmc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColKmmc.ToolTipText = "科目名称"
        Me.ColKmmc.Width = 200
        '
        'ColBmdm
        '
        Me.ColBmdm.DataPropertyName = "bmdm"
        Me.ColBmdm.HeaderText = "部门编码"
        Me.ColBmdm.MinimumWidth = 8
        Me.ColBmdm.Name = "ColBmdm"
        Me.ColBmdm.Visible = False
        Me.ColBmdm.Width = 150
        '
        'ColBmmc
        '
        Me.ColBmmc.DataPropertyName = "bmmc"
        Me.ColBmmc.HeaderText = "部门名称"
        Me.ColBmmc.MinimumWidth = 8
        Me.ColBmmc.Name = "ColBmmc"
        Me.ColBmmc.Visible = False
        Me.ColBmmc.Width = 200
        '
        'ColKhdm
        '
        Me.ColKhdm.DataPropertyName = "khdm"
        Me.ColKhdm.HeaderText = "客户编码"
        Me.ColKhdm.MinimumWidth = 8
        Me.ColKhdm.Name = "ColKhdm"
        Me.ColKhdm.Visible = False
        Me.ColKhdm.Width = 150
        '
        'ColKhmc
        '
        Me.ColKhmc.DataPropertyName = "khmc"
        Me.ColKhmc.HeaderText = "客户名称"
        Me.ColKhmc.MinimumWidth = 8
        Me.ColKhmc.Name = "ColKhmc"
        Me.ColKhmc.Visible = False
        Me.ColKhmc.Width = 200
        '
        'ColYspz
        '
        Me.ColYspz.DataPropertyName = "yspz"
        Me.ColYspz.HeaderText = "原始凭证号"
        Me.ColYspz.MinimumWidth = 8
        Me.ColYspz.Name = "ColYspz"
        Me.ColYspz.Visible = False
        Me.ColYspz.Width = 150
        '
        'ColJsr
        '
        Me.ColJsr.DataPropertyName = "jsr"
        Me.ColJsr.HeaderText = "经手人"
        Me.ColJsr.MinimumWidth = 8
        Me.ColJsr.Name = "ColJsr"
        Me.ColJsr.Visible = False
        Me.ColJsr.Width = 150
        '
        'ColWldqr
        '
        Me.ColWldqr.DataPropertyName = "wldqr"
        Me.ColWldqr.HeaderText = "到期日"
        Me.ColWldqr.MinimumWidth = 8
        Me.ColWldqr.Name = "ColWldqr"
        Me.ColWldqr.Visible = False
        Me.ColWldqr.Width = 150
        '
        'ColXmdm
        '
        Me.ColXmdm.DataPropertyName = "xmdm"
        Me.ColXmdm.HeaderText = "项目编码"
        Me.ColXmdm.MinimumWidth = 8
        Me.ColXmdm.Name = "ColXmdm"
        Me.ColXmdm.Visible = False
        Me.ColXmdm.Width = 150
        '
        'ColXmmc
        '
        Me.ColXmmc.DataPropertyName = "xmmc"
        Me.ColXmmc.HeaderText = "项目名称"
        Me.ColXmmc.MinimumWidth = 8
        Me.ColXmmc.Name = "ColXmmc"
        Me.ColXmmc.Visible = False
        Me.ColXmmc.Width = 200
        '
        'ColSl
        '
        Me.ColSl.DataPropertyName = "sl"
        Me.ColSl.HeaderText = "数量"
        Me.ColSl.MinimumWidth = 8
        Me.ColSl.Name = "ColSl"
        Me.ColSl.Visible = False
        Me.ColSl.Width = 150
        '
        'ColDj
        '
        Me.ColDj.DataPropertyName = "dj"
        Me.ColDj.HeaderText = "单价"
        Me.ColDj.MinimumWidth = 8
        Me.ColDj.Name = "ColDj"
        Me.ColDj.Visible = False
        Me.ColDj.Width = 150
        '
        'ColWb
        '
        Me.ColWb.DataPropertyName = "wb"
        Me.ColWb.HeaderText = "外币"
        Me.ColWb.MinimumWidth = 8
        Me.ColWb.Name = "ColWb"
        Me.ColWb.Visible = False
        Me.ColWb.Width = 150
        '
        'ColHl
        '
        Me.ColHl.DataPropertyName = "hl"
        Me.ColHl.HeaderText = "汇率"
        Me.ColHl.MinimumWidth = 8
        Me.ColHl.Name = "ColHl"
        Me.ColHl.Visible = False
        Me.ColHl.Width = 150
        '
        'ColJfje
        '
        Me.ColJfje.DataPropertyName = "jfje"
        Me.ColJfje.HeaderText = "借方金额"
        Me.ColJfje.MaxInputLength = 18
        Me.ColJfje.MinimumWidth = 8
        Me.ColJfje.Name = "ColJfje"
        Me.ColJfje.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColJfje.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColJfje.ToolTipText = "借方金额"
        Me.ColJfje.Width = 125
        '
        'ColDfje
        '
        Me.ColDfje.DataPropertyName = "dfje"
        Me.ColDfje.HeaderText = "贷方金额"
        Me.ColDfje.MaxInputLength = 18
        Me.ColDfje.MinimumWidth = 8
        Me.ColDfje.Name = "ColDfje"
        Me.ColDfje.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColDfje.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColDfje.ToolTipText = "贷方金额"
        Me.ColDfje.Width = 125
        '
        'FrmGlPzSrz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1230, 700)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.rcDataGridView)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStripPanel1)
        Me.MainMenuStrip = Me.MenuStripMain
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmGlPzSrz"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "凭证输入"
        Me.ToolStripPanel1.ResumeLayout(False)
        Me.ToolStripPanel1.PerformLayout()
        Me.MenuStripMain.ResumeLayout(False)
        Me.MenuStripMain.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripPanel1 As System.Windows.Forms.ToolStripPanel
    Friend WithEvents MenuStripMain As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rcDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DtpPzrq As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbPzlxjc As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtDjh As System.Windows.Forms.TextBox
    Friend WithEvents TxtFjzs As System.Windows.Forms.TextBox
    Friend WithEvents LblJe As System.Windows.Forms.Label
    Friend WithEvents TxtJfje As System.Windows.Forms.TextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TxtDfje As System.Windows.Forms.TextBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents BtnHelp As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnIns As System.Windows.Forms.Button
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents rcBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LblMsg As System.Windows.Forms.Label
    Friend WithEvents MnuiExit As System.Windows.Forms.ToolStripMenuItem
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
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnPrintView As System.Windows.Forms.Button
    Friend WithEvents ColZy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKmdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKmmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBmdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBmmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKhdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKhmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColYspz As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJsr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColWldqr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColXmdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColXmmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColWb As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColHl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJfje As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDfje As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LblBdelete As System.Windows.Forms.Label
End Class
