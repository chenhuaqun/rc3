<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmYwfJs
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
        Me.LblPeriod = New System.Windows.Forms.Label
        Me.LblMonth = New System.Windows.Forms.Label
        Me.LblYear = New System.Windows.Forms.Label
        Me.NudMonth = New System.Windows.Forms.NumericUpDown
        Me.NudYear = New System.Windows.Forms.NumericUpDown
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.TxtCdhp = New System.Windows.Forms.TextBox
        Me.LblCdhp = New System.Windows.Forms.Label
        Me.TxtNewKh = New System.Windows.Forms.TextBox
        Me.LblNewKh = New System.Windows.Forms.Label
        Me.TxtOldKh = New System.Windows.Forms.TextBox
        Me.LblOldKh = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.ListBoxYuxuanDwdm = New System.Windows.Forms.ListBox
        Me.ListBoxYixuanDwdm = New System.Windows.Forms.ListBox
        Me.BtnSelectAllDwdm = New System.Windows.Forms.Button
        Me.BtnSelectOneDwdm = New System.Windows.Forms.Button
        Me.BtnUnSelectOneDwdm = New System.Windows.Forms.Button
        Me.BtnUnSelectAllDwdm = New System.Windows.Forms.Button
        Me.LblYuxuanDwdm = New System.Windows.Forms.Label
        Me.LblYixuanDwdm = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.ListBoxYuxuanKmdm = New System.Windows.Forms.ListBox
        Me.ListBoxYixuanKmdm = New System.Windows.Forms.ListBox
        Me.LblYixuanKmdm = New System.Windows.Forms.Label
        Me.BtnSelectAllKmdm = New System.Windows.Forms.Button
        Me.LblYuxuanKmdm = New System.Windows.Forms.Label
        Me.BtnSelectOneKmdm = New System.Windows.Forms.Button
        Me.BtnUnSelectAllKmdm = New System.Windows.Forms.Button
        Me.BtnUnSelectOneKmdm = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.DlgPanel.SuspendLayout()
        CType(Me.NudMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(411, 404)
        Me.DlgPanel.TabIndex = 12
        '
        'LblPeriod
        '
        Me.LblPeriod.AutoSize = True
        Me.LblPeriod.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblPeriod.Location = New System.Drawing.Point(50, 23)
        Me.LblPeriod.Name = "LblPeriod"
        Me.LblPeriod.Size = New System.Drawing.Size(88, 16)
        Me.LblPeriod.TabIndex = 0
        Me.LblPeriod.Text = "会计期间："
        '
        'LblMonth
        '
        Me.LblMonth.AutoSize = True
        Me.LblMonth.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblMonth.Location = New System.Drawing.Point(298, 23)
        Me.LblMonth.Name = "LblMonth"
        Me.LblMonth.Size = New System.Drawing.Size(24, 16)
        Me.LblMonth.TabIndex = 4
        Me.LblMonth.Text = "月"
        '
        'LblYear
        '
        Me.LblYear.AutoSize = True
        Me.LblYear.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblYear.Location = New System.Drawing.Point(218, 23)
        Me.LblYear.Name = "LblYear"
        Me.LblYear.Size = New System.Drawing.Size(24, 16)
        Me.LblYear.TabIndex = 2
        Me.LblYear.Text = "年"
        '
        'NudMonth
        '
        Me.NudMonth.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NudMonth.Location = New System.Drawing.Point(250, 18)
        Me.NudMonth.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NudMonth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudMonth.Name = "NudMonth"
        Me.NudMonth.Size = New System.Drawing.Size(40, 26)
        Me.NudMonth.TabIndex = 3
        Me.NudMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudMonth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NudYear
        '
        Me.NudYear.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NudYear.Location = New System.Drawing.Point(146, 18)
        Me.NudYear.Maximum = New Decimal(New Integer() {2050, 0, 0, 0})
        Me.NudYear.Minimum = New Decimal(New Integer() {1990, 0, 0, 0})
        Me.NudYear.Name = "NudYear"
        Me.NudYear.Size = New System.Drawing.Size(64, 26)
        Me.NudYear.TabIndex = 1
        Me.NudYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudYear.Value = New Decimal(New Integer() {1990, 0, 0, 0})
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(7, 408)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(399, 23)
        Me.ProgressBar1.TabIndex = 11
        '
        'TxtCdhp
        '
        Me.TxtCdhp.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtCdhp.Location = New System.Drawing.Point(234, 96)
        Me.TxtCdhp.MaxLength = 6
        Me.TxtCdhp.Name = "TxtCdhp"
        Me.TxtCdhp.Size = New System.Drawing.Size(112, 26)
        Me.TxtCdhp.TabIndex = 10
        '
        'LblCdhp
        '
        Me.LblCdhp.AutoSize = True
        Me.LblCdhp.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblCdhp.Location = New System.Drawing.Point(18, 101)
        Me.LblCdhp.Name = "LblCdhp"
        Me.LblCdhp.Size = New System.Drawing.Size(208, 16)
        Me.LblCdhp.TabIndex = 9
        Me.LblCdhp.Text = "承兑汇票回笼下降比率(%)："
        '
        'TxtNewKh
        '
        Me.TxtNewKh.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtNewKh.Location = New System.Drawing.Point(234, 64)
        Me.TxtNewKh.MaxLength = 6
        Me.TxtNewKh.Name = "TxtNewKh"
        Me.TxtNewKh.Size = New System.Drawing.Size(112, 26)
        Me.TxtNewKh.TabIndex = 6
        '
        'LblNewKh
        '
        Me.LblNewKh.AutoSize = True
        Me.LblNewKh.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblNewKh.Location = New System.Drawing.Point(66, 69)
        Me.LblNewKh.Name = "LblNewKh"
        Me.LblNewKh.Size = New System.Drawing.Size(160, 16)
        Me.LblNewKh.TabIndex = 5
        Me.LblNewKh.Text = "新客户上升比率(%)："
        '
        'TxtOldKh
        '
        Me.TxtOldKh.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtOldKh.Location = New System.Drawing.Point(527, 64)
        Me.TxtOldKh.MaxLength = 6
        Me.TxtOldKh.Name = "TxtOldKh"
        Me.TxtOldKh.Size = New System.Drawing.Size(112, 26)
        Me.TxtOldKh.TabIndex = 8
        '
        'LblOldKh
        '
        Me.LblOldKh.AutoSize = True
        Me.LblOldKh.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblOldKh.Location = New System.Drawing.Point(359, 69)
        Me.LblOldKh.Name = "LblOldKh"
        Me.LblOldKh.Size = New System.Drawing.Size(160, 16)
        Me.LblOldKh.TabIndex = 7
        Me.LblOldKh.Text = "老客户下降比率(%)："
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TabControl1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 144)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(664, 257)
        Me.GroupBox1.TabIndex = 122
        Me.GroupBox1.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(3, 17)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(658, 237)
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
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(650, 211)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "选择核算单位"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ListBoxYuxuanDwdm
        '
        Me.ListBoxYuxuanDwdm.ItemHeight = 12
        Me.ListBoxYuxuanDwdm.Location = New System.Drawing.Point(6, 35)
        Me.ListBoxYuxuanDwdm.Name = "ListBoxYuxuanDwdm"
        Me.ListBoxYuxuanDwdm.Size = New System.Drawing.Size(270, 172)
        Me.ListBoxYuxuanDwdm.Sorted = True
        Me.ListBoxYuxuanDwdm.TabIndex = 23
        '
        'ListBoxYixuanDwdm
        '
        Me.ListBoxYixuanDwdm.ItemHeight = 12
        Me.ListBoxYixuanDwdm.Location = New System.Drawing.Point(378, 35)
        Me.ListBoxYixuanDwdm.Name = "ListBoxYixuanDwdm"
        Me.ListBoxYixuanDwdm.Size = New System.Drawing.Size(270, 172)
        Me.ListBoxYixuanDwdm.Sorted = True
        Me.ListBoxYixuanDwdm.TabIndex = 24
        '
        'BtnSelectAllDwdm
        '
        Me.BtnSelectAllDwdm.Location = New System.Drawing.Point(290, 43)
        Me.BtnSelectAllDwdm.Name = "BtnSelectAllDwdm"
        Me.BtnSelectAllDwdm.Size = New System.Drawing.Size(75, 23)
        Me.BtnSelectAllDwdm.TabIndex = 17
        Me.BtnSelectAllDwdm.Text = "-->>"
        '
        'BtnSelectOneDwdm
        '
        Me.BtnSelectOneDwdm.Location = New System.Drawing.Point(290, 83)
        Me.BtnSelectOneDwdm.Name = "BtnSelectOneDwdm"
        Me.BtnSelectOneDwdm.Size = New System.Drawing.Size(75, 23)
        Me.BtnSelectOneDwdm.TabIndex = 18
        Me.BtnSelectOneDwdm.Text = "-->"
        '
        'BtnUnSelectOneDwdm
        '
        Me.BtnUnSelectOneDwdm.Location = New System.Drawing.Point(290, 123)
        Me.BtnUnSelectOneDwdm.Name = "BtnUnSelectOneDwdm"
        Me.BtnUnSelectOneDwdm.Size = New System.Drawing.Size(75, 23)
        Me.BtnUnSelectOneDwdm.TabIndex = 19
        Me.BtnUnSelectOneDwdm.Text = "<--"
        '
        'BtnUnSelectAllDwdm
        '
        Me.BtnUnSelectAllDwdm.Location = New System.Drawing.Point(290, 163)
        Me.BtnUnSelectAllDwdm.Name = "BtnUnSelectAllDwdm"
        Me.BtnUnSelectAllDwdm.Size = New System.Drawing.Size(75, 23)
        Me.BtnUnSelectAllDwdm.TabIndex = 20
        Me.BtnUnSelectAllDwdm.Text = "<<--"
        '
        'LblYuxuanDwdm
        '
        Me.LblYuxuanDwdm.AutoSize = True
        Me.LblYuxuanDwdm.Location = New System.Drawing.Point(6, 11)
        Me.LblYuxuanDwdm.Name = "LblYuxuanDwdm"
        Me.LblYuxuanDwdm.Size = New System.Drawing.Size(77, 12)
        Me.LblYuxuanDwdm.TabIndex = 21
        Me.LblYuxuanDwdm.Text = "预选核算单位"
        '
        'LblYixuanDwdm
        '
        Me.LblYixuanDwdm.AutoSize = True
        Me.LblYixuanDwdm.Location = New System.Drawing.Point(378, 11)
        Me.LblYixuanDwdm.Name = "LblYixuanDwdm"
        Me.LblYixuanDwdm.Size = New System.Drawing.Size(77, 12)
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
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(650, 211)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "选择科目"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ListBoxYuxuanKmdm
        '
        Me.ListBoxYuxuanKmdm.ItemHeight = 12
        Me.ListBoxYuxuanKmdm.Location = New System.Drawing.Point(8, 34)
        Me.ListBoxYuxuanKmdm.Name = "ListBoxYuxuanKmdm"
        Me.ListBoxYuxuanKmdm.Size = New System.Drawing.Size(264, 160)
        Me.ListBoxYuxuanKmdm.Sorted = True
        Me.ListBoxYuxuanKmdm.TabIndex = 23
        '
        'ListBoxYixuanKmdm
        '
        Me.ListBoxYixuanKmdm.ItemHeight = 12
        Me.ListBoxYixuanKmdm.Location = New System.Drawing.Point(374, 34)
        Me.ListBoxYixuanKmdm.Name = "ListBoxYixuanKmdm"
        Me.ListBoxYixuanKmdm.Size = New System.Drawing.Size(264, 160)
        Me.ListBoxYixuanKmdm.Sorted = True
        Me.ListBoxYixuanKmdm.TabIndex = 24
        '
        'LblYixuanKmdm
        '
        Me.LblYixuanKmdm.AutoSize = True
        Me.LblYixuanKmdm.Location = New System.Drawing.Point(374, 10)
        Me.LblYixuanKmdm.Name = "LblYixuanKmdm"
        Me.LblYixuanKmdm.Size = New System.Drawing.Size(53, 12)
        Me.LblYixuanKmdm.TabIndex = 22
        Me.LblYixuanKmdm.Text = "已选科目"
        '
        'BtnSelectAllKmdm
        '
        Me.BtnSelectAllKmdm.Location = New System.Drawing.Point(286, 42)
        Me.BtnSelectAllKmdm.Name = "BtnSelectAllKmdm"
        Me.BtnSelectAllKmdm.Size = New System.Drawing.Size(75, 23)
        Me.BtnSelectAllKmdm.TabIndex = 17
        Me.BtnSelectAllKmdm.Text = "-->>"
        '
        'LblYuxuanKmdm
        '
        Me.LblYuxuanKmdm.AutoSize = True
        Me.LblYuxuanKmdm.Location = New System.Drawing.Point(8, 10)
        Me.LblYuxuanKmdm.Name = "LblYuxuanKmdm"
        Me.LblYuxuanKmdm.Size = New System.Drawing.Size(53, 12)
        Me.LblYuxuanKmdm.TabIndex = 21
        Me.LblYuxuanKmdm.Text = "预选科目"
        '
        'BtnSelectOneKmdm
        '
        Me.BtnSelectOneKmdm.Location = New System.Drawing.Point(286, 82)
        Me.BtnSelectOneKmdm.Name = "BtnSelectOneKmdm"
        Me.BtnSelectOneKmdm.Size = New System.Drawing.Size(75, 23)
        Me.BtnSelectOneKmdm.TabIndex = 18
        Me.BtnSelectOneKmdm.Text = "-->"
        '
        'BtnUnSelectAllKmdm
        '
        Me.BtnUnSelectAllKmdm.Location = New System.Drawing.Point(286, 162)
        Me.BtnUnSelectAllKmdm.Name = "BtnUnSelectAllKmdm"
        Me.BtnUnSelectAllKmdm.Size = New System.Drawing.Size(75, 23)
        Me.BtnUnSelectAllKmdm.TabIndex = 20
        Me.BtnUnSelectAllKmdm.Text = "<<--"
        '
        'BtnUnSelectOneKmdm
        '
        Me.BtnUnSelectOneKmdm.Location = New System.Drawing.Point(286, 122)
        Me.BtnUnSelectOneKmdm.Name = "BtnUnSelectOneKmdm"
        Me.BtnUnSelectOneKmdm.Size = New System.Drawing.Size(75, 23)
        Me.BtnUnSelectOneKmdm.TabIndex = 19
        Me.BtnUnSelectOneKmdm.Text = "<--"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LblNewKh)
        Me.GroupBox2.Controls.Add(Me.NudYear)
        Me.GroupBox2.Controls.Add(Me.TxtOldKh)
        Me.GroupBox2.Controls.Add(Me.NudMonth)
        Me.GroupBox2.Controls.Add(Me.LblOldKh)
        Me.GroupBox2.Controls.Add(Me.LblYear)
        Me.GroupBox2.Controls.Add(Me.TxtNewKh)
        Me.GroupBox2.Controls.Add(Me.LblMonth)
        Me.GroupBox2.Controls.Add(Me.LblPeriod)
        Me.GroupBox2.Controls.Add(Me.TxtCdhp)
        Me.GroupBox2.Controls.Add(Me.LblCdhp)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(664, 144)
        Me.GroupBox2.TabIndex = 123
        Me.GroupBox2.TabStop = False
        '
        'FrmYwfJs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(664, 447)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Name = "FrmYwfJs"
        Me.Text = "业务费计算"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.ProgressBar1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.DlgPanel.ResumeLayout(False)
        CType(Me.NudMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LblPeriod As System.Windows.Forms.Label
    Friend WithEvents LblMonth As System.Windows.Forms.Label
    Friend WithEvents LblYear As System.Windows.Forms.Label
    Friend WithEvents NudMonth As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudYear As System.Windows.Forms.NumericUpDown
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Public WithEvents TxtCdhp As System.Windows.Forms.TextBox
    Public WithEvents LblCdhp As System.Windows.Forms.Label
    Public WithEvents TxtNewKh As System.Windows.Forms.TextBox
    Public WithEvents LblNewKh As System.Windows.Forms.Label
    Public WithEvents TxtOldKh As System.Windows.Forms.TextBox
    Public WithEvents LblOldKh As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents ListBoxYuxuanDwdm As System.Windows.Forms.ListBox
    Friend WithEvents ListBoxYixuanDwdm As System.Windows.Forms.ListBox
    Friend WithEvents BtnSelectAllDwdm As System.Windows.Forms.Button
    Friend WithEvents BtnSelectOneDwdm As System.Windows.Forms.Button
    Friend WithEvents BtnUnSelectOneDwdm As System.Windows.Forms.Button
    Friend WithEvents BtnUnSelectAllDwdm As System.Windows.Forms.Button
    Friend WithEvents LblYuxuanDwdm As System.Windows.Forms.Label
    Friend WithEvents LblYixuanDwdm As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ListBoxYuxuanKmdm As System.Windows.Forms.ListBox
    Friend WithEvents ListBoxYixuanKmdm As System.Windows.Forms.ListBox
    Friend WithEvents LblYixuanKmdm As System.Windows.Forms.Label
    Friend WithEvents BtnSelectAllKmdm As System.Windows.Forms.Button
    Friend WithEvents LblYuxuanKmdm As System.Windows.Forms.Label
    Friend WithEvents BtnSelectOneKmdm As System.Windows.Forms.Button
    Friend WithEvents BtnUnSelectAllKmdm As System.Windows.Forms.Button
    Friend WithEvents BtnUnSelectOneKmdm As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class
