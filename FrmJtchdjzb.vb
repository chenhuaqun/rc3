Imports System.Data.OleDb

Public Class FrmJtchdjzb
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '数据OleDb更新传递
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '数据视图
    ReadOnly rcDataView As DataView
    '建立Datatable '我们要利用该datatable进行金额计算
    ReadOnly dtCkxx As New DataTable("ckxx")

    Private Sub FrmJtchdjzb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        Me.NudYear.Value = Mid(g_Kjqj, 1, 4)
        Me.NudMonth.Value = Mid(g_Kjqj, 5, 2)

        '数据绑定
        dtCkxx.Columns.Add("xz", Type.GetType("System.Boolean"))
        dtCkxx.Columns.Add("ckdm", Type.GetType("System.String"))
        dtCkxx.Columns.Add("ckmc", Type.GetType("System.String"))
        rcDataset.Tables.Add(dtCkxx)
        With dtCkxx
            .Columns("xz").DefaultValue = 0
            .Columns("ckdm").DefaultValue = ""
            .Columns("ckmc").DefaultValue = ""
        End With
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT 0 AS xz,ckdm,ckmc FROM rc_ckxx ORDER BY ckdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("ckxx") IsNot Nothing Then
                rcDataset.Tables("ckxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "ckxx")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '绑定数据the DataGrid to the DataSet.
        Me.rcBindingSource.DataSource = dtCkxx
        Me.rcDataGridView.DataSource = Me.rcBindingSource
    End Sub

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NudYear.KeyPress, NudMonth.KeyPress, TxtCkdm.KeyPress, TxtFadm.KeyPress
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
        Dim j As Integer
        If String.IsNullOrEmpty(Me.TxtFadm.Text) Then
            MsgBox("请选择库存账龄方案。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        Dim strExpCkdm As String = ""
        Dim strExpRckdm As String = ""
        Dim strExpCckdm As String = ""
        '库存仓库条件
        For i = 0 To dtCkxx.Rows.Count - 1
            If dtCkxx.Rows(i).Item("xz") Then
                strExpCkdm += IIf(j = 0, " AND (", " OR") + " ckdm = '" + dtCkxx.Rows(i).Item("ckdm") & "'"
                strExpRckdm += IIf(j = 0, " AND (", " OR") + " rckdm = '" + dtCkxx.Rows(i).Item("ckdm") & "'"
                strExpCckdm += IIf(j = 0, " AND (", " OR") + " cckdm = '" + dtCkxx.Rows(i).Item("ckdm") & "'"
                j += 1
            End If
        Next
        If Not String.IsNullOrEmpty(strExpCkdm) Then
            strExpCkdm += ")"
            strExpRckdm += ")"
            strExpCckdm += ")"
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
            rcOleDbCommand.CommandText = "SELECT * FROM user_tables WHERE table_name='T_JTCHDJZB'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count = 0 Then
                rcOleDbCommand.CommandText = "Create Global Temporary Table t_jtchdjzb (cpdm varchar2(15),kcsl number(18,6),kcje number(14,2),kcsl_tot number(18,6),kcje_tot number(14,2),kcsl_01 number(18,6),kcje_01 number(14,2),jitibilv_01 number(6,2),jitije_01 number(14,2),kcsl_02 number(18,6),kcje_02 number(14,2),jitibilv_02 number(6,2),jitije_02 number(14,2),kcsl_03 number(18,6),kcje_03 number(14,2),jitibilv_03 number(6,2),jitije_03 number(14,2),kcsl_04 number(18,6),kcje_04 number(14,2),jitibilv_04 number(6,2),jitije_04 number(14,2),kcsl_05 number(18,6),kcje_05 number(14,2),jitibilv_05 number(6,2),jitije_05 number(14,2),kcsl_06 number(18,6),kcje_06 number(14,2),jitibilv_06 number(6,2),jitije_06 number(14,2),kcsl_07 number(18,6),kcje_07 number(14,2),jitibilv_07 number(6,2),jitije_07 number(14,2)) on Commit delete Rows"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "alter table T_JTCHDJZB  add constraint PK_JTCHDJZB primary key (CPDM)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            End If
            Me.LblMsg.Text = "正在生成库存账龄分析表......"
            '插入库存数据
            For i = 0 To rcDataset.Tables("rc_kczlfd").Rows.Count
                If i = 0 Then
                    Me.LblMsg.Text = "正在生成" & Me.NudMonth.Value.ToString & "月库存数据......"
                    rcOleDbCommand.CommandText = "INSERT INTO t_jtchdjzb (cpdm,kcsl,kcje)" & _
                        " SELECT asfchz.cpdm,COALESCE(asfchz.qcsl,0.0)+COALESCE(asfchz.qcscrksl,0.0)+COALESCE(asfchz.qccgrksl,0.0)+COALESCE(asfchz.qcdbrksl,0.0)-COALESCE(asfchz.qcxscksl,0.0)-COALESCE(asfchz.qcckcksl,0.0)-COALESCE(asfchz.qcdbcksl,0.0) AS kcsl_tot,COALESCE(asfchz.qcje,0.0)+COALESCE(asfchz.qcscrkje,0.0)+COALESCE(asfchz.qccgrkje,0.0)+COALESCE(asfchz.qcdbrkje,0.0)-COALESCE(asfchz.qcxsckje,0.0)-COALESCE(asfchz.qcckckje,0.0)-COALESCE(asfchz.qcdbckje,0.0) AS kcje_tot FROM" & _
                        " (SELECT cpnc.cpdm,cpnc.qcsl,cpnc.qcje,qcscrk.qcscrksl,qcscrk.qcscrkje,qccgrk.qccgrksl,qccgrk.qccgrkje,qcdbrk.qcdbrksl,qcdbrk.qcdbrkje,qcxsck.qcxscksl,qcxsck.qcxsckje,qcckck.qcckcksl,qcckck.qcckckje,qcdbck.qcdbcksl,qcdbck.qcdbckje FROM" & _
                        " (SELECT inv_cpyeb.cpdm,sum(qcsl) as qcsl,sum(qcje) as qcje FROM inv_cpyeb WHERE kjnd = ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_cpyeb.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_cpyeb.cpdm) cpnc" & _
                        " Left join (SELECT inv_rkd.cpdm,sum(inv_rkd.sl) as qcscrksl,sum(inv_rkd.je) as qcscrkje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND inv_rkd.rkrq >= ? and inv_rkd.rkrq >= ? and inv_rkd.rkrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_rkd.cpdm) qcscrk ON cpnc.cpdm = qcscrk.cpdm" & _
                        " Left join (SELECT po_rkd.cpdm,sum(po_rkd.sl) as qccgrksl,sum(po_rkd.je) as qccgrkje FROM po_rkd WHERE po_rkd.bdelete = 0 AND po_rkd.rkrq >= ? and po_rkd.rkrq >= ? and po_rkd.rkrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND po_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY po_rkd.cpdm) qccgrk ON cpnc.cpdm = qccgrk.cpdm" & _
                        " Left join (SELECT inv_dbd.cpdm,sum(inv_dbd.sl) as qcdbrksl,sum(inv_dbd.je) as qcdbrkje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.rckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_dbd.cpdm) qcdbrk ON cpnc.cpdm = qcdbrk.cpdm" & _
                        " Left join (SELECT oe_xsd.cpdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND oe_xsd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY oe_xsd.cpdm) qcxsck ON cpnc.cpdm = qcxsck.cpdm" & _
                        " Left join (SELECT inv_ckd.cpdm,sum(inv_ckd.sl) as qcckcksl,sum(inv_ckd.je) as qcckckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND inv_ckd.ckrq >= ? and inv_ckd.ckrq >= ? and inv_ckd.ckrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_ckd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_ckd.cpdm) qcckck ON cpnc.cpdm = qcckck.cpdm" & _
                        " Left join (SELECT inv_dbd.cpdm,sum(inv_dbd.sl) as qcdbcksl,sum(inv_dbd.je) as qcdbckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.cckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_dbd.cpdm) qcdbck ON cpnc.cpdm = qcdbck.cpdm) asfchz"
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
                    rcOleDbCommand.CommandText = "UPDATE t_jtchdjzb SET (kcsl_tot,kcje_tot) = " & _
                        " (SELECT COALESCE(asfchz.qcsl,0.0)+COALESCE(asfchz.qcscrksl,0.0)+COALESCE(asfchz.qccgrksl,0.0)+COALESCE(asfchz.qcdbrksl,0.0)-COALESCE(asfchz.qcxscksl,0.0)-COALESCE(asfchz.qcckcksl,0.0)-COALESCE(asfchz.qcdbcksl,0.0) AS kcsl_tot,COALESCE(asfchz.qcje,0.0)+COALESCE(asfchz.qcscrkje,0.0)+COALESCE(asfchz.qccgrkje,0.0)+COALESCE(asfchz.qcdbrkje,0.0)-COALESCE(asfchz.qcxsckje,0.0)-COALESCE(asfchz.qcckckje,0.0)-COALESCE(asfchz.qcdbckje,0.0) AS kcje_tot FROM" & _
                        " (SELECT cpnc.cpdm,cpnc.qcsl,cpnc.qcje,qcscrk.qcscrksl,qcscrk.qcscrkje,qccgrk.qccgrksl,qccgrk.qccgrkje,qcdbrk.qcdbrksl,qcdbrk.qcdbrkje,qcxsck.qcxscksl,qcxsck.qcxsckje,qcckck.qcckcksl,qcckck.qcckckje,qcdbck.qcdbcksl,qcdbck.qcdbckje FROM" & _
                        " (SELECT inv_cpyeb.cpdm,sum(qcsl) as qcsl,sum(qcje) as qcje FROM inv_cpyeb WHERE kjnd = ?" & strExpCkdm & " GROUP BY inv_cpyeb.cpdm) cpnc" & _
                        " Left join (SELECT inv_rkd.cpdm,sum(inv_rkd.sl) as qcscrksl,sum(inv_rkd.je) as qcscrkje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND inv_rkd.rkrq >= ? and inv_rkd.rkrq >= ? and inv_rkd.rkrq < ?" & strExpCkdm & " GROUP BY inv_rkd.cpdm) qcscrk ON cpnc.cpdm = qcscrk.cpdm" & _
                        " Left join (SELECT po_rkd.cpdm,sum(po_rkd.sl) as qccgrksl,sum(po_rkd.je) as qccgrkje FROM po_rkd WHERE po_rkd.bdelete = 0 AND po_rkd.rkrq >= ? and po_rkd.rkrq >= ? and po_rkd.rkrq < ?" & strExpCkdm & " GROUP BY po_rkd.cpdm) qccgrk ON cpnc.cpdm = qccgrk.cpdm" & _
                        " Left join (SELECT inv_dbd.cpdm,sum(inv_dbd.sl) as qcdbrksl,sum(inv_dbd.je) as qcdbrkje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ?" & strExpRckdm & " GROUP BY inv_dbd.cpdm) qcdbrk ON cpnc.cpdm = qcdbrk.cpdm" & _
                        " Left join (SELECT oe_xsd.cpdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq < ?" & strExpCkdm & " GROUP BY oe_xsd.cpdm) qcxsck ON cpnc.cpdm = qcxsck.cpdm" & _
                        " Left join (SELECT inv_ckd.cpdm,sum(inv_ckd.sl) as qcckcksl,sum(inv_ckd.je) as qcckckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND inv_ckd.ckrq >= ? and inv_ckd.ckrq >= ? and inv_ckd.ckrq < ?" & strExpCkdm & " GROUP BY inv_ckd.cpdm) qcckck ON cpnc.cpdm = qcckck.cpdm" & _
                        " Left join (SELECT inv_dbd.cpdm,sum(inv_dbd.sl) as qcdbcksl,sum(inv_dbd.je) as qcdbckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ?" & strExpCckdm & " GROUP BY inv_dbd.cpdm) qcdbck ON cpnc.cpdm = qcdbck.cpdm) asfchz WHERE asfchz.cpdm = t_jtchdjzb.cpdm)"
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
                    If i < rcDataset.Tables("rc_kczlfd").Rows.Count Then
                        rcOleDbCommand.CommandText = "UPDATE t_jtchdjzb SET (kcsl_" & i.ToString.PadLeft(2, "0") & ",kcje_" & i.ToString.PadLeft(2, "0") & ") = " & _
                            " (SELECT CASE WHEN COALESCE(asfchz.qcsl,0.0)+COALESCE(asfchz.qcscrksl,0.0)+COALESCE(asfchz.qccgrksl,0.0)+COALESCE(asfchz.qcdbrksl,0.0)-COALESCE(asfchz.qcxscksl,0.0)-COALESCE(asfchz.qcckcksl,0.0)-COALESCE(asfchz.qcdbcksl,0.0) > 0 THEN COALESCE(asfchz.qcsl,0.0)+COALESCE(asfchz.qcscrksl,0.0)+COALESCE(asfchz.qccgrksl,0.0)+COALESCE(asfchz.qcdbrksl,0.0)-COALESCE(asfchz.qcxscksl,0.0)-COALESCE(asfchz.qcckcksl,0.0)-COALESCE(asfchz.qcdbcksl,0.0) ELSE 0 END AS kcsl_tot,CASE WHEN COALESCE(asfchz.qcje,0.0)+COALESCE(asfchz.qcscrkje,0.0)+COALESCE(asfchz.qccgrkje,0.0)+COALESCE(asfchz.qcdbrkje,0.0)-COALESCE(asfchz.qcxsckje,0.0)-COALESCE(asfchz.qcckckje,0.0)-COALESCE(asfchz.qcdbckje,0.0) > 0 THEN COALESCE(asfchz.qcje,0.0)+COALESCE(asfchz.qcscrkje,0.0)+COALESCE(asfchz.qccgrkje,0.0)+COALESCE(asfchz.qcdbrkje,0.0)-COALESCE(asfchz.qcxsckje,0.0)-COALESCE(asfchz.qcckckje,0.0)-COALESCE(asfchz.qcdbckje,0.0) ELSE 0 END AS kcje_tot FROM" & _
                            " (SELECT cpnc.cpdm,cpnc.qcsl,cpnc.qcje,qcscrk.qcscrksl,qcscrk.qcscrkje,qccgrk.qccgrksl,qccgrk.qccgrkje,qcdbrk.qcdbrksl,qcdbrk.qcdbrkje,qcxsck.qcxscksl,qcxsck.qcxsckje,qcckck.qcckcksl,qcckck.qcckckje,qcdbck.qcdbcksl,qcdbck.qcdbckje FROM" & _
                            " (SELECT inv_cpyeb.cpdm,sum(qcsl) as qcsl,sum(qcje) as qcje FROM inv_cpyeb WHERE kjnd = ?" & strExpCkdm & " GROUP BY inv_cpyeb.cpdm) cpnc" & _
                            " Left join (SELECT inv_rkd.cpdm,sum(inv_rkd.sl) as qcscrksl,sum(inv_rkd.je) as qcscrkje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND inv_rkd.rkrq >= ? and inv_rkd.rkrq >= ? and inv_rkd.rkrq < ?" & strExpCkdm & " GROUP BY inv_rkd.cpdm) qcscrk ON cpnc.cpdm = qcscrk.cpdm" & _
                            " Left join (SELECT po_rkd.cpdm,sum(po_rkd.sl) as qccgrksl,sum(po_rkd.je) as qccgrkje FROM po_rkd WHERE po_rkd.bdelete = 0 AND po_rkd.rkrq >= ? and po_rkd.rkrq >= ? and po_rkd.rkrq < ?" & strExpCkdm & " GROUP BY po_rkd.cpdm) qccgrk ON cpnc.cpdm = qccgrk.cpdm" & _
                            " Left join (SELECT inv_dbd.cpdm,sum(inv_dbd.sl) as qcdbrksl,sum(inv_dbd.je) as qcdbrkje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ?" & strExpRckdm & " GROUP BY inv_dbd.cpdm) qcdbrk ON cpnc.cpdm = qcdbrk.cpdm" & _
                            " Left join (SELECT oe_xsd.cpdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq < ?" & strExpCkdm & " GROUP BY oe_xsd.cpdm) qcxsck ON cpnc.cpdm = qcxsck.cpdm" & _
                            " Left join (SELECT inv_ckd.cpdm,sum(inv_ckd.sl) as qcckcksl,sum(inv_ckd.je) as qcckckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND inv_ckd.ckrq >= ? and inv_ckd.ckrq >= ? and inv_ckd.ckrq < ?" & strExpCkdm & " GROUP BY inv_ckd.cpdm) qcckck ON cpnc.cpdm = qcckck.cpdm" & _
                            " Left join (SELECT inv_dbd.cpdm,sum(inv_dbd.sl) as qcdbcksl,sum(inv_dbd.je) as qcdbckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ?" & strExpCckdm & " GROUP BY inv_dbd.cpdm) qcdbck ON cpnc.cpdm = qcdbck.cpdm) asfchz WHERE asfchz.cpdm = t_jtchdjzb.cpdm" & ")"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dInvBegin1.Date
                        If i = rcDataset.Tables("rc_kczlfd").Rows.Count And i > 1 Then
                            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePcrq.AddDays(1).AddMonths(-1 - rcDataset.Tables("rc_kczlfd").Rows(i - 2).Item("zhangling")).AddDays(-1)
                        Else
                            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePcrq.AddDays(1).AddMonths(0 - rcDataset.Tables("rc_kczlfd").Rows(i - 1).Item("zhangling")).AddDays(-1)
                        End If
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dInvBegin1.Date
                        If i = rcDataset.Tables("rc_kczlfd").Rows.Count And i > 1 Then
                            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePcrq.AddDays(1).AddMonths(-1 - rcDataset.Tables("rc_kczlfd").Rows(i - 2).Item("zhangling")).AddDays(-1)
                        Else
                            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePcrq.AddDays(1).AddMonths(0 - rcDataset.Tables("rc_kczlfd").Rows(i - 1).Item("zhangling")).AddDays(-1)
                        End If
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dInvBegin1.Date
                        If i = rcDataset.Tables("rc_kczlfd").Rows.Count And i > 1 Then
                            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePcrq.AddDays(1).AddMonths(-1 - rcDataset.Tables("rc_kczlfd").Rows(i - 2).Item("zhangling")).AddDays(-1)
                        Else
                            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePcrq.AddDays(1).AddMonths(0 - rcDataset.Tables("rc_kczlfd").Rows(i - 1).Item("zhangling")).AddDays(-1)
                        End If
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
                    End If
                    rcOleDbCommand.CommandText = "UPDATE t_jtchdjzb SET jitibilv_" & i.ToString.PadLeft(2, "0") & " = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@jitibilv", OleDbType.Numeric, 6).Value = rcDataset.Tables("rc_kczlfd").Rows(i - 1).Item("jitibilv")
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            Next
            '更新成期间库存
            Me.LblMsg.Text = "正在更新成期间库存......"
            For i = rcDataset.Tables("rc_kczlfd").Rows.Count To 1 Step -1
                If i = 1 Then
                    rcOleDbCommand.CommandText = "UPDATE t_jtchdjzb SET t_jtchdjzb.kcsl_" & i.ToString.PadLeft(2, "0") & " = COALESCE(t_jtchdjzb.kcsl_tot" & ",0.0) - COALESCE(t_jtchdjzb.kcsl_" & i.ToString.PadLeft(2, "0") & ",0.0), t_jtchdjzb.kcje_" & i.ToString.PadLeft(2, "0") & " = COALESCE(t_jtchdjzb.kcje_tot,0.0)" & " - COALESCE(t_jtchdjzb.kcje_" & i.ToString.PadLeft(2, "0") & ",0.0)"
                Else
                    rcOleDbCommand.CommandText = "UPDATE t_jtchdjzb SET t_jtchdjzb.kcsl_" & i.ToString.PadLeft(2, "0") & " = COALESCE(t_jtchdjzb.kcsl_" & (i - 1).ToString.PadLeft(2, "0") & ",0.0) - COALESCE(t_jtchdjzb.kcsl_" & i.ToString.PadLeft(2, "0") & ",0.0),t_jtchdjzb.kcje_" & i.ToString.PadLeft(2, "0") & " = COALESCE(t_jtchdjzb.kcje_" & (i - 1).ToString.PadLeft(2, "0") & ",0.0) - COALESCE(t_jtchdjzb.kcje_" & i.ToString.PadLeft(2, "0") & ",0.0)"
                End If
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "UPDATE t_jtchdjzb SET jitije_" & i.ToString.PadLeft(2, "0") & " = ROUND(kcje_" & i.ToString.PadLeft(2, "0") & " * jitibilv_" & i.ToString.PadLeft(2, "0") & " / 100,2)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Next
            Me.LblMsg.Text = "正在读取数据......"
            rcOleDbCommand.CommandText = "SELECT t_jtchdjzb.cpdm,rc_cpxx.cpmc,rc_cpxx.dw,t_jtchdjzb.kcsl,t_jtchdjzb.kcje,t_jtchdjzb.kcsl_tot,t_jtchdjzb.kcje_tot,t_jtchdjzb.kcsl_01,t_jtchdjzb.kcje_01,t_jtchdjzb.jitibilv_01,t_jtchdjzb.jitije_01,t_jtchdjzb.kcsl_02,t_jtchdjzb.kcje_02,t_jtchdjzb.jitibilv_02,t_jtchdjzb.jitije_02,t_jtchdjzb.kcsl_03,t_jtchdjzb.kcje_03,t_jtchdjzb.jitibilv_03,t_jtchdjzb.jitije_03,t_jtchdjzb.kcsl_04,t_jtchdjzb.kcje_04,t_jtchdjzb.jitibilv_04,t_jtchdjzb.jitije_04,t_jtchdjzb.kcsl_05,t_jtchdjzb.kcje_05,t_jtchdjzb.jitibilv_05,t_jtchdjzb.jitije_05,t_jtchdjzb.kcsl_06,t_jtchdjzb.kcje_06,t_jtchdjzb.jitibilv_06,t_jtchdjzb.jitije_06,t_jtchdjzb.kcsl_07,t_jtchdjzb.kcje_07,t_jtchdjzb.jitibilv_07,t_jtchdjzb.jitije_07 FROM t_jtchdjzb left join RC_CPXX on RC_CPXX.CPDM = t_jtchdjzb.CPDM ORDER BY cpdm"
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
                If rcDataset.Tables("cpsfchz").Rows(i).Item("kcsl") = 0 And rcDataset.Tables("cpsfchz").Rows(i).Item("kcje") = 0 Then
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
            rcDataRow.Item("jitije_" & (i + 1).ToString.PadLeft(2, "0")) = rcDataset.Tables("cpsfchz").Compute("Sum(jitije_" & (i + 1).ToString.PadLeft(2, "0") & ")", "")
        Next
        rcDataset.Tables("cpsfchz").Rows.Add(rcDataRow)

        '调用表单
        Dim rcFrm As New FrmJtchdjzbz
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("cpsfchz"), "TRUE", "cpdm", DataViewRowState.CurrentRows)
            '.Label2.Text = "盘点日期：" & Me.DtpPcrq.Value
            .Label3.Text = "仓库：" & Trim(Me.TxtCkdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class