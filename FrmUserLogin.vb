Imports System.Data.OleDb
Public Class FrmUserLogin
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '��������
    ReadOnly rcOleDbCommand As New OleDbCommand '= rcOleDbConn.CreateCommand()

    Private Sub TxtUser_Account_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUser_Account.KeyPress, TxtUser_PWD.KeyPress, CmbDwmc.KeyPress, DtpKjrq.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                e.Handled = True
        End Select
    End Sub

    Private Sub TxtUser_Account_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtUser_Account.Validating

        'ȡ���ױ���
        If Not String.IsNullOrEmpty(Me.TxtUser_Account.Text) Then
            Try
                sysOleDbConn.Open()
                rcOleDbCommand.Connection = sysOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT dwdm,('('|| TRIM(dwdm) || ')' || dwmc) AS dwmc,rc_dwdm.parentid,rc_dwdm.host,rc_dwdm.servicename,rc_dwdm.userid,rc_dwdm.userpwd,rc_dwdm.dwrq FROM rc_dwdm,rc_userqx WHERE TRIM(rc_dwdm.dwdm) =  rc_userqx.code AND rc_userqx.righttype = 'DWDM' AND rc_userqx.user_account = ? Order by rc_dwdm.dwdm"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@user_account", OleDbType.VarChar, 30).Value = Trim(Me.TxtUser_Account.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_dwdm") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_dwdm").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_dwdm")
            Catch ex As Exception
                MsgBox("�������1��" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                sysOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_dwdm").Rows.Count > 0 Then
                BindDropDownList(Me.CmbDwmc, rcDataset.Tables("rc_dwdm"), "dwdm", "dwmc")
            End If
        End If
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If Me.CmbDwmc.SelectedIndex > -1 Then
            '��λ����
            g_Dwdm = Me.CmbDwmc.SelectedValue.ToString
            g_Dwmc = rcDataset.Tables("rc_dwdm").Rows(Me.CmbDwmc.SelectedIndex).Item("dwmc")
            g_PrnDwmc = g_Dwmc
            '��������˶�
            Try
                sysOleDbConn.Open()
                rcOleDbCommand.Connection = sysOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                'ȡ����
                rcOleDbCommand.CommandText = "SELECT User_Account,User_PWD,User_DspName FROM rc_users WHERE User_Account = '" & Trim(TxtUser_Account.Text).ToUpper & "'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_users") IsNot Nothing Then
                    rcDataset.Tables("rc_users").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_users")
            Catch ex As Exception
                MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                sysOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_users").Rows.Count = 0 Then
                MsgBox("�ò���Ա�����ڡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
                Return
            Else
                '������
                If rcDataset.Tables("rc_users").Rows(0).Item("User_PWD").GetType.ToString = "System.DBNull" Then
                    rcDataset.Tables("rc_users").Rows(0).Item("User_PWD") = ""
                End If
                Dim c As New models.rcCryptography
                If Not c.DeCryptography(Trim(rcDataset.Tables("rc_users").Rows(0).Item("User_PWD"))) = Trim(TxtUser_PWD.Text) Then
                    MsgBox("�������", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
                    Return
                Else
                    g_User_Account = Trim(TxtUser_Account.Text).ToUpper
                    g_User_DspName = rcDataset.Tables("rc_users").Rows(0).Item("User_DspName")
                    'rcDataset.Tables("rc_dwdm").Rows(Me.CmbDwmc.SelectedIndex).Item("host")
                    rcOleDbConn.ConnectionString = "Provider=OraOLEDB.Oracle.1;Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = " & rcDataset.Tables("rc_dwdm").Rows(Me.CmbDwmc.SelectedIndex).Item("host") & ")(PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = " & rcDataset.Tables("rc_dwdm").Rows(Me.CmbDwmc.SelectedIndex).Item("servicename") & ")));User ID=" & rcDataset.Tables("rc_dwdm").Rows(Me.CmbDwmc.SelectedIndex).Item("userid") & ";Password=" & rcDataset.Tables("rc_dwdm").Rows(Me.CmbDwmc.SelectedIndex).Item("userpwd") & ";Pooling = false"
                    If g_Dwdm = "999" Then
                        rcOleDbConn.ConnectionString = sysOleDbConn.ConnectionString
                    End If
                    g_Dwrq = GetInvBegin(Mid(rcDataset.Tables("rc_dwdm").Rows(Me.CmbDwmc.SelectedIndex).Item("dwrq"), 1, 4), Mid(rcDataset.Tables("rc_dwdm").Rows(Me.CmbDwmc.SelectedIndex).Item("dwrq"), 5, 2))
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                End If
            End If
            'ȡOEģ����㵥λ���û���ڼ�
            g_Kjrq = Me.DtpKjrq.Value
            g_Kjqj = GetInvKjqj(g_Kjrq)
            Try
                'ȡ���ݴ�ӡ��̧ͷʹ�õĵ�λ����
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT parastrvalue FROM rc_para WHERE paraid = '���ݴ�ӡ��̧ͷʹ�õĵ�λ����'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_para") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_para").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
                If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                    If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                        g_PrnDwmc = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                    End If
                End If
                rcOleDbCommand.CommandText = "SELECT parastrvalue FROM rc_para WHERE paraid = '���ݴ�ӡ�е�λ����Ӣ��'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_para") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_para").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
                If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                    If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                        g_PrnDwmc_EN = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                    End If
                End If
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message)
            Finally
                rcOleDbConn.Close()
            End Try
        End If
    End Sub

    Private Sub FrmUserLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Label2.Text = "�汾��" & System.Diagnostics.FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion.ToString
    End Sub
End Class