<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeDdReference
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
        Me.components = New System.ComponentModel.Container
        Me.rcDataGridView = New System.Windows.Forms.DataGridView
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.BtnExit = New System.Windows.Forms.Button
        Me.rcBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ColXz = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ColCpdm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCpmc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColDw = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColDj = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColHsdj = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColShlv = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rcDataGridView
        '
        Me.rcDataGridView.AllowUserToAddRows = False
        Me.rcDataGridView.AllowUserToDeleteRows = False
        Me.rcDataGridView.ColumnHeadersHeight = 30
        Me.rcDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColXz, Me.ColCpdm, Me.ColCpmc, Me.ColDw, Me.ColDj, Me.ColHsdj, Me.ColShlv})
        Me.rcDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rcDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.rcDataGridView.Name = "rcDataGridView"
        Me.rcDataGridView.RowTemplate.Height = 23
        Me.rcDataGridView.Size = New System.Drawing.Size(984, 506)
        Me.rcDataGridView.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtnExit)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 506)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(984, 55)
        Me.Panel2.TabIndex = 3
        '
        'BtnExit
        '
        Me.BtnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExit.Location = New System.Drawing.Point(902, 15)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(61, 23)
        Me.BtnExit.TabIndex = 13
        Me.BtnExit.Text = "返回(&X)"
        '
        'ColXz
        '
        Me.ColXz.DataPropertyName = "xz"
        Me.ColXz.HeaderText = "选择"
        Me.ColXz.Name = "ColXz"
        Me.ColXz.Width = 45
        '
        'ColCpdm
        '
        Me.ColCpdm.DataPropertyName = "cpdm"
        Me.ColCpdm.HeaderText = "产品编码"
        Me.ColCpdm.MaxInputLength = 15
        Me.ColCpdm.Name = "ColCpdm"
        Me.ColCpdm.ReadOnly = True
        Me.ColCpdm.Width = 110
        '
        'ColCpmc
        '
        Me.ColCpmc.DataPropertyName = "cpmc"
        Me.ColCpmc.HeaderText = "产品名称"
        Me.ColCpmc.MaxInputLength = 50
        Me.ColCpmc.Name = "ColCpmc"
        Me.ColCpmc.ReadOnly = True
        Me.ColCpmc.Width = 240
        '
        'ColDw
        '
        Me.ColDw.DataPropertyName = "dw"
        Me.ColDw.HeaderText = "单位"
        Me.ColDw.MaxInputLength = 10
        Me.ColDw.Name = "ColDw"
        Me.ColDw.ReadOnly = True
        Me.ColDw.Width = 45
        '
        'ColDj
        '
        Me.ColDj.DataPropertyName = "dj"
        Me.ColDj.HeaderText = "单价"
        Me.ColDj.MaxInputLength = 18
        Me.ColDj.Name = "ColDj"
        Me.ColDj.ReadOnly = True
        Me.ColDj.Width = 90
        '
        'ColHsdj
        '
        Me.ColHsdj.DataPropertyName = "hsdj"
        Me.ColHsdj.HeaderText = "含税单价"
        Me.ColHsdj.MaxInputLength = 18
        Me.ColHsdj.Name = "ColHsdj"
        Me.ColHsdj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColShlv
        '
        Me.ColShlv.DataPropertyName = "shlv"
        Me.ColShlv.HeaderText = "税率"
        Me.ColShlv.MaxInputLength = 6
        Me.ColShlv.Name = "ColShlv"
        Me.ColShlv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'FrmOeDdReference
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.rcDataGridView)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "FrmOeDdReference"
        Me.Text = "订单参照录入"
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rcDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents rcBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ColXz As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColCpdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCpmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDw As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColHsdj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColShlv As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
