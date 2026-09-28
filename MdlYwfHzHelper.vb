Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports Microsoft.Office.Interop

'按账套业务费报表公共函数
Public Module MdlYwfHzHelper

    '总计行占用的账套编码，保证排序时排在最后
    Public Const StrTotalDwdm As String = "ZZZZ"

    '账套列表项格式为 "dwdm dwmc"
    Public Function DwdmOf(ByVal item As String) As String
        Dim nPos As Integer = item.IndexOf(" ")
        If nPos > 0 Then
            Return item.Substring(0, nPos).Trim
        End If
        Return Trim(item)
    End Function

    Public Function DwmcOf(ByVal item As String) As String
        Dim nPos As Integer = item.IndexOf(" ")
        If nPos >= 0 Then
            Return Trim(item.Substring(nPos + 1))
        End If
        Return ""
    End Function

    '用于拼接 rcdata_<dwdm> 的账套编码
    Public Function DwdmOfSafe(ByVal item As String) As String
        Dim strDwdm As String = DwdmOf(item)
        '仅允许字母、数字和下划线，避免非法字符进入对象名称
        For i As Integer = 0 To strDwdm.Length - 1
            If Not (Char.IsLetterOrDigit(strDwdm.Substring(i, 1)) OrElse strDwdm.Substring(i, 1) = "_") Then
                Return ""
            End If
        Next
        If strDwdm.Length = 0 OrElse strDwdm.Length > 30 Then
            Return ""
        End If
        Return strDwdm
    End Function

    '读取当前用户授权的核算单位，装入预选列表框
    Public Sub LoadAuthorizedDwdm(ByVal lstYuxuanDwdm As ListBox)
        Dim rcOleDbDataAdpt As New OleDbDataAdapter
        Dim rcDataset As New DataSet
        Dim rcOleDbCommand As OleDbCommand = sysOleDbConn.CreateCommand()
        Try
            sysOleDbConn.Open()
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT dwdm,dwmc,userid FROM rc_dwdm WHERE dwdm IN (SELECT code AS dwdm from rc_userqx WHERE righttype = 'DWDM' and User_Account = ?) order by dwdm"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@User_Account", OleDbType.VarChar, 30).Value = g_User_Account
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            rcOleDbDataAdpt.Fill(rcDataset, "rc_dwdm")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            sysOleDbConn.Close()
        End Try
        lstYuxuanDwdm.Items.Clear()
        For i As Integer = 0 To rcDataset.Tables("rc_dwdm").Rows.Count - 1
            lstYuxuanDwdm.Items.Add(rcDataset.Tables("rc_dwdm").Rows(i).Item("dwdm") & " " & rcDataset.Tables("rc_dwdm").Rows(i).Item("dwmc"))
        Next
    End Sub

    '把选中的项目从左侧列表移到右侧列表
    Public Sub MoveOneTo(ByVal lstFrom As ListBox, ByVal lstTo As ListBox)
        If lstFrom.SelectedItems.Count > 0 Then
            lstTo.Items.Add(lstFrom.SelectedItem)
            lstFrom.Items.Remove(lstFrom.SelectedItem)
        End If
    End Sub

    '把左侧列表全部移到右侧列表
    Public Sub MoveAllTo(ByVal lstFrom As ListBox, ByVal lstTo As ListBox)
        Do While lstFrom.Items.Count > 0
            lstTo.Items.Add(lstFrom.Items(0))
            lstFrom.Items.Remove(lstFrom.Items(0))
        Loop
    End Sub

    '已选账套的合法编码
    Public Function SelectedDwdmArr(ByVal lstYixuanDwdm As ListBox) As String()
        Dim strArr As New List(Of String)
        For i As Integer = 0 To lstYixuanDwdm.Items.Count - 1
            Dim strDwdm As String = DwdmOfSafe(lstYixuanDwdm.Items(i).ToString)
            If strDwdm.Length > 0 Then
                strArr.Add(strDwdm)
            End If
        Next
        Return strArr.ToArray()
    End Function

    '创建全局临时表，已存在时先删除
    Public Sub CreateGlobalTempTable(ByVal rcOleDbCommand As OleDbCommand, ByVal rcOleDbDataAdpt As OleDbDataAdapter, ByVal rcDataset As DataSet, ByVal strTableName As String, ByVal strColumns As String)
        rcOleDbCommand.CommandText = "SELECT * FROM user_tables WHERE table_name='" & strTableName.ToUpper & "'"
        rcOleDbCommand.Parameters.Clear()
        rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
        If rcDataset.Tables("user_tables") IsNot Nothing Then
            rcDataset.Tables("user_tables").Clear()
        End If
        rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
        If rcDataset.Tables("user_tables").Rows.Count > 0 Then
            rcOleDbCommand.CommandText = "DROP Table " & strTableName
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.ExecuteNonQuery()
        End If
        rcOleDbCommand.CommandText = "Create Global Temporary Table " & strTableName & " (" & strColumns & ") on Commit delete Rows"
        rcOleDbCommand.Parameters.Clear()
        rcOleDbCommand.ExecuteNonQuery()
    End Sub

    '校验职员编码在所选账套中均存在，返回空串表示通过，否则返回缺失账套说明
    Public Function CheckZydmAllDwdm(ByVal strDwdmArr() As String, ByVal strZydm As String) As String
        If String.IsNullOrEmpty(strZydm) OrElse strDwdmArr.Length = 0 Then
            Return ""
        End If
        Dim rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
        Dim rcOleDbDataAdpt As New OleDbDataAdapter
        Dim rcDataset As New DataSet
        Dim strMiss As New List(Of String)
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            For Each strDwdm As String In strDwdmArr
                rcOleDbCommand.CommandText = "SELECT zydm FROM rcdata_" & strDwdm & ".rc_zyxx WHERE (zydm = ?)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@zydm", OleDbType.VarChar, 12).Value = strZydm
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("rc_zyxx") IsNot Nothing Then
                    rcDataset.Tables("rc_zyxx").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "rc_zyxx")
                If rcDataset.Tables("rc_zyxx").Rows.Count = 0 Then
                    strMiss.Add(strDwdm)
                End If
            Next
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return strZydm
        Finally
            rcOleDbConn.Close()
        End Try
        If strMiss.Count > 0 Then
            Return String.Join("、", strMiss.ToArray())
        End If
        Return ""
    End Function

    '取得 Excel 中不重复且不超过31个字符的工作表名
    Public Function MakeSheetName(ByVal strName As String, ByVal lstUsed As List(Of String)) As String
        Dim strBase As String
        If String.IsNullOrEmpty(Trim(strName)) Then
            strBase = "Sheet"
        Else
            strBase = Trim(strName)
        End If
        strBase = strBase.Replace("'", "").Replace("[", "").Replace("]", "").Replace(":", "").Replace("\", "").Replace("/", "").Replace("*", "").Replace("?", "")
        If strBase.Length > 28 Then
            strBase = strBase.Substring(0, 28)
        End If
        If strBase.Length = 0 Then
            strBase = "Sheet"
        End If
        Dim strTry As String = strBase
        Dim nIndex As Integer = 1
        Do While lstUsed.Contains(strTry)
            strTry = strBase & "_" & nIndex.ToString
            nIndex += 1
        Loop
        lstUsed.Add(strTry)
        Return strTry
    End Function

    '是否输出列：以“_”开头的列(如 _px)为内部排序用，不输出
    Private Function IsOutputColumn(ByVal rcDataColumn As DataColumn) As Boolean
        Return Not rcDataColumn.ColumnName.StartsWith("_")
    End Function

    '把 DataView 输出到 Excel 指定工作表，首行为列名
    'strCaption1/strValue1、strCaption2/strValue2 非空时，在最前面增加两列
    Public Sub WriteDataViewToSheet(ByVal rcExcelWorksheet As Excel.Worksheet, ByVal rcDataView As DataView, ByVal strCaption1 As String, ByVal strValue1 As String, ByVal strCaption2 As String, ByVal strValue2 As String)
        Dim intRow As Integer = 1
        Dim intCol As Integer = 0
        If strCaption1.Length > 0 Then
            intCol = 1
            rcExcelWorksheet.Cells(1, 1) = strCaption1
        End If
        If strCaption2.Length > 0 Then
            intCol = 2
            rcExcelWorksheet.Cells(1, 2) = strCaption2
        End If
        Dim intStart As Integer = intCol
        For Each rcDataColumn As DataColumn In rcDataView.Table.Columns
            If Not IsOutputColumn(rcDataColumn) Then
                Continue For
            End If
            intCol += 1
            rcExcelWorksheet.Cells(1, intCol) = rcDataColumn.ColumnName
        Next
        For j As Integer = 0 To rcDataView.Count - 1
            Dim rcDataRowView As DataRowView = rcDataView.Item(j)
            If rcDataRowView.Row.RowState <> DataRowState.Deleted Then
                intRow += 1
                intCol = intStart
                If strCaption1.Length > 0 Then
                    rcExcelWorksheet.Cells(intRow, 1) = "'" & strValue1
                End If
                If strCaption2.Length > 0 Then
                    rcExcelWorksheet.Cells(intRow, 2) = "'" & strValue2
                End If
                For Each rcDataColumn As DataColumn In rcDataView.Table.Columns
                    If Not IsOutputColumn(rcDataColumn) Then
                        Continue For
                    End If
                    intCol += 1
                    Dim objValue As Object = rcDataRowView.Row.Item(rcDataColumn.ColumnName)
                    If objValue Is DBNull.Value Then
                        rcExcelWorksheet.Cells(intRow, intCol) = ""
                    ElseIf objValue.GetType.ToString = "System.String" Then
                        rcExcelWorksheet.Cells(intRow, intCol) = "'" & Trim(CStr(objValue))
                    Else
                        rcExcelWorksheet.Cells(intRow, intCol) = objValue
                    End If
                Next
            End If
        Next
        '首行加粗并自适应列宽
        If intCol > 0 Then
            rcExcelWorksheet.Cells(1, 1, 1, intCol).Font.Bold = True
        End If
        rcExcelWorksheet.Columns.AutoFit()
    End Sub

End Module
