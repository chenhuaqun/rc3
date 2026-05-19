Imports System.IO
Imports System.Net
Imports System.Text

Public Class NcServiceClient
    ''' <summary>
    ''' 向用友NC服务接口提交XML数据
    ''' </summary>
    ''' <param name="xmlContent">要提交的完整XML字符串</param>
    ''' <param name="url">NC服务地址，例如 http://10.2.3.53:9999/service/XChangeServlet?account=DMEGE&groupcode=DMEGC</param>
    ''' <param name="username">可选：认证用户名</param>
    ''' <param name="password">可选：认证密码</param>
    ''' <returns>服务器返回的响应内容</returns>
    Public Shared Function PostXmlToNc(xmlContent As String, url As String, Optional username As String = Nothing, Optional password As String = Nothing) As String
        Dim request As HttpWebRequest = Nothing
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader = Nothing

        Try
            ' 创建HTTP请求
            request = DirectCast(WebRequest.Create(url), HttpWebRequest)
            request.Method = "POST"
            request.ContentType = "application/xml" ' 关键：设置内容类型为XML:cite[3]:cite[4]
            request.Timeout = 300000 ' 设置超时时间（5分钟）

            ' 如果提供了用户名和密码，设置网络凭证
            If Not String.IsNullOrEmpty(username) AndAlso Not String.IsNullOrEmpty(password) Then
                request.Credentials = New NetworkCredential(username, password)
            End If

            ' 将XML字符串转换为字节数组
            Dim byteData As Byte() = Encoding.UTF8.GetBytes(xmlContent)
            request.ContentLength = byteData.Length

            ' 写入请求数据流
            Using requestStream As Stream = request.GetRequestStream()
                requestStream.Write(byteData, 0, byteData.Length)
            End Using

            ' 获取服务器响应
            response = DirectCast(request.GetResponse(), HttpWebResponse)
            Using responseStream As Stream = response.GetResponseStream()
                reader = New StreamReader(responseStream, Encoding.UTF8)
                Dim responseText As String = reader.ReadToEnd()
                Return responseText
            End Using

        Catch ex As WebException
            ' 处理网络异常，尝试读取错误响应
            If ex.Response IsNot Nothing Then
                Using errorResponse As WebResponse = ex.Response
                    Using errorReader As New StreamReader(errorResponse.GetResponseStream())
                        Dim errorText As String = errorReader.ReadToEnd()
                        Throw New Exception($"NC服务调用失败 (HTTP {DirectCast(ex.Response, HttpWebResponse).StatusCode}): {errorText}", ex)
                    End Using
                End Using
            Else
                Throw New Exception("网络连接异常: " & ex.Message, ex)
            End If
        Finally
            ' 确保资源被释放
            reader?.Dispose()
            response?.Close()
        End Try
    End Function
End Class