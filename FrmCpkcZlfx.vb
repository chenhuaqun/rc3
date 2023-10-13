Imports System.Data.OleDb

Public Class FrmCpkcZlfx
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '数据OleDb更新传递
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Private Sub FrmCpkcZlfx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        Me.NudYear.Value = Mid(g_Kjqj, 1, 4)
        Me.NudMonth.Value = Mid(g_Kjqj, 5, 2)
    End Sub

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NudYear.KeyPress, NudMonth.KeyPress, TxtCkdm.KeyPress, TxtLbdm.KeyPress, TxtCpdm.KeyPress, TxtCpmc.KeyPress, TxtFadm.KeyPress
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

#Region "库存账龄方案编码的事件"

    Private Sub TxtFadm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFadm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_kczlfa"
                    .paraField1 = "fadm"
                    .paraField2 = "famc"
                    .paraField3 = "fasm"
                    .paraTitle = "库存账龄方案"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtFadm.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtFadm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtFadm.Validating
        If Not String.IsNullOrEmpty(Me.TxtFadm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_kczlfa WHERE (fadm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@fadm", OleDbType.VarChar, 12).Value = Trim(TxtFadm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_kczlfa") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_kczlfa").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_kczlfa")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_kczlfa").Rows.Count > 0 Then
                Me.TxtFadm.Text = Trim(rcDataset.Tables("rc_kczlfa").Rows(0).Item("fadm"))
                'Me.LblCkmc.Text = Trim(rcDataSet.Tables("rc_ckxx").Rows(0).Item("ckmc"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim datePcrq As Date = getInvEnd(Me.NudYear.Value, Me.NudMonth.Value)
        Dim dInvBegin1 As Date = getInvBegin(Me.NudYear.Value, 1)
        Dim i As Integer = 1
        If String.IsNullOrEmpty(Me.TxtFadm.Text) Then
            MsgBox("请选择库存账龄方案。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        '取数据
        '取期初库存、期初入库、期初出库、本期入库、本期出库
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '读取账龄分段信息
            Me.LblMsg.Text = "正在读取账龄分段信息表，请稍候......"
            rcOleDbCommand.CommandText = "SELECT * FROM rc_kczlfd WHERE fadm = ? ORDER BY fadm,fdxh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@fadm", OleDbType.VarChar, 12).Value = Trim(Me.TxtFadm.Text)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_kczlfd") IsNot Nothing Then
                rcDataset.Tables("rc_kczlfd").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_kczlfd")
            '创建临时表
            Me.LblMsg.Text = "正在创建临时表，请稍候......"
            rcOleDbCommand.CommandText = "SELECT * FROM user_tables WHERE table_name='T_CPKCZLFX'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count = 0 Then
                rcOleDbCommand.CommandText = "Create Global Temporary Table t_cpkczlfx (cpdm varchar2(15),ckdm varchar2(12),kcsl_tot number(18,6),kcje_tot number(14,2),kcsl_01 number(18,6),kcje_01 number(14,2),kcsl_02 number(18,6),kcje_02 number(14,2),kcsl_03 number(18,6),kcje_03 number(14,2),kcsl_04 number(18,6),kcje_04 number(14,2),kcsl_05 number(18,6),kcje_05 number(14,2),kcsl_06 number(18,6),kcje_06 number(14,2),kcsl_07 number(18,6),kcje_07 number(14,2)) on Commit delete Rows"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "alter table T_CPKCZLFX  add constraint PK_CPKCZLFX primary key (CPDM, CKDM)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            End If
            Me.LblMsg.Text = "正在生成库存账龄分析表......"
            '插入库存数据
            For i = 0 To rcDataset.Tables("rc_kczlfd").Rows.Count - 1
                If i = 0 Then
                    Me.LblMsg.Text = "正在生成" & Me.NudMonth.Value.ToString & "月库存数据......"
                    rcOleDbCommand.CommandText = "INSERT INTO t_cpkczlfx (cpdm,ckdm,kcsl_tot,kcje_tot)" & _
                        " SELECT bsfchz.cpdm,bsfchz.ckdm,COALESCE(bsfchz.qcsl,0.0)+COALESCE(bsfchz.qcscrksl,0.0)+COALESCE(bsfchz.qccgrksl,0.0)+COALESCE(bsfchz.qcdbrksl,0.0)-COALESCE(bsfchz.qcxscksl,0.0)-COALESCE(bsfchz.qcckcksl,0.0)-COALESCE(bsfchz.qcdbcksl,0.0) AS kcsl_tot,COALESCE(bsfchz.qcje,0.0)+COALESCE(bsfchz.qcscrkje,0.0)+COALESCE(bsfchz.qccgrkje,0.0)+COALESCE(bsfchz.qcdbrkje,0.0)-COALESCE(bsfchz.qcxsckje,0.0)-COALESCE(bsfchz.qcckckje,0.0)-COALESCE(bsfchz.qcdbckje,0.0) AS kcje_tot FROM" & _
                        " (SELECT asfchz.*,rc_cpxx.cpmc,rc_cpxx.dw,rc_cpxx.lbdm,rc_ckxx.ckmc FROM" & _
                        " (SELECT cpnc.cpdm,cpnc.ckdm,cpnc.qcsl,cpnc.qcje,qcscrk.qcscrksl,qcscrk.qcscrkje,qccgrk.qccgrksl,qccgrk.qccgrkje,qcdbrk.qcdbrksl,qcdbrk.qcdbrkje,qcxsck.qcxscksl,qcxsck.qcxsckje,qcckck.qcckcksl,qcckck.qcckckje,qcdbck.qcdbcksl,qcdbck.qcdbckje FROM" & _
                        " (SELECT inv_cpyeb.cpdm,inv_cpyeb.ckdm,sum(qcsl) as qcsl,sum(qcje) as qcje FROM inv_cpyeb WHERE kjnd = ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_cpyeb.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_cpyeb.cpdm,inv_cpyeb.ckdm) cpnc" & _
                        " Left join (SELECT inv_rkd.cpdm,inv_rkd.ckdm,sum(inv_rkd.sl) as qcscrksl,sum(inv_rkd.je) as qcscrkje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND inv_rkd.rkrq >= ? and inv_rkd.rkrq >= ? and inv_rkd.rkrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_rkd.cpdm,inv_rkd.ckdm) qcscrk ON cpnc.cpdm = qcscrk.cpdm AND cpnc.ckdm = qcscrk.ckdm" & _
                        " Left join (SELECT po_rkd.cpdm,po_rkd.ckdm,sum(po_rkd.sl) as qccgrksl,sum(po_rkd.je) as qccgrkje FROM po_rkd WHERE po_rkd.bdelete = 0 AND po_rkd.rkrq >= ? and po_rkd.rkrq >= ? and po_rkd.rkrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND po_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY po_rkd.cpdm,po_rkd.ckdm) qccgrk ON cpnc.cpdm = qccgrk.cpdm AND cpnc.ckdm = qccgrk.ckdm" & _
                        " Left join (SELECT inv_dbd.cpdm,inv_dbd.rckdm AS ckdm,sum(inv_dbd.sl) as qcdbrksl,sum(inv_dbd.je) as qcdbrkje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.rckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_dbd.cpdm,inv_dbd.rckdm) qcdbrk ON cpnc.cpdm = qcdbrk.cpdm AND cpnc.ckdm = qcdbrk.ckdm" & _
                        " Left join (SELECT oe_xsd.cpdm,oe_xsd.ckdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND oe_xsd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY oe_xsd.cpdm,oe_xsd.ckdm) qcxsck ON cpnc.cpdm = qcxsck.cpdm AND cpnc.ckdm = qcxsck.ckdm" & _
                        " Left join (SELECT inv_ckd.cpdm,inv_ckd.ckdm,sum(inv_ckd.sl) as qcckcksl,sum(inv_ckd.je) as qcckckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND inv_ckd.ckrq >= ? and inv_ckd.ckrq >= ? and inv_ckd.ckrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_ckd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_ckd.cpdm,inv_ckd.ckdm) qcckck ON cpnc.cpdm = qcckck.cpdm AND cpnc.ckdm = qcckck.ckdm" & _
                        " Left join (SELECT inv_dbd.cpdm,inv_dbd.cckdm AS ckdm,sum(inv_dbd.sl) as qcdbcksl,sum(inv_dbd.je) as qcdbckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.cckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_dbd.cpdm,inv_dbd.cckdm) qcdbck ON cpnc.cpdm = qcdbck.cpdm AND cpnc.ckdm = qcdbck.ckdm) asfchz LEFT JOIN rc_cpxx ON asfchz.cpdm = rc_cpxx.cpdm LEFT JOIN rc_ckxx ON asfchz.ckdm = rc_ckxx.ckdm) bsfchz WHERE (0=0)" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " and cpdm LIKE '" & Trim(TxtCpdm.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpmc.Text), " AND cpmc LIKE '%" & TxtCpmc.Text & "%'", "")
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dInvBegin1.Date
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePcrq
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dInvBegin1.Date
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePcrq
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dInvBegin1.Date
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePcrq
                    rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dInvBegin1.Date
                    rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = datePcrq
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dInvBegin1.Date
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = datePcrq
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dInvBegin1.Date
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePcrq
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    Me.LblMsg.Text = "正在生成" & (Me.NudMonth.Value - rcDataset.Tables("rc_kczlfd").Rows(i - 1).Item("zhangling")).ToString & "月库存数据......"
                    rcOleDbCommand.CommandText = "UPDATE t_cpkczlfx SET (kcsl_" & i.ToString.PadLeft(2, "0") & ",kcje_" & i.ToString.PadLeft(2, "0") & ") = " & _
                        " (SELECT CASE WHEN COALESCE(bsfchz.qcsl,0.0)+COALESCE(bsfchz.qcscrksl,0.0)+COALESCE(bsfchz.qccgrksl,0.0)+COALESCE(bsfchz.qcdbrksl,0.0)-COALESCE(bsfchz.qcxscksl,0.0)-COALESCE(bsfchz.qcckcksl,0.0)-COALESCE(bsfchz.qcdbcksl,0.0) > 0 THEN COALESCE(bsfchz.qcsl,0.0)+COALESCE(bsfchz.qcscrksl,0.0)+COALESCE(bsfchz.qccgrksl,0.0)+COALESCE(bsfchz.qcdbrksl,0.0)-COALESCE(bsfchz.qcxscksl,0.0)-COALESCE(bsfchz.qcckcksl,0.0)-COALESCE(bsfchz.qcdbcksl,0.0) ELSE 0 END AS kcsl_tot,CASE WHEN COALESCE(bsfchz.qcje,0.0)+COALESCE(bsfchz.qcscrkje,0.0)+COALESCE(bsfchz.qccgrkje,0.0)+COALESCE(bsfchz.qcdbrkje,0.0)-COALESCE(bsfchz.qcxsckje,0.0)-COALESCE(bsfchz.qcckckje,0.0)-COALESCE(bsfchz.qcdbckje,0.0) > 0 THEN COALESCE(bsfchz.qcje,0.0)+COALESCE(bsfchz.qcscrkje,0.0)+COALESCE(bsfchz.qccgrkje,0.0)+COALESCE(bsfchz.qcdbrkje,0.0)-COALESCE(bsfchz.qcxsckje,0.0)-COALESCE(bsfchz.qcckckje,0.0)-COALESCE(bsfchz.qcdbckje,0.0) ELSE 0 END AS kcje_tot FROM" & _
                        " (SELECT asfchz.*,rc_cpxx.cpmc,rc_cpxx.dw,rc_cpxx.lbdm,rc_ckxx.ckmc FROM" & _
                        " (SELECT cpnc.cpdm,cpnc.ckdm,cpnc.qcsl,cpnc.qcje,qcscrk.qcscrksl,qcscrk.qcscrkje,qccgrk.qccgrksl,qccgrk.qccgrkje,qcdbrk.qcdbrksl,qcdbrk.qcdbrkje,qcxsck.qcxscksl,qcxsck.qcxsckje,qcckck.qcckcksl,qcckck.qcckckje,qcdbck.qcdbcksl,qcdbck.qcdbckje FROM" & _
                        " (SELECT inv_cpyeb.cpdm,inv_cpyeb.ckdm,sum(qcsl) as qcsl,sum(qcje) as qcje FROM inv_cpyeb WHERE kjnd = ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_cpyeb.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_cpyeb.cpdm,inv_cpyeb.ckdm) cpnc" & _
                        " Left join (SELECT inv_rkd.cpdm,inv_rkd.ckdm,sum(inv_rkd.sl) as qcscrksl,sum(inv_rkd.je) as qcscrkje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND inv_rkd.rkrq >= ? and inv_rkd.rkrq >= ? and inv_rkd.rkrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_rkd.cpdm,inv_rkd.ckdm) qcscrk ON cpnc.cpdm = qcscrk.cpdm AND cpnc.ckdm = qcscrk.ckdm" & _
                        " Left join (SELECT po_rkd.cpdm,po_rkd.ckdm,sum(po_rkd.sl) as qccgrksl,sum(po_rkd.je) as qccgrkje FROM po_rkd WHERE po_rkd.bdelete = 0 AND po_rkd.rkrq >= ? and po_rkd.rkrq >= ? and po_rkd.rkrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND po_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY po_rkd.cpdm,po_rkd.ckdm) qccgrk ON cpnc.cpdm = qccgrk.cpdm AND cpnc.ckdm = qccgrk.ckdm" & _
                        " Left join (SELECT inv_dbd.cpdm,inv_dbd.rckdm AS ckdm,sum(inv_dbd.sl) as qcdbrksl,sum(inv_dbd.je) as qcdbrkje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.rckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_dbd.cpdm,inv_dbd.rckdm) qcdbrk ON cpnc.cpdm = qcdbrk.cpdm AND cpnc.ckdm = qcdbrk.ckdm" & _
                        " Left join (SELECT oe_xsd.cpdm,oe_xsd.ckdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND oe_xsd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY oe_xsd.cpdm,oe_xsd.ckdm) qcxsck ON cpnc.cpdm = qcxsck.cpdm AND cpnc.ckdm = qcxsck.ckdm" & _
                        " Left join (SELECT inv_ckd.cpdm,inv_ckd.ckdm,sum(inv_ckd.sl) as qcckcksl,sum(inv_ckd.je) as qcckckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND inv_ckd.ckrq >= ? and inv_ckd.ckrq >= ? and inv_ckd.ckrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_ckd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_ckd.cpdm,inv_ckd.ckdm) qcckck ON cpnc.cpdm = qcckck.cpdm AND cpnc.ckdm = qcckck.ckdm" & _
                        " Left join (SELECT inv_dbd.cpdm,inv_dbd.cckdm AS ckdm,sum(inv_dbd.sl) as qcdbcksl,sum(inv_dbd.je) as qcdbckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.cckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_dbd.cpdm,inv_dbd.cckdm) qcdbck ON cpnc.cpdm = qcdbck.cpdm AND cpnc.ckdm = qcdbck.ckdm) asfchz LEFT JOIN rc_cpxx ON asfchz.cpdm = rc_cpxx.cpdm LEFT JOIN rc_ckxx ON asfchz.ckdm = rc_ckxx.ckdm) bsfchz WHERE bsfchz.ckdm = t_cpkczlfx.ckdm AND bsfchz.cpdm = t_cpkczlfx.cpdm" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " and cpdm LIKE '" & Trim(TxtCpdm.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpmc.Text), " AND cpmc LIKE '%" & TxtCpmc.Text & "%'", "") & ")"
                    rcOleDbCommand.Parameters.Clear()
                    'rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                    If i = rcDataset.Tables("rc_kczlfd").Rows.Count And i > 1 Then
                        rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = datePcrq.AddDays(1).AddMonths(-1 - rcDataset.Tables("rc_kczlfd").Rows(i - 2).Item("zhangling")).AddDays(-1).Year
                    Else
                        rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = datePcrq.AddDays(1).AddMonths(0 - rcDataset.Tables("rc_kczlfd").Rows(i - 1).Item("zhangling")).AddDays(-1).Year
                    End If
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    'rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dInvBegin1.Date
                    If i = rcDataset.Tables("rc_kczlfd").Rows.Count And i > 1 Then
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = Convert.ToDateTime(datePcrq.AddDays(1).AddMonths(-1 - rcDataset.Tables("rc_kczlfd").Rows(i - 2).Item("zhangling")).AddDays(-1).Year.ToString + "-01-01")
                    Else
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = Convert.ToDateTime(datePcrq.AddDays(1).AddMonths(0 - rcDataset.Tables("rc_kczlfd").Rows(i - 1).Item("zhangling")).AddDays(-1).Year.ToString + "-01-01")
                    End If
                    If i = rcDataset.Tables("rc_kczlfd").Rows.Count And i > 1 Then
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePcrq.AddDays(1).AddMonths(-1 - rcDataset.Tables("rc_kczlfd").Rows(i - 2).Item("zhangling")).AddDays(-1)
                    Else
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePcrq.AddDays(1).AddMonths(0 - rcDataset.Tables("rc_kczlfd").Rows(i - 1).Item("zhangling")).AddDays(-1)
                    End If
                    rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    'rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dInvBegin1.Date
                    If i = rcDataset.Tables("rc_kczlfd").Rows.Count And i > 1 Then
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = Convert.ToDateTime(datePcrq.AddDays(1).AddMonths(-1 - rcDataset.Tables("rc_kczlfd").Rows(i - 2).Item("zhangling")).AddDays(-1).Year.ToString + "-01-01")
                    Else
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = Convert.ToDateTime(datePcrq.AddDays(1).AddMonths(0 - rcDataset.Tables("rc_kczlfd").Rows(i - 1).Item("zhangling")).AddDays(-1).Year.ToString + "-01-01")
                    End If
                    If i = rcDataset.Tables("rc_kczlfd").Rows.Count And i > 1 Then
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePcrq.AddDays(1).AddMonths(-1 - rcDataset.Tables("rc_kczlfd").Rows(i - 2).Item("zhangling")).AddDays(-1)
                    Else
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePcrq.AddDays(1).AddMonths(0 - rcDataset.Tables("rc_kczlfd").Rows(i - 1).Item("zhangling")).AddDays(-1)
                    End If
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    'rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dInvBegin1.Date
                    If i = rcDataset.Tables("rc_kczlfd").Rows.Count And i > 1 Then
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = Convert.ToDateTime(datePcrq.AddDays(1).AddMonths(-1 - rcDataset.Tables("rc_kczlfd").Rows(i - 2).Item("zhangling")).AddDays(-1).Year.ToString + "-01-01")
                    Else
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = Convert.ToDateTime(datePcrq.AddDays(1).AddMonths(0 - rcDataset.Tables("rc_kczlfd").Rows(i - 1).Item("zhangling")).AddDays(-1).Year.ToString + "-01-01")
                    End If
                    If i = rcDataset.Tables("rc_kczlfd").Rows.Count And i > 1 Then
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePcrq.AddDays(1).AddMonths(-1 - rcDataset.Tables("rc_kczlfd").Rows(i - 2).Item("zhangling")).AddDays(-1)
                    Else
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePcrq.AddDays(1).AddMonths(0 - rcDataset.Tables("rc_kczlfd").Rows(i - 1).Item("zhangling")).AddDays(-1)
                    End If
                    rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    'rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dInvBegin1.Date
                    If i = rcDataset.Tables("rc_kczlfd").Rows.Count And i > 1 Then
                        rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = Convert.ToDateTime(datePcrq.AddDays(1).AddMonths(-1 - rcDataset.Tables("rc_kczlfd").Rows(i - 2).Item("zhangling")).AddDays(-1).Year.ToString + "-01-01")
                    Else
                        rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = Convert.ToDateTime(datePcrq.AddDays(1).AddMonths(0 - rcDataset.Tables("rc_kczlfd").Rows(i - 1).Item("zhangling")).AddDays(-1).Year.ToString + "-01-01")
                    End If
                    rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = datePcrq
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    'rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dInvBegin1.Date
                    If i = rcDataset.Tables("rc_kczlfd").Rows.Count And i > 1 Then
                        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Convert.ToDateTime(datePcrq.AddDays(1).AddMonths(-1 - rcDataset.Tables("rc_kczlfd").Rows(i - 2).Item("zhangling")).AddDays(-1).Year.ToString + "-01-01")
                    Else
                        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Convert.ToDateTime(datePcrq.AddDays(1).AddMonths(0 - rcDataset.Tables("rc_kczlfd").Rows(i - 1).Item("zhangling")).AddDays(-1).Year.ToString + "-01-01")
                    End If
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = datePcrq
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    'rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dInvBegin1.Date
                    If i = rcDataset.Tables("rc_kczlfd").Rows.Count And i > 1 Then
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = Convert.ToDateTime(datePcrq.AddDays(1).AddMonths(-1 - rcDataset.Tables("rc_kczlfd").Rows(i - 2).Item("zhangling")).AddDays(-1).Year.ToString + "-01-01")
                    Else
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = Convert.ToDateTime(datePcrq.AddDays(1).AddMonths(0 - rcDataset.Tables("rc_kczlfd").Rows(i - 1).Item("zhangling")).AddDays(-1).Year.ToString + "-01-01")
                    End If
                    rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePcrq
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            Next
            '更新成期间库存
            For i = rcDataset.Tables("rc_kczlfd").Rows.Count To 1 Step -1
                If i = 1 Then
                    rcOleDbCommand.CommandText = "UPDATE t_cpkczlfx SET t_cpkczlfx.kcsl_" & i.ToString.PadLeft(2, "0") & " = COALESCE(t_cpkczlfx.kcsl_tot" & ",0.0) - COALESCE(t_cpkczlfx.kcsl_" & i.ToString.PadLeft(2, "0") & ",0.0), t_cpkczlfx.kcje_" & i.ToString.PadLeft(2, "0") & " = COALESCE(t_cpkczlfx.kcje_tot,0.0)" & " - COALESCE(t_cpkczlfx.kcje_" & i.ToString.PadLeft(2, "0") & ",0.0)"
                Else
                    rcOleDbCommand.CommandText = "UPDATE t_cpkczlfx SET t_cpkczlfx.kcsl_" & i.ToString.PadLeft(2, "0") & " = COALESCE(t_cpkczlfx.kcsl_" & (i - 1).ToString.PadLeft(2, "0") & ",0.0) - COALESCE(t_cpkczlfx.kcsl_" & i.ToString.PadLeft(2, "0") & ",0.0),t_cpkczlfx.kcje_" & i.ToString.PadLeft(2, "0") & " = COALESCE(t_cpkczlfx.kcje_" & (i - 1).ToString.PadLeft(2, "0") & ",0.0) - COALESCE(t_cpkczlfx.kcje_" & i.ToString.PadLeft(2, "0") & ",0.0)"
                End If
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Next
            rcOleDbCommand.CommandText = "SELECT t_cpkczlfx.cpdm,rc_cpxx.cpmc,rc_cpxx.dw,t_cpkczlfx.ckdm,rc_ckxx.ckmc,t_cpkczlfx.kcsl_tot,t_cpkczlfx.kcje_tot,t_cpkczlfx.kcsl_01,t_cpkczlfx.kcje_01,t_cpkczlfx.kcsl_02,t_cpkczlfx.kcje_02,t_cpkczlfx.kcsl_03,t_cpkczlfx.kcje_03,t_cpkczlfx.kcsl_04,t_cpkczlfx.kcje_04,t_cpkczlfx.kcsl_05,t_cpkczlfx.kcje_05,t_cpkczlfx.kcsl_06,t_cpkczlfx.kcje_06,t_cpkczlfx.kcsl_07,t_cpkczlfx.kcje_07 FROM t_cpkczlfx left join RC_CPXX on RC_CPXX.CPDM = T_CPKCZLFX.CPDM LEFT JOIN rc_ckxx ON rc_ckxx.ckdm = t_cpkczlfx.ckdm ORDER BY cpdm,ckdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("cpsfchz") IsNot Nothing Then
                rcDataset.Tables("cpsfchz").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "cpsfchz")
            rcOleDbTrans.Commit()
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("cpsfchz").Rows.Count > 0 Then
            Me.ProgressBar1.Maximum = rcDataset.Tables("cpsfchz").Rows.Count - 1
        End If
        If Me.ChbYe.Checked Then
            For i = 0 To rcDataset.Tables("cpsfchz").Rows.Count - 1
                Me.ProgressBar1.Value = i
                If rcDataset.Tables("cpsfchz").Rows(i).Item("kcsl_tot") = 0 And rcDataset.Tables("cpsfchz").Rows(i).Item("kcje_tot") = 0 Then
                    rcDataset.Tables("cpsfchz").Rows(i).Delete()
                End If
            Next
        End If
        Dim rcDataRow As DataRow
        rcDataRow = rcDataset.Tables("cpsfchz").NewRow
        rcDataRow.Item("cpdm") = "合计"
        rcDataRow.Item("kcsl_tot") = rcDataset.Tables("cpsfchz").Compute("Sum(kcsl_tot)", "")
        rcDataRow.Item("kcje_tot") = rcDataset.Tables("cpsfchz").Compute("Sum(kcje_tot)", "")
        For i = 0 To rcDataset.Tables("rc_kczlfd").Rows.Count - 1
            rcDataRow.Item("kcsl_" & (i + 1).ToString.PadLeft(2, "0")) = rcDataset.Tables("cpsfchz").Compute("Sum(kcsl_" & (i + 1).ToString.PadLeft(2, "0") & ")", "")
            rcDataRow.Item("kcje_" & (i + 1).ToString.PadLeft(2, "0")) = rcDataset.Tables("cpsfchz").Compute("Sum(kcje_" & (i + 1).ToString.PadLeft(2, "0") & ")", "")
        Next
        rcDataset.Tables("cpsfchz").Rows.Add(rcDataRow)

        '调用表单
        Dim rcFrm As New FrmCpkcZlfxz
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("cpsfchz"), "TRUE", "cpdm,ckdm", DataViewRowState.CurrentRows)
            '.Label2.Text = "盘点日期：" & Me.DtpPcrq.Value
            .Label3.Text = "仓库：" & Trim(Me.TxtCkdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class