<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmOeKhFpFxbz
    Inherits models.FrmReportView

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DgtbcKhLbdm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcKhLbmc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcKhdm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcKhmc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcZydm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcZymc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcCpLbdm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcCpLbmc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcBySl = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcSySl = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcSnSl = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcByFzsl = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcSyFzsl = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcSnFzsl = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcByJe = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcSyJe = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcSnJe = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcBySe = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcSySe = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcSnSe = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcByCbje = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcSyCbje = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcSnCbje = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcByMle = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcSyMle = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcSnMle = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcByMll = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcSyMll = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcSnMll = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcHbFzsl = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcTbFzsl = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcHbJe = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcTbJe = New System.Windows.Forms.DataGridTextBoxColumn()
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RcDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RcDataGrid
        '
        Me.RcDataGrid.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(363, 8)
        Me.Label1.Size = New System.Drawing.Size(254, 26)
        Me.Label1.Text = "客户销售发票对比分析表"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.RcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcKhLbdm, Me.DgtbcKhLbmc, Me.DgtbcKhdm, Me.DgtbcKhmc, Me.DgtbcZydm, Me.DgtbcZymc, Me.DgtbcCpLbdm, Me.DgtbcCpLbmc, Me.DgtbcBySl, Me.DgtbcSySl, Me.DgtbcSnSl, Me.DgtbcByFzsl, Me.DgtbcSyFzsl, Me.DgtbcSnFzsl, Me.DgtbcHbFzsl, Me.DgtbcTbFzsl, Me.DgtbcByJe, Me.DgtbcSyJe, Me.DgtbcSnJe, Me.DgtbcHbJe, Me.DgtbcTbJe, Me.DgtbcBySe, Me.DgtbcSySe, Me.DgtbcSnSe, Me.DgtbcByCbje, Me.DgtbcSyCbje, Me.DgtbcSnCbje, Me.DgtbcByMle, Me.DgtbcSyMle, Me.DgtbcSnMle, Me.DgtbcByMll, Me.DgtbcSyMll, Me.DgtbcSnMll})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "oekhfpfxb"
        '
        'DgtbcKhLbdm
        '
        Me.DgtbcKhLbdm.Format = ""
        Me.DgtbcKhLbdm.FormatInfo = Nothing
        Me.DgtbcKhLbdm.HeaderText = "客户类别编码"
        Me.DgtbcKhLbdm.MappingName = "khlbdm"
        Me.DgtbcKhLbdm.NullText = ""
        Me.DgtbcKhLbdm.Width = 75
        '
        'DgtbcKhLbmc
        '
        Me.DgtbcKhLbmc.Format = ""
        Me.DgtbcKhLbmc.FormatInfo = Nothing
        Me.DgtbcKhLbmc.HeaderText = "客户类别名称"
        Me.DgtbcKhLbmc.MappingName = "khlbmc"
        Me.DgtbcKhLbmc.NullText = ""
        Me.DgtbcKhLbmc.Width = 75
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
        Me.DgtbcKhmc.Width = 210
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
        'DgtbcCpLbdm
        '
        Me.DgtbcCpLbdm.Format = ""
        Me.DgtbcCpLbdm.FormatInfo = Nothing
        Me.DgtbcCpLbdm.HeaderText = "物料类别编码"
        Me.DgtbcCpLbdm.MappingName = "cplbdm"
        Me.DgtbcCpLbdm.NullText = ""
        Me.DgtbcCpLbdm.Width = 75
        '
        'DgtbcCpLbmc
        '
        Me.DgtbcCpLbmc.Format = ""
        Me.DgtbcCpLbmc.FormatInfo = Nothing
        Me.DgtbcCpLbmc.HeaderText = "物料类别名称"
        Me.DgtbcCpLbmc.MappingName = "cplbmc"
        Me.DgtbcCpLbmc.NullText = ""
        Me.DgtbcCpLbmc.Width = 75
        '
        'DgtbcBySl
        '
        Me.DgtbcBySl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcBySl.Format = ""
        Me.DgtbcBySl.FormatInfo = Nothing
        Me.DgtbcBySl.HeaderText = "本月数量"
        Me.DgtbcBySl.MappingName = "bysl"
        Me.DgtbcBySl.NullText = ""
        Me.DgtbcBySl.Width = 75
        '
        'DgtbcSySl
        '
        Me.DgtbcSySl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSySl.Format = ""
        Me.DgtbcSySl.FormatInfo = Nothing
        Me.DgtbcSySl.HeaderText = "上月数量"
        Me.DgtbcSySl.MappingName = "sysl"
        Me.DgtbcSySl.NullText = ""
        Me.DgtbcSySl.Width = 75
        '
        'DgtbcSnSl
        '
        Me.DgtbcSnSl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSnSl.Format = ""
        Me.DgtbcSnSl.FormatInfo = Nothing
        Me.DgtbcSnSl.HeaderText = "上年同期数量"
        Me.DgtbcSnSl.MappingName = "snsl"
        Me.DgtbcSnSl.NullText = ""
        Me.DgtbcSnSl.Width = 75
        '
        'DgtbcByFzsl
        '
        Me.DgtbcByFzsl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcByFzsl.Format = ""
        Me.DgtbcByFzsl.FormatInfo = Nothing
        Me.DgtbcByFzsl.HeaderText = "本月重量"
        Me.DgtbcByFzsl.MappingName = "byfzsl"
        Me.DgtbcByFzsl.NullText = ""
        Me.DgtbcByFzsl.Width = 75
        '
        'DgtbcSyFzsl
        '
        Me.DgtbcSyFzsl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSyFzsl.Format = ""
        Me.DgtbcSyFzsl.FormatInfo = Nothing
        Me.DgtbcSyFzsl.HeaderText = "上月重量"
        Me.DgtbcSyFzsl.MappingName = "syfzsl"
        Me.DgtbcSyFzsl.NullText = ""
        Me.DgtbcSyFzsl.Width = 75
        '
        'DgtbcSnFzsl
        '
        Me.DgtbcSnFzsl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSnFzsl.Format = ""
        Me.DgtbcSnFzsl.FormatInfo = Nothing
        Me.DgtbcSnFzsl.HeaderText = "上年同期重量"
        Me.DgtbcSnFzsl.MappingName = "snfzsl"
        Me.DgtbcSnFzsl.NullText = ""
        Me.DgtbcSnFzsl.Width = 75
        '
        'DgtbcByJe
        '
        Me.DgtbcByJe.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcByJe.Format = ""
        Me.DgtbcByJe.FormatInfo = Nothing
        Me.DgtbcByJe.HeaderText = "本月金额"
        Me.DgtbcByJe.MappingName = "byje"
        Me.DgtbcByJe.NullText = ""
        Me.DgtbcByJe.Width = 75
        '
        'DgtbcSyJe
        '
        Me.DgtbcSyJe.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSyJe.Format = ""
        Me.DgtbcSyJe.FormatInfo = Nothing
        Me.DgtbcSyJe.HeaderText = "上月金额"
        Me.DgtbcSyJe.MappingName = "syje"
        Me.DgtbcSyJe.NullText = ""
        Me.DgtbcSyJe.Width = 75
        '
        'DgtbcSnJe
        '
        Me.DgtbcSnJe.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSnJe.Format = ""
        Me.DgtbcSnJe.FormatInfo = Nothing
        Me.DgtbcSnJe.HeaderText = "上年同期金额"
        Me.DgtbcSnJe.MappingName = "snje"
        Me.DgtbcSnJe.NullText = ""
        Me.DgtbcSnJe.Width = 75
        '
        'DgtbcBySe
        '
        Me.DgtbcBySe.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcBySe.Format = ""
        Me.DgtbcBySe.FormatInfo = Nothing
        Me.DgtbcBySe.HeaderText = "本月税额"
        Me.DgtbcBySe.MappingName = "byse"
        Me.DgtbcBySe.NullText = ""
        Me.DgtbcBySe.Width = 75
        '
        'DgtbcSySe
        '
        Me.DgtbcSySe.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSySe.Format = ""
        Me.DgtbcSySe.FormatInfo = Nothing
        Me.DgtbcSySe.HeaderText = "上月税额"
        Me.DgtbcSySe.MappingName = "syse"
        Me.DgtbcSySe.NullText = ""
        Me.DgtbcSySe.Width = 75
        '
        'DgtbcSnSe
        '
        Me.DgtbcSnSe.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSnSe.Format = ""
        Me.DgtbcSnSe.FormatInfo = Nothing
        Me.DgtbcSnSe.HeaderText = "上年同期税额"
        Me.DgtbcSnSe.MappingName = "snse"
        Me.DgtbcSnSe.NullText = ""
        Me.DgtbcSnSe.Width = 75
        '
        'DgtbcByCbje
        '
        Me.DgtbcByCbje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcByCbje.Format = ""
        Me.DgtbcByCbje.FormatInfo = Nothing
        Me.DgtbcByCbje.HeaderText = "本月成本金额"
        Me.DgtbcByCbje.MappingName = "bycbje"
        Me.DgtbcByCbje.NullText = ""
        Me.DgtbcByCbje.Width = 75
        '
        'DgtbcSyCbje
        '
        Me.DgtbcSyCbje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSyCbje.Format = ""
        Me.DgtbcSyCbje.FormatInfo = Nothing
        Me.DgtbcSyCbje.HeaderText = "上月成本金额"
        Me.DgtbcSyCbje.MappingName = "sycbje"
        Me.DgtbcSyCbje.NullText = ""
        Me.DgtbcSyCbje.Width = 75
        '
        'DgtbcSnCbje
        '
        Me.DgtbcSnCbje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSnCbje.Format = ""
        Me.DgtbcSnCbje.FormatInfo = Nothing
        Me.DgtbcSnCbje.HeaderText = "上年同期成本金额"
        Me.DgtbcSnCbje.MappingName = "sncbje"
        Me.DgtbcSnCbje.NullText = ""
        Me.DgtbcSnCbje.Width = 75
        '
        'DgtbcByMle
        '
        Me.DgtbcByMle.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcByMle.Format = ""
        Me.DgtbcByMle.FormatInfo = Nothing
        Me.DgtbcByMle.HeaderText = "本月毛利额"
        Me.DgtbcByMle.MappingName = "bymle"
        Me.DgtbcByMle.NullText = ""
        Me.DgtbcByMle.Width = 75
        '
        'DgtbcSyMle
        '
        Me.DgtbcSyMle.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSyMle.Format = ""
        Me.DgtbcSyMle.FormatInfo = Nothing
        Me.DgtbcSyMle.HeaderText = "上月毛利额"
        Me.DgtbcSyMle.MappingName = "symle"
        Me.DgtbcSyMle.NullText = ""
        Me.DgtbcSyMle.Width = 75
        '
        'DgtbcSnMle
        '
        Me.DgtbcSnMle.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSnMle.Format = ""
        Me.DgtbcSnMle.FormatInfo = Nothing
        Me.DgtbcSnMle.HeaderText = "上年毛利额"
        Me.DgtbcSnMle.MappingName = "snmle"
        Me.DgtbcSnMle.NullText = ""
        Me.DgtbcSnMle.Width = 75
        '
        'DgtbcByMll
        '
        Me.DgtbcByMll.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcByMll.Format = ""
        Me.DgtbcByMll.FormatInfo = Nothing
        Me.DgtbcByMll.HeaderText = "本月毛利率"
        Me.DgtbcByMll.MappingName = "bymll"
        Me.DgtbcByMll.NullText = ""
        Me.DgtbcByMll.Width = 75
        '
        'DgtbcSyMll
        '
        Me.DgtbcSyMll.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSyMll.Format = ""
        Me.DgtbcSyMll.FormatInfo = Nothing
        Me.DgtbcSyMll.HeaderText = "上月毛利率"
        Me.DgtbcSyMll.MappingName = "symll"
        Me.DgtbcSyMll.NullText = ""
        Me.DgtbcSyMll.Width = 75
        '
        'DgtbcSnMll
        '
        Me.DgtbcSnMll.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSnMll.Format = ""
        Me.DgtbcSnMll.FormatInfo = Nothing
        Me.DgtbcSnMll.HeaderText = "上年同期毛利率"
        Me.DgtbcSnMll.MappingName = "snmll"
        Me.DgtbcSnMll.NullText = ""
        Me.DgtbcSnMll.Width = 75
        '
        'DgtbcHbFzsl
        '
        Me.DgtbcHbFzsl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcHbFzsl.Format = ""
        Me.DgtbcHbFzsl.FormatInfo = Nothing
        Me.DgtbcHbFzsl.HeaderText = "重量环比"
        Me.DgtbcHbFzsl.MappingName = "hbfzsl"
        Me.DgtbcHbFzsl.NullText = ""
        Me.DgtbcHbFzsl.Width = 75
        '
        'DgtbcTbFzsl
        '
        Me.DgtbcTbFzsl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcTbFzsl.Format = ""
        Me.DgtbcTbFzsl.FormatInfo = Nothing
        Me.DgtbcTbFzsl.HeaderText = "重量同比"
        Me.DgtbcTbFzsl.MappingName = "tbfzsl"
        Me.DgtbcTbFzsl.NullText = ""
        Me.DgtbcTbFzsl.Width = 75
        '
        'DgtbcHbJe
        '
        Me.DgtbcHbJe.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcHbJe.Format = ""
        Me.DgtbcHbJe.FormatInfo = Nothing
        Me.DgtbcHbJe.HeaderText = "金额环比"
        Me.DgtbcHbJe.MappingName = "hbje"
        Me.DgtbcHbJe.NullText = ""
        Me.DgtbcHbJe.Width = 75
        '
        'DgtbcTbJe
        '
        Me.DgtbcTbJe.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcTbJe.Format = ""
        Me.DgtbcTbJe.FormatInfo = Nothing
        Me.DgtbcTbJe.HeaderText = "金额同比"
        Me.DgtbcTbJe.MappingName = "tbje"
        Me.DgtbcTbJe.NullText = ""
        Me.DgtbcTbJe.Width = 75
        '
        'FrmOeKhFpFxbz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmOeKhFpFxbz"
        Me.Text = "客户销售发票对比分析表"
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RcDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DgtbcKhdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcKhmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBySl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcByJe As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZydm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZymc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBySe As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcByCbje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcByMle As DataGridTextBoxColumn
    Friend WithEvents DgtbcByMll As DataGridTextBoxColumn
    Friend WithEvents DgtbcKhLbdm As DataGridTextBoxColumn
    Friend WithEvents DgtbcKhLbmc As DataGridTextBoxColumn
    Friend WithEvents DgtbcByFzsl As DataGridTextBoxColumn
    Friend WithEvents DgtbcCpLbdm As DataGridTextBoxColumn
    Friend WithEvents DgtbcCpLbmc As DataGridTextBoxColumn
    Friend WithEvents DgtbcSySl As DataGridTextBoxColumn
    Friend WithEvents DgtbcSnSl As DataGridTextBoxColumn
    Friend WithEvents DgtbcSyFzsl As DataGridTextBoxColumn
    Friend WithEvents DgtbcSnFzsl As DataGridTextBoxColumn
    Friend WithEvents DgtbcSyJe As DataGridTextBoxColumn
    Friend WithEvents DgtbcSnJe As DataGridTextBoxColumn
    Friend WithEvents DgtbcSySe As DataGridTextBoxColumn
    Friend WithEvents DgtbcSnSe As DataGridTextBoxColumn
    Friend WithEvents DgtbcSyCbje As DataGridTextBoxColumn
    Friend WithEvents DgtbcSnCbje As DataGridTextBoxColumn
    Friend WithEvents DgtbcSyMle As DataGridTextBoxColumn
    Friend WithEvents DgtbcSnMle As DataGridTextBoxColumn
    Friend WithEvents DgtbcSyMll As DataGridTextBoxColumn
    Friend WithEvents DgtbcSnMll As DataGridTextBoxColumn
    Friend WithEvents DgtbcHbFzsl As DataGridTextBoxColumn
    Friend WithEvents DgtbcTbFzsl As DataGridTextBoxColumn
    Friend WithEvents DgtbcHbJe As DataGridTextBoxColumn
    Friend WithEvents DgtbcTbJe As DataGridTextBoxColumn
End Class
