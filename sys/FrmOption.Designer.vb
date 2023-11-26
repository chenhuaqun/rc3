<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOption
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
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtYszk = New System.Windows.Forms.TextBox()
        Me.TxtYfzk = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtZyywsr = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtZyywcb = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtYcl = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtKcsp = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtSccb = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CmbPzlxjc = New System.Windows.Forms.ComboBox()
        Me.ChbXsdDy = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.BtnFbd = New System.Windows.Forms.Button()
        Me.TxtGlPath = New System.Windows.Forms.TextBox()
        Me.rcFolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.TxtDefaultShlv = New System.Windows.Forms.TextBox()
        Me.LblDefaultShlv = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TxtNCAccountingBook = New System.Windows.Forms.TextBox()
        Me.LblNCAccountingBook = New System.Windows.Forms.Label()
        Me.BtnNCSave = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.TxtNCHost = New System.Windows.Forms.TextBox()
        Me.TxtNCService_Name = New System.Windows.Forms.TextBox()
        Me.LblNCPwd = New System.Windows.Forms.Label()
        Me.LblNCUser_ID = New System.Windows.Forms.Label()
        Me.TxtNCUser_ID = New System.Windows.Forms.TextBox()
        Me.LblNCService_Name = New System.Windows.Forms.Label()
        Me.TxtNCPwd = New System.Windows.Forms.TextBox()
        Me.LblNCHost = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.BtnU8Save = New System.Windows.Forms.Button()
        Me.TxtU8Acc_ID = New System.Windows.Forms.TextBox()
        Me.LblU8Acc_ID = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtU8Host = New System.Windows.Forms.TextBox()
        Me.LblU8Pwd = New System.Windows.Forms.Label()
        Me.LblU8User_ID = New System.Windows.Forms.Label()
        Me.TxtU8User_ID = New System.Windows.Forms.TextBox()
        Me.TxtU8Pwd = New System.Windows.Forms.TextBox()
        Me.LblU8Host = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.BtnCostRegion = New System.Windows.Forms.Button()
        Me.ChbCostRegion = New System.Windows.Forms.CheckBox()
        Me.GroupBox4.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(462, 317)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(80, 23)
        Me.BtnSave.TabIndex = 2
        Me.BtnSave.Text = "保存设置(&X)"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(234, 12)
        Me.TextBox3.MaxLength = 30
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(308, 21)
        Me.TextBox3.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(173, 12)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "单据打印中抬头使用的单位名称"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "总账应收账款科目编码"
        '
        'TxtYszk
        '
        Me.TxtYszk.Location = New System.Drawing.Point(234, 67)
        Me.TxtYszk.Name = "TxtYszk"
        Me.TxtYszk.Size = New System.Drawing.Size(100, 21)
        Me.TxtYszk.TabIndex = 4
        '
        'TxtYfzk
        '
        Me.TxtYfzk.Location = New System.Drawing.Point(234, 94)
        Me.TxtYfzk.Name = "TxtYfzk"
        Me.TxtYfzk.Size = New System.Drawing.Size(100, 21)
        Me.TxtYfzk.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "总账应付账款科目编码"
        '
        'TxtZyywsr
        '
        Me.TxtZyywsr.Location = New System.Drawing.Point(234, 121)
        Me.TxtZyywsr.Name = "TxtZyywsr"
        Me.TxtZyywsr.Size = New System.Drawing.Size(100, 21)
        Me.TxtZyywsr.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(149, 12)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "总账主营业务收入科目编码"
        '
        'TxtZyywcb
        '
        Me.TxtZyywcb.Location = New System.Drawing.Point(234, 148)
        Me.TxtZyywcb.Name = "TxtZyywcb"
        Me.TxtZyywcb.Size = New System.Drawing.Size(100, 21)
        Me.TxtZyywcb.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(149, 12)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "总账主营业务成本科目编码"
        '
        'TxtYcl
        '
        Me.TxtYcl.Location = New System.Drawing.Point(234, 176)
        Me.TxtYcl.Name = "TxtYcl"
        Me.TxtYcl.Size = New System.Drawing.Size(100, 21)
        Me.TxtYcl.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 180)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 12)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "总账原材料科目编码"
        '
        'TxtKcsp
        '
        Me.TxtKcsp.Location = New System.Drawing.Point(234, 205)
        Me.TxtKcsp.Name = "TxtKcsp"
        Me.TxtKcsp.Size = New System.Drawing.Size(100, 21)
        Me.TxtKcsp.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 209)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 12)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "总账库存商品科目编码"
        '
        'TxtSccb
        '
        Me.TxtSccb.Location = New System.Drawing.Point(234, 232)
        Me.TxtSccb.Name = "TxtSccb"
        Me.TxtSccb.Size = New System.Drawing.Size(100, 21)
        Me.TxtSccb.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 236)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(125, 12)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "总账生产成本科目编码"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 264)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(149, 12)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "凭证生成中使用的凭证类型"
        '
        'CmbPzlxjc
        '
        Me.CmbPzlxjc.FormattingEnabled = True
        Me.CmbPzlxjc.Location = New System.Drawing.Point(234, 260)
        Me.CmbPzlxjc.Name = "CmbPzlxjc"
        Me.CmbPzlxjc.Size = New System.Drawing.Size(100, 20)
        Me.CmbPzlxjc.TabIndex = 18
        '
        'ChbXsdDy
        '
        Me.ChbXsdDy.AutoSize = True
        Me.ChbXsdDy.Location = New System.Drawing.Point(420, 44)
        Me.ChbXsdDy.Name = "ChbXsdDy"
        Me.ChbXsdDy.Size = New System.Drawing.Size(132, 16)
        Me.ChbXsdDy.TabIndex = 20
        Me.ChbXsdDy.Text = "套打格式打印销售单"
        Me.ChbXsdDy.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.BtnFbd)
        Me.GroupBox4.Controls.Add(Me.TxtGlPath)
        Me.GroupBox4.Location = New System.Drawing.Point(17, 295)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(384, 64)
        Me.GroupBox4.TabIndex = 21
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Anyi311账务系统路径"
        '
        'BtnFbd
        '
        Me.BtnFbd.Location = New System.Drawing.Point(344, 24)
        Me.BtnFbd.Name = "BtnFbd"
        Me.BtnFbd.Size = New System.Drawing.Size(24, 23)
        Me.BtnFbd.TabIndex = 1
        Me.BtnFbd.Text = "…"
        '
        'TxtGlPath
        '
        Me.TxtGlPath.Location = New System.Drawing.Point(16, 24)
        Me.TxtGlPath.Name = "TxtGlPath"
        Me.TxtGlPath.Size = New System.Drawing.Size(320, 21)
        Me.TxtGlPath.TabIndex = 0
        '
        'rcFolderBrowserDialog
        '
        Me.rcFolderBrowserDialog.Description = "请选择升级数据路径"
        Me.rcFolderBrowserDialog.ShowNewFolderButton = False
        '
        'TxtDefaultShlv
        '
        Me.TxtDefaultShlv.Location = New System.Drawing.Point(234, 39)
        Me.TxtDefaultShlv.Name = "TxtDefaultShlv"
        Me.TxtDefaultShlv.Size = New System.Drawing.Size(100, 21)
        Me.TxtDefaultShlv.TabIndex = 23
        '
        'LblDefaultShlv
        '
        Me.LblDefaultShlv.AutoSize = True
        Me.LblDefaultShlv.Location = New System.Drawing.Point(15, 43)
        Me.LblDefaultShlv.Name = "LblDefaultShlv"
        Me.LblDefaultShlv.Size = New System.Drawing.Size(89, 12)
        Me.LblDefaultShlv.TabIndex = 22
        Me.LblDefaultShlv.Text = "增值税默认税率"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(579, 385)
        Me.TabControl1.TabIndex = 24
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ChbXsdDy)
        Me.TabPage1.Controls.Add(Me.BtnSave)
        Me.TabPage1.Controls.Add(Me.TxtDefaultShlv)
        Me.TabPage1.Controls.Add(Me.TxtZyywcb)
        Me.TabPage1.Controls.Add(Me.LblDefaultShlv)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Controls.Add(Me.TextBox3)
        Me.TabPage1.Controls.Add(Me.CmbPzlxjc)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.TxtYszk)
        Me.TabPage1.Controls.Add(Me.TxtSccb)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.TxtYfzk)
        Me.TabPage1.Controls.Add(Me.TxtKcsp)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.TxtZyywsr)
        Me.TabPage1.Controls.Add(Me.TxtYcl)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(571, 359)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "会计科目设置"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TxtNCAccountingBook)
        Me.TabPage2.Controls.Add(Me.LblNCAccountingBook)
        Me.TabPage2.Controls.Add(Me.BtnNCSave)
        Me.TabPage2.Controls.Add(Me.GroupBox5)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(571, 359)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "用友NC6.X数据源及参数设置"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TxtNCAccountingBook
        '
        Me.TxtNCAccountingBook.Location = New System.Drawing.Point(98, 140)
        Me.TxtNCAccountingBook.MaxLength = 20
        Me.TxtNCAccountingBook.Name = "TxtNCAccountingBook"
        Me.TxtNCAccountingBook.Size = New System.Drawing.Size(96, 21)
        Me.TxtNCAccountingBook.TabIndex = 14
        '
        'LblNCAccountingBook
        '
        Me.LblNCAccountingBook.AutoSize = True
        Me.LblNCAccountingBook.Location = New System.Drawing.Point(27, 143)
        Me.LblNCAccountingBook.Name = "LblNCAccountingBook"
        Me.LblNCAccountingBook.Size = New System.Drawing.Size(65, 12)
        Me.LblNCAccountingBook.TabIndex = 13
        Me.LblNCAccountingBook.Text = "核算账簿："
        '
        'BtnNCSave
        '
        Me.BtnNCSave.Location = New System.Drawing.Point(467, 318)
        Me.BtnNCSave.Name = "BtnNCSave"
        Me.BtnNCSave.Size = New System.Drawing.Size(80, 23)
        Me.BtnNCSave.TabIndex = 3
        Me.BtnNCSave.Text = "保存设置(&X)"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.TxtNCHost)
        Me.GroupBox5.Controls.Add(Me.TxtNCService_Name)
        Me.GroupBox5.Controls.Add(Me.LblNCPwd)
        Me.GroupBox5.Controls.Add(Me.LblNCUser_ID)
        Me.GroupBox5.Controls.Add(Me.TxtNCUser_ID)
        Me.GroupBox5.Controls.Add(Me.LblNCService_Name)
        Me.GroupBox5.Controls.Add(Me.TxtNCPwd)
        Me.GroupBox5.Controls.Add(Me.LblNCHost)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox5.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(565, 114)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "用友NC6.X数据源设置"
        '
        'TxtNCHost
        '
        Me.TxtNCHost.Location = New System.Drawing.Point(24, 43)
        Me.TxtNCHost.MaxLength = 20
        Me.TxtNCHost.Name = "TxtNCHost"
        Me.TxtNCHost.Size = New System.Drawing.Size(192, 21)
        Me.TxtNCHost.TabIndex = 10
        '
        'TxtNCService_Name
        '
        Me.TxtNCService_Name.Location = New System.Drawing.Point(120, 72)
        Me.TxtNCService_Name.MaxLength = 20
        Me.TxtNCService_Name.Name = "TxtNCService_Name"
        Me.TxtNCService_Name.Size = New System.Drawing.Size(96, 21)
        Me.TxtNCService_Name.TabIndex = 12
        '
        'LblNCPwd
        '
        Me.LblNCPwd.AutoSize = True
        Me.LblNCPwd.Location = New System.Drawing.Point(248, 76)
        Me.LblNCPwd.Name = "LblNCPwd"
        Me.LblNCPwd.Size = New System.Drawing.Size(65, 12)
        Me.LblNCPwd.TabIndex = 15
        Me.LblNCPwd.Text = "口    令："
        '
        'LblNCUser_ID
        '
        Me.LblNCUser_ID.AutoSize = True
        Me.LblNCUser_ID.Location = New System.Drawing.Point(248, 47)
        Me.LblNCUser_ID.Name = "LblNCUser_ID"
        Me.LblNCUser_ID.Size = New System.Drawing.Size(65, 12)
        Me.LblNCUser_ID.TabIndex = 13
        Me.LblNCUser_ID.Text = "用户名称："
        '
        'TxtNCUser_ID
        '
        Me.TxtNCUser_ID.Location = New System.Drawing.Point(320, 43)
        Me.TxtNCUser_ID.MaxLength = 20
        Me.TxtNCUser_ID.Name = "TxtNCUser_ID"
        Me.TxtNCUser_ID.Size = New System.Drawing.Size(96, 21)
        Me.TxtNCUser_ID.TabIndex = 14
        '
        'LblNCService_Name
        '
        Me.LblNCService_Name.AutoSize = True
        Me.LblNCService_Name.Location = New System.Drawing.Point(24, 76)
        Me.LblNCService_Name.Name = "LblNCService_Name"
        Me.LblNCService_Name.Size = New System.Drawing.Size(89, 12)
        Me.LblNCService_Name.TabIndex = 11
        Me.LblNCService_Name.Text = "数据库服务名："
        '
        'TxtNCPwd
        '
        Me.TxtNCPwd.Location = New System.Drawing.Point(320, 72)
        Me.TxtNCPwd.MaxLength = 20
        Me.TxtNCPwd.Name = "TxtNCPwd"
        Me.TxtNCPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtNCPwd.Size = New System.Drawing.Size(96, 21)
        Me.TxtNCPwd.TabIndex = 16
        '
        'LblNCHost
        '
        Me.LblNCHost.AutoSize = True
        Me.LblNCHost.Location = New System.Drawing.Point(24, 27)
        Me.LblNCHost.Name = "LblNCHost"
        Me.LblNCHost.Size = New System.Drawing.Size(161, 12)
        Me.LblNCHost.TabIndex = 9
        Me.LblNCHost.Text = "数据库服务器（或IP地址）："
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.BtnU8Save)
        Me.TabPage4.Controls.Add(Me.TxtU8Acc_ID)
        Me.TabPage4.Controls.Add(Me.LblU8Acc_ID)
        Me.TabPage4.Controls.Add(Me.GroupBox1)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(571, 359)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "用友U8数据源及参数设置"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'BtnU8Save
        '
        Me.BtnU8Save.Location = New System.Drawing.Point(436, 296)
        Me.BtnU8Save.Name = "BtnU8Save"
        Me.BtnU8Save.Size = New System.Drawing.Size(80, 23)
        Me.BtnU8Save.TabIndex = 18
        Me.BtnU8Save.Text = "保存设置(&X)"
        '
        'TxtU8Acc_ID
        '
        Me.TxtU8Acc_ID.Location = New System.Drawing.Point(136, 138)
        Me.TxtU8Acc_ID.MaxLength = 20
        Me.TxtU8Acc_ID.Name = "TxtU8Acc_ID"
        Me.TxtU8Acc_ID.Size = New System.Drawing.Size(96, 21)
        Me.TxtU8Acc_ID.TabIndex = 17
        '
        'LblU8Acc_ID
        '
        Me.LblU8Acc_ID.AutoSize = True
        Me.LblU8Acc_ID.Location = New System.Drawing.Point(39, 142)
        Me.LblU8Acc_ID.Name = "LblU8Acc_ID"
        Me.LblU8Acc_ID.Size = New System.Drawing.Size(89, 12)
        Me.LblU8Acc_ID.TabIndex = 16
        Me.LblU8Acc_ID.Text = "核算单位编码："
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtU8Host)
        Me.GroupBox1.Controls.Add(Me.LblU8Pwd)
        Me.GroupBox1.Controls.Add(Me.LblU8User_ID)
        Me.GroupBox1.Controls.Add(Me.TxtU8User_ID)
        Me.GroupBox1.Controls.Add(Me.TxtU8Pwd)
        Me.GroupBox1.Controls.Add(Me.LblU8Host)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(571, 114)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "用友U8数据源设置"
        '
        'TxtU8Host
        '
        Me.TxtU8Host.Location = New System.Drawing.Point(27, 63)
        Me.TxtU8Host.MaxLength = 20
        Me.TxtU8Host.Name = "TxtU8Host"
        Me.TxtU8Host.Size = New System.Drawing.Size(192, 21)
        Me.TxtU8Host.TabIndex = 10
        '
        'LblU8Pwd
        '
        Me.LblU8Pwd.AutoSize = True
        Me.LblU8Pwd.Location = New System.Drawing.Point(248, 76)
        Me.LblU8Pwd.Name = "LblU8Pwd"
        Me.LblU8Pwd.Size = New System.Drawing.Size(65, 12)
        Me.LblU8Pwd.TabIndex = 15
        Me.LblU8Pwd.Text = "口    令："
        '
        'LblU8User_ID
        '
        Me.LblU8User_ID.AutoSize = True
        Me.LblU8User_ID.Location = New System.Drawing.Point(248, 47)
        Me.LblU8User_ID.Name = "LblU8User_ID"
        Me.LblU8User_ID.Size = New System.Drawing.Size(65, 12)
        Me.LblU8User_ID.TabIndex = 13
        Me.LblU8User_ID.Text = "用户名称："
        '
        'TxtU8User_ID
        '
        Me.TxtU8User_ID.Location = New System.Drawing.Point(320, 43)
        Me.TxtU8User_ID.MaxLength = 20
        Me.TxtU8User_ID.Name = "TxtU8User_ID"
        Me.TxtU8User_ID.Size = New System.Drawing.Size(96, 21)
        Me.TxtU8User_ID.TabIndex = 14
        '
        'TxtU8Pwd
        '
        Me.TxtU8Pwd.Location = New System.Drawing.Point(320, 72)
        Me.TxtU8Pwd.MaxLength = 20
        Me.TxtU8Pwd.Name = "TxtU8Pwd"
        Me.TxtU8Pwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtU8Pwd.Size = New System.Drawing.Size(96, 21)
        Me.TxtU8Pwd.TabIndex = 16
        '
        'LblU8Host
        '
        Me.LblU8Host.AutoSize = True
        Me.LblU8Host.Location = New System.Drawing.Point(27, 47)
        Me.LblU8Host.Name = "LblU8Host"
        Me.LblU8Host.Size = New System.Drawing.Size(161, 12)
        Me.LblU8Host.TabIndex = 9
        Me.LblU8Host.Text = "数据库服务器（或IP地址）："
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.BtnCostRegion)
        Me.TabPage3.Controls.Add(Me.ChbCostRegion)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(571, 359)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "成本参数"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'BtnCostRegion
        '
        Me.BtnCostRegion.Location = New System.Drawing.Point(425, 277)
        Me.BtnCostRegion.Name = "BtnCostRegion"
        Me.BtnCostRegion.Size = New System.Drawing.Size(80, 23)
        Me.BtnCostRegion.TabIndex = 22
        Me.BtnCostRegion.Text = "保存设置(&X)"
        '
        'ChbCostRegion
        '
        Me.ChbCostRegion.AutoSize = True
        Me.ChbCostRegion.Location = New System.Drawing.Point(54, 21)
        Me.ChbCostRegion.Name = "ChbCostRegion"
        Me.ChbCostRegion.Size = New System.Drawing.Size(144, 16)
        Me.ChbCostRegion.TabIndex = 21
        Me.ChbCostRegion.Text = "是否按成本域计算成本"
        Me.ChbCostRegion.UseVisualStyleBackColor = True
        '
        'FrmOption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(579, 385)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FrmOption"
        Me.Text = "选项"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtYszk As System.Windows.Forms.TextBox
    Friend WithEvents TxtYfzk As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtZyywsr As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtZyywcb As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtYcl As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtKcsp As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtSccb As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CmbPzlxjc As System.Windows.Forms.ComboBox
    Friend WithEvents ChbXsdDy As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnFbd As System.Windows.Forms.Button
    Friend WithEvents TxtGlPath As System.Windows.Forms.TextBox
    Friend WithEvents rcFolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents TxtDefaultShlv As System.Windows.Forms.TextBox
    Friend WithEvents LblDefaultShlv As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Private WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNCHost As System.Windows.Forms.TextBox
    Friend WithEvents TxtNCService_Name As System.Windows.Forms.TextBox
    Friend WithEvents LblNCPwd As System.Windows.Forms.Label
    Friend WithEvents LblNCUser_ID As System.Windows.Forms.Label
    Friend WithEvents TxtNCUser_ID As System.Windows.Forms.TextBox
    Friend WithEvents LblNCService_Name As System.Windows.Forms.Label
    Friend WithEvents TxtNCPwd As System.Windows.Forms.TextBox
    Friend WithEvents LblNCHost As System.Windows.Forms.Label
    Friend WithEvents BtnNCSave As System.Windows.Forms.Button
    Friend WithEvents TxtNCAccountingBook As System.Windows.Forms.TextBox
    Friend WithEvents LblNCAccountingBook As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents BtnCostRegion As Button
    Friend WithEvents ChbCostRegion As CheckBox
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents TxtU8Acc_ID As TextBox
    Friend WithEvents LblU8Acc_ID As Label
    Private WithEvents GroupBox1 As GroupBox
    Friend WithEvents TxtU8Host As TextBox
    Friend WithEvents LblU8Pwd As Label
    Friend WithEvents LblU8User_ID As Label
    Friend WithEvents TxtU8User_ID As TextBox
    Friend WithEvents TxtU8Pwd As TextBox
    Friend WithEvents LblU8Host As Label
    Friend WithEvents BtnU8Save As Button
End Class
