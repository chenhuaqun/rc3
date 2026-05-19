<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUpdateDB
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
        Me.TxtSql = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtPath = New System.Windows.Forms.TextBox
        Me.BtnFbd = New System.Windows.Forms.Button
        Me.rcFolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblMsg = New System.Windows.Forms.Label
        Me.DlgPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(492, 405)
        '
        'TxtSql
        '
        Me.TxtSql.Location = New System.Drawing.Point(14, 92)
        Me.TxtSql.Multiline = True
        Me.TxtSql.Name = "TxtSql"
        Me.TxtSql.ReadOnly = True
        Me.TxtSql.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxtSql.Size = New System.Drawing.Size(716, 289)
        Me.TxtSql.TabIndex = 102
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 12)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = "脚本文件的路径："
        '
        'TxtPath
        '
        Me.TxtPath.Location = New System.Drawing.Point(119, 26)
        Me.TxtPath.Name = "TxtPath"
        Me.TxtPath.ReadOnly = True
        Me.TxtPath.Size = New System.Drawing.Size(389, 21)
        Me.TxtPath.TabIndex = 104
        '
        'BtnFbd
        '
        Me.BtnFbd.Location = New System.Drawing.Point(539, 25)
        Me.BtnFbd.Name = "BtnFbd"
        Me.BtnFbd.Size = New System.Drawing.Size(146, 23)
        Me.BtnFbd.TabIndex = 105
        Me.BtnFbd.Text = "选择脚本文件的路径"
        Me.BtnFbd.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(43, 405)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(202, 22)
        Me.Label2.TabIndex = 106
        Me.Label2.Text = "切记先备份数据，再升级。"
        '
        'LblMsg
        '
        Me.LblMsg.AutoSize = True
        Me.LblMsg.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblMsg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblMsg.Location = New System.Drawing.Point(20, 58)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(186, 22)
        Me.LblMsg.TabIndex = 107
        Me.LblMsg.Text = "正在执行的脚本文件是："
        '
        'FrmUpdateDB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(745, 448)
        Me.Controls.Add(Me.LblMsg)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtPath)
        Me.Controls.Add(Me.BtnFbd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtSql)
        Me.Name = "FrmUpdateDB"
        Me.Text = "升级RC3数据"
        Me.Controls.SetChildIndex(Me.TxtSql, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.BtnFbd, 0)
        Me.Controls.SetChildIndex(Me.TxtPath, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.LblMsg, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtSql As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtPath As System.Windows.Forms.TextBox
    Friend WithEvents BtnFbd As System.Windows.Forms.Button
    Friend WithEvents rcFolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblMsg As System.Windows.Forms.Label
End Class
