Imports System.Data.OleDb

Public Class FrmGlZlfx
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '数据OleDb更新传递
    Dim rcOleDbTrans As OleDbTransaction
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = sysOleDbConn.CreateCommand()

    Private Sub FrmGlZlfx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim i As Integer
        '默认值
        NudYear.Value = Mid(g_Kjqj, 1, 4)
        NudMonth.Value = Mid(g_Kjqj, 5, 2)
        '预选科目
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT kmdm,kmmc FROM gl_kmxx WHERE kmkh = 1 or kmcs = 1 order by kmdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("gl_kmxx") IsNot Nothing Then
                rcDataset.Tables("gl_kmxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "gl_kmxx")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        For i = 0 To rcDataset.Tables("gl_kmxx").Rows.Count - 1
            ListBoxYuxuanKmdm.Items.Add(rcDataset.Tables("gl_kmxx").Rows(i).Item("kmdm") & " " & rcDataset.Tables("gl_kmxx").Rows(i).Item("kmmc"))
        Next
    End Sub

    Private Sub ListBoxYuxuanKmdm_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBoxYuxuanKmdm.DoubleClick
        If Me.ListBoxYuxuanKmdm.SelectedItem IsNot Nothing Then
            Me.ListBoxYixuanKmdm.Items.Add(Me.ListBoxYuxuanKmdm.SelectedItem)
            Me.ListBoxYuxuanKmdm.Items.Remove(Me.ListBoxYuxuanKmdm.SelectedItem)
        End If
    End Sub

    Private Sub ListBoxYixuanKmdm_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBoxYixuanKmdm.DoubleClick
        If Me.ListBoxYixuanKmdm.SelectedItem IsNot Nothing Then
            Me.ListBoxYuxuanKmdm.Items.Add(Me.ListBoxYixuanKmdm.SelectedItem)
            Me.ListBoxYixuanKmdm.Items.Remove(Me.ListBoxYixuanKmdm.SelectedItem)
        End If
    End Sub

    Private Sub BtnSelectAllKmdm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectAllKmdm.Click
        Dim i As Integer
        For i = 0 To Me.ListBoxYuxuanKmdm.Items.Count - 1
            Me.ListBoxYixuanKmdm.Items.Add(Me.ListBoxYuxuanKmdm.Items(0))
            Me.ListBoxYuxuanKmdm.Items.Remove(Me.ListBoxYuxuanKmdm.Items(0))
        Next
    End Sub

    Private Sub BtnSelectOneKmdm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectOneKmdm.Click
        If Me.ListBoxYuxuanKmdm.SelectedItems.Count > 0 Then
            Me.ListBoxYixuanKmdm.Items.Add(Me.ListBoxYuxuanKmdm.SelectedItem)
            Me.ListBoxYuxuanKmdm.Items.Remove(Me.ListBoxYuxuanKmdm.SelectedItem)
        End If
    End Sub

    Private Sub BtnUnSelectOneKmdm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUnSelectOneKmdm.Click
        If Me.ListBoxYixuanKmdm.SelectedItems.Count > 0 Then
            Me.ListBoxYuxuanKmdm.Items.Add(Me.ListBoxYixuanKmdm.SelectedItem)
            Me.ListBoxYixuanKmdm.Items.Remove(Me.ListBoxYixuanKmdm.SelectedItem)
        End If
    End Sub

    Private Sub BtnUnSelectAllKmdm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUnSelectAllKmdm.Click
        Dim i As Integer
        For i = 0 To Me.ListBoxYixuanKmdm.Items.Count - 1
            Me.ListBoxYuxuanKmdm.Items.Add(Me.ListBoxYixuanKmdm.Items(0))
            Me.ListBoxYixuanKmdm.Items.Remove(Me.ListBoxYixuanKmdm.Items(0))
        Next
    End Sub
    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim i As Integer = 1
        Dim m As Integer = 1
        Dim n As Integer = 1
        '查询科目权限
        If Me.ListBoxYixuanKmdm.Items.Count = 0 Then
            MsgBox("请选择会计科目。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If

        Dim strKmdm As String = ""
        For i = 0 To Me.ListBoxYixuanKmdm.Items.Count - 1
            strKmdm += IIf(i = 0, "", " OR") & " kmdm = '" & Mid(Me.ListBoxYixuanKmdm.Items(i), 1, InStr(Me.ListBoxYixuanKmdm.Items(i), " ") - 1) & "'"
        Next
        If String.IsNullOrEmpty(strKmdm) Then
            strKmdm = "0=0"
        End If

        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '创建临时表
            Me.LblMsg.Text = "正在创建临时表，请稍候......"
            rcOleDbCommand.CommandText = "SELECT * FROM user_tables WHERE table_name='T_GLZLFX'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count > 0 Then
                rcOleDbCommand.CommandText = "DROP Table t_glzlfx"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            End If
            rcOleDbCommand.CommandText = "Create Global Temporary Table t_glzlfx (khdm varchar2(15),khmc varchar2(200),zydm varchar2(12),zymc varchar2(30),skqx number(4,0),qmye number(14,2),je01 number(14,2),je02 number(14,2),je03 number(14,2),je04 number(14,2),je05 number(14,2),je06 number(14,2),je07 number(14,2),dqje number(14,2),yqje number(14,2),byjf number(14,2),bydf number(14,2),ljjf number(14,2),ljdf number(14,2)) on Commit delete Rows"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "alter table T_GLZLFX  add constraint PK_GLZLFX primary key (KHDM)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.ExecuteNonQuery()
            Me.LblMsg.Text = "正在生成账龄分析表......"
            '插入库存数据
            Me.LblMsg.Text = "正在生成gl_kmyeb数据......"
            rcOleDbCommand.CommandText = "INSERT INTO gl_kmyeb (kjnd,kmdm,bmdm,zydm,xmdm,khdm,csdm,yhzh,jxzh) SELECT SUBSTR(djh,5,4) AS kjnd,NVL(kmdm,'~'),NVL(bmdm,'~'),NVL(zydm,'~'),NVL(xmdm,'~'),NVL(khdm,'~'),NVL(csdm,'~'),NVL(yhzh,'~'),NVL(jxzh,'~') FROM gl_pz WHERE gl_pz.cperiod = ? AND NOT EXISTS (SELECT 1 FROM gl_kmyeb WHERE gl_kmyeb.kjnd = ? AND gl_kmyeb.jxzh = NVL(gl_pz.jxzh,'~') AND gl_kmyeb.yhzh = NVL(gl_pz.yhzh,'~') AND gl_kmyeb.csdm = NVL(gl_pz.csdm,'~') AND gl_kmyeb.khdm = NVL(gl_pz.khdm,'~') AND gl_kmyeb.xmdm = NVL(gl_pz.xmdm,'~') AND gl_kmyeb.zydm = NVL(gl_pz.zydm,'~') AND gl_kmyeb.bmdm = NVL(gl_pz.bmdm,'~') AND gl_kmyeb.kmdm = NVL(gl_pz.kmdm,'~')) GROUP BY SUBSTR(djh,5,4),kmdm,bmdm,zydm,xmdm,khdm,csdm,yhzh,jxzh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
            rcOleDbCommand.ExecuteNonQuery()
            If Me.RadioButton1.Checked Then
                '插入客户与年初余额
                rcOleDbCommand.CommandText = "INSERT INTO t_glzlfx (khdm,qmye) SELECT khdm,COALESCE(SUM(CASE WHEN gl_kmyeb.jd = '借' THEN ncje ELSE 0 - ncje END),0.0) AS qmye FROM gl_kmyeb WHERE gl_kmyeb.kjnd = ? AND khdm <> '~' AND (" & strKmdm & ") GROUP BY khdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                rcOleDbCommand.ExecuteNonQuery()
                '计算期末余额
                rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET qmye = qmye + (SELECT COALESCE(SUM(CASE WHEN gl_pz.jd = '借' THEN je ELSE 0 - je END),0.0) FROM gl_pz WHERE gl_pz.khdm = t_glzlfx.khdm  AND (" & strKmdm & ") AND gl_pz.cperiod<= ? AND gl_pz.cperiod>= ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & "01"
                rcOleDbCommand.ExecuteNonQuery()
                '更新收款期限
                rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET skqx = (SELECT skqx FROM rc_khxx WHERE rc_khxx.khdm = t_glzlfx.khdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '更新1至6个月借方金额'
                For i = 1 To 6
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET je" & i.ToString.PadLeft(2, "0") & " = (SELECT COALESCE(SUM(je),0.0) FROM gl_pz WHERE gl_pz.khdm = t_glzlfx.khdm AND (" & strKmdm & ") AND gl_pz.jd = '借' AND gl_pz.cperiod= ?)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = IIf(Me.NudMonth.Value - i + 1 <= 0, (Me.NudYear.Value - 1).ToString & (Me.NudMonth.Value - i + 13).ToString.PadLeft(2, "0"), Me.NudYear.Value.ToString & (Me.NudMonth.Value - i + 1).ToString.PadLeft(2, "0"))
                    rcOleDbCommand.ExecuteNonQuery()
                Next
                '本月发出
                rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET byjf = (SELECT COALESCE(SUM(je),0.0) FROM gl_pz WHERE gl_pz.khdm = t_glzlfx.khdm  AND (" & strKmdm & ") AND gl_pz.jd = '借' AND gl_pz.cperiod= ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                '本月收款
                rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET bydf = (SELECT COALESCE(SUM(je),0.0) FROM gl_pz WHERE gl_pz.khdm = t_glzlfx.khdm  AND (" & strKmdm & ") AND gl_pz.jd = '贷' AND gl_pz.cperiod= ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                '累计发出
                rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET ljjf = (SELECT COALESCE(SUM(je),0.0) FROM gl_pz WHERE gl_pz.khdm = t_glzlfx.khdm  AND (" & strKmdm & ") AND gl_pz.jd = '借' AND gl_pz.cperiod<= ? AND gl_pz.cperiod>= ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & "01"
                rcOleDbCommand.ExecuteNonQuery()
                '累计收款
                rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET ljdf = (SELECT COALESCE(SUM(je),0.0) FROM gl_pz WHERE gl_pz.khdm = t_glzlfx.khdm  AND (" & strKmdm & ") AND gl_pz.jd = '贷' AND gl_pz.cperiod<= ? AND gl_pz.cperiod>= ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & "01"
                rcOleDbCommand.ExecuteNonQuery()
                '根据余额进行分解
                rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET je01 = qmye,je02 = 0,je03 = 0,je04 = 0,je05 = 0,je06 = 0,je07 = 0 WHERE qmye <= 0"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '调整当月收款金额小于0的为0，并相应的调整发生额
                rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET je01 = CASE WHEN je01 < 0 THEN 0 ELSE je01 END,je02 = CASE WHEN je02 < 0 THEN 0 ELSE je02 END,je03 = CASE WHEN je03 < 0 THEN 0 ELSE je03 END,je04 = CASE WHEN je04 < 0 THEN 0 ELSE je04 END,je05 = CASE WHEN je05 < 0 THEN 0 ELSE je05 END,je06 = CASE WHEN je06 < 0 THEN 0 ELSE je06 END,je07 = CASE WHEN je07 < 0 THEN 0 ELSE je07 END WHERE qmye > 0"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET je07 = CASE WHEN qmye > je01 + je02 + je03 + je04 + je05 + je06 THEN qmye -je01 -je02 -je03 -je04 -je05 - je06 ELSE 0.0 END WHERE qmye > 0"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET je06 = CASE WHEN qmye > je01 + je02 + je03 + je04 + je05 THEN CASE WHEN qmye > je01 + je02 + je03 + je04 + je05 + je06 THEN je06 ELSE qmye -je01 -je02 -je03 -je04 -je05 END ELSE 0.0 END WHERE qmye > 0"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET je05 = CASE WHEN qmye > je01 + je02 + je03 + je04 THEN CASE WHEN qmye > je01 + je02 + je03 + je04 + je05 THEN je05 ELSE qmye -je01 -je02 -je03 -je04 END ELSE 0.0 END WHERE qmye > 0"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET je04 = CASE WHEN qmye > je01 + je02 + je03 THEN CASE WHEN qmye > je01 + je02 + je03 + je04 THEN je04 ELSE qmye - je01 -je02 -je03 END ELSE 0.0 END WHERE qmye > 0"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET je03 = CASE WHEN qmye > je01 + je02 THEN CASE WHEN qmye > je01 + je02 + je03 THEN je03 ELSE qmye -je01 -je02 END ELSE 0.0 END WHERE qmye > 0"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET je02 = CASE WHEN qmye > je01 THEN CASE WHEN qmye > je01 + je02 THEN je02 ELSE qmye - je01 END ELSE 0.0 END WHERE qmye > 0"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET je01 = CASE WHEN qmye <= je01 THEN qmye ELSE je01 END WHERE qmye > 0"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '到期款/逾期款

                ''0天 预收款
                'rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET dqje = qmye,yqje = qmye WHERE qmye > 0 AND skqx = 0"
                rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET dqje = je01 + je02 + je03 + je04 + je05 + je06 + je07,yqje = je02 + je03 + je04 + je05 + je06 + je07 WHERE qmye > 0 AND skqx = 0"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '30天
                rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET dqje = je02 + je03 + je04 + je05 + je06 + je07,yqje = je03 + je04 + je05 + je06 + je07 WHERE qmye > 0 AND skqx = 30"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '60
                rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET dqje = je03 + je04 + je05 + je06 + je07,yqje = je04 + je05 + je06 + je07 WHERE qmye > 0 AND skqx = 60"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '90
                rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET dqje = je04 + je05 + je06 + je07,yqje = je05 + je06 + je07 WHERE qmye > 0 AND skqx = 90"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '120
                rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET dqje = je05 + je06 + je07,yqje = je06 + je07 WHERE qmye > 0 AND skqx = 120"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '150
                rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET dqje = je06 + je07,yqje = je07  WHERE qmye > 0 AND skqx = 150"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '180
                rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET dqje = je07,yqje = je07 WHERE qmye > 0 AND skqx = 180"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '增加只显示挂靠客户的条件
                rcOleDbCommand.CommandText = "SELECT t_glzlfx.khdm,rc_khxx.khmc,rc_khxx.zydm,rc_zyxx.zymc,t_glzlfx.skqx,t_glzlfx.qmye,t_glzlfx.je01,t_glzlfx.je02,t_glzlfx.je03,t_glzlfx.je04,t_glzlfx.je05,t_glzlfx.je06,t_glzlfx.je07,t_glzlfx.dqje,t_glzlfx.yqje,t_glzlfx.byjf,t_glzlfx.bydf,t_glzlfx.ljjf,t_glzlfx.ljdf FROM t_glzlfx LEFT JOIN rc_khxx ON rc_khxx.khdm = t_glzlfx.khdm LEFT JOIN rc_zyxx ON rc_zyxx.zydm = rc_khxx.zydm " & IIf(Me.ChbBGuaKao.Checked, " where exists (select 1 from rc_khxx where rc_khxx.bguakao = 1 and rc_khxx.khdm = t_glzlfx.khdm)", "") & IIf(Me.ChbBNotGuaKao.Checked, " where exists (select 1 from rc_khxx where rc_khxx.bguakao <> 1 and rc_khxx.khdm = t_glzlfx.khdm)", "") & " ORDER BY t_glzlfx.khdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("glzlfx") IsNot Nothing Then
                    rcDataset.Tables("glzlfx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "glzlfx")
                rcOleDbCommand.CommandText = "SELECT '' AS khdm,glzlfxa.zymc AS khmc,glzlfxa.zydm,glzlfxa.zymc,SUM(qmye) AS qmye,SUM(je01) AS je01,SUM(je02) AS je02,SUM(je03) AS je03,SUM(je04) AS je04,SUM(je05) AS je05,SUM(je06) AS je06,SUM(je07) AS je07,SUM(dqje) AS dqje,SUM(yqje) AS yqje,SUM(byjf) AS byjf,SUM(bydf) AS bydf,SUM(ljjf) AS ljjf,SUM(ljdf) AS ljdf FROM (SELECT t_glzlfx.khdm,rc_khxx.khmc,rc_khxx.zydm,rc_zyxx.zymc,t_glzlfx.skqx,t_glzlfx.qmye,t_glzlfx.je01,t_glzlfx.je02,t_glzlfx.je03,t_glzlfx.je04,t_glzlfx.je05,t_glzlfx.je06,t_glzlfx.je07,t_glzlfx.dqje,t_glzlfx.yqje,t_glzlfx.byjf,t_glzlfx.bydf,t_glzlfx.ljjf,t_glzlfx.ljdf FROM t_glzlfx LEFT JOIN rc_khxx ON rc_khxx.khdm = t_glzlfx.khdm LEFT JOIN rc_zyxx ON rc_zyxx.zydm = rc_khxx.zydm" & IIf(Me.ChbBGuaKao.Checked, " where exists (select 1 from rc_khxx where rc_khxx.bguakao = 1 and rc_khxx.khdm = t_glzlfx.khdm)", "") & IIf(Me.ChbBNotGuaKao.Checked, " where exists (select 1 from rc_khxx where rc_khxx.bguakao <> 1 and rc_khxx.khdm = t_glzlfx.khdm)", "") & ") glzlfxa GROUP BY glzlfxa.zydm,glzlfxa.zymc"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                rcOleDbDataAdpt.Fill(rcDataset, "glzlfx")
                rcOleDbCommand.CommandText = "SELECT '' AS khdm,'合计' AS khmc,'' AS zydm,'' AS zymc,SUM(qmye) AS qmye,SUM(je01) AS je01,SUM(je02) AS je02,SUM(je03) AS je03,SUM(je04) AS je04,SUM(je05) AS je05,SUM(je06) AS je06,SUM(je07) AS je07,SUM(dqje) AS dqje,SUM(yqje) AS yqje,SUM(byjf) AS byjf,SUM(bydf) AS bydf,SUM(ljjf) AS ljjf,SUM(ljdf) AS ljdf FROM (SELECT t_glzlfx.khdm,rc_khxx.khmc,rc_khxx.zydm,rc_zyxx.zymc,t_glzlfx.skqx,t_glzlfx.qmye,t_glzlfx.je01,t_glzlfx.je02,t_glzlfx.je03,t_glzlfx.je04,t_glzlfx.je05,t_glzlfx.je06,t_glzlfx.je07,t_glzlfx.dqje,t_glzlfx.yqje,t_glzlfx.byjf,t_glzlfx.bydf,t_glzlfx.ljjf,t_glzlfx.ljdf FROM t_glzlfx LEFT JOIN rc_khxx ON rc_khxx.khdm = t_glzlfx.khdm LEFT JOIN rc_zyxx ON rc_zyxx.zydm = rc_khxx.zydm" & IIf(Me.ChbBGuaKao.Checked, " where exists (select 1 from rc_khxx where rc_khxx.bguakao = 1 and rc_khxx.khdm = t_glzlfx.khdm)", "") & IIf(Me.ChbBNotGuaKao.Checked, " where exists (select 1 from rc_khxx where rc_khxx.bguakao <> 1 and rc_khxx.khdm = t_glzlfx.khdm)", "") & ") glzlfxa"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                rcOleDbDataAdpt.Fill(rcDataset, "glzlfx")
            Else
                If Me.RadioButton2.Checked Then
                    '供应商
                    '插入供应商与年初余额
                    rcOleDbCommand.CommandText = "INSERT INTO t_glzlfx (khdm,qmye) SELECT csdm AS khdm,COALESCE(SUM(CASE WHEN gl_kmyeb.jd = '贷' THEN ncje ELSE 0 - ncje END),0.0) AS qmye FROM gl_kmyeb WHERE gl_kmyeb.kjnd = ? AND csdm <> '~' AND (" & strKmdm & ") GROUP BY csdm"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                    rcOleDbCommand.ExecuteNonQuery()
                    '计算期末余额
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET qmye = qmye + (SELECT COALESCE(SUM(CASE WHEN gl_pz.jd = '贷' THEN je ELSE 0 - je END),0.0) FROM gl_pz WHERE gl_pz.csdm = t_glzlfx.khdm AND (" & strKmdm & ") AND gl_pz.cperiod<= ? AND gl_pz.cperiod>= ?)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & "01"
                    rcOleDbCommand.ExecuteNonQuery()
                    '更新收款期限
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET skqx = (SELECT fkts FROM rc_csxx WHERE rc_csxx.csdm = t_glzlfx.khdm)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    '更新1至6个月贷方金额'
                    For i = 1 To 6
                        rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET je" & i.ToString.PadLeft(2, "0") & " = (SELECT COALESCE(SUM(je),0.0) FROM gl_pz WHERE gl_pz.csdm = t_glzlfx.khdm AND gl_pz.jd = '贷' AND (" & strKmdm & ") AND gl_pz.cperiod= ?)"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = IIf(Me.NudMonth.Value - i + 1 <= 0, (Me.NudYear.Value - 1).ToString & (Me.NudMonth.Value - i + 13).ToString.PadLeft(2, "0"), Me.NudYear.Value.ToString & (Me.NudMonth.Value - i + 1).ToString.PadLeft(2, "0"))
                        rcOleDbCommand.ExecuteNonQuery()
                    Next
                    '本月发出
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET byjf = (SELECT COALESCE(SUM(je),0.0) FROM gl_pz WHERE gl_pz.csdm = t_glzlfx.khdm AND (" & strKmdm & ") AND gl_pz.jd = '贷' AND gl_pz.cperiod= ?)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.ExecuteNonQuery()
                    '本月收款
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET bydf = (SELECT COALESCE(SUM(je),0.0) FROM gl_pz WHERE gl_pz.csdm = t_glzlfx.khdm AND (" & strKmdm & ") AND gl_pz.jd = '借' AND gl_pz.cperiod= ?)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.ExecuteNonQuery()
                    '累计发出
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET ljjf = (SELECT COALESCE(SUM(je),0.0) FROM gl_pz WHERE gl_pz.csdm = t_glzlfx.khdm AND (" & strKmdm & ") AND gl_pz.jd = '贷' AND gl_pz.cperiod<= ? AND gl_pz.cperiod>= ?)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & "01"
                    rcOleDbCommand.ExecuteNonQuery()
                    '累计收款
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET ljdf = (SELECT COALESCE(SUM(je),0.0) FROM gl_pz WHERE gl_pz.csdm = t_glzlfx.khdm AND (" & strKmdm & ") AND gl_pz.jd = '借' AND gl_pz.cperiod<= ? AND gl_pz.cperiod>= ?)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & "01"
                    rcOleDbCommand.ExecuteNonQuery()
                    '根据余额进行分解
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET je01 = qmye,je02 = 0,je03 = 0,je04 = 0,je05 = 0,je06 = 0,je07 = 0 WHERE qmye <= 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET je07 = CASE WHEN qmye > je01 + je02 + je03 + je04 + je05 + je06 THEN qmye -je01 -je02 -je03 -je04 -je05 - je06 ELSE 0.0 END WHERE qmye > 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET je06 = CASE WHEN qmye > je01 + je02 + je03 + je04 + je05 THEN CASE WHEN qmye > je01 + je02 + je03 + je04 + je05 + je06 THEN je06 ELSE qmye -je01 -je02 -je03 -je04 -je05 END ELSE 0.0 END WHERE qmye > 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET je05 = CASE WHEN qmye > je01 + je02 + je03 + je04 THEN CASE WHEN qmye > je01 + je02 + je03 + je04 + je05 THEN je05 ELSE qmye -je01 -je02 -je03 -je04 END ELSE 0.0 END WHERE qmye > 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET je04 = CASE WHEN qmye > je01 + je02 + je03 THEN CASE WHEN qmye > je01 + je02 + je03 + je04 THEN je04 ELSE qmye - je01 -je02 -je03 END ELSE 0.0 END WHERE qmye > 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET je03 = CASE WHEN qmye > je01 + je02 THEN CASE WHEN qmye > je01 + je02 + je03 THEN je03 ELSE qmye -je01 -je02 END ELSE 0.0 END WHERE qmye > 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET je02 = CASE WHEN qmye > je01 THEN CASE WHEN qmye > je01 + je02 THEN je02 ELSE qmye - je01 END ELSE 0.0 END WHERE qmye > 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET je01 = CASE WHEN qmye <= je01 THEN qmye ELSE je01 END WHERE qmye > 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    '到期款/逾期款

                    ''0天 预收款
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET dqje = je01 + je02 + je03 + je04 + je05 + je06 + je07,yqje = je02 + je03 + je04 + je05 + je06 + je07 WHERE qmye > 0 AND skqx = 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    '30天
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET dqje = je02 + je03 + je04 + je05 + je06 + je07,yqje = je03 + je04 + je05 + je06 + je07 WHERE qmye > 0 AND skqx = 30"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    '60
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET dqje = je03 + je04 + je05 + je06 + je07,yqje = je04 + je05 + je06 + je07 WHERE qmye > 0 AND skqx = 60"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    '90
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET dqje = je04 + je05 + je06 + je07,yqje = je05 + je06 + je07 WHERE qmye > 0 AND skqx = 90"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    '120
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET dqje = je05 + je06 + je07,yqje = je06 + je07 WHERE qmye > 0 AND skqx = 120"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    '150
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET dqje = je06 + je07,yqje = je07  WHERE qmye > 0 AND skqx = 150"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    '180
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET dqje = je07,yqje = je07 WHERE qmye > 0 AND skqx = 180"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "SELECT t_glzlfx.khdm,rc_csxx.csmc AS khmc,rc_csxx.zydm,rc_zyxx.zymc,t_glzlfx.skqx,t_glzlfx.qmye,t_glzlfx.je01,t_glzlfx.je02,t_glzlfx.je03,t_glzlfx.je04,t_glzlfx.je05,t_glzlfx.je06,t_glzlfx.je07,t_glzlfx.dqje,t_glzlfx.yqje,t_glzlfx.byjf,t_glzlfx.bydf,t_glzlfx.ljjf,t_glzlfx.ljdf FROM t_glzlfx LEFT JOIN rc_csxx ON rc_csxx.csdm = t_glzlfx.khdm LEFT JOIN rc_zyxx ON rc_zyxx.zydm = rc_csxx.zydm"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("glzlfx") IsNot Nothing Then
                        rcDataset.Tables("glzlfx").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "glzlfx")
                    rcOleDbCommand.CommandText = "SELECT '' AS khdm,glzlfxa.zymc AS khmc,glzlfxa.zydm,glzlfxa.zymc,SUM(qmye) AS qmye,SUM(je01) AS je01,SUM(je02) AS je02,SUM(je03) AS je03,SUM(je04) AS je04,SUM(je05) AS je05,SUM(je06) AS je06,SUM(je07) AS je07,SUM(dqje) AS dqje,SUM(yqje) AS yqje,SUM(byjf) AS byjf,SUM(bydf) AS bydf,SUM(ljjf) AS ljjf,SUM(ljdf) AS ljdf FROM (SELECT t_glzlfx.khdm,rc_csxx.csmc AS khmc,rc_csxx.zydm,rc_zyxx.zymc,t_glzlfx.skqx,t_glzlfx.qmye,t_glzlfx.je01,t_glzlfx.je02,t_glzlfx.je03,t_glzlfx.je04,t_glzlfx.je05,t_glzlfx.je06,t_glzlfx.je07,t_glzlfx.dqje,t_glzlfx.yqje,t_glzlfx.byjf,t_glzlfx.bydf,t_glzlfx.ljjf,t_glzlfx.ljdf FROM t_glzlfx LEFT JOIN rc_csxx ON rc_csxx.csdm = t_glzlfx.khdm LEFT JOIN rc_zyxx ON rc_zyxx.zydm = rc_csxx.zydm) glzlfxa GROUP BY glzlfxa.zydm,glzlfxa.zymc"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    rcOleDbDataAdpt.Fill(rcDataset, "glzlfx")
                    rcOleDbCommand.CommandText = "SELECT '' AS khdm,'合计' AS khmc,'' AS zydm,'' AS zymc,SUM(qmye) AS qmye,SUM(je01) AS je01,SUM(je02) AS je02,SUM(je03) AS je03,SUM(je04) AS je04,SUM(je05) AS je05,SUM(je06) AS je06,SUM(je07) AS je07,SUM(dqje) AS dqje,SUM(yqje) AS yqje,SUM(byjf) AS byjf,SUM(bydf) AS bydf,SUM(ljjf) AS ljjf,SUM(ljdf) AS ljdf FROM (SELECT t_glzlfx.khdm,rc_csxx.csmc AS khmc,rc_csxx.zydm,rc_zyxx.zymc,t_glzlfx.skqx,t_glzlfx.qmye,t_glzlfx.je01,t_glzlfx.je02,t_glzlfx.je03,t_glzlfx.je04,t_glzlfx.je05,t_glzlfx.je06,t_glzlfx.je07,t_glzlfx.dqje,t_glzlfx.yqje,t_glzlfx.byjf,t_glzlfx.bydf,t_glzlfx.ljjf,t_glzlfx.ljdf FROM t_glzlfx LEFT JOIN rc_csxx ON rc_csxx.csdm = t_glzlfx.khdm LEFT JOIN rc_zyxx ON rc_zyxx.zydm = rc_csxx.zydm) glzlfxa"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    rcOleDbDataAdpt.Fill(rcDataset, "glzlfx")
                Else
                    '插入供应商与年初余额
                    rcOleDbCommand.CommandText = "INSERT INTO t_glzlfx (khdm,qmye) SELECT csdm AS khdm,COALESCE(SUM(CASE WHEN gl_kmyeb.jd = '借' THEN ncje ELSE 0 - ncje END),0.0) AS qmye FROM gl_kmyeb WHERE gl_kmyeb.kjnd = ? AND csdm <> '~' AND (" & strKmdm & ") GROUP BY csdm"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                    rcOleDbCommand.ExecuteNonQuery()
                    '计算期末余额
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET qmye = qmye + (SELECT COALESCE(SUM(CASE WHEN gl_pz.jd = '借' THEN je ELSE 0 - je END),0.0) FROM gl_pz WHERE gl_pz.csdm = t_glzlfx.khdm  AND (" & strKmdm & ") AND gl_pz.cperiod<= ? AND gl_pz.cperiod>= ?)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & "01"
                    rcOleDbCommand.ExecuteNonQuery()
                    '更新收款期限
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET skqx = (SELECT fkts FROM rc_csxx WHERE rc_csxx.csdm = t_glzlfx.khdm)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    '更新1至6个月借方金额'
                    For i = 1 To 6
                        rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET je" & i.ToString.PadLeft(2, "0") & " = (SELECT COALESCE(SUM(je),0.0) FROM gl_pz WHERE gl_pz.csdm = t_glzlfx.khdm AND (" & strKmdm & ") AND gl_pz.jd = '借' AND gl_pz.cperiod= ?)"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = IIf(Me.NudMonth.Value - i + 1 <= 0, (Me.NudYear.Value - 1).ToString & (Me.NudMonth.Value - i + 13).ToString.PadLeft(2, "0"), Me.NudYear.Value.ToString & (Me.NudMonth.Value - i + 1).ToString.PadLeft(2, "0"))
                        rcOleDbCommand.ExecuteNonQuery()
                    Next
                    '本月发出
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET byjf = (SELECT COALESCE(SUM(je),0.0) FROM gl_pz WHERE gl_pz.csdm = t_glzlfx.khdm  AND (" & strKmdm & ") AND gl_pz.jd = '借' AND gl_pz.cperiod= ?)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.ExecuteNonQuery()
                    '本月收款
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET bydf = (SELECT COALESCE(SUM(je),0.0) FROM gl_pz WHERE gl_pz.csdm = t_glzlfx.khdm  AND (" & strKmdm & ") AND gl_pz.jd = '贷' AND gl_pz.cperiod= ?)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.ExecuteNonQuery()
                    '累计发出
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET ljjf = (SELECT COALESCE(SUM(je),0.0) FROM gl_pz WHERE gl_pz.csdm = t_glzlfx.khdm  AND (" & strKmdm & ") AND gl_pz.jd = '借' AND gl_pz.cperiod<= ? AND gl_pz.cperiod>= ?)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & "01"
                    rcOleDbCommand.ExecuteNonQuery()
                    '累计收款
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET ljdf = (SELECT COALESCE(SUM(je),0.0) FROM gl_pz WHERE gl_pz.csdm = t_glzlfx.khdm  AND (" & strKmdm & ") AND gl_pz.jd = '贷' AND gl_pz.cperiod<= ? AND gl_pz.cperiod>= ?)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & "01"
                    rcOleDbCommand.ExecuteNonQuery()
                    '根据余额进行分解
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET je01 = qmye,je02 = 0,je03 = 0,je04 = 0,je05 = 0,je06 = 0,je07 = 0 WHERE qmye <= 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    '调整当月收款金额小于0的为0，并相应的调整发生额
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET je01 = CASE WHEN je01 < 0 THEN 0 ELSE je01 END,je02 = CASE WHEN je02 < 0 THEN 0 ELSE je02 END,je03 = CASE WHEN je03 < 0 THEN 0 ELSE je03 END,je04 = CASE WHEN je04 < 0 THEN 0 ELSE je04 END,je05 = CASE WHEN je05 < 0 THEN 0 ELSE je05 END,je06 = CASE WHEN je06 < 0 THEN 0 ELSE je06 END,je07 = CASE WHEN je07 < 0 THEN 0 ELSE je07 END WHERE qmye > 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET je07 = CASE WHEN qmye > je01 + je02 + je03 + je04 + je05 + je06 THEN qmye -je01 -je02 -je03 -je04 -je05 - je06 ELSE 0.0 END WHERE qmye > 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET je06 = CASE WHEN qmye > je01 + je02 + je03 + je04 + je05 THEN CASE WHEN qmye > je01 + je02 + je03 + je04 + je05 + je06 THEN je06 ELSE qmye -je01 -je02 -je03 -je04 -je05 END ELSE 0.0 END WHERE qmye > 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET je05 = CASE WHEN qmye > je01 + je02 + je03 + je04 THEN CASE WHEN qmye > je01 + je02 + je03 + je04 + je05 THEN je05 ELSE qmye -je01 -je02 -je03 -je04 END ELSE 0.0 END WHERE qmye > 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET je04 = CASE WHEN qmye > je01 + je02 + je03 THEN CASE WHEN qmye > je01 + je02 + je03 + je04 THEN je04 ELSE qmye - je01 -je02 -je03 END ELSE 0.0 END WHERE qmye > 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET je03 = CASE WHEN qmye > je01 + je02 THEN CASE WHEN qmye > je01 + je02 + je03 THEN je03 ELSE qmye -je01 -je02 END ELSE 0.0 END WHERE qmye > 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET je02 = CASE WHEN qmye > je01 THEN CASE WHEN qmye > je01 + je02 THEN je02 ELSE qmye - je01 END ELSE 0.0 END WHERE qmye > 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET je01 = CASE WHEN qmye <= je01 THEN qmye ELSE je01 END WHERE qmye > 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    '到期款/逾期款

                    ''0天 预收款
                    'rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET dqje = qmye,yqje = qmye WHERE qmye > 0 AND skqx = 0"
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET dqje = je01 + je02 + je03 + je04 + je05 + je06 + je07,yqje = je02 + je03 + je04 + je05 + je06 + je07 WHERE qmye > 0 AND skqx = 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    '30天
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET dqje = je02 + je03 + je04 + je05 + je06 + je07,yqje = je03 + je04 + je05 + je06 + je07 WHERE qmye > 0 AND skqx = 30"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    '60
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET dqje = je03 + je04 + je05 + je06 + je07,yqje = je04 + je05 + je06 + je07 WHERE qmye > 0 AND skqx = 60"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    '90
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET dqje = je04 + je05 + je06 + je07,yqje = je05 + je06 + je07 WHERE qmye > 0 AND skqx = 90"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    '120
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET dqje = je05 + je06 + je07,yqje = je06 + je07 WHERE qmye > 0 AND skqx = 120"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    '150
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET dqje = je06 + je07,yqje = je07  WHERE qmye > 0 AND skqx = 150"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    '180
                    rcOleDbCommand.CommandText = "UPDATE t_glzlfx SET dqje = je07,yqje = je07 WHERE qmye > 0 AND skqx = 180"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "SELECT t_glzlfx.khdm,rc_csxx.csmc AS khmc,rc_csxx.zydm,rc_zyxx.zymc,t_glzlfx.skqx,t_glzlfx.qmye,t_glzlfx.je01,t_glzlfx.je02,t_glzlfx.je03,t_glzlfx.je04,t_glzlfx.je05,t_glzlfx.je06,t_glzlfx.je07,t_glzlfx.dqje,t_glzlfx.yqje,t_glzlfx.byjf,t_glzlfx.bydf,t_glzlfx.ljjf,t_glzlfx.ljdf FROM t_glzlfx LEFT JOIN rc_csxx ON rc_csxx.csdm = t_glzlfx.khdm LEFT JOIN rc_zyxx ON rc_zyxx.zydm = rc_csxx.zydm ORDER BY t_glzlfx.khdm"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("glzlfx") IsNot Nothing Then
                        rcDataset.Tables("glzlfx").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "glzlfx")
                    rcOleDbCommand.CommandText = "SELECT '' AS khdm,glzlfxa.zymc AS khmc,glzlfxa.zydm,glzlfxa.zymc,SUM(qmye) AS qmye,SUM(je01) AS je01,SUM(je02) AS je02,SUM(je03) AS je03,SUM(je04) AS je04,SUM(je05) AS je05,SUM(je06) AS je06,SUM(je07) AS je07,SUM(dqje) AS dqje,SUM(yqje) AS yqje,SUM(byjf) AS byjf,SUM(bydf) AS bydf,SUM(ljjf) AS ljjf,SUM(ljdf) AS ljdf FROM (SELECT t_glzlfx.khdm,rc_csxx.csmc AS khmc,rc_csxx.zydm,rc_zyxx.zymc,t_glzlfx.skqx,t_glzlfx.qmye,t_glzlfx.je01,t_glzlfx.je02,t_glzlfx.je03,t_glzlfx.je04,t_glzlfx.je05,t_glzlfx.je06,t_glzlfx.je07,t_glzlfx.dqje,t_glzlfx.yqje,t_glzlfx.byjf,t_glzlfx.bydf,t_glzlfx.ljjf,t_glzlfx.ljdf FROM t_glzlfx LEFT JOIN rc_csxx ON rc_csxx.csdm = t_glzlfx.khdm LEFT JOIN rc_zyxx ON rc_zyxx.zydm = rc_csxx.zydm) glzlfxa GROUP BY glzlfxa.zydm,glzlfxa.zymc"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    rcOleDbDataAdpt.Fill(rcDataset, "glzlfx")
                    rcOleDbCommand.CommandText = "SELECT '' AS khdm,'合计' AS khmc,'' AS zydm,'' AS zymc,SUM(qmye) AS qmye,SUM(je01) AS je01,SUM(je02) AS je02,SUM(je03) AS je03,SUM(je04) AS je04,SUM(je05) AS je05,SUM(je06) AS je06,SUM(je07) AS je07,SUM(dqje) AS dqje,SUM(yqje) AS yqje,SUM(byjf) AS byjf,SUM(bydf) AS bydf,SUM(ljjf) AS ljjf,SUM(ljdf) AS ljdf FROM (SELECT t_glzlfx.khdm,rc_csxx.csmc AS khmc,rc_csxx.zydm,rc_zyxx.zymc,t_glzlfx.skqx,t_glzlfx.qmye,t_glzlfx.je01,t_glzlfx.je02,t_glzlfx.je03,t_glzlfx.je04,t_glzlfx.je05,t_glzlfx.je06,t_glzlfx.je07,t_glzlfx.dqje,t_glzlfx.yqje,t_glzlfx.byjf,t_glzlfx.bydf,t_glzlfx.ljjf,t_glzlfx.ljdf FROM t_glzlfx LEFT JOIN rc_csxx ON rc_csxx.csdm = t_glzlfx.khdm LEFT JOIN rc_zyxx ON rc_zyxx.zydm = rc_csxx.zydm) glzlfxa"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    rcOleDbDataAdpt.Fill(rcDataset, "glzlfx")
                End If
            End If
            rcOleDbTrans.Commit()
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If Me.CheckBox1.Checked Then
            For i = 0 To rcDataset.Tables("glzlfx").Rows.Count - 1
                If rcDataset.Tables("glzlfx").Rows(i).Item("byjf") = 0 And rcDataset.Tables("glzlfx").Rows(i).Item("bydf") = 0 And rcDataset.Tables("glzlfx").Rows(i).Item("ljjf") = 0 And rcDataset.Tables("glzlfx").Rows(i).Item("ljdf") = 0 And rcDataset.Tables("glzlfx").Rows(i).Item("qmye") = 0 Then
                    rcDataset.Tables("glzlfx").Rows(i).Delete()
                End If
            Next
        End If
        'Dim rcDataRow As DataRow
        'rcDataRow = rcDataset.Tables("cpsfchz").NewRow
        'rcDataRow.Item("cpdm") = "合计"
        'rcDataRow.Item("kcsl_tot") = rcDataset.Tables("cpsfchz").Compute("Sum(kcsl_tot)", "")
        'rcDataRow.Item("kcje_tot") = rcDataset.Tables("cpsfchz").Compute("Sum(kcje_tot)", "")
        'For i = 0 To rcDataset.Tables("rc_kczlfd").Rows.Count - 1
        '    rcDataRow.Item("kcsl_" & (i + 1).ToString.PadLeft(2, "0")) = rcDataset.Tables("cpsfchz").Compute("Sum(kcsl_" & (i + 1).ToString.PadLeft(2, "0") & ")", "")
        '    rcDataRow.Item("kcje_" & (i + 1).ToString.PadLeft(2, "0")) = rcDataset.Tables("cpsfchz").Compute("Sum(kcje_" & (i + 1).ToString.PadLeft(2, "0") & ")", "")
        'Next
        'rcDataset.Tables("cpsfchz").Rows.Add(rcDataRow)

        '调用表单
        Dim rcFrm As New FrmGlZlfxz
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("glzlfx"), "TRUE", "zydm,khdm", DataViewRowState.CurrentRows)
            '.Label2.Text = "盘点日期：" & Me.DtpPcrq.Value
            '.Label3.Text = "仓库：" & Trim(Me.TxtCkdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

    Private Sub ChbBGuaKao_CheckedChanged(sender As Object, e As EventArgs) Handles ChbBGuaKao.CheckedChanged
        If Me.ChbBGuaKao.Checked Then
            Me.ChbBNotGuaKao.Checked = False
        End If
    End Sub

    Private Sub ChbBNotGuaKao_CheckedChanged(sender As Object, e As EventArgs) Handles ChbBNotGuaKao.CheckedChanged
        If Me.ChbBNotGuaKao.Checked Then
            Me.ChbBGuaKao.Checked = False
        End If
    End Sub
End Class