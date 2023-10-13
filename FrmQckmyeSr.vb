Imports System.Data.OleDb

Public Class FrmQckmyeSr
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

#Region "初始化事件"

    Private Sub FrmKcslyeSr_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LblKjnd.Text = "会计年度：" & Mid(g_Kjqj, 1, 4) & "年"
        Me.LblKmmc.Text = ""
        Me.LblBmmc.Text = ""
        Me.LblZymc.Text = ""
        Me.LblXmmc.Text = ""
        Me.LblKhmc.Text = ""
        Me.LblCsmc.Text = ""
        Me.LblDw.Text = ""
        Me.LblBz.Text = ""
        Me.TxtNcwb.Text = 0.0
        Me.TxtNcje.Text = 0.0
    End Sub

#End Region

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKmdm.KeyPress, TxtBmdm.KeyPress, TxtZydm.KeyPress, TxtXmdm.KeyPress, TxtKhdm.KeyPress, TxtCsdm.KeyPress, TxtYhzh.KeyPress, TxtJxzh.KeyPress, RdoBtnJie.KeyPress, RdoBtnDai.KeyPress, TxtNcsl.KeyPress, TxtNcje.KeyPress, TxtNcwb.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "科目编码的事件"

    Private Sub TxtKmdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtKmdm.KeyDown
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
                        TxtKmdm.Text = Trim(.paraField1)
                        LblKmmc.Text = Trim(.paraField2)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtKmdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtKmdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtKmdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM gl_kmxx WHERE (kmdm = ?) AND NOT EXISTS (SELECT 1 FROM gl_kmxx aa WHERE aa.parentid = gl_kmxx.kmdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKmdm.Text)
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
                Me.TxtKmdm.Text = Trim(rcDataset.Tables("gl_kmxx").Rows(0).Item("kmdm"))
                Me.LblKmmc.Text = rcDataset.Tables("gl_kmxx").Rows(0).Item("kmmc")
                If rcDataset.Tables("gl_kmxx").Rows(0).Item("kmbm") = 1 Then
                    Me.TxtBmdm.Enabled = True
                Else
                    Me.TxtBmdm.Enabled = False
                End If
                If rcDataset.Tables("gl_kmxx").Rows(0).Item("kmzy") = 1 Then
                    Me.TxtZydm.Enabled = True
                Else
                    Me.TxtZydm.Enabled = False
                End If
                If rcDataset.Tables("gl_kmxx").Rows(0).Item("kmxm") = 1 Then
                    Me.TxtXmdm.Enabled = True
                Else
                    Me.TxtXmdm.Enabled = False
                End If
                If rcDataset.Tables("gl_kmxx").Rows(0).Item("kmkh") = 1 Then
                    Me.TxtKhdm.Enabled = True
                Else
                    Me.TxtKhdm.Enabled = False
                End If
                If rcDataset.Tables("gl_kmxx").Rows(0).Item("kmcs") = 1 Then
                    Me.TxtCsdm.Enabled = True
                Else
                    Me.TxtCsdm.Enabled = False
                End If
                If rcDataset.Tables("gl_kmxx").Rows(0).Item("kmyh") = 1 Then
                    Me.TxtYhzh.Enabled = True
                Else
                    Me.TxtYhzh.Enabled = False
                End If
                If rcDataset.Tables("gl_kmxx").Rows(0).Item("kmjx") = 1 Then
                    Me.TxtJxzh.Enabled = True
                Else
                    Me.TxtJxzh.Enabled = False
                End If

                If rcDataset.Tables("gl_kmxx").Rows(0).Item("kmgs") = 1 Then
                    If rcDataset.Tables("gl_kmxx").Rows(0).Item("dw").GetType.ToString <> "System.DBNull" Then
                        Me.LblDw.Text = rcDataset.Tables("gl_kmxx").Rows(0).Item("dw")
                    End If
                    Me.TxtNcsl.Enabled = True
                Else
                    Me.TxtNcsl.Enabled = False
                End If
                If rcDataset.Tables("gl_kmxx").Rows(0).Item("kmgs") = 2 Then
                    If rcDataset.Tables("gl_kmxx").Rows(0).Item("bz").GetType.ToString <> "System.DBNull" Then
                        Me.LblDw.Text = rcDataset.Tables("gl_kmxx").Rows(0).Item("bz")
                    End If
                    Me.TxtNcwb.Enabled = True
                Else
                    Me.TxtNcwb.Enabled = False
                End If
            Else
                MsgBox("科目编码不存在或非明细科目。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                e.Cancel = True
                Return
            End If
            LoadSavedKmye()
        End If
    End Sub

#End Region

#Region "部门编码的事件"

    Private Sub TxtBmdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBmdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_bmxx"
                    .paraField1 = "bmdm"
                    .paraField2 = "bmmc"
                    .paraField3 = "bmsm"
                    .paraTitle = "部门"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtBmdm.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtBmdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtBmdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtBmdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT bmdm,bmmc FROM rc_bmxx WHERE (bmdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(TxtBmdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_bmxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_bmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_bmxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_bmxx").Rows.Count > 0 Then
                Me.TxtBmdm.Text = Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmdm"))
                Me.LblBmmc.Text = Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmmc"))
            Else
                MsgBox("部门编码不存在，请按F3键选择。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                e.Cancel = True
            End If
            '检测是否最明细记录
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT COUNT(*) AS gs FROM rc_bmxx WHERE (parentid = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtBmdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("reccnt") IsNot Nothing Then
                    Me.rcDataset.Tables("reccnt").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "reccnt")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("reccnt").Rows(0).Item("gs") > 0 Then
                MsgBox("请输入最明细部门编码。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                e.Cancel = True
            End If
            LoadSavedKmye()
        End If
    End Sub

#End Region

#Region "职员编码的事件"

    Private Sub TxtZydm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtZydm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_zyxx"
                    .paraField1 = "zydm"
                    .paraField2 = "zymc"
                    .paraField3 = "zysm"
                    .paraTitle = "职员"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtZydm.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtZydm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtZydm.Validating
        If Not String.IsNullOrEmpty(Me.TxtZydm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT zydm,zymc FROM rc_zyxx WHERE (zydm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = Trim(TxtZydm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_zyxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_zyxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_zyxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_zyxx").Rows.Count > 0 Then
                Me.TxtZydm.Text = Trim(rcDataset.Tables("rc_zyxx").Rows(0).Item("zydm"))
                Me.LblZymc.Text = Trim(rcDataset.Tables("rc_zyxx").Rows(0).Item("zymc"))
            Else
                e.Cancel = True
            End If
            LoadSavedKmye()
        End If
    End Sub

#End Region

#Region "项目编码事件"

    Private Sub TxtXmdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtXmdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "gl_xmxx"
                    .paraField1 = "xmdm"
                    .paraField2 = "xmmc"
                    .paraField3 = "xmsm"
                    .paraTitle = "项目"
                    .paraOldValue = ""
                    .paraAddName = ""
                    .paraCondition = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtXmdm.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtXmdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtXmdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtXmdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM gl_xmxx where (xmdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@xmdm", OleDbType.VarChar, 12).Value = Trim(TxtXmdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("gl_xmxx") IsNot Nothing Then
                    Me.rcDataset.Tables("gl_xmxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "gl_xmxx")
            Catch ex As Exception
                Try
                    MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("gl_xmxx").Rows.Count > 0 Then
                Me.TxtXmdm.Text = Trim(rcDataset.Tables("gl_xmxx").Rows(0).Item("xmdm"))
                Me.LblXmmc.Text = rcDataset.Tables("gl_xmxx").Rows(0).Item("xmmc")
            Else
                MsgBox("项目编码不存在。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                e.Cancel = True
            End If
            LoadSavedKmye()
        End If
    End Sub

#End Region

#Region "客户编码事件"

    Private Sub TxtKhdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtKhdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_khxx"
                    .paraField1 = "khdm"
                    .paraField2 = "khmc"
                    .paraField3 = "khsm"
                    .paraTitle = "客户"
                    .paraOldValue = ""
                    .paraAddName = ""
                    .paraCondition = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtKhdm.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtKhdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtKhdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtKhdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_khxx where (khdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(TxtKhdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_khxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_khxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_khxx")
            Catch ex As Exception
                Try
                    MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_khxx").Rows.Count > 0 Then
                Me.TxtKhdm.Text = Trim(rcDataset.Tables("rc_khxx").Rows(0).Item("khdm"))
                Me.LblKhmc.Text = rcDataset.Tables("rc_khxx").Rows(0).Item("khmc")
            Else
                MsgBox("客户编码不存在。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                e.Cancel = True
            End If
            LoadSavedKmye()
        End If
    End Sub

#End Region

#Region "供应商编码事件"

    Private Sub TxtCsdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCsdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_csxx"
                    .paraField1 = "csdm"
                    .paraField2 = "csmc"
                    .paraField3 = "cssm"
                    .paraTitle = "供应商"
                    .paraOldValue = ""
                    .paraAddName = ""
                    .paraCondition = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtCsdm.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtCsdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCsdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtCsdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_csxx where (csdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(TxtCsdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_csxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_csxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_csxx")
            Catch ex As Exception
                Try
                    MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_Csxx").Rows.Count > 0 Then
                Me.TxtCsdm.Text = Trim(rcDataset.Tables("rc_csxx").Rows(0).Item("csdm"))
                Me.LblCsmc.Text = rcDataset.Tables("rc_csxx").Rows(0).Item("csmc")
            Else
                MsgBox("供应商编码不存在。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                e.Cancel = True
            End If
            LoadSavedKmye()
        End If
    End Sub

#End Region

#Region "取原来保存的年初数量"

    Private Sub LoadSavedKmye()
        '取原来的数据
        If Not String.IsNullOrEmpty(Me.TxtKmdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT kjnd,kmdm,bmdm,zydm,xmdm,khdm,csdm,yhzh,jxzh,jd,ncsl,ncwb,ncje FROM gl_kmyeb WHERE kjnd = ? AND jxzh = ? AND yhzh = ? AND csdm = ? AND khdm = ? AND xmdm = ? AND zydm = ? AND bmdm = ? AND kmdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
                rcOleDbCommand.Parameters.Add("@jxzh", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty((Me.TxtJxzh.Text).ToUpper), "~", (Me.TxtJxzh.Text).ToUpper）
                rcOleDbCommand.Parameters.Add("@yhzh", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty((Me.TxtYhzh.Text).ToUpper), "~", (Me.TxtYhzh.Text).ToUpper）
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty((Me.TxtCsdm.Text).ToUpper), "~", (Me.TxtCsdm.Text).ToUpper）
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty((Me.TxtKhdm.Text).ToUpper), "~", (Me.TxtKhdm.Text).ToUpper）
                rcOleDbCommand.Parameters.Add("@xmdm", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty((Me.TxtXmdm.Text).ToUpper), "~", (Me.TxtXmdm.Text).ToUpper）
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty((Me.TxtZydm.Text).ToUpper), "~", (Me.TxtZydm.Text).ToUpper）
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty((Me.TxtBmdm.Text).ToUpper), "~", (Me.TxtBmdm.Text).ToUpper）
                rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKmdm.Text).ToUpper
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("kmye") IsNot Nothing Then
                    rcDataset.Tables("kmye").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "kmye")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("kmye").Rows.Count = 1 Then
                If rcDataset.Tables("kmye").Rows(0).Item("jd").GetType.ToString <> "System.DBNull" Then
                    If rcDataset.Tables("kmye").Rows(0).Item("jd") = "借" Or rcDataset.Tables("kmye").Rows(0).Item("jd") = "贷" Then
                        Me.RdoBtnJie.Checked = IIf(rcDataset.Tables("kmye").Rows(0).Item("jd") = "借", True, False)
                        Me.RdoBtnDai.Checked = IIf(rcDataset.Tables("kmye").Rows(0).Item("jd") = "贷", True, False)
                    Else
                        Me.RdoBtnJie.Checked = True
                        Me.RdoBtnDai.Checked = False
                    End If
                Else
                    Me.RdoBtnJie.Checked = True
                    Me.RdoBtnDai.Checked = False
                End If
                Me.TxtBmdm.Text = IIf(rcDataset.Tables("kmye").Rows(0).Item("bmdm") = "~", "", rcDataset.Tables("kmye").Rows(0).Item("bmdm"))
                Me.TxtZydm.Text = IIf(rcDataset.Tables("kmye").Rows(0).Item("zydm") = "~", "", rcDataset.Tables("kmye").Rows(0).Item("zydm"))
                Me.TxtXmdm.Text = IIf(rcDataset.Tables("kmye").Rows(0).Item("xmdm") = "~", "", rcDataset.Tables("kmye").Rows(0).Item("xmdm"))
                Me.TxtKhdm.Text = IIf(rcDataset.Tables("kmye").Rows(0).Item("khdm") = "~", "", rcDataset.Tables("kmye").Rows(0).Item("khdm"))
                Me.TxtCsdm.Text = IIf(rcDataset.Tables("kmye").Rows(0).Item("csdm") = "~", "", rcDataset.Tables("kmye").Rows(0).Item("csdm"))
                Me.TxtYhzh.Text = IIf(rcDataset.Tables("kmye").Rows(0).Item("yhzh") = "~", "", rcDataset.Tables("kmye").Rows(0).Item("yhzh"))
                Me.TxtJxzh.Text = IIf(rcDataset.Tables("kmye").Rows(0).Item("jxzh") = "~", "", rcDataset.Tables("kmye").Rows(0).Item("jxzh"))
                Me.TxtNcsl.Text = rcDataset.Tables("kmye").Rows(0).Item("ncsl")
                Me.TxtNcwb.Text = rcDataset.Tables("kmye").Rows(0).Item("ncwb")
                Me.TxtNcje.Text = rcDataset.Tables("kmye").Rows(0).Item("ncje")
            Else
                Me.RdoBtnJie.Checked = True
                Me.RdoBtnDai.Checked = False
                Me.TxtNcsl.Text = 0.0
                Me.TxtNcwb.Text = 0.0
                Me.TxtNcje.Text = 0.0
            End If
        End If
    End Sub

#End Region

#Region "保存数据事件"

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If String.IsNullOrEmpty(Me.TxtKmdm.Text) Then
            Return
        End If
        '存数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT kjnd,kmdm,bmdm,zydm,xmdm,khdm,csdm,yhzh,jxzh,jd,ncsl,ncwb,ncje FROM gl_kmyeb WHERE kjnd = ? AND jxzh = ? AND yhzh = ? AND csdm = ? AND khdm = ? AND xmdm = ? AND zydm = ? AND bmdm = ? AND kmdm = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
            rcOleDbCommand.Parameters.Add("@jxzh", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty((Me.TxtJxzh.Text).ToUpper), "~", (Me.TxtJxzh.Text).ToUpper）
            rcOleDbCommand.Parameters.Add("@yhzh", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty((Me.TxtYhzh.Text).ToUpper), "~", (Me.TxtYhzh.Text).ToUpper）
            rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty((Me.TxtCsdm.Text).ToUpper), "~", (Me.TxtCsdm.Text).ToUpper）
            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty((Me.TxtKhdm.Text).ToUpper), "~", (Me.TxtKhdm.Text).ToUpper）
            rcOleDbCommand.Parameters.Add("@xmdm", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty((Me.TxtXmdm.Text).ToUpper), "~", (Me.TxtXmdm.Text).ToUpper）
            rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty((Me.TxtZydm.Text).ToUpper), "~", (Me.TxtZydm.Text).ToUpper）
            rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty((Me.TxtBmdm.Text).ToUpper), "~", (Me.TxtBmdm.Text).ToUpper）
            rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtKmdm.Text).ToUpper
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("kmye") IsNot Nothing Then
                rcDataset.Tables("kmye").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "kmye")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("kmye").Rows.Count <= 0 Then
            '增加新记录
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "INSERT INTO gl_kmyeb (kjnd,kmdm,bmdm,zydm,xmdm,khdm,csdm,yhzh,jxzh,jd,ncsl,ncwb,ncje) values (?,?,?,?,?,?,?,?,?,?,?,?,?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
                rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = Me.TxtKmdm.Text
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty((Me.TxtBmdm.Text).ToUpper), "~", (Me.TxtBmdm.Text).ToUpper）
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty((Me.TxtZydm.Text).ToUpper), "~", (Me.TxtZydm.Text).ToUpper）
                rcOleDbCommand.Parameters.Add("@xmdm", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty((Me.TxtXmdm.Text).ToUpper), "~", (Me.TxtXmdm.Text).ToUpper）
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty((Me.TxtKhdm.Text).ToUpper), "~", (Me.TxtKhdm.Text).ToUpper）
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty((Me.TxtCsdm.Text).ToUpper), "~", (Me.TxtCsdm.Text).ToUpper）
                rcOleDbCommand.Parameters.Add("@yhzh", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty((Me.TxtYhzh.Text).ToUpper), "~", (Me.TxtYhzh.Text).ToUpper）
                rcOleDbCommand.Parameters.Add("@jxzh", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty((Me.TxtJxzh.Text).ToUpper), "~", (Me.TxtJxzh.Text).ToUpper）
                rcOleDbCommand.Parameters.Add("@jd", OleDbType.VarChar, 2).Value = IIf(Me.RdoBtnJie.Checked, "借", "贷")
                rcOleDbCommand.Parameters.Add("@ncsl", OleDbType.Numeric, 18).Value = Me.TxtNcsl.Text
                rcOleDbCommand.Parameters.Add("@ncwb", OleDbType.Numeric, 18).Value = Me.TxtNcwb.Text
                rcOleDbCommand.Parameters.Add("@ncje", OleDbType.Numeric, 14).Value = Me.TxtNcje.Text
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        Else
            '修改记录
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "UPDATE gl_kmyeb SET jd = ? ,ncsl = ?,ncwb = ?,ncje = ? WHERE kjnd = ? AND jxzh = ? AND yhzh = ? AND csdm = ? AND khdm = ? AND xmdm =  ? AND zydm = ? AND bmdm = ? AND kmdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@jd", OleDbType.VarChar, 2).Value = IIf(Me.RdoBtnJie.Checked, "借", "贷")
                rcOleDbCommand.Parameters.Add("@ncsl", OleDbType.Numeric, 18).Value = Me.TxtNcsl.Text
                rcOleDbCommand.Parameters.Add("@ncwb", OleDbType.Numeric, 18).Value = Me.TxtNcwb.Text
                rcOleDbCommand.Parameters.Add("@ncje", OleDbType.Numeric, 14).Value = Me.TxtNcje.Text
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
                rcOleDbCommand.Parameters.Add("@jxzh", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty((Me.TxtJxzh.Text).ToUpper), "~", (Me.TxtJxzh.Text).ToUpper）
                rcOleDbCommand.Parameters.Add("@yhzh", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty((Me.TxtYhzh.Text).ToUpper), "~", (Me.TxtYhzh.Text).ToUpper）
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty((Me.TxtCsdm.Text).ToUpper), "~", (Me.TxtCsdm.Text).ToUpper）
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty((Me.TxtKhdm.Text).ToUpper), "~", (Me.TxtKhdm.Text).ToUpper）
                rcOleDbCommand.Parameters.Add("@xmdm", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty((Me.TxtXmdm.Text).ToUpper), "~", (Me.TxtXmdm.Text).ToUpper）
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty((Me.TxtZydm.Text).ToUpper), "~", (Me.TxtZydm.Text).ToUpper）
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = IIf(String.IsNullOrEmpty((Me.TxtBmdm.Text).ToUpper), "~", (Me.TxtBmdm.Text).ToUpper）
                rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = Trim(TxtKmdm.Text).ToUpper
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        End If
        Me.TxtKmdm.Enabled = True
        Me.TxtKmdm.Text = ""
        Me.LblKmmc.Text = ""
        Me.TxtBmdm.Enabled = True
        Me.TxtBmdm.Text = ""
        Me.LblBmmc.Text = ""
        Me.TxtZydm.Enabled = True
        Me.TxtZydm.Text = ""
        Me.LblZymc.Text = ""
        Me.TxtXmdm.Enabled = True
        Me.TxtXmdm.Text = ""
        Me.LblXmmc.Text = ""
        Me.TxtKhdm.Enabled = True
        Me.TxtKhdm.Text = ""
        Me.LblKhmc.Text = ""
        Me.TxtCsdm.Enabled = True
        Me.TxtCsdm.Text = ""
        Me.LblCsmc.Text = ""
        Me.TxtYhzh.Enabled = True
        Me.TxtYhzh.Text = ""
        Me.TxtJxzh.Enabled = True
        Me.TxtJxzh.Text = ""
        Me.LblDw.Text = ""
        Me.LblBz.Text = ""
        Me.TxtNcsl.Text = 0.0
        Me.TxtNcwb.Text = 0.0
        Me.TxtNcje.Text = 0.0
        Me.TxtKmdm.Focus()
    End Sub

#End Region

End Class