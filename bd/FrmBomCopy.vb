Imports System.Data.OleDb

Public Class FrmBomCopy

    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

#Region "���ϱ����¼�"

    Private Sub TxtParentCpdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtParentCpdm.KeyDown
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
                    .paraTitle = "����"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtParentCpdm.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtParentCpdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtParentCpdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtParentCpdm.Text) Then
            '��ȡ����
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT  *  From rc_cpxx Where cpdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtParentCpdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("parentcpxx") IsNot Nothing Then
                    rcDataset.Tables("parentcpxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "parentcpxx")
                rcOleDbCommand.CommandText = "SELECT * FROM pm_bom WHERE pm_bom.parentcpdm = ? ORDER BY pm_bom.childcpdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtParentCpdm.Text)
                If rcDataset.Tables("rc_bom") IsNot Nothing Then
                    rcDataset.Tables("rc_bom").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_bom")
            Catch ex As Exception
                MsgBox("�������1��" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("parentcpxx").Rows.Count > 0 Then
                If rcDataset.Tables("rc_bom").Rows.Count > 0 Then
                    MsgBox("�����ϱ����Ѵ���BOM��", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                    e.Cancel = True
                End If
            Else
                MsgBox("�����ϱ��벻���ڡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If String.IsNullOrEmpty(Me.TxtParentCpdm.Text) Then
            Me.DialogResult = DialogResult.No
        End If
    End Sub
End Class