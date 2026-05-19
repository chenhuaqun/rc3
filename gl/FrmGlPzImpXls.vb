Imports System.Data.OleDb
Public Class FrmGlPzImpXls
    '建立数据适配器
    Dim rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    Dim rcDataset As New DataSet
    '数据更新传递
    Dim rcOleDbTrans As OleDbTransaction
    '建立命令
    Dim rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '会计期间
    Dim strKjqj As String = g_Kjqj
    '单据类型
    Dim strPzlxdm As String = ""

#Region "初始化"

    Public Property ParaStrKjqj() As String
        Get
            ParaStrKjqj = strKjqj
        End Get
        Set(ByVal Value As String)
            strKjqj = Value
        End Set
    End Property

    Public Property ParaStrPzlxdm() As String
        Get
            ParaStrPzlxdm = strPzlxdm
        End Get
        Set(ByVal Value As String)
            strPzlxdm = Value
        End Set
    End Property

#End Region

#Region "读入数据"

    Private Sub BtnXzwj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXzwj.Click
        If Me.OfdSourceExcelFileName.ShowDialog = DialogResult.OK Then
            Me.TxtSourceExcelFileName.Text = Me.OfdSourceExcelFileName.FileName
        End If
    End Sub

    Function ReadExcel(ByVal strFileName As String, ByVal strSheetName As String) As Boolean
        Dim strConnection As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = " + strFileName + ";Extended Properties = Excel 12.0"
        Dim oleConnection As New OleDbConnection(strConnection)
        Try
            oleConnection.Open()
            Dim oleAdper As New OleDbDataAdapter(" SELECT * FROM [" + strSheetName + "$]", oleConnection)
            If rcDataset.Tables("result") IsNot Nothing Then
                rcDataset.Tables("result").Clear()
                rcDataset.Tables("result").Columns.Clear()
            End If
            oleAdper.Fill(rcDataset, "result")
        Catch ex As Exception
            MsgBox("你选择的文件不是Excel文件格式，请重新选择" & Chr(13) & ex.ToString(), MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return False
        Finally
            oleConnection.Close()
        End Try
        Return True
    End Function

    Private Sub TsbImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsbImp.Click, MnuiImp.Click
        If ReadExcel(Me.TxtSourceExcelFileName.Text, Me.TxtSheetName.Text) = True Then
            Me.DataGridView1.DataSource = rcDataset.Tables("result")
            Dim i As Integer
            For i = 0 To Me.DataGridView1.Columns.Count - 1
                Me.DataGridView1.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        End If
    End Sub

#End Region

#Region "保存事件"

    Private Sub TsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsbSave.Click
        Dim i As Integer
        'For i = 0 To rcDataset.Tables("result").Rows.Count - 1
        '    If rcDataset.Tables("result").Rows(i).Item("职员编码").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("职员编码") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("职员姓名").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("职员姓名") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("部门编码").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("部门编码") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("部门名称").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("部门名称") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("仓库编码").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("仓库编码") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("仓库名称").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("仓库名称") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("物料编码").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("物料编码") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("物料描述").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("物料描述") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("订单号").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("订单号") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("数量").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("数量") = 0.0
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("单位").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("单位") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("换算系数").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("换算系数") = 0.0
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("辅数量").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("辅数量") = 0.0
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("辅单位").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("辅单位") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("单价").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("单价") = 0.0
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("金额").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("金额") = 0.0
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("备注").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("备注") = ""
        '    End If
        'Next
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "DELETE FROM gl_pz WHERE substr(djh,5,6)= ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = strKjqj
            rcOleDbCommand.ExecuteNonQuery()
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
        For i = 0 To rcDataset.Tables("result").Rows.Count - 1
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                'Me.ProgressBar1.Value = i + 1
                rcOleDbCommand.CommandText = "INSERT INTO gl_pz (djh,cperiod,pzlxdm,pzh,xh,bdelete,pzrq,fjzs,jd,zy,kmdm,kmmc,bmdm,bmmc,zydm,zymc,xmdm,xmmc,khdm,khmc,csdm,csmc,jxzh,yhzh,dfkm,dw,sl,dj,bz,wb,hl,je,yspz,jsr,wldqr,srr,srrq,shr,shrq,jzr,jzrq) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = rcDataset.Tables("result").Rows(i).Item("凭证类别").ToString.PadRight(4, "0") & strKjqj & Trim(rcDataset.Tables("result").Rows(i).Item("凭证编号").ToString).PadLeft(5, "0")
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.Char, 6).Value = strKjqj
                rcOleDbCommand.Parameters.Add("@pzlxdm", OleDbType.VarChar, 4).Value = rcDataset.Tables("result").Rows(i).Item("凭证类别").ToString.PadRight(4, "0")
                rcOleDbCommand.Parameters.Add("@pzh", OleDbType.Numeric, 5).Value = rcDataset.Tables("result").Rows(i).Item("凭证编号")
                rcOleDbCommand.Parameters.Add("@xh", OleDbType.Numeric, 6).Value = i
                rcOleDbCommand.Parameters.Add("@bdelete", OleDbType.Numeric, 1).Value = 0
                rcOleDbCommand.Parameters.Add("@pzrq", OleDbType.Date, 8).Value = rcDataset.Tables("result").Rows(i).Item("制单日期")
                rcOleDbCommand.Parameters.Add("@fjzs", OleDbType.Numeric, 4).Value = rcDataset.Tables("result").Rows(i).Item("附单据数")
                rcOleDbCommand.Parameters.Add("@jd", OleDbType.Char, 2).Value = IIf(rcDataset.Tables("result").Rows(i).Item("借贷方向") = "借方", "借", "贷")
                rcOleDbCommand.Parameters.Add("@zy", OleDbType.VarChar, 200).Value = rcDataset.Tables("result").Rows(i).Item("摘要")
                rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("result").Rows(i).Item("科目编码")
                rcOleDbCommand.Parameters.Add("@kmmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("result").Rows(i).Item("科目")
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("部门编码")
                rcOleDbCommand.Parameters.Add("@bmmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("result").Rows(i).Item("部门")
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = "~"
                rcOleDbCommand.Parameters.Add("@zymc", OleDbType.VarChar, 200).Value = "~"
                rcOleDbCommand.Parameters.Add("@xmdm", OleDbType.VarChar, 12).Value = "~"
                rcOleDbCommand.Parameters.Add("@xmmc", OleDbType.VarChar, 200).Value = "~"
                rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = IIf(Mid(rcDataset.Tables("result").Rows(i).Item("科目编码"), 1, 4) <> "2202", rcDataset.Tables("result").Rows(i).Item("往来单位编码"), "~")
                rcOleDbCommand.Parameters.Add("@khmc", OleDbType.VarChar, 100).Value = IIf(Mid(rcDataset.Tables("result").Rows(i).Item("科目编码"), 1, 4) <> "2202", rcDataset.Tables("result").Rows(i).Item("往来单位"), "~")
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = IIf(Mid(rcDataset.Tables("result").Rows(i).Item("科目编码"), 1, 4) = "2202", rcDataset.Tables("result").Rows(i).Item("往来单位编码"), "~")
                rcOleDbCommand.Parameters.Add("@csmc", OleDbType.VarChar, 100).Value = IIf(Mid(rcDataset.Tables("result").Rows(i).Item("科目编码"), 1, 4) = "2202", rcDataset.Tables("result").Rows(i).Item("往来单位"), "~")
                rcOleDbCommand.Parameters.Add("@jxzh", OleDbType.VarChar, 12).Value = "~"
                rcOleDbCommand.Parameters.Add("@yhzh", OleDbType.VarChar, 12).Value = "~"
                rcOleDbCommand.Parameters.Add("@dfkm", OleDbType.VarChar, 50).Value = "~"
                rcOleDbCommand.Parameters.Add("@dw", OleDbType.VarChar, 50).Value = "~"
                rcOleDbCommand.Parameters.Add("@sl", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("数量")
                rcOleDbCommand.Parameters.Add("@dj", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("单价")
                rcOleDbCommand.Parameters.Add("@bz", OleDbType.VarChar, 12).Value = IIf(rcDataset.Tables("result").Rows(i).Item("币种") = "人民币", "CNY", rcDataset.Tables("result").Rows(i).Item("币种"))
                rcOleDbCommand.Parameters.Add("@wb", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("原币")
                rcOleDbCommand.Parameters.Add("@hl", OleDbType.Numeric, 18).Value = 0.0
                rcOleDbCommand.Parameters.Add("@je", OleDbType.Numeric, 14).Value = rcDataset.Tables("result").Rows(i).Item("本币")
                rcOleDbCommand.Parameters.Add("@yspz", OleDbType.VarChar, 16).Value = "~"
                rcOleDbCommand.Parameters.Add("@jsr", OleDbType.VarChar, 30).Value = "~"
                rcOleDbCommand.Parameters.Add("@wldqr", OleDbType.Date, 8).Value = Now.Date
                rcOleDbCommand.Parameters.Add("@srr", OleDbType.VarChar, 30).Value = "~"
                rcOleDbCommand.Parameters.Add("@srrq", OleDbType.Date, 8).Value = Now.Date
                rcOleDbCommand.Parameters.Add("@shr", OleDbType.VarChar, 30).Value = "~"
                rcOleDbCommand.Parameters.Add("@shrq", OleDbType.Date, 8).Value = Now.Date
                rcOleDbCommand.Parameters.Add("@jzr", OleDbType.VarChar, 30).Value = "~"
                rcOleDbCommand.Parameters.Add("@jzrq", OleDbType.Date, 8).Value = Now.Date
                rcOleDbCommand.ExecuteNonQuery()
                '检测科目编码
                If rcDataset.Tables("result").Rows(i).Item("科目编码").GetType.ToString <> "System.DBNull" Then
                    rcOleDbCommand.CommandText = "SELECT kmdm FROM gl_kmxx WHERE kmdm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("result").Rows(i).Item("科目编码")
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("gl_kmxx") IsNot Nothing Then
                        rcDataset.Tables("gl_kmxx").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "gl_kmxx")
                    If rcDataset.Tables("gl_kmxx").Rows.Count = 0 Then
                        rcOleDbCommand.CommandText = "INSERT INTO gl_kmxx (kmdm,kmmc) VALUES (?,?)"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@kmdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("result").Rows(i).Item("科目编码")
                        rcOleDbCommand.Parameters.Add("@kmmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("result").Rows(i).Item("科目")
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                End If
                '检测外币编码
                If rcDataset.Tables("result").Rows(i).Item("币种").ToString <> "System.DBNull" Then
                    rcOleDbCommand.CommandText = "SELECT wbdm FROM rc_wbxx WHERE kjnd = ? AND wbdm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(strKjqj, 1, 4)
                    rcOleDbCommand.Parameters.Add("@wbdm", OleDbType.VarChar, 4).Value = IIf(rcDataset.Tables("result").Rows(i).Item("币种") = "人民币", "CNY", rcDataset.Tables("result").Rows(i).Item("币种"))
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("rc_wbxx") IsNot Nothing Then
                        rcDataset.Tables("rc_wbxx").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "rc_wbxx")
                    If rcDataset.Tables("rc_wbxx").Rows.Count = 0 Then
                        rcOleDbCommand.CommandText = "INSERT INTO rc_wbxx (kjnd,wbdm,wbmc) VALUES (?,?,?)"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(strKjqj, 1, 4)
                        rcOleDbCommand.Parameters.Add("@wbdm", OleDbType.VarChar, 4).Value = IIf(rcDataset.Tables("result").Rows(i).Item("币种") = "人民币", "CNY", rcDataset.Tables("result").Rows(i).Item("币种"))
                        rcOleDbCommand.Parameters.Add("@wbmc", OleDbType.VarChar, 8).Value = rcDataset.Tables("result").Rows(i).Item("币种")
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                End If
                If rcDataset.Tables("result").Rows(i).Item("往来单位编码").ToString <> "System.DBNull" Then
                    '检测客户编码
                    If Mid(rcDataset.Tables("result").Rows(i).Item("科目编码"), 1, 4) = "1122" Then
                        rcOleDbCommand.CommandText = "SELECT khdm FROM rc_khxx WHERE khdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("result").Rows(i).Item("往来单位编码")
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_khxx") IsNot Nothing Then
                            rcDataset.Tables("rc_khxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_khxx")
                        If rcDataset.Tables("rc_khxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_khxx (khdm,khmc) VALUES (?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("result").Rows(i).Item("往来单位编码")
                            rcOleDbCommand.Parameters.Add("@khmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("result").Rows(i).Item("往来单位")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    If Mid(rcDataset.Tables("result").Rows(i).Item("科目编码"), 1, 4) = "2202" Then
                        '检测供应商编码
                        rcOleDbCommand.CommandText = "SELECT csdm FROM rc_csxx WHERE csdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("往来单位编码")
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_csxx") IsNot Nothing Then
                            rcDataset.Tables("rc_csxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_csxx")
                        If rcDataset.Tables("rc_csxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_csxx (csdm,csmc,zczb,fktj,fkts) VALUES (?,?,0,'月结',0)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("往来单位编码")
                            rcOleDbCommand.Parameters.Add("@csmc", OleDbType.VarChar, 100).Value = rcDataset.Tables("result").Rows(i).Item("往来单位")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                Else

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
        Next
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            '重新汇总总帐
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP3_REDO_KMYEHZ"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@year", OleDbType.VarChar, 4).Value = Mid(strKjqj, 1, 4)
            rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
            rcOleDbCommand.ExecuteNonQuery()
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
        MsgBox("记账凭证读入完成,请检查数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        Me.Close()
    End Sub

#End Region

#Region "退出事件"

    Private Sub TsbExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TsbExit.Click, MnuiExit.Click
        Me.Close()
    End Sub

#End Region

End Class