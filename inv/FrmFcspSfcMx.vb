Imports System.Data.OleDb

Public Class FrmFcspSfcMx
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable
    ReadOnly dtFcspSfcMx As New DataTable("fcspsfcmx")
    '发出商品启用会计期间
    Dim dateFcspBegin As Date

    Private Sub FrmFcspSfcMx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        NudYear.Value = Mid(g_Kjqj, 1, 4)
        NudMonthBegin.Value = 1
        NudMonthEnd.Value = Mid(g_Kjqj, 5, 2)
        '创建datatable
        dtFcspSfcMx.Columns.Add("rq", Type.GetType("System.DateTime"))
        dtFcspSfcMx.Columns.Add("djh", Type.GetType("System.String"))
        dtFcspSfcMx.Columns.Add("zy", Type.GetType("System.String"))
        dtFcspSfcMx.Columns.Add("rksl", Type.GetType("System.Double"))
        dtFcspSfcMx.Columns.Add("rkdj", Type.GetType("System.Double"))
        dtFcspSfcMx.Columns.Add("rkje", Type.GetType("System.Double"))
        dtFcspSfcMx.Columns.Add("cksl", Type.GetType("System.Double"))
        dtFcspSfcMx.Columns.Add("ckdj", Type.GetType("System.Double"))
        dtFcspSfcMx.Columns.Add("ckje", Type.GetType("System.Double"))
        dtFcspSfcMx.Columns.Add("jcsl", Type.GetType("System.Double"))
        dtFcspSfcMx.Columns.Add("jcdj", Type.GetType("System.Double"))
        dtFcspSfcMx.Columns.Add("jcje", Type.GetType("System.Double"))
        dtFcspSfcMx.Columns.Add("mxzindex", Type.GetType("System.String"))
        rcDataset.Tables.Add(dtFcspSfcMx)
        With rcDataset.Tables("FcspSfcmx")
            .Columns("djh").DefaultValue = ""
            .Columns("zy").DefaultValue = ""
            .Columns("rksl").DefaultValue = 0.0
            .Columns("rkdj").DefaultValue = 0.0
            .Columns("rkje").DefaultValue = 0.0
            .Columns("cksl").DefaultValue = 0.0
            .Columns("ckdj").DefaultValue = 0.0
            .Columns("ckje").DefaultValue = 0.0
            .Columns("jcsl").DefaultValue = 0.0
            .Columns("jcdj").DefaultValue = 0.0
            .Columns("jcje").DefaultValue = 0.0
        End With
        Dim strFcspKjqj As String = GetParaValue("发出商品启用会计期间", True)
        If Not String.IsNullOrEmpty(strFcspKjqj) Then
            dateFcspBegin = GetInvBegin(Mid(strFcspKjqj, 1, 4), Mid(strFcspKjqj, 5, 2))
        Else
            dateFcspBegin = g_Dwrq
        End If
    End Sub

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NudYear.KeyPress, NudMonthBegin.KeyPress, NudMonthEnd.KeyPress, TxtKhdm.KeyPress, TxtBmdm.KeyPress, TxtCpdm.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "客户编码事件"

    Private Sub TxtKhdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtKhdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .ParaOleDbConn = rcOleDbConn
                    .ParaTableName = "rc_khxx"
                    .ParaField1 = "khdm"
                    .ParaField2 = "khmc"
                    .ParaField3 = "khsm"
                    .ParaCondition = "0=0"
                    .ParaOrderField = "khmc"
                    .ParaTitle = "客户"
                    .ParaOldValue = ""
                    .ParaAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtKhdm.Text = Trim(.ParaField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtKhdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtKhdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtKhdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_khxx WHERE (khdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(TxtKhdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_khxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_khxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_khxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_khxx").Rows.Count = 0 Then
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
                    .ParaOleDbConn = rcOleDbConn
                    .ParaTableName = "rc_cpxx"
                    .ParaField1 = "cpdm"
                    .ParaField2 = "cpmc"
                    .ParaField3 = "dw"
                    .ParaField4 = "cpsm"
                    .ParaOrderField = "cpmc"
                    .ParaTitle = "物料"
                    .ParaOldValue = ""
                    .ParaAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtCpdm.Text = Trim(.ParaField1)
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

#Region "部门编码的事件"

    Private Sub TxtBmdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBmdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .ParaOleDbConn = rcOleDbConn
                    .ParaTableName = "rc_bmxx"
                    .ParaField1 = "bmdm"
                    .ParaField2 = "bmmc"
                    .ParaField3 = "bmsm"
                    .ParaTitle = "部门"
                    .ParaOldValue = ""
                    .ParaAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtBmdm.Text = Trim(.ParaField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtBmdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtBmdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtBmdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_bmxx WHERE (bmdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(TxtBmdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_bmxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_bmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_bmxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_bmxx").Rows.Count = 0 Then
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
        rcDataset.Tables("fcspsfcmx").Clear()
        'Dim i As Integer
        Dim j As Integer
        Dim rqBegin As Date
        Dim rqEnd As Date
        Dim dblQcsl As Double
        Dim dblQcje As Double
        Dim dblJcsl As Double = 0.0
        Dim dblJcje As Double = 0.0
        rqBegin = GetInvBegin(NudYear.Value, NudMonthBegin.Value)
        rqEnd = GetInvEnd(NudYear.Value, NudMonthEnd.Value)
        '读取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "(SELECT oe_xsd.xsrq As rq,oe_xsd.djh,oe_xsd.xsmemo || '开票客户:(' || oe_xsd.fpkhdm  || ')' || oe_xsd.fpkhmc|| '第' || oe_xsd.xh || '行' AS zy,oe_xsd.khdm,oe_xsd.khmc,oe_xsd.bmdm,oe_xsd.bmmc,oe_xsd.sl As rksl,oe_xsd.cbdj AS rkdj,oe_xsd.cbje As rkje,0.0 As cksl,0.0 AS ckdj,0.0 As ckje FROM oe_xsd WHERE oe_xsd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND oe_xsd.khdm ='" & Me.TxtKhdm.Text & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_xsd.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " AND cpdm = ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq <= ?)" &
                " UNION ALL (SELECT oe_fp.fprq As rq,oe_fp.djh,oe_fp.fpmemo || '第' || oe_fp.xh || '行' || '开票客户:(' || oe_fp.khdm || ')' || oe_fp.khmc AS zy,oe_fp.shkhdm as khdm,oe_fp.shkhmc as khmc,oe_fp.bmdm,oe_fp.bmmc,0.0 As rksl,0.0 AS rkdj,0.0 As rkje,oe_fp.sl As cksl,oe_fp.cbdj AS ckdj,oe_fp.cbje As ckje FROM oe_fp WHERE oe_fp.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND oe_fp.shkhdm ='" & Me.TxtKhdm.Text & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_fp.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " AND cpdm = ? and oe_fp.fprq >= ? and oe_fp.fprq >= ? and oe_fp.fprq <= ?)" &
                " UNION ALL (SELECT oe_xsd.xsrq As rq,oe_xsd.djh,oe_xsd.xsmemo || '开票客户:(' || oe_xsd.fpkhdm  || ')' || oe_xsd.fpkhmc|| '第' || oe_xsd.xh || '行' AS zy,oe_xsd.khdm,oe_xsd.khmc,oe_xsd.bmdm,oe_xsd.bmmc,0.0 As rksl,0.0 AS rkdj,0.0 As rkje,oe_xsd.sl As cksl,oe_xsd.cbdj AS ckdj,oe_xsd.cbje As ckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND oe_xsd.je = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND oe_xsd.khdm ='" & Me.TxtKhdm.Text & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_xsd.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " AND cpdm = ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq <= ?)"

            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtCpdm.Text)
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateFcspBegin.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtCpdm.Text)
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateFcspBegin.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtCpdm.Text)
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateFcspBegin.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("fcspsfcmx") IsNot Nothing Then
                rcDataset.Tables("fcspsfcmx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "fcspsfcmx")
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
            rcOleDbCommand.CommandText = "SELECT sum(rksl) As rksl,Sum(rkje) As rkje,sum(cksl) As cksl,Sum(ckje) As ckje FROM (" &
                "(SELECT oe_xsd.sl As rksl,oe_xsd.cbje As rkje,0.0 As cksl,0.0 As ckje FROM oe_xsd WHERE oe_xsd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND oe_xsd.khdm ='" & Me.TxtKhdm.Text & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_xsd.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " AND cpdm = ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq < ?)" &
                " UNION ALL (SELECT 0.0 As rksl,0.0 As rkje,oe_fp.sl As cksl,oe_fp.cbje As ckje FROM oe_fp WHERE oe_fp.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND oe_fp.shkhdm ='" & Me.TxtKhdm.Text & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_fp.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " AND cpdm = ? and oe_fp.fprq >= ? and oe_fp.fprq >= ? and oe_fp.fprq < ?)" &
                " UNION ALL (SELECT 0.0 As rksl,0.0 As rkje,oe_xsd.sl As cksl,oe_xsd.cbje As ckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND oe_xsd.je = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND oe_xsd.khdm ='" & Me.TxtKhdm.Text & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_xsd.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " AND cpdm = ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq < ?)) tmpmxz"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateFcspBegin.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateFcspBegin.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateFcspBegin.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = rqEnd
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
        If rcDataset.Tables("qcrkck").Rows(0).Item("rkje").GetType.ToString = "System.DBNull" Then
            rcDataset.Tables("qcrkck").Rows(0).Item("rkje") = 0.0
        End If
        If rcDataset.Tables("qcrkck").Rows(0).Item("cksl").GetType.ToString = "System.DBNull" Then
            rcDataset.Tables("qcrkck").Rows(0).Item("cksl") = 0.0
        End If
        If rcDataset.Tables("qcrkck").Rows(0).Item("ckje").GetType.ToString = "System.DBNull" Then
            rcDataset.Tables("qcrkck").Rows(0).Item("ckje") = 0.0
        End If
        rqBegin = GetInvBegin(NudYear.Value, NudMonthBegin.Value)
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT '" & rqBegin.ToString & "' As rq,'期初结存' As zy ,(sum(qcsl)+(" & rcDataset.Tables("qcrkck").Rows(0).Item("rksl") & ")-(" & rcDataset.Tables("qcrkck").Rows(0).Item("cksl") & ")) As jcsl,CASE WHEN (sum(qcsl)+(" & rcDataset.Tables("qcrkck").Rows(0).Item("rksl") & ")-(" & rcDataset.Tables("qcrkck").Rows(0).Item("cksl") & ")) <> 0 THEN (sum(qcje)+(" & rcDataset.Tables("qcrkck").Rows(0).Item("rkje") & ")-(" & rcDataset.Tables("qcrkck").Rows(0).Item("ckje") & ")) / (sum(qcsl)+(" & rcDataset.Tables("qcrkck").Rows(0).Item("rksl") & ")-(" & rcDataset.Tables("qcrkck").Rows(0).Item("cksl") & ")) ELSE 0 END AS jcdj,(sum(qcje)+(" & rcDataset.Tables("qcrkck").Rows(0).Item("rkje") & ")-(" & rcDataset.Tables("qcrkck").Rows(0).Item("ckje") & ")) As jcje FROM inv_fcspyeb WHERE kjnd = ? AND cpdm = ?" & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND inv_fcspyeb.khdm ='" & Me.TxtKhdm.Text & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND inv_fcspyeb.bmdm ='" & Me.TxtBmdm.Text & "'", "")
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtCpdm.Text)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            rcOleDbDataAdpt.Fill(rcDataset, "fcspsfcmx")
        Catch ex As Exception
            MsgBox("程序错误3。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            MsgBox(rcOleDbCommand.CommandText)
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If dtFcspSfcMx.Rows(dtFcspSfcMx.Rows.Count - 1).Item("jcsl").GetType.ToString <> "System.DBNull" Then
            dblQcsl = dtFcspSfcMx.Rows(dtFcspSfcMx.Rows.Count - 1).Item("jcsl")
            dblQcje = dtFcspSfcMx.Rows(dtFcspSfcMx.Rows.Count - 1).Item("jcje")
        End If
        dblJcsl = dblQcsl
        dblJcje = dblQcje
        '本月合计
        For j = Me.NudMonthBegin.Value To Me.NudMonthEnd.Value
            rqBegin = GetInvBegin(Me.NudYear.Value, j)
            rqEnd = GetInvEnd(Me.NudYear.Value, j)
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT '" & rqEnd.ToString & "' As rq,'本月合计' As zy ,Coalesce(Sum(rksl),0.0) As rksl,CASE WHEN Coalesce(Sum(rksl),0.0) <> 0 THEN Coalesce(Sum(rkje),0.0) / Coalesce(Sum(rksl),0.0) ELSE 0.0 END AS rkdj,Coalesce(Sum(rkje),0.0) As rkje,Coalesce(sum(cksl),0.0) As cksl,CASE WHEN Coalesce(Sum(cksl),0.0) <> 0 THEN Coalesce(Sum(ckje),0.0) / Coalesce(Sum(cksl),0.0) ELSE 0.0 END AS ckdj,Coalesce(Sum(ckje),0.0) As ckje," & dblJcsl & " + Sum(rksl) - Sum(cksl) As jcsl,CASE WHEN " & dblJcsl & " + Sum(rksl) - Sum(cksl) <> 0 THEN (" & dblJcje & " + Sum(rkje) - Sum(ckje)) / (" & dblJcsl & " + Sum(rksl) - Sum(cksl)) ELSE 0 END AS jcdj," & dblJcje & " + Sum(rkje) - Sum(ckje) As jcje,'98' AS mxzindex FROM (" &
                    " (SELECT Sum(oe_xsd.sl) As rksl,Sum(oe_xsd.cbje) As rkje,0.0 As cksl,0.0 As ckje FROM oe_xsd WHERE oe_xsd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND oe_xsd.khdm ='" & Me.TxtKhdm.Text & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_xsd.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " AND cpdm = ? AND oe_xsd.xsrq >= ? AND oe_xsd.xsrq >= ? AND oe_xsd.xsrq <= ?)" &
                    " UNION ALL (SELECT 0.0 As rksl,0.0 As rkje,Sum(oe_fp.sl) As cksl,Sum(oe_fp.cbje) As ckje FROM oe_fp WHERE oe_fp.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND oe_fp.shkhdm ='" & Me.TxtKhdm.Text & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_fp.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " AND cpdm = ? AND oe_fp.fprq >= ? AND oe_fp.fprq >= ? AND oe_fp.fprq <= ?)" &
                    " UNION ALL (SELECT 0.0 As rksl,0.0 As rkje,Sum(oe_xsd.sl) As cksl,Sum(oe_xsd.cbje) As ckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND oe_xsd.je = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND oe_xsd.khdm ='" & Me.TxtKhdm.Text & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_xsd.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " AND cpdm = ? AND oe_xsd.xsrq >= ? AND oe_xsd.xsrq >= ? AND oe_xsd.xsrq <= ?)) tmpmxz "
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateFcspBegin.Date
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateFcspBegin.Date
                rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateFcspBegin.Date
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                rcOleDbDataAdpt.Fill(rcDataset, "fcspsfcmx")
                If dtFcspSfcMx.Rows(dtFcspSfcMx.Rows.Count - 1).Item("jcsl").GetType.ToString <> "System.DBNull" Then
                    dblJcsl = dtFcspSfcMx.Rows(dtFcspSfcMx.Rows.Count - 1).Item("jcsl")
                    dblJcje = dtFcspSfcMx.Rows(dtFcspSfcMx.Rows.Count - 1).Item("jcje")
                Else
                    dtFcspSfcMx.Rows(dtFcspSfcMx.Rows.Count - 1).Item("jcsl") = dblJcsl
                    dtFcspSfcMx.Rows(dtFcspSfcMx.Rows.Count - 1).Item("jcje") = dblJcje
                End If
            Catch ex As Exception
                MsgBox("程序错误4。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
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
                rcOleDbCommand.CommandText = "SELECT '" & rqEnd.ToString & "' As rq,'本年累计' As zy ,Coalesce(Sum(rksl),0.0) As rksl,CASE WHEN Coalesce(Sum(rksl),0.0) <> 0 THEN Coalesce(Sum(rkje),0.0) / Coalesce(Sum(rksl),0.0) ELSE 0.0 END AS rkdj,Coalesce(Sum(rkje),0.0) As rkje,Coalesce(sum(cksl),0.0) As cksl,CASE WHEN Coalesce(Sum(cksl),0.0) <> 0 THEN Coalesce(Sum(ckje),0.0) / Coalesce(Sum(cksl),0.0) ELSE 0.0 END AS ckdj,Coalesce(Sum(ckje),0.0) As ckje,0.0 As jcsl,0.0 As jcje,'99' AS mxzindex FROM (" &
                    "(SELECT Sum(oe_xsd.sl) As rksl,Sum(oe_xsd.cbje) As rkje,0.0 As cksl,0.0 As ckje FROM oe_xsd WHERE oe_xsd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND oe_xsd.khdm ='" & Me.TxtKhdm.Text & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_xsd.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " AND cpdm = ? AND oe_xsd.xsrq >= ? AND oe_xsd.xsrq >= ? AND oe_xsd.xsrq <= ?)" &
                    " UNION ALL (SELECT 0.0 As rksl,0.0 As rkje,Sum(oe_fp.sl) As cksl,Sum(oe_fp.cbje) As ckje FROM oe_fp WHERE oe_fp.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND oe_fp.shkhdm ='" & Me.TxtKhdm.Text & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_fp.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " AND cpdm = ? AND oe_fp.fprq >= ? AND oe_fp.fprq >= ? AND oe_fp.fprq <= ?)" &
                    " UNION ALL (SELECT 0.0 As rksl,0.0 As rkje,Sum(oe_xsd.sl) As cksl,Sum(oe_xsd.cbje) As ckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND oe_xsd.je = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND oe_xsd.khdm ='" & Me.TxtKhdm.Text & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_xsd.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " AND cpdm = ? AND oe_xsd.xsrq >= ? AND oe_xsd.xsrq >= ? AND oe_xsd.xsrq <= ?)) tmpmxz "
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateFcspBegin.Date
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateFcspBegin.Date
                rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateFcspBegin.Date
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = rqBegin
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = rqEnd
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                rcOleDbDataAdpt.Fill(rcDataset, "fcspsfcmx")
            Catch ex As Exception
                MsgBox("程序错误5。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        Next

        If rcDataset.Tables("fcspsfcmx").Rows.Count <= 0 Then
            MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        '调用表单
        Dim rcFrm As New FrmFcspSfcMxz
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("fcspsfcmx"), "TRUE", "rq,mxzindex,zy", DataViewRowState.CurrentRows)
            '.paraDataTable = rcDataset.Tables("fcspsfcmx")
            .Label2.Text = NudYear.Value & "年" & NudMonthBegin.Value & "月至" & NudMonthEnd.Value & "月"
            If rcDataset.Tables("rc_cpxx").Rows.Count > 0 Then
                .Label3.Text = "物料：(" & Me.TxtCpdm.Text & ")" & rcDataset.Tables("rc_cpxx").Rows(0).Item("cpmc") & " " & rcDataset.Tables("rc_cpxx").Rows(0).Item("dw")
            End If
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class