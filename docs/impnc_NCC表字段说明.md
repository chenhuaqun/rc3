# impnc（导入用友NC数据）NCC 表与字段说明

- 来源代码：`sys/FrmImpNC.vb`（窗体 `FrmImpNC`，标题“导入用友NC数据”）
- 范围：仅整理**从 NCC（用友NC，Oracle 库）读取数据**所使用的表与字段；“写入本地目标”一列仅作对应关系标注，本地表（`rc_*`、`gl_pz`、`inv_*`、`oe_*`、`po_rkd`、`ar_skd`、`gl_kmyeb` 等）字段清单及“回写NC”（`BtnWrite` 对 `ic_finprodin_b`、`ic_openbal_b` 的 UPDATE）不在本文档范围内。
- 文中标注为 `xx_h` / `xx_b` 的为 NC 单据表头/表体，查询中以子查询形式出现，外层用别名（如 `ic_material`、`list`）再取列。

---

## 1. 概述

### 1.1 连接与账套

| 项目 | 说明 |
| --- | --- |
| 连接方式 | `OraOLEDB.Oracle.1`，直连 NC 的 Oracle 数据库（TCP/1521） |
| 连接参数 | 本地 `rc_para`（`dwdm` = 当前单位）中 5 项：`NCACCOUNTINGBOOK`（账套编码）、`NCHOST`、`NCSERVICE_NAME`、`NCUser_ID`、`NCPASSWORD`；缺一提示“请定义用友NC数据源信息” |
| 账套过滤 | 账簿类查询 `org_accountingbook.code = 账套编码`；单据类查询 `org_orgs.code = 账套编码` |
| 有效性过滤 | 单据与档案查询普遍带 `dr = 0`（未删除）；例外：`bd_material` 的“物料信息”查询、`ar_estirecitem` 用 `nvl(dr,0)=0` |
| 期间/日期过滤 | 凭证：`gl_voucher.year`、`gl_voucher.period`；期初余额：`gl_balance.year` 且 `gl_balance.period = '00'`（年初数）；收款单：`ar_gatherbill.billyear`、`billperiod`；出入库单据：单据日期 `dbilldate`/`dbizdate` 在所选年月区间内；库存期初：`SUBSTR(dbilldate,1,4) = 所选年份`；物料信息：无过滤（全量） |
| 仓库过滤 | 界面“仓库编码”选择后拼成 `bd_stordoc.code IN ('账套编码'+仓库编码, ...)`（`TxtNCCkdm`） |
| 空值占位 | 查询结果中 `'~'` 表示该辅助项/字段无值 |
| 自定义项序号 | 由本地 `rc_para` 配置：`收款单据表体售达方属性序号`、`收款期属性序号`、`销售订单表体折扣原物料编码属性序号`、`销售发票表头发票号属性序号` |

### 1.2 功能模块 → NC 表 → 写入本地目标

