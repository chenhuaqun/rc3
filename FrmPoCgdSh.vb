Imports System.Data.OleDb

Public Class FrmPoCgdSh
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Private Sub FrmCgdSh_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        DtpBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '取单据类型数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE kjnd = ? AND lxgs = '物料采购订单' ORDER BY pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_lx") IsNot Nothing Then
                Me.rcDataset.Tables("rc_lx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_lx")
        Catch ex As Exception
            MsgBox("程序错误。读取单据类型。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Dim rcDataRow As DataRow
        rcDataRow = rcDataSet.Tables("rc_lx").NewRow
        rcDataRow.Item("pzlxdm") = "0000"
        rcDataRow.Item("pzlxjc") = "全部单据"
        rcDataSet.Tables("rc_lx").Rows.Add(rcDataRow)
        If rcDataSet.Tables("rc_lx").Rows.Count = 0 Then
            MsgBox("请定义单据类型。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        BindDropDownList(CmbPzlxjc, rcDataSet.Tables("rc_lx"), "pzlxdm", "pzlxjc")
        CmbPzlxjc.SelectedValue = "0000"
    End Sub

    Private Sub ChbSh_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbSh.CheckedChanged
        If Me.ChbSh.Checked Then
            Me.DtpBegin.Enabled = False
            Me.DtpEnd.Enabled = False
        Else
            Me.DtpBegin.Enabled = True
            Me.DtpEnd.Enabled = True
        End If
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        '单据方式
        '取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT po_cgd.djh FROM po_cgd WHERE SUBSTR(po_cgd.djh,11, 5) >= ?  AND SUBSTR(po_cgd.djh,11, 5) <= ?" & IIf(ChbSh.Checked, " AND po_cgd.shr IS NULL", " AND po_cgd.cgrq >= ? AND po_cgd.cgrq <= ?") & IIf(Me.CmbPzlxjc.SelectedValue <> "0000", " AND SUBSTR(po_cgd.djh,1, 4) ='" & Me.CmbPzlxjc.SelectedValue & "'", "") & " GROUP BY po_cgd.djh ORDER BY po_cgd.djh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh1", OleDbType.VarChar, 5).Value = NudDjhBegin.Value.ToString.PadLeft(5, "0")
            rcOleDbCommand.Parameters.Add("@djh2", OleDbType.VarChar, 5).Value = NudDjhEnd.Value.ToString.PadLeft(5, "0")
            If Not Me.ChbSh.Checked Then
                rcOleDbCommand.Parameters.Add("@cgrq", OleDbType.Date, 8).Value = DtpBegin.Value
                rcOleDbCommand.Parameters.Add("@cgrq", OleDbType.Date, 8).Value = Me.DtpEnd.Value
            End If
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("ckdml") IsNot Nothing Then
                rcDataSet.Tables("ckdml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "ckdml")
        Catch ex As Exception
            MsgBox("程序错误。读取单据数据。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("ckdml").Rows.Count <= 0 Then
            MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        '调用表单
        Dim rcFrm As New FrmPoCgdShz
        With rcFrm
            .ParaDataSet = rcDataSet
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class