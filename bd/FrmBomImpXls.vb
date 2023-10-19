Imports System.Data.OleDb

Public Class FrmBomImpXls
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
        Dim strParentCpdm As String = ""
        For i = 0 To rcDataset.Tables("result").Rows.Count - 1
            If rcDataset.Tables("result").Rows(i).Item("父项物料编码").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("父项物料编码") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("父项物料描述").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("父项物料描述") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("父项计量单位").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("父项计量单位") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("子项物料编码").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("子项物料编码") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("子项物料描述").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("子项物料描述") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("子项计量单位").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("子项计量单位") = ""
            End If
            If rcDataset.Tables("result").Rows(i).Item("数量").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("result").Rows(i).Item("数量") = 0.0
            End If

        Next
        '(二)存储ml
        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            For i = 0 To rcDataset.Tables("result").Rows.Count - 1
                If strParentCpdm <> Trim(rcDataset.Tables("result").Rows(i).Item("父项物料编码")).ToUpper Then
                    rcOleDbCommand.CommandText = "DELETE FROM pm_bom WHERE parentcpdm = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@paraStrParentCpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("父项物料编码")).ToUpper
                    rcOleDbCommand.ExecuteNonQuery()
                    strParentCpdm = Trim(rcDataset.Tables("result").Rows(i).Item("父项物料编码")).ToUpper
                End If
                rcOleDbCommand.CommandText = "INSERT INTO pm_bom (parentcpdm,childcpdm,sl,dj,je) VALUES (?,?,?,0.0,0.0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraStrParentCpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("父项物料编码")).ToUpper
                rcOleDbCommand.Parameters.Add("@paraStrChildCpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("result").Rows(i).Item("子项物料编码")).ToUpper
                rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("数量")
                rcOleDbCommand.ExecuteNonQuery()
            Next
            rcOleDbTrans.Commit()
        Catch ex As Exception
            MsgBox("执行程序时发生了错误。" & Chr(13) & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        MsgBox("物料清单读入完成,请检查数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
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