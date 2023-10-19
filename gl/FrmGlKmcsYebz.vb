Imports System.Data.OleDb
Public Class FrmGlKmcsYebz

#Region "定义变量"
    '建立数据视图
    Dim rcDataView As DataView
#End Region

#Region "初始化"

    Overloads Property ParaDataView() As DataView
        Get
            ParaDataView = rcDataView
        End Get
        Set(ByVal Value As DataView)
            rcDataView = Value
        End Set
    End Property

    Private Sub FrmGlKmcsYebz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.DataGridView1.Columns("ColQcjf").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridView1.Columns("ColQcjf").DefaultCellStyle.Format = g_FormatJe0
        Me.DataGridView1.Columns("ColQcdf").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridView1.Columns("ColQcdf").DefaultCellStyle.Format = g_FormatJe0
        Me.DataGridView1.Columns("ColBqjf").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridView1.Columns("ColBqjf").DefaultCellStyle.Format = g_FormatJe0
        Me.DataGridView1.Columns("ColBqdf").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridView1.Columns("ColBqdf").DefaultCellStyle.Format = g_FormatJe0
        Me.DataGridView1.Columns("ColQmjf").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridView1.Columns("ColQmjf").DefaultCellStyle.Format = g_FormatJe0
        Me.DataGridView1.Columns("ColQmdf").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridView1.Columns("ColQmdf").DefaultCellStyle.Format = g_FormatJe0
        Me.DataGridView1.Columns("ColLjjf").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridView1.Columns("ColLjjf").DefaultCellStyle.Format = g_FormatJe0
        Me.DataGridView1.Columns("ColLjdf").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridView1.Columns("ColLjdf").DefaultCellStyle.Format = g_FormatJe0

        Me.DataGridView1.DataSource = ParaDataView
    End Sub

#End Region

#Region "关闭事件"

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

#End Region

End Class