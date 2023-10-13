Imports System.Data.OleDb
Imports Microsoft.Office.Interop

Public Class FrmYwfZyMx
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable '我们要利用该datatable进行金额计算
    ReadOnly dtYwfzymx As New DataTable("ywfzymx")

#Region "初始化"

    Private Sub FrmYwfZyMx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        Me.NudYear.Value = Mid(g_Kjqj, 1, 4)
        Me.NudMonthBegin.Value = 1
        Me.NudMonthEnd.Value = 12

        '数据绑定
        dtYwfzymx.Columns.Add("khdm", Type.GetType("System.String"))
        dtYwfzymx.Columns.Add("khmc", Type.GetType("System.String"))
        dtYwfzymx.Columns.Add("xslbdm", Type.GetType("System.String"))
        dtYwfzymx.Columns.Add("gjxslb", Type.GetType("System.Boolean"))
        dtYwfzymx.Columns.Add("bywfjszz", Type.GetType("System.Boolean"))
        dtYwfzymx.Columns.Add("ywfbl", Type.GetType("System.String"))
        dtYwfzymx.Columns.Add("bnqc", Type.GetType("System.Double"))
        dtYwfzymx.Columns.Add("bnjf", Type.GetType("System.Double"))
        dtYwfzymx.Columns.Add("bndf", Type.GetType("System.Double"))
        dtYwfzymx.Columns.Add("bndj", Type.GetType("System.Double"))
        dtYwfzymx.Columns.Add("bnhl", Type.GetType("System.Double"))
        dtYwfzymx.Columns.Add("ywf_bz", Type.GetType("System.Double"))
        dtYwfzymx.Columns.Add("snhl", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtYwfzymx)
        With dtYwfzymx
            .Columns("khdm").DefaultValue = ""
            .Columns("khmc").DefaultValue = ""
            .Columns("xslbdm").DefaultValue = ""
            .Columns("gjxslb").DefaultValue = False
            .Columns("bywfjszz").DefaultValue = False
            .Columns("ywfbl").DefaultValue = ""
            .Columns("bnqc").DefaultValue = 0.0
            .Columns("bnjf").DefaultValue = 0.0
            .Columns("bndf").DefaultValue = 0.0
            .Columns("bndj").DefaultValue = 0.0
            .Columns("bnhl").DefaultValue = 0.0
            .Columns("ywf_bz").DefaultValue = 0.0
            .Columns("snhl").DefaultValue = 0.0
        End With
    End Sub

