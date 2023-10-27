Imports System.IO
Imports System.Data.OleDb
Imports System.Threading
Imports System.ComponentModel

Public Class FrmMain

    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As New OleDbCommand

    Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If System.IO.File.Exists(Application.StartupPath + "\images\" + Now.Year.ToString + Now.Month.ToString.PadLeft(2, "0") + ".jpg") Then
        '    Me.BackgroundImage = System.Drawing.Image.FromFile(Application.StartupPath + "\images\" + Now.Year.ToString + Now.Month.ToString.PadLeft(2, "0") + ".jpg")
        '    Me.BackgroundImageLayout = ImageLayout.Stretch
        'Else
        If System.IO.File.Exists(Application.StartupPath + "\images\rc01.jpg") Then
            Me.BackgroundImage = System.Drawing.Image.FromFile(Application.StartupPath + "\images\rc01.jpg")
            Me.BackgroundImageLayout = ImageLayout.Stretch
        End If
        'End If
        '赋值
        Me.ToolStripStatusLabel2.Text = "单位：" + g_Dwmc
        Me.ToolStripStatusLabel3.Text = "操作员：" + g_User_DspName
        Me.ToolStripStatusLabel4.Text = "登陆日期：" & g_Kjrq.ToLongDateString
        '取操作员的角色
        Try
            sysOleDbConn.Open()
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT rc_users.user_dwdm,rc_users.user_account,rc_userinrole.roleid FROM rc_users,rc_userinrole WHERE rc_users.user_account = rc_userinrole.user_account AND rc_users.user_account = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@USER_Account", OleDbType.VarChar, 30).Value = g_User_Account
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_userinrole") IsNot Nothing Then
                rcDataSet.Tables("rc_userinrole").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_userinrole")
        Catch ex As Exception
            MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End
        Finally
            sysOleDbConn.Close()
        End Try
        If rcDataSet.Tables("rc_userinrole").Rows.Count <= 0 Then
            MsgBox("您没有操作权限，请与系统管理员联系。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End
        End If
        Dim i As Integer
        For i = 0 To rcDataSet.Tables("rc_userinrole").Rows.Count - 1
            '取角色权限(角色权限为并且的关系)
            Try
                sysOleDbConn.Open()
                rcOleDbCommand.Connection = sysOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT rc_menu.mnuiname FROM rc_roleqx,rc_menu WHERE rc_roleqx.roleid = ? AND rc_menu.mnuiown = 'RC3' AND rc_roleqx.righttype = 'RC3' AND rc_roleqx.code = rc_menu.mnuiid ORDER BY rc_menu.mnuiid"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@roleid", OleDbType.VarChar, 12).Value = rcDataSet.Tables("rc_userinrole").Rows(i).Item("roleid")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_roleqx") IsNot Nothing Then
                    rcDataSet.Tables("rc_roleqx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_roleqx")
            Catch ex As Exception
                MsgBox("程序错误2。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End
            Finally
                sysOleDbConn.Close()
            End Try
            Dim j As Integer
            For j = 0 To rcDataSet.Tables("rc_roleqx").Rows.Count - 1
                Dim t As Type = Me.GetType
                Dim f As System.Reflection.FieldInfo = t.GetField("_" & Trim(rcDataSet.Tables("rc_roleqx").Rows(j).Item("mnuiname")), System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Public)
                If f IsNot Nothing Then
                    Dim itemMenu As ToolStripMenuItem = CType(f.GetValue(Me), ToolStripMenuItem)
                    itemMenu.Visible = True
                End If
            Next
        Next
        If g_User_Account = "ADMIN" Then
            '系统管理员
            '取所有菜单
            Try
                sysOleDbConn.Open()
                rcOleDbCommand.Connection = sysOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT rc_menu.mnuiname FROM rc_menu WHERE rc_menu.mnuiown = 'RC3' ORDER BY rc_menu.mnuiid"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_roleqx") IsNot Nothing Then
                    rcDataSet.Tables("rc_roleqx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_roleqx")
            Catch ex As Exception
                MsgBox("程序错误5。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End
            Finally
                sysOleDbConn.Close()
            End Try
            Dim j As Integer
            For j = 0 To rcDataSet.Tables("rc_roleqx").Rows.Count - 1
                Dim t As Type = Me.GetType
                Dim f As System.Reflection.FieldInfo = t.GetField("_" & Trim(rcDataSet.Tables("rc_roleqx").Rows(j).Item("mnuiname")), System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Public)
                If f IsNot Nothing Then
                    Dim itemMenu As ToolStripMenuItem = CType(f.GetValue(Me), ToolStripMenuItem)
                    itemMenu.Visible = True
                End If
            Next
        End If

        Me.ToolStripStatusLabel1.Text = "欢迎使用。"

        For i = 0 To Me.MenuStripMain.Items.Count - 1
            Dim dc As ToolStripMenuItem = Me.MenuStripMain.Items(i)
            If Not SetSubItemVisible(dc) Then
                dc.Visible = False
            End If
        Next


        'sysoledbconn.ConnectionString = strSysConnectionString

        BackgroundWorkerMain.RunWorkerAsync()
    End Sub

    Private Sub FrmMain_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Me.MdiChildren.Length > 0 Then
            e.Cancel = True
            Return
        End If
        If MsgBox("您真的要退出系统吗？", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "提示信息") = MsgBoxResult.Yes Then
            Application.Exit()
        Else
            e.Cancel = True
        End If
    End Sub


#Region "下载文件"

    Private Sub BackgroundWorkerMain_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorkerMain.DoWork
        ' Get the BackgroundWorker object that raised this event.
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
        UpdateEvent(worker, e)
    End Sub

    Private Sub BackgroundWorkerMain_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorkerMain.RunWorkerCompleted
        Me.ToolStripStatusLabel1.Text = "下载完成!"
        If sysOleDbConn.State = ConnectionState.Open Then
            sysOleDbConn.Close()
        End If
    End Sub

    Private Sub UpdateEvent(ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs)
        Try
            sysOleDbConn.Open()
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM (SELECT filever FROM rc_file ORDER BY filever Desc) WHERE ROWNUM <= 1"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_file") IsNot Nothing Then
                rcDataset.Tables("rc_file").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_file")
        Catch ex As Exception
            MsgBox("程序错误6。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            sysOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_file").Rows.Count > 0 Then
            '分析升级文件
            '存储更新XML文件
            '保存设置
            Dim rcStreamWriter As System.IO.StreamWriter
            Dim oldXml As New System.Xml.XmlDocument
            If Not System.IO.File.Exists(Application.StartupPath & "\UpdateVersion.XML") Then
                '写xml文件
                rcStreamWriter = System.IO.File.CreateText(Application.StartupPath & "\UpdateVersion.XML")
                rcStreamWriter.WriteLine("<?xml version=""1.0"" encoding=""utf-8"" ?> ")
                rcStreamWriter.WriteLine("<product>")
                rcStreamWriter.WriteLine("<version>1.0</version>")
                rcStreamWriter.WriteLine("</product>")
                rcStreamWriter.Close()
            End If
            oldXml.Load(CurDir() & "\" & "UpdateVersion.XML")
            If oldXml.SelectSingleNode("product").SelectSingleNode("version").InnerText <> rcDataset.Tables("rc_file").Rows(0).Item("filever") Then
                sysOleDbConn.Open()
                rcOleDbCommand.Connection = sysOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                Try
                    rcOleDbCommand.CommandText = "SELECT * FROM (SELECT fname,filecontent,filever FROM rc_file ORDER BY filever Desc) WHERE ROWNUM <= 1"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("rc_file") IsNot Nothing Then
                        rcDataset.Tables("rc_file").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "rc_file")
                Catch ex As Exception
                    MsgBox("程序错误7。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                    Return
                Finally
                    sysOleDbConn.Close()
                End Try
                Dim s As String
                s = Application.StartupPath & "\update\" & rcDataset.Tables("rc_file").Rows(0).Item("fname")
                If IO.File.Exists(s) Then
                    IO.File.Delete(s)
                End If
                Dim size() As Byte = rcDataset.Tables("rc_file").Rows(0).Item("filecontent")
                Dim fs As IO.FileStream
                fs = New IO.FileStream(s, IO.FileMode.CreateNew)
                fs.Write(size, 0, size.Length - 0)
                fs.Close()
            End If
            '存储更新XML文件
            '保存设置
            If System.IO.File.Exists(Application.StartupPath & "\UpdateVersion.XML") Then
                System.IO.File.Delete(Application.StartupPath & "\UpdateVersion.XML")
            End If
            '写xml文件
            'Dim rcStreamWriter As System.IO.StreamWriter
            rcStreamWriter = System.IO.File.CreateText(Application.StartupPath & "\UpdateVersion.XML")
            rcStreamWriter.WriteLine("<?xml version=""1.0"" encoding=""utf-8"" ?> ")
            rcStreamWriter.WriteLine("<product>")
            rcStreamWriter.WriteLine("<version>" & Trim(rcDataset.Tables("rc_file").Rows(0).Item("filever")) & "</version>")
            rcStreamWriter.WriteLine("</product>")
            rcStreamWriter.Close()
        End If
    End Sub

#End Region

    '物料类别信息设置
    Private Sub MnuiCplbxx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCplbxx.Click
        AddLog(Me.MnuiCplbxx.Text)
        Dim rcFrm As New FrmCplbxx
        With rcFrm
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料组设置
    Private Sub MnuiCpGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCpGroup.Click
        AddLog(Me.MnuiCpGroup.Text)
        Dim rcFrm As New FrmCpGroup
        With rcFrm
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料信息设置
    Private Sub MnuiCpxx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCpxx.Click
        AddLog(Me.MnuiCpxx.Text)
        Dim rcFrm As New FrmCpxx
        With rcFrm
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料清单设置
    Private Sub MnuiBom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiBom.Click
        AddLog(Me.MnuiBom.Text)
        Dim rcFrm As New FrmBom
        With rcFrm
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '客户基本分类信息设置
    Private Sub MnuiKhlbxx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiKhlbxx.Click
        AddLog(Me.MnuiKhlbxx.Text)
        Dim rcFrm As New FrmKhlbxx
        With rcFrm
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '客户销售分类信息设置
    Private Sub MnuiKhXslb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiKhXslb.Click
        AddLog(Me.MnuiKhXslb.Text)
        Dim rcFrm As New FrmKhXslbxx
        With rcFrm
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '客户信息设置
    Private Sub MnuiKhxx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiKhxx.Click
        AddLog(Me.MnuiKhxx.Text)
        Dim rcFrm As New FrmKhxx
        With rcFrm
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '客户收货地址管理
    Private Sub MnuiKhshdz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiKhshdz.Click
        AddLog(Me.MnuiKhshdz.Text)
        Dim rcFrm As New FrmKhshdzxx
        With rcFrm
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    '客户专管业务员设置
    Private Sub MnuiKhzyxx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiKhzyxx.Click
        AddLog(Me.MnuiKhzyxx.Text)
        Dim rcFrm As New FrmKhzyxx
        With rcFrm
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    '供应商类别信息设置
    Private Sub MnuiCslbxx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCslbxx.Click
        AddLog(Me.MnuiCslbxx.Text)
        Dim rcFrm As New FrmCslbxx
        With rcFrm
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '供应商信息设置
    Private Sub MnuiCsxx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCsxx.Click
        AddLog(Me.MnuiCsxx.Text)
        Dim rcFrm As New FrmCsxx
        With rcFrm
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '部门信息设置
    Private Sub MnuiBmxx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiBmxx.Click
        AddLog(Me.MnuiBmxx.Text)
        Dim rcFrm As New FrmBmxx
        With rcFrm
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '职员信息设置
    Private Sub MnuiZyxx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiZyxx.Click
        AddLog(Me.MnuiZyxx.Text)
        Dim rcFrm As New FrmZyxx
        With rcFrm
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '仓库信息设置
    Private Sub MnuiCkxx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCkxx.Click
        AddLog(Me.MnuiCkxx.Text)
        Dim rcFrm As New FrmCkxx
        With rcFrm
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '成本域设置
    Private Sub MnuiCostRegion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCostRegion.Click
        AddLog(Me.MnuiCostRegion.Text)
        Dim rcFrm As New FrmCostRegionxx
        With rcFrm
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '计量单位设置
    Private Sub MnuiJldwxx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiJldwxx.Click
        AddLog(Me.MnuiJldwxx.Text)
        Dim rcFrm As New FrmJldwxx
        With rcFrm
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '生产工序信息设置
    Private Sub MnuiGxxx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiGxxx.Click
        AddLog(Me.MnuiGxxx.Text)
        Dim rcFrm As New FrmGxxx
        With rcFrm
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '科目信息设置
    Private Sub MnuiKmxx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiKmxx.Click
        AddLog(Me.MnuiKmxx.Text)
        Dim rcFrm As New FrmKmxx
        With rcFrm
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '结算方式信息设置
    Private Sub MnuiJsfsxx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiJsfsxx.Click
        AddLog(Me.MnuiJsfsxx.Text)
        Dim rcFrm As New FrmJsfsxx
        With rcFrm
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '币种信息设置
    Private Sub MnuiWbxx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiWbxx.Click
        AddLog(Me.MnuiWbxx.Text)
        Dim rcFrm As New FrmWbxx
        With rcFrm
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料库存账龄设置
    Private Sub MnuiKczlxx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiKcZlxx.Click
        AddLog(Me.MnuiKcZlxx.Text)
        Dim rcFrm As New FrmKcZlxx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '逾期收款倒扣比率设置
    Private Sub MnuiYwfDkl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiYwfDkl.Click
        AddLog(Me.MnuiYwfDkl.Text)
        Dim rcFrm As New FrmYwfDklxx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '业务员任务数设置
    Private Sub MnuiYwfZyrw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiYwfZyrw.Click
        AddLog(Me.MnuiYwfZyrw.Text)
        Dim rcFrm As New FrmYwfZyrw
        With rcFrm
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    '期初库存余额输入
    Private Sub MnuiQcyeSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiQccpyeSr.Click
        AddLog(Me.MnuiQccpyeSr.Text)
        Dim rcFrm As New FrmQccpyeSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '期初客户应收余额输入
    Private Sub MnuiQckhyeSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiQckhyeSr.Click
        AddLog(Me.MnuiQckhyeSr.Text)
        Dim rcFrm As New FrmQckhyeSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '期初供应商应付余额输入
    Private Sub MnuiQccsyeSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiQccsyeSr.Click
        AddLog(Me.MnuiQccsyeSr.Text)
        Dim rcFrm As New FrmQccsyeSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '期初科目余额输入
    Private Sub MnuiQckmyeSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiQckmyeSr.Click
        AddLog(Me.MnuiQckmyeSr.Text)
        Dim rcFrm As New FrmQckmyeSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '单据类型信息设置
    Private Sub MnuiPzlxxx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPzlxxx.Click
        AddLog(Me.MnuiPzlxxx.Text)
        Dim rcFrm As New FrmPzlxxx
        With rcFrm
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '会计期间设置
    Private Sub MnuiKjqj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiKjqj.Click
        AddLog(Me.MnuiKjqj.Text)
        Dim rcFrm As New FrmKjqj
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub


    '角色和角色操作权限设置
    Private Sub MnuiRoles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiRoles.Click
        AddLog(Me.MnuiRoles.Text)
        Dim rcFrm As New FrmRoles
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '操作员和操作员角色设置
    Private Sub MnuiUsers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiUsers.Click
        AddLog(Me.MnuiUsers.Text)
        Dim rcFrm As New FrmUsers
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '选项
    Private Sub MnuiOption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOption.Click
        AddLog(Me.MnuiOption.Text)
        Dim rcFrm As New FrmOption
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '退出
    Private Sub MnuiExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiExit.Click, BtnExit.Click
        Me.Close()
    End Sub

#Region "样品订单"

    Private Sub MnuiOeYpddSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeYpddSr.Click
        AddLog(Me.MnuiOeYpddSr.Text)
        Dim rcFrm As New FrmOeYpddSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub MnuiOeYpddBmSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeYpddBmSr.Click
        AddLog(Me.MnuiOeYpddBmSr.Text)
        Dim rcFrm As New FrmOeYpddBmSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub MnuiOeYpddJqSr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuiOeYpddJqSr.Click
        AddLog(Me.MnuiOeYpddJqSr.Text)
        Dim rcFrm As New FrmOeYpddJqSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub MnuiOeYpddSh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuiOeYpddSh.Click
        AddLog(Me.MnuiOeYpddSh.Text)
        Dim rcFrm As New FrmOeYpddSh
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub MnuiOeYpFhrqSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeYpFhrqSr.Click
        AddLog(Me.MnuiOeYpFhrqSr.Text)
        Dim rcFrm As New FrmOeYpFhrqSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub MnuiOeYpFhdhSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeYpFhdhSr.Click
        AddLog(Me.MnuiOeYpFhdhSr.Text)
        Dim rcFrm As New FrmOeYpFhdhSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub MnuiOeYpddHx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeYpddHx.Click
        AddLog(Me.MnuiOeYpddHx.Text)
        Dim rcFrm As New FrmOeYpddHx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub MnuiOeYpddCx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeYpddCx.Click
        AddLog(Me.MnuiOeYpddCx.Text)
        Dim rcFrm As New FrmOeYpddCx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub MnuiOeYpddDjb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeYpddDjb.Click
        AddLog(Me.MnuiOeYpddDjb.Text)
        Dim rcFrm As New FrmOeYpddDjb
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

#End Region

    '产品报价单输入与修改
    Private Sub MnuiOeBjdsr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeBjdSr.Click
        AddLog(Me.MnuiOeBjdSr.Text)
        Dim rcFrm As New FrmOeBjdSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '产品报价单审核
    Private Sub MnuiOeBjdSh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeBjdSh.Click
        AddLog(Me.MnuiOeBjdSh.Text)
        Dim rcFrm As New FrmOeBjdSh
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '产品报价单查询
    Private Sub MnuiOeBjdCx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeBjdCx.Click
        AddLog(Me.MnuiOeBjdCx.Text)
        Dim rcFrm As New FrmOeBjdCx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '产品销售订单输入与修改
    Private Sub MnuiOeDdsr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeDdSr.Click
        AddLog(Me.MnuiOeDdSr.Text)
        Dim rcFrm As New FrmOeDdSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '产品销售订单审核
    Private Sub MnuiOeDdSh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeDdSh.Click
        AddLog(Me.MnuiOeDdSh.Text)
        Dim rcFrm As New FrmOeDdSh
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '产品销售订单订单审核
    Private Sub MnuiOeDddjSh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeDddjSh.Click
        AddLog(Me.MnuiOeDddjSh.Text)
        Dim rcFrm As New FrmOeDddjSh
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '产品销售订单半闭
    Private Sub MnuiOeDdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeDdClose.Click
        AddLog(Me.MnuiOeDdClose.Text)
        Dim rcFrm As New FrmOeDdClose
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '产品销售订单派工
    Private Sub MnuiOeDdJqSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeDdJqSr.Click
        AddLog(Me.MnuiOeDdJqSr.Text)
        Dim rcFrm As New FrmOeDdJqSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '产品销售订单查询
    Private Sub MnuiOeDdCx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeDdCx.Click
        AddLog(Me.MnuiOeDdCx.Text)
        Dim rcFrm As New FrmOeDdCx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '产品入库单输入
    Private Sub MnuiOeRkdsr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeRkdSr.Click
        AddLog(Me.MnuiOeRkdSr.Text)
        Dim rcFrm As New FrmOeRkdSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '产品入库单审核
    Private Sub MnuiOeRkdSh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuiOeRkdSh.Click
        AddLog(Me.MnuiOeRkdSh.Text)
        Dim rcFrm As New FrmOeRkdSh
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '产品发货通知书输入
    Private Sub MnuiOeFhdsr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeFhdSr.Click
        AddLog(Me.MnuiOeFhdSr.Text)
        Dim rcFrm As New FrmOeFhdSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '产品发货通知书审核
    Private Sub MnuiOeFhdSh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuiOeFhdSh.Click
        AddLog(Me.MnuiOeFhdSh.Text)
        Dim rcFrm As New FrmOeFhdSh
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '产品送货单输入
    Private Sub MnuiOeXsdSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeXsdSr.Click
        AddLog(Me.MnuiOeXsdSr.Text)
        Dim rcFrm As New FrmOeXsdSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '产品送货单审核
    Private Sub MnuiOeXsdSh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeXsdSh.Click
        AddLog(Me.MnuiOeXsdSh.Text)
        Dim rcFrm As New FrmOeXsdSh
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '产品送货单核销
    Private Sub MnuiOeXsdHx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeXsdHx.Click
        AddLog(Me.MnuiOeXsdHx.Text)
        Dim rcFrm As New FrmOeXsdHx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '产品销售单输入
    Private Sub MnuiOeFpSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeFpSr.Click
        AddLog(Me.MnuiOeFpSr.Text)
        Dim rcFrm As New FrmOeFpSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '产品销售单审核
    Private Sub MnuiOeFpSh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeFpSh.Click
        AddLog(Me.MnuiOeFpSh.Text)
        Dim rcFrm As New FrmOeFpSh
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '产品入库单查询
    Private Sub MnuiOeRkdCx_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuiOeRkdCx.Click
        AddLog(Me.MnuiOeRkdCx.Text)
        Dim rcFrm As New FrmOeRkdCx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '产品发货通知书查询
    Private Sub MnuiOeFhdCx_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuiOeFhdCx.Click
        AddLog(Me.MnuiOeFhdCx.Text)
        Dim rcFrm As New FrmOeFhdCx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '产品送货单查询
    Private Sub MnuiOeXsdCx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeXsdCx.Click
        AddLog(Me.MnuiOeXsdCx.Text)
        Dim rcFrm As New FrmOeXsdCx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '产品销售单查询
    Private Sub MnuiOeFpCx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeFpCx.Click
        AddLog(Me.MnuiOeFpCx.Text)
        Dim rcFrm As New FrmOeFpCx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '产品入库产值汇总表
    Private Sub MnuiOeRkCpHzb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeRkCpHzb.Click
        AddLog(Me.MnuiOeRkCpHzb.Text)
        Dim rcFrm As New FrmOeRkCpHzb
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '产品入库产值部门汇总表
    Private Sub MnuiOeRkBmHzb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeRkBmHzb.Click
        AddLog(Me.MnuiOeRkBmHzb.Text)
        Dim rcFrm As New FrmOeRkBmHzb
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '产品销售日报
    Private Sub MnuiXsrb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeXsrb.Click
        AddLog(Me.MnuiOeXsrb.Text)
        Dim rcFrm As New FrmOeXsRb
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料类别送货汇总表
    Private Sub MnuiOeCplbHzb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeCplbHzb.Click
        AddLog(Me.MnuiOeCplbHzb.Text)
        Dim rcFrm As New FrmOeCplbHzb
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '部门送货汇总表
    Private Sub MnuiOeBmHzb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeBmHzb.Click
        AddLog(Me.MnuiOeBmHzb.Text)
        Dim rcFrm As New FrmOeBmHzb
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '产品送货汇总表
    Private Sub MnuiOeCpHzb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeCpHzb.Click
        AddLog(Me.MnuiOeCpHzb.Text)
        Dim rcFrm As New FrmOeCpHzb
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '产品送货仓库汇总表
    Private Sub MnuiOeCkCpHzb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeCkCpHzb.Click
        AddLog(Me.MnuiOeCkCpHzb.Text)
        Dim rcFrm As New FrmOeCkCpHzb
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '客户送货汇总表
    Private Sub MnuiOeKhHzb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeKhHzb.Click
        AddLog(Me.MnuiOeKhHzb.Text)
        Dim rcFrm As New FrmOeKhHzb
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '职员销售汇总表
    Private Sub MnuiOeZyHzb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiOeZyHzb.Click
        AddLog(Me.MnuiOeZyHzb.Text)
        Dim rcFrm As New FrmOeZyHzb
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '生产订单输入与修改
    Private Sub MnuiPmDdSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPmDdSr.Click
        AddLog(Me.MnuiPmDdSr.Text)
        Dim rcFrm As New FrmPmDdSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '生成工序流转卡
    Private Sub MnuiPmScGxlzk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPmScGxlzk.Click
        AddLog(Me.MnuiPmScGxlzk.Text)
        Dim rcFrm As New FrmPmScGxlzk
        With rcFrm
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    '工序派工单
    Private Sub MnuiPmDdGxPg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPmDdGxPg.Click
        AddLog(Me.MnuiPmDdGxPg.Text)
        Dim rcFrm As New FrmPmDdGxPg
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '工序汇报单
    Private Sub MnuiPmDdGxHb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPmDdGxHb.Click
        AddLog(Me.MnuiPmDdGxHb.Text)
        Dim rcFrm As New FrmPmDdGxHb
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '工序领料单输入与修改
    Private Sub MnuiPmCkdSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPmCkdSr.Click
        AddLog(Me.MnuiPmCkdSr.Text)
        Dim rcFrm As New FrmPmCkdSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '工序领料单审核
    Private Sub MnuiPmCkdSh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPmCkdSh.Click
        AddLog(Me.MnuiPmCkdSh.Text)
        Dim rcFrm As New FrmPmCkdSh
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '工序入库单输入与修改
    Private Sub MnuiPmRkdSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPmRkdSr.Click
        AddLog(Me.MnuiPmRkdSr.Text)
        Dim rcFrm As New FrmPmRkdSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '工序入库单审核
    Private Sub MnuiPmRkdSh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPmRkdSh.Click
        AddLog(Me.MnuiPmRkdSh.Text)
        Dim rcFrm As New FrmPmRkdSh
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '工序入库单查询
    Private Sub MnuiPmRkdCx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPmRkdCx.Click
        AddLog(Me.MnuiPmRkdCx.Text)
        Dim rcFrm As New FrmPmRkdCx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '工序领料单查询
    Private Sub MnuiPmCkdCx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPmCkdCx.Click
        AddLog(Me.MnuiPmCkdCx.Text)
        Dim rcFrm As New FrmPmCkdCx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '订单生产工序跟踪查询
    Private Sub MnuiPmDdGxlzCx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPmDdGxlzCx.Click
        AddLog(Me.MnuiPmDdGxlzCx.Text)
        Dim rcFrm As New FrmPmDdGxlzCx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '各部门工序入库物料汇总表
    Private Sub MnuiPmRkCpHzb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPmRkCpHzb.Click
        AddLog(Me.MnuiPmRkCpHzb.Text)
        Dim rcFrm As New FrmPmRkCpHzb
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '部门入库汇总表
    Private Sub MnuiPmBmRkHzb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPmBmRkHzb.Click
        AddLog(Me.MnuiPmBmRkHzb.Text)
        Dim rcFrm As New FrmPmBmRkHzb
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料采购/维修需求输入与修改
    Private Sub MnuiPoCgjhSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPoCgjhSr.Click
        AddLog(Me.MnuiPoCgjhSr.Text)
        Dim rcFrm As New FrmPoCgjhSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料采购/维修需求单审核
    Private Sub MnuiPoCgjhSh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPoCgjhSh.Click
        AddLog(Me.MnuiPoCgjhSh.Text)
        Dim rcFrm As New FrmPoCgjhSh
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料采购/维修需求单关闭
    Private Sub MnuiPoCgjhClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPoCgjhClose.Click
        AddLog(Me.MnuiPoCgjhClose.Text)
        Dim rcFrm As New FrmPoCgjhClose
        With rcFrm
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '供应商物料采购价格目录维护
    Private Sub MnuiCsCpCgdjSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCsCpCgdjSr.Click
        AddLog(Me.MnuiCsCpCgdjSr.Text)
        Dim rcFrm As New FrmCsCpCgdjSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料采购/维修需求单查询
    Private Sub MnuiCgjhCx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPoCgjhCx.Click
        AddLog(Me.MnuiPoCgjhCx.Text)
        Dim rcFrm As New FrmPoCgjhCx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料采购订单输入与修改
    Private Sub MnuiPoCgdSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPoCgdSr.Click
        AddLog(Me.MnuiPoCgdSr.Text)
        Dim rcFrm As New FrmPoCgdSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料采购订单审核
    Private Sub MnuiPoCgdSh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPoCgdSh.Click
        AddLog(Me.MnuiPoCgdSh.Text)
        Dim rcFrm As New FrmPoCgdSh
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料采购订单审核
    Private Sub MnuiPoCgdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPoCgdClose.Click
        AddLog(Me.MnuiPoCgdClose.Text)
        Dim rcFrm As New FrmPoCgdClose
        With rcFrm
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料采购订单查询
    Private Sub MnuiCsCpCgdjCx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCsCpCgdjCx.Click
        AddLog(Me.MnuiCsCpCgdjCx.Text)
        Dim rcFrm As New FrmCsCpCgdjCx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料采购订单查询
    Private Sub MnuiPoCgdCx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPoCgdCx.Click
        AddLog(Me.MnuiPoCgdCx.Text)
        Dim rcFrm As New FrmPoCgdCx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料入库单输入
    Private Sub MnuiPoRkdsr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPoRkdSr.Click
        AddLog(Me.MnuiPoRkdSr.Text)
        Dim rcFrm As New FrmPoRkdSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料入库单审核
    Private Sub MnuiPoRkdSh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuiPoRkdSh.Click
        AddLog(Me.MnuiPoRkdSh.Text)
        Dim rcFrm As New FrmPoRkdSh
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料采购发票录入与修改
    Private Sub MnuiPoFpSr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuiPoFpSr.Click
        AddLog(Me.MnuiPoFpSr.Text)
        Dim rcFrm As New FrmPoFpSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料采购发票审核
    Private Sub MnuiPoFpSh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuiPoFpSh.Click
        AddLog(Me.MnuiPoFpSh.Text)
        Dim rcFrm As New FrmPoFpSh
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料领料申请单输入
    Private Sub MnuiPoLlsqSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPoLlsqSr.Click
        AddLog(Me.MnuiPoLlsqSr.Text)
        Dim rcFrm As New FrmPoLlsqSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料领料申请单审核
    Private Sub MnuiPoLlsqSh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPoLlsqSh.Click
        AddLog(Me.MnuiPoLlsqSh.Text)
        Dim rcFrm As New FrmPoLlsqSh
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料领料申请单审核
    Private Sub MnuiPoLlsqClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPoLlsqClose.Click
        AddLog(Me.MnuiPoLlsqClose.Text)
        Dim rcFrm As New FrmPoLlsqClose
        With rcFrm
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料回收单输入与修改
    Private Sub MnuiInvRecycleSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiInvRecycleSr.Click
        AddLog(Me.MnuiPoCkdSr.Text)
        Dim rcFrm As New FrmInvRecycleSr
        With rcFrm
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    '物料出库单输入
    Private Sub MnuiPoCkdSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPoCkdSr.Click
        AddLog(Me.MnuiPoCkdSr.Text)
        Dim rcFrm As New FrmPoCkdSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料领料发货
    Private Sub MnuiPoCkdSr2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPoCkdSr2.Click
        AddLog(Me.MnuiPoCkdSr2.Text)
        Dim rcFrm As New FrmPoCkdSr2
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料出库单审核
    Private Sub MnuiPoCkdSh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPoCkdSh.Click
        AddLog(Me.MnuiPoCkdSh.Text)
        Dim rcFrm As New FrmPoCkdSh
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料调拨单输入
    Private Sub MnuiInvDbdSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiInvDbdSr.Click
        AddLog(Me.MnuiInvDbdSr.Text)
        Dim rcFrm As New FrmInvDbdSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料调拨单审核
    Private Sub MnuiInvDbdSh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiInvDbdSh.Click
        AddLog(Me.MnuiInvDbdSh.Text)
        Dim rcFrm As New FrmInvDbdSh
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料入库单查询
    Private Sub MnuiPoRkdCx_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuiPoRkdCx.Click
        AddLog(Me.MnuiPoRkdCx.Text)
        Dim rcFrm As New FrmPoRkdCx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料采购发票查询
    Private Sub MnuiPoFpCx_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuiPoFpCx.Click
        AddLog(Me.MnuiPoFpCx.Text)
        Dim rcFrm As New FrmPoFpCx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料领料申请单查询
    Private Sub MnuiPoLlsqCx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPoLlsqCx.Click
        AddLog(Me.MnuiPoLlsqCx.Text)
        Dim rcFrm As New FrmPoLlsqCx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料出库单查询
    Private Sub MnuiPoCkdCx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPoCkdCx.Click
        AddLog(Me.MnuiPoCkdCx.Text)
        Dim rcFrm As New FrmPoCkdCx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料调拨单查询
    Private Sub MnuiInvDbdCx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiInvDbdCx.Click
        AddLog(Me.MnuiInvDbdCx.Text)
        Dim rcFrm As New FrmInvDbdCx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '供应商采购汇总表
    Private Sub MnuiPoCsHzb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPoCsHzb.Click
        AddLog(Me.MnuiPoCsHzb.Text)
        Dim rcFrm As New FrmPoCsHzb
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '部门领用汇总表
    Private Sub MnuiPoBmHzb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPoBmHzb.Click
        AddLog(Me.MnuiPoBmHzb.Text)
        Dim rcFrm As New FrmPoBmHzb
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '部门设备物料类别消耗汇总表
    Private Sub MnuiPoBmFaLbHzb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPoBmFaLbHzb.Click
        AddLog(Me.MnuiPoBmFaLbHzb.Text)
        Dim rcFrm As New FrmPoBmFaLbHzb
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '仓库领用物料汇总表
    Private Sub MnuiCkCkCpHzb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCkCkCpHzb.Click
        AddLog(Me.MnuiCkCkCpHzb.Text)
        Dim rcFrm As New FrmCkCkCpHzb
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '仓库调拨物料汇总表
    Private Sub MnuiCkDbCpHzb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCkDbCpHzb.Click
        AddLog(Me.MnuiCkDbCpHzb.Text)
        Dim rcFrm As New FrmCkDbCpHzb
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料调整单输入与修改
    Private Sub MnuiInvCktzSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiInvCktzSr.Click
        AddLog(Me.MnuiInvCktzSr.Text)
        Dim rcFrm As New FrmInvCktzSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料盘存表输入与修改
    Private Sub MnuiInvPcSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiInvPcSr.Click
        AddLog(Me.MnuiInvPcSr.Text)
        Dim rcFrm As New FrmInvPcSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料盘存表审核
    Private Sub MnuiInvPcSh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiInvPcSh.Click
        AddLog(Me.MnuiInvPcSh.Text)
        Dim rcFrm As New FrmInvPcSh
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '仓库收发存明细账
    Private Sub MnuiSlSfcMx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiSlSfcMx.Click
        AddLog(Me.MnuiSlSfcMx.Text)
        Dim rcFrm As New FrmSlSfcMx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '仓库收发存汇总表
    Private Sub MnuiSlSfcHz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiSlSfcHz.Click
        AddLog(Me.MnuiSlSfcHz.Text)
        Dim rcFrm As New FrmSlSfcHz
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料盘存表
    Private Sub MnuiCpPcb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCpPcb.Click
        AddLog(Me.MnuiCpPcb.Text)
        Dim rcFrm As New FrmCpPcb
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料收发存明细账
    Private Sub MnuiCpSfcMx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCpSfcMx.Click
        AddLog(Me.MnuiCpSfcMx.Text)
        Dim rcFrm As New FrmCpSfcMx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料各仓库资金收发存汇总表
    Private Sub MnuiJeSfcHz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiJeSfcHz.Click
        AddLog(Me.MnuiJeSfcHz.Text)
        Dim rcFrm As New FrmJeSfcHz
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料收发存汇总表
    Private Sub MnuiCpSfcHz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCpSfcHz.Click
        AddLog(Me.MnuiCpSfcHz.Text)
        Dim rcFrm As New FrmCpSfcHz
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料批次收发存明细账
    Private Sub MnuiPhSfcMx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPhSfcMx.Click
        AddLog(Me.MnuiPhSfcMx.Text)
        Dim rcFrm As New FrmPhSfcMx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料批次收发存汇总表
    Private Sub MnuiPhSfcHz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPhSfcHz.Click
        AddLog(Me.MnuiPhSfcHz.Text)
        Dim rcFrm As New FrmPhSfcHz
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料类别收发存汇总表
    Private Sub MnuiCplbSfcHz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCplbSfcHz.Click
        AddLog(Me.MnuiCplbSfcHz.Text)
        Dim rcFrm As New FrmCplbSfcHz
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料库存账龄分析表
    Private Sub MnuiCpkcZlfx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCpkcZlfx.Click
        AddLog(Me.MnuiCpkcZlfx.Text)
        Dim rcFrm As New FrmCpkcZlfx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '其他应收单输入
    Private Sub MnuiQtysSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiQtysSr.Click
        AddLog(Me.MnuiQtysSr.Text)
        Dim rcFrm As New FrmQtysSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '其他应收单审核
    Private Sub MnuiQtysSh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiQtysSh.Click
        AddLog(Me.MnuiQtysSh.Text)
        Dim rcFrm As New FrmQtysSh
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '收款单输入
    Private Sub MnuiSkdSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiSkdSr.Click
        AddLog(Me.MnuiSkdSr.Text)
        Dim rcFrm As New FrmSkdSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '收款单审核
    Private Sub MnuiSkdSh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiSkdSh.Click
        AddLog(Me.MnuiSkdSh.Text)
        Dim rcFrm As New FrmSkdSh
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '应收账款核销
    Private Sub MnuiSkdHx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiSkdHx.Click
        AddLog(Me.MnuiSkdHx.Text)
        Dim rcFrm As New FrmSkdHx
        With rcFrm
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '其他应付单输入
    Private Sub MnuiQtyfSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiQtyfSr.Click
        AddLog(Me.MnuiQtyfSr.Text)
        Dim rcFrm As New FrmQtyfSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '其他应付单审核
    Private Sub MnuiQtyfSh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiQtyfSh.Click
        AddLog(Me.MnuiQtyfSh.Text)
        Dim rcFrm As New FrmQtyfSh
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '付款申请单输入
    Private Sub MnuiApFksqSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiApFksqSr.Click
        AddLog(Me.MnuiApFksqSr.Text)
        Dim rcFrm As New FrmApFksqSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '付款申请单审核
    Private Sub MnuiApFksqSh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiApFksqSh.Click
        AddLog(Me.MnuiApFksqSh.Text)
        Dim rcFrm As New FrmApFksqSh
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '付款单输入
    Private Sub MnuiFkdSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiFkdSr.Click
        AddLog(Me.MnuiFkdSr.Text)
        Dim rcFrm As New FrmFkdSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '付款单审核
    Private Sub MnuiFkdSh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiFkdSh.Click
        AddLog(Me.MnuiFkdSh.Text)
        Dim rcFrm As New FrmFkdSh
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '应付账款核销
    Private Sub MnuiFkdHx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiFkdHx.Click
        AddLog(Me.MnuiFkdHx.Text)
        Dim rcFrm As New FrmFkdHx
        With rcFrm
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '其他应收单查询
    Private Sub MnuiQtysCx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiQtysCx.Click
        AddLog(Me.MnuiQtysCx.Text)
        Dim rcFrm As New FrmQtysCx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '收款单查询
    Private Sub MnuiSkdCx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiSkdCx.Click
        AddLog(Me.MnuiSkdCx.Text)
        Dim rcFrm As New FrmSkdCx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '其他应付单查询
    Private Sub MnuiQtyfCx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiQtyfCx.Click
        AddLog(Me.MnuiQtyfCx.Text)
        Dim rcFrm As New FrmQtyfCx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '付款申请单查询
    Private Sub MnuiApFksqCx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiApFksqCx.Click
        AddLog(Me.MnuiApFksqCx.Text)
        Dim rcFrm As New FrmApFksqCx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '付款单查询
    Private Sub MnuiFkdCx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiFkdCx.Click
        AddLog(Me.MnuiFkdCx.Text)
        Dim rcFrm As New FrmFkdCx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '客户应收账款明细
    Private Sub MnuiKhYszkMx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiKhYszkMx.Click
        AddLog(Me.MnuiKhYszkMx.Text)
        Dim rcFrm As New FrmKhYszkMx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '客户应收账款核销明细账
    Private Sub MnuiKhYszkHxMx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiKhYszkHxMx.Click
        AddLog(Me.MnuiKhYszkHxMx.Text)
        Dim rcFrm As New FrmKhYszkHxMx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '客户应收账款汇总表
    Private Sub MnuiKhYszkHz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiKhYszkHz.Click
        AddLog(Me.MnuiKhYszkHz.Text)
        Dim rcFrm As New FrmKhYszkHz
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '客户类别应收账款汇总表
    Private Sub MnuiKhLbYszkHz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiKhLbYszkHz.Click
        AddLog(Me.MnuiKhLbYszkHz.Text)
        Dim rcFrm As New FrmKhLbYszkHz
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '客户应付账款明细
    Private Sub MnuiCsYfzkMx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCsYfzkMx.Click
        AddLog(Me.MnuiCsYfzkMx.Text)
        Dim rcFrm As New FrmCsYfzkMx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '客户应付账款汇总表
    Private Sub MnuiCsYfzkHz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCsYfzkHz.Click
        AddLog(Me.MnuiCsYfzkHz.Text)
        Dim rcFrm As New FrmCsYfzkHz
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '客户应付账款汇总表
    Private Sub MnuiCsLbYfzkHz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCsLbYfzkHz.Click
        AddLog(Me.MnuiCsLbYfzkHz.Text)
        Dim rcFrm As New FrmCsLbYfzkHz
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '客户收款汇总表
    Private Sub MnuiArKhHzb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiArKhHzb.Click
        AddLog(Me.MnuiArKhHzb.Text)
        Dim rcFrm As New FrmArKhHzb
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

#Region "成本"

    '期末在产材料数量录入
    Private Sub MnuiZcclslSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiZcclslSr.Click
        AddLog(Me.MnuiZcclslSr.Text)
        Dim rcFrm As New FrmZcclslSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '期末在产品数量录入
    Private Sub MnuiZcpslSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiZcpslSr.Click
        AddLog(Me.MnuiZcpslSr.Text)
        Dim rcFrm As New FrmZcpslSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub MnuiZcbJeSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiZcbJeSr.Click
        AddLog(Me.MnuiZcbJeSr.Text)
        Dim rcFrm As New FrmZcbjeSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '材料出库成本结转
    Private Sub MnuiCbjz_Cl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCbjz_Cl.Click
        AddLog(Me.MnuiCbjz_Cl.Text)
        Dim rcFrm As New FrmCbjz_Cl
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '生产成本分配
    Private Sub MnuiCbjz_Sccb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCbjz_Sccb.Click
        AddLog(Me.MnuiCbjz_Sccb.Text)
        Dim rcFrm As New FrmCbjz_Sccb
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '产品出库成本结转
    Private Sub MnuiCbjz_Xscb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCbjz_Xscb.Click
        AddLog(Me.MnuiCbjz_Xscb.Text)
        Dim rcFrm As New FrmCbjz_Xscb
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub MnuiZcclMx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiZcclMx.Click
        AddLog(Me.MnuiZcclMx.Text)
        Dim rcFrm As New FrmZcclMx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '在产品部门工序汇总表
    Private Sub MnuiZcpBmGxHz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiZcpBmGxHz.Click
        AddLog(Me.MnuiZcpBmGxHz.Text)
        Dim rcFrm As New FrmZcpBmGxHz
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '产成品在产品成本汇总表
    Private Sub MnuiCcpZcpHz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCcpZcpHz.Click
        AddLog(Me.MnuiCcpZcpHz.Text)
        Dim rcFrm As New FrmCcpZcpHz
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '产成品在产品各部门成本汇总表
    Private Sub MnuiCcpZcpBmHz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCcpZcpBmHz.Click
        AddLog(Me.MnuiCcpZcpBmHz.Text)
        Dim rcFrm As New FrmCcpZcpBmHz
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料清单查询
    Private Sub MnuiBomCx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiBomCx.Click
        AddLog(Me.MnuiBomCx.Text)
        Dim rcFrm As New FrmBomCx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

#End Region

    '凭证输入
    Private Sub MnuiGlPzSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiGlPzSr.Click
        AddLog(Me.MnuiGlPzSr.Text)
        Dim rcFrm As New FrmGlPzSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '凭证审核
    Private Sub MnuiGlPzSh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiGlPzSh.Click
        AddLog(Me.MnuiGlPzSh.Text)
        Dim rcFrm As New FrmGlPzSh
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '凭证记帐
    Private Sub MnuiGlPzJz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiGlPzJz.Click
        AddLog(Me.MnuiGlPzJz.Text)
        Dim rcFrm As New FrmGlPzJz
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '凭证查询
    Private Sub MnuiGlPzCx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiGlPzCx.Click
        AddLog(Me.MnuiGlPzCx.Text)
        Dim rcFrm As New FrmGlPzCx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '科目日记账
    Private Sub MnuiGlKmRjz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiGlKmRjz.Click
        AddLog(Me.MnuiGlKmRjz.Text)
        Dim rcFrm As New FrmGlKmRjz
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '科目明细账
    Private Sub MnuiGlKmMxz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiGlKmMxz.Click
        AddLog(Me.MnuiGlKmMxz.Text)
        Dim rcFrm As New FrmGlKmMxz
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '总账余额汇总表
    Private Sub MnuiGlKmyeb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiGlKmyeb.Click
        AddLog(Me.MnuiGlKmyeb.Text)
        Dim rcFrm As New FrmGlKmyeb
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '科目客户余额汇总表
    Private Sub MnuiGlKmkhYeb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiGlKmkhYeb.Click
        AddLog(Me.MnuiGlKmkhYeb.Text)
        Dim rcFrm As New FrmGlKmkhYeb
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '科目供应商余额汇总表
    Private Sub MnuiGlKmcsYeb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiGlKmcsYeb.Click
        AddLog(Me.MnuiGlKmcsYeb.Text)
        Dim rcFrm As New FrmGlKmcsYeb
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '账龄分析表
    Private Sub MnuiGlZlfx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiGlZlfx.Click
        AddLog(Me.MnuiGlZlfx.Text)
        Dim rcFrm As New FrmGlZlfx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '汇总账龄分析表
    Private Sub MnuiGlZlfxHz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiGlZlfxHz.Click
        AddLog(Me.MnuiGlZlfxHz.Text)
        Dim rcFrm As New FrmGlZlfxHz
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '汇总账龄分析表（按账套）
    Private Sub MnuiGlZlfxHz2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiGlZlfxHz2.Click
        AddLog(Me.MnuiGlZlfxHz2.Text)
        Dim rcFrm As New FrmGlZlfxHz2
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '单据记账
    Private Sub MnuiDjjz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiDjjz.Click
        AddLog(Me.MnuiDjjz.Text)
        Dim rcFrm As New FrmDjjz
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '计提存货跌价准备
    Private Sub MnuiJtchdjzb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiJtchdjzb.Click
        AddLog(Me.MnuiJtchdjzb.Text)
        Dim rcFrm As New FrmJtchdjzb
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '业务费抵扣规则定义
    Private Sub MnuiYwfDkgsxx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiYwfDkgsxx.Click
        AddLog(Me.MnuiYwfDkgsxx.Text)
        Dim rcFrm As New FrmYwfDkgsxx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '业务费抵扣业务输入与修改
    Private Sub MnuiYwfDkywSr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiYwfDkywSr.Click
        AddLog(Me.MnuiYwfDkywSr.Text)
        Dim rcFrm As New FrmYwfDkywSr
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '业务费抵扣业务查询
    Private Sub MnuiYwfDkywCx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiYwfDkywCx.Click
        AddLog(Me.MnuiYwfDkywCx.Text)
        Dim rcFrm As New FrmYwfDkywCx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '业务费计算
    Private Sub MnuiYwfJs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiYwfJs.Click
        AddLog(Me.MnuiYwfJs.Text)
        Dim rcFrm As New FrmYwfJs
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '业务费查询
    Private Sub MnuiYwfCx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiYwfCx.Click
        AddLog(Me.MnuiYwfCx.Text)
        Dim rcFrm As New FrmYwfCx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '业务费客户汇总查询
    Private Sub MnuiYwfKhHz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiYwfKhHz.Click
        AddLog(Me.MnuiYwfKhHz.Text)
        Dim rcFrm As New FrmYwfKhHz
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '业务费业务员汇总查询
    Private Sub MnuiYwfZyHz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiYwfZyHz.Click
        AddLog(Me.MnuiYwfZyHz.Text)
        Dim rcFrm As New FrmYwfZyHz
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '业务费业务员计算明细表
    Private Sub MnuiYwfZyMx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiYwfZyMx.Click
        AddLog(Me.MnuiYwfZyMx.Text)
        Dim rcFrm As New FrmYwfZyMx
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '业务费业务员增长汇总查询
    Private Sub MnuiYwfZyzzHz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiYwfZyzzHz.Click
        AddLog(Me.MnuiYwfZyzzHz.Text)
        Dim rcFrm As New FrmYwfZyzzHz
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '汇总业务费客户汇总查询
    Private Sub MnuiYwfKhHzHz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiYwfKhHzHz.Click
        AddLog(Me.MnuiYwfKhHzHz.Text)
        Dim rcFrm As New FrmYwfKhHzHz
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '物料消耗计算
    Private Sub MnuiMrpJs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiMrpJs.Click
        AddLog(Me.MnuiMrpJs.Text)
        Dim rcFrm As New FrmMrpJs
        With rcFrm
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '凭证生成
    Private Sub MnuiPzsc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPzsc.Click
        AddLog(Me.MnuiPzsc.Text)
        Dim rcFrm As New FrmPzsc
        With rcFrm
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '凭证传递
    Private Sub MnuiPzcd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPzcd.Click
        AddLog(Me.MnuiPzcd.Text)
        Dim rcFrm As New FrmPzcd
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '月底结账
    Private Sub MnuiYdjz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiYdjz.Click
        AddLog(Me.MnuiYdjz.Text)
        Dim rcFrm As New FrmYdjz
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '建立新年度帐
    Private Sub MnuiNewYear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiNewYear.Click
        AddLog(Me.MnuiNewYear.Text)
        Dim rcFrm As New FrmNewYear
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '修改密码
    Private Sub MnuiModPwd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiModPwd.Click, BtnModPwd.Click
        AddLog(Me.MnuiModPwd.Text)
        Dim rcFrm As New models.FrmModPwd
        With rcFrm
            .paraOleDbConn = sysOleDbConn
            .paraUser_Account = g_User_Account
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '重新注册
    Private Sub MnuiZtdl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiZtdl.Click
        '操作员登陆
        Dim rcFrm As New FrmUserLogin
        With rcFrm
            If Not .ShowDialog() = DialogResult.OK Then
                Return
            End If
        End With
        '取操作员的角色
        Try
            sysOleDbConn.Open()
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT rc_users.user_dwdm,rc_users.user_account,rc_userinrole.roleid FROM rc_users,rc_userinrole WHERE rc_users.user_account = rc_userinrole.user_account AND rc_users.user_account = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@USER_Account", OleDbType.VarChar, 30).Value = g_User_Account
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_userinrole") IsNot Nothing Then
                rcDataset.Tables("rc_userinrole").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_userinrole")
        Catch ex As Exception
            MsgBox("程序错误4。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End
        Finally
            sysOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_userinrole").Rows.Count <= 0 Then
            MsgBox("您没有操作权限，请与系统管理员联系。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End
        End If
        Dim i As Integer
        For i = 0 To rcDataset.Tables("rc_userinrole").Rows.Count - 1
            '取角色权限(角色权限为并且的关系)
            Try
                sysOleDbConn.Open()
                rcOleDbCommand.Connection = sysOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT rc_menu.mnuiname FROM rc_roleqx,rc_menu WHERE rc_roleqx.roleid = ? AND rc_menu.mnuiown = 'RC3' AND rc_roleqx.righttype = 'RC3' AND rc_roleqx.code = rc_menu.mnuiid ORDER BY rc_menu.mnuiid"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@roleid", OleDbType.VarChar, 12).Value = rcDataset.Tables("rc_userinrole").Rows(i).Item("roleid")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_roleqx") IsNot Nothing Then
                    rcDataset.Tables("rc_roleqx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_roleqx")
            Catch ex As Exception
                MsgBox("程序错误5。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End
            Finally
                sysOleDbConn.Close()
            End Try
            Dim j As Integer
            For j = 0 To rcDataset.Tables("rc_roleqx").Rows.Count - 1
                Dim t As Type = Me.GetType
                Dim f As System.Reflection.FieldInfo = t.GetField("_" & Trim(rcDataset.Tables("rc_roleqx").Rows(j).Item("mnuiname")), System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Public)
                Dim itemMenu As ToolStripMenuItem = CType(f.GetValue(Me), ToolStripMenuItem)
                itemMenu.Visible = True
            Next
        Next
        If g_User_Account = "ADMIN" Then
            '系统管理员
            '取所有菜单
            Try
                sysOleDbConn.Open()
                rcOleDbCommand.Connection = sysOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT rc_menu.mnuiname FROM rc_menu WHERE rc_menu.mnuiown = 'RC3' ORDER BY rc_menu.mnuiid"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_roleqx") IsNot Nothing Then
                    rcDataset.Tables("rc_roleqx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_roleqx")
            Catch ex As Exception
                MsgBox("程序错误5。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End
            Finally
                sysOleDbConn.Close()
            End Try
            Dim j As Integer
            For j = 0 To rcDataset.Tables("rc_roleqx").Rows.Count - 1
                Dim t As Type = Me.GetType
                Dim f As System.Reflection.FieldInfo = t.GetField("_" & Trim(rcDataset.Tables("rc_roleqx").Rows(j).Item("mnuiname")), System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Public)
                Dim itemMenu As ToolStripMenuItem = CType(f.GetValue(Me), ToolStripMenuItem)
                itemMenu.Visible = True
            Next
        End If
        Me.ToolStripStatusLabel2.Text = "单位：" + g_Dwmc
        Me.ToolStripStatusLabel3.Text = "操作员：" + g_User_DspName
        Me.ToolStripStatusLabel4.Text = "登陆日期：" & g_Kjrq.ToLongDateString
        ''取会计期间
        g_Kjqj = getInvKjqj(g_Kjrq)
    End Sub

    '在线升级
    Private Sub MnuiUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiUpdate.Click
        AddLog(Me.MnuiUpdate.Text)
        Dim rcFrm As New FrmUpdate
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '上传文件
    Private Sub MnuiUploadFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiUploadFile.Click
        AddLog(Me.MnuiUploadFile.Text)
        Dim rcFrm As New FrmUploadFile
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '升级RC3数据
    Private Sub MnuiUpdateDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiUpdateDB.Click
        AddLog(Me.MnuiUpdateDB.Text)
        Dim rcFrm As New FrmUpdateDB
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '导入用友NC数据
    Private Sub MnuiImpNC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiImpNC.Click
        AddLog(Me.MnuiImpNC.Text)
        Dim rcFrm As New FrmImpNC
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '导入用友U8数据
    Private Sub MnuiImpU8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiImpU8.Click
        AddLog(Me.MnuiImpU8.Text)
        Dim rcFrm As New FrmImpU8
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub


    '物料编码更改与合并
    Private Sub MnuiCpdmGg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCpdmGg.Click
        AddLog(Me.MnuiCpdmGg.Text)
        Dim rcFrm As New FrmCpdmGg
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '客户编码更改与合并
    Private Sub MnuiKhdmGg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiKhdmGg.Click
        AddLog(Me.MnuiKhdmGg.Text)
        Dim rcFrm As New FrmKhdmGg
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '供应商编码更改与合并
    Private Sub MnuiCsdmGg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCsdmGg.Click
        AddLog(Me.MnuiCsdmGg.Text)
        Dim rcFrm As New FrmCsdmGg
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '供应商编码更改与合并
    Private Sub MnuiZydmGg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiZydmGg.Click
        AddLog(Me.MnuiZydmGg.Text)
        Dim rcFrm As New FrmZydmGg
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '重新汇总总帐
    Private Sub MnuiRedoCpyeHz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiRedoCpyeHz.Click
        Dim rcFrm As New FrmRedoCpyeHz
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '检测系统数据库
    Private Sub MnuiCheckData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCheckData.Click
        AddLog(Me.MnuiCheckData.Text)
        Dim rcFrm As New FrmCheckData
        With rcFrm
            .ShowDialog()
        End With
    End Sub

    '升级锐创数据
    Private Sub MnuiUpgrateData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiUpgrateData.Click
        AddLog(Me.MnuiUpgrateData.Text)
        Dim rcFrm As New FrmUpgrateData
        With rcFrm
            .ShowDialog()
        End With
    End Sub

    '物料数据修复
    Private Sub MnuiCpRepair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiCpRepair.Click
        Dim rcFrm As New FrmCpRepair
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    '关于
    Private Sub MnuiAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiAbout.Click
        Dim rcFrm As New FrmAbout
        With rcFrm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Function SetSubItemVisible(ByVal dc As ToolStripMenuItem) As Boolean
        Dim i As Integer
        'dc.Visible = False
        'Dim blnVisible As Boolean
        If dc.DropDownItems.Count > 0 Then
            For i = 0 To dc.DropDownItems.Count - 1
                If dc.DropDownItems.Item(i).GetType.ToString = "System.Windows.Forms.ToolStripMenuItem" Then
                    Dim sdc As ToolStripMenuItem = dc.DropDownItems.Item(i)
                    If sdc.Visible = True Then
                        'blnVisible = True
                    End If
                    SetSubItemVisible(sdc)
                End If
            Next
        End If
        Return True
    End Function

    Private Sub TESTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TESTToolStripMenuItem.Click
        Dim rcFrm As New Form3
        With rcFrm
            .MdiParent = Me
            .Show()
        End With

    End Sub

    Private Sub MnuiPoRkdImpCgd_Click(sender As Object, e As EventArgs) Handles MnuiInvRecycleSr.Click

    End Sub
End Class
