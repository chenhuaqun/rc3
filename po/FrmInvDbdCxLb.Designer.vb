<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInvDbdCxLb
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
        Me.DgtbcDjh = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcXh = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcDbrq = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCckdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCckmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcRckdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcRckmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcZydm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcZymc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCpdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCpmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCsdm = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcCsmc = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcPiHao = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcKuwei = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcDw = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcMjsl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcFzsl = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcFzdw = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcDj = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJe = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcDbmemo = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcLlsqDjh = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcLlsqXh = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcSrr = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcShr = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcJzr = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DgtbcBdelete = New System.Windows.Forms.DataGridTextBoxColumn
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
        Me.Label1.Text = "物料调拨单列表"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.rcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcDjh, Me.DgtbcXh, Me.DgtbcBdelete, Me.DgtbcDbrq, Me.DgtbcCckdm, Me.DgtbcCckmc, Me.DgtbcRckdm, Me.DgtbcRckmc, Me.DgtbcZydm, Me.DgtbcZymc, Me.DgtbcCpdm, Me.DgtbcCpmc, Me.DgtbcCsdm, Me.DgtbcCsmc, Me.DgtbcPiHao, Me.DgtbcKuwei, Me.DgtbcSl, Me.DgtbcDw, Me.DgtbcMjsl, Me.DgtbcFzsl, Me.DgtbcFzdw, Me.DgtbcDj, Me.DgtbcJe, Me.DgtbcDbmemo, Me.DgtbcLlsqDjh, Me.DgtbcLlsqXh, Me.DgtbcSrr, Me.DgtbcShr, Me.DgtbcJzr})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "dbdlb"
        '
        'DgtbcDjh
        '
        Me.DgtbcDjh.Format = ""
        Me.DgtbcDjh.FormatInfo = Nothing
        Me.DgtbcDjh.HeaderText = "单据号"
        Me.DgtbcDjh.MappingName = "djh"
        Me.DgtbcDjh.NullText = ""
        Me.DgtbcDjh.Width = 120
        '
        'DgtbcXh
        '
        Me.DgtbcXh.Format = ""
        Me.DgtbcXh.FormatInfo = Nothing
        Me.DgtbcXh.HeaderText = "行号"
        Me.DgtbcXh.MappingName = "xh"
        Me.DgtbcXh.NullText = ""
        Me.DgtbcXh.Width = 60
        '
        'DgtbcDbrq
        '
        Me.DgtbcDbrq.Format = ""
        Me.DgtbcDbrq.FormatInfo = Nothing
        Me.DgtbcDbrq.HeaderText = "调拨日期"
        Me.DgtbcDbrq.MappingName = "dbrq"
        Me.DgtbcDbrq.NullText = ""
        Me.DgtbcDbrq.Width = 110
        '
        'DgtbcCckdm
        '
        Me.DgtbcCckdm.Format = ""
        Me.DgtbcCckdm.FormatInfo = Nothing
        Me.DgtbcCckdm.HeaderText = "调出仓库编码"
        Me.DgtbcCckdm.MappingName = "cckdm"
        Me.DgtbcCckdm.NullText = ""
        Me.DgtbcCckdm.Width = 75
        '
        'DgtbcCckmc
        '
        Me.DgtbcCckmc.Format = ""
        Me.DgtbcCckmc.FormatInfo = Nothing
        Me.DgtbcCckmc.HeaderText = "调出仓库名称"
        Me.DgtbcCckmc.MappingName = "cckmc"
        Me.DgtbcCckmc.NullText = ""
        Me.DgtbcCckmc.Width = 75
        '
        'DgtbcRckdm
        '
        Me.DgtbcRckdm.Format = ""
        Me.DgtbcRckdm.FormatInfo = Nothing
        Me.DgtbcRckdm.HeaderText = "调入仓库编码"
        Me.DgtbcRckdm.MappingName = "rckdm"
        Me.DgtbcRckdm.NullText = ""
        Me.DgtbcRckdm.Width = 75
        '
        'DgtbcRckmc
        '
        Me.DgtbcRckmc.Format = ""
        Me.DgtbcRckmc.FormatInfo = Nothing
        Me.DgtbcRckmc.HeaderText = "调入仓库名称"
        Me.DgtbcRckmc.MappingName = "rckmc"
        Me.DgtbcRckmc.NullText = ""
        Me.DgtbcRckmc.Width = 75
        '
        'DgtbcZydm
        '
        Me.DgtbcZydm.Format = ""
        Me.DgtbcZydm.FormatInfo = Nothing
        Me.DgtbcZydm.HeaderText = "职员编码"
        Me.DgtbcZydm.MappingName = "zydm"
        Me.DgtbcZydm.NullText = ""
        Me.DgtbcZydm.Width = 45
        '
        'DgtbcZymc
        '
        Me.DgtbcZymc.Format = ""
        Me.DgtbcZymc.FormatInfo = Nothing
        Me.DgtbcZymc.HeaderText = "职员名称"
        Me.DgtbcZymc.MappingName = "zymc"
        Me.DgtbcZymc.NullText = ""
        Me.DgtbcZymc.Width = 90
        '
        'DgtbcCpdm
        '
        Me.DgtbcCpdm.Format = ""
        Me.DgtbcCpdm.FormatInfo = Nothing
        Me.DgtbcCpdm.HeaderText = "物料编码"
        Me.DgtbcCpdm.MappingName = "cpdm"
        Me.DgtbcCpdm.NullText = ""
        Me.DgtbcCpdm.Width = 90
        '
        'DgtbcCpmc
        '
        Me.DgtbcCpmc.Format = ""
        Me.DgtbcCpmc.FormatInfo = Nothing
        Me.DgtbcCpmc.HeaderText = "物料名称"
        Me.DgtbcCpmc.MappingName = "cpmc"
        Me.DgtbcCpmc.NullText = ""
        Me.DgtbcCpmc.Width = 240
        '
        'DgtbcCsdm
        '
        Me.DgtbcCsdm.Format = ""
        Me.DgtbcCsdm.FormatInfo = Nothing
        Me.DgtbcCsdm.HeaderText = "供应商编码"
        Me.DgtbcCsdm.MappingName = "csdm"
        Me.DgtbcCsdm.NullText = ""
        Me.DgtbcCsdm.Width = 90
        '
        'DgtbcCsmc
        '
        Me.DgtbcCsmc.Format = ""
        Me.DgtbcCsmc.FormatInfo = Nothing
        Me.DgtbcCsmc.HeaderText = "供应商名称"
        Me.DgtbcCsmc.MappingName = "csmc"
        Me.DgtbcCsmc.NullText = ""
        Me.DgtbcCsmc.Width = 180
        '
        'DgtbcPiHao
        '
        Me.DgtbcPiHao.Format = ""
        Me.DgtbcPiHao.FormatInfo = Nothing
        Me.DgtbcPiHao.HeaderText = "批号"
        Me.DgtbcPiHao.MappingName = "pihao"
        Me.DgtbcPiHao.NullText = ""
        Me.DgtbcPiHao.Width = 90
        '
        'DgtbcKuwei
        '
        Me.DgtbcKuwei.Format = ""
        Me.DgtbcKuwei.FormatInfo = Nothing
        Me.DgtbcKuwei.HeaderText = "库位"
        Me.DgtbcKuwei.MappingName = "kuwei"
        Me.DgtbcKuwei.NullText = ""
        Me.DgtbcKuwei.Width = 75
        '
        'DgtbcSl
        '
        Me.DgtbcSl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSl.Format = ""
        Me.DgtbcSl.FormatInfo = Nothing
        Me.DgtbcSl.HeaderText = "数量"
        Me.DgtbcSl.MappingName = "sl"
        Me.DgtbcSl.NullText = ""
        Me.DgtbcSl.Width = 75
        '
        'DgtbcDw
        '
        Me.DgtbcDw.Format = ""
        Me.DgtbcDw.FormatInfo = Nothing
        Me.DgtbcDw.HeaderText = "单位"
        Me.DgtbcDw.MappingName = "dw"
        Me.DgtbcDw.NullText = ""
        Me.DgtbcDw.Width = 30
        '
        'DgtbcMjsl
        '
        Me.DgtbcMjsl.Format = ""
        Me.DgtbcMjsl.FormatInfo = Nothing
        Me.DgtbcMjsl.HeaderText = "换算系数"
        Me.DgtbcMjsl.MappingName = "mjsl"
        Me.DgtbcMjsl.NullText = ""
        Me.DgtbcMjsl.Width = 75
        '
        'DgtbcFzsl
        '
        Me.DgtbcFzsl.Format = ""
        Me.DgtbcFzsl.FormatInfo = Nothing
        Me.DgtbcFzsl.HeaderText = "辅数量"
        Me.DgtbcFzsl.MappingName = "fzsl"
        Me.DgtbcFzsl.NullText = ""
        Me.DgtbcFzsl.Width = 75
        '
        'DgtbcFzdw
        '
        Me.DgtbcFzdw.Format = ""
        Me.DgtbcFzdw.FormatInfo = Nothing
        Me.DgtbcFzdw.HeaderText = "辅单位"
        Me.DgtbcFzdw.MappingName = "fzdw"
        Me.DgtbcFzdw.NullText = ""
        Me.DgtbcFzdw.Width = 35
        '
        'DgtbcDj
        '
        Me.DgtbcDj.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcDj.Format = ""
        Me.DgtbcDj.FormatInfo = Nothing
        Me.DgtbcDj.HeaderText = "单价"
        Me.DgtbcDj.MappingName = "dj"
        Me.DgtbcDj.NullText = ""
        Me.DgtbcDj.Width = 75
        '
        'DgtbcJe
        '
        Me.DgtbcJe.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcJe.Format = ""
        Me.DgtbcJe.FormatInfo = Nothing
        Me.DgtbcJe.HeaderText = "金额"
        Me.DgtbcJe.MappingName = "je"
        Me.DgtbcJe.NullText = ""
        Me.DgtbcJe.Width = 75
        '
        'DgtbcDbmemo
        '
        Me.DgtbcDbmemo.Format = ""
        Me.DgtbcDbmemo.FormatInfo = Nothing
        Me.DgtbcDbmemo.HeaderText = "备注"
        Me.DgtbcDbmemo.MappingName = "dbmemo"
        Me.DgtbcDbmemo.NullText = ""
        Me.DgtbcDbmemo.Width = 135
        '
        'DgtbcLlsqDjh
        '
        Me.DgtbcLlsqDjh.Format = ""
        Me.DgtbcLlsqDjh.FormatInfo = Nothing
        Me.DgtbcLlsqDjh.HeaderText = "领料申请单据号"
        Me.DgtbcLlsqDjh.MappingName = "llsqdjh"
        Me.DgtbcLlsqDjh.NullText = ""
        Me.DgtbcLlsqDjh.Width = 120
        '
        'DgtbcLlsqXh
        '
        Me.DgtbcLlsqXh.Format = ""
        Me.DgtbcLlsqXh.FormatInfo = Nothing
        Me.DgtbcLlsqXh.HeaderText = "领料申请行号"
        Me.DgtbcLlsqXh.MappingName = "llsqxh"
        Me.DgtbcLlsqXh.NullText = ""
        Me.DgtbcLlsqXh.Width = 60
        '
        'DgtbcSrr
        '
        Me.DgtbcSrr.Format = ""
        Me.DgtbcSrr.FormatInfo = Nothing
        Me.DgtbcSrr.HeaderText = "输入"
        Me.DgtbcSrr.MappingName = "srr"
        Me.DgtbcSrr.NullText = ""
        Me.DgtbcSrr.Width = 90
        '
        'DgtbcShr
        '
        Me.DgtbcShr.Format = ""
        Me.DgtbcShr.FormatInfo = Nothing
        Me.DgtbcShr.HeaderText = "审核"
        Me.DgtbcShr.MappingName = "shr"
        Me.DgtbcShr.NullText = ""
        Me.DgtbcShr.Width = 90
        '
        'DgtbcJzr
        '
        Me.DgtbcJzr.Format = ""
        Me.DgtbcJzr.FormatInfo = Nothing
        Me.DgtbcJzr.HeaderText = "记账"
        Me.DgtbcJzr.MappingName = "jzr"
        Me.DgtbcJzr.NullText = ""
        Me.DgtbcJzr.Width = 90
        '
        'DgtbcBdelete
        '
        Me.DgtbcBdelete.Format = ""
        Me.DgtbcBdelete.FormatInfo = Nothing
        Me.DgtbcBdelete.HeaderText = "作废标志"
        Me.DgtbcBdelete.MappingName = "bdelete"
        Me.DgtbcBdelete.NullText = ""
        Me.DgtbcBdelete.Width = 45
        '
        'FrmInvDbdCxLb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmInvDbdCxLb"
        Me.Text = "物料调拨单列表"
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DgtbcDjh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDbrq As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZydm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCpdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCpmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDw As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDj As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDbmemo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSrr As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcShr As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJzr As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZymc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCckdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcKuwei As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJe As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcRckdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCckmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcRckmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcMjsl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcFzsl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcFzdw As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcPiHao As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcLlsqDjh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcLlsqXh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcXh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCsdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCsmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBdelete As System.Windows.Forms.DataGridTextBoxColumn
End Class
