Imports System.IO
Imports System.Net
Imports System.Reflection
Imports System.Text

Public Class Form1

    Public Sub MMMToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MMMToolStripMenuItem.Click
        MsgBox("menu click")
    End Sub

    '在按钮事件处理里面通过反射名称调用相应菜单事件
    Public Sub CallEventMethod(ByVal sender As Object, ByVal e As EventArgs)
        Dim b As Button = sender '获取点击的按钮
        '拼接菜单事件名称
        Dim MethodName As String = b.Name & "ToolStripMenuItem_Click"
        Dim t As Type = Me.GetType
        Dim m As MethodInfo = t.GetMethod(MethodName)
        '反射方法
        m.Invoke(Me, New Object() {Nothing, Nothing})
    End Sub

    '动态生成了按钮
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Dim btn As New Button
        btn.Location = New Point(100, 100)
        btn.Name = "MMM" '关键
        btn.Text = "MMM"
        '注册事件
        AddHandler btn.Click, AddressOf Me.CallEventMethod
        Me.Controls.Add(btn)
    End Sub

    Public Structure JsonUser
        Public companycode As String
        Public companypassword As String
    End Structure

    Public Structure JsonBus
        Public access_token As String
        Public basicInfo As String
        Public vehiclepartslist As String
        Public repairprojectlist As String
    End Structure
    Public Structure JsonBasicInfo
        Public vehicleplatenumber As String
        Public companyname As String
        Public vin As String
        Public repairdate As String
        Public repairmileage As String
        Public settledate As String
        Public faultdescription As String
        Public costlistcode As String
    End Structure
    Public Structure JsonVehiclepartslist
        Public partscode As String
        Public partsquantity As Double
        Public partsname As String
    End Structure

    Public Structure JsonRepairProjectList
        Public repairproject As String
        Public workinghours As Double
    End Structure
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            '读取Access_Token
            Dim a As New JsonUser
            a.companycode = "330103000056746"
            a.companypassword = "sq123456"
            Dim ddd As String = ""
            ddd = Newtonsoft.Json.JsonConvert.SerializeObject(a)

            Dim postBytes As Byte() = Encoding.UTF8.GetBytes(ddd)

            Dim request As System.Net.HttpWebRequest = System.Net.WebRequest.Create("https://qcda.96520.com/restservices/lcipprodatarest/lcipprogetaccesstoken/query")
            request.Method = "POST"
            request.ContentLength = postBytes.Length
            request.ContentType = "application/json"
            Dim requestStream As System.IO.Stream = request.GetRequestStream()
            'now send it
            requestStream.Write(postBytes, 0, postBytes.Length)
            requestStream.Close()

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
            MsgBox(msg)
            '创建需发送的文本
            Dim jsonBasicInfo As New JsonBasicInfo
            jsonBasicInfo.vehicleplatenumber = "浙A5L570"
            jsonBasicInfo.companyname = "杭州公共交通集团有限公司"
            jsonBasicInfo.vin = "LA6C1GAE8GC301093"
            jsonBasicInfo.repairdate = "20210822"
            jsonBasicInfo.repairmileage = "77015"
            jsonBasicInfo.settledate = "20210822"
            jsonBasicInfo.faultdescription = "报告编码{330100112108211315501011}"
            jsonBasicInfo.costlistcode = "992108220001"
            Dim aaa1 As String = ""
            aaa1 = Newtonsoft.Json.JsonConvert.SerializeObject(jsonBasicInfo)
            MsgBox(aaa1)

            Dim jsonVehiclepartslist(0) As JsonVehiclepartslist
            jsonVehiclepartslist(0).partscode = "1-2012-LG1"
            jsonVehiclepartslist(0).partsquantity = 1.0
            jsonVehiclepartslist(0).partsname = "尿素泵（计量喷射泵）"
            Dim bbb1 As String = ""
            bbb1 = Newtonsoft.Json.JsonConvert.SerializeObject(jsonVehiclepartslist)
            MsgBox(bbb1)

            Dim jsonRepairProjectList(0) As JsonRepairProjectList
            jsonRepairProjectList(0).repairproject = "小修"
            jsonRepairProjectList(0).workinghours = 1
            Dim ccc1 As String = ""
            ccc1 = Newtonsoft.Json.JsonConvert.SerializeObject(jsonRepairProjectList)
            MsgBox(ccc1)

            Dim jsonBus As New JsonBus
            jsonBus.access_token = msg
            jsonBus.basicInfo = aaa1
            jsonBus.vehiclepartslist = bbb1
            jsonBus.repairprojectlist = ccc1

            Dim ddd1 As String = ""
            ddd1 = Newtonsoft.Json.JsonConvert.SerializeObject(jsonBus)
            MsgBox(ddd1)

            ' turn our request1 string into a byte stream
            Dim postBytes1 As Byte() = System.Text.Encoding.UTF8.GetBytes(ddd1)

            ' create a request
            Dim request1 As System.Net.HttpWebRequest = CType(System.Net.WebRequest.Create("https://qcda.96520.com/restservices/lcipprodatarest/lcipprocarfixrecordadd/query"), System.Net.HttpWebRequest)
            request1.Method = "POST"
            request1.ContentLength = postBytes1.Length
            request1.ContentType = "application/json"
            Dim requestStream1 As System.IO.Stream = request1.GetRequestStream()

            'now send it
            requestStream1.Write(postBytes1, 0, postBytes1.Length)
            requestStream1.Close()

            ' grab te response and print it out to the console along with the status code
            Dim response1 As System.Net.HttpWebResponse = CType(request1.GetResponse(), System.Net.HttpWebResponse)
            Dim rdr As System.IO.StreamReader = New System.IO.StreamReader(response1.GetResponseStream())
            Dim result As String = rdr.ReadToEnd()
            MsgBox(result)

        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        End Try
    End Sub

End Class