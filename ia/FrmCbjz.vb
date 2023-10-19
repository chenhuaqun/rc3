Imports System.Data.OleDb

Public Class FrmCbjz
    '��������������
    Dim rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    Dim rcDataSet As New DataSet
    '��ʾҪ������Դִ�е� SQL ����
    Dim rcOleDbTrans As OleDbTransaction
    '����OleDbCommand����
    Dim rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '����Datatable '����Ҫ���ø�datatable���н�����
    Dim dtBom As New DataTable("rc_cbjz")

#Region "��ʼ��"

    Private Sub FrmCbjz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Ĭ��ֵ
        Me.NudYear.Value = Mid(g_Kjqj, 1, 4)
        Me.NudMonthBegin.Value = Mid(g_Kjqj, 5, 2)
        Me.NudMonthEnd.Value = Mid(g_Kjqj, 5, 2)
        Me.TxtZclcb.Text = 0.0
        Me.TxtZrgcb.Text = 0.0
        Me.TxtZglcb.Text = 0.0
        Me.TxtZcb.Text = 0.0
        '����DataGridView
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.DataGridView1.Columns("ColClcb").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridView1.Columns("ColClcb").DefaultCellStyle.Format = g_FormatJe
        Me.DataGridView1.Columns("ColRgcb").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridView1.Columns("ColRgcb").DefaultCellStyle.Format = g_FormatJe
        Me.DataGridView1.Columns("ColGlcb").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridView1.Columns("ColGlcb").DefaultCellStyle.Format = g_FormatJe
        Me.DataGridView1.Columns("ColZcb").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridView1.Columns("ColZcb").DefaultCellStyle.Format = g_FormatJe
        '���ݰ�
        dtBom.Columns.Add("bmdm", Type.GetType("System.String"))
        dtBom.Columns.Add("bmmc", Type.GetType("System.String"))
        dtBom.Columns.Add("clcb", Type.GetType("System.Double"))
        dtBom.Columns.Add("rgcb", Type.GetType("System.Double"))
        dtBom.Columns.Add("glcb", Type.GetType("System.Double"))
        dtBom.Columns.Add("zcb", Type.GetType("System.Double"))
        rcDataSet.Tables.Add(dtBom)
        With dtBom
            .Columns("bmdm").DefaultValue = ""
            .Columns("bmmc").DefaultValue = ""
            .Columns("clcb").DefaultValue = 0.0
            .Columns("rgcb").DefaultValue = 0.0
            .Columns("glcb").DefaultValue = 0.0
            .Columns("zcb").DefaultValue = 0.0
            .Columns("zcb").Expression = "clcb + rgcb + glcb"
        End With
        Me.rcBindingSource.DataSource = dtBom
        Me.DataGridView1.DataSource = Me.rcBindingSource
    End Sub

#End Region

