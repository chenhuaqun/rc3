<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRoles
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
        Me.rcDataGridView = New System.Windows.Forms.DataGridView
        Me.ColRoleId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RoleName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColRolesm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BtnEdit = New System.Windows.Forms.Button
        Me.BtnExit = New System.Windows.Forms.Button
        Me.BtnHelp = New System.Windows.Forms.Button
        Me.BtnDel = New System.Windows.Forms.Button
        Me.BtnNew = New System.Windows.Forms.Button
        Me.BtnQx = New System.Windows.Forms.Button
        Me.BtnExport = New System.Windows.Forms.Button
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rcDataGridView
        '
        Me.rcDataGridView.AllowUserToAddRows = False
        Me.rcDataGridView.AllowUserToDeleteRows = False
        Me.rcDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.rcDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColRoleId, Me.RoleName, Me.ColRolesm})
        Me.rcDataGridView.Location = New System.Drawing.Point(12, 12)
        Me.rcDataGridView.Name = "rcDataGridView"
        Me.rcDataGridView.ReadOnly = True
        Me.rcDataGridView.RowTemplate.Height = 23
        Me.rcDataGridView.Size = New System.Drawing.Size(339, 397)
        Me.rcDataGridView.TabIndex = 0
        '
        'ColRoleId
        '
        Me.ColRoleId.DataPropertyName = "roleid"
        Me.ColRoleId.HeaderText = "角色编码"
        Me.ColRoleId.Name = "ColRoleId"
        Me.ColRoleId.ReadOnly = True
        Me.ColRoleId.Width = 80
        '
        'RoleName
        '
        Me.RoleName.DataPropertyName = "rolename"
        Me.RoleName.HeaderText = "角色名称"
        Me.RoleName.Name = "RoleName"
        Me.RoleName.ReadOnly = True
        Me.RoleName.Width = 135
        '
        'ColRolesm
        '
        Me.ColRolesm.DataPropertyName = "rolesm"
        Me.ColRolesm.HeaderText = "记忆码"
        Me.ColRolesm.Name = "ColRolesm"
        Me.ColRolesm.ReadOnly = True
        Me.ColRolesm.Width = 75
        '
        'BtnEdit
        '
        Me.BtnEdit.Location = New System.Drawing.Point(357, 41)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(75, 23)
        Me.BtnEdit.TabIndex = 2
        Me.BtnEdit.Text = "修改(&E)"
        '
        'BtnExit
        '
        Me.BtnExit.Location = New System.Drawing.Point(357, 186)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 23)
        Me.BtnExit.TabIndex = 7
        Me.BtnExit.Text = "退出(&X)"
        '
        'BtnHelp
        '
        Me.BtnHelp.Location = New System.Drawing.Point(357, 157)
        Me.BtnHelp.Name = "BtnHelp"
        Me.BtnHelp.Size = New System.Drawing.Size(75, 23)
        Me.BtnHelp.TabIndex = 6
        Me.BtnHelp.Text = "帮助(&H)"
        '
        'BtnDel
        '
        Me.BtnDel.Location = New System.Drawing.Point(357, 70)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(75, 23)
        Me.BtnDel.TabIndex = 3
        Me.BtnDel.Text = "删除(&D)"
        '
        'BtnNew
        '
        Me.BtnNew.Location = New System.Drawing.Point(357, 12)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(75, 23)
        Me.BtnNew.TabIndex = 1
        Me.BtnNew.Text = "增加(&A)"
        '
        'BtnQx
        '
        Me.BtnQx.Location = New System.Drawing.Point(357, 99)
        Me.BtnQx.Name = "BtnQx"
        Me.BtnQx.Size = New System.Drawing.Size(75, 23)
        Me.BtnQx.TabIndex = 4
        Me.BtnQx.Text = "权限(&V)"
        '
        'BtnExport
        '
        Me.BtnExport.Location = New System.Drawing.Point(357, 128)
        Me.BtnExport.Name = "BtnExport"
        Me.BtnExport.Size = New System.Drawing.Size(75, 23)
        Me.BtnExport.TabIndex = 5
        Me.BtnExport.Text = "输出"
        '
        'FrmRoles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(444, 421)
        Me.Controls.Add(Me.BtnExport)
        Me.Controls.Add(Me.BtnQx)
        Me.Controls.Add(Me.BtnEdit)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.BtnHelp)
        Me.Controls.Add(Me.BtnDel)
        Me.Controls.Add(Me.BtnNew)
        Me.Controls.Add(Me.rcDataGridView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRoles"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "用户角色"
        CType(Me.rcDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rcDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents BtnEdit As System.Windows.Forms.Button
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents BtnHelp As System.Windows.Forms.Button
    Friend WithEvents BtnDel As System.Windows.Forms.Button
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents ColRoleId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RoleName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRolesm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnQx As System.Windows.Forms.Button
    Friend WithEvents BtnExport As System.Windows.Forms.Button
End Class
