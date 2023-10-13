Imports System.Data.OleDb

Public Class FrmOeCpHzb
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable
    ReadOnly dtOeCpHzb As New DataTable("oecphzb")
    '按成本域
    Dim bCostRegion As Boolean = False

    Private Sub FrmOeCpHzb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '是否按成本域计算成本
        bCostRegion = GetParaValue("是否按成本域计算成本", False)
        If bCostRegion Then
            Me.LblBmdm.Text = "成本域编码："
        Else
            Me.LblBmdm.Text = "部门编码："
        End If
        '默认值
        DtpHzrqBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpHzrqEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '创建datatable
        dtOeCpHzb.Columns.Add("cpdm", Type.GetType("System.String"))
        dtOeCpHzb.Columns.Add("cpmc", Type.GetType("System.String"))
        dtOeCpHzb.Columns.Add("dw", Type.GetType("System.String"))
        dtOeCpHzb.Columns.Add("sl", Type.GetType("System.Double"))
        dtOeCpHzb.Columns.Add("fzsl", Type.GetType("System.Double"))
        dtOeCpHzb.Columns.Add("je", Type.GetType("System.Double"))
        dtOeCpHzb.Columns.Add("se", Type.GetType("System.Double"))
        dtOeCpHzb.Columns.Add("cbje", Type.GetType("System.Double"))
        dtOeCpHzb.Columns.Add("dj", Type.GetType("System.Double"))
        dtOeCpHzb.Columns.Add("cbdj", Type.GetType("System.Double"))
        dtOeCpHzb.Columns.Add("mle", Type.GetType("System.Double"))
        dtOeCpHzb.Columns.Add("mll", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtOeCpHzb)
        With dtOeCpHzb
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
                        .paraOleDbConn = rcOleDbConn
                        .paraTableName = "rc_costregion"
                        .paraField1 = "crdm"
                        .paraField2 = "crmc"
                        .paraField3 = "crsm"
                        .paraTitle = "成本域"
                        .paraOldValue = ""
                        .paraAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            TxtBmdm.Text = Trim(.paraField1)
                        End If
                    End With
                Else
                    Dim rcFrm As New models.FrmF3KeyPress
                    With rcFrm
                        .paraOleDbConn = rcOleDbConn
                        .paraTableName = "rc_bmxx"
                        .paraField1 = "bmdm"
                        .paraField2 = "bmmc"
                        .paraField3 = "bmsm"
                        .paraTitle = "部门"
                        .paraOldValue = ""
                        .paraAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            TxtBmdm.Text = Trim(.paraField1)
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
        '权限控制
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "select code as bmdm from rc_userqx where righttype = 'BMDM' and User_Account = ?" & IIf(Trim(TxtBmdm.Text).Length > 0, " and code ='" & Trim(TxtBmdm.Text) & "'", "")
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = g_User_Account
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_bmxx") IsNot Nothing Then
                rcDataset.Tables("rc_bmxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_bmxx")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Dim strExpBmdm As String = ""
        Dim strExpCrdm As String = ""
        Dim j As Integer
        If rcDataset.Tables("rc_bmxx").Rows.Count = 1 Then
            Me.TxtBmdm.Text = Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmdm"))
            strExpBmdm = strExpBmdm & " OR bmdm = '" & Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmdm")) & "'"
        Else
            For j = 0 To rcDataset.Tables("rc_bmxx").Rows.Count - 1
                strExpBmdm = strExpBmdm & " OR bmdm = '" & Trim(rcDataset.Tables("rc_bmxx").Rows(j).Item("bmdm")) & "'"
            Next
        End If
        If strExpBmdm.Length = 0 Then
            strExpBmdm = " 0=0"
        End If
        If strExpBmdm.Length > 0 Then
            If strExpBmdm.Substring(0, 3) = " OR" Then
                strExpBmdm = strExpBmdm.Substring(3)
            End If
        End If
        If rcDataset.Tables("rc_bmxx").Rows.Count = 1 Then
            Me.TxtBmdm.Text = Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmdm"))
            strExpCrdm = strExpCrdm & " OR crdm = '" & Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmdm")) & "'"
        Else
            For j = 0 To rcDataset.Tables("rc_bmxx").Rows.Count - 1
                strExpCrdm = strExpCrdm & " OR crdm = '" & Trim(rcDataset.Tables("rc_bmxx").Rows(j).Item("bmdm")) & "'"
            Next
        End If
        If strExpCrdm.Length = 0 Then
            strExpCrdm = " 0=0"
        End If
        If strExpCrdm.Length > 0 Then
            If strExpCrdm.Substring(0, 3) = " OR" Then
                strExpCrdm = strExpCrdm.Substring(3)
            End If
        End If

        dtOeCpHzb.Clear()
        '取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            If Me.CheckBox3.Checked Then
                '分仓库显示
                If Me.CheckBox1.Checked Then
                    '含出库调整单
                    If bCostRegion Then
                        rcOleDbCommand.CommandText = "SELECT oecphzbb.cpdm,oecphzbb.cpmc,oecphzbb.dw,oecphzbb.cpweight,oecphzbb.bzcb,oecphzbb.ckdm,oecphzbb.ckmc,oecphzbb.sl,oecphzbb.fzsl,oecphzbb.je,oecphzbb.se,oecphzbb.cbje,oecphzbb.dj,oecphzbb.cbdj,oecphzbb.mle,oecphzbb.mll FROM (SELECT oecphzba.*,CASE WHEN oecphzba.sl <> 0 THEN oecphzba.je / oecphzba.sl ELSE 0.0 END AS dj,CASE WHEN oecphzba.sl <> 0 THEN oecphzba.cbje / oecphzba.sl ELSE 0.0 END AS cbdj,(oecphzba.je - oecphzba.cbje) AS mle,CASE WHEN oecphzba.je <> 0 THEN (oecphzba.je - oecphzba.cbje) / oecphzba.je ELSE 0.0 END AS mll,rc_cpxx.cpmc,rc_cpxx.dw,rc_cpxx.lbdm,rc_cpxx.bzcb,rc_cpxx.cpweight,rc_ckxx.ckmc FROM " &
                        "(SELECT oecphzbc.cpdm,oecphzbc.ckdm,SUM(oecphzbc.sl) AS sl,SUM(oecphzbc.fzsl) AS fzsl,SUM(oecphzbc.je) AS je,SUM(oecphzbc.se) AS se ,SUM(cbje) AS cbje FROM" &
                        "((SELECT oe_xsd.cpdm,oe_xsd.ckdm,SUM(oe_xsd.sl) AS sl,SUM(oe_xsd.fzsl) AS fzsl,SUM(oe_xsd.je) AS je,SUM(oe_xsd.se) AS se,SUM(oe_xsd.cbje) AS cbje FROM oe_xsd,rc_lx,rc_cr_ck WHERE oe_xsd.ckdm  = rc_cr_ck.ckdm AND (" & strExpCrdm & ") AND SUBSTR(oe_xsd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_xsd.djh,5,4) = rc_lx.kjnd AND lxgs = '产品送货单' AND oe_xsd.bdelete = 0" & IIf(Me.CheckBox2.Checked, " AND oe_xsd.sl <> 0 AND oe_xsd.je <> 0", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND rc_cr_ck.crdm = '" & Me.TxtBmdm.Text & "'", "") & " AND xsrq >= ? AND xsrq >= ? AND xsrq <= ? GROUP BY oe_xsd.cpdm,oe_xsd.ckdm)" &
                        " UNION (SELECT inv_ckd.cpdm,inv_ckd.ckdm,SUM(inv_ckd.sl) AS sl,SUM(inv_ckd.fzsl) AS fzsl,0.0 AS je,0.0 AS se,SUM(inv_ckd.je) AS cbje FROM inv_ckd,rc_cr_ck WHERE inv_ckd.ckdm  = rc_cr_ck.ckdm AND (" & strExpCrdm & ") AND SUBSTR(inv_ckd.djh,1,4) = 'CKTZ' AND inv_ckd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND rc_cr_ck.crdm = '" & Me.TxtBmdm.Text & "'", "") & " AND inv_ckd.ckrq >= ? AND inv_ckd.ckrq >= ? AND inv_ckd.ckrq <= ? GROUP BY inv_ckd.cpdm,inv_ckd.ckdm)) oecphzbc GROUP BY oecphzbc.cpdm,oecphzbc.ckdm) oecphzba LEFT JOIN rc_cpxx ON rc_cpxx.cpdm = oecphzba.cpdm LEFT JOIN rc_ckxx ON rc_ckxx.ckdm = oecphzba.ckdm) oecphzbb" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " WHERE lbdm = '" & Me.TxtLbdm.Text & "'", "")
                    Else
                        rcOleDbCommand.CommandText = "SELECT oecphzbb.cpdm,oecphzbb.cpmc,oecphzbb.dw,oecphzbb.cpweight,oecphzbb.bzcb,oecphzbb.ckdm,oecphzbb.ckmc,oecphzbb.sl,oecphzbb.fzsl,oecphzbb.je,oecphzbb.se,oecphzbb.cbje,oecphzbb.dj,oecphzbb.cbdj,oecphzbb.mle,oecphzbb.mll FROM (SELECT oecphzba.*,CASE WHEN oecphzba.sl <> 0 THEN oecphzba.je / oecphzba.sl ELSE 0.0 END AS dj,CASE WHEN oecphzba.sl <> 0 THEN oecphzba.cbje / oecphzba.sl ELSE 0.0 END AS cbdj,(oecphzba.je - oecphzba.cbje) AS mle,CASE WHEN oecphzba.je <> 0 THEN (oecphzba.je - oecphzba.cbje) / oecphzba.je ELSE 0.0 END AS mll,rc_cpxx.cpmc,rc_cpxx.dw,rc_cpxx.lbdm,rc_cpxx.bzcb,rc_cpxx.cpweight,rc_ckxx.ckmc FROM " &
                        "(SELECT oecphzbc.cpdm,oecphzbc.ckdm,SUM(oecphzbc.sl) AS sl,SUM(oecphzbc.fzsl) AS fzsl,SUM(oecphzbc.je) AS je,SUM(oecphzbc.se) AS se ,SUM(cbje) AS cbje FROM" &
                        "((SELECT oe_xsd.cpdm,oe_xsd.ckdm,SUM(oe_xsd.sl) AS sl,SUM(oe_xsd.fzsl) AS fzsl,SUM(oe_xsd.je) AS je,SUM(oe_xsd.se) AS se,SUM(oe_xsd.cbje) AS cbje FROM oe_xsd,rc_lx WHERE (" & strExpBmdm & ") AND SUBSTR(oe_xsd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_xsd.djh,5,4) = rc_lx.kjnd AND lxgs = '产品送货单' AND oe_xsd.bdelete = 0" & IIf(Me.CheckBox2.Checked, " AND oe_xsd.sl <> 0 AND oe_xsd.je <> 0", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_xsd.bmdm = '" & Me.TxtBmdm.Text & "'", "") & " AND xsrq >= ? AND xsrq >= ? AND xsrq <= ? GROUP BY oe_xsd.cpdm,oe_xsd.ckdm)" &
                        " UNION (SELECT inv_ckd.cpdm,inv_ckd.ckdm,SUM(inv_ckd.sl) AS sl,SUM(inv_ckd.fzsl) AS fzsl,0.0 AS je,0.0 AS se,SUM(inv_ckd.je) AS cbje FROM inv_ckd WHERE (" & strExpBmdm & ") AND SUBSTR(inv_ckd.djh,1,4) = 'CKTZ' AND inv_ckd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND inv_ckd.bmdm = '" & Me.TxtBmdm.Text & "'", "") & " AND inv_ckd.ckrq >= ? AND inv_ckd.ckrq >= ? AND inv_ckd.ckrq <= ? GROUP BY inv_ckd.cpdm,inv_ckd.ckdm)) oecphzbc GROUP BY oecphzbc.cpdm,oecphzbc.ckdm) oecphzba LEFT JOIN rc_cpxx ON rc_cpxx.cpdm = oecphzba.cpdm LEFT JOIN rc_ckxx ON rc_ckxx.ckdm = oecphzba.ckdm) oecphzbb" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " WHERE lbdm = '" & Me.TxtLbdm.Text & "'", "")
                    End If
                    rcOleDbCommand.Parameters.Clear()
                    'MsgBox(Me.rcOleDbCommand.CommandText)
                    rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
                    rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
                Else
                    '不含出库调整单
                    If bCostRegion Then
                        rcOleDbCommand.CommandText = "SELECT oecphzbb.cpdm,oecphzbb.cpmc,oecphzbb.dw,oecphzbb.cpweight,oecphzbb.bzcb,oecphzbb.ckdm,oecphzbb.ckmc,oecphzbb.sl,oecphzbb.fzsl,oecphzbb.je,oecphzbb.se,oecphzbb.cbje,oecphzbb.dj,oecphzbb.cbdj,oecphzbb.mle,oecphzbb.mll FROM (SELECT oecphzba.*,CASE WHEN oecphzba.sl <> 0 THEN oecphzba.je / oecphzba.sl ELSE 0.0 END AS dj,CASE WHEN oecphzba.sl <> 0 THEN oecphzba.cbje / oecphzba.sl ELSE 0.0 END AS cbdj,(oecphzba.je - oecphzba.cbje) AS mle,CASE WHEN oecphzba.je <> 0 THEN (oecphzba.je - oecphzba.cbje) / oecphzba.je ELSE 0.0 END AS mll,rc_cpxx.cpmc,rc_cpxx.dw,rc_cpxx.lbdm,rc_cpxx.bzcb,rc_cpxx.cpweight,rc_ckxx.ckmc FROM (SELECT oe_xsd.cpdm,oe_xsd.ckdm,SUM(oe_xsd.sl) AS sl,SUM(oe_xsd.fzsl) AS fzsl,SUM(oe_xsd.je) AS je,SUM(oe_xsd.se) AS se,SUM(oe_xsd.cbje) AS cbje FROM oe_xsd,rc_lx,rc_cr_ck WHERE oe_xsd.ckdm  = rc_cr_ck.ckdm AND (" & strExpCrdm & ") AND SUBSTR(oe_xsd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_xsd.djh,5,4) = rc_lx.kjnd AND lxgs = '产品送货单' AND oe_xsd.bdelete = 0" & IIf(Me.CheckBox2.Checked, " AND oe_xsd.sl <> 0 AND oe_xsd.je <> 0", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND rc_cr_ck.crdm = '" & Me.TxtBmdm.Text & "'", "") & " AND xsrq >= ? AND xsrq >= ? AND xsrq <= ? GROUP BY oe_xsd.cpdm,oe_xsd.ckdm) oecphzba LEFT JOIN rc_cpxx ON rc_cpxx.cpdm = oecphzba.cpdm LEFT JOIN rc_ckxx ON rc_ckxx.ckdm = oecphzba.ckdm) oecphzbb" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " WHERE lbdm = '" & Me.TxtLbdm.Text & "'", "")
                    Else
                        rcOleDbCommand.CommandText = "SELECT oecphzbb.cpdm,oecphzbb.cpmc,oecphzbb.dw,oecphzbb.cpweight,oecphzbb.bzcb,oecphzbb.ckdm,oecphzbb.ckmc,oecphzbb.sl,oecphzbb.fzsl,oecphzbb.je,oecphzbb.se,oecphzbb.cbje,oecphzbb.dj,oecphzbb.cbdj,oecphzbb.mle,oecphzbb.mll FROM (SELECT oecphzba.*,CASE WHEN oecphzba.sl <> 0 THEN oecphzba.je / oecphzba.sl ELSE 0.0 END AS dj,CASE WHEN oecphzba.sl <> 0 THEN oecphzba.cbje / oecphzba.sl ELSE 0.0 END AS cbdj,(oecphzba.je - oecphzba.cbje) AS mle,CASE WHEN oecphzba.je <> 0 THEN (oecphzba.je - oecphzba.cbje) / oecphzba.je ELSE 0.0 END AS mll,rc_cpxx.cpmc,rc_cpxx.dw,rc_cpxx.lbdm,rc_cpxx.bzcb,rc_cpxx.cpweight,rc_ckxx.ckmc FROM (SELECT oe_xsd.cpdm,oe_xsd.ckdm,SUM(oe_xsd.sl) AS slSUM(oe_xsd.fzsl) AS fzsl,SUM(oe_xsd.je) AS je,SUM(oe_xsd.se) AS se,SUM(oe_xsd.cbje) AS cbje FROM oe_xsd,rc_lx WHERE (" & strExpBmdm & ") AND SUBSTR(oe_xsd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_xsd.djh,5,4) = rc_lx.kjnd AND lxgs = '产品送货单' AND oe_xsd.bdelete = 0" & IIf(Me.CheckBox2.Checked, " AND oe_xsd.sl <> 0 AND oe_xsd.je <> 0", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_xsd.bmdm = '" & Me.TxtBmdm.Text & "'", "") & " AND xsrq >= ? AND xsrq >= ? AND xsrq <= ? GROUP BY oe_xsd.cpdm,oe_xsd.ckdm) oecphzba LEFT JOIN rc_cpxx ON rc_cpxx.cpdm = oecphzba.cpdm LEFT JOIN rc_ckxx ON rc_ckxx.ckdm = oecphzba.ckdm) oecphzbb" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " WHERE lbdm = '" & Me.TxtLbdm.Text & "'", "")
                    End If
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
                    rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
                End If
            Else
                '不分仓库显示
                If Me.CheckBox1.Checked Then
                    '含出库调整单
                    If bCostRegion Then
                        rcOleDbCommand.CommandText = "SELECT oecphzbb.cpdm,oecphzbb.cpmc,oecphzbb.dw,oecphzbb.cpweight,oecphzbb.bzcb,oecphzbb.sl,oecphzbb.fzsl,oecphzbb.je,oecphzbb.se,oecphzbb.cbje,oecphzbb.dj,oecphzbb.cbdj,oecphzbb.mle,oecphzbb.mll FROM (SELECT oecphzba.*,CASE WHEN oecphzba.sl <> 0 THEN oecphzba.je / oecphzba.sl ELSE 0.0 END AS dj,CASE WHEN oecphzba.sl <> 0 THEN oecphzba.cbje / oecphzba.sl ELSE 0.0 END AS cbdj,(oecphzba.je - oecphzba.cbje) AS mle,CASE WHEN oecphzba.je <> 0 THEN (oecphzba.je - oecphzba.cbje) / oecphzba.je ELSE 0.0 END AS mll,rc_cpxx.cpmc,rc_cpxx.dw,rc_cpxx.lbdm,rc_cpxx.bzcb,rc_cpxx.cpweight FROM " &
                        "(SELECT oecphzbc.cpdm,SUM(oecphzbc.sl) AS sl,SUM(oecphzbc.fzsl) AS fzsl,SUM(oecphzbc.je) AS je,SUM(oecphzbc.se) AS se ,SUM(cbje) AS cbje FROM" &
                        "((SELECT oe_xsd.cpdm,SUM(oe_xsd.sl) AS sl,SUM(oe_xsd.fzsl) AS fzsl,SUM(oe_xsd.je) AS je,SUM(oe_xsd.se) AS se,SUM(oe_xsd.cbje) AS cbje FROM oe_xsd,rc_lx,rc_cr_ck WHERE oe_xsd.ckdm  = rc_cr_ck.ckdm AND (" & strExpCrdm & ") AND SUBSTR(oe_xsd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_xsd.djh,5,4) = rc_lx.kjnd AND lxgs = '产品送货单' AND oe_xsd.bdelete = 0" & IIf(Me.CheckBox2.Checked, " AND oe_xsd.sl <> 0 AND oe_xsd.je <> 0", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND rc_cr_ck.crdm = '" & Me.TxtBmdm.Text & "'", "") & " AND xsrq >= ? AND xsrq >= ? AND xsrq <= ? GROUP BY oe_xsd.cpdm)" &
                        " UNION (SELECT inv_ckd.cpdm,SUM(inv_ckd.sl) AS sl,SUM(inv_ckd.fzsl) AS fzsl,0.0 AS je,0.0 AS se,SUM(inv_ckd.je) AS cbje FROM inv_ckd,rc_cr_ck WHERE inv_ckd.ckdm  = rc_cr_ck.ckdm AND (" & strExpCrdm & ") AND SUBSTR(inv_ckd.djh,1,4) = 'CKTZ' AND inv_ckd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND rc_cr_ck.crdm = '" & Me.TxtBmdm.Text & "'", "") & " AND inv_ckd.ckrq >= ? AND inv_ckd.ckrq >= ? AND inv_ckd.ckrq <= ? GROUP BY inv_ckd.cpdm)) oecphzbc GROUP BY oecphzbc.cpdm) oecphzba LEFT JOIN rc_cpxx ON rc_cpxx.cpdm = oecphzba.cpdm) oecphzbb" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " WHERE lbdm = '" & Me.TxtLbdm.Text & "'", "")
                    Else
                        rcOleDbCommand.CommandText = "SELECT oecphzbb.cpdm,oecphzbb.cpmc,oecphzbb.dw,oecphzbb.cpweight,oecphzbb.bzcb,oecphzbb.sl,oecphzbb.fzsl,oecphzbb.je,oecphzbb.se,oecphzbb.cbje,oecphzbb.dj,oecphzbb.cbdj,oecphzbb.mle,oecphzbb.mll FROM (SELECT oecphzba.*,CASE WHEN oecphzba.sl <> 0 THEN oecphzba.je / oecphzba.sl ELSE 0.0 END AS dj,CASE WHEN oecphzba.sl <> 0 THEN oecphzba.cbje / oecphzba.sl ELSE 0.0 END AS cbdj,(oecphzba.je - oecphzba.cbje) AS mle,CASE WHEN oecphzba.je <> 0 THEN (oecphzba.je - oecphzba.cbje) / oecphzba.je ELSE 0.0 END AS mll,rc_cpxx.cpmc,rc_cpxx.dw,rc_cpxx.lbdm,rc_cpxx.bzcb,rc_cpxx.cpweight FROM " &
                        "(SELECT oecphzbc.cpdm,SUM(oecphzbc.sl) AS sl,SUM(oecphzbc.fzsl) AS fzsl,SUM(oecphzbc.je) AS je,SUM(oecphzbc.se) AS se ,SUM(cbje) AS cbje FROM" &
                        "((SELECT oe_xsd.cpdm,SUM(oe_xsd.sl) AS sl,SUM(oe_xsd.fzsl) AS fzsl,SUM(oe_xsd.je) AS je,SUM(oe_xsd.se) AS se,SUM(oe_xsd.cbje) AS cbje FROM oe_xsd,rc_lx WHERE (" & strExpBmdm & ") AND SUBSTR(oe_xsd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_xsd.djh,5,4) = rc_lx.kjnd AND lxgs = '产品送货单' AND oe_xsd.bdelete = 0" & IIf(Me.CheckBox2.Checked, " AND oe_xsd.sl <> 0 AND oe_xsd.je <> 0", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_xsd.bmdm = '" & Me.TxtBmdm.Text & "'", "") & " AND xsrq >= ? AND xsrq >= ? AND xsrq <= ? GROUP BY oe_xsd.cpdm)" &
                        " UNION (SELECT inv_ckd.cpdm,SUM(inv_ckd.sl) AS sl,SUM(inv_ckd.fzsl) AS fzsl,0.0 AS je,0.0 AS se,SUM(inv_ckd.je) AS cbje FROM inv_ckd WHERE (" & strExpBmdm & ") AND SUBSTR(inv_ckd.djh,1,4) = 'CKTZ' AND inv_ckd.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND inv_ckd.bmdm = '" & Me.TxtBmdm.Text & "'", "") & " AND inv_ckd.ckrq >= ? AND inv_ckd.ckrq >= ? AND inv_ckd.ckrq <= ? GROUP BY inv_ckd.cpdm)) oecphzbc GROUP BY oecphzbc.cpdm) oecphzba LEFT JOIN rc_cpxx ON rc_cpxx.cpdm = oecphzba.cpdm) oecphzbb" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " WHERE lbdm = '" & Me.TxtLbdm.Text & "'", "")
                    End If
                    rcOleDbCommand.Parameters.Clear()
                    'MsgBox(Me.rcOleDbCommand.CommandText)
                    rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
                    rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
                Else
                    '不含出库调整单
                    If bCostRegion Then
                        rcOleDbCommand.CommandText = "SELECT oecphzbb.cpdm,oecphzbb.cpmc,oecphzbb.dw,oecphzbb.cpweight,oecphzbb.bzcb,oecphzbb.sl,oecphzbb.fzsl,oecphzbb.je,oecphzbb.se,oecphzbb.cbje,oecphzbb.dj,oecphzbb.cbdj,oecphzbb.mle,oecphzbb.mll FROM (SELECT oecphzba.*,CASE WHEN oecphzba.sl <> 0 THEN oecphzba.je / oecphzba.sl ELSE 0.0 END AS dj,CASE WHEN oecphzba.sl <> 0 THEN oecphzba.cbje / oecphzba.sl ELSE 0.0 END AS cbdj,(oecphzba.je - oecphzba.cbje) AS mle,CASE WHEN oecphzba.je <> 0 THEN (oecphzba.je - oecphzba.cbje) / oecphzba.je ELSE 0.0 END AS mll,rc_cpxx.cpmc,rc_cpxx.dw,rc_cpxx.lbdm,rc_cpxx.bzcb,rc_cpxx.cpweight FROM (SELECT oe_xsd.cpdm,SUM(oe_xsd.sl) AS sl,SUM(oe_xsd.fzsl) AS fzsl,SUM(oe_xsd.je) AS je,SUM(oe_xsd.se) AS se,SUM(oe_xsd.cbje) AS cbje FROM oe_xsd,rc_lx,rc_cr_ck WHERE oe_xsd.ckdm  = rc_cr_ck.ckdm AND (" & strExpCrdm & ") AND SUBSTR(oe_xsd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_xsd.djh,5,4) = rc_lx.kjnd AND lxgs = '产品送货单' AND oe_xsd.bdelete = 0" & IIf(Me.CheckBox2.Checked, " AND oe_xsd.sl <> 0 AND oe_xsd.je <> 0", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND rc_cr_ck.crdm = '" & Me.TxtBmdm.Text & "'", "") & " AND xsrq >= ? AND xsrq >= ? AND xsrq <= ? GROUP BY oe_xsd.cpdm) oecphzba LEFT JOIN rc_cpxx ON rc_cpxx.cpdm = oecphzba.cpdm) oecphzbb" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " WHERE lbdm = '" & Me.TxtLbdm.Text & "'", "")
                    Else
                        rcOleDbCommand.CommandText = "SELECT oecphzbb.cpdm,oecphzbb.cpmc,oecphzbb.dw,oecphzbb.cpweight,oecphzbb.bzcb,oecphzbb.sl,oecphzbb.fzsl,oecphzbb.je,oecphzbb.se,oecphzbb.cbje,oecphzbb.dj,oecphzbb.cbdj,oecphzbb.mle,oecphzbb.mll FROM (SELECT oecphzba.*,CASE WHEN oecphzba.sl <> 0 THEN oecphzba.je / oecphzba.sl ELSE 0.0 END AS dj,CASE WHEN oecphzba.sl <> 0 THEN oecphzba.cbje / oecphzba.sl ELSE 0.0 END AS cbdj,(oecphzba.je - oecphzba.cbje) AS mle,CASE WHEN oecphzba.je <> 0 THEN (oecphzba.je - oecphzba.cbje) / oecphzba.je ELSE 0.0 END AS mll,rc_cpxx.cpmc,rc_cpxx.dw,rc_cpxx.lbdm,rc_cpxx.bzcb,rc_cpxx.cpweight FROM (SELECT oe_xsd.cpdm,SUM(oe_xsd.sl) AS sl,SUM(oe_xsd.fzsl) AS fzsl,SUM(oe_xsd.je) AS je,SUM(oe_xsd.se) AS se,SUM(oe_xsd.cbje) AS cbje FROM oe_xsd,rc_lx WHERE (" & strExpBmdm & ") AND SUBSTR(oe_xsd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_xsd.djh,5,4) = rc_lx.kjnd AND lxgs = '产品送货单' AND oe_xsd.bdelete = 0" & IIf(Me.CheckBox2.Checked, " AND oe_xsd.sl <> 0 AND oe_xsd.je <> 0", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_xsd.bmdm = '" & Me.TxtBmdm.Text & "'", "") & " AND xsrq >= ? AND xsrq >= ? AND xsrq <= ? GROUP BY oe_xsd.cpdm) oecphzba LEFT JOIN rc_cpxx ON rc_cpxx.cpdm = oecphzba.cpdm) oecphzbb" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " WHERE lbdm = '" & Me.TxtLbdm.Text & "'", "")
                    End If
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                    rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
                    rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
                End If
            End If
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("oecphzb") IsNot Nothing Then
                rcDataset.Tables("oecphzb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "oecphzb")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Dim rcDataRow As DataRow
        rcDataRow = rcDataset.Tables("oecphzb").NewRow
        rcDataRow.Item("cpdm") = "合计"
        rcDataRow.Item("sl") = dtOeCpHzb.Compute("Sum(sl)", "")
        rcDataRow.Item("fzsl") = dtOeCpHzb.Compute("Sum(fzsl)", "")
        rcDataRow.Item("je") = dtOeCpHzb.Compute("Sum(je)", "")
        rcDataRow.Item("se") = dtOeCpHzb.Compute("Sum(se)", "")
        rcDataRow.Item("cbje") = dtOeCpHzb.Compute("Sum(cbje)", "")
        rcDataRow.Item("mle") = dtOeCpHzb.Compute("Sum(mle)", "")
        rcDataset.Tables("oecphzb").Rows.Add(rcDataRow)

        '调用表单
        Dim rcFrm As New FrmOeCpHzbz
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("oecphzb"), "TRUE", "cpdm", DataViewRowState.CurrentRows)
            .Label2.Text = DtpHzrqBegin.Value & "至" & DtpHzrqEnd.Value
            '.Label3.Text = "仓库：" & Trim(Me.TxtCkdm.Text)
            .paraDateBegin = Me.DtpHzrqBegin.Value.Date
            .paraDateEnd = Me.DtpHzrqEnd.Value.Date
            .ParaBlnCkd = Me.CheckBox1.Checked
            .ParaStrBmdm = strExpBmdm
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class