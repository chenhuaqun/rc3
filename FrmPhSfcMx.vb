Imports System.Data.OleDb

Public Class FrmPhSfcMx
    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '����Datatable
    ReadOnly dtCpsfcMx As New DataTable("cpsfcmx")

    Private Sub FrmPhSfcMx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '����datatable
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

#Region "�ؼ��س����Ĵ���"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPiHao.KeyPress, TxtCpdm.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "���ϱ����¼�"

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
                    .paraTitle = "����"
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
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
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
            MsgBox("���ϱ��벻��Ϊ�ա�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        '�������
        rcDataset.Tables("cpsfcmx").Clear()
        Dim dblJcsl As Double = 0.0
        Dim dblJcfzsl As Double = 0.0
        Dim dblJcje As Double = 0.0
        '��ȡ����
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "(SELECT inv_rkd.rkrq As rq,inv_rkd.djh,inv_rkd.rkmemo || '�ͻ�:' || inv_rkd.khdm || '��' || inv_rkd.xh || '��' As zy,inv_rkd.sl As rksl,inv_rkd.fzsl as rkfzsl,inv_rkd.je As rkje,0.0 As cksl,0.0 AS ckfzsl,0.0 As ckje FROM inv_rkd WHERE inv_rkd.bdelete = 0 AND cpdm = ? AND scph = ?)" &
                " UNION ALL (SELECT po_rkd.rkrq As rq,po_rkd.djh,po_rkd.rkmemo || '��Ӧ��:' || po_rkd.csdm || '��' || po_rkd.xh || '��' As zy,po_rkd.sl As rksl,po_rkd.fzsl AS rkfzsl,po_rkd.je As rkje,0.0 As cksl,0.0 AS ckfzsl,0.0 As ckje FROM po_rkd WHERE po_rkd.bdelete = 0 AND cpdm = ? AND pihao = ?)" &
                " UNION ALL (SELECT TRUNC(inv_dbd.dbrq,'mi') As rq,inv_dbd.djh,inv_dbd.dbmemo || '�����ֿ�' || inv_dbd.cckdm || '��' || inv_dbd.xh || '��' As zy,inv_dbd.sl As rksl,inv_dbd.fzsl AS rkfzsl,inv_dbd.je As rkje,0.0 As cksl,0.0 AS ckfzsl,0.0 As ckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND cpdm = ? AND scph = ?)" &
                " UNION ALL (SELECT oe_xsd.xsrq As rq,oe_xsd.djh,oe_xsd.xsmemo || '��' || oe_xsd.xh || '��' AS zy,0.0 As rksl,0.0 AS rkfzsl,0.0 As rkje,oe_xsd.sl As cksl,oe_xsd.fzsl AS ckfzsl,oe_xsd.cbje As ckje FROM oe_xsd WHERE oe_xsd.bdelete = 0 AND cpdm = ? AND pihao = ?)" &
                " UNION ALL (SELECT inv_ckd.ckrq As rq,inv_ckd.djh,inv_ckd.ckmemo || '��' || inv_ckd.xh || '��' || '��Ӧ��:' || inv_ckd.csdm AS zy,0.0 As rksl,0.0 AS rkfzsl,0.0 As rkje,inv_ckd.sl As cksl,inv_ckd.fzsl AS ckfzsl,inv_ckd.je As ckje FROM inv_ckd WHERE inv_ckd.bdelete = 0 AND cpdm = ? AND scph = ?)" &
                " UNION ALL (SELECT TRUNC(inv_dbd.dbrq,'mi') As rq,inv_dbd.djh,inv_dbd.dbmemo || '����ֿ�' || inv_dbd.rckdm || '��' || inv_dbd.xh || '��' AS zy,0.0 As rksl,0.0 AS rkfzsl,0.0 As rkje,inv_dbd.sl As cksl,inv_dbd.fzsl AS ckfzsl,inv_dbd.je As ckje FROM inv_dbd WHERE inv_dbd.bdelete = 0 AND cpdm = ? AND pihao = ?)"
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
            MsgBox("�������1��" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try

        If rcDataset.Tables("cpsfcmx").Rows.Count <= 0 Then
            MsgBox("û���������������ݡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        Dim i As Integer
        Dim rcDataView As New DataView(rcDataset.Tables("cpsfcmx"), "TRUE", "rq", DataViewRowState.CurrentRows)
        '������ĩ���
        For i = 0 To rcDataView.Count - 1
            dblJcsl += rcDataView.Table.Rows(i).Item("rksl") - rcDataView.Table.Rows(i).Item("cksl")
            rcDataView.Table.Rows(i).Item("jcsl") = dblJcsl
            dblJcfzsl += rcDataView.Table.Rows(i).Item("rkfzsl") - rcDataView.Table.Rows(i).Item("ckfzsl")
            rcDataView.Table.Rows(i).Item("jcfzsl") = dblJcfzsl
            dblJcje += rcDataView.Table.Rows(i).Item("rkje") - rcDataView.Table.Rows(i).Item("ckje")
            rcDataView.Table.Rows(i).Item("jcje") = dblJcje
        Next
        '���ñ�
        Dim rcFrm As New FrmPhSfcMxz
        With rcFrm
            .ParaDataSet = rcDataset
            .paraDataView = New DataView(rcDataset.Tables("cpsfcmx"), "TRUE", "rq", DataViewRowState.CurrentRows)
            '.paraDataTable = rcDataset.Tables("cpsfcmx")
            .Label3.Text = "���κţ�" & Me.TxtPiHao.Text
            If rcDataset.Tables("rc_cpxx").Rows.Count > 0 Then
                .Label2.Text = "���ϣ�(" & Me.TxtCpdm.Text & ")" & rcDataset.Tables("rc_cpxx").Rows(0).Item("cpmc") & " " & rcDataset.Tables("rc_cpxx").Rows(0).Item("dw")
            End If
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class