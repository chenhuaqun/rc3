-- 动态菜单完整数据更新脚本 v2.0
-- 基于 rc_menu 表 mnuiown = 'RC3'
-- 需要先执行 MenuMigration.sql 添加字段

-- ============================================
-- 顶级父菜单
-- ============================================
UPDATE rc_menu SET mnuiparentid = '0', mnuisortorder = 10, mnuiformname = NULL WHERE mnuiid = '10' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '0', mnuisortorder = 20, mnuiformname = NULL WHERE mnuiid = '20' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '0', mnuisortorder = 30, mnuiformname = NULL WHERE mnuiid = '30' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '0', mnuisortorder = 40, mnuiformname = NULL WHERE mnuiid = '40' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '0', mnuisortorder = 50, mnuiformname = NULL WHERE mnuiid = '50' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '0', mnuisortorder = 60, mnuiformname = NULL WHERE mnuiid = '60' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '0', mnuisortorder = 70, mnuiformname = NULL WHERE mnuiid = '70' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '0', mnuisortorder = 80, mnuiformname = NULL WHERE mnuiid = '80' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '0', mnuisortorder = 90, mnuiformname = NULL WHERE mnuiid = '90' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '0', mnuisortorder = 99, mnuiformname = NULL WHERE mnuiid = '99' AND mnuiown = 'RC3';

-- ============================================
-- 基础数据子菜单 (1001-1030) -> 父ID: 10
-- ============================================
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 1, mnuiformname = 'FrmCplbxx' WHERE mnuiid = '1001' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 2, mnuiformname = 'FrmCpGroup' WHERE mnuiid = '1002' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 3, mnuiformname = 'FrmCpxx' WHERE mnuiid = '1003' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 4, mnuiformname = 'FrmBom' WHERE mnuiid = '1004' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 5, mnuiformname = 'FrmKhlbxx' WHERE mnuiid = '1005' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 6, mnuiformname = 'FrmKhXslbxx' WHERE mnuiid = '1006' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 7, mnuiformname = 'FrmKhxx' WHERE mnuiid = '1007' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 8, mnuiformname = 'FrmKhshdzxx' WHERE mnuiid = '1008' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 9, mnuiformname = 'FrmKhzyxx' WHERE mnuiid = '1009' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 10, mnuiformname = 'FrmCslbxx' WHERE mnuiid = '1010' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 11, mnuiformname = 'FrmCsxx' WHERE mnuiid = '1011' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 12, mnuiformname = 'FrmBmxx' WHERE mnuiid = '1012' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 13, mnuiformname = 'FrmZyxx' WHERE mnuiid = '1013' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 14, mnuiformname = 'FrmCkxx' WHERE mnuiid = '1014' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 15, mnuiformname = 'FrmCostRegionxx' WHERE mnuiid = '1015' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 16, mnuiformname = 'FrmJldwxx' WHERE mnuiid = '1016' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 17, mnuiformname = 'FrmGxxx' WHERE mnuiid = '1017' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 18, mnuiformname = 'FrmKmxx' WHERE mnuiid = '1018' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 19, mnuiformname = 'FrmJsfsxx' WHERE mnuiid = '1019' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 20, mnuiformname = 'FrmWbxx' WHERE mnuiid = '1020' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 21, mnuiformname = 'FrmKcZlxx' WHERE mnuiid = '1021' AND mnuiown = 'RC3';

-- ============================================
-- 期初数据 (1021-1025) -> 父ID: 10
-- ============================================
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 22, mnuiformname = 'FrmQccpyeSr' WHERE mnuiid = '1022' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 23, mnuiformname = 'FrmQcfcspyeSr' WHERE mnuiid = '1023' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 24, mnuiformname = 'FrmQckhyeSr' WHERE mnuiid = '1024' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 25, mnuiformname = 'FrmQccsyeSr' WHERE mnuiid = '1025' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 26, mnuiformname = 'FrmQckmyeSr' WHERE mnuiid = '1026' AND mnuiown = 'RC3';

-- ============================================
-- 单据类型和会计期间 (1026-1027) -> 父ID: 10
-- ============================================
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 27, mnuiformname = 'FrmPzlxxx' WHERE mnuiid = '1027' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 28, mnuiformname = 'FrmKjqj' WHERE mnuiid = '1028' AND mnuiown = 'RC3';

