Imports System.Data.OleDb

Public Class FrmYwfZyzzHz
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

#Region "初始化"

    Private Sub FrmYwfZyzzHz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        Me.NudYear.Value = Mid(g_Kjqj, 1, 4)
        Me.NudMonthBegin.Value = 1
        Me.NudMonthEnd.Value = 12
        '取非关键客户回笼增长部分提升比例
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT paraid,parastrvalue,paradblvalue FROM rc_para WHERE paraId = '非关键客户回笼增长部分提升比例'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message)
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_para").Rows.Count > 0 Then
            If rcDataset.Tables("rc_para").Rows(0).Item("paradblvalue").GetType.ToString <> "System.DBNull" Then
                Me.TxtZyzz.Text = rcDataset.Tables("rc_para").Rows(0).Item("paradblvalue")
            Else
                Me.TxtZyzz.Text = 0
            End If
        Else
            Me.TxtZyzz.Text = 0
        End If
        '取非关键客户回笼增长部分固定奖惩比例
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT paraid,parastrvalue,paradblvalue FROM rc_para WHERE paraId = '非关键客户回笼增长部分固定奖惩比例'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message)
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_para").Rows.Count > 0 Then
            If rcDataset.Tables("rc_para").Rows(0).Item("paradblvalue").GetType.ToString <> "System.DBNull" Then
                Me.TxtGdjcbl.Text = rcDataset.Tables("rc_para").Rows(0).Item("paradblvalue")
            Else
                Me.TxtGdjcbl.Text = 0
            End If
        Else
            Me.TxtGdjcbl.Text = 0
        End If
    End Sub

