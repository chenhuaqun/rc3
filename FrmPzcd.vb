Imports System.Data.OleDb

Public Class FrmPzcd
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    ReadOnly rcOleDbTrans As OleDbTransaction
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim dateBegin As Date = getInvBegin(Me.NudYear.Value, Me.NudMonth.Value)
        Dim dateEnd As Date = getInvEnd(Me.NudYear.Value, Me.NudMonth.Value)

        '取账务系统参数
        Dim strGlPath As String = ""
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
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
                    strGlPath = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                Else
                    MsgBox("请至【选项】设置Anyi311账务系统路径。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")

                    Return
                End If
            Else
                MsgBox("请至【选项】设置Anyi311账务系统路径。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        'Dim dbfOleDbConn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & rcDataSet.Tables("rc_dwdm").Rows(0).Item("glpath") & ";Extended Properties=dBASE IV;User ID=Admin;Password=")
        Dim dbfOleDbConn As New OleDbConnection("Provider=vfpoledb.1;Data Source=" & strGlPath & "\;Collating Sequence=general")
        '取数据（已编制凭证）
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM gl_pz WHERE gl_pz.pzrq >= ? AND gl_pz.pzrq <= ? AND SUBSTR(gl_pz.djh,11, 5) >= ?  AND SUBSTR(gl_pz.djh,11,5) <= ?" & IIf(Me.CmbPzlxjc.SelectedValue <> "0000", " AND SUBSTR(gl_pz.djh,1, 4) ='" & Me.CmbPzlxjc.SelectedValue & "'", "") & " ORDER BY djh,xh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@pzrq", OleDbType.Date, 8).Value = dateBegin
            rcOleDbCommand.Parameters.Add("@pzrq", OleDbType.Date, 8).Value = dateEnd
            rcOleDbCommand.Parameters.Add("@djh1", OleDbType.VarChar, 5).Value = NudDjhBegin.Value.ToString.PadLeft(5, "0")
            rcOleDbCommand.Parameters.Add("@djh2", OleDbType.VarChar, 5).Value = NudDjhEnd.Value.ToString.PadLeft(5, "0")
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("gl_pz") IsNot Nothing Then
                rcDataset.Tables("gl_pz").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "gl_pz")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '取凭证类型与凭证号
        Try
            dbfOleDbConn.Open()
            rcOleDbCommand.Connection = dbfOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzno" & Trim(Me.NudMonth.Text) & " as pzno FROM pzlx" & Me.NudYear.Text & " WHERE pzlxjc = '记账'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("pzlx") IsNot Nothing Then
                rcDataset.Tables("pzlx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "pzlx")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            dbfOleDbConn.Close()
        End Try
        Me.ProgressBar1.Maximum = rcDataset.Tables("gl_pz").Rows.Count
        If rcDataset.Tables("pzlx").Rows.Count > 0 And rcDataset.Tables("gl_pz").Rows.Count > 0 Then
            Dim i As Integer
            Dim mpzh As String = rcDataset.Tables("pzlx").Rows(0).Item("pzno")
            Dim oldpzh As String = ""
            Try
                dbfOleDbConn.Open()
                rcOleDbCommand.Connection = dbfOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                For i = 0 To rcDataset.Tables("gl_pz").Rows.Count - 1
                    If oldpzh <> rcDataset.Tables("gl_pz").Rows(i).Item("djh") Then
                        mpzh += 1
                        oldpzh = rcDataset.Tables("gl_pz").Rows(i).Item("djh")
                    End If
                    Me.ProgressBar1.Value = i + 1
                    rcOleDbCommand.CommandText = "INSERT INTO a_pz" & Trim(NudYear.Text) & " (pzrq,pzh,fjzs,zy,kmdm,dfkm,xmdm,jd,rmb,sr,sh,jzr,wldm,bmdm,wbdm,wb,sl,hl,dj,yspz,jsr,pzhzbz,pzhzkmdy) values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,'',0,0,0,0,'','','','')"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.AddWithValue("@pzrq", RSet(Trim(Str(NudMonth.Value)), 2) + RSet(Trim(Str(NudMonth.Value)), 2) + RSet(Trim(Str(dateEnd.Day)), 2))
                    rcOleDbCommand.Parameters.AddWithValue("@pzh", "记账" + mpzh.PadLeft(4, " "))
                    rcOleDbCommand.Parameters.AddWithValue("@fjzs", rcDataset.Tables("gl_pz").Rows(i).Item("fjzs"))
                    rcOleDbCommand.Parameters.AddWithValue("@zy", rcDataset.Tables("gl_pz").Rows(i).Item("zy"))
                    rcOleDbCommand.Parameters.AddWithValue("@kmdm", rcDataset.Tables("gl_pz").Rows(i).Item("kmdm"))
                    rcOleDbCommand.Parameters.AddWithValue("@dfkm", rcDataset.Tables("gl_pz").Rows(i).Item("dfkm"))
                    rcOleDbCommand.Parameters.AddWithValue("@xmdm", "")
                    rcOleDbCommand.Parameters.AddWithValue("@jd", rcDataset.Tables("gl_pz").Rows(i).Item("jd"))
                    rcOleDbCommand.Parameters.AddWithValue("@rmb", rcDataset.Tables("gl_pz").Rows(i).Item("je"))
                    rcOleDbCommand.Parameters.AddWithValue("@sr", rcDataset.Tables("gl_pz").Rows(i).Item("srr"))
                    rcOleDbCommand.Parameters.AddWithValue("@sh", "")
                    rcOleDbCommand.Parameters.AddWithValue("@jzr", "")
                    rcOleDbCommand.Parameters.AddWithValue("@wldm", "")
                    rcOleDbCommand.Parameters.AddWithValue("@bmdm", "")
                    rcOleDbCommand.ExecuteNonQuery()
                Next
                '更新凭证号
                rcOleDbCommand.CommandText = "UPDATE pzlx" & NudYear.Text & " SET pzno" & Trim(NudMonth.Text) & " = " & mpzh & " where pzlxjc = '记账'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Catch ex As Exception
                Try
                    MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End Try
                Return
            Finally
                dbfOleDbConn.Close()
            End Try
        End If
        MsgBox("凭证传递完成。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
        Me.Close()
    End Sub

    Private Sub FrmPzcd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.NudYear.Value = Mid(getInvKjqj(g_Kjrq), 1, 4)
        Me.NudMonth.Value = Mid(getInvKjqj(g_Kjrq), 5, 2)
        '取凭证类型数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc FROM rc_lx WHERE kjnd = > AND lxgs = '记账凭证' ORDER BY pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(g_Kjqj, 1, 4)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_lx") IsNot Nothing Then
                Me.rcDataset.Tables("rc_lx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_lx")
        Catch ex As Exception
            MsgBox("程序错误。读取凭证类型。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Dim rcDataRow As DataRow
        rcDataRow = rcDataset.Tables("rc_lx").NewRow
        rcDataRow.Item("pzlxdm") = "0000"
        rcDataRow.Item("pzlxjc") = "全部凭证"
        rcDataset.Tables("rc_lx").Rows.Add(rcDataRow)
        If rcDataset.Tables("rc_lx").Rows.Count = 0 Then
            MsgBox("请定义凭证类型。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        BindDropDownList(CmbPzlxjc, rcDataset.Tables("rc_lx"), "pzlxdm", "pzlxjc")
        CmbPzlxjc.SelectedValue = "0000"
    End Sub
End Class