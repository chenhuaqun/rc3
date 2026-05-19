Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization

'辅助核算项
<Serializable()>
Public Class AssItem
    <XmlElement("pk_Checktype")>
    Public Property CheckType As String '辅助核算类型
    <XmlElement("pk_Checkvalue")>
    Public Property CheckValue As String '辅助核算值

    Public Sub New()

    End Sub

    Public Sub New(checkType As String, checkValue As String)
        Me.CheckType = checkType
        Me.CheckValue = checkValue
    End Sub
End Class

'辅助核算集合
<Serializable()>
Public Class AssCollection
    <XmlElement("item")>
    Public Property Items As List(Of AssItem)
    Public Sub New()
        Items = New List(Of AssItem)()
    End Sub
    Public Sub AddItem(item As AssItem)
        Items.Add(item)
    End Sub

End Class

'现金流量项
<Serializable()>
Public Class CashFlowItem
    <XmlElement("m_pk_currtype")>
    Public Property CurrencyType As String '币种
    <XmlElement("money")>
    Public Property Money As String '金额
    <XmlElement("moneyglobal")>
    Public Property MoneyGlobal As String '全局金额
    <XmlElement("moneygroup")>
    Public Property MoneyGroup As String '集团金额
    <XmlElement("moneymain")>
    Public Property MoneyMain As String '本位币金额
    <XmlElement("pk_cashflow")>
    Public Property CashFlowCode As String '现金流量编码
    <XmlElement("pk_innercorp")>
    Public Property InnerCorp As String '内部组织
    Public Sub New()
    End Sub
    Public Sub New(currencyType As String, money As String, moneyGlobal As String, moneyGroup As String, moneyMain As String, cashFlowCode As String, innerCorp As String)
        Me.CurrencyType = currencyType
        Me.Money = money
        Me.MoneyGlobal = moneyGlobal
        Me.MoneyGroup = moneyGroup
        Me.MoneyMain = moneyMain
        Me.CashFlowCode = cashFlowCode
        Me.InnerCorp = innerCorp
    End Sub
End Class

'现金流量集合
<Serializable()>
Public Class CashFlowCollection
    <XmlElement("item")>
    Public Property Items As List(Of CashFlowItem)
    Public Sub New()
        Items = New List(Of CashFlowItem)()
    End Sub
    Public Sub AddItem(item As CashFlowItem)
        Items.Add(item)
    End Sub
End Class

'欧盟VAT明细
<Serializable()>
Public Class VatDetail
    <XmlElement("businesscode")>
    Public Property BusinessCode As String '业务类型编码
    <XmlElement("pk_receivecountry")>
    Public Property ReceiveCountry As String '收款国别
    <XmlElement("pk_suppliervatcode")>
    Public Property SupplierVatCode As String '供应商VAT编码
    <XmlElement("pk_taxcode")>
    Public Property TaxCode As String '税种
    <XmlElement("pk_clientvatcode")>
    Public Property ClientVatCode As String '客户VAT编码
    <XmlElement("direction")>
    Public Property Direction As String '方向
    <XmlElement("moneyamount")>
    Public Property MoneyAmount As String '金额
    <XmlElement("pk_vatcountry")>
    Public Property VatCountry As String 'VAT国别
    <XmlElement("taxamount")>
    Public Property TaxAmount As String '税额
    Public Sub New()
    End Sub
    Public Sub New(businessCode As String, receiveCountry As String, supplierVatCode As String, taxCode As String, clientVatCode As String, direction As String, moneyAmount As String, vatCountry As String, taxAmount As String)
        Me.BusinessCode = businessCode
        Me.ReceiveCountry = receiveCountry
        Me.SupplierVatCode = supplierVatCode
        Me.TaxCode = taxCode
        Me.ClientVatCode = clientVatCode
        Me.Direction = direction
        Me.MoneyAmount = moneyAmount
        Me.VatCountry = vatCountry
        Me.TaxAmount = taxAmount
    End Sub
End Class