| 界面功能（复选框） | NC 取数主表 | 关联 NC 表 | 写入本地 |
| --- | --- | --- | --- |
| 总账凭证 `ChbPz` | `gl_voucher`、`gl_detail`、`gl_freevalue` | `bd_vouchertype`、`bd_accasoa`、`bd_account`、`bd_currtype`、`org_accountingbook`；辅助核算转换：`bd_accassitem`、`org_orgs`、`bd_psndoc`、`bd_cust_supplier`、`bd_customer`、`bd_supplier`、`bd_bankaccbas` | `gl_pz`（并自动补 `gl_kmxx`、`rc_wbxx`、`rc_khxx`、`rc_csxx`，重算总账 `USP3_REDO_KMYEHZ`） |
| 期初余额 `ChbQc` | `gl_balance`、`gl_freevalue` | 同凭证的辅助核算转换表 | `gl_kmyeb`（并补 `gl_kmxx`、`rc_wbxx`、`rc_khxx`、`rc_csxx`） |
| 收款单(SKDJ) `ChbSkd` | `ar_gatherbill`、`ar_gatheritem` | `bd_balatype`、`bd_customer`、`org_orgs` | `ar_skd`（并补 `rc_jsfs`、`rc_khxx`） |
| 客户收款期与业务员 `ChbKh` | `bd_custfinance` | `bd_psndoc`、`bd_customer`、`bd_defdoc`、`org_orgs` | 更新本地 `rc_khxx.zydm/zymc/skqx` |
| 材料出库(LLCK) `ChbInvCkd` | `ic_material_h`、`ic_material_b` | `bd_stordoc`、`bd_material`、`bd_measdoc`、`bd_marbasclass`、`org_orgs`、`org_dept` | `inv_ckd`（`USP3_SAVE_INV_CKD`，单据类型 LLCK；补 `rc_cpxx`、`rc_ckxx`） |
| 其它出库(CKTZ) `ChbQtck` | `ic_generalout_h`、`ic_generalout_b` | 同上 | `inv_ckd`（`USP3_SAVE_INV_CKD`，CKTZ；补 `rc_cpxx`、`rc_ckxx`） |
| 其它入库(RKTZ) `ChbQtrk` | `ic_generalin_h`、`ic_generalin_b` | 同上 | `po_rkd`（`USP3_SAVE_PO_RKD`，RKTZ；补 `rc_cpxx`、`rc_ckxx`） |
| 库存期初余额 `ChbKcqcye` | `ic_openbal_h`、`ic_openbal_b` | `bd_stordoc`、`bd_material`、`bd_measdoc`、`bd_marbasclass`、`org_orgs` | `inv_cpyeb`（补 `rc_cpxx`） |
| 调拨出库(DBDJ) `ChbInvDbd` | `ic_transout_h`、`ic_transout_b` | `bd_stordoc`（调出/调入两个别名）、`bd_material`、`bd_measdoc`、`bd_marbasclass`、`org_orgs` | `inv_dbd`（`USP3_SAVE_INV_DBD`；补 `rc_cpxx`、`rc_ckxx`） |
| 产成品入库(SCRK) `ChbInvRkd1` | `ic_finprodin_h`、`ic_finprodin_b` | 同材料出库 | `inv_rkd`（`USP3_SAVE_INV_RKD`，SCRK；补 `rc_bmxx`、`rc_cpxx`、`rc_ckxx`） |
| 委外加工入库(WWRK) `ChbInvRkd2` | `ic_subcontin_h`、`ic_subcontin_b` | 同材料出库 | `inv_rkd`（`USP3_SAVE_INV_RKD`，WWRK；补 `rc_cpxx`、`rc_ckxx`） |
| 销售出库(XSCK) `ChbOeXsck` | `ic_saleout_h`、`ic_saleout_b` | `so_saleorder`、`so_saleorder_b`、`bd_stordoc`、`bd_material`、`bd_measdoc`、`bd_marbasclass`、`org_orgs`、`org_dept`、`bd_customer`（售达方/开票方各一） | `oe_xsd`（`USP3_SAVE_OE_XSD`；补 `rc_bmxx`、`rc_cpxx`、`rc_ckxx`、`rc_khxx`） |
| 销售发票(XSFP) `ChbOeXsfp` | `so_saleinvoice`、`so_saleinvoice_b` | `so_saleorder`、`so_saleorder_b`、`bd_material`、`bd_measdoc`、`bd_marbasclass`、`bd_stordoc`、`org_orgs`、`org_dept`、`bd_customer`×2 | `oe_fp`（`USP3_SAVE_OE_FP`，XSFP；补 `rc_cpxx`、`rc_khxx`） |
| 暂估应收(ZGYS) `ChbOeZgys` | `ar_estirecitem` | `so_saleorder`、`so_saleorder_b`、`org_orgs`、`bd_material`、`bd_customer`×2、`bd_measdoc`、`org_dept` | `oe_fp`（`USP3_SAVE_OE_FP`，ZGYS；补 `rc_cpxx`、`rc_khxx`） |
| 采购入库(CGRK) `ChbPoRkd` | `ic_purchasein_h`、`ic_purchasein_b` | `bd_stordoc`、`bd_material`、`bd_measdoc`、`bd_marbasclass`、`org_orgs`、`org_dept`、`bd_supplier` | `po_rkd`（`USP3_SAVE_PO_RKD`，CGRK；补 `rc_cpxx`、`rc_ckxx`、`rc_csxx`） |
| 物料信息 `ChbCpdm` | `bd_material` | `bd_measdoc`、`bd_marbasclass` | `rc_cpxx`（含 `cpweight`） |

---

## 2. 业务单据与账表类 NC 表

### 2.1 总账凭证 `ChbPz`

#### gl_voucher（凭证头）

| 字段 | 含义 | 用途 |
| --- | --- | --- |
| `year` | 会计年 | 与 `period` 一起按界面年月过滤 |
| `period` | 会计期间 | 过滤条件 `gl_voucher.period = ?` |
| `num` | 凭证号 | → `pzh`（拼入本地单据号 `djh`） |
| `prepareddate` | 制单日期 | → `pzrq` |
| `attachment` | 附件张数 | → `fjzs` |
| `pk_voucher` | 凭证主键 | 与 `gl_detail` 关联 |
| `pk_vouchertype` | 凭证类型主键 | 关联 `bd_vouchertype` 取凭证类型代码/名称 |
| `pk_accountingbook` | 会计核算簿主键 | 关联 `org_accountingbook`，按账套编码过滤 |

#### gl_detail（凭证明细行）

