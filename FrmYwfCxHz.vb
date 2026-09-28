Imports System.Data.OleDb
Imports Microsoft.Office.Interop

Public Class FrmYwfCxHz
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
    Private Const StrTempTable As String = "t_ywfcxhz"
    '报表输出字段
    Private Const StrSelAll As String = "dwdm,dwmc,_px,cperiod,khdm,khmc,zydm,zymc,xslbdm,ywfbl,newkhbl,skqx,byjf,bydf,qmye,jf01,jf02,jf03,jf04,jf05,jf06,jf07,jf08,jf09,jf10,jf11,jf12,jf13,jf14,df01,df02,df03,df04,df05,df06,df07,df08,df09,df10,df11,df12,df13,df14,ywf_bz,ywf_newkh,ywf_zl,cdhpje,ywf_cdhp,gylpjje,ywf_gylpj,tiexije,ywf_tx,skje_yj,yongjinje,ywf_yj,daizhang,ywf_dz,susong,ywf_ss,ywf_hlc,ywf_hj"
    '临时表字段
    Private Const StrColAll As String = "dwdm varchar2(4),dwmc varchar2(200),_px number(2,0),cperiod varchar2(6),khdm varchar2(15),khmc varchar2(200),zydm varchar2(12),zymc varchar2(30),xslbdm varchar2(60),ywfbl number(10,3),newkhbl number(10,3),skqx number(4,0),byjf number(14,2),bydf number(14,2),qmye number(14,2),jf01 number(14,2),jf02 number(14,2),jf03 number(14,2),jf04 number(14,2),jf05 number(14,2),jf06 number(14,2),jf07 number(14,2),jf08 number(14,2),jf09 number(14,2),jf10 number(14,2),jf11 number(14,2),jf12 number(14,2),jf13 number(14,2),jf14 number(14,2),df01 number(14,2),df02 number(14,2),df03 number(14,2),df04 number(14,2),df05 number(14,2),df06 number(14,2),df07 number(14,2),df08 number(14,2),df09 number(14,2),df10 number(14,2),df11 number(14,2),df12 number(14,2),df13 number(14,2),df14 number(14,2),ywf_bz number(14,2),ywf_newkh number(14,2),ywf_zl number(14,2),cdhpje number(14,2),ywf_cdhp number(14,2),gylpjje number(14,2),ywf_gylpj number(14,2),tiexije number(14,2),ywf_tx number(14,2),skje_yj number(14,2),yongjinje number(14,2),ywf_yj number(14,2),daizhang number(14,2),ywf_dz number(14,2),susong number(14,2),ywf_ss number(14,2),ywf_hlc number(14,2),ywf_hj number(14,2)"
    '汇总金额字段
    Private Const StrSumCol As String = "byjf,bydf,qmye,jf01,jf02,jf03,jf04,jf05,jf06,jf07,jf08,jf09,jf10,jf11,jf12,jf13,jf14,df01,df02,df03,df04,df05,df06,df07,df08,df09,df10,df11,df12,df13,df14,ywf_bz,ywf_newkh,ywf_zl,cdhpje,ywf_cdhp,gylpjje,ywf_gylpj,tiexije,ywf_tx,skje_yj,yongjinje,ywf_yj,daizhang,ywf_dz,susong,ywf_ss,ywf_hlc,ywf_hj"