-- ============================================
-- 权限管理 (1028-1030) -> 父ID: 99
-- ============================================
UPDATE rc_menu SET mnuiparentid = '99', mnuisortorder = 1, mnuiformname = 'FrmRoles' WHERE mnuiid = '1029' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '99', mnuisortorder = 2, mnuiformname = 'FrmUsers' WHERE mnuiid = '1030' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '99', mnuisortorder = 3, mnuiformname = 'FrmOption' WHERE mnuiid = '1031' AND mnuiown = 'RC3';

-- ============================================
-- 样品订单 (2001-2009) -> 父ID: 20
-- ============================================
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 1, mnuiformname = 'FrmOeYpddSr' WHERE mnuiid = '2001' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 2, mnuiformname = 'FrmOeYpddBmSr' WHERE mnuiid = '2002' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 3, mnuiformname = 'FrmOeYpddJqSr' WHERE mnuiid = '2003' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 4, mnuiformname = 'FrmOeYpddSh' WHERE mnuiid = '2004' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 5, mnuiformname = 'FrmOeYpFhrqSr' WHERE mnuiid = '2005' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 6, mnuiformname = 'FrmOeYpFhdhSr' WHERE mnuiid = '2006' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 7, mnuiformname = 'FrmOeYpddHx' WHERE mnuiid = '2007' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 8, mnuiformname = 'FrmOeYpddCx' WHERE mnuiid = '2008' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 9, mnuiformname = 'FrmOeYpddDjb' WHERE mnuiid = '2009' AND mnuiown = 'RC3';

-- ============================================
-- 销售订单 (2010-2031) -> 父ID: 20
-- ============================================
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 10, mnuiformname = 'FrmOeBjdSr' WHERE mnuiid = '2010' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 11, mnuiformname = 'FrmOeBjdSh' WHERE mnuiid = '2011' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 12, mnuiformname = 'FrmOeBjdCx' WHERE mnuiid = '2012' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 13, mnuiformname = 'FrmOeDdSr' WHERE mnuiid = '2013' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 14, mnuiformname = 'FrmOeDddjSh' WHERE mnuiid = '2014' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 15, mnuiformname = 'FrmOeDdClose' WHERE mnuiid = '2015' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 16, mnuiformname = 'FrmOeDdJqSr' WHERE mnuiid = '2016' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 17, mnuiformname = 'FrmOeDdSh' WHERE mnuiid = '2017' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 18, mnuiformname = 'FrmOeRkdSr' WHERE mnuiid = '2018' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 19, mnuiformname = 'FrmOeRkdSh' WHERE mnuiid = '2019' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 20, mnuiformname = 'FrmOeFhdSr' WHERE mnuiid = '2020' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 21, mnuiformname = 'FrmOeFhdSh' WHERE mnuiid = '2021' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 22, mnuiformname = 'FrmOeXsdSr' WHERE mnuiid = '2022' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 23, mnuiformname = 'FrmOeXsdSh' WHERE mnuiid = '2023' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 24, mnuiformname = 'FrmOeXsdHx' WHERE mnuiid = '2024' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 25, mnuiformname = 'FrmOeFpSr' WHERE mnuiid = '2025' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 26, mnuiformname = 'FrmOeFpSh' WHERE mnuiid = '2026' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 27, mnuiformname = 'FrmOeDdCx' WHERE mnuiid = '2027' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 28, mnuiformname = 'FrmOeRkdCx' WHERE mnuiid = '2028' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 29, mnuiformname = 'FrmOeFhdCx' WHERE mnuiid = '2029' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 30, mnuiformname = 'FrmOeXsdCx' WHERE mnuiid = '2030' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 31, mnuiformname = 'FrmOeFpCx' WHERE mnuiid = '2031' AND mnuiown = 'RC3';

