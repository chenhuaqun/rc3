Imports System.Data.OleDb

Public Class FrmZcbjeSrz
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
    '计算生产入库成本方式
    Dim intJsfs As Int16 = 0

#Region "初始化事件"

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

    Private Sub FrmZcbjeSrz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '计算生产入库成本方式
        intJsfs = GetParaValue("是否按成本域计算成本", False)
        Select Case intJsfs
            Case 1
                Me.LblBmdm.Text = "成本域编码："
            Case Else
                Me.LblBmdm.Text = "部门编码："
        End Select
        strKjqj = strYear & strMonth.PadLeft(2, "0")
        Me.TxtKjqj.Text = strKjqj
        SumSlJe()
    End Sub

#End Region

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKjqj.KeyPress, TxtBmdm.KeyPress, TxtQczcpje.KeyPress, TxtZcbje.KeyPress, TxtQmzcclje.KeyPress, TxtCcpje.KeyPress, TxtQmzcpje.KeyPress
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
                Select Case intJsfs
                    Case 1
                        Dim rcFrm As New models.FrmF3KeyPress
                        With rcFrm
                            .ParaOleDbConn = rcOleDbConn
                            .ParaTableName = "rc_costregion"
                            .ParaField1 = "crdm"
                            .ParaField2 = "crmc"
                            .ParaField3 = "crsm"
                            .ParaTitle = "成本域"
                            .ParaOldValue = ""
                            .ParaAddName = ""
                            If .ShowDialog = DialogResult.OK Then
                                TxtBmdm.Text = Trim(.ParaField1)
                            End If
                        End With
                    Case 2
                        Dim rcFrm As New models.FrmF3KeyPress
                        With rcFrm
                            .ParaOleDbConn = rcOleDbConn
                            .ParaTableName = "rc_gxxx"
                            .ParaField1 = "gxdm"
                            .ParaField2 = "gxmc"
                            .ParaField3 = "gxsm"
                            .ParaTitle = "生产工序"
                            .ParaOldValue = ""
                            .ParaAddName = ""
                            If .ShowDialog = DialogResult.OK Then
                                TxtBmdm.Text = Trim(.ParaField1)
                            End If
                        End With
                    Case Else
                        Dim rcFrm As New models.FrmF3KeyPress
                        With rcFrm
                            .ParaOleDbConn = rcOleDbConn
                            .ParaTableName = "rc_bmxx"
                            .ParaField1 = "bmdm"
                            .ParaField2 = "bmmc"
                            .ParaField3 = "bmsm"
                            .ParaTitle = "部门"
                            .ParaOldValue = ""
                            .ParaAddName = ""
                            If .ShowDialog = DialogResult.OK Then
                                TxtBmdm.Text = Trim(.ParaField1)
                            End If
                        End With
                End Select
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtBmdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtBmdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtBmdm.Text) Then
            Select Case intJsfs
                Case 1
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
                        LblBmmc.Text = Trim(rcDataset.Tables("rc_costregion").Rows(0).Item("crmc"))
                    Else
                        MsgBox("成本域编码不存在，请按F3键选择。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        e.Cancel = True
                    End If
                Case 2
                    Try
                        rcOleDbConn.Open()
                        rcOleDbCommand.Connection = rcOleDbConn
                        rcOleDbCommand.CommandTimeout = 300
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT gxdm,gxmc FROM rc_gxxx WHERE (gxdm = ?)"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@gxdm", OleDbType.VarChar, 12).Value = Trim(TxtBmdm.Text)
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_gxxx") IsNot Nothing Then
                            Me.rcDataset.Tables("rc_gxxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_gxxx")
                    Catch ex As Exception
                        MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                    If rcDataset.Tables("rc_gxxx").Rows.Count > 0 Then
                        Me.TxtBmdm.Text = Trim(rcDataset.Tables("rc_gxxx").Rows(0).Item("gxdm"))
                        Me.LblBmmc.Text = Trim(rcDataset.Tables("rc_gxxx").Rows(0).Item("gxmc"))
                    Else
                        MsgBox("生产工序编码不存在，请按F3键选择。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        e.Cancel = True
                    End If
                Case Else
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
                        TxtBmdm.Text = Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmdm"))
                        LblBmmc.Text = Trim(rcDataset.Tables("rc_bmxx").Rows(0).Item("bmmc"))
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
            End Select
            '取已保存的数据
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM pm_zcbje WHERE cperiod = ? AND bmdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strKjqj
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Me.TxtBmdm.Text
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("pm_zcbje") IsNot Nothing Then
                    rcDataset.Tables("pm_zcbje").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "pm_zcbje")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message)
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("pm_zcbje").Rows.Count > 0 Then
                Me.TxtQczcpje.Text = rcDataset.Tables("pm_zcbje").Rows(0).Item("qczcpje")
                Me.TxtZcbje.Text = rcDataset.Tables("pm_zcbje").Rows(0).Item("zcbje")
                Me.TxtCcpje.Text = rcDataset.Tables("pm_zcbje").Rows(0).Item("ccpje")
                Me.TxtQmzcclje.Text = rcDataset.Tables("pm_zcbje").Rows(0).Item("qmzcclje")
                Me.TxtQmzcpje.Text = rcDataset.Tables("pm_zcbje").Rows(0).Item("qmzcpje")
            Else
                Me.TxtQczcpje.Text = 0.0
                Me.TxtZcbje.Text = 0.0
                Me.TxtQmzcclje.Text = 0.0
                Me.TxtCcpje.Text = 0.0
                Me.TxtQmzcpje.Text = 0.0
            End If

            '取上月的期末在制品库存,建立逻辑关系
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM pm_zcbje WHERE cperiod = ? AND bmdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = IIf(Val(strMonth) = 1, Trim(Str(Val(strYear) - 1)).PadLeft(4, "0") & "12", strYear & Trim(Str(Val(strMonth) - 1)).PadLeft(2, "0"))
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Me.TxtBmdm.Text
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("pm_zcbje") IsNot Nothing Then
                    rcDataset.Tables("pm_zcbje").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "pm_zcbje")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message)
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("pm_zcbje").Rows.Count > 0 Then
                Me.TxtQczcpje.Text = rcDataset.Tables("pm_zcbje").Rows(0).Item("qczcpje") + rcDataset.Tables("pm_zcbje").Rows(0).Item("zcbje") - rcDataset.Tables("pm_zcbje").Rows(0).Item("ccpje") ' - rcDataSet.Tables("pm_zcbje").Rows(0).Item("qmzcclje")
            End If
        End If
    End Sub

