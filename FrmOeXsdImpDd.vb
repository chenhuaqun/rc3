Imports System.Data.OleDb

Public Class FrmOeXsdImpDd

#Region "定义变量"

    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    Dim rcDataset As New DataSet
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    Dim strKhdm As String = ""

#End Region

    Public Property ParaStrKhdm() As String
        Get
            ParaStrKhdm = strKhdm
        End Get
        Set(ByVal Value As String)
            strKhdm = Value
        End Set
    End Property

    Overloads Property ParaDataSet() As DataSet
        Get
            ParaDataSet = rcDataset
        End Get
        Set(ByVal Value As DataSet)
            rcDataset = Value
        End Set
    End Property

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Dim i As Integer
        For i = 0 To rcDataSet.Tables("rc_xsdref").Rows.Count - 1
            If rcDataSet.Tables("rc_xsdref").Rows(i).Item("xz") Then
                Dim rcDataRow As DataRow
                rcDataRow = rcDataSet.Tables("rc_xsdnr").NewRow
                rcDataRow.Item("cpdm") = rcDataSet.Tables("rc_xsdref").Rows(i).Item("cpdm")
                rcDataRow.Item("cpmc") = rcDataSet.Tables("rc_xsdref").Rows(i).Item("cpmc")
                rcDataRow.Item("hth") = rcDataSet.Tables("rc_xsdref").Rows(i).Item("hth")
                rcDataRow.Item("khddh") = rcDataSet.Tables("rc_xsdref").Rows(i).Item("khddh")
                rcDataRow.Item("khlh") = rcDataSet.Tables("rc_xsdref").Rows(i).Item("khlh")
                rcDataRow.Item("sl") = rcDataSet.Tables("rc_xsdref").Rows(i).Item("sl")
                rcDataRow.Item("dw") = rcDataSet.Tables("rc_xsdref").Rows(i).Item("dw")
                rcDataRow.Item("mjsl") = rcDataSet.Tables("rc_xsdref").Rows(i).Item("mjsl")
                rcDataRow.Item("fzsl") = rcDataSet.Tables("rc_xsdref").Rows(i).Item("fzsl")
                rcDataRow.Item("fzdw") = rcDataSet.Tables("rc_xsdref").Rows(i).Item("fzdw")
                rcDataRow.Item("dj") = rcDataSet.Tables("rc_xsdref").Rows(i).Item("dj")
                rcDataRow.Item("hsdj") = rcDataSet.Tables("rc_xsdref").Rows(i).Item("hsdj")
                rcDataRow.Item("je") = rcDataSet.Tables("rc_xsdref").Rows(i).Item("je")
                rcDataRow.Item("shlv") = rcDataSet.Tables("rc_xsdref").Rows(i).Item("shlv")
                rcDataRow.Item("se") = rcDataSet.Tables("rc_xsdref").Rows(i).Item("se")
                rcDataRow.Item("jese") = rcDataSet.Tables("rc_xsdref").Rows(i).Item("jese")
                rcDataRow.Item("xsmemo") = rcDataSet.Tables("rc_xsdref").Rows(i).Item("xsmemo")
                rcDataRow.Item("dddjh") = rcDataSet.Tables("rc_xsdref").Rows(i).Item("dddjh")
                rcDataRow.Item("ddxh") = rcDataSet.Tables("rc_xsdref").Rows(i).Item("ddxh")
                rcDataSet.Tables("rc_xsdnr").Rows.Add(rcDataRow)
            End If
        Next
        Me.Close()
    End Sub

    Private Sub FrmOeXsdReference_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '设置DataGridView
        Me.rcDataGridView.AutoGenerateColumns = False
        Me.rcDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColSl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColMjsl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColMjsl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColFzsl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColFzsl").DefaultCellStyle.Format = g_FormatSl
        Me.rcDataGridView.Columns("ColDj").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColDj").DefaultCellStyle.Format = g_FormatDj
        Me.rcDataGridView.Columns("ColHsdj").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColHsdj").DefaultCellStyle.Format = g_FormatDj
        Me.rcDataGridView.Columns("ColJe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColJe").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColShlv").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColShlv").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColSe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColSe").DefaultCellStyle.Format = g_FormatJe
        Me.rcDataGridView.Columns("ColJese").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.rcDataGridView.Columns("ColJese").DefaultCellStyle.Format = g_FormatJe
        If rcDataSet.Tables("rc_xsdref") IsNot Nothing Then
            rcDataSet.Tables("rc_xsdref").Clear()
        End If
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT 0 AS xz,oe_dd.djh AS dddjh,oe_dd.xh AS ddxh,oe_dd.cpdm,rc_cpxx.cpmc,oe_dd.hth,oe_dd.khddh,oe_dd.khlh,oe_dd.scjhrq,oe_dd.sl - oe_dd.hxsl - oe_dd.cksl AS sl,rc_cpxx.dw,oe_dd.mjsl,(oe_dd.sl - oe_dd.hxsl - oe_dd.cksl) / oe_dd.sl * oe_dd.fzsl AS fzsl,rc_cpxx.fzdw,oe_dd.dj,oe_dd.hsdj,ROUND(oe_dd.hsdj * (oe_dd.sl - oe_dd.hxsl - oe_dd.cksl)/(1 + oe_dd.shlv / 100),2) AS je,oe_dd.shlv,ROUND(oe_dd.hsdj / (1 + oe_dd.shlv / 100) * (oe_dd.sl - oe_dd.hxsl - oe_dd.cksl) * oe_dd.shlv /100,2) AS se,ROUND(oe_dd.hsdj / (1 + oe_dd.shlv / 100) * (oe_dd.sl - oe_dd.hxsl - oe_dd.cksl),2) + ROUND(oe_dd.hsdj / (1 + oe_dd.shlv / 100) * (oe_dd.sl - oe_dd.hxsl - oe_dd.cksl) * oe_dd.shlv /100,2) AS jese,oe_dd.ddmemo AS xsmemo,oe_dd.ddmemo AS xsmemo FROM oe_dd,rc_cpxx WHERE oe_dd.cpdm = rc_cpxx.cpdm AND ((oe_dd.sl - oe_dd.hxsl - oe_dd.cksl > 0 AND oe_dd.sl > 0) OR (oe_dd.sl - oe_dd.hxsl - oe_dd.cksl < 0 AND oe_dd.sl < 0)) AND oe_dd.bclosed  = 0 AND NOT oe_dd.shr IS NULL AND oe_dd.khdm = ? ORDER BY oe_dd.djh,oe_dd.xh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = strKhdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_xsdref") IsNot Nothing Then
                Me.rcDataSet.Tables("rc_xsdref").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_xsdref")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        Finally
            rcOleDbConn.Close()
        End Try
        '绑定数据the DataGrid to the DataSet.
        Me.rcBindingSource.DataSource = Me.rcDataSet.Tables("rc_xsdref")
        Me.rcDataGridView.DataSource = Me.rcBindingSource
    End Sub
End Class