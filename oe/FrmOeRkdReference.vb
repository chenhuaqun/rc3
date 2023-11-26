Imports System.Data.OleDb

Public Class FrmOeRkdReference

#Region "定义变量"

    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    Dim rcDataset As New DataSet
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

#End Region

    Overloads Property ParaDataSet() As DataSet
        Get
            ParaDataSet = rcDataset
        End Get
        Set(ByVal Value As DataSet)
            rcDataset = Value
        End Set
    End Property

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Dim i As Integer
        For i = 0 To rcDataSet.Tables("rc_rkdref").Rows.Count - 1
            If rcDataSet.Tables("rc_rkdref").Rows(i).Item("xz") Then
                Dim rcDataRow As DataRow
                rcDataRow = rcDataSet.Tables("rc_rkdnr").NewRow
                rcDataRow.Item("cpdm") = rcDataSet.Tables("rc_rkdref").Rows(i).Item("cpdm")
                rcDataRow.Item("cpmc") = rcDataSet.Tables("rc_rkdref").Rows(i).Item("cpmc")
                rcDataRow.Item("hth") = rcDataSet.Tables("rc_rkdref").Rows(i).Item("hth")
                rcDataRow.Item("sl") = rcDataSet.Tables("rc_rkdref").Rows(i).Item("sl")
                rcDataRow.Item("dw") = rcDataSet.Tables("rc_rkdref").Rows(i).Item("dw")
                rcDataRow.Item("mjsl") = rcDataSet.Tables("rc_rkdref").Rows(i).Item("mjsl")
                rcDataRow.Item("fzsl") = rcDataSet.Tables("rc_rkdref").Rows(i).Item("fzsl")
                rcDataRow.Item("fzdw") = rcDataSet.Tables("rc_rkdref").Rows(i).Item("fzdw")
                rcDataRow.Item("dj") = rcDataSet.Tables("rc_rkdref").Rows(i).Item("dj")
                rcDataRow.Item("je") = rcDataSet.Tables("rc_rkdref").Rows(i).Item("je")
                rcDataSet.Tables("rc_rkdnr").Rows.Add(rcDataRow)
            End If
        Next
        Me.Close()
    End Sub

    Private Sub FrmOeRkdReference_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '设置DataGridView
        Me.rcDataGridView.AutoGenerateColumns = False
        Me.rcDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColMjsl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColMjsl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColFzsl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColFzsl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColDj").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColDj").DefaultCellStyle.Format = g_FormatDj
        Me.rcDataGridView.Columns("ColJe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColJe").DefaultCellStyle.Format = "0.00"
        If rcDataSet.Tables("rc_rkdref") IsNot Nothing Then
            rcDataSet.Tables("rc_rkdref").Clear()
        End If
        '绑定数据the DataGrid to the DataSet.
        Me.rcBindingSource.DataSource = Me.rcDataSet.Tables("rc_rkdref")
        Me.rcDataGridView.DataSource = Me.rcBindingSource
    End Sub

#Region "客户编码事件"

    Private Sub TxtKhdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtKhdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_khxx"
                    .paraField1 = "khdm"
                    .paraField2 = "khmc"
                    .paraField3 = "khsm"
                    .paraCondition = "0=0"
                    .paraOrderField = "khmc"
                    .paraTitle = "客户"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtKhdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
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
            If rcDataset.Tables("rc_khxx").Rows.Count > 0 Then
                Me.TxtKhdm.Text = Trim(rcDataset.Tables("rc_khxx").Rows(0).Item("khdm"))
                'Me.LblKhmc.Text = Trim(rcDataset.Tables("rc_khxx").Rows(0).Item("khmc"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "职员编码的事件"

    Private Sub TxtZydm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtZydm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_zyxx"
                    .paraField1 = "zydm"
                    .paraField2 = "zymc"
                    .paraField3 = "zysm"
                    .paraOrderField = "zymc"
                    .paraTitle = "职员"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtZydm.Text = Trim(.paraField1)
                        'Me.LblZymc.Text = Trim(.paraField2)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtZydm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtZydm.Validating
        If Not String.IsNullOrEmpty(Me.TxtZydm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT rc_zyxx.zydm,rc_zyxx.zymc FROM rc_zyxx WHERE (zydm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(Me.TxtZydm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_zyxx") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_zyxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_zyxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_zyxx").Rows.Count > 0 Then
                Me.TxtZydm.Text = Trim(rcDataset.Tables("rc_zyxx").Rows(0).Item("zydm"))
                ' Me.LblZymc.Text = Trim(rcDataset.Tables("rc_zyxx").Rows(0).Item("zymc"))
            Else
                MsgBox("职员编码不存在，请重输入。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

    Private Sub BtnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImport.Click
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT 0 AS xz,oe_dd.cpdm,rc_cpxx.cpmc,rc_cpxx.dw,oe_dd.hth,oe_dd.khdm,oe_dd.khmc,sl - hxsl - rksl AS sl,rc_cpxx.rgcb AS rgdj,(oe_dd.sl - oe_dd.hxsl - oe_dd.rksl)* rc_cpxx.rgcb AS rgcb,rc_cpxx.bzcb AS dj,(oe_dd.sl - oe_dd.hxsl - oe_dd.rksl)* rc_cpxx.bzcb AS je FROM oe_dd,rc_cpxx WHERE oe_dd.cpdm = rc_cpxx.cpdm AND oe_dd.sl - oe_dd.hxsl - oe_dd.rksl > 0 " & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND oe_dd.khdm = '" & Me.TxtKhdm.Text & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtZydm.Text), " AND oe_dd.sczydm = '" & Me.TxtZydm.Text & "'", "") & " ORDER BY oe_dd.qdrq"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_rkdref") IsNot Nothing Then
                Me.rcDataSet.Tables("rc_rkdref").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_rkdref")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        Finally
            rcOleDbConn.Close()
        End Try
    End Sub
End Class