Imports System.Data.OleDb

Public Class FrmCpRepair
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '��ʾҪ������Դִ�е� SQL ����
    Dim rcOleDbTrans As OleDbTransaction
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

#Region "�ؼ��س����Ĵ���"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCpdm.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "���ϱ����¼�"

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
                    .paraTitle = "����"
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
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
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

    '#Region "�ֿ������¼�"

    '    Private Sub TxtCkdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCkdm.KeyDown
    '        Select Case e.KeyCode
    '            Case Keys.F3
    '                Dim rcFrm As New models.FrmF3KeyPress
    '                With rcFrm
    '                    .paraOleDbConn = rcOleDbConn
    '                    .paraTableName = "rc_ckxx"
    '                    .paraField1 = "ckdm"
    '                    .paraField2 = "ckmc"
    '                    .paraField3 = "cksm"
    '                    .paraTitle = "�ֿ�"
    '                    .paraOldValue = ""
    '                    .paraAddName = ""
    '                    If .ShowDialog = DialogResult.OK Then
    '                        TxtCkdm.Text = Trim(.paraField1)
    '                    End If
    '                End With
    '            Case Keys.Down
    '                SendKeys.Send("{TAB}")
    '            Case Keys.Up
    '                SendKeys.Send("+{TAB}")
    '        End Select
    '    End Sub

    '    Private Sub TxtCkdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCkdm.Validating
    '        If Not String.IsNullOrEmpty(Me.TxtCkdm.Text) Then
    '            Try
    '                rcOleDbConn.Open()
    '                rcOleDbCommand.Connection = rcOleDbConn
    '                rcOleDbCommand.CommandTimeout = 300
    '                rcOleDbCommand.CommandType = CommandType.Text
    '                rcOleDbCommand.CommandText = "SELECT * FROM rc_ckxx WHERE (ckdm = ?)"
    '                rcOleDbCommand.Parameters.Clear()
    '                rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(TxtCkdm.Text)
    '                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
    '                If Not rcDataSet.Tables("rc_ckxx") Is Nothing Then
    '                    Me.rcDataSet.Tables("rc_ckxx").Clear()
    '                End If
    '                rcOleDbDataAdpt.Fill(rcDataSet, "rc_ckxx")
    '            Catch ex As Exception
    '                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
    '                Return
    '            Finally
    '                rcOleDbConn.Close()
    '            End Try
    '            If rcDataSet.Tables("rc_ckxx").Rows.Count > 0 Then
    '                Me.TxtCkdm.Text = Trim(rcDataSet.Tables("rc_ckxx").Rows(0).Item("ckdm"))
    '            Else
    '                e.Cancel = True
    '            End If
    '        End If
    '    End Sub

    '#End Region

    Public Structure DdAccess_Token
        Public touser As String
        Public toparty As String
        Public agentid As String
        Public code As String
        Public msgtype As String
        Public text As String
    End Structure


    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        'Ĭ�����񴴵�ID
        Dim strCorpId As String = "ding07ca8170052d3e7c35c2f4657eb6378f"
        Dim strCorpSecret As String = "30-lK1YrUpsmz6ysYUPd30SWlZVVOFEShKa3HtWuFcA_4RxwnVUUBUIEMlFLTvzF"
        Dim strChatId As String = "chat62f80f55f531375b9a4e3a3d1b67469c"
        Try
            'ȡ����corpid,corpsecret
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT paraid,parastrvalue,paradblvalue FROM rc_para WHERE SUBSTR(paraid,1,2) = '����' Order by paraid"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_para") IsNot Nothing Then
                    rcDataset.Tables("rc_para").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message)
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_para").Rows.Count = 3 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    strChatId = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
                If rcDataset.Tables("rc_para").Rows(1).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    strCorpId = rcDataset.Tables("rc_para").Rows(1).Item("parastrvalue")
                End If
                If rcDataset.Tables("rc_para").Rows(2).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    strCorpSecret = rcDataset.Tables("rc_para").Rows(2).Item("parastrvalue")
                End If
            End If
            '��������
            'Dim ccc As New ClsDdAccess_Token
            'ccc.access_token = "1"
            'ccc.errcode = 0
            'ccc.errmsg = "����"
            'Dim ddd As String = ""
            'ddd = Newtonsoft.Json.JsonConvert.SerializeObject(ccc)
            'MsgBox(ddd)
            Dim request As System.Net.HttpWebRequest = System.Net.WebRequest.Create("https://oapi.dingtalk.com/gettoken" + "?" + "corpid=" & strCorpId & "&corpsecret=" & strCorpSecret)
            request.Method = "GET"
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(request.GetResponse().GetResponseStream)
            Dim str As String = sr.ReadToEnd
            'MsgBox(str)
            'Dim aaa As ClsDdAccess_Token
            Dim bbb As New Newtonsoft.Json.Linq.JObject
            bbb = Newtonsoft.Json.JsonConvert.DeserializeObject(str)
            Dim fff As Newtonsoft.Json.Linq.JObject
            Dim eee As New Newtonsoft.Json.Linq.JArray
            fff = CType(Newtonsoft.Json.JsonConvert.DeserializeObject(str), Newtonsoft.Json.Linq.JObject)
            Dim msg As String = fff("access_token").ToString
            'Dim ccc As New DdAccess_Token
            'ccc.touser = "091458425637665374"
            ''ccc.toparty = ""
            'ccc.agentid = "1"
            'ccc.code = "code"
            'ccc.msgtype = "text"
            'ccc.text = "{" & Chr(34) & "content" & Chr(34) & ":" & Chr(34) & "���ϱ���" & Me.TxtCpdm.Text & "���޸���" & Chr(34) & "}"
            'ddd = Newtonsoft.Json.JsonConvert.SerializeObject(ccc)
            'MsgBox(ddd)
            'request = System.Net.WebRequest.Create("https://oapi.dingtalk.com/message/sendByCode" + "?" + "access_token=" + msg + "&q=" + ddd)
            'request.Method = "POST"

            'sr = New System.IO.StreamReader(request.GetResponse().GetResponseStream)
            'MsgBox(sr.ReadToEnd)
            '{"touser":"@all","agentid":"4117797","msgtype":"text","text":{"content":"�������������"}} + "&units=metric"
            'Dim editedText As String = ddd.Replace(" ", "%20") '�ո��滻��%20
            ''��ҵ�Ự
            'Dim myHttpWebRequest = CType(System.Net.WebRequest.Create("https://oapi.dingtalk.com/message/sendByCode?access_token=" + msg), System.Net.HttpWebRequest) ' + "&q=" + editedText
            'myHttpWebRequest.ContentType = "text/json"
            'myHttpWebRequest.Method = "POST"
            ''myHttpWebRequest.Headers.Add("Authorization: Bearer <myauthcode>")
            'Dim streamWriter As New System.IO.StreamWriter(myHttpWebRequest.GetRequestStream())
            'streamWriter.Write(editedText)
            'streamWriter.Flush()

            'Dim myHttpWebResponse = CType(myHttpWebRequest.GetResponse(), System.Net.HttpWebResponse) & "," & Chr(34) & "agentid" & Chr(34) & ":" & Chr(34) & "93587844" & Chr(34)
            'Dim myWebSource As New System.IO.StreamReader(myHttpWebResponse.GetResponseStream())
            'Dim myPageSource As String = myWebSource.ReadToEnd()
            'MsgBox(myPageSource)

            Dim ddd As String = ""
            ddd = "{" & Chr(34) & "chatid" & Chr(34) & ":" & Chr(34) & strChatId & Chr(34) & "," & Chr(34) & "msgtype" & Chr(34) & ":" & Chr(34) & "text" & Chr(34) & "," & Chr(34) & "text" & Chr(34) & ":{" & Chr(34) & "content" & Chr(34) & ":" & Chr(34) & "���ϱ���" & Me.TxtCpdm.Text & "���޸���" & Chr(34) & "}}"
            'MsgBox(ddd)
            ' create a request
            Dim request1 As System.Net.HttpWebRequest = CType(System.Net.WebRequest.Create("https://oapi.dingtalk.com/chat/send?access_token=" + msg), System.Net.HttpWebRequest)
            request1.KeepAlive = False
            request1.ProtocolVersion = System.Net.HttpVersion.Version10
            request1.Method = "POST"


            ' turn our request1 string into a byte stream
            Dim postBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(ddd)

            ' this is important - make sure you specify type this way
            request1.ContentType = "application/json; charset=UTF-8"
            request1.Accept = "application/json"
            request1.ContentLength = postBytes.Length
            'request1.CookieContainer = Cookies
            'request1.UserAgent = currentUserAgent
            Dim requestStream As System.IO.Stream = request1.GetRequestStream()

            ' now send it
            requestStream.Write(postBytes, 0, postBytes.Length)
            requestStream.Close()


            ' grab te response and print it out to the console along with the status code
            Dim response As System.Net.HttpWebResponse = CType(request1.GetResponse(), System.Net.HttpWebResponse)
            Dim rdr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
            Dim result As String = rdr.ReadToEnd()
            MsgBox(result)

        Catch ex As Exception
            MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
        End Try

        If String.IsNullOrEmpty(Me.TxtCpdm.Text) Then
            MsgBox("���ϱ��벻��Ϊ�ա�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If

        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP3_CPREPAIR"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtCpdm.Text)
            'rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtCkdm.Text)
            rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
            rcOleDbCommand.ExecuteNonQuery()
            If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                    MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                    Return
                End If
            End If
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
        MsgBox("�ѳɹ�������ɡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
        Me.TxtCpdm.Text = ""
        Me.TxtCpdm.Focus()
        'Me.TxtCkdm.Text = ""

        'oe_xsd��������

        'po_rkd,inv_rkd���������������

        '���»�������

    End Sub
End Class