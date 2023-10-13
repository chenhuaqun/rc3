Imports System.Data.OleDb

Public Class FrmPoBmLbHzb
    '建立数据适配器
    Dim rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    Dim rcDataset As New DataSet
    '建立OleDbCommand对象
    Dim rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable
    Dim dtPoBmLbHzb As New DataTable("pobmlbhzb")

    Private Sub FrmPoBmLbHzb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        DtpHzrqBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpHzrqEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '创建datatable
        dtPoBmLbHzb.Columns.Add("lbdm", Type.GetType("System.String"))
        dtPoBmLbHzb.Columns.Add("lbmc", Type.GetType("System.String"))
        dtPoBmLbHzb.Columns.Add("bysl", Type.GetType("System.Double"))
        dtPoBmLbHzb.Columns.Add("byje", Type.GetType("System.Double"))
        dtPoBmLbHzb.Columns.Add("chanliang", Type.GetType("System.Double"))
        dtPoBmLbHzb.Columns.Add("danhao", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtPoBmLbHzb)
        With dtPoBmLbHzb
            .Columns("lbdm").DefaultValue = ""
            .Columns("lbmc").DefaultValue = ""
            .Columns("bysl").DefaultValue = 0.0
            .Columns("byje").DefaultValue = 0.0
            .Columns("chanliang").DefaultValue = 0.0
            .Columns("danhao").DefaultValue = 0.0
        End With
    End Sub

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpHzrqBegin.KeyPress, DtpHzrqEnd.KeyPress, TxtFadm.KeyPress, TxtBmdm.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "设备编码的事件"

    Private Sub TxtFadm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFadm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_faxx"
                    .paraField1 = "fadm"
                    .paraField2 = "famc"
                    .paraField3 = "fasm"
                    .paraTitle = "设备"
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
                rcOleDbCommand.CommandText = "SELECT * FROM rc_faxx WHERE (fadm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@fadm", OleDbType.VarChar, 12).Value = Trim(TxtFadm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If Not rcDataset.Tables("rc_faxx") Is Nothing Then
                    Me.rcDataset.Tables("rc_faxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_faxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_faxx").Rows.Count > 0 Then
                Me.TxtFadm.Text = Trim(rcDataset.Tables("rc_faxx").Rows(0).Item("fadm"))
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
                If Not rcDataset.Tables("rc_bmxx") Is Nothing Then
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
            Else
                MsgBox("部门编码不存在，请按F3键选择。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                e.Cancel = True
            End If
        End If
    End Sub

#End Region


    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If String.IsNullOrEmpty(Me.TxtBmdm.Text) Then
            MsgBox("部门编码不能为空。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        Dim i As Integer = 0
        dtPoBmLbHzb.Clear()
        '取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT SUBSTR(rc_cpxx.lbdm,1,3) AS lbdm,rc_cplb.lbmc,COALESCE(SUM(inv_ckd.sl),0.0) AS bysl,COALESCE(SUM(inv_ckd.je),0.0) AS byje FROM inv_ckd,rc_cpxx,rc_cplb,rc_lx WHERE inv_ckd.cpdm = rc_cpxx.cpdm AND SUBSTR(rc_cpxx.lbdm,1,3) = rc_cplb.lbdm AND SUBSTR(inv_ckd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(inv_ckd.djh,5,4) = rc_lx.kjnd AND (lxgs = '物料出库单' OR lxgs = '工序领料单')" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND inv_ckd.bmdm LIKE '" & Me.TxtBmdm.Text & "%'", "") & " AND inv_ckd.bdelete = 0 AND inv_ckd.ckrq >= ? AND inv_ckd.ckrq >= ? AND inv_ckd.ckrq <= ? GROUP BY SUBSTR(rc_cpxx.lbdm,1,3),rc_cplb.lbmc"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If Not rcDataset.Tables("pobmlbhzb") Is Nothing Then
                rcDataset.Tables("pobmlbhzb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "pobmlbhzb")
            'For i = 0 To rcDataset.Tables("pobmlbhzb").Rows.Count - 1
            '    If Not String.IsNullOrEmpty(Me.TxtFadm.Text) Then
            '        '取产量数据
            '        '1）拉晶的产量
            '        rcOleDbCommand.CommandText = "SELECT ROUND(COALESCE(SUM(pm_rkd01.fzsl/rc_cpxx.mjsl),0.0),2) AS chanliang FROM pm_rkd01,rc_cpxx WHERE pm_rkd01.cpdm = rc_cpxx.cpdm AND pm_rkd01.fzsl <> 0 AND pm_rkd01.rkrq >= ? AND pm_rkd01.rkrq <= ? AND pm_rkd01.fadm = ?"
            '        rcOleDbCommand.Parameters.Clear()
            '        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
            '        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
            '        rcOleDbCommand.Parameters.Add("@fadm", OleDbType.VarChar, 12).Value = rcDataset.Tables("pobmlbhzb").Rows(i).Item("fadm")
            '        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            '        If Not rcDataset.Tables("chanliang") Is Nothing Then
            '            rcDataset.Tables("chanliang").Clear()
            '        End If
            '        rcOleDbDataAdpt.Fill(rcDataset, "chanliang")
            '        rcDataset.Tables("pobmlbhzb").Rows(i).Item("chanliang") += rcDataset.Tables("chanliang").Rows(0).Item("chanliang")
            '        '2）铸锭的产量
            '        rcOleDbCommand.CommandText = "SELECT ROUND(COALESCE(SUM(pm_rkd02.sl),0.0),2) AS chanliang FROM pm_rkd02 WHERE pm_rkd02.rkrq >= ? AND pm_rkd02.rkrq <= ? AND pm_rkd02.fadm = ?"
            '        rcOleDbCommand.Parameters.Clear()
            '        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
            '        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
            '        rcOleDbCommand.Parameters.Add("@fadm", OleDbType.VarChar, 12).Value = rcDataset.Tables("pobmlbhzb").Rows(i).Item("fadm")
            '        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            '        If Not rcDataset.Tables("chanliang") Is Nothing Then
            '            rcDataset.Tables("chanliang").Clear()
            '        End If
            '        rcOleDbDataAdpt.Fill(rcDataset, "chanliang")
            '        rcDataset.Tables("pobmlbhzb").Rows(i).Item("chanliang") += rcDataset.Tables("chanliang").Rows(0).Item("chanliang")
            '        '3）单晶开方机的产量
            '        rcOleDbCommand.CommandText = "SELECT ROUND(COALESCE(SUM(pm_rkd04.sl),0.0),2) AS chanliang FROM pm_rkd04 WHERE pm_rkd04.rkrq >= ? AND pm_rkd04.rkrq <= ? AND pm_rkd04.fadm = ?"
            '        rcOleDbCommand.Parameters.Clear()
            '        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
            '        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
            '        rcOleDbCommand.Parameters.Add("@fadm", OleDbType.VarChar, 12).Value = rcDataset.Tables("pobmlbhzb").Rows(i).Item("fadm")
            '        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            '        If Not rcDataset.Tables("chanliang") Is Nothing Then
            '            rcDataset.Tables("chanliang").Clear()
            '        End If
            '        rcOleDbDataAdpt.Fill(rcDataset, "chanliang")
            '        rcDataset.Tables("pobmlbhzb").Rows(i).Item("chanliang") += rcDataset.Tables("chanliang").Rows(0).Item("chanliang")
            '        '多晶开方机的产量
            '        rcOleDbCommand.CommandText = "SELECT ROUND(COALESCE(SUM(pm_rkd05.fzsl/rc_cpxx.mjsl),0.0),2) AS chanliang FROM pm_rkd05,rc_cpxx WHERE pm_rkd05.cpdm = rc_cpxx.cpdm AND pm_rkd05.fzsl <> 0 AND pm_rkd05.rkrq >= ? AND pm_rkd05.rkrq <= ? AND pm_rkd05.fadm = ?"
            '        rcOleDbCommand.Parameters.Clear()
            '        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
            '        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
            '        rcOleDbCommand.Parameters.Add("@fadm", OleDbType.VarChar, 12).Value = rcDataset.Tables("pobmlbhzb").Rows(i).Item("fadm")
            '        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            '        If Not rcDataset.Tables("chanliang") Is Nothing Then
            '            rcDataset.Tables("chanliang").Clear()
            '        End If
            '        rcOleDbDataAdpt.Fill(rcDataset, "chanliang")
            '        rcDataset.Tables("pobmlbhzb").Rows(i).Item("chanliang") += rcDataset.Tables("chanliang").Rows(0).Item("chanliang")
            '        '4）平磨机的产量
            '        '单晶
            '        rcOleDbCommand.CommandText = "SELECT ROUND(COALESCE(SUM(pm_rkd06.sl),0.0),2) AS chanliang FROM pm_rkd06 WHERE pm_rkd06.rkrq >= ? AND pm_rkd06.rkrq <= ? AND pm_rkd06.pmfadm = ?"
            '        rcOleDbCommand.Parameters.Clear()
            '        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
            '        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
            '        rcOleDbCommand.Parameters.Add("@fadm", OleDbType.VarChar, 12).Value = rcDataset.Tables("pobmlbhzb").Rows(i).Item("fadm")
            '        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            '        If Not rcDataset.Tables("chanliang") Is Nothing Then
            '            rcDataset.Tables("chanliang").Clear()
            '        End If
            '        rcOleDbDataAdpt.Fill(rcDataset, "chanliang")
            '        rcDataset.Tables("pobmlbhzb").Rows(i).Item("chanliang") += rcDataset.Tables("chanliang").Rows(0).Item("chanliang")
            '        rcOleDbCommand.CommandText = "SELECT ROUND(COALESCE(SUM(pm_rkd06.sl),0.0),2) AS chanliang FROM pm_rkd06 WHERE pm_rkd06.rkrq >= ? AND pm_rkd06.rkrq <= ? AND pm_rkd06.gmfadm = ?"
            '        rcOleDbCommand.Parameters.Clear()
            '        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
            '        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
            '        rcOleDbCommand.Parameters.Add("@fadm", OleDbType.VarChar, 12).Value = rcDataset.Tables("pobmlbhzb").Rows(i).Item("fadm")
            '        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            '        If Not rcDataset.Tables("chanliang") Is Nothing Then
            '            rcDataset.Tables("chanliang").Clear()
            '        End If
            '        rcOleDbDataAdpt.Fill(rcDataset, "chanliang")
            '        rcDataset.Tables("pobmlbhzb").Rows(i).Item("chanliang") += rcDataset.Tables("chanliang").Rows(0).Item("chanliang")

            '        '多晶
            '        rcOleDbCommand.CommandText = "SELECT ROUND(COALESCE(SUM(pm_rkd12p.sl),0.0),2) AS chanliang FROM pm_rkd12p WHERE pm_rkd12p.rkrq >= ? AND pm_rkd12p.rkrq <= ? AND pm_rkd12p.pmfadm = ?"
            '        rcOleDbCommand.Parameters.Clear()
            '        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
            '        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
            '        rcOleDbCommand.Parameters.Add("@fadm", OleDbType.VarChar, 12).Value = rcDataset.Tables("pobmlbhzb").Rows(i).Item("fadm")
            '        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            '        If Not rcDataset.Tables("chanliang") Is Nothing Then
            '            rcDataset.Tables("chanliang").Clear()
            '        End If
            '        rcOleDbDataAdpt.Fill(rcDataset, "chanliang")
            '        rcDataset.Tables("pobmlbhzb").Rows(i).Item("chanliang") += rcDataset.Tables("chanliang").Rows(0).Item("chanliang")
            '        rcOleDbCommand.CommandText = "SELECT ROUND(COALESCE(SUM(pm_rkd12p.sl),0.0),2) AS chanliang FROM pm_rkd12p WHERE pm_rkd12p.rkrq >= ? AND pm_rkd12p.rkrq <= ? AND pm_rkd12p.djfadm = ?"
            '        rcOleDbCommand.Parameters.Clear()
            '        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
            '        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
            '        rcOleDbCommand.Parameters.Add("@fadm", OleDbType.VarChar, 12).Value = rcDataset.Tables("pobmlbhzb").Rows(i).Item("fadm")
            '        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            '        If Not rcDataset.Tables("chanliang") Is Nothing Then
            '            rcDataset.Tables("chanliang").Clear()
            '        End If
            '        rcOleDbDataAdpt.Fill(rcDataset, "chanliang")
            '        rcDataset.Tables("pobmlbhzb").Rows(i).Item("chanliang") += rcDataset.Tables("chanliang").Rows(0).Item("chanliang")
            '        '6）切片机的产量
            '        rcOleDbCommand.CommandText = "SELECT ROUND(COALESCE(SUM(pm_rkd16.sl),0.0),2) AS chanliang FROM pm_rkd16 WHERE pm_rkd16.rkrq >= ? AND pm_rkd16.rkrq <= ? AND pm_rkd16.fadm = ?"
            '        rcOleDbCommand.Parameters.Clear()
            '        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
            '        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
            '        rcOleDbCommand.Parameters.Add("@fadm", OleDbType.VarChar, 12).Value = rcDataset.Tables("pobmlbhzb").Rows(i).Item("fadm")
            '        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            '        If Not rcDataset.Tables("chanliang") Is Nothing Then
            '            rcDataset.Tables("chanliang").Clear()
            '        End If
            '        rcOleDbDataAdpt.Fill(rcDataset, "chanliang")
            '        rcDataset.Tables("pobmlbhzb").Rows(i).Item("chanliang") += rcDataset.Tables("chanliang").Rows(0).Item("chanliang")
            '        If rcDataset.Tables("pobmlbhzb").Rows(i).Item("chanliang") <> 0 Then
            '            rcDataset.Tables("pobmlbhzb").Rows(i).Item("danhao") = System.Math.Round(rcDataset.Tables("pobmlbhzb").Rows(i).Item("byje") / rcDataset.Tables("pobmlbhzb").Rows(i).Item("chanliang"), 2, MidpointRounding.AwayFromZero)
            '        End If
            '    End If
            'Next
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Dim rcDataRow As DataRow
        rcDataRow = rcDataset.Tables("pobmlbhzb").NewRow
        rcDataRow.Item("lbdm") = "合计"
        rcDataRow.Item("bysl") = dtPoBmLbHzb.Compute("Sum(bysl)", "")
        rcDataRow.Item("byje") = dtPoBmLbHzb.Compute("Sum(byje)", "")
        rcDataset.Tables("pobmlbhzb").Rows.Add(rcDataRow)

        '调用表单
        Dim rcFrm As New FrmPoBmLbHzbz
        With rcFrm
            .paraDataSet = rcDataset
            .paraDataView = New DataView(rcDataset.Tables("pobmlbhzb"), "TRUE", "lbdm", DataViewRowState.CurrentRows)
            .Label2.Text = DtpHzrqBegin.Value & "至" & DtpHzrqEnd.Value
            '.Label3.Text = "仓库：" & Trim(Me.TxtCkdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

End Class