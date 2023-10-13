Imports System.Data.OleDb

Public Class FrmCsLbYfzkHz
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable
    ReadOnly dtCsLbYfzkHz As New DataTable("csyfzkhz")

    Private Sub FrmCsLbYfzkHz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        DtpHzrqBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpHzrqEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '创建datatable
        dtCsLbYfzkHz.Columns.Add("lbdm", Type.GetType("System.String"))
        dtCsLbYfzkHz.Columns.Add("lbmc", Type.GetType("System.String"))
        dtCsLbYfzkHz.Columns.Add("qcje", Type.GetType("System.Double"))
        dtCsLbYfzkHz.Columns.Add("yfje", Type.GetType("System.Double"))
        dtCsLbYfzkHz.Columns.Add("fkje", Type.GetType("System.Double"))
        dtCsLbYfzkHz.Columns.Add("qmje", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtCsLbYfzkHz)
        With dtCsLbYfzkHz
            .Columns("lbdm").DefaultValue = ""
            .Columns("qcje").DefaultValue = 0.0
            .Columns("yfje").DefaultValue = 0.0
            .Columns("fkje").DefaultValue = 0.0
            .Columns("qmje").DefaultValue = 0.0
        End With
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim strKjqj As String = getInvKjqj(DtpHzrqBegin.Value)
        Dim dInvBegin1 As Date = getInvBegin(Mid(strKjqj, 1, 4), 1)
        Dim i As Integer = 1
        'If String.IsNullOrEmpty(Me.TxtCkdm.Text) Then
        '    Return
        'End If
        dtCsLbYfzkHz.Clear()

        '取数据
        '取期初库存、期初入库、期初出库、本期入库、本期出库
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT bsfchz.lbdm,bsfchz.lbmc,SUM(COALESCE(bsfchz.qcje,0.0)+COALESCE(bsfchz.qcyfje,0.0)-COALESCE(bsfchz.qcfkje,0.0)) as qcje,SUM(COALESCE(bsfchz.bqyfje,0.0)) AS yfje,SUM(COALESCE(bsfchz.bqfkje,0.0)) AS fkje,SUM(COALESCE(bsfchz.qcje,0.0)+COALESCE(bsfchz.qcyfje,0.0)-COALESCE(bsfchz.qcfkje,0.0)+ COALESCE(bsfchz.bqyfje,0.0) - COALESCE(bsfchz.bqfkje,0.0)) AS qmje FROM (SELECT asfchz.*,rc_csxx.lbmc,rc_csxx.lbdm FROM (SELECT khnc.csdm,khnc.qcje,qcxs.qcyfje,qcsk.qcfkje,bqrk.bqyfje,bqck.bqfkje FROM" & _
                " (SELECT ap_csyeb.csdm,sum(qcje) as qcje FROM ap_csyeb WHERE kjnd = ? GROUP BY ap_csyeb.csdm) khnc" & _
                " Left join (SELECT po_fp.csdm,sum(po_fp.je + po_fp.se) as qcyfje FROM po_fp WHERE po_fp.bdelete = 0 AND po_fp.fprq >= ? and po_fp.fprq >= ? and po_fp.fprq < ? GROUP BY po_fp.csdm) qcxs ON khnc.csdm = qcxs.csdm" & _
                " Left join (SELECT ap_fkd.csdm,sum(ap_fkd.je) as qcfkje FROM ap_fkd WHERE ap_fkd.fkrq >= ? and ap_fkd.fkrq >= ? and ap_fkd.fkrq < ? GROUP BY ap_fkd.csdm) qcsk ON khnc.csdm = qcsk.csdm" & _
                " Left join (SELECT po_fp.csdm,sum(po_fp.je + po_fp.se) as bqyfje FROM po_fp WHERE po_fp.bdelete = 0 AND po_fp.fprq >= ? and po_fp.fprq >= ? and po_fp.fprq <= ? GROUP BY po_fp.csdm) bqrk ON khnc.csdm = bqrk.csdm" & _
                " Left join (SELECT ap_fkd.csdm,sum(ap_fkd.je) as bqfkje FROM ap_fkd WHERE ap_fkd.fkrq >= ? and ap_fkd.fkrq >= ? and ap_fkd.fkrq <= ? GROUP BY ap_fkd.csdm) bqck ON khnc.csdm = bqck.csdm) asfchz LEFT JOIN rc_csxx ON asfchz.csdm = rc_csxx.csdm) bsfchz GROUP BY bsfchz.lbdm,bsfchz.lbmc"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(strKjqj, 1, 4)
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dInvBegin1.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = dInvBegin1.Date
            rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = DtpHzrqEnd.Value
            rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = DtpHzrqEnd.Value
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("csyfzkhz") IsNot Nothing Then
                rcDataset.Tables("csyfzkhz").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "csyfzkhz")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("csyfzkhz").Rows.Count > 0 Then
            Me.ProgressBar1.Maximum = rcDataset.Tables("csyfzkhz").Rows.Count - 1
        End If
        Dim rcDataRow As DataRow
        rcDataRow = rcDataset.Tables("csyfzkhz").NewRow
        rcDataRow.Item("lbdm") = "合计"
        rcDataRow.Item("qcje") = dtCsLbYfzkHz.Compute("Sum(qcje)", "")
        rcDataRow.Item("yfje") = dtCsLbYfzkHz.Compute("Sum(yfje)", "")
        rcDataRow.Item("fkje") = dtCsLbYfzkHz.Compute("Sum(fkje)", "")
        rcDataRow.Item("qmje") = dtCsLbYfzkHz.Compute("Sum(qmje)", "")
        rcDataset.Tables("csyfzkhz").Rows.Add(rcDataRow)

        '调用表单
        Dim rcFrm As New FrmCsLbYfzkHzz
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("csyfzkhz"), "TRUE", "lbdm", DataViewRowState.CurrentRows)
            .Label2.Text = DtpHzrqBegin.Value & "至" & DtpHzrqEnd.Value
            '.Label3.Text = "仓库：" & Trim(Me.TxtCkdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

End Class