#End Region

    Private Sub LblQczcpje_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtQczcpje.Validating, TxtZcbje.Validating, TxtQmzcclje.Validating, TxtCcpje.Validating
        SumSlJe()
    End Sub

#Region "计算合计数"

    Private Sub SumSlJe()
        '计算合计数
        Dim dblQmzcpje As Double
        dblQmzcpje = Val(Me.TxtQczcpje.Text) + Val(Me.TxtZcbje.Text) - Val(Me.TxtQmzcclje.Text) - Val(Me.TxtCcpje.Text)
        Me.TxtQmzcpje.Text = Format(dblQmzcpje, g_FormatJe)
    End Sub

#End Region

#Region "保存数据事件"

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "DELETE FROM pm_zcbje WHERE cperiod = ? AND bmdm = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strKjqj
            rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Me.TxtBmdm.Text
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "INSERT INTO pm_zcbje (cperiod,bmdm,qczcpje,zcbje,ccpje,qmzcclje,qmzcpje) values (?,?,?,?,?,?,?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strKjqj
            rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = Me.TxtBmdm.Text
            rcOleDbCommand.Parameters.Add("@qczcpje", OleDbType.Numeric, 14).Value = Me.TxtQczcpje.Text
            rcOleDbCommand.Parameters.Add("@zcbje", OleDbType.Numeric, 14).Value = Me.TxtZcbje.Text
            rcOleDbCommand.Parameters.Add("@ccpje", OleDbType.Numeric, 14).Value = Me.TxtCcpje.Text
            rcOleDbCommand.Parameters.Add("@qmzcclje", OleDbType.Numeric, 14).Value = Me.TxtQmzcclje.Text
            rcOleDbCommand.Parameters.Add("@qmzcpje", OleDbType.Numeric, 14).Value = Me.TxtQmzcpje.Text
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
        Me.TxtBmdm.Text = ""
        Me.LblBmmc.Text = ""
        Me.TxtQczcpje.Text = 0.0
        Me.TxtZcbje.Text = 0.0
        Me.TxtCcpje.Text = 0.0
        Me.TxtQmzcclje.Text = 0.0
        Me.TxtQmzcpje.Text = 0.0
    End Sub

#End Region

End Class