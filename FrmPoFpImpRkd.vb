Imports System.Data.OleDb

Public Class FrmPoFpImpRkd
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    Dim rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '客户编码
    Dim strCsdm As String = ""

    Public Property ParaStrCsdm() As String
        Get
            ParaStrCsdm = strCsdm
        End Get
        Set(ByVal Value As String)
            strCsdm = Value
        End Set
    End Property

    Public Property ParaDataSet() As DataSet
        Get
            ParaDataSet = rcDataSet
        End Get
        Set(ByVal Value As DataSet)
            rcDataSet = Value
        End Set
    End Property

    Private Sub FrmPoFpImpRkd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        Me.DtpBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        Me.DtpEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
    End Sub

#Region "物料编码事件"

    Private Sub TxtCpdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCpdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF34
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_cpxx"
                    .paraField1 = "cpdm"
                    .paraField2 = "cpmc"
                    .paraField3 = "dw"
                    .paraField4 = "cpsm"
                    .paraOrderField = "cpmc"
                    .paraTitle = "物料"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtCpdm.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtCpdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCpdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtCpdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT cpdm,cpmc,dw,kuwei FROM rc_cpxx WHERE (cpdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_cpxx") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_cpxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_cpxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_cpxx").Rows.Count = 0 Then
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        '取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT po_rkd.cpdm,rc_cpxx.cpmc,po_rkd.sgddh,rc_cpxx.dw,rc_cpxx.oldcpdm,po_rkd.sl - po_rkd.fpsl As sl,po_rkd.dj,po_rkd.hsdj,ROUND(po_rkd.dj * (po_rkd.sl - po_rkd.fpsl),2) AS je,po_rkd.shlv,ROUND(po_rkd.dj * (po_rkd.sl - po_rkd.fpsl)*po_rkd.shlv/100,2) AS se,ROUND(po_rkd.hsdj * (po_rkd.sl - po_rkd.fpsl),2) AS jese,po_rkd.rkmemo AS fpmemo,po_rkd.cgddjh,po_rkd.cgdxh,po_rkd.djh AS rkddjh,po_rkd.xh AS rkdxh,po_rkd.dj AS rkddj,po_rkd.hsdj AS rkdhsdj,ROUND(po_rkd.dj * (po_rkd.sl - po_rkd.fpsl),2) AS rkdje,po_rkd.shlv AS rkdshlv,ROUND(po_rkd.dj * (po_rkd.sl - po_rkd.fpsl)*po_rkd.shlv/100,2) AS rkdse FROM po_rkd,rc_cpxx WHERE po_rkd.bdelete = 0 AND po_rkd.cpdm = rc_cpxx.cpdm AND po_rkd.rkrq >= ? AND po_rkd.rkrq <= ? AND ((po_rkd.sl > 0 AND po_rkd.sl > po_rkd.fpsl) OR (po_rkd.sl < 0 AND po_rkd.sl < po_rkd.fpsl))" & IIf(Not String.IsNullOrEmpty(Me.TxtRkdDjh.Text), " and po_rkd.djh = '" & Trim(Me.TxtRkdDjh.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCgdDjh.Text), " and po_rkd.cgddjh = '" & Trim(Me.TxtCgdDjh.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtSgddh.Text), " and po_rkd.sgddh LIKE '%" & Trim(Me.TxtSgddh.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " AND po_rkd.cpdm = '" & Trim(Me.TxtCpdm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpmc.Text), " AND po_rkd.cpmc Like '%" & Trim(Me.TxtCpmc.Text) & "%'", "") & " AND po_rkd.csdm = ? ORDER BY po_rkd.djh,po_rkd.xh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = Me.DtpBegin.Value
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = Me.DtpEnd.Value
            rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = strCsdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If Me.CheckBox1.Checked Then
                If rcDataSet.Tables("rc_fpnr") IsNot Nothing Then
                    rcDataSet.Tables("rc_fpnr").Clear()
                End If
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_fpnr")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("rc_fpnr").Rows.Count <= 0 Then
            MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
    End Sub
End Class