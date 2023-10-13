<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGlZlfxHzz
    Inherits models.FrmReportView

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
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DgtbcKhdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcKhmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcZydm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcZymc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSkqx = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcQmye = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJe01 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJe02 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJe03 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJe04 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJe05 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJe06 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJe07 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcDqje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcYqje = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcByjf = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcBydf = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcLjjf = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcLjdf = New System.Windows.Forms.DataGridTextBoxColumn
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'rcDataGrid
        '
        Me.rcDataGrid.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(408, 8)
        Me.Label1.Size = New System.Drawing.Size(164, 23)
        Me.Label1.Text = "汇总账龄分析表"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.rcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcKhdm, Me.DgtbcKhmc, Me.DgtbcZydm, Me.DgtbcZymc, Me.DgtbcSkqx, Me.DgtbcQmye, Me.DgtbcJe01, Me.DgtbcJe02, Me.DgtbcJe03, Me.DgtbcJe04, Me.DgtbcJe05, Me.DgtbcJe06, Me.DgtbcJe07, Me.DgtbcDqje, Me.DgtbcYqje, Me.DgtbcByjf, Me.DgtbcBydf, Me.DgtbcLjjf, Me.DgtbcLjdf})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "glzlfx"
        '
        'DgtbcKhdm
        '
        Me.DgtbcKhdm.Format = ""
        Me.DgtbcKhdm.FormatInfo = Nothing
        Me.DgtbcKhdm.HeaderText = "客户编码"
        Me.DgtbcKhdm.MappingName = "khdm"
        Me.DgtbcKhdm.NullText = ""
        Me.DgtbcKhdm.Width = 75
        '
        'DgtbcKhmc
        '
        Me.DgtbcKhmc.Format = ""
        Me.DgtbcKhmc.FormatInfo = Nothing
        Me.DgtbcKhmc.HeaderText = "客户名称"
        Me.DgtbcKhmc.MappingName = "khmc"
        Me.DgtbcKhmc.NullText = ""
        Me.DgtbcKhmc.Width = 250
        '
        'DgtbcZydm
        '
        Me.DgtbcZydm.Format = ""
        Me.DgtbcZydm.FormatInfo = Nothing
        Me.DgtbcZydm.HeaderText = "职员编码"
        Me.DgtbcZydm.MappingName = "zydm"
        Me.DgtbcZydm.NullText = ""
        Me.DgtbcZydm.Width = 75
        '
        'DgtbcZymc
        '
        Me.DgtbcZymc.Format = ""
        Me.DgtbcZymc.FormatInfo = Nothing
        Me.DgtbcZymc.HeaderText = "职员姓名"
        Me.DgtbcZymc.MappingName = "zymc"
        Me.DgtbcZymc.NullText = ""
        Me.DgtbcZymc.Width = 75
        '
        'DgtbcSkqx
        '
        Me.DgtbcSkqx.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSkqx.Format = ""
        Me.DgtbcSkqx.FormatInfo = Nothing
        Me.DgtbcSkqx.HeaderText = "收款期限"
        Me.DgtbcSkqx.MappingName = "skqx"
        Me.DgtbcSkqx.NullText = ""
        Me.DgtbcSkqx.Width = 45
        '
        'DgtbcQmye
        '
        Me.DgtbcQmye.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcQmye.Format = ""
        Me.DgtbcQmye.FormatInfo = Nothing
        Me.DgtbcQmye.HeaderText = "期末余额"
        Me.DgtbcQmye.MappingName = "qmye"
        Me.DgtbcQmye.NullText = ""
        Me.DgtbcQmye.Width = 75
        '
        'DgtbcJe01
        '
        Me.DgtbcJe01.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcJe01.Format = ""
        Me.DgtbcJe01.FormatInfo = Nothing
        Me.DgtbcJe01.HeaderText = "一个月"
        Me.DgtbcJe01.MappingName = "je01"
        Me.DgtbcJe01.NullText = ""
        Me.DgtbcJe01.Width = 75
        '
        'DgtbcJe02
        '
        Me.DgtbcJe02.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcJe02.Format = ""
        Me.DgtbcJe02.FormatInfo = Nothing
        Me.DgtbcJe02.HeaderText = "二个月"
        Me.DgtbcJe02.MappingName = "je02"
        Me.DgtbcJe02.NullText = ""
        Me.DgtbcJe02.Width = 75
        '
        'DgtbcJe03
        '
        Me.DgtbcJe03.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcJe03.Format = ""
        Me.DgtbcJe03.FormatInfo = Nothing
        Me.DgtbcJe03.HeaderText = "三个月"
        Me.DgtbcJe03.MappingName = "je03"
        Me.DgtbcJe03.NullText = ""
        Me.DgtbcJe03.Width = 75
        '
        'DgtbcJe04
        '
        Me.DgtbcJe04.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcJe04.Format = ""
        Me.DgtbcJe04.FormatInfo = Nothing
        Me.DgtbcJe04.HeaderText = "四个月"
        Me.DgtbcJe04.MappingName = "je04"
        Me.DgtbcJe04.NullText = ""
        Me.DgtbcJe04.Width = 75
        '
        'DgtbcJe05
        '
        Me.DgtbcJe05.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcJe05.Format = ""
        Me.DgtbcJe05.FormatInfo = Nothing
        Me.DgtbcJe05.HeaderText = "五个月"
        Me.DgtbcJe05.MappingName = "je05"
        Me.DgtbcJe05.NullText = ""
        Me.DgtbcJe05.Width = 75
        '
        'DgtbcJe06
        '
        Me.DgtbcJe06.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcJe06.Format = ""
        Me.DgtbcJe06.FormatInfo = Nothing
        Me.DgtbcJe06.HeaderText = "六个月"
        Me.DgtbcJe06.MappingName = "je06"
        Me.DgtbcJe06.NullText = ""
        Me.DgtbcJe06.Width = 75
        '
        'DgtbcJe07
        '
        Me.DgtbcJe07.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcJe07.Format = ""
        Me.DgtbcJe07.FormatInfo = Nothing
        Me.DgtbcJe07.HeaderText = "六个月以上"
        Me.DgtbcJe07.MappingName = "je07"
        Me.DgtbcJe07.NullText = ""
        Me.DgtbcJe07.Width = 75
        '
        'DgtbcDqje
        '
        Me.DgtbcDqje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcDqje.Format = ""
        Me.DgtbcDqje.FormatInfo = Nothing
        Me.DgtbcDqje.HeaderText = "到期金额"
        Me.DgtbcDqje.MappingName = "dqje"
        Me.DgtbcDqje.NullText = ""
        Me.DgtbcDqje.Width = 75
        '
        'DgtbcYqje
        '
        Me.DgtbcYqje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcYqje.Format = ""
        Me.DgtbcYqje.FormatInfo = Nothing
        Me.DgtbcYqje.HeaderText = "逾期金额"
        Me.DgtbcYqje.MappingName = "yqje"
        Me.DgtbcYqje.NullText = ""
        Me.DgtbcYqje.Width = 75
        '
        'DgtbcByjf
        '
        Me.DgtbcByjf.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcByjf.Format = ""
        Me.DgtbcByjf.FormatInfo = Nothing
        Me.DgtbcByjf.HeaderText = "本月发出"
        Me.DgtbcByjf.MappingName = "byjf"
        Me.DgtbcByjf.NullText = ""
        Me.DgtbcByjf.Width = 75
        '
        'DgtbcBydf
        '
        Me.DgtbcBydf.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcBydf.Format = ""
        Me.DgtbcBydf.FormatInfo = Nothing
        Me.DgtbcBydf.HeaderText = "本月收款"
        Me.DgtbcBydf.MappingName = "bydf"
        Me.DgtbcBydf.NullText = ""
        Me.DgtbcBydf.Width = 75
        '
        'DgtbcLjjf
        '
        Me.DgtbcLjjf.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcLjjf.Format = ""
        Me.DgtbcLjjf.FormatInfo = Nothing
        Me.DgtbcLjjf.HeaderText = "累计发出"
        Me.DgtbcLjjf.MappingName = "ljjf"
        Me.DgtbcLjjf.NullText = ""
        Me.DgtbcLjjf.Width = 75
        '
        'DgtbcLjdf
        '
        Me.DgtbcLjdf.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcLjdf.Format = ""
        Me.DgtbcLjdf.FormatInfo = Nothing
        Me.DgtbcLjdf.HeaderText = "累计收款"
        Me.DgtbcLjdf.MappingName = "ljdf"
        Me.DgtbcLjdf.NullText = ""
        Me.DgtbcLjdf.Width = 75
        '
        'FrmGlZlfxHzz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmGlZlfxHzz"
        Me.Text = "汇总账龄分析表"
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DgtbcKhdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcKhmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSkqx As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcQmye As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJe01 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJe02 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJe03 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJe04 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJe05 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJe06 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJe07 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcByjf As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBydf As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcLjjf As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcLjdf As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDqje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcYqje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZydm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZymc As System.Windows.Forms.DataGridTextBoxColumn
End Class