| 字段 | 含义 | 用途 |
| --- | --- | --- |
| `pk_voucher` | 所属凭证 | 关联 `gl_voucher` |
| `detailindex` | 分录行号 | → `xh` |
| `explanation` | 摘要 | → `zy` |
| `pk_accasoa` | 科目（辅助核算段） | 关联 `bd_accasoa` 取科目名称，关联 `bd_account` 取科目编码 |
| `oppositesubj` | 对方科目（pk 串，逗号分隔） | 逐个转 `bd_accasoa`/`bd_account` → 对方科目编码 `dfkm` |
| `assid` | 辅助核算值 id | 关联 `gl_freevalue.freevalueid` 解析核算项 |
| `pk_currtype` | 币种 | 关联 `bd_currtype` 取币种代码/名称 |
| `debitamount` | 原币借方金额 | → 借方原币 `jfwb` |
| `debitquantity` | 借方数量 | → 借方数量 `jfsl` |
| `localdebitamount` | 本币借方金额 | → 借方本币 `jfje`（判断借贷方向） |
| `creditamount` | 原币贷方金额 | → 贷方原币 `dfwb` |
| `creditquantity` | 贷方数量 | → 贷方数量 `dfsl` |
| `localcreditamount` | 本币贷方金额 | → 贷方本币 `dfje` |
| `dr` | 删除标记 | `= 0` 过滤 |

#### gl_freevalue（辅助核算自由项，最多 9 组）

| 字段 | 含义 | 用途 |
| --- | --- | --- |
| `freevalueid` | 辅助核算值主键 | 关联 `gl_detail.assid` / `gl_balance.assid` |
| `typevalue1` … `typevalue9` | 核算项内容串 | 每串前 20 位 = 核算项目类型 pk（查 `bd_accassitem`），后 20 位 = 档案值 pk（再按类型查对应档案表）；值为 `'NN/A'` 表示该组未使用，程序取 `'~'` |

辅助核算转换时按 `bd_accassitem.name` 分派：

| `bd_accassitem.name` | 取值表 | 取值字段 | 结果 |
| --- | --- | --- | --- |
| 部门 | `org_orgs` | `code`、`name` | 部门编码/名称 |
| 人员档案 | `bd_psndoc` | `code`、`name` | 职员编码/名称 |
| 客商 | `bd_cust_supplier` | `code`、`name` | 科目编码为 `2202*`/`2241`/`22510114` 时作供应商，否则作客户 |
| 客户档案 | `bd_customer` | `code`、`name` | 客户编码/名称 |
| 供应商档案 | `bd_supplier` | `code`、`name` | 供应商编码/名称 |
| 银行账户 | `bd_bankaccbas` | `accnum`、`accname` | 银行账号 |

> 说明：SQL 中出现的 `gl_pza`、`gl_kmyeba` 是**查询内部派生别名**（分别由 `gl_voucher`+`gl_detail`、`gl_balance` 子查询生成），不是 NC 实表；`bd_bankdoc`（银行档案）在代码中已注释，当前未启用。

#### gl_balance（科目期初余额，`ChbQc`）

| 字段 | 含义 | 用途 |
| --- | --- | --- |
| `year` | 会计年 | 过滤条件 |
| `period` | 会计期间 | 固定取 `'00'`（年初余额） |
| `pk_accasoa` | 科目（辅助核算段） | 取科目编码 `kmdm`、科目名称 `kmmc` |
| `assid` | 辅助核算值 id | 关联 `gl_freevalue` 解析部门/人员/客商/客户/供应商/银行账户 |
| `pk_currtype` | 币种 | 取币种代码/名称 |
| `debitamount` / `debitquantity` / `localdebitamount` | 原币借方 / 借方数量 / 本币借方 | 期初借方 `jfwb`/`jfsl`/`jfje` |
| `creditamount` / `creditquantity` / `localcreditamount` | 原币贷方 / 贷方数量 / 本币贷方 | 期初贷方 `dfwb`/`dfsl`/`dfje` |
| `pk_accountingbook` | 核算簿 | 关联 `org_accountingbook` 按账套过滤 |

#### 账簿与凭证基础表

| 表 | 使用字段 | 含义与用途 |
| --- | --- | --- |
| `org_accountingbook` | `pk_accountingbook`、`code` | 核算簿；`code` = 界面账套编码，凭证/期初查询的账套过滤条件 |
| `bd_account` | `pk_account`、`code` | 科目主档；`code` → 科目编码 `kmdm`（含对方科目转换） |
| `bd_accasoa` | `pk_accasoa`、`pk_account`、`name` | 科目辅助核算段；`name` → 科目名称 `kmmc`；配合 `bd_account.code` 取科目编码 |
| `bd_vouchertype` | `pk_vouchertype`、`code`、`name` | 凭证类型；`code` → `pzlxdm`（拼入本地单据号前缀），`name` → 类型简称 |
| `bd_currtype` | `pk_currtype`、`code`、`name` | 币种；`code` → 币种代码 `bz`，`name` → 币种名称（本地 `rc_wbxx` 无此币种时自动新增） |
| `bd_accassitem` | `pk_accassitem`、`code`、`name` | 辅助核算项目类型；`name` 用于分派到对应档案表取编码/名称（见上表） |

