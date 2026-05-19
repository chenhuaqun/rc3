<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmOeKhFpFxb
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
        Me.LblhzrqBegin = New System.Windows.Forms.Label()
        Me.TxtLbdm = New System.Windows.Forms.TextBox()
        Me.LblLbdm = New System.Windows.Forms.Label()
        Me.TxtBmdm = New System.Windows.Forms.TextBox()
        Me.LblBmdm = New System.Windows.Forms.Label()
        Me.ChbLb = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NudMonth = New System.Windows.Forms.NumericUpDown()
        Me.NudYear = New System.Windows.Forms.NumericUpDown()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.DlgPanel.SuspendLayout()
        CType(Me.NudMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(354, 184)
        Me.DlgPanel.TabIndex = 8
        '
        'LblhzrqBegin
        '
        Me.LblhzrqBegin.AutoSize = True
        Me.LblhzrqBegin.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblhzrqBegin.Location = New System.Drawing.Point(47, 33)
        Me.LblhzrqBegin.Name = "LblhzrqBegin"
        Me.LblhzrqBegin.Size = New System.Drawing.Size(87, 16)
        Me.LblhzrqBegin.TabIndex = 0
        Me.LblhzrqBegin.Text = "会计期间："
        '
        'TxtLbdm
        '
        Me.TxtLbdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLbdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtLbdm.Location = New System.Drawing.Point(143, 70)
        Me.TxtLbdm.MaxLength = 12
        Me.TxtLbdm.Name = "TxtLbdm"
        Me.TxtLbdm.Size = New System.Drawing.Size(146, 26)
        Me.TxtLbdm.TabIndex = 5
        '
        'LblLbdm
        '
        Me.LblLbdm.AutoSize = True
        Me.LblLbdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblLbdm.Location = New System.Drawing.Point(47, 75)
        Me.LblLbdm.Name = "LblLbdm"
        Me.LblLbdm.Size = New System.Drawing.Size(87, 16)
        Me.LblLbdm.TabIndex = 4
        Me.LblLbdm.Text = "客户类别："
        '
        'TxtBmdm
        '
        Me.TxtBmdm.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtBmdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtBmdm.Location = New System.Drawing.Point(414, 70)
        Me.TxtBmdm.MaxLength = 12
        Me.TxtBmdm.Name = "TxtBmdm"
        Me.TxtBmdm.Size = New System.Drawing.Size(146, 26)
        Me.TxtBmdm.TabIndex = 7
        '
        'LblBmdm
        '
        Me.LblBmdm.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblBmdm.AutoSize = True
        Me.LblBmdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblBmdm.Location = New System.Drawing.Point(318, 75)
        Me.LblBmdm.Name = "LblBmdm"
        Me.LblBmdm.Size = New System.Drawing.Size(87, 16)
        Me.LblBmdm.TabIndex = 6
        Me.LblBmdm.Text = "部门编码："
        '
        'ChbLb
        '
        Me.ChbLb.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ChbLb.ForeColor = System.Drawing.Color.SteelBlue
        Me.ChbLb.Location = New System.Drawing.Point(50, 121)
        Me.ChbLb.Name = "ChbLb"
        Me.ChbLb.Size = New System.Drawing.Size(146, 21)
        Me.ChbLb.TabIndex = 27
        Me.ChbLb.Text = "按物料分类展开"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(289, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 16)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "月"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(217, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 16)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "年"
        '
        'NudMonth
        '
        Me.NudMonth.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NudMonth.Location = New System.Drawing.Point(241, 31)
        Me.NudMonth.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NudMonth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudMonth.Name = "NudMonth"
        Me.NudMonth.Size = New System.Drawing.Size(40, 26)
        Me.NudMonth.TabIndex = 30
        Me.NudMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudMonth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NudYear
        '
        Me.NudYear.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NudYear.Location = New System.Drawing.Point(145, 31)
        Me.NudYear.Maximum = New Decimal(New Integer() {2050, 0, 0, 0})
        Me.NudYear.Minimum = New Decimal(New Integer() {1990, 0, 0, 0})
        Me.NudYear.Name = "NudYear"
        Me.NudYear.Size = New System.Drawing.Size(64, 26)
        Me.NudYear.TabIndex = 28
        Me.NudYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudYear.Value = New Decimal(New Integer() {1990, 0, 0, 0})
        '
        'LblMsg
        '
        Me.LblMsg.AutoSize = True
        Me.LblMsg.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblMsg.ForeColor = System.Drawing.Color.Navy
        Me.LblMsg.Location = New System.Drawing.Point(47, 190)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(87, 16)
        Me.LblMsg.TabIndex = 121
        Me.LblMsg.Text = "提示信息。"
        '
        'CheckBox1
        '
        Me.CheckBox1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.SteelBlue
        Me.CheckBox1.Location = New System.Drawing.Point(274, 121)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(318, 21)
        Me.CheckBox1.TabIndex = 122
        Me.CheckBox1.Text = "上年同期从销售出库(产品送货单)取数"
        '
        'CheckBox2
        '
        Me.CheckBox2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CheckBox2.ForeColor = System.Drawing.Color.SteelBlue
        Me.CheckBox2.Location = New System.Drawing.Point(50, 148)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(146, 21)
        Me.CheckBox2.TabIndex = 123
        Me.CheckBox2.Text = "按物料分类查询"
        '
        'FrmOeKhFpFxb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(607, 227)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.LblMsg)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NudMonth)
        Me.Controls.Add(Me.NudYear)
        Me.Controls.Add(Me.ChbLb)
        Me.Controls.Add(Me.TxtBmdm)
        Me.Controls.Add(Me.LblBmdm)
        Me.Controls.Add(Me.TxtLbdm)
        Me.Controls.Add(Me.LblLbdm)
        Me.Controls.Add(Me.LblhzrqBegin)
        Me.Name = "FrmOeKhFpFxb"
        Me.Text = "客户销售发票对比分析表"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.LblhzrqBegin, 0)
        Me.Controls.SetChildIndex(Me.LblLbdm, 0)
        Me.Controls.SetChildIndex(Me.TxtLbdm, 0)
        Me.Controls.SetChildIndex(Me.LblBmdm, 0)
        Me.Controls.SetChildIndex(Me.TxtBmdm, 0)
        Me.Controls.SetChildIndex(Me.ChbLb, 0)
        Me.Controls.SetChildIndex(Me.NudYear, 0)
        Me.Controls.SetChildIndex(Me.NudMonth, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.LblMsg, 0)
        Me.Controls.SetChildIndex(Me.CheckBox1, 0)
        Me.Controls.SetChildIndex(Me.CheckBox2, 0)
        Me.DlgPanel.ResumeLayout(False)
        CType(Me.NudMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents LblhzrqBegin As System.Windows.Forms.Label
    Friend WithEvents TxtLbdm As System.Windows.Forms.TextBox
    Friend WithEvents LblLbdm As System.Windows.Forms.Label
    Friend WithEvents TxtBmdm As System.Windows.Forms.TextBox
    Friend WithEvents LblBmdm As System.Windows.Forms.Label
    Friend WithEvents ChbLb As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents NudMonth As NumericUpDown
    Friend WithEvents NudYear As NumericUpDown
    Friend WithEvents LblMsg As Label
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
End Class