-- ============================================
-- 销售汇总表 (2032-2040) -> 父ID: 20
-- ============================================
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 32, mnuiformname = 'FrmOeRkCpHzb' WHERE mnuiid = '2032' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 33, mnuiformname = 'FrmOeRkBmHzb' WHERE mnuiid = '2033' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 34, mnuiformname = 'FrmOeXsRb' WHERE mnuiid = '2034' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 35, mnuiformname = 'FrmOeCplbHzb' WHERE mnuiid = '2035' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 36, mnuiformname = 'FrmOeBmHzb' WHERE mnuiid = '2036' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 37, mnuiformname = 'FrmOeCpHzb' WHERE mnuiid = '2037' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 38, mnuiformname = 'FrmOeCkCpHzb' WHERE mnuiid = '2038' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 39, mnuiformname = 'FrmOeKhHzb' WHERE mnuiid = '2039' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 40, mnuiformname = 'FrmOeZyHzb' WHERE mnuiid = '2040' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 41, mnuiformname = 'FrmOeBmFpHzb' WHERE mnuiid = '2041' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 42, mnuiformname = 'FrmOeCpFpHzb' WHERE mnuiid = '2042' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 43, mnuiformname = 'FrmOeKhFpHzb' WHERE mnuiid = '2043' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '20', mnuisortorder = 44, mnuiformname = 'FrmOeKhFpFxb' WHERE mnuiid = '2044' AND mnuiown = 'RC3';

-- ============================================
-- 生产管理 (3001-3014) -> 父ID: 30
-- ============================================
UPDATE rc_menu SET mnuiparentid = '30', mnuisortorder = 1, mnuiformname = 'FrmPmDdSr' WHERE mnuiid = '3001' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '30', mnuisortorder = 2, mnuiformname = 'FrmPmDdClose' WHERE mnuiid = '3002' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '30', mnuisortorder = 3, mnuiformname = 'FrmPmScGxlzk' WHERE mnuiid = '3003' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '30', mnuisortorder = 4, mnuiformname = 'FrmPmDdGxPg' WHERE mnuiid = '3004' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '30', mnuisortorder = 5, mnuiformname = 'FrmPmDdGxHb' WHERE mnuiid = '3005' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '30', mnuisortorder = 6, mnuiformname = 'FrmPmCkdSr' WHERE mnuiid = '3006' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '30', mnuisortorder = 7, mnuiformname = 'FrmPmCkdSh' WHERE mnuiid = '3007' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '30', mnuisortorder = 8, mnuiformname = 'FrmPmRkdSr' WHERE mnuiid = '3008' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '30', mnuisortorder = 9, mnuiformname = 'FrmPmRkdSh' WHERE mnuiid = '3009' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '30', mnuisortorder = 10, mnuiformname = 'FrmPmCkdCx' WHERE mnuiid = '3010' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '30', mnuisortorder = 11, mnuiformname = 'FrmPmRkdCx' WHERE mnuiid = '3011' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '30', mnuisortorder = 12, mnuiformname = 'FrmPmDdGxlzCx' WHERE mnuiid = '3012' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '30', mnuisortorder = 13, mnuiformname = 'FrmPmRkCpHzb' WHERE mnuiid = '3013' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '30', mnuisortorder = 14, mnuiformname = 'FrmPmBmRkHzb' WHERE mnuiid = '3014' AND mnuiown = 'RC3';

-- ============================================
-- 物料采购 (4001-4034) -> 父ID: 40
-- ============================================
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 1, mnuiformname = 'FrmPoCgjhSr' WHERE mnuiid = '4001' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 2, mnuiformname = 'FrmPoCgjhSh' WHERE mnuiid = '4002' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 3, mnuiformname = 'FrmPoCgjhClose' WHERE mnuiid = '4003' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 4, mnuiformname = 'FrmCsCpCgdjSr' WHERE mnuiid = '4004' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 5, mnuiformname = 'FrmCsCpCgdjSh' WHERE mnuiid = '4005' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 6, mnuiformname = 'FrmPoCgdSr' WHERE mnuiid = '4006' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 7, mnuiformname = 'FrmPoCgdSh' WHERE mnuiid = '4007' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 8, mnuiformname = 'FrmPoCgdClose' WHERE mnuiid = '4008' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 9, mnuiformname = 'FrmPoRkdSr' WHERE mnuiid = '4009' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 10, mnuiformname = 'FrmPoRkdSh' WHERE mnuiid = '4011' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 11, mnuiformname = 'FrmPoFpSr' WHERE mnuiid = '4012' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 12, mnuiformname = 'FrmPoFpSh' WHERE mnuiid = '4013' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 13, mnuiformname = 'FrmPoLlsqSr' WHERE mnuiid = '4014' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 14, mnuiformname = 'FrmPoLlsqSh' WHERE mnuiid = '4015' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 15, mnuiformname = 'FrmPoLlsqClose' WHERE mnuiid = '4016' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 16, mnuiformname = 'FrmInvRecycleSr' WHERE mnuiid = '4010' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 17, mnuiformname = 'FrmPoCkdSr' WHERE mnuiid = '4017' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 18, mnuiformname = 'FrmPoCkdSr2' WHERE mnuiid = '4018' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 19, mnuiformname = 'FrmPoCkdSh' WHERE mnuiid = '4019' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 20, mnuiformname = 'FrmInvDbdSr' WHERE mnuiid = '4020' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 21, mnuiformname = 'FrmInvDbdSh' WHERE mnuiid = '4021' AND mnuiown = 'RC3';

