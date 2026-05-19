Imports System.Data.OleDb
Public Class FrmInvCktzImpXls
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '数据更新传递
    Dim rcOleDbTrans As OleDbTransaction
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
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
        If Me.RadioButton1.Checked Then
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                '删除已保存的数据
                rcOleDbCommand.CommandText = "DELETE FROM inv_ckd WHERE SUBSTR(djh,1,10) = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@pzlxdmkjqj", OleDbType.VarChar, 10).Value = strPzlxdm & strKjqj
                rcOleDbCommand.ExecuteNonQuery()
                '更新单据号
                rcOleDbCommand.CommandText = "UPDATE rc_lx SET pzno" & Mid(strKjqj, 5, 2) & " = 0 WHERE kjnd = ? AND pzlxdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(strKjqj, 1, 4)
                rcOleDbCommand.Parameters.Add("@pzpxdm", OleDbType.VarChar, 4).Value = strPzlxdm
                rcOleDbCommand.ExecuteNonQuery()
                '更新序列
                rcOleDbCommand.CommandText = "DROP SEQUENCE " & strPzlxdm & strKjqj
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "CREATE SEQUENCE " & strPzlxdm & strKjqj & " INCREMENT BY 1 START WITH 1 MAXVALUE 99999 MINVALUE 1 NOCYCLE NOCACHE NOORDER"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbTrans.Commit()
            Catch ex As Exception
                MsgBox("执行程序时发生了错误。" & Chr(13) & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        End If
        For i = 0 To rcDataset.Tables("result").Rows.Count - 1
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.StoredProcedure
                rcOleDbCommand.CommandText = "USP3_SAVE_INV_CKTZ"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                rcOleDbCommand.Parameters.Add("@ParaStrDjh", OleDbType.VarChar, 15).Value = strPzlxdm & strKjqj & "00001"
                rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 6).Value = 1
                rcOleDbCommand.Parameters.Add("@paraDateCkrq", OleDbType.Date, 8).Value = rcDataset.Tables("result").Rows(i).Item("出库日期")
                rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                rcOleDbCommand.Parameters.Add("@ParaStrCkdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("仓库编码")
                rcOleDbCommand.Parameters.Add("@paraStrCkmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("result").Rows(i).Item("仓库名称")
                rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("部门编码")
                rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("result").Rows(i).Item("部门名称")
                rcOleDbCommand.Parameters.Add("@paraStrZydm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("职员编码")
                rcOleDbCommand.Parameters.Add("@paraStrZymc", OleDbType.VarChar, 30).Value = rcDataset.Tables("result").Rows(i).Item("职员姓名")
                rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("物料编码")).ToUpper
                rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("result").Rows(i).Item("物料描述")
                rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("供应商编码")
                rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("result").Rows(i).Item("供应商名称")
                rcOleDbCommand.Parameters.Add("@paraStrKuwei", OleDbType.VarChar, 40).Value = rcDataset.Tables("result").Rows(i).Item("库位")
                rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("数量")
                rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = rcDataset.Tables("result").Rows(i).Item("单位")
                rcOleDbCommand.Parameters.Add("@paraDblMjsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("换算系数")
                rcOleDbCommand.Parameters.Add("@paraDblFzsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("辅数量")
                rcOleDbCommand.Parameters.Add("@paraStrFzdw", OleDbType.VarChar, 8).Value = rcDataset.Tables("result").Rows(i).Item("辅单位")
                rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("单价")
                rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("result").Rows(i).Item("金额")
                rcOleDbCommand.Parameters.Add("@paraStrRkmemo", OleDbType.VarChar, 50).Value = rcDataset.Tables("result").Rows(i).Item("备注")
                rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                rcOleDbCommand.ExecuteNonQuery()
                If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                    If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                        MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                        Return
                    End If
                End If
                rcOleDbTrans.Commit()
            Catch ex As Exception
                MsgBox("执行程序时发生了错误。" & Chr(13) & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        Next
        MsgBox("物料出库单读入完成,请检查数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        Me.Close()
    End Sub

#End Region

#Region "退出事件"

    Private Sub TsbExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TsbExit.Click, MnuiExit.Click
        Me.Close()
    End Sub

#End Region

End Class