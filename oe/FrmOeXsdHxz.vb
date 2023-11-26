Imports System.Data.OleDb

Public Class FrmOeXsdHxz

#Region "定义变量"
    '建立DataSet对象
    Dim rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

#End Region

#Region "窗体初始化"

    Public Property ParaDataSet() As DataSet
        Get
            ParaDataSet = rcDataSet
        End Get
        Set(ByVal Value As DataSet)
            rcDataSet = Value
        End Set
    End Property

    Private Sub FrmOeXsdHxz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DataGridViewXsd.AutoGenerateColumns = False
        Me.DataGridViewXsd.Columns("ColSl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewXsd.Columns("ColSl").DefaultCellStyle.Format = g_FormatSl
        Me.DataGridViewXsd.Columns("ColJe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewXsd.Columns("ColJe").DefaultCellStyle.Format = g_FormatJe
        '绑定数据the DataGridview to the DataTable.
        rcBindingSource.DataSource = rcDataSet.Tables("rc_xsdnr")
        Me.DataGridViewXsd.DataSource = rcBindingSource
    End Sub

#End Region

    Private Sub DataGridViewXsd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewXsd.Leave
        Me.DataGridViewXsd.ClearSelection()
    End Sub

#Region "保存单据的事件"

    Private Sub MnuiSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiSave.Click
        SaveEvent()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        SaveEvent()
    End Sub

    Private Sub SaveEvent()
        Dim i As Integer
        '(二)存储skd
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '保存历史销售单上的收款金额
            For i = 0 To rcDataSet.Tables("rc_xsdnr").Rows.Count - 1
                If rcDataSet.Tables("rc_xsdnr").Rows(i).Item("bsign") Then
                    rcOleDbCommand.CommandText = "UPDATE oe_xsd SET bsign = 1 WHERE djh = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = rcDataSet.Tables("rc_xsdnr").Rows(i).Item("djh")
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "UPDATE oe_xsd SET bsign = 0 WHERE djh = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = rcDataSet.Tables("rc_xsdnr").Rows(i).Item("djh")
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            Next
            rcOleDbTrans.Commit()
        Catch ex As Exception
            MsgBox("程序错误：" & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        MsgBox("保存完毕。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
        Me.Close()
    End Sub

#End Region

#Region "退出表单事件"

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

#End Region
End Class