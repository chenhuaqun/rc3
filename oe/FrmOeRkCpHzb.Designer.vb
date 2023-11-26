<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeRkCpHzb
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
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
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
        Me.DlgPanel.Location = New System.Drawing.Point(530, 192)
        Me.DlgPanel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DlgPanel.Size = New System.Drawing.Size(362, 46)
        Me.DlgPanel.TabIndex = 5
        '
        'LblhzrqEnd
        '
        Me.LblhzrqEnd.AutoSize = True
        Me.LblhzrqEnd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblhzrqEnd.Location = New System.Drawing.Point(506, 50)
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
        Me.LblhzrqBegin.Location = New System.Drawing.Point(46, 50)
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
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CheckBox1.Location = New System.Drawing.Point(214, 116)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(276, 28)
        Me.CheckBox1.TabIndex = 4
        Me.CheckBox1.Text = "按物料类别分部门汇总"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CheckBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CheckBox2.Location = New System.Drawing.Point(544, 116)
        Me.CheckBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(204, 28)
        Me.CheckBox2.TabIndex = 6
        Me.CheckBox2.Text = "按物料类别汇总"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'FrmOeRkCpHzb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(909, 256)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.LblhzrqEnd)
        Me.Controls.Add(Me.DtpHzrqEnd)
        Me.Controls.Add(Me.LblhzrqBegin)
        Me.Controls.Add(Me.DtpHzrqBegin)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FrmOeRkCpHzb"
        Me.Text = "产品入库产值汇总表"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.DtpHzrqBegin, 0)
        Me.Controls.SetChildIndex(Me.LblhzrqBegin, 0)
        Me.Controls.SetChildIndex(Me.DtpHzrqEnd, 0)
        Me.Controls.SetChildIndex(Me.LblhzrqEnd, 0)
        Me.Controls.SetChildIndex(Me.CheckBox1, 0)
        Me.Controls.SetChildIndex(Me.CheckBox2, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents LblhzrqEnd As System.Windows.Forms.Label
    Public WithEvents DtpHzrqEnd As System.Windows.Forms.DateTimePicker
    Public WithEvents LblhzrqBegin As System.Windows.Forms.Label
    Public WithEvents DtpHzrqBegin As System.Windows.Forms.DateTimePicker
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As CheckBox
End Class
