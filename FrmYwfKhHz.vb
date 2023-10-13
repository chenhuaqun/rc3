Imports System.Data.OleDb

Public Class FrmYwfKhHz
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '��ʾҪ������Դִ�е� SQL ����
    Dim rcOleDbTrans As OleDbTransaction
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

#Region "��ʼ��"

    Private Sub FrmDjjz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Ĭ��ֵ
        Me.NudYear.Value = Mid(g_Kjqj, 1, 4)
        Me.NudMonthBegin.Value = 1
        Me.NudMonthEnd.Value = Mid(g_Kjqj, 5, 2)
    End Sub

#End Region

#Region "�ؼ��س����Ĵ���"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NudYear.KeyPress, NudMonthBegin.KeyPress, NudMonthEnd.KeyPress, TxtZydm.KeyPress, TxtKhdm.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
        End Select
    End Sub

#End Region


#Region "ְԱ������¼�"

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
                    .paraTitle = "ְԱ"
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
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
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

#Region "�ͻ������¼�"

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
                    .paraTitle = "�ͻ�"
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
        Dim i As Integer
        Dim dateKsrq As Date '�ɱ���ת��ʼ����
        Dim dateJsrq As Date '�ɱ���ת��������
        dateKsrq = getInvBegin(Me.NudYear.Value, Me.NudMonthBegin.Value)
        dateJsrq = getInvEnd(Me.NudYear.Value, Me.NudMonthBegin.Value)
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT aa.khdm,aa.khmc,aa.zydm,aa.zymc,aa.xslbdm,TO_CHAR(aa.ywfbl,'0.000') || '%' AS ywfbl,TO_CHAR(aa.newkhbl,'99.9') || '%' AS newkhbl,aa.skqx,NVL(aa.byjf,0.0) AS byjf,NVL(aa.bydf,0.0) AS bydf,NVL(bb.qmye,0.0) AS qmye,NVL(aa.ywf_bz,0.0) AS ywf_bz,aa.ywf_newkh AS ywf_newkh,aa.ywf_zl,aa.cdhpje,aa.ywf_cdhp,aa.tiexije,aa.ywf_tx,aa.skje_yj,aa.yongjinje,aa.ywf_yj,aa.daizhang,aa.ywf_dz,aa.susong,aa.ywf_ss,aa.ywf_hlc,aa.ywf_hj FROM (SELECT gl_ywfjsb.khdm,gl_ywfjsb.khmc,gl_ywfjsb.zydm,gl_ywfjsb.zymc,gl_ywfjsb.xslbdm,AVG(gl_ywfjsb.ywfbl) AS ywfbl,AVG(gl_ywfjsb.newkhbl) AS newkhbl,AVG(gl_ywfjsb.skqx) AS skqx,SUM(gl_ywfjsb.byjf) AS byjf,SUM(gl_ywfjsb.bydf) AS bydf,SUM(gl_ywfjsb.ywf_bz) AS ywf_bz,SUM(gl_ywfjsb.ywf_newkh) AS ywf_newkh,SUM(0 - gl_ywfjsb.ywf_zl) AS ywf_zl,SUM(gl_ywfjsb.cdhpje) AS cdhpje,SUM(0 - gl_ywfjsb.ywf_cdhp) AS ywf_cdhp,SUM(gl_ywfjsb.tiexije) AS tiexije, SUM(0 - gl_ywfjsb.ywf_tx) AS ywf_tx,SUM(gl_ywfjsb.skje_yj) AS skje_yj,SUM(gl_ywfjsb.yongjinje) AS yongjinje,SUM(0 - gl_ywfjsb.ywf_yj) AS ywf_yj,SUM(gl_ywfjsb.daizhang) AS daizhang,SUM(0 - gl_ywfjsb.ywf_dz) AS ywf_dz,SUM(gl_ywfjsb.susong) AS susong,SUM(0 - gl_ywfjsb.ywf_ss) AS ywf_ss,SUM(gl_ywfjsb.ywf_hlc) AS ywf_hlc,SUM(NVL(gl_ywfjsb.ywf_bz,0) + NVL(gl_ywfjsb.ywf_newkh,0) - NVL(gl_ywfjsb.ywf_zl,0) - NVL(gl_ywfjsb.ywf_cdhp,0) - NVL(gl_ywfjsb.ywf_tx,0) - NVL(gl_ywfjsb.ywf_yj,0) - NVL(gl_ywfjsb.ywf_dz,0) - NVL(gl_ywfjsb.ywf_ss,0) + NVL(gl_ywfjsb.ywf_hlc,0)) AS ywf_hj FROM gl_ywfjsb WHERE cperiod >= ? AND cperiod <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtZydm.Text), " AND gl_ywfjsb.zydm ='" & Me.TxtZydm.Text & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND gl_ywfjsb.khdm ='" & Me.TxtKhdm.Text & "'", "") & " GROUP BY gl_ywfjsb.khdm,gl_ywfjsb.khmc,gl_ywfjsb.zydm,gl_ywfjsb.zymc,gl_ywfjsb.xslbdm) aa LEFT JOIN (SELECT gl_ywfjsb.khdm,NVL(gl_ywfjsb.zydm,'~') AS zydm,SUM(gl_ywfjsb.qmye) AS qmye FROM gl_ywfjsb WHERE EXISTS (SELECT 1 FROM (SELECT MAX(cperiod) AS cperiod,khdm,zydm FROM gl_ywfjsb gl_ywfjsba WHERE gl_ywfjsba.cperiod >= ? AND gl_ywfjsba.cperiod <= ? GROUP BY gl_ywfjsba.khdm,gl_ywfjsba.zydm) gl_ywfjsbb WHERE gl_ywfjsbb.cperiod = gl_ywfjsb.cperiod AND gl_ywfjsbb.khdm = gl_ywfjsb.khdm AND NVL(gl_ywfjsbb.zydm,'~') = NVL(gl_ywfjsb.zydm,'~'))" & IIf(Not String.IsNullOrEmpty(Me.TxtZydm.Text), " AND gl_ywfjsb.zydm ='" & Me.TxtZydm.Text & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND gl_ywfjsb.khdm ='" & Me.TxtKhdm.Text & "'", "") & " GROUP BY gl_ywfjsb.khdm,gl_ywfjsb.zydm) bb ON aa.khdm = bb.khdm AND NVL(aa.zydm,'~') = NVL(bb.zydm,'~')"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthBegin.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthBegin.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("gl_ywfjsb") IsNot Nothing Then
                rcDataSet.Tables("gl_ywfjsb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "gl_ywfjsb")
            'rcOleDbCommand.CommandText = "SELECT '' AS khdm,'С��' AS khmc,gl_ywfjsba.zydm,gl_ywfjsba.zymc,SUM(byjf) AS byjf,SUM(bydf) AS bydf,SUM(qmye) AS qmye,SUM(jf01) AS jf01,SUM(jf02) AS jf02,SUM(jf03) AS jf03,SUM(jf04) AS jf04,SUM(jf05) AS jf05,SUM(jf06) AS jf06,SUM(jf07) AS jf07,SUM(jf08) AS jf08,SUM(jf09) AS jf09,SUM(jf10) AS jf10,SUM(jf11) AS jf11,SUM(jf12) AS jf12,SUM(jf13) AS jf13,SUM(jf14) AS jf14,SUM(df01) AS df01,SUM(df02) AS df02,SUM(df03) AS df03,SUM(df04) AS df04,SUM(df05) AS df05,SUM(df06) AS df06,SUM(df07) AS df07,SUM(df08) AS df08,SUM(df09) AS df09,SUM(df10) AS df10,SUM(df11) AS df11,SUM(df12) AS df12,SUM(df13) AS df13,SUM(df14) AS df14 FROM (SELECT gl_ywfjsb.khdm,rc_khxx.khmc,rc_khxx.zydm,rc_zyxx.zymc,gl_ywfjsb.skqx,gl_ywfjsb.byjf,gl_ywfjsb.bydf,gl_ywfjsb.qmye,gl_ywfjsb.jf01,gl_ywfjsb.jf02,gl_ywfjsb.jf03,gl_ywfjsb.jf04,gl_ywfjsb.jf05,gl_ywfjsb.jf06,gl_ywfjsb.jf07,gl_ywfjsb.jf08,gl_ywfjsb.jf09,gl_ywfjsb.jf10,gl_ywfjsb.jf11,gl_ywfjsb.jf12,gl_ywfjsb.jf13,gl_ywfjsb.jf14,gl_ywfjsb.df01,gl_ywfjsb.df02,gl_ywfjsb.df03,gl_ywfjsb.df04,gl_ywfjsb.df05,gl_ywfjsb.df06,gl_ywfjsb.df07,gl_ywfjsb.df08,gl_ywfjsb.df09,gl_ywfjsb.df10,gl_ywfjsb.df11,gl_ywfjsb.df12,gl_ywfjsb.df13,gl_ywfjsb.df14 FROM gl_ywfjsb LEFT JOIN rc_khxx ON rc_khxx.khdm = gl_ywfjsb.khdm LEFT JOIN rc_zyxx ON rc_zyxx.zydm = rc_khxx.zydm WHERE cperiod = ?) gl_ywfjsba GROUP BY gl_ywfjsba.zydm,gl_ywfjsba.zymc"
            'rcOleDbCommand.Parameters.Clear()
            'rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            'rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            'rcOleDbDataAdpt.Fill(rcDataSet, "gl_ywfjsb")
            rcOleDbCommand.CommandText = "SELECT '�ϼ�' AS khmc,SUM(aa.byjf) AS byjf,SUM(aa.bydf) AS bydf,SUM(bb.qmye) AS qmye,SUM(aa.ywf_bz) AS ywf_bz,SUM(aa.ywf_newkh) AS ywf_newkh,SUM(aa.ywf_zl) AS ywf_zl,SUM(aa.cdhpje) AS cdhpje,SUM(aa.ywf_cdhp) AS ywf_cdhp,SUM(aa.tiexije) AS tiexije,SUM(aa.ywf_tx) AS ywf_tx,SUM(aa.skje_yj) AS skje_yj,SUM(aa.yongjinje) AS yongjinje,SUM(aa.ywf_yj) AS ywf_yj,SUM(aa.daizhang) AS daizhang,SUM(aa.ywf_dz) AS ywf_dz,SUM(aa.susong) AS susong,SUM(aa.ywf_ss) AS ywf_ss,SUM(aa.ywf_hlc) AS ywf_hlc,SUM(aa.ywf_hj) AS ywf_hj FROM (SELECT gl_ywfjsb.khdm,gl_ywfjsb.khmc,gl_ywfjsb.zydm,gl_ywfjsb.zymc,gl_ywfjsb.xslbdm,AVG(gl_ywfjsb.ywfbl) AS ywfbl,AVG(gl_ywfjsb.newkhbl) AS newkhbl,AVG(gl_ywfjsb.skqx) AS skqx,SUM(gl_ywfjsb.byjf) AS byjf,SUM(gl_ywfjsb.bydf) AS bydf,SUM(gl_ywfjsb.ywf_bz) AS ywf_bz,SUM(gl_ywfjsb.ywf_newkh) AS ywf_newkh,SUM(0 - gl_ywfjsb.ywf_zl) AS ywf_zl,SUM(gl_ywfjsb.cdhpje) AS cdhpje,SUM(0 - gl_ywfjsb.ywf_cdhp) AS ywf_cdhp,SUM(gl_ywfjsb.tiexije) AS tiexije, SUM(0 - gl_ywfjsb.ywf_tx) AS ywf_tx,SUM(gl_ywfjsb.skje_yj) AS skje_yj,SUM(gl_ywfjsb.yongjinje) AS yongjinje,SUM(0 - gl_ywfjsb.ywf_yj) AS ywf_yj,SUM(gl_ywfjsb.daizhang) AS daizhang,SUM(0 - gl_ywfjsb.ywf_dz) AS ywf_dz,SUM(gl_ywfjsb.susong) AS susong,SUM(0 - gl_ywfjsb.ywf_ss) AS ywf_ss,SUM(gl_ywfjsb.ywf_hlc) AS ywf_hlc,SUM(NVL(gl_ywfjsb.ywf_bz,0) + NVL(gl_ywfjsb.ywf_newkh,0) - NVL(gl_ywfjsb.ywf_zl,0) - NVL(gl_ywfjsb.ywf_cdhp,0) - NVL(gl_ywfjsb.ywf_tx,0) - NVL(gl_ywfjsb.ywf_yj,0) - NVL(gl_ywfjsb.ywf_dz,0) - NVL(gl_ywfjsb.ywf_ss,0) + NVL(gl_ywfjsb.ywf_hlc,0)) AS ywf_hj FROM gl_ywfjsb WHERE cperiod >= ? AND cperiod <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtZydm.Text), " AND gl_ywfjsb.zydm ='" & Me.TxtZydm.Text & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND gl_ywfjsb.khdm ='" & Me.TxtKhdm.Text & "'", "") & " GROUP BY gl_ywfjsb.khdm,gl_ywfjsb.khmc,gl_ywfjsb.zydm,gl_ywfjsb.zymc,gl_ywfjsb.xslbdm) aa LEFT JOIN (SELECT gl_ywfjsb.khdm,gl_ywfjsb.zydm,SUM(gl_ywfjsb.qmye) AS qmye FROM gl_ywfjsb WHERE EXISTS (SELECT 1 FROM (SELECT MAX(cperiod) AS cperiod,khdm,zydm FROM gl_ywfjsb gl_ywfjsba WHERE gl_ywfjsba.cperiod >= ? AND gl_ywfjsba.cperiod <= ? GROUP BY gl_ywfjsba.khdm,gl_ywfjsba.zydm) gl_ywfjsbb WHERE gl_ywfjsbb.cperiod = gl_ywfjsb.cperiod AND gl_ywfjsbb.khdm = gl_ywfjsb.khdm AND NVL(gl_ywfjsbb.zydm,'~') = NVL(gl_ywfjsb.zydm,'~'))" & IIf(Not String.IsNullOrEmpty(Me.TxtZydm.Text), " AND gl_ywfjsb.zydm ='" & Me.TxtZydm.Text & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND gl_ywfjsb.khdm ='" & Me.TxtKhdm.Text & "'", "") & " GROUP BY gl_ywfjsb.khdm,gl_ywfjsb.zydm) bb ON aa.khdm = bb.khdm AND NVL(aa.zydm,'~') = NVL(bb.zydm,'~')"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthBegin.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthBegin.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            rcOleDbDataAdpt.Fill(rcDataset, "gl_ywfjsb")
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Catch ey As OleDbException
                MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If Me.CheckBox1.Checked Then
            For i = 0 To rcDataSet.Tables("gl_ywfjsb").Rows.Count - 1
                If rcDataSet.Tables("gl_ywfjsb").Rows(i).Item("byjf") = 0 And rcDataSet.Tables("gl_ywfjsb").Rows(i).Item("bydf") = 0 And rcDataSet.Tables("gl_ywfjsb").Rows(i).Item("qmye") = 0 And rcDataSet.Tables("gl_ywfjsb").Rows(i).Item("ywf_hj") = 0 Then
                    rcDataSet.Tables("gl_ywfjsb").Rows(i).Delete()
                End If
            Next
        End If
        '���ñ�
        Dim rcFrm As New FrmYwfKhHzz
        With rcFrm
            .ParaDataSet = rcDataset
            .paraDataView = New DataView(rcDataset.Tables("gl_ywfjsb"), "TRUE", "zydm,khdm", DataViewRowState.CurrentRows)
            '.Label2.Text = "�̵����ڣ�" & Me.DtpPcrq.Value
            '.Label3.Text = "�ֿ⣺" & Trim(Me.TxtCkdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With

    End Sub
End Class