---

### 2.2 收款单(SKDJ) `ChbSkd`

#### ar_gatherbill（收款单头）

| 字段 | 含义 | 用途 |
| --- | --- | --- |
| `pk_gatherbill` | 收款单主键 | 关联 `ar_gatheritem` |
| `billyear` | 单据年 | 按界面年份过滤 |
| `billperiod` | 单据期间 | 按界面月份过滤 |
| `dr` | 删除标记 | `= 0` |

#### ar_gatheritem（收款单行）

| 字段 | 含义 | 用途 |
| --- | --- | --- |
| `billno` | 单据号 | → `djh`（本地单据号） |
| `billdate` | 收款日期 | → `skrq` |
| `def{N}` | 表体自定义项 N（售达方） | `N` = 本地参数“收款单据表体售达方属性序号”；值为客户 pk，关联 `bd_customer` 取客户编码/名称 |
| `ordercubasdoc` | 订单客户 | 第一种取数（`def{N}`）结果为 0 行时的回退路径，同样关联 `bd_customer` |
| `pk_balatype` | 结算方式 | 关联 `bd_balatype` 取结算方式代码/名称 |
| `invoiceno` | 原凭证号 | → 原凭证 `ypz` |
| `local_money_cr` | 本币贷方发生额 | → 金额 `je` |
| `scomment` | 备注 | → 收款备注 `skmemo` |
| `pk_org` | 组织 | 关联 `org_orgs`（且 `isbusinessunit='Y'`），按组织编码过滤 |
| `dr` | 删除标记 | `= 0` |

配套维表：`bd_balatype`（`pk_balatype`、`code`→结算方式代码、`name`→结算方式名称）、`bd_customer`（`pk_customer`、`code`、`name`）、`org_orgs`（`pk_org`、`code`、`isbusinessunit`）。

---

### 2.3 客户收款期与业务员 `ChbKh`

#### bd_custfinance（客户财务/责任信息）

| 字段 | 含义 | 用途 |
| --- | --- | --- |
| `pk_customer` | 客户 | 关联 `bd_customer` 取客户编码 `khdm` |
| `pk_resppsn1` | 责任业务员 | 关联 `bd_psndoc` 取业务员编码/名称 |
| `def{N}` | 自定义项 N（收款期） | `N` = 本地参数“收款期属性序号”；值为客户自定义档案 pk，关联 `bd_defdoc` 取收款期名称 |
| `pk_org` | 组织 | 关联 `org_orgs` 按账套编码过滤 |
| `dr` | 删除标记 | `= 0` |

配套维表：`bd_defdoc`（`pk_defdoc`、`name`→收款期 `skqx`、`dr`）、`bd_customer`（`pk_customer`、`code`、`dr`）、`bd_psndoc`（`pk_psndoc`、`code`、`name`、`dr`）、`org_orgs`（`pk_org`、`code`、`dr`）。

---

### 2.4 库存出入库单据（共用结构）

以下 NC 单据均为“表头 `_h` + 表体 `_b`”，共同结构如下（差异字段见各表）：

**表头 `_h` 共用字段**

| 字段 | 含义 | 用途 |
| --- | --- | --- |
| `pk_org` | 组织 | 关联 `org_orgs`，按账套/组织编码过滤 |
| `cgeneralhid` | 单据表头主键 | 关联同名单据表体 |
| `vbillcode` | 单据号 | → 本地单据号 `djh`（截取末 5 位拼年月与单据类型前缀） |
| `dbilldate` | 单据日期 | 取数期间过滤条件（`to_date(...,'yyyy-mm-dd HH24:mi:ss')` 区间）；部分单据作为业务日期来源 |
| `cwarehouseid` | 仓库 | 关联 `bd_stordoc` 取仓库编码/名称（编码带账套前缀，入库时剥离） |
| `cdptid` | 部门 | 关联 `org_dept` 取部门编码/名称（调拨、库存期初无此字段） |
| `dr` | 删除标记 | `= 0` |

**表体 `_b` 共用字段**

