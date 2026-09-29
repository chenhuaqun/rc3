Imports System.Data.OleDb
Imports Microsoft.Office.Interop

Public Class FrmYwfZyHzHz
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
    Private Const StrTempTable As String = "t_ywfzyhhz"
    '报表输出字段
    Private Const StrSelAll As String = "dwdm,dwmc,px,zydm,zymc,xslbdm,TO_CHAR(ywfbl,'0.000') || '%' AS ywfbl,TO_CHAR(newkhbl,'99.9') || '%' AS newkhbl,byjf,bydf,qmye,ywf_bz,ywf_newkh,ywf_zl,cdhpje,ywf_cdhp,gylpjje,ywf_gylpj,tiexije,ywf_tx,skje_yj,yongjinje,ywf_yj,daizhang,ywf_dz,susong,ywf_ss,ywf_hlc,ywf_hj"
    '临时表字段，px 为内部排序列，必须与 MdlYwfHzHelper.StrSortCol 同名
    Private Const StrColAll As String = "dwdm varchar2(4),dwmc varchar2(200),px number(2,0),zydm varchar2(12),zymc varchar2(30),xslbdm varchar2(60),ywfbl number(10,3),newkhbl number(10,3),byjf number(14,2),bydf number(14,2),qmye number(14,2),ywf_bz number(14,2),ywf_newkh number(14,2),ywf_zl number(14,2),cdhpje number(14,2),ywf_cdhp number(14,2),gylpjje number(14,2),ywf_gylpj number(14,2),tiexije number(14,2),ywf_tx number(14,2),skje_yj number(14,2),yongjinje number(14,2),ywf_yj number(14,2),daizhang number(14,2),ywf_dz number(14,2),susong number(14,2),ywf_ss number(14,2),ywf_hlc number(14,2),ywf_hj number(14,2)"
    '汇总金额字段
    Private Const StrSumCol As String = "byjf,bydf,qmye,ywf_bz,ywf_newkh,ywf_zl,cdhpje,ywf_cdhp,gylpjje,ywf_gylpj,tiexije,ywf_tx,skje_yj,yongjinje,ywf_yj,daizhang,ywf_dz,susong,ywf_ss,ywf_hlc,ywf_hj"

