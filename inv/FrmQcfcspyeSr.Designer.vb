<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmQcfcspyeSr
    Inherits models.FrmDlgPortrait

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TxtQcje = New System.Windows.Forms.TextBox()
        Me.LblQcje = New System.Windows.Forms.Label()
        Me.LblDw = New System.Windows.Forms.Label()
        Me.LblCpmc = New System.Windows.Forms.Label()
        Me.TxtQcsl = New System.Windows.Forms.TextBox()
        Me.LblQcsl = New System.Windows.Forms.Label()
        Me.TxtCpdm = New System.Windows.Forms.TextBox()
        Me.LblCpdm = New System.Windows.Forms.Label()
        Me.LblBmmc = New System.Windows.Forms.Label()
        Me.TxtBmdm = New System.Windows.Forms.TextBox()
        Me.LblBmdm = New System.Windows.Forms.Label()
        Me.TxtQcFzsl = New System.Windows.Forms.TextBox()
        Me.LblQcFzsl = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MnuiFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiImpXls = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuiExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuiAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.LblKhmc = New System.Windows.Forms.Label()
        Me.TxtKhdm = New System.Windows.Forms.TextBox()
        Me.LblKhdm = New System.Windows.Forms.Label()
        Me.DlgPanel.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(124, 4)
        Me.BtnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnCancel.Size = New System.Drawing.Size(111, 34)
        Me.BtnCancel.TabIndex = 1
        '
        'BtnHelp
        '
        Me.BtnHelp.Location = New System.Drawing.Point(244, 4)
        Me.BtnHelp.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnHelp.Size = New System.Drawing.Size(112, 34)
        Me.BtnHelp.TabIndex = 2
        '
        'BtnOk
        '
        Me.BtnOk.Location = New System.Drawing.Point(4, 4)
        Me.BtnOk.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnOk.Size = New System.Drawing.Size(111, 34)
        Me.BtnOk.TabIndex = 0
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(129, 432)
        Me.DlgPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.DlgPanel.Size = New System.Drawing.Size(363, 46)
        Me.DlgPanel.TabIndex = 17
        '
        'TxtQcje
        '
        Me.TxtQcje.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtQcje.Location = New System.Drawing.Point(225, 349)
        Me.TxtQcje.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtQcje.MaxLength = 12
        Me.TxtQcje.Name = "TxtQcje"
        Me.TxtQcje.Size = New System.Drawing.Size(154, 28)
        Me.TxtQcje.TabIndex = 17
        '
        'LblQcje
        '
        Me.LblQcje.AutoSize = True
        Me.LblQcje.Location = New System.Drawing.Point(45, 355)
        Me.LblQcje.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblQcje.Name = "LblQcje"
        Me.LblQcje.Size = New System.Drawing.Size(170, 18)
        Me.LblQcje.TabIndex = 16
        Me.LblQcje.Text = "期初发出商品金额："
        '
        'LblDw
        '
        Me.LblDw.AutoSize = True
        Me.LblDw.Location = New System.Drawing.Point(117, 146)
        Me.LblDw.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDw.Name = "LblDw"
        Me.LblDw.Size = New System.Drawing.Size(98, 18)
        Me.LblDw.TabIndex = 5
        Me.LblDw.Text = "单    位："
        '
        'LblCpmc
        '
        Me.LblCpmc.AutoSize = True
        Me.LblCpmc.Location = New System.Drawing.Point(117, 110)
        Me.LblCpmc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCpmc.Name = "LblCpmc"
        Me.LblCpmc.Size = New System.Drawing.Size(98, 18)
        Me.LblCpmc.TabIndex = 2
        Me.LblCpmc.Text = "物料描述："
        '
        'TxtQcsl
        '
        Me.TxtQcsl.Location = New System.Drawing.Point(225, 265)
        Me.TxtQcsl.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtQcsl.MaxLength = 16
        Me.TxtQcsl.Name = "TxtQcsl"
        Me.TxtQcsl.Size = New System.Drawing.Size(154, 28)
        Me.TxtQcsl.TabIndex = 13
        '
        'LblQcsl
        '
        Me.LblQcsl.AutoSize = True
        Me.LblQcsl.Location = New System.Drawing.Point(45, 271)
        Me.LblQcsl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblQcsl.Name = "LblQcsl"
        Me.LblQcsl.Size = New System.Drawing.Size(170, 18)
        Me.LblQcsl.TabIndex = 12
        Me.LblQcsl.Text = "期初发出商品数量："
        '
        'TxtCpdm
        '
        Me.TxtCpdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCpdm.Location = New System.Drawing.Point(225, 62)
        Me.TxtCpdm.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCpdm.MaxLength = 15
        Me.TxtCpdm.Name = "TxtCpdm"
        Me.TxtCpdm.Size = New System.Drawing.Size(154, 28)
        Me.TxtCpdm.TabIndex = 1
        '
        'LblCpdm
        '
        Me.LblCpdm.AutoSize = True
        Me.LblCpdm.Location = New System.Drawing.Point(117, 68)
        Me.LblCpdm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCpdm.Name = "LblCpdm"
        Me.LblCpdm.Size = New System.Drawing.Size(98, 18)
        Me.LblCpdm.TabIndex = 0
        Me.LblCpdm.Text = "物料编码："
        '
        'LblBmmc
        '
        Me.LblBmmc.AutoSize = True
        Me.LblBmmc.Location = New System.Drawing.Point(387, 235)
        Me.LblBmmc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBmmc.Name = "LblBmmc"
        Me.LblBmmc.Size = New System.Drawing.Size(0, 18)
        Me.LblBmmc.TabIndex = 11
        '
        'TxtBmdm
        '
        Me.TxtBmdm.Location = New System.Drawing.Point(225, 229)
        Me.TxtBmdm.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtBmdm.MaxLength = 30
        Me.TxtBmdm.Name = "TxtBmdm"
        Me.TxtBmdm.Size = New System.Drawing.Size(154, 28)
        Me.TxtBmdm.TabIndex = 10
        '
        'LblBmdm
        '
        Me.LblBmdm.AutoSize = True
        Me.LblBmdm.Location = New System.Drawing.Point(117, 235)
        Me.LblBmdm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBmdm.Name = "LblBmdm"
        Me.LblBmdm.Size = New System.Drawing.Size(98, 18)
        Me.LblBmdm.TabIndex = 9
        Me.LblBmdm.Text = "部门编码："
        '
        'TxtQcFzsl
        '
        Me.TxtQcFzsl.Location = New System.Drawing.Point(225, 307)
        Me.TxtQcFzsl.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtQcFzsl.MaxLength = 16
        Me.TxtQcFzsl.Name = "TxtQcFzsl"
        Me.TxtQcFzsl.Size = New System.Drawing.Size(154, 28)
        Me.TxtQcFzsl.TabIndex = 15
        '
        'LblQcFzsl
        '
        Me.LblQcFzsl.AutoSize = True
        Me.LblQcFzsl.Location = New System.Drawing.Point(27, 313)
        Me.LblQcFzsl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblQcFzsl.Name = "LblQcFzsl"
        Me.LblQcFzsl.Size = New System.Drawing.Size(188, 18)
        Me.LblQcFzsl.TabIndex = 14
        Me.LblQcFzsl.Text = "期初发出商品辅数量："
        '
        'MenuStrip1
        '
        Me.MenuStrip1.GripMargin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiFile, Me.MnuiHelp})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(508, 32)
        Me.MenuStrip1.TabIndex = 16
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MnuiFile
        '
        Me.MnuiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiSave, Me.MnuiImpXls, Me.ToolStripMenuItem1, Me.MnuiExit})
        Me.MnuiFile.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiFile.Name = "MnuiFile"
        Me.MnuiFile.Size = New System.Drawing.Size(84, 28)
        Me.MnuiFile.Text = "文件(&F)"
        '
        'MnuiSave
        '
        Me.MnuiSave.Name = "MnuiSave"
        Me.MnuiSave.Size = New System.Drawing.Size(278, 34)
        Me.MnuiSave.Text = "保存(&S)"
        '
        'MnuiImpXls
        '
        Me.MnuiImpXls.Name = "MnuiImpXls"
        Me.MnuiImpXls.Size = New System.Drawing.Size(278, 34)
        Me.MnuiImpXls.Text = "导入Excel模板数据(&I)"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(275, 6)
        '
        'MnuiExit
        '
        Me.MnuiExit.Name = "MnuiExit"
        Me.MnuiExit.Size = New System.Drawing.Size(278, 34)
        Me.MnuiExit.Text = "退出(&X)"
        '
        'MnuiHelp
        '
        Me.MnuiHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiAbout})
        Me.MnuiHelp.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.MnuiHelp.Name = "MnuiHelp"
        Me.MnuiHelp.Size = New System.Drawing.Size(88, 28)
        Me.MnuiHelp.Text = "帮助(&H)"
        '
        'MnuiAbout
        '
        Me.MnuiAbout.Name = "MnuiAbout"
        Me.MnuiAbout.Size = New System.Drawing.Size(171, 34)
        Me.MnuiAbout.Text = "关于(&A)"
        '
        'LblKhmc
        '
        Me.LblKhmc.AutoSize = True
        Me.LblKhmc.Location = New System.Drawing.Point(387, 199)
        Me.LblKhmc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblKhmc.Name = "LblKhmc"
        Me.LblKhmc.Size = New System.Drawing.Size(0, 18)
        Me.LblKhmc.TabIndex = 8
        '
        'TxtKhdm
        '
        Me.TxtKhdm.Location = New System.Drawing.Point(225, 193)
        Me.TxtKhdm.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtKhdm.MaxLength = 30
        Me.TxtKhdm.Name = "TxtKhdm"
        Me.TxtKhdm.Size = New System.Drawing.Size(154, 28)
        Me.TxtKhdm.TabIndex = 7
        '
        'LblKhdm
        '
        Me.LblKhdm.AutoSize = True
        Me.LblKhdm.Location = New System.Drawing.Point(117, 199)
        Me.LblKhdm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblKhdm.Name = "LblKhdm"
        Me.LblKhdm.Size = New System.Drawing.Size(98, 18)
        Me.LblKhdm.TabIndex = 6
        Me.LblKhdm.Text = "客户编码："
        '
        'FrmQcfcspyeSr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(508, 497)
        Me.Controls.Add(Me.LblKhmc)
        Me.Controls.Add(Me.TxtKhdm)
        Me.Controls.Add(Me.LblKhdm)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TxtQcFzsl)
        Me.Controls.Add(Me.LblQcFzsl)
        Me.Controls.Add(Me.LblBmmc)
        Me.Controls.Add(Me.TxtBmdm)
        Me.Controls.Add(Me.LblBmdm)
        Me.Controls.Add(Me.TxtQcje)
        Me.Controls.Add(Me.LblQcje)
        Me.Controls.Add(Me.LblDw)
        Me.Controls.Add(Me.LblCpmc)
        Me.Controls.Add(Me.TxtQcsl)
        Me.Controls.Add(Me.LblQcsl)
        Me.Controls.Add(Me.TxtCpdm)
        Me.Controls.Add(Me.LblCpdm)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmQcfcspyeSr"
        Me.Text = "期初发出商品余额装入"
        Me.Controls.SetChildIndex(Me.LblCpdm, 0)
        Me.Controls.SetChildIndex(Me.TxtCpdm, 0)
        Me.Controls.SetChildIndex(Me.LblQcsl, 0)
        Me.Controls.SetChildIndex(Me.TxtQcsl, 0)
        Me.Controls.SetChildIndex(Me.LblCpmc, 0)
        Me.Controls.SetChildIndex(Me.LblDw, 0)
        Me.Controls.SetChildIndex(Me.LblQcje, 0)
        Me.Controls.SetChildIndex(Me.TxtQcje, 0)
        Me.Controls.SetChildIndex(Me.LblBmdm, 0)
        Me.Controls.SetChildIndex(Me.TxtBmdm, 0)
        Me.Controls.SetChildIndex(Me.LblBmmc, 0)
        Me.Controls.SetChildIndex(Me.LblQcFzsl, 0)
        Me.Controls.SetChildIndex(Me.TxtQcFzsl, 0)
        Me.Controls.SetChildIndex(Me.MenuStrip1, 0)
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.LblKhdm, 0)
        Me.Controls.SetChildIndex(Me.TxtKhdm, 0)
        Me.Controls.SetChildIndex(Me.LblKhmc, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents TxtQcje As System.Windows.Forms.TextBox
    Public WithEvents LblQcje As System.Windows.Forms.Label
    Public WithEvents LblDw As System.Windows.Forms.Label
    Public WithEvents LblCpmc As System.Windows.Forms.Label
    Public WithEvents TxtQcsl As System.Windows.Forms.TextBox
    Public WithEvents LblQcsl As System.Windows.Forms.Label
    Public WithEvents TxtCpdm As System.Windows.Forms.TextBox
    Public WithEvents LblCpdm As System.Windows.Forms.Label
    Public WithEvents LblBmmc As System.Windows.Forms.Label
    Public WithEvents TxtBmdm As System.Windows.Forms.TextBox
    Public WithEvents LblBmdm As System.Windows.Forms.Label
    Public WithEvents TxtQcFzsl As System.Windows.Forms.TextBox
    Public WithEvents LblQcFzsl As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuiFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiImpXls As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuiExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuiAbout As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents LblKhmc As Label
    Public WithEvents TxtKhdm As TextBox
    Public WithEvents LblKhdm As Label
End Class
