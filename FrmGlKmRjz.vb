Imports System.Data.OleDb

Public Class FrmGlKmRjz

#Region "�������"

    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '��ʾҪ������Դִ�е� SQL ����
    Dim rcOleDbTrans As OleDbTransaction
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As New OleDbCommand
    '����Datatable
    ReadOnly dtGlKmMxz As New DataTable("kmmxz")

#End Region

#Region "��ʼ��"

    Private Sub FrmKmRjz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Ĭ��ֵ
        Me.NudYear.Value = Mid(g_Kjqj, 1, 4)
        Me.NudMonthBegin.Value = Mid(g_Kjqj, 5, 2)
        Me.NudMonthEnd.Value = Mid(g_Kjqj, 5, 2)
        '����datatable
        dtGlKmMxz.Columns.Add("pzrq", Type.GetType("System.DateTime"))
        dtGlKmMxz.Columns.Add("djh", Type.GetType("System.String"))
        dtGlKmMxz.Columns.Add("zy", Type.GetType("System.String"))
        dtGlKmMxz.Columns.Add("jfje", Type.GetType("System.Double"))
        dtGlKmMxz.Columns.Add("dfje", Type.GetType("System.Double"))
        dtGlKmMxz.Columns.Add("jd", Type.GetType("System.String"))
        dtGlKmMxz.Columns.Add("ye", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtGlKmMxz)
        With rcDataset.Tables("kmmxz")
            .Columns("djh").DefaultValue = ""
            .Columns("zy").DefaultValue = ""
            .Columns("jfje").DefaultValue = 0.0
            .Columns("dfje").DefaultValue = 0.0
            .Columns("jd").DefaultValue = ""
            .Columns("ye").DefaultValue = 0.0
        End With
    End Sub

#End Region

