﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmKcZlxx
    Inherits System.Windows.Forms.Form

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
        Me.rcDataGrid = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DgtbcFadm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcFamc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcFasm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.BtnExport = New System.Windows.Forms.Button
        Me.BtnEdit = New System.Windows.Forms.Button
        Me.BtnExit = New System.Windows.Forms.Button
        Me.BtnHelp = New System.Windows.Forms.Button
        Me.BtnQx = New System.Windows.Forms.Button
        Me.BtnDel = New System.Windows.Forms.Button
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        CType(Me.rcDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'rcDataGrid
        '
        Me.rcDataGrid.CaptionVisible = False
        Me.rcDataGrid.DataMember = ""
        Me.rcDataGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rcDataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.rcDataGrid.Location = New System.Drawing.Point(0, 0)
        Me.rcDataGrid.Name = "rcDataGrid"
        Me.rcDataGrid.ReadOnly = True
        Me.rcDataGrid.Size = New System.Drawing.Size(410, 447)
        Me.rcDataGrid.TabIndex = 1
        Me.rcDataGrid.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.rcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcFadm, Me.DgtbcFamc, Me.DgtbcFasm})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "rc_kczlfa"
        Me.DataGridTableStyle1.ReadOnly = True
        '
        'DgtbcFadm
        '
        Me.DgtbcFadm.Format = ""
        Me.DgtbcFadm.FormatInfo = Nothing
        Me.DgtbcFadm.HeaderText = "方案编码"
        Me.DgtbcFadm.MappingName = "fadm"
        Me.DgtbcFadm.NullText = ""
        Me.DgtbcFadm.ReadOnly = True
        Me.DgtbcFadm.Width = 120
        '
        'DgtbcFamc
        '
        Me.DgtbcFamc.Format = ""
        Me.DgtbcFamc.FormatInfo = Nothing
        Me.DgtbcFamc.HeaderText = "方案名称"
        Me.DgtbcFamc.MappingName = "famc"
        Me.DgtbcFamc.NullText = ""
        Me.DgtbcFamc.Width = 120
        '
        'DgtbcFasm
        '
        Me.DgtbcFasm.Format = ""
        Me.DgtbcFasm.FormatInfo = Nothing
        Me.DgtbcFasm.HeaderText = "记忆码"
        Me.DgtbcFasm.MappingName = "fasm"
        Me.DgtbcFasm.NullText = ""
        Me.DgtbcFasm.Width = 75
        '
        'BtnExport
        '
        Me.BtnExport.Location = New System.Drawing.Point(19, 134)
        Me.BtnExport.Name = "BtnExport"
        Me.BtnExport.Size = New System.Drawing.Size(75, 23)
        Me.BtnExport.TabIndex = 12
        Me.BtnExport.Text = "输出"
        '
        'BtnEdit
        '
        Me.BtnEdit.Location = New System.Drawing.Point(19, 76)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(75, 23)
        Me.BtnEdit.TabIndex = 10
        Me.BtnEdit.Text = "修改(&E)"
        '
        'BtnExit
        '
        Me.BtnExit.Location = New System.Drawing.Point(19, 192)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 23)
        Me.BtnExit.TabIndex = 14
        Me.BtnExit.Text = "退出(&X)"
        '
        'BtnHelp
        '
        Me.BtnHelp.Location = New System.Drawing.Point(19, 163)
        Me.BtnHelp.Name = "BtnHelp"
        Me.BtnHelp.Size = New System.Drawing.Size(75, 23)
        Me.BtnHelp.TabIndex = 13
        Me.BtnHelp.Text = "帮助(&H)"
        '
        'BtnQx
        '
        Me.BtnQx.Location = New System.Drawing.Point(19, 105)
        Me.BtnQx.Name = "BtnQx"
        Me.BtnQx.Size = New System.Drawing.Size(75, 23)
        Me.BtnQx.TabIndex = 11
        Me.BtnQx.Text = "账龄分段"
        '
        'BtnDel
        '
        Me.BtnDel.Location = New System.Drawing.Point(19, 47)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(75, 23)
        Me.BtnDel.TabIndex = 9
        Me.BtnDel.Text = "删除(&D)"
        '
        'BtnAdd
        '
        Me.BtnAdd.Location = New System.Drawing.Point(19, 18)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(75, 23)
        Me.BtnAdd.TabIndex = 8
        Me.BtnAdd.Text = "增加(&A)"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnAdd)
        Me.Panel1.Controls.Add(Me.BtnExport)
        Me.Panel1.Controls.Add(Me.BtnDel)
        Me.Panel1.Controls.Add(Me.BtnEdit)
        Me.Panel1.Controls.Add(Me.BtnQx)
        Me.Panel1.Controls.Add(Me.BtnExit)
        Me.Panel1.Controls.Add(Me.BtnHelp)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(410, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(112, 447)
        Me.Panel1.TabIndex = 15
        '
        'FrmKcZlxx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(522, 447)
        Me.Controls.Add(Me.rcDataGrid)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmKcZlxx"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "库存账龄信息设置"
        CType(Me.rcDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rcDataGrid As System.Windows.Forms.DataGrid
    Friend WithEvents BtnExport As System.Windows.Forms.Button
    Friend WithEvents BtnEdit As System.Windows.Forms.Button
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents BtnHelp As System.Windows.Forms.Button
    Friend WithEvents BtnQx As System.Windows.Forms.Button
    Friend WithEvents BtnDel As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DgtbcFadm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcFamc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcFasm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
