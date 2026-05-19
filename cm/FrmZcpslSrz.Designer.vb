<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmZcpslSrz
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
        Me.TxtCpdm = New System.Windows.Forms.TextBox()
        Me.LblCpdm = New System.Windows.Forms.Label()
        Me.TxtCpmc = New System.Windows.Forms.TextBox()
        Me.LblCpmc = New System.Windows.Forms.Label()
        Me.LblDw = New System.Windows.Forms.Label()
        Me.LblGxmc = New System.Windows.Forms.Label()
        Me.TxtGxmc = New System.Windows.Forms.TextBox()
        Me.LblGxdm = New System.Windows.Forms.Label()
        Me.TxtGxdm = New System.Windows.Forms.TextBox()
        Me.LblZcpsl = New System.Windows.Forms.Label()
        Me.TxtZcpsl = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtBmmc = New System.Windows.Forms.TextBox()
        Me.LblBmmc = New System.Windows.Forms.Label()
        Me.TxtBmdm = New System.Windows.Forms.TextBox()
        Me.LblBmdm = New System.Windows.Forms.Label()
        Me.BtnImpXls = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnOk = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MnuiFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiImpXls = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuiExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtCpdm
        '
        Me.TxtCpdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCpdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtCpdm.Location = New System.Drawing.Point(297, 93)
        Me.TxtCpdm.MaxLength = 12
        Me.TxtCpdm.Name = "TxtCpdm"
        Me.TxtCpdm.Size = New System.Drawing.Size(112, 26)
        Me.TxtCpdm.TabIndex = 5
        '
        'LblCpdm
        '
        Me.LblCpdm.AutoSize = True
        Me.LblCpdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblCpdm.Location = New System.Drawing.Point(201, 98)
        Me.LblCpdm.Name = "LblCpdm"
        Me.LblCpdm.Size = New System.Drawing.Size(88, 16)
        Me.LblCpdm.TabIndex = 4
        Me.LblCpdm.Text = "物料编码："
        '
        'TxtCpmc
        '
        Me.TxtCpmc.Enabled = False
        Me.TxtCpmc.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtCpmc.Location = New System.Drawing.Point(297, 127)
        Me.TxtCpmc.MaxLength = 100
        Me.TxtCpmc.Name = "TxtCpmc"
        Me.TxtCpmc.Size = New System.Drawing.Size(316, 26)
        Me.TxtCpmc.TabIndex = 7
        '
        'LblCpmc
        '
        Me.LblCpmc.AutoSize = True
        Me.LblCpmc.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblCpmc.Location = New System.Drawing.Point(201, 132)
        Me.LblCpmc.Name = "LblCpmc"
        Me.LblCpmc.Size = New System.Drawing.Size(88, 16)
        Me.LblCpmc.TabIndex = 6
        Me.LblCpmc.Text = "物料描述："
        '
        'LblDw
        '
        Me.LblDw.AutoSize = True
        Me.LblDw.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblDw.Location = New System.Drawing.Point(505, 234)
        Me.LblDw.Name = "LblDw"
        Me.LblDw.Size = New System.Drawing.Size(40, 16)
        Me.LblDw.TabIndex = 14
        Me.LblDw.Text = "单位"
        '
        'LblGxmc
        '
        Me.LblGxmc.AutoSize = True
        Me.LblGxmc.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblGxmc.Location = New System.Drawing.Point(201, 200)
        Me.LblGxmc.Name = "LblGxmc"
        Me.LblGxmc.Size = New System.Drawing.Size(88, 16)
        Me.LblGxmc.TabIndex = 10
        Me.LblGxmc.Text = "工序名称："
        '
        'TxtGxmc
        '
        Me.TxtGxmc.Enabled = False
        Me.TxtGxmc.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtGxmc.Location = New System.Drawing.Point(297, 195)
        Me.TxtGxmc.MaxLength = 40
        Me.TxtGxmc.Name = "TxtGxmc"
        Me.TxtGxmc.Size = New System.Drawing.Size(183, 26)
        Me.TxtGxmc.TabIndex = 11
        '
        'LblGxdm
        '
        Me.LblGxdm.AutoSize = True
        Me.LblGxdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblGxdm.Location = New System.Drawing.Point(201, 166)
        Me.LblGxdm.Name = "LblGxdm"
        Me.LblGxdm.Size = New System.Drawing.Size(88, 16)
        Me.LblGxdm.TabIndex = 8
        Me.LblGxdm.Text = "工序编码："
        '
        'TxtGxdm
        '
        Me.TxtGxdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtGxdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtGxdm.Location = New System.Drawing.Point(297, 161)
        Me.TxtGxdm.MaxLength = 12
        Me.TxtGxdm.Name = "TxtGxdm"
        Me.TxtGxdm.Size = New System.Drawing.Size(112, 26)
        Me.TxtGxdm.TabIndex = 9
        '
        'LblZcpsl
        '
        Me.LblZcpsl.AutoSize = True
        Me.LblZcpsl.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblZcpsl.Location = New System.Drawing.Point(201, 234)
        Me.LblZcpsl.Name = "LblZcpsl"
        Me.LblZcpsl.Size = New System.Drawing.Size(168, 16)
        Me.LblZcpsl.TabIndex = 12
        Me.LblZcpsl.Text = "期末在产品库存数量："
        '
        'TxtZcpsl
        '
        Me.TxtZcpsl.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtZcpsl.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtZcpsl.Location = New System.Drawing.Point(385, 229)
        Me.TxtZcpsl.MaxLength = 12
        Me.TxtZcpsl.Name = "TxtZcpsl"
        Me.TxtZcpsl.Size = New System.Drawing.Size(112, 26)
        Me.TxtZcpsl.TabIndex = 13
        Me.TxtZcpsl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TxtBmmc)
        Me.Panel1.Controls.Add(Me.LblBmmc)
        Me.Panel1.Controls.Add(Me.TxtBmdm)
        Me.Panel1.Controls.Add(Me.LblBmdm)
        Me.Panel1.Controls.Add(Me.BtnImpXls)
        Me.Panel1.Controls.Add(Me.BtnCancel)
        Me.Panel1.Controls.Add(Me.BtnOk)
        Me.Panel1.Controls.Add(Me.TxtCpdm)
        Me.Panel1.Controls.Add(Me.LblZcpsl)
        Me.Panel1.Controls.Add(Me.LblCpdm)
        Me.Panel1.Controls.Add(Me.TxtZcpsl)
        Me.Panel1.Controls.Add(Me.LblCpmc)
        Me.Panel1.Controls.Add(Me.LblGxmc)
        Me.Panel1.Controls.Add(Me.TxtCpmc)
        Me.Panel1.Controls.Add(Me.TxtGxmc)
        Me.Panel1.Controls.Add(Me.LblGxdm)
        Me.Panel1.Controls.Add(Me.LblDw)
        Me.Panel1.Controls.Add(Me.TxtGxdm)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(984, 336)
        Me.Panel1.TabIndex = 1
        '
        'TxtBmmc
        '
        Me.TxtBmmc.Enabled = False
        Me.TxtBmmc.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtBmmc.Location = New System.Drawing.Point(297, 59)
        Me.TxtBmmc.MaxLength = 40
        Me.TxtBmmc.Name = "TxtBmmc"
        Me.TxtBmmc.Size = New System.Drawing.Size(183, 26)
        Me.TxtBmmc.TabIndex = 3
        '
        'LblBmmc
        '
        Me.LblBmmc.AutoSize = True
        Me.LblBmmc.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblBmmc.Location = New System.Drawing.Point(185, 64)
        Me.LblBmmc.Name = "LblBmmc"
        Me.LblBmmc.Size = New System.Drawing.Size(88, 16)
        Me.LblBmmc.TabIndex = 2
        Me.LblBmmc.Text = "部门名称："
        '
        'TxtBmdm
        '
        Me.TxtBmdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtBmdm.Location = New System.Drawing.Point(297, 25)
        Me.TxtBmdm.MaxLength = 12
        Me.TxtBmdm.Name = "TxtBmdm"
        Me.TxtBmdm.Size = New System.Drawing.Size(104, 26)
        Me.TxtBmdm.TabIndex = 1
        '
        'LblBmdm
        '
        Me.LblBmdm.AutoSize = True
        Me.LblBmdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblBmdm.Location = New System.Drawing.Point(185, 30)
        Me.LblBmdm.Name = "LblBmdm"
        Me.LblBmdm.Size = New System.Drawing.Size(88, 16)
        Me.LblBmdm.TabIndex = 0
        Me.LblBmdm.Text = "部门编码："
        '
        'BtnImpXls
        '
        Me.BtnImpXls.Location = New System.Drawing.Point(540, 284)
        Me.BtnImpXls.Name = "BtnImpXls"
        Me.BtnImpXls.Size = New System.Drawing.Size(141, 23)
        Me.BtnImpXls.TabIndex = 17
        Me.BtnImpXls.Text = "导入EXCEL数据(&I)"
        Me.BtnImpXls.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(417, 284)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 16
        Me.BtnCancel.Text = "取消(&C)"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnOk
        '
        Me.BtnOk.Location = New System.Drawing.Point(294, 284)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(75, 23)
        Me.BtnOk.TabIndex = 15
        Me.BtnOk.Text = "确定(&O)"
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiFile, Me.MnuiHelp})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(984, 25)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MnuiFile
        '
        Me.MnuiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiSave, Me.MnuiImpXls, Me.ToolStripMenuItem1, Me.MnuiExit})
        Me.MnuiFile.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiFile.Name = "MnuiFile"
        Me.MnuiFile.Size = New System.Drawing.Size(58, 21)
        Me.MnuiFile.Text = "文件(&F)"
        '
        'MnuiSave
        '
        Me.MnuiSave.Name = "MnuiSave"
        Me.MnuiSave.Size = New System.Drawing.Size(189, 22)
        Me.MnuiSave.Text = "保存(&S)"
        '
        'MnuiImpXls
        '
        Me.MnuiImpXls.Name = "MnuiImpXls"
        Me.MnuiImpXls.Size = New System.Drawing.Size(189, 22)
        Me.MnuiImpXls.Text = "导入Excel模板数据(&I)"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(186, 6)
        '
        'MnuiExit
        '
        Me.MnuiExit.Name = "MnuiExit"
        Me.MnuiExit.Size = New System.Drawing.Size(189, 22)
        Me.MnuiExit.Text = "退出(&X)"
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
        'FrmZcpslSrz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmZcpslSrz"
        Me.Text = "期末在产品数量录入"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtCpdm As System.Windows.Forms.TextBox
    Friend WithEvents LblCpdm As System.Windows.Forms.Label
    Friend WithEvents TxtCpmc As System.Windows.Forms.TextBox
    Friend WithEvents LblCpmc As System.Windows.Forms.Label
    Friend WithEvents LblDw As System.Windows.Forms.Label
    Friend WithEvents LblGxmc As System.Windows.Forms.Label
    Friend WithEvents TxtGxmc As System.Windows.Forms.TextBox
    Friend WithEvents LblGxdm As System.Windows.Forms.Label
    Friend WithEvents TxtGxdm As System.Windows.Forms.TextBox
    Friend WithEvents LblZcpsl As System.Windows.Forms.Label
    Friend WithEvents TxtZcpsl As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnImpXls As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuiFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiImpXls As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuiExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LblBmmc As System.Windows.Forms.Label
    Friend WithEvents TxtBmdm As System.Windows.Forms.TextBox
    Friend WithEvents LblBmdm As System.Windows.Forms.Label
    Friend WithEvents TxtBmmc As System.Windows.Forms.TextBox
End Class
