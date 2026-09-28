Imports System.Data.OleDb
Imports Microsoft.Office.Interop

Public Class FrmYwfZyMxHz
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '报表结果
    Private rcDataViewReport As DataView

    '全局临时表名称
    Private Const StrTempTable As String = "t_ywfzymxhz"
    '临时表字段
    Private Const StrColAll As String = "dwdm varchar2(4),dwmc varchar2(200),_px number(2,0),khdm varchar2(15),khmc varchar2(200),xslbdm varchar2(60),gjxslb number(1,0),bywfjszz number(1,0),ywfbl number(10,3),bnqc number(14,2),bnjf number(14,2),bndf number(14,2),bndj number(14,2),bnhl number(14,2),ywf_bz number(14,2),snhl number(14,2)"
    '汇总金额字段
    Private Const StrSumCol As String = "bnqc,bnjf,bndf,bndj,bnhl,ywf_bz,snhl"

#Region "初始化"

    Private Sub FrmYwfZyMxHz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        Me.NudYear.Value = Mid(g_Kjqj, 1, 4)
        Me.NudMonthBegin.Value = Mid(g_Kjqj, 5, 2)
        Me.NudMonthEnd.Value = Mid(g_Kjqj, 5, 2)
        '预选单位编码数据
        MdlYwfHzHelper.LoadAuthorizedDwdm(Me.ListBoxYuxuanDwdm)
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
                    .paraCondition = "0=0"
                    .paraOrderField = "bmmc"
                    .paraTitle = "部门"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtBmdm.Text = Trim(.paraField1)
                    End If
                End With
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
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtBmdm.Text)
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
                Me.TxtBmdm.Text = Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmdm"))
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
                    .paraCondition = IIf(String.IsNullOrEmpty(Me.TxtBmdm.Text), "0=0", "bmdm = '" & Me.TxtBmdm.Text.Replace("'", "''") & "'")
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
            Me.TxtZydm.Text = Trim(Me.TxtZydm.Text).ToUpper
            If Me.ListBoxYixuanDwdm.Items.Count > 0 Then
                Dim strMiss As String = MdlYwfHzHelper.CheckZydmAllDwdm(MdlYwfHzHelper.SelectedDwdmArr(Me.ListBoxYixuanDwdm), Me.TxtZydm.Text)
                If strMiss.Length > 0 Then
                    MsgBox("职员编码在核算单位(" & strMiss & ")中不存在。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

#End Region

#Region "核算单位选择"

    Private Sub ListBoxYuxuanDwdm_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBoxYuxuanDwdm.DoubleClick
        MdlYwfHzHelper.MoveOneTo(Me.ListBoxYuxuanDwdm, Me.ListBoxYixuanDwdm)
    End Sub

    Private Sub ListBoxYixuanDwdm_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBoxYixuanDwdm.DoubleClick
        MdlYwfHzHelper.MoveOneTo(Me.ListBoxYixuanDwdm, Me.ListBoxYuxuanDwdm)
    End Sub

    Private Sub BtnSelectAllDwdm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectAllDwdm.Click
        MdlYwfHzHelper.MoveAllTo(Me.ListBoxYuxuanDwdm, Me.ListBoxYixuanDwdm)
    End Sub

    Private Sub BtnSelectOneDwdm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectOneDwdm.Click
        MdlYwfHzHelper.MoveOneTo(Me.ListBoxYuxuanDwdm, Me.ListBoxYixuanDwdm)
    End Sub

    Private Sub BtnUnSelectOneDwdm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUnSelectOneDwdm.Click
        MdlYwfHzHelper.MoveOneTo(Me.ListBoxYixuanDwdm, Me.ListBoxYuxuanDwdm)
    End Sub

    Private Sub BtnUnSelectAllDwdm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUnSelectAllDwdm.Click
        MdlYwfHzHelper.MoveAllTo(Me.ListBoxYixuanDwdm, Me.ListBoxYuxuanDwdm)
    End Sub

#End Region

#Region "生成明细数据"

    Private Function SumField() As String
        Dim strArr As String() = StrSumCol.Split(",")
        Dim strSb As New System.Text.StringBuilder
        For i As Integer = 0 To strArr.Length - 1
            If strSb.Length > 0 Then
                strSb.Append(",")
            End If
            strSb.Append("SUM(" & strArr(i) & ") AS " & strArr(i))
        Next
        Return strSb.ToString
    End Function

    '向临时表插入指定账套、职员的明细
    Private Sub ReadDetail(ByVal strDwdm As String, ByVal strDwmc As String, ByVal strZydm As String)
        Dim strTbl As String = "rcdata_" & strDwdm & ".gl_ywfjsb"
        Dim strKh As String = "rcdata_" & strDwdm & ".rc_khxx"
        Dim strXsl As String = "rcdata_" & strDwdm & ".rc_khxslb"
        Dim strBnz As String = (Me.NudYear.Value - 1).ToString
        Dim strBns As String = (Me.NudYear.Value - 1).ToString & Me.NudMonthBegin.Value.ToString.PadLeft(2, "0")
        Dim strBne As String = (Me.NudYear.Value - 1).ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
        Dim strNs As String = Me.NudYear.Value.ToString & "01"
        Dim strNe As String = Me.NudYear.Value.ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
        Dim strKsr As String = Me.NudYear.Value.ToString & Me.NudMonthBegin.Value.ToString.PadLeft(2, "0")
        '本年数
        Dim strCur As String = "(SELECT gl_ywfjsb.khdm,gl_ywfjsb.khmc,gl_ywfjsb.xslbdm,gl_ywfjsb.ywfbl,0 AS bnqc,SUM(COALESCE(gl_ywfjsb.byjf,0.0)) AS bnjf,SUM(COALESCE(gl_ywfjsb.bydf,0.0)) AS bndf,SUM(COALESCE(gl_ywfjsb.tiexije,0.0) + COALESCE(gl_ywfjsb.yongjinje,0.0)) AS bndj,SUM(COALESCE(gl_ywfjsb.bydf,0.0) - COALESCE(gl_ywfjsb.tiexije,0.0) - COALESCE(gl_ywfjsb.yongjinje,0.0)) AS bnhl,SUM(gl_ywfjsb.ywf_bz) AS ywf_bz,0 AS snhl FROM " & strTbl & " WHERE gl_ywfjsb.cperiod <= ? AND gl_ywfjsb.cperiod >= ? AND gl_ywfjsb.zydm = ? GROUP BY gl_ywfjsb.khdm,gl_ywfjsb.khmc,gl_ywfjsb.xslbdm,gl_ywfjsb.ywfbl)"
        '期初余额
        Dim strQcy As String = "(SELECT gl_ywfjsb.khdm,gl_ywfjsb.khmc,gl_ywfjsb.xslbdm,gl_ywfjsb.ywfbl,SUM(COALESCE(gl_ywfjsb.qmye,0.0) + COALESCE(gl_ywfjsb.bydf,0.0) - COALESCE(gl_ywfjsb.byjf,0.0)) AS bnqc,0 AS bnjf,0 AS bndf,0 AS bndj,0 AS bnhl,0 AS ywf_bz,0 AS snhl FROM " & strTbl & " WHERE EXISTS (SELECT 1 FROM (SELECT MIN(gl_ywfjsba.cperiod) AS cperiod,gl_ywfjsba.khdm FROM " & strTbl & " gl_ywfjsba WHERE gl_ywfjsba.cperiod >= ? AND gl_ywfjsba.zydm = ? GROUP BY gl_ywfjsba.khdm) gl_ywfjsbb WHERE gl_ywfjsbb.cperiod = gl_ywfjsb.cperiod AND gl_ywfjsbb.khdm = gl_ywfjsb.khdm) AND gl_ywfjsb.zydm = ? GROUP BY gl_ywfjsb.khdm,gl_ywfjsb.khmc,gl_ywfjsb.xslbdm,gl_ywfjsb.ywfbl)"
        '上年数
        Dim strPre As String = "(SELECT gl_ywfjsb.khdm,gl_ywfjsb.khmc,gl_ywfjsb.t_xslbdm AS xslbdm," & strXsl & ".ywfbl,0 AS bnqc,0 AS bnjf,0 AS bndf,0 AS bndj,0 AS bnhl,0 AS ywf_bz,SUM(COALESCE(gl_ywfjsb.bydf,0.0) - COALESCE(gl_ywfjsb.tiexije,0.0) - COALESCE(gl_ywfjsb.yongjinje,0.0)) AS snhl FROM " & strTbl & "," & strXsl & " WHERE gl_ywfjsb.t_xslbdm = " & strXsl & ".xslbdm AND gl_ywfjsb.cperiod <= ? AND gl_ywfjsb.cperiod >= ? AND gl_ywfjsb.t_zydm = ? GROUP BY gl_ywfjsb.khdm,gl_ywfjsb.khmc,gl_ywfjsb.t_xslbdm," & strXsl & ".ywfbl)"
        rcOleDbCommand.CommandText = "INSERT INTO " & StrTempTable & " (dwdm,dwmc,_px,khdm,khmc,xslbdm,gjxslb,bywfjszz,ywfbl,bnqc,bnjf,bndf,bndj,bnhl,ywf_bz,snhl) SELECT '" & strDwdm & "','" & strDwmc & "',1 AS _px,ywfzymxb.khdm,ywfzymxb.khmc,ywfzymxb.xslbdm,ywfzymxb.gjxslb,ywfzymxb.bywfjszz,ywfzymxb.ywfbl,SUM(ywfzymxb.bnqc) AS bnqc,SUM(ywfzymxb.bnjf) AS bnjf,SUM(ywfzymxb.bndf) AS bndf,SUM(ywfzymxb.bndj) AS bndj,SUM(ywfzymxb.bnhl) AS bnhl,SUM(ywfzymxb.ywf_bz) AS ywf_bz,SUM(ywfzymxb.snhl) AS snhl FROM (SELECT ywfzymxa.khdm,ywfzymxa.khmc,ywfzymxa.xslbdm || CASE WHEN " & strKh & ".djyear >= " & strBnz & " THEN '新' ELSE '' END AS xslbdm," & strXsl & ".gjxslb," & strKh & ".bywfjszz,ywfzymxa.ywfbl,ywfzymxa.bnqc,ywfzymxa.bnjf,ywfzymxa.bndf,ywfzymxa.bndj,ywfzymxa.bnhl,ywfzymxa.ywf_bz,ywfzymxa.snhl FROM (" & strCur & " UNION ALL " & strQcy & " UNION ALL " & strPre & ") ywfzymxa LEFT JOIN " & strXsl & " ON " & strXsl & ".xslbdm = ywfzymxa.xslbdm LEFT JOIN " & strKh & " ON ywfzymxa.khdm = " & strKh & ".khdm) ywfzymxb GROUP BY ywfzymxb.khdm,ywfzymxb.khmc,ywfzymxb.xslbdm,ywfzymxb.gjxslb,ywfzymxb.bywfjszz,ywfzymxb.ywfbl"
        rcOleDbCommand.Parameters.Clear()
        '本年数
        rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strNe
        rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strKsr
        rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = strZydm
        '期初余额
        rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strNs
        rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = strZydm
        rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = strZydm
        '上年数
        rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strBne
        rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strBns
        rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = strZydm
        rcOleDbCommand.ExecuteNonQuery()
    End Sub

    '从临时表生成明细、分类小计、关键非关小计、账套合计与总计
    Private Sub FillReport(ByVal strDataTable As String)
        Dim strSel As String = "dwdm,dwmc,_px,khdm,khmc,xslbdm,gjxslb,bywfjszz,TO_CHAR(ywfbl,'0.000') || '%' AS ywfbl,bnqc,bnjf,bndf,bndj,bnhl,ywf_bz,snhl"
        If rcDataset.Tables(strDataTable) IsNot Nothing Then
            rcDataset.Tables(strDataTable).Clear()
        End If
        '明细
        rcOleDbCommand.CommandText = "SELECT " & strSel & " FROM " & StrTempTable & " ORDER BY khdm,xslbdm"
        rcOleDbCommand.Parameters.Clear()
        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
        rcOleDbDataAdpt.Fill(rcDataset, strDataTable)
        '各账套内分类小计
        rcOleDbCommand.CommandText = "SELECT dwdm,dwmc,2 AS _px,'' AS khdm,'小计' AS khmc,xslbdm,gjxslb,bywfjszz,TO_CHAR(ywfbl,'0.000') || '%' AS ywfbl," & SumField() & " FROM " & StrTempTable & " GROUP BY dwdm,dwmc,xslbdm,gjxslb,bywfjszz,ywfbl"
        rcOleDbCommand.Parameters.Clear()
        rcOleDbDataAdpt.Fill(rcDataset, strDataTable)
        '关键、非关小计
        rcOleDbCommand.CommandText = "SELECT dwdm,dwmc,3 AS _px,'' AS khdm,CASE WHEN gjxslb = 0 AND bywfjszz = 0 THEN '非关不计算增长小计' ELSE CASE WHEN gjxslb = 0 AND bywfjszz = 1 THEN '非关计算增长小计' ELSE CASE WHEN gjxslb = 1 AND bywfjszz = 0 THEN '关键不计算增长小计' ELSE '关键计算增长小计' END END END AS khmc,CAST(NULL AS varchar2(60)) AS xslbdm,gjxslb,bywfjszz,'%' AS ywfbl," & SumField() & " FROM " & StrTempTable & " GROUP BY dwdm,dwmc,gjxslb,bywfjszz"
        rcOleDbCommand.Parameters.Clear()
        rcOleDbDataAdpt.Fill(rcDataset, strDataTable)
        '各账套合计
        rcOleDbCommand.CommandText = "SELECT dwdm,dwmc,4 AS _px,'' AS khdm,'合计' AS khmc,'合计' AS xslbdm,CAST(NULL AS number(1,0)) AS gjxslb,1 AS bywfjszz,'%' AS ywfbl," & SumField() & " FROM " & StrTempTable & " GROUP BY dwdm,dwmc"
        rcOleDbCommand.Parameters.Clear()
        rcOleDbDataAdpt.Fill(rcDataset, strDataTable)
        '总计
        rcOleDbCommand.CommandText = "SELECT '" & MdlYwfHzHelper.StrTotalDwdm & "' AS dwdm,'合计' AS dwmc,5 AS _px,'' AS khdm,'合计' AS khmc,'合计' AS xslbdm,CAST(NULL AS number(1,0)) AS gjxslb,1 AS bywfjszz,'%' AS ywfbl," & SumField() & " FROM " & StrTempTable
        rcOleDbCommand.Parameters.Clear()
        rcOleDbDataAdpt.Fill(rcDataset, strDataTable)
    End Sub

#End Region

#Region "生成报表"

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim i As Integer
        If Me.ListBoxYixuanDwdm.Items.Count = 0 Then
            MsgBox("请选择核算单位。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        If String.IsNullOrEmpty(Me.TxtZydm.Text) Then
            MsgBox("请选择职员编码。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            MdlYwfHzHelper.CreateGlobalTempTable(rcOleDbCommand, rcOleDbDataAdpt, rcDataset, StrTempTable, StrColAll)
            For i = 0 To Me.ListBoxYixuanDwdm.Items.Count - 1
                Dim strDwdm As String = MdlYwfHzHelper.DwdmOfSafe(Me.ListBoxYixuanDwdm.Items(i).ToString)
                If strDwdm.Length = 0 Then
                    Continue For
                End If
                ReadDetail(strDwdm, MdlYwfHzHelper.DwmcOf(Me.ListBoxYixuanDwdm.Items(i).ToString).Replace("'", "''"), Trim(Me.TxtZydm.Text))
            Next
            FillReport("ywfzymx")
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '调用表单
        rcDataViewReport = New DataView(rcDataset.Tables("ywfzymx"), "TRUE", "dwdm,_px,khdm,xslbdm", DataViewRowState.CurrentRows)
        Dim rcFrm As New FrmYwfZyMxHzz
        With rcFrm
            .ParaDataSet = rcDataset
            .paraDataView = rcDataViewReport
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

    '按所选账套与部门职员分页输出到Excel
    Private Sub BtnToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnToExcel.Click
        Dim i As Integer
        Dim j As Integer
        If Me.ListBoxYixuanDwdm.Items.Count = 0 Then
            MsgBox("请选择核算单位。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        If String.IsNullOrEmpty(Me.TxtBmdm.Text) Then
            MsgBox("请选择部门编码。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        Dim rcExcelApp As Excel.Application = Nothing
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            MdlYwfHzHelper.CreateGlobalTempTable(rcOleDbCommand, rcOleDbDataAdpt, rcDataset, StrTempTable, StrColAll)
            rcExcelApp = New Excel.Application
            Dim rcExcelWorkbook As Excel.Workbook = rcExcelApp.Workbooks().Add
            rcExcelApp.Visible = True
            Dim lstSheet As New List(Of String)
            Dim nCount As Integer = 0
            For i = 0 To Me.ListBoxYixuanDwdm.Items.Count - 1
                Dim strDwdm As String = MdlYwfHzHelper.DwdmOfSafe(Me.ListBoxYixuanDwdm.Items(i).ToString)
                If strDwdm.Length = 0 Then
                    Continue For
                End If
                Dim strDwmc As String = MdlYwfHzHelper.DwmcOf(Me.ListBoxYixuanDwdm.Items(i).ToString)
                '取该账套部门职员
                rcOleDbCommand.CommandText = "SELECT rc_zyxx.zydm,rc_zyxx.zymc FROM rcdata_" & strDwdm & ".rc_zyxx WHERE (bmdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtBmdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_zyxx") IsNot Nothing Then
                    rcDataset.Tables("rc_zyxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_zyxx")
                For j = 0 To rcDataset.Tables("rc_zyxx").Rows.Count - 1
                    rcOleDbCommand.CommandText = "DELETE FROM " & StrTempTable
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    ReadDetail(strDwdm, strDwmc.Replace("'", "''"), Trim(rcDataset.Tables("rc_zyxx").Rows(j).Item("zydm")))
                    FillReport("ywfzymxt")
                    Dim dvYwfZyMx As New DataView(rcDataset.Tables("ywfzymxt"), "TRUE", "dwdm,_px,khdm,xslbdm", DataViewRowState.CurrentRows)
                    If dvYwfZyMx.Count > 0 Then
                        If Me.CheckBox1.Checked Then
                            Dim rcExcelWorksheet As Excel.Worksheet = rcExcelWorkbook.Worksheets.Add()
                            rcExcelWorksheet.Name = MdlYwfHzHelper.MakeSheetName(strDwmc & "_" & Trim(rcDataset.Tables("rc_zyxx").Rows(j).Item("zymc")), lstSheet)
                            MdlYwfHzHelper.WriteDataViewToSheet(rcExcelWorksheet, dvYwfZyMx, "", "", "", "")
                        Else
                            MdlYwfHzHelper.WriteDataViewToSheet(rcExcelWorkbook.Worksheets(1), dvYwfZyMx, "职员编码", Trim(CStr(rcDataset.Tables("rc_zyxx").Rows(j).Item("zydm"))), "职员姓名", Trim(CStr(rcDataset.Tables("rc_zyxx").Rows(j).Item("zymc"))))
                        End If
                    End If
                    nCount += 1
                Next
            Next
            rcOleDbTrans.Commit()
            If nCount = 0 Then
                MsgBox("没有数据！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            End If
        Catch ex As Exception
            MsgBox("数据导出失败！请查看是否已经安装了Excel。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        Finally
            rcOleDbConn.Close()
        End Try
    End Sub

#End Region

End Class
