Imports System.Data.OleDb

Public Class FrmOeKhFpFxb
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '数据OleDb更新传递
    Dim rcOleDbTrans As OleDbTransaction
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = sysOleDbConn.CreateCommand()
    '建立Datatable
    ReadOnly dtOeKhFpFxb As New DataTable("oekhfpfxb")

    Private Sub FrmOeKhFpFxb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        '默认值
        NudYear.Value = Mid(g_Kjqj, 1, 4)
        NudMonth.Value = Mid(g_Kjqj, 5, 2)
        ''创建datatable
        'dtOeKhFpFxb.Columns.Add("khlbdm", Type.GetType("System.String"))
        'dtOeKhFpFxb.Columns.Add("khlbmc", Type.GetType("System.String"))
        'dtOeKhFpFxb.Columns.Add("khdm", Type.GetType("System.String"))
        'dtOeKhFpFxb.Columns.Add("khmc", Type.GetType("System.String"))
        'dtOeKhFpFxb.Columns.Add("zydm", Type.GetType("System.String"))
        'dtOeKhFpFxb.Columns.Add("zymc", Type.GetType("System.String"))
        'dtOeKhFpFxb.Columns.Add("cplbdm", Type.GetType("System.String"))
        'dtOeKhFpFxb.Columns.Add("cplbmc", Type.GetType("System.String"))
        'dtOeKhFpFxb.Columns.Add("bysl", Type.GetType("System.Double"))
        'dtOeKhFpFxb.Columns.Add("sysl", Type.GetType("System.Double"))
        'dtOeKhFpFxb.Columns.Add("snsl", Type.GetType("System.Double"))
        'dtOeKhFpFxb.Columns.Add("byfzsl", Type.GetType("System.Double"))
        'dtOeKhFpFxb.Columns.Add("syfzsl", Type.GetType("System.Double"))
        'dtOeKhFpFxb.Columns.Add("sbfzsl", Type.GetType("System.Double"))
        'dtOeKhFpFxb.Columns.Add("byje", Type.GetType("System.Double"))
        'dtOeKhFpFxb.Columns.Add("syje", Type.GetType("System.Double"))
        'dtOeKhFpFxb.Columns.Add("snje", Type.GetType("System.Double"))
        'dtOeKhFpFxb.Columns.Add("byse", Type.GetType("System.Double"))
        'dtOeKhFpFxb.Columns.Add("syse", Type.GetType("System.Double"))
        'dtOeKhFpFxb.Columns.Add("snse", Type.GetType("System.Double"))
        'dtOeKhFpFxb.Columns.Add("bycbje", Type.GetType("System.Double"))
        'dtOeKhFpFxb.Columns.Add("sycbje", Type.GetType("System.Double"))
        'dtOeKhFpFxb.Columns.Add("sncbje", Type.GetType("System.Double"))
        'dtOeKhFpFxb.Columns.Add("bymle", Type.GetType("System.Double"))
        'dtOeKhFpFxb.Columns.Add("symle", Type.GetType("System.Double"))
        'dtOeKhFpFxb.Columns.Add("snmle", Type.GetType("System.Double"))
        'dtOeKhFpFxb.Columns.Add("bymll", Type.GetType("System.Double"))
        'dtOeKhFpFxb.Columns.Add("symll", Type.GetType("System.Double"))
        'dtOeKhFpFxb.Columns.Add("snmll", Type.GetType("System.Double"))
        'rcDataset.Tables.Add(dtOeKhFpFxb)
        'With dtOeKhFpFxb
        '    .Columns("khlbdm").DefaultValue = ""
        '    .Columns("khdm").DefaultValue = ""
        '    .Columns("zydm").DefaultValue = ""
        '    .Columns("cplbdm").DefaultValue = ""
        '    .Columns("bysl").DefaultValue = 0.0
        '    .Columns("sysl").DefaultValue = 0.0
        '    .Columns("snsl").DefaultValue = 0.0
        '    .Columns("byfzsl").DefaultValue = 0.0
        '    .Columns("syfasl").DefaultValue = 0.0
        '    .Columns("snfzsl").DefaultValue = 0.0
        '    .Columns("byje").DefaultValue = 0.0
        '    .Columns("syje").DefaultValue = 0.0
        '    .Columns("snje").DefaultValue = 0.0
        '    .Columns("byse").DefaultValue = 0.0
        '    .Columns("syse").DefaultValue = 0.0
        '    .Columns("snse").DefaultValue = 0.0
        '    .Columns("bycbje").DefaultValue = 0.0
        '    .Columns("sycbje").DefaultValue = 0.0
        '    .Columns("sncbje").DefaultValue = 0.0
        '    .Columns("bymle").DefaultValue = 0.0
        '    .Columns("symle").DefaultValue = 0.0
        '    .Columns("snmle").DefaultValue = 0.0
        '    .Columns("bymll").DefaultValue = 0.0
        '    .Columns("symll").DefaultValue = 0.0
        '    .Columns("snmll").DefaultValue = 0.0
        'End With
    End Sub

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLbdm.KeyPress, TxtBmdm.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#Region "客户类别编码的事件"

    Private Sub Txtlbdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLbdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .ParaOleDbConn = rcOleDbConn
                    .ParaTableName = "rc_khlb"
                    .ParaField1 = "lbdm"
                    .ParaField2 = "lbmc"
                    .ParaField3 = "lbsm"
                    .ParaTitle = "客户类别"
                    .ParaOldValue = ""
                    .ParaAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtLbdm.Text = Trim(.ParaField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub Txtlbdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtLbdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtLbdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_khlb WHERE (lbdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = Trim(TxtLbdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_khlb") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_khlb").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_khlb")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_khlb").Rows.Count > 0 Then
                TxtLbdm.Text = Trim(rcDataset.Tables("rc_khlb").Rows(0).Item("lbdm"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "部门编码的事件"

    Private Sub TxtBmdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBmdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .ParaOleDbConn = rcOleDbConn
                    .ParaTableName = "rc_bmxx"
                    .ParaField1 = "bmdm"
                    .ParaField2 = "bmmc"
                    .ParaField3 = "bmsm"
                    .ParaTitle = "部门"
                    .ParaOldValue = ""
                    .ParaAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtBmdm.Text = Trim(.ParaField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtBmdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtBmdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtBmdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT bmdm,bmmc FROM rc_bmxx WHERE (bmdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(TxtBmdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_bmxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_bmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_bmxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_bmxx").Rows.Count > 0 Then
                TxtBmdm.Text = Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmdm"))
            Else
                MsgBox("部门编码不存在，请按F3键选择。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim dateByBegin As Date = GetInvBegin(Me.NudYear.Value, Me.NudMonth.Value)
        Dim dateByEnd As Date = GetInvEnd(Me.NudYear.Value, Me.NudMonth.Value)
        Dim dateSyBegin As Date = GetInvBegin(IIf(Me.NudMonth.Value = 1, Me.NudYear.Value - 1, Me.NudYear.Value), IIf(Me.NudMonth.Value = 1, 12, Me.NudMonth.Value - 1))
        Dim dateSyEnd As Date = GetInvEnd(IIf(Me.NudMonth.Value = 1, Me.NudYear.Value - 1, Me.NudYear.Value), IIf(Me.NudMonth.Value = 1, 12, Me.NudMonth.Value - 1))
        Dim dateSnBegin As Date = GetInvBegin(Me.NudYear.Value - 1, Me.NudMonth.Value)
        Dim dateSnEnd As Date = GetInvEnd(Me.NudYear.Value - 1, Me.NudMonth.Value)



        dtOeKhFpFxb.Clear()
        '取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '创建临时表
            Me.LblMsg.Text = "正在创建临时表，请稍候......"
            rcOleDbCommand.CommandText = "SELECT * FROM user_tables WHERE table_name='T_OEKHFPFXB'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count > 0 Then
                rcOleDbCommand.CommandText = "DROP Table t_oekhfpfxb"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            End If
            rcOleDbCommand.CommandText = "Create Global Temporary Table t_oekhfpfxb (khlbdm varchar2(15),khlbmc varchar2(200),khdm varchar2(15),khmc varchar2(200),zydm varchar2(12),zymc varchar2(200),cplbdm varchar2(12),cplbmc varchar2(200),bysl number(18,6),sysl number(18,6),snsl number(18,6),byfzsl number(18,6),syfzsl number(18,6),snfzsl number(18,6),byje number(14,2),syje number(14,2),snje number(14,2),byse number(14,2),syse number(14,2),snse number(14,2),bycbje number(14,2),sycbje number(14,2),sncbje number(14,2),bymle number(14,2),symle number(14,2),snmle number(14,2),bymll number(18,6),symll number(18,6),snmll number(18,6)) on Commit delete Rows"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.ExecuteNonQuery()
            'rcOleDbCommand.CommandText = "alter table T_OEKHFPFXB  add constraint PK_OEKHFPFXB primary key (KHDM,ZYDM)"
            'rcOleDbCommand.Parameters.Clear()
            'rcOleDbCommand.ExecuteNonQuery()
            Me.LblMsg.Text = "正在插入本月数据，请稍候......"
            If Me.ChbLb.Checked Then
                rcOleDbCommand.CommandText = "INSERT INTO t_oekhfpfxb (khlbdm,khlbmc,khdm,khmc,zydm,zymc,cplbdm,cplbmc,bysl,byfzsl,byje,byse,bycbje,bymle,bymll) SELECT oekhfpfxbc.khlbdm,rc_khlb.lbmc AS khlbmc,oekhfpfxbc.khdm,oekhfpfxbc.khmc,oekhfpfxbc.zydm,oekhfpfxbc.zymc,oekhfpfxbc.cplbdm,rc_cplb.lbmc AS cplbmc,oekhfpfxbc.sl AS bysy,oekhfpfxbc.fzsl AS byfzsl,oekhfpfxbc.je AS byje,oekhfpfxbc.se AS byse,oekhfpfxbc.cbje AS bycbje,oekhfpfxbc.mle AS bymle,oekhfpfxbc.bymll FROM (SELECT oekhfpfxbb.khlbdm,oekhfpfxbb.khdm,oekhfpfxbb.khmc,oekhfpfxbb.zydm,oekhfpfxbb.zymc,oekhfpfxbb.cplbdm,oekhfpfxbb.sl,oekhfpfxbb.fzsl,oekhfpfxbb.je,oekhfpfxbb.se,oekhfpfxbb.cbje,(oekhfpfxbb.je-oekhfpfxbb.cbje) AS mle,CASE WHEN oekhfpfxbb.je <> 0 THEN (oekhfpfxbb.je-oekhfpfxbb.cbje) / oekhfpfxbb.je ELSE 0 END AS bymll FROM (SELECT oekhfpfxba.khdm,oekhfpfxba.khmc,rc_khxx.zydm,rc_khxx.zymc,oekhfpfxba.cplbdm,oekhfpfxba.sl,oekhfpfxba.fzsl,oekhfpfxba.je,oekhfpfxba.se,oekhfpfxba.cbje,rc_khxx.lbdm AS khlbdm FROM (SELECT oe_fp.shkhdm AS khdm,oe_fp.shkhmc AS khmc,rc_cpxx.lbdm AS cplbdm,SUM(oe_fp.sl) AS sl,SUM(oe_fp.sl * rc_cpxx.cpweight/1000) AS fzsl,SUM(oe_fp.je) AS je,SUM(oe_fp.se) AS se,SUM(oe_fp.cbje) AS cbje FROM oe_fp,rc_lx,rc_cpxx WHERE SUBSTR(oe_fp.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_fp.djh,5,4) = rc_lx.kjnd AND lxgs = '产品销售单' AND oe_fp.cpdm = rc_cpxx.cpdm AND oe_fp.bdelete = 0 AND oe_fp.fprq >= ? AND oe_fp.fprq >= ? AND oe_fp.fprq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_fp.bmdm = '" & Me.TxtBmdm.Text & "'", "") & " GROUP BY oe_fp.shkhdm,oe_fp.shkhmc,rc_cpxx.lbdm) oekhfpfxba LEFT JOIN rc_khxx ON oekhfpfxba.khdm = rc_khxx.khdm) oekhfpfxbb " & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " WHERE khlbdm = '" & Me.TxtLbdm.Text & "'", "") & ") oekhfpfxbc LEFT JOIN rc_khlb ON oekhfpfxbc.khlbdm = rc_khlb.lbdm LEFT JOIN rc_cplb ON oekhfpfxbc.cplbdm = rc_cplb.lbdm"
            Else
                rcOleDbCommand.CommandText = "INSERT INTO t_oekhfpfxb (khlbdm,khlbmc,khdm,khmc,zydm,zymc,bysl,byfzsl,byje,byse,bycbje,bymle,bymll)SELECT oekhfpfxbc.khlbdm,rc_khlb.lbmc AS khlbmc,oekhfpfxbc.khdm,oekhfpfxbc.khmc,oekhfpfxbc.zydm,oekhfpfxbc.zymc,oekhfpfxbc.sl AS,oekhfpfxbc.fzsl,oekhfpfxbc.je,oekhfpfxbc.se,oekhfpfxbc.cbje,oekhfpfxbc.mle,oekhfpfxbc.bymll FROM (SELECT oekhfpfxbb.khlbdm,oekhfpfxbb.khdm,oekhfpfxbb.khmc,oekhfpfxbb.zydm,oekhfpfxbb.zymc,oekhfpfxbb.sl,oekhfpfxbb.fzsl,oekhfpfxbb.je,oekhfpfxbb.se,oekhfpfxbb.cbje,(oekhfpfxbb.je-oekhfpfxbb.cbje) AS mle,CASE WHEN oekhfpfxbb.je <> 0 THEN (oekhfpfxbb.je-oekhfpfxbb.cbje) / oekhfpfxbb.je ELSE 0 END AS bymll FROM (SELECT oekhfpfxba.khdm,oekhfpfxba.khmc,rc_khxx.zydm,rc_khxx.zymc,oekhfpfxba.sl,oekhfpfxba.fzsl,oekhfpfxba.je,oekhfpfxba.se,oekhfpfxba.cbje,rc_khxx.lbdm AS khlbdm FROM (SELECT oe_fp.shkhdm AS khdm,oe_fp.shkhmc AS khmc,SUM(oe_fp.sl) AS sl,SUM(oe_fp.sl * rc_cpxx.cpweight/1000) AS fzsl,SUM(oe_fp.je) AS je,SUM(oe_fp.se) AS se,SUM(oe_fp.cbje) AS cbje FROM oe_fp,rc_lx,rc_cpxx WHERE SUBSTR(oe_fp.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_fp.djh,5,4) = rc_lx.kjnd AND lxgs = '产品销售单' AND oe_fp.cpdm = rc_cpxx.cpdm AND oe_fp.bdelete = 0 AND oe_fp.fprq >= ? AND oe_fp.fprq >= ? AND oe_fp.fprq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_fp.bmdm = '" & Me.TxtBmdm.Text & "'", "") & " GROUP BY oe_fp.shkhdm,oe_fp.shkhmc) oekhfpfxba LEFT JOIN rc_khxx ON oekhfpfxba.khdm = rc_khxx.khdm) oekhfpfxbb " & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " WHERE khlbdm = '" & Me.TxtLbdm.Text & "'", "") & ") oekhfpfxbc LEFT JOIN rc_khlb ON oekhfpfxbc.khlbdm = rc_khlb.lbdm"
            End If
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateByBegin
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateByEnd
            rcOleDbCommand.ExecuteNonQuery()
            Me.LblMsg.Text = "正在插入上月数据，请稍候......"
            If Me.ChbLb.Checked Then
                rcOleDbCommand.CommandText = "INSERT INTO t_oekhfpfxb (khlbdm,khlbmc,khdm,khmc,zydm,zymc,cplbdm,cplbmc,sysl,syfzsl,syje,syse,sycbje,symle,symll) SELECT oekhfpfxbc.khlbdm,rc_khlb.lbmc AS khlbmc,oekhfpfxbc.khdm,oekhfpfxbc.khmc,oekhfpfxbc.zydm,oekhfpfxbc.zymc,oekhfpfxbc.cplbdm,rc_cplb.lbmc AS cplbmc,oekhfpfxbc.sl,oekhfpfxbc.fzsl,oekhfpfxbc.je,oekhfpfxbc.se,oekhfpfxbc.cbje,oekhfpfxbc.mle,oekhfpfxbc.symll FROM (SELECT oekhfpfxbb.khlbdm,oekhfpfxbb.khdm,oekhfpfxbb.khmc,oekhfpfxbb.zydm,oekhfpfxbb.zymc,oekhfpfxbb.cplbdm,oekhfpfxbb.sl,oekhfpfxbb.fzsl,oekhfpfxbb.je,oekhfpfxbb.se,oekhfpfxbb.cbje,(oekhfpfxbb.je-oekhfpfxbb.cbje) AS mle,CASE WHEN oekhfpfxbb.je <> 0 THEN (oekhfpfxbb.je-oekhfpfxbb.cbje) / oekhfpfxbb.je ELSE 0 END AS symll FROM (SELECT oekhfpfxba.khdm,oekhfpfxba.khmc,rc_khxx.zydm,rc_khxx.zymc,oekhfpfxba.cplbdm,oekhfpfxba.sl,oekhfpfxba.fzsl,oekhfpfxba.je,oekhfpfxba.se,oekhfpfxba.cbje,rc_khxx.lbdm AS khlbdm FROM (SELECT oe_fp.shkhdm AS khdm,oe_fp.shkhmc AS khmc,rc_cpxx.lbdm AS cplbdm,SUM(oe_fp.sl) AS sl,SUM(oe_fp.sl * rc_cpxx.cpweight/1000) AS fzsl,SUM(oe_fp.je) AS je,SUM(oe_fp.se) AS se,SUM(oe_fp.cbje) AS cbje FROM oe_fp,rc_lx,rc_cpxx WHERE SUBSTR(oe_fp.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_fp.djh,5,4) = rc_lx.kjnd AND lxgs = '产品销售单' AND oe_fp.cpdm = rc_cpxx.cpdm AND oe_fp.bdelete = 0 AND oe_fp.fprq >= ? AND oe_fp.fprq >= ? AND oe_fp.fprq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_fp.bmdm = '" & Me.TxtBmdm.Text & "'", "") & " GROUP BY oe_fp.shkhdm,oe_fp.shkhmc,rc_cpxx.lbdm) oekhfpfxba LEFT JOIN rc_khxx ON oekhfpfxba.khdm = rc_khxx.khdm) oekhfpfxbb " & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " WHERE khlbdm = '" & Me.TxtLbdm.Text & "'", "") & ") oekhfpfxbc LEFT JOIN rc_khlb ON oekhfpfxbc.khlbdm = rc_khlb.lbdm LEFT JOIN rc_cplb ON oekhfpfxbc.cplbdm = rc_cplb.lbdm"
            Else
                rcOleDbCommand.CommandText = "INSERT INTO t_oekhfpfxb (khlbdm,khlbmc,khdm,khmc,zydm,zymc,sysl,syfzsl,syje,syse,sycbje,symle,symll)SELECT oekhfpfxbc.khlbdm,rc_khlb.lbmc AS khlbmc,oekhfpfxbc.khdm,oekhfpfxbc.khmc,oekhfpfxbc.zydm,oekhfpfxbc.zymc,oekhfpfxbc.sl,oekhfpfxbc.fzsl,oekhfpfxbc.je,oekhfpfxbc.se,oekhfpfxbc.cbje,oekhfpfxbc.mle,oekhfpfxbc.symll FROM (SELECT oekhfpfxbb.khlbdm,oekhfpfxbb.khdm,oekhfpfxbb.khmc,oekhfpfxbb.zydm,oekhfpfxbb.zymc,oekhfpfxbb.sl,oekhfpfxbb.fzsl,oekhfpfxbb.je,oekhfpfxbb.se,oekhfpfxbb.cbje,(oekhfpfxbb.je-oekhfpfxbb.cbje) AS mle,CASE WHEN oekhfpfxbb.je <> 0 THEN (oekhfpfxbb.je-oekhfpfxbb.cbje) / oekhfpfxbb.je ELSE 0 END AS symll FROM (SELECT oekhfpfxba.khdm,oekhfpfxba.khmc,rc_khxx.zydm,rc_khxx.zymc,oekhfpfxba.sl,oekhfpfxba.fzsl,oekhfpfxba.je,oekhfpfxba.se,oekhfpfxba.cbje,rc_khxx.lbdm AS khlbdm FROM (SELECT oe_fp.shkhdm AS khdm,oe_fp.shkhmc AS khmc,SUM(oe_fp.sl) AS sl,SUM(oe_fp.sl * rc_cpxx.cpweight/1000) AS fzsl,SUM(oe_fp.je) AS je,SUM(oe_fp.se) AS se,SUM(oe_fp.cbje) AS cbje FROM oe_fp,rc_lx,rc_cpxx WHERE SUBSTR(oe_fp.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_fp.djh,5,4) = rc_lx.kjnd AND lxgs = '产品销售单' AND oe_fp.cpdm = rc_cpxx.cpdm AND oe_fp.bdelete = 0 AND oe_fp.fprq >= ? AND oe_fp.fprq >= ? AND oe_fp.fprq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_fp.bmdm = '" & Me.TxtBmdm.Text & "'", "") & " GROUP BY oe_fp.shkhdm,oe_fp.shkhmc) oekhfpfxba LEFT JOIN rc_khxx ON oekhfpfxba.khdm = rc_khxx.khdm) oekhfpfxbb " & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " WHERE khlbdm = '" & Me.TxtLbdm.Text & "'", "") & ") oekhfpfxbc LEFT JOIN rc_khlb ON oekhfpfxbc.khlbdm = rc_khlb.lbdm"
            End If
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateSyBegin
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateSyEnd
            rcOleDbCommand.ExecuteNonQuery()
            Me.LblMsg.Text = "正在插入上年数据，请稍候......"
            If Not Me.CheckBox1.Checked Then
                '取销售发票的数据
                If Me.ChbLb.Checked Then
                    rcOleDbCommand.CommandText = "INSERT INTO t_oekhfpfxb (khlbdm,khlbmc,khdm,khmc,zydm,zymc,cplbdm,cplbmc,snsl,snfzsl,snje,snse,sncbje,snmle,snmll) SELECT oekhfpfxbc.khlbdm,rc_khlb.lbmc AS khlbmc,oekhfpfxbc.khdm,oekhfpfxbc.khmc,oekhfpfxbc.zydm,oekhfpfxbc.zymc,oekhfpfxbc.cplbdm,rc_cplb.lbmc AS cplbmc,oekhfpfxbc.sl,oekhfpfxbc.fzsl,oekhfpfxbc.je,oekhfpfxbc.se,oekhfpfxbc.cbje,oekhfpfxbc.mle,oekhfpfxbc.snmll FROM (SELECT oekhfpfxbb.khlbdm,oekhfpfxbb.khdm,oekhfpfxbb.khmc,oekhfpfxbb.zydm,oekhfpfxbb.zymc,oekhfpfxbb.cplbdm,oekhfpfxbb.sl,oekhfpfxbb.fzsl,oekhfpfxbb.je,oekhfpfxbb.se,oekhfpfxbb.cbje,(oekhfpfxbb.je-oekhfpfxbb.cbje) AS mle,CASE WHEN oekhfpfxbb.je <> 0 THEN (oekhfpfxbb.je-oekhfpfxbb.cbje) / oekhfpfxbb.je ELSE 0 END AS snmll FROM (SELECT oekhfpfxba.khdm,oekhfpfxba.khmc,rc_khxx.zydm,rc_khxx.zymc,oekhfpfxba.cplbdm,oekhfpfxba.sl,oekhfpfxba.fzsl,oekhfpfxba.je,oekhfpfxba.se,oekhfpfxba.cbje,rc_khxx.lbdm AS khlbdm FROM (SELECT oe_fp.shkhdm AS khdm,oe_fp.shkhmc AS khmc,rc_cpxx.lbdm AS cplbdm,SUM(oe_fp.sl) AS sl,SUM(oe_fp.sl * rc_cpxx.cpweight/1000) AS fzsl,SUM(oe_fp.je) AS je,SUM(oe_fp.se) AS se,SUM(oe_fp.cbje) AS cbje FROM oe_fp,rc_lx,rc_cpxx WHERE SUBSTR(oe_fp.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_fp.djh,5,4) = rc_lx.kjnd AND lxgs = '产品销售单' AND oe_fp.cpdm = rc_cpxx.cpdm AND oe_fp.bdelete = 0 AND oe_fp.fprq >= ? AND oe_fp.fprq >= ? AND oe_fp.fprq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_fp.bmdm = '" & Me.TxtBmdm.Text & "'", "") & " GROUP BY oe_fp.shkhdm,oe_fp.shkhmc,rc_cpxx.lbdm) oekhfpfxba LEFT JOIN rc_khxx ON oekhfpfxba.khdm = rc_khxx.khdm) oekhfpfxbb " & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " WHERE khlbdm = '" & Me.TxtLbdm.Text & "'", "") & ") oekhfpfxbc LEFT JOIN rc_khlb ON oekhfpfxbc.khlbdm = rc_khlb.lbdm LEFT JOIN rc_cplb ON oekhfpfxbc.cplbdm = rc_cplb.lbdm"
                Else
                    rcOleDbCommand.CommandText = "INSERT INTO t_oekhfpfxb (khlbdm,khlbmc,khdm,khmc,zydm,zymc,snsl,snfzsl,snje,snse,sncbje,snmle,snmll)SELECT oekhfpfxbc.khlbdm,rc_khlb.lbmc AS khlbmc,oekhfpfxbc.khdm,oekhfpfxbc.khmc,oekhfpfxbc.zydm,oekhfpfxbc.zymc,oekhfpfxbc.sl,oekhfpfxbc.fzsl,oekhfpfxbc.je,oekhfpfxbc.se,oekhfpfxbc.cbje,oekhfpfxbc.mle,oekhfpfxbc.snmll FROM (SELECT oekhfpfxbb.khlbdm,oekhfpfxbb.khdm,oekhfpfxbb.khmc,oekhfpfxbb.zydm,oekhfpfxbb.zymc,oekhfpfxbb.sl,oekhfpfxbb.fzsl,oekhfpfxbb.je,oekhfpfxbb.se,oekhfpfxbb.cbje,(oekhfpfxbb.je-oekhfpfxbb.cbje) AS mle,CASE WHEN oekhfpfxbb.je <> 0 THEN (oekhfpfxbb.je-oekhfpfxbb.cbje) / oekhfpfxbb.je ELSE 0 END AS snmll FROM (SELECT oekhfpfxba.khdm,oekhfpfxba.khmc,rc_khxx.zydm,rc_khxx.zymc,oekhfpfxba.sl,oekhfpfxba.fzsl,oekhfpfxba.je,oekhfpfxba.se,oekhfpfxba.cbje,rc_khxx.lbdm AS khlbdm FROM (SELECT oe_fp.shkhdm AS khdm,oe_fp.shkhmc AS khmc,SUM(oe_fp.sl) AS sl,SUM(oe_fp.sl * rc_cpxx.cpweight/1000) AS fzsl,SUM(oe_fp.je) AS je,SUM(oe_fp.se) AS se,SUM(oe_fp.cbje) AS cbje FROM oe_fp,rc_lx,rc_cpxx WHERE SUBSTR(oe_fp.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_fp.djh,5,4) = rc_lx.kjnd AND lxgs = '产品销售单' AND oe_fp.cpdm = rc_cpxx.cpdm AND oe_fp.bdelete = 0 AND oe_fp.fprq >= ? AND oe_fp.fprq >= ? AND oe_fp.fprq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_fp.bmdm = '" & Me.TxtBmdm.Text & "'", "") & " GROUP BY oe_fp.shkhdm,oe_fp.shkhmc) oekhfpfxba LEFT JOIN rc_khxx ON oekhfpfxba.khdm = rc_khxx.khdm) oekhfpfxbb " & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " WHERE khlbdm = '" & Me.TxtLbdm.Text & "'", "") & ") oekhfpfxbc LEFT JOIN rc_khlb ON oekhfpfxbc.khlbdm = rc_khlb.lbdm"
                End If
            Else
                '取销售出库的数据
                If Me.ChbLb.Checked Then
                    rcOleDbCommand.CommandText = "INSERT INTO t_oekhfpfxb (khlbdm,khlbmc,khdm,khmc,zydm,zymc,cplbdm,cplbmc,snsl,snfzsl,snje,snse,sncbje,snmle,snmll) SELECT oekhfpfxbc.khlbdm,rc_khlb.lbmc AS khlbmc,oekhfpfxbc.khdm,oekhfpfxbc.khmc,oekhfpfxbc.zydm,oekhfpfxbc.zymc,oekhfpfxbc.cplbdm,rc_cplb.lbmc AS cplbmc,oekhfpfxbc.sl,oekhfpfxbc.fzsl,oekhfpfxbc.je,oekhfpfxbc.se,oekhfpfxbc.cbje,oekhfpfxbc.mle,oekhfpfxbc.snmll FROM (SELECT oekhfpfxbb.khlbdm,oekhfpfxbb.khdm,oekhfpfxbb.khmc,oekhfpfxbb.zydm,oekhfpfxbb.zymc,oekhfpfxbb.cplbdm,oekhfpfxbb.sl,oekhfpfxbb.fzsl,oekhfpfxbb.je,oekhfpfxbb.se,oekhfpfxbb.cbje,(oekhfpfxbb.je-oekhfpfxbb.cbje) AS mle,CASE WHEN oekhfpfxbb.je <> 0 THEN (oekhfpfxbb.je-oekhfpfxbb.cbje) / oekhfpfxbb.je ELSE 0 END AS snmll FROM (SELECT oekhfpfxba.khdm,oekhfpfxba.khmc,rc_khxx.zydm,rc_khxx.zymc,oekhfpfxba.cplbdm,oekhfpfxba.sl,oekhfpfxba.fzsl,oekhfpfxba.je,oekhfpfxba.se,oekhfpfxba.cbje,rc_khxx.lbdm AS khlbdm FROM (SELECT oe_xsd.khdm,oe_xsd.khmc,rc_cpxx.lbdm AS cplbdm,SUM(oe_xsd.sl) AS sl,SUM(oe_xsd.sl * rc_cpxx.cpweight/1000) AS fzsl,SUM(oe_xsd.je) AS je,SUM(oe_xsd.se) AS se,SUM(oe_xsd.cbje) AS cbje FROM oe_xsd,rc_lx,rc_cpxx WHERE SUBSTR(oe_xsd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_xsd.djh,5,4) = rc_lx.kjnd AND lxgs = '产品送货单' AND oe_xsd.cpdm = rc_cpxx.cpdm AND oe_xsd.bdelete = 0 AND oe_xsd.xsrq >= ? AND oe_xsd.xsrq >= ? AND oe_xsd.xsrq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_xsd.bmdm = '" & Me.TxtBmdm.Text & "'", "") & " GROUP BY oe_xsd.khdm,oe_xsd.khmc,rc_cpxx.lbdm) oekhfpfxba LEFT JOIN rc_khxx ON oekhfpfxba.khdm = rc_khxx.khdm) oekhfpfxbb " & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " WHERE khlbdm = '" & Me.TxtLbdm.Text & "'", "") & ") oekhfpfxbc LEFT JOIN rc_khlb ON oekhfpfxbc.khlbdm = rc_khlb.lbdm LEFT JOIN rc_cplb ON oekhfpfxbc.cplbdm = rc_cplb.lbdm"
                Else
                    rcOleDbCommand.CommandText = "INSERT INTO t_oekhfpfxb (khlbdm,khlbmc,khdm,khmc,zydm,zymc,snsl,snfzsl,snje,snse,sncbje,snmle,snmll)SELECT oekhfpfxbc.khlbdm,rc_khlb.lbmc AS khlbmc,oekhfpfxbc.khdm,oekhfpfxbc.khmc,oekhfpfxbc.zydm,oekhfpfxbc.zymc,oekhfpfxbc.sl,oekhfpfxbc.fzsl,oekhfpfxbc.je,oekhfpfxbc.se,oekhfpfxbc.cbje,oekhfpfxbc.mle,oekhfpfxbc.snmll FROM (SELECT oekhfpfxbb.khlbdm,oekhfpfxbb.khdm,oekhfpfxbb.khmc,oekhfpfxbb.zydm,oekhfpfxbb.zymc,oekhfpfxbb.sl,oekhfpfxbb.fzsl,oekhfpfxbb.je,oekhfpfxbb.se,oekhfpfxbb.cbje,(oekhfpfxbb.je-oekhfpfxbb.cbje) AS mle,CASE WHEN oekhfpfxbb.je <> 0 THEN (oekhfpfxbb.je-oekhfpfxbb.cbje) / oekhfpfxbb.je ELSE 0 END AS snmll FROM (SELECT oekhfpfxba.khdm,oekhfpfxba.khmc,rc_khxx.zydm,rc_khxx.zymc,oekhfpfxba.sl,oekhfpfxba.fzsl,oekhfpfxba.je,oekhfpfxba.se,oekhfpfxba.cbje,rc_khxx.lbdm AS khlbdm FROM (SELECT oe_xsd.khdm,oe_xsd.khmc,SUM(oe_xsd.sl) AS sl,SUM(oe_xsd.sl * rc_cpxx.cpweight/1000) AS fzsl,SUM(oe_xsd.je) AS je,SUM(oe_xsd.se) AS se,SUM(oe_xsd.cbje) AS cbje FROM oe_xsd,rc_lx,rc_cpxx WHERE SUBSTR(oe_xsd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_xsd.djh,5,4) = rc_lx.kjnd AND lxgs = '产品送货单' AND oe_xsd.cpdm = rc_cpxx.cpdm AND oe_xsd.bdelete = 0 AND oe_xsd.xsrq >= ? AND oe_xsd.xsrq >= ? AND oe_xsd.xsrq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_xsd.bmdm = '" & Me.TxtBmdm.Text & "'", "") & " GROUP BY oe_xsd.khdm,oe_xsd.khmc) oekhfpfxba LEFT JOIN rc_khxx ON oekhfpfxba.khdm = rc_khxx.khdm) oekhfpfxbb " & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " WHERE khlbdm = '" & Me.TxtLbdm.Text & "'", "") & ") oekhfpfxbc LEFT JOIN rc_khlb ON oekhfpfxbc.khlbdm = rc_khlb.lbdm"
                End If

            End If
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateSnBegin
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateSnEnd
            rcOleDbCommand.ExecuteNonQuery()
            Me.LblMsg.Text = "正在读取数据，请稍候......"
            If Me.CheckBox2.Checked Then
                rcOleDbCommand.CommandText = "SELECT cplbdm,cplbmc,SUM(bysl) AS bysl,SUM(sysl) AS sysl,SUM(snsl) AS snsl,SUM(byfzsl) AS byfzsl,SUM(syfzsl) AS syfzsl,SUM(snfzsl) AS snfzsl,CASE WHEN SUM(syfzsl) <> 0 THEN ROUND(SUM(byfzsl)/SUM(syfzsl)*100,2) ELSE 0 END AS hbfzsl,CASE WHEN SUM(snfzsl) <> 0 THEN ROUND(SUM(byfzsl)/SUM(snfzsl)*100,2) ELSE 0 END AS tbfzsl,SUM(byje) AS byje,SUM(syje) AS syje,SUM(snje) AS snje,CASE WHEN SUM(syje) <> 0 THEN ROUND(SUM(byje)/SUM(syje)*100,2) ELSE 0 END AS hbje,CASE WHEN SUM(snje) <> 0 THEN ROUND(SUM(byje)/SUM(snje)*100,2) ELSE 0 END AS tbje,SUM(byse) AS byse,SUM(syse) AS syse,SUM(snse) AS snse,SUM(bycbje) AS bycbje,SUM(sycbje) AS sycbje,SUM(sncbje) AS sncbje,SUM(bymle) AS bymle,SUM(symle) AS symle,SUM(snmle) AS snmle,SUM(bymll) AS bymll,SUM(symll) AS symll,SUM(snmll) AS snmll FROM t_oekhfpfxb GROUP BY cplbdm,cplbmc"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("oekhfpfxb") IsNot Nothing Then
                    rcDataset.Tables("oekhfpfxb").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "oekhfpfxb")
                rcOleDbCommand.CommandText = "SELECT '' AS cplbdm,'合计' AS cplbmc,SUM(bysl) AS bysl,SUM(sysl) AS sysl,SUM(snsl) AS snsl,SUM(byfzsl) AS byfzsl,SUM(syfzsl) AS syfzsl,SUM(snfzsl) AS snfzsl,CASE WHEN SUM(syfzsl) <> 0 THEN ROUND(SUM(byfzsl)/SUM(syfzsl)*100,2) ELSE 0 END AS hbfzsl,CASE WHEN SUM(snfzsl) <> 0 THEN ROUND(SUM(byfzsl)/SUM(snfzsl)*100,2) ELSE 0 END AS tbfzsl,SUM(byje) AS byje,SUM(syje) AS syje,SUM(snje) AS snje,CASE WHEN SUM(syje) <> 0 THEN ROUND(SUM(byje)/SUM(syje)*100,2) ELSE 0 END AS hbje,CASE WHEN SUM(snje) <> 0 THEN ROUND(SUM(byje)/SUM(snje)*100,2) ELSE 0 END AS tbje,SUM(byse) AS byse,SUM(syse) AS syse,SUM(snse) AS snse,SUM(bycbje) AS bycbje,SUM(sycbje) AS sycbje,SUM(sncbje) AS sncbje,SUM(bymle) AS bymle,SUM(symle) AS symle,SUM(snmle) AS snmle,SUM(bymll) AS bymll,SUM(symll) AS symll,SUM(snmll) AS snmll FROM t_oekhfpfxb"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                rcOleDbDataAdpt.Fill(rcDataset, "oekhfpfxb")
            Else
                rcOleDbCommand.CommandText = "SELECT khlbdm,khlbmc,khdm,khmc,zydm,zymc,cplbdm,cplbmc,SUM(bysl) AS bysl,SUM(sysl) AS sysl,SUM(snsl) AS snsl,SUM(byfzsl) AS byfzsl,SUM(syfzsl) AS syfzsl,SUM(snfzsl) AS snfzsl,CASE WHEN SUM(syfzsl) <> 0 THEN ROUND(SUM(byfzsl)/SUM(syfzsl)*100,2) ELSE 0 END AS hbfzsl,CASE WHEN SUM(snfzsl) <> 0 THEN ROUND(SUM(byfzsl)/SUM(snfzsl)*100,2) ELSE 0 END AS tbfzsl,SUM(byje) AS byje,SUM(syje) AS syje,SUM(snje) AS snje,CASE WHEN SUM(syje) <> 0 THEN ROUND(SUM(byje)/SUM(syje)*100,2) ELSE 0 END AS hbje,CASE WHEN SUM(snje) <> 0 THEN ROUND(SUM(byje)/SUM(snje)*100,2) ELSE 0 END AS tbje,SUM(byse) AS byse,SUM(syse) AS syse,SUM(snse) AS snse,SUM(bycbje) AS bycbje,SUM(sycbje) AS sycbje,SUM(sncbje) AS sncbje,SUM(bymle) AS bymle,SUM(symle) AS symle,SUM(snmle) AS snmle,SUM(bymll) AS bymll,SUM(symll) AS symll,SUM(snmll) AS snmll FROM t_oekhfpfxb GROUP BY khlbdm,khlbmc,khdm,khmc,zydm,zymc,cplbdm,cplbmc"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("oekhfpfxb") IsNot Nothing Then
                    rcDataset.Tables("oekhfpfxb").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "oekhfpfxb")
                rcOleDbCommand.CommandText = "SELECT '' AS khdm,'合计' AS khmc,'' AS zydm,'' AS zymc,'' AS cplbdm,'' AS cplbmc,SUM(bysl) AS bysl,SUM(sysl) AS sysl,SUM(snsl) AS snsl,SUM(byfzsl) AS byfzsl,SUM(syfzsl) AS syfzsl,SUM(snfzsl) AS snfzsl,CASE WHEN SUM(syfzsl) <> 0 THEN ROUND(SUM(byfzsl)/SUM(syfzsl)*100,2) ELSE 0 END AS hbfzsl,CASE WHEN SUM(snfzsl) <> 0 THEN ROUND(SUM(byfzsl)/SUM(snfzsl)*100,2) ELSE 0 END AS tbfzsl,SUM(byje) AS byje,SUM(syje) AS syje,SUM(snje) AS snje,CASE WHEN SUM(syje) <> 0 THEN ROUND(SUM(byje)/SUM(syje)*100,2) ELSE 0 END AS hbje,CASE WHEN SUM(snje) <> 0 THEN ROUND(SUM(byje)/SUM(snje)*100,2) ELSE 0 END AS tbje,SUM(byse) AS byse,SUM(syse) AS syse,SUM(snse) AS snse,SUM(bycbje) AS bycbje,SUM(sycbje) AS sycbje,SUM(sncbje) AS sncbje,SUM(bymle) AS bymle,SUM(symle) AS symle,SUM(snmle) AS snmle,SUM(bymll) AS bymll,SUM(symll) AS symll,SUM(snmll) AS snmll FROM t_oekhfpfxb"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                rcOleDbDataAdpt.Fill(rcDataset, "oekhfpfxb")
            End If
            rcOleDbTrans.Commit()
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        'Dim rcDataRow As DataRow
        'rcDataRow = rcDataset.Tables("oekhfpfxb").NewRow
        'rcDataRow.Item("khdm") = "合计"
        'rcDataRow.Item("sl") = dtOeKhFpFxb.Compute("Sum(sl)", "")
        'rcDataRow.Item("fzsl") = dtOeKhFpFxb.Compute("Sum(fzsl)", "")
        'rcDataRow.Item("je") = dtOeKhFpFxb.Compute("Sum(je)", "")
        'rcDataRow.Item("se") = dtOeKhFpFxb.Compute("Sum(se)", "")
        'rcDataRow.Item("cbje") = dtOeKhFpFxb.Compute("Sum(cbje)", "")
        'rcDataRow.Item("mle") = dtOeKhFpFxb.Compute("Sum(mll)", "")
        'rcDataset.Tables("oekhfpfxb").Rows.Add(rcDataRow)

        '调用表单
        Dim rcFrm As New FrmOeKhFpFxbz
        With rcFrm
            .ParaDataSet = rcDataset
            If Me.CheckBox2.Checked Then
                .ParaDataView = New DataView(rcDataset.Tables("oekhfpfxb"), "TRUE", "cplbdm", DataViewRowState.CurrentRows)
            Else
                .ParaDataView = New DataView(rcDataset.Tables("oekhfpfxb"), "TRUE", "khdm,zydm", DataViewRowState.CurrentRows)
            End If
            .Label2.Text = Me.NudYear.Value & "年" & Me.NudMonth.Value & "月"
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If Me.CheckBox2.Checked Then
            Me.ChbLb.Checked = True
        End If
    End Sub
End Class