| 字段 | 含义 | 用途 |
| --- | --- | --- |
| `cgeneralhid` | 所属表头 | 关联表头 |
| `crowno` | 行号 | → 行号 `xh` |
| `dbizdate` | 业务日期 | → 单据业务日期（部分单据以其作为期间过滤条件） |
| `cmaterialvid` | 物料版本 | 关联 `bd_material` 取物料编码/名称/单位/分类 |
| `vbatchcode` | 批号 | → 批号 |
| `nassistnum` | 辅助数量 | → 辅助数量 |
| `nnum` | 数量 | → 数量 `sl` |
| `nweight` | 重量 | → 重量 `zl`（写入本地辅助数量字段，单位 KG） |
| `ncostprice` | 成本单价 | → 单价 `dj` |
| `ncostmny` | 成本金额 | → 金额 `je` |
| `vnotebody` | 备注 | → 出入库备注 |
| `cgeneralbid` | 表体行主键 | → 本地 `cbill_bid`（用于回写 NC 成本） |
| `dr` | 删除标记 | `= 0` |

#### ic_material_h / ic_material_b（材料出库 → LLCK）

- 过滤：`org_orgs.code = ?`、`dbilldate` 在所选期间、可选 `bd_stordoc.code IN (...)`。
- 表体取：`crowno`、`dbizdate`→出库日期、`vbatchcode`、`nassistnum`、`nnum`、`nweight`、`ncostprice`、`ncostmny`、`vnotebody`→出库备注、`cgeneralbid`。
- 表头取：`vbillcode`、`cwarehouseid`、`cdptid`、`dbilldate`、`pk_org`。
- 关联：`bd_stordoc`、`bd_material`、`bd_measdoc`、`bd_marbasclass`、`org_orgs`、`org_dept`。

#### ic_generalout_h / ic_generalout_b（其它出库 → CKTZ）

字段与材料出库完全一致（`ic_generalout_*`）。

#### ic_generalin_h / ic_generalin_b（其它入库 → RKTZ）

- 表体取数在共用字段外，金额类改取成本：`ncostprice`→单价/含税单价、`ncostmny`→金额，税率/税额固定置 0（`shlv=0`、`se=0`）。
- 业务日期：`ic_generalin_b.dbizdate` → 入库日期；期间过滤用表头 `dbilldate`。

#### ic_openbal_h / ic_openbal_b（库存期初余额）

| 字段 | 含义 | 用途 |
| --- | --- | --- |
| `ic_openbal_h.vbillcode` | 单据号 | 溯源（本地按年度汇总，不逐单保存） |
| `ic_openbal_h.dbilldate` | 单据日期 | `SUBSTR(...,1,4) = 所选年份` 过滤期初年度 |
| `ic_openbal_h.cwarehouseid` | 仓库 | 关联 `bd_stordoc` 取仓库编码 `ckdm`（子查询内取的 `name` 未进入汇总输出）并做仓库过滤 |
| `ic_openbal_b.nassistnum` / `nnum` / `nweight` | 辅助数量 / 数量 / 重量 | `SUM` 汇总 → 期初数量/重量 |
| `ic_openbal_b.ncostmny` | 成本金额 | `SUM` 汇总 → 期初金额 |
| `ic_openbal_b.vbatchcode` / `vnotebody` / `cgeneralbid` / `crowno` / `dr` | 批号 / 备注 / 行主键 / 行号 / 删除标记 | 查询中选取（汇总时不使用） |
| `bd_marbasclass.pk_marbasclass` | 物料分类主键 | 作为 `lbdm` 输出（注意：此处取主键而非分类代码） |

#### ic_transout_h / ic_transout_b（调拨出库 → DBDJ）

| 字段 | 含义 | 用途 |
| --- | --- | --- |
| `ic_transout_h.cwarehouseid` | 调出仓库 | 关联 `bd_stordoc`（别名 bd_stordoc）→ 调出仓库编码/名称 |
| `ic_transout_h.cotherwhid` | 调入仓库 | 关联 `bd_stordoc bd_stordoc_r` → 调入仓库编码/名称 |
| `ic_transout_h.dbilldate` | 单据日期 | 调拨日期 `dbrq` + 期间过滤 |
| `ic_transout_b.vnotebody` | 备注 | → 调拨备注 `dbmemo` |
| 其余表头/表体字段 | 同共用结构 | 单据号、行号、物料、数量、重量等（无 `ncostprice`/`ncostmny` 取数） |

无部门（`org_dept`）关联，无仓库过滤条件拼接。

#### ic_finprodin_h / ic_finprodin_b（产成品入库 → SCRK）

- 表头：`vbillcode`、`dbilldate`→入库日期、`cwarehouseid`、`cdptid`、`pk_org`。
- 表体：`crowno`、`dbizdate`、`cmaterialvid`、`vbatchcode`、`nassistnum`、`nnum`、`nweight`、`ncostprice`、`ncostmny`（均 `COALESCE(...,0)` 空值置 0）、`vnotebody`→入库备注、`cgeneralbid`（回写成本用）。
- 关联同材料出库；`cgeneralbid` 保存到本地 `cbill_bid`，供“回写NC”更新 `ic_finprodin_b.ncostprice/ncostmny`。

