Imports System.Data.OleDb

Public Class FrmPoBmFaLbHzb
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable
    ReadOnly dtPoBmFaLbHzb As New DataTable("pobmfalbhzb")

    Private Sub FrmPoBmFaLbHzb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        DtpHzrqBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpHzrqEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '创建datatable
        dtPoBmFaLbHzb.Columns.Add("bmdm", Type.GetType("System.String"))
        dtPoBmFaLbHzb.Columns.Add("bmmc", Type.GetType("System.String"))
        dtPoBmFaLbHzb.Columns.Add("fadm", Type.GetType("System.String"))
        dtPoBmFaLbHzb.Columns.Add("famc", Type.GetType("System.String"))
        dtPoBmFaLbHzb.Columns.Add("lbdm", Type.GetType("System.String"))
        dtPoBmFaLbHzb.Columns.Add("lbmc", Type.GetType("System.String"))
        dtPoBmFaLbHzb.Columns.Add("sl", Type.GetType("System.Double"))
        dtPoBmFaLbHzb.Columns.Add("je", Type.GetType("System.Double"))
        dtPoBmFaLbHzb.Columns.Add("chanliang", Type.GetType("System.Double"))
        dtPoBmFaLbHzb.Columns.Add("danhao", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtPoBmFaLbHzb)
        With dtPoBmFaLbHzb
            .Columns("bmdm").DefaultValue = ""
            .Columns("bmmc").DefaultValue = ""
            .Columns("fadm").DefaultValue = ""
            .Columns("famc").DefaultValue = ""
            .Columns("lbdm").DefaultValue = ""
            .Columns("lbmc").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("je").DefaultValue = 0.0
            .Columns("chanliang").DefaultValue = 0.0
            .Columns("danhao").DefaultValue = 0.0
        End With
    End Sub

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpHzrqBegin.KeyPress, DtpHzrqEnd.KeyPress, TxtLbdm.KeyPress, TxtCkdm.KeyPress, TxtBmdm.KeyPress
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
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtBmdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtBmdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtBmdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT bmdm,bmmc FROM rc_bmxx WHERE (bmdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(TxtBmdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_bmxx") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_bmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_bmxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_bmxx").Rows.Count > 0 Then
                TxtBmdm.Text = Trim(rcDataSet.Tables("rc_bmxx").Rows(0).Item("bmdm"))
            Else
                MsgBox("部门编码不存在，请按F3键选择。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                e.Cancel = True
            End If
        End If
    End Sub

#End Region


    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim i As Integer
        dtPoBmFaLbHzb.Clear()
        '取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT inv_ckd.bmdm,inv_ckd.bmmc,inv_ckd.fadm,inv_ckd.famc,rc_cpxx.lbdm,rc_cplb.lbmc,COALESCE(SUM(inv_ckd.sl),0.0) AS sl,COALESCE(SUM(inv_ckd.je),0.0) AS je FROM inv_ckd,rc_cpxx,rc_cplb,rc_lx WHERE inv_ckd.cpdm = rc_cpxx.cpdm AND rc_cpxx.lbdm = rc_cplb.lbdm AND SUBSTR(inv_ckd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(inv_ckd.djh,5,4) = rc_lx.kjnd AND lxgs = '物料出库单'" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND inv_ckd.bmdm LIKE '" & Me.TxtBmdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND rc_cpxx.lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_ckd.ckdm = '" & Me.TxtCkdm.Text & "'", "") & " AND inv_ckd.bdelete = 0 AND inv_ckd.ckrq >= ? AND inv_ckd.ckrq >= ? AND inv_ckd.ckrq <= ? GROUP BY inv_ckd.bmdm,inv_ckd.bmmc,inv_ckd.fadm,inv_ckd.famc,rc_cpxx.lbdm,rc_cplb.lbmc"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("pobmfalbhzb") IsNot Nothing Then
                rcDataset.Tables("pobmfalbhzb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "pobmfalbhzb")
            For i = 0 To rcDataset.Tables("pobmfalbhzb").Rows.Count - 1
                If rcDataset.Tables("pobmfalbhzb").Rows(i).Item("fadm").GetType.ToString <> "System.DBNull" Then
                    '取产量数据
                    '1）拉晶的产量
                    rcOleDbCommand.CommandText = "SELECT ROUND(COALESCE(SUM(pm_rkd01.fzsl/rc_cpxx.mjsl),0.0),2) AS chanliang FROM pm_rkd01,rc_cpxx WHERE pm_rkd01.cpdm = rc_cpxx.cpdm AND pm_rkd01.fzsl <> 0 AND pm_rkd01.rkrq >= ? AND pm_rkd01.rkrq <= ? AND pm_rkd01.fadm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
                    rcOleDbCommand.Parameters.Add("@fadm", OleDbType.VarChar, 12).Value = rcDataset.Tables("pobmfalbhzb").Rows(i).Item("fadm")
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("chanliang") IsNot Nothing Then
                        rcDataset.Tables("chanliang").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "chanliang")
                    rcDataset.Tables("pobmfalbhzb").Rows(i).Item("chanliang") += rcDataset.Tables("chanliang").Rows(0).Item("chanliang")
                    '2）铸锭的产量
                    rcOleDbCommand.CommandText = "SELECT ROUND(COALESCE(SUM(pm_rkd02.sl),0.0),2) AS chanliang FROM pm_rkd02 WHERE pm_rkd02.rkrq >= ? AND pm_rkd02.rkrq <= ? AND pm_rkd02.fadm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
                    rcOleDbCommand.Parameters.Add("@fadm", OleDbType.VarChar, 12).Value = rcDataset.Tables("pobmfalbhzb").Rows(i).Item("fadm")
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("chanliang") IsNot Nothing Then
                        rcDataset.Tables("chanliang").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "chanliang")
                    rcDataset.Tables("pobmfalbhzb").Rows(i).Item("chanliang") += rcDataset.Tables("chanliang").Rows(0).Item("chanliang")
                    '3）单晶开方机的产量
                    rcOleDbCommand.CommandText = "SELECT ROUND(COALESCE(SUM(pm_rkd04.sl),0.0),2) AS chanliang FROM pm_rkd04 WHERE pm_rkd04.rkrq >= ? AND pm_rkd04.rkrq <= ? AND pm_rkd04.fadm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
                    rcOleDbCommand.Parameters.Add("@fadm", OleDbType.VarChar, 12).Value = rcDataset.Tables("pobmfalbhzb").Rows(i).Item("fadm")
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("chanliang") IsNot Nothing Then
                        rcDataset.Tables("chanliang").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "chanliang")
                    rcDataset.Tables("pobmfalbhzb").Rows(i).Item("chanliang") += rcDataset.Tables("chanliang").Rows(0).Item("chanliang")
                    '多晶开方机的产量
                    rcOleDbCommand.CommandText = "SELECT ROUND(COALESCE(SUM(pm_rkd05.fzsl/rc_cpxx.mjsl),0.0),2) AS chanliang FROM pm_rkd05,rc_cpxx WHERE pm_rkd05.cpdm = rc_cpxx.cpdm AND pm_rkd05.fzsl <> 0 AND pm_rkd05.rkrq >= ? AND pm_rkd05.rkrq <= ? AND pm_rkd05.fadm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
                    rcOleDbCommand.Parameters.Add("@fadm", OleDbType.VarChar, 12).Value = rcDataset.Tables("pobmfalbhzb").Rows(i).Item("fadm")
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("chanliang") IsNot Nothing Then
                        rcDataset.Tables("chanliang").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "chanliang")
                    rcDataset.Tables("pobmfalbhzb").Rows(i).Item("chanliang") += rcDataset.Tables("chanliang").Rows(0).Item("chanliang")
                    '4）平磨机的产量
                    '单晶
                    rcOleDbCommand.CommandText = "SELECT ROUND(COALESCE(SUM(pm_rkd06.sl),0.0),2) AS chanliang FROM pm_rkd06 WHERE pm_rkd06.rkrq >= ? AND pm_rkd06.rkrq <= ? AND pm_rkd06.pmfadm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
                    rcOleDbCommand.Parameters.Add("@fadm", OleDbType.VarChar, 12).Value = rcDataset.Tables("pobmfalbhzb").Rows(i).Item("fadm")
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("chanliang") IsNot Nothing Then
                        rcDataset.Tables("chanliang").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "chanliang")
                    rcDataset.Tables("pobmfalbhzb").Rows(i).Item("chanliang") += rcDataset.Tables("chanliang").Rows(0).Item("chanliang")
                    rcOleDbCommand.CommandText = "SELECT ROUND(COALESCE(SUM(pm_rkd06.sl),0.0),2) AS chanliang FROM pm_rkd06 WHERE pm_rkd06.rkrq >= ? AND pm_rkd06.rkrq <= ? AND pm_rkd06.gmfadm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
                    rcOleDbCommand.Parameters.Add("@fadm", OleDbType.VarChar, 12).Value = rcDataset.Tables("pobmfalbhzb").Rows(i).Item("fadm")
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("chanliang") IsNot Nothing Then
                        rcDataset.Tables("chanliang").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "chanliang")
                    rcDataset.Tables("pobmfalbhzb").Rows(i).Item("chanliang") += rcDataset.Tables("chanliang").Rows(0).Item("chanliang")

                    '多晶
                    rcOleDbCommand.CommandText = "SELECT ROUND(COALESCE(SUM(pm_rkd12p.sl),0.0),2) AS chanliang FROM pm_rkd12p WHERE pm_rkd12p.rkrq >= ? AND pm_rkd12p.rkrq <= ? AND pm_rkd12p.pmfadm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
                    rcOleDbCommand.Parameters.Add("@fadm", OleDbType.VarChar, 12).Value = rcDataset.Tables("pobmfalbhzb").Rows(i).Item("fadm")
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("chanliang") IsNot Nothing Then
                        rcDataset.Tables("chanliang").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "chanliang")
                    rcDataset.Tables("pobmfalbhzb").Rows(i).Item("chanliang") += rcDataset.Tables("chanliang").Rows(0).Item("chanliang")
                    rcOleDbCommand.CommandText = "SELECT ROUND(COALESCE(SUM(pm_rkd12p.sl),0.0),2) AS chanliang FROM pm_rkd12p WHERE pm_rkd12p.rkrq >= ? AND pm_rkd12p.rkrq <= ? AND pm_rkd12p.djfadm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
                    rcOleDbCommand.Parameters.Add("@fadm", OleDbType.VarChar, 12).Value = rcDataset.Tables("pobmfalbhzb").Rows(i).Item("fadm")
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("chanliang") IsNot Nothing Then
                        rcDataset.Tables("chanliang").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "chanliang")
                    rcDataset.Tables("pobmfalbhzb").Rows(i).Item("chanliang") += rcDataset.Tables("chanliang").Rows(0).Item("chanliang")
                    '6）切片机的产量
                    rcOleDbCommand.CommandText = "SELECT ROUND(COALESCE(SUM(pm_rkd16.sl),0.0),2) AS chanliang FROM pm_rkd16 WHERE pm_rkd16.rkrq >= ? AND pm_rkd16.rkrq <= ? AND pm_rkd16.fadm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
                    rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
                    rcOleDbCommand.Parameters.Add("@fadm", OleDbType.VarChar, 12).Value = rcDataset.Tables("pobmfalbhzb").Rows(i).Item("fadm")
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("chanliang") IsNot Nothing Then
                        rcDataset.Tables("chanliang").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "chanliang")
                    rcDataset.Tables("pobmfalbhzb").Rows(i).Item("chanliang") += rcDataset.Tables("chanliang").Rows(0).Item("chanliang")
                    If rcDataset.Tables("pobmfalbhzb").Rows(i).Item("chanliang") <> 0 Then
                        rcDataset.Tables("pobmfalbhzb").Rows(i).Item("danhao") = System.Math.Round(rcDataset.Tables("pobmfalbhzb").Rows(i).Item("je") / rcDataset.Tables("pobmfalbhzb").Rows(i).Item("chanliang"), 2, MidpointRounding.AwayFromZero)
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Dim rcDataRow As DataRow
        rcDataRow = rcDataset.Tables("pobmfalbhzb").NewRow
        rcDataRow.Item("bmdm") = "合计"
        rcDataRow.Item("sl") = dtPoBmFaLbHzb.Compute("Sum(sl)", "")
        rcDataRow.Item("je") = dtPoBmFaLbHzb.Compute("Sum(je)", "")
        rcDataset.Tables("pobmfalbhzb").Rows.Add(rcDataRow)

        '调用表单
        Dim rcFrm As New FrmPoBmFaLbHzbz
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("pobmfalbhzb"), "TRUE", "bmdm,fadm,lbdm", DataViewRowState.CurrentRows)
            .Label2.Text = DtpHzrqBegin.Value & "至" & DtpHzrqEnd.Value
            '.Label3.Text = "仓库：" & Trim(Me.TxtCkdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

End Class