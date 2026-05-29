-- 动态菜单初始化数据脚本
-- 适用于 rc_menu 表，mnuiown = 'RC3'
-- 需要先执行 MenuMigration.sql

-- ============================================
-- 父级菜单（顶级菜单）
-- ============================================
DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '10';
INSERT INTO rc_menu (mnuiid,mnuparentid,mnucaption,mnuiname,mnuiown,mnusortorder,mnuformname) 
VALUES ('10','0','系统设置(&B)','MnuiBase','RC3',10,NULL);

DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '20';
INSERT INTO rc_menu (mnuiid,mnuparentid,mnucaption,mnuiname,mnuiown,mnusortorder,mnuformname) 
VALUES ('20','0','销售(&OE)','MnuiOe','RC3',20,NULL);

DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '30';
INSERT INTO rc_menu (mnuiid,mnuparentid,mnucaption,mnuiname,mnuiown,mnusortorder,mnuformname) 
VALUES ('30','0','生产(P&M)','MnuiPm','RC3',30,NULL);

DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '40';
INSERT INTO rc_menu (mnuiid,mnuparentid,mnucaption,mnuiname,mnuiown,mnusortorder,mnuformname) 
VALUES ('40','0','采购(&PO)','MnuiPo','RC3',40,NULL);

DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '50';
INSERT INTO rc_menu (mnuiid,mnuparentid,mnucaption,mnuiname,mnuiown,mnusortorder,mnuformname) 
VALUES ('50','0','库存(&INV)','MnuiInv','RC3',50,NULL);

DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '60';
INSERT INTO rc_menu (mnuiid,mnuparentid,mnucaption,mnuiname,mnuiown,mnusortorder,mnuformname) 
VALUES ('60','0','财务(&F)','MnuiArAp','RC3',60,NULL);

DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '70';
INSERT INTO rc_menu (mnuiid,mnuparentid,mnucaption,mnuiname,mnuiown,mnusortorder,mnuformname) 
VALUES ('70','0','成本(&CM)','MnuiCb','RC3',70,NULL);

DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '80';
INSERT INTO rc_menu (mnuiid,mnuparentid,mnucaption,mnuiname,mnuiown,mnusortorder,mnuformname) 
VALUES ('80','0','总账(&GL)','MnuiGl','RC3',80,NULL);

DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '90';
INSERT INTO rc_menu (mnuiid,mnuparentid,mnucaption,mnuiname,mnuiown,mnusortorder,mnuformname) 
VALUES ('90','0','期末(&T)','MnuiYwf','RC3',90,NULL);

DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '99';
INSERT INTO rc_menu (mnuiid,mnuparentid,mnucaption,mnuiname,mnuiown,mnusortorder,mnuformname) 
VALUES ('99','0','系统服务(&S)','MnuiSys','RC3',99,NULL);

-- ============================================
-- 基础数据子菜单（10xx）
-- ============================================
UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 1, mnuformname = 'FrmCplbxx' WHERE mnuiid = '1001' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 2, mnuformname = 'FrmCpGroup' WHERE mnuiid = '1002' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 3, mnuformname = 'FrmCpxx' WHERE mnuiid = '1003' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 4, mnuformname = 'FrmBom' WHERE mnuiid = '1004' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 5, mnuformname = 'FrmKhlbxx' WHERE mnuiid = '1005' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 6, mnuformname = 'FrmKhxx' WHERE mnuiid = '1006' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 7, mnuformname = 'FrmKhshdzxx' WHERE mnuiid = '1007' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 8, mnuformname = 'FrmKhzyxx' WHERE mnuiid = '1008' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 9, mnuformname = 'FrmCslbxx' WHERE mnuiid = '1009' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 10, mnuformname = 'FrmCsxx' WHERE mnuiid = '1010' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 11, mnuformname = 'FrmBmxx' WHERE mnuiid = '1011' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 12, mnuformname = 'FrmZyxx' WHERE mnuiid = '1012' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 13, mnuformname = 'FrmCkxx' WHERE mnuiid = '1013' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 14, mnuformname = 'FrmCostRegionxx' WHERE mnuiid = '1014' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 15, mnuformname = 'FrmJldwxx' WHERE mnuiid = '1015' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 16, mnuformname = 'FrmGxxx' WHERE mnuiid = '1016' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 17, mnuformname = 'FrmKmxx' WHERE mnuiid = '1017' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 18, mnuformname = 'FrmJsfsxx' WHERE mnuiid = '1018' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 19, mnuformname = 'FrmWbxx' WHERE mnuiid = '1019' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 20, mnuformname = 'FrmKcZlxx' WHERE mnuiid = '1020' AND mnuiown = 'RC3';

-- ============================================
-- 期初数据子菜单
-- ============================================
UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 21, mnuformname = 'FrmQccpyeSr' WHERE mnuiid = '1021' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 22, mnuformname = 'FrmQcfcspyeSr' WHERE mnuiid = '1022' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 23, mnuformname = 'FrmQckhyeSr' WHERE mnuiid = '1023' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 24, mnuformname = 'FrmQccsyeSr' WHERE mnuiid = '1024' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 25, mnuformname = 'FrmQckmyeSr' WHERE mnuiid = '1025' AND mnuiown = 'RC3';

-- ============================================
-- 单据类型和会计期间
-- ============================================
UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 26, mnuformname = 'FrmPzlxxx' WHERE mnuiid = '1026' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 27, mnuformname = 'FrmKjqj' WHERE mnuiid = '1027' AND mnuiown = 'RC3';

-- ============================================
-- 权限管理
-- ============================================
UPDATE rc_menu SET mnuparentid = '99', mnusortorder = 1, mnuformname = 'FrmRoles' WHERE mnuiid = '1028' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '99', mnusortorder = 2, mnuformname = 'FrmUsers' WHERE mnuiid = '1029' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '99', mnusortorder = 3, mnuformname = 'FrmOption' WHERE mnuiid = '1030' AND mnuiown = 'RC3';

COMMIT;