-- ============================================
-- 物料查询 (4022-4034) -> 父ID: 40
-- ============================================
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 22, mnuiformname = 'FrmPoCgjhCx' WHERE mnuiid = '4022' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 23, mnuiformname = 'FrmCsCpCgdjCx' WHERE mnuiid = '4023' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 24, mnuiformname = 'FrmPoCgdCx' WHERE mnuiid = '4024' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 25, mnuiformname = 'FrmPoRkdCx' WHERE mnuiid = '4025' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 26, mnuiformname = 'FrmPoFpCx' WHERE mnuiid = '4026' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 27, mnuiformname = 'FrmPoLlsqCx' WHERE mnuiid = '4027' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 28, mnuiformname = 'FrmPoCkdCx' WHERE mnuiid = '4028' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 29, mnuiformname = 'FrmInvDbdCx' WHERE mnuiid = '4029' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 30, mnuiformname = 'FrmPoCsHzb' WHERE mnuiid = '4030' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 31, mnuiformname = 'FrmPoBmHzb' WHERE mnuiid = '4031' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 32, mnuiformname = 'FrmPoBmFaLbHzb' WHERE mnuiid = '4032' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 33, mnuiformname = 'FrmCkCkCpHzb' WHERE mnuiid = '4033' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '40', mnuisortorder = 34, mnuiformname = 'FrmCkDbCpHzb' WHERE mnuiid = '4034' AND mnuiown = 'RC3';

-- ============================================
-- 仓库管理 (5001-5016) -> 父ID: 50
-- ============================================
UPDATE rc_menu SET mnuiparentid = '50', mnuisortorder = 1, mnuiformname = 'FrmInvCktzSr' WHERE mnuiid = '5001' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '50', mnuisortorder = 2, mnuiformname = 'FrmInvPcSr' WHERE mnuiid = '5002' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '50', mnuisortorder = 3, mnuiformname = 'FrmFcspSr' WHERE mnuiid = '5003' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '50', mnuisortorder = 4, mnuiformname = 'FrmInvPcSh' WHERE mnuiid = '5004' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '50', mnuisortorder = 5, mnuiformname = 'FrmSlSfcMx' WHERE mnuiid = '5005' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '50', mnuisortorder = 6, mnuiformname = 'FrmSlSfcHz' WHERE mnuiid = '5006' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '50', mnuisortorder = 7, mnuiformname = 'FrmCpPcb' WHERE mnuiid = '5007' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '50', mnuisortorder = 8, mnuiformname = 'FrmCpSfcMx' WHERE mnuiid = '5008' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '50', mnuisortorder = 9, mnuiformname = 'FrmCpSfcHz' WHERE mnuiid = '5009' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '50', mnuisortorder = 10, mnuiformname = 'FrmJeSfcHz' WHERE mnuiid = '5010' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '50', mnuisortorder = 11, mnuiformname = 'FrmPhSfcMx' WHERE mnuiid = '5011' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '50', mnuisortorder = 12, mnuiformname = 'FrmPhSfcHz' WHERE mnuiid = '5012' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '50', mnuisortorder = 13, mnuiformname = 'FrmCplbSfcHz' WHERE mnuiid = '5013' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '50', mnuisortorder = 14, mnuiformname = 'FrmCpkcZlfx' WHERE mnuiid = '5014' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '50', mnuisortorder = 15, mnuiformname = 'FrmFcspPcb' WHERE mnuiid = '5015' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '50', mnuisortorder = 16, mnuiformname = 'FrmFcspSfcMx' WHERE mnuiid = '5016' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '50', mnuisortorder = 17, mnuiformname = 'FrmFcspSfcHz' WHERE mnuiid = '5017' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '50', mnuisortorder = 18, mnuiformname = 'FrmFcspKhSfcHz' WHERE mnuiid = '5018' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '50', mnuisortorder = 19, mnuiformname = 'FrmFcspBmSfcHz' WHERE mnuiid = '5019' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '50', mnuisortorder = 20, mnuiformname = 'FrmFcspCx' WHERE mnuiid = '5020' AND mnuiown = 'RC3';

