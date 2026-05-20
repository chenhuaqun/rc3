Imports System.io
Imports System.Data
Imports System.Data.OleDb
Imports System.Management
Imports System.Security.Cryptography
Imports System.Threading.Tasks
Imports System.Text

Module MdlMain
    Declare Function DogRead_Str Lib "Win32dll" Alias "DogRead" (ByVal DogBytes As Integer, ByVal DogAddr As Integer, ByVal DogData As String) As Integer

    '全局变量声明
    Public g_Module As String = ""
    Public g_Kjrq As Date = Now()
    Public g_Dwrq As Date = Now() '起用日期
    Public g_Kjqj As String = g_Kjrq.Year.ToString("0000") & g_Kjrq.Month.ToString("00") '会计期间
    Public g_User_Account As String = "ADMIN"
    Public g_User_DspName As String = "系统管理员"
    Public g_Dwdm As String = "0000"
    Public g_Dwmc As String = "杭州锐创软件有限公司"
    Public g_PrnDwmc As String = "杭州锐创软件有限公司"
    Public g_PrnDwmc_EN As String = "HANGZHOU RICHEN SOFTWARE CO,.LTD"
    Public g_Demo As Integer = 0 '试用版
    Public g_Wbdm As String = ""

    Public g_CpdmText As String = "物料编码"
    Public g_CpmcText As String = "物料描述"

    Public g_FormatSl As String = "N4" '数量小数位格式
    Public g_FormatSl0 As String = "0.0000;;#.#"
    Public g_FormatInt As String = "N0" '数量小数位格式
    Public g_FormatInt0 As String = "0;;#.#"
    Public g_FormatJe As String = "N2" '金额小数位格式
    Public g_FormatJe0 As String = "0.00;;#.#"
    Public g_FormatJe1 As String = "0.00;0.00;#.#"
    Public g_FormatDj As String = "N4" '单价小数位格式
    Public g_FormatDj0 As String = "0.0000;;#.#"
    Public g_FormatPer As String = "0.00%;;#.#%"

    '数据源信息
    Public PubStrDatabaseServer As String = "."
    Public PubStrDatabaseName As String = "RCSYSTEM"
    Public PubStrUserName As String = "SA"
    Public PubStrPassword As String = ""
    'MS_SQL
    Public sysOleDbConn As New OleDbConnection
    Public rcOleDbConn As New OleDbConnection
    Public sysConnectionString As String
    Public rcConnectionString As String

    <STAThread()>
    Sub Main()
        '检查新版本
        Dim sourceFileName As String = Path.Combine(Application.StartupPath, "update\rcerm.exe")
        Dim destFileName As String = Path.Combine(Application.StartupPath, "rcerm.exe")
        If File.Exists(destFileName) Then
            File.Delete(destFileName)
        End If
        If File.Exists(sourceFileName) Then
            File.Move(sourceFileName, destFileName)
            '升级
            System.Diagnostics.Process.Start(destFileName)
            Application.Exit()
        End If
        '读取数据源配置文件并解密
        Dim c As New models.rcCryptography
        Dim rcFileName As String = Path.Combine(Application.StartupPath, "richen.config")
        If Not File.Exists(rcFileName) Then
            Dim rcFrmDataSource As New models.FrmDataSource
            If Not rcFrmDataSource.ShowDialog() = DialogResult.OK Then
                Application.Exit()
            End If
        End If
        If Not File.Exists(rcFileName) Then
            MsgBox("运行系统，必须配置系统数据库信息！")
            Exit Sub
        End If
        Using rcStreamReader As StreamReader = File.OpenText(rcFileName)
            PubStrDatabaseServer = Trim(rcStreamReader.ReadLine)
            If PubStrDatabaseServer.Length <> 0 Then
                PubStrDatabaseServer = Trim(c.DeCryptography(PubStrDatabaseServer))
            Else
                PubStrDatabaseServer = ""
            End If
            PubStrDatabaseName = Trim(rcStreamReader.ReadLine)
            If PubStrDatabaseName.Length <> 0 Then
                PubStrDatabaseName = Trim(c.DeCryptography(PubStrDatabaseName))
            Else
                PubStrDatabaseName = ""
            End If
            PubStrUserName = Trim(rcStreamReader.ReadLine)
            If PubStrUserName.Length <> 0 Then
                PubStrUserName = Trim(c.DeCryptography(PubStrUserName))
            Else
                PubStrUserName = ""
            End If
            PubStrPassword = Trim(rcStreamReader.ReadLine)
            If PubStrPassword.Length <> 0 Then
                PubStrPassword = Trim(c.DeCryptography(PubStrPassword))
            Else
                PubStrPassword = ""
            End If
        End Using
        'SQL Server
        'sysConnectionString = "Provider=SQLOLEDB.1;OLE DB Services=-1;Data Source=" & PubStrDatabaseServer & ";Initial Catalog=" & PubStrDatabaseName & ";User ID=" & PubStrUserName & ";PWD=" & PubStrPassword 'Integrated Security=SSPI;
        'Orcal 9.i
        sysConnectionString = "Provider=OraOLEDB.Oracle.1;Persist Security Info=False;Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = " & PubStrDatabaseServer & ")(PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = " & PubStrDatabaseName & ")));User ID=" & PubStrUserName & ";Password=" & PubStrPassword ' &";Pooling = false" 'Integrated Security=SSPI;
        sysOleDbConn.ConnectionString = sysConnectionString
        '检查能否建立连接
        Try
            sysOleDbConn.Open()
        Catch ex As Exception
            MsgBox("对不起，数据库服务器连接不上。" & Chr(13) & "请稍后再试或与系统管理员联系。" & Chr(13) & Chr(13) & ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示信息")
            Application.Exit()
        Finally
            sysOleDbConn.Close()
        End Try
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        '操作员登陆
        Try
            '等待一秒
            System.Threading.Thread.Sleep(2000) ' 等待1秒(New TimeSpan(0, 0, 1)))
            'MsgBox("准备显示登录窗口")
            Dim rcFrmUserLogin As New FrmUserLogin
            If rcFrmUserLogin.ShowDialog() = DialogResult.OK Then
                Dim currentDeviceCode = GetDeviceCodeAsync().Result
                Dim activationFile = Path.Combine(Application.StartupPath, "license", "license.dat")

                If Not File.Exists(activationFile) Then
                    Dim result = MsgBox("未检测到许可证文件，请先注册和激活。", MsgBoxStyle.OkCancel + MsgBoxIcon.Question, "提示信息")
                    If result = MsgBoxResult.OK Then
                        Dim frmReg As New sys.FrmRegister
                        frmReg.ShowDialog()
                    End If
                    If Not File.Exists(activationFile) Then
                        MsgBox("未激活程序，将退出系统。", MsgBoxStyle.OkOnly + MsgBoxIcon.Warning, "提示信息")
                        Application.Exit()
                        Return
                    End If
                Else
                    Try
                        Dim content = File.ReadAllText(activationFile)
                        Dim parts = content.Split("|"c)
                        If parts.Length >= 1 AndAlso parts(0) <> currentDeviceCode Then
                            Dim result = MsgBox("检测到硬件变更，设备ID不匹配，请重新激活。", MsgBoxStyle.OkCancel + MsgBoxIcon.Warning, "提示信息")
                            If result = MsgBoxResult.OK Then
                                Dim frmReg As New sys.FrmRegister
                                frmReg.ShowDialog()
                            End If
                            If Not File.Exists(activationFile) Then
                                MsgBox("未激活程序，将退出系统。", MsgBoxStyle.OkOnly + MsgBoxIcon.Warning, "提示信息")
                                Application.Exit()
                                Return
                            End If
                        End If
                    Catch ex As Exception
                        MsgBox("读取许可证文件失败，请重新激活。", MsgBoxStyle.OkOnly + MsgBoxIcon.Warning, "提示信息")
                        Dim frmReg As New sys.FrmRegister
                        frmReg.ShowDialog()
                        If Not File.Exists(activationFile) Then
                            Application.Exit()
                            Return
                        End If
                    End Try
                End If

                Application.Run(New FrmMain)
            Else
                Application.Exit()
            End If
        Catch ex As Exception
            MsgBox("主程序异常：" & ex.Message)
            Application.Exit()
        End Try
    End Sub

    'Function getOeBegin(ByVal intYear As Integer, ByVal intMonth As Integer) As Date
    '    '取会计期间开始日期
    '    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '    Dim rcDataset As New DataSet
    '    '建立命令
    '    Dim rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '    Try
    '        rcOleDbConn.Open()
    '        rcOleDbCommand.Connection = rcOleDbConn
    '        rcOleDbCommand.CommandTimeout = 300
    '        rcOleDbCommand.CommandType = CommandType.Text
    '        rcOleDbCommand.CommandText = "SELECT OeBegin FROM rc_yj WHERE ny = ? "
    '        rcOleDbCommand.Parameters.Clear()
    '        rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = Replace(RSet(intYear, 4) & RSet(intMonth, 2), " ", "0")
    '        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
    '        If Not rcDataset.Tables("rc_yj") Is Nothing Then
    '            rcDataset.Tables("rc_yj").Clear()
    '        End If
    '        rcOleDbDataAdpt.Fill(rcDataset, "rc_yj")
    '    Catch ex As Exception
    '        MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
    '        Return Today
    '    Finally
    '        rcOleDbConn.Close()
    '    End Try
    '    If rcDataset.Tables("rc_yj").Rows.Count = 0 Then
    '        MsgBox("没有符合条件的数据。请检查会计期间设置。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
    '        Return Today
    '    Else
    '        Return rcDataset.Tables("rc_yj").Rows(0).Item("OeBegin")
    '    End If
    'End Function

    'Function getOeEnd(ByVal intYear As Integer, ByVal intMonth As Integer) As Date
    '    '取会计期间终止日期
    '    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '    Dim rcDataset As New DataSet
    '    '建立命令
    '    Dim rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '    Try
    '        rcOleDbConn.Open()
    '        rcOleDbCommand.Connection = rcOleDbConn
    '        rcOleDbCommand.CommandTimeout = 300
    '        rcOleDbCommand.CommandType = CommandType.Text
    '        rcOleDbCommand.CommandText = "SELECT OeEnd FROM rc_yj WHERE ny = ? "
    '        rcOleDbCommand.Parameters.Clear()
    '        rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = Replace(RSet(intYear, 4) & RSet(intMonth, 2), " ", "0")
    '        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
    '        If Not rcDataset.Tables("rc_yj") Is Nothing Then
    '            rcDataset.Tables("rc_yj").Clear()
    '        End If
    '        rcOleDbDataAdpt.Fill(rcDataset, "rc_yj")
    '    Catch ex As Exception
    '        MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
    '        Return Today
    '    Finally
    '        rcOleDbConn.Close()
    '    End Try
    '    If rcDataset.Tables("rc_yj").Rows.Count = 0 Then
    '        MsgBox("没有符合条件的数据。请检查会计期间设置。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
    '        Return Today
    '    Else
    '        Return rcDataset.Tables("rc_yj").Rows(0).Item("OeEnd")
    '    End If
    'End Function

    'Function getOeKjqj(ByVal dateRq As Date) As String
    '    '取会计期间
    '    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '    Dim rcDataset As New DataSet
    '    '建立命令
    '    Dim rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '    Try
    '        rcOleDbConn.Open()
    '        rcOleDbCommand.Connection = rcOleDbConn
    '        rcOleDbCommand.CommandTimeout = 300
    '        rcOleDbCommand.CommandType = CommandType.Text
    '        rcOleDbCommand.CommandText = "SELECT ny FROM rc_yj WHERE OeBegin <= ? and OeEnd >= ?"
    '        rcOleDbCommand.Parameters.Clear()
    '        rcOleDbCommand.Parameters.Add("@OeBegin", OleDbType.Date, 8).Value = dateRq
    '        rcOleDbCommand.Parameters.Add("@OeEnd", OleDbType.Date, 8).Value = dateRq
    '        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
    '        If Not rcDataset.Tables("rc_yj") Is Nothing Then
    '            rcDataset.Tables("rc_yj").Clear()
    '        End If
    '        rcOleDbDataAdpt.Fill(rcDataset, "rc_yj")
    '    Catch ex As Exception
    '        MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
    '        Return "200801"
    '    Finally
    '        rcOleDbConn.Close()
    '    End Try
    '    If rcDataset.Tables("rc_yj").Rows.Count = 0 Then
    '        MsgBox("没有符合条件的数据。请检查会计期间设置。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
    '        Return "200801"
    '    Else
    '        Return rcDataset.Tables("rc_yj").Rows(0).Item("ny")
    '    End If
    'End Function

    Function GetInvBegin(ByVal intYear As Integer, ByVal intMonth As Integer) As Date
        '取会计期间开始日期
        Dim rcOleDbDataAdpt As New OleDbDataAdapter
        Dim rcDataset As New DataSet
        '建立命令
        Dim rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT InvBegin FROM rc_yj WHERE ny = ? "
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = Replace(RSet(intYear, 4) & RSet(intMonth, 2), " ", "0")
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_yj") IsNot Nothing Then
                rcDataset.Tables("rc_yj").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_yj")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return Today
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_yj").Rows.Count = 0 Then
            MsgBox("没有符合条件的会计期间。请检查会计期间设置。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return Today
        Else
            Return rcDataset.Tables("rc_yj").Rows(0).Item("InvBegin")
        End If
    End Function

    Function GetInvEnd(ByVal intYear As Integer, ByVal intMonth As Integer) As Date
        '取会计期间终止日期
        Dim rcOleDbDataAdpt As New OleDbDataAdapter
        Dim rcDataset As New DataSet
        '建立命令
        Dim rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
        rcOleDbConn.Open()
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT InvEnd FROM rc_yj WHERE ny = ? "
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = Replace(RSet(intYear, 4) & RSet(intMonth, 2), " ", "0")
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_yj") IsNot Nothing Then
                rcDataset.Tables("rc_yj").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_yj")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return Today
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_yj").Rows.Count = 0 Then
            MsgBox("没有符合条件的会计期间。请检查会计期间设置。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return Today
        Else
            Return rcDataset.Tables("rc_yj").Rows(0).Item("InvEnd")
        End If
    End Function

    Function GetInvKjqj(ByVal dateRq As Date) As String
        '取会计期间
        Dim rcOleDbDataAdpt As New OleDbDataAdapter
        Dim rcDataset As New DataSet
        '建立命令
        Dim rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT ny FROM rc_yj WHERE InvBegin <= ? and InvEnd >= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@InvBegin", OleDbType.Date, 8).Value = dateRq
            rcOleDbCommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = dateRq
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_yj") IsNot Nothing Then
                rcDataset.Tables("rc_yj").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_yj")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return "200801"
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_yj").Rows.Count = 0 Then
            MsgBox("没有符合条件的数据。请检查会计期间设置。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return Today
        Else
            Return rcDataset.Tables("rc_yj").Rows(0).Item("ny")
        End If
    End Function

    'Function getArBegin(ByVal intYear As Integer, ByVal intMonth As Integer) As Date
    '    '取会计期间开始日期
    '    Dim rcOleDbDataAdpt As New OleDbDataAdapter
    '    Dim rcDataset As New DataSet
    '    '建立命令
    '    Dim rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '    rcOleDbConn.Open()
    '    rcOleDbCommand.Connection = rcOleDbConn
    '    rcOleDbCommand.CommandTimeout = 300
    '    rcOleDbCommand.CommandType = CommandType.Text
    '    Try
    '        rcOleDbCommand.CommandText = "SELECT ArBegin FROM rc_yj WHERE ny = ? "
    '        rcOleDbCommand.Parameters.Clear()
    '        rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = Replace(RSet(intYear, 4) & RSet(intMonth, 2), " ", "0")
    '        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
    '        If Not rcDataset.Tables("rc_yj") Is Nothing Then
    '            rcDataset.Tables("rc_yj").Clear()
    '        End If
    '        rcOleDbDataAdpt.Fill(rcDataset, "rc_yj")
    '    Catch ex As Exception
    '        MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
    '        Return Today
    '    Finally
    '        rcOleDbConn.Close()
    '    End Try
    '    If rcDataset.Tables("rc_yj").Rows.Count = 0 Then
    '        MsgBox("没有符合条件的数据。请检查会计期间设置。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
    '        Return Today
    '    Else
    '        Return rcDataset.Tables("rc_yj").Rows(0).Item("ArBegin")
    '    End If
    'End Function

    'Function getArEnd(ByVal intYear As Integer, ByVal intMonth As Integer) As Date
    '    '取会计期间终止日期
    '    Dim rcOleDbDataAdpt As New OleDbDataAdapter
    '    Dim rcDataset As New DataSet
    '    '建立命令
    '    Dim rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '    rcOleDbConn.Open()
    '    rcOleDbCommand.Connection = rcOleDbConn
    '    rcOleDbCommand.CommandTimeout = 300
    '    rcOleDbCommand.CommandType = CommandType.Text
    '    Try
    '        rcOleDbCommand.CommandText = "SELECT ArEnd FROM rc_yj WHERE ny = ? "
    '        rcOleDbCommand.Parameters.Clear()
    '        rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = Replace(RSet(intYear, 4) & RSet(intMonth, 2), " ", "0")
    '        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
    '        If Not rcDataset.Tables("rc_yj") Is Nothing Then
    '            rcDataset.Tables("rc_yj").Clear()
    '        End If
    '        rcOleDbDataAdpt.Fill(rcDataset, "rc_yj")
    '    Catch ex As Exception
    '        MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
    '        Return Today
    '    Finally
    '        rcOleDbConn.Close()
    '    End Try
    '    If rcDataset.Tables("rc_yj").Rows.Count = 0 Then
    '        MsgBox("没有符合条件的数据。请检查会计期间设置。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
    '        Return Today
    '    Else
    '        Return rcDataset.Tables("rc_yj").Rows(0).Item("ArEnd")
    '    End If
    'End Function

    'Function getArKjqj(ByVal dateRq As Date) As String
    '    '取会计期间
    '    Dim rcOleDbDataAdpt As New OleDbDataAdapter
    '    Dim rcDataset As New DataSet
    '    '表示要在数据源执行的 SQL 事务
    '    '建立命令
    '    Dim rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '    rcOleDbConn.Open()
    '    rcOleDbCommand.Connection = rcOleDbConn
    '    rcOleDbCommand.CommandTimeout = 300
    '    rcOleDbCommand.CommandType = CommandType.Text
    '    Try
    '        rcOleDbCommand.CommandText = "SELECT ny FROM rc_yj WHERE ArBegin <= ? and ArEnd >= ?"
    '        rcOleDbCommand.Parameters.Clear()
    '        rcOleDbCommand.Parameters.Add("@ArBegin", OleDbType.Date, 8).Value = dateRq
    '        rcOleDbCommand.Parameters.Add("@ArEnd", OleDbType.Date, 8).Value = dateRq
    '        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
    '        If Not rcDataset.Tables("rc_yj") Is Nothing Then
    '            rcDataset.Tables("rc_yj").Clear()
    '        End If
    '        rcOleDbDataAdpt.Fill(rcDataset, "rc_yj")
    '    Catch ex As Exception
    '        MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
    '        Return "200801"
    '    Finally
    '        rcOleDbConn.Close()
    '    End Try
    '    If rcDataset.Tables("rc_yj").Rows.Count = 0 Then
    '        MsgBox("没有符合条件的数据。请检查会计期间设置。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
    '        Return "200801"
    '    Else
    '        Return rcDataset.Tables("rc_yj").Rows(0).Item("ny")
    '    End If
    'End Function

    Function GetParaValue(ByVal ParaId As String, ByVal blnStrDbl As Boolean) As String
        '取参数值
        Dim rcOleDbDataAdpt As New OleDbDataAdapter
        Dim rcDataset As New DataSet
        '建立命令
        Dim rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_para WHERE paraid = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraid", OleDbType.VarChar, 30).Value = ParaId
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            If blnStrDbl Then
                Return ""
            Else
                Return 0
            End If
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_para").Rows.Count = 0 Then
            MsgBox("没有符合条件的数据。请设置" & ParaId, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            If blnStrDbl Then
                Return ""
            Else
                Return 0
            End If
        Else
            If blnStrDbl Then
                Return rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
            Else
                Return rcDataset.Tables("rc_para").Rows(0).Item("paradblvalue")
            End If
        End If
    End Function

    Public Function GetSpell(ByVal cnChar As String) As String
        Dim sarr As Byte() = System.Text.Encoding.Default.GetBytes(cnChar)
        Dim len As Integer = sarr.Length
        If len > 1 Then
            Dim array(2) As Byte
            array = System.Text.Encoding.Default.GetBytes(cnChar)
            Dim area As Integer = CShort(array(0) - Asc(ControlChars.NullChar))
            Dim pos As Integer = CShort(array(1) - Asc(ControlChars.NullChar))
            Dim code As Integer = area * 256 + pos
            Dim getPyChar As String = "*"
            If code >= 45217 And code <= 45252 Then
                getPyChar = "A"
            End If
            If code >= 45253 And code <= 45760 Then
                getPyChar = "B"
            End If
            If code >= 45761 And code <= 46317 Then
                getPyChar = "C"
            End If
            If code >= 46318 And code <= 46825 Then
                getPyChar = "D"
            End If
            If code >= 46826 And code <= 47009 Then
                getPyChar = "E"
            End If
            If code >= 47010 And code <= 47296 Then
                getPyChar = "F"
            End If
            If code >= 47297 And code <= 47613 Then
                getPyChar = "G"
            End If
            If code >= 47614 And code <= 48118 Then
                getPyChar = "H"
            End If
            If code >= 48119 And code <= 49061 Then
                getPyChar = "J"
            End If
            If code >= 49062 And code <= 49323 Then
                getPyChar = "K"
            End If
            If code >= 49324 And code <= 49895 Then
                getPyChar = "L"
            End If
            If code >= 49896 And code <= 50370 Then
                getPyChar = "M"
            End If
            If code >= 50371 And code <= 50613 Then
                getPyChar = "N"
            End If
            If code >= 50614 And code <= 50621 Then
                getPyChar = "O"
            End If
            If code >= 50622 And code <= 50905 Then
                getPyChar = "P"
            End If
            If code >= 50906 And code <= 51386 Then
                getPyChar = "Q"
            End If
            If code >= 51387 And code <= 51445 Then
                getPyChar = "R"
            End If
            If code >= 51446 And code <= 52217 Then
                getPyChar = "S"
            End If
            If code >= 52218 And code <= 52697 Then
                getPyChar = "T"
            End If
            If code >= 52698 And code <= 52979 Then
                getPyChar = "W"
            End If
            If code >= 52980 And code <= 53640 Then
                getPyChar = "X"
            End If
            If code >= 53641 And code <= 54480 Then
                getPyChar = "Y"
            End If
            If code >= 54481 And code <= 55289 Then
                getPyChar = "Z"
            End If
            Return getPyChar
        Else
            Return cnChar
        End If
    End Function

    Public Function GetChineseSpell(ByVal strText As String) As String
        Dim strtemp As String = ""
        Dim strlen As Integer = strText.Length
        Dim i As Integer
        For i = 0 To strlen - 1
            strtemp += getSpell(strText.Substring(i, 1))
        Next i
        Return strtemp
    End Function

    Public Function GetDeviceCodeAsync() As Task(Of String)
        Return Task.Run(Function()
                            Try
                                Dim sb As New StringBuilder()
                                Using searcher As New ManagementObjectSearcher("SELECT ProcessorId FROM Win32_Processor")
                                    For Each obj As ManagementObject In searcher.Get()
                                        sb.Append(obj("ProcessorId")?.ToString())
                                        Exit For
                                    Next
                                End Using
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
        Dim path = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RC3", "device.id")
        Dim dir = IO.Path.GetDirectoryName(path)
        If Not IO.Directory.Exists(dir) Then IO.Directory.CreateDirectory(dir)
        If IO.File.Exists(path) Then
            Return IO.File.ReadAllText(path)
        Else
            Dim guid = Guid.NewGuid().ToString("N")
            IO.File.WriteAllText(path, guid)
            Return guid
        End If
    End Function

    Private Function ComputeHash(input As String) As String
        Using sha As SHA256 = SHA256.Create()
            Dim bytes = Encoding.UTF8.GetBytes(input)
            Dim hash = sha.ComputeHash(bytes)
            Return BitConverter.ToString(hash).Replace("-", "").ToLower()
        End Using
    End Function
End Module
