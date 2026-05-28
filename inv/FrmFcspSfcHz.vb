Imports System.Data.OleDb

Public Class FrmFcspSfcHz
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable
    ReadOnly dtFcspSfcHz As New DataTable("fcspsfchz")
    '发出商品启用会计期间
    Dim dateFcspBegin As Date

    Private Sub FrmFcspSfcHz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        DtpHzrqBegin.Value = GetInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpHzrqEnd.Value = GetInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '创建datatable
        dtFcspSfcHz.Columns.Add("khdm", Type.GetType("System.String"))
        dtFcspSfcHz.Columns.Add("khmc", Type.GetType("System.String"))
        dtFcspSfcHz.Columns.Add("bmdm", Type.GetType("System.String"))
        dtFcspSfcHz.Columns.Add("bmmc", Type.GetType("System.String"))
        dtFcspSfcHz.Columns.Add("cpdm", Type.GetType("System.String"))
        dtFcspSfcHz.Columns.Add("cpmc", Type.GetType("System.String"))
        dtFcspSfcHz.Columns.Add("dw", Type.GetType("System.String"))
        dtFcspSfcHz.Columns.Add("cpweight", Type.GetType("System.Double"))
        dtFcspSfcHz.Columns.Add("bzcb", Type.GetType("System.Double"))
        dtFcspSfcHz.Columns.Add("qcsl", Type.GetType("System.Double"))
        dtFcspSfcHz.Columns.Add("qczl", Type.GetType("System.Double"))
        dtFcspSfcHz.Columns.Add("qcje", Type.GetType("System.Double"))
        dtFcspSfcHz.Columns.Add("rksl", Type.GetType("System.Double"))
        dtFcspSfcHz.Columns.Add("rkzl", Type.GetType("System.Double"))
        dtFcspSfcHz.Columns.Add("rkje", Type.GetType("System.Double"))
        dtFcspSfcHz.Columns.Add("cksl", Type.GetType("System.Double"))
        dtFcspSfcHz.Columns.Add("ckzl", Type.GetType("System.Double"))
        dtFcspSfcHz.Columns.Add("ckje", Type.GetType("System.Double"))
        dtFcspSfcHz.Columns.Add("jcsl", Type.GetType("System.Double"))
        dtFcspSfcHz.Columns.Add("jczl", Type.GetType("System.Double"))
        dtFcspSfcHz.Columns.Add("jcje", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtFcspSfcHz)
        With dtFcspSfcHz
            .Columns("khdm").DefaultValue = ""
            .Columns("bmdm").DefaultValue = ""
            .Columns("cpdm").DefaultValue = ""
            .Columns("cpweight").DefaultValue = 0.0
            .Columns("bzcb").DefaultValue = 0.0
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
        Dim strFcspKjqj As String = GetParaValue("发出商品启用会计期间", True)
        If Not String.IsNullOrEmpty(strFcspKjqj) Then
            dateFcspBegin = GetInvBegin(Mid(strFcspKjqj, 1, 4), Mid(strFcspKjqj, 5, 2))
        Else
            dateFcspBegin = g_Dwrq
        End If
    End Sub

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpHzrqBegin.KeyPress, DtpHzrqEnd.KeyPress, TxtKhdm.KeyPress, TxtLbdm.KeyPress, TxtBmdm.KeyPress, TxtCpdm.KeyPress, TxtCpmc.KeyPress
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