#### ic_subcontin_h / ic_subcontin_b（委外加工入库 → WWRK）

字段结构与产成品入库一致（`ic_subcontin_*`，`ncostprice`/`ncostmny` 不做 `COALESCE`）。

#### ic_purchasein_h / ic_purchasein_b（采购入库 → CGRK）

| 字段 | 含义 | 用途 |
| --- | --- | --- |
| `ic_purchasein_h.cvendorid` | 供应商 | 关联 `bd_supplier` 取供应商编码/名称 |
| `ic_purchasein_b.nqtnetprice` | 原币单价 | → 单价 `dj` |
| `ic_purchasein_b.nqttaxnetprice` | 原币含税单价 | → 含税单价 `hsdj` |
| `ic_purchasein_b.norigmny` | 原币金额 | → 金额 `je` |
| `ic_purchasein_b.ntaxrate` | 税率 | → 税率 `shlv` |
| `ic_purchasein_b.ntax` | 税额 | → 税额 `se` |
| 其余 | 同共用结构 | 单据号、行号、`dbizdate`→入库日期、仓库、部门、物料、批号、数量、重量、备注、`cgeneralbid` |

#### 表体行主键用途说明

`cgeneralbid` 是 NC 单据表体行主键，随单据保存到本地 `cbill_bid` 字段，仅用于“回写NC”时精确定位 NC 行（`ic_finprodin_b`）。

---

### 2.5 销售出库(XSCK) `ChbOeXsck`

#### ic_saleout_h（销售出库单头）

| 字段 | 含义 | 用途 |
| --- | --- | --- |
| `pk_org` | 组织 | 组织过滤 |
| `cgeneralhid` | 表头主键 | 关联表体 |
| `vbillcode` | 单据号 | → 单据号 `djh` |
| `cwarehouseid` | 仓库 | 关联 `bd_stordoc`，可选仓库 `IN` 过滤 |
| `cdptid` | 部门 | 关联 `org_dept` 取部门编码/名称 |
| `dr` | 删除标记 | `= 0` |

#### ic_saleout_b（销售出库单体）

| 字段 | 含义 | 用途 |
| --- | --- | --- |
| `crowno` | 行号 | → 行号 `xh` |
| `dbizdate` | 业务日期 | → 销售日期 `xsrq`；**期间过滤条件**（本单据按表体日期过滤） |
| `cfirstbillhid` / `cfirstbillbid` | 源单（销售订单）头/行 | 关联 `so_saleorder.csaleorderid` / `so_saleorder_b.csaleorderbid` 取客户、折扣物料、客户订单号 |
| `cmaterialvid` | 物料 | 关联 `bd_material` |
| `vbatchcode` | 批号 | → 批号 |
| `nassistnum` | 辅助数量 | → 辅助数量 |
| `nnum` | 数量 | → 数量 `sl` |
| `nweight` | 重量 | → 重量 `zl` |
| `nprice` | 单价 | → 单价 `dj` |
| `ntaxprice` | 含税单价 | → 含税单价 `hsdj` |
| `nmny` | 金额 | → 金额 `je` |
| `ntaxrate` | 税率 | → 税率 `shlv` |
| `ntax` | 税额 | → 税额 `se` |
| `vnotebody` | 备注 | → 入库备注 `rkmemo` |
| `cgeneralbid` | 行主键 | → `cbill_bid` |
| `dr` | 删除标记 | `= 0` |

#### so_saleorder / so_saleorder_b（销售订单，取客户与自定义项）

| 表 | 字段 | 含义与用途 |
| --- | --- | --- |
| `so_saleorder` | `csaleorderid` | 订单主键；被 `ic_saleout_b.cfirstbillhid` 关联 |
| `so_saleorder` | `ccustomerid` | 售达客户 → 关联 `bd_customer`（别名 kha）取售达方编码/名称 |
| `so_saleorder` | `cinvoicecustid` | 开票客户 → 关联 `bd_customer`（别名 khb）取开票方编码/名称 |
| `so_saleorder` | `dr` | `= 0` |
| `so_saleorder_b` | `csaleorderbid` | 订单行主键；被 `ic_saleout_b.cfirstbillbid` 关联 |
| `so_saleorder_b` | `vbdef{N}` | 表体自定义项 N（折扣原物料编码），`N` = 本地参数“销售订单表体折扣原物料编码属性序号”（默认 1）→ `zkcpdm` |
| `so_saleorder_b` | `dr` | `= 0` |

---

### 2.6 销售发票(XSFP) `ChbOeXsfp`

#### so_saleinvoice（销售发票头，别名 h）

