Imports System.Data.OleDb

Public Class FrmCheckData
    '建立OLEDB数据适配器对象
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立OleDb传递对象
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDb命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        '数据库结构
        '********************'
        '******rcsystem******'
        '*****rc_DicTable********'
        '********************'
        Try
            sysOleDbConn.Open()
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'RC_DICTABLE'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            rcDataset.Tables("user_tables")?.Clear()
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE rc_dictable (PK_DicTable varchar2(32) default SYS_GUID(),Own varchar2(10),TableName varchar2(200),FieldName varchar2(100),FieldType varchar2(100),IsPrimaryKey number(1,0),DefaultValue varchar2(500),AllowNull number(1,0),Description varchar2(500),SortIndex number(4,0))"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE rc_dictable ADD CONSTRAINT PK_DicTable primary key (PK_DicTable)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            sysOleDbConn.Close()
        End Try
        '********************'
        '******rcsystem******'
        ''*****rc_menu*******'
        '********************'
        Try
            sysOleDbConn.Open()
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'RC_MENU'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE rc_menu (mnuiid VARCHAR2(4),mnuicaption VARCHAR2(50),mnuiname VARCHAR2(30),mnuiown VARCHAR2(4))"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE rc_menu ADD CONSTRAINT PK_RC_MENU primary key (mnuiown,mnuiid)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'MNUIID' AND table_name ='RC_MENU'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_menu ADD mnuiid VARCHAR2(4)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'MNUICAPTION' AND table_name ='RC_MENU'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_menu ADD mnuicaption VARCHAR2(50)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'MNUINAME' AND table_name ='RC_MENU'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_menu ADD mnuiname VARCHAR2(30)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'MNUIOWN' AND table_name ='RC_MENU'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_menu ADD mnuiown VARCHAR2(4)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '添加数据
                '1030
                '1001
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='1001'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('1001','物料类别信息设置','MnuiCplbxx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '1002
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='1002'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('1002','物料组设置','MnuiCpGroup','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '1003
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='1003'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('1003','物料信息设置','MnuiCpxx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '1004
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='1004'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('1004','物料清单设置','MnuiBom','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '1005
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='1005'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('1005','客户分类信息设置','MnuiKhlbxx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '1006
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='1006'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('1006','客户信息设置','MnuiKhxx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '1007
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='1007'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('1007','客户收货地址管理','MnuiKhshdz','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '1008
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='1008'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('1008','客户专管业务员设置','MnuiKhzyxx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '1009
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='1009'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('1009','供应商分类信息设置','MnuiCslbxx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '1010
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='1010'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('1010','供应商信息设置','MnuiCsxx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '1011
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='1011'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('1011','部门编码设置','MnuiBmxx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '1012
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='1012'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('1012','职员信息设置','MnuiZyxx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '1013
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='1013'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('1013','仓库编码设置','MnuiCkxx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '1014
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='1014'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('1014','成本域设置','MnuiCostRegion','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '1015
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='1015'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('1015','计量单位设置','MnuiJldwxx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '1016
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='1016'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('1016','生产工序信息设置','MnuiGxxx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '1017
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='1017'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('1017','科目信息设置','MnuiKmxx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '1018
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='1018'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('1018','结算方式信息设置','MnuiJsfsxx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '1019
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='1019'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('1019','币种信息设置','MnuiWbxx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '1020
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='1020'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('1020','库存账龄设置','MnuiKcZlxx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '1021
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='1021'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('1021','期初产品库存余额装入','MnuiQccpyeSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '1022
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='1022'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('1022','期初发出商品余额装入','MnuiQcfcspyeSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '1023
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='1023'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('1023','期初客户应收明细装入','MnuiQckhyeSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '1024
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='1024'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('1024','期初供应商应付明细装入','MnuiQccsyeSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '1025
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='1025'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('1025','期初总账余额装入','MnuiQckmyeSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '1026
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='1026'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('1026','单据类型信息设置','MnuiPzlxxx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '1027
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='1027'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('1027','会计期间设置','MnuiKjqj','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '1028
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='1028'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('1028','角色和角色操作权限设置','MnuiRoles','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '1029
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='1029'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('1029','操作员和操作员角色设置','MnuiUsers','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '1030
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='1030'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('1030','选项','MnuiOption','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2001
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2001'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2001','样品订单录入与修改','MnuiOeYpddSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2002
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2002'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2002','样品生产厂输入','MnuiOeYpddBmSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2003
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2003'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2003','样品生产交期输入','MnuiOeYpddJqSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2004
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2004'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2004','样品订单审核','MnuiOeYpddSh','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2005
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2005'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2005','样品寄样日期输入','MnuiOeYpFhrqSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2006
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2006'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2006','样品寄样单号输入','MnuiOeYpFhdhSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2007
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2007'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2007','样品客户反馈','MnuiOeYpddHx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2008
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2008'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2008','样品订单查询','MnuiOeYpddCx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2009
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2009'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2009','样品订单发货登记表','MnuiOeYpddDjb','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2010
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2010'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2010','产品报价单输入与修改','MnuiOeBjdSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2011
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2011'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2011','产品报价单审核','MnuiOeBjdSh','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2012
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2012'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2012','产品报价单查询','MnuiOeBjdCx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2013
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2013'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2013','产品销售订单录入与修改','MnuiOeDdSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2014
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2014'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2014','产品销售订单单价审核','MnuiOeDddjSh','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2015
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2015'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2015','产品销售订单关闭','MnuiOeDdClose','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2016
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2016'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2016','产品销售订单派工','MnuiOeDdJqSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2017
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2017'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2017','产品销售订单审核','MnuiOeDdSh','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2018
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2018'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2018','产品入库单录入与修改','MnuiOeRkdSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2019
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2019'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2019','产品入库单审核','MnuiOeRkdSh','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2020
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2020'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2020','产品发货通知书输入与修改','MnuiOeFhdSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2021
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2021'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2021','产品发货通知书审核','MnuiOeFhdSh','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2022
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2022'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2022','产品送货单录入与修改','MnuiOeXsdSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2023
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2023'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2023','产品送货单审核','MnuiOeXsdSh','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2024
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2024'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2024','产品送货单核销','MnuiOeXsdHx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2025
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2025'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2025','产品销售发票输入与修改','MnuiOeFpSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2026
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2026'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2026','产品销售发票审核','MnuiOeFpSh','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2027
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2027'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2027','产品销售订单查询','MnuiOeDdCx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2028
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2028'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2028','产品入库单查询','MnuiOeRkdCx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2029
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2029'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2029','产品发货通知书查询','MnuiOeFhdCx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2030
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2030'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2030','产品送货单查询','MnuiOeXsdCx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2031
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2031'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2031','产品销售发票查询','MnuiOeFpCx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2032
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2032'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2032','产品入库产值汇总表','MnuiOeRkCpHzb','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2033
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2033'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2033','产品入库产值部门汇总表','MnuiOeRkBmHzb','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2034
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2034'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2034','产品销售日报','MnuiOeXsrb','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2035
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2035'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2035','物料类别送货汇总表','MnuiOeCplbHzb','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2036
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2036'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2036','部门送货汇总表','MnuiOeBmHzb','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2037
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2037'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2037','产品送货汇总表','MnuiOeCpHzb','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2038
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2038'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2038','产品送货仓库汇总表','MnuiOeCkCpHzb','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2039
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2039'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2039','客户送货汇总表','MnuiOeKhHzb','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '2040
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='2040'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('2040','职员送货汇总表','MnuiOeZyHzb','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '3001
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='3001'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('3001','生产订单输入与修改','MnuiPmDdSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '3002
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='3002'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('3002','生产订单关闭','MnuiPmDdClose','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '3003
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='3003'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('3003','生成工序流转卡','MnuiPmScGxlzk','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '3004
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='3004'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('3004','工序派工单','MnuiPmDdGxPg','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '3005
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='3005'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('3005','工序汇报单','MnuiPmDdGxHb','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '3006
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='3006'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('3006','工序领料单输入与修改','MnuiPmCkdSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '3007
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='3007'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('3007','工序领料单审核','MnuiPmCkdSh','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '3008
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='3008'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('3008','工序入库单输入与修改','MnuiPmRkdSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '3009
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='3009'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('3009','工序入库单审核','MnuiPmRkdSh','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '3010
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='3010'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('3010','工序领料单查询','MnuiPmCkdCx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '3011
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='3011'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('3011','工序入库单查询','MnuiPmRkdCx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '3012
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='3012'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('3012','订单生产跟踪查询','MnuiPmDdGxlzCx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '3013
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='3013'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('3013','各部门工序入库物料汇总表','MnuiPmRkCpHzb','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '3014
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='3014'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('3014','部门入库汇总表','MnuiPmBmRkHzb','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4001
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4001'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4001','物料采购/维修需求单录入与修改','MnuiPoCgjhSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4002
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4002'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4002','物料采购/维修需求单审核','MnuiPoCgjhSh','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4003
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4003'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4003','物料采购/维修需求单关闭','MnuiPoCgjhClose','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4004
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4004'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4004','供应商物料采购价格目录维护','MnuiCsCpCgdjSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4005
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4005'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4005','供应商物料采购价格目录审核','MnuiCsCpCgdjSh','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4006
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4006'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4006','物料采购订单录入与修改','MnuiPoCgdSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4007
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4007'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4007','物料采购订单审核','MnuiPoCgdSh','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4008
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4008'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4008','物料采购订单关闭','MnuiPoCgdClose','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4009
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4009'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4009','物料入库单输入与修改','MnuiPoRkdSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4011
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4011'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4011','物料入库单审核','MnuiPoRkdSh','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4012
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4012'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4012','采购发票输入与修改','MnuiPoFpSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4013
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4013'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4013','采购发票审核','MnuiPoFpSh','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4014
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4014'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4014','物料领用申请单输入与修改','MnuiPoLlsqSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4015
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4015'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4015','物料领用申请单审核','MnuiPoLlsqSh','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4016
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4016'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4016','物料领用申请单关闭','MnuiPoLlsqClose','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4010
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4010'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4010','物料回收与取消回收','MnuiInvRecycleSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4017
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4017'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4017','物料出库单输入与修改','MnuiPoCkdSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4018
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4018'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4018','物料领用发货','MnuiPoCkdSr2','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4019
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4019'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4019','物料出库单审核','MnuiPoCkdSh','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4020
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4020'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4020','物料调拨单输入与修改','MnuiInvDbdSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4021
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4021'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4021','物料调拨单审核','MnuiInvDbdSh','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4022
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4022'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4022','物料采购/维修需求单查询','MnuiPoCgjhCx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4023
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4023'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4023','供应商物料采购价格目录查询','MnuiCsCpCgdjCx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4024
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4024'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4024','物料采购订单查询','MnuiPoCgdCx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4025
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4025'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4025','物料入库单查询','MnuiPoRkdCx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4026
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4026'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4026','采购发票查询','MnuiPoFpCx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4027
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4027'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4027','物料领用申请单查询','MnuiPoLlsqCx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4028
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4028'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4028','物料出库单查询','MnuiPoCkdCx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4029
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4029'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4029','物料调拨单查询','MnuiInvDbdCx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4030
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4030'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4030','供应商采购汇总表','MnuiPoCsHzb','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4031
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4031'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4031','部门领用汇总表','MnuiPoBmHzb','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4032
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4032'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4032','部门设备物料类别消耗汇总表','MnuiPoBmFaLbHzb','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4033
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4033'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4033','仓库领用物料汇总表','MnuiCkCkCpHzb','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '4034
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='4034'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('4034','仓库调拨物料汇总表','MnuiCkDbCpHzb','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '5001
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='5001'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('5001','物料调整单输入与修改','MnuiInvCktzSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '5002
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='5002'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('5002','物料盘存表输入与修改','MnuiInvPcSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '5003
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='5003'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('5003','物料盘存表审核','MnuiInvPcSh','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '5004
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='5004'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('5004','仓库收发存明细账','MnuiSlSfcMx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '5005
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='5005'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('5005','仓库收发存汇总表','MnuiSlSfcHz','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '5006
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='5006'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('5006','物料盘存表','MnuiCpPcb','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '5007
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='5007'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('5007','物料收发存明细账','MnuiCpSfcMx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '5008
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='5008'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('5008','物料收发存汇总表','MnuiCpSfcHz','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '5009
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='5009'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('5009','物料各仓库资金收发存汇总表','MnuiJeSfcHz','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '5010
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='5010'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('5010','物料批次收发存明细帐','MnuiPhSfcMx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '5011
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='5011'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('5011','物料批次收发存汇总表','MnuiPhSfcHz','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '5012
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='5012'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('5012','物料类别收发存汇总表','MnuiCplbSfcHz','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '5013
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='5013'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('5013','物料库存账龄分析表','MnuiCpkcZlfx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '5014
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='5014'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('5014','发出商品盘存表','MnuiFcspPcb','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '5015
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='5015'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('5015','发出商品收发存明细账','MnuiFcspSfcMx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '5016
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='5016'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('5016','发出商品收发存汇总表','MnuiFcspSfcHz','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '6023
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='6023'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('6023','付款申请单录入与修改','MnuiApFksqSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '6024
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='6024'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('6024','付款申请单审核','MnuiApFksqSh','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '6025
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='6025'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('6025','付款申请单查询','MnuiApFksqCx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '7001
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='7001'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('7001','期末在产材料数量录入','MnuiZcclslSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '7002
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='7002'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('7002','期末在产品数量录入','MnuiZcpslSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '7003
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='7003'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('7003','本期投入总成本录入','MnuiZcbJeSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '7004
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='7004'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('7004','材料出库成本结转','MnuiCbjz_Cl','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '7005
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='7005'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('7005','生产成本分配','MnuiCbjz_Sccb','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '7006
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='7006'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('7006','产品出库成本结转','MnuiCbjz_Xscb','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '7007
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='7007'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('7007','发出商品成本结转','MnuiCbjz_Fcsp','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '7008
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='7008'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('7008','在产材料成本明细表','MnuiZcclMx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '7009
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='7009'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('7009','在产品成本明细表','MnuiZcpMx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '7010
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='7010'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('7010','在产品部门工序汇总表','MnuiZcpBmGxHz','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '7011
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='7011'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('7011','产成品在产品成本汇总表','MnuiCcpZcpHz','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '7012
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='7012'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('7012','产成品在产品各部门成本汇总表','MnuiCcpZcpBmHz','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '7013
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='7013'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('7013','物料清单查询','MnuiBomCx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '8001
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='8001'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('8001','凭证输入与修改','MnuiGlPzSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '8002
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='8002'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('8002','凭证审核','MnuiGlPzSh','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '8003
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='8003'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('8003','凭证记账','MnuiGlPzJz','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '8004
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='8004'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('8004','凭证查询','MnuiGlPzCx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '8005
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='8005'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('8005','科目日记账','MnuiGlKmRjz','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '8006
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='8006'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('8006','科目明细账','MnuiGlKmMxz','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '8007
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='8007'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('8007','科目余额汇总表','MnuiGlKmyeb','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '8008
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='8008'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('8008','科目客户余额汇总表','MnuiGlKmkhYeb','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '8009
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='8009'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('8009','科目供应商余额汇总表','MnuiGlKmcsYeb','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '8010
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='8010'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('8010','账龄分析表','MnuiGlZlfx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '8011
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='8011'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('8011','汇总账龄分析表','MnuiGlZlfxHz','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '9001
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='9001'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('9001','客户销售分类信息设置','MnuiKhXslb','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '9002
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='9002'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('9002','逾期收款倒扣比例设置','MnuiYwfDkl','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '9003
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='9003'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('9003','业务员任务数设置','MnuiYwfZyrw','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '9003
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='9004'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('9004','业务费抵扣规则定义','MnuiYwfDkgsxx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '9004
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='9005'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('9005','业务费抵扣业务输入与修改','MnuiYwfDkywSr','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '9005
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='9006'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('9006','业务费抵扣业务查询','MnuiYwfDkywCx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '9006
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='9007'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('9007','业务费计算','MnuiYwfJs','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '9007
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='9008'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('9008','业务费计算明细查询','MnuiYwfCx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '9008
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='9009'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('9009','业务费客户汇总表','MnuiYwfKhHz','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '9009
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='9010'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('9010','业务费业务员汇总表','MnuiYwfZyHz','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '9011
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='9011'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('9011','业务费业务员计算明细表','MnuiYwfZyMx','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '9012
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='9012'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('9012','业务费业务员增长汇总表','MnuiYwfZyzzHz','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '9013
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='9013'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('9013','汇总业务费客户汇总表','MnuiYwfKhHzHz','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '9014
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='9014'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('9014','单据记账','MnuiDjjz','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '9015
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='9015'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('9015','发出商品处理','MnuiFcspJz','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '9016
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='9016'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('9016','计提存货跌价准备','MnuiJtchdjzb','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '9017
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='9017'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('9017','MRP运算','MnuiMrpJs','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '9018
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='9018'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('9018','凭证生成','MnuiPzsc','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '9019
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='9019'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('9019','凭证传递','MnuiPzcd','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '9020
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='9020'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('9020','期末结账','MnuiYdjz','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '9021
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='9021'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('9021','建立新年度账','MnuiNewYear','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'A001
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='A001'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('A001','修改密码','MnuiModPwd','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'A002
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='A002'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('A002','重新注册','MnuiZtdl','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'A003
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='A003'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('A003','在线升级','MnuiUpdate','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'A004
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='A004'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('A004','上传文件','MnuiUploadFile','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'A005
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='A005'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('A005','升级RC3数据','MnuiUpdateDB','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'A006
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='A006'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('A006','导入用友NC数据','MnuiImpNC','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'A007
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='A007'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('A007','物料编码更改与合并','MnuiCpdmGg','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'A008
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='A008'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('A008','客户编码更改与合并','MnuiKhdmGg','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'A009
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='A009'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('A009','供应商编码更改与合并','MnuiCsdmGg','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'A010
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='A010'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('A010','职员编码更改与合并','MnuiZydmGg','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'A011
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='A011'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('A011','重新汇总物料总账','MnuiRedoCpyeHz','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'A012
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='A012'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('A012','重新汇总物料总账','MnuiRedoFcspyeHz','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'A013
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='A013'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('A013','物料数据修复','MnuiCpRepair','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'A014
                rcOleDbCommand.CommandText = "DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid ='A014'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "INSERT INTO rc_menu (mnuiid,mnuicaption,mnuiname,mnuiown) VALUES ('A014','检测数据','MnuiCheckData','RC3')"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            sysOleDbConn.Close()
        End Try
        '********************'
        '******rcsystem******'
        '*****rc_para********'
        '********************'
        Try
            sysOleDbConn.Open()
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'RC_PARA'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE rc_para (paraid VARCHAR2(75),parastrvalue VARCHAR2(50),paradblvalue NUMBER(18,6))"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE rc_para ADD CONSTRAINT PK_RC_PARA primary key (dwdm,paraid)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'PARAID' AND table_name ='RC_PARA'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_para ADD paraid VARCHAR2(75)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_para MODIFY paraid VARCHAR2(75)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'PARASTRVALUE' AND table_name ='RC_PARA'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_para ADD parastrvalue VARCHAR2(50)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_para MODIFY parastrvalue VARCHAR2(50)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            sysOleDbConn.Close()
        End Try

        '********************'
        '******rcsystem******'
        '******rc_users******'
        '********************'
        Try
            sysOleDbConn.Open()
            rcOleDbCommand.Connection = sysOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'RC_USERS'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE rc_users (user_account VARCHAR2(30),user_pwd VARCHAR2(50))"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE rc_users ADD CONSTRAINT PK_RC_USERS primary key (user_account)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'USER_PWD' AND table_name ='RC_USERS'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_users ADD user_pwd VARCHAR2(50)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_users MODIFY user_pwd VARCHAR2(50)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            sysOleDbConn.Close()
        End Try
        '********************'
        '******rcsystem******'
        ''*****rc_yj*********'
        '********************'

        '********************'
        '*****rcdata_001*****'
        ''****ar_skd*********'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'AR_SKD'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE ar_skd (khdm VARCHAR2(15) NOT NULL,khmc VARCHAR2(200),jsfsdm VARCHAR2(12),jsfsmc VARCHAR2(30),yspz VARCHAR2(30),skmemo VARCHAR2(100))" '待完善
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE ar_skd ADD CONSTRAINT PK_AR_SKD primary key (djh)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'KHDM' AND table_name ='AR_SKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE ar_skd ADD khdm VARCHAR2(15) NOT NULL"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE ar_skd MODIFY khdm VARCHAR2(15)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'KHMC' AND table_name ='AR_SKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE ar_skd ADD khmc VARCHAR2(200)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE ar_skd MODIFY khmc VARCHAR2(200)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'JSFSDM' AND table_name ='AR_SKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE ar_skd ADD jsfsdm VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'JSFSMC' AND table_name ='AR_SKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE ar_skd ADD jsfsmc VARCHAR2(30)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'YSPZ' AND table_name ='AR_SKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE ar_skd ADD yspz VARCHAR2(30)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE ar_skd MODIFY yspz VARCHAR2(30)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'SKMEMO' AND table_name ='AR_SKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE ar_skd ADD skmemo VARCHAR2(100)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE ar_skd MODIFY skmemo VARCHAR2(100)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        ''****dzb_na********'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'DZB_NC'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE dzb_nc (leibie VARCHAR2(4) NOT NULL,nc VARCHAR2(15) NOT NULL,rc VARCHAR2(15) NOT NULL)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE dzb_nc ADD CONSTRAINT PK_DZB_NC primary key (leibie,nc)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        ''****gl_kmxx********'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'GL_KMXX'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE gl_kmxx (kmdm VARCHAR2(15) NOT NULL,kmmc VARCHAR2(100),kmzy NUMBER(1,0) DEFAULT 0)" '待完善
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE gl_kmxx ADD CONSTRAINT PK_GL_KMXX primary key (KMDM)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'KMDM' AND table_name ='GL_KMXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_kmxx ADD kmdm VARCHAR2(15)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_kmxx MODIFY kmdm VARCHAR2(15)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'KMMC' AND table_name ='GL_KMXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_kmxx ADD kmmc VARCHAR2(100)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_kmxx MODIFY kmmc VARCHAR2(100)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'KMZY' AND table_name ='GL_KMXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_kmxx ADD kmzy NUMBER(1,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_kmxx MODIFY kmzy NUMBER(1,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try

        '********************'
        '*****rcdata_001*****'
        ''****gl_kmyeb*******'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'GL_KMYEB'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE gl_kmyeb (jd VARCHAR2(3), wbdm VARCHAR2(4),bmdm VARCHAR2(12),zydm VARCHAR2(12),xmdm VARCHAR2(12),khdm VARCHAR2(15),csdm VARCHAR2(12),yhzh VARCHAR2(12),jxzh VARCHAR2(12))" '待完善
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE gl_kmyeb ADD CONSTRAINT PK_GL_KMYEB primary key (KJND, KMDM, WBDM, BMDM, ZYDM, XMDM, KHDM, CSDM, YHZH, JXZH)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'JD' AND table_name ='GL_KMYEB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_kmyeb ADD jd VARCHAR2(3) DEFAULT '~'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_kmyeb MODIFY jd VARCHAR2(3) DEFAULT '~'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'WBDM' AND table_name ='GL_KMYEB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_kmyeb ADD wbdm VARCHAR2(4) DEFAULT '~'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_kmyeb MODIFY wbdm VARCHAR2(4) DEFAULT '~'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'BMDM' AND table_name ='GL_KMYEB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_kmyeb ADD bmdm VARCHAR2(12) DEFAULT '~'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_kmyeb MODIFY bmdm VARCHAR2(12) DEFAULT '~'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'ZYDM' AND table_name ='GL_KMYEB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_kmyeb ADD zydm VARCHAR2(12) DEFAULT '~'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_kmyeb MODIFY zydm VARCHAR2(12) DEFAULT '~'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'XMDM' AND table_name ='GL_KMYEB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_kmyeb ADD xmdm VARCHAR2(12) DEFAULT '~'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_kmyeb MODIFY xmdm VARCHAR2(12) DEFAULT '~'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'KHDM' AND table_name ='GL_KMYEB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_kmyeb ADD khdm VARCHAR2(15) DEFAULT '~'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_kmyeb MODIFY khdm VARCHAR2(15) DEFAULT '~'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CSDM' AND table_name ='GL_KMYEB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_kmyeb ADD csdm VARCHAR2(12) DEFAULT '~'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_kmyeb MODIFY csdm VARCHAR2(12) DEFAULT '~'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'YHZH' AND table_name ='GL_KMYEB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_kmyeb ADD yhzh VARCHAR2(12) DEFAULT '~'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_kmyeb MODIFY yhzh VARCHAR2(12) DEFAULT '~'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'JXZH' AND table_name ='GL_KMYEB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_kmyeb ADD jxzh VARCHAR2(12) DEFAULT '~'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_kmyeb MODIFY jxzh VARCHAR2(12) DEFAULT '~'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '重建索引
                Dim i As Integer
                rcOleDbCommand.CommandText = "SELECT * FROM user_constraints WHERE table_name ='GL_KMYEB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_constraints") IsNot Nothing Then
                    rcDataset.Tables("user_constraints").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_constraints")
                'Dim i As Integer
                For i = 0 To rcDataset.Tables("user_constraints").Rows.Count - 1
                    rcOleDbCommand.CommandText = "alter table GL_KMYEB drop constraint " & rcDataset.Tables("user_constraints").Rows(i).Item("constraint_name") & " cascade"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Next
                rcOleDbCommand.CommandText = "SELECT * FROM user_indexes WHERE table_name ='GL_KMYEB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_indexes") IsNot Nothing Then
                    rcDataset.Tables("user_indexes").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_indexes")
                For i = 0 To rcDataset.Tables("user_indexes").Rows.Count - 1
                    rcOleDbCommand.CommandText = "drop index " & rcDataset.Tables("user_indexes").Rows(i).Item("index_name")
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Next
                rcOleDbCommand.CommandText = "ALTER TABLE gl_kmyeb ADD CONSTRAINT PK_GL_KMYEB primary key (KJND, KMDM ,WBDM , BMDM, ZYDM, XMDM, KHDM, CSDM, YHZH, JXZH)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'kjnd
                rcOleDbCommand.CommandText = "SELECT * FROM user_ind_columns WHERE index_name = 'IDX_GL_KMYEB_KJND' AND table_name ='GL_KMYEB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_ind_columns") IsNot Nothing Then
                    rcDataset.Tables("user_ind_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_ind_columns")
                If rcDataset.Tables("user_ind_columns").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "drop index IDX_GL_KMYEB_KJND"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "create index IDX_GL_KMYEB_KJND on GL_KMYEB (kjnd)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'kmdm
                rcOleDbCommand.CommandText = "SELECT * FROM user_ind_columns WHERE index_name = 'IDX_GL_KMYEB_KMDM' AND table_name ='GL_KMYEB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_ind_columns") IsNot Nothing Then
                    rcDataset.Tables("user_ind_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_ind_columns")
                If rcDataset.Tables("user_ind_columns").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "drop index IDX_GL_KMYEB_KMDM"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "create index IDX_GL_KMYEB_KMDM on GL_KMYEB (kmdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'wbdm
                rcOleDbCommand.CommandText = "SELECT * FROM user_ind_columns WHERE index_name = 'IDX_GL_KMYEB_WBDM' AND table_name ='GL_KMYEB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_ind_columns") IsNot Nothing Then
                    rcDataset.Tables("user_ind_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_ind_columns")
                If rcDataset.Tables("user_ind_columns").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "drop index IDX_GL_KMYEB_WBDM"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "create index IDX_GL_KMYEB_WBDM on GL_KMYEB (wbdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'bmdm
                rcOleDbCommand.CommandText = "SELECT * FROM user_ind_columns WHERE index_name = 'IDX_GL_KMYEB_BMDM' AND table_name ='GL_KMYEB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_ind_columns") IsNot Nothing Then
                    rcDataset.Tables("user_ind_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_ind_columns")
                If rcDataset.Tables("user_ind_columns").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "drop index IDX_GL_KMYEB_BMDM"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "create index IDX_GL_KMYEB_BMDM on GL_KMYEB (bmdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'zydm
                rcOleDbCommand.CommandText = "SELECT * FROM user_ind_columns WHERE index_name = 'IDX_GL_KMYEB_ZYDM' AND table_name ='GL_KMYEB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_ind_columns") IsNot Nothing Then
                    rcDataset.Tables("user_ind_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_ind_columns")
                If rcDataset.Tables("user_ind_columns").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "drop index IDX_GL_KMYEB_ZYDM"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "create index IDX_GL_KMYEB_ZYDM on GL_KMYEB (zydm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'xmdm
                rcOleDbCommand.CommandText = "SELECT * FROM user_ind_columns WHERE index_name = 'IDX_GL_KMYEB_XMDM' AND table_name ='GL_KMYEB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_ind_columns") IsNot Nothing Then
                    rcDataset.Tables("user_ind_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_ind_columns")
                If rcDataset.Tables("user_ind_columns").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "drop index IDX_GL_KMYEB_XMDM"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "create index IDX_GL_KMYEB_XMDM on GL_KMYEB (xmdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'khdm
                rcOleDbCommand.CommandText = "SELECT * FROM user_ind_columns WHERE index_name = 'IDX_GL_KMYEB_KHDM' AND table_name ='GL_KMYEB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_ind_columns") IsNot Nothing Then
                    rcDataset.Tables("user_ind_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_ind_columns")
                If rcDataset.Tables("user_ind_columns").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "drop index IDX_GL_KMYEB_KHDM"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "create index IDX_GL_KMYEB_KHDM on GL_KMYEB (khdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'csdm
                rcOleDbCommand.CommandText = "SELECT * FROM user_ind_columns WHERE index_name = 'IDX_GL_KMYEB_CSDM' AND table_name ='GL_KMYEB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_ind_columns") IsNot Nothing Then
                    rcDataset.Tables("user_ind_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_ind_columns")
                If rcDataset.Tables("user_ind_columns").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "drop index IDX_GL_KMYEB_CSDM"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "create index IDX_GL_KMYEB_CSDM on GL_KMYEB (csdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'yhzh
                rcOleDbCommand.CommandText = "SELECT * FROM user_ind_columns WHERE index_name = 'IDX_GL_KMYEB_YHZH' AND table_name ='GL_KMYEB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_ind_columns") IsNot Nothing Then
                    rcDataset.Tables("user_ind_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_ind_columns")
                If rcDataset.Tables("user_ind_columns").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "drop index IDX_GL_KMYEB_YHZH"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "create index IDX_GL_KMYEB_YHZH on GL_KMYEB (yhzh)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'jxzh
                rcOleDbCommand.CommandText = "SELECT * FROM user_ind_columns WHERE index_name = 'IDX_GL_KMYEB_JXZH' AND table_name ='GL_KMYEB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_ind_columns") IsNot Nothing Then
                    rcDataset.Tables("user_ind_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_ind_columns")
                If rcDataset.Tables("user_ind_columns").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "drop index IDX_GL_KMYEB_JXZH"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "create index IDX_GL_KMYEB_JXZH on GL_KMYEB (jxzh)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        ''****gl_pz*********'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'GL_PZ'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "create table GL_PZ (
  djh     VARCHAR2(15) not null,
  xh      NUMBER(4) not null,
  bdelete NUMBER(1),
  cperiod CHAR(6),
  pzlxdm  VARCHAR2(4),
  pzh     NUMBER(5),
  pzrq    DATE,
  fjzs    NUMBER(4),
  jd      VARCHAR2(3),
  zy      VARCHAR2(300),
  kmdm    VARCHAR2(15),
  kmmc    VARCHAR2(100),
  bmdm    VARCHAR2(12),
  bmmc    VARCHAR2(50),
  zydm    VARCHAR2(12),
  zymc    VARCHAR2(30),
  xmdm    VARCHAR2(12),
  xmmc    VARCHAR2(50),
  khdm    VARCHAR2(15),
  khmc    VARCHAR2(200),
  csdm    VARCHAR2(12),
  csmc    VARCHAR2(100),
  yhzh    VARCHAR2(12),
  jxzh    VARCHAR2(12),
  dwmc    VARCHAR2(60),
  dfkm    VARCHAR2(50),
  dw      VARCHAR2(8),
  sl      NUMBER(18,6) default 0.0,
  bz      VARCHAR2(8),
  dj      NUMBER(18,6) default 0.0,
  wb      NUMBER(18,6) default 0.0,
  hl      NUMBER(18,6) default 0.0,
  je      NUMBER(14,2) default 0.0,
  yspz    VARCHAR2(16),
  jsr     VARCHAR2(30),
  wldqr   DATE,
  srr     VARCHAR2(30),
  srrq    DATE,
  shr     VARCHAR2(30),
  shrq    DATE,
  jzr     VARCHAR2(30),
  jzrq    DATE)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE gl_pz ADD CONSTRAINT PK_GL_PZ primary key (djh,xh)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CPERIOD' AND table_name ='GL_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_pz ADD cperiod CHAR(6)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_pz MODIFY cperiod CHAR(6)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'table存在，则检测字段
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'JD' AND table_name ='GL_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_pz ADD jd VARCHAR2(3)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_pz MODIFY jd VARCHAR2(3)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'PZLXDM' AND table_name ='GL_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_pz ADD pzlxdm VARCHAR2(4)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_pz MODIFY pzlxdm VARCHAR2(4)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'PZH' AND table_name ='GL_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_pz ADD pzh NUMBER(5,0)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_pz MODIFY pzh NUMBER(5,0)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'KMDM' AND table_name ='GL_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_pz ADD kmdm VARCHAR2(15)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_pz MODIFY kmdm VARCHAR2(15)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'KMMC' AND table_name ='GL_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_pz ADD kmmc VARCHAR2(100)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_pz MODIFY kmmc VARCHAR2(100)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'ZYDM' AND table_name ='GL_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_pz ADD zydm VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_pz MODIFY zydm VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'ZYMC' AND table_name ='GL_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_pz ADD zymc VARCHAR2(30)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_pz MODIFY zymc VARCHAR2(30)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'KHDM' AND table_name ='GL_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_pz ADD khdm VARCHAR2(15)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_pz MODIFY khdm VARCHAR2(15)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'KHMC' AND table_name ='GL_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_pz ADD khmc VARCHAR2(200)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_pz MODIFY khmc VARCHAR2(200)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CSMC' AND table_name ='GL_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_pz ADD csmc VARCHAR2(100)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_pz MODIFY csmc VARCHAR2(100)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'YHZH' AND table_name ='GL_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_pz ADD yhzh VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_pz MODIFY yhzh VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '重建索引
                rcOleDbCommand.CommandText = "SELECT * FROM user_ind_columns WHERE index_name = 'IDX_GL_PZ' AND table_name ='GL_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_ind_columns") IsNot Nothing Then
                    rcDataset.Tables("user_ind_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_ind_columns")
                If rcDataset.Tables("user_ind_columns").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "drop index IDX_GL_PZ"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "CREATE INDEX IDX_GL_PZ on GL_PZ (cperiod,pzlxdm,pzh,kmdm,bmdm,zydm,khdm,csdm,xmdm,yhzh,jxzh)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'cperiod
                rcOleDbCommand.CommandText = "SELECT * FROM user_ind_columns WHERE index_name = 'IDX_GL_PZ_CPERIOD' AND table_name ='GL_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_ind_columns") IsNot Nothing Then
                    rcDataset.Tables("user_ind_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_ind_columns")
                If rcDataset.Tables("user_ind_columns").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "drop index IDX_GL_PZ_CPERIOD"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "create index IDX_GL_PZ_CPERIOD on GL_PZ (cperiod)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'kmdm
                rcOleDbCommand.CommandText = "SELECT * FROM user_ind_columns WHERE index_name = 'IDX_GL_PZ_KMDM' AND table_name ='GL_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_ind_columns") IsNot Nothing Then
                    rcDataset.Tables("user_ind_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_ind_columns")
                If rcDataset.Tables("user_ind_columns").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "drop index IDX_GL_PZ_KMDM"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "create index IDX_GL_PZ_KMDM on GL_PZ (kmdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'bmdm
                rcOleDbCommand.CommandText = "SELECT * FROM user_ind_columns WHERE index_name = 'IDX_GL_PZ_BMDM' AND table_name ='GL_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_ind_columns") IsNot Nothing Then
                    rcDataset.Tables("user_ind_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_ind_columns")
                If rcDataset.Tables("user_ind_columns").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "drop index IDX_GL_PZ_BMDM"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "create index IDX_GL_PZ_BMDM on GL_PZ (bmdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'zydm
                rcOleDbCommand.CommandText = "SELECT * FROM user_ind_columns WHERE index_name = 'IDX_GL_PZ_ZYDM' AND table_name ='GL_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_ind_columns") IsNot Nothing Then
                    rcDataset.Tables("user_ind_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_ind_columns")
                If rcDataset.Tables("user_ind_columns").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "drop index IDX_GL_PZ_ZYDM"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "create index IDX_GL_PZ_ZYDM on GL_PZ (zydm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'xmdm
                rcOleDbCommand.CommandText = "SELECT * FROM user_ind_columns WHERE index_name = 'IDX_GL_PZ_XMDM' AND table_name ='GL_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_ind_columns") IsNot Nothing Then
                    rcDataset.Tables("user_ind_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_ind_columns")
                If rcDataset.Tables("user_ind_columns").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "drop index IDX_GL_PZ_XMDM"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "create index IDX_GL_PZ_XMDM on GL_PZ (xmdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'khdm
                rcOleDbCommand.CommandText = "SELECT * FROM user_ind_columns WHERE index_name = 'IDX_GL_PZ_KHDM' AND table_name ='GL_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_ind_columns") IsNot Nothing Then
                    rcDataset.Tables("user_ind_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_ind_columns")
                If rcDataset.Tables("user_ind_columns").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "drop index IDX_GL_PZ_KHDM"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "create index IDX_GL_PZ_KHDM on GL_PZ (khdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'csdm
                rcOleDbCommand.CommandText = "SELECT * FROM user_ind_columns WHERE index_name = 'IDX_GL_PZ_CSDM' AND table_name ='GL_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_ind_columns") IsNot Nothing Then
                    rcDataset.Tables("user_ind_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_ind_columns")
                If rcDataset.Tables("user_ind_columns").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "drop index IDX_GL_PZ_CSDM"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "create index IDX_GL_PZ_CSDM on GL_PZ (csdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'yhzh
                rcOleDbCommand.CommandText = "SELECT * FROM user_ind_columns WHERE index_name = 'IDX_GL_PZ_YHZH' AND table_name ='GL_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_ind_columns") IsNot Nothing Then
                    rcDataset.Tables("user_ind_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_ind_columns")
                If rcDataset.Tables("user_ind_columns").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "drop index IDX_GL_PZ_YHZH"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "create index IDX_GL_PZ_YHZH on GL_PZ (yhzh)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'jxzh
                rcOleDbCommand.CommandText = "SELECT * FROM user_ind_columns WHERE index_name = 'IDX_GL_PZ_JXZH' AND table_name ='GL_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_ind_columns") IsNot Nothing Then
                    rcDataset.Tables("user_ind_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_ind_columns")
                If rcDataset.Tables("user_ind_columns").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "drop index IDX_GL_PZ_JXZH"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "create index IDX_GL_PZ_JXZH on GL_PZ (jxzh)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        ''****sys_pz*********'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'SYS_PZ'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "create table SYS_PZ (
                  djh     VARCHAR2(15) not null,
                  xh      NUMBER(4) not null,
                  bdelete NUMBER(1),
                  cperiod CHAR(6),
                  pzlxdm  VARCHAR2(4),
                  pzh     NUMBER(5),
                  pzrq    DATE,
                  fjzs    NUMBER(4),
                  jd      VARCHAR2(3),
                  zy      VARCHAR2(300),
                  kmdm    VARCHAR2(15),
                  kmmc    VARCHAR2(100),
                  bmdm    VARCHAR2(12),
                  bmmc    VARCHAR2(50),
                  zydm    VARCHAR2(12),
                  zymc    VARCHAR2(30),
                  xmdm    VARCHAR2(12),
                  xmmc    VARCHAR2(50),
                  khdm    VARCHAR2(15),
                  khmc    VARCHAR2(200),
                  csdm    VARCHAR2(12),
                  csmc    VARCHAR2(100),
                  yhzh    VARCHAR2(12),
                  jxzh    VARCHAR2(12),
                  dwmc    VARCHAR2(60),
                  dfkm    VARCHAR2(50),
                  dw      VARCHAR2(8),
                  sl      NUMBER(18,6) default 0.0,
                  bz      VARCHAR2(8),
                  dj      NUMBER(18,6) default 0.0,
                  wb      NUMBER(18,6) default 0.0,
                  hl      NUMBER(18,6) default 0.0,
                  je      NUMBER(14,2) default 0.0,
                  yspz    VARCHAR2(16),
                  jsr     VARCHAR2(30),
                  wldqr   DATE,
                  srr     VARCHAR2(30),
                  srrq    DATE,
                  shr     VARCHAR2(30),
                  shrq    DATE,
                  jzr     VARCHAR2(30),
                  jzrq    DATE)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE sys_pz ADD CONSTRAINT PK_SYS_PZ primary key (djh,xh)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CPERIOD' AND table_name ='SYS_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE sys_pz ADD cperiod CHAR(6)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE sys_pz MODIFY cperiod CHAR(6)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'table存在，则检测字段
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'JD' AND table_name ='SYS_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE sys_pz ADD jd VARCHAR2(3)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE sys_pz MODIFY jd VARCHAR2(3)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'PZLXDM' AND table_name ='SYS_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE sys_pz ADD pzlxdm VARCHAR2(4)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE sys_pz MODIFY pzlxdm VARCHAR2(4)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'PZH' AND table_name ='SYS_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE sys_pz ADD pzh NUMBER(5,0)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE sys_pz MODIFY pzh NUMBER(5,0)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'KMDM' AND table_name ='SYS_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE sys_pz ADD kmdm VARCHAR2(15)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE sys_pz MODIFY kmdm VARCHAR2(15)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'KMMC' AND table_name ='SYS_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE sys_pz ADD kmmc VARCHAR2(100)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE sys_pz MODIFY kmmc VARCHAR2(100)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'ZYDM' AND table_name ='SYS_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE sys_pz ADD zydm VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE sys_pz MODIFY zydm VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'ZYMC' AND table_name ='SYS_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE sys_pz ADD zymc VARCHAR2(30)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE sys_pz MODIFY zymc VARCHAR2(30)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'KHDM' AND table_name ='SYS_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE sys_pz ADD khdm VARCHAR2(15)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE sys_pz MODIFY khdm VARCHAR2(15)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'KHMC' AND table_name ='SYS_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE sys_pz ADD khmc VARCHAR2(200)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE sys_pz MODIFY khmc VARCHAR2(200)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CSMC' AND table_name ='SYS_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE sys_pz ADD csmc VARCHAR2(100)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE sys_pz MODIFY csmc VARCHAR2(100)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'YHZH' AND table_name ='SYS_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE sys_pz ADD yhzh VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE sys_pz MODIFY yhzh VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '重建索引
                rcOleDbCommand.CommandText = "SELECT * FROM user_ind_columns WHERE index_name = 'IDX_SYS_PZ' AND table_name ='SYS_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_ind_columns") IsNot Nothing Then
                    rcDataset.Tables("user_ind_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_ind_columns")
                If rcDataset.Tables("user_ind_columns").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "drop index IDX_SYS_PZ"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "CREATE INDEX IDX_SYS_PZ on SYS_PZ (cperiod,pzlxdm,pzh,kmdm,bmdm,zydm,khdm,csdm,xmdm,yhzh,jxzh)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'cperiod
                rcOleDbCommand.CommandText = "SELECT * FROM user_ind_columns WHERE index_name = 'IDX_SYS_PZ_CPERIOD' AND table_name ='SYS_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_ind_columns") IsNot Nothing Then
                    rcDataset.Tables("user_ind_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_ind_columns")
                If rcDataset.Tables("user_ind_columns").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "drop index IDX_SYS_PZ_CPERIOD"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "create index IDX_SYS_PZ_CPERIOD on SYS_PZ (cperiod)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'kmdm
                rcOleDbCommand.CommandText = "SELECT * FROM user_ind_columns WHERE index_name = 'IDX_SYS_PZ_KMDM' AND table_name ='SYS_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_ind_columns") IsNot Nothing Then
                    rcDataset.Tables("user_ind_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_ind_columns")
                If rcDataset.Tables("user_ind_columns").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "drop index IDX_SYS_PZ_KMDM"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "create index IDX_SYS_PZ_KMDM on SYS_PZ (kmdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'bmdm
                rcOleDbCommand.CommandText = "SELECT * FROM user_ind_columns WHERE index_name = 'IDX_SYS_PZ_BMDM' AND table_name ='SYS_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_ind_columns") IsNot Nothing Then
                    rcDataset.Tables("user_ind_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_ind_columns")
                If rcDataset.Tables("user_ind_columns").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "drop index IDX_SYS_PZ_BMDM"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "create index IDX_SYS_PZ_BMDM on SYS_PZ (bmdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'zydm
                rcOleDbCommand.CommandText = "SELECT * FROM user_ind_columns WHERE index_name = 'IDX_SYS_PZ_ZYDM' AND table_name ='SYS_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_ind_columns") IsNot Nothing Then
                    rcDataset.Tables("user_ind_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_ind_columns")
                If rcDataset.Tables("user_ind_columns").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "drop index IDX_SYS_PZ_ZYDM"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "create index IDX_SYS_PZ_ZYDM on SYS_PZ (zydm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'xmdm
                rcOleDbCommand.CommandText = "SELECT * FROM user_ind_columns WHERE index_name = 'IDX_SYS_PZ_XMDM' AND table_name ='SYS_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_ind_columns") IsNot Nothing Then
                    rcDataset.Tables("user_ind_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_ind_columns")
                If rcDataset.Tables("user_ind_columns").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "drop index IDX_SYS_PZ_XMDM"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "create index IDX_SYS_PZ_XMDM on SYS_PZ (xmdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'khdm
                rcOleDbCommand.CommandText = "SELECT * FROM user_ind_columns WHERE index_name = 'IDX_SYS_PZ_KHDM' AND table_name ='SYS_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_ind_columns") IsNot Nothing Then
                    rcDataset.Tables("user_ind_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_ind_columns")
                If rcDataset.Tables("user_ind_columns").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "drop index IDX_SYS_PZ_KHDM"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "create index IDX_SYS_PZ_KHDM on SYS_PZ (khdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'csdm
                rcOleDbCommand.CommandText = "SELECT * FROM user_ind_columns WHERE index_name = 'IDX_SYS_PZ_CSDM' AND table_name ='SYS_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_ind_columns") IsNot Nothing Then
                    rcDataset.Tables("user_ind_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_ind_columns")
                If rcDataset.Tables("user_ind_columns").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "drop index IDX_SYS_PZ_CSDM"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "create index IDX_SYS_PZ_CSDM on SYS_PZ (csdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'yhzh
                rcOleDbCommand.CommandText = "SELECT * FROM user_ind_columns WHERE index_name = 'IDX_SYS_PZ_YHZH' AND table_name ='SYS_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_ind_columns") IsNot Nothing Then
                    rcDataset.Tables("user_ind_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_ind_columns")
                If rcDataset.Tables("user_ind_columns").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "drop index IDX_SYS_PZ_YHZH"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "create index IDX_SYS_PZ_YHZH on SYS_PZ (yhzh)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                'jxzh
                rcOleDbCommand.CommandText = "SELECT * FROM user_ind_columns WHERE index_name = 'IDX_SYS_PZ_JXZH' AND table_name ='SYS_PZ'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_ind_columns") IsNot Nothing Then
                    rcDataset.Tables("user_ind_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_ind_columns")
                If rcDataset.Tables("user_ind_columns").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "drop index IDX_SYS_PZ_JXZH"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "create index IDX_SYS_PZ_JXZH on SYS_PZ (jxzh)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try

        '********************'
        '*****rcdata_001*****'
        ''****gl_ywfdkgs******'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'GL_YWFDKGS'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE gl_ywfdkgs (dkgsdm VARCHAR2(12) NOT NULL,dkgsmc VARCHAR2(30),dkgssm VARCHAR2(12),jsgs VARCHAR2(500))"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfdkgs ADD CONSTRAINT PK_GL_YWFDKGS primary key (dkgsdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DKGSDM' AND table_name ='GL_YWFDKGS'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfdkgs ADD dkgsdm VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DKGSMC' AND table_name ='GL_YWFDKGS'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfdkgs ADD dkgsmc VARCHAR2(30)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DKGSSM' AND table_name ='GL_YWFDKGS'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfdkgs ADD dkgssm VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'JSGS' AND table_name ='GL_YWFDKGS'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfdkgs ADD jsgs VARCHAR2(500)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        ''****gl_ywfdkl******'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'GL_YWFDKL'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE gl_ywfdkl (xh VARCHAR2(6) NOT NULL,mc VARCHAR2(30),dkbl NUMBER(6,2) DEFAULT 0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfdkl ADD CONSTRAINT PK_GL_YWFDKL primary key (xh)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'XH' AND table_name ='GL_YWFDKL'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfdkl ADD xh VARCHAR2(6)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'MC' AND table_name ='GL_YWFDKL'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfdkl ADD mc VARCHAR2(30)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DKBL' AND table_name ='GL_YWFDKL'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfdkl ADD dkbl NUMBER(6,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        ''****gl_ywfdkyw******'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'GL_YWFDKYW'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE gl_ywfdkyw (djh VARCHAR2(15) NOT NULL,dkrq DATE,khdm VARCHAR2(15),khmc VARCHAR2(200),dkgsdm VARCHAR2(12),dkgsmc VARCHAR2(30),skje NUMBER(14,2) DEFAULT 0,fyje NUMBER(14,2) DEFAULT 0,dkmemo VARCHAR2(30),srr VARCHAR2(30),srrq DATE,ywfbl NUMBER(7,3) DEFAULT 0,dkje NUMBER(14,2) DEFAULT 0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfdkyw ADD CONSTRAINT PK_GL_YWFDKYW primary key (djh)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DJH' AND table_name ='GL_YWFDKYW'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfdkyw ADD djh VARCHAR2(15) NOT NULL"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DKRQ' AND table_name ='GL_YWFDKYW'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfdkyw ADD dkrq DATE"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'KHDM' AND table_name ='GL_YWFDKYW'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfdkyw ADD khdm VARCHAR2(15)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfdkyw MODIFY khdm VARCHAR2(15)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'KHMC' AND table_name ='GL_YWFDKYW'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfdkyw ADD khmc VARCHAR2(200)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DKGSDM' AND table_name ='GL_YWFDKYW'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfdkyw ADD dkgsdm VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DKGSMC' AND table_name ='GL_YWFDKYW'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfdkyw ADD dkgsmc VARCHAR2(30)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'SKJE' AND table_name ='GL_YWFDKYW'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfdkyw ADD skje NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'FYJE' AND table_name ='GL_YWFDKYW'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfdkyw ADD fyje NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DKMEMO' AND table_name ='GL_YWFDKYW'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfdkyw ADD dkmemo VARCHAR2(50)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'SRR' AND table_name ='GL_YWFDKYW'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfdkyw ADD srr VARCHAR2(30)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'SRRQ' AND table_name ='GL_YWFDKYW'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfdkyw ADD srrq DATE"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'YWFBL' AND table_name ='GL_YWFDKYW'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfdkyw ADD ywfbl NUMBER(7,3) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfdkyw MODIFY ywfbl NUMBER(7,3) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DKJE' AND table_name ='GL_YWFDKYW'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfdkyw ADD dkje NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '重建索引
                rcOleDbCommand.CommandText = "SELECT * FROM user_constraints WHERE table_name ='GL_YWFDKYW'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_constraints") IsNot Nothing Then
                    rcDataset.Tables("user_constraints").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_constraints")
                Dim i As Integer
                For i = 0 To rcDataset.Tables("user_constraints").Rows.Count - 1
                    rcOleDbCommand.CommandText = "alter table GL_YWFDKYW drop constraint " & rcDataset.Tables("user_constraints").Rows(i).Item("constraint_name") & " cascade"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Next
                rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfdkyw ADD CONSTRAINT PK_GL_YWFDKYW primary key (djh)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try

        '********************'
        '*****rcdata_001*****'
        ''****gl_ywfjsb******'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'GL_YWFJSB'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE gl_ywfjsb (cperiod VARCHAR2(6) NOT NULL,khdm VARCHAR2(15) NOT NULL,khmc VARCHAR2(200),zydm VARCHAR2(12),zymc VARCHAR2(30),t_zydm VARCHAR2(12),t_zymc VARCHAR2(30),xslbdm VARCHAR2(12),t_xslbdm VARCHAR2(12),ywfbl NUMBER(7,3) DEFAULT 0,newkhbl NUMBER(6,2) DEFAULT 0,skqx NUMBER(4,0) DEFAULT 0,byjf NUMBER(14,2) DEFAULT 0,bydf NUMBER(14,2) DEFAULT 0,qmye NUMBER(14,2) DEFAULT 0,jf00 NUMBER(14,2) DEFAULT 0,jf01 NUMBER(14,2) DEFAULT 0,jf02 NUMBER(14,2) DEFAULT 0,jf03 NUMBER(14,2) DEFAULT 0,jf04 NUMBER(14,2) DEFAULT 0,jf05 NUMBER(14,2) DEFAULT 0,jf06 NUMBER(14,2) DEFAULT 0,jf07 NUMBER(14,2) DEFAULT 0,jf08 NUMBER(14,2) DEFAULT 0,jf09 NUMBER(14,2) DEFAULT 0,jf10 NUMBER(14,2) DEFAULT 0,jf11 NUMBER(14,2) DEFAULT 0,jf12 NUMBER(14,2) DEFAULT 0,jf13 NUMBER(14,2) DEFAULT 0,jf14 NUMBER(14,2) DEFAULT 0,df01 NUMBER(14,2) DEFAULT 0,df02 NUMBER(14,2) DEFAULT 0,df03 NUMBER(14,2) DEFAULT 0,df04 NUMBER(14,2) DEFAULT 0,df05 NUMBER(14,2) DEFAULT 0,df06 NUMBER(14,2) DEFAULT 0,df07 NUMBER(14,2) DEFAULT 0,df08 NUMBER(14,2) DEFAULT 0,df09 NUMBER(14,2) DEFAULT 0,df10 NUMBER(14,2) DEFAULT 0,df11 NUMBER(14,2) DEFAULT 0,df12 NUMBER(14,2) DEFAULT 0,df13 NUMBER(14,2) DEFAULT 0,df14 NUMBER(14,2) DEFAULT 0,dkl07 NUMBER(6,2) DEFAULT 0,dkl08 NUMBER(6,2) DEFAULT 0,dkl09 NUMBER(6,2) DEFAULT 0,dkl10 NUMBER(6,2) DEFAULT 0,dkl11 NUMBER(6,2) DEFAULT 0,dkl12 NUMBER(6,2) DEFAULT 0,dkl13 NUMBER(6,2) DEFAULT 0,dkl14 NUMBER(6,2) DEFAULT 0,ywf_bz NUMBER(14,2) DEFAULT 0,ywf_newkh NUMBER(14,2) DEFAULT 0,ywf_zl NUMBER(14,2) DEFAULT 0,cdhpje NUMBER(14,2) DEFAULT 0,ywf_cdhp NUMBER(14,2) DEFAULT 0,gylpjje NUMBER(14,2) DEFAULT 0,ywf_gylpj NUMBER(14,2) DEFAULT 0,tiexije NUMBER(14,2) DEFAULT 0,ywf_tx NUMBER(14,2) DEFAULT 0,skje_yj NUMBER(14,2) DEFAULT 0,yongjinje NUMBER(14,2) DEFAULT 0,ywf_yj NUMBER(14,2) DEFAULT 0,daizhang NUMBER(14,2) DEFAULT 0,ywf_dz NUMBER(14,2) DEFAULT 0,susong NUMBER(14,2) DEFAULT 0,ywf_ss NUMBER(14,2) DEFAULT 0,ywf_hlc NUMBER(14,2) DEFAULT 0,ywfhj NUMBER(14,2) DEFAULT 0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD CONSTRAINT PK_GL_YWFJSB primary key (cperiod,khdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CPERIOD' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD cperiod VARCHAR2(6)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'KHDM' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD khdm VARCHAR2(15)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb MODIFY khdm VARCHAR2(15)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'KHMC' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD khmc VARCHAR2(200)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'ZYDM' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD zydm VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb MODIFY zydm VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'ZYMC' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD zymc VARCHAR2(30)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'T_ZYDM' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD t_zydm VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'T_ZYMC' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD t_zymc VARCHAR2(30)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'XSLBDM' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD xslbdm VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'T_XSLBDM' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD t_xslbdm VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'YWFBL' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD ywfbl NUMBER(7,3) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb MODIFY ywfbl NUMBER(7,3) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'NEWKHBL' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD newkhbl NUMBER(6,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'SKQX' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD skqx NUMBER(4,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'BYJF' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD byjf NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'BYDF' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD bydf NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'QMYE' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD qmye NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'JF00' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD jf00 NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'JF01' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD jf01 NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'JF02' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD jf02 NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'JF03' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD jf03 NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'JF04' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD jf04 NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'JF05' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD jf05 NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'JF06' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD jf06 NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'JF07' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD jf07 NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'JF08' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD jf08 NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'JF09' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD jf09 NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'JF10' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD jf10 NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'JF11' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD jf11 NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'JF12' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD jf12 NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'JF13' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD jf13 NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'JF14' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD jf14 NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DF01' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD df01 NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DF02' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD df02 NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DF03' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD df03 NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DF04' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD df04 NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DF05' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD df05 NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DF06' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD df06 NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DF07' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD df07 NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DF08' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD df08 NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DF09' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD df09 NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DF10' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD df10 NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DF11' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD df11 NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DF12' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD df12 NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DF13' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD df13 NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DF14' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD df14 NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If

                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DKL07' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD dkl07 NUMBER(6,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DKL08' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD dkl08 NUMBER(6,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DKL09' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD dkl09 NUMBER(6,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DKL10' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD dkl10 NUMBER(6,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DKL11' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD dkl11 NUMBER(6,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DKL12' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD dkl12 NUMBER(6,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DKL13' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD dkl13 NUMBER(6,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DKL14' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD dkl14 NUMBER(6,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'YWF_BZ' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD ywf_bz NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'YWF_NEWKH' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD ywf_newkh NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'YWF_ZL' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD ywf_zl NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CDHPJE' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD cdhpje NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'YWF_CDHP' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD ywf_cdhp NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'GYLPJJE' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD gylpjje NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'YWF_GYLPJ' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD ywf_gylpj NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'TIEXIJE' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD tiexije NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'YWF_TX' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD ywf_tx NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'SKJE_YJ' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD skje_yj NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'YONGJINJE' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD yongjinje NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'YWF_YJ' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD ywf_yj NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DAIZHANG' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD daizhang NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'YWF_DZ' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD ywf_dz NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'SUSONG' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD susong NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'YWF_SS' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD ywf_ss NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'YWF_HLC' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD ywf_hlc NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'YWFHJ' AND table_name ='GL_YWFJSB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfjsb ADD ywfhj NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        '*****gl_ywfzyrw*****'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'GL_YWFZYRW'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE gl_ywfzyrw (kjnd VARCHAR2(4) NOT NULL,zydm VARCHAR2(12) NOT NULL,rws NUMBER(14,2) DEFAULT 0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfzyrw ADD CONSTRAINT PK_GL_YWFZYRW primary key (kjnd,zydm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'KJND' AND table_name ='GL_YWFZYRW'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfzyrw ADD kjnd VARCHAR2(4) NOT NULL"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'ZYDM' AND table_name ='GL_YWFZYRW'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfzyrw ADD zydm VARCHAR2(12) NOT NULL"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'RWS' AND table_name ='GL_YWFZYRW'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE gl_ywfzyrw ADD rws NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        '*****inv_ckd********'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'INV_CKD'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE inv_ckd (djh VARCHAR2(15) NOT NULL,xh number(4,0),cpmc VARCHAR2(200),dw VARCHAR2(12),ckmemo VARCHAR2(200),brecycle NUMBER(1,0) DEFAULT 0,recyclerq DATE,recycler VARCHAR2(30),cbill_bid VARCHAR2(20))" '待完善
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE inv_ckd ADD CONSTRAINT PK_INV_CKD primary key (djh,xh)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                '行号xh
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'XH' AND table_name ='INV_CKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_ckd ADD xh NUMBER(6,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column INV_CKD.xh is '行号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_ckd MODIFY xh NUMBER(6,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column INV_CKD.xh is '行号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '仓库名称
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CKMC' AND table_name ='INV_CKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_ckd ADD ckmc VARCHAR2(40)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column INV_CKD.ckmc is '仓库名称'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_ckd MODIFY ckmc VARCHAR2(40)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column INV_CKD.ckmc is '仓库名称'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CPMC' AND table_name ='INV_CKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_ckd ADD cpmc VARCHAR2(250)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_ckd MODIFY cpmc VARCHAR2(250)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'DW
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DW' AND table_name ='INV_CKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_ckd ADD dw VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_ckd MODIFY dw VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'PIHAO
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'PIHAO' AND table_name ='INV_CKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_ckd ADD pihao VARCHAR2(40)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_ckd MODIFY pihao VARCHAR2(40)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'CKMEMO
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CKMEMO' AND table_name ='INV_CKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_ckd ADD ckmemo VARCHAR2(200)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_ckd MODIFY ckmemo VARCHAR2(200)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'BRECYCLE回收标志
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'BRECYCLE' AND table_name ='INV_CKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_ckd ADD brecycle NUMBER(1,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_ckd MODIFY brecycle  NUMBER(1,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'RECYCLERQ回收日期
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'RECYCLERQ' AND table_name ='INV_CKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_ckd ADD recyclerq DATE"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_ckd MODIFY recyclerq  DATE"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'RECYCLER回收人
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'RECYCLER' AND table_name ='INV_CKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_ckd ADD recycler VARCHAR2(30)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_ckd MODIFY recycler VARCHAR2(30)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'cbill_bid
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CBILL_BID' AND table_name ='INV_CKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_ckd ADD cbill_bid VARCHAR2(20)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column INV_CKD.cbill_bid is 'NC单据表体主键'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_ckd MODIFY cbill_bid VARCHAR2(20)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column INV_CKD.cbill_bid is 'NC单据表体主键'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '更新fzsl字段是空的为0
                rcOleDbCommand.CommandText = "UPDATE inv_ckd SET fzsl = 0 WHERE fzsl IS NULL"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '更新dj字段是空的为0
                rcOleDbCommand.CommandText = "UPDATE inv_ckd SET dj = 0 WHERE dj IS NULL"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '更新je字段是空的为0
                rcOleDbCommand.CommandText = "UPDATE inv_ckd SET je = 0 WHERE je IS NULL"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        '*****inv_cpyeb********'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'INV_CPYEB'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE inv_cpyeb (djh VARCHAR2(15) NOT NULL,xh number(4,0),cpmc VARCHAR2(200),dw VARCHAR2(12),ckmemo VARCHAR2(200),cbill_bid VARCHAR2(20))" '待完善
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE inv_cpyeb ADD CONSTRAINT PK_inv_cpyeb primary key (kjnd,cpdm,ckdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                '检测索引
                ''组合索引
                'rcOleDbCommand.CommandText = "SELECT * FROM user_indexes WHERE index_name = 'IDX_INV_CPYEB_COMP' AND table_name = 'INV_CPYEB'"
                'rcOleDbCommand.Parameters.Clear()
                'rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                'If rcDataset.Tables("user_indexes") IsNot Nothing Then
                '    rcDataset.Tables("user_indexes").Clear()
                'End If
                'rcOleDbDataAdpt.Fill(rcDataset, "user_indexes")
                'If rcDataset.Tables("user_indexes").Rows.Count <= 0 Then
                '    rcOleDbCommand.CommandText = "CREATE INDEX idx_inv_cpyeb_comp ON inv_cpyeb(kjnd, cpdm, ckdm)"
                '    rcOleDbCommand.Parameters.Clear()
                '    rcOleDbCommand.ExecuteNonQuery()
                'End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_indexes WHERE index_name = 'IDX_INV_CPYEB_CKDM' AND table_name = 'INV_CPYEB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_indexes") IsNot Nothing Then
                    rcDataset.Tables("user_indexes").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_indexes")
                If rcDataset.Tables("user_indexes").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "create index IDX_INV_CPYEB_CKDM on INV_CPYEB (ckdm)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_indexes WHERE index_name = 'IDX_INV_CPYEB_CPDM' AND table_name = 'INV_CPYEB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_indexes") IsNot Nothing Then
                    rcDataset.Tables("user_indexes").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_indexes")
                If rcDataset.Tables("user_indexes").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "create index IDX_INV_CPYEB_CPDM on INV_CPYEB (cpdm)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'table存在，则检测字段
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        '*****inv_dbd********'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'INV_DBD'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE inv_dbd (djh VARCHAR2(15) NOT NULL,xh number(4,0),cpmc VARCHAR2(200),dbmemo VARCHAR2(200),cbill_bid VARCHAR2(20))" '待完善
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE inv_dbd ADD CONSTRAINT PK_INV_DBD primary key (djh,xh)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                rcOleDbCommand.CommandText = "SELECT * FROM user_indexes WHERE index_name = 'IDX_INV_DBD_CCKDM' AND table_name = 'INV_DBD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_indexes") IsNot Nothing Then
                    rcDataset.Tables("user_indexes").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_indexes")
                If rcDataset.Tables("user_indexes").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "create index IDX_INV_DBD_CCKDM on INV_DBD (cckdm)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_indexes WHERE index_name = 'IDX_INV_DBD_RCKDM' AND table_name = 'INV_DBD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_indexes") IsNot Nothing Then
                    rcDataset.Tables("user_indexes").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_indexes")
                If rcDataset.Tables("user_indexes").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "create index IDX_INV_DBD_RCKDM on INV_DBD (rckdm)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_indexes WHERE index_name = 'IDX_INV_DBD_CPDM' AND table_name = 'INV_DBD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_indexes") IsNot Nothing Then
                    rcDataset.Tables("user_indexes").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_indexes")
                If rcDataset.Tables("user_indexes").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "create index IDX_INV_DBD_CPDM on INV_DBD (cpdm)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_indexes WHERE index_name = 'IDX_INV_DBD_DBRQ' AND table_name = 'INV_DBD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_indexes") IsNot Nothing Then
                    rcDataset.Tables("user_indexes").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_indexes")
                If rcDataset.Tables("user_indexes").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "create index IDX_INV_DBD_DBRQ on INV_DBD (dbrq)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'table存在，则检测字段
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CPMC' AND table_name ='INV_DBD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_dbd ADD cpmc VARCHAR2(200)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_dbd MODIFY cpmc VARCHAR2(200)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'DBMEMO
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DBMEMO' AND table_name ='INV_DBD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_dbd ADD dbmemo VARCHAR2(200)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_dbd MODIFY dbmemo VARCHAR2(200)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'cbill_bid
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CBILL_BID' AND table_name ='INV_DBD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_dbd ADD cbill_bid VARCHAR2(20)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column INV_DBD.cbill_bid is 'NC单据表体主键'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_dbd MODIFY cbill_bid VARCHAR2(20)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column INV_DBD.cbill_bid is 'NC单据表体主键'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        '*****inv_fcspyeb********'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'INV_FCSPYEB'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE inv_fcspyeb (kjnd VARCHAR2(4) not null,cpdm varchar2(15),bmdm VARCHAR2(12),khdm VARCHAR2(15),qcsl NUMBER(18,6) default 0,qcfzsl NUMBER(18,6) default 0,qcje NUMBER(14,2) default 0,idsl NUMBER(18,6) default 0,idfzsl NUMBER(18,6) default 0,idje NUMBER(14,2) default 0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE inv_fcspyeb ADD CONSTRAINT PK_inv_fcspyeb primary key (kjnd,cpdm,bmdm,khdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                '检测索引
                ''组合索引
                'rcOleDbCommand.CommandText = "SELECT * FROM user_indexes WHERE index_name = 'IDX_INV_FCSPYEB_COMP' AND table_name = 'INV_FCSPYEB'"
                'rcOleDbCommand.Parameters.Clear()
                'rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                'If rcDataset.Tables("user_indexes") IsNot Nothing Then
                '    rcDataset.Tables("user_indexes").Clear()
                'End If
                'rcOleDbDataAdpt.Fill(rcDataset, "user_indexes")
                'If rcDataset.Tables("user_indexes").Rows.Count <= 0 Then
                '    rcOleDbCommand.CommandText = "CREATE INDEX idx_inv_fcspyeb_comp ON INV_FCSPYEB(KJND, CPDM, BMDM, KHDM)"
                '    rcOleDbCommand.Parameters.Clear()
                '    rcOleDbCommand.ExecuteNonQuery()
                'End If
                '检测索引
                rcOleDbCommand.CommandText = "SELECT * FROM user_indexes WHERE index_name = 'IDX_INV_FCSPYEB_BMDM' AND table_name = 'INV_FCSPYEB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_indexes") IsNot Nothing Then
                    rcDataset.Tables("user_indexes").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_indexes")
                If rcDataset.Tables("user_indexes").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "create index IDX_INV_FCSPYEB_BMDM on INV_FCSPYEB (bmdm)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_indexes WHERE index_name = 'IDX_INV_FCSPYEB_KHDM' AND table_name = 'INV_FCSPYEB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_indexes") IsNot Nothing Then
                    rcDataset.Tables("user_indexes").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_indexes")
                If rcDataset.Tables("user_indexes").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "create index IDX_INV_FCSPYEB_KHDM on INV_FCSPYEB (khdm)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_indexes WHERE index_name = 'IDX_INV_FCSPYEB_CPDM' AND table_name = 'INV_FCSPYEB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_indexes") IsNot Nothing Then
                    rcDataset.Tables("user_indexes").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_indexes")
                If rcDataset.Tables("user_indexes").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "create index IDX_INV_FCSPYEB_CPDM on INV_FCSPYEB (cpdm)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'table存在，则检测字段
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try

        '********************'
        '*****rcdata_001*****'
        '*****inv_rkd********'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'INV_RKD'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE inv_rkd (djh VARCHAR2(15) NOT NULL,xh number(4,0),cpmc VARCHAR2(200),bzcb NUMBER(18,6) DEFAULT 0.0,clcb NUMBER(14,2) DEFAULT 0.0,rgcb NUMBER(14,2) DEFAULT 0.0,nycb NUMBER(14,2) DEFAULT 0.0,zjcb NUMBER(14,2) DEFAULT 0.0,glcb NUMBER(14,2) DEFAULT 0.0,xsdj NUMBER(18,6) DEFAULT 0.0,xsje NUMBER(14,2) DEFAULT 0.0,rkmemo VARCHAR2(200),cbill_bid VARCHAR2(20))" '待完善
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE inv_rkd ADD CONSTRAINT PK_INV_RKD primary key (djh,xh)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                '检测索引
                rcOleDbCommand.CommandText = "SELECT * FROM user_indexes WHERE index_name = 'IDX_INV_RKD_BMDM' AND table_name = 'INV_RKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_indexes") IsNot Nothing Then
                    rcDataset.Tables("user_indexes").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_indexes")
                If rcDataset.Tables("user_indexes").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "create index IDX_INV_RKD_BMDM on INV_RKD (bmdm)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_indexes WHERE index_name = 'IDX_INV_RKD_CKDM' AND table_name = 'INV_RKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_indexes") IsNot Nothing Then
                    rcDataset.Tables("user_indexes").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_indexes")
                If rcDataset.Tables("user_indexes").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "create index IDX_INV_RKD_CKDM on INV_RKD (ckdm)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_indexes WHERE index_name = 'IDX_INV_RKD_CPDM' AND table_name = 'INV_RKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_indexes") IsNot Nothing Then
                    rcDataset.Tables("user_indexes").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_indexes")
                If rcDataset.Tables("user_indexes").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "create index IDX_INV_RKD_CPDM on INV_RKD (cpdm)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_indexes WHERE index_name = 'IDX_INV_RKD_RKRQ' AND table_name = 'INV_RKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_indexes") IsNot Nothing Then
                    rcDataset.Tables("user_indexes").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_indexes")
                If rcDataset.Tables("user_indexes").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "create index IDX_INV_RKD_RKRQ on INV_RKD (rkrq)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'table存在，则检测字段
                '行号xh
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'XH' AND table_name ='INV_RKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_rkd ADD xh NUMBER(6,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column INV_RKD.xh is '行号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_rkd MODIFY xh NUMBER(6,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column INV_RKD.xh is '行号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CPMC' AND table_name ='INV_RKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_rkd ADD cpmc VARCHAR2(200)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_rkd MODIFY cpmc VARCHAR2(200)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '标准成本
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'BZCB' AND table_name ='INV_RKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_rkd ADD bzcb NUMBER(18,6) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_rkd MODIFY bzcb NUMBER(18,6) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'CLCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CLCB' AND table_name ='INV_RKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_rkd ADD clcb NUMBER(14,2) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_rkd MODIFY clcb NUMBER(14,2) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'RGCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'RGCB' AND table_name ='INV_RKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_rkd ADD rgcb NUMBER(14,2) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_rkd MODIFY rgcb NUMBER(14,2) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'NYCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'NYCB' AND table_name ='INV_RKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_rkd ADD nycb NUMBER(14,2) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_rkd MODIFY nycb NUMBER(14,2) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'ZJCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'ZJCB' AND table_name ='INV_RKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_rkd ADD zjcb NUMBER(14,2) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_rkd MODIFY zjcb NUMBER(14,2) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'GLCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'GLCB' AND table_name ='INV_RKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_rkd ADD glcb NUMBER(14,2) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_rkd MODIFY glcb NUMBER(14,2) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'XSDJ
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'XSDJ' AND table_name ='INV_RKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_rkd ADD xsdj NUMBER(18,6) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_rkd MODIFY xsdj NUMBER(18,6) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'XSJE
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'XSJE' AND table_name ='INV_RKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_rkd ADD xsje NUMBER(14,2) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_rkd MODIFY xsje NUMBER(14,2) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'RKMEMO
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'RKMEMO' AND table_name ='INV_RKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_rkd ADD rkmemo VARCHAR2(200)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_rkd MODIFY rkmemo VARCHAR2(200)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'cbill_bid
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CBILL_BID' AND table_name ='INV_RKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_rkd ADD cbill_bid VARCHAR2(20)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column INV_RKD.cbill_bid is 'NC单据表体主键'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE inv_rkd MODIFY cbill_bid VARCHAR2(20)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column INV_RKD.cbill_bid is 'NC单据表体主键'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '更新fzsl字段是空的为0
                rcOleDbCommand.CommandText = "UPDATE inv_rkd SET fzsl = 0 WHERE fzsl IS NULL"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                '更新je字段是空的为0
                rcOleDbCommand.CommandText = "UPDATE inv_rkd SET je = 0 WHERE je IS NULL"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()

            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        ''****oe_dd*********'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'OE_DD'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE oe_dd (djh VARCHAR2(15) NOT NULL,xh number(4,0),sdjh VARCHAR2(15),sxh number(4,0))" '待完善
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE oe_dd ADD CONSTRAINT PK_OE_DD primary key (djh,xh)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                '行号xh
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'XH' AND table_name ='OE_DD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_dd ADD xh NUMBER(6,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_DD.xh is '行号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_dd MODIFY xh NUMBER(6,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_DD.xh is '行号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '送货单税额
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'FPJE' AND table_name ='OE_DD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_dd ADD fpje NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_DD.fpje is '发票金额'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_dd MODIFY fpje NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_DD.fpje is '发票金额'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'SDJH' AND table_name ='OE_DD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_dd ADD sdjh VARCHAR2(15)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'SXH' AND table_name ='OE_DD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_dd ADD sxh NUMBER(4,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        ''****oe_fp*********'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'OE_FP'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE oe_fp (djh VARCHAR2(15) NOT NULL,xh number(4,0),sdjh VARCHAR2(15),sxh number(4,0))" '待完善
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE oe_fp ADD CONSTRAINT PK_OE_FP primary key (djh,xh)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                '行号xh
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'XH' AND table_name ='OE_FP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp ADD xh NUMBER(6,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_FP.xh is '行号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp MODIFY xh NUMBER(6,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_FP.xh is '行号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If

                '客户订单号
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'KHDDH' AND table_name ='OE_FP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp ADD khddh VARCHAR2(30)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_FP.khddh is '客户订单号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp MODIFY khddh VARCHAR2(30)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_FP.khddh is '客户订单号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '客户编码
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'KHDM' AND table_name ='OE_FP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp ADD khdm VARCHAR2(15)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_FP.khdm is '客户编码'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp MODIFY khdm VARCHAR2(15)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_FP.khdm is '客户编码'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '客户名称
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'KHMC' AND table_name ='OE_FP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp ADD khmc VARCHAR2(200)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_FP.khmc is '客户名称'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp MODIFY khmc VARCHAR2(200)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_FP.khmc is '客户名称'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '收货客户编码
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'SHKHDM' AND table_name ='OE_FP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp ADD shkhdm VARCHAR2(15)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_FP.shkhdm is '收货客户编码'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp MODIFY shkhdm VARCHAR2(15)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_FP.shkhdm is '收货客户编码'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '客户名称
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'SHKHMC' AND table_name ='OE_FP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp ADD shkhmc VARCHAR2(200)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_FP.shkhmc is '收货客户名称'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp MODIFY shkhmc VARCHAR2(200)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_FP.shkhmc is '收货客户名称'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '部门编码bmdm
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'BMDM' AND table_name ='OE_FP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp ADD bmdm VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '部门名称bmmc
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'BMMC' AND table_name ='OE_FP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp ADD bmmc VARCHAR2(60)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp MODIFY bmmc VARCHAR2(60)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '送货单单据号xsddjh
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'XSDDJH' AND table_name ='OE_FP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp ADD xsddjh VARCHAR2(40)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_FP.xsddjh is '送货单单据号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp MODIFY xsddjh VARCHAR2(40)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_FP.xsddjh is '送货单单据号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '送货单行号xsdxh
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'XSDXH' AND table_name ='OE_FP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp ADD xsdxh NUMBER(6,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_FP.xsdxh is '送货单行号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp MODIFY xsdxh NUMBER(6,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_FP.xsdxh is '送货单行号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '送货单单价xsddj
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'XSDDJ' AND table_name ='OE_FP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp ADD xsddj NUMBER(18,6) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_FP.xsddj is '送货单不含税单价'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp MODIFY xsddj NUMBER(18,6) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_FP.xsddj is '送货单不含税单价'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '送货单含税单价xsdhsdj
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'XSDHSDJ' AND table_name ='OE_FP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp ADD xsdhsdj NUMBER(18,6) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_FP.xsdhsdj is '送货单含税单价'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp MODIFY xsdhsdj NUMBER(18,6) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_FP.xsdhsdj is '送货单含税单价'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '送货单金额xsdje
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'XSDJE' AND table_name ='OE_FP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp ADD xsdje NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_FP.xsdje is '送货单金额'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp MODIFY xsdje NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_FP.xsdje is '送货单金额'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '送货单税率xsdshlv
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'XSDSHLV' AND table_name ='OE_FP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp ADD xsdshlv NUMBER(6,2) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_FP.xsdshlv is '送货单税率'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp MODIFY xsdshlv NUMBER(6,2) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_FP.xsdshlv is '送货单税率'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '送货单税额xsdse
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'XSDSE' AND table_name ='OE_FP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp ADD xsdse NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_FP.xsdse is '送货单税额'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp MODIFY xsdse NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_FP.xsdse is '送货单税额'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '成本单价cbdj
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CBDJ' AND table_name ='OE_FP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp ADD cbdj NUMBER(18,6) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_FP.cbdj is '成本单价'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp MODIFY cbdj NUMBER(18,6) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_FP.cbdj is '成本单价'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '成本金额cbje
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CBJE' AND table_name ='OE_FP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp ADD cbje NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_FP.cbje is '成本金额'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp MODIFY cbje NUMBER(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_FP.cbje is '成本金额'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'BRECYCLE回收标志
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'BPZ' AND table_name ='OE_FP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp ADD bpz NUMBER(1,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_FP.bpz is '凭证生成标志'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_fp MODIFY bpz  NUMBER(1,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_FP.bpz is '凭证生成标志'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '检测索引
                'bdelete, fprq, cpdm, bmdm, shkhdm
                rcOleDbCommand.CommandText = "SELECT * FROM user_indexes WHERE index_name = 'IDX_OE_FP_COMP1' AND table_name = 'OE_FP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_indexes") IsNot Nothing Then
                    rcDataset.Tables("user_indexes").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_indexes")
                If rcDataset.Tables("user_indexes").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "create index IDX_OE_FP_COMP1 on OE_FP (bdelete, fprq, cpdm, bmdm, shkhdm)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'fprq
                rcOleDbCommand.CommandText = "SELECT * FROM user_indexes WHERE index_name = 'IDX_OE_FP_FPRQ' AND table_name = 'OE_FP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_indexes") IsNot Nothing Then
                    rcDataset.Tables("user_indexes").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_indexes")
                If rcDataset.Tables("user_indexes").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "create index IDX_OE_FP_FPRQ on OE_FP (fprq)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'khdm
                rcOleDbCommand.CommandText = "SELECT * FROM user_indexes WHERE index_name = 'IDX_OE_FP_KHDM' AND table_name = 'OE_FP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_indexes") IsNot Nothing Then
                    rcDataset.Tables("user_indexes").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_indexes")
                If rcDataset.Tables("user_indexes").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "create index IDX_OE_FP_KHDM on OE_FP (khdm)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'shkhdm
                rcOleDbCommand.CommandText = "SELECT * FROM user_indexes WHERE index_name = 'IDX_OE_FP_SHKHDM' AND table_name = 'OE_FP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_indexes") IsNot Nothing Then
                    rcDataset.Tables("user_indexes").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_indexes")
                If rcDataset.Tables("user_indexes").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "create index IDX_OE_FP_SHKHDM on OE_FP (shkhdm)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'bmdm
                rcOleDbCommand.CommandText = "SELECT * FROM user_indexes WHERE index_name = 'IDX_OE_FP_BMDM' AND table_name = 'OE_FP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_indexes") IsNot Nothing Then
                    rcDataset.Tables("user_indexes").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_indexes")
                If rcDataset.Tables("user_indexes").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "create index IDX_OE_FP_BMDM on OE_FP (bmdm)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'cpdm
                rcOleDbCommand.CommandText = "SELECT * FROM user_indexes WHERE (index_name = 'IDX_OE_FP_CPDM' OR index_name ='IDXOE_FPCPDM') AND table_name = 'OE_FP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_indexes") IsNot Nothing Then
                    rcDataset.Tables("user_indexes").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_indexes")
                If rcDataset.Tables("user_indexes").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "create index IDX_OE_FP_CPDM on OE_FP (cpdm)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        '*****oe_xsd********'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'OE_XSD'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE oe_xsd (djh VARCHAR2(15) NOT NULL,xh number(4,0),bmdm VARCHAR2(12),xsmemo VARCHAR2(200),csdm VARCHAR2(12),csmc VARCHAR2(100),cbill_bid VARCHAR2(20))" '待完善
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd ADD CONSTRAINT PK_OE_XSD primary key (djh,xh)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                '行号xh
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'XH' AND table_name ='OE_XSD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd ADD xh NUMBER(6,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_XSD.xh is '行号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd MODIFY xh NUMBER(6,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_XSD.xh is '行号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '仓库名称
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CKMC' AND table_name ='OE_XSD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd ADD ckmc VARCHAR2(40)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_XSD.ckmc is '仓库名称'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd MODIFY ckmc VARCHAR2(40)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_XSD.ckmc is '仓库名称'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '批号PIHAO
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'PIHAO' AND table_name ='OE_XSD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd ADD pihao VARCHAR2(40)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_XSD.pihao is '批次号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd MODIFY pihao VARCHAR2(40)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_XSD.pihao is '批次号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '开票客户编码
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'FPKHDM' AND table_name ='OE_XSD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd ADD fpkhdm VARCHAR2(15)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_XSD.fpkhdm is '开票客户编码'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd MODIFY fpkhdm VARCHAR2(15)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_XSD.fpkhdm is '开票客户编码'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '开票客户名称
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'FPKHMC' AND table_name ='OE_XSD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd ADD fpkhmc VARCHAR2(200)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_XSD.fpkhmc is '开票客户名称'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd MODIFY fpkhmc VARCHAR2(200)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_XSD.fpkhmc is '开票客户名称'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'bmdm
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'BMDM' AND table_name ='OE_XSD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd ADD bmdm VARCHAR2(12) DEFAULT '~'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd MODIFY bmdm VARCHAR2(12) DEFAULT '~'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'bmmc
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'BMMC' AND table_name ='OE_XSD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd ADD bmmc VARCHAR2(60) DEFAULT '~'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd MODIFY bmmc VARCHAR2(60) DEFAULT '~'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'xsmemo
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'XSMEMO' AND table_name ='OE_XSD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd ADD xsmemo VARCHAR2(200)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd MODIFY xsmemo VARCHAR2(200)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'csdm
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CSDM' AND table_name ='OE_XSD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd ADD csdm VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd MODIFY csdm VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'csmc
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CSMC' AND table_name ='OE_XSD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd ADD csmc VARCHAR2(100)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd MODIFY csmc VARCHAR2(100)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'cbill_bid
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CBILL_BID' AND table_name ='OE_XSD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd ADD cbill_bid VARCHAR2(20)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_XSD.cbill_bid is 'NC单据表体主键'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd MODIFY cbill_bid VARCHAR2(20)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_XSD.cbill_bid is 'NC单据表体主键'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '单据号vbillcode
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'VBILLCODE' AND table_name ='OE_XSD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd ADD vbillcode VARCHAR2(40)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_XSD.vbillcode is 'NC单据号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd MODIFY vbillcode VARCHAR2(40)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_XSD.vbillcode is 'NC单据号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '单据号vbillcode
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CROWNO' AND table_name ='OE_XSD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd ADD crowno VARCHAR2(20)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_XSD.crowno is 'NC行号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd MODIFY crowno VARCHAR2(20)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_XSD.crowno is 'NC行号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '检测索引
                '复合覆盖索引1cpdm,ckdm,xsrq,bdelete
                rcOleDbCommand.CommandText = "SELECT * FROM user_indexes WHERE index_name = 'IDX_OE_XSD_COMP1' AND table_name = 'OE_XSD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_indexes") IsNot Nothing Then
                    rcDataset.Tables("user_indexes").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_indexes")
                If rcDataset.Tables("user_indexes").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "CREATE INDEX idx_oe_xsd_comp1 ON OE_XSD (CPDM,CKDM,XSRQ,BDELETE)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '复合覆盖索引2cpdm,bmdm,khdm,xsrq,bdelete
                rcOleDbCommand.CommandText = "SELECT * FROM user_indexes WHERE index_name = 'IDX_OE_XSD_COMP2' AND table_name = 'OE_XSD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_indexes") IsNot Nothing Then
                    rcDataset.Tables("user_indexes").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_indexes")
                If rcDataset.Tables("user_indexes").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "CREATE INDEX idx_oe_xsd_comp2 ON OE_XSD (bdelete, xsrq, cpdm, bmdm, khdm)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'khdm
                rcOleDbCommand.CommandText = "SELECT * FROM user_indexes WHERE index_name = 'IDX_OE_XSD_KHDM' AND table_name = 'OE_XSD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_indexes") IsNot Nothing Then
                    rcDataset.Tables("user_indexes").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_indexes")
                If rcDataset.Tables("user_indexes").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "create index IDX_OE_XSD_KHDM on OE_XSD (khdm)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'fpkhdm
                rcOleDbCommand.CommandText = "SELECT * FROM user_indexes WHERE index_name = 'IDX_OE_XSD_FPKHDM' AND table_name = 'OE_XSD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_indexes") IsNot Nothing Then
                    rcDataset.Tables("user_indexes").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_indexes")
                If rcDataset.Tables("user_indexes").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "create index IDX_OE_XSD_FPKHDM on OE_XSD (fpkhdm)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_indexes WHERE index_name = 'IDX_OE_XSD_BMDM' AND table_name = 'OE_XSD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_indexes") IsNot Nothing Then
                    rcDataset.Tables("user_indexes").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_indexes")
                If rcDataset.Tables("user_indexes").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "create index IDX_OE_XSD_BMDM on OE_XSD (bmdm)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_indexes WHERE index_name = 'IDX_OE_XSD_CKDM' AND table_name = 'OE_XSD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_indexes") IsNot Nothing Then
                    rcDataset.Tables("user_indexes").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_indexes")
                If rcDataset.Tables("user_indexes").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "create index IDX_OE_XSD_CKDM on OE_XSD (ckdm)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_indexes WHERE index_name = 'IDX_OE_XSD_CPDM' AND table_name = 'OE_XSD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_indexes") IsNot Nothing Then
                    rcDataset.Tables("user_indexes").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_indexes")
                If rcDataset.Tables("user_indexes").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "create index IDX_OE_XSD_CPDM on OE_XSD (cpdm)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_indexes WHERE index_name = 'IDX_OE_XSD_XSRQ' AND table_name = 'OE_XSD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_indexes") IsNot Nothing Then
                    rcDataset.Tables("user_indexes").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_indexes")
                If rcDataset.Tables("user_indexes").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "create index IDX_OE_XSD_XSRQ on OE_XSD (xsrq)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If


                '更新fzsl字段是空的为0
                rcOleDbCommand.CommandText = "UPDATE oe_xsd SET fzsl = 0 WHERE fzsl IS NULL"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()

            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        '*****oe_xsd_fcsp********'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'OE_XSD_FCSP'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE oe_xsd_fcsp (cperiod CHAR(6),ckkjqj CHAR(6),djh VARCHAR2(40) NOT NULL,xh number(6,0),shkhdm VARCHAR2(15),fpkhdm VARCHAR2(15),bmdm VARCHAR2(12),cpdm VARCHAR2(15),sl NUMBER(18,6) DEFAULT 0,je NUMBER(14,2) DEFAULT 0,se NUMBER(14,2) DEFAULT 0,cbje NUMBER(14,2) DEFAULT 0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd_fcsp ADD CONSTRAINT PK_OE_XSD_FCSP primary key (cperiod,djh,xh,shkhdm,fpkhdm,bmdm,cpdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                '销售出库日期xsrq
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CKKJQJ' AND table_name ='OE_XSD_FCSP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd_fcsp ADD ckkjqj CHAR(6)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_XSD_FCSP.ckkjqj is '出库会计期间'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd_fcsp MODIFY ckkjqj CHAR(6)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_XSD_FCSP.ckkjqj is '出库会计期间'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '单据号djh
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DJH' AND table_name ='OE_XSD_FCSP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd_fcsp ADD djh VARCHAR2(40)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_XSD_FCSP.djh is '单据号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd_fcsp MODIFY djh VARCHAR2(40)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_XSD_FCSP.djh is '单据号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '行号xh
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'XH' AND table_name ='OE_XSD_FCSP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd_fcsp ADD xh NUMBER(6,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_XSD_FCSP.xh is '行号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd_fcsp MODIFY xh NUMBER(6,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_XSD_FCSP.xh is '行号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If

                'khdm字段改名成shkhdm
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'KHDM' AND table_name ='OE_XSD_FCSP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count > 0 Then
                    rcOleDbCommand.CommandText = "alter table OE_XSD_FCSP rename column khdm to shkhdm"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_XSD_FCSP.shkhdm is '送货客户'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If

                '送货客户shkhdm
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'SHKHDM' AND table_name ='OE_XSD_FCSP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd_fcsp ADD shkhdm VARCHAR2(15)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_XSD_FCSP.shkhdm is '收货客户'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd_fcsp MODIFY shkhdm VARCHAR2(15)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_XSD_FCSP.shkhdm is '收货客户'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '开票客户fpkhdm
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'FPKHDM' AND table_name ='OE_XSD_FCSP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd_fcsp ADD fpkhdm VARCHAR2(15)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_XSD_FCSP.fpkhdm is '开票客户'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE oe_xsd_fcsp MODIFY fpkhdm VARCHAR2(15)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column OE_XSD_FCSP.fpkhdm is '开票客户'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '删除主键、新增主键
                rcOleDbCommand.CommandText = "alter table OE_XSD_FCSP drop constraint PK_OE_XSD_FCSP cascade"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "alter table OE_XSD_FCSP add constraint PK_OE_XSD_FCSP primary key (CPERIOD, DJH, XH, SHKHDM, FPKHDM, BMDM, CPDM)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        '*****pm_bomdata*****'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'PM_BOMDATA'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建parentcpdm,childcpdm,sl,dj,je,bommemo
                rcOleDbCommand.CommandText = "CREATE TABLE pm_bomdata (cperiod VARCHAR2(6),parentcpdm VARCHAR2(15) NOT NULL,childcpdm Varchar2(15),sl NUMBER(18,6) DEFAULT 0,dj NUMBER(18,6) DEFAULT 0,je NUMBER(16,4) DEFAULT 0,bommemo VARCHAR2(50))"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE pm_bomdata ADD CONSTRAINT PK_PM_BOMDATA primary key (cperiod,parentcpdm,childcpdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                'rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'RKRQ' AND table_name ='PO_CGD'"
                'rcOleDbCommand.Parameters.Clear()
                'rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                'If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                '    rcDataset.Tables("user_tab_columns").Clear()
                'End If
                'rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                'If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                '    rcOleDbCommand.CommandText = "ALTER TABLE po_cgd ADD rkrq DATE"
                '    rcOleDbCommand.Parameters.Clear()
                '    rcOleDbCommand.ExecuteNonQuery()
                'End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        '*****pm_zcbje*****'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'PM_ZCBJE'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建parentcpdm,childcpdm,sl,dj,je,bommemo
                rcOleDbCommand.CommandText = "CREATE TABLE pm_zcbje (cperiod VARCHAR2(6),bmdm VARCHAR2(12) NOT NULL,qczcpje NUMBER(14,2) DEFAULT 0,qczcpje_clcb NUMBER(14,2) DEFAULT 0,qczcpje_rgcb NUMBER(14,2) DEFAULT 0,qczcpje_nycb NUMBER(14,2) DEFAULT 0,qczcpje_zjcb NUMBER(14,2) DEFAULT 0,qczcpje_glcb NUMBER(14,2) DEFAULT 0,zcbje NUMBER(14,2) DEFAULT 0,zcbje_clcb NUMBER(14,2) DEFAULT 0,zcbje_rgcb NUMBER(14,2) DEFAULT 0,zcbje_nycb NUMBER(14,2) DEFAULT 0,zcbje_zjcb NUMBER(14,2) DEFAULT 0,zcbje_glcb NUMBER(14,2) DEFAULT 0,ccpje NUMBER(14,2) DEFAULT 0,ccpje_clcb NUMBER(14,2) DEFAULT 0,ccpje_rgcb NUMBER(14,2) DEFAULT 0,ccpje_nycb NUMBER(14,2) DEFAULT 0,ccpje_zjcb NUMBER(14,2) DEFAULT 0,ccpje_glcb NUMBER(14,2) DEFAULT 0,qmzcclje NUMBER(14,2) DEFAULT 0,qmzcclje_clcb NUMBER(14,2) DEFAULT 0,qmzcclje_rgcb NUMBER(14,2) DEFAULT 0,qmzcclje_nycb NUMBER(14,2) DEFAULT 0,qmzcclje_zjcb NUMBER(14,2) DEFAULT 0,qmzcclje_glcb NUMBER(14,2) DEFAULT 0,qmzcpje NUMBER(14,2) DEFAULT 0,qmzcpje_clcb NUMBER(14,2) DEFAULT 0,qmzcpje_rgcb NUMBER(14,2) DEFAULT 0,qmzcpje_nycb NUMBER(14,2) DEFAULT 0,qmzcpje_zjcb NUMBER(14,2) DEFAULT 0,qmzcpje_glcb NUMBER(14,2) DEFAULT 0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE pm_zcbje ADD CONSTRAINT PK_PM_ZCBJE primary key (cperiod,bmdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                'QCZCPJE
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'QCZCPJE' AND table_name ='PM_ZCBJE'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcbje ADD qczcpje number(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'QCZCPJE_CLCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'QCZCPJE_CLCB' AND table_name ='PM_ZCBJE'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcbje ADD qczcpje_clcb number(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'QCZCPJE_RGCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'QCZCPJE_RGCB' AND table_name ='PM_ZCBJE'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcbje ADD qczcpje_rgcb number(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'QCZCPJE_NYCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'QCZCPJE_NYCB' AND table_name ='PM_ZCBJE'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcbje ADD qczcpje_nycb number(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'QCZCPJE_ZJCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'QCZCPJE_ZJCB' AND table_name ='PM_ZCBJE'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcbje ADD qczcpje_zjcb number(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'QCZCPJE_GLCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'QCZCPJE_GLCB' AND table_name ='PM_ZCBJE'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcbje ADD qczcpje_glcb number(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'ZCBJE
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'ZCBJE' AND table_name ='PM_ZCBJE'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcbje ADD zcbje number(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'ZCBJE_CLCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'ZCBJE_CLCB' AND table_name ='PM_ZCBJE'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcbje ADD zcbje_clcb number(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'ZCBJE_RGCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'ZCBJE_RGCB' AND table_name ='PM_ZCBJE'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcbje ADD zcbje_rgcb number(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'ZCBJE_NYCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'ZCBJE_NYCB' AND table_name ='PM_ZCBJE'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcbje ADD zcbje_nycb number(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'ZCBJE_ZJCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'ZCBJE_ZJCB' AND table_name ='PM_ZCBJE'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcbje ADD zcbje_zjcb number(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'ZCBJE_GLCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'ZCBJE_GLCB' AND table_name ='PM_ZCBJE'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcbje ADD zcbje_glcb number(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'CCPJE
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CCPJE' AND table_name ='PM_ZCBJE'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcbje ADD ccpje number(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'CCPJE_CLCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CCPJE_CLCB' AND table_name ='PM_ZCBJE'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcbje ADD ccpje_clcb number(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'CCPJE_RGCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CCPJE_RGCB' AND table_name ='PM_ZCBJE'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcbje ADD ccpje_rgcb number(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'CCPJE_NYCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CCPJE_NYCB' AND table_name ='PM_ZCBJE'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcbje ADD ccpje_nycb number(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'CCPJE_ZJCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CCPJE_ZJCB' AND table_name ='PM_ZCBJE'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcbje ADD ccpje_zjcb number(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'CCPJE_GLCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CCPJE_GLCB' AND table_name ='PM_ZCBJE'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcbje ADD ccpje_glcb number(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'QMZCCLJE
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'QMZCCLJE' AND table_name ='PM_ZCBJE'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcbje ADD qmzcclje number(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'QMZCCLJE_CLCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'QMZCCLJE_CLCB' AND table_name ='PM_ZCBJE'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcbje ADD qmzcclje_clcb number(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'QMZCCLJE_RGCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'QMZCCLJE_RGCB' AND table_name ='PM_ZCBJE'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcbje ADD qmzcclje_rgcb number(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'QMZCCLJE_NYCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'QMZCCLJE_NYCB' AND table_name ='PM_ZCBJE'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcbje ADD qmzcclje_nycb number(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'QMZCCLJE_ZJCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'QMZCCLJE_ZJCB' AND table_name ='PM_ZCBJE'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcbje ADD qmzcclje_zjcb number(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'QMZCCLJE_GLCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'QMZCCLJE_GLCB' AND table_name ='PM_ZCBJE'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcbje ADD qmzcclje_glcb number(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'QMZCPJE
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'QMZCPJE' AND table_name ='PM_ZCBJE'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcbje ADD qmzcpje number(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'QMZCPJE_CLCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'QMZCPJE_CLCB' AND table_name ='PM_ZCBJE'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcbje ADD qmzcpje_clcb number(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'QMZCPJE_RGCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'QMZCPJE_RGCB' AND table_name ='PM_ZCBJE'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcbje ADD qmzcpje_rgcb number(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'QMZCPJE_NYCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'QMZCPJE_NYCB' AND table_name ='PM_ZCBJE'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcbje ADD qmzcpje_nycb number(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'QMZCPJE_ZJCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'QMZCPJE_ZJCB' AND table_name ='PM_ZCBJE'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcbje ADD qmzcpje_zjcb number(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'QMZCPJE_GLCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'QMZCPJE_GLCB' AND table_name ='PM_ZCBJE'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcbje ADD qmzcpje_glcb number(14,2) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        '*****pm_zcp*****'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'PM_ZCP'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建parentcpdm,childcpdm,sl,dj,je,bommemo
                rcOleDbCommand.CommandText = "CREATE TABLE pm_zcp (cperiod VARCHAR2(6) NOT NULL,bmdm VARCHAR2(12) NOT NULL,cpdm VARCHAR2(15) NOT NULL,gxdm VARCHAR2(12) NOT NULL,zcpsl NUMBER(18,6) DEFAULT 0,ydsl NUMBER(18,6) DEFAULT 0,zcpje NUMBER(14,2) DEFAULT 0,clcb NUMBER(14,2) DEFAULT 0,rgcb NUMBER(14,2) DEFAULT 0,nycb NUMBER(14,2) DEFAULT 0,zjcb NUMBER(14,2) DEFAULT 0,glcb NUMBER(14,2) DEFAULT 0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE pm_zcp ADD CONSTRAINT PK_PM_ZCP primary key (cperiod,bmdm,cpdm,gxdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                'CLCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CLCB' AND table_name ='PM_ZCP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcp ADD clcb number(14,2) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcp MODIFY clcb number(14,2) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'RGCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'RGCB' AND table_name ='PM_ZCP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcp ADD rgcb number(14,2) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcp MODIFY rgcb number(14,2) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'NYCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'NYCB' AND table_name ='PM_ZCP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcp ADD nycb number(14,2) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcp MODIFY nycb number(14,2) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'ZJCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'ZJCB' AND table_name ='PM_ZCP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcp ADD zjcb number(14,2) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcp MODIFY zjcb number(14,2) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'GLCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'GLCB' AND table_name ='PM_ZCP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcp ADD glcb number(14,2) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE pm_zcp MODIFY glcb number(14,2) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        ''****po_cgd*********'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'PO_CGD'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE po_cgd (djh VARCHAR2(15) NOT NULL,rkrq DATE)" '待完善
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE po_cgd ADD CONSTRAINT PK_PO_CGD primary key (djh,xh)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                '行号xh
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'XH' AND table_name ='PO_CGD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE po_cgd ADD xh NUMBER(6,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column PO_CGD.xh is '行号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE po_cgd MODIFY xh NUMBER(6,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column PO_CGD.xh is '行号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If

                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'RKRQ' AND table_name ='PO_CGD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE po_cgd ADD rkrq DATE"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        ''****po_cgjh*********'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'PO_CGJH'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE po_cgjh (djh VARCHAR2(15) not null,xh NUMBER(4) not null,jhrq DATE,bmdm VARCHAR2(12),bmmc VARCHAR2(30),cpdm VARCHAR2(15),cpmc VARCHAR2(200),sl NUMBER(18,6) default 0,dw VARCHAR2(8),mjsl NUMBER(18,6) default 0,fzsl NUMBER(18,6) default 0,fzdw VARCHAR2(8),jhshrq DATE,jhmemo VARCHAR2(200),srr VARCHAR2(30),srrq DATE default sysdate,shr VARCHAR2(30),shrq DATE,cgsl NUMBER(18,6) default 0,bclosed NUMBER(1) default 0,bcg NUMBER(1) default 0,bsenddingtalk NUMBER(1) default 0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE po_cgjh ADD CONSTRAINT PK_PO_CGJH primary key (djh,xh)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                '采购需求发送钉钉标志
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'BSENDDINGTALK' AND table_name ='PO_CGJH'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE po_cgjh ADD bsenddingtalk number(1,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE po_cgjh MODIFY bsenddingtalk number(1,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        ''****po_fp*********'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'PO_FP'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE po_fp (djh VARCHAR2(15) not null,xh NUMBER(4) not null,fprq DATE,bmdm VARCHAR2(12),bmmc VARCHAR2(30),cpdm VARCHAR2(15),cpmc VARCHAR2(200),sl NUMBER(18,6) default 0,dw VARCHAR2(8),mjsl NUMBER(18,6) default 0,fzsl NUMBER(18,6) default 0,fzdw VARCHAR2(8),jhshrq DATE,jhmemo VARCHAR2(200),srr VARCHAR2(30),srrq DATE default sysdate,shr VARCHAR2(30),shrq DATE,cgsl NUMBER(18,6) default 0,bclosed NUMBER(1) default 0,bcg NUMBER(1) default 0,bsenddingtalk NUMBER(1) default 0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE po_fp ADD CONSTRAINT PK_PO_FP primary key (djh,xh)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                '行号xh
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'XH' AND table_name ='PO_FP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE po_fp ADD xh NUMBER(6,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column PO_FP.xh is '行号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE po_fp MODIFY xh NUMBER(6,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column PO_FP.xh is '行号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '入库单不含税单价
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'YSPZ' AND table_name ='PO_FP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE po_fp ADD yspz VARCHAR2(30)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE po_fp MODIFY yspz VARCHAR2(30)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '入库单不含税单价
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'RKDDJ' AND table_name ='PO_FP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE po_fp ADD rkddj NUMBER(18,6) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE po_fp MODIFY rkddj NUMBER(18,6) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '入库单含税单价
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'RKDHSDJ' AND table_name ='PO_FP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE po_fp ADD rkdhsdj NUMBER(18,6) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE po_fp MODIFY rkdhsdj NUMBER(18,6) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '入库单金额
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'RKDJE' AND table_name ='PO_FP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE po_fp ADD rkdje NUMBER(14,2) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE po_fp MODIFY rkdje NUMBER(14,2) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '入库单税率
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'RKDSHLV' AND table_name ='PO_FP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE po_fp ADD rkdshlv NUMBER(6,2) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE po_fp MODIFY rkdshlv NUMBER(6,2) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '入库单不含税单价
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'RKDSE' AND table_name ='PO_FP'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE po_fp ADD rkdse NUMBER(14,2) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE po_fp MODIFY rkdse NUMBER(14,2) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        ''****po_rkd*********'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'PO_RKD'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE po_rkd (djh VARCHAR2(15) NOT NULL,rkrq DATE,yspz VARCHAR2(20) ,dw VARCHAR2(12),pihao VARCHAR2(30),cksl NUMBER(18,6) default 0,ckje NUMBER(14,2) default 0,cbill_bid VARCHAR2(20))" '待完善
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE po_rkd ADD CONSTRAINT PK_PO_RKD primary key (djh)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                '行号xh
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'XH' AND table_name ='PO_RKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE po_rkd ADD xh NUMBER(6,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column PO_RKD.xh is '行号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE po_rkd MODIFY xh NUMBER(6,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column PO_RKD.xh is '行号'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'rkrq
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'RKRQ' AND table_name ='PO_RKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE po_rkd ADD rkrq DATE"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'YSPZ
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'YSPZ' AND table_name ='PO_RKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE po_rkd ADD yspz VARCHAR2(20)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE po_rkd MODIFY yspz VARCHAR2(20)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'DW
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DW' AND table_name ='PO_RKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE po_rkd ADD dw VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE po_rkd MODIFY dw VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'PIHAO
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'PIHAO' AND table_name ='PO_RKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE po_rkd ADD pihao VARCHAR2(30)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE po_rkd MODIFY pihao VARCHAR2(30)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'cksl
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CKSL' AND table_name ='PO_RKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE po_rkd ADD cksl number(18,6) default 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE po_rkd MODIFY cksl number(18,6) default 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'ckje
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CKJE' AND table_name ='PO_RKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE po_rkd ADD ckje number(14,2) default 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE po_rkd MODIFY ckje number(14,2) default 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'cbill_bid
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CBILL_BID' AND table_name ='PO_RKD'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE po_rkd ADD cbill_bid VARCHAR2(20)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column PO_RKD.cbill_bid is 'NC单据表体主键'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE po_rkd MODIFY cbill_bid VARCHAR2(20)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column PO_RKD.cbill_bid is 'NC单据表体主键'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If

            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '**********************'
        '*****rcdata_001*******'
        ''****rc_costregion****'
        '**********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'RC_COSTREGION'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE rc_costregion (crdm VARCHAR2(12) NOT NULL,crmc VARCHAR2(100),crsm VARCHAR2(12))"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE rc_costregion ADD CONSTRAINT PK_RC_COSTREGION primary key (crdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CRDM' AND table_name ='RC_COSTREGION'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_costregion ADD crdm VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CRMC' AND table_name ='RC_COSTREGION'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_costregion ADD crmc VARCHAR2(100)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_costregion MODIFY crmc VARCHAR2(100)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CRSM' AND table_name ='RC_COSTREGION'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_costregion ADD crsm VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '**********************'
        '*****rcdata_001*******'
        ''****rc_cr_ck****'
        '**********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'RC_CR_CK'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE rc_cr_ck (crdm VARCHAR2(12) NOT NULL,ckdm VARCHAR2(12))"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE rc_cr_ck ADD CONSTRAINT PK_RC_CR_CK primary key (crdm,ckdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CRDM' AND table_name ='RC_CR_CK'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE RC_CR_CK ADD crdm VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CKDM' AND table_name ='RC_CR_CK'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_cr_ck ADD ckdm VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try

        '********************'
        '*****rcdata_001*****'
        ''****rc_ckxx********'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'RC_CKXX'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE rc_ckxx (ckdm VARCHAR2(12) NOT NULL,ckmc VARCHAR2(40),cksm VARCHAR2(12),bscrkcb NUMERIC(1,0),hsfl VARCHAR2(10))"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE rc_ckxx ADD CONSTRAINT PK_RC_CKXX primary key (ckdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                'ckmc
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CKMC' AND table_name ='RC_CKXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_ckxx ADD ckmc VARCHAR2(40)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_ckxx MODIFY ckmc VARCHAR2(40)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'BSCRKCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'BSCRKCB' AND table_name ='RC_CKXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_ckxx ADD bscrkcb NUMERIC(1,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column RC_CKXX.bscrkcb is '生产入库按标准成本计算'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_ckxx MODIFY bscrkcb NUMERIC(1,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column RC_CKXX.bscrkcb is '生产入库按标准成本计算'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '核算分类
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'HSFL' AND table_name ='RC_CKXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_ckxx ADD hsfl VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column RC_CKXX.hsfl is '核算分类'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_ckxx MODIFY hsfl VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                    rcOleDbCommand.CommandText = "comment on column RC_CKXX.hsfl is '核算分类'"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        ''****rc_cplb********'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'RC_CPLB'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE rc_cplb (lbdm VARCHAR2(12) NOT NULL,lbmc VARCHAR2(50),lbsm VARCHAR2(12))"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE rc_cplb ADD CONSTRAINT PK_RC_CPLB primary key (lbdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                'BSCRKCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'LBMC' AND table_name ='RC_CPLB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_cplb ADD lbmc VARCHAR2(50)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_cplb MODIFY lbmc VARCHAR2(50)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        ''****rc_cpxx********'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'RC_CPXX'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE rc_cpxx (cpdm VARCHAR2(15) NOT NULL,dw VARCHAR2(12),bbatch NUMBER(1) default 0,clcb numeric(16,4) DEFAULT 0,rgcb numeric(16,4) DEFAULT 0,nycb numeric(16,4) DEFAULT 0,zjcb numeric(16,4) DEFAULT 0,glcb numeric(16,4) DEFAULT 0)" '待完善
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE rc_cpxx ADD CONSTRAINT PK_RC_CPXX primary key (cpdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                'DW
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DW' AND table_name ='RC_CPXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_cpxx ADD dw VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_cpxx MODIFY dw VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'bbatch
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'BBATCH' AND table_name ='RC_CPXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_cpxx ADD bbatch NUMBER(1) default 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_cpxx MODIFY bbatch NUMBER(1) default 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'CLCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CLCB' AND table_name ='RC_CPXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_cpxx ADD clcb numeric(16,4) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'RGCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'RGCB' AND table_name ='RC_CPXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_cpxx ADD rgcb numeric(16,4) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'NYCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'NYCB' AND table_name ='RC_CPXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_cpxx ADD nycb numeric(16,4) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'ZJCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'ZJCB' AND table_name ='RC_CPXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_cpxx ADD zjcb numeric(16,4) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'GLCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'GLCB' AND table_name ='RC_CPXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_cpxx ADD glcb numeric(16,4) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        ''****rc_csxx******'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'RC_CSXX'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE rc_csxx (csdm VARCHAR2(12) NOT NULL,csmc VARCHAR2(100),cssm VARCHAR2(12),fktj VARCHAR2(20),fkts NUMBER(4,0) default 0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE rc_csxx ADD CONSTRAINT PK_RC_CSXX primary key (csdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CSDM' AND table_name ='RC_CSXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_csxx ADD csdm VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CSMC' AND table_name ='RC_CSXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_csxx ADD csmc VARCHAR2(100)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_csxx MODIFY csmc VARCHAR2(100)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'CSSM' AND table_name ='RC_CSXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_csxx ADD cssm VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'FKTJ' AND table_name ='RC_CSXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_csxx ADD fktj VARCHAR2(20)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'FKTS' AND table_name ='RC_CSXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_csxx ADD fkts NUMBER(4,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '重建索引
                rcOleDbCommand.CommandText = "SELECT * FROM user_constraints WHERE table_name ='RC_CSXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_constraints") IsNot Nothing Then
                    rcDataset.Tables("user_constraints").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_constraints")
                Dim i As Integer
                For i = 0 To rcDataset.Tables("user_constraints").Rows.Count - 1
                    rcOleDbCommand.CommandText = "alter table RC_CSXX drop constraint " & rcDataset.Tables("user_constraints").Rows(i).Item("constraint_name") & " cascade"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Next
                rcOleDbCommand.CommandText = "ALTER TABLE rc_csxx ADD CONSTRAINT PK_RC_CSXX primary key (CSDM)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()

            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        ''****rc_gxxx********'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'RC_GXXX'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE rc_gxxx (gxdm VARCHAR2(12) NOT NULL,gxmc VARCHAR2(50) NOT NULL,gxsm VARCHAR2(12),ydbl_clcb NUMBER(6,4) DEFAULT 0.0), ydbl_rgcb NUMBER(6,4) DEFAULT 0.0, ydbl_nycb NUMBER(6,4) DEFAULT 0.0, ydbl_zjcb NUMBER(6,4) DEFAULT 0.0, ydbl_glcb NUMBER(6,4) DEFAULT 0.0"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE rc_gxxx ADD CONSTRAINT PK_RC_GXXX primary key (gxdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                'YDBL_CLCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'YDBL_CLCB' AND table_name ='RC_GXXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_gxxx ADD ydbl_clcb NUMBER(6,4) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_gxxx MODIFY ydbl_clcb NUMBER(6,4) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'YDBL_RGCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'YDBL_RGCB' AND table_name ='RC_GXXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_gxxx ADD ydbl_rgcb NUMBER(6,4) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_gxxx MODIFY ydbl_rgcb NUMBER(6,4) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'YDBL_NYCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'YDBL_NYCB' AND table_name ='RC_GXXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_gxxx ADD ydbl_nycb NUMBER(6,4) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_gxxx MODIFY ydbl_nycb NUMBER(6,4) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'YDBL_ZJCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'YDBL_ZJCB' AND table_name ='RC_GXXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_gxxx ADD ydbl_zjcb NUMBER(6,4) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_gxxx MODIFY ydbl_zjcb NUMBER(6,4) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'YDBL_GLCB
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'YDBL_GLCB' AND table_name ='RC_GXXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_gxxx ADD ydbl_glcb NUMBER(6,4) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_gxxx MODIFY ydbl_glcb NUMBER(6,4) DEFAULT 0.0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try

        '********************'
        '*****rcdata_001*****'
        ''****rc_jldw********'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'RC_JLDW'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE rc_jldw (jldwdm VARCHAR2(8) NOT NULL,jldwmc VARCHAR2(8),jldwsm VARCHAR2(8),xsws NUMBER(1,0))"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE rc_jldw ADD CONSTRAINT PK_RC_JLDW primary key (jldwdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'JLDWDM' AND table_name ='RC_JLDW'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_jldw ADD jldwdm VARCHAR2(8)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'JLDWMC' AND table_name ='RC_JLDW'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_jldw ADD jldwmc VARCHAR2(8)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'JLDWSM' AND table_name ='RC_JLDW'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_jldw ADD jldwsm VARCHAR2(8)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '扣业务费标志
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'XSWS' AND table_name ='RC_JLDW'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_jldw ADD xsws NUMBER(1,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try

        '********************'
        '*****rcdata_001*****'
        ''****rc_jsfs********'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'RC_JSFS'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE rc_jsfs (jsfsdm VARCHAR2(12) NOT NULL,jsfsmc VARCHAR2(30),jsfssm VARCHAR2(12),bkywf NUMBER(1,0) DEFAULT 0,bgylk NUMBER(1,0) DEFAULT 0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE rc_jsfs ADD CONSTRAINT PK_RC_JSFS primary key (jsfsdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'JSFSDM' AND table_name ='RC_JSFS'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_jsfs ADD jsfsdm VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'JSFSMC' AND table_name ='RC_JSFS'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_jsfs ADD jsfsmc VARCHAR2(30)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'JSFSSM' AND table_name ='RC_JSFS'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_jsfs ADD jsfssm VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '承兑汇票扣业务费标志
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'BKYWF' AND table_name ='RC_JSFS'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_jsfs ADD bkywf NUMBER(1,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '供应链票据扣业务费标志
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'BGYLK' AND table_name ='RC_JSFS'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_jsfs ADD bgylk NUMBER(1,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        ''****rc_kczlfa******'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'RC_KCZLFA'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "create table RC_KCZLFA (fadm VARCHAR2(12) not null,famc VARCHAR2(30),fasm VARCHAR2(12))"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "alter table RC_KCZLFA add constraint PK_KCZLFA primary key (FADM)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                'rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'XSLBDM' AND table_name ='RC_KCZLFA'"
                'rcOleDbCommand.Parameters.Clear()
                'rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                'If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                '    rcDataset.Tables("user_tab_columns").Clear()
                'End If
                'rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                'If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                '    rcOleDbCommand.CommandText = "ALTER TABLE rc_kczlfa ADD xslbdm VARCHAR2(12)"
                '    rcOleDbCommand.Parameters.Clear()
                '    rcOleDbCommand.ExecuteNonQuery()
                'End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        ''****rc_kczlfd******'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'RC_KCZLFD'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "create table RC_KCZLFD (fadm VARCHAR2(12) not null,fdxh VARCHAR2(4) not null,zhangling NUMBER(4) default 0,jitibilv  NUMBER(6,2) default 0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "alter table RC_KCZLFD add constraint PK_KCZLFD primary key (FADM, FDXH)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                'rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'XSLBDM' AND table_name ='RC_KCZLFD'"
                'rcOleDbCommand.Parameters.Clear()
                'rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                'If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                '    rcDataset.Tables("user_tab_columns").Clear()
                'End If
                'rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                'If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                '    rcOleDbCommand.CommandText = "ALTER TABLE rc_kczlfd ADD xslbdm VARCHAR2(12)"
                '    rcOleDbCommand.Parameters.Clear()
                '    rcOleDbCommand.ExecuteNonQuery()
                'End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        ''****rc_khxslb******'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'RC_KHXSLB'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE rc_khxslb (xslbdm VARCHAR2(12) NOT NULL,xslbmc VARCHAR2(30),xslbsm VARCHAR2(12),ywfbl NUMBER(7,3) DEFAULT 0,gjxslb NUMBER(1,0) DEFAULT 0)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE rc_khxslb ADD CONSTRAINT PK_RC_KHXSLB primary key (xslbdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'XSLBDM' AND table_name ='RC_KHXSLB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_khxslb ADD xslbdm VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'XSLBMC' AND table_name ='RC_KHXSLB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_khxslb ADD xslbmc VARCHAR2(30)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'XSLBSM' AND table_name ='RC_KHXSLB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_khxslb ADD xslbsm VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'YWFBL' AND table_name ='RC_KHXSLB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_khxslb ADD ywfbl NUMBER(7,3) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_khxslb MODIFY ywfbl NUMBER(7,3) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'GJXSLB' AND table_name ='RC_KHXSLB'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_khxslb ADD gjxslb NUMBER(1,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        ''****rc_khxx******'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'RC_KHXX'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE rc_khxx (khdm VARCHAR2(15) NOT NULL,khmc VARCHAR2(200),khsm VARCHAR2(12),xslbdm VARCHAR2(12),sktj VARCHAR2(10),djyear NUMBER(4,0) DEFAULT 0),bjsywf NUMBER(1,0) DEFAULT 1,bywfjszz NUMBER(1,0) DEFAULT 1,bguakao NUMBER(1,0) DEFAULT 1"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE rc_khxx ADD CONSTRAINT PK_RC_KHXX primary key (khdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'KHDM' AND table_name ='RC_KHXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_khxx ADD khdm VARCHAR2(15)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_khxx MODIFY khdm VARCHAR2(15)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'KHMC' AND table_name ='RC_KHXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_khxx ADD khmc VARCHAR2(200)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_khxx MODIFY khmc VARCHAR2(200)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'KHSM' AND table_name ='RC_KHXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_khxx ADD khsm VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'XSLBDM' AND table_name ='RC_KHXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_khxx ADD xslbdm VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'SKTJ' AND table_name ='RC_KHXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_khxx ADD sktj VARCHAR2(10)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'DJYEAR' AND table_name ='RC_KHXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_khxx ADD djyear NUMBER(4,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'BJSYWF' AND table_name ='RC_KHXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_khxx ADD bjsywf NUMBER(1,0) DEFAULT 1"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_khxx MODIFY bjsywf NUMBER(1,0) DEFAULT 1"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'BYWFJSZZ' AND table_name ='RC_KHXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_khxx ADD bywfjszz NUMBER(1,0) DEFAULT 1"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_khxx MODIFY bywfjszz NUMBER(1,0) DEFAULT 1"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '挂靠标志
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'BGUAKAO' AND table_name ='RC_KHXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_khxx ADD bguakao NUMBER(1,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_khxx MODIFY bguakao NUMBER(1,0) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '重建索引
                rcOleDbCommand.CommandText = "SELECT * FROM user_constraints WHERE table_name ='RC_KHXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_constraints") IsNot Nothing Then
                    rcDataset.Tables("user_constraints").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_constraints")
                Dim i As Integer
                For i = 0 To rcDataset.Tables("user_constraints").Rows.Count - 1
                    rcOleDbCommand.CommandText = "alter table RC_KHXX drop constraint " & rcDataset.Tables("user_constraints").Rows(i).Item("constraint_name") & " cascade"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Next
                rcOleDbCommand.CommandText = "ALTER TABLE rc_khxx ADD CONSTRAINT PK_RC_KHXX primary key (khdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        ''****rc_khzyxx******'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'RC_KHZYXX'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE rc_khzyxx (zydm VARCHAR2(12) NOT NULL,khdm VARCHAR2(15) NOT NULL,ksperiod VARCHAR2(6),jsperiod VARCHAR2(6),xslbdm VARCHAR2(12))"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE rc_khzyxx ADD CONSTRAINT PK_RC_KHZYXX primary key (zydm,khdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'ZYDM' AND table_name ='RC_KHZYXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_khzyxx ADD zydm VARCHAR2(12) NOT NULL"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_khzyxx MODIFY zydm VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'KHDM' AND table_name ='RC_KHZYXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_khzyxx ADD khdm VARCHAR2(15) NOT NULL"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_khzyxx MODIFY khdm VARCHAR2(15)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'KSPERIOD' AND table_name ='RC_KHZYXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_khzyxx ADD ksperiod VARCHAR2(6)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_khzyxx MODIFY ksperiod VARCHAR2(6)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'JSPERIOD' AND table_name ='RC_KHZYXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_khzyxx ADD jspeeriod VARCHAR2(6)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_khzyxx MODIFY jsperiod VARCHAR2(6)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'XSLBDM' AND table_name ='RC_KHZYXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_khzyxx ADD xslbdm VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_khzyxx MODIFY xslbdm VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '重建索引
                rcOleDbCommand.CommandText = "SELECT * FROM user_constraints WHERE table_name ='RC_KHZYXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_constraints") IsNot Nothing Then
                    rcDataset.Tables("user_constraints").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_constraints")
                Dim i As Integer
                For i = 0 To rcDataset.Tables("user_constraints").Rows.Count - 1
                    rcOleDbCommand.CommandText = "alter table RC_KHZYXX drop constraint " & rcDataset.Tables("user_constraints").Rows(i).Item("constraint_name") & " cascade"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Next
                rcOleDbCommand.CommandText = "ALTER TABLE rc_khzyxx ADD CONSTRAINT PK_RC_KHZYXX primary key (zydm,khdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try

        '********************'
        '*****rcdata_001*****'
        ''****rc_lx**********'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'RC_LX'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE rc_lx (pzlxjc VARCHAR2(12) NOT NULL)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE rc_lx ADD CONSTRAINT PK_RC_LX primary key (pzlxdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'PZLXJC' AND table_name ='RC_LX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_lx ADD pzlxjc VARCHAR2(12) NOT NULL"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_lx MODIFY pzlxjc VARCHAR2(12)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '******rcsystem******'
        '*****rc_para********'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'RC_PARA'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE rc_para (paraid VARCHAR2(75),parastrvalue VARCHAR2(50),paradblvalue NUMBER(18,6))"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE rc_para ADD CONSTRAINT PK_RC_PARA primary key (dwdm,paraid)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'PARAID' AND table_name ='RC_PARA'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_para ADD paraid VARCHAR2(75)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_para MODIFY paraid VARCHAR2(75)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'PARASTRVALUE' AND table_name ='RC_PARA'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_para ADD parastrvalue VARCHAR2(200)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_para MODIFY parastrvalue VARCHAR2(200)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '重建索引
                rcOleDbCommand.CommandText = "SELECT * FROM user_constraints WHERE table_name ='RC_PARA'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_constraints") IsNot Nothing Then
                    rcDataset.Tables("user_constraints").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_constraints")
                Dim i As Integer
                For i = 0 To rcDataset.Tables("user_constraints").Rows.Count - 1
                    rcOleDbCommand.CommandText = "alter table RC_PARA drop constraint " & rcDataset.Tables("user_constraints").Rows(i).Item("constraint_name") & " cascade"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Next
                rcOleDbCommand.CommandText = "ALTER TABLE rc_para ADD CONSTRAINT PK_RC_PARA primary key (dwdm,paraid)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '******rcsystem******'
        '******rc_rps********'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'RC_RPS'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE rc_rps (rpsid VARCHAR2(20),rpsname VARCHAR2(40))"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE rc_rps ADD CONSTRAINT PK_RC_RPS primary key (rpsid)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'RPSID' AND table_name ='RC_RPS'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_rps ADD rpsid VARCHAR2(20)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_rps MODIFY rpsid VARCHAR2(20)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                '重建索引
                rcOleDbCommand.CommandText = "SELECT * FROM user_constraints WHERE table_name ='RC_RPS'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_constraints") IsNot Nothing Then
                    rcDataset.Tables("user_constraints").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_constraints")
                Dim i As Integer
                For i = 0 To rcDataset.Tables("user_constraints").Rows.Count - 1
                    rcOleDbCommand.CommandText = "alter table RC_RPS drop constraint " & rcDataset.Tables("user_constraints").Rows(i).Item("constraint_name") & " cascade"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Next
                rcOleDbCommand.CommandText = "ALTER TABLE rc_rps ADD CONSTRAINT PK_RC_RPS primary key (rpsid)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        ''****rc_wbxx********'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT table_name FROM user_tables WHERE table_name = 'RC_WBXX'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_tables") IsNot Nothing Then
                rcDataset.Tables("user_tables").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_tables")
            If rcDataset.Tables("user_tables").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "CREATE TABLE rc_wbxx (kjnd VARCHAR2(4) NOT NULL,wbdm VARCHAR2(4) NOT NULL,wbmc VARCHAR2(20),wbsm VARCHAR2(4),ywftzbl numeric(10,6) DEFAULT 0)" '待完善
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
                rcOleDbCommand.CommandText = "ALTER TABLE rc_wbxx ADD CONSTRAINT PK_RC_WBXX primary key (kjnd,wbdm)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                'table存在，则检测字段
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'WBMC' AND table_name ='RC_WBXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_wbxx ADD wbmc VARCHAR2(20)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_wbxx MODIFY wbmc VARCHAR2(20)"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
                'table存在，则检测字段
                rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'YWFTZBL' AND table_name ='RC_WBXX'"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                    rcDataset.Tables("user_tab_columns").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_wbxx ADD ywftzbl numeric(10,6) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                Else
                    rcOleDbCommand.CommandText = "ALTER TABLE rc_wbxx MODIFY ywftzbl numeric(10,6) DEFAULT 0"
                    rcOleDbCommand.Parameters.Clear()
                    rcOleDbCommand.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '********************'
        '*****rcdata_001*****'
        ''****v_cppihao********'
        '********************'
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT view_name FROM user_views WHERE view_name = 'V_CPPIHAO'"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataset.Tables("user_views") IsNot Nothing Then
                rcDataset.Tables("user_views").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataset, "user_views")
            If rcDataset.Tables("user_views").Rows.Count <= 0 Then
                'table不存在,则新建
                rcOleDbCommand.CommandText = "create or replace view v_cppihao as select to_char(po_rkd.rkrq,'yyyy-MM-dd') as rkrq,po_rkd.cpdm,po_rkd.csdm,po_rkd.pihao,po_rkd.sl - po_rkd.cksl as sl from po_rkd,rc_cpxx where po_rkd.cpdm = rc_cpxx.cpdm and rc_cpxx.bbatch = 1 and po_rkd.bdelete = 0 and not po_rkd.pihao is null and po_rkd.sl - po_rkd.cksl <> 0 order by po_rkd.cpdm,po_rkd.rkrq,po_rkd.pihao"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.ExecuteNonQuery()
            Else
                ''table存在，则检测字段
                'rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'WBMC' AND table_name ='RC_WBXX'"
                'rcOleDbCommand.Parameters.Clear()
                'rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                'If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                '    rcDataset.Tables("user_tab_columns").Clear()
                'End If
                'rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                'If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                '    rcOleDbCommand.CommandText = "ALTER TABLE rc_wbxx ADD wbmc VARCHAR2(20)"
                '    rcOleDbCommand.Parameters.Clear()
                '    rcOleDbCommand.ExecuteNonQuery()
                'Else
                '    rcOleDbCommand.CommandText = "ALTER TABLE rc_wbxx MODIFY wbmc VARCHAR2(20)"
                '    rcOleDbCommand.Parameters.Clear()
                '    rcOleDbCommand.ExecuteNonQuery()
                'End If
                ''table存在，则检测字段
                'rcOleDbCommand.CommandText = "SELECT * FROM user_tab_columns WHERE column_name = 'YWFTZBL' AND table_name ='RC_WBXX'"
                'rcOleDbCommand.Parameters.Clear()
                'rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                'If rcDataset.Tables("user_tab_columns") IsNot Nothing Then
                '    rcDataset.Tables("user_tab_columns").Clear()
                'End If
                'rcOleDbDataAdpt.Fill(rcDataset, "user_tab_columns")
                'If rcDataset.Tables("user_tab_columns").Rows.Count <= 0 Then
                '    rcOleDbCommand.CommandText = "ALTER TABLE rc_wbxx ADD ywftzbl numeric(10,6) DEFAULT 0"
                '    rcOleDbCommand.Parameters.Clear()
                '    rcOleDbCommand.ExecuteNonQuery()
                'Else
                '    rcOleDbCommand.CommandText = "ALTER TABLE rc_wbxx MODIFY ywftzbl numeric(10,6) DEFAULT 0"
                '    rcOleDbCommand.Parameters.Clear()
                '    rcOleDbCommand.ExecuteNonQuery()
                'End If
            End If
        Catch ex As Exception
            MsgBox("程序错误。" & ex.Message & Chr(13) & rcOleDbCommand.CommandText, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try

        '数据库存储过程

        '*************************'
        '******rcdata_001*********'
        '*****USP3_REDO_CPYEHZ*******'
        '*************************'
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "CREATE OR REPLACE PROCEDURE USP3_REDO_CPYEHZ(paraStrYear  IN VARCHAR2,
                                             paraDateDwrq IN DATE,
                                             paraStrMsg   OUT VARCHAR2) AS
  vDateBegin DATE := GET_INV_BEGIN(paraStrYear, '01');
  vDateEnd   DATE := GET_INV_END(paraStrYear, '12');
BEGIN
  -- 1. 清除当前年份的发生额字段（为重新计算做准备）
  UPDATE inv_cpyeb
     SET idsl = 0, idfzsl = 0, idje = 0
   WHERE kjnd = paraStrYear;

  -- 2. 删除期初和发生额全部为零的冗余记录（此时发生额已被清零）
  DELETE FROM inv_cpyeb
   WHERE kjnd = paraStrYear
     AND qcsl = 0 AND qcfzsl = 0 AND qcje = 0
     AND idsl = 0 AND idfzsl = 0 AND idje = 0;

  -- 3. 处理采购入库单（PO_RKD）：加法
  MERGE INTO inv_cpyeb i
  USING (SELECT cpdm, ckdm,
                COALESCE(SUM(sl), 0.0)   AS sum_sl,
                COALESCE(SUM(fzsl), 0.0) AS sum_fzsl,
                COALESCE(SUM(je), 0.0)   AS sum_je
           FROM po_rkd
          WHERE bdelete = 0
            AND rkrq <= vDateEnd
            AND rkrq >= GREATEST(paraDateDwrq, vDateBegin)
          GROUP BY cpdm, ckdm) p
  ON (i.cpdm = p.cpdm AND i.ckdm = p.ckdm AND i.kjnd = paraStrYear)
  WHEN MATCHED THEN
    UPDATE SET i.idsl   = i.idsl + p.sum_sl,
               i.idfzsl = i.idfzsl + p.sum_fzsl,
               i.idje   = i.idje + p.sum_je
  WHEN NOT MATCHED THEN
    INSERT (kjnd, cpdm, ckdm, qcsl, qcfzsl, qcje, idsl, idfzsl, idje)
    VALUES (paraStrYear, p.cpdm, p.ckdm, 0, 0, 0, p.sum_sl, p.sum_fzsl, p.sum_je);

  -- 4. 处理出库单（INV_CKD）：减法
  MERGE INTO inv_cpyeb i
  USING (SELECT cpdm, ckdm,
                COALESCE(SUM(sl), 0.0)   AS sum_sl,
                COALESCE(SUM(fzsl), 0.0) AS sum_fzsl,
                COALESCE(SUM(je), 0.0)   AS sum_je
           FROM inv_ckd
          WHERE bdelete = 0
            AND ckrq <= vDateEnd
            AND ckrq >= GREATEST(paraDateDwrq, vDateBegin)
          GROUP BY cpdm, ckdm) c
  ON (i.cpdm = c.cpdm AND i.ckdm = c.ckdm AND i.kjnd = paraStrYear)
  WHEN MATCHED THEN
    UPDATE SET i.idsl   = i.idsl - c.sum_sl,
               i.idfzsl = i.idfzsl - c.sum_fzsl,
               i.idje   = i.idje - c.sum_je
  WHEN NOT MATCHED THEN
    INSERT (kjnd, cpdm, ckdm, qcsl, qcfzsl, qcje, idsl, idfzsl, idje)
    VALUES (paraStrYear, c.cpdm, c.ckdm, 0, 0, 0, -c.sum_sl, -c.sum_fzsl, -c.sum_je);

  -- 5. 处理调拨单（INV_DBD）：调入仓库（rckdm）加法，调出仓库（cckdm）减法
  -- 5.1 调入仓库（加法）
  MERGE INTO inv_cpyeb i
  USING (SELECT cpdm, rckdm AS ckdm,
                COALESCE(SUM(sl), 0.0)   AS sum_sl,
                COALESCE(SUM(fzsl), 0.0) AS sum_fzsl,
                COALESCE(SUM(je), 0.0)   AS sum_je
           FROM inv_dbd
          WHERE bdelete = 0
            AND dbrq <= vDateEnd
            AND dbrq >= GREATEST(paraDateDwrq, vDateBegin)
          GROUP BY cpdm, rckdm) d_in
  ON (i.cpdm = d_in.cpdm AND i.ckdm = d_in.ckdm AND i.kjnd = paraStrYear)
  WHEN MATCHED THEN
    UPDATE SET i.idsl   = i.idsl + d_in.sum_sl,
               i.idfzsl = i.idfzsl + d_in.sum_fzsl,
               i.idje   = i.idje + d_in.sum_je
  WHEN NOT MATCHED THEN
    INSERT (kjnd, cpdm, ckdm, qcsl, qcfzsl, qcje, idsl, idfzsl, idje)
    VALUES (paraStrYear, d_in.cpdm, d_in.ckdm, 0, 0, 0, d_in.sum_sl, d_in.sum_fzsl, d_in.sum_je);

  -- 5.2 调出仓库（减法）
  MERGE INTO inv_cpyeb i
  USING (SELECT cpdm, cckdm AS ckdm,
                COALESCE(SUM(sl), 0.0)   AS sum_sl,
                COALESCE(SUM(fzsl), 0.0) AS sum_fzsl,
                COALESCE(SUM(je), 0.0)   AS sum_je
           FROM inv_dbd
          WHERE bdelete = 0
            AND dbrq <= vDateEnd
            AND dbrq >= GREATEST(paraDateDwrq, vDateBegin)
          GROUP BY cpdm, cckdm) d_out
  ON (i.cpdm = d_out.cpdm AND i.ckdm = d_out.ckdm AND i.kjnd = paraStrYear)
  WHEN MATCHED THEN
    UPDATE SET i.idsl   = i.idsl - d_out.sum_sl,
               i.idfzsl = i.idfzsl - d_out.sum_fzsl,
               i.idje   = i.idje - d_out.sum_je
  WHEN NOT MATCHED THEN
    INSERT (kjnd, cpdm, ckdm, qcsl, qcfzsl, qcje, idsl, idfzsl, idje)
    VALUES (paraStrYear, d_out.cpdm, d_out.ckdm, 0, 0, 0, -d_out.sum_sl, -d_out.sum_fzsl, -d_out.sum_je);

  -- 6. 处理其他入库单（INV_RKD）：加法
  MERGE INTO inv_cpyeb i
  USING (SELECT cpdm, ckdm,
                COALESCE(SUM(sl), 0.0)   AS sum_sl,
                COALESCE(SUM(fzsl), 0.0) AS sum_fzsl,
                COALESCE(SUM(je), 0.0)   AS sum_je
           FROM inv_rkd
          WHERE bdelete = 0
            AND rkrq <= vDateEnd
            AND rkrq >= GREATEST(paraDateDwrq, vDateBegin)
          GROUP BY cpdm, ckdm) r
  ON (i.cpdm = r.cpdm AND i.ckdm = r.ckdm AND i.kjnd = paraStrYear)
  WHEN MATCHED THEN
    UPDATE SET i.idsl   = i.idsl + r.sum_sl,
               i.idfzsl = i.idfzsl + r.sum_fzsl,
               i.idje   = i.idje + r.sum_je
  WHEN NOT MATCHED THEN
    INSERT (kjnd, cpdm, ckdm, qcsl, qcfzsl, qcje, idsl, idfzsl, idje)
    VALUES (paraStrYear, r.cpdm, r.ckdm, 0, 0, 0, r.sum_sl, r.sum_fzsl, r.sum_je);

  -- 7. 处理销售出库单（OE_XSD）：减法（使用成本金额 cbje）
  MERGE INTO inv_cpyeb i
  USING (SELECT cpdm, ckdm,
                COALESCE(SUM(sl), 0.0)   AS sum_sl,
                COALESCE(SUM(fzsl), 0.0) AS sum_fzsl,
                COALESCE(SUM(cbje), 0.0) AS sum_cbje
           FROM oe_xsd
          WHERE bdelete = 0
            AND xsrq <= vDateEnd
            AND xsrq >= GREATEST(paraDateDwrq, vDateBegin)
          GROUP BY cpdm, ckdm) x
  ON (i.cpdm = x.cpdm AND i.ckdm = x.ckdm AND i.kjnd = paraStrYear)
  WHEN MATCHED THEN
    UPDATE SET i.idsl   = i.idsl - x.sum_sl,
               i.idfzsl = i.idfzsl - x.sum_fzsl,
               i.idje   = i.idje - x.sum_cbje
  WHEN NOT MATCHED THEN
    INSERT (kjnd, cpdm, ckdm, qcsl, qcfzsl, qcje, idsl, idfzsl, idje)
    VALUES (paraStrYear, x.cpdm, x.ckdm, 0, 0, 0, -x.sum_sl, -x.sum_fzsl, -x.sum_cbje);

  COMMIT;
  paraStrMsg := '执行成功';
EXCEPTION
  WHEN OTHERS THEN
    ROLLBACK;
    paraStrMsg := '执行SQL语句错误，发生在USP3_REDO_CPYEHZ：' || SQLERRM;
END USP3_REDO_CPYEHZ;"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '*************************'
        '******rcdata_001*********'
        '*****USP3_REDO_FCSPYEHZ*******'
        '*************************'
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '2020年3月收款单增加结算方式的字段
            rcOleDbCommand.CommandText = "CREATE OR REPLACE PROCEDURE USP3_REDO_FCSPYEHZ(paraStrYear  IN VARCHAR2,
                                               paraDateDwrq IN DATE,
                                               paraStrMsg   OUT VARCHAR2) AS
  vDateBegin DATE := GET_INV_BEGIN(paraStrYear, '01');
  vDateEnd   DATE := GET_INV_END(paraStrYear, '12');
BEGIN
  -- 1. 清除当前年份的发生额字段（为重新计算做准备）
  UPDATE inv_fcspyeb
     SET idsl = 0, idfzsl = 0, idje = 0
   WHERE kjnd = paraStrYear;

  -- 2. 处理销售出库单（oe_xsd）：累加发生额，并补全缺失的产品-部门-客户组合
  MERGE INTO inv_fcspyeb i
  USING (SELECT cpdm,
                bmdm,
                khdm,
                COALESCE(SUM(sl), 0.0) AS sum_sl,
                COALESCE(SUM(fzsl), 0.0) AS sum_fzsl,
                COALESCE(SUM(cbje), 0.0) AS sum_cbje
           FROM oe_xsd
          WHERE bdelete = 0
            AND je <> 0
            AND xsrq <= vDateEnd
            AND xsrq >= GREATEST(paraDateDwrq, vDateBegin)
          GROUP BY cpdm, bmdm, khdm) o
  ON (i.cpdm = o.cpdm AND i.bmdm = o.bmdm AND i.khdm = o.khdm AND i.kjnd = paraStrYear)
  WHEN MATCHED THEN
    UPDATE
       SET i.idsl   = i.idsl + o.sum_sl,
           i.idfzsl = i.idfzsl + o.sum_fzsl,
           i.idje   = i.idje + o.sum_cbje
  WHEN NOT MATCHED THEN
    INSERT
      (kjnd, cpdm, bmdm, khdm, qcsl, qcfzsl, qcje, idsl, idfzsl, idje)
    VALUES
      (paraStrYear,
       o.cpdm,
       o.bmdm,
       o.khdm,
       0,
       0,
       0,
       o.sum_sl,
       o.sum_fzsl,
       o.sum_cbje);

  -- 3. 处理发票（oe_fp）：扣减发生额，并补全缺失的产品-部门-客户组合（注意客户字段为shkhdm）
  MERGE INTO inv_fcspyeb i
  USING (SELECT cpdm,
                bmdm,
                shkhdm AS khdm,
                COALESCE(SUM(sl), 0.0) AS sum_sl,
                COALESCE(SUM(fzsl), 0.0) AS sum_fzsl,
                COALESCE(SUM(cbje), 0.0) AS sum_cbje
           FROM oe_fp
          WHERE bdelete = 0
            AND fprq <= vDateEnd
            AND fprq >= GREATEST(paraDateDwrq, vDateBegin)
          GROUP BY cpdm, bmdm, shkhdm) o
  ON (i.cpdm = o.cpdm AND i.bmdm = o.bmdm AND i.khdm = o.khdm AND i.kjnd = paraStrYear)
  WHEN MATCHED THEN
    UPDATE
       SET i.idsl   = i.idsl - o.sum_sl,
           i.idfzsl = i.idfzsl - o.sum_fzsl,
           i.idje   = i.idje - o.sum_cbje
  WHEN NOT MATCHED THEN
    INSERT
      (kjnd, cpdm, bmdm, khdm, qcsl, qcfzsl, qcje, idsl, idfzsl, idje)
    VALUES
      (paraStrYear,
       o.cpdm,
       o.bmdm,
       o.khdm,
       0,
       0,
       0,
       -o.sum_sl,
       -o.sum_fzsl,
       -o.sum_cbje);

  -- 4. 删除期初和发生额全部为零的冗余记录
  DELETE FROM inv_fcspyeb
   WHERE kjnd = paraStrYear
     AND qcsl = 0
     AND qcfzsl = 0
     AND qcje = 0
     AND idsl = 0
     AND idfzsl = 0
     AND idje = 0;

  COMMIT;
  --paraStrMsg := '执行成功';
EXCEPTION
  WHEN OTHERS THEN
    ROLLBACK;
    paraStrMsg := '执行SQL语句错误，发生在USP3_REDO_FCSPYEHZ：' || SQLERRM;
END USP3_REDO_FCSPYEHZ;"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try

        '*************************'
        '******rcdata_001*********'
        '*****USP3_REDO_KMYEHZ*******'
        '*************************'
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '2020年3月收款单增加结算方式的字段
            rcOleDbCommand.CommandText = "CREATE OR REPLACE PROCEDURE USP3_REDO_KMYEHZ" &
                "  (" &
                "  ParaStrYear        IN VARCHAR2" &
                "  , paraStrMsg       OUT VARCHAR2" &
                "  )AS " &
                "vStrStatement VARCHAR(1000):='';" &
                "vStrPeriod CHAR(6):='';" &
                "CURSOR vCursorRc_yj IS SELECT ny FROM rc_yj WHERE substr(ny,1,4) = ParaStrYear;" &
                "BEGIN" &
                "     DELETE FROM gl_kmyeb WHERE kjnd = ParaStrYear AND ncsl = 0 ANd ncwb = 0 AND ncje = 0;" &
                "     INSERT INTO gl_kmyeb (kjnd,kmdm,wbdm,bmdm,zydm,xmdm,khdm,csdm,jxzh,yhzh) SELECT SUBSTR(cperiod,1,4) AS kjnd,NVL(kmdm,'~'),NVL(bz,'~') AS wbdm,NVL(bmdm,'~'),NVL(zydm,'~'),NVL(xmdm,'~'),NVL(khdm,'~'),NVL(csdm,'~'),NVL(jxzh,'~'),NVL(yhzh,'~') FROM gl_pz WHERE SUBSTR(cperiod,1,4) = ParaStrYear AND NOT EXISTS (SELECT 1 FROM gl_kmyeb aa WHERE aa.kjnd = ParaStrYear AND aa.kmdm = NVL(gl_pz.kmdm,'~') AND aa.wbdm = NVL(gl_pz.bz,'~') AND aa.bmdm = NVL(gl_pz.bmdm,'~') AND aa.zydm = NVL(gl_pz.zydm,'~') AND aa.xmdm = NVL(gl_pz.xmdm,'~') AND aa.khdm = NVL(gl_pz.khdm,'~') AND aa.csdm = NVL(gl_pz.csdm,'~') AND aa.jxzh = NVL(gl_pz.jxzh,'~') AND aa.yhzh = NVL(gl_pz.yhzh,'~')) GROUP BY SUBSTR(cperiod,1,4),kmdm,bz,bmdm,zydm,xmdm,khdm,csdm,jxzh,yhzh;" &
                "     FOR vRc_yj IN vCursorRc_yj LOOP" &
                "         vStrPeriod := vRc_yj.ny;" &
                "         vStrStatement := 'UPDATE gl_kmyeb SET jfsl' || SUBSTR(vStrPeriod,5,2) || ' = 0, jfwb' ||  SUBSTR(vStrPeriod,5,2) || ' = 0, jfje' || SUBSTR(vStrPeriod,5,2)|| ' = 0,dfsl' || SUBSTR(vStrPeriod,5,2) || ' = 0, dfwb' ||  SUBSTR(vStrPeriod,5,2) || ' = 0, dfje' || SUBSTR(vStrPeriod,5,2)|| ' = 0 WHERE kjnd =''' || SUBSTR(vStrPeriod,1,4) || '''';" &
                "         EXECUTE IMMEDIATE vStrStatement;" &
                "         vStrStatement := 'MERGE INTO gl_kmyeb " &
                "             USING (SELECT A.kmdm, A.bz AS wbdm, A.bmdm, A.zydm, A.xmdm,A.khdm,A.csdm,A.yhzh,A.jxzh,NVL(SUM(sl),0.0) AS jfsl,NVL(SUM(wb),0.0) AS jfwb,NVL(SUM(je),0.0) AS jfje FROM gl_pz A WHERE jd = ' || chr(39) || '借' || chr(39) || ' AND cperiod =''' || vStrPeriod || ''' GROUP BY A.jxzh, A.yhzh, A.csdm, A.khdm, A.xmdm, A.zydm, A.bmdm, A.bz, A.kmdm) S " &
                "             ON (gl_kmyeb.jxzh = S.jxzh AND gl_kmyeb.yhzh = S.yhzh AND gl_kmyeb.csdm = S.csdm AND gl_kmyeb.khdm = S.khdm AND gl_kmyeb.xmdm = S.xmdm AND gl_kmyeb.zydm = S.zydm AND gl_kmyeb.bmdm = S.bmdm AND gl_kmyeb.wbdm = S.wbdm AND gl_kmyeb.kmdm = S.kmdm AND gl_kmyeb.kjnd = ''' || ParaStrYear || ''') " &
                "             WHEN MATCHED THEN UPDATE SET gl_kmyeb.jfsl' || SUBSTR(vStrPeriod,5,2) || '= S.jfsl,gl_kmyeb.jfwb' || SUBSTR(vStrPeriod,5,2) || '= S.jfwb,gl_kmyeb.jfje' || SUBSTR(vStrPeriod,5,2) || '= S.jfje';" &
                "         EXECUTE IMMEDIATE vStrStatement;" &
                "         vStrStatement := 'MERGE INTO gl_kmyeb " &
                "             USING (SELECT A.kmdm, A.bz AS wbdm, A.bmdm, A.zydm, A.xmdm,A.khdm,A.csdm,A.yhzh,A.jxzh,NVL(SUM(sl),0.0) AS dfsl,NVL(SUM(wb),0.0) AS dfwb,NVL(SUM(je),0.0) AS dfje FROM gl_pz A WHERE jd = ' || chr(39) || '贷' || chr(39) || ' AND cperiod =''' || vStrPeriod || ''' GROUP BY A.jxzh, A.yhzh, A.csdm, A.khdm, A.xmdm, A.zydm, A.bmdm, A.bz, A.kmdm) S " &
                "             ON (gl_kmyeb.jxzh = S.jxzh AND gl_kmyeb.yhzh = S.yhzh AND gl_kmyeb.csdm = S.csdm AND gl_kmyeb.khdm = S.khdm AND gl_kmyeb.xmdm = S.xmdm AND gl_kmyeb.zydm = S.zydm AND gl_kmyeb.bmdm = S.bmdm AND gl_kmyeb.wbdm = S.wbdm AND gl_kmyeb.kmdm = S.kmdm AND gl_kmyeb.kjnd = ''' ||  ParaStrYear || ''') " &
                "             WHEN MATCHED THEN UPDATE SET gl_kmyeb.dfsl' || SUBSTR(vStrPeriod,5,2) || '= S.dfsl,gl_kmyeb.dfwb' || SUBSTR(vStrPeriod,5,2) || '= S.dfwb,gl_kmyeb.dfje' || SUBSTR(vStrPeriod,5,2) || '= S.dfje';" &
                "         EXECUTE IMMEDIATE vStrStatement;" &
                "     END LOOP;" &
                "     COMMIT;" &
                "     EXCEPTION" &
                "         WHEN OTHERS THEN" &
                "         ROLLBACK;" &
                "         paraStrMsg := '执行SQL语句错误，发生在USP3_REDO_KMYEHZ' || sqlerrm;" &
                "END USP3_REDO_KMYEHZ;"
            '"         vStrStatement := 'MERGE INTO gl_kmyeb " &
            '"             USING (SELECT A.kmdm, A.bmdm, A.zydm, A.xmdm,A.khdm,A.csdm,A.yhzh,A.jxzh,NVL(SUM(wb),0.0) AS jfwb FROM gl_pz A WHERE jd = ' || chr(39) || '借' || chr(39) || ' AND cperiod =' || vStrPeriod || ' GROUP BY A.kmdm, A.bmdm, A.zydm, A.xmdm,A.khdm,A.csdm,A.yhzh,A.jxzh) S " &
            '"             ON (gl_kmyeb.kmdm = S.kmdm AND gl_kmyeb.bmdm = S.bmdm AND gl_kmyeb.zydm = S.zydm AND gl_kmyeb.xmdm = S.xmdm AND gl_kmyeb.khdm = S.khdm AND gl_kmyeb.csdm = S.csdm AND gl_kmyeb.yhzh = S.yhzh AND gl_kmyeb.jxzh = S.jxzh AND gl_kmyeb.kjnd = ' ||  ParaStrYear || ') " &
            '"             WHEN MATCHED THEN UPDATE SET gl_kmyeb.jfwb' || SUBSTR(vStrPeriod,5,2) || '= S.jfwb';" &
            '"         EXECUTE IMMEDIATE vStrStatement;" &
            '"         vStrStatement := 'MERGE INTO gl_kmyeb " &
            '"             USING (SELECT A.kmdm, A.bmdm, A.zydm, A.xmdm,A.khdm,A.csdm,A.yhzh,A.jxzh,NVL(SUM(je),0.0) AS jfje FROM gl_pz A WHERE jd = ' || chr(39) || '借' || chr(39) || ' AND cperiod =' || vStrPeriod || ' GROUP BY A.kmdm, A.bmdm, A.zydm, A.xmdm,A.khdm,A.csdm,A.yhzh,A.jxzh) S " &
            '"             ON (gl_kmyeb.kmdm = S.kmdm AND gl_kmyeb.bmdm = S.bmdm AND gl_kmyeb.zydm = S.zydm AND gl_kmyeb.xmdm = S.xmdm AND gl_kmyeb.khdm = S.khdm AND gl_kmyeb.csdm = S.csdm AND gl_kmyeb.yhzh = S.yhzh AND gl_kmyeb.jxzh = S.jxzh AND gl_kmyeb.kjnd = ' ||  ParaStrYear || ') " &
            '"             WHEN MATCHED THEN UPDATE SET gl_kmyeb.jfje' || SUBSTR(vStrPeriod,5,2) || '= S.jfje';" &
            '"         EXECUTE IMMEDIATE vStrStatement;" &
            '"         vStrStatement := 'MERGE INTO gl_kmyeb " &
            '"             USING (SELECT A.kmdm, A.bmdm, A.zydm, A.xmdm,A.khdm,A.csdm,A.yhzh,A.jxzh,NVL(SUM(wb),0.0) AS dfwb FROM gl_pz A WHERE jd = ' || chr(39) || '贷' || chr(39) || ' AND cperiod =' || vStrPeriod || ' GROUP BY A.kmdm, A.bmdm, A.zydm, A.xmdm,A.khdm,A.csdm,A.yhzh,A.jxzh) S " &
            '"             ON (gl_kmyeb.kmdm = S.kmdm AND gl_kmyeb.bmdm = S.bmdm AND gl_kmyeb.zydm = S.zydm AND gl_kmyeb.xmdm = S.xmdm AND gl_kmyeb.khdm = S.khdm AND gl_kmyeb.csdm = S.csdm AND gl_kmyeb.yhzh = S.yhzh AND gl_kmyeb.jxzh = S.jxzh AND gl_kmyeb.kjnd = ' ||  ParaStrYear || ') " &
            '"             WHEN MATCHED THEN UPDATE SET gl_kmyeb.dfwb' || SUBSTR(vStrPeriod,5,2) || '= S.dfwb';" &
            '"         EXECUTE IMMEDIATE vStrStatement;" &
            '"         vStrStatement := 'MERGE INTO gl_kmyeb " &
            '"             USING (SELECT A.kmdm, A.bmdm, A.zydm, A.xmdm,A.khdm,A.csdm,A.yhzh,A.jxzh,NVL(SUM(je),0.0) AS dfje FROM gl_pz A WHERE jd = ' || chr(39) || '贷' || chr(39) || ' AND cperiod =' || vStrPeriod || ' GROUP BY A.kmdm, A.bmdm, A.zydm, A.xmdm,A.khdm,A.csdm,A.yhzh,A.jxzh) S " &
            '"             ON (gl_kmyeb.kmdm = S.kmdm AND gl_kmyeb.bmdm = S.bmdm AND gl_kmyeb.zydm = S.zydm AND gl_kmyeb.xmdm = S.xmdm AND gl_kmyeb.khdm = S.khdm AND gl_kmyeb.csdm = S.csdm AND gl_kmyeb.yhzh = S.yhzh AND gl_kmyeb.jxzh = S.jxzh AND gl_kmyeb.kjnd = ' ||  ParaStrYear || ') " &
            '"             WHEN MATCHED THEN UPDATE SET gl_kmyeb.dfje' || SUBSTR(vStrPeriod,5,2) || '= S.dfje';" &
            '"         EXECUTE IMMEDIATE vStrStatement;" &

            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '*************************'
        '******rcdata_001*********'
        '*****USP3_SAVE_AR_SKD*******'
        '*************************'
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '2020年3月收款单增加结算方式的字段
            rcOleDbCommand.CommandText = "CREATE OR REPLACE PROCEDURE USP3_SAVE_AR_SKD" &
                "   ( paraIntIsAdding	    IN INTEGER" &
                "   , paraStrDjh 		    IN OUT VARCHAR2" &
                "   , paraDateSkrq		    IN DATE" &
                "   , ParaStrKhdm 		    IN VARCHAR2" &
                "   , paraStrKhmc 		    IN VARCHAR2" &
                "   , paraStrJsfsdm 	    IN VARCHAR2" &
                "   , paraStrJsfsmc 	    IN VARCHAR2" &
                "   , paraStrKmdm 		    IN VARCHAR2" &
                "   , paraStrKmmc 		    IN VARCHAR2" &
                "   , paraStrYspz 		    IN VARCHAR2" &
                "   , paraDblJe		        IN NUMERIC" &
                "   , paraDblXsje		    IN NUMERIC" &
                "   , paraStrSkmemo		    IN VARCHAR2" &
                "   , paraStrUserDspName	IN VARCHAR2" &
                "   , paraStrMsg		    OUT VARCHAR2" &
                "   ) AS " &
                "vStrPzlxdm CHAR(4):='';" &
                "vStrYear CHAR(4):='';" &
                "vStrMonth CHAR(2):='';" &
                "vIntPzno INTEGER(5):=0;" &
                "vStrStatement VARCHAR(200):='';" &
                "vIntCount INTEGER(4) := 0;" &
                "CURSOR vCursorAr_skd IS SELECT ar_skd.djh,ar_skd.khdm,COALESCE(ar_skd.je,0.0) AS je FROM ar_skd WHERE djh = paraStrDjh;" &
                "BEGIN" &
                "   vStrPzlxdm := SUBSTR(paraStrDjh,1,4);" &
                "   vStrYear := SUBSTR(paraStrDjh,5,4);" &
                "   vStrMonth := SUBSTR(paraStrDjh,9,2);" &
                "   vIntPzno := SUBSTR(paraStrDjh,11,5);" &
                "   If paraIntIsAdding = 1 Then" &
                "       vStrStatement := 'SELECT pzno' || vStrMonth || ' FROM rc_lx WHERE pzlxdm =' || chr(39) || vStrPzlxdm || chr(39) || ' AND kjnd = ' || chr(39) || vStrYear || chr(39) || ' FOR UPDATE';" &
                "       EXECUTE IMMEDIATE vStrStatement INTO vIntPzno;" &
                "       vStrStatement := 'SELECT ' || vStrPzlxdm || vStrYear || vStrMonth || '.NEXTVAL FROM dual';" &
                "       EXECUTE IMMEDIATE vStrStatement INTO vIntPzno;" &
                "       vStrStatement := 'UPDATE rc_lx SET pzno' || vStrMonth ||' = ' || vIntPzno || ' WHERE pzlxdm = ' || chr(39) || vStrPzlxdm || chr(39) || ' AND kjnd = ' || chr(39) || vStrYear || chr(39) ;" &
                "       EXECUTE IMMEDIATE vStrStatement;" &
                "       paraStrDjh :=  vStrPzlxdm || vStrYear || vStrMonth || LPAD(vIntPzno,5,'0');" &
                "   Else" &
                "       FOR vAr_skd IN vCursorAr_skd LOOP" &
                "           UPDATE ar_khyeb SET idje = idje + vAr_skd.je WHERE kjnd = vStrYear AND khdm = vAr_skd.khdm;" &
                "       END LOOP;" &
                "       DELETE FROM ar_skd WHERE djh = paraStrDjh;" &
                "   END IF;" &
                "   INSERT INTO ar_skd (djh,skrq,khdm,khmc,jsfsdm,jsfsmc,kmdm,kmmc,yspz,je,xsje,skmemo,srr) VALUES (paraStrDjh,paraDateSkrq,ParaStrKhdm,paraStrKhmc,paraStrJsfsdm,paraStrJsfsmc,paraStrKmdm,paraStrKmmc,paraStrYspz,paraDblJe,paraDblXsje,paraStrSkmemo,paraStrUserDspName);" &
                "   SELECT COUNT(1) INTO vIntCount FROM ar_khyeb WHERE kjnd = vStrYear AND khdm = ParaStrKhdm;" &
                "   IF vIntCount = 0 THEN" &
                "       INSERT INTO ar_khyeb (kjnd,khdm,khmc,qcje,idje) VALUES (vStrYear,ParaStrKhdm,paraStrKhmc,0.0,0.0);" &
                "   END IF;" &
                "   UPDATE ar_khyeb SET idje = idje - paraDblJe WHERE kjnd = vStrYear AND khdm = ParaStrKhdm;" &
                "   Exception" &
                "       WHEN OTHERS THEN ROLLBACK;" &
                "       paraStrMsg := '执行SQL语句错误，发生在USP3_SAVE_AR_SKD' || sqlerrm;" &
                "END USP3_SAVE_AR_SKD;"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '*************************'
        '******rcdata_001*********'
        '*****USP3_SAVE_GL_PZ*******'
        '*************************'
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "CREATE OR REPLACE PROCEDURE USP3_SAVE_GL_PZ" &
                "   ( paraIntIsAdding         IN INTEGER" &
                "   , paraStrDjh 		          IN OUT VARCHAR2" &
                "   , paraIntXh 		          IN INTEGER" &
                "   , paraBlnDelete		        IN NUMERIC" &
                "   , paraDatePzrq		        IN DATE" &
                "   , paraIntFjzs	            IN NUMERIC" &
                "   , paraStrJd 		          IN VARCHAR2" &
                "   , paraStrZy 		          IN VARCHAR2" &
                "   , paraStrKmdm 		        IN VARCHAR2" &
                "   , paraStrKmmc 		        IN VARCHAR2" &
                "   , ParaStrBmdm 		        IN VARCHAR2" &
                "   , paraStrBmmc 		        IN VARCHAR2" &
                "   , paraStrZydm 		        IN VARCHAR2" &
                "   , paraStrZymc 		        IN VARCHAR2" &
                "   , paraStrXmdm 		        IN VARCHAR2" &
                "   , paraStrXmmc 		        IN VARCHAR2" &
                "   , ParaStrKhdm 		        IN VARCHAR2" &
                "   , paraStrKhmc 		        IN VARCHAR2" &
                "   , paraStrCsdm 		        IN VARCHAR2" &
                "   , paraStrCsmc 		        IN VARCHAR2" &
                "   , paraStrYhzh 		        IN VARCHAR2" &
                "   , paraStrJxzh 		        IN VARCHAR2" &
                "   , paraStrDwmc 		        IN VARCHAR2" &
                "   , paraStrDfkm		          IN VARCHAR2" &
                "   , paraStrDw 		          IN VARCHAR2" &
                "   , paraDblSl		            IN NUMERIC" &
                "   , paraDblDj		            IN NUMERIC" &
                "   , paraStrBz 		          IN VARCHAR2" &
                "   , paraDblWb		            IN NUMERIC" &
                "   , paraDblHl		            IN NUMERIC" &
                "   , paraDblJe		            IN NUMERIC" &
                "   , paraStrYspz 		        IN VARCHAR2" &
                "   , paraStrJsr		          IN VARCHAR2" &
                "   , paraDateWldqr		        IN DATE" &
                "   , paraStrUserDspName	    IN VARCHAR2" &
                "   , paraStrMsg		          OUT VARCHAR2" &
                "   ) AS " &
                "vStrPzlxdm CHAR(4):='';" &
                "vStrYear CHAR(4):='';" &
                "vStrMonth CHAR(2):='';" &
                "vIntPzno INTEGER(5):=0;" &
                "vStrStatement VARCHAR(500):='';" &
                "vIntCount INTEGER(4) := 0;" &
                "CURSOR vCursorGl_pz IS SELECT gl_pz.djh,gl_pz.bdelete,gl_pz.jd,NVL(gl_pz.kmdm,'~') AS kmdm,NVL(gl_pz.bmdm,'~') AS bmdm,NVL(gl_pz.zydm,'~') AS zydm,NVL(gl_pz.xmdm,'~') AS xmdm,NVL(gl_pz.khdm,'~') AS khdm,NVL(gl_pz.csdm,'~') AS csdm,NVL(gl_pz.yhzh,'~') AS yhzh,NVL(gl_pz.jxzh,'~') AS jxzh,gl_pz.xh,NVL(gl_pz.sl,0.0) AS sl,NVL(gl_pz.wb,0.0) AS wb,NVL(gl_pz.je,0.0) AS je FROM gl_pz WHERE djh = paraStrDjh ORDER BY xh;" &
                "BEGIN" &
                "   vStrPzlxdm := SUBSTR(paraStrDjh,1,4);" &
                "   vStrYear := SUBSTR(paraStrDjh,5,4);" &
                "   vStrMonth := SUBSTR(paraStrDjh,9,2);" &
                "   vIntPzno := SUBSTR(paraStrDjh,11,5);" &
                "   If paraIntXh = 1 Then" &
                "       If paraIntIsAdding = 1 Then" &
                "           vStrStatement := 'SELECT ' || vStrPzlxdm || vStrYear || vStrMonth || '.NEXTVAL FROM dual';" &
                "           EXECUTE IMMEDIATE vStrStatement INTO vIntPzno;" &
                "           /*更新表rc_lx*/" &
                "           vStrStatement := 'UPDATE rc_lx SET pzno' || vStrMonth ||' = ' || vIntPzno || ' WHERE pzlxdm = ' || chr(39) || vStrPzlxdm || chr(39) || ' AND kjnd = ' || chr(39) || vStrYear || chr(39) ;" &
                "           EXECUTE IMMEDIATE vStrStatement;" &
                "           paraStrDjh :=  vStrPzlxdm || vStrYear || vStrMonth || LPAD(vIntPzno,5,'0');" &
                "       Else" &
                "           /*对已保存的凭证负项处理*/" &
                "           FOR vGl_pz IN vCursorGl_pz LOOP" &
                "               If vGl_pz.bdelete <> 1 Then" &
                "                   IF vGl_pz.jd = '借' THEN" &
                "                       vStrStatement := 'UPDATE gl_kmyeb SET jfsl' || vStrMonth || ' = jfsl' || vStrMonth || ' - ' || vGl_pz.sl || ',jfwb' || vStrMonth || ' = jfwb' || vStrMonth || ' - ' || vGl_pz.wb || ' ,jfje' || vStrMonth || ' = jfje' || vStrMonth || ' - ' || vGl_pz.je || ' WHERE kjnd = ''' || vStrYear || ''' AND jxzh = ''' || vGl_pz.jxzh || ''' AND yhzh = ''' || vGl_pz.yhzh || ''' AND csdm = ''' || vGl_pz.csdm || ''' AND khdm = ''' || vGl_pz.khdm || ''' AND xmdm = ''' || vGl_pz.xmdm || ''' AND zydm = ''' || vGl_pz.zydm || ''' AND bmdm = ''' || vGl_pz.bmdm || ''' AND kmdm = ''' || vGl_pz.kmdm || '''';" &
                "                       EXECUTE IMMEDIATE vStrStatement;" &
                "                   Else" &
                "                       vStrStatement := 'UPDATE gl_kmyeb SET dfsl' || vStrMonth || ' = dfsl' || vStrMonth || ' - ' || vGl_pz.sl || ',dfwb' || vStrMonth || ' = dfwb' || vStrMonth || ' - ' || vGl_pz.wb || ' ,dfje' || vStrMonth || ' = dfje' || vStrMonth || ' - ' || vGl_pz.je || ' WHERE kjnd = ''' || vStrYear || ''' AND jxzh = ''' || vGl_pz.jxzh || ''' AND yhzh = ''' || vGl_pz.yhzh || ''' AND csdm = ''' || vGl_pz.csdm || ''' AND khdm = ''' || vGl_pz.khdm || ''' AND xmdm = ''' || vGl_pz.xmdm || ''' AND zydm = ''' || vGl_pz.zydm || ''' AND bmdm = ''' || vGl_pz.bmdm || ''' AND kmdm = ''' || vGl_pz.kmdm || '''';" &
                "                       EXECUTE IMMEDIATE vStrStatement;" &
                "                   END IF;" &
                "               END IF;" &
                "           END LOOP;" &
                "           DELETE FROM gl_pz WHERE djh = paraStrDjh;" &
                "       END IF;" &
                "   END IF;" &
                "   If paraBlnDelete <> 1 Then" &
                "       /*更新gl_kmyeb表*/" &
                "       SELECT COUNT(1) INTO vIntCount FROM gl_kmyeb WHERE kjnd = vStrYear AND kmdm = NVL(paraStrKmdm,'~') AND bmdm = NVL(ParaStrBmdm,'~') AND zydm = NVL(paraStrZydm,'~') AND xmdm = NVL(paraStrXmdm,'~') AND khdm = NVL(ParaStrKhdm,'~') AND csdm = NVL(paraStrCsdm,'~') AND yhzh = NVL(paraStrYhzh,'~') AND jxzh = NVL(paraStrJxzh,'~');" &
                "       If vIntCount = 0 Then" &
                "           INSERT INTO gl_kmyeb (kjnd,kmdm,wbdm,bmdm,zydm,xmdm,khdm,csdm,yhzh,jxzh,jd,ncsl,ncwb,ncje) VALUES (vStrYear,NVL(paraStrKmdm,'~'),NVL(paraStrBz,'~'),NVL(ParaStrBmdm,'~'),NVL(paraStrZydm,'~'),NVL(paraStrXmdm,'~'),NVL(ParaStrKhdm,'~'),NVL(paraStrCsdm,'~'),NVL(paraStrYhzh,'~'),NVL(paraStrJxzh,'~'),'平',0.0,0.0,0.0);" &
                "       END IF;" &
                "       IF paraStrJd = '借' THEN" &
                "           vStrStatement := 'UPDATE gl_kmyeb SET jfsl' || vStrMonth || ' = jfsl' || vStrMonth || ' + ' || paraDblSl || ',jfwb' || vStrMonth || ' = jfwb' || vStrMonth || ' + ' || paraDblWb || ' ,jfje' || vStrMonth || ' = jfje' || vStrMonth || ' + ' || paraDblJe || ' WHERE kjnd = ''' || vStrYear || ''' AND jxzh = ''' || NVL(paraStrJxzh,'~') || ''' AND yhzh = ''' || NVL(paraStrYhzh,'~') || ''' AND csdm = ''' || NVL(paraStrCsdm,'~') || ''' AND khdm = ''' || NVL(ParaStrKhdm,'~') || ''' AND xmdm = ''' || NVL(paraStrXmdm,'~') || ''' AND zydm = ''' || NVL(paraStrZydm,'~') || ''' AND bmdm = ''' || NVL(ParaStrBmdm,'~') || ''' AND kmdm = ''' || NVL(paraStrKmdm,'~') || '''';" &
                "           EXECUTE IMMEDIATE vStrStatement;" &
                "       Else" &
                "           vStrStatement := 'UPDATE gl_kmyeb SET dfsl' || vStrMonth || ' = dfsl' || vStrMonth || ' + ' || paraDblSl || ',dfwb' || vStrMonth || ' = dfwb' || vStrMonth || ' + ' || paraDblWb || ' ,dfje' || vStrMonth || ' = dfje' || vStrMonth || ' + ' || paraDblJe || ' WHERE kjnd = ''' || vStrYear || ''' AND jxzh = ''' || NVL(paraStrJxzh,'~') || ''' AND yhzh = ''' || NVL(paraStrYhzh,'~') || ''' AND csdm = ''' || NVL(paraStrCsdm,'~') || ''' AND khdm = ''' || NVL(ParaStrKhdm,'~') || ''' AND xmdm = ''' || NVL(paraStrXmdm,'~') || ''' AND zydm = ''' || NVL(paraStrZydm,'~') || ''' AND bmdm = ''' || NVL(ParaStrBmdm,'~') || ''' AND kmdm = ''' || NVL(paraStrKmdm,'~') || '''';" &
                "           EXECUTE IMMEDIATE vStrStatement;" &
                "       END IF;" &
                "   END IF;" &
                "   /*添加数据gl_pz*/" &
                "   INSERT INTO gl_pz (djh,pzlxdm,cperiod,pzh,xh,bdelete,pzrq,fjzs,jd,zy,kmdm,kmmc,bmdm,bmmc,zydm,zymc,xmdm,xmmc,khdm,khmc,csdm,csmc,yhzh,jxzh,dwmc,dfkm,dw,sl,dj,bz,wb,hl,je,yspz,jsr,wldqr,srr,srrq) VALUES (paraStrDjh,vStrPzlxdm,vStrYear || vStrMonth,vIntPzno,paraIntXh,paraBlnDelete,paraDatePzrq,paraIntFjzs,paraStrJd,NVL(paraStrZy,'~'),NVL(paraStrKmdm,'~'),NVL(paraStrKmmc,'~'),NVL(ParaStrBmdm,'~'),NVL(paraStrBmmc,'~'),NVL(paraStrZydm,'~'),NVL(paraStrZymc,'~'),NVL(paraStrXmdm,'~'),NVL(paraStrXmmc,'~'),NVL(ParaStrKhdm,'~'),NVL(paraStrKhmc,'~'),NVL(paraStrCsdm,'~'),NVL(paraStrCsmc,'~'),NVL(paraStrYhzh,'~'),NVL(paraStrJxzh,'~'),NVL(paraStrDwmc,'~'),NVL(paraStrDfkm,'~'),NVL(paraStrDw,'~'),paraDblSl,paraDblDj,NVL(paraStrBz,'~'),paraDblWb,paraDblHl,paraDblJe,paraStrYspz,paraStrJsr,paraDateWldqr,paraStrUserDspName,sysdate);" &
                "   Exception" &
                "       WHEN OTHERS THEN" &
                "       ROLLBACK;" &
                "       paraStrMsg := '执行SQL语句错误，发生在USP3_SAVE_GL_PZ' || sqlerrm;" &
                "END USP3_SAVE_GL_PZ;"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try

        '********************************'
        '******rcdata_001****************'
        '*****USP3_SAVE_GL_YWFDKYW*******'
        '********************************'
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '2020年3月收款单增加结算方式的字段
            rcOleDbCommand.CommandText = "CREATE OR REPLACE PROCEDURE USP3_SAVE_GL_YWFDKYW" &
                "   ( paraIntIsAdding	    IN INTEGER" &
                "   , paraStrDjh 		    IN OUT VARCHAR2" &
                "   , paraDateDkrq		    IN DATE" &
                "   , ParaStrKhdm 		    IN VARCHAR2" &
                "   , paraStrKhmc 		    IN VARCHAR2" &
                "   , paraStrDkgsdm 	    IN VARCHAR2" &
                "   , paraStrDkgsmc 	    IN VARCHAR2" &
                "   , paraDblSkje		    IN NUMERIC" &
                "   , paraDblFyje		    IN NUMERIC" &
                "   , paraStrDkmemo		    IN VARCHAR2" &
                "   , paraStrUserDspName	IN VARCHAR2" &
                "   , paraStrMsg		    OUT VARCHAR2" &
                "   ) AS " &
                "vStrPzlxdm CHAR(4):='';" &
                "vStrYear CHAR(4):='';" &
                "vStrMonth CHAR(2):='';" &
                "vIntPzno INTEGER(5):=0;" &
                "vStrStatement VARCHAR(200):='';" &
                "BEGIN" &
                "   vStrPzlxdm := SUBSTR(paraStrDjh,1,4);" &
                "   vStrYear := SUBSTR(paraStrDjh,5,4);" &
                "   vStrMonth := SUBSTR(paraStrDjh,9,2);" &
                "   vIntPzno := SUBSTR(paraStrDjh,11,5);" &
                "   If paraIntIsAdding = 1 Then" &
                "       vStrStatement := 'SELECT pzno' || vStrMonth || ' FROM rc_lx WHERE pzlxdm =' || chr(39) || vStrPzlxdm || chr(39) || ' AND kjnd = ' || chr(39) || vStrYear || chr(39) || ' FOR UPDATE';" &
                "       EXECUTE IMMEDIATE vStrStatement INTO vIntPzno;" &
                "       vStrStatement := 'SELECT ' || vStrPzlxdm || vStrYear || vStrMonth || '.NEXTVAL FROM dual';" &
                "       EXECUTE IMMEDIATE vStrStatement INTO vIntPzno;" &
                "       vStrStatement := 'UPDATE rc_lx SET pzno' || vStrMonth ||' = ' || vIntPzno || ' WHERE pzlxdm = ' || chr(39) || vStrPzlxdm || chr(39) || ' AND kjnd = ' || chr(39) || vStrYear || chr(39) ;" &
                "       EXECUTE IMMEDIATE vStrStatement;" &
                "       paraStrDjh :=  vStrPzlxdm || vStrYear || vStrMonth || LPAD(vIntPzno,5,'0');" &
                "   Else" &
                "       DELETE FROM gl_ywfdkyw WHERE djh = paraStrDjh;" &
                "   END IF;" &
                "   INSERT INTO gl_ywfdkyw (djh,dkrq,khdm,khmc,dkgsdm,dkgsmc,skje,fyje,dkmemo,srr) VALUES (paraStrDjh,paraDateDkrq,ParaStrKhdm,paraStrKhmc,paraStrDkgsdm,paraStrDkgsmc,paraDblSkje,paraDblFyje,paraStrDkmemo,paraStrUserDspName);" &
                "   Exception" &
                "       WHEN OTHERS THEN ROLLBACK;" &
                "       paraStrMsg := '执行SQL语句错误，发生在USP3_SAVE_GL_YWFDKYW' || sqlerrm;" &
                "END USP3_SAVE_GL_YWFDKYW;"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '*****************************'
        '******rcdata_001*************'
        '*****USP3_SAVE_INV_CKD*******'
        '*****************************'
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "CREATE OR REPLACE PROCEDURE USP3_SAVE_INV_CKD 
                ( paraIntIsAdding IN INTEGER
                , paraStrDjh IN OUT VARCHAR2
                , paraIntXh IN INTEGER
                , paraDateCkrq IN DATE
                , paraBlnDelete IN NUMERIC
	            , ParaStrCkdm IN VARCHAR2
	            , paraStrCkmc IN VARCHAR2
                , ParaStrBmdm IN VARCHAR2
                , paraStrBmmc IN VARCHAR2
                , paraStrZydm IN VARCHAR2
                , paraStrZymc IN VARCHAR2
	            , ParaStrCpdm IN VARCHAR2
	            , paraStrCpmc IN VARCHAR2
                , paraStrCsdm IN VARCHAR2
                , paraStrCsmc IN VARCHAR2
	            , paraIntBrecycling IN NUMERIC
	            , paraIntBfadm IN NUMERIC
                , ParaStrFadm IN VARCHAR2
                , paraStrFamc IN VARCHAR2
	            , paraStrKuwei IN VARCHAR2
	            , paraStrPiHao IN VARCHAR2
	            , paraDblSl IN NUMERIC
	            , paraStrDw IN VARCHAR2
	            , paraDblMjsl IN NUMERIC
	            , paraDblFzsl IN NUMERIC
	            , paraStrFzdw IN VARCHAR2
	            , paraDblDj IN NUMERIC
	            , paraDblje IN NUMERIC
	            , paraStrCkmemo IN VARCHAR2
                , paraStrLlsqDjh IN VARCHAR2
                , paraIntLlsqXh IN INTEGER
	            , paraStrUserDspName IN VARCHAR2
                , paraCbill_bid IN VARCHAR2
	            , paraStrMsg OUT VARCHAR2
	              ) AS 
                vStrPzlxdm CHAR(4):='';
                vStrYear CHAR(4):='';
                vStrMonth CHAR(2):='';
                vIntPzno INTEGER(5):=0;
                vStrStatement VARCHAR(200):='';
                vIntCount INTEGER(4) := 0;
                vStrCkdm VARCHAR(12) :='';
                vStrCpdm VARCHAR(15) :='';
                vStrCsdm VARCHAR(12) :='';
                vStrPiHao VARCHAR(30) :='';
                vDblCksl NUMERIC(18,6) := 0.0;
                vDblCkje NUMERIC(14,2) := 0.0;
                CURSOR vCursorInv_ckd IS SELECT inv_ckd.djh,inv_ckd.bdelete,inv_ckd.xh,inv_ckd.ckdm,inv_ckd.cpdm,inv_ckd.csdm,inv_ckd.pihao,inv_ckd.hth,COALESCE(inv_ckd.sl,0.0) AS sl,COALESCE(inv_ckd.je,0.0) AS je,llsqdjh,llsqxh FROM inv_ckd WHERE djh = paraStrDjh ORDER BY xh;
                --正项先进先出核销用
                CURSOR vCursorPo_rkd1 IS SELECT po_rkd.djh,po_rkd.xh,po_rkd.ckdm,po_rkd.cpdm,po_rkd.csdm,po_rkd.pihao,po_rkd.sl,po_rkd.je,po_rkd.cksl,po_rkd.ckje FROM po_rkd WHERE po_rkd.sl > po_rkd.cksl AND po_rkd.ckdm = ParaStrCkdm AND po_rkd.cpdm = ParaStrCpdm AND po_rkd.csdm = paraStrCsdm AND po_rkd.pihao = paraStrPiHao ORDER BY djh,xh;
                --冲回正项已核销单据用
                CURSOR vCursorPo_rkd2 IS SELECT po_rkd.djh,po_rkd.xh,po_rkd.ckdm,po_rkd.cpdm,po_rkd.csdm,po_rkd.pihao,po_rkd.sl,po_rkd.je,po_rkd.cksl,po_rkd.ckje FROM po_rkd WHERE po_rkd.cksl <> 0 AND po_rkd.ckdm = vStrCkdm AND po_rkd.cpdm = vStrCpdm AND po_rkd.csdm = vStrCsdm AND po_rkd.pihao = vStrPiHao ORDER BY djh DESC,xh DESC;
                --负项后进先冲核销用
                CURSOR vCursorPo_rkd3 IS SELECT po_rkd.djh,po_rkd.xh,po_rkd.ckdm,po_rkd.cpdm,po_rkd.csdm,po_rkd.pihao,po_rkd.sl,po_rkd.je,po_rkd.cksl,po_rkd.ckje FROM po_rkd WHERE po_rkd.cksl <> 0 AND po_rkd.ckdm = ParaStrCkdm AND po_rkd.cpdm = ParaStrCpdm AND po_rkd.csdm = paraStrCsdm AND po_rkd.pihao = paraStrPiHao ORDER BY djh DESC,xh DESC;
                --冲回负项已核销单据用
                CURSOR vCursorPo_rkd4 IS SELECT po_rkd.djh,po_rkd.xh,po_rkd.ckdm,po_rkd.cpdm,po_rkd.csdm,po_rkd.pihao,po_rkd.sl,po_rkd.je,po_rkd.cksl,po_rkd.ckje FROM po_rkd WHERE po_rkd.sl > po_rkd.cksl AND po_rkd.ckdm = vStrCkdm AND po_rkd.cpdm = vStrCpdm AND po_rkd.csdm = vStrCsdm AND po_rkd.pihao = vStrPiHao ORDER BY djh,xh;
                BEGIN
                    vStrPzlxdm := SUBSTR(paraStrDjh,1,4);
                    vStrYear := SUBSTR(paraStrDjh,5,4);
                    vStrMonth := SUBSTR(paraStrDjh,9,2);
                    vIntPzno := SUBSTR(paraStrDjh,11,5);
                    IF paraIntXh = 1 THEN
                        --
                        IF paraIntIsAdding = 1 THEN
                            vStrStatement := 'SELECT ' || vStrPzlxdm || vStrYear || vStrMonth || '.NEXTVAL FROM dual';
                            EXECUTE IMMEDIATE vStrStatement INTO vIntPzno;
		                    --更新表rc_lx
		                    vStrStatement := 'UPDATE rc_lx SET pzno' || vStrMonth ||' = ' || vIntPzno || ' WHERE pzlxdm = ' || chr(39) || vStrPzlxdm || chr(39) || ' AND kjnd = ' || chr(39) || vStrYear || chr(39) ;
		                    EXECUTE IMMEDIATE vStrStatement;
		                    paraStrDjh :=  vStrPzlxdm || vStrYear || vStrMonth || LPAD(vIntPzno,5,'0');
                        ELSE
                            --对已保存的单据负项处理
                            FOR vInv_ckd IN vCursorInv_ckd LOOP
                                IF vInv_ckd.bdelete <> 1 THEN
                                    UPDATE inv_cpyeb SET idsl = idsl + vInv_ckd.sl,idje = idje + vInv_ckd.je WHERE kjnd = vStrYear AND cpdm = vInv_ckd.cpdm AND ckdm = vInv_ckd.ckdm;
                                    IF NOT vInv_ckd.llsqdjh IS NULL AND NOT vInv_ckd.llsqxh IS NULL THEN
                                        UPDATE inv_llsq SET cksl = cksl - vInv_ckd.sl WHERE djh = vInv_ckd.llsqdjh AND xh = vInv_ckd.llsqxh;
                                    END IF;
                                    vStrCkdm := vInv_ckd.ckdm;
                                    vStrCpdm := vInv_ckd.cpdm;
                                    vStrCsdm := vInv_ckd.csdm;
                                    vStrPiHao := vInv_ckd.pihao;
                                    vDblCksl := vInv_ckd.sl;
                                    vDblCkje := vInv_ckd.je;
                                    IF vDblCksl >= 0 THEN
                                        --冲回正项已核销单据
                                        FOR vPo_rkd2 IN vCursorPo_rkd2 LOOP
                                            IF vPo_rkd2.cksl >= vDblCksl THEN
                                                UPDATE po_rkd SET cksl = cksl - vDblCksl,ckje = ckje - vDblCkje WHERE djh = vPo_rkd2.djh AND xh = vPo_rkd2.xh;
                                                vDblCksl := 0.0;
                                                vDblCkje := 0.0;
                                            ELSE
                                                UPDATE Po_rkd SET cksl = 0.0,ckje = 0.0 WHERE djh = vPo_rkd2.djh AND xh = vPo_rkd2.xh;
                                                vDblCksl := vDblCksl - vPo_rkd2.Cksl;
                                                vDblCkje := vDblCkje - vPo_rkd2.Ckje;
                                            END IF;
                                            IF vDblCksl = 0.0 AND vDblCkje = 0.0 THEN
                                                EXIT;
                                            END IF;
                                        END LOOP;
                                    ELSE
                                        --冲回负项已核销单据用
                                        FOR vPo_rkd4 IN vCursorPo_rkd4 LOOP
                                            IF vPo_rkd4.sl - vPo_rkd4.cksl >= 0 - vDblCksl THEN
                                                UPDATE po_rkd SET cksl = cksl - vDblCksl,ckje = ckje - vDblCkje WHERE djh = vPo_rkd4.djh AND xh = vPo_rkd4.xh;
                                                vDblCksl := 0.0;
                                                vDblCkje := 0.0;
                                            ELSE
                                                UPDATE po_rkd SET cksl = sl,ckje = je WHERE djh = vPo_rkd4.djh AND xh = vPo_rkd4.xh;
                                                vDblCksl := vDblCksl + vPo_rkd4.sl - vPo_rkd4.cksl;
                                                vDblCkje := vDblCkje + vPo_rkd4.je - vPo_rkd4.Ckje;
                                            END IF;
                                            IF vDblCksl = 0 AND vDblCkje = 0 THEN
                                                EXIT;
                                            END IF;
                                        END LOOP;
                                    END IF;
                                END IF;
                            END LOOP;
                            DELETE FROM inv_ckd WHERE djh = paraStrDjh;
                        END IF;
                    END IF;
                    IF paraBlnDelete <> 1 THEN
                        --更新inv_cpyeb表
		                    SELECT COUNT(1) INTO vIntCount FROM inv_cpyeb WHERE kjnd = vStrYear AND cpdm = ParaStrCpdm AND ckdm = ParaStrCkdm;
    		                IF vIntCount = 0 THEN
		                        INSERT INTO inv_cpyeb (kjnd,cpdm,ckdm,qcsl,qcje,idsl,idje) VALUES (vStrYear,ParaStrCpdm,ParaStrCkdm,0.0,0.0,0.0,0.0);
		                    END IF;
		                    UPDATE inv_cpyeb SET idsl = idsl - paraDblSl,idje = idje - paraDblJe WHERE kjnd = vStrYear AND cpdm = ParaStrCpdm AND ckdm = ParaStrCkdm;
                        --更新领料申请单
                        IF NOT paraStrLlsqDjh IS NULL AND NOT paraIntLlsqXh IS NULL THEN
                            UPDATE inv_llsq SET cksl = cksl + paraDblSl WHERE djh = paraStrLlsqDjh AND xh = paraIntLlsqXh;
                        END IF;
                        vDblCksl := paraDblSl;
                        vDblCkje := paraDblJe;
                        IF paraDblSl >=0 THEN
                            --根据先进先出法更新采购入库单PO_RKD
                            FOR vPo_rkd1 IN vCursorPo_rkd1 LOOP
                                IF vPo_rkd1.sl - vPo_rkd1.cksl >= vDblCksl THEN
                                    UPDATE po_rkd SET cksl = cksl + vDblCksl,ckje = ckje + vDblCkje WHERE djh = vPo_rkd1.djh AND xh = vPo_rkd1.xh;
                                    vDblCksl := 0.0;
                                    vDblCkje := 0.0;
                                ELSE
                                    UPDATE po_rkd SET cksl = cksl + vPo_rkd1.sl - vPo_rkd1.cksl,ckje = ckje + vPo_rkd1.je - vPo_rkd1.ckje WHERE djh = vPo_rkd1.djh AND xh = vPo_rkd1.xh;
                                    vDblCksl := vDblCksl - vPo_rkd1.sl + vPo_rkd1.cksl;
                                    vDblCkje := vDblCkje - vPo_rkd1.je + vPo_rkd1.Ckje;
                                END IF;
                                IF vDblCksl = 0 AND vDblCkje = 0 THEN
                                    EXIT;
                                END IF;
                            END LOOP;
                        ELSE
                            --根据后出先冲法更新采购入库单PO_RKD
                            FOR vPo_rkd3 IN vCursorPo_rkd3 LOOP
                                IF vPo_rkd3.cksl <= 0 - vDblCksl THEN
                                    UPDATE po_rkd SET cksl = 0,ckje = 0 WHERE djh = vPo_rkd3.djh AND xh = vPo_rkd3.xh;
                                    vDblCksl := vDblCksl + vPo_rkd3.cksl;
                                    vDblCkje := vDblCkje + vPo_rkd3.ckje;
                                ELSE
                                    UPDATE po_rkd SET cksl = cksl + vDblCksl ,ckje = ckje + vDblCkje WHERE djh = vPo_rkd3.djh AND xh = vPo_rkd3.xh;
                                    vDblCksl := 0.0;
                                    vDblCkje := 0.0;
                                END IF;
                                IF vDblCksl = 0.0 AND vDblCkje = 0.0 THEN
                                    EXIT;
                                END IF;
                            END LOOP;
                        END IF;
                    END IF;
	                  --添加数据inv_ckd
	                  INSERT INTO inv_ckd (djh,xh,ckrq,bdelete,ckdm,ckmc,bmdm,bmmc,zydm,zymc,cpdm,cpmc,csdm,csmc,brecycling,bfadm,fadm,famc,kuwei,pihao,sl,dw,mjsl,fzsl,fzdw,dj,je,ckmemo,llsqdjh,llsqxh,srr,cbill_bid,srrq) VALUES (paraStrDjh,paraIntXh,paraDateCkrq,paraBlnDelete,ParaStrCkdm,paraStrCkmc,ParaStrBmdm,paraStrBmmc,paraStrZydm,paraStrZymc,ParaStrCpdm,paraStrCpmc,paraStrCsdm,paraStrCsmc,paraIntBrecycling,paraIntBfadm,ParaStrFadm,paraStrFamc,paraStrKuwei,paraStrPiHao,paraDblSl,paraStrDw,paraDblMjsl,paraDblFzsl,paraStrFzdw,paraDblDj,paraDblJe,paraStrCkmemo,paraStrLlsqDjh,paraIntLlsqXh,paraStrUserDspName,paraCbill_bid,SYSDATE);
                EXCEPTION
   	                WHEN OTHERS THEN
   	                ROLLBACK;
   	                paraStrMsg := '执行SQL语句错误，发生在USP_SAVE_INV_CKD' || sqlerrm;
                END USP3_SAVE_INV_CKD;"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '*****************************'
        '******rcdata_001*************'
        '*****USP3_SAVE_INV_DBD*******'
        '*****************************'
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "CREATE OR REPLACE PROCEDURE USP3_SAVE_INV_DBD 
                  ( paraIntIsAdding IN INTEGER
                  , paraStrDjh IN OUT VARCHAR2
                  , paraIntXh IN INTEGER
                  , paraDateDbrq IN DATE
                  , paraBlnDelete IN NUMERIC
                  , paraStrCckdm IN VARCHAR2
                  , paraStrCckmc IN VARCHAR2
                  , paraStrRckdm IN VARCHAR2
                  , paraStrRckmc IN VARCHAR2
                  , paraStrZydm IN VARCHAR2
                  , paraStrZymc IN VARCHAR2
                  , ParaStrCpdm IN VARCHAR2
                  , paraStrCpmc IN VARCHAR2
                  , paraStrCsdm IN VARCHAR2
                  , paraStrCsmc IN VARCHAR2
                  , paraStrKuwei IN VARCHAR2
                  , paraStrPiHao IN VARCHAR2
                  , paraDblSl IN NUMERIC
                  , paraStrDw IN VARCHAR2
                  , paraDblMjsl IN NUMERIC
                  , paraDblFzsl IN NUMERIC
                  , paraStrFzdw IN VARCHAR2
                  , paraDblDj IN NUMERIC
                  , paraDblje IN NUMERIC
                  , paraStrDbmemo IN VARCHAR2
                  , paraStrLlsqDjh IN VARCHAR2
                  , paraIntLlsqXh IN INTEGER
                  , paraStrUserDspName IN VARCHAR2
                  , paraCbill_bid IN VARCHAR2
                  , paraStrMsg OUT VARCHAR2
                  ) AS

                vStrPzlxdm CHAR(4):='';
                vStrYear CHAR(4):='';
                vStrMonth CHAR(2):='';
                vIntPzno INTEGER(5):=0;
                vStrStatement VARCHAR(200):='';
                vIntCount INTEGER(4) := 0;
                CURSOR vCursorInv_dbd IS SELECT inv_dbd.djh,inv_dbd.bdelete,inv_dbd.xh,inv_dbd.cckdm,inv_dbd.rckdm,inv_dbd.cpdm,COALESCE(inv_dbd.sl,0.0) AS sl,COALESCE(inv_dbd.je,0.0) AS je,llsqdjh,llsqxh FROM inv_dbd WHERE djh = paraStrDjh ORDER BY xh;
                BEGIN
                    vStrPzlxdm := SUBSTR(paraStrDjh,1,4);
                    vStrYear := SUBSTR(paraStrDjh,5,4);
                    vStrMonth := SUBSTR(paraStrDjh,9,2);
                    vIntPzno := SUBSTR(paraStrDjh,11,5);
                    IF paraIntXh = 1 THEN
                        --
                        IF paraIntIsAdding = 1 THEN
                            vStrStatement := 'SELECT ' || vStrPzlxdm || vStrYear || vStrMonth || '.NEXTVAL FROM dual';
                            EXECUTE IMMEDIATE vStrStatement INTO vIntPzno;
                            --更新表rc_lx
                            vStrStatement := 'UPDATE rc_lx SET pzno' || vStrMonth ||' = ' || vIntPzno || ' WHERE pzlxdm = ' || chr(39) || vStrPzlxdm || chr(39) || ' AND kjnd = ' || chr(39) || vStrYear || chr(39) ;
                            EXECUTE IMMEDIATE vStrStatement;
                            paraStrDjh :=  vStrPzlxdm || vStrYear || vStrMonth || LPAD(vIntPzno,5,'0');
                        ELSE
                            --对已保存的单据负项处理
                            FOR vInv_dbd IN vCursorInv_dbd LOOP
                                IF vInv_dbd.bdelete <> 1 THEN
                                    UPDATE inv_cpyeb SET idsl = idsl + vInv_dbd.sl,idje = idje + vInv_dbd.je WHERE kjnd = vStrYear AND cpdm = vInv_dbd.cpdm AND ckdm = vInv_dbd.cckdm;
                                    UPDATE inv_cpyeb SET idsl = idsl - vInv_dbd.sl,idje = idje - vInv_dbd.je WHERE kjnd = vStrYear AND cpdm = vInv_dbd.cpdm AND ckdm = vInv_dbd.rckdm;
                                    IF NOT vInv_dbd.llsqdjh IS NULL AND NOT vInv_dbd.llsqxh IS NULL THEN
                                        UPDATE inv_llsq SET cksl = cksl - vInv_dbd.sl WHERE djh = vInv_dbd.llsqdjh AND xh = vInv_dbd.llsqxh;
                                    END IF;
                                END IF;
                            END LOOP;
                            DELETE FROM inv_dbd WHERE djh = paraStrDjh;
                        END IF;
                    END IF;
                    IF paraBlnDelete <> 1 THEN
                        --更新inv_cpyeb表
                        SELECT COUNT(1) INTO vIntCount FROM inv_cpyeb WHERE kjnd = vStrYear AND cpdm = ParaStrCpdm AND ckdm = paraStrCckdm;
                        IF vIntCount = 0 THEN
                            INSERT INTO inv_cpyeb (kjnd,cpdm,ckdm,qcsl,qcje,idsl,idje) VALUES (vStrYear,ParaStrCpdm,paraStrCckdm,0.0,0.0,0.0,0.0);
                        END IF;
                        UPDATE inv_cpyeb SET idsl = idsl - paraDblSl,idje = idje - paraDblJe WHERE kjnd = vStrYear AND cpdm = ParaStrCpdm AND ckdm = paraStrCckdm;
                        --更新inv_cpyeb表
                        SELECT COUNT(1) INTO vIntCount FROM inv_cpyeb WHERE kjnd = vStrYear AND cpdm = ParaStrCpdm AND ckdm = paraStrRckdm;
                        IF vIntCount = 0 THEN
                            INSERT INTO inv_cpyeb (kjnd,cpdm,ckdm,qcsl,qcje,idsl,idje) VALUES (vStrYear,ParaStrCpdm,paraStrRckdm,0.0,0.0,0.0,0.0);
                        END IF;
                        UPDATE inv_cpyeb SET idsl = idsl + paraDblSl,idje = idje + paraDblJe WHERE kjnd = vStrYear AND cpdm = ParaStrCpdm AND ckdm = paraStrRckdm;
                        --更新领料申请单
                        IF NOT paraStrLlsqDjh IS NULL AND NOT paraIntLlsqXh IS NULL THEN
                            UPDATE inv_llsq SET cksl = cksl + paraDblSl WHERE djh = paraStrLlsqDjh AND xh = paraIntLlsqXh;
                        END IF;
                    END IF;
                    --添加数据inv_dbd
                    INSERT INTO inv_dbd (djh,xh,dbrq,bdelete,cckdm,cckmc,rckdm,rckmc,zydm,zymc,cpdm,cpmc,csdm,csmc,kuwei,pihao,sl,dw,mjsl,fzsl,fzdw,dj,je,dbmemo,llsqdjh,llsqxh,srr,cbill_bid) VALUES (paraStrDjh,paraIntXh,paraDateDbrq,paraBlnDelete,paraStrCckdm,paraStrCckmc,paraStrRckdm,paraStrRckmc,paraStrZydm,paraStrZymc,ParaStrCpdm,paraStrCpmc,paraStrCsdm,paraStrCsmc,paraStrKuwei,paraStrPiHao,paraDblSl,paraStrDw,paraDblMjsl,paraDblFzsl,paraStrFzdw,paraDblDj,paraDblJe,paraStrDbmemo,paraStrLlsqDjh,paraIntLlsqXh,paraStrUserDspName,paraCbill_bid);
                    --COMMIT;
                EXCEPTION
                     WHEN OTHERS THEN
                     ROLLBACK;
   	                paraStrMsg := '执行SQL语句错误，发生在USP_SAVE_INV_DBD' || sqlerrm;
                END USP3_SAVE_INV_DBD;"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        '*****************************'
        '******rcdata_001*************'
        '*****USP3_SAVE_INV_RKD*******'
        '*****************************'
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "CREATE OR REPLACE PROCEDURE USP3_SAVE_INV_RKD" &
                "( paraIntIsAdding IN INTEGER" &
                ", paraStrDjh IN OUT VARCHAR2" &
                ", paraIntXh IN INTEGER" &
                ", paraDateRkrq IN DATE" &
                ", paraBlnDelete IN NUMERIC" &
                ", paraStrZydm IN VARCHAR2" &
                ", paraStrZymc IN VARCHAR2" &
                ", ParaStrBmdm IN VARCHAR2" &
                ", paraStrBmmc IN VARCHAR2" &
                ", ParaStrCkdm IN VARCHAR2" &
                ", paraStrCkmc IN VARCHAR2" &
                ", ParaStrCpdm IN VARCHAR2" &
                ", paraStrCpmc IN VARCHAR2" &
                ", paraStrHth IN VARCHAR2" &
                ", paraDblSl IN NUMERIC" &
                ", paraStrDw IN VARCHAR2" &
                ", paraDblMjsl IN NUMERIC" &
                ", paraDblFzsl IN NUMERIC" &
                ", paraStrFzdw IN VARCHAR2" &
                ", paraDblDj IN NUMERIC" &
                ", paraDblJe IN NUMERIC" &
                ", paraStrRkmemo IN VARCHAR2" &
                ", paraStrUserDspName IN VARCHAR2" &
                ", paraCbill_bid IN VARCHAR2" &
                ", paraStrMsg OUT VARCHAR2" &
                ") AS " &
                "vStrPzlxdm CHAR(4):='';" &
                "vStrYear CHAR(4):='';" &
                "vStrMonth CHAR(2):='';" &
                "vIntPzno INTEGER(5):=0;" &
                "vStrStatement VARCHAR(200):='';" &
                "vIntCount INTEGER(4) := 0;" &
                "vDblRksl NUMERIC(18,6) := 0;" &
                "vStrHth VARCHAR(11):='';" &
                "vStrCpdm VARCHAR(15) := '';" &
                "vStrDddjh VARCHAR(15) := '';" &
                "vIntDdxh INTEGER(5) := 0;" &
                "CURSOR vCursorInv_rkd IS SELECT inv_rkd.djh,inv_rkd.bdelete,inv_rkd.ckdm,inv_rkd.xh,inv_rkd.cpdm,inv_rkd.hth,COALESCE(inv_rkd.sl,0.0) AS sl,COALESCE(inv_rkd.je,0.0) AS je FROM inv_rkd WHERE djh = paraStrDjh ORDER BY xh;" &
                "CURSOR vCursorOe_dd1 IS SELECT oe_dd.djh,oe_dd.xh,oe_dd.cpdm,oe_dd.hth,COALESCE(oe_dd.sl,0.0) AS sl,COALESCE(oe_dd.hxsl,0.0) AS hxsl,COALESCE(oe_dd.rksl,0.0) AS rksl FROM oe_dd WHERE sl - hxsl > rksl AND cpdm = ParaStrCpdm AND hth = paraStrHth ORDER BY djh,xh;" &
                "CURSOR vCursorOe_dd2 IS SELECT oe_dd.djh,oe_dd.xh,oe_dd.cpdm,oe_dd.hth,COALESCE(oe_dd.sl,0.0) AS sl,COALESCE(oe_dd.hxsl,0.0) AS hxsl,COALESCE(oe_dd.rksl,0.0) AS rksl,COALESCE(oe_dd.cerk,0.0) AS cerk FROM oe_dd WHERE rksl > 0 AND cpdm = vStrCpdm AND hth = vStrHth ORDER BY djh DESC,xh DESC;" &
                "BEGIN" &
                "   vStrPzlxdm := SUBSTR(paraStrDjh,1,4);" &
                "   vStrYear := SUBSTR(paraStrDjh,5,4);" &
                "   vStrMonth := SUBSTR(paraStrDjh,9,2);" &
                "   vIntPzno := SUBSTR(paraStrDjh,11,5);" &
                "   IF paraIntXh = 1 THEN" &
                "       IF paraIntIsAdding = 1 THEN" &
                "           vStrStatement := 'SELECT ' || vStrPzlxdm || vStrYear || vStrMonth || '.NEXTVAL FROM dual';" &
                "           EXECUTE IMMEDIATE vStrStatement INTO vIntPzno;" &
                "           /*更新表rc_lx*/" &
                "           vStrStatement := 'UPDATE rc_lx SET pzno' || vStrMonth ||' = ' || vIntPzno || ' WHERE pzlxdm = ' || chr(39) || vStrPzlxdm || chr(39) || ' AND kjnd = ' || chr(39) || vStrYear || chr(39) ;" &
                "           EXECUTE IMMEDIATE vStrStatement;" &
                "           paraStrDjh :=  vStrPzlxdm || vStrYear || vStrMonth || LPAD(vIntPzno,5,'0');" &
                "       ELSE" &
                "           /*对已保存的单据负项处理*/" &
                "           FOR vInv_rkd IN vCursorInv_rkd LOOP" &
                "               IF NOT vInv_rkd.hth IS NULL AND vInv_rkd.bdelete <> 1 THEN" &
                "                   vDblRksl := vInv_rkd.sl;" &
                "                   vStrHth := vInv_rkd.hth;" &
                "                   vStrCpdm := vInv_rkd.cpdm;" &
                "                   FOR vOe_dd2 IN vCursorOe_dd2 LOOP" &
                "                      IF vOe_dd2.cerk > 0 THEN" &
                "                           UPDATE oe_dd SET cerk = 0 WHERE djh = vOe_dd2.djh AND xh = vOe_dd2.xh;" &
                "                           vDblRksl := vDblRksl - vOe_dd2.cerk;" &
                "                       END IF;" &
                "                       IF vOe_dd2.rksl >= vDblRksl THEN" &
                "                           UPDATE oe_dd SET rksl = rksl - vDblRksl,rkrq = SYSDATE WHERE djh = vOe_dd2.djh AND xh = vOe_dd2.xh;" &
                "                           vDblRksl := 0.0;" &
                "                       END IF;" &
                "                      IF vOe_dd2.rksl < paraDblSl THEN" &
                "                           UPDATE oe_dd SET rksl = 0.0,rkrq = SYSDATE WHERE djh = vOe_dd2.djh AND xh = vOe_dd2.xh;" &
                "                           vDblRksl := vDblRksl - vOe_dd2.rksl;" &
                "                       END IF;" &
                "                       IF vDblRksl = 0 THEN" &
                "                           EXIT;" &
                "                       END IF;" &
                "                   END LOOP;" &
                "                   IF vDblRksl <> 0 THEN" &
                "                       UPDATE oe_dd SET cerk = cerk - vDblRksl WHERE djh = vStrDddjh AND xh = vIntDdxh;" &
                "                   END IF;" &
                "               END IF;" &
                "               IF vInv_rkd.bdelete <> 1 THEN" &
                "                   UPDATE inv_cpyeb SET idsl = idsl - vInv_rkd.sl,idje = idje - vInv_rkd.je WHERE kjnd = vStrYear AND cpdm = vInv_rkd.cpdm AND ckdm = vInv_rkd.ckdm;" &
                "               END IF;" &
                "           END LOOP;" &
                "           DELETE FROM inv_rkd WHERE djh = paraStrDjh;" &
                "       END IF;" &
                "   END IF;" &
                "   IF NOT paraStrHth IS NULL AND paraBlnDelete <> 1 THEN" &
                "       vDblRksl := paraDblSL;" &
                "       FOR vOe_dd1 IN vCursorOe_dd1 LOOP" &
                "           vStrDddjh := vOe_dd1.djh;" &
                "           vIntDdxh := vOe_dd1.xh;" &
                "           IF vOe_dd1.sl - vOe_dd1.hxsl - vOe_dd1.rksl >= vDblRksl THEN" &
                "               UPDATE oe_dd SET rksl = rksl + vDblRksl,rkrq = SYSDATE WHERE djh = vOe_dd1.djh AND xh = vOe_dd1.xh;" &
                "               vDblRksl := 0.0;" &
                "           END IF;" &
                "           IF vOe_dd1.sl - vOe_dd1.hxsl - vOe_dd1.rksl < vDblRksl THEN" &
                "               UPDATE oe_dd SET rksl = rksl + vOe_dd1.sl - vOe_dd1.hxsl - vOe_dd1.rksl,rkrq = SYSDATE WHERE djh = vOe_dd1.djh AND xh = vOe_dd1.xh;" &
                "               vDblRksl := vDblRksl - vOe_dd1.sl + vOe_dd1.hxsl + vOe_dd1.rksl;" &
                "           END IF;" &
                "           IF vDblRksl = 0 THEN" &
                "               EXIT;" &
                "           END IF;" &
                "       END LOOP;" &
                "       IF vDblRksl <> 0 THEN" &
                "           UPDATE oe_dd SET cerk = vDblRksl WHERE djh = vStrDddjh AND xh = vIntDdxh;" &
                "       END IF;" &
                "   END IF;" &
                "   /*更新inv_cpyeb表*/" &
                "   SELECT COUNT(1) INTO vIntCount FROM inv_cpyeb WHERE kjnd = vStrYear AND cpdm = ParaStrCpdm AND ckdm = ParaStrCkdm;" &
                "   IF vIntCount = 0 THEN" &
                "       INSERT INTO inv_cpyeb (kjnd,cpdm,ckdm,qcsl,qcje,idsl,idje) VALUES (vStrYear,ParaStrCpdm,ParaStrCkdm,0.0,0.0,0.0,0.0);" &
                "   END IF;" &
                "   IF paraBlnDelete <> 1 THEN" &
                "       UPDATE inv_cpyeb SET idsl = idsl + paraDblSl WHERE kjnd = vStrYear AND cpdm = ParaStrCpdm AND ckdm = ParaStrCkdm;" &
                "   END IF;" &
                "   /*添加数据inv_rkd*/" &
                "   INSERT INTO inv_rkd (djh,xh,rkrq,bdelete,zydm,zymc,bmdm,bmmc,ckdm,ckmc,cpdm,cpmc,hth,sl,dw,mjsl,fzsl,fzdw,dj,je,rkmemo,srr,cbill_bid) VALUES (paraStrDjh,paraIntXh,paraDateRkrq,paraBlnDelete,paraStrZydm,paraStrZymc,ParaStrBmdm,paraStrBmmc,ParaStrCkdm,paraStrCkmc,ParaStrCpdm,paraStrCpmc,paraStrHth,paraDblSl,paraStrDw,paraDblMjsl,paraDblFzsl,paraStrFzdw,paraDblDj,paraDblJe,paraStrRkmemo,paraStrUserDspName,paraCbill_bid);" &
                "   /*UPDATE rc_cpxx SET rgcb = paraDblRgdj WHERE cpdm = ParaStrCpdm AND paraDblRgdj <> 0;*/" &
                "   /*COMMIT;*/" &
                "   EXCEPTION" &
                "       WHEN OTHERS THEN" &
                "       ROLLBACK;" &
                "       paraStrMsg := '执行SQL语句错误，发生在SP_SAVE_INV_RKD' || sqlerrm;" &
                "END USP3_SAVE_INV_RKD;"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try

        '*****************************'
        '******rcdata_001*************'
        '*****USP3_SAVE_OE_DD*********'
        '*****************************'
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '2020年3月收款单增加结算方式的字段
            rcOleDbCommand.CommandText = "CREATE Or REPLACE PROCEDURE USP3_SAVE_OE_DD" &
                "   ( paraIntIsAdding       In Integer" &
                "   , paraStrDjh            In OUT VARCHAR2" &
                "   , paraIntXh             In Integer" &
                "   , paraDateQdrq	        In Date" &
                "   , paraStrHth 	        In OUT VARCHAR2" &
                "   , ParaStrKhdm 		    In VARCHAR2" &
                "	, paraStrKhmc 		    In VARCHAR2" &
                "	, paraStrZydm 		    In VARCHAR2" &
                "	, paraStrZymc 		    In VARCHAR2" &
                "	, paraStrDdtk 		    In VARCHAR2" &
                "	, paraStrSktj 		    In VARCHAR2" &
                "	, paraIntSkqx 		    In Integer" &
                "	, ParaStrCpdm		    In VARCHAR2" &
                "	, paraStrCpmc 		    In VARCHAR2" &
                "   , paraDblSl             In NUMERIC" &
                "   , paraStrDw             In VARCHAR2" &
                "   , paraDblMjsl           In NUMERIC" &
                "   , paraDblFzsl           In NUMERIC" &
                "   , paraStrFzdw           In VARCHAR2" &
                "   , paraDblDj             In NUMERIC" &
                "   , paraDblHsdj           In NUMERIC" &
                "   , paraDblJe             In NUMERIC" &
                "   , paraDblShlv           In NUMERIC" &
                "   , paraDblSe             In NUMERIC" &
                "   , paraStrKhddh 		    In VARCHAR2" &
                "   , paraStrKhlh 		    In VARCHAR2" &
                "   , paraDateKhjhrq	    In Date" &
                "   , paraDateScjhrq	    In Date" &
                "   , paraStrZxgg 		    In VARCHAR2" &
                "   , paraStrDdmemo		    In VARCHAR2" &
                "   , paraStrSdjh           In VARCHAR2" &
                "   , paraIntSxh            In Integer" &
                "   , paraStrUserDspName    In VARCHAR2" &
                "   , paraStrMsg		    OUT VARCHAR2" &
                "	) AS " &
                "vStrPzlxdm CHAR(4):='';" &
                "vStrYear CHAR(4):='';" &
                "vStrMonth CHAR(2):='';" &
                "vIntPzno INTEGER(5):=0;" &
                "vStrStatement VARCHAR(200):='';" &
                "vDblYhxsl NUMERIC(18,6) := 0;" &
                "vBlnNew BOOLEAN := TRUE;" &
                "CURSOR vCursorOe_dd IS SELECT oe_dd.djh,oe_dd.xh,oe_dd.cpdm,oe_dd.hth,COALESCE(oe_dd.sl,0.0) AS sl,oe_dd.sdjh,oe_dd.sxh FROM oe_dd WHERE djh = paraStrDjh ORDER BY xh;" &
                "BEGIN" &
                "   vStrPzlxdm := SUBSTR(paraStrDjh,1,4);" &
                "   vStrYear := SUBSTR(paraStrDjh,5,4);" &
                "   vStrMonth := SUBSTR(paraStrDjh,9,2);" &
                "   vIntPzno := SUBSTR(paraStrDjh,11,5);" &
                "   If paraStrHth = SUBSTR(paraStrDjh, 5, 11) Then" &
                "       vBlnNew := TRUE;" &
                "   Else" &
                "       vBlnNew := FALSE;" &
                "   END IF;" &
                "   If paraIntXh = 1 Then" &
                "       If paraIntIsAdding = 1 Then" &
                "           vStrStatement := 'SELECT pzno' || vStrMonth || ' FROM rc_lx WHERE pzlxdm =' || chr(39) || vStrPzlxdm || chr(39) || ' AND kjnd = ' || chr(39) || vStrYear || chr(39) || ' FOR UPDATE';" &
                "           EXECUTE IMMEDIATE vStrStatement INTO vIntPzno;" &
                "		    vStrStatement := 'SELECT ' || vStrPzlxdm || vStrYear || vStrMonth || '.NEXTVAL FROM dual';" &
                "		    EXECUTE IMMEDIATE vStrStatement INTO vIntPzno;" &
                "		    /*更新表rc_lx*/" &
                "		    vStrStatement := 'UPDATE rc_lx SET pzno' || vStrMonth ||' = ' || vIntPzno || ' WHERE pzlxdm = ' || chr(39) || vStrPzlxdm || chr(39) || ' AND kjnd = ' || chr(39) || vStrYear || chr(39) ;" &
                "		    EXECUTE IMMEDIATE vStrStatement;" &
                "           If vBlnNew Then" &
                "               paraStrHth := vStrYear || vStrMonth || LPAD(vIntPzno,5,'0');" &
                "           END IF;" &
                "		    paraStrDjh :=  vStrPzlxdm || vStrYear || vStrMonth || LPAD(vIntPzno,5,'0');" &
                "       Else" &
                "           /*对已保存的单据负项处理*/" &
                "           FOR vOe_dd IN vCursorOe_dd LOOP" &
                "               If vOe_dd.sl < 0 AND NOT vOe_dd.sdjh IS NULL Then" &
                "                   UPDATE oe_dd SET hxsl = hxsl + vOe_dd.sl WHERE xh = vOe_dd.sxh AND djh = vOe_dd.sdjh;" &
                "               END IF;" &
                "           END LOOP;" &
                "           DELETE FROM oe_dd WHERE djh = paraStrDjh;" &
                "       END IF;" &
                "   END IF;" &
                "   If paraDblSl < 0 AND NOT paraStrSdjh IS NULL Then" &
                "       UPDATE oe_dd SET hxsl = hxsl - paraDblSl WHERE xh = paraIntSxh AND djh = paraStrSdjh;" &
                "       vDblYhxsl := paraDblSl;" &
                "   END IF;" &
                "   /*添加数据oe_dd*/" &
                "   INSERT INTO oe_dd (djh,xh,qdrq,hth,khdm,khmc,zydm,zymc,ddtk,sktj,skqx,cpdm,cpmc,sl,hxsl,dw,mjsl,fzsl,fzdw,dj,hsdj,je,shlv,se,khddh,khlh,khjhrq,scjhrq,zxgg,ddmemo,sdjh,sxh,srr) VALUES (paraStrDjh,paraIntXh,paraDateQdrq,paraStrHth,ParaStrKhdm,paraStrKhmc,paraStrZydm,paraStrZymc,paraStrDdtk,paraStrSktj,paraIntSkqx,ParaStrCpdm,paraStrCpmc,paraDblSl,vDblYhxsl,paraStrDw,paraDblMjsl,paraDblFzsl,paraStrFzdw,paraDblDj,paraDblHsdj,paraDblJe,paraDblShlv,paraDblSe,paraStrKhddh,paraStrKhlh,paraDateKhjhrq,paraDateScjhrq,paraStrZxgg,paraStrDdmemo,paraStrSdjh,paraIntSxh,paraStrUserDspName);" &
                "   Exception" &
                "       WHEN OTHERS THEN ROLLBACK;" &
                "       paraStrMsg := '执行SQL语句错误，发生在USP3_SAVE_OE_DD' || sqlerrm;" &
                "END USP3_SAVE_OE_DD;"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try

        '*****************************'
        '******rcdata_001*************'
        '*****USP3_SAVE_OE_FP*********'
        '*****************************'
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '2020年3月收款单增加结算方式的字段
            rcOleDbCommand.CommandText = "CREATE OR REPLACE PROCEDURE USP3_SAVE_OE_FP(paraIntIsAdding    IN INTEGER,
                                                        paraIntIsNewBill   IN INTEGER,
                                                        paraStrDjh         IN OUT VARCHAR2,
                                                        paraIntXh          IN INTEGER,
                                                        paraDateFprq       IN DATE,
                                                        paraBlnDelete      IN INTEGER,
                                                        paraStrZydm        IN VARCHAR2,
                                                        paraStrZymc        IN VARCHAR2,
                                                        paraStrKhdm        IN VARCHAR2,
                                                        paraStrKhmc        IN VARCHAR2,
                                                        paraStrShKhdm      IN VARCHAR2,
                                                        paraStrShKhmc      IN VARCHAR2,
                                                        paraStrYspz        IN VARCHAR2,
                                                        paraStrCpdm        IN VARCHAR2,
                                                        paraStrCpmc        IN VARCHAR2,
                                                        paraStrHth         IN VARCHAR2,
                                                        paraStrKhddh       IN VARCHAR2,
                                                        paraStrBmdm        IN VARCHAR2,
                                                        paraStrBmmc        IN VARCHAR2,
                                                        paraDblSl          IN NUMERIC,
                                                        paraStrDw          IN VARCHAR2,
                                                        paraDblMjsl        IN NUMERIC,
                                                        paraDblFzsl        IN NUMERIC,
                                                        paraStrFzdw        IN VARCHAR2,
                                                        paraDblDj          IN NUMERIC,
                                                        paraDblHsdj        IN NUMERIC,
                                                        paraDblJe          IN NUMERIC,
                                                        paraDblShlv        IN NUMERIC,
                                                        paraDblSe          IN NUMERIC,
                                                        paraStrFpmemo      IN VARCHAR2,
                                                        paraStrDdDjh       IN VARCHAR2,
                                                        paraIntDdXh        IN INTEGER,
                                                        paraStrXsdDjh      IN VARCHAR2,
                                                        paraIntXsdXh       IN INTEGER,
                                                        paraDblXsdDj       IN NUMERIC,
                                                        paraDblXsdHsdj     IN NUMERIC,
                                                        paraDblXsdJe       IN NUMERIC,
                                                        paraDblXsdShlv     IN NUMERIC,
                                                        paraDblXsdSe       IN NUMERIC,
                                                        paraStrUserDspName IN VARCHAR2,
                                                        paraStrMsg         OUT VARCHAR2) AS

                vStrPzlxdm    CHAR(4) := '';
                vStrYear      CHAR(4) := '';
                vStrMonth     CHAR(2) := '';
                vIntPzno      INTEGER(5) := 0;
                vStrStatement VARCHAR(200) := '';
                vIntCount     INTEGER(4) := 0;
                vDblFpsl      NUMERIC(18, 6) := 0;
                vDblFpje      NUMERIC(14, 2) := 0;
                vDblFpse      NUMERIC(14, 2) := 0;
                CURSOR vCursorOe_fp IS
                    SELECT oe_fp.djh,
                           oe_fp.bdelete,
                           oe_fp.xh,
                           oe_fp.khdm,
                           oe_fp.cpdm,
                           oe_fp.bmdm,
                           oe_fp.hth,
                           oe_fp.khddh,
                           COALESCE(oe_fp.sl, 0.0) AS sl,
                           COALESCE(oe_fp.je, 0.0) AS je,
                           COALESCE(oe_fp.se, 0.0) AS se,
                           COALESCE(oe_fp.cbje, 0.0) AS cbje,
                           oe_fp.dddjh,
                           oe_fp.ddxh,
                           oe_fp.xsddjh,
                           oe_fp.xsdxh,
                           oe_fp.xsdje,
                           oe_fp.xsdse
                      FROM oe_fp
                     WHERE djh = paraStrDjh
                     ORDER BY xh;
            BEGIN
                vStrPzlxdm := SUBSTR(paraStrDjh, 1, 4);
                vStrYear   := SUBSTR(paraStrDjh, 5, 4);
                vStrMonth  := SUBSTR(paraStrDjh, 9, 2);
                vIntPzno   := SUBSTR(paraStrDjh, 11, 5);
                IF paraIntIsNewBill = 1 THEN
                    IF paraIntIsAdding = 1 THEN
                        vStrStatement := 'SELECT ' || vStrPzlxdm || vStrYear ||
                                         vStrMonth || '.NEXTVAL FROM dual';
                        EXECUTE IMMEDIATE vStrStatement
                            INTO vIntPzno;
                        /*更新表rc_lx*/
                        vStrStatement := 'UPDATE rc_lx SET pzno' || vStrMonth || ' = ' ||
                                         vIntPzno || ' WHERE pzlxdm = ' || chr(39) ||
                                         vStrPzlxdm || chr(39) || ' AND kjnd = ' ||
                                         chr(39) || vStrYear || chr(39);
                        EXECUTE IMMEDIATE vStrStatement;
                        paraStrDjh := vStrPzlxdm || vStrYear || vStrMonth ||
                                      LPAD(vIntPzno, 5, '0');
                    ELSE
                        /*对已保存的单据负项处理*/
                        FOR vOe_fp IN vCursorOe_fp LOOP
                            vDblFpsl := vOe_fp.sl;
                            vDblFpje := vOe_fp.je;
                            vDblFpse := vOe_fp.se;
                            IF NOT vOe_fp.dddjh IS NULL AND vOe_fp.ddxh > 0 AND
                               vOe_fp.bdelete = 0 THEN
                                UPDATE oe_dd
                                   SET fpsl = fpsl - vOe_fp.sl,
                                       fpje = fpje - paraDblJe - paraDblSe
                                 WHERE djh = vOe_fp.dddjh
                                   AND xh = vOe_fp.ddxh;
                            END IF;
                            IF NOT vOe_fp.xsddjh IS NULL AND vOe_fp.xsdxh > 0 AND
                               vOe_fp.bdelete = 0 THEN
                                UPDATE oe_xsd
                                   SET fpsl = fpsl - vOe_fp.sl,
                                       fpje = fpje - paraDblJe - paraDblSe
                                 WHERE djh = vOe_fp.xsddjh
                                   AND xh = vOe_fp.xsdxh;
                            END IF;
                            IF vOe_fp.bdelete <> 1 THEN
                                UPDATE inv_fcspyeb
                                   SET idsl = idsl + vOe_fp.sl,
                                       idje = idje + vOe_fp.cbje
                                 WHERE kjnd = vStrYear
                                   AND cpdm = vOe_fp.cpdm
                                   AND khdm = vOe_fp.khdm
                                   AND bmdm = vOe_fp.bmdm;
                                UPDATE ar_khyeb
                                   SET idfpje = idfpje - vOe_fp.je - vOe_fp.se
                                 WHERE kjnd = vStrYear
                                   AND khdm = vOe_fp.khdm;
                            END IF;
                        END LOOP;
                        DELETE FROM oe_fp WHERE djh = paraStrDjh;
                    END IF;
                END IF;
                IF NOT paraStrDdDjh IS NULL AND paraIntDdXh > 0 AND paraBlnDelete = 0 THEN
                    UPDATE oe_dd
                       SET fpsl = fpsl + paraDblSl, fpje = fpje + paraDblJe + paraDblSe
                     WHERE djh = paraStrDdDjh
                       AND xh = paraIntDdXh;
                END IF;
                IF NOT paraStrXsdDjh IS NULL AND paraIntXsdXh > 0 AND paraBlnDelete = 0 THEN
                    UPDATE oe_xsd
                       SET fpsl = fpsl + paraDblSl, fpje = fpje + paraDblJe + paraDblSe
                     WHERE djh = paraStrXsdDjh
                       AND xh = paraIntXsdXh;
                END IF;
                IF paraBlnDelete <> 1 THEN
                    /*更新inv_fcspyeb表*/
                    IF NOT paraStrCpdm IS NULL AND NOT paraStrKhdm IS NULL AND
                       NOT paraStrBmdm IS NULL THEN
                        SELECT COUNT(1)
                          INTO vIntCount
                          FROM inv_fcspyeb
                         WHERE kjnd = vStrYear
                           AND cpdm = paraStrCpdm
                           AND khdm = paraStrKhdm
                           AND bmdm = paraStrBmdm;
                        IF vIntCount = 0 THEN
                            INSERT INTO inv_fcspyeb
                                (kjnd, cpdm, khdm, bmdm, qcsl, qcje, idsl, idje)
                            VALUES
                                (vStrYear,
                                 paraStrCpdm,
                                 paraStrKhdm,
                                 paraStrBmdm,
                                 0.0,
                                 0.0,
                                 0.0,
                                 0.0);
                        END IF;
                        UPDATE inv_fcspyeb
                           SET idsl = idsl - paraDblSl
                         WHERE kjnd = vStrYear
                           AND cpdm = paraStrCpdm
                           AND khdm = paraStrKhdm
                           AND bmdm = paraStrBmdm;
                    END IF;
    
                    IF NOT paraStrKhdm IS NULL THEN
                        /*更新ar_khyeb表*/
                        SELECT COUNT(1)
                          INTO vIntCount
                          FROM ar_khyeb
                         WHERE kjnd = vStrYear
                           AND khdm = paraStrKhdm;
                        IF vIntCount = 0 THEN
                            INSERT INTO ar_khyeb
                                (kjnd, khdm, khmc, qcje, idje, qcfpje, idfpje)
                            VALUES
                                (vStrYear,
                                 paraStrKhdm,
                                 paraStrKhmc,
                                 0.0,
                                 0.0,
                                 0.0,
                                 0.0);
                        END IF;
                        UPDATE ar_khyeb
                           SET idfpje = idfpje + paraDblJe + paraDblSe
                         WHERE kjnd = vStrYear
                           AND khdm = paraStrKhdm;
                    END IF;
                END IF;
                /*添加数据oe_fp*/
                INSERT INTO oe_fp
                    (djh,xh,fprq,bdelete,zydm,zymc,khdm,khmc,shkhdm,shkhmc,bmdm,bmmc,yspz,
                     cpdm,
                     cpmc,
                     hth,
                     khddh,
                     sl,
                     dw,
                     mjsl,
                     fzsl,
                     fzdw,
                     dj,
                     hsdj,
                     je,
                     shlv,
                     se,
                     fpmemo,
                     dddjh,
                     ddxh,
                     xsddjh,
                     xsdxh,
                     xsddj,
                     xsdhsdj,
                     xsdje,
                     xsdshlv,
                     xsdse,
                     srr,
                     srrq)
                VALUES
                    (paraStrDjh,
                     paraIntXh,
                     paraDateFprq,
                     paraBlnDelete,
                     paraStrZydm,
                     paraStrZymc,
                     paraStrKhdm,
                     paraStrKhmc,
                        paraStrShKhdm,
                        paraStrShKhmc,
                     paraStrBmdm,
                     paraStrBmmc,
                     paraStrYspz,
                     paraStrCpdm,
                     paraStrCpmc,
                     paraStrHth,
                     paraStrKhddh,
                     paraDblSl,
                     paraStrDw,
                     paraDblMjsl,
                     paraDblFzsl,
                     paraStrFzdw,
                     paraDblDj,
                     paraDblHsdj,
                     paraDblJe,
                     paraDblShlv,
                     paraDblSe,
                     paraStrFpmemo,
                     paraStrDdDjh,
                     paraIntDdXh,
                     paraStrXsdDjh,
                     paraIntXsdXh,
                     paraDblXsdDj,
                     paraDblXsdHsdj,
                     paraDblXsdJe,
                     paraDblXsdShlv,
                     paraDblXsdSe,
                     paraStrUserDspName,
                     SYSDATE());
            EXCEPTION
                WHEN OTHERS THEN
                    ROLLBACK;
                    paraStrMsg := '执行SQL语句错误，发生在USP3_SAVE_OE_FP' || SQLERRM;
            END USP3_SAVE_OE_FP;"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try

        '*****************************'
        '******rcdata_001*************'
        '*****USP3_SAVE_OE_XSD*********'
        '*****************************'
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '2020年3月收款单增加结算方式的字段
            '2025年6月增加传入参数IsNewBill，用于区分新增单据
            '2025年6月增加NC单据号与NC行号Vbillcode、Crowno
            rcOleDbCommand.CommandText = "CREATE OR REPLACE PROCEDURE USP3_SAVE_OE_XSD(paraIntIsAdding    IN INTEGER,
                                             paraIntIsNewBill   IN INTEGER,
                                             paraStrDjh         IN OUT VARCHAR2,
                                             paraIntXh          IN INTEGER,
                                             paraDateXsrq       IN DATE,
                                             paraBlnDelete      IN NUMERIC,
                                             paraStrZydm        IN VARCHAR2,
                                             paraStrZymc        IN VARCHAR2,
                                             ParaStrKhdm        IN VARCHAR2,
                                             paraStrKhmc        IN VARCHAR2,
                                             ParaStrFpKhdm        IN VARCHAR2,
                                             paraStrFpKhmc        IN VARCHAR2,
                                             ParaStrBmdm        IN VARCHAR2,
                                             paraStrBmmc        IN VARCHAR2,
                                             ParaStrCkdm        IN VARCHAR2,
                                             paraStrCkmc        IN VARCHAR2,
                                             ParaStrCpdm        IN VARCHAR2,
                                             paraStrCpmc        IN VARCHAR2,
                                             paraStrHth         IN VARCHAR2,
                                             paraStrKhddh       IN VARCHAR2,
                                             paraStrKhlh        IN VARCHAR2,
                                             paraStrPiHao       IN VARCHAR2,
                                             paraDblSl          IN NUMERIC,
                                             paraStrDw          IN VARCHAR2,
                                             paraDblMjsl        IN NUMERIC,
                                             paraDblFzsl        IN NUMERIC,
                                             paraStrFzdw        IN VARCHAR2,
                                             paraIntJs          IN INTEGER,
                                             paraDblLt          IN NUMERIC,
                                             paraIntTs          IN INTEGER,
                                             paraDblDj          IN NUMERIC,
                                             paraDblHsdj        IN NUMERIC,
                                             paraDblJe          IN NUMERIC,
                                             paraDblShlv        IN NUMERIC,
                                             paraDblSe          IN NUMERIC,
                                             paraStrXsmemo      IN VARCHAR2,
                                             paraStrDdDjh       IN VARCHAR2,
                                             paraIntDdXh        IN INTEGER,
                                             paraStrUserDspName IN VARCHAR2,
                                             paraCbill_bid      IN VARCHAR2,
                                             paraVbillcode      IN VARCHAR2,
                                             paraCrowno         IN VARCHAR2,
                                             paraStrMsg         OUT VARCHAR2) AS
  vStrPzlxdm    Char(4) := '';
  vStrYear      Char(4) := '';
  vStrMonth     Char(2) := '';
  vIntPzno      Integer(5) := 0;
  vStrStatement VARCHAR(200) := '';
  vIntCount     Integer(4) := 0;
  vDblCksl      NUMERIC(18, 6) := 0;
  vStrCpdm      VARCHAR(15) := '';
  vStrDddjh     VARCHAR(15) := '';
  vIntDdxh      Integer(5) := 0;
  Cursor vCursorOe_xsd Is
    SELECT oe_xsd.djh,
           oe_xsd.bdelete,
           oe_xsd.xh,
           oe_xsd.khdm,
           oe_xsd.ckdm,
           oe_xsd.cpdm,
           oe_xsd.hth,
           COALESCE(oe_xsd.sl, 0.0) As sl,
           COALESCE(oe_xsd.je, 0.0) As je,
           COALESCE(oe_xsd.cbje, 0.0) As cbje,
           oe_xsd.dddjh,
           oe_xsd.ddxh
      FROM oe_xsd
     WHERE djh = paraStrDjh
     ORDER BY xh;
BEGIN
  vStrPzlxdm := SUBSTR(paraStrDjh, 1, 4);
  vStrYear   := SUBSTR(paraStrDjh, 5, 4);
  vStrMonth  := SUBSTR(paraStrDjh, 9, 2);
  vIntPzno   := SUBSTR(paraStrDjh, 11, 5);
  If paraIntIsNewBill = 1 Then
    /*新增单据*/
    If paraIntIsAdding = 1 Then
      vStrStatement := 'SELECT ' || vStrPzlxdm || vStrYear || vStrMonth ||
                       '.NEXTVAL FROM dual';
      EXECUTE IMMEDIATE vStrStatement
        INTO vIntPzno;
      /*更新表rc_lx*/
      vStrStatement := 'UPDATE rc_lx SET pzno' || vStrMonth || ' = ' ||
                       vIntPzno || ' WHERE pzlxdm = ' || chr(39) ||
                       vStrPzlxdm || chr(39) || ' AND kjnd = ' || chr(39) ||
                       vStrYear || chr(39);
      EXECUTE IMMEDIATE vStrStatement;
      paraStrDjh := vStrPzlxdm || vStrYear || vStrMonth ||
                    LPAD(vIntPzno, 5, '0');
    ELSE
      /*对已保存的单据负项处理*/
      For vOe_xsd IN vCursorOe_xsd LOOP
        If Not vOe_xsd.hth Is NULL And vOe_xsd.bdelete <> 1 Then
          vDblCksl := vOe_xsd.sl;
          --vStrHth := vOe_xsd.hth;  
          vStrCpdm := vOe_xsd.cpdm;
          If Not vOe_xsd.dddjh Is NULL And vOe_xsd.ddxh > 0 Then
            Update oe_dd
               SET cksl = cksl - vOe_xsd.sl
             WHERE djh = vOe_xsd.dddjh
               And xh = vOe_xsd.ddxh;
          End If;
          IF vDblCksl <> 0 THEN
            Update oe_dd
               SET ceck = ceck - vDblCksl
             WHERE djh = vStrDddjh
               And xh = vIntDdxh;
          End If;
        End If;
        If vOe_xsd.bdelete <> 1 Then
          Update inv_cpyeb
             Set idsl = idsl + vOe_xsd.sl, idje = idje + vOe_xsd.cbje
           WHERE kjnd = vStrYear
             And cpdm = vOe_xsd.cpdm
             And ckdm = vOe_xsd.ckdm;
          Update ar_khyeb
             SET idje = idje - vOe_xsd.je
           WHERE kjnd = vStrYear
             And khdm = vOe_xsd.khdm;
        End If;
      End Loop;
      DELETE From oe_xsd Where djh = paraStrDjh;
    End If;
  End If;
  If Not paraStrDdDjh Is NULL And paraIntDdXh > 0 And paraBlnDelete = 0 Then
    Update oe_dd
       SET cksl = cksl + paraDblSl
     WHERE djh = paraStrDdDjh
       And xh = paraIntDdXh;
    Update oe_fhd
       Set cksl = cksl + paraDblSl
     WHERE TRUNC(fhrq, 'dd') = TRUNC(paraDateXsrq, 'dd')
       AND djh = paraStrDdDjh
       AND xh = paraIntDdXh;
  End If;
  If paraBlnDelete = 0 Then
    /*更新inv_cpyeb表*/
    If Not ParaStrCpdm Is NULL And Not ParaStrCkdm Is NULL Then
      Select COUNT(1)
        INTO vIntCount
        FROM inv_cpyeb
       WHERE kjnd = vStrYear
         And cpdm = ParaStrCpdm
         And ckdm = ParaStrCkdm;
      If vIntCount = 0 Then
        INSERT INTO inv_cpyeb
          (kjnd, cpdm, ckdm, qcsl, qcje, idsl, idje)
        VALUES
          (vStrYear, ParaStrCpdm, ParaStrCkdm, 0.0, 0.0, 0.0, 0.0);
      End If;
      Update inv_cpyeb
         SET idsl = idsl - paraDblSl
       WHERE kjnd = vStrYear
         And cpdm = ParaStrCpdm
         And ckdm = ParaStrCkdm;
    End If;
    /*更新inv_fcspyeb表*/
    IF NOT paraStrCpdm IS NULL AND NOT paraStrKhdm IS NULL AND
       NOT paraStrBmdm IS NULL THEN
      SELECT COUNT(1)
        INTO vIntCount
        FROM inv_fcspyeb
       WHERE kjnd = vStrYear
         AND cpdm = paraStrCpdm
         AND khdm = paraStrKhdm
         AND bmdm = paraStrBmdm;
      IF vIntCount = 0 THEN
        INSERT INTO inv_fcspyeb
          (kjnd, cpdm, khdm, bmdm, qcsl, qcje, idsl, idje)
        VALUES
          (vStrYear,
           paraStrCpdm,
           paraStrKhdm,
           paraStrBmdm,
           0.0,
           0.0,
           0.0,
           0.0);
      END IF;
      UPDATE inv_fcspyeb
         SET idsl = idsl - paraDblSl
       WHERE kjnd = vStrYear
         AND cpdm = paraStrCpdm
         AND khdm = paraStrKhdm
         AND bmdm = paraStrBmdm;
    END IF;
    /*更新ar_khyeb表*/
    If Not ParaStrKhdm Is NULL Then
      Select COUNT(1)
        INTO vIntCount
        FROM ar_khyeb
       WHERE kjnd = vStrYear
         And khdm = ParaStrKhdm;
      If vIntCount = 0 Then
        INSERT INTO ar_khyeb
          (kjnd, khdm, khmc, qcje, idje)
        VALUES
          (vStrYear, ParaStrKhdm, paraStrKhmc, 0.0, 0.0);
      End If;
      Update ar_khyeb
         SET idje = idje + paraDblJe
       WHERE kjnd = vStrYear
         And khdm = ParaStrKhdm;
    End If;
  End If;
  /*添加数据oe_xsd*/
  INSERT INTO oe_xsd
    (djh,
     xh,
     xsrq,
     bdelete,
     zydm,
     zymc,
     khdm,
     khmc,
        fpkhdm,
        fpkhmc,
     bmdm,
     bmmc,
     ckdm,
     ckmc,
     cpdm,
     cpmc,
     hth,
     khddh,
     khlh,
     pihao,
     sl,
     dw,
     mjsl,
     fzsl,
     fzdw,
     js,
     lt,
     ts,
     dj,
     hsdj,
     je,
     shlv,
     se,
     xsmemo,
     dddjh,
     ddxh,
     srr,
     cbill_bid,
     vbillcode,
     crowno)
  VALUES
    (paraStrDjh,
     paraIntXh,
     paraDateXsrq,
     paraBlnDelete,
     paraStrZydm,
     paraStrZymc,
     ParaStrKhdm,
     paraStrKhmc,
        ParaStrFpKhdm,
        paraStrFpKhmc,
     ParaStrBmdm,
     paraStrBmmc,
     ParaStrCkdm,
     paraStrCkmc,
     ParaStrCpdm,
     paraStrCpmc,
     paraStrHth,
     paraStrKhddh,
     paraStrKhlh,
     paraStrPiHao,
     paraDblSl,
     paraStrDw,
     paraDblMjsl,
     paraDblFzsl,
     paraStrFzdw,
     paraIntJs,
     paraDblLt,
     paraIntTs,
     paraDblDj,
     paraDblHsdj,
     paraDblJe,
     paraDblShlv,
     paraDblSe,
     paraStrXsmemo,
     paraStrDdDjh,
     paraIntDdXh,
     paraStrUserDspName,
     paraCbill_bid,
     paraVbillcode,
     paraCrowno);
Exception
  WHEN OTHERS THEN
    ROLLBACK;
    paraStrMsg := '执行SQL语句错误，发生在USP3_SAVE_OE_XSD' || sqlerrm;
End USP3_SAVE_OE_XSD;"

            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try

        '*****************************'
        '******rcdata_001*************'
        '*****USP3_SAVE_PO_RKD*********'
        '*****************************'
        Try
            rcOleDbConn.Open()
            rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.Transaction = rcOleDbTrans
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            '2020年3月收款单增加结算方式的字段
            rcOleDbCommand.CommandText = "CREATE Or Replace PROCEDURE USP3_SAVE_PO_RKD" &
                "(paraIntIsAdding IN INTEGER" &
                ", paraStrDjh IN OUT VARCHAR2" &
                ", paraIntXh IN INTEGER" &
                ", paraDateRkrq IN DATE" &
                ", paraBlnDelete IN NUMERIC" &
                ", paraStrZydm IN VARCHAR2" &
                ", paraStrZymc IN VARCHAR2" &
                ", paraStrCsdm IN VARCHAR2" &
                ", paraStrCsmc IN VARCHAR2" &
                ", paraStrYspz IN VARCHAR2" &
                ", ParaStrCkdm IN VARCHAR2" &
                ", paraStrCkmc IN VARCHAR2" &
                ", ParaStrCpdm IN VARCHAR2" &
                ", paraStrCpmc IN VARCHAR2" &
                ", paraStrKuwei IN VARCHAR2" &
                ", paraStrSgddh IN VARCHAR2" &
                ", paraStrPiHao IN VARCHAR2" &
                ", paraDblSl IN NUMERIC" &
                ", paraStrDw IN VARCHAR2" &
                ", paraDblMjsl IN NUMERIC" &
                ", paraDblFzsl IN NUMERIC" &
                ", paraStrFzdw IN VARCHAR2" &
                ", paraDblDj IN NUMERIC" &
                ", paraDblHsdj IN NUMERIC" &
                ", paraDblJe IN NUMERIC" &
                ", paraDblShlv IN NUMERIC" &
                ", paraDblSe IN NUMERIC" &
                ", paraStrRkmemo IN VARCHAR2" &
                ", paraStrCgdDjh IN VARCHAR2" &
                ", paraIntCgdXh IN INTEGER" &
                ", paraStrUserDspName IN VARCHAR2" &
                ", paraCbill_bid IN CHAR" &
                ", paraStrMsg OUT VARCHAR2" &
                ") AS " &
                "vStrPzlxdm Char(4):='';" &
                "vStrYear Char(4):='';" &
                "vStrMonth Char(2):='';" &
                "vIntPzno Integer(5):=0;" &
                "vStrStatement VARCHAR(200):='';" &
                "vIntCount Integer(4) := 0;" &
                "vDblRksl NUMERIC(18, 6) := 0;" &
                "vDblRkje NUMERIC(14, 2) := 0;" &
                "vDblRkse NUMERIC(14, 2) := 0;" &
                "vStrCpdm VARCHAR(15) := '';" &
                "Cursor vCursorPo_rkd Is SELECT po_rkd.bdelete, po_rkd.csdm, po_rkd.ckdm, po_rkd.xh, po_rkd.cpdm, po_rkd.cgddjh, po_rkd.cgdxh, COALESCE(po_rkd.sl, 0.0) As sl, COALESCE(po_rkd.je, 0.0) As je, COALESCE(po_rkd.se, 0.0) AS se FROM po_rkd WHERE djh = paraStrDjh ORDER BY xh;" &
                "/*红字入库单时根据后入先冲法更新采购入库单PO_RKD*/" &
                "Cursor vCursorPo_rkd1 Is SELECT po_rkd.djh, po_rkd.xh, po_rkd.ckdm, po_rkd.cpdm, po_rkd.csdm, po_rkd.sl, po_rkd.je, po_rkd.cksl, po_rkd.ckje FROM po_rkd WHERE po_rkd.sl > 0 And po_rkd.sl > po_rkd.cksl And po_rkd.bdelete = 0 And po_rkd.ckdm = ParaStrCkdm And po_rkd.cpdm = ParaStrCpdm And po_rkd.csdm = paraStrCsdm ORDER BY djh DESC, xh DESC;" &
                "/*修改红字入库单时根据后入先冲法更新采购入库单PO_RKD*/" &
                "Cursor vCursorPo_rkd2 Is SELECT po_rkd.djh, po_rkd.xh, po_rkd.ckdm, po_rkd.cpdm, po_rkd.csdm, po_rkd.sl, po_rkd.je, po_rkd.cksl, po_rkd.ckje FROM po_rkd WHERE po_rkd.sl > 0 And po_rkd.cksl <> 0 And po_rkd.bdelete = 0 And po_rkd.ckdm = ParaStrCkdm And po_rkd.cpdm = vStrCpdm And po_rkd.csdm = paraStrCsdm ORDER BY djh DESC, xh DESC;" &
                "BEGIN" &
                "    vStrPzlxdm := SUBSTR(paraStrDjh, 1, 4);" &
                "    vStrYear := SUBSTR(paraStrDjh, 5, 4);" &
                "    vStrMonth := SUBSTR(paraStrDjh, 9, 2);" &
                "    vIntPzno := SUBSTR(paraStrDjh, 11, 5);" &
                "    If paraIntXh = 1 Then" &
                "        If paraIntIsAdding = 1 Then" &
                "            vStrStatement := 'SELECT ' || vStrPzlxdm || vStrYear || vStrMonth || '.NEXTVAL FROM dual';" &
                "            EXECUTE IMMEDIATE vStrStatement INTO vIntPzno;" &
                "            /*更新表rc_lx*/" &
                "            vStrStatement := 'UPDATE rc_lx SET pzno' || vStrMonth ||' = ' || vIntPzno || ' WHERE pzlxdm = ' || chr(39) || vStrPzlxdm || chr(39) || ' AND kjnd = ' || chr(39) || vStrYear || chr(39) ;" &
                "            EXECUTE IMMEDIATE vStrStatement;" &
                "            paraStrDjh :=  vStrPzlxdm || vStrYear || vStrMonth || LPAD(vIntPzno, 5,'0');" &
                "        ELSE" &
                "            /*对已保存的单据负项处理*/" &
                "            For vPo_rkd IN vCursorPo_rkd LOOP" &
                "                vDblRksl := vPo_rkd.sl;" &
                "                vDblRkje := vPo_rkd.je;" &
                "                vDblRkse := vPo_rkd.se;" &
                "                vStrCpdm := vPo_rkd.cpdm;" &
                "                If Not vPo_rkd.cgddjh Is NULL And vPo_rkd.cgdxh > 0 And vPo_rkd.bdelete = 0 Then" &
                "                    Update po_cgd Set rksl = rksl - vPo_rkd.sl, rkje = rkje - vPo_rkd.je - vPo_rkd.se WHERE djh = vPo_rkd.cgddjh And xh = vPo_rkd.cgdxh;" &
                "                End If;" &
                "                /*冲回最后的入库单的出库数量,出库金额*/" &
                "                If vDblRksl < 0 And vPo_rkd.bdelete = 0 Then" &
                "                    For vPo_rkd2 IN vCursorPo_rkd2 LOOP" &
                "                        If vPo_rkd2.cksl >= 0 - vDblRksl Then" &
                "                                    Update po_rkd Set cksl = cksl + vDblRksl, ckje = ckje + vDblRkje  WHERE djh = vPo_rkd2.djh And xh = vPo_rkd2.xh;" &
                "                            vDblRksl := 0.0;" &
                "                            vDblRkje := 0.0;" &
                "                        Else" &
                "                                    Update po_rkd Set cksl = 0 , ckje = 0 WHERE djh = vPo_rkd2.djh And xh = vPo_rkd2.xh;" &
                "                            vDblRksl := vDblRksl + vPo_rkd2.cksl;" &
                "                            vDblRkje := vDblRkje + vPo_rkd2.ckje;" &
                "                        End If;" &
                "                        If vDblRksl = 0.0 And vDblRkje = 0.0 Then" &
                "                                    Exit;" &
                "                        End If;" &
                "                    End Loop;" &
                "                End If;" &
                "                If vPo_rkd.bdelete = 0 Then" &
                "                            Update inv_cpyeb Set idsl = idsl - vPo_rkd.sl, idje = idje - vPo_rkd.je WHERE kjnd = vStrYear And cpdm = vPo_rkd.cpdm And ckdm = vPo_rkd.ckdm;" &
                "                    Update ap_csyeb SET idje = idje - vPo_rkd.je - vPo_rkd.se WHERE kjnd = vStrYear And csdm = vPo_rkd.csdm;" &
                "                End If;" &
                "            End Loop;" &
                "            DELETE From po_rkd Where djh = paraStrDjh;" &
                "        End If;" &
                "    End If;" &
                "    If Not paraStrCgdDjh Is NULL And paraIntCgdXh > 0 And paraBlnDelete = 0 Then" &
                "        Update po_cgd Set rksl = rksl + paraDblSl, rkje = rkje + paraDblJe + paraDblSe WHERE djh = paraStrCgdDjh And xh = paraIntCgdXh;" &
                "    End If;" &
                "    If Not ParaStrCpdm Is NULL And Not ParaStrCkdm Is NULL And paraBlnDelete = 0 Then" &
                "        /*更新inv_cpyeb表*/" &
                "        Select COUNT(1) INTO vIntCount FROM inv_cpyeb WHERE kjnd = vStrYear And cpdm = ParaStrCpdm And ckdm = ParaStrCkdm;" &
                "        If vIntCount = 0 Then" &
                "                        INSERT INTO inv_cpyeb (kjnd, cpdm, ckdm, qcsl, qcje, idsl, idje) VALUES (vStrYear,ParaStrCpdm,ParaStrCkdm,0.0,0.0,0.0,0.0);" &
                "        End If;" &
                "        Update inv_cpyeb Set idsl = idsl + paraDblSl , idje = idje + paraDblJe WHERE kjnd = vStrYear And cpdm = ParaStrCpdm And ckdm = ParaStrCkdm;" &
                "    End If;" &
                "    If Not paraStrCsdm Is NULL And paraBlnDelete = 0 Then" &
                "        /*更新ar_khyeb表*/" &
                "        Select COUNT(1) INTO vIntCount FROM ap_csyeb WHERE kjnd = vStrYear And csdm = paraStrCsdm;" &
                "        If vIntCount = 0 Then" &
                "            INSERT INTO ap_csyeb (kjnd, csdm, csmc, qcje, idje) VALUES (vStrYear,paraStrCsdm,paraStrCsmc,0.0,0.0);" &
                "        End If;" &
                "        Update ap_csyeb SET idje = idje + paraDblJe + paraDblSe WHERE kjnd = vStrYear And csdm = paraStrCsdm;" &
                "    End If;" &
                "    /*添加数据po_rkd*/" &
                "    INSERT INTO po_rkd (djh, xh, rkrq, bdelete, zydm, zymc, csdm, csmc, yspz, ckdm, ckmc, cpdm, cpmc, kuwei, sgddh, pihao, sl, dw, mjsl, fzsl, fzdw, dj, hsdj, je, shlv, se, rkmemo, cgddjh, cgdxh, srr,cbill_bid, srrq) VALUES (paraStrDjh,paraIntXh,paraDateRkrq,paraBlnDelete,paraStrZydm,paraStrZymc,paraStrCsdm,paraStrCsmc,paraStrYspz,ParaStrCkdm,paraStrCkmc,ParaStrCpdm,paraStrCpmc,paraStrKuwei,paraStrSgddh,paraStrPiHao,paraDblSl,paraStrDw,paraDblMjsl,paraDblFzsl,paraStrFzdw,paraDblDj,paraDblHsdj,paraDblJe,paraDblShlv,paraDblSe,paraStrRkmemo,paraStrCgdDjh,paraIntCgdXh,paraStrUserDspName,paraCbill_bid,SYSDATE);" &
                "    If paraDblSl < 0 And paraBlnDelete = 0 Then" &
                "        /*红字入库单时根据后出先冲法更新采购入库单PO_RKD*/" &
                "        vDblRksl := paraDblSl;" &
                "        vDblRkje := paraDblJe;" &
                "        For vPo_rkd1 IN vCursorPo_rkd1 LOOP" &
                "            If vPo_rkd1.sl - vPo_rkd1.cksl >= 0 - vDblRksl Then" &
                "                Update po_rkd Set cksl = cksl - vDblRksl, ckje = ckje - vDblRkje  WHERE djh = vPo_rkd1.djh And xh = vPo_rkd1.xh;" &
                "                vDblRksl := 0.0;" &
                "                vDblRkje := 0.0;" &
                "            Else" &
                "                Update po_rkd Set cksl = sl , ckje = je WHERE djh = vPo_rkd1.djh And xh = vPo_rkd1.xh;" &
                "                vDblRksl := vDblRksl + vPo_rkd1.sl - vPo_rkd1.cksl;" &
                "                vDblRkje := vDblRkje + vPo_rkd1.je - vPo_rkd1.ckje;" &
                "            End If;" &
                "            If vDblRksl = 0.0 And vDblRkje = 0.0 Then" &
                "                Exit;" &
                "            End If;" &
                "        End Loop;" &
                "        /*更新自已的出库数量*/" &
                "        Update po_rkd Set cksl = paraDblSl , ckje = paraDblJe WHERE djh = paraStrDjh And xh = paraIntXh;" &
                "    End If;" &
                "    Update rc_cpxx SET cgdj = paraDblDj WHERE cpdm = ParaStrCpdm And paraDblDj <> 0;" &
                "    Exception" &
                "        WHEN OTHERS THEN" &
                "        ROLLBACK;" &
                "        paraStrMsg := '执行SQL语句错误，发生在SP_SAVE_PO_RKD'||sqlerrm;" &
                "End USP3_SAVE_PO_RKD;"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.ExecuteNonQuery()
            rcOleDbTrans.Commit()
        Catch ex As Exception
            Try
                rcOleDbTrans.Rollback()
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Catch ey As OleDbException
                MsgBox("程序错误。" & Chr(13) & ey.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
            Return
        Finally
            rcOleDbConn.Close()
        End Try


    End Sub
End Class