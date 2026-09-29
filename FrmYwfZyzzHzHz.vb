Imports System.Data.OleDb
Imports System.Globalization
Imports Microsoft.Office.Interop

Public Class FrmYwfZyzzHzHz
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
    Private Const StrTempTable As String = "t_ywfzyzzhhz"
    '临时表字段，px 为内部排序列，必须与 MdlYwfHzHelper.StrSortCol 同名
    Private Const StrColAll As String = "dwdm varchar2(4),dwmc varchar2(200),px number(2,0),zydm varchar2(12),zymc varchar2(30),bngjdf number(14,2),bngjywf number(14,2),bnfgjdf number(14,2),bnfgjbjs number(14,2),bnfgjywf number(14,2),sngjdf number(14,2),sngjywf number(14,2),snfgjdf number(14,2),snfgjbjs number(14,2),snfgjywf number(14,2)"
    '汇总金额字段
    Private Const StrSumCol As String = "bngjdf,bngjywf,bnfgjdf,bnfgjbjs,bnfgjywf,sngjdf,sngjywf,snfgjdf,snfgjbjs,snfgjywf"

#Region "初始化"

    Private Sub FrmYwfZyzzHzHz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        Me.NudYear.Value = Mid(g_Kjqj, 1, 4)
        Me.NudMonthBegin.Value = Mid(g_Kjqj, 5, 2)
        Me.NudMonthEnd.Value = Mid(g_Kjqj, 5, 2)
        '预选单位编码数据
        MdlYwfHzHelper.LoadAuthorizedDwdm(Me.ListBoxYuxuanDwdm)
        '比例参数
        LoadPara("非关键客户回笼增长部分提升比例", Me.TxtZyzz)
        LoadPara("非关键客户回笼增长部分固定奖惩比例", Me.TxtGdjcbl)
    End Sub

    '读取系统参数作为比例默认值
    Private Sub LoadPara(ByVal strParaId As String, ByVal txtBox As TextBox)
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT paraid,parastrvalue,paradblvalue FROM rc_para WHERE paraId = '" & strParaId.Replace("'", "''") & "'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count > 0 Then
                txtBox.Text = CStr(rcDataset.Tables("rc_para").Rows(0).Item("paradblvalue"))
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        Finally
            rcOleDbConn.Close()
        End Try
    End Sub

