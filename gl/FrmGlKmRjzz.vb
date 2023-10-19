Imports System.Data.OleDb
Public Class FrmGlKmRjzz

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

    Private Sub FrmKmRjzz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.DataGridView1.Columns("ColJfje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridView1.Columns("ColJfje").DefaultCellStyle.Format = g_FormatJe0
        Me.DataGridView1.Columns("ColDfje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridView1.Columns("ColDfje").DefaultCellStyle.Format = g_FormatJe0
        Me.DataGridView1.Columns("ColYe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridView1.Columns("ColYe").DefaultCellStyle.Format = g_FormatJe0

        Me.DataGridView1.DataSource = ParaDataView
    End Sub

#End Region

#Region "关闭事件"

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

#End Region

End Class