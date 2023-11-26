Imports System.Text
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.Data.OleDb

Public Class Form2
    Inherits Form

    Private employees As New List(Of Employee)
    Private tasks As New List(Of Task)
    Private WithEvents reportButton As New Button
    Friend WithEvents rcTimer As Timer
    Private components As System.ComponentModel.IContainer
    Private WithEvents dataGridView1 As New DataGridView
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '表示要在数据源执行的 SQL 事务
    Dim rcOleDbTrans As OleDbTransaction
    Friend WithEvents btnStart As Button
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()



    '<STAThread()>
    'Public Sub Main()
    '    Application.Run(New Form1)
    'End Sub

    Sub New()
        dataGridView1.Dock = DockStyle.Fill
        dataGridView1.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.AllCells
        reportButton.Text = "Generate Report"
        reportButton.Dock = DockStyle.Top

        Controls.Add(dataGridView1)
        Controls.Add(reportButton)
        Controls.Add(btnStart)
        Text = "DataGridViewComboBoxColumn Demo"
    End Sub

    ' Initializes the data source and populates the DataGridView control.
    Private Sub Form1_Load(ByVal sender As Object,
        ByVal e As EventArgs) Handles Me.Load

        PopulateLists()
        dataGridView1.AutoGenerateColumns = False
        dataGridView1.DataSource = tasks
        AddColumns()

    End Sub

    ' Populates the employees and tasks lists. 
    Private Sub PopulateLists()
        employees.Add(New Employee("Harry"))
        employees.Add(New Employee("Sally"))
        employees.Add(New Employee("Roy"))
        employees.Add(New Employee("Pris"))
        tasks.Add(New Task(1, employees(1)))
        tasks.Add(New Task(2))
        tasks.Add(New Task(3, employees(2)))
        tasks.Add(New Task(4))
    End Sub

    ' Configures columns for the DataGridView control.
    Private Sub AddColumns()

        Dim idColumn As New DataGridViewTextBoxColumn()
        idColumn.Name = "Task"
        idColumn.DataPropertyName = "Id"
        idColumn.ReadOnly = True

        Dim assignedToColumn As New DataGridViewComboBoxColumn()

        ' Populate the combo box drop-down list with Employee objects. 
        For Each e As Employee In employees
            assignedToColumn.Items.Add(e)
        Next

        ' Add "unassigned" to the drop-down list and display it for 
        ' empty AssignedTo values or when the user presses CTRL+0. 
        assignedToColumn.Items.Add("unassigned")
        assignedToColumn.DefaultCellStyle.NullValue = "unassigned"

        assignedToColumn.Name = "Assigned To"
        assignedToColumn.DataPropertyName = "AssignedTo"
        assignedToColumn.AutoComplete = True
        assignedToColumn.DisplayMember = "Name"
        assignedToColumn.ValueMember = "Self"

        ' Add a button column. 
        Dim buttonColumn As New DataGridViewButtonColumn()
        buttonColumn.HeaderText = ""
        buttonColumn.Name = "Status Request"
        buttonColumn.Text = "Request Status"
        buttonColumn.UseColumnTextForButtonValue = True

        dataGridView1.Columns.Add(idColumn)
        dataGridView1.Columns.Add(assignedToColumn)
        dataGridView1.Columns.Add(buttonColumn)

    End Sub

    ' Reports on task assignments. 
    Private Sub reportButton_Click(ByVal sender As Object,
        ByVal e As EventArgs) Handles reportButton.Click

        Dim report As New StringBuilder()
        For Each t As Task In tasks
            Dim assignment As String
            If t.AssignedTo Is Nothing Then
                assignment = "unassigned"
            Else
                assignment = "assigned to " + t.AssignedTo.Name
            End If
            report.AppendFormat("Task {0} is {1}.", t.Id, assignment)
            report.Append(Environment.NewLine)
        Next
        MessageBox.Show(report.ToString(), "Task Assignments")

    End Sub

    ' Calls the Employee.RequestStatus method.
    Private Sub dataGridView1_CellClick(ByVal sender As Object,
        ByVal e As DataGridViewCellEventArgs) _
        Handles dataGridView1.CellClick

        ' Ignore clicks that are not on button cells. 
        If e.RowIndex < 0 OrElse Not e.ColumnIndex =
            dataGridView1.Columns("Status Request").Index Then Return

        ' Retrieve the task ID.
        Dim taskID As Int32 = CInt(dataGridView1(0, e.RowIndex).Value)

        ' Retrieve the Employee object from the "Assigned To" cell.
        Dim assignedTo As Employee = TryCast(dataGridView1.Rows(e.RowIndex) _
            .Cells("Assigned To").Value, Employee)

        ' Request status through the Employee object if present. 
        If assignedTo IsNot Nothing Then
            assignedTo.RequestStatus(taskID)
        Else
            MessageBox.Show(String.Format(
                "Task {0} is unassigned.", taskID), "Status Request")
        End If

    End Sub

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.rcTimer = New System.Windows.Forms.Timer(Me.components)
        Me.btnStart = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'rcTimer
        '
        Me.rcTimer.Interval = 60000
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(97, 312)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "开始"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.ClientSize = New System.Drawing.Size(284, 361)
        Me.Controls.Add(Me.btnStart)
        Me.Name = "Form2"
        Me.ResumeLayout(False)

    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        If Me.rcTimer.Enabled Then
            Me.rcTimer.Enabled = False
            Me.btnStart.Text = "开始"
        Else
            Me.rcTimer.Enabled = True
            Me.btnStart.Text = "停止"
        End If
    End Sub

    Private Sub rcTimer_Tick(sender As Object, e As EventArgs) Handles rcTimer.Tick
        '取需要发送的数据
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "select po_cgjh.djh,po_cgjh.jhrq,po_cgjh.srrq,po_cgjh.cpdm,rc_cpxx.cpmc,rc_cpxx.dw,po_cgjh.sl,rc_cpxx.cgdj from po_cgjh,rc_cpxx where po_cgjh.cpdm = rc_cpxx.cpdm and po_cgjh.bsenddingtalk <> 1 and po_cgjh.srrq >= sysdate-1 "
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("po_cgjh") IsNot Nothing Then
                rcDataset.Tables("po_cgjh").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "po_cgjh")
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" + ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        Dim i As Integer
        For i = 0 To rcDataset.Tables("po_cgjh").Rows.Count - 1


            '默认用锐创的ID
            Dim strCorpId As String = "ding07ca8170052d3e7c35c2f4657eb6378f"
            Dim strCorpSecret As String = "30-lK1YrUpsmz6ysYUPd30SWlZVVOFEShKa3HtWuFcA_4RxwnVUUBUIEMlFLTvzF"
            Dim strChatId As String = "chat62f80f55f531375b9a4e3a3d1b67469c"
            Try
                '取钉钉corpid,corpsecret
                'Try
                '    rcOleDbConn.Open()
                '    rcOleDbCommand.Connection = rcOleDbConn
                '    rcOleDbCommand.CommandTimeout = 300
                '    rcOleDbCommand.CommandType = CommandType.Text
                '    rcOleDbCommand.CommandText = "SELECT paraid,parastrvalue,paradblvalue FROM rc_para WHERE SUBSTR(paraid,1,2) = '钉钉' Order by paraid"
                '    rcOleDbCommand.Parameters.Clear()
                '    rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                '    If rcDataset.Tables("rc_para") IsNot Nothing Then
                '        rcDataset.Tables("rc_para").Clear()
                '    End If
                '    rcOleDbDataAdpt.Fill(rcDataset, "rc_para")
                'Catch ex As Exception
                '    MsgBox("程序错误。" & Chr(13) & ex.Message)
                'Finally
                '    rcOleDbConn.Close()
                'End Try
                'If rcDataset.Tables("rc_para").Rows.Count = 3 Then
                '    If rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                '        strChatId = rcDataset.Tables("rc_para").Rows(0).Item("parastrvalue")
                '    End If
                '    If rcDataset.Tables("rc_para").Rows(1).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                '        strCorpId = rcDataset.Tables("rc_para").Rows(1).Item("parastrvalue")
                '    End If
                '    If rcDataset.Tables("rc_para").Rows(2).Item("parastrvalue").GetType.ToString <> "System.DBNull" Then
                '        strCorpSecret = rcDataset.Tables("rc_para").Rows(2).Item("parastrvalue")
                '    End If
                'End If


                '钉钉测试
                Dim request As System.Net.HttpWebRequest = System.Net.WebRequest.Create("https://oapi.dingtalk.com/gettoken" + "?" + "corpid=" & strCorpId & "&corpsecret=" & strCorpSecret)
                request.Method = "GET"
                Dim sr As System.IO.StreamReader = New System.IO.StreamReader(request.GetResponse().GetResponseStream)
                Dim str As String = sr.ReadToEnd
                'MsgBox(str)
                'Dim aaa As ClsDdAccess_Token
                Dim bbb As New Newtonsoft.Json.Linq.JObject
                bbb = Newtonsoft.Json.JsonConvert.DeserializeObject(str)
                Dim fff As Newtonsoft.Json.Linq.JObject
                Dim eee As New Newtonsoft.Json.Linq.JArray
                fff = CType(Newtonsoft.Json.JsonConvert.DeserializeObject(str), Newtonsoft.Json.Linq.JObject)
                Dim msg As String = fff("access_token").ToString

                Dim ddd As String = ""
                ddd = "{" & Chr(34) & "chatid" & Chr(34) & ":" & Chr(34) & strChatId & Chr(34) & "," & Chr(34) & "msgtype" & Chr(34) & ":" & Chr(34) & "text" & Chr(34) & "," & Chr(34) & "text" & Chr(34) & ":{" & Chr(34) & "content" & Chr(34) & ":" & Chr(34) & rcDataset.Tables("po_cgjh").Rows(i).Item("cpmc") & "需采购" & rcDataset.Tables("po_cgjh").Rows(i).Item("sl").ToString & Chr(34) & "}}"
                'MsgBox(ddd)
                ' create a request
                Dim request1 As System.Net.HttpWebRequest = CType(System.Net.WebRequest.Create("https://oapi.dingtalk.com/chat/send?access_token=" + msg), System.Net.HttpWebRequest)
                request1.KeepAlive = False
                request1.ProtocolVersion = System.Net.HttpVersion.Version10
                request1.Method = "POST"


                ' turn our request1 string into a byte stream
                Dim postBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(ddd)

                ' this is important - make sure you specify type this way
                request1.ContentType = "application/json; charset=UTF-8"
                request1.Accept = "application/json"
                request1.ContentLength = postBytes.Length
                'request1.CookieContainer = Cookies
                'request1.UserAgent = currentUserAgent
                Dim requestStream As System.IO.Stream = request1.GetRequestStream()

                ' now send it
                requestStream.Write(postBytes, 0, postBytes.Length)
                requestStream.Close()


                ' grab te response and print it out to the console along with the status code
                Dim response As System.Net.HttpWebResponse = CType(request1.GetResponse(), System.Net.HttpWebResponse)
                Dim rdr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
                Dim result As String = rdr.ReadToEnd()
                MsgBox(result)

            Catch ex As Exception
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Threading.Thread.Sleep(5000)
        Next
    End Sub
End Class