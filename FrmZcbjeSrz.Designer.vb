<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmZcbjeSrz
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
        Me.TxtKjqj = New System.Windows.Forms.TextBox()
        Me.LblDjh = New System.Windows.Forms.Label()
        Me.TxtZcbje = New System.Windows.Forms.TextBox()
        Me.LblZcbje = New System.Windows.Forms.Label()
        Me.LblQczcpje = New System.Windows.Forms.Label()
        Me.TxtQczcpje = New System.Windows.Forms.TextBox()
        Me.LblQmZcclje = New System.Windows.Forms.Label()
        Me.TxtQmzcclje = New System.Windows.Forms.TextBox()
        Me.LblCcpje = New System.Windows.Forms.Label()
        Me.TxtCcpje = New System.Windows.Forms.TextBox()
        Me.LblQmzcpje = New System.Windows.Forms.Label()
        Me.TxtQmzcpje = New System.Windows.Forms.TextBox()
        Me.LblBmmc = New System.Windows.Forms.Label()
        Me.TxtBmdm = New System.Windows.Forms.TextBox()
        Me.LblBmdm = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DlgPanel.SuspendLayout()
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
        Me.DlgPanel.Location = New System.Drawing.Point(293, 302)
        Me.DlgPanel.TabIndex = 15
        '
        'TxtKjqj
        '
        Me.TxtKjqj.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtKjqj.Enabled = False
        Me.TxtKjqj.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtKjqj.Location = New System.Drawing.Point(242, 22)
        Me.TxtKjqj.MaxLength = 15
        Me.TxtKjqj.Name = "TxtKjqj"
        Me.TxtKjqj.Size = New System.Drawing.Size(110, 26)
        Me.TxtKjqj.TabIndex = 1
        '
        'LblDjh
        '
        Me.LblDjh.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblDjh.AutoSize = True
        Me.LblDjh.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblDjh.Location = New System.Drawing.Point(146, 27)
        Me.LblDjh.Name = "LblDjh"
        Me.LblDjh.Size = New System.Drawing.Size(88, 16)
        Me.LblDjh.TabIndex = 0
        Me.LblDjh.Text = "会计期间："
        '
        'TxtZcbje
        '
        Me.TxtZcbje.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtZcbje.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtZcbje.Location = New System.Drawing.Point(242, 124)
        Me.TxtZcbje.MaxLength = 14
        Me.TxtZcbje.Name = "TxtZcbje"
        Me.TxtZcbje.Size = New System.Drawing.Size(132, 26)
        Me.TxtZcbje.TabIndex = 8
        Me.TxtZcbje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblZcbje
        '
        Me.LblZcbje.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblZcbje.AutoSize = True
        Me.LblZcbje.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblZcbje.Location = New System.Drawing.Point(98, 129)
        Me.LblZcbje.Name = "LblZcbje"
        Me.LblZcbje.Size = New System.Drawing.Size(136, 16)
        Me.LblZcbje.TabIndex = 7
        Me.LblZcbje.Text = "本期投入总成本："
        '
        'LblQczcpje
        '
        Me.LblQczcpje.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblQczcpje.AutoSize = True
        Me.LblQczcpje.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblQczcpje.Location = New System.Drawing.Point(98, 95)
        Me.LblQczcpje.Name = "LblQczcpje"
        Me.LblQczcpje.Size = New System.Drawing.Size(136, 16)
        Me.LblQczcpje.TabIndex = 5
        Me.LblQczcpje.Text = "期初在产品成本："
        '
        'TxtQczcpje
        '
        Me.TxtQczcpje.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtQczcpje.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtQczcpje.Location = New System.Drawing.Point(242, 90)
        Me.TxtQczcpje.MaxLength = 14
        Me.TxtQczcpje.Name = "TxtQczcpje"
        Me.TxtQczcpje.Size = New System.Drawing.Size(132, 26)
        Me.TxtQczcpje.TabIndex = 6
        Me.TxtQczcpje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblQmZcclje
        '
        Me.LblQmZcclje.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblQmZcclje.AutoSize = True
        Me.LblQmZcclje.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblQmZcclje.Location = New System.Drawing.Point(82, 197)
        Me.LblQmZcclje.Name = "LblQmZcclje"
        Me.LblQmZcclje.Size = New System.Drawing.Size(152, 16)
        Me.LblQmZcclje.TabIndex = 11
        Me.LblQmZcclje.Text = "期末在产材料成本："
        '
        'TxtQmzcclje
        '
        Me.TxtQmzcclje.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtQmzcclje.Enabled = False
        Me.TxtQmzcclje.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtQmzcclje.Location = New System.Drawing.Point(242, 192)
        Me.TxtQmzcclje.MaxLength = 14
        Me.TxtQmzcclje.Name = "TxtQmzcclje"
        Me.TxtQmzcclje.Size = New System.Drawing.Size(132, 26)
        Me.TxtQmzcclje.TabIndex = 12
        Me.TxtQmzcclje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblCcpje
        '
        Me.LblCcpje.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblCcpje.AutoSize = True
        Me.LblCcpje.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblCcpje.Location = New System.Drawing.Point(66, 163)
        Me.LblCcpje.Name = "LblCcpje"
        Me.LblCcpje.Size = New System.Drawing.Size(168, 16)
        Me.LblCcpje.TabIndex = 9
        Me.LblCcpje.Text = "本期产成品入库成本："
        '
        'TxtCcpje
        '
        Me.TxtCcpje.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtCcpje.Enabled = False
        Me.TxtCcpje.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtCcpje.Location = New System.Drawing.Point(242, 158)
        Me.TxtCcpje.MaxLength = 14
        Me.TxtCcpje.Name = "TxtCcpje"
        Me.TxtCcpje.Size = New System.Drawing.Size(132, 26)
        Me.TxtCcpje.TabIndex = 10
        Me.TxtCcpje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblQmzcpje
        '
        Me.LblQmzcpje.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblQmzcpje.AutoSize = True
        Me.LblQmzcpje.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblQmzcpje.Location = New System.Drawing.Point(98, 231)
        Me.LblQmzcpje.Name = "LblQmzcpje"
        Me.LblQmzcpje.Size = New System.Drawing.Size(136, 16)
        Me.LblQmzcpje.TabIndex = 13
        Me.LblQmzcpje.Text = "期末在产品成本："
        '
        'TxtQmzcpje
        '
        Me.TxtQmzcpje.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtQmzcpje.Enabled = False
        Me.TxtQmzcpje.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtQmzcpje.Location = New System.Drawing.Point(242, 226)
        Me.TxtQmzcpje.MaxLength = 14
        Me.TxtQmzcpje.Name = "TxtQmzcpje"
        Me.TxtQmzcpje.Size = New System.Drawing.Size(132, 26)
        Me.TxtQmzcpje.TabIndex = 14
        Me.TxtQmzcpje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblBmmc
        '
        Me.LblBmmc.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblBmmc.AutoSize = True
        Me.LblBmmc.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblBmmc.Location = New System.Drawing.Point(360, 61)
        Me.LblBmmc.Name = "LblBmmc"
        Me.LblBmmc.Size = New System.Drawing.Size(0, 16)
        Me.LblBmmc.TabIndex = 4
        '
        'TxtBmdm
        '
        Me.TxtBmdm.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtBmdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtBmdm.Location = New System.Drawing.Point(242, 56)
        Me.TxtBmdm.MaxLength = 12
        Me.TxtBmdm.Name = "TxtBmdm"
        Me.TxtBmdm.Size = New System.Drawing.Size(110, 26)
        Me.TxtBmdm.TabIndex = 3
        '
        'LblBmdm
        '
        Me.LblBmdm.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblBmdm.AutoSize = True
        Me.LblBmdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblBmdm.Location = New System.Drawing.Point(130, 61)
        Me.LblBmdm.Name = "LblBmdm"
        Me.LblBmdm.Size = New System.Drawing.Size(88, 16)
        Me.LblBmdm.TabIndex = 2
        Me.LblBmdm.Text = "部门编码："
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(380, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 16)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "*含期初在产材料成本"
        '
        'FrmZcbjeSrz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(546, 345)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblBmmc)
        Me.Controls.Add(Me.TxtBmdm)
        Me.Controls.Add(Me.LblBmdm)
        Me.Controls.Add(Me.LblQmzcpje)
        Me.Controls.Add(Me.TxtQmzcpje)
        Me.Controls.Add(Me.LblCcpje)
        Me.Controls.Add(Me.TxtCcpje)
        Me.Controls.Add(Me.LblQmZcclje)
        Me.Controls.Add(Me.TxtQmzcclje)
        Me.Controls.Add(Me.LblQczcpje)
        Me.Controls.Add(Me.TxtQczcpje)
        Me.Controls.Add(Me.TxtZcbje)
        Me.Controls.Add(Me.LblZcbje)
        Me.Controls.Add(Me.TxtKjqj)
        Me.Controls.Add(Me.LblDjh)
        Me.Name = "FrmZcbjeSrz"
        Me.Text = "本期投入总成本录入"
        Me.Controls.SetChildIndex(Me.LblDjh, 0)
        Me.Controls.SetChildIndex(Me.TxtKjqj, 0)
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.LblZcbje, 0)
        Me.Controls.SetChildIndex(Me.TxtZcbje, 0)
        Me.Controls.SetChildIndex(Me.TxtQczcpje, 0)
        Me.Controls.SetChildIndex(Me.LblQczcpje, 0)
        Me.Controls.SetChildIndex(Me.TxtQmzcclje, 0)
        Me.Controls.SetChildIndex(Me.LblQmZcclje, 0)
        Me.Controls.SetChildIndex(Me.TxtCcpje, 0)
        Me.Controls.SetChildIndex(Me.LblCcpje, 0)
        Me.Controls.SetChildIndex(Me.TxtQmzcpje, 0)
        Me.Controls.SetChildIndex(Me.LblQmzcpje, 0)
        Me.Controls.SetChildIndex(Me.LblBmdm, 0)
        Me.Controls.SetChildIndex(Me.TxtBmdm, 0)
        Me.Controls.SetChildIndex(Me.LblBmmc, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtKjqj As System.Windows.Forms.TextBox
    Friend WithEvents LblDjh As System.Windows.Forms.Label
    Friend WithEvents TxtZcbje As System.Windows.Forms.TextBox
    Public WithEvents LblZcbje As System.Windows.Forms.Label
    Friend WithEvents LblQczcpje As System.Windows.Forms.Label
    Friend WithEvents TxtQczcpje As System.Windows.Forms.TextBox
    Friend WithEvents LblQmZcclje As System.Windows.Forms.Label
    Friend WithEvents TxtQmzcclje As System.Windows.Forms.TextBox
    Friend WithEvents LblCcpje As System.Windows.Forms.Label
    Friend WithEvents TxtCcpje As System.Windows.Forms.TextBox
    Friend WithEvents LblQmzcpje As System.Windows.Forms.Label
    Friend WithEvents TxtQmzcpje As System.Windows.Forms.TextBox
    Friend WithEvents LblBmmc As System.Windows.Forms.Label
    Friend WithEvents TxtBmdm As System.Windows.Forms.TextBox
    Friend WithEvents LblBmdm As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
