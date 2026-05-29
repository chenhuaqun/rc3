-- 动态菜单数据库迁移脚本
-- 执行前请备份数据库

-- 1. 添加新字段
ALTER TABLE rc_menu ADD (mnuiparentid VARCHAR2(4) DEFAULT '0');
ALTER TABLE rc_menu ADD (mnuisortorder NUMBER(10) DEFAULT 0);
ALTER TABLE rc_menu ADD (mnuiformname VARCHAR2(100));

-- 2. 更新父菜单（顶级菜单）
UPDATE rc_menu SET mnuiparentid = '0', mnuisortorder = 10 WHERE mnuiid = '10' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '0', mnuisortorder = 20 WHERE mnuiid = '20' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '0', mnuisortorder = 30 WHERE mnuiid = '30' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '0', mnuisortorder = 40 WHERE mnuiid = '40' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '0', mnuisortorder = 50 WHERE mnuiid = '50' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '0', mnuisortorder = 60 WHERE mnuiid = '60' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '0', mnuisortorder = 70 WHERE mnuiid = '70' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '0', mnuisortorder = 80 WHERE mnuiid = '80' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '0', mnuisortorder = 90 WHERE mnuiid = '90' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuiparentid = '0', mnuisortorder = 99 WHERE mnuiid = '99' AND mnuiown = 'RC3';

COMMIT;