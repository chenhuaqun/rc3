<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmGlZlfxHz2
    Inherits models.FrmDlgPortrait

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NudMonth = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NudYear = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ListBoxYuxuanDwdm = New System.Windows.Forms.ListBox()
        Me.ListBoxYixuanDwdm = New System.Windows.Forms.ListBox()
        Me.BtnSelectAllDwdm = New System.Windows.Forms.Button()
        Me.BtnSelectOneDwdm = New System.Windows.Forms.Button()
        Me.BtnUnSelectOneDwdm = New System.Windows.Forms.Button()
        Me.BtnUnSelectAllDwdm = New System.Windows.Forms.Button()
        Me.LblYuxuanDwdm = New System.Windows.Forms.Label()
        Me.LblYixuanDwdm = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ListBoxYuxuanKmdm = New System.Windows.Forms.ListBox()
        Me.ListBoxYixuanKmdm = New System.Windows.Forms.ListBox()
        Me.LblYixuanKmdm = New System.Windows.Forms.Label()
        Me.BtnSelectAllKmdm = New System.Windows.Forms.Button()
        Me.LblYuxuanKmdm = New System.Windows.Forms.Label()
        Me.BtnSelectOneKmdm = New System.Windows.Forms.Button()
        Me.BtnUnSelectAllKmdm = New System.Windows.Forms.Button()
        Me.BtnUnSelectOneKmdm = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.DlgPanel.SuspendLayout()
        CType(Me.NudMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(124, 4)
        Me.BtnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnCancel.Size = New System.Drawing.Size(111, 34)
        '
        'BtnHelp
        '
        Me.BtnHelp.Location = New System.Drawing.Point(244, 4)
        Me.BtnHelp.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnHelp.Size = New System.Drawing.Size(112, 34)
        '
        'BtnOk
        '
        Me.BtnOk.Location = New System.Drawing.Point(4, 4)
        Me.BtnOk.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnOk.Size = New System.Drawing.Size(111, 34)
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(412, 565)
        Me.DlgPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.DlgPanel.Size = New System.Drawing.Size(362, 46)
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Enabled = False
        Me.RadioButton2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.RadioButton2.Location = New System.Drawing.Point(266, 102)
        Me.RadioButton2.Margin = New System.Windows.Forms.Padding(4)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(251, 28)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "供应商(按贷方分析)"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.RadioButton1.Location = New System.Drawing.Point(24, 102)
        Me.RadioButton1.Margin = New System.Windows.Forms.Padding(4)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(227, 28)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "客户(按借方分析)"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(460, 49)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 24)
        Me.Label3.TabIndex = 118
        Me.Label3.Text = "月"
        '
        'NudMonth
        '
        Me.NudMonth.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NudMonth.Location = New System.Drawing.Point(381, 41)
        Me.NudMonth.Margin = New System.Windows.Forms.Padding(4)
        Me.NudMonth.Maximum = New Decimal(New Integer() {13, 0, 0, 0})
        Me.NudMonth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudMonth.Name = "NudMonth"
        Me.NudMonth.Size = New System.Drawing.Size(68, 35)
        Me.NudMonth.TabIndex = 117
        Me.NudMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudMonth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(333, 49)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 24)
        Me.Label2.TabIndex = 116
        Me.Label2.Text = "年"
        '
        'NudYear
        '
        Me.NudYear.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NudYear.Location = New System.Drawing.Point(232, 41)
        Me.NudYear.Margin = New System.Windows.Forms.Padding(4)
        Me.NudYear.Maximum = New Decimal(New Integer() {2050, 0, 0, 0})
        Me.NudYear.Minimum = New Decimal(New Integer() {1951, 0, 0, 0})
        Me.NudYear.Name = "NudYear"
        Me.NudYear.Size = New System.Drawing.Size(88, 35)
        Me.NudYear.TabIndex = 115
        Me.NudYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudYear.Value = New Decimal(New Integer() {1999, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(88, 49)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 24)
        Me.Label1.TabIndex = 114
        Me.Label1.Text = "会计期间："
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CheckBox2)
        Me.GroupBox2.Controls.Add(Me.RadioButton3)
        Me.GroupBox2.Controls.Add(Me.RadioButton2)
        Me.GroupBox2.Controls.Add(Me.NudYear)
        Me.GroupBox2.Controls.Add(Me.RadioButton1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.NudMonth)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(792, 154)
        Me.GroupBox2.TabIndex = 119
        Me.GroupBox2.TabStop = False
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Enabled = False
        Me.RadioButton3.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.RadioButton3.Location = New System.Drawing.Point(534, 102)
        Me.RadioButton3.Margin = New System.Windows.Forms.Padding(4)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(251, 28)
        Me.RadioButton3.TabIndex = 120
        Me.RadioButton3.Text = "供应商(按借方分析)"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'LblMsg
        '
        Me.LblMsg.AutoSize = True
        Me.LblMsg.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblMsg.ForeColor = System.Drawing.Color.Navy
        Me.LblMsg.Location = New System.Drawing.Point(18, 554)
        Me.LblMsg.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(130, 24)
        Me.LblMsg.TabIndex = 120
        Me.LblMsg.Text = "提示信息。"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TabControl1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 154)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(792, 386)
        Me.GroupBox1.TabIndex = 121
        Me.GroupBox1.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(4, 25)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(784, 357)
        Me.TabControl1.TabIndex = 122
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ListBoxYuxuanDwdm)
        Me.TabPage1.Controls.Add(Me.ListBoxYixuanDwdm)
        Me.TabPage1.Controls.Add(Me.BtnSelectAllDwdm)
        Me.TabPage1.Controls.Add(Me.BtnSelectOneDwdm)
        Me.TabPage1.Controls.Add(Me.BtnUnSelectOneDwdm)
        Me.TabPage1.Controls.Add(Me.BtnUnSelectAllDwdm)
        Me.TabPage1.Controls.Add(Me.LblYuxuanDwdm)
        Me.TabPage1.Controls.Add(Me.LblYixuanDwdm)
        Me.TabPage1.Location = New System.Drawing.Point(4, 28)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Size = New System.Drawing.Size(776, 325)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "选择核算单位"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ListBoxYuxuanDwdm
        '
        Me.ListBoxYuxuanDwdm.ItemHeight = 18
        Me.ListBoxYuxuanDwdm.Location = New System.Drawing.Point(9, 52)
        Me.ListBoxYuxuanDwdm.Margin = New System.Windows.Forms.Padding(4)
        Me.ListBoxYuxuanDwdm.Name = "ListBoxYuxuanDwdm"
        Me.ListBoxYuxuanDwdm.Size = New System.Drawing.Size(301, 256)
        Me.ListBoxYuxuanDwdm.Sorted = True
        Me.ListBoxYuxuanDwdm.TabIndex = 23
        '
        'ListBoxYixuanDwdm
        '
        Me.ListBoxYixuanDwdm.ItemHeight = 18
        Me.ListBoxYixuanDwdm.Location = New System.Drawing.Point(460, 52)
        Me.ListBoxYixuanDwdm.Margin = New System.Windows.Forms.Padding(4)
        Me.ListBoxYixuanDwdm.Name = "ListBoxYixuanDwdm"
        Me.ListBoxYixuanDwdm.Size = New System.Drawing.Size(301, 256)
        Me.ListBoxYixuanDwdm.Sorted = True
        Me.ListBoxYixuanDwdm.TabIndex = 24
        '
        'BtnSelectAllDwdm
        '
        Me.BtnSelectAllDwdm.Location = New System.Drawing.Point(328, 64)
        Me.BtnSelectAllDwdm.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSelectAllDwdm.Name = "BtnSelectAllDwdm"
        Me.BtnSelectAllDwdm.Size = New System.Drawing.Size(112, 34)
        Me.BtnSelectAllDwdm.TabIndex = 17
        Me.BtnSelectAllDwdm.Text = "-->>"
        '
        'BtnSelectOneDwdm
        '
        Me.BtnSelectOneDwdm.Location = New System.Drawing.Point(328, 124)
        Me.BtnSelectOneDwdm.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSelectOneDwdm.Name = "BtnSelectOneDwdm"
        Me.BtnSelectOneDwdm.Size = New System.Drawing.Size(112, 34)
        Me.BtnSelectOneDwdm.TabIndex = 18
        Me.BtnSelectOneDwdm.Text = "-->"
        '
        'BtnUnSelectOneDwdm
        '
        Me.BtnUnSelectOneDwdm.Location = New System.Drawing.Point(328, 184)
        Me.BtnUnSelectOneDwdm.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnUnSelectOneDwdm.Name = "BtnUnSelectOneDwdm"
        Me.BtnUnSelectOneDwdm.Size = New System.Drawing.Size(112, 34)
        Me.BtnUnSelectOneDwdm.TabIndex = 19
        Me.BtnUnSelectOneDwdm.Text = "<--"
        '
        'BtnUnSelectAllDwdm
        '
        Me.BtnUnSelectAllDwdm.Location = New System.Drawing.Point(328, 244)
        Me.BtnUnSelectAllDwdm.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnUnSelectAllDwdm.Name = "BtnUnSelectAllDwdm"
        Me.BtnUnSelectAllDwdm.Size = New System.Drawing.Size(112, 34)
        Me.BtnUnSelectAllDwdm.TabIndex = 20
        Me.BtnUnSelectAllDwdm.Text = "<<--"
        '
        'LblYuxuanDwdm
        '
        Me.LblYuxuanDwdm.AutoSize = True
        Me.LblYuxuanDwdm.Location = New System.Drawing.Point(9, 16)
        Me.LblYuxuanDwdm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblYuxuanDwdm.Name = "LblYuxuanDwdm"
        Me.LblYuxuanDwdm.Size = New System.Drawing.Size(116, 18)
        Me.LblYuxuanDwdm.TabIndex = 21
        Me.LblYuxuanDwdm.Text = "预选核算单位"
        '
        'LblYixuanDwdm
        '
        Me.LblYixuanDwdm.AutoSize = True
        Me.LblYixuanDwdm.Location = New System.Drawing.Point(460, 16)
        Me.LblYixuanDwdm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblYixuanDwdm.Name = "LblYixuanDwdm"
        Me.LblYixuanDwdm.Size = New System.Drawing.Size(116, 18)
        Me.LblYixuanDwdm.TabIndex = 22
        Me.LblYixuanDwdm.Text = "已选核算单位"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ListBoxYuxuanKmdm)
        Me.TabPage2.Controls.Add(Me.ListBoxYixuanKmdm)
        Me.TabPage2.Controls.Add(Me.LblYixuanKmdm)
        Me.TabPage2.Controls.Add(Me.BtnSelectAllKmdm)
        Me.TabPage2.Controls.Add(Me.LblYuxuanKmdm)
        Me.TabPage2.Controls.Add(Me.BtnSelectOneKmdm)
        Me.TabPage2.Controls.Add(Me.BtnUnSelectAllKmdm)
        Me.TabPage2.Controls.Add(Me.BtnUnSelectOneKmdm)
        Me.TabPage2.Location = New System.Drawing.Point(4, 28)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Size = New System.Drawing.Size(776, 325)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "选择科目"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ListBoxYuxuanKmdm
        '
        Me.ListBoxYuxuanKmdm.ItemHeight = 18
        Me.ListBoxYuxuanKmdm.Location = New System.Drawing.Point(10, 51)
        Me.ListBoxYuxuanKmdm.Margin = New System.Windows.Forms.Padding(4)
        Me.ListBoxYuxuanKmdm.Name = "ListBoxYuxuanKmdm"
        Me.ListBoxYuxuanKmdm.Size = New System.Drawing.Size(298, 238)
        Me.ListBoxYuxuanKmdm.Sorted = True
        Me.ListBoxYuxuanKmdm.TabIndex = 23
        '
        'ListBoxYixuanKmdm
        '
        Me.ListBoxYixuanKmdm.ItemHeight = 18
        Me.ListBoxYixuanKmdm.Location = New System.Drawing.Point(460, 51)
        Me.ListBoxYixuanKmdm.Margin = New System.Windows.Forms.Padding(4)
        Me.ListBoxYixuanKmdm.Name = "ListBoxYixuanKmdm"
        Me.ListBoxYixuanKmdm.Size = New System.Drawing.Size(298, 238)
        Me.ListBoxYixuanKmdm.Sorted = True
        Me.ListBoxYixuanKmdm.TabIndex = 24
        '
        'LblYixuanKmdm
        '
        Me.LblYixuanKmdm.AutoSize = True
        Me.LblYixuanKmdm.Location = New System.Drawing.Point(460, 15)
        Me.LblYixuanKmdm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblYixuanKmdm.Name = "LblYixuanKmdm"
        Me.LblYixuanKmdm.Size = New System.Drawing.Size(80, 18)
        Me.LblYixuanKmdm.TabIndex = 22
        Me.LblYixuanKmdm.Text = "已选科目"
        '
        'BtnSelectAllKmdm
        '
        Me.BtnSelectAllKmdm.Location = New System.Drawing.Point(328, 63)
        Me.BtnSelectAllKmdm.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSelectAllKmdm.Name = "BtnSelectAllKmdm"
        Me.BtnSelectAllKmdm.Size = New System.Drawing.Size(112, 34)
        Me.BtnSelectAllKmdm.TabIndex = 17
        Me.BtnSelectAllKmdm.Text = "-->>"
        '
        'LblYuxuanKmdm
        '
        Me.LblYuxuanKmdm.AutoSize = True
        Me.LblYuxuanKmdm.Location = New System.Drawing.Point(10, 15)
        Me.LblYuxuanKmdm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblYuxuanKmdm.Name = "LblYuxuanKmdm"
        Me.LblYuxuanKmdm.Size = New System.Drawing.Size(80, 18)
        Me.LblYuxuanKmdm.TabIndex = 21
        Me.LblYuxuanKmdm.Text = "预选科目"
        '
        'BtnSelectOneKmdm
        '
        Me.BtnSelectOneKmdm.Location = New System.Drawing.Point(328, 123)
        Me.BtnSelectOneKmdm.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSelectOneKmdm.Name = "BtnSelectOneKmdm"
        Me.BtnSelectOneKmdm.Size = New System.Drawing.Size(112, 34)
        Me.BtnSelectOneKmdm.TabIndex = 18
        Me.BtnSelectOneKmdm.Text = "-->"
        '
        'BtnUnSelectAllKmdm
        '
        Me.BtnUnSelectAllKmdm.Location = New System.Drawing.Point(328, 243)
        Me.BtnUnSelectAllKmdm.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnUnSelectAllKmdm.Name = "BtnUnSelectAllKmdm"
        Me.BtnUnSelectAllKmdm.Size = New System.Drawing.Size(112, 34)
        Me.BtnUnSelectAllKmdm.TabIndex = 20
        Me.BtnUnSelectAllKmdm.Text = "<<--"
        '
        'BtnUnSelectOneKmdm
        '
        Me.BtnUnSelectOneKmdm.Location = New System.Drawing.Point(328, 183)
        Me.BtnUnSelectOneKmdm.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnUnSelectOneKmdm.Name = "BtnUnSelectOneKmdm"
        Me.BtnUnSelectOneKmdm.Size = New System.Drawing.Size(112, 34)
        Me.BtnUnSelectOneKmdm.TabIndex = 19
        Me.BtnUnSelectOneKmdm.Text = "<--"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.ForeColor = System.Drawing.Color.Blue
        Me.CheckBox1.Location = New System.Drawing.Point(22, 593)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(304, 22)
        Me.CheckBox1.TabIndex = 122
        Me.CheckBox1.Text = "不显示没有发生额没有余额的数据"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CheckBox2.ForeColor = System.Drawing.Color.Blue
        Me.CheckBox2.Location = New System.Drawing.Point(536, 45)
        Me.CheckBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(204, 28)
        Me.CheckBox2.TabIndex = 123
        Me.CheckBox2.Text = "按核算单位显示"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'FrmGlZlfxHz2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 630)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.LblMsg)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmGlZlfxHz2"
        Me.Text = "汇总账龄分析表(按单位)"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.LblMsg, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.CheckBox1, 0)
        Me.DlgPanel.ResumeLayout(False)
        CType(Me.NudMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents NudMonth As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NudYear As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LblMsg As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ListBoxYuxuanKmdm As System.Windows.Forms.ListBox
    Friend WithEvents ListBoxYixuanKmdm As System.Windows.Forms.ListBox
    Friend WithEvents BtnSelectAllKmdm As System.Windows.Forms.Button
    Friend WithEvents BtnSelectOneKmdm As System.Windows.Forms.Button
    Friend WithEvents BtnUnSelectOneKmdm As System.Windows.Forms.Button
    Friend WithEvents BtnUnSelectAllKmdm As System.Windows.Forms.Button
    Friend WithEvents LblYuxuanKmdm As System.Windows.Forms.Label
    Friend WithEvents LblYixuanKmdm As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ListBoxYuxuanDwdm As System.Windows.Forms.ListBox
    Friend WithEvents ListBoxYixuanDwdm As System.Windows.Forms.ListBox
    Friend WithEvents BtnSelectAllDwdm As System.Windows.Forms.Button
    Friend WithEvents BtnSelectOneDwdm As System.Windows.Forms.Button
    Friend WithEvents BtnUnSelectOneDwdm As System.Windows.Forms.Button
    Friend WithEvents BtnUnSelectAllDwdm As System.Windows.Forms.Button
    Friend WithEvents LblYuxuanDwdm As System.Windows.Forms.Label
    Friend WithEvents LblYixuanDwdm As System.Windows.Forms.Label
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
End Class
