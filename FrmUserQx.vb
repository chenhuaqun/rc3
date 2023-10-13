Imports System.Data.OleDb

Public Class FrmUserQx
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '数据更新传递
    Dim rcOleDbTrans As OleDbTransaction
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = sysOleDbConn.CreateCommand()
    '操作员姓名
    Dim strAccount As String = ""

    Public Property paraStrAccount() As String
        Get
            paraStrAccount = strAccount
        End Get
        Set(ByVal Value As String)
            strAccount = Value
        End Set
    End Property

    Private Sub FrmUserQx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        Dim j As Integer = 1

        '预选单位编码数据
        Try
            sysOleDbConn.Open()
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT dwdm,dwmc FROM rc_dwdm WHERE dwdm IN (SELECT code AS dwdm from rc_userqx WHERE righttype = 'DWDM' and User_Account = ?) order by dwdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = strAccount
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_dwdm") IsNot Nothing Then
                rcDataset.Tables("rc_dwdm").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_dwdm")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            sysOleDbConn.Close()
        End Try
        For i = 0 To rcDataset.Tables("rc_dwdm").Rows.Count - 1
            ListBoxYixuanDwdm.Items.Add(rcDataset.Tables("rc_dwdm").Rows(i).Item("dwdm") & " " & rcDataset.Tables("rc_dwdm").Rows(i).Item("dwmc"))
        Next
        Try
            sysOleDbConn.Open()
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT dwdm,dwmc FROM rc_dwdm WHERE dwdm not in (SELECT code AS dwdm FROM rc_userqx WHERE righttype = 'DWDM' and User_Account = ?) order by dwdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = strAccount
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_dwdm") IsNot Nothing Then
                rcDataset.Tables("rc_dwdm").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_dwdm")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            sysOleDbConn.Close()
        End Try
        For i = 0 To rcDataset.Tables("rc_dwdm").Rows.Count - 1
            ListBoxYuxuanDwdm.Items.Add(rcDataset.Tables("rc_dwdm").Rows(i).Item("dwdm") & " " & rcDataset.Tables("rc_dwdm").Rows(i).Item("dwmc"))
        Next
        '取ROLE的rc_roles数据()
        Try
            sysOleDbConn.Open()
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_roles WHERE roleid in (SELECT roleid FROM rc_userinrole WHERE User_Account = ?) ORDER BY roleid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = strAccount
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_roles") IsNot Nothing Then
                rcDataset.Tables("rc_roles").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_roles")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            sysOleDbConn.Close()
        End Try
        For i = 0 To rcDataset.Tables("rc_roles").Rows.Count - 1
            ListBoxYixuanRole.Items.Add(rcDataset.Tables("rc_roles").Rows(i).Item("roleid") & " " & rcDataset.Tables("rc_roles").Rows(i).Item("rolename"))
        Next
        Try
            sysOleDbConn.Open()
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_roles WHERE roleid not in (SELECT roleid FROM rc_userinrole WHERE User_Account = ?) ORDER BY roleid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = strAccount
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_roles") IsNot Nothing Then
                rcDataset.Tables("rc_roles").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_roles")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            sysOleDbConn.Close()
        End Try
        For i = 0 To rcDataset.Tables("rc_roles").Rows.Count - 1
            ListBoxYuxuanRole.Items.Add(rcDataset.Tables("rc_roles").Rows(i).Item("roleid") & " " & rcDataset.Tables("rc_roles").Rows(i).Item("rolename"))
        Next
        '预选物料类别权限
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT lbdm,lbmc FROM rc_cplb WHERE lbdm IN (SELECT code AS lbdm from rc_userqx WHERE righttype = 'LBDM' and User_Account = ?) order by lbdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = strAccount
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_cplb") IsNot Nothing Then
                rcDataset.Tables("rc_cplb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_cplb")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        For i = 0 To rcDataset.Tables("rc_cplb").Rows.Count - 1
            ListBoxYixuanLbdm.Items.Add(rcDataset.Tables("rc_cplb").Rows(i).Item("lbdm") & " " & rcDataset.Tables("rc_cplb").Rows(i).Item("lbmc"))
        Next
        '已选物料类别权限
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT lbdm,lbmc FROM rc_cplb WHERE lbdm not in (SELECT code AS lbdm FROM rc_userqx WHERE righttype = 'LBDM' and User_Account = ?) order by lbdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = strAccount
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_cplb") IsNot Nothing Then
                rcDataset.Tables("rc_cplb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_cplb")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        For i = 0 To rcDataset.Tables("rc_cplb").Rows.Count - 1
            ListBoxYuxuanLbdm.Items.Add(rcDataset.Tables("rc_cplb").Rows(i).Item("lbdm") & " " & rcDataset.Tables("rc_cplb").Rows(i).Item("lbmc"))
        Next
        '预选部门编码
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT bmdm,bmmc FROM rc_bmxx WHERE bmdm IN (SELECT code AS bmdm from rc_userqx WHERE righttype = 'BMDM' and User_Account = ?) ORDER BY bmdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = strAccount
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_bmxx") IsNot Nothing Then
                rcDataset.Tables("rc_bmxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_bmxx")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        For i = 0 To rcDataset.Tables("rc_bmxx").Rows.Count - 1
            ListBoxYixuanBmdm.Items.Add(rcDataset.Tables("rc_bmxx").Rows(i).Item("bmdm") & " " & rcDataset.Tables("rc_bmxx").Rows(i).Item("bmmc"))
        Next
        '已选部门编码
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT bmdm,bmmc FROM rc_bmxx WHERE bmdm not in (SELECT code AS bmdm FROM rc_userqx WHERE righttype = 'BMDM' and User_Account = ?) ORDER BY bmdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = strAccount
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_bmxx") IsNot Nothing Then
                rcDataset.Tables("rc_bmxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_bmxx")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        For i = 0 To rcDataset.Tables("rc_bmxx").Rows.Count - 1
            ListBoxYuxuanBmdm.Items.Add(rcDataset.Tables("rc_bmxx").Rows(i).Item("bmdm") & " " & rcDataset.Tables("rc_bmxx").Rows(i).Item("bmmc"))
        Next
        '预选凭证类别编码
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxmc FROM rc_lx WHERE pzlxdm IN (SELECT code AS pzlxdm from rc_userqx WHERE righttype = 'PZLX' and User_Account = ?) GROUP BY pzlxdm,pzlxmc ORDER BY pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = strAccount
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_lx") IsNot Nothing Then
                rcDataset.Tables("rc_lx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_lx")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        For i = 0 To rcDataset.Tables("rc_lx").Rows.Count - 1
            ListBoxYixuanPzlx.Items.Add(rcDataset.Tables("rc_lx").Rows(i).Item("pzlxdm") & " " & rcDataset.Tables("rc_lx").Rows(i).Item("pzlxmc"))
        Next
        '已选凭证类别编码
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxmc FROM rc_lx WHERE pzlxdm not in (SELECT code AS pzlxdm FROM rc_userqx WHERE righttype = 'PZLX' and User_Account = ?) GROUP BY pzlxdm,pzlxmc ORDER BY pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = strAccount
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_lx") IsNot Nothing Then
                rcDataset.Tables("rc_lx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_lx")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        For i = 0 To rcDataset.Tables("rc_lx").Rows.Count - 1
            ListBoxYuxuanPzlx.Items.Add(rcDataset.Tables("rc_lx").Rows(i).Item("pzlxdm") & " " & rcDataset.Tables("rc_lx").Rows(i).Item("pzlxmc"))
        Next

    End Sub

    Private Sub ListBoxYuxuanDwdm_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBoxYuxuanDwdm.DoubleClick
        If Me.ListBoxYuxuanDwdm.SelectedItem IsNot Nothing Then
            Me.ListBoxYixuanDwdm.Items.Add(Me.ListBoxYuxuanDwdm.SelectedItem)
            Me.ListBoxYuxuanDwdm.Items.Remove(Me.ListBoxYuxuanDwdm.SelectedItem)
        End If
    End Sub

    Private Sub ListBoxYixuanDwdm_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBoxYixuanDwdm.DoubleClick
        If Me.ListBoxYixuanDwdm.SelectedItem IsNot Nothing Then
            Me.ListBoxYuxuanDwdm.Items.Add(Me.ListBoxYixuanDwdm.SelectedItem)
            Me.ListBoxYixuanDwdm.Items.Remove(Me.ListBoxYixuanDwdm.SelectedItem)
        End If
    End Sub

    Private Sub BtnSelectAllDwdm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectAllDwdm.Click
        Dim i As Integer
        For i = 0 To Me.ListBoxYuxuanDwdm.Items.Count - 1
            Me.ListBoxYixuanDwdm.Items.Add(Me.ListBoxYuxuanDwdm.Items(0))
            Me.ListBoxYuxuanDwdm.Items.Remove(Me.ListBoxYuxuanDwdm.Items(0))
        Next
    End Sub

    Private Sub BtnSelectOneDwdm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectOneDwdm.Click
        If Me.ListBoxYuxuanDwdm.SelectedItems.Count > 0 Then
            Me.ListBoxYixuanDwdm.Items.Add(Me.ListBoxYuxuanDwdm.SelectedItem)
            Me.ListBoxYuxuanDwdm.Items.Remove(Me.ListBoxYuxuanDwdm.SelectedItem)
        End If
    End Sub

    Private Sub BtnUnSelectOneDwdm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUnSelectOneDwdm.Click
        If Me.ListBoxYixuanDwdm.SelectedItems.Count > 0 Then
            Me.ListBoxYuxuanDwdm.Items.Add(Me.ListBoxYixuanDwdm.SelectedItem)
            Me.ListBoxYixuanDwdm.Items.Remove(Me.ListBoxYixuanDwdm.SelectedItem)
        End If
    End Sub

    Private Sub BtnUnSelectAllDwdm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUnSelectAllDwdm.Click
        Dim i As Integer
        For i = 0 To Me.ListBoxYixuanDwdm.Items.Count - 1
            Me.ListBoxYuxuanDwdm.Items.Add(Me.ListBoxYixuanDwdm.Items(0))
            Me.ListBoxYixuanDwdm.Items.Remove(Me.ListBoxYixuanDwdm.Items(0))
        Next
    End Sub

    Private Sub ListBoxYuxuanRole_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBoxYuxuanRole.DoubleClick
        If Me.ListBoxYuxuanRole.SelectedItem IsNot Nothing Then
            Me.ListBoxYixuanRole.Items.Add(Me.ListBoxYuxuanRole.SelectedItem)
            Me.ListBoxYuxuanRole.Items.Remove(Me.ListBoxYuxuanRole.SelectedItem)
        End If
    End Sub

    Private Sub ListBoxYixuanRole_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBoxYixuanRole.DoubleClick
        If Me.ListBoxYixuanRole.SelectedItem IsNot Nothing Then
            Me.ListBoxYuxuanRole.Items.Add(Me.ListBoxYixuanRole.SelectedItem)
            Me.ListBoxYixuanRole.Items.Remove(Me.ListBoxYixuanRole.SelectedItem)
        End If
    End Sub

    Private Sub BtnSelectAllRole_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectAllRole.Click
        Dim i As Integer
        For i = 0 To Me.ListBoxYuxuanRole.Items.Count - 1
            Me.ListBoxYixuanRole.Items.Add(Me.ListBoxYuxuanRole.Items(0))
            Me.ListBoxYuxuanRole.Items.Remove(Me.ListBoxYuxuanRole.Items(0))
        Next
    End Sub

    Private Sub BtnSelectOneRole_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectOneRole.Click
        If Me.ListBoxYuxuanRole.SelectedItems.Count > 0 Then
            Me.ListBoxYixuanRole.Items.Add(Me.ListBoxYuxuanRole.SelectedItem)
            Me.ListBoxYuxuanRole.Items.Remove(Me.ListBoxYuxuanRole.SelectedItem)
        End If
    End Sub

    Private Sub BtnUnSelectOneRole_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUnSelectOneRole.Click
        If Me.ListBoxYixuanRole.SelectedItems.Count > 0 Then
            Me.ListBoxYuxuanRole.Items.Add(Me.ListBoxYixuanRole.SelectedItem)
            Me.ListBoxYixuanRole.Items.Remove(Me.ListBoxYixuanRole.SelectedItem)
        End If
    End Sub

    Private Sub BtnUnSelectAllRole_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUnSelectAllRole.Click
        Dim i As Integer
        For i = 0 To Me.ListBoxYixuanRole.Items.Count - 1
            Me.ListBoxYuxuanRole.Items.Add(Me.ListBoxYixuanRole.Items(0))
            Me.ListBoxYixuanRole.Items.Remove(Me.ListBoxYixuanRole.Items(0))
        Next
    End Sub

    Private Sub ListBoxYuxuanLbdm_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBoxYuxuanLbdm.DoubleClick
        If Me.ListBoxYuxuanLbdm.SelectedItem IsNot Nothing Then
            Me.ListBoxYixuanLbdm.Items.Add(Me.ListBoxYuxuanLbdm.SelectedItem)
            Me.ListBoxYuxuanLbdm.Items.Remove(Me.ListBoxYuxuanLbdm.SelectedItem)
        End If
    End Sub

    Private Sub ListBoxYixuanLbdm_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBoxYixuanLbdm.DoubleClick
        If Me.ListBoxYixuanLbdm.SelectedItem IsNot Nothing Then
            Me.ListBoxYuxuanLbdm.Items.Add(Me.ListBoxYixuanLbdm.SelectedItem)
            Me.ListBoxYixuanLbdm.Items.Remove(Me.ListBoxYixuanLbdm.SelectedItem)
        End If
    End Sub

    Private Sub BtnSelectAllLbdm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectAllLbdm.Click
        Dim i As Integer
        For i = 0 To Me.ListBoxYuxuanLbdm.Items.Count - 1
            Me.ListBoxYixuanLbdm.Items.Add(Me.ListBoxYuxuanLbdm.Items(0))
            Me.ListBoxYuxuanLbdm.Items.Remove(Me.ListBoxYuxuanLbdm.Items(0))
        Next
    End Sub

    Private Sub BtnSelectOneLbdm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectOneLbdm.Click
        If Me.ListBoxYuxuanLbdm.SelectedItems.Count > 0 Then
            Me.ListBoxYixuanLbdm.Items.Add(Me.ListBoxYuxuanLbdm.SelectedItem)
            Me.ListBoxYuxuanLbdm.Items.Remove(Me.ListBoxYuxuanLbdm.SelectedItem)
        End If
    End Sub

    Private Sub BtnUnSelectOneLbdm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUnSelectOneLbdm.Click
        If Me.ListBoxYixuanLbdm.SelectedItems.Count > 0 Then
            Me.ListBoxYuxuanLbdm.Items.Add(Me.ListBoxYixuanLbdm.SelectedItem)
            Me.ListBoxYixuanLbdm.Items.Remove(Me.ListBoxYixuanLbdm.SelectedItem)
        End If
    End Sub

    Private Sub BtnUnSelectAllLbdm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUnSelectAllLbdm.Click
        Dim i As Integer
        For i = 0 To Me.ListBoxYixuanLbdm.Items.Count - 1
            Me.ListBoxYuxuanLbdm.Items.Add(Me.ListBoxYixuanLbdm.Items(0))
            Me.ListBoxYixuanLbdm.Items.Remove(Me.ListBoxYixuanLbdm.Items(0))
        Next
    End Sub

    Private Sub ListBoxYuxuanBmdm_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBoxYuxuanBmdm.DoubleClick
        If Me.ListBoxYuxuanBmdm.SelectedItem IsNot Nothing Then
            Me.ListBoxYixuanBmdm.Items.Add(Me.ListBoxYuxuanBmdm.SelectedItem)
            Me.ListBoxYuxuanBmdm.Items.Remove(Me.ListBoxYuxuanBmdm.SelectedItem)
        End If
    End Sub

    Private Sub ListBoxYixuanBmdm_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBoxYixuanBmdm.DoubleClick
        If Me.ListBoxYixuanBmdm.SelectedItem IsNot Nothing Then
            Me.ListBoxYuxuanBmdm.Items.Add(Me.ListBoxYixuanBmdm.SelectedItem)
            Me.ListBoxYixuanBmdm.Items.Remove(Me.ListBoxYixuanBmdm.SelectedItem)
        End If
    End Sub

    Private Sub BtnSelectAllBmdm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectAllBmdm.Click
        Dim i As Integer
        For i = 0 To Me.ListBoxYuxuanBmdm.Items.Count - 1
            Me.ListBoxYixuanBmdm.Items.Add(Me.ListBoxYuxuanBmdm.Items(0))
            Me.ListBoxYuxuanBmdm.Items.Remove(Me.ListBoxYuxuanBmdm.Items(0))
        Next
    End Sub

    Private Sub BtnSelectOneBmdm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectOneBmdm.Click
        If Me.ListBoxYuxuanBmdm.SelectedItems.Count > 0 Then
            Me.ListBoxYixuanBmdm.Items.Add(Me.ListBoxYuxuanBmdm.SelectedItem)
            Me.ListBoxYuxuanBmdm.Items.Remove(Me.ListBoxYuxuanBmdm.SelectedItem)
        End If
    End Sub

    Private Sub BtnUnSelectOneBmdm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUnSelectOneBmdm.Click
        If Me.ListBoxYixuanBmdm.SelectedItems.Count > 0 Then
            Me.ListBoxYuxuanBmdm.Items.Add(Me.ListBoxYixuanBmdm.SelectedItem)
            Me.ListBoxYixuanBmdm.Items.Remove(Me.ListBoxYixuanBmdm.SelectedItem)
        End If
    End Sub

    Private Sub BtnUnSelectAllBmdm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUnSelectAllBmdm.Click
        Dim i As Integer
        For i = 0 To Me.ListBoxYixuanBmdm.Items.Count - 1
            Me.ListBoxYuxuanBmdm.Items.Add(Me.ListBoxYixuanBmdm.Items(0))
            Me.ListBoxYixuanBmdm.Items.Remove(Me.ListBoxYixuanBmdm.Items(0))
        Next
    End Sub

    Private Sub ListBoxYuxuanPzlx_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBoxYuxuanPzlx.DoubleClick
        If Me.ListBoxYuxuanPzlx.SelectedItem IsNot Nothing Then
            Me.ListBoxYixuanPzlx.Items.Add(Me.ListBoxYuxuanPzlx.SelectedItem)
            Me.ListBoxYuxuanPzlx.Items.Remove(Me.ListBoxYuxuanPzlx.SelectedItem)
        End If
    End Sub

    Private Sub ListBoxYixuanPzlx_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBoxYixuanPzlx.DoubleClick
        If Me.ListBoxYixuanPzlx.SelectedItem IsNot Nothing Then
            Me.ListBoxYuxuanPzlx.Items.Add(Me.ListBoxYixuanPzlx.SelectedItem)
            Me.ListBoxYixuanPzlx.Items.Remove(Me.ListBoxYixuanPzlx.SelectedItem)
        End If
    End Sub

    Private Sub BtnSelectAllPzlx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectAllPzlx.Click
        Dim i As Integer
        For i = 0 To Me.ListBoxYuxuanPzlx.Items.Count - 1
            Me.ListBoxYixuanPzlx.Items.Add(Me.ListBoxYuxuanPzlx.Items(0))
            Me.ListBoxYuxuanPzlx.Items.Remove(Me.ListBoxYuxuanPzlx.Items(0))
        Next
    End Sub

    Private Sub BtnSelectOnePzlx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectOnePzlx.Click
        If Me.ListBoxYuxuanPzlx.SelectedItems.Count > 0 Then
            Me.ListBoxYixuanPzlx.Items.Add(Me.ListBoxYuxuanPzlx.SelectedItem)
            Me.ListBoxYuxuanPzlx.Items.Remove(Me.ListBoxYuxuanPzlx.SelectedItem)
        End If
    End Sub

    Private Sub BtnUnSelectOnePzlx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUnSelectOnePzlx.Click
        If Me.ListBoxYixuanPzlx.SelectedItems.Count > 0 Then
            Me.ListBoxYuxuanPzlx.Items.Add(Me.ListBoxYixuanPzlx.SelectedItem)
            Me.ListBoxYixuanPzlx.Items.Remove(Me.ListBoxYixuanPzlx.SelectedItem)
        End If
    End Sub

    Private Sub BtnUnSelectAllPzlx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUnSelectAllPzlx.Click
        Dim i As Integer
        For i = 0 To Me.ListBoxYixuanPzlx.Items.Count - 1
            Me.ListBoxYuxuanPzlx.Items.Add(Me.ListBoxYixuanPzlx.Items(0))
            Me.ListBoxYixuanPzlx.Items.Remove(Me.ListBoxYixuanPzlx.Items(0))
        Next
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim i As Integer

        '删除数据
        Try
            sysOleDbConn.Open()
            rcOleDbTrans = sysOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandText = "DELETE FROM rc_userqx WHERE User_Account = ? AND righttype = 'DWDM'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = strAccount
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "DELETE FROM rc_userinrole WHERE User_Account = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = strAccount
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
            sysOleDbConn.Close()
        End Try
        '删除数据
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandText = "DELETE FROM rc_userqx WHERE User_Account = ? AND righttype = 'LBDM'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = strAccount
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
        '删除数据
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandText = "DELETE FROM rc_userqx WHERE User_Account = ? AND righttype = 'BMDM'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = strAccount
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
        '删除数据
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandText = "DELETE FROM rc_userqx WHERE User_Account = ? AND righttype = 'PZLX'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = strAccount
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
        '添加单位编码数据
        For i = 0 To Me.ListBoxYixuanDwdm.Items.Count - 1
            sysOleDbConn.Open()
            rcOleDbTrans = sysOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            Try
                rcOleDbCommand.CommandText = "INSERT INTO rc_userqx (User_Account,code,righttype) VALUES (?,?,'DWDM')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = strAccount
                rcOleDbCommand.Parameters.Add("@code", OleDbType.VarChar, 20).Value = Mid(Me.ListBoxYixuanDwdm.Items(i), 1, InStr(Me.ListBoxYixuanDwdm.Items(i), " ") - 1)
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
                sysOleDbConn.Close()
            End Try
        Next
        '添加库存管理功能权限
        For i = 0 To Me.ListBoxYixuanRole.Items.Count - 1
            sysOleDbConn.Open()
            rcOleDbTrans = sysOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            Try
                rcOleDbCommand.CommandText = "INSERT INTO rc_userinrole (User_Account,roleid) VALUES (?,?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = strAccount
                rcOleDbCommand.Parameters.Add("@roleid", OleDbType.VarChar, 20).Value = Mid(Me.ListBoxYixuanRole.Items(i), 1, InStr(Me.ListBoxYixuanRole.Items(i), " ") - 1)
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
                sysOleDbConn.Close()
            End Try
        Next
        '添加物料类别权限
        For i = 0 To Me.ListBoxYixuanLbdm.Items.Count - 1
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            Try
                rcOleDbCommand.CommandText = "INSERT INTO rc_userqx (User_Account,code,righttype) VALUES (?,?,'LBDM')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = strAccount
                rcOleDbCommand.Parameters.Add("@code", OleDbType.VarChar, 20).Value = Mid(Me.ListBoxYixuanLbdm.Items(i), 1, InStr(Me.ListBoxYixuanLbdm.Items(i), " ") - 1)
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
        Next
        '添加部门编码
        For i = 0 To Me.ListBoxYixuanBmdm.Items.Count - 1
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            Try
                rcOleDbCommand.CommandText = "INSERT INTO rc_userqx (User_Account,code,righttype) VALUES (?,?,'BMDM')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = strAccount
                rcOleDbCommand.Parameters.Add("@code", OleDbType.VarChar, 20).Value = Mid(Me.ListBoxYixuanBmdm.Items(i), 1, InStr(Me.ListBoxYixuanBmdm.Items(i), " ") - 1)
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
        Next
        '添加单据类型
        For i = 0 To Me.ListBoxYixuanPzlx.Items.Count - 1
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            Try
                rcOleDbCommand.CommandText = "INSERT INTO rc_userqx (User_Account,code,righttype) VALUES (?,?,'PZLX')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = strAccount
                rcOleDbCommand.Parameters.Add("@code", OleDbType.VarChar, 20).Value = Mid(Me.ListBoxYixuanPzlx.Items(i), 1, InStr(Me.ListBoxYixuanPzlx.Items(i), " ") - 1)
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
        Next

    End Sub
End Class