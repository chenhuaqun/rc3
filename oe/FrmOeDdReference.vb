Imports System.Data.OleDb

Public Class FrmOeDdReference

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

    Private Sub FrmOeDdReference_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If rcDataSet.Tables("rc_ddref") IsNot Nothing Then
            rcDataSet.Tables("rc_ddref").Clear()
        End If

        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            'rcOleDbCommand.CommandText = "SELECT 0 AS xz,oe_dd.cpdm,rc_cpxx.cpmc,rc_cpxx.dw,MIN(dj) AS dj,COUNT(1) AS cntcs FROM oe_dd,rc_cpxx WHERE oe_dd.cpdm = rc_cpxx.cpdm AND oe_dd.sl <> oe_dd.hxsl AND oe_dd.khdm = ? GROUP BY oe_dd.cpdm,rc_cpxx.cpmc,rc_cpxx.dw"
            rcOleDbCommand.CommandText = "SELECT 0 AS xz,a.cpdm,a.cpmc,a.dw,a.dj,a.hsdj,a.shlv FROM oe_dd a WHERE NOT EXISTS (SELECT 1 FROM oe_dd b WHERE a.cpdm = b.cpdm AND a.qdrq < b.qdrq) AND a.khdm = ? ORDER BY a.cpdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = strKhdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_ddref") IsNot Nothing Then
                Me.rcDataSet.Tables("rc_ddref").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_ddref")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        Finally
            rcOleDbConn.Close()
        End Try
        '绑定数据the DataGrid to the DataSet.
        Me.rcBindingSource.DataSource = Me.rcDataSet.Tables("rc_ddref")
        Me.rcDataGridView.DataSource = Me.rcBindingSource
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Dim i As Integer
        For i = 0 To rcDataSet.Tables("rc_ddref").Rows.Count - 1
            If rcDataSet.Tables("rc_ddref").Rows(i).Item("xz") Then
                Dim rcDataRow As DataRow
                rcDataRow = rcDataSet.Tables("rc_ddnr").NewRow
                rcDataRow.Item("cpdm") = rcDataSet.Tables("rc_ddref").Rows(i).Item("cpdm")
                rcDataRow.Item("cpmc") = rcDataSet.Tables("rc_ddref").Rows(i).Item("cpmc")
                rcDataRow.Item("dw") = rcDataSet.Tables("rc_ddref").Rows(i).Item("dw")
                rcDataRow.Item("dj") = rcDataSet.Tables("rc_ddref").Rows(i).Item("dj")
                rcDataRow.Item("hsdj") = rcDataSet.Tables("rc_ddref").Rows(i).Item("hsdj")
                rcDataRow.Item("shlv") = rcDataSet.Tables("rc_ddref").Rows(i).Item("shlv")
                rcDataSet.Tables("rc_ddnr").Rows.Add(rcDataRow)
            End If
        Next
        Me.Close()
    End Sub
End Class