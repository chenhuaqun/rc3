-- 动态菜单数据库迁移脚本
-- 执行前请备份数据库

-- 1. 添加新字段
ALTER TABLE rc_menu ADD (mnuparentid VARCHAR2(4) DEFAULT '0');
ALTER TABLE rc_menu ADD (mnusortorder NUMBER(10) DEFAULT 0);
ALTER TABLE rc_menu ADD (mnuformname VARCHAR2(100));

-- 2. 更新父菜单（顶级菜单）
UPDATE rc_menu SET mnuparentid = '0', mnusortorder = 10 WHERE mnuiid = '10' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '0', mnusortorder = 20 WHERE mnuiid = '20' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '0', mnusortorder = 30 WHERE mnuiid = '30' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '0', mnusortorder = 40 WHERE mnuiid = '40' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '0', mnusortorder = 50 WHERE mnuiid = '50' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '0', mnusortorder = 60 WHERE mnuiid = '60' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '0', mnusortorder = 70 WHERE mnuiid = '70' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '0', mnusortorder = 80 WHERE mnuiid = '80' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '0', mnusortorder = 90 WHERE mnuiid = '90' AND mnuiown = 'RC3';
UPDATE rc_menu SET mnuparentid = '0', mnusortorder = 99 WHERE mnuiid = '99' AND mnuiown = 'RC3';

COMMIT;