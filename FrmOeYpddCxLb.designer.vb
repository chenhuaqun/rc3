<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOeYpddCxLb
    Inherits models.FrmRepView

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
        Me.rcDataGridTableStyle = New System.Windows.Forms.DataGridTableStyle
        Me.Panel1.SuspendLayout()
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblTitle
        '
        Me.LblTitle.Location = New System.Drawing.Point(419, 8)
        Me.LblTitle.Size = New System.Drawing.Size(142, 23)
        Me.LblTitle.Text = "��Ʒ������ѯ"
        '
        'rcDataGridTableStyle
        '
        Me.rcDataGridTableStyle.DataGrid = Nothing
        Me.rcDataGridTableStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText
        '
        'FrmOeYpddCxLb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmOeYpddCxLb"
        Me.Text = "��Ʒ������ѯ"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rcDataGridTableStyle As System.Windows.Forms.DataGridTableStyle

End Class
