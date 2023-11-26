Imports System.Data.OleDb

Public Class Form3
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction

    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        If Me.rcTimer.Enabled Then
            Me.rcTimer.Enabled = False
            Me.btnStart.Text = "开始"
        Else
            Me.rcTimer.Enabled = True
            Me.btnStart.Text = "停止"
        End If
    End Sub

    Private Sub rcTimer_Tick(sender As Object, e As EventArgs) Handles rcTimer.Tick
        '取需要发送的数据
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "select po_cgjh.djh,po_cgjh.xh,po_cgjh.jhrq,po_cgjh.srrq,po_cgjh.bmdm,po_cgjh.bmmc,po_cgjh.cpdm,rc_cpxx.cpmc,rc_cpxx.dw,po_cgjh.sl,rc_cpxx.cgdj from po_cgjh,rc_cpxx where po_cgjh.cpdm = rc_cpxx.cpdm and po_cgjh.bsenddingtalk <> 1 and po_cgjh.srrq >= sysdate-1 "
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("po_cgjh") IsNot Nothing Then
                rcDataset.Tables("po_cgjh").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "po_cgjh")
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Dim i As Integer
        For i = 0 To rcDataset.Tables("po_cgjh").Rows.Count - 1


            ''默认用锐创的ID
            'Dim strCorpId As String = "ding07ca8170052d3e7c35c2f4657eb6378f"
            'Dim strCorpSecret As String = "30-lK1YrUpsmz6ysYUPd30SWlZVVOFEShKa3HtWuFcA_4RxwnVUUBUIEMlFLTvzF"
            Dim strChatId As String = "chat62f80f55f531375b9a4e3a3d1b67469c"
            Try
                ''取钉钉corpid, corpsecret
                'Try
                '    rcOleDbConn.Open()
                '    rcOleDbCommand.Connection = rcOleDbConn
                '    rcOleDbCommand.CommandTimeout = 300
                '    rcOleDbCommand.CommandType = CommandType.Text
                '    rcOleDbCommand.CommandText = "SELECT paraid,parastrvalue,paradblvalue FROM rc_para WHERE SUBSTR(paraid,1,2) = '钉钉' Order by paraid"
                '    rcOleDbCommand.Parameters.Clear()
                '    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                '    If rcDataset.Tables("rc_para") IsNot Nothing Then
                '        rcDataset.Tables("rc_para").Clear()
                '    End If
                '    rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
                'Catch ex As Exception
                '    MsgBox("程序错误。" & Chr(13) & ex.Message)
                'Finally
                '    rcOleDbConn.Close()
                'End Try
                'If rcDataset.Tables("rc_para").Rows.Count = 3 Then
                '    If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                '        strChatId = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                '    End If
                '    If rcDataset.Tables("rc_para").Rows(1).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                '        strCorpId = rcDataset.Tables("rc_para").Rows(1).Item("parastrvalue")
                '    End If
                '    If rcDataset.Tables("rc_para").Rows(2).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                '        strCorpSecret = rcDataset.Tables("rc_para").Rows(2).Item("parastrvalue")
                '    End If
                'End If


                '钉钉测试
                'Dim request As System.Net.HttpWebRequest = System.Net.WebRequest.Create("https://oapi.dingtalk.com/gettoken" + "?" + "corpid=" & strCorpId & "&corpsecret=" & strCorpSecret)
                'request.Method = "GET"
                'Dim sr As System.IO.StreamReader = New System.IO.StreamReader(request.GetResponse().GetResponseStream)
                'Dim str As String = sr.ReadToEnd
                ''MsgBox(str)
                ''Dim aaa As ClsDdAccess_Token
                'Dim bbb As New Newtonsoft.Json.Linq.JObject
                'bbb = Newtonsoft.Json.JsonConvert.DeserializeObject(str)
                'Dim fff As Newtonsoft.Json.Linq.JObject
                'Dim eee As New Newtonsoft.Json.Linq.JArray
                'fff = CType(Newtonsoft.Json.JsonConvert.DeserializeObject(str), Newtonsoft.Json.Linq.JObject)
                'Dim msg As String = fff("access_token").ToString

                Dim ddd As String = ""
                ddd = "{" & Chr(34) & "chatid" & Chr(34) & ":" & Chr(34) & strChatId & Chr(34) & "," & Chr(34) & "msgtype" & Chr(34) & ":" & Chr(34) & "text" & Chr(34) & "," & Chr(34) & "text" & Chr(34) & ":{" & Chr(34) & "content" & Chr(34) & ":" & Chr(34) & "采购申请" & rcDataset.Tables("po_cgjh").Rows(i).Item("jhrq").ToString & "物料:(" & rcDataset.Tables("po_cgjh").Rows(i).Item("cpdm") & ")" & rcDataset.Tables("po_cgjh").Rows(i).Item("cpmc") & " 需采购数量:" & rcDataset.Tables("po_cgjh").Rows(i).Item("sl").ToString & rcDataset.Tables("po_cgjh").Rows(i).Item("dw") & "最近采购单价：" & rcDataset.Tables("po_cgjh").Rows(i).Item("cgdj").ToString & "请购部门:(" & rcDataset.Tables("po_cgjh").Rows(i).Item("bmdm") & ")" & rcDataset.Tables("po_cgjh").Rows(i).Item("bmmc") & Chr(34) & "}}"
                'MsgBox(ddd)
                '' create a request
                'Dim request1 As System.Net.HttpWebRequest = CType(System.Net.WebRequest.Create("https://oapi.dingtalk.com/chat/send?access_token=" + msg), System.Net.HttpWebRequest)
                'request1.KeepAlive = False
                'request1.ProtocolVersion = System.Net.HttpVersion.Version10
                'request1.Method = "POST"


                '' turn our request1 string into a byte stream
                Dim postBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(ddd)

                '' this is important - make sure you specify type this way
                'request1.ContentType = "application/json; charset=UTF-8"
                'request1.Accept = "application/json"
                'request1.ContentLength = postBytes.Length
                ''request1.CookieContainer = Cookies
                ''request1.UserAgent = currentUserAgent
                'Dim requestStream As System.IO.Stream = request1.GetRequestStream()

                '' now send it
                'requestStream.Write(postBytes, 0, postBytes.Length)
                'requestStream.Close()
                '' grab te response and print it out to the console along with the status code
                'Dim response As System.Net.HttpWebResponse = CType(request1.GetResponse(), System.Net.HttpWebResponse)
                'Dim rdr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
                'Dim result As String = rdr.ReadToEnd()
                ''MsgBox(result)

                '机器人发送
                Dim request2 As System.Net.HttpWebRequest = CType(System.Net.WebRequest.Create("https://oapi.dingtalk.com/robot/send?access_token=55fa5bce97bd28a5e8f66567589060d44b4fba74a5d983ec87224e3eb1ff056c"), System.Net.HttpWebRequest)
                request2.KeepAlive = False
                request2.ProtocolVersion = System.Net.HttpVersion.Version10
                request2.Method = "POST"
                request2.ContentType = "application/json; charset=UTF-8"
                request2.Accept = "application/json"
                request2.ContentLength = postBytes.Length
                Dim requestStream2 As System.IO.Stream = request2.GetRequestStream()

                ' now send it
                requestStream2.Write(postBytes, 0, postBytes.Length)
                requestStream2.Close()
                ' grab te response and print it out to the console along with the status code
                Dim response2 As System.Net.HttpWebResponse = CType(request2.GetResponse(), System.Net.HttpWebResponse)
                Dim rdr2 As System.IO.StreamReader = New System.IO.StreamReader(response2.GetResponseStream())
                Dim result2 As String = rdr2.ReadToEnd()
                'MsgBox(result2)


                '更新发送成功标志
                Try
                    rcOleDbConn.Open()
                    rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.Transaction = rcOleDbTrans
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    rcOleDbCommand.CommandText = "update po_cgjh set bsenddingtalk = 1 where xh = ? and djh = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = rcDataset.Tables("po_cgjh").Rows(i).Item("xh")
                    rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("po_cgjh").Rows(i).Item("djh")
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbTrans.Commit()
                Catch ex As Exception
                    Try
                        rcOleDbTrans.Rollback()
                        MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                    Catch ey As OleDbException
                        MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                    End Try
                    Return
                Finally
                    rcOleDbConn.Close()
                End Try

            Catch ex As Exception
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Threading.Thread.Sleep(5000)
        Next
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class