<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGlPzXm
    Inherits models.FrmDlgPortrait

    '������д�ͷţ�����������б�
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows ����������������
    Private components As System.ComponentModel.IContainer

    'ע��: ���¹����� Windows ����������������
    '����ʹ�� Windows ����������޸�����
    '��Ҫʹ�ô���༭���޸�����
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TxtXmdm = New System.Windows.Forms.TextBox
        Me.LblXmdm = New System.Windows.Forms.Label
        Me.TxtXmmc = New System.Windows.Forms.TextBox
        Me.LblXmmc = New System.Windows.Forms.Label
        Me.DlgPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(133, 122)
        Me.DlgPanel.TabIndex = 4
        '
        'TxtXmdm
        '
        Me.TxtXmdm.Font = New System.Drawing.Font("����", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtXmdm.Location = New System.Drawing.Point(140, 28)
        Me.TxtXmdm.Name = "TxtXmdm"
        Me.TxtXmdm.Size = New System.Drawing.Size(104, 26)
        Me.TxtXmdm.TabIndex = 1
        '
        'LblXmdm
        '
        Me.LblXmdm.AutoSize = True
        Me.LblXmdm.Font = New System.Drawing.Font("����", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblXmdm.Location = New System.Drawing.Point(45, 31)
        Me.LblXmdm.Name = "LblXmdm"
        Me.LblXmdm.Size = New System.Drawing.Size(88, 16)
        Me.LblXmdm.TabIndex = 0
        Me.LblXmdm.Text = "��Ŀ���룺"
        '
        'TxtXmmc
        '
        Me.TxtXmmc.Font = New System.Drawing.Font("����", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtXmmc.Location = New System.Drawing.Point(140, 69)
        Me.TxtXmmc.Name = "TxtXmmc"
        Me.TxtXmmc.ReadOnly = True
        Me.TxtXmmc.Size = New System.Drawing.Size(201, 26)
        Me.TxtXmmc.TabIndex = 3
        Me.TxtXmmc.TabStop = False
        '
        'LblXmmc
        '
        Me.LblXmmc.AutoSize = True
        Me.LblXmmc.Font = New System.Drawing.Font("����", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblXmmc.Location = New System.Drawing.Point(45, 72)
        Me.LblXmmc.Name = "LblXmmc"
        Me.LblXmmc.Size = New System.Drawing.Size(88, 16)
        Me.LblXmmc.TabIndex = 2
        Me.LblXmmc.Text = "��Ŀ���ƣ�"
        '
        'FrmGlPzXm
        '
        Me.ClientSize = New System.Drawing.Size(386, 165)
        Me.Controls.Add(Me.TxtXmmc)
        Me.Controls.Add(Me.LblXmmc)
        Me.Controls.Add(Me.TxtXmdm)
        Me.Controls.Add(Me.LblXmdm)
        Me.Name = "FrmGlPzXm"
        Me.Text = "ѡ����Ŀ"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.LblXmdm, 0)
        Me.Controls.SetChildIndex(Me.TxtXmdm, 0)
        Me.Controls.SetChildIndex(Me.LblXmmc, 0)
        Me.Controls.SetChildIndex(Me.TxtXmmc, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtXmdm As System.Windows.Forms.TextBox
    Friend WithEvents LblXmdm As System.Windows.Forms.Label
    Friend WithEvents TxtXmmc As System.Windows.Forms.TextBox
    Friend WithEvents LblXmmc As System.Windows.Forms.Label

End Class
