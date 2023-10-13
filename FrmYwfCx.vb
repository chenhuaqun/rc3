Imports System.Data.OleDb

Public Class FrmYwfCx
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

#Region "初始化"

    Private Sub FrmDjjz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        Me.NudYear.Value = Mid(g_Kjqj, 1, 4)
        Me.NudMonthBegin.Value = Mid(g_Kjqj, 5, 2)
        Me.NudMonthEnd.Value = Mid(g_Kjqj, 5, 2)
    End Sub

#End Region

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NudYear.KeyPress, NudMonthBegin.KeyPress, NudMonthEnd.KeyPress, TxtZydm.KeyPress, TxtKhdm.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
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
                    .paraTitle = "职员"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtZydm.Text = Trim(.paraField1)
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
                rcOleDbCommand.CommandText = "SELECT zydm,zymc FROM rc_zyxx WHERE (zydm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(TxtZydm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_zyxx") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_zyxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_zyxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_zyxx").Rows.Count > 0 Then
                Me.TxtZydm.Text = Trim(rcDataSet.Tables("rc_zyxx").Rows(0).Item("zydm"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "客户编码事件"

    Private Sub TxtKhdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtKhdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_khxx"
                    .paraField1 = "khdm"
                    .paraField2 = "khmc"
                    .paraField3 = "khsm"
                    .paraCondition = "0=0"
                    .paraOrderField = "khmc"
                    .paraTitle = "客户"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtKhdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

#End Region


    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim dateKsrq As Date '成本结转开始日期
        Dim dateJsrq As Date '成本结转结束日期
        dateKsrq = getInvBegin(Me.NudYear.Value, Me.NudMonthBegin.Value)
        dateJsrq = getInvEnd(Me.NudYear.Value, Me.NudMonthBegin.Value)
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT gl_ywfjsb.cperiod,gl_ywfjsb.khdm,gl_ywfjsb.khmc,gl_ywfjsb.zydm,gl_ywfjsb.zymc,gl_ywfjsb.xslbdm,gl_ywfjsb.ywfbl,gl_ywfjsb.newkhbl,gl_ywfjsb.skqx,gl_ywfjsb.byjf,gl_ywfjsb.bydf,gl_ywfjsb.qmye,gl_ywfjsb.jf01,gl_ywfjsb.jf02,gl_ywfjsb.jf03,gl_ywfjsb.jf04,gl_ywfjsb.jf05,gl_ywfjsb.jf06,gl_ywfjsb.jf07,gl_ywfjsb.jf08,gl_ywfjsb.jf09,gl_ywfjsb.jf10,gl_ywfjsb.jf11,gl_ywfjsb.jf12,gl_ywfjsb.jf13,gl_ywfjsb.jf14,gl_ywfjsb.df01,gl_ywfjsb.df02,gl_ywfjsb.df03,gl_ywfjsb.df04,gl_ywfjsb.df05,gl_ywfjsb.df06,gl_ywfjsb.df07,gl_ywfjsb.df08,gl_ywfjsb.df09,gl_ywfjsb.df10,gl_ywfjsb.df11,gl_ywfjsb.df12,gl_ywfjsb.df13,gl_ywfjsb.df14,gl_ywfjsb.ywf_bz,gl_ywfjsb.ywf_newkh,0 - gl_ywfjsb.ywf_zl AS ywf_zl,gl_ywfjsb.cdhpje,0 - gl_ywfjsb.ywf_cdhp AS ywf_cdhp,gl_ywfjsb.tiexije, 0 - gl_ywfjsb.ywf_tx AS ywf_tx,gl_ywfjsb.skje_yj,gl_ywfjsb.yongjinje,0 - gl_ywfjsb.ywf_yj AS ywf_yj,gl_ywfjsb.daizhang,0 - gl_ywfjsb.ywf_dz AS ywf_dz,gl_ywfjsb.susong,0 - gl_ywfjsb.ywf_ss AS ywf_ss,gl_ywfjsb.ywf_hlc,NVL(gl_ywfjsb.ywf_bz,0) + NVL(gl_ywfjsb.ywf_newkh,0) - NVL(gl_ywfjsb.ywf_zl,0) - NVL(gl_ywfjsb.ywf_cdhp,0) - NVL(gl_ywfjsb.ywf_tx,0) - NVL(gl_ywfjsb.ywf_yj,0) - NVL(gl_ywfjsb.ywf_dz,0) - NVL(gl_ywfjsb.ywf_ss,0) + NVL(gl_ywfjsb.ywf_hlc,0) AS ywf_hj FROM gl_ywfjsb WHERE cperiod >= ? AND cperiod <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtZydm.Text), " AND gl_ywfjsb.zydm ='" & Me.TxtZydm.Text & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND gl_ywfjsb.khdm ='" & Me.TxtKhdm.Text & "'", "") & " ORDER BY gl_ywfjsb.khdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthBegin.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("gl_ywfjsb") IsNot Nothing Then
                rcDataSet.Tables("gl_ywfjsb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "gl_ywfjsb")
            'rcOleDbCommand.CommandText = "SELECT '' AS khdm,'小计' AS khmc,gl_ywfjsba.zydm,gl_ywfjsba.zymc,SUM(byjf) AS byjf,SUM(bydf) AS bydf,SUM(qmye) AS qmye,SUM(jf01) AS jf01,SUM(jf02) AS jf02,SUM(jf03) AS jf03,SUM(jf04) AS jf04,SUM(jf05) AS jf05,SUM(jf06) AS jf06,SUM(jf07) AS jf07,SUM(jf08) AS jf08,SUM(jf09) AS jf09,SUM(jf10) AS jf10,SUM(jf11) AS jf11,SUM(jf12) AS jf12,SUM(jf13) AS jf13,SUM(jf14) AS jf14,SUM(df01) AS df01,SUM(df02) AS df02,SUM(df03) AS df03,SUM(df04) AS df04,SUM(df05) AS df05,SUM(df06) AS df06,SUM(df07) AS df07,SUM(df08) AS df08,SUM(df09) AS df09,SUM(df10) AS df10,SUM(df11) AS df11,SUM(df12) AS df12,SUM(df13) AS df13,SUM(df14) AS df14 FROM (SELECT gl_ywfjsb.khdm,rc_khxx.khmc,rc_khxx.zydm,rc_zyxx.zymc,gl_ywfjsb.skqx,gl_ywfjsb.byjf,gl_ywfjsb.bydf,gl_ywfjsb.qmye,gl_ywfjsb.jf01,gl_ywfjsb.jf02,gl_ywfjsb.jf03,gl_ywfjsb.jf04,gl_ywfjsb.jf05,gl_ywfjsb.jf06,gl_ywfjsb.jf07,gl_ywfjsb.jf08,gl_ywfjsb.jf09,gl_ywfjsb.jf10,gl_ywfjsb.jf11,gl_ywfjsb.jf12,gl_ywfjsb.jf13,gl_ywfjsb.jf14,gl_ywfjsb.df01,gl_ywfjsb.df02,gl_ywfjsb.df03,gl_ywfjsb.df04,gl_ywfjsb.df05,gl_ywfjsb.df06,gl_ywfjsb.df07,gl_ywfjsb.df08,gl_ywfjsb.df09,gl_ywfjsb.df10,gl_ywfjsb.df11,gl_ywfjsb.df12,gl_ywfjsb.df13,gl_ywfjsb.df14 FROM gl_ywfjsb LEFT JOIN rc_khxx ON rc_khxx.khdm = gl_ywfjsb.khdm LEFT JOIN rc_zyxx ON rc_zyxx.zydm = rc_khxx.zydm WHERE cperiod = ?) gl_ywfjsba GROUP BY gl_ywfjsba.zydm,gl_ywfjsba.zymc"
            'rcOleDbCommand.Parameters.Clear()
            'rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            'rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            'rcOleDbDataAdpt.Fill(rcDataSet, "gl_ywfjsb")
            rcOleDbCommand.CommandText = "SELECT '合计' AS khmc,SUM(byjf) AS byjf,SUM(bydf) AS bydf,SUM(qmye) AS qmye,SUM(jf01) AS jf01,SUM(jf02) AS jf02,SUM(jf03) AS jf03,SUM(jf04) AS jf04,SUM(jf05) AS jf05,SUM(jf06) AS jf06,SUM(jf07) AS jf07,SUM(jf08) AS jf08,SUM(jf09) AS jf09,SUM(jf10) AS jf10,SUM(jf11) AS jf11,SUM(jf12) AS jf12,SUM(jf13) AS jf13,SUM(jf14) AS jf14,SUM(df01) AS df01,SUM(df02) AS df02,SUM(df03) AS df03,SUM(df04) AS df04,SUM(df05) AS df05,SUM(df06) AS df06,SUM(df07) AS df07,SUM(df08) AS df08,SUM(df09) AS df09,SUM(df10) AS df10,SUM(df11) AS df11,SUM(df12) AS df12,SUM(df13) AS df13,SUM(df14) AS df14,SUM(ywf_bz) AS ywf_bz,SUM(ywf_newkh) AS ywf_newkh,SUM(0 - gl_ywfjsb.ywf_zl) AS ywf_zl,SUM(cdhpje) AS cdhpje,SUM(tiexije) AS tiexije,SUM(0 - gl_ywfjsb.ywf_tx) AS ywf_tx,SUM(skje_yj) AS skje_yj,SUM(yongjinje) AS yongjinje,SUM(daizhang) AS daizhang,SUM(0 - gl_ywfjsb.ywf_dz) AS ywf_dz,SUM(susong) AS susong,SUM(0 - gl_ywfjsb.ywf_ss) AS ywf_ss,SUM(ywf_hlc) AS ywf_hlc,SUM(NVL(gl_ywfjsb.ywf_bz,0) + NVL(gl_ywfjsb.ywf_newkh,0) - NVL(gl_ywfjsb.ywf_zl,0) - NVL(gl_ywfjsb.ywf_cdhp,0) - NVL(gl_ywfjsb.ywf_tx,0) - NVL(gl_ywfjsb.ywf_yj,0) - NVL(gl_ywfjsb.ywf_dz,0) - NVL(gl_ywfjsb.ywf_ss,0) + NVL(gl_ywfjsb.ywf_hlc,0)) AS ywf_hj FROM gl_ywfjsb WHERE cperiod >= ? AND cperiod <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtZydm.Text), " AND gl_ywfjsb.zydm ='" & Me.TxtZydm.Text & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND gl_ywfjsb.khdm ='" & Me.TxtKhdm.Text & "'", "")
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthBegin.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            rcOleDbDataAdpt.Fill(rcDataset, "gl_ywfjsb")
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
        Dim rcFrm As New FrmYwfCxz
        With rcFrm
            .ParaDataSet = rcDataset
            .paraDataView = New DataView(rcDataset.Tables("gl_ywfjsb"), "TRUE", "cperiod,zydm,khdm", DataViewRowState.CurrentRows)
            '.Label2.Text = "盘点日期：" & Me.DtpPcrq.Value
            '.Label3.Text = "仓库：" & Trim(Me.TxtCkdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With

    End Sub
End Class