Imports System.Data.OleDb

Public Class FrmFcspKhSfcHz
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable
    ReadOnly dtCpsfcHz As New DataTable("cpsfchz")

    Private Sub FrmFcspJeSfcHz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        DtpHzrqBegin.Value = GetInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpHzrqEnd.Value = GetInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '创建datatable
        dtCpsfcHz.Columns.Add("khdm", Type.GetType("System.String"))
        dtCpsfcHz.Columns.Add("khmc", Type.GetType("System.String"))
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
            .Columns("khdm").DefaultValue = ""
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

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpHzrqBegin.KeyPress, DtpHzrqEnd.KeyPress, TxtLbdm.KeyPress, TxtKhdm.KeyPress
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

#Region "客户编码的事件"

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
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 12).Value = Trim(TxtKhdm.Text)
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
            If rcDataset.Tables("rc_khxx").Rows.Count > 0 Then
                Me.TxtKhdm.Text = Trim(rcDataset.Tables("rc_khxx").Rows(0).Item("khdm"))
                'Me.Lblkhmc.Text = Trim(rcDataSet.Tables("rc_khxx").Rows(0).Item("khmc"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim strKjqj As String = GetInvKjqj(DtpHzrqBegin.Value)
        Dim strKjqjEnd As String = GetInvKjqj(Me.DtpHzrqEnd.Value)
        Dim dInvBegin1 As Date = GetInvBegin(Mid(strKjqj, 1, 4), 1)
        Dim strDwKjqj As String

        strDwKjqj = GetParaValue("发出商品启用会计期间", True)
        If String.IsNullOrEmpty(strDwKjqj) Then
            strDwKjqj = GetInvKjqj(g_Dwrq)
        End If
        Dim dateKsrq As Date = GetInvBegin(Mid(strDwKjqj, 1, 4), Mid(strDwKjqj, 5, 2))

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
            'rcOleDbCommand.CommandText = "SELECT bsfchz.khdm,bsfchz.khmc,COALESCE(bsfchz.qcsl,0.0)+COALESCE(bsfchz.qcscrksl,0.0)-COALESCE(bsfchz.qcckcksl,0.0)-COALESCE(bsfchz.qcxscksl,0.0) as qcsl,COALESCE(bsfchz.qczl,0.0)+COALESCE(bsfchz.qcscrkzl,0.0)-COALESCE(bsfchz.qcckckzl,0.0)-COALESCE(bsfchz.qcxsckzl,0.0) as qczl,COALESCE(bsfchz.qcje,0.0)+COALESCE(bsfchz.qcscrkje,0.0)-COALESCE(bsfchz.qcckckje,0.0)-COALESCE(bsfchz.qcxsckje,0.0) as qcje,COALESCE(bsfchz.bqscrksl,0.0) AS rksl,COALESCE(bsfchz.bqscrkzl,0.0) AS rkzl,COALESCE(bsfchz.bqscrkje,0.0) AS rkje, COALESCE(bsfchz.bqckcksl,0.0) AS cksl, COALESCE(bsfchz.bqckckzl,0.0) AS ckzl,COALESCE(bsfchz.bqckckje,0.0) AS ckje,COALESCE(bsfchz.qcsl,0.0)+COALESCE(bsfchz.qcscrksl,0.0)-COALESCE(bsfchz.qcckcksl,0.0)-COALESCE(bsfchz.qcxscksl,0.0) + COALESCE(bsfchz.bqscrksl,0.0) - COALESCE(bsfchz.bqckcksl,0.0) AS jcsl,COALESCE(bsfchz.qczl,0.0)+COALESCE(bsfchz.qcscrkzl,0.0)-COALESCE(bsfchz.qcckckzl,0.0)-COALESCE(bsfchz.qcxsckzl,0.0) + COALESCE(bsfchz.bqscrkzl,0.0) - COALESCE(bsfchz.bqckckzl,0.0) AS jczl,COALESCE(bsfchz.qcje,0.0)+COALESCE(bsfchz.qcscrkje,0.0)-COALESCE(bsfchz.qcckckje,0.0)+ COALESCE(bsfchz.bqscrkje,0.0)- COALESCE(bsfchz.bqckckje,0.0) AS jcje , COALESCE(bsfchz.jcfcspje,0.0) AS jcfcspje FROM" &
            '                " (SELECT cpnc.khdm,cpnc.qcsl,cpnc.qczl,cpnc.qcje,qcscrk.qcscrksl,qcscrk.qcscrkzl,qcscrk.qcscrkje,qcckck.qcckcksl,qcckck.qcckckzl,qcckck.qcckckje,bqscrk.bqscrksl,bqscrk.bqscrkzl,bqscrk.bqscrkje,bqckck.bqckcksl,bqckck.bqckckzl,bqckck.bqckckje,fcspjc.jcfcspje FROM" &
            rcOleDbCommand.CommandText = "SELECT bsfchz.khdm,bsfchz.khmc,COALESCE(bsfchz.qcsl,0.0)+COALESCE(bsfchz.qcscrksl,0.0)-COALESCE(bsfchz.qcckcksl,0.0)-+COALESCE(bsfchz.qcxscksl,0.0) as qcsl,COALESCE(bsfchz.qczl,0.0)+COALESCE(bsfchz.qcscrkzl,0.0)-COALESCE(bsfchz.qcckckzl,0.0)-COALESCE(bsfchz.qcxsckzl,0.0) as qczl,COALESCE(bsfchz.qcje,0.0)+COALESCE(bsfchz.qcscrkje,0.0)-COALESCE(bsfchz.qcckckje,0.0)-COALESCE(bsfchz.qcxsckje,0.0) as qcje,COALESCE(bsfchz.bqscrksl,0.0) AS rksl,COALESCE(bsfchz.bqscrkzl,0.0) AS rkzl,COALESCE(bsfchz.bqscrkje,0.0) AS rkje, COALESCE(bsfchz.bqckcksl,0.0)+COALESCE(bsfchz.bqxscksl,0.0) AS cksl, COALESCE(bsfchz.bqckckzl,0.0)+COALESCE(bsfchz.bqxsckzl,0.0) AS ckzl,COALESCE(bsfchz.bqckckje,0.0)+COALESCE(bsfchz.bqxsckje,0.0) AS ckje,COALESCE(bsfchz.qcsl,0.0)+COALESCE(bsfchz.qcscrksl,0.0)-COALESCE(bsfchz.qcckcksl,0.0)-COALESCE(bsfchz.qcxscksl,0.0) + COALESCE(bsfchz.bqscrksl,0.0) - COALESCE(bsfchz.bqckcksl,0.0) -COALESCE(bsfchz.bqxscksl,0.0) AS jcsl,COALESCE(bsfchz.qczl,0.0)+COALESCE(bsfchz.qcscrkzl,0.0)-COALESCE(bsfchz.qcckckzl,0.0)-COALESCE(bsfchz.qcxsckzl,0.0) + COALESCE(bsfchz.bqscrkzl,0.0) - COALESCE(bsfchz.bqckckzl,0.0)- COALESCE(bsfchz.bqxsckzl,0.0) AS jczl,COALESCE(bsfchz.qcje,0.0)+COALESCE(bsfchz.qcscrkje,0.0)-COALESCE(bsfchz.qcckckje,0.0)-COALESCE(bsfchz.qcxsckje,0.0)+ COALESCE(bsfchz.bqscrkje,0.0)- COALESCE(bsfchz.bqckckje,0.0)-COALESCE(bsfchz.bqxsckje,0.0) AS jcje, COALESCE(bsfchz.jcfcspje,0.0) AS jcfcspje FROM" &
                " (SELECT asfchz.*,rc_khxx.khmc FROM" &
                " (SELECT cpnc.khdm,cpnc.qcsl,cpnc.qczl,cpnc.qcje,qcscrk.qcscrksl,qcscrk.qcscrkzl,qcscrk.qcscrkje,qcckck.qcckcksl,qcckck.qcckckzl,qcckck.qcckckje,qcxsck.qcxscksl,qcxsck.qcxsckzl,qcxsck.qcxsckje,bqscrk.bqscrksl,bqscrk.bqscrkzl,bqscrk.bqscrkje,bqckck.bqckcksl,bqckck.bqckckzl,bqckck.bqckckje,bqxsck.bqxscksl,bqxsck.bqxsckzl,bqxsck.bqxsckje,fcspjc.jcfcspje FROM" &
                " (SELECT inv_fcspyeb.khdm,sum(qcsl) as qcsl,sum(qcsl * rc_cpxx.cpweight)/1000 as qczl,sum(qcje) as qcje FROM inv_fcspyeb,rc_cpxx WHERE inv_fcspyeb.kjnd = ? AND inv_fcspyeb.cpdm = rc_cpxx.cpdm" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND inv_fcspyeb.khdm ='" & Me.TxtKhdm.Text & "'", "") & " GROUP BY inv_fcspyeb.khdm) cpnc" &
                " Left join (SELECT oe_xsd.khdm,sum(oe_xsd.sl) as qcscrksl,sum(oe_xsd.sl * rc_cpxx.cpweight)/1000 as qcscrkzl,sum(oe_xsd.cbje) as qcscrkje FROM oe_xsd,rc_cpxx WHERE oe_xsd.bdelete = 0 AND oe_xsd.cpdm = rc_cpxx.cpdm AND oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND oe_xsd.khdm ='" & Me.TxtKhdm.Text & "'", "") & " GROUP BY oe_xsd.khdm) qcscrk ON cpnc.khdm = qcscrk.khdm" &
                " Left join (SELECT oe_fp.shkhdm as khdm,sum(oe_fp.sl) as qcckcksl,sum(oe_fp.sl * rc_cpxx.cpweight)/1000 as qcckckzl,sum(oe_fp.cbje) as qcckckje FROM oe_fp,rc_cpxx WHERE oe_fp.bdelete = 0 AND oe_fp.cpdm = rc_cpxx.cpdm AND oe_fp.fprq >= ? and oe_fp.fprq >= ? and oe_fp.fprq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND oe_fp.shkhdm ='" & Me.TxtKhdm.Text & "'", "") & " GROUP BY oe_fp.shkhdm) qcckck ON cpnc.khdm = qcckck.khdm" &
                " Left join (SELECT oe_xsd.khdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.sl * rc_cpxx.cpweight)/1000 as qcxsckzl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd,rc_cpxx WHERE oe_xsd.bdelete = 0 AND oe_xsd.je = 0 AND oe_xsd.cpdm = rc_cpxx.cpdm AND oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND oe_xsd.khdm ='" & Me.TxtKhdm.Text & "'", "") & " GROUP BY oe_xsd.khdm) qcxsck ON cpnc.khdm = qcxsck.khdm" &
                " Left join (SELECT oe_xsd.khdm,sum(oe_xsd.sl) as bqscrksl,sum(oe_xsd.sl * rc_cpxx.cpweight)/1000 as bqscrkzl,sum(oe_xsd.cbje) as bqscrkje FROM oe_xsd,rc_cpxx WHERE oe_xsd.bdelete = 0 AND oe_xsd.cpdm = rc_cpxx.cpdm AND oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND oe_xsd.khdm ='" & Me.TxtKhdm.Text & "'", "") & " GROUP BY oe_xsd.khdm) bqscrk ON cpnc.khdm = bqscrk.khdm" &
                " Left join (SELECT oe_fp.shkhdm as khdm,sum(oe_fp.sl) as bqckcksl,sum(oe_fp.sl * rc_cpxx.cpweight)/1000 as bqckckzl,sum(oe_fp.cbje) as bqckckje FROM oe_fp,rc_cpxx WHERE oe_fp.bdelete = 0 AND oe_fp.cpdm = rc_cpxx.cpdm AND oe_fp.fprq >= ? and oe_fp.fprq >= ? and oe_fp.fprq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND oe_fp.shkhdm ='" & Me.TxtKhdm.Text & "'", "") & " GROUP BY oe_fp.shkhdm) bqckck ON cpnc.khdm = bqckck.khdm" &
                " Left join (SELECT oe_xsd.khdm,sum(oe_xsd.sl) as bqxscksl,sum(oe_xsd.sl * rc_cpxx.cpweight)/1000 as bqxsckzl,sum(oe_xsd.cbje) as bqxsckje FROM oe_xsd,rc_cpxx WHERE oe_xsd.bdelete = 0 AND oe_xsd.je = 0 AND oe_xsd.cpdm = rc_cpxx.cpdm AND oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND oe_xsd.khdm ='" & Me.TxtKhdm.Text & "'", "") & " GROUP BY oe_xsd.khdm) bqxsck ON cpnc.khdm = bqxsck.khdm" &
                " Left join (SELECT oe_xsd_fcsp.shkhdm as khdm,sum(oe_xsd_fcsp.je) as jcfcspje FROM oe_xsd_fcsp,rc_cpxx WHERE oe_xsd_fcsp.cpdm = rc_cpxx.cpdm AND oe_xsd_fcsp.cperiod = ?" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND oe_xsd_fcsp.shkhdm ='" & Me.TxtKhdm.Text & "'", "") & " GROUP BY oe_xsd_fcsp.shkhdm) fcspjc ON cpnc.khdm = fcspjc.khdm) asfchz LEFT JOIN rc_khxx ON asfchz.khdm = rc_khxx.khdm) bsfchz"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(strKjqj, 1, 4)
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dInvBegin1.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dInvBegin1.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dInvBegin1.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = DtpHzrqEnd.Value
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = DtpHzrqEnd.Value
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = DtpHzrqEnd.Value
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strKjqjEnd
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
        rcDataRow.Item("khdm") = "合计"
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
        rcDataRow.Item("jcfcspje") = dtCpsfcHz.Compute("Sum(jcfcspje)", "")
        rcDataset.Tables("cpsfchz").Rows.Add(rcDataRow)

        '调用表单
        Dim rcFrm As New FrmFcspKhSfcHzz
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("cpsfchz"), "TRUE", "khdm", DataViewRowState.CurrentRows)
            .Label2.Text = DtpHzrqBegin.Value & "至" & DtpHzrqEnd.Value
            '.Label3.Text = "仓库：" & Trim(Me.Txtkhdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

End Class