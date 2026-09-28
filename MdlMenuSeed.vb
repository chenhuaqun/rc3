Imports System.Data
Imports System.Data.OleDb

'rc_menu 预置菜单数据
'
'本模块是 rc_menu 菜单树的唯一数据源，结构与 FrmMain.Designer.vb 中的静态菜单一一对应。
'
'约定:
'  1. mnuiname 必须与 FrmMain 中 ToolStripMenuItem 的字段名完全一致，FrmMain 加载时按该名称反射取控件控制显隐。
'  2. mnuiid 沿用历史编号，rc_roleqx.code 引用该编号，一经分配不可变更；FrmMain 后续新增的菜单项在所属顶级段内往后追加。
'  3. mnuiparentid 为 0 表示顶级菜单，mnuisortorder 为同级显示顺序。
'  4. mnuiformname 为对应的窗体类名，无点击处理器的菜单项为空。
Module MdlMenuSeed

    '预置菜单项
    Private Class MenuItem
        Public ReadOnly MenuId As String
        Public ReadOnly ParentId As String
        Public ReadOnly SortOrder As Integer
        Public ReadOnly Caption As String
        Public ReadOnly MenuName As String
        Public ReadOnly FormName As String

        Public Sub New(strMenuId As String, strParentId As String, intSortOrder As Integer,
                        strCaption As String, strMenuName As String, strFormName As String)
            Me.MenuId = strMenuId
            Me.ParentId = strParentId
            Me.SortOrder = intSortOrder
            Me.Caption = strCaption
            Me.MenuName = strMenuName
            Me.FormName = strFormName
        End Sub
    End Class

    Private Const MENU_OWN As String = "RC3"

    '预置菜单树，与 FrmMain.Designer.vb 一一对应，共 246 条
    '格式: mnuiid, mnuiparentid, mnuisortorder, mnuicaption, mnuiname, mnuiformname
    Private ReadOnly PresetMenu As MenuItem() = {
        New MenuItem("10", "0", 10, "系统设置(&B)", "MnuiBase", Nothing),
        New MenuItem("1001", "10", 1, "物料类别信息设置", "MnuiCplbxx", "FrmCplbxx"),
        New MenuItem("1002", "10", 2, "物料组设置", "MnuiCpGroup", "FrmCpGroup"),
        New MenuItem("1003", "10", 3, "物料信息设置", "MnuiCpxx", "FrmCpxx"),
        New MenuItem("1004", "10", 4, "物料清单设置", "MnuiBom", "FrmBom"),
        New MenuItem("1005", "10", 5, "客户分类信息设置", "MnuiKhlbxx", "FrmKhlbxx"),
        New MenuItem("1006", "10", 6, "客户信息设置", "MnuiKhxx", "FrmKhxx"),
        New MenuItem("1007", "10", 7, "客户收货地址管理", "MnuiKhshdz", "FrmKhshdzxx"),
        New MenuItem("1008", "10", 8, "客户专管业务员设置", "MnuiKhzyxx", "FrmKhzyxx"),
        New MenuItem("1009", "10", 9, "供应商分类信息设置", "MnuiCslbxx", "FrmCslbxx"),
        New MenuItem("1010", "10", 10, "供应商信息设置", "MnuiCsxx", "FrmCsxx"),
        New MenuItem("1011", "10", 11, "部门编码设置", "MnuiBmxx", "FrmBmxx"),
        New MenuItem("1012", "10", 12, "职员信息设置", "MnuiZyxx", "FrmZyxx"),
        New MenuItem("1013", "10", 13, "仓库编码设置", "MnuiCkxx", "FrmCkxx"),
        New MenuItem("1014", "10", 14, "成本域设置", "MnuiCostRegion", "FrmCostRegionxx"),
        New MenuItem("1015", "10", 15, "计量单位设置", "MnuiJldwxx", "FrmJldwxx"),
        New MenuItem("1016", "10", 16, "生产工序信息设置", "MnuiGxxx", "FrmGxxx"),
        New MenuItem("1017", "10", 17, "科目信息设置", "MnuiKmxx", "FrmKmxx"),
        New MenuItem("1018", "10", 18, "结算方式信息设置", "MnuiJsfsxx", "FrmJsfsxx"),
        New MenuItem("1019", "10", 19, "币种信息设置", "MnuiWbxx", "FrmWbxx"),
        New MenuItem("1020", "10", 20, "库存账龄设置", "MnuiKcZlxx", "FrmKcZlxx"),
        New MenuItem("1021", "10", 21, "期初产品库存余额装入", "MnuiQccpyeSr", "FrmQccpyeSr"),
        New MenuItem("1022", "10", 22, "期初发出商品余额装入", "MnuiQcfcspyeSr", "FrmQcfcspyeSr"),
        New MenuItem("1023", "10", 23, "期初客户应收明细装入", "MnuiQckhyeSr", "FrmQckhyeSr"),
        New MenuItem("1024", "10", 24, "期初供应商应付明细装入", "MnuiQccsyeSr", "FrmQccsyeSr"),
        New MenuItem("1025", "10", 25, "期初总账余额装入", "MnuiQckmyeSr", "FrmQckmyeSr"),
        New MenuItem("1026", "10", 26, "单据类型信息设置", "MnuiPzlxxx", "FrmPzlxxx"),
        New MenuItem("1027", "10", 27, "会计期间设置", "MnuiKjqj", "FrmKjqj"),
        New MenuItem("1028", "10", 28, "角色和角色操作权限设置", "MnuiRoles", "FrmRoles"),
        New MenuItem("1029", "10", 29, "操作员和操作员角色设置", "MnuiUsers", "FrmUsers"),
        New MenuItem("1030", "10", 30, "选项", "MnuiOption", "FrmOption"),
        New MenuItem("20", "0", 20, "销售(&OE)", "MnuiOe", Nothing),
        New MenuItem("20G1", "20", 1, "样品订单", "MnuiOeYpdd", Nothing),
        New MenuItem("2001", "20G1", 1, "样品订单录入与修改", "MnuiOeYpddSr", "FrmOeYpddSr"),
        New MenuItem("2002", "20G1", 2, "样品生产厂输入", "MnuiOeYpddBmSr", "FrmOeYpddBmSr"),
        New MenuItem("2003", "20G1", 3, "样品生产交期输入", "MnuiOeYpddJqSr", "FrmOeYpddJqSr"),
        New MenuItem("2004", "20G1", 4, "样品订单审核", "MnuiOeYpddSh", "FrmOeYpddSh"),
        New MenuItem("2005", "20G1", 5, "样品寄样日期输入", "MnuiOeYpFhrqSr", "FrmOeYpFhrqSr"),
        New MenuItem("2006", "20G1", 6, "样品寄样单号输入", "MnuiOeYpFhdhSr", "FrmOeYpFhdhSr"),
        New MenuItem("2007", "20G1", 7, "样品客户反馈", "MnuiOeYpddHx", "FrmOeYpddHx"),
        New MenuItem("2008", "20G1", 8, "样品订单查询", "MnuiOeYpddCx", "FrmOeYpddCx"),
        New MenuItem("2009", "20G1", 9, "样品订单发货登记表", "MnuiOeYpddDjb", "FrmOeYpddDjb"),
        New MenuItem("20G2", "20", 2, "产品报价单", "MnuiOeBjd", Nothing),
        New MenuItem("2010", "20G2", 1, "产品报价单输入与修改", "MnuiOeBjdSr", "FrmOeBjdSr"),
        New MenuItem("2011", "20G2", 2, "产品报价单审核", "MnuiOeBjdSh", "FrmOeBjdSh"),
        New MenuItem("2012", "20G2", 3, "产品报价单查询", "MnuiOeBjdCx", "FrmOeBjdCx"),
        New MenuItem("2013", "20", 3, "产品销售订单录入与修改", "MnuiOeDdSr", "FrmOeDdSr"),
        New MenuItem("2014", "20", 4, "产品销售订单单价审核", "MnuiOeDddjSh", "FrmOeDddjSh"),
        New MenuItem("2015", "20", 5, "产品销售订单关闭", "MnuiOeDdClose", "FrmOeDdClose"),
        New MenuItem("2016", "20", 6, "产品销售订单派工", "MnuiOeDdJqSr", "FrmOeDdJqSr"),
        New MenuItem("2017", "20", 7, "产品销售订单审核", "MnuiOeDdSh", "FrmOeDdSh"),
        New MenuItem("2018", "20", 8, "产品入库单录入与修改", "MnuiOeRkdSr", "FrmOeRkdSr"),
        New MenuItem("2019", "20", 9, "产品入库单审核", "MnuiOeRkdSh", "FrmOeRkdSh"),
        New MenuItem("2020", "20", 10, "产品发货通知书输入与修改", "MnuiOeFhdSr", "FrmOeFhdSr"),
        New MenuItem("2021", "20", 11, "产品发货通知书审核", "MnuiOeFhdSh", "FrmOeFhdSh"),
        New MenuItem("2022", "20", 12, "产品送货单录入与修改", "MnuiOeXsdSr", "FrmOeXsdSr"),
        New MenuItem("2023", "20", 13, "产品送货单审核", "MnuiOeXsdSh", "FrmOeXsdSh"),
        New MenuItem("2024", "20", 14, "产品送货单核销", "MnuiOeXsdHx", "FrmOeXsdHx"),
        New MenuItem("2025", "20", 15, "产品销售发票输入与修改", "MnuiOeFpSr", "FrmOeFpSr"),
        New MenuItem("2026", "20", 16, "产品销售发票审核", "MnuiOeFpSh", "FrmOeFpSh"),
        New MenuItem("2027", "20", 17, "产品销售订单查询", "MnuiOeDdCx", "FrmOeDdCx"),
        New MenuItem("2028", "20", 18, "产品入库单查询", "MnuiOeRkdCx", "FrmOeRkdCx"),
        New MenuItem("2029", "20", 19, "产品发货通知书查询", "MnuiOeFhdCx", "FrmOeFhdCx"),
        New MenuItem("2030", "20", 20, "产品送货单查询", "MnuiOeXsdCx", "FrmOeXsdCx"),
        New MenuItem("2031", "20", 21, "产品销售发票查询", "MnuiOeFpCx", "FrmOeFpCx"),
        New MenuItem("2032", "20", 22, "产品入库产值汇总表", "MnuiOeRkCpHzb", "FrmOeRkCpHzb"),
        New MenuItem("2033", "20", 23, "产品入库产值部门汇总表", "MnuiOeRkBmHzb", "FrmOeRkBmHzb"),
        New MenuItem("2034", "20", 24, "产品销售日报", "MnuiOeXsrb", "FrmOeXsRb"),
        New MenuItem("2035", "20", 25, "物料类别送货汇总表", "MnuiOeCplbHzb", "FrmOeCplbHzb"),
        New MenuItem("2036", "20", 26, "部门送货汇总表", "MnuiOeBmHzb", "FrmOeBmHzb"),
        New MenuItem("2037", "20", 27, "产品送货汇总表", "MnuiOeCpHzb", "FrmOeCpHzb"),
        New MenuItem("2038", "20", 28, "产品送货仓库汇总表", "MnuiOeCkCpHzb", "FrmOeCkCpHzb"),
        New MenuItem("2039", "20", 29, "客户送货汇总表", "MnuiOeKhHzb", "FrmOeKhHzb"),
        New MenuItem("2040", "20", 30, "职员送货汇总表", "MnuiOeZyHzb", "FrmOeZyHzb"),
        New MenuItem("2041", "20", 31, "部门销售发票汇总表", "MnuiOeBmFpHzb", "FrmOeBmFpHzb"),
        New MenuItem("2042", "20", 32, "产品销售发票汇总表", "MnuiOeCpFpHzb", "FrmOeCpFpHzb"),
        New MenuItem("2043", "20", 33, "客户销售发票汇总表", "MnuiOeKhFpHzb", "FrmOeKhFpHzb"),
        New MenuItem("2044", "20", 34, "客户销售发票对比分析表", "MnuiOeKhFpFxb", "FrmOeKhFpFxb"),
        New MenuItem("30", "0", 30, "生产(P&M)", "MnuiPm", Nothing),
        New MenuItem("3001", "30", 1, "生产订单输入与修改", "MnuiPmDdSr", "FrmPmDdSr"),
        New MenuItem("3003", "30", 3, "生成工序流转卡", "MnuiPmScGxlzk", "FrmPmScGxlzk"),
        New MenuItem("3004", "30", 4, "工序派工单", "MnuiPmDdGxPg", "FrmPmDdGxPg"),
        New MenuItem("3005", "30", 5, "工序汇报单", "MnuiPmDdGxHb", "FrmPmDdGxHb"),
        New MenuItem("3006", "30", 6, "工序领料单输入与修改", "MnuiPmCkdSr", "FrmPmCkdSr"),
        New MenuItem("3007", "30", 7, "工序领料单审核", "MnuiPmCkdSh", "FrmPmCkdSh"),
        New MenuItem("3008", "30", 8, "工序入库单输入与修改", "MnuiPmRkdSr", "FrmPmRkdSr"),
        New MenuItem("3009", "30", 9, "工序入库单审核", "MnuiPmRkdSh", "FrmPmRkdSh"),
        New MenuItem("3010", "30", 10, "工序领料单查询", "MnuiPmCkdCx", "FrmPmCkdCx"),
        New MenuItem("3011", "30", 11, "工序入库单查询", "MnuiPmRkdCx", "FrmPmRkdCx"),
        New MenuItem("3012", "30", 12, "订单生产跟踪查询", "MnuiPmDdGxlzCx", "FrmPmDdGxlzCx"),
        New MenuItem("3013", "30", 13, "各部门工序入库物料汇总表", "MnuiPmRkCpHzb", "FrmPmRkCpHzb"),
        New MenuItem("3014", "30", 14, "部门入库汇总表", "MnuiPmBmRkHzb", "FrmPmBmRkHzb"),
        New MenuItem("40", "0", 40, "采购(&PO)", "MnuiPo", Nothing),
        New MenuItem("4001", "40", 1, "物料采购/维修需求单录入与修改", "MnuiPoCgjhSr", "FrmPoCgjhSr"),
        New MenuItem("4002", "40", 2, "物料采购/维修需求单审核", "MnuiPoCgjhSh", "FrmPoCgjhSh"),
        New MenuItem("4003", "40", 3, "物料采购/维修需求单关闭", "MnuiPoCgjhClose", "FrmPoCgjhClose"),
        New MenuItem("4004", "40", 4, "供应商物料采购价格目录维护", "MnuiCsCpCgdjSr", "FrmCsCpCgdjSr"),
        New MenuItem("4006", "40", 6, "物料采购订单录入与修改", "MnuiPoCgdSr", "FrmPoCgdSr"),
        New MenuItem("4007", "40", 7, "物料采购订单审核", "MnuiPoCgdSh", "FrmPoCgdSh"),
        New MenuItem("4008", "40", 8, "物料采购订单关闭", "MnuiPoCgdClose", "FrmPoCgdClose"),
        New MenuItem("4009", "40", 9, "物料入库单输入与修改", "MnuiPoRkdSr", "FrmPoRkdSr"),
        New MenuItem("4011", "40", 10, "物料入库单审核", "MnuiPoRkdSh", "FrmPoRkdSh"),
        New MenuItem("4012", "40", 11, "采购发票输入与修改", "MnuiPoFpSr", "FrmPoFpSr"),
        New MenuItem("4013", "40", 12, "采购发票审核", "MnuiPoFpSh", "FrmPoFpSh"),
        New MenuItem("4014", "40", 13, "物料领用申请单输入与修改", "MnuiPoLlsqSr", "FrmPoLlsqSr"),
        New MenuItem("4015", "40", 14, "物料领用申请单审核", "MnuiPoLlsqSh", "FrmPoLlsqSh"),
        New MenuItem("4016", "40", 15, "物料领用申请单关闭", "MnuiPoLlsqClose", "FrmPoLlsqClose"),
        New MenuItem("4010", "40", 16, "物料回收与取消回收", "MnuiInvRecycleSr", "FrmInvRecycleSr"),
        New MenuItem("4017", "40", 17, "物料出库单输入与修改", "MnuiPoCkdSr", "FrmPoCkdSr"),
        New MenuItem("4018", "40", 18, "物料领用发货", "MnuiPoCkdSr2", "FrmPoCkdSr2"),
        New MenuItem("4019", "40", 19, "物料出库单审核", "MnuiPoCkdSh", "FrmPoCkdSh"),
        New MenuItem("4020", "40", 20, "物料调拨单输入与修改", "MnuiInvDbdSr", "FrmInvDbdSr"),
        New MenuItem("4021", "40", 21, "物料调拨单审核", "MnuiInvDbdSh", "FrmInvDbdSh"),
        New MenuItem("4022", "40", 22, "物料采购/维修需求单查询", "MnuiPoCgjhCx", "FrmPoCgjhCx"),
        New MenuItem("4023", "40", 23, "供应商物料采购价格目录查询", "MnuiCsCpCgdjCx", "FrmCsCpCgdjCx"),
        New MenuItem("4024", "40", 24, "物料采购订单查询", "MnuiPoCgdCx", "FrmPoCgdCx"),
        New MenuItem("4025", "40", 25, "物料入库单查询", "MnuiPoRkdCx", "FrmPoRkdCx"),
        New MenuItem("4026", "40", 26, "采购发票查询", "MnuiPoFpCx", "FrmPoFpCx"),
        New MenuItem("4027", "40", 27, "物料领用申请单查询", "MnuiPoLlsqCx", "FrmPoLlsqCx"),
        New MenuItem("4028", "40", 28, "物料出库单查询", "MnuiPoCkdCx", "FrmPoCkdCx"),
        New MenuItem("4029", "40", 29, "物料调拨单查询", "MnuiInvDbdCx", "FrmInvDbdCx"),
        New MenuItem("4030", "40", 30, "供应商采购汇总表", "MnuiPoCsHzb", "FrmPoCsHzb"),
        New MenuItem("4031", "40", 31, "部门领用汇总表", "MnuiPoBmHzb", "FrmPoBmHzb"),
        New MenuItem("4032", "40", 32, "部门设备物料类别消耗汇总表", "MnuiPoBmFaLbHzb", "FrmPoBmFaLbHzb"),
        New MenuItem("4033", "40", 33, "仓库领用物料汇总表", "MnuiCkCkCpHzb", "FrmCkCkCpHzb"),
        New MenuItem("4034", "40", 34, "仓库调拨物料汇总表", "MnuiCkDbCpHzb", "FrmCkDbCpHzb"),
        New MenuItem("50", "0", 50, "库存(&I)", "MnuiInv", Nothing),
        New MenuItem("5001", "50", 1, "物料调整单输入与修改", "MnuiInvCktzSr", "FrmInvCktzSr"),
        New MenuItem("5002", "50", 2, "物料盘存表输入与修改", "MnuiInvPcSr", "FrmInvPcSr"),
        New MenuItem("5017", "50", 3, "期末发出商品输入与修改", "MnuiFcspSr", "FrmFcspSr"),
        New MenuItem("5003", "50", 4, "物料盘存表审核", "MnuiInvPcSh", "FrmInvPcSh"),
        New MenuItem("5004", "50", 5, "仓库收发存明细账", "MnuiSlSfcMx", "FrmSlSfcMx"),
        New MenuItem("5005", "50", 6, "仓库收发存汇总表", "MnuiSlSfcHz", "FrmSlSfcHz"),
        New MenuItem("5006", "50", 7, "物料盘存表", "MnuiCpPcb", "FrmCpPcb"),
        New MenuItem("5007", "50", 8, "物料收发存明细账", "MnuiCpSfcMx", "FrmCpSfcMx"),
        New MenuItem("5008", "50", 9, "物料收发存汇总表", "MnuiCpSfcHz", "FrmCpSfcHz"),
        New MenuItem("5009", "50", 10, "物料各仓库资金收发存汇总表", "MnuiJeSfcHz", "FrmJeSfcHz"),
        New MenuItem("5010", "50", 11, "物料批次收发存明细帐", "MnuiPhSfcMx", "FrmPhSfcMx"),
        New MenuItem("5011", "50", 12, "物料批次收发存汇总表", "MnuiPhSfcHz", "FrmPhSfcHz"),
        New MenuItem("5012", "50", 13, "物料类别收发存汇总表", "MnuiCplbSfcHz", "FrmCplbSfcHz"),
        New MenuItem("5013", "50", 14, "物料库存账龄分析表", "MnuiCpkcZlfx", "FrmCpkcZlfx"),
        New MenuItem("5014", "50", 15, "发出商品盘存表", "MnuiFcspPcb", "FrmFcspPcb"),
        New MenuItem("5015", "50", 16, "发出商品收发存明细账", "MnuiFcspSfcMx", "FrmFcspSfcMx"),
        New MenuItem("5016", "50", 17, "发出商品收发存汇总表", "MnuiFcspSfcHz", "FrmFcspSfcHz"),
        New MenuItem("5018", "50", 18, "发出商品客户收发存汇总表", "MnuiFcspKhSfcHz", "FrmFcspKhSfcHz"),
        New MenuItem("5019", "50", 19, "发出商品部门收发存汇总表", "MnuiFcspBmSfcHz", "FrmFcspBmSfcHz"),
        New MenuItem("5020", "50", 20, "发出商品清单查询", "MnuiFcspCx", "FrmFcspCx"),
        New MenuItem("60", "0", 60, "财务(&F)", "MnuiArAp", Nothing),
        New MenuItem("6001", "60", 1, "其他应收单录入与修改", "MnuiQtysSr", "FrmQtysSr"),
        New MenuItem("6002", "60", 2, "其他应收单审核", "MnuiQtysSh", "FrmQtysSh"),
        New MenuItem("6003", "60", 3, "收款单录入与修改", "MnuiSkdSr", "FrmSkdSr"),
        New MenuItem("6004", "60", 4, "收款单审核", "MnuiSkdSh", "FrmSkdSh"),
        New MenuItem("6005", "60", 5, "应收账款核销", "MnuiSkdHx", "FrmSkdHx"),
        New MenuItem("6006", "60", 6, "其他应付单录入与修改", "MnuiQtyfSr", "FrmQtyfSr"),
        New MenuItem("6007", "60", 7, "其他应付单审核", "MnuiQtyfSh", "FrmQtyfSh"),
        New MenuItem("6023", "60", 8, "付款申请单录入与修改", "MnuiApFksqSr", "FrmApFksqSr"),
        New MenuItem("6024", "60", 9, "付款申请单审核", "MnuiApFksqSh", "FrmApFksqSh"),
        New MenuItem("6008", "60", 10, "付款单录入与修改", "MnuiFkdSr", "FrmFkdSr"),
        New MenuItem("6009", "60", 11, "付款单审核", "MnuiFkdSh", "FrmFkdSh"),
        New MenuItem("6010", "60", 12, "应付账款核销", "MnuiFkdHx", "FrmFkdHx"),
        New MenuItem("6011", "60", 13, "其他应收单查询", "MnuiQtysCx", "FrmQtysCx"),
        New MenuItem("6012", "60", 14, "收款单查询", "MnuiSkdCx", "FrmSkdCx"),
        New MenuItem("6013", "60", 15, "其他应付单查询", "MnuiQtyfCx", "FrmQtyfCx"),
        New MenuItem("6025", "60", 16, "付款申请单查询", "MnuiApFksqCx", "FrmApFksqCx"),
        New MenuItem("6014", "60", 17, "付款单查询", "MnuiFkdCx", "FrmFkdCx"),
        New MenuItem("6015", "60", 18, "客户应收账款明细账", "MnuiKhYszkMx", "FrmKhYszkMx"),
        New MenuItem("6016", "60", 19, "客户应收账款核销明细账", "MnuiKhYszkHxMx", "FrmKhYszkHxMx"),
        New MenuItem("6017", "60", 20, "客户应收账款汇总表", "MnuiKhYszkHz", "FrmKhYszkHz"),
        New MenuItem("6018", "60", 21, "客户类别应收账款汇总表", "MnuiKhLbYszkHz", "FrmKhLbYszkHz"),
        New MenuItem("6019", "60", 22, "供应商应付账款明细账", "MnuiCsYfzkMx", "FrmCsYfzkMx"),
        New MenuItem("6020", "60", 23, "供应商应付账款汇总表", "MnuiCsYfzkHz", "FrmCsYfzkHz"),
        New MenuItem("6021", "60", 24, "供应商类别应付账款汇总表", "MnuiCsLbYfzkHz", "FrmCsLbYfzkHz"),
        New MenuItem("6022", "60", 25, "客户收款汇总表", "MnuiArKhHzb", "FrmArKhHzb"),
        New MenuItem("70", "0", 70, "成本(&CM)", "MnuiCosts", Nothing),
        New MenuItem("7001", "70", 1, "期末在产材料数量录入", "MnuiZcclslSr", "FrmZcclslSr"),
        New MenuItem("7002", "70", 2, "期末在产品数量录入", "MnuiZcpslSr", "FrmZcpslSr"),
        New MenuItem("7003", "70", 3, "本期投入总成本录入", "MnuiZcbJeSr", "FrmZcbjeSr"),
        New MenuItem("7004", "70", 4, "材料出库成本结转", "MnuiCbjz_Cl", "FrmCbjz_Cl"),
        New MenuItem("7005", "70", 5, "生产成本分配", "MnuiCbjz_Sccb", "FrmCbjz_Sccb"),
        New MenuItem("7006", "70", 6, "产品出库成本结转", "MnuiCbjz_Xscb", "FrmCbjz_Xscb"),
        New MenuItem("7007", "70", 7, "发出商品成本结转", "MnuiCbjz_Fcsp", "FrmCbjz_Fcsp"),
        New MenuItem("7008", "70", 8, "在产材料成本明细表", "MnuiZcclMx", "FrmZcclMx"),
        New MenuItem("7009", "70", 9, "在产品成本明细表", "MnuiZcpMx", "FrmZcpMx"),
        New MenuItem("7010", "70", 10, "在产品部门工序汇总表", "MnuiZcpBmGxHz", "FrmZcpBmGxHz"),
        New MenuItem("7011", "70", 11, "产成品在产品成本汇总表", "MnuiCcpZcpHz", "FrmCcpZcpHz"),
        New MenuItem("7012", "70", 12, "产成品在产品各部门成本汇总表", "MnuiCcpZcpBmHz", "FrmCcpZcpBmHz"),
        New MenuItem("7013", "70", 13, "物料清单查询", "MnuiBomCx", "FrmFcspCx"),
        New MenuItem("80", "0", 80, "总账(G)", "MnuiGl", Nothing),
        New MenuItem("8001", "80", 1, "凭证输入与修改", "MnuiGlPzSr", "FrmGlPzSr"),
        New MenuItem("8002", "80", 2, "凭证审核", "MnuiGlPzSh", "FrmGlPzSh"),
        New MenuItem("8003", "80", 3, "凭证记账", "MnuiGlPzJz", "FrmGlPzJz"),
        New MenuItem("8004", "80", 4, "凭证查询", "MnuiGlPzCx", "FrmGlPzCx"),
        New MenuItem("8005", "80", 5, "科目日记账", "MnuiGlKmRjz", "FrmGlKmRjz"),
        New MenuItem("8006", "80", 6, "科目明细账", "MnuiGlKmMxz", "FrmGlKmMxz"),
        New MenuItem("8007", "80", 7, "科目余额汇总表", "MnuiGlKmyeb", "FrmGlKmyeb"),
        New MenuItem("8008", "80", 8, "科目客户余额汇总表", "MnuiGlKmkhYeb", "FrmGlKmkhYeb"),
        New MenuItem("8009", "80", 9, "科目供应商余额汇总表", "MnuiGlKmcsYeb", "FrmGlKmcsYeb"),
        New MenuItem("8010", "80", 10, "账龄分析表", "MnuiGlZlfx", "FrmGlZlfx"),
        New MenuItem("8011", "80", 11, "汇总账龄分析表", "MnuiGlZlfxHz", "FrmGlZlfxHz"),
        New MenuItem("8012", "80", 12, "汇总账龄分析表(按账套)", "MnuiGlZlfxHz2", "FrmGlZlfxHz2"),
        New MenuItem("90", "0", 90, "期末(&T)", "MnuiEnding", Nothing),
        New MenuItem("90G1", "90", 1, "业务费管理", "MnuiYwfGl", Nothing),
        New MenuItem("9001", "90G1", 1, "客户销售分类信息设置", "MnuiKhXslb", "FrmKhXslbxx"),
        New MenuItem("9002", "90G1", 2, "逾期收款倒扣比率设置", "MnuiYwfDkl", "FrmYwfDklxx"),
        New MenuItem("9003", "90G1", 3, "业务员任务数设置", "MnuiYwfZyrw", "FrmYwfZyrw"),
        New MenuItem("9004", "90G1", 4, "业务费抵扣规则定义", "MnuiYwfDkgsxx", "FrmYwfDkgsxx"),
        New MenuItem("9005", "90G1", 5, "业务费抵扣业务输入与修改", "MnuiYwfDkywSr", "FrmYwfDkywSr"),
        New MenuItem("9006", "90G1", 6, "业务费抵扣业务查询", "MnuiYwfDkywCx", "FrmYwfDkywCx"),
        New MenuItem("9007", "90G1", 7, "业务费计算", "MnuiYwfJs", "FrmYwfJs"),
        New MenuItem("9008", "90G1", 8, "业务费计算明细查询", "MnuiYwfCx", "FrmYwfCx"),
        New MenuItem("9009", "90G1", 9, "业务费客户汇总表", "MnuiYwfKhHz", "FrmYwfKhHz"),
        New MenuItem("9010", "90G1", 10, "业务费业务员汇总表", "MnuiYwfZyHz", "FrmYwfZyHz"),
        New MenuItem("9011", "90G1", 11, "业务费业务员计算明细表", "MnuiYwfZyMx", "FrmYwfZyMx"),
        New MenuItem("9012", "90G1", 12, "业务费业务员增长汇总表", "MnuiYwfZyzzHz", "FrmYwfZyzzHz"),
        New MenuItem("9022", "90G1", 13, "业务费计算明细查询(按账套)", "MnuiYwfCxHz", "FrmYwfCxHz"),
        New MenuItem("9013", "90G1", 14, "业务费客户汇总表(按账套)", "MnuiYwfKhHzHz", "FrmYwfKhHzHz"),
        New MenuItem("9023", "90G1", 15, "业务费业务员汇总表(按账套)", "MnuiYwfZyHzHz", "FrmYwfZyHzHz"),
        New MenuItem("9024", "90G1", 16, "业务费业务员计算明细表(按账套)", "MnuiYwfZyMxHz", "FrmYwfZyMxHz"),
        New MenuItem("9025", "90G1", 17, "业务费业务员增长汇总表(按账套)", "MnuiYwfZyzzHzHz", "FrmYwfZyzzHzHz"),
        New MenuItem("9014", "90", 2, "单据记账", "MnuiDjjz", "FrmDjjz"),
        New MenuItem("9015", "90", 3, "发出商品处理", "MnuiFcspJz", "FrmFcspJz"),
        New MenuItem("9016", "90", 4, "计提存货跌价准备", "MnuiJtchdjzb", "FrmJtchdjzb"),
        New MenuItem("9017", "90", 5, "MRP运算", "MnuiMrpJs", "FrmMrpJs"),
        New MenuItem("9018", "90", 6, "凭证生成", "MnuiPzsc", "FrmPzsc"),
        New MenuItem("9019", "90", 7, "凭证传递", "MnuiPzcd", "FrmPzcd"),
        New MenuItem("9020", "90", 8, "期末结账", "MnuiYdjz", "FrmYdjz"),
        New MenuItem("9021", "90", 9, "建立新年度账", "MnuiNewYear", "FrmNewYear"),
        New MenuItem("99", "0", 99, "系统服务(&S)", "MnuiSys", Nothing),
        New MenuItem("A001", "99", 1, "修改密码", "MnuiModPwd", "FrmModPwd"),
        New MenuItem("A002", "99", 2, "重新注册", "MnuiZtdl", "FrmUserLogin"),
        New MenuItem("A003", "99", 3, "在线升级", "MnuiUpdate", "FrmUpdate"),
        New MenuItem("A004", "99", 4, "上传文件", "MnuiUploadFile", "FrmUploadFile"),
        New MenuItem("A005", "99", 5, "升级RC3数据", "MnuiUpdateDB", "FrmUpdateDB"),
        New MenuItem("A006", "99", 6, "导入用友NC数据", "MnuiImpNC", "FrmImpNC"),
        New MenuItem("9901", "99", 7, "导入用友U8数据", "MnuiImpU8", "FrmImpU8"),
        New MenuItem("A007", "99", 8, "物料编码更改与合并", "MnuiCpdmGg", "FrmCpdmGg"),
        New MenuItem("A008", "99", 9, "客户编码更改与合并", "MnuiKhdmGg", "FrmKhdmGg"),
        New MenuItem("A009", "99", 10, "供应商编码更改与合并", "MnuiCsdmGg", "FrmCsdmGg"),
        New MenuItem("A010", "99", 11, "职员编码更改与合并", "MnuiZydmGg", "FrmZydmGg"),
        New MenuItem("A011", "99", 12, "重新汇总库存总账", "MnuiRedoCpyeHz", "FrmRedoCpyeHz"),
        New MenuItem("A012", "99", 13, "重新汇总发出商品总账", "MnuiRedoFcspyeHz", "FrmRedoFcspyeHz"),
        New MenuItem("A013", "99", 14, "物料数据修复", "MnuiCpRepair", "FrmCpRepair"),
        New MenuItem("A014", "99", 15, "检测与升级数据库", "MnuiCheckData", "FrmCheckData"),
        New MenuItem("9902", "99", 16, "升级数据", "MnuiUpgrateData", "FrmUpgrateData"),
        New MenuItem("9903", "99", 17, "注册与激活(&R)", "MnuiRegister", "FrmRegister"),
        New MenuItem("9904", "99", 18, "关于(&A)", "MnuiAbout", "FrmAbout"),
    }

    '建立 rc_menu 表及所需字段，已存在则跳过
    Public Function EnsureMenuTable(ByRef erroMsg As String) As Boolean
        erroMsg = ""
        Try
            sysOleDbConn.Open()
            Using rcOleDbCommand As OleDbCommand = sysOleDbConn.CreateCommand()
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text

                If TableExists(rcOleDbCommand, "RC_MENU") Then
                    EnsureColumn(rcOleDbCommand, "MNUIPARENTID", "mnuiparentid VARCHAR2(4) DEFAULT '0'")
                    EnsureColumn(rcOleDbCommand, "MNUISORTORDER", "mnuisortorder NUMBER(10) DEFAULT 0")
                    EnsureColumn(rcOleDbCommand, "MNUIFORMNAME", "mnuiformname VARCHAR2(100)")
                Else
                    rcOleDbCommand.CommandText = "CREATE TABLE rc_menu (mnuiid VARCHAR2(4),mnuiparentid VARCHAR2(4) DEFAULT '0',mnuicaption VARCHAR2(50),mnuiname VARCHAR2(30),mnuiown VARCHAR2(4),mnuisortorder NUMBER(10) DEFAULT 0,mnuiformname VARCHAR2(100))"
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_menu ADD CONSTRAINT PK_RC_MENU primary key (mnuiown,mnuiid)"
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            End Using
            Return True
        Catch ex As Exception
            erroMsg = ex.Message
            Return False
        Finally
            CloseConnection()
        End Try
    End Function

    '写入预置菜单数据，已存在的记录就地更新，缺失的记录补入，不删除任何已有数据
    Public Function EnsureMenuData(ByRef erroMsg As String) As Boolean
        erroMsg = ""
        Dim rcOleDbTrans As OleDbTransaction = Nothing
        Try
            sysOleDbConn.Open()
            Using rcOleDbCommand As OleDbCommand = sysOleDbConn.CreateCommand()
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text

                rcOleDbTrans = sysOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
                rcOleDbCommand.Transaction = rcOleDbTrans

                For Each rcItem As MenuItem In PresetMenu
                    rcOleDbCommand.CommandText = "UPDATE rc_menu SET mnuiparentid = ?,mnuicaption = ?,mnuiname = ?,mnuisortorder = ?,mnuiformname = ? WHERE mnuiown = ? AND mnuiid = ?"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.Parameters.Add("@mnuiparentid", OleDbType.VarChar, 4).Value = rcItem.ParentId
                    rcOleDbCommand.Parameters.Add("@mnuicaption", OleDbType.VarChar, 50).Value = rcItem.Caption
                    rcOleDbCommand.Parameters.Add("@mnuiname", OleDbType.VarChar, 30).Value = rcItem.MenuName
                    rcOleDbCommand.Parameters.Add("@mnuisortorder", OleDbType.Integer).Value = rcItem.SortOrder
                    rcOleDbCommand.Parameters.Add("@mnuiformname", OleDbType.VarChar, 100).Value = FormNameValue(rcItem.FormName)
                    rcOleDbCommand.Parameters.Add("@mnuiown", OleDbType.VarChar, 4).Value = MENU_OWN
                    rcOleDbCommand.Parameters.Add("@mnuiid", OleDbType.VarChar, 4).Value = rcItem.MenuId
                    If rcOleDbCommand.ExecuteNonQuery() = 0 Then
                        rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) VALUES (?,?,?,?,?,?,?)"
                        rcOleDbCommand.Parameters.Clear()
                        rcOleDbCommand.Parameters.Add("@mnuiid", OleDbType.VarChar, 4).Value = rcItem.MenuId
                        rcOleDbCommand.Parameters.Add("@mnuiparentid", OleDbType.VarChar, 4).Value = rcItem.ParentId
                        rcOleDbCommand.Parameters.Add("@mnuicaption", OleDbType.VarChar, 50).Value = rcItem.Caption
                        rcOleDbCommand.Parameters.Add("@mnuiname", OleDbType.VarChar, 30).Value = rcItem.MenuName
                        rcOleDbCommand.Parameters.Add("@mnuiown", OleDbType.VarChar, 4).Value = MENU_OWN
                        rcOleDbCommand.Parameters.Add("@mnuisortorder", OleDbType.Integer).Value = rcItem.SortOrder
                        rcOleDbCommand.Parameters.Add("@mnuiformname", OleDbType.VarChar, 100).Value = FormNameValue(rcItem.FormName)
                        rcOleDbCommand.ExecuteNonQuery()
                    End If
                Next

                rcOleDbTrans.Commit()
            End Using
            Return True
        Catch ex As Exception
            erroMsg = ex.Message
            Try
                If Not rcOleDbTrans Is Nothing Then rcOleDbTrans.Rollback()
            Catch
            End Try
            Return False
        Finally
            CloseConnection()
        End Try
    End Function

    '建表并写入预置菜单数据
    Public Function EnsureMenu(ByRef erroMsg As String) As Boolean
        If Not EnsureMenuTable(erroMsg) Then Return False
        Return EnsureMenuData(erroMsg)
    End Function

    '预置菜单项总数
    Public Function GetPresetMenuCount() As Integer
        Return PresetMenu.Length
    End Function

    Private Function FormNameValue(strFormName As String) As Object
        If String.IsNullOrEmpty(strFormName) Then Return DBNull.Value
        Return strFormName
    End Function

    Private Function TableExists(rcOleDbCommand As OleDbCommand, strTableName As String) As Boolean
        rcOleDbCommand.CommandText = "SELECT COUNT(*) FROM user_tables WHERE table_name = ?"
        rcOleDbCommand.Parameters.Clear()
        rcOleDbCommand.Parameters.Add("@table_name", OleDbType.VarChar, 30).Value = strTableName
        Return Convert.ToInt32(rcOleDbCommand.ExecuteScalar()) > 0
    End Function

    Private Sub EnsureColumn(rcOleDbCommand As OleDbCommand, strColumnName As String, strColumnDef As String)
        rcOleDbCommand.CommandText = "SELECT COUNT(*) FROM user_tab_columns WHERE table_name = 'RC_MENU' AND column_name = ?"
        rcOleDbCommand.Parameters.Clear()
        rcOleDbCommand.Parameters.Add("@column_name", OleDbType.VarChar, 30).Value = strColumnName
        If Convert.ToInt32(rcOleDbCommand.ExecuteScalar()) > 0 Then Return
        rcOleDbCommand.CommandText = "ALTER TABLE rc_menu ADD " & strColumnDef
        rcOleDbCommand.ExecuteNonQuery()
    End Sub

    Private Sub CloseConnection()
        If sysOleDbConn.State = ConnectionState.Open Then
            sysOleDbConn.Close()
        End If
    End Sub

End Module
