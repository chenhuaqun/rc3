﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeYpddBmSrz
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
        Me.ToolStripPanel1 = New System.Windows.Forms.ToolStripPanel
        Me.MnuMain = New System.Windows.Forms.MenuStrip
        Me.MnuiFile = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiPageSetup = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiPreview = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiPrint = New System.Windows.Forms.ToolStripMenuItem
        Me.Mnui13 = New System.Windows.Forms.ToolStripSeparator
        Me.MnuiExit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiCut = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiCopy = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiPaste = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiHelp = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblDd = New System.Windows.Forms.Label
        Me.rcDataGridView = New System.Windows.Forms.DataGridView
        Me.ColDjh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColQdrq = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColHth = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColDdmemo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColBmdm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColBmmc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCpdm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCpmc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCpgg = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCpmemo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColDw = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColKhlh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColKhcz = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColKhjhrq = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColSl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColKhdm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColKhmc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColXh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.BtnPreview = New System.Windows.Forms.Button
        Me.BtnPrint = New System.Windows.Forms.Button
        Me.BtnExit = New System.Windows.Forms.Button
        Me.BtnHelp = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.rcBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ToolStripPanel1.SuspendLayout()
        Me.MnuMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripPanel1
        '
        Me.ToolStripPanel1.Controls.Add(Me.MnuMain)
        Me.ToolStripPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ToolStripPanel1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripPanel1.Name = "ToolStripPanel1"
        Me.ToolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.ToolStripPanel1.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ToolStripPanel1.Size = New System.Drawing.Size(786, 25)
        '
        'MnuMain
        '
        Me.MnuMain.Dock = System.Windows.Forms.DockStyle.None
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiFile, Me.MnuiEdit, Me.MnuiHelp})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(786, 25)
        Me.MnuMain.TabIndex = 1
        '
        'MnuiFile
        '
        Me.MnuiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiPageSetup, Me.MnuiPreview, Me.MnuiPrint, Me.Mnui13, Me.MnuiExit})
        Me.MnuiFile.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiFile.Name = "MnuiFile"
        Me.MnuiFile.Size = New System.Drawing.Size(58, 21)
        Me.MnuiFile.Text = "文件(&F)"
        '
        'MnuiPageSetup
        '
        Me.MnuiPageSetup.Name = "MnuiPageSetup"
        Me.MnuiPageSetup.Size = New System.Drawing.Size(141, 22)
        Me.MnuiPageSetup.Text = "页面设置(&U)"
        '
        'MnuiPreview
        '
        Me.MnuiPreview.Name = "MnuiPreview"
        Me.MnuiPreview.Size = New System.Drawing.Size(141, 22)
        Me.MnuiPreview.Text = "打印预览(&V)"
        '
        'MnuiPrint
        '
        Me.MnuiPrint.Name = "MnuiPrint"
        Me.MnuiPrint.Size = New System.Drawing.Size(141, 22)
        Me.MnuiPrint.Text = "打印(&P)"
        '
        'Mnui13
        '
        Me.Mnui13.Name = "Mnui13"
        Me.Mnui13.Size = New System.Drawing.Size(138, 6)
        '
        'MnuiExit
        '
        Me.MnuiExit.Name = "MnuiExit"
        Me.MnuiExit.Size = New System.Drawing.Size(141, 22)
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
        Me.MnuiCut.Size = New System.Drawing.Size(116, 22)
        Me.MnuiCut.Text = "剪切(&T)"
        '
        'MnuiCopy
        '
        Me.MnuiCopy.Name = "MnuiCopy"
        Me.MnuiCopy.Size = New System.Drawing.Size(116, 22)
        Me.MnuiCopy.Text = "复制(&C)"
        '
        'MnuiPaste
        '
        Me.MnuiPaste.Name = "MnuiPaste"
        Me.MnuiPaste.Size = New System.Drawing.Size(116, 22)
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
        Me.Panel1.Controls.Add(Me.LblDd)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(786, 48)
        Me.Panel1.TabIndex = 3
        '
        'LblDd
        '
        Me.LblDd.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblDd.AutoSize = True
        Me.LblDd.Font = New System.Drawing.Font("华文行楷", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblDd.ForeColor = System.Drawing.Color.CadetBlue
        Me.LblDd.Location = New System.Drawing.Point(337, 9)
        Me.LblDd.Name = "LblDd"
        Me.LblDd.Size = New System.Drawing.Size(112, 25)
        Me.LblDd.TabIndex = 0
        Me.LblDd.Text = "样品订单"
        '
        'rcDataGridView
        '
        Me.rcDataGridView.AllowUserToAddRows = False
        Me.rcDataGridView.AllowUserToDeleteRows = False
        Me.rcDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.rcDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColDjh, Me.ColQdrq, Me.ColHth, Me.ColDdmemo, Me.ColBmdm, Me.ColBmmc, Me.ColCpdm, Me.ColCpmc, Me.ColCpgg, Me.ColCpmemo, Me.ColDw, Me.ColKhlh, Me.ColKhcz, Me.ColKhjhrq, Me.ColSl, Me.ColKhdm, Me.ColKhmc, Me.ColXh})
        Me.rcDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rcDataGridView.Location = New System.Drawing.Point(0, 73)
        Me.rcDataGridView.Name = "rcDataGridView"
        Me.rcDataGridView.RowTemplate.Height = 23
        Me.rcDataGridView.Size = New System.Drawing.Size(786, 365)
        Me.rcDataGridView.TabIndex = 4
        '
        'ColDjh
        '
        Me.ColDjh.DataPropertyName = "djh"
        Me.ColDjh.HeaderText = "单据号"
        Me.ColDjh.Name = "ColDjh"
        Me.ColDjh.ReadOnly = True
        Me.ColDjh.Width = 105
        '
        'ColQdrq
        '
        Me.ColQdrq.DataPropertyName = "qdrq"
        Me.ColQdrq.HeaderText = "签单日期"
        Me.ColQdrq.Name = "ColQdrq"
        Me.ColQdrq.ReadOnly = True
        Me.ColQdrq.Width = 80
        '
        'ColHth
        '
        Me.ColHth.DataPropertyName = "hth"
        Me.ColHth.HeaderText = "合同编码"
        Me.ColHth.Name = "ColHth"
        Me.ColHth.ReadOnly = True
        Me.ColHth.Width = 80
        '
        'ColDdmemo
        '
        Me.ColDdmemo.DataPropertyName = "ddmemo"
        Me.ColDdmemo.HeaderText = "备注"
        Me.ColDdmemo.Name = "ColDdmemo"
        Me.ColDdmemo.ReadOnly = True
        Me.ColDdmemo.Width = 90
        '
        'ColBmdm
        '
        Me.ColBmdm.DataPropertyName = "bmdm"
        Me.ColBmdm.HeaderText = "部门编码"
        Me.ColBmdm.MaxInputLength = 12
        Me.ColBmdm.Name = "ColBmdm"
        Me.ColBmdm.Width = 55
        '
        'ColBmmc
        '
        Me.ColBmmc.DataPropertyName = "bmmc"
        Me.ColBmmc.HeaderText = "部门名称"
        Me.ColBmmc.Name = "ColBmmc"
        Me.ColBmmc.ReadOnly = True
        Me.ColBmmc.Width = 80
        '
        'ColCpdm
        '
        Me.ColCpdm.DataPropertyName = "cpdm"
        Me.ColCpdm.HeaderText = "产品编码"
        Me.ColCpdm.Name = "ColCpdm"
        Me.ColCpdm.ReadOnly = True
        Me.ColCpdm.Width = 80
        '
        'ColCpmc
        '
        Me.ColCpmc.DataPropertyName = "cpmc"
        Me.ColCpmc.HeaderText = "产品名称"
        Me.ColCpmc.Name = "ColCpmc"
        Me.ColCpmc.ReadOnly = True
        Me.ColCpmc.Width = 135
        '
        'ColCpgg
        '
        Me.ColCpgg.DataPropertyName = "cpgg"
        Me.ColCpgg.HeaderText = "规格型号"
        Me.ColCpgg.Name = "ColCpgg"
        Me.ColCpgg.ReadOnly = True
        Me.ColCpgg.Width = 135
        '
        'ColCpmemo
        '
        Me.ColCpmemo.DataPropertyName = "cpmemo"
        Me.ColCpmemo.HeaderText = "产品属性"
        Me.ColCpmemo.Name = "ColCpmemo"
        Me.ColCpmemo.ReadOnly = True
        Me.ColCpmemo.Width = 135
        '
        'ColDw
        '
        Me.ColDw.DataPropertyName = "dw"
        Me.ColDw.HeaderText = "单位"
        Me.ColDw.Name = "ColDw"
        Me.ColDw.ReadOnly = True
        Me.ColDw.Width = 45
        '
        'ColKhlh
        '
        Me.ColKhlh.DataPropertyName = "khlh"
        Me.ColKhlh.HeaderText = "客户料号"
        Me.ColKhlh.Name = "ColKhlh"
        Me.ColKhlh.ReadOnly = True
        Me.ColKhlh.Width = 90
        '
        'ColKhcz
        '
        Me.ColKhcz.DataPropertyName = "khcz"
        Me.ColKhcz.HeaderText = "客户材质"
        Me.ColKhcz.Name = "ColKhcz"
        Me.ColKhcz.ReadOnly = True
        Me.ColKhcz.Width = 90
        '
        'ColKhjhrq
        '
        Me.ColKhjhrq.DataPropertyName = "khjhrq"
        Me.ColKhjhrq.HeaderText = "客户交期"
        Me.ColKhjhrq.Name = "ColKhjhrq"
        Me.ColKhjhrq.ReadOnly = True
        Me.ColKhjhrq.Width = 80
        '
        'ColSl
        '
        Me.ColSl.DataPropertyName = "sl"
        Me.ColSl.HeaderText = "数量"
        Me.ColSl.Name = "ColSl"
        Me.ColSl.ReadOnly = True
        Me.ColSl.Width = 80
        '
        'ColKhdm
        '
        Me.ColKhdm.DataPropertyName = "khdm"
        Me.ColKhdm.HeaderText = "客户编码"
        Me.ColKhdm.Name = "ColKhdm"
        Me.ColKhdm.ReadOnly = True
        Me.ColKhdm.Width = 80
        '
        'ColKhmc
        '
        Me.ColKhmc.DataPropertyName = "khmc"
        Me.ColKhmc.HeaderText = "客户名称"
        Me.ColKhmc.Name = "ColKhmc"
        Me.ColKhmc.ReadOnly = True
        Me.ColKhmc.Width = 135
        '
        'ColXh
        '
        Me.ColXh.DataPropertyName = "xh"
        Me.ColXh.HeaderText = "行号"
        Me.ColXh.Name = "ColXh"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtnPreview)
        Me.Panel2.Controls.Add(Me.BtnPrint)
        Me.Panel2.Controls.Add(Me.BtnExit)
        Me.Panel2.Controls.Add(Me.BtnHelp)
        Me.Panel2.Controls.Add(Me.BtnSave)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 438)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(786, 59)
        Me.Panel2.TabIndex = 5
        '
        'BtnPreview
        '
        Me.BtnPreview.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnPreview.Location = New System.Drawing.Point(274, 19)
        Me.BtnPreview.Name = "BtnPreview"
        Me.BtnPreview.Size = New System.Drawing.Size(75, 23)
        Me.BtnPreview.TabIndex = 2
        Me.BtnPreview.Text = "预览(&V)"
        Me.BtnPreview.Visible = False
        '
        'BtnPrint
        '
        Me.BtnPrint.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnPrint.Location = New System.Drawing.Point(194, 19)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrint.TabIndex = 1
        Me.BtnPrint.Text = "打印(&P)"
        Me.BtnPrint.Visible = False
        '
        'BtnExit
        '
        Me.BtnExit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnExit.Location = New System.Drawing.Point(514, 19)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 23)
        Me.BtnExit.TabIndex = 5
        Me.BtnExit.Text = "退出(&X)"
        '
        'BtnHelp
        '
        Me.BtnHelp.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnHelp.Location = New System.Drawing.Point(434, 19)
        Me.BtnHelp.Name = "BtnHelp"
        Me.BtnHelp.Size = New System.Drawing.Size(75, 23)
        Me.BtnHelp.TabIndex = 4
        Me.BtnHelp.Text = "帮助(&H)"
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnSave.Location = New System.Drawing.Point(354, 19)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 3
        Me.BtnSave.Text = "保存(&S)"
        '
        'FrmOeYpddBmSrz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(786, 497)
        Me.Controls.Add(Me.rcDataGridView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStripPanel1)
        Me.Name = "FrmOeYpddBmSrz"
        Me.Text = "样品生产厂录入"
        Me.ToolStripPanel1.ResumeLayout(False)
        Me.ToolStripPanel1.PerformLayout()
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.rcBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripPanel1 As System.Windows.Forms.ToolStripPanel
    Friend WithEvents MnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuiFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiPageSetup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiPreview As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Mnui13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuiExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiCut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiPaste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LblDd As System.Windows.Forms.Label
    Friend WithEvents rcDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnPreview As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents BtnHelp As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents rcBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ColDjh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColQdrq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColHth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDdmemo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBmdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBmmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCpdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCpmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCpgg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCpmemo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDw As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKhlh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKhcz As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKhjhrq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKhdm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColKhmc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColXh As System.Windows.Forms.DataGridViewTextBoxColumn
End Class