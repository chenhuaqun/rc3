Imports System.IO

'帮助功能：把系统中所有「帮助」按钮与「帮助(&H)」菜单统一挂接到本模块。
'
'系统的帮助控件分散在 160 余个窗体里（工具栏 ToolStripButton、窗体 Panel 内的 Button、
'各窗体菜单栏内的 ToolStripMenuItem），并且有 100 余处用 ShowDialog 弹出的模态窗体，
'MdiChildActivate 覆盖不到它们，因此这里不定点改写各窗体，而是在启动后定时扫描
'Application.OpenForms，对尚未挂接的控件补挂事件，扫描结果记入 g_attached 防止重复。
Module MdlHelp

    '帮助站点固定发布在 rc3.exe 同级的 help 目录下，随程序目录一起分发
    Private Const HELP_FOLDER As String = "help"
    Private Const HELP_INDEX As String = "index.html"

    '扫描已打开窗体的间隔（毫秒）
    Private Const SCAN_INTERVAL As Integer = 1500

    '约定挂接的控件名，与各 Designer 中的字段名一致
    Private Const BUTTON_HELP As String = "BtnHelp"
    Private Const MENU_HELP As String = "MnuiHelp"

    '已挂接的对象（Control 与 ToolStripItem 混存，故以 Object 为键，按引用比较）
    Private ReadOnly g_attached As New Dictionary(Of Object, Boolean)(New MdlHelpRefComparer)

    Private g_timer As System.Windows.Forms.Timer = Nothing