#End Region

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NudYear.KeyPress, NudMonthBegin.KeyPress, NudMonthEnd.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        '保存系统参数
        If Not String.IsNullOrEmpty(Me.TxtZyzz.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                '删除数据
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = '非关键客户回笼增长部分提升比例'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '插入数据
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'非关键客户回笼增长部分提升比例','',?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarNumeric, 14).Value = Trim(Me.TxtZyzz.Text)
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("程序错误。" & Chr(13) & ex.Message)
                Catch ey As OleDbException
                    MsgBox("程序错误。" & Chr(13) & ey.Message)
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        End If
        If Not String.IsNullOrEmpty(Me.TxtGdjcbl.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                '删除数据
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = '非关键客户回笼增长部分固定奖惩比例'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '插入数据
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'非关键客户回笼增长部分固定奖惩比例','',?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarNumeric, 14).Value = Trim(Me.TxtGdjcbl.Text)
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("程序错误。" & Chr(13) & ex.Message)
                Catch ey As OleDbException
                    MsgBox("程序错误。" & Chr(13) & ey.Message)
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        End If

        Dim i As Integer
        Dim dateKsrq As Date '成本结转开始日期
        Dim dateJsrq As Date '成本结转结束日期
        dateKsrq = GetInvBegin(Me.NudYear.Value, Me.NudMonthBegin.Value)
        dateJsrq = GetInvEnd(Me.NudYear.Value, Me.NudMonthBegin.Value)
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '关键客户回笼，非关键客户回笼，（本年与，上年同期）
            If Not Me.CheckBox2.Checked Then
                '不按业务员任务数计算增长比
                '取数据
                rcOleDbCommand.CommandText = "SELECT ywfzyzzhzb.zydm,rc_zyxx.zymc,ywfzyzzhzb.bngjdf,ywfzyzzhzb.bngjywf,ywfzyzzhzb.bnfgjdf,ywfzyzzhzb.bnfgjbjs,ywfzyzzhzb.bnfgjywf,ywfzyzzhzb.sngjdf,ywfzyzzhzb.sngjywf,ywfzyzzhzb.snfgjdf,ywfzyzzhzb.snfgjbjs,ywfzyzzhzb.snfgjywf,ywfzyzzhzb.zyzzbl,ywfzyzzhzb.zyzzje" &
                " FROM (SELECT zydm,SUM(bngjdf) AS bngjdf,SUM(bngjywf) AS bngjywf,SUM(bnfgjdf) AS bnfgjdf,SUM(bnfgjbjs) AS bnfgjbjs,SUM(bnfgjywf) AS bnfgjywf,SUM(sngjdf) AS sngjdf,SUM(sngjywf) AS sngjywf,SUM(snfgjdf) AS snfgjdf,SUM(snfgjbjs) AS snfgjbjs,SUM(snfgjywf) AS snfgjywf,CASE WHEN " & Me.TxtGdjcbl.Text & " <> 0 THEN " & Me.TxtGdjcbl.Text & " ELSE CASE WHEN SUM(bngjdf + bnfgjdf) <> 0 THEN SUM(bngjywf + bnfgjywf)/SUM(bngjdf + bnfgjdf) * " & Me.TxtZyzz.Text & " ELSE 0 END END zyzzbl,CASE WHEN " & Me.TxtGdjcbl.Text & "<> 0 THEN " & Me.TxtGdjcbl.Text & " ELSE CASE WHEN SUM(bngjdf + bnfgjdf) <> 0 THEN SUM(bngjywf + bnfgjywf)/SUM(bngjdf + bnfgjdf) * " & Me.TxtZyzz.Text & " ELSE 0 END END * CASE WHEN SUM(bnfgjdf) - SUM(snfgjdf) - SUM(bnfgjbjs) + SUM(snfgjbjs) > 0 THEN (SUM(bnfgjdf) - SUM(snfgjdf) - SUM(bnfgjbjs) + SUM(snfgjbjs))/100 ELSE 0 END zyzzje" &
                " FROM ((SELECT zydm,SUM(COALESCE(bydf,0.0)- COALESCE(tiexije,0.0) - COALESCE(yongjinje,0.0)) AS bngjdf,0 AS bnfgjdf,0 AS bnfgjbjs,0 AS sngjdf,0 AS snfgjdf,0 AS snfgjbjs,SUM(ywf_bz) AS bngjywf,0 AS bnfgjywf,0 AS sngjywf,0 AS snfgjywf FROM gl_ywfjsb WHERE gl_ywfjsb.cperiod <= ? AND gl_ywfjsb.cperiod >= ? AND EXISTS (SELECT 1 FROM rc_khxslb WHERE rc_khxslb.gjxslb = 1 AND rc_khxslb.xslbdm = gl_ywfjsb.xslbdm) GROUP BY gl_ywfjsb.zydm)" &
                " UNION ALL (SELECT zydm,0 AS bngjdf,SUM(COALESCE(bydf,0.0)- COALESCE(tiexije,0.0) - COALESCE(yongjinje,0.0)) AS bnfgjdf,0 AS bnfgjbjs,0 AS sngjdf,0 AS snfgjdf,0 AS snfgjbjs,0 AS bngjywf,SUM(ywf_bz) AS bnfgjywf,0 AS sngjywf,0 AS snfgjywf FROM gl_ywfjsb WHERE gl_ywfjsb.cperiod <= ? AND gl_ywfjsb.cperiod >= ? AND EXISTS (SELECT 1 FROM rc_khxslb WHERE rc_khxslb.gjxslb <> 1 AND rc_khxslb.xslbdm = gl_ywfjsb.xslbdm) GROUP BY gl_ywfjsb.zydm)" &
                " UNION ALL (SELECT zydm,0 AS bngjdf,0 AS bnfgjdf,SUM(COALESCE(bydf,0.0)- COALESCE(tiexije,0.0) - COALESCE(yongjinje,0.0)) AS bnfgjbjs,0 AS sngjdf,0 AS snfgjdf,0 AS snfgjbjs,0 AS bngjywf,0 AS bnfgjywf,0 AS sngjywf,0 AS snfgjywf FROM gl_ywfjsb WHERE gl_ywfjsb.cperiod <= ? AND gl_ywfjsb.cperiod >= ? AND EXISTS (SELECT 1 FROM rc_khxx WHERE rc_khxx.khdm = gl_ywfjsb.khdm AND rc_khxx.bywfjszz <> 1) AND EXISTS (SELECT 1 FROM rc_khxslb WHERE rc_khxslb.gjxslb <> 1 AND rc_khxslb.xslbdm = gl_ywfjsb.xslbdm) GROUP BY gl_ywfjsb.zydm)" &
                " UNION ALL (SELECT t_zydm AS zydm,0 as bngjdf,0 AS bnfgjdf,0 AS bnfgjbjs,SUM(COALESCE(bydf,0.0)- COALESCE(tiexije,0.0) - COALESCE(yongjinje,0.0)) AS sngjdf,0 AS snfgjdf,0 AS snfgjbjs,0 AS bngjywf,0 AS bnfgjywf,SUM(ywf_bz) AS sngjywf,0 AS snfgjywf FROM gl_ywfjsb WHERE  gl_ywfjsb.cperiod <= ? AND gl_ywfjsb.cperiod >= ? AND EXISTS (SELECT 1 FROM rc_khxslb WHERE rc_khxslb.gjxslb = 1 AND rc_khxslb.xslbdm = gl_ywfjsb.t_xslbdm) GROUP BY gl_ywfjsb.t_zydm)" &
                " UNION ALL (SELECT t_zydm AS zydm,0 as bngjdf,0 AS bnfgjdf,0 AS bnfgjbjs,0 AS sngjdf,SUM(COALESCE(bydf,0.0)- COALESCE(tiexije,0.0) - COALESCE(yongjinje,0.0)) AS snfgjdf,0 AS snfgjbjs,0 AS bngjywf,0 AS bnfgjywf,0 AS sngjywf,SUM(ywf_bz) AS snfgjywf FROM gl_ywfjsb WHERE  gl_ywfjsb.cperiod <= ? AND gl_ywfjsb.cperiod >= ? AND EXISTS (SELECT 1 FROM rc_khxslb WHERE rc_khxslb.gjxslb <> 1 AND rc_khxslb.xslbdm = gl_ywfjsb.t_xslbdm) GROUP BY gl_ywfjsb.t_zydm)" &
                " UNION ALL (SELECT t_zydm AS zydm,0 as bngjdf,0 AS bnfgjdf,0 AS bnfgjbjs,0 AS sngjdf,0 AS snfgjdf,SUM(COALESCE(bydf,0.0)- COALESCE(tiexije,0.0) - COALESCE(yongjinje,0.0)) AS snfgjbjs,0 AS bngjywf,0 AS bnfgjywf,0 AS sngjywf,SUM(ywf_bz) AS snfgjywf FROM gl_ywfjsb WHERE  gl_ywfjsb.cperiod <= ? AND gl_ywfjsb.cperiod >= ? AND EXISTS (SELECT 1 FROM rc_khxx WHERE rc_khxx.khdm = gl_ywfjsb.khdm AND rc_khxx.bywfjszz <> 1) AND EXISTS (SELECT 1 FROM rc_khxslb WHERE rc_khxslb.gjxslb <> 1 AND rc_khxslb.xslbdm = gl_ywfjsb.t_xslbdm) GROUP BY gl_ywfjsb.t_zydm)) ywfzyzzhza GROUP BY zydm) ywfzyzzhzb LEFT JOIN rc_zyxx ON ywfzyzzhzb.zydm = rc_zyxx.zydm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthBegin.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthBegin.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthBegin.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = (Me.NudYear.Value - 1).ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = (Me.NudYear.Value - 1).ToString & Me.NudMonthBegin.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = (Me.NudYear.Value - 1).ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = (Me.NudYear.Value - 1).ToString & Me.NudMonthBegin.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = (Me.NudYear.Value - 1).ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = (Me.NudYear.Value - 1).ToString & Me.NudMonthBegin.Value.ToString.PadLeft(2, "0")
            Else
                rcOleDbCommand.CommandText = "SELECT ywfzyzzhzb.zydm,rc_zyxx.zymc,ywfzyzzhzb.bngjdf,ywfzyzzhzb.bngjywf,ywfzyzzhzb.bnfgjdf,ywfzyzzhzb.bnfgjbjs,ywfzyzzhzb.bnfgjywf,ywfzyzzhzb.sngjdf,ywfzyzzhzb.sngjywf,ywfzyzzhzb.snfgjdf,0 AS snfgjbjs,ywfzyzzhzb.snfgjywf,ywfzyzzhzb.zyzzbl,ywfzyzzhzb.zyzzje" &
                " FROM (SELECT zydm,SUM(bngjdf) AS bngjdf,SUM(bngjywf) AS bngjywf,SUM(bnfgjdf) AS bnfgjdf,SUM(bnfgjbjs) AS bnfgjbjs,SUM(bnfgjywf) AS bnfgjywf,SUM(sngjdf) AS sngjdf,SUM(sngjywf) AS sngjywf,SUM(snfgjdf) AS snfgjdf,SUM(snfgjywf) AS snfgjywf,CASE WHEN SUM(bngjdf + bnfgjdf) <> 0 THEN SUM(bngjywf + bnfgjywf)/SUM(bngjdf + bnfgjdf) * " & Me.TxtZyzz.Text & " ELSE 0 END zyzzbl,CASE WHEN SUM(bngjdf + bnfgjdf) <> 0 THEN SUM(bngjywf + bnfgjywf)/SUM(bngjdf + bnfgjdf) * " & Me.TxtZyzz.Text & " ELSE 0 END * CASE WHEN SUM(bnfgjdf) - SUM(snfgjdf) - SUM(bnfgjbjs) > 0 THEN (SUM(bnfgjdf) - SUM(snfgjdf) - SUM(bnfgjbjs))/100 ELSE 0 END zyzzje" &
                " FROM ((SELECT zydm,SUM(COALESCE(bydf,0.0)- COALESCE(tiexije,0.0) - COALESCE(yongjinje,0.0)) AS bngjdf,0 AS bnfgjdf,0 AS bnfgjbjs,0 AS sngjdf,0 AS snfgjdf,SUM(ywf_bz) AS bngjywf,0 AS bnfgjywf,0 AS sngjywf,0 AS snfgjywf FROM gl_ywfjsb WHERE gl_ywfjsb.cperiod <= ? AND gl_ywfjsb.cperiod >= ? AND EXISTS (SELECT 1 FROM rc_khxslb WHERE rc_khxslb.gjxslb = 1 AND rc_khxslb.xslbdm = gl_ywfjsb.xslbdm) GROUP BY gl_ywfjsb.zydm)" &
                " UNION ALL (SELECT zydm,0 AS bngjdf,SUM(COALESCE(bydf,0.0)- COALESCE(tiexije,0.0) - COALESCE(yongjinje,0.0)) AS bnfgjdf,0 AS bnfgjbjs,0 AS sngjdf,0 AS snfgjdf,0 AS bngjywf,SUM(ywf_bz) AS bnfgjywf,0 AS sngjywf,0 AS snfgjywf FROM gl_ywfjsb WHERE gl_ywfjsb.cperiod <= ? AND gl_ywfjsb.cperiod >= ? AND EXISTS (SELECT 1 FROM rc_khxslb WHERE rc_khxslb.gjxslb <> 1 AND rc_khxslb.xslbdm = gl_ywfjsb.xslbdm) GROUP BY gl_ywfjsb.zydm)" &
                " UNION ALL (SELECT zydm,0 AS bngjdf,0 AS bnfgjdf,SUM(COALESCE(bydf,0.0)- COALESCE(tiexije,0.0) - COALESCE(yongjinje,0.0)) AS bnfgjbjs,0 AS sngjdf,0 AS snfgjdf,0 AS bngjywf,SUM(ywf_bz) AS bnfgjywf,0 AS sngjywf,0 AS snfgjywf FROM gl_ywfjsb WHERE gl_ywfjsb.cperiod <= ? AND gl_ywfjsb.cperiod >= ? AND EXISTS (SELECT 1 FROM rc_khxx WHERE rc_khxx.khdm = gl_ywfjsb.khdm AND rc_khxx.bywfjszz <> 1) AND EXISTS (SELECT 1 FROM rc_khxslb WHERE rc_khxslb.gjxslb <> 1 AND rc_khxslb.xslbdm = gl_ywfjsb.xslbdm) GROUP BY gl_ywfjsb.zydm)" &
                " UNION ALL (SELECT zydm,0 AS bngjdf,0 AS bnfgjdf,0 AS bnfgjbjs,0 AS sngjdf,SUM(rws) AS snfgjdf,0 AS bngjywf,0 AS bnfgjywf,0 AS sngjywf,0 AS snfgjywf FROM gl_ywfzyrw WHERE kjnd = ? GROUP BY gl_ywfzyrw.zydm)" &
                ") ywfzyzzhza GROUP BY zydm) ywfzyzzhzb LEFT JOIN rc_zyxx ON ywfzyzzhzb.zydm = rc_zyxx.zydm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthBegin.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthBegin.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthBegin.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString
            End If
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            'MsgBox(rcOleDbCommand.CommandText)
            If rcDataset.Tables("ywfzyzzhz") IsNot Nothing Then
                rcDataset.Tables("ywfzyzzhz").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "ywfzyzzhz")
            'rcOleDbCommand.CommandText = "SELECT '' AS khdm,'小计' AS khmc,gl_ywfjsba.zydm,gl_ywfjsba.zymc,SUM(byjf) AS byjf,SUM(bydf) AS bydf,SUM(qmye) AS qmye,SUM(jf01) AS jf01,SUM(jf02) AS jf02,SUM(jf03) AS jf03,SUM(jf04) AS jf04,SUM(jf05) AS jf05,SUM(jf06) AS jf06,SUM(jf07) AS jf07,SUM(jf08) AS jf08,SUM(jf09) AS jf09,SUM(jf10) AS jf10,SUM(jf11) AS jf11,SUM(jf12) AS jf12,SUM(jf13) AS jf13,SUM(jf14) AS jf14,SUM(df01) AS df01,SUM(df02) AS df02,SUM(df03) AS df03,SUM(df04) AS df04,SUM(df05) AS df05,SUM(df06) AS df06,SUM(df07) AS df07,SUM(df08) AS df08,SUM(df09) AS df09,SUM(df10) AS df10,SUM(df11) AS df11,SUM(df12) AS df12,SUM(df13) AS df13,SUM(df14) AS df14 FROM (SELECT gl_ywfjsb.khdm,rc_khxx.khmc,rc_khxx.zydm,rc_zyxx.zymc,gl_ywfjsb.skqx,gl_ywfjsb.byjf,gl_ywfjsb.bydf,gl_ywfjsb.qmye,gl_ywfjsb.jf01,gl_ywfjsb.jf02,gl_ywfjsb.jf03,gl_ywfjsb.jf04,gl_ywfjsb.jf05,gl_ywfjsb.jf06,gl_ywfjsb.jf07,gl_ywfjsb.jf08,gl_ywfjsb.jf09,gl_ywfjsb.jf10,gl_ywfjsb.jf11,gl_ywfjsb.jf12,gl_ywfjsb.jf13,gl_ywfjsb.jf14,gl_ywfjsb.df01,gl_ywfjsb.df02,gl_ywfjsb.df03,gl_ywfjsb.df04,gl_ywfjsb.df05,gl_ywfjsb.df06,gl_ywfjsb.df07,gl_ywfjsb.df08,gl_ywfjsb.df09,gl_ywfjsb.df10,gl_ywfjsb.df11,gl_ywfjsb.df12,gl_ywfjsb.df13,gl_ywfjsb.df14 FROM gl_ywfjsb LEFT JOIN rc_khxx ON rc_khxx.khdm = gl_ywfjsb.khdm LEFT JOIN rc_zyxx ON rc_zyxx.zydm = rc_khxx.zydm WHERE cperiod = ?) gl_ywfjsba GROUP BY gl_ywfjsba.zydm,gl_ywfjsba.zymc"
            'rcOleDbCommand.Parameters.Clear()
            'rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            'rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            'rcOleDbDataAdpt.Fill(rcDataSet, "gl_ywfjsb")
            'rcOleDbCommand.CommandText = "SELECT '' AS khdm,'合计' AS khmc,'' AS zydm,'' AS zymc,SUM(byjf) AS byjf,SUM(bydf) AS bydf,SUM(qmye) AS qmye,SUM(jf01) AS jf01,SUM(jf02) AS jf02,SUM(jf03) AS jf03,SUM(jf04) AS jf04,SUM(jf05) AS jf05,SUM(jf06) AS jf06,SUM(jf07) AS jf07,SUM(jf08) AS jf08,SUM(jf09) AS jf09,SUM(jf10) AS jf10,SUM(jf11) AS jf11,SUM(jf12) AS jf12,SUM(jf13) AS jf13,SUM(jf14) AS jf14,SUM(df01) AS df01,SUM(df02) AS df02,SUM(df03) AS df03,SUM(df04) AS df04,SUM(df05) AS df05,SUM(df06) AS df06,SUM(df07) AS df07,SUM(df08) AS df08,SUM(df09) AS df09,SUM(df10) AS df10,SUM(df11) AS df11,SUM(df12) AS df12,SUM(df13) AS df13,SUM(df14) AS df14 FROM (SELECT gl_ywfjsb.khdm,rc_khxx.khmc,rc_khxx.zydm,rc_zyxx.zymc,gl_ywfjsb.skqx,gl_ywfjsb.byjf,gl_ywfjsb.bydf,gl_ywfjsb.qmye,gl_ywfjsb.jf01,gl_ywfjsb.jf02,gl_ywfjsb.jf03,gl_ywfjsb.jf04,gl_ywfjsb.jf05,gl_ywfjsb.jf06,gl_ywfjsb.jf07,gl_ywfjsb.jf08,gl_ywfjsb.jf09,gl_ywfjsb.jf10,gl_ywfjsb.jf11,gl_ywfjsb.jf12,gl_ywfjsb.jf13,gl_ywfjsb.jf14,gl_ywfjsb.df01,gl_ywfjsb.df02,gl_ywfjsb.df03,gl_ywfjsb.df04,gl_ywfjsb.df05,gl_ywfjsb.df06,gl_ywfjsb.df07,gl_ywfjsb.df08,gl_ywfjsb.df09,gl_ywfjsb.df10,gl_ywfjsb.df11,gl_ywfjsb.df12,gl_ywfjsb.df13,gl_ywfjsb.df14 FROM gl_ywfjsb LEFT JOIN rc_khxx ON rc_khxx.khdm = gl_ywfjsb.khdm LEFT JOIN rc_zyxx ON rc_zyxx.zydm = rc_khxx.zydm WHERE cperiod = ?) gl_ywfjsba"
            'rcOleDbCommand.Parameters.Clear()
            'rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            'rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            'rcOleDbDataAdpt.Fill(rcDataSet, "gl_ywfjsb")
            rcOleDbTrans.Commit()
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
        If Me.CheckBox1.Checked Then
            For i = 0 To rcDataset.Tables("ywfzyzzhz").Rows.Count - 1
                If rcDataset.Tables("ywfzyzzhz").Rows(i).Item("bngjdf") = 0 And rcDataset.Tables("ywfzyzzhz").Rows(i).Item("bnfgjdf") = 0 And rcDataset.Tables("ywfzyzzhz").Rows(i).Item("sngjdf") = 0 And rcDataset.Tables("ywfzyzzhz").Rows(i).Item("snfgjdf") = 0 Then
                    rcDataset.Tables("ywfzyzzhz").Rows(i).Delete()
                End If
            Next
        End If
        '调用表单
        Dim rcFrm As New FrmYwfZyzzHzz
        With rcFrm
            .ParaDataSet = rcDataset
            .paraDataView = New DataView(rcDataset.Tables("ywfzyzzhz"), "TRUE", "zydm", DataViewRowState.CurrentRows)
            .Label2.Text = "会计期间：" & Me.NudYear.Value & "年" & Me.NudMonthBegin.Value & "月至" & Me.NudMonthEnd.Value & "月"
            '.Label3.Text = "仓库：" & Trim(Me.TxtCkdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With

    End Sub
End Class