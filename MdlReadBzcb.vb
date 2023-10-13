Imports System.Data.OleDb

Module MdlReadBzcb

    Friend Function ReadBzcb(ByVal strCpdm As String) As Double
        '建立数据适配器
        Dim rcOleDbDataAdpt As New OleDbDataAdapter
        '建立DataSet对象
        Dim rcDataset As New DataSet
        '建立OleDbCommand对象
        Dim rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
        Dim dateSysdate As Date
        '取服务器系统时间
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT SYSDATE FROM dual"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_sysdate") IsNot Nothing Then
                rcDataSet.Tables("rc_sysdate").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_sysdate")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("rc_sysdate").Rows.Count = 1 Then
            dateSysdate = rcDataSet.Tables("rc_sysdate").Rows(0).Item("sysdate")
        Else
            dateSysdate = Now()
        End If
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT COALESCE(bzcb,0.0) AS bzcb FROM pm_bzcb WHERE tzrq < ? AND cpdm = ? ORDER BY tzrq DESC"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@tzrq", OleDbType.Date, 8).Value = dateSysdate
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = strCpdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("pm_bzcb") IsNot Nothing Then
                rcDataSet.Tables("pm_bzcb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "pm_bzcb")
            rcOleDbCommand.CommandText = "SELECT bzcb FROM rc_cpxx WHERE cpdm = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = strCpdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_cpxx") IsNot Nothing Then
                rcDataSet.Tables("rc_cpxx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_cpxx")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return 0
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("pm_bzcb").Rows.Count = 0 Then
            If rcDataSet.Tables("rc_cpxx").Rows.Count = 0 Then
                Return 0
            Else
                Return rcDataSet.Tables("rc_cpxx").Rows(0).Item("bzcb")
            End If
        Else
            Return rcDataSet.Tables("pm_bzcb").Rows(0).Item("bzcb")
        End If
    End Function

End Module
