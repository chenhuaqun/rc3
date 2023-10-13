Imports System.Data.OleDb
Imports System.IO

Public Class FrmUpdateDB

#Region "定义变量"
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
#End Region

    Private Sub FrmUpdateDB_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.TxtPath.Text = My.Computer.FileSystem.SpecialDirectories.Desktop
    End Sub

    Private Sub BtnFbd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFbd.Click
        If Me.rcFolderBrowserDialog.ShowDialog() = DialogResult.OK Then
            Me.TxtPath.Text = Me.rcFolderBrowserDialog.SelectedPath
        End If
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        '0）定义变量
        Dim rcStreamReader As StreamReader
        Dim rcFileName As String

        '1）表、视图

        '2）索引
        '3）存储过程、函数

        '4）rcsystem表
        '5）索引
        '6）


        '系统－RC3菜单
        rcFileName = Me.TxtPath.Text + "\rc3_menu.sql"
        Me.LblMsg.Text = "正在执行的脚本文件是：" & rcFileName
        If System.IO.File.Exists(rcFileName) Then
            rcStreamReader = System.IO.File.OpenText(rcFileName)
            Me.TxtSql.Text = rcStreamReader.ReadToEnd
            rcStreamReader.Close()
            Try
                sysOleDbConn.Open()
                rcOleDbCommand.Connection = sysOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = Trim(Me.TxtSql.Text)
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("程序错误rc3_menu.sql" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                sysOleDbConn.Close()
            End Try
            Me.TxtSql.Text = ""
        End If

        '帐套－产品送货单存储过程
        rcFileName = Me.TxtPath.Text + "\USP3_SAVE_OE_XSD.sql"
        Me.LblMsg.Text = "正在执行的脚本文件是：" & rcFileName
        If System.IO.File.Exists(rcFileName) Then
            rcStreamReader = System.IO.File.OpenText(rcFileName)
            Me.TxtSql.Text = rcStreamReader.ReadToEnd
            rcStreamReader.Close()
            Try
                '
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = Trim(Me.TxtSql.Text)
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("程序错误rc3_menu.sql" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            Me.TxtSql.Text = ""
        End If
    End Sub
End Class