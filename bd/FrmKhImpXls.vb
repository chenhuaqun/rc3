Imports System.Data.OleDb
Public Class FrmKhImpXls
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
        For i = 0 To rcDataset.Tables("result").Rows.Count - 1
            If rcDataset.Tables("result").Rows(i).Item("客户分类编码").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("客户分类编码") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("客户分类名称").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("客户分类名称") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("客户编码").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("客户编码") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("客户名称").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("客户名称") = ""
            End If
        Next
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            For i = 0 To rcDataset.Tables("result").Rows.Count - 1
                If Me.RadioButton3.Checked Then
                    '更新销售类别
                    '更新克重，标准成本
                    rcOleDbCommand.CommandText = "UPDATE rc_khxx SET xslbdm = ? WHERE khdm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@xslbdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("销售类别编码")
                    rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("客户编码")).ToUpper
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    '删除已保存的数据
                    rcOleDbCommand.CommandText = "SELECT * FROM rc_khxx WHERE khdm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("客户编码")).ToUpper
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataset.Tables("cntcpxx") IsNot Nothing Then
                        rcDataset.Tables("cntcpxx").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataset, "cntcpxx")
                    '覆盖
                    If Me.RadioButton1.Checked Then
                        If rcDataset.Tables("cntcpxx").Rows.Count > 0 Then
                            '存在
                            '更新克重，标准成本
                            rcOleDbCommand.CommandText = "UPDATE rc_khxx SET khmc = ?,lbdm = ?,lbmc = ?,xslbdm=? WHERE khdm = ?"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@khmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("result").Rows(i).Item("客户名称")
                            rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("result").Rows(i).Item("客户分类编码")).ToUpper
                            rcOleDbCommand.Parameters.Add("@lbmc", OleDbType.VarChar, 30).Value = Trim(rcDataset.Tables("result").Rows(i).Item("客户分类名称")).ToUpper
                            rcOleDbCommand.Parameters.Add("@xslbdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("销售类别编码")
                            rcOleDbCommand.Parameters.Add("@djyear", OleDbType.Integer, 4).Value = rcDataset.Tables("result").Rows(i).Item("登记年份")
                            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("客户编码")).ToUpper
                            rcOleDbCommand.ExecuteNonQuery()
                        Else
                            '不存在,则不操作
                        End If
                    Else
                        '追加
                        If rcDataset.Tables("cntcpxx").Rows.Count = 0 Then
                            '添加客户信息信息
                            rcOleDbCommand.CommandText = "INSERT INTO rc_khxx (lbdm,lbmc,khdm,khmc,zczb,xslbdm,djyear) VALUES (?,?,?,?,0,?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@lbdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("result").Rows(i).Item("客户分类编码")).ToUpper
                            rcOleDbCommand.Parameters.Add("@lbmc", OleDbType.VarChar, 30).Value = Trim(rcDataset.Tables("result").Rows(i).Item("客户分类名称")).ToUpper
                            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("客户编码")).ToUpper
                            rcOleDbCommand.Parameters.Add("@khmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("result").Rows(i).Item("客户名称")
                            rcOleDbCommand.Parameters.Add("@xslbdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("销售类别编码")
                            rcOleDbCommand.Parameters.Add("@djyear", OleDbType.Integer, 4).Value = rcDataset.Tables("result").Rows(i).Item("登记年份")
                            rcOleDbCommand.ExecuteNonQuery()
                        Else
                            '存在则不操作
                        End If

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
        MsgBox("客户信息读入完成,请检查数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        Me.Close()
    End Sub

#End Region

#Region "退出事件"

    Private Sub TsbExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TsbExit.Click, MnuiExit.Click
        Me.Close()
    End Sub

#End Region

End Class