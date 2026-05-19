Imports System.Data.OleDb

Public Class FrmFcspPcb
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable
    ReadOnly dtCpsfcHz As New DataTable("cpsfchz")
    '发出商品启用会计期间
    Dim dateFcspBegin As Date
    Private Sub FrmFcspPcb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        DtpPcrq.Value = Now()
        '创建datatable
        dtCpsfcHz.Columns.Add("cpdm", Type.GetType("System.String"))
        dtCpsfcHz.Columns.Add("cpmc", Type.GetType("System.String"))
        dtCpsfcHz.Columns.Add("dw", Type.GetType("System.String"))
        dtCpsfcHz.Columns.Add("bmdm", Type.GetType("System.String"))
        dtCpsfcHz.Columns.Add("bmmc", Type.GetType("System.String"))
        dtCpsfcHz.Columns.Add("khdm", Type.GetType("System.String"))
        dtCpsfcHz.Columns.Add("khmc", Type.GetType("System.String"))
        dtCpsfcHz.Columns.Add("cgdj", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("jcsl", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("jcfzsl", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("jcje", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("xsdj", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("xsje", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("mll", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtCpsfcHz)
        With dtCpsfcHz
            .Columns("cpdm").DefaultValue = ""
            .Columns("bmdm").DefaultValue = ""
            .Columns("khdm").DefaultValue = ""
            .Columns("cgdj").DefaultValue = 0.0
            .Columns("jcsl").DefaultValue = 0.0
            .Columns("jcfzsl").DefaultValue = 0.0
            .Columns("jcje").DefaultValue = 0.0
            .Columns("xsdj").DefaultValue = 0.0
            .Columns("xsje").DefaultValue = 0.0
            .Columns("mll").DefaultValue = 0.0
            '.Columns("xsje").Expression = "jcsl * xsdj"
            .Columns("mll").Expression = "(xsje-jcje) /jcje"
        End With
        Dim strFcspKjqj As String = GetParaValue("发出商品启用会计期间", True)
        If Not String.IsNullOrEmpty(strFcspKjqj) Then
            dateFcspBegin = GetInvBegin(Mid(strFcspKjqj, 1, 4), Mid(strFcspKjqj, 5, 2))
        Else
            dateFcspBegin = g_Dwrq
        End If
    End Sub

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpPcrq.KeyPress, TxtBmdm.KeyPress, TxtKhdm.KeyPress, TxtLbdm.KeyPress, TxtCpdm.KeyPress, TxtCpmc.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "物料类别编码的事件"

    Private Sub Txtlbdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLbdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .ParaOleDbConn = rcOleDbConn
                    .ParaTableName = "rc_cplb"
                    .ParaField1 = "lbdm"
                    .ParaField2 = "lbmc"
                    .ParaField3 = "lbsm"
                    .ParaTitle = "物料类别"
                    .ParaOldValue = ""
                    .ParaAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtLbdm.Text = Trim(.ParaField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub Txtlbdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtLbdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtLbdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_cplb WHERE (lbdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = Trim(TxtLbdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_cplb") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_cplb").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_cplb")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_cplb").Rows.Count > 0 Then
                Me.TxtLbdm.Text = Trim(rcDataset.Tables("rc_cplb").Rows(0).Item("lbdm"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "部门编码的事件"

    Private Sub TxtBmdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBmdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .ParaOleDbConn = rcOleDbConn
                    .ParaTableName = "rc_bmxx"
                    .ParaField1 = "bmdm"
                    .ParaField2 = "bmmc"
                    .ParaField3 = "bmsm"
                    .ParaTitle = "部门"
                    .ParaOldValue = ""
                    .ParaAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtBmdm.Text = Trim(.ParaField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtBmdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtBmdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtBmdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_bmxx WHERE (bmdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(TxtBmdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_bmxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_bmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_bmxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_bmxx").Rows.Count > 0 Then
                Me.TxtBmdm.Text = Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmdm"))
                'Me.Lblbmmc.Text = Trim(rcDataSet.Tables("rc_bmxx").Rows(0).Item("bmmc"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "客户编码的事件"

    Private Sub TxtKhdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtKhdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .ParaOleDbConn = rcOleDbConn
                    .ParaTableName = "rc_khxx"
                    .ParaField1 = "khdm"
                    .ParaField2 = "khmc"
                    .ParaField3 = "khsm"
                    .ParaTitle = "客户"
                    .ParaOldValue = ""
                    .ParaAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtKhdm.Text = Trim(.ParaField1)
                    End If
                End With
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
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 12).Value = Trim(TxtKhdm.Text)
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
                'Me.Lblkhmc.Text = Trim(rcDataSet.Tables("rc_khxx").Rows(0).Item("khmc"))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "物料编码事件"

    Private Sub TxtCpdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCpdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF34
                With rcFrm
                    .ParaOleDbConn = rcOleDbConn
                    .ParaTableName = "rc_cpxx"
                    .ParaField1 = "cpdm"
                    .ParaField2 = "cpmc"
                    .ParaField3 = "dw"
                    .ParaField4 = "cpsm"
                    .ParaOrderField = "cpmc"
                    .ParaTitle = "物料"
                    .ParaOldValue = ""
                    .ParaAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtCpdm.Text = Trim(.ParaField1)
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

    Private Sub ChbCq_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbCq.CheckedChanged
        If Me.ChbCq.Checked Then
            Me.NumericUpDown1.Visible = True
            Me.Label1.Visible = True
        Else
            Me.NumericUpDown1.Visible = False
            Me.Label1.Visible = False
        End If
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim strKjqj As String = IIf(Me.ChbCq.Checked, Me.DtpPcrq.Value.AddDays(0 - Me.NumericUpDown1.Value), Me.DtpPcrq.Value)
        Dim dInvBegin1 As Date = GetInvBegin(Mid(strKjqj, 1, 4), 1)
        Dim i As Integer = 1
        If dtCpsfcHz IsNot Nothing Then
            dtCpsfcHz.Clear()
        End If
        '取数据
        '取期初库存、期初入库、期初出库、本期入库、本期出库
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '销售单价成本加成
            rcOleDbCommand.CommandText = "SELECT bsfchz.cpdm,bsfchz.cpmc,bsfchz.dw,bsfchz.bmdm,bsfchz.bmmc,bsfchz.khdm,bsfchz.khmc,bsfchz.cgdj,COALESCE(bsfchz.qcsl,0.0)+COALESCE(bsfchz.qcxscksl,0.0)-COALESCE(bsfchz.qcfpcksl,0.0) AS jcsl,COALESCE(bsfchz.qcfzsl,0.0)+COALESCE(bsfchz.qcxsckfzsl,0.0)-COALESCE(bsfchz.qcfpckfzsl,0.0) AS jcfzsl,COALESCE(bsfchz.qcje,0.0)+COALESCE(bsfchz.qcxsckje,0.0)+COALESCE(bsfchz.qcfpckje,0.0) AS jcje,bsfchz.xsdj,(COALESCE(bsfchz.qcsl,0.0)+COALESCE(bsfchz.qcxscksl,0.0)-COALESCE(bsfchz.qcfpcksl,0.0)) * bsfchz.xsdj AS xsje FROM" &
                " (SELECT asfchz.*,rc_cpxx.cpmc,rc_cpxx.dw,rc_cpxx.lbdm,rc_bmxx.bmmc,rc_khxx.khmc,rc_cpxx.cgdj,rc_cpxx.xsdj FROM" &
                " (SELECT cpnc.cpdm,cpnc.bmdm,cpnc.khdm,cpnc.qcsl,cpnc.qcfzsl,cpnc.qcje,qcxsck.qcxscksl,qcxsck.qcxsckfzsl,qcxsck.qcxsckje,qcfpck.qcfpcksl,qcfpck.qcfpckfzsl,qcfpck.qcfpckje FROM" &
                " (SELECT inv_fcspyeb.cpdm,inv_fcspyeb.bmdm,inv_fcspyeb.khdm,sum(qcsl) as qcsl,sum(qcfzsl) as qcfzsl,sum(qcje) as qcje FROM inv_fcspyeb WHERE kjnd = ?" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND inv_fcspyeb.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " GROUP BY inv_fcspyeb.cpdm,inv_fcspyeb.bmdm,inv_fcspyeb.khdm) cpnc" &
                " Left join (SELECT oe_xsd.cpdm,oe_xsd.bmdm,oe_xsd.khdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.fzsl) as qcxsckfzsl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND oe_xsd.je <> 0 AND oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_xsd.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " GROUP BY oe_xsd.cpdm,oe_xsd.bmdm,oe_xsd.khdm) qcxsck ON cpnc.cpdm = qcxsck.cpdm AND cpnc.bmdm = qcxsck.bmdm AND cpnc.khdm = qcxsck.khdm" &
                " Left join (SELECT oe_fp.cpdm,oe_fp.bmdm,oe_fp.khdm,sum(oe_fp.sl) as qcfpcksl,sum(oe_fp.fzsl) as qcfpckfzsl,sum(oe_fp.je) as qcfpckje FROM oe_fp WHERE oe_fp.bdelete = 0 AND oe_fp.fprq >= ? and oe_fp.fprq >= ? and oe_fp.fprq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " AND oe_fp.bmdm ='" & Me.TxtBmdm.Text & "'", "") & " GROUP BY oe_fp.cpdm,oe_fp.bmdm,oe_fp.khdm) qcfpck ON cpnc.cpdm = qcfpck.cpdm AND cpnc.bmdm = qcfpck.bmdm AND cpnc.khdm = qcfpck.khdm" &
                ") asfchz LEFT JOIN rc_cpxx ON asfchz.cpdm = rc_cpxx.cpdm LEFT JOIN rc_bmxx ON asfchz.bmdm = rc_bmxx.bmdm LEFT JOIN rc_khxx ON asfchz.khdm = rc_khxx.khdm) bsfchz WHERE (0=0)" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " and cpdm LIKE '" & Trim(TxtCpdm.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpmc.Text), " AND cpmc LIKE '%" & TxtCpmc.Text & "%'", "")
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(strKjqj, 1, 4)
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateFcspBegin.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dInvBegin1.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = DtpPcrq.Value
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dateFcspBegin.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = dInvBegin1.Date
            rcOleDbCommand.Parameters.Add("@fprq", OleDbType.Date, 8).Value = DtpPcrq.Value
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("cpsfchz") IsNot Nothing Then
                rcDataset.Tables("cpsfchz").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "cpsfchz")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("cpsfchz").Rows.Count > 0 Then
            Me.ProgressBar1.Maximum = rcDataset.Tables("cpsfchz").Rows.Count - 1
        End If
        If Me.ChbYe.Checked Then
            For i = 0 To rcDataset.Tables("cpsfchz").Rows.Count - 1
                Me.ProgressBar1.Value = i
                If rcDataset.Tables("cpsfchz").Rows(i).Item("jcsl") = 0 And rcDataset.Tables("cpsfchz").Rows(i).Item("jcfzsl") = 0 And rcDataset.Tables("cpsfchz").Rows(i).Item("jcje") = 0 Then
                    rcDataset.Tables("cpsfchz").Rows(i).Delete()
                End If
            Next
        End If
        If Me.ChbCq.Checked Then
            For i = 0 To rcDataset.Tables("cpsfchz").Rows.Count - 1
                Me.ProgressBar1.Value = i
                If rcDataset.Tables("cpsfchz").Rows(i).RowState <> DataRowState.Deleted Then
                    If rcDataset.Tables("cpsfchz").Rows(i).Item("jcsl").GetType.ToString <> "System.DBNull" Then
                        If rcDataset.Tables("cpsfchz").Rows(i).Item("jcsl") <= 0 Then
                            rcDataset.Tables("cpsfchz").Rows(i).Delete()
                        End If
                    End If
                End If
            Next
        End If
        Dim rcDataRow As DataRow
        rcDataRow = rcDataset.Tables("cpsfchz").NewRow
        rcDataRow.Item("cpdm") = "合计"
        rcDataRow.Item("jcsl") = dtCpsfcHz.Compute("Sum(jcsl)", "")
        rcDataRow.Item("jcfzsl") = dtCpsfcHz.Compute("Sum(jcfzsl)", "")
        rcDataRow.Item("jcje") = dtCpsfcHz.Compute("Sum(jcje)", "")
        rcDataset.Tables("cpsfchz").Rows.Add(rcDataRow)

        '调用表单
        Dim rcFrm As New FrmFcspPcbz
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("cpsfchz"), "TRUE", "cpdm,bmdm,khdm", DataViewRowState.CurrentRows)
            .Label2.Text = "盘点日期：" & Me.DtpPcrq.Value
            .Label3.Text = "部门：" & Trim(Me.TxtBmdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class