<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPoCkdCxLb
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
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DgtbcDjh = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcXh = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcCkrq = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcBdelete = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcCkdm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcCkmc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcBmdm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcBmmc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcFadm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcFamc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcZydm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcZymc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcCpdm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcCpmc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcCsdm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcCsmc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgbcBrecycling = New System.Windows.Forms.DataGridBoolColumn()
        Me.DgtbcKuwei = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcSl = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcDw = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcMjsl = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcFzsl = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcFzdw = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcDj = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcJe = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcCkmemo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcLlsqDjh = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcLlsqXh = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcSrr = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcSrrq = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcShr = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcShrq = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcRecyclerq = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcRecycler = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgbcBRecycle = New System.Windows.Forms.DataGridBoolColumn()
        Me.DgtbcPiHao = New System.Windows.Forms.DataGridTextBoxColumn()
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
        Me.Label1.Location = New System.Drawing.Point(408, 8)
        Me.Label1.Size = New System.Drawing.Size(166, 26)
        Me.Label1.Text = "物料出库单列表"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.RcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcDjh, Me.DgtbcXh, Me.DgtbcCkrq, Me.DgtbcBdelete, Me.DgtbcCkdm, Me.DgtbcCkmc, Me.DgtbcBmdm, Me.DgtbcBmmc, Me.DgtbcFadm, Me.DgtbcFamc, Me.DgtbcZydm, Me.DgtbcZymc, Me.DgtbcCpdm, Me.DgtbcCpmc, Me.DgtbcCsdm, Me.DgtbcCsmc, Me.DgbcBrecycling, Me.DgtbcKuwei, Me.DgtbcPiHao, Me.DgtbcSl, Me.DgtbcDw, Me.DgtbcMjsl, Me.DgtbcFzsl, Me.DgtbcFzdw, Me.DgtbcDj, Me.DgtbcJe, Me.DgtbcCkmemo, Me.DgtbcLlsqDjh, Me.DgtbcLlsqXh, Me.DgtbcSrr, Me.DgtbcSrrq, Me.DgtbcShr, Me.DgtbcShrq, Me.DgbcBRecycle, Me.DgtbcRecyclerq, Me.DgtbcRecycler})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "ckdlb"
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
        Me.DgtbcXh.Width = 45
        '
        'DgtbcCkrq
        '
        Me.DgtbcCkrq.Format = ""
        Me.DgtbcCkrq.FormatInfo = Nothing
        Me.DgtbcCkrq.HeaderText = "出库日期"
        Me.DgtbcCkrq.MappingName = "ckrq"
        Me.DgtbcCkrq.NullText = ""
        Me.DgtbcCkrq.Width = 110
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
        'DgtbcCkdm
        '
        Me.DgtbcCkdm.Format = ""
        Me.DgtbcCkdm.FormatInfo = Nothing
        Me.DgtbcCkdm.HeaderText = "仓库编码"
        Me.DgtbcCkdm.MappingName = "ckdm"
        Me.DgtbcCkdm.NullText = ""
        Me.DgtbcCkdm.Width = 60
        '
        'DgtbcCkmc
        '
        Me.DgtbcCkmc.Format = ""
        Me.DgtbcCkmc.FormatInfo = Nothing
        Me.DgtbcCkmc.HeaderText = "仓库名称"
        Me.DgtbcCkmc.MappingName = "ckmc"
        Me.DgtbcCkmc.NullText = ""
        Me.DgtbcCkmc.Width = 90
        '
        'DgtbcBmdm
        '
        Me.DgtbcBmdm.Format = ""
        Me.DgtbcBmdm.FormatInfo = Nothing
        Me.DgtbcBmdm.HeaderText = "部门编码"
        Me.DgtbcBmdm.MappingName = "bmdm"
        Me.DgtbcBmdm.NullText = ""
        Me.DgtbcBmdm.Width = 60
        '
        'DgtbcBmmc
        '
        Me.DgtbcBmmc.Format = ""
        Me.DgtbcBmmc.FormatInfo = Nothing
        Me.DgtbcBmmc.HeaderText = "部门名称"
        Me.DgtbcBmmc.MappingName = "bmmc"
        Me.DgtbcBmmc.NullText = ""
        Me.DgtbcBmmc.Width = 135
        '
        'DgtbcFadm
        '
        Me.DgtbcFadm.Format = ""
        Me.DgtbcFadm.FormatInfo = Nothing
        Me.DgtbcFadm.HeaderText = "设备编码"
        Me.DgtbcFadm.MappingName = "fadm"
        Me.DgtbcFadm.NullText = ""
        Me.DgtbcFadm.Width = 60
        '
        'DgtbcFamc
        '
        Me.DgtbcFamc.Format = ""
        Me.DgtbcFamc.FormatInfo = Nothing
        Me.DgtbcFamc.HeaderText = "设备名称"
        Me.DgtbcFamc.MappingName = "famc"
        Me.DgtbcFamc.NullText = ""
        Me.DgtbcFamc.Width = 135
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
        Me.DgtbcCsdm.Width = 75
        '
        'DgtbcCsmc
        '
        Me.DgtbcCsmc.Format = ""
        Me.DgtbcCsmc.FormatInfo = Nothing
        Me.DgtbcCsmc.HeaderText = "供应商名称"
        Me.DgtbcCsmc.MappingName = "csmc"
        Me.DgtbcCsmc.NullText = ""
        Me.DgtbcCsmc.Width = 210
        '
        'DgbcBrecycling
        '
        Me.DgbcBrecycling.HeaderText = "旧件回收"
        Me.DgbcBrecycling.MappingName = "brecycling"
        Me.DgbcBrecycling.NullText = ""
        Me.DgbcBrecycling.Width = 60
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
        Me.DgtbcSl.Width = 80
        '
        'DgtbcDw
        '
        Me.DgtbcDw.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DgtbcDw.Format = ""
        Me.DgtbcDw.FormatInfo = Nothing
        Me.DgtbcDw.HeaderText = "单位"
        Me.DgtbcDw.MappingName = "dw"
        Me.DgtbcDw.NullText = ""
        Me.DgtbcDw.Width = 35
        '
        'DgtbcMjsl
        '
        Me.DgtbcMjsl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcMjsl.Format = ""
        Me.DgtbcMjsl.FormatInfo = Nothing
        Me.DgtbcMjsl.HeaderText = "换算系数"
        Me.DgtbcMjsl.MappingName = "mjsl"
        Me.DgtbcMjsl.NullText = ""
        Me.DgtbcMjsl.Width = 80
        '
        'DgtbcFzsl
        '
        Me.DgtbcFzsl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcFzsl.Format = ""
        Me.DgtbcFzsl.FormatInfo = Nothing
        Me.DgtbcFzsl.HeaderText = "辅数量"
        Me.DgtbcFzsl.MappingName = "fzsl"
        Me.DgtbcFzsl.NullText = ""
        Me.DgtbcFzsl.Width = 80
        '
        'DgtbcFzdw
        '
        Me.DgtbcFzdw.Alignment = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.DgtbcDj.Width = 80
        '
        'DgtbcJe
        '
        Me.DgtbcJe.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcJe.Format = ""
        Me.DgtbcJe.FormatInfo = Nothing
        Me.DgtbcJe.HeaderText = "金额"
        Me.DgtbcJe.MappingName = "je"
        Me.DgtbcJe.NullText = ""
        Me.DgtbcJe.Width = 80
        '
        'DgtbcCkmemo
        '
        Me.DgtbcCkmemo.Format = ""
        Me.DgtbcCkmemo.FormatInfo = Nothing
        Me.DgtbcCkmemo.HeaderText = "备注"
        Me.DgtbcCkmemo.MappingName = "ckmemo"
        Me.DgtbcCkmemo.NullText = ""
        Me.DgtbcCkmemo.Width = 135
        '
        'DgtbcLlsqDjh
        '
        Me.DgtbcLlsqDjh.Format = ""
        Me.DgtbcLlsqDjh.FormatInfo = Nothing
        Me.DgtbcLlsqDjh.HeaderText = "领料申请单单据号"
        Me.DgtbcLlsqDjh.MappingName = "llsqdjh"
        Me.DgtbcLlsqDjh.NullText = ""
        Me.DgtbcLlsqDjh.Width = 110
        '
        'DgtbcLlsqXh
        '
        Me.DgtbcLlsqXh.Format = ""
        Me.DgtbcLlsqXh.FormatInfo = Nothing
        Me.DgtbcLlsqXh.HeaderText = "领料申请单行号"
        Me.DgtbcLlsqXh.MappingName = "llsqxh"
        Me.DgtbcLlsqXh.NullText = ""
        Me.DgtbcLlsqXh.Width = 60
        '
        'DgtbcSrr
        '
        Me.DgtbcSrr.Format = ""
        Me.DgtbcSrr.FormatInfo = Nothing
        Me.DgtbcSrr.HeaderText = "输入人"
        Me.DgtbcSrr.MappingName = "srr"
        Me.DgtbcSrr.NullText = ""
        Me.DgtbcSrr.Width = 90
        '
        'DgtbcSrrq
        '
        Me.DgtbcSrrq.Format = ""
        Me.DgtbcSrrq.FormatInfo = Nothing
        Me.DgtbcSrrq.HeaderText = "输入日期"
        Me.DgtbcSrrq.MappingName = "srrq"
        Me.DgtbcSrrq.NullText = ""
        Me.DgtbcSrrq.Width = 110
        '
        'DgtbcShr
        '
        Me.DgtbcShr.Format = ""
        Me.DgtbcShr.FormatInfo = Nothing
        Me.DgtbcShr.HeaderText = "审核人"
        Me.DgtbcShr.MappingName = "shr"
        Me.DgtbcShr.NullText = ""
        Me.DgtbcShr.Width = 90
        '
        'DgtbcShrq
        '
        Me.DgtbcShrq.Format = ""
        Me.DgtbcShrq.FormatInfo = Nothing
        Me.DgtbcShrq.HeaderText = "审核日期"
        Me.DgtbcShrq.MappingName = "shrq"
        Me.DgtbcShrq.NullText = ""
        Me.DgtbcShrq.Width = 110
        '
        'DgtbcRecyclerq
        '
        Me.DgtbcRecyclerq.Format = ""
        Me.DgtbcRecyclerq.FormatInfo = Nothing
        Me.DgtbcRecyclerq.HeaderText = "回收日期"
        Me.DgtbcRecyclerq.MappingName = "recyclerq"
        Me.DgtbcRecyclerq.NullText = ""
        Me.DgtbcRecyclerq.Width = 75
        '
        'DgtbcRecycler
        '
        Me.DgtbcRecycler.Format = ""
        Me.DgtbcRecycler.FormatInfo = Nothing
        Me.DgtbcRecycler.HeaderText = "回收人"
        Me.DgtbcRecycler.MappingName = "recycler"
        Me.DgtbcRecycler.NullText = ""
        Me.DgtbcRecycler.Width = 75
        '
        'DgbcBRecycle
        '
        Me.DgbcBRecycle.HeaderText = "回收标志"
        Me.DgbcBRecycle.MappingName = "brecycle"
        Me.DgbcBRecycle.NullText = ""
        Me.DgbcBRecycle.Width = 75
        '
        'DgtbcPiHao
        '
        Me.DgtbcPiHao.Format = ""
        Me.DgtbcPiHao.FormatInfo = Nothing
        Me.DgtbcPiHao.HeaderText = "批号"
        Me.DgtbcPiHao.MappingName = "pihao"
        Me.DgtbcPiHao.NullText = ""
        Me.DgtbcPiHao.Width = 75
        '
        'FrmPoCkdCxLb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmPoCkdCxLb"
        Me.Text = "物料出库单列表"
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RcDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DgtbcDjh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCkrq As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZydm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCpdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCpmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDw As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDj As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCkmemo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSrr As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcShr As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSrrq As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZymc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCkdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcKuwei As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcJe As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCkmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBmdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBmmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcMjsl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcFzsl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcFzdw As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcXh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcFadm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcFamc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcShrq As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCsdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCsmc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcLlsqDjh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcLlsqXh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgbcBrecycling As System.Windows.Forms.DataGridBoolColumn
    Friend WithEvents DgtbcBdelete As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgbcBRecycle As DataGridBoolColumn
    Friend WithEvents DgtbcRecyclerq As DataGridTextBoxColumn
    Friend WithEvents DgtbcRecycler As DataGridTextBoxColumn
    Friend WithEvents DgtbcPiHao As DataGridTextBoxColumn
End Class
