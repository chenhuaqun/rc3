Imports System.Data.OleDb

Public Class FrmCpPcb
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable
    ReadOnly dtCpsfcHz As New DataTable("cpsfchz")

    Private Sub FrmCpPcb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        DtpPcrq.Value = Now()
        '创建datatable
        dtCpsfcHz.Columns.Add("cpdm", Type.GetType("System.String"))
        dtCpsfcHz.Columns.Add("cpmc", Type.GetType("System.String"))
        dtCpsfcHz.Columns.Add("dw", Type.GetType("System.String"))
        dtCpsfcHz.Columns.Add("ckdm", Type.GetType("System.String"))
        dtCpsfcHz.Columns.Add("ckmc", Type.GetType("System.String"))
        dtCpsfcHz.Columns.Add("zdcb", Type.GetType("System.Double"))
        dtCpsfcHz.Columns.Add("zgcb", Type.GetType("System.Double"))
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
            .Columns("ckdm").DefaultValue = ""
            .Columns("zdcb").DefaultValue = 0.0
            .Columns("zgcb").DefaultValue = 0.0
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
    End Sub

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpPcrq.KeyPress, TxtLbdm.KeyPress, TxtCkdm.KeyPress, TxtCpdm.KeyPress, TxtCpmc.KeyPress
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
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_cplb"
                    .paraField1 = "lbdm"
                    .paraField2 = "lbmc"
                    .paraField3 = "lbsm"
                    .paraTitle = "物料类别"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtLbdm.Text = Trim(.paraField1)
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

