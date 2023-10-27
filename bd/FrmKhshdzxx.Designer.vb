<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmKhshdzxx
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmKhshdzxx))
        Me.ToolStripPanelMain = New System.Windows.Forms.ToolStripPanel
        Me.MenuStripMain = New System.Windows.Forms.MenuStrip
        Me.MnuiFile = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiPageSetup = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiPrint = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiPreview = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiExport = New System.Windows.Forms.ToolStripMenuItem
        Me.Tss3 = New System.Windows.Forms.ToolStripSeparator
        Me.MnuiNew = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiRefresh = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiSearch = New System.Windows.Forms.ToolStripMenuItem
        Me.Tss4 = New System.Windows.Forms.ToolStripSeparator
        Me.MnuiExit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiHelp = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip
        Me.BtnPageSetup = New System.Windows.Forms.ToolStripButton
        Me.BtnPrint = New System.Windows.Forms.ToolStripButton
        Me.BtnPreview = New System.Windows.Forms.ToolStripButton
        Me.BtnExport = New System.Windows.Forms.ToolStripButton
        Me.Tss1 = New System.Windows.Forms.ToolStripSeparator
        Me.BtnNew = New System.Windows.Forms.ToolStripButton
        Me.BtnEdit = New System.Windows.Forms.ToolStripButton
        Me.BtnDelete = New System.Windows.Forms.ToolStripButton
        Me.BtnRefresh = New System.Windows.Forms.ToolStripButton
        Me.BtnSearch = New System.Windows.Forms.ToolStripButton
        Me.Tss2 = New System.Windows.Forms.ToolStripSeparator
        Me.BtnExit = New System.Windows.Forms.ToolStripButton
        Me.rcDataGrid = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DgtbcKhdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcKhmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcZydm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcZymc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcAddress = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcPostCode = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcTel = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcMobile = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcLxr = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgbcLastTimebz = New System.Windows.Forms.DataGridBoolColumn
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToolStripPanelMain.SuspendLayout()
        Me.MenuStripMain.SuspendLayout()
        Me.ToolStripMain.SuspendLayout()
        CType(Me.rcDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripPanelMain
        '
        Me.ToolStripPanelMain.Controls.Add(Me.ToolStripMain)
        Me.ToolStripPanelMain.Controls.Add(Me.MenuStripMain)
        Me.ToolStripPanelMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.ToolStripPanelMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripPanelMain.Name = "ToolStripPanelMain"
        Me.ToolStripPanelMain.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.ToolStripPanelMain.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ToolStripPanelMain.Size = New System.Drawing.Size(786, 64)
        '
        'MenuStripMain
        '
        Me.MenuStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiFile, Me.MnuiHelp})
        Me.MenuStripMain.Location = New System.Drawing.Point(0, 0)
        Me.MenuStripMain.Name = "MenuStripMain"
        Me.MenuStripMain.Size = New System.Drawing.Size(786, 25)
        Me.MenuStripMain.TabIndex = 2
        Me.MenuStripMain.Text = "MenuStripMain"
        '
        'MnuiFile
        '
        Me.MnuiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiPageSetup, Me.MnuiPrint, Me.MnuiPreview, Me.MnuiExport, Me.Tss3, Me.MnuiNew, Me.MnuiEdit, Me.MnuiDelete, Me.MnuiRefresh, Me.MnuiSearch, Me.Tss4, Me.MnuiExit})
        Me.MnuiFile.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiFile.Name = "MnuiFile"
        Me.MnuiFile.Size = New System.Drawing.Size(58, 21)
        Me.MnuiFile.Text = "文件(&F)"
        '
        'MnuiPageSetup
        '
        Me.MnuiPageSetup.Name = "MnuiPageSetup"
        Me.MnuiPageSetup.Size = New System.Drawing.Size(124, 22)
        Me.MnuiPageSetup.Text = "页面设置"
        '
        'MnuiPrint
        '
        Me.MnuiPrint.Name = "MnuiPrint"
        Me.MnuiPrint.Size = New System.Drawing.Size(124, 22)
        Me.MnuiPrint.Text = "打印"
        '
        'MnuiPreview
        '
        Me.MnuiPreview.Name = "MnuiPreview"
        Me.MnuiPreview.Size = New System.Drawing.Size(124, 22)
        Me.MnuiPreview.Text = "打印预览"
        '
        'MnuiExport
        '
        Me.MnuiExport.Name = "MnuiExport"
        Me.MnuiExport.Size = New System.Drawing.Size(124, 22)
        Me.MnuiExport.Text = "输出"
        '
        'Tss3
        '
        Me.Tss3.Name = "Tss3"
        Me.Tss3.Size = New System.Drawing.Size(121, 6)
        '
        'MnuiNew
        '
        Me.MnuiNew.Name = "MnuiNew"
        Me.MnuiNew.Size = New System.Drawing.Size(124, 22)
        Me.MnuiNew.Text = "新增"
        '
        'MnuiEdit
        '
        Me.MnuiEdit.Name = "MnuiEdit"
        Me.MnuiEdit.Size = New System.Drawing.Size(124, 22)
        Me.MnuiEdit.Text = "修改"
        '
        'MnuiDelete
        '
        Me.MnuiDelete.Name = "MnuiDelete"
        Me.MnuiDelete.Size = New System.Drawing.Size(124, 22)
        Me.MnuiDelete.Text = "删除"
        '
        'MnuiRefresh
        '
        Me.MnuiRefresh.Name = "MnuiRefresh"
        Me.MnuiRefresh.Size = New System.Drawing.Size(124, 22)
        Me.MnuiRefresh.Text = "刷新"
        '
        'MnuiSearch
        '
        Me.MnuiSearch.Name = "MnuiSearch"
        Me.MnuiSearch.Size = New System.Drawing.Size(124, 22)
        Me.MnuiSearch.Text = "查找"
        '
        'Tss4
        '
        Me.Tss4.Name = "Tss4"
        Me.Tss4.Size = New System.Drawing.Size(121, 6)
        '
        'MnuiExit
        '
        Me.MnuiExit.Name = "MnuiExit"
        Me.MnuiExit.Size = New System.Drawing.Size(124, 22)
        Me.MnuiExit.Text = "关闭(&C)"
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
        'ToolStripMain
        '
        Me.ToolStripMain.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnPageSetup, Me.BtnPrint, Me.BtnPreview, Me.BtnExport, Me.Tss1, Me.BtnNew, Me.BtnEdit, Me.BtnDelete, Me.BtnRefresh, Me.BtnSearch, Me.Tss2, Me.BtnExit})
        Me.ToolStripMain.Location = New System.Drawing.Point(3, 25)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(512, 39)
        Me.ToolStripMain.TabIndex = 1
        '
        'BtnPageSetup
        '
        Me.BtnPageSetup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPageSetup.Image = Global.rc3.My.Resources.Resources.ImgPageSetup
        Me.BtnPageSetup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPageSetup.Name = "BtnPageSetup"
        Me.BtnPageSetup.Size = New System.Drawing.Size(36, 36)
        Me.BtnPageSetup.Text = "页面设置"
        '
        'BtnPrint
        '
        Me.BtnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrint.Image = Global.rc3.My.Resources.Resources.ImgPrint
        Me.BtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(36, 36)
        Me.BtnPrint.Text = "打印"
        '
        'BtnPreview
        '
        Me.BtnPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPreview.Image = Global.rc3.My.Resources.Resources.ImgPreview
        Me.BtnPreview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPreview.Name = "BtnPreview"
        Me.BtnPreview.Size = New System.Drawing.Size(36, 36)
        Me.BtnPreview.Text = "预览"
        '
        'BtnExport
        '
        Me.BtnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnExport.Image = Global.rc3.My.Resources.Resources.ImgExport
        Me.BtnExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnExport.Name = "BtnExport"
        Me.BtnExport.Size = New System.Drawing.Size(36, 36)
        Me.BtnExport.Text = "输出"
        '
        'Tss1
        '
        Me.Tss1.Name = "Tss1"
        Me.Tss1.Size = New System.Drawing.Size(6, 39)
        '
        'BtnNew
        '
        Me.BtnNew.Image = Global.rc3.My.Resources.Resources.ImgNew
        Me.BtnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(68, 36)
        Me.BtnNew.Text = "新增"
        '
        'BtnEdit
        '
        Me.BtnEdit.Image = Global.rc3.My.Resources.Resources.ImgEdit
        Me.BtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(68, 36)
        Me.BtnEdit.Text = "修改"
        '
        'BtnDelete
        '
        Me.BtnDelete.Image = Global.rc3.My.Resources.Resources.ImgDelete
        Me.BtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(68, 36)
        Me.BtnDelete.Text = "删除"
        '
        'BtnRefresh
        '
        Me.BtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnRefresh.Image = Global.rc3.My.Resources.Resources.ImgRefresh
        Me.BtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(36, 36)
        Me.BtnRefresh.Text = "刷新"
        '
        'BtnSearch
        '
        Me.BtnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnSearch.Image = Global.rc3.My.Resources.Resources.ImgSearch
        Me.BtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(36, 36)
        Me.BtnSearch.Text = "查找"
        '
        'Tss2
        '
        Me.Tss2.Name = "Tss2"
        Me.Tss2.Size = New System.Drawing.Size(6, 39)
        '
        'BtnExit
        '
        Me.BtnExit.Image = Global.rc3.My.Resources.Resources.ImgExit
        Me.BtnExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(68, 36)
        Me.BtnExit.Text = "关闭"
        '
        'rcDataGrid
        '
        Me.rcDataGrid.CaptionVisible = False
        Me.rcDataGrid.DataMember = ""
        Me.rcDataGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rcDataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.rcDataGrid.Location = New System.Drawing.Point(0, 112)
        Me.rcDataGrid.Name = "rcDataGrid"
        Me.rcDataGrid.ReadOnly = True
        Me.rcDataGrid.Size = New System.Drawing.Size(682, 385)
        Me.rcDataGrid.TabIndex = 4
        Me.rcDataGrid.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.rcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcKhdm, Me.DgtbcKhmc, Me.DgtbcZydm, Me.DgtbcZymc, Me.DgtbcAddress, Me.DgtbcPostCode, Me.DgtbcTel, Me.DgtbcMobile, Me.DgtbcLxr, Me.DgbcLastTimebz})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "oe_khshdz"
        '
        'DgtbcKhdm
        '
        Me.DgtbcKhdm.Format = ""
        Me.DgtbcKhdm.FormatInfo = Nothing
        Me.DgtbcKhdm.HeaderText = "客户编码"
        Me.DgtbcKhdm.MappingName = "khdm"
        Me.DgtbcKhdm.NullText = ""
        Me.DgtbcKhdm.Width = 75
        '
        'DgtbcKhmc
        '
        Me.DgtbcKhmc.Format = ""
        Me.DgtbcKhmc.FormatInfo = Nothing
        Me.DgtbcKhmc.HeaderText = "客户名称"
        Me.DgtbcKhmc.MappingName = "khmc"
        Me.DgtbcKhmc.NullText = ""
        Me.DgtbcKhmc.Width = 180
        '
        'DgtbcZydm
        '
        Me.DgtbcZydm.Format = ""
        Me.DgtbcZydm.FormatInfo = Nothing
        Me.DgtbcZydm.HeaderText = "职员编码"
        Me.DgtbcZydm.MappingName = "zydm"
        Me.DgtbcZydm.NullText = ""
        Me.DgtbcZydm.Width = 45
        '
        'DgtbcZymc
        '
        Me.DgtbcZymc.Format = ""
        Me.DgtbcZymc.FormatInfo = Nothing
        Me.DgtbcZymc.HeaderText = "职员姓名"
        Me.DgtbcZymc.MappingName = "zymc"
        Me.DgtbcZymc.NullText = ""
        Me.DgtbcZymc.Width = 75
        '
        'DgtbcAddress
        '
        Me.DgtbcAddress.Format = ""
        Me.DgtbcAddress.FormatInfo = Nothing
        Me.DgtbcAddress.HeaderText = "收货地址"
        Me.DgtbcAddress.MappingName = "address"
        Me.DgtbcAddress.NullText = ""
        Me.DgtbcAddress.Width = 150
        '
        'DgtbcPostCode
        '
        Me.DgtbcPostCode.Format = ""
        Me.DgtbcPostCode.FormatInfo = Nothing
        Me.DgtbcPostCode.HeaderText = "邮政编码"
        Me.DgtbcPostCode.MappingName = "postcode"
        Me.DgtbcPostCode.NullText = ""
        Me.DgtbcPostCode.Width = 75
        '
        'DgtbcTel
        '
        Me.DgtbcTel.Format = ""
        Me.DgtbcTel.FormatInfo = Nothing
        Me.DgtbcTel.HeaderText = "电话"
        Me.DgtbcTel.MappingName = "tel"
        Me.DgtbcTel.NullText = ""
        Me.DgtbcTel.Width = 75
        '
        'DgtbcMobile
        '
        Me.DgtbcMobile.Format = ""
        Me.DgtbcMobile.FormatInfo = Nothing
        Me.DgtbcMobile.HeaderText = "手机"
        Me.DgtbcMobile.MappingName = "mobile"
        Me.DgtbcMobile.NullText = ""
        Me.DgtbcMobile.Width = 75
        '
        'DgtbcLxr
        '
        Me.DgtbcLxr.Format = ""
        Me.DgtbcLxr.FormatInfo = Nothing
        Me.DgtbcLxr.HeaderText = "联系人"
        Me.DgtbcLxr.MappingName = "lxr"
        Me.DgtbcLxr.NullText = ""
        Me.DgtbcLxr.Width = 75
        '
        'DgbcLastTimebz
        '
        Me.DgbcLastTimebz.HeaderText = "上次送货标志"
        Me.DgbcLastTimebz.MappingName = "lasttimebz"
        Me.DgbcLastTimebz.NullText = ""
        Me.DgbcLastTimebz.Width = 75
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FloralWhite
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(682, 112)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(104, 385)
        Me.Panel3.TabIndex = 5
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(16, 48)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(80, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FloralWhite
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 64)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(786, 48)
        Me.Panel1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("楷体", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label1.Location = New System.Drawing.Point(305, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(177, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "客户收货地址管理"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmKhshdzxx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.rcDataGrid)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStripPanelMain)
        Me.MainMenuStrip = Me.MenuStripMain
        Me.Name = "FrmKhshdzxx"
        Me.Text = "客户收货地址管理"
        Me.ToolStripPanelMain.ResumeLayout(False)
        Me.ToolStripPanelMain.PerformLayout()
        Me.MenuStripMain.ResumeLayout(False)
        Me.MenuStripMain.PerformLayout()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        CType(Me.rcDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripPanelMain As System.Windows.Forms.ToolStripPanel
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnPreview As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tss1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tss2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnPageSetup As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents rcDataGrid As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DgtbcKhdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcKhmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcAddress As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcPostCode As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcMobile As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcTel As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DgtbcLxr As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgbcLastTimebz As System.Windows.Forms.DataGridBoolColumn
    Friend WithEvents MenuStripMain As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuiFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiPageSetup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiPreview As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tss3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuiNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tss4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuiExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DgtbcZydm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZymc As System.Windows.Forms.DataGridTextBoxColumn
End Class
