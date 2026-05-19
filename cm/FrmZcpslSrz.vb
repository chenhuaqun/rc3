Imports System.Data.OleDb

Public Class FrmZcpslSrz

#Region "定义变量"
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '会计期间
    Dim strKjqj As String = g_Kjqj
    '年
    Dim strYear As String = ""
    '月
    Dim strMonth As String = ""
    '按成本域
    Dim bCostRegion As Boolean = False

#End Region

#Region "初始化"

    Public Property ParaStrYear() As String
        Get
            ParaStrYear = strYear
        End Get
        Set(ByVal Value As String)
            strYear = Value
        End Set
    End Property

    Public Property ParaStrMonth() As String
        Get
            ParaStrMonth = strMonth
        End Get
        Set(ByVal Value As String)
            strMonth = Value
        End Set
    End Property

    Private Sub FrmZcpslSrz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '是否按成本域计算成本
        bCostRegion = GetParaValue("是否按成本域计算成本", False)
        If bCostRegion Then
            Me.LblBmdm.Text = "成本域编码："
            Me.LblBmmc.Text = "成本域名称："
        Else
            Me.LblBmdm.Text = "部门编码："
            Me.LblBmmc.Text = "部门名称："
        End If
        strKjqj = strYear + strMonth
        Me.TxtZcpsl.Text = 0.0
    End Sub

#End Region

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBmdm.KeyPress, TxtCpdm.KeyPress, TxtCpmc.KeyPress, TxtGxdm.KeyPress, TxtGxmc.KeyPress, TxtZcpsl.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "部门编码的事件"

    Private Sub TxtBmdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBmdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                If bCostRegion Then
                    Dim rcFrm As New models.FrmF3KeyPress
                    With rcFrm
                        .paraOleDbConn = rcOleDbConn
                        .paraTableName = "rc_costregion"
                        .paraField1 = "crdm"
                        .paraField2 = "crmc"
                        .paraField3 = "crsm"
                        .paraTitle = "成本域"
                        .paraOldValue = ""
                        .paraAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            TxtBmdm.Text = Trim(.paraField1)
                        End If
                    End With
                Else
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
                End If
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtBmdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtBmdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtBmdm.Text) Then
            If bCostRegion Then
                Try
                    rcOleDbConn.Open()
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    rcOleDbCommand.CommandText = "SELECT crdm,crmc FROM rc_costregion WHERE (crdm = ?)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@crdm", OleDbType.VarChar, 12).Value = Trim(TxtBmdm.Text)
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("rc_costregion") IsNot Nothing Then
                        Me.rcDataset.Tables("rc_costregion").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "rc_costregion")
                Catch ex As Exception
                    MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                    Return
                Finally
                    rcOleDbConn.Close()
                End Try
                If rcDataset.Tables("rc_costregion").Rows.Count > 0 Then
                    TxtBmdm.Text = Trim(rcDataset.Tables("rc_costregion").Rows(0).Item("crdm"))
                    TxtBmmc.Text = Trim(rcDataset.Tables("rc_costregion").Rows(0).Item("crmc"))
                Else
                    MsgBox("成本域编码不存在，请按F3键选择。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                    e.Cancel = True
                End If
            Else
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
                    Me.TxtBmmc.Text = Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmmc"))
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
            End If

        End If
    End Sub

#End Region

#Region "物料编码事件"

    Private Sub TxtCpdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCpdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF34
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_cpxx"
                    .paraField1 = "cpdm"
                    .paraField2 = "cpmc"
                    .paraField3 = "dw"
                    .paraField4 = "cpsm"
                    .paraOrderField = "cpmc"
                    .paraTitle = "物料"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtCpdm.Text = Trim(.paraField1)
                        TxtCpmc.Text = Trim(.paraField2)
                        LblDw.Text = Trim(.paraField3)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtCpdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCpdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtCpdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT cpdm,cpmc,dw,khdm FROM rc_cpxx WHERE (cpdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_cpxx") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_cpxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_cpxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_cpxx").Rows.Count > 0 Then
                If rcDataSet.Tables("rc_cpxx").Rows(0).Item("cpmc").GetType.ToString <> "System.DBNull" Then
                    Me.TxtCpmc.Text = rcDataSet.Tables("rc_cpxx").Rows(0).Item("cpmc")
                End If
                If rcDataSet.Tables("rc_cpxx").Rows(0).Item("dw").GetType.ToString <> "System.DBNull" Then
                    LblDw.Text = rcDataSet.Tables("rc_cpxx").Rows(0).Item("dw")
                End If
            Else
                Me.TxtCpdm.Focus()
            End If
            LoadSavedZcpsl()
        End If
    End Sub

#End Region

#Region "工序编码的事件"

    Private Sub TxtGxdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtGxdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_gxxx"
                    .paraField1 = "gxdm"
                    .paraField2 = "gxmc"
                    .paraField3 = "gxsm"
                    .paraTitle = "工序"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtGxdm.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtGxdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtGxdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtGxdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_gxxx WHERE (gxdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@gxdm", OleDbType.VarChar, 12).Value = Trim(TxtGxdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_gxxx") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_gxxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_gxxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_gxxx").Rows.Count > 0 Then
                Me.TxtGxdm.Text = Trim(rcDataSet.Tables("rc_gxxx").Rows(0).Item("gxdm"))
                Me.TxtGxmc.Text = Trim(rcDataSet.Tables("rc_gxxx").Rows(0).Item("gxmc"))
            Else
                e.Cancel = True
            End If
            LoadSavedZcpsl()
        End If
    End Sub

#End Region

#Region "取原来保存的年初数量"

    Private Sub LoadSavedZcpsl()
        '取原来的数据
        If Not String.IsNullOrEmpty(Me.TxtBmdm.Text) And Not String.IsNullOrEmpty(Me.TxtCpdm.Text) And Not String.IsNullOrEmpty(Me.TxtGxdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT zcpsl FROM pm_zcp WHERE cperiod = ? AND bmdm = ? AND cpdm = ? AND gxdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strKjqj
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtBmdm.Text).ToUpper
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtCpdm.Text).ToUpper
                rcOleDbCommand.Parameters.Add("@gxdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtGxdm.Text).ToUpper
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("pm_zcp") IsNot Nothing Then
                    rcDataSet.Tables("pm_zcp").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "pm_zcp")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("pm_zcp").Rows.Count > 0 Then
                Me.TxtZcpsl.Text = rcDataSet.Tables("pm_zcp").Rows(0).Item("zcpsl")
            Else
                Me.TxtZcpsl.Text = 0.0
            End If
        End If
    End Sub

