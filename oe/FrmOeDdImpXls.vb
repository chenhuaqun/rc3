Imports System.Data.OleDb
Public Class FrmOeDdImpXls
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
        Dim strDjh As String = "XSHT" & g_Kjqj & "00001"
        If rcDataset.Tables("result").Rows.Count = 0 Then
            Return
        End If
        For i = 0 To rcDataset.Tables("result").Rows.Count - 1
            If rcDataset.Tables("result").Rows(i).Item("签单日期").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("签单日期") = Now.Date
            End If
            If rcDataset.Tables("result").Rows(i).Item("订单编码").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("订单编码") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("客户编码").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("客户编码") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("付款方式").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("付款方式") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("币种").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("币种") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("汇率").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("汇率") = 1
            End If
            If rcDataset.Tables("result").Rows(i).Item("客户订单号").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("客户订单号") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("进出口单号").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("进出口单号") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("合同其他条款").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("合同其他条款") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("产品编码").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("产品编码") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("部门编码").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("部门编码") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("客户料号").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("客户料号") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("订单数量").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("订单数量") = 0
            End If
            If rcDataset.Tables("result").Rows(i).Item("系数").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("系数") = 1
            End If
            If rcDataset.Tables("result").Rows(i).Item("数量").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("数量") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("含税单价").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("含税单价") = 0.0
            End If
            If rcDataset.Tables("result").Rows(i).Item("单价").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("单价") = 0.0
            End If
            If rcDataset.Tables("result").Rows(i).Item("客户交期").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("客户交期") = Now.Date
            End If
            If rcDataset.Tables("result").Rows(i).Item("常规特殊").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("常规特殊") = 0
            End If
            If rcDataset.Tables("result").Rows(i).Item("承认书").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("承认书") = 2
            End If
            If rcDataset.Tables("result").Rows(i).Item("LineNo").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("LineNo") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("备注").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("备注") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("发运方向").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("发运方向") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("运输方式").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("运输方式") = ""
            End If
            '取订单编码
            '(二)存储ml
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            Try
                'If i = 0 Then
                rcOleDbCommand.CommandText = "USP_SAVE_OE_DDML"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = strDjh
                rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                rcOleDbCommand.Parameters.Add("@pDateQdrq", OleDbType.Date, 8).Value = rcDataset.Tables("result").Rows(i).Item("签单日期")
                rcOleDbCommand.Parameters.Add("@paraStrHth", OleDbType.VarChar, 30).Value = rcDataset.Tables("result").Rows(i).Item("订单编码")
                rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("客户编码")
                rcOleDbCommand.Parameters.Add("@paraStrSgdh", OleDbType.VarChar, 20).Value = rcDataset.Tables("result").Rows(i).Item("客户订单号")
                rcOleDbCommand.Parameters.Add("@paraStrJckdh", OleDbType.VarChar, 20).Value = rcDataset.Tables("result").Rows(i).Item("进出口单号")
                rcOleDbCommand.Parameters.Add("@paraStrWbdm", OleDbType.VarChar, 4).Value = rcDataset.Tables("result").Rows(i).Item("币种")
                rcOleDbCommand.Parameters.Add("@paraDblWbhl", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("汇率")
                rcOleDbCommand.Parameters.Add("@paraStrJsfs", OleDbType.VarChar, 20).Value = rcDataset.Tables("result").Rows(i).Item("付款方式")
                rcOleDbCommand.Parameters.Add("@paraStrDdmemo", OleDbType.VarChar, 40).Value = rcDataset.Tables("result").Rows(i).Item("合同其他条款") '
                rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 10).Value = g_User_DspName
                rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                rcOleDbCommand.Parameters.Add("@paraIntError", OleDbType.Integer, 4).Direction = ParameterDirection.Output
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
                'End If
                '(三)存储nr
                rcOleDbCommand.CommandText = "USP_SAVE_OE_DDNR"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = strDjh
                rcOleDbCommand.Parameters.Add("@paraStrHth", OleDbType.VarChar, 30).Value = Mid(strDjh, 5, 11)
                rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("客户编码")
                rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = i + 1
                rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("产品编码")).ToUpper
                rcOleDbCommand.Parameters.Add("@paraStrKhlh", OleDbType.VarChar, 50).Value = Trim(rcDataset.Tables("result").Rows(i).Item("客户料号")).ToUpper
                rcOleDbCommand.Parameters.Add("@paraDblKhsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("订单数量")
                rcOleDbCommand.Parameters.Add("@paraIntXs", OleDbType.Integer, 4).Value = rcDataset.Tables("result").Rows(i).Item("系数")
                rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("数量")
                rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("单价")
                rcOleDbCommand.Parameters.Add("@paraDblHsdj", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("含税单价")
                rcOleDbCommand.Parameters.Add("@pDateKhjhrq", OleDbType.Date).Value = rcDataset.Tables("result").Rows(i).Item("客户交期")
                rcOleDbCommand.Parameters.Add("@pDateScjhrq", OleDbType.Date).Value = DBNull.Value
                rcOleDbCommand.Parameters.Add("@pDateFhrq", OleDbType.Date).Value = DBNull.Value
                rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("部门编码")
                rcOleDbCommand.Parameters.Add("@paraIntTeshu", OleDbType.Integer, 1).Value = rcDataset.Tables("result").Rows(i).Item("常规特殊")
                rcOleDbCommand.Parameters.Add("@paraIntCrs", OleDbType.Integer, 1).Value = rcDataset.Tables("result").Rows(i).Item("承认书")
                rcOleDbCommand.Parameters.Add("@paraStrLine_no", OleDbType.VarChar, 10).Value = rcDataset.Tables("result").Rows(i).Item("LineNo")
                rcOleDbCommand.Parameters.Add("@paraStrDdmemo", OleDbType.VarChar, 50).Value = rcDataset.Tables("result").Rows(i).Item("备注")
                rcOleDbCommand.Parameters.Add("@paraStrFyfx", OleDbType.VarChar, 8).Value = rcDataset.Tables("result").Rows(i).Item("发运方向")
                rcOleDbCommand.Parameters.Add("@paraStrYsfs", OleDbType.VarChar, 8).Value = rcDataset.Tables("result").Rows(i).Item("运输方式")
                rcOleDbCommand.Parameters.Add("@paraStrSrr", OleDbType.VarChar, 10).Value = ""
                rcOleDbCommand.Parameters.Add("@paraIntZt", OleDbType.Integer, 1).Value = 0
                rcOleDbCommand.Parameters.Add("@paraDblCksl", OleDbType.Numeric, 18).Value = 0
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
        MsgBox("产品销售订单读入完成,请检查数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
    End Sub

#End Region

#Region "退出事件"

    Private Sub TsbExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TsbExit.Click, MnuiExit.Click
        Me.Close()
    End Sub

#End Region
End Class