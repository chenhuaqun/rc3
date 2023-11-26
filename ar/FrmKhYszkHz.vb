Imports System.Data.OleDb

Public Class FrmKhYszkHz
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable
    ReadOnly dtKhYszkHz As New DataTable("khyszkhz")

    Private Sub FrmKhYszkHz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        DtpHzrqBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpHzrqEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '创建datatable
        dtKhYszkHz.Columns.Add("khdm", Type.GetType("System.String"))
        dtKhYszkHz.Columns.Add("khmc", Type.GetType("System.String"))
        dtKhYszkHz.Columns.Add("zydm", Type.GetType("System.String"))
        dtKhYszkHz.Columns.Add("zymc", Type.GetType("System.String"))
        dtKhYszkHz.Columns.Add("sktj", Type.GetType("System.String"))
        dtKhYszkHz.Columns.Add("skqx", Type.GetType("System.Int32"))
        dtKhYszkHz.Columns.Add("qcje", Type.GetType("System.Double"))
        dtKhYszkHz.Columns.Add("ysje", Type.GetType("System.Double"))
        dtKhYszkHz.Columns.Add("skje", Type.GetType("System.Double"))
        dtKhYszkHz.Columns.Add("qmje", Type.GetType("System.Double"))
        dtKhYszkHz.Columns.Add("wkpje", Type.GetType("System.Double"))
        dtKhYszkHz.Columns.Add("zs", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtKhYszkHz)
        With dtKhYszkHz
            .Columns("khdm").DefaultValue = ""
            .Columns("zydm").DefaultValue = ""
            .Columns("zymc").DefaultValue = ""
            .Columns("sktj").DefaultValue = ""
            .Columns("skqx").DefaultValue = 0
            .Columns("qcje").DefaultValue = 0.0
            .Columns("ysje").DefaultValue = 0.0
            .Columns("skje").DefaultValue = 0.0
            .Columns("qmje").DefaultValue = 0.0
            .Columns("wkpje").DefaultValue = 0.0
            .Columns("zs").DefaultValue = 0.0
        End With
    End Sub

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpHzrqBegin.KeyPress, DtpHzrqEnd.KeyPress, TxtZydm.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "业务员事件"

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
                    .paraOrderField = "zydm"
                    .paraTitle = "职员"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtZydm.Text = Trim(.paraField1)
                    End If
                End With
        End Select
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
        dtKhYszkHz.Clear()

        '取数据
        '取期初库存、期初入库、期初出库、本期入库、本期出库
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            'rcOleDbCommand.CommandText = "SELECT bsfchz.khdm,bsfchz.khmc,COALESCE(bsfchz.qcje,0.0)+COALESCE(bsfchz.qcysje,0.0)-COALESCE(bsfchz.qcskje,0.0) as qcje,COALESCE(bsfchz.bqysje,0.0) AS ysje,COALESCE(bsfchz.bqskje,0.0) AS skje,COALESCE(bsfchz.qcje,0.0)+COALESCE(bsfchz.qcysje,0.0)-COALESCE(bsfchz.qcskje,0.0)+ COALESCE(bsfchz.bqysje,0.0) - COALESCE(bsfchz.bqskje,0.0) AS qmje FROM (SELECT asfchz.*,rc_khxx.khmc,rc_khxx.lbdm FROM (SELECT khnc.khdm,khnc.qcje,qcxs.qcysje,qcsk.qcskje,bqrk.bqysje,bqck.bqskje FROM" & _
            '    " (SELECT ar_khyeb.khdm,sum(qcfpje) as qcje FROM ar_khyeb WHERE kjnd = ? GROUP BY ar_khyeb.khdm) khnc" & _
            '    " Left join (SELECT oe_fp.khdm,sum(oe_fp.je) as qcysje FROM oe_fp WHERE oe_fp.bdelete = 0 AND TRUNC(oe_fp.fprq,'dd') >= ? and TRUNC(oe_fp.fprq,'dd') >= ? and TRUNC(oe_fp.fprq,'dd') < ? GROUP BY oe_fp.khdm) qcxs ON khnc.khdm = qcxs.khdm" & _
            '    " Left join (SELECT ar_skd.khdm,sum(ar_skd.je) as qcskje FROM ar_skd WHERE ar_skd.skrq >= ? and ar_skd.skrq >= ? and ar_skd.skrq < ? GROUP BY ar_skd.khdm) qcsk ON khnc.khdm = qcsk.khdm" & _
            '    " Left join (SELECT oe_fp.khdm,sum(oe_fp.je) as bqysje FROM oe_fp WHERE oe_fp.bdelete = 0 AND TRUNC(oe_fp.fprq,'dd') >= ? and TRUNC(oe_fp.fprq,'dd') >= ? and TRUNC(oe_fp.fprq,'dd') <= ? GROUP BY oe_fp.khdm) bqrk ON khnc.khdm = bqrk.khdm" & _
            '    " Left join (SELECT ar_skd.khdm,sum(ar_skd.je) as bqskje FROM ar_skd WHERE ar_skd.skrq >= ? and ar_skd.skrq >= ? and ar_skd.skrq <= ? GROUP BY ar_skd.khdm) bqck ON khnc.khdm = bqck.khdm) asfchz LEFT JOIN rc_khxx ON asfchz.khdm = rc_khxx.khdm) bsfchz"
            rcOleDbCommand.CommandText = "SELECT bsfchz.khdm,bsfchz.khmc,bsfchz.zydm,bsfchz.zymc,bsfchz.sktj,bsfchz.skqx,COALESCE(bsfchz.qcje,0.0)+COALESCE(bsfchz.qcysje,0.0)-COALESCE(bsfchz.qcskje,0.0) as qcje,COALESCE(bsfchz.bqysje,0.0) AS ysje,COALESCE(bsfchz.bqskje,0.0) AS skje,COALESCE(bsfchz.qcje,0.0)+COALESCE(bsfchz.qcysje,0.0)-COALESCE(bsfchz.qcskje,0.0)+ COALESCE(bsfchz.bqysje,0.0) - COALESCE(bsfchz.bqskje,0.0) AS qmje,COALESCE(bsfchz.wkpje,0.0) AS wkpje,COALESCE(bsfchz.zs,0.0) AS zs FROM (SELECT khnc.khdm,khnc.khmc,khnc.zydm,khnc.zymc,khnc.sktj,khnc.skqx,khnc.qcje,qcxs.qcysje,qcsk.qcskje,bqrk.bqysje,bqck.bqskje,wkpxs.wkpje,qmzs.zs FROM" & _
                " (SELECT ar_khyeb.khdm,rc_khxx.khmc,rc_khxx.zydm,rc_khxx.zymc,rc_khxx.sktj,rc_khxx.skqx,sum(qcfpje) as qcje FROM ar_khyeb,rc_khxx WHERE ar_khyeb.khdm = rc_khxx.khdm AND ar_khyeb.kjnd = ?" & IIf(Not String.IsNullOrEmpty(Me.TxtZydm.Text), " AND rc_khxx.zydm = '" & Me.TxtZydm.Text & "'", "") & " GROUP BY ar_khyeb.khdm,rc_khxx.khmc,rc_khxx.zydm,rc_khxx.zymc,rc_khxx.sktj,rc_khxx.skqx) khnc" & _
                " Left join (SELECT oe_fp.khdm,sum(oe_fp.je + oe_fp.se) as qcysje FROM oe_fp WHERE oe_fp.bdelete = 0 AND TRUNC(oe_fp.fprq,'dd') >= ? and TRUNC(oe_fp.fprq,'dd') >= ? AND TRUNC(oe_fp.fprq,'dd') < ? GROUP BY oe_fp.khdm) qcxs ON khnc.khdm = qcxs.khdm" & _
                " Left join (SELECT ar_skd.khdm,sum(ar_skd.je) as qcskje FROM ar_skd WHERE ar_skd.skrq >= ? and ar_skd.skrq >= ? and ar_skd.skrq < ? GROUP BY ar_skd.khdm) qcsk ON khnc.khdm = qcsk.khdm" & _
                " Left join (SELECT oe_fp.khdm,sum(oe_fp.je + oe_fp.se) as bqysje FROM oe_fp WHERE oe_fp.bdelete = 0 AND TRUNC(oe_fp.fprq,'dd') >= ? and TRUNC(oe_fp.fprq,'dd') >= ? and TRUNC(oe_fp.fprq,'dd') <= ? GROUP BY oe_fp.khdm) bqrk ON khnc.khdm = bqrk.khdm" & _
                " Left join (SELECT ar_skd.khdm,sum(ar_skd.je) as bqskje FROM ar_skd WHERE ar_skd.skrq >= ? and ar_skd.skrq >= ? and ar_skd.skrq <= ? GROUP BY ar_skd.khdm) bqck ON khnc.khdm = bqck.khdm" & _
                " LEFT JOIN (SELECT oe_xsd.khdm,SUM(oe_xsd.je + oe_xsd.se - oe_xsd.fpje) AS wkpje FROM oe_xsd WHERE oe_xsd.sl <> oe_xsd.fpsl AND oe_xsd.bdelete = 0 GROUP BY oe_xsd.khdm) wkpxs ON khnc.khdm = wkpxs.khdm" & _
                " Left join (SELECT khdm,count(*) AS zs from (SELECT djh,khdm FROM oe_fp WHERE oe_fp.bdelete = 0 AND je <> skje AND TRUNC(oe_fp.fprq,'dd') <= ? GROUP BY djh,khdm) GROUP BY khdm) qmzs ON khnc.khdm = qmzs.khdm) bsfchz"
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
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = DtpHzrqEnd.Value
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
        '只显示有余额与发生额的客户
        If Me.CheckBox1.Checked Then
            For i = 0 To rcDataset.Tables("khyszkhz").Rows.Count - 1
                Me.ProgressBar1.Value = i
                If rcDataset.Tables("khyszkhz").Rows(i).Item("qcfpje") = 0 And rcDataset.Tables("khyszkhz").Rows(i).Item("ysje") = 0 And rcDataset.Tables("khyszkhz").Rows(i).Item("skje") = 0 And rcDataset.Tables("khyszkhz").Rows(i).Item("qmje") = 0 Then
                    rcDataset.Tables("khyszkhz").Rows(i).Delete()
                End If
            Next
        End If
        '只显示有余额的客户
        If Me.CheckBox2.Checked Then
            For i = 0 To rcDataset.Tables("khyszkhz").Rows.Count - 1
                Me.ProgressBar1.Value = i
                If rcDataset.Tables("khyszkhz").Rows(i).Item("qmje") = 0 Then
                    rcDataset.Tables("khyszkhz").Rows(i).Delete()
                End If
            Next
        End If
        Dim rcDataRow As DataRow
        rcDataRow = rcDataset.Tables("khyszkhz").NewRow
        rcDataRow.Item("khdm") = "合计"
        rcDataRow.Item("qcje") = dtKhYszkHz.Compute("Sum(qcje)", "")
        rcDataRow.Item("ysje") = dtKhYszkHz.Compute("Sum(ysje)", "")
        rcDataRow.Item("skje") = dtKhYszkHz.Compute("Sum(skje)", "")
        rcDataRow.Item("qmje") = dtKhYszkHz.Compute("Sum(qmje)", "")
        rcDataset.Tables("khyszkhz").Rows.Add(rcDataRow)

        '调用表单
        Dim rcFrm As New FrmKhYszkHzz
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("khyszkhz"), "TRUE", "khdm", DataViewRowState.CurrentRows)
            .Label2.Text = DtpHzrqBegin.Value & "至" & DtpHzrqEnd.Value
            '.Label3.Text = "仓库：" & Trim(Me.TxtCkdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class