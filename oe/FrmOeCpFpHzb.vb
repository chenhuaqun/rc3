Imports System.Data.OleDb

Public Class FrmOeCpFpHzb
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable
    ReadOnly dtOeCpFpHzb As New DataTable("oecpfphzb")
    '按成本域
    Dim bCostRegion As Boolean = False

    Private Sub FrmOeCpFpHzb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '是否按成本域计算成本
        bCostRegion = GetParaValue("是否按成本域计算成本", False)
        If bCostRegion Then
            Me.LblBmdm.Text = "成本域编码："
        Else
            Me.LblBmdm.Text = "部门编码："
        End If
        '默认值
        DtpHzrqBegin.Value = GetInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpHzrqEnd.Value = GetInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '创建datatable
        dtOeCpFpHzb.Columns.Add("cpdm", Type.GetType("System.String"))
        dtOeCpFpHzb.Columns.Add("cpmc", Type.GetType("System.String"))
        dtOeCpFpHzb.Columns.Add("dw", Type.GetType("System.String"))
        dtOeCpFpHzb.Columns.Add("sl", Type.GetType("System.Double"))
        dtOeCpFpHzb.Columns.Add("fzsl", Type.GetType("System.Double"))
        dtOeCpFpHzb.Columns.Add("je", Type.GetType("System.Double"))
        dtOeCpFpHzb.Columns.Add("se", Type.GetType("System.Double"))
        dtOeCpFpHzb.Columns.Add("cbje", Type.GetType("System.Double"))
        dtOeCpFpHzb.Columns.Add("dj", Type.GetType("System.Double"))
        dtOeCpFpHzb.Columns.Add("cbdj", Type.GetType("System.Double"))
        dtOeCpFpHzb.Columns.Add("mle", Type.GetType("System.Double"))
        dtOeCpFpHzb.Columns.Add("mll", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtOeCpFpHzb)
        With dtOeCpFpHzb
            .Columns("cpdm").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("fzsl").DefaultValue = 0.0
            .Columns("je").DefaultValue = 0.0
            .Columns("se").DefaultValue = 0.0
            .Columns("cbje").DefaultValue = 0.0
            .Columns("dj").DefaultValue = 0.0
            .Columns("cbdj").DefaultValue = 0.0
            .Columns("mle").DefaultValue = 0.0
            .Columns("mll").DefaultValue = 0.0
        End With
    End Sub

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
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
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
                TxtLbdm.Text = Trim(rcDataset.Tables("rc_cplb").Rows(0).Item("lbdm"))
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
                If bCostRegion Then
                    Dim rcFrm As New models.FrmF3KeyPress
                    With rcFrm
                        .ParaOleDbConn = rcOleDbConn
                        .ParaTableName = "rc_costregion"
                        .ParaField1 = "crdm"
                        .ParaField2 = "crmc"
                        .ParaField3 = "crsm"
                        .ParaTitle = "成本域"
                        .ParaOldValue = ""
                        .ParaAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            TxtBmdm.Text = Trim(.ParaField1)
                        End If
                    End With
                Else
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
                End If
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtBmdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtBmdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtBmdm.Text) Then
            If bCostRegion Then
                Try
                    rcOleDbConn.Open()
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    rcOleDbCommand.CommandText = "SELECT crdm,crmc FROM rc_costregion WHERE (crdm = ?)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@crdm", OleDbType.VarChar, 12).Value = Trim(TxtBmdm.Text)
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("rc_costregion") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_costregion").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "rc_costregion")
                Catch ex As Exception
                    MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                    Return
                Finally
                    rcOleDbConn.Close()
                End Try
                If rcDataset.Tables("rc_costregion").Rows.Count > 0 Then
                    TxtBmdm.Text = Trim(rcDataset.Tables("rc_costregion").Rows(0).Item("crdm"))
                    'LblBmmc.Text = Trim(rcDataset.Tables("rc_costregion").Rows(0).Item("crmc"))
                Else
                    MsgBox("成本域编码不存在，请按F3键选择。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                    e.Cancel = True
                End If
            Else
                Try
                    rcOleDbConn.Open()
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    rcOleDbCommand.CommandText = "SELECT bmdm,bmmc FROM rc_bmxx WHERE (bmdm = ?)"
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
                    TxtBmdm.Text = Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmdm"))
                    'LblBmmc.Text = Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmmc"))
                Else
                    MsgBox("部门编码不存在，请按F3键选择。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                    e.Cancel = True
                End If
                '检测是否最明细记录
                Try
                    rcOleDbConn.Open()
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    rcOleDbCommand.CommandText = "SELECT COUNT(*) AS gs FROM rc_bmxx WHERE (parentid = ?)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtBmdm.Text)
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("reccnt") IsNot Nothing Then
                        Me.rcDataset.Tables("reccnt").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "reccnt")
                Catch ex As Exception
                    MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                    Return
                Finally
                    rcOleDbConn.Close()
                End Try
                If rcDataset.Tables("reccnt").Rows(0).Item("gs") > 0 Then
                    MsgBox("请输入最明细部门编码。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        ''权限控制
        'Try
        '    rcOleDbConn.Open()
        '    rcOleDbCommand.Connection = rcOleDbConn
        '    rcOleDbCommand.CommandTimeout = 300
        '    rcOleDbCommand.CommandType = CommandType.Text
        '    rcOleDbCommand.CommandText = "select code as bmdm from rc_userqx where righttype = 'BMDM' and User_Account = ?" & IIf(Trim(TxtBmdm.Text).Length > 0, " and code ='" & Trim(TxtBmdm.Text) & "'", "")
        '    rcOleDbCommand.Parameters.Clear()
        '    rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = g_User_Account
        '    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
        '    If rcDataset.Tables("rc_bmxx") IsNot Nothing Then
        '        rcDataset.Tables("rc_bmxx").Clear()
        '    End If
        '    rcOleDbDataAdpt.Fill(rcDataset, "rc_bmxx")
        'Catch ex As Exception
        '    MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        '    Return
        'Finally
        '    rcOleDbConn.Close()
        'End Try
        'Dim strExpBmdm As String = ""
        'Dim strExpCrdm As String = ""
        'Dim j As Integer
        'If rcDataset.Tables("rc_bmxx").Rows.Count = 1 Then
        '    Me.TxtBmdm.Text = Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmdm"))
        '    strExpBmdm = strExpBmdm & " OR bmdm = '" & Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmdm")) & "'"
        'Else
        '    For j = 0 To rcDataset.Tables("rc_bmxx").Rows.Count - 1
        '        strExpBmdm = strExpBmdm & " OR bmdm = '" & Trim(rcDataset.Tables("rc_bmxx").Rows(j).Item("bmdm")) & "'"
        '    Next
        'End If
        'If strExpBmdm.Length = 0 Then
        '    strExpBmdm = " 0=0"
        'End If
        'If strExpBmdm.Length > 0 Then
        '    If strExpBmdm.Substring(0, 3) = " OR" Then
        '        strExpBmdm = strExpBmdm.Substring(3)
        '    End If
        'End If
        'If rcDataset.Tables("rc_bmxx").Rows.Count = 1 Then
        '    Me.TxtBmdm.Text = Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmdm"))
        '    strExpCrdm = strExpCrdm & " OR crdm = '" & Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmdm")) & "'"
        'Else
        '    For j = 0 To rcDataset.Tables("rc_bmxx").Rows.Count - 1
        '        strExpCrdm = strExpCrdm & " OR crdm = '" & Trim(rcDataset.Tables("rc_bmxx").Rows(j).Item("bmdm")) & "'"
        '    Next
        'End If
        'If strExpCrdm.Length = 0 Then
        '    strExpCrdm = " 0=0"
        'End If
        'If strExpCrdm.Length > 0 Then
        '    If strExpCrdm.Substring(0, 3) = " OR" Then
        '        strExpCrdm = strExpCrdm.Substring(3)
        '    End If
        'End If

        'dtOeCpFpHzb.Clear()
        '取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            'If bCostRegion Then
            '    rcOleDbCommand.CommandText = "SELECT oecpfphzbb.cpdm,oecpfphzbb.cpmc,oecpfphzbb.dw,oecpfphzbb.cpweight,oecpfphzbb.bzcb,oecpfphzbb.sl,oecpfphzbb.fzsl,oecpfphzbb.je,oecpfphzbb.se,oecpfphzbb.cbje,oecpfphzbb.dj,oecpfphzbb.cbdj,oecpfphzbb.mle,oecpfphzbb.mll FROM" &
            '        " (SELECT oecpfphzba.*,CASE WHEN oecpfphzba.sl <> 0 THEN oecpfphzba.je / oecpfphzba.sl ELSE 0.0 END AS dj,CASE WHEN oecpfphzba.sl <> 0 THEN oecpfphzba.cbje / oecpfphzba.sl ELSE 0.0 END AS cbdj,(oecpfphzba.je - oecpfphzba.cbje) AS mle,CASE WHEN oecpfphzba.je <> 0 THEN (oecpfphzba.je - oecpfphzba.cbje) / oecpfphzba.je ELSE 0.0 END AS mll,rc_cpxx.cpmc,rc_cpxx.dw,rc_cpxx.lbdm,rc_cpxx.bzcb,rc_cpxx.cpweight FROM" &
            '        " (SELECT oecpfphzbc.cpdm,SUM(oecpfphzbc.sl) AS sl,SUM(oecpfphzbc.fzsl) AS fzsl,SUM(oecpfphzbc.je) AS je,SUM(oecpfphzbc.se) AS se,SUM(oecpfphzbc.cbje) AS cbje FROM" &
            '        " ((SELECT oe_fp.cpdm,oe_fp.sl,oe_fp.fzsl,oe_fp.je,oe_fp.se,oe_fp.cbje FROM oe_fp,rc_lx,rc_cr_ck WHERE oe_fp.ckdm  = rc_cr_ck.ckdm AND (" & strExpCrdm & ") AND SUBSTR(oe_fp.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_fp.djh,5,4) = rc_lx.kjnd AND lxgs = '产品销售单' AND oe_fp.bdelete = 0" & IIf(Me.CheckBox2.Checked, " AND oe_fp.sl <> 0 AND oe_fp.je <> 0", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND rc_cr_ck.crdm = '" & Me.TxtBmdm.Text & "'", "") & " AND fprq >= ? AND fprq >= ? AND fprq <= ?)" &
            '        IIf(Me.CheckBox1.Checked, " UNION ALL (SELECT oe_xsd.cpdm,oe_xsd.sl,oe_xsd.fzsl,oe_xsd.je,oe_xsd.se,oe_xsd.cbje FROM oe_xsd,rc_lx,rc_cr_ck WHERE oe_xsd.ckdm = rc_cr_ck.ckdm AND (" & strExpCrdm & ") AND SUBSTR(oe_xsd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_xsd.djh,5,4) = rc_lx.kjnd AND lxgs = '产品送货单' AND oe_xsd.bdelete = 0" & IIf(Me.CheckBox2.Checked, " AND oe_xsd.sl <> 0 AND oe_xsd.je = 0", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND rc_cr_ck.crdm = '" & Me.TxtBmdm.Text & "'", "") & " AND xsrq >= ? AND xsrq >= ? AND xsrq <= ?)", "") & ") oecpfphzbc GROUP BY oecpfphzbc.cpdm) oecpfphzba LEFT JOIN rc_cpxx ON rc_cpxx.cpdm = oecpfphzba.cpdm) oecpfphzbb" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " WHERE lbdm = '" & Me.TxtLbdm.Text & "'", "")
            'Else
            'rcOleDbCommand.CommandText = "Select oecpfphzbb.cpdm,oecpfphzbb.cpmc,oecpfphzbb.dw,oecpfphzbb.cpweight,oecpfphzbb.bzcb,oecpfphzbb.sl,oecpfphzbb.fzsl,oecpfphzbb.je,oecpfphzbb.se,oecpfphzbb.cbje,oecpfphzbb.dj,oecpfphzbb.cbdj,oecpfphzbb.mle,oecpfphzbb.mll FROM" &
            '        " (Select oecpfphzba.*,Case When oecpfphzba.sl <> 0 Then oecpfphzba.je / oecpfphzba.sl Else 0.0 End As dj,Case When oecpfphzba.sl <> 0 Then oecpfphzba.cbje / oecpfphzba.sl Else 0.0 End As cbdj,(oecpfphzba.je - oecpfphzba.cbje) As mle,Case When oecpfphzba.je <> 0 Then (oecpfphzba.je - oecpfphzba.cbje) / oecpfphzba.je Else 0.0 End As mll,rc_cpxx.cpmc,rc_cpxx.dw,rc_cpxx.lbdm,rc_cpxx.bzcb,rc_cpxx.cpweight FROM" &
            '        " (Select oecpfphzbc.cpdm,SUM(oecpfphzbc.sl) As sl,SUM(oecpfphzbc.fzsl) As fzsl,SUM(oecpfphzbc.je) As je,SUM(oecpfphzbc.se) As se,SUM(oecpfphzbc.cbje) As cbje FROM" &
            '        " ((Select oe_fp.cpdm,oe_fp.sl,oe_fp.fzsl,oe_fp.je,oe_fp.se,oe_fp.cbje FROM oe_fp,rc_lx WHERE (" & strExpBmdm & ") And SUBSTR(oe_fp.djh,1,4) = rc_lx.pzlxdm And SUBSTR(oe_fp.djh,5,4) = rc_lx.kjnd And lxgs = '产品销售单' AND oe_fp.bdelete = 0" & IIf(Me.CheckBox2.Checked, " AND oe_fp.sl <> 0 AND oe_fp.je <> 0", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_fp.bmdm = '" & Me.TxtBmdm.Text & "'", "") & " AND fprq >= ? AND fprq >= ? AND fprq <= ?)" &
            '    IIf(Me.CheckBox1.Checked, " UNION ALL (Select oe_xsd.cpdm,oe_xsd.sl,oe_xsd.fzsl,oe_xsd.je,oe_xsd.se,oe_xsd.cbje FROM oe_xsd,rc_lx WHERE (" & strExpBmdm & ") And SUBSTR(oe_xsd.djh,1,4) = rc_lx.pzlxdm And SUBSTR(oe_xsd.djh,5,4) = rc_lx.kjnd And lxgs = '产品送货单' AND oe_xsd.bdelete = 0" & IIf(Me.CheckBox2.Checked, " AND oe_xsd.sl <> 0 AND oe_xsd.je = 0", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_xsd.bmdm = '" & Me.TxtBmdm.Text & "'", "") & " AND xsrq >= ? AND xsrq >= ? AND xsrq <= ?)", "") & ") oecpfphzbc GROUP BY oecpfphzbc.cpdm) oecpfphzba LEFT JOIN rc_cpxx ON rc_cpxx.cpdm = oecpfphzba.cpdm) oecpfphzbb" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " WHERE lbdm = '" & Me.TxtLbdm.Text & "'", "")
            rcOleDbCommand.CommandText = "Select oecpfphzbb.cpdm,oecpfphzbb.cpmc,oecpfphzbb.dw,oecpfphzbb.cpweight,oecpfphzbb.bzcb,oecpfphzbb.sl,oecpfphzbb.fzsl,oecpfphzbb.je,oecpfphzbb.se,oecpfphzbb.cbje,oecpfphzbb.dj,oecpfphzbb.cbdj,oecpfphzbb.mle,oecpfphzbb.mll FROM" &
                    " (Select oecpfphzba.*,Case When oecpfphzba.sl <> 0 Then oecpfphzba.je / oecpfphzba.sl Else 0.0 End As dj,Case When oecpfphzba.sl <> 0 Then oecpfphzba.cbje / oecpfphzba.sl Else 0.0 End As cbdj,(oecpfphzba.je - oecpfphzba.cbje) As mle,Case When oecpfphzba.je <> 0 Then (oecpfphzba.je - oecpfphzba.cbje) / oecpfphzba.je Else 0.0 End As mll,rc_cpxx.cpmc,rc_cpxx.dw,rc_cpxx.lbdm,rc_cpxx.bzcb,rc_cpxx.cpweight FROM" &
                    " (Select oecpfphzbc.cpdm,SUM(oecpfphzbc.sl) As sl,SUM(oecpfphzbc.fzsl) As fzsl,SUM(oecpfphzbc.je) As je,SUM(oecpfphzbc.se) As se,SUM(oecpfphzbc.cbje) As cbje FROM" &
                    " ((Select oe_fp.cpdm,oe_fp.sl,oe_fp.fzsl,oe_fp.je,oe_fp.se,oe_fp.cbje FROM oe_fp,rc_lx WHERE SUBSTR(oe_fp.djh,1,4) = rc_lx.pzlxdm And SUBSTR(oe_fp.djh,5,4) = rc_lx.kjnd And lxgs = '产品销售单' AND oe_fp.bdelete = 0" & IIf(Me.CheckBox2.Checked, " AND oe_fp.sl <> 0 AND oe_fp.je <> 0", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_fp.bmdm = '" & Me.TxtBmdm.Text & "'", "") & " AND fprq >= ? AND fprq >= ? AND fprq <= ?)" &
                IIf(Me.CheckBox1.Checked, " UNION ALL (Select oe_xsd.cpdm,oe_xsd.sl,oe_xsd.fzsl,oe_xsd.je,oe_xsd.se,oe_xsd.cbje FROM oe_xsd,rc_lx WHERE SUBSTR(oe_xsd.djh,1,4) = rc_lx.pzlxdm And SUBSTR(oe_xsd.djh,5,4) = rc_lx.kjnd And lxgs = '产品送货单' AND oe_xsd.bdelete = 0 AND oe_xsd.sl <> 0 AND oe_xsd.je = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_xsd.bmdm = '" & Me.TxtBmdm.Text & "'", "") & " AND xsrq >= ? AND xsrq >= ? AND xsrq <= ?)", "") & ") oecpfphzbc GROUP BY oecpfphzbc.cpdm) oecpfphzba LEFT JOIN rc_cpxx ON rc_cpxx.cpdm = oecpfphzba.cpdm) oecpfphzbb" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " WHERE lbdm = '" & Me.TxtLbdm.Text & "'", "")
            'End If
            rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
            If Me.CheckBox1.Checked Then
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
            End If
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("oecpfphzb") IsNot Nothing Then
                rcDataset.Tables("oecpfphzb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "oecpfphzb")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Dim rcDataRow As DataRow
        rcDataRow = rcDataset.Tables("oecpfphzb").NewRow
        rcDataRow.Item("cpdm") = "合计"
        rcDataRow.Item("sl") = dtOeCpFpHzb.Compute("Sum(sl)", "")
        rcDataRow.Item("fzsl") = dtOeCpFpHzb.Compute("Sum(fzsl)", "")
        rcDataRow.Item("je") = dtOeCpFpHzb.Compute("Sum(je)", "")
        rcDataRow.Item("se") = dtOeCpFpHzb.Compute("Sum(se)", "")
        rcDataRow.Item("cbje") = dtOeCpFpHzb.Compute("Sum(cbje)", "")
        rcDataRow.Item("mle") = dtOeCpFpHzb.Compute("Sum(mle)", "")
        rcDataset.Tables("oecpfphzb").Rows.Add(rcDataRow)

        '调用表单
        Dim rcFrm As New FrmOeCpFpHzbz
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("oecpfphzb"), "TRUE", "cpdm", DataViewRowState.CurrentRows)
            .Label2.Text = DtpHzrqBegin.Value & "至" & DtpHzrqEnd.Value
            '.Label3.Text = "仓库：" & Trim(Me.TxtCkdm.Text)
            .ParaDateBegin = Me.DtpHzrqBegin.Value.Date
            .ParaDateEnd = Me.DtpHzrqEnd.Value.Date
            '.ParaStrBmdm = strExpBmdm
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class