-- ============================================
-- 财务 (6001-6025) -> 父ID: 60
-- ============================================
DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '6001';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) VALUES ('6001','60','其他应收单录入与修改','MnuiQtysSr','RC3',1,'FrmQtysSr');
DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '6002';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) VALUES ('6002','60','其他应收单审核','MnuiQtysSh','RC3',2,'FrmQtysSh');
DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '6003';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) VALUES ('6003','60','收款单录入与修改','MnuiSkdSr','RC3',3,'FrmSkdSr');
DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '6004';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) VALUES ('6004','60','收款单审核','MnuiSkdSh','RC3',4,'FrmSkdSh');
DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '6005';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) VALUES ('6005','60','应收账款核销','MnuiSkdHx','RC3',5,'FrmSkdHx');
DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '6006';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) VALUES ('6006','60','其他应付单录入与修改','MnuiQtyfSr','RC3',6,'FrmQtyfSr');
DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '6007';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) VALUES ('6007','60','其他应付单审核','MnuiQtyfSh','RC3',7,'FrmQtyfSh');
DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '6008';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) VALUES ('6008','60','付款单录入与修改','MnuiFkdSr','RC3',10,'FrmFkdSr');
DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '6009';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) VALUES ('6009','60','付款单审核','MnuiFkdSh','RC3',11,'FrmFkdSh');
DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '6010';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) VALUES ('6010','60','应付账款核销','MnuiFkdHx','RC3',12,'FrmFkdHx');
DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '6011';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) VALUES ('6011','60','其他应收单查询','MnuiQtysCx','RC3',13,'FrmQtysCx');
DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '6012';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) VALUES ('6012','60','收款单查询','MnuiSkdCx','RC3',14,'FrmSkdCx');
DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '6013';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) VALUES ('6013','60','其他应付单查询','MnuiQtyfCx','RC3',15,'FrmQtyfCx');
DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '6014';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) VALUES ('6014','60','付款单查询','MnuiFkdCx','RC3',17,'FrmFkdCx');
DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '6015';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) VALUES ('6015','60','客户应收账款明细账','MnuiKhYszkMx','RC3',18,'FrmKhYszkMx');
DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '6016';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) VALUES ('6016','60','客户应收账款核销明细账','MnuiKhYszkHxMx','RC3',19,'FrmKhYszkHxMx');
DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '6017';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) VALUES ('6017','60','客户应收账款汇总表','MnuiKhYszkHz','RC3',20,'FrmKhYszkHz');
DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '6018';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) VALUES ('6018','60','客户类别应收账款汇总表','MnuiKhLbYszkHz','RC3',21,'FrmKhLbYszkHz');
DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '6019';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) VALUES ('6019','60','供应商应付账款明细账','MnuiCsYfzkMx','RC3',22,'FrmCsYfzkMx');
DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '6020';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) VALUES ('6020','60','供应商应付账款汇总表','MnuiCsYfzkHz','RC3',23,'FrmCsYfzkHz');
DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '6021';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) VALUES ('6021','60','供应商类别应付账款汇总表','MnuiCsLbYfzkHz','RC3',24,'FrmCsLbYfzkHz');
DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '6022';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) VALUES ('6022','60','客户收款汇总表','MnuiArKhHzb','RC3',25,'FrmArKhHzb');

