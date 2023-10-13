<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeXsdImpDd
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
        Me.BtnExit = New System.Windows.Forms.Button
        Me.rcDataGridView = New System.Windows.Forms.DataGridView
        Me.rcBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ColXz = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ColDdDjh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColDdXh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCpdm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCpmc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColHth = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColKhddh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColKhlh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColScjhrq = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColSl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColDw = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColMjsl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColFzsl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColFzdw = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColDj = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColJe = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColHsdj = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColShlv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColSe = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColJese = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColXsmemo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel2.SuspendLayout()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtnExit)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 506)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(984, 55)
        Me.Panel2.TabIndex = 0
        '
        'BtnExit
        '
        Me.BtnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExit.Location = New System.Drawing.Point(902, 15)
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
        Me.rcDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColXz, Me.ColDdDjh, Me.ColDdXh, Me.ColCpdm, Me.ColCpmc, Me.ColHth, Me.ColKhddh, Me.ColKhlh, Me.ColScjhrq, Me.ColSl, Me.ColDw, Me.ColMjsl, Me.ColFzsl, Me.ColFzdw, Me.ColDj, Me.ColJe, Me.ColHsdj, Me.ColShlv, Me.ColSe, Me.ColJese, Me.ColXsmemo})
        Me.rcDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rcDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.rcDataGridView.Name = "rcDataGridView"
        Me.rcDataGridView.RowTemplate.Height = 23
        Me.rcDataGridView.Size = New System.Drawing.Size(984, 506)
        Me.rcDataGridView.TabIndex = 1
        '
        'ColXz
        '
        Me.ColXz.DataPropertyName = "xz"
        Me.ColXz.HeaderText = "选择"
        Me.ColXz.Name = "ColXz"
        Me.ColXz.Width = 45
        '
        'ColDdDjh
        '
        Me.ColDdDjh.DataPropertyName = "dddjh"
        Me.ColDdDjh.HeaderText = "销售订单单据号"
        Me.ColDdDjh.MaxInputLength = 15
        Me.ColDdDjh.Name = "ColDdDjh"
        Me.ColDdDjh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColDdXh
        '
        Me.ColDdXh.DataPropertyName = "ddxh"
        Me.ColDdXh.HeaderText = "销售订单行号"
        Me.ColDdXh.MaxInputLength = 4
        Me.ColDdXh.Name = "ColDdXh"
        Me.ColDdXh.ReadOnly = True
        Me.ColDdXh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColDdXh.Width = 55
        '
        'ColCpdm
        '
        Me.ColCpdm.DataPropertyName = "cpdm"
        Me.ColCpdm.HeaderText = "产品编码"
        Me.ColCpdm.MaxInputLength = 15
        Me.ColCpdm.Name = "ColCpdm"
        Me.ColCpdm.ReadOnly = True
        Me.ColCpdm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColCpdm.Width = 110
        '
        'ColCpmc
        '
        Me.ColCpmc.DataPropertyName = "cpmc"
        Me.ColCpmc.HeaderText = "产品名称"
        Me.ColCpmc.MaxInputLength = 200
        Me.ColCpmc.Name = "ColCpmc"
        Me.ColCpmc.ReadOnly = True
        Me.ColCpmc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColCpmc.Width = 240
        '
        'ColHth
        '
        Me.ColHth.DataPropertyName = "hth"
        Me.ColHth.HeaderText = "手工订单号"
        Me.ColHth.MaxInputLength = 30
        Me.ColHth.Name = "ColHth"
        Me.ColHth.ReadOnly = True
        Me.ColHth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColKhddh
        '
        Me.ColKhddh.DataPropertyName = "khddh"
        Me.ColKhddh.HeaderText = "客户订单号"
        Me.ColKhddh.MaxInputLength = 30
        Me.ColKhddh.Name = "ColKhddh"
        Me.ColKhddh.ReadOnly = True
        Me.ColKhddh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColKhlh
        '
        Me.ColKhlh.DataPropertyName = "khlh"
        Me.ColKhlh.HeaderText = "客户料号"
        Me.ColKhlh.MaxInputLength = 30
        Me.ColKhlh.Name = "ColKhlh"
        Me.ColKhlh.ReadOnly = True
        Me.ColKhlh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColScjhrq
        '
        Me.ColScjhrq.DataPropertyName = "scjhrq"
        Me.ColScjhrq.HeaderText = "生产交期"
        Me.ColScjhrq.Name = "ColScjhrq"
        Me.ColScjhrq.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColScjhrq.Width = 80
        '
        'ColSl
        '
        Me.ColSl.DataPropertyName = "sl"
        Me.ColSl.HeaderText = "未送货数量"
        Me.ColSl.MaxInputLength = 18
        Me.ColSl.Name = "ColSl"
        Me.ColSl.ReadOnly = True
        Me.ColSl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColSl.Width = 90
        '
        'ColDw
        '
        Me.ColDw.DataPropertyName = "dw"
        Me.ColDw.HeaderText = "单位"
        Me.ColDw.Name = "ColDw"
        Me.ColDw.ReadOnly = True
        Me.ColDw.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColDw.Width = 45
        '
        'ColMjsl
        '
        Me.ColMjsl.DataPropertyName = "mjsl"
        Me.ColMjsl.HeaderText = "换算系数"
        Me.ColMjsl.MaxInputLength = 18
        Me.ColMjsl.Name = "ColMjsl"
        Me.ColMjsl.ReadOnly = True
        Me.ColMjsl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColMjsl.Width = 90
        '
        'ColFzsl
        '
        Me.ColFzsl.DataPropertyName = "fzsl"
        Me.ColFzsl.HeaderText = "辅数量"
        Me.ColFzsl.MaxInputLength = 18
        Me.ColFzsl.Name = "ColFzsl"
        Me.ColFzsl.ReadOnly = True
        Me.ColFzsl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColFzsl.Width = 90
        '
        'ColFzdw
        '
        Me.ColFzdw.DataPropertyName = "fzdw"
        Me.ColFzdw.HeaderText = "辅单位"
        Me.ColFzdw.MaxInputLength = 8
        Me.ColFzdw.Name = "ColFzdw"
        Me.ColFzdw.ReadOnly = True
        Me.ColFzdw.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColFzdw.Width = 45
        '
        'ColDj
        '
        Me.ColDj.DataPropertyName = "dj"
        Me.ColDj.HeaderText = "单价"
        Me.ColDj.MaxInputLength = 18
        Me.ColDj.Name = "ColDj"
        Me.ColDj.ReadOnly = True
        Me.ColDj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColDj.Width = 90
        '
        'ColJe
        '
        Me.ColJe.DataPropertyName = "je"
        Me.ColJe.HeaderText = "金额"
        Me.ColJe.MaxInputLength = 14
        Me.ColJe.Name = "ColJe"
        Me.ColJe.ReadOnly = True
        Me.ColJe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColJe.Width = 90
        '
        'ColHsdj
        '
        Me.ColHsdj.DataPropertyName = "hsdj"
        Me.ColHsdj.HeaderText = "含税单价"
        Me.ColHsdj.MaxInputLength = 18
        Me.ColHsdj.Name = "ColHsdj"
        Me.ColHsdj.ReadOnly = True
        Me.ColHsdj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColHsdj.Width = 90
        '
        'ColShlv
        '
        Me.ColShlv.DataPropertyName = "shlv"
        Me.ColShlv.HeaderText = "税率"
        Me.ColShlv.MaxInputLength = 6
        Me.ColShlv.Name = "ColShlv"
        Me.ColShlv.ReadOnly = True
        Me.ColShlv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColShlv.Width = 90
        '
        'ColSe
        '
        Me.ColSe.DataPropertyName = "se"
        Me.ColSe.HeaderText = "税额"
        Me.ColSe.MaxInputLength = 14
        Me.ColSe.Name = "ColSe"
        Me.ColSe.ReadOnly = True
        Me.ColSe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColSe.Width = 90
        '
        'ColJese
        '
        Me.ColJese.DataPropertyName = "jese"
        Me.ColJese.HeaderText = "价税合计"
        Me.ColJese.MaxInputLength = 14
        Me.ColJese.Name = "ColJese"
        Me.ColJese.ReadOnly = True
        Me.ColJese.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColJese.Width = 90
        '
        'ColXsmemo
        '
        Me.ColXsmemo.DataPropertyName = "xsmemo"
        Me.ColXsmemo.HeaderText = "备注"
        Me.ColXsmemo.MaxInputLength = 50
        Me.ColXsmemo.Name = "ColXsmemo"
        Me.ColXsmemo.ReadOnly = True
        Me.ColXsmemo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColXsmemo.Width = 135
        '
        'FrmOeXsdImpDd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.rcDataGridView)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "FrmOeXsdImpDd"
        Me.Text = "产品送货单参照录入"
        Me.Panel2.ResumeLayout(False)
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents rcDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents rcBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ColXz As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColDdDjh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDdXh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCpdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCpmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColHth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKhddh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKhlh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColScjhrq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDw As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMjsl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFzsl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFzdw As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColHsdj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColShlv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColJese As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColXsmemo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
