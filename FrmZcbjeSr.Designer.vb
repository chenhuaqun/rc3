﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmZcbjeSr
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NudMonth = New System.Windows.Forms.NumericUpDown()
        Me.NudYear = New System.Windows.Forms.NumericUpDown()
        Me.DlgPanel.SuspendLayout()
        CType(Me.NudMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudYear, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.DlgPanel.Location = New System.Drawing.Point(129, 141)
        Me.DlgPanel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DlgPanel.Size = New System.Drawing.Size(363, 46)
        Me.DlgPanel.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(50, 58)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "日    期："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(422, 58)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 24)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "月"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(302, 58)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 24)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "年"
        '
        'NudMonth
        '
        Me.NudMonth.Enabled = False
        Me.NudMonth.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NudMonth.Location = New System.Drawing.Point(350, 51)
        Me.NudMonth.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.NudMonth.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NudMonth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudMonth.Name = "NudMonth"
        Me.NudMonth.Size = New System.Drawing.Size(60, 35)
        Me.NudMonth.TabIndex = 3
        Me.NudMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudMonth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NudYear
        '
        Me.NudYear.Enabled = False
        Me.NudYear.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NudYear.Location = New System.Drawing.Point(194, 51)
        Me.NudYear.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.NudYear.Maximum = New Decimal(New Integer() {2050, 0, 0, 0})
        Me.NudYear.Minimum = New Decimal(New Integer() {1990, 0, 0, 0})
        Me.NudYear.Name = "NudYear"
        Me.NudYear.Size = New System.Drawing.Size(96, 35)
        Me.NudYear.TabIndex = 1
        Me.NudYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudYear.Value = New Decimal(New Integer() {1990, 0, 0, 0})
        '
        'FrmZcbjeSr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(508, 206)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NudMonth)
        Me.Controls.Add(Me.NudYear)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FrmZcbjeSr"
        Me.Text = "输入年月"
        Me.TopMost = True
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.NudYear, 0)
        Me.Controls.SetChildIndex(Me.NudMonth, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.DlgPanel.ResumeLayout(False)
        CType(Me.NudMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NudMonth As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudYear As System.Windows.Forms.NumericUpDown
End Class
