Imports System.Data.OleDb

Public Class FrmPhSfcHz
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable
    ReadOnly dtCpsfcHz As New DataTable("cpsfchz")

    Private Sub FrmPhSfcHz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        DtpHzrqBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpHzrqEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '创建datatable
        dtCpsfcHz.Columns.Add("cpdm", Type.GetType("System.String"))
        dtCpsfcHz.Columns.Add("cpmc", Type.GetType("System.String"))
        dtCpsfcHz.Columns.Add("dw", Type.GetType("System.String"))
        dtCpsfcHz.Columns.Add("pihao", Type.GetType("System.String"))
        dtCpsfcHz.Columns.Add("ckdm", Type.GetType("System.String"))
        dtCpsfcHz.Columns.Add("ckmc", Type.GetType("System.String"))
        dtCpsfcHz.Columns.Add("rksl", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("rkfzsl", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("rkje", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("cksl", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("ckfzsl", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("ckje", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("jcsl", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("jcfzsl", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("jcje", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtCpsfcHz)
        With dtCpsfcHz
            .Columns("cpdm").DefaultValue = ""
            .Columns("pihao").DefaultValue = ""
            .Columns("ckdm").DefaultValue = ""
            .Columns("rksl").DefaultValue = 0.0
            .Columns("rkfzsl").DefaultValue = 0.0
            .Columns("rkje").DefaultValue = 0.0
            .Columns("cksl").DefaultValue = 0.0
            .Columns("ckfzsl").DefaultValue = 0.0
            .Columns("ckje").DefaultValue = 0.0
            .Columns("jcsl").DefaultValue = 0.0
            .Columns("jcfzsl").DefaultValue = 0.0
            .Columns("jcje").DefaultValue = 0.0
        End With
    End Sub

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpHzrqBegin.KeyPress, DtpHzrqEnd.KeyPress, TxtLbdm.KeyPress, TxtCkdm.KeyPress, TxtCpdm.KeyPress, TxtCpmc.KeyPress
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

#Region "物料编码事件"

    Private Sub TxtCpdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCpdm.KeyDown
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
                        Me.TxtCpdm.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtCpdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCpdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtCpdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT cpdm,cpmc,dw,kuwei FROM rc_cpxx WHERE (cpdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_cpxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_cpxx").Rows.Count = 0 Then
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
        If Me.rdoCk.Checked Then
            '取入库数据
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT cpsfchzb.cpdm,rc_cpxx.cpmc,rc_cpxx.dw,cpsfchzb.pihao,cpsfchzb.ckdm,rc_ckxx.ckmc,cpsfchzb.rksl,cpsfchzb.rkfzsl,cpsfchzb.rkje,cpsfchzb.cksl,cpsfchzb.ckfzsl,cpsfchzb.ckje FROM (SELECT cpsfchza.cpdm,cpsfchza.pihao,cpsfchza.ckdm,SUM(rksl) AS rksl,SUM(rkfzsl) AS rkfzsl,SUM(rkje) AS rkje,SUM(cksl) AS cksl,SUM(ckfzsl) AS ckfzsl,SUM(ckje) AS ckje" & _
                    " FROM ((SELECT inv_rkd.cpdm,inv_rkd.scph AS pihao,inv_rkd.ckdm,SUM(inv_rkd.sl) As rksl,SUM(inv_rkd.fzsl) as rkfzsl,SUM(inv_rkd.je) As rkje,0.0 As cksl,0.0 AS ckfzsl,0.0 As ckje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND inv_rkd.rkrq <= ? AND inv_rkd.rkrq >= ? AND NOT scph IS NULL" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_rkd.cpdm,inv_rkd.scph,inv_rkd.ckdm) UNION" & _
                    " (SELECT po_rkd.cpdm,po_rkd.pihao,po_rkd.ckdm,SUM(po_rkd.sl) As rksl,SUM(po_rkd.fzsl) as rkfzsl,SUM(po_rkd.je) As rkje,0.0 As cksl,0.0 AS ckfzsl,0.0 As ckje FROM po_rkd WHERE po_rkd.rkrq <= ? AND po_rkd.rkrq >= ? AND NOT pihao IS NULL" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND po_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY po_rkd.cpdm,po_rkd.pihao,po_rkd.ckdm) UNION" & _
                    " (SELECT inv_dbd.cpdm,inv_dbd.scph AS pihao,inv_dbd.rckdm AS ckdm,SUM(inv_dbd.sl) As rksl,SUM(inv_dbd.fzsl) as rkfzsl,SUM(inv_dbd.je) As rkje,0.0 As cksl,0.0 AS ckfzsl,0.0 As ckje FROM inv_dbd WHERE inv_dbd.dbrq <= ? AND inv_dbd.dbrq >= ? AND NOT scph IS NULL" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.rckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_dbd.cpdm,inv_dbd.scph,inv_dbd.rckdm)) cpsfchza GROUP BY cpsfchza.cpdm,cpsfchza.pihao,cpsfchza.ckdm) cpsfchzb LEFT JOIN rc_cpxx ON rc_cpxx.cpdm = cpsfchzb.cpdm LEFT JOIN rc_ckxx ON rc_ckxx.ckdm = cpsfchzb.ckdm WHERE (" & strExpLbdm & ")" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND rc_cpxx.lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " AND cpsfchzb.cpdm LIKE '" & Trim(TxtCpdm.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpmc.Text), " AND cpsfchzb.cpmc LIKE '%" & TxtCpmc.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtPiHao.Text), " AND cpsfchzb.pihao LIKE '%" & Me.TxtPiHao.Text & "%'", "")
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
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
                For i = 0 To rcDataset.Tables("cpsfchz").Rows.Count - 1
                    '取出库数据
                    Try
                        rcOleDbConn.Open()
                        rcOleDbCommand.Connection = rcOleDbConn
                        rcOleDbCommand.CommandTimeout = 300
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT cpsfchza.cpdm,cpsfchza.pihao,cpsfchza.ckdm,COALESCE(SUM(cksl),0.0) AS cksl,COALESCE(SUM(ckfzsl),0.0) AS ckfzsl,COALESCE(SUM(ckje),0.0) AS ckje" & _
                            " FROM ((SELECT inv_ckd.cpdm,inv_ckd.scph AS pihao,inv_ckd.ckdm,SUM(inv_ckd.sl) As cksl,SUM(inv_ckd.fzsl) as ckfzsl,SUM(inv_ckd.je) As ckje FROM inv_ckd WHERE inv_ckd.cpdm = ? AND inv_ckd.scph = ? AND inv_ckd.ckdm = ? GROUP BY inv_ckd.cpdm,inv_ckd.scph,inv_ckd.ckdm) UNION" & _
                            " (SELECT oe_xsd.cpdm,oe_xsd.pihao,oe_xsd.ckdm,SUM(oe_xsd.sl) As cksl,SUM(oe_xsd.fzsl) as crkfzsl,SUM(oe_xsd.je) As ckje FROM oe_xsd WHERE oe_xsd.cpdm = ? AND oe_xsd.pihao = ? AND oe_xsd.ckdm = ? GROUP BY oe_xsd.cpdm,oe_xsd.pihao,oe_xsd.ckdm) UNION" & _
                            " (SELECT inv_dbd.cpdm,inv_dbd.scph AS pihao,inv_dbd.cckdm AS ckdm,SUM(inv_dbd.sl) As cksl,SUM(inv_dbd.fzsl) as ckfzsl,SUM(inv_dbd.je) As ckje FROM inv_dbd WHERE inv_dbd.cpdm = ? AND inv_dbd.scph = ? AND inv_dbd.cckdm = ? GROUP BY inv_dbd.cpdm,inv_dbd.scph,inv_dbd.cckdm)) cpsfchza GROUP BY cpsfchza.cpdm,cpsfchza.pihao,cpsfchza.ckdm"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("cpsfchz").Rows(i).Item("cpdm")
                        rcOleDbCommand.Parameters.Add("@pihao", OleDbType.VarChar, 20).Value = rcDataset.Tables("cpsfchz").Rows(i).Item("pihao")
                        rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("cpsfchz").Rows(i).Item("ckdm")
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("cpsfchz").Rows(i).Item("cpdm")
                        rcOleDbCommand.Parameters.Add("@pihao", OleDbType.VarChar, 20).Value = rcDataset.Tables("cpsfchz").Rows(i).Item("pihao")
                        rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("cpsfchz").Rows(i).Item("ckdm")
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("cpsfchz").Rows(i).Item("cpdm")
                        rcOleDbCommand.Parameters.Add("@pihao", OleDbType.VarChar, 20).Value = rcDataset.Tables("cpsfchz").Rows(i).Item("pihao")
                        rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("cpsfchz").Rows(i).Item("ckdm")
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("cpsfchz_ck") IsNot Nothing Then
                            rcDataset.Tables("cpsfchz_ck").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "cpsfchz_ck")
                    Catch ex As Exception
                        MsgBox("程序错误2。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                    If rcDataset.Tables("cpsfchz_ck").Rows.Count > 0 Then
                        rcDataset.Tables("cpsfchz").Rows(i).Item("cksl") = rcDataset.Tables("cpsfchz_ck").Rows(0).Item("cksl")
                        rcDataset.Tables("cpsfchz").Rows(i).Item("ckfzsl") = rcDataset.Tables("cpsfchz_ck").Rows(0).Item("ckfzsl")
                        rcDataset.Tables("cpsfchz").Rows(i).Item("ckje") = rcDataset.Tables("cpsfchz_ck").Rows(0).Item("ckje")
                    End If
                Next
            End If
            If Me.CheckBox1.Checked Then
                For i = 0 To rcDataset.Tables("cpsfchz").Rows.Count - 1
                    Me.ProgressBar1.Value = i
                    If rcDataset.Tables("cpsfchz").Rows(i).Item("rksl") = 0 And rcDataset.Tables("cpsfchz").Rows(i).Item("cksl") = 0 And rcDataset.Tables("cpsfchz").Rows(i).Item("jcsl") = 0 Then
                        rcDataset.Tables("cpsfchz").Rows(i).Delete()
                    End If
                Next
            End If
            Dim rcDataRow As DataRow
            rcDataRow = rcDataset.Tables("cpsfchz").NewRow
            rcDataRow.Item("cpdm") = "合计"
            rcDataRow.Item("rksl") = dtCpsfcHz.Compute("Sum(rksl)", "")
            rcDataRow.Item("rkfzsl") = dtCpsfcHz.Compute("Sum(rkfzsl)", "")
            rcDataRow.Item("rkje") = dtCpsfcHz.Compute("Sum(rkje)", "")
            rcDataRow.Item("cksl") = dtCpsfcHz.Compute("Sum(cksl)", "")
            rcDataRow.Item("ckfzsl") = dtCpsfcHz.Compute("Sum(ckfzsl)", "")
            rcDataRow.Item("ckje") = dtCpsfcHz.Compute("Sum(ckje)", "")
            rcDataRow.Item("jcsl") = dtCpsfcHz.Compute("Sum(jcsl)", "")
            rcDataRow.Item("jcfzsl") = dtCpsfcHz.Compute("Sum(jcfzsl)", "")
            rcDataRow.Item("jcje") = dtCpsfcHz.Compute("Sum(jcje)", "")
            rcDataset.Tables("cpsfchz").Rows.Add(rcDataRow)

            '调用表单
            Dim rcFrm As New FrmPhSfcHzz1
            With rcFrm
                .ParaDataSet = rcDataset
                .ParaDataView = New DataView(rcDataset.Tables("cpsfchz"), "TRUE", "cpdm,pihao,ckdm", DataViewRowState.CurrentRows)
                .Label2.Text = DtpHzrqBegin.Value & "至" & DtpHzrqEnd.Value
                .Label3.Text = "仓库：" & Trim(Me.TxtCkdm.Text)
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
                rcOleDbCommand.CommandText = "SELECT bsfchz.cpdm,bsfchz.cpmc,bsfchz.dw,COALESCE(bsfchz.qcsl,0.0)+COALESCE(bsfchz.qcscrksl,0.0)+COALESCE(bsfchz.qccgrksl,0.0)+COALESCE(bsfchz.qcdbrksl,0.0)-COALESCE(bsfchz.qcxscksl,0.0)-COALESCE(bsfchz.qcckcksl,0.0)-COALESCE(bsfchz.qcdbcksl,0.0) as qcsl,COALESCE(bsfchz.qcje,0.0)+COALESCE(bsfchz.qcscrkje,0.0)+COALESCE(bsfchz.qccgrkje,0.0)+COALESCE(bsfchz.qcdbrkje,0.0)-COALESCE(bsfchz.qcxsckje,0.0)-COALESCE(bsfchz.qcckckje,0.0)-COALESCE(bsfchz.qcdbckje,0.0) as qcje,COALESCE(bsfchz.bqscrksl,0.0) + COALESCE(bsfchz.bqcgrksl,0.0) + COALESCE(bsfchz.bqdbrksl,0.0) AS rksl,COALESCE(bsfchz.bqscrkje,0.0) +COALESCE(bsfchz.bqcgrkje,0.0) +COALESCE(bsfchz.bqdbrkje,0.0) AS rkje,COALESCE(bsfchz.bqxscksl,0.0) + COALESCE(bsfchz.bqckcksl,0.0) + COALESCE(bsfchz.bqdbcksl,0.0) AS cksl,COALESCE(bsfchz.bqxsckje,0.0)+COALESCE(bsfchz.bqckckje,0.0)+COALESCE(bsfchz.bqdbckje,0.0) AS ckje,COALESCE(bsfchz.qcsl,0.0)+COALESCE(bsfchz.qcscrksl,0.0)+COALESCE(bsfchz.qccgrksl,0.0)+COALESCE(bsfchz.qcdbrksl,0.0)-COALESCE(bsfchz.qcxscksl,0.0)-COALESCE(bsfchz.qcckcksl,0.0)-COALESCE(bsfchz.qcdbcksl,0.0) + COALESCE(bsfchz.bqscrksl,0.0)+ COALESCE(bsfchz.bqcgrksl,0.0)+ COALESCE(bsfchz.bqdbrksl,0.0) - COALESCE(bsfchz.bqxscksl,0.0) - COALESCE(bsfchz.bqckcksl,0.0) - COALESCE(bsfchz.bqdbcksl,0.0) AS jcsl,COALESCE(bsfchz.qcje,0.0)+COALESCE(bsfchz.qcscrkje,0.0)+COALESCE(bsfchz.qccgrkje,0.0)+COALESCE(bsfchz.qcdbrkje,0.0)-COALESCE(bsfchz.qcxsckje,0.0)-COALESCE(bsfchz.qcckckje,0.0)-COALESCE(bsfchz.qcdbckje,0.0)+ COALESCE(bsfchz.bqscrkje,0.0)+ COALESCE(bsfchz.bqcgrkje,0.0)+ COALESCE(bsfchz.bqdbrkje,0.0) - COALESCE(bsfchz.bqxsckje,0.0)- COALESCE(bsfchz.bqckckje,0.0)- COALESCE(bsfchz.bqdbckje,0.0) AS jcje FROM" & _
                    " (SELECT asfchz.*,rc_cpxx.cpmc,rc_cpxx.dw,rc_cpxx.lbdm FROM" & _
                    " (SELECT cpnc.cpdm,cpnc.qcsl,cpnc.qcje,qcscrk.qcscrksl,qcscrk.qcscrkje,qccgrk.qccgrksl,qccgrk.qccgrkje,qcdbrk.qcdbrksl,qcdbrk.qcdbrkje,qcxsck.qcxscksl,qcxsck.qcxsckje,qcckck.qcckcksl,qcckck.qcckckje,qcdbck.qcdbcksl,qcdbck.qcdbckje,bqscrk.bqscrksl,bqscrk.bqscrkje,bqcgrk.bqcgrksl,bqcgrk.bqcgrkje,bqdbrk.bqdbrksl,bqdbrk.bqdbrkje,bqxsck.bqxscksl,bqxsck.bqxsckje,bqckck.bqckcksl,bqckck.bqckckje,bqdbck.bqdbcksl,bqdbck.bqdbckje FROM" & _
                    " (SELECT inv_cpyeb.cpdm,sum(qcsl) as qcsl,sum(qcje) as qcje FROM inv_cpyeb WHERE kjnd = ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_cpyeb.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_cpyeb.cpdm) cpnc" & _
                    " Left join (SELECT inv_rkd.cpdm,sum(inv_rkd.sl) as qcscrksl,sum(inv_rkd.je) as qcscrkje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND inv_rkd.rkrq >= ? and inv_rkd.rkrq >= ? and inv_rkd.rkrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_rkd.cpdm) qcscrk ON cpnc.cpdm = qcscrk.cpdm" & _
                    " Left join (SELECT po_rkd.cpdm,sum(po_rkd.sl) as qccgrksl,sum(po_rkd.je) as qccgrkje FROM po_rkd WHERE po_rkd.bdelete = 0 AND po_rkd.rkrq >= ? and po_rkd.rkrq >= ? and po_rkd.rkrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND po_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY po_rkd.cpdm) qccgrk ON cpnc.cpdm = qccgrk.cpdm" & _
                    " Left join (SELECT inv_dbd.cpdm,sum(inv_dbd.sl) as qcdbrksl,sum(inv_dbd.je) as qcdbrkje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.rckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_dbd.cpdm) qcdbrk ON cpnc.cpdm = qcdbrk.cpdm" & _
                    " Left join (SELECT oe_xsd.cpdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND oe_xsd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY oe_xsd.cpdm) qcxsck ON cpnc.cpdm = qcxsck.cpdm" & _
                    " Left join (SELECT inv_ckd.cpdm,sum(inv_ckd.sl) as qcckcksl,sum(inv_ckd.je) as qcckckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND inv_ckd.ckrq >= ? and inv_ckd.ckrq >= ? and inv_ckd.ckrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_ckd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_ckd.cpdm) qcckck ON cpnc.cpdm = qcckck.cpdm" & _
                    " Left join (SELECT inv_dbd.cpdm,sum(inv_dbd.sl) as qcdbcksl,sum(inv_dbd.je) as qcdbckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.cckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_dbd.cpdm) qcdbck ON cpnc.cpdm = qcdbck.cpdm" & _
                    " Left join (SELECT inv_rkd.cpdm,sum(inv_rkd.sl) as bqscrksl,sum(inv_rkd.je) as bqscrkje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND inv_rkd.rkrq >= ? and inv_rkd.rkrq >= ? and inv_rkd.rkrq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_rkd.cpdm) bqscrk ON cpnc.cpdm = bqscrk.cpdm" & _
                    " Left join (SELECT po_rkd.cpdm,sum(po_rkd.sl) as bqcgrksl,sum(po_rkd.je) as bqcgrkje FROM po_rkd WHERE po_rkd.bdelete = 0 AND po_rkd.rkrq >= ? and po_rkd.rkrq >= ? and po_rkd.rkrq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND po_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY po_rkd.cpdm) bqcgrk ON cpnc.cpdm = bqcgrk.cpdm" & _
                    " Left join (SELECT inv_dbd.cpdm,sum(inv_dbd.sl) as bqdbrksl,sum(inv_dbd.je) as bqdbrkje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.rckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_dbd.cpdm) bqdbrk ON cpnc.cpdm = bqdbrk.cpdm" & _
                    " Left join (SELECT oe_xsd.cpdm,sum(oe_xsd.sl) as bqxscksl,sum(oe_xsd.cbje) as bqxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND oe_xsd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY oe_xsd.cpdm) bqxsck ON cpnc.cpdm = bqxsck.cpdm" & _
                    " Left join (SELECT inv_ckd.cpdm,sum(inv_ckd.sl) as bqckcksl,sum(inv_ckd.je) as bqckckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND inv_ckd.ckrq >= ? and inv_ckd.ckrq >= ? and inv_ckd.ckrq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_ckd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_ckd.cpdm) bqckck ON cpnc.cpdm = bqckck.cpdm" & _
                    " Left join (SELECT inv_dbd.cpdm,sum(inv_dbd.sl) as bqdbcksl,sum(inv_dbd.je) as bqdbckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.cckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_dbd.cpdm) bqdbck ON cpnc.cpdm = bqdbck.cpdm) asfchz LEFT JOIN rc_cpxx ON asfchz.cpdm = rc_cpxx.cpdm) bsfchz WHERE (" & strExpLbdm & ")" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " and cpdm LIKE '" & Trim(TxtCpdm.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpmc.Text), " AND cpmc LIKE '%" & TxtCpmc.Text & "%'", "")
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
            If Me.CheckBox1.Checked Then
                For i = 0 To rcDataset.Tables("cpsfchz").Rows.Count - 1
                    Me.ProgressBar1.Value = i
                    If rcDataset.Tables("cpsfchz").Rows(i).Item("qcsl") = 0 And rcDataset.Tables("cpsfchz").Rows(i).Item("rksl") = 0 And rcDataset.Tables("cpsfchz").Rows(i).Item("cksl") = 0 And rcDataset.Tables("cpsfchz").Rows(i).Item("jcsl") = 0 Then
                        rcDataset.Tables("cpsfchz").Rows(i).Delete()
                    End If
                Next
            End If
            Dim rcDataRow As DataRow
            rcDataRow = rcDataset.Tables("cpsfchz").NewRow
            rcDataRow.Item("cpdm") = "合计"
            rcDataRow.Item("qcsl") = dtCpsfcHz.Compute("Sum(qcsl)", "")
            rcDataRow.Item("qcje") = dtCpsfcHz.Compute("Sum(qcje)", "")
            rcDataRow.Item("rksl") = dtCpsfcHz.Compute("Sum(rksl)", "")
            rcDataRow.Item("rkje") = dtCpsfcHz.Compute("Sum(rkje)", "")
            rcDataRow.Item("cksl") = dtCpsfcHz.Compute("Sum(cksl)", "")
            rcDataRow.Item("ckje") = dtCpsfcHz.Compute("Sum(ckje)", "")
            rcDataRow.Item("jcsl") = dtCpsfcHz.Compute("Sum(jcsl)", "")
            rcDataRow.Item("jcje") = dtCpsfcHz.Compute("Sum(jcje)", "")
            rcDataset.Tables("cpsfchz").Rows.Add(rcDataRow)

            '调用表单
            Dim rcFrm As New FrmPhSfcHzz2
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