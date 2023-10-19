Imports System.Data.OleDb

Public Class FrmImpNC
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '数据更新传递
    Dim rcOleDbTrans As OleDbTransaction
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Private Sub FrmImpNC_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If g_User_Account = "ADMIN" Then
            Me.BtnWrite.Enabled = True
        End If
        '默认值
        Dim strDwKjqj As String = GetInvKjqj(g_Dwrq)
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT ny,jzbz,invbegin,invend FROM rc_yj WHERE jzbz = 0 AND ny >= ? ORDER BY ny"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = strDwKjqj
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_yj") IsNot Nothing Then
                rcDataset.Tables("rc_yj").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_yj")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_yj").Rows.Count = 0 Then
            MsgBox("会计期间设置有错误，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        '默认值
        NudYear.Value = Mid(rcDataset.Tables("rc_yj").Rows(0).Item("ny"), 1, 4)
        NudMonth.Value = Mid(rcDataset.Tables("rc_yj").Rows(0).Item("ny"), 5, 2)
        '取收款单据表体售达方属性序号
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT paraid,parastrvalue,paradblvalue FROM rc_para WHERE paraId = '收款单据表体售达方属性序号'"
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
                Me.ComboBox1.SelectedItem = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
            Else
                Me.ComboBox1.SelectedItem = 1
            End If
        Else
            Me.ComboBox1.SelectedItem = 1
        End If
        '取收款期属性序号
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT paraid,parastrvalue,paradblvalue FROM rc_para WHERE paraId = '收款期属性序号'"
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
                Me.ComboBox2.SelectedItem = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
            Else
                Me.ComboBox2.SelectedItem = 1
            End If
        Else
            Me.ComboBox2.SelectedItem = 1
        End If

    End Sub

#Region "仓库编码的事件"

    Private Sub TxtCkdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCkdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_ckxx"
                    .paraField1 = "ckdm"
                    .paraField2 = "ckmc"
                    .paraField3 = "cksm"
                    .paraTitle = "仓库"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtCkdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtCkdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCkdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtCkdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_ckxx WHERE (ckdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(TxtCkdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_ckxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_ckxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_ckxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_ckxx").Rows.Count > 0 Then
                Me.TxtCkdm.Text = Trim(rcDataset.Tables("rc_ckxx").Rows(0).Item("ckdm"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If MsgBox("确定要读取NC的数据吗？", MsgBoxStyle.YesNo, "提示信息") = MsgBoxResult.No Then
            Return
        End If
        Dim NCAccountingBook As String = ""
        Dim NCOleDbConn As New OleDbConnection
        Dim i As Integer
        Dim j As Integer
        Dim dateBegin As DateTime
        Dim dateEnd As DateTime
        dateBegin = GetInvBegin(Me.NudYear.Value, Me.NudMonth.Value)
        dateEnd = GetInvEnd(Me.NudYear.Value, Me.NudMonth.Value)
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_para Where dwdm = ? And (paraid = 'NCACCOUNTINGBOOK' or paraid = 'NCHOST' or paraid = 'NCSERVICE_NAME' or paraid = 'NCUser_ID' or paraid = 'NCPASSWORD') ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
        Catch ex As Exception
            MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_para").Rows.Count = 5 Then
            If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                NCAccountingBook = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
            End If
            'Orcal 9.i
            NCOleDbConn.ConnectionString = "Provider=OraOLEDB.Oracle.1;Persist Security Info=False;Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = " & rcDataset.Tables("rc_para").Rows(1).Item("parastrvalue") & ")(PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = " & rcDataset.Tables("rc_para").Rows(3).Item("parastrvalue") & ")));User ID=" & rcDataset.Tables("rc_para").Rows(4).Item("parastrvalue") & ";Password=" & rcDataset.Tables("rc_para").Rows(2).Item("parastrvalue") ' &";Pooling = false" 'Integrated Security=SSPI;
        Else
            MsgBox("请定义用友NC数据源信息。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        If Me.ChbPz.Checked Then
            Try
                NCOleDbConn.Open()
                rcOleDbCommand.Connection = NCOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT gl_pza.*,'~' AS bmdm,'~' AS bmmc,'~' AS zydm,'~' AS zymc,'~' AS xmdm,'~' AS xmmc,'~' AS khdm,'~' AS khmc,'~' AS csdm,'~' AS csmc,'~' AS yhzh,'~' AS jxzh" &
                    ",CASE WHEN gl_freevalue.typevalue1 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue1,1,20) ELSE '~' END AS type1,CASE WHEN gl_freevalue.typevalue1 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue1,21,20) ELSE '~' END AS value1" &
                    ",CASE WHEN gl_freevalue.typevalue2 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue2,1,20) ELSE '~' END AS type2,CASE WHEN gl_freevalue.typevalue2 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue2,21,20) ELSE '~' END AS value2" &
                    ",CASE WHEN gl_freevalue.typevalue3 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue3,1,20) ELSE '~' END AS type3,CASE WHEN gl_freevalue.typevalue3 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue3,21,20) ELSE '~' END AS value3" &
                    ",CASE WHEN gl_freevalue.typevalue4 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue4,1,20) ELSE '~' END AS type4,CASE WHEN gl_freevalue.typevalue4 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue4,21,20) ELSE '~' END AS value4" &
                    ",CASE WHEN gl_freevalue.typevalue5 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue5,1,20) ELSE '~' END AS type5,CASE WHEN gl_freevalue.typevalue5 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue5,21,20) ELSE '~' END AS value5" &
                    ",CASE WHEN gl_freevalue.typevalue6 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue6,1,20) ELSE '~' END AS type6,CASE WHEN gl_freevalue.typevalue6 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue6,21,20) ELSE '~' END AS value6" &
                    ",CASE WHEN gl_freevalue.typevalue7 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue7,1,20) ELSE '~' END AS type7,CASE WHEN gl_freevalue.typevalue7 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue7,21,20) ELSE '~' END AS value7" &
                    ",CASE WHEN gl_freevalue.typevalue8 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue8,1,20) ELSE '~' END AS type8,CASE WHEN gl_freevalue.typevalue8 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue8,21,20) ELSE '~' END AS value8" &
                    ",CASE WHEN gl_freevalue.typevalue9 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue9,1,20) ELSE '~' END AS type9,CASE WHEN gl_freevalue.typevalue9 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue9,21,20) ELSE '~' END AS value9 FROM" &
                    " (SELECT gl_voucher.year,gl_voucher.period,gl_voucher.prepareddate AS pzrq,bd_vouchertype.code AS pzlxdm,bd_vouchertype.name AS pzlxjc,gl_voucher.num AS pzh,gl_voucher.attachment AS fjzs,gl_detail.detailindex AS xh,gl_detail.explanation AS zy,bd_account.code AS kmdm,bd_accasoa.name AS kmmc,gl_detail.oppositesubj AS dfkm,gl_detail.assid,bd_currtype.code AS wbdm,bd_currtype.name AS wbmc,gl_detail.debitamount jfwb,gl_detail.debitquantity jfsl,gl_detail.localdebitamount AS jfje,gl_detail.creditamount AS dfwb,gl_detail.creditquantity AS dfsl,gl_detail.localcreditamount AS dfje FROM gl_detail,gl_voucher,bd_accasoa,bd_account,bd_currtype,bd_vouchertype,org_accountingbook WHERE gl_detail.pk_voucher = gl_voucher.pk_voucher AND gl_detail.dr = 0 AND bd_accasoa.pk_accasoa = gl_detail.pk_accasoa AND bd_accasoa.pk_account = bd_account.pk_account AND bd_currtype.pk_currtype = gl_detail.pk_currtype AND bd_vouchertype.pk_vouchertype = gl_voucher.pk_vouchertype AND gl_voucher.pk_accountingbook = org_accountingbook.pk_accountingbook AND gl_voucher.period = ? AND gl_voucher.year = ? AND org_accountingbook.code = ?) gl_pza LEFT JOIN gl_freevalue ON gl_freevalue.freevalueid = gl_pza.assid"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@period", OleDbType.VarChar, 2).Value = Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@year", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                rcOleDbCommand.Parameters.Add("@NCAccountingBook", OleDbType.VarChar, 40).Value = NCAccountingBook
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("gl_pz") IsNot Nothing Then
                    Me.rcDataset.Tables("gl_pz").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "gl_pz")
                Me.ProgressBar1.Maximum = rcDataset.Tables("gl_pz").Rows.Count
                For i = 0 To rcDataset.Tables("gl_pz").Rows.Count - 1
                    Me.ProgressBar1.Value = i + 1
                    '辅助核算转换
                    For j = 1 To 8
                        If rcDataset.Tables("gl_pz").Rows(i).Item("type" & j.ToString) <> "~" Then
                            rcOleDbCommand.CommandText = "SELECT code,name FROM bd_accassitem WHERE pk_accassitem = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@pk_accassitem", OleDbType.VarChar, 20).Value = rcDataset.Tables("gl_pz").Rows(i).Item("type" & j.ToString)
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("bd_accassitem") IsNot Nothing Then
                                Me.rcDataset.Tables("bd_accassitem").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "bd_accassitem")
                            If rcDataset.Tables("bd_accassitem").Rows.Count > 0 Then
                                rcDataset.Tables("gl_pz").Rows(i).Item("type" & j.ToString) = rcDataset.Tables("bd_accassitem").Rows(0).Item("name")
                                Select Case rcDataset.Tables("bd_accassitem").Rows(0).Item("name")
                                    Case "部门" '0001
                                        rcOleDbCommand.CommandText = "SELECT code,name FROM org_orgs WHERE pk_org = ?"
                                        rcOleDbCommand.Parameters.Clear()
                                        rcOleDbCommand.Parameters.Add("@pk_org", OleDbType.VarChar, 20).Value = rcDataset.Tables("gl_pz").Rows(i).Item("value" & j.ToString)
                                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                        If rcDataset.Tables("org_orgs") IsNot Nothing Then
                                            rcDataset.Tables("org_orgs").Clear()
                                        End If
                                        rcOleDbDataAdpt.Fill(rcDataset, "org_orgs")
                                        If rcDataset.Tables("org_orgs").Rows.Count > 0 Then
                                            rcDataset.Tables("gl_pz").Rows(i).Item("bmdm") = rcDataset.Tables("org_orgs").Rows(0).Item("code")
                                            rcDataset.Tables("gl_pz").Rows(i).Item("bmmc") = rcDataset.Tables("org_orgs").Rows(0).Item("name")
                                        End If
                                    Case "人员档案"
                                        rcOleDbCommand.CommandText = "SELECT code,name FROM bd_psndoc WHERE pk_psndoc = ?"
                                        rcOleDbCommand.Parameters.Clear()
                                        rcOleDbCommand.Parameters.Add("@pk_psndoc", OleDbType.VarChar, 20).Value = rcDataset.Tables("gl_pz").Rows(i).Item("value" & j.ToString)
                                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                        If rcDataset.Tables("bd_psndoc") IsNot Nothing Then
                                            rcDataset.Tables("bd_psndoc").Clear()
                                        End If
                                        rcOleDbDataAdpt.Fill(rcDataset, "bd_psndoc")
                                        If rcDataset.Tables("bd_psndoc").Rows.Count > 0 Then
                                            rcDataset.Tables("gl_pz").Rows(i).Item("zydm") = rcDataset.Tables("bd_psndoc").Rows(0).Item("code")
                                            rcDataset.Tables("gl_pz").Rows(i).Item("zymc") = rcDataset.Tables("bd_psndoc").Rows(0).Item("name")
                                        End If
                                    Case "客商"
                                        rcOleDbCommand.CommandText = "SELECT code,name,pk_custclass,pk_supplierclass FROM bd_cust_supplier WHERE pk_cust_sup = ?"
                                        rcOleDbCommand.Parameters.Clear()
                                        rcOleDbCommand.Parameters.Add("@pk_cust_sup", OleDbType.VarChar, 20).Value = rcDataset.Tables("gl_pz").Rows(i).Item("value" & j.ToString)
                                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                        If rcDataset.Tables("bd_cust_supplier") IsNot Nothing Then
                                            rcDataset.Tables("bd_cust_supplier").Clear()
                                        End If
                                        rcOleDbDataAdpt.Fill(rcDataset, "bd_cust_supplier")
                                        If rcDataset.Tables("bd_cust_supplier").Rows.Count > 0 Then
                                            If Mid(rcDataset.Tables("gl_pz").Rows(i).Item("kmdm"), 1, 4) = "2202" Then
                                                '科目编码是2开头，设为供应商
                                                rcDataset.Tables("gl_pz").Rows(i).Item("csdm") = rcDataset.Tables("bd_cust_supplier").Rows(0).Item("code")
                                                rcDataset.Tables("gl_pz").Rows(i).Item("csmc") = rcDataset.Tables("bd_cust_supplier").Rows(0).Item("name")
                                            Else
                                                '其他为客户
                                                rcDataset.Tables("gl_pz").Rows(i).Item("khdm") = rcDataset.Tables("bd_cust_supplier").Rows(0).Item("code")
                                                rcDataset.Tables("gl_pz").Rows(i).Item("khmc") = rcDataset.Tables("bd_cust_supplier").Rows(0).Item("name")
                                            End If
                                        End If
                                    Case "客户档案"
                                        rcOleDbCommand.CommandText = "SELECT code,name FROM bd_customer WHERE pk_customer = ?"
                                        rcOleDbCommand.Parameters.Clear()
                                        rcOleDbCommand.Parameters.Add("@pk_customer", OleDbType.VarChar, 20).Value = rcDataset.Tables("gl_pz").Rows(i).Item("value" & j.ToString)
                                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                        If rcDataset.Tables("bd_customer") IsNot Nothing Then
                                            rcDataset.Tables("bd_customer").Clear()
                                        End If
                                        rcOleDbDataAdpt.Fill(rcDataset, "bd_customer")
                                        If rcDataset.Tables("bd_customer").Rows.Count > 0 Then
                                            rcDataset.Tables("gl_pz").Rows(i).Item("khdm") = rcDataset.Tables("bd_customer").Rows(0).Item("code")
                                            rcDataset.Tables("gl_pz").Rows(i).Item("khmc") = rcDataset.Tables("bd_customer").Rows(0).Item("name")
                                        End If
                                    Case "供应商档案"
                                        rcOleDbCommand.CommandText = "SELECT code,name FROM bd_supplier WHERE pk_supplier = ?"
                                        rcOleDbCommand.Parameters.Clear()
                                        rcOleDbCommand.Parameters.Add("@pk_supplier", OleDbType.VarChar, 20).Value = rcDataset.Tables("gl_pz").Rows(i).Item("value" & j.ToString)
                                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                        If rcDataset.Tables("bd_supplier") IsNot Nothing Then
                                            rcDataset.Tables("bd_supplier").Clear()
                                        End If
                                        rcOleDbDataAdpt.Fill(rcDataset, "bd_supplier")
                                        If rcDataset.Tables("bd_supplier").Rows.Count > 0 Then
                                            rcDataset.Tables("gl_pz").Rows(i).Item("csdm") = rcDataset.Tables("bd_supplier").Rows(0).Item("code")
                                            rcDataset.Tables("gl_pz").Rows(i).Item("csmc") = rcDataset.Tables("bd_supplier").Rows(0).Item("name")
                                        End If
                                    Case "银行账户"
                                        rcOleDbCommand.CommandText = "SELECT accnum,accname FROM bd_bankaccbas WHERE pk_bankaccbas = ?"
                                        rcOleDbCommand.Parameters.Clear()
                                        rcOleDbCommand.Parameters.Add("@pk_bankaccbas", OleDbType.VarChar, 20).Value = rcDataset.Tables("gl_pz").Rows(i).Item("value" & j.ToString)
                                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                        If rcDataset.Tables("bd_bankaccbas") IsNot Nothing Then
                                            rcDataset.Tables("bd_bankaccbas").Clear()
                                        End If
                                        rcOleDbDataAdpt.Fill(rcDataset, "bd_bankaccbas")
                                        If rcDataset.Tables("bd_bankaccbas").Rows.Count > 0 Then
                                            rcDataset.Tables("gl_pz").Rows(i).Item("yhzh") = rcDataset.Tables("bd_bankaccbas").Rows(0).Item("accnum")
                                            'rcDataset.Tables("gl_pz").Rows(i).Item("") = rcDataset.Tables("bd_bankaccbas").Rows(0).Item("accname")
                                        End If
                                        'Case "银行档案"
                                        '    rcOleDbCommand.CommandText = "SELECT code,name FROM bd_bankdoc WHERE pk_bankdoc = ?"
                                        '    rcOleDbCommand.Parameters.Clear()
                                        '    rcOleDbCommand.Parameters.Add("@pk_bankdoc", OleDbType.VarChar, 20).Value = rcDataset.Tables("gl_pz").Rows(i).Item("value" & j.ToString)
                                        '    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                        '    If Not rcDataset.Tables("bd_bankdoc") Is Nothing Then
                                        '        rcDataset.Tables("bd_bankdoc").Clear()
                                        '    End If
                                        '    rcOleDbDataAdpt.Fill(rcDataset, "bd_bankdoc")
                                        '    If rcDataset.Tables("bd_bankdoc").Rows.Count > 0 Then
                                        '        rcDataset.Tables("gl_pz").Rows(i).Item("khyh") = rcDataset.Tables("bd_bankdoc").Rows(0).Item("code")
                                        '        'rcDataset.Tables("gl_pz").Rows(i).Item("csmc") = rcDataset.Tables("bd_bankdoc").Rows(0).Item("name")
                                        '    End If
                                End Select
                            End If
                        End If
                    Next
                    '对方科目转换
                    If rcDataset.Tables("gl_pz").Rows(i).Item("dfkm").GetType.ToString <> "System.DBNull" Then
                        Dim aa() As String = rcDataset.Tables("gl_pz").Rows(i).Item("dfkm").ToString.Split(",")
                        rcDataset.Tables("gl_pz").Rows(i).Item("dfkm") = ""
                        For j = 0 To aa.Length - 1
                            rcOleDbCommand.CommandText = "SELECT bd_accasoa.name,bd_account.code FROM bd_accasoa,bd_account WHERE bd_account.pk_account = bd_accasoa.pk_account AND bd_accasoa.pk_accasoa = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@pk_accasoa", OleDbType.VarChar, 20).Value = aa(j)
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("bd_accasoa") IsNot Nothing Then
                                rcDataset.Tables("bd_accasoa").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "bd_accasoa")
                            If rcDataset.Tables("bd_accasoa").Rows.Count > 0 Then
                                rcDataset.Tables("gl_pz").Rows(i).Item("dfkm") += IIf(j = 0, "", ",") & rcDataset.Tables("bd_accasoa").Rows(0).Item("code")
                            End If
                        Next
                    End If
                Next
            Catch ex As Exception
                MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                NCOleDbConn.Close()
            End Try
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "DELETE FROM gl_pz WHERE substr(djh,5,6)= ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
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
            'MsgBox(rcDataset.Tables("gl_pz").Rows.Count)
            Me.ProgressBar1.Maximum = rcDataset.Tables("gl_pz").Rows.Count
            For i = 0 To rcDataset.Tables("gl_pz").Rows.Count - 1
                Try
                    rcOleDbConn.Open()
                    rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.Transaction = rcOleDbTrans
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    Me.ProgressBar1.Value = i + 1
                    rcOleDbCommand.CommandText = "INSERT INTO gl_pz (djh,cperiod,pzlxdm,pzh,xh,bdelete,pzrq,fjzs,jd,zy,kmdm,kmmc,bmdm,bmmc,zydm,zymc,xmdm,xmmc,khdm,khmc,csdm,csmc,jxzh,yhzh,dfkm,dw,sl,dj,bz,wb,hl,je,yspz,jsr,wldqr,srr,srrq,shr,shrq,jzr,jzrq) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataset.Tables("gl_pz").Rows(i).Item("pzlxdm").ToString.PadRight(4, "0") & rcDataset.Tables("gl_pz").Rows(i).Item("year") & rcDataset.Tables("gl_pz").Rows(i).Item("period") & Trim(rcDataset.Tables("gl_pz").Rows(i).Item("pzh").ToString).PadLeft(5, "0")
                    rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.Char, 6).Value = rcDataset.Tables("gl_pz").Rows(i).Item("year") & rcDataset.Tables("gl_pz").Rows(i).Item("period")
                    rcOleDbCommand.Parameters.Add("@pzlxdm", OleDbType.VarChar, 4).Value = rcDataset.Tables("gl_pz").Rows(i).Item("pzlxdm").ToString.PadRight(4, "0")
                    rcOleDbCommand.Parameters.Add("@pzh", OleDbType.Numeric, 5).Value = rcDataset.Tables("gl_pz").Rows(i).Item("pzh")
                    rcOleDbCommand.Parameters.Add("@xh", OleDbType.Numeric, 4).Value = rcDataset.Tables("gl_pz").Rows(i).Item("xh")
                    rcOleDbCommand.Parameters.Add("@bdelete", OleDbType.Numeric, 1).Value = 0
                    rcOleDbCommand.Parameters.Add("@pzrq", OleDbType.Date, 8).Value = rcDataset.Tables("gl_pz").Rows(i).Item("pzrq")
                    rcOleDbCommand.Parameters.Add("@fjzs", OleDbType.Numeric, 4).Value = rcDataset.Tables("gl_pz").Rows(i).Item("fjzs")
                    rcOleDbCommand.Parameters.Add("@jd", OleDbType.Char, 2).Value = IIf(rcDataset.Tables("gl_pz").Rows(i).Item("jfje") <> 0, "借", "贷")
                    rcOleDbCommand.Parameters.Add("@zy", OleDbType.VarChar, 200).Value = rcDataset.Tables("gl_pz").Rows(i).Item("zy")
                    rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("gl_pz").Rows(i).Item("kmdm")
                    rcOleDbCommand.Parameters.Add("@kmmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("gl_pz").Rows(i).Item("kmmc")
                    rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("gl_pz").Rows(i).Item("bmdm")
                    rcOleDbCommand.Parameters.Add("@bmmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("gl_pz").Rows(i).Item("bmmc")
                    rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = rcDataset.Tables("gl_pz").Rows(i).Item("zydm")
                    rcOleDbCommand.Parameters.Add("@zymc", OleDbType.VarChar, 200).Value = rcDataset.Tables("gl_pz").Rows(i).Item("zymc")
                    rcOleDbCommand.Parameters.Add("@xmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("gl_pz").Rows(i).Item("xmdm")
                    rcOleDbCommand.Parameters.Add("@xmmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("gl_pz").Rows(i).Item("xmmc")
                    If Not Me.RadioButton2.Checked Or rcDataset.Tables("gl_pz").Rows(i).Item("csdm") = "~" Then
                        rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("gl_pz").Rows(i).Item("khdm")
                        rcOleDbCommand.Parameters.Add("@khmc", OleDbType.VarChar, 100).Value = rcDataset.Tables("gl_pz").Rows(i).Item("khmc")
                        rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("gl_pz").Rows(i).Item("csdm")
                        rcOleDbCommand.Parameters.Add("@csmc", OleDbType.VarChar, 100).Value = rcDataset.Tables("gl_pz").Rows(i).Item("csmc")
                    Else
                        rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("gl_pz").Rows(i).Item("csdm") & rcDataset.Tables("gl_pz").Rows(i).Item("khdm")
                        rcOleDbCommand.Parameters.Add("@khmc", OleDbType.VarChar, 100).Value = rcDataset.Tables("gl_pz").Rows(i).Item("csmc") & "_" & rcDataset.Tables("gl_pz").Rows(i).Item("khmc")
                        rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = "~"
                        rcOleDbCommand.Parameters.Add("@csmc", OleDbType.VarChar, 100).Value = "~"
                    End If
                    rcOleDbCommand.Parameters.Add("@jxzh", OleDbType.VarChar, 12).Value = rcDataset.Tables("gl_pz").Rows(i).Item("jxzh")
                    rcOleDbCommand.Parameters.Add("@yhzh", OleDbType.VarChar, 12).Value = rcDataset.Tables("gl_pz").Rows(i).Item("yhzh")
                    rcOleDbCommand.Parameters.Add("@dfkm", OleDbType.VarChar, 50).Value = rcDataset.Tables("gl_pz").Rows(i).Item("dfkm")
                    rcOleDbCommand.Parameters.Add("@dw", OleDbType.VarChar, 50).Value = "~"
                    rcOleDbCommand.Parameters.Add("@sl", OleDbType.Numeric, 18).Value = IIf(rcDataset.Tables("gl_pz").Rows(i).Item("jfje") <> 0, rcDataset.Tables("gl_pz").Rows(i).Item("jfsl"), rcDataset.Tables("gl_pz").Rows(i).Item("dfsl"))
                    rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = 0.0
                    rcOleDbCommand.Parameters.Add("@bz", OleDbType.VarChar, 12).Value = rcDataset.Tables("gl_pz").Rows(i).Item("wbdm")
                    rcOleDbCommand.Parameters.Add("@wb", OleDbType.Numeric, 18).Value = IIf(rcDataset.Tables("gl_pz").Rows(i).Item("jfje") <> 0, rcDataset.Tables("gl_pz").Rows(i).Item("jfwb"), rcDataset.Tables("gl_pz").Rows(i).Item("dfwb"))
                    rcOleDbCommand.Parameters.Add("@hl", OleDbType.Numeric, 18).Value = 0.0
                    rcOleDbCommand.Parameters.Add("@je", OleDbType.Numeric, 14).Value = IIf(rcDataset.Tables("gl_pz").Rows(i).Item("jfje") <> 0, rcDataset.Tables("gl_pz").Rows(i).Item("jfje"), rcDataset.Tables("gl_pz").Rows(i).Item("dfje"))
                    rcOleDbCommand.Parameters.Add("@yspz", OleDbType.VarChar, 16).Value = "~"
                    rcOleDbCommand.Parameters.Add("@jsr", OleDbType.VarChar, 30).Value = "~"
                    rcOleDbCommand.Parameters.Add("@wldqr", OleDbType.Date, 8).Value = Now.Date
                    rcOleDbCommand.Parameters.Add("@srr", OleDbType.VarChar, 30).Value = "~"
                    rcOleDbCommand.Parameters.Add("@srrq", OleDbType.Date, 8).Value = Now.Date
                    rcOleDbCommand.Parameters.Add("@shr", OleDbType.VarChar, 30).Value = "~"
                    rcOleDbCommand.Parameters.Add("@shrq", OleDbType.Date, 8).Value = Now.Date
                    rcOleDbCommand.Parameters.Add("@jzr", OleDbType.VarChar, 30).Value = "~"
                    rcOleDbCommand.Parameters.Add("@jzrq", OleDbType.Date, 8).Value = Now.Date
                    rcOleDbCommand.ExecuteNonQuery()
                    '检测科目编码
                    If rcDataset.Tables("gl_pz").Rows(i).Item("kmdm") <> "~" Then
                        rcOleDbCommand.CommandText = "SELECT kmdm FROM gl_kmxx WHERE kmdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("gl_pz").Rows(i).Item("kmdm")
                        If rcDataset.Tables("gl_kmxx") IsNot Nothing Then
                            rcDataset.Tables("gl_kmxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "gl_kmxx")
                        If rcDataset.Tables("gl_kmxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO gl_kmxx (kmdm,kmmc) VALUES (?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("gl_pz").Rows(i).Item("kmdm")
                            rcOleDbCommand.Parameters.Add("@kmmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("gl_pz").Rows(i).Item("kmmc")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    '检测外币编码
                    If rcDataset.Tables("gl_pz").Rows(i).Item("wbdm") <> "~" Then
                        rcOleDbCommand.CommandText = "SELECT wbdm FROM rc_wbxx WHERE kjnd = ? AND wbdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                        rcOleDbCommand.Parameters.Add("@wbdm", OleDbType.VarChar, 4).Value = rcDataset.Tables("gl_pz").Rows(i).Item("wbdm")
                        If rcDataset.Tables("rc_wbxx") IsNot Nothing Then
                            rcDataset.Tables("rc_wbxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_wbxx")
                        If rcDataset.Tables("rc_wbxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_wbxx (kjnd,wbdm,wbmc) VALUES (?,?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                            rcOleDbCommand.Parameters.Add("@wbdm", OleDbType.VarChar, 4).Value = rcDataset.Tables("gl_pz").Rows(i).Item("wbdm")
                            rcOleDbCommand.Parameters.Add("@wbmc", OleDbType.VarChar, 8).Value = rcDataset.Tables("gl_pz").Rows(i).Item("wbmc")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    '检测客户编码
                    If rcDataset.Tables("gl_pz").Rows(i).Item("khdm") <> "~" Then
                        rcOleDbCommand.CommandText = "SELECT khdm FROM rc_khxx WHERE khdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        If Not Me.RadioButton2.Checked Or rcDataset.Tables("gl_pz").Rows(i).Item("csdm") = "~" Then
                            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("gl_pz").Rows(i).Item("khdm")
                        Else
                            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("gl_pz").Rows(i).Item("csdm") & rcDataset.Tables("gl_pz").Rows(i).Item("khdm")
                        End If
                        If rcDataset.Tables("rc_khxx") IsNot Nothing Then
                            rcDataset.Tables("rc_khxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_khxx")
                        If rcDataset.Tables("rc_khxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_khxx (khdm,khmc) VALUES (?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            If Not Me.RadioButton2.Checked Or rcDataset.Tables("gl_pz").Rows(i).Item("csdm") = "~" Then
                                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("gl_pz").Rows(i).Item("khdm")
                                rcOleDbCommand.Parameters.Add("@khmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("gl_pz").Rows(i).Item("khmc")
                            Else
                                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("gl_pz").Rows(i).Item("csdm") & rcDataset.Tables("gl_pz").Rows(i).Item("khdm")
                                rcOleDbCommand.Parameters.Add("@khmc", OleDbType.VarChar, 100).Value = rcDataset.Tables("gl_pz").Rows(i).Item("csmc") & "_" & rcDataset.Tables("gl_pz").Rows(i).Item("khmc")
                            End If
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    '检测供应商编码
                    If rcDataset.Tables("gl_pz").Rows(i).Item("csdm") <> "~" Then
                        rcOleDbCommand.CommandText = "SELECT csdm FROM rc_csxx WHERE csdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("gl_pz").Rows(i).Item("csdm")
                        If rcDataset.Tables("rc_csxx") IsNot Nothing Then
                            rcDataset.Tables("rc_csxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_csxx")
                        If rcDataset.Tables("rc_csxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_csxx (csdm,csmc,zczb,fktj,fkts) VALUES (?,?,0,'月结',0)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("gl_pz").Rows(i).Item("csdm")
                            rcOleDbCommand.Parameters.Add("@csmc", OleDbType.VarChar, 100).Value = rcDataset.Tables("gl_pz").Rows(i).Item("csmc")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    ''重新汇总总帐
                    'rcOleDbCommand.CommandType = CommandType.StoredProcedure
                    'rcOleDbCommand.CommandText = "USP3_REDO_KMYEHZ"
                    'rcOleDbCommand.Parameters.Clear()
                    'rcOleDbCommand.Parameters.Add("@year", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                    'rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                    'rcOleDbCommand.ExecuteNonQuery()
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
            Next
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                '重新汇总总帐
                rcOleDbCommand.CommandType = CommandType.StoredProcedure
                rcOleDbCommand.CommandText = "USP3_REDO_KMYEHZ"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@year", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
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
        '材料出库
        If Me.ChbInvCkd.Checked Then
            '读取材料出库
            Try
                NCOleDbConn.Open()
                rcOleDbCommand.Connection = NCOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT ic_material.pk_org,ic_material.djh,ic_material.xh,ic_material.ckrq,ic_material.cwarehouseid,ic_material.ckdm,ic_material.ckmc,ic_material.cdptid,NVL(org_dept.code,'~') AS bmdm,NVL(org_dept.name,'~') AS bmmc,ic_material.pk_marbasclass,ic_material.lbdm,ic_material.cmaterialvid,ic_material.cpdm,ic_material.cpmc,ic_material.pk_measdoc,ic_material.dw,ic_material.vbatchcode,ic_material.nassistnum,ic_material.nnum AS sl,ic_material.nweight AS zl,ic_material.ncostprice AS dj,ic_material.ncostmny AS je,ic_material.ckmemo,ic_material.cgeneralbid FROM (select ic_material_h.pk_org,ic_material_h.vbillcode AS djh,ic_material_b.crowno AS xh,ic_material_b.dbizdate AS ckrq,ic_material_h.cwarehouseid,bd_stordoc.code AS ckdm,bd_stordoc.name AS ckmc,ic_material_h.cdptid,bd_material.pk_marbasclass,bd_marbasclass.code AS lbdm,ic_material_b.cmaterialvid,bd_material.code AS cpdm,bd_material.name || ',' || bd_material.materialtype || ',' || bd_material.materialspec AS cpmc,bd_material.pk_measdoc,bd_measdoc.name AS dw,ic_material_b.vbatchcode,ic_material_b.nassistnum,ic_material_b.nnum,ic_material_b.nweight,ic_material_b.ncostprice,ic_material_b.ncostmny,ic_material_b.vnotebody AS ckmemo,ic_material_b.cgeneralbid from ic_material_h,ic_material_b,bd_stordoc,bd_material,bd_measdoc,bd_marbasclass,org_orgs where ic_material_h.cgeneralhid = ic_material_b.cgeneralhid AND ic_material_h.cwarehouseid = bd_stordoc.pk_stordoc" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND EXISTS (SELECT 1 FROM bd_stordoc WHERE ic_material_h.cwarehouseid = bd_stordoc.pk_stordoc AND bd_stordoc.code = '" & Me.TxtCkdm.Text & "')", "") & " AND ic_material_b.cmaterialvid = bd_material.pk_material AND bd_material.pk_measdoc = bd_measdoc.pk_measdoc AND bd_material.pk_marbasclass = bd_marbasclass.pk_marbasclass AND ic_material_h.pk_org = org_orgs.pk_org AND org_orgs.code = ? AND ic_material_h.dr=0 and ic_material_b.dr=0 AND to_date(ic_material_h.dbilldate,'yyyy-mm-dd HH24:mi:ss') <= ? AND to_date(ic_material_h.dbilldate,'yyyy-mm-dd HH24:mi:ss') >= ?) ic_material left join org_dept on org_dept.pk_dept = ic_material.cdptid ORDER BY ic_material.djh,ic_material.xh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@NCAccountingBook", OleDbType.VarChar, 40).Value = NCAccountingBook
                rcOleDbCommand.Parameters.Add("@dateEnd", OleDbType.Date, 8).Value = dateEnd
                rcOleDbCommand.Parameters.Add("@dateBegin", OleDbType.Date, 8).Value = dateBegin
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("ic_material") IsNot Nothing Then
                    Me.rcDataset.Tables("ic_material").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "ic_material")
                Me.ProgressBar1.Maximum = rcDataset.Tables("ic_material").Rows.Count
            Catch ex As Exception
                MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                NCOleDbConn.Close()
            End Try
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                If String.IsNullOrEmpty(Me.TxtCkdm.Text) Then
                    '序列删除再重建
                    rcOleDbCommand.CommandText = "DROP SEQUENCE LLCK" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "CREATE SEQUENCE LLCK" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0") & " INCREMENT BY 1 START WITH 1 MAXVALUE 99999 MINVALUE 1 NOCYCLE NOCACHE NOORDER"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    '更新单据号至0
                    rcOleDbCommand.CommandText = "UPDATE rc_lx SET pzno" & Me.NudMonth.Value.ToString.PadLeft(2, "0") & " = 0 WHERE kjnd = ? AND pzlxdm = 'LLCK'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '删除历史单据
                rcOleDbCommand.CommandText = "DELETE FROM inv_ckd WHERE SUBSTR(djh,5,6)= ? AND SUBSTR(djh,1,4) = 'LLCK'" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND ckdm ='" & Me.TxtCkdm.Text & "'", "")
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                Me.ProgressBar1.Maximum = rcDataset.Tables("ic_material").Rows.Count
                'Dim oldStrDjh As String = ""
                'Dim blnNew As Boolean = False
                For i = 0 To rcDataset.Tables("ic_material").Rows.Count - 1
                    'If oldStrDjh <> rcDataset.Tables("ic_material").Rows(i).Item("djh") Then
                    '    blnNew = True
                    '    oldStrDjh = rcDataset.Tables("ic_material").Rows(i).Item("djh")
                    'Else
                    '    blnNew = False
                    'End If
                    Me.ProgressBar1.Value = i + 1
                    rcOleDbCommand.CommandType = CommandType.StoredProcedure
                    rcOleDbCommand.CommandText = "USP3_SAVE_INV_CKD"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                    rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = "LLCK" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0") & Mid(rcDataset.Tables("ic_material").Rows(i).Item("djh"), rcDataset.Tables("ic_material").Rows(i).Item("djh").ToString.Length - 4, 5)
                    rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                    rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = 1
                    rcOleDbCommand.Parameters.Add("@paraDateCkrq", OleDbType.Date, 8).Value = rcDataset.Tables("ic_material").Rows(i).Item("ckrq")
                    rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                    rcOleDbCommand.Parameters.Add("@ParaStrCkdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_material").Rows(i).Item("ckdm")
                    rcOleDbCommand.Parameters.Add("@paraStrCkmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("ic_material").Rows(i).Item("ckmc")
                    rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_material").Rows(i).Item("bmdm")
                    rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("ic_material").Rows(i).Item("bmmc")
                    rcOleDbCommand.Parameters.Add("@paraStrZydm", OleDbType.VarChar, 12).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrZymc", OleDbType.VarChar, 30).Value = "~"
                    rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("ic_material").Rows(i).Item("cpdm")
                    rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("ic_material").Rows(i).Item("cpmc")
                    rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrBrecycling", OleDbType.Numeric, 1).Value = 0
                    rcOleDbCommand.Parameters.Add("@paraStrBfadm", OleDbType.Numeric, 1).Value = 0
                    rcOleDbCommand.Parameters.Add("@ParaStrFadm", OleDbType.VarChar, 12).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrFamc", OleDbType.VarChar, 30).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrKuwei", OleDbType.VarChar, 40).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrPiHao", OleDbType.VarChar, 40).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("ic_material").Rows(i).Item("sl")
                    rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = rcDataset.Tables("ic_material").Rows(i).Item("dw")
                    rcOleDbCommand.Parameters.Add("@paraDblMjsl", OleDbType.Numeric, 18).Value = 0.0
                    rcOleDbCommand.Parameters.Add("@paraDblFzsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("ic_material").Rows(i).Item("zl")
                    rcOleDbCommand.Parameters.Add("@paraStrFzdw", OleDbType.VarChar, 8).Value = "KG"
                    rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = rcDataset.Tables("ic_material").Rows(i).Item("dj")
                    rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("ic_material").Rows(i).Item("je")
                    rcOleDbCommand.Parameters.Add("@paraStrCkmemo", OleDbType.VarChar, 50).Value = rcDataset.Tables("ic_material").Rows(i).Item("ckmemo")
                    rcOleDbCommand.Parameters.Add("@paraStrLlsqDjh", OleDbType.VarChar, 15).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraIntLlsqXh", OleDbType.Integer, 4).Value = 0
                    rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                    rcOleDbCommand.Parameters.Add("@paraCbill_bid", OleDbType.VarChar, 20).Value = rcDataset.Tables("ic_material").Rows(i).Item("cgeneralbid")
                    rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                    rcOleDbCommand.ExecuteNonQuery()
                    If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                        If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                            MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                            Return
                        End If
                    End If
                    '检测物料编码
                    If rcDataset.Tables("ic_material").Rows(i).Item("cpdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT cpdm FROM rc_cpxx WHERE cpdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("ic_material").Rows(i).Item("cpdm")
                        If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                            rcDataset.Tables("rc_cpxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
                        If rcDataset.Tables("rc_cpxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_cpxx (lbdm,cpdm,cpmc,dw) VALUES (?,?,?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_material").Rows(i).Item("lbdm")
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("ic_material").Rows(i).Item("cpdm")
                            rcOleDbCommand.Parameters.Add("@cpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("ic_material").Rows(i).Item("cpmc")
                            rcOleDbCommand.Parameters.Add("@dw", OleDbType.VarChar, 8).Value = rcDataset.Tables("ic_material").Rows(i).Item("dw")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    '检测仓库编码
                    If rcDataset.Tables("ic_material").Rows(i).Item("ckdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT ckdm FROM rc_ckxx WHERE ckdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_material").Rows(i).Item("ckdm")
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_ckxx") IsNot Nothing Then
                            rcDataset.Tables("rc_ckxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_ckxx")
                        If rcDataset.Tables("rc_ckxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_ckxx (ckdm,ckmc) VALUES (?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_material").Rows(i).Item("ckdm")
                            rcOleDbCommand.Parameters.Add("@ckmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("ic_material").Rows(i).Item("ckmc")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                Next
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
        '其它出库
        If Me.ChbQtck.Checked Then
            '读取材料出库
            Try
                NCOleDbConn.Open()
                rcOleDbCommand.Connection = NCOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT ic_generalout.pk_org,ic_generalout.djh,ic_generalout.xh,ic_generalout.ckrq,ic_generalout.cwarehouseid,ic_generalout.ckdm,ic_generalout.ckmc,ic_generalout.cdptid,NVL(org_dept.code,'~') AS bmdm,NVL(org_dept.name,'~') AS bmmc,ic_generalout.pk_marbasclass,ic_generalout.lbdm,ic_generalout.cmaterialvid,ic_generalout.cpdm,ic_generalout.cpmc,ic_generalout.pk_measdoc,ic_generalout.dw,ic_generalout.vbatchcode,ic_generalout.nassistnum,ic_generalout.nnum AS sl,ic_generalout.nweight AS zl,ic_generalout.ncostprice AS dj,ic_generalout.ncostmny AS je,ic_generalout.ckmemo,ic_generalout.cgeneralbid FROM (select ic_generalout_h.pk_org,ic_generalout_h.vbillcode AS djh,ic_generalout_b.crowno AS xh,ic_generalout_b.dbizdate AS ckrq,ic_generalout_h.cwarehouseid,bd_stordoc.code AS ckdm,bd_stordoc.name AS ckmc,ic_generalout_h.cdptid,bd_material.pk_marbasclass,bd_marbasclass.code AS lbdm,ic_generalout_b.cmaterialvid,bd_material.code AS cpdm,bd_material.name || ',' || bd_material.materialtype || ',' || bd_material.materialspec AS cpmc,bd_material.pk_measdoc,bd_measdoc.name AS dw,ic_generalout_b.vbatchcode,ic_generalout_b.nassistnum,ic_generalout_b.nnum,ic_generalout_b.nweight,ic_generalout_b.ncostprice,ic_generalout_b.ncostmny,ic_generalout_b.vnotebody AS ckmemo,ic_generalout_b.cgeneralbid from ic_generalout_h,ic_generalout_b,bd_stordoc,bd_material,bd_measdoc,bd_marbasclass,org_orgs where ic_generalout_h.cgeneralhid = ic_generalout_b.cgeneralhid AND ic_generalout_h.cwarehouseid = bd_stordoc.pk_stordoc" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND EXISTS (SELECT 1 FROM bd_stordoc WHERE ic_generalout_h.cwarehouseid = bd_stordoc.pk_stordoc AND bd_stordoc.code = '" & Me.TxtCkdm.Text & "')", "") & " AND ic_generalout_b.cmaterialvid = bd_material.pk_material AND bd_material.pk_measdoc = bd_measdoc.pk_measdoc AND bd_material.pk_marbasclass = bd_marbasclass.pk_marbasclass AND ic_generalout_h.pk_org = org_orgs.pk_org AND org_orgs.code = ? AND ic_generalout_h.dr=0 and ic_generalout_b.dr=0 AND to_date(ic_generalout_h.dbilldate,'yyyy-mm-dd HH24:mi:ss') <= ? AND to_date(ic_generalout_h.dbilldate,'yyyy-mm-dd HH24:mi:ss') >= ?) ic_generalout left join org_dept on org_dept.pk_dept = ic_generalout.cdptid ORDER BY ic_generalout.djh,ic_generalout.xh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@NCAccountingBook", OleDbType.VarChar, 40).Value = NCAccountingBook
                rcOleDbCommand.Parameters.Add("@dateEnd", OleDbType.Date, 8).Value = dateEnd
                rcOleDbCommand.Parameters.Add("@dateBegin", OleDbType.Date, 8).Value = dateBegin
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("ic_generalout") IsNot Nothing Then
                    Me.rcDataset.Tables("ic_generalout").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "ic_generalout")
                Me.ProgressBar1.Maximum = rcDataset.Tables("ic_generalout").Rows.Count
            Catch ex As Exception
                MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                NCOleDbConn.Close()
            End Try
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                If String.IsNullOrEmpty(Me.TxtCkdm.Text) Then
                    '序列删除再重建
                    rcOleDbCommand.CommandText = "DROP SEQUENCE CKTZ" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "CREATE SEQUENCE CKTZ" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0") & " INCREMENT BY 1 START WITH 1 MAXVALUE 99999 MINVALUE 1 NOCYCLE NOCACHE NOORDER"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    '更新单据号至0
                    rcOleDbCommand.CommandText = "UPDATE rc_lx SET pzno" & Me.NudMonth.Value.ToString.PadLeft(2, "0") & " = 0 WHERE kjnd = ? AND pzlxdm = 'CKTZ'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '删除历史单据
                rcOleDbCommand.CommandText = "DELETE FROM inv_ckd WHERE SUBSTR(djh,5,6)= ? AND SUBSTR(djh,1,4) = 'CKTZ'" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND ckdm ='" & Me.TxtCkdm.Text & "'", "")
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                Me.ProgressBar1.Maximum = rcDataset.Tables("ic_generalout").Rows.Count
                'Dim oldStrDjh As String = ""
                'Dim blnNew As Boolean = False
                For i = 0 To rcDataset.Tables("ic_generalout").Rows.Count - 1
                    'If oldStrDjh <> rcDataset.Tables("ic_generalout").Rows(i).Item("djh") Then
                    '    blnNew = True
                    '    oldStrDjh = rcDataset.Tables("ic_generalout").Rows(i).Item("djh")
                    'Else
                    '    blnNew = False
                    'End If
                    Me.ProgressBar1.Value = i + 1
                    rcOleDbCommand.CommandType = CommandType.StoredProcedure
                    rcOleDbCommand.CommandText = "USP3_SAVE_INV_CKD"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                    rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = "CKTZ" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0") & Mid(rcDataset.Tables("ic_generalout").Rows(i).Item("djh"), rcDataset.Tables("ic_generalout").Rows(i).Item("djh").ToString.Length - 4, 5)
                    rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                    rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = 1
                    rcOleDbCommand.Parameters.Add("@paraDateCkrq", OleDbType.Date, 8).Value = rcDataset.Tables("ic_generalout").Rows(i).Item("ckrq")
                    rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                    rcOleDbCommand.Parameters.Add("@ParaStrCkdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_generalout").Rows(i).Item("ckdm")
                    rcOleDbCommand.Parameters.Add("@paraStrCkmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("ic_generalout").Rows(i).Item("ckmc")
                    rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_generalout").Rows(i).Item("bmdm")
                    rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("ic_generalout").Rows(i).Item("bmmc")
                    rcOleDbCommand.Parameters.Add("@paraStrZydm", OleDbType.VarChar, 12).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrZymc", OleDbType.VarChar, 30).Value = "~"
                    rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("ic_generalout").Rows(i).Item("cpdm")
                    rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("ic_generalout").Rows(i).Item("cpmc")
                    rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrBrecycling", OleDbType.Numeric, 1).Value = 0
                    rcOleDbCommand.Parameters.Add("@paraStrBfadm", OleDbType.Numeric, 1).Value = 0
                    rcOleDbCommand.Parameters.Add("@ParaStrFadm", OleDbType.VarChar, 12).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrFamc", OleDbType.VarChar, 30).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrKuwei", OleDbType.VarChar, 40).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("ic_generalout").Rows(i).Item("sl")
                    rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = rcDataset.Tables("ic_generalout").Rows(i).Item("dw")
                    rcOleDbCommand.Parameters.Add("@paraDblMjsl", OleDbType.Numeric, 18).Value = 0.0
                    rcOleDbCommand.Parameters.Add("@paraDblFzsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("ic_generalout").Rows(i).Item("zl")
                    rcOleDbCommand.Parameters.Add("@paraStrFzdw", OleDbType.VarChar, 8).Value = "KG"
                    rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = rcDataset.Tables("ic_generalout").Rows(i).Item("dj")
                    rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("ic_generalout").Rows(i).Item("je")
                    rcOleDbCommand.Parameters.Add("@paraStrCkmemo", OleDbType.VarChar, 50).Value = rcDataset.Tables("ic_generalout").Rows(i).Item("ckmemo")
                    rcOleDbCommand.Parameters.Add("@paraStrLlsqDjh", OleDbType.VarChar, 15).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraIntLlsqXh", OleDbType.Integer, 4).Value = 0
                    rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                    rcOleDbCommand.Parameters.Add("@paraCbill_bid", OleDbType.VarChar, 20).Value = rcDataset.Tables("ic_generalout").Rows(i).Item("cgeneralbid")
                    rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                    rcOleDbCommand.ExecuteNonQuery()
                    If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                        If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                            MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                            Return
                        End If
                    End If
                    '检测物料编码
                    If rcDataset.Tables("ic_generalout").Rows(i).Item("cpdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT cpdm FROM rc_cpxx WHERE cpdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("ic_generalout").Rows(i).Item("cpdm")
                        If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                            rcDataset.Tables("rc_cpxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
                        If rcDataset.Tables("rc_cpxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_cpxx (lbdm,cpdm,cpmc,dw) VALUES (?,?,?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_generalout").Rows(i).Item("lbdm")
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("ic_generalout").Rows(i).Item("cpdm")
                            rcOleDbCommand.Parameters.Add("@cpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("ic_generalout").Rows(i).Item("cpmc")
                            rcOleDbCommand.Parameters.Add("@dw", OleDbType.VarChar, 8).Value = rcDataset.Tables("ic_generalout").Rows(i).Item("dw")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    '检测仓库编码
                    If rcDataset.Tables("ic_generalout").Rows(i).Item("ckdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT ckdm FROM rc_ckxx WHERE ckdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_generalout").Rows(i).Item("ckdm")
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_ckxx") IsNot Nothing Then
                            rcDataset.Tables("rc_ckxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_ckxx")
                        If rcDataset.Tables("rc_ckxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_ckxx (ckdm,ckmc) VALUES (?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_generalout").Rows(i).Item("ckdm")
                            rcOleDbCommand.Parameters.Add("@ckmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("ic_generalout").Rows(i).Item("ckmc")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                Next
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
        '导入库存期初余额inv_cpyeb
        If Me.ChbKcqcye.Checked Then
            Try
                NCOleDbConn.Open()
                rcOleDbCommand.Connection = NCOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT ic_openbal.ckdm,ic_openbal.lbdm,ic_openbal.cpdm,ic_openbal.cpmc,ic_openbal.dw,SUM(ic_openbal.nassistnum) AS nassistnum,SUM(ic_openbal.nnum) AS sl,SUM(ic_openbal.nweight) AS zl,SUM(ic_openbal.ncostmny) AS je FROM (select ic_openbal_h.pk_org,ic_openbal_h.vbillcode AS djh,ic_openbal_b.crowno AS xh,ic_openbal_h.dbilldate AS rkrq,ic_openbal_h.cwarehouseid,bd_stordoc.code AS ckdm,bd_stordoc.name AS ckmc,bd_material.pk_marbasclass,bd_marbasclass.pk_marbasclass AS lbdm,ic_openbal_b.cmaterialvid,bd_material.code AS cpdm,bd_material.name || ',' || bd_material.materialtype || ',' || bd_material.materialspec AS cpmc,bd_material.pk_measdoc,bd_measdoc.name AS dw,ic_openbal_b.vbatchcode,ic_openbal_b.nassistnum,ic_openbal_b.nnum,ic_openbal_b.nweight,ic_openbal_b.ncostmny,ic_openbal_b.vnotebody AS rkmemo,ic_openbal_b.cgeneralbid from ic_openbal_h,ic_openbal_b,bd_stordoc,bd_material,bd_measdoc,bd_marbasclass,org_orgs where ic_openbal_h.cgeneralhid = ic_openbal_b.cgeneralhid AND ic_openbal_h.cwarehouseid = bd_stordoc.pk_stordoc AND ic_openbal_b.cmaterialvid = bd_material.pk_material AND bd_material.pk_measdoc = bd_measdoc.pk_measdoc AND bd_material.pk_marbasclass = bd_marbasclass.pk_marbasclass AND ic_openbal_h.pk_org = org_orgs.pk_org AND org_orgs.code = ? AND ic_openbal_h.dr=0 and ic_openbal_b.dr=0 AND SUBSTR(ic_openbal_h.dbilldate,1,4)= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND EXISTS (SELECT 1 FROM bd_stordoc WHERE ic_openbal_h.cwarehouseid = bd_stordoc.pk_stordoc AND bd_stordoc.code = '" & Me.TxtCkdm.Text & "')", "") & ") ic_openbal GROUP BY ic_openbal.ckdm,ic_openbal.lbdm,ic_openbal.cpdm,ic_openbal.cpmc,ic_openbal.dw"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@NCAccountingBook", OleDbType.VarChar, 40).Value = NCAccountingBook
                rcOleDbCommand.Parameters.Add("@intYear", OleDbType.Integer, 4).Value = Me.NudYear.Value
                'rcOleDbCommand.Parameters.Add("@dateBegin", OleDbType.Date, 8).Value = dateBegin
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("ic_openbal") IsNot Nothing Then
                    Me.rcDataset.Tables("ic_openbal").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "ic_openbal")
                Me.ProgressBar1.Maximum = rcDataset.Tables("ic_openbal").Rows.Count
            Catch ex As Exception
                MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                NCOleDbConn.Close()
            End Try
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                '删除历史期初余额
                rcOleDbCommand.CommandText = "DELETE FROM inv_cpyeb WHERE kjnd = ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND ckdm ='" & Me.TxtCkdm.Text & "'", "")
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                rcOleDbCommand.ExecuteNonQuery()
                Me.ProgressBar1.Maximum = rcDataset.Tables("ic_openbal").Rows.Count
                For i = 0 To rcDataset.Tables("ic_openbal").Rows.Count - 1
                    Me.ProgressBar1.Value = i + 1
                    rcOleDbCommand.CommandType = CommandType.Text
                    rcOleDbCommand.CommandText = "INSERT INTO inv_cpyeb (kjnd,cpdm,ckdm,qcsl,qcfzsl,qcje) VALUES (?,?,?,?,?,?)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@paraStrKjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                    rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("ic_openbal").Rows(i).Item("cpdm")).ToUpper
                    rcOleDbCommand.Parameters.Add("@ParaStrCkdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_openbal").Rows(i).Item("ckdm")
                    rcOleDbCommand.Parameters.Add("@paraDblQcSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("ic_openbal").Rows(i).Item("sl")
                    rcOleDbCommand.Parameters.Add("@paraDblFzsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("ic_openbal").Rows(i).Item("zl")
                    rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("ic_openbal").Rows(i).Item("je")
                    rcOleDbCommand.ExecuteNonQuery()
                    '检测物料编码
                    If rcDataset.Tables("ic_openbal").Rows(i).Item("cpdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT cpdm FROM rc_cpxx WHERE cpdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("ic_openbal").Rows(i).Item("cpdm")
                        If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                            rcDataset.Tables("rc_cpxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
                        If rcDataset.Tables("rc_cpxx").Rows.Count = 0 Then
                            'MsgBox(rcDataset.Tables("ic_openbal").Rows(i).Item("dw"))
                            rcOleDbCommand.CommandText = "INSERT INTO rc_cpxx (lbdm,cpdm,cpmc,dw) VALUES (?,?,?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_openbal").Rows(i).Item("lbdm")
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("ic_openbal").Rows(i).Item("cpdm")
                            rcOleDbCommand.Parameters.Add("@cpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("ic_openbal").Rows(i).Item("cpmc")
                            rcOleDbCommand.Parameters.Add("@dw", OleDbType.VarChar, 8).Value = rcDataset.Tables("ic_openbal").Rows(i).Item("dw")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                Next
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
        '调拨出库
        If Me.ChbInvDbd.Checked Then
            '读取调拨出库
            Try
                NCOleDbConn.Open()
                rcOleDbCommand.Connection = NCOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT ic_transout.pk_org,ic_transout.djh,ic_transout.xh,ic_transout.dbrq,ic_transout.cwarehouseid,ic_transout.cckdm,ic_transout.cckmc,ic_transout.rckdm,ic_transout.rckmc,ic_transout.pk_marbasclass,ic_transout.lbdm,ic_transout.cmaterialvid,ic_transout.cpdm,ic_transout.cpmc,ic_transout.pk_measdoc,ic_transout.dw,ic_transout.vbatchcode,ic_transout.nassistnum,ic_transout.nnum AS sl,ic_transout.nweight AS zl,ic_transout.dbmemo,ic_transout.cgeneralbid FROM (select ic_transout_h.pk_org,ic_transout_h.vbillcode AS djh,ic_transout_b.crowno AS xh,ic_transout_h.dbilldate AS dbrq,ic_transout_h.cwarehouseid,bd_stordoc.code AS cckdm,bd_stordoc.name AS cckmc,ic_transout_h.cotherwhid,bd_stordoc_r.code AS rckdm,bd_stordoc_r.name AS rckmc,bd_material.pk_marbasclass,bd_marbasclass.code AS lbdm,ic_transout_b.cmaterialvid,bd_material.code AS cpdm,bd_material.name || ',' || bd_material.materialtype || ',' || bd_material.materialspec AS cpmc,bd_material.pk_measdoc,bd_measdoc.name AS dw,ic_transout_b.vbatchcode,ic_transout_b.nassistnum,ic_transout_b.nnum,ic_transout_b.nweight,ic_transout_b.vnotebody AS dbmemo,ic_transout_b.cgeneralbid from ic_transout_h,ic_transout_b,bd_stordoc,bd_stordoc bd_stordoc_r,bd_material,bd_measdoc,bd_marbasclass,org_orgs where ic_transout_h.cgeneralhid = ic_transout_b.cgeneralhid AND ic_transout_h.cwarehouseid = bd_stordoc.pk_stordoc AND ic_transout_h.cotherwhid = bd_stordoc_r.pk_stordoc AND ic_transout_b.cmaterialvid = bd_material.pk_material AND bd_material.pk_measdoc = bd_measdoc.pk_measdoc AND bd_material.pk_marbasclass = bd_marbasclass.pk_marbasclass AND ic_transout_h.pk_org = org_orgs.pk_org AND org_orgs.code = ? AND ic_transout_h.dr=0 and ic_transout_b.dr=0 AND to_date(ic_transout_h.dbilldate,'yyyy-mm-dd HH24:mi:ss') <= ? AND to_date(ic_transout_h.dbilldate,'yyyy-mm-dd HH24:mi:ss') >= ?) ic_transout ORDER BY ic_transout.djh,ic_transout.xh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@NCAccountingBook", OleDbType.VarChar, 40).Value = NCAccountingBook
                rcOleDbCommand.Parameters.Add("@dateEnd", OleDbType.Date, 8).Value = dateEnd
                rcOleDbCommand.Parameters.Add("@dateBegin", OleDbType.Date, 8).Value = dateBegin
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("ic_transout") IsNot Nothing Then
                    Me.rcDataset.Tables("ic_transout").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "ic_transout")
                Me.ProgressBar1.Maximum = rcDataset.Tables("ic_transout").Rows.Count
            Catch ex As Exception
                MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                NCOleDbConn.Close()
            End Try
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                '序列删除再重建
                rcOleDbCommand.CommandText = "DROP SEQUENCE DBDJ" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "CREATE SEQUENCE DBDJ" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0") & " INCREMENT BY 1 START WITH 1 MAXVALUE 99999 MINVALUE 1 NOCYCLE NOCACHE NOORDER"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '更新单据号至0
                rcOleDbCommand.CommandText = "UPDATE rc_lx SET pzno" & Me.NudMonth.Value.ToString.PadLeft(2, "0") & " = 0 WHERE kjnd = ? AND pzlxdm = 'DBDJ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                rcOleDbCommand.ExecuteNonQuery()
                '删除历史单据
                rcOleDbCommand.CommandText = "DELETE FROM inv_dbd WHERE SUBSTR(djh,5,6)= ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                Me.ProgressBar1.Maximum = rcDataset.Tables("ic_transout").Rows.Count
                'Dim oldStrDjh As String = ""
                'Dim blnNew As Boolean = False
                For i = 0 To rcDataset.Tables("ic_transout").Rows.Count - 1
                    'If oldStrDjh <> rcDataset.Tables("ic_transout").Rows(i).Item("djh") Then
                    '    blnNew = True
                    '    oldStrDjh = rcDataset.Tables("ic_transout").Rows(i).Item("djh")
                    'Else
                    '    blnNew = False
                    'End If
                    Me.ProgressBar1.Value = i + 1
                    rcOleDbCommand.CommandType = CommandType.StoredProcedure
                    rcOleDbCommand.CommandText = "USP3_SAVE_INV_DBD"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                    rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = "DBDJ" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0") & Mid(rcDataset.Tables("ic_transout").Rows(i).Item("djh"), rcDataset.Tables("ic_transout").Rows(i).Item("djh").ToString.Length - 4, 5)
                    rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                    rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = 1
                    rcOleDbCommand.Parameters.Add("@paraDateCkrq", OleDbType.Date, 8).Value = rcDataset.Tables("ic_transout").Rows(i).Item("dbrq")
                    rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                    rcOleDbCommand.Parameters.Add("@paraStrCckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_transout").Rows(i).Item("cckdm")
                    rcOleDbCommand.Parameters.Add("@paraStrCckmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("ic_transout").Rows(i).Item("cckmc")
                    rcOleDbCommand.Parameters.Add("@paraStrRkdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_transout").Rows(i).Item("rckdm")
                    rcOleDbCommand.Parameters.Add("@paraStrRkmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("ic_transout").Rows(i).Item("rckdm")
                    rcOleDbCommand.Parameters.Add("@paraStrZydm", OleDbType.VarChar, 12).Value = ""
                    rcOleDbCommand.Parameters.Add("@paraStrZymc", OleDbType.VarChar, 30).Value = ""

                    rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("ic_transout").Rows(i).Item("cpdm")).ToUpper
                    rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("ic_transout").Rows(i).Item("cpmc")
                    rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = ""
                    rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = ""
                    rcOleDbCommand.Parameters.Add("@paraStrKuwei", OleDbType.VarChar, 40).Value = ""
                    rcOleDbCommand.Parameters.Add("@paraStrPiHao", OleDbType.VarChar, 30).Value = ""
                    rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("ic_transout").Rows(i).Item("sl")
                    rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = rcDataset.Tables("ic_transout").Rows(i).Item("dw")
                    rcOleDbCommand.Parameters.Add("@paraDblMjsl", OleDbType.Numeric, 18).Value = 0.0
                    rcOleDbCommand.Parameters.Add("@paraDblFzsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("ic_transout").Rows(i).Item("zl")
                    rcOleDbCommand.Parameters.Add("@paraStrFzdw", OleDbType.VarChar, 8).Value = "KG"
                    rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = 0.0
                    rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = 0.0
                    rcOleDbCommand.Parameters.Add("@paraStrDbmemo", OleDbType.VarChar, 50).Value = rcDataset.Tables("ic_transout").Rows(i).Item("dbmemo")
                    rcOleDbCommand.Parameters.Add("@paraStrLlsqDjh", OleDbType.VarChar, 15).Value = ""
                    rcOleDbCommand.Parameters.Add("@paraIntLlsqXh", OleDbType.Integer, 4).Value = 0
                    rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                    rcOleDbCommand.Parameters.Add("@paraCbill_bid", OleDbType.VarChar, 20).Value = rcDataset.Tables("ic_transout").Rows(i).Item("cgeneralbid")
                    rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                    rcOleDbCommand.ExecuteNonQuery()
                    If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                        If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                            MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                            Return
                        End If
                    End If
                    '检测物料编码
                    If rcDataset.Tables("ic_transout").Rows(i).Item("cpdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT cpdm FROM rc_cpxx WHERE cpdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("ic_transout").Rows(i).Item("cpdm")
                        If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                            rcDataset.Tables("rc_cpxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
                        If rcDataset.Tables("rc_cpxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_cpxx (lbdm,cpdm,cpmc,dw) VALUES (?,?,?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_transout").Rows(i).Item("lbdm")
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("ic_transout").Rows(i).Item("cpdm")
                            rcOleDbCommand.Parameters.Add("@cpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("ic_transout").Rows(i).Item("cpmc")
                            rcOleDbCommand.Parameters.Add("@dw", OleDbType.VarChar, 8).Value = rcDataset.Tables("ic_transout").Rows(i).Item("dw")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    '检测仓库编码
                    If rcDataset.Tables("ic_transout").Rows(i).Item("cckdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT ckdm FROM rc_ckxx WHERE ckdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_transout").Rows(i).Item("cckdm")
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_ckxx") IsNot Nothing Then
                            rcDataset.Tables("rc_ckxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_ckxx")
                        If rcDataset.Tables("rc_ckxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_ckxx (ckdm,ckmc) VALUES (?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_transout").Rows(i).Item("cckdm")
                            rcOleDbCommand.Parameters.Add("@ckmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("ic_transout").Rows(i).Item("cckmc")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    If rcDataset.Tables("ic_transout").Rows(i).Item("rckdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT ckdm FROM rc_ckxx WHERE ckdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_transout").Rows(i).Item("rckdm")
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_ckxx") IsNot Nothing Then
                            rcDataset.Tables("rc_ckxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_ckxx")
                        If rcDataset.Tables("rc_ckxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_ckxx (ckdm,ckmc) VALUES (?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_transout").Rows(i).Item("rckdm")
                            rcOleDbCommand.Parameters.Add("@ckmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("ic_transout").Rows(i).Item("rckmc")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                Next
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

        '产成品入库
        If Me.ChbInvRkd1.Checked Then
            '读取产成品入库
            Try
                NCOleDbConn.Open()
                rcOleDbCommand.Connection = NCOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT ic_finprodin.pk_org,ic_finprodin.djh,ic_finprodin.xh,ic_finprodin.rkrq,ic_finprodin.cwarehouseid,ic_finprodin.ckdm,ic_finprodin.ckmc,ic_finprodin.cdptid,NVL(org_dept.code,'~') AS bmdm,NVL(org_dept.name,'~') AS bmmc,ic_finprodin.pk_marbasclass,ic_finprodin.lbdm,ic_finprodin.cmaterialvid,ic_finprodin.cpdm,ic_finprodin.cpmc,ic_finprodin.pk_measdoc,ic_finprodin.dw,ic_finprodin.vbatchcode,ic_finprodin.nassistnum,ic_finprodin.nnum AS sl,ic_finprodin.nweight AS zl,COALESCE(ic_finprodin.ncostprice,0.0) AS dj,COALESCE(ic_finprodin.ncostmny,0.0) As je,ic_finprodin.rkmemo,ic_finprodin.cgeneralbid FROM (select ic_finprodin_h.pk_org,ic_finprodin_h.vbillcode AS djh,ic_finprodin_b.crowno AS xh,ic_finprodin_h.dbilldate AS rkrq,ic_finprodin_h.cwarehouseid,bd_stordoc.code AS ckdm,bd_stordoc.name AS ckmc,ic_finprodin_h.cdptid,bd_material.pk_marbasclass,bd_marbasclass.code AS lbdm,ic_finprodin_b.cmaterialvid,bd_material.code AS cpdm,bd_material.name || ',' || bd_material.materialtype || ',' || bd_material.materialspec AS cpmc,bd_material.pk_measdoc,bd_measdoc.name AS dw,ic_finprodin_b.vbatchcode,ic_finprodin_b.nassistnum,ic_finprodin_b.nnum,ic_finprodin_b.nweight,ic_finprodin_b.ncostprice,ic_finprodin_b.ncostmny,ic_finprodin_b.vnotebody AS rkmemo,ic_finprodin_b.cgeneralbid from ic_finprodin_h,ic_finprodin_b,bd_stordoc,bd_material,bd_measdoc,bd_marbasclass,org_orgs where ic_finprodin_h.cgeneralhid = ic_finprodin_b.cgeneralhid AND ic_finprodin_h.cwarehouseid = bd_stordoc.pk_stordoc AND ic_finprodin_b.cmaterialvid = bd_material.pk_material AND bd_material.pk_measdoc = bd_measdoc.pk_measdoc AND bd_material.pk_marbasclass = bd_marbasclass.pk_marbasclass AND ic_finprodin_h.pk_org = org_orgs.pk_org AND org_orgs.code = ? AND  ic_finprodin_h.dr=0 and ic_finprodin_b.dr=0 AND to_date(ic_finprodin_h.dbilldate,'yyyy-mm-dd HH24:mi:ss') <= ? AND to_date(ic_finprodin_h.dbilldate,'yyyy-mm-dd HH24:mi:ss') >= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND EXISTS (SELECT 1 FROM bd_stordoc WHERE ic_finprodin_h.cwarehouseid = bd_stordoc.pk_stordoc AND bd_stordoc.code = '" & Me.TxtCkdm.Text & "')", "") & ") ic_finprodin left join org_dept on org_dept.pk_dept = ic_finprodin.cdptid ORDER BY ic_finprodin.djh,ic_finprodin.xh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@NCAccountingBook", OleDbType.VarChar, 40).Value = NCAccountingBook
                rcOleDbCommand.Parameters.Add("@dateEnd", OleDbType.Date, 8).Value = dateEnd
                rcOleDbCommand.Parameters.Add("@dateBegin", OleDbType.Date, 8).Value = dateBegin
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("ic_finprodin") IsNot Nothing Then
                    Me.rcDataset.Tables("ic_finprodin").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "ic_finprodin")
                Me.ProgressBar1.Maximum = rcDataset.Tables("ic_finprodin").Rows.Count
            Catch ex As Exception
                MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                NCOleDbConn.Close()
            End Try
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                If String.IsNullOrEmpty(Me.TxtCkdm.Text) Then
                    '序列删除再重建
                    rcOleDbCommand.CommandText = "DROP SEQUENCE SCRK" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "CREATE SEQUENCE SCRK" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0") & " INCREMENT BY 1 START WITH 1 MAXVALUE 99999 MINVALUE 1 NOCYCLE NOCACHE NOORDER"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    '更新单据号至0
                    rcOleDbCommand.CommandText = "UPDATE rc_lx SET pzno" & Me.NudMonth.Value.ToString.PadLeft(2, "0") & " = 0 WHERE kjnd = ? AND pzlxdm = 'SCRK'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '删除历史单据
                rcOleDbCommand.CommandText = "DELETE FROM inv_rkd WHERE SUBSTR(djh,1,10)= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND ckdm ='" & Me.TxtCkdm.Text & "'", "")
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 10).Value = "SCRK" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                Me.ProgressBar1.Maximum = rcDataset.Tables("ic_finprodin").Rows.Count
                Dim oldStrDjh As String = ""
                Dim blnNew As Boolean = False
                For i = 0 To rcDataset.Tables("ic_finprodin").Rows.Count - 1
                    If oldStrDjh <> rcDataset.Tables("ic_finprodin").Rows(i).Item("djh") Then
                        blnNew = True
                        oldStrDjh = rcDataset.Tables("ic_finprodin").Rows(i).Item("djh")
                    Else
                        blnNew = False
                    End If
                    Me.ProgressBar1.Value = i + 1
                    rcOleDbCommand.CommandType = CommandType.StoredProcedure
                    rcOleDbCommand.CommandText = "USP3_SAVE_INV_RKD"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                    rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = "SCRK" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0") & Mid(rcDataset.Tables("ic_finprodin").Rows(i).Item("djh"), rcDataset.Tables("ic_finprodin").Rows(i).Item("djh").ToString.Length - 4, 5)
                    rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                    rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = 1 'IIf(blnNew, 1, rcDataset.Tables("ic_finprodin").Rows(i).Item("xh"))
                    rcOleDbCommand.Parameters.Add("@paraDateRkrq", OleDbType.Date, 8).Value = rcDataset.Tables("ic_finprodin").Rows(i).Item("rkrq")
                    rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                    rcOleDbCommand.Parameters.Add("@paraStrZydm", OleDbType.VarChar, 12).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrZymc", OleDbType.VarChar, 30).Value = "~"
                    rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_finprodin").Rows(i).Item("bmdm")
                    rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("ic_finprodin").Rows(i).Item("bmmc")
                    rcOleDbCommand.Parameters.Add("@ParaStrCkdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_finprodin").Rows(i).Item("ckdm")
                    rcOleDbCommand.Parameters.Add("@paraStrCkmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("ic_finprodin").Rows(i).Item("ckmc")
                    rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("ic_finprodin").Rows(i).Item("cpdm")
                    rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("ic_finprodin").Rows(i).Item("cpmc")
                    rcOleDbCommand.Parameters.Add("@paraStrHth", OleDbType.VarChar, 30).Value = ""
                    rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("ic_finprodin").Rows(i).Item("sl")
                    rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = rcDataset.Tables("ic_finprodin").Rows(i).Item("dw")
                    rcOleDbCommand.Parameters.Add("@paraDblMjsl", OleDbType.Numeric, 18).Value = 0.0
                    rcOleDbCommand.Parameters.Add("@paraDblFzsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("ic_finprodin").Rows(i).Item("zl")
                    rcOleDbCommand.Parameters.Add("@paraStrFzdw", OleDbType.VarChar, 8).Value = "KG"
                    rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = rcDataset.Tables("ic_finprodin").Rows(i).Item("dj")
                    rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("ic_finprodin").Rows(i).Item("je")
                    rcOleDbCommand.Parameters.Add("@paraStrRkmemo", OleDbType.VarChar, 50).Value = rcDataset.Tables("ic_finprodin").Rows(i).Item("djh") & " " & rcDataset.Tables("ic_finprodin").Rows(i).Item("vbatchcode") & " " & rcDataset.Tables("ic_finprodin").Rows(i).Item("rkmemo")
                    rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                    rcOleDbCommand.Parameters.Add("@paraCbill_bid", OleDbType.VarChar, 50).Value = rcDataset.Tables("ic_finprodin").Rows(i).Item("cgeneralbid")
                    rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                    rcOleDbCommand.ExecuteNonQuery()
                    If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                        If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                            MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value + rcDataset.Tables("ic_finprodin").Rows(i).Item("djh"), MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                            Return
                        End If
                    End If
                    '检测物料编码
                    If rcDataset.Tables("ic_finprodin").Rows(i).Item("cpdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT cpdm FROM rc_cpxx WHERE cpdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("ic_finprodin").Rows(i).Item("cpdm")
                        If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                            rcDataset.Tables("rc_cpxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
                        If rcDataset.Tables("rc_cpxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_cpxx (lbdm,cpdm,cpmc,dw) VALUES (?,?,?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_finprodin").Rows(i).Item("lbdm")
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("ic_finprodin").Rows(i).Item("cpdm")
                            rcOleDbCommand.Parameters.Add("@cpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("ic_finprodin").Rows(i).Item("cpmc")
                            rcOleDbCommand.Parameters.Add("@dw", OleDbType.VarChar, 8).Value = rcDataset.Tables("ic_finprodin").Rows(i).Item("dw")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    '检测仓库编码
                    If rcDataset.Tables("ic_finprodin").Rows(i).Item("ckdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT ckdm FROM rc_ckxx WHERE ckdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_finprodin").Rows(i).Item("ckdm")
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_ckxx") IsNot Nothing Then
                            rcDataset.Tables("rc_ckxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_ckxx")
                        If rcDataset.Tables("rc_ckxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_ckxx (ckdm,ckmc) VALUES (?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_finprodin").Rows(i).Item("ckdm")
                            rcOleDbCommand.Parameters.Add("@ckmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("ic_finprodin").Rows(i).Item("ckmc")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    '检测部门编码
                    If rcDataset.Tables("ic_finprodin").Rows(i).Item("bmdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT bmdm FROM rc_bmxx WHERE bmdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_finprodin").Rows(i).Item("bmdm")
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_bmxx") IsNot Nothing Then
                            rcDataset.Tables("rc_bmxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_bmxx")
                        If rcDataset.Tables("rc_bmxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_bmxx (bmdm,bmmc) VALUES (?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_finprodin").Rows(i).Item("bmdm")
                            rcOleDbCommand.Parameters.Add("@bmmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("ic_finprodin").Rows(i).Item("bmmc")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If

                Next
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

        '委外加工入库
        If Me.ChbInvRkd2.Checked Then
            '读取委外加工入库
            Try
                NCOleDbConn.Open()
                rcOleDbCommand.Connection = NCOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT ic_subcontin.pk_org,ic_subcontin.djh,ic_subcontin.xh,ic_subcontin.rkrq,ic_subcontin.cwarehouseid,ic_subcontin.ckdm,ic_subcontin.ckmc,ic_subcontin.cdptid,NVL(org_dept.code,'~') AS bmdm,NVL(org_dept.name,'~') AS bmmc,ic_subcontin.pk_marbasclass,ic_subcontin.lbdm,ic_subcontin.cmaterialvid,ic_subcontin.cpdm,ic_subcontin.cpmc,ic_subcontin.pk_measdoc,ic_subcontin.dw,ic_subcontin.vbatchcode,ic_subcontin.nassistnum,ic_subcontin.nnum AS sl,ic_subcontin.nweight AS zl,ic_subcontin.ncostprice AS dj,ic_subcontin.ncostmny AS je,ic_subcontin.rkmemo,ic_subcontin.cgeneralbid FROM (select ic_subcontin_h.pk_org,ic_subcontin_h.vbillcode AS djh,ic_subcontin_b.crowno AS xh,ic_subcontin_h.dbilldate AS rkrq,ic_subcontin_h.cwarehouseid,bd_stordoc.code AS ckdm,bd_stordoc.name AS ckmc,ic_subcontin_h.cdptid,bd_material.pk_marbasclass,bd_marbasclass.code AS lbdm,ic_subcontin_b.cmaterialvid,bd_material.code AS cpdm,bd_material.name || ',' || bd_material.materialtype || ',' || bd_material.materialspec AS cpmc,bd_material.pk_measdoc,bd_measdoc.name AS dw,ic_subcontin_b.vbatchcode,ic_subcontin_b.nassistnum,ic_subcontin_b.nnum,ic_subcontin_b.nweight,ic_subcontin_b.ncostprice,ic_subcontin_b.ncostmny,ic_subcontin_b.vnotebody AS rkmemo,ic_subcontin_b.cgeneralbid from ic_subcontin_h,ic_subcontin_b,bd_stordoc,bd_material,bd_measdoc,bd_marbasclass,org_orgs WHERE ic_subcontin_h.cgeneralhid = ic_subcontin_b.cgeneralhid AND ic_subcontin_h.cwarehouseid = bd_stordoc.pk_stordoc AND ic_subcontin_b.cmaterialvid = bd_material.pk_material AND bd_material.pk_measdoc = bd_measdoc.pk_measdoc AND bd_material.pk_marbasclass = bd_marbasclass.pk_marbasclass AND ic_subcontin_h.pk_org = org_orgs.pk_org AND org_orgs.code = ? AND  ic_subcontin_h.dr=0 and ic_subcontin_b.dr=0 AND to_date(ic_subcontin_h.dbilldate,'yyyy-mm-dd HH24:mi:ss') <= ? AND to_date(ic_subcontin_h.dbilldate,'yyyy-mm-dd HH24:mi:ss') >= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND EXISTS (SELECT 1 FROM bd_stordoc WHERE ic_subcontin_h.cwarehouseid = bd_stordoc.pk_stordoc AND bd_stordoc.code = '" & Me.TxtCkdm.Text & "')", "") & ") ic_subcontin left join org_dept on org_dept.pk_dept = ic_subcontin.cdptid ORDER BY ic_subcontin.djh,ic_subcontin.xh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@NCAccountingBook", OleDbType.VarChar, 40).Value = NCAccountingBook
                rcOleDbCommand.Parameters.Add("@dateEnd", OleDbType.Date, 8).Value = dateEnd
                rcOleDbCommand.Parameters.Add("@dateBegin", OleDbType.Date, 8).Value = dateBegin
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("ic_subcontin") IsNot Nothing Then
                    Me.rcDataset.Tables("ic_subcontin").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "ic_subcontin")
                Me.ProgressBar1.Maximum = rcDataset.Tables("ic_subcontin").Rows.Count
            Catch ex As Exception
                MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                NCOleDbConn.Close()
            End Try
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                If String.IsNullOrEmpty(Me.TxtCkdm.Text) Then
                    '序列删除再重建
                    rcOleDbCommand.CommandText = "DROP SEQUENCE WWRK" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "CREATE SEQUENCE WWRK" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0") & " INCREMENT BY 1 START WITH 1 MAXVALUE 99999 MINVALUE 1 NOCYCLE NOCACHE NOORDER"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    '更新单据号至0
                    rcOleDbCommand.CommandText = "UPDATE rc_lx SET pzno" & Me.NudMonth.Value.ToString.PadLeft(2, "0") & " = 0 WHERE kjnd = ? AND pzlxdm = 'WWRK'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '删除历史单据
                rcOleDbCommand.CommandText = "DELETE FROM inv_rkd WHERE SUBSTR(djh,1,10)= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND ckdm ='" & Me.TxtCkdm.Text & "'", "")
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 10).Value = "WWRK" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                Me.ProgressBar1.Maximum = rcDataset.Tables("ic_subcontin").Rows.Count
                Dim oldStrDjh As String = ""
                Dim blnNew As Boolean = False
                For i = 0 To rcDataset.Tables("ic_subcontin").Rows.Count - 1
                    If oldStrDjh <> rcDataset.Tables("ic_subcontin").Rows(i).Item("djh") Then
                        blnNew = True
                        oldStrDjh = rcDataset.Tables("ic_subcontin").Rows(i).Item("djh")
                    Else
                        blnNew = False
                    End If
                    Me.ProgressBar1.Value = i + 1
                    rcOleDbCommand.CommandType = CommandType.StoredProcedure
                    rcOleDbCommand.CommandText = "USP3_SAVE_INV_RKD"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                    rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = "WWRK" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0") & Mid(rcDataset.Tables("ic_subcontin").Rows(i).Item("djh"), rcDataset.Tables("ic_subcontin").Rows(i).Item("djh").ToString.Length - 4, 5)
                    rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                    rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = 1 'IIf(blnNew, 1, rcDataset.Tables("ic_subcontin").Rows(i).Item("xh"))
                    rcOleDbCommand.Parameters.Add("@paraDateRkrq", OleDbType.Date, 8).Value = rcDataset.Tables("ic_subcontin").Rows(i).Item("rkrq")
                    rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                    rcOleDbCommand.Parameters.Add("@paraStrZydm", OleDbType.VarChar, 12).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrZymc", OleDbType.VarChar, 30).Value = "~"
                    rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_subcontin").Rows(i).Item("bmdm")
                    rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("ic_subcontin").Rows(i).Item("bmmc")
                    rcOleDbCommand.Parameters.Add("@ParaStrCkdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_subcontin").Rows(i).Item("ckdm")
                    rcOleDbCommand.Parameters.Add("@paraStrCkmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("ic_subcontin").Rows(i).Item("ckmc")
                    rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("ic_subcontin").Rows(i).Item("cpdm")
                    rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("ic_subcontin").Rows(i).Item("cpmc")
                    rcOleDbCommand.Parameters.Add("@paraStrHth", OleDbType.VarChar, 30).Value = ""
                    rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("ic_subcontin").Rows(i).Item("sl")
                    rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = rcDataset.Tables("ic_subcontin").Rows(i).Item("dw")
                    rcOleDbCommand.Parameters.Add("@paraDblMjsl", OleDbType.Numeric, 18).Value = 0.0
                    rcOleDbCommand.Parameters.Add("@paraDblFzsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("ic_subcontin").Rows(i).Item("zl")
                    rcOleDbCommand.Parameters.Add("@paraStrFzdw", OleDbType.VarChar, 8).Value = "KG"
                    rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = rcDataset.Tables("ic_subcontin").Rows(i).Item("dj")
                    rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("ic_subcontin").Rows(i).Item("je")
                    rcOleDbCommand.Parameters.Add("@paraStrRkmemo", OleDbType.VarChar, 50).Value = rcDataset.Tables("ic_subcontin").Rows(i).Item("djh") & " " & rcDataset.Tables("ic_subcontin").Rows(i).Item("vbatchcode") & " " & rcDataset.Tables("ic_subcontin").Rows(i).Item("rkmemo")
                    rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                    rcOleDbCommand.Parameters.Add("@paraCbill_bid", OleDbType.VarChar, 50).Value = rcDataset.Tables("ic_subcontin").Rows(i).Item("cgeneralbid")
                    rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                    rcOleDbCommand.ExecuteNonQuery()
                    If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                        If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                            MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value + rcDataset.Tables("ic_subcontin").Rows(i).Item("djh"), MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                            Return
                        End If
                    End If
                    '检测物料编码
                    If rcDataset.Tables("ic_subcontin").Rows(i).Item("cpdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT cpdm FROM rc_cpxx WHERE cpdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("ic_subcontin").Rows(i).Item("cpdm")
                        If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                            rcDataset.Tables("rc_cpxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
                        If rcDataset.Tables("rc_cpxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_cpxx (lbdm,cpdm,cpmc,dw) VALUES (?,?,?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_subcontin").Rows(i).Item("lbdm")
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("ic_subcontin").Rows(i).Item("cpdm")
                            rcOleDbCommand.Parameters.Add("@cpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("ic_subcontin").Rows(i).Item("cpmc")
                            rcOleDbCommand.Parameters.Add("@dw", OleDbType.VarChar, 8).Value = rcDataset.Tables("ic_subcontin").Rows(i).Item("dw")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    '检测仓库编码
                    If rcDataset.Tables("ic_subcontin").Rows(i).Item("ckdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT ckdm FROM rc_ckxx WHERE ckdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_subcontin").Rows(i).Item("ckdm")
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_ckxx") IsNot Nothing Then
                            rcDataset.Tables("rc_ckxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_ckxx")
                        If rcDataset.Tables("rc_ckxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_ckxx (ckdm,ckmc) VALUES (?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_subcontin").Rows(i).Item("ckdm")
                            rcOleDbCommand.Parameters.Add("@ckmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("ic_subcontin").Rows(i).Item("ckmc")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                Next
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

        '销售出库
        If Me.ChbOeXsd.Checked Then
            '读取销售出库
            Try
                NCOleDbConn.Open()
                rcOleDbCommand.Connection = NCOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT ic_saleout.pk_org,ic_saleout.djh,ic_saleout.xh,ic_saleout.xsrq,ic_saleout.ccustomerid,ic_saleout.khdm,ic_saleout.khmc,ic_saleout.cwarehouseid,ic_saleout.ckdm,ic_saleout.ckmc,ic_saleout.cdptid,NVL(org_dept.code,'~') AS bmdm,NVL(org_dept.name,'~') AS bmmc,ic_saleout.pk_marbasclass,ic_saleout.lbdm,ic_saleout.cmaterialvid,ic_saleout.cpdm,ic_saleout.cpmc,ic_saleout.pk_measdoc,ic_saleout.dw,ic_saleout.vbatchcode,ic_saleout.nassistnum,ic_saleout.nnum AS sl,ic_saleout.nweight AS zl,ic_saleout.nprice AS dj,ic_saleout.ntaxprice AS hsdj,ic_saleout.nmny AS je,ic_saleout.ntaxrate AS shlv,ic_saleout.ntax AS se,ic_saleout.rkmemo,ic_saleout.cgeneralbid FROM (select ic_saleout_h.pk_org,ic_saleout_h.vbillcode AS djh,ic_saleout_b.crowno AS xh,ic_saleout_b.dbizdate AS xsrq,ic_saleout_h.ccustomerid,bd_customer.code AS khdm,bd_customer.name AS khmc,ic_saleout_h.cwarehouseid,bd_stordoc.code AS ckdm,bd_stordoc.name AS ckmc,ic_saleout_h.cdptid,bd_material.pk_marbasclass,bd_marbasclass.pk_marbasclass AS lbdm,ic_saleout_b.cmaterialvid,bd_material.code AS cpdm,bd_material.name || ',' || bd_material.materialtype || ',' || bd_material.materialspec AS cpmc,bd_material.pk_measdoc,bd_measdoc.name AS dw,ic_saleout_b.vbatchcode,ic_saleout_b.nassistnum,ic_saleout_b.nnum,ic_saleout_b.nweight,ic_saleout_b.nprice,ic_saleout_b.ntaxprice,ic_saleout_b.nmny,ic_saleout_b.ntaxrate,ic_saleout_b.ntax,ic_saleout_b.vnotebody AS rkmemo,ic_saleout_b.cgeneralbid FROM ic_saleout_h,ic_saleout_b,bd_stordoc,bd_material,bd_measdoc,bd_marbasclass,org_orgs,bd_customer where ic_saleout_h.cgeneralhid = ic_saleout_b.cgeneralhid AND ic_saleout_h.cwarehouseid = bd_stordoc.pk_stordoc AND ic_saleout_b.cmaterialvid = bd_material.pk_material AND bd_material.pk_measdoc = bd_measdoc.pk_measdoc AND bd_material.pk_marbasclass = bd_marbasclass.pk_marbasclass AND ic_saleout_h.pk_org = org_orgs.pk_org AND org_orgs.code = ? AND ic_saleout_h.ccustomerid = bd_customer.pk_customer AND ic_saleout_h.dr=0 and ic_saleout_b.dr=0 AND to_date(ic_saleout_b.dbizdate,'yyyy-mm-dd HH24:mi:ss') <= ? AND to_date(ic_saleout_b.dbizdate,'yyyy-mm-dd HH24:mi:ss') >= ?) ic_saleout left join org_dept on org_dept.pk_dept = ic_saleout.cdptid ORDER BY ic_saleout.djh,ic_saleout.xh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@NCAccountingBook", OleDbType.VarChar, 40).Value = NCAccountingBook
                rcOleDbCommand.Parameters.Add("@dateEnd", OleDbType.Date, 8).Value = dateEnd
                rcOleDbCommand.Parameters.Add("@dateBegin", OleDbType.Date, 8).Value = dateBegin
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("ic_saleout") IsNot Nothing Then
                    Me.rcDataset.Tables("ic_saleout").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "ic_saleout")
                Me.ProgressBar1.Maximum = rcDataset.Tables("ic_saleout").Rows.Count
            Catch ex As Exception
                MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                NCOleDbConn.Close()
            End Try
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                '序列删除再重建
                rcOleDbCommand.CommandText = "DROP SEQUENCE XSCK" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "CREATE SEQUENCE XSCK" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0") & " INCREMENT BY 1 START WITH 1 MAXVALUE 99999 MINVALUE 1 NOCYCLE NOCACHE NOORDER"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '更新单据号至0
                rcOleDbCommand.CommandText = "UPDATE rc_lx SET pzno" & Me.NudMonth.Value.ToString.PadLeft(2, "0") & " = 0 WHERE kjnd = ? AND pzlxdm = 'XSCK'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                rcOleDbCommand.ExecuteNonQuery()
                '删除历史单据
                rcOleDbCommand.CommandText = "DELETE FROM oe_xsd WHERE SUBSTR(djh,5,6)= ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                Me.ProgressBar1.Maximum = rcDataset.Tables("ic_saleout").Rows.Count
                'Dim oldStrDjh As String = ""
                'Dim blnNew As Boolean = False
                For i = 0 To rcDataset.Tables("ic_saleout").Rows.Count - 1
                    'If oldStrDjh <> rcDataset.Tables("ic_saleout").Rows(i).Item("djh") Then
                    '    blnNew = True
                    '    oldStrDjh = rcDataset.Tables("ic_saleout").Rows(i).Item("djh")
                    'Else
                    '    blnNew = False
                    'End If
                    Me.ProgressBar1.Value = i + 1
                    rcOleDbCommand.CommandType = CommandType.StoredProcedure
                    rcOleDbCommand.CommandText = "USP3_SAVE_OE_XSD"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                    rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = "XSCK" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0") & Mid(rcDataset.Tables("ic_saleout").Rows(i).Item("djh"), rcDataset.Tables("ic_saleout").Rows(i).Item("djh").ToString.Length - 4, 5)
                    rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                    rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = 1 'IIf(blnNew, 1, rcDataset.Tables("ic_saleout").Rows(i).Item("xh"))
                    rcOleDbCommand.Parameters.Add("@paraDateXsrq", OleDbType.Date, 8).Value = rcDataset.Tables("ic_saleout").Rows(i).Item("xsrq")
                    rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                    rcOleDbCommand.Parameters.Add("@paraStrZydm", OleDbType.VarChar, 12).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrZymc", OleDbType.VarChar, 30).Value = "~"
                    rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_saleout").Rows(i).Item("khdm")
                    rcOleDbCommand.Parameters.Add("@paraStrKhmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("ic_saleout").Rows(i).Item("khmc")
                    rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_saleout").Rows(i).Item("bmdm")
                    rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("ic_saleout").Rows(i).Item("bmmc")
                    rcOleDbCommand.Parameters.Add("@ParaStrCkdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_saleout").Rows(i).Item("ckdm")
                    rcOleDbCommand.Parameters.Add("@paraStrCkmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("ic_saleout").Rows(i).Item("ckmc")
                    rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("ic_saleout").Rows(i).Item("cpdm")
                    rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("ic_saleout").Rows(i).Item("cpmc")
                    rcOleDbCommand.Parameters.Add("@paraStrHth", OleDbType.VarChar, 30).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrKhddh", OleDbType.VarChar, 30).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrKhlh", OleDbType.VarChar, 30).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("ic_saleout").Rows(i).Item("sl")
                    rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = rcDataset.Tables("ic_saleout").Rows(i).Item("dw")
                    rcOleDbCommand.Parameters.Add("@paraDblMjsl", OleDbType.Numeric, 18).Value = 0.0
                    rcOleDbCommand.Parameters.Add("@paraDblFzsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("ic_saleout").Rows(i).Item("zl")
                    rcOleDbCommand.Parameters.Add("@paraStrFzdw", OleDbType.VarChar, 8).Value = "KG"
                    rcOleDbCommand.Parameters.Add("@paraIntJs", OleDbType.Integer, 12).Value = 0
                    rcOleDbCommand.Parameters.Add("@paraDblLt", OleDbType.Numeric, 18).Value = 0.0
                    rcOleDbCommand.Parameters.Add("@paraIntTs", OleDbType.Integer, 12).Value = 0
                    rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = rcDataset.Tables("ic_saleout").Rows(i).Item("dj")
                    rcOleDbCommand.Parameters.Add("@paraDblHsdj", OleDbType.Numeric, 18).Value = rcDataset.Tables("ic_saleout").Rows(i).Item("hsdj")
                    rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("ic_saleout").Rows(i).Item("je")
                    rcOleDbCommand.Parameters.Add("@paraDblShlv", OleDbType.Numeric, 6).Value = rcDataset.Tables("ic_saleout").Rows(i).Item("shlv")
                    rcOleDbCommand.Parameters.Add("@paraDblSe", OleDbType.Numeric, 14).Value = rcDataset.Tables("ic_saleout").Rows(i).Item("se")
                    rcOleDbCommand.Parameters.Add("@paraStrXsmemo", OleDbType.VarChar, 50).Value = rcDataset.Tables("ic_saleout").Rows(i).Item("djh") & " " & rcDataset.Tables("ic_saleout").Rows(i).Item("vbatchcode") & " " & rcDataset.Tables("ic_saleout").Rows(i).Item("rkmemo")
                    rcOleDbCommand.Parameters.Add("@paraStrDdDjh", OleDbType.VarChar, 15).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraIntDdXh", OleDbType.Integer, 4).Value = 0
                    rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                    rcOleDbCommand.Parameters.Add("@paraCbill_bid", OleDbType.VarChar, 20).Value = rcDataset.Tables("ic_saleout").Rows(i).Item("cgeneralbid")
                    rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                    rcOleDbCommand.ExecuteNonQuery()
                    If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                        If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                            MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value + rcDataset.Tables("ic_saleout").Rows(i).Item("djh"), MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                            Return
                        End If
                    End If
                    '检测客户编码
                    If rcDataset.Tables("ic_saleout").Rows(i).Item("khdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT khdm FROM rc_khxx WHERE khdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("ic_saleout").Rows(i).Item("khdm")
                        If rcDataset.Tables("rc_khxx") IsNot Nothing Then
                            rcDataset.Tables("rc_khxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_khxx")
                        If rcDataset.Tables("rc_khxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_khxx (khdm,khmc,zczb) VALUES (?,?,0)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("ic_saleout").Rows(i).Item("khdm")
                            rcOleDbCommand.Parameters.Add("@khmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("ic_saleout").Rows(i).Item("khmc")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    '检测物料编码
                    If rcDataset.Tables("ic_saleout").Rows(i).Item("cpdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT cpdm FROM rc_cpxx WHERE cpdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("ic_saleout").Rows(i).Item("cpdm")
                        If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                            rcDataset.Tables("rc_cpxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
                        If rcDataset.Tables("rc_cpxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_cpxx (lbdm,cpdm,cpmc,dw) VALUES (?,?,?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_saleout").Rows(i).Item("lbdm")
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("ic_saleout").Rows(i).Item("cpdm")
                            rcOleDbCommand.Parameters.Add("@cpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("ic_saleout").Rows(i).Item("cpmc")
                            rcOleDbCommand.Parameters.Add("@dw", OleDbType.VarChar, 8).Value = rcDataset.Tables("ic_saleout").Rows(i).Item("dw")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    '检测仓库编码
                    If rcDataset.Tables("ic_saleout").Rows(i).Item("ckdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT ckdm FROM rc_ckxx WHERE ckdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_saleout").Rows(i).Item("ckdm")
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_ckxx") IsNot Nothing Then
                            rcDataset.Tables("rc_ckxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_ckxx")
                        If rcDataset.Tables("rc_ckxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_ckxx (ckdm,ckmc) VALUES (?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_saleout").Rows(i).Item("ckdm")
                            rcOleDbCommand.Parameters.Add("@ckmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("ic_saleout").Rows(i).Item("ckmc")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                Next
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
        '采购入库
        If Me.ChbPoRkd.Checked Then
            '读取采购入库
            Try
                NCOleDbConn.Open()
                rcOleDbCommand.Connection = NCOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT ic_purchasein.pk_org,ic_purchasein.djh,ic_purchasein.xh,ic_purchasein.rkrq,ic_purchasein.cvendorid,ic_purchasein.csdm,ic_purchasein.csmc,ic_purchasein.cwarehouseid,ic_purchasein.ckdm,ic_purchasein.ckmc,ic_purchasein.cdptid,NVL(org_dept.code,'~') AS bmdm,NVL(org_dept.name,'~') AS bmmc,ic_purchasein.pk_marbasclass,ic_purchasein.lbdm,ic_purchasein.cmaterialvid,ic_purchasein.cpdm,ic_purchasein.cpmc,ic_purchasein.pk_measdoc,ic_purchasein.dw,ic_purchasein.vbatchcode,ic_purchasein.nassistnum,ic_purchasein.nnum AS sl,ic_purchasein.nweight AS zl,ic_purchasein.dj,ic_purchasein.hsdj,ic_purchasein.je,ic_purchasein.shlv,ic_purchasein.se,ic_purchasein.rkmemo,ic_purchasein.cgeneralbid FROM (select ic_purchasein_h.pk_org,ic_purchasein_h.vbillcode AS djh,ic_purchasein_b.crowno AS xh,ic_purchasein_h.dbilldate AS rkrq,ic_purchasein_h.cvendorid,bd_supplier.code AS csdm,bd_supplier.name AS csmc,ic_purchasein_h.cwarehouseid,bd_stordoc.code AS ckdm,bd_stordoc.name AS ckmc,ic_purchasein_h.cdptid,bd_material.pk_marbasclass,bd_marbasclass.code AS lbdm,ic_purchasein_b.cmaterialvid,bd_material.code AS cpdm,bd_material.name || ',' || bd_material.materialtype || ',' || bd_material.materialspec AS cpmc,bd_material.pk_measdoc,bd_measdoc.name AS dw,ic_purchasein_b.vbatchcode,ic_purchasein_b.nassistnum,ic_purchasein_b.nnum,ic_purchasein_b.nweight,ic_purchasein_b.nqtnetprice AS dj,ic_purchasein_b.nqttaxnetprice AS hsdj,ic_purchasein_b.norigmny AS je,ic_purchasein_b.ntaxrate AS shlv,ic_purchasein_b.ntax AS se,ic_purchasein_b.vnotebody AS rkmemo,ic_purchasein_b.cgeneralbid from ic_purchasein_h,ic_purchasein_b,bd_stordoc,bd_material,bd_measdoc,bd_marbasclass,org_orgs,bd_supplier where ic_purchasein_h.cgeneralhid = ic_purchasein_b.cgeneralhid AND ic_purchasein_h.cwarehouseid = bd_stordoc.pk_stordoc AND ic_purchasein_b.cmaterialvid = bd_material.pk_material AND bd_material.pk_measdoc = bd_measdoc.pk_measdoc AND bd_material.pk_marbasclass = bd_marbasclass.pk_marbasclass AND ic_purchasein_h.pk_org = org_orgs.pk_org AND org_orgs.code = ? AND ic_purchasein_h.cvendorid = bd_supplier.pk_supplier AND ic_purchasein_h.dr=0 and ic_purchasein_b.dr=0 AND to_date(ic_purchasein_h.dbilldate,'yyyy-mm-dd HH24:mi:ss') <= ? AND to_date(ic_purchasein_h.dbilldate,'yyyy-mm-dd HH24:mi:ss') >= ?) ic_purchasein left join org_dept on org_dept.pk_dept = ic_purchasein.cdptid ORDER BY ic_purchasein.djh,ic_purchasein.xh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@NCAccountingBook", OleDbType.VarChar, 40).Value = NCAccountingBook
                rcOleDbCommand.Parameters.Add("@dateEnd", OleDbType.Date, 8).Value = dateEnd
                rcOleDbCommand.Parameters.Add("@dateBegin", OleDbType.Date, 8).Value = dateBegin
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("ic_purchasein") IsNot Nothing Then
                    Me.rcDataset.Tables("ic_purchasein").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "ic_purchasein")
                Me.ProgressBar1.Maximum = rcDataset.Tables("ic_purchasein").Rows.Count
            Catch ex As Exception
                MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                NCOleDbConn.Close()
            End Try
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                '序列删除再重建
                rcOleDbCommand.CommandText = "DROP SEQUENCE CGRK" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "CREATE SEQUENCE CGRK" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0") & " INCREMENT BY 1 START WITH 1 MAXVALUE 99999 MINVALUE 1 NOCYCLE NOCACHE NOORDER"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '更新单据号至0
                rcOleDbCommand.CommandText = "UPDATE rc_lx SET pzno" & Me.NudMonth.Value.ToString.PadLeft(2, "0") & " = 0 WHERE kjnd = ? AND pzlxdm = 'CGRK'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                rcOleDbCommand.ExecuteNonQuery()
                '删除历史单据
                rcOleDbCommand.CommandText = "DELETE FROM po_rkd WHERE SUBSTR(djh,5,6)= ? AND SUBSTR(djh,1,4) = 'CGRK'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                Me.ProgressBar1.Maximum = rcDataset.Tables("ic_purchasein").Rows.Count
                'Dim oldStrDjh As String = ""
                'Dim blnNew As Boolean = False
                For i = 0 To rcDataset.Tables("ic_purchasein").Rows.Count - 1
                    'If oldStrDjh <> rcDataset.Tables("ic_purchasein").Rows(i).Item("djh") Then
                    '    blnNew = True
                    '    oldStrDjh = rcDataset.Tables("ic_purchasein").Rows(i).Item("djh")
                    'Else
                    '    blnNew = False
                    'End If
                    Me.ProgressBar1.Value = i + 1
                    rcOleDbCommand.CommandType = CommandType.StoredProcedure
                    rcOleDbCommand.CommandText = "USP3_SAVE_PO_RKD"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                    rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = "CGRK" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0") & Mid(rcDataset.Tables("ic_purchasein").Rows(i).Item("djh"), rcDataset.Tables("ic_purchasein").Rows(i).Item("djh").ToString.Length - 4, 5)
                    rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                    rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = 1 'IIf(blnNew, 1, rcDataset.Tables("ic_purchasein").Rows(i).Item("xh"))
                    rcOleDbCommand.Parameters.Add("@paraDateRkrq", OleDbType.Date, 8).Value = rcDataset.Tables("ic_purchasein").Rows(i).Item("rkrq")
                    rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                    rcOleDbCommand.Parameters.Add("@paraStrZydm", OleDbType.VarChar, 12).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrZymc", OleDbType.VarChar, 30).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_purchasein").Rows(i).Item("csdm")
                    rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("ic_purchasein").Rows(i).Item("csmc")
                    rcOleDbCommand.Parameters.Add("@paraStrYspz", OleDbType.VarChar, 12).Value = "~"
                    rcOleDbCommand.Parameters.Add("@ParaStrCkdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_purchasein").Rows(i).Item("ckdm")
                    rcOleDbCommand.Parameters.Add("@paraStrCkmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("ic_purchasein").Rows(i).Item("ckmc")
                    rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("ic_purchasein").Rows(i).Item("cpdm")
                    rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("ic_purchasein").Rows(i).Item("cpmc")
                    rcOleDbCommand.Parameters.Add("@paraStrKuwei", OleDbType.VarChar, 40).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrSgddh", OleDbType.VarChar, 20).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrPiHao", OleDbType.VarChar, 20).Value = rcDataset.Tables("ic_purchasein").Rows(i).Item("vbatchcode")
                    rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("ic_purchasein").Rows(i).Item("sl")
                    rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = rcDataset.Tables("ic_purchasein").Rows(i).Item("dw")
                    rcOleDbCommand.Parameters.Add("@paraDblMjsl", OleDbType.Numeric, 18).Value = 0.0
                    rcOleDbCommand.Parameters.Add("@paraDblFzsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("ic_purchasein").Rows(i).Item("zl")
                    rcOleDbCommand.Parameters.Add("@paraStrFzdw", OleDbType.VarChar, 8).Value = "KG"
                    rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = rcDataset.Tables("ic_purchasein").Rows(i).Item("dj")
                    rcOleDbCommand.Parameters.Add("@paraDblHsdj", OleDbType.Numeric, 18).Value = rcDataset.Tables("ic_purchasein").Rows(i).Item("hsdj")
                    rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("ic_purchasein").Rows(i).Item("je")
                    rcOleDbCommand.Parameters.Add("@paraDblShlv", OleDbType.Numeric, 6).Value = rcDataset.Tables("ic_purchasein").Rows(i).Item("shlv")
                    rcOleDbCommand.Parameters.Add("@paraDblSe", OleDbType.Numeric, 14).Value = rcDataset.Tables("ic_purchasein").Rows(i).Item("se")
                    rcOleDbCommand.Parameters.Add("@paraStrRkmemo", OleDbType.VarChar, 50).Value = rcDataset.Tables("ic_purchasein").Rows(i).Item("rkmemo")
                    rcOleDbCommand.Parameters.Add("@paraStrCgdDjh", OleDbType.VarChar, 15).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraIntCgdXh", OleDbType.Integer, 4).Value = 0
                    rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                    rcOleDbCommand.Parameters.Add("@paraCbill_bid", OleDbType.VarChar, 20).Value = rcDataset.Tables("ic_purchasein").Rows(i).Item("cgeneralbid")
                    rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                    rcOleDbCommand.ExecuteNonQuery()
                    If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                        If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                            MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                            Return
                        End If
                    End If
                    '检测供应商编码
                    If rcDataset.Tables("ic_purchasein").Rows(i).Item("csdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT csdm FROM rc_csxx WHERE csdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("ic_purchasein").Rows(i).Item("csdm")
                        If rcDataset.Tables("rc_csxx") IsNot Nothing Then
                            rcDataset.Tables("rc_csxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_csxx")
                        If rcDataset.Tables("rc_csxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_csxx (csdm,csmc,zczb) VALUES (?,?,0)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("ic_purchasein").Rows(i).Item("csdm")
                            rcOleDbCommand.Parameters.Add("@csmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("ic_purchasein").Rows(i).Item("csmc")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    '检测物料编码
                    If rcDataset.Tables("ic_purchasein").Rows(i).Item("cpdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT cpdm FROM rc_cpxx WHERE cpdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("ic_purchasein").Rows(i).Item("cpdm")
                        If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                            rcDataset.Tables("rc_cpxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
                        If rcDataset.Tables("rc_cpxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_cpxx (lbdm,cpdm,cpmc,dw) VALUES (?,?,?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_purchasein").Rows(i).Item("lbdm")
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("ic_purchasein").Rows(i).Item("cpdm")
                            rcOleDbCommand.Parameters.Add("@cpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("ic_purchasein").Rows(i).Item("cpmc")
                            rcOleDbCommand.Parameters.Add("@dw", OleDbType.VarChar, 8).Value = rcDataset.Tables("ic_purchasein").Rows(i).Item("dw")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    '检测仓库编码
                    If rcDataset.Tables("ic_purchasein").Rows(i).Item("ckdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT ckdm FROM rc_ckxx WHERE ckdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_purchasein").Rows(i).Item("ckdm")
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_ckxx") IsNot Nothing Then
                            rcDataset.Tables("rc_ckxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_ckxx")
                        If rcDataset.Tables("rc_ckxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_ckxx (ckdm,ckmc) VALUES (?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_purchasein").Rows(i).Item("ckdm")
                            rcOleDbCommand.Parameters.Add("@ckmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("ic_purchasein").Rows(i).Item("ckmc")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                Next
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
        '其它入库
        If Me.ChbQtrk.Checked Then
            '读取其它入库
            Try
                NCOleDbConn.Open()
                rcOleDbCommand.Connection = NCOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT ic_generalin.pk_org,ic_generalin.djh,ic_generalin.xh,ic_generalin.rkrq,ic_generalin.cwarehouseid,ic_generalin.ckdm,ic_generalin.ckmc,ic_generalin.cdptid,NVL(org_dept.code,'~') AS bmdm,NVL(org_dept.name,'~') AS bmmc,ic_generalin.pk_marbasclass,ic_generalin.lbdm,ic_generalin.cmaterialvid,ic_generalin.cpdm,ic_generalin.cpmc,ic_generalin.pk_measdoc,ic_generalin.dw,ic_generalin.vbatchcode,ic_generalin.nassistnum,ic_generalin.nnum AS sl,ic_generalin.nweight AS zl,ic_generalin.dj,ic_generalin.hsdj,ic_generalin.je,ic_generalin.shlv,ic_generalin.se,ic_generalin.rkmemo,ic_generalin.cgeneralbid FROM (select ic_generalin_h.pk_org,ic_generalin_h.vbillcode AS djh,ic_generalin_b.crowno AS xh,ic_generalin_h.dbilldate AS rkrq,ic_generalin_h.cwarehouseid,bd_stordoc.code AS ckdm,bd_stordoc.name AS ckmc,ic_generalin_h.cdptid,bd_material.pk_marbasclass,bd_marbasclass.code AS lbdm,ic_generalin_b.cmaterialvid,bd_material.code AS cpdm,bd_material.name || ',' || bd_material.materialtype || ',' || bd_material.materialspec AS cpmc,bd_material.pk_measdoc,bd_measdoc.name AS dw,ic_generalin_b.vbatchcode,ic_generalin_b.nassistnum,ic_generalin_b.nnum,ic_generalin_b.nweight,COALESCE(ic_generalin_b.ncostprice,0.0) AS dj,COALESCE(ic_generalin_b.ncostprice,0.0) AS hsdj,COALESCE(ic_generalin_b.ncostmny,0.0) AS je,0 AS shlv,0 AS se,ic_generalin_b.vnotebody AS rkmemo,ic_generalin_b.cgeneralbid from ic_generalin_h,ic_generalin_b,bd_stordoc,bd_material,bd_measdoc,bd_marbasclass,org_orgs where ic_generalin_h.cgeneralhid = ic_generalin_b.cgeneralhid AND ic_generalin_h.cwarehouseid = bd_stordoc.pk_stordoc AND ic_generalin_b.cmaterialvid = bd_material.pk_material AND bd_material.pk_measdoc = bd_measdoc.pk_measdoc AND bd_material.pk_marbasclass = bd_marbasclass.pk_marbasclass AND ic_generalin_h.pk_org = org_orgs.pk_org AND org_orgs.code = ? AND ic_generalin_h.dr=0 and ic_generalin_b.dr=0 AND to_date(ic_generalin_h.dbilldate,'yyyy-mm-dd HH24:mi:ss') <= ? AND to_date(ic_generalin_h.dbilldate,'yyyy-mm-dd HH24:mi:ss') >= ?) ic_generalin left join org_dept on org_dept.pk_dept = ic_generalin.cdptid ORDER BY ic_generalin.djh,ic_generalin.xh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@NCAccountingBook", OleDbType.VarChar, 40).Value = NCAccountingBook
                rcOleDbCommand.Parameters.Add("@dateEnd", OleDbType.Date, 8).Value = dateEnd
                rcOleDbCommand.Parameters.Add("@dateBegin", OleDbType.Date, 8).Value = dateBegin
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("ic_generalin") IsNot Nothing Then
                    Me.rcDataset.Tables("ic_generalin").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "ic_generalin")
                Me.ProgressBar1.Maximum = rcDataset.Tables("ic_generalin").Rows.Count
            Catch ex As Exception
                MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                NCOleDbConn.Close()
            End Try
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                '序列删除再重建
                rcOleDbCommand.CommandText = "DROP SEQUENCE RKTZ" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "CREATE SEQUENCE RKTZ" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0") & " INCREMENT BY 1 START WITH 1 MAXVALUE 99999 MINVALUE 1 NOCYCLE NOCACHE NOORDER"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '更新单据号至0
                rcOleDbCommand.CommandText = "UPDATE rc_lx SET pzno" & Me.NudMonth.Value.ToString.PadLeft(2, "0") & " = 0 WHERE kjnd = ? AND pzlxdm = 'RKTZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                rcOleDbCommand.ExecuteNonQuery()
                '删除历史单据
                rcOleDbCommand.CommandText = "DELETE FROM po_rkd WHERE SUBSTR(djh,5,6)= ? AND SUBSTR(djh,1,4) = 'RKTZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                Me.ProgressBar1.Maximum = rcDataset.Tables("ic_generalin").Rows.Count
                'Dim oldStrDjh As String = ""
                'Dim blnNew As Boolean = False
                For i = 0 To rcDataset.Tables("ic_generalin").Rows.Count - 1
                    'If oldStrDjh <> rcDataset.Tables("ic_generalin").Rows(i).Item("djh") Then
                    '    blnNew = True
                    '    oldStrDjh = rcDataset.Tables("ic_generalin").Rows(i).Item("djh")
                    'Else
                    '    blnNew = False
                    'End If
                    Me.ProgressBar1.Value = i + 1
                    rcOleDbCommand.CommandType = CommandType.StoredProcedure
                    rcOleDbCommand.CommandText = "USP3_SAVE_PO_RKD"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                    rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = "RKTZ" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0") & Mid(rcDataset.Tables("ic_generalin").Rows(i).Item("djh"), rcDataset.Tables("ic_generalin").Rows(i).Item("djh").ToString.Length - 4, 5)
                    rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                    rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = 1 'IIf(blnNew, 1, rcDataset.Tables("ic_generalin").Rows(i).Item("xh"))
                    rcOleDbCommand.Parameters.Add("@paraDateRkrq", OleDbType.Date, 8).Value = rcDataset.Tables("ic_generalin").Rows(i).Item("rkrq")
                    rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                    rcOleDbCommand.Parameters.Add("@paraStrZydm", OleDbType.VarChar, 12).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrZymc", OleDbType.VarChar, 30).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrYspz", OleDbType.VarChar, 12).Value = "~"
                    rcOleDbCommand.Parameters.Add("@ParaStrCkdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_generalin").Rows(i).Item("ckdm")
                    rcOleDbCommand.Parameters.Add("@paraStrCkmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("ic_generalin").Rows(i).Item("ckmc")
                    rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("ic_generalin").Rows(i).Item("cpdm")
                    rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("ic_generalin").Rows(i).Item("cpmc")
                    rcOleDbCommand.Parameters.Add("@paraStrKuwei", OleDbType.VarChar, 40).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrSgddh", OleDbType.VarChar, 20).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrPiHao", OleDbType.VarChar, 20).Value = rcDataset.Tables("ic_generalin").Rows(i).Item("vbatchcode")
                    rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("ic_generalin").Rows(i).Item("sl")
                    rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = rcDataset.Tables("ic_generalin").Rows(i).Item("dw")
                    rcOleDbCommand.Parameters.Add("@paraDblMjsl", OleDbType.Numeric, 18).Value = 0.0
                    rcOleDbCommand.Parameters.Add("@paraDblFzsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("ic_generalin").Rows(i).Item("zl")
                    rcOleDbCommand.Parameters.Add("@paraStrFzdw", OleDbType.VarChar, 8).Value = "KG"
                    rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = rcDataset.Tables("ic_generalin").Rows(i).Item("dj")
                    rcOleDbCommand.Parameters.Add("@paraDblHsdj", OleDbType.Numeric, 18).Value = rcDataset.Tables("ic_generalin").Rows(i).Item("hsdj")
                    rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("ic_generalin").Rows(i).Item("je")
                    rcOleDbCommand.Parameters.Add("@paraDblShlv", OleDbType.Numeric, 6).Value = rcDataset.Tables("ic_generalin").Rows(i).Item("shlv")
                    rcOleDbCommand.Parameters.Add("@paraDblSe", OleDbType.Numeric, 14).Value = rcDataset.Tables("ic_generalin").Rows(i).Item("se")
                    rcOleDbCommand.Parameters.Add("@paraStrRkmemo", OleDbType.VarChar, 50).Value = rcDataset.Tables("ic_generalin").Rows(i).Item("rkmemo")
                    rcOleDbCommand.Parameters.Add("@paraStrCgdDjh", OleDbType.VarChar, 15).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraIntCgdXh", OleDbType.Integer, 4).Value = 0
                    rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                    rcOleDbCommand.Parameters.Add("@paraCbill_bid", OleDbType.VarChar, 20).Value = rcDataset.Tables("ic_generalin").Rows(i).Item("cgeneralbid")
                    rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                    rcOleDbCommand.ExecuteNonQuery()
                    If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                        If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                            MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                            Return
                        End If
                    End If
                    '检测物料编码
                    If rcDataset.Tables("ic_generalin").Rows(i).Item("cpdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT cpdm FROM rc_cpxx WHERE cpdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("ic_generalin").Rows(i).Item("cpdm")
                        If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                            rcDataset.Tables("rc_cpxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
                        If rcDataset.Tables("rc_cpxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_cpxx (lbdm,cpdm,cpmc,dw) VALUES (?,?,?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_generalin").Rows(i).Item("lbdm")
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("ic_generalin").Rows(i).Item("cpdm")
                            rcOleDbCommand.Parameters.Add("@cpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("ic_generalin").Rows(i).Item("cpmc")
                            rcOleDbCommand.Parameters.Add("@dw", OleDbType.VarChar, 8).Value = rcDataset.Tables("ic_generalin").Rows(i).Item("dw")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    '检测仓库编码
                    If rcDataset.Tables("ic_generalin").Rows(i).Item("ckdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT ckdm FROM rc_ckxx WHERE ckdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_generalin").Rows(i).Item("ckdm")
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_ckxx") IsNot Nothing Then
                            rcDataset.Tables("rc_ckxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_ckxx")
                        If rcDataset.Tables("rc_ckxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_ckxx (ckdm,ckmc) VALUES (?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ic_generalin").Rows(i).Item("ckdm")
                            rcOleDbCommand.Parameters.Add("@ckmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("ic_generalin").Rows(i).Item("ckmc")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                Next
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

        '收款单
        '
        If Me.ChbSkd.Checked Then
            '写系统参数
            If Not String.IsNullOrEmpty(Me.ComboBox1.SelectedItem) Then
                Try
                    rcOleDbConn.Open()
                    rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.Transaction = rcOleDbTrans
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    '删除数据
                    rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = '收款单据表体售达方属性序号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                    rcOleDbCommand.ExecuteNonQuery()
                    '插入数据
                    rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'收款单据表体售达方属性序号',?,0)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                    rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 30).Value = Trim(Me.ComboBox1.SelectedItem)
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
            Try
                NCOleDbConn.Open()
                rcOleDbCommand.Connection = NCOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT ar_gatheritem.billno AS djh,ar_gatheritem.billdate AS skrq,ar_gatheritem.def" & Trim(Me.ComboBox1.SelectedItem.ToString) & " AS khid,bd_customer.code AS khdm,bd_customer.name AS khmc,ar_gatheritem.pk_balatype,bd_balatype.code AS jsfsdm,bd_balatype.name AS jsfsmc,ar_gatheritem.invoiceno AS yspz,ar_gatheritem.local_money_cr AS je,ar_gatheritem.scomment as skmemo FROM ar_gatherbill,ar_gatheritem,bd_balatype,bd_customer,org_orgs WHERE ar_gatherbill.billperiod = ? AND ar_gatherbill.billyear = ? AND ar_gatherbill.dr =0 AND ar_gatheritem.dr = 0 AND ar_gatherbill.pk_gatherbill = ar_gatheritem.pk_gatherbill AND ar_gatheritem.pk_balatype = bd_balatype.pk_balatype AND ar_gatheritem.def" & Me.ComboBox1.SelectedItem.ToString & " = bd_customer.pk_customer AND org_orgs.isbusinessunit = 'Y' AND ar_gatheritem.pk_org = org_orgs.pk_org AND org_orgs.code = ? ORDER BY ar_gatheritem.billno"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@period", OleDbType.VarChar, 2).Value = Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@year", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                rcOleDbCommand.Parameters.Add("@NCAccountingBook", OleDbType.VarChar, 40).Value = NCAccountingBook
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("ar_gatheritem") IsNot Nothing Then
                    Me.rcDataset.Tables("ar_gatheritem").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "ar_gatheritem")
                If Me.rcDataset.Tables("ar_gatheritem").Rows.Count = 0 Then
                    rcOleDbCommand.CommandText = "SELECT ar_gatheritem.billno AS djh,ar_gatheritem.billdate AS skrq,ar_gatheritem.ordercubasdoc AS khid,bd_customer.code AS khdm,bd_customer.name AS khmc,ar_gatheritem.pk_balatype,bd_balatype.code AS jsfsdm,bd_balatype.name AS jsfsmc,ar_gatheritem.invoiceno AS yspz,ar_gatheritem.local_money_cr AS je,ar_gatheritem.scomment as skmemo FROM ar_gatherbill,ar_gatheritem,bd_balatype,bd_customer,org_orgs WHERE ar_gatherbill.billperiod = ? AND ar_gatherbill.billyear = ? AND ar_gatherbill.dr =0 AND ar_gatheritem.dr = 0 AND ar_gatherbill.pk_gatherbill = ar_gatheritem.pk_gatherbill AND ar_gatheritem.pk_balatype = bd_balatype.pk_balatype AND ar_gatheritem.ordercubasdoc = bd_customer.pk_customer AND org_orgs.isbusinessunit = 'Y' AND ar_gatheritem.pk_org = org_orgs.pk_org AND org_orgs.code = ? ORDER BY ar_gatheritem.billno"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@period", OleDbType.VarChar, 2).Value = Me.NudMonth.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Add("@year", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                    rcOleDbCommand.Parameters.Add("@NCAccountingBook", OleDbType.VarChar, 40).Value = NCAccountingBook
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("ar_gatheritem") IsNot Nothing Then
                        Me.rcDataset.Tables("ar_gatheritem").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "ar_gatheritem")

                End If
                Me.ProgressBar1.Maximum = rcDataset.Tables("ar_gatheritem").Rows.Count
            Catch ex As Exception
                MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                NCOleDbConn.Close()
            End Try
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                '序列删除再重建
                rcOleDbCommand.CommandText = "DROP SEQUENCE SKDJ" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "CREATE SEQUENCE SKDJ" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0") & " INCREMENT BY 1 START WITH 1 MAXVALUE 99999 MINVALUE 1 NOCYCLE NOCACHE NOORDER"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '更新单据号至0
                rcOleDbCommand.CommandText = "UPDATE rc_lx SET pzno" & Me.NudMonth.Value.ToString.PadLeft(2, "0") & " = 0 WHERE kjnd = ? AND pzlxdm = 'SKDJ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                rcOleDbCommand.ExecuteNonQuery()
                '删除历史单据
                rcOleDbCommand.CommandText = "DELETE FROM ar_skd WHERE SUBSTR(djh,5,6)= ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                Me.ProgressBar1.Maximum = rcDataset.Tables("ar_gatheritem").Rows.Count
                For i = 0 To rcDataset.Tables("ar_gatheritem").Rows.Count - 1
                    Me.ProgressBar1.Value = i + 1
                    rcOleDbCommand.CommandType = CommandType.StoredProcedure
                    rcOleDbCommand.CommandText = "USP3_SAVE_AR_SKD"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                    rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = "SKDJ" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0") & i.ToString.PadLeft(5, "0")
                    rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                    rcOleDbCommand.Parameters.Add("@paraDateSkrq", OleDbType.Date, 8).Value = rcDataset.Tables("ar_gatheritem").Rows(i).Item("skrq")
                    rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ar_gatheritem").Rows(i).Item("khdm")
                    rcOleDbCommand.Parameters.Add("@paraStrKhmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("ar_gatheritem").Rows(i).Item("khmc")
                    rcOleDbCommand.Parameters.Add("@paraStrJsfsdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ar_gatheritem").Rows(i).Item("jsfsdm")
                    rcOleDbCommand.Parameters.Add("@paraStrJsfsmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("ar_gatheritem").Rows(i).Item("jsfsmc")
                    rcOleDbCommand.Parameters.Add("@paraStrKmdm", OleDbType.VarChar, 12).Value = ""
                    rcOleDbCommand.Parameters.Add("@paraStrKmmc", OleDbType.VarChar, 50).Value = ""
                    rcOleDbCommand.Parameters.Add("@paraStrYspz", OleDbType.VarChar, 30).Value = rcDataset.Tables("ar_gatheritem").Rows(i).Item("yspz")
                    rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("ar_gatheritem").Rows(i).Item("je")
                    rcOleDbCommand.Parameters.Add("@paraDblXsje", OleDbType.Numeric, 14).Value = 0
                    rcOleDbCommand.Parameters.Add("@paraStrSkmemo", OleDbType.VarChar, 50).Value = rcDataset.Tables("ar_gatheritem").Rows(i).Item("skmemo")
                    rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 10).Value = g_User_DspName
                    rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                    rcOleDbCommand.ExecuteNonQuery()
                    If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                        If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                            MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                            Return
                        End If
                    End If
                    '检测客户编码
                    If rcDataset.Tables("ar_gatheritem").Rows(i).Item("khdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT khdm FROM rc_khxx WHERE khdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("ar_gatheritem").Rows(i).Item("khdm")
                        If rcDataset.Tables("rc_khxx") IsNot Nothing Then
                            rcDataset.Tables("rc_khxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_khxx")
                        If rcDataset.Tables("rc_khxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_khxx (khdm,khmc) VALUES (?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("ar_gatheritem").Rows(i).Item("khdm")
                            rcOleDbCommand.Parameters.Add("@khmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("ar_gatheritem").Rows(i).Item("khmc")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    '检测结算方式编码
                    If rcDataset.Tables("ar_gatheritem").Rows(i).Item("jsfsdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT jsfsdm FROM rc_jsfs WHERE jsfsdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@jsfsdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ar_gatheritem").Rows(i).Item("jsfsdm")
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_jsfs") IsNot Nothing Then
                            rcDataset.Tables("rc_jsfs").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_jsfs")
                        If rcDataset.Tables("rc_jsfs").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_jsfs (jsfsdm,jsfsmc,bkywf) VALUES (?,?,0)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@jsfsdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("ar_gatheritem").Rows(i).Item("jsfsdm")
                            rcOleDbCommand.Parameters.Add("@jsfsmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("ar_gatheritem").Rows(i).Item("jsfsmc")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                Next
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
        '期初余额
        If Me.ChbQc.Checked Then
            Try
                NCOleDbConn.Open()
                rcOleDbCommand.Connection = NCOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT gl_kmyeba.*,'~' AS bmdm,'~' AS bmmc,'~' AS zydm,'~' AS zymc,'~' AS xmdm,'~' AS xmmc,'~' AS khdm,'~' AS khmc,'~' AS csdm,'~' AS csmc,'~' AS yhzh,'~' AS jxzh" &
                    ",CASE WHEN gl_freevalue.typevalue1 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue1,1,20) ELSE '~' END AS type1,CASE WHEN gl_freevalue.typevalue1 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue1,21,20) ELSE '~' END AS value1" &
                    ",CASE WHEN gl_freevalue.typevalue2 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue2,1,20) ELSE '~' END AS type2,CASE WHEN gl_freevalue.typevalue2 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue2,21,20) ELSE '~' END AS value2" &
                    ",CASE WHEN gl_freevalue.typevalue3 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue3,1,20) ELSE '~' END AS type3,CASE WHEN gl_freevalue.typevalue3 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue3,21,20) ELSE '~' END AS value3" &
                    ",CASE WHEN gl_freevalue.typevalue4 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue4,1,20) ELSE '~' END AS type4,CASE WHEN gl_freevalue.typevalue4 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue4,21,20) ELSE '~' END AS value4" &
                    ",CASE WHEN gl_freevalue.typevalue5 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue5,1,20) ELSE '~' END AS type5,CASE WHEN gl_freevalue.typevalue5 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue5,21,20) ELSE '~' END AS value5" &
                    ",CASE WHEN gl_freevalue.typevalue6 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue6,1,20) ELSE '~' END AS type6,CASE WHEN gl_freevalue.typevalue6 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue6,21,20) ELSE '~' END AS value6" &
                    ",CASE WHEN gl_freevalue.typevalue7 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue7,1,20) ELSE '~' END AS type7,CASE WHEN gl_freevalue.typevalue7 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue7,21,20) ELSE '~' END AS value7" &
                    ",CASE WHEN gl_freevalue.typevalue8 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue8,1,20) ELSE '~' END AS type8,CASE WHEN gl_freevalue.typevalue8 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue8,21,20) ELSE '~' END AS value8" &
                    ",CASE WHEN gl_freevalue.typevalue9 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue9,1,20) ELSE '~' END AS type9,CASE WHEN gl_freevalue.typevalue9 <> 'NN/A' THEN SUBSTR(gl_freevalue.typevalue9,21,20) ELSE '~' END AS value9 FROM" &
                    "(SELECT gl_balance.year,gl_balance.period,bd_account.code AS kmdm,bd_accasoa.name AS kmmc,gl_balance.assid,bd_currtype.code AS wbdm,gl_balance.debitamount jfwb,gl_balance.debitquantity jfsl,gl_balance.localdebitamount AS jfje,gl_balance.creditamount AS dfwb,gl_balance.creditquantity AS dfsl,gl_balance.localcreditamount AS dfje FROM gl_balance,bd_account,bd_accasoa,bd_currtype,org_accountingbook WHERE bd_accasoa.pk_accasoa = gl_balance.pk_accasoa AND bd_account.pk_account = bd_accasoa.pk_account AND bd_currtype.pk_currtype = gl_balance.pk_currtype AND gl_balance.pk_accountingbook = org_accountingbook.pk_accountingbook AND gl_balance.period = '00' AND gl_balance.year = ? AND org_accountingbook.code = ?) gl_kmyeba LEFT JOIN gl_freevalue ON gl_freevalue.freevalueid = gl_kmyeba.assid"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@year", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                rcOleDbCommand.Parameters.Add("@NCAccountingBook", OleDbType.VarChar, 40).Value = NCAccountingBook
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("gl_kmyeb") IsNot Nothing Then
                    Me.rcDataset.Tables("gl_kmyeb").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "gl_kmyeb")
                Me.ProgressBar1.Maximum = rcDataset.Tables("gl_kmyeb").Rows.Count
                For i = 0 To rcDataset.Tables("gl_kmyeb").Rows.Count - 1
                    Me.ProgressBar1.Value = i + 1
                    '辅助核算转换
                    For j = 1 To 8
                        If rcDataset.Tables("gl_kmyeb").Rows(i).Item("type" & j.ToString) <> "~" Then
                            rcOleDbCommand.CommandText = "SELECT code,name FROM bd_accassitem WHERE pk_accassitem = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@pk_accassitem", OleDbType.VarChar, 20).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("type" & j.ToString)
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("bd_accassitem") IsNot Nothing Then
                                Me.rcDataset.Tables("bd_accassitem").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "bd_accassitem")
                            If rcDataset.Tables("bd_accassitem").Rows.Count > 0 Then
                                rcDataset.Tables("gl_kmyeb").Rows(i).Item("type" & j.ToString) = rcDataset.Tables("bd_accassitem").Rows(0).Item("name")
                                Select Case rcDataset.Tables("bd_accassitem").Rows(0).Item("name")
                                    Case "部门" '0001
                                        rcOleDbCommand.CommandText = "SELECT code,name FROM org_orgs WHERE pk_org = ?"
                                        rcOleDbCommand.Parameters.Clear()
                                        rcOleDbCommand.Parameters.Add("@pk_org", OleDbType.VarChar, 20).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("value" & j.ToString)
                                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                        If rcDataset.Tables("org_orgs") IsNot Nothing Then
                                            rcDataset.Tables("org_orgs").Clear()
                                        End If
                                        rcOleDbDataAdpt.Fill(rcDataset, "org_orgs")
                                        If rcDataset.Tables("org_orgs").Rows.Count > 0 Then
                                            rcDataset.Tables("gl_kmyeb").Rows(i).Item("bmdm") = rcDataset.Tables("org_orgs").Rows(0).Item("code")
                                            rcDataset.Tables("gl_kmyeb").Rows(i).Item("bmmc") = rcDataset.Tables("org_orgs").Rows(0).Item("name")
                                        End If
                                    Case "人员档案"
                                        rcOleDbCommand.CommandText = "SELECT code,name FROM bd_psndoc WHERE pk_psndoc = ?"
                                        rcOleDbCommand.Parameters.Clear()
                                        rcOleDbCommand.Parameters.Add("@pk_psndoc", OleDbType.VarChar, 20).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("value" & j.ToString)
                                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                        If rcDataset.Tables("bd_psndoc") IsNot Nothing Then
                                            rcDataset.Tables("bd_psndoc").Clear()
                                        End If
                                        rcOleDbDataAdpt.Fill(rcDataset, "bd_psndoc")
                                        If rcDataset.Tables("bd_psndoc").Rows.Count > 0 Then
                                            rcDataset.Tables("gl_kmyeb").Rows(i).Item("zydm") = rcDataset.Tables("bd_psndoc").Rows(0).Item("code")
                                            rcDataset.Tables("gl_kmyeb").Rows(i).Item("zymc") = rcDataset.Tables("bd_psndoc").Rows(0).Item("name")
                                        End If
                                    Case "客商"
                                        rcOleDbCommand.CommandText = "SELECT code,name,pk_custclass,pk_supplierclass FROM bd_cust_supplier WHERE pk_cust_sup = ?"
                                        rcOleDbCommand.Parameters.Clear()
                                        rcOleDbCommand.Parameters.Add("@pk_cust_sup", OleDbType.VarChar, 20).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("value" & j.ToString)
                                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                        If rcDataset.Tables("bd_cust_supplier") IsNot Nothing Then
                                            rcDataset.Tables("bd_cust_supplier").Clear()
                                        End If
                                        rcOleDbDataAdpt.Fill(rcDataset, "bd_cust_supplier")
                                        If rcDataset.Tables("bd_cust_supplier").Rows.Count > 0 Then
                                            If Mid(rcDataset.Tables("gl_kmyeb").Rows(i).Item("kmdm"), 1, 4) = "2202" Then
                                                '科目编码是2开头，设为供应商
                                                rcDataset.Tables("gl_kmyeb").Rows(i).Item("csdm") = rcDataset.Tables("bd_cust_supplier").Rows(0).Item("code")
                                                rcDataset.Tables("gl_kmyeb").Rows(i).Item("csmc") = rcDataset.Tables("bd_cust_supplier").Rows(0).Item("name")
                                            Else
                                                '其他为客户
                                                rcDataset.Tables("gl_kmyeb").Rows(i).Item("khdm") = rcDataset.Tables("bd_cust_supplier").Rows(0).Item("code")
                                                rcDataset.Tables("gl_kmyeb").Rows(i).Item("khmc") = rcDataset.Tables("bd_cust_supplier").Rows(0).Item("name")
                                            End If
                                        End If
                                        'If rcDataset.Tables("bd_cust_supplier").Rows.Count > 0 Then
                                        '    If rcDataset.Tables("bd_cust_supplier").Rows(0).Item("pk_custclass") <> "~" Then
                                        '        rcDataset.Tables("gl_kmyeb").Rows(i).Item("khdm") = rcDataset.Tables("bd_cust_supplier").Rows(0).Item("code")
                                        '        rcDataset.Tables("gl_kmyeb").Rows(i).Item("khmc") = rcDataset.Tables("bd_cust_supplier").Rows(0).Item("name")
                                        '    Else
                                        '        rcDataset.Tables("gl_kmyeb").Rows(i).Item("csdm") = rcDataset.Tables("bd_cust_supplier").Rows(0).Item("code")
                                        '        rcDataset.Tables("gl_kmyeb").Rows(i).Item("csmc") = rcDataset.Tables("bd_cust_supplier").Rows(0).Item("name")
                                        '    End If
                                        'End If
                                    Case "客户档案"
                                        rcOleDbCommand.CommandText = "SELECT code,name FROM bd_customer WHERE pk_customer = ?"
                                        rcOleDbCommand.Parameters.Clear()
                                        rcOleDbCommand.Parameters.Add("@pk_customer", OleDbType.VarChar, 20).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("value" & j.ToString)
                                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                        If rcDataset.Tables("bd_customer") IsNot Nothing Then
                                            rcDataset.Tables("bd_customer").Clear()
                                        End If
                                        rcOleDbDataAdpt.Fill(rcDataset, "bd_customer")
                                        If rcDataset.Tables("bd_customer").Rows.Count > 0 Then
                                            rcDataset.Tables("gl_kmyeb").Rows(i).Item("khdm") = rcDataset.Tables("bd_customer").Rows(0).Item("code")
                                            rcDataset.Tables("gl_kmyeb").Rows(i).Item("khmc") = rcDataset.Tables("bd_customer").Rows(0).Item("name")
                                        End If
                                    Case "供应商档案"
                                        rcOleDbCommand.CommandText = "SELECT code,name FROM bd_supplier WHERE pk_supplier = ?"
                                        rcOleDbCommand.Parameters.Clear()
                                        rcOleDbCommand.Parameters.Add("@pk_supplier", OleDbType.VarChar, 20).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("value" & j.ToString)
                                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                        If rcDataset.Tables("bd_supplier") IsNot Nothing Then
                                            rcDataset.Tables("bd_supplier").Clear()
                                        End If
                                        rcOleDbDataAdpt.Fill(rcDataset, "bd_supplier")
                                        If rcDataset.Tables("bd_supplier").Rows.Count > 0 Then
                                            rcDataset.Tables("gl_kmyeb").Rows(i).Item("csdm") = rcDataset.Tables("bd_supplier").Rows(0).Item("code")
                                            rcDataset.Tables("gl_kmyeb").Rows(i).Item("csmc") = rcDataset.Tables("bd_supplier").Rows(0).Item("name")
                                        End If
                                    Case "银行账户"
                                        rcOleDbCommand.CommandText = "SELECT accnum,accname FROM bd_bankaccbas WHERE pk_bankaccbas = ?"
                                        rcOleDbCommand.Parameters.Clear()
                                        rcOleDbCommand.Parameters.Add("@pk_bankaccbas", OleDbType.VarChar, 20).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("value" & j.ToString)
                                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                        If rcDataset.Tables("bd_bankaccbas") IsNot Nothing Then
                                            rcDataset.Tables("bd_bankaccbas").Clear()
                                        End If
                                        rcOleDbDataAdpt.Fill(rcDataset, "bd_bankaccbas")
                                        If rcDataset.Tables("bd_bankaccbas").Rows.Count > 0 Then
                                            rcDataset.Tables("gl_kmyeb").Rows(i).Item("yhzh") = rcDataset.Tables("bd_bankaccbas").Rows(0).Item("accnum")
                                            'rcDataset.Tables("gl_kmyeb").Rows(i).Item("") = rcDataset.Tables("bd_bankaccbas").Rows(0).Item("accname")
                                        End If
                                End Select
                            End If
                        End If
                    Next
                Next
            Catch ex As Exception
                MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                NCOleDbConn.Close()
            End Try
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "DELETE FROM gl_kmyeb WHERE kjnd = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.Char, 4).Value = Me.NudYear.Value.ToString
                rcOleDbCommand.ExecuteNonQuery()
                Me.ProgressBar1.Maximum = rcDataset.Tables("gl_kmyeb").Rows.Count
                For i = 0 To rcDataset.Tables("gl_kmyeb").Rows.Count - 1
                    Me.ProgressBar1.Value = i + 1
                    rcOleDbCommand.CommandText = "SELECT * FROM gl_kmyeb WHERE jxzh = ? AND yhzh = ? AND csdm = ? AND khdm =? AND xmdm = ? AND zydm = ? AND bmdm = ? AND kmdm = ? AND kjnd = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@jxzh", OleDbType.VarChar, 12).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("jxzh")
                    rcOleDbCommand.Parameters.Add("@yhzh", OleDbType.VarChar, 12).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("yhzh")
                    If Not Me.RadioButton2.Checked Or rcDataset.Tables("gl_kmyeb").Rows(i).Item("csdm") = "~" Then
                        rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("csdm")
                        rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("khdm")
                    Else
                        rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = "~"
                        rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("csdm") & rcDataset.Tables("gl_kmyeb").Rows(i).Item("khdm")
                    End If
                    rcOleDbCommand.Parameters.Add("@xmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("xmdm")
                    rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("zydm")
                    rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("bmdm")
                    rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("kmdm")
                    rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.Char, 4).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("year")
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("t_kmyeb") IsNot Nothing Then
                        rcDataset.Tables("t_kmyeb").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "t_kmyeb")
                    If rcDataset.Tables("t_kmyeb").Rows.Count > 0 Then
                        rcOleDbCommand.CommandText = "UPDATE gl_kmyeb SET jd = ? ,ncsl = ?,ncwb =  ?,ncje = ? WHERE jxzh = ? AND yhzh = ? AND csdm = ? AND khdm =? AND xmdm = ? AND zydm = ? AND bmdm = ? AND kmdm = ? AND kjnd = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@jd", OleDbType.Char, 2).Value = IIf(IIf(rcDataset.Tables("t_kmyeb").Rows(0).Item("jd") = "借", rcDataset.Tables("t_kmyeb").Rows(0).Item("ncje"), 0 - rcDataset.Tables("t_kmyeb").Rows(0).Item("ncje")) + rcDataset.Tables("gl_kmyeb").Rows(i).Item("jfje") - rcDataset.Tables("gl_kmyeb").Rows(i).Item("dfje") > 0, "借", "贷")
                        rcOleDbCommand.Parameters.Add("@ncsl", OleDbType.Numeric, 18).Value = IIf(IIf(rcDataset.Tables("t_kmyeb").Rows(0).Item("jd") = "借", rcDataset.Tables("t_kmyeb").Rows(0).Item("ncje"), 0 - rcDataset.Tables("t_kmyeb").Rows(0).Item("ncje")) + rcDataset.Tables("gl_kmyeb").Rows(i).Item("jfje") - rcDataset.Tables("gl_kmyeb").Rows(i).Item("dfje") > 0, IIf(rcDataset.Tables("t_kmyeb").Rows(0).Item("jd") = "借", rcDataset.Tables("t_kmyeb").Rows(0).Item("ncsl"), 0 - rcDataset.Tables("t_kmyeb").Rows(0).Item("ncsl")) + rcDataset.Tables("gl_kmyeb").Rows(i).Item("jfsl") - rcDataset.Tables("gl_kmyeb").Rows(i).Item("dfsl"), IIf(rcDataset.Tables("t_kmyeb").Rows(0).Item("jd") = "借", 0 - rcDataset.Tables("t_kmyeb").Rows(0).Item("ncsl"), rcDataset.Tables("t_kmyeb").Rows(0).Item("ncsl")) - rcDataset.Tables("gl_kmyeb").Rows(i).Item("jfsl") + rcDataset.Tables("gl_kmyeb").Rows(i).Item("dfsl"))
                        rcOleDbCommand.Parameters.Add("@ncwb", OleDbType.Numeric, 18).Value = IIf(IIf(rcDataset.Tables("t_kmyeb").Rows(0).Item("jd") = "借", rcDataset.Tables("t_kmyeb").Rows(0).Item("ncje"), 0 - rcDataset.Tables("t_kmyeb").Rows(0).Item("ncje")) + rcDataset.Tables("gl_kmyeb").Rows(i).Item("jfje") - rcDataset.Tables("gl_kmyeb").Rows(i).Item("dfje") > 0, IIf(rcDataset.Tables("t_kmyeb").Rows(0).Item("jd") = "借", rcDataset.Tables("t_kmyeb").Rows(0).Item("ncwb"), 0 - rcDataset.Tables("t_kmyeb").Rows(0).Item("ncwb")) + rcDataset.Tables("gl_kmyeb").Rows(i).Item("jfwb") - rcDataset.Tables("gl_kmyeb").Rows(i).Item("dfwb"), IIf(rcDataset.Tables("t_kmyeb").Rows(0).Item("jd") = "借", 0 - rcDataset.Tables("t_kmyeb").Rows(0).Item("ncwb"), rcDataset.Tables("t_kmyeb").Rows(0).Item("ncwb")) - rcDataset.Tables("gl_kmyeb").Rows(i).Item("jfwb") + rcDataset.Tables("gl_kmyeb").Rows(i).Item("dfwb"))
                        rcOleDbCommand.Parameters.Add("@ncje", OleDbType.Numeric, 14).Value = IIf(IIf(rcDataset.Tables("t_kmyeb").Rows(0).Item("jd") = "借", rcDataset.Tables("t_kmyeb").Rows(0).Item("ncje"), 0 - rcDataset.Tables("t_kmyeb").Rows(0).Item("ncje")) + rcDataset.Tables("gl_kmyeb").Rows(i).Item("jfje") - rcDataset.Tables("gl_kmyeb").Rows(i).Item("dfje") > 0, IIf(rcDataset.Tables("t_kmyeb").Rows(0).Item("jd") = "借", rcDataset.Tables("t_kmyeb").Rows(0).Item("ncje"), 0 - rcDataset.Tables("t_kmyeb").Rows(0).Item("ncje")) + rcDataset.Tables("gl_kmyeb").Rows(i).Item("jfje") - rcDataset.Tables("gl_kmyeb").Rows(i).Item("dfje"), IIf(rcDataset.Tables("t_kmyeb").Rows(0).Item("jd") = "借", 0 - rcDataset.Tables("t_kmyeb").Rows(0).Item("ncje"), rcDataset.Tables("t_kmyeb").Rows(0).Item("ncje")) - rcDataset.Tables("gl_kmyeb").Rows(i).Item("jfje") + rcDataset.Tables("gl_kmyeb").Rows(i).Item("dfje"))
                        rcOleDbCommand.Parameters.Add("@jxzh", OleDbType.VarChar, 12).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("jxzh")
                        rcOleDbCommand.Parameters.Add("@yhzh", OleDbType.VarChar, 12).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("yhzh")
                        If Not Me.RadioButton2.Checked Or rcDataset.Tables("gl_kmyeb").Rows(i).Item("csdm") = "~" Then
                            rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("csdm")
                            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("khdm")
                        Else
                            rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = "~"
                            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("csdm") & rcDataset.Tables("gl_kmyeb").Rows(i).Item("khdm")
                        End If
                        rcOleDbCommand.Parameters.Add("@xmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("xmdm")
                        rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("zydm")
                        rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("bmdm")
                        rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("kmdm")
                        rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.Char, 4).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("year")
                        rcOleDbCommand.ExecuteNonQuery()
                    Else
                        rcOleDbCommand.CommandText = "INSERT INTO gl_kmyeb (kjnd,kmdm,bmdm,zydm,xmdm,khdm,csdm,yhzh,jxzh,jd,ncsl,ncwb,ncje) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?)"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.Char, 4).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("year")
                        rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("kmdm")
                        rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("bmdm")
                        rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("zydm")
                        rcOleDbCommand.Parameters.Add("@xmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("xmdm")
                        If Not Me.RadioButton2.Checked Or rcDataset.Tables("gl_kmyeb").Rows(i).Item("csdm") = "~" Then
                            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("khdm")
                            rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("csdm")
                        Else
                            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("csdm") & rcDataset.Tables("gl_kmyeb").Rows(i).Item("khdm")
                            rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = "~"
                        End If
                        rcOleDbCommand.Parameters.Add("@yhzh", OleDbType.VarChar, 12).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("yhzh")
                        rcOleDbCommand.Parameters.Add("@jxzh", OleDbType.VarChar, 12).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("jxzh")
                        rcOleDbCommand.Parameters.Add("@jd", OleDbType.Char, 2).Value = IIf(rcDataset.Tables("gl_kmyeb").Rows(i).Item("jfje") <> 0, "借", "贷")
                        rcOleDbCommand.Parameters.Add("@ncsl", OleDbType.Numeric, 18).Value = IIf(rcDataset.Tables("gl_kmyeb").Rows(i).Item("jfje") <> 0, rcDataset.Tables("gl_kmyeb").Rows(i).Item("jfsl"), rcDataset.Tables("gl_kmyeb").Rows(i).Item("dfsl"))
                        rcOleDbCommand.Parameters.Add("@ncwb", OleDbType.Numeric, 18).Value = IIf(rcDataset.Tables("gl_kmyeb").Rows(i).Item("jfje") <> 0, rcDataset.Tables("gl_kmyeb").Rows(i).Item("jfwb"), rcDataset.Tables("gl_kmyeb").Rows(i).Item("dfwb"))
                        rcOleDbCommand.Parameters.Add("@ncje", OleDbType.Numeric, 14).Value = IIf(rcDataset.Tables("gl_kmyeb").Rows(i).Item("jfje") <> 0, rcDataset.Tables("gl_kmyeb").Rows(i).Item("jfje"), rcDataset.Tables("gl_kmyeb").Rows(i).Item("dfje"))
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                    '检测科目编码
                    If rcDataset.Tables("gl_kmyeb").Rows(i).Item("kmdm") <> "~" Then
                        rcOleDbCommand.CommandText = "SELECT kmdm FROM gl_kmxx WHERE kmdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("kmdm")
                        If rcDataset.Tables("gl_kmxx") IsNot Nothing Then
                            rcDataset.Tables("gl_kmxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "gl_kmxx")
                        If rcDataset.Tables("gl_kmxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO gl_kmxx (kmdm,kmmc) VALUES (?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("kmdm")
                            rcOleDbCommand.Parameters.Add("@kmmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("kmmc")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    '检测客户编码
                    If rcDataset.Tables("gl_kmyeb").Rows(i).Item("khdm") <> "~" Then
                        rcOleDbCommand.CommandText = "SELECT khdm FROM rc_khxx WHERE khdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        If Not Me.RadioButton2.Checked Or rcDataset.Tables("gl_kmyeb").Rows(i).Item("csdm") = "~" Then
                            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("khdm")
                        Else
                            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("csdm") & rcDataset.Tables("gl_kmyeb").Rows(i).Item("khdm")
                        End If
                        If rcDataset.Tables("rc_khxx") IsNot Nothing Then
                            rcDataset.Tables("rc_khxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_khxx")
                        If rcDataset.Tables("rc_khxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_khxx (khdm,khmc) VALUES (?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            If Not Me.RadioButton2.Checked Or rcDataset.Tables("gl_kmyeb").Rows(i).Item("csdm") = "~" Then
                                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("khdm")
                                rcOleDbCommand.Parameters.Add("@khmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("khmc")
                            Else
                                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("csdm") & rcDataset.Tables("gl_kmyeb").Rows(i).Item("khdm")
                                rcOleDbCommand.Parameters.Add("@khmc", OleDbType.VarChar, 100).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("csmc") & "_" & rcDataset.Tables("gl_kmyeb").Rows(i).Item("khmc")
                            End If
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    '检测供应商编码
                    If rcDataset.Tables("gl_kmyeb").Rows(i).Item("csdm") <> "~" Then
                        rcOleDbCommand.CommandText = "SELECT csdm FROM rc_csxx WHERE csdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("csdm")
                        If rcDataset.Tables("rc_csxx") IsNot Nothing Then
                            rcDataset.Tables("rc_csxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_csxx")
                        If rcDataset.Tables("rc_csxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_csxx (csdm,csmc) VALUES (?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("csdm")
                            rcOleDbCommand.Parameters.Add("@csmc", OleDbType.VarChar, 100).Value = rcDataset.Tables("gl_kmyeb").Rows(i).Item("csmc")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                Next
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
        '客户的业务员及收款期
        If Me.ChbKh.Checked Then
            '写系统参数
            If Not String.IsNullOrEmpty(Me.ComboBox1.SelectedItem) Then
                Try
                    rcOleDbConn.Open()
                    rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.Transaction = rcOleDbTrans
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    '删除数据
                    rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = '收款期属性序号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                    rcOleDbCommand.ExecuteNonQuery()
                    '插入数据
                    rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'收款期属性序号',?,0)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                    rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 30).Value = Trim(Me.ComboBox2.SelectedItem)
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
            Try
                NCOleDbConn.Open()
                rcOleDbCommand.Connection = NCOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                'rcOleDbCommand.CommandText = "SELECT bd_customer.code AS khdm,bd_psndoc.code AS zydm,bd_psndoc.name AS zymc,bd_defdoc.name AS skqx FROM bd_custfinance,bd_psndoc,bd_defdoc,bd_customer,org_orgs where bd_defdoc.pk_defdoc = bd_custfinance.def" & Trim(Me.ComboBox2.SelectedItem.ToString) & " and bd_customer.pk_customer =bd_custfinance.pk_customer and bd_custfinance.pk_resppsn1 = bd_psndoc.pk_psndoc and org_orgs.pk_org = bd_custfinance.pk_org and org_orgs.code = ?"
                rcOleDbCommand.CommandText = "SELECT aa.*,bd_defdoc.name AS skqx FROM (SELECT bd_customer.code AS khdm,bd_psndoc.code AS zydm,bd_psndoc.name AS zymc,bd_custfinance.def" & Trim(Me.ComboBox2.SelectedItem.ToString) & " FROM bd_custfinance,bd_psndoc,bd_customer,org_orgs WHERE bd_customer.pk_customer =bd_custfinance.pk_customer and bd_custfinance.pk_resppsn1 = bd_psndoc.pk_psndoc and org_orgs.pk_org = bd_custfinance.pk_org and org_orgs.code = ?) aa LEFT JOIN bd_defdoc ON bd_defdoc.pk_defdoc = aa.def" & Trim(Me.ComboBox2.SelectedItem.ToString)
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@NCAccountingBook", OleDbType.VarChar, 40).Value = NCAccountingBook
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("bd_custfinance") IsNot Nothing Then
                    Me.rcDataset.Tables("bd_custfinance").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "bd_custfinance")
                Me.ProgressBar1.Maximum = rcDataset.Tables("bd_custfinance").Rows.Count
            Catch ex As Exception
                MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                NCOleDbConn.Close()
            End Try
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                Me.ProgressBar1.Maximum = rcDataset.Tables("bd_custfinance").Rows.Count
                For i = 0 To rcDataset.Tables("bd_custfinance").Rows.Count - 1
                    Me.ProgressBar1.Value = i + 1
                    If rcDataset.Tables("bd_custfinance").Rows(i).Item("skqx").GetType.ToString = "System.DBNull" Then
                        rcDataset.Tables("bd_custfinance").Rows(i).Item("skqx") = 0
                    End If
                    rcOleDbCommand.CommandText = "UPDATE rc_khxx SET zydm = ?,zymc = ?,skqx = ? WHERE khdm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@paraStrZydm", OleDbType.VarChar, 12).Value = rcDataset.Tables("bd_custfinance").Rows(i).Item("zydm")
                    rcOleDbCommand.Parameters.Add("@paraStrZymc", OleDbType.VarChar, 30).Value = rcDataset.Tables("bd_custfinance").Rows(i).Item("zymc")
                    rcOleDbCommand.Parameters.Add("@paraIntSkqx", OleDbType.Numeric, 4).Value = rcDataset.Tables("bd_custfinance").Rows(i).Item("skqx")
                    rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("bd_custfinance").Rows(i).Item("khdm")
                    rcOleDbCommand.ExecuteNonQuery()
                Next
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
        If ChbCpdm.Checked Then
            Try
                NCOleDbConn.Open()
                rcOleDbCommand.Connection = NCOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT bd_material.pk_marbasclass,bd_marbasclass.code AS lbdm,bd_marbasclass.name AS lbmc,bd_material.code AS cpdm,bd_material.name || ',' || bd_material.materialtype || ',' || bd_material.materialspec AS cpmc,bd_material.pk_measdoc,bd_measdoc.name AS dw,bd_material.unitweight AS cpweight FROM bd_material,bd_measdoc,bd_marbasclass WHERE bd_material.pk_measdoc = bd_measdoc.pk_measdoc AND bd_marbasclass.pk_marbasclass = bd_material.pk_marbasclass"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@NCAccountingBook", OleDbType.VarChar, 40).Value = NCAccountingBook
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("bd_material") IsNot Nothing Then
                    Me.rcDataset.Tables("bd_material").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "bd_material")
                Me.ProgressBar1.Maximum = rcDataset.Tables("bd_material").Rows.Count
            Catch ex As Exception
                MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                NCOleDbConn.Close()
            End Try
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                Me.ProgressBar1.Maximum = rcDataset.Tables("bd_material").Rows.Count
                For i = 0 To rcDataset.Tables("bd_material").Rows.Count - 1
                    Me.ProgressBar1.Value = i + 1
                    rcOleDbCommand.CommandText = "SELECT * FROM rc_cpxx WHERE cpdm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("bd_material").Rows(i).Item("cpdm")
                    If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_cpxx").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
                    If Me.rcDataset.Tables("rc_cpxx").Rows.Count <= 0 Then
                        rcOleDbCommand.CommandText = "INSERT INTO rc_cpxx (lbdm,cpdm,cpmc,dw,cpweight) VALUES (?,?,?,?,?)"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraStrLbdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("bd_material").Rows(i).Item("lbdm")
                        'rcOleDbCommand.Parameters.Add("@paraStrLbmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("bd_material").Rows(i).Item("lbmc")
                        rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("bd_material").Rows(i).Item("cpdm")
                        rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("bd_material").Rows(i).Item("cpmc")
                        rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = rcDataset.Tables("bd_material").Rows(i).Item("dw")
                        rcOleDbCommand.Parameters.Add("@paraStrCpweight", OleDbType.Numeric, 18).Value = rcDataset.Tables("bd_material").Rows(i).Item("cpweight")
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                Next
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
        '根据对照表替换数据
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '删除仓库编码
            rcOleDbCommand.CommandText = "DELETE FROM rc_ckxx WHERE EXISTS (SELECT 1 FROM dzb_nc WHERE dzb_nc.leibie = 'CKDM' AND rc_ckxx.ckdm = dzb_nc.nc)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.ExecuteNonQuery()
            '替换各种表
            rcOleDbCommand.CommandText = "UPDATE po_rkd SET ckdm = (SELECT rc FROM dzb_nc WHERE po_rkd.ckdm = dzb_nc.nc) WHERE EXISTS (SELECT 1 FROM dzb_nc WHERE dzb_nc.leibie = 'CKDM' AND po_rkd.ckdm = dzb_nc.nc)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "UPDATE inv_ckd SET ckdm = (SELECT rc FROM dzb_nc WHERE inv_ckd.ckdm = dzb_nc.nc) WHERE EXISTS (SELECT 1 FROM dzb_nc WHERE dzb_nc.leibie = 'CKDM' AND inv_ckd.ckdm = dzb_nc.nc)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "UPDATE inv_rkd SET ckdm = (SELECT rc FROM dzb_nc WHERE inv_rkd.ckdm = dzb_nc.nc) WHERE EXISTS (SELECT 1 FROM dzb_nc WHERE dzb_nc.leibie = 'CKDM' AND inv_rkd.ckdm = dzb_nc.nc)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "UPDATE inv_dbd SET cckdm = (SELECT rc FROM dzb_nc WHERE inv_dbd.cckdm = dzb_nc.nc) WHERE EXISTS (SELECT 1 FROM dzb_nc WHERE dzb_nc.leibie = 'CKDM' AND inv_dbd.cckdm = dzb_nc.nc)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "UPDATE inv_dbd SET rckdm = (SELECT rc FROM dzb_nc WHERE inv_dbd.rckdm = dzb_nc.nc) WHERE EXISTS (SELECT 1 FROM dzb_nc WHERE dzb_nc.leibie = 'CKDM' AND inv_dbd.rckdm = dzb_nc.nc)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "UPDATE oe_xsd SET ckdm = (SELECT rc FROM dzb_nc WHERE oe_xsd.ckdm = dzb_nc.nc) WHERE EXISTS (SELECT 1 FROM dzb_nc WHERE dzb_nc.leibie = 'CKDM' AND oe_xsd.ckdm = dzb_nc.nc)"
            rcOleDbCommand.Parameters.Clear()
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
        MsgBox("数据读入完成,请检查数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
    End Sub

    Private Sub ChbOeXsd_CheckedChanged(sender As Object, e As EventArgs) Handles ChbOeXsd.CheckedChanged, ChbPoRkd.CheckedChanged, ChbInvDbd.CheckedChanged
        If Me.ChbOeXsd.Checked Or Me.ChbPoRkd.Checked Or Me.ChbInvDbd.Checked Then
            Me.TxtCkdm.Text = ""
            Me.TxtCkdm.Enabled = False
        End If
    End Sub

    Private Sub ChbInvRkd_CheckedChanged(sender As Object, e As EventArgs) Handles ChbInvRkd1.CheckedChanged, ChbInvCkd.CheckedChanged
        '需要分仓库读入
        If Me.ChbInvRkd1.Checked Or Me.ChbInvCkd.Checked Then
            Me.TxtCkdm.Enabled = True
        End If
    End Sub

    Private Sub BtnWrite_Click(sender As Object, e As EventArgs) Handles BtnWrite.Click
        If MsgBox("确定要回写到NC吗？", MsgBoxStyle.YesNo, "提示信息") = MsgBoxResult.No Then
            Return
        End If
        '检查NC的结账状态

        Dim i As Integer
        Dim intRowCount As Integer
        Dim NCAccountingBook As String
        Dim NCOleDbConn As New OleDbConnection
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_para Where dwdm = ? And (paraid = 'NCACCOUNTINGBOOK' or paraid = 'NCHOST' or paraid = 'NCSERVICE_NAME' or paraid = 'NCUser_ID' or paraid = 'NCPASSWORD') ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
        Catch ex As Exception
            MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_para").Rows.Count = 5 Then
            If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                NCAccountingBook = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
            End If
            'Orcal 9.i
            NCOleDbConn.ConnectionString = "Provider=OraOLEDB.Oracle.1;Persist Security Info=False;Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = " & rcDataset.Tables("rc_para").Rows(1).Item("parastrvalue") & ")(PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = " & rcDataset.Tables("rc_para").Rows(3).Item("parastrvalue") & ")));User ID=" & rcDataset.Tables("rc_para").Rows(4).Item("parastrvalue") & ";Password=" & rcDataset.Tables("rc_para").Rows(2).Item("parastrvalue") ' &";Pooling = false" 'Integrated Security=SSPI;
        Else
            MsgBox("请定义用友NC数据源信息。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        '回写NC生产入库成本
        If Me.ChbInvRkd1.Checked Then
            If Not String.IsNullOrEmpty(Me.TxtCkdm.Text) Then
                Try
                    rcOleDbConn.Open()
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    rcOleDbCommand.CommandText = "SELECT * FROM inv_rkd WHERE SUBSTR(djh,5,6)= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND ckdm ='" & Me.TxtCkdm.Text & "'", "")
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("inv_rkd") IsNot Nothing Then
                        Me.rcDataset.Tables("inv_rkd").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "inv_rkd")

                Catch ex As Exception
                    MsgBox("程序错误。" & Chr(13) & ex.Message)
                    Return
                Finally
                    rcOleDbConn.Close()
                End Try
                Me.ProgressBar1.Maximum = rcDataset.Tables("inv_rkd").Rows.Count
                Try
                    NCOleDbConn.Open()
                    rcOleDbTrans = NCOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                    rcOleDbCommand.Connection = NCOleDbConn
                    rcOleDbCommand.Transaction = rcOleDbTrans
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    Me.ProgressBar1.Maximum = rcDataset.Tables("inv_rkd").Rows.Count
                    For i = 0 To rcDataset.Tables("inv_rkd").Rows.Count - 1
                        Me.ProgressBar1.Value = i + 1
                        rcOleDbCommand.CommandText = "UPDATE ic_finprodin_b SET ncostprice  = ?,ncostmny  = ? WHERE dr = 0 AND cgeneralbid = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraNcostprice ", OleDbType.Numeric, 18).Value = rcDataset.Tables("inv_rkd").Rows(i).Item("dj")
                        rcOleDbCommand.Parameters.Add("@paraNcostmny ", OleDbType.Numeric, 18).Value = rcDataset.Tables("inv_rkd").Rows(i).Item("je")
                        rcOleDbCommand.Parameters.Add("@paraCgeneralbid ", OleDbType.VarChar, 20).Value = rcDataset.Tables("inv_rkd").Rows(i).Item("cbill_bid")
                        intRowCount = rcOleDbCommand.ExecuteNonQuery()
                        If intRowCount <> 1 Then
                            MsgBox(rcDataset.Tables("inv_rkd").Rows(i).Item("cbill_bid"))
                        End If
                    Next
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
                    NCOleDbConn.Close()
                End Try
            Else
                MsgBox("请填写仓库编码")
            End If
            MsgBox("回写NC生产入库成本完成。")
        End If
        '期初库存
        If Me.ChbKcqcye.Checked Then
            If Not String.IsNullOrEmpty(Me.TxtCkdm.Text) Then
                Try
                    rcOleDbConn.Open()
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    rcOleDbCommand.CommandText = "SELECT cpdm,ckdm,qcsl,qcje,CASE WHEN qcsl <> 0 THEN ROUND(qcje/qcsl,6) ELSE 0 END AS qcdj FROM inv_cpyeb WHERE kjnd = ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND ckdm ='" & Me.TxtCkdm.Text & "'", "")
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@year", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("inv_cpyeb") IsNot Nothing Then
                        Me.rcDataset.Tables("inv_cpyeb").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "inv_cpyeb")

                Catch ex As Exception
                    MsgBox("程序错误。" & Chr(13) & ex.Message)
                    Return
                Finally
                    rcOleDbConn.Close()
                End Try
                Me.ProgressBar1.Maximum = rcDataset.Tables("inv_cpyeb").Rows.Count
                Try
                    NCOleDbConn.Open()
                    rcOleDbTrans = NCOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                    rcOleDbCommand.Connection = NCOleDbConn
                    rcOleDbCommand.Transaction = rcOleDbTrans
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    Me.ProgressBar1.Maximum = rcDataset.Tables("inv_cpyeb").Rows.Count
                    For i = 0 To rcDataset.Tables("inv_cpyeb").Rows.Count - 1
                        Me.ProgressBar1.Value = i + 1
                        rcOleDbCommand.CommandText = "UPDATE ic_openbal_b SET ncostprice  = ?,ncostmny  = ROUND(nnum * ? , 2) WHERE EXISTS (SELECT 1 FROM bd_material WHERE bd_material.code = ? AND bd_material.pk_material = ic_openbal_b.cmaterialvid) AND EXISTS (SELECT 1 FROM bd_stordoc WHERE bd_stordoc.pk_stordoc = ic_openbal_b.cbodywarehouseid AND bd_stordoc.code = ?) AND ic_openbal_b.dr = 0 AND substr(ic_openbal_b.dbizdate,1,4) = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraNcostprice ", OleDbType.Numeric, 18).Value = rcDataset.Tables("inv_cpyeb").Rows(i).Item("qcdj")
                        rcOleDbCommand.Parameters.Add("@paraNcostmny ", OleDbType.Numeric, 18).Value = rcDataset.Tables("inv_cpyeb").Rows(i).Item("qcdj")
                        rcOleDbCommand.Parameters.Add("@cpdm ", OleDbType.VarChar, 15).Value = rcDataset.Tables("inv_cpyeb").Rows(i).Item("cpdm")
                        rcOleDbCommand.Parameters.Add("@ckdm ", OleDbType.VarChar, 12).Value = rcDataset.Tables("inv_cpyeb").Rows(i).Item("ckdm")
                        rcOleDbCommand.Parameters.Add("@year", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString
                        rcOleDbCommand.ExecuteNonQuery()
                    Next
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
                    NCOleDbConn.Close()
                End Try
            Else
                MsgBox("请填写仓库编码")
            End If
            MsgBox("回写NC期初余额成本完成。")
        End If
    End Sub
End Class