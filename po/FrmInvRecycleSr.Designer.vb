<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInvRecycleSr
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
        Me.components = New System.ComponentModel.Container()
        Me.TxtCpdm = New System.Windows.Forms.TextBox()
        Me.LblCpdm = New System.Windows.Forms.Label()
        Me.BtnImpCkd = New System.Windows.Forms.Button()
        Me.rcDataGridView = New System.Windows.Forms.DataGridView()
        Me.MnuMain = New System.Windows.Forms.MenuStrip()
        Me.MnuiFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiImpCkd = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mnui11 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuiExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LblRkrqEnd = New System.Windows.Forms.Label()
        Me.DtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.LblRkrqBegin = New System.Windows.Forms.Label()
        Me.DtpBegin = New System.Windows.Forms.DateTimePicker()
        Me.rcBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ColButtonText = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.ColCkrq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColBmdm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColBmmc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColZydm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColZymc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCpdm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCpmc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCsdm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCsmc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColBrecycling = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColBFadm = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColFadm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFamc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColKuwei = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPiHao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDw = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMjsl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFzsl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFzdw = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColJe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRkmemo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDjh = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColXh = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MnuMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtCpdm
        '
        Me.TxtCpdm.Location = New System.Drawing.Point(539, 25)
        Me.TxtCpdm.MaxLength = 15
        Me.TxtCpdm.Name = "TxtCpdm"
        Me.TxtCpdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtCpdm.TabIndex = 5
        '
        'LblCpdm
        '
        Me.LblCpdm.AutoSize = True
        Me.LblCpdm.Location = New System.Drawing.Point(466, 29)
        Me.LblCpdm.Name = "LblCpdm"
        Me.LblCpdm.Size = New System.Drawing.Size(65, 12)
        Me.LblCpdm.TabIndex = 4
        Me.LblCpdm.Text = "物料编码："
        '
        'BtnImpCkd
        '
        Me.BtnImpCkd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImpCkd.Location = New System.Drawing.Point(780, 25)
        Me.BtnImpCkd.Name = "BtnImpCkd"
        Me.BtnImpCkd.Size = New System.Drawing.Size(129, 23)
        Me.BtnImpCkd.TabIndex = 6
        Me.BtnImpCkd.Text = "读取物料出库单"
        '
        'rcDataGridView
        '
        Me.rcDataGridView.AllowUserToAddRows = False
        Me.rcDataGridView.AllowUserToDeleteRows = False
        Me.rcDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.rcDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColButtonText, Me.ColCkrq, Me.ColBmdm, Me.ColBmmc, Me.ColZydm, Me.ColZymc, Me.ColCpdm, Me.ColCpmc, Me.ColCsdm, Me.ColCsmc, Me.ColBrecycling, Me.ColBFadm, Me.ColFadm, Me.ColFamc, Me.ColKuwei, Me.ColPiHao, Me.ColSl, Me.ColDw, Me.ColMjsl, Me.ColFzsl, Me.ColFzdw, Me.ColDj, Me.ColJe, Me.ColRkmemo, Me.ColDjh, Me.ColXh})
        Me.rcDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rcDataGridView.Location = New System.Drawing.Point(0, 96)
        Me.rcDataGridView.Name = "rcDataGridView"
        Me.rcDataGridView.ReadOnly = True
        Me.rcDataGridView.RowHeadersWidth = 62
        Me.rcDataGridView.RowTemplate.Height = 23
        Me.rcDataGridView.Size = New System.Drawing.Size(984, 465)
        Me.rcDataGridView.TabIndex = 2
        '
        'MnuMain
        '
        Me.MnuMain.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiFile, Me.MnuiEdit, Me.MnuiHelp})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(984, 25)
        Me.MnuMain.TabIndex = 0
        '
        'MnuiFile
        '
        Me.MnuiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiImpCkd, Me.Mnui11, Me.MnuiExit})
        Me.MnuiFile.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiFile.Name = "MnuiFile"
        Me.MnuiFile.Size = New System.Drawing.Size(58, 21)
        Me.MnuiFile.Text = "文件(&F)"
        '
        'MnuiImpCkd
        '
        Me.MnuiImpCkd.Name = "MnuiImpCkd"
        Me.MnuiImpCkd.Size = New System.Drawing.Size(160, 22)
        Me.MnuiImpCkd.Text = "读取物料出库单"
        '
        'Mnui11
        '
        Me.Mnui11.Name = "Mnui11"
        Me.Mnui11.Size = New System.Drawing.Size(157, 6)
        '
        'MnuiExit
        '
        Me.MnuiExit.Name = "MnuiExit"
        Me.MnuiExit.Size = New System.Drawing.Size(160, 22)
        Me.MnuiExit.Text = "退出(&X)"
        '
        'MnuiEdit
        '
        Me.MnuiEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiCut, Me.MnuiCopy, Me.MnuiPaste})
        Me.MnuiEdit.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiEdit.Name = "MnuiEdit"
        Me.MnuiEdit.Size = New System.Drawing.Size(59, 21)
        Me.MnuiEdit.Text = "编辑(&E)"
        '
        'MnuiCut
        '
        Me.MnuiCut.Name = "MnuiCut"
        Me.MnuiCut.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.MnuiCut.Size = New System.Drawing.Size(180, 22)
        Me.MnuiCut.Text = "剪切(&T)"
        '
        'MnuiCopy
        '
        Me.MnuiCopy.Name = "MnuiCopy"
        Me.MnuiCopy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.MnuiCopy.Size = New System.Drawing.Size(180, 22)
        Me.MnuiCopy.Text = "复制(&C)"
        '
        'MnuiPaste
        '
        Me.MnuiPaste.Name = "MnuiPaste"
        Me.MnuiPaste.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.MnuiPaste.Size = New System.Drawing.Size(180, 22)
        Me.MnuiPaste.Text = "粘贴(&P)"
        '
        'MnuiHelp
        '
        Me.MnuiHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiAbout})
        Me.MnuiHelp.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiHelp.Name = "MnuiHelp"
        Me.MnuiHelp.Size = New System.Drawing.Size(61, 21)
        Me.MnuiHelp.Text = "帮助(&H)"
        '
        'MnuiAbout
        '
        Me.MnuiAbout.Name = "MnuiAbout"
        Me.MnuiAbout.Size = New System.Drawing.Size(116, 22)
        Me.MnuiAbout.Text = "关于(&A)"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FloralWhite
        Me.Panel1.Controls.Add(Me.LblRkrqEnd)
        Me.Panel1.Controls.Add(Me.DtpEnd)
        Me.Panel1.Controls.Add(Me.LblRkrqBegin)
        Me.Panel1.Controls.Add(Me.DtpBegin)
        Me.Panel1.Controls.Add(Me.TxtCpdm)
        Me.Panel1.Controls.Add(Me.LblCpdm)
        Me.Panel1.Controls.Add(Me.BtnImpCkd)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(984, 71)
        Me.Panel1.TabIndex = 1
        '
        'LblRkrqEnd
        '
        Me.LblRkrqEnd.AutoSize = True
        Me.LblRkrqEnd.Location = New System.Drawing.Point(254, 29)
        Me.LblRkrqEnd.Name = "LblRkrqEnd"
        Me.LblRkrqEnd.Size = New System.Drawing.Size(17, 12)
        Me.LblRkrqEnd.TabIndex = 2
        Me.LblRkrqEnd.Text = "至"
        '
        'DtpEnd
        '
        Me.DtpEnd.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpEnd.Location = New System.Drawing.Point(279, 25)
        Me.DtpEnd.Name = "DtpEnd"
        Me.DtpEnd.Size = New System.Drawing.Size(151, 21)
        Me.DtpEnd.TabIndex = 3
        '
        'LblRkrqBegin
        '
        Me.LblRkrqBegin.AutoSize = True
        Me.LblRkrqBegin.Location = New System.Drawing.Point(22, 29)
        Me.LblRkrqBegin.Name = "LblRkrqBegin"
        Me.LblRkrqBegin.Size = New System.Drawing.Size(65, 12)
        Me.LblRkrqBegin.TabIndex = 0
        Me.LblRkrqBegin.Text = "出库日期："
        '
        'DtpBegin
        '
        Me.DtpBegin.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpBegin.Location = New System.Drawing.Point(95, 25)
        Me.DtpBegin.Name = "DtpBegin"
        Me.DtpBegin.Size = New System.Drawing.Size(151, 21)
        Me.DtpBegin.TabIndex = 1
        '
        'ColButtonText
        '
        Me.ColButtonText.DataPropertyName = "buttontext"
        Me.ColButtonText.HeaderText = "回收/取消回收"
        Me.ColButtonText.Name = "ColButtonText"
        Me.ColButtonText.ReadOnly = True
        Me.ColButtonText.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'ColCkrq
        '
        Me.ColCkrq.DataPropertyName = "ckrq"
        Me.ColCkrq.HeaderText = "出库日期"
        Me.ColCkrq.Name = "ColCkrq"
        Me.ColCkrq.ReadOnly = True
        '
        'ColBmdm
        '
        Me.ColBmdm.DataPropertyName = "bmdm"
        Me.ColBmdm.HeaderText = "部门编码"
        Me.ColBmdm.Name = "ColBmdm"
        Me.ColBmdm.ReadOnly = True
        '
        'ColBmmc
        '
        Me.ColBmmc.DataPropertyName = "bmmc"
        Me.ColBmmc.HeaderText = "部门名称"
        Me.ColBmmc.Name = "ColBmmc"
        Me.ColBmmc.ReadOnly = True
        '
        'ColZydm
        '
        Me.ColZydm.DataPropertyName = "zydm"
        Me.ColZydm.HeaderText = "职员编码"
        Me.ColZydm.Name = "ColZydm"
        Me.ColZydm.ReadOnly = True
        '
        'ColZymc
        '
        Me.ColZymc.DataPropertyName = "zymc"
        Me.ColZymc.HeaderText = "职员姓名"
        Me.ColZymc.Name = "ColZymc"
        Me.ColZymc.ReadOnly = True
        '
        'ColCpdm
        '
        Me.ColCpdm.DataPropertyName = "cpdm"
        Me.ColCpdm.HeaderText = "物料编码"
        Me.ColCpdm.MaxInputLength = 15
        Me.ColCpdm.MinimumWidth = 8
        Me.ColCpdm.Name = "ColCpdm"
        Me.ColCpdm.ReadOnly = True
        Me.ColCpdm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColCpdm.Width = 110
        '
        'ColCpmc
        '
        Me.ColCpmc.DataPropertyName = "cpmc"
        Me.ColCpmc.HeaderText = "物料描述"
        Me.ColCpmc.MaxInputLength = 50
        Me.ColCpmc.MinimumWidth = 8
        Me.ColCpmc.Name = "ColCpmc"
        Me.ColCpmc.ReadOnly = True
        Me.ColCpmc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColCpmc.Width = 240
        '
        'ColCsdm
        '
        Me.ColCsdm.DataPropertyName = "csdm"
        Me.ColCsdm.HeaderText = "供应商编码"
        Me.ColCsdm.MaxInputLength = 12
        Me.ColCsdm.MinimumWidth = 8
        Me.ColCsdm.Name = "ColCsdm"
        Me.ColCsdm.ReadOnly = True
        Me.ColCsdm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColCsdm.Width = 90
        '
        'ColCsmc
        '
        Me.ColCsmc.DataPropertyName = "csmc"
        Me.ColCsmc.HeaderText = "供应商名称"
        Me.ColCsmc.MaxInputLength = 50
        Me.ColCsmc.MinimumWidth = 8
        Me.ColCsmc.Name = "ColCsmc"
        Me.ColCsmc.ReadOnly = True
        Me.ColCsmc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColCsmc.Width = 180
        '
        'ColBrecycling
        '
        Me.ColBrecycling.DataPropertyName = "brecycling"
        Me.ColBrecycling.HeaderText = "旧件回收选项"
        Me.ColBrecycling.MinimumWidth = 8
        Me.ColBrecycling.Name = "ColBrecycling"
        Me.ColBrecycling.ReadOnly = True
        Me.ColBrecycling.Width = 55
        '
        'ColBFadm
        '
        Me.ColBFadm.DataPropertyName = "bfadm"
        Me.ColBFadm.HeaderText = "跟踪设备选项"
        Me.ColBFadm.MinimumWidth = 8
        Me.ColBFadm.Name = "ColBFadm"
        Me.ColBFadm.ReadOnly = True
        Me.ColBFadm.Width = 55
        '
        'ColFadm
        '
        Me.ColFadm.DataPropertyName = "fadm"
        Me.ColFadm.HeaderText = "设备编码"
        Me.ColFadm.MaxInputLength = 12
        Me.ColFadm.MinimumWidth = 8
        Me.ColFadm.Name = "ColFadm"
        Me.ColFadm.ReadOnly = True
        Me.ColFadm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColFadm.Width = 75
        '
        'ColFamc
        '
        Me.ColFamc.DataPropertyName = "famc"
        Me.ColFamc.HeaderText = "设备名称"
        Me.ColFamc.MaxInputLength = 50
        Me.ColFamc.MinimumWidth = 8
        Me.ColFamc.Name = "ColFamc"
        Me.ColFamc.ReadOnly = True
        Me.ColFamc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColFamc.Width = 135
        '
        'ColKuwei
        '
        Me.ColKuwei.DataPropertyName = "kuwei"
        Me.ColKuwei.HeaderText = "库位"
        Me.ColKuwei.MaxInputLength = 20
        Me.ColKuwei.MinimumWidth = 8
        Me.ColKuwei.Name = "ColKuwei"
        Me.ColKuwei.ReadOnly = True
        Me.ColKuwei.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColKuwei.Width = 90
        '
        'ColPiHao
        '
        Me.ColPiHao.DataPropertyName = "pihao"
        Me.ColPiHao.HeaderText = "批次号"
        Me.ColPiHao.MaxInputLength = 20
        Me.ColPiHao.Name = "ColPiHao"
        Me.ColPiHao.ReadOnly = True
        Me.ColPiHao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColSl
        '
        Me.ColSl.DataPropertyName = "sl"
        Me.ColSl.HeaderText = "数量"
        Me.ColSl.MaxInputLength = 18
        Me.ColSl.MinimumWidth = 8
        Me.ColSl.Name = "ColSl"
        Me.ColSl.ReadOnly = True
        Me.ColSl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColSl.Width = 90
        '
        'ColDw
        '
        Me.ColDw.DataPropertyName = "dw"
        Me.ColDw.HeaderText = "单位"
        Me.ColDw.MaxInputLength = 8
        Me.ColDw.MinimumWidth = 8
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
        Me.ColMjsl.MinimumWidth = 8
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
        Me.ColFzsl.MinimumWidth = 8
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
        Me.ColFzdw.MinimumWidth = 8
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
        Me.ColDj.MinimumWidth = 8
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
        Me.ColJe.MinimumWidth = 8
        Me.ColJe.Name = "ColJe"
        Me.ColJe.ReadOnly = True
        Me.ColJe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColJe.Width = 90
        '
        'ColRkmemo
        '
        Me.ColRkmemo.DataPropertyName = "ckmemo"
        Me.ColRkmemo.HeaderText = "备注"
        Me.ColRkmemo.MaxInputLength = 50
        Me.ColRkmemo.MinimumWidth = 8
        Me.ColRkmemo.Name = "ColRkmemo"
        Me.ColRkmemo.ReadOnly = True
        Me.ColRkmemo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColRkmemo.Width = 135
        '
        'ColDjh
        '
        Me.ColDjh.DataPropertyName = "djh"
        Me.ColDjh.HeaderText = "出库单单据号"
        Me.ColDjh.MaxInputLength = 15
        Me.ColDjh.MinimumWidth = 8
        Me.ColDjh.Name = "ColDjh"
        Me.ColDjh.ReadOnly = True
        Me.ColDjh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColDjh.Width = 110
        '
        'ColXh
        '
        Me.ColXh.DataPropertyName = "xh"
        Me.ColXh.HeaderText = "出库单行号"
        Me.ColXh.MaxInputLength = 4
        Me.ColXh.MinimumWidth = 8
        Me.ColXh.Name = "ColXh"
        Me.ColXh.ReadOnly = True
        Me.ColXh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColXh.Width = 60
        '
        'FrmInvRecycleSr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.rcDataGridView)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MnuMain)
        Me.Name = "FrmInvRecycleSr"
        Me.Text = "物料回收与取消回收"
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents TxtCpdm As TextBox
    Public WithEvents LblCpdm As Label
    Friend WithEvents BtnImpCkd As Button
    Friend WithEvents rcDataGridView As DataGridView
    Friend WithEvents MnuMain As MenuStrip
    Friend WithEvents MnuiFile As ToolStripMenuItem
    Friend WithEvents MnuiImpCkd As ToolStripMenuItem
    Friend WithEvents Mnui11 As ToolStripSeparator
    Friend WithEvents MnuiExit As ToolStripMenuItem
    Friend WithEvents MnuiEdit As ToolStripMenuItem
    Friend WithEvents MnuiCut As ToolStripMenuItem
    Friend WithEvents MnuiCopy As ToolStripMenuItem
    Friend WithEvents MnuiPaste As ToolStripMenuItem
    Friend WithEvents MnuiHelp As ToolStripMenuItem
    Friend WithEvents MnuiAbout As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Public WithEvents LblRkrqEnd As Label
    Public WithEvents DtpEnd As DateTimePicker
    Public WithEvents LblRkrqBegin As Label
    Public WithEvents DtpBegin As DateTimePicker
    Friend WithEvents rcBindingSource As BindingSource
    Friend WithEvents ColButtonText As DataGridViewButtonColumn
    Friend WithEvents ColCkrq As DataGridViewTextBoxColumn
    Friend WithEvents ColBmdm As DataGridViewTextBoxColumn
    Friend WithEvents ColBmmc As DataGridViewTextBoxColumn
    Friend WithEvents ColZydm As DataGridViewTextBoxColumn
    Friend WithEvents ColZymc As DataGridViewTextBoxColumn
    Friend WithEvents ColCpdm As DataGridViewTextBoxColumn
    Friend WithEvents ColCpmc As DataGridViewTextBoxColumn
    Friend WithEvents ColCsdm As DataGridViewTextBoxColumn
    Friend WithEvents ColCsmc As DataGridViewTextBoxColumn
    Friend WithEvents ColBrecycling As DataGridViewCheckBoxColumn
    Friend WithEvents ColBFadm As DataGridViewCheckBoxColumn
    Friend WithEvents ColFadm As DataGridViewTextBoxColumn
    Friend WithEvents ColFamc As DataGridViewTextBoxColumn
    Friend WithEvents ColKuwei As DataGridViewTextBoxColumn
    Friend WithEvents ColPiHao As DataGridViewTextBoxColumn
    Friend WithEvents ColSl As DataGridViewTextBoxColumn
    Friend WithEvents ColDw As DataGridViewTextBoxColumn
    Friend WithEvents ColMjsl As DataGridViewTextBoxColumn
    Friend WithEvents ColFzsl As DataGridViewTextBoxColumn
    Friend WithEvents ColFzdw As DataGridViewTextBoxColumn
    Friend WithEvents ColDj As DataGridViewTextBoxColumn
    Friend WithEvents ColJe As DataGridViewTextBoxColumn
    Friend WithEvents ColRkmemo As DataGridViewTextBoxColumn
    Friend WithEvents ColDjh As DataGridViewTextBoxColumn
    Friend WithEvents ColXh As DataGridViewTextBoxColumn
End Class
