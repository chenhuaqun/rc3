Imports System.Data.OleDb

Public Class FrmKhLbYszkHz
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable
    ReadOnly dtKhLbYszkHz As New DataTable("khyszkhz")

    Private Sub FrmKhLbYszkHz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        DtpHzrqBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpHzrqEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '创建datatable
        dtKhLbYszkHz.Columns.Add("lbdm", Type.GetType("System.String"))
        dtKhLbYszkHz.Columns.Add("lbmc", Type.GetType("System.String"))
        dtKhLbYszkHz.Columns.Add("qcje", Type.GetType("System.Double"))
        dtKhLbYszkHz.Columns.Add("ysje", Type.GetType("System.Double"))
        dtKhLbYszkHz.Columns.Add("skje", Type.GetType("System.Double"))
        dtKhLbYszkHz.Columns.Add("qmje", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtKhLbYszkHz)
        With dtKhLbYszkHz
            .Columns("lbdm").DefaultValue = ""
            .Columns("qcje").DefaultValue = 0.0
            .Columns("ysje").DefaultValue = 0.0
            .Columns("skje").DefaultValue = 0.0
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
        dtKhLbYszkHz.Clear()

        '取数据
        '取期初库存、期初入库、期初出库、本期入库、本期出库
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT bsfchz.lbdm,bsfchz.lbmc,SUM(COALESCE(bsfchz.qcje,0.0)+COALESCE(bsfchz.qcysje,0.0)-COALESCE(bsfchz.qcskje,0.0)) as qcje,SUM(COALESCE(bsfchz.bqysje,0.0)) AS ysje,SUM(COALESCE(bsfchz.bqskje,0.0)) AS skje,SUM(COALESCE(bsfchz.qcje,0.0)+COALESCE(bsfchz.qcysje,0.0)-COALESCE(bsfchz.qcskje,0.0)+ COALESCE(bsfchz.bqysje,0.0) - COALESCE(bsfchz.bqskje,0.0)) AS qmje FROM (SELECT asfchz.*,rc_khxx.lbdm,rc_khxx.lbmc FROM (SELECT khnc.khdm,khnc.qcje,qcxs.qcysje,qcsk.qcskje,bqrk.bqysje,bqck.bqskje FROM" & _
                " (SELECT ar_khyeb.khdm,sum(qcje) as qcje FROM ar_khyeb WHERE kjnd = ? GROUP BY ar_khyeb.khdm) khnc" & _
                " Left join (SELECT oe_fp.khdm,sum(oe_fp.je + oe_fp.se) as qcysje FROM oe_fp WHERE oe_fp.bdelete = 0 AND oe_fp.fprq >= ? and oe_fp.fprq >= ? and oe_fp.fprq < ? GROUP BY oe_fp.khdm) qcxs ON khnc.khdm = qcxs.khdm" & _
                " Left join (SELECT ar_skd.khdm,sum(ar_skd.je) as qcskje FROM ar_skd WHERE ar_skd.skrq >= ? and ar_skd.skrq >= ? and ar_skd.skrq < ? GROUP BY ar_skd.khdm) qcsk ON khnc.khdm = qcsk.khdm" & _
                " Left join (SELECT oe_fp.khdm,sum(oe_fp.je + oe_fp.se) as bqysje FROM oe_fp WHERE oe_fp.bdelete = 0 AND oe_fp.fprq >= ? and oe_fp.fprq >= ? and oe_fp.fprq <= ? GROUP BY oe_fp.khdm) bqrk ON khnc.khdm = bqrk.khdm" & _
                " Left join (SELECT ar_skd.khdm,sum(ar_skd.je) as bqskje FROM ar_skd WHERE ar_skd.skrq >= ? and ar_skd.skrq >= ? and ar_skd.skrq <= ? GROUP BY ar_skd.khdm) bqck ON khnc.khdm = bqck.khdm) asfchz LEFT JOIN rc_khxx ON asfchz.khdm = rc_khxx.khdm) bsfchz GROUP BY bsfchz.lbdm,bsfchz.lbmc"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(strKjqj, 1, 4)
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dInvBegin1.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = dInvBegin1.Date
            rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = DtpHzrqEnd.Value
            rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@skrq", OleDbType.Date, 8).Value = DtpHzrqEnd.Value
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("khyszkhz") IsNot Nothing Then
                rcDataset.Tables("khyszkhz").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "khyszkhz")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("khyszkhz").Rows.Count > 0 Then
            Me.ProgressBar1.Maximum = rcDataset.Tables("khyszkhz").Rows.Count - 1
        End If
        Dim rcDataRow As DataRow
        rcDataRow = rcDataset.Tables("khyszkhz").NewRow
        rcDataRow.Item("lbdm") = "合计"
        rcDataRow.Item("qcje") = dtKhLbYszkHz.Compute("Sum(qcje)", "")
        rcDataRow.Item("ysje") = dtKhLbYszkHz.Compute("Sum(ysje)", "")
        rcDataRow.Item("skje") = dtKhLbYszkHz.Compute("Sum(skje)", "")
        rcDataRow.Item("qmje") = dtKhLbYszkHz.Compute("Sum(qmje)", "")
        rcDataset.Tables("khyszkhz").Rows.Add(rcDataRow)

        '调用表单
        Dim rcFrm As New FrmKhLbYszkHzz
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("khyszkhz"), "TRUE", "lbdm", DataViewRowState.CurrentRows)
            .Label2.Text = DtpHzrqBegin.Value & "至" & DtpHzrqEnd.Value
            '.Label3.Text = "仓库：" & Trim(Me.TxtCkdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class