#Region "�ؼ��س����Ĵ���"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NudYear.KeyPress, NudMonthBegin.KeyPress, NudMonthEnd.KeyPress, TxtZcb.KeyPress, TxtZclcb.KeyPress, TxtZrgcb.KeyPress, TxtZglcb.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "��������"

    Private Sub BtnImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImp.Click
        Dim dateKsrq As Date = getInvBegin(Me.NudYear.Value, Me.NudMonthBegin.Value)
        Dim dateJsrq As Date = getInvEnd(Me.NudYear.Value, Me.NudMonthEnd.Value)
        'ȡ��Ʒ��ⵥ
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT rc_bmxx.bmdm,rc_bmxx.bmmc,COALESCE(acbjz.clcb,0.0) AS clcb,COALESCE(acbjz.rgcb,0.0) AS rgcb,COALESCE(acbjz.glcb,0.0) AS glcb FROM rc_bmxx LEFT JOIN (SELECT inv_rkd.bmdm,SUM(inv_rkd.clcb) AS clcb,SUM(inv_rkd.rgcb) AS rgcb,SUM(inv_rkd.glcb) AS glcb FROM inv_rkd WHERE inv_rkd.bdelete <> 1 AND inv_rkd.rkrq >= ? AND inv_rkd.rkrq <= ? GROUP BY inv_rkd.bmdm) acbjz ON acbjz.bmdm = rc_bmxx.bmdm ORDER BY rc_bmxx.bmdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
            rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If Not rcDataSet.Tables("rc_cbjz") Is Nothing Then
                rcDataSet.Tables("rc_cbjz").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_cbjz")
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
        Finally
            rcOleDbConn.Close()
        End Try
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        '��ת�ɱ�
        '��ת�˻����ĳɱ�
        '��ת���ⵥ�ĳɱ�
        Dim datePoBegin1 As Date = Now.Date
        Dim dateKsrq As Date '�ɱ���ת��ʼ����
        Dim dateJsrq As Date '�ɱ���ת��������
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim k As Integer = 0
        Dim dblQcsl As Double = 0.0
        Dim dblQcje As Double = 0.0
        Dim dblQcdj As Double = 0.0
        Dim dblBmzje As Double = 0.0
        Dim dblZydsl As Double = 0.0
        datePoBegin1 = getInvBegin(Me.NudYear.Value, 1)
        dateKsrq = getInvBegin(Me.NudYear.Value, Me.NudMonthBegin.Value)
        dateJsrq = getInvEnd(Me.NudYear.Value, Me.NudMonthEnd.Value)
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            'ȡ������Ϣ
            rcOleDbCommand.CommandText = "SELECT rc_cpxx.cpdm FROM rc_cpxx ORDER BY rc_cpxx.cpdm" ',rc_cpxx.jjfs
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If Not rcDataSet.Tables("cpxx") Is Nothing Then
                rcDataSet.Tables("cpxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "cpxx")
            For i = 0 To rcDataSet.Tables("cpxx").Rows.Count - 1
                Me.ProgressBar1.Value = 100 / rcDataSet.Tables("cpxx").Rows.Count * (i + 1)
                Dim strJjfs As String = "��Ȩƽ����" ' rcDataSet.Tables("cpxx").Rows(i).Item("jjfs")
                Select Case strJjfs
                    Case "��Ȩƽ����"
                        '''''''''''''''''''''''''''''''
                        ''''''''''��Ȩƽ����'''''''''''
                        '''''''''''''''''''''''''''''''
                        '����ò�Ʒ�òֿ��������������+����������������µ�������+���������
                        'For j = 0 To rcDataset.Tables("dbdnr").Rows.Count - 1
                        '�ֲֿ����,��������������������������������������ĳ���ɱ�
                        rcOleDbCommand.CommandText = "SELECT cpdm,ckdm,COALESCE(sum(qcsl),0.0) as qcsl,COALESCE(sum(qcje),0.0) as qcje,COALESCE(sum(qccgrksl),0.0) as qccgrksl,COALESCE(sum(qccgrkje),0.0) as qccgrkje,COALESCE(sum(qcscrksl),0.0) as qcscrksl,COALESCE(sum(qcscrkje),0.0) as qcscrkje,COALESCE(sum(qcdbrksl),0.0) as qcdbrksl,COALESCE(sum(qcdbrkje),0.0) as qcdbrkje,COALESCE(sum(qcxscksl),0.0) as qcxscksl,COALESCE(sum(qcxsckje),0.0) as qcxsckje,COALESCE(sum(qcckcksl),0.0) as qcckcksl,COALESCE(sum(qcckckje),0.0) as qcckckje,COALESCE(sum(qcdbcksl),0.0) as qcdbcksl,COALESCE(sum(qcdbckje),0.0) as qcdbckje FROM (SELECT clnc.cpdm,clnc.ckdm,clnc.qcsl,clnc.qcje,qccgrk.qccgrksl,qccgrk.qccgrkje,qcscrk.qcscrksl,qcscrk.qcscrkje,qcdbrk.qcdbrksl,qcdbrk.qcdbrkje,qcxsck.qcxscksl,qcxsck.qcxsckje,qcckck.qcckcksl,qcckck.qcckckje,qcdbck.qcdbcksl,qcdbck.qcdbckje FROM" & _
                            " (SELECT inv_cpyeb.cpdm,inv_cpyeb.ckdm,sum(qcsl) as qcsl,sum(qcje) as qcje FROM inv_cpyeb WHERE kjnd = ? AND cpdm = ? GROUP by inv_cpyeb.cpdm,inv_cpyeb.ckdm) clnc" & _
                            " Left join (SELECT po_rkd.cpdm,po_rkd.ckdm,sum(po_rkd.sl) as qccgrksl,sum(po_rkd.je) as qccgrkje FROM po_rkd WHERE po_rkd.bdelete = 0 AND po_rkd.rkrq >= ? AND po_rkd.rkrq >= ? AND po_rkd.rkrq <= ? AND cpdm = ? GROUP BY po_rkd.cpdm,po_rkd.ckdm) qccgrk ON clnc.cpdm = qccgrk.cpdm AND clnc.ckdm = qccgrk.ckdm" & _
                            " Left join (SELECT inv_rkd.cpdm,inv_rkd.ckdm,sum(inv_rkd.sl) as qcscrksl,sum(inv_rkd.je) as qcscrkje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND inv_rkd.rkrq >= ? and inv_rkd.rkrq >= ? and inv_rkd.rkrq < ? AND cpdm = ? GROUP BY inv_rkd.cpdm,inv_rkd.ckdm) qcscrk ON clnc.cpdm = qcscrk.cpdm AND clnc.ckdm = qcscrk.ckdm" & _
                            " Left join (SELECT inv_dbd.cpdm,inv_dbd.rckdm AS ckdm,sum(inv_dbd.sl) as qcdbrksl,sum(inv_dbd.je) as qcdbrkje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ? AND cpdm = ? GROUP BY inv_dbd.cpdm,inv_dbd.rckdm) qcdbrk ON clnc.cpdm = qcdbrk.cpdm AND clnc.ckdm = qcdbrk.ckdm" & _
                            " Left join (SELECT oe_xsd.cpdm,oe_xsd.ckdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq < ? AND cpdm = ? GROUP BY oe_xsd.cpdm,oe_xsd.ckdm) qcxsck ON clnc.cpdm = qcxsck.cpdm AND clnc.ckdm = qcxsck.ckdm" & _
                            " Left join (SELECT inv_ckd.cpdm,inv_ckd.ckdm,sum(inv_ckd.sl) as qcckcksl,sum(inv_ckd.je) as qcckckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND inv_ckd.ckrq >= ? and inv_ckd.ckrq >= ? and inv_ckd.ckrq < ? AND cpdm = ? GROUP BY inv_ckd.cpdm,inv_ckd.ckdm) qcckck ON clnc.cpdm = qcckck.cpdm AND clnc.ckdm = qcckck.ckdm" & _
                            " Left join (SELECT inv_dbd.cpdm,inv_dbd.cckdm AS ckdm,sum(inv_dbd.sl) as qcdbcksl,sum(inv_dbd.je) as qcdbckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ? AND cpdm = ? GROUP BY inv_dbd.cpdm,inv_dbd.cckdm) qcdbck ON clnc.cpdm = qcdbck.cpdm AND clnc.ckdm = qcdbck.ckdm) asfchz GROUP BY cpdm,ckdm"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePoBegin1
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePoBegin1
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePoBegin1
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateKsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = datePoBegin1
                        rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = datePoBegin1
                        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateKsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePoBegin1
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateKsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If Not rcDataSet.Tables("clqcye") Is Nothing Then
                            rcDataSet.Tables("clqcye").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataSet, "clqcye")
                        For j = 0 To rcDataSet.Tables("clqcye").Rows.Count - 1
                            'ȡƽ������
                            dblQcsl = rcDataSet.Tables("clqcye").Rows(j).Item("qcsl") + rcDataSet.Tables("clqcye").Rows(j).Item("qccgrksl") + rcDataSet.Tables("clqcye").Rows(j).Item("qcscrksl") + rcDataSet.Tables("clqcye").Rows(j).Item("qcdbrksl") - rcDataSet.Tables("clqcye").Rows(j).Item("qcxscksl") - rcDataSet.Tables("clqcye").Rows(j).Item("qcckcksl") - rcDataSet.Tables("clqcye").Rows(j).Item("qcdbcksl")
                            dblQcje = rcDataSet.Tables("clqcye").Rows(j).Item("qcje") + rcDataSet.Tables("clqcye").Rows(j).Item("qccgrkje") + rcDataSet.Tables("clqcye").Rows(j).Item("qcscrkje") + rcDataSet.Tables("clqcye").Rows(j).Item("qcdbrkje") - rcDataSet.Tables("clqcye").Rows(j).Item("qcxsckje") - rcDataSet.Tables("clqcye").Rows(j).Item("qcckckje") - rcDataSet.Tables("clqcye").Rows(j).Item("qcdbckje")
                            '�����Ʒ�����ɱ�����=���µ�������+���������/������������+�����������
                            If dblQcsl <> 0 Then
                                dblQcdj = dblQcje / dblQcsl
                            Else
                                dblQcdj = 0.0
                            End If
                            ''��ƽ�����۽��и��µ��²�Ʒ�������ĵ������=�ɱ�����*�˻�����
                            rcOleDbCommand.CommandText = "UPDATE inv_dbd SET inv_dbd.je = inv_dbd.sl * ?,inv_dbd.dj = ? WHERE inv_dbd.cpdm = ? AND cckdm = ? AND SUBSTR(inv_dbd.djh,5,6) >= ? AND SUBSTR(inv_dbd.djh,5,6) <= ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                            rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("cpxx").Rows(i).Item("cpdm")
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("clqcye").Rows(j).Item("ckdm")
                            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthBegin.Value.ToString.PadLeft(2, "0")
                            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthEnd.Value.ToString.PadLeft(2, "0")
                            rcOleDbCommand.ExecuteNonQuery()
                        Next
                        '�ֲֿ����,������������������������������ⵥ�ĳ���ɱ�
                        rcOleDbCommand.CommandText = "SELECT cpdm,ckdm,COALESCE(sum(qcsl),0.0) as qcsl,COALESCE(sum(qcje),0.0) as qcje,COALESCE(sum(qccgrksl),0.0) as qccgrksl,COALESCE(sum(qccgrkje),0.0) as qccgrkje,COALESCE(sum(qcscrksl),0.0) as qcscrksl,COALESCE(sum(qcscrkje),0.0) as qcscrkje,COALESCE(sum(qcdbrksl),0.0) as qcdbrksl,COALESCE(sum(qcdbrkje),0.0) as qcdbrkje,COALESCE(sum(qcxscksl),0.0) as qcxscksl,COALESCE(sum(qcxsckje),0.0) as qcxsckje,COALESCE(sum(qcckcksl),0.0) as qcckcksl,COALESCE(sum(qcckckje),0.0) as qcckckje,COALESCE(sum(qcdbcksl),0.0) as qcdbcksl,COALESCE(sum(qcdbckje),0.0) as qcdbckje FROM (SELECT clnc.cpdm,clnc.ckdm,clnc.qcsl,clnc.qcje,qccgrk.qccgrksl,qccgrk.qccgrkje,qcscrk.qcscrksl,qcscrk.qcscrkje,qcdbrk.qcdbrksl,qcdbrk.qcdbrkje,qcxsck.qcxscksl,qcxsck.qcxsckje,qcckck.qcckcksl,qcckck.qcckckje,qcdbck.qcdbcksl,qcdbck.qcdbckje FROM" & _
                            " (SELECT inv_cpyeb.cpdm,inv_cpyeb.ckdm,sum(qcsl) as qcsl,sum(qcje) as qcje FROM inv_cpyeb WHERE kjnd = ? AND cpdm = ? GROUP by inv_cpyeb.cpdm,inv_cpyeb.ckdm) clnc" & _
                            " Left join (SELECT po_rkd.cpdm,po_rkd.ckdm,sum(po_rkd.sl) as qccgrksl,sum(po_rkd.je) as qccgrkje FROM po_rkd WHERE po_rkd.bdelete = 0 AND po_rkd.rkrq >= ? and po_rkd.rkrq >= ? and po_rkd.rkrq <= ? AND cpdm = ? GROUP BY po_rkd.cpdm,po_rkd.ckdm) qccgrk ON clnc.cpdm = qccgrk.cpdm AND clnc.ckdm = qccgrk.ckdm" & _
                            " Left join (SELECT inv_rkd.cpdm,inv_rkd.ckdm,sum(inv_rkd.sl) as qcscrksl,sum(inv_rkd.je) as qcscrkje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND inv_rkd.rkrq >= ? and inv_rkd.rkrq >= ? and inv_rkd.rkrq < ? AND cpdm = ? GROUP BY inv_rkd.cpdm,inv_rkd.ckdm) qcscrk ON clnc.cpdm = qcscrk.cpdm AND clnc.ckdm = qcscrk.ckdm" & _
                            " Left join (SELECT inv_dbd.cpdm,inv_dbd.rckdm AS ckdm,sum(inv_dbd.sl) as qcdbrksl,sum(inv_dbd.je) as qcdbrkje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ? AND cpdm = ? GROUP BY inv_dbd.cpdm,inv_dbd.rckdm) qcdbrk ON clnc.cpdm = qcdbrk.cpdm AND clnc.ckdm = qcdbrk.ckdm" & _
                            " Left join (SELECT oe_xsd.cpdm,oe_xsd.ckdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq < ? AND cpdm = ? GROUP BY oe_xsd.cpdm,oe_xsd.ckdm) qcxsck ON clnc.cpdm = qcxsck.cpdm AND clnc.ckdm = qcxsck.ckdm" & _
                            " Left join (SELECT inv_ckd.cpdm,inv_ckd.ckdm,sum(inv_ckd.sl) as qcckcksl,sum(inv_ckd.je) as qcckckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND inv_ckd.ckrq >= ? and inv_ckd.ckrq >= ? and inv_ckd.ckrq < ? AND cpdm = ? GROUP BY inv_ckd.cpdm,inv_ckd.ckdm) qcckck ON clnc.cpdm = qcckck.cpdm AND clnc.ckdm = qcckck.ckdm" & _
                            " Left join (SELECT inv_dbd.cpdm,inv_dbd.cckdm AS ckdm,sum(inv_dbd.sl) as qcdbcksl,sum(inv_dbd.je) as qcdbckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ? AND cpdm = ? GROUP BY inv_dbd.cpdm,inv_dbd.cckdm) qcdbck ON clnc.cpdm = qcdbck.cpdm AND clnc.ckdm = qcdbck.ckdm) asfchz GROUP BY cpdm,ckdm"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePoBegin1
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePoBegin1
                        rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateKsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePoBegin1
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateJsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = datePoBegin1
                        rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = datePoBegin1
                        rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateKsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePoBegin1
                        rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateJsrq
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If Not rcDataSet.Tables("clqcye") Is Nothing Then
                            rcDataSet.Tables("clqcye").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataSet, "clqcye")
                        For j = 0 To rcDataSet.Tables("clqcye").Rows.Count - 1
                            'ȡƽ������
                            dblQcsl = rcDataSet.Tables("clqcye").Rows(j).Item("qcsl") + rcDataSet.Tables("clqcye").Rows(j).Item("qccgrksl") + rcDataSet.Tables("clqcye").Rows(j).Item("qcscrksl") + rcDataSet.Tables("clqcye").Rows(j).Item("qcdbrksl") - rcDataSet.Tables("clqcye").Rows(j).Item("qcxscksl") - rcDataSet.Tables("clqcye").Rows(j).Item("qcckcksl") - rcDataSet.Tables("clqcye").Rows(j).Item("qcdbcksl")
                            dblQcje = rcDataSet.Tables("clqcye").Rows(j).Item("qcje") + rcDataSet.Tables("clqcye").Rows(j).Item("qccgrkje") + rcDataSet.Tables("clqcye").Rows(j).Item("qcscrkje") + rcDataSet.Tables("clqcye").Rows(j).Item("qcdbrkje") - rcDataSet.Tables("clqcye").Rows(j).Item("qcxsckje") - rcDataSet.Tables("clqcye").Rows(j).Item("qcckckje") - rcDataSet.Tables("clqcye").Rows(j).Item("qcdbckje")
                            '�����Ʒ�����ɱ�����=���µ�������+���������/������������+�����������
                            If dblQcsl <> 0 Then
                                dblQcdj = dblQcje / dblQcsl
                            Else
                                dblQcdj = 0.0
                            End If
                            'MsgBox(Str(dblQcdj) + "/" + rcDataSet.Tables("cpxx").Rows(i).Item("cpdm") + "/" + rcDataSet.Tables("clqcye").Rows(j).Item("ckdm"))

                            ''��ƽ�����۽��и��µ��²�Ʒ���ⵥ�ĵ������=�ɱ�����*�˻�����
                            rcOleDbCommand.CommandText = "UPDATE oe_xsd SET oe_xsd.cbje = oe_xsd.sl * ?,oe_xsd.cbdj = ? WHERE oe_xsd.cpdm = ? AND ckdm = ? AND SUBSTR(oe_xsd.djh,5,6) >= ?  AND SUBSTR(oe_xsd.djh,5,6) <= ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                            rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("cpxx").Rows(i).Item("cpdm")
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("clqcye").Rows(j).Item("ckdm")
                            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthBegin.Value.ToString.PadLeft(2, "0")
                            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthEnd.Value.ToString.PadLeft(2, "0")
                            rcOleDbCommand.ExecuteNonQuery()
                            ''��ƽ�����۽��и��µ��²�Ʒ���ⵥ�ĵ������=�ɱ�����*�˻�����
                            rcOleDbCommand.CommandText = "UPDATE inv_ckd SET inv_ckd.je = inv_ckd.sl * ?,inv_ckd.dj = ? WHERE inv_ckd.cpdm = ? AND ckdm = ? AND SUBSTR(inv_ckd.djh,5,6) >= ? AND SUBSTR(inv_ckd.djh,5,6) <= ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                            rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("cpxx").Rows(i).Item("cpdm")
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("clqcye").Rows(j).Item("ckdm")
                            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthBegin.Value.ToString.PadLeft(2, "0")
                            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthEnd.Value.ToString.PadLeft(2, "0")
                            rcOleDbCommand.ExecuteNonQuery()
                        Next

                End Select
                '���ϳ���ɱ�β��ĵ���,�Ƚ��ȳ������ý���β�������
            Next
            '�������Ʒ�ĳɱ�
            '******************
            '���²�Ʒ�����׼
            rcOleDbCommand.CommandText = "UPDATE inv_rkd SET inv_rkd.bzcb = (SELECT bzcb FROM rc_cpxx WHERE rc_cpxx.cpdm = inv_rkd.cpdm)  WHERE SUBSTR(inv_rkd.djh,5,6) >= ? AND SUBSTR(inv_rkd.djh,5,6) <= ?"
            'rcOleDbCommand.CommandText = "UPDATE inv_rkd SET inv_rkd.clcb = (SELECT clcb FROM rc_cpxx WHERE rc_cpxx.cpdm = inv_rkd.cpdm),inv_rkd.rgcb = (SELECT rgcb FROM rc_cpxx WHERE rc_cpxx.cpdm = inv_rkd.cpdm) WHERE SUBSTR(inv_rkd.djh,5,6) >= ? AND SUBSTR(inv_rkd.djh,5,6) <= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthBegin.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthEnd.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            '���ܲ��ϳ����ܽ��
            rcOleDbCommand.CommandText = "SELECT bmdm,COALESCE(SUM(je),0.0) AS je FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND SUBSTR(inv_ckd.djh,5,6) >= ? AND SUBSTR(inv_ckd.djh,5,6) <= ? GROUP BY bmdm ORDER BY bmdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthBegin.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthEnd.Value.ToString.PadLeft(2, "0")
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If Not rcDataSet.Tables("inv_ckd") Is Nothing Then
                rcDataSet.Tables("inv_ckd").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "inv_ckd")
            '�ڽ�������ʾ���Ͻ��
            For i = 0 To rcDataSet.Tables("inv_ckd").Rows.Count - 1
                For j = 0 To rcDataSet.Tables("rc_cbjz").Rows.Count - 1
                    If rcDataSet.Tables("inv_ckd").Rows(i).Item("bmdm") = rcDataSet.Tables("rc_cbjz").Rows(j).Item("bmdm") Then
                        rcDataSet.Tables("rc_cbjz").Rows(j).Item("clcb") = rcDataSet.Tables("inv_ckd").Rows(i).Item("je")
                    End If
                Next
            Next
            Me.TxtZclcb.Text = rcDataSet.Tables("rc_cbjz").Compute("SUM(clcb)", "")
            Me.TxtZrgcb.Text = rcDataSet.Tables("rc_cbjz").Compute("SUM(rgcb)", "")
            Me.TxtZglcb.Text = rcDataSet.Tables("rc_cbjz").Compute("SUM(glcb)", "")
            Me.TxtZcb.Text = Val(Me.TxtZclcb.Text) + Val(Me.TxtZrgcb.Text) + Val(Me.TxtZglcb.Text)
            '�����Ž���ѭ����̯
            For i = 0 To rcDataSet.Tables("rc_cbjz").Rows.Count - 1
                dblBmzje = rcDataSet.Tables("rc_cbjz").Rows(i).Item("zcb")
                If dblBmzje <> 0 Then
                    '����Լ������
                    rcOleDbCommand.CommandText = "SELECT COALESCE(SUM(bzcb * sl),0.0) AS zydsl FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND SUBSTR(inv_rkd.djh,5,6) >= ? AND SUBSTR(inv_rkd.djh,5,6) <= ? AND inv_rkd.bmdm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthBegin.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthEnd.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("rc_cbjz").Rows(i).Item("bmdm")
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If Not rcDataSet.Tables("inv_rkd") Is Nothing Then
                        rcDataSet.Tables("inv_rkd").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataSet, "inv_rkd")
                    dblZydsl = rcDataSet.Tables("inv_rkd").Rows(0).Item("zydsl")
                    If dblZydsl <> 0 Then
                        rcOleDbCommand.CommandText = "UPDATE inv_rkd SET inv_rkd.dj = " & dblBmzje & "/" & dblZydsl & "  * inv_rkd.bzcb,inv_rkd.je = " & dblBmzje & "/" & dblZydsl & " * inv_rkd.sl * inv_rkd.bzcb WHERE SUBSTR(inv_rkd.djh,5,6) >= ? AND SUBSTR(inv_rkd.djh,5,6) <= ? AND inv_rkd.bmdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthBegin.Value.ToString.PadLeft(2, "0")
                        rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthEnd.Value.ToString.PadLeft(2, "0")
                        rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("rc_cbjz").Rows(i).Item("bmdm")
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                    '�������
                    'ȡ�ϼ������
                    rcOleDbCommand.CommandText = "SELECT COALESCE(SUM(je),0.0) AS je FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND SUBSTR(inv_rkd.djh,5,6) >= ? AND SUBSTR(inv_rkd.djh,5,6) <= ? AND inv_rkd.bmdm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthBegin.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthEnd.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("rc_cbjz").Rows(i).Item("bmdm")
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If Not rcDataSet.Tables("inv_rkd1") Is Nothing Then
                        rcDataSet.Tables("inv_rkd1").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataSet, "inv_rkd1")
                    If rcDataSet.Tables("inv_rkd1").Rows(0).Item("je") <> dblBmzje Then
                        'ȡ���������ĵ���
                        rcOleDbCommand.CommandText = "SELECT djh,xh,je FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND SUBSTR(inv_rkd.djh,5,6) >= ? AND SUBSTR(inv_rkd.djh,5,6) <= ? AND inv_rkd.bmdm = ? ORDER BY je DESC"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthBegin.Value.ToString.PadLeft(2, "0")
                        rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthEnd.Value.ToString.PadLeft(2, "0")
                        rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("rc_cbjz").Rows(i).Item("bmdm")
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If Not rcDataSet.Tables("inv_rkd2") Is Nothing Then
                            rcDataSet.Tables("inv_rkd2").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataSet, "inv_rkd2")
                        If rcDataSet.Tables("inv_rkd2").Rows.Count > 0 Then
                            rcOleDbCommand.CommandText = "UPDATE inv_rkd SET inv_rkd.je = inv_rkd.je - " & rcDataSet.Tables("inv_rkd1").Rows(0).Item("je") & "+" & dblBmzje & " WHERE inv_rkd.djh = ? AND inv_rkd.xh = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataSet.Tables("inv_rkd2").Rows(0).Item("djh")
                            rcOleDbCommand.Parameters.Add("@xh", OleDbType.Numeric, 4).Value = rcDataSet.Tables("inv_rkd2").Rows(0).Item("xh")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                Else
                    rcOleDbCommand.CommandText = "UPDATE inv_rkd SET inv_rkd.dj = 0.0,inv_rkd.je = 0.0 WHERE SUBSTR(inv_rkd.djh,5,6) >= ? AND SUBSTR(inv_rkd.djh,5,6) <= ? AND inv_rkd.bmdm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthBegin.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthEnd.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("rc_cbjz").Rows(i).Item("bmdm")
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            Next
            ''�������Ʒ���˹��ɱ�
            ''���²�Ʒ�����׼
            'rcOleDbCommand.CommandText = "UPDATE inv_rkd SET inv_rkd.je = inv_rkd.je + inv_rkd.rgcb * inv_rkd.sl WHERE SUBSTR(inv_rkd.djh,5,6) >= ? AND SUBSTR(inv_rkd.djh,5,6) <= ?"
            'rcOleDbCommand.Parameters.Clear()
            'rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthBegin.Value.ToString.PadLeft(2, "0")
            'rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthEnd.Value.ToString.PadLeft(2, "0")
            'rcOleDbCommand.ExecuteNonQuery()
            'rcOleDbCommand.CommandText = "UPDATE inv_rkd SET inv_rkd.dj = CASE WHEN inv_rkd.sl <> 0  THEN inv_rkd.je / inv_rkd.sl ELSE 0.0 END WHERE SUBSTR(inv_rkd.djh,5,6) >= ? AND SUBSTR(inv_rkd.djh,5,6) <= ?"
            'rcOleDbCommand.Parameters.Clear()
            'rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthBegin.Value.ToString.PadLeft(2, "0")
            'rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthEnd.Value.ToString.PadLeft(2, "0")
            'rcOleDbCommand.ExecuteNonQuery()
            '��ת����Ʒ�ĳ���ɱ�
            For i = 0 To rcDataSet.Tables("cpxx").Rows.Count - 1
                Me.ProgressBar1.Value = 100 / rcDataSet.Tables("cpxx").Rows.Count * (i + 1)
                '�ֲֿ����,��������������������������������������ĳ���ɱ�
                rcOleDbCommand.CommandText = "SELECT cpdm,ckdm,COALESCE(sum(qcsl),0.0) as qcsl,COALESCE(sum(qcje),0.0) as qcje,COALESCE(sum(qccgrksl),0.0) as qccgrksl,COALESCE(sum(qccgrkje),0.0) as qccgrkje,COALESCE(sum(qcscrksl),0.0) as qcscrksl,COALESCE(sum(qcscrkje),0.0) as qcscrkje,COALESCE(sum(qcdbrksl),0.0) as qcdbrksl,COALESCE(sum(qcdbrkje),0.0) as qcdbrkje,COALESCE(sum(qcxscksl),0.0) as qcxscksl,COALESCE(sum(qcxsckje),0.0) as qcxsckje,COALESCE(sum(qcckcksl),0.0) as qcckcksl,COALESCE(sum(qcckckje),0.0) as qcckckje,COALESCE(sum(qcdbcksl),0.0) as qcdbcksl,COALESCE(sum(qcdbckje),0.0) as qcdbckje FROM (SELECT clnc.cpdm,clnc.ckdm,clnc.qcsl,clnc.qcje,qccgrk.qccgrksl,qccgrk.qccgrkje,qcscrk.qcscrksl,qcscrk.qcscrkje,qcdbrk.qcdbrksl,qcdbrk.qcdbrkje,qcxsck.qcxscksl,qcxsck.qcxsckje,qcckck.qcckcksl,qcckck.qcckckje,qcdbck.qcdbcksl,qcdbck.qcdbckje FROM" & _
                    " (SELECT inv_cpyeb.cpdm,inv_cpyeb.ckdm,sum(qcsl) as qcsl,sum(qcje) as qcje FROM inv_cpyeb WHERE kjnd = ? AND cpdm = ? GROUP by inv_cpyeb.cpdm,inv_cpyeb.ckdm) clnc" & _
                    " Left join (SELECT po_rkd.cpdm,po_rkd.ckdm,sum(po_rkd.sl) as qccgrksl,sum(po_rkd.je) as qccgrkje FROM po_rkd WHERE po_rkd.bdelete = 0 AND po_rkd.rkrq >= ? and po_rkd.rkrq >= ? and po_rkd.rkrq <= ? AND cpdm = ? GROUP BY po_rkd.cpdm,po_rkd.ckdm) qccgrk ON clnc.cpdm = qccgrk.cpdm AND clnc.ckdm = qccgrk.ckdm" & _
                    " Left join (SELECT inv_rkd.cpdm,inv_rkd.ckdm,sum(inv_rkd.sl) as qcscrksl,sum(inv_rkd.je) as qcscrkje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND inv_rkd.rkrq >= ? and inv_rkd.rkrq >= ? and inv_rkd.rkrq <= ? AND cpdm = ? GROUP BY inv_rkd.cpdm,inv_rkd.ckdm) qcscrk ON clnc.cpdm = qcscrk.cpdm AND clnc.ckdm = qcscrk.ckdm" & _
                    " Left join (SELECT inv_dbd.cpdm,inv_dbd.rckdm AS ckdm,sum(inv_dbd.sl) as qcdbrksl,sum(inv_dbd.je) as qcdbrkje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ? AND cpdm = ? GROUP BY inv_dbd.cpdm,inv_dbd.rckdm) qcdbrk ON clnc.cpdm = qcdbrk.cpdm AND clnc.ckdm = qcdbrk.ckdm" & _
                    " Left join (SELECT oe_xsd.cpdm,oe_xsd.ckdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq < ? AND cpdm = ? GROUP BY oe_xsd.cpdm,oe_xsd.ckdm) qcxsck ON clnc.cpdm = qcxsck.cpdm AND clnc.ckdm = qcxsck.ckdm" & _
                    " Left join (SELECT inv_ckd.cpdm,inv_ckd.ckdm,sum(inv_ckd.sl) as qcckcksl,sum(inv_ckd.je) as qcckckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND inv_ckd.ckrq >= ? and inv_ckd.ckrq >= ? and inv_ckd.ckrq <= ? AND cpdm = ? GROUP BY inv_ckd.cpdm,inv_ckd.ckdm) qcckck ON clnc.cpdm = qcckck.cpdm AND clnc.ckdm = qcckck.ckdm" & _
                    " Left join (SELECT inv_dbd.cpdm,inv_dbd.cckdm AS ckdm,sum(inv_dbd.sl) as qcdbcksl,sum(inv_dbd.je) as qcdbckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') < ? AND cpdm = ? GROUP BY inv_dbd.cpdm,inv_dbd.cckdm) qcdbck ON clnc.cpdm = qcdbck.cpdm AND clnc.ckdm = qcdbck.ckdm) asfchz GROUP BY cpdm,ckdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePoBegin1
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePoBegin1
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePoBegin1
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateKsrq
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = datePoBegin1
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = datePoBegin1
                rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateKsrq
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePoBegin1
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateKsrq
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If Not rcDataSet.Tables("clqcye") Is Nothing Then
                    rcDataSet.Tables("clqcye").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "clqcye")
                For j = 0 To rcDataSet.Tables("clqcye").Rows.Count - 1
                    'ȡƽ������
                    dblQcsl = rcDataSet.Tables("clqcye").Rows(j).Item("qcsl") + rcDataSet.Tables("clqcye").Rows(j).Item("qccgrksl") + rcDataSet.Tables("clqcye").Rows(j).Item("qcscrksl") + rcDataSet.Tables("clqcye").Rows(j).Item("qcdbrksl") - rcDataSet.Tables("clqcye").Rows(j).Item("qcxscksl") - rcDataSet.Tables("clqcye").Rows(j).Item("qcckcksl") - rcDataSet.Tables("clqcye").Rows(j).Item("qcdbcksl")
                    dblQcje = rcDataSet.Tables("clqcye").Rows(j).Item("qcje") + rcDataSet.Tables("clqcye").Rows(j).Item("qccgrkje") + rcDataSet.Tables("clqcye").Rows(j).Item("qcscrkje") + rcDataSet.Tables("clqcye").Rows(j).Item("qcdbrkje") - rcDataSet.Tables("clqcye").Rows(j).Item("qcxsckje") - rcDataSet.Tables("clqcye").Rows(j).Item("qcckckje") - rcDataSet.Tables("clqcye").Rows(j).Item("qcdbckje")
                    '�����Ʒ�����ɱ�����=���µ�������+���������/������������+�����������
                    If dblQcsl <> 0 Then
                        dblQcdj = dblQcje / dblQcsl
                    Else
                        dblQcdj = 0.0
                    End If
                    ''��ƽ�����۽��и��µ��²�Ʒ�������ĵ������=�ɱ�����*�˻�����
                    rcOleDbCommand.CommandText = "UPDATE inv_dbd SET inv_dbd.je = inv_dbd.sl * ?,inv_dbd.dj = ? WHERE inv_dbd.cpdm = ? AND cckdm = ? AND SUBSTR(inv_dbd.djh,5,6) >= ? AND SUBSTR(inv_dbd.djh,5,6) <= ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                    rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("cpxx").Rows(i).Item("cpdm")
                    rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("clqcye").Rows(j).Item("ckdm")
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthBegin.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthEnd.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.ExecuteNonQuery()
                Next
                '�ֲֿ����,������������������������������ⵥ�ĳ���ɱ�
                rcOleDbCommand.CommandText = "SELECT cpdm,ckdm,COALESCE(sum(qcsl),0.0) as qcsl,COALESCE(sum(qcje),0.0) as qcje,COALESCE(sum(qccgrksl),0.0) as qccgrksl,COALESCE(sum(qccgrkje),0.0) as qccgrkje,COALESCE(sum(qcscrksl),0.0) as qcscrksl,COALESCE(sum(qcscrkje),0.0) as qcscrkje,COALESCE(sum(qcdbrksl),0.0) as qcdbrksl,COALESCE(sum(qcdbrkje),0.0) as qcdbrkje,COALESCE(sum(qcxscksl),0.0) as qcxscksl,COALESCE(sum(qcxsckje),0.0) as qcxsckje,COALESCE(sum(qcckcksl),0.0) as qcckcksl,COALESCE(sum(qcckckje),0.0) as qcckckje,COALESCE(sum(qcdbcksl),0.0) as qcdbcksl,COALESCE(sum(qcdbckje),0.0) as qcdbckje FROM (SELECT clnc.cpdm,clnc.ckdm,clnc.qcsl,clnc.qcje,qccgrk.qccgrksl,qccgrk.qccgrkje,qcscrk.qcscrksl,qcscrk.qcscrkje,qcdbrk.qcdbrksl,qcdbrk.qcdbrkje,qcxsck.qcxscksl,qcxsck.qcxsckje,qcckck.qcckcksl,qcckck.qcckckje,qcdbck.qcdbcksl,qcdbck.qcdbckje FROM" & _
                    " (SELECT inv_cpyeb.cpdm,inv_cpyeb.ckdm,sum(qcsl) as qcsl,sum(qcje) as qcje FROM inv_cpyeb WHERE kjnd = ? AND cpdm = ? GROUP by inv_cpyeb.cpdm,inv_cpyeb.ckdm) clnc" & _
                    " Left join (SELECT po_rkd.cpdm,po_rkd.ckdm,sum(po_rkd.sl) as qccgrksl,sum(po_rkd.je) as qccgrkje FROM po_rkd WHERE po_rkd.bdelete = 0 AND po_rkd.rkrq >= ? and po_rkd.rkrq >= ? and po_rkd.rkrq <= ? AND cpdm = ? GROUP BY po_rkd.cpdm,po_rkd.ckdm) qccgrk ON clnc.cpdm = qccgrk.cpdm AND clnc.ckdm = qccgrk.ckdm" & _
                    " Left join (SELECT inv_rkd.cpdm,inv_rkd.ckdm,sum(inv_rkd.sl) as qcscrksl,sum(inv_rkd.je) as qcscrkje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND inv_rkd.rkrq >= ? and inv_rkd.rkrq >= ? and inv_rkd.rkrq <= ? AND cpdm = ? GROUP BY inv_rkd.cpdm,inv_rkd.ckdm) qcscrk ON clnc.cpdm = qcscrk.cpdm AND clnc.ckdm = qcscrk.ckdm" & _
                    " Left join (SELECT inv_dbd.cpdm,inv_dbd.rckdm AS ckdm,sum(inv_dbd.sl) as qcdbrksl,sum(inv_dbd.je) as qcdbrkje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ? AND cpdm = ? GROUP BY inv_dbd.cpdm,inv_dbd.rckdm) qcdbrk ON clnc.cpdm = qcdbrk.cpdm AND clnc.ckdm = qcdbrk.ckdm" & _
                    " Left join (SELECT oe_xsd.cpdm,oe_xsd.ckdm,sum(oe_xsd.sl) as qcxscksl,sum(oe_xsd.cbje) as qcxsckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND oe_xsd.xsrq >= ? and oe_xsd.xsrq >= ? and oe_xsd.xsrq < ? AND cpdm = ? GROUP BY oe_xsd.cpdm,oe_xsd.ckdm) qcxsck ON clnc.cpdm = qcxsck.cpdm AND clnc.ckdm = qcxsck.ckdm" & _
                    " Left join (SELECT inv_ckd.cpdm,inv_ckd.ckdm,sum(inv_ckd.sl) as qcckcksl,sum(inv_ckd.je) as qcckckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND inv_ckd.ckrq >= ? and inv_ckd.ckrq >= ? and inv_ckd.ckrq <= ? AND cpdm = ? GROUP BY inv_ckd.cpdm,inv_ckd.ckdm) qcckck ON clnc.cpdm = qcckck.cpdm AND clnc.ckdm = qcckck.ckdm" & _
                    " Left join (SELECT inv_dbd.cpdm,inv_dbd.cckdm AS ckdm,sum(inv_dbd.sl) as qcdbcksl,sum(inv_dbd.je) as qcdbckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') >= ? and TRUNC(inv_dbd.dbrq,'mi') <= ? AND cpdm = ? GROUP BY inv_dbd.cpdm,inv_dbd.cckdm) qcdbck ON clnc.cpdm = qcdbck.cpdm AND clnc.ckdm = qcdbck.ckdm) asfchz GROUP BY cpdm,ckdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePoBegin1
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = datePoBegin1
                rcOleDbCommand.Parameters.Add("@rkrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePoBegin1
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateJsrq
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = datePoBegin1
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = dateKsrq
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = datePoBegin1
                rcOleDbCommand.Parameters.Add("@ckrq", OleDbType.Date, 8).Value = dateKsrq
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = datePoBegin1
                rcOleDbCommand.Parameters.Add("@dbrq", OleDbType.Date, 8).Value = dateKsrq
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = Trim(rcDataSet.Tables("cpxx").Rows(i).Item("cpdm"))
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If Not rcDataSet.Tables("clqcye") Is Nothing Then
                    rcDataSet.Tables("clqcye").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "clqcye")
                For j = 0 To rcDataSet.Tables("clqcye").Rows.Count - 1
                    'ȡƽ������
                    dblQcsl = rcDataSet.Tables("clqcye").Rows(j).Item("qcsl") + rcDataSet.Tables("clqcye").Rows(j).Item("qccgrksl") + rcDataSet.Tables("clqcye").Rows(j).Item("qcscrksl") + rcDataSet.Tables("clqcye").Rows(j).Item("qcdbrksl") - rcDataSet.Tables("clqcye").Rows(j).Item("qcxscksl") - rcDataSet.Tables("clqcye").Rows(j).Item("qcckcksl") - rcDataSet.Tables("clqcye").Rows(j).Item("qcdbcksl")
                    dblQcje = rcDataSet.Tables("clqcye").Rows(j).Item("qcje") + rcDataSet.Tables("clqcye").Rows(j).Item("qccgrkje") + rcDataSet.Tables("clqcye").Rows(j).Item("qcscrkje") + rcDataSet.Tables("clqcye").Rows(j).Item("qcdbrkje") - rcDataSet.Tables("clqcye").Rows(j).Item("qcxsckje") - rcDataSet.Tables("clqcye").Rows(j).Item("qcckckje") - rcDataSet.Tables("clqcye").Rows(j).Item("qcdbckje")
                    '�����Ʒ�����ɱ�����=���µ�������+���������/������������+�����������
                    If dblQcsl <> 0 Then
                        dblQcdj = dblQcje / dblQcsl
                    Else
                        dblQcdj = 0.0
                    End If

                    ''��ƽ�����۽��и��µ��²�Ʒ���ⵥ�ĵ������=�ɱ�����*�˻�����
                    rcOleDbCommand.CommandText = "UPDATE oe_xsd SET oe_xsd.cbje = oe_xsd.sl * ?,oe_xsd.cbdj = ? WHERE oe_xsd.cpdm = ? AND ckdm = ? AND SUBSTR(oe_xsd.djh,5,6) >= ? AND SUBSTR(oe_xsd.djh,5,6) <= ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                    rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("cpxx").Rows(i).Item("cpdm")
                    rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("clqcye").Rows(j).Item("ckdm")
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthBegin.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthEnd.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.ExecuteNonQuery()
                    ''��ƽ�����۽��и��µ��²�Ʒ���ⵥ�ĵ������=�ɱ�����*�˻�����
                    rcOleDbCommand.CommandText = "UPDATE inv_ckd SET inv_ckd.je = inv_ckd.sl * ?,inv_ckd.dj = ? WHERE inv_ckd.cpdm = ? AND ckdm = ? AND SUBSTR(inv_ckd.djh,5,6) >= ? AND SUBSTR(inv_ckd.djh,5,6) <= ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                    rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = dblQcdj
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("cpxx").Rows(i).Item("cpdm")
                    rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("clqcye").Rows(j).Item("ckdm")
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthBegin.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonthEnd.Value.ToString.PadLeft(2, "0")
                    rcOleDbCommand.ExecuteNonQuery()
                Next
            Next
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Catch ey As OleDbException
                MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        MsgBox("�ɱ���ת��ɡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
        Me.Close()
    End Sub

    Private Sub TxtZclcb_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtZclcb.Validating, TxtZrgcb.Validating, TxtZglcb.Validating
        Me.TxtZcb.Text = Val(Me.TxtZclcb.Text) + Val(Me.TxtZrgcb.Text) + Val(Me.TxtZglcb.Text)
    End Sub

    Private Sub DataGridView1_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DataGridView1.RowValidating
        '����ϼ���
        Dim dblTotClcb As Double = 0.0
        Dim dblTotRgcb As Double = 0.0
        Dim dblTotGlcb As Double = 0.0
        If dtBom.Rows.Count > 0 Then
            dblTotClcb = dtBom.Compute("Sum(clcb)", "")
            dblTotRgcb = dtBom.Compute("Sum(rgcb)", "")
            dblTotGlcb = dtBom.Compute("Sum(glcb)", "")
        End If
        Me.TxtZclcb.Text = Format(dblTotClcb, g_FormatJe)
        Me.TxtZrgcb.Text = Format(dblTotRgcb, g_FormatJe)
        Me.TxtZglcb.Text = Format(dblTotGlcb, g_FormatJe)
        Me.TxtZcb.Text = Format(dblTotClcb + dblTotRgcb + dblTotGlcb, g_FormatJe)

    End Sub
End Class