Imports System.Data.OleDb

Public Class FrmJeSfcHz
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable
    ReadOnly dtCpsfcHz As New DataTable("cpsfchz")

    Private Sub FrmJeSfcHz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        DtpHzrqBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpHzrqEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '创建datatable
        dtCpsfcHz.Columns.Add("ckdm", Type.GetType("System.String"))
        dtCpsfcHz.Columns.Add("ckmc", Type.GetType("System.String"))
        dtCpsfcHz.Columns.Add("qcsl", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("qczl", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("qcje", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("rksl", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("rkzl", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("rkje", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("cksl", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("ckzl", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("ckje", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("jcsl", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("jczl", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("jcje", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtCpsfcHz)
        With dtCpsfcHz
            .Columns("ckdm").DefaultValue = ""
            .Columns("qcsl").DefaultValue = 0.0
            .Columns("qczl").DefaultValue = 0.0
            .Columns("qcje").DefaultValue = 0.0
            .Columns("rksl").DefaultValue = 0.0
            .Columns("rkzl").DefaultValue = 0.0
            .Columns("rkje").DefaultValue = 0.0
            .Columns("cksl").DefaultValue = 0.0
            .Columns("ckzl").DefaultValue = 0.0
            .Columns("ckje").DefaultValue = 0.0
            .Columns("jcsl").DefaultValue = 0.0
            .Columns("jczl").DefaultValue = 0.0
            .Columns("jcje").DefaultValue = 0.0
        End With
    End Sub

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpHzrqBegin.KeyPress, DtpHzrqEnd.KeyPress, TxtLbdm.KeyPress, TxtCkdm.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "物料类别编码的事件"

    Private Sub Txtlbdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLbdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_cplb"
                    .paraField1 = "lbdm"
                    .paraField2 = "lbmc"
                    .paraField3 = "lbsm"
                    .paraTitle = "物料类别"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtLbdm.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub Txtlbdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtLbdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtLbdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_cplb WHERE (lbdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = Trim(TxtLbdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_cplb") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_cplb").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_cplb")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_cplb").Rows.Count > 0 Then
                Me.TxtLbdm.Text = Trim(rcDataset.Tables("rc_cplb").Rows(0).Item("lbdm"))
            Else
                e.Cancel = True
            End If
        End If
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
        If dtCpsfcHz IsNot Nothing Then
            dtCpsfcHz.Clear()
        End If
        '权限控制
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT code AS lbdm FROM rc_userqx WHERE righttype = 'LBDM' AND User_Account = ?" & IIf(Trim(Me.TxtLbdm.Text).Length > 0, " AND code ='" & Trim(Me.TxtLbdm.Text) & "'", "")
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = g_User_Account
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_cplb") IsNot Nothing Then
                rcDataset.Tables("rc_cplb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_cplb")
        Catch ex As Exception
            MsgBox("程序错误2。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        'If rcDataset.Tables("rc_cplb").Rows.Count <= 0 Then
        '    MsgBox("你无权查看该报表。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
        '    Return
        'End If
        Dim strExpLbdm As String = ""
        Dim j As Integer
        If rcDataset.Tables("rc_cplb").Rows.Count = 1 Then
            Me.TxtLbdm.Text = Trim(rcDataset.Tables("rc_cplb").Rows(0).Item("lbdm"))
            strExpLbdm = " lbdm = '" & Trim(rcDataset.Tables("rc_cplb").Rows(0).Item("lbdm")) & "'"
        Else
            For j = 0 To rcDataset.Tables("rc_cplb").Rows.Count - 1
                strExpLbdm = strExpLbdm & " OR lbdm = '" & Trim(rcDataset.Tables("rc_cplb").Rows(j).Item("lbdm")) & "'"
            Next
        End If
        If strExpLbdm.Length = 0 Then
            strExpLbdm = " 0=0"
        End If
        If strExpLbdm.Length > 0 Then
            If strExpLbdm.Substring(0, 3) = " OR" Then
                strExpLbdm = strExpLbdm.Substring(3)
            End If
        End If
        '取数据
        '取期初库存、期初入库、期初出库、本期入库、本期出库
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT bsfchz.ckdm,bsfchz.ckmc,COALESCE(bsfchz.qcsl,0.0)+COALESCE(bsfchz.qcscrksl,0.0)+COALESCE(bsfchz.qccgrksl,0.0)+COALESCE(bsfchz.qcdbrksl,0.0)-COALESCE(bsfchz.qcxscksl,0.0)-COALESCE(bsfchz.qcckcksl,0.0)-COALESCE(bsfchz.qcdbcksl,0.0) as qcsl,COALESCE(bsfchz.qczl,0.0)+COALESCE(bsfchz.qcscrkzl,0.0)+COALESCE(bsfchz.qccgrkzl,0.0)+COALESCE(bsfchz.qcdbrkzl,0.0)-COALESCE(bsfchz.qcxsckzl,0.0)-COALESCE(bsfchz.qcckckzl,0.0)-COALESCE(bsfchz.qcdbckzl,0.0) as qczl,COALESCE(bsfchz.qcje,0.0)+COALESCE(bsfchz.qcscrkje,0.0)+COALESCE(bsfchz.qccgrkje,0.0)+COALESCE(bsfchz.qcdbrkje,0.0)-COALESCE(bsfchz.qcxsckje,0.0)-COALESCE(bsfchz.qcckckje,0.0)-COALESCE(bsfchz.qcdbckje,0.0) as qcje,COALESCE(bsfchz.bqscrksl,0.0) + COALESCE(bsfchz.bqcgrksl,0.0) + COALESCE(bsfchz.bqdbrksl,0.0) AS rksl,COALESCE(bsfchz.bqscrkzl,0.0) + COALESCE(bsfchz.bqcgrkzl,0.0) + COALESCE(bsfchz.bqdbrkzl,0.0) AS rkzl,COALESCE(bsfchz.bqscrkje,0.0) +COALESCE(bsfchz.bqcgrkje,0.0) +COALESCE(bsfchz.bqdbrkje,0.0) AS rkje,COALESCE(bsfchz.bqxscksl,0.0) + COALESCE(bsfchz.bqckcksl,0.0) + COALESCE(bsfchz.bqdbcksl,0.0) AS cksl,COALESCE(bsfchz.bqxsckzl,0.0) + COALESCE(bsfchz.bqckckzl,0.0) + COALESCE(bsfchz.bqdbckzl,0.0) AS ckzl,COALESCE(bsfchz.bqxsckje,0.0)+COALESCE(bsfchz.bqckckje,0.0)+COALESCE(bsfchz.bqdbckje,0.0) AS ckje,COALESCE(bsfchz.qcsl,0.0)+COALESCE(bsfchz.qcscrksl,0.0)+COALESCE(bsfchz.qccgrksl,0.0)+COALESCE(bsfchz.qcdbrksl,0.0)-COALESCE(bsfchz.qcxscksl,0.0)-COALESCE(bsfchz.qcckcksl,0.0)-COALESCE(bsfchz.qcdbcksl,0.0) + COALESCE(bsfchz.bqscrksl,0.0)+ COALESCE(bsfchz.bqcgrksl,0.0)+ COALESCE(bsfchz.bqdbrksl,0.0) - COALESCE(bsfchz.bqxscksl,0.0) - COALESCE(bsfchz.bqckcksl,0.0) - COALESCE(bsfchz.bqdbcksl,0.0) AS jcsl,COALESCE(bsfchz.qczl,0.0)+COALESCE(bsfchz.qcscrkzl,0.0)+COALESCE(bsfchz.qccgrkzl,0.0)+COALESCE(bsfchz.qcdbrkzl,0.0)-COALESCE(bsfchz.qcxsckzl,0.0)-COALESCE(bsfchz.qcckckzl,0.0)-COALESCE(bsfchz.qcdbckzl,0.0) + COALESCE(bsfchz.bqscrkzl,0.0)+ COALESCE(bsfchz.bqcgrkzl,0.0)+ COALESCE(bsfchz.bqdbrkzl,0.0) - COALESCE(bsfchz.bqxsckzl,0.0) - COALESCE(bsfchz.bqckckzl,0.0) - COALESCE(bsfchz.bqdbckzl,0.0) AS jczl,COALESCE(bsfchz.qcje,0.0)+COALESCE(bsfchz.qcscrkje,0.0)+COALESCE(bsfchz.qccgrkje,0.0)+COALESCE(bsfchz.qcdbrkje,0.0)-COALESCE(bsfchz.qcxsckje,0.0)-COALESCE(bsfchz.qcckckje,0.0)-COALESCE(bsfchz.qcdbckje,0.0)+ COALESCE(bsfchz.bqscrkje,0.0)+ COALESCE(bsfchz.bqcgrkje,0.0)+ COALESCE(bsfchz.bqdbrkje,0.0) - COALESCE(bsfchz.bqxsckje,0.0)- COALESCE(bsfchz.bqckckje,0.0)- COALESCE(bsfchz.bqdbckje,0.0) AS jcje FROM" & _
                " (SELECT asfchz.*,rc_ckxx.ckmc FROM" & _
                " (SELECT cpnc.ckdm,cpnc.qcsl,cpnc.qczl,cpnc.qcje,qcscrk.qcscrksl,qcscrk.qcscrkzl,qcscrk.qcscrkje,qccgrk.qccgrksl,qccgrk.qccgrkzl,qccgrk.qccgrkje,qcdbrk.qcdbrksl,qcdbrk.qcdbrkzl,qcdbrk.qcdbrkje,qcxsck.qcxscksl,qcxsck.qcxsckzl,qcxsck.qcxsckje,qcckck.qcckcksl,qcckck.qcckckzl,qcckck.qcckckje,qcdbck.qcdbcksl,qcdbck.qcdbckzl,qcdbck.qcdbckje,bqscrk.bqscrksl,bqscrk.bqscrkzl,bqscrk.bqscrkje,bqcgrk.bqcgrksl,bqcgrk.bqcgrkzl,bqcgrk.bqcgrkje,bqdbrk.bqdbrksl,bqdbrk.bqdbrkzl,bqdbrk.bqdbrkje,bqxsck.bqxscksl,bqxsck.bqxsckzl,bqxsck.bqxsckje,bqckck.bqckcksl,bqckck.bqckckzl,bqckck.bqckckje,bqdbck.bqdbcksl,bqdbck.bqdbckzl,bqdbck.bqdbckje FROM" & _
                " (SELECT inv_cpyeb.ckdm,sum(qcsl) as qcsl,sum(qcsl * rc_cpxx.cpweight)/1000 as qczl,sum(qcje) as qcje FROM inv_cpyeb,rc_cpxx WHERE inv_cpyeb.kjnd = ? AND inv_cpyeb.cpdm = rc_cpxx.cpdm" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_cpyeb.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_cpyeb.ckdm) cpnc" & _
                " Left join (SELECT inv_rkd.ckdm,sum(inv_rkd.sl) as qcscrksl,sum(inv_rkd.sl * rc_cpxx.cpweight)/1000 as qcscrkzl,sum(inv_rkd.je) as qcscrkje FROM inv_rkd,rc_cpxx WHERE inv_rkd.bdelete = 0 AND inv_rkd.cpdm = rc_cpxx.cpdm AND inv_rkd.rkrq >= ? and inv_rkd.rkrq >= ? and inv_rkd.rkrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_rkd.ckdm) qcscrk ON cpnc.ckdm = qcscrk.ckdm" & _
                " Left join (SELECT po_rkd.ckdm,sum(po_rkd.sl) as qccgrksl,sum(po_rkd.sl * rc_cpxx.cpweight)/1000 as qccgrkzl,sum(po_rkd.je) as qccgrkje FROM po_rkd,rc_cpxx WHERE po_rkd.bdelete = 0 AND po_rkd.cpdm = rc_cpxx.cpdm AND po_rkd.rkrq >= ? and po_rkd.rkrq >= ? and po_rkd.rkrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND po_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY po_rkd.ckdm) qccgrk ON cpnc.ckdm = qccgrk.ckdm" & _
                " Left join (SELECT inv_dbd.rckdm AS ckdm,sum(inv_dbd.sl) as qcdbrksl,sum(inv_dbd.sl * rc_cpxx.cpweight)/1000 as qcdbrkzl,sum(inv_dbd.je) as qcdbrkje FROM inv_dbd,rc_cpxx WHERE inv_dbd.bdelete = 0 AND inv_dbd.cpdm = rc_cpxx.cpdm AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.rckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_dbd.rckdm) qcdbrk ON cpnc.ckdm = qcdbrk.ckdm" & _
                " Left join (SELECT oe_xsd.ckdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.sl * rc_cpxx.cpweight)/1000 as qcxsckzl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd,rc_cpxx WHERE oe_xsd.bdelete = 0 AND oe_xsd.cpdm = rc_cpxx.cpdm AND oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND oe_xsd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY oe_xsd.ckdm) qcxsck ON cpnc.ckdm = qcxsck.ckdm" & _
                " Left join (SELECT inv_ckd.ckdm,sum(inv_ckd.sl) as qcckcksl,sum(inv_ckd.sl * rc_cpxx.cpweight)/1000 as qcckckzl,sum(inv_ckd.je) as qcckckje FROM inv_ckd,rc_cpxx WHERE inv_ckd.bdelete = 0 AND inv_ckd.cpdm = rc_cpxx.cpdm AND inv_ckd.ckrq >= ? and inv_ckd.ckrq >= ? and inv_ckd.ckrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_ckd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_ckd.ckdm) qcckck ON cpnc.ckdm = qcckck.ckdm" & _
                " Left join (SELECT inv_dbd.cckdm AS ckdm,sum(inv_dbd.sl) as qcdbcksl,sum(inv_dbd.sl * rc_cpxx.cpweight)/1000 as qcdbckzl,sum(inv_dbd.je) as qcdbckje FROM inv_dbd,rc_cpxx WHERE inv_dbd.bdelete = 0 AND inv_dbd.cpdm = rc_cpxx.cpdm AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.cckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_dbd.cckdm) qcdbck ON cpnc.ckdm = qcdbck.ckdm" & _
                " Left join (SELECT inv_rkd.ckdm,sum(inv_rkd.sl) as bqscrksl,sum(inv_rkd.sl * rc_cpxx.cpweight)/1000 as bqscrkzl,sum(inv_rkd.je) as bqscrkje FROM inv_rkd,rc_cpxx WHERE inv_rkd.bdelete = 0 AND inv_rkd.cpdm = rc_cpxx.cpdm AND inv_rkd.rkrq >= ? and inv_rkd.rkrq >= ? and inv_rkd.rkrq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_rkd.ckdm) bqscrk ON cpnc.ckdm = bqscrk.ckdm" & _
                " Left join (SELECT po_rkd.ckdm,sum(po_rkd.sl) as bqcgrksl,sum(po_rkd.sl * rc_cpxx.cpweight)/1000 as bqcgrkzl,sum(po_rkd.je) as bqcgrkje FROM po_rkd,rc_cpxx WHERE po_rkd.bdelete = 0 AND po_rkd.cpdm = rc_cpxx.cpdm AND po_rkd.rkrq >= ? and po_rkd.rkrq >= ? and po_rkd.rkrq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND po_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY po_rkd.ckdm) bqcgrk ON cpnc.ckdm = bqcgrk.ckdm" & _
                " Left join (SELECT inv_dbd.rckdm AS ckdm,sum(inv_dbd.sl) as bqdbrksl,sum(inv_dbd.sl * rc_cpxx.cpweight)/1000 as bqdbrkzl,sum(inv_dbd.je) as bqdbrkje FROM inv_dbd,rc_cpxx WHERE inv_dbd.bdelete = 0 AND inv_dbd.cpdm = rc_cpxx.cpdm AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.rckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_dbd.rckdm) bqdbrk ON cpnc.ckdm = bqdbrk.ckdm" & _
                " Left join (SELECT oe_xsd.ckdm,sum(oe_xsd.sl) as bqxscksl,sum(oe_xsd.sl * rc_cpxx.cpweight)/1000 as bqxsckzl,sum(oe_xsd.cbje) as bqxsckje FROM oe_xsd,rc_cpxx WHERE oe_xsd.bdelete = 0 AND oe_xsd.cpdm = rc_cpxx.cpdm AND oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND oe_xsd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY oe_xsd.ckdm) bqxsck ON cpnc.ckdm = bqxsck.ckdm" & _
                " Left join (SELECT inv_ckd.ckdm,sum(inv_ckd.sl) as bqckcksl,sum(inv_ckd.sl * rc_cpxx.cpweight)/1000 as bqckckzl,sum(inv_ckd.je) as bqckckje FROM inv_ckd,rc_cpxx WHERE inv_ckd.bdelete = 0 AND inv_ckd.cpdm = rc_cpxx.cpdm AND inv_ckd.ckrq >= ? and inv_ckd.ckrq >= ? and inv_ckd.ckrq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_ckd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_ckd.ckdm) bqckck ON cpnc.ckdm = bqckck.ckdm" & _
                " Left join (SELECT inv_dbd.cckdm AS ckdm,sum(inv_dbd.sl) as bqdbcksl,sum(inv_dbd.sl * rc_cpxx.cpweight)/1000 as bqdbckzl,sum(inv_dbd.je) as bqdbckje FROM inv_dbd,rc_cpxx WHERE inv_dbd.bdelete = 0 AND inv_dbd.cpdm = rc_cpxx.cpdm AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.cckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_dbd.cckdm) bqdbck ON cpnc.ckdm = bqdbck.ckdm) asfchz LEFT JOIN rc_ckxx ON asfchz.ckdm = rc_ckxx.ckdm) bsfchz"
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
            If rcDataset.Tables("cpsfchz") IsNot Nothing Then
                rcDataset.Tables("cpsfchz").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "cpsfchz")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("cpsfchz").Rows.Count > 0 Then
            Me.ProgressBar1.Maximum = rcDataset.Tables("cpsfchz").Rows.Count - 1
        End If
        Dim rcDataRow As DataRow
        rcDataRow = rcDataset.Tables("cpsfchz").NewRow
        rcDataRow.Item("ckdm") = "合计"
        rcDataRow.Item("qcsl") = dtCpsfcHz.Compute("Sum(qcsl)", "")
        rcDataRow.Item("qczl") = dtCpsfcHz.Compute("Sum(qczl)", "")
        rcDataRow.Item("qcje") = dtCpsfcHz.Compute("Sum(qcje)", "")
        rcDataRow.Item("rksl") = dtCpsfcHz.Compute("Sum(rksl)", "")
        rcDataRow.Item("rkzl") = dtCpsfcHz.Compute("Sum(rkzl)", "")
        rcDataRow.Item("rkje") = dtCpsfcHz.Compute("Sum(rkje)", "")
        rcDataRow.Item("cksl") = dtCpsfcHz.Compute("Sum(cksl)", "")
        rcDataRow.Item("ckzl") = dtCpsfcHz.Compute("Sum(ckzl)", "")
        rcDataRow.Item("ckje") = dtCpsfcHz.Compute("Sum(ckje)", "")
        rcDataRow.Item("jcsl") = dtCpsfcHz.Compute("Sum(jcsl)", "")
        rcDataRow.Item("jczl") = dtCpsfcHz.Compute("Sum(jczl)", "")
        rcDataRow.Item("jcje") = dtCpsfcHz.Compute("Sum(jcje)", "")
        rcDataset.Tables("cpsfchz").Rows.Add(rcDataRow)

        '调用表单
        Dim rcFrm As New FrmJeSfcHzz
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("cpsfchz"), "TRUE", "ckdm", DataViewRowState.CurrentRows)
            .Label2.Text = DtpHzrqBegin.Value & "至" & DtpHzrqEnd.Value
            '.Label3.Text = "仓库：" & Trim(Me.TxtCkdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

End Class