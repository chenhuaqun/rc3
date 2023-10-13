Imports System.Data.OleDb

Public Class FrmFkdHx

#Region "�������"

    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '��ʾҪ������Դִ�е� SQL ����
    Dim rcOleDbTrans As OleDbTransaction
    '��������
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '���ӵ��ݵı���
    ReadOnly IsAdding As Boolean = False
    '�޸ĵ��ݵı���
    ReadOnly IsEditing As Boolean = False
    '���ݰ�
    ReadOnly rcBmb As BindingManagerBase
    '������ӡ�ĵ�
    ReadOnly rcRps As RPS.Document
    '����ڼ�
    ReadOnly strKjqj As String = g_Kjqj
    '��
    Dim strYear As String = ""
    '��
    Dim strMonth As String = ""
    '����Datatable '����Ҫ���ø�datatable���н�����
    ReadOnly dtFp As New DataTable("rc_fpnr")
    ReadOnly dtFkd As New DataTable("rc_fkdnr")

#End Region

#Region "�����ʼ��"

    Public Property ParaStrYear() As String
        Get
            ParaStrYear = strYear
        End Get
        Set(ByVal Value As String)
            strYear = Value
        End Set
    End Property

    Public Property ParaStrMonth() As String
        Get
            ParaStrMonth = strMonth
        End Get
        Set(ByVal Value As String)
            strMonth = Value
        End Set
    End Property

    Private Sub FrmFkdHx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DataGridViewRkd.AutoGenerateColumns = False
        Me.DataGridViewFkd.AutoGenerateColumns = False
        Me.DataGridViewRkd.Columns("ColRkSl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewRkd.Columns("ColRkSl").DefaultCellStyle.Format = g_FormatSl
        Me.DataGridViewRkd.Columns("ColRkDj").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewRkd.Columns("ColRkDj").DefaultCellStyle.Format = g_FormatDj
        Me.DataGridViewRkd.Columns("ColRkHsdj").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewRkd.Columns("ColRkHsdj").DefaultCellStyle.Format = g_FormatDj
        Me.DataGridViewRkd.Columns("ColRkJe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewRkd.Columns("ColRkJe").DefaultCellStyle.Format = g_FormatJe
        Me.DataGridViewRkd.Columns("ColRkShlv").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewRkd.Columns("ColRkShlv").DefaultCellStyle.Format = g_FormatJe
        Me.DataGridViewRkd.Columns("ColRkSe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewRkd.Columns("ColRkSe").DefaultCellStyle.Format = g_FormatJe
        Me.DataGridViewRkd.Columns("ColRkJese").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewRkd.Columns("ColRkJese").DefaultCellStyle.Format = g_FormatJe
        Me.DataGridViewRkd.Columns("ColYifje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewRkd.Columns("ColYifje").DefaultCellStyle.Format = g_FormatJe
        Me.DataGridViewFkd.Columns("ColFkje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewFkd.Columns("ColFkje").DefaultCellStyle.Format = g_FormatJe
        Me.DataGridViewFkd.Columns("ColYufje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewFkd.Columns("ColYufje").DefaultCellStyle.Format = g_FormatJe
        '���ݰ�
        dtFp.Columns.Add("xz", Type.GetType("System.Boolean"))
        dtFp.Columns.Add("fprq", Type.GetType("System.DateTime"))
        dtFp.Columns.Add("rkdjh", Type.GetType("System.String"))
        dtFp.Columns.Add("rkzy", Type.GetType("System.String"))
        dtFp.Columns.Add("rksl", Type.GetType("System.Double"))
        dtFp.Columns.Add("rkdj", Type.GetType("System.Double"))
        dtFp.Columns.Add("rkhsdj", Type.GetType("System.Double"))
        dtFp.Columns.Add("rkje", Type.GetType("System.Double"))
        dtFp.Columns.Add("rkshlv", Type.GetType("System.Double"))
        dtFp.Columns.Add("rkse", Type.GetType("System.Double"))
        dtFp.Columns.Add("rkjese", Type.GetType("System.Double"))
        dtFp.Columns.Add("yifje", Type.GetType("System.Double"))
        rcDataSet.Tables.Add(dtFp)
        With rcDataSet.Tables("rc_fpnr")
            .Columns("xz").DefaultValue = 0
            .Columns("rkdjh").DefaultValue = ""
            .Columns("rkzy").DefaultValue = ""
            .Columns("rksl").DefaultValue = 0.0
            .Columns("rkdj").DefaultValue = 0.0
            .Columns("rkhsdj").DefaultValue = 0.0
            .Columns("rkje").DefaultValue = 0.0
            .Columns("rkshlv").DefaultValue = 0.0
            .Columns("rkse").DefaultValue = 0.0
            .Columns("rkjese").DefaultValue = 0.0
            .Columns("yifje").DefaultValue = 0.0
        End With
        '������the DataGrid to the DataSet.
        Me.BindingSourceRkd.DataSource = dtFp
        Me.DataGridViewRkd.DataSource = Me.BindingSourceRkd
        '������ṹ
        dtFkd.Columns.Add("xz", Type.GetType("System.Boolean"))
        dtFkd.Columns.Add("fkrq", Type.GetType("System.DateTime"))
        dtFkd.Columns.Add("fkdjh", Type.GetType("System.String"))
        dtFkd.Columns.Add("fkzy", Type.GetType("System.String"))
        dtFkd.Columns.Add("fkje", Type.GetType("System.Double"))
        dtFkd.Columns.Add("yufje", Type.GetType("System.Double"))
        rcDataSet.Tables.Add(dtFkd)
        With rcDataSet.Tables("rc_fkdnr")
            .Columns("xz").DefaultValue = 0
            .Columns("fkdjh").DefaultValue = ""
            .Columns("fkzy").DefaultValue = ""
            .Columns("fkje").DefaultValue = 0.0
            .Columns("yufje").DefaultValue = 0.0
        End With
        '������the DataGrid to the DataSet.
        Me.BindingSourceFkd.DataSource = dtFkd
        Me.DataGridViewFkd.DataSource = Me.BindingSourceFkd

    End Sub

#End Region

#Region "�ؼ��س����Ĵ���"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCsdm.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "��Ӧ�̱�����¼�"

    Private Sub TxtCsdm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCsdm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim rcFrm As New models.FrmF3KeyPress
                With rcFrm
                    .paraOleDbConn = rcOleDbConn
                    .paraTableName = "rc_csxx"
                    .paraField1 = "csdm"
                    .paraField2 = "csmc"
                    .paraField3 = "cssm"
                    .paraCondition = "0=0"
                    .paraOrderField = "csmc"
                    .paraTitle = "��Ӧ��"
                    .paraOldValue = ""
                    .paraAddName = ""
                    If .ShowDialog = DialogResult.OK Then
                        TxtCsdm.Text = Trim(.paraField1)
                        LblCsmc.Text = Trim(.paraField2)
                    End If
                End With
        End Select
    End Sub

    Private Sub TxtCsdm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCsdm.Validating
        If Not String.IsNullOrEmpty(Me.TxtCsdm.Text) Then
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM rc_csxx WHERE (csdm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtCsdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_csxx") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_csxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_csxx")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_csxx").Rows.Count > 0 Then
                TxtCsdm.Text = Trim(rcDataSet.Tables("rc_csxx").Rows(0).Item("csdm"))
                LblCsmc.Text = rcDataSet.Tables("rc_csxx").Rows(0).Item("csmc")
            Else
                e.Cancel = True
                Return
            End If
            ReadData()
        End If
    End Sub

#End Region

#Region "�����Ѻ�������ѡ��"

    Private Sub ChbHx_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbHx.CheckedChanged
        If Me.ChbHx.Checked Then
            Me.BtnCancel.Enabled = True
        Else
            Me.BtnCancel.Enabled = False
        End If
        ReadData()
    End Sub

#End Region

#Region "��ȡ����"

    Private Sub ReadData()
        If Not String.IsNullOrEmpty(Me.TxtCsdm.Text) Then
            'ȡӦ����ϸ
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT 0 AS xz,fprq,'(' ||cpdm || ')' || cpmc || dw || fpmemo AS rkzy,sl AS rksl,dj AS rkdj,hsdj AS rkhsdj,je AS rkje,shlv AS rkshlv,se As rkse,(je + se) AS rkjese,fkje As yifje,djh,xh FROM po_fp WHERE " & IIf(Me.ChbHx.Checked, "", " je + se <> fkje AND") & " po_fp.bdelete = 0 AND csdm = ? ORDER BY fprq,djh,xh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtCsdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_fpnr") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_fpnr").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_fpnr")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            Me.NudYifje.Value = 0.0
            Me.NudYfyh.Value = 0.0
            'ȡ������ϸ
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT 1 AS xz,fkrq,yspz || fkmemo fkzy,je AS fkje,je - rkje AS yufje,djh FROM ap_fkd WHERE " & IIf(Me.ChbHx.Checked, "", "je <> rkje AND ") & "csdm = ? ORDER BY fkrq,djh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 12).Value = Trim(Me.TxtCsdm.Text)
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataSet.Tables("rc_fkdnr") IsNot Nothing Then
                    Me.rcDataSet.Tables("rc_fkdnr").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataSet, "rc_fkdnr")
            Catch ex As Exception
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataSet.Tables("rc_fkdnr").Rows.Count > 0 Then
                Me.NudYufje.Value = dtFkd.Compute("Sum(yufje)", "")
                Me.NudFkyh.Value = dtFkd.Compute("Sum(fkje)-Sum(yufje)", "")
            Else
                Me.NudYufje.Value = 0.0
                Me.NudFkyh.Value = 0.0
            End If
            Me.NudWfje.Value = Me.NudYifje.Value - Me.NudYufje.Value
        End If
    End Sub
#End Region

#Region "�������¼�"

    Private Sub MnuiSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiSave.Click, BtnSave.Click
        SaveEvent()
    End Sub

    Private Sub SaveEvent()
        Dim i As Integer
        Dim dblFkje As Double = Me.NudYufje.Value
        Dim dblRkje As Double = Me.NudYifje.Value
        Dim dblHxje As Double = 0.0
        '(һ)���ݺϷ��Լ��
        '(1)�Ƿ�����Ҫ�洢������
        '(2)��Ӧ�̼��
        If Trim(Me.TxtCsdm.Text).Length = 0 Then
            MsgBox("�����빩Ӧ�̱��롣", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            Return
        End If
        '(��)�洢skd
        '������ �� Ӧ����� �� Ԥ����� 
        If Me.NudYifje.Value - Me.NudYufje.Value = 0 Then
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            Try
                rcOleDbCommand.CommandType = CommandType.Text
                '������ʷ��ⵥ�ϵĸ�����
                For i = 0 To rcDataset.Tables("rc_fpnr").Rows.Count - 1
                    If rcDataset.Tables("rc_fpnr").Rows(i).Item("xz") Then
                        rcOleDbCommand.CommandText = "UPDATE po_fp SET fkje = je + se WHERE djh = ? AND xh = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("djh")
                        rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("xh")
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                Next
                '����ʷ����ϵ������
                For i = 0 To rcDataset.Tables("rc_fkdnr").Rows.Count - 1
                    If rcDataset.Tables("rc_fkdnr").Rows(i).Item("xz") Then
                        rcOleDbCommand.CommandText = "UPDATE ap_fkd SET rkje = je WHERE djh = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_fkdnr").Rows(i).Item("djh")
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                Next
                rcOleDbTrans.Commit()
            Catch ex As Exception
                MsgBox("�������1��" & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        Else
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            Try
                rcOleDbCommand.CommandType = CommandType.Text
                '������ʷ��ⵥ�ϵĸ�����
                For i = 0 To rcDataset.Tables("rc_fpnr").Rows.Count - 1
                    If rcDataset.Tables("rc_fpnr").Rows(i).Item("xz") And dblFkje <> 0 Then
                        rcOleDbCommand.CommandText = "UPDATE po_fp SET fkje = fkje + ? WHERE djh = ? AND xh = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraDblFkje", OleDbType.Numeric, 14).Value = IIf(dblFkje >= rcDataset.Tables("rc_fpnr").Rows(i).Item("rkjese") - rcDataset.Tables("rc_fpnr").Rows(i).Item("yifje"), rcDataset.Tables("rc_fpnr").Rows(i).Item("rkjese") - rcDataset.Tables("rc_fpnr").Rows(i).Item("yifje"), dblFkje)
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("djh")
                        rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("xh")
                        rcOleDbCommand.ExecuteNonQuery()
                        dblHxje += IIf(dblFkje >= rcDataset.Tables("rc_fpnr").Rows(i).Item("rkjese") - rcDataset.Tables("rc_fpnr").Rows(i).Item("yifje"), rcDataset.Tables("rc_fpnr").Rows(i).Item("rkjese") - rcDataset.Tables("rc_fpnr").Rows(i).Item("yifje"), dblFkje)
                        dblFkje -= IIf(dblFkje >= rcDataset.Tables("rc_fpnr").Rows(i).Item("rkjese") - rcDataset.Tables("rc_fpnr").Rows(i).Item("yifje"), rcDataset.Tables("rc_fpnr").Rows(i).Item("rkjese") - rcDataset.Tables("rc_fpnr").Rows(i).Item("yifje"), dblFkje)
                    End If
                Next
                '����ʷ����ϵ������
                For i = 0 To rcDataset.Tables("rc_fkdnr").Rows.Count - 1
                    If rcDataset.Tables("rc_fkdnr").Rows(i).Item("xz") Then
                        rcOleDbCommand.CommandText = "UPDATE ap_fkd SET rkje = rkje + ? WHERE djh = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraDblRkje", OleDbType.Numeric, 14).Value = IIf(dblRkje >= rcDataset.Tables("rc_fkdnr").Rows(i).Item("yufje"), rcDataset.Tables("rc_fkdnr").Rows(i).Item("yufje"), dblRkje)
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_fkdnr").Rows(i).Item("djh")
                        rcOleDbCommand.ExecuteNonQuery()
                        dblHxje -= IIf(dblRkje >= rcDataset.Tables("rc_fkdnr").Rows(i).Item("yufje"), rcDataset.Tables("rc_fkdnr").Rows(i).Item("yufje"), dblRkje)
                        dblRkje -= IIf(dblRkje >= rcDataset.Tables("rc_fkdnr").Rows(i).Item("yufje"), rcDataset.Tables("rc_fkdnr").Rows(i).Item("yufje"), dblRkje)
                    End If
                Next
                rcOleDbTrans.Commit()
            Catch ex As Exception
                MsgBox("�������" & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        End If
        '�������
        Me.TxtCsdm.Text = ""
        Me.LblCsmc.Text = ""
        Me.NudYifje.Value = 0.0
        Me.NudYufje.Value = 0.0
        Me.NudWfje.Value = 0.0
        Me.NudYfyh.Value = 0.0
        Me.NudFkyh.Value = 0.0
        If dtFp IsNot Nothing Then
            dtFp.Clear()
        End If
        If dtFkd IsNot Nothing Then
            dtFkd.Clear()
        End If
        '���ý���
        Me.TxtCsdm.Focus()
    End Sub

#End Region

#Region "����"

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click, MnuiCancel.Click
        Dim i As Integer
        '������ �� Ӧ����� �� Ԥ����� 
        If Me.NudYfyh.Value - Me.NudFkyh.Value = 0 Then
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                '������ʷ��ⵥ�ϵĸ�����
                For i = 0 To rcDataset.Tables("rc_fpnr").Rows.Count - 1
                    If rcDataset.Tables("rc_fpnr").Rows(i).Item("xz") Then
                        rcOleDbCommand.CommandText = "UPDATE po_fp SET fkje = 0.0 WHERE djh = ? AND xh = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("djh")
                        rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = rcDataset.Tables("rc_fpnr").Rows(i).Item("xh")
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                Next
                '����ʷ����ϵ������
                For i = 0 To rcDataset.Tables("rc_fkdnr").Rows.Count - 1
                    If rcDataset.Tables("rc_fkdnr").Rows(i).Item("xz") Then
                        rcOleDbCommand.CommandText = "UPDATE ap_fkd SET rkje = 0.0 WHERE djh = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_fkdnr").Rows(i).Item("djh")
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                Next
                rcOleDbTrans.Commit()
            Catch ex As Exception
                MsgBox("�������1��" & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            '�������
            Me.TxtCsdm.Text = ""
            Me.LblCsmc.Text = ""
            Me.NudYifje.Value = 0.0
            Me.NudYufje.Value = 0.0
            Me.NudWfje.Value = 0.0
            Me.NudYfyh.Value = 0.0
            Me.NudFkyh.Value = 0.0
            If dtFp IsNot Nothing Then
                dtFp.Clear()
            End If
            If dtFkd IsNot Nothing Then
                dtFkd.Clear()
            End If
            '���ý���
            Me.TxtCsdm.Focus()
        Else
            MsgBox("Ӧ���˿��Ѻ˽���븶��Ѻ˽��ȣ�����ȡ��������", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
            Return
        End If
    End Sub

#End Region

#Region "�˳����¼�"

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

#End Region

    Private Sub DataGridViewRkd_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DataGridViewRkd.CellValidating
        If Me.DataGridViewRkd.IsCurrentCellDirty Then
            Me.DataGridViewRkd.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
        '���ܱ���Ӧ�����
        Dim i As Integer
        Me.NudYifje.Value = 0.0
        Me.NudYfyh.Value = 0.0
        For i = 0 To rcDataset.Tables("rc_fpnr").Rows.Count - 1
            If rcDataset.Tables("rc_fpnr").Rows(i).Item("xz").GetType.ToString <> "System.DBNull" Then
                If rcDataset.Tables("rc_fpnr").Rows(i).Item("xz") Then
                    Me.NudYifje.Value = Me.NudYifje.Value + rcDataset.Tables("rc_fpnr").Rows(i).Item("rkjese") - rcDataset.Tables("rc_fpnr").Rows(i).Item("yifje")
                    Me.NudYfyh.Value = Me.NudYfyh.Value + rcDataset.Tables("rc_fpnr").Rows(i).Item("yifje")
                End If
            End If
        Next
        Me.NudWfje.Value = Me.NudYifje.Value - Me.NudYufje.Value
    End Sub

    Private Sub DataGridViewRkd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewRkd.Leave
        Me.DataGridViewRkd.ClearSelection()
    End Sub

    Private Sub BtnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectAll.Click
        '���ܱ���Ӧ�����
        Dim i As Integer
        Me.NudYifje.Value = 0.0
        Me.NudYfyh.Value = 0.0
        For i = 0 To rcDataset.Tables("rc_fpnr").Rows.Count - 1
            rcDataset.Tables("rc_fpnr").Rows(i).Item("xz") = True
            Me.NudYifje.Value = Me.NudYifje.Value + rcDataset.Tables("rc_fpnr").Rows(i).Item("rkjese") - rcDataset.Tables("rc_fpnr").Rows(i).Item("yifje")
            Me.NudYfyh.Value = Me.NudYfyh.Value + rcDataset.Tables("rc_fpnr").Rows(i).Item("yifje")
        Next
        Me.NudWfje.Value = Me.NudYifje.Value - Me.NudYufje.Value
    End Sub

    Private Sub DataGridViewFkd_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DataGridViewFkd.CellValidating
        If Me.DataGridViewFkd.IsCurrentCellDirty Then
            Me.DataGridViewFkd.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
        '���ܱ���Ԥ�����
        Dim i As Integer
        Me.NudYufje.Value = 0.0
        Me.NudFkyh.Value = 0.0
        For i = 0 To rcDataSet.Tables("rc_fkdnr").Rows.Count - 1
            If rcDataSet.Tables("rc_fkdnr").Rows(i).Item("xz").GetType.ToString <> "System.DBNull" Then
                If rcDataSet.Tables("rc_fkdnr").Rows(i).Item("xz") Then
                    Me.NudYufje.Value = Me.NudYufje.Value + rcDataSet.Tables("rc_fkdnr").Rows(i).Item("yufje")
                    Me.NudFkyh.Value = Me.NudFkyh.Value + rcDataSet.Tables("rc_fkdnr").Rows(i).Item("fkje") - rcDataSet.Tables("rc_fkdnr").Rows(i).Item("yufje")
                End If
            End If
        Next
        Me.NudWfje.Value = Me.NudYifje.Value - Me.NudYufje.Value

    End Sub

    Private Sub DataGridViewFkd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewFkd.Leave
        Me.DataGridViewFkd.ClearSelection()
    End Sub
End Class