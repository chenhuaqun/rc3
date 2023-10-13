﻿Imports System.Data.OleDb

Public Class FrmOeXsdWriteOff
    '建立OLEDB数据适配器对象
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDb传递对象
    ReadOnly rcOleDbTrans As OleDbTransaction
    '建立OleDb命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '
    Dim strDjh As String = ""
    Dim blnFp As Boolean = False

    Public Property paraStrDjh() As String
        Get
            paraStrDjh = strDjh
        End Get
        Set(ByVal Value As String)
            strDjh = Value
        End Set
    End Property

    Public Property paraBlnFp() As Boolean
        Get
            paraBlnFp = blnFp
        End Get
        Set(ByVal Value As Boolean)
            blnFp = Value
        End Set
    End Property

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT oe_xsd.fpsl FROM oe_xsd WHERE (djh = ? )"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@djh", OleDbType.VarChar, 15).Value = Me.TxtDjh.Text
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("rc_xsdml") IsNot Nothing Then
                Me.rcDataSet.Tables("rc_xsdml").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "rc_xsdml")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message)
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("rc_xsdml").Rows.Count > 0 Then
            '已开票不能冲销
            Dim i As Integer
            For i = 0 To rcDataSet.Tables("rc_xsdml").Rows.Count - 1
                If rcDataSet.Tables("rc_xsdml").Rows(i).Item("fpsl").GetType.ToString <> "System.DBNull" Then
                    If rcDataSet.Tables("rc_xsdml").Rows(i).Item("fpsl") <> 0 Then
                        blnFp = True
                    End If
                End If
            Next
        End If
        If Not String.IsNullOrEmpty(Me.TxtDjh.Text) Then
            strDjh = Trim(Me.TxtDjh.Text)
        End If
    End Sub
End Class