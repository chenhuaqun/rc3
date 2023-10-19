<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGlZlfx
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
        Me.ListBoxYuxuanKmdm = New System.Windows.Forms.ListBox()
        Me.ListBoxYixuanKmdm = New System.Windows.Forms.ListBox()
        Me.BtnSelectAllKmdm = New System.Windows.Forms.Button()
        Me.BtnSelectOneKmdm = New System.Windows.Forms.Button()
        Me.BtnUnSelectOneKmdm = New System.Windows.Forms.Button()
        Me.BtnUnSelectAllKmdm = New System.Windows.Forms.Button()
        Me.LblYuxuanKmdm = New System.Windows.Forms.Label()
        Me.LblYixuanKmdm = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ChbBGuaKao = New System.Windows.Forms.CheckBox()
        Me.ChbBNotGuaKao = New System.Windows.Forms.CheckBox()
        Me.DlgPanel.SuspendLayout()
        CType(Me.NudMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(275, 363)
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.RadioButton2.Location = New System.Drawing.Point(171, 71)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(170, 20)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "供应商(按贷方分析)"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.RadioButton1.Location = New System.Drawing.Point(9, 71)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(154, 20)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "客户(按借方分析)"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(342, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 16)
        Me.Label3.TabIndex = 118
        Me.Label3.Text = "月"
        '
        'NudMonth
        '
        Me.NudMonth.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NudMonth.Location = New System.Drawing.Point(289, 27)
        Me.NudMonth.Maximum = New Decimal(New Integer() {13, 0, 0, 0})
        Me.NudMonth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudMonth.Name = "NudMonth"
        Me.NudMonth.Size = New System.Drawing.Size(45, 26)
        Me.NudMonth.TabIndex = 117
        Me.NudMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudMonth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(257, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 116
        Me.Label2.Text = "年"
        '
        'NudYear
        '
        Me.NudYear.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NudYear.Location = New System.Drawing.Point(190, 27)
        Me.NudYear.Maximum = New Decimal(New Integer() {2050, 0, 0, 0})
        Me.NudYear.Minimum = New Decimal(New Integer() {1951, 0, 0, 0})
        Me.NudYear.Name = "NudYear"
        Me.NudYear.Size = New System.Drawing.Size(59, 26)
        Me.NudYear.TabIndex = 115
        Me.NudYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudYear.Value = New Decimal(New Integer() {1999, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(94, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 114
        Me.Label1.Text = "会计期间："
        '
        'GroupBox2
        '
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
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(528, 103)
        Me.GroupBox2.TabIndex = 119
        Me.GroupBox2.TabStop = False
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.RadioButton3.Location = New System.Drawing.Point(349, 71)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(170, 20)
        Me.RadioButton3.TabIndex = 119
        Me.RadioButton3.Text = "供应商(按借方分析)"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'LblMsg
        '
        Me.LblMsg.AutoSize = True
        Me.LblMsg.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblMsg.ForeColor = System.Drawing.Color.Navy
        Me.LblMsg.Location = New System.Drawing.Point(13, 327)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(88, 16)
        Me.LblMsg.TabIndex = 120
        Me.LblMsg.Text = "提示信息。"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ListBoxYuxuanKmdm)
        Me.GroupBox1.Controls.Add(Me.ListBoxYixuanKmdm)
        Me.GroupBox1.Controls.Add(Me.BtnSelectAllKmdm)
        Me.GroupBox1.Controls.Add(Me.BtnSelectOneKmdm)
        Me.GroupBox1.Controls.Add(Me.BtnUnSelectOneKmdm)
        Me.GroupBox1.Controls.Add(Me.BtnUnSelectAllKmdm)
        Me.GroupBox1.Controls.Add(Me.LblYuxuanKmdm)
        Me.GroupBox1.Controls.Add(Me.LblYixuanKmdm)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 103)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(528, 209)
        Me.GroupBox1.TabIndex = 121
        Me.GroupBox1.TabStop = False
        '
        'ListBoxYuxuanKmdm
        '
        Me.ListBoxYuxuanKmdm.ItemHeight = 12
        Me.ListBoxYuxuanKmdm.Location = New System.Drawing.Point(14, 41)
        Me.ListBoxYuxuanKmdm.Name = "ListBoxYuxuanKmdm"
        Me.ListBoxYuxuanKmdm.Size = New System.Drawing.Size(200, 160)
        Me.ListBoxYuxuanKmdm.Sorted = True
        Me.ListBoxYuxuanKmdm.TabIndex = 23
        '
        'ListBoxYixuanKmdm
        '
        Me.ListBoxYixuanKmdm.ItemHeight = 12
        Me.ListBoxYixuanKmdm.Location = New System.Drawing.Point(315, 41)
        Me.ListBoxYixuanKmdm.Name = "ListBoxYixuanKmdm"
        Me.ListBoxYixuanKmdm.Size = New System.Drawing.Size(200, 160)
        Me.ListBoxYixuanKmdm.Sorted = True
        Me.ListBoxYixuanKmdm.TabIndex = 24
        '
        'BtnSelectAllKmdm
        '
        Me.BtnSelectAllKmdm.Location = New System.Drawing.Point(227, 49)
        Me.BtnSelectAllKmdm.Name = "BtnSelectAllKmdm"
        Me.BtnSelectAllKmdm.Size = New System.Drawing.Size(75, 23)
        Me.BtnSelectAllKmdm.TabIndex = 17
        Me.BtnSelectAllKmdm.Text = "-->>"
        '
        'BtnSelectOneKmdm
        '
        Me.BtnSelectOneKmdm.Location = New System.Drawing.Point(227, 89)
        Me.BtnSelectOneKmdm.Name = "BtnSelectOneKmdm"
        Me.BtnSelectOneKmdm.Size = New System.Drawing.Size(75, 23)
        Me.BtnSelectOneKmdm.TabIndex = 18
        Me.BtnSelectOneKmdm.Text = "-->"
        '
        'BtnUnSelectOneKmdm
        '
        Me.BtnUnSelectOneKmdm.Location = New System.Drawing.Point(227, 129)
        Me.BtnUnSelectOneKmdm.Name = "BtnUnSelectOneKmdm"
        Me.BtnUnSelectOneKmdm.Size = New System.Drawing.Size(75, 23)
        Me.BtnUnSelectOneKmdm.TabIndex = 19
        Me.BtnUnSelectOneKmdm.Text = "<--"
        '
        'BtnUnSelectAllKmdm
        '
        Me.BtnUnSelectAllKmdm.Location = New System.Drawing.Point(227, 169)
        Me.BtnUnSelectAllKmdm.Name = "BtnUnSelectAllKmdm"
        Me.BtnUnSelectAllKmdm.Size = New System.Drawing.Size(75, 23)
        Me.BtnUnSelectAllKmdm.TabIndex = 20
        Me.BtnUnSelectAllKmdm.Text = "<<--"
        '
        'LblYuxuanKmdm
        '
        Me.LblYuxuanKmdm.AutoSize = True
        Me.LblYuxuanKmdm.Location = New System.Drawing.Point(14, 17)
        Me.LblYuxuanKmdm.Name = "LblYuxuanKmdm"
        Me.LblYuxuanKmdm.Size = New System.Drawing.Size(53, 12)
        Me.LblYuxuanKmdm.TabIndex = 21
        Me.LblYuxuanKmdm.Text = "预选科目"
        '
        'LblYixuanKmdm
        '
        Me.LblYixuanKmdm.AutoSize = True
        Me.LblYixuanKmdm.Location = New System.Drawing.Point(315, 17)
        Me.LblYixuanKmdm.Name = "LblYixuanKmdm"
        Me.LblYixuanKmdm.Size = New System.Drawing.Size(53, 12)
        Me.LblYixuanKmdm.TabIndex = 22
        Me.LblYixuanKmdm.Text = "已选科目"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.ForeColor = System.Drawing.Color.Blue
        Me.CheckBox1.Location = New System.Drawing.Point(14, 378)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(204, 16)
        Me.CheckBox1.TabIndex = 122
        Me.CheckBox1.Text = "不显示没有发生额没有余额的数据"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ChbBGuaKao
        '
        Me.ChbBGuaKao.AutoSize = True
        Me.ChbBGuaKao.ForeColor = System.Drawing.Color.Blue
        Me.ChbBGuaKao.Location = New System.Drawing.Point(14, 356)
        Me.ChbBGuaKao.Name = "ChbBGuaKao"
        Me.ChbBGuaKao.Size = New System.Drawing.Size(108, 16)
        Me.ChbBGuaKao.TabIndex = 123
        Me.ChbBGuaKao.Text = "只显示挂靠客户"
        Me.ChbBGuaKao.UseVisualStyleBackColor = True
        '
        'ChbBNotGuaKao
        '
        Me.ChbBNotGuaKao.AutoSize = True
        Me.ChbBNotGuaKao.ForeColor = System.Drawing.Color.Blue
        Me.ChbBNotGuaKao.Location = New System.Drawing.Point(130, 356)
        Me.ChbBNotGuaKao.Name = "ChbBNotGuaKao"
        Me.ChbBNotGuaKao.Size = New System.Drawing.Size(120, 16)
        Me.ChbBNotGuaKao.TabIndex = 124
        Me.ChbBNotGuaKao.Text = "只显示非挂靠客户"
        Me.ChbBNotGuaKao.UseVisualStyleBackColor = True
        '
        'FrmGlZlfx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 406)
        Me.Controls.Add(Me.ChbBNotGuaKao)
        Me.Controls.Add(Me.ChbBGuaKao)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.LblMsg)
        Me.Name = "FrmGlZlfx"
        Me.Text = "账龄分析表"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.LblMsg, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.CheckBox1, 0)
        Me.Controls.SetChildIndex(Me.ChbBGuaKao, 0)
        Me.Controls.SetChildIndex(Me.ChbBNotGuaKao, 0)
        Me.DlgPanel.ResumeLayout(False)
        CType(Me.NudMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
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
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents ChbBGuaKao As CheckBox
    Friend WithEvents ChbBNotGuaKao As CheckBox
End Class
