Imports System.Data.OleDb

Public Class FrmSlSfcMx
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable
    ReadOnly dtCpsfcMx As New DataTable("cpsfcmx")

    Private Sub FrmSlSfcMx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        NudYear.Value = Mid(g_Kjqj, 1, 4)
        NudMonthBegin.Value = 1
        NudMonthEnd.Value = Mid(g_Kjqj, 5, 2)
        '创建datatable
        dtCpsfcMx.Columns.Add("rq", Type.GetType("System.DateTime"))
        dtCpsfcMx.Columns.Add("djh", Type.GetType("System.String"))
        dtCpsfcMx.Columns.Add("zy", Type.GetType("System.String"))
        dtCpsfcMx.Columns.Add("rksl", Type.GetType("System.Double"))
        dtCpsfcMx.Columns.Add("rkfzsl", Type.GetType("System.Double"))
        dtCpsfcMx.Columns.Add("cksl", Type.GetType("System.Double"))
        dtCpsfcMx.Columns.Add("ckfzsl", Type.GetType("System.Double"))
        dtCpsfcMx.Columns.Add("jcsl", Type.GetType("System.Double"))
        dtCpsfcMx.Columns.Add("jcfzsl", Type.GetType("System.Double"))
        dtCpsfcMx.Columns.Add("idx", Type.GetType("System.String"))
        rcDataset.Tables.Add(dtCpsfcMx)
        With rcDataset.Tables("cpsfcmx")
            .Columns("djh").DefaultValue = ""
            .Columns("zy").DefaultValue = ""
            .Columns("rksl").DefaultValue = 0.0
            .Columns("rkfzsl").DefaultValue = 0.0
            .Columns("cksl").DefaultValue = 0.0
            .Columns("ckfzsl").DefaultValue = 0.0
            .Columns("jcsl").DefaultValue = 0.0
            .Columns("jcfzsl").DefaultValue = 0.0
            .Columns("idx").DefaultValue = ""
        End With
    End Sub

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NudYear.KeyPress, NudMonthBegin.KeyPress, NudMonthEnd.KeyPress, TxtCkdm.KeyPress, TxtCpdm.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
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
                If rcDataSet.Tables("rc_ckxx") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_ckxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_ckxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_ckxx").Rows.Count > 0 Then
                Me.TxtCkdm.Text = Trim(rcDataSet.Tables("rc_ckxx").Rows(0).Item("ckdm"))
                'Me.LblCkmc.Text = Trim(rcDataSet.Tables("rc_ckxx").Rows(0).Item("ckmc"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If String.IsNullOrEmpty(Me.TxtCpdm.Text) Then
            MsgBox("物料编码不能为空。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        '清空数据
        rcDataset.Tables("cpsfcmx").Clear()
        'Dim i As Integer
        Dim j As Integer
        Dim rqBegin As Date
        Dim rqEnd As Date
        Dim dblQcsl As Double
        Dim dblQcfzsl As Double = 0.0
        Dim dblJcsl As Double = 0.0
        Dim dblJcfzsl As Double = 0.0
        rqBegin = GetInvBegin(NudYear.Value, NudMonthBegin.Value)
        rqEnd = GetInvEnd(NudYear.Value, NudMonthEnd.Value)
        '读取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "(SELECT inv_rkd.rkrq As rq,inv_rkd.djh,inv_rkd.rkmemo || '客户:' || inv_rkd.khdm || '第' || inv_rkd.xh || '行' As zy,inv_rkd.sl As rksl,inv_rkd.fzsl As rkfzsl,0.0 As cksl,0.0 AS ckfzsl,TO_CHAR(inv_rkd.rkrq,'YYYYMMDD') AS idx FROM inv_rkd WHERE inv_rkd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? and inv_rkd.rkrq >= ? and inv_rkd.rkrq >= ? and inv_rkd.rkrq <= ?)" &
                " UNION ALL (SELECT po_rkd.rkrq As rq,po_rkd.djh,po_rkd.rkmemo || '供应商:(' || po_rkd.csdm || ')' || po_rkd.csdm|| '第' || po_rkd.xh || '行' As zy,po_rkd.sl As rksl,po_rkd.fzsl AS rkfzsl,0.0 As cksl,0.0 AS ckfzsl,TO_CHAR(po_rkd.rkrq,'YYYYMMDD') AS idx FROM po_rkd WHERE po_rkd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND po_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? and po_rkd.rkrq >= ? and po_rkd.rkrq >= ? and po_rkd.rkrq <= ?)" &
                " UNION ALL (SELECT TRUNC(inv_dbd.dbrq,'mi') As rq,inv_dbd.djh,inv_dbd.dbmemo || '调出仓库' || inv_dbd.cckdm || '第' || inv_dbd.xh || '行' As zy,inv_dbd.sl As rksl,inv_dbd.fzsl As rkfzsl,0.0 As cksl,0.0 As ckfzsl,TO_CHAR(TRUNC(inv_dbd.dbrq,'mi'),'YYYYMMDD') AS idx FROM inv_dbd WHERE inv_dbd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.rckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ?)" &
                " UNION ALL (SELECT oe_xsd.xsrq As rq,oe_xsd.djh,oe_xsd.xsmemo || '客户:(' || oe_xsd.khdm  || ')' || oe_xsd.khmc || '第' || oe_xsd.xh || '行' AS zy,0.0 As rksl,0.0 As rkfzsl,oe_xsd.sl As cksl,oe_xsd.fzsl As ckfzsl,TO_CHAR(oe_xsd.xsrq,'YYYYMMDD') AS idx FROM oe_xsd WHERE oe_xsd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND oe_xsd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq <= ?)" &
                " UNION ALL (SELECT inv_ckd.ckrq As rq,inv_ckd.djh,inv_ckd.ckmemo || '第' || inv_ckd.xh || '行' AS zy,0.0 As rksl,0.0 As rkfzsl,inv_ckd.sl As cksl,inv_ckd.fzsl As ckfzsl,TO_CHAR(inv_ckd.ckrq,'YYYYMMDD') AS idx FROM inv_ckd WHERE inv_ckd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_ckd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? and inv_ckd.ckrq >= ? and inv_ckd.ckrq >= ? and inv_ckd.ckrq <= ?)" &
                " UNION ALL (SELECT TRUNC(inv_dbd.dbrq,'mi') As rq,inv_dbd.djh,inv_dbd.dbmemo || '调入仓库' || inv_dbd.rckdm || '第' || inv_dbd.xh || '行' AS zy,0.0 As rksl,0.0 As rkfzsl,inv_dbd.sl As cksl,inv_dbd.fzsl As ckfzsl,TO_CHAR(TRUNC(inv_dbd.dbrq,'mi'),'YYYYMMDD') AS idx FROM inv_dbd WHERE inv_dbd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.cckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("cpsfcmx") IsNot Nothing Then
                rcDataset.Tables("cpsfcmx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "cpsfcmx")
        Catch ex As Exception
            MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '取期初数
        rqBegin = GetInvBegin(Me.NudYear.Value, 1)
        rqEnd = GetInvBegin(Me.NudYear.Value, Me.NudMonthBegin.Value)
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT SUM(COALESCE(rksl,0.0)) As rksl,SUM(COALESCE(rkfzsl,0.0)) As rkfzsl,SUM(COALESCE(cksl,0.0)) As cksl,SUM(COALESCE(ckfzsl,0.0)) As ckfzsl FROM (" &
                "(SELECT inv_rkd.sl As rksl,inv_rkd.fzsl As rkfzsl,0.0 As cksl,0.0 As ckfzsl FROM inv_rkd WHERE inv_rkd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? and inv_rkd.rkrq >= ? and inv_rkd.rkrq >= ? and inv_rkd.rkrq < ?)" &
                " UNION ALL (SELECT po_rkd.sl As rksl,po_rkd.fzsl As rkfzsl,0.0 As cksl,0.0 As ckfzsl FROM po_rkd WHERE po_rkd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND po_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? and po_rkd.rkrq >= ? and po_rkd.rkrq >= ? and po_rkd.rkrq < ?)" &
                " UNION ALL (SELECT inv_dbd.sl As rksl,inv_dbd.fzsl As rkfzsl,0.0 As cksl,0.0 As ckfzsl FROM inv_dbd WHERE inv_dbd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.rckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ?)" &
                " UNION ALL (SELECT 0.0 As rksl,0.0 As rkfzsl,oe_xsd.sl As cksl,oe_xsd.fzsl As ckfzsl FROM oe_xsd WHERE oe_xsd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND oe_xsd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq < ?)" &
                " UNION ALL (SELECT 0.0 As rksl,0.0 As rkfzsl,inv_ckd.sl As cksl,inv_ckd.fzsl As ckfzsl FROM inv_ckd WHERE inv_ckd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_ckd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? and inv_ckd.ckrq >= ? and inv_ckd.ckrq >= ? and inv_ckd.ckrq < ?)" &
                " UNION ALL (SELECT 0.0 As rksl,0.0 As rkfzsl,inv_dbd.sl As cksl,inv_dbd.fzsl As ckfzsl FROM inv_dbd WHERE inv_dbd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.cckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ?)) tmpmxz "
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = rqEnd
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
        If rcDataset.Tables("qcrkck").Rows(0).Item("rksl").GetType.ToString = "System.DBNull" Then
            rcDataset.Tables("qcrkck").Rows(0).Item("rksl") = 0.0
        End If
        If rcDataset.Tables("qcrkck").Rows(0).Item("cksl").GetType.ToString = "System.DBNull" Then
            rcDataset.Tables("qcrkck").Rows(0).Item("cksl") = 0.0
        End If
        If rcDataset.Tables("qcrkck").Rows(0).Item("rkfzsl").GetType.ToString = "System.DBNull" Then
            rcDataset.Tables("qcrkck").Rows(0).Item("rkfzsl") = 0.0
        End If
        If rcDataset.Tables("qcrkck").Rows(0).Item("ckfzsl").GetType.ToString = "System.DBNull" Then
            rcDataset.Tables("qcrkck").Rows(0).Item("ckfzsl") = 0.0
        End If
        rqBegin = GetInvBegin(NudYear.Value, NudMonthBegin.Value)
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT '" & rqBegin.ToString & "' As rq,'期初结存' As zy ,(SUM(qcsl)+" & rcDataset.Tables("qcrkck").Rows(0).Item("rksl") & "-" & rcDataset.Tables("qcrkck").Rows(0).Item("cksl") & ") As jcsl,(SUM(qcfzsl)+" & rcDataset.Tables("qcrkck").Rows(0).Item("rkfzsl") & "-" & rcDataset.Tables("qcrkck").Rows(0).Item("ckfzsl") & ") As jcfzsl,'00' AS idx FROM inv_cpyeb WHERE kjnd = ? AND cpdm = ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_cpyeb.ckdm ='" & Me.TxtCkdm.Text & "'", "")
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
            rcOleDbDataAdpt.Fill(rcDataset, "cpsfcmx")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If dtCpsfcMx.Rows(dtCpsfcMx.Rows.Count - 1).Item("jcsl").GetType.ToString <> "System.DBNull" Then
            dblQcsl = dtCpsfcMx.Rows(dtCpsfcMx.Rows.Count - 1).Item("jcsl")
        End If
        If dtCpsfcMx.Rows(dtCpsfcMx.Rows.Count - 1).Item("jcfzsl").GetType.ToString <> "System.DBNull" Then
            dblQcfzsl = dtCpsfcMx.Rows(dtCpsfcMx.Rows.Count - 1).Item("jcfzsl")
        End If
        dblJcsl = dblQcsl
        dblJcfzsl = dblQcfzsl
        '本月合计
        For j = Me.NudMonthBegin.Value To Me.NudMonthEnd.Value
            rqBegin = GetInvBegin(Me.NudYear.Value, j)
            rqEnd = GetInvEnd(Me.NudYear.Value, j)
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT '" & rqEnd.ToString & "' As rq,'本月合计' As zy ,Coalesce(Sum(rksl),0.0) As rksl ,Coalesce(Sum(rkfzsl),0.0) As rkfzsl,Coalesce(sum(cksl),0.0) As cksl,Coalesce(sum(ckfzsl),0.0) As ckfzsl," & dblJcsl & " + Sum(rksl) - Sum(cksl) As jcsl," & dblJcfzsl & " + Sum(rkfzsl) - Sum(ckfzsl) As jcfzsl," & rqEnd.Year & rqEnd.Month.ToString.PadLeft(2, "0") & "98" & " AS idx FROM (" &
                    "(SELECT Sum(inv_rkd.sl) As rksl,Sum(inv_rkd.fzsl) As rkfzsl,0.0 As cksl,0.0 As ckfzsl FROM inv_rkd WHERE inv_rkd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? AND inv_rkd.rkrq >= ? AND inv_rkd.rkrq >= ? AND inv_rkd.rkrq <= ?)" &
                    " UNION ALL (SELECT Sum(po_rkd.sl) As rksl,Sum(po_rkd.fzsl) As rkfzsl,0.0 As cksl,0.0 As ckfzsl FROM po_rkd WHERE po_rkd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND po_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? AND po_rkd.rkrq >= ? AND po_rkd.rkrq >= ? AND po_rkd.rkrq <= ?)" &
                    " UNION ALL (SELECT Sum(inv_dbd.sl) As rksl,Sum(inv_dbd.fzsl) As rkfzsl,0.0 As cksl,0.0 As ckfzsl FROM inv_dbd WHERE inv_dbd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.rckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? AND TRUNC(inv_dbd.dbrq,'mi') >= ? AND TRUNC(inv_dbd.dbrq,'mi') >= ? AND TRUNC(inv_dbd.dbrq,'mi') <= ?)" &
                    " UNION ALL (SELECT 0.0 As rksl,0.0 As rkfzsl,Sum(oe_xsd.sl) As cksl,Sum(oe_xsd.fzsl) As ckfzsl FROM oe_xsd WHERE oe_xsd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND oe_xsd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? AND oe_xsd.xsrq >= ? AND oe_xsd.xsrq >= ? AND oe_xsd.xsrq <= ?)" &
                    " UNION ALL (SELECT 0.0 As rksl,0.0 As rkfzsl,Sum(inv_ckd.sl) As cksl,Sum(inv_ckd.fzsl) As ckfzsl FROM inv_ckd WHERE inv_ckd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_ckd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? AND inv_ckd.ckrq >= ? AND inv_ckd.ckrq >= ? AND inv_ckd.ckrq <= ?)" &
                    " UNION ALL (SELECT 0.0 As rksl,0.0 As rkfzsl,Sum(inv_dbd.sl) As cksl,Sum(inv_dbd.fzsl) As ckfzsl FROM inv_dbd WHERE inv_dbd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.cckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? AND TRUNC(inv_dbd.dbrq,'mi') >= ? AND TRUNC(inv_dbd.dbrq,'mi') >= ? AND TRUNC(inv_dbd.dbrq,'mi') <= ?)) tmpmxz "
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                rcOleDbDataAdpt.Fill(rcDataset, "cpsfcmx")
                If dtCpsfcMx.Rows(dtCpsfcMx.Rows.Count - 1).Item("jcsl").GetType.ToString <> "System.DBNull" Then
                    dblJcsl = dtCpsfcMx.Rows(dtCpsfcMx.Rows.Count - 1).Item("jcsl")
                Else
                    dtCpsfcMx.Rows(dtCpsfcMx.Rows.Count - 1).Item("jcsl") = dblJcsl
                End If
                If dtCpsfcMx.Rows(dtCpsfcMx.Rows.Count - 1).Item("jcfzsl").GetType.ToString <> "System.DBNull" Then
                    dblJcfzsl = dtCpsfcMx.Rows(dtCpsfcMx.Rows.Count - 1).Item("jcfzsl")
                Else
                    dtCpsfcMx.Rows(dtCpsfcMx.Rows.Count - 1).Item("jcfzsl") = dblJcfzsl
                End If
            Catch ex As Exception
                MsgBox("程序错误98。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        Next
        '本年累计
        rqBegin = GetInvBegin(NudYear.Value, NudMonthBegin.Value)
        For j = Me.NudMonthBegin.Value To Me.NudMonthEnd.Value
            rqEnd = GetInvEnd(Me.NudYear.Value, j)
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT '" & rqEnd.ToString & "' As rq,'本年累计' As zy ,Coalesce(Sum(rksl),0.0) As rksl ,Coalesce(Sum(rkfzsl),0.0) As rkfzsl,Coalesce(sum(cksl),0.0) As cksl,Coalesce(sum(ckfzsl),0.0) As ckfzsl,0.0 As jcsl,0.0 As jcfzsl," & rqEnd.Year & rqEnd.Month.ToString.PadLeft(2, "0") & "99" & " AS idx FROM (" &
                    "(SELECT Sum(inv_rkd.sl) As rksl,Sum(inv_rkd.fzsl) As rkfzsl,0.0 As cksl,0.0 As ckfzsl FROM inv_rkd WHERE inv_rkd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? AND inv_rkd.rkrq >= ? AND inv_rkd.rkrq >= ? AND inv_rkd.rkrq <= ?)" &
                    " UNION ALL (SELECT Sum(po_rkd.sl) As rksl,Sum(po_rkd.fzsl) As rkfzsl,0.0 As cksl,0.0 As ckfzsl FROM po_rkd WHERE po_rkd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND po_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? AND po_rkd.rkrq >= ? AND po_rkd.rkrq >= ? AND po_rkd.rkrq <= ?)" &
                    " UNION ALL (SELECT Sum(inv_dbd.sl) As rksl,Sum(inv_dbd.fzsl) As rkfzsl,0.0 As cksl,0.0 As ckfzsl FROM inv_dbd WHERE inv_dbd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.rckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? AND TRUNC(inv_dbd.dbrq,'mi') >= ? AND TRUNC(inv_dbd.dbrq,'mi') >= ? AND TRUNC(inv_dbd.dbrq,'mi') <= ?)" &
                    " UNION ALL (SELECT 0.0 As rksl,0.0 As rkfzsl,Sum(oe_xsd.sl) As cksl,Sum(oe_xsd.fzsl) As ckfzsl FROM oe_xsd WHERE oe_xsd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND oe_xsd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? AND oe_xsd.xsrq >= ? AND oe_xsd.xsrq >= ? AND oe_xsd.xsrq <= ?)" &
                    " UNION ALL (SELECT 0.0 As rksl,0.0 As rkfzsl,Sum(inv_ckd.sl) As cksl,Sum(inv_ckd.fzsl) As ckfzsl FROM inv_ckd WHERE inv_ckd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_ckd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? AND inv_ckd.ckrq >= ? AND inv_ckd.ckrq >= ? AND inv_ckd.ckrq <= ?)" &
                    " UNION ALL (SELECT 0.0 As rksl,0.0 As rkfzsl,Sum(inv_dbd.sl) As cksl,Sum(inv_dbd.fzsl) As ckfzsl FROM inv_dbd WHERE inv_dbd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.cckdm ='" & Me.TxtCkdm.Text & "'", "") & " AND cpdm = ? AND TRUNC(inv_dbd.dbrq,'mi') >= ? AND TRUNC(inv_dbd.dbrq,'mi') >= ? AND TRUNC(inv_dbd.dbrq,'mi') <= ?)) tmpmxz "
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                rcOleDbDataAdpt.Fill(rcDataset, "cpsfcmx")
            Catch ex As Exception
                MsgBox("程序错误99。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        Next

        If rcDataset.Tables("cpsfcmx").Rows.Count <= 0 Then
            MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        '调用表单
        Dim rcFrm As New FrmSlSfcMxz
        With rcFrm
            .paraDataSet = rcDataset
            .paraDataView = New DataView(rcDataset.Tables("cpsfcmx"), "TRUE", "idx", DataViewRowState.CurrentRows)
            '.paraDataTable = rcDataset.Tables("cpsfcmx")
            .Label2.Text = "日期：" & NudYear.Value & "年" & NudMonthBegin.Value & "月至" & NudMonthEnd.Value & "月"
            If rcDataset.Tables("rc_cpxx").Rows.Count > 0 Then
                .Label3.Text = "物料：(" & Me.TxtCpdm.Text & ")" & rcDataset.Tables("rc_cpxx").Rows(0).Item("cpmc") & " " & rcDataset.Tables("rc_cpxx").Rows(0).Item("dw") & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " 仓库：" & Me.TxtCkdm.Text, "")
            End If
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class