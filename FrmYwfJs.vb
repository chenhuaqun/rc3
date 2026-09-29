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
            rcDataset.Tables("rc_para")?.Clear()
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
        Dim dateBegin As Date = GetInvBegin(Me.NudYear.Value, Me.NudMonth.Value)
        Dim dateEnd As Date = GetInvEnd(Me.NudYear.Value, Me.NudMonth.Value)
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
        Me.LblMsg.Text = "写系统参数。"
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

        '读取所选账套的连接信息
        'strMainConnString 为登录时的连接串，仅供同步主账套业务费规则时读数据用
        Dim strMainConnString As String = rcOleDbConn.ConnectionString
        Dim dtCalcDwdm As New DataTable
        Dim strIN As String = ""
        For i = 0 To Me.ListBoxYixuanDwdm.Items.Count - 1
            strIN &= IIf(i = 0, "", ",") & "'" & Mid(Me.ListBoxYixuanDwdm.Items(i), 1, InStr(Me.ListBoxYixuanDwdm.Items(i), " ") - 1) & "'"
        Next
        Try
            sysOleDbConn.Open()
            rcOleDbCommand.Transaction = Nothing
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT dwdm,dwmc,host,servicename,userid,userpwd FROM rc_dwdm WHERE TRIM(dwdm) IN (" & strIN & ") Order by dwdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            rcOleDbDataAdpt.Fill(dtCalcDwdm)
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message)
            Return
        Finally
            sysOleDbConn.Close()
        End Try
        '校验所选账套的连接信息并组装连接串，有缺失则终止，避免算出残缺结果
        Dim dicConnString As New Dictionary(Of String, String)
        Dim strInvalid As String = ""
        For i = 0 To dtCalcDwdm.Rows.Count - 1
            Dim strChkDwdm As String = SafeText(dtCalcDwdm.Rows(i).Item("dwdm"))
            Dim strChkDwmc As String = SafeText(dtCalcDwdm.Rows(i).Item("dwmc"))
            Dim strHost As String = SafeText(dtCalcDwdm.Rows(i).Item("host"))
            Dim strServiceName As String = SafeText(dtCalcDwdm.Rows(i).Item("servicename"))
            Dim strUserId As String = SafeText(dtCalcDwdm.Rows(i).Item("userid"))
            Dim strUserPwd As String = SafeText(dtCalcDwdm.Rows(i).Item("userpwd"))
            Dim strMissing As String = ""
            If strHost.Length = 0 Then strMissing &= "数据库服务器、"
            If strServiceName.Length = 0 Then strMissing &= "服务名、"
            If strUserId.Length = 0 Then strMissing &= "用户名、"
            If strUserPwd.Length = 0 Then strMissing &= "口令、"
            If strMissing.Length > 0 Then
                strInvalid &= "    " & strChkDwdm & " " & strChkDwmc & "：缺" & Mid(strMissing, strMissing.Length - 1) & Chr(13)
            Else
                dicConnString.Add(strChkDwdm, BuildOraConnString(strHost, strServiceName, strUserId, strUserPwd))
            End If
        Next
        If strInvalid.Length > 0 Then
            MsgBox("以下账套在系统库 rc_dwdm 中未完整配置数据库连接信息，无法计算业务费：" & Chr(13) & Chr(13) _
                   & strInvalid & Chr(13) & "请由系统管理员补全 rc_dwdm 的 host、servicename、userid、userpwd 后重试。",
                   MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        If rcDataset.Tables("gl_ywfjsb") IsNot Nothing Then
            rcDataset.Tables("gl_ywfjsb").Clear()
        End If
        '逐账套计算，每个账套用 rc_dwdm 组装的连接串开独立连接
        For i = 0 To dtCalcDwdm.Rows.Count - 1
            Dim strDwdm As String = SafeText(dtCalcDwdm.Rows(i).Item("dwdm"))
            Dim strDwmc As String = SafeText(dtCalcDwdm.Rows(i).Item("dwmc"))
            Me.LblMsg.Text = "计算" & strDwdm & "账套业务费（" & (i + 1).ToString & "/" & dtCalcDwdm.Rows.Count.ToString & "）"
            CalcOneYwf(strDwdm, strDwmc, strKmdm, dicConnString(strDwdm), strMainConnString)
        Next
        '调用表单
        If rcDataset.Tables("gl_ywfjsb") IsNot Nothing AndAlso rcDataset.Tables("gl_ywfjsb").Rows.Count > 0 Then
            Dim rcFrm As New FrmYwfJsz
            With rcFrm
                .ParaDataSet = rcDataset
                .ParaDataView = New DataView(rcDataset.Tables("gl_ywfjsb"), "TRUE", "dwdm,zydm,khdm", DataViewRowState.CurrentRows)
                .Label2.Text = "会计期间：" & Me.NudYear.Value & "年" & Me.NudMonth.Value & "月"
                '.Label3.Text = "仓库：" & Trim(Me.TxtCkdm.Text)
                .WindowState = FormWindowState.Maximized
                .MdiParent = Me.MdiParent
                .Show()
            End With
        Else
            MsgBox("没有符合条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
        End If

    End Sub

    '取连接信息字段文本，数据库空值统一转为空串
    Private Function SafeText(ByVal obj As Object) As String
        If obj Is Nothing OrElse obj Is DBNull.Value Then
            Return ""
        End If
        Return Trim(obj.ToString())
    End Function

    '按 Oracle OLE DB 方式组装账套连接字符串
    Private Function BuildOraConnString(ByVal strHost As String, ByVal strServiceName As String, ByVal strUserId As String, ByVal strUserPwd As String) As String
        Return "Provider=OraOLEDB.Oracle.1;Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = " _
            & strHost & ")(PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = " & strServiceName & ")));User ID=" _
            & strUserId & ";Password=" & strUserPwd & ";Pooling = false"
    End Function

    '计算单个账套业务费，连接串取自系统库 rc_dwdm，不改写全局 rcOleDbConn
    Private Sub CalcOneYwf(ByVal strDwdm As String, ByVal strDwmc As String, ByVal strKmdm As String, ByVal strConnString As String, ByVal strMainConnString As String)
        '本账套专用连接
        Dim rcConnYwf As New OleDbConnection
        Dim rcCmdYwf As OleDbCommand
        Dim rcAdptYwf As New OleDbDataAdapter
        Dim rcTransYwf As OleDbTransaction
        Try
            Dim i As Integer
            Dim j As Integer
            rcConnYwf.ConnectionString = strConnString
            rcConnYwf.Open()
            rcCmdYwf = rcConnYwf.CreateCommand()
            rcCmdYwf.CommandTimeout = 300
            rcCmdYwf.CommandType = CommandType.Text
            '规则同步不参与业务费事务，故在开事务前执行
            If Trim(strDwdm) <> Trim(g_Dwdm) Then
                SyncYwfRuleFromMain(strDwdm, strMainConnString, rcCmdYwf)
            End If
            rcTransYwf = rcConnYwf.BeginTransaction(IsolationLevel.ReadCommitted)
            rcCmdYwf.Transaction = rcTransYwf
            Me.LblMsg.Text = "删除历史数据"
            '删除历史数据
            rcCmdYwf.CommandText = "DELETE FROM gl_ywfjsb WHERE cperiod = ?"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET t_zydm = '',t_zymc = '' WHERE cperiod = ?"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = (Me.NudYear.Value - 1).ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET t_xslbdm = '' WHERE cperiod = ?"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = (Me.NudYear.Value - 1).ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()

            Me.LblMsg.Text = "插入客户与年初余额"
            '插入客户与年初余额
            rcCmdYwf.CommandText = "INSERT INTO gl_ywfjsb (cperiod,khdm,qmye) SELECT ?,khdm,0 AS qmye FROM gl_kmyeb WHERE kjnd = ? AND khdm <> '~' AND EXISTS (SELECT 1 FROM rc_khxx WHERE rc_khxx.khdm = gl_kmyeb.khdm AND rc_khxx.bjsywf = 1) AND (" & strKmdm & ") AND NOT EXISTS (SELECT 1 FROM gl_ywfjsb WHERE gl_ywfjsb.cperiod = ? AND gl_ywfjsb.khdm = gl_kmyeb.khdm) GROUP BY khdm"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            If CheckBox3.Checked Then
                Me.LblMsg.Text = "正在插入本期发出商品的客户"
                '插入发出商品的客户
                rcCmdYwf.CommandText = "INSERT INTO gl_ywfjsb (cperiod,khdm,qmye) SELECT ?,shkhdm AS khdm,0 AS qmye FROM oe_xsd_fcsp WHERE cperiod = ? AND shkhdm <> '~' AND EXISTS (SELECT 1 FROM rc_khxx WHERE rc_khxx.khdm = oe_xsd_fcsp.shkhdm AND rc_khxx.bjsywf = 1) AND NOT EXISTS (SELECT 1 FROM gl_ywfjsb WHERE gl_ywfjsb.cperiod = ? AND gl_ywfjsb.khdm = oe_xsd_fcsp.shkhdm) GROUP BY shkhdm"
                rcCmdYwf.Parameters.Clear()
                rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcCmdYwf.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcCmdYwf.ExecuteNonQuery()
            End If
            Me.LblMsg.Text = "抵扣业务中"
            '抵扣业务中
            rcCmdYwf.CommandText = "INSERT INTO gl_ywfjsb (cperiod,khdm,qmye) SELECT ?,khdm,0 AS qmye FROM gl_ywfdkyw WHERE SUBSTR(gl_ywfdkyw.djh,5,6) = ? AND khdm <> '~' AND EXISTS (SELECT 1 FROM rc_khxx WHERE rc_khxx.khdm = gl_ywfdkyw.khdm AND rc_khxx.bjsywf = 1) AND NOT EXISTS (SELECT 1 FROM gl_ywfjsb WHERE gl_ywfjsb.cperiod = ? AND gl_ywfjsb.khdm = gl_ywfdkyw.khdm) GROUP BY khdm"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.Parameters.Add("@djh", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "更新期末余额"
            '更新期末余额
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET qmye = NVL(qmye,0) +  (SELECT COALESCE(SUM(CASE WHEN gl_kmyeb.jd = '借' THEN ncje ELSE 0 - ncje END),0.0) AS qmye FROM gl_kmyeb WHERE kjnd = ? AND khdm <> '~' AND (" & strKmdm & ") AND gl_kmyeb.khdm = gl_ywfjsb.khdm GROUP BY khdm) WHERE cperiod = ? AND EXISTS (SELECT 1 FROM gl_kmyeb WHERE kjnd = ? AND khdm <> '~' AND (" & strKmdm & ") AND gl_kmyeb.khdm = gl_ywfjsb.khdm)"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "计算期末余额"
            '计算期末余额
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET qmye = NVL(qmye,0) + (SELECT COALESCE(SUM(CASE WHEN gl_pz.jd = '借' THEN je ELSE 0 - je END),0.0) FROM gl_pz WHERE gl_pz.khdm = gl_ywfjsb.khdm AND (" & strKmdm & ") AND gl_pz.cperiod <= ? AND gl_pz.cperiod >= ?) WHERE cperiod = ? AND EXISTS (SELECT 1 FROM gl_pz WHERE gl_pz.khdm = gl_ywfjsb.khdm AND (" & strKmdm & ") AND gl_pz.cperiod <= ? AND gl_pz.cperiod >= ?)"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & "01"
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & "01"
            rcCmdYwf.ExecuteNonQuery()
            If CheckBox3.Checked Then
                Me.LblMsg.Text = "计算期末余额+发出商品"
                '计算期末余额+发出商品
                rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET qmye = NVL(qmye,0) + (SELECT COALESCE(SUM(NVL(oe_xsd_fcsp.je,0) + NVL(oe_xsd_fcsp.se,0)),0.0) FROM oe_xsd_fcsp WHERE oe_xsd_fcsp.shkhdm = gl_ywfjsb.khdm AND oe_xsd_fcsp.cperiod = ?) WHERE cperiod = ? AND EXISTS (SELECT 1 FROM oe_xsd_fcsp WHERE oe_xsd_fcsp.shkhdm = gl_ywfjsb.khdm AND oe_xsd_fcsp.cperiod = ?)"
                rcCmdYwf.Parameters.Clear()
                rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcCmdYwf.ExecuteNonQuery()
            End If
            Me.LblMsg.Text = "更新客户名称、业务员编码"
            '更新客户名称、业务员编码
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET khmc = (SELECT khmc FROM rc_khxx WHERE rc_khxx.khdm = gl_ywfjsb.khdm) WHERE cperiod = ? AND gl_ywfjsb.khmc IS NULL"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "更新业务员编码、销售销售分类--根据专管业务员"
            '更新业务员编码、销售销售分类--根据专管业务员
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET (zydm,xslbdm) = (SELECT zydm,xslbdm FROM rc_khzyxx WHERE (SUBSTR(rc_khzyxx.ksperiod,1,4) = ? OR SUBSTR(rc_khzyxx.jsperiod,1,4) = ?) AND (rc_khzyxx.ksperiod <= ? OR rc_khzyxx.ksperiod IS NULL) AND (rc_khzyxx.jsperiod IS NULL OR rc_khzyxx.jsperiod >= ? ) AND rc_khzyxx.khdm = gl_ywfjsb.khdm) WHERE EXISTS (SELECT 1 FROM rc_khzyxx WHERE rc_khzyxx.khdm = gl_ywfjsb.khdm) AND gl_ywfjsb.cperiod = ?"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
            rcCmdYwf.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "更新上年业务员编码--根据专管业务员"
            '更新上年业务员编码--根据专管业务员
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET t_zydm = (SELECT zydm FROM rc_khzyxx WHERE (SUBSTR(rc_khzyxx.ksperiod,1,4) = ? OR SUBSTR(rc_khzyxx.jsperiod,1,4) = ?) AND (rc_khzyxx.ksperiod <= ? OR rc_khzyxx.ksperiod IS NULL) AND (rc_khzyxx.jsperiod IS NULL OR rc_khzyxx.jsperiod >= ? ) AND rc_khzyxx.khdm = gl_ywfjsb.khdm) WHERE EXISTS (SELECT 1 FROM rc_khzyxx WHERE rc_khzyxx.khdm = gl_ywfjsb.khdm) AND gl_ywfjsb.cperiod = ?"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
            rcCmdYwf.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = (Me.NudYear.Value - 1).ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "更新上年销售分类编码--根据专管业务员"
            '更新上年销售分类编码--根据专管业务员
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET t_xslbdm = (SELECT xslbdm FROM rc_khzyxx WHERE (SUBSTR(rc_khzyxx.ksperiod,1,4) = ? OR SUBSTR(rc_khzyxx.jsperiod,1,4) = ?) AND (rc_khzyxx.ksperiod <= ? OR rc_khzyxx.ksperiod IS NULL) AND (rc_khzyxx.jsperiod IS NULL OR rc_khzyxx.jsperiod >= ? ) AND rc_khzyxx.khdm = gl_ywfjsb.khdm) WHERE EXISTS (SELECT 1 FROM rc_khzyxx WHERE rc_khzyxx.khdm = gl_ywfjsb.khdm) AND gl_ywfjsb.cperiod = ?"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
            rcCmdYwf.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = (Me.NudYear.Value - 1).ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "更新业务员编码--根据客户信息"
            '更新业务员编码--根据客户信息
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET zydm = (SELECT zydm FROM rc_khxx WHERE rc_khxx.khdm = gl_ywfjsb.khdm) WHERE gl_ywfjsb.cperiod = ? AND gl_ywfjsb.zydm IS NULL"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "更新上年业务员编码--根据客户信息"
            '更新上年业务员编码--根据客户信息
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET t_zydm = (SELECT zydm FROM rc_khxx WHERE rc_khxx.khdm = gl_ywfjsb.khdm) WHERE gl_ywfjsb.cperiod = ? AND gl_ywfjsb.t_zydm IS NULL"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = (Me.NudYear.Value - 1).ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "更新上年销售分类编码--根据客户信息"
            '更新上年销售分类编码--根据客户信息
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET t_xslbdm = (SELECT xslbdm FROM rc_khxx WHERE rc_khxx.khdm = gl_ywfjsb.khdm) WHERE gl_ywfjsb.cperiod = ? AND gl_ywfjsb.t_xslbdm IS NULL"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = (Me.NudYear.Value - 1).ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "更新业务员姓名"
            '更新业务员姓名
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET zymc = (SELECT zymc FROM rc_zyxx WHERE rc_zyxx.zydm = gl_ywfjsb.zydm) WHERE cperiod = ? AND gl_ywfjsb.zymc IS NULL"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "更新上年业务员姓名"
            '更新上年业务员姓名
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET t_zymc = (SELECT zymc FROM rc_zyxx WHERE rc_zyxx.zydm = gl_ywfjsb.t_zydm) WHERE cperiod = ? AND gl_ywfjsb.t_zymc IS NULL"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = (Me.NudYear.Value - 1).ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "更新上年客户名称--根据客户信息"
            '更新上年客户名称--根据客户信息
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET khmc = (SELECT khmc FROM rc_khxx WHERE rc_khxx.khdm = gl_ywfjsb.khdm) WHERE gl_ywfjsb.cperiod = ? AND exists (select 1 from rc_khxx where rc_khxx.khdm = gl_ywfjsb.khdm)"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = (Me.NudYear.Value - 1).ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "更新收款期限"
            '更新收款期限
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET skqx = (SELECT skqx FROM rc_khxx WHERE rc_khxx.khdm = gl_ywfjsb.khdm) WHERE cperiod = ? AND (gl_ywfjsb.skqx IS NULL OR gl_ywfjsb.skqx = 0)"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "本月发出+科目"
            '本月发出+科目
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET byjf = NVL(byjf,0) + (SELECT COALESCE(SUM(je),0.0) FROM gl_pz WHERE gl_pz.khdm = gl_ywfjsb.khdm AND (" & strKmdm & ") AND gl_pz.jd = '借' AND gl_pz.cperiod= ?) WHERE cperiod = ? AND EXISTS (SELECT 1 FROM gl_pz WHERE gl_pz.khdm = gl_ywfjsb.khdm AND (" & strKmdm & ") AND gl_pz.cperiod = ?)"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            If CheckBox3.Checked Then
                Me.LblMsg.Text = "本月发出+发出商品"
                '本月发出+发出商品
                rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET byjf = NVL(byjf,0) + (SELECT COALESCE(SUM(NVL(je,0)+NVL(se,0)),0.0) FROM oe_xsd_fcsp WHERE oe_xsd_fcsp.shkhdm = gl_ywfjsb.khdm AND ckkjqj = ?) WHERE cperiod = ? AND EXISTS (SELECT 1 FROM oe_xsd_fcsp WHERE oe_xsd_fcsp.shkhdm = gl_ywfjsb.khdm AND ckkjqj = ?)"
                rcCmdYwf.Parameters.Clear()
                rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcCmdYwf.ExecuteNonQuery()
            End If
            Me.LblMsg.Text = "本月收款"
            '本月收款
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET bydf = NVL(bydf,0) + (SELECT COALESCE(SUM(je),0.0) FROM gl_pz WHERE gl_pz.khdm = gl_ywfjsb.khdm AND (" & strKmdm & ") AND gl_pz.jd = '贷' AND gl_pz.cperiod= ?) WHERE cperiod = ? AND EXISTS (SELECT 1 FROM gl_pz WHERE gl_pz.khdm = gl_ywfjsb.khdm AND (" & strKmdm & ") AND gl_pz.cperiod = ?)"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "更新1至13个月科目借方发生金额"
            '更新1至13个月借方金额'
            For i = 1 To 13
                rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET jf" & i.ToString.PadLeft(2, "0") & " = NVL(jf" & i.ToString.PadLeft(2, "0") & ",0) + (SELECT COALESCE(SUM(je),0.0) FROM gl_pz WHERE gl_pz.khdm = gl_ywfjsb.khdm AND (" & strKmdm & ") AND gl_pz.jd = '借' AND gl_pz.cperiod= ?) WHERE cperiod = ? AND EXISTS (SELECT 1 FROM gl_pz WHERE gl_pz.khdm = gl_ywfjsb.khdm AND (" & strKmdm & ") AND gl_pz.cperiod = ?)"
                rcCmdYwf.Parameters.Clear()
                rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = IIf(Me.NudMonth.Value - i + 1 <= 0, (Me.NudYear.Value - 1).ToString & (Me.NudMonth.Value - i + 13).ToString.PadLeft(2, "0"), Me.NudYear.Value.ToString & (Me.NudMonth.Value - i + 1).ToString.PadLeft(2, "0"))
                rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = IIf(Me.NudMonth.Value - i + 1 <= 0, (Me.NudYear.Value - 1).ToString & (Me.NudMonth.Value - i + 13).ToString.PadLeft(2, "0"), Me.NudYear.Value.ToString & (Me.NudMonth.Value - i + 1).ToString.PadLeft(2, "0"))
                rcCmdYwf.ExecuteNonQuery()
            Next
            If CheckBox3.Checked Then
                Me.LblMsg.Text = "更新1至13个月发出商品发生金额"
                '更新1至13个月发出商品发生金额'
                For i = 1 To 13
                    rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET jf" & i.ToString.PadLeft(2, "0") & " = NVL(jf" & i.ToString.PadLeft(2, "0") & ",0) + (SELECT COALESCE(SUM(je),0.0) FROM oe_xsd_fcsp WHERE oe_xsd_fcsp.shkhdm = gl_ywfjsb.khdm AND ckkjqj= ?) WHERE cperiod = ? AND EXISTS (SELECT 1 FROM oe_xsd_fcsp WHERE oe_xsd_fcsp.shkhdm = gl_ywfjsb.khdm AND ckkjqj = ?)"
                    rcCmdYwf.Parameters.Clear()
                    rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = IIf(Me.NudMonth.Value - i + 1 <= 0, (Me.NudYear.Value - 1).ToString & (Me.NudMonth.Value - i + 13).ToString.PadLeft(2, "0"), Me.NudYear.Value.ToString & (Me.NudMonth.Value - i + 1).ToString.PadLeft(2, "0"))
                    rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                    rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = IIf(Me.NudMonth.Value - i + 1 <= 0, (Me.NudYear.Value - 1).ToString & (Me.NudMonth.Value - i + 13).ToString.PadLeft(2, "0"), Me.NudYear.Value.ToString & (Me.NudMonth.Value - i + 1).ToString.PadLeft(2, "0"))
                    rcCmdYwf.ExecuteNonQuery()
                Next
            End If
            Me.LblMsg.Text = "更新客户销售分类"
            '更新客户销售分类
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET xslbdm = (SELECT xslbdm FROM rc_khxx WHERE rc_khxx.khdm = gl_ywfjsb.khdm) WHERE cperiod = ? AND xslbdm IS NULL"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "更新业务费标准系数"
            '更新业务费标准系数
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET ywfbl = (SELECT ywfbl FROM rc_khxslb WHERE rc_khxslb.xslbdm = gl_ywfjsb.xslbdm) WHERE cperiod = ? AND (ywfbl IS NULL OR ywfbl = 0)"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "更新汇率差金额到计算表"
            '更新汇率差金额到计算表
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET ywf_hlc = NVL(ywf_hlc,0) + (SELECT NVL(SUM(NVL(gl_pz.je,0) * NVL(ywfbl,0) * NVL(rc_wbxx.ywftzbl,0) / 10000),0) FROM gl_pz,rc_wbxx WHERE gl_pz.bz = rc_wbxx.wbdm AND rc_wbxx.kjnd = ? AND (" & strKmdm & ") AND gl_pz.jd = '贷' AND gl_pz.cperiod = ? AND gl_pz.khdm = gl_ywfjsb.khdm) WHERE cperiod = ?"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "把负数发生额踢掉"
            '把负数发生额踢掉
            For i = 1 To 13
                rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET jf" & i.ToString.PadLeft(2, "0") & " = 0 WHERE cperiod = ? AND jf" & i.ToString.PadLeft(2, "0") & " < 0 "
                rcCmdYwf.Parameters.Clear()
                rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcCmdYwf.ExecuteNonQuery()
            Next
            Me.LblMsg.Text = "根据余额进行分解成各月的发货额"
            '根据余额进行分解成各月的发货额
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET jf00 = 0,jf01 = 0,jf02 = 0,jf03 = 0,jf04 = 0,jf05 = 0,jf06 = 0,jf07 = 0,jf08 = 0,jf09 = 0,jf10 = 0,jf11 = 0,jf12 = 0,jf13 = 0,jf14 = 0  WHERE cperiod = ? AND CASE WHEN NVL(qmye,0) >0 THEN NVL(qmye,0) ELSE 0 END + CASE WHEN NVL(bydf,0) >0 THEN NVL(bydf,0) ELSE 0 END <= 0"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "预收款"
            '预收款
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET jf00 = CASE WHEN NVL(bydf,0) > 0 - NVL(qmye,0) THEN 0 - NVL(qmye,0) ELSE NVL(bydf,0) END WHERE cperiod = ? AND NVL(qmye,0) < 0 OR (qmye = 0 AND bydf < 0)"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            For i = 1 To 13 Step 1
                Me.LblMsg.Text = "期末余额+本月收款>0,上月底余额>=0"
                '期末余额+本月收款>0,上月底余额>=0
                rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET jf" & i.ToString.PadLeft(2, "0") & " = CASE WHEN CASE WHEN NVL(qmye,0) >0 THEN NVL(qmye,0) ELSE 0 END + NVL(bydf,0) > NVL(jf00,0)"
                For j = 1 To i - 1
                    rcCmdYwf.CommandText += "+ NVL(jf" & j.ToString.PadLeft(2, "0") & ",0)"
                Next
                rcCmdYwf.CommandText += " THEN CASE WHEN CASE WHEN NVL(qmye,0) >0 THEN NVL(qmye,0) ELSE 0 END  - NVL(jf00,0) + CASE WHEN NVL(bydf,0) >0 THEN NVL(bydf,0) ELSE 0 END > NVL(jf00,0)"
                For j = 1 To i
                    rcCmdYwf.CommandText += "+ NVL(jf" & j.ToString.PadLeft(2, "0") & ",0)"
                Next
                rcCmdYwf.CommandText += " THEN NVL(jf" & i.ToString.PadLeft(2, "0") & ",0) ELSE CASE WHEN NVL(qmye,0) >0 THEN NVL(qmye,0) ELSE 0 END - NVL(jf00,0) + CASE WHEN NVL(bydf,0) >0 THEN NVL(bydf,0) ELSE 0 END"
                For j = 1 To i - 1
                    rcCmdYwf.CommandText += " - NVL(jf" & j.ToString.PadLeft(2, "0") & ",0)"
                Next
                rcCmdYwf.CommandText += " END ELSE 0.0 END WHERE cperiod = ? AND CASE WHEN NVL(qmye,0) >0 THEN NVL(qmye,0) ELSE 0 END  - NVL(jf00,0) + CASE WHEN NVL(bydf,0) >0 THEN NVL(bydf,0) ELSE 0 END >= 0 AND (qmye > 0 OR bydf > 0)"
                rcCmdYwf.Parameters.Clear()
                rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcCmdYwf.ExecuteNonQuery()
            Next
            'rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET jf01 = bydf  WHERE cperiod = ? AND bydf + qmye <= 0"
            'rcCmdYwf.Parameters.Clear()
            'rcCmdYwf.ExecuteNonQuery()
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET jf01 = CASE WHEN qmye <= jf01 THEN qmye ELSE jf01 END  WHERE cperiod = ? AND qmye > 0"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.ExecuteNonQuery()
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET jf14 = CASE WHEN CASE WHEN NVL(qmye,0) >0 THEN NVL(qmye,0) ELSE 0 END - NVL(jf00,0) + CASE WHEN NVL(bydf,0) >0 THEN NVL(bydf,0) ELSE 0 END > NVL(jf01,0) +NVL(jf02,0) +NVL(jf03,0) +NVL(jf04,0) +NVL(jf05,0) +jf06 +jf07 +jf08 +jf09 +jf10 +jf11 +jf12 +jf13 THEN qmye - NVL(jf00,0) + bydf -jf01 -jf02 -jf03 -jf04 -jf05 -jf06 -jf07 -jf08 -jf09 -jf10 -jf11 -jf12 -jf13 ELSE 0.0 END WHERE cperiod = ? AND CASE WHEN NVL(qmye,0) >0 THEN NVL(qmye,0) ELSE 0 END - NVL(jf00,0) + CASE WHEN NVL(bydf,0) >0 THEN NVL(bydf,0) ELSE 0 END >= 0 AND (qmye > 0 or bydf > 0)"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "根据收款期进行应收借方金额调整"
            '根据收款期进行应收借方金额调整
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET jf14 = jf14 +jf13 +jf12 +jf11 +jf10 +jf09 +jf08,jf13 = 0,jf12 =0,jf11 =0,jf10 =0,jf09 =0,jf08 = 0 WHERE cperiod = ? AND skqx = 0"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET jf14 = jf14 +jf13 +jf12 +jf11 +jf10 +jf09,jf13 = 0,jf12 =0,jf11 =0,jf10 =0,jf09 =0 WHERE cperiod = ? AND skqx = 30"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET jf14 = jf14 +jf13 +jf12 +jf11 +jf10,jf13 = 0,jf12 =0,jf11 =0,jf10 =0 WHERE cperiod = ? AND skqx = 60"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET jf14 = jf14 +jf13 +jf12 +jf11,jf13 = 0,jf12 =0,jf11 =0 WHERE cperiod = ? AND skqx = 90"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET jf14 = jf14 +jf13 +jf12,jf13 = 0,jf12 =0 WHERE cperiod = ? AND skqx = 120"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET jf14 = jf14 +jf13,jf13 = 0 WHERE cperiod = ? AND skqx = 150"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Application.DoEvents()

            Me.LblMsg.Text = "将本月回笼额根据发出额的时间先后顺序分解到各时间段的回笼额中"

            '将本月回笼额根据发出额的时间先后顺序分解到各时间段的回笼额中
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET df14 = (CASE WHEN bydf >= jf14 THEN jf14 ELSE bydf END) WHERE cperiod = ? AND bydf > 0"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            For i = 13 To 1 Step -1
                'update gl_ywfjsb set df13 = case when bydf > df14 THEN case when bydf > jf14+ jf13 then jf13 else bydf - jf14 end else 0 end
                rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET df" & i.ToString.PadLeft(2, "0") & " = CASE WHEN bydf >= "
                For j = 14 To i + 1 Step -1
                    rcCmdYwf.CommandText += IIf(j = 14, "", " +") & "jf" & j.ToString.PadLeft(2, "0")
                Next
                rcCmdYwf.CommandText += " THEN CASE WHEN bydf >"
                For j = 14 To i Step -1
                    rcCmdYwf.CommandText += IIf(j = 14, "", " +") & "jf" & j.ToString.PadLeft(2, "0")
                Next
                rcCmdYwf.CommandText += " THEN jf" & i.ToString.PadLeft(2, "0") & " ELSE bydf"
                For j = 14 To i + 1 Step -1
                    rcCmdYwf.CommandText += " -jf" & j.ToString.PadLeft(2, "0")
                Next
                rcCmdYwf.CommandText += " END ELSE 0.0 END WHERE cperiod = ?"
                rcCmdYwf.Parameters.Clear()
                rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcCmdYwf.ExecuteNonQuery()
            Next
            Me.LblMsg.Text = "根据收款期进行逾期金额调整"
            '根据收款期进行逾期金额调整
            'rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET df14 = df14 +df13 +df12 +df11 +df10 +df09 +df08,df13 = df07,df12 =df06,df11 =df05,df10 =df04,df09 =df03,df08 = df02,df07 =df01,df06 =0,df05 =0,df04 =0,df03 =0,df02 =0,df01 =0 WHERE cperiod = ? AND skqx = 0"
            'rcCmdYwf.Parameters.Clear()
            'rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            'rcCmdYwf.ExecuteNonQuery()
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET df14 = df14 +df13 +df12 +df11 +df10 +df09,df13 = df08,df12 =df07,df11 =df06,df10 =df05,df09 =df04,df08 = df03,df07 =df02,df06 =0,df05 =0,df04 =0,df03 =0,df02 =0 WHERE cperiod = ? AND (skqx = 30 OR skqx = 0)"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET df14 = df14 +df13 +df12 +df11 +df10,df13 = df09,df12 =df08,df11 =df07,df10 =df06,df09 =df05,df08 = df04,df07 =df03,df06 =0,df05 =0,df04 =0,df03 =0 WHERE cperiod = ? AND skqx = 60"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET df14 = df14 +df13 +df12 +df11,df13 = df10,df12 =df09,df11 =df08,df10 =df07,df09 =df06,df08 = df05,df07 =df04,df06 =0,df05 =0,df04 =0 WHERE cperiod = ? AND skqx = 90"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET df14 = df14 +df13 +df12,df13 = df11,df12 =df10,df11 =df09,df10 =df08,df09 =df07,df08 = df06,df07 =df05,df06 =0,df05 =0 WHERE cperiod = ? AND skqx = 120"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET df14 = df14 +df13,df13 = df12,df12 =df11,df11 =df10,df10 =df09,df09 =df08,df08 = df07,df07 =df06,df06 =0 WHERE cperiod = ? AND skqx = 150"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "预收款全部加到30天内"
            '预收款全部加到30天内
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET df01 = df01 + jf00 WHERE cperiod = ?"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()

            Me.LblMsg.Text = "读取业务费倒扣比率前面8行"
            '读取业务费倒扣比率前面8行
            rcCmdYwf.CommandText = "SELECT * FROM gl_ywfdkl WHERE ROWNUM<=8 ORDER BY xh"
            rcCmdYwf.Parameters.Clear()
            rcAdptYwf.SelectCommand = rcCmdYwf
            If rcDataset.Tables("gl_ywfdkl") IsNot Nothing Then
                rcDataset.Tables("gl_ywfdkl").Clear()
            End If
            rcAdptYwf.Fill(rcDataset, "gl_ywfdkl")
            For i = 0 To rcDataset.Tables("gl_ywfdkl").Rows.Count - 1
                rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET dkl" & (i + 7).ToString.PadLeft(2, "0") & " = " & rcDataset.Tables("gl_ywfdkl").Rows(i).Item("dkbl") & " WHERE cperiod = ?"
                rcCmdYwf.Parameters.Clear()
                rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcCmdYwf.ExecuteNonQuery()
            Next
            Me.LblMsg.Text = "计算账龄业务费"
            '计算账龄业务费
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET ywf_zl = ROUND(NVL(df07,0) * NVL(ywfbl,0) * NVL(dkl07,0) + NVL(df08,0) * NVL(ywfbl,0) * NVL(dkl08,0) + NVL(df09,0) * NVL(ywfbl,0) * NVL(dkl09,0) + NVL(df10,0) * NVL(ywfbl,0) * NVL(dkl10,0) + NVL(df11,0) * NVL(ywfbl,0) * NVL(dkl11,0) + NVL(df12,0) * NVL(ywfbl,0) * NVL(dkl12,0) + NVL(df13,0) * NVL(ywfbl,0) * NVL(dkl13,0) + (NVL(jf14,0) - NVL(df14,0)) * NVL(dkl14,0) * 100,-2) / 10000  WHERE cperiod = ?"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "提取收款方式为承兑汇票的金额"
            '提取收款方式为承兑汇票的金额
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET cdhpje = NVL(cdhpje,0) + (SELECT NVL(SUM(JE),0) FROM ar_skd WHERE SUBSTR(djh,5,6)=  ? AND EXISTS (SELECT 1 FROM rc_jsfs WHERE rc_jsfs.bkywf = 1 AND rc_jsfs.jsfsdm = ar_skd.jsfsdm) AND ar_skd.khdm = gl_ywfjsb.khdm) WHERE cperiod = ?"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "提取收款方式为供应链票据的金额"
            '提取收款方式为承兑汇票的金额
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET gylpjje = NVL(gylpjje,0) + (SELECT NVL(SUM(JE),0) FROM ar_skd WHERE SUBSTR(djh,5,6)=  ? AND EXISTS (SELECT 1 FROM rc_jsfs WHERE rc_jsfs.bgylk = 1 AND rc_jsfs.jsfsdm = ar_skd.jsfsdm) AND ar_skd.khdm = gl_ywfjsb.khdm) WHERE cperiod = ?"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "计算承兑汇票倒扣金额"
            '计算承兑汇票倒扣金额
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET ywf_cdhp = ROUND(NVL(gl_ywfjsb.cdhpje,0) * NVL(gl_ywfjsb.ywfbl,0) / 10000 * " & Me.TxtCdhp.Text & ",2) WHERE cperiod = ?"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            '计算供应链票据倒扣金额
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET ywf_gylpj = ROUND(NVL(gl_ywfjsb.gylpjje,0) * NVL(gl_ywfjsb.ywfbl,0) / 10000 * " & Me.TxtCdhp.Text & ",2) WHERE cperiod = ?"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = ""
            '抵扣业务计算
            Me.LblMsg.Text = "更新业务费标准系数"
            '（1）更新业务费标准系数
            rcCmdYwf.CommandText = "UPDATE gl_ywfdkyw SET ywfbl = (SELECT ywfbl FROM rc_khxslb,rc_khxx WHERE rc_khxslb.xslbdm = rc_khxx.xslbdm AND rc_khxx.khdm = gl_ywfdkyw.khdm) WHERE SUBSTR(gl_ywfdkyw.djh,5,6) = ?"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "抵扣业务"
            '抵扣业务
            rcCmdYwf.CommandText = "SELECT gl_ywfdkyw.djh,gl_ywfdkgs.jsgs FROM gl_ywfdkyw,gl_ywfdkgs WHERE gl_ywfdkyw.dkgsdm = gl_ywfdkgs.dkgsdm AND SUBSTR(gl_ywfdkyw.djh,5,6) = ? ORDER BY gl_ywfdkyw.djh"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcAdptYwf.SelectCommand = rcCmdYwf
            If rcDataset.Tables("gl_ywfdkyw") IsNot Nothing Then
                rcDataset.Tables("gl_ywfdkyw").Clear()
            End If
            rcAdptYwf.Fill(rcDataset, "gl_ywfdkyw")
            For i = 0 To rcDataset.Tables("gl_ywfdkyw").Rows.Count - 1
                rcCmdYwf.CommandText = "UPDATE gl_ywfdkyw SET dkje = " & rcDataset.Tables("gl_ywfdkyw").Rows(i).Item("jsgs") & " WHERE djh = ?"
                rcCmdYwf.Parameters.Clear()
                'rcCmdYwf.Parameters.Add("@jsgs", OleDbType.VarChar, 500).Value = rcDataSet.Tables("gl_ywfdkyw").Rows(i).Item("jsgs")
                rcCmdYwf.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataset.Tables("gl_ywfdkyw").Rows(i).Item("djh")
                rcCmdYwf.ExecuteNonQuery()
            Next
            Me.LblMsg.Text = "更新贴息金额到计算表"
            '更新贴息金额到计算表
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET tiexije = (SELECT SUM(NVL(fyje,0)) FROM gl_ywfdkyw WHERE SUBSTR(gl_ywfdkyw.djh,5,6) = ? AND gl_ywfdkyw.dkgsmc LIKE '%贴息%'  AND gl_ywfdkyw.khdm = gl_ywfjsb.khdm) WHERE cperiod = ?"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "更新贴息扣款金额到计算表"
            '更新贴息扣款金额到计算表
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET ywf_tx = (SELECT SUM(NVL(dkje,0)) FROM gl_ywfdkyw WHERE SUBSTR(gl_ywfdkyw.djh,5,6) = ? AND gl_ywfdkyw.dkgsmc LIKE '%贴息%' AND gl_ywfdkyw.khdm = gl_ywfjsb.khdm) WHERE cperiod = ?"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "更新佣金金额到计算表"
            '更新佣金金额到计算表
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET (skje_yj,yongjinje) = (SELECT SUM(NVL(skje,0)),SUM(NVL(fyje,0)) FROM gl_ywfdkyw WHERE SUBSTR(gl_ywfdkyw.djh,5,6) = ? AND gl_ywfdkyw.dkgsmc LIKE '%佣金%'  AND gl_ywfdkyw.khdm = gl_ywfjsb.khdm) WHERE cperiod = ?"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "更新佣金扣款金额到计算表"
            '更新佣金扣款金额到计算表
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET ywf_yj = (SELECT SUM(NVL(dkje,0)) FROM gl_ywfdkyw WHERE SUBSTR(gl_ywfdkyw.djh,5,6) = ? AND gl_ywfdkyw.dkgsmc LIKE '%佣金%' AND gl_ywfdkyw.khdm = gl_ywfjsb.khdm) WHERE cperiod = ?"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "计算新客户提升比例"
            '计算新客户提升比例
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET newkhbl =  0 WHERE cperiod = ?"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET newkhbl =  NVL(" & Me.TxtNewKh.Text & ",0)  WHERE cperiod = ? AND EXISTS (SELECT 1 FROM rc_khxx WHERE (rc_khxx.djyear = " & Me.NudYear.Value & " OR  rc_khxx.djyear = " & Me.NudYear.Value - 1 & ") AND rc_khxx.khdm = gl_ywfjsb.khdm)"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET newkhbl =  0 - NVL(" & Me.TxtOldKh.Text & ",0)  WHERE cperiod = ? AND NOT EXISTS (SELECT 1 FROM rc_khxx WHERE (rc_khxx.djyear = " & Me.NudYear.Value & " OR  rc_khxx.djyear = " & Me.NudYear.Value - 1 & ") AND rc_khxx.khdm = gl_ywfjsb.khdm)"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "计算新客户提升业务费"
            '计算新客户提升业务费
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET ywf_newkh = ROUND((NVL(bydf,0) - NVL(yongjinje,0) - NVL(tiexije,0)) * NVL(ywfbl,0) * NVL(newkhbl,0) / 10000,2)  WHERE cperiod = ?"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "计算标准业务费"
            '计算标准业务费
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET ywf_bz = ROUND((NVL(bydf,0) - NVL(yongjinje,0) - NVL(tiexije,0)) * NVL(ywfbl,0) / 100,2)  WHERE cperiod = ?"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "更新呆账金额到计算表"
            '更新呆账金额到计算表
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET daizhang = (SELECT SUM(NVL(skje,0)) FROM gl_ywfdkyw WHERE SUBSTR(gl_ywfdkyw.djh,5,6) = ? AND gl_ywfdkyw.dkgsmc LIKE '%呆账%'  AND gl_ywfdkyw.khdm = gl_ywfjsb.khdm) WHERE cperiod = ?"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "更新呆账扣款金额到计算表"
            '更新呆账扣款金额到计算表
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET ywf_dz = (SELECT SUM(NVL(dkje,0)) FROM gl_ywfdkyw WHERE SUBSTR(gl_ywfdkyw.djh,5,6) = ? AND gl_ywfdkyw.dkgsmc LIKE '%呆账%' AND gl_ywfdkyw.khdm = gl_ywfjsb.khdm) WHERE cperiod = ?"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "更新诉讼金额到计算表"
            '更新诉讼金额到计算表
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET susong = (SELECT SUM(NVL(skje,0)) FROM gl_ywfdkyw WHERE SUBSTR(gl_ywfdkyw.djh,5,6) = ? AND gl_ywfdkyw.dkgsmc LIKE '%诉讼%'  AND gl_ywfdkyw.khdm = gl_ywfjsb.khdm) WHERE cperiod = ?"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "更新诉讼扣款金额到计算表"
            '更新诉讼扣款金额到计算表
            rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET ywf_ss = (SELECT SUM(NVL(dkje,0)) FROM gl_ywfdkyw WHERE SUBSTR(gl_ywfdkyw.djh,5,6) = ? AND gl_ywfdkyw.dkgsmc LIKE '%诉讼%' AND gl_ywfdkyw.khdm = gl_ywfjsb.khdm) WHERE cperiod = ?"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcCmdYwf.ExecuteNonQuery()
            Me.LblMsg.Text = "更新汇率差金额*结算系数到计算表"
            ''更新汇率差金额*结算系数到计算表
            'rcCmdYwf.CommandText = "UPDATE gl_ywfjsb SET ywf_hlc = NVL(ywf_hlc,0) * NVL(ywfbl,0) WHERE cperiod = ?"
            'rcCmdYwf.Parameters.Clear()
            'rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            'rcCmdYwf.ExecuteNonQuery()

            Me.LblMsg.Text = "读取数据"
            '读取数据
            rcCmdYwf.CommandText = "SELECT '" & strDwdm & "' AS dwdm,'" & strDwmc & "' AS dwmc,gl_ywfjsb.khdm,gl_ywfjsb.khmc,gl_ywfjsb.zydm,gl_ywfjsb.zymc,gl_ywfjsb.xslbdm,gl_ywfjsb.ywfbl,gl_ywfjsb.newkhbl,gl_ywfjsb.skqx,gl_ywfjsb.byjf,gl_ywfjsb.bydf,gl_ywfjsb.qmye,gl_ywfjsb.jf00,gl_ywfjsb.jf01,gl_ywfjsb.jf02,gl_ywfjsb.jf03,gl_ywfjsb.jf04,gl_ywfjsb.jf05,gl_ywfjsb.jf06,gl_ywfjsb.jf07,gl_ywfjsb.jf08,gl_ywfjsb.jf09,gl_ywfjsb.jf10,gl_ywfjsb.jf11,gl_ywfjsb.jf12,gl_ywfjsb.jf13,gl_ywfjsb.jf14,gl_ywfjsb.df01,gl_ywfjsb.df02,gl_ywfjsb.df03,gl_ywfjsb.df04,gl_ywfjsb.df05,gl_ywfjsb.df06,gl_ywfjsb.df07,gl_ywfjsb.df08,gl_ywfjsb.df09,gl_ywfjsb.df10,gl_ywfjsb.df11,gl_ywfjsb.df12,gl_ywfjsb.df13,gl_ywfjsb.df14,gl_ywfjsb.ywf_bz,gl_ywfjsb.ywf_newkh,0 - gl_ywfjsb.ywf_zl AS ywf_zl,gl_ywfjsb.cdhpje,0 - gl_ywfjsb.ywf_cdhp AS ywf_cdhp,gl_ywfjsb.gylpjje,0 - gl_ywfjsb.ywf_gylpj AS ywf_gylpj,gl_ywfjsb.tiexije, 0 - gl_ywfjsb.ywf_tx AS ywf_tx,gl_ywfjsb.skje_yj,gl_ywfjsb.yongjinje,0 - gl_ywfjsb.ywf_yj AS ywf_yj,gl_ywfjsb.daizhang,0 - gl_ywfjsb.ywf_dz AS ywf_dz,gl_ywfjsb.susong,0 - gl_ywfjsb.ywf_ss AS ywf_ss,gl_ywfjsb.ywf_hlc,NVL(gl_ywfjsb.ywf_bz,0) + NVL(gl_ywfjsb.ywf_newkh,0) - NVL(gl_ywfjsb.ywf_zl,0) - NVL(gl_ywfjsb.ywf_cdhp,0) - NVL(gl_ywfjsb.ywf_gylpj , 0) - NVL(gl_ywfjsb.ywf_tx,0) - NVL(gl_ywfjsb.ywf_yj,0) - NVL(gl_ywfjsb.ywf_dz,0) - NVL(gl_ywfjsb.ywf_ss,0) + NVL(gl_ywfjsb.ywf_hlc,0) AS ywf_hj FROM gl_ywfjsb WHERE cperiod = ? ORDER BY dwdm,gl_ywfjsb.khdm"
            rcCmdYwf.Parameters.Clear()
            rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcAdptYwf.SelectCommand = rcCmdYwf
            rcAdptYwf.Fill(rcDataset, "gl_ywfjsb")
            'rcCmdYwf.CommandText = "SELECT '' AS khdm,'小计' AS khmc,gl_ywfjsba.zydm,gl_ywfjsba.zymc,SUM(byjf) AS byjf,SUM(bydf) AS bydf,SUM(qmye) AS qmye,SUM(jf01) AS jf01,SUM(jf02) AS jf02,SUM(jf03) AS jf03,SUM(jf04) AS jf04,SUM(jf05) AS jf05,SUM(jf06) AS jf06,SUM(jf07) AS jf07,SUM(jf08) AS jf08,SUM(jf09) AS jf09,SUM(jf10) AS jf10,SUM(jf11) AS jf11,SUM(jf12) AS jf12,SUM(jf13) AS jf13,SUM(jf14) AS jf14,SUM(df01) AS df01,SUM(df02) AS df02,SUM(df03) AS df03,SUM(df04) AS df04,SUM(df05) AS df05,SUM(df06) AS df06,SUM(df07) AS df07,SUM(df08) AS df08,SUM(df09) AS df09,SUM(df10) AS df10,SUM(df11) AS df11,SUM(df12) AS df12,SUM(df13) AS df13,SUM(df14) AS df14 FROM (SELECT gl_ywfjsb.khdm,rc_khxx.khmc,rc_khxx.zydm,rc_zyxx.zymc,gl_ywfjsb.skqx,gl_ywfjsb.byjf,gl_ywfjsb.bydf,gl_ywfjsb.qmye,gl_ywfjsb.jf01,gl_ywfjsb.jf02,gl_ywfjsb.jf03,gl_ywfjsb.jf04,gl_ywfjsb.jf05,gl_ywfjsb.jf06,gl_ywfjsb.jf07,gl_ywfjsb.jf08,gl_ywfjsb.jf09,gl_ywfjsb.jf10,gl_ywfjsb.jf11,gl_ywfjsb.jf12,gl_ywfjsb.jf13,gl_ywfjsb.jf14,gl_ywfjsb.df01,gl_ywfjsb.df02,gl_ywfjsb.df03,gl_ywfjsb.df04,gl_ywfjsb.df05,gl_ywfjsb.df06,gl_ywfjsb.df07,gl_ywfjsb.df08,gl_ywfjsb.df09,gl_ywfjsb.df10,gl_ywfjsb.df11,gl_ywfjsb.df12,gl_ywfjsb.df13,gl_ywfjsb.df14 FROM gl_ywfjsb LEFT JOIN rc_khxx ON rc_khxx.khdm = gl_ywfjsb.khdm LEFT JOIN rc_zyxx ON rc_zyxx.zydm = rc_khxx.zydm WHERE cperiod = ?) gl_ywfjsba GROUP BY gl_ywfjsba.zydm,gl_ywfjsba.zymc"
            'rcCmdYwf.Parameters.Clear()
            'rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            'rcAdptYwf.SelectCommand = rcCmdYwf
            'rcAdptYwf.Fill(rcDataSet, "gl_ywfjsb")
            'rcCmdYwf.CommandText = "SELECT '' AS khdm,'合计' AS khmc,'' AS zydm,'' AS zymc,SUM(byjf) AS byjf,SUM(bydf) AS bydf,SUM(qmye) AS qmye,SUM(jf01) AS jf01,SUM(jf02) AS jf02,SUM(jf03) AS jf03,SUM(jf04) AS jf04,SUM(jf05) AS jf05,SUM(jf06) AS jf06,SUM(jf07) AS jf07,SUM(jf08) AS jf08,SUM(jf09) AS jf09,SUM(jf10) AS jf10,SUM(jf11) AS jf11,SUM(jf12) AS jf12,SUM(jf13) AS jf13,SUM(jf14) AS jf14,SUM(df01) AS df01,SUM(df02) AS df02,SUM(df03) AS df03,SUM(df04) AS df04,SUM(df05) AS df05,SUM(df06) AS df06,SUM(df07) AS df07,SUM(df08) AS df08,SUM(df09) AS df09,SUM(df10) AS df10,SUM(df11) AS df11,SUM(df12) AS df12,SUM(df13) AS df13,SUM(df14) AS df14 FROM (SELECT gl_ywfjsb.khdm,rc_khxx.khmc,rc_khxx.zydm,rc_zyxx.zymc,gl_ywfjsb.skqx,gl_ywfjsb.byjf,gl_ywfjsb.bydf,gl_ywfjsb.qmye,gl_ywfjsb.jf01,gl_ywfjsb.jf02,gl_ywfjsb.jf03,gl_ywfjsb.jf04,gl_ywfjsb.jf05,gl_ywfjsb.jf06,gl_ywfjsb.jf07,gl_ywfjsb.jf08,gl_ywfjsb.jf09,gl_ywfjsb.jf10,gl_ywfjsb.jf11,gl_ywfjsb.jf12,gl_ywfjsb.jf13,gl_ywfjsb.jf14,gl_ywfjsb.df01,gl_ywfjsb.df02,gl_ywfjsb.df03,gl_ywfjsb.df04,gl_ywfjsb.df05,gl_ywfjsb.df06,gl_ywfjsb.df07,gl_ywfjsb.df08,gl_ywfjsb.df09,gl_ywfjsb.df10,gl_ywfjsb.df11,gl_ywfjsb.df12,gl_ywfjsb.df13,gl_ywfjsb.df14 FROM gl_ywfjsb LEFT JOIN rc_khxx ON rc_khxx.khdm = gl_ywfjsb.khdm LEFT JOIN rc_zyxx ON rc_zyxx.zydm = rc_khxx.zydm WHERE cperiod = ?) gl_ywfjsba"
            'rcCmdYwf.Parameters.Clear()
            'rcCmdYwf.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            'rcAdptYwf.SelectCommand = rcCmdYwf
            'rcAdptYwf.Fill(rcDataSet, "gl_ywfjsb")
            rcTransYwf.Commit()
        Catch ex As Exception
            If rcTransYwf IsNot Nothing Then
                Try
                    rcTransYwf.Rollback()
                Catch
                End Try
            End If
            MsgBox("计算账套" & strDwdm & "业务费失败。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            If rcConnYwf.State = ConnectionState.Open Then
                rcConnYwf.Close()
            End If
        End Try

    End Sub

    '把主账套的业务费规则同步到目标账套，源用主账套连接串，目标命令由调用方传入
    Private Sub SyncYwfRuleFromMain(ByVal strTargetDwdm As String, ByVal strMainConnString As String, ByVal rcCmdTarget As OleDbCommand)
        Dim rcConnMain As New OleDbConnection
        Dim rcCmdMain As OleDbCommand
        Dim rcDataAdptMain As New OleDbDataAdapter
        Dim dtPara As New DataTable
        Dim dtDkgs As New DataTable
        Dim dtDkl As New DataTable
        Dim i As Integer
        Try
            rcConnMain.ConnectionString = strMainConnString
            rcConnMain.Open()
            rcCmdMain = rcConnMain.CreateCommand()
            rcCmdMain.CommandTimeout = 300
            rcCmdMain.CommandType = CommandType.Text
            '业务费比例参数
            rcCmdMain.CommandText = "SELECT paraid,parastrvalue,paradblvalue FROM rc_para WHERE dwdm = ? AND paraid IN ('业务费新客户上升比例','业务费老客户下降比例','承兑汇票回笼下降比例')"
            rcCmdMain.Parameters.Clear()
            rcCmdMain.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcDataAdptMain.SelectCommand = rcCmdMain
            rcDataAdptMain.Fill(dtPara)
            '垫扣结算公司规则
            rcCmdMain.CommandText = "SELECT dkgsdm,dkgsmc,dkgssm,jsgs FROM gl_ywfdkgs"
            rcCmdMain.Parameters.Clear()
            rcDataAdptMain.SelectCommand = rcCmdMain
            rcDataAdptMain.Fill(dtDkgs)
            '垫扣率规则
            rcCmdMain.CommandText = "SELECT xh,mc,dkbl FROM gl_ywfdkl ORDER BY xh"
            rcCmdMain.Parameters.Clear()
            rcDataAdptMain.SelectCommand = rcCmdMain
            rcDataAdptMain.Fill(dtDkl)
            rcConnMain.Close()
            '写规则到目标账套，目标连接已由调用方打开
            rcCmdTarget.Transaction = Nothing
            rcCmdTarget.CommandTimeout = 300
            rcCmdTarget.CommandType = CommandType.Text
            For i = 0 To dtPara.Rows.Count - 1
                Dim strParId As String = "" & dtPara.Rows(i).Item("paraid")
                rcCmdTarget.CommandText = "DELETE FROM rc_para WHERE paraid = ? AND dwdm = ?"
                rcCmdTarget.Parameters.Clear()
                rcCmdTarget.Parameters.Add("@paraid", OleDbType.VarChar, 30).Value = strParId
                rcCmdTarget.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = strTargetDwdm
                rcCmdTarget.ExecuteNonQuery()
                rcCmdTarget.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,?,'',?)"
                rcCmdTarget.Parameters.Clear()
                rcCmdTarget.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = strTargetDwdm
                rcCmdTarget.Parameters.Add("@paraid", OleDbType.VarChar, 30).Value = strParId
                If dtPara.Rows(i).Item("paradblvalue") Is DBNull.Value Then
                    rcCmdTarget.Parameters.Add("@paraStrValue", OleDbType.VarNumeric, 14).Value = 0
                Else
                    rcCmdTarget.Parameters.Add("@paraStrValue", OleDbType.VarNumeric, 14).Value = dtPara.Rows(i).Item("paradblvalue")
                End If
                rcCmdTarget.ExecuteNonQuery()
            Next
            rcCmdTarget.CommandText = "DELETE FROM gl_ywfdkgs"
            rcCmdTarget.Parameters.Clear()
            rcCmdTarget.ExecuteNonQuery()
            For i = 0 To dtDkgs.Rows.Count - 1
                rcCmdTarget.CommandText = "INSERT INTO gl_ywfdkgs (dkgsdm,dkgsmc,dkgssm,jsgs) VALUES (?,?,?,?)"
                rcCmdTarget.Parameters.Clear()
                rcCmdTarget.Parameters.Add("@dkgsdm", OleDbType.VarChar, 12).Value = IIf(dtDkgs.Rows(i).Item("dkgsdm") Is DBNull.Value, "", dtDkgs.Rows(i).Item("dkgsdm"))
                rcCmdTarget.Parameters.Add("@dkgsmc", OleDbType.VarChar, 60).Value = IIf(dtDkgs.Rows(i).Item("dkgsmc") Is DBNull.Value, "", dtDkgs.Rows(i).Item("dkgsmc"))
                rcCmdTarget.Parameters.Add("@dkgssm", OleDbType.VarChar, 60).Value = IIf(dtDkgs.Rows(i).Item("dkgssm") Is DBNull.Value, "", dtDkgs.Rows(i).Item("dkgssm"))
                rcCmdTarget.Parameters.Add("@jsgs", OleDbType.VarChar, 12).Value = IIf(dtDkgs.Rows(i).Item("jsgs") Is DBNull.Value, "", dtDkgs.Rows(i).Item("jsgs"))
                rcCmdTarget.ExecuteNonQuery()
            Next
            rcCmdTarget.CommandText = "DELETE FROM gl_ywfdkl"
            rcCmdTarget.Parameters.Clear()
            rcCmdTarget.ExecuteNonQuery()
            For i = 0 To dtDkl.Rows.Count - 1
                rcCmdTarget.CommandText = "INSERT INTO gl_ywfdkl (xh,mc,dkbl) VALUES (?,?,?)"
                rcCmdTarget.Parameters.Clear()
                rcCmdTarget.Parameters.Add("@xh", OleDbType.VarNumeric, 14).Value = IIf(dtDkl.Rows(i).Item("xh") Is DBNull.Value, 0, dtDkl.Rows(i).Item("xh"))
                rcCmdTarget.Parameters.Add("@mc", OleDbType.VarChar, 60).Value = IIf(dtDkl.Rows(i).Item("mc") Is DBNull.Value, "", dtDkl.Rows(i).Item("mc"))
                rcCmdTarget.Parameters.Add("@dkbl", OleDbType.VarNumeric, 14).Value = IIf(dtDkl.Rows(i).Item("dkbl") Is DBNull.Value, 0, dtDkl.Rows(i).Item("dkbl"))
                rcCmdTarget.ExecuteNonQuery()
            Next
        Catch ex As Exception
            '目标连接由调用方负责关闭
            MsgBox("同步业务费规则到账套" & strTargetDwdm & "失败。" & Chr(13) & ex.Message)
        Finally
            Try
                If rcConnMain.State = ConnectionState.Open Then
                    rcConnMain.Close()
                End If
            Catch ex As Exception
            End Try
        End Try

    End Sub
End Class