Imports System.Data.OleDb

Public Class FrmKhdmGg
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Private Sub FrmKhdmGg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TxtOldKhdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtOldKhdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_khxx"
                    .paraField1 = "khdm"
                    .paraField2 = "khmc"
                    .paraField3 = "khsm"
                    .paraCondition = "0=0"
                    .paraOrderField = "khmc"
                    .paraTitle = "客户"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtOldKhdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Return, Keys.Down
                Me.TxtNewKhdm.Focus()
            Case Keys.Up
                Me.BtnHelp.Focus()
        End Select
    End Sub

    Private Sub TxtNewKhdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNewKhdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_khxx"
                    .paraField1 = "khdm"
                    .paraField2 = "khmc"
                    .paraField3 = "khsm"
                    .paraCondition = "0=0"
                    .paraOrderField = "khmc"
                    .paraTitle = "客户"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtNewKhdm.Text = Trim(.paraField1)
                    End If
                End With
            Case Keys.Return, Keys.Down
                Me.BtnOk.Focus()
            Case Keys.Up
                Me.TxtOldKhdm.Focus()
        End Select
    End Sub

    Private Sub TxtOldKhdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtOldKhdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtOldKhdm.Text) Then
            '读取数据
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT  *  From rc_khxx Where khdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtOldKhdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("oldkhxx") IsNot Nothing Then
                    rcDataSet.Tables("oldkhxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "oldkhxx")
            Catch ex As Exception
                MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("oldkhxx").Rows.Count > 0 Then
                If rcDataSet.Tables("oldkhxx").Rows(0).Item("khmc").GetType.ToString <> "System.DBNull" Then
                    TxtOldKhmc.Text = rcDataSet.Tables("oldkhxx").Rows(0).Item("khmc")
                End If
            Else
                MsgBox("该客户编码不存在。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                TxtOldKhdm.Focus()
            End If
        End If
    End Sub

    Private Sub TxtNewKhdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNewKhdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtNewKhdm.Text) Then
            '读取数据
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "SELECT  *  From rc_khxx Where khdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtNewKhdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("newkhxx") IsNot Nothing Then
                    rcDataSet.Tables("newkhxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "newkhxx")
            Catch ex As Exception
                MsgBox("程序错误2。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("newkhxx").Rows.Count > 0 Then
                If rcDataSet.Tables("newkhxx").Rows(0).Item("khmc").GetType.ToString <> "System.DBNull" Then
                    TxtNewKhmc.Text = rcDataSet.Tables("newkhxx").Rows(0).Item("khmc")
                End If
            Else
                Me.TxtNewKhmc.Text = Me.TxtOldKhmc.Text
            End If
        End If
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If rcDataSet.Tables("newkhxx") Is Nothing Then
            Return
        End If
        If rcDataSet.Tables("oldkhxx") Is Nothing Then
            Return
        End If
        '同一编码则返回
        If Me.TxtOldKhdm.Text = Me.TxtNewKhdm.Text Then
            MsgBox("客户编码相同，不需要更改。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        If rcDataSet.Tables("newkhxx").Rows.Count > 0 Then
            If Not MsgBox("新客户编码已经存在。您是否要合并客户编码？", MsgBoxStyle.YesNo + MsgBoxStyle.Information + MsgBoxStyle.DefaultButton2, "提示信息") = MsgBoxResult.Yes Then
                TxtNewKhdm.Text = ""
                TxtNewKhmc.Text = ""
                TxtNewKhdm.Focus()
                Return
            End If
        End If
        '下面开始更改编码
        '(1)AR_KHYEB(需要合并)
        '读取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT kjnd,Sum(Nvl(qcje,0.0)) as qcje,Sum(Nvl(idje,0.0)) as idje FROM ar_khyeb WHERE (khdm = ? or khdm = ?) GROUP BY kjnd"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtNewKhdm.Text)
            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtOldKhdm.Text)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("sumkhyeb") IsNot Nothing Then
                rcDataset.Tables("sumkhyeb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "sumkhyeb")
            '科目余额表
            rcOleDbCommand.CommandText = "SELECT kjnd,kmdm,bmdm,zydm,xmdm,csdm,yhzh,jxzh,'借' AS jd,SUM(CASE WHEN jd ='借' THEN ncsl ELSE 0 - ncsl END) AS ncsl,SUM(CASE WHEN jd ='借' THEN ncwb ELSE 0 - ncwb END) AS ncwb,SUM(CASE WHEN jd ='借' THEN ncje ELSE 0 - ncje END) AS ncje" &
                    ",SUM(CASE WHEN jd ='借' THEN jfsl01 ELSE 0 - jfsl01 END) AS jfsl01,SUM(CASE WHEN jd ='借' THEN jfwb01 ELSE 0 - jfwb01 END) AS jfwb01,SUM(CASE WHEN jd ='借' THEN jfje01 ELSE 0 - jfje01 END) AS jfje01" &
                    ",SUM(CASE WHEN jd ='借' THEN dfsl01 ELSE 0 - dfsl01 END) AS dfsl01,SUM(CASE WHEN jd ='借' THEN dfwb01 ELSE 0 - dfwb01 END) AS dfwb01,SUM(CASE WHEN jd ='借' THEN dfje01 ELSE 0 - dfje01 END) AS dfje01" &
                    ",SUM(CASE WHEN jd ='借' THEN jfsl02 ELSE 0 - jfsl02 END) AS jfsl02,SUM(CASE WHEN jd ='借' THEN jfwb02 ELSE 0 - jfwb02 END) AS jfwb02,SUM(CASE WHEN jd ='借' THEN jfje02 ELSE 0 - jfje02 END) AS jfje02" &
                    ",SUM(CASE WHEN jd ='借' THEN dfsl02 ELSE 0 - dfsl02 END) AS dfsl02,SUM(CASE WHEN jd ='借' THEN dfwb02 ELSE 0 - dfwb02 END) AS dfwb02,SUM(CASE WHEN jd ='借' THEN dfje02 ELSE 0 - dfje02 END) AS dfje02" &
                    ",SUM(CASE WHEN jd ='借' THEN jfsl03 ELSE 0 - jfsl03 END) AS jfsl03,SUM(CASE WHEN jd ='借' THEN jfwb03 ELSE 0 - jfwb03 END) AS jfwb03,SUM(CASE WHEN jd ='借' THEN jfje03 ELSE 0 - jfje03 END) AS jfje03" &
                    ",SUM(CASE WHEN jd ='借' THEN dfsl03 ELSE 0 - dfsl03 END) AS dfsl03,SUM(CASE WHEN jd ='借' THEN dfwb03 ELSE 0 - dfwb03 END) AS dfwb03,SUM(CASE WHEN jd ='借' THEN dfje03 ELSE 0 - dfje03 END) AS dfje03" &
                    ",SUM(CASE WHEN jd ='借' THEN jfsl04 ELSE 0 - jfsl04 END) AS jfsl04,SUM(CASE WHEN jd ='借' THEN jfwb04 ELSE 0 - jfwb04 END) AS jfwb04,SUM(CASE WHEN jd ='借' THEN jfje04 ELSE 0 - jfje04 END) AS jfje04" &
                    ",SUM(CASE WHEN jd ='借' THEN dfsl04 ELSE 0 - dfsl04 END) AS dfsl04,SUM(CASE WHEN jd ='借' THEN dfwb04 ELSE 0 - dfwb04 END) AS dfwb04,SUM(CASE WHEN jd ='借' THEN dfje04 ELSE 0 - dfje04 END) AS dfje04" &
                    ",SUM(CASE WHEN jd ='借' THEN jfsl05 ELSE 0 - jfsl05 END) AS jfsl05,SUM(CASE WHEN jd ='借' THEN jfwb05 ELSE 0 - jfwb05 END) AS jfwb05,SUM(CASE WHEN jd ='借' THEN jfje05 ELSE 0 - jfje05 END) AS jfje05" &
                    ",SUM(CASE WHEN jd ='借' THEN dfsl05 ELSE 0 - dfsl05 END) AS dfsl05,SUM(CASE WHEN jd ='借' THEN dfwb05 ELSE 0 - dfwb05 END) AS dfwb05,SUM(CASE WHEN jd ='借' THEN dfje05 ELSE 0 - dfje05 END) AS dfje05" &
                    ",SUM(CASE WHEN jd ='借' THEN jfsl06 ELSE 0 - jfsl06 END) AS jfsl06,SUM(CASE WHEN jd ='借' THEN jfwb06 ELSE 0 - jfwb06 END) AS jfwb06,SUM(CASE WHEN jd ='借' THEN jfje06 ELSE 0 - jfje06 END) AS jfje06" &
                    ",SUM(CASE WHEN jd ='借' THEN dfsl06 ELSE 0 - dfsl06 END) AS dfsl06,SUM(CASE WHEN jd ='借' THEN dfwb06 ELSE 0 - dfwb06 END) AS dfwb06,SUM(CASE WHEN jd ='借' THEN dfje06 ELSE 0 - dfje06 END) AS dfje06" &
                    ",SUM(CASE WHEN jd ='借' THEN jfsl07 ELSE 0 - jfsl07 END) AS jfsl07,SUM(CASE WHEN jd ='借' THEN jfwb07 ELSE 0 - jfwb07 END) AS jfwb07,SUM(CASE WHEN jd ='借' THEN jfje07 ELSE 0 - jfje07 END) AS jfje07" &
                    ",SUM(CASE WHEN jd ='借' THEN dfsl07 ELSE 0 - dfsl07 END) AS dfsl07,SUM(CASE WHEN jd ='借' THEN dfwb07 ELSE 0 - dfwb07 END) AS dfwb07,SUM(CASE WHEN jd ='借' THEN dfje07 ELSE 0 - dfje07 END) AS dfje07" &
                    ",SUM(CASE WHEN jd ='借' THEN jfsl08 ELSE 0 - jfsl08 END) AS jfsl08,SUM(CASE WHEN jd ='借' THEN jfwb08 ELSE 0 - jfwb08 END) AS jfwb08,SUM(CASE WHEN jd ='借' THEN jfje08 ELSE 0 - jfje08 END) AS jfje08" &
                    ",SUM(CASE WHEN jd ='借' THEN dfsl08 ELSE 0 - dfsl08 END) AS dfsl08,SUM(CASE WHEN jd ='借' THEN dfwb08 ELSE 0 - dfwb08 END) AS dfwb08,SUM(CASE WHEN jd ='借' THEN dfje08 ELSE 0 - dfje08 END) AS dfje08" &
                    ",SUM(CASE WHEN jd ='借' THEN jfsl09 ELSE 0 - jfsl09 END) AS jfsl09,SUM(CASE WHEN jd ='借' THEN jfwb09 ELSE 0 - jfwb09 END) AS jfwb09,SUM(CASE WHEN jd ='借' THEN jfje09 ELSE 0 - jfje09 END) AS jfje09" &
                    ",SUM(CASE WHEN jd ='借' THEN dfsl09 ELSE 0 - dfsl09 END) AS dfsl09,SUM(CASE WHEN jd ='借' THEN dfwb09 ELSE 0 - dfwb09 END) AS dfwb09,SUM(CASE WHEN jd ='借' THEN dfje09 ELSE 0 - dfje09 END) AS dfje09" &
                    ",SUM(CASE WHEN jd ='借' THEN jfsl10 ELSE 0 - jfsl10 END) AS jfsl10,SUM(CASE WHEN jd ='借' THEN jfwb10 ELSE 0 - jfwb10 END) AS jfwb10,SUM(CASE WHEN jd ='借' THEN jfje10 ELSE 0 - jfje10 END) AS jfje10" &
                    ",SUM(CASE WHEN jd ='借' THEN dfsl10 ELSE 0 - dfsl10 END) AS dfsl10,SUM(CASE WHEN jd ='借' THEN dfwb10 ELSE 0 - dfwb10 END) AS dfwb10,SUM(CASE WHEN jd ='借' THEN dfje10 ELSE 0 - dfje10 END) AS dfje10" &
                    ",SUM(CASE WHEN jd ='借' THEN jfsl11 ELSE 0 - jfsl11 END) AS jfsl11,SUM(CASE WHEN jd ='借' THEN jfwb11 ELSE 0 - jfwb11 END) AS jfwb11,SUM(CASE WHEN jd ='借' THEN jfje11 ELSE 0 - jfje11 END) AS jfje11" &
                    ",SUM(CASE WHEN jd ='借' THEN dfsl11 ELSE 0 - dfsl11 END) AS dfsl11,SUM(CASE WHEN jd ='借' THEN dfwb11 ELSE 0 - dfwb11 END) AS dfwb11,SUM(CASE WHEN jd ='借' THEN dfje11 ELSE 0 - dfje11 END) AS dfje11" &
                    ",SUM(CASE WHEN jd ='借' THEN jfsl12 ELSE 0 - jfsl12 END) AS jfsl12,SUM(CASE WHEN jd ='借' THEN jfwb12 ELSE 0 - jfwb12 END) AS jfwb12,SUM(CASE WHEN jd ='借' THEN jfje12 ELSE 0 - jfje12 END) AS jfje12" &
                    ",SUM(CASE WHEN jd ='借' THEN dfsl12 ELSE 0 - dfsl12 END) AS dfsl12,SUM(CASE WHEN jd ='借' THEN dfwb12 ELSE 0 - dfwb12 END) AS dfwb12,SUM(CASE WHEN jd ='借' THEN dfje12 ELSE 0 - dfje12 END) AS dfje12" &
                    ",SUM(CASE WHEN jd ='借' THEN jfsl13 ELSE 0 - jfsl13 END) AS jfsl13,SUM(CASE WHEN jd ='借' THEN jfwb13 ELSE 0 - jfwb13 END) AS jfwb13,SUM(CASE WHEN jd ='借' THEN jfje13 ELSE 0 - jfje13 END) AS jfje13" &
                    ",SUM(CASE WHEN jd ='借' THEN dfsl13 ELSE 0 - dfsl13 END) AS dfsl13,SUM(CASE WHEN jd ='借' THEN dfwb13 ELSE 0 - dfwb13 END) AS dfwb13,SUM(CASE WHEN jd ='借' THEN dfje13 ELSE 0 - dfje13 END) AS dfje13" &
                    " FROM gl_kmyeb WHERE (khdm = ? or khdm = ?) GROUP BY kjnd,kmdm,bmdm,zydm,xmdm,csdm,yhzh,jxzh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtNewKhdm.Text)
            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtOldKhdm.Text)
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("sumkmyeb") IsNot Nothing Then
                rcDataSet.Tables("sumkmyeb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "sumkmyeb")

            '取带khdm字段的表
            rcOleDbCommand.CommandText = "SELECT table_name,column_name FROM user_tab_columns WHERE column_name = 'KHDM' AND table_name <> 'AR_KHYEB' AND table_name <> 'RC_KHXX' AND table_name <> 'GL_KMYEB' AND table_name <> 'GL_YWFJSB'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("user_tab_columns") IsNot Nothing Then
                rcDataSet.Tables("user_tab_columns").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "user_tab_columns")
        Catch ex As Exception
            MsgBox("程序错误10。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Dim i As Integer
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '删除原来的数据
            rcOleDbCommand.CommandText = "DELETE FROM ar_khyeb WHERE (khdm = ? or khdm = ?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtNewKhdm.Text)
            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtOldKhdm.Text)
            rcOleDbCommand.ExecuteNonQuery()
            '添加数据
            For i = 0 To rcDataset.Tables("sumkhyeb").Rows.Count - 1
                rcOleDbCommand.CommandText = "INSERT INTO ar_khyeb (kjnd,khdm,khmc,qcje,idje) VALUES (?,?,?,?,?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = rcDataset.Tables("sumkhyeb").Rows(i).Item("kjnd")
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Me.TxtNewKhdm.Text
                rcOleDbCommand.Parameters.Add("@khmc", OleDbType.VarChar, 12).Value = Me.TxtNewKhmc.Text
                rcOleDbCommand.Parameters.Add("@qcje", OleDbType.VarNumeric, 14).Value = rcDataset.Tables("sumkhyeb").Rows(i).Item("qcje")
                rcOleDbCommand.Parameters.Add("@idje", OleDbType.VarNumeric, 14).Value = rcDataset.Tables("sumkhyeb").Rows(i).Item("idje")
                rcOleDbCommand.ExecuteNonQuery()
            Next
            '删除业务费计算表的数据
            rcOleDbCommand.CommandText = "DELETE FROM gl_ywfjsb WHERE (khdm = ? or khdm = ?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtNewKhdm.Text)
            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtOldKhdm.Text)
            rcOleDbCommand.ExecuteNonQuery()
            '删除原来的数据
            rcOleDbCommand.CommandText = "DELETE FROM gl_kmyeb WHERE (khdm = ? or khdm = ?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtNewKhdm.Text)
            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtOldKhdm.Text)
            rcOleDbCommand.ExecuteNonQuery()
            '添加数据
            For i = 0 To rcDataSet.Tables("sumkmyeb").Rows.Count - 1
                rcOleDbCommand.CommandText = "INSERT INTO gl_kmyeb (kjnd,kmdm,bmdm,zydm,xmdm,khdm,csdm,yhzh,jxzh,jd,ncsl,ncwb,ncje" &
                    ",jfsl01,jfwb01,jfje01,dfsl01,dfwb01,dfje01" &
                    ",jfsl02,jfwb02,jfje02,dfsl02,dfwb02,dfje02" &
                    ",jfsl03,jfwb03,jfje03,dfsl03,dfwb03,dfje03" &
                    ",jfsl04,jfwb04,jfje04,dfsl04,dfwb04,dfje04" &
                    ",jfsl05,jfwb05,jfje05,dfsl05,dfwb05,dfje05" &
                    ",jfsl06,jfwb06,jfje06,dfsl06,dfwb06,dfje06" &
                    ",jfsl07,jfwb07,jfje07,dfsl07,dfwb07,dfje07" &
                    ",jfsl08,jfwb08,jfje08,dfsl08,dfwb08,dfje08" &
                    ",jfsl09,jfwb09,jfje09,dfsl09,dfwb09,dfje09" &
                    ",jfsl10,jfwb10,jfje10,dfsl10,dfwb10,dfje10" &
                    ",jfsl11,jfwb11,jfje11,dfsl11,dfwb11,dfje11" &
                    ",jfsl12,jfwb12,jfje12,dfsl12,dfwb12,dfje12" &
                    ",jfsl13,jfwb13,jfje13,dfsl13,dfwb13,dfje13)" &
                    " VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = rcDataSet.Tables("sumkmyeb").Rows(i).Item("kjnd")
                rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = rcDataSet.Tables("sumkmyeb").Rows(i).Item("kmdm")
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("sumkmyeb").Rows(i).Item("bmdm")
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("sumkmyeb").Rows(i).Item("zydm")
                rcOleDbCommand.Parameters.Add("@xmdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("sumkmyeb").Rows(i).Item("xmdm")
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Me.TxtNewKhdm.Text
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = rcDataSet.Tables("sumkmyeb").Rows(i).Item("csdm")
                rcOleDbCommand.Parameters.Add("@yhzh", OleDbType.VarChar, 12).Value = rcDataSet.Tables("sumkmyeb").Rows(i).Item("yhzh")
                rcOleDbCommand.Parameters.Add("@jxzh", OleDbType.VarChar, 12).Value = rcDataSet.Tables("sumkmyeb").Rows(i).Item("jxzh")
                rcOleDbCommand.Parameters.Add("@jd", OleDbType.VarChar, 4).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, "借", "贷")
                rcOleDbCommand.Parameters.Add("@ncsl", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncsl"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncsl"))
                rcOleDbCommand.Parameters.Add("@ncwb", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncwb"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncwb"))
                rcOleDbCommand.Parameters.Add("@ncje", OleDbType.VarNumeric, 14).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje"))
                rcOleDbCommand.Parameters.Add("@jfsl01", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfsl01"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfsl01"))
                rcOleDbCommand.Parameters.Add("@jfwb01", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfwb01"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfwb01"))
                rcOleDbCommand.Parameters.Add("@jfje01", OleDbType.VarNumeric, 14).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfje01"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfje01"))
                rcOleDbCommand.Parameters.Add("@dfsl01", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfsl01"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfsl01"))
                rcOleDbCommand.Parameters.Add("@dfwb01", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfwb01"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfwb01"))
                rcOleDbCommand.Parameters.Add("@dfje01", OleDbType.VarNumeric, 14).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfje01"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfje01"))
                rcOleDbCommand.Parameters.Add("@jfsl02", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfsl02"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfsl02"))
                rcOleDbCommand.Parameters.Add("@jfwb02", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfwb02"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfwb02"))
                rcOleDbCommand.Parameters.Add("@jfje02", OleDbType.VarNumeric, 14).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfje02"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfje02"))
                rcOleDbCommand.Parameters.Add("@dfsl02", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfsl02"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfsl02"))
                rcOleDbCommand.Parameters.Add("@dfwb02", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfwb02"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfwb02"))
                rcOleDbCommand.Parameters.Add("@dfje02", OleDbType.VarNumeric, 14).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfje02"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfje02"))
                rcOleDbCommand.Parameters.Add("@jfsl03", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfsl03"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfsl03"))
                rcOleDbCommand.Parameters.Add("@jfwb03", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfwb03"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfwb03"))
                rcOleDbCommand.Parameters.Add("@jfje03", OleDbType.VarNumeric, 14).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfje03"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfje03"))
                rcOleDbCommand.Parameters.Add("@dfsl03", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfsl03"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfsl03"))
                rcOleDbCommand.Parameters.Add("@dfwb03", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfwb03"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfwb03"))
                rcOleDbCommand.Parameters.Add("@dfje03", OleDbType.VarNumeric, 14).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfje03"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfje03"))
                rcOleDbCommand.Parameters.Add("@jfsl04", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfsl04"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfsl04"))
                rcOleDbCommand.Parameters.Add("@jfwb04", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfwb04"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfwb04"))
                rcOleDbCommand.Parameters.Add("@jfje04", OleDbType.VarNumeric, 14).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfje04"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfje04"))
                rcOleDbCommand.Parameters.Add("@dfsl04", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfsl04"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfsl04"))
                rcOleDbCommand.Parameters.Add("@dfwb04", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfwb04"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfwb04"))
                rcOleDbCommand.Parameters.Add("@dfje04", OleDbType.VarNumeric, 14).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfje04"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfje04"))
                rcOleDbCommand.Parameters.Add("@jfsl05", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfsl05"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfsl05"))
                rcOleDbCommand.Parameters.Add("@jfwb05", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfwb05"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfwb05"))
                rcOleDbCommand.Parameters.Add("@jfje05", OleDbType.VarNumeric, 14).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfje05"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfje05"))
                rcOleDbCommand.Parameters.Add("@dfsl05", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfsl05"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfsl05"))
                rcOleDbCommand.Parameters.Add("@dfwb05", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfwb05"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfwb05"))
                rcOleDbCommand.Parameters.Add("@dfje05", OleDbType.VarNumeric, 14).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfje05"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfje05"))
                rcOleDbCommand.Parameters.Add("@jfsl06", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfsl06"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfsl06"))
                rcOleDbCommand.Parameters.Add("@jfwb06", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfwb06"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfwb06"))
                rcOleDbCommand.Parameters.Add("@jfje06", OleDbType.VarNumeric, 14).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfje06"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfje06"))
                rcOleDbCommand.Parameters.Add("@dfsl06", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfsl06"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfsl06"))
                rcOleDbCommand.Parameters.Add("@dfwb06", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfwb06"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfwb06"))
                rcOleDbCommand.Parameters.Add("@dfje06", OleDbType.VarNumeric, 14).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfje06"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfje06"))
                rcOleDbCommand.Parameters.Add("@jfsl07", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfsl07"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfsl07"))
                rcOleDbCommand.Parameters.Add("@jfwb07", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfwb07"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfwb07"))
                rcOleDbCommand.Parameters.Add("@jfje07", OleDbType.VarNumeric, 14).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfje07"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfje07"))
                rcOleDbCommand.Parameters.Add("@dfsl07", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfsl07"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfsl07"))
                rcOleDbCommand.Parameters.Add("@dfwb07", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfwb07"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfwb07"))
                rcOleDbCommand.Parameters.Add("@dfje07", OleDbType.VarNumeric, 14).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfje07"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfje07"))
                rcOleDbCommand.Parameters.Add("@jfsl08", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfsl08"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfsl08"))
                rcOleDbCommand.Parameters.Add("@jfwb08", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfwb08"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfwb08"))
                rcOleDbCommand.Parameters.Add("@jfje08", OleDbType.VarNumeric, 14).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfje08"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfje08"))
                rcOleDbCommand.Parameters.Add("@dfsl08", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfsl08"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfsl08"))
                rcOleDbCommand.Parameters.Add("@dfwb08", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfwb08"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfwb08"))
                rcOleDbCommand.Parameters.Add("@dfje08", OleDbType.VarNumeric, 14).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfje08"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfje08"))
                rcOleDbCommand.Parameters.Add("@jfsl09", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfsl09"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfsl09"))
                rcOleDbCommand.Parameters.Add("@jfwb09", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfwb09"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfwb09"))
                rcOleDbCommand.Parameters.Add("@jfje09", OleDbType.VarNumeric, 14).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfje09"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfje09"))
                rcOleDbCommand.Parameters.Add("@dfsl09", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfsl09"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfsl09"))
                rcOleDbCommand.Parameters.Add("@dfwb09", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfwb09"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfwb09"))
                rcOleDbCommand.Parameters.Add("@dfje09", OleDbType.VarNumeric, 14).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfje09"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfje09"))
                rcOleDbCommand.Parameters.Add("@jfsl10", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfsl10"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfsl10"))
                rcOleDbCommand.Parameters.Add("@jfwb10", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfwb10"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfwb10"))
                rcOleDbCommand.Parameters.Add("@jfje10", OleDbType.VarNumeric, 14).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfje10"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfje10"))
                rcOleDbCommand.Parameters.Add("@dfsl10", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfsl10"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfsl10"))
                rcOleDbCommand.Parameters.Add("@dfwb10", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfwb10"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfwb10"))
                rcOleDbCommand.Parameters.Add("@dfje10", OleDbType.VarNumeric, 14).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfje10"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfje10"))
                rcOleDbCommand.Parameters.Add("@jfsl11", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfsl11"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfsl11"))
                rcOleDbCommand.Parameters.Add("@jfwb11", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfwb11"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfwb11"))
                rcOleDbCommand.Parameters.Add("@jfje11", OleDbType.VarNumeric, 14).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfje11"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfje11"))
                rcOleDbCommand.Parameters.Add("@dfsl11", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfsl11"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfsl11"))
                rcOleDbCommand.Parameters.Add("@dfwb11", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfwb11"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfwb11"))
                rcOleDbCommand.Parameters.Add("@dfje11", OleDbType.VarNumeric, 14).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfje11"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfje11"))
                rcOleDbCommand.Parameters.Add("@jfsl12", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfsl12"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfsl12"))
                rcOleDbCommand.Parameters.Add("@jfwb12", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfwb12"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfwb12"))
                rcOleDbCommand.Parameters.Add("@jfje12", OleDbType.VarNumeric, 14).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfje12"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfje12"))
                rcOleDbCommand.Parameters.Add("@dfsl12", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfsl12"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfsl12"))
                rcOleDbCommand.Parameters.Add("@dfwb12", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfwb12"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfwb12"))
                rcOleDbCommand.Parameters.Add("@dfje12", OleDbType.VarNumeric, 14).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfje12"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfje12"))
                rcOleDbCommand.Parameters.Add("@jfsl13", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfsl13"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfsl13"))
                rcOleDbCommand.Parameters.Add("@jfwb13", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfwb13"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfwb13"))
                rcOleDbCommand.Parameters.Add("@jfje13", OleDbType.VarNumeric, 14).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfje13"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("jfje13"))
                rcOleDbCommand.Parameters.Add("@dfsl13", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfsl13"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfsl13"))
                rcOleDbCommand.Parameters.Add("@dfwb13", OleDbType.VarNumeric, 18).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfwb13"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfwb13"))
                rcOleDbCommand.Parameters.Add("@dfje13", OleDbType.VarNumeric, 14).Value = IIf(rcDataSet.Tables("sumkmyeb").Rows(i).Item("ncje") >= 0, rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfje13"), 0 - rcDataSet.Tables("sumkmyeb").Rows(i).Item("dfje13"))
                rcOleDbCommand.ExecuteNonQuery()
            Next
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误13。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误14。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            For i = 0 To rcDataSet.Tables("user_tab_columns").Rows.Count - 1
                rcOleDbCommand.CommandText = "UPDATE " & rcDataSet.Tables("user_tab_columns").Rows(i).Item("table_name") & " SET khdm = ? WHERE khdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtNewKhdm.Text)
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtOldKhdm.Text)
                rcOleDbCommand.ExecuteNonQuery()
            Next
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误15。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误16。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '(12)RC_KHXX(需要删除/或更改)
        If rcDataSet.Tables("newkhxx").Rows.Count > 0 Then
            '删除旧编码
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "DELETE From rc_khxx Where khdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtOldKhdm.Text)
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("程序错误17。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误18。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        Else
            '更改旧编码
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            Try
                rcOleDbCommand.CommandText = "UPDATE rc_khxx SET khdm = ? WHERE khdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtNewKhdm.Text)
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(Me.TxtOldKhdm.Text)
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("程序错误19。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Catch ey As OleDbException
                    MsgBox("程序错误20。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        End If
        '(13)记录更改或合并记录
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "INSERT INTO rc_khdmtz (tzrq,oldkhdm,oldkhmc,newkhdm,newkhmc,ynhb,srr) VALUES (?,?,?,?,?,?,?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@tzrq", OleDbType.Date, 8).Value = Now.Date
            rcOleDbCommand.Parameters.Add("@oldkhdm", OleDbType.VarChar, 12).Value = Me.TxtOldKhdm.Text
            rcOleDbCommand.Parameters.Add("@oldkhmc", OleDbType.VarChar, 40).Value = Me.TxtOldKhmc.Text
            rcOleDbCommand.Parameters.Add("@newkhdm", OleDbType.VarChar, 12).Value = Me.TxtNewKhdm.Text
            rcOleDbCommand.Parameters.Add("@newkhmc", OleDbType.VarChar, 40).Value = Me.TxtNewKhmc.Text
            If rcDataSet.Tables("newkhxx").Rows.Count > 0 Then
                rcOleDbCommand.Parameters.Add("@ynhb", OleDbType.VarNumeric, 1).Value = 1
            Else
                rcOleDbCommand.Parameters.Add("@ynhb", OleDbType.VarNumeric, 1).Value = 0
            End If
            rcOleDbCommand.Parameters.Add("@srr", OleDbType.VarChar, 10).Value = g_User_DspName
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误21。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误22。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        MsgBox("更改与合并客户编码完成。" & Chr(13) & "请检查库存数量及金额、应收、应付等的数据正确性。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        Me.TxtOldKhdm.Text = ""
        Me.TxtNewKhdm.Text = ""
        Me.TxtOldKhmc.Text = ""
        Me.TxtNewKhmc.Text = ""
        Me.TxtOldKhdm.Focus()
    End Sub

End Class