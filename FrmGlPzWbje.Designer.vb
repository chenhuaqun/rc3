<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGlPzWbje
    Inherits models.FrmDlgPortrait

    '窗体重写释放，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TxtJe = New System.Windows.Forms.TextBox
        Me.LblJe = New System.Windows.Forms.Label
        Me.TxtHl = New System.Windows.Forms.TextBox
        Me.LblHl = New System.Windows.Forms.Label
        Me.TxtWb = New System.Windows.Forms.TextBox
        Me.LblWb = New System.Windows.Forms.Label
        Me.LblJd = New System.Windows.Forms.Label
        Me.CmbJd = New System.Windows.Forms.ComboBox
        Me.TxtWbdm = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.DlgPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(41, 193)
        Me.DlgPanel.TabIndex = 10
        '
        'TxtJe
        '
        Me.TxtJe.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtJe.Location = New System.Drawing.Point(148, 147)
        Me.TxtJe.Name = "TxtJe"
        Me.TxtJe.Size = New System.Drawing.Size(104, 26)
        Me.TxtJe.TabIndex = 9
        Me.TxtJe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblJe
        '
        Me.LblJe.AutoSize = True
        Me.LblJe.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblJe.Location = New System.Drawing.Point(43, 150)
        Me.LblJe.Name = "LblJe"
        Me.LblJe.Size = New System.Drawing.Size(88, 16)
        Me.LblJe.TabIndex = 8
        Me.LblJe.Text = "金    额："
        '
        'TxtHl
        '
        Me.TxtHl.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtHl.Location = New System.Drawing.Point(148, 114)
        Me.TxtHl.Name = "TxtHl"
        Me.TxtHl.Size = New System.Drawing.Size(104, 26)
        Me.TxtHl.TabIndex = 7
        Me.TxtHl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblHl
        '
        Me.LblHl.AutoSize = True
        Me.LblHl.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblHl.Location = New System.Drawing.Point(43, 117)
        Me.LblHl.Name = "LblHl"
        Me.LblHl.Size = New System.Drawing.Size(88, 16)
        Me.LblHl.TabIndex = 6
        Me.LblHl.Text = "汇    率："
        '
        'TxtWb
        '
        Me.TxtWb.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtWb.Location = New System.Drawing.Point(148, 82)
        Me.TxtWb.Name = "TxtWb"
        Me.TxtWb.Size = New System.Drawing.Size(104, 26)
        Me.TxtWb.TabIndex = 5
        Me.TxtWb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblWb
        '
        Me.LblWb.AutoSize = True
        Me.LblWb.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblWb.Location = New System.Drawing.Point(43, 85)
        Me.LblWb.Name = "LblWb"
        Me.LblWb.Size = New System.Drawing.Size(88, 16)
        Me.LblWb.TabIndex = 4
        Me.LblWb.Text = "外币金额："
        '
        'LblJd
        '
        Me.LblJd.AutoSize = True
        Me.LblJd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblJd.Location = New System.Drawing.Point(43, 53)
        Me.LblJd.Name = "LblJd"
        Me.LblJd.Size = New System.Drawing.Size(88, 16)
        Me.LblJd.TabIndex = 2
        Me.LblJd.Text = "借贷方向："
        '
        'CmbJd
        '
        Me.CmbJd.DisplayMember = "借"
        Me.CmbJd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbJd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CmbJd.FormattingEnabled = True
        Me.CmbJd.Items.AddRange(New Object() {"借", "贷"})
        Me.CmbJd.Location = New System.Drawing.Point(148, 50)
        Me.CmbJd.Name = "CmbJd"
        Me.CmbJd.Size = New System.Drawing.Size(104, 24)
        Me.CmbJd.TabIndex = 3
        Me.CmbJd.ValueMember = "借"
        '
        'TxtWbdm
        '
        Me.TxtWbdm.Enabled = False
        Me.TxtWbdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtWbdm.Location = New System.Drawing.Point(148, 17)
        Me.TxtWbdm.Name = "TxtWbdm"
        Me.TxtWbdm.ReadOnly = True
        Me.TxtWbdm.Size = New System.Drawing.Size(104, 26)
        Me.TxtWbdm.TabIndex = 1
        Me.TxtWbdm.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.Location = New System.Drawing.Point(43, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "币    种："
        '
        'FrmGlPzWbje
        '
        Me.ClientSize = New System.Drawing.Size(294, 236)
        Me.Controls.Add(Me.TxtWbdm)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CmbJd)
        Me.Controls.Add(Me.TxtJe)
        Me.Controls.Add(Me.TxtWb)
        Me.Controls.Add(Me.LblJd)
        Me.Controls.Add(Me.LblWb)
        Me.Controls.Add(Me.LblJe)
        Me.Controls.Add(Me.TxtHl)
        Me.Controls.Add(Me.LblHl)
        Me.Name = "FrmGlPzWbje"
        Me.Text = "外币金额*汇率=本位币金额"
        Me.Controls.SetChildIndex(Me.LblHl, 0)
        Me.Controls.SetChildIndex(Me.TxtHl, 0)
        Me.Controls.SetChildIndex(Me.LblJe, 0)
        Me.Controls.SetChildIndex(Me.LblWb, 0)
        Me.Controls.SetChildIndex(Me.LblJd, 0)
        Me.Controls.SetChildIndex(Me.TxtWb, 0)
        Me.Controls.SetChildIndex(Me.TxtJe, 0)
        Me.Controls.SetChildIndex(Me.CmbJd, 0)
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.TxtWbdm, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtJe As System.Windows.Forms.TextBox
    Friend WithEvents LblJe As System.Windows.Forms.Label
    Friend WithEvents TxtHl As System.Windows.Forms.TextBox
    Friend WithEvents LblHl As System.Windows.Forms.Label
    Friend WithEvents TxtWb As System.Windows.Forms.TextBox
    Friend WithEvents LblWb As System.Windows.Forms.Label
    Friend WithEvents LblJd As System.Windows.Forms.Label
    Friend WithEvents CmbJd As System.Windows.Forms.ComboBox
    Friend WithEvents TxtWbdm As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
