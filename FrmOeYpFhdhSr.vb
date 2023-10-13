Imports System.Data.OleDb

Public Class FrmOeYpFhdhSr

#Region "�������"

    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '���ݸ��´���
    Dim rcOleDbTrans As OleDbTransaction
    '��������
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

#End Region

#Region "�ؼ��س����Ĵ���"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpQdrqBegin.KeyPress, DtpQdrqEnd.KeyPress, TxtHth.KeyPress, TxtKhdm.KeyPress, TxtCpmc.KeyPress, TxtCpgg.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                'ָʾ KeyPress �¼��Ѵ�����ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "�ͻ������¼�"

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
                    .paraOrderField = "khmc"
                    .paraTitle = "�ͻ�"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtKhdm.Text = Trim(.paraField1)
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
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "SELECT rc_khxx.khdm,rc_khxx.khmc FROM rc_khxx WHERE (khdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKhdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_khxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_khxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_khxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_khxx").Rows.Count <= 0 Then
                MsgBox("�ͻ����벻���ڣ��������롣", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "��ͬ������¼�"

    Private Sub TxtHth_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtHth.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

#End Region

#Region "��Ʒ�����¼�"

    Private Sub TxtCpmc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCpmc.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

#End Region

#Region "��Ʒ�����¼�"

    Private Sub TxtCpgg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCpgg.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

#End Region

#Region "ȷ���¼�"

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        'ȡ����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT Case When oe_ypdd.zt = 3 Then 0 Else 1 End as xz,fhrq,Coalesce(oe_ypdd.shdh,'') As shdh,oe_ypdd.khdm,oe_ypdd.khmc,oe_ypdd.lxr,oe_ypdd.hth,oe_ypdd.cpdm,oe_ypdd.cpmc,oe_ypdd.cpgg,oe_ypdd.cpmemo,oe_ypdd.dw,oe_ypdd.khlh,oe_ypdd.khcz,oe_ypdd.sl,oe_ypdd.zl,oe_ypdd.qdrq,oe_ypdd.khjhrq,oe_ypdd.scjhrq,oe_ypdd.fhrq,oe_ypdd.bmdm,REPLACE(oe_ypdd.ddtk || oe_ypdd.ddmemo,' ','') as ddmemo,oe_ypdd.djh,oe_ypdd.xh From oe_ypdd WHERE oe_ypdd.fhrq >= ? And oe_ypdd.fhrq <= ?" & IIf(Not String.IsNullOrEmpty(Me.TxtKhdm.Text), " and oe_ypdd.khdm = '" & Trim(Me.TxtKhdm.Text) & "'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtHth.Text), " and oe_ypdd.hth LIKE '" & Trim(Me.TxtHth.Text) & "%'", " And oe_ypdd.zt = 3 And oe_ypdd.sl - oe_ypdd.hxsl > 0") & IIf(Not String.IsNullOrEmpty(Me.TxtCpmc.Text), " and oe_ypdd.cpmc LIKE '" & Trim(Me.TxtCpmc.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtCpgg.Text), " and oe_ypdd.cpgg LIKE '" & Trim(Me.TxtCpgg.Text) & "%'", "")
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.AddWithValue("@fhrq", Me.DtpQdrqBegin.Value.Date)
            rcOleDbCommand.Parameters.AddWithValue("@fhrq", Me.DtpQdrqEnd.Value.Date)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_ypddnr") IsNot Nothing Then
                rcDataset.Tables("rc_ypddnr").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_ypddnr")
        Catch ex As Exception
            MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_ypddnr").Rows.Count <= 0 Then
            MsgBox("û���������������ݡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        '���ñ���
        Dim rcFrm As New FrmOeYpFhdhSrz
        With rcFrm
            .ParaDataSet = rcDataset
            '.ParaDataView = New DataView(rcDataset.Tables("rc_ypddnr"), "TRUE", "djh,xh", DataViewRowState.CurrentRows)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

#End Region
End Class