#Region "初始化"

    Private Sub FrmYwfCxHz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

    '取得"小计"、"合计"行的金额字段
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

    '小计、合计行的非金额字段
    Private Function BlankField(ByVal strRowName As String) As String
        Return "'' AS cperiod,'' AS khdm,'" & strRowName & "' AS khmc,'' AS zydm,'' AS zymc,'' AS xslbdm,NULL AS ywfbl,NULL AS newkhbl,NULL AS skqx,"
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
                rcOleDbCommand.CommandText = "INSERT INTO " & StrTempTable & " (dwdm,dwmc,_px,cperiod,khdm,khmc,zydm,zymc,xslbdm,ywfbl,newkhbl,skqx,byjf,bydf,qmye,jf01,jf02,jf03,jf04,jf05,jf06,jf07,jf08,jf09,jf10,jf11,jf12,jf13,jf14,df01,df02,df03,df04,df05,df06,df07,df08,df09,df10,df11,df12,df13,df14,ywf_bz,ywf_newkh,ywf_zl,cdhpje,ywf_cdhp,gylpjje,ywf_gylpj,tiexije,ywf_tx,skje_yj,yongjinje,ywf_yj,daizhang,ywf_dz,susong,ywf_ss,ywf_hlc,ywf_hj) SELECT '" & strDwdm & "','" & strDwmc & "',1 AS _px,gl_ywfjsb.cperiod,gl_ywfjsb.khdm,gl_ywfjsb.khmc,gl_ywfjsb.zydm,gl_ywfjsb.zymc,gl_ywfjsb.xslbdm,gl_ywfjsb.ywfbl,gl_ywfjsb.newkhbl,gl_ywfjsb.skqx,gl_ywfjsb.byjf,gl_ywfjsb.bydf,gl_ywfjsb.qmye,gl_ywfjsb.jf01,gl_ywfjsb.jf02,gl_ywfjsb.jf03,gl_ywfjsb.jf04,gl_ywfjsb.jf05,gl_ywfjsb.jf06,gl_ywfjsb.jf07,gl_ywfjsb.jf08,gl_ywfjsb.jf09,gl_ywfjsb.jf10,gl_ywfjsb.jf11,gl_ywfjsb.jf12,gl_ywfjsb.jf13,gl_ywfjsb.jf14,gl_ywfjsb.df01,gl_ywfjsb.df02,gl_ywfjsb.df03,gl_ywfjsb.df04,gl_ywfjsb.df05,gl_ywfjsb.df06,gl_ywfjsb.df07,gl_ywfjsb.df08,gl_ywfjsb.df09,gl_ywfjsb.df10,gl_ywfjsb.df11,gl_ywfjsb.df12,gl_ywfjsb.df13,gl_ywfjsb.df14,gl_ywfjsb.ywf_bz,gl_ywfjsb.ywf_newkh,0 - gl_ywfjsb.ywf_zl AS ywf_zl,gl_ywfjsb.cdhpje,0 - gl_ywfjsb.ywf_cdhp AS ywf_cdhp,gl_ywfjsb.gylpjje,0 - gl_ywfjsb.ywf_gylpj AS ywf_gylpj,gl_ywfjsb.tiexije,0 - gl_ywfjsb.ywf_tx AS ywf_tx,gl_ywfjsb.skje_yj,gl_ywfjsb.yongjinje,0 - gl_ywfjsb.ywf_yj AS ywf_yj,gl_ywfjsb.daizhang,0 - gl_ywfjsb.ywf_dz AS ywf_dz,gl_ywfjsb.susong,0 - gl_ywfjsb.ywf_ss AS ywf_ss,gl_ywfjsb.ywf_hlc,NVL(gl_ywfjsb.ywf_bz,0) + NVL(gl_ywfjsb.ywf_newkh,0) - NVL(gl_ywfjsb.ywf_zl,0) - NVL(gl_ywfjsb.ywf_cdhp,0) - NVL(gl_ywfjsb.ywf_gylpj,0) - NVL(gl_ywfjsb.ywf_tx,0) - NVL(gl_ywfjsb.ywf_yj,0) - NVL(gl_ywfjsb.ywf_dz,0) - NVL(gl_ywfjsb.ywf_ss,0) + NVL(gl_ywfjsb.ywf_hlc,0) AS ywf_hj FROM rcdata_" & strDwdm & ".gl_ywfjsb WHERE gl_ywfjsb.cperiod >= ? AND gl_ywfjsb.cperiod <= ? AND NVL(gl_ywfjsb.zydm,'~') = NVL(?, gl_ywfjsb.zydm) AND NVL(gl_ywfjsb.khdm,'~') = NVL(?, gl_ywfjsb.khdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthBegin.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty(Me.TxtZydm.Text), DBNull.Value, Trim(Me.TxtZydm.Text))
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty(Me.TxtKhdm.Text), DBNull.Value, Trim(Me.TxtKhdm.Text))
                rcOleDbCommand.ExecuteNonQuery()
            Next
            If rcDataset.Tables("gl_ywfjsb") IsNot Nothing Then
                rcDataset.Tables("gl_ywfjsb").Clear()
            End If
            '明细
            rcOleDbCommand.CommandText = "SELECT " & StrSelAll & " FROM " & StrTempTable & " ORDER BY dwdm,cperiod,zydm,khdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            rcOleDbDataAdpt.Fill(rcDataset, "gl_ywfjsb")
            '各账套小计
            rcOleDbCommand.CommandText = "SELECT dwdm,dwmc,2 AS _px," & BlankField("小计") & SumField() & " FROM " & StrTempTable & " GROUP BY dwdm,dwmc"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.Fill(rcDataset, "gl_ywfjsb")
            '合计
            rcOleDbCommand.CommandText = "SELECT '" & MdlYwfHzHelper.StrTotalDwdm & "' AS dwdm,'合计' AS dwmc,3 AS _px," & BlankField("合计") & SumField() & " FROM " & StrTempTable
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
                If Val(rcDataset.Tables("gl_ywfjsb").Rows(i).Item("_px")) = 1 Then
                    If Val(rcDataset.Tables("gl_ywfjsb").Rows(i).Item("byjf")) = 0 And Val(rcDataset.Tables("gl_ywfjsb").Rows(i).Item("bydf")) = 0 And Val(rcDataset.Tables("gl_ywfjsb").Rows(i).Item("qmye")) = 0 And Val(rcDataset.Tables("gl_ywfjsb").Rows(i).Item("ywf_hj")) = 0 Then
                        rcDataset.Tables("gl_ywfjsb").Rows(i).Delete()
                    End If
                End If
            Next
        End If
        '调用表单
        rcDataViewReport = New DataView(rcDataset.Tables("gl_ywfjsb"), "TRUE", "dwdm,_px,cperiod,zydm,khdm", DataViewRowState.CurrentRows)
        Dim rcFrm As New FrmYwfCxHzz
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
