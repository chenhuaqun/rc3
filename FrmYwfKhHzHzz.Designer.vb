<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmYwfKhHzHzz
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
        Me.DgtbcDwdm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcDwmc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcKhdm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcKhmc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcZydm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcZymc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcXslbdm = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcYwfbl = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcNewkhBl = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcSkqx = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcByjf = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcBydf = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcQmye = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcYwf_Bz = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcYwf_Newkh = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcYwf_Zl = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcCdhpje = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcYwf_cdhp = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcTieXiJe = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcYwf_Tx = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcSkje_yj = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcYongJinJe = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcYwf_Yj = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcDaiZhang = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcYwf_Dz = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcSuSong = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcYwf_Ss = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcYwf_Hlc = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DgtbcYwf_Hj = New System.Windows.Forms.DataGridTextBoxColumn()
        CType(Me.rcDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcDataView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RcDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RcDataGrid
        '
        Me.RcDataGrid.Location = New System.Drawing.Point(0, 172)
        Me.RcDataGrid.Size = New System.Drawing.Size(984, 389)
        Me.RcDataGrid.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(984, 108)
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(374, 8)
        Me.Label1.Size = New System.Drawing.Size(232, 26)
        Me.Label1.Text = "汇总业务费客户汇总表"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.RcDataGrid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DgtbcDwdm, Me.DgtbcDwmc, Me.DgtbcKhdm, Me.DgtbcKhmc, Me.DgtbcZydm, Me.DgtbcZymc, Me.DgtbcXslbdm, Me.DgtbcYwfbl, Me.DgtbcNewkhBl, Me.DgtbcSkqx, Me.DgtbcByjf, Me.DgtbcBydf, Me.DgtbcQmye, Me.DgtbcYwf_Bz, Me.DgtbcYwf_Newkh, Me.DgtbcYwf_Zl, Me.DgtbcCdhpje, Me.DgtbcYwf_cdhp, Me.DgtbcTieXiJe, Me.DgtbcYwf_Tx, Me.DgtbcSkje_yj, Me.DgtbcYongJinJe, Me.DgtbcYwf_Yj, Me.DgtbcDaiZhang, Me.DgtbcYwf_Dz, Me.DgtbcSuSong, Me.DgtbcYwf_Ss, Me.DgtbcYwf_Hlc, Me.DgtbcYwf_Hj})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "gl_ywfjsb"
        '
        'DgtbcDwdm
        '
        Me.DgtbcDwdm.Format = ""
        Me.DgtbcDwdm.FormatInfo = Nothing
        Me.DgtbcDwdm.HeaderText = "单位编码"
        Me.DgtbcDwdm.MappingName = "dwdm"
        Me.DgtbcDwdm.NullText = ""
        Me.DgtbcDwdm.Width = 75
        '
        'DgtbcDwmc
        '
        Me.DgtbcDwmc.Format = ""
        Me.DgtbcDwmc.FormatInfo = Nothing
        Me.DgtbcDwmc.HeaderText = "单位名称"
        Me.DgtbcDwmc.MappingName = "dwmc"
        Me.DgtbcDwmc.NullText = ""
        Me.DgtbcDwmc.Width = 75
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
        'DgtbcXslbdm
        '
        Me.DgtbcXslbdm.Format = ""
        Me.DgtbcXslbdm.FormatInfo = Nothing
        Me.DgtbcXslbdm.HeaderText = "销售类别"
        Me.DgtbcXslbdm.MappingName = "xslbdm"
        Me.DgtbcXslbdm.NullText = ""
        Me.DgtbcXslbdm.Width = 75
        '
        'DgtbcYwfbl
        '
        Me.DgtbcYwfbl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcYwfbl.Format = ""
        Me.DgtbcYwfbl.FormatInfo = Nothing
        Me.DgtbcYwfbl.HeaderText = "结算系数"
        Me.DgtbcYwfbl.MappingName = "ywfbl"
        Me.DgtbcYwfbl.NullText = ""
        Me.DgtbcYwfbl.Width = 75
        '
        'DgtbcNewkhBl
        '
        Me.DgtbcNewkhBl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcNewkhBl.Format = ""
        Me.DgtbcNewkhBl.FormatInfo = Nothing
        Me.DgtbcNewkhBl.HeaderText = "新客户提升比例"
        Me.DgtbcNewkhBl.MappingName = "newkhbl"
        Me.DgtbcNewkhBl.NullText = ""
        Me.DgtbcNewkhBl.Width = 75
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
        Me.DgtbcBydf.HeaderText = "本月回笼"
        Me.DgtbcBydf.MappingName = "bydf"
        Me.DgtbcBydf.NullText = ""
        Me.DgtbcBydf.Width = 75
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
        'DgtbcYwf_Bz
        '
        Me.DgtbcYwf_Bz.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcYwf_Bz.Format = ""
        Me.DgtbcYwf_Bz.FormatInfo = Nothing
        Me.DgtbcYwf_Bz.HeaderText = "标准业务费"
        Me.DgtbcYwf_Bz.MappingName = "ywf_bz"
        Me.DgtbcYwf_Bz.NullText = ""
        Me.DgtbcYwf_Bz.Width = 75
        '
        'DgtbcYwf_Newkh
        '
        Me.DgtbcYwf_Newkh.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcYwf_Newkh.Format = ""
        Me.DgtbcYwf_Newkh.FormatInfo = Nothing
        Me.DgtbcYwf_Newkh.HeaderText = "新客户提升业务费"
        Me.DgtbcYwf_Newkh.MappingName = "ywf_newkh"
        Me.DgtbcYwf_Newkh.NullText = ""
        Me.DgtbcYwf_Newkh.Width = 75
        '
        'DgtbcYwf_Zl
        '
        Me.DgtbcYwf_Zl.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcYwf_Zl.Format = ""
        Me.DgtbcYwf_Zl.FormatInfo = Nothing
        Me.DgtbcYwf_Zl.HeaderText = "超期收款下降金额"
        Me.DgtbcYwf_Zl.MappingName = "ywf_zl"
        Me.DgtbcYwf_Zl.NullText = ""
        Me.DgtbcYwf_Zl.Width = 75
        '
        'DgtbcCdhpje
        '
        Me.DgtbcCdhpje.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcCdhpje.Format = ""
        Me.DgtbcCdhpje.FormatInfo = Nothing
        Me.DgtbcCdhpje.HeaderText = "承兑汇票金额"
        Me.DgtbcCdhpje.MappingName = "cdhpje"
        Me.DgtbcCdhpje.NullText = ""
        Me.DgtbcCdhpje.Width = 75
        '
        'DgtbcYwf_cdhp
        '
        Me.DgtbcYwf_cdhp.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcYwf_cdhp.Format = ""
        Me.DgtbcYwf_cdhp.FormatInfo = Nothing
        Me.DgtbcYwf_cdhp.HeaderText = "承兑汇票下降金额"
        Me.DgtbcYwf_cdhp.MappingName = "ywf_cdhp"
        Me.DgtbcYwf_cdhp.NullText = ""
        Me.DgtbcYwf_cdhp.Width = 75
        '
        'DgtbcTieXiJe
        '
        Me.DgtbcTieXiJe.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcTieXiJe.Format = ""
        Me.DgtbcTieXiJe.FormatInfo = Nothing
        Me.DgtbcTieXiJe.HeaderText = "贴息金额"
        Me.DgtbcTieXiJe.MappingName = "tiexije"
        Me.DgtbcTieXiJe.NullText = ""
        Me.DgtbcTieXiJe.Width = 75
        '
        'DgtbcYwf_Tx
        '
        Me.DgtbcYwf_Tx.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcYwf_Tx.Format = ""
        Me.DgtbcYwf_Tx.FormatInfo = Nothing
        Me.DgtbcYwf_Tx.HeaderText = "贴息下降金额"
        Me.DgtbcYwf_Tx.MappingName = "ywf_tx"
        Me.DgtbcYwf_Tx.NullText = ""
        Me.DgtbcYwf_Tx.Width = 75
        '
        'DgtbcSkje_yj
        '
        Me.DgtbcSkje_yj.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSkje_yj.Format = ""
        Me.DgtbcSkje_yj.FormatInfo = Nothing
        Me.DgtbcSkje_yj.HeaderText = "收款金额(佣金)"
        Me.DgtbcSkje_yj.MappingName = "skje_yj"
        Me.DgtbcSkje_yj.NullText = ""
        Me.DgtbcSkje_yj.Width = 75
        '
        'DgtbcYongJinJe
        '
        Me.DgtbcYongJinJe.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcYongJinJe.Format = ""
        Me.DgtbcYongJinJe.FormatInfo = Nothing
        Me.DgtbcYongJinJe.HeaderText = "佣金金额"
        Me.DgtbcYongJinJe.MappingName = "yongjinje"
        Me.DgtbcYongJinJe.NullText = ""
        Me.DgtbcYongJinJe.Width = 75
        '
        'DgtbcYwf_Yj
        '
        Me.DgtbcYwf_Yj.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcYwf_Yj.Format = ""
        Me.DgtbcYwf_Yj.FormatInfo = Nothing
        Me.DgtbcYwf_Yj.HeaderText = "佣金下降金额"
        Me.DgtbcYwf_Yj.MappingName = "ywf_yj"
        Me.DgtbcYwf_Yj.NullText = ""
        Me.DgtbcYwf_Yj.Width = 75
        '
        'DgtbcDaiZhang
        '
        Me.DgtbcDaiZhang.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcDaiZhang.Format = ""
        Me.DgtbcDaiZhang.FormatInfo = Nothing
        Me.DgtbcDaiZhang.HeaderText = "呆账金额"
        Me.DgtbcDaiZhang.MappingName = "daizhang"
        Me.DgtbcDaiZhang.NullText = ""
        Me.DgtbcDaiZhang.Width = 75
        '
        'DgtbcYwf_Dz
        '
        Me.DgtbcYwf_Dz.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcYwf_Dz.Format = ""
        Me.DgtbcYwf_Dz.FormatInfo = Nothing
        Me.DgtbcYwf_Dz.HeaderText = "呆账下降金额"
        Me.DgtbcYwf_Dz.MappingName = "ywf_dz"
        Me.DgtbcYwf_Dz.NullText = ""
        Me.DgtbcYwf_Dz.Width = 75
        '
        'DgtbcSuSong
        '
        Me.DgtbcSuSong.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcSuSong.Format = ""
        Me.DgtbcSuSong.FormatInfo = Nothing
        Me.DgtbcSuSong.HeaderText = "诉讼回笼"
        Me.DgtbcSuSong.MappingName = "susong"
        Me.DgtbcSuSong.NullText = ""
        Me.DgtbcSuSong.Width = 75
        '
        'DgtbcYwf_Ss
        '
        Me.DgtbcYwf_Ss.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcYwf_Ss.Format = ""
        Me.DgtbcYwf_Ss.FormatInfo = Nothing
        Me.DgtbcYwf_Ss.HeaderText = "诉讼下降金额"
        Me.DgtbcYwf_Ss.MappingName = "ywf_ss"
        Me.DgtbcYwf_Ss.NullText = ""
        Me.DgtbcYwf_Ss.Width = 75
        '
        'DgtbcYwf_Hlc
        '
        Me.DgtbcYwf_Hlc.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcYwf_Hlc.Format = ""
        Me.DgtbcYwf_Hlc.FormatInfo = Nothing
        Me.DgtbcYwf_Hlc.HeaderText = "汇率差奖金"
        Me.DgtbcYwf_Hlc.MappingName = "ywf_hlc"
        Me.DgtbcYwf_Hlc.NullText = ""
        Me.DgtbcYwf_Hlc.Width = 75
        '
        'DgtbcYwf_Hj
        '
        Me.DgtbcYwf_Hj.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DgtbcYwf_Hj.Format = ""
        Me.DgtbcYwf_Hj.FormatInfo = Nothing
        Me.DgtbcYwf_Hj.HeaderText = "业务费合计"
        Me.DgtbcYwf_Hj.MappingName = "ywf_hj"
        Me.DgtbcYwf_Hj.NullText = ""
        Me.DgtbcYwf_Hj.Width = 75
        '
        'FrmYwfKhHzHzz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "FrmYwfKhHzHzz"
        Me.Text = "汇总业务费客户汇总表"
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
    Friend WithEvents DgtbcSkqx As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcByjf As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcBydf As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZydm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcZymc As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcXslbdm As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcYwfbl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcYwf_Bz As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcCdhpje As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcYwf_cdhp As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcYwf_Tx As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcYwf_Hj As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcYwf_Zl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcYwf_Newkh As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcNewkhBl As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcTieXiJe As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcYongJinJe As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcYwf_Yj As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcDaiZhang As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcYwf_Dz As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSuSong As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcYwf_Ss As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcSkje_yj As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DgtbcYwf_Hlc As DataGridTextBoxColumn
    Friend WithEvents DgtbcQmye As DataGridTextBoxColumn
    Friend WithEvents DgtbcDwdm As DataGridTextBoxColumn
    Friend WithEvents DgtbcDwmc As DataGridTextBoxColumn
End Class
