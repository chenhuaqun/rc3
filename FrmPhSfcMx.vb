Imports System.Data.OleDb

Public Class FrmPhSfcMx
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable
    ReadOnly dtCpsfcMx As New DataTable("cpsfcmx")

    Private Sub FrmPhSfcMx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '创建datatable
        dtCpsfcMx.Columns.Add("rq", Type.GetType("System.DateTime"))
        dtCpsfcMx.Columns.Add("djh", Type.GetType("System.String"))
        dtCpsfcMx.Columns.Add("zy", Type.GetType("System.String"))
        dtCpsfcMx.Columns.Add("rksl", Type.GetType("System.Double"))
        dtCpsfcMx.Columns.Add("rkfzsl", Type.GetType("System.Double"))
        dtCpsfcMx.Columns.Add("rkje", Type.GetType("System.Double"))
        dtCpsfcMx.Columns.Add("cksl", Type.GetType("System.Double"))
        dtCpsfcMx.Columns.Add("ckfzsl", Type.GetType("System.Double"))
        dtCpsfcMx.Columns.Add("ckje", Type.GetType("System.Double"))
        dtCpsfcMx.Columns.Add("jcsl", Type.GetType("System.Double"))
        dtCpsfcMx.Columns.Add("jcfzsl", Type.GetType("System.Double"))
        dtCpsfcMx.Columns.Add("jcje", Type.GetType("System.Double"))
        rcDataset.Tables.Add(dtCpsfcMx)
        With rcDataset.Tables("cpsfcmx")
            .Columns("djh").DefaultValue = ""
            .Columns("zy").DefaultValue = ""
            .Columns("rksl").DefaultValue = 0.0
            .Columns("rkfzsl").DefaultValue = 0.0
            .Columns("rkje").DefaultValue = 0.0
            .Columns("cksl").DefaultValue = 0.0
            .Columns("ckfzsl").DefaultValue = 0.0
            .Columns("ckje").DefaultValue = 0.0
            .Columns("jcsl").DefaultValue = 0.0
            .Columns("jcfzsl").DefaultValue = 0.0
            .Columns("jcje").DefaultValue = 0.0
        End With
    End Sub

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPiHao.KeyPress, TxtCpdm.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "物料编码事件"

    Private Sub TxtCpdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCpdm.KeyDown
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
                    .paraOrderField = "cpmc"
                    .paraTitle = "物料"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        Me.TxtCpdm.Text = Trim(.paraField1)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtCpdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCpdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtCpdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT cpdm,cpmc,dw,kuwei FROM rc_cpxx WHERE (cpdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Trim(TxtCpdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                    Me.rcDataset.Tables("rc_cpxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_cpxx").Rows.Count = 0 Then
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If String.IsNullOrEmpty(Me.TxtCpdm.Text) Then
            MsgBox("物料编码不能为空。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        '清空数据
        rcDataset.Tables("cpsfcmx").Clear()
        Dim dblJcsl As Double = 0.0
        Dim dblJcfzsl As Double = 0.0
        Dim dblJcje As Double = 0.0
        '读取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "(SELECT inv_rkd.rkrq As rq,inv_rkd.djh,inv_rkd.rkmemo || '客户:' || inv_rkd.khdm || '第' || inv_rkd.xh || '行' As zy,inv_rkd.sl As rksl,inv_rkd.fzsl as rkfzsl,inv_rkd.je As rkje,0.0 As cksl,0.0 AS ckfzsl,0.0 As ckje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND cpdm = ? AND scph = ?)" &
                " UNION ALL (SELECT po_rkd.rkrq As rq,po_rkd.djh,po_rkd.rkmemo || '供应商:' || po_rkd.csdm || '第' || po_rkd.xh || '行' As zy,po_rkd.sl As rksl,po_rkd.fzsl AS rkfzsl,po_rkd.je As rkje,0.0 As cksl,0.0 AS ckfzsl,0.0 As ckje FROM po_rkd WHERE po_rkd.bdelete = 0 AND cpdm = ? AND pihao = ?)" &
                " UNION ALL (SELECT TRUNC(inv_dbd.dbrq,'mi') As rq,inv_dbd.djh,inv_dbd.dbmemo || '调出仓库' || inv_dbd.cckdm || '第' || inv_dbd.xh || '行' As zy,inv_dbd.sl As rksl,inv_dbd.fzsl AS rkfzsl,inv_dbd.je As rkje,0.0 As cksl,0.0 AS ckfzsl,0.0 As ckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND cpdm = ? AND scph = ?)" &
                " UNION ALL (SELECT oe_xsd.xsrq As rq,oe_xsd.djh,oe_xsd.xsmemo || '第' || oe_xsd.xh || '行' AS zy,0.0 As rksl,0.0 AS rkfzsl,0.0 As rkje,oe_xsd.sl As cksl,oe_xsd.fzsl AS ckfzsl,oe_xsd.cbje As ckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND cpdm = ? AND pihao = ?)" &
                " UNION ALL (SELECT inv_ckd.ckrq As rq,inv_ckd.djh,inv_ckd.ckmemo || '第' || inv_ckd.xh || '行' || '供应商:' || inv_ckd.csdm AS zy,0.0 As rksl,0.0 AS rkfzsl,0.0 As rkje,inv_ckd.sl As cksl,inv_ckd.fzsl AS ckfzsl,inv_ckd.je As ckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND cpdm = ? AND scph = ?)" &
                " UNION ALL (SELECT TRUNC(inv_dbd.dbrq,'mi') As rq,inv_dbd.djh,inv_dbd.dbmemo || '调入仓库' || inv_dbd.rckdm || '第' || inv_dbd.xh || '行' AS zy,0.0 As rksl,0.0 AS rkfzsl,0.0 As rkje,inv_dbd.sl As cksl,inv_dbd.fzsl AS ckfzsl,inv_dbd.je As ckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND cpdm = ? AND pihao = ?)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Me.TxtCpdm.Text
            rcOleDbCommand.Parameters.Add("@pihao", OleDbType.VarChar, 20).Value = Me.TxtPiHao.Text
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Me.TxtCpdm.Text
            rcOleDbCommand.Parameters.Add("@pihao", OleDbType.VarChar, 20).Value = Me.TxtPiHao.Text
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Me.TxtCpdm.Text
            rcOleDbCommand.Parameters.Add("@pihao", OleDbType.VarChar, 20).Value = Me.TxtPiHao.Text
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Me.TxtCpdm.Text
            rcOleDbCommand.Parameters.Add("@pihao", OleDbType.VarChar, 20).Value = Me.TxtPiHao.Text
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Me.TxtCpdm.Text
            rcOleDbCommand.Parameters.Add("@pihao", OleDbType.VarChar, 20).Value = Me.TxtPiHao.Text
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = Me.TxtCpdm.Text
            rcOleDbCommand.Parameters.Add("@pihao", OleDbType.VarChar, 20).Value = Me.TxtPiHao.Text
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("cpsfcmx") IsNot Nothing Then
                rcDataset.Tables("cpsfcmx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "cpsfcmx")
        Catch ex As Exception
            MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try

        If rcDataset.Tables("cpsfcmx").Rows.Count <= 0 Then
            MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        Dim i As Integer
        Dim rcDataView As New DataView(rcDataset.Tables("cpsfcmx"), "TRUE", "rq", DataViewRowState.CurrentRows)
        '计算期末库存
        For i = 0 To rcDataView.Count - 1
            dblJcsl += rcDataView.Table.Rows(i).Item("rksl") - rcDataView.Table.Rows(i).Item("cksl")
            rcDataView.Table.Rows(i).Item("jcsl") = dblJcsl
            dblJcfzsl += rcDataView.Table.Rows(i).Item("rkfzsl") - rcDataView.Table.Rows(i).Item("ckfzsl")
            rcDataView.Table.Rows(i).Item("jcfzsl") = dblJcfzsl
            dblJcje += rcDataView.Table.Rows(i).Item("rkje") - rcDataView.Table.Rows(i).Item("ckje")
            rcDataView.Table.Rows(i).Item("jcje") = dblJcje
        Next
        '调用表单
        Dim rcFrm As New FrmPhSfcMxz
        With rcFrm
            .ParaDataSet = rcDataset
            .paraDataView = New DataView(rcDataset.Tables("cpsfcmx"), "TRUE", "rq", DataViewRowState.CurrentRows)
            '.paraDataTable = rcDataset.Tables("cpsfcmx")
            .Label3.Text = "批次号：" & Me.TxtPiHao.Text
            If rcDataset.Tables("rc_cpxx").Rows.Count > 0 Then
                .Label2.Text = "物料：(" & Me.TxtCpdm.Text & ")" & rcDataset.Tables("rc_cpxx").Rows(0).Item("cpmc") & " " & rcDataset.Tables("rc_cpxx").Rows(0).Item("dw")
            End If
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class