Imports System.Data.OleDb
Public Class FrmPoCkdSr3

    '建立数据适配器
    Dim rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    Dim rcDataset As New DataSet
    '数据更新传递
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    Dim rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '数据视图
    Dim rcDataView As DataView
    'shCommPort为串口号从0开始，dwBaudrate为波特率通常9600
    '如果寻读卡成功，返回卡片系列号dwSerialNo和制造商shManu
    'Phillips 0	Siemens 1
    Public Declare Function GetCSN Lib "READCARD.DLL" (ByVal shCommPort As Short, ByVal dwBaudrate As Integer, ByRef dwSerialNo As Integer, ByRef shManu As Short) As Short
    Dim intCom As Integer = 0

    Private Sub FrmPoCkdSr2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '取端口设置
        Try
            If System.IO.File.Exists(Application.StartupPath & "\" & "COMport.xml") Then
                Dim xmlCom As New System.Xml.XmlDocument
                xmlCom.Load(Application.StartupPath & "\" & "COMport.xml")
                intCom = xmlCom.SelectSingleNode("COMport").InnerText
            End If
        Catch ex As Exception
            MsgBox("请设置读卡程序商品参数。程序错误：" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End Try
    End Sub

    Private Sub TimerReadCard_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerReadCard.Tick
        Dim shCommPort As Short = intCom
        Dim dwBaudrate As Integer = 9600
        Dim dwSerialNo As Integer = 0
        Dim shManu As Short = 0
        Dim mm As Short = 1
        mm = GetCSN(shCommPort, dwBaudrate, dwSerialNo, shManu)
        If mm <> 1 Then
            Me.TxtZydm.Text = IIf(dwSerialNo < 0, 4294967296 + dwSerialNo, dwSerialNo)
            Me.TimerReadCard.Enabled = False
        End If
        '读取数据
        If Not String.IsNullOrEmpty(Me.TxtZydm.Text) Then
            '取职员编码
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT rc_zyxx.zydm,rc_zyxx.zymc FROM rc_zyxx WHERE rc_zyxx.icno = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@icno", OleDbType.VarChar, 12).Value = Me.TxtZydm.Text
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If Not rcDataset.Tables("rc_zyxx") Is Nothing Then
                    Me.rcDataset.Tables("rc_zyxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_zyxx")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message)
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_zyxx").Rows.Count > 0 Then
                Me.TxtZydm.Text = rcDataset.Tables("rc_zyxx").Rows(0).Item("zydm")
            End If
            '取未发料明细
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                '取部门、设备、职员
                rcOleDbCommand.CommandText = "SELECT inv_llsq.zydm,inv_llsq.zymc,inv_llsq.bmdm,inv_llsq.bmmc FROM inv_llsq WHERE ((inv_llsq.sl > inv_llsq.cksl AND inv_llsq.sl > 0) OR (inv_llsq.sl < inv_llsq.cksl AND inv_llsq.sl < 0)) AND inv_llsq.bclosed  = 0" & IIf(Me.ChbSh.Checked, " AND NOT inv_llsq.shr IS NULL", "") & IIf(Not String.IsNullOrEmpty(Me.TxtZydm.Text), " and inv_llsq.zydm = '" & Trim(Me.TxtZydm.Text) & "'", "") & " ORDER BY inv_llsq.djh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If Not rcDataset.Tables("inv_llsqml") Is Nothing Then
                    rcDataset.Tables("inv_llsqml").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "inv_llsqml")
                '取物料信息
                rcOleDbCommand.CommandText = "SELECT inv_llsq.cpdm,rc_cpxx.cpmc,inv_llsq.csdm,inv_llsq.csmc,rc_cpxx.brecycling,rc_cpxx.bfadm,inv_llsq.fadm,inv_llsq.famc,rc_cpxx.kuwei,(inv_llsq.sl - inv_llsq.cksl) As sl,rc_cpxx.dw,0.0 AS dj,0.0 AS je,inv_llsq.sqmemo AS ckmemo,inv_llsq.djh AS llsqdjh,inv_llsq.xh AS llsqxh FROM inv_llsq,rc_cpxx WHERE inv_llsq.cpdm = rc_cpxx.cpdm AND ((inv_llsq.sl > inv_llsq.cksl AND inv_llsq.sl > 0) OR (inv_llsq.sl < inv_llsq.cksl AND inv_llsq.sl < 0)) AND inv_llsq.bclosed  = 0" & IIf(Me.ChbSh.Checked, " AND NOT inv_llsq.shr IS NULL", "") & IIf(Not String.IsNullOrEmpty(Me.TxtBmdm.Text), " and inv_llsq.bmdm LIKE '" & Trim(Me.TxtBmdm.Text) & "%'", "") & IIf(Not String.IsNullOrEmpty(Me.TxtZydm.Text), " and inv_llsq.zydm = '" & Trim(Me.TxtZydm.Text) & "'", "") & " ORDER BY inv_llsq.xh"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If Not rcDataset.Tables("rc_ckdnr") Is Nothing Then
                    rcDataset.Tables("rc_ckdnr").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_ckdnr")
            Catch ex As Exception
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("rc_ckdnr").Rows.Count <= 0 Then
                MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If

        End If
    End Sub

    Private Sub TxtZydm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtZydm.LostFocus
        Me.TimerReadCard.Enabled = False
    End Sub

    Private Sub TxtZydm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtZydm.GotFocus
        Me.TimerReadCard.Enabled = True
    End Sub

    Private Sub TxtZydm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtZydm.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                If Me.TimerReadCard.Enabled = True Then
                    Me.TimerReadCard.Enabled = False
                Else
                    Me.TimerReadCard.Enabled = True
                End If
        End Select
    End Sub
End Class