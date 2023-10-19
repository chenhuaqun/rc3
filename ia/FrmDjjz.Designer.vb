<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDjjz
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.NudMonth = New System.Windows.Forms.NumericUpDown
        Me.NudYear = New System.Windows.Forms.NumericUpDown
        Me.rcDataGridView = New System.Windows.Forms.DataGridView
        Me.rcBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ColXm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColBqzs = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColWjzzs = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColYjzzs = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColBcjzzs = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DlgPanel.SuspendLayout()
        CType(Me.NudMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.DlgPanel.Location = New System.Drawing.Point(309, 266)
        Me.DlgPanel.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(44, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "请选择记账的年月："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(348, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "月"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(276, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "年"
        '
        'NudMonth
        '
        Me.NudMonth.Enabled = False
        Me.NudMonth.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NudMonth.Location = New System.Drawing.Point(300, 21)
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
        Me.NudYear.Enabled = False
        Me.NudYear.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NudYear.Location = New System.Drawing.Point(204, 21)
        Me.NudYear.Maximum = New Decimal(New Integer() {2050, 0, 0, 0})
        Me.NudYear.Minimum = New Decimal(New Integer() {1990, 0, 0, 0})
        Me.NudYear.Name = "NudYear"
        Me.NudYear.Size = New System.Drawing.Size(64, 26)
        Me.NudYear.TabIndex = 1
        Me.NudYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudYear.Value = New Decimal(New Integer() {1990, 0, 0, 0})
        '
        'rcDataGridView
        '
        Me.rcDataGridView.AllowUserToAddRows = False
        Me.rcDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.rcDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColXm, Me.ColBqzs, Me.ColWjzzs, Me.ColYjzzs, Me.ColBcjzzs})
        Me.rcDataGridView.Location = New System.Drawing.Point(28, 66)
        Me.rcDataGridView.Name = "rcDataGridView"
        Me.rcDataGridView.ReadOnly = True
        Me.rcDataGridView.RowTemplate.Height = 23
        Me.rcDataGridView.Size = New System.Drawing.Size(503, 175)
        Me.rcDataGridView.TabIndex = 5
        '
        'ColXm
        '
        Me.ColXm.DataPropertyName = "xm"
        Me.ColXm.HeaderText = "记账内容"
        Me.ColXm.Name = "ColXm"
        Me.ColXm.ReadOnly = True
        Me.ColXm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColXm.Width = 135
        '
        'ColBqzs
        '
        Me.ColBqzs.DataPropertyName = "bqzs"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColBqzs.DefaultCellStyle = DataGridViewCellStyle1
        Me.ColBqzs.HeaderText = "本期张数"
        Me.ColBqzs.Name = "ColBqzs"
        Me.ColBqzs.ReadOnly = True
        Me.ColBqzs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColBqzs.Width = 75
        '
        'ColWjzzs
        '
        Me.ColWjzzs.DataPropertyName = "wjzzs"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColWjzzs.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColWjzzs.HeaderText = "未记账张数"
        Me.ColWjzzs.Name = "ColWjzzs"
        Me.ColWjzzs.ReadOnly = True
        Me.ColWjzzs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColWjzzs.Width = 75
        '
        'ColYjzzs
        '
        Me.ColYjzzs.DataPropertyName = "yjzzs"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColYjzzs.DefaultCellStyle = DataGridViewCellStyle3
        Me.ColYjzzs.HeaderText = "已记账张数"
        Me.ColYjzzs.Name = "ColYjzzs"
        Me.ColYjzzs.ReadOnly = True
        Me.ColYjzzs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColYjzzs.Width = 75
        '
        'ColBcjzzs
        '
        Me.ColBcjzzs.DataPropertyName = "bcjzzs"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColBcjzzs.DefaultCellStyle = DataGridViewCellStyle4
        Me.ColBcjzzs.HeaderText = "允许记账张数"
        Me.ColBcjzzs.Name = "ColBcjzzs"
        Me.ColBcjzzs.ReadOnly = True
        Me.ColBcjzzs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColBcjzzs.Width = 75
        '
        'FrmDjjz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 309)
        Me.Controls.Add(Me.rcDataGridView)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NudMonth)
        Me.Controls.Add(Me.NudYear)
        Me.Name = "FrmDjjz"
        Me.Text = "单据记账"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.NudYear, 0)
        Me.Controls.SetChildIndex(Me.NudMonth, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.rcDataGridView, 0)
        Me.DlgPanel.ResumeLayout(False)
        CType(Me.NudMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NudMonth As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudYear As System.Windows.Forms.NumericUpDown
    Friend WithEvents rcDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents rcBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ColXm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBqzs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColWjzzs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColYjzzs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBcjzzs As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
