<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmJtchdjzb
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
        Me.components = New System.ComponentModel.Container()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.LblPcrq = New System.Windows.Forms.Label()
        Me.TxtCkdm = New System.Windows.Forms.TextBox()
        Me.LblCkdm = New System.Windows.Forms.Label()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NudMonth = New System.Windows.Forms.NumericUpDown()
        Me.NudYear = New System.Windows.Forms.NumericUpDown()
        Me.ChbYe = New System.Windows.Forms.CheckBox()
        Me.LblFadm = New System.Windows.Forms.Label()
        Me.TxtFadm = New System.Windows.Forms.TextBox()
        Me.rcDataGridView = New System.Windows.Forms.DataGridView()
        Me.ColXz = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColCkdm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCkmc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rcBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DlgPanel.SuspendLayout()
        CType(Me.NudMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(305, 402)
        Me.DlgPanel.TabIndex = 13
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(56, 334)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(421, 23)
        Me.ProgressBar1.TabIndex = 11
        '
        'LblPcrq
        '
        Me.LblPcrq.AutoSize = True
        Me.LblPcrq.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblPcrq.Location = New System.Drawing.Point(46, 29)
        Me.LblPcrq.Name = "LblPcrq"
        Me.LblPcrq.Size = New System.Drawing.Size(88, 16)
        Me.LblPcrq.TabIndex = 0
        Me.LblPcrq.Text = "会计期间："
        '
        'TxtCkdm
        '
        Me.TxtCkdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCkdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtCkdm.Location = New System.Drawing.Point(142, 58)
        Me.TxtCkdm.MaxLength = 15
        Me.TxtCkdm.Name = "TxtCkdm"
        Me.TxtCkdm.Size = New System.Drawing.Size(112, 26)
        Me.TxtCkdm.TabIndex = 6
        '
        'LblCkdm
        '
        Me.LblCkdm.AutoSize = True
        Me.LblCkdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblCkdm.Location = New System.Drawing.Point(46, 63)
        Me.LblCkdm.Name = "LblCkdm"
        Me.LblCkdm.Size = New System.Drawing.Size(88, 16)
        Me.LblCkdm.TabIndex = 5
        Me.LblCkdm.Text = "计提仓库："
        '
        'LblMsg
        '
        Me.LblMsg.AutoSize = True
        Me.LblMsg.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblMsg.ForeColor = System.Drawing.Color.Navy
        Me.LblMsg.Location = New System.Drawing.Point(56, 370)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(88, 16)
        Me.LblMsg.TabIndex = 12
        Me.LblMsg.Text = "提示信息。"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(302, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "月"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.Location = New System.Drawing.Point(214, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "年"
        '
        'NudMonth
        '
        Me.NudMonth.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NudMonth.Location = New System.Drawing.Point(246, 24)
        Me.NudMonth.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NudMonth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudMonth.Name = "NudMonth"
        Me.NudMonth.Size = New System.Drawing.Size(48, 26)
        Me.NudMonth.TabIndex = 3
        Me.NudMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudMonth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NudYear
        '
        Me.NudYear.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NudYear.Location = New System.Drawing.Point(142, 24)
        Me.NudYear.Maximum = New Decimal(New Integer() {2050, 0, 0, 0})
        Me.NudYear.Minimum = New Decimal(New Integer() {1990, 0, 0, 0})
        Me.NudYear.Name = "NudYear"
        Me.NudYear.Size = New System.Drawing.Size(64, 26)
        Me.NudYear.TabIndex = 1
        Me.NudYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudYear.Value = New Decimal(New Integer() {1990, 0, 0, 0})
        '
        'ChbYe
        '
        Me.ChbYe.Checked = True
        Me.ChbYe.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChbYe.ForeColor = System.Drawing.Color.SteelBlue
        Me.ChbYe.Location = New System.Drawing.Point(194, 304)
        Me.ChbYe.Name = "ChbYe"
        Me.ChbYe.Size = New System.Drawing.Size(151, 24)
        Me.ChbYe.TabIndex = 10
        Me.ChbYe.Text = "只显示有余额的物料"
        '
        'LblFadm
        '
        Me.LblFadm.AutoSize = True
        Me.LblFadm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblFadm.Location = New System.Drawing.Point(262, 63)
        Me.LblFadm.Name = "LblFadm"
        Me.LblFadm.Size = New System.Drawing.Size(120, 16)
        Me.LblFadm.TabIndex = 7
        Me.LblFadm.Text = "库存账龄方案："
        '
        'TxtFadm
        '
        Me.TxtFadm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFadm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtFadm.Location = New System.Drawing.Point(390, 58)
        Me.TxtFadm.MaxLength = 12
        Me.TxtFadm.Name = "TxtFadm"
        Me.TxtFadm.Size = New System.Drawing.Size(112, 26)
        Me.TxtFadm.TabIndex = 8
        '
        'rcDataGridView
        '
        Me.rcDataGridView.AllowUserToAddRows = False
        Me.rcDataGridView.AllowUserToDeleteRows = False
        Me.rcDataGridView.AutoGenerateColumns = False
        Me.rcDataGridView.ColumnHeadersHeight = 30
        Me.rcDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColXz, Me.ColCkdm, Me.ColCkmc})
        Me.rcDataGridView.DataSource = Me.rcBindingSource
        Me.rcDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rcDataGridView.Location = New System.Drawing.Point(3, 17)
        Me.rcDataGridView.Name = "rcDataGridView"
        Me.rcDataGridView.RowTemplate.Height = 23
        Me.rcDataGridView.Size = New System.Drawing.Size(447, 169)
        Me.rcDataGridView.TabIndex = 0
        '
        'ColXz
        '
        Me.ColXz.DataPropertyName = "xz"
        Me.ColXz.HeaderText = "选择"
        Me.ColXz.Name = "ColXz"
        Me.ColXz.Width = 60
        '
        'ColCkdm
        '
        Me.ColCkdm.DataPropertyName = "ckdm"
        Me.ColCkdm.HeaderText = "仓库编码"
        Me.ColCkdm.Name = "ColCkdm"
        Me.ColCkdm.ReadOnly = True
        Me.ColCkdm.Width = 90
        '
        'ColCkmc
        '
        Me.ColCkmc.DataPropertyName = "ckmc"
        Me.ColCkmc.HeaderText = "仓库名称"
        Me.ColCkmc.Name = "ColCkmc"
        Me.ColCkmc.ReadOnly = True
        Me.ColCkmc.Width = 180
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rcDataGridView)
        Me.GroupBox1.Location = New System.Drawing.Point(49, 109)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(453, 189)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "库存账龄计算范围"
        '
        'FrmJtchdjzb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 445)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LblFadm)
        Me.Controls.Add(Me.TxtFadm)
        Me.Controls.Add(Me.ChbYe)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.NudMonth)
        Me.Controls.Add(Me.NudYear)
        Me.Controls.Add(Me.LblMsg)
        Me.Controls.Add(Me.TxtCkdm)
        Me.Controls.Add(Me.LblCkdm)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.LblPcrq)
        Me.Name = "FrmJtchdjzb"
        Me.Text = "计提存货跌价准备"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.LblPcrq, 0)
        Me.Controls.SetChildIndex(Me.ProgressBar1, 0)
        Me.Controls.SetChildIndex(Me.LblCkdm, 0)
        Me.Controls.SetChildIndex(Me.TxtCkdm, 0)
        Me.Controls.SetChildIndex(Me.LblMsg, 0)
        Me.Controls.SetChildIndex(Me.NudYear, 0)
        Me.Controls.SetChildIndex(Me.NudMonth, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.ChbYe, 0)
        Me.Controls.SetChildIndex(Me.TxtFadm, 0)
        Me.Controls.SetChildIndex(Me.LblFadm, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.DlgPanel.ResumeLayout(False)
        CType(Me.NudMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Public WithEvents LblPcrq As System.Windows.Forms.Label
    Public WithEvents TxtCkdm As System.Windows.Forms.TextBox
    Public WithEvents LblCkdm As System.Windows.Forms.Label
    Friend WithEvents LblMsg As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents NudMonth As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudYear As System.Windows.Forms.NumericUpDown
    Friend WithEvents ChbYe As System.Windows.Forms.CheckBox
    Friend WithEvents LblFadm As System.Windows.Forms.Label
    Friend WithEvents TxtFadm As System.Windows.Forms.TextBox
    Friend WithEvents rcDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents rcBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ColXz As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColCkdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCkmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
