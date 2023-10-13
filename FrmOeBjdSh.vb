﻿Imports System.Data.OleDb

Public Class FrmOeBjdSh
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Private Sub FrmOeBjdSh_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        DtpBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '取单据类型数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc From rc_lx WHERE lxgs = '产品报价单' and kjnd = '" & Mid(g_Kjqj, 1, 4) & "' ORDER BY pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_lx") IsNot Nothing Then
                Me.rcDataset.Tables("rc_lx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_lx")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Dim rcRow As DataRow
        rcRow = rcDataset.Tables("rc_lx").NewRow
        rcRow.Item("pzlxdm") = "0000"
        rcRow.Item("pzlxjc") = "全部单据"
        rcDataset.Tables("rc_lx").Rows.Add(rcRow)
        If rcDataset.Tables("rc_lx").Rows.Count = 0 Then
            MsgBox("请定义单据类型。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        BindDropDownList(CmbPzlxjc, rcDataset.Tables("rc_lx"), "pzlxdm", "pzlxjc")
        Me.CmbPzlxjc.SelectedValue = "0000"
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        '取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT djh FROM oe_bjd WHERE jzr IS NULL AND oe_bjd.bjrq >= ? AND oe_bjd.bjrq <= ? AND SUBSTR(djh,11, 5) >= ?  AND SUBSTR(djh,11, 5) <= ?" & IIf(Me.CmbPzlxjc.SelectedValue <> "0000", " AND SUBSTR(oe_bjd.djh,1, 4) ='" & Me.CmbPzlxjc.SelectedValue & "'", "") & IIf(ChbSh.Checked, " and shr IS NULL", "") & " GROUP BY oe_bjd.djh ORDER BY djh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@bjrq", OleDbType.Date, 8).Value = Me.DtpBegin.Value.Date
            rcOleDbCommand.Parameters.Add("@bjrq", OleDbType.Date, 8).Value = Me.DtpEnd.Value.Date
            rcOleDbCommand.Parameters.Add("@djh1", OleDbType.VarChar, 5).Value = NudDjhBegin.Value.ToString.PadLeft(5, "0")
            rcOleDbCommand.Parameters.Add("@djh2", OleDbType.VarChar, 5).Value = NudDjhEnd.Value.ToString.PadLeft(5, "0")
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("djhml") IsNot Nothing Then
                rcDataset.Tables("djhml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "djhml")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("djhml").Rows.Count <= 0 Then
            MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        '调用表单
        Dim rcFrm As New FrmOeBjdShz
        With rcFrm
            .ParaDataSet = rcDataset
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

End Class