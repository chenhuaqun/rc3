Imports System.Data.OleDb

Public Class FrmGlPzCx
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Private Sub FrmGlPzCx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        DtpBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        DtpEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '取凭证类型数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE kjnd = ? AND lxgs = '记账凭证' ORDER BY pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_lx") IsNot Nothing Then
                Me.rcDataSet.Tables("rc_lx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_lx")
        Catch ex As Exception
            MsgBox("程序错误。读取凭证类型。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
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
            MsgBox("请定义凭证类型。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        BindDropDownList(CmbPzlxjc, rcDataSet.Tables("rc_lx"), "pzlxdm", "pzlxjc")
        CmbPzlxjc.SelectedValue = "0000"

    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If Me.ChbLbfs.Checked Then
            '取数据
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT gl_pz.djh,gl_pz.xh,gl_pz.bdelete,gl_pz.pzrq,gl_pz.fjzs,gl_pz.jd,gl_pz.zy,gl_pz.kmdm,gl_pz.kmmc,gl_pz.bmdm,gl_pz.bmmc,gl_pz.xmdm,gl_pz.xmmc,gl_pz.khdm,gl_pz.khmc,gl_pz.csdm,gl_pz.csmc,gl_pz.jxzh,gl_pz.dfkm,gl_pz.dw,gl_pz.sl,gl_pz.dj,gl_pz.bz,gl_pz.wb,gl_pz.hl,gl_pz.je,gl_pz.yspz,gl_pz.jsr,gl_pz.wldqr,gl_pz.srr,gl_pz.shr,gl_pz.jzr FROM gl_pz WHERE pzrq >= ? AND pzrq <= ?" & IIf(Me.ChbSh.Checked, "", " AND NOT gl_pz.jzr IS NULL") & " AND SUBSTR(gl_pz.djh,11, 5) >= ?  AND SUBSTR(gl_pz.djh,11,5) <= ?" & IIf(Trim(Me.TxtKmdm.Text).Length > 0, " and gl_pz.kmdm = '" & Trim(Me.TxtKmdm.Text) & "'", "") & IIf(Trim(Me.TxtKmmc.Text).Length > 0, " and gl_pz.kmmc LIKE '" & Trim(Me.TxtKmmc.Text) & "%'", "") & IIf(Trim(Me.TxtBmdm.Text).Length > 0, " and gl_pz.bmdm LIKE '" & Trim(Me.TxtBmdm.Text) & "%'", "") & IIf(Trim(Me.TxtXmdm.Text).Length > 0, " and gl_pz.xmdm LIKE '" & Trim(Me.TxtXmdm.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " and gl_pz.khdm = '" & Trim(TxtKhdm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCsdm.Text), " and gl_pz.csdm = '" & Trim(Me.TxtCsdm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtJxzh.Text), " and gl_pz.rckdm = '" & Trim(Me.TxtJxzh.Text) & "'", "") & IIf(Me.CmbPzlxjc.SelectedValue <> "0000", " AND SUBSTR(gl_pz.djh,1, 4) ='" & Me.CmbPzlxjc.SelectedValue & "'", "") & " ORDER BY gl_pz.djh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@pzrq1", OleDbType.Date, 8).Value = DtpBegin.Value
                rcOleDbCommand.Parameters.Add("@pzrq2", OleDbType.Date, 8).Value = Me.DtpEnd.Value
                rcOleDbCommand.Parameters.Add("@djh1", OleDbType.VarChar, 5).Value = NudDjhBegin.Value.ToString.PadLeft(5, "0")
                rcOleDbCommand.Parameters.Add("@djh2", OleDbType.VarChar, 5).Value = NudDjhEnd.Value.ToString.PadLeft(5, "0")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("pzlb") IsNot Nothing Then
                    rcDataSet.Tables("pzlb").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "pzlb")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("pzlb").Rows.Count <= 0 Then
                MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            '调用表单
            Dim rcFrm As New FrmGlPzCxLb
            With rcFrm
                .ParaDataSet = rcDataSet
                .ParaDataView = New DataView(rcDataSet.Tables("pzlb"), "TRUE", "djh,xh", DataViewRowState.CurrentRows)
                .WindowState = FormWindowState.Maximized
                .MdiParent = Me.MdiParent
                .Show()
            End With
        Else
            '取数据
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT djh FROM gl_pz WHERE pzrq >= ? AND pzrq <= ? AND SUBSTR(djh,11,5) >= ?  AND SUBSTR(djh,11,5) <= ? " & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " and gl_pz.khdm = '" & Trim(TxtKhdm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCsdm.Text), " and gl_pz.csdm = '" & Trim(Me.TxtCsdm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtJxzh.Text), " and gl_pz.rckdm = '" & Trim(Me.TxtJxzh.Text) & "'", "") & IIf(Me.ChbSh.Checked, "", " AND NOT gl_pz.jzr IS NULL") & " GROUP BY djh ORDER BY djh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@pzrq1", OleDbType.Date, 8).Value = DtpBegin.Value
                rcOleDbCommand.Parameters.Add("@pzrq2", OleDbType.Date, 8).Value = Me.DtpEnd.Value
                rcOleDbCommand.Parameters.Add("@djh1", OleDbType.VarChar, 5).Value = NudDjhBegin.Value.ToString.PadLeft(5, "0")
                rcOleDbCommand.Parameters.Add("@djh2", OleDbType.VarChar, 5).Value = NudDjhEnd.Value.ToString.PadLeft(5, "0")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("pzml") IsNot Nothing Then
                    rcDataSet.Tables("pzml").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "pzml")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("pzml").Rows.Count <= 0 Then
                MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
            '调用表单
            Dim rcFrm As New FrmGlPzCxz
            With rcFrm
                .ParaDataSet = rcDataSet
                .WindowState = FormWindowState.Maximized
                .MdiParent = Me.MdiParent
                .Show()
            End With
        End If
    End Sub

    Private Sub ChbLbfs_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbLbfs.CheckedChanged
        If Me.ChbLbfs.Checked Then
            Me.TxtKmdm.Enabled = True
            Me.TxtBmdm.Enabled = True
            Me.TxtXmdm.Enabled = True
        Else
            Me.TxtKmdm.Enabled = False
            Me.TxtBmdm.Enabled = False
            Me.TxtXmdm.Enabled = False
        End If
    End Sub
End Class