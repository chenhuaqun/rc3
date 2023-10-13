Imports System.Data.OleDb

Public Class FrmYwfJs
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
        Me.NudMonth.Value = Mid(g_Kjqj, 5, 2)
        '取业务费新客户上升比例
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT paraid,parastrvalue,paradblvalue FROM rc_para WHERE paraId = '业务费新客户上升比例'"
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
                Me.TxtNewKh.Text = rcDataset.Tables("rc_para").Rows(0).Item("paradblvalue")
            Else
                Me.TxtNewKh.Text = 0
            End If
        Else
            Me.TxtNewKh.Text = 0
        End If
        '取业务费老客户下降比例
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT paraid,parastrvalue,paradblvalue FROM rc_para WHERE paraId = '业务费老客户下降比例'"
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
                Me.TxtOldKh.Text = rcDataset.Tables("rc_para").Rows(0).Item("paradblvalue")
            Else
                Me.TxtOldKh.Text = 0
            End If
        Else
            Me.TxtOldKh.Text = 0
        End If
        '取承兑汇票回笼下降比例
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT paraid,parastrvalue,paradblvalue FROM rc_para WHERE paraId = '承兑汇票回笼下降比例'"
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
                Me.TxtCdhp.Text = rcDataset.Tables("rc_para").Rows(0).Item("paradblvalue")
            Else
                Me.TxtCdhp.Text = 0
            End If
        Else
            Me.TxtCdhp.Text = 0
        End If

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


