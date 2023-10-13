Imports System.Data.OleDb
Public Class FrmOeYpddShz

#Region "定义变量"
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    Dim rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '数据绑定
    Dim rcBmb As BindingManagerBase
    '建立打印文档
    ReadOnly rcRps As RPS.Document
#End Region

#Region "初始化"

    Public Property ParaDataSet() As DataSet
        Get
            ParaDataSet = rcDataSet
        End Get
        Set(ByVal Value As DataSet)
            rcDataSet = Value
        End Set
    End Property

    Private Sub FrmDdShz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '设置DataGridView
        Me.rcDataGridView.AutoGenerateColumns = False
        rcBmb = Me.BindingContext(rcDataSet, "ddml")
        If rcDataSet.Tables("ddml").Rows.Count > 0 Then
            ShowDd(rcDataset.Tables("ddml").Rows(0).Item("djh"))
        End If
    End Sub

#End Region

#Region "显示订单过程"

    Private Sub ShowDd(ByVal ddDjh As String)
        '判断ddDjh
        '取oe_ypdd数据
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            '修改单据
            rcOleDbCommand.CommandText = "SELECT oe_ypdd.djh,oe_ypdd.qdrq,oe_ypdd.hth,oe_ypdd.khdm,oe_ypdd.khmc,oe_ypdd.zydm,oe_ypdd.zymc,oe_ypdd.lxr,oe_ypdd.ddtk,oe_ypdd.srr,oe_ypdd.shr FROM oe_ypdd WHERE djh = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = ddDjh
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_ddml") IsNot Nothing Then
                rcDataset.Tables("rc_ddml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_ddml")
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
        '赋值
        Me.TxtDjh.Text = rcDataset.Tables("rc_ddml").Rows(0).Item("djh")
        Me.DtpQdrq.Value = rcDataset.Tables("rc_ddml").Rows(0).Item("qdrq")
        If rcDataset.Tables("rc_ddml").Rows(0).Item("khdm").GetType.ToString <> "System.DBNull" Then
            Me.TxtKhdm.Text = rcDataset.Tables("rc_ddml").Rows(0).Item("khdm")
        Else
            Me.TxtKhdm.Text = ""
        End If
        If rcDataset.Tables("rc_ddml").Rows(0).Item("khmc").GetType.ToString <> "System.DBNull" Then
            Me.LblKhmc.Text = rcDataset.Tables("rc_ddml").Rows(0).Item("khmc")
        Else
            Me.LblKhmc.Text = ""
        End If
        If rcDataset.Tables("rc_ddml").Rows(0).Item("zydm").GetType.ToString <> "System.DBNull" Then
            Me.TxtZydm.Text = Trim(rcDataset.Tables("rc_ddml").Rows(0).Item("zydm"))
        End If
        If rcDataset.Tables("rc_ddml").Rows(0).Item("zymc").GetType.ToString <> "System.DBNull" Then
            Me.LblZymc.Text = Trim(rcDataset.Tables("rc_ddml").Rows(0).Item("zymc"))
        End If
        If rcDataset.Tables("rc_ddml").Rows(0).Item("hth").GetType.ToString <> "System.DBNull" Then
            Me.TxtHth.Text = rcDataset.Tables("rc_ddml").Rows(0).Item("hth")
        Else
            Me.TxtHth.Text = ""
        End If
        If rcDataset.Tables("rc_ddml").Rows(0).Item("lxr").GetType.ToString <> "System.DBNull" Then
            Me.TxtLxr.Text = rcDataset.Tables("rc_ddml").Rows(0).Item("lxr")
        Else
            Me.TxtLxr.Text = ""
        End If
        If rcDataset.Tables("rc_ddml").Rows(0).Item("ddtk").GetType.ToString <> "System.DBNull" Then
            Me.TxtDdtk.Text = rcDataset.Tables("rc_ddml").Rows(0).Item("ddtk")
        Else
            Me.TxtDdtk.Text = ""
        End If
        Me.LblSrr.Text = "合同输入：" + rcDataset.Tables("rc_ddml").Rows(0).Item("srr")
        Me.LblShr.Text = "审核：" + rcDataset.Tables("rc_ddml").Rows(0).Item("shr")
        '取oe_ypddnr数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT ddnr.*,rc_bmxx.bmmc FROM (SELECT oe_ypdd.jhsbm,oe_ypdd.cpdm,oe_ypdd.cpmc,oe_ypdd.cpgg,oe_ypdd.cpmemo,oe_ypdd.dw,oe_ypdd.muju,oe_ypdd.khlh,oe_ypdd.khcz,oe_ypdd.sl,oe_ypdd.khjhrq,oe_ypdd.scjhrq,oe_ypdd.bmdm,oe_ypdd.ddmemo FROM oe_ypdd WHERE (oe_ypdd.djh = ?)) ddnr LEFT OUTER JOIN rc_bmxx ON rc_bmxx.bmdm = ddnr.bmdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = ddDjh
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_ddnr") IsNot Nothing Then
                rcDataset.Tables("rc_ddnr").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_ddnr")
            Me.rcDataGridView.DataSource = rcDataset.Tables("rc_ddnr")
        Catch ex As Exception
            Try
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
        Finally
            rcOleDbConn.Close()
        End Try
    End Sub

#End Region


    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        ExitEvent()
    End Sub

    Private Sub MnuiExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiExit.Click
        ExitEvent()
    End Sub

    Private Sub ExitEvent()
        Me.Close()
    End Sub

    Private Sub BtnSh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSh.Click
        ShEvent(rcBmb.Current("djh"))
    End Sub

    Private Sub MnuiSh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiSh.Click
        ShEvent(rcBmb.Current("djh"))
    End Sub

    Private Sub ShEvent(ByVal ddDjh As String)
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT djh FROM oe_ypdd WHERE (bmdm IS NULL OR scjhrq IS NULL) AND djh = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = ddDjh
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("nobm") IsNot Nothing Then
                rcDataset.Tables("nobm").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "nobm")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("nobm").Rows.Count > 0 Then
            MsgBox("存在没有录入生产厂或没有确认交期的数据，不能进行审核。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "UPDATE oe_ypdd SET shr = ?,shrq = SYSDATE WHERE djh = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@shr", OleDbType.VarChar, 30).Value = g_User_DspName
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = ddDjh
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "UPDATE oe_ypdd SET zt = 3 WHERE djh = ? AND zt < 3"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = ddDjh
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
        LblShr.Text = "审核：" + g_User_DspName
    End Sub

    Private Sub BtnXs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXs.Click
        XsEvent(rcBmb.Current("djh"))
    End Sub

    Private Sub MnuiXs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiXs.Click
        XsEvent(rcBmb.Current("djh"))
    End Sub

    Private Sub XsEvent(ByVal ddDjh As String)
        '检查数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT zt FROM oe_ypdd WHERE zt > 3 AND djh = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = ddDjh
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("nobm") IsNot Nothing Then
                rcDataset.Tables("nobm").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "nobm")
        Catch ex As Exception
            Try
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("nobm").Rows.Count > 0 Then
            MsgBox("存在已经出库的数据，不能取消审核。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        '
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "UPDATE oe_ypdd SET zt = 2 WHERE djh = ? AND zt= 3"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = ddDjh
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbCommand.CommandText = "UPDATE oe_ypdd SET shr = NULL,shrq = NULL WHERE djh = ? AND NOT shr IS NULL"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = ddDjh
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        LblShr.Text = "审核："
    End Sub

    Private Sub BtnQs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQs.Click
        QsEvent()
    End Sub

    Private Sub MnuiQs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiQs.Click
        QsEvent()
    End Sub

    Private Sub QsEvent()
        Dim i As Integer
        For i = 0 To rcDataset.Tables("ddml").Rows.Count - 1
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT djh FROM oe_ypdd WHERE (bmdm IS NULL OR scjhrq IS NULL) AND djh = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataset.Tables("ddml").Rows(i).Item("djh")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("nobm") IsNot Nothing Then
                    rcDataset.Tables("nobm").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "nobm")
            Catch ex As Exception
                Try
                    MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End Try
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("nobm").Rows.Count > 0 Then
                MsgBox("存在没有录入生产厂或交期的数据，不能进行审核。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
        Next
        For i = 0 To rcDataset.Tables("ddml").Rows.Count - 1
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "UPDATE oe_ypdd SET shr = ?,shrq = SYSDATE WHERE djh = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@shr", OleDbType.VarChar, 30).Value = g_User_DspName
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataset.Tables("ddml").Rows(i).Item("djh")
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "UPDATE oe_ypdd SET zt = 3 WHERE djh = ? AND zt < 3"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataset.Tables("ddml").Rows(i).Item("djh")
                rcOleDbCommand.ExecuteNonQuery()
                'rcOleDbCommand.CommandText = "Select oe_ypdd.hth,oe_ypdd.cpdm,oe_ypdd.bmdm From oe_ypdd WHERE oe_ypdd.djh = ?"
                'rcOleDbCommand.Parameters.Clear()
                'rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataSet.Tables("ddml").Rows(i).Item("djh")
                'rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                'If Not rcDataSet.Tables("ddrkckhx") Is Nothing Then
                '    rcDataSet.Tables("ddrkckhx").Clear()
                'End If
                'rcOleDbDataAdpt.Fill(rcDataSet, "ddrkckhx")
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        Next
        LblShr.Text = "审核：" + g_User_DspName
        MsgBox("审核完成。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
    End Sub

    Private Sub BtnQx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQx.Click
        QxEvent()
    End Sub

    Private Sub MnuiQx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiQx.Click
        QxEvent()
    End Sub

    Private Sub QxEvent()
        Dim i As Integer
        For i = 0 To rcDataset.Tables("ddml").Rows.Count - 1
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT zt FROM oe_ypdd WHERE zt > 3 AND djh = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataset.Tables("ddml").Rows(i).Item("djh")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("nobm") IsNot Nothing Then
                    rcDataset.Tables("nobm").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "nobm")
            Catch ex As Exception
                Try
                    MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End Try
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("nobm").Rows.Count > 0 Then
                MsgBox("存在已经出库的数据，不能取消审核。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
        Next
        For i = 0 To rcDataset.Tables("ddml").Rows.Count - 1
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "UPDATE oe_ypdd SET zt = 2 WHERE djh = ? AND zt = 3"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataset.Tables("ddml").Rows(i).Item("djh")
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "UPDATE oe_ypdd SET shr = NULL,shrq = NULL WHERE djh = ? AND NOT shr IS NULL"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataset.Tables("ddml").Rows(i).Item("djh")
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        Next
        LblShr.Text = "审核："
        MsgBox("取消审核完成。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
    End Sub

    Private Sub BtnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevious.Click
        If rcBmb.Count > 0 Then
            If rcBmb.Position <> 0 Then
                rcBmb.Position -= 1
            End If
            ShowDd(rcBmb.Current("djh"))
        End If
    End Sub

    Private Sub MnuiPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrevious.Click
        If rcBmb.Count > 0 Then
            If rcBmb.Position <> 0 Then
                rcBmb.Position -= 1
            End If
            ShowDd(rcBmb.Current("djh"))
        End If
    End Sub

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
        If rcBmb.Count > 0 Then
            If rcBmb.Position <> rcBmb.Count Then
                rcBmb.Position += 1
            End If
            ShowDd(rcBmb.Current("djh"))
        End If
    End Sub

    Private Sub MnuiNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiNext.Click
        If rcBmb.Count > 0 Then
            If rcBmb.Position <> rcBmb.Count Then
                rcBmb.Position += 1
            End If
            ShowDd(rcBmb.Current("djh"))
        End If
    End Sub

End Class