'凭证分录项
<Serializable()>
Public Class VoucherItem
    <XmlElement("detailindex")>
    Public Property DetailIndex As String '分录序号
    <XmlElement("explanation")>
    Public Property Explanation As String '摘要
    <XmlElement("verifydate")>
    Public Property VerifyDate As String '核销日期
    <XmlElement("price")>
    Public Property Price As String '单价
    <XmlElement("excrate2")>
    Public Property Excrate2 As String '汇率2
    '借方相关字段
    <XmlElement("debitquantity")>
    Public Property DebitQuantity As String '借方数量
    <XmlElement("debitamount")>
    Public Property DebitAmount As String '借方金额
    <XmlElement("localdebitamount")>
    Public Property LocalDebitAmount As String '本币借方金额
    <XmlElement("groupdebitamount")>
    Public Property GroupDebitAmount As String '集团借方金额
    <XmlElement("globaldebitamount")>
    Public Property GlobalDebitAmount As String '全局借方金额
    '贷方相关字段
    <XmlElement("creditquantity")>
    Public Property CreditQuantity As String '贷方数量
    <XmlElement("creditamount")>
    Public Property CreditAmount As String '贷方金额
    <XmlElement("localcreditamount")>
    Public Property LocalCreditAmount As String '本币贷方金额
    <XmlElement("groupcreditamount")>
    Public Property GroupCreditAmount As String '集团贷方金额
    <XmlElement("globalcreditamount")>
    Public Property GlobalCreditAmount As String '全局贷方金额
    <XmlElement("pk_currtype")>
    Public Property CurrencyType As String '币种
    <XmlElement("pk_accasoa")>
    Public Property AccountCode As String '科目编码
    <XmlElement("pk_unit")>
    Public Property UnitCode As String '核算单位编码
    <XmlElement("pk_unit_v")>
    Public Property UnitCodeV As String '核算单位版本编码
    <XmlElement("ass")>
    Public Property Ass As AssCollection '辅助核算集合
    <XmlElement("vatdetail")>
    Public Property VatDetail As VatDetail
    <XmlElement("cashFlow")>
    Public Property CashFlow As CashFlowCollection

    Public Sub New()
        Ass = New AssCollection()
        CashFlow = New CashFlowCollection
    End Sub
End Class

'凭证分录集合
<Serializable()>
Public Class VoucherDetails
    <XmlElement("item")>
    Public Property Items As List(Of VoucherItem)

    Public Sub New()
        Items = New List(Of VoucherItem)()
    End Sub

    Public Sub AddItem(item As VoucherItem)
        Items.Add(item)
    End Sub
End Class

'凭证头信息
<Serializable()>
Public Class VoucherHead
    <XmlElement("pk_voucher")>
    Public Property VoucherId As String
    <XmlElement("pk_vouchertype")>
    Public Property VoucherType As String
    <XmlElement("year")>
    Public Property Year As String

    <XmlElement("pk_system")>
    Public Property System As String

    <XmlElement("voucherkind")>
    Public Property VoucherKind As String

    <XmlElement("pk_accountingbook")>
    Public Property AccountingBook As String

    <XmlElement("discardflag")>
    Public Property DiscardFlag As String

    <XmlElement("period")>
    Public Property Period As String

    <XmlElement("no")>
    Public Property Number As String

    <XmlElement("attachment")>
    Public Property Attachment As String

    <XmlElement("prepareddate")>
    Public Property PreparedDate As String

    <XmlElement("pk_prepared")>
    Public Property PreparedBy As String

    <XmlElement("pk_casher")>
    Public Property Casher As String

    <XmlElement("signflag")>
    Public Property SignFlag As String

    <XmlElement("pk_checked")>
    Public Property CheckedBy As String

    <XmlElement("tallydate")>
    Public Property TallyDate As String

    <XmlElement("pk_manager")>
    Public Property Manager As String

    <XmlElement("memo1")>
    Public Property Memo1 As String

    <XmlElement("memo2")>
    Public Property Memo2 As String

    <XmlElement("reserve1")>
    Public Property Reserve1 As String

    <XmlElement("reserve2")>
    Public Property Reserve2 As String

    <XmlElement("siscardflag")>
    Public Property SisCardFlag As String

    <XmlElement("pk_org")>
    Public Property Organization As String

    <XmlElement("pk_org_v")>
    Public Property OrganizationVersion As String

    <XmlElement("pk_group")>
    Public Property Group As String

    <XmlElement("details")>
    Public Property Details As VoucherDetails
    Public Sub New()
        Details = New VoucherDetails()
    End Sub
