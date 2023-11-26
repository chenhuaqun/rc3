Imports System.Data.OleDb

Public Class FrmKhYszkHxMx
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable
    ReadOnly dtKhYszkHxMx As New DataTable("khyszkhxmx")

    Private Sub FrmKhYszkHxMx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        NudYear.Value = Mid(g_Kjqj, 1, 4)
        NudMonthBegin.Value = 1
        NudMonthEnd.Value = Mid(g_Kjqj, 5, 2)
        '创建datatable
        dtKhYszkHxMx.Columns.Add("khdm", Type.GetType("System.String"))
        dtKhYszkHxMx.Columns.Add("khmc", Type.GetType("System.String"))
        dtKhYszkHxMx.Columns.Add("fprq", Type.GetType("System.DateTime"))
        dtKhYszkHxMx.Columns.Add("xsddjh", Type.GetType("System.String"))
        dtKhYszkHxMx.Columns.Add("xsdxh", Type.GetType("System.Int32"))
        dtKhYszkHxMx.Columns.Add("cpdm", Type.GetType("System.String"))
        dtKhYszkHxMx.Columns.Add("cpmc", Type.GetType("System.String"))
        dtKhYszkHxMx.Columns.Add("dw", Type.GetType("System.String"))
        dtKhYszkHxMx.Columns.Add("xssl", Type.GetType("System.Double"))
        dtKhYszkHxMx.Columns.Add("xsdj", Type.GetType("System.Double"))
        dtKhYszkHxMx.Columns.Add("xsje", Type.GetType("System.Double"))
        dtKhYszkHxMx.Columns.Add("skrq", Type.GetType("System.DateTime"))
        dtKhYszkHxMx.Columns.Add("skddjh", Type.GetType("System.String"))
        dtKhYszkHxMx.Columns.Add("skje", Type.GetType("System.Double"))
        dtKhYszkHxMx.Columns.Add("hxje", Type.GetType("System.Double"))
        dtKhYszkHxMx.Columns.Add("bzcb", Type.GetType("System.Double"))
        dtKhYszkHxMx.Columns.Add("xstcbl", Type.GetType("System.Double")) '销售提成比例
        dtKhYszkHxMx.Columns.Add("skts", Type.GetType("System.Double")) '收款天数
        dtKhYszkHxMx.Columns.Add("skqx", Type.GetType("System.Double")) '收款期限
        rcDataset.Tables.Add(dtKhYszkHxMx)
        With rcDataset.Tables("khyszkhxmx")
            .Columns("khdm").DefaultValue = ""
            .Columns("khmc").DefaultValue = ""
            .Columns("xsddjh").DefaultValue = ""
            .Columns("xsdxh").DefaultValue = 0
            .Columns("cpdm").DefaultValue = ""
            .Columns("xsje").DefaultValue = 0.0
            .Columns("hxje").DefaultValue = 0.0
            .Columns("bzcb").DefaultValue = 0.0
            .Columns("xstcbl").DefaultValue = 0.0
            .Columns("skddjh").DefaultValue = ""
            .Columns("skje").DefaultValue = 0.0
        End With
    End Sub


#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NudYear.KeyPress, NudMonthBegin.KeyPress, NudMonthEnd.KeyPress, TxtKhdm.KeyPress, TxtZydm.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

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
                'LblKhmc.Text = Trim(rcDataset.Tables("rc_khxx").Rows(0).Item("khmc"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "职员编码事件"

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
                    .paraOrderField = "zydm"
                    .paraTitle = "职员"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtZydm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If String.IsNullOrEmpty(Me.TxtKhdm.Text) And String.IsNullOrEmpty(Me.TxtZydm.Text) Then
            Return
        End If
        '清空数据
        rcDataset.Tables("khyszkhxmx").Clear()
        'Dim i As Integer
        Dim rqBegin As Date
        Dim rqEnd As Date
        Dim dblYe As Double = 0.0
        rqBegin = getInvBegin(NudYear.Value, NudMonthBegin.Value)
        rqEnd = getInvEnd(NudYear.Value, NudMonthEnd.Value)
        '读取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT akhyszkhxmx.*,rc_cpxx.xstcbl FROM (SELECT oe_fp.khdm,oe_fp.khmc,oe_fp.fprq,oe_fp.djh as xsddjh,oe_fp.xh AS xsdxh,oe_fp.cpdm,oe_fp.cpmc,oe_fp.dw,oe_fp.sl AS xssl,oe_fp.dj AS xsdj,oe_fp.je AS xsje,ar_xsdskd.je AS hxje,ar_skd.skrq,ar_skd.djh AS skddjh,ar_skd.je AS skje,ar_xsdskd.bzcb,ar_skd.skrq - oe_fp.fprq AS skts,rc_khxx.skqx FROM rc_khxx,oe_fp,ar_xsdskd,ar_skd WHERE rc_khxx.khdm = oe_fp.khdm AND oe_fp.djh = ar_xsdskd.xsddjh AND oe_fp.xh = ar_xsdskd.xsdxh AND ar_skd.djh = ar_xsdskd.skddjh AND oe_fp.bdelete = 0" & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " AND oe_fp.khdm = ?", " AND rc_khxx.zydm = ?") & " AND ar_skd.skrq >= ? and ar_skd.skrq <= ?) akhyszkhxmx LEFT JOIN rc_cpxx ON  akhyszkhxmx.cpdm = rc_cpxx.cpdm ORDER BY akhyszkhxmx.khdm,akhyszkhxmx.fprq"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), Me.TxtKhdm.Text, Me.TxtZydm.Text)
            'rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = rqBegin
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = rqEnd
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("khyszkhxmx") IsNot Nothing Then
                rcDataset.Tables("khyszkhxmx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "khyszkhxmx")
        Catch ex As Exception
            MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("khyszkhxmx").Rows.Count <= 0 Then
            MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        '调用表单
        Dim rcFrm As New FrmKhYszkHxMxz
        With rcFrm
            .ParaDataSet = rcDataset
            .paraDataView = New DataView(rcDataset.Tables("khyszkhxmx"), "TRUE", "fprq,xsddjh", DataViewRowState.CurrentRows)
            '.paraDataTable = rcDataset.Tables("khyszkhxmx")
            .Label2.Text = NudYear.Value & "年" & NudMonthBegin.Value & "月至" & NudMonthEnd.Value & "月"
            '.Label3.Text = "产品：" & Trim(TxtCpdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class