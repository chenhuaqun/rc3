Imports System.Data.OleDb

Public Class FrmCsYfzkHz
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable
    ReadOnly dtCsYfzkHz As New DataTable("csyfzkhz")

    Private Sub FrmCsYfzkHz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        DtpHzrqBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpHzrqEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '创建datatable
        dtCsYfzkHz.Columns.Add("csdm", Type.GetType("System.String"))
        dtCsYfzkHz.Columns.Add("csmc", Type.GetType("System.String"))
        dtCsYfzkHz.Columns.Add("zydm", Type.GetType("System.String"))
        dtCsYfzkHz.Columns.Add("zymc", Type.GetType("System.String"))
        dtCsYfzkHz.Columns.Add("fktj", Type.GetType("System.String"))
        dtCsYfzkHz.Columns.Add("fkts", Type.GetType("System.Int32"))
        dtCsYfzkHz.Columns.Add("qcje", Type.GetType("System.Double"))
        dtCsYfzkHz.Columns.Add("yfje", Type.GetType("System.Double"))
        dtCsYfzkHz.Columns.Add("fkje", Type.GetType("System.Double"))
        dtCsYfzkHz.Columns.Add("qmje", Type.GetType("System.Double"))
        dtCsYfzkHz.Columns.Add("wkpje", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtCsYfzkHz)
        With dtCsYfzkHz
            .Columns("csdm").DefaultValue = ""
            .Columns("csmc").DefaultValue = ""
            .Columns("zydm").DefaultValue = ""
            .Columns("zymc").DefaultValue = ""
            .Columns("fktj").DefaultValue = ""
            .Columns("fkts").DefaultValue = 0
            .Columns("qcje").DefaultValue = 0.0
            .Columns("yfje").DefaultValue = 0.0
            .Columns("fkje").DefaultValue = 0.0
            .Columns("qmje").DefaultValue = 0.0
            .Columns("wkpje").DefaultValue = 0.0
        End With
    End Sub

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
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT zydm,zymc FROM rc_zyxx WHERE (zydm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(TxtZydm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_zyxx") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_zyxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_zyxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_zyxx").Rows.Count > 0 Then
                Me.TxtZydm.Text = Trim(rcDataSet.Tables("rc_zyxx").Rows(0).Item("zydm"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

    Private Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Me.CheckBox1.Checked Then
            Me.CheckBox2.Checked = False
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If Me.CheckBox2.Checked Then
            Me.CheckBox1.Checked = False
        End If
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim strKjqj As String = getInvKjqj(DtpHzrqBegin.Value)
        Dim dInvBegin1 As Date = getInvBegin(Mid(strKjqj, 1, 4), 1)
        Dim i As Integer = 1
        'If String.IsNullOrEmpty(Me.TxtCkdm.Text) Then
        '    Return
        'End If
        dtCsYfzkHz.Clear()

        '取数据
        '取期初库存、期初入库、期初出库、本期入库、本期出库
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT bsfchz.csdm,bsfchz.csmc,bsfchz.zydm,bsfchz.zymc,bsfchz.fktj,bsfchz.fkts,COALESCE(bsfchz.qcje,0.0)+COALESCE(bsfchz.qcyfje,0.0)-COALESCE(bsfchz.qcfkje,0.0) as qcje,COALESCE(bsfchz.bqyfje,0.0) AS yfje,COALESCE(bsfchz.bqfkje,0.0) AS fkje,COALESCE(bsfchz.qcje,0.0)+COALESCE(bsfchz.qcyfje,0.0)-COALESCE(bsfchz.qcfkje,0.0)+ COALESCE(bsfchz.bqyfje,0.0) - COALESCE(bsfchz.bqfkje,0.0) AS qmje,COALESCE(bsfchz.wkpje,0.0) AS wkpje FROM (SELECT asfchz.*,rc_csxx.csmc,rc_csxx.zydm,rc_csxx.zymc,rc_csxx.fktj,rc_csxx.fkts,rc_csxx.lbdm FROM (SELECT khnc.csdm,khnc.qcje,qcxs.qcyfje,qcsk.qcfkje,bqrk.bqyfje,bqck.bqfkje,wkprk.wkpje FROM" & _
                " (SELECT ap_csyeb.csdm,sum(qcfpje) as qcje FROM ap_csyeb WHERE kjnd = ? GROUP BY ap_csyeb.csdm) khnc" & _
                " Left join (SELECT po_fp.csdm,sum(po_fp.je + po_fp.se) as qcyfje FROM po_fp WHERE TRUNC(po_fp.fprq,'dd') >= ? AND TRUNC(po_fp.fprq,'dd') >= ? AND po_fp.bdelete = 0 and TRUNC(po_fp.fprq,'dd') < ? GROUP BY po_fp.csdm) qcxs ON khnc.csdm = qcxs.csdm" & _
                " Left join (SELECT ap_fkd.csdm,sum(ap_fkd.je) as qcfkje FROM ap_fkd WHERE ap_fkd.fkrq >= ? and ap_fkd.fkrq >= ? and ap_fkd.fkrq < ? GROUP BY ap_fkd.csdm) qcsk ON khnc.csdm = qcsk.csdm" & _
                " Left join (SELECT po_fp.csdm,sum(po_fp.je + po_fp.se) as bqyfje FROM po_fp WHERE TRUNC(po_fp.fprq,'dd') >= ? and TRUNC(po_fp.fprq,'dd') >= ? and TRUNC(po_fp.fprq,'dd') <= ? AND po_fp.bdelete = 0 GROUP BY po_fp.csdm) bqrk ON khnc.csdm = bqrk.csdm" & _
                " Left join (SELECT ap_fkd.csdm,sum(ap_fkd.je) as bqfkje FROM ap_fkd WHERE ap_fkd.fkrq >= ? and ap_fkd.fkrq >= ? and ap_fkd.fkrq <= ? GROUP BY ap_fkd.csdm) bqck ON khnc.csdm = bqck.csdm" & _
                " LEFT JOIN (SELECT po_rkd.csdm,SUM(po_rkd.je + po_rkd.se - po_rkd.fpje) AS wkpje FROM po_rkd WHERE po_rkd.sl <> po_rkd.fpsl AND po_rkd.bdelete = 0 GROUP BY po_rkd.csdm) wkprk ON khnc.csdm = wkprk.csdm) asfchz LEFT JOIN rc_csxx ON asfchz.csdm = rc_csxx.csdm) bsfchz" & IIf(Not String.IsNullOrEmpty(Me.TxtZydm.Text), " WHERE bsfchz.zydm = '" & Trim(TxtZydm.Text) & "'", "")
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(strKjqj, 1, 4)
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dInvBegin1.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = dInvBegin1.Date
            rcOleDbCommand.Parameters.Add("@fkrq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = DtpHzrqEnd.Value
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
        If Me.CheckBox1.Checked Then
            For i = 0 To rcDataset.Tables("csyfzkhz").Rows.Count - 1
                Me.ProgressBar1.Value = i
                If rcDataset.Tables("csyfzkhz").Rows(i).Item("qcje") = 0 And rcDataset.Tables("csyfzkhz").Rows(i).Item("yfje") = 0 And rcDataset.Tables("csyfzkhz").Rows(i).Item("fkje") = 0 And rcDataset.Tables("csyfzkhz").Rows(i).Item("qmje") = 0 And rcDataset.Tables("csyfzkhz").Rows(i).Item("wkpje") = 0 Then
                    rcDataset.Tables("csyfzkhz").Rows(i).Delete()
                End If
            Next
        End If
        If Me.CheckBox2.Checked Then
            For i = 0 To rcDataset.Tables("csyfzkhz").Rows.Count - 1
                Me.ProgressBar1.Value = i
                If rcDataset.Tables("csyfzkhz").Rows(i).Item("qmje") = 0 Then
                    rcDataset.Tables("csyfzkhz").Rows(i).Delete()
                End If
            Next
        End If
        Dim rcDataRow As DataRow
        rcDataRow = rcDataset.Tables("csyfzkhz").NewRow
        rcDataRow.Item("csdm") = "合计"
        rcDataRow.Item("qcje") = dtCsYfzkHz.Compute("Sum(qcje)", "")
        rcDataRow.Item("yfje") = dtCsYfzkHz.Compute("Sum(yfje)", "")
        rcDataRow.Item("fkje") = dtCsYfzkHz.Compute("Sum(fkje)", "")
        rcDataRow.Item("qmje") = dtCsYfzkHz.Compute("Sum(qmje)", "")
        rcDataRow.Item("wkpje") = dtCsYfzkHz.Compute("Sum(wkpje)", "")
        rcDataset.Tables("csyfzkhz").Rows.Add(rcDataRow)

        '调用表单
        Dim rcFrm As New FrmCsYfzkHzz
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("csyfzkhz"), "TRUE", "csdm", DataViewRowState.CurrentRows)
            .Label2.Text = DtpHzrqBegin.Value & "至" & DtpHzrqEnd.Value
            '.Label3.Text = "仓库：" & Trim(Me.TxtCkdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

End Class