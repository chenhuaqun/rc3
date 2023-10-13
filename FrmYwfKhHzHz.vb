Imports System.Data.OleDb

Public Class FrmYwfKhHzHz
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
        Dim i As Integer
        '默认值
        Me.NudYear.Value = Mid(g_Kjqj, 1, 4)
        Me.NudMonthBegin.Value = Mid(g_Kjqj, 5, 2)
        Me.NudMonthEnd.Value = Mid(g_Kjqj, 5, 2)
        '预选单位编码数据
        Try
            sysOleDbConn.Open()
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT dwdm,dwmc,userid FROM rc_dwdm WHERE dwdm IN (SELECT code AS dwdm from rc_userqx WHERE righttype = 'DWDM' and User_Account = ?) order by dwdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = g_User_Account
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_dwdm") IsNot Nothing Then
                rcDataset.Tables("rc_dwdm").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_dwdm")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            sysOleDbConn.Close()
        End Try
        For i = 0 To rcDataset.Tables("rc_dwdm").Rows.Count - 1
            ListBoxYuxuanDwdm.Items.Add(rcDataset.Tables("rc_dwdm").Rows(i).Item("dwdm") & " " & rcDataset.Tables("rc_dwdm").Rows(i).Item("dwmc"))
        Next
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
                If rcDataset.Tables("rc_zyxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_zyxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_zyxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_zyxx").Rows.Count > 0 Then
                Me.TxtZydm.Text = Trim(rcDataset.Tables("rc_zyxx").Rows(0).Item("zydm"))
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

    Private Sub ListBoxYuxuanDwdm_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBoxYuxuanDwdm.DoubleClick
        If Me.ListBoxYuxuanDwdm.SelectedItem IsNot Nothing Then
            Me.ListBoxYixuanDwdm.Items.Add(Me.ListBoxYuxuanDwdm.SelectedItem)
            Me.ListBoxYuxuanDwdm.Items.Remove(Me.ListBoxYuxuanDwdm.SelectedItem)
        End If
    End Sub

    Private Sub ListBoxYixuanDwdm_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBoxYixuanDwdm.DoubleClick
        If Me.ListBoxYixuanDwdm.SelectedItem IsNot Nothing Then
            Me.ListBoxYuxuanDwdm.Items.Add(Me.ListBoxYixuanDwdm.SelectedItem)
            Me.ListBoxYixuanDwdm.Items.Remove(Me.ListBoxYixuanDwdm.SelectedItem)
        End If
    End Sub

    Private Sub BtnSelectAllDwdm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectAllDwdm.Click
        Dim i As Integer
        For i = 0 To Me.ListBoxYuxuanDwdm.Items.Count - 1
            Me.ListBoxYixuanDwdm.Items.Add(Me.ListBoxYuxuanDwdm.Items(0))
            Me.ListBoxYuxuanDwdm.Items.Remove(Me.ListBoxYuxuanDwdm.Items(0))
        Next
    End Sub

    Private Sub BtnSelectOneDwdm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectOneDwdm.Click
        If Me.ListBoxYuxuanDwdm.SelectedItems.Count > 0 Then
            Me.ListBoxYixuanDwdm.Items.Add(Me.ListBoxYuxuanDwdm.SelectedItem)
            Me.ListBoxYuxuanDwdm.Items.Remove(Me.ListBoxYuxuanDwdm.SelectedItem)
        End If
    End Sub

    Private Sub BtnUnSelectOneDwdm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUnSelectOneDwdm.Click
        If Me.ListBoxYixuanDwdm.SelectedItems.Count > 0 Then
            Me.ListBoxYuxuanDwdm.Items.Add(Me.ListBoxYixuanDwdm.SelectedItem)
            Me.ListBoxYixuanDwdm.Items.Remove(Me.ListBoxYixuanDwdm.SelectedItem)
        End If
    End Sub

    Private Sub BtnUnSelectAllDwdm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUnSelectAllDwdm.Click
        Dim i As Integer
        For i = 0 To Me.ListBoxYixuanDwdm.Items.Count - 1
            Me.ListBoxYuxuanDwdm.Items.Add(Me.ListBoxYixuanDwdm.Items(0))
            Me.ListBoxYixuanDwdm.Items.Remove(Me.ListBoxYixuanDwdm.Items(0))
        Next
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim i As Integer
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
            If rcDataSet.Tables("gl_ywfjsb") IsNot Nothing Then
                rcDataSet.Tables("gl_ywfjsb").Clear()
            End If
            For i = 0 To Me.ListBoxYixuanDwdm.Items.Count - 1
                rcOleDbCommand.CommandText = "SELECT '" & Mid(Me.ListBoxYixuanDwdm.Items(i), 1, InStr(Me.ListBoxYixuanDwdm.Items(i), " ") - 1) & "' AS dwdm,'" & Mid(Me.ListBoxYixuanDwdm.Items(i), InStr(Me.ListBoxYixuanDwdm.Items(i), " ")) & "' AS dwmc,aa.khdm,aa.khmc,aa.zydm,aa.zymc,aa.xslbdm,aa.ywfbl,aa.newkhbl,aa.skqx,aa.byjf,aa.bydf,bb.qmye,aa.ywf_bz,aa.newkh,aa.ywf_zl,aa.cdhpje,aa.ywf_cdhp,aa.tiexije,aa.ywf_tx,aa.skje_yj,aa.yongjinje,aa.ywf_yj,aa.daizhang,aa.ywf_dz,aa.susong,aa.ywf_ss,aa.ywf_hlc,aa.ywf_hj FROM (SELECT gl_ywfjsb.khdm,gl_ywfjsb.khmc,gl_ywfjsb.zydm,gl_ywfjsb.zymc,gl_ywfjsb.xslbdm,AVG(gl_ywfjsb.ywfbl) AS ywfbl,AVG(gl_ywfjsb.newkhbl) AS newkhbl,AVG(gl_ywfjsb.skqx) AS skqx,SUM(gl_ywfjsb.byjf) AS byjf,SUM(gl_ywfjsb.bydf) AS bydf,SUM(gl_ywfjsb.ywf_bz) AS ywf_bz,SUM(gl_ywfjsb.ywf_newkh) AS newkh,SUM(0 - gl_ywfjsb.ywf_zl) AS ywf_zl,SUM(gl_ywfjsb.cdhpje) AS cdhpje,SUM(0 - gl_ywfjsb.ywf_cdhp) AS ywf_cdhp,SUM(gl_ywfjsb.tiexije) AS tiexije, SUM(0 - gl_ywfjsb.ywf_tx) AS ywf_tx,SUM(gl_ywfjsb.skje_yj) AS skje_yj,SUM(gl_ywfjsb.yongjinje) AS yongjinje,SUM(0 - gl_ywfjsb.ywf_yj) AS ywf_yj,SUM(gl_ywfjsb.daizhang) AS daizhang,SUM(0 - gl_ywfjsb.ywf_dz) AS ywf_dz,SUM(gl_ywfjsb.susong) AS susong,SUM(0 - gl_ywfjsb.ywf_ss) AS ywf_ss,SUM(gl_ywfjsb.ywf_hlc) AS ywf_hlc,SUM(NVL(gl_ywfjsb.ywf_bz,0) + NVL(gl_ywfjsb.ywf_newkh,0) - NVL(gl_ywfjsb.ywf_zl,0) - NVL(gl_ywfjsb.ywf_cdhp,0) - NVL(gl_ywfjsb.ywf_tx,0) - NVL(gl_ywfjsb.ywf_yj,0) - NVL(gl_ywfjsb.ywf_dz,0) - NVL(gl_ywfjsb.ywf_ss,0) + NVL(gl_ywfjsb.ywf_hlc,0)) AS ywf_hj FROM rcdata_" & Mid(Me.ListBoxYixuanDwdm.Items(i), 1, InStr(Me.ListBoxYixuanDwdm.Items(i), " ") - 1) & ".gl_ywfjsb WHERE cperiod >= ? AND cperiod <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtZydm.Text), " AND gl_ywfjsb.zydm ='" & Me.TxtZydm.Text & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND gl_ywfjsb.khdm ='" & Me.TxtKhdm.Text & "'", "") & " GROUP BY gl_ywfjsb.khdm,gl_ywfjsb.khmc,gl_ywfjsb.zydm,gl_ywfjsb.zymc,gl_ywfjsb.xslbdm) aa LEFT JOIN (SELECT gl_ywfjsb.khdm,SUM(gl_ywfjsb.qmye) AS qmye FROM rcdata_" & Mid(Me.ListBoxYixuanDwdm.Items(i), 1, InStr(Me.ListBoxYixuanDwdm.Items(i), " ") - 1) & ".gl_ywfjsb WHERE gl_ywfjsb.cperiod = ?" & IIf(Not String.IsNullOrEmpty(Me.TxtZydm.Text), " AND gl_ywfjsb.zydm ='" & Me.TxtZydm.Text & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND gl_ywfjsb.khdm ='" & Me.TxtKhdm.Text & "'", "") & " GROUP BY gl_ywfjsb.khdm) bb ON aa.khdm = bb.khdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthBegin.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                rcOleDbDataAdpt.Fill(rcDataSet, "gl_ywfjsb")
            Next
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
            For i = 0 To rcDataSet.Tables("gl_ywfjsb").Rows.Count - 1
                If rcDataSet.Tables("gl_ywfjsb").Rows(i).Item("byjf") = 0 And rcDataSet.Tables("gl_ywfjsb").Rows(i).Item("bydf") = 0 And rcDataSet.Tables("gl_ywfjsb").Rows(i).Item("qmye") = 0 And rcDataSet.Tables("gl_ywfjsb").Rows(i).Item("ywf_hj") = 0 Then
                    rcDataSet.Tables("gl_ywfjsb").Rows(i).Delete()
                End If
            Next
        End If
        '调用表单
        Dim rcFrm As New FrmYwfKhHzHzz
        With rcFrm
            .ParaDataSet = rcDataset
            .paraDataView = New DataView(rcDataset.Tables("gl_ywfjsb"), "TRUE", "zydm,khdm", DataViewRowState.CurrentRows)
            '.Label2.Text = "盘点日期：" & Me.DtpPcrq.Value
            '.Label3.Text = "仓库：" & Trim(Me.TxtCkdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With

    End Sub
End Class