<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeRkdReference
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
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.BtnImport = New System.Windows.Forms.Button
        Me.TxtZydm = New System.Windows.Forms.TextBox
        Me.LblZydm = New System.Windows.Forms.Label
        Me.TxtKhdm = New System.Windows.Forms.TextBox
        Me.LblKhdm = New System.Windows.Forms.Label
        Me.BtnExit = New System.Windows.Forms.Button
        Me.rcDataGridView = New System.Windows.Forms.DataGridView
        Me.rcBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ColXz = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ColCpdm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCpmc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColHth = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColSl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColDw = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColMjsl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColFzsl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColFzdw = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColDj = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColJe = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel2.SuspendLayout()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtnImport)
        Me.Panel2.Controls.Add(Me.TxtZydm)
        Me.Panel2.Controls.Add(Me.LblZydm)
        Me.Panel2.Controls.Add(Me.TxtKhdm)
        Me.Panel2.Controls.Add(Me.LblKhdm)
        Me.Panel2.Controls.Add(Me.BtnExit)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 442)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(786, 55)
        Me.Panel2.TabIndex = 0
        '
        'BtnImport
        '
        Me.BtnImport.Location = New System.Drawing.Point(353, 11)
        Me.BtnImport.Name = "BtnImport"
        Me.BtnImport.Size = New System.Drawing.Size(99, 23)
        Me.BtnImport.TabIndex = 4
        Me.BtnImport.Text = "读入数据(&I)"
        '
        'TxtZydm
        '
        Me.TxtZydm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtZydm.Location = New System.Drawing.Point(260, 13)
        Me.TxtZydm.MaxLength = 12
        Me.TxtZydm.Name = "TxtZydm"
        Me.TxtZydm.Size = New System.Drawing.Size(87, 21)
        Me.TxtZydm.TabIndex = 3
        '
        'LblZydm
        '
        Me.LblZydm.AutoSize = True
        Me.LblZydm.Location = New System.Drawing.Point(189, 19)
        Me.LblZydm.Name = "LblZydm"
        Me.LblZydm.Size = New System.Drawing.Size(65, 12)
        Me.LblZydm.TabIndex = 2
        Me.LblZydm.Text = "生产职员："
        '
        'TxtKhdm
        '
        Me.TxtKhdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtKhdm.Location = New System.Drawing.Point(86, 13)
        Me.TxtKhdm.MaxLength = 15
        Me.TxtKhdm.Name = "TxtKhdm"
        Me.TxtKhdm.Size = New System.Drawing.Size(87, 21)
        Me.TxtKhdm.TabIndex = 1
        '
        'LblKhdm
        '
        Me.LblKhdm.AutoSize = True
        Me.LblKhdm.Location = New System.Drawing.Point(15, 16)
        Me.LblKhdm.Name = "LblKhdm"
        Me.LblKhdm.Size = New System.Drawing.Size(65, 12)
        Me.LblKhdm.TabIndex = 0
        Me.LblKhdm.Text = "客户编码："
        '
        'BtnExit
        '
        Me.BtnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExit.Location = New System.Drawing.Point(704, 15)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(61, 23)
        Me.BtnExit.TabIndex = 5
        Me.BtnExit.Text = "返回(&X)"
        '
        'rcDataGridView
        '
        Me.rcDataGridView.AllowUserToAddRows = False
        Me.rcDataGridView.AllowUserToDeleteRows = False
        Me.rcDataGridView.ColumnHeadersHeight = 30
        Me.rcDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColXz, Me.ColCpdm, Me.ColCpmc, Me.ColHth, Me.ColSl, Me.ColDw, Me.ColMjsl, Me.ColFzsl, Me.ColFzdw, Me.ColDj, Me.ColJe})
        Me.rcDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rcDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.rcDataGridView.Name = "rcDataGridView"
        Me.rcDataGridView.RowTemplate.Height = 23
        Me.rcDataGridView.Size = New System.Drawing.Size(786, 442)
        Me.rcDataGridView.TabIndex = 1
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
        'ColHth
        '
        Me.ColHth.DataPropertyName = "hth"
        Me.ColHth.HeaderText = "订单编码"
        Me.ColHth.MaxInputLength = 18
        Me.ColHth.Name = "ColHth"
        Me.ColHth.ReadOnly = True
        Me.ColHth.Width = 80
        '
        'ColSl
        '
        Me.ColSl.DataPropertyName = "sl"
        Me.ColSl.HeaderText = "数量"
        Me.ColSl.Name = "ColSl"
        Me.ColSl.Width = 90
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
        'ColMjsl
        '
        Me.ColMjsl.DataPropertyName = "mjsl"
        Me.ColMjsl.HeaderText = "换算系数"
        Me.ColMjsl.Name = "ColMjsl"
        Me.ColMjsl.Width = 90
        '
        'ColFzsl
        '
        Me.ColFzsl.DataPropertyName = "fzsl"
        Me.ColFzsl.HeaderText = "辅数量"
        Me.ColFzsl.Name = "ColFzsl"
        Me.ColFzsl.Width = 90
        '
        'ColFzdw
        '
        Me.ColFzdw.DataPropertyName = "fzdw"
        Me.ColFzdw.HeaderText = "辅单位"
        Me.ColFzdw.Name = "ColFzdw"
        Me.ColFzdw.ReadOnly = True
        Me.ColFzdw.Width = 45
        '
        'ColDj
        '
        Me.ColDj.DataPropertyName = "dj"
        Me.ColDj.HeaderText = "单价"
        Me.ColDj.Name = "ColDj"
        '
        'ColJe
        '
        Me.ColJe.DataPropertyName = "je"
        Me.ColJe.HeaderText = "金额"
        Me.ColJe.Name = "ColJe"
        '
        'FrmOeRkdReference
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.rcDataGridView)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "FrmOeRkdReference"
        Me.Text = "产品入库单参照录入"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents rcDataGridView As System.Windows.Forms.DataGridView
    Public WithEvents TxtKhdm As System.Windows.Forms.TextBox
    Public WithEvents LblKhdm As System.Windows.Forms.Label
    Public WithEvents TxtZydm As System.Windows.Forms.TextBox
    Public WithEvents LblZydm As System.Windows.Forms.Label
    Friend WithEvents BtnImport As System.Windows.Forms.Button
    Friend WithEvents rcBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ColXz As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColCpdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCpmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColHth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDw As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMjsl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFzsl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFzdw As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJe As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
