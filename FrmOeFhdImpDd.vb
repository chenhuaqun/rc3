Imports System.Data.OleDb

Public Class FrmOeFhdImpDd
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

    Private Sub FrmOeFhdImpDd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '取单据类型数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE kjnd = ? AND lxgs = '产品销售订单' ORDER BY pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("ddlx") IsNot Nothing Then
                Me.rcDataSet.Tables("ddlx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "ddlx")
        Catch ex As Exception
            MsgBox("程序错误。读取单据类型。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Dim rcDataRow As DataRow
        rcDataRow = rcDataSet.Tables("ddlx").NewRow
        rcDataRow.Item("pzlxdm") = "0000"
        rcDataRow.Item("pzlxjc") = "全部单据"
        rcDataSet.Tables("ddlx").Rows.Add(rcDataRow)
        If rcDataSet.Tables("ddlx").Rows.Count = 0 Then
            MsgBox("请定义单据类型。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        BindDropDownList(CmbPzlxjc, rcDataSet.Tables("ddlx"), "pzlxdm", "pzlxjc")
        CmbPzlxjc.SelectedValue = "0000"
    End Sub

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbPzlxjc.KeyPress, TxtDjh.KeyPress, TxtCpdm.KeyPress, TxtCpmc.KeyPress, TxtSgddh.KeyPress
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
        dtCopy = rcDataSet.Tables("rc_fhdnr").Copy

        If Me.CheckBox1.Checked Then
            If rcDataSet.Tables("rc_fhdnr") IsNot Nothing Then
                rcDataSet.Tables("rc_fhdnr").Clear()
            End If
        End If
        '取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT oe_dd.cpdm,rc_cpxx.oldcpdm,oe_dd.hth,oe_dd.khddh,oe_dd.khlh,rc_cpxx.cpmc,(oe_dd.sl - oe_dd.hxsl - oe_dd.cksl) As sl,oe_dd.dw,oe_dd.mjsl,(oe_dd.sl - oe_dd.hxsl - oe_dd.cksl) / oe_dd.sl * oe_dd.fzsl AS fzsl,oe_dd.fzdw,oe_dd.ddmemo as fhmemo,oe_dd.scjhrq,oe_dd.djh AS dddjh,oe_dd.xh AS ddxh FROM oe_dd,rc_cpxx WHERE oe_dd.cpdm = rc_cpxx.cpdm AND (oe_dd.sl - oe_dd.hxsl - oe_dd.cksl > 0 AND oe_dd.sl > 0" & IIf(Me.CheckBox2.Checked, " OR oe_dd.sl - oe_dd.hxsl - oe_dd.cksl < 0 AND oe_dd.sl < 0", "") & ") AND oe_dd.bclosed = 0" & IIf(Me.CmbPzlxjc.SelectedValue <> "0000", " AND SUBSTR(oe_dd.djh,1, 4) ='" & Me.CmbPzlxjc.SelectedValue & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtDjh.Text), " and oe_dd.djh = '" & Trim(Me.TxtDjh.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtSgddh.Text), " and oe_dd.hth LIKE '" & Trim(Me.TxtSgddh.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " and oe_dd.cpdm = '" & Trim(Me.TxtCpdm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpmc.Text), " and rc_cpxx.cpmc Like '%" & Trim(Me.TxtCpmc.Text) & "%'", "") & " AND NOT oe_dd.shr IS NULL AND oe_dd.khdm = ? ORDER BY oe_dd.scjhrq,oe_dd.djh,oe_dd.xh"
            rcOleDbCommand.Parameters.Clear()
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
                rcDataRow = rcDataSet.Tables("rc_fhdnr").NewRow
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
                rcDataRow.Item("fhmemo") = rcDataSet.Tables("t_ddnr").Rows(j).Item("fhmemo")
                rcDataRow.Item("scjhrq") = rcDataSet.Tables("t_ddnr").Rows(j).Item("scjhrq")
                rcDataRow.Item("dddjh") = rcDataSet.Tables("t_ddnr").Rows(j).Item("dddjh")
                rcDataRow.Item("ddxh") = rcDataSet.Tables("t_ddnr").Rows(j).Item("ddxh")
                'rcDataRow.Item("xsddj") = rcDataSet.Tables("t_ddnr").Rows(j).Item("xsddj")
                'rcDataRow.Item("xsdhsdj") = rcDataSet.Tables("t_ddnr").Rows(j).Item("xsdhsdj")
                'rcDataRow.Item("xsdje") = rcDataSet.Tables("t_ddnr").Rows(j).Item("xsdje")
                'rcDataRow.Item("xsdshlv") = rcDataSet.Tables("t_ddnr").Rows(j).Item("xsdshlv")
                'rcDataRow.Item("xsdse") = rcDataSet.Tables("t_ddnr").Rows(j).Item("xsdse")
                rcDataSet.Tables("rc_fhdnr").Rows.Add(rcDataRow)
            End If
        Next
        If rcDataSet.Tables("rc_fhdnr").Rows.Count <= 0 Then
            MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
    End Sub
End Class