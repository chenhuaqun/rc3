Imports System.Data.OleDb

Public Class FrmPoCgdImpDd
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    Dim rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
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

    Private Sub FrmPoCgdImpDd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            If rcDataSet.Tables("cgjhlx") IsNot Nothing Then
                Me.rcDataSet.Tables("cgjhlx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "cgjhlx")
        Catch ex As Exception
            MsgBox("程序错误。读取单据类型。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Dim rcDataRow As DataRow
        rcDataRow = rcDataSet.Tables("cgjhlx").NewRow
        rcDataRow.Item("pzlxdm") = "0000"
        rcDataRow.Item("pzlxjc") = "全部单据"
        rcDataSet.Tables("cgjhlx").Rows.Add(rcDataRow)
        If rcDataSet.Tables("cgjhlx").Rows.Count = 0 Then
            MsgBox("请定义单据类型。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        BindDropDownList(CmbPzlxjc, rcDataSet.Tables("cgjhlx"), "pzlxdm", "pzlxjc")
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
        '倒数据
        Dim dtCopy As DataTable
        dtCopy = rcDataSet.Tables("rc_cgdnr").Copy

        If Me.CheckBox1.Checked Then
            If rcDataSet.Tables("rc_cgdnr") IsNot Nothing Then
                rcDataSet.Tables("rc_cgdnr").Clear()
            End If
        End If
        '取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT oe_dd.cpdm,rc_cpxx.oldcpdm,rc_cpxx.cpmc,oe_dd.khjhrq,oe_dd.sl,rc_cpxx.dw,oe_dd.mjsl,oe_dd.fzsl,oe_dd.fzdw,0 AS dj,0 AS hsdj,0.0 AS je,0 AS shlv,0 AS se,0 AS jese,oe_dd.ddmemo as cgmemo,'' AS cgjhdjh,0 AS cgjhxh FROM oe_dd,rc_cpxx WHERE oe_dd.cpdm = rc_cpxx.cpdm AND oe_dd.bclosed = 0" & IIf(Me.CmbPzlxjc.SelectedValue <> "0000", " AND SUBSTR(oe_dd.djh,1, 4) ='" & Me.CmbPzlxjc.SelectedValue & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtDjh.Text), " and oe_dd.djh = '" & Trim(Me.TxtDjh.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtSgddh.Text), " and oe_dd.hth LIKE '%" & Trim(Me.TxtSgddh.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " and oe_dd.cpdm = '" & Trim(Me.TxtCpdm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpmc.Text), " and rc_cpxx.cpmc Like '%" & Trim(Me.TxtCpmc.Text) & "%'", "") & " AND NOT oe_dd.shr IS NULL ORDER BY oe_dd.djh,oe_dd.xh" ' AND ((oe_dd.sl > 0 AND oe_dd.sl - oe_dd.cgsl > 0) OR (oe_dd.sl < 0 AND oe_dd.sl - oe_dd.cgsl < 0))
            rcOleDbCommand.Parameters.Clear()
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
            'blnExists = False
            'For i = 0 To dtCopy.Rows.Count - 1
            '    If dtCopy.Rows(i).Item("cgjhdjh").GetType.ToString <> "System.DBNull" And rcDataSet.Tables("t_ddnr").Rows(j).Item("cgjhdjh").GetType.ToString <> "System.DBNull" And dtCopy.Rows(i).Item("cgjhxh").GetType.ToString <> "System.DBNull" And rcDataSet.Tables("t_ddnr").Rows(j).Item("cgjhxh").GetType.ToString <> "System.DBNull" Then
            '        If dtCopy.Rows(i).Item("cgjhdjh") = rcDataSet.Tables("t_ddnr").Rows(j).Item("cgjhdjh") And dtCopy.Rows(i).Item("cgjhxh") = rcDataSet.Tables("t_ddnr").Rows(j).Item("cgjhxh") Then
            '            blnExists = True
            '        End If
            '    End If
            'Next
            'If Not blnExists Then
            rcDataRow = rcDataSet.Tables("rc_cgdnr").NewRow
            rcDataRow.Item("cpdm") = rcDataSet.Tables("t_ddnr").Rows(j).Item("cpdm")
            rcDataRow.Item("oldcpdm") = rcDataSet.Tables("t_ddnr").Rows(j).Item("oldcpdm")
            rcDataRow.Item("cpmc") = rcDataSet.Tables("t_ddnr").Rows(j).Item("cpmc")
            rcDataRow.Item("jhshrq") = rcDataSet.Tables("t_ddnr").Rows(j).Item("khjhrq")
            rcDataRow.Item("sl") = rcDataSet.Tables("t_ddnr").Rows(j).Item("sl")
            rcDataRow.Item("dw") = rcDataSet.Tables("t_ddnr").Rows(j).Item("dw")
            rcDataRow.Item("mjsl") = rcDataSet.Tables("t_ddnr").Rows(j).Item("mjsl")
            rcDataRow.Item("fzsl") = rcDataSet.Tables("t_ddnr").Rows(j).Item("fzsl")
            rcDataRow.Item("fzdw") = rcDataSet.Tables("t_ddnr").Rows(j).Item("fzdw")
            rcDataRow.Item("dj") = 0
            rcDataRow.Item("je") = 0
            rcDataRow.Item("cgmemo") = rcDataSet.Tables("t_ddnr").Rows(j).Item("cgmemo")
            rcDataRow.Item("cgjhdjh") = rcDataSet.Tables("t_ddnr").Rows(j).Item("cgjhdjh")
            rcDataRow.Item("cgjhxh") = rcDataSet.Tables("t_ddnr").Rows(j).Item("cgjhxh")
            rcDataSet.Tables("rc_cgdnr").Rows.Add(rcDataRow)
            'End If
        Next
        For i = 0 To rcDataSet.Tables("rc_cgdnr").Rows.Count - 1
            '取供应商采购价格目录中的数据
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT po_cscpcgdj.cgdj FROM po_cscpcgdj WHERE po_cscpcgdj.csdm = ? AND po_cscpcgdj.cpdm = ? ORDER BY po_cscpcgdj.cgdj"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = strCsdm
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataSet.Tables("rc_cgdnr").Rows(i).Item("cpdm")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("po_cscpcgdj") IsNot Nothing Then
                    rcDataSet.Tables("po_cscpcgdj").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "po_cscpcgdj")
                If rcDataSet.Tables("po_cscpcgdj").Rows.Count > 0 Then
                    rcDataSet.Tables("rc_cgdnr").Rows(i).Item("dj") = rcDataSet.Tables("po_cscpcgdj").Rows(0).Item("cgdj")
                    rcDataSet.Tables("rc_cgdnr").Rows(i).Item("hsdj") = rcDataSet.Tables("rc_cgdnr").Rows(i).Item("dj") * (1 + rcDataSet.Tables("rc_cgdnr").Rows(i).Item("shlv") / 100)
                    rcDataSet.Tables("rc_cgdnr").Rows(i).Item("je") = System.Math.Round(rcDataSet.Tables("po_cscpcgdj").Rows(0).Item("cgdj") * rcDataSet.Tables("rc_cgdnr").Rows(i).Item("sl"), 2, MidpointRounding.AwayFromZero)
                    rcDataSet.Tables("rc_cgdnr").Rows(i).Item("se") = System.Math.Round(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("je") * rcDataSet.Tables("rc_cgdnr").Rows(i).Item("shlv") / 100, 2, MidpointRounding.AwayFromZero)
                    rcDataSet.Tables("rc_cgdnr").Rows(i).Item("jese") = rcDataSet.Tables("rc_cgdnr").Rows(i).Item("je") + rcDataSet.Tables("rc_cgdnr").Rows(i).Item("se")
                Else
                    '取上次的采购的供应商及上次的采购价格
                    rcOleDbCommand.CommandText = "SELECT po_cgd.dj FROM po_cgd WHERE po_cgd.dj <> 0 AND po_cgd.csdm = ? AND po_cgd.cpdm = ? ORDER BY po_cgd.djh DESC,po_cgd.xh DESC"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = strCsdm
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataSet.Tables("rc_cgdnr").Rows(i).Item("cpdm")
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataSet.Tables("lastcgd") IsNot Nothing Then
                        rcDataSet.Tables("lastcgd").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataSet, "lastcgd")
                    If rcDataSet.Tables("lastcgd").Rows.Count > 0 Then
                        rcDataSet.Tables("rc_cgdnr").Rows(i).Item("dj") = rcDataSet.Tables("lastcgd").Rows(0).Item("dj")
                        rcDataSet.Tables("rc_cgdnr").Rows(i).Item("hsdj") = rcDataSet.Tables("rc_cgdnr").Rows(i).Item("dj") * (1 + rcDataSet.Tables("rc_cgdnr").Rows(i).Item("shlv") / 100)
                        rcDataSet.Tables("rc_cgdnr").Rows(i).Item("je") = System.Math.Round(rcDataSet.Tables("lastcgd").Rows(0).Item("dj") * rcDataSet.Tables("rc_cgdnr").Rows(i).Item("sl"), 2, MidpointRounding.AwayFromZero)
                        rcDataSet.Tables("rc_cgdnr").Rows(i).Item("se") = System.Math.Round(rcDataSet.Tables("rc_cgdnr").Rows(i).Item("je") * rcDataSet.Tables("rc_cgdnr").Rows(i).Item("shlv") / 100, 2, MidpointRounding.AwayFromZero)
                        rcDataSet.Tables("rc_cgdnr").Rows(i).Item("jese") = rcDataSet.Tables("rc_cgdnr").Rows(i).Item("je") + rcDataSet.Tables("rc_cgdnr").Rows(i).Item("se")
                    End If
                End If
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        Next
        If rcDataSet.Tables("rc_cgdnr").Rows.Count <= 0 Then
            MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
    End Sub
End Class