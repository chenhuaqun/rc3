<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImpU8
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
        Me.ChbKcqcye = New System.Windows.Forms.CheckBox()
        Me.ChbInvRkd2 = New System.Windows.Forms.CheckBox()
        Me.ChbQtrk = New System.Windows.Forms.CheckBox()
        Me.ChbQtck = New System.Windows.Forms.CheckBox()
        Me.ChbCpdm = New System.Windows.Forms.CheckBox()
        Me.ChbInvCkd = New System.Windows.Forms.CheckBox()
        Me.ChbPoRkd = New System.Windows.Forms.CheckBox()
        Me.ChbInvDbd = New System.Windows.Forms.CheckBox()
        Me.ChbOeXsd = New System.Windows.Forms.CheckBox()
        Me.ChbInvRkd1 = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NudMonth = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NudYear = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
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
        Me.DlgPanel.Location = New System.Drawing.Point(276, 278)
        '
        'ChbKcqcye
        '
        Me.ChbKcqcye.AutoSize = True
        Me.ChbKcqcye.Location = New System.Drawing.Point(138, 93)
        Me.ChbKcqcye.Name = "ChbKcqcye"
        Me.ChbKcqcye.Size = New System.Drawing.Size(96, 16)
        Me.ChbKcqcye.TabIndex = 102
        Me.ChbKcqcye.Text = "库存期初余额"
        Me.ChbKcqcye.UseVisualStyleBackColor = True
        '
        'ChbInvRkd2
        '
        Me.ChbInvRkd2.AutoSize = True
        Me.ChbInvRkd2.Location = New System.Drawing.Point(138, 199)
        Me.ChbInvRkd2.Name = "ChbInvRkd2"
        Me.ChbInvRkd2.Size = New System.Drawing.Size(132, 16)
        Me.ChbInvRkd2.TabIndex = 105
        Me.ChbInvRkd2.Text = "委外加工入库(WWRK)"
        Me.ChbInvRkd2.UseVisualStyleBackColor = True
        '
        'ChbQtrk
        '
        Me.ChbQtrk.AutoSize = True
        Me.ChbQtrk.Location = New System.Drawing.Point(281, 200)
        Me.ChbQtrk.Name = "ChbQtrk"
        Me.ChbQtrk.Size = New System.Drawing.Size(108, 16)
        Me.ChbQtrk.TabIndex = 106
        Me.ChbQtrk.Text = "其它入库(RKTZ)"
        Me.ChbQtrk.UseVisualStyleBackColor = True
        '
        'ChbQtck
        '
        Me.ChbQtck.AutoSize = True
        Me.ChbQtck.Location = New System.Drawing.Point(406, 199)
        Me.ChbQtck.Name = "ChbQtck"
        Me.ChbQtck.Size = New System.Drawing.Size(108, 16)
        Me.ChbQtck.TabIndex = 110
        Me.ChbQtck.Text = "其它出库(CKTZ)"
        Me.ChbQtck.UseVisualStyleBackColor = True
        '
        'ChbCpdm
        '
        Me.ChbCpdm.AutoSize = True
        Me.ChbCpdm.Location = New System.Drawing.Point(26, 200)
        Me.ChbCpdm.Name = "ChbCpdm"
        Me.ChbCpdm.Size = New System.Drawing.Size(72, 16)
        Me.ChbCpdm.TabIndex = 111
        Me.ChbCpdm.Text = "物料信息"
        Me.ChbCpdm.UseVisualStyleBackColor = True
        '
        'ChbInvCkd
        '
        Me.ChbInvCkd.AutoSize = True
        Me.ChbInvCkd.Location = New System.Drawing.Point(26, 71)
        Me.ChbInvCkd.Name = "ChbInvCkd"
        Me.ChbInvCkd.Size = New System.Drawing.Size(108, 16)
        Me.ChbInvCkd.TabIndex = 107
        Me.ChbInvCkd.Text = "材料出库(LLCK)"
        Me.ChbInvCkd.UseVisualStyleBackColor = True
        '
        'ChbPoRkd
        '
        Me.ChbPoRkd.AutoSize = True
        Me.ChbPoRkd.Location = New System.Drawing.Point(26, 49)
        Me.ChbPoRkd.Name = "ChbPoRkd"
        Me.ChbPoRkd.Size = New System.Drawing.Size(108, 16)
        Me.ChbPoRkd.TabIndex = 103
        Me.ChbPoRkd.Text = "采购入库(CGRK)"
        Me.ChbPoRkd.UseVisualStyleBackColor = True
        '
        'ChbInvDbd
        '
        Me.ChbInvDbd.AutoSize = True
        Me.ChbInvDbd.Location = New System.Drawing.Point(262, 71)
        Me.ChbInvDbd.Name = "ChbInvDbd"
        Me.ChbInvDbd.Size = New System.Drawing.Size(108, 16)
        Me.ChbInvDbd.TabIndex = 109
        Me.ChbInvDbd.Text = "调拨出库(DBDJ)"
        Me.ChbInvDbd.UseVisualStyleBackColor = True
        '
        'ChbOeXsd
        '
        Me.ChbOeXsd.AutoSize = True
        Me.ChbOeXsd.Location = New System.Drawing.Point(138, 71)
        Me.ChbOeXsd.Name = "ChbOeXsd"
        Me.ChbOeXsd.Size = New System.Drawing.Size(108, 16)
        Me.ChbOeXsd.TabIndex = 108
        Me.ChbOeXsd.Text = "销售出库(XSCK)"
        Me.ChbOeXsd.UseVisualStyleBackColor = True
        '
        'ChbInvRkd1
        '
        Me.ChbInvRkd1.AutoSize = True
        Me.ChbInvRkd1.Location = New System.Drawing.Point(138, 49)
        Me.ChbInvRkd1.Name = "ChbInvRkd1"
        Me.ChbInvRkd1.Size = New System.Drawing.Size(120, 16)
        Me.ChbInvRkd1.TabIndex = 104
        Me.ChbInvRkd1.Text = "产成品入库(SCRK)"
        Me.ChbInvRkd1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(364, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 16)
        Me.Label3.TabIndex = 116
        Me.Label3.Text = "月"
        '
        'NudMonth
        '
        Me.NudMonth.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NudMonth.Location = New System.Drawing.Point(310, 12)
        Me.NudMonth.Maximum = New Decimal(New Integer() {13, 0, 0, 0})
        Me.NudMonth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudMonth.Name = "NudMonth"
        Me.NudMonth.Size = New System.Drawing.Size(45, 26)
        Me.NudMonth.TabIndex = 115
        Me.NudMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudMonth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(278, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 16)
        Me.Label2.TabIndex = 114
        Me.Label2.Text = "年"
        '
        'NudYear
        '
        Me.NudYear.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NudYear.Location = New System.Drawing.Point(212, 12)
        Me.NudYear.Maximum = New Decimal(New Integer() {2050, 0, 0, 0})
        Me.NudYear.Minimum = New Decimal(New Integer() {1951, 0, 0, 0})
        Me.NudYear.Name = "NudYear"
        Me.NudYear.Size = New System.Drawing.Size(59, 26)
        Me.NudYear.TabIndex = 113
        Me.NudYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudYear.Value = New Decimal(New Integer() {1999, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(116, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 16)
        Me.Label1.TabIndex = 112
        Me.Label1.Text = "会计期间："
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(26, 239)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(465, 23)
        Me.ProgressBar1.TabIndex = 117
        '
        'FrmImpU8
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 321)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.NudMonth)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NudYear)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ChbInvRkd2)
        Me.Controls.Add(Me.ChbQtrk)
        Me.Controls.Add(Me.ChbQtck)
        Me.Controls.Add(Me.ChbCpdm)
        Me.Controls.Add(Me.ChbInvCkd)
        Me.Controls.Add(Me.ChbPoRkd)
        Me.Controls.Add(Me.ChbInvDbd)
        Me.Controls.Add(Me.ChbOeXsd)
        Me.Controls.Add(Me.ChbInvRkd1)
        Me.Controls.Add(Me.ChbKcqcye)
        Me.Name = "FrmImpU8"
        Me.Text = "导入用友U8数据"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.ChbKcqcye, 0)
        Me.Controls.SetChildIndex(Me.ChbInvRkd1, 0)
        Me.Controls.SetChildIndex(Me.ChbOeXsd, 0)
        Me.Controls.SetChildIndex(Me.ChbInvDbd, 0)
        Me.Controls.SetChildIndex(Me.ChbPoRkd, 0)
        Me.Controls.SetChildIndex(Me.ChbInvCkd, 0)
        Me.Controls.SetChildIndex(Me.ChbCpdm, 0)
        Me.Controls.SetChildIndex(Me.ChbQtck, 0)
        Me.Controls.SetChildIndex(Me.ChbQtrk, 0)
        Me.Controls.SetChildIndex(Me.ChbInvRkd2, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.NudYear, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.NudMonth, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.ProgressBar1, 0)
        Me.DlgPanel.ResumeLayout(False)
        CType(Me.NudMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ChbKcqcye As CheckBox
    Friend WithEvents ChbInvRkd2 As CheckBox
    Friend WithEvents ChbQtrk As CheckBox
    Friend WithEvents ChbQtck As CheckBox
    Friend WithEvents ChbCpdm As CheckBox
    Friend WithEvents ChbInvCkd As CheckBox
    Friend WithEvents ChbPoRkd As CheckBox
    Friend WithEvents ChbInvDbd As CheckBox
    Friend WithEvents ChbOeXsd As CheckBox
    Friend WithEvents ChbInvRkd1 As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents NudMonth As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents NudYear As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
End Class