End Class

' 凭证
<Serializable()>
Public Class Voucher
    <XmlElement("voucher_head")>
    Public Property Head As VoucherHead

    Public Sub New()
        Head = New VoucherHead()
    End Sub
End Class

' 根节点
<Serializable(), XmlRoot("ufinterface")>
Public Class UfInterface
    <XmlAttribute("account")>
    Public Property Account As String

    <XmlAttribute("billtype")>
    Public Property BillType As String

    <XmlAttribute("businessunitcode")>
    Public Property BusinessUnitCode As String

    <XmlAttribute("filename")>
    Public Property FileName As String

    <XmlAttribute("groupcode")>
    Public Property GroupCode As String

    <XmlAttribute("isexchange")>
    Public Property IsExchange As String

    <XmlAttribute("orgcode")>
    Public Property OrgCode As String

    <XmlAttribute("receiver")>
    Public Property Receiver As String

    <XmlAttribute("replace")>
    Public Property Replace As String

    <XmlAttribute("roottag")>
    Public Property RootTag As String

    <XmlAttribute("sender")>
    Public Property Sender As String

    <XmlElement("voucher")>
    Public Property Vouchers As List(Of Voucher)

    Public Sub New()
        Vouchers = New List(Of Voucher)
    End Sub

    Public Sub AddVoucher(voucher As Voucher)
        Vouchers.Add(voucher)
    End Sub
End Class

