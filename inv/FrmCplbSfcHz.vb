Imports System.Data.OleDb

Public Class FrmCplbSfcHz
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable
    ReadOnly dtCplbSfcHz As New DataTable("cplbsfchz")

    Private Sub FrmCplbSfcHz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        DtpHzrqBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpHzrqEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '创建datatable
        dtCplbSfcHz.Columns.Add("lbdm", Type.GetType("System.String"))
        dtCplbSfcHz.Columns.Add("lbmc", Type.GetType("System.String"))
        dtCplbSfcHz.Columns.Add("qcje", Type.GetType("System.Double"))
        dtCplbSfcHz.Columns.Add("rkje", Type.GetType("System.Double"))
        dtCplbSfcHz.Columns.Add("ckje", Type.GetType("System.Double"))
        dtCplbSfcHz.Columns.Add("jcje", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtCplbSfcHz)
        With dtCplbSfcHz
            .Columns("lbdm").DefaultValue = ""
            .Columns("qcje").DefaultValue = 0.0
            .Columns("rkje").DefaultValue = 0.0
            .Columns("ckje").DefaultValue = 0.0
            .Columns("jcje").DefaultValue = 0.0
        End With
    End Sub

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpHzrqBegin.KeyPress, DtpHzrqEnd.KeyPress, TxtCkdm.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "仓库编码的事件"

    Private Sub TxtCkdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCkdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_ckxx"
                    .paraField1 = "ckdm"
                    .paraField2 = "ckmc"
                    .paraField3 = "cksm"
                    .paraTitle = "仓库"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtCkdm.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtCkdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCkdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtCkdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_ckxx WHERE (ckdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(TxtCkdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_ckxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_ckxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_ckxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_ckxx").Rows.Count > 0 Then
                Me.TxtCkdm.Text = Trim(rcDataset.Tables("rc_ckxx").Rows(0).Item("ckdm"))
                'Me.LblCkmc.Text = Trim(rcDataSet.Tables("rc_ckxx").Rows(0).Item("ckmc"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim strKjqj As String = getInvKjqj(DtpHzrqBegin.Value)
        Dim dInvBegin1 As Date = getInvBegin(Mid(strKjqj, 1, 4), 1)
        Dim i As Integer = 1
        If dtCplbSfcHz IsNot Nothing Then
            dtCplbSfcHz.Clear()
        End If
        '取数据
        '取期初库存、期初入库、期初出库、本期入库、本期出库
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT csfchz.lbdm,rc_cplb.lbmc,csfchz.qcsl,csfchz.qczl,csfchz.qcje,csfchz.rksl,csfchz.rkzl,csfchz.rkje,csfchz.cksl,csfchz.ckzl,csfchz.ckje,csfchz.jcsl,csfchz.jczl,csfchz.jcje FROM" &
                " (SELECT bsfchz.lbdm" &
                ",SUM(COALESCE(bsfchz.qcsl,0.0)+COALESCE(bsfchz.qcscrksl,0.0)+COALESCE(bsfchz.qccgrksl,0.0)+COALESCE(bsfchz.qcdbrksl,0.0)-COALESCE(bsfchz.qcxscksl,0.0)-COALESCE(bsfchz.qcckcksl,0.0)-COALESCE(bsfchz.qcdbcksl,0.0)) as qcsl" &
                ",SUM((COALESCE(bsfchz.qcsl,0.0)+COALESCE(bsfchz.qcscrksl,0.0)+COALESCE(bsfchz.qccgrksl,0.0)+COALESCE(bsfchz.qcdbrksl,0.0)-COALESCE(bsfchz.qcxscksl,0.0)-COALESCE(bsfchz.qcckcksl,0.0)-COALESCE(bsfchz.qcdbcksl,0.0))*bsfchz.cpweight) as qczl" &
                ",SUM(COALESCE(bsfchz.qcje,0.0)+COALESCE(bsfchz.qcscrkje,0.0)+COALESCE(bsfchz.qccgrkje,0.0)+COALESCE(bsfchz.qcdbrkje,0.0)-COALESCE(bsfchz.qcxsckje,0.0)-COALESCE(bsfchz.qcckckje,0.0)-COALESCE(bsfchz.qcdbckje,0.0)) as qcje" &
                ",SUM(COALESCE(bsfchz.bqscrksl,0.0) +COALESCE(bsfchz.bqcgrksl,0.0) +COALESCE(bsfchz.bqdbrksl,0.0)) AS rksl" &
                ",SUM((COALESCE(bsfchz.bqscrksl,0.0) +COALESCE(bsfchz.bqcgrksl,0.0) +COALESCE(bsfchz.bqdbrksl,0.0)) * bsfchz.cpweight) AS rkzl" &
                ",SUM(COALESCE(bsfchz.bqscrkje,0.0) +COALESCE(bsfchz.bqcgrkje,0.0) +COALESCE(bsfchz.bqdbrkje,0.0)) AS rkje" &
                ",SUM(COALESCE(bsfchz.bqxscksl,0.0)+COALESCE(bsfchz.bqckcksl,0.0)+COALESCE(bsfchz.bqdbcksl,0.0)) AS cksl" &
                ",SUM((COALESCE(bsfchz.bqxscksl,0.0)+COALESCE(bsfchz.bqckcksl,0.0)+COALESCE(bsfchz.bqdbcksl,0.0)) * bsfchz.cpweight) AS ckzl" &
                ",SUM(COALESCE(bsfchz.bqxsckje,0.0)+COALESCE(bsfchz.bqckckje,0.0)+COALESCE(bsfchz.bqdbckje,0.0)) AS ckje" &
                ",SUM(COALESCE(bsfchz.qcsl,0.0)+COALESCE(bsfchz.qcscrksl,0.0)+COALESCE(bsfchz.qccgrksl,0.0)+COALESCE(bsfchz.qcdbrksl,0.0)-COALESCE(bsfchz.qcxscksl,0.0)-COALESCE(bsfchz.qcckcksl,0.0)-COALESCE(bsfchz.qcdbcksl,0.0)+ COALESCE(bsfchz.bqscrksl,0.0)+ COALESCE(bsfchz.bqcgrksl,0.0)+ COALESCE(bsfchz.bqdbrksl,0.0) - COALESCE(bsfchz.bqxscksl,0.0)- COALESCE(bsfchz.bqckcksl,0.0)- COALESCE(bsfchz.bqdbcksl,0.0)) AS jcsl" &
                ",SUM((COALESCE(bsfchz.qcsl,0.0)+COALESCE(bsfchz.qcscrksl,0.0)+COALESCE(bsfchz.qccgrksl,0.0)+COALESCE(bsfchz.qcdbrksl,0.0)-COALESCE(bsfchz.qcxscksl,0.0)-COALESCE(bsfchz.qcckcksl,0.0)-COALESCE(bsfchz.qcdbcksl,0.0)+ COALESCE(bsfchz.bqscrksl,0.0)+ COALESCE(bsfchz.bqcgrksl,0.0)+ COALESCE(bsfchz.bqdbrksl,0.0) - COALESCE(bsfchz.bqxscksl,0.0)- COALESCE(bsfchz.bqckcksl,0.0)- COALESCE(bsfchz.bqdbcksl,0.0)) * bsfchz.cpweight) AS jczl" &
                ",SUM(COALESCE(bsfchz.qcje,0.0)+COALESCE(bsfchz.qcscrkje,0.0)+COALESCE(bsfchz.qccgrkje,0.0)+COALESCE(bsfchz.qcdbrkje,0.0)-COALESCE(bsfchz.qcxsckje,0.0)-COALESCE(bsfchz.qcckckje,0.0)-COALESCE(bsfchz.qcdbckje,0.0)+ COALESCE(bsfchz.bqscrkje,0.0)+ COALESCE(bsfchz.bqcgrkje,0.0)+ COALESCE(bsfchz.bqdbrkje,0.0) - COALESCE(bsfchz.bqxsckje,0.0)- COALESCE(bsfchz.bqckckje,0.0)- COALESCE(bsfchz.bqdbckje,0.0)) AS jcje" &
                " FROM" &
                " (SELECT asfchz.*,rc_cpxx.lbdm,rc_cpxx.cpweight FROM" &
                " (SELECT cpnc.cpdm,cpnc.qcsl,cpnc.qcje,qcscrk.qcscrksl,qcscrk.qcscrkje,qccgrk.qccgrksl,qccgrk.qccgrkje,qcdbrk.qcdbrksl,qcdbrk.qcdbrkje,qcxsck.qcxscksl,qcxsck.qcxsckje,qcckck.qcckcksl,qcckck.qcckckje,qcdbck.qcdbcksl,qcdbck.qcdbckje,bqscrk.bqscrksl,bqscrk.bqscrkje,bqcgrk.bqcgrksl,bqcgrk.bqcgrkje,bqdbrk.bqdbrksl,bqdbrk.bqdbrkje,bqxsck.bqxscksl,bqxsck.bqxsckje,bqckck.bqckcksl,bqckck.bqckckje,bqdbck.bqdbcksl,bqdbck.bqdbckje FROM" &
                " (SELECT inv_cpyeb.cpdm,sum(qcsl) AS qcsl,sum(qcje) as qcje FROM inv_cpyeb WHERE kjnd = ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_cpyeb.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_cpyeb.cpdm) cpnc" &
                " Left join (SELECT inv_rkd.cpdm,sum(inv_rkd.sl) as qcscrksl,sum(inv_rkd.je) as qcscrkje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND inv_rkd.rkrq >= ? and inv_rkd.rkrq >= ? and inv_rkd.rkrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_rkd.cpdm) qcscrk ON cpnc.cpdm = qcscrk.cpdm" &
                " Left join (SELECT po_rkd.cpdm,sum(po_rkd.sl) as qccgrksl,sum(po_rkd.je) as qccgrkje FROM po_rkd WHERE po_rkd.bdelete = 0 AND po_rkd.rkrq >= ? and po_rkd.rkrq >= ? and po_rkd.rkrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND po_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY po_rkd.cpdm) qccgrk ON cpnc.cpdm = qccgrk.cpdm" &
                " Left join (SELECT inv_dbd.cpdm,sum(inv_dbd.sl) as qcdbrksl,sum(inv_dbd.je) as qcdbrkje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.rckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_dbd.cpdm) qcdbrk ON cpnc.cpdm = qcdbrk.cpdm" &
                " Left join (SELECT oe_xsd.cpdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND oe_xsd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY oe_xsd.cpdm) qcxsck ON cpnc.cpdm = qcxsck.cpdm" &
                " Left join (SELECT inv_ckd.cpdm,sum(inv_ckd.sl) as qcckcksl,sum(inv_ckd.je) as qcckckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND inv_ckd.ckrq >= ? and inv_ckd.ckrq >= ? and inv_ckd.ckrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_ckd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_ckd.cpdm) qcckck ON cpnc.cpdm = qcckck.cpdm" &
                " Left join (SELECT inv_dbd.cpdm,sum(inv_dbd.sl) as qcdbcksl,sum(inv_dbd.je) as qcdbckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.cckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_dbd.cpdm) qcdbck ON cpnc.cpdm = qcdbck.cpdm" &
                " Left join (SELECT inv_rkd.cpdm,sum(inv_rkd.sl) as bqscrksl,sum(inv_rkd.je) as bqscrkje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND inv_rkd.rkrq >= ? and inv_rkd.rkrq >= ? and inv_rkd.rkrq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_rkd.cpdm) bqscrk ON cpnc.cpdm = bqscrk.cpdm" &
                " Left join (SELECT po_rkd.cpdm,sum(po_rkd.sl) as bqcgrksl,sum(po_rkd.je) as bqcgrkje FROM po_rkd WHERE po_rkd.bdelete = 0 AND po_rkd.rkrq >= ? and po_rkd.rkrq >= ? and po_rkd.rkrq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND po_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY po_rkd.cpdm) bqcgrk ON cpnc.cpdm = bqcgrk.cpdm" &
                " Left join (SELECT inv_dbd.cpdm,sum(inv_dbd.sl) as bqdbrksl,sum(inv_dbd.je) as bqdbrkje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.rckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_dbd.cpdm) bqdbrk ON cpnc.cpdm = bqdbrk.cpdm" &
                " Left join (SELECT oe_xsd.cpdm,sum(oe_xsd.sl) as bqxscksl,sum(oe_xsd.cbje) as bqxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND oe_xsd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY oe_xsd.cpdm) bqxsck ON cpnc.cpdm = bqxsck.cpdm" &
                " Left join (SELECT inv_ckd.cpdm,sum(inv_ckd.sl) as bqckcksl,sum(inv_ckd.je) as bqckckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND inv_ckd.ckrq >= ? and inv_ckd.ckrq >= ? and inv_ckd.ckrq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_ckd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_ckd.cpdm) bqckck ON cpnc.cpdm = bqckck.cpdm" &
                " Left join (SELECT inv_dbd.cpdm,sum(inv_dbd.sl) as bqdbcksl,sum(inv_dbd.je) as bqdbckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.cckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_dbd.cpdm) bqdbck ON cpnc.cpdm = bqdbck.cpdm) asfchz LEFT JOIN rc_cpxx ON asfchz.cpdm = rc_cpxx.cpdm) bsfchz GROUP BY lbdm) csfchz LEFT JOIN rc_cplb ON csfchz.lbdm = rc_cplb.lbdm ORDER BY csfchz.lbdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(strKjqj, 1, 4)
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dInvBegin1.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dInvBegin1.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dInvBegin1.Date
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dInvBegin1.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dInvBegin1.Date
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dInvBegin1.Date
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = DtpHzrqEnd.Value
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = DtpHzrqEnd.Value
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = DtpHzrqEnd.Value
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = DtpHzrqEnd.Value
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = DtpHzrqEnd.Value
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = DtpHzrqEnd.Value
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("cplbsfchz") IsNot Nothing Then
                rcDataset.Tables("cplbsfchz").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "cplbsfchz")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("cplbsfchz").Rows.Count > 0 Then
            Me.ProgressBar1.Maximum = rcDataset.Tables("cplbsfchz").Rows.Count - 1
        End If
        Dim rcDataRow As DataRow
        rcDataRow = rcDataset.Tables("cplbsfchz").NewRow
        rcDataRow.Item("lbdm") = "合计"
        rcDataRow.Item("qcsl") = dtCplbSfcHz.Compute("Sum(qcsl)", "")
        rcDataRow.Item("rksl") = dtCplbSfcHz.Compute("Sum(rksl)", "")
        rcDataRow.Item("cksl") = dtCplbSfcHz.Compute("Sum(cksl)", "")
        rcDataRow.Item("jcsl") = dtCplbSfcHz.Compute("Sum(jcsl)", "")
        rcDataRow.Item("qczl") = dtCplbSfcHz.Compute("Sum(qczl)", "")
        rcDataRow.Item("rkzl") = dtCplbSfcHz.Compute("Sum(rkzl)", "")
        rcDataRow.Item("ckzl") = dtCplbSfcHz.Compute("Sum(ckzl)", "")
        rcDataRow.Item("jczl") = dtCplbSfcHz.Compute("Sum(jczl)", "")
        rcDataRow.Item("qcje") = dtCplbSfcHz.Compute("Sum(qcje)", "")
        rcDataRow.Item("rkje") = dtCplbSfcHz.Compute("Sum(rkje)", "")
        rcDataRow.Item("ckje") = dtCplbSfcHz.Compute("Sum(ckje)", "")
        rcDataRow.Item("jcje") = dtCplbSfcHz.Compute("Sum(jcje)", "")
        rcDataset.Tables("cplbsfchz").Rows.Add(rcDataRow)

        '调用表单
        Dim rcFrm As New FrmCplbSfcHzz
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("cplbsfchz"), "TRUE", "lbdm", DataViewRowState.CurrentRows)
            .Label2.Text = DtpHzrqBegin.Value & "至" & DtpHzrqEnd.Value
            '.Label3.Text = "仓库：" & Trim(Me.TxtCkdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

End Class