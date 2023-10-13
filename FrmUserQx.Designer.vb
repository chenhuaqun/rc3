<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUserQx
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
        Me.rcTabControl = New System.Windows.Forms.TabControl
        Me.TabPageDwdm = New System.Windows.Forms.TabPage
        Me.ListBoxYuxuanDwdm = New System.Windows.Forms.ListBox
        Me.ListBoxYixuanDwdm = New System.Windows.Forms.ListBox
        Me.BtnSelectAllDwdm = New System.Windows.Forms.Button
        Me.BtnSelectOneDwdm = New System.Windows.Forms.Button
        Me.BtnUnSelectOneDwdm = New System.Windows.Forms.Button
        Me.BtnUnSelectAllDwdm = New System.Windows.Forms.Button
        Me.LblYuxuanDwdm = New System.Windows.Forms.Label
        Me.LblYixuanDwdm = New System.Windows.Forms.Label
        Me.TabPageRole = New System.Windows.Forms.TabPage
        Me.ListBoxYuxuanRole = New System.Windows.Forms.ListBox
        Me.ListBoxYixuanRole = New System.Windows.Forms.ListBox
        Me.BtnSelectAllRole = New System.Windows.Forms.Button
        Me.BtnSelectOneRole = New System.Windows.Forms.Button
        Me.BtnUnSelectOneRole = New System.Windows.Forms.Button
        Me.BtnUnSelectAllRole = New System.Windows.Forms.Button
        Me.LblYuxuanRole = New System.Windows.Forms.Label
        Me.LblYixuanRole = New System.Windows.Forms.Label
        Me.TabPageLbdm = New System.Windows.Forms.TabPage
        Me.ListBoxYuxuanLbdm = New System.Windows.Forms.ListBox
        Me.ListBoxYixuanLbdm = New System.Windows.Forms.ListBox
        Me.BtnSelectAllLbdm = New System.Windows.Forms.Button
        Me.BtnSelectOneLbdm = New System.Windows.Forms.Button
        Me.BtnUnSelectOneLbdm = New System.Windows.Forms.Button
        Me.BtnUnSelectAllLbdm = New System.Windows.Forms.Button
        Me.LblYuxuanLbdm = New System.Windows.Forms.Label
        Me.LblYixuanLbdm = New System.Windows.Forms.Label
        Me.TabPageBmdm = New System.Windows.Forms.TabPage
        Me.ListBoxYuxuanBmdm = New System.Windows.Forms.ListBox
        Me.ListBoxYixuanBmdm = New System.Windows.Forms.ListBox
        Me.BtnSelectAllBmdm = New System.Windows.Forms.Button
        Me.BtnSelectOneBmdm = New System.Windows.Forms.Button
        Me.BtnUnSelectOneBmdm = New System.Windows.Forms.Button
        Me.BtnUnSelectAllBmdm = New System.Windows.Forms.Button
        Me.LblYuxuanBmdm = New System.Windows.Forms.Label
        Me.LblYixuanBmdm = New System.Windows.Forms.Label
        Me.TabPagePzlx = New System.Windows.Forms.TabPage
        Me.ListBoxYuxuanPzlx = New System.Windows.Forms.ListBox
        Me.ListBoxYixuanPzlx = New System.Windows.Forms.ListBox
        Me.BtnSelectAllPzlx = New System.Windows.Forms.Button
        Me.BtnSelectOnePzlx = New System.Windows.Forms.Button
        Me.BtnUnSelectOnePzlx = New System.Windows.Forms.Button
        Me.BtnUnSelectAllPzlx = New System.Windows.Forms.Button
        Me.LblYuxuanPzlx = New System.Windows.Forms.Label
        Me.LblYixuanPzlx = New System.Windows.Forms.Label
        Me.DlgPanel.SuspendLayout()
        Me.rcTabControl.SuspendLayout()
        Me.TabPageDwdm.SuspendLayout()
        Me.TabPageRole.SuspendLayout()
        Me.TabPageLbdm.SuspendLayout()
        Me.TabPageBmdm.SuspendLayout()
        Me.TabPagePzlx.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(255, 360)
        '
        'rcTabControl
        '
        Me.rcTabControl.Controls.Add(Me.TabPageDwdm)
        Me.rcTabControl.Controls.Add(Me.TabPageRole)
        Me.rcTabControl.Controls.Add(Me.TabPageLbdm)
        Me.rcTabControl.Controls.Add(Me.TabPageBmdm)
        Me.rcTabControl.Controls.Add(Me.TabPagePzlx)
        Me.rcTabControl.Location = New System.Drawing.Point(10, 10)
        Me.rcTabControl.Name = "rcTabControl"
        Me.rcTabControl.SelectedIndex = 0
        Me.rcTabControl.Size = New System.Drawing.Size(488, 328)
        Me.rcTabControl.TabIndex = 102
        '
        'TabPageDwdm
        '
        Me.TabPageDwdm.Controls.Add(Me.ListBoxYuxuanDwdm)
        Me.TabPageDwdm.Controls.Add(Me.ListBoxYixuanDwdm)
        Me.TabPageDwdm.Controls.Add(Me.BtnSelectAllDwdm)
        Me.TabPageDwdm.Controls.Add(Me.BtnSelectOneDwdm)
        Me.TabPageDwdm.Controls.Add(Me.BtnUnSelectOneDwdm)
        Me.TabPageDwdm.Controls.Add(Me.BtnUnSelectAllDwdm)
        Me.TabPageDwdm.Controls.Add(Me.LblYuxuanDwdm)
        Me.TabPageDwdm.Controls.Add(Me.LblYixuanDwdm)
        Me.TabPageDwdm.Location = New System.Drawing.Point(4, 22)
        Me.TabPageDwdm.Name = "TabPageDwdm"
        Me.TabPageDwdm.Size = New System.Drawing.Size(480, 302)
        Me.TabPageDwdm.TabIndex = 0
        Me.TabPageDwdm.Text = "核算单位权限"
        Me.TabPageDwdm.ToolTipText = "选择核算单位权限"
        Me.TabPageDwdm.UseVisualStyleBackColor = True
        '
        'ListBoxYuxuanDwdm
        '
        Me.ListBoxYuxuanDwdm.ItemHeight = 12
        Me.ListBoxYuxuanDwdm.Location = New System.Drawing.Point(8, 32)
        Me.ListBoxYuxuanDwdm.Name = "ListBoxYuxuanDwdm"
        Me.ListBoxYuxuanDwdm.Size = New System.Drawing.Size(184, 256)
        Me.ListBoxYuxuanDwdm.Sorted = True
        Me.ListBoxYuxuanDwdm.TabIndex = 15
        '
        'ListBoxYixuanDwdm
        '
        Me.ListBoxYixuanDwdm.ItemHeight = 12
        Me.ListBoxYixuanDwdm.Location = New System.Drawing.Point(288, 32)
        Me.ListBoxYixuanDwdm.Name = "ListBoxYixuanDwdm"
        Me.ListBoxYixuanDwdm.Size = New System.Drawing.Size(184, 256)
        Me.ListBoxYixuanDwdm.Sorted = True
        Me.ListBoxYixuanDwdm.TabIndex = 16
        '
        'BtnSelectAllDwdm
        '
        Me.BtnSelectAllDwdm.Location = New System.Drawing.Point(200, 40)
        Me.BtnSelectAllDwdm.Name = "BtnSelectAllDwdm"
        Me.BtnSelectAllDwdm.Size = New System.Drawing.Size(75, 23)
        Me.BtnSelectAllDwdm.TabIndex = 9
        Me.BtnSelectAllDwdm.Text = "-->>"
        '
        'BtnSelectOneDwdm
        '
        Me.BtnSelectOneDwdm.Location = New System.Drawing.Point(200, 80)
        Me.BtnSelectOneDwdm.Name = "BtnSelectOneDwdm"
        Me.BtnSelectOneDwdm.Size = New System.Drawing.Size(75, 23)
        Me.BtnSelectOneDwdm.TabIndex = 10
        Me.BtnSelectOneDwdm.Text = "-->"
        '
        'BtnUnSelectOneDwdm
        '
        Me.BtnUnSelectOneDwdm.Location = New System.Drawing.Point(200, 120)
        Me.BtnUnSelectOneDwdm.Name = "BtnUnSelectOneDwdm"
        Me.BtnUnSelectOneDwdm.Size = New System.Drawing.Size(75, 23)
        Me.BtnUnSelectOneDwdm.TabIndex = 11
        Me.BtnUnSelectOneDwdm.Text = "<--"
        '
        'BtnUnSelectAllDwdm
        '
        Me.BtnUnSelectAllDwdm.Location = New System.Drawing.Point(200, 160)
        Me.BtnUnSelectAllDwdm.Name = "BtnUnSelectAllDwdm"
        Me.BtnUnSelectAllDwdm.Size = New System.Drawing.Size(75, 23)
        Me.BtnUnSelectAllDwdm.TabIndex = 12
        Me.BtnUnSelectAllDwdm.Text = "<<--"
        '
        'LblYuxuanDwdm
        '
        Me.LblYuxuanDwdm.AutoSize = True
        Me.LblYuxuanDwdm.Location = New System.Drawing.Point(8, 8)
        Me.LblYuxuanDwdm.Name = "LblYuxuanDwdm"
        Me.LblYuxuanDwdm.Size = New System.Drawing.Size(77, 12)
        Me.LblYuxuanDwdm.TabIndex = 13
        Me.LblYuxuanDwdm.Text = "预选核算单位"
        '
        'LblYixuanDwdm
        '
        Me.LblYixuanDwdm.AutoSize = True
        Me.LblYixuanDwdm.Location = New System.Drawing.Point(288, 8)
        Me.LblYixuanDwdm.Name = "LblYixuanDwdm"
        Me.LblYixuanDwdm.Size = New System.Drawing.Size(77, 12)
        Me.LblYixuanDwdm.TabIndex = 14
        Me.LblYixuanDwdm.Text = "已选核算单位"
        '
        'TabPageRole
        '
        Me.TabPageRole.Controls.Add(Me.ListBoxYuxuanRole)
        Me.TabPageRole.Controls.Add(Me.ListBoxYixuanRole)
        Me.TabPageRole.Controls.Add(Me.BtnSelectAllRole)
        Me.TabPageRole.Controls.Add(Me.BtnSelectOneRole)
        Me.TabPageRole.Controls.Add(Me.BtnUnSelectOneRole)
        Me.TabPageRole.Controls.Add(Me.BtnUnSelectAllRole)
        Me.TabPageRole.Controls.Add(Me.LblYuxuanRole)
        Me.TabPageRole.Controls.Add(Me.LblYixuanRole)
        Me.TabPageRole.Location = New System.Drawing.Point(4, 22)
        Me.TabPageRole.Name = "TabPageRole"
        Me.TabPageRole.Size = New System.Drawing.Size(480, 302)
        Me.TabPageRole.TabIndex = 1
        Me.TabPageRole.Text = "角色选择"
        Me.TabPageRole.UseVisualStyleBackColor = True
        '
        'ListBoxYuxuanRole
        '
        Me.ListBoxYuxuanRole.ItemHeight = 12
        Me.ListBoxYuxuanRole.Location = New System.Drawing.Point(8, 32)
        Me.ListBoxYuxuanRole.Name = "ListBoxYuxuanRole"
        Me.ListBoxYuxuanRole.Size = New System.Drawing.Size(184, 256)
        Me.ListBoxYuxuanRole.Sorted = True
        Me.ListBoxYuxuanRole.TabIndex = 23
        '
        'ListBoxYixuanRole
        '
        Me.ListBoxYixuanRole.ItemHeight = 12
        Me.ListBoxYixuanRole.Location = New System.Drawing.Point(288, 32)
        Me.ListBoxYixuanRole.Name = "ListBoxYixuanRole"
        Me.ListBoxYixuanRole.Size = New System.Drawing.Size(184, 256)
        Me.ListBoxYixuanRole.Sorted = True
        Me.ListBoxYixuanRole.TabIndex = 24
        '
        'BtnSelectAllRole
        '
        Me.BtnSelectAllRole.Location = New System.Drawing.Point(200, 40)
        Me.BtnSelectAllRole.Name = "BtnSelectAllRole"
        Me.BtnSelectAllRole.Size = New System.Drawing.Size(75, 23)
        Me.BtnSelectAllRole.TabIndex = 17
        Me.BtnSelectAllRole.Text = "-->>"
        '
        'BtnSelectOneRole
        '
        Me.BtnSelectOneRole.Location = New System.Drawing.Point(200, 80)
        Me.BtnSelectOneRole.Name = "BtnSelectOneRole"
        Me.BtnSelectOneRole.Size = New System.Drawing.Size(75, 23)
        Me.BtnSelectOneRole.TabIndex = 18
        Me.BtnSelectOneRole.Text = "-->"
        '
        'BtnUnSelectOneRole
        '
        Me.BtnUnSelectOneRole.Location = New System.Drawing.Point(200, 120)
        Me.BtnUnSelectOneRole.Name = "BtnUnSelectOneRole"
        Me.BtnUnSelectOneRole.Size = New System.Drawing.Size(75, 23)
        Me.BtnUnSelectOneRole.TabIndex = 19
        Me.BtnUnSelectOneRole.Text = "<--"
        '
        'BtnUnSelectAllRole
        '
        Me.BtnUnSelectAllRole.Location = New System.Drawing.Point(200, 160)
        Me.BtnUnSelectAllRole.Name = "BtnUnSelectAllRole"
        Me.BtnUnSelectAllRole.Size = New System.Drawing.Size(75, 23)
        Me.BtnUnSelectAllRole.TabIndex = 20
        Me.BtnUnSelectAllRole.Text = "<<--"
        '
        'LblYuxuanRole
        '
        Me.LblYuxuanRole.AutoSize = True
        Me.LblYuxuanRole.Location = New System.Drawing.Point(8, 8)
        Me.LblYuxuanRole.Name = "LblYuxuanRole"
        Me.LblYuxuanRole.Size = New System.Drawing.Size(53, 12)
        Me.LblYuxuanRole.TabIndex = 21
        Me.LblYuxuanRole.Text = "预选角色"
        '
        'LblYixuanRole
        '
        Me.LblYixuanRole.AutoSize = True
        Me.LblYixuanRole.Location = New System.Drawing.Point(288, 8)
        Me.LblYixuanRole.Name = "LblYixuanRole"
        Me.LblYixuanRole.Size = New System.Drawing.Size(53, 12)
        Me.LblYixuanRole.TabIndex = 22
        Me.LblYixuanRole.Text = "已选角色"
        '
        'TabPageLbdm
        '
        Me.TabPageLbdm.Controls.Add(Me.ListBoxYuxuanLbdm)
        Me.TabPageLbdm.Controls.Add(Me.ListBoxYixuanLbdm)
        Me.TabPageLbdm.Controls.Add(Me.BtnSelectAllLbdm)
        Me.TabPageLbdm.Controls.Add(Me.BtnSelectOneLbdm)
        Me.TabPageLbdm.Controls.Add(Me.BtnUnSelectOneLbdm)
        Me.TabPageLbdm.Controls.Add(Me.BtnUnSelectAllLbdm)
        Me.TabPageLbdm.Controls.Add(Me.LblYuxuanLbdm)
        Me.TabPageLbdm.Controls.Add(Me.LblYixuanLbdm)
        Me.TabPageLbdm.Location = New System.Drawing.Point(4, 22)
        Me.TabPageLbdm.Name = "TabPageLbdm"
        Me.TabPageLbdm.Size = New System.Drawing.Size(480, 302)
        Me.TabPageLbdm.TabIndex = 1
        Me.TabPageLbdm.Text = "物料类别权限"
        Me.TabPageLbdm.UseVisualStyleBackColor = True
        '
        'ListBoxYuxuanLbdm
        '
        Me.ListBoxYuxuanLbdm.ItemHeight = 12
        Me.ListBoxYuxuanLbdm.Location = New System.Drawing.Point(8, 32)
        Me.ListBoxYuxuanLbdm.Name = "ListBoxYuxuanLbdm"
        Me.ListBoxYuxuanLbdm.Size = New System.Drawing.Size(184, 256)
        Me.ListBoxYuxuanLbdm.Sorted = True
        Me.ListBoxYuxuanLbdm.TabIndex = 23
        '
        'ListBoxYixuanLbdm
        '
        Me.ListBoxYixuanLbdm.ItemHeight = 12
        Me.ListBoxYixuanLbdm.Location = New System.Drawing.Point(288, 32)
        Me.ListBoxYixuanLbdm.Name = "ListBoxYixuanLbdm"
        Me.ListBoxYixuanLbdm.Size = New System.Drawing.Size(184, 256)
        Me.ListBoxYixuanLbdm.Sorted = True
        Me.ListBoxYixuanLbdm.TabIndex = 24
        '
        'BtnSelectAllLbdm
        '
        Me.BtnSelectAllLbdm.Location = New System.Drawing.Point(200, 40)
        Me.BtnSelectAllLbdm.Name = "BtnSelectAllLbdm"
        Me.BtnSelectAllLbdm.Size = New System.Drawing.Size(75, 23)
        Me.BtnSelectAllLbdm.TabIndex = 17
        Me.BtnSelectAllLbdm.Text = "-->>"
        '
        'BtnSelectOneLbdm
        '
        Me.BtnSelectOneLbdm.Location = New System.Drawing.Point(200, 80)
        Me.BtnSelectOneLbdm.Name = "BtnSelectOneLbdm"
        Me.BtnSelectOneLbdm.Size = New System.Drawing.Size(75, 23)
        Me.BtnSelectOneLbdm.TabIndex = 18
        Me.BtnSelectOneLbdm.Text = "-->"
        '
        'BtnUnSelectOneLbdm
        '
        Me.BtnUnSelectOneLbdm.Location = New System.Drawing.Point(200, 120)
        Me.BtnUnSelectOneLbdm.Name = "BtnUnSelectOneLbdm"
        Me.BtnUnSelectOneLbdm.Size = New System.Drawing.Size(75, 23)
        Me.BtnUnSelectOneLbdm.TabIndex = 19
        Me.BtnUnSelectOneLbdm.Text = "<--"
        '
        'BtnUnSelectAllLbdm
        '
        Me.BtnUnSelectAllLbdm.Location = New System.Drawing.Point(200, 160)
        Me.BtnUnSelectAllLbdm.Name = "BtnUnSelectAllLbdm"
        Me.BtnUnSelectAllLbdm.Size = New System.Drawing.Size(75, 23)
        Me.BtnUnSelectAllLbdm.TabIndex = 20
        Me.BtnUnSelectAllLbdm.Text = "<<--"
        '
        'LblYuxuanLbdm
        '
        Me.LblYuxuanLbdm.AutoSize = True
        Me.LblYuxuanLbdm.Location = New System.Drawing.Point(8, 8)
        Me.LblYuxuanLbdm.Name = "LblYuxuanLbdm"
        Me.LblYuxuanLbdm.Size = New System.Drawing.Size(53, 12)
        Me.LblYuxuanLbdm.TabIndex = 21
        Me.LblYuxuanLbdm.Text = "预选角色"
        '
        'LblYixuanLbdm
        '
        Me.LblYixuanLbdm.AutoSize = True
        Me.LblYixuanLbdm.Location = New System.Drawing.Point(288, 8)
        Me.LblYixuanLbdm.Name = "LblYixuanLbdm"
        Me.LblYixuanLbdm.Size = New System.Drawing.Size(53, 12)
        Me.LblYixuanLbdm.TabIndex = 22
        Me.LblYixuanLbdm.Text = "已选角色"
        '
        'TabPageBmdm
        '
        Me.TabPageBmdm.Controls.Add(Me.ListBoxYuxuanBmdm)
        Me.TabPageBmdm.Controls.Add(Me.ListBoxYixuanBmdm)
        Me.TabPageBmdm.Controls.Add(Me.BtnSelectAllBmdm)
        Me.TabPageBmdm.Controls.Add(Me.BtnSelectOneBmdm)
        Me.TabPageBmdm.Controls.Add(Me.BtnUnSelectOneBmdm)
        Me.TabPageBmdm.Controls.Add(Me.BtnUnSelectAllBmdm)
        Me.TabPageBmdm.Controls.Add(Me.LblYuxuanBmdm)
        Me.TabPageBmdm.Controls.Add(Me.LblYixuanBmdm)
        Me.TabPageBmdm.Location = New System.Drawing.Point(4, 22)
        Me.TabPageBmdm.Name = "TabPageBmdm"
        Me.TabPageBmdm.Size = New System.Drawing.Size(480, 302)
        Me.TabPageBmdm.TabIndex = 2
        Me.TabPageBmdm.Text = "部门编码权限"
        Me.TabPageBmdm.UseVisualStyleBackColor = True
        '
        'ListBoxYuxuanBmdm
        '
        Me.ListBoxYuxuanBmdm.ItemHeight = 12
        Me.ListBoxYuxuanBmdm.Location = New System.Drawing.Point(8, 35)
        Me.ListBoxYuxuanBmdm.Name = "ListBoxYuxuanBmdm"
        Me.ListBoxYuxuanBmdm.Size = New System.Drawing.Size(184, 256)
        Me.ListBoxYuxuanBmdm.Sorted = True
        Me.ListBoxYuxuanBmdm.TabIndex = 31
        '
        'ListBoxYixuanBmdm
        '
        Me.ListBoxYixuanBmdm.ItemHeight = 12
        Me.ListBoxYixuanBmdm.Location = New System.Drawing.Point(288, 35)
        Me.ListBoxYixuanBmdm.Name = "ListBoxYixuanBmdm"
        Me.ListBoxYixuanBmdm.Size = New System.Drawing.Size(184, 256)
        Me.ListBoxYixuanBmdm.Sorted = True
        Me.ListBoxYixuanBmdm.TabIndex = 32
        '
        'BtnSelectAllBmdm
        '
        Me.BtnSelectAllBmdm.Location = New System.Drawing.Point(200, 43)
        Me.BtnSelectAllBmdm.Name = "BtnSelectAllBmdm"
        Me.BtnSelectAllBmdm.Size = New System.Drawing.Size(75, 23)
        Me.BtnSelectAllBmdm.TabIndex = 25
        Me.BtnSelectAllBmdm.Text = "-->>"
        '
        'BtnSelectOneBmdm
        '
        Me.BtnSelectOneBmdm.Location = New System.Drawing.Point(200, 83)
        Me.BtnSelectOneBmdm.Name = "BtnSelectOneBmdm"
        Me.BtnSelectOneBmdm.Size = New System.Drawing.Size(75, 23)
        Me.BtnSelectOneBmdm.TabIndex = 26
        Me.BtnSelectOneBmdm.Text = "-->"
        '
        'BtnUnSelectOneBmdm
        '
        Me.BtnUnSelectOneBmdm.Location = New System.Drawing.Point(200, 123)
        Me.BtnUnSelectOneBmdm.Name = "BtnUnSelectOneBmdm"
        Me.BtnUnSelectOneBmdm.Size = New System.Drawing.Size(75, 23)
        Me.BtnUnSelectOneBmdm.TabIndex = 27
        Me.BtnUnSelectOneBmdm.Text = "<--"
        '
        'BtnUnSelectAllBmdm
        '
        Me.BtnUnSelectAllBmdm.Location = New System.Drawing.Point(200, 163)
        Me.BtnUnSelectAllBmdm.Name = "BtnUnSelectAllBmdm"
        Me.BtnUnSelectAllBmdm.Size = New System.Drawing.Size(75, 23)
        Me.BtnUnSelectAllBmdm.TabIndex = 28
        Me.BtnUnSelectAllBmdm.Text = "<<--"
        '
        'LblYuxuanBmdm
        '
        Me.LblYuxuanBmdm.AutoSize = True
        Me.LblYuxuanBmdm.Location = New System.Drawing.Point(8, 11)
        Me.LblYuxuanBmdm.Name = "LblYuxuanBmdm"
        Me.LblYuxuanBmdm.Size = New System.Drawing.Size(53, 12)
        Me.LblYuxuanBmdm.TabIndex = 29
        Me.LblYuxuanBmdm.Text = "预选部门"
        '
        'LblYixuanBmdm
        '
        Me.LblYixuanBmdm.AutoSize = True
        Me.LblYixuanBmdm.Location = New System.Drawing.Point(288, 11)
        Me.LblYixuanBmdm.Name = "LblYixuanBmdm"
        Me.LblYixuanBmdm.Size = New System.Drawing.Size(53, 12)
        Me.LblYixuanBmdm.TabIndex = 30
        Me.LblYixuanBmdm.Text = "已选部门"
        '
        'TabPagePzlx
        '
        Me.TabPagePzlx.Controls.Add(Me.ListBoxYuxuanPzlx)
        Me.TabPagePzlx.Controls.Add(Me.ListBoxYixuanPzlx)
        Me.TabPagePzlx.Controls.Add(Me.BtnSelectAllPzlx)
        Me.TabPagePzlx.Controls.Add(Me.BtnSelectOnePzlx)
        Me.TabPagePzlx.Controls.Add(Me.BtnUnSelectOnePzlx)
        Me.TabPagePzlx.Controls.Add(Me.BtnUnSelectAllPzlx)
        Me.TabPagePzlx.Controls.Add(Me.LblYuxuanPzlx)
        Me.TabPagePzlx.Controls.Add(Me.LblYixuanPzlx)
        Me.TabPagePzlx.Location = New System.Drawing.Point(4, 22)
        Me.TabPagePzlx.Name = "TabPagePzlx"
        Me.TabPagePzlx.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPagePzlx.Size = New System.Drawing.Size(480, 302)
        Me.TabPagePzlx.TabIndex = 3
        Me.TabPagePzlx.Text = "单据类型权限"
        Me.TabPagePzlx.UseVisualStyleBackColor = True
        '
        'ListBoxYuxuanPzlx
        '
        Me.ListBoxYuxuanPzlx.ItemHeight = 12
        Me.ListBoxYuxuanPzlx.Location = New System.Drawing.Point(8, 35)
        Me.ListBoxYuxuanPzlx.Name = "ListBoxYuxuanPzlx"
        Me.ListBoxYuxuanPzlx.Size = New System.Drawing.Size(184, 256)
        Me.ListBoxYuxuanPzlx.Sorted = True
        Me.ListBoxYuxuanPzlx.TabIndex = 39
        '
        'ListBoxYixuanPzlx
        '
        Me.ListBoxYixuanPzlx.ItemHeight = 12
        Me.ListBoxYixuanPzlx.Location = New System.Drawing.Point(288, 35)
        Me.ListBoxYixuanPzlx.Name = "ListBoxYixuanPzlx"
        Me.ListBoxYixuanPzlx.Size = New System.Drawing.Size(184, 256)
        Me.ListBoxYixuanPzlx.Sorted = True
        Me.ListBoxYixuanPzlx.TabIndex = 40
        '
        'BtnSelectAllPzlx
        '
        Me.BtnSelectAllPzlx.Location = New System.Drawing.Point(200, 43)
        Me.BtnSelectAllPzlx.Name = "BtnSelectAllPzlx"
        Me.BtnSelectAllPzlx.Size = New System.Drawing.Size(75, 23)
        Me.BtnSelectAllPzlx.TabIndex = 33
        Me.BtnSelectAllPzlx.Text = "-->>"
        '
        'BtnSelectOnePzlx
        '
        Me.BtnSelectOnePzlx.Location = New System.Drawing.Point(200, 83)
        Me.BtnSelectOnePzlx.Name = "BtnSelectOnePzlx"
        Me.BtnSelectOnePzlx.Size = New System.Drawing.Size(75, 23)
        Me.BtnSelectOnePzlx.TabIndex = 34
        Me.BtnSelectOnePzlx.Text = "-->"
        '
        'BtnUnSelectOnePzlx
        '
        Me.BtnUnSelectOnePzlx.Location = New System.Drawing.Point(200, 123)
        Me.BtnUnSelectOnePzlx.Name = "BtnUnSelectOnePzlx"
        Me.BtnUnSelectOnePzlx.Size = New System.Drawing.Size(75, 23)
        Me.BtnUnSelectOnePzlx.TabIndex = 35
        Me.BtnUnSelectOnePzlx.Text = "<--"
        '
        'BtnUnSelectAllPzlx
        '
        Me.BtnUnSelectAllPzlx.Location = New System.Drawing.Point(200, 163)
        Me.BtnUnSelectAllPzlx.Name = "BtnUnSelectAllPzlx"
        Me.BtnUnSelectAllPzlx.Size = New System.Drawing.Size(75, 23)
        Me.BtnUnSelectAllPzlx.TabIndex = 36
        Me.BtnUnSelectAllPzlx.Text = "<<--"
        '
        'LblYuxuanPzlx
        '
        Me.LblYuxuanPzlx.AutoSize = True
        Me.LblYuxuanPzlx.Location = New System.Drawing.Point(8, 11)
        Me.LblYuxuanPzlx.Name = "LblYuxuanPzlx"
        Me.LblYuxuanPzlx.Size = New System.Drawing.Size(77, 12)
        Me.LblYuxuanPzlx.TabIndex = 37
        Me.LblYuxuanPzlx.Text = "预选单据类型"
        '
        'LblYixuanPzlx
        '
        Me.LblYixuanPzlx.AutoSize = True
        Me.LblYixuanPzlx.Location = New System.Drawing.Point(288, 11)
        Me.LblYixuanPzlx.Name = "LblYixuanPzlx"
        Me.LblYixuanPzlx.Size = New System.Drawing.Size(77, 12)
        Me.LblYixuanPzlx.TabIndex = 38
        Me.LblYixuanPzlx.Text = "已选单据类型"
        '
        'FrmUserQx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(508, 403)
        Me.Controls.Add(Me.rcTabControl)
        Me.Name = "FrmUserQx"
        Me.Text = "操作员权限设置"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.rcTabControl, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.rcTabControl.ResumeLayout(False)
        Me.TabPageDwdm.ResumeLayout(False)
        Me.TabPageDwdm.PerformLayout()
        Me.TabPageRole.ResumeLayout(False)
        Me.TabPageRole.PerformLayout()
        Me.TabPageLbdm.ResumeLayout(False)
        Me.TabPageLbdm.PerformLayout()
        Me.TabPageBmdm.ResumeLayout(False)
        Me.TabPageBmdm.PerformLayout()
        Me.TabPagePzlx.ResumeLayout(False)
        Me.TabPagePzlx.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rcTabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabPageDwdm As System.Windows.Forms.TabPage
    Friend WithEvents ListBoxYuxuanDwdm As System.Windows.Forms.ListBox
    Friend WithEvents ListBoxYixuanDwdm As System.Windows.Forms.ListBox
    Friend WithEvents BtnSelectAllDwdm As System.Windows.Forms.Button
    Friend WithEvents BtnSelectOneDwdm As System.Windows.Forms.Button
    Friend WithEvents BtnUnSelectOneDwdm As System.Windows.Forms.Button
    Friend WithEvents BtnUnSelectAllDwdm As System.Windows.Forms.Button
    Friend WithEvents LblYuxuanDwdm As System.Windows.Forms.Label
    Friend WithEvents LblYixuanDwdm As System.Windows.Forms.Label
    Friend WithEvents TabPageRole As System.Windows.Forms.TabPage
    Friend WithEvents ListBoxYuxuanRole As System.Windows.Forms.ListBox
    Friend WithEvents ListBoxYixuanRole As System.Windows.Forms.ListBox
    Friend WithEvents BtnSelectAllRole As System.Windows.Forms.Button
    Friend WithEvents BtnSelectOneRole As System.Windows.Forms.Button
    Friend WithEvents BtnUnSelectOneRole As System.Windows.Forms.Button
    Friend WithEvents BtnUnSelectAllRole As System.Windows.Forms.Button
    Friend WithEvents LblYuxuanRole As System.Windows.Forms.Label
    Friend WithEvents LblYixuanRole As System.Windows.Forms.Label
    Friend WithEvents TabPageLbdm As System.Windows.Forms.TabPage
    Friend WithEvents ListBoxYuxuanLbdm As System.Windows.Forms.ListBox
    Friend WithEvents ListBoxYixuanLbdm As System.Windows.Forms.ListBox
    Friend WithEvents BtnSelectAllLbdm As System.Windows.Forms.Button
    Friend WithEvents BtnSelectOneLbdm As System.Windows.Forms.Button
    Friend WithEvents BtnUnSelectOneLbdm As System.Windows.Forms.Button
    Friend WithEvents BtnUnSelectAllLbdm As System.Windows.Forms.Button
    Friend WithEvents LblYuxuanLbdm As System.Windows.Forms.Label
    Friend WithEvents LblYixuanLbdm As System.Windows.Forms.Label
    Friend WithEvents TabPageBmdm As System.Windows.Forms.TabPage
    Friend WithEvents ListBoxYuxuanBmdm As System.Windows.Forms.ListBox
    Friend WithEvents ListBoxYixuanBmdm As System.Windows.Forms.ListBox
    Friend WithEvents BtnSelectAllBmdm As System.Windows.Forms.Button
    Friend WithEvents BtnSelectOneBmdm As System.Windows.Forms.Button
    Friend WithEvents BtnUnSelectOneBmdm As System.Windows.Forms.Button
    Friend WithEvents BtnUnSelectAllBmdm As System.Windows.Forms.Button
    Friend WithEvents LblYuxuanBmdm As System.Windows.Forms.Label
    Friend WithEvents LblYixuanBmdm As System.Windows.Forms.Label
    Friend WithEvents TabPagePzlx As System.Windows.Forms.TabPage
    Friend WithEvents ListBoxYuxuanPzlx As System.Windows.Forms.ListBox
    Friend WithEvents ListBoxYixuanPzlx As System.Windows.Forms.ListBox
    Friend WithEvents BtnSelectAllPzlx As System.Windows.Forms.Button
    Friend WithEvents BtnSelectOnePzlx As System.Windows.Forms.Button
    Friend WithEvents BtnUnSelectOnePzlx As System.Windows.Forms.Button
    Friend WithEvents BtnUnSelectAllPzlx As System.Windows.Forms.Button
    Friend WithEvents LblYuxuanPzlx As System.Windows.Forms.Label
    Friend WithEvents LblYixuanPzlx As System.Windows.Forms.Label
End Class