Public Class VoucherXmlGenerator
    Public Function CreateVoucherData() As UfInterface
        Dim ufInterface As New UfInterface()

        ' 设置根节点属性
        ufInterface.Account = "develop" '账套编码
        ufInterface.BillType = "vouchergl"
        ufInterface.BusinessUnitCode = "develop"
        ufInterface.FileName = ""
        ufInterface.GroupCode = ""
        ufInterface.IsExchange = ""
        ufInterface.OrgCode = ""
        ufInterface.Receiver = "1000"
        ufInterface.Replace = ""
        ufInterface.RootTag = ""
        ufInterface.Sender = "HC01"

        Dim voucher = New Voucher()
        ' 设置凭证头信息
        voucher.Head.VoucherId = ""
        voucher.Head.VoucherType = "01"
        voucher.Head.Year = "2012"
        voucher.Head.System = "GL"
        voucher.Head.VoucherKind = "0"
        voucher.Head.AccountingBook = "101-zx"
        voucher.Head.DiscardFlag = "N"
        voucher.Head.Period = "02"
        voucher.Head.Number = "1055"
        voucher.Head.Attachment = "0"
        voucher.Head.PreparedDate = "2012-02-22 00:00:00"
        voucher.Head.PreparedBy = "701"
        voucher.Head.Casher = ""
        voucher.Head.SignFlag = "Y"
        voucher.Head.CheckedBy = ""
        voucher.Head.TallyDate = ""
        voucher.Head.Manager = ""
        voucher.Head.Memo1 = ""
        voucher.Head.Memo2 = ""
        voucher.Head.Reserve1 = ""
        voucher.Head.Reserve2 = "N"
        voucher.Head.SisCardFlag = ""
        voucher.Head.Organization = "101"
        voucher.Head.OrganizationVersion = "101"
        voucher.Head.Group = "007"

        ' 创建借方分录
        Dim debitItem As New VoucherItem()
        debitItem.DetailIndex = "1"
        debitItem.Explanation = "取备用金"
        debitItem.VerifyDate = ""
        debitItem.Price = "0.00000000"
        debitItem.Excrate2 = "1"
        debitItem.DebitQuantity = "0.00000000"
        debitItem.DebitAmount = "8000"
        debitItem.LocalDebitAmount = "8000"
        debitItem.GroupDebitAmount = "19.00000000"
        debitItem.GlobalDebitAmount = "19.00000000"
        debitItem.CurrencyType = "人民币"
        debitItem.AccountCode = "1001"
        debitItem.UnitCode = "101"
        debitItem.UnitCodeV = "101"

        ' 添加辅助核算项
        For i As Integer = 1 To 3
            debitItem.Ass.AddItem(New AssItem("0007", "luotest"))
        Next

        ' 设置VAT详情
        debitItem.VatDetail = New VatDetail()
        debitItem.VatDetail.BusinessCode = ""
        debitItem.VatDetail.ReceiveCountry = "AD"
        debitItem.VatDetail.SupplierVatCode = ""
        debitItem.VatDetail.TaxCode = ""
        debitItem.VatDetail.ClientVatCode = ""
        debitItem.VatDetail.Direction = "2"
        debitItem.VatDetail.MoneyAmount = "0.00000000"
        debitItem.VatDetail.VatCountry = "AF"
        debitItem.VatDetail.TaxAmount = "66"

        ' 设置现金流量
        debitItem.CashFlow.AddItem(New CashFlowItem("a", "0.00000000", "0.00000000", "0.00000000", "0.00000000", "a", "cc01"))

        ' 创建贷方分录
        Dim creditItem As New VoucherItem()
        creditItem.CreditQuantity = "0.00000000"
        creditItem.CreditAmount = "8000"
        creditItem.LocalCreditAmount = "8000"
        creditItem.GroupCreditAmount = "19.00000000"
        creditItem.GlobalCreditAmount = "19.00000000"
        creditItem.DetailIndex = "2"
        creditItem.Explanation = "取备用金"
        creditItem.VerifyDate = ""
        creditItem.Price = "0.00000000"
        creditItem.Excrate2 = "1"
        creditItem.CurrencyType = "人民币"
        creditItem.AccountCode = "1002"
        creditItem.UnitCode = "101"
        creditItem.UnitCodeV = "101"

        ' 添加辅助核算项（简化版本）
        creditItem.Ass.AddItem(New AssItem() With {.CheckType = "", .CheckValue = ""})

        ' 设置现金流量
        creditItem.CashFlow.AddItem(New CashFlowItem("a", "0.00000000", "0.00000000", "0.00000000", "0.00000000", "a", "cc01"))

        ' 添加分录到凭证
        voucher.Head.Details.AddItem(debitItem)
        voucher.Head.Details.AddItem(creditItem)

        Return ufInterface
    End Function

    ' 生成XML文件
    Public Sub GenerateXmlFile(filePath As String, data As UfInterface)
        Try
            Dim settings As New XmlWriterSettings()
            settings.Encoding = Encoding.UTF8
            settings.Indent = True
            settings.IndentChars = vbTab

            Using writer As XmlWriter = XmlWriter.Create(filePath, settings)
                ' 创建序列化器
                Dim serializer As New XmlSerializer(GetType(UfInterface))
                Dim namespaces As New XmlSerializerNamespaces()
                namespaces.Add("", "") ' 移除命名空间

                ' 写入XML声明
                writer.WriteStartDocument()

                ' 序列化对象
                serializer.Serialize(writer, data, namespaces)
            End Using

            Console.WriteLine($"XML文件已生成: {filePath}")
        Catch ex As Exception
            Console.WriteLine($"生成XML文件时出错: {ex.Message}")
            Throw
        End Try

    End Sub

    ' 生成XML字符串
    Public Function GenerateXmlString(data As UfInterface) As String
        Try
            Dim serializer As New XmlSerializer(GetType(UfInterface))
            Dim namespaces As New XmlSerializerNamespaces()
            namespaces.Add("", "") ' 移除命名空间

            Using ms As New MemoryStream()
                Using writer As XmlWriter = XmlWriter.Create(ms, New XmlWriterSettings With {
                .Encoding = Encoding.UTF8,
                .Indent = True,
                .IndentChars = vbTab
            })
                    writer.WriteStartDocument()
                    serializer.Serialize(writer, data, namespaces)
                End Using
                ' 用UTF8编码读取字节流
                Return Encoding.UTF8.GetString(ms.ToArray())
            End Using
        Catch ex As Exception
            Console.WriteLine($"生成XML字符串时出错: {ex.Message}")
            Throw
        End Try
    End Function
End Class