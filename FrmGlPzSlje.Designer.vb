<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGlPzSlje
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
        Me.TxtSl = New System.Windows.Forms.TextBox
        Me.LblXmdm = New System.Windows.Forms.Label
        Me.TxtDj = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtJe = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtDw = New System.Windows.Forms.TextBox
        Me.LblDw = New System.Windows.Forms.Label
        Me.CmbJd = New System.Windows.Forms.ComboBox
        Me.LblJd = New System.Windows.Forms.Label
        Me.DlgPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(41, 222)
        Me.DlgPanel.TabIndex = 10
        '
        'TxtSl
        '
        Me.TxtSl.Font = New System.Drawing.Font("����", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtSl.Location = New System.Drawing.Point(149, 97)
        Me.TxtSl.Name = "TxtSl"
        Me.TxtSl.Size = New System.Drawing.Size(104, 26)
        Me.TxtSl.TabIndex = 5
        Me.TxtSl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblXmdm
        '
        Me.LblXmdm.AutoSize = True
        Me.LblXmdm.Font = New System.Drawing.Font("����", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblXmdm.Location = New System.Drawing.Point(44, 100)
        Me.LblXmdm.Name = "LblXmdm"
        Me.LblXmdm.Size = New System.Drawing.Size(88, 16)
        Me.LblXmdm.TabIndex = 4
        Me.LblXmdm.Text = "��    ����"
        '
        'TxtDj
        '
        Me.TxtDj.Font = New System.Drawing.Font("����", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtDj.Location = New System.Drawing.Point(149, 129)
        Me.TxtDj.Name = "TxtDj"
        Me.TxtDj.Size = New System.Drawing.Size(104, 26)
        Me.TxtDj.TabIndex = 7
        Me.TxtDj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("����", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(44, 132)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "��    �ۣ�"
        '
        'TxtJe
        '
        Me.TxtJe.Font = New System.Drawing.Font("����", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtJe.Location = New System.Drawing.Point(149, 162)
        Me.TxtJe.Name = "TxtJe"
        Me.TxtJe.Size = New System.Drawing.Size(104, 26)
        Me.TxtJe.TabIndex = 9
        Me.TxtJe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("����", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(44, 165)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "��    �"
        '
        'TxtDw
        '
        Me.TxtDw.Font = New System.Drawing.Font("����", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtDw.Location = New System.Drawing.Point(149, 31)
        Me.TxtDw.Name = "TxtDw"
        Me.TxtDw.ReadOnly = True
        Me.TxtDw.Size = New System.Drawing.Size(104, 26)
        Me.TxtDw.TabIndex = 1
        '
        'LblDw
        '
        Me.LblDw.AutoSize = True
        Me.LblDw.Font = New System.Drawing.Font("����", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblDw.Location = New System.Drawing.Point(44, 34)
        Me.LblDw.Name = "LblDw"
        Me.LblDw.Size = New System.Drawing.Size(88, 16)
        Me.LblDw.TabIndex = 0
        Me.LblDw.Text = "��    λ��"
        '
        'CmbJd
        '
        Me.CmbJd.DisplayMember = "��"
        Me.CmbJd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbJd.Font = New System.Drawing.Font("����", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CmbJd.FormattingEnabled = True
        Me.CmbJd.Items.AddRange(New Object() {"��", "��"})
        Me.CmbJd.Location = New System.Drawing.Point(149, 63)
        Me.CmbJd.Name = "CmbJd"
        Me.CmbJd.Size = New System.Drawing.Size(104, 24)
        Me.CmbJd.TabIndex = 3
        Me.CmbJd.ValueMember = "��"
        '
        'LblJd
        '
        Me.LblJd.AutoSize = True
        Me.LblJd.Font = New System.Drawing.Font("����", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblJd.Location = New System.Drawing.Point(44, 66)
        Me.LblJd.Name = "LblJd"
        Me.LblJd.Size = New System.Drawing.Size(88, 16)
        Me.LblJd.TabIndex = 2
        Me.LblJd.Text = "�������"
        '
        'FrmGlPzSlje
        '
        Me.ClientSize = New System.Drawing.Size(294, 265)
        Me.Controls.Add(Me.CmbJd)
        Me.Controls.Add(Me.LblJd)
        Me.Controls.Add(Me.TxtDw)
        Me.Controls.Add(Me.LblDw)
        Me.Controls.Add(Me.TxtJe)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtDj)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtSl)
        Me.Controls.Add(Me.LblXmdm)
        Me.Name = "FrmGlPzSlje"
        Me.Text = "����*����=���"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.LblXmdm, 0)
        Me.Controls.SetChildIndex(Me.TxtSl, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.TxtDj, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.TxtJe, 0)
        Me.Controls.SetChildIndex(Me.LblDw, 0)
        Me.Controls.SetChildIndex(Me.TxtDw, 0)
        Me.Controls.SetChildIndex(Me.LblJd, 0)
        Me.Controls.SetChildIndex(Me.CmbJd, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtSl As System.Windows.Forms.TextBox
    Friend WithEvents LblXmdm As System.Windows.Forms.Label
    Friend WithEvents TxtDj As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtJe As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtDw As System.Windows.Forms.TextBox
    Friend WithEvents LblDw As System.Windows.Forms.Label
    Friend WithEvents CmbJd As System.Windows.Forms.ComboBox
    Friend WithEvents LblJd As System.Windows.Forms.Label

End Class