#Region "初始化"

    Private Sub FrmYwfZyHzHz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        Me.NudYear.Value = Mid(g_Kjqj, 1, 4)
        Me.NudMonthBegin.Value = Mid(g_Kjqj, 5, 2)
        Me.NudMonthEnd.Value = Mid(g_Kjqj, 5, 2)
        '预选单位编码数据
        MdlYwfHzHelper.LoadAuthorizedDwdm(Me.ListBoxYuxuanDwdm)
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

    Private Function BlankField() As String
        Return "'' AS zydm,'' AS zymc,'' AS xslbdm,NULL AS ywfbl,NULL AS newkhbl,"
    End Function

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
            '创建临时表
            MdlYwfHzHelper.CreateGlobalTempTable(rcOleDbCommand, rcOleDbDataAdpt, rcDataset, StrTempTable, StrColAll)
            '插入各账套明细
            For i = 0 To Me.ListBoxYixuanDwdm.Items.Count - 1
                Dim strDwdm As String = MdlYwfHzHelper.DwdmOfSafe(Me.ListBoxYixuanDwdm.Items(i).ToString)
                If strDwdm.Length = 0 Then
                    Continue For
                End If
                Dim strDwmc As String = MdlYwfHzHelper.DwmcOf(Me.ListBoxYixuanDwdm.Items(i).ToString).Replace("'", "''")
                Dim strTbl As String = "rcdata_" & strDwdm & ".gl_ywfjsb"
                Dim strWhere As String = " AND NVL(gl_ywfjsb.zydm,'~') = NVL(?, gl_ywfjsb.zydm) AND NVL(gl_ywfjsb.khdm,'~') = NVL(?, gl_ywfjsb.khdm)"
                Dim strAa As String = "SELECT gl_ywfjsb.zydm,gl_ywfjsb.zymc,gl_ywfjsb.xslbdm,gl_ywfjsb.ywfbl,gl_ywfjsb.newkhbl,SUM(gl_ywfjsb.byjf) AS byjf,SUM(gl_ywfjsb.bydf) AS bydf,SUM(gl_ywfjsb.ywf_bz) AS ywf_bz,SUM(gl_ywfjsb.ywf_newkh) AS ywf_newkh,SUM(0 - gl_ywfjsb.ywf_zl) AS ywf_zl,SUM(gl_ywfjsb.cdhpje) AS cdhpje,SUM(0 - gl_ywfjsb.ywf_cdhp) AS ywf_cdhp,SUM(gl_ywfjsb.gylpjje) AS gylpjje,SUM(0 - gl_ywfjsb.ywf_gylpj) AS ywf_gylpj,SUM(gl_ywfjsb.tiexije) AS tiexije,SUM(0 - gl_ywfjsb.ywf_tx) AS ywf_tx,SUM(gl_ywfjsb.skje_yj) AS skje_yj,SUM(gl_ywfjsb.yongjinje) AS yongjinje,SUM(0 - gl_ywfjsb.ywf_yj) AS ywf_yj,SUM(gl_ywfjsb.daizhang) AS daizhang,SUM(0 - gl_ywfjsb.ywf_dz) AS ywf_dz,SUM(gl_ywfjsb.susong) AS susong,SUM(0 - gl_ywfjsb.ywf_ss) AS ywf_ss,SUM(gl_ywfjsb.ywf_hlc) AS ywf_hlc,SUM(NVL(gl_ywfjsb.ywf_bz,0) + NVL(gl_ywfjsb.ywf_newkh,0) - NVL(gl_ywfjsb.ywf_zl,0) - NVL(gl_ywfjsb.ywf_cdhp,0) - NVL(gl_ywfjsb.ywf_gylpj,0) - NVL(gl_ywfjsb.ywf_tx,0) - NVL(gl_ywfjsb.ywf_yj,0) - NVL(gl_ywfjsb.ywf_dz,0) - NVL(gl_ywfjsb.ywf_ss,0) + NVL(gl_ywfjsb.ywf_hlc,0)) AS ywf_hj FROM " & strTbl & " WHERE gl_ywfjsb.cperiod >= ? AND gl_ywfjsb.cperiod <= ?" & strWhere & " GROUP BY gl_ywfjsb.zydm,gl_ywfjsb.zymc,gl_ywfjsb.xslbdm,gl_ywfjsb.ywfbl,gl_ywfjsb.newkhbl"
                Dim strBb As String = "SELECT gl_ywfjsb.zydm,gl_ywfjsb.zymc,gl_ywfjsb.xslbdm,gl_ywfjsb.ywfbl,gl_ywfjsb.newkhbl,SUM(gl_ywfjsb.qmye) AS qmye FROM " & strTbl & " WHERE EXISTS (SELECT 1 FROM (SELECT MAX(gl_ywfjsba.cperiod) AS cperiod,gl_ywfjsba.khdm,gl_ywfjsba.zydm FROM " & strTbl & " gl_ywfjsba WHERE gl_ywfjsba.cperiod >= ? AND gl_ywfjsba.cperiod <= ? GROUP BY gl_ywfjsba.khdm,gl_ywfjsba.zydm) gl_ywfjsbb WHERE gl_ywfjsbb.cperiod = gl_ywfjsb.cperiod AND gl_ywfjsbb.khdm = gl_ywfjsb.khdm AND gl_ywfjsbb.zydm = gl_ywfjsb.zydm)" & strWhere & " GROUP BY gl_ywfjsb.zydm,gl_ywfjsb.zymc,gl_ywfjsb.xslbdm,gl_ywfjsb.ywfbl,gl_ywfjsb.newkhbl"
                rcOleDbCommand.CommandText = "INSERT INTO " & StrTempTable & " (dwdm,dwmc,px,zydm,zymc,xslbdm,ywfbl,newkhbl,byjf,bydf,qmye,ywf_bz,ywf_newkh,ywf_zl,cdhpje,ywf_cdhp,gylpjje,ywf_gylpj,tiexije,ywf_tx,skje_yj,yongjinje,ywf_yj,daizhang,ywf_dz,susong,ywf_ss,ywf_hlc,ywf_hj) SELECT '" & strDwdm & "','" & strDwmc & "',1 AS px,aa.zydm,aa.zymc,aa.xslbdm,aa.ywfbl,aa.newkhbl,aa.byjf,aa.bydf,bb.qmye,aa.ywf_bz,aa.ywf_newkh,aa.ywf_zl,aa.cdhpje,aa.ywf_cdhp,aa.gylpjje,aa.ywf_gylpj,aa.tiexije,aa.ywf_tx,aa.skje_yj,aa.yongjinje,aa.ywf_yj,aa.daizhang,aa.ywf_dz,aa.susong,aa.ywf_ss,aa.ywf_hlc,aa.ywf_hj FROM (" & strAa & ") aa LEFT JOIN (" & strBb & ") bb ON aa.zydm = bb.zydm AND aa.zymc = bb.zymc AND NVL(aa.xslbdm,'~') = NVL(bb.xslbdm,'~') AND NVL(aa.ywfbl,0.0) = NVL(bb.ywfbl,0.0) AND aa.newkhbl = bb.newkhbl"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthBegin.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty(Me.TxtZydm.Text), DBNull.Value, Trim(Me.TxtZydm.Text))
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty(Me.TxtKhdm.Text), DBNull.Value, Trim(Me.TxtKhdm.Text))
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthBegin.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty(Me.TxtZydm.Text), DBNull.Value, Trim(Me.TxtZydm.Text))
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty(Me.TxtKhdm.Text), DBNull.Value, Trim(Me.TxtKhdm.Text))
                rcOleDbCommand.ExecuteNonQuery()
            Next
            If rcDataset.Tables("gl_ywfjsb") IsNot Nothing Then
                rcDataset.Tables("gl_ywfjsb").Clear()
            End If
            '明细
            rcOleDbCommand.CommandText = "SELECT " & StrSelAll & " FROM " & StrTempTable & " ORDER BY dwdm,zydm,xslbdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            rcOleDbDataAdpt.Fill(rcDataset, "gl_ywfjsb")
            '各账套小计
            rcOleDbCommand.CommandText = "SELECT dwdm,dwmc,2 AS px," & BlankField() & SumField() & " FROM " & StrTempTable & " GROUP BY dwdm,dwmc"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.Fill(rcDataset, "gl_ywfjsb")
            '合计
            rcOleDbCommand.CommandText = "SELECT '" & MdlYwfHzHelper.StrTotalDwdm & "' AS dwdm,'合计' AS dwmc,3 AS px," & BlankField() & SumField() & " FROM " & StrTempTable
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.Fill(rcDataset, "gl_ywfjsb")
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
            For i = 0 To rcDataset.Tables("gl_ywfjsb").Rows.Count - 1
                If Val(rcDataset.Tables("gl_ywfjsb").Rows(i).Item("px")) = 1 Then
                    If Val(rcDataset.Tables("gl_ywfjsb").Rows(i).Item("byjf")) = 0 And Val(rcDataset.Tables("gl_ywfjsb").Rows(i).Item("bydf")) = 0 And Val(rcDataset.Tables("gl_ywfjsb").Rows(i).Item("qmye")) = 0 And Val(rcDataset.Tables("gl_ywfjsb").Rows(i).Item("ywf_hj")) = 0 Then
                        rcDataset.Tables("gl_ywfjsb").Rows(i).Delete()
                    End If
                End If
            Next
        End If
        '调用表单
        rcDataViewReport = New DataView(rcDataset.Tables("gl_ywfjsb"), "TRUE", "dwdm,px,zydm,xslbdm", DataViewRowState.CurrentRows)
        Dim rcFrm As New FrmYwfZyHzHzz
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
