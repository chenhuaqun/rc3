Imports System.Data.OleDb
Public Class FrmFcspImpXls
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
        '(二)存储
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            If Me.RadioButton1.Checked Then
                rcOleDbCommand.CommandText = "DELETE FROM oe_xsd_fcsp WHERE cperiod = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strKjqj
                rcOleDbCommand.ExecuteNonQuery()
            End If
            rcOleDbCommand.CommandText = "INSERT INTO oe_xsd_fcsp (cperiod,ckkjqj,djh,xh,shkhdm,fpkhdm,bmdm,cpdm,sl,je,se,cbje) " &
                                         "VALUES (?,?,?,?,?,?,?,?,?,?,?)"
            For i = 0 To rcDataset.Tables("result").Rows.Count - 1
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = strKjqj
                rcOleDbCommand.Parameters.Add("@ckkjqj", OleDbType.VarChar, 20).Value = rcDataset.Tables("result").Rows(i).Item("出库会计期间")
                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 20).Value = rcDataset.Tables("result").Rows(i).Item("出库单号")
                rcOleDbCommand.Parameters.Add("@xh", OleDbType.Integer, 6).Value = rcDataset.Tables("result").Rows(i).Item("行号")
                rcOleDbCommand.Parameters.Add("@shkhdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("收货客户编码")
                rcOleDbCommand.Parameters.Add("@fpkhdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("开票客户编码")
                rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("result").Rows(i).Item("部门编码")
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("result").Rows(i).Item("物料编码")
                rcOleDbCommand.Parameters.Add("@sl", OleDbType.Numeric, 18).Value = rcDataset.Tables("result").Rows(i).Item("数量")
                rcOleDbCommand.Parameters.Add("@je", OleDbType.Numeric, 14).Value = rcDataset.Tables("result").Rows(i).Item("金额")
                rcOleDbCommand.Parameters.Add("@se", OleDbType.Numeric, 14).Value = rcDataset.Tables("result").Rows(i).Item("税额")
                rcOleDbCommand.Parameters.Add("@cbje", OleDbType.Numeric, 14).Value = rcDataset.Tables("result").Rows(i).Item("成本金额")
                rcOleDbCommand.ExecuteNonQuery()
            Next
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        MsgBox("期末发出商品读入完成,请检查数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        Me.Close()
    End Sub

#End Region

#Region "退出事件"

    Private Sub TsbExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TsbExit.Click, MnuiExit.Click
        Me.Close()
    End Sub

#End Region

End Class