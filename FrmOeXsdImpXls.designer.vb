﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeXsdImpXls
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOeXsdImpXls))
        Me.ToolStripPanel1 = New System.Windows.Forms.ToolStripPanel()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.TsbImp = New System.Windows.Forms.ToolStripButton()
        Me.TsbSave = New System.Windows.Forms.ToolStripButton()
        Me.Tss1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TsbExit = New System.Windows.Forms.ToolStripButton()
        Me.MnuMain = New System.Windows.Forms.MenuStrip()
        Me.MnuiFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiImp = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mnui13 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuiExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtSheetName = New System.Windows.Forms.TextBox()
        Me.BtnXzwj = New System.Windows.Forms.Button()
        Me.TxtSourceExcelFileName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.OfdSourceExcelFileName = New System.Windows.Forms.OpenFileDialog()
        Me.ToolStripPanel1.SuspendLayout()
        Me.ToolStripMain.SuspendLayout()
        Me.MnuMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripPanel1
        '
        Me.ToolStripPanel1.Controls.Add(Me.ToolStripMain)
        Me.ToolStripPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ToolStripPanel1.Location = New System.Drawing.Point(0, 36)
        Me.ToolStripPanel1.Name = "ToolStripPanel1"
        Me.ToolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.ToolStripPanel1.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ToolStripPanel1.Size = New System.Drawing.Size(1476, 41)
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripMain.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsbImp, Me.TsbSave, Me.Tss1, Me.TsbExit})
        Me.ToolStripMain.Location = New System.Drawing.Point(3, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(270, 41)
        Me.ToolStripMain.TabIndex = 2
        '
        'TsbImp
        '
        Me.TsbImp.Image = CType(resources.GetObject("TsbImp.Image"), System.Drawing.Image)
        Me.TsbImp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbImp.Name = "TsbImp"
        Me.TsbImp.Size = New System.Drawing.Size(82, 36)
        Me.TsbImp.Text = "导入"
        '
        'TsbSave
        '
        Me.TsbSave.Image = CType(resources.GetObject("TsbSave.Image"), System.Drawing.Image)
        Me.TsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbSave.Name = "TsbSave"
        Me.TsbSave.Size = New System.Drawing.Size(82, 36)
        Me.TsbSave.Text = "保存"
        '
        'Tss1
        '
        Me.Tss1.Name = "Tss1"
        Me.Tss1.Size = New System.Drawing.Size(6, 41)
        '
        'TsbExit
        '
        Me.TsbExit.Image = CType(resources.GetObject("TsbExit.Image"), System.Drawing.Image)
        Me.TsbExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbExit.Name = "TsbExit"
        Me.TsbExit.Size = New System.Drawing.Size(82, 36)
        Me.TsbExit.Text = "退出"
        '
        'MnuMain
        '
        Me.MnuMain.GripMargin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.MnuMain.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiFile, Me.MnuiEdit, Me.MnuiHelp})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(1476, 36)
        Me.MnuMain.TabIndex = 1
        '
        'MnuiFile
        '
        Me.MnuiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiImp, Me.MnuiSave, Me.Mnui13, Me.MnuiExit})
        Me.MnuiFile.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiFile.Name = "MnuiFile"
        Me.MnuiFile.Size = New System.Drawing.Size(84, 30)
        Me.MnuiFile.Text = "文件(&F)"
        '
        'MnuiImp
        '
        Me.MnuiImp.Name = "MnuiImp"
        Me.MnuiImp.Size = New System.Drawing.Size(170, 34)
        Me.MnuiImp.Text = "导入"
        '
        'MnuiSave
        '
        Me.MnuiSave.Name = "MnuiSave"
        Me.MnuiSave.Size = New System.Drawing.Size(170, 34)
        Me.MnuiSave.Text = "保存(&S)"
        '
        'Mnui13
        '
        Me.Mnui13.Name = "Mnui13"
        Me.Mnui13.Size = New System.Drawing.Size(167, 6)
        '
        'MnuiExit
        '
        Me.MnuiExit.Name = "MnuiExit"
        Me.MnuiExit.Size = New System.Drawing.Size(170, 34)
        Me.MnuiExit.Text = "退出(&X)"
        '
        'MnuiEdit
        '
        Me.MnuiEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiCut, Me.MnuiCopy, Me.MnuiPaste})
        Me.MnuiEdit.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiEdit.Name = "MnuiEdit"
        Me.MnuiEdit.Size = New System.Drawing.Size(84, 30)
        Me.MnuiEdit.Text = "编辑(&E)"
        '
        'MnuiCut
        '
        Me.MnuiCut.Name = "MnuiCut"
        Me.MnuiCut.Size = New System.Drawing.Size(170, 34)
        Me.MnuiCut.Text = "剪切(&T)"
        '
        'MnuiCopy
        '
        Me.MnuiCopy.Name = "MnuiCopy"
        Me.MnuiCopy.Size = New System.Drawing.Size(170, 34)
        Me.MnuiCopy.Text = "复制(&C)"
        '
        'MnuiPaste
        '
        Me.MnuiPaste.Name = "MnuiPaste"
        Me.MnuiPaste.Size = New System.Drawing.Size(170, 34)
        Me.MnuiPaste.Text = "粘贴(&P)"
        '
        'MnuiHelp
        '
        Me.MnuiHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiAbout})
        Me.MnuiHelp.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiHelp.Name = "MnuiHelp"
        Me.MnuiHelp.Size = New System.Drawing.Size(88, 30)
        Me.MnuiHelp.Text = "帮助(&H)"
        '
        'MnuiAbout
        '
        Me.MnuiAbout.Name = "MnuiAbout"
        Me.MnuiAbout.Size = New System.Drawing.Size(171, 34)
        Me.MnuiAbout.Text = "关于(&A)"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.RadioButton2)
        Me.Panel1.Controls.Add(Me.RadioButton1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TxtSheetName)
        Me.Panel1.Controls.Add(Me.BtnXzwj)
        Me.Panel1.Controls.Add(Me.TxtSourceExcelFileName)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 77)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1476, 122)
        Me.Panel1.TabIndex = 3
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(795, 72)
        Me.RadioButton2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(69, 22)
        Me.RadioButton2.TabIndex = 16
        Me.RadioButton2.Text = "追加"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(688, 72)
        Me.RadioButton1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(69, 22)
        Me.RadioButton1.TabIndex = 15
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "覆盖"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(45, 69)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(215, 18)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "读取Excel的工作表名称："
        '
        'TxtSheetName
        '
        Me.TxtSheetName.Location = New System.Drawing.Point(268, 64)
        Me.TxtSheetName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtSheetName.Name = "TxtSheetName"
        Me.TxtSheetName.Size = New System.Drawing.Size(280, 28)
        Me.TxtSheetName.TabIndex = 13
        Me.TxtSheetName.Text = "产品送货单"
        '
        'BtnXzwj
        '
        Me.BtnXzwj.Location = New System.Drawing.Point(1010, 21)
        Me.BtnXzwj.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnXzwj.Name = "BtnXzwj"
        Me.BtnXzwj.Size = New System.Drawing.Size(36, 34)
        Me.BtnXzwj.TabIndex = 12
        Me.BtnXzwj.Text = "…"
        Me.BtnXzwj.UseVisualStyleBackColor = True
        '
        'TxtSourceExcelFileName
        '
        Me.TxtSourceExcelFileName.Location = New System.Drawing.Point(232, 24)
        Me.TxtSourceExcelFileName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtSourceExcelFileName.Name = "TxtSourceExcelFileName"
        Me.TxtSourceExcelFileName.Size = New System.Drawing.Size(766, 28)
        Me.TxtSourceExcelFileName.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(45, 24)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 18)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "源文件(Excel格式)："
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView1.ColumnHeadersHeight = 25
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 199)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 62
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1476, 643)
        Me.DataGridView1.TabIndex = 4
        '
        'OfdSourceExcelFileName
        '
        Me.OfdSourceExcelFileName.Filter = "Excel 2003 文件|*.xls|Excel 2007 文件|*.xlsx"
        Me.OfdSourceExcelFileName.Title = "选择文件"
        '
        'FrmOeXsdImpXls
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1476, 842)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStripPanel1)
        Me.Controls.Add(Me.MnuMain)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FrmOeXsdImpXls"
        Me.Text = "产品送货单读入"
        Me.ToolStripPanel1.ResumeLayout(False)
        Me.ToolStripPanel1.PerformLayout()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripPanel1 As System.Windows.Forms.ToolStripPanel
    Friend WithEvents MnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuiFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Mnui13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuiExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiCut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiPaste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents TsbImp As System.Windows.Forms.ToolStripButton
    Friend WithEvents TsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tss1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TsbExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtSheetName As System.Windows.Forms.TextBox
    Friend WithEvents BtnXzwj As System.Windows.Forms.Button
    Friend WithEvents TxtSourceExcelFileName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents MnuiImp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OfdSourceExcelFileName As System.Windows.Forms.OpenFileDialog
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
End Class
