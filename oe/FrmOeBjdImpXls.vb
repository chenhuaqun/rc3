Imports System.Data.OleDb

Public Class FrmOeBjdImpXls
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
        Dim j As Integer
        Dim strDjh As String = "BJDJ" & g_Kjqj & "00001"
        Dim isAdding As Boolean
        Dim strKhdm As String = ""
        For i = 0 To rcDataset.Tables("result").Rows.Count - 1
            If rcDataset.Tables("result").Rows(i).Item("报价日期").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("报价日期") = Now.Date
            End If
            If rcDataset.Tables("result").Rows(i).Item("币种编码").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("币种编码") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("汇率").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("汇率") = 0.0
            End If
            If rcDataset.Tables("result").Rows(i).Item("报价条款").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("报价条款") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("客户编码").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("客户编码") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("客户名称").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("客户名称") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("客户料号").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("客户料号") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("客户材质").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("客户材质") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("产品编码").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("产品编码") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("型号").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("型号") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("规格").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("规格") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("单位").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("单位") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("重量").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("重量") = 0.0
            End If
            If rcDataset.Tables("result").Rows(i).Item("spq").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("spq") = 0.0
            End If
            If rcDataset.Tables("result").Rows(i).Item("moq").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("moq") = 0.0
            End If
            If rcDataset.Tables("result").Rows(i).Item("单价").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("单价") = 0.0
            End If
            If rcDataset.Tables("result").Rows(i).Item("备注").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("备注") = ""
            End If
        Next
        '(二)存储ml
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.StoredProcedure
        Try
            rcOleDbCommand.CommandText = "USP3_SAVE_OE_BJD"
            For i = 0 To rcDataset.Tables("result").Rows.Count - 1
                If strKhdm <> Trim(rcDataset.Tables("result").Rows(i).Item("客户编码")) Then
                    isAdding = True
                    strKhdm = Trim(rcDataset.Tables("result").Rows(i).Item("客户编码"))
                    j = 0
                Else
                    isAdding = False
                    j += 1
                End If
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = IIf(isAdding, 1, 0)
                rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = strDjh
                rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = j + 1
                rcOleDbCommand.Parameters.Add("@paraDateBjrq", OleDbType.Date, 8).Value = rcDataset.Tables("result").Rows(i).Item("报价日期")
                rcOleDbCommand.Parameters.Add("@paraStrWbdm", OleDbType.VarChar, 4).Value = rcDataset.Tables("result").Rows(i).Item("币种编码")
                rcOleDbCommand.Parameters.Add("@paraDblWbhl", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("汇率")
                rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("客户编码")
                rcOleDbCommand.Parameters.Add("@paraStrKhmc", OleDbType.VarChar, 100).Value = rcDataset.Tables("result").Rows(i).Item("客户名称")
                rcOleDbCommand.Parameters.Add("@paraStrZydm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("职员编码")
                rcOleDbCommand.Parameters.Add("@paraStrZymc", OleDbType.VarChar, 30).Value = rcDataset.Tables("result").Rows(i).Item("职员姓名")
                rcOleDbCommand.Parameters.Add("@paraStrEmail", OleDbType.VarChar, 300).Value = rcDataset.Tables("result").Rows(i).Item("Email")
                rcOleDbCommand.Parameters.Add("@paraStrBjtk", OleDbType.VarChar, 200).Value = rcDataset.Tables("result").Rows(i).Item("报价条款")
                rcOleDbCommand.Parameters.Add("@paraStrKhlh", OleDbType.VarChar, 50).Value = Trim(rcDataset.Tables("result").Rows(i).Item("客户料号"))
                rcOleDbCommand.Parameters.Add("@paraStrKhcz", OleDbType.VarChar, 30).Value = Trim(rcDataset.Tables("result").Rows(i).Item("客户材质"))
                rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("产品编码")).ToUpper
                rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 40).Value = Trim(rcDataset.Tables("result").Rows(i).Item("型号"))
                rcOleDbCommand.Parameters.Add("@paraStrCpgg", OleDbType.VarChar, 40).Value = Trim(rcDataset.Tables("result").Rows(i).Item("规格"))
                rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = Trim(rcDataset.Tables("result").Rows(i).Item("单位"))
                rcOleDbCommand.Parameters.Add("@paraDblZl", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("重量")
                rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("单价")
                rcOleDbCommand.Parameters.Add("@paraDblSpq", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("spq")
                rcOleDbCommand.Parameters.Add("@paraDblMoq", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("moq")
                rcOleDbCommand.Parameters.Add("@paraStrBjmemo", OleDbType.VarChar, 50).Value = Trim(rcDataset.Tables("result").Rows(i).Item("备注"))
                rcOleDbCommand.Parameters.Add("@paraStrMemo1", OleDbType.VarChar, 300).Value = ""
                rcOleDbCommand.Parameters.Add("@paraStrMemo2", OleDbType.VarChar, 300).Value = ""
                rcOleDbCommand.Parameters.Add("@paraStrMemo3", OleDbType.VarChar, 300).Value = ""
                rcOleDbCommand.Parameters.Add("@paraStrMemo4", OleDbType.VarChar, 300).Value = ""
                rcOleDbCommand.Parameters.Add("@paraStrMemo5", OleDbType.VarChar, 300).Value = ""
                rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 10).Value = g_User_DspName
                rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                rcOleDbCommand.ExecuteNonQuery()
                If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                    If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                        MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                        Return
                    End If
                End If
                If rcOleDbCommand.Parameters("@paraStrDjh").Value.GetType.ToString <> "System.DBNull" Then
                    If rcOleDbCommand.Parameters("@paraStrDjh").Value <> "" Then
                        strDjh = Trim(rcOleDbCommand.Parameters("@paraStrDjh").Value)
                    End If
                End If
            Next
            rcOleDbTrans.Commit()
        Catch ex As Exception
            MsgBox("执行程序时发生了错误。" & Chr(13) & Chr(13) & ex.Message & Chr(13) & Chr(13) & rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        MsgBox("产品报价单读入完成,请检查数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        If rcDataset.Tables("result") IsNot Nothing Then
            rcDataset.Tables("result").Clear()
        End If
    End Sub

#End Region

#Region "退出事件"

    Private Sub TsbExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TsbExit.Click, MnuiExit.Click
        Me.Close()
    End Sub

#End Region

End Class