UPDATE rc_menu SET mnuiparentid = '60', mnuisortorder = 1, mnuiformname = 'FrmQtysSr' WHERE mnuiid = '6001' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '60', mnuisortorder = 2, mnuiformname = 'FrmQtysSh' WHERE mnuiid = '6002' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '60', mnuisortorder = 3, mnuiformname = 'FrmSkdSr' WHERE mnuiid = '6003' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '60', mnuisortorder = 4, mnuiformname = 'FrmSkdSh' WHERE mnuiid = '6004' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '60', mnuisortorder = 5, mnuiformname = 'FrmSkdHx' WHERE mnuiid = '6005' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '60', mnuisortorder = 6, mnuiformname = 'FrmQtyfSr' WHERE mnuiid = '6006' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '60', mnuisortorder = 7, mnuiformname = 'FrmQtyfSh' WHERE mnuiid = '6007' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '60', mnuisortorder = 8, mnuiformname = 'FrmApFksqSr' WHERE mnuiid = '6023' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '60', mnuisortorder = 9, mnuiformname = 'FrmApFksqSh' WHERE mnuiid = '6024' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '60', mnuisortorder = 10, mnuiformname = 'FrmFkdSr' WHERE mnuiid = '6008' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '60', mnuisortorder = 11, mnuiformname = 'FrmFkdSh' WHERE mnuiid = '6009' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '60', mnuisortorder = 12, mnuiformname = 'FrmFkdHx' WHERE mnuiid = '6010' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '60', mnuisortorder = 13, mnuiformname = 'FrmQtysCx' WHERE mnuiid = '6011' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '60', mnuisortorder = 14, mnuiformname = 'FrmSkdCx' WHERE mnuiid = '6012' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '60', mnuisortorder = 15, mnuiformname = 'FrmQtyfCx' WHERE mnuiid = '6013' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '60', mnuisortorder = 16, mnuiformname = 'FrmApFksqCx' WHERE mnuiid = '6025' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '60', mnuisortorder = 17, mnuiformname = 'FrmFkdCx' WHERE mnuiid = '6014' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '60', mnuisortorder = 18, mnuiformname = 'FrmKhYszkMx' WHERE mnuiid = '6015' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '60', mnuisortorder = 19, mnuiformname = 'FrmKhYszkHxMx' WHERE mnuiid = '6016' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '60', mnuisortorder = 20, mnuiformname = 'FrmKhYszkHz' WHERE mnuiid = '6017' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '60', mnuisortorder = 21, mnuiformname = 'FrmKhLbYszkHz' WHERE mnuiid = '6018' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '60', mnuisortorder = 22, mnuiformname = 'FrmCsYfzkMx' WHERE mnuiid = '6019' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '60', mnuisortorder = 23, mnuiformname = 'FrmCsYfzkHz' WHERE mnuiid = '6020' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '60', mnuisortorder = 24, mnuiformname = 'FrmCsLbYfzkHz' WHERE mnuiid = '6021' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '60', mnuisortorder = 25, mnuiformname = 'FrmArKhHzb' WHERE mnuiid = '6022' AND mnuiown = 'RC3';

-- ============================================
-- 成本 (7001-7013) -> 父ID: 70
-- ============================================
UPDATE rc_menu SET mnuiparentid = '70', mnuisortorder = 1, mnuiformname = 'FrmZcclslSr' WHERE mnuiid = '7001' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '70', mnuisortorder = 2, mnuiformname = 'FrmZcpslSr' WHERE mnuiid = '7002' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '70', mnuisortorder = 3, mnuiformname = 'FrmZcbjeSr' WHERE mnuiid = '7003' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '70', mnuisortorder = 4, mnuiformname = 'FrmCbjz_Cl' WHERE mnuiid = '7004' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '70', mnuisortorder = 5, mnuiformname = 'FrmCbjz_Sccb' WHERE mnuiid = '7005' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '70', mnuisortorder = 6, mnuiformname = 'FrmCbjz_Xscb' WHERE mnuiid = '7006' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '70', mnuisortorder = 7, mnuiformname = 'FrmCbjz_Fcsp' WHERE mnuiid = '7007' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '70', mnuisortorder = 8, mnuiformname = 'FrmZcclMx' WHERE mnuiid = '7008' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '70', mnuisortorder = 9, mnuiformname = 'FrmZcpMx' WHERE mnuiid = '7009' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '70', mnuisortorder = 10, mnuiformname = 'FrmZcpBmGxHz' WHERE mnuiid = '7010' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '70', mnuisortorder = 11, mnuiformname = 'FrmCcpZcpHz' WHERE mnuiid = '7011' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '70', mnuisortorder = 12, mnuiformname = 'FrmCcpZcpBmHz' WHERE mnuiid = '7012' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '70', mnuisortorder = 13, mnuiformname = 'FrmBomCx' WHERE mnuiid = '7013' AND mnuiown = 'RC3';

-- ============================================
-- 总账 (8001-8012) -> 父ID: 80
-- ============================================
DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '8012';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) VALUES ('8012','80','汇总账龄分析表(按账套)','MnuiGlZlfxHz2','RC3',12,'FrmGlZlfxHz2');

