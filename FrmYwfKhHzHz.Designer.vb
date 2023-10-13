<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmYwfKhHzHz
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NudMonthBegin = New System.Windows.Forms.NumericUpDown()
        Me.NudYear = New System.Windows.Forms.NumericUpDown()
        Me.TxtZydm = New System.Windows.Forms.TextBox()
        Me.LblZydm = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NudMonthEnd = New System.Windows.Forms.NumericUpDown()
        Me.TxtKhdm = New System.Windows.Forms.TextBox()
        Me.LblKhdm = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
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
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.DlgPanel.SuspendLayout()
        CType(Me.NudMonthBegin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudMonthEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(275, 400)
        Me.DlgPanel.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(79, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "会计期间："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(327, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "月至"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(247, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "年"
        '
        'NudMonthBegin
        '
        Me.NudMonthBegin.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NudMonthBegin.Location = New System.Drawing.Point(279, 21)
        Me.NudMonthBegin.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NudMonthBegin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudMonthBegin.Name = "NudMonthBegin"
        Me.NudMonthBegin.Size = New System.Drawing.Size(40, 26)
        Me.NudMonthBegin.TabIndex = 3
        Me.NudMonthBegin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudMonthBegin.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NudYear
        '
        Me.NudYear.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NudYear.Location = New System.Drawing.Point(175, 21)
        Me.NudYear.Maximum = New Decimal(New Integer() {2050, 0, 0, 0})
        Me.NudYear.Minimum = New Decimal(New Integer() {1990, 0, 0, 0})
        Me.NudYear.Name = "NudYear"
        Me.NudYear.Size = New System.Drawing.Size(64, 26)
        Me.NudYear.TabIndex = 1
        Me.NudYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudYear.Value = New Decimal(New Integer() {1990, 0, 0, 0})
        '
        'TxtZydm
        '
        Me.TxtZydm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtZydm.Location = New System.Drawing.Point(175, 55)
        Me.TxtZydm.MaxLength = 12
        Me.TxtZydm.Name = "TxtZydm"
        Me.TxtZydm.Size = New System.Drawing.Size(112, 26)
        Me.TxtZydm.TabIndex = 8
        '
        'LblZydm
        '
        Me.LblZydm.AutoSize = True
        Me.LblZydm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblZydm.Location = New System.Drawing.Point(79, 59)
        Me.LblZydm.Name = "LblZydm"
        Me.LblZydm.Size = New System.Drawing.Size(88, 16)
        Me.LblZydm.TabIndex = 7
        Me.LblZydm.Text = "职员编码："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.Location = New System.Drawing.Point(417, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "月"
        '
        'NudMonthEnd
        '
        Me.NudMonthEnd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NudMonthEnd.Location = New System.Drawing.Point(369, 21)
        Me.NudMonthEnd.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NudMonthEnd.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudMonthEnd.Name = "NudMonthEnd"
        Me.NudMonthEnd.Size = New System.Drawing.Size(40, 26)
        Me.NudMonthEnd.TabIndex = 5
        Me.NudMonthEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudMonthEnd.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'TxtKhdm
        '
        Me.TxtKhdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtKhdm.Location = New System.Drawing.Point(175, 89)
        Me.TxtKhdm.MaxLength = 12
        Me.TxtKhdm.Name = "TxtKhdm"
        Me.TxtKhdm.Size = New System.Drawing.Size(112, 26)
        Me.TxtKhdm.TabIndex = 11
        '
        'LblKhdm
        '
        Me.LblKhdm.AutoSize = True
        Me.LblKhdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblKhdm.Location = New System.Drawing.Point(79, 93)
        Me.LblKhdm.Name = "LblKhdm"
        Me.LblKhdm.Size = New System.Drawing.Size(88, 16)
        Me.LblKhdm.TabIndex = 10
        Me.LblKhdm.Text = "客户编码："
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtKhdm)
        Me.GroupBox1.Controls.Add(Me.NudYear)
        Me.GroupBox1.Controls.Add(Me.LblKhdm)
        Me.GroupBox1.Controls.Add(Me.NudMonthBegin)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.NudMonthEnd)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TxtZydm)
        Me.GroupBox1.Controls.Add(Me.LblZydm)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(528, 131)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TabControl1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 131)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(528, 257)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(3, 17)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(522, 237)
        Me.TabControl1.TabIndex = 0
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
        Me.TabPage1.Size = New System.Drawing.Size(514, 211)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "选择核算单位"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ListBoxYuxuanDwdm
        '
        Me.ListBoxYuxuanDwdm.ItemHeight = 12
        Me.ListBoxYuxuanDwdm.Location = New System.Drawing.Point(6, 35)
        Me.ListBoxYuxuanDwdm.Name = "ListBoxYuxuanDwdm"
        Me.ListBoxYuxuanDwdm.Size = New System.Drawing.Size(202, 172)
        Me.ListBoxYuxuanDwdm.Sorted = True
        Me.ListBoxYuxuanDwdm.TabIndex = 23
        '
        'ListBoxYixuanDwdm
        '
        Me.ListBoxYixuanDwdm.ItemHeight = 12
        Me.ListBoxYixuanDwdm.Location = New System.Drawing.Point(307, 35)
        Me.ListBoxYixuanDwdm.Name = "ListBoxYixuanDwdm"
        Me.ListBoxYixuanDwdm.Size = New System.Drawing.Size(202, 172)
        Me.ListBoxYixuanDwdm.Sorted = True
        Me.ListBoxYixuanDwdm.TabIndex = 24
        '
        'BtnSelectAllDwdm
        '
        Me.BtnSelectAllDwdm.Location = New System.Drawing.Point(219, 43)
        Me.BtnSelectAllDwdm.Name = "BtnSelectAllDwdm"
        Me.BtnSelectAllDwdm.Size = New System.Drawing.Size(75, 23)
        Me.BtnSelectAllDwdm.TabIndex = 17
        Me.BtnSelectAllDwdm.Text = "-->>"
        '
        'BtnSelectOneDwdm
        '
        Me.BtnSelectOneDwdm.Location = New System.Drawing.Point(219, 83)
        Me.BtnSelectOneDwdm.Name = "BtnSelectOneDwdm"
        Me.BtnSelectOneDwdm.Size = New System.Drawing.Size(75, 23)
        Me.BtnSelectOneDwdm.TabIndex = 18
        Me.BtnSelectOneDwdm.Text = "-->"
        '
        'BtnUnSelectOneDwdm
        '
        Me.BtnUnSelectOneDwdm.Location = New System.Drawing.Point(219, 123)
        Me.BtnUnSelectOneDwdm.Name = "BtnUnSelectOneDwdm"
        Me.BtnUnSelectOneDwdm.Size = New System.Drawing.Size(75, 23)
        Me.BtnUnSelectOneDwdm.TabIndex = 19
        Me.BtnUnSelectOneDwdm.Text = "<--"
        '
        'BtnUnSelectAllDwdm
        '
        Me.BtnUnSelectAllDwdm.Location = New System.Drawing.Point(219, 163)
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
        Me.LblYixuanDwdm.Location = New System.Drawing.Point(307, 11)
        Me.LblYixuanDwdm.Name = "LblYixuanDwdm"
        Me.LblYixuanDwdm.Size = New System.Drawing.Size(77, 12)
        Me.LblYixuanDwdm.TabIndex = 22
        Me.LblYixuanDwdm.Text = "已选核算单位"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.ForeColor = System.Drawing.Color.Blue
        Me.CheckBox1.Location = New System.Drawing.Point(35, 407)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(204, 16)
        Me.CheckBox1.TabIndex = 2
        Me.CheckBox1.Text = "不显示没有发生额没有余额的数据"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'FrmYwfKhHzHz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 444)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmYwfKhHzHz"
        Me.Text = "汇总业务费客户汇总表"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.CheckBox1, 0)
        Me.DlgPanel.ResumeLayout(False)
        CType(Me.NudMonthBegin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudMonthEnd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NudMonthBegin As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudYear As System.Windows.Forms.NumericUpDown
    Public WithEvents TxtZydm As System.Windows.Forms.TextBox
    Public WithEvents LblZydm As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents NudMonthEnd As System.Windows.Forms.NumericUpDown
    Public WithEvents TxtKhdm As System.Windows.Forms.TextBox
    Public WithEvents LblKhdm As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents ListBoxYuxuanDwdm As ListBox
    Friend WithEvents ListBoxYixuanDwdm As ListBox
    Friend WithEvents BtnSelectAllDwdm As Button
    Friend WithEvents BtnSelectOneDwdm As Button
    Friend WithEvents BtnUnSelectOneDwdm As Button
    Friend WithEvents BtnUnSelectAllDwdm As Button
    Friend WithEvents LblYuxuanDwdm As Label
    Friend WithEvents LblYixuanDwdm As Label
    Friend WithEvents CheckBox1 As CheckBox
End Class