#End Region

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NudYear.KeyPress, NudMonthBegin.KeyPress, NudMonthEnd.KeyPress, TxtBmdm.KeyPress, TxtZydm.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "部门编码的事件"
    Private Sub TxtBmdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBmdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_bmxx"
                    .paraField1 = "bmdm"
                    .paraField2 = "bmmc"
                    .paraField3 = "bmsm"
                    .paraTitle = "部门"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtBmdm.Text = Trim(.paraField1)
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
                rcOleDbCommand.CommandText = "SELECT * FROM rc_bmxx WHERE (bmdm = ?)"
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
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "职员编码的事件"
    Private Sub TxtZydm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtZydm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_zyxx"
                    .paraField1 = "zydm"
                    .paraField2 = "zymc"
                    .paraField3 = "zysm"
                    .paraOrderField = "zymc"
                    .paraTitle = "职员"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtZydm.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtZydm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtZydm.Validating
        If Not String.IsNullOrEmpty(Me.TxtZydm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT rc_zyxx.zydm,rc_zyxx.zymc FROM rc_zyxx WHERE (zydm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(Me.TxtZydm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_zyxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_zyxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_zyxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_zyxx").Rows.Count > 0 Then
                Me.TxtZydm.Text = Trim(rcDataset.Tables("rc_zyxx").Rows(0).Item("zydm"))
            Else
                MsgBox("职员编码不存在，请重输入。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "生成明细数据"
    Private Sub ReadYwfZyMx(strZydm As String)
        Dim dateKsrq As Date '成本结转开始日期
        Dim dateJsrq As Date '成本结转结束日期
        dateKsrq = GetInvBegin(Me.NudYear.Value, Me.NudMonthBegin.Value)
        dateJsrq = GetInvEnd(Me.NudYear.Value, Me.NudMonthBegin.Value)
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '取数据
            rcOleDbCommand.CommandText = "SELECT khdm,khmc,xslbdm,gjxslb,bywfjszz,TO_CHAR(ywfbl,'0.00') || '%' AS ywfbl,SUM(bnqc) AS bnqc,SUM(bnjf) AS bnjf,SUM(bndf) AS bndf,SUM(bndj) AS bndj,SUM(bnhl) AS bnhl,SUM(ywf_bz) AS ywf_bz,SUM(snhl) AS snhl" &
                " FROM (SELECT ywfzymxa.khdm,ywfzymxa.khmc,ywfzymxa.xslbdm || CASE WHEN rc_khxx.djyear >= " & Me.NudYear.Value - 1 & " THEN '新' ELSE '' END AS xslbdm ,rc_khxslb.gjxslb,rc_khxx.bywfjszz,ywfzymxa.ywfbl,ywfzymxa.bnqc,ywfzymxa.bnjf,ywfzymxa.bndf,ywfzymxa.bndj,ywfzymxa.bnhl,ywfzymxa.ywf_bz,ywfzymxa.snhl" &
                " FROM ((SELECT khdm,khmc,xslbdm,ywfbl,0 AS bnqc,SUM(COALESCE(byjf,0.0)) AS bnjf,SUM(COALESCE(bydf,0.0)) AS bndf,SUM(COALESCE(tiexije,0.0) + COALESCE(yongjinje,0.0)) AS bndj,SUM(COALESCE(bydf,0.0)- COALESCE(tiexije,0.0) - COALESCE(yongjinje,0.0)) AS bnhl,SUM(ywf_bz) AS ywf_bz,0 AS snhl FROM gl_ywfjsb WHERE gl_ywfjsb.cperiod <= ? AND gl_ywfjsb.cperiod >= ? AND gl_ywfjsb.zydm = '" & strZydm & "' GROUP BY gl_ywfjsb.khdm,gl_ywfjsb.khmc,gl_ywfjsb.xslbdm,gl_ywfjsb.ywfbl)" & '取本年数
                " UNION ALL (SELECT khdm,khmc,xslbdm,ywfbl,SUM(COALESCE(qmye,0.0) + COALESCE(bydf,0.0) - COALESCE(byjf,0.0)) AS bnqc,0 AS bnjf,0 AS bndf,0 AS bndj,0 AS bnhl,0 AS ywf_bz,0 AS snhl FROM gl_ywfjsb WHERE EXISTS (SELECT 1 FROM (SELECT MIN(cperiod) AS cperiod,khdm FROM gl_ywfjsb gl_ywfjsba WHERE gl_ywfjsba.cperiod >= ? AND gl_ywfjsba.zydm = '" & strZydm & "' GROUP BY gl_ywfjsba.khdm) gl_ywfjsbb WHERE gl_ywfjsbb.cperiod = gl_ywfjsb.cperiod AND gl_ywfjsbb.khdm = gl_ywfjsb.khdm) AND gl_ywfjsb.zydm = '" & strZydm & "' GROUP BY gl_ywfjsb.khdm,gl_ywfjsb.khmc,gl_ywfjsb.xslbdm,gl_ywfjsb.ywfbl)" &   '取期初余额
                " UNION ALL (SELECT khdm,khmc,t_xslbdm AS xslbdm,rc_khxslb.ywfbl,0 AS bnqc,0 as bnjf,0 AS bndf,0 AS bndj,0 AS bnhl,0 AS ywf_bz,SUM(COALESCE(bydf,0.0)- COALESCE(tiexije,0.0) - COALESCE(yongjinje,0.0)) AS snhl FROM gl_ywfjsb,rc_khxslb WHERE gl_ywfjsb.t_xslbdm = rc_khxslb.xslbdm AND gl_ywfjsb.cperiod <= ? AND gl_ywfjsb.cperiod >= ? AND gl_ywfjsb.t_zydm = '" & strZydm & "' GROUP BY gl_ywfjsb.khdm,gl_ywfjsb.khmc,gl_ywfjsb.t_xslbdm,rc_khxslb.ywfbl) " & '取上年数 
                ") ywfzymxa LEFT JOIN rc_khxslb ON rc_khxslb.xslbdm = ywfzymxa.xslbdm LEFT JOIN rc_khxx ON ywfzymxa.khdm = rc_khxx.khdm) ywfzymxb GROUP BY khdm,khmc,xslbdm,gjxslb,bywfjszz,ywfbl"

            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthBegin.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & "01"
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = (Me.NudYear.Value - 1).ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = (Me.NudYear.Value - 1).ToString & Me.NudMonthBegin.Value.ToString.PadLeft(2, "0")
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("ywfzymx") IsNot Nothing Then
                rcDataset.Tables("ywfzymx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "ywfzymx")
            '小计
            rcOleDbCommand.CommandText = "SELECT '小计' AS khdm,xslbdm,gjxslb,bywfjszz,TO_CHAR(ywfbl,'0.00') || '%'  AS ywfbl,SUM(bnqc) AS bnqc,SUM(bnjf) AS bnjf,SUM(bndf) AS bndf,SUM(bndj) AS bndj,SUM(bnhl) AS bnhl,SUM(ywf_bz) AS ywf_bz,SUM(snhl) AS snhl" &
                " FROM (SELECT ywfzymxa.khdm,rc_khxx.khmc,ywfzymxa.xslbdm || CASE WHEN rc_khxx.djyear >= " & Me.NudYear.Value - 1 & " THEN '新' ELSE '' END AS xslbdm ,rc_khxslb.gjxslb,rc_khxx.bywfjszz,ywfzymxa.ywfbl,ywfzymxa.bnqc,ywfzymxa.bnjf,ywfzymxa.bndf,ywfzymxa.bndj,ywfzymxa.bnhl,ywfzymxa.ywf_bz,ywfzymxa.snhl" &
                " FROM ((SELECT khdm,xslbdm,ywfbl,0 AS bnqc,SUM(COALESCE(byjf,0.0)) AS bnjf,SUM(COALESCE(bydf,0.0)) AS bndf,SUM(COALESCE(tiexije,0.0) + COALESCE(yongjinje,0.0)) AS bndj,SUM(COALESCE(bydf,0.0)- COALESCE(tiexije,0.0) - COALESCE(yongjinje,0.0)) AS bnhl,SUM(ywf_bz) AS ywf_bz,0 AS snhl FROM gl_ywfjsb WHERE gl_ywfjsb.cperiod <= ? AND gl_ywfjsb.cperiod >= ? AND gl_ywfjsb.zydm = '" & strZydm & "' GROUP BY gl_ywfjsb.khdm,gl_ywfjsb.xslbdm,gl_ywfjsb.ywfbl)" & '取本年数
                " UNION ALL (SELECT khdm,xslbdm,ywfbl,SUM(COALESCE(qmye,0.0) + COALESCE(bydf,0.0) - COALESCE(byjf,0.0)) AS bnqc,0 AS bnjf,0 AS bndf,0 AS bndj,0 AS bnhl,0 AS ywf_bz,0 AS snhl FROM gl_ywfjsb WHERE EXISTS (SELECT 1 FROM (SELECT MIN(cperiod) AS cperiod,khdm FROM gl_ywfjsb gl_ywfjsba WHERE gl_ywfjsba.cperiod >= ? AND gl_ywfjsba.zydm = '" & strZydm & "' GROUP BY gl_ywfjsba.khdm) gl_ywfjsbb WHERE gl_ywfjsbb.cperiod = gl_ywfjsb.cperiod AND gl_ywfjsbb.khdm = gl_ywfjsb.khdm) AND gl_ywfjsb.zydm = '" & strZydm & "' GROUP BY gl_ywfjsb.khdm,gl_ywfjsb.xslbdm,gl_ywfjsb.ywfbl)" &   '取期初余额
                " UNION ALL (SELECT khdm,t_xslbdm AS xslbdm,rc_khxslb.ywfbl,0 AS bnqc,0 as bnjf,0 AS bndf,0 AS bndj,0 AS bnhl,0 AS ywf_bz,SUM(COALESCE(bydf,0.0)- COALESCE(tiexije,0.0) - COALESCE(yongjinje,0.0)) AS snhl FROM gl_ywfjsb,rc_khxslb WHERE gl_ywfjsb.t_xslbdm = rc_khxslb.xslbdm AND gl_ywfjsb.cperiod <= ? AND gl_ywfjsb.cperiod >= ? AND gl_ywfjsb.t_zydm = '" & strZydm & "' GROUP BY gl_ywfjsb.khdm,gl_ywfjsb.t_xslbdm,rc_khxslb.ywfbl) " & '取上年数 
                ") ywfzymxa LEFT JOIN rc_khxslb ON rc_khxslb.xslbdm = ywfzymxa.xslbdm LEFT JOIN rc_khxx ON ywfzymxa.khdm = rc_khxx.khdm) ywfzymxb GROUP BY xslbdm,gjxslb,bywfjszz,ywfbl"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthBegin.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & "01"
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = (Me.NudYear.Value - 1).ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = (Me.NudYear.Value - 1).ToString & Me.NudMonthBegin.Value.ToString.PadLeft(2, "0")
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            rcOleDbDataAdpt.Fill(rcDataset, "ywfzymx")
            ''关键、非关合计
            rcOleDbCommand.CommandText = "SELECT CASE WHEN gjxslb = 0 AND bywfjszz = 0 THEN '非关不计算增长小计' ELSE CASE WHEN gjxslb = 0 AND bywfjszz = 1 THEN '非关计算增长小计' ELSE CASE WHEN gjxslb = 1 AND bywfjszz = 0 THEN '关键不计算增长小计' ELSE '关键计算增长小计' END END END AS xslbdm,gjxslb,bywfjszz,'%' AS ywfbl,SUM(bnqc) AS bnqc,SUM(bnjf) AS bnjf,SUM(bndf) AS bndf,SUM(bndj) AS bndj,SUM(bnhl) AS bnhl,SUM(ywf_bz) AS ywf_bz,SUM(snhl) AS snhl" &
                " FROM (SELECT ywfzymxa.khdm,rc_khxx.khmc,ywfzymxa.xslbdm || CASE WHEN rc_khxx.djyear >= " & Me.NudYear.Value - 1 & " THEN '新' ELSE '' END AS xslbdm ,rc_khxslb.gjxslb,rc_khxx.bywfjszz,ywfzymxa.ywfbl,ywfzymxa.bnqc,ywfzymxa.bnjf,ywfzymxa.bndf,ywfzymxa.bndj,ywfzymxa.bnhl,ywfzymxa.ywf_bz,ywfzymxa.snhl" &
                " FROM ((SELECT khdm,xslbdm,ywfbl,0 AS bnqc,SUM(COALESCE(byjf,0.0)) AS bnjf,SUM(COALESCE(bydf,0.0)) AS bndf,SUM(COALESCE(tiexije,0.0) + COALESCE(yongjinje,0.0)) AS bndj,SUM(COALESCE(bydf,0.0)- COALESCE(tiexije,0.0) - COALESCE(yongjinje,0.0)) AS bnhl,SUM(ywf_bz) AS ywf_bz,0 AS snhl FROM gl_ywfjsb WHERE gl_ywfjsb.cperiod <= ? AND gl_ywfjsb.cperiod >= ? AND gl_ywfjsb.zydm = '" & strZydm & "' GROUP BY gl_ywfjsb.khdm,gl_ywfjsb.xslbdm,gl_ywfjsb.ywfbl)" & '取本年数
                " UNION ALL (SELECT khdm,xslbdm,ywfbl,SUM(COALESCE(qmye,0.0) + COALESCE(bydf,0.0) - COALESCE(byjf,0.0)) AS bnqc,0 AS bnjf,0 AS bndf,0 AS bndj,0 AS bnhl,0 AS ywf_bz,0 AS snhl FROM gl_ywfjsb WHERE EXISTS (SELECT 1 FROM (SELECT MIN(cperiod) AS cperiod,khdm FROM gl_ywfjsb gl_ywfjsba WHERE gl_ywfjsba.cperiod >= ? AND gl_ywfjsba.zydm = '" & strZydm & "' GROUP BY gl_ywfjsba.khdm) gl_ywfjsbb WHERE gl_ywfjsbb.cperiod = gl_ywfjsb.cperiod AND gl_ywfjsbb.khdm = gl_ywfjsb.khdm) AND gl_ywfjsb.zydm = '" & strZydm & "' GROUP BY gl_ywfjsb.khdm,gl_ywfjsb.xslbdm,gl_ywfjsb.ywfbl)" &   '取期初余额
                " UNION ALL (SELECT khdm,t_xslbdm AS xslbdm,rc_khxslb.ywfbl,0 AS bnqc,0 as bnjf,0 AS bndf,0 AS bndj,0 AS bnhl,0 AS ywf_bz,SUM(COALESCE(bydf,0.0)- COALESCE(tiexije,0.0) - COALESCE(yongjinje,0.0)) AS snhl FROM gl_ywfjsb,rc_khxslb WHERE gl_ywfjsb.t_xslbdm = rc_khxslb.xslbdm AND gl_ywfjsb.cperiod <= ? AND gl_ywfjsb.cperiod >= ? AND gl_ywfjsb.t_zydm = '" & strZydm & "' GROUP BY gl_ywfjsb.khdm,gl_ywfjsb.t_xslbdm,rc_khxslb.ywfbl) " & '取上年数 
                ") ywfzymxa LEFT JOIN rc_khxslb ON rc_khxslb.xslbdm = ywfzymxa.xslbdm LEFT JOIN rc_khxx ON ywfzymxa.khdm = rc_khxx.khdm) ywfzymxb GROUP BY gjxslb,bywfjszz"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthBegin.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & "01"
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = (Me.NudYear.Value - 1).ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = (Me.NudYear.Value - 1).ToString & Me.NudMonthBegin.Value.ToString.PadLeft(2, "0")
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            rcOleDbDataAdpt.Fill(rcDataset, "ywfzymx")
            '总计
            rcOleDbCommand.CommandText = "SELECT '合计' AS xslbdm,1 AS bywfjszz,'%' AS ywfbl,SUM(bnqc) AS bnqc,SUM(bnjf) AS bnjf,SUM(bndf) AS bndf,SUM(bndj) AS bndj,SUM(bnhl) AS bnhl,SUM(ywf_bz) AS ywf_bz,SUM(snhl) AS snhl" &
                " FROM (SELECT ywfzymxa.khdm,rc_khxx.khmc,ywfzymxa.xslbdm || CASE WHEN rc_khxx.djyear >= " & Me.NudYear.Value - 1 & " THEN '新' ELSE '' END AS xslbdm ,rc_khxslb.gjxslb,ywfzymxa.ywfbl,ywfzymxa.bnqc,ywfzymxa.bnjf,ywfzymxa.bndf,ywfzymxa.bndj,ywfzymxa.bnhl,ywfzymxa.ywf_bz,ywfzymxa.snhl" &
                " FROM ((SELECT khdm,xslbdm,ywfbl,0 AS bnqc,SUM(COALESCE(byjf,0.0)) AS bnjf,SUM(COALESCE(bydf,0.0)) AS bndf,SUM(COALESCE(tiexije,0.0) + COALESCE(yongjinje,0.0)) AS bndj,SUM(COALESCE(bydf,0.0)- COALESCE(tiexije,0.0) - COALESCE(yongjinje,0.0)) AS bnhl,SUM(ywf_bz) AS ywf_bz,0 AS snhl FROM gl_ywfjsb WHERE gl_ywfjsb.cperiod <= ? AND gl_ywfjsb.cperiod >= ? AND gl_ywfjsb.zydm = '" & strZydm & "' GROUP BY gl_ywfjsb.khdm,gl_ywfjsb.xslbdm,gl_ywfjsb.ywfbl)" & '取本年数
                " UNION ALL (SELECT khdm,xslbdm,ywfbl,SUM(COALESCE(qmye,0.0) + COALESCE(bydf,0.0) - COALESCE(byjf,0.0)) AS bnqc,0 AS bnjf,0 AS bndf,0 AS bndj,0 AS bnhl,0 AS ywf_bz,0 AS snhl FROM gl_ywfjsb WHERE EXISTS (SELECT 1 FROM (SELECT MIN(cperiod) AS cperiod,khdm FROM gl_ywfjsb gl_ywfjsba WHERE gl_ywfjsba.cperiod >= ? AND gl_ywfjsba.zydm = '" & strZydm & "' GROUP BY gl_ywfjsba.khdm) gl_ywfjsbb WHERE gl_ywfjsbb.cperiod = gl_ywfjsb.cperiod AND gl_ywfjsbb.khdm = gl_ywfjsb.khdm) AND gl_ywfjsb.zydm = '" & strZydm & "' GROUP BY gl_ywfjsb.khdm,gl_ywfjsb.xslbdm,gl_ywfjsb.ywfbl)" &   '取期初余额
                " UNION ALL (SELECT khdm,t_xslbdm AS xslbdm,rc_khxslb.ywfbl,0 AS bnqc,0 as bnjf,0 AS bndf,0 AS bndj,0 AS bnhl,0 AS ywf_bz,SUM(COALESCE(bydf,0.0)- COALESCE(tiexije,0.0) - COALESCE(yongjinje,0.0)) AS snhl FROM gl_ywfjsb,rc_khxslb WHERE gl_ywfjsb.t_xslbdm = rc_khxslb.xslbdm AND gl_ywfjsb.cperiod <= ? AND gl_ywfjsb.cperiod >= ? AND gl_ywfjsb.t_zydm = '" & strZydm & "' GROUP BY gl_ywfjsb.khdm,gl_ywfjsb.t_xslbdm,rc_khxslb.ywfbl) " & '取上年数 
                ") ywfzymxa LEFT JOIN rc_khxslb ON rc_khxslb.xslbdm = ywfzymxa.xslbdm LEFT JOIN rc_khxx ON ywfzymxa.khdm = rc_khxx.khdm) ywfzymxb"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthBegin.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & "01"
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = (Me.NudYear.Value - 1).ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = (Me.NudYear.Value - 1).ToString & Me.NudMonthBegin.Value.ToString.PadLeft(2, "0")
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            rcOleDbDataAdpt.Fill(rcDataset, "ywfzymx")
        Catch ex As Exception
            Try
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
    End Sub
#End Region

    '#Region "输出到Excel"
    '    Private Sub ToExcel(rcExcelApp As Microsoft.Office.Interop.Excel.Application, rcExcelWorksheet As Microsoft.Office.Interop.Excel.Application, strZydm As String, strZymc As String, dvYwfZyMx As DataView)
    '        If dvYwfZyMx.Count > 0 Then
    '            Try
    '                Dim rowIndex, colIndex As Integer
    '                rowIndex = 1
    '                colIndex = 0

    '                '将所得到的表的列名,赋值给单元格
    '                Dim i As Integer
    '                Dim rcDataColumn As DataColumn
    '                Dim rcDataRowView As DataRowView


    '                For Each rcDataColumn In dvYwfZyMx.Table.Columns
    '                    colIndex = colIndex + 1
    '                    rcExcelApp.Cells(1, colIndex) = rcDataColumn.ColumnName
    '                Next
    '                '得到的表所有行,赋值给单元格
    '                For i = 0 To dvYwfZyMx.Count - 1
    '                    rcDataRowView = dvYwfZyMx.Item(i)
    '                    If rcDataRowView.Row.RowState <> DataRowState.Deleted Then
    '                        rowIndex = rowIndex + 1
    '                        colIndex = 0
    '                        For Each rcDataColumn In dvYwfZyMx.Table.Columns
    '                            colIndex = colIndex + 1
    '                            Select Case True
    '                                Case dvYwfZyMx.Item(i).Row.Item(rcDataColumn.ColumnName).GetType.ToString = "System.String"
    '                                    rcExcelApp.Cells(rowIndex, colIndex) = "'" & Trim(dvYwfZyMx.Item(i).Row.Item(rcDataColumn.ColumnName))
    '                                Case dvYwfZyMx.Item(i).Row.Item(rcDataColumn.ColumnName).GetType.ToString = "System.Byte[]"
    '                                    '设置行高
    '                                    rcExcelWorksheet.Rows().RowHeight = 100
    '                                    '设置列宽
    '                                    rcExcelWorksheet.Columns().ColumnWidth = 16
    '                                    '
    '                                    Dim s As String
    '                                    s = Application.StartupPath & "\tmptoexcel.jpg"
    '                                    If IO.File.Exists(s) Then
    '                                        IO.File.Delete(s)
    '                                    End If
    '                                    Dim size() As Byte = dvYwfZyMx.Item(i).Row.Item(rcDataColumn.ColumnName)
    '                                    Dim fs As IO.FileStream
    '                                    fs = New IO.FileStream(s, IO.FileMode.CreateNew)
    '                                    fs.Write(size, 0, size.Length - 0)
    '                                    fs.Close()
    '                                    Dim range As Microsoft.Office.Interop.Excel.Range = rcExcelWorksheet.Range(rcExcelApp.Cells(rowIndex, colIndex), rcExcelApp.Cells(rowIndex, colIndex))  '粘贴图片的位置
    '                                    range.Select()
    '                                    rcExcelApp.ActiveSheet.Pictures.Insert(s).Select()

    '                                Case Else
    '                                    rcExcelApp.Cells(rowIndex, colIndex) = dvYwfZyMx.Item(i).Row.Item(rcDataColumn.ColumnName)

    '                            End Select
    '                        Next
    '                    End If
    '                Next
    '                For Each pic As Microsoft.Office.Interop.Excel.Shape In rcExcelApp.ActiveSheet.Shapes
    '                    pic.Height = 100
    '                Next
    '                ''设置打印显示样式
    '                'With rcExcelWorksheet
    '                '    .Range(.cell(1, 1), .cell(1, colIndex)).borderstyle.font = True '标题加粗
    '                '    .Range(.cell(1, 1), .cell(1, colIndex)).borderstyle.color = RGB(125, 25, 27)
    '                '    .Range(.cell(1, 1), .cell(rowIndex, colIndex)).borderstyle.linestyle = 1 '设置边框样式
    '                'End With
    '                'rcExcelApp.close()
    '            Catch ex As Exception
    '                MessageBox.Show("数据导出失败！请查看是否已经安装了Excel。", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            Finally
    '                Me.Cursor = Cursors.Default
    '            End Try
    '        Else
    '            MessageBox.Show("没有数据！", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        End If
    '        'Dim strConnection As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = " + strFilename + ";Extended Properties = 'Excel 12.0;HDR=YES;IMEX=0;'"
    '        'Dim xlsOleDbConn As New OleDbConnection(strConnection)
    '        'Dim i As Integer
    '        'Dim j As Integer
    '        ''插入工作表
    '        'Dim xlApp As Excel.Application
    '        'Dim xlBook As Excel.Workbook
    '        'Dim xlSheet As Excel.Worksheet
    '        'xlApp = New Excel.Application
    '        'xlBook = xlApp.Workbooks.Add
    '        'xlSheet = xlBook.Worksheets.Item(xlBook.Worksheets.Count)

    '        'Try
    '        '    xlsOleDbConn.Open()
    '        '    rcOleDbCommand.Connection = xlsOleDbConn
    '        '    rcOleDbCommand.CommandType = CommandType.Text
    '        '    rcOleDbCommand.CommandText = "CREATE TABLE [S" & strZydm & "] ("
    '        '    For j = 0 To dvYwfZyMx.Table.Columns.Count - 1
    '        '        rcOleDbCommand.CommandText += IIf(j = 0, "", ",") & dvYwfZyMx.Table.Columns(j).ColumnName & " " & dvYwfZyMx.Table.Columns(j).DataType.ToString.Replace("System.", "").Replace("Int16", "Integer").Replace("Int32", "Integer").Replace("DateTime", "String").Replace("Boolean", "Integer") '"colname" & Trim((j + 1).ToString)
    '        '        'MsgBox(rcDataView.Table.Columns(j).DataType.ToString)
    '        '    Next
    '        '    'rcOleDbCommand.CommandText += " VALUES ("
    '        '    'For j = 0 To rcDataView.Table.Columns.Count - 1
    '        '    '    rcOleDbCommand.CommandText += IIf(j = 0, "'", ",'") & rcDataView.Table.Columns(j).ColumnName & "'"
    '        '    'Next
    '        '    rcOleDbCommand.CommandText += ")"
    '        '    rcOleDbCommand.Parameters.Clear()
    '        '    'MsgBox(rcOleDbCommand.CommandText)
    '        '    rcOleDbCommand.ExecuteNonQuery()
    '        '    For i = 0 To dvYwfZyMx.Count - 1
    '        '        rcOleDbCommand.CommandText = "INSERT INTO [" & strZymc & "] ("
    '        '        For j = 0 To dvYwfZyMx.Table.Columns.Count - 1
    '        '            rcOleDbCommand.CommandText += IIf(j = 0, "", ",") & dvYwfZyMx.Table.Columns(j).ColumnName
    '        '        Next
    '        '        rcOleDbCommand.CommandText += ") VALUES ("
    '        '        For j = 0 To dvYwfZyMx.Table.Columns.Count - 1
    '        '            Select Case dvYwfZyMx.Table.Columns(j).DataType.ToString
    '        '                Case "System.Decimal", "System.Double", "System.Int16", "System.Int32"
    '        '                    If dvYwfZyMx.Item(i).Row.Item(dvYwfZyMx.Table.Columns(j).ColumnName).ToString = "非数字" Or dvYwfZyMx.Item(i).Row.Item(dvYwfZyMx.Table.Columns(j).ColumnName).ToString = "正无穷大" Or dvYwfZyMx.Item(i).Row.Item(dvYwfZyMx.Table.Columns(j).ColumnName).ToString = "负无穷大" Then
    '        '                        rcOleDbCommand.CommandText += IIf(j = 0, "'", ",0")
    '        '                    Else
    '        '                        rcOleDbCommand.CommandText += IIf(j = 0, "'", ",0") & dvYwfZyMx.Item(i).Row.Item(dvYwfZyMx.Table.Columns(j).ColumnName)
    '        '                    End If
    '        '                Case Else
    '        '                    If dvYwfZyMx.Item(i).Row.Item(dvYwfZyMx.Table.Columns(j).ColumnName).GetType.ToString <> "System.DBNull" Then
    '        '                        rcOleDbCommand.CommandText += IIf(j = 0, "'", ",'") & dvYwfZyMx.Item(i).Row.Item(dvYwfZyMx.Table.Columns(j).ColumnName).Replace("'", "''") & "'"
    '        '                    Else
    '        '                        rcOleDbCommand.CommandText += IIf(j = 0, "'", ",'") & "'"
    '        '                    End If
    '        '            End Select
    '        '        Next
    '        '        rcOleDbCommand.CommandText += ")"
    '        '        rcOleDbCommand.Parameters.Clear()
    '        '        'MsgBox(rcOleDbCommand.CommandText)
    '        '        rcOleDbCommand.ExecuteNonQuery()
    '        '    Next
    '        'Catch ex As Exception
    '        '    Try
    '        '        MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
    '        '    Catch ey As OleDbException
    '        '        MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
    '        '    End Try
    '        '    Return
    '        'Finally
    '        '    xlsOleDbConn.Close()
    '        'End Try
    '        'MsgBox("数据导出完成。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
    '    End Sub

    '#End Region
    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If String.IsNullOrEmpty(Me.TxtZydm.Text) Then
            MsgBox("请选择职员编码。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        ReadYwfZyMx(Me.TxtZydm.Text)
        '调用表单
        Dim rcFrm As New FrmYwfZyMxz
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("ywfzymx"), "TRUE", "gjxslb desc,bywfjszz,ywfbl,xslbdm,khdm", DataViewRowState.CurrentRows)
            .Label2.Text = "会计期间：" & Me.NudYear.Value & "年" & Me.NudMonthBegin.Value & "月至" & Me.NudMonthEnd.Value & "月"
            '.Label3.Text = "仓库：" & Trim(Me.TxtCkdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With

    End Sub
    Private Sub BtnToExcel_Click(sender As Object, e As EventArgs) Handles BtnToExcel.Click
        Dim i As Integer
        If String.IsNullOrEmpty(Me.TxtBmdm.Text) Then
            MsgBox("请选择部门编码。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT rc_zyxx.zydm,rc_zyxx.zymc FROM rc_zyxx WHERE (bmdm = ?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtBmdm.Text)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_zyxx") IsNot Nothing Then
                Me.rcDataset.Tables("rc_zyxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_zyxx")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        Finally
            rcOleDbConn.Close()
        End Try
        Dim rcExcelApp As New Microsoft.Office.Interop.Excel.Application
        Dim rcExcelWorkbook As Microsoft.Office.Interop.Excel.Workbook
        Dim rcExcelWorksheet As Microsoft.Office.Interop.Excel.Worksheet
        rcExcelWorkbook = rcExcelApp.Workbooks().Add
        If Not Me.CheckBox1.Checked Then
            rcExcelWorksheet = rcExcelWorkbook.Worksheets("sheet1")
        End If
        rcExcelApp.Visible = True
        '定义行号，列号
        Dim rowIndex, colIndex As Integer
        rowIndex = 1
        colIndex = 0
        For i = 0 To rcDataset.Tables("rc_zyxx").Rows.Count - 1
            '读取数据
            ReadYwfZyMx(rcDataset.Tables("rc_zyxx").Rows(i).Item("zydm"))
            ''选择输出文件
            'Dim rcFileName As String = CurDir() + "\report.xls"
            'If Me.OpenFileDialogExcel.ShowDialog = DialogResult.OK Then
            '    rcFileName = Me.OpenFileDialogExcel.FileName
            'Else
            '    Return
            'End If
            If Me.CheckBox1.Checked Then
                rcExcelWorksheet = rcExcelWorkbook.Worksheets.Add()
                rcExcelWorksheet.Name = rcDataset.Tables("rc_zyxx").Rows(i).Item("zymc")
            End If
            '输出
            Dim dvYwfzyMx As New DataView(rcDataset.Tables("ywfzymx"), "TRUE", "gjxslb desc,bywfjszz,ywfbl,xslbdm,khdm", DataViewRowState.CurrentRows)
            If dvYwfzyMx.Count > 0 Then
                Try

                    '将所得到的表的列名,赋值给单元格
                    Dim j As Integer
                    Dim rcDataColumn As DataColumn
                    Dim rcDataRowView As DataRowView
                    If Me.CheckBox1.Checked Then
                        rowIndex = 1
                        colIndex = 0
                    Else
                        colIndex = 2
                    End If
                    If rowIndex = 1 Then
                        If Not Me.CheckBox1.Checked Then
                            rcExcelApp.Cells(rowIndex, 1) = "职员编码"
                            rcExcelApp.Cells(rowIndex, 2) = "职员姓名"
                        End If
                        '写列名
                        For Each rcDataColumn In dvYwfzyMx.Table.Columns
                            colIndex += 1
                            rcExcelApp.Cells(1, colIndex) = rcDataColumn.ColumnName
                        Next
                    End If
                    '得到的表所有行,赋值给单元格
                    For j = 0 To dvYwfzyMx.Count - 1
                        rcDataRowView = dvYwfzyMx.Item(j)
                        If rcDataRowView.Row.RowState <> DataRowState.Deleted Then
                            rowIndex += 1
                            If Not Me.CheckBox1.Checked Then
                                rcExcelApp.Cells(rowIndex, 1) = "'" & rcDataset.Tables("rc_zyxx").Rows(i).Item("zydm")
                                rcExcelApp.Cells(rowIndex, 2) = "'" & rcDataset.Tables("rc_zyxx").Rows(i).Item("zymc")
                            End If
                            colIndex = IIf(Me.CheckBox1.Checked, 0, 2)
                            For Each rcDataColumn In dvYwfzyMx.Table.Columns
                                colIndex += 1
                                Select Case True
                                    Case dvYwfzyMx.Item(j).Row.Item(rcDataColumn.ColumnName).GetType.ToString = "System.String"
                                        rcExcelApp.Cells(rowIndex, colIndex) = "'" & Trim(dvYwfzyMx.Item(j).Row.Item(rcDataColumn.ColumnName))
                                    Case Else
                                        rcExcelApp.Cells(rowIndex, colIndex) = dvYwfzyMx.Item(j).Row.Item(rcDataColumn.ColumnName)
                                End Select
                            Next
                        End If
                    Next
                    ''设置打印显示样式
                    'With rcExcelWorksheet
                    '    .Range(.cell(1, 1), .cell(1, colIndex)).borderstyle.font = True '标题加粗
                    '    .Range(.cell(1, 1), .cell(1, colIndex)).borderstyle.color = RGB(125, 25, 27)
                    '    .Range(.cell(1, 1), .cell(rowIndex, colIndex)).borderstyle.linestyle = 1 '设置边框样式
                    'End With
                    'rcExcelApp.close()
                Catch ex As Exception
                    MessageBox.Show("数据导出失败！请查看是否已经安装了Excel。", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Finally
                    Me.Cursor = Cursors.Default
                End Try
            Else
                MessageBox.Show("没有数据！", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            'ToExcel(rcDataset.Tables("rc_zyxx").Rows(i).Item("zydm"), rcDataset.Tables("rc_zyxx").Rows(i).Item("zymc"), New DataView(rcDataset.Tables("ywfzymx"), "TRUE", "gjxslb desc,ywfbl,xslbdm,khdm", DataViewRowState.CurrentRows))
        Next
    End Sub
End Class