#Region "物料类别编码的事件"

    Private Sub Txtlbdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLbdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .ParaOleDbConn = rcOleDbConn
                    .ParaTableName = "rc_cplb"
                    .ParaField1 = "lbdm"
                    .ParaField2 = "lbmc"
                    .ParaField3 = "lbsm"
                    .ParaTitle = "物料类别"
                    .ParaOldValue = ""
                    .ParaAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtLbdm.Text = Trim(.ParaField1)
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
            If rcDataset.Tables("rc_bmxx").Rows.Count > 0 Then
                Me.TxtBmdm.Text = Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmdm"))
                'Me.LblBmmc.Text = Trim(rcDataSet.Tables("rc_bmxx").Rows(0).Item("bmmc"))
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

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim strKjqj As String = GetInvKjqj(DtpHzrqBegin.Value)
        Dim dInvBegin1 As Date = GetInvBegin(Mid(strKjqj, 1, 4), 1)
        Dim i As Integer = 1
        If dtFcspSfcHz IsNot Nothing Then
            dtFcspSfcHz.Clear()
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
        If Me.rdoBm.Checked Then
            '取期初库存、期初入库、期初出库、本期入库、本期出库
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT csfchz.khdm,csfchz.khmc,csfchz.bmdm,csfchz.bmmc,csfchz.cpdm,csfchz.cpmc,csfchz.dw,csfchz.cpweight,csfchz.bzcb,csfchz.qcsl,csfchz.qcsl * csfchz.cpweight AS qczl,csfchz.qcje,csfchz.rksl,csfchz.rksl * csfchz.cpweight AS rkzl,csfchz.rkje,csfchz.cksl,csfchz.cksl * csfchz.cpweight AS ckzl,csfchz.ckje,csfchz.jcsl,csfchz.jcsl*cpweight AS jczl,csfchz.jcje" &
                    " FROM (SELECT bsfchz.khdm,bsfchz.khmc,bsfchz.bmdm,bsfchz.bmmc,bsfchz.cpdm,bsfchz.cpmc,bsfchz.dw,bsfchz.cpweight,bsfchz.bzcb,COALESCE(bsfchz.qcsl,0.0)+COALESCE(bsfchz.qcscrksl,0.0)-COALESCE(bsfchz.qcckcksl,0.0)-COALESCE(bsfchz.qcxscksl,0.0) as qcsl,COALESCE(bsfchz.qcje,0.0)+COALESCE(bsfchz.qcscrkje,0.0)-COALESCE(bsfchz.qcckckje,0.0)-COALESCE(bsfchz.qcxsckje,0.0) as qcje,COALESCE(bsfchz.bqscrksl,0.0) AS rksl,COALESCE(bsfchz.bqscrkje,0.0) AS rkje,COALESCE(bsfchz.bqckcksl,0.0)+COALESCE(bsfchz.bqxscksl,0.0) AS cksl,COALESCE(bsfchz.bqckckje,0.0)+COALESCE(bsfchz.bqxsckje,0.0) AS ckje,COALESCE(bsfchz.qcsl,0.0)+COALESCE(bsfchz.qcscrksl,0.0)-COALESCE(bsfchz.qcckcksl,0.0)-COALESCE(bsfchz.qcxscksl,0.0) + COALESCE(bsfchz.bqscrksl,0.0) - COALESCE(bsfchz.bqckcksl,0.0)- COALESCE(bsfchz.bqxscksl,0.0) AS jcsl,COALESCE(bsfchz.qcje,0.0)+COALESCE(bsfchz.qcscrkje,0.0)-COALESCE(bsfchz.qcckckje,0.0)-COALESCE(bsfchz.qcxsckje,0.0) + COALESCE(bsfchz.bqscrkje,0.0)- COALESCE(bsfchz.bqckckje,0.0)- COALESCE(bsfchz.bqxsckje,0.0) AS jcje FROM" &
                    " (SELECT asfchz.*,rc_khxx.khmc,rc_bmxx.bmmc,rc_cpxx.cpmc,rc_cpxx.dw,rc_cpxx.lbdm,rc_cpxx.cpweight,rc_cpxx.bzcb FROM" &
                    " (SELECT cpnc.khdm,cpnc.bmdm,cpnc.cpdm,cpnc.qcsl,cpnc.qcje,qcscrk.qcscrksl,qcscrk.qcscrkje,qcckck.qcckcksl,qcckck.qcckckje,qcxsck.qcxscksl,qcxsck.qcxsckje,bqscrk.bqscrksl,bqscrk.bqscrkje,bqckck.bqckcksl,bqckck.bqckckje,bqxsck.bqxscksl,bqxsck.bqxsckje FROM" &
                    " (SELECT inv_fcspyeb.khdm,inv_fcspyeb.bmdm,inv_fcspyeb.cpdm,sum(qcsl) as qcsl,sum(qcje) as qcje FROM inv_fcspyeb WHERE kjnd = ?" & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND inv_fcspyeb.khdm ='" & Me.TxtKhdm.Text & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND inv_fcspyeb.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " GROUP BY inv_fcspyeb.khdm,inv_fcspyeb.bmdm,inv_fcspyeb.cpdm) cpnc" &
                    " Left join (SELECT oe_xsd.khdm,oe_xsd.bmdm,oe_xsd.cpdm,sum(oe_xsd.sl) as qcscrksl,sum(oe_xsd.cbje) as qcscrkje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND oe_xsd.khdm ='" & Me.TxtKhdm.Text & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_xsd.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " GROUP BY oe_xsd.khdm,oe_xsd.bmdm,oe_xsd.cpdm) qcscrk ON  cpnc.khdm = qcscrk.khdm  AND cpnc.bmdm = qcscrk.bmdm AND cpnc.cpdm = qcscrk.cpdm" &
                    " Left join (SELECT oe_fp.shkhdm AS khdm,oe_fp.bmdm,oe_fp.cpdm,sum(oe_fp.sl) as qcckcksl,sum(oe_fp.cbje) as qcckckje FROM oe_fp WHERE oe_fp.bdelete = 0 AND TRUNC(oe_fp.fprq,'mi') >= ? and TRUNC(oe_fp.fprq,'mi') >= ? and TRUNC(oe_fp.fprq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND oe_fp.shkhdm ='" & Me.TxtKhdm.Text & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_fp.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " GROUP BY oe_fp.shkhdm,oe_fp.bmdm,oe_fp.cpdm) qcckck ON cpnc.khdm = qcckck.khdm AND cpnc.bmdm = qcckck.bmdm AND cpnc.cpdm = qcckck.cpdm" &
                    " Left join (SELECT oe_xsd.khdm,oe_xsd.bmdm,oe_xsd.cpdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd,rc_cpxx WHERE oe_xsd.bdelete = 0 AND oe_xsd.je = 0 AND oe_xsd.cpdm = rc_cpxx.cpdm AND oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_xsd.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " GROUP BY oe_xsd.khdm,oe_xsd.bmdm,oe_xsd.cpdm) qcxsck ON cpnc.khdm = qcxsck.khdm AND cpnc.bmdm = qcxsck.bmdm AND cpnc.cpdm = qcxsck.cpdm" &
                    " Left join (SELECT oe_xsd.khdm,oe_xsd.bmdm,oe_xsd.cpdm,sum(oe_xsd.sl) as bqscrksl,sum(oe_xsd.cbje) as bqscrkje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND oe_xsd.khdm ='" & Me.TxtKhdm.Text & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_xsd.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " GROUP BY oe_xsd.khdm,oe_xsd.bmdm,oe_xsd.cpdm) bqscrk ON cpnc.khdm = bqscrk.khdm AND cpnc.bmdm = bqscrk.bmdm AND cpnc.cpdm = bqscrk.cpdm" &
                    " Left join (SELECT oe_fp.shkhdm AS khdm,oe_fp.bmdm,oe_fp.cpdm,sum(oe_fp.sl) as bqckcksl,sum(oe_fp.cbje) as bqckckje FROM oe_fp WHERE oe_fp.bdelete = 0 AND TRUNC(oe_fp.fprq,'mi') >= ? and TRUNC(oe_fp.fprq,'mi') >= ? and TRUNC(oe_fp.fprq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND oe_fp.shkhdm ='" & Me.TxtKhdm.Text & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_fp.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " GROUP BY oe_fp.shkhdm,oe_fp.bmdm,oe_fp.cpdm) bqckck ON cpnc.khdm = bqckck.khdm AND cpnc.bmdm = bqckck.bmdm AND cpnc.cpdm = bqckck.cpdm" &
                    " Left join (SELECT oe_xsd.khdm,oe_xsd.bmdm,oe_xsd.cpdm,sum(oe_xsd.sl) as bqxscksl,sum(oe_xsd.cbje) as bqxsckje FROM oe_xsd,rc_cpxx WHERE oe_xsd.bdelete = 0 AND oe_xsd.je = 0 AND oe_xsd.cpdm = rc_cpxx.cpdm AND oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_xsd.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " GROUP BY oe_xsd.khdm,oe_xsd.bmdm,oe_xsd.cpdm) bqxsck ON cpnc.khdm = bqxsck.khdm AND cpnc.bmdm = bqxsck.bmdm AND cpnc.cpdm = bqxsck.cpdm) asfchz LEFT JOIN rc_khxx ON asfchz.khdm = rc_khxx.khdm LEFT JOIN rc_bmxx ON asfchz.bmdm = rc_bmxx.bmdm LEFT JOIN rc_cpxx ON asfchz.cpdm = rc_cpxx.cpdm) bsfchz WHERE (" & strExpLbdm & ")" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " and cpdm LIKE '" & Trim(TxtCpdm.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpmc.Text), " AND cpmc LIKE '%" & TxtCpmc.Text & "%'", "") & ") csfchz"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(strKjqj, 1, 4)
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateFcspBegin.Date
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dInvBegin1.Date
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
                rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateFcspBegin.Date
                rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dInvBegin1.Date
                rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateFcspBegin.Date
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dInvBegin1.Date
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateFcspBegin.Date
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = DtpHzrqEnd.Value
                rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateFcspBegin.Date
                rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
                rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = DtpHzrqEnd.Value
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateFcspBegin.Date
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = DtpHzrqEnd.Value
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("fcspsfchz") IsNot Nothing Then
                    rcDataset.Tables("fcspsfchz").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "fcspsfchz")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("fcspsfchz").Rows.Count > 0 Then
                Me.ProgressBar1.Maximum = rcDataset.Tables("fcspsfchz").Rows.Count - 1
            End If
            If Me.CheckBox1.Checked Then
                For i = 0 To rcDataset.Tables("fcspsfchz").Rows.Count - 1
                    Me.ProgressBar1.Value = i
                    If rcDataset.Tables("fcspsfchz").Rows(i).Item("qcsl") = 0 And rcDataset.Tables("fcspsfchz").Rows(i).Item("rksl") = 0 And rcDataset.Tables("fcspsfchz").Rows(i).Item("cksl") = 0 And rcDataset.Tables("fcspsfchz").Rows(i).Item("jcsl") = 0 And rcDataset.Tables("fcspsfchz").Rows(i).Item("qcje") = 0 And rcDataset.Tables("fcspsfchz").Rows(i).Item("rkje") = 0 And rcDataset.Tables("fcspsfchz").Rows(i).Item("ckje") = 0 And rcDataset.Tables("fcspsfchz").Rows(i).Item("jcje") = 0 Then
                        rcDataset.Tables("fcspsfchz").Rows(i).Delete()
                    End If
                Next
            End If
            Dim rcDataRow As DataRow
            rcDataRow = rcDataset.Tables("fcspsfchz").NewRow
            rcDataRow.Item("khdm") = "合计"
            rcDataRow.Item("qcsl") = dtFcspSfcHz.Compute("Sum(qcsl)", "")
            rcDataRow.Item("qczl") = dtFcspSfcHz.Compute("Sum(qczl)", "")
            rcDataRow.Item("qcje") = dtFcspSfcHz.Compute("Sum(qcje)", "")
            rcDataRow.Item("rksl") = dtFcspSfcHz.Compute("Sum(rksl)", "")
            rcDataRow.Item("rkzl") = dtFcspSfcHz.Compute("Sum(rkzl)", "")
            rcDataRow.Item("rkje") = dtFcspSfcHz.Compute("Sum(rkje)", "")
            rcDataRow.Item("cksl") = dtFcspSfcHz.Compute("Sum(cksl)", "")
            rcDataRow.Item("ckzl") = dtFcspSfcHz.Compute("Sum(ckzl)", "")
            rcDataRow.Item("ckje") = dtFcspSfcHz.Compute("Sum(ckje)", "")
            rcDataRow.Item("jcsl") = dtFcspSfcHz.Compute("Sum(jcsl)", "")
            rcDataRow.Item("jczl") = dtFcspSfcHz.Compute("Sum(jczl)", "")
            rcDataRow.Item("jcje") = dtFcspSfcHz.Compute("Sum(jcje)", "")
            rcDataset.Tables("fcspsfchz").Rows.Add(rcDataRow)
            If Not String.IsNullOrEmpty(Me.TxtBmdm.Text) Then
                Try
                    rcOleDbConn.Open()
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    rcOleDbCommand.CommandText = "SELECT * FROM rc_bmxx WHERE (bmdm = ?)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtBmdm.Text)
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
            End If
            '调用表单
            Dim rcFrm As New FrmFcspSfcHzz1
            With rcFrm
                .ParaDataSet = rcDataset
                .ParaDataView = New DataView(rcDataset.Tables("fcspsfchz"), "TRUE", "khdm,bmdm,cpdm", DataViewRowState.CurrentRows)
                .Label2.Text = "汇总日期：" & DtpHzrqBegin.Value & "至" & DtpHzrqEnd.Value
                If Not String.IsNullOrEmpty(Me.TxtBmdm.Text) Then
                    If rcDataset.Tables("rc_bmxx").Rows.Count > 0 Then
                        .Label3.Text = "部门：(" & rcDataset.Tables("rc_bmxx").Rows(0).Item("bmdm") & ")" & rcDataset.Tables("rc_bmxx").Rows(0).Item("bmdm")
                    End If
                End If
                '.Label3.Text = IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), "部门：" & Trim(Me.TxtBmdm.Text), "")
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
                rcOleDbCommand.CommandText = "SELECT bsfchz.cpdm,bsfchz.cpmc,bsfchz.dw,COALESCE(bsfchz.qcsl,0.0)+COALESCE(bsfchz.qcscrksl,0.0)-COALESCE(bsfchz.qcckcksl,0.0)-COALESCE(bsfchz.qcxscksl,0.0) as qcsl,COALESCE(bsfchz.qcje,0.0)+COALESCE(bsfchz.qcscrkje,0.0)-COALESCE(bsfchz.qcckckje,0.0)-COALESCE(bsfchz.qcxsckje,0.0) as qcje,COALESCE(bsfchz.bqscrksl,0.0) AS rksl,COALESCE(bsfchz.bqscrkje,0.0) AS rkje,COALESCE(bsfchz.bqckcksl,0.0)+COALESCE(bsfchz.bqxscksl,0.0) AS cksl,COALESCE(bsfchz.bqckckje,0.0)+COALESCE(bsfchz.bqxsckje,0.0) AS ckje,COALESCE(bsfchz.qcsl,0.0)+COALESCE(bsfchz.qcscrksl,0.0)-COALESCE(bsfchz.qcckcksl,0.0)-COALESCE(bsfchz.qcxscksl,0.0)+COALESCE(bsfchz.bqscrksl,0.0) - COALESCE(bsfchz.bqckcksl,0.0) - COALESCE(bsfchz.bqxscksl,0.0) AS jcsl,COALESCE(bsfchz.qcje,0.0)+COALESCE(bsfchz.qcscrkje,0.0)-COALESCE(bsfchz.qcckckje,0.0)-COALESCE(bsfchz.qcxsckje,0.0)+ COALESCE(bsfchz.bqscrkje,0.0)- COALESCE(bsfchz.bqckckje,0.0)- COALESCE(bsfchz.bqxsckje,0.0) AS jcje FROM" &
                    " (SELECT asfchz.*,rc_cpxx.cpmc,rc_cpxx.dw,rc_cpxx.lbdm FROM" &
                    " (SELECT cpnc.cpdm,cpnc.qcsl,cpnc.qcje,qcscrk.qcscrksl,qcscrk.qcscrkje,qcckck.qcckcksl,qcckck.qcckckje,qcxsck.qcxscksl,qcxsck.qcxsckje,bqscrk.bqscrksl,bqscrk.bqscrkje,bqckck.bqckcksl,bqckck.bqckckje,bqxsck.bqxscksl,bqxsck.bqxsckje FROM" &
                    " (SELECT inv_fcspyeb.cpdm,sum(qcsl) as qcsl,sum(qcje) as qcje FROM inv_fcspyeb WHERE kjnd = ?" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND inv_fcspyeb.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " GROUP BY inv_fcspyeb.cpdm) cpnc" &
                    " Left join (SELECT oe_xsd.cpdm,sum(oe_xsd.sl) as qcscrksl,sum(oe_xsd.cbje) as qcscrkje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_xsd.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " GROUP BY oe_xsd.cpdm) qcscrk ON cpnc.cpdm = qcscrk.cpdm" &
                    " Left join (SELECT oe_fp.cpdm,sum(oe_fp.sl) as qcckcksl,sum(oe_fp.cbje) as qcckckje FROM oe_fp WHERE oe_fp.bdelete = 0 AND TRUNC(oe_fp.fprq,'mi') >= ? and TRUNC(oe_fp.fprq,'mi') >= ? and TRUNC(oe_fp.fprq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_fp.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " GROUP BY oe_fp.cpdm) qcckck ON cpnc.cpdm = qcckck.cpdm" &
                    " Left join (SELECT oe_xsd.cpdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd,rc_cpxx WHERE oe_xsd.bdelete = 0 AND oe_xsd.je = 0 AND oe_xsd.cpdm = rc_cpxx.cpdm AND oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_xsd.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " GROUP BY oe_xsd.cpdm) qcxsck ON cpnc.cpdm = qcxsck.cpdm" &
                    " Left join (SELECT oe_xsd.cpdm,sum(oe_xsd.sl) as bqscrksl,sum(oe_xsd.cbje) as bqscrkje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') >= ? and TRUNC(oe_xsd.xsrq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_xsd.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " GROUP BY oe_xsd.cpdm) bqscrk ON cpnc.cpdm = bqscrk.cpdm" &
                    " Left join (SELECT oe_fp.cpdm,sum(oe_fp.sl) as bqckcksl,sum(oe_fp.cbje) as bqckckje FROM oe_fp WHERE oe_fp.bdelete = 0 AND TRUNC(oe_fp.fprq,'mi') >= ? and TRUNC(oe_fp.fprq,'mi') >= ? and TRUNC(oe_fp.fprq,'mi') <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_fp.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " GROUP BY oe_fp.cpdm) bqckck ON cpnc.cpdm = bqckck.cpdm" &
                    " Left join (SELECT oe_xsd.cpdm,sum(oe_xsd.sl) as bqxscksl,sum(oe_xsd.cbje) as bqxsckje FROM oe_xsd,rc_cpxx WHERE oe_xsd.bdelete = 0 AND oe_xsd.je = 0 AND oe_xsd.cpdm = rc_cpxx.cpdm AND oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_xsd.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " GROUP BY oe_xsd.cpdm) bqxsck ON cpnc.cpdm = bqxsck.cpdm) asfchz LEFT JOIN rc_cpxx ON asfchz.cpdm = rc_cpxx.cpdm) bsfchz WHERE (" & strExpLbdm & ")" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " and cpdm LIKE '" & Trim(TxtCpdm.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpmc.Text), " AND cpmc LIKE '%" & TxtCpmc.Text & "%'", "")
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(strKjqj, 1, 4)
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateFcspBegin.Date
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dInvBegin1.Date
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
                rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateFcspBegin.Date
                rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dInvBegin1.Date
                rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateFcspBegin.Date
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dInvBegin1.Date
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateFcspBegin.Date
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = DtpHzrqEnd.Value
                rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateFcspBegin.Date
                rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
                rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = DtpHzrqEnd.Value
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateFcspBegin.Date
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = DtpHzrqEnd.Value
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("fcspsfchz") IsNot Nothing Then
                    rcDataset.Tables("fcspsfchz").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "fcspsfchz")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("fcspsfchz").Rows.Count > 0 Then
                Me.ProgressBar1.Maximum = rcDataset.Tables("fcspsfchz").Rows.Count - 1
            End If
            If Me.CheckBox1.Checked Then
                For i = 0 To rcDataset.Tables("fcspsfchz").Rows.Count - 1
                    Me.ProgressBar1.Value = i
                    If rcDataset.Tables("fcspsfchz").Rows(i).Item("qcsl") = 0 And rcDataset.Tables("fcspsfchz").Rows(i).Item("rksl") = 0 And rcDataset.Tables("fcspsfchz").Rows(i).Item("cksl") = 0 And rcDataset.Tables("fcspsfchz").Rows(i).Item("jcsl") = 0 And rcDataset.Tables("fcspsfchz").Rows(i).Item("qcje") = 0 And rcDataset.Tables("fcspsfchz").Rows(i).Item("rkje") = 0 And rcDataset.Tables("fcspsfchz").Rows(i).Item("ckje") = 0 And rcDataset.Tables("fcspsfchz").Rows(i).Item("jcje") = 0 Then
                        rcDataset.Tables("fcspsfchz").Rows(i).Delete()
                    End If
                Next
            End If
            Dim rcDataRow As DataRow
            rcDataRow = rcDataset.Tables("fcspsfchz").NewRow
            rcDataRow.Item("cpdm") = "合计"
            rcDataRow.Item("qcsl") = dtFcspSfcHz.Compute("Sum(qcsl)", "")
            rcDataRow.Item("qcje") = dtFcspSfcHz.Compute("Sum(qcje)", "")
            rcDataRow.Item("rksl") = dtFcspSfcHz.Compute("Sum(rksl)", "")
            rcDataRow.Item("rkje") = dtFcspSfcHz.Compute("Sum(rkje)", "")
            rcDataRow.Item("cksl") = dtFcspSfcHz.Compute("Sum(cksl)", "")
            rcDataRow.Item("ckje") = dtFcspSfcHz.Compute("Sum(ckje)", "")
            rcDataRow.Item("jcsl") = dtFcspSfcHz.Compute("Sum(jcsl)", "")
            rcDataRow.Item("jcje") = dtFcspSfcHz.Compute("Sum(jcje)", "")
            rcDataset.Tables("fcspsfchz").Rows.Add(rcDataRow)

            '调用表单
            Dim rcFrm As New FrmFcspSfcHzz2
            With rcFrm
                .ParaDataSet = rcDataset
                .ParaDataView = New DataView(rcDataset.Tables("fcspsfchz"), "TRUE", "cpdm", DataViewRowState.CurrentRows)
                .Label2.Text = "汇总日期：" & DtpHzrqBegin.Value & "至" & DtpHzrqEnd.Value
                '.Label3.Text = "部门：" & Trim(Me.TxtBmdm.Text)
                .WindowState = FormWindowState.Maximized
                .MdiParent = Me.MdiParent
                .Show()
            End With
        End If
    End Sub

End Class