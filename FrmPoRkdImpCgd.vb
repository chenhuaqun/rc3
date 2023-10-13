Imports System.Data.OleDb

Public Class FrmPoRkdImpCgd
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

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCpdm.KeyPress, TxtCpmc.KeyPress, TxtDjh.KeyPress, TxtSgddh.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

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
                If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_cpxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_cpxx").Rows.Count = 0 Then
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim i As Integer
        Dim j As Integer
        Dim rcDataRow As DataRow
        Dim blnExists As Boolean
        '倒数据
        Dim dtCopy As DataTable
        dtCopy = rcDataSet.Tables("rc_rkdnr").Copy
        '取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT po_cgd.cpdm,rc_cpxx.oldcpdm,rc_cpxx.cpmc,rc_cpxx.dw,rc_cpxx.kuwei,po_cgd.sgddh,'' AS pihao,po_cgd.sl - po_cgd.rksl As sl,po_cgd.mjsl,(po_cgd.sl - po_cgd.rksl) / po_cgd.sl * po_cgd.fzsl AS fzsl,rc_cpxx.fzdw,po_cgd.dj,po_cgd.hsdj,ROUND(po_cgd.dj * (po_cgd.sl - po_cgd.rksl),2) AS je,po_cgd.shlv,ROUND(po_cgd.dj * (po_cgd.sl - po_cgd.rksl)*po_cgd.shlv/100,2) AS se,ROUND(po_cgd.hsdj * (po_cgd.sl - po_cgd.rksl),2) AS jese,po_cgd.cgmemo AS rkmemo,po_cgd.djh AS cgddjh,po_cgd.xh AS cgdxh FROM po_cgd,rc_cpxx WHERE po_cgd.cpdm = rc_cpxx.cpdm AND ((po_cgd.sl > 0 AND po_cgd.sl > po_cgd.rksl) OR (po_cgd.sl < 0 AND po_cgd.sl < po_cgd.rksl)) AND po_cgd.bclosed  = 0 AND NOT po_cgd.shr IS NULL" & IIf(Not String.IsNullOrEmpty(Me.TxtDjh.Text), " and po_cgd.djh = '" & Trim(Me.TxtDjh.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtSgddh.Text), " and po_cgd.sgddh = '" & Trim(Me.TxtSgddh.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " AND po_cgd.cpdm = '" & Trim(Me.TxtCpdm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpmc.Text), " AND po_cgd.cpmc Like '%" & Trim(Me.TxtCpmc.Text) & "%'", "") & " AND po_cgd.csdm = ? ORDER BY po_cgd.xh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = strCsdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("t_rkdnr") IsNot Nothing Then
                rcDataSet.Tables("t_rkdnr").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "t_rkdnr")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '倒数据
        '本月数据
        For j = 0 To rcDataSet.Tables("t_rkdnr").Rows.Count - 1
            blnExists = False
            For i = 0 To dtCopy.Rows.Count - 1
                If dtCopy.Rows(i).Item("cgddjh") = rcDataSet.Tables("t_rkdnr").Rows(j).Item("cgddjh") And dtCopy.Rows(i).Item("cgdxh") = rcDataSet.Tables("t_rkdnr").Rows(j).Item("cgdxh") Then
                    blnExists = True
                End If
            Next
            If Not blnExists Then
                rcDataRow = rcDataSet.Tables("rc_rkdnr").NewRow
                rcDataRow.Item("cpdm") = rcDataSet.Tables("t_rkdnr").Rows(j).Item("cpdm")
                rcDataRow.Item("oldcpdm") = rcDataSet.Tables("t_rkdnr").Rows(j).Item("oldcpdm")
                rcDataRow.Item("cpmc") = rcDataSet.Tables("t_rkdnr").Rows(j).Item("cpmc")
                rcDataRow.Item("dw") = rcDataSet.Tables("t_rkdnr").Rows(j).Item("dw")
                rcDataRow.Item("kuwei") = rcDataSet.Tables("t_rkdnr").Rows(j).Item("kuwei")
                rcDataRow.Item("sgddh") = rcDataSet.Tables("t_rkdnr").Rows(j).Item("sgddh")
                rcDataRow.Item("pihao") = rcDataSet.Tables("t_rkdnr").Rows(j).Item("pihao")
                rcDataRow.Item("sl") = rcDataSet.Tables("t_rkdnr").Rows(j).Item("sl")
                rcDataRow.Item("mjsl") = rcDataSet.Tables("t_rkdnr").Rows(j).Item("mjsl")
                rcDataRow.Item("fzsl") = rcDataSet.Tables("t_rkdnr").Rows(j).Item("fzsl")
                rcDataRow.Item("fzdw") = rcDataSet.Tables("t_rkdnr").Rows(j).Item("fzdw")
                rcDataRow.Item("dj") = rcDataSet.Tables("t_rkdnr").Rows(j).Item("dj")
                rcDataRow.Item("hsdj") = rcDataSet.Tables("t_rkdnr").Rows(j).Item("hsdj")
                rcDataRow.Item("je") = rcDataSet.Tables("t_rkdnr").Rows(j).Item("je")
                rcDataRow.Item("shlv") = rcDataSet.Tables("t_rkdnr").Rows(j).Item("shlv")
                rcDataRow.Item("se") = rcDataSet.Tables("t_rkdnr").Rows(j).Item("se")
                rcDataRow.Item("jese") = rcDataSet.Tables("t_rkdnr").Rows(j).Item("jese")
                rcDataRow.Item("rkmemo") = rcDataSet.Tables("t_rkdnr").Rows(j).Item("rkmemo")
                rcDataRow.Item("cgddjh") = rcDataSet.Tables("t_rkdnr").Rows(j).Item("cgddjh")
                rcDataRow.Item("cgdxh") = rcDataSet.Tables("t_rkdnr").Rows(j).Item("cgdxh")
                rcDataSet.Tables("rc_rkdnr").Rows.Add(rcDataRow)
            End If
        Next

        If rcDataSet.Tables("rc_rkdnr").Rows.Count <= 0 Then
            MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
    End Sub
End Class