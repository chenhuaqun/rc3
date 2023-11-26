Imports System.Data.OleDb

Public Class FrmPoCkdSr2

    '建立OLEDB数据适配器对象
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDb传递对象
    ReadOnly rcOleDbTrans As OleDbTransaction
    '建立OleDb命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

#Region "初始化"

    Private Sub FrmPoCkdSr2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT inv_llsqmla.bmdm,inv_llsqmla.bmmc,inv_llsqmla.zydm,inv_llsqmla.zymc,COUNT(inv_llsqmla.djh) AS cntdjh FROM (SELECT inv_llsq.bmdm,inv_llsq.bmmc,inv_llsq.zydm,inv_llsq.zymc,inv_llsq.djh FROM inv_llsq WHERE ((inv_llsq.sl > inv_llsq.cksl AND inv_llsq.sl > 0) OR (inv_llsq.sl < inv_llsq.cksl AND inv_llsq.sl < 0)) AND inv_llsq.bclosed  = 0 " & IIf(Me.ChbSh.Checked, " AND NOT inv_llsq.shr IS NULL", "") & " GROUP BY inv_llsq.bmdm,inv_llsq.bmmc,inv_llsq.zydm,inv_llsq.zymc,inv_llsq.djh) inv_llsqmla GROUP BY inv_llsqmla.bmdm,inv_llsqmla.bmmc,inv_llsqmla.zydm,inv_llsqmla.zymc ORDER BY inv_llsqmla.bmdm,inv_llsqmla.zydm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("inv_llsqml") IsNot Nothing Then
                Me.rcDataSet.Tables("inv_llsqml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "inv_llsqml")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message)
        Finally
            rcOleDbConn.Close()
        End Try
        Me.DataGridView1.DataSource = rcDataSet.Tables("inv_llsqml")
    End Sub

#End Region

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT inv_llsqmla.bmdm,inv_llsqmla.bmmc,inv_llsqmla.zydm,inv_llsqmla.zymc,COUNT(inv_llsqmla.djh) AS cntdjh FROM (SELECT inv_llsq.bmdm,inv_llsq.bmmc,inv_llsq.zydm,inv_llsq.zymc,inv_llsq.djh FROM inv_llsq WHERE ((inv_llsq.sl > inv_llsq.cksl AND inv_llsq.sl > 0) OR (inv_llsq.sl < inv_llsq.cksl AND inv_llsq.sl < 0)) AND inv_llsq.bclosed  = 0 " & IIf(Me.ChbSh.Checked, " AND NOT inv_llsq.shr IS NULL", "") & " GROUP BY inv_llsq.bmdm,inv_llsq.bmmc,inv_llsq.zydm,inv_llsq.zymc,inv_llsq.djh) inv_llsqmla GROUP BY inv_llsqmla.bmdm,inv_llsqmla.bmmc,inv_llsqmla.zydm,inv_llsqmla.zymc ORDER BY inv_llsqmla.bmdm,inv_llsqmla.bmmc,inv_llsqmla.zydm,inv_llsqmla.zymc"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("inv_llsqml") IsNot Nothing Then
                Me.rcDataSet.Tables("inv_llsqml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "inv_llsqml")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message)
        Finally
            rcOleDbConn.Close()
        End Try
        Me.DataGridView1.DataSource = rcDataSet.Tables("inv_llsqml")
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If rcDataSet.Tables("inv_llsqml").Rows(Me.DataGridView1.CurrentRow.Index).Item("zydm").GetType.ToString <> "System.DBNull" And rcDataSet.Tables("inv_llsqml").Rows(Me.DataGridView1.CurrentRow.Index).Item("bmdm").GetType.ToString <> "System.DBNull" Then
            '调用表单
            Dim rcFrm As New FrmPoCkdSr2z
            With rcFrm
                .ParaBmdm = rcDataset.Tables("inv_llsqml").Rows(Me.DataGridView1.CurrentRow.Index).Item("bmdm")
                .ParaZydm = rcDataset.Tables("inv_llsqml").Rows(Me.DataGridView1.CurrentRow.Index).Item("zydm")
                .WindowState = FormWindowState.Maximized
                .MdiParent = Me.MdiParent
                .Show()
            End With
        End If
    End Sub
End Class