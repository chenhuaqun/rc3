Imports System.Data.OleDb

Public Class FrmYwfDkywImpXls
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
            If rcDataset.Tables("result").Rows(i).Item("抵扣日期").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("抵扣日期") = Now().Date
            End If
            If rcDataset.Tables("result").Rows(i).Item("客户编码").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("客户编码") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("客户名称").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("客户名称") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("抵扣规则编码").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("抵扣规则编码") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("抵扣规则名称").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("抵扣规则名称") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("收款金额").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("收款金额") = 0.0
            End If
            If rcDataset.Tables("result").Rows(i).Item("费用金额").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("费用金额") = 0.0
            End If
            If rcDataset.Tables("result").Rows(i).Item("备注").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("备注") = ""
            End If
        Next
        If Me.RadioButton1.Checked Then
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                '删除已保存的数据
                rcOleDbCommand.CommandText = "DELETE FROM gl_ywfdkyw WHERE SUBSTR(djh,1,10) = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@pzlxdmkjqj", OleDbType.VarChar, 10).Value = "DKYW" & strKjqj
                rcOleDbCommand.ExecuteNonQuery()
                '更新单据号
                rcOleDbCommand.CommandText = "UPDATE rc_lx SET pzno" & Mid(strKjqj, 5, 2) & " = 0 WHERE kjnd = ? AND pzlxdm = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Mid(strKjqj, 1, 4)
                rcOleDbCommand.Parameters.Add("@pzpxdm", OleDbType.VarChar, 4).Value = "DKYW"
                rcOleDbCommand.ExecuteNonQuery()
                '更新序列
                rcOleDbCommand.CommandText = "DROP SEQUENCE " & "DKYW" & strKjqj
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "CREATE SEQUENCE " & "DKYW" & strKjqj & " INCREMENT BY 1 START WITH 1 MAXVALUE 99999 MINVALUE 1 NOCYCLE NOCACHE NOORDER"
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
                rcOleDbCommand.CommandText = "USP3_SAVE_GL_YWFDKYW"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = "DKYW" & strKjqj & "00001"
                rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                rcOleDbCommand.Parameters.Add("@paraDateDkrq", OleDbType.Date, 8).Value = rcDataset.Tables("result").Rows(i).Item("抵扣日期")
                rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("客户编码")
                rcOleDbCommand.Parameters.Add("@paraStrKhmc", OleDbType.VarChar, 100).Value = rcDataset.Tables("result").Rows(i).Item("客户名称")
                rcOleDbCommand.Parameters.Add("@paraStrDkgsdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("抵扣规则编码")
                rcOleDbCommand.Parameters.Add("@paraStrDkgsmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("result").Rows(i).Item("抵扣规则名称")
                rcOleDbCommand.Parameters.Add("@paraStrSkje", OleDbType.Numeric, 14).Value = rcDataset.Tables("result").Rows(i).Item("收款金额")
                rcOleDbCommand.Parameters.Add("@paraStrFyje", OleDbType.Numeric, 14).Value = rcDataset.Tables("result").Rows(i).Item("费用金额")
                rcOleDbCommand.Parameters.Add("@paraStrDkmemo", OleDbType.VarChar, 50).Value = rcDataset.Tables("result").Rows(i).Item("备注")
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
        MsgBox("业务费抵扣业务读入完成,请检查数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        Me.Close()
    End Sub

#End Region

#Region "退出事件"

    Private Sub TsbExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TsbExit.Click, MnuiExit.Click
        Me.Close()
    End Sub

#End Region

End Class