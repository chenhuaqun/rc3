<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmOeKhFpHzb
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
        Me.LblhzrqEnd = New System.Windows.Forms.Label()
        Me.DtpHzrqEnd = New System.Windows.Forms.DateTimePicker()
        Me.LblhzrqBegin = New System.Windows.Forms.Label()
        Me.DtpHzrqBegin = New System.Windows.Forms.DateTimePicker()
        Me.TxtLbdm = New System.Windows.Forms.TextBox()
        Me.LblLbdm = New System.Windows.Forms.Label()
        Me.TxtBmdm = New System.Windows.Forms.TextBox()
        Me.LblBmdm = New System.Windows.Forms.Label()
        Me.ChbLb = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.DlgPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(354, 160)
        Me.DlgPanel.TabIndex = 8
        '
        'LblhzrqEnd
        '
        Me.LblhzrqEnd.AutoSize = True
        Me.LblhzrqEnd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblhzrqEnd.Location = New System.Drawing.Point(337, 33)
        Me.LblhzrqEnd.Name = "LblhzrqEnd"
        Me.LblhzrqEnd.Size = New System.Drawing.Size(39, 16)
        Me.LblhzrqEnd.TabIndex = 2
        Me.LblhzrqEnd.Text = "至："
        '
        'DtpHzrqEnd
        '
        Me.DtpHzrqEnd.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpHzrqEnd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.DtpHzrqEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpHzrqEnd.Location = New System.Drawing.Point(385, 28)
        Me.DtpHzrqEnd.Name = "DtpHzrqEnd"
        Me.DtpHzrqEnd.Size = New System.Drawing.Size(186, 26)
        Me.DtpHzrqEnd.TabIndex = 3
        '
        'LblhzrqBegin
        '
        Me.LblhzrqBegin.AutoSize = True
        Me.LblhzrqBegin.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblhzrqBegin.Location = New System.Drawing.Point(31, 33)
        Me.LblhzrqBegin.Name = "LblhzrqBegin"
        Me.LblhzrqBegin.Size = New System.Drawing.Size(103, 16)
        Me.LblhzrqBegin.TabIndex = 0
        Me.LblhzrqBegin.Text = "汇总日期从："
        '
        'DtpHzrqBegin
        '
        Me.DtpHzrqBegin.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpHzrqBegin.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.DtpHzrqBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpHzrqBegin.Location = New System.Drawing.Point(143, 28)
        Me.DtpHzrqBegin.Name = "DtpHzrqBegin"
        Me.DtpHzrqBegin.Size = New System.Drawing.Size(186, 26)
        Me.DtpHzrqBegin.TabIndex = 1
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
        Me.ChbLb.Location = New System.Drawing.Point(66, 120)
        Me.ChbLb.Name = "ChbLb"
        Me.ChbLb.Size = New System.Drawing.Size(146, 21)
        Me.ChbLb.TabIndex = 27
        Me.ChbLb.Text = "按物料分类展开"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.SteelBlue
        Me.CheckBox1.Location = New System.Drawing.Point(263, 121)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(282, 20)
        Me.CheckBox1.TabIndex = 28
        Me.CheckBox1.Text = "包含补货产品送货单(有数量没金额)"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'FrmOeKhFpHzb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(607, 203)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.ChbLb)
        Me.Controls.Add(Me.TxtBmdm)
        Me.Controls.Add(Me.LblBmdm)
        Me.Controls.Add(Me.TxtLbdm)
        Me.Controls.Add(Me.LblLbdm)
        Me.Controls.Add(Me.LblhzrqEnd)
        Me.Controls.Add(Me.DtpHzrqEnd)
        Me.Controls.Add(Me.LblhzrqBegin)
        Me.Controls.Add(Me.DtpHzrqBegin)
        Me.Name = "FrmOeKhFpHzb"
        Me.Text = "客户销售发票汇总表"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.DtpHzrqBegin, 0)
        Me.Controls.SetChildIndex(Me.LblhzrqBegin, 0)
        Me.Controls.SetChildIndex(Me.DtpHzrqEnd, 0)
        Me.Controls.SetChildIndex(Me.LblhzrqEnd, 0)
        Me.Controls.SetChildIndex(Me.LblLbdm, 0)
        Me.Controls.SetChildIndex(Me.TxtLbdm, 0)
        Me.Controls.SetChildIndex(Me.LblBmdm, 0)
        Me.Controls.SetChildIndex(Me.TxtBmdm, 0)
        Me.Controls.SetChildIndex(Me.ChbLb, 0)
        Me.Controls.SetChildIndex(Me.CheckBox1, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents LblhzrqEnd As System.Windows.Forms.Label
    Public WithEvents DtpHzrqEnd As System.Windows.Forms.DateTimePicker
    Public WithEvents LblhzrqBegin As System.Windows.Forms.Label
    Public WithEvents DtpHzrqBegin As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtLbdm As System.Windows.Forms.TextBox
    Friend WithEvents LblLbdm As System.Windows.Forms.Label
    Friend WithEvents TxtBmdm As System.Windows.Forms.TextBox
    Friend WithEvents LblBmdm As System.Windows.Forms.Label
    Friend WithEvents ChbLb As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
End Class
