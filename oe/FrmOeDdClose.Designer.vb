<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeDdClose
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
        Me.TxtCpdm = New System.Windows.Forms.TextBox
        Me.LblCpdm = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.BtnQuery = New System.Windows.Forms.Button
        Me.rcDataGridView = New System.Windows.Forms.DataGridView
        Me.ColButtonText = New System.Windows.Forms.DataGridViewButtonColumn
        Me.ColBClose = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ColDjh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColXh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColKhdm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColKhmc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCpdm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCpmc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColDw = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColSl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColHxsl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColRksl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColXssl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColFpsl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColDdmemo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1.SuspendLayout()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtCpdm
        '
        Me.TxtCpdm.Location = New System.Drawing.Point(113, 21)
        Me.TxtCpdm.MaxLength = 15
        Me.TxtCpdm.Name = "TxtCpdm"
        Me.TxtCpdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtCpdm.TabIndex = 13
        '
        'LblCpdm
        '
        Me.LblCpdm.AutoSize = True
        Me.LblCpdm.Location = New System.Drawing.Point(40, 25)
        Me.LblCpdm.Name = "LblCpdm"
        Me.LblCpdm.Size = New System.Drawing.Size(65, 12)
        Me.LblCpdm.TabIndex = 12
        Me.LblCpdm.Text = "物料编码："
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnQuery)
        Me.Panel1.Controls.Add(Me.TxtCpdm)
        Me.Panel1.Controls.Add(Me.LblCpdm)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(984, 62)
        Me.Panel1.TabIndex = 14
        '
        'BtnQuery
        '
        Me.BtnQuery.Location = New System.Drawing.Point(281, 21)
        Me.BtnQuery.Name = "BtnQuery"
        Me.BtnQuery.Size = New System.Drawing.Size(159, 23)
        Me.BtnQuery.TabIndex = 14
        Me.BtnQuery.Text = "显示未完成的订单"
        Me.BtnQuery.UseVisualStyleBackColor = True
        '
        'rcDataGridView
        '
        Me.rcDataGridView.AllowUserToAddRows = False
        Me.rcDataGridView.AllowUserToDeleteRows = False
        Me.rcDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.rcDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColButtonText, Me.ColBClose, Me.ColDjh, Me.ColXh, Me.ColKhdm, Me.ColKhmc, Me.ColCpdm, Me.ColCpmc, Me.ColDw, Me.ColSl, Me.ColHxsl, Me.ColRksl, Me.ColXssl, Me.ColFpsl, Me.ColDdmemo})
        Me.rcDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rcDataGridView.Location = New System.Drawing.Point(0, 62)
        Me.rcDataGridView.Name = "rcDataGridView"
        Me.rcDataGridView.ReadOnly = True
        Me.rcDataGridView.RowTemplate.Height = 23
        Me.rcDataGridView.Size = New System.Drawing.Size(984, 499)
        Me.rcDataGridView.TabIndex = 15
        '
        'ColButtonText
        '
        Me.ColButtonText.DataPropertyName = "buttontext"
        Me.ColButtonText.HeaderText = "操作"
        Me.ColButtonText.Name = "ColButtonText"
        Me.ColButtonText.ReadOnly = True
        '
        'ColBClose
        '
        Me.ColBClose.DataPropertyName = "bclosed"
        Me.ColBClose.HeaderText = "关闭"
        Me.ColBClose.Name = "ColBClose"
        Me.ColBClose.ReadOnly = True
        Me.ColBClose.Width = 45
        '
        'ColDjh
        '
        Me.ColDjh.DataPropertyName = "djh"
        Me.ColDjh.HeaderText = "单据号"
        Me.ColDjh.MaxInputLength = 15
        Me.ColDjh.Name = "ColDjh"
        Me.ColDjh.ReadOnly = True
        Me.ColDjh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColXh
        '
        Me.ColXh.DataPropertyName = "xh"
        Me.ColXh.HeaderText = "行号"
        Me.ColXh.MaxInputLength = 4
        Me.ColXh.Name = "ColXh"
        Me.ColXh.ReadOnly = True
        Me.ColXh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColXh.Width = 45
        '
        'ColKhdm
        '
        Me.ColKhdm.DataPropertyName = "khdm"
        Me.ColKhdm.HeaderText = "客户编码"
        Me.ColKhdm.MaxInputLength = 12
        Me.ColKhdm.Name = "ColKhdm"
        Me.ColKhdm.ReadOnly = True
        Me.ColKhdm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColKhdm.Width = 90
        '
        'ColKhmc
        '
        Me.ColKhmc.DataPropertyName = "khmc"
        Me.ColKhmc.HeaderText = "客户名称"
        Me.ColKhmc.MaxInputLength = 50
        Me.ColKhmc.Name = "ColKhmc"
        Me.ColKhmc.ReadOnly = True
        Me.ColKhmc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColKhmc.Width = 180
        '
        'ColCpdm
        '
        Me.ColCpdm.DataPropertyName = "cpdm"
        Me.ColCpdm.HeaderText = "物料编码"
        Me.ColCpdm.MaxInputLength = 15
        Me.ColCpdm.Name = "ColCpdm"
        Me.ColCpdm.ReadOnly = True
        Me.ColCpdm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColCpmc
        '
        Me.ColCpmc.DataPropertyName = "cpmc"
        Me.ColCpmc.HeaderText = "物料描述"
        Me.ColCpmc.MaxInputLength = 200
        Me.ColCpmc.Name = "ColCpmc"
        Me.ColCpmc.ReadOnly = True
        Me.ColCpmc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColCpmc.Width = 180
        '
        'ColDw
        '
        Me.ColDw.DataPropertyName = "dw"
        Me.ColDw.HeaderText = "单位"
        Me.ColDw.MaxInputLength = 8
        Me.ColDw.Name = "ColDw"
        Me.ColDw.ReadOnly = True
        Me.ColDw.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColDw.Width = 45
        '
        'ColSl
        '
        Me.ColSl.DataPropertyName = "sl"
        Me.ColSl.HeaderText = "订单数量"
        Me.ColSl.MaxInputLength = 18
        Me.ColSl.Name = "ColSl"
        Me.ColSl.ReadOnly = True
        Me.ColSl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColHxsl
        '
        Me.ColHxsl.DataPropertyName = "hxsl"
        Me.ColHxsl.HeaderText = "已核销数量"
        Me.ColHxsl.MaxInputLength = 18
        Me.ColHxsl.Name = "ColHxsl"
        Me.ColHxsl.ReadOnly = True
        Me.ColHxsl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColRksl
        '
        Me.ColRksl.DataPropertyName = "rksl"
        Me.ColRksl.HeaderText = "已入库数量"
        Me.ColRksl.MaxInputLength = 18
        Me.ColRksl.Name = "ColRksl"
        Me.ColRksl.ReadOnly = True
        Me.ColRksl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColXssl
        '
        Me.ColXssl.DataPropertyName = "xssl"
        Me.ColXssl.HeaderText = "已送货数量"
        Me.ColXssl.MaxInputLength = 18
        Me.ColXssl.Name = "ColXssl"
        Me.ColXssl.ReadOnly = True
        Me.ColXssl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColFpsl
        '
        Me.ColFpsl.DataPropertyName = "fpsl"
        Me.ColFpsl.HeaderText = "已开票数量"
        Me.ColFpsl.MaxInputLength = 18
        Me.ColFpsl.Name = "ColFpsl"
        Me.ColFpsl.ReadOnly = True
        Me.ColFpsl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColDdmemo
        '
        Me.ColDdmemo.DataPropertyName = "ddmemo"
        Me.ColDdmemo.HeaderText = "备注"
        Me.ColDdmemo.MaxInputLength = 50
        Me.ColDdmemo.Name = "ColDdmemo"
        Me.ColDdmemo.ReadOnly = True
        Me.ColDdmemo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColDdmemo.Width = 180
        '
        'FrmOeDdClose
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.rcDataGridView)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmOeDdClose"
        Me.Text = "产品销售订单关闭"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents TxtCpdm As System.Windows.Forms.TextBox
    Public WithEvents LblCpdm As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rcDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents BtnQuery As System.Windows.Forms.Button
    Friend WithEvents ColButtonText As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents ColBClose As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColDjh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColXh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKhdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKhmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCpdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCpmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDw As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColHxsl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRksl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColXssl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFpsl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDdmemo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
