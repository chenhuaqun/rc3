<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmQccpyeSr
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
        Me.TxtQcje = New System.Windows.Forms.TextBox
        Me.LblQcje = New System.Windows.Forms.Label
        Me.LblDw = New System.Windows.Forms.Label
        Me.LblCpmc = New System.Windows.Forms.Label
        Me.TxtQcsl = New System.Windows.Forms.TextBox
        Me.LblQcsl = New System.Windows.Forms.Label
        Me.TxtCpdm = New System.Windows.Forms.TextBox
        Me.LblCpdm = New System.Windows.Forms.Label
        Me.LblCkmc = New System.Windows.Forms.Label
        Me.TxtCkdm = New System.Windows.Forms.TextBox
        Me.LblCkdm = New System.Windows.Forms.Label
        Me.TxtQcFzsl = New System.Windows.Forms.TextBox
        Me.LblQcFzsl = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.MnuiFile = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiSave = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiImpXls = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.MnuiExit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiHelp = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuiAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.DlgPanel.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnCancel
        '
        Me.BtnCancel.TabIndex = 1
        '
        'BtnHelp
        '
        Me.BtnHelp.TabIndex = 2
        '
        'BtnOk
        '
        Me.BtnOk.TabIndex = 0
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(86, 255)
        Me.DlgPanel.TabIndex = 15
        '
        'TxtQcje
        '
        Me.TxtQcje.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtQcje.Location = New System.Drawing.Point(150, 205)
        Me.TxtQcje.MaxLength = 12
        Me.TxtQcje.Name = "TxtQcje"
        Me.TxtQcje.Size = New System.Drawing.Size(104, 21)
        Me.TxtQcje.TabIndex = 14
        '
        'LblQcje
        '
        Me.LblQcje.AutoSize = True
        Me.LblQcje.Location = New System.Drawing.Point(54, 209)
        Me.LblQcje.Name = "LblQcje"
        Me.LblQcje.Size = New System.Drawing.Size(89, 12)
        Me.LblQcje.TabIndex = 13
        Me.LblQcje.Text = "期初库存金额："
        '
        'LblDw
        '
        Me.LblDw.AutoSize = True
        Me.LblDw.Location = New System.Drawing.Point(78, 97)
        Me.LblDw.Name = "LblDw"
        Me.LblDw.Size = New System.Drawing.Size(65, 12)
        Me.LblDw.TabIndex = 5
        Me.LblDw.Text = "单    位："
        '
        'LblCpmc
        '
        Me.LblCpmc.AutoSize = True
        Me.LblCpmc.Location = New System.Drawing.Point(78, 73)
        Me.LblCpmc.Name = "LblCpmc"
        Me.LblCpmc.Size = New System.Drawing.Size(65, 12)
        Me.LblCpmc.TabIndex = 2
        Me.LblCpmc.Text = "物料描述："
        '
        'TxtQcsl
        '
        Me.TxtQcsl.Location = New System.Drawing.Point(150, 149)
        Me.TxtQcsl.MaxLength = 16
        Me.TxtQcsl.Name = "TxtQcsl"
        Me.TxtQcsl.Size = New System.Drawing.Size(104, 21)
        Me.TxtQcsl.TabIndex = 10
        '
        'LblQcsl
        '
        Me.LblQcsl.AutoSize = True
        Me.LblQcsl.Location = New System.Drawing.Point(54, 153)
        Me.LblQcsl.Name = "LblQcsl"
        Me.LblQcsl.Size = New System.Drawing.Size(89, 12)
        Me.LblQcsl.TabIndex = 9
        Me.LblQcsl.Text = "期初库存数量："
        '
        'TxtCpdm
        '
        Me.TxtCpdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCpdm.Location = New System.Drawing.Point(150, 41)
        Me.TxtCpdm.MaxLength = 15
        Me.TxtCpdm.Name = "TxtCpdm"
        Me.TxtCpdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtCpdm.TabIndex = 1
        '
        'LblCpdm
        '
        Me.LblCpdm.AutoSize = True
        Me.LblCpdm.Location = New System.Drawing.Point(78, 45)
        Me.LblCpdm.Name = "LblCpdm"
        Me.LblCpdm.Size = New System.Drawing.Size(65, 12)
        Me.LblCpdm.TabIndex = 0
        Me.LblCpdm.Text = "物料编码："
        '
        'LblCkmc
        '
        Me.LblCkmc.AutoSize = True
        Me.LblCkmc.Location = New System.Drawing.Point(258, 125)
        Me.LblCkmc.Name = "LblCkmc"
        Me.LblCkmc.Size = New System.Drawing.Size(0, 12)
        Me.LblCkmc.TabIndex = 8
        '
        'TxtCkdm
        '
        Me.TxtCkdm.Location = New System.Drawing.Point(150, 121)
        Me.TxtCkdm.MaxLength = 30
        Me.TxtCkdm.Name = "TxtCkdm"
        Me.TxtCkdm.Size = New System.Drawing.Size(104, 21)
        Me.TxtCkdm.TabIndex = 7
        '
        'LblCkdm
        '
        Me.LblCkdm.AutoSize = True
        Me.LblCkdm.Location = New System.Drawing.Point(78, 125)
        Me.LblCkdm.Name = "LblCkdm"
        Me.LblCkdm.Size = New System.Drawing.Size(65, 12)
        Me.LblCkdm.TabIndex = 6
        Me.LblCkdm.Text = "仓库编码："
        '
        'TxtQcFzsl
        '
        Me.TxtQcFzsl.Location = New System.Drawing.Point(150, 177)
        Me.TxtQcFzsl.MaxLength = 16
        Me.TxtQcFzsl.Name = "TxtQcFzsl"
        Me.TxtQcFzsl.Size = New System.Drawing.Size(104, 21)
        Me.TxtQcFzsl.TabIndex = 12
        '
        'LblQcFzsl
        '
        Me.LblQcFzsl.AutoSize = True
        Me.LblQcFzsl.Location = New System.Drawing.Point(42, 181)
        Me.LblQcFzsl.Name = "LblQcFzsl"
        Me.LblQcFzsl.Size = New System.Drawing.Size(101, 12)
        Me.LblQcFzsl.TabIndex = 11
        Me.LblQcFzsl.Text = "期初库存辅数量："
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuiFile, Me.MnuiHelp})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(339, 25)
        Me.MenuStrip1.TabIndex = 16
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
        Me.MnuiAbout.Size = New System.Drawing.Size(152, 22)
        Me.MnuiAbout.Text = "关于(&A)"
        '
        'FrmQccpyeSr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(339, 298)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TxtQcFzsl)
        Me.Controls.Add(Me.LblQcFzsl)
        Me.Controls.Add(Me.LblCkmc)
        Me.Controls.Add(Me.TxtCkdm)
        Me.Controls.Add(Me.LblCkdm)
        Me.Controls.Add(Me.TxtQcje)
        Me.Controls.Add(Me.LblQcje)
        Me.Controls.Add(Me.LblDw)
        Me.Controls.Add(Me.LblCpmc)
        Me.Controls.Add(Me.TxtQcsl)
        Me.Controls.Add(Me.LblQcsl)
        Me.Controls.Add(Me.TxtCpdm)
        Me.Controls.Add(Me.LblCpdm)
        Me.Name = "FrmQccpyeSr"
        Me.Text = "期初产品库存余额装入"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.LblCpdm, 0)
        Me.Controls.SetChildIndex(Me.TxtCpdm, 0)
        Me.Controls.SetChildIndex(Me.LblQcsl, 0)
        Me.Controls.SetChildIndex(Me.TxtQcsl, 0)
        Me.Controls.SetChildIndex(Me.LblCpmc, 0)
        Me.Controls.SetChildIndex(Me.LblDw, 0)
        Me.Controls.SetChildIndex(Me.LblQcje, 0)
        Me.Controls.SetChildIndex(Me.TxtQcje, 0)
        Me.Controls.SetChildIndex(Me.LblCkdm, 0)
        Me.Controls.SetChildIndex(Me.TxtCkdm, 0)
        Me.Controls.SetChildIndex(Me.LblCkmc, 0)
        Me.Controls.SetChildIndex(Me.LblQcFzsl, 0)
        Me.Controls.SetChildIndex(Me.TxtQcFzsl, 0)
        Me.Controls.SetChildIndex(Me.MenuStrip1, 0)
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
    Public WithEvents LblCkmc As System.Windows.Forms.Label
    Public WithEvents TxtCkdm As System.Windows.Forms.TextBox
    Public WithEvents LblCkdm As System.Windows.Forms.Label
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
End Class
