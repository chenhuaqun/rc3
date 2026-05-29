-- 动态菜单初始化数据脚本
-- 适用于 rc_menu 表，mnuiown = 'RC3'
-- 需要先执行 MenuMigration.sql

-- ============================================
-- 父级菜单（顶级菜单）
-- ============================================
DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '10';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) 
VALUES ('10','0','系统设置(&B)','MnuiBase','RC3',10,NULL);

DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '20';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) 
VALUES ('20','0','销售(&OE)','MnuiOe','RC3',20,NULL);

DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '30';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) 
VALUES ('30','0','生产(P&M)','MnuiPm','RC3',30,NULL);

DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '40';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) 
VALUES ('40','0','采购(&PO)','MnuiPo','RC3',40,NULL);

DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '50';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) 
VALUES ('50','0','库存(&INV)','MnuiInv','RC3',50,NULL);

DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '60';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) 
VALUES ('60','0','财务(&F)','MnuiArAp','RC3',60,NULL);

DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '70';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) 
VALUES ('70','0','成本(&CM)','MnuiCb','RC3',70,NULL);

DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '80';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) 
VALUES ('80','0','总账(&GL)','MnuiGl','RC3',80,NULL);

DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '90';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) 
VALUES ('90','0','期末(&T)','MnuiYwf','RC3',90,NULL);

DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '99';
INSERT INTO rc_menu (mnuiid,mnuiparentid,mnuicaption,mnuiname,mnuiown,mnuisortorder,mnuiformname) 
VALUES ('99','0','系统服务(&S)','MnuiSys','RC3',99,NULL);

-- ============================================
-- 基础数据子菜单（10xx）
-- ============================================
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 1, mnuiformname = 'FrmCplbxx' WHERE mnuiid = '1001' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 2, mnuiformname = 'FrmCpGroup' WHERE mnuiid = '1002' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 3, mnuiformname = 'FrmCpxx' WHERE mnuiid = '1003' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 4, mnuiformname = 'FrmBom' WHERE mnuiid = '1004' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 5, mnuiformname = 'FrmKhlbxx' WHERE mnuiid = '1005' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 6, mnuiformname = 'FrmKhxx' WHERE mnuiid = '1006' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 7, mnuiformname = 'FrmKhshdzxx' WHERE mnuiid = '1007' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 8, mnuiformname = 'FrmKhzyxx' WHERE mnuiid = '1008' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 9, mnuiformname = 'FrmCslbxx' WHERE mnuiid = '1009' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 10, mnuiformname = 'FrmCsxx' WHERE mnuiid = '1010' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 11, mnuiformname = 'FrmBmxx' WHERE mnuiid = '1011' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 12, mnuiformname = 'FrmZyxx' WHERE mnuiid = '1012' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 13, mnuiformname = 'FrmCkxx' WHERE mnuiid = '1013' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 14, mnuiformname = 'FrmCostRegionxx' WHERE mnuiid = '1014' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 15, mnuiformname = 'FrmJldwxx' WHERE mnuiid = '1015' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 16, mnuiformname = 'FrmGxxx' WHERE mnuiid = '1016' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 17, mnuiformname = 'FrmKmxx' WHERE mnuiid = '1017' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 18, mnuiformname = 'FrmJsfsxx' WHERE mnuiid = '1018' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 19, mnuiformname = 'FrmWbxx' WHERE mnuiid = '1019' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 20, mnuiformname = 'FrmKcZlxx' WHERE mnuiid = '1020' AND mnuiown = 'RC3';

-- ============================================
-- 期初数据子菜单
-- ============================================
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 21, mnuiformname = 'FrmQccpyeSr' WHERE mnuiid = '1021' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 22, mnuiformname = 'FrmQcfcspyeSr' WHERE mnuiid = '1022' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 23, mnuiformname = 'FrmQckhyeSr' WHERE mnuiid = '1023' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 24, mnuiformname = 'FrmQccsyeSr' WHERE mnuiid = '1024' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 25, mnuiformname = 'FrmQckmyeSr' WHERE mnuiid = '1025' AND mnuiown = 'RC3';

-- ============================================
-- 单据类型和会计期间
-- ============================================
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 26, mnuiformname = 'FrmPzlxxx' WHERE mnuiid = '1026' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '10', mnuisortorder = 27, mnuiformname = 'FrmKjqj' WHERE mnuiid = '1027' AND mnuiown = 'RC3';

-- ============================================
-- 权限管理
-- ============================================
UPDATE rc_menu SET mnuiparentid = '99', mnuisortorder = 1, mnuiformname = 'FrmRoles' WHERE mnuiid = '1028' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '99', mnuisortorder = 2, mnuiformname = 'FrmUsers' WHERE mnuiid = '1029' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '99', mnuisortorder = 3, mnuiformname = 'FrmOption' WHERE mnuiid = '1030' AND mnuiown = 'RC3';

COMMIT;