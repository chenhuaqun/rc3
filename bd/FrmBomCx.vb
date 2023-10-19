Imports System.Data.OleDb

Public Class FrmBomCx
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Private Sub TxtParentCpdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtParentCpdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF34
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_cpxx"
                    .paraField1 = "cpdm"
                    .paraField2 = "cpmc"
                    .paraField3 = "dw"
                    .paraField4 = "cpsm"
                    .paraOrderField = "cpdm"
                    .paraTitle = "物料"
                    .paraOldValue = Me.TxtParentCpdm.Text
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtParentCpdm.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtChildCpdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtChildCpdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF34
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_cpxx"
                    .paraField1 = "cpdm"
                    .paraField2 = "cpmc"
                    .paraField3 = "dw"
                    .paraField4 = "cpsm"
                    .paraOrderField = "cpdm"
                    .paraTitle = "物料"
                    .paraOldValue = Me.TxtParentCpdm.Text
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtChildCpdm.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        '取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pm_bomdata.cperiod,pm_bomdata.parentcpdm,a.cpmc AS parentcpmc,a.dw AS parentdw,a.bzcb,a.beishu,a.clcb,a.rgcb,a.nycb,a.zjcb,a.glcb,pm_bomdata.childcpdm,b.cpmc AS childcpmc,b.dw AS childdw,pm_bomdata.sl,pm_bomdata.dj,pm_bomdata.je,pm_bomdata.bommemo FROM pm_bomdata LEFT JOIN rc_cpxx a ON a.cpdm = pm_bomdata.parentcpdm LEFT JOIN rc_cpxx b ON b.cpdm = pm_bomdata.childcpdm WHERE pm_bomdata.cperiod = ?" & IIf(Trim(Me.TxtParentCpdm.Text).Length > 0, " AND pm_bomdata.parentcpdm = '" & Trim(Me.TxtParentCpdm.Text) & "'", "") & IIf(Trim(Me.TxtParentCpmc.Text).Length > 0, " AND a.cpmc LIKE '%" & Me.TxtParentCpmc.Text & "%'", "") & IIf(Trim(Me.TxtChildCpdm.Text).Length > 0, " AND pm_bomdata.childcpdm LIKE '" & LTrim(Me.TxtChildCpdm.Text) & "%'", "") & IIf(Trim(Me.TxtChildCpmc.Text).Length > 0, " AND b.cpmc LIKE '%" & Trim(Me.TxtChildCpmc.Text) & "%'", "") & " ORDER BY pm_bomdata.parentcpdm,pm_bomdata.childcpdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("bomlb") IsNot Nothing Then
                rcDataSet.Tables("bomlb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "bomlb")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("bomlb").Rows.Count <= 0 Then
            MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        '调用表单
        Dim rcFrm As New FrmBomCxz
        With rcFrm
            .ParaDataSet = rcDataSet
            .ParaDataView = New DataView(rcDataSet.Tables("bomlb"), "TRUE", "parentcpdm,childcpdm", DataViewRowState.CurrentRows)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

    Private Sub FrmBomCx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        Me.NudYear.Value = Mid(g_Kjqj, 1, 4)
        Me.NudMonth.Value = Mid(g_Kjqj, 5, 2)
    End Sub
End Class