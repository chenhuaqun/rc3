<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeCkCpHzb
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
        Me.LblhzrqEnd = New System.Windows.Forms.Label()
        Me.DtpHzrqEnd = New System.Windows.Forms.DateTimePicker()
        Me.LblhzrqBegin = New System.Windows.Forms.Label()
        Me.DtpHzrqBegin = New System.Windows.Forms.DateTimePicker()
        Me.TxtLbdm = New System.Windows.Forms.TextBox()
        Me.LblLbdm = New System.Windows.Forms.Label()
        Me.TxtBmdm = New System.Windows.Forms.TextBox()
        Me.LblBmdm = New System.Windows.Forms.Label()
        Me.TxtCkdm = New System.Windows.Forms.TextBox()
        Me.LblCckdm = New System.Windows.Forms.Label()
        Me.TxtCpdm = New System.Windows.Forms.TextBox()
        Me.LblCpdm = New System.Windows.Forms.Label()
        Me.DlgPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(124, 4)
        Me.BtnCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnCancel.Size = New System.Drawing.Size(111, 34)
        '
        'BtnHelp
        '
        Me.BtnHelp.Location = New System.Drawing.Point(244, 4)
        Me.BtnHelp.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnHelp.Size = New System.Drawing.Size(112, 34)
        '
        'BtnOk
        '
        Me.BtnOk.Location = New System.Drawing.Point(4, 4)
        Me.BtnOk.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnOk.Size = New System.Drawing.Size(111, 34)
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(526, 213)
        Me.DlgPanel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DlgPanel.Size = New System.Drawing.Size(362, 46)
        Me.DlgPanel.TabIndex = 12
        '
        'LblhzrqEnd
        '
        Me.LblhzrqEnd.AutoSize = True
        Me.LblhzrqEnd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblhzrqEnd.Location = New System.Drawing.Point(506, 47)
        Me.LblhzrqEnd.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblhzrqEnd.Name = "LblhzrqEnd"
        Me.LblhzrqEnd.Size = New System.Drawing.Size(58, 24)
        Me.LblhzrqEnd.TabIndex = 2
        Me.LblhzrqEnd.Text = "至："
        '
        'DtpHzrqEnd
        '
        Me.DtpHzrqEnd.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpHzrqEnd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.DtpHzrqEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpHzrqEnd.Location = New System.Drawing.Point(578, 42)
        Me.DtpHzrqEnd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DtpHzrqEnd.Name = "DtpHzrqEnd"
        Me.DtpHzrqEnd.Size = New System.Drawing.Size(277, 35)
        Me.DtpHzrqEnd.TabIndex = 3
        '
        'LblhzrqBegin
        '
        Me.LblhzrqBegin.AutoSize = True
        Me.LblhzrqBegin.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblhzrqBegin.Location = New System.Drawing.Point(46, 47)
        Me.LblhzrqBegin.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblhzrqBegin.Name = "LblhzrqBegin"
        Me.LblhzrqBegin.Size = New System.Drawing.Size(154, 24)
        Me.LblhzrqBegin.TabIndex = 0
        Me.LblhzrqBegin.Text = "汇总日期从："
        '
        'DtpHzrqBegin
        '
        Me.DtpHzrqBegin.CustomFormat = "yyyy年MM月dd日 HH:mm"
        Me.DtpHzrqBegin.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.DtpHzrqBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpHzrqBegin.Location = New System.Drawing.Point(214, 42)
        Me.DtpHzrqBegin.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DtpHzrqBegin.Name = "DtpHzrqBegin"
        Me.DtpHzrqBegin.Size = New System.Drawing.Size(277, 35)
        Me.DtpHzrqBegin.TabIndex = 1
        '
        'TxtLbdm
        '
        Me.TxtLbdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLbdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtLbdm.Location = New System.Drawing.Point(214, 93)
        Me.TxtLbdm.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtLbdm.MaxLength = 12
        Me.TxtLbdm.Name = "TxtLbdm"
        Me.TxtLbdm.Size = New System.Drawing.Size(166, 35)
        Me.TxtLbdm.TabIndex = 5
        '
        'LblLbdm
        '
        Me.LblLbdm.AutoSize = True
        Me.LblLbdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblLbdm.Location = New System.Drawing.Point(70, 98)
        Me.LblLbdm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblLbdm.Name = "LblLbdm"
        Me.LblLbdm.Size = New System.Drawing.Size(130, 24)
        Me.LblLbdm.TabIndex = 4
        Me.LblLbdm.Text = "产品类别："
        '
        'TxtBmdm
        '
        Me.TxtBmdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtBmdm.Location = New System.Drawing.Point(214, 144)
        Me.TxtBmdm.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtBmdm.MaxLength = 12
        Me.TxtBmdm.Name = "TxtBmdm"
        Me.TxtBmdm.Size = New System.Drawing.Size(166, 35)
        Me.TxtBmdm.TabIndex = 9
        '
        'LblBmdm
        '
        Me.LblBmdm.AutoSize = True
        Me.LblBmdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblBmdm.Location = New System.Drawing.Point(70, 149)
        Me.LblBmdm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBmdm.Name = "LblBmdm"
        Me.LblBmdm.Size = New System.Drawing.Size(130, 24)
        Me.LblBmdm.TabIndex = 8
        Me.LblBmdm.Text = "部门编码："
        '
        'TxtCkdm
        '
        Me.TxtCkdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtCkdm.Location = New System.Drawing.Point(578, 144)
        Me.TxtCkdm.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCkdm.MaxLength = 30
        Me.TxtCkdm.Name = "TxtCkdm"
        Me.TxtCkdm.Size = New System.Drawing.Size(166, 35)
        Me.TxtCkdm.TabIndex = 11
        '
        'LblCckdm
        '
        Me.LblCckdm.AutoSize = True
        Me.LblCckdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblCckdm.Location = New System.Drawing.Point(434, 149)
        Me.LblCckdm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCckdm.Name = "LblCckdm"
        Me.LblCckdm.Size = New System.Drawing.Size(130, 24)
        Me.LblCckdm.TabIndex = 10
        Me.LblCckdm.Text = "仓库编码："
        '
        'TxtCpdm
        '
        Me.TxtCpdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtCpdm.Location = New System.Drawing.Point(578, 93)
        Me.TxtCpdm.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCpdm.MaxLength = 15
        Me.TxtCpdm.Name = "TxtCpdm"
        Me.TxtCpdm.Size = New System.Drawing.Size(166, 35)
        Me.TxtCpdm.TabIndex = 7
        '
        'LblCpdm
        '
        Me.LblCpdm.AutoSize = True
        Me.LblCpdm.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblCpdm.Location = New System.Drawing.Point(434, 98)
        Me.LblCpdm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCpdm.Name = "LblCpdm"
        Me.LblCpdm.Size = New System.Drawing.Size(130, 24)
        Me.LblCpdm.TabIndex = 6
        Me.LblCpdm.Text = "物料编码："
        '
        'FrmOeCkCpHzb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(906, 278)
        Me.Controls.Add(Me.TxtCpdm)
        Me.Controls.Add(Me.LblCpdm)
        Me.Controls.Add(Me.TxtCkdm)
        Me.Controls.Add(Me.LblCckdm)
        Me.Controls.Add(Me.TxtBmdm)
        Me.Controls.Add(Me.LblBmdm)
        Me.Controls.Add(Me.TxtLbdm)
        Me.Controls.Add(Me.LblLbdm)
        Me.Controls.Add(Me.LblhzrqEnd)
        Me.Controls.Add(Me.DtpHzrqEnd)
        Me.Controls.Add(Me.LblhzrqBegin)
        Me.Controls.Add(Me.DtpHzrqBegin)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FrmOeCkCpHzb"
        Me.Text = "产品送货仓库汇总表"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.DtpHzrqBegin, 0)
        Me.Controls.SetChildIndex(Me.LblhzrqBegin, 0)
        Me.Controls.SetChildIndex(Me.DtpHzrqEnd, 0)
        Me.Controls.SetChildIndex(Me.LblhzrqEnd, 0)
        Me.Controls.SetChildIndex(Me.LblLbdm, 0)
        Me.Controls.SetChildIndex(Me.TxtLbdm, 0)
        Me.Controls.SetChildIndex(Me.LblBmdm, 0)
        Me.Controls.SetChildIndex(Me.TxtBmdm, 0)
        Me.Controls.SetChildIndex(Me.LblCckdm, 0)
        Me.Controls.SetChildIndex(Me.TxtCkdm, 0)
        Me.Controls.SetChildIndex(Me.LblCpdm, 0)
        Me.Controls.SetChildIndex(Me.TxtCpdm, 0)
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
    Public WithEvents TxtBmdm As System.Windows.Forms.TextBox
    Public WithEvents LblBmdm As System.Windows.Forms.Label
    Public WithEvents TxtCkdm As System.Windows.Forms.TextBox
    Public WithEvents LblCckdm As System.Windows.Forms.Label
    Public WithEvents TxtCpdm As TextBox
    Public WithEvents LblCpdm As Label
End Class
