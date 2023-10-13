<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmQckmyeSr
    Inherits models.FrmDlgPortrait

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
        Me.TxtNcje = New System.Windows.Forms.TextBox()
        Me.LblNcje = New System.Windows.Forms.Label()
        Me.LblBz = New System.Windows.Forms.Label()
        Me.LblDw = New System.Windows.Forms.Label()
        Me.LblJd = New System.Windows.Forms.Label()
        Me.LblKmmc = New System.Windows.Forms.Label()
        Me.TxtNcwb = New System.Windows.Forms.TextBox()
        Me.LblNcwb = New System.Windows.Forms.Label()
        Me.TxtKmdm = New System.Windows.Forms.TextBox()
        Me.LblKmdm = New System.Windows.Forms.Label()
        Me.TxtNcsl = New System.Windows.Forms.TextBox()
        Me.LblNcsl = New System.Windows.Forms.Label()
        Me.TxtBmdm = New System.Windows.Forms.TextBox()
        Me.LblBmdm = New System.Windows.Forms.Label()
        Me.TxtZydm = New System.Windows.Forms.TextBox()
        Me.LblZydm = New System.Windows.Forms.Label()
        Me.TxtXmdm = New System.Windows.Forms.TextBox()
        Me.LblXmdm = New System.Windows.Forms.Label()
        Me.TxtKhdm = New System.Windows.Forms.TextBox()
        Me.LblKhdm = New System.Windows.Forms.Label()
        Me.TxtCsdm = New System.Windows.Forms.TextBox()
        Me.LblCsdm = New System.Windows.Forms.Label()
        Me.TxtYhzh = New System.Windows.Forms.TextBox()
        Me.LblYhzh = New System.Windows.Forms.Label()
        Me.TxtJxzh = New System.Windows.Forms.TextBox()
        Me.LblJxzh = New System.Windows.Forms.Label()
        Me.LblBmmc = New System.Windows.Forms.Label()
        Me.LblZymc = New System.Windows.Forms.Label()
        Me.LblXmmc = New System.Windows.Forms.Label()
        Me.LblKhmc = New System.Windows.Forms.Label()
        Me.LblCsmc = New System.Windows.Forms.Label()
        Me.RdoBtnJie = New System.Windows.Forms.RadioButton()
        Me.RdoBtnDai = New System.Windows.Forms.RadioButton()
        Me.LblKjnd = New System.Windows.Forms.Label()
        Me.DlgPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(124, 4)
        Me.BtnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnCancel.Size = New System.Drawing.Size(111, 34)
        Me.BtnCancel.TabIndex = 1
        '
        'BtnHelp
        '
        Me.BtnHelp.Location = New System.Drawing.Point(244, 4)
        Me.BtnHelp.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnHelp.Size = New System.Drawing.Size(112, 34)
        Me.BtnHelp.TabIndex = 2
        '
        'BtnOk
        '
        Me.BtnOk.Location = New System.Drawing.Point(4, 4)
        Me.BtnOk.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnOk.Size = New System.Drawing.Size(111, 34)
        Me.BtnOk.TabIndex = 0
        '
        'DlgPanel
        '
        Me.DlgPanel.Location = New System.Drawing.Point(247, 502)
        Me.DlgPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.DlgPanel.Size = New System.Drawing.Size(363, 46)
        Me.DlgPanel.TabIndex = 33
        '
        'TxtNcje
        '
        Me.TxtNcje.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNcje.Location = New System.Drawing.Point(211, 454)
        Me.TxtNcje.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNcje.MaxLength = 12
        Me.TxtNcje.Name = "TxtNcje"
        Me.TxtNcje.Size = New System.Drawing.Size(154, 28)
        Me.TxtNcje.TabIndex = 32
        '
        'LblNcje
        '
        Me.LblNcje.AutoSize = True
        Me.LblNcje.Location = New System.Drawing.Point(97, 459)
        Me.LblNcje.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNcje.Name = "LblNcje"
        Me.LblNcje.Size = New System.Drawing.Size(98, 18)
        Me.LblNcje.TabIndex = 31
        Me.LblNcje.Text = "年初金额："
        '
        'LblBz
        '
        Me.LblBz.AutoSize = True
        Me.LblBz.Location = New System.Drawing.Point(381, 423)
        Me.LblBz.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBz.Name = "LblBz"
        Me.LblBz.Size = New System.Drawing.Size(44, 18)
        Me.LblBz.TabIndex = 30
        Me.LblBz.Text = "币种"
        '
        'LblDw
        '
        Me.LblDw.AutoSize = True
        Me.LblDw.Location = New System.Drawing.Point(381, 387)
        Me.LblDw.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDw.Name = "LblDw"
        Me.LblDw.Size = New System.Drawing.Size(44, 18)
        Me.LblDw.TabIndex = 27
        Me.LblDw.Text = "单位"
        '
        'LblJd
        '
        Me.LblJd.AutoSize = True
        Me.LblJd.Location = New System.Drawing.Point(97, 354)
        Me.LblJd.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblJd.Name = "LblJd"
        Me.LblJd.Size = New System.Drawing.Size(98, 18)
        Me.LblJd.TabIndex = 22
        Me.LblJd.Text = "余额方向："
        '
        'LblKmmc
        '
        Me.LblKmmc.AutoSize = True
        Me.LblKmmc.Location = New System.Drawing.Point(355, 69)
        Me.LblKmmc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblKmmc.Name = "LblKmmc"
        Me.LblKmmc.Size = New System.Drawing.Size(80, 18)
        Me.LblKmmc.TabIndex = 2
        Me.LblKmmc.Text = "科目名称"
        '
        'TxtNcwb
        '
        Me.TxtNcwb.Location = New System.Drawing.Point(211, 418)
        Me.TxtNcwb.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNcwb.MaxLength = 16
        Me.TxtNcwb.Name = "TxtNcwb"
        Me.TxtNcwb.Size = New System.Drawing.Size(154, 28)
        Me.TxtNcwb.TabIndex = 29
        '
        'LblNcwb
        '
        Me.LblNcwb.AutoSize = True
        Me.LblNcwb.Location = New System.Drawing.Point(97, 423)
        Me.LblNcwb.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNcwb.Name = "LblNcwb"
        Me.LblNcwb.Size = New System.Drawing.Size(98, 18)
        Me.LblNcwb.TabIndex = 28
        Me.LblNcwb.Text = "年初外币："
        '
        'TxtKmdm
        '
        Me.TxtKmdm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtKmdm.Location = New System.Drawing.Point(211, 64)
        Me.TxtKmdm.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtKmdm.MaxLength = 15
        Me.TxtKmdm.Name = "TxtKmdm"
        Me.TxtKmdm.Size = New System.Drawing.Size(128, 28)
        Me.TxtKmdm.TabIndex = 1
        '
        'LblKmdm
        '
        Me.LblKmdm.AutoSize = True
        Me.LblKmdm.Location = New System.Drawing.Point(97, 69)
        Me.LblKmdm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblKmdm.Name = "LblKmdm"
        Me.LblKmdm.Size = New System.Drawing.Size(98, 18)
        Me.LblKmdm.TabIndex = 0
        Me.LblKmdm.Text = "科目编码："
        '
        'TxtNcsl
        '
        Me.TxtNcsl.Location = New System.Drawing.Point(211, 382)
        Me.TxtNcsl.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNcsl.MaxLength = 30
        Me.TxtNcsl.Name = "TxtNcsl"
        Me.TxtNcsl.Size = New System.Drawing.Size(154, 28)
        Me.TxtNcsl.TabIndex = 26
        '
        'LblNcsl
        '
        Me.LblNcsl.AutoSize = True
        Me.LblNcsl.Location = New System.Drawing.Point(97, 387)
        Me.LblNcsl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNcsl.Name = "LblNcsl"
        Me.LblNcsl.Size = New System.Drawing.Size(98, 18)
        Me.LblNcsl.TabIndex = 25
        Me.LblNcsl.Text = "年初数量："
        '
        'TxtBmdm
        '
        Me.TxtBmdm.Location = New System.Drawing.Point(211, 100)
        Me.TxtBmdm.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtBmdm.MaxLength = 12
        Me.TxtBmdm.Name = "TxtBmdm"
        Me.TxtBmdm.Size = New System.Drawing.Size(128, 28)
        Me.TxtBmdm.TabIndex = 4
        '
        'LblBmdm
        '
        Me.LblBmdm.AutoSize = True
        Me.LblBmdm.Location = New System.Drawing.Point(97, 105)
        Me.LblBmdm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBmdm.Name = "LblBmdm"
        Me.LblBmdm.Size = New System.Drawing.Size(98, 18)
        Me.LblBmdm.TabIndex = 3
        Me.LblBmdm.Text = "部门编码："
        '
        'TxtZydm
        '
        Me.TxtZydm.Location = New System.Drawing.Point(211, 136)
        Me.TxtZydm.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtZydm.MaxLength = 12
        Me.TxtZydm.Name = "TxtZydm"
        Me.TxtZydm.Size = New System.Drawing.Size(128, 28)
        Me.TxtZydm.TabIndex = 7
        '
        'LblZydm
        '
        Me.LblZydm.AutoSize = True
        Me.LblZydm.Location = New System.Drawing.Point(97, 141)
        Me.LblZydm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblZydm.Name = "LblZydm"
        Me.LblZydm.Size = New System.Drawing.Size(98, 18)
        Me.LblZydm.TabIndex = 6
        Me.LblZydm.Text = "职员编码："
        '
        'TxtXmdm
        '
        Me.TxtXmdm.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtXmdm.Location = New System.Drawing.Point(211, 172)
        Me.TxtXmdm.Name = "TxtXmdm"
        Me.TxtXmdm.Size = New System.Drawing.Size(128, 28)
        Me.TxtXmdm.TabIndex = 10
        '
        'LblXmdm
        '
        Me.LblXmdm.AutoSize = True
        Me.LblXmdm.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblXmdm.Location = New System.Drawing.Point(97, 177)
        Me.LblXmdm.Name = "LblXmdm"
        Me.LblXmdm.Size = New System.Drawing.Size(98, 18)
        Me.LblXmdm.TabIndex = 9
        Me.LblXmdm.Text = "项目编码："
        '
        'TxtKhdm
        '
        Me.TxtKhdm.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtKhdm.Location = New System.Drawing.Point(211, 208)
        Me.TxtKhdm.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtKhdm.MaxLength = 12
        Me.TxtKhdm.Name = "TxtKhdm"
        Me.TxtKhdm.Size = New System.Drawing.Size(128, 28)
        Me.TxtKhdm.TabIndex = 13
        '
        'LblKhdm
        '
        Me.LblKhdm.AutoSize = True
        Me.LblKhdm.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblKhdm.Location = New System.Drawing.Point(97, 213)
        Me.LblKhdm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblKhdm.Name = "LblKhdm"
        Me.LblKhdm.Size = New System.Drawing.Size(98, 18)
        Me.LblKhdm.TabIndex = 12
        Me.LblKhdm.Text = "客户编码："
        '
        'TxtCsdm
        '
        Me.TxtCsdm.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtCsdm.Location = New System.Drawing.Point(211, 244)
        Me.TxtCsdm.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCsdm.MaxLength = 12
        Me.TxtCsdm.Name = "TxtCsdm"
        Me.TxtCsdm.Size = New System.Drawing.Size(128, 28)
        Me.TxtCsdm.TabIndex = 16
        '
        'LblCsdm
        '
        Me.LblCsdm.AutoSize = True
        Me.LblCsdm.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblCsdm.Location = New System.Drawing.Point(79, 249)
        Me.LblCsdm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCsdm.Name = "LblCsdm"
        Me.LblCsdm.Size = New System.Drawing.Size(116, 18)
        Me.LblCsdm.TabIndex = 15
        Me.LblCsdm.Text = "供应商编码："
        '
        'TxtYhzh
        '
        Me.TxtYhzh.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtYhzh.Location = New System.Drawing.Point(211, 280)
        Me.TxtYhzh.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtYhzh.MaxLength = 12
        Me.TxtYhzh.Name = "TxtYhzh"
        Me.TxtYhzh.Size = New System.Drawing.Size(128, 28)
        Me.TxtYhzh.TabIndex = 19
        '
        'LblYhzh
        '
        Me.LblYhzh.AutoSize = True
        Me.LblYhzh.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblYhzh.Location = New System.Drawing.Point(97, 285)
        Me.LblYhzh.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblYhzh.Name = "LblYhzh"
        Me.LblYhzh.Size = New System.Drawing.Size(98, 18)
        Me.LblYhzh.TabIndex = 18
        Me.LblYhzh.Text = "银行账号："
        '
        'TxtJxzh
        '
        Me.TxtJxzh.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtJxzh.Location = New System.Drawing.Point(211, 316)
        Me.TxtJxzh.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtJxzh.MaxLength = 12
        Me.TxtJxzh.Name = "TxtJxzh"
        Me.TxtJxzh.Size = New System.Drawing.Size(128, 28)
        Me.TxtJxzh.TabIndex = 21
        '
        'LblJxzh
        '
        Me.LblJxzh.AutoSize = True
        Me.LblJxzh.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblJxzh.Location = New System.Drawing.Point(97, 321)
        Me.LblJxzh.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblJxzh.Name = "LblJxzh"
        Me.LblJxzh.Size = New System.Drawing.Size(98, 18)
        Me.LblJxzh.TabIndex = 20
        Me.LblJxzh.Text = "计息账号："
        '
        'LblBmmc
        '
        Me.LblBmmc.AutoSize = True
        Me.LblBmmc.Location = New System.Drawing.Point(355, 105)
        Me.LblBmmc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBmmc.Name = "LblBmmc"
        Me.LblBmmc.Size = New System.Drawing.Size(80, 18)
        Me.LblBmmc.TabIndex = 5
        Me.LblBmmc.Text = "部门名称"
        '
        'LblZymc
        '
        Me.LblZymc.AutoSize = True
        Me.LblZymc.Location = New System.Drawing.Point(355, 141)
        Me.LblZymc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblZymc.Name = "LblZymc"
        Me.LblZymc.Size = New System.Drawing.Size(80, 18)
        Me.LblZymc.TabIndex = 8
        Me.LblZymc.Text = "职员姓名"
        '
        'LblXmmc
        '
        Me.LblXmmc.AutoSize = True
        Me.LblXmmc.Location = New System.Drawing.Point(355, 177)
        Me.LblXmmc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblXmmc.Name = "LblXmmc"
        Me.LblXmmc.Size = New System.Drawing.Size(80, 18)
        Me.LblXmmc.TabIndex = 11
        Me.LblXmmc.Text = "项目名称"
        '
        'LblKhmc
        '
        Me.LblKhmc.AutoSize = True
        Me.LblKhmc.Location = New System.Drawing.Point(355, 213)
        Me.LblKhmc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblKhmc.Name = "LblKhmc"
        Me.LblKhmc.Size = New System.Drawing.Size(80, 18)
        Me.LblKhmc.TabIndex = 14
        Me.LblKhmc.Text = "客户名称"
        '
        'LblCsmc
        '
        Me.LblCsmc.AutoSize = True
        Me.LblCsmc.Location = New System.Drawing.Point(355, 249)
        Me.LblCsmc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCsmc.Name = "LblCsmc"
        Me.LblCsmc.Size = New System.Drawing.Size(98, 18)
        Me.LblCsmc.TabIndex = 17
        Me.LblCsmc.Text = "供应商名称"
        '
        'RdoBtnJie
        '
        Me.RdoBtnJie.AutoSize = True
        Me.RdoBtnJie.Checked = True
        Me.RdoBtnJie.Location = New System.Drawing.Point(211, 352)
        Me.RdoBtnJie.Name = "RdoBtnJie"
        Me.RdoBtnJie.Size = New System.Drawing.Size(51, 22)
        Me.RdoBtnJie.TabIndex = 23
        Me.RdoBtnJie.TabStop = True
        Me.RdoBtnJie.Text = "借"
        Me.RdoBtnJie.UseVisualStyleBackColor = True
        '
        'RdoBtnDai
        '
        Me.RdoBtnDai.AutoSize = True
        Me.RdoBtnDai.Location = New System.Drawing.Point(278, 352)
        Me.RdoBtnDai.Name = "RdoBtnDai"
        Me.RdoBtnDai.Size = New System.Drawing.Size(51, 22)
        Me.RdoBtnDai.TabIndex = 24
        Me.RdoBtnDai.Text = "贷"
        Me.RdoBtnDai.UseVisualStyleBackColor = True
        '
        'LblKjnd
        '
        Me.LblKjnd.AutoSize = True
        Me.LblKjnd.Location = New System.Drawing.Point(107, 22)
        Me.LblKjnd.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblKjnd.Name = "LblKjnd"
        Me.LblKjnd.Size = New System.Drawing.Size(98, 18)
        Me.LblKjnd.TabIndex = 34
        Me.LblKjnd.Text = "会计年度："
        '
        'FrmQckmyeSr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(627, 566)
        Me.Controls.Add(Me.LblKjnd)
        Me.Controls.Add(Me.RdoBtnDai)
        Me.Controls.Add(Me.RdoBtnJie)
        Me.Controls.Add(Me.LblCsmc)
        Me.Controls.Add(Me.LblKhmc)
        Me.Controls.Add(Me.LblXmmc)
        Me.Controls.Add(Me.LblZymc)
        Me.Controls.Add(Me.LblBmmc)
        Me.Controls.Add(Me.TxtJxzh)
        Me.Controls.Add(Me.LblJxzh)
        Me.Controls.Add(Me.TxtYhzh)
        Me.Controls.Add(Me.LblYhzh)
        Me.Controls.Add(Me.TxtCsdm)
        Me.Controls.Add(Me.LblCsdm)
        Me.Controls.Add(Me.TxtKhdm)
        Me.Controls.Add(Me.LblKhdm)
        Me.Controls.Add(Me.TxtXmdm)
        Me.Controls.Add(Me.LblXmdm)
        Me.Controls.Add(Me.TxtZydm)
        Me.Controls.Add(Me.LblZydm)
        Me.Controls.Add(Me.TxtBmdm)
        Me.Controls.Add(Me.LblBmdm)
        Me.Controls.Add(Me.TxtNcsl)
        Me.Controls.Add(Me.LblNcsl)
        Me.Controls.Add(Me.TxtNcje)
        Me.Controls.Add(Me.LblNcje)
        Me.Controls.Add(Me.LblBz)
        Me.Controls.Add(Me.LblDw)
        Me.Controls.Add(Me.LblJd)
        Me.Controls.Add(Me.LblKmmc)
        Me.Controls.Add(Me.TxtNcwb)
        Me.Controls.Add(Me.LblNcwb)
        Me.Controls.Add(Me.TxtKmdm)
        Me.Controls.Add(Me.LblKmdm)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmQckmyeSr"
        Me.Text = "期初总账余额装入"
        Me.Controls.SetChildIndex(Me.DlgPanel, 0)
        Me.Controls.SetChildIndex(Me.LblKmdm, 0)
        Me.Controls.SetChildIndex(Me.TxtKmdm, 0)
        Me.Controls.SetChildIndex(Me.LblNcwb, 0)
        Me.Controls.SetChildIndex(Me.TxtNcwb, 0)
        Me.Controls.SetChildIndex(Me.LblKmmc, 0)
        Me.Controls.SetChildIndex(Me.LblJd, 0)
        Me.Controls.SetChildIndex(Me.LblDw, 0)
        Me.Controls.SetChildIndex(Me.LblBz, 0)
        Me.Controls.SetChildIndex(Me.LblNcje, 0)
        Me.Controls.SetChildIndex(Me.TxtNcje, 0)
        Me.Controls.SetChildIndex(Me.LblNcsl, 0)
        Me.Controls.SetChildIndex(Me.TxtNcsl, 0)
        Me.Controls.SetChildIndex(Me.LblBmdm, 0)
        Me.Controls.SetChildIndex(Me.TxtBmdm, 0)
        Me.Controls.SetChildIndex(Me.LblZydm, 0)
        Me.Controls.SetChildIndex(Me.TxtZydm, 0)
        Me.Controls.SetChildIndex(Me.LblXmdm, 0)
        Me.Controls.SetChildIndex(Me.TxtXmdm, 0)
        Me.Controls.SetChildIndex(Me.LblKhdm, 0)
        Me.Controls.SetChildIndex(Me.TxtKhdm, 0)
        Me.Controls.SetChildIndex(Me.LblCsdm, 0)
        Me.Controls.SetChildIndex(Me.TxtCsdm, 0)
        Me.Controls.SetChildIndex(Me.LblYhzh, 0)
        Me.Controls.SetChildIndex(Me.TxtYhzh, 0)
        Me.Controls.SetChildIndex(Me.LblJxzh, 0)
        Me.Controls.SetChildIndex(Me.TxtJxzh, 0)
        Me.Controls.SetChildIndex(Me.LblBmmc, 0)
        Me.Controls.SetChildIndex(Me.LblZymc, 0)
        Me.Controls.SetChildIndex(Me.LblXmmc, 0)
        Me.Controls.SetChildIndex(Me.LblKhmc, 0)
        Me.Controls.SetChildIndex(Me.LblCsmc, 0)
        Me.Controls.SetChildIndex(Me.RdoBtnJie, 0)
        Me.Controls.SetChildIndex(Me.RdoBtnDai, 0)
        Me.Controls.SetChildIndex(Me.LblKjnd, 0)
        Me.DlgPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents TxtNcje As System.Windows.Forms.TextBox
    Public WithEvents LblNcje As System.Windows.Forms.Label
    Public WithEvents LblBz As System.Windows.Forms.Label
    Public WithEvents LblDw As System.Windows.Forms.Label
    Public WithEvents LblJd As System.Windows.Forms.Label
    Public WithEvents LblKmmc As System.Windows.Forms.Label
    Public WithEvents TxtNcwb As System.Windows.Forms.TextBox
    Public WithEvents LblNcwb As System.Windows.Forms.Label
    Public WithEvents TxtKmdm As System.Windows.Forms.TextBox
    Public WithEvents LblKmdm As System.Windows.Forms.Label
    Public WithEvents TxtNcsl As System.Windows.Forms.TextBox
    Public WithEvents LblNcsl As System.Windows.Forms.Label
    Friend WithEvents TxtBmdm As TextBox
    Friend WithEvents LblBmdm As Label
    Public WithEvents TxtZydm As TextBox
    Public WithEvents LblZydm As Label
    Friend WithEvents TxtXmdm As TextBox
    Friend WithEvents LblXmdm As Label
    Friend WithEvents TxtKhdm As TextBox
    Friend WithEvents LblKhdm As Label
    Friend WithEvents TxtCsdm As TextBox
    Friend WithEvents LblCsdm As Label
    Friend WithEvents TxtYhzh As TextBox
    Friend WithEvents LblYhzh As Label
    Friend WithEvents TxtJxzh As TextBox
    Friend WithEvents LblJxzh As Label
    Public WithEvents LblBmmc As Label
    Public WithEvents LblZymc As Label
    Public WithEvents LblXmmc As Label
    Public WithEvents LblKhmc As Label
    Public WithEvents LblCsmc As Label
    Friend WithEvents RdoBtnJie As RadioButton
    Friend WithEvents RdoBtnDai As RadioButton
    Public WithEvents LblKjnd As Label
End Class
