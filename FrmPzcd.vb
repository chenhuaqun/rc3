Imports System.Data.OleDb

Public Class FrmPzcd
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    ReadOnly rcOleDbTrans As OleDbTransaction
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim dateBegin As Date = getInvBegin(Me.NudYear.Value, Me.NudMonth.Value)
        Dim dateEnd As Date = getInvEnd(Me.NudYear.Value, Me.NudMonth.Value)

        If Me.RadioButton1.Checked Then
            '传递到用友NC
            '取核算账簿
            Dim strAccountingBook As String = GetParaValue("NCACCOUNTINGBOOK", True)
            Dim strNCUserAccount As String = GetParaValue("NC用户编码", True)

            '读取凭证
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT djh,pzrq,cperiod,pzlxdm,pzh,fjzs FROM sys_pz WHERE sys_pz.pzrq >= ? AND sys_pz.pzrq <= ? AND SUBSTR(sys_pz.djh,11, 5) >= ?  AND SUBSTR(sys_pz.djh,11,5) <= ?" & IIf(Me.CmbPzlxjc.SelectedValue <> "0000", " AND SUBSTR(sys_pz.djh,1, 4) ='" & Me.CmbPzlxjc.SelectedValue & "'", "") & "GROUP BY djh,pzrq,cperiod,pzlxdm,pzh,fjzs ORDER BY djh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@pzrq", OleDbType.Date, 8).Value = dateBegin
                rcOleDbCommand.Parameters.Add("@pzrq", OleDbType.Date, 8).Value = dateEnd
                rcOleDbCommand.Parameters.Add("@djh1", OleDbType.VarChar, 5).Value = NudDjhBegin.Value.ToString.PadLeft(5, "0")
                rcOleDbCommand.Parameters.Add("@djh2", OleDbType.VarChar, 5).Value = NudDjhEnd.Value.ToString.PadLeft(5, "0")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("sys_pzml") IsNot Nothing Then
                    rcDataset.Tables("sys_pzml").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "sys_pzml")
            Catch ex As Exception
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            Me.ProgressBar1.Maximum = rcDataset.Tables("sys_pzml").Rows.Count
            '生成XML文件
            If rcDataset.Tables("sys_pzml").Rows.Count > 0 Then
                Dim i As Integer
                Dim j As Integer
                Dim ufInterface As New UfInterface()
                '设置根节点属性
                ufInterface.Account = "develop"
                ufInterface.BillType = "vouchergl"
                ufInterface.BusinessUnitCode = "develop"
                'ufInterface.Receiver = "1000"
                ufInterface.Sender = "001"

                For i = 0 To rcDataset.Tables("sys_pzml").Rows.Count - 1
                    Me.ProgressBar1.Value = i + 1
                    Dim voucher As New Voucher()
                    voucher.Head.VoucherId = "" '凭证内部标识，新增时为空
                    voucher.Head.VoucherType = "03" '凭证类型，01-记账凭证，02-收款凭证，03-付款凭证，04-转账凭证，05-其他凭证
                    voucher.Head.Year = Me.NudYear.Value.ToString '会计年度，YYYY格式
                    voucher.Head.System = "GL" '来源系统，固定值GL
                    voucher.Head.VoucherKind = 0 '凭证类型值 0：正常凭证 3：数量调整凭证 不可空
                    voucher.Head.AccountingBook = strAccountingBook '核算账簿 非空 （账簿_财务核算账簿）
                    voucher.Head.DiscardFlag = "N" '作废标志 可空’
                    voucher.Head.Period = Me.NudMonth.Value.ToString.PadLeft(2, "0") '会计期间 非空
                    voucher.Head.Number = "" '凭证号为空自动分配 非空：按凭证号处理
                    voucher.Head.Attachment = rcDataset.Tables("sys_pzml").Rows(i).Item("fjzs").ToString '附件张数 可空
                    voucher.Head.PreparedDate = String.Format(rcDataset.Tables("sys_pzml").Rows(i).Item("pzrq"), ("yyyy-MM-dd HH:mm:ss")) '制单日期 非空-
                    voucher.Head.PreparedBy = strNCUserAccount '"chenhq" '制单人 非空  （用户）
                    voucher.Head.Casher = "" '出纳 （用户）
                    voucher.Head.SignFlag = "N" '签字标志 可空
                    voucher.Head.CheckedBy = "" '审核人 （用户）
                    voucher.Head.TallyDate = "" '记账日期
                    voucher.Head.Manager = "" '记账人 （用户）
                    voucher.Head.Memo1 = "" '自定义项1
                    voucher.Head.Memo2 = "" '自定义项2
                    voucher.Head.Reserve1 = "" '预留字段1
                    voucher.Head.Reserve2 = "" '预留字段2
                    'voucher.Head.SisCardFlag = "N" '是否金蝶卡片标志
                    voucher.Head.Organization = strAccountingBook
                    voucher.Head.OrganizationVersion = strAccountingBook
                    '读取凭证
                    Try
                        rcOleDbConn.Open()
                        rcOleDbCommand.Connection = rcOleDbConn
                        rcOleDbCommand.CommandTimeout = 300
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT * FROM sys_pz WHERE djh = ? ORDER BY djh,xh"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataset.Tables("sys_pzml").Rows(i).Item("djh")
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("sys_pznr") IsNot Nothing Then
                            rcDataset.Tables("sys_pznr").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "sys_pznr")
                    Catch ex As Exception
                        MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                    For j = 0 To rcDataset.Tables("sys_pznr").Rows.Count - 1
                        If rcDataset.Tables("sys_pznr").Rows(j).Item("jd") = "借" Then
                            '创建借方分录
                            Dim debitItem As New VoucherItem()
                            debitItem.DetailIndex = rcDataset.Tables("sys_pznr").Rows(j).Item("xh").ToString
                            debitItem.Explanation = rcDataset.Tables("sys_pznr").Rows(j).Item("zy") '摘要内容
                            debitItem.DebitQuantity = rcDataset.Tables("sys_pznr").Rows(j).Item("sl") '借方数量
                            'debitItem.Price = rcDataset.Tables("sys_pznr").Rows(j).Item("dj")‘单价可空
                            debitItem.CurrencyType = rcDataset.Tables("sys_pznr").Rows(j).Item("bz")
                            debitItem.DebitAmount = rcDataset.Tables("sys_pznr").Rows(j).Item("wb") '原币借发生额
                            'debitItem.Excrate2 = rcDataset.Tables("sys_pznr").Rows(j).Item("hl") '汇率2 可空
                            debitItem.LocalDebitAmount = rcDataset.Tables("sys_pznr").Rows(j).Item("je") '组织本币借发生额
                            debitItem.GroupDebitAmount = rcDataset.Tables("sys_pznr").Rows(j).Item("je") '集团本币借发生额 
                            debitItem.GlobalDebitAmount = rcDataset.Tables("sys_pznr").Rows(j).Item("je") '全局本币借发生额
                            debitItem.AccountCode = rcDataset.Tables("sys_pznr").Rows(j).Item("kmdm")
                            debitItem.UnitCode = strAccountingBook
                            debitItem.UnitCodeV = strAccountingBook

                            '辅助核算
                            ' 添加辅助核算项
                            '部门
                            If rcDataset.Tables("sys_pznr").Rows(j).Item("bmdm").GetType.ToString <> "System.DBNull" Then
                                If Not String.IsNullOrEmpty(rcDataset.Tables("sys_pznr").Rows(j).Item("bmdm")) Then
                                    If rcDataset.Tables("sys_pznr").Rows(j).Item("bmdm") <> "~" Then
                                        debitItem.Ass.AddItem(New AssItem("0001", rcDataset.Tables("sys_pznr").Rows(j).Item("bmdm")))
                                    End If
                                End If
                            End If
                            '客户
                            If rcDataset.Tables("sys_pznr").Rows(j).Item("khdm").GetType.ToString <> "System.DBNull" Then
                                If Not String.IsNullOrEmpty(rcDataset.Tables("sys_pznr").Rows(j).Item("khdm")) Then
                                    If rcDataset.Tables("sys_pznr").Rows(j).Item("khdm") <> "~" Then
                                        debitItem.Ass.AddItem(New AssItem("0004", rcDataset.Tables("sys_pznr").Rows(j).Item("khdm")))
                                    End If
                                End If
                            End If

                            '欧盟vat导入
                            debitItem.VatDetail = New VatDetail()
                            '现金流量
                            debitItem.CashFlow = New CashFlowCollection()

                            voucher.Head.Details.AddItem(debitItem)
                        Else
                            '创建贷方分录
                            Dim creditItem As New VoucherItem()
                            creditItem.DetailIndex = rcDataset.Tables("sys_pznr").Rows(j).Item("xh").ToString '分录号 非空
                            creditItem.Explanation = rcDataset.Tables("sys_pznr").Rows(j).Item("zy") '摘要内容
                            creditItem.CreditQuantity = rcDataset.Tables("sys_pznr").Rows(j).Item("sl") '贷方数量
                            'creditItem.Price = rcDataset.Tables("sys_pznr").Rows(j).Item("dj") '单价，可空
                            creditItem.CurrencyType = rcDataset.Tables("sys_pznr").Rows(j).Item("bz")
                            creditItem.CreditAmount = rcDataset.Tables("sys_pznr").Rows(j).Item("wb") '原币贷发生额
                            'creditItem.Excrate2 = rcDataset.Tables("sys_pznr").Rows(j).Item("hl") '折本汇率2 可空
                            creditItem.LocalCreditAmount = rcDataset.Tables("sys_pznr").Rows(j).Item("je") '组织本币贷发生额
                            creditItem.GroupCreditAmount = rcDataset.Tables("sys_pznr").Rows(j).Item("je") '集团本币贷发生额 
                            creditItem.GlobalCreditAmount = rcDataset.Tables("sys_pznr").Rows(j).Item("je") '全局本币贷发生额 
                            creditItem.VerifyDate = ""
                            creditItem.AccountCode = rcDataset.Tables("sys_pznr").Rows(j).Item("kmdm")
                            creditItem.UnitCode = strAccountingBook
                            creditItem.UnitCodeV = strAccountingBook

                            ' 添加辅助核算项
                            '部门
                            If rcDataset.Tables("sys_pznr").Rows(j).Item("bmdm").GetType.ToString <> "System.DBNull" Then
                                If Not String.IsNullOrEmpty(rcDataset.Tables("sys_pznr").Rows(j).Item("bmdm")) Then
                                    If rcDataset.Tables("sys_pznr").Rows(j).Item("bmdm") <> "~" Then
                                        creditItem.Ass.AddItem(New AssItem("0001", rcDataset.Tables("sys_pznr").Rows(j).Item("bmdm")))
                                    End If
                                End If
                            End If
                            '客户
                            If rcDataset.Tables("sys_pznr").Rows(j).Item("khdm").GetType.ToString <> "System.DBNull" Then
                                If Not String.IsNullOrEmpty(rcDataset.Tables("sys_pznr").Rows(j).Item("khdm")) Then
                                    If rcDataset.Tables("sys_pznr").Rows(j).Item("khdm") <> "~" Then
                                        creditItem.Ass.AddItem(New AssItem("0004", rcDataset.Tables("sys_pznr").Rows(j).Item("khdm")))
                                    End If
                                End If
                            End If
                            '欧盟vat导入
                            creditItem.VatDetail = New VatDetail()
                            '现金流量
                            creditItem.CashFlow = New CashFlowCollection()

                            voucher.Head.Details.AddItem(creditItem)


                        End If
                    Next

                    ufInterface.AddVoucher(voucher)


                Next
                Dim generator As New VoucherXmlGenerator()
                generator.GenerateXmlFile(Application.StartupPath & "\voucher.xml", ufInterface)

                Dim xmlContent As String = generator.GenerateXmlString(ufInterface)
                ' 目标URL
                'Dim ncServiceUrl As String = "http://10.2.3.53:9999/service/XChangeServlet?account=DMEGE&groupcode=DMEGC"
                Dim ncServiceUrl As String = GetParaValue("NC服务器的Servlet的URL地址", True)
                Try
                    ' 2. 提交到NC服务（使用HttpWebRequest版本）
                    Console.WriteLine("正在向NC系统提交凭证数据...")
                    Dim response = NcServiceClient.PostXmlToNc(xmlContent, ncServiceUrl) ' 如果需要认证，可传入最后两个参数
                    MsgBox("提交成功！服务器响应：" & response.ToString)
                    'Console.ReadKey(response)

                    ' 或者使用HttpClient异步版本
                    ' Await PostUsingHttpClientAsync(xmlContent, ncServiceUrl)

                Catch ex As Exception
                    Console.WriteLine("提交失败：")
                    MsgBox("提交失败" & ex.Message)
                End Try
                'Console.ReadKey()
            End If
        Else
            '传递到Anyi311
            '取账务系统参数
            Dim strGlPath As String = ""
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT parastrvalue FROM rc_para WHERE dwdm = ? AND paraid = 'Anyi311账务系统路径' ORDER BY paraid"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_para") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_para").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
                If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                    If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                        strGlPath = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                    Else
                        MsgBox("请至【选项】设置Anyi311账务系统路径。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")

                        Return
                    End If
                Else
                    MsgBox("请至【选项】设置Anyi311账务系统路径。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                    Return
                End If
            Catch ex As Exception
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            'Dim dbfOleDbConn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & rcDataSet.Tables("rc_dwdm").Rows(0).Item("glpath") & ";Extended Properties=dBASE IV;User ID=Admin;Password=")
            Dim dbfOleDbConn As New OleDbConnection("Provider=vfpoledb.1;Data Source=" & strGlPath & "\;Collating Sequence=general")
            '取数据（已编制凭证）
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM gl_pz WHERE gl_pz.pzrq >= ? AND gl_pz.pzrq <= ? AND SUBSTR(gl_pz.djh,11, 5) >= ?  AND SUBSTR(gl_pz.djh,11,5) <= ?" & IIf(Me.CmbPzlxjc.SelectedValue <> "0000", " AND SUBSTR(gl_pz.djh,1, 4) ='" & Me.CmbPzlxjc.SelectedValue & "'", "") & " ORDER BY djh,xh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@pzrq", OleDbType.Date, 8).Value = dateBegin
                rcOleDbCommand.Parameters.Add("@pzrq", OleDbType.Date, 8).Value = dateEnd
                rcOleDbCommand.Parameters.Add("@djh1", OleDbType.VarChar, 5).Value = NudDjhBegin.Value.ToString.PadLeft(5, "0")
                rcOleDbCommand.Parameters.Add("@djh2", OleDbType.VarChar, 5).Value = NudDjhEnd.Value.ToString.PadLeft(5, "0")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("gl_pz") IsNot Nothing Then
                    rcDataset.Tables("gl_pz").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "gl_pz")
            Catch ex As Exception
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            '取凭证类型与凭证号
            Try
                dbfOleDbConn.Open()
                rcOleDbCommand.Connection = dbfOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT pzno" & Trim(Me.NudMonth.Text) & " as pzno FROM pzlx" & Me.NudYear.Text & " WHERE pzlxjc = '记账'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("pzlx") IsNot Nothing Then
                    rcDataset.Tables("pzlx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "pzlx")
            Catch ex As Exception
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                dbfOleDbConn.Close()
            End Try
            Me.ProgressBar1.Maximum = rcDataset.Tables("gl_pz").Rows.Count
            If rcDataset.Tables("pzlx").Rows.Count > 0 And rcDataset.Tables("gl_pz").Rows.Count > 0 Then
                Dim i As Integer
                Dim mpzh As String = rcDataset.Tables("pzlx").Rows(0).Item("pzno")
                Dim oldpzh As String = ""
                Try
                    dbfOleDbConn.Open()
                    rcOleDbCommand.Connection = dbfOleDbConn
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    For i = 0 To rcDataset.Tables("gl_pz").Rows.Count - 1
                        If oldpzh <> rcDataset.Tables("gl_pz").Rows(i).Item("djh") Then
                            mpzh += 1
                            oldpzh = rcDataset.Tables("gl_pz").Rows(i).Item("djh")
                        End If
                        Me.ProgressBar1.Value = i + 1
                        rcOleDbCommand.CommandText = "INSERT INTO a_pz" & Trim(NudYear.Text) & " (pzrq,pzh,fjzs,zy,kmdm,dfkm,xmdm,jd,rmb,sr,sh,jzr,wldm,bmdm,wbdm,wb,sl,hl,dj,yspz,jsr,pzhzbz,pzhzkmdy) values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,'',0,0,0,0,'','','','')"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.AddWithValue("@pzrq", RSet(Trim(Str(NudMonth.Value)), 2) + RSet(Trim(Str(NudMonth.Value)), 2) + RSet(Trim(Str(dateEnd.Day)), 2))
                        rcOleDbCommand.Parameters.AddWithValue("@pzh", "记账" + mpzh.PadLeft(4, " "))
                        rcOleDbCommand.Parameters.AddWithValue("@fjzs", rcDataset.Tables("gl_pz").Rows(i).Item("fjzs"))
                        rcOleDbCommand.Parameters.AddWithValue("@zy", rcDataset.Tables("gl_pz").Rows(i).Item("zy"))
                        rcOleDbCommand.Parameters.AddWithValue("@kmdm", rcDataset.Tables("gl_pz").Rows(i).Item("kmdm"))
                        rcOleDbCommand.Parameters.AddWithValue("@dfkm", rcDataset.Tables("gl_pz").Rows(i).Item("dfkm"))
                        rcOleDbCommand.Parameters.AddWithValue("@xmdm", "")
                        rcOleDbCommand.Parameters.AddWithValue("@jd", rcDataset.Tables("gl_pz").Rows(i).Item("jd"))
                        rcOleDbCommand.Parameters.AddWithValue("@rmb", rcDataset.Tables("gl_pz").Rows(i).Item("je"))
                        rcOleDbCommand.Parameters.AddWithValue("@sr", rcDataset.Tables("gl_pz").Rows(i).Item("srr"))
                        rcOleDbCommand.Parameters.AddWithValue("@sh", "")
                        rcOleDbCommand.Parameters.AddWithValue("@jzr", "")
                        rcOleDbCommand.Parameters.AddWithValue("@wldm", "")
                        rcOleDbCommand.Parameters.AddWithValue("@bmdm", "")
                        rcOleDbCommand.ExecuteNonQuery()
                    Next
                    '更新凭证号
                    rcOleDbCommand.CommandText = "UPDATE pzlx" & NudYear.Text & " SET pzno" & Trim(NudMonth.Text) & " = " & mpzh & " where pzlxjc = '记账'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Catch ex As Exception
                    Try
                        MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                    Catch ey As OleDbException
                        MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                    End Try
                    Return
                Finally
                    dbfOleDbConn.Close()
                End Try
            End If
            MsgBox("凭证传递完成。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")

        End If

        Me.Close()
    End Sub

    Private Sub FrmPzcd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.NudYear.Value = Mid(getInvKjqj(g_Kjrq), 1, 4)
        Me.NudMonth.Value = Mid(getInvKjqj(g_Kjrq), 5, 2)
        '取凭证类型数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE kjnd = ? AND lxgs = '记账凭证' ORDER BY pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_lx") IsNot Nothing Then
                Me.rcDataset.Tables("rc_lx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_lx")
        Catch ex As Exception
            MsgBox("程序错误。读取凭证类型。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Dim rcDataRow As DataRow
        rcDataRow = rcDataset.Tables("rc_lx").NewRow
        rcDataRow.Item("pzlxdm") = "0000"
        rcDataRow.Item("pzlxjc") = "全部凭证"
        rcDataset.Tables("rc_lx").Rows.Add(rcDataRow)
        If rcDataset.Tables("rc_lx").Rows.Count = 0 Then
            MsgBox("请定义凭证类型。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        BindDropDownList(CmbPzlxjc, rcDataset.Tables("rc_lx"), "pzlxdm", "pzlxjc")
        CmbPzlxjc.SelectedValue = "0000"
    End Sub
End Class