#End Region

#Region "保存数据事件"

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click, MnuiSave.Click
        If String.IsNullOrEmpty(Me.TxtBmdm.Text) Or String.IsNullOrEmpty(Me.TxtCpdm.Text) Or String.IsNullOrEmpty(Me.TxtGxdm.Text) Then
            Return
        End If
        '存数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM pm_zcp WHERE cperiod = ? AND bmdm = ? AND cpdm = ? AND gxdm = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strKjqj
            rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtBmdm.Text).ToUpper
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtCpdm.Text).ToUpper
            rcOleDbCommand.Parameters.Add("@gxdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtGxdm.Text).ToUpper
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("pm_zcp") IsNot Nothing Then
                rcDataSet.Tables("pm_zcp").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "pm_zcp")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("pm_zcp").Rows.Count <= 0 Then
            '增加新记录
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "INSERT INTO pm_zcp (cperiod,bmdm,cpdm,gxdm,zcpsl,ydsl,zcpje) values (?,?,?,?,?,0.0,0.0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strKjqj
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtBmdm.Text).ToUpper
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtCpdm.Text).ToUpper
                rcOleDbCommand.Parameters.Add("@gxdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtGxdm.Text).ToUpper
                rcOleDbCommand.Parameters.Add("@zcpsl", OleDbType.Numeric, 18).Value = Me.TxtZcpsl.Text
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
                rcOleDbCommand.CommandText = "UPDATE pm_zcp set zcpsl = ? WHERE cperiod = ? AND bmdm = ? AND cpdm = ? AND gxdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@zcpsl", OleDbType.Numeric, 18).Value = Me.TxtZcpsl.Text
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strKjqj
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtBmdm.Text).ToUpper
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtCpdm.Text).ToUpper
                rcOleDbCommand.Parameters.Add("@gxdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtGxdm.Text).ToUpper
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
        TxtCpdm.Text = ""
        TxtCpmc.Text = ""
        LblDw.Text = ""
        TxtZcpsl.Text = 0.0
        TxtCpdm.Focus()
    End Sub

#End Region

#Region "读入excel"

    Private Sub BtnImpXls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImpXls.Click, MnuiImpXls.Click
        '调用表单
        Dim rcFrm As New FrmZcpslImpXls
        With rcFrm
            .ParaStrKjqj = strKjqj
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

#End Region

#Region "关闭"

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click, MnuiExit.Click
        Me.Close()
    End Sub

#End Region
End Class