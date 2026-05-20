Imports System.Threading.Tasks
Imports System.Management
Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json

Public Class FrmRegister
    Private ReadOnly baseUrl As String = "https://richen.dpdns.org/api/"
    Private ReadOnly productName As String = "RC3企业管理系统"

    ' 窗体加载时自动获取设备码
    Private Async Sub FrmRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 1. 获取当前设备的硬件设备码（异步）
        Dim currentDeviceCode = Await GetDeviceCodeAsync()
        txtDeviceCodeActivate.Text = currentDeviceCode

        ' 2. 尝试读取本地保存的激活信息
        Dim activationFile = IO.Path.Combine(Application.StartupPath, "license", "license.dat")
        If IO.File.Exists(activationFile) Then
            Try
                Dim content = IO.File.ReadAllText(activationFile)
                Dim parts = content.Split("|"c)
                If parts.Length >= 3 Then
                    Dim savedDeviceCode = parts(0)
                    Dim savedLicenseKey = parts(1)
                    Dim activationTime = parts(2)

                    ' 3. 判断设备码是否一致
                    If savedDeviceCode = currentDeviceCode Then
                        ' 设备匹配，说明本机已激活
                        txtLicenseKey.Text = savedLicenseKey       ' 显示许可证密钥
                        ' 可选：显示激活时间（假设有一个 Label 控件名为 lblActivationTime）
                        lblActivationTime.Text = $"激活时间：{activationTime}"

                        ' 禁用激活按钮和注册按钮（已激活的设备无需再操作）
                        btnActivate.Enabled = False
                        btnActivate.Text = "已激活"
                        btnRegister.Enabled = False
                        btnRegister.Text = "已激活"

                        ' 可选：禁用邮箱和密码输入框（避免重复注册）
                        txtEmail.Enabled = False
                        txtPassword.Enabled = False

                        MessageBox.Show("本设备已激活，无需再次注册或激活。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        ' 设备码不一致，提示用户重新激活
                        MessageBox.Show("检测到硬件变更，请重新激活。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ' 清空许可证密钥输入框，让用户手动输入新的
                        txtLicenseKey.Clear()
                        ' 确保激活按钮可用
                        btnActivate.Enabled = True
                        btnActivate.Text = "激活"
                    End If
                End If
            Catch ex As Exception
                ' 读取失败时忽略（文件可能损坏）
                MessageBox.Show("读取激活信息失败，请重新激活。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub
    ' ==================== 注册 ====================
    Private Async Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        btnRegister.Enabled = False
        btnRegister.Text = "注册中..."

        Try
            ' 获取当前设备码（从激活区域读取，保证一致）
            Dim deviceCode = txtDeviceCodeActivate.Text.Trim()
            If String.IsNullOrEmpty(deviceCode) Then
                MessageBox.Show("无法获取设备码，请检查硬件或手动输入。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' 校验邮箱和密码
            If String.IsNullOrWhiteSpace(txtEmail.Text) Then
                MessageBox.Show("请输入邮箱地址。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If String.IsNullOrWhiteSpace(txtPassword.Text) Then
                MessageBox.Show("请输入密码。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' 构建注册请求体
            Dim data As New Dictionary(Of String, String)
            data.Add("device_code", deviceCode)
            data.Add("product", productName)
            data.Add("email", txtEmail.Text.Trim())
            data.Add("password", txtPassword.Text)

            Dim json = JsonConvert.SerializeObject(data)

            Using client As New HttpClient()
                Dim content = New StringContent(json, Encoding.UTF8, "application/json")
                Dim response = Await client.PostAsync($"{baseUrl}users/product-registration", content)
                Dim responseBody = Await response.Content.ReadAsStringAsync()

                If response.IsSuccessStatusCode Then
                    ' 解析响应（可选，通常包含消息和 license_key 但不需显示）
                    MessageBox.Show("注册成功！注册码已发送至您的邮箱，请查收。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ' 清空密码框（安全）
                    txtPassword.Clear()
                Else
                    MessageBox.Show($"注册失败！{vbCrLf}HTTP {response.StatusCode}{vbCrLf}{responseBody}", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show($"注册时发生错误：{ex.Message}", "异常", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            btnRegister.Enabled = True
            btnRegister.Text = "注册"
        End Try
    End Sub

    ' ==================== 激活 ====================
    Private Async Sub btnActivate_Click(sender As Object, e As EventArgs) Handles btnActivate.Click
        btnActivate.Enabled = False
        btnActivate.Text = "激活中..."

        Try
            Dim deviceCode = txtDeviceCodeActivate.Text.Trim()
            Dim licenseKey = txtLicenseKey.Text.Trim()

            If String.IsNullOrEmpty(deviceCode) Then
                MessageBox.Show("请输入设备码。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If String.IsNullOrEmpty(licenseKey) Then
                MessageBox.Show("请输入从邮箱收到的许可证密钥。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' 构建激活请求体
            Dim data As New Dictionary(Of String, String)
            data.Add("device_code", deviceCode)
            data.Add("license_key", licenseKey)
            data.Add("product", productName)

            Dim json = JsonConvert.SerializeObject(data)

            Using client As New HttpClient()
                Dim content = New StringContent(json, Encoding.UTF8, "application/json")
                Dim response = Await client.PostAsync($"{baseUrl}users/activate", content)
                Dim responseBody = Await response.Content.ReadAsStringAsync()

                If response.IsSuccessStatusCode Then
                    MessageBox.Show("产品激活成功！本设备已获得授权。", "激活成功", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ' 可选：保存激活状态到本地，避免重复激活
                    SaveActivationInfo(deviceCode, licenseKey)
                Else
                    MessageBox.Show($"激活失败！{vbCrLf}HTTP {response.StatusCode}{vbCrLf}{responseBody}", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show($"激活时发生错误：{ex.Message}", "异常", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            btnActivate.Enabled = True
            btnActivate.Text = "激活"
        End Try
    End Sub

    ' 保存激活信息（可选）
    Private Sub SaveActivationInfo(deviceCode As String, licenseKey As String)
        Dim saveDir = IO.Path.Combine(Application.StartupPath, "license")
        If Not IO.Directory.Exists(saveDir) Then IO.Directory.CreateDirectory(saveDir)
        Dim infoFile = IO.Path.Combine(saveDir, "license.dat")
        Dim content = $"{deviceCode}|{licenseKey}|{DateTime.Now:yyyy-MM-dd HH:mm:ss}"
        IO.File.WriteAllText(infoFile, content)
    End Sub

    ' ==================== 设备码获取函数（保持不变） ====================
    Private Function GetDeviceCodeAsync() As Task(Of String)
        Return Task.Run(Function()
                            Try
                                Dim sb As New StringBuilder()
                                ' CPU ID
                                Using searcher As New ManagementObjectSearcher("SELECT ProcessorId FROM Win32_Processor")
                                    For Each obj As ManagementObject In searcher.Get()
                                        sb.Append(obj("ProcessorId")?.ToString())
                                        Exit For
                                    Next
                                End Using
                                ' 主板序列号
                                Using searcher As New ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard")
                                    For Each obj As ManagementObject In searcher.Get()
                                        sb.Append(obj("SerialNumber")?.ToString())
                                        Exit For
                                    Next
                                End Using
                                If sb.Length = 0 Then
                                    Dim mac = GetMacAddress()
                                    If Not String.IsNullOrEmpty(mac) Then
                                        sb.Append(mac)
                                    Else
                                        sb.Append(GetFallbackDeviceId())
                                    End If
                                End If
                                Return ComputeHash(sb.ToString())
                            Catch ex As Exception
                                Return "DEVICE_UNKNOWN"
                            End Try
                        End Function)
    End Function

    Private Function GetMacAddress() As String
        Try
            Using searcher As New ManagementObjectSearcher("SELECT MACAddress, NetEnabled FROM Win32_NetworkAdapter WHERE NetEnabled = True")
                For Each obj As ManagementObject In searcher.Get()
                    Dim mac = obj("MACAddress")?.ToString()
                    If Not String.IsNullOrEmpty(mac) Then
                        Return mac.Replace(":", "").ToUpper()
                    End If
                Next
            End Using
        Catch
        End Try
        Return String.Empty
    End Function

    Private Function GetFallbackDeviceId() As String
        Dim path = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "YourAppName", "device.id")
        Dim dir = IO.Path.GetDirectoryName(path)
        If Not IO.Directory.Exists(dir) Then IO.Directory.CreateDirectory(dir)
        If IO.File.Exists(path) Then
            Return IO.File.ReadAllText(path)
        Else
            Dim guid = guid.NewGuid().ToString("N")
            IO.File.WriteAllText(path, guid)
            Return guid
        End If
    End Function

    Private Function ComputeHash(input As String) As String
        Using sha As System.Security.Cryptography.SHA256 = System.Security.Cryptography.SHA256.Create()
            Dim bytes = Encoding.UTF8.GetBytes(input)
            Dim hash = sha.ComputeHash(bytes)
            Return BitConverter.ToString(hash).Replace("-", "").ToLower()
        End Using
    End Function

    Private Sub LinkLabelRegister_Click(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelRegister.LinkClicked
        ' 替换为你的注册页面网址
        Dim url As String = "https://richen.dpdns.org/auth?tab=register"

        Try
            ' 打开系统默认浏览器
            Process.Start(url)
        Catch ex As Exception
            ' 备用方法：某些环境下 Process.Start 可能失败，使用此方法
            Try
                Process.Start("explorer.exe", url)
            Catch ex2 As Exception
                MessageBox.Show("无法打开浏览器，请手动访问：" & url, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Try

        ' 可选：改变链接颜色表示已访问
        LinkLabelRegister.LinkVisited = True
    End Sub
End Class