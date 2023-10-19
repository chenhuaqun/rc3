Imports System.Data.OleDb

Public Class FrmGlKmkhYeb

#Region "定义变量"

    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As New OleDbCommand

#End Region

    Private Sub FrmGlKmkhYeb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        Me.NudYear.Value = Mid(g_Kjqj, 1, 4)
        Me.NudMonthBegin.Value = Mid(g_Kjqj, 5, 2)
        Me.NudMonthEnd.Value = Mid(g_Kjqj, 5, 2)
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim i As Integer
        '取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "Select a.root AS kmdm,jiajia.kmmc,'' AS khdm,'' AS khmc,jiajia.bmjs,CASE WHEN NVL(SUM(qcye),0) > 0 THEN NVL(SUM(qcye),0) ELSE 0 END AS qcjf,CASE WHEN NVL(SUM(qcye),0) < 0 THEN 0 - NVL(SUM(qcye),0) ELSE 0 END AS qcdf,NVL(SUM(bqjf),0) AS bqjf,NVL(SUM(bqdf),0) AS bqdf,CASE WHEN NVL(SUM(qcye),0) + NVL(SUM(bqjf),0) - NVL(SUM(bqdf),0) > 0 THEN NVL(SUM(qcye),0) + NVL(SUM(bqjf),0) - NVL(SUM(bqdf),0) ELSE 0 END AS qmjf,CASE WHEN NVL(SUM(qcye),0) + NVL(SUM(bqjf),0) - NVL(SUM(bqdf),0) < 0 THEN 0 - NVL(SUM(qcye),0) - NVL(SUM(bqjf),0) + NVL(SUM(bqdf),0) ELSE 0 END AS qmdf,NVL(SUM(ljjf),0) AS ljjf,NVL(SUM(ljdf),0) AS ljdf"
            'For i = 0 To rcDataSet.Tables("rc_dgtbc").Rows.Count - 1
            '    rcOleDbCommand.CommandText = rcOleDbCommand.CommandText & ",NVL(SUM(" & rcDataSet.Tables("rc_dgtbc").Rows(i).Item("fieldname") & "),0) AS " & rcDataSet.Tables("rc_dgtbc").Rows(i).Item("fieldname")
            'Next
            rcOleDbCommand.CommandText &= " FROM (SELECT kmdm, parentid, connect_by_root(kmdm) root FROM (SELECT gl_kmxx.kmdm, gl_kmxx.parentid FROM gl_kmxx START WITH gl_kmxx.kmkh = 1 CONNECT BY PRIOR gl_kmxx.parentid = gl_kmxx.kmdm) connect by prior kmdm = parentid) a  Left Join (SELECT kmdm,COUNT(1) AS cnt_hs,NVL(SUM(CASE WHEN jd = '借' THEN ncje ELSE 0 - ncje END"
            For i = 1 To Me.NudMonthBegin.Value - 1
                rcOleDbCommand.CommandText = rcOleDbCommand.CommandText & "+jfje" & i.ToString.PadLeft(2, "0") & " - dfje" & i.ToString.PadLeft(2, "0")
            Next
            rcOleDbCommand.CommandText &= "),0) AS qcye,NVL(SUM("
            For i = Me.NudMonthBegin.Value To Me.NudMonthEnd.Value
                rcOleDbCommand.CommandText = rcOleDbCommand.CommandText & IIf(i = Me.NudMonthBegin.Value, "", "+") & "jfje" & i.ToString.PadLeft(2, "0")
            Next
            rcOleDbCommand.CommandText &= "),0) AS bqjf,NVL(SUM("
            For i = Me.NudMonthBegin.Value To Me.NudMonthEnd.Value
                rcOleDbCommand.CommandText = rcOleDbCommand.CommandText & IIf(i = Me.NudMonthBegin.Value, "", "+") & "dfje" & i.ToString.PadLeft(2, "0")
            Next
            rcOleDbCommand.CommandText &= "),0) AS bqdf,NVL(SUM("
            For i = 1 To Me.NudMonthEnd.Value
                rcOleDbCommand.CommandText = rcOleDbCommand.CommandText & IIf(i = 1, "", "+") & "jfje" & i.ToString.PadLeft(2, "0")
            Next
            rcOleDbCommand.CommandText &= "),0) AS ljjf,NVL(SUM("
            For i = 1 To Me.NudMonthEnd.Value
                rcOleDbCommand.CommandText = rcOleDbCommand.CommandText & IIf(i = 1, "", "+") & "dfje" & i.ToString.PadLeft(2, "0")
            Next
            rcOleDbCommand.CommandText &= "),0) AS ljdf FROM gl_kmyeb WHERE gl_kmyeb.kjnd = ? GROUP BY gl_kmyeb.kmdm) b ON a.kmdm = b.kmdm LEFT JOIN (SELECT gl_kmxx.kmdm,gl_kmxx.kmmc,gl_kmxx.parentid,level AS bmjs from gl_kmxx start with gl_kmxx.parentid Is null connect by prior gl_kmxx.kmdm = gl_kmxx.parentid) jiajia ON a.root = jiajia.kmdm GROUP BY a.root,jiajia.kmmc,jiajia.bmjs HAVING SUM(cnt_hs) >0 ORDER BY root"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
            'MsgBox(rcOleDbCommand.CommandText)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("zzyeb") IsNot Nothing Then
                rcDataSet.Tables("zzyeb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "zzyeb")
            '科目客户明细
            rcOleDbCommand.CommandText = "Select zzyeba.kmdm,gl_kmxx.kmmc,zzyeba.khdm,rc_khxx.khmc,Case When zzyeba.qcye > 0 Then zzyeba.qcye Else 0 End As qcjf,Case When zzyeba.qcye < 0 Then 0- zzyeba.qcye Else 0 End As qcdf,zzyeba.bqjf,zzyeba.bqdf,Case When zzyeba.qmye > 0 Then zzyeba.qmye Else 0 End As qmjf,Case When zzyeba.qmye < 0 Then 0 - zzyeba.qmye Else 0 End As qmdf,zzyeba.ljjf,zzyeba.ljdf"
            rcOleDbCommand.CommandText &= " From (Select kmdm,khdm,NVL(SUM(Case When jd = '借' Then ncje Else 0 - ncje End"
            For i = 1 To Me.NudMonthBegin.Value - 1
                rcOleDbCommand.CommandText = rcOleDbCommand.CommandText & " + jfje" & i.ToString.PadLeft(2, "0") & " - dfje" & i.ToString.PadLeft(2, "0")
            Next
            rcOleDbCommand.CommandText &= "),0) As qcye,NVL(SUM("
            For i = Me.NudMonthBegin.Value To Me.NudMonthEnd.Value
                rcOleDbCommand.CommandText = rcOleDbCommand.CommandText & IIf(i = Me.NudMonthBegin.Value, "", " + ") & "jfje" & i.ToString.PadLeft(2, "0")
            Next
            rcOleDbCommand.CommandText &= "),0) As bqjf,NVL(SUM("
            For i = Me.NudMonthBegin.Value To Me.NudMonthEnd.Value
                rcOleDbCommand.CommandText = rcOleDbCommand.CommandText & IIf(i = Me.NudMonthBegin.Value, "", " + ") & "dfje" & i.ToString.PadLeft(2, "0")
            Next
            rcOleDbCommand.CommandText &= "),0) As bqdf,NVL(SUM("
            rcOleDbCommand.CommandText &= "Case When jd = '借' Then ncje Else 0- ncje End"
            For i = 1 To Me.NudMonthEnd.Value
                rcOleDbCommand.CommandText = rcOleDbCommand.CommandText & " + jfje" & i.ToString.PadLeft(2, "0") & " - dfje" & i.ToString.PadLeft(2, "0")
            Next
            rcOleDbCommand.CommandText &= "),0) As qmye,NVL(SUM("
            For i = 1 To Me.NudMonthEnd.Value
                rcOleDbCommand.CommandText = rcOleDbCommand.CommandText & IIf(i = 1, "", " + ") & "jfje" & i.ToString.PadLeft(2, "0")
            Next
            rcOleDbCommand.CommandText &= "),0) As ljjf,NVL(SUM("
            For i = 1 To Me.NudMonthEnd.Value
                rcOleDbCommand.CommandText = rcOleDbCommand.CommandText & IIf(i = 1, "", " + ") & "dfje" & i.ToString.PadLeft(2, "0")
            Next
            rcOleDbCommand.CommandText &= "),0) As ljdf  FROM gl_kmyeb WHERE khdm <> '~' AND gl_kmyeb.kjnd = ? GROUP BY gl_kmyeb.khdm,gl_kmyeb.kmdm) zzyeba ,gl_kmxx,rc_khxx Where zzyeba.kmdm = gl_kmxx.kmdm AND zzyeba.khdm = rc_khxx.khdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            rcOleDbDataAdpt.Fill(rcDataSet, "zzyeb")
            'rcOleDbCommand.CommandText = "SELECT zzyebb.kmdm,gl_kmxx.kmmc,SUM(zzyebb.qcjf) AS qcjf,SUM(zzyebb.qcdf) AS qcdf,SUM(zzyebb.bqjf) AS bqjf,SUM(zzyebb.bqdf) AS bqdf,SUM(zzyebb.qmjf) AS qmjf,SUM(zzyebb.qmdf) AS qmdf,SUM(zzyebb.ljjf) AS ljjf,SUM(zzyebb.ljdf) AS ljdf FROM" & _
            '    " (SELECT gl_kmxx.parentid AS kmdm,Case When zzyeba.qcye > 0 Then zzyeba.qcye Else 0 End As qcjf,Case When zzyeba.qcye < 0 Then 0- zzyeba.qcye Else 0 End As qcdf,zzyeba.bqjf,zzyeba.bqdf,Case When zzyeba.qmye > 0 Then zzyeba.qmye Else 0 End As qmjf,Case When zzyeba.qmye < 0 Then 0 - zzyeba.qmye Else 0 End As qmdf,zzyeba.ljjf,zzyeba.ljdf"
            'rcOleDbCommand.CommandText = rcOleDbCommand.CommandText & " From (Select kmdm,Case When jd = '借' Then ncje Else 0 - ncje End"
            'For i = 1 To Me.NudMonthBegin.Value - 1
            '    rcOleDbCommand.CommandText = rcOleDbCommand.CommandText & " + jfje" & i.ToString.PadLeft(2, "0") & " - dfje" & i.ToString.PadLeft(2, "0")
            'Next
            'rcOleDbCommand.CommandText = rcOleDbCommand.CommandText & " As qcye,"
            'For i = Me.NudMonthBegin.Value To Me.NudMonthEnd.Value
            '    rcOleDbCommand.CommandText = rcOleDbCommand.CommandText & IIf(i = Me.NudMonthBegin.Value, "", " + ") & "jfje" & i.ToString.PadLeft(2, "0")
            'Next
            'rcOleDbCommand.CommandText = rcOleDbCommand.CommandText & " As bqjf,"
            'For i = Me.NudMonthBegin.Value To Me.NudMonthEnd.Value
            '    rcOleDbCommand.CommandText = rcOleDbCommand.CommandText & IIf(i = Me.NudMonthBegin.Value, "", " + ") & "dfje" & i.ToString.PadLeft(2, "0")
            'Next
            'rcOleDbCommand.CommandText = rcOleDbCommand.CommandText & " As bqdf,"
            'rcOleDbCommand.CommandText = rcOleDbCommand.CommandText & "Case When jd = '借' Then ncje Else 0- ncje End"
            'For i = 1 To Me.NudMonthEnd.Value
            '    rcOleDbCommand.CommandText = rcOleDbCommand.CommandText & " + jfje" & i.ToString.PadLeft(2, "0") & " - dfje" & i.ToString.PadLeft(2, "0")
            'Next
            'rcOleDbCommand.CommandText = rcOleDbCommand.CommandText & " As qmye,"
            'For i = 1 To Me.NudMonthEnd.Value
            '    rcOleDbCommand.CommandText = rcOleDbCommand.CommandText & IIf(i = 1, "", " + ") & "jfje" & i.ToString.PadLeft(2, "0")
            'Next
            'rcOleDbCommand.CommandText = rcOleDbCommand.CommandText & " As ljjf,"
            'For i = 1 To Me.NudMonthEnd.Value
            '    rcOleDbCommand.CommandText = rcOleDbCommand.CommandText & IIf(i = 1, "", " + ") & "dfje" & i.ToString.PadLeft(2, "0")
            'Next
            'rcOleDbCommand.CommandText = rcOleDbCommand.CommandText & " As ljdf  From gl_kmyeb) zzyeba ,gl_kmxx Where zzyeba.kmdm = gl_kmxx.kmdm AND NOT gl_kmxx.parentid IS NULL) zzyebb,gl_kmxx WHERE zzyebb.kmdm = gl_kmxx.kmdm GROUP BY zzyebb.kmdm,gl_kmxx.kmmc"
            'rcOleDbCommand.Parameters.Clear()
            'rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            'rcOleDbDataAdpt.Fill(rcDataSet, "zzyeb")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Dim rcFrm As New FrmGlKmkhYebz
        With rcFrm
            .ParaDataView = New DataView(rcDataSet.Tables("zzyeb"), "TRUE", "kmdm,khdm", DataViewRowState.CurrentRows)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class