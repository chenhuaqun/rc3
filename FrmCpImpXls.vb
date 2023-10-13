Imports System.Data.OleDb
Public Class FrmCpImpXls
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '数据更新传递
    Dim rcOleDbTrans As OleDbTransaction
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '会计期间
    Dim strKjqj As String = g_Kjqj

#Region "初始化"

    Public Property ParaStrKjqj() As String
        Get
            ParaStrKjqj = strKjqj
        End Get
        Set(ByVal Value As String)
            strKjqj = Value
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
        Dim j As Integer
        'For i = 0 To rcDataset.Tables("result").Rows.Count - 1
        '    If rcDataset.Tables("result").Rows(i).Item("物料类别编码").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("物料类别编码") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("物料类别名称").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("物料类别名称") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("物料编码").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("物料编码") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("物料描述").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("物料描述") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("单位").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("单位") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("换算系数").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("换算系数") = 0.0
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("辅单位").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("辅单位") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("默认仓库编码").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("默认仓库编码") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("默认仓库名称").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("默认仓库名称") = ""
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("标准成本").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("标准成本") = 0.0
        '    End If
        '    If rcDataset.Tables("result").Rows(i).Item("克重").GetType.ToString = "System.DBNull" Then
        '        rcDataset.Tables("result").Rows(i).Item("克重") = 0.0
        '    End If
        'Next
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '取带cpdm字段的表
            rcOleDbCommand.CommandText = "SELECT table_name,column_name FROM user_tab_columns WHERE column_name = 'CPDM' AND table_name <> 'RC_CPXX' AND table_name <> 'PO_CSCPCGDJ'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                rcDataset.Tables("user_tab_columns").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
            For i = 0 To rcDataset.Tables("result").Rows.Count - 1
                If Me.RadioButton1.Checked Then
                    '查找已保存的数据
                    rcOleDbCommand.CommandText = "SELECT * FROM rc_cpxx WHERE cpdm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("物料编码")).ToUpper
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("cntcpxx") IsNot Nothing Then
                        rcDataset.Tables("cntcpxx").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "cntcpxx")
                    If rcDataset.Tables("cntcpxx").Rows.Count > 0 Then
                        '存在
                        '标准成本
                        If rcDataset.Tables("result").Rows(i).Item("标准成本").GetType.ToString <> "System.DBNull" Then
                            If rcDataset.Tables("result").Rows(i).Item("材料成本").GetType.ToString = "System.DBNull" Then
                                rcDataset.Tables("result").Rows(i).Item("材料成本") = 0.0
                            End If
                            If rcDataset.Tables("result").Rows(i).Item("倍数").GetType.ToString = "System.DBNull" Then
                                rcDataset.Tables("result").Rows(i).Item("倍数") = 1
                            End If
                            If rcDataset.Tables("result").Rows(i).Item("标准成本") <> 0 Then
                                rcOleDbCommand.CommandText = "UPDATE rc_cpxx SET bzcb = ?,clcb = ?,beishu = ? WHERE cpdm = ?"
                                rcOleDbCommand.Parameters.Clear()
                                rcOleDbCommand.Parameters.Add("@bzcb", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("标准成本")
                                rcOleDbCommand.Parameters.Add("@clcb", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("材料成本")
                                rcOleDbCommand.Parameters.Add("@beishu", OleDbType.Numeric, 12).Value = rcDataset.Tables("result").Rows(i).Item("倍数")
                                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("物料编码")).ToUpper
                                rcOleDbCommand.ExecuteNonQuery()
                            End If
                        End If
                        '更新克重
                        If rcDataset.Tables("result").Rows(i).Item("克重").GetType.ToString <> "System.DBNull" Then
                            If rcDataset.Tables("result").Rows(i).Item("克重") <> 0 Then
                                rcOleDbCommand.CommandText = "UPDATE rc_cpxx SET cpweight = ? WHERE cpdm = ?"
                                rcOleDbCommand.Parameters.Clear()
                                rcOleDbCommand.Parameters.Add("@cpweight", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("克重")
                                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("物料编码")).ToUpper
                                rcOleDbCommand.ExecuteNonQuery()
                            End If
                        End If
                        '更新销售单价
                        If rcDataset.Tables("result").Rows(i).Item("销售单价").GetType.ToString <> "System.DBNull" Then
                            If rcDataset.Tables("result").Rows(i).Item("销售单价") <> 0 Then
                                rcOleDbCommand.CommandText = "UPDATE rc_cpxx SET xsdj = ? WHERE cpdm = ?"
                                rcOleDbCommand.Parameters.Clear()
                                rcOleDbCommand.Parameters.Add("@cpweight", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("销售单价")
                                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("物料编码")).ToUpper
                                rcOleDbCommand.ExecuteNonQuery()
                            End If
                        End If
                    Else
                        '不存在,则不操作
                    End If
                End If
                If Me.RadioButton2.Checked Then
                    rcOleDbCommand.CommandText = "SELECT * FROM rc_cpxx WHERE cpdm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("物料编码")).ToUpper
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("cntcpxx") IsNot Nothing Then
                        rcDataset.Tables("cntcpxx").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "cntcpxx")
                    If rcDataset.Tables("cntcpxx").Rows.Count = 0 Then
                        Dim blnExists As Boolean
                        '不存在,则查找有没有业务发生
                        For j = 0 To rcDataset.Tables("user_tab_columns").Rows.Count - 1
                            rcOleDbCommand.CommandText = "SELECT COUNT(*) AS gs FROM " & rcDataset.Tables("user_tab_columns").Rows(j).Item("table_name") & " WHERE cpdm = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("物料编码")).ToUpper
                            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                            If rcDataset.Tables("cntgs") IsNot Nothing Then
                                rcDataset.Tables("cntgs").Clear()
                            End If
                            rcOleDbDataAdpt.Fill(rcDataset, "cntgs")
                            If rcDataset.Tables("cntgs").Rows(0).Item("gs") > 0 Then
                                blnExists = True
                                'MsgBox(Trim(rcDataset.Tables("result").Rows(i).Item("物料编码")).ToUpper)
                            End If
                            If blnExists = True Then
                                Exit For
                            End If
                        Next
                        If blnExists Then
                            '添加物料属性信息
                            rcOleDbCommand.CommandText = "INSERT INTO rc_cpxx (lbdm,cpdm,cpmc,dw,ckdm,mjsl,fzdw,bzcb,clcb,beishu,cpweight,srr,srrq) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,SYSDATE)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("result").Rows(i).Item("物料类别编码")).ToUpper
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("物料编码")).ToUpper
                            rcOleDbCommand.Parameters.Add("@cpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("result").Rows(i).Item("物料描述")
                            rcOleDbCommand.Parameters.Add("@dw", OleDbType.VarChar, 8).Value = rcDataset.Tables("result").Rows(i).Item("单位")
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("默认仓库编码")
                            rcOleDbCommand.Parameters.Add("@mjsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("换算系数")
                            rcOleDbCommand.Parameters.Add("@fzdw", OleDbType.VarChar, 8).Value = rcDataset.Tables("result").Rows(i).Item("辅单位")
                            rcOleDbCommand.Parameters.Add("@bzcb", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("标准成本")
                            rcOleDbCommand.Parameters.Add("@clcb", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("材料成本")
                            rcOleDbCommand.Parameters.Add("@beishu", OleDbType.Numeric, 12).Value = rcDataset.Tables("result").Rows(i).Item("倍数")
                            rcOleDbCommand.Parameters.Add("@cpweight", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("克重")
                            rcOleDbCommand.Parameters.Add("@srr", OleDbType.VarChar, 30).Value = g_User_DspName
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    Else
                        '存在,不操作
                    End If
                End If
                If Me.RadioButton3.Checked Or Me.RadioButton4.Checked Then
                    '查找已保存的数据
                    rcOleDbCommand.CommandText = "SELECT * FROM rc_cpxx WHERE cpdm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("物料编码")).ToUpper
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("cntcpxx") IsNot Nothing Then
                        rcDataset.Tables("cntcpxx").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "cntcpxx")
                    If rcDataset.Tables("cntcpxx").Rows.Count > 0 Then
                        If RadioButton3.Checked Then
                            '存在
                            '更新克重，标准成本
                            'rcOleDbCommand.CommandText = "UPDATE rc_cpxx SET bzcb = ?,clcb = ?,cpweight = ?,beishu = ? WHERE cpdm = ?"
                            'rcOleDbCommand.Parameters.Clear()
                            'rcOleDbCommand.Parameters.Add("@bzcb", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("标准成本")
                            'rcOleDbCommand.Parameters.Add("@clcb", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("材料成本")
                            'rcOleDbCommand.Parameters.Add("@cpweight", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("克重")
                            'rcOleDbCommand.Parameters.Add("@beishu", OleDbType.Numeric, 12).Value = rcDataset.Tables("result").Rows(i).Item("倍数")
                            'rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("物料编码")).ToUpper
                            'rcOleDbCommand.ExecuteNonQuery()
                            If rcDataset.Tables("result").Rows(i).Item("标准成本").GetType.ToString <> "System.DBNull" Then
                                If rcDataset.Tables("result").Rows(i).Item("标准成本") <> 0 Then
                                    rcOleDbCommand.CommandText = "UPDATE rc_cpxx SET bzcb = ?,clcb = ?,beishu = ? WHERE cpdm = ?"
                                    rcOleDbCommand.Parameters.Clear()
                                    rcOleDbCommand.Parameters.Add("@bzcb", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("标准成本")
                                    rcOleDbCommand.Parameters.Add("@clcb", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("材料成本")
                                    rcOleDbCommand.Parameters.Add("@beishu", OleDbType.Numeric, 12).Value = rcDataset.Tables("result").Rows(i).Item("倍数")
                                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("物料编码")).ToUpper
                                    rcOleDbCommand.ExecuteNonQuery()
                                End If
                            End If
                            If rcDataset.Tables("result").Rows(i).Item("克重").GetType.ToString <> "System.DBNull" Then
                                If rcDataset.Tables("result").Rows(i).Item("克重") <> 0 Then
                                    rcOleDbCommand.CommandText = "UPDATE rc_cpxx SET cpweight = ? WHERE cpdm = ?"
                                    rcOleDbCommand.Parameters.Clear()
                                    rcOleDbCommand.Parameters.Add("@cpweight", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("克重")
                                    rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("物料编码")).ToUpper
                                    rcOleDbCommand.ExecuteNonQuery()
                                End If
                            End If
                        End If
                    Else
                        '不存在,则追加
                        rcOleDbCommand.CommandText = "INSERT INTO rc_cpxx (lbdm,cpdm,cpmc,dw,ckdm,mjsl,fzdw,bzcb,clcb,beishu,cpweight,srr,srrq) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,SYSDATE)"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("result").Rows(i).Item("物料类别编码")).ToUpper
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("物料编码")).ToUpper
                        rcOleDbCommand.Parameters.Add("@cpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("result").Rows(i).Item("物料描述")
                        rcOleDbCommand.Parameters.Add("@dw", OleDbType.VarChar, 8).Value = rcDataset.Tables("result").Rows(i).Item("单位")
                        rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("默认仓库编码")
                        rcOleDbCommand.Parameters.Add("@mjsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("换算系数")
                        rcOleDbCommand.Parameters.Add("@fzdw", OleDbType.VarChar, 8).Value = rcDataset.Tables("result").Rows(i).Item("辅单位")
                        rcOleDbCommand.Parameters.Add("@bzcb", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("标准成本")
                        rcOleDbCommand.Parameters.Add("@clcb", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("材料成本")
                        rcOleDbCommand.Parameters.Add("@beishu", OleDbType.Numeric, 12).Value = rcDataset.Tables("result").Rows(i).Item("倍数")
                        rcOleDbCommand.Parameters.Add("@cpweight", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("克重")
                        rcOleDbCommand.Parameters.Add("@srr", OleDbType.VarChar, 30).Value = g_User_DspName
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                End If
                If Me.RadioButton5.Checked Then
                    If rcDataset.Tables("result").Rows(i).Item("物料类别编码").GetType.ToString <> "System.DBNull" Then
                        rcOleDbCommand.CommandText = "UPDATE rc_cpxx SET lbdm = ? WHERE cpdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("物料类别编码")
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("物料编码")).ToUpper
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                End If
            Next
            rcOleDbTrans.Commit()
        Catch ex As Exception
            MsgBox("执行程序时发生了错误。" & Chr(13) & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        MsgBox("物料属性读入完成,请检查数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        Me.Close()
    End Sub

#End Region

#Region "退出事件"

    Private Sub TsbExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TsbExit.Click, MnuiExit.Click
        Me.Close()
    End Sub

#End Region

End Class