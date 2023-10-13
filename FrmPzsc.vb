Imports System.Data.OleDb

Public Class FrmPzsc

#Region "定义变量"

    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '数据更新传递
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable
    ReadOnly dtPz As New DataTable("rc_pz")
    Dim dateKsrq As Date '开始日期
    Dim dateJsrq As Date '结束日期
    Dim strPzlxdm As String = ""
    Dim strJfKmdm As String = ""
    Dim strJfKmmc As String = ""
    Dim strDfKmdm As String = ""
    Dim strDfKmmc As String = ""
#End Region

    Private Sub FrmPzsc_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '设置DataGridView
        Me.rcDataGridView.AutoGenerateColumns = False
        Me.rcDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.rcDataGridView.Columns("ColJe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColJe").DefaultCellStyle.Format = g_FormatJe
        '默认值
        Me.NudYear.Value = Mid(g_Kjqj, 1, 4)
        Me.NudMonth.Value = Mid(g_Kjqj, 5, 2)
        '数据绑定
        dtPz.Columns.Add("xz", Type.GetType("System.Boolean"))
        dtPz.Columns.Add("pzrq", Type.GetType("System.DateTime"))
        dtPz.Columns.Add("djh", Type.GetType("System.String"))
        dtPz.Columns.Add("je", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtPz)
        With dtPz
            .Columns("xz").DefaultValue = False
            .Columns("djh").DefaultValue = ""
            .Columns("je").DefaultValue = 0.0
        End With
    End Sub

#Region ""

    Private Sub RadioBtnPoRkd_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioBtnPoRkd.CheckedChanged
    End Sub

#End Region

    Private Sub BtnImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImp.Click
        dateKsrq = getInvBegin(Me.NudYear.Value, Me.NudMonth.Value)
        dateJsrq = getInvEnd(Me.NudYear.Value, Me.NudMonth.Value)
        '1物料入库单
        If Me.RadioBtnPoRkd.Checked Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT 0 AS xz,po_rkd.djh,po_rkd.rkrq AS pzrq,SUM(po_rkd.je) AS je FROM po_rkd,rc_lx WHERE SUBSTR(po_rkd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(po_rkd.djh,5,4) = rc_lx.kjnd AND rc_lx.lxgs = '物料入库单' AND po_rkd.bdelete <> 1 AND po_rkd.rkrq >= ? AND po_rkd.rkrq <= ? AND po_rkd.bpz <> 1 GROUP BY po_rkd.djh,po_rkd.rkrq ORDER BY po_rkd.djh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_pz") IsNot Nothing Then
                    rcDataset.Tables("rc_pz").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_pz")
            Catch ex As Exception
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            Me.rcDataGridView.DataSource = rcDataset.Tables("rc_pz")
        End If
        '2物料出库单
        If Me.RadioBtnInvCkd.Checked Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT 0 AS xz,inv_ckd.djh,inv_ckd.ckrq AS pzrq,SUM(inv_ckd.je) AS je FROM inv_ckd,rc_lx WHERE SUBSTR(inv_ckd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(inv_ckd.djh,5,4) = rc_lx.kjnd AND rc_lx.lxgs = '物料出库单' AND inv_ckd.bdelete <> 1 AND inv_ckd.ckrq >= ? AND inv_ckd.ckrq <= ? AND inv_ckd.bpz <> 1 GROUP BY inv_ckd.djh,inv_ckd.ckrq ORDER BY inv_ckd.djh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateKsrq
                rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_pz") IsNot Nothing Then
                    rcDataset.Tables("rc_pz").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_pz")
            Catch ex As Exception
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            Me.rcDataGridView.DataSource = rcDataset.Tables("rc_pz")
        End If
        '3产品入库单
        If Me.RadioBtnInvRkd.Checked Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT 0 AS xz,inv_rkd.djh,TRUNC(inv_rkd.rkrq,'mi') AS pzrq,SUM(inv_rkd.je) AS je FROM inv_rkd,rc_lx WHERE SUBSTR(inv_rkd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(inv_rkd.djh,5,4) = rc_lx.kjnd AND rc_lx.lxgs = '产品入库单' AND inv_rkd.bdelete <> 1 AND inv_rkd.rkrq >= ? AND inv_rkd.rkrq <= ? AND inv_rkd.bpz <> 1 GROUP BY inv_rkd.djh,inv_rkd.rkrq ORDER BY inv_rkd.djh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_pz") IsNot Nothing Then
                    rcDataset.Tables("rc_pz").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_pz")
            Catch ex As Exception
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            Me.rcDataGridView.DataSource = rcDataset.Tables("rc_pz")
        End If
        '4产品送货单
        If Me.RadioBtnOeXsd.Checked Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT 0 AS xz,oe_xsd.djh,oe_xsd.xsrq AS pzrq,SUM(oe_xsd.je) AS je FROM oe_xsd,rc_lx WHERE SUBSTR(oe_xsd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_xsd.djh,5,4) = rc_lx.kjnd AND rc_lx.lxgs = '产品送货单' AND oe_xsd.bdelete <> 1 AND oe_xsd.xsrq >= ? AND oe_xsd.xsrq <= ? AND oe_xsd.bpz <> 1 GROUP BY oe_xsd.djh,oe_xsd.xsrq ORDER BY oe_xsd.djh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_pz") IsNot Nothing Then
                    rcDataset.Tables("rc_pz").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_pz")
            Catch ex As Exception
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            Me.rcDataGridView.DataSource = rcDataset.Tables("rc_pz")
        End If
        '5其他应收单
        If Me.RadioBtnOeQtys.Checked Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT 0 AS xz,oe_xsd.djh,oe_xsd.xsrq AS pzrq,SUM(oe_xsd.je) AS je FROM oe_xsd,rc_lx WHERE SUBSTR(oe_xsd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_xsd.djh,5,4) = rc_lx.kjnd AND rc_lx.lxgs = '其他应收单' AND oe_xsd.bdelete <> 1 AND oe_xsd.xsrq >= ? AND oe_xsd.xsrq <= ? AND oe_xsd.bpz <> 1 GROUP BY oe_xsd.djh,oe_xsd.xsrq ORDER BY oe_xsd.djh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_pz") IsNot Nothing Then
                    rcDataset.Tables("rc_pz").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_pz")
            Catch ex As Exception
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            Me.rcDataGridView.DataSource = rcDataset.Tables("rc_pz")
        End If
        '6其他应付单
        If Me.RadioBtnPoQtyf.Checked Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT 0 AS xz,po_rkd.djh,po_rkd.rkrq AS pzrq,SUM(po_rkd.je) AS je FROM po_rkd,rc_lx WHERE SUBSTR(po_rkd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(po_rkd.djh,5,4) = rc_lx.kjnd AND rc_lx.lxgs = '其他应付单' AND po_rkd.bdelete <> 1 AND po_rkd.rkrq >= ? AND po_rkd.rkrq <= ? AND po_rkd.bpz <> 1 GROUP BY po_rkd.djh,po_rkd.rkrq ORDER BY po_rkd.djh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_pz") IsNot Nothing Then
                    rcDataset.Tables("rc_pz").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_pz")
            Catch ex As Exception
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            Me.rcDataGridView.DataSource = rcDataset.Tables("rc_pz")
        End If
        '7收款单
        If Me.RadioBtnArSkd.Checked Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT 0 AS xz,ar_skd.djh,ar_skd.skrq AS pzrq,ar_skd.kmdm,ar_skd.kmmc,ar_skd.je FROM ar_skd,rc_lx WHERE SUBSTR(ar_skd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(ar_skd.djh,5,4) = rc_lx.kjnd AND rc_lx.lxgs = '收款单' AND ar_skd.skrq >= ? AND ar_skd.skrq <= ? AND ar_skd.bpz <> 1 ORDER BY ar_skd.djh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = dateKsrq
                rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_pz") IsNot Nothing Then
                    rcDataset.Tables("rc_pz").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_pz")
            Catch ex As Exception
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            Me.rcDataGridView.DataSource = rcDataset.Tables("rc_pz")
        End If
        '8付款单
        If Me.RadioBtnApFkd.Checked Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT 0 AS xz,ap_fkd.djh,ap_fkd.fkrq AS pzrq,ap_fkd.kmdm,ap_fkd.kmmc,ap_fkd.je FROM ap_fkd,rc_lx WHERE SUBSTR(ap_fkd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(ap_fkd.djh,5,4) = rc_lx.kjnd AND rc_lx.lxgs = '付款单' AND ap_fkd.fkrq >= ? AND ap_fkd.fkrq <= ? AND ap_fkd.bpz <> 1 ORDER BY ap_fkd.djh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = dateKsrq
                rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_pz") IsNot Nothing Then
                    rcDataset.Tables("rc_pz").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_pz")
            Catch ex As Exception
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            Me.rcDataGridView.DataSource = rcDataset.Tables("rc_pz")
        End If

    End Sub

    Private Sub BtnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectAll.Click
        Dim i As Integer
        For i = 0 To rcDataset.Tables("rc_pz").Rows.Count - 1
            rcDataset.Tables("rc_pz").Rows(i).Item("xz") = True
        Next
    End Sub

    Private Sub BtnUnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUnSelectAll.Click
        Dim i As Integer
        For i = 0 To rcDataset.Tables("rc_pz").Rows.Count - 1
            rcDataset.Tables("rc_pz").Rows(i).Item("xz") = False
        Next
    End Sub

    Private Sub BtnPzsc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPzsc.Click
        Dim i As Integer
        'Dim datePzrq As Date = getInvEnd(Me.NudYear.Value, Me.NudMonth.Value)
        Dim strDjh As String = ""
        '取生成凭证的凭证类型
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT parastrvalue FROM rc_para WHERE dwdm = ? AND paraid = '凭证生成中使用的凭证类型' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    strPzlxdm = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
            Else
                MsgBox("请定义凭证生成中使用的凭证类型参数。")
                Return
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message)
            Return
        Finally
            rcOleDbConn.Close()
        End Try

        '1物料入库单
        If Me.RadioBtnPoRkd.Checked Then
            '取借方科目编码名称，取贷方科目编码名称
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT rc_para.parastrvalue,gl_kmxx.kmmc FROM rc_para,gl_kmxx WHERE rc_para.parastrvalue = gl_kmxx.kmdm AND rc_para.dwdm = ? AND rc_para.paraid = '总账原材料科目编码' ORDER BY paraid"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_para") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_para").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
                If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                    If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                        strJfKmdm = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                        strJfKmmc = rcDataset.Tables("rc_para").Rows(0).Item("kmmc")
                    End If
                Else
                    MsgBox("请定义总账原材料科目编码参数。")
                    Return
                End If
                rcOleDbCommand.CommandText = "SELECT rc_para.parastrvalue,gl_kmxx.kmmc FROM rc_para,gl_kmxx WHERE rc_para.parastrvalue = gl_kmxx.kmdm AND rc_para.dwdm = ? AND rc_para.paraid = '总账应付账款科目编码' ORDER BY paraid"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_para") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_para").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
                If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                    If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                        strDfKmdm = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                        strDfKmmc = rcDataset.Tables("rc_para").Rows(0).Item("kmmc")
                    End If
                Else
                    MsgBox("请定义总账应付账款科目编码参数。")
                    Return
                End If
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message)
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            '存储凭证
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                For i = 0 To rcDataset.Tables("rc_pz").Rows.Count - 1
                    If rcDataset.Tables("rc_pz").Rows(i).Item("xz") And rcDataset.Tables("rc_pz").Rows(i).Item("je") <> 0 Then

                        rcOleDbCommand.CommandType = CommandType.StoredProcedure
                        rcOleDbCommand.CommandText = "USP_SAVE_GL_PZ"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = strPzlxdm & Me.NudYear.Value & Me.NudMonth.Value.ToString.PadLeft(2, "0") & "00001"
                        rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                        rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                        rcOleDbCommand.Parameters.Add("@paraDatePzrq", OleDbType.Date, 8).Value = rcDataset.Tables("rc_pz").Rows(i).Item("pzrq")
                        rcOleDbCommand.Parameters.Add("@paraIntFjzs", OleDbType.Integer, 4).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraStrJd", OleDbType.Char, 2).Value = "借"
                        rcOleDbCommand.Parameters.Add("@paraStrZy", OleDbType.VarChar, 50).Value = "物料入库单" & rcDataset.Tables("rc_pz").Rows(i).Item("djh")
                        rcOleDbCommand.Parameters.Add("@paraStrKmdm", OleDbType.VarChar, 15).Value = strJfKmdm
                        rcOleDbCommand.Parameters.Add("@paraStrKmmc", OleDbType.VarChar, 50).Value = strJfKmmc
                        rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrXmdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrXmmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrKhmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrJxzh", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrDfkm", OleDbType.VarChar, 30).Value = strDfKmdm
                        rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraStrBz", OleDbType.VarChar, 8).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDblWb", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblHl", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_pz").Rows(i).Item("je")
                        rcOleDbCommand.Parameters.Add("@paraStrYspz", OleDbType.VarChar, 16).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrJsr", OleDbType.VarChar, 30).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDateWldqr", OleDbType.Date, 8).Value = Nothing
                        rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                        rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                        rcOleDbCommand.ExecuteNonQuery()
                        If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                            If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                                MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                                Return
                            End If
                        End If
                        If rcOleDbCommand.Parameters("@paraStrDjh").Value.GetType.ToString <> "System.DBNull" Then
                            If rcOleDbCommand.Parameters("@paraStrDjh").Value <> "" Then
                                strDjh = rcOleDbCommand.Parameters("@paraStrDjh").Value
                            End If
                        End If
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = strDjh
                        rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                        rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = 2
                        rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                        rcOleDbCommand.Parameters.Add("@paraDatePzrq", OleDbType.Date, 8).Value = rcDataset.Tables("rc_pz").Rows(i).Item("pzrq")
                        rcOleDbCommand.Parameters.Add("@paraIntFjzs", OleDbType.Integer, 4).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraStrJd", OleDbType.Char, 2).Value = "贷"
                        rcOleDbCommand.Parameters.Add("@paraStrZy", OleDbType.VarChar, 50).Value = "物料入库单" & rcDataset.Tables("rc_pz").Rows(i).Item("djh")
                        rcOleDbCommand.Parameters.Add("@paraStrKmdm", OleDbType.VarChar, 15).Value = strDfKmdm
                        rcOleDbCommand.Parameters.Add("@paraStrKmmc", OleDbType.VarChar, 50).Value = strDfKmmc
                        rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrXmdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrXmmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrKhmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrJxzh", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrDfkm", OleDbType.VarChar, 30).Value = strJfKmdm
                        rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraStrBz", OleDbType.VarChar, 8).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDblWb", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblHl", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_pz").Rows(i).Item("je")
                        rcOleDbCommand.Parameters.Add("@paraStrYspz", OleDbType.VarChar, 16).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrJsr", OleDbType.VarChar, 30).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDateWldqr", OleDbType.Date, 8).Value = Nothing
                        rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                        rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                        rcOleDbCommand.ExecuteNonQuery()
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "UPDATE po_rkd SET bpz = 1 WHERE djh = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_pz").Rows(i).Item("djh")
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                Next
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("程序错误1。USP_SAVE_GL_PZ" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            MsgBox("物料入库单本月凭证已经生成完成。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
        End If

        '2物料出库单
        If Me.RadioBtnInvCkd.Checked Then
            '取借方科目编码名称，取贷方科目编码名称
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT rc_para.parastrvalue,gl_kmxx.kmmc FROM rc_para,gl_kmxx WHERE rc_para.parastrvalue = gl_kmxx.kmdm AND rc_para.dwdm = ? AND rc_para.paraid = '总账生产成本科目编码' ORDER BY paraid"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_para") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_para").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
                If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                    If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                        strJfKmdm = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                        strJfKmmc = rcDataset.Tables("rc_para").Rows(0).Item("kmmc")
                    End If
                Else
                    MsgBox("请定义总账生产成本科目编码参数。")
                    Return
                End If
                rcOleDbCommand.CommandText = "SELECT rc_para.parastrvalue,gl_kmxx.kmmc FROM rc_para,gl_kmxx WHERE rc_para.parastrvalue = gl_kmxx.kmdm AND rc_para.dwdm = ? AND rc_para.paraid = '总账原材料科目编码' ORDER BY paraid"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_para") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_para").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
                If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                    If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                        strDfKmdm = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                        strDfKmmc = rcDataset.Tables("rc_para").Rows(0).Item("kmmc")
                    End If
                Else
                    MsgBox("请定义总账原材料科目编码参数。")
                    Return
                End If
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message)
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            '存储凭证
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                For i = 0 To rcDataset.Tables("rc_pz").Rows.Count - 1
                    If rcDataset.Tables("rc_pz").Rows(i).Item("xz") Then
                        rcOleDbCommand.CommandType = CommandType.StoredProcedure
                        rcOleDbCommand.CommandText = "USP_SAVE_GL_PZ"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = strPzlxdm & Me.NudYear.Value & Me.NudMonth.Value.ToString.PadLeft(2, "0") & "00001"
                        rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                        rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                        rcOleDbCommand.Parameters.Add("@paraDatePzrq", OleDbType.Date, 8).Value = rcDataset.Tables("rc_pz").Rows(i).Item("pzrq")
                        rcOleDbCommand.Parameters.Add("@paraIntFjzs", OleDbType.Integer, 4).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraStrJd", OleDbType.Char, 2).Value = "借"
                        rcOleDbCommand.Parameters.Add("@paraStrZy", OleDbType.VarChar, 50).Value = "物料出库单" & rcDataset.Tables("rc_pz").Rows(i).Item("djh")
                        rcOleDbCommand.Parameters.Add("@paraStrKmdm", OleDbType.VarChar, 15).Value = strJfKmdm
                        rcOleDbCommand.Parameters.Add("@paraStrKmmc", OleDbType.VarChar, 50).Value = strJfKmmc
                        rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrXmdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrXmmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrKhmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrJxzh", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrDfkm", OleDbType.VarChar, 30).Value = strDfKmdm
                        rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraStrBz", OleDbType.VarChar, 8).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDblWb", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblHl", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_pz").Rows(i).Item("je")
                        rcOleDbCommand.Parameters.Add("@paraStrYspz", OleDbType.VarChar, 16).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrJsr", OleDbType.VarChar, 30).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDateWldqr", OleDbType.Date, 8).Value = Nothing
                        rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                        rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                        rcOleDbCommand.ExecuteNonQuery()
                        If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                            If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                                MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                                Return
                            End If
                        End If
                        If rcOleDbCommand.Parameters("@paraStrDjh").Value.GetType.ToString <> "System.DBNull" Then
                            If rcOleDbCommand.Parameters("@paraStrDjh").Value <> "" Then
                                strDjh = rcOleDbCommand.Parameters("@paraStrDjh").Value
                            End If
                        End If
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = strDjh
                        rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                        rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = 2
                        rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                        rcOleDbCommand.Parameters.Add("@paraDatePzrq", OleDbType.Date, 8).Value = rcDataset.Tables("rc_pz").Rows(i).Item("pzrq")
                        rcOleDbCommand.Parameters.Add("@paraIntFjzs", OleDbType.Integer, 4).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraStrJd", OleDbType.Char, 2).Value = "贷"
                        rcOleDbCommand.Parameters.Add("@paraStrZy", OleDbType.VarChar, 50).Value = "物料出库单" & rcDataset.Tables("rc_pz").Rows(i).Item("djh")
                        rcOleDbCommand.Parameters.Add("@paraStrKmdm", OleDbType.VarChar, 15).Value = strDfKmdm
                        rcOleDbCommand.Parameters.Add("@paraStrKmmc", OleDbType.VarChar, 50).Value = strDfKmmc
                        rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrXmdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrXmmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrKhmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrJxzh", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrDfkm", OleDbType.VarChar, 30).Value = strJfKmdm
                        rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraStrBz", OleDbType.VarChar, 8).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDblWb", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblHl", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_pz").Rows(i).Item("je")
                        rcOleDbCommand.Parameters.Add("@paraStrYspz", OleDbType.VarChar, 16).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrJsr", OleDbType.VarChar, 30).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDateWldqr", OleDbType.Date, 8).Value = Nothing
                        rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                        rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                        rcOleDbCommand.ExecuteNonQuery()
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "UPDATE inv_ckd SET bpz = 1 WHERE djh = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_pz").Rows(i).Item("djh")
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                Next

                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("程序错误2。USP_SAVE_GL_PZ" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            MsgBox("物料出库单本月凭证已经生成完成。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
        End If
        '3产品入库单
        If Me.RadioBtnInvRkd.Checked Then
            '取借方科目编码名称，取贷方科目编码名称
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT rc_para.parastrvalue,gl_kmxx.kmmc FROM rc_para,gl_kmxx WHERE rc_para.parastrvalue = gl_kmxx.kmdm AND rc_para.dwdm = ? AND rc_para.paraid = '总账库存商品科目编码' ORDER BY paraid"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_para") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_para").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
                If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                    If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                        strJfKmdm = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                        strJfKmmc = rcDataset.Tables("rc_para").Rows(0).Item("kmmc")
                    End If
                Else
                    MsgBox("请定义总账库存商品科目编码参数。")
                    Return
                End If
                rcOleDbCommand.CommandText = "SELECT rc_para.parastrvalue,gl_kmxx.kmmc FROM rc_para,gl_kmxx WHERE rc_para.parastrvalue = gl_kmxx.kmdm AND rc_para.dwdm = ? AND rc_para.paraid = '总账生产成本科目编码' ORDER BY paraid"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_para") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_para").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
                If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                    If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                        strDfKmdm = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                        strDfKmmc = rcDataset.Tables("rc_para").Rows(0).Item("kmmc")
                    End If
                Else
                    MsgBox("请定义总账生产成本科目编码参数。")
                    Return
                End If
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message)
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            '存储凭证
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                For i = 0 To rcDataset.Tables("rc_pz").Rows.Count - 1
                    If rcDataset.Tables("rc_pz").Rows(i).Item("xz") And rcDataset.Tables("rc_pz").Rows(i).Item("je") <> 0 Then
                        rcOleDbCommand.CommandType = CommandType.StoredProcedure
                        rcOleDbCommand.CommandText = "USP_SAVE_GL_PZ"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = strPzlxdm & Me.NudYear.Value & Me.NudMonth.Value.ToString.PadLeft(2, "0") & "00001"
                        rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                        rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                        rcOleDbCommand.Parameters.Add("@paraDatePzrq", OleDbType.Date, 8).Value = rcDataset.Tables("rc_pz").Rows(i).Item("pzrq")
                        rcOleDbCommand.Parameters.Add("@paraIntFjzs", OleDbType.Integer, 4).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraStrJd", OleDbType.Char, 2).Value = "借"
                        rcOleDbCommand.Parameters.Add("@paraStrZy", OleDbType.VarChar, 50).Value = "产品入库单" & rcDataset.Tables("rc_pz").Rows(i).Item("djh")
                        rcOleDbCommand.Parameters.Add("@paraStrKmdm", OleDbType.VarChar, 15).Value = strJfKmdm
                        rcOleDbCommand.Parameters.Add("@paraStrKmmc", OleDbType.VarChar, 50).Value = strJfKmmc
                        rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrXmdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrXmmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrKhmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrJxzh", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrDfkm", OleDbType.VarChar, 30).Value = strDfKmdm
                        rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraStrBz", OleDbType.VarChar, 8).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDblWb", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblHl", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_pz").Rows(i).Item("je")
                        rcOleDbCommand.Parameters.Add("@paraStrYspz", OleDbType.VarChar, 16).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrJsr", OleDbType.VarChar, 30).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDateWldqr", OleDbType.Date, 8).Value = Nothing
                        rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                        rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                        rcOleDbCommand.ExecuteNonQuery()
                        If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                            If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                                MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                                Return
                            End If
                        End If
                        If rcOleDbCommand.Parameters("@paraStrDjh").Value.GetType.ToString <> "System.DBNull" Then
                            If rcOleDbCommand.Parameters("@paraStrDjh").Value <> "" Then
                                strDjh = rcOleDbCommand.Parameters("@paraStrDjh").Value
                            End If
                        End If
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = strDjh
                        rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                        rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = 2
                        rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                        rcOleDbCommand.Parameters.Add("@paraDatePzrq", OleDbType.Date, 8).Value = rcDataset.Tables("rc_pz").Rows(i).Item("pzrq")
                        rcOleDbCommand.Parameters.Add("@paraIntFjzs", OleDbType.Integer, 4).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraStrJd", OleDbType.Char, 2).Value = "贷"
                        rcOleDbCommand.Parameters.Add("@paraStrZy", OleDbType.VarChar, 50).Value = "产品入库单" & rcDataset.Tables("rc_pz").Rows(i).Item("djh")
                        rcOleDbCommand.Parameters.Add("@paraStrKmdm", OleDbType.VarChar, 15).Value = strDfKmdm
                        rcOleDbCommand.Parameters.Add("@paraStrKmmc", OleDbType.VarChar, 50).Value = strDfKmmc
                        rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrXmdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrXmmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrKhmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrJxzh", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrDfkm", OleDbType.VarChar, 30).Value = strJfKmdm
                        rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraStrBz", OleDbType.VarChar, 8).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDblWb", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblHl", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_pz").Rows(i).Item("je")
                        rcOleDbCommand.Parameters.Add("@paraStrYspz", OleDbType.VarChar, 16).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrJsr", OleDbType.VarChar, 30).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDateWldqr", OleDbType.Date, 8).Value = Nothing
                        rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                        rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                        rcOleDbCommand.ExecuteNonQuery()
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "UPDATE inv_rkd SET bpz = 1 WHERE djh = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_pz").Rows(i).Item("djh")
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                Next
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("程序错误1。USP_SAVE_GL_PZ" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            MsgBox("产品入库单本月凭证已经生成完成。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
        End If
        '4产品送货单
        If Me.RadioBtnOeXsd.Checked Then
            '取借方科目编码名称，取贷方科目编码名称
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT rc_para.parastrvalue,gl_kmxx.kmmc FROM rc_para,gl_kmxx WHERE rc_para.parastrvalue = gl_kmxx.kmdm AND rc_para.dwdm = ? AND rc_para.paraid = '总账应收账款科目编码' ORDER BY paraid"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_para") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_para").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
                If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                    If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                        strJfKmdm = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                        strJfKmmc = rcDataset.Tables("rc_para").Rows(0).Item("kmmc")
                    End If
                Else
                    MsgBox("请定义总账应收账款科目编码参数。")
                    Return
                End If
                rcOleDbCommand.CommandText = "SELECT rc_para.parastrvalue,gl_kmxx.kmmc FROM rc_para,gl_kmxx WHERE rc_para.parastrvalue = gl_kmxx.kmdm AND rc_para.dwdm = ? AND rc_para.paraid = '总账主营业务收入科目编码' ORDER BY paraid"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_para") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_para").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
                If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                    If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                        strDfKmdm = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                        strDfKmmc = rcDataset.Tables("rc_para").Rows(0).Item("kmmc")
                    End If
                Else
                    MsgBox("请定义总账主营业务收入科目编码参数。")
                    Return
                End If
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message)
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            '存储凭证
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                For i = 0 To rcDataset.Tables("rc_pz").Rows.Count - 1
                    If rcDataset.Tables("rc_pz").Rows(i).Item("xz") And rcDataset.Tables("rc_pz").Rows(i).Item("je") <> 0 Then
                        rcOleDbCommand.CommandType = CommandType.StoredProcedure
                        rcOleDbCommand.CommandText = "USP_SAVE_GL_PZ"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = strPzlxdm & Me.NudYear.Value & Me.NudMonth.Value.ToString.PadLeft(2, "0") & "00001"
                        rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                        rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                        rcOleDbCommand.Parameters.Add("@paraDatePzrq", OleDbType.Date, 8).Value = rcDataset.Tables("rc_pz").Rows(i).Item("pzrq")
                        rcOleDbCommand.Parameters.Add("@paraIntFjzs", OleDbType.Integer, 4).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraStrJd", OleDbType.Char, 2).Value = "借"
                        rcOleDbCommand.Parameters.Add("@paraStrZy", OleDbType.VarChar, 50).Value = "产品送货单" & rcDataset.Tables("rc_pz").Rows(i).Item("djh")
                        rcOleDbCommand.Parameters.Add("@paraStrKmdm", OleDbType.VarChar, 15).Value = strJfKmdm
                        rcOleDbCommand.Parameters.Add("@paraStrKmmc", OleDbType.VarChar, 50).Value = strJfKmmc
                        rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrXmdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrXmmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrKhmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrJxzh", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrDfkm", OleDbType.VarChar, 30).Value = strDfKmdm
                        rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraStrBz", OleDbType.VarChar, 8).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDblWb", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblHl", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_pz").Rows(i).Item("je")
                        rcOleDbCommand.Parameters.Add("@paraStrYspz", OleDbType.VarChar, 16).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrJsr", OleDbType.VarChar, 30).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDateWldqr", OleDbType.Date, 8).Value = Nothing
                        rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                        rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                        rcOleDbCommand.ExecuteNonQuery()
                        If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                            If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                                MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                                Return
                            End If
                        End If
                        If rcOleDbCommand.Parameters("@paraStrDjh").Value.GetType.ToString <> "System.DBNull" Then
                            If rcOleDbCommand.Parameters("@paraStrDjh").Value <> "" Then
                                strDjh = rcOleDbCommand.Parameters("@paraStrDjh").Value
                            End If
                        End If
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = strDjh
                        rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                        rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = 2
                        rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                        rcOleDbCommand.Parameters.Add("@paraDatePzrq", OleDbType.Date, 8).Value = rcDataset.Tables("rc_pz").Rows(i).Item("pzrq")
                        rcOleDbCommand.Parameters.Add("@paraIntFjzs", OleDbType.Integer, 4).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraStrJd", OleDbType.Char, 2).Value = "贷"
                        rcOleDbCommand.Parameters.Add("@paraStrZy", OleDbType.VarChar, 50).Value = "产品送货单" & rcDataset.Tables("rc_pz").Rows(i).Item("djh")
                        rcOleDbCommand.Parameters.Add("@paraStrKmdm", OleDbType.VarChar, 15).Value = strDfKmdm
                        rcOleDbCommand.Parameters.Add("@paraStrKmmc", OleDbType.VarChar, 50).Value = strDfKmmc
                        rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrXmdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrXmmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrKhmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrJxzh", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrDfkm", OleDbType.VarChar, 30).Value = strJfKmdm
                        rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraStrBz", OleDbType.VarChar, 8).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDblWb", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblHl", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_pz").Rows(i).Item("je")
                        rcOleDbCommand.Parameters.Add("@paraStrYspz", OleDbType.VarChar, 16).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrJsr", OleDbType.VarChar, 30).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDateWldqr", OleDbType.Date, 8).Value = Nothing
                        rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                        rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                        rcOleDbCommand.ExecuteNonQuery()
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "UPDATE oe_xsd SET bpz = 1 WHERE djh = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_pz").Rows(i).Item("djh")
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                Next
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("程序错误1。USP_SAVE_GL_PZ" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            MsgBox("产品送货单本月凭证已经生成完成。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
        End If
        '5其他应收单
        If Me.RadioBtnOeQtys.Checked Then
            '取借方科目编码名称，取贷方科目编码名称
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT rc_para.parastrvalue,gl_kmxx.kmmc FROM rc_para,gl_kmxx WHERE rc_para.parastrvalue = gl_kmxx.kmdm AND rc_para.dwdm = ? AND rc_para.paraid = '总账应收账款科目编码' ORDER BY paraid"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_para") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_para").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
                If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                    If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                        strJfKmdm = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                        strJfKmmc = rcDataset.Tables("rc_para").Rows(0).Item("kmmc")
                    End If
                Else
                    MsgBox("请定义总账应收账款科目编码参数。")
                    Return
                End If
                rcOleDbCommand.CommandText = "SELECT rc_para.parastrvalue,gl_kmxx.kmmc FROM rc_para,gl_kmxx WHERE rc_para.parastrvalue = gl_kmxx.kmdm AND rc_para.dwdm = ? AND rc_para.paraid = '总账主营业务收入科目编码' ORDER BY paraid"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_para") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_para").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
                If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                    If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                        strDfKmdm = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                        strDfKmmc = rcDataset.Tables("rc_para").Rows(0).Item("kmmc")
                    End If
                Else
                    MsgBox("请定义总账主营业务收入科目编码参数。")
                    Return
                End If
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message)
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            '存储凭证
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                For i = 0 To rcDataset.Tables("rc_pz").Rows.Count - 1
                    If rcDataset.Tables("rc_pz").Rows(i).Item("xz") And rcDataset.Tables("rc_pz").Rows(i).Item("je") <> 0 Then
                        rcOleDbCommand.CommandType = CommandType.StoredProcedure
                        rcOleDbCommand.CommandText = "USP_SAVE_GL_PZ"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = strPzlxdm & Me.NudYear.Value & Me.NudMonth.Value.ToString.PadLeft(2, "0") & "00001"
                        rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                        rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                        rcOleDbCommand.Parameters.Add("@paraDatePzrq", OleDbType.Date, 8).Value = rcDataset.Tables("rc_pz").Rows(i).Item("pzrq")
                        rcOleDbCommand.Parameters.Add("@paraIntFjzs", OleDbType.Integer, 4).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraStrJd", OleDbType.Char, 2).Value = "借"
                        rcOleDbCommand.Parameters.Add("@paraStrZy", OleDbType.VarChar, 50).Value = "其他应收单" & rcDataset.Tables("rc_pz").Rows(i).Item("djh")
                        rcOleDbCommand.Parameters.Add("@paraStrKmdm", OleDbType.VarChar, 15).Value = strJfKmdm
                        rcOleDbCommand.Parameters.Add("@paraStrKmmc", OleDbType.VarChar, 50).Value = strJfKmmc
                        rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrXmdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrXmmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrKhmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrJxzh", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrDfkm", OleDbType.VarChar, 30).Value = strDfKmdm
                        rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraStrBz", OleDbType.VarChar, 8).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDblWb", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblHl", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_pz").Rows(i).Item("je")
                        rcOleDbCommand.Parameters.Add("@paraStrYspz", OleDbType.VarChar, 16).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrJsr", OleDbType.VarChar, 30).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDateWldqr", OleDbType.Date, 8).Value = Nothing
                        rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                        rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                        rcOleDbCommand.ExecuteNonQuery()
                        If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                            If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                                MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                                Return
                            End If
                        End If
                        If rcOleDbCommand.Parameters("@paraStrDjh").Value.GetType.ToString <> "System.DBNull" Then
                            If rcOleDbCommand.Parameters("@paraStrDjh").Value <> "" Then
                                strDjh = rcOleDbCommand.Parameters("@paraStrDjh").Value
                            End If
                        End If
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = strDjh
                        rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                        rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = 2
                        rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                        rcOleDbCommand.Parameters.Add("@paraDatePzrq", OleDbType.Date, 8).Value = rcDataset.Tables("rc_pz").Rows(i).Item("pzrq")
                        rcOleDbCommand.Parameters.Add("@paraIntFjzs", OleDbType.Integer, 4).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraStrJd", OleDbType.Char, 2).Value = "贷"
                        rcOleDbCommand.Parameters.Add("@paraStrZy", OleDbType.VarChar, 50).Value = "其他应收单" & rcDataset.Tables("rc_pz").Rows(i).Item("djh")
                        rcOleDbCommand.Parameters.Add("@paraStrKmdm", OleDbType.VarChar, 15).Value = strDfKmdm
                        rcOleDbCommand.Parameters.Add("@paraStrKmmc", OleDbType.VarChar, 50).Value = strDfKmmc
                        rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrXmdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrXmmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrKhmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrJxzh", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrDfkm", OleDbType.VarChar, 30).Value = strJfKmdm
                        rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraStrBz", OleDbType.VarChar, 8).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDblWb", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblHl", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_pz").Rows(i).Item("je")
                        rcOleDbCommand.Parameters.Add("@paraStrYspz", OleDbType.VarChar, 16).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrJsr", OleDbType.VarChar, 30).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDateWldqr", OleDbType.Date, 8).Value = Nothing
                        rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                        rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                        rcOleDbCommand.ExecuteNonQuery()
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "UPDATE oe_xsd SET bpz = 1 WHERE djh = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_pz").Rows(i).Item("djh")
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                Next
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("程序错误1。USP_SAVE_GL_PZ" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            MsgBox("其他应收单本月凭证已经生成完成。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
        End If
        '6其他应付单
        If Me.RadioBtnPoQtyf.Checked Then
            '取借方科目编码名称，取贷方科目编码名称
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT rc_para.parastrvalue,gl_kmxx.kmmc FROM rc_para,gl_kmxx WHERE rc_para.parastrvalue = gl_kmxx.kmdm AND rc_para.dwdm = ? AND rc_para.paraid = '总账原材料科目编码' ORDER BY paraid"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_para") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_para").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
                If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                    If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                        strJfKmdm = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                        strJfKmmc = rcDataset.Tables("rc_para").Rows(0).Item("kmmc")
                    End If
                Else
                    MsgBox("请定义总账原材料科目编码参数。")
                    Return
                End If
                rcOleDbCommand.CommandText = "SELECT rc_para.parastrvalue,gl_kmxx.kmmc FROM rc_para,gl_kmxx WHERE rc_para.parastrvalue = gl_kmxx.kmdm AND rc_para.dwdm = ? AND rc_para.paraid = '总账应付账款科目编码' ORDER BY paraid"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_para") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_para").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
                If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                    If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                        strDfKmdm = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                        strDfKmmc = rcDataset.Tables("rc_para").Rows(0).Item("kmmc")
                    End If
                Else
                    MsgBox("请定义总账应付账款科目编码参数。")
                    Return
                End If
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message)
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            '存储凭证
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                For i = 0 To rcDataset.Tables("rc_pz").Rows.Count - 1
                    If rcDataset.Tables("rc_pz").Rows(i).Item("xz") And rcDataset.Tables("rc_pz").Rows(i).Item("je") <> 0 Then
                        rcOleDbCommand.CommandType = CommandType.StoredProcedure
                        rcOleDbCommand.CommandText = "USP_SAVE_GL_PZ"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = strPzlxdm & Me.NudYear.Value & Me.NudMonth.Value.ToString.PadLeft(2, "0") & "00001"
                        rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                        rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                        rcOleDbCommand.Parameters.Add("@paraDatePzrq", OleDbType.Date, 8).Value = rcDataset.Tables("rc_pz").Rows(i).Item("pzrq")
                        rcOleDbCommand.Parameters.Add("@paraIntFjzs", OleDbType.Integer, 4).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraStrJd", OleDbType.Char, 2).Value = "借"
                        rcOleDbCommand.Parameters.Add("@paraStrZy", OleDbType.VarChar, 50).Value = "其他应付单" & rcDataset.Tables("rc_pz").Rows(i).Item("djh")
                        rcOleDbCommand.Parameters.Add("@paraStrKmdm", OleDbType.VarChar, 15).Value = strJfKmdm
                        rcOleDbCommand.Parameters.Add("@paraStrKmmc", OleDbType.VarChar, 50).Value = strJfKmmc
                        rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrXmdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrXmmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrKhmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrJxzh", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrDfkm", OleDbType.VarChar, 30).Value = strDfKmdm
                        rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraStrBz", OleDbType.VarChar, 8).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDblWb", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblHl", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_pz").Rows(i).Item("je")
                        rcOleDbCommand.Parameters.Add("@paraStrYspz", OleDbType.VarChar, 16).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrJsr", OleDbType.VarChar, 30).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDateWldqr", OleDbType.Date, 8).Value = Nothing
                        rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                        rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                        rcOleDbCommand.ExecuteNonQuery()
                        If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                            If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                                MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                                Return
                            End If
                        End If
                        If rcOleDbCommand.Parameters("@paraStrDjh").Value.GetType.ToString <> "System.DBNull" Then
                            If rcOleDbCommand.Parameters("@paraStrDjh").Value <> "" Then
                                strDjh = rcOleDbCommand.Parameters("@paraStrDjh").Value
                            End If
                        End If
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = strDjh
                        rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                        rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = 2
                        rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                        rcOleDbCommand.Parameters.Add("@paraDatePzrq", OleDbType.Date, 8).Value = rcDataset.Tables("rc_pz").Rows(i).Item("pzrq")
                        rcOleDbCommand.Parameters.Add("@paraIntFjzs", OleDbType.Integer, 4).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraStrJd", OleDbType.Char, 2).Value = "贷"
                        rcOleDbCommand.Parameters.Add("@paraStrZy", OleDbType.VarChar, 50).Value = "其他应付单" & rcDataset.Tables("rc_pz").Rows(i).Item("djh")
                        rcOleDbCommand.Parameters.Add("@paraStrKmdm", OleDbType.VarChar, 15).Value = strDfKmdm
                        rcOleDbCommand.Parameters.Add("@paraStrKmmc", OleDbType.VarChar, 50).Value = strDfKmmc
                        rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrXmdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrXmmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrKhmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrJxzh", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrDfkm", OleDbType.VarChar, 30).Value = strJfKmdm
                        rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraStrBz", OleDbType.VarChar, 8).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDblWb", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblHl", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_pz").Rows(i).Item("je")
                        rcOleDbCommand.Parameters.Add("@paraStrYspz", OleDbType.VarChar, 16).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrJsr", OleDbType.VarChar, 30).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDateWldqr", OleDbType.Date, 8).Value = Nothing
                        rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                        rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                        rcOleDbCommand.ExecuteNonQuery()
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "UPDATE po_rkd SET bpz = 1 WHERE djh = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_pz").Rows(i).Item("djh")
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                Next
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("程序错误1。USP_SAVE_GL_PZ" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            MsgBox("其他应付单本月凭证已经生成完成。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
        End If
        '7收款单
        If Me.RadioBtnArSkd.Checked Then
            '取借方科目编码名称，取贷方科目编码名称
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT rc_para.parastrvalue,gl_kmxx.kmmc FROM rc_para,gl_kmxx WHERE rc_para.parastrvalue = gl_kmxx.kmdm AND rc_para.dwdm = ? AND rc_para.paraid = '总账应收账款科目编码' ORDER BY paraid"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_para") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_para").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
                If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                    If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                        strDfKmdm = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                        strDfKmmc = rcDataset.Tables("rc_para").Rows(0).Item("kmmc")
                    End If
                Else
                    MsgBox("请定义总账应收账款科目编码参数。")
                    Return
                End If
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message)
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            '存储凭证
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                For i = 0 To rcDataset.Tables("rc_pz").Rows.Count - 1
                    If rcDataset.Tables("rc_pz").Rows(i).Item("xz") And rcDataset.Tables("rc_pz").Rows(i).Item("je") <> 0 Then
                        rcOleDbCommand.CommandType = CommandType.StoredProcedure
                        rcOleDbCommand.CommandText = "USP_SAVE_GL_PZ"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = strPzlxdm & Me.NudYear.Value & Me.NudMonth.Value.ToString.PadLeft(2, "0") & "00001"
                        rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                        rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                        rcOleDbCommand.Parameters.Add("@paraDatePzrq", OleDbType.Date, 8).Value = rcDataset.Tables("rc_pz").Rows(i).Item("pzrq")
                        rcOleDbCommand.Parameters.Add("@paraIntFjzs", OleDbType.Integer, 4).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraStrJd", OleDbType.Char, 2).Value = "借"
                        rcOleDbCommand.Parameters.Add("@paraStrZy", OleDbType.VarChar, 50).Value = "收款单" & rcDataset.Tables("rc_pz").Rows(i).Item("djh")
                        rcOleDbCommand.Parameters.Add("@paraStrKmdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_pz").Rows(i).Item("kmdm")
                        rcOleDbCommand.Parameters.Add("@paraStrKmmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("rc_pz").Rows(i).Item("kmmc")
                        rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrXmdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrXmmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrKhmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrJxzh", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrDfkm", OleDbType.VarChar, 30).Value = strDfKmdm
                        rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraStrBz", OleDbType.VarChar, 8).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDblWb", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblHl", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_pz").Rows(i).Item("je")
                        rcOleDbCommand.Parameters.Add("@paraStrYspz", OleDbType.VarChar, 16).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrJsr", OleDbType.VarChar, 30).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDateWldqr", OleDbType.Date, 8).Value = Nothing
                        rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                        rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                        rcOleDbCommand.ExecuteNonQuery()
                        If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                            If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                                MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                                Return
                            End If
                        End If
                        If rcOleDbCommand.Parameters("@paraStrDjh").Value.GetType.ToString <> "System.DBNull" Then
                            If rcOleDbCommand.Parameters("@paraStrDjh").Value <> "" Then
                                strDjh = rcOleDbCommand.Parameters("@paraStrDjh").Value
                            End If
                        End If
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = strDjh
                        rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                        rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = 2
                        rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                        rcOleDbCommand.Parameters.Add("@paraDatePzrq", OleDbType.Date, 8).Value = rcDataset.Tables("rc_pz").Rows(i).Item("pzrq")
                        rcOleDbCommand.Parameters.Add("@paraIntFjzs", OleDbType.Integer, 4).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraStrJd", OleDbType.Char, 2).Value = "贷"
                        rcOleDbCommand.Parameters.Add("@paraStrZy", OleDbType.VarChar, 50).Value = "收款单" & rcDataset.Tables("rc_pz").Rows(i).Item("djh")
                        rcOleDbCommand.Parameters.Add("@paraStrKmdm", OleDbType.VarChar, 15).Value = strDfKmdm
                        rcOleDbCommand.Parameters.Add("@paraStrKmmc", OleDbType.VarChar, 50).Value = strDfKmmc
                        rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrXmdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrXmmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrKhmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrJxzh", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrDfkm", OleDbType.VarChar, 30).Value = rcDataset.Tables("rc_pz").Rows(i).Item("kmdm")
                        rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraStrBz", OleDbType.VarChar, 8).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDblWb", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblHl", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_pz").Rows(i).Item("je")
                        rcOleDbCommand.Parameters.Add("@paraStrYspz", OleDbType.VarChar, 16).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrJsr", OleDbType.VarChar, 30).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDateWldqr", OleDbType.Date, 8).Value = Nothing
                        rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                        rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                        rcOleDbCommand.ExecuteNonQuery()
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "UPDATE ar_skd SET bpz = 1 WHERE djh = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_pz").Rows(i).Item("djh")
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                Next
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("程序错误1。USP_SAVE_GL_PZ" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            MsgBox("收款单本月凭证已经生成完成。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
        End If
        '8付款单
        If Me.RadioBtnApFkd.Checked Then
            '取借方科目编码名称，取贷方科目编码名称
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT rc_para.parastrvalue,gl_kmxx.kmmc FROM rc_para,gl_kmxx WHERE rc_para.parastrvalue = gl_kmxx.kmdm AND rc_para.dwdm = ? AND rc_para.paraid = '总账应付账款科目编码' ORDER BY paraid"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_para") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_para").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
                If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                    If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                        strJfKmdm = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                        strJfKmmc = rcDataset.Tables("rc_para").Rows(0).Item("kmmc")
                    End If
                Else
                    MsgBox("请定义总账应付账款科目编码参数。")
                    Return
                End If
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message)
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            '存储凭证
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                For i = 0 To rcDataset.Tables("rc_pz").Rows.Count - 1
                    If rcDataset.Tables("rc_pz").Rows(i).Item("xz") And rcDataset.Tables("rc_pz").Rows(i).Item("je") <> 0 Then
                        rcOleDbCommand.CommandType = CommandType.StoredProcedure
                        rcOleDbCommand.CommandText = "USP_SAVE_GL_PZ"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = strPzlxdm & Me.NudYear.Value & Me.NudMonth.Value.ToString.PadLeft(2, "0") & "00001"
                        rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                        rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                        rcOleDbCommand.Parameters.Add("@paraDatePzrq", OleDbType.Date, 8).Value = rcDataset.Tables("rc_pz").Rows(i).Item("pzrq")
                        rcOleDbCommand.Parameters.Add("@paraIntFjzs", OleDbType.Integer, 4).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraStrJd", OleDbType.Char, 2).Value = "借"
                        rcOleDbCommand.Parameters.Add("@paraStrZy", OleDbType.VarChar, 50).Value = "付款单" & rcDataset.Tables("rc_pz").Rows(i).Item("djh")
                        rcOleDbCommand.Parameters.Add("@paraStrKmdm", OleDbType.VarChar, 15).Value = strJfKmdm
                        rcOleDbCommand.Parameters.Add("@paraStrKmmc", OleDbType.VarChar, 50).Value = strJfKmmc
                        rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrXmdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrXmmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrKhmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrJxzh", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrDfkm", OleDbType.VarChar, 30).Value = rcDataset.Tables("rc_pz").Rows(i).Item("kmdm")
                        rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraStrBz", OleDbType.VarChar, 8).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDblWb", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblHl", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_pz").Rows(i).Item("je")
                        rcOleDbCommand.Parameters.Add("@paraStrYspz", OleDbType.VarChar, 16).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrJsr", OleDbType.VarChar, 30).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDateWldqr", OleDbType.Date, 8).Value = Nothing
                        rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                        rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                        rcOleDbCommand.ExecuteNonQuery()
                        If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                            If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                                MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                                Return
                            End If
                        End If
                        If rcOleDbCommand.Parameters("@paraStrDjh").Value.GetType.ToString <> "System.DBNull" Then
                            If rcOleDbCommand.Parameters("@paraStrDjh").Value <> "" Then
                                strDjh = rcOleDbCommand.Parameters("@paraStrDjh").Value
                            End If
                        End If
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = strDjh
                        rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                        rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = 2
                        rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                        rcOleDbCommand.Parameters.Add("@paraDatePzrq", OleDbType.Date, 8).Value = rcDataset.Tables("rc_pz").Rows(i).Item("pzrq")
                        rcOleDbCommand.Parameters.Add("@paraIntFjzs", OleDbType.Integer, 4).Value = 1
                        rcOleDbCommand.Parameters.Add("@paraStrJd", OleDbType.Char, 2).Value = "贷"
                        rcOleDbCommand.Parameters.Add("@paraStrZy", OleDbType.VarChar, 50).Value = "付款单" & rcDataset.Tables("rc_pz").Rows(i).Item("djh")
                        rcOleDbCommand.Parameters.Add("@paraStrKmdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_pz").Rows(i).Item("kmdm")
                        rcOleDbCommand.Parameters.Add("@paraStrKmmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("rc_pz").Rows(i).Item("kmmc")
                        rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrXmdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrXmmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrKhmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrJxzh", OleDbType.VarChar, 12).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrDfkm", OleDbType.VarChar, 30).Value = strJfKmdm
                        rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraStrBz", OleDbType.VarChar, 8).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDblWb", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblHl", OleDbType.Numeric, 18).Value = 0.0
                        rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_pz").Rows(i).Item("je")
                        rcOleDbCommand.Parameters.Add("@paraStrYspz", OleDbType.VarChar, 16).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraStrJsr", OleDbType.VarChar, 30).Value = ""
                        rcOleDbCommand.Parameters.Add("@paraDateWldqr", OleDbType.Date, 8).Value = Nothing
                        rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                        rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                        rcOleDbCommand.ExecuteNonQuery()
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "UPDATE ap_fkd SET bpz = 1 WHERE djh = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_pz").Rows(i).Item("djh")
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                Next
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("程序错误1。USP_SAVE_GL_PZ" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            MsgBox("付款单本月凭证已经生成完成。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
        End If
        '清除数据
        If rcDataset.Tables("rc_pz") IsNot Nothing Then
            rcDataset.Tables("rc_pz").Clear()
        End If
    End Sub

#Region "退出表单事件"

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

#End Region

End Class