| 字段 | 含义 | 用途 |
| --- | --- | --- |
| `pk_org` | 组织 | 组织过滤 |
| `csaleinvoiceid` | 发票主键 | 关联表体、关联 `so_saleorder`（`b.cfirstid`） |
| `vbillcode` | 单据号 | → 单据号 `djh`（未配置发票号自定义项时使用） |
| `vdef{N}` | 表头自定义项 N（发票号） | `N` = 本地参数“销售发票表头发票号属性序号”；配置后 `CASE WHEN vdef{N} <> '~' THEN vdef{N} ELSE vbillcode END` 作为单据号 |
| `dbilldate` | 单据日期 | → 发票日期 `fprq` + 期间过滤 |
| `dr` | 删除标记 | `= 0` |

#### so_saleinvoice_b（销售发票行，别名 b）

| 字段 | 含义 | 用途 |
| --- | --- | --- |
| `crowno` | 行号 | → 行号 `xh` |
| `cfirstid` / `cfirstbid` | 源单（销售订单）头/行 | 关联 `so_saleorder` / `so_saleorder_b` 取客户、折扣物料、订单自定义项 |
| `cmaterialvid` | 物料 | 关联 `bd_material` |
| `cunitid` | 计量单位 | 关联 `bd_measdoc` 取单位名称 |
| `csendstordocid` | 发货仓库 | 关联 `bd_stordoc`，同时用于仓库 `IN` 过滤 |
| `cdeptid` | 部门 | 关联 `org_dept` 取部门编码/名称 |
| `vbatchcode` | 批号 | → 批号 |
| `nnum` | 数量 | → 数量 `sl` |
| `nprice` | 单价 | → 单价 `dj` |
| `ntaxprice` | 含税单价 | → 含税单价 `hsdj` |
| `nmny` | 金额 | → 金额 `je` |
| `ntaxrate` | 税率 | → 税率 `shlv` |
| `ntax` | 税额 | → 税额 `se` |
| `vrownote` | 行备注 | → 发票备注 `fpmemo` |
| `csaleinvoicebid` | 行主键 | → `cbill_bid` |
| `vsrccode` | 源单号 | → 销售订单号 `xsddjh` |
| `vsrcrowno` | 源单行号 | → 销售订单行号 `xsdxh` |
| `dr` | 删除标记 | `= 0` |

`so_saleorder`/`so_saleorder_b` 取数字段同销售出库，另取 `vbdef38`→手工订单号 `sgddh`、`vbdef6`→客户订单号 `khddh`。

---

### 2.7 暂估应收(ZGYS) `ChbOeZgys`

#### ar_estirecitem（暂估应收单行，别名 b）

| 字段 | 含义 | 用途 |
| --- | --- | --- |
| `pk_estirecbill` | 暂估应收单主键 | 单据标识 |
| `billno` | 单据号 | → 单据号 `djh` |
| `rowno` | 行号 | → 行号 `xh` |
| `billdate` | 单据日期 | → 发票日期 `fprq` + 期间过滤 |
| `pk_deptid` | 部门 | 关联 `org_dept` 取部门编码/名称 |
| `pk_org` | 组织 | 关联 `org_orgs` 按账套过滤 |
| `material` | 物料 | 关联 `bd_material` 取物料编码/名称/分类；关联 `bd_measdoc` 取单位 |
| `batchcode` | 批号 | → 批号 |
| `quantity_de` | 数量 | → 数量 `sl` |
| `price` | 单价 | → 单价 `dj` |
| `taxprice` | 含税单价 | → 含税单价 `hsdj` |
| `local_notax_de` | 本币无税金额 | → 金额 `je` |
| `taxrate` | 税率 | → 税率 `shlv` |
| `local_tax_de` | 本币税额 | → 税额 `se` |
| `local_money_de` | 本币价税合计 | → 价税合计 `jese` |
| `src_billid` / `src_itemid` | 源单（销售订单）头/行 | 关联 `so_saleorder` / `so_saleorder_b` 取售达方、开票方、折扣物料、订单自定义项 |
| `dr` | 删除标记 | `nvl(dr,0) = 0` |

---

## 3. 基础档案 / 维表（跨功能共用）