UPDATE rc_menu SET mnuiparentid = '80', mnuisortorder = 1, mnuiformname = 'FrmGlPzSr' WHERE mnuiid = '8001' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '80', mnuisortorder = 2, mnuiformname = 'FrmGlPzSh' WHERE mnuiid = '8002' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '80', mnuisortorder = 3, mnuiformname = 'FrmGlPzJz' WHERE mnuiid = '8003' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '80', mnuisortorder = 4, mnuiformname = 'FrmGlPzCx' WHERE mnuiid = '8004' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '80', mnuisortorder = 5, mnuiformname = 'FrmGlKmRjz' WHERE mnuiid = '8005' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '80', mnuisortorder = 6, mnuiformname = 'FrmGlKmMxz' WHERE mnuiid = '8006' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '80', mnuisortorder = 7, mnuiformname = 'FrmGlKmyeb' WHERE mnuiid = '8007' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '80', mnuisortorder = 8, mnuiformname = 'FrmGlKmkhYeb' WHERE mnuiid = '8008' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '80', mnuisortorder = 9, mnuiformname = 'FrmGlKmcsYeb' WHERE mnuiid = '8009' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '80', mnuisortorder = 10, mnuiformname = 'FrmGlZlfx' WHERE mnuiid = '8010' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '80', mnuisortorder = 11, mnuiformname = 'FrmGlZlfxHz' WHERE mnuiid = '8011' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '80', mnuisortorder = 12, mnuiformname = 'FrmGlZlfxHz2' WHERE mnuiid = '8012' AND mnuiown = 'RC3';

-- ============================================
-- 期末 (9001-9021) -> 父ID: 90
-- ============================================
UPDATE rc_menu SET mnuiparentid = '90', mnuisortorder = 1, mnuiformname = 'FrmKhXslbxx' WHERE mnuiid = '9001' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '90', mnuisortorder = 2, mnuiformname = 'FrmYwfDklxx' WHERE mnuiid = '9002' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '90', mnuisortorder = 3, mnuiformname = 'FrmYwfZyrw' WHERE mnuiid = '9003' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '90', mnuisortorder = 4, mnuiformname = 'FrmYwfDkgsxx' WHERE mnuiid = '9004' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '90', mnuisortorder = 5, mnuiformname = 'FrmYwfDkywSr' WHERE mnuiid = '9005' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '90', mnuisortorder = 6, mnuiformname = 'FrmYwfDkywCx' WHERE mnuiid = '9006' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '90', mnuisortorder = 7, mnuiformname = 'FrmYwfJs' WHERE mnuiid = '9007' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '90', mnuisortorder = 8, mnuiformname = 'FrmYwfCx' WHERE mnuiid = '9008' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '90', mnuisortorder = 9, mnuiformname = 'FrmYwfKhHz' WHERE mnuiid = '9009' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '90', mnuisortorder = 10, mnuiformname = 'FrmYwfZyHz' WHERE mnuiid = '9010' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '90', mnuisortorder = 11, mnuiformname = 'FrmYwfZyMx' WHERE mnuiid = '9011' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '90', mnuisortorder = 12, mnuiformname = 'FrmYwfZyzzHz' WHERE mnuiid = '9012' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '90', mnuisortorder = 13, mnuiformname = 'FrmYwfKhHzHz' WHERE mnuiid = '9013' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '90', mnuisortorder = 14, mnuiformname = 'FrmDjjz' WHERE mnuiid = '9014' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '90', mnuisortorder = 15, mnuiformname = 'FrmFcspJz' WHERE mnuiid = '9015' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '90', mnuisortorder = 16, mnuiformname = 'FrmJtchdjzb' WHERE mnuiid = '9016' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '90', mnuisortorder = 17, mnuiformname = 'FrmMrpJs' WHERE mnuiid = '9017' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '90', mnuisortorder = 18, mnuiformname = 'FrmPzsc' WHERE mnuiid = '9018' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '90', mnuisortorder = 19, mnuiformname = 'FrmPzcd' WHERE mnuiid = '9019' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '90', mnuisortorder = 20, mnuiformname = 'FrmYdjz' WHERE mnuiid = '9020' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '90', mnuisortorder = 21, mnuiformname = 'FrmNewYear' WHERE mnuiid = '9021' AND mnuiown = 'RC3';

COMMIT;