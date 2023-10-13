Imports System.Data.OleDb

Public Class FrmOeXsdImpFhd
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    Dim rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    Dim strKhdm As String = ""

    Public Property ParaStrKhdm() As String
        Get
            ParaStrKhdm = strKhdm
        End Get
        Set(ByVal Value As String)
            strKhdm = Value
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

    Private Sub FrmOeXsdImpFhd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DtpFhrq.Value = g_Kjrq
    End Sub

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDjh.KeyPress, TxtCpdm.KeyPress, TxtCpmc.KeyPress, TxtSgddh.KeyPress
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
        Dim i As Integer
        Dim j As Integer
        Dim rcDataRow As DataRow
        Dim blnExists As Boolean
        '倒数据
        Dim dtCopy As DataTable
        dtCopy = rcDataSet.Tables("rc_xsdnr").Copy

        If Me.CheckBox1.Checked Then
            If rcDataSet.Tables("rc_xsdnr") IsNot Nothing Then
                rcDataSet.Tables("rc_xsdnr").Clear()
            End If
        End If
        '取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT oe_fhd.cpdm,rc_cpxx.oldcpdm,oe_fhd.hth,oe_fhd.khddh,oe_fhd.khlh,rc_cpxx.cpmc,oe_fhd.sl,oe_fhd.dw,oe_fhd.mjsl,oe_fhd.fzsl,oe_fhd.fzdw,0 AS dj,0 AS hsdj,0 AS je,0 AS shlv,0 AS se,0 AS jese,oe_fhd.fhmemo as xsmemo,oe_fhd.dddjh,oe_fhd.ddxh FROM oe_fhd,rc_cpxx WHERE oe_fhd.cpdm = rc_cpxx.cpdm AND oe_fhd.bclosed = 0 AND TRUNC(oe_fhd.fhrq,'dd') = ?" & IIf(Not String.IsNullOrEmpty(Me.TxtDjh.Text), " and oe_fhd.djh = '" & Trim(Me.TxtDjh.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtSgddh.Text), " and oe_fhd.hth LIKE '" & Trim(Me.TxtSgddh.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " and oe_fhd.cpdm = '" & Trim(Me.TxtCpdm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpmc.Text), " and rc_cpxx.cpmc Like '%" & Trim(Me.TxtCpmc.Text) & "%'", "") & IIf(Me.ChbSh.Checked, " AND NOT oe_fhd.shr IS NULL", "") & " AND oe_fhd.khdm = ? ORDER BY oe_fhd.djh,oe_fhd.xh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@fhrq", OleDbType.Date, 8).Value = Me.DtpFhrq.Value.Date
            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = strKhdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("t_ddnr") IsNot Nothing Then
                rcDataSet.Tables("t_ddnr").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "t_ddnr")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '倒数据
        '本月数据
        For j = 0 To rcDataSet.Tables("t_ddnr").Rows.Count - 1

            blnExists = False
            For i = 0 To dtCopy.Rows.Count - 1
                If dtCopy.Rows(i).Item("dddjh").GetType.ToString <> "System.DBNull" And rcDataSet.Tables("t_ddnr").Rows(j).Item("dddjh").GetType.ToString <> "System.DBNull" And dtCopy.Rows(i).Item("ddxh").GetType.ToString <> "System.DBNull" And rcDataSet.Tables("t_ddnr").Rows(j).Item("ddxh").GetType.ToString <> "System.DBNull" Then
                    If dtCopy.Rows(i).Item("dddjh") = rcDataSet.Tables("t_ddnr").Rows(j).Item("dddjh") And dtCopy.Rows(i).Item("ddxh") = rcDataSet.Tables("t_ddnr").Rows(j).Item("ddxh") Then
                        blnExists = True
                    End If
                End If
            Next
            If Not blnExists Then
                rcDataRow = rcDataSet.Tables("rc_xsdnr").NewRow
                rcDataRow.Item("cpdm") = rcDataSet.Tables("t_ddnr").Rows(j).Item("cpdm")
                rcDataRow.Item("oldcpdm") = rcDataSet.Tables("t_ddnr").Rows(j).Item("oldcpdm")
                rcDataRow.Item("cpmc") = rcDataSet.Tables("t_ddnr").Rows(j).Item("cpmc")
                rcDataRow.Item("hth") = rcDataSet.Tables("t_ddnr").Rows(j).Item("hth")
                rcDataRow.Item("khddh") = rcDataSet.Tables("t_ddnr").Rows(j).Item("khddh")
                rcDataRow.Item("khlh") = rcDataSet.Tables("t_ddnr").Rows(j).Item("khlh")
                rcDataRow.Item("sl") = rcDataSet.Tables("t_ddnr").Rows(j).Item("sl")
                rcDataRow.Item("dw") = rcDataSet.Tables("t_ddnr").Rows(j).Item("dw")
                rcDataRow.Item("mjsl") = rcDataSet.Tables("t_ddnr").Rows(j).Item("mjsl")
                rcDataRow.Item("fzsl") = rcDataSet.Tables("t_ddnr").Rows(j).Item("fzsl")
                rcDataRow.Item("fzdw") = rcDataSet.Tables("t_ddnr").Rows(j).Item("fzdw")
                rcDataRow.Item("dj") = rcDataSet.Tables("t_ddnr").Rows(j).Item("dj")
                rcDataRow.Item("hsdj") = rcDataSet.Tables("t_ddnr").Rows(j).Item("hsdj")
                rcDataRow.Item("je") = rcDataSet.Tables("t_ddnr").Rows(j).Item("je")
                rcDataRow.Item("shlv") = rcDataSet.Tables("t_ddnr").Rows(j).Item("shlv")
                rcDataRow.Item("se") = rcDataSet.Tables("t_ddnr").Rows(j).Item("se")
                rcDataRow.Item("jese") = rcDataSet.Tables("t_ddnr").Rows(j).Item("jese")
                rcDataRow.Item("xsmemo") = rcDataSet.Tables("t_ddnr").Rows(j).Item("xsmemo")
                rcDataRow.Item("dddjh") = rcDataSet.Tables("t_ddnr").Rows(j).Item("dddjh")
                rcDataRow.Item("ddxh") = rcDataSet.Tables("t_ddnr").Rows(j).Item("ddxh")
                rcDataSet.Tables("rc_xsdnr").Rows.Add(rcDataRow)
            End If
        Next
        '查找销售价格数据
        For i = 0 To rcDataSet.Tables("rc_xsdnr").Rows.Count - 1
            '取销售订单中的价格数据
            If rcDataSet.Tables("rc_xsdnr").Rows(i).Item("dddjh").GetType.ToString <> "System.DBNull" And rcDataSet.Tables("rc_xsdnr").Rows(i).Item("ddxh").GetType.ToString <> "System.DBNull" Then
                Try
                    rcOleDbConn.Open()
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    rcOleDbCommand.CommandText = "SELECT oe_dd.dj,oe_dd.hsdj,oe_dd.shlv FROM oe_dd WHERE oe_dd.djh = ? AND oe_dd.xh = ? ORDER BY oe_dd.djh,oe_dd.xh"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataSet.Tables("rc_xsdnr").Rows(i).Item("dddjh")
                    rcOleDbCommand.Parameters.Add("@xh", OleDbType.VarChar, 4).Value = rcDataSet.Tables("rc_xsdnr").Rows(i).Item("ddxh")
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataSet.Tables("oe_dd") IsNot Nothing Then
                        rcDataSet.Tables("oe_dd").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataSet, "oe_dd")
                    If rcDataSet.Tables("oe_dd").Rows.Count > 0 Then
                        rcDataSet.Tables("rc_xsdnr").Rows(i).Item("dj") = rcDataSet.Tables("oe_dd").Rows(0).Item("dj")
                        rcDataSet.Tables("rc_xsdnr").Rows(i).Item("hsdj") = rcDataSet.Tables("oe_dd").Rows(0).Item("hsdj")
                        rcDataSet.Tables("rc_xsdnr").Rows(i).Item("shlv") = rcDataSet.Tables("oe_dd").Rows(0).Item("shlv")
                        rcDataSet.Tables("rc_xsdnr").Rows(i).Item("je") = System.Math.Round(rcDataSet.Tables("oe_dd").Rows(0).Item("dj") * rcDataSet.Tables("rc_xsdnr").Rows(i).Item("sl"), 2)
                        rcDataSet.Tables("rc_xsdnr").Rows(i).Item("jese") = System.Math.Round(rcDataSet.Tables("oe_dd").Rows(0).Item("hsdj") * rcDataSet.Tables("rc_xsdnr").Rows(i).Item("sl"), 2)
                        rcDataSet.Tables("rc_xsdnr").Rows(i).Item("se") = rcDataSet.Tables("rc_xsdnr").Rows(i).Item("jese") - rcDataSet.Tables("rc_xsdnr").Rows(i).Item("je")
                    End If
                Catch ex As Exception
                    MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                    Return
                Finally
                    rcOleDbConn.Close()
                End Try
            End If
        Next

        If rcDataSet.Tables("rc_xsdnr").Rows.Count <= 0 Then
            MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
    End Sub
End Class