| 表 | 使用字段 | 含义与用途 | 使用功能 |
| --- | --- | --- | --- |
| `org_orgs` | `pk_org`、`code`、`name`、`dr`、`isbusinessunit` | 组织/公司；`code` = 账套或组织编码，是所有单据取数的**主过滤条件**；`name` 在辅助核算“部门”分派时取部门名称；`isbusinessunit='Y'` 用于收款单 | 全部单据、凭证辅助核算、收款单 |
| `org_dept` | `pk_dept`、`code`、`name` | 部门；`LEFT JOIN` 取部门编码/名称，空值置 `'~'` | 除调拨、库存期初外的出入库单据、销售发票、暂估应收 |
| `bd_stordoc` | `pk_stordoc`、`code`、`name` | 仓库；`code` → 仓库编码（带账套前缀，保存前剥离前缀），`name` → 仓库名称；`code IN (...)` 实现分仓库导入 | 全部出入库单据、库存期初 |
| `bd_material` | `pk_material`、`code`、`name`、`materialtype`、`materialspec`、`pk_measdoc`、`pk_marbasclass`、`unitweight`、`dr` | 物料；`code` → 物料编码；`name \|\| ',' \|\| materialtype \|\| ',' \|\| materialspec` → 物料名称（名称,类型,规格）；`pk_measdoc` 关联单位；`pk_marbasclass` 关联分类；`unitweight` 单件重量（物料信息功能） | 所有出入库、销售、暂估、物料信息 |
| `bd_measdoc` | `pk_measdoc`、`name` | 计量单位；`name` → 单位 `dw` | 所有含物料的单据 |
| `bd_marbasclass` | `pk_marbasclass`、`code`、`name` | 物料分类；`code` → 物料类别 `lbdm`；但**库存期初、销售出库、销售发票、暂估应收**四个查询取 `pk_marbasclass` 主键作为 `lbdm`；`name` → 类别名称 `lbmc`（物料信息） | 所有含物料的单据、物料信息 |
| `bd_customer` | `pk_customer`、`code`、`name`、`dr` | 客户；`code`/`name` → 客户编码/名称；销售单据分别作为售达方（`kha`）与开票方（`khb`） | 凭证辅助核算、收款单、销售出库/发票/暂估、客户收款期 |
| `bd_supplier` | `pk_supplier`、`code`、`name` | 供应商；→ 供应商编码/名称 | 采购入库、凭证辅助核算 |
| `bd_cust_supplier` | `pk_cust_sup`、`code`、`name`（另查 `pk_custclass`、`pk_supplierclass`） | 客商（客户/供应商合一档案）；按科目编码判断写入客户或供应商 | 凭证、期初余额辅助核算 |
| `bd_psndoc` | `pk_psndoc`、`code`、`name` | 人员档案；→ 职员编码/名称（凭证辅助核算“人员档案”）；→ 业务员编码/名称（客户收款期） | 凭证/期初辅助核算、客户收款期 |
| `bd_bankaccbas` | `pk_bankaccbas`、`accnum`、`accname` | 银行账户；`accnum` → 银行账号 `yhzh` | 凭证、期初余额辅助核算“银行账户” |
| `bd_balatype` | `pk_balatype`、`code`、`name` | 结算方式；→ 结算方式代码/名称 | 收款单 |

---

## 4. 公共机制说明

1. **账套/组织过滤**：凭证与期初按 `org_accountingbook.code`；单据与档案按 `org_orgs.code`，值来自 `rc_para.NCACCOUNTINGBOOK`。
2. **仓库过滤与前缀剥离**：界面选择仓库后生成 `bd_stordoc.code IN ('账套编码'+仓库编码, ...)`；读回的仓库编码若以账套编码开头则剥离前缀，得到本地仓库编码。
3. **辅助核算解析**：`gl_freevalue.typevalueN` 前 20 位 = 核算项目类型 pk → `bd_accassitem.name`；后 20 位 = 档案值 pk → 按类型分别查 `org_orgs`/`bd_psndoc`/`bd_cust_supplier`/`bd_customer`/`bd_supplier`/`bd_bankaccbas`；未使用的组取 `'~'`。对方科目 `gl_detail.oppositesubj` 为逗号分隔的 `pk_accasoa` 串，逐个转换为科目编码。
4. **自定义项序号**：`vbdef{N}` / `vdef{N}` / `def{N}` / `typevalueN` 中的 `N` 由本地 `rc_para` 参数决定（收款单据表体售达方属性序号、收款期属性序号、销售订单表体折扣原物料编码属性序号、销售发票表头发票号属性序号），首次运行时按界面选择回写 `rc_para`。
5. **`'~'` 占位符**：NC 无值的辅助项、部门、仓库等统一取 `'~'`，后续本地逻辑据此判断是否为空。
6. **单据日期口径**：出入库单据**过滤**用表头 `dbilldate`，**取业务日期**用表体 `dbizdate`（销售出库例外，过滤与取值均用表体 `dbizdate`）；收款单按 `billyear`/`billperiod` 过滤；期初库存按表头 `dbilldate` 的年份过滤。
7. **行主键留存**：`ic_*_b.cgeneralbid`、`so_saleinvoice_b.csaleinvoicebid` 保存为本地 `cbill_bid`，用于回写NC时定位 NC 行（回写部分不在本文档范围）。
