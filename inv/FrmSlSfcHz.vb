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
                    ",bsfchz.qcsl,bsfchz.qcfzsl,bsfchz.rksl,bsfchz.rkfzsl,bsfchz.cksl,bsfchz.ckfzsl,bsfchz.jcsl,bsfchz.jcfzsl FROM" & _
                    " (SELECT asfchz.*,rc_cpxx.cpmc,rc_cpxx.dw,rc_cpxx.lbdm,rc_ckxx.ckmc FROM" & _
                    " (SELECT cpdm,ckdm,SUM(qcsl) AS qcsl,SUM(qcfzsl) AS qcfzsl,SUM(rksl) AS rksl,SUM(rkfzsl) AS rkfzsl,SUM(cksl) AS cksl,SUM(ckfzsl) AS ckfzsl,SUM(qcsl)+SUM(rksl)-SUM(cksl) AS jcsl,SUM(qcfzsl)+SUM(rkfzsl)-SUM(ckfzsl) AS jcfzsl FROM (" & _
                    " SELECT inv_cpyeb.cpdm,inv_cpyeb.ckdm,SUM(qcsl) AS qcsl,SUM(qcfzsl) AS qcfzsl,0.0 AS rksl,0.0 AS rkfzsl,0.0 AS cksl,0.0 AS ckfzsl FROM inv_cpyeb WHERE kjnd = ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_cpyeb.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_cpyeb.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_cpyeb.cpdm,inv_cpyeb.ckdm" & _
                    " UNION ALL SELECT inv_rkd.cpdm,inv_rkd.ckdm,SUM(inv_rkd.sl),SUM(inv_rkd.fzsl),0.0,0.0,0.0,0.0 FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_rkd.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_rkd.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_rkd.cpdm,inv_rkd.ckdm" & _
                    " UNION ALL SELECT po_rkd.cpdm,po_rkd.ckdm,SUM(po_rkd.sl),SUM(po_rkd.fzsl),0.0,0.0,0.0,0.0 FROM po_rkd WHERE po_rkd.bdelete = 0 AND TRUNC(po_rkd.rkrq,'mi') >= ? and TRUNC(po_rkd.rkrq,'mi') >= ? and TRUNC(po_rkd.rkrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND po_rkd.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND po_rkd.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY po_rkd.cpdm,po_rkd.ckdm" & _
                    " UNION ALL SELECT inv_dbd.cpdm,inv_dbd.rckdm,SUM(inv_dbd.sl),SUM(inv_dbd.fzsl),0.0,0.0,0.0,0.0 FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_dbd.rckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_dbd.rckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_dbd.cpdm,inv_dbd.rckdm" & _
                    " UNION ALL SELECT oe_xsd.cpdm,oe_xsd.ckdm,-SUM(oe_xsd.sl),-SUM(oe_xsd.fzsl),0.0,0.0,0.0,0.0 FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND oe_xsd.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND oe_xsd.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY oe_xsd.cpdm,oe_xsd.ckdm" & _
                    " UNION ALL SELECT inv_ckd.cpdm,inv_ckd.ckdm,-SUM(inv_ckd.sl),-SUM(inv_ckd.fzsl),0.0,0.0,0.0,0.0 FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_ckd.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_ckd.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_ckd.cpdm,inv_ckd.ckdm" & _
                    " UNION ALL SELECT inv_dbd.cpdm,inv_dbd.cckdm,-SUM(inv_dbd.sl),-SUM(inv_dbd.fzsl),0.0,0.0,0.0,0.0 FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_dbd.cckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_dbd.cckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_dbd.cpdm,inv_dbd.cckdm" & _
                    " UNION ALL SELECT inv_rkd.cpdm,inv_rkd.ckdm,0.0,0.0,SUM(inv_rkd.sl),SUM(inv_rkd.fzsl),0.0,0.0 FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_rkd.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_rkd.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_rkd.cpdm,inv_rkd.ckdm" & _
                    " UNION ALL SELECT po_rkd.cpdm,po_rkd.ckdm,0.0,0.0,SUM(po_rkd.sl),SUM(po_rkd.fzsl),0.0,0.0 FROM po_rkd WHERE po_rkd.bdelete = 0 AND TRUNC(po_rkd.rkrq,'mi') >= ? and TRUNC(po_rkd.rkrq,'mi') >= ? and TRUNC(po_rkd.rkrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND po_rkd.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND po_rkd.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY po_rkd.cpdm,po_rkd.ckdm" & _
                    " UNION ALL SELECT inv_dbd.cpdm,inv_dbd.rckdm,0.0,0.0,SUM(inv_dbd.sl),SUM(inv_dbd.fzsl),0.0,0.0 FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_dbd.rckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_dbd.rckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_dbd.cpdm,inv_dbd.rckdm" & _
                    " UNION ALL SELECT oe_xsd.cpdm,oe_xsd.ckdm,0.0,0.0,0.0,0.0,SUM(oe_xsd.sl),SUM(oe_xsd.fzsl) FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND oe_xsd.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND oe_xsd.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY oe_xsd.cpdm,oe_xsd.ckdm" & _
                    " UNION ALL SELECT inv_ckd.cpdm,inv_ckd.ckdm,0.0,0.0,0.0,0.0,SUM(inv_ckd.sl),SUM(inv_ckd.fzsl) FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_ckd.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_ckd.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_ckd.cpdm,inv_ckd.ckdm" & _
                    " UNION ALL SELECT inv_dbd.cpdm,inv_dbd.cckdm,0.0,0.0,0.0,0.0,SUM(inv_dbd.sl),SUM(inv_dbd.fzsl) FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_dbd.cckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_dbd.cckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_dbd.cpdm,inv_dbd.cckdm" & _
                    " ) GROUP BY cpdm,ckdm) asfchz LEFT JOIN rc_cpxx ON asfchz.cpdm = rc_cpxx.cpdm LEFT JOIN rc_ckxx ON asfchz.ckdm = rc_ckxx.ckdm) bsfchz WHERE (" & strExpLbdm & ")" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpdmBegin.Text), " and cpdm >= '" & Trim(TxtCpdmBegin.Text) & "' AND cpdm <= '" & Me.TxtCpdmEnd.Text & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpmc.Text), " AND cpmc LIKE '%" & TxtCpmc.Text & "%'", "")
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
                    ",bsfchz.qcsl,bsfchz.qcfzsl,bsfchz.rksl,bsfchz.rkfzsl,bsfchz.cksl,bsfchz.ckfzsl,bsfchz.jcsl,bsfchz.jcfzsl FROM" & _
                    " (SELECT asfchz.*,rc_cpxx.cpmc,rc_cpxx.dw,rc_cpxx.lbdm FROM" & _
                    " (SELECT cpdm,SUM(qcsl) AS qcsl,SUM(qcfzsl) AS qcfzsl,SUM(rksl) AS rksl,SUM(rkfzsl) AS rkfzsl,SUM(cksl) AS cksl,SUM(ckfzsl) AS ckfzsl,SUM(qcsl)+SUM(rksl)-SUM(cksl) AS jcsl,SUM(qcfzsl)+SUM(rkfzsl)-SUM(ckfzsl) AS jcfzsl FROM (" & _
                    " SELECT inv_cpyeb.cpdm,SUM(qcsl) AS qcsl,SUM(qcfzsl) AS qcfzsl,0.0 AS rksl,0.0 AS rkfzsl,0.0 AS cksl,0.0 AS ckfzsl FROM inv_cpyeb WHERE kjnd = ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_cpyeb.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_cpyeb.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_cpyeb.cpdm" & _
                    " UNION ALL SELECT inv_rkd.cpdm,SUM(inv_rkd.sl),SUM(inv_rkd.fzsl),0.0,0.0,0.0,0.0 FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_rkd.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_rkd.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_rkd.cpdm" & _
                    " UNION ALL SELECT po_rkd.cpdm,SUM(po_rkd.sl),SUM(po_rkd.fzsl),0.0,0.0,0.0,0.0 FROM po_rkd WHERE po_rkd.bdelete = 0 AND TRUNC(po_rkd.rkrq,'mi') >= ? and TRUNC(po_rkd.rkrq,'mi') >= ? and TRUNC(po_rkd.rkrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND po_rkd.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND po_rkd.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY po_rkd.cpdm" & _
                    " UNION ALL SELECT inv_dbd.cpdm,SUM(inv_dbd.sl),SUM(inv_dbd.fzsl),0.0,0.0,0.0,0.0 FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_dbd.rckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_dbd.rckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_dbd.cpdm" & _
                    " UNION ALL SELECT oe_xsd.cpdm,-SUM(oe_xsd.sl),-SUM(oe_xsd.fzsl),0.0,0.0,0.0,0.0 FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND oe_xsd.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND oe_xsd.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY oe_xsd.cpdm" & _
                    " UNION ALL SELECT inv_ckd.cpdm,-SUM(inv_ckd.sl),-SUM(inv_ckd.fzsl),0.0,0.0,0.0,0.0 FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_ckd.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_ckd.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_ckd.cpdm" & _
                    " UNION ALL SELECT inv_dbd.cpdm,-SUM(inv_dbd.sl),-SUM(inv_dbd.fzsl),0.0,0.0,0.0,0.0 FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_dbd.cckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_dbd.cckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_dbd.cpdm" & _
                    " UNION ALL SELECT inv_rkd.cpdm,0.0,0.0,SUM(inv_rkd.sl),SUM(inv_rkd.fzsl),0.0,0.0 FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') >= ? and TRUNC(inv_rkd.rkrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_rkd.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_rkd.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_rkd.cpdm" & _
                    " UNION ALL SELECT po_rkd.cpdm,0.0,0.0,SUM(po_rkd.sl),SUM(po_rkd.fzsl),0.0,0.0 FROM po_rkd WHERE po_rkd.bdelete = 0 AND TRUNC(po_rkd.rkrq,'mi') >= ? and TRUNC(po_rkd.rkrq,'mi') >= ? and TRUNC(po_rkd.rkrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND po_rkd.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND po_rkd.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY po_rkd.cpdm" & _
                    " UNION ALL SELECT inv_dbd.cpdm,0.0,0.0,SUM(inv_dbd.sl),SUM(inv_dbd.fzsl),0.0,0.0 FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_dbd.rckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_dbd.rckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_dbd.cpdm" & _
                    " UNION ALL SELECT oe_xsd.cpdm,0.0,0.0,0.0,0.0,SUM(oe_xsd.sl),SUM(oe_xsd.fzsl) FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND oe_xsd.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND oe_xsd.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY oe_xsd.cpdm" & _
                    " UNION ALL SELECT inv_ckd.cpdm,0.0,0.0,0.0,0.0,SUM(inv_ckd.sl),SUM(inv_ckd.fzsl) FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') >= ? and TRUNC(inv_ckd.ckrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_ckd.ckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_ckd.ckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_ckd.cpdm" & _
                    " UNION ALL SELECT inv_dbd.cpdm,0.0,0.0,0.0,0.0,SUM(inv_dbd.sl),SUM(inv_dbd.fzsl) FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdmBegin.Text), " AND inv_dbd.cckdm >='" & Me.TxtCkdmBegin.Text & "' AND inv_dbd.cckdm <= '" & Me.TxtCkdmEnd.Text & "'", "") & " GROUP BY inv_dbd.cpdm" & _
                    " ) GROUP BY cpdm) asfchz LEFT JOIN rc_cpxx ON asfchz.cpdm = rc_cpxx.cpdm) bsfchz WHERE (" & strExpLbdm & ")" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpdmBegin.Text), " and cpdm LIKE '" & Trim(TxtCpdmBegin.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpmc.Text), " AND cpmc LIKE '%" & TxtCpmc.Text & "%'", "")
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