#End Region

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NudYear.KeyPress, NudMonthBegin.KeyPress, NudMonthEnd.KeyPress, TxtZyzz.KeyPress, TxtGdjcbl.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "比例参数事件"

    Private Sub TxtZyzz_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtZyzz.Validating
        CheckRatio(Me.TxtZyzz, e)
    End Sub

    Private Sub TxtGdjcbl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtGdjcbl.Validating
        CheckRatio(Me.TxtGdjcbl, e)
    End Sub

    Private Sub CheckRatio(ByVal txtBox As TextBox, ByVal e As System.ComponentModel.CancelEventArgs)
        If String.IsNullOrEmpty(txtBox.Text) Then
            txtBox.Text = "0"
            Exit Sub
        End If
        Dim dblValue As Double
        If Not Double.TryParse(txtBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, dblValue) Then
            MsgBox("请输入正确的数字。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            txtBox.Text = "0"
            e.Cancel = True
        End If
    End Sub

    '取得可以安全嵌入SQL的比例数值
    Private Function RatioText(ByVal txtBox As TextBox) As String
        Dim dblValue As Double
        If Not Double.TryParse(txtBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, dblValue) Then
            dblValue = 0
        End If
        Return dblValue.ToString("0.########", CultureInfo.InvariantCulture)
    End Function

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

#Region "生成报表"

    Private Function Agg(ByVal strCol As String, ByVal bSum As Boolean) As String
        If bSum Then
            Return "SUM(" & strCol & ")"
        End If
        Return strCol
    End Function

    '奖惩系数
    Private Function ZyzzBlField(ByVal bSum As Boolean) As String
        Dim strA As String = Agg("bngjdf + bnfgjdf", bSum)
        Dim strB As String = Agg("bngjywf + bnfgjywf", bSum)
        Dim strBl As String
        If Me.CheckBox2.Checked Then
            strBl = "CASE WHEN " & strA & " <> 0 THEN " & strB & " / " & strA & " * " & RatioText(Me.TxtZyzz) & " ELSE 0 END"
        Else
            strBl = "CASE WHEN " & RatioText(Me.TxtGdjcbl) & " <> 0 THEN " & RatioText(Me.TxtGdjcbl) & " ELSE " & strBlInner(bSum) & " END"
        End If
        Return strBl
    End Function

    Private Function strBlInner(ByVal bSum As Boolean) As String
        Dim strA As String = Agg("bngjdf + bnfgjdf", bSum)
        Dim strB As String = Agg("bngjywf + bnfgjywf", bSum)
        Return "CASE WHEN " & strA & " <> 0 THEN " & strB & " / " & strA & " * " & RatioText(Me.TxtZyzz) & " ELSE 0 END"
    End Function

    '非关键客户回笼增长部分
    Private Function ZyzzBase(ByVal bSum As Boolean) As String
        If Me.CheckBox2.Checked Then
            Return Agg("bnfgjdf - snfgjdf - bnfgjbjs", bSum)
        End If
        Return Agg("bnfgjdf - snfgjdf - bnfgjbjs + snfgjbjs", bSum)
    End Function

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

    Private Function BaseField(ByVal bSum As Boolean) As String
        Dim strArr As String() = StrSumCol.Split(",")
        Dim strSb As New System.Text.StringBuilder
        For i As Integer = 0 To strArr.Length - 1
            If strSb.Length > 0 Then
                strSb.Append(",")
            End If
            strSb.Append(Agg(strArr(i), bSum) & " AS " & strArr(i))
        Next
        Return strSb.ToString
    End Function

    '生成明细SQL
    Private Function DetailSql(ByVal strDwdm As String, ByVal strDwmc As String) As String
        Dim strTbl As String = "rcdata_" & strDwdm & ".gl_ywfjsb"
        Dim strXsl As String = "rcdata_" & strDwdm & ".rc_khxslb"
        Dim strKh As String = "rcdata_" & strDwdm & ".rc_khxx"
        Dim strZy As String = "rcdata_" & strDwdm & ".rc_zyxx"
        Dim strKs As String = "gl_ywfjsb.cperiod >= ? AND gl_ywfjsb.cperiod <= ?"
        '本年关键客户
        Dim strU1 As String = "(SELECT gl_ywfjsb.zydm,SUM(COALESCE(gl_ywfjsb.bydf,0.0) - COALESCE(gl_ywfjsb.tiexije,0.0) - COALESCE(gl_ywfjsb.yongjinje,0.0)) AS bngjdf,0 AS bnfgjdf,0 AS bnfgjbjs,0 AS sngjdf,0 AS snfgjdf,0 AS snfgjbjs,SUM(gl_ywfjsb.ywf_bz) AS bngjywf,0 AS bnfgjywf,0 AS sngjywf,0 AS snfgjywf FROM " & strTbl & " WHERE " & strKs & " AND EXISTS (SELECT 1 FROM " & strXsl & " WHERE " & strXsl & ".gjxslb = 1 AND " & strXsl & ".xslbdm = gl_ywfjsb.xslbdm) GROUP BY gl_ywfjsb.zydm)"
        '本年非关键客户
        Dim strU2 As String = "(SELECT gl_ywfjsb.zydm,0 AS bngjdf,SUM(COALESCE(gl_ywfjsb.bydf,0.0) - COALESCE(gl_ywfjsb.tiexije,0.0) - COALESCE(gl_ywfjsb.yongjinje,0.0)) AS bnfgjdf,0 AS bnfgjbjs,0 AS sngjdf,0 AS snfgjdf,0 AS snfgjbjs,0 AS bngjywf,SUM(gl_ywfjsb.ywf_bz) AS bnfgjywf,0 AS sngjywf,0 AS snfgjywf FROM " & strTbl & " WHERE " & strKs & " AND EXISTS (SELECT 1 FROM " & strXsl & " WHERE " & strXsl & ".gjxslb <> 1 AND " & strXsl & ".xslbdm = gl_ywfjsb.xslbdm) GROUP BY gl_ywfjsb.zydm)"
        '本年非关键客户不计算增长部分
        Dim strU3 As String = "(SELECT gl_ywfjsb.zydm,0 AS bngjdf,0 AS bnfgjdf,SUM(COALESCE(gl_ywfjsb.bydf,0.0) - COALESCE(gl_ywfjsb.tiexije,0.0) - COALESCE(gl_ywfjsb.yongjinje,0.0)) AS bnfgjbjs,0 AS sngjdf,0 AS snfgjdf,0 AS snfgjbjs,0 AS bngjywf,0 AS bnfgjywf,0 AS sngjywf,0 AS snfgjywf FROM " & strTbl & " WHERE " & strKs & " AND EXISTS (SELECT 1 FROM " & strKh & " WHERE " & strKh & ".khdm = gl_ywfjsb.khdm AND " & strKh & ".bywfjszz <> 1) AND EXISTS (SELECT 1 FROM " & strXsl & " WHERE " & strXsl & ".gjxslb <> 1 AND " & strXsl & ".xslbdm = gl_ywfjsb.xslbdm) GROUP BY gl_ywfjsb.zydm)"
        Dim strSql As String
        If Me.CheckBox2.Checked Then
            '按业务员任务数计算增长比：上年非关键客户以业务员任务数(rws)计
            Dim strU4 As String = "(SELECT gl_ywfzyrw.zydm,0 AS bngjdf,0 AS bnfgjdf,0 AS bnfgjbjs,0 AS sngjdf,SUM(gl_ywfzyrw.rws) AS snfgjdf,0 AS snfgjbjs,0 AS bngjywf,0 AS bnfgjywf,0 AS sngjywf,0 AS snfgjywf FROM rcdata_" & strDwdm & ".gl_ywfzyrw WHERE gl_ywfzyrw.kjnd = ? GROUP BY gl_ywfzyrw.zydm)"
            strSql = strU1 & " UNION ALL " & strU2 & " UNION ALL " & strU3 & " UNION ALL " & strU4
        Else
            '上年关键客户
            Dim strU4 As String = "(SELECT gl_ywfjsb.t_zydm AS zydm,0 AS bngjdf,0 AS bnfgjdf,0 AS bnfgjbjs,SUM(COALESCE(gl_ywfjsb.bydf,0.0) - COALESCE(gl_ywfjsb.tiexije,0.0) - COALESCE(gl_ywfjsb.yongjinje,0.0)) AS sngjdf,0 AS snfgjdf,0 AS snfgjbjs,0 AS bngjywf,0 AS bnfgjywf,SUM(gl_ywfjsb.ywf_bz) AS sngjywf,0 AS snfgjywf FROM " & strTbl & " WHERE gl_ywfjsb.cperiod >= ? AND gl_ywfjsb.cperiod <= ? AND EXISTS (SELECT 1 FROM " & strXsl & " WHERE " & strXsl & ".gjxslb = 1 AND " & strXsl & ".xslbdm = gl_ywfjsb.t_xslbdm) GROUP BY gl_ywfjsb.t_zydm)"
            '上年非关键客户
            Dim strU5 As String = "(SELECT gl_ywfjsb.t_zydm AS zydm,0 AS bngjdf,0 AS bnfgjdf,0 AS bnfgjbjs,0 AS sngjdf,SUM(COALESCE(gl_ywfjsb.bydf,0.0) - COALESCE(gl_ywfjsb.tiexije,0.0) - COALESCE(gl_ywfjsb.yongjinje,0.0)) AS snfgjdf,0 AS snfgjbjs,0 AS bngjywf,0 AS bnfgjywf,0 AS sngjywf,SUM(gl_ywfjsb.ywf_bz) AS snfgjywf FROM " & strTbl & " WHERE gl_ywfjsb.cperiod >= ? AND gl_ywfjsb.cperiod <= ? AND EXISTS (SELECT 1 FROM " & strXsl & " WHERE " & strXsl & ".gjxslb <> 1 AND " & strXsl & ".xslbdm = gl_ywfjsb.t_xslbdm) GROUP BY gl_ywfjsb.t_zydm)"
            '上年非关键客户不计算增长部分
            Dim strU6 As String = "(SELECT gl_ywfjsb.t_zydm AS zydm,0 AS bngjdf,0 AS bnfgjdf,0 AS bnfgjbjs,0 AS sngjdf,0 AS snfgjdf,SUM(COALESCE(gl_ywfjsb.bydf,0.0) - COALESCE(gl_ywfjsb.tiexije,0.0) - COALESCE(gl_ywfjsb.yongjinje,0.0)) AS snfgjbjs,0 AS bngjywf,0 AS bnfgjywf,0 AS sngjywf,SUM(gl_ywfjsb.ywf_bz) AS snfgjywf FROM " & strTbl & " WHERE gl_ywfjsb.cperiod >= ? AND gl_ywfjsb.cperiod <= ? AND EXISTS (SELECT 1 FROM " & strKh & " WHERE " & strKh & ".khdm = gl_ywfjsb.khdm AND " & strKh & ".bywfjszz <> 1) AND EXISTS (SELECT 1 FROM " & strXsl & " WHERE " & strXsl & ".gjxslb <> 1 AND " & strXsl & ".xslbdm = gl_ywfjsb.t_xslbdm) GROUP BY gl_ywfjsb.t_zydm)"
            strSql = strU1 & " UNION ALL " & strU2 & " UNION ALL " & strU3 & " UNION ALL " & strU4 & " UNION ALL " & strU5 & " UNION ALL " & strU6
        End If
        Return "SELECT '" & strDwdm & "' AS dwdm,'" & strDwmc & "' AS dwmc,1 AS px,ywfzyzzhzb.zydm,(SELECT NVL(" & strZy & ".zymc,'') FROM " & strZy & " WHERE " & strZy & ".zydm = ywfzyzzhzb.zydm) AS zymc," & BaseField(True) & " FROM (SELECT zydm," & SumField() & " FROM (" & strSql & ") ywfzyzzhza GROUP BY zydm) ywfzyzzhzb"
    End Function

    '插入参数
    Private Sub AddDetailParameter()
        Dim strNe As String = Me.NudYear.Value.ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
        Dim strKsr As String = Me.NudYear.Value.ToString & Me.NudMonthBegin.Value.ToString.PadLeft(2, "0")
        Dim strBne As String = (Me.NudYear.Value - 1).ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
        Dim strBns As String = (Me.NudYear.Value - 1).ToString & Me.NudMonthBegin.Value.ToString.PadLeft(2, "0")
        '本年
        rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strKsr
        rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strNe
        rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strKsr
        rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strNe
        rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strKsr
        rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strNe
        '上年
        If Not Me.CheckBox2.Checked Then
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strBns
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strBne
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strBns
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strBne
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strBns
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strBne
        Else
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = (Me.NudYear.Value - 1).ToString
        End If
    End Sub

    '插入各账套明细
    Private Sub ReadDetail(ByVal strDwdm As String, ByVal strDwmc As String)
        rcOleDbCommand.CommandText = "INSERT INTO " & StrTempTable & " (dwdm,dwmc,px,zydm,zymc,bngjdf,bngjywf,bnfgjdf,bnfgjbjs,bnfgjywf,sngjdf,sngjywf,snfgjdf,snfgjbjs,snfgjywf) " & DetailSql(strDwdm, strDwmc)
        rcOleDbCommand.Parameters.Clear()
        AddDetailParameter()
        rcOleDbCommand.ExecuteNonQuery()
    End Sub

    '从临时表生成报表
    Private Sub FillReport(ByVal strDataTable As String)
        Dim strSel As String = "dwdm,dwmc,px,zydm,zymc," & BaseField(False) & "," & ZyzzBlField(False) & " AS zyzzbl," & ZyzzBlField(False) & " * CASE WHEN " & ZyzzBase(False) & " > 0 THEN " & ZyzzBase(False) & " / 100 ELSE 0 END AS zyzzje"
        If rcDataset.Tables(strDataTable) IsNot Nothing Then
            rcDataset.Tables(strDataTable).Clear()
        End If
        '明细
        rcOleDbCommand.CommandText = "SELECT " & strSel & " FROM " & StrTempTable & " ORDER BY zydm"
        rcOleDbCommand.Parameters.Clear()
        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
        rcOleDbDataAdpt.Fill(rcDataset, strDataTable)
        '各账套小计
        rcOleDbCommand.CommandText = "SELECT dwdm,dwmc,2 AS px,'' AS zydm,'' AS zymc," & BaseField(True) & "," & ZyzzBlField(True) & " AS zyzzbl," & ZyzzBlField(True) & " * CASE WHEN " & ZyzzBase(True) & " > 0 THEN " & ZyzzBase(True) & " / 100 ELSE 0 END AS zyzzje FROM " & StrTempTable & " GROUP BY dwdm,dwmc"
        rcOleDbCommand.Parameters.Clear()
        rcOleDbDataAdpt.Fill(rcDataset, strDataTable)
        '合计
        rcOleDbCommand.CommandText = "SELECT '" & MdlYwfHzHelper.StrTotalDwdm & "' AS dwdm,'合计' AS dwmc,3 AS px,'' AS zydm,'合计' AS zymc," & BaseField(True) & "," & ZyzzBlField(True) & " AS zyzzbl," & ZyzzBlField(True) & " * CASE WHEN " & ZyzzBase(True) & " > 0 THEN " & ZyzzBase(True) & " / 100 ELSE 0 END AS zyzzje FROM " & StrTempTable
        rcOleDbCommand.Parameters.Clear()
        rcOleDbDataAdpt.Fill(rcDataset, strDataTable)
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim i As Integer
        If Me.ListBoxYixuanDwdm.Items.Count = 0 Then
            MsgBox("请选择核算单位。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
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
                ReadDetail(strDwdm, MdlYwfHzHelper.DwmcOf(Me.ListBoxYixuanDwdm.Items(i).ToString).Replace("'", "''"))
            Next
            FillReport("ywfzyzzhz")
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
        If Me.CheckBox1.Checked Then
            For i = 0 To rcDataset.Tables("ywfzyzzhz").Rows.Count - 1
                If Val(rcDataset.Tables("ywfzyzzhz").Rows(i).Item("px")) = 1 Then
                    If Val(rcDataset.Tables("ywfzyzzhz").Rows(i).Item("bngjdf")) = 0 And Val(rcDataset.Tables("ywfzyzzhz").Rows(i).Item("bnfgjdf")) = 0 And Val(rcDataset.Tables("ywfzyzzhz").Rows(i).Item("sngjdf")) = 0 And Val(rcDataset.Tables("ywfzyzzhz").Rows(i).Item("snfgjdf")) = 0 Then
                        rcDataset.Tables("ywfzyzzhz").Rows(i).Delete()
                    End If
                End If
            Next
        End If
        '调用表单
        rcDataViewReport = New DataView(rcDataset.Tables("ywfzyzzhz"), "TRUE", "dwdm,px,zydm", DataViewRowState.CurrentRows)
        Dim rcFrm As New FrmYwfZyzzHzHzz
        With rcFrm
            .ParaDataSet = rcDataset
            .paraDataView = rcDataViewReport
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

    Private Sub BtnToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnToExcel.Click
        If rcDataViewReport Is Nothing OrElse rcDataViewReport.Count = 0 Then
            MsgBox("没有数据！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        Dim rcExcelApp As Excel.Application = Nothing
        Try
            rcExcelApp = New Excel.Application
            Dim rcExcelWorkbook As Excel.Workbook = rcExcelApp.Workbooks().Add
            rcExcelApp.Visible = True
            MdlYwfHzHelper.WriteDataViewToSheet(rcExcelWorkbook.Worksheets("sheet1"), rcDataViewReport, "", "", "", "")
        Catch ex As Exception
            MsgBox("数据导出失败！请查看是否已经安装了Excel。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        End Try
    End Sub

#End Region

End Class
