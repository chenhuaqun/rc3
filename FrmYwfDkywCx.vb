Imports System.Data.OleDb

Public Class FrmYwfDkywCx
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

#Region "初始化"

    Private Sub FrmDjjz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        Me.NudYear.Value = Mid(g_Kjqj, 1, 4)
        Me.NudMonthBegin.Value = Mid(g_Kjqj, 5, 2)
        Me.NudMonthEnd.Value = Mid(g_Kjqj, 5, 2)
    End Sub

#End Region

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NudYear.KeyPress, NudMonthBegin.KeyPress, NudMonthEnd.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region


    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim dateKsrq As Date '成本结转开始日期
        Dim dateJsrq As Date '成本结转结束日期
        dateKsrq = getInvBegin(Me.NudYear.Value, Me.NudMonthBegin.Value)
        dateJsrq = getInvEnd(Me.NudYear.Value, Me.NudMonthBegin.Value)
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT gl_ywfdkyw.djh,gl_ywfdkyw.dkrq,gl_ywfdkyw.khdm,gl_ywfdkyw.khmc,gl_ywfdkyw.dkgsdm,gl_ywfdkyw.dkgsmc,gl_ywfdkyw.skje,gl_ywfdkyw.fyje,gl_ywfdkyw.dkmemo,gl_ywfdkyw.srr,gl_ywfdkyw.srrq,gl_ywfdkyw.ywfbl,gl_ywfdkyw.dkje FROM gl_ywfdkyw WHERE SUBSTR(djh,5,6) >= ? AND SUBSTR(djh,5,6) <= ? ORDER BY gl_ywfdkyw.khdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthBegin.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonthEnd.Value.ToString.PadLeft(2, "0")
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("gl_ywfdkyw") IsNot Nothing Then
                rcDataSet.Tables("gl_ywfdkyw").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "gl_ywfdkyw")
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '调用表单
        Dim rcFrm As New FrmYwfDkywCxz
        With rcFrm
            .ParaDataSet = rcDataset
            .paraDataView = New DataView(rcDataset.Tables("gl_ywfdkyw"), "TRUE", "djh", DataViewRowState.CurrentRows)
            '.Label2.Text = "盘点日期：" & Me.DtpPcrq.Value
            '.Label3.Text = "仓库：" & Trim(Me.TxtCkdm.Text)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With

    End Sub
End Class