<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImpNC
    Inherits models.FrmDlgPortrait

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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NudMonth = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NudYear = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ChbPz = New System.Windows.Forms.CheckBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ChbQc = New System.Windows.Forms.CheckBox()
        Me.ChbSkd = New System.Windows.Forms.CheckBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ChbKh = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.ChbInvRkd1 = New System.Windows.Forms.CheckBox()
        Me.ChbOeXsck = New System.Windows.Forms.CheckBox()
        Me.ChbInvDbd = New System.Windows.Forms.CheckBox()
        Me.ChbPoRkd = New System.Windows.Forms.CheckBox()
        Me.ChbInvCkd = New System.Windows.Forms.CheckBox()
        Me.TxtCkdm = New System.Windows.Forms.TextBox()
        Me.LblCkdm = New System.Windows.Forms.Label()
        Me.ChbKcqcye = New System.Windows.Forms.CheckBox()
        Me.BtnWrite = New System.Windows.Forms.Button()
        Me.ChbCpdm = New System.Windows.Forms.CheckBox()
        Me.ChbQtck = New System.Windows.Forms.CheckBox()
        Me.ChbQtrk = New System.Windows.Forms.CheckBox()
        Me.ChbInvRkd2 = New System.Windows.Forms.CheckBox()
        Me.ChbOeXsfp = New System.Windows.Forms.CheckBox()
        Me.LblFph = New System.Windows.Forms.Label()
        Me.CmbFph = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CmbZkCpdm = New System.Windows.Forms.ComboBox()
        Me.ChbOeZgys = New System.Windows.Forms.CheckBox()
        Me.TxtNCCkdm = New System.Windows.Forms.TextBox()
        Me.DlgPanel.SuspendLayout()
        CType(Me.NudMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnCancel
        '
        Me.BtnCancel.TabIndex = 1
        '
        'BtnHelp
        '
        Me.BtnHelp.TabIndex = 2
        '
        'BtnOk
        '
        Me.BtnOk.TabIndex = 0
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(305, 418)
        Me.DlgPanel.Size = New System.Drawing.Size(241, 31)
        Me.DlgPanel.TabIndex = 28
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(341, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "月"
        '
        'NudMonth
        '
        Me.NudMonth.Enabled = False
        Me.NudMonth.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NudMonth.Location = New System.Drawing.Point(287, 17)
        Me.NudMonth.Maximum = New Decimal(New Integer() {13, 0, 0, 0})
        Me.NudMonth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudMonth.Name = "NudMonth"
        Me.NudMonth.Size = New System.Drawing.Size(45, 26)
        Me.NudMonth.TabIndex = 3
        Me.NudMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudMonth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(255, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "年"
        '
        'NudYear
        '
        Me.NudYear.Enabled = False
        Me.NudYear.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NudYear.Location = New System.Drawing.Point(189, 17)
        Me.NudYear.Maximum = New Decimal(New Integer() {2050, 0, 0, 0})
        Me.NudYear.Minimum = New Decimal(New Integer() {1951, 0, 0, 0})
        Me.NudYear.Name = "NudYear"
        Me.NudYear.Size = New System.Drawing.Size(59, 26)
        Me.NudYear.TabIndex = 1
        Me.NudYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudYear.Value = New Decimal(New Integer() {1999, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(93, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "会计期间："
        '
        'ChbPz
        '
        Me.ChbPz.AutoSize = True
        Me.ChbPz.Location = New System.Drawing.Point(41, 62)
        Me.ChbPz.Name = "ChbPz"
        Me.ChbPz.Size = New System.Drawing.Size(72, 16)
        Me.ChbPz.TabIndex = 5
        Me.ChbPz.Text = "总账凭证"
        Me.ChbPz.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(41, 389)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(465, 23)
        Me.ProgressBar1.TabIndex = 26
        '
        'ChbQc
        '
        Me.ChbQc.AutoSize = True
        Me.ChbQc.Location = New System.Drawing.Point(138, 62)
        Me.ChbQc.Name = "ChbQc"
        Me.ChbQc.Size = New System.Drawing.Size(72, 16)
        Me.ChbQc.TabIndex = 6
        Me.ChbQc.Text = "期初余额"
        Me.ChbQc.UseVisualStyleBackColor = True
        '
        'ChbSkd
        '
        Me.ChbSkd.AutoSize = True
        Me.ChbSkd.Location = New System.Drawing.Point(41, 86)
        Me.ChbSkd.Name = "ChbSkd"
        Me.ChbSkd.Size = New System.Drawing.Size(96, 16)
        Me.ChbSkd.TabIndex = 7
        Me.ChbSkd.Text = "收款单(SKDJ)"
        Me.ChbSkd.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30"})
        Me.ComboBox1.Location = New System.Drawing.Point(413, 84)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(60, 20)
        Me.ComboBox1.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(196, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(209, 12)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "收款单据表体售达方的自定义属性序号"
        '
        'ChbKh
        '
        Me.ChbKh.AutoSize = True
        Me.ChbKh.Location = New System.Drawing.Point(41, 110)
        Me.ChbKh.Name = "ChbKh"
        Me.ChbKh.Size = New System.Drawing.Size(132, 16)
        Me.ChbKh.TabIndex = 10
        Me.ChbKh.Text = "客户收款期与业务员"
        Me.ChbKh.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(268, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(137, 12)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "收款期的自定义属性序号"
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30"})
        Me.ComboBox2.Location = New System.Drawing.Point(413, 108)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(60, 20)
        Me.ComboBox2.TabIndex = 12
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Location = New System.Drawing.Point(41, 134)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(465, 48)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(246, 20)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(59, 16)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "进出口"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(74, 20)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "普通"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'ChbInvRkd1
        '
        Me.ChbInvRkd1.AutoSize = True
        Me.ChbInvRkd1.Location = New System.Drawing.Point(153, 231)
        Me.ChbInvRkd1.Name = "ChbInvRkd1"
        Me.ChbInvRkd1.Size = New System.Drawing.Size(120, 16)
        Me.ChbInvRkd1.TabIndex = 17
        Me.ChbInvRkd1.Text = "产成品入库(SCRK)"
        Me.ChbInvRkd1.UseVisualStyleBackColor = True
        '
        'ChbOeXsck
        '
        Me.ChbOeXsck.AutoSize = True
        Me.ChbOeXsck.Location = New System.Drawing.Point(41, 271)
        Me.ChbOeXsck.Name = "ChbOeXsck"
        Me.ChbOeXsck.Size = New System.Drawing.Size(108, 16)
        Me.ChbOeXsck.TabIndex = 21
        Me.ChbOeXsck.Text = "销售出库(XSCK)"
        Me.ChbOeXsck.UseVisualStyleBackColor = True
        '
        'ChbInvDbd
        '
        Me.ChbInvDbd.AutoSize = True
        Me.ChbInvDbd.Location = New System.Drawing.Point(277, 251)
        Me.ChbInvDbd.Name = "ChbInvDbd"
        Me.ChbInvDbd.Size = New System.Drawing.Size(108, 16)
        Me.ChbInvDbd.TabIndex = 22
        Me.ChbInvDbd.Text = "调拨出库(DBDJ)"
        Me.ChbInvDbd.UseVisualStyleBackColor = True
        '
        'ChbPoRkd
        '
        Me.ChbPoRkd.AutoSize = True
        Me.ChbPoRkd.Location = New System.Drawing.Point(41, 231)
        Me.ChbPoRkd.Name = "ChbPoRkd"
        Me.ChbPoRkd.Size = New System.Drawing.Size(108, 16)
        Me.ChbPoRkd.TabIndex = 16
        Me.ChbPoRkd.Text = "采购入库(CGRK)"
        Me.ChbPoRkd.UseVisualStyleBackColor = True
        '
        'ChbInvCkd
        '
        Me.ChbInvCkd.AutoSize = True
        Me.ChbInvCkd.Location = New System.Drawing.Point(41, 251)
        Me.ChbInvCkd.Name = "ChbInvCkd"
        Me.ChbInvCkd.Size = New System.Drawing.Size(108, 16)
        Me.ChbInvCkd.TabIndex = 20
        Me.ChbInvCkd.Text = "材料出库(LLCK)"
        Me.ChbInvCkd.UseVisualStyleBackColor = True
        '
        'TxtCkdm
        '
        Me.TxtCkdm.Location = New System.Drawing.Point(115, 207)
        Me.TxtCkdm.MaxLength = 30
        Me.TxtCkdm.Name = "TxtCkdm"
        Me.TxtCkdm.Size = New System.Drawing.Size(391, 21)
        Me.TxtCkdm.TabIndex = 15
        '
        'LblCkdm
        '
        Me.LblCkdm.AutoSize = True
        Me.LblCkdm.Location = New System.Drawing.Point(42, 211)
        Me.LblCkdm.Name = "LblCkdm"
        Me.LblCkdm.Size = New System.Drawing.Size(65, 12)
        Me.LblCkdm.TabIndex = 14
        Me.LblCkdm.Text = "仓库编码："
        '
        'ChbKcqcye
        '
        Me.ChbKcqcye.AutoSize = True
        Me.ChbKcqcye.Enabled = False
        Me.ChbKcqcye.Location = New System.Drawing.Point(150, 367)
        Me.ChbKcqcye.Name = "ChbKcqcye"
        Me.ChbKcqcye.Size = New System.Drawing.Size(96, 16)
        Me.ChbKcqcye.TabIndex = 25
        Me.ChbKcqcye.Text = "库存期初余额"
        Me.ChbKcqcye.UseVisualStyleBackColor = True
        '
        'BtnWrite
        '
        Me.BtnWrite.Enabled = False
        Me.BtnWrite.Location = New System.Drawing.Point(41, 421)
        Me.BtnWrite.Name = "BtnWrite"
        Me.BtnWrite.Size = New System.Drawing.Size(192, 23)
        Me.BtnWrite.TabIndex = 27
        Me.BtnWrite.Text = "回写NC生产入库成本"
        Me.BtnWrite.UseVisualStyleBackColor = True
        '
        'ChbCpdm
        '
        Me.ChbCpdm.AutoSize = True
        Me.ChbCpdm.Location = New System.Drawing.Point(41, 367)
        Me.ChbCpdm.Name = "ChbCpdm"
        Me.ChbCpdm.Size = New System.Drawing.Size(72, 16)
        Me.ChbCpdm.TabIndex = 24
        Me.ChbCpdm.Text = "物料信息"
        Me.ChbCpdm.UseVisualStyleBackColor = True
        '
        'ChbQtck
        '
        Me.ChbQtck.AutoSize = True
        Me.ChbQtck.Location = New System.Drawing.Point(413, 251)
        Me.ChbQtck.Name = "ChbQtck"
        Me.ChbQtck.Size = New System.Drawing.Size(108, 16)
        Me.ChbQtck.TabIndex = 23
        Me.ChbQtck.Text = "其它出库(CKTZ)"
        Me.ChbQtck.UseVisualStyleBackColor = True
        '
        'ChbQtrk
        '
        Me.ChbQtrk.AutoSize = True
        Me.ChbQtrk.Location = New System.Drawing.Point(413, 231)
        Me.ChbQtrk.Name = "ChbQtrk"
        Me.ChbQtrk.Size = New System.Drawing.Size(108, 16)
        Me.ChbQtrk.TabIndex = 19
        Me.ChbQtrk.Text = "其它入库(RKTZ)"
        Me.ChbQtrk.UseVisualStyleBackColor = True
        '
        'ChbInvRkd2
        '
        Me.ChbInvRkd2.AutoSize = True
        Me.ChbInvRkd2.Location = New System.Drawing.Point(277, 231)
        Me.ChbInvRkd2.Name = "ChbInvRkd2"
        Me.ChbInvRkd2.Size = New System.Drawing.Size(132, 16)
        Me.ChbInvRkd2.TabIndex = 18
        Me.ChbInvRkd2.Text = "委外加工入库(WWRK)"
        Me.ChbInvRkd2.UseVisualStyleBackColor = True
        '
        'ChbOeXsfp
        '
        Me.ChbOeXsfp.AutoSize = True
        Me.ChbOeXsfp.Location = New System.Drawing.Point(41, 293)
        Me.ChbOeXsfp.Name = "ChbOeXsfp"
        Me.ChbOeXsfp.Size = New System.Drawing.Size(108, 16)
        Me.ChbOeXsfp.TabIndex = 29
        Me.ChbOeXsfp.Text = "销售发票(XSFP)"
        Me.ChbOeXsfp.UseVisualStyleBackColor = True
        '
        'LblFph
        '
        Me.LblFph.AutoSize = True
        Me.LblFph.Location = New System.Drawing.Point(196, 295)
        Me.LblFph.Name = "LblFph"
        Me.LblFph.Size = New System.Drawing.Size(209, 12)
        Me.LblFph.TabIndex = 32
        Me.LblFph.Text = "销售发票表头发票号的自定义属性序号"
        '
        'CmbFph
        '
        Me.CmbFph.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbFph.FormattingEnabled = True
        Me.CmbFph.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30"})
        Me.CmbFph.Location = New System.Drawing.Point(413, 291)
        Me.CmbFph.Name = "CmbFph"
        Me.CmbFph.Size = New System.Drawing.Size(60, 20)
        Me.CmbFph.TabIndex = 33
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(148, 273)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(257, 12)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "销售订单表体折扣原物料编码的自定义属性序号"
        '
        'CmbZkCpdm
        '
        Me.CmbZkCpdm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbZkCpdm.FormattingEnabled = True
        Me.CmbZkCpdm.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30"})
        Me.CmbZkCpdm.Location = New System.Drawing.Point(413, 269)
        Me.CmbZkCpdm.Name = "CmbZkCpdm"
        Me.CmbZkCpdm.Size = New System.Drawing.Size(60, 20)
        Me.CmbZkCpdm.TabIndex = 35
        '
        'ChbOeZgys
        '
        Me.ChbOeZgys.AutoSize = True
        Me.ChbOeZgys.Location = New System.Drawing.Point(41, 315)
        Me.ChbOeZgys.Name = "ChbOeZgys"
        Me.ChbOeZgys.Size = New System.Drawing.Size(108, 16)
        Me.ChbOeZgys.TabIndex = 36
        Me.ChbOeZgys.Text = "暂估应收(ZGYS)"
        Me.ChbOeZgys.UseVisualStyleBackColor = True
        '
        'TxtNCCkdm
        '
        Me.TxtNCCkdm.Location = New System.Drawing.Point(115, 188)
        Me.TxtNCCkdm.MaxLength = 30
        Me.TxtNCCkdm.Name = "TxtNCCkdm"
        Me.TxtNCCkdm.Size = New System.Drawing.Size(391, 21)
        Me.TxtNCCkdm.TabIndex = 37
        '
        'FrmImpNC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(555, 458)
        Me.Controls.Add(Me.TxtNCCkdm)
        Me.Controls.Add(Me.ChbOeZgys)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CmbZkCpdm)
        Me.Controls.Add(Me.LblFph)
        Me.Controls.Add(Me.CmbFph)
        Me.Controls.Add(Me.ChbOeXsfp)
        Me.Controls.Add(Me.ChbInvRkd2)
        Me.Controls.Add(Me.ChbQtrk)
        Me.Controls.Add(Me.ChbQtck)
        Me.Controls.Add(Me.ChbCpdm)
        Me.Controls.Add(Me.BtnWrite)
        Me.Controls.Add(Me.ChbKcqcye)
        Me.Controls.Add(Me.TxtCkdm)
        Me.Controls.Add(Me.LblCkdm)
        Me.Controls.Add(Me.ChbInvCkd)
        Me.Controls.Add(Me.ChbPoRkd)
        Me.Controls.Add(Me.ChbInvDbd)
        Me.Controls.Add(Me.ChbOeXsck)
        Me.Controls.Add(Me.ChbInvRkd1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ChbKh)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.ChbSkd)
        Me.Controls.Add(Me.ChbQc)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.ChbPz)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.NudMonth)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NudYear)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmImpNC"
        Me.Text = "导入用友NC数据"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.NudYear, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.NudMonth, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.ChbPz, 0)
        Me.Controls.SetChildIndex(Me.ProgressBar1, 0)
        Me.Controls.SetChildIndex(Me.ChbQc, 0)
        Me.Controls.SetChildIndex(Me.ChbSkd, 0)
        Me.Controls.SetChildIndex(Me.ComboBox1, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.ChbKh, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.ComboBox2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.ChbInvRkd1, 0)
        Me.Controls.SetChildIndex(Me.ChbOeXsck, 0)
        Me.Controls.SetChildIndex(Me.ChbInvDbd, 0)
        Me.Controls.SetChildIndex(Me.ChbPoRkd, 0)
        Me.Controls.SetChildIndex(Me.ChbInvCkd, 0)
        Me.Controls.SetChildIndex(Me.LblCkdm, 0)
        Me.Controls.SetChildIndex(Me.TxtCkdm, 0)
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.ChbKcqcye, 0)
        Me.Controls.SetChildIndex(Me.BtnWrite, 0)
        Me.Controls.SetChildIndex(Me.ChbCpdm, 0)
        Me.Controls.SetChildIndex(Me.ChbQtck, 0)
        Me.Controls.SetChildIndex(Me.ChbQtrk, 0)
        Me.Controls.SetChildIndex(Me.ChbInvRkd2, 0)
        Me.Controls.SetChildIndex(Me.ChbOeXsfp, 0)
        Me.Controls.SetChildIndex(Me.CmbFph, 0)
        Me.Controls.SetChildIndex(Me.LblFph, 0)
        Me.Controls.SetChildIndex(Me.CmbZkCpdm, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.ChbOeZgys, 0)
        Me.Controls.SetChildIndex(Me.TxtNCCkdm, 0)
        Me.DlgPanel.ResumeLayout(False)
        CType(Me.NudMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents NudMonth As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NudYear As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ChbPz As System.Windows.Forms.CheckBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents ChbQc As System.Windows.Forms.CheckBox
    Friend WithEvents ChbSkd As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ChbKh As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents ChbInvRkd1 As CheckBox
    Friend WithEvents ChbOeXsck As CheckBox
    Friend WithEvents ChbInvDbd As CheckBox
    Friend WithEvents ChbPoRkd As CheckBox
    Friend WithEvents ChbInvCkd As CheckBox
    Public WithEvents TxtCkdm As TextBox
    Public WithEvents LblCkdm As Label
    Friend WithEvents ChbKcqcye As CheckBox
    Friend WithEvents BtnWrite As Button
    Friend WithEvents ChbCpdm As CheckBox
    Friend WithEvents ChbQtck As CheckBox
    Friend WithEvents ChbQtrk As CheckBox
    Friend WithEvents ChbInvRkd2 As CheckBox
    Friend WithEvents ChbOeXsfp As CheckBox
    Friend WithEvents LblFph As Label
    Friend WithEvents CmbFph As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents CmbZkCpdm As ComboBox
    Friend WithEvents ChbOeZgys As CheckBox
    Public WithEvents TxtNCCkdm As TextBox
End Class
