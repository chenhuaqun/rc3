Imports System.Data.OleDb

Public Class FrmImpU8
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '数据更新传递
    Dim rcOleDbTrans As OleDbTransaction
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Private Sub FrmImpU8_Load(sender As Object, e As EventArgs) Handles Me.Load
        '默认值
        Dim strDwKjqj As String = GetInvKjqj(g_Dwrq)
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT ny,jzbz,invbegin,invend FROM rc_yj WHERE jzbz = 0 AND ny >= ? ORDER BY ny"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = strDwKjqj
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_yj") IsNot Nothing Then
                rcDataset.Tables("rc_yj").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_yj")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_yj").Rows.Count = 0 Then
            MsgBox("会计期间设置有错误，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        '默认值
        NudYear.Value = Mid(rcDataset.Tables("rc_yj").Rows(0).Item("ny"), 1, 4)
        NudMonth.Value = Mid(rcDataset.Tables("rc_yj").Rows(0).Item("ny"), 5, 2)
    End Sub

    Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click
        If MsgBox("确定要读取U8的数据吗？", MsgBoxStyle.YesNo, "提示信息") = MsgBoxResult.No Then
            Return
        End If
        Dim U8Acc_ID As String = ""
        Dim U8SysOleDbConn As New OleDbConnection
        Dim U8OleDbConn As New OleDbConnection
        Dim i As Integer
        'Dim j As Integer
        Dim dateBegin As DateTime
        Dim dateEnd As DateTime
        dateBegin = GetInvBegin(Me.NudYear.Value, Me.NudMonth.Value)
        dateEnd = GetInvEnd(Me.NudYear.Value, Me.NudMonth.Value)
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT * FROM rc_para Where dwdm = ? And (paraid = 'U8Acc_ID' or paraid = 'U8HOST' or paraid = 'U8User_ID' or paraid = 'U8PASSWORD') ORDER BY paraid"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@dwdm", OleDbType.VarChar, 4).Value = g_Dwdm
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("rc_para") IsNot Nothing Then
                Me.rcDataset.Tables("rc_para").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
        Catch ex As Exception
            MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_para").Rows.Count = 4 Then
            If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                U8Acc_ID = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
            End If
            'SQL Server
            U8SysOleDbConn.ConnectionString = "Provider=SQLOLEDB.1;OLE DB Services=-1;Data Source=" & rcDataset.Tables("rc_para").Rows(1).Item("parastrvalue") & ";Initial Catalog=UFSYSTEM;User ID=" & rcDataset.Tables("rc_para").Rows(3).Item("parastrvalue") & ";PWD=" & rcDataset.Tables("rc_para").Rows(2).Item("parastrvalue") 'Integrated Security=SSPI;
            'Orcal 9.i
            'U8OleDbConn.ConnectionString = "Provider=OraOLEDB.Oracle.1;Persist Security Info=False;Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = " & rcDataset.Tables("rc_para").Rows(1).Item("parastrvalue") & ")(PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = " & rcDataset.Tables("rc_para").Rows(3).Item("parastrvalue") & ")));User ID=" & rcDataset.Tables("rc_para").Rows(4).Item("parastrvalue") & ";Password=" & rcDataset.Tables("rc_para").Rows(2).Item("parastrvalue") ' &";Pooling = false" 'Integrated Security=SSPI;
            '取账套的启用年份
            Try
                U8SysOleDbConn.Open()
                rcOleDbCommand.Connection = U8SysOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT * FROM UA_Account WHERE cAcc_ID = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@U8Acc_ID", OleDbType.VarChar, 40).Value = U8Acc_ID
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("UA_Account") IsNot Nothing Then
                    Me.rcDataset.Tables("UA_Account").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "UA_Account")
            Catch ex As Exception
                MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                U8SysOleDbConn.Close()
            End Try
            If rcDataset.Tables("UA_Account").Rows.Count > 0 Then
                'SQL Server
                U8OleDbConn.ConnectionString = "Provider=SQLOLEDB.1;OLE DB Services=-1;Data Source=" & rcDataset.Tables("rc_para").Rows(1).Item("parastrvalue") & ";Initial Catalog=UFDATA_" & U8Acc_ID & "_" & rcDataset.Tables("UA_Account").Rows(0).Item("iyear") & ";User ID=" & rcDataset.Tables("rc_para").Rows(3).Item("parastrvalue") & ";PWD=" & rcDataset.Tables("rc_para").Rows(2).Item("parastrvalue") 'Integrated Security=SSPI;
                'MsgBox(U8OleDbConn.ConnectionString)
            End If
            If rcDataset.Tables("UA_Account").Rows(0).Item("iyear") = Me.NudYear.Value Then
                Me.ChbKcqcye.Enabled = True
            Else
                Me.ChbKcqcye.Enabled = False
            End If
        Else
            MsgBox("请定义用友U8数据源信息。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        '采购入库
        If Me.ChbPoRkd.Checked Then
            '读取采购入库
            Try
                U8OleDbConn.Open()
                rcOleDbCommand.Connection = U8OleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT rdrecord.*,ISNULL(ComputationUnit.cComUnitName,'') AS fzdw FROM (SELECT rdrecord01.cCode,rdrecords01.iRowNo,rdrecord01.dDate AS rkrq,rdrecord01.cVenCode AS csdm,Vendor.cVenName AS csmc,Vendor.cVCCode AS cslbdm,rdrecord01.cWhCode AS ckdm,Warehouse.cWhName AS ckmc,rdrecords01.cInvCode AS cpdm,Inventory.cInvName + ',' + ISNULL(Inventory.cInvStd,'') AS cpmc,ComputationUnit.cComUnitName AS dw,ISNULL(Inventory.cAssComUnitCode,'') AS cAssComUnitCode,ISNULL(rdrecords01.cBatch,'') AS cBatch,rdrecords01.iQuantity AS sl,ISNULL(rdrecords01.iNum,0.0) AS fzsl,rdrecords01.iOriCost AS dj,rdrecords01.iOriTaxCost AS hsdj,rdrecords01.iOriMoney AS je,rdrecords01.iTaxRate AS shlv,rdrecords01.iOriTaxPrice AS se,ISNULL(rdrecords01.cbMemo,'') AS rkmemo FROM rdrecord01,rdrecords01,Warehouse,Inventory,ComputationUnit,Vendor WHERE rdrecord01.ID = rdrecords01.ID AND rdrecord01.cWhCode = Warehouse.cWhCode AND rdrecords01.cInvCode = Inventory.cInvCode AND Inventory.cComunitCode = ComputationUnit.cComunitCode AND rdrecord01.cVenCode = Vendor.cVenCode AND rdrecord01.dDate <= ? AND rdrecord01.dDate >= ?) rdrecord LEFT JOIN ComputationUnit ON ComputationUnit.cComunitCode = rdrecord.cAssComUnitCode ORDER BY rdrecord.cCode,rdrecord.iRowNo"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dateEnd", OleDbType.Date, 8).Value = dateEnd
                rcOleDbCommand.Parameters.Add("@dateBegin", OleDbType.Date, 8).Value = dateBegin
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rdrecord01") IsNot Nothing Then
                    Me.rcDataset.Tables("rdrecord01").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rdrecord01")
                Me.ProgressBar1.Maximum = rcDataset.Tables("rdrecord01").Rows.Count
            Catch ex As Exception
                MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                U8OleDbConn.Close()
            End Try
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                '序列删除再重建
                rcOleDbCommand.CommandText = "DROP SEQUENCE CGRK" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "CREATE SEQUENCE CGRK" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0") & " INCREMENT BY 1 START WITH 1 MAXVALUE 99999 MINVALUE 1 NOCYCLE NOCACHE NOORDER"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '更新单据号至0
                rcOleDbCommand.CommandText = "UPDATE rc_lx SET pzno" & Me.NudMonth.Value.ToString.PadLeft(2, "0") & " = 0 WHERE kjnd = ? AND pzlxdm = 'CGRK'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                rcOleDbCommand.ExecuteNonQuery()
                '删除历史单据
                rcOleDbCommand.CommandText = "DELETE FROM po_rkd WHERE SUBSTR(djh,5,6)= ? AND SUBSTR(djh,1,4) = 'CGRK'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                Me.ProgressBar1.Maximum = rcDataset.Tables("rdrecord01").Rows.Count
                Dim oldStrDjh As String = ""
                Dim ParaStrDjh As String = ""
                Dim blnNew As Boolean = False
                For i = 0 To rcDataset.Tables("rdrecord01").Rows.Count - 1
                    If oldStrDjh <> rcDataset.Tables("rdrecord01").Rows(i).Item("cCode") Then
                        blnNew = True
                        oldStrDjh = rcDataset.Tables("rdrecord01").Rows(i).Item("cCode")
                    Else
                        blnNew = False
                    End If
                    Me.ProgressBar1.Value = i + 1
                    rcOleDbCommand.CommandType = CommandType.StoredProcedure
                    rcOleDbCommand.CommandText = "USP3_SAVE_PO_RKD"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                    rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = IIf(blnNew, "CGRK" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0") & "00001", ParaStrDjh)
                    rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                    rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = IIf(blnNew, 1, rcDataset.Tables("rdrecord01").Rows(i).Item("iRowNo"))
                    rcOleDbCommand.Parameters.Add("@paraDateRkrq", OleDbType.Date, 8).Value = rcDataset.Tables("rdrecord01").Rows(i).Item("rkrq")
                    rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                    rcOleDbCommand.Parameters.Add("@paraStrZydm", OleDbType.VarChar, 12).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrZymc", OleDbType.VarChar, 30).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rdrecord01").Rows(i).Item("csdm")
                    rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("rdrecord01").Rows(i).Item("csmc")
                    rcOleDbCommand.Parameters.Add("@paraStrYspz", OleDbType.VarChar, 12).Value = "~"
                    rcOleDbCommand.Parameters.Add("@ParaStrCkdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rdrecord01").Rows(i).Item("ckdm")
                    rcOleDbCommand.Parameters.Add("@paraStrCkmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("rdrecord01").Rows(i).Item("ckmc")
                    rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("rdrecord01").Rows(i).Item("cpdm")
                    rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("rdrecord01").Rows(i).Item("cpmc")
                    rcOleDbCommand.Parameters.Add("@paraStrKuwei", OleDbType.VarChar, 40).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrSgddh", OleDbType.VarChar, 20).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrPiHao", OleDbType.VarChar, 30).Value = rcDataset.Tables("rdrecord01").Rows(i).Item("cBatch")
                    rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rdrecord01").Rows(i).Item("sl")
                    rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = rcDataset.Tables("rdrecord01").Rows(i).Item("dw")
                    rcOleDbCommand.Parameters.Add("@paraDblMjsl", OleDbType.Numeric, 18).Value = 0.0
                    rcOleDbCommand.Parameters.Add("@paraDblFzsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rdrecord01").Rows(i).Item("fzsl")
                    rcOleDbCommand.Parameters.Add("@paraStrFzdw", OleDbType.VarChar, 8).Value = rcDataset.Tables("rdrecord01").Rows(i).Item("fzdw")
                    rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = rcDataset.Tables("rdrecord01").Rows(i).Item("dj")
                    rcOleDbCommand.Parameters.Add("@paraDblHsdj", OleDbType.Numeric, 18).Value = rcDataset.Tables("rdrecord01").Rows(i).Item("hsdj")
                    rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rdrecord01").Rows(i).Item("je")
                    rcOleDbCommand.Parameters.Add("@paraDblShlv", OleDbType.Numeric, 6).Value = rcDataset.Tables("rdrecord01").Rows(i).Item("shlv")
                    rcOleDbCommand.Parameters.Add("@paraDblSe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rdrecord01").Rows(i).Item("se")
                    rcOleDbCommand.Parameters.Add("@paraStrRkmemo", OleDbType.VarChar, 50).Value = rcDataset.Tables("rdrecord01").Rows(i).Item("rkmemo")
                    rcOleDbCommand.Parameters.Add("@paraStrCgdDjh", OleDbType.VarChar, 15).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraIntCgdXh", OleDbType.Integer, 4).Value = 0
                    rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                    rcOleDbCommand.Parameters.Add("@paraCbill_bid", OleDbType.VarChar, 20).Value = rcDataset.Tables("rdrecord01").Rows(i).Item("cCode")
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
                            ParaStrDjh = Trim(rcOleDbCommand.Parameters("@paraStrDjh").Value)
                        End If
                    End If
                    '检测供应商编码
                    If rcDataset.Tables("rdrecord01").Rows(i).Item("csdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT csdm FROM rc_csxx WHERE csdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("rdrecord01").Rows(i).Item("csdm")
                        If rcDataset.Tables("rc_csxx") IsNot Nothing Then
                            rcDataset.Tables("rc_csxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_csxx")
                        If rcDataset.Tables("rc_csxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_csxx (csdm,csmc,zczb) VALUES (?,?,0)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@csdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("rdrecord01").Rows(i).Item("csdm")
                            rcOleDbCommand.Parameters.Add("@csmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("rdrecord01").Rows(i).Item("csmc")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    '检测物料编码
                    If rcDataset.Tables("rdrecord01").Rows(i).Item("cpdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT cpdm FROM rc_cpxx WHERE cpdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("rdrecord01").Rows(i).Item("cpdm")
                        If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                            rcDataset.Tables("rc_cpxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
                        If rcDataset.Tables("rc_cpxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_cpxx (cpdm,cpmc,dw) VALUES (?,?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("rdrecord01").Rows(i).Item("cpdm")
                            rcOleDbCommand.Parameters.Add("@cpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("rdrecord01").Rows(i).Item("cpmc")
                            rcOleDbCommand.Parameters.Add("@dw", OleDbType.VarChar, 8).Value = rcDataset.Tables("rdrecord01").Rows(i).Item("dw")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    '检测仓库编码
                    If rcDataset.Tables("rdrecord01").Rows(i).Item("ckdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT ckdm FROM rc_ckxx WHERE ckdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rdrecord01").Rows(i).Item("ckdm")
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_ckxx") IsNot Nothing Then
                            rcDataset.Tables("rc_ckxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_ckxx")
                        If rcDataset.Tables("rc_ckxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_ckxx (ckdm,ckmc) VALUES (?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rdrecord01").Rows(i).Item("ckdm")
                            rcOleDbCommand.Parameters.Add("@ckmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("rdrecord01").Rows(i).Item("ckmc")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                Next
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("程序错误。" & Chr(13) & ex.Message)
                Catch ey As OleDbException
                    MsgBox("程序错误。" & Chr(13) & ey.Message)
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        End If
        '产成品入库
        If Me.ChbInvRkd1.Checked Then
            '读取产成品入库
            Try
                U8OleDbConn.Open()
                rcOleDbCommand.Connection = U8OleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT rdrecord.*,ISNULL(ComputationUnit.cComUnitName,'') AS fzdw FROM (SELECT rdrecord10.cCode,rdrecords10.iRowNo,rdrecord10.dDate AS rkrq,rdrecord10.cDepCode AS bmdm,Department.cDepName AS bmmc,rdrecord10.cWhCode AS ckdm,Warehouse.cWhName AS ckmc,rdrecords10.cInvCode AS cpdm,Inventory.cInvName + ',' + ISNULL(Inventory.cInvStd,'') AS cpmc,ComputationUnit.cComUnitName AS dw,ISNULL(Inventory.cAssComUnitCode,'') AS cAssComUnitCode,ISNULL(rdrecords10.cBatch,'') AS cBatch,rdrecords10.iQuantity AS sl,ISNULL(rdrecords10.iNum,0.0) AS fzsl,rdrecords10.iUnitCost AS dj,rdrecords10.iPrice AS je,ISNULL(rdrecords10.cbMemo,'') AS rkmemo FROM rdrecord10,rdrecords10,Warehouse,Inventory,ComputationUnit,Department WHERE rdrecord10.ID = rdrecords10.ID AND rdrecord10.cWhCode = Warehouse.cWhCode AND rdrecords10.cInvCode = Inventory.cInvCode AND Inventory.cComunitCode = ComputationUnit.cComunitCode AND rdrecord10.cDepCode = Department.cDepCode AND rdrecord10.dDate <= ? AND rdrecord10.dDate >= ?) rdrecord LEFT JOIN ComputationUnit ON ComputationUnit.cComunitCode = rdrecord.cAssComUnitCode ORDER BY rdrecord.cCode,rdrecord.iRowNo"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dateEnd", OleDbType.Date, 8).Value = dateEnd
                rcOleDbCommand.Parameters.Add("@dateBegin", OleDbType.Date, 8).Value = dateBegin
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rdrecord10") IsNot Nothing Then
                    Me.rcDataset.Tables("rdrecord10").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rdrecord10")
                Me.ProgressBar1.Maximum = rcDataset.Tables("rdrecord10").Rows.Count
            Catch ex As Exception
                MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                U8OleDbConn.Close()
            End Try
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                '序列删除再重建
                rcOleDbCommand.CommandText = "DROP SEQUENCE SCRK" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "CREATE SEQUENCE SCRK" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0") & " INCREMENT BY 1 START WITH 1 MAXVALUE 99999 MINVALUE 1 NOCYCLE NOCACHE NOORDER"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '更新单据号至0
                rcOleDbCommand.CommandText = "UPDATE rc_lx SET pzno" & Me.NudMonth.Value.ToString.PadLeft(2, "0") & " = 0 WHERE kjnd = ? AND pzlxdm = 'SCRK'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                rcOleDbCommand.ExecuteNonQuery()
                '删除历史单据
                rcOleDbCommand.CommandText = "DELETE FROM inv_rkd WHERE SUBSTR(djh,5,6)= ? AND SUBSTR(djh,1,4) = 'SCRK'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                Me.ProgressBar1.Maximum = rcDataset.Tables("rdrecord10").Rows.Count
                Dim oldStrDjh As String = ""
                Dim ParaStrDjh As String = ""
                Dim blnNew As Boolean = False
                For i = 0 To rcDataset.Tables("rdrecord10").Rows.Count - 1
                    If oldStrDjh <> rcDataset.Tables("rdrecord10").Rows(i).Item("cCode") Then
                        blnNew = True
                        oldStrDjh = rcDataset.Tables("rdrecord10").Rows(i).Item("cCode")
                    Else
                        blnNew = False
                    End If
                    Me.ProgressBar1.Value = i + 1
                    rcOleDbCommand.CommandType = CommandType.StoredProcedure
                    rcOleDbCommand.CommandText = "USP3_SAVE_INV_RKD"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                    rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = IIf(blnNew, "SCRK" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0") & "00001", ParaStrDjh)
                    rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                    rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = IIf(blnNew, 1, rcDataset.Tables("rdrecord10").Rows(i).Item("iRowNo"))
                    rcOleDbCommand.Parameters.Add("@paraDateRkrq", OleDbType.Date, 8).Value = rcDataset.Tables("rdrecord10").Rows(i).Item("rkrq")
                    rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                    rcOleDbCommand.Parameters.Add("@paraStrZydm", OleDbType.VarChar, 12).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrZymc", OleDbType.VarChar, 30).Value = "~"
                    rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rdrecord10").Rows(i).Item("bmdm")
                    rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("rdrecord10").Rows(i).Item("bmmc")
                    rcOleDbCommand.Parameters.Add("@ParaStrCkdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rdrecord10").Rows(i).Item("ckdm")
                    rcOleDbCommand.Parameters.Add("@paraStrCkmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("rdrecord10").Rows(i).Item("ckmc")
                    rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("rdrecord10").Rows(i).Item("cpdm")
                    rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("rdrecord10").Rows(i).Item("cpmc")
                    rcOleDbCommand.Parameters.Add("@paraStrHth", OleDbType.VarChar, 30).Value = ""
                    'rcOleDbCommand.Parameters.Add("@paraStrPiHao", OleDbType.VarChar, 30).Value = rcDataset.Tables("rdrecord10").Rows(i).Item("cBatch")
                    rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rdrecord10").Rows(i).Item("sl")
                    rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = rcDataset.Tables("rdrecord10").Rows(i).Item("dw")
                    rcOleDbCommand.Parameters.Add("@paraDblMjsl", OleDbType.Numeric, 18).Value = 0.0
                    rcOleDbCommand.Parameters.Add("@paraDblFzsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rdrecord10").Rows(i).Item("fzsl")
                    rcOleDbCommand.Parameters.Add("@paraStrFzdw", OleDbType.VarChar, 8).Value = rcDataset.Tables("rdrecord10").Rows(i).Item("fzdw")
                    rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = rcDataset.Tables("rdrecord10").Rows(i).Item("dj")
                    rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rdrecord10").Rows(i).Item("je")
                    rcOleDbCommand.Parameters.Add("@paraStrRkmemo", OleDbType.VarChar, 50).Value = rcDataset.Tables("rdrecord10").Rows(i).Item("rkmemo")
                    rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                    rcOleDbCommand.Parameters.Add("@paraCbill_bid", OleDbType.VarChar, 20).Value = rcDataset.Tables("rdrecord10").Rows(i).Item("cCode")
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
                            ParaStrDjh = Trim(rcOleDbCommand.Parameters("@paraStrDjh").Value)
                        End If
                    End If
                    '检测部门编码
                    If rcDataset.Tables("rdrecord10").Rows(i).Item("bmdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT bmdm FROM rc_bmxx WHERE bmdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("rdrecord10").Rows(i).Item("bmdm")
                        If rcDataset.Tables("rc_bmxx") IsNot Nothing Then
                            rcDataset.Tables("rc_bmxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_bmxx")
                        If rcDataset.Tables("rc_bmxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_bmxx (bmdm,bmmc) VALUES (?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("rdrecord10").Rows(i).Item("bmdm")
                            rcOleDbCommand.Parameters.Add("@bmmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("rdrecord10").Rows(i).Item("bmmc")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    '检测物料编码
                    If rcDataset.Tables("rdrecord10").Rows(i).Item("cpdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT cpdm FROM rc_cpxx WHERE cpdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("rdrecord10").Rows(i).Item("cpdm")
                        If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                            rcDataset.Tables("rc_cpxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
                        If rcDataset.Tables("rc_cpxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_cpxx (cpdm,cpmc,dw,fzdw) VALUES (?,?,?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("rdrecord10").Rows(i).Item("cpdm")
                            rcOleDbCommand.Parameters.Add("@cpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("rdrecord10").Rows(i).Item("cpmc")
                            rcOleDbCommand.Parameters.Add("@dw", OleDbType.VarChar, 8).Value = rcDataset.Tables("rdrecord10").Rows(i).Item("dw")
                            rcOleDbCommand.Parameters.Add("@fzdw", OleDbType.VarChar, 8).Value = rcDataset.Tables("rdrecord10").Rows(i).Item("fzdw")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    '检测仓库编码
                    If rcDataset.Tables("rdrecord10").Rows(i).Item("ckdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT ckdm FROM rc_ckxx WHERE ckdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rdrecord10").Rows(i).Item("ckdm")
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_ckxx") IsNot Nothing Then
                            rcDataset.Tables("rc_ckxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_ckxx")
                        If rcDataset.Tables("rc_ckxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_ckxx (ckdm,ckmc) VALUES (?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rdrecord10").Rows(i).Item("ckdm")
                            rcOleDbCommand.Parameters.Add("@ckmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("rdrecord10").Rows(i).Item("ckmc")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                Next
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("程序错误。" & Chr(13) & ex.Message)
                Catch ey As OleDbException
                    MsgBox("程序错误。" & Chr(13) & ey.Message)
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        End If
        '材料出库
        If Me.ChbInvCkd.Checked Then
            '读取材料出库
            Try
                U8OleDbConn.Open()
                rcOleDbCommand.Connection = U8OleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT rdrecord.*,ISNULL(ComputationUnit.cComUnitName,'') AS fzdw FROM (SELECT rdrecord11.cCode,rdrecords11.iRowNo,rdrecord11.dDate AS ckrq,rdrecord11.cDepCode AS bmdm,Department.cDepName AS bmmc,rdrecord11.cWhCode AS ckdm,Warehouse.cWhName AS ckmc,rdrecords11.cInvCode AS cpdm,Inventory.cInvName + ',' + ISNULL(Inventory.cInvStd,'') AS cpmc,ComputationUnit.cComUnitName AS dw,ISNULL(Inventory.cAssComUnitCode,'') AS cAssComUnitCode,ISNULL(rdrecords11.cBatch,'') AS cBatch,rdrecords11.iQuantity AS sl,ISNULL(rdrecords11.iNum,0.0) AS fzsl,rdrecords11.iUnitCost AS dj,rdrecords11.iPrice AS je,ISNULL(rdrecords11.cbMemo,'') AS ckmemo FROM rdrecord11,rdrecords11,Warehouse,Inventory,ComputationUnit,Department WHERE rdrecord11.ID = rdrecords11.ID AND rdrecord11.cWhCode = Warehouse.cWhCode AND rdrecords11.cInvCode = Inventory.cInvCode AND Inventory.cComunitCode = ComputationUnit.cComunitCode AND rdrecord11.cDepCode = Department.cDepCode AND rdrecord11.dDate <= ? AND rdrecord11.dDate >= ?) rdrecord LEFT JOIN ComputationUnit ON ComputationUnit.cComunitCode = rdrecord.cAssComUnitCode ORDER BY rdrecord.cCode,rdrecord.iRowNo"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dateEnd", OleDbType.Date, 8).Value = dateEnd
                rcOleDbCommand.Parameters.Add("@dateBegin", OleDbType.Date, 8).Value = dateBegin
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rdrecord11") IsNot Nothing Then
                    Me.rcDataset.Tables("rdrecord11").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rdrecord11")
                Me.ProgressBar1.Maximum = rcDataset.Tables("rdrecord11").Rows.Count
            Catch ex As Exception
                MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                U8OleDbConn.Close()
            End Try
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                '序列删除再重建
                rcOleDbCommand.CommandText = "DROP SEQUENCE LLCK" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "CREATE SEQUENCE LLCK" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0") & " INCREMENT BY 1 START WITH 1 MAXVALUE 99999 MINVALUE 1 NOCYCLE NOCACHE NOORDER"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '更新单据号至0
                rcOleDbCommand.CommandText = "UPDATE rc_lx SET pzno" & Me.NudMonth.Value.ToString.PadLeft(2, "0") & " = 0 WHERE kjnd = ? AND pzlxdm = 'LLCK'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                rcOleDbCommand.ExecuteNonQuery()
                '删除历史单据
                rcOleDbCommand.CommandText = "DELETE FROM inv_ckd WHERE SUBSTR(djh,5,6)= ? AND SUBSTR(djh,1,4) = 'LLCK'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                Me.ProgressBar1.Maximum = rcDataset.Tables("rdrecord11").Rows.Count
                Dim oldStrDjh As String = ""
                Dim ParaStrDjh As String = ""
                Dim blnNew As Boolean = False
                For i = 0 To rcDataset.Tables("rdrecord11").Rows.Count - 1
                    If oldStrDjh <> rcDataset.Tables("rdrecord11").Rows(i).Item("cCode") Then
                        blnNew = True
                        oldStrDjh = rcDataset.Tables("rdrecord11").Rows(i).Item("cCode")
                    Else
                        blnNew = False
                    End If
                    Me.ProgressBar1.Value = i + 1
                    rcOleDbCommand.CommandType = CommandType.StoredProcedure
                    rcOleDbCommand.CommandText = "USP3_SAVE_INV_CKD"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                    rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = IIf(blnNew, "LLCK" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0") & "00001", ParaStrDjh)
                    rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                    rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = IIf(blnNew, 1, rcDataset.Tables("rdrecord11").Rows(i).Item("iRowNo"))
                    rcOleDbCommand.Parameters.Add("@paraDateCkrq", OleDbType.Date, 8).Value = rcDataset.Tables("rdrecord11").Rows(i).Item("ckrq")
                    rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                    rcOleDbCommand.Parameters.Add("@ParaStrCkdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rdrecord11").Rows(i).Item("ckdm")
                    rcOleDbCommand.Parameters.Add("@paraStrCkmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("rdrecord11").Rows(i).Item("ckmc")
                    rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rdrecord11").Rows(i).Item("bmdm")
                    rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("rdrecord11").Rows(i).Item("bmmc")
                    rcOleDbCommand.Parameters.Add("@paraStrZydm", OleDbType.VarChar, 12).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrZymc", OleDbType.VarChar, 30).Value = "~"
                    rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("rdrecord11").Rows(i).Item("cpdm")
                    rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("rdrecord11").Rows(i).Item("cpmc")
                    rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrBrecycling", OleDbType.Numeric, 1).Value = 0
                    rcOleDbCommand.Parameters.Add("@paraStrBfadm", OleDbType.Numeric, 1).Value = 0
                    rcOleDbCommand.Parameters.Add("@ParaStrFadm", OleDbType.VarChar, 12).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrFamc", OleDbType.VarChar, 30).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrKuwei", OleDbType.VarChar, 40).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrPiHao", OleDbType.VarChar, 30).Value = rcDataset.Tables("rdrecord11").Rows(i).Item("cBatch")
                    rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rdrecord11").Rows(i).Item("sl")
                    rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = rcDataset.Tables("rdrecord11").Rows(i).Item("dw")
                    rcOleDbCommand.Parameters.Add("@paraDblMjsl", OleDbType.Numeric, 18).Value = 0.0
                    rcOleDbCommand.Parameters.Add("@paraDblFzsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rdrecord11").Rows(i).Item("fzsl")
                    rcOleDbCommand.Parameters.Add("@paraStrFzdw", OleDbType.VarChar, 8).Value = rcDataset.Tables("rdrecord11").Rows(i).Item("fzdw")
                    rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = rcDataset.Tables("rdrecord11").Rows(i).Item("dj")
                    rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rdrecord11").Rows(i).Item("je")
                    rcOleDbCommand.Parameters.Add("@paraStrCkmemo", OleDbType.VarChar, 50).Value = rcDataset.Tables("rdrecord11").Rows(i).Item("ckmemo")
                    rcOleDbCommand.Parameters.Add("@paraStrLlsqDjh", OleDbType.VarChar, 15).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraIntLlsqXh", OleDbType.Integer, 4).Value = 0
                    rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                    rcOleDbCommand.Parameters.Add("@paraCbill_bid", OleDbType.VarChar, 20).Value = rcDataset.Tables("rdrecord11").Rows(i).Item("cCode")
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
                            ParaStrDjh = Trim(rcOleDbCommand.Parameters("@paraStrDjh").Value)
                        End If
                    End If
                    '检测部门编码
                    If rcDataset.Tables("rdrecord11").Rows(i).Item("bmdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT bmdm FROM rc_bmxx WHERE bmdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("rdrecord11").Rows(i).Item("bmdm")
                        If rcDataset.Tables("rc_bmxx") IsNot Nothing Then
                            rcDataset.Tables("rc_bmxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_bmxx")
                        If rcDataset.Tables("rc_bmxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_bmxx (bmdm,bmmc) VALUES (?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("rdrecord11").Rows(i).Item("bmdm")
                            rcOleDbCommand.Parameters.Add("@bmmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("rdrecord11").Rows(i).Item("bmmc")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    '检测物料编码
                    If rcDataset.Tables("rdrecord11").Rows(i).Item("cpdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT cpdm FROM rc_cpxx WHERE cpdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("rdrecord11").Rows(i).Item("cpdm")
                        If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                            rcDataset.Tables("rc_cpxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
                        If rcDataset.Tables("rc_cpxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_cpxx (cpdm,cpmc,dw,fzdw) VALUES (?,?,?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("rdrecord11").Rows(i).Item("cpdm")
                            rcOleDbCommand.Parameters.Add("@cpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("rdrecord11").Rows(i).Item("cpmc")
                            rcOleDbCommand.Parameters.Add("@dw", OleDbType.VarChar, 8).Value = rcDataset.Tables("rdrecord11").Rows(i).Item("dw")
                            rcOleDbCommand.Parameters.Add("@fzdw", OleDbType.VarChar, 8).Value = rcDataset.Tables("rdrecord11").Rows(i).Item("fzdw")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    '检测仓库编码
                    If rcDataset.Tables("rdrecord11").Rows(i).Item("ckdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT ckdm FROM rc_ckxx WHERE ckdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rdrecord11").Rows(i).Item("ckdm")
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_ckxx") IsNot Nothing Then
                            rcDataset.Tables("rc_ckxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_ckxx")
                        If rcDataset.Tables("rc_ckxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_ckxx (ckdm,ckmc) VALUES (?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rdrecord11").Rows(i).Item("ckdm")
                            rcOleDbCommand.Parameters.Add("@ckmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("rdrecord11").Rows(i).Item("ckmc")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                Next
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("程序错误。" & Chr(13) & ex.Message)
                Catch ey As OleDbException
                    MsgBox("程序错误。" & Chr(13) & ey.Message)
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        End If
        '销售出库
        If Me.ChbOeXsd.Checked Then
            '读取销售出库
            Try
                U8OleDbConn.Open()
                rcOleDbCommand.Connection = U8OleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT DispatchList.*,ISNULL(ComputationUnit.cComUnitName,'') AS fzdw FROM (SELECT DispatchList.cDLCode,DispatchLists.iRowNo,DispatchList.dDate AS xsrq,DispatchList.cDepCode AS bmdm,Department.cDepName AS bmmc,DispatchList.cCusCode As khdm,Customer.cCusName AS khmc,DispatchLists.cWhCode AS ckdm,Warehouse.cWhName AS ckmc,DispatchLists.cInvCode AS cpdm,Inventory.cInvName + ',' + ISNULL(Inventory.cInvStd,'') AS cpmc,ComputationUnit.cComUnitName AS dw,ISNULL(Inventory.cAssComUnitCode,'') AS cAssComUnitCode,ISNULL(DispatchLists.cBatch,'') AS cBatch,DispatchLists.iQuantity AS sl,ISNULL(DispatchLists.iNum,0.0) AS fzsl,DispatchLists.iUnitPrice AS dj,DispatchLists.iTaxUnitPrice AS hsdj,DispatchLists.iMoney AS je,DispatchLists.iTaxRate AS shlv,DispatchLists.iTax AS se,ISNULL(DispatchLists.cMemo,'') AS xsmemo FROM DispatchList,DispatchLists,Warehouse,Inventory,ComputationUnit,Department,Customer WHERE DispatchList.DLID = DispatchLists.DLID AND DispatchLists.cWhCode = Warehouse.cWhCode AND DispatchLists.cInvCode = Inventory.cInvCode AND Inventory.cComunitCode = ComputationUnit.cComunitCode AND DispatchList.cDepCode = Department.cDepCode AND DispatchList.cCusCode = Customer.cCusCode AND DispatchList.dDate <= ? AND DispatchList.dDate >= ?) DispatchList LEFT JOIN ComputationUnit ON ComputationUnit.cComunitCode = DispatchList.cAssComUnitCode ORDER BY DispatchList.cDLCode,DispatchList.iRowNo"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dateEnd", OleDbType.Date, 8).Value = dateEnd
                rcOleDbCommand.Parameters.Add("@dateBegin", OleDbType.Date, 8).Value = dateBegin
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("DispatchList") IsNot Nothing Then
                    Me.rcDataset.Tables("DispatchList").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "DispatchList")
                Me.ProgressBar1.Maximum = rcDataset.Tables("DispatchList").Rows.Count
            Catch ex As Exception
                MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                U8OleDbConn.Close()
            End Try
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                '序列删除再重建
                rcOleDbCommand.CommandText = "DROP SEQUENCE XSCK" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "CREATE SEQUENCE XSCK" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0") & " INCREMENT BY 1 START WITH 1 MAXVALUE 99999 MINVALUE 1 NOCYCLE NOCACHE NOORDER"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '更新单据号至0
                rcOleDbCommand.CommandText = "UPDATE rc_lx SET pzno" & Me.NudMonth.Value.ToString.PadLeft(2, "0") & " = 0 WHERE kjnd = ? AND pzlxdm = 'XSCK'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                rcOleDbCommand.ExecuteNonQuery()
                '删除历史单据
                rcOleDbCommand.CommandText = "DELETE FROM oe_xsd WHERE SUBSTR(djh,5,6)= ? AND SUBSTR(djh,1,4) = 'XSCK'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                Me.ProgressBar1.Maximum = rcDataset.Tables("DispatchList").Rows.Count
                Dim oldStrDjh As String = ""
                Dim ParaStrDjh As String = ""
                Dim blnNew As Boolean = False
                For i = 0 To rcDataset.Tables("DispatchList").Rows.Count - 1
                    If oldStrDjh <> rcDataset.Tables("DispatchList").Rows(i).Item("cDLCode") Then
                        blnNew = True
                        oldStrDjh = rcDataset.Tables("DispatchList").Rows(i).Item("cDLCode")
                    Else
                        blnNew = False
                    End If
                    Me.ProgressBar1.Value = i + 1
                    rcOleDbCommand.CommandType = CommandType.StoredProcedure
                    rcOleDbCommand.CommandText = "USP3_SAVE_OE_XSD"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                    rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = IIf(blnNew, "XSCK" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0") & "00001", ParaStrDjh)
                    rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                    rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = IIf(blnNew, 1, rcDataset.Tables("DispatchList").Rows(i).Item("iRowNo"))
                    rcOleDbCommand.Parameters.Add("@paraDateXsrq", OleDbType.Date, 8).Value = rcDataset.Tables("DispatchList").Rows(i).Item("xsrq")
                    rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                    rcOleDbCommand.Parameters.Add("@paraStrZydm", OleDbType.VarChar, 12).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrZymc", OleDbType.VarChar, 30).Value = "~"
                    rcOleDbCommand.Parameters.Add("@ParaStrKhdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("DispatchList").Rows(i).Item("khdm")
                    rcOleDbCommand.Parameters.Add("@paraStrKhmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("DispatchList").Rows(i).Item("khmc")
                    rcOleDbCommand.Parameters.Add("@ParaStrBmdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("DispatchList").Rows(i).Item("bmdm")
                    rcOleDbCommand.Parameters.Add("@paraStrBmmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("DispatchList").Rows(i).Item("bmmc")
                    rcOleDbCommand.Parameters.Add("@ParaStrCkdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("DispatchList").Rows(i).Item("ckdm")
                    rcOleDbCommand.Parameters.Add("@paraStrCkmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("DispatchList").Rows(i).Item("ckmc")
                    rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("DispatchList").Rows(i).Item("cpdm")
                    rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("DispatchList").Rows(i).Item("cpmc")
                    rcOleDbCommand.Parameters.Add("@paraStrHth", OleDbType.VarChar, 30).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrKhddh", OleDbType.VarChar, 30).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraStrKhlh", OleDbType.VarChar, 30).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("DispatchList").Rows(i).Item("sl")
                    rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = rcDataset.Tables("DispatchList").Rows(i).Item("dw")
                    rcOleDbCommand.Parameters.Add("@paraDblMjsl", OleDbType.Numeric, 18).Value = 0.0
                    rcOleDbCommand.Parameters.Add("@paraDblFzsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("DispatchList").Rows(i).Item("fzsl")
                    rcOleDbCommand.Parameters.Add("@paraStrFzdw", OleDbType.VarChar, 8).Value = rcDataset.Tables("DispatchList").Rows(i).Item("fzdw")
                    rcOleDbCommand.Parameters.Add("@paraIntJs", OleDbType.Integer, 12).Value = 0
                    rcOleDbCommand.Parameters.Add("@paraDblLt", OleDbType.Numeric, 18).Value = 0.0
                    rcOleDbCommand.Parameters.Add("@paraIntTs", OleDbType.Integer, 12).Value = 0
                    rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = rcDataset.Tables("DispatchList").Rows(i).Item("dj")
                    rcOleDbCommand.Parameters.Add("@paraDblHsdj", OleDbType.Numeric, 18).Value = rcDataset.Tables("DispatchList").Rows(i).Item("hsdj")
                    rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("DispatchList").Rows(i).Item("je")
                    rcOleDbCommand.Parameters.Add("@paraDblShlv", OleDbType.Numeric, 6).Value = rcDataset.Tables("DispatchList").Rows(i).Item("shlv")
                    rcOleDbCommand.Parameters.Add("@paraDblSe", OleDbType.Numeric, 14).Value = rcDataset.Tables("DispatchList").Rows(i).Item("se")
                    rcOleDbCommand.Parameters.Add("@paraStrXsmemo", OleDbType.VarChar, 50).Value = rcDataset.Tables("DispatchList").Rows(i).Item("xsmemo")
                    rcOleDbCommand.Parameters.Add("@paraStrDdDjh", OleDbType.VarChar, 15).Value = "~"
                    rcOleDbCommand.Parameters.Add("@paraIntDdXh", OleDbType.Integer, 4).Value = 0
                    rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                    rcOleDbCommand.Parameters.Add("@paraCbill_bid", OleDbType.VarChar, 20).Value = rcDataset.Tables("DispatchList").Rows(i).Item("cDLCode")
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
                            ParaStrDjh = Trim(rcOleDbCommand.Parameters("@paraStrDjh").Value)
                        End If
                    End If
                    '检测客户编码
                    If rcDataset.Tables("DispatchList").Rows(i).Item("khdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT khdm FROM rc_khxx WHERE khdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("DispatchList").Rows(i).Item("khdm")
                        If rcDataset.Tables("rc_khxx") IsNot Nothing Then
                            rcDataset.Tables("rc_khxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_khxx")
                        If rcDataset.Tables("rc_khxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_khxx (khdm,khmc,zczb) VALUES (?,?,0)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@khdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("DispatchList").Rows(i).Item("khdm")
                            rcOleDbCommand.Parameters.Add("@khmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("DispatchList").Rows(i).Item("khmc")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    '检测部门编码
                    If rcDataset.Tables("DispatchList").Rows(i).Item("bmdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT bmdm FROM rc_bmxx WHERE bmdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("DispatchList").Rows(i).Item("bmdm")
                        If rcDataset.Tables("rc_bmxx") IsNot Nothing Then
                            rcDataset.Tables("rc_bmxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_bmxx")
                        If rcDataset.Tables("rc_bmxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_bmxx (bmdm,bmmc) VALUES (?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@bmdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("DispatchList").Rows(i).Item("bmdm")
                            rcOleDbCommand.Parameters.Add("@bmmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("DispatchList").Rows(i).Item("bmmc")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    '检测物料编码
                    If rcDataset.Tables("DispatchList").Rows(i).Item("cpdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT cpdm FROM rc_cpxx WHERE cpdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("DispatchList").Rows(i).Item("cpdm")
                        If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                            rcDataset.Tables("rc_cpxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
                        If rcDataset.Tables("rc_cpxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_cpxx (cpdm,cpmc,dw,fzdw) VALUES (?,?,?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("DispatchList").Rows(i).Item("cpdm")
                            rcOleDbCommand.Parameters.Add("@cpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("DispatchList").Rows(i).Item("cpmc")
                            rcOleDbCommand.Parameters.Add("@dw", OleDbType.VarChar, 8).Value = rcDataset.Tables("DispatchList").Rows(i).Item("dw")
                            rcOleDbCommand.Parameters.Add("@fzdw", OleDbType.VarChar, 8).Value = rcDataset.Tables("DispatchList").Rows(i).Item("fzdw")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    '检测仓库编码
                    If rcDataset.Tables("DispatchList").Rows(i).Item("ckdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT ckdm FROM rc_ckxx WHERE ckdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("DispatchList").Rows(i).Item("ckdm")
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_ckxx") IsNot Nothing Then
                            rcDataset.Tables("rc_ckxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_ckxx")
                        If rcDataset.Tables("rc_ckxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_ckxx (ckdm,ckmc) VALUES (?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("DispatchList").Rows(i).Item("ckdm")
                            rcOleDbCommand.Parameters.Add("@ckmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("DispatchList").Rows(i).Item("ckmc")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                Next
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("程序错误。" & Chr(13) & ex.Message)
                Catch ey As OleDbException
                    MsgBox("程序错误。" & Chr(13) & ey.Message)
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        End If
        '调拨出库
        If Me.ChbInvDbd.Checked Then
            '读取调拨出库
            Try
                U8OleDbConn.Open()
                rcOleDbCommand.Connection = U8OleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT TransVouch.*,ISNULL(ComputationUnit.cComUnitName,'') AS fzdw FROM (SELECT TransVouch.cTVCode,TransVouchs.iRowNo,TransVouch.dTVDate AS dbrq,TransVouch.cOWhCode AS cckdm,OWarehouse.cWhName AS cckmc,TransVouch.cIWhCode AS rckdm,IWarehouse.cWhName AS rckmc,TransVouchs.cInvCode AS cpdm,Inventory.cInvName + ',' + ISNULL(Inventory.cInvStd,'') AS cpmc,ComputationUnit.cComUnitName AS dw,ISNULL(Inventory.cAssComUnitCode,'') AS cAssComUnitCode,ISNULL(TransVouchs.cTVBatch,'') AS cTVBatch,TransVouchs.iTVQuantity AS sl,ISNULL(TransVouchs.iTVNum,0.0) AS fzsl,TransVouchs.iTVACost AS dj,TransVouchs.iTVAPrice AS je,ISNULL(TransVouchs.cbMemo,'') AS dbmemo FROM TransVouch,TransVouchs,Warehouse OWarehouse,Warehouse IWarehouse,Inventory,ComputationUnit WHERE TransVouch.ID = TransVouchs.ID AND TransVouch.cOWhCode = OWarehouse.cWhCode AND TransVouch.cIWhCode = IWarehouse.cWhCode AND TransVouchs.cInvCode = Inventory.cInvCode AND Inventory.cComunitCode = ComputationUnit.cComunitCode AND TransVouch.dTVDate <= ? AND TransVouch.dTVDate >= ?) TransVouch LEFT JOIN ComputationUnit ON ComputationUnit.cComunitCode = TransVouch.cAssComUnitCode ORDER BY TransVouch.cTVCode,TransVouch.iRowNo"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@dateEnd", OleDbType.Date, 8).Value = dateEnd
                rcOleDbCommand.Parameters.Add("@dateBegin", OleDbType.Date, 8).Value = dateBegin
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("TransVouch") IsNot Nothing Then
                    Me.rcDataset.Tables("TransVouch").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "TransVouch")
                Me.ProgressBar1.Maximum = rcDataset.Tables("TransVouch").Rows.Count
            Catch ex As Exception
                MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                U8OleDbConn.Close()
            End Try
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                '序列删除再重建
                rcOleDbCommand.CommandText = "DROP SEQUENCE DBDJ" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "CREATE SEQUENCE DBDJ" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0") & " INCREMENT BY 1 START WITH 1 MAXVALUE 99999 MINVALUE 1 NOCYCLE NOCACHE NOORDER"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '更新单据号至0
                rcOleDbCommand.CommandText = "UPDATE rc_lx SET pzno" & Me.NudMonth.Value.ToString.PadLeft(2, "0") & " = 0 WHERE kjnd = ? AND pzlxdm = 'DBDJ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                rcOleDbCommand.ExecuteNonQuery()
                '删除历史单据
                rcOleDbCommand.CommandText = "DELETE FROM inv_dbd WHERE SUBSTR(djh,5,6)= ? AND SUBSTR(djh,1,4) = 'DBDJ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjqj", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.ExecuteNonQuery()
                Me.ProgressBar1.Maximum = rcDataset.Tables("TransVouch").Rows.Count
                Dim oldStrDjh As String = ""
                Dim ParaStrDjh As String = ""
                Dim blnNew As Boolean = False
                For i = 0 To rcDataset.Tables("TransVouch").Rows.Count - 1
                    If oldStrDjh <> rcDataset.Tables("TransVouch").Rows(i).Item("cTVCode") Then
                        blnNew = True
                        oldStrDjh = rcDataset.Tables("TransVouch").Rows(i).Item("cTVCode")
                    Else
                        blnNew = False
                    End If
                    Me.ProgressBar1.Value = i + 1
                    rcOleDbCommand.CommandType = CommandType.StoredProcedure
                    rcOleDbCommand.CommandText = "USP3_SAVE_INV_DBD"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@paraIntIsAdding", OleDbType.Integer, 1).Value = 1
                    rcOleDbCommand.Parameters.Add("@paraStrDjh", OleDbType.VarChar, 15).Value = IIf(blnNew, "DBDJ" & Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0") & "00001", ParaStrDjh)
                    rcOleDbCommand.Parameters("@paraStrDjh").Direction = ParameterDirection.InputOutput
                    rcOleDbCommand.Parameters.Add("@paraIntXh", OleDbType.Integer, 4).Value = IIf(blnNew, 1, rcDataset.Tables("TransVouch").Rows(i).Item("iRowNo"))
                    rcOleDbCommand.Parameters.Add("@paraDateCkrq", OleDbType.Date, 8).Value = rcDataset.Tables("TransVouch").Rows(i).Item("dbrq")
                    rcOleDbCommand.Parameters.Add("@paraBlnDelete", OleDbType.Numeric, 1).Value = 0
                    rcOleDbCommand.Parameters.Add("@paraStrCckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("TransVouch").Rows(i).Item("cckdm")
                    rcOleDbCommand.Parameters.Add("@paraStrCckmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("TransVouch").Rows(i).Item("cckmc")
                    rcOleDbCommand.Parameters.Add("@paraStrRkdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("TransVouch").Rows(i).Item("rckdm")
                    rcOleDbCommand.Parameters.Add("@paraStrRkmc", OleDbType.VarChar, 50).Value = rcDataset.Tables("TransVouch").Rows(i).Item("rckdm")
                    rcOleDbCommand.Parameters.Add("@paraStrZydm", OleDbType.VarChar, 12).Value = ""
                    rcOleDbCommand.Parameters.Add("@paraStrZymc", OleDbType.VarChar, 30).Value = ""
                    rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("TransVouch").Rows(i).Item("cpdm")).ToUpper
                    rcOleDbCommand.Parameters.Add("@paraStrCpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("TransVouch").Rows(i).Item("cpmc")
                    rcOleDbCommand.Parameters.Add("@paraStrCsdm", OleDbType.VarChar, 12).Value = ""
                    rcOleDbCommand.Parameters.Add("@paraStrCsmc", OleDbType.VarChar, 50).Value = ""
                    rcOleDbCommand.Parameters.Add("@paraStrKuwei", OleDbType.VarChar, 40).Value = ""
                    rcOleDbCommand.Parameters.Add("@paraStrPiHao", OleDbType.VarChar, 30).Value = ""
                    rcOleDbCommand.Parameters.Add("@paraDblSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("TransVouch").Rows(i).Item("sl")
                    rcOleDbCommand.Parameters.Add("@paraStrDw", OleDbType.VarChar, 8).Value = rcDataset.Tables("TransVouch").Rows(i).Item("dw")
                    rcOleDbCommand.Parameters.Add("@paraDblMjsl", OleDbType.Numeric, 18).Value = 0.0
                    rcOleDbCommand.Parameters.Add("@paraDblFzsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("TransVouch").Rows(i).Item("fzsl")
                    rcOleDbCommand.Parameters.Add("@paraStrFzdw", OleDbType.VarChar, 8).Value = rcDataset.Tables("TransVouch").Rows(i).Item("fzdw")
                    rcOleDbCommand.Parameters.Add("@paraDblDj", OleDbType.Numeric, 18).Value = 0.0
                    rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = 0.0
                    rcOleDbCommand.Parameters.Add("@paraStrDbmemo", OleDbType.VarChar, 50).Value = rcDataset.Tables("TransVouch").Rows(i).Item("dbmemo")
                    rcOleDbCommand.Parameters.Add("@paraStrLlsqDjh", OleDbType.VarChar, 15).Value = ""
                    rcOleDbCommand.Parameters.Add("@paraIntLlsqXh", OleDbType.Integer, 4).Value = 0
                    rcOleDbCommand.Parameters.Add("@paraStrUserDspName", OleDbType.VarChar, 30).Value = g_User_DspName
                    rcOleDbCommand.Parameters.Add("@paraCbill_bid", OleDbType.VarChar, 20).Value = rcDataset.Tables("TransVouch").Rows(i).Item("cTVCode")
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
                            ParaStrDjh = Trim(rcOleDbCommand.Parameters("@paraStrDjh").Value)
                        End If
                    End If
                    '检测物料编码
                    If rcDataset.Tables("TransVouch").Rows(i).Item("cpdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT cpdm FROM rc_cpxx WHERE cpdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("TransVouch").Rows(i).Item("cpdm")
                        If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                            rcDataset.Tables("rc_cpxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
                        If rcDataset.Tables("rc_cpxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_cpxx (cpdm,cpmc,dw,fzdw) VALUES (?,?,?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("TransVouch").Rows(i).Item("cpdm")
                            rcOleDbCommand.Parameters.Add("@cpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("TransVouch").Rows(i).Item("cpmc")
                            rcOleDbCommand.Parameters.Add("@dw", OleDbType.VarChar, 8).Value = rcDataset.Tables("TransVouch").Rows(i).Item("dw")
                            rcOleDbCommand.Parameters.Add("@fzdw", OleDbType.VarChar, 8).Value = rcDataset.Tables("TransVouch").Rows(i).Item("fzdw")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    '检测仓库编码
                    If rcDataset.Tables("TransVouch").Rows(i).Item("cckdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT ckdm FROM rc_ckxx WHERE ckdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("TransVouch").Rows(i).Item("cckdm")
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_ckxx") IsNot Nothing Then
                            rcDataset.Tables("rc_ckxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_ckxx")
                        If rcDataset.Tables("rc_ckxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_ckxx (ckdm,ckmc) VALUES (?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("TransVouch").Rows(i).Item("cckdm")
                            rcOleDbCommand.Parameters.Add("@ckmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("TransVouch").Rows(i).Item("cckmc")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                    If rcDataset.Tables("TransVouch").Rows(i).Item("rckdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT ckdm FROM rc_ckxx WHERE ckdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("TransVouch").Rows(i).Item("rckdm")
                        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                        If rcDataset.Tables("rc_ckxx") IsNot Nothing Then
                            rcDataset.Tables("rc_ckxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_ckxx")
                        If rcDataset.Tables("rc_ckxx").Rows.Count = 0 Then
                            rcOleDbCommand.CommandText = "INSERT INTO rc_ckxx (ckdm,ckmc) VALUES (?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@ckdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("TransVouch").Rows(i).Item("rckdm")
                            rcOleDbCommand.Parameters.Add("@ckmc", OleDbType.VarChar, 30).Value = rcDataset.Tables("TransVouch").Rows(i).Item("rckmc")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                Next
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("程序错误。" & Chr(13) & ex.Message)
                Catch ey As OleDbException
                    MsgBox("程序错误。" & Chr(13) & ey.Message)
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        End If
        '导入库存期初余额inv_cpyeb
        If Me.ChbKcqcye.Checked Then
            If Me.ChbKcqcye.Enabled = False Then
                MsgBox("非启用年度，不允许读取期初库存。")
                Return
            End If
            Try
                U8OleDbConn.Open()
                rcOleDbCommand.Connection = U8OleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT rdrecord.*,ISNULL(ComputationUnit.cComUnitName,'') AS fzdw FROM (SELECT rdrecord34.ckdm,rdrecord34.cpdm,rdrecord34.cpmc,rdrecord34.dw,rdrecord34.cAssComUnitCode,SUM(rdrecord34.iQuantity) AS sl,SUM(rdrecord34.iNum) AS fzsl,SUM(rdrecord34.iPrice) AS je FROM (SELECT rdrecord34.cWhCode AS ckdm,Warehouse.cWhName AS ckmc,rdrecords34.cInvCode AS cpdm,Inventory.cInvName + ',' + ISNULL(Inventory.cInvStd,'') AS cpmc,ComputationUnit.cComUnitName AS dw,ISNULL(Inventory.cAssComUnitCode,'') AS cAssComUnitCode,rdrecords34.cBatch,rdrecords34.iQuantity,rdrecords34.iNum,rdrecords34.iPrice from rdrecord34,rdrecords34,Warehouse,Inventory,ComputationUnit WHERE rdrecord34.id = rdrecords34.id AND rdrecord34.cWhCode = Warehouse.cWhCode AND rdrecords34.cInvCode = Inventory.cInvCode AND Inventory.cComunitCode = ComputationUnit.cComunitCode AND YEAR(rdrecord34.dDate)= ?) rdrecord34 GROUP BY rdrecord34.ckdm,rdrecord34.cpdm,rdrecord34.cpmc,rdrecord34.dw,rdrecord34.cAssComUnitCode) rdrecord LEFT JOIN ComputationUnit ON ComputationUnit.cComunitCode = rdrecord.cAssComUnitCode"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@intYear", OleDbType.Integer, 4).Value = Me.NudYear.Value
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rdrecord") IsNot Nothing Then
                    Me.rcDataset.Tables("rdrecord").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rdrecord")
                Me.ProgressBar1.Maximum = rcDataset.Tables("rdrecord").Rows.Count
            Catch ex As Exception
                MsgBox("程序错误1。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            Finally
                U8OleDbConn.Close()
            End Try
            Try
                rcOleDbConn.Open()
                rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.Serializable)
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.Transaction = rcOleDbTrans
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                '删除历史期初余额
                rcOleDbCommand.CommandText = "DELETE FROM inv_cpyeb WHERE kjnd = ?"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@kjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                rcOleDbCommand.ExecuteNonQuery()
                Me.ProgressBar1.Maximum = rcDataset.Tables("rdrecord").Rows.Count
                For i = 0 To rcDataset.Tables("rdrecord").Rows.Count - 1
                    Me.ProgressBar1.Value = i + 1
                    rcOleDbCommand.CommandType = CommandType.Text
                    rcOleDbCommand.CommandText = "INSERT INTO inv_cpyeb (kjnd,cpdm,ckdm,qcsl,qcfzsl,qcje) VALUES (?,?,?,?,?,?)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@paraStrKjnd", OleDbType.VarChar, 4).Value = Me.NudYear.Value.ToString
                    rcOleDbCommand.Parameters.Add("@ParaStrCpdm", OleDbType.VarChar, 15).Value = Trim(rcDataset.Tables("rdrecord").Rows(i).Item("cpdm")).ToUpper
                    rcOleDbCommand.Parameters.Add("@ParaStrCkdm", OleDbType.VarChar, 12).Value = rcDataset.Tables("rdrecord").Rows(i).Item("ckdm")
                    rcOleDbCommand.Parameters.Add("@paraDblQcSl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rdrecord").Rows(i).Item("sl")
                    rcOleDbCommand.Parameters.Add("@paraDblFzsl", OleDbType.Numeric, 18).Value = rcDataset.Tables("rdrecord").Rows(i).Item("fzsl")
                    rcOleDbCommand.Parameters.Add("@paraDblJe", OleDbType.Numeric, 14).Value = rcDataset.Tables("rdrecord").Rows(i).Item("je")
                    rcOleDbCommand.ExecuteNonQuery()
                    '检测物料编码
                    If rcDataset.Tables("rdrecord").Rows(i).Item("cpdm") <> "~" Then
                        rcOleDbCommand.CommandType = CommandType.Text
                        rcOleDbCommand.CommandText = "SELECT cpdm FROM rc_cpxx WHERE cpdm = ?"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("rdrecord").Rows(i).Item("cpdm")
                        If rcDataset.Tables("rc_cpxx") IsNot Nothing Then
                            rcDataset.Tables("rc_cpxx").Clear()
                        End If
                        rcOleDbDataAdpt.Fill(rcDataset, "rc_cpxx")
                        If rcDataset.Tables("rc_cpxx").Rows.Count = 0 Then
                            'MsgBox(rcDataset.Tables("rdrecord").Rows(i).Item("dw"))
                            rcOleDbCommand.CommandText = "INSERT INTO rc_cpxx (cpdm,cpmc,dw,fzdw) VALUES (?,?,?,?)"
                            rcOleDbCommand.Parameters.Clear()
                            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataset.Tables("rdrecord").Rows(i).Item("cpdm")
                            rcOleDbCommand.Parameters.Add("@cpmc", OleDbType.VarChar, 200).Value = rcDataset.Tables("rdrecord").Rows(i).Item("cpmc")
                            rcOleDbCommand.Parameters.Add("@dw", OleDbType.VarChar, 8).Value = rcDataset.Tables("rdrecord").Rows(i).Item("dw")
                            rcOleDbCommand.Parameters.Add("@fzdw", OleDbType.VarChar, 8).Value = rcDataset.Tables("rdrecord").Rows(i).Item("fzdw")
                            rcOleDbCommand.ExecuteNonQuery()
                        End If
                    End If
                Next
                rcOleDbTrans.Commit()
            Catch ex As Exception
                Try
                    rcOleDbTrans.Rollback()
                    MsgBox("程序错误。" & Chr(13) & ex.Message)
                Catch ey As OleDbException
                    MsgBox("程序错误。" & Chr(13) & ey.Message)
                End Try
                Return
            Finally
                rcOleDbConn.Close()
            End Try
        End If

        MsgBox("数据读入完成,请检查数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
    End Sub
End Class