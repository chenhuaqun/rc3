Imports System.Data.OleDb

Public Class FrmOption
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '数据更新传递
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Private Sub FrmOption_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            '取单据类型数据
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx Where lxgs = '记账凭证' AND kjnd = ? ORDER BY pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@year", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_lx") IsNot Nothing Then
                Me.rcDataset.Tables("rc_lx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_lx")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_lx").Rows.Count = 0 Then
            MsgBox("请在单据类型定义中的设置记账凭证的单据类型。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        '绑定凭证类型简称
        BindDropDownList(CmbPzlxjc, rcDataset.Tables("rc_lx"), "pzlxdm", "pzlxjc")
        '取会计期间数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT ny FROM rc_yj ORDER BY ny"
            rcOleDbCommand.Parameters.Clear()
            'rcOleDbCommand.Parameters.Add("@year", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_yj") IsNot Nothing Then
                Me.rcDataset.Tables("rc_yj").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_yj")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_yj").Rows.Count = 0 Then
            MsgBox("请先定义会计期间。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        '绑定凭证类型简称
        BindDropDownList(CmbFcsp, rcDataset.Tables("rc_yj"), "ny", "ny")
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT paradblvalue FROM rc_para WHERE dwdm = ? AND paraid = '增值税默认税率' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("paradblvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtDefaultShlv.Text = rcDataset.Tables("rc_para").Rows(0).Item("paradblvalue")
                End If
            End If
            rcOleDbCommand.CommandText = "SELECT parastrvalue FROM rc_para WHERE dwdm = ? AND paraid = '单据打印中抬头使用的单位名称' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TextBox3.Text = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
            End If
            rcOleDbCommand.CommandText = "SELECT parastrvalue FROM rc_para WHERE dwdm = ? AND paraid = '总账应收账款科目编码' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtYszk.Text = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
            End If
            rcOleDbCommand.CommandText = "SELECT parastrvalue FROM rc_para WHERE dwdm = ? AND paraid = '总账应付账款科目编码' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtYfzk.Text = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
            End If
            rcOleDbCommand.CommandText = "SELECT parastrvalue FROM rc_para WHERE dwdm = ? AND paraid = '总账主营业务收入科目编码' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtZyywsr.Text = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
            End If
            rcOleDbCommand.CommandText = "SELECT parastrvalue FROM rc_para WHERE dwdm = ? AND paraid = '总账主营业务成本科目编码' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtZyywcb.Text = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
            End If
            rcOleDbCommand.CommandText = "SELECT parastrvalue FROM rc_para WHERE dwdm = ? AND paraid = '总账原材料科目编码' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtYcl.Text = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
            End If
            '总账库存商品科目
            rcOleDbCommand.CommandText = "SELECT parastrvalue FROM rc_para WHERE dwdm = ? AND paraid = '总账库存商品科目编码' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtKcspKm.Text = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
            End If
            '总账发出商品科目
            rcOleDbCommand.CommandText = "SELECT parastrvalue FROM rc_para WHERE dwdm = ? AND paraid = '总账发出商品科目编码' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtFcspKm.Text = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
            End If
            '总账自制半成品科目
            rcOleDbCommand.CommandText = "SELECT parastrvalue FROM rc_para WHERE dwdm = ? AND paraid = '总账自制半成品科目编码' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtZzbcpKm.Text = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
            End If
            rcOleDbCommand.CommandText = "SELECT parastrvalue FROM rc_para WHERE dwdm = ? AND paraid = '总账生产成本科目编码' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtSccbKm.Text = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
            End If
            rcOleDbCommand.CommandText = "SELECT parastrvalue FROM rc_para WHERE dwdm = ? AND paraid = '凭证生成中使用的凭证类型' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.CmbPzlxjc.SelectedValue = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
            End If
            rcOleDbCommand.CommandText = "SELECT paradblvalue FROM rc_para WHERE dwdm = ? AND paraid = '套打格式打印销售单' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("paradblvalue").GetType.ToString <> "System.DBNull" Then
                    Me.ChbXsdDy.Checked = rcDataset.Tables("rc_para").Rows(0).Item("paradblvalue")
                End If
            End If
            rcOleDbCommand.CommandText = "SELECT parastrvalue FROM rc_para WHERE dwdm = ? AND paraid = 'Anyi311账务系统路径' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtGlPath.Text = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
            End If
            rcOleDbCommand.CommandText = "SELECT parastrvalue FROM rc_para WHERE dwdm = ? AND paraid = '本位币币种编码' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtWbdm.Text = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
            End If
            '发出商品启用会计期间
            rcOleDbCommand.CommandText = "SELECT parastrvalue FROM rc_para WHERE dwdm = ? AND paraid = '发出商品启用会计期间' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.CmbFcsp.SelectedValue = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
            End If

            rcOleDbCommand.CommandText = "SELECT * FROM rc_para Where dwdm = ? And (paraid = 'NCACCOUNTINGBOOK' or paraid = 'NCHOST' or paraid = 'NCSERVICE_NAME' or paraid = 'NCUser_ID' or paraid = 'NCPASSWORD') ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 5 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtNCAccountingBook.Text = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtNCHost.Text = rcDataset.Tables("rc_para").Rows(1).Item("parastrvalue")
                End If
                If rcDataset.Tables("rc_para").Rows(1).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtNCPwd.Text = rcDataset.Tables("rc_para").Rows(2).Item("parastrvalue")
                End If
                If rcDataset.Tables("rc_para").Rows(2).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtNCService_Name.Text = rcDataset.Tables("rc_para").Rows(3).Item("parastrvalue")
                End If
                If rcDataset.Tables("rc_para").Rows(3).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtNCUser_ID.Text = rcDataset.Tables("rc_para").Rows(4).Item("parastrvalue")
                End If
            End If
            'NC服务器的Servlet的URL地址
            rcOleDbCommand.CommandText = "SELECT * FROM rc_para Where dwdm = ? AND paraid = 'NC服务器的Servlet的URL地址' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtNcServletUrl.Text = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
            End If
            'NC用户编码
            rcOleDbCommand.CommandText = "SELECT * FROM rc_para Where dwdm = ? AND paraid = 'NC用户编码' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtNCUserAccount.Text = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
            End If
            rcOleDbCommand.CommandText = "SELECT * FROM rc_para Where dwdm = ? And (paraid = 'U8Acc_ID' or paraid = 'U8HOST' or paraid = 'U8User_ID' or paraid = 'U8PASSWORD') ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 5 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtU8Acc_ID.Text = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                End If
                If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtU8Host.Text = rcDataset.Tables("rc_para").Rows(1).Item("parastrvalue")
                End If
                If rcDataset.Tables("rc_para").Rows(1).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtU8Pwd.Text = rcDataset.Tables("rc_para").Rows(2).Item("parastrvalue")
                End If
                If rcDataset.Tables("rc_para").Rows(3).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                    Me.TxtU8User_ID.Text = rcDataset.Tables("rc_para").Rows(4).Item("parastrvalue")
                End If
            End If
            rcOleDbCommand.CommandText = "SELECT paradblvalue FROM rc_para WHERE dwdm = ? AND paraid = '是否按成本域计算成本' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("paradblvalue").GetType.ToString <> "System.DBNull" Then
                    Me.ChbCostRegion.Checked = rcDataset.Tables("rc_para").Rows(0).Item("paradblvalue")
                End If
            End If
            rcOleDbCommand.CommandText = "SELECT paradblvalue FROM rc_para WHERE dwdm = ? AND paraid = '按成本要素独立分配成本' ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
            If rcDataset.Tables("rc_para").Rows.Count = 1 Then
                If rcDataset.Tables("rc_para").Rows(0).Item("paradblvalue").GetType.ToString <> "System.DBNull" Then
                    Me.ChbCostElements.Checked = rcDataset.Tables("rc_para").Rows(0).Item("paradblvalue")
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message)
            Return
        Finally
            rcOleDbConn.Close()
        End Try
    End Sub

#Region "应收账款科目编码的事件"

    Private Sub TxtYszk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtYszk.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "gl_kmxx"
                    .paraField1 = "kmdm"
                    .paraField2 = "kmmc"
                    .paraField3 = "kmsm"
                    .paraCondition = "0=0"
                    .paraOrderField = "kmdm"
                    .paraTitle = "科目"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtYszk.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtYszk_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtYszk.Validating
        If Not String.IsNullOrEmpty(Me.TxtYszk.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM gl_kmxx WHERE (kmdm = ?) AND NOT EXISTS (SELECT 1 FROM gl_kmxx aa WHERE aa.parentid = gl_kmxx.kmdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtYszk.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("gl_kmxx") IsNot Nothing Then
                    Me.rcDataset.Tables("gl_kmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "gl_kmxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("gl_kmxx").Rows.Count > 0 Then
                TxtYszk.Text = Trim(rcDataset.Tables("gl_kmxx").Rows(0).Item("kmdm"))
            Else
                MsgBox("科目编码不存在或非明细科目。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                e.Cancel = True
                Return
            End If
        End If
    End Sub

#End Region

#Region "应付账款科目编码的事件"

    Private Sub TxtYfzk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtYfzk.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "gl_kmxx"
                    .paraField1 = "kmdm"
                    .paraField2 = "kmmc"
                    .paraField3 = "kmsm"
                    .paraCondition = "0=0"
                    .paraOrderField = "kmdm"
                    .paraTitle = "科目"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtYfzk.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtYfzk_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtYfzk.Validating
        If Not String.IsNullOrEmpty(Me.TxtYfzk.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM gl_kmxx WHERE (kmdm = ?) AND NOT EXISTS (SELECT 1 FROM gl_kmxx aa WHERE aa.parentid = gl_kmxx.kmdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtYfzk.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("gl_kmxx") IsNot Nothing Then
                    Me.rcDataset.Tables("gl_kmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "gl_kmxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("gl_kmxx").Rows.Count > 0 Then
                TxtYfzk.Text = Trim(rcDataset.Tables("gl_kmxx").Rows(0).Item("kmdm"))
            Else
                MsgBox("科目编码不存在或非明细科目。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                e.Cancel = True
                Return
            End If
        End If
    End Sub

#End Region

#Region "主营业务收入科目编码的事件"

    Private Sub TxtZyywsr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtZyywsr.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "gl_kmxx"
                    .paraField1 = "kmdm"
                    .paraField2 = "kmmc"
                    .paraField3 = "kmsm"
                    .paraCondition = "0=0"
                    .paraOrderField = "kmdm"
                    .paraTitle = "科目"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtZyywsr.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtZyywsr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtZyywsr.Validating
        If Not String.IsNullOrEmpty(Me.TxtZyywsr.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM gl_kmxx WHERE (kmdm = ?) AND NOT EXISTS (SELECT 1 FROM gl_kmxx aa WHERE aa.parentid = gl_kmxx.kmdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtZyywsr.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("gl_kmxx") IsNot Nothing Then
                    Me.rcDataset.Tables("gl_kmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "gl_kmxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("gl_kmxx").Rows.Count > 0 Then
                TxtZyywsr.Text = Trim(rcDataset.Tables("gl_kmxx").Rows(0).Item("kmdm"))
            Else
                MsgBox("科目编码不存在或非明细科目。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                e.Cancel = True
                Return
            End If
        End If
    End Sub

#End Region

#Region "主营业务成本科目编码的事件"

    Private Sub TxtZyywcb_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtZyywcb.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "gl_kmxx"
                    .paraField1 = "kmdm"
                    .paraField2 = "kmmc"
                    .paraField3 = "kmsm"
                    .paraCondition = "0=0"
                    .paraOrderField = "kmdm"
                    .paraTitle = "科目"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtZyywcb.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtZyywcb_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtZyywcb.Validating
        If Not String.IsNullOrEmpty(Me.TxtZyywcb.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM gl_kmxx WHERE (kmdm = ?) AND NOT EXISTS (SELECT 1 FROM gl_kmxx aa WHERE aa.parentid = gl_kmxx.kmdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtZyywcb.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("gl_kmxx") IsNot Nothing Then
                    Me.rcDataset.Tables("gl_kmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "gl_kmxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("gl_kmxx").Rows.Count > 0 Then
                TxtZyywcb.Text = Trim(rcDataset.Tables("gl_kmxx").Rows(0).Item("kmdm"))
            Else
                MsgBox("科目编码不存在或非明细科目。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                e.Cancel = True
                Return
            End If
        End If
    End Sub

#End Region

#Region "原材料科目编码的事件"

    Private Sub TxtYcl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtYcl.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "gl_kmxx"
                    .paraField1 = "kmdm"
                    .paraField2 = "kmmc"
                    .paraField3 = "kmsm"
                    .paraCondition = "0=0"
                    .paraOrderField = "kmdm"
                    .paraTitle = "科目"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtYcl.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtYcl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtYcl.Validating
        If Not String.IsNullOrEmpty(Me.TxtYcl.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM gl_kmxx WHERE (kmdm = ?) AND NOT EXISTS (SELECT 1 FROM gl_kmxx aa WHERE aa.parentid = gl_kmxx.kmdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtYcl.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("gl_kmxx") IsNot Nothing Then
                    Me.rcDataset.Tables("gl_kmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "gl_kmxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("gl_kmxx").Rows.Count > 0 Then
                TxtYcl.Text = Trim(rcDataset.Tables("gl_kmxx").Rows(0).Item("kmdm"))
            Else
                MsgBox("科目编码不存在或非明细科目。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                e.Cancel = True
                Return
            End If
        End If
    End Sub

#End Region

#Region "库存商品科目编码的事件"

    Private Sub TxtKcsp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtKcspKm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .ParaOleDbConn = rcOleDbConn
                    .ParaTableName = "gl_kmxx"
                    .ParaField1 = "kmdm"
                    .ParaField2 = "kmmc"
                    .ParaField3 = "kmsm"
                    .ParaCondition = "0=0"
                    .ParaOrderField = "kmdm"
                    .ParaTitle = "科目"
                    .ParaOldValue = ""
                    .ParaAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtKcspKm.Text = Trim(.ParaField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtKcsp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtKcspKm.Validating
        If Not String.IsNullOrEmpty(Me.TxtKcspKm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM gl_kmxx WHERE (kmdm = ?) AND NOT EXISTS (SELECT 1 FROM gl_kmxx aa WHERE aa.parentid = gl_kmxx.kmdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKcspKm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("gl_kmxx") IsNot Nothing Then
                    Me.rcDataset.Tables("gl_kmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "gl_kmxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("gl_kmxx").Rows.Count > 0 Then
                TxtKcspKm.Text = Trim(rcDataset.Tables("gl_kmxx").Rows(0).Item("kmdm"))
            Else
                MsgBox("科目编码不存在或非明细科目。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                e.Cancel = True
                Return
            End If
        End If
    End Sub

#End Region

#Region "发出商品科目编码的事件"

    Private Sub TxtFcspKm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFcspKm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .ParaOleDbConn = rcOleDbConn
                    .ParaTableName = "gl_kmxx"
                    .ParaField1 = "kmdm"
                    .ParaField2 = "kmmc"
                    .ParaField3 = "kmsm"
                    .ParaCondition = "0=0"
                    .ParaOrderField = "kmdm"
                    .ParaTitle = "科目"
                    .ParaOldValue = ""
                    .ParaAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtFcspKm.Text = Trim(.ParaField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtFcspKm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtFcspKm.Validating
        If Not String.IsNullOrEmpty(Me.TxtFcspKm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM gl_kmxx WHERE (kmdm = ?) AND NOT EXISTS (SELECT 1 FROM gl_kmxx aa WHERE aa.parentid = gl_kmxx.kmdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtFcspKm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("gl_kmxx") IsNot Nothing Then
                    Me.rcDataset.Tables("gl_kmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "gl_kmxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("gl_kmxx").Rows.Count > 0 Then
                TxtFcspKm.Text = Trim(rcDataset.Tables("gl_kmxx").Rows(0).Item("kmdm"))
            Else
                MsgBox("科目编码不存在或非明细科目。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                e.Cancel = True
                Return
            End If
        End If
    End Sub

#End Region

#Region "生产成本科目编码的事件"

    Private Sub TxtSccb_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSccbKm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "gl_kmxx"
                    .paraField1 = "kmdm"
                    .paraField2 = "kmmc"
                    .paraField3 = "kmsm"
                    .paraCondition = "0=0"
                    .paraOrderField = "kmdm"
                    .paraTitle = "科目"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtSccbKm.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtSccb_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtSccbKm.Validating
        If Not String.IsNullOrEmpty(Me.TxtSccbKm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM gl_kmxx WHERE (kmdm = ?) AND NOT EXISTS (SELECT 1 FROM gl_kmxx aa WHERE aa.parentid = gl_kmxx.kmdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtSccbKm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("gl_kmxx") IsNot Nothing Then
                    Me.rcDataset.Tables("gl_kmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "gl_kmxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("gl_kmxx").Rows.Count > 0 Then
                TxtSccbKm.Text = Trim(rcDataset.Tables("gl_kmxx").Rows(0).Item("kmdm"))
            Else
                MsgBox("科目编码不存在或非明细科目。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                e.Cancel = True
                Return
            End If
        End If
    End Sub

#End Region

    Private Sub BtnFbd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFbd.Click
        If Me.rcFolderBrowserDialog.ShowDialog() = DialogResult.OK Then
            Me.TxtGlPath.Text = Me.rcFolderBrowserDialog.SelectedPath
        End If
    End Sub

#Region "本位币币种的事件"

    Private Sub TxtWbdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtWbdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .ParaOleDbConn = rcOleDbConn
                    .ParaTableName = "rc_wbxx"
                    .ParaField1 = "wbdm"
                    .ParaField2 = "wbmc"
                    .ParaField3 = "wbsm"
                    .ParaCondition = "kjnd = '" & Mid(g_Kjqj, 1, 4) & "'"
                    .ParaOrderField = "wbdm"
                    .ParaTitle = "币种"
                    .ParaOldValue = ""
                    .ParaAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtWbdm.Text = Trim(.ParaField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtWbdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtWbdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtWbdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_wbxx WHERE (wbdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtWbdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_wbxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_wbxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_wbxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_wbxx").Rows.Count > 0 Then
                TxtWbdm.Text = Trim(rcDataset.Tables("rc_wbxx").Rows(0).Item("wbdm"))
            Else
                MsgBox("币种编码不存在。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                e.Cancel = True
                Return
            End If
        End If
    End Sub

#End Region

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        '写系统参数
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            If Not String.IsNullOrEmpty(Me.TxtDefaultShlv.Text) Then
                '删除数据
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = '增值税默认税率'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '插入数据
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'增值税默认税率','',?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarNumeric, 14).Value = Trim(Me.TxtDefaultShlv.Text)
                rcOleDbCommand.ExecuteNonQuery()
            End If
            If Not String.IsNullOrEmpty(Me.TextBox3.Text) Then
                '删除数据
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = '单据打印中抬头使用的单位名称'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '插入数据
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'单据打印中抬头使用的单位名称',?,0.0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 30).Value = Trim(Me.TextBox3.Text)
                rcOleDbCommand.ExecuteNonQuery()
                g_PrnDwmc = Me.TextBox3.Text
            End If
            If Not String.IsNullOrEmpty(Me.TxtYszk.Text) Then
                '删除数据
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = '总账应收账款科目编码'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '插入数据
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'总账应收账款科目编码',?,0.0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 30).Value = Trim(Me.TxtYszk.Text)
                rcOleDbCommand.ExecuteNonQuery()
            End If
            If Not String.IsNullOrEmpty(Me.TxtYfzk.Text) Then
                '删除数据
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = '总账应付账款科目编码'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '插入数据
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'总账应付账款科目编码',?,0.0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 30).Value = Trim(Me.TxtYfzk.Text)
                rcOleDbCommand.ExecuteNonQuery()
            End If
            If Not String.IsNullOrEmpty(Me.TxtZyywsr.Text) Then
                '删除数据
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = '总账主营业务收入科目编码'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '插入数据
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'总账主营业务收入科目编码',?,0.0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 30).Value = Trim(Me.TxtZyywsr.Text)
                rcOleDbCommand.ExecuteNonQuery()
            End If
            If Not String.IsNullOrEmpty(Me.TxtZyywcb.Text) Then
                '删除数据
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = '总账主营业务成本科目编码'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '插入数据
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'总账主营业务成本科目编码',?,0.0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 30).Value = Trim(Me.TxtZyywcb.Text)
                rcOleDbCommand.ExecuteNonQuery()
            End If
            If Not String.IsNullOrEmpty(Me.TxtYcl.Text) Then
                '删除数据
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = '总账原材料科目编码'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '插入数据
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'总账原材料科目编码',?,0.0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 30).Value = Trim(Me.TxtYcl.Text)
                rcOleDbCommand.ExecuteNonQuery()
            End If
            If Not String.IsNullOrEmpty(Me.TxtKcspKm.Text) Then
                '删除数据
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = '总账库存商品科目编码'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '插入数据
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'总账库存商品科目编码',?,0.0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 30).Value = Trim(Me.TxtKcspKm.Text)
                rcOleDbCommand.ExecuteNonQuery()
            End If
            If Not String.IsNullOrEmpty(Me.TxtFcspKm.Text) Then
                '删除数据
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = '总账发出商品科目编码'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '插入数据
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'总账发出商品科目编码',?,0.0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 30).Value = Trim(Me.TxtFcspKm.Text)
                rcOleDbCommand.ExecuteNonQuery()
            End If
            If Not String.IsNullOrEmpty(Me.TxtZzbcpKm.Text) Then
                '删除数据
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = '总账自制半成品科目编码'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '插入数据
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'总账自制半成品科目编码',?,0.0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 30).Value = Trim(Me.TxtZzbcpKm.Text)
                rcOleDbCommand.ExecuteNonQuery()
            End If
            If Not String.IsNullOrEmpty(Me.TxtSccbKm.Text) Then
                '删除数据
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = '总账生产成本科目编码'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '插入数据
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'总账生产成本科目编码',?,0.0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 30).Value = Trim(Me.TxtSccbKm.Text)
                rcOleDbCommand.ExecuteNonQuery()
            End If
            If Not String.IsNullOrEmpty(Me.CmbPzlxjc.SelectedValue) Then
                '删除数据
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = '凭证生成中使用的凭证类型'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '插入数据
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'凭证生成中使用的凭证类型',?,0.0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 30).Value = Me.CmbPzlxjc.SelectedValue
                rcOleDbCommand.ExecuteNonQuery()
            End If
            If Not String.IsNullOrEmpty(Me.CmbPzlxjc.SelectedValue) Then
                '删除数据
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = '套打格式打印销售单'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '插入数据
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'套打格式打印销售单','',?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraDblValue", OleDbType.Numeric, 1).Value = Me.ChbXsdDy.Checked
                rcOleDbCommand.ExecuteNonQuery()
            End If
            If Not String.IsNullOrEmpty(Me.TxtGlPath.Text) Then
                '删除数据
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = 'Anyi311账务系统路径'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '插入数据
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'Anyi311账务系统路径',?,0.0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 30).Value = Trim(Me.TxtGlPath.Text)
                rcOleDbCommand.ExecuteNonQuery()
            End If
            If Not String.IsNullOrEmpty(Me.TxtWbdm.Text) Then
                '删除数据
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = '本位币币种编码'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '插入数据
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'本位币币种编码',?,0.0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 30).Value = Trim(Me.TxtWbdm.Text)
                rcOleDbCommand.ExecuteNonQuery()
            End If
            If Not String.IsNullOrEmpty(Me.CmbPzlxjc.SelectedValue) Then
                '删除数据
                rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? AND paraid = '发出商品启用会计期间'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.ExecuteNonQuery()
                '插入数据
                rcOleDbCommand.CommandText = "INSERT INTO rc_para (dwdm,paraid,parastrvalue,paradblvalue) VALUES (?,'发出商品启用会计期间',?,0.0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
                rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 30).Value = Me.CmbFcsp.SelectedValue
                rcOleDbCommand.ExecuteNonQuery()
            End If
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误。" & Chr(13) & ex.Message)
            Catch ey As OleDbException
                MsgBox("程序错误。" & Chr(13) & ey.Message)
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Me.Close()
    End Sub

    Private Sub BtnNCSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNCSave.Click
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            '删除数据
            rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? And (paraid = 'NCACCOUNTINGBOOK' OR paraid = 'NCHOST' OR paraid = 'NCSERVICE_NAME' OR paraid = 'NCUser_ID' OR paraid = 'NCPASSWORD' or paraid ='NC服务器的Servlet的URL地址' or paraid ='NC用户编码')"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbCommand.ExecuteNonQuery()
            '插入数据
            rcOleDbCommand.CommandText = "INSERT INTO rc_para (paraid,parastrvalue,paradblvalue,dwdm) VALUES ('NCACCOUNTINGBOOK',?,0.0,?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 20).Value = Trim(Me.TxtNCAccountingBook.Text)
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "INSERT INTO rc_para (paraid,parastrvalue,paradblvalue,dwdm) VALUES ('NCHOST',?,0.0,?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 20).Value = Trim(Me.TxtNCHost.Text)
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "INSERT INTO rc_para (paraid,parastrvalue,paradblvalue,dwdm) VALUES ('NCSERVICE_NAME',?,0.0,?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 20).Value = Trim(Me.TxtNCService_Name.Text)
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "INSERT INTO rc_para (paraid,parastrvalue,paradblvalue,dwdm) VALUES ('NCUser_ID',?,0.0,?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 20).Value = Trim(Me.TxtNCUser_ID.Text)
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "INSERT INTO rc_para (paraid,parastrvalue,paradblvalue,dwdm) VALUES ('NCPASSWORD',?,0.0,?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 20).Value = Trim(Me.TxtNCPwd.Text)
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "INSERT INTO rc_para (paraid,parastrvalue,paradblvalue,dwdm) VALUES ('NC服务器的Servlet的URL地址',?,0.0,?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 200).Value = Trim(Me.TxtNcServletUrl.Text)
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "INSERT INTO rc_para (paraid,parastrvalue,paradblvalue,dwdm) VALUES ('NC用户编码',?,0.0,?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 200).Value = Trim(Me.TxtNCUserAccount.Text)
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误。" & Chr(13) & ex.Message)
            Catch ey As OleDbException
                MsgBox("程序错误。" & Chr(13) & ey.Message)
            End Try
        Finally
            rcOleDbConn.Close()
        End Try
    End Sub

#Region "U8核算单位设置"

    Private Sub BtnU8Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnU8Save.Click
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            '删除数据
            rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? And (paraid = 'U8Acc_ID' OR paraid = 'U8HOST' OR paraid = 'U8User_ID' OR paraid = 'U8PASSWORD')"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbCommand.ExecuteNonQuery()
            '插入数据
            rcOleDbCommand.CommandText = "INSERT INTO rc_para (paraid,parastrvalue,paradblvalue,dwdm) VALUES ('U8Acc_ID',?,0.0,?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 20).Value = Trim(Me.TxtU8Acc_ID.Text)
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "INSERT INTO rc_para (paraid,parastrvalue,paradblvalue,dwdm) VALUES ('U8HOST',?,0.0,?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 20).Value = Trim(Me.TxtU8Host.Text)
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "INSERT INTO rc_para (paraid,parastrvalue,paradblvalue,dwdm) VALUES ('U8User_ID',?,0.0,?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 20).Value = Trim(Me.TxtU8User_ID.Text)
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "INSERT INTO rc_para (paraid,parastrvalue,paradblvalue,dwdm) VALUES ('U8PASSWORD',?,0.0,?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.VarChar, 20).Value = Trim(Me.TxtU8Pwd.Text)
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误。" & Chr(13) & ex.Message)
            Catch ey As OleDbException
                MsgBox("程序错误。" & Chr(13) & ey.Message)
            End Try
        Finally
            rcOleDbConn.Close()
        End Try
    End Sub
#End Region

    Private Sub BtnCostRegion_Click(sender As Object, e As EventArgs) Handles BtnCostRegion.Click
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            '删除数据
            rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? And paraid = '是否按成本域计算成本'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbCommand.ExecuteNonQuery()
            '删除数据
            rcOleDbCommand.CommandText = "DELETE FROM rc_para WHERE dwdm = ? And paraid = '按成本要素独立分配成本'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbCommand.ExecuteNonQuery()
            '插入数据
            rcOleDbCommand.CommandText = "INSERT INTO rc_para (paraid,parastrvalue,paradblvalue,dwdm) VALUES ('是否按成本域计算成本','',?,?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.Numeric, 1).Value = IIf(Me.ChbCostRegion.Checked, 1, 0)
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbCommand.ExecuteNonQuery()
            '插入数据
            rcOleDbCommand.CommandText = "INSERT INTO rc_para (paraid,parastrvalue,paradblvalue,dwdm) VALUES ('按成本要素独立分配成本','',?,?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@paraStrValue", OleDbType.Numeric, 1).Value = IIf(Me.ChbCostElements.Checked, 1, 0)
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误。" & Chr(13) & ex.Message)
            Catch ey As OleDbException
                MsgBox("程序错误。" & Chr(13) & ey.Message)
            End Try
        Finally
            rcOleDbConn.Close()
        End Try

    End Sub
End Class