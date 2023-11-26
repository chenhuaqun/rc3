Imports System.Data.OleDb

Public Class FrmOeFpImpXsd
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

    Private Sub FrmOeFpImpXsd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '默认值
        Me.DtpBegin.Value = getInvBegin(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        Me.DtpEnd.Value = getInvEnd(Mid(g_Kjqj, 1, 4), Mid(g_Kjqj, 5, 2))
        '取单据类型数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE kjnd = ? AND lxgs = '产品送货单' ORDER BY pzlxdm"
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
        dtCopy = rcDataSet.Tables("rc_fpnr").Copy

        If Me.CheckBox1.Checked Then
            If rcDataSet.Tables("rc_fpnr") IsNot Nothing Then
                rcDataSet.Tables("rc_fpnr").Clear()
            End If
        End If
        '取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT oe_xsd.cpdm,rc_cpxx.oldcpdm,oe_xsd.hth,rc_cpxx.cpmc,(oe_xsd.sl - oe_xsd.fpsl) As sl,rc_cpxx.dw,oe_xsd.mjsl,(oe_xsd.sl - oe_xsd.fpsl) / oe_xsd.sl * oe_xsd.fzsl AS fzsl,rc_cpxx.fzdw,oe_xsd.dj,oe_xsd.hsdj,ROUND(oe_xsd.dj * (oe_xsd.sl - oe_xsd.fpsl),2) AS je,oe_xsd.shlv,ROUND(oe_xsd.dj * (oe_xsd.sl - oe_xsd.fpsl) * oe_xsd.shlv / 100,2) AS se,ROUND(oe_xsd.dj * (oe_xsd.sl - oe_xsd.fpsl),2) + ROUND(oe_xsd.dj * (oe_xsd.sl - oe_xsd.fpsl) * oe_xsd.shlv / 100,2) AS jese,oe_xsd.xsmemo as fpmemo,oe_xsd.dddjh,oe_xsd.ddxh,oe_xsd.djh AS xsddjh,oe_xsd.xh AS xsdxh,oe_xsd.dj AS xsddj,oe_xsd.hsdj AS xsdhsdj,ROUND(oe_xsd.dj * (oe_xsd.sl - oe_xsd.fpsl),2) AS xsdje,oe_xsd.shlv AS xsdshlv,ROUND(oe_xsd.dj * (oe_xsd.sl - oe_xsd.fpsl) * oe_xsd.shlv / 100,2) AS xsdse FROM oe_xsd,rc_cpxx WHERE oe_xsd.cpdm = rc_cpxx.cpdm AND oe_xsd.bdelete = 0 AND TRUNC(oe_xsd.xsrq,'dd') >= ? AND TRUNC(oe_xsd.xsrq,'dd') <= ? AND (oe_xsd.sl - oe_xsd.fpsl > 0 AND oe_xsd.sl > 0 OR oe_xsd.sl - oe_xsd.fpsl < 0 AND oe_xsd.sl < 0)" & IIf(Me.CmbPzlxjc.SelectedValue <> "0000", " AND SUBSTR(oe_xsd.djh,1, 4) ='" & Me.CmbPzlxjc.SelectedValue & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtDjh.Text), " and oe_xsd.djh = '" & Trim(Me.TxtDjh.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtSgddh.Text), " and oe_xsd.hth LIKE '" & Trim(Me.TxtSgddh.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " and oe_xsd.cpdm = '" & Trim(Me.TxtCpdm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpmc.Text), " and rc_cpxx.cpmc Like '%" & Trim(Me.TxtCpmc.Text) & "%'", "") & IIf(Me.ChbSh.Checked, " AND NOT oe_xsd.shr IS NULL", "") & " AND oe_xsd.khdm = ? ORDER BY oe_xsd.djh,oe_xsd.xh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = Me.DtpBegin.Value.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = Me.DtpEnd.Value.Date
            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = strKhdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("t_xsdnr") IsNot Nothing Then
                rcDataSet.Tables("t_xsdnr").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "t_xsdnr")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '倒数据
        '本月数据
        For j = 0 To rcDataSet.Tables("t_xsdnr").Rows.Count - 1
            blnExists = False
            For i = 0 To dtCopy.Rows.Count - 1
                If dtCopy.Rows(i).Item("dddjh").GetType.ToString <> "System.DBNull" And rcDataSet.Tables("t_xsdnr").Rows(j).Item("dddjh").GetType.ToString <> "System.DBNull" And dtCopy.Rows(i).Item("ddxh").GetType.ToString <> "System.DBNull" And rcDataSet.Tables("t_xsdnr").Rows(j).Item("ddxh").GetType.ToString <> "System.DBNull" Then
                    If dtCopy.Rows(i).Item("dddjh") = rcDataSet.Tables("t_xsdnr").Rows(j).Item("dddjh") And dtCopy.Rows(i).Item("ddxh") = rcDataSet.Tables("t_xsdnr").Rows(j).Item("ddxh") Then
                        blnExists = True
                    End If
                End If
            Next
            If Not blnExists Then
                rcDataRow = rcDataSet.Tables("rc_fpnr").NewRow
                rcDataRow.Item("cpdm") = rcDataSet.Tables("t_xsdnr").Rows(j).Item("cpdm")
                rcDataRow.Item("oldcpdm") = rcDataSet.Tables("t_xsdnr").Rows(j).Item("oldcpdm")
                rcDataRow.Item("cpmc") = rcDataSet.Tables("t_xsdnr").Rows(j).Item("cpmc")
                rcDataRow.Item("hth") = rcDataSet.Tables("t_xsdnr").Rows(j).Item("hth")
                rcDataRow.Item("sl") = rcDataSet.Tables("t_xsdnr").Rows(j).Item("sl")
                rcDataRow.Item("dw") = rcDataSet.Tables("t_xsdnr").Rows(j).Item("dw")
                rcDataRow.Item("mjsl") = rcDataSet.Tables("t_xsdnr").Rows(j).Item("mjsl")
                rcDataRow.Item("fzsl") = rcDataSet.Tables("t_xsdnr").Rows(j).Item("fzsl")
                rcDataRow.Item("fzdw") = rcDataSet.Tables("t_xsdnr").Rows(j).Item("fzdw")
                rcDataRow.Item("dj") = rcDataSet.Tables("t_xsdnr").Rows(j).Item("dj")
                rcDataRow.Item("hsdj") = rcDataSet.Tables("t_xsdnr").Rows(j).Item("hsdj")
                rcDataRow.Item("je") = rcDataSet.Tables("t_xsdnr").Rows(j).Item("je")
                rcDataRow.Item("shlv") = rcDataSet.Tables("t_xsdnr").Rows(j).Item("shlv")
                rcDataRow.Item("se") = rcDataSet.Tables("t_xsdnr").Rows(j).Item("se")
                rcDataRow.Item("jese") = rcDataSet.Tables("t_xsdnr").Rows(j).Item("jese")
                rcDataRow.Item("fpmemo") = rcDataSet.Tables("t_xsdnr").Rows(j).Item("fpmemo")
                rcDataRow.Item("dddjh") = rcDataSet.Tables("t_xsdnr").Rows(j).Item("dddjh")
                rcDataRow.Item("ddxh") = rcDataSet.Tables("t_xsdnr").Rows(j).Item("ddxh")
                rcDataRow.Item("xsddjh") = rcDataSet.Tables("t_xsdnr").Rows(j).Item("xsddjh")
                rcDataRow.Item("xsdxh") = rcDataSet.Tables("t_xsdnr").Rows(j).Item("xsdxh")
                rcDataRow.Item("xsddj") = rcDataSet.Tables("t_xsdnr").Rows(j).Item("xsddj")
                rcDataRow.Item("xsdhsdj") = rcDataSet.Tables("t_xsdnr").Rows(j).Item("xsdhsdj")
                rcDataRow.Item("xsdje") = rcDataSet.Tables("t_xsdnr").Rows(j).Item("xsdje")
                rcDataRow.Item("xsdshlv") = rcDataSet.Tables("t_xsdnr").Rows(j).Item("xsdshlv")
                rcDataRow.Item("xsdse") = rcDataSet.Tables("t_xsdnr").Rows(j).Item("xsdse")
                rcDataSet.Tables("rc_fpnr").Rows.Add(rcDataRow)
            End If
        Next
        If rcDataSet.Tables("rc_fpnr").Rows.Count <= 0 Then
            MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
    End Sub
End Class