#Region "对外入口"

    '启动自动挂接。须在消息循环建立之前调用（Sub Main 中），登录窗等模态窗体才能被扫到
    Public Sub StartAutoAttach()
        If Not g_timer Is Nothing Then
            If g_timer.Enabled Then Return
        End If

        If g_timer Is Nothing Then
            g_timer = New System.Windows.Forms.Timer()
            AddHandler g_timer.Tick, AddressOf g_timer_Tick
        End If
        g_timer.Interval = SCAN_INTERVAL
        g_timer.Start()
    End Sub

    '打开帮助。strPage 为 help 站点内的页面文件名，缺省打开首页
    Public Sub ShowHelp(Optional ByVal strPage As String = HELP_INDEX)
        Dim strPath As String = ResolveLocalPage(strPage)
        If strPath.Length = 0 Then
            MessageBox.Show("未找到帮助文件，请确认程序目录下的 help 文件夹已随程序一同安装。" & vbCrLf &
                            "需要打开的文件：" & HELP_FOLDER & "\" & strPage,
                            "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim rcPci As New ProcessStartInfo(strPath)
            rcPci.UseShellExecute = True
            Process.Start(rcPci)
        Catch ex As Exception
            MessageBox.Show("无法打开帮助文件：" & strPath & vbCrLf & ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    '为单个窗体补挂帮助入口：遍历整棵控件树，再挂窗体自身的帮助请求
    Public Sub Attach(ByVal frm As Form)
        If frm Is Nothing Then Return

        Try
            AttachControlTree(frm)
        Catch ex As Exception
        End Try

        If g_attached.ContainsKey(frm) Then Return
        g_attached.Add(frm, True)

        Try
            AddHandler frm.HelpRequested, AddressOf frm_HelpRequested
        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "定时扫描"

    Private Sub g_timer_Tick(ByVal sender As Object, ByVal e As EventArgs)
        '单个窗体异常不应中断整轮扫描
        Try
            Dim obj As Object
            For Each obj In Application.OpenForms
                Dim frm As Form = TryCast(obj, Form)
                If Not frm Is Nothing Then
                    Attach(frm)
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "控件遍历与挂接"

    '窗体与普通容器走 Controls；ToolStrip、MenuStrip 的按钮与菜单项不在 Controls 内，
    '须另走 Items，并顺着 DropDownItems 递归，才能覆盖各级菜单
    Private Sub AttachControlTree(ByVal ctl As Control)
        If ctl Is Nothing Then Return

        Try
            TryAttach(ctl)
        Catch ex As Exception
        End Try

        Dim ts As ToolStrip = TryCast(ctl, ToolStrip)
        If Not ts Is Nothing Then
            Try
                Dim it As ToolStripItem
                For Each it In ts.Items
                    AttachStripItemTree(it)
                Next
            Catch ex As Exception
            End Try
        End If

        Try
            Dim child As Control
            For Each child In ctl.Controls
                AttachControlTree(child)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub AttachStripItemTree(ByVal it As ToolStripItem)
        If it Is Nothing Then Return

        Try
            TryAttach(it)
        Catch ex As Exception
        End Try

        Dim dd As ToolStripDropDownItem = TryCast(it, ToolStripDropDownItem)
        If dd Is Nothing Then Return

        Try
            Dim sub2 As ToolStripItem
            For Each sub2 In dd.DropDownItems
                AttachStripItemTree(sub2)
            Next
        Catch ex As Exception
        End Try
    End Sub

    '按控件名识别帮助入口并挂接。已挂接过的对象直接返回，保证同一控件只挂一次
    Private Sub TryAttach(ByVal obj As Object)
        If obj Is Nothing Then Return
        If g_attached.ContainsKey(obj) Then Return

        '无论挂接成功与否都记入 g_attached，失败的对象不再重试
        Try
            Dim mnu As ToolStripMenuItem = TryCast(obj, ToolStripMenuItem)
            If Not mnu Is Nothing AndAlso IsName(mnu.Name, MENU_HELP) Then
                AddHelpMenuItem(mnu)
                g_attached.Add(obj, True)
                Return
            End If

            Dim btn As ToolStripButton = TryCast(obj, ToolStripButton)
            If Not btn Is Nothing AndAlso IsName(btn.Name, BUTTON_HELP) Then
                AddHandler btn.Click, AddressOf HelpItem_Click
                g_attached.Add(obj, True)
                Return
            End If

            Dim btn2 As Button = TryCast(obj, Button)
            If Not btn2 Is Nothing AndAlso IsName(btn2.Name, BUTTON_HELP) Then
                AddHandler btn2.Click, AddressOf HelpItem_Click
                g_attached.Add(obj, True)
                Return
            End If
        Catch ex As Exception
            MarkAttached(obj)
        End Try
    End Sub

    Private Sub MarkAttached(ByVal obj As Object)
        Try
            If Not g_attached.ContainsKey(obj) Then
                g_attached.Add(obj, True)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Function IsName(ByVal strName As String, ByVal strTarget As String) As Boolean
        Return String.Equals(strName, strTarget, StringComparison.Ordinal)
    End Function

#End Region

#Region "帮助菜单项"

    '各窗体的「帮助(&H)」菜单下原本只有「关于」，在此插入「帮助内容」置顶
    Private Sub AddHelpMenuItem(ByVal mnu As ToolStripMenuItem)
        '图标不设：Resources\ImgHelp.png 未随程序输出，运行时取不到
        Dim mnuContent As New ToolStripMenuItem("帮助内容(&C)")
        mnuContent.Name = "MnuiHelpContent"
        mnuContent.ToolTipText = "打开 RC3 帮助"
        mnu.DropDownItems.Insert(0, mnuContent)

        Dim sep As New ToolStripSeparator()
        sep.Name = "MnuiHelpSeparator"
        mnu.DropDownItems.Insert(1, sep)

        AddHandler mnuContent.Click, AddressOf HelpItem_Click
    End Sub

#End Region

#Region "事件处理"

    Private Sub HelpItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ShowHelp()
    End Sub

    Private Sub frm_HelpRequested(ByVal sender As Object, ByVal e As HelpEventArgs)
        ShowHelp()
    End Sub

#End Region

#Region "本地帮助文件定位"

    '只认程序目录（Application.StartupPath，即 rc3.exe 所在目录）下的 help 子目录
    Private Function ResolveLocalPage(ByVal strPage As String) As String
        If String.IsNullOrEmpty(strPage) Then
            strPage = HELP_INDEX
        End If

        Dim strCandidate As String = Path.Combine(Application.StartupPath, Path.Combine(HELP_FOLDER, strPage))
        If File.Exists(strCandidate) Then
            Return strCandidate
        End If

        Return ""
    End Function

#End Region

#Region "引用相等比较器"

    'g_attached 的键含 Control 与 ToolStripItem，需按对象身份而非内容比较，
    '.NET Framework 4.8 无内置 ReferenceEqualityComparer，故自行实现
    Private Class MdlHelpRefComparer
        Implements IEqualityComparer(Of Object)

        Public Function Equals(ByVal x As Object, ByVal y As Object) As Boolean Implements IEqualityComparer(Of Object).Equals
            Return Object.ReferenceEquals(x, y)
        End Function

        Public Function GetHashCode(ByVal obj As Object) As Integer Implements IEqualityComparer(Of Object).GetHashCode
            If obj Is Nothing Then
                Return 0
            End If
            Return System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(obj)
        End Function
    End Class

#End Region

End Module