#Region "��Ŀ������¼�"

    Private Sub TxtKmdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtKmdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "gl_kmxx"
                    .paraField1 = "kmdm"
                    .paraField2 = "kmmc"
                    .paraField3 = "kmsm"
                    .paraCondition = "0=0"
                    .paraOrderField = "kmdm"
                    .paraTitle = "��Ŀ"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtKmdm.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtKmdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtKmdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtKmdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM gl_kmxx WHERE (kmdm = ?)" ' AND NOT EXISTS (SELECT 1 FROM gl_kmxx aa WHERE aa.parentid = gl_kmxx.kmdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKmdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("gl_kmxx") IsNot Nothing Then
                    Me.rcDataset.Tables("gl_kmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "gl_kmxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("gl_kmxx").Rows.Count > 0 Then
                TxtKmdm.Text = Trim(rcDataSet.Tables("gl_kmxx").Rows(0).Item("kmdm"))
                'LblKmmc.Text = rcDataSet.Tables("gl_kmxx").Rows(0).Item("kmmc")
            Else
                MsgBox("��Ŀ���벻���ڡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                e.Cancel = True
                Return
            End If
        End If
    End Sub

#End Region

#Region "ȷ���¼�"

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim i As Integer
        Dim dblQcje As Double
        Dim dblYe As Double = 0.0
        Dim datePzrqBegin As Date
        Dim datePzrqEnd As Date
        If rcDataSet.Tables("kmmxz") IsNot Nothing Then
            rcDataSet.Tables("kmmxz").Clear()
        End If
        '��Ŀ���벻��Ϊ��
        If String.IsNullOrEmpty(Me.TxtKmdm.Text) Then
            MsgBox("��Ŀ���벻��Ϊ�ա�", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            Return
        End If

        'ȡ�ڳ���
        datePzrqBegin = getInvBegin(Me.NudYear.Value, 1)
        datePzrqEnd = getInvBegin(Me.NudYear.Value, Me.NudMonthBegin.Value)
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT SUM(CASE WHEN jd = '��' THEN ncje ELSE 0.0-ncje END"
            For i = 1 To Me.NudMonthBegin.Value - 1
                rcOleDbCommand.CommandText += " + jfje" & i.ToString.PadLeft(2, "0") & " - dfje" & i.ToString.PadLeft(2, "0")
            Next
            rcOleDbCommand.CommandText += ") AS qcje FROM gl_kmyeb WHERE kmdm LIKE '" & Me.TxtKmdm.Text & "%'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("qckmye") IsNot Nothing Then
                rcDataSet.Tables("qckmye").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "qckmye")
        Catch ex As Exception
            MsgBox("�������2��" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("qckmye").Rows(0).Item("qcje").GetType.ToString = "System.DBNull" Then
            rcDataSet.Tables("qckmye").Rows(0).Item("qcje") = 0.0
        End If
        dblQcje = rcDataSet.Tables("qckmye").Rows(0).Item("qcje")
        datePzrqBegin = getInvBegin(NudYear.Value, NudMonthBegin.Value)
        Dim rcDataRow As DataRow = dtGlKmMxz.NewRow
        rcDataRow.Item("pzrq") = datePzrqBegin
        rcDataRow.Item("zy") = "�ڳ����"
        rcDataRow.Item("jd") = IIf(dblQcje > 0, "��", IIf(dblQcje < 0, "��", "ƽ"))
        rcDataRow.Item("ye") = IIf(dblQcje > 0, dblQcje, 0 - dblQcje)
        dtGlKmMxz.Rows.Add(rcDataRow)
        dblYe = dblQcje
        datePzrqBegin = getInvBegin(Me.NudYear.Value, Me.NudMonthBegin.Value)
        datePzrqEnd = getInvEnd(Me.NudYear.Value, Me.NudMonthEnd.Value)
        'ȡ����
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "Select gl_pz.pzrq,gl_pz.djh,gl_pz.zy,gl_pz.dfkm,gl_pz.yspz,Case When jd = '��' Then je Else 0 End As jfje,Case When jd = '��' Then je Else 0 End As dfje From gl_pz Where gl_pz.kmdm = ? And gl_pz.pzrq >= ? And gl_pz.pzrq <= ?"
            rcOleDbCommand.CommandText = rcOleDbCommand.CommandText
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKmdm.Text)
            rcOleDbCommand.Parameters.Add("@pzrq", OleDbType.Date, 8).Value = datePzrqBegin
            rcOleDbCommand.Parameters.Add("@pzrq", OleDbType.Date, 8).Value = datePzrqEnd
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            rcOleDbDataAdpt.Fill(rcDataSet, "kmmxz")
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Catch ey As OleDbException
                MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '���պϼ�
        i = 0
        datePzrqBegin = getInvBegin(Me.NudYear.Value, Me.NudMonthBegin.Value)
        datePzrqEnd = getInvEnd(Me.NudYear.Value, Me.NudMonthEnd.Value)
        Do While datePzrqBegin.AddDays(i) <= datePzrqEnd
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT '" & datePzrqBegin.AddDays(i).ToString & "' As pzrq,'���պϼ�' As zy,COALESCE(SUM(CASE WHEN jd = '��' THEN gl_pz.je ELSE 0.0 END),0.0) As jfje,COALESCE(SUM(CASE WHEN jd = '��' THEN gl_pz.je ELSE 0.0 END),0.0) As dfje FROM gl_pz WHERE gl_pz.bdelete = 0 AND kmdm = ? AND gl_pz.pzrq >= ? AND gl_pz.pzrq >= ? AND gl_pz.pzrq <= ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = Trim(TxtKmdm.Text)
                rcOleDbCommand.Parameters.Add("@pzrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@pzrq", OleDbType.Date, 8).Value = datePzrqBegin.AddDays(i)
                rcOleDbCommand.Parameters.Add("@pzrq", OleDbType.Date, 8).Value = datePzrqBegin.AddDays(i)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                rcOleDbDataAdpt.Fill(rcDataSet, "kmmxz")
                If rcDataSet.Tables("kmmxz").Rows(rcDataSet.Tables("kmmxz").Rows.Count - 1).Item("jfje") = 0 And rcDataSet.Tables("kmmxz").Rows(rcDataSet.Tables("kmmxz").Rows.Count - 1).Item("dfje") = 0 Then
                    rcDataSet.Tables("kmmxz").Rows(rcDataSet.Tables("kmmxz").Rows.Count - 1).Delete()
                Else
                    rcDataSet.Tables("kmmxz").Rows(rcDataSet.Tables("kmmxz").Rows.Count - 1).Item("ye") = dblYe + rcDataSet.Tables("kmmxz").Rows(rcDataSet.Tables("kmmxz").Rows.Count - 1).Item("jfje") - rcDataSet.Tables("kmmxz").Rows(rcDataSet.Tables("kmmxz").Rows.Count - 1).Item("dfje")
                    dblYe = rcDataSet.Tables("kmmxz").Rows(rcDataSet.Tables("kmmxz").Rows.Count - 1).Item("ye")
                    If dblYe > 0 Then
                        rcDataSet.Tables("kmmxz").Rows(rcDataSet.Tables("kmmxz").Rows.Count - 1).Item("jd") = "��"
                    Else
                        rcDataSet.Tables("kmmxz").Rows(rcDataSet.Tables("kmmxz").Rows.Count - 1).Item("jd") = "��"
                        rcDataSet.Tables("kmmxz").Rows(rcDataSet.Tables("kmmxz").Rows.Count - 1).Item("ye") = 0 - rcDataSet.Tables("kmmxz").Rows(rcDataSet.Tables("kmmxz").Rows.Count - 1).Item("ye")
                    End If
                End If
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            i += 1
        Loop
        ''�����ۼ�
        datePzrqBegin = getInvBegin(NudYear.Value, NudMonthBegin.Value)
        For i = Me.NudMonthBegin.Value To Me.NudMonthEnd.Value
            datePzrqEnd = getInvEnd(Me.NudYear.Value, i)
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT '" & datePzrqEnd.ToString & "' As pzrq,'�����ۼ�' As zy,COALESCE(SUM(CASE WHEN jd = '��' THEN gl_pz.je ELSE 0.0 END),0.0) As jfje,COALESCE(SUM(CASE WHEN jd = '��' THEN gl_pz.je ELSE 0.0 END),0.0) As dfje FROM gl_pz WHERE gl_pz.bdelete = 0 AND kmdm = ? AND gl_pz.pzrq >= ? AND gl_pz.pzrq >= ? AND gl_pz.pzrq <= ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = Trim(TxtKmdm.Text)
                rcOleDbCommand.Parameters.Add("@pzrq", OleDbType.Date, 8).Value = g_Dwrq.Date
                rcOleDbCommand.Parameters.Add("@pzrq", OleDbType.Date, 8).Value = datePzrqBegin
                rcOleDbCommand.Parameters.Add("@pzrq", OleDbType.Date, 8).Value = datePzrqEnd
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                rcOleDbDataAdpt.Fill(rcDataSet, "kmmxz")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        Next


        Dim rcFrm As New FrmGlKmMxzz
        With rcFrm
            .ParaDataView = New DataView(rcDataSet.Tables("kmmxz"), "TRUE", "pzrq", DataViewRowState.CurrentRows)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

#End Region

End Class