<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPoCkdSr2
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.ColBmdm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColBmmc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColZydm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColZymc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColDjh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ChbSh = New System.Windows.Forms.CheckBox
        Me.DlgPanel.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.DlgPanel.Location = New System.Drawing.Point(441, 378)
        Me.DlgPanel.TabIndex = 4
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeight = 30
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColBmdm, Me.ColBmmc, Me.ColZydm, Me.ColZymc, Me.ColDjh})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Top
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(694, 359)
        Me.DataGridView1.TabIndex = 5
        '
        'ColBmdm
        '
        Me.ColBmdm.DataPropertyName = "bmdm"
        Me.ColBmdm.HeaderText = "部门编码"
        Me.ColBmdm.Name = "ColBmdm"
        Me.ColBmdm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColBmmc
        '
        Me.ColBmmc.DataPropertyName = "bmmc"
        Me.ColBmmc.HeaderText = "部门名称"
        Me.ColBmmc.Name = "ColBmmc"
        Me.ColBmmc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColBmmc.Width = 150
        '
        'ColZydm
        '
        Me.ColZydm.DataPropertyName = "zydm"
        Me.ColZydm.HeaderText = "职员编码"
        Me.ColZydm.Name = "ColZydm"
        Me.ColZydm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColZydm.Width = 80
        '
        'ColZymc
        '
        Me.ColZymc.DataPropertyName = "zymc"
        Me.ColZymc.HeaderText = "职员姓名"
        Me.ColZymc.Name = "ColZymc"
        Me.ColZymc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColZymc.Width = 150
        '
        'ColDjh
        '
        Me.ColDjh.DataPropertyName = "cntdjh"
        Me.ColDjh.HeaderText = "未确认发货单据张数"
        Me.ColDjh.Name = "ColDjh"
        Me.ColDjh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColDjh.Width = 125
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 300000
        '
        'ChbSh
        '
        Me.ChbSh.Checked = True
        Me.ChbSh.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChbSh.ForeColor = System.Drawing.Color.SteelBlue
        Me.ChbSh.Location = New System.Drawing.Point(125, 381)
        Me.ChbSh.Name = "ChbSh"
        Me.ChbSh.Size = New System.Drawing.Size(180, 24)
        Me.ChbSh.TabIndex = 6
        Me.ChbSh.Text = "领料申请单审核后才能发料"
        '
        'FrmPoCkdSr2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(694, 421)
        Me.Controls.Add(Me.ChbSh)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FrmPoCkdSr2"
        Me.Text = "物料领用发货确认单(查询条件)"
        Me.Controls.SetChildIndex(Me.DataGridView1, 0)
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.ChbSh, 0)
        Me.DlgPanel.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ColBmdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBmmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColZydm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColZymc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDjh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChbSh As System.Windows.Forms.CheckBox
End Class