#Region "仓库编码的事件"

    Private Sub TxtCkdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCkdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_ckxx"
                    .paraField1 = "ckdm"
                    .paraField2 = "ckmc"
                    .paraField3 = "cksm"
                    .paraTitle = "仓库"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtCkdm.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtCkdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCkdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtCkdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_ckxx WHERE (ckdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(TxtCkdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_ckxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_ckxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_ckxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_ckxx").Rows.Count > 0 Then
                Me.TxtCkdm.Text = Trim(rcDataset.Tables("rc_ckxx").Rows(0).Item("ckdm"))
                'Me.LblCkmc.Text = Trim(rcDataSet.Tables("rc_ckxx").Rows(0).Item("ckmc"))
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
        Dim dInvBegin1 As Date = getInvBegin(Mid(strKjqj, 1, 4), 1)
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
            If Me.ChbXsdj.Checked Then
                '重算销售单价
                rcOleDbCommand.CommandText = "UPDATE rc_cpxx SET xsdj = (SELECT CASE WHEN SUM(oe_xsd.sl) <> 0 THEN SUM(oe_xsd.je)/ SUM(oe_xsd.sl) ELSE 0 END FROM oe_xsd WHERE oe_xsd.sl <> 0 AND oe_xsd.je <> 0 AND TRUNC(oe_xsd.xsrq,'dd') <= ? AND TRUNC(oe_xsd.xsrq,'dd') >= ? AND oe_xsd.cpdm = rc_cpxx.cpdm) WHERE EXISTS (SELECT 1 FROM oe_xsd WHERE oe_xsd.sl <> 0 AND oe_xsd.je <> 0 AND TRUNC(oe_xsd.xsrq,'dd') <= ? AND TRUNC(oe_xsd.xsrq,'dd') >= ? AND oe_xsd.cpdm = rc_cpxx.cpdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@pcrq", OleDbType.Date, 8).Value = Me.DtpPcrq.Value.Date
                rcOleDbCommand.Parameters.Add("@pcrq", OleDbType.Date, 8).Value = Me.DtpPcrq.Value.Date.AddDays(0 - Me.NumericUpDown2.Value)
                rcOleDbCommand.Parameters.Add("@pcrq", OleDbType.Date, 8).Value = Me.DtpPcrq.Value.Date
                rcOleDbCommand.Parameters.Add("@pcrq", OleDbType.Date, 8).Value = Me.DtpPcrq.Value.Date.AddDays(0 - Me.NumericUpDown2.Value)
                rcOleDbCommand.ExecuteNonQuery()
            End If
            '销售单价成本加成

            rcOleDbCommand.CommandText = "SELECT bsfchz.cpdm,bsfchz.cpmc,bsfchz.dw,bsfchz.ckdm,bsfchz.ckmc,bsfchz.kuwei,bsfchz.zdcb,bsfchz.zgcb,bsfchz.cgdj,COALESCE(bsfchz.qcsl,0.0)+COALESCE(bsfchz.qcscrksl,0.0)+COALESCE(bsfchz.qcschzrksl,0.0)+COALESCE(bsfchz.qccgrksl,0.0)+COALESCE(bsfchz.qccghzrksl,0.0)+COALESCE(bsfchz.qcdbrksl,0.0)+COALESCE(bsfchz.qcdbhzrksl,0.0)-COALESCE(bsfchz.qcxscksl,0.0)-COALESCE(bsfchz.qcckcksl,0.0)-COALESCE(bsfchz.qcdbcksl,0.0) AS jcsl,COALESCE(bsfchz.qcfzsl,0.0)+COALESCE(bsfchz.qcscrkfzsl,0.0)+COALESCE(bsfchz.qcschzrkfzsl,0.0)+COALESCE(bsfchz.qccgrkfzsl,0.0)+COALESCE(bsfchz.qccghzrkfzsl,0.0)+COALESCE(bsfchz.qcdbrkfzsl,0.0)+COALESCE(bsfchz.qcdbhzrkfzsl,0.0)-COALESCE(bsfchz.qcxsckfzsl,0.0)-COALESCE(bsfchz.qcckckfzsl,0.0)-COALESCE(bsfchz.qcdbckfzsl,0.0) AS jcfzsl,COALESCE(bsfchz.qcje,0.0)+COALESCE(bsfchz.qcscrkje,0.0)+COALESCE(bsfchz.qcschzrkje,0.0)+COALESCE(bsfchz.qccgrkje,0.0)+COALESCE(bsfchz.qccghzrkje,0.0)+COALESCE(bsfchz.qcdbrkje,0.0)+COALESCE(bsfchz.qcdbhzrkje,0.0)-COALESCE(bsfchz.qcxsckje,0.0)-COALESCE(bsfchz.qcckckje,0.0)-COALESCE(bsfchz.qcdbckje,0.0) AS jcje,bsfchz.xsdj,(COALESCE(bsfchz.qcsl,0.0)+COALESCE(bsfchz.qcscrksl,0.0)+COALESCE(bsfchz.qccgrksl,0.0)+COALESCE(bsfchz.qcdbrksl,0.0)-COALESCE(bsfchz.qcxscksl,0.0)-COALESCE(bsfchz.qcckcksl,0.0)-COALESCE(bsfchz.qcdbcksl,0.0)) * bsfchz.xsdj AS xsje FROM" & _
                " (SELECT asfchz.*,rc_cpxx.cpmc,rc_cpxx.dw,rc_cpxx.lbdm,rc_ckxx.ckmc,rc_cpxx.kuwei,rc_cpxx.zdcb,rc_cpxx.zgcb,rc_cpxx.cgdj,rc_cpxx.xsdj FROM" & _
                " (SELECT cpnc.cpdm,cpnc.ckdm,cpnc.qcsl,cpnc.qcfzsl,cpnc.qcje,qcscrk.qcscrksl,qcscrk.qcscrkfzsl,qcscrk.qcscrkje,qcschzrk.qcschzrksl,qcschzrk.qcschzrkfzsl,qcschzrk.qcschzrkje,qccgrk.qccgrksl,qccgrk.qccgrkfzsl,qccgrk.qccgrkje,qccghzrk.qccghzrksl,qccghzrk.qccghzrkfzsl,qccghzrk.qccghzrkje,qcdbrk.qcdbrksl,qcdbrk.qcdbrkfzsl,qcdbrk.qcdbrkje,qcdbhzrk.qcdbhzrksl,qcdbhzrk.qcdbhzrkfzsl,qcdbhzrk.qcdbhzrkje,qcxsck.qcxscksl,qcxsck.qcxsckfzsl,qcxsck.qcxsckje,qcckck.qcckcksl,qcckck.qcckckfzsl,qcckck.qcckckje,qcdbck.qcdbcksl,qcdbck.qcdbckfzsl,qcdbck.qcdbckje FROM" & _
                " (SELECT inv_cpyeb.cpdm,inv_cpyeb.ckdm,sum(qcsl) as qcsl,sum(qcfzsl) as qcfzsl,sum(qcje) as qcje FROM inv_cpyeb WHERE kjnd = ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_cpyeb.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_cpyeb.cpdm,inv_cpyeb.ckdm) cpnc" & _
                " Left join (SELECT inv_rkd.cpdm,inv_rkd.ckdm,sum(inv_rkd.sl) as qcscrksl,sum(inv_rkd.fzsl) as qcscrkfzsl,sum(inv_rkd.je) as qcscrkje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND inv_rkd.rkrq >= ? and inv_rkd.rkrq >= ? and inv_rkd.rkrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_rkd.cpdm,inv_rkd.ckdm) qcscrk ON cpnc.cpdm = qcscrk.cpdm AND cpnc.ckdm = qcscrk.ckdm" & _
                " Left join (SELECT inv_rkd.cpdm,inv_rkd.ckdm,sum(inv_rkd.sl) as qcschzrksl,sum(inv_rkd.fzsl) as qcschzrkfzsl,sum(inv_rkd.je) as qcschzrkje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND inv_rkd.sl < 0 AND inv_rkd.rkrq >= ? AND inv_rkd.rkrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_rkd.cpdm,inv_rkd.ckdm) qcschzrk ON cpnc.cpdm = qcschzrk.cpdm AND cpnc.ckdm = qcschzrk.ckdm" & _
                " Left join (SELECT po_rkd.cpdm,po_rkd.ckdm,sum(po_rkd.sl) as qccgrksl,sum(po_rkd.fzsl) as qccgrkfzsl,sum(po_rkd.je) as qccgrkje FROM po_rkd WHERE po_rkd.bdelete = 0 AND po_rkd.rkrq >= ? and po_rkd.rkrq >= ? and po_rkd.rkrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND po_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY po_rkd.cpdm,po_rkd.ckdm) qccgrk ON cpnc.cpdm = qccgrk.cpdm AND cpnc.ckdm = qccgrk.ckdm" & _
                " Left join (SELECT po_rkd.cpdm,po_rkd.ckdm,sum(po_rkd.sl) as qccghzrksl,sum(po_rkd.fzsl) as qccghzrkfzsl,sum(po_rkd.je) as qccghzrkje FROM po_rkd WHERE po_rkd.bdelete = 0 AND po_rkd.sl < 0 AND po_rkd.rkrq >= ? and po_rkd.rkrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND po_rkd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY po_rkd.cpdm,po_rkd.ckdm) qccghzrk ON cpnc.cpdm = qccghzrk.cpdm AND cpnc.ckdm = qccghzrk.ckdm" & _
                " Left join (SELECT inv_dbd.cpdm,inv_dbd.rckdm AS ckdm,sum(inv_dbd.sl) as qcdbrksl,sum(inv_dbd.fzsl) as qcdbrkfzsl,sum(inv_dbd.je) as qcdbrkje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.rckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_dbd.cpdm,inv_dbd.rckdm) qcdbrk ON cpnc.cpdm = qcdbrk.cpdm AND cpnc.ckdm = qcdbrk.ckdm" & _
                " Left join (SELECT inv_dbd.cpdm,inv_dbd.rckdm AS ckdm,sum(inv_dbd.sl) as qcdbhzrksl,sum(inv_dbd.fzsl) as qcdbhzrkfzsl,sum(inv_dbd.je) as qcdbhzrkje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND inv_dbd.sl < 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.rckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_dbd.cpdm,inv_dbd.rckdm) qcdbhzrk ON cpnc.cpdm = qcdbhzrk.cpdm AND cpnc.ckdm = qcdbhzrk.ckdm" & _
                " Left join (SELECT oe_xsd.cpdm,oe_xsd.ckdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.fzsl) as qcxsckfzsl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND oe_xsd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY oe_xsd.cpdm,oe_xsd.ckdm) qcxsck ON cpnc.cpdm = qcxsck.cpdm AND cpnc.ckdm = qcxsck.ckdm" & _
                " Left join (SELECT inv_ckd.cpdm,inv_ckd.ckdm,sum(inv_ckd.sl) as qcckcksl,sum(inv_ckd.fzsl) as qcckckfzsl,sum(inv_ckd.je) as qcckckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND inv_ckd.ckrq >= ? and inv_ckd.ckrq >= ? and inv_ckd.ckrq < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_ckd.ckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_ckd.cpdm,inv_ckd.ckdm) qcckck ON cpnc.cpdm = qcckck.cpdm AND cpnc.ckdm = qcckck.ckdm" & _
                " Left join (SELECT inv_dbd.cpdm,inv_dbd.cckdm AS ckdm,sum(inv_dbd.sl) as qcdbcksl,sum(inv_dbd.fzsl) as qcdbckfzsl,sum(inv_dbd.je) as qcdbckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ?" & IIf(Not String.IsNullOrEmpty(Me.TxtCkdm.Text), " AND inv_dbd.cckdm ='" & Me.TxtCkdm.Text & "'", "") & " GROUP BY inv_dbd.cpdm,inv_dbd.cckdm) qcdbck ON cpnc.cpdm = qcdbck.cpdm AND cpnc.ckdm = qcdbck.ckdm) asfchz LEFT JOIN rc_cpxx ON asfchz.cpdm = rc_cpxx.cpdm LEFT JOIN rc_ckxx ON asfchz.ckdm = rc_ckxx.ckdm) bsfchz WHERE (0=0)" & IIf(Not String.IsNullOrEmpty(Me.TxtLbdm.Text), " AND lbdm LIKE '" & Me.TxtLbdm.Text & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpdm.Text), " and cpdm LIKE '" & Trim(TxtCpdm.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpmc.Text), " AND cpmc LIKE '%" & TxtCpmc.Text & "%'", "")
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(strKjqj, 1, 4)
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dInvBegin1.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = IIf(Me.ChbCq.Checked, Me.DtpPcrq.Value.AddDays(0 - Me.NumericUpDown1.Value), Me.DtpPcrq.Value)
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = IIf(Me.ChbCq.Checked, Me.DtpPcrq.Value.AddDays(0 - Me.NumericUpDown1.Value), Me.DtpPcrq.Value)
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = Me.DtpPcrq.Value
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dInvBegin1.Date
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = IIf(Me.ChbCq.Checked, Me.DtpPcrq.Value.AddDays(0 - Me.NumericUpDown1.Value), Me.DtpPcrq.Value)
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = IIf(Me.ChbCq.Checked, Me.DtpPcrq.Value.AddDays(0 - Me.NumericUpDown1.Value), Me.DtpPcrq.Value)
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = Me.DtpPcrq.Value
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dInvBegin1.Date
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = IIf(Me.ChbCq.Checked, Me.DtpPcrq.Value.AddDays(0 - Me.NumericUpDown1.Value), Me.DtpPcrq.Value)
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = IIf(Me.ChbCq.Checked, Me.DtpPcrq.Value.AddDays(0 - Me.NumericUpDown1.Value), Me.DtpPcrq.Value)
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = Me.DtpPcrq.Value
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dInvBegin1.Date
            rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = DtpPcrq.Value
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dInvBegin1.Date
            rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = DtpPcrq.Value
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dInvBegin1.Date
            rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = DtpPcrq.Value
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
        If Me.ChbZdcb.Checked Then
            For i = 0 To rcDataset.Tables("cpsfchz").Rows.Count - 1
                Me.ProgressBar1.Value = i
                If rcDataset.Tables("cpsfchz").Rows(i).RowState <> DataRowState.Deleted Then
                    If rcDataset.Tables("cpsfchz").Rows(i).Item("zdcb").GetType.ToString <> "System.DBNull" Then
                        If rcDataset.Tables("cpsfchz").Rows(i).Item("jcsl") >= rcDataset.Tables("cpsfchz").Rows(i).Item("zdcb") Then
                            rcDataset.Tables("cpsfchz").Rows(i).Delete()
                        End If
                    End If
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
        Dim rcFrm As New FrmCpPcbz
        With rcFrm
            .ParaDataSet = rcDataset
            .ParaDataView = New DataView(rcDataset.Tables("cpsfchz"), "TRUE", "cpdm,ckdm", DataViewRowState.CurrentRows)
            .Label2.Text = "盘点日期：" & Me.DtpPcrq.Value
            .Label3.Text = "仓库：" & Trim(Me.TxtCkdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

    Private Sub ChbXsdj_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbXsdj.CheckedChanged
        If Me.ChbXsdj.Checked Then
            Me.NumericUpDown2.Visible = True
            Me.Label2.Visible = True
        Else
            Me.NumericUpDown2.Visible = False
            Me.Label2.Visible = False
        End If
    End Sub
End Class