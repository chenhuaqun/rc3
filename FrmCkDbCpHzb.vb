Imports System.Data.OleDb

Public Class FrmCkDbCpHzb
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable
    ReadOnly dtCkDbCpHzb As New DataTable("ckdbcphzb")

    Private Sub FrmCkDbCpHzb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        DtpHzrqBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpHzrqEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '创建datatable
        dtCkDbCpHzb.Columns.Add("ckdm", Type.GetType("System.String"))
        dtCkDbCpHzb.Columns.Add("ckmc", Type.GetType("System.String"))
        dtCkDbCpHzb.Columns.Add("cpdm", Type.GetType("System.String"))
        dtCkDbCpHzb.Columns.Add("cpmc", Type.GetType("System.String"))
        dtCkDbCpHzb.Columns.Add("dw", Type.GetType("System.String"))
        dtCkDbCpHzb.Columns.Add("sl", Type.GetType("System.Double"))
        dtCkDbCpHzb.Columns.Add("je", Type.GetType("System.Double"))
        dtCkDbCpHzb.Columns.Add("oldcpdm", Type.GetType("System.String"))
        rcDataset.Tables.Add(dtCkDbCpHzb)
        With dtCkDbCpHzb
            .Columns("ckdm").DefaultValue = ""
            .Columns("cpdm").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("je").DefaultValue = 0.0
            .Columns("oldcpdm").DefaultValue = ""
        End With
    End Sub

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpHzrqBegin.KeyPress, DtpHzrqEnd.KeyPress, TxtCckdm.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "调出仓库的事件"

    Private Sub TxtCckdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCckdm.KeyDown
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
                        TxtCckdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtCckdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCckdm.Validating
        If Not String.IsNullOrEmpty(sender.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_ckxx WHERE (ckdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = sender.Text
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
                sender.Text = Trim(rcDataset.Tables("rc_ckxx").Rows(0).Item("ckdm"))
                Me.LblCckmc.Text = Trim(rcDataset.Tables("rc_ckxx").Rows(0).Item("ckmc"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If String.IsNullOrEmpty(Me.TxtCckdm.Text) Then
            MsgBox("请选择调出仓库。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        dtCkDbCpHzb.Clear()
        '取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT aa.rckdm AS ckdm,rc_ckxx.ckmc AS ckmc,aa.cpdm,rc_cpxx.cpmc,rc_cpxx.dw,aa.sl,aa.je,rc_cpxx.oldcpdm FROM (SELECT inv_dbd.rckdm,inv_dbd.cpdm,SUM(inv_dbd.sl) AS sl,SUM(inv_dbd.je) AS je FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND dbrq >= ? AND dbrq >= ? AND dbrq <= ? AND inv_dbd.cckdm = '" & Me.TxtCckdm.Text & "' GROUP BY inv_dbd.rckdm,inv_dbd.cpdm) aa LEFT JOIN rc_ckxx ON rc_ckxx.ckdm = aa.rckdm LEFT JOIN rc_cpxx ON rc_cpxx.cpdm = aa.cpdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = Me.DtpHzrqBegin.Value
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = Me.DtpHzrqEnd.Value
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("ckdbcphzb") IsNot Nothing Then
                rcDataset.Tables("ckdbcphzb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "ckdbcphzb")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Dim rcDataRow As DataRow
        rcDataRow = rcDataset.Tables("ckdbcphzb").NewRow
        rcDataRow.Item("ckdm") = "合计"
        rcDataRow.Item("sl") = dtCkDbCpHzb.Compute("Sum(sl)", "")
        rcDataRow.Item("je") = dtCkDbCpHzb.Compute("Sum(je)", "")
        rcDataset.Tables("ckdbcphzb").Rows.Add(rcDataRow)

        '调用表单
        Dim rcFrm As New FrmCkDbCpHzbz
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("ckdbcphzb"), "TRUE", "ckdm,cpdm", DataViewRowState.CurrentRows)
            .Label2.Text = "日期：" & DtpHzrqBegin.Value & "至" & DtpHzrqEnd.Value & " 调出仓库：(" & Me.TxtCckdm.Text & ")" & Me.LblCckmc.Text
            '.Label3.Text = "仓库：" & Trim(Me.TxtCkdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

End Class