<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPzsc
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
        Me.RadioBtnPoRkd = New System.Windows.Forms.RadioButton
        Me.RadioBtnInvCkd = New System.Windows.Forms.RadioButton
        Me.RadioBtnInvRkd = New System.Windows.Forms.RadioButton
        Me.RadioBtnOeXsd = New System.Windows.Forms.RadioButton
        Me.RadioBtnOeQtys = New System.Windows.Forms.RadioButton
        Me.RadioBtnPoQtyf = New System.Windows.Forms.RadioButton
        Me.RadioBtnArSkd = New System.Windows.Forms.RadioButton
        Me.RadioBtnApFkd = New System.Windows.Forms.RadioButton
        Me.rcDataGridView = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.NudMonth = New System.Windows.Forms.NumericUpDown
        Me.NudYear = New System.Windows.Forms.NumericUpDown
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BtnImp = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.BtnPzsc = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.BtnExit = New System.Windows.Forms.Button
        Me.BtnUnSelectAll = New System.Windows.Forms.Button
        Me.BtnSelectAll = New System.Windows.Forms.Button
        Me.ColXz = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ColDjh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColPzrq = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColJe = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RadioBtnPoRkd
        '
        Me.RadioBtnPoRkd.AutoSize = True
        Me.RadioBtnPoRkd.Checked = True
        Me.RadioBtnPoRkd.Location = New System.Drawing.Point(21, 20)
        Me.RadioBtnPoRkd.Name = "RadioBtnPoRkd"
        Me.RadioBtnPoRkd.Size = New System.Drawing.Size(269, 16)
        Me.RadioBtnPoRkd.TabIndex = 0
        Me.RadioBtnPoRkd.TabStop = True
        Me.RadioBtnPoRkd.Text = "物料入库单      借:原材料     贷:应付账款"
        Me.RadioBtnPoRkd.UseVisualStyleBackColor = True
        '
        'RadioBtnInvCkd
        '
        Me.RadioBtnInvCkd.AutoSize = True
        Me.RadioBtnInvCkd.Location = New System.Drawing.Point(21, 44)
        Me.RadioBtnInvCkd.Name = "RadioBtnInvCkd"
        Me.RadioBtnInvCkd.Size = New System.Drawing.Size(257, 16)
        Me.RadioBtnInvCkd.TabIndex = 1
        Me.RadioBtnInvCkd.Text = "物料出库单      借:生产成本   贷:原材料"
        Me.RadioBtnInvCkd.UseVisualStyleBackColor = True
        '
        'RadioBtnInvRkd
        '
        Me.RadioBtnInvRkd.AutoSize = True
        Me.RadioBtnInvRkd.Location = New System.Drawing.Point(21, 68)
        Me.RadioBtnInvRkd.Name = "RadioBtnInvRkd"
        Me.RadioBtnInvRkd.Size = New System.Drawing.Size(269, 16)
        Me.RadioBtnInvRkd.TabIndex = 2
        Me.RadioBtnInvRkd.Text = "产品入库单      借:库存商品   贷:生产成本"
        Me.RadioBtnInvRkd.UseVisualStyleBackColor = True
        '
        'RadioBtnOeXsd
        '
        Me.RadioBtnOeXsd.AutoSize = True
        Me.RadioBtnOeXsd.Location = New System.Drawing.Point(21, 92)
        Me.RadioBtnOeXsd.Name = "RadioBtnOeXsd"
        Me.RadioBtnOeXsd.Size = New System.Drawing.Size(293, 16)
        Me.RadioBtnOeXsd.TabIndex = 3
        Me.RadioBtnOeXsd.Text = "产品送货单      借:应收账款   贷:主营业务收入"
        Me.RadioBtnOeXsd.UseVisualStyleBackColor = True
        '
        'RadioBtnOeQtys
        '
        Me.RadioBtnOeQtys.AutoSize = True
        Me.RadioBtnOeQtys.Location = New System.Drawing.Point(21, 116)
        Me.RadioBtnOeQtys.Name = "RadioBtnOeQtys"
        Me.RadioBtnOeQtys.Size = New System.Drawing.Size(293, 16)
        Me.RadioBtnOeQtys.TabIndex = 4
        Me.RadioBtnOeQtys.Text = "其他应收单      借:应收账款   贷:主营业务收入"
        Me.RadioBtnOeQtys.UseVisualStyleBackColor = True
        '
        'RadioBtnPoQtyf
        '
        Me.RadioBtnPoQtyf.AutoSize = True
        Me.RadioBtnPoQtyf.Location = New System.Drawing.Point(21, 140)
        Me.RadioBtnPoQtyf.Name = "RadioBtnPoQtyf"
        Me.RadioBtnPoQtyf.Size = New System.Drawing.Size(269, 16)
        Me.RadioBtnPoQtyf.TabIndex = 5
        Me.RadioBtnPoQtyf.Text = "其他应付单      借:原材料     贷:应付账款"
        Me.RadioBtnPoQtyf.UseVisualStyleBackColor = True
        '
        'RadioBtnArSkd
        '
        Me.RadioBtnArSkd.AutoSize = True
        Me.RadioBtnArSkd.Location = New System.Drawing.Point(21, 164)
        Me.RadioBtnArSkd.Name = "RadioBtnArSkd"
        Me.RadioBtnArSkd.Size = New System.Drawing.Size(269, 16)
        Me.RadioBtnArSkd.TabIndex = 6
        Me.RadioBtnArSkd.Text = "收款单          借:现金       贷:应收账款"
        Me.RadioBtnArSkd.UseVisualStyleBackColor = True
        '
        'RadioBtnApFkd
        '
        Me.RadioBtnApFkd.AutoSize = True
        Me.RadioBtnApFkd.Location = New System.Drawing.Point(21, 188)
        Me.RadioBtnApFkd.Name = "RadioBtnApFkd"
        Me.RadioBtnApFkd.Size = New System.Drawing.Size(245, 16)
        Me.RadioBtnApFkd.TabIndex = 7
        Me.RadioBtnApFkd.Text = "付款单          借:应付账款   贷:现金"
        Me.RadioBtnApFkd.UseVisualStyleBackColor = True
        '
        'rcDataGridView
        '
        Me.rcDataGridView.AllowUserToAddRows = False
        Me.rcDataGridView.AllowUserToDeleteRows = False
        Me.rcDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.rcDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColXz, Me.ColDjh, Me.ColPzrq, Me.ColJe})
        Me.rcDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rcDataGridView.Location = New System.Drawing.Point(402, 0)
        Me.rcDataGridView.Name = "rcDataGridView"
        Me.rcDataGridView.RowTemplate.Height = 23
        Me.rcDataGridView.Size = New System.Drawing.Size(382, 564)
        Me.rcDataGridView.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(142, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 110
        Me.Label3.Text = "月"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(74, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 12)
        Me.Label2.TabIndex = 108
        Me.Label2.Text = "年"
        '
        'NudMonth
        '
        Me.NudMonth.Location = New System.Drawing.Point(97, 23)
        Me.NudMonth.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NudMonth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudMonth.Name = "NudMonth"
        Me.NudMonth.Size = New System.Drawing.Size(39, 21)
        Me.NudMonth.TabIndex = 109
        Me.NudMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudMonth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NudYear
        '
        Me.NudYear.Location = New System.Drawing.Point(17, 23)
        Me.NudYear.Maximum = New Decimal(New Integer() {2050, 0, 0, 0})
        Me.NudYear.Minimum = New Decimal(New Integer() {1990, 0, 0, 0})
        Me.NudYear.Name = "NudYear"
        Me.NudYear.Size = New System.Drawing.Size(51, 21)
        Me.NudYear.TabIndex = 107
        Me.NudYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudYear.Value = New Decimal(New Integer() {1990, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 310)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(365, 26)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "注：现金是广义上的现金,包括库存现金、银行存款、其他货币资金"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioBtnPoRkd)
        Me.GroupBox1.Controls.Add(Me.RadioBtnInvCkd)
        Me.GroupBox1.Controls.Add(Me.RadioBtnInvRkd)
        Me.GroupBox1.Controls.Add(Me.RadioBtnOeXsd)
        Me.GroupBox1.Controls.Add(Me.RadioBtnOeQtys)
        Me.GroupBox1.Controls.Add(Me.RadioBtnPoQtyf)
        Me.GroupBox1.Controls.Add(Me.RadioBtnArSkd)
        Me.GroupBox1.Controls.Add(Me.RadioBtnApFkd)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 83)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(365, 224)
        Me.GroupBox1.TabIndex = 112
        Me.GroupBox1.TabStop = False
        '
        'BtnImp
        '
        Me.BtnImp.Location = New System.Drawing.Point(165, 22)
        Me.BtnImp.Name = "BtnImp"
        Me.BtnImp.Size = New System.Drawing.Size(75, 23)
        Me.BtnImp.TabIndex = 113
        Me.BtnImp.Text = "读取数据"
        Me.BtnImp.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BtnImp)
        Me.GroupBox2.Controls.Add(Me.NudYear)
        Me.GroupBox2.Controls.Add(Me.NudMonth)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(24, 20)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(365, 57)
        Me.GroupBox2.TabIndex = 114
        Me.GroupBox2.TabStop = False
        '
        'BtnPzsc
        '
        Me.BtnPzsc.Location = New System.Drawing.Point(204, 339)
        Me.BtnPzsc.Name = "BtnPzsc"
        Me.BtnPzsc.Size = New System.Drawing.Size(75, 23)
        Me.BtnPzsc.TabIndex = 114
        Me.BtnPzsc.Text = "生成凭证"
        Me.BtnPzsc.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnExit)
        Me.Panel1.Controls.Add(Me.BtnUnSelectAll)
        Me.Panel1.Controls.Add(Me.BtnPzsc)
        Me.Panel1.Controls.Add(Me.BtnSelectAll)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(402, 564)
        Me.Panel1.TabIndex = 115
        '
        'BtnExit
        '
        Me.BtnExit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnExit.Location = New System.Drawing.Point(287, 339)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 23)
        Me.BtnExit.TabIndex = 117
        Me.BtnExit.Text = "退出(&X)"
        '
        'BtnUnSelectAll
        '
        Me.BtnUnSelectAll.Location = New System.Drawing.Point(121, 339)
        Me.BtnUnSelectAll.Name = "BtnUnSelectAll"
        Me.BtnUnSelectAll.Size = New System.Drawing.Size(75, 23)
        Me.BtnUnSelectAll.TabIndex = 116
        Me.BtnUnSelectAll.TabStop = False
        Me.BtnUnSelectAll.Text = "全不选"
        '
        'BtnSelectAll
        '
        Me.BtnSelectAll.Location = New System.Drawing.Point(38, 339)
        Me.BtnSelectAll.Name = "BtnSelectAll"
        Me.BtnSelectAll.Size = New System.Drawing.Size(75, 23)
        Me.BtnSelectAll.TabIndex = 115
        Me.BtnSelectAll.TabStop = False
        Me.BtnSelectAll.Text = "全选"
        '
        'ColXz
        '
        Me.ColXz.DataPropertyName = "xz"
        Me.ColXz.HeaderText = "选择"
        Me.ColXz.Name = "ColXz"
        Me.ColXz.Width = 45
        '
        'ColDjh
        '
        Me.ColDjh.DataPropertyName = "djh"
        Me.ColDjh.HeaderText = "单据号"
        Me.ColDjh.Name = "ColDjh"
        Me.ColDjh.ReadOnly = True
        Me.ColDjh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColPzrq
        '
        Me.ColPzrq.DataPropertyName = "pzrq"
        Me.ColPzrq.HeaderText = "业务日期"
        Me.ColPzrq.Name = "ColPzrq"
        '
        'ColJe
        '
        Me.ColJe.DataPropertyName = "je"
        Me.ColJe.HeaderText = "金额"
        Me.ColJe.Name = "ColJe"
        Me.ColJe.ReadOnly = True
        Me.ColJe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'FrmPzsc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 564)
        Me.Controls.Add(Me.rcDataGridView)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmPzsc"
        Me.Text = "凭证生成"
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RadioBtnPoRkd As System.Windows.Forms.RadioButton
    Friend WithEvents RadioBtnInvCkd As System.Windows.Forms.RadioButton
    Friend WithEvents RadioBtnInvRkd As System.Windows.Forms.RadioButton
    Friend WithEvents RadioBtnOeXsd As System.Windows.Forms.RadioButton
    Friend WithEvents RadioBtnOeQtys As System.Windows.Forms.RadioButton
    Friend WithEvents RadioBtnPoQtyf As System.Windows.Forms.RadioButton
    Friend WithEvents RadioBtnArSkd As System.Windows.Forms.RadioButton
    Friend WithEvents RadioBtnApFkd As System.Windows.Forms.RadioButton
    Friend WithEvents rcDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NudMonth As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudYear As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnImp As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnPzsc As System.Windows.Forms.Button
    Friend WithEvents BtnUnSelectAll As System.Windows.Forms.Button
    Friend WithEvents BtnSelectAll As System.Windows.Forms.Button
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents ColXz As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColDjh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPzrq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJe As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
