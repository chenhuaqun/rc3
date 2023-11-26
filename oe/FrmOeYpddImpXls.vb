Imports System.Data.OleDb
Public Class FrmOeYpddImpXls
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '数据更新传递
    Dim rcOleDbTrans As OleDbTransaction
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

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
        Dim strKjqj As String = g_Kjqj
        Dim strDjh As String = "YPHT" & strKjqj & "00001"
        For i = 0 To rcDataset.Tables("result").Rows.Count - 1
            If rcDataset.Tables("result").Rows(i).Item("排样日期").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("排样日期") = Now.Date
            End If
            If rcDataset.Tables("result").Rows(i).Item("合同编码").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("合同编码") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("客户编码").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("客户编码") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("收件人").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("收件人") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("产品编码").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("产品编码") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("东磁型号").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("东磁型号") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("材质").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("材质") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("产品属性").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("产品属性") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("单位").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("单位") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("客户料号").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("客户料号") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("客户材质").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("客户材质") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("客户数量").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("客户数量") = 0.0
            End If
            If rcDataset.Tables("result").Rows(i).Item("系数").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("系数") = 1
            End If
            If rcDataset.Tables("result").Rows(i).Item("订单数量").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("订单数量") = 0.0
            End If
            If rcDataset.Tables("result").Rows(i).Item("客户交期").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("客户交期") = Now.Date
            End If
            If rcDataset.Tables("result").Rows(i).Item("部门编码").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("部门编码") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("备注").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("备注") = ""
            End If
            strKjqj = getInvKjqj(rcDataset.Tables("result").Rows(i).Item("排样日期"))
            strDjh = "YPHT" & strKjqj & "00001"
            '(二)存储ml
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            Try
                rcOleDbCommand.CommandText = "USP_SAVE_oe_ypdd"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                rcOleDbCommand.Parameters.Add("@pStrDjh", OleDbType.VarChar, 15).Value = strDjh
                rcOleDbCommand.Parameters("@pStrDjh").Direction = ParameterDirection.InputOutput
                rcOleDbCommand.Parameters.Add("@pDateQdrq", OleDbType.Date, 8).Value = rcDataset.Tables("result").Rows(i).Item("排样日期")
                rcOleDbCommand.Parameters.Add("@pStrHth", OleDbType.VarChar, 11).Value = rcDataset.Tables("result").Rows(i).Item("合同编码")
                rcOleDbCommand.Parameters.Add("@pStrKhdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("客户编码")
                rcOleDbCommand.Parameters.Add("@pStrLxr", OleDbType.VarChar, 30).Value = rcDataset.Tables("result").Rows(i).Item("收件人")
                rcOleDbCommand.Parameters.Add("@pStrDdmemo", OleDbType.VarChar, 40).Value = rcDataset.Tables("result").Rows(i).Item("合同其他条款") '合同其他条款
                rcOleDbCommand.Parameters.Add("@pStrUserDspName", OleDbType.VarChar, 10).Value = g_User_DspName
                rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                rcOleDbCommand.Parameters.Add("@paraIntError", OleDbType.Integer, 4).Direction = ParameterDirection.Output
                rcOleDbCommand.ExecuteNonQuery()
                If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                    If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                        MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                        Return
                    End If
                End If
                If rcOleDbCommand.Parameters("@pStrDjh").Value.GetType.ToString <> "System.DBNull" Then
                    If rcOleDbCommand.Parameters("@pStrDjh").Value <> "" Then
                        strDjh = Trim(rcOleDbCommand.Parameters("@pStrDjh").Value)
                    End If
                End If
                '(三)存储nr
                rcOleDbCommand.CommandText = "USP_SAVE_oe_ypdd"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@pStrDjh", OleDbType.VarChar, 15).Value = strDjh
                rcOleDbCommand.Parameters.Add("@pStrHth", OleDbType.VarChar, 11).Value = rcDataset.Tables("result").Rows(i).Item("合同编码")
                rcOleDbCommand.Parameters.Add("@pStrKhdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("客户编码")
                rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = 1
                rcOleDbCommand.Parameters.Add("@pStrCpdm", OleDbType.VarChar, 12).Value = Trim(rcDataset.Tables("result").Rows(i).Item("产品编码")).ToUpper
                rcOleDbCommand.Parameters.Add("@pStrCpmc", OleDbType.VarChar, 40).Value = Trim(rcDataset.Tables("result").Rows(i).Item("东磁型号"))
                rcOleDbCommand.Parameters.Add("@pStrCpgg", OleDbType.VarChar, 40).Value = Trim(rcDataset.Tables("result").Rows(i).Item("材质"))
                rcOleDbCommand.Parameters.Add("@pStrCpmemo", OleDbType.VarChar, 50).Value = Trim(rcDataset.Tables("result").Rows(i).Item("产品属性"))
                rcOleDbCommand.Parameters.Add("@pStrDw", OleDbType.VarChar, 8).Value = Trim(rcDataset.Tables("result").Rows(i).Item("单位"))
                rcOleDbCommand.Parameters.Add("@pStrKhlh", OleDbType.VarChar, 50).Value = Trim(rcDataset.Tables("result").Rows(i).Item("客户料号"))
                rcOleDbCommand.Parameters.Add("@pStrKhcz", OleDbType.VarChar, 30).Value = Trim(rcDataset.Tables("result").Rows(i).Item("客户材质"))
                rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("订单数量")
                rcOleDbCommand.Parameters.Add("@pDateKhjhrq", OleDbType.Date).Value = rcDataset.Tables("result").Rows(i).Item("客户交期")
                rcOleDbCommand.Parameters.Add("@pDateScjhrq", OleDbType.Date).Value = rcDataset.Tables("result").Rows(i).Item("客户交期")
                rcOleDbCommand.Parameters.Add("@pDateFhrq", OleDbType.Date).Value = rcDataset.Tables("result").Rows(i).Item("客户交期")
                rcOleDbCommand.Parameters.Add("@pStrBmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("部门编码")
                rcOleDbCommand.Parameters.Add("@pStrDdmemo", OleDbType.VarChar, 50).Value = rcDataset.Tables("result").Rows(i).Item("备注")
                rcOleDbCommand.Parameters.Add("@pStrSrr", OleDbType.VarChar, 10).Value = ""
                rcOleDbCommand.Parameters.Add("@paraIntZt", OleDbType.Integer, 1).Value = 0
                rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                rcOleDbCommand.Parameters.Add("@paraIntError", OleDbType.Integer, 4).Direction = ParameterDirection.Output
                rcOleDbCommand.ExecuteNonQuery()
                If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                    If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                        MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                        Return
                    End If
                End If
                rcOleDbTrans.Commit()
            Catch ex As Exception
                MsgBox("执行程序时发生了错误。" & Chr(13) & Chr(13) & ex.Message & Chr(13) & Chr(13) & rcOleDbCommand.Parameters("@paraIntError").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        Next
        MsgBox("样品订单读入完成,请检查数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
    End Sub

#End Region

#Region "退出事件"

    Private Sub TsbExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TsbExit.Click, MnuiExit.Click
        Me.Close()
    End Sub

#End Region
End Class