#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NudYear.KeyPress, NudMonth.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim i As Integer
        Dim j As Integer
        '查询科目权限
        If Me.ListBoxYixuanDwdm.Items.Count = 0 Then
            Return
        End If
        Dim strKmdm As String = ""
        For i = 0 To Me.ListBoxYixuanKmdm.Items.Count - 1
            strKmdm += IIf(i = 0, "", " OR") & " kmdm = '" & Mid(Me.ListBoxYixuanKmdm.Items(i), 1, InStr(Me.ListBoxYixuanKmdm.Items(i), " ") - 1) & "'"
        Next
        If String.IsNullOrEmpty(strKmdm) Then
            strKmdm = "0=0"
        End If
        '写系统参数
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            If Not String.IsNullOrEmpty(Me.TxtNewKh.Text) Then
                '删除数据
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = '业务费新客户上升比例'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '插入数据
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'业务费新客户上升比例','',?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarNumeric, 14).Value = Trim(Me.TxtNewKh.Text)
                rcOleDbCommand.ExecuteNonQuery()
            End If
            If Not String.IsNullOrEmpty(Me.TxtOldKh.Text) Then
                '删除数据
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = '业务费老客户下降比例'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '插入数据
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'业务费老客户下降比例','',?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarNumeric, 14).Value = Trim(Me.TxtOldKh.Text)
                rcOleDbCommand.ExecuteNonQuery()
            End If
            If Not String.IsNullOrEmpty(Me.TxtCdhp.Text) Then
                '删除数据
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = '承兑汇票回笼下降比例'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '插入数据
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'承兑汇票回笼下降比例','',?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarNumeric, 14).Value = Trim(Me.TxtCdhp.Text)
                rcOleDbCommand.ExecuteNonQuery()
            End If
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

        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '删除历史数据
            rcOleDbCommand.CommandText = "DELETE FROM gl_ywfjsb WHERE cperiod = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET t_zydm = '',t_zymc = '' WHERE cperiod = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = (Me.NudYear.Value - 1).ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET t_xslbdm = '' WHERE cperiod = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = (Me.NudYear.Value - 1).ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()

            For j = 0 To Me.ListBoxYixuanDwdm.Items.Count - 1
                '插入客户与年初余额
                rcOleDbCommand.CommandText = "INSERT INTO gl_ywfjsb (cperiod,khdm,qmye) SELECT ?,khdm,0 AS qmye FROM rcdata_" & Mid(Me.ListBoxYixuanDwdm.Items(j), 1, InStr(Me.ListBoxYixuanDwdm.Items(j), " ") - 1) & ".gl_kmyeb WHERE kjnd = ? AND khdm <> '~' AND EXISTS (SELECT 1 FROM rcdata_" & Mid(Me.ListBoxYixuanDwdm.Items(j), 1, InStr(Me.ListBoxYixuanDwdm.Items(j), " ") - 1) & ".rc_khxx WHERE rc_khxx.khdm = gl_kmyeb.khdm AND rc_khxx.bjsywf = 1) AND (" & strKmdm & ") AND NOT EXISTS (SELECT 1 FROM gl_ywfjsb WHERE gl_ywfjsb.cperiod = ? AND gl_ywfjsb.khdm = gl_kmyeb.khdm) GROUP BY khdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                '更新期末余额
                rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET qmye = NVL(qmye,0) +  (SELECT COALESCE(SUM(CASE WHEN gl_kmyeb.jd = '借' THEN ncje ELSE 0 - ncje END),0.0) AS qmye FROM rcdata_" & Mid(Me.ListBoxYixuanDwdm.Items(j), 1, InStr(Me.ListBoxYixuanDwdm.Items(j), " ") - 1) & ".gl_kmyeb WHERE kjnd = ? AND khdm <> '~' AND (" & strKmdm & ") AND gl_kmyeb.khdm = gl_ywfjsb.khdm GROUP BY khdm) WHERE cperiod = ? AND EXISTS (SELECT 1 FROM rcdata_" & Mid(Me.ListBoxYixuanDwdm.Items(j), 1, InStr(Me.ListBoxYixuanDwdm.Items(j), " ") - 1) & ".gl_kmyeb WHERE kjnd = ? AND khdm <> '~' AND (" & strKmdm & ") AND gl_kmyeb.khdm = gl_ywfjsb.khdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                rcOleDbCommand.ExecuteNonQuery()
                '计算期末余额
                rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET qmye = NVL(qmye,0) + (SELECT COALESCE(SUM(CASE WHEN gl_pz.jd = '借' THEN je ELSE 0 - je END),0.0) FROM rcdata_" & Mid(Me.ListBoxYixuanDwdm.Items(j), 1, InStr(Me.ListBoxYixuanDwdm.Items(j), " ") - 1) & ".gl_pz WHERE gl_pz.khdm = gl_ywfjsb.khdm AND (" & strKmdm & ") AND gl_pz.cperiod <= ? AND gl_pz.cperiod >= ?) WHERE cperiod = ? AND EXISTS (SELECT 1 FROM rcdata_" & Mid(Me.ListBoxYixuanDwdm.Items(j), 1, InStr(Me.ListBoxYixuanDwdm.Items(j), " ") - 1) & ".gl_pz WHERE gl_pz.khdm = gl_ywfjsb.khdm AND (" & strKmdm & ") AND gl_pz.cperiod <= ? AND gl_pz.cperiod >= ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & "01"
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & "01"
                rcOleDbCommand.ExecuteNonQuery()
                '更新客户名称、业务员编码
                rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET khmc = (SELECT khmc FROM rcdata_" & Mid(Me.ListBoxYixuanDwdm.Items(j), 1, InStr(Me.ListBoxYixuanDwdm.Items(j), " ") - 1) & ".rc_khxx WHERE rc_khxx.khdm = gl_ywfjsb.khdm) WHERE cperiod = ? AND gl_ywfjsb.khmc IS NULL"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                '更新业务员编码、销售销售分类--根据专管业务员
                rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET (zydm,xslbdm) = (SELECT zydm,xslbdm FROM rcdata_" & Mid(Me.ListBoxYixuanDwdm.Items(j), 1, InStr(Me.ListBoxYixuanDwdm.Items(j), " ") - 1) & ".rc_khzyxx WHERE (SUBSTR(rc_khzyxx.ksperiod,1,4) = ? OR SUBSTR(rc_khzyxx.jsperiod,1,4) = ?) AND (rc_khzyxx.ksperiod <= ? OR rc_khzyxx.ksperiod IS NULL) AND (rc_khzyxx.jsperiod IS NULL OR rc_khzyxx.jsperiod >= ? ) AND rc_khzyxx.khdm = gl_ywfjsb.khdm) WHERE EXISTS (SELECT 1 FROM rc_khzyxx WHERE rc_khzyxx.khdm = gl_ywfjsb.khdm) AND gl_ywfjsb.zydm IS NULL AND gl_ywfjsb.cperiod = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                '更新上年业务员编码--根据专管业务员
                rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET t_zydm = (SELECT zydm FROM rcdata_" & Mid(Me.ListBoxYixuanDwdm.Items(j), 1, InStr(Me.ListBoxYixuanDwdm.Items(j), " ") - 1) & ".rc_khzyxx WHERE (SUBSTR(rc_khzyxx.ksperiod,1,4) = ? OR SUBSTR(rc_khzyxx.jsperiod,1,4) = ?) AND (rc_khzyxx.ksperiod <= ? OR rc_khzyxx.ksperiod IS NULL) AND (rc_khzyxx.jsperiod IS NULL OR rc_khzyxx.jsperiod >= ? ) AND rc_khzyxx.khdm = gl_ywfjsb.khdm) WHERE EXISTS (SELECT 1 FROM rc_khzyxx WHERE rc_khzyxx.khdm = gl_ywfjsb.khdm) AND gl_ywfjsb.cperiod = ? AND t_zydm IS NULL"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = (Me.NudYear.Value - 1).ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                '更新上年销售分类编码--根据专管业务员
                rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET t_xslbdm = (SELECT xslbdm FROM rcdata_" & Mid(Me.ListBoxYixuanDwdm.Items(j), 1, InStr(Me.ListBoxYixuanDwdm.Items(j), " ") - 1) & ".rc_khzyxx WHERE (SUBSTR(rc_khzyxx.ksperiod,1,4) = ? OR SUBSTR(rc_khzyxx.jsperiod,1,4) = ?) AND (rc_khzyxx.ksperiod <= ? OR rc_khzyxx.ksperiod IS NULL) AND (rc_khzyxx.jsperiod IS NULL OR rc_khzyxx.jsperiod >= ? ) AND rc_khzyxx.khdm = gl_ywfjsb.khdm) WHERE EXISTS (SELECT 1 FROM rc_khzyxx WHERE rc_khzyxx.khdm = gl_ywfjsb.khdm) AND gl_ywfjsb.cperiod = ? AND t_xslbdm IS NULL"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = (Me.NudYear.Value - 1).ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                '更新业务员编码--根据客户信息
                rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET zydm = (SELECT zydm FROM rcdata_" & Mid(Me.ListBoxYixuanDwdm.Items(j), 1, InStr(Me.ListBoxYixuanDwdm.Items(j), " ") - 1) & ".rc_khxx WHERE rc_khxx.khdm = gl_ywfjsb.khdm) WHERE gl_ywfjsb.cperiod = ? AND gl_ywfjsb.zydm IS NULL"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                '更新上年业务员编码--根据客户信息
                rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET t_zydm = (SELECT zydm FROM rcdata_" & Mid(Me.ListBoxYixuanDwdm.Items(j), 1, InStr(Me.ListBoxYixuanDwdm.Items(j), " ") - 1) & ".rc_khxx WHERE rc_khxx.khdm = gl_ywfjsb.khdm) WHERE gl_ywfjsb.cperiod = ? AND gl_ywfjsb.t_zydm IS NULL"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = (Me.NudYear.Value - 1).ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                '更新上年销售分类编码--根据客户信息
                rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET t_xslbdm = (SELECT xslbdm FROM rcdata_" & Mid(Me.ListBoxYixuanDwdm.Items(j), 1, InStr(Me.ListBoxYixuanDwdm.Items(j), " ") - 1) & ".rc_khxx WHERE rc_khxx.khdm = gl_ywfjsb.khdm) WHERE gl_ywfjsb.cperiod = ? AND gl_ywfjsb.t_xslbdm IS NULL"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = (Me.NudYear.Value - 1).ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                '更新业务员姓名
                rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET zymc = (SELECT zymc FROM rcdata_" & Mid(Me.ListBoxYixuanDwdm.Items(j), 1, InStr(Me.ListBoxYixuanDwdm.Items(j), " ") - 1) & ".rc_zyxx WHERE rc_zyxx.zydm = gl_ywfjsb.zydm) WHERE cperiod = ? AND gl_ywfjsb.zymc IS NULL"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                '更新上年业务员姓名
                rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET t_zymc = (SELECT zymc FROM rcdata_" & Mid(Me.ListBoxYixuanDwdm.Items(j), 1, InStr(Me.ListBoxYixuanDwdm.Items(j), " ") - 1) & ".rc_zyxx WHERE rc_zyxx.zydm = gl_ywfjsb.t_zydm) WHERE cperiod = ? AND gl_ywfjsb.t_zymc IS NULL"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = (Me.NudYear.Value - 1).ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                '更新上年客户名称--根据客户信息
                rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET khmc = (SELECT khmc FROM rcdata_" & Mid(Me.ListBoxYixuanDwdm.Items(j), 1, InStr(Me.ListBoxYixuanDwdm.Items(j), " ") - 1) & ".rc_khxx WHERE rc_khxx.khdm = gl_ywfjsb.khdm) WHERE gl_ywfjsb.cperiod = ? AND exists (select 1 from rcdata_" & Mid(Me.ListBoxYixuanDwdm.Items(j), 1, InStr(Me.ListBoxYixuanDwdm.Items(j), " ") - 1) & ".rc_khxx where rc_khxx.khdm = gl_ywfjsb.khdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = (Me.NudYear.Value - 1).ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                '更新收款期限
                rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET skqx = (SELECT skqx FROM rcdata_" & Mid(Me.ListBoxYixuanDwdm.Items(j), 1, InStr(Me.ListBoxYixuanDwdm.Items(j), " ") - 1) & ".rc_khxx WHERE rc_khxx.khdm = gl_ywfjsb.khdm) WHERE cperiod = ? AND (gl_ywfjsb.skqx IS NULL OR gl_ywfjsb.skqx = 0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                '本月发出
                rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET byjf = NVL(byjf,0) + (SELECT COALESCE(SUM(je),0.0) FROM rcdata_" & Mid(Me.ListBoxYixuanDwdm.Items(j), 1, InStr(Me.ListBoxYixuanDwdm.Items(j), " ") - 1) & ".gl_pz WHERE gl_pz.khdm = gl_ywfjsb.khdm AND (" & strKmdm & ") AND gl_pz.jd = '借' AND gl_pz.cperiod= ?) WHERE cperiod = ? AND EXISTS (SELECT 1 FROM rcdata_" & Mid(Me.ListBoxYixuanDwdm.Items(j), 1, InStr(Me.ListBoxYixuanDwdm.Items(j), " ") - 1) & ".gl_pz WHERE gl_pz.khdm = gl_ywfjsb.khdm AND (" & strKmdm & ") AND gl_pz.cperiod = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                '本月收款
                rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET bydf = NVL(bydf,0) + (SELECT COALESCE(SUM(je),0.0) FROM rcdata_" & Mid(Me.ListBoxYixuanDwdm.Items(j), 1, InStr(Me.ListBoxYixuanDwdm.Items(j), " ") - 1) & ".gl_pz WHERE gl_pz.khdm = gl_ywfjsb.khdm AND (" & strKmdm & ") AND gl_pz.jd = '贷' AND gl_pz.cperiod= ?) WHERE cperiod = ? AND EXISTS (SELECT 1 FROM rcdata_" & Mid(Me.ListBoxYixuanDwdm.Items(j), 1, InStr(Me.ListBoxYixuanDwdm.Items(j), " ") - 1) & ".gl_pz WHERE gl_pz.khdm = gl_ywfjsb.khdm AND (" & strKmdm & ") AND gl_pz.cperiod = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                '更新1至13个月借方金额'
                For i = 1 To 13
                    rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET jf" & i.ToString.PadLeft(2, "0") & " = NVL(jf" & i.ToString.PadLeft(2, "0") & ",0) + (SELECT COALESCE(SUM(je),0.0) FROM rcdata_" & Mid(Me.ListBoxYixuanDwdm.Items(j), 1, InStr(Me.ListBoxYixuanDwdm.Items(j), " ") - 1) & ".gl_pz WHERE gl_pz.khdm = gl_ywfjsb.khdm AND (" & strKmdm & ") AND gl_pz.jd = '借' AND gl_pz.cperiod= ?) WHERE cperiod = ? AND EXISTS (SELECT 1 FROM rcdata_" & Mid(Me.ListBoxYixuanDwdm.Items(j), 1, InStr(Me.ListBoxYixuanDwdm.Items(j), " ") - 1) & ".gl_pz WHERE gl_pz.khdm = gl_ywfjsb.khdm AND (" & strKmdm & ") AND gl_pz.cperiod = ?)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = IIf(Me.NudMonth.Value - i + 1 <= 0, (Me.NudYear.Value - 1).ToString & (Me.NudMonth.Value - i + 13).ToString.PadLeft(2, "0"), Me.NudYear.Value.ToString & (Me.NudMonth.Value - i + 1).ToString.PadLeft(2, "0"))
                    rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = IIf(Me.NudMonth.Value - i + 1 <= 0, (Me.NudYear.Value - 1).ToString & (Me.NudMonth.Value - i + 13).ToString.PadLeft(2, "0"), Me.NudYear.Value.ToString & (Me.NudMonth.Value - i + 1).ToString.PadLeft(2, "0"))
                    rcOleDbCommand.ExecuteNonQuery()
                Next
                '更新客户销售分类
                rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET xslbdm = (SELECT xslbdm FROM rcdata_" & Mid(Me.ListBoxYixuanDwdm.Items(j), 1, InStr(Me.ListBoxYixuanDwdm.Items(j), " ") - 1) & ".rc_khxx WHERE rc_khxx.khdm = gl_ywfjsb.khdm) WHERE cperiod = ? AND xslbdm IS NULL"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                '更新业务费标准系数
                rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET ywfbl = (SELECT ywfbl FROM rcdata_" & Mid(Me.ListBoxYixuanDwdm.Items(j), 1, InStr(Me.ListBoxYixuanDwdm.Items(j), " ") - 1) & ".rc_khxslb WHERE rc_khxslb.xslbdm = gl_ywfjsb.xslbdm) WHERE cperiod = ? AND (ywfbl IS NULL OR ywfbl = 0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                '更新汇率差金额到计算表
                rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET ywf_hlc = NVL(ywf_hlc,0) + (SELECT NVL(SUM(NVL(gl_pz.je,0) * NVL(ywfbl,0) * NVL(rc_wbxx.ywftzbl,0) / 10000),0) FROM rcdata_" & Mid(Me.ListBoxYixuanDwdm.Items(j), 1, InStr(Me.ListBoxYixuanDwdm.Items(j), " ") - 1) & ".gl_pz,rcdata_" & Mid(Me.ListBoxYixuanDwdm.Items(j), 1, InStr(Me.ListBoxYixuanDwdm.Items(j), " ") - 1) & ".rc_wbxx WHERE gl_pz.bz = rc_wbxx.wbdm AND rc_wbxx.kjnd = ? AND (" & strKmdm & ") AND gl_pz.jd = '贷' AND gl_pz.cperiod = ? AND gl_pz.khdm = gl_ywfjsb.khdm) WHERE cperiod = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
            Next
            '把负数发生额踢掉
            For i = 1 To 13
                rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET jf" & i.ToString.PadLeft(2, "0") & " = 0 WHERE cperiod = ? AND jf" & i.ToString.PadLeft(2, "0") & " < 0 "
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
            Next
            '根据余额进行分解成各月的发货额
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET jf00 = 0,jf01 = 0,jf02 = 0,jf03 = 0,jf04 = 0,jf05 = 0,jf06 = 0,jf07 = 0,jf08 = 0,jf09 = 0,jf10 = 0,jf11 = 0,jf12 = 0,jf13 = 0,jf14 = 0  WHERE cperiod = ? AND CASE WHEN NVL(qmye,0) >0 THEN NVL(qmye,0) ELSE 0 END + CASE WHEN NVL(bydf,0) >0 THEN NVL(bydf,0) ELSE 0 END <= 0"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            '预收款
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET jf00 = CASE WHEN NVL(bydf,0) > 0 - NVL(qmye,0) THEN 0 - NVL(qmye,0) ELSE NVL(bydf,0) END WHERE cperiod = ? AND NVL(qmye,0) < 0 OR (qmye = 0 AND bydf < 0)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            For i = 1 To 13 Step 1
                '期末余额+本月收款>0,上月底余额>=0
                rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET jf" & i.ToString.PadLeft(2, "0") & " = CASE WHEN CASE WHEN NVL(qmye,0) >0 THEN NVL(qmye,0) ELSE 0 END + NVL(bydf,0) > NVL(jf00,0)"
                For j = 1 To i - 1
                    rcOleDbCommand.CommandText += "+ NVL(jf" & j.ToString.PadLeft(2, "0") & ",0)"
                Next
                rcOleDbCommand.CommandText += " THEN CASE WHEN CASE WHEN NVL(qmye,0) >0 THEN NVL(qmye,0) ELSE 0 END  - NVL(jf00,0) + CASE WHEN NVL(bydf,0) >0 THEN NVL(bydf,0) ELSE 0 END > NVL(jf00,0)"
                For j = 1 To i
                    rcOleDbCommand.CommandText += "+ NVL(jf" & j.ToString.PadLeft(2, "0") & ",0)"
                Next
                rcOleDbCommand.CommandText += " THEN NVL(jf" & i.ToString.PadLeft(2, "0") & ",0) ELSE CASE WHEN NVL(qmye,0) >0 THEN NVL(qmye,0) ELSE 0 END - NVL(jf00,0) + CASE WHEN NVL(bydf,0) >0 THEN NVL(bydf,0) ELSE 0 END"
                For j = 1 To i - 1
                    rcOleDbCommand.CommandText += " - NVL(jf" & j.ToString.PadLeft(2, "0") & ",0)"
                Next
                rcOleDbCommand.CommandText += " END ELSE 0.0 END WHERE cperiod = ? AND CASE WHEN NVL(qmye,0) >0 THEN NVL(qmye,0) ELSE 0 END  - NVL(jf00,0) + CASE WHEN NVL(bydf,0) >0 THEN NVL(bydf,0) ELSE 0 END >= 0 AND (qmye > 0 OR bydf > 0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
            Next
            'rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET jf01 = bydf  WHERE cperiod = ? AND bydf + qmye <= 0"
            'rcOleDbCommand.Parameters.Clear()
            'rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET jf01 = CASE WHEN qmye <= jf01 THEN qmye ELSE jf01 END  WHERE cperiod = ? AND qmye > 0"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET jf14 = CASE WHEN CASE WHEN NVL(qmye,0) >0 THEN NVL(qmye,0) ELSE 0 END - NVL(jf00,0) + CASE WHEN NVL(bydf,0) >0 THEN NVL(bydf,0) ELSE 0 END > NVL(jf01,0) +NVL(jf02,0) +NVL(jf03,0) +NVL(jf04,0) +NVL(jf05,0) +jf06 +jf07 +jf08 +jf09 +jf10 +jf11 +jf12 +jf13 THEN qmye - NVL(jf00,0) + bydf -jf01 -jf02 -jf03 -jf04 -jf05 -jf06 -jf07 -jf08 -jf09 -jf10 -jf11 -jf12 -jf13 ELSE 0.0 END WHERE cperiod = ? AND CASE WHEN NVL(qmye,0) >0 THEN NVL(qmye,0) ELSE 0 END - NVL(jf00,0) + CASE WHEN NVL(bydf,0) >0 THEN NVL(bydf,0) ELSE 0 END >= 0 AND (qmye > 0 or bydf > 0)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            '根据收款期进行应收借方金额调整
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET jf14 = jf14 +jf13 +jf12 +jf11 +jf10 +jf09 +jf08,jf13 = 0,jf12 =0,jf11 =0,jf10 =0,jf09 =0,jf08 = 0 WHERE cperiod = ? AND skqx = 0"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET jf14 = jf14 +jf13 +jf12 +jf11 +jf10 +jf09,jf13 = 0,jf12 =0,jf11 =0,jf10 =0,jf09 =0 WHERE cperiod = ? AND skqx = 30"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET jf14 = jf14 +jf13 +jf12 +jf11 +jf10,jf13 = 0,jf12 =0,jf11 =0,jf10 =0 WHERE cperiod = ? AND skqx = 60"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET jf14 = jf14 +jf13 +jf12 +jf11,jf13 = 0,jf12 =0,jf11 =0 WHERE cperiod = ? AND skqx = 90"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET jf14 = jf14 +jf13 +jf12,jf13 = 0,jf12 =0 WHERE cperiod = ? AND skqx = 120"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET jf14 = jf14 +jf13,jf13 = 0 WHERE cperiod = ? AND skqx = 150"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()


            '将本月回笼额根据发出额的时间先后顺序分解到各时间段的回笼额中
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET df14 = (CASE WHEN bydf >= jf14 THEN jf14 ELSE bydf END) WHERE cperiod = ? AND bydf > 0"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            For i = 13 To 1 Step -1
                'update gl_ywfjsb set df13 = case when bydf > df14 THEN case when bydf > jf14+ jf13 then jf13 else bydf - jf14 end else 0 end
                rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET df" & i.ToString.PadLeft(2, "0") & " = CASE WHEN bydf >= "
                For j = 14 To i + 1 Step -1
                    rcOleDbCommand.CommandText += IIf(j = 14, "", " +") & "jf" & j.ToString.PadLeft(2, "0")
                Next
                rcOleDbCommand.CommandText += " THEN CASE WHEN bydf >"
                For j = 14 To i Step -1
                    rcOleDbCommand.CommandText += IIf(j = 14, "", " +") & "jf" & j.ToString.PadLeft(2, "0")
                Next
                rcOleDbCommand.CommandText += " THEN jf" & i.ToString.PadLeft(2, "0") & " ELSE bydf"
                For j = 14 To i + 1 Step -1
                    rcOleDbCommand.CommandText += " -jf" & j.ToString.PadLeft(2, "0")
                Next
                rcOleDbCommand.CommandText += " END ELSE 0.0 END WHERE cperiod = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
            Next
            '根据收款期进行逾期金额调整
            'rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET df14 = df14 +df13 +df12 +df11 +df10 +df09 +df08,df13 = df07,df12 =df06,df11 =df05,df10 =df04,df09 =df03,df08 = df02,df07 =df01,df06 =0,df05 =0,df04 =0,df03 =0,df02 =0,df01 =0 WHERE cperiod = ? AND skqx = 0"
            'rcOleDbCommand.Parameters.Clear()
            'rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            'rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET df14 = df14 +df13 +df12 +df11 +df10 +df09,df13 = df08,df12 =df07,df11 =df06,df10 =df05,df09 =df04,df08 = df03,df07 =df02,df06 =0,df05 =0,df04 =0,df03 =0,df02 =0 WHERE cperiod = ? AND (skqx = 30 OR skqx = 0)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET df14 = df14 +df13 +df12 +df11 +df10,df13 = df09,df12 =df08,df11 =df07,df10 =df06,df09 =df05,df08 = df04,df07 =df03,df06 =0,df05 =0,df04 =0,df03 =0 WHERE cperiod = ? AND skqx = 60"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET df14 = df14 +df13 +df12 +df11,df13 = df10,df12 =df09,df11 =df08,df10 =df07,df09 =df06,df08 = df05,df07 =df04,df06 =0,df05 =0,df04 =0 WHERE cperiod = ? AND skqx = 90"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET df14 = df14 +df13 +df12,df13 = df11,df12 =df10,df11 =df09,df10 =df08,df09 =df07,df08 = df06,df07 =df05,df06 =0,df05 =0 WHERE cperiod = ? AND skqx = 120"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET df14 = df14 +df13,df13 = df12,df12 =df11,df11 =df10,df10 =df09,df09 =df08,df08 = df07,df07 =df06,df06 =0 WHERE cperiod = ? AND skqx = 150"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            '预收款全部加到30天内
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET df01 = df01 + jf00 WHERE cperiod = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()

            '读取业务费倒扣比率前面8行
            rcOleDbCommand.CommandText = "SELECT * FROM gl_ywfdkl WHERE ROWNUM<=8 ORDER BY xh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("gl_ywfdkl") IsNot Nothing Then
                rcDataSet.Tables("gl_ywfdkl").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "gl_ywfdkl")
            For i = 0 To rcDataSet.Tables("gl_ywfdkl").Rows.Count - 1
                rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET dkl" & (i + 7).ToString.PadLeft(2, "0") & " = " & rcDataSet.Tables("gl_ywfdkl").Rows(i).Item("dkbl") & " WHERE cperiod = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
            Next
            '计算账龄业务费
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET ywf_zl = ROUND(NVL(df07,0) * NVL(ywfbl,0) * NVL(dkl07,0) + NVL(df08,0) * NVL(ywfbl,0) * NVL(dkl08,0) + NVL(df09,0) * NVL(ywfbl,0) * NVL(dkl09,0) + NVL(df10,0) * NVL(ywfbl,0) * NVL(dkl10,0) + NVL(df11,0) * NVL(ywfbl,0) * NVL(dkl11,0) + NVL(df12,0) * NVL(ywfbl,0) * NVL(dkl12,0) + NVL(df13,0) * NVL(ywfbl,0) * NVL(dkl13,0) + (NVL(jf14,0) - NVL(df14,0)) * NVL(dkl14,0) * 100,-2) / 10000  WHERE cperiod = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            For j = 0 To Me.ListBoxYixuanDwdm.Items.Count - 1
                '提取收款方式为承兑汇票的金额
                rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET cdhpje = NVL(cdhpje,0) + (SELECT NVL(SUM(JE),0) FROM rcdata_" & Mid(Me.ListBoxYixuanDwdm.Items(j), 1, InStr(Me.ListBoxYixuanDwdm.Items(j), " ") - 1) & ".ar_skd WHERE SUBSTR(djh,5,6)=  ? AND EXISTS (SELECT 1 FROM rcdata_" & Mid(Me.ListBoxYixuanDwdm.Items(j), 1, InStr(Me.ListBoxYixuanDwdm.Items(j), " ") - 1) & ".rc_jsfs WHERE rc_jsfs.bkywf = 1 AND rc_jsfs.jsfsdm = ar_skd.jsfsdm) AND ar_skd.khdm = gl_ywfjsb.khdm) WHERE cperiod = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
            Next
            '计算承兑汇票倒扣金额
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET ywf_cdhp = ROUND(NVL(gl_ywfjsb.cdhpje,0) * NVL(gl_ywfjsb.ywfbl,0) / 10000 * " & Me.TxtCdhp.Text & ",2) WHERE cperiod = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            '抵扣业务计算
            '（1）更新业务费标准系数
            rcOleDbCommand.CommandText = "UPDATE gl_ywfdkyw SET ywfbl = (SELECT ywfbl FROM rc_khxslb,rc_khxx WHERE rc_khxslb.xslbdm = rc_khxx.xslbdm AND rc_khxx.khdm = gl_ywfdkyw.khdm) WHERE SUBSTR(gl_ywfdkyw.djh,5,6) = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            '抵扣业务
            rcOleDbCommand.CommandText = "SELECT gl_ywfdkyw.djh,gl_ywfdkgs.jsgs FROM gl_ywfdkyw,gl_ywfdkgs WHERE gl_ywfdkyw.dkgsdm = gl_ywfdkgs.dkgsdm AND SUBSTR(gl_ywfdkyw.djh,5,6) = ? ORDER BY gl_ywfdkyw.djh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("gl_ywfdkyw") IsNot Nothing Then
                rcDataSet.Tables("gl_ywfdkyw").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "gl_ywfdkyw")
            For i = 0 To rcDataSet.Tables("gl_ywfdkyw").Rows.Count - 1
                rcOleDbCommand.CommandText = "UPDATE gl_ywfdkyw SET dkje = " & rcDataSet.Tables("gl_ywfdkyw").Rows(i).Item("jsgs") & " WHERE djh = ?"
                rcOleDbCommand.Parameters.Clear()
                'rcOleDbCommand.Parameters.Add("@jsgs", OleDbType.VarChar, 500).Value = rcDataSet.Tables("gl_ywfdkyw").Rows(i).Item("jsgs")
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataSet.Tables("gl_ywfdkyw").Rows(i).Item("djh")
                rcOleDbCommand.ExecuteNonQuery()
            Next
            '更新贴息金额到计算表
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET tiexije = (SELECT SUM(NVL(fyje,0)) FROM gl_ywfdkyw WHERE SUBSTR(gl_ywfdkyw.djh,5,6) = ? AND gl_ywfdkyw.dkgsmc LIKE '%贴息%'  AND gl_ywfdkyw.khdm = gl_ywfjsb.khdm) WHERE cperiod = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            '更新贴息扣款金额到计算表
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET ywf_tx = (SELECT SUM(NVL(dkje,0)) FROM gl_ywfdkyw WHERE SUBSTR(gl_ywfdkyw.djh,5,6) = ? AND gl_ywfdkyw.dkgsmc LIKE '%贴息%' AND gl_ywfdkyw.khdm = gl_ywfjsb.khdm) WHERE cperiod = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            '更新佣金金额到计算表
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET (skje_yj,yongjinje) = (SELECT SUM(NVL(skje,0)),SUM(NVL(fyje,0)) FROM gl_ywfdkyw WHERE SUBSTR(gl_ywfdkyw.djh,5,6) = ? AND gl_ywfdkyw.dkgsmc LIKE '%佣金%'  AND gl_ywfdkyw.khdm = gl_ywfjsb.khdm) WHERE cperiod = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            '更新佣金扣款金额到计算表
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET ywf_yj = (SELECT SUM(NVL(dkje,0)) FROM gl_ywfdkyw WHERE SUBSTR(gl_ywfdkyw.djh,5,6) = ? AND gl_ywfdkyw.dkgsmc LIKE '%佣金%' AND gl_ywfdkyw.khdm = gl_ywfjsb.khdm) WHERE cperiod = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            '计算新客户提升比例
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET newkhbl =  0 WHERE cperiod = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET newkhbl =  NVL(" & Me.TxtNewKh.Text & ",0)  WHERE cperiod = ? AND EXISTS (SELECT 1 FROM rc_khxx WHERE (rc_khxx.djyear = " & Me.NudYear.Value & " OR  rc_khxx.djyear = " & Me.NudYear.Value - 1 & ") AND rc_khxx.khdm = gl_ywfjsb.khdm)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET newkhbl =  0 - NVL(" & Me.TxtOldKh.Text & ",0)  WHERE cperiod = ? AND NOT EXISTS (SELECT 1 FROM rc_khxx WHERE (rc_khxx.djyear = " & Me.NudYear.Value & " OR  rc_khxx.djyear = " & Me.NudYear.Value - 1 & ") AND rc_khxx.khdm = gl_ywfjsb.khdm)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            '计算新客户提升业务费
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET ywf_newkh = ROUND((NVL(bydf,0) - NVL(yongjinje,0) - NVL(tiexije,0)) * NVL(ywfbl,0) * NVL(newkhbl,0) / 10000,2)  WHERE cperiod = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            '计算标准业务费
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET ywf_bz = ROUND((NVL(bydf,0) - NVL(yongjinje,0) - NVL(tiexije,0)) * NVL(ywfbl,0) / 100,2)  WHERE cperiod = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            '更新呆账金额到计算表
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET daizhang = (SELECT SUM(NVL(skje,0)) FROM gl_ywfdkyw WHERE SUBSTR(gl_ywfdkyw.djh,5,6) = ? AND gl_ywfdkyw.dkgsmc LIKE '%呆账%'  AND gl_ywfdkyw.khdm = gl_ywfjsb.khdm) WHERE cperiod = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            '更新呆账扣款金额到计算表
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET ywf_dz = (SELECT SUM(NVL(dkje,0)) FROM gl_ywfdkyw WHERE SUBSTR(gl_ywfdkyw.djh,5,6) = ? AND gl_ywfdkyw.dkgsmc LIKE '%呆账%' AND gl_ywfdkyw.khdm = gl_ywfjsb.khdm) WHERE cperiod = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            '更新诉讼金额到计算表
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET susong = (SELECT SUM(NVL(skje,0)) FROM gl_ywfdkyw WHERE SUBSTR(gl_ywfdkyw.djh,5,6) = ? AND gl_ywfdkyw.dkgsmc LIKE '%诉讼%'  AND gl_ywfdkyw.khdm = gl_ywfjsb.khdm) WHERE cperiod = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            '更新诉讼扣款金额到计算表
            rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET ywf_ss = (SELECT SUM(NVL(dkje,0)) FROM gl_ywfdkyw WHERE SUBSTR(gl_ywfdkyw.djh,5,6) = ? AND gl_ywfdkyw.dkgsmc LIKE '%诉讼%' AND gl_ywfdkyw.khdm = gl_ywfjsb.khdm) WHERE cperiod = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            ''更新汇率差金额*结算系数到计算表
            'rcOleDbCommand.CommandText = "UPDATE gl_ywfjsb SET ywf_hlc = NVL(ywf_hlc,0) * NVL(ywfbl,0) WHERE cperiod = ?"
            'rcOleDbCommand.Parameters.Clear()
            'rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            'rcOleDbCommand.ExecuteNonQuery()

            '读取数据
            rcOleDbCommand.CommandText = "SELECT gl_ywfjsb.khdm,gl_ywfjsb.khmc,gl_ywfjsb.zydm,gl_ywfjsb.zymc,gl_ywfjsb.xslbdm,gl_ywfjsb.ywfbl,gl_ywfjsb.newkhbl,gl_ywfjsb.skqx,gl_ywfjsb.byjf,gl_ywfjsb.bydf,gl_ywfjsb.qmye,gl_ywfjsb.jf00,gl_ywfjsb.jf01,gl_ywfjsb.jf02,gl_ywfjsb.jf03,gl_ywfjsb.jf04,gl_ywfjsb.jf05,gl_ywfjsb.jf06,gl_ywfjsb.jf07,gl_ywfjsb.jf08,gl_ywfjsb.jf09,gl_ywfjsb.jf10,gl_ywfjsb.jf11,gl_ywfjsb.jf12,gl_ywfjsb.jf13,gl_ywfjsb.jf14,gl_ywfjsb.df01,gl_ywfjsb.df02,gl_ywfjsb.df03,gl_ywfjsb.df04,gl_ywfjsb.df05,gl_ywfjsb.df06,gl_ywfjsb.df07,gl_ywfjsb.df08,gl_ywfjsb.df09,gl_ywfjsb.df10,gl_ywfjsb.df11,gl_ywfjsb.df12,gl_ywfjsb.df13,gl_ywfjsb.df14,gl_ywfjsb.ywf_bz,gl_ywfjsb.ywf_newkh,0 - gl_ywfjsb.ywf_zl AS ywf_zl,gl_ywfjsb.cdhpje,0 - gl_ywfjsb.ywf_cdhp AS ywf_cdhp,gl_ywfjsb.tiexije, 0 - gl_ywfjsb.ywf_tx AS ywf_tx,gl_ywfjsb.skje_yj,gl_ywfjsb.yongjinje,0 - gl_ywfjsb.ywf_yj AS ywf_yj,gl_ywfjsb.daizhang,0 - gl_ywfjsb.ywf_dz AS ywf_dz,gl_ywfjsb.susong,0 - gl_ywfjsb.ywf_ss AS ywf_ss,gl_ywfjsb.ywf_hlc,NVL(gl_ywfjsb.ywf_bz,0) + NVL(gl_ywfjsb.ywf_newkh,0) - NVL(gl_ywfjsb.ywf_zl,0) - NVL(gl_ywfjsb.ywf_cdhp,0) - NVL(gl_ywfjsb.ywf_tx,0) - NVL(gl_ywfjsb.ywf_yj,0) - NVL(gl_ywfjsb.ywf_dz,0) - NVL(gl_ywfjsb.ywf_ss,0) + NVL(gl_ywfjsb.ywf_hlc,0) AS ywf_hj FROM gl_ywfjsb WHERE cperiod = ? ORDER BY gl_ywfjsb.khdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
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
        '调用表单
        Dim rcFrm As New FrmYwfJsz
        With rcFrm
            .ParaDataSet = rcDataSet
            .ParaDataView = New DataView(rcDataSet.Tables("gl_ywfjsb"), "TRUE", "zydm,khdm", DataViewRowState.CurrentRows)
            .Label2.Text = "会计期间：" & Me.NudYear.Value & "年" & Me.NudMonth.Value & "月"
            '.Label3.Text = "仓库：" & Trim(Me.TxtCkdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With

    End Sub
End Class