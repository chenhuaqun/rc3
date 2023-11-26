Imports System.Data.OleDb

Public Class FrmKjqj
    '建立OLEDB数据适配器对象
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDb传递对象
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDb命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Private Sub FrmKjqj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Label16.Text = "会计年度：" & g_Kjrq.Year.ToString & "年"
        '取已设置值
        Try
            sysOleDbConn.Open()
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_yj WHERE substr(ny,1,4) = '" & g_Kjrq.Year & "' ORDER BY ny"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_yj") IsNot Nothing Then
                rcDataSet.Tables("rc_yj").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_yj")
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
        Finally
            sysOleDbConn.Close()
        End Try
        If rcDataSet.Tables("rc_yj").Rows.Count = 12 Then
            If rcDataSet.Tables("rc_yj").Rows(11).Item("Invbegin").GetType.ToString <> "System.DBNull" Then
                Dtp1Begin.Value = rcDataSet.Tables("rc_yj").Rows(0).Item("Invbegin")
                Dtp1End.Value = rcDataSet.Tables("rc_yj").Rows(0).Item("InvEnd")
                Dtp2Begin.Value = rcDataSet.Tables("rc_yj").Rows(1).Item("Invbegin")
                Dtp2End.Value = rcDataSet.Tables("rc_yj").Rows(1).Item("InvEnd")
                Dtp3Begin.Value = rcDataSet.Tables("rc_yj").Rows(2).Item("Invbegin")
                Dtp3End.Value = rcDataSet.Tables("rc_yj").Rows(2).Item("InvEnd")
                Dtp4Begin.Value = rcDataSet.Tables("rc_yj").Rows(3).Item("Invbegin")
                Dtp4End.Value = rcDataSet.Tables("rc_yj").Rows(3).Item("InvEnd")
                Dtp5Begin.Value = rcDataSet.Tables("rc_yj").Rows(4).Item("Invbegin")
                Dtp5End.Value = rcDataSet.Tables("rc_yj").Rows(4).Item("InvEnd")
                Dtp6Begin.Value = rcDataSet.Tables("rc_yj").Rows(5).Item("Invbegin")
                Dtp6End.Value = rcDataSet.Tables("rc_yj").Rows(5).Item("InvEnd")
                Dtp7Begin.Value = rcDataSet.Tables("rc_yj").Rows(6).Item("Invbegin")
                Dtp7End.Value = rcDataSet.Tables("rc_yj").Rows(6).Item("InvEnd")
                Dtp8Begin.Value = rcDataSet.Tables("rc_yj").Rows(7).Item("Invbegin")
                Dtp8End.Value = rcDataSet.Tables("rc_yj").Rows(7).Item("InvEnd")
                Dtp9Begin.Value = rcDataSet.Tables("rc_yj").Rows(8).Item("Invbegin")
                Dtp9End.Value = rcDataSet.Tables("rc_yj").Rows(8).Item("InvEnd")
                Dtp10Begin.Value = rcDataSet.Tables("rc_yj").Rows(9).Item("Invbegin")
                Dtp10End.Value = rcDataSet.Tables("rc_yj").Rows(9).Item("InvEnd")
                Dtp11Begin.Value = rcDataSet.Tables("rc_yj").Rows(10).Item("Invbegin")
                Dtp11End.Value = rcDataSet.Tables("rc_yj").Rows(10).Item("InvEnd")
                Dtp12Begin.Value = rcDataSet.Tables("rc_yj").Rows(11).Item("Invbegin")
                Dtp12End.Value = rcDataSet.Tables("rc_yj").Rows(11).Item("InvEnd")
            Else
                '取默认值
                Dtp1Begin.Value = CDate("#" & g_Kjrq.Year & "/1/1 0:0#")
                Dtp1End.Value = CDate("#" & g_Kjrq.Year & "/2/1 0:0#").AddMinutes(-1)
                Dtp2Begin.Value = CDate("#" & g_Kjrq.Year & "/2/1 0:0#")
                Dtp2End.Value = CDate("#" & g_Kjrq.Year & "/3/1 0:0#").AddMinutes(-1)
                Dtp3Begin.Value = CDate("#" & g_Kjrq.Year & "/3/1 0:0#")
                Dtp3End.Value = CDate("#" & g_Kjrq.Year & "/4/1 0:0#").AddMinutes(-1)
                Dtp4Begin.Value = CDate("#" & g_Kjrq.Year & "/4/1 0:0#")
                Dtp4End.Value = CDate("#" & g_Kjrq.Year & "/5/1 0:0#").AddMinutes(-1)
                Dtp5Begin.Value = CDate("#" & g_Kjrq.Year & "/5/1 0:0#")
                Dtp5End.Value = CDate("#" & g_Kjrq.Year & "/6/1 0:0#").AddMinutes(-1)
                Dtp6Begin.Value = CDate("#" & g_Kjrq.Year & "/6/1 0:0#")
                Dtp6End.Value = CDate("#" & g_Kjrq.Year & "/7/1 0:0#").AddMinutes(-1)
                Dtp7Begin.Value = CDate("#" & g_Kjrq.Year & "/7/1 0:0#")
                Dtp7End.Value = CDate("#" & g_Kjrq.Year & "/8/1 0:0#").AddMinutes(-1)
                Dtp8Begin.Value = CDate("#" & g_Kjrq.Year & "/8/1 0:0#")
                Dtp8End.Value = CDate("#" & g_Kjrq.Year & "/9/1 0:0#").AddMinutes(-1)
                Dtp9Begin.Value = CDate("#" & g_Kjrq.Year & "/9/1 0:0#")
                Dtp9End.Value = CDate("#" & g_Kjrq.Year & "/10/1 0:0#").AddMinutes(-1)
                Dtp10Begin.Value = CDate("#" & g_Kjrq.Year & "/10/1 0:0#")
                Dtp10End.Value = CDate("#" & g_Kjrq.Year & "/11/1 0:0#").AddMinutes(-1)
                Dtp11Begin.Value = CDate("#" & g_Kjrq.Year & "/11/1 0:0#")
                Dtp11End.Value = CDate("#" & g_Kjrq.Year & "/12/1 0:0#").AddMinutes(-1)
                Dtp12Begin.Value = CDate("#" & g_Kjrq.Year & "/12/1 0:0#")
                Dtp12End.Value = CDate("#" & (g_Kjrq.Year + 1) & "/1/1 0:0#").AddMinutes(-1)
            End If
        Else
            '取默认值
            Dtp1Begin.Value = CDate("#" & g_Kjrq.Year & "/1/1 0:0#")
            Dtp1End.Value = CDate("#" & g_Kjrq.Year & "/2/1 0:0#").AddMinutes(-1)
            Dtp2Begin.Value = CDate("#" & g_Kjrq.Year & "/2/1 0:0#")
            Dtp2End.Value = CDate("#" & g_Kjrq.Year & "/3/1 0:0#").AddMinutes(-1)
            Dtp3Begin.Value = CDate("#" & g_Kjrq.Year & "/3/1 0:0#")
            Dtp3End.Value = CDate("#" & g_Kjrq.Year & "/4/1 0:0#").AddMinutes(-1)
            Dtp4Begin.Value = CDate("#" & g_Kjrq.Year & "/4/1 0:0#")
            Dtp4End.Value = CDate("#" & g_Kjrq.Year & "/5/1 0:0#").AddMinutes(-1)
            Dtp5Begin.Value = CDate("#" & g_Kjrq.Year & "/5/1 0:0#")
            Dtp5End.Value = CDate("#" & g_Kjrq.Year & "/6/1 0:0#").AddMinutes(-1)
            Dtp6Begin.Value = CDate("#" & g_Kjrq.Year & "/6/1 0:0#")
            Dtp6End.Value = CDate("#" & g_Kjrq.Year & "/7/1 0:0#").AddMinutes(-1)
            Dtp7Begin.Value = CDate("#" & g_Kjrq.Year & "/7/1 0:0#")
            Dtp7End.Value = CDate("#" & g_Kjrq.Year & "/8/1 0:0#").AddMinutes(-1)
            Dtp8Begin.Value = CDate("#" & g_Kjrq.Year & "/8/1 0:0#")
            Dtp8End.Value = CDate("#" & g_Kjrq.Year & "/9/1 0:0#").AddMinutes(-1)
            Dtp9Begin.Value = CDate("#" & g_Kjrq.Year & "/9/1 0:0#")
            Dtp9End.Value = CDate("#" & g_Kjrq.Year & "/10/1 0:0#").AddMinutes(-1)
            Dtp10Begin.Value = CDate("#" & g_Kjrq.Year & "/10/1 0:0#")
            Dtp10End.Value = CDate("#" & g_Kjrq.Year & "/11/1 0:0#").AddMinutes(-1)
            Dtp11Begin.Value = CDate("#" & g_Kjrq.Year & "/11/1 0:0#")
            Dtp11End.Value = CDate("#" & g_Kjrq.Year & "/12/1 0:0#").AddMinutes(-1)
            Dtp12Begin.Value = CDate("#" & g_Kjrq.Year & "/12/1 0:0#")
            Dtp12End.Value = CDate("#" & (g_Kjrq.Year + 1) & "/1/1 0:0#").AddMinutes(-1)
        End If
    End Sub

    Private Sub Dtp1Begin_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp1Begin.ValueChanged
        Dtp12End.Value = Dtp1Begin.Value.AddYears(1).AddMinutes(-1)
    End Sub

    Private Sub Dtp1End_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp1End.ValueChanged
        Dtp2Begin.Value = Dtp1End.Value.AddMinutes(1)
    End Sub

    Private Sub Dtp2Begin_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp2Begin.ValueChanged
        Dtp1End.Value = Dtp2Begin.Value.AddMinutes(-1)
    End Sub

    Private Sub Dtp2End_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp2End.ValueChanged
        Dtp3Begin.Value = Dtp2End.Value.AddMinutes(1)
    End Sub

    Private Sub Dtp3Begin_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp3Begin.ValueChanged
        Dtp2End.Value = Dtp3Begin.Value.AddMinutes(-1)
    End Sub

    Private Sub Dtp3End_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp3End.ValueChanged
        Dtp4Begin.Value = Dtp3End.Value.AddMinutes(1)
    End Sub

    Private Sub Dtp4Begin_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp4Begin.ValueChanged
        Dtp3End.Value = Dtp4Begin.Value.AddMinutes(-1)
    End Sub

    Private Sub Dtp4End_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp4End.ValueChanged
        Dtp5Begin.Value = Dtp4End.Value.AddMinutes(1)
    End Sub

    Private Sub Dtp5Begin_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp5Begin.ValueChanged
        Dtp4End.Value = Dtp5Begin.Value.AddMinutes(-1)
    End Sub

    Private Sub Dtp5End_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp5End.ValueChanged
        Dtp6Begin.Value = Dtp5End.Value.AddMinutes(1)
    End Sub

    Private Sub Dtp6Begin_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp6Begin.ValueChanged
        Dtp5End.Value = Dtp6Begin.Value.AddMinutes(-1)
    End Sub

    Private Sub Dtp6End_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp6End.ValueChanged
        Dtp7Begin.Value = Dtp6End.Value.AddMinutes(1)
    End Sub

    Private Sub Dtp7Begin_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp7Begin.ValueChanged
        Dtp6End.Value = Dtp7Begin.Value.AddMinutes(-1)
    End Sub

    Private Sub Dtp7End_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp7End.ValueChanged
        Dtp8Begin.Value = Dtp7End.Value.AddMinutes(1)
    End Sub

    Private Sub Dtp8Begin_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp8Begin.ValueChanged
        Dtp7End.Value = Dtp8Begin.Value.AddMinutes(-1)
    End Sub

    Private Sub Dtp8End_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp8End.ValueChanged
        Dtp9Begin.Value = Dtp8End.Value.AddMinutes(1)
    End Sub

    Private Sub Dtp9Begin_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp9Begin.ValueChanged
        Dtp8End.Value = Dtp9Begin.Value.AddMinutes(-1)
    End Sub

    Private Sub Dtp9End_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp9End.ValueChanged
        Dtp10Begin.Value = Dtp9End.Value.AddMinutes(1)
    End Sub

    Private Sub Dtp10Begin_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp10Begin.ValueChanged
        Dtp9End.Value = Dtp10Begin.Value.AddMinutes(-1)
    End Sub

    Private Sub Dtp10End_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp10End.ValueChanged
        Dtp11Begin.Value = Dtp10End.Value.AddMinutes(1)
    End Sub

    Private Sub Dtp11Begin_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp11Begin.ValueChanged
        Dtp10End.Value = Dtp11Begin.Value.AddMinutes(-1)
    End Sub

    Private Sub Dtp11End_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp11End.ValueChanged
        Dtp12Begin.Value = Dtp11End.Value.AddMinutes(1)
    End Sub

    Private Sub Dtp12Begin_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp12Begin.ValueChanged
        Dtp11End.Value = Dtp12Begin.Value.AddMinutes(-1)
    End Sub

    Private Sub Dtp12End_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp12End.ValueChanged
        Dtp1Begin.Value = Dtp12End.Value.AddYears(-1).AddMinutes(1)
        'If MsgBox("是否调整会计期间一月的开始时间？", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "提示信息") = MsgBoxResult.Yes Then
        'End If
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        '查找
        Try
            sysOleDbConn.Open()
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_yj WHERE substr(ny,1,4) = '" & g_Kjrq.Year & "' ORDER BY ny"
            rcOleDbCommand.Parameters.Clear()
            'rcoledbcommand.Parameters.Add("@ny", OleDbType.varchar, 6).Value = g_Kjrq.Year
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("yjdata") IsNot Nothing Then
                rcDataSet.Tables("yjdata").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "yjdata")
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误1。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误2。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
        Finally
            sysOleDbConn.Close()
        End Try
        If rcDataSet.Tables("yjdata").Rows.Count > 0 Then
            '更新
            '保存
            sysOleDbConn.Open()
            rcOleDbTrans = sysOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            Try
                rcOleDbCommand.CommandText = "UPDATE rc_yj set jzbz = 0,Invbegin = ? ,InvEnd = ?,PoBegin = ?,PoEnd = ? WHERE ny = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp1Begin.Value
                rcOleDbCommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp1End.Value
                rcOleDbCommand.Parameters.Add("@PoBegin", OleDbType.Date, 8).Value = Dtp1Begin.Value
                rcOleDbCommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp1End.Value
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "01"
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp2Begin.Value
                rcOleDbCommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp2End.Value
                rcOleDbCommand.Parameters.Add("@PoBegin", OleDbType.Date, 8).Value = Dtp2Begin.Value
                rcOleDbCommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp2End.Value
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "02"
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp3Begin.Value
                rcOleDbCommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp3End.Value
                rcOleDbCommand.Parameters.Add("@PoBegin", OleDbType.Date, 8).Value = Dtp3Begin.Value
                rcOleDbCommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp3End.Value
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "03"
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp4Begin.Value
                rcOleDbCommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp4End.Value
                rcOleDbCommand.Parameters.Add("@PoBegin", OleDbType.Date, 8).Value = Dtp4Begin.Value
                rcOleDbCommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp4End.Value
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "04"
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp5Begin.Value
                rcOleDbCommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp5End.Value
                rcOleDbCommand.Parameters.Add("@PoBegin", OleDbType.Date, 8).Value = Dtp5Begin.Value
                rcOleDbCommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp5End.Value
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "05"
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp6Begin.Value
                rcOleDbCommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp6End.Value
                rcOleDbCommand.Parameters.Add("@PoBegin", OleDbType.Date, 8).Value = Dtp6Begin.Value
                rcOleDbCommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp6End.Value
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "06"
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp7Begin.Value
                rcOleDbCommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp7End.Value
                rcOleDbCommand.Parameters.Add("@PoBegin", OleDbType.Date, 8).Value = Dtp7Begin.Value
                rcOleDbCommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp7End.Value
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "07"
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp8Begin.Value
                rcOleDbCommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp8End.Value
                rcOleDbCommand.Parameters.Add("@PoBegin", OleDbType.Date, 8).Value = Dtp8Begin.Value
                rcOleDbCommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp8End.Value
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "08"
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp9Begin.Value
                rcOleDbCommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp9End.Value
                rcOleDbCommand.Parameters.Add("@PoBegin", OleDbType.Date, 8).Value = Dtp9Begin.Value
                rcOleDbCommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp9End.Value
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "09"
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp10Begin.Value
                rcOleDbCommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp10End.Value
                rcOleDbCommand.Parameters.Add("@PoBegin", OleDbType.Date, 8).Value = Dtp10Begin.Value
                rcOleDbCommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp10End.Value
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "10"
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp11Begin.Value
                rcOleDbCommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp11End.Value
                rcOleDbCommand.Parameters.Add("@PoBegin", OleDbType.Date, 8).Value = Dtp11Begin.Value
                rcOleDbCommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp11End.Value
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "11"
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp12Begin.Value
                rcOleDbCommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp12End.Value
                rcOleDbCommand.Parameters.Add("@PoBegin", OleDbType.Date, 8).Value = Dtp12Begin.Value
                rcOleDbCommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp12End.Value
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "12"
                rcOleDbCommand.ExecuteNonQuery()
                If rcDataSet.Tables("rc_yj") IsNot Nothing Then
                    rcDataSet.Tables("rc_yj").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_yj")
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("程序错误3。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误4。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End Try
            Finally
                sysOleDbConn.Close()
            End Try
        Else
            '插入
            '保存
            Try
                sysOleDbConn.Open()
                rcOleDbTrans = sysOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = sysOleDbConn
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandText = "INSERT INTO rc_yj (ny,jzbz,Invbegin,InvEnd,PoBegin,PoEnd) values (?,0,?,?,?,?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "01"
                rcOleDbCommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp1Begin.Value
                rcOleDbCommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp1End.Value
                rcOleDbCommand.Parameters.Add("@PoBegin", OleDbType.Date, 8).Value = Dtp1Begin.Value
                rcOleDbCommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp1End.Value
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "02"
                rcOleDbCommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp2Begin.Value
                rcOleDbCommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp2End.Value
                rcOleDbCommand.Parameters.Add("@PoBegin", OleDbType.Date, 8).Value = Dtp2Begin.Value
                rcOleDbCommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp2End.Value
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "03"
                rcOleDbCommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp3Begin.Value
                rcOleDbCommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp3End.Value
                rcOleDbCommand.Parameters.Add("@PoBegin", OleDbType.Date, 8).Value = Dtp3Begin.Value
                rcOleDbCommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp3End.Value
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "04"
                rcOleDbCommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp4Begin.Value
                rcOleDbCommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp4End.Value
                rcOleDbCommand.Parameters.Add("@PoBegin", OleDbType.Date, 8).Value = Dtp4Begin.Value
                rcOleDbCommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp4End.Value
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "05"
                rcOleDbCommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp5Begin.Value
                rcOleDbCommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp5End.Value
                rcOleDbCommand.Parameters.Add("@PoBegin", OleDbType.Date, 8).Value = Dtp5Begin.Value
                rcOleDbCommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp5End.Value
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "06"
                rcOleDbCommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp6Begin.Value
                rcOleDbCommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp6End.Value
                rcOleDbCommand.Parameters.Add("@PoBegin", OleDbType.Date, 8).Value = Dtp6Begin.Value
                rcOleDbCommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp6End.Value
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "07"
                rcOleDbCommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp7Begin.Value
                rcOleDbCommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp7End.Value
                rcOleDbCommand.Parameters.Add("@PoBegin", OleDbType.Date, 8).Value = Dtp7Begin.Value
                rcOleDbCommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp7End.Value
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "08"
                rcOleDbCommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp8Begin.Value
                rcOleDbCommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp8End.Value
                rcOleDbCommand.Parameters.Add("@PoBegin", OleDbType.Date, 8).Value = Dtp8Begin.Value
                rcOleDbCommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp8End.Value
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "09"
                rcOleDbCommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp9Begin.Value
                rcOleDbCommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp9End.Value
                rcOleDbCommand.Parameters.Add("@PoBegin", OleDbType.Date, 8).Value = Dtp9Begin.Value
                rcOleDbCommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp9End.Value
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "10"
                rcOleDbCommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp10Begin.Value
                rcOleDbCommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp10End.Value
                rcOleDbCommand.Parameters.Add("@PoBegin", OleDbType.Date, 8).Value = Dtp10Begin.Value
                rcOleDbCommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp10End.Value
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "11"
                rcOleDbCommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp11Begin.Value
                rcOleDbCommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp11End.Value
                rcOleDbCommand.Parameters.Add("@PoBegin", OleDbType.Date, 8).Value = Dtp11Begin.Value
                rcOleDbCommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp11End.Value
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "12"
                rcOleDbCommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp12Begin.Value
                rcOleDbCommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp12End.Value
                rcOleDbCommand.Parameters.Add("@PoBegin", OleDbType.Date, 8).Value = Dtp12Begin.Value
                rcOleDbCommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp12End.Value
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("程序错误5。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误6。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End Try
            Finally
                sysOleDbConn.Close()
            End Try
        End If
        '查找
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_yj WHERE Substr(ny,1,4) = '" & g_Kjrq.Year & "' ORDER BY ny"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("yjdata") IsNot Nothing Then
                rcDataSet.Tables("yjdata").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "yjdata")
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误7。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误8。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("yjdata").Rows.Count > 0 Then
            '更新
            '保存
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            Try
                rcOleDbCommand.CommandText = "UPDATE rc_yj set jzbz = 0,Invbegin = ? ,InvEnd = ?,PoBegin = ? ,PoEnd = ? WHERE ny = ?"
                rcoledbcommand.Parameters.Clear()
                rcoledbcommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp1Begin.Value
                rcoledbcommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp1End.Value
                rcoledbcommand.Parameters.Add("@PoBegin", OleDbType.Date, 8).Value = Dtp1Begin.Value
                rcoledbcommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp1End.Value
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "01"
                rcoledbcommand.ExecuteNonQuery()
                rcoledbcommand.Parameters.Clear()
                rcoledbcommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp2Begin.Value
                rcoledbcommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp2End.Value
                rcoledbcommand.Parameters.Add("@Pobegin", OleDbType.Date, 8).Value = Dtp2Begin.Value
                rcoledbcommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp2End.Value
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "02"
                rcoledbcommand.ExecuteNonQuery()
                rcoledbcommand.Parameters.Clear()
                rcoledbcommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp3Begin.Value
                rcoledbcommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp3End.Value
                rcoledbcommand.Parameters.Add("@Pobegin", OleDbType.Date, 8).Value = Dtp3Begin.Value
                rcoledbcommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp3End.Value
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "03"
                rcoledbcommand.ExecuteNonQuery()
                rcoledbcommand.Parameters.Clear()
                rcoledbcommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp4Begin.Value
                rcoledbcommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp4End.Value
                rcoledbcommand.Parameters.Add("@Pobegin", OleDbType.Date, 8).Value = Dtp4Begin.Value
                rcoledbcommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp4End.Value
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "04"
                rcoledbcommand.ExecuteNonQuery()
                rcoledbcommand.Parameters.Clear()
                rcoledbcommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp5Begin.Value
                rcoledbcommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp5End.Value
                rcoledbcommand.Parameters.Add("@Pobegin", OleDbType.Date, 8).Value = Dtp5Begin.Value
                rcoledbcommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp5End.Value
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "05"
                rcoledbcommand.ExecuteNonQuery()
                rcoledbcommand.Parameters.Clear()
                rcoledbcommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp6Begin.Value
                rcoledbcommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp6End.Value
                rcoledbcommand.Parameters.Add("@Pobegin", OleDbType.Date, 8).Value = Dtp6Begin.Value
                rcoledbcommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp6End.Value
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "06"
                rcoledbcommand.ExecuteNonQuery()
                rcoledbcommand.Parameters.Clear()
                rcoledbcommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp7Begin.Value
                rcoledbcommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp7End.Value
                rcoledbcommand.Parameters.Add("@Pobegin", OleDbType.Date, 8).Value = Dtp7Begin.Value
                rcoledbcommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp7End.Value
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "07"
                rcoledbcommand.ExecuteNonQuery()
                rcoledbcommand.Parameters.Clear()
                rcoledbcommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp8Begin.Value
                rcoledbcommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp8End.Value
                rcoledbcommand.Parameters.Add("@Pobegin", OleDbType.Date, 8).Value = Dtp8Begin.Value
                rcoledbcommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp8End.Value
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "08"
                rcoledbcommand.ExecuteNonQuery()
                rcoledbcommand.Parameters.Clear()
                rcoledbcommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp9Begin.Value
                rcoledbcommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp9End.Value
                rcoledbcommand.Parameters.Add("@Pobegin", OleDbType.Date, 8).Value = Dtp9Begin.Value
                rcoledbcommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp9End.Value
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "09"
                rcoledbcommand.ExecuteNonQuery()
                rcoledbcommand.Parameters.Clear()
                rcoledbcommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp10Begin.Value
                rcoledbcommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp10End.Value
                rcoledbcommand.Parameters.Add("@Pobegin", OleDbType.Date, 8).Value = Dtp10Begin.Value
                rcoledbcommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp10End.Value
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "10"
                rcoledbcommand.ExecuteNonQuery()
                rcoledbcommand.Parameters.Clear()
                rcoledbcommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp11Begin.Value
                rcoledbcommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp11End.Value
                rcoledbcommand.Parameters.Add("@Pobegin", OleDbType.Date, 8).Value = Dtp11Begin.Value
                rcoledbcommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp11End.Value
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "11"
                rcoledbcommand.ExecuteNonQuery()
                rcoledbcommand.Parameters.Clear()
                rcoledbcommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp12Begin.Value
                rcoledbcommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp12End.Value
                rcoledbcommand.Parameters.Add("@Pobegin", OleDbType.Date, 8).Value = Dtp12Begin.Value
                rcoledbcommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp12End.Value
                rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "12"
                rcoledbcommand.ExecuteNonQuery()
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("程序错误9。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误10。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End Try
            Finally
                rcOleDbConn.Close()
            End Try
        Else
            '插入
            '保存
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            Try
                rcOleDbCommand.CommandText = "INSERT INTO rc_yj (ny,jzbz,Invbegin,InvEnd,pobegin,poend) values (?,0,?,?,?,?)"
                rcoledbcommand.Parameters.Clear()
                rcoledbcommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "01"
                rcoledbcommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp1Begin.Value
                rcoledbcommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp1End.Value
                rcoledbcommand.Parameters.Add("@Pobegin", OleDbType.Date, 8).Value = Dtp1Begin.Value
                rcoledbcommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp1End.Value
                rcOleDbCommand.ExecuteNonQuery()
                rcoledbcommand.Parameters.Clear()
                rcoledbcommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "02"
                rcoledbcommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp2Begin.Value
                rcoledbcommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp2End.Value
                rcoledbcommand.Parameters.Add("@Pobegin", OleDbType.Date, 8).Value = Dtp2Begin.Value
                rcoledbcommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp2End.Value
                rcOleDbCommand.ExecuteNonQuery()
                rcoledbcommand.Parameters.Clear()
                rcoledbcommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "03"
                rcoledbcommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp3Begin.Value
                rcoledbcommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp3End.Value
                rcoledbcommand.Parameters.Add("@Pobegin", OleDbType.Date, 8).Value = Dtp3Begin.Value
                rcoledbcommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp3End.Value
                rcOleDbCommand.ExecuteNonQuery()
                rcoledbcommand.Parameters.Clear()
                rcoledbcommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "04"
                rcoledbcommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp4Begin.Value
                rcoledbcommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp4End.Value
                rcoledbcommand.Parameters.Add("@Pobegin", OleDbType.Date, 8).Value = Dtp4Begin.Value
                rcoledbcommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp4End.Value
                rcOleDbCommand.ExecuteNonQuery()
                rcoledbcommand.Parameters.Clear()
                rcoledbcommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "05"
                rcoledbcommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp5Begin.Value
                rcoledbcommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp5End.Value
                rcoledbcommand.Parameters.Add("@Pobegin", OleDbType.Date, 8).Value = Dtp5Begin.Value
                rcoledbcommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp5End.Value
                rcOleDbCommand.ExecuteNonQuery()
                rcoledbcommand.Parameters.Clear()
                rcoledbcommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "06"
                rcoledbcommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp6Begin.Value
                rcoledbcommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp6End.Value
                rcoledbcommand.Parameters.Add("@Pobegin", OleDbType.Date, 8).Value = Dtp6Begin.Value
                rcoledbcommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp6End.Value
                rcOleDbCommand.ExecuteNonQuery()
                rcoledbcommand.Parameters.Clear()
                rcoledbcommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "07"
                rcoledbcommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp7Begin.Value
                rcoledbcommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp7End.Value
                rcoledbcommand.Parameters.Add("@Pobegin", OleDbType.Date, 8).Value = Dtp7Begin.Value
                rcoledbcommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp7End.Value
                rcOleDbCommand.ExecuteNonQuery()
                rcoledbcommand.Parameters.Clear()
                rcoledbcommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "08"
                rcoledbcommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp8Begin.Value
                rcoledbcommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp8End.Value
                rcoledbcommand.Parameters.Add("@Pobegin", OleDbType.Date, 8).Value = Dtp8Begin.Value
                rcoledbcommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp8End.Value
                rcOleDbCommand.ExecuteNonQuery()
                rcoledbcommand.Parameters.Clear()
                rcoledbcommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "09"
                rcoledbcommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp9Begin.Value
                rcoledbcommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp9End.Value
                rcoledbcommand.Parameters.Add("@Pobegin", OleDbType.Date, 8).Value = Dtp9Begin.Value
                rcoledbcommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp9End.Value
                rcOleDbCommand.ExecuteNonQuery()
                rcoledbcommand.Parameters.Clear()
                rcoledbcommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "10"
                rcoledbcommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp10Begin.Value
                rcoledbcommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp10End.Value
                rcoledbcommand.Parameters.Add("@Pobegin", OleDbType.Date, 8).Value = Dtp10Begin.Value
                rcoledbcommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp10End.Value
                rcOleDbCommand.ExecuteNonQuery()
                rcoledbcommand.Parameters.Clear()
                rcoledbcommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "11"
                rcoledbcommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp11Begin.Value
                rcoledbcommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp11End.Value
                rcoledbcommand.Parameters.Add("@Pobegin", OleDbType.Date, 8).Value = Dtp11Begin.Value
                rcoledbcommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp11End.Value
                rcOleDbCommand.ExecuteNonQuery()
                rcoledbcommand.Parameters.Clear()
                rcoledbcommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = g_Kjrq.Year & "12"
                rcoledbcommand.Parameters.Add("@Invbegin", OleDbType.Date, 8).Value = Dtp12Begin.Value
                rcoledbcommand.Parameters.Add("@InvEnd", OleDbType.Date, 8).Value = Dtp12End.Value
                rcoledbcommand.Parameters.Add("@Pobegin", OleDbType.Date, 8).Value = Dtp12Begin.Value
                rcoledbcommand.Parameters.Add("@PoEnd", OleDbType.Date, 8).Value = Dtp12End.Value
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("程序错误11。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误12。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End Try
            Finally
                rcOleDbConn.Close()
            End Try
        End If
        Me.Close()
    End Sub
End Class