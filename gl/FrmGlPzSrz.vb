Imports System.Data.OleDb
Imports System.Math

Public Class FrmGlPzSrz

#Region "�������"

    '��������������
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '����DataSet����
    ReadOnly rcDataset As New DataSet
    '��ʾҪ������Դִ�е� SQL ����
    Dim rcOleDbTrans As OleDbTransaction
    '����OleDbCommand����
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '����Datatable
    ReadOnly dtPz As New DataTable("rc_pz")
    '��
    Dim strYear As String = ""
    '��
    Dim strMonth As String = ""
    '����ڼ�
    Dim strKjqj As String = g_Kjqj
    '���ӵ��ݵı���
    Dim IsAdding As Boolean = False
    '�޸ĵ��ݵı���
    Dim IsEditing As Boolean = False
    'DataGridViewTextBoxEditingControl
    Dim EditingControl As DataGridViewTextBoxEditingControl
    '��ӡ�ĵ�
    Dim rcRps As RPS.Document = Nothing

#End Region

#Region "��ʼ��"

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

    Private Sub FrmGlPzSrz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '����DataGridView
        Me.rcDataGridView.AutoGenerateColumns = False
        Me.rcDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.rcDataGridView.Font = New System.Drawing.Font("����", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))

        Me.rcDataGridView.Columns("ColJfje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColJfje").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColDfje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColDfje").DefaultCellStyle.Format = g_FormatJe
        Try
            'ȡ������������
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc From rc_lx Where lxgs = '����ƾ֤' AND kjnd = '" & strYear & "' ORDER BY pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_lx") IsNot Nothing Then
                Me.rcDataSet.Tables("rc_lx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_lx")
        Catch ex As Exception
            MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("rc_lx").Rows.Count = 0 Then
            MsgBox("�붨�嵥�����͡�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        '��ƾ֤���ͼ��
        BindDropDownList(CmbPzlxjc, rcDataSet.Tables("rc_lx"), "pzlxdm", "pzlxjc")
        '���ݰ�
        dtPz.Columns.Add("zy", Type.GetType("System.String"))
        dtPz.Columns.Add("kmdm", Type.GetType("System.String"))
        dtPz.Columns.Add("kmmc", Type.GetType("System.String"))
        dtPz.Columns.Add("bmdm", Type.GetType("System.String"))
        dtPz.Columns.Add("bmmc", Type.GetType("System.String"))
        dtPz.Columns.Add("xmdm", Type.GetType("System.String"))
        dtPz.Columns.Add("xmmc", Type.GetType("System.String"))
        dtPz.Columns.Add("khdm", Type.GetType("System.String"))
        dtPz.Columns.Add("khmc", Type.GetType("System.String"))
        dtPz.Columns.Add("csdm", Type.GetType("System.String"))
        dtPz.Columns.Add("csmc", Type.GetType("System.String"))
        dtPz.Columns.Add("yhzh", Type.GetType("System.String"))
        dtPz.Columns.Add("jxzh", Type.GetType("System.String"))
        dtPz.Columns.Add("dwmc", Type.GetType("System.String"))
        dtPz.Columns.Add("dfkm", Type.GetType("System.String"))
        dtPz.Columns.Add("dw", Type.GetType("System.String"))
        dtPz.Columns.Add("sl", Type.GetType("System.Double"))
        dtPz.Columns.Add("dj", Type.GetType("System.Double"))
        dtPz.Columns.Add("bz", Type.GetType("System.String"))
        dtPz.Columns.Add("wb", Type.GetType("System.Double"))
        dtPz.Columns.Add("hl", Type.GetType("System.Double"))
        dtPz.Columns.Add("jfje", Type.GetType("System.Double"))
        dtPz.Columns.Add("dfje", Type.GetType("System.Double"))
        dtPz.Columns.Add("yspz", Type.GetType("System.String"))
        dtPz.Columns.Add("jsr", Type.GetType("System.String"))
        dtPz.Columns.Add("wldqr", Type.GetType("System.DateTime"))
        rcDataSet.Tables.Add(dtPz)
        With dtPz
            .Columns("zy").DefaultValue = ""
            .Columns("kmdm").DefaultValue = ""
            .Columns("kmmc").DefaultValue = ""
            .Columns("bmdm").DefaultValue = ""
            .Columns("bmmc").DefaultValue = ""
            .Columns("xmdm").DefaultValue = ""
            .Columns("xmmc").DefaultValue = ""
            .Columns("khdm").DefaultValue = ""
            .Columns("khmc").DefaultValue = ""
            .Columns("csdm").DefaultValue = ""
            .Columns("csmc").DefaultValue = ""
            .Columns("yspz").DefaultValue = ""
            .Columns("jsr").DefaultValue = ""
            .Columns("yhzh").DefaultValue = ""
            .Columns("jxzh").DefaultValue = ""
            .Columns("dwmc").DefaultValue = ""
            .Columns("dfkm").DefaultValue = ""
            .Columns("dw").DefaultValue = ""
            .Columns("sl").DefaultValue = 0.0
            .Columns("dj").DefaultValue = 0.0
            .Columns("bz").DefaultValue = ""
            .Columns("wb").DefaultValue = 0.0
            .Columns("hl").DefaultValue = 0.0
            .Columns("jfje").DefaultValue = 0.0
            .Columns("dfje").DefaultValue = 0.0
        End With
        '������the DataGrid to the DataSet.
        rcBindingSource.DataSource = dtPz
        Me.rcDataGridView.DataSource = rcBindingSource

        strKjqj = strYear & strMonth
        If getInvKjqj(g_Kjrq) = strKjqj Then
            Me.DtpPzrq.Value = g_Kjrq
        Else
            Me.DtpPzrq.Value = getInvEnd(strYear, strMonth)
        End If
        NewEvent()
    End Sub

#End Region

#Region "���ÿؼ�"

    Private Sub SetControlEnableEvent()
        If IsEditing = True Then
            Me.CmbPzlxjc.Enabled = False
            Me.TxtDjh.Enabled = False
            Me.BtnNew.Enabled = False
            Me.BtnSave.Enabled = True
            Me.BtnCancel.Enabled = True
            Me.BtnExit.Enabled = False
            Me.MnuiNew.Enabled = False
            Me.MnuiSave.Enabled = True
            Me.MnuiCancel.Enabled = True
            Me.MnuiExit.Enabled = False
        Else
            If dtPz.Rows.Count > 0 Then
                Me.CmbPzlxjc.Enabled = False
            Else
                Me.CmbPzlxjc.Enabled = True
            End If
            Me.TxtDjh.Enabled = True
            Me.BtnNew.Enabled = True
            Me.BtnSave.Enabled = False
            Me.BtnCancel.Enabled = False
            Me.BtnExit.Enabled = True
            Me.MnuiNew.Enabled = True
            Me.MnuiSave.Enabled = False
            Me.MnuiCancel.Enabled = False
            Me.MnuiExit.Enabled = True
        End If
    End Sub

#End Region

#Region "�ؼ��س����Ĵ���"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbPzlxjc.KeyPress, TxtDjh.KeyPress, DtpPzrq.KeyPress, TxtFjzs.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
        End Select
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If (Me.ActiveControl.GetType.Name = "DataGridViewTextBoxEditingControl" Or Me.rcDataGridView.Focused) Then
            Select Case keyData
                Case Keys.Enter, Keys.Right
                    SendKeys.Send("{TAB}")
                    Return True
                Case Keys.Left
                    SendKeys.Send("+{TAB}")
                    Return True
            End Select
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

#End Region

#Region "ƾ֤���͵��¼�"

    Private Sub CmbPzlxjc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbPzlxjc.Validated
        ShowNewDjh()
    End Sub

#End Region

#Region "ƾ֤�ŵ��¼�"

    Private Sub TxtDjh_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDjh.KeyDown
        Select Case e.KeyCode
            Case Keys.F7
                'ɾ�����һ�ŵ���
                '1.����������ӵ����򷵻�
                If IsAdding Then
                    Return
                End If
                '2.ɾ��
                If MsgBox("�Ƿ�Ҫɾ�����һ�ŵ��ݣ�", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "��ʾ��Ϣ") = MsgBoxResult.Ok Then
                    rcOleDbConn.Open()
                    rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.Transaction = rcOleDbTrans
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.StoredProcedure
                    Try
                        rcOleDbCommand.CommandText = "USP_DELETE_GL_PZ"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = Trim(Me.TxtDjh.Text)
                        rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                        rcOleDbCommand.Parameters.Add("@paraIntError", OleDbType.Integer, 4).Direction = ParameterDirection.Output
                        rcOleDbCommand.ExecuteNonQuery()
                        If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                            If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                                MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                                Return
                            End If
                        End If
                        rcOleDbTrans.Commit()
                    Catch ex As Exception
                        Try
                            rcOleDbTrans.Rollback()
                            MsgBox("ִ�д洢���̷����˴���" & rcOleDbCommand.Parameters("@paraIntError").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                        Catch ey As OleDbException
                            MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                        End Try
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                Else
                    Return
                End If
                '3.��ʾ�µ���
                NewEvent()
                Me.TxtDjh.Focus()
                SetControlEnableEvent()
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtDjh_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtDjh.Validating
        If IsEditing Then
            Return
        End If
        '��鵥�ݺ��Ƿ����
        If rcDataSet.Tables("rc_pzno") Is Nothing Then
            Return
        End If
        rcOleDbConn.Open()
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            '�ж����ӻ����޸�
            If rcDataSet.Tables("rc_pzno").Rows.Count > 0 Then
                If rcDataSet.Tables("rc_pzno").Rows(0).Item("pzno") >= Mid(Trim(Me.TxtDjh.Text), 11, 5) Then
                    '�޸ĵ���
                    rcOleDbCommand.CommandText = "Select gl_pz.djh,gl_pz.bdelete,gl_pz.pzrq,gl_pz.fjzs,gl_pz.srr,gl_pz.shr,gl_pz.jzr FROM gl_pz WHERE (gl_pz.djh = ?)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.AddWithValue("@djh", Me.TxtDjh.Text)
                    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                    If rcDataSet.Tables("rc_pz") IsNot Nothing Then
                        Me.rcDataSet.Tables("rc_pz").Clear()
                    End If
                    If rcDataSet.Tables("pzml") IsNot Nothing Then
                        Me.rcDataSet.Tables("pzml").Clear()
                    End If
                    rcOleDbDataAdpt.Fill(rcDataSet, "pzml")
                    If rcDataSet.Tables("pzml").Rows.Count > 0 Then
                        If rcDataSet.Tables("pzml").Rows(0).Item("jzr").GetType.ToString <> "System.DBNull" Then
                            MsgBox("�õ����Ѿ����ˣ������޸ġ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                            IsAdding = True
                        Else
                            If rcDataSet.Tables("pzml").Rows(0).Item("shr").GetType.ToString <> "System.DBNull" Then
                                MsgBox("�õ����Ѿ���ˣ������޸ġ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                                IsAdding = True
                            Else
                                Me.DtpPzrq.Value = rcDataSet.Tables("pzml").Rows(0).Item("pzrq")
                                Me.TxtFjzs.Text = rcDataSet.Tables("pzml").Rows(0).Item("fjzs")
                                Me.LblBdelete.Text = IIf(rcDataSet.Tables("pzml").Rows(0).Item("bdelete"), "����", "")
                                '�޸ĵ���
                                rcOleDbCommand.CommandText = "SELECT gl_pz.xh,gl_pz.zy,gl_pz.kmdm,gl_pz.kmmc,gl_pz.bmdm,gl_pz.bmmc,gl_pz.xmdm,gl_pz.xmmc,gl_pz.khdm,gl_pz.khmc,gl_pz.csdm,gl_pz.csmc,gl_pz.yhzh,gl_pz.jxzh,gl_pz.dwmc,gl_pz.sl,gl_pz.dj,gl_pz.wb,gl_pz.hl,Case When jd = '��' Then je Else 0 End As jfje,Case When jd = '��' Then je Else 0 End As dfje FROM gl_pz Where (gl_pz.djh = ?) ORDER BY gl_pz.xh"
                                rcOleDbCommand.Parameters.Clear()
                                rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.TxtDjh.Text
                                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                                If rcDataSet.Tables("rc_pz") IsNot Nothing Then
                                    Me.rcDataSet.Tables("rc_pz").Clear()
                                End If
                                rcOleDbDataAdpt.Fill(rcDataSet, "rc_pz")
                                Me.rcDataGridView.ClearSelection()
                                Me.TxtJfje.Text = Format(dtPz.Compute("Sum(jfje)", ""), g_FormatJe)
                                Me.TxtDfje.Text = Format(dtPz.Compute("Sum(dfje)", ""), g_FormatJe)
                                IsAdding = False
                            End If
                        End If
                    End If
                Else
                    '��������
                    IsAdding = True
                End If
            End If
        Catch ex As Exception
            Try
                MsgBox("�������" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Catch ey As OleDbException
                MsgBox("�������" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If IsAdding Then
            NewEvent()
        End If
        SetControlEnableEvent()
    End Sub

#End Region

#Region "ƾ֤�����¼�"

    Private Sub DtpPzrq_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpPzrq.Validated
        If strKjqj <> getInvKjqj(Me.DtpPzrq.Value) Then
            MsgBox("��ѡ���ڣ������ڵ�ǰ����ڼ䡣�������", MsgBoxStyle.OkOnly)
            Me.DtpPzrq.Focus()
        End If
    End Sub

#End Region

#Region "���������¼�"

    Private Sub TxtFjzs_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFjzs.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

#End Region

#Region "DataGridView�¼�"

    Private Sub RcDataGridView_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles rcDataGridView.CellValidating
        If Me.rcDataGridView.CurrentRow.IsNewRow = False Then
            If Me.rcDataGridView.IsCurrentCellDirty Then
                Me.rcDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColKmdm" Then
                If Not String.IsNullOrEmpty(e.FormattedValue) Then
                    'ȡ��Ŀ����
                    rcOleDbConn.Open()
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    Try
                        'ȡgl_kmxx
                        rcOleDbCommand.CommandText = "SELECT * FROM gl_kmxx WHERE kmdm = ? And Not Exists (Select 1 From gl_kmxx parentkm Where parentkm.parentid = gl_kmxx.kmdm)"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.AddWithValue("@kmdm", rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColKmdm").EditedFormattedValue)
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataSet.Tables("gl_kmxx") IsNot Nothing Then
                            rcDataSet.Tables("gl_kmxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataSet, "gl_kmxx")
                    Catch ex As Exception
                        MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                    If rcDataSet.Tables("gl_kmxx").Rows.Count > 0 Then
                        '�Ƿ�Ϊ��ϸ��Ŀ
                        Me.rcDataGridView.CurrentRow.Cells("ColKmmc").Value = rcDataSet.Tables("gl_kmxx").Rows(0).Item("kmmc")
                        '���ź���
                        If rcDataSet.Tables("gl_kmxx").Rows(0).Item("kmbm") = 1 Then
                            Dim rcFrm As New FrmGlPzBm
                            With rcFrm
                                .TxtBmdm.Text = Me.rcDataGridView.CurrentRow.Cells("ColBmdm").Value
                                .TxtBmmc.Text = Me.rcDataGridView.CurrentRow.Cells("ColBmmc").Value
                                If .ShowDialog() = DialogResult.OK Then
                                    Me.rcDataGridView.CurrentRow.Cells("ColBmdm").Value = Trim(.TxtBmdm.Text)
                                    Me.rcDataGridView.CurrentRow.Cells("ColBmmc").Value = Trim(.TxtBmmc.Text)
                                End If
                            End With
                        End If
                        '�ͻ�����
                        If rcDataSet.Tables("gl_kmxx").Rows(0).Item("kmkh") = 1 Then
                            Dim rcFrm As New FrmGlPzKh
                            With rcFrm
                                .TxtKhdm.Text = Me.rcDataGridView.CurrentRow.Cells("ColKhdm").Value
                                .TxtKhmc.Text = Me.rcDataGridView.CurrentRow.Cells("ColKhmc").Value
                                .TxtYspz.Text = Me.rcDataGridView.CurrentRow.Cells("ColYspz").Value
                                .TxtJsr.Text = Me.rcDataGridView.CurrentRow.Cells("ColJsr").Value
                                If Me.rcDataGridView.CurrentRow.Cells("ColWldqr").Value.GetType.ToString = "System.DateTime" Then
                                    .DtpWldqr.Value = Me.rcDataGridView.CurrentRow.Cells("ColWldqr").Value
                                Else
                                    .DtpWldqr.Value = Me.DtpPzrq.Value
                                End If
                                If .ShowDialog() = DialogResult.OK Then
                                    Me.rcDataGridView.CurrentRow.Cells("ColKhdm").Value = Trim(.TxtKhdm.Text)
                                    Me.rcDataGridView.CurrentRow.Cells("ColKhmc").Value = Trim(.TxtKhmc.Text)
                                    Me.rcDataGridView.CurrentRow.Cells("ColYspz").Value = Trim(.TxtYspz.Text)
                                    Me.rcDataGridView.CurrentRow.Cells("ColJsr").Value = Trim(.TxtJsr.Text)
                                    Me.rcDataGridView.CurrentRow.Cells("ColWldqr").Value = .DtpWldqr.Value
                                End If
                            End With
                        End If
                        '��Ӧ�̺���
                        If rcDataSet.Tables("gl_kmxx").Rows(0).Item("kmcs") = True Then
                            Dim rcFrm As New FrmGlPzCs
                            With rcFrm
                                .TxtCsdm.Text = Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value
                                .TxtCsmc.Text = Me.rcDataGridView.CurrentRow.Cells("ColCsmc").Value
                                .TxtYspz.Text = Me.rcDataGridView.CurrentRow.Cells("ColYspz").Value
                                .TxtJsr.Text = Me.rcDataGridView.CurrentRow.Cells("ColJsr").Value
                                If Me.rcDataGridView.CurrentRow.Cells("ColWldqr").Value.GetType.ToString = "System.DateTime" Then
                                    .DtpWldqr.Value = Me.rcDataGridView.CurrentRow.Cells("ColWldqr").Value
                                Else
                                    .DtpWldqr.Value = Me.DtpPzrq.Value
                                End If
                                If .ShowDialog() = DialogResult.OK Then
                                    Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value = Trim(.TxtCsdm.Text)
                                    Me.rcDataGridView.CurrentRow.Cells("ColCsmc").Value = Trim(.TxtCsmc.Text)
                                    Me.rcDataGridView.CurrentRow.Cells("ColYspz").Value = Trim(.TxtYspz.Text)
                                    Me.rcDataGridView.CurrentRow.Cells("ColJsr").Value = Trim(.TxtJsr.Text)
                                    Me.rcDataGridView.CurrentRow.Cells("ColWldqr").Value = .DtpWldqr.Value
                                End If
                            End With
                        End If
                        '��Ŀ����
                        If rcDataSet.Tables("gl_kmxx").Rows(0).Item("kmxm") = True Then
                            Dim rcFrm As New FrmGlPzXm
                            With rcFrm
                                .TxtXmdm.Text = Me.rcDataGridView.CurrentRow.Cells("ColXmdm").Value
                                .TxtXmmc.Text = Me.rcDataGridView.CurrentRow.Cells("ColXmmc").Value
                                If .ShowDialog() = DialogResult.OK Then
                                    Me.rcDataGridView.CurrentRow.Cells("ColXmdm").Value = Trim(.TxtXmdm.Text)
                                    Me.rcDataGridView.CurrentRow.Cells("ColXmmc").Value = Trim(.TxtXmmc.Text)
                                End If
                            End With
                        End If
                        '���
                        If rcDataSet.Tables("gl_kmxx").Rows(0).Item("kmgs") = 2 Then
                            Dim rcFrm As New FrmGlPzWbje
                            With rcFrm
                                .TxtWbdm.Text = rcDataSet.Tables("gl_kmxx").Rows(0).Item("kmbz")
                                .TxtWb.Text = Me.rcDataGridView.CurrentRow.Cells("ColWb").Value
                                .TxtHl.Text = Me.rcDataGridView.CurrentRow.Cells("ColHl").Value
                                If Me.rcDataGridView.CurrentRow.Cells("ColJfje").Value <> 0.0 Then
                                    .CmbJd.SelectedIndex = 0
                                    .TxtJe.Text = Me.rcDataGridView.CurrentRow.Cells("ColJfje").Value
                                Else
                                    If Me.rcDataGridView.CurrentRow.Cells("ColDfje").Value <> 0.0 Then
                                        .CmbJd.SelectedIndex = 1
                                        .TxtJe.Text = Me.rcDataGridView.CurrentRow.Cells("ColDfje").Value
                                    Else
                                        .CmbJd.SelectedIndex = 0
                                    End If
                                End If
                                If .ShowDialog() = DialogResult.OK Then
                                    Me.rcDataGridView.CurrentRow.Cells("ColWb").Value = .TxtWb.Text
                                    Me.rcDataGridView.CurrentRow.Cells("ColHl").Value = .TxtHl.Text
                                    If .CmbJd.SelectedIndex = 0 Then
                                        Me.rcDataGridView.CurrentRow.Cells("ColJfje").Value = .TxtJe.Text
                                        Me.rcDataGridView.CurrentRow.Cells("ColDfje").Value = 0.0
                                    Else
                                        Me.rcDataGridView.CurrentRow.Cells("ColJfje").Value = 0.0
                                        Me.rcDataGridView.CurrentRow.Cells("ColDfje").Value = .TxtJe.Text
                                    End If
                                End If
                            End With
                        End If
                        '����
                        If rcDataSet.Tables("gl_kmxx").Rows(0).Item("kmgs") = 1 Then
                            Dim rcFrm As New FrmGlPzSlje
                            With rcFrm
                                .TxtDw.Text = rcDataSet.Tables("gl_kmxx").Rows(0).Item("kmdw")
                                .TxtSl.Text = Me.rcDataGridView.CurrentRow.Cells("ColSl").Value
                                .TxtDj.Text = Me.rcDataGridView.CurrentRow.Cells("ColDj").Value
                                If .ShowDialog() = DialogResult.OK Then
                                    Me.rcDataGridView.CurrentRow.Cells("ColSl").Value = Trim(.TxtSl.Text)
                                    Me.rcDataGridView.CurrentRow.Cells("ColDj").Value = Trim(.TxtDj.Text)
                                End If
                            End With
                        End If
                    Else
                        Me.LblMsg.Text = "��Ŀ�����ĩ����Ŀ���Ŀ���벻���ڡ�"
                        e.Cancel = True
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColBmdm" Then
                If Not String.IsNullOrEmpty(e.FormattedValue) Then
                    'ȡ��Ŀ����
                    rcOleDbConn.Open()
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    Try
                        'ȡdwdb
                        rcOleDbCommand.CommandText = "SELECT * FROM gl_bmxx WHERE bmdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.AddWithValue("@bmdm", Me.rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColBmdm").EditedFormattedValue)
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataSet.Tables("gl_bmxx") IsNot Nothing Then
                            rcDataSet.Tables("gl_bmxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataSet, "gl_bmxx")
                    Catch ex As Exception
                        Try
                            MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                        Catch ey As OleDbException
                            MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                        End Try
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                    If rcDataSet.Tables("gl_bmxx").Rows.Count > 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColBmdm").Value = rcDataSet.Tables("gl_bmxx").Rows(0).Item("bmdm")
                        Me.rcDataGridView.CurrentRow.Cells("ColBmmc").Value = rcDataSet.Tables("gl_bmxx").Rows(0).Item("bmmc")
                    Else
                        Me.LblMsg.Text = "���ű��벻���ڡ�"
                        e.Cancel = True
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColKhdm" Then
                If Not String.IsNullOrEmpty(e.FormattedValue) Then
                    'ȡ�ͻ�����
                    Try
                        rcOleDbConn.Open()
                        rcOleDbCommand.Connection = rcOleDbConn
                        rcOleDbCommand.CommandTimeout = 300
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT * FROM rc_khxx WHERE khdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.AddWithValue("@khdm", Me.rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColKhdm").EditedFormattedValue)
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataSet.Tables("rc_khxx") IsNot Nothing Then
                            rcDataSet.Tables("rc_khxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataSet, "rc_khxx")
                    Catch ex As Exception
                        Try
                            MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                        Catch ey As OleDbException
                            MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                        End Try
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                    If rcDataSet.Tables("rc_khxx").Rows.Count > 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColKhdm").Value = rcDataSet.Tables("rc_khxx").Rows(0).Item("khdm")
                        Me.rcDataGridView.CurrentRow.Cells("ColKhmc").Value = rcDataSet.Tables("rc_khxx").Rows(0).Item("khmc")
                    Else
                        Me.LblMsg.Text = "�ͻ����벻���ڡ�"
                        e.Cancel = True
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColCsdm" Then
                If Not String.IsNullOrEmpty(e.FormattedValue) Then
                    'ȡ�ͻ�����
                    Try
                        rcOleDbConn.Open()
                        rcOleDbCommand.Connection = rcOleDbConn
                        rcOleDbCommand.CommandTimeout = 300
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT * FROM rc_csxx WHERE csdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.AddWithValue("@csdm", Me.rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColCsdm").EditedFormattedValue)
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataSet.Tables("rc_csxx") IsNot Nothing Then
                            rcDataSet.Tables("rc_csxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataSet, "rc_csxx")
                    Catch ex As Exception
                        Try
                            MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                        Catch ey As OleDbException
                            MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
                        End Try
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                    If rcDataSet.Tables("rc_csxx").Rows.Count > 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value = rcDataSet.Tables("rc_csxx").Rows(0).Item("csdm")
                        Me.rcDataGridView.CurrentRow.Cells("ColCsmc").Value = rcDataSet.Tables("rc_csxx").Rows(0).Item("csmc")
                    Else
                        Me.LblMsg.Text = "�ͻ����벻���ڡ�"
                        e.Cancel = True
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColJfje" Then
                If e.FormattedValue.ToString.Length > 0 Then
                    If Convert.ToDecimal(e.FormattedValue) <> 0.0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColDfje").ReadOnly = True
                    Else
                        Me.rcDataGridView.CurrentRow.Cells("ColDfje").ReadOnly = False
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColDfje" Then
                If e.FormattedValue.ToString.Length > 0 Then
                    If Convert.ToDecimal(e.FormattedValue) <> 0.0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColJfje").ReadOnly = True
                    Else
                        Me.rcDataGridView.CurrentRow.Cells("ColJfje").ReadOnly = False
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub RcDataGridView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rcDataGridView.KeyDown
        Select Case e.KeyCode
            Case Keys.C And e.Control
                '����
                Clipboard.SetDataObject(Me.rcDataGridView.GetClipboardContent())
            Case Keys.V And e.Control
                'ճ��
                Me.rcDataGridView.CurrentCell.Value = Clipboard.GetText()
                Me.rcDataGridView.EndEdit()
                Me.rcBindingSource.EndEdit()
        End Select
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColKmdm" Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF3KeyPress
                    With rcFrm
                        .paraOleDbConn = rcOleDbConn
                        .paraTableName = "gl_kmxx"
                        .paraField1 = "kmdm"
                        .paraField2 = "kmmc"
                        .paraField3 = "kmsm"
                        .paraTitle = "��Ŀ"
                        .paraOldValue = ""
                        .paraAddName = ""
                        .paraCondition = ""
                        If .ShowDialog = DialogResult.OK Then
                            '���û���rcfrmselectkmdm��ѡ���kmdm����rcdataridView'
                            Me.rcDataGridView.CurrentRow.Cells("ColKmdm").Value = .paraField1
                            Me.rcDataGridView.EndEdit()
                            Me.rcBindingSource.EndEdit()
                        End If
                    End With
            End Select
        End If
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColBmdm" Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF3KeyPress
                    With rcFrm
                        .paraOleDbConn = rcOleDbConn
                        .paraTableName = "gl_bmxx"
                        .paraField1 = "bmdm"
                        .paraField2 = "bmmc"
                        .paraField3 = "bmsm"
                        .paraTitle = "����"
                        .paraOldValue = ""
                        .paraAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            Me.rcDataGridView.CurrentRow.Cells("ColBmdm").Value = .paraField1
                            Me.rcDataGridView.EndEdit()
                            Me.rcBindingSource.EndEdit()
                        End If
                    End With
            End Select
        End If
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColKhdm" Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF3KeyPress
                    With rcFrm
                        .paraOleDbConn = rcOleDbConn
                        .paraTableName = "rc_khxx"
                        .paraField1 = "khdm"
                        .paraField2 = "khmc"
                        .paraField3 = "khsm"
                        .paraTitle = "�ͻ�"
                        .paraOldValue = ""
                        .paraAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            Me.rcDataGridView.CurrentRow.Cells("ColKhdm").Value = .paraField1
                            Me.rcDataGridView.EndEdit()
                            Me.rcBindingSource.EndEdit()
                        End If
                    End With
            End Select
        End If
        'If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColCsdm" And Me.ColCsdm.ReadOnly = False Then
        '    Select Case e.KeyCode
        '        Case Keys.F3
        '            Dim rcFrm As New models.FrmF3KeyPress
        '            With rcFrm
        '                .paraOleDbConn = rcOleDbConn
        '                .paraTableName = "rc_csxx"
        '                .paraField1 = "csdm"
        '                .paraField2 = "csmc"
        '                .paraField3 = "cssm"
        '                .paraTitle = "��Ӧ��"
        '                .paraOldValue = ""
        '                .paraAddName = ""
        '                If .ShowDialog = DialogResult.OK Then
        '                    Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value = .paraField1
        '                    Me.rcDataGridView.EndEdit()
        '                    Me.rcBindingSource.EndEdit()
        '                End If
        '            End With
        '    End Select
        'End If
    End Sub

    Private Sub RcDataGridView_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles rcDataGridView.EditingControlShowing
        EditingControl = e.Control
        If Not EditingControl.IsHandleCreated Then
            AddHandler EditingControl.KeyDown, New KeyEventHandler(AddressOf EditingControl_KeyDown)
            AddHandler EditingControl.KeyPress, New KeyPressEventHandler(AddressOf EditingControl_KeyPress)
        End If
        If Me.rcDataGridView.CurrentCell.OwningColumn.Name = "ColKmdm" Or Me.rcDataGridView.CurrentCell.OwningColumn.Name = "ColBmdm" Or Me.rcDataGridView.CurrentCell.OwningColumn.Name = "ColKhdm" Or Me.rcDataGridView.CurrentCell.OwningColumn.Name = "ColCsdm" Then
            EditingControl.CharacterCasing = CharacterCasing.Upper
        Else
            EditingControl.CharacterCasing = CharacterCasing.Normal
        End If
    End Sub

    Private Sub EditingControl_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColKmdm" Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF3KeyPress
                    With rcFrm
                        .paraOleDbConn = rcOleDbConn
                        .paraTableName = "gl_kmxx"
                        .paraField1 = "kmdm"
                        .paraField2 = "kmmc"
                        .paraField3 = "kmsm"
                        .paraTitle = "��Ŀ"
                        .paraOldValue = ""
                        .paraAddName = ""
                        .paraCondition = ""
                        If .ShowDialog = DialogResult.OK Then
                            '���û���rcfrmselectkmdm��ѡ���kmdm����rcdatarid'
                            Me.rcDataGridView.CurrentRow.Cells("ColKmdm").Value = .paraField1
                            Me.rcDataGridView.EndEdit()
                            Me.rcBindingSource.EndEdit()
                        End If
                    End With
                    e.Handled = True
            End Select
        End If
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColBmdm" Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF3KeyPress
                    With rcFrm
                        .paraOleDbConn = rcOleDbConn
                        .paraTableName = "gl_bmxx"
                        .paraField1 = "bmdm"
                        .paraField2 = "bmmc"
                        .paraField3 = "bmsm"
                        .paraTitle = "����"
                        .paraOldValue = ""
                        .paraAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            '���û���FrmF3KeyPress��ѡ���bmdm����rcdatarid'
                            Me.rcDataGridView.CurrentRow.Cells("ColBmdm").Value = .paraField1
                            Me.rcDataGridView.EndEdit()
                            Me.rcBindingSource.EndEdit()
                        End If
                    End With
                    e.Handled = True
            End Select
        End If
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColKhdm" Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim rcFrm As New models.FrmF3KeyPress
                    With rcFrm
                        .paraOleDbConn = rcOleDbConn
                        .paraTableName = "rc_khxx"
                        .paraField1 = "khdm"
                        .paraField2 = "khmc"
                        .paraField3 = "khsm"
                        .paraTitle = "�ͻ�"
                        .paraOldValue = ""
                        .paraAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            '���û���FrmF3KeyPress��ѡ���bmdm����rcdatarid'
                            Me.rcDataGridView.CurrentRow.Cells("ColKhdm").Value = .paraField1
                            Me.rcDataGridView.EndEdit()
                            Me.rcBindingSource.EndEdit()
                        End If
                    End With
                    e.Handled = True
            End Select
        End If
        'If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColCsdm" And Me.ColCsdm.ReadOnly = False Then
        '    Select Case e.KeyCode
        '        Case Keys.F3
        '            Dim rcFrm As New models.FrmF3KeyPress
        '            With rcFrm
        '                .paraOleDbConn = rcOleDbConn
        '                .paraTableName = "rc_csxx"
        '                .paraField1 = "csdm"
        '                .paraField2 = "csmc"
        '                .paraField3 = "cssm"
        '                .paraTitle = "��Ӧ��"
        '                .paraOldValue = ""
        '                .paraAddName = ""
        '                If .ShowDialog = DialogResult.OK Then
        '                    '���û���FrmF3KeyPress��ѡ���bmdm����rcdatarid'
        '                    Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value = .paraField1
        '                    Me.rcDataGridView.EndEdit()
        '                    Me.rcBindingSource.EndEdit()
        '                End If
        '            End With
        '            e.Handled = True
        '    End Select
        'End If
    End Sub

    Private Sub EditingControl_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColJfje" Or Me.rcDataGridView.Columns(Me.rcDataGridView.CurrentCell.ColumnIndex).Name = "ColDfje" Then
            If ((Convert.ToInt32(e.KeyChar) < 48 OrElse Convert.ToInt32(e.KeyChar) > 57) AndAlso Convert.ToInt32(e.KeyChar) <> 45 AndAlso Convert.ToInt32(e.KeyChar) <> 46 AndAlso Convert.ToInt32(e.KeyChar) <> 8 AndAlso Convert.ToInt32(e.KeyChar) <> 13) Then
                e.Handled = True
            Else
                If ((Convert.ToInt32(e.KeyChar) = 46) AndAlso CType(sender, DataGridViewTextBoxEditingControl).Text.IndexOf(".") <> -1) Then
                    e.Handled = True
                End If
            End If
        End If
    End Sub

    Private Sub RcDataGridView_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles rcDataGridView.Leave
        Me.rcDataGridView.ClearSelection()
    End Sub

    Private Sub RcDataGridView_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles rcDataGridView.RowValidating
        If Not Me.rcDataGridView.CurrentRow.IsNewRow Then
            Me.rcDataGridView.EndEdit()
            Me.rcBindingSource.EndEdit()
        End If
        If dtPz.Rows.Count > 0 Then
            IsEditing = True
            SetControlEnableEvent()
            Me.TxtJfje.Text = Format(dtPz.Compute("Sum(jfje)", ""), g_FormatJe)
            Me.TxtDfje.Text = Format(dtPz.Compute("Sum(dfje)", ""), g_FormatJe)
        End If
    End Sub

    Private Sub RcDataGridView_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles rcDataGridView.CellEndEdit
        'If (e.ColumnIndex = Me.rcDataGridView.Columns("ColJfje").Index Or e.ColumnIndex = Me.rcDataGridView.Columns("ColDfje").Index) AndAlso e.RowIndex > -1 Then
        '    rcDataGridView(e.ColumnIndex, e.RowIndex).Value = Math.Round(Convert.ToDecimal(rcDataGridView(e.ColumnIndex, e.RowIndex).Value), 2, MidpointRounding.AwayFromZero)
        'End If
        '������ESCʱ�����ǰ�еĴ�����ʾClear the row error in case the user presses ESC.   
        Me.rcDataGridView.Rows(e.RowIndex).ErrorText = String.Empty
        Me.LblMsg.Text = ""
    End Sub

#End Region

#Region "�µ��¼�"

    Private Sub MnuiNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiNew.Click, BtnNew.Click
        NewEvent()
    End Sub

    Private Sub NewEvent()
        '�������
        Me.LblBdelete.Text = ""
        Me.TxtFjzs.Text = 1
        Me.TxtJfje.Text = ""
        Me.TxtDfje.Text = ""
        Me.LblMsg.Text = ""
        Me.LblJe.Text = "�ϼƽ�"
        '��ʾ�µ��ݺ�
        ShowNewDjh()
        IsAdding = True
        IsEditing = False
        '�������
        If rcDataSet.Tables("rc_pz") IsNot Nothing Then
            rcDataSet.Tables("rc_pz").Clear()
        End If
    End Sub

    Private Sub ShowNewDjh()
        'ȡ������������
        rcOleDbConn.Open()
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT pzno" & strMonth & " as pzno From rc_lx Where pzlxdm = ? AND lxgs = '����ƾ֤' AND kjnd = '" & strYear & "' ORDER BY pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.AddWithValue("@pzlxdm", Trim(Me.CmbPzlxjc.SelectedValue))
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_pzno") IsNot Nothing Then
                Me.rcDataSet.Tables("rc_pzno").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_pzno")
        Catch ex As Exception
            Try
                MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Catch ey As OleDbException
                MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("rc_pzno").Rows.Count = 0 Then
            MsgBox("�붨�嵥�����͡�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataSet.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
        IsAdding = True
    End Sub

#End Region

#Region "���浥�������¼�"

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MnuiSave.Click
        SaveEvent(False)
    End Sub

    Private Sub SaveEvent(ByVal blnPrint As Boolean)
        Dim i As Integer
        '(һ)���ݺϷ��Լ��
        '(1)�Ƿ�����Ҫ�洢������
        If rcDataset.Tables("rc_pz").Rows.Count = 0 Then
            MsgBox("û����Ӧ��ҵ�������롣", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            Return
        End If
        '(2)���̼��
        If Trim(TxtFjzs.Text).Length = 0 Then
            MsgBox("�����븽��������", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "��ʾ��Ϣ")
            Return
        End If
        '(4)DataTable��Ĭ��ֵ
        For i = 0 To rcDataset.Tables("rc_pz").Rows.Count - 1
            If rcDataset.Tables("rc_pz").Rows(i).Item("kmdm").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_pz").Rows(i).Item("kmdm") = ""
            End If
            If rcDataset.Tables("rc_pz").Rows(i).Item("zy").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_pz").Rows(i).Item("zy") = ""
            End If
            If rcDataset.Tables("rc_pz").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_pz").Rows(i).Item("sl") = 0.0
            End If
            If rcDataset.Tables("rc_pz").Rows(i).Item("jfje").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_pz").Rows(i).Item("jfje") = 0.0
            End If
            If rcDataset.Tables("rc_pz").Rows(i).Item("dfje").GetType.ToString = "System.DBNull" Then
                rcDataset.Tables("rc_pz").Rows(i).Item("dfje") = 0.0
            End If
        Next
        rcOleDbConn.Open()
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.StoredProcedure
        Try
            '(5)��Ŀ������
            rcOleDbCommand.CommandText = "USP_CHECK_CODE"
            For i = 0 To rcDataset.Tables("rc_pz").Rows.Count - 1
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraStrCode", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("rc_pz").Rows(i).Item("kmdm"))
                rcOleDbCommand.Parameters.Add("@paraStrTable", OleDbType.VarChar, 30).Value = "gl_kmxx"
                rcOleDbCommand.Parameters.Add("@paraStrField", OleDbType.VarChar, 30).Value = "kmdm"
                rcOleDbCommand.Parameters.Add("@paraStrCondition", OleDbType.VarChar, 100).Value = ""
                rcOleDbCommand.Parameters.Add("@paraIntRecordCount", OleDbType.Integer, 1).Direction = ParameterDirection.ReturnValue
                rcOleDbCommand.ExecuteNonQuery()
                If rcOleDbCommand.Parameters.Item("@paraIntRecordCount").Value <> 1 Then
                    MsgBox(Trim(rcDataset.Tables("rc_pz").Rows(i).Item("kmdm")) & "��Ŀ���벻��ȷ�����顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                    Return
                End If
            Next
        Catch ex As Exception
            Try
                MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Catch ey As OleDbException
                MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '(6)���ݺų��ȼ��
        If Trim(Me.TxtDjh.Text).Length <> 15 Then
            MsgBox("���ݺų��Ȳ���ȷ�����顣", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
            Return
        End If

        '�洢ƾ֤
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.StoredProcedure
            rcOleDbCommand.CommandText = "USP3_SAVE_GL_PZ"
            For i = 0 To rcDataset.Tables("rc_pz").Rows.Count - 1
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = IIf(IsAdding, 1, 0)
                rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = Trim(Me.TxtDjh.Text)
                rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = i + 1
                rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = IIf(String.IsNullOrEmpty(Me.LblBdelete.Text), 0, 1)
                rcOleDbCommand.Parameters.Add("@paraDatePzrq", OleDbType.Date, 8).Value = Me.DtpPzrq.Value
                rcOleDbCommand.Parameters.Add("@paraIntFjzs", OleDbType.Integer, 4).Value = Trim(Me.TxtFjzs.Text)
                If rcDataset.Tables("rc_pz").Rows(i).Item("jfje").GetType.ToString <> "System.DBNull" And rcDataset.Tables("rc_pz").Rows(i).Item("jfje") <> 0 Then
                    rcOleDbCommand.Parameters.Add("@paraStrJd", OleDbType.Char, 2).Value = "��"
                Else
                    rcOleDbCommand.Parameters.Add("@paraStrJd", OleDbType.Char, 2).Value = "��"
                End If
                rcOleDbCommand.Parameters.Add("@paraStrZy", OleDbType.VarChar, 50).Value = Trim(rcDataset.Tables("rc_pz").Rows(i).Item("zy"))
                rcOleDbCommand.Parameters.Add("@paraStrKmdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("rc_pz").Rows(i).Item("kmdm")
                rcOleDbCommand.Parameters.Add("@paraStrKmmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("rc_pz").Rows(i).Item("kmmc")
                rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rc_pz").Rows(i).Item("bmdm")
                rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("rc_pz").Rows(i).Item("bmmc")
                rcOleDbCommand.Parameters.Add("@paraStrZydm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rc_pz").Rows(i).Item("bmdm")
                rcOleDbCommand.Parameters.Add("@paraStrZymc", OleDbType.VarChar, 30).Value = rcDataset.Tables("rc_pz").Rows(i).Item("bmmc")
                rcOleDbCommand.Parameters.Add("@paraStrXmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rc_pz").Rows(i).Item("xmdm")
                rcOleDbCommand.Parameters.Add("@paraStrXmmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("rc_pz").Rows(i).Item("xmmc")
                rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rc_pz").Rows(i).Item("khdm")
                rcOleDbCommand.Parameters.Add("@paraStrKhmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("rc_pz").Rows(i).Item("khmc")
                rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rc_pz").Rows(i).Item("csdm")
                rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("rc_pz").Rows(i).Item("csmc")
                rcOleDbCommand.Parameters.Add("@paraStrYhzh", OleDbType.VarChar, 12).Value = rcDataset.Tables("rc_pz").Rows(i).Item("yhzh")
                rcOleDbCommand.Parameters.Add("@paraStrJxzh", OleDbType.VarChar, 12).Value = rcDataset.Tables("rc_pz").Rows(i).Item("jxzh")
                rcOleDbCommand.Parameters.Add("@paraStrDwmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("rc_pz").Rows(i).Item("dwmc")
                rcOleDbCommand.Parameters.Add("@paraStrDfkm", OleDbType.VarChar, 30).Value = rcDataset.Tables("rc_pz").Rows(i).Item("dfkm")
                rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = rcDataset.Tables("rc_pz").Rows(i).Item("dw")
                rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_pz").Rows(i).Item("sl")
                rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_pz").Rows(i).Item("dj")
                rcOleDbCommand.Parameters.Add("@paraStrBz", OleDbType.VarChar, 8).Value = rcDataset.Tables("rc_pz").Rows(i).Item("bz")
                rcOleDbCommand.Parameters.Add("@paraDblWb", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_pz").Rows(i).Item("wb")
                rcOleDbCommand.Parameters.Add("@paraDblHl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rc_pz").Rows(i).Item("hl")
                If rcDataset.Tables("rc_pz").Rows(i).Item("jfje").GetType.ToString <> "System.DBNull" And rcDataset.Tables("rc_pz").Rows(i).Item("jfje") <> 0 Then
                    rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_pz").Rows(i).Item("jfje")
                Else
                    rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rc_pz").Rows(i).Item("dfje")
                End If
                rcOleDbCommand.Parameters.Add("@paraStrYspz", OleDbType.VarChar, 16).Value = Trim(rcDataset.Tables("rc_pz").Rows(i).Item("yspz"))
                rcOleDbCommand.Parameters.Add("@paraStrJsr", OleDbType.VarChar, 30).Value = Trim(rcDataset.Tables("rc_pz").Rows(i).Item("jsr"))
                rcOleDbCommand.Parameters.Add("@paraDateWldqr", OleDbType.Date, 8).Value = rcDataset.Tables("rc_pz").Rows(i).Item("wldqr")
                rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                rcOleDbCommand.Parameters.Add("@paraStrMsg", OleDbType.VarChar, 200).Direction = ParameterDirection.Output
                rcOleDbCommand.ExecuteNonQuery()
                If rcOleDbCommand.Parameters("@paraStrMsg").Value.GetType.ToString <> "System.DBNull" Then
                    If rcOleDbCommand.Parameters("@paraStrMsg").Value <> "" Then
                        MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "��ʾ��Ϣ")
                        Return
                    End If
                End If
                If rcOleDbCommand.Parameters("@paraStrDjh").Value.GetType.ToString <> "System.DBNull" Then
                    If rcOleDbCommand.Parameters("@paraStrDjh").Value <> "" Then
                        Me.TxtDjh.Text = Trim(rcOleDbCommand.Parameters("@paraStrDjh").Value)
                    End If
                End If
            Next
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("�������USP3_SAVE_GL_PZ" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Catch ey As OleDbException
                MsgBox("�������" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If blnPrint Then
            'Print()
        End If

        IsAdding = False
        IsEditing = False
        '�µ��ݺ�
        NewEvent()
        '�ؼ�����
        SetControlEnableEvent()
        '���ý���
        Me.TxtDjh.Focus()
    End Sub

#End Region

#Region "ȡ���޸��¼�"

    Private Sub BtnCancelEvent(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click, MnuiCancel.Click
        If MsgBox("�Ƿ�����������޸ģ�", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "��ʾ��Ϣ") = MsgBoxResult.Yes Then
            IsAdding = False
            IsEditing = False
            NewEvent()
            SetControlEnableEvent()
            Me.TxtDjh.Focus()
        End If
    End Sub

#End Region

#Region "�������¼�"

    Private Sub BtnIns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIns.Click, MnuiIns.Click
        If Me.rcDataGridView.ReadOnly = False Then
            If dtPz.Rows.Count > 0 Then
                Dim row As DataRow = dtPz.NewRow
                dtPz.Rows.InsertAt(row, rcDataGridView.CurrentCell.RowIndex)
                dtPz.AcceptChanges()
            End If
        End If
    End Sub

#End Region

#Region "ɾ��DataGridView���¼�"

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        DeleteEvent()
    End Sub

    Private Sub MnuiDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiDelete.Click
        DeleteEvent()
    End Sub

    Private Sub DeleteEvent()
        If Me.rcDataGridView.ReadOnly = False Then
            If rcDataset.Tables("rc_pz").Rows.Count > 0 Then
                rcDataset.Tables("rc_pz").Rows(rcDataGridView.CurrentRow.Index).Delete()
                rcDataset.Tables("rc_pz").AcceptChanges()
                IsEditing = True
                SetControlEnableEvent()
            End If
        End If
    End Sub
#End Region

#Region "��ӡ�¼�"

    Private Sub PageSetupEvent()
        Dim rcFrmPageSetup As New models.FrmPageSetup
        With rcFrmPageSetup
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = "GLPZBZ"
            .paraRpsName = "����ƾ֤"
            .ShowDialog()
        End With
    End Sub

    Private Sub PrintEvent()
        If g_Demo = 1 Then
            MsgBox("�Բ�������������ܴ�ӡ��", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Return
        End If
        PreparePrintData()
        Dim rcFrmPrint As New models.FrmPrint
        With rcFrmPrint
            .ParaRps = rcRps
            .ShowDialog()
        End With
    End Sub

    Private Sub PrintViewEvent()
        PreparePrintData()
        rcRps.Preview()
    End Sub

    Private Sub PreparePrintData()
        If rcRps Is Nothing Then
            rcRps = New RPS.Document
        End If
        'Dim rft1 As String = Application.StartupPath + "\reports\glpzbz.csv"
        Dim rft As String = Application.StartupPath + "\reports\glpzbz.rft"
        'rcRps.LoadCsvTemplate(rft1)
        'rcRps.SaveTemplate(rft)
        rcRps.LoadTemplate(rft)
        'ȡRPS����
        rcOleDbConn.Open()
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT * FROM rc_rps where rpsid = 'GLPZBZ'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_rps") IsNot Nothing Then
                rcDataset.Tables("rc_rps").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_rps")
        Catch ex As Exception
            Try
                MsgBox("�������" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            Catch ey As OleDbException
                MsgBox("�������" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_rps").Rows.Count > 0 Then
            '�趨ֵ
            rcRps.Scale = rcDataset.Tables("rc_rps").Rows(0).Item("scale")
            rcRps.Orientation = rcDataset.Tables("rc_rps").Rows(0).Item("orientation")
            rcRps.PaperWidth = rcDataset.Tables("rc_rps").Rows(0).Item("paperwidth")
            rcRps.PaperHeight = rcDataset.Tables("rc_rps").Rows(0).Item("paperheight")
            rcRps.PrinterLeft = rcDataset.Tables("rc_rps").Rows(0).Item("printerleft")
            rcRps.PrinterTop = rcDataset.Tables("rc_rps").Rows(0).Item("printertop")
        Else
            'Ĭ��ֵ
            rcRps.Scale = 100
            rcRps.Orientation = 1
        End If
        '�״�
        'rcRps.PaperType = 1
        rcRps.Text(-1, 1) = "����ƾ֤"
        rcRps.Text(-1, 2) = "���ڣ�" & Me.DtpPzrq.Value.Date.ToLongDateString
        rcRps.Text(-1, 3) = "�� �� �ţ�" & Trim(Me.TxtDjh.Text)
        Dim i As Integer
        Dim j As Integer
        Dim dblTotalJe As Double = 0.0
        For i = 0 To rcDataSet.Tables("rc_pz").Rows.Count - 1
            If rcDataSet.Tables("rc_pz").Rows(i).RowState <> 8 Then
                If Not rcDataSet.Tables("rc_pz").Rows(i).Item("kmdm").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 1) = Trim(rcDataSet.Tables("rc_pz").Rows(i).Item("kmdm"))
                End If
                If Not rcDataSet.Tables("rc_pz").Rows(i).Item("kmmc").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 2) = Trim(rcDataSet.Tables("rc_pz").Rows(i).Item("kmmc"))
                End If
                If Not rcDataSet.Tables("rc_pz").Rows(i).Item("wbdm").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 3) = Trim(rcDataSet.Tables("rc_pz").Rows(i).Item("wbdm"))
                End If
                If Not rcDataSet.Tables("rc_pz").Rows(i).Item("dw").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 4) = Trim(rcDataSet.Tables("rc_pz").Rows(i).Item("dw"))
                End If
                If Not rcDataSet.Tables("rc_pz").Rows(i).Item("sl").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 5) = Format(rcDataSet.Tables("rc_pz").Rows(i).Item("sl"), g_FormatSl)
                End If
                If Not rcDataSet.Tables("rc_pz").Rows(i).Item("dj").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 6) = Format(rcDataSet.Tables("rc_pz").Rows(i).Item("dj"), g_FormatDj)
                End If
                If Not rcDataSet.Tables("rc_pz").Rows(i).Item("je").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 7) = Format(rcDataSet.Tables("rc_pz").Rows(i).Item("je"), g_FormatJe)
                    dblTotalJe += rcDataSet.Tables("rc_pz").Rows(i).Item("je")
                End If
                If Not rcDataSet.Tables("rc_pz").Rows(i).Item("rkmemo").GetType.ToString = "System.DBNull" Then
                    rcRps.Text(j + 1, 8) = Trim(rcDataSet.Tables("rc_pz").Rows(i).Item("rkmemo"))
                End If
                j += 1
            End If
        Next
        If Decimal.op_Modulus(rcDataSet.Tables("rc_pz").Rows.Count, rcRps.LinesPerPage.ToString) <> 0 Then
            For i = Decimal.op_Modulus(rcDataSet.Tables("rc_pz").Rows.Count, rcRps.LinesPerPage.ToString) + 1 To rcRps.LinesPerPage.ToString
                rcRps.Text(j + 1, 1) = ""
                j += 1
            Next
        End If

        Dim m As New models.ChineseNum With {
            .InputString = dblTotalJe
        }
        rcRps.Text(-1, 8) = m.OutString '��д
        rcRps.Text(-1, 9) = Format(dblTotalJe, g_FormatJe)
        rcRps.Text(-1, 11) = "���ϣ�" & g_User_DspName
    End Sub

    Private Sub MnuiPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrint.Click, BtnPrint.Click
        PrintEvent()
    End Sub

    Private Sub MnuiPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPageSetup.Click
        PageSetupEvent()
    End Sub

    Private Sub MnuiPrintView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiPrintView.Click, BtnPrintView.Click
        PrintViewEvent()
    End Sub

#End Region

#Region "�˳����¼�"

    Private Sub BtnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExit.Click, MnuiExit.Click
        Me.Close()
    End Sub

    Private Sub FrmGlPzSrz_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If IsEditing Then
            MsgBox("�Ѿ��༭�����ݣ��뱣�����ݡ�", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "��ʾ��Ϣ")
            e.Cancel = True
        End If
    End Sub

#End Region
End Class