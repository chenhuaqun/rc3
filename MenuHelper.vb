Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class MenuHelper

    Private Shared _authorizedMenuIds As List(Of String)
    Private Shared _menuData As DataTable

    Private Shared ReadOnly Property AuthorizedMenuIds As List(Of String)
        Get
            Return _authorizedMenuIds
        End Get
    End Property

    Public Shared Function GetUserAuthorizedMenuIds(userAccount As String, ByRef erroMsg As String) As List(Of String)
        Dim menuIds As New List(Of String)
        erroMsg = ""

        Try
            If sysOleDbConn.State <> ConnectionState.Open Then
                sysOleDbConn.Open()
            End If

            Dim cmd As OleDbCommand = sysOleDbConn.CreateCommand()
            cmd.CommandTimeout = 300
            cmd.CommandType = CommandType.Text

            If userAccount = "ADMIN" Then
                cmd.CommandText = "SELECT mnuiid FROM rc_menu WHERE mnuiown = 'RC3' ORDER BY mnuiid"
            Else
                cmd.CommandText = "SELECT DISTINCT rc_menu.mnuiid FROM rc_roleqx,rc_menu " &
                                  "WHERE rc_roleqx.roleid IN (SELECT roleid FROM rc_userinrole WHERE user_account = ?) " &
                                  "AND rc_menu.mnuiown = 'RC3' AND rc_roleqx.righttype = 'RC3' " &
                                  "AND rc_roleqx.code = rc_menu.mnuiid ORDER BY rc_menu.mnuiid"
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@user_account", OleDbType.VarChar, 30).Value = userAccount
            End If

            Using reader As OleDbDataReader = cmd.ExecuteReader()
                While reader.Read()
                    menuIds.Add(reader("mnuiid").ToString())
                End While
            End Using

        Catch ex As Exception
            erroMsg = ex.Message
        Finally
            If sysOleDbConn.State = ConnectionState.Open Then
                sysOleDbConn.Close()
            End If
        End Try

        Return menuIds
    End Function

    Public Shared Function LoadMenuData(ByRef erroMsg As String) As DataTable
        erroMsg = ""
        _menuData = New DataTable("rc_menu")

        Try
            If sysOleDbConn.State <> ConnectionState.Open Then
                sysOleDbConn.Open()
            End If

            Dim da As New OleDbDataAdapter
            Dim cmd As OleDbCommand = sysOleDbConn.CreateCommand()
            cmd.CommandTimeout = 300
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuisortorder,mnuiformname " &
                              "FROM rc_menu WHERE mnuiown = 'RC3' ORDER BY mnuisortorder,mnuiid"

            da.SelectCommand = cmd
            da.Fill(_menuData)

        Catch ex As Exception
            erroMsg = ex.Message
            Return Nothing
        Finally
            If sysOleDbConn.State = ConnectionState.Open Then
                sysOleDbConn.Close()
            End If
        End Try

        Return _menuData
    End Function

    Public Shared Sub BuildMenu(menuStrip As MenuStrip, userAccount As String)
        Dim erroMsg As String = ""

        _authorizedMenuIds = GetUserAuthorizedMenuIds(userAccount, erroMsg)
        If erroMsg <> "" Then
            MessageBox.Show("加载菜单权限失败：" & erroMsg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim menuData As DataTable = LoadMenuData(erroMsg)
        If menuData Is Nothing Then
            MessageBox.Show("加载菜单数据失败：" & erroMsg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        menuStrip.Items.Clear()

        Dim isAdmin As Boolean = (userAccount = "ADMIN")
        Dim topMenus = menuData.Select("mnuiparentid = '0' OR mnuiparentid IS NULL", "mnuisortorder,mnuiid")
        For Each topMenu As DataRow In topMenus
            Dim menuId As String = topMenu("mnuiid").ToString()
            If isAdmin OrElse _authorizedMenuIds.Contains(menuId) Then
                Dim menuItem As ToolStripMenuItem = CreateMenuItem(topMenu, menuData, isAdmin)
                If menuItem IsNot Nothing Then
                    menuStrip.Items.Add(menuItem)
                End If
            End If
        Next

        AddStaticMenuItems(menuStrip)
    End Sub

    Private Shared Function CreateMenuItem(menuRow As DataRow, menuData As DataTable, isAdmin As Boolean) As ToolStripMenuItem
        Dim menuItem As New ToolStripMenuItem()
        menuItem.Name = "_" & menuRow("mnuiname").ToString()
        menuItem.Text = menuRow("mnuicaption").ToString()
        menuItem.Tag = menuRow("mnuiid").ToString()

        Dim formName As String = ""
        If menuRow.Table.Columns.Contains("mnuiformname") AndAlso menuRow("mnuiformname") IsNot DBNull.Value Then
            formName = menuRow("mnuiformname").ToString()
        End If
        menuItem.ToolTipText = formName

        Dim menuId As String = menuRow("mnuiid").ToString()
        Dim childMenus = menuData.Select("mnuiparentid = '" & menuId & "'", "mnuisortorder,mnuiid")

        If childMenus.Length > 0 Then
            For Each childRow As DataRow In childMenus
                Dim childId As String = childRow("mnuiid").ToString()
                If isAdmin OrElse _authorizedMenuIds.Contains(childId) Then
                    Dim childItem As ToolStripMenuItem = CreateMenuItem(childRow, menuData, isAdmin)
                    If childItem IsNot Nothing Then
                        menuItem.DropDownItems.Add(childItem)
                    End If
                End If
            Next

            If menuItem.DropDownItems.Count = 0 Then
                If Not String.IsNullOrEmpty(formName) Then
                    AddHandler menuItem.Click, AddressOf DynamicMenuItem_Click
                    Return menuItem
                End If
                Return Nothing
            Else
                Return menuItem
            End If
        Else
            If Not String.IsNullOrEmpty(formName) Then
                AddHandler menuItem.Click, AddressOf DynamicMenuItem_Click
            End If
            Return menuItem
        End If
    End Function

    Private Shared Sub AddStaticMenuItems(menuStrip As MenuStrip)
        If menuStrip.Items.Count > 0 Then
            Dim lastItem = menuStrip.Items(menuStrip.Items.Count - 1)
            If TypeOf lastItem Is ToolStripMenuItem Then
                lastItem.DropDownItems.Add(New ToolStripSeparator())
            End If
        End If

        Dim staticMenus As ToolStripMenuItem() = {
            CreateStaticMenuItem("_MnuiZtdl", "重新登录", AddressOf MnuiZtdl_Click),
            CreateStaticMenuItem("_MnuiExit", "退出", AddressOf ExitMenuItem_Click)
        }

        For Each staticMenu As ToolStripMenuItem In staticMenus
            If menuStrip.Items.Count > 0 Then
                CType(menuStrip.Items(menuStrip.Items.Count - 1), ToolStripMenuItem).DropDownItems.Add(staticMenu)
            Else
                menuStrip.Items.Add(staticMenu)
            End If
        Next
    End Sub

    Private Shared Function CreateStaticMenuItem(name As String, text As String, clickHandler As EventHandler) As ToolStripMenuItem
        Dim item As New ToolStripMenuItem()
        item.Name = name
        item.Text = text
        AddHandler item.Click, clickHandler
        Return item
    End Function

    Private Shared Sub DynamicMenuItem_Click(sender As Object, e As EventArgs)
        Dim menuItem = CType(sender, ToolStripMenuItem)
        Dim parentForm As Form = TryCast(menuItem.OwnerItem?.Owner?.Parent, Form)

        If parentForm Is Nothing Then
            For Each frm As Form In Application.OpenForms
                If TypeOf frm Is FrmMain Then
                    parentForm = frm
                    Exit For
                End If
            Next
        End If

        If parentForm Is Nothing Then
            MessageBox.Show("无法找到主窗口", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim formName As String = menuItem.ToolTipText
        If String.IsNullOrEmpty(formName) Then
            formName = menuItem.Tag?.ToString()
        End If

        If String.IsNullOrEmpty(formName) Then
            MessageBox.Show("菜单未配置表单名称", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If formName = "FrmCheckData" Then
            Dim rcFrm As New FrmCheckData
            rcFrm.ShowDialog()
            Return
        End If

        If formName = "FrmUserLogin" Then
            Dim rcFrm As New FrmUserLogin
            If rcFrm.ShowDialog() = DialogResult.OK Then
                Dim mainForm As FrmMain = GetMainForm()
                If mainForm IsNot Nothing Then
                    BuildMenu(mainForm.MenuStripMain, g_User_Account)
                End If
            End If
            Return
        End If

        If formName = "FrmModPwd" Then
            Dim rcFrm As New models.FrmModPwd
            rcFrm.paraOleDbConn = sysOleDbConn
            rcFrm.paraUser_Account = g_User_Account
            rcFrm.MdiParent = parentForm
            rcFrm.Show()
            Return
        End If

        Dim childForm As Form = DynamicFormFactory.CreateForm(formName)
        If childForm IsNot Nothing Then
            childForm.MdiParent = parentForm
            childForm.WindowState = FormWindowState.Maximized
            childForm.Show()
        Else
            MessageBox.Show("无法创建表单：" & formName, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Shared Sub ExitMenuItem_Click(sender As Object, e As EventArgs)
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is FrmMain Then
                frm.Close()
                Exit For
            End If
        Next
    End Sub

    Public Shared Sub MnuiZtdl_Click(sender As Object, e As EventArgs)
        Dim rcFrm As New FrmUserLogin
        If rcFrm.ShowDialog() <> DialogResult.OK Then
            Return
        End If

        Dim mainForm As FrmMain = GetMainForm()
        If mainForm IsNot Nothing Then
            MenuHelper.BuildMenu(mainForm.MenuStripMain, g_User_Account)
        End If
    End Sub

    Private Shared Function GetMainForm() As FrmMain
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is FrmMain Then
                Return CType(frm, FrmMain)
            End If
        Next
        Return Nothing
    End Function

End Class