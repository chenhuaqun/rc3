Imports System.Data.OleDb
Imports System.Math

Public Class FrmGlPzSrz

#Region "定义变量"

    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '建立Datatable
    ReadOnly dtPz As New DataTable("rc_pz")
    '年
    Dim strYear As String = ""
    '月
    Dim strMonth As String = ""
    '会计期间
    Dim strKjqj As String = g_Kjqj
    '增加单据的变量
    Dim IsAdding As Boolean = False
    '修改单据的变量
    Dim IsEditing As Boolean = False
    'DataGridViewTextBoxEditingControl
    Dim EditingControl As DataGridViewTextBoxEditingControl
    '打印文档
    Dim rcRps As RPS.Document = Nothing

#End Region

#Region "初始化"

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
        '设置DataGridView
        Me.rcDataGridView.AutoGenerateColumns = False
        Me.rcDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.rcDataGridView.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))

        Me.rcDataGridView.Columns("ColJfje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColJfje").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColDfje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColDfje").DefaultCellStyle.Format = g_FormatJe
        Try
            '取单据类型数据
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT pzlxdm,pzlxjc From rc_lx Where lxgs = '记账凭证' AND kjnd = '" & strYear & "' ORDER BY pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_lx") IsNot Nothing Then
                Me.rcDataSet.Tables("rc_lx").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_lx")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("rc_lx").Rows.Count = 0 Then
            MsgBox("请定义单据类型。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        '绑定凭证类型简称
        BindDropDownList(CmbPzlxjc, rcDataSet.Tables("rc_lx"), "pzlxdm", "pzlxjc")
        '数据绑定
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
        '绑定数据the DataGrid to the DataSet.
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

#Region "设置控件"

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

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbPzlxjc.KeyPress, TxtDjh.KeyPress, DtpPzrq.KeyPress, TxtFjzs.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
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

#Region "凭证类型的事件"

    Private Sub CmbPzlxjc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbPzlxjc.Validated
        ShowNewDjh()
    End Sub

#End Region

#Region "凭证号的事件"

    Private Sub TxtDjh_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDjh.KeyDown
        Select Case e.KeyCode
            Case Keys.F7
                '删除最后一张单据
                '1.如果正在增加单据则返回
                If IsAdding Then
                    Return
                End If
                '2.删除
                If MsgBox("是否要删除最后一张单据？", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "提示信息") = MsgBoxResult.Ok Then
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
                                MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                                Return
                            End If
                        End If
                        rcOleDbTrans.Commit()
                    Catch ex As Exception
                        Try
                            rcOleDbTrans.Rollback()
                            MsgBox("执行存储过程发生了错误：" & rcOleDbCommand.Parameters("@paraIntError").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                        Catch ey As OleDbException
                            MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        End Try
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                Else
                    Return
                End If
                '3.显示新单据
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
        '检查单据号是否存在
        If rcDataSet.Tables("rc_pzno") Is Nothing Then
            Return
        End If
        rcOleDbConn.Open()
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            '判断增加还是修改
            If rcDataSet.Tables("rc_pzno").Rows.Count > 0 Then
                If rcDataSet.Tables("rc_pzno").Rows(0).Item("pzno") >= Mid(Trim(Me.TxtDjh.Text), 11, 5) Then
                    '修改单据
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
                            MsgBox("该单据已经记账，不能修改。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                            IsAdding = True
                        Else
                            If rcDataSet.Tables("pzml").Rows(0).Item("shr").GetType.ToString <> "System.DBNull" Then
                                MsgBox("该单据已经审核，不能修改。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                                IsAdding = True
                            Else
                                Me.DtpPzrq.Value = rcDataSet.Tables("pzml").Rows(0).Item("pzrq")
                                Me.TxtFjzs.Text = rcDataSet.Tables("pzml").Rows(0).Item("fjzs")
                                Me.LblBdelete.Text = IIf(rcDataSet.Tables("pzml").Rows(0).Item("bdelete"), "作废", "")
                                '修改单据
                                rcOleDbCommand.CommandText = "SELECT gl_pz.xh,gl_pz.zy,gl_pz.kmdm,gl_pz.kmmc,gl_pz.bmdm,gl_pz.bmmc,gl_pz.xmdm,gl_pz.xmmc,gl_pz.khdm,gl_pz.khmc,gl_pz.csdm,gl_pz.csmc,gl_pz.yhzh,gl_pz.jxzh,gl_pz.dwmc,gl_pz.sl,gl_pz.dj,gl_pz.wb,gl_pz.hl,Case When jd = '借' Then je Else 0 End As jfje,Case When jd = '贷' Then je Else 0 End As dfje FROM gl_pz Where (gl_pz.djh = ?) ORDER BY gl_pz.xh"
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
                    '新增单据
                    IsAdding = True
                End If
            End If
        Catch ex As Exception
            Try
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
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

#Region "凭证日期事件"

    Private Sub DtpPzrq_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpPzrq.Validated
        If strKjqj <> getInvKjqj(Me.DtpPzrq.Value) Then
            MsgBox("所选日期，不属于当前会计期间。请更正。", MsgBoxStyle.OkOnly)
            Me.DtpPzrq.Focus()
        End If
    End Sub

#End Region

#Region "附件张数事件"

    Private Sub TxtFjzs_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFjzs.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

#End Region

#Region "DataGridView事件"

    Private Sub RcDataGridView_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles rcDataGridView.CellValidating
        If Me.rcDataGridView.CurrentRow.IsNewRow = False Then
            If Me.rcDataGridView.IsCurrentCellDirty Then
                Me.rcDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColKmdm" Then
                If Not String.IsNullOrEmpty(e.FormattedValue) Then
                    '取科目名称
                    rcOleDbConn.Open()
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    Try
                        '取gl_kmxx
                        rcOleDbCommand.CommandText = "SELECT * FROM gl_kmxx WHERE kmdm = ? And Not Exists (Select 1 From gl_kmxx parentkm Where parentkm.parentid = gl_kmxx.kmdm)"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.AddWithValue("@kmdm", rcDataGridView.Rows(rcDataGridView.CurrentRow.Index).Cells("ColKmdm").EditedFormattedValue)
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataSet.Tables("gl_kmxx") IsNot Nothing Then
                            rcDataSet.Tables("gl_kmxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataSet, "gl_kmxx")
                    Catch ex As Exception
                        MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                    If rcDataSet.Tables("gl_kmxx").Rows.Count > 0 Then
                        '是否为明细科目
                        Me.rcDataGridView.CurrentRow.Cells("ColKmmc").Value = rcDataSet.Tables("gl_kmxx").Rows(0).Item("kmmc")
                        '部门核算
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
                        '客户核算
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
                        '供应商核算
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
                        '项目核算
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
                        '外币
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
                        '数量
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
                        Me.LblMsg.Text = "科目编码非末级科目或科目编码不存在。"
                        e.Cancel = True
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColBmdm" Then
                If Not String.IsNullOrEmpty(e.FormattedValue) Then
                    '取科目名称
                    rcOleDbConn.Open()
                    rcOleDbCommand.Connection = rcOleDbConn
                    rcOleDbCommand.CommandTimeout = 300
                    rcOleDbCommand.CommandType = CommandType.Text
                    Try
                        '取dwdb
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
                            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        Catch ey As OleDbException
                            MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        End Try
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                    If rcDataSet.Tables("gl_bmxx").Rows.Count > 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColBmdm").Value = rcDataSet.Tables("gl_bmxx").Rows(0).Item("bmdm")
                        Me.rcDataGridView.CurrentRow.Cells("ColBmmc").Value = rcDataSet.Tables("gl_bmxx").Rows(0).Item("bmmc")
                    Else
                        Me.LblMsg.Text = "部门编码不存在。"
                        e.Cancel = True
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColKhdm" Then
                If Not String.IsNullOrEmpty(e.FormattedValue) Then
                    '取客户名称
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
                            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        Catch ey As OleDbException
                            MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        End Try
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                    If rcDataSet.Tables("rc_khxx").Rows.Count > 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColKhdm").Value = rcDataSet.Tables("rc_khxx").Rows(0).Item("khdm")
                        Me.rcDataGridView.CurrentRow.Cells("ColKhmc").Value = rcDataSet.Tables("rc_khxx").Rows(0).Item("khmc")
                    Else
                        Me.LblMsg.Text = "客户编码不存在。"
                        e.Cancel = True
                    End If
                End If
            End If
            If Me.rcDataGridView.Columns(e.ColumnIndex).Name = "ColCsdm" Then
                If Not String.IsNullOrEmpty(e.FormattedValue) Then
                    '取客户名称
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
                            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        Catch ey As OleDbException
                            MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                        End Try
                        Return
                    Finally
                        rcOleDbConn.Close()
                    End Try
                    If rcDataSet.Tables("rc_csxx").Rows.Count > 0 Then
                        Me.rcDataGridView.CurrentRow.Cells("ColCsdm").Value = rcDataSet.Tables("rc_csxx").Rows(0).Item("csdm")
                        Me.rcDataGridView.CurrentRow.Cells("ColCsmc").Value = rcDataSet.Tables("rc_csxx").Rows(0).Item("csmc")
                    Else
                        Me.LblMsg.Text = "客户编码不存在。"
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
                '复制
                Clipboard.SetDataObject(Me.rcDataGridView.GetClipboardContent())
            Case Keys.V And e.Control
                '粘贴
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
                        .paraTitle = "科目"
                        .paraOldValue = ""
                        .paraAddName = ""
                        .paraCondition = ""
                        If .ShowDialog = DialogResult.OK Then
                            '将用户在rcfrmselectkmdm所选择的kmdm带入rcdataridView'
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
                        .paraTitle = "部门"
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
                        .paraTitle = "客户"
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
        '                .paraTitle = "供应商"
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
                        .paraTitle = "科目"
                        .paraOldValue = ""
                        .paraAddName = ""
                        .paraCondition = ""
                        If .ShowDialog = DialogResult.OK Then
                            '将用户在rcfrmselectkmdm所选择的kmdm带入rcdatarid'
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
                        .paraTitle = "部门"
                        .paraOldValue = ""
                        .paraAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            '将用户在FrmF3KeyPress所选择的bmdm带入rcdatarid'
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
                        .paraTitle = "客户"
                        .paraOldValue = ""
                        .paraAddName = ""
                        If .ShowDialog = DialogResult.OK Then
                            '将用户在FrmF3KeyPress所选择的bmdm带入rcdatarid'
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
        '                .paraTitle = "供应商"
        '                .paraOldValue = ""
        '                .paraAddName = ""
        '                If .ShowDialog = DialogResult.OK Then
        '                    '将用户在FrmF3KeyPress所选择的bmdm带入rcdatarid'
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
        '当键入ESC时清除当前行的错误提示Clear the row error in case the user presses ESC.   
        Me.rcDataGridView.Rows(e.RowIndex).ErrorText = String.Empty
        Me.LblMsg.Text = ""
    End Sub

#End Region

#Region "新单事件"

    Private Sub MnuiNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuiNew.Click, BtnNew.Click
        NewEvent()
    End Sub

    Private Sub NewEvent()
        '清空数据
        Me.LblBdelete.Text = ""
        Me.TxtFjzs.Text = 1
        Me.TxtJfje.Text = ""
        Me.TxtDfje.Text = ""
        Me.LblMsg.Text = ""
        Me.LblJe.Text = "合计金额："
        '显示新单据号
        ShowNewDjh()
        IsAdding = True
        IsEditing = False
        '清空数据
        If rcDataSet.Tables("rc_pz") IsNot Nothing Then
            rcDataSet.Tables("rc_pz").Clear()
        End If
    End Sub

    Private Sub ShowNewDjh()
        '取单据类型数据
        rcOleDbConn.Open()
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            rcOleDbCommand.CommandText = "SELECT pzno" & strMonth & " as pzno From rc_lx Where pzlxdm = ? AND lxgs = '记账凭证' AND kjnd = '" & strYear & "' ORDER BY pzlxdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.AddWithValue("@pzlxdm", Trim(Me.CmbPzlxjc.SelectedValue))
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_pzno") IsNot Nothing Then
                Me.rcDataSet.Tables("rc_pzno").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_pzno")
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
        If rcDataSet.Tables("rc_pzno").Rows.Count = 0 Then
            MsgBox("请定义单据类型。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        TxtDjh.Text = Trim(Me.CmbPzlxjc.SelectedValue) & strKjqj & (rcDataSet.Tables("rc_pzno").Rows(0).Item("pzno") + 1).ToString.PadLeft(5, "0")
        IsAdding = True
    End Sub

#End Region

#Region "保存单据数据事件"

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MnuiSave.Click
        SaveEvent(False)
    End Sub

    Private Sub SaveEvent(ByVal blnPrint As Boolean)
        Dim i As Integer
        '(一)数据合法性检查
        '(1)是否有需要存储的数据
        If rcDataset.Tables("rc_pz").Rows.Count = 0 Then
            MsgBox("没有相应的业务，请输入。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        '(2)厂商检查
        If Trim(TxtFjzs.Text).Length = 0 Then
            MsgBox("请输入附件张数。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
            Return
        End If
        '(4)DataTable赋默认值
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
            '(5)科目编码检查
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
                    MsgBox(Trim(rcDataset.Tables("rc_pz").Rows(i).Item("kmdm")) & "科目编码不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
                    Return
                End If
            Next
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
        '(6)单据号长度检查
        If Trim(Me.TxtDjh.Text).Length <> 15 Then
            MsgBox("单据号长度不正确，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
            Return
        End If

        '存储凭证
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
                    rcOleDbCommand.Parameters.Add("@paraStrJd", OleDbType.Char, 2).Value = "借"
                Else
                    rcOleDbCommand.Parameters.Add("@paraStrJd", OleDbType.Char, 2).Value = "贷"
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
                        MsgBox(rcOleDbCommand.Parameters("@paraStrMsg").Value, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "提示信息")
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
                MsgBox("程序错误。USP3_SAVE_GL_PZ" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
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
        '新单据号
        NewEvent()
        '控件设置
        SetControlEnableEvent()
        '设置焦点
        Me.TxtDjh.Focus()
    End Sub

#End Region

#Region "取消修改事件"

    Private Sub BtnCancelEvent(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click, MnuiCancel.Click
        If MsgBox("是否放弃所做的修改？", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "提示信息") = MsgBoxResult.Yes Then
            IsAdding = False
            IsEditing = False
            NewEvent()
            SetControlEnableEvent()
            Me.TxtDjh.Focus()
        End If
    End Sub

#End Region

#Region "插入行事件"

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

#Region "删除DataGridView行事件"

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

#Region "打印事件"

    Private Sub PageSetupEvent()
        Dim rcFrmPageSetup As New models.FrmPageSetup
        With rcFrmPageSetup
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = "GLPZBZ"
            .paraRpsName = "记账凭证"
            .ShowDialog()
        End With
    End Sub

    Private Sub PrintEvent()
        If g_Demo = 1 Then
            MsgBox("对不起，试用软件不能打印。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
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
        '取RPS数据
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
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_rps").Rows.Count > 0 Then
            '设定值
            rcRps.Scale = rcDataset.Tables("rc_rps").Rows(0).Item("scale")
            rcRps.Orientation = rcDataset.Tables("rc_rps").Rows(0).Item("orientation")
            rcRps.PaperWidth = rcDataset.Tables("rc_rps").Rows(0).Item("paperwidth")
            rcRps.PaperHeight = rcDataset.Tables("rc_rps").Rows(0).Item("paperheight")
            rcRps.PrinterLeft = rcDataset.Tables("rc_rps").Rows(0).Item("printerleft")
            rcRps.PrinterTop = rcDataset.Tables("rc_rps").Rows(0).Item("printertop")
        Else
            '默认值
            rcRps.Scale = 100
            rcRps.Orientation = 1
        End If
        '套打
        'rcRps.PaperType = 1
        rcRps.Text(-1, 1) = "记账凭证"
        rcRps.Text(-1, 2) = "日期：" & Me.DtpPzrq.Value.Date.ToLongDateString
        rcRps.Text(-1, 3) = "单 据 号：" & Trim(Me.TxtDjh.Text)
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
        rcRps.Text(-1, 8) = m.OutString '大写
        rcRps.Text(-1, 9) = Format(dblTotalJe, g_FormatJe)
        rcRps.Text(-1, 11) = "收料：" & g_User_DspName
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

#Region "退出表单事件"

    Private Sub BtnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExit.Click, MnuiExit.Click
        Me.Close()
    End Sub

    Private Sub FrmGlPzSrz_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If IsEditing Then
            MsgBox("已经编辑过数据，请保存数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            e.Cancel = True
        End If
    End Sub

#End Region
End Class