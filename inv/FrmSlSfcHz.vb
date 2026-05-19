Imports System.Data.OleDb

Public Class FrmSlSfcHz
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable
    ReadOnly dtCpsfcHz As New DataTable("cpsfchz")

    Private Sub FrmSlSfcHz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        DtpHzrqBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpHzrqEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '创建datatable
        dtCpsfcHz.Columns.Add("cpdm", Type.GetType("System.String"))
        dtCpsfcHz.Columns.Add("cpmc", Type.GetType("System.String"))
        dtCpsfcHz.Columns.Add("dw", Type.GetType("System.String"))
        dtCpsfcHz.Columns.Add("ckdm", Type.GetType("System.String"))
        dtCpsfcHz.Columns.Add("ckmc", Type.GetType("System.String"))
        dtCpsfcHz.Columns.Add("qcsl", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("qcfzsl", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("rksl", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("rkfzsl", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("cksl", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("ckfzsl", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("jcsl", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("jcfzsl", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtCpsfcHz)
        With dtCpsfcHz
            .Columns("cpdm").DefaultValue = ""
            .Columns("ckdm").DefaultValue = ""
            .Columns("qcsl").DefaultValue = 0.0
            .Columns("qcfzsl").DefaultValue = 0.0
            .Columns("rksl").DefaultValue = 0.0
            .Columns("rkfzsl").DefaultValue = 0.0
            .Columns("cksl").DefaultValue = 0.0
            .Columns("ckfzsl").DefaultValue = 0.0
            .Columns("jcsl").DefaultValue = 0.0
            .Columns("jcfzsl").DefaultValue = 0.0
        End With
    End Sub

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpHzrqBegin.KeyPress, DtpHzrqEnd.KeyPress, TxtLbdm.KeyPress, TxtCkdmBegin.KeyPress, TxtCkdmEnd.KeyPress, TxtCpdmBegin.KeyPress, TxtCpdmEnd.KeyPress, TxtCpmc.KeyPress
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
                sender.Text = Trim(rcDataset.Tables("rc_cplb").Rows(0).Item("lbdm"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "仓库编码的事件"

    Private Sub TxtCkdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCkdmBegin.KeyDown, TxtCkdmEnd.KeyDown
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
                        sender.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtCkdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCkdmBegin.Validating, TxtCkdmEnd.Validating
        If Not String.IsNullOrEmpty(sender.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_ckxx WHERE (ckdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = sender.text
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
                sender.Text = Trim(rcDataset.Tables("rc_ckxx").Rows(0).Item("ckdm"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "物料编码事件"

    Private Sub TxtCpdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCpdmBegin.KeyDown, TxtCpdmEnd.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF34
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_cpxx"
                    .paraField1 = "cpdm"
                    .paraField2 = "cpmc"
                    .paraField3 = "dw"
                    .paraField4 = "cpsm"
                    .paraOrderField = "cpmc"
                    .paraTitle = "物料"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        sender.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        '设置仓库编码值
        If Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text) Then
            If String.IsNullOrEmpty(Me.TxtCkdmEnd.Text) Then
                Me.TxtCkdmEnd.Text = Me.TxtCkdmBegin.Text
            End If
        End If
        '设置物料编码
        If Not String.IsNullOrEmpty(Me.TxtCpdmBegin.Text) Then
            If String.IsNullOrEmpty(Me.TxtCpdmEnd.Text) Then
                Me.TxtCpdmEnd.Text = Me.TxtCpdmBegin.Text
            End If
        End If

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
            strExpLbdm = " lbdm LIKE '" & Trim(rcDataset.Tables("rc_cplb").Rows(0).Item("lbdm")) & "%'"
        Else
            For j = 0 To rcDataset.Tables("rc_cplb").Rows.Count - 1
                strExpLbdm = strExpLbdm & " OR lbdm LIKE '" & Trim(rcDataset.Tables("rc_cplb").Rows(j).Item("lbdm")) & "%'"
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
        If Me.rdoCk.Checked Then
            '取分仓库的期初库存、期初入库、期初出库、本期入库、本期出库
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT bsfchz.cpdm,bsfchz.cpmc,bsfchz.dw,bsfchz.ckdm,bsfchz.ckmc" & _
                    ",COALESCE(bsfchz.qcsl,0.0)+COALESCE(bsfchz.qcscrksl,0.0)+COALESCE(bsfchz.qccgrksl,0.0)+COALESCE(bsfchz.qcdbrksl,0.0)-COALESCE(bsfchz.qcxscksl,0.0)-COALESCE(bsfchz.qcckcksl,0.0)-COALESCE(bsfchz.qcdbcksl,0.0) as qcsl,COALESCE(bsfchz.qcfzsl,0.0)+COALESCE(bsfchz.qcscrkfzsl,0.0)+COALESCE(bsfchz.qccgrkfzsl,0.0)+COALESCE(bsfchz.qcdbrkfzsl,0.0)-COALESCE(bsfchz.qcxsckfzsl,0.0)-COALESCE(bsfchz.qcckckfzsl,0.0)-COALESCE(bsfchz.qcdbckfzsl,0.0) as qcfzsl" & _
                    ",COALESCE(bsfchz.bqscrksl,0.0) + COALESCE(bsfchz.bqcgrksl,0.0) + COALESCE(bsfchz.bqdbrksl,0.0) AS rksl,COALESCE(bsfchz.bqscrkfzsl,0.0) + COALESCE(bsfchz.bqcgrkfzsl,0.0) + COALESCE(bsfchz.bqdbrkfzsl,0.0) AS rkfzsl" & _
                    ",COALESCE(bsfchz.bqxscksl,0.0) + COALESCE(bsfchz.bqckcksl,0.0) + COALESCE(bsfchz.bqdbcksl,0.0) AS cksl,COALESCE(bsfchz.bqxsckfzsl,0.0) + COALESCE(bsfchz.bqckckfzsl,0.0) + COALESCE(bsfchz.bqdbckfzsl,0.0) AS ckfzsl" & _
                    ",COALESCE(bsfchz.qcsl,0.0)+COALESCE(bsfchz.qcscrksl,0.0)+COALESCE(bsfchz.qccgrksl,0.0)+COALESCE(bsfchz.qcdbrksl,0.0)-COALESCE(bsfchz.qcxscksl,0.0)-COALESCE(bsfchz.qcckcksl,0.0)-COALESCE(bsfchz.qcdbcksl,0.0) + COALESCE(bsfchz.bqscrksl,0.0)+ COALESCE(bsfchz.bqcgrksl,0.0)+ COALESCE(bsfchz.bqdbrksl,0.0) - COALESCE(bsfchz.bqxscksl,0.0) - COALESCE(bsfchz.bqckcksl,0.0) - COALESCE(bsfchz.bqdbcksl,0.0) AS jcsl,COALESCE(bsfchz.qcfzsl,0.0)+COALESCE(bsfchz.qcscrkfzsl,0.0)+COALESCE(bsfchz.qccgrkfzsl,0.0)+COALESCE(bsfchz.qcdbrkfzsl,0.0)-COALESCE(bsfchz.qcxsckfzsl,0.0)-COALESCE(bsfchz.qcckckfzsl,0.0)-COALESCE(bsfchz.qcdbckfzsl,0.0) + COALESCE(bsfchz.bqscrkfzsl,0.0)+ COALESCE(bsfchz.bqcgrkfzsl,0.0)+ COALESCE(bsfchz.bqdbrkfzsl,0.0) - COALESCE(bsfchz.bqxsckfzsl,0.0) - COALESCE(bsfchz.bqckckfzsl,0.0) - COALESCE(bsfchz.bqdbckfzsl,0.0) AS jcfzsl FROM" & _
                    " (SELECT asfchz.*,rc_cpxx.cpmc,rc_cpxx.dw,rc_cpxx.lbdm,rc_ckxx.ckmc FROM" & _
                    " (SELECT cpnc.cpdm,cpnc.ckdm,cpnc.qcsl,cpnc.qcfzsl,qcscrk.qcscrksl,qcscrk.qcscrkfzsl,qccgrk.qccgrksl,qccgrk.qccgrkfzsl,qcdbrk.qcdbrksl,qcdbrk.qcdbrkfzsl,qcxsck.qcxscksl,qcxsck.qcxsckfzsl,qcckck.qcckcksl,qcckck.qcckckfzsl,qcdbck.qcdbcksl,qcdbck.qcdbckfzsl,bqscrk.bqscrksl,bqscrk.bqscrkfzsl,bqcgrk.bqcgrksl,bqcgrk.bqcgrkfzsl,bqdbrk.bqdbrksl,bqdbrk.bqdbrkfzsl,bqxsck.bqxscksl,bqxsck.bqxsckfzsl,bqckck.bqckcksl,bqckck.bqckckfzsl,bqdbck.bqdbcksl,bqdbck.bqdbckfzsl FROM" & _
                    " (SELECT inv_cpyeb.cpdm,inv_cpyeb.ckdm,sum(qcsl) as qcsl,sum(qcfzsl) as qcfzsl FROM inv_cpyeb WHERE kjnd = ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_cpyeb.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_cpyeb.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_cpyeb.cpdm,inv_cpyeb.ckdm) cpnc" & _
                    " Left join (SELECT inv_rkd.cpdm,inv_rkd.ckdm,sum(inv_rkd.sl) as qcscrksl,sum(inv_rkd.fzsl) as qcscrkfzsl FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_rkd.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_rkd.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_rkd.cpdm,inv_rkd.ckdm) qcscrk ON cpnc.cpdm = qcscrk.cpdm AND cpnc.ckdm = qcscrk.ckdm" & _
                    " Left join (SELECT po_rkd.cpdm,po_rkd.ckdm,sum(po_rkd.sl) as qccgrksl,sum(po_rkd.fzsl) as qccgrkfzsl FROM po_rkd WHERE po_rkd.bdelete = 0 AND TRUNC(po_rkd.rkrq,'mi') >= ? and TRUNC(po_rkd.rkrq,'mi') >= ? and TRUNC(po_rkd.rkrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND po_rkd.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND po_rkd.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY po_rkd.cpdm,po_rkd.ckdm) qccgrk ON cpnc.cpdm = qccgrk.cpdm AND cpnc.ckdm = qccgrk.ckdm" & _
                    " Left join (SELECT inv_dbd.cpdm,inv_dbd.rckdm AS ckdm,sum(inv_dbd.sl) as qcdbrksl,sum(inv_dbd.fzsl) as qcdbrkfzsl FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_dbd.rckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_dbd.rckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_dbd.cpdm,inv_dbd.rckdm) qcdbrk ON cpnc.cpdm = qcdbrk.cpdm AND cpnc.ckdm = qcdbrk.ckdm" & _
                    " Left join (SELECT oe_xsd.cpdm,oe_xsd.ckdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.fzsl) as qcxsckfzsl FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND oe_xsd.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND oe_xsd.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY oe_xsd.cpdm,oe_xsd.ckdm) qcxsck ON cpnc.cpdm = qcxsck.cpdm AND cpnc.ckdm = qcxsck.ckdm" & _
                    " Left join (SELECT inv_ckd.cpdm,inv_ckd.ckdm,sum(inv_ckd.sl) as qcckcksl,sum(inv_ckd.fzsl) as qcckckfzsl FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_ckd.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_ckd.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_ckd.cpdm,inv_ckd.ckdm) qcckck ON cpnc.cpdm = qcckck.cpdm AND cpnc.ckdm = qcckck.ckdm" & _
                    " Left join (SELECT inv_dbd.cpdm,inv_dbd.cckdm AS ckdm,sum(inv_dbd.sl) as qcdbcksl,sum(inv_dbd.fzsl) as qcdbckfzsl FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_dbd.cckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_dbd.cckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_dbd.cpdm,inv_dbd.cckdm) qcdbck ON cpnc.cpdm = qcdbck.cpdm AND cpnc.ckdm = qcdbck.ckdm" & _
                    " Left join (SELECT inv_rkd.cpdm,inv_rkd.ckdm,sum(inv_rkd.sl) as bqscrksl,sum(inv_rkd.fzsl) as bqscrkfzsl FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_rkd.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_rkd.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_rkd.cpdm,inv_rkd.ckdm) bqscrk ON cpnc.cpdm = bqscrk.cpdm AND cpnc.ckdm = bqscrk.ckdm" & _
                    " Left join (SELECT po_rkd.cpdm,po_rkd.ckdm,sum(po_rkd.sl) as bqcgrksl,sum(po_rkd.fzsl) as bqcgrkfzsl FROM po_rkd WHERE po_rkd.bdelete = 0 AND TRUNC(po_rkd.rkrq,'mi') >= ? and TRUNC(po_rkd.rkrq,'mi') >= ? and TRUNC(po_rkd.rkrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND po_rkd.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND po_rkd.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY po_rkd.cpdm,po_rkd.ckdm) bqcgrk ON cpnc.cpdm = bqcgrk.cpdm AND cpnc.ckdm = bqcgrk.ckdm" & _
                    " Left join (SELECT inv_dbd.cpdm,inv_dbd.rckdm AS ckdm,sum(inv_dbd.sl) as bqdbrksl,sum(inv_dbd.fzsl) as bqdbrkfzsl FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_dbd.rckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_dbd.rckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_dbd.cpdm,inv_dbd.rckdm) bqdbrk ON cpnc.cpdm = bqdbrk.cpdm AND cpnc.ckdm = bqdbrk.ckdm" & _
                    " Left join (SELECT oe_xsd.cpdm,oe_xsd.ckdm,sum(oe_xsd.sl) as bqxscksl,sum(oe_xsd.fzsl) as bqxsckfzsl FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND oe_xsd.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND oe_xsd.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY oe_xsd.cpdm,oe_xsd.ckdm) bqxsck ON cpnc.cpdm = bqxsck.cpdm AND cpnc.ckdm = bqxsck.ckdm" & _
                    " Left join (SELECT inv_ckd.cpdm,inv_ckd.ckdm,sum(inv_ckd.sl) as bqckcksl,sum(inv_ckd.fzsl) as bqckckfzsl FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_ckd.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_ckd.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_ckd.cpdm,inv_ckd.ckdm) bqckck ON cpnc.cpdm = bqckck.cpdm AND cpnc.ckdm = bqckck.ckdm" & _
                    " Left join (SELECT inv_dbd.cpdm,inv_dbd.cckdm AS ckdm,sum(inv_dbd.sl) as bqdbcksl,sum(inv_dbd.fzsl) as bqdbckfzsl FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_dbd.cckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_dbd.cckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_dbd.cpdm,inv_dbd.cckdm) bqdbck ON cpnc.cpdm = bqdbck.cpdm AND cpnc.ckdm = bqdbck.ckdm) asfchz LEFT JOIN rc_cpxx ON asfchz.cpdm = rc_cpxx.cpdm LEFT JOIN rc_ckxx ON asfchz.ckdm = rc_ckxx.ckdm) bsfchz WHERE (" & strExpLbdm & ")" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpdmBegin.Text), " and cpdm >= '" & Trim(TxtCpdmBegin.Text) & "' AND cpdm <= '" & Me.TxtCpdmEnd.Text & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpmc.Text), " AND cpmc LIKE '%" & TxtCpmc.Text & "%'", "")
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
            For i = 0 To rcDataset.Tables("cpsfchz").Rows.Count - 1
                Me.ProgressBar1.Value = i
                If rcDataset.Tables("cpsfchz").Rows(i).Item("qcsl") = 0 And rcDataset.Tables("cpsfchz").Rows(i).Item("rksl") = 0 And rcDataset.Tables("cpsfchz").Rows(i).Item("cksl") = 0 And rcDataset.Tables("cpsfchz").Rows(i).Item("jcsl") = 0 Then
                    rcDataset.Tables("cpsfchz").Rows(i).Delete()
                End If
            Next
            Dim rcDataRow As DataRow
            rcDataRow = rcDataset.Tables("cpsfchz").NewRow
            rcDataRow.Item("cpdm") = "合计"
            rcDataRow.Item("qcsl") = dtCpsfcHz.Compute("Sum(qcsl)", "")
            rcDataRow.Item("rksl") = dtCpsfcHz.Compute("Sum(rksl)", "")
            rcDataRow.Item("cksl") = dtCpsfcHz.Compute("Sum(cksl)", "")
            rcDataRow.Item("jcsl") = dtCpsfcHz.Compute("Sum(jcsl)", "")
            rcDataRow.Item("qcfzsl") = dtCpsfcHz.Compute("Sum(qcfzsl)", "")
            rcDataRow.Item("rkfzsl") = dtCpsfcHz.Compute("Sum(rkfzsl)", "")
            rcDataRow.Item("ckfzsl") = dtCpsfcHz.Compute("Sum(ckfzsl)", "")
            rcDataRow.Item("jcfzsl") = dtCpsfcHz.Compute("Sum(jcfzsl)", "")
            rcDataset.Tables("cpsfchz").Rows.Add(rcDataRow)
            '调用表单
            Dim rcFrm As New FrmSlSfcHzz1
            With rcFrm
                .ParaDataSet = rcDataset
                .ParaDataView = New DataView(rcDataset.Tables("cpsfchz"), "TRUE", "cpdm,ckdm", DataViewRowState.CurrentRows)
                .Label2.Text = "日期：" & DtpHzrqBegin.Value & "至" & DtpHzrqEnd.Value
                .Label3.Text = "仓库：" & Trim(Me.TxtCkdmBegin.Text)
                .WindowState = FormWindowState.Maximized
                .MdiParent = Me.MdiParent
                .Show()
            End With
        Else
            '取期初库存、期初入库、期初出库、本期入库、本期出库
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT bsfchz.cpdm,bsfchz.cpmc,bsfchz.dw" & _
                    ",COALESCE(bsfchz.qcsl,0.0)+COALESCE(bsfchz.qcscrksl,0.0)+COALESCE(bsfchz.qccgrksl,0.0)+COALESCE(bsfchz.qcdbrksl,0.0)-COALESCE(bsfchz.qcxscksl,0.0)-COALESCE(bsfchz.qcckcksl,0.0)-COALESCE(bsfchz.qcdbcksl,0.0) as qcsl,COALESCE(bsfchz.qcfzsl,0.0)+COALESCE(bsfchz.qcscrkfzsl,0.0)+COALESCE(bsfchz.qccgrkfzsl,0.0)+COALESCE(bsfchz.qcdbrkfzsl,0.0)-COALESCE(bsfchz.qcxsckfzsl,0.0)-COALESCE(bsfchz.qcckckfzsl,0.0)-COALESCE(bsfchz.qcdbckfzsl,0.0) as qcfzsl" & _
                    ",COALESCE(bsfchz.bqscrksl,0.0) + COALESCE(bsfchz.bqcgrksl,0.0) + COALESCE(bsfchz.bqdbrksl,0.0) AS rksl,COALESCE(bsfchz.bqscrkfzsl,0.0) + COALESCE(bsfchz.bqcgrkfzsl,0.0) + COALESCE(bsfchz.bqdbrkfzsl,0.0) AS rkfzsl" & _
                    ",COALESCE(bsfchz.bqxscksl,0.0) + COALESCE(bsfchz.bqckcksl,0.0) + COALESCE(bsfchz.bqdbcksl,0.0) AS cksl,COALESCE(bsfchz.bqxsckfzsl,0.0) + COALESCE(bsfchz.bqckckfzsl,0.0) + COALESCE(bsfchz.bqdbckfzsl,0.0) AS ckfzsl" & _
                    ",COALESCE(bsfchz.qcsl,0.0)+COALESCE(bsfchz.qcscrksl,0.0)+COALESCE(bsfchz.qccgrksl,0.0)+COALESCE(bsfchz.qcdbrksl,0.0)-COALESCE(bsfchz.qcxscksl,0.0)-COALESCE(bsfchz.qcckcksl,0.0)-COALESCE(bsfchz.qcdbcksl,0.0) + COALESCE(bsfchz.bqscrksl,0.0)+ COALESCE(bsfchz.bqcgrksl,0.0)+ COALESCE(bsfchz.bqdbrksl,0.0) - COALESCE(bsfchz.bqxscksl,0.0) - COALESCE(bsfchz.bqckcksl,0.0) - COALESCE(bsfchz.bqdbcksl,0.0) AS jcsl,COALESCE(bsfchz.qcfzsl,0.0)+COALESCE(bsfchz.qcscrkfzsl,0.0)+COALESCE(bsfchz.qccgrkfzsl,0.0)+COALESCE(bsfchz.qcdbrkfzsl,0.0)-COALESCE(bsfchz.qcxsckfzsl,0.0)-COALESCE(bsfchz.qcckckfzsl,0.0)-COALESCE(bsfchz.qcdbckfzsl,0.0) + COALESCE(bsfchz.bqscrkfzsl,0.0)+ COALESCE(bsfchz.bqcgrkfzsl,0.0)+ COALESCE(bsfchz.bqdbrkfzsl,0.0) - COALESCE(bsfchz.bqxsckfzsl,0.0) - COALESCE(bsfchz.bqckckfzsl,0.0) - COALESCE(bsfchz.bqdbckfzsl,0.0) AS jcfzsl FROM" & _
                    " (SELECT asfchz.*,rc_cpxx.cpmc,rc_cpxx.dw,rc_cpxx.lbdm FROM" & _
                    " (SELECT cpnc.cpdm,cpnc.qcsl,cpnc.qcfzsl,qcscrk.qcscrksl,qcscrk.qcscrkfzsl,qccgrk.qccgrksl,qccgrk.qccgrkfzsl,qcdbrk.qcdbrksl,qcdbrk.qcdbrkfzsl,qcxsck.qcxscksl,qcxsck.qcxsckfzsl,qcckck.qcckcksl,qcckck.qcckckfzsl,qcdbck.qcdbcksl,qcdbck.qcdbckfzsl,bqscrk.bqscrksl,bqscrk.bqscrkfzsl,bqcgrk.bqcgrksl,bqcgrk.bqcgrkfzsl,bqdbrk.bqdbrksl,bqdbrk.bqdbrkfzsl,bqxsck.bqxscksl,bqxsck.bqxsckfzsl,bqckck.bqckcksl,bqckck.bqckckfzsl,bqdbck.bqdbcksl,bqdbck.bqdbckfzsl FROM" & _
                    " (SELECT inv_cpyeb.cpdm,sum(qcsl) as qcsl,sum(qcfzsl) as qcfzsl FROM inv_cpyeb WHERE kjnd = ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_cpyeb.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_cpyeb.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_cpyeb.cpdm) cpnc" & _
                    " Left join (SELECT inv_rkd.cpdm,sum(inv_rkd.sl) as qcscrksl,sum(inv_rkd.fzsl) as qcscrkfzsl FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_rkd.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_rkd.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_rkd.cpdm) qcscrk ON cpnc.cpdm = qcscrk.cpdm" & _
                    " Left join (SELECT po_rkd.cpdm,sum(po_rkd.sl) as qccgrksl,sum(po_rkd.fzsl) as qccgrkfzsl FROM po_rkd WHERE po_rkd.bdelete = 0 AND TRUNC(po_rkd.rkrq,'mi') >= ? and TRUNC(po_rkd.rkrq,'mi') >= ? and TRUNC(po_rkd.rkrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND po_rkd.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND po_rkd.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY po_rkd.cpdm) qccgrk ON cpnc.cpdm = qccgrk.cpdm" & _
                    " Left join (SELECT inv_dbd.cpdm,sum(inv_dbd.sl) as qcdbrksl,sum(inv_dbd.fzsl) as qcdbrkfzsl FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_dbd.rckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_dbd.rckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_dbd.cpdm) qcdbrk ON cpnc.cpdm = qcdbrk.cpdm" & _
                    " Left join (SELECT oe_xsd.cpdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.fzsl) as qcxsckfzsl FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND oe_xsd.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND oe_xsd.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY oe_xsd.cpdm) qcxsck ON cpnc.cpdm = qcxsck.cpdm" & _
                    " Left join (SELECT inv_ckd.cpdm,sum(inv_ckd.sl) as qcckcksl,sum(inv_ckd.fzsl) as qcckckfzsl FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_ckd.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_ckd.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_ckd.cpdm) qcckck ON cpnc.cpdm = qcckck.cpdm" & _
                    " Left join (SELECT inv_dbd.cpdm,sum(inv_dbd.sl) as qcdbcksl,sum(inv_dbd.fzsl) as qcdbckfzsl FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_dbd.cckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_dbd.cckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_dbd.cpdm) qcdbck ON cpnc.cpdm = qcdbck.cpdm" & _
                    " Left join (SELECT inv_rkd.cpdm,sum(inv_rkd.sl) as bqscrksl,sum(inv_rkd.fzsl) as bqscrkfzsl FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_rkd.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_rkd.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_rkd.cpdm) bqscrk ON cpnc.cpdm = bqscrk.cpdm" & _
                    " Left join (SELECT po_rkd.cpdm,sum(po_rkd.sl) as bqcgrksl,sum(po_rkd.fzsl) as bqcgrkfzsl FROM po_rkd WHERE po_rkd.bdelete = 0 AND TRUNC(po_rkd.rkrq,'mi') >= ? and TRUNC(po_rkd.rkrq,'mi') >= ? and TRUNC(po_rkd.rkrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND po_rkd.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND po_rkd.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY po_rkd.cpdm) bqcgrk ON cpnc.cpdm = bqcgrk.cpdm" & _
                    " Left join (SELECT inv_dbd.cpdm,sum(inv_dbd.sl) as bqdbrksl,sum(inv_dbd.fzsl) as bqdbrkfzsl FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_dbd.rckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_dbd.rckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_dbd.cpdm) bqdbrk ON cpnc.cpdm = bqdbrk.cpdm" & _
                    " Left join (SELECT oe_xsd.cpdm,sum(oe_xsd.sl) as bqxscksl,sum(oe_xsd.fzsl) as bqxsckfzsl FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND oe_xsd.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND oe_xsd.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY oe_xsd.cpdm) bqxsck ON cpnc.cpdm = bqxsck.cpdm" & _
                    " Left join (SELECT inv_ckd.cpdm,sum(inv_ckd.sl) as bqckcksl,sum(inv_ckd.fzsl) as bqckckfzsl FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_ckd.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_ckd.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_ckd.cpdm) bqckck ON cpnc.cpdm = bqckck.cpdm" & _
                    " Left join (SELECT inv_dbd.cpdm,sum(inv_dbd.sl) as bqdbcksl,sum(inv_dbd.fzsl) as bqdbckfzsl FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_dbd.cckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_dbd.cckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_dbd.cpdm) bqdbck ON cpnc.cpdm = bqdbck.cpdm) asfchz LEFT JOIN rc_cpxx ON asfchz.cpdm = rc_cpxx.cpdm) bsfchz WHERE (" & strExpLbdm & ")" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpdmBegin.Text), " and cpdm LIKE '" & Trim(TxtCpdmBegin.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpmc.Text), " AND cpmc LIKE '%" & TxtCpmc.Text & "%'", "")
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
            For i = 0 To rcDataset.Tables("cpsfchz").Rows.Count - 1
                Me.ProgressBar1.Value = i
                If rcDataset.Tables("cpsfchz").Rows(i).Item("qcsl") = 0 And rcDataset.Tables("cpsfchz").Rows(i).Item("rksl") = 0 And rcDataset.Tables("cpsfchz").Rows(i).Item("cksl") = 0 And rcDataset.Tables("cpsfchz").Rows(i).Item("jcsl") = 0 Then
                    rcDataset.Tables("cpsfchz").Rows(i).Delete()
                End If
            Next
            Dim rcDataRow As DataRow
            rcDataRow = rcDataset.Tables("cpsfchz").NewRow
            rcDataRow.Item("cpdm") = "合计"
            rcDataRow.Item("qcsl") = dtCpsfcHz.Compute("Sum(qcsl)", "")
            rcDataRow.Item("rksl") = dtCpsfcHz.Compute("Sum(rksl)", "")
            rcDataRow.Item("cksl") = dtCpsfcHz.Compute("Sum(cksl)", "")
            rcDataRow.Item("jcsl") = dtCpsfcHz.Compute("Sum(jcsl)", "")
            rcDataRow.Item("qcfzsl") = dtCpsfcHz.Compute("Sum(qcfzsl)", "")
            rcDataRow.Item("rkfzsl") = dtCpsfcHz.Compute("Sum(rkfzsl)", "")
            rcDataRow.Item("ckfzsl") = dtCpsfcHz.Compute("Sum(ckfzsl)", "")
            rcDataRow.Item("jcfzsl") = dtCpsfcHz.Compute("Sum(jcfzsl)", "")
            rcDataset.Tables("cpsfchz").Rows.Add(rcDataRow)
            '调用表单
            Dim rcFrm As New FrmSlSfcHzz2
            With rcFrm
                .ParaDataSet = rcDataset
                .ParaDataView = New DataView(rcDataset.Tables("cpsfchz"), "TRUE", "cpdm", DataViewRowState.CurrentRows)
                .Label2.Text = DtpHzrqBegin.Value & "至" & DtpHzrqEnd.Value
                '.Label3.Text = "仓库：" & Trim(Me.TxtCkdm.Text)
                .WindowState = FormWindowState.Maximized
                .MdiParent = Me.MdiParent
                .Show()
            End With
        End If
    End Sub

End Class