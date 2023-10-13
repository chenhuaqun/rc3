Imports System.Data.OleDb
Public Class FrmQckhyeSr
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '��ʾҪ������Դִ�е� SQL ����
    Dim rcOleDbTrans As OleDbTransaction
    '��������
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Private Sub FrmQckhyeSr_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DtpXsrq.Value = g_Dwrq.Date.AddDays(-1)
        Me.TxtJe.Text = 0.0
        Me.TxtXsmemo.Text = ""
    End Sub

#Region "�ؼ��س����Ĵ���"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKhdm.KeyPress, TxtXh.KeyPress, DtpXsrq.KeyPress, TxtJe.KeyPress, TxtXsmemo.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "�ͻ�������¼�"

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
                    .paraTitle = "�ͻ�"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtKhdm.Text = Trim(.paraField1)
                        LblKhmc.Text = Trim(.paraField2)
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
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKhdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_khxx") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_khxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_khxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_khxx").Rows.Count > 0 Then
                TxtKhdm.Text = Trim(rcDataSet.Tables("rc_khxx").Rows(0).Item("khdm"))
                LblKhmc.Text = rcDataSet.Tables("rc_khxx").Rows(0).Item("khmc")
            Else
                e.Cancel = True
                Return
            End If
            LoadSavedQcsl()
        End If
    End Sub

#End Region

    Private Sub TxtXh_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtXh.Validating
        LoadSavedQcsl()
    End Sub

#Region "ȡԭ��������������"

    Private Sub LoadSavedQcsl()
        'ȡԭ��������
        If Not String.IsNullOrEmpty(Me.TxtKhdm.Text) And Not String.IsNullOrEmpty(Me.TxtXh.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT xsrq,je,xsmemo FROM oe_xsd WHERE khdm = ? AND xh = ? AND djh = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKhdm.Text).ToUpper
                rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = Me.TxtXh.Text
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKhdm.Text).ToUpper
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("khmx") IsNot Nothing Then
                    rcDataSet.Tables("khmx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "khmx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("khmx").Rows.Count > 0 Then
                Me.DtpXsrq.Value = rcDataSet.Tables("khmx").Rows(0).Item("xsrq")
                Me.TxtJe.Text = rcDataSet.Tables("khmx").Rows(0).Item("je")
                Me.TxtXsmemo.Text = rcDataSet.Tables("khmx").Rows(0).Item("xsmemo")
            Else
                Me.DtpXsrq.Value = g_Dwrq.Date.AddDays(-1)
                Me.TxtJe.Text = 0.0
                Me.TxtXsmemo.Text = ""
            End If
        End If
    End Sub

#End Region


#Region "���������¼�"

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If String.IsNullOrEmpty(Me.TxtKhdm.Text) Or String.IsNullOrEmpty(Me.TxtXh.Text) Then
            Return
        End If
        '������
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM ar_khyeb WHERE kjnd = ? AND khdm = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKhdm.Text).ToUpper
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("khyeb") IsNot Nothing Then
                rcDataSet.Tables("khyeb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "khyeb")
        Catch ex As Exception
            MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("khmx").Rows.Count <= 0 Then
            '�����¼�¼
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "INSERT INTO oe_xsd (djh,xh,xsrq,khdm,khmc,je,xsmemo) values (?,?,?,?,?,?,?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Trim(Me.TxtKhdm.Text).ToUpper
                rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = Me.TxtXh.Text
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = Me.DtpXsrq.Value
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKhdm.Text).ToUpper
                rcOleDbCommand.Parameters.Add("@khmc", OleDbType.VarChar, 50).Value = Me.LblKhmc.Text
                rcOleDbCommand.Parameters.Add("@je", OleDbType.Numeric, 18).Value = Me.TxtJe.Text
                rcOleDbCommand.Parameters.Add("@xsmemo", OleDbType.VarChar, 50).Value = Me.TxtXsmemo.Text
                rcOleDbCommand.ExecuteNonQuery()
                If rcDataSet.Tables("khyeb").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "UPDATE ar_khyeb SET qcje = qcje + ?,khmc = ? WHERE kjnd = ? AND khdm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@qcje", OleDbType.Numeric, 18).Value = Me.TxtJe.Text
                    rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
                    rcOleDbCommand.Parameters.Add("@khmc", OleDbType.VarChar, 50).Value = Me.LblKhmc.Text
                    rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKhdm.Text).ToUpper
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "INSERT INTO ar_khyeb (kjnd,khdm,khmc,qcje,idje) values (?,?,?,?,0.0)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
                    rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKhdm.Text).ToUpper
                    rcOleDbCommand.Parameters.Add("@khmc", OleDbType.VarChar, 50).Value = Me.LblKhmc.Text
                    rcOleDbCommand.Parameters.Add("@qcje", OleDbType.Numeric, 18).Value = Me.TxtJe.Text
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Catch ey As OleDbException
                    MsgBox("�������" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        Else
            '�޸ļ�¼
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "UPDATE oe_xsd SET xsrq = ?,khdm = ?,khmc = ?,je = ?,xsmemo = ? WHERE djh = ? AND xh = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@xsrq", OleDbType.Date, 8).Value = Me.DtpXsrq.Value
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKhdm.Text).ToUpper
                rcOleDbCommand.Parameters.Add("@khmc", OleDbType.VarChar, 50).Value = Me.LblKhmc.Text
                rcOleDbCommand.Parameters.Add("@je", OleDbType.Numeric, 18).Value = Me.TxtJe.Text
                rcOleDbCommand.Parameters.Add("@xsmemo", OleDbType.VarChar, 50).Value = Me.TxtXsmemo.Text
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Trim(Me.TxtKhdm.Text).ToUpper
                rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 4).Value = Me.TxtXh.Text
                rcOleDbCommand.ExecuteNonQuery()
                If rcDataSet.Tables("khyeb").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "UPDATE ar_khyeb SET qcje = qcje + ?,khmc = ? WHERE kjnd = ? AND khdm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@qcje", OleDbType.Numeric, 18).Value = Me.TxtJe.Text - rcDataSet.Tables("khmx").Rows(0).Item("je")
                    rcOleDbCommand.Parameters.Add("@khmc", OleDbType.VarChar, 50).Value = Me.LblKhmc.Text
                    rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
                    rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKhdm.Text).ToUpper
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "INSERT INTO ar_khyeb (kjnd,khdm,khmc,qcje,idje) values (?,?,?,?,0.0)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
                    rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKhdm.Text).ToUpper
                    rcOleDbCommand.Parameters.Add("@khmc", OleDbType.VarChar, 50).Value = Me.LblKhmc.Text
                    rcOleDbCommand.Parameters.Add("@qcje", OleDbType.Numeric, 18).Value = Me.TxtJe.Text '- rcDataSet.Tables("khmx").Rows(0).Item("je")
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Catch ey As OleDbException
                    MsgBox("�������" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        End If
        TxtKhdm.Text = ""
        LblKhmc.Text = ""
        TxtJe.Text = 0.0
        Me.TxtXsmemo.Text = ""
        Me.TxtKhdm.Focus()
    End Sub

#End Region

End Class