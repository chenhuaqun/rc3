Imports System.Data.OleDb

Public Class FrmCsYfzkMx
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable
    ReadOnly dtCsYfzkMx As New DataTable("csyfzkmx")

    Private Sub FrmCsYfzkMx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        NudYear.Value = Mid(g_Kjqj, 1, 4)
        NudMonthBegin.Value = 1
        NudMonthEnd.Value = Mid(g_Kjqj, 5, 2)
        '创建datatable
        dtCsYfzkMx.Columns.Add("rq", Type.GetType("System.DateTime"))
        dtCsYfzkMx.Columns.Add("djh", Type.GetType("System.String"))
        dtCsYfzkMx.Columns.Add("zy", Type.GetType("System.String"))
        dtCsYfzkMx.Columns.Add("yfje", Type.GetType("System.Double"))
        dtCsYfzkMx.Columns.Add("fkje", Type.GetType("System.Double"))
        dtCsYfzkMx.Columns.Add("ye", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtCsYfzkMx)
        With rcDataset.Tables("csyfzkmx")
            .Columns("djh").DefaultValue = ""
            .Columns("zy").DefaultValue = ""
            .Columns("yfje").DefaultValue = 0.0
            .Columns("fkje").DefaultValue = 0.0
            .Columns("ye").DefaultValue = 0.0
        End With
    End Sub


#Region "供应商编码事件"

    Private Sub TxtCsdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCsdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_csxx"
                    .paraField1 = "csdm"
                    .paraField2 = "csmc"
                    .paraField3 = "cssm"
                    .paraCondition = "0=0"
                    .paraOrderField = "csmc"
                    .paraTitle = "供应商"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtCsdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub


    Private Sub TxtCsdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCsdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtCsdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_csxx WHERE (csdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(TxtCsdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_csxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_csxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_csxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_csxx").Rows.Count > 0 Then
                Me.TxtCsdm.Text = Trim(rcDataset.Tables("rc_csxx").Rows(0).Item("csdm"))
                'LblCsmc.Text = Trim(rcDataset.Tables("rc_csxx").Rows(0).Item("csmc"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If String.IsNullOrEmpty(Me.TxtCsdm.Text) Then
            Return
        End If
        '清空数据
        rcDataset.Tables("csyfzkmx").Clear()
        'Dim i As Integer
        Dim j As Integer
        Dim rqBegin As Date
        Dim rqEnd As Date
        Dim dblQcje As Double
        Dim dblYe As Double = 0.0
        '取期初数
        rqBegin = getInvBegin(Me.NudYear.Value, 1)
        rqEnd = getInvBegin(Me.NudYear.Value, Me.NudMonthBegin.Value)
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT COALESCE(Sum(yfje),0.0) As yfje,COALESCE(Sum(fkje),0.0) As fkje FROM((SELECT po_fp.je + po_fp.se As yfje,0.0 As fkje FROM po_fp WHERE csdm = ? AND po_fp.bdelete = 0 and TRUNC(po_fp.fprq,'dd') >= ? and TRUNC(po_fp.fprq,'dd') >= ? and TRUNC(po_fp.fprq,'dd') < ?) UNION ALL (SELECT 0.0 As yfje,ap_fkd.je As fkje FROM ap_fkd WHERE csdm = ? and ap_fkd.fkrq >= ? and ap_fkd.fkrq >= ? and ap_fkd.fkrq < ?)) tmpmxz "
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 15).Value = Trim(TxtCsdm.Text)
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 15).Value = Trim(TxtCsdm.Text)
            rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("qcrkck") IsNot Nothing Then
                rcDataset.Tables("qcrkck").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "qcrkck")
        Catch ex As Exception
            MsgBox("程序错误2。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("qcrkck").Rows(0).Item("yfje").GetType.ToString = "System.DBNull" Then
            rcDataset.Tables("qcrkck").Rows(0).Item("yfje") = 0.0
        End If
        If rcDataset.Tables("qcrkck").Rows(0).Item("fkje").GetType.ToString = "System.DBNull" Then
            rcDataset.Tables("qcrkck").Rows(0).Item("fkje") = 0.0
        End If
        rqBegin = getInvBegin(NudYear.Value, NudMonthBegin.Value)
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT '" & rqBegin.ToString & "' As rq,'期初结存' As zy ,(COALESCE(sum(qcfpje),0.0)+" & rcDataset.Tables("qcrkck").Rows(0).Item("yfje") & "-" & rcDataset.Tables("qcrkck").Rows(0).Item("fkje") & ") As ye FROM ap_csyeb WHERE kjnd = ? AND csdm = ? "
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
            rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 15).Value = Trim(TxtCsdm.Text)
            If rcDataset.Tables("csyfzkmx") IsNot Nothing Then
                rcDataset.Tables("csyfzkmx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "csyfzkmx")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If dtCsYfzkMx.Rows(dtCsYfzkMx.Rows.Count - 1).Item("ye").GetType.ToString <> "System.DBNull" Then
            dblQcje = dtCsYfzkMx.Rows(dtCsYfzkMx.Rows.Count - 1).Item("ye")
        End If
        dblYe = dblQcje
        rqBegin = getInvBegin(NudYear.Value, NudMonthBegin.Value)
        rqEnd = getInvEnd(NudYear.Value, NudMonthEnd.Value)
        '读取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            'REPLACE(CONCAT(CONCAT(CONCAT(po_fpnr.rkmemo,'供应商:('), CONCAT(po_fpml.csdm,')')), po_fpml.csmc),' ','')
            rcOleDbCommand.CommandText = "(SELECT TRUNC(po_fp.fprq,'dd') As rq,po_fp.djh,po_fp.fpmemo || po_fp.cpdm || po_fp.cpmc || po_fp.dw || '第' || po_fp.xh || '行' As zy,(po_fp.je + po_fp.se) As yfje,0.0 As fkje FROM po_fp WHERE csdm = ? AND po_fp.bdelete = 0 and TRUNC(po_fp.fprq,'dd') >= ? and TRUNC(po_fp.fprq,'dd') >= ? and TRUNC(po_fp.fprq,'dd') <= ?) UNION ALL (SELECT ap_fkd.fkrq As rq,ap_fkd.djh,ap_fkd.fkmemo As zy,0.0 As yfje,ap_fkd.je As fkje FROM ap_fkd WHERE csdm = ? and ap_fkd.fkrq >= ? and ap_fkd.fkrq >= ? and ap_fkd.fkrq <= ?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 15).Value = Trim(TxtCsdm.Text)
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 15).Value = Trim(TxtCsdm.Text)
            rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            rcOleDbDataAdpt.Fill(rcDataset, "csyfzkmx")
        Catch ex As Exception
            MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try

        '本月合计
        For j = Me.NudMonthBegin.Value To Me.NudMonthEnd.Value
            rqBegin = getInvBegin(Me.NudYear.Value, j)
            rqEnd = getInvEnd(Me.NudYear.Value, j)
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT '" & rqEnd.ToString & "' As rq,'本月合计' As zy ,Coalesce(Sum(yfje),0.0) As yfje,Coalesce(Sum(fkje),0.0) As fkje," & dblYe & " + Sum(yfje) - Sum(fkje) As ye FROM ((SELECT Sum(po_fp.je + po_fp.se) As yfje,0.0 As fkje FROM po_fp WHERE po_fp.csdm = ? AND po_fp.bdelete = 0 AND TRUNC(po_fp.fprq,'dd') >= ? AND TRUNC(po_fp.fprq,'dd') >= ? AND TRUNC(po_fp.fprq,'dd') <= ?) UNION ALL (SELECT 0.0 As yfje,Sum(ap_fkd.je) As fkje FROM ap_fkd WHERE csdm = ? AND ap_fkd.fkrq >= ? AND ap_fkd.fkrq >= ? AND ap_fkd.fkrq <= ?)) tmpmxz "
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 15).Value = Trim(TxtCsdm.Text)
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 15).Value = Trim(TxtCsdm.Text)
                rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                rcOleDbDataAdpt.Fill(rcDataset, "csyfzkmx")
                If dtCsYfzkMx.Rows(dtCsYfzkMx.Rows.Count - 1).Item("ye").GetType.ToString <> "System.DBNull" Then
                    dblYe = dtCsYfzkMx.Rows(dtCsYfzkMx.Rows.Count - 1).Item("ye")
                Else
                    dtCsYfzkMx.Rows(dtCsYfzkMx.Rows.Count - 1).Item("ye") = dblYe
                End If
                'MsgBox(dblYe)
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        Next
        '本年累计
        rqBegin = getInvBegin(NudYear.Value, NudMonthBegin.Value)
        For j = Me.NudMonthBegin.Value To Me.NudMonthEnd.Value
            rqEnd = getInvEnd(Me.NudYear.Value, j)
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT '" & rqEnd.ToString & "' As rq,'本年累计' As zy ,Coalesce(Sum(yfje),0.0) As yfje,Coalesce(Sum(fkje),0.0) As fkje,0.0 As ye FROM ((SELECT Sum(po_fp.je + po_fp.se) As yfje,0.0 As fkje FROM po_fp WHERE csdm = ? AND TRUNC(po_fp.fprq,'dd') >= ? AND TRUNC(po_fp.fprq,'dd') >= ? AND TRUNC(po_fp.fprq,'dd') <= ?) UNION ALL (SELECT 0.0 As yfje,Sum(ap_fkd.je) As fkje FROM ap_fkd WHERE csdm = ? AND ap_fkd.fkrq >= ? AND ap_fkd.fkrq >= ? AND ap_fkd.fkrq <= ?)) tmpmxz "
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 15).Value = Trim(TxtCsdm.Text)
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 15).Value = Trim(TxtCsdm.Text)
                rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                rcOleDbDataAdpt.Fill(rcDataset, "csyfzkmx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        Next

        If rcDataset.Tables("csyfzkmx").Rows.Count <= 0 Then
            MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        '调用表单
        Dim rcFrm As New FrmCsYfzkMxz
        With rcFrm
            .ParaDataSet = rcDataset
            .paraDataView = New DataView(rcDataset.Tables("csyfzkmx"), "TRUE", "rq", DataViewRowState.CurrentRows)
            '.paraDataTable = rcDataset.Tables("csyfzkmx")
            .Label2.Text = NudYear.Value & "年" & NudMonthBegin.Value & "月至" & NudMonthEnd.Value & "月"
            '.Label3.Text = "产品：" & Trim(TxtCpdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class