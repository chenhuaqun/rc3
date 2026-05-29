Imports System.Data.OleDb
Imports System.Text

Module MdlMenuMigration

    Public Function RunMenuMigration() As Boolean
        Try
            If IsMigrationDone() Then Return True

            sysOleDbConn.Open()
            Dim cmd As OleDbCommand = sysOleDbConn.CreateCommand()
            cmd.CommandTimeout = 300
            cmd.CommandType = CommandType.Text

            If Not ExecuteSqlScript(cmd, GetMigrationSql()) Then Return False
            If Not ExecuteSqlScript(cmd, GetInitDataSql()) Then Return False
            If Not ExecuteSqlScript(cmd, GetUpdateDataSql()) Then Return False

            Return True
        Catch ex As Exception
            MsgBox("菜单数据迁移失败：" & ex.Message, MsgBoxStyle.Exclamation, "提示")
            Return False
        Finally
            If sysOleDbConn.State = ConnectionState.Open Then
                sysOleDbConn.Close()
            End If
        End Try
    End Function

    Private Function IsMigrationDone() As Boolean
        Try
            sysOleDbConn.Open()
            Using cmd As OleDbCommand = sysOleDbConn.CreateCommand()
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT COUNT(*) FROM user_tab_columns WHERE table_name = 'RC_MENU' AND column_name = 'MNUPARENTID'"
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                Return count > 0
            End Using
        Catch
            Return False
        Finally
            If sysOleDbConn.State = ConnectionState.Open Then
                sysOleDbConn.Close()
            End If
        End Try
    End Function

    Private Function ExecuteSqlScript(cmd As OleDbCommand, sqlContent As String) As Boolean
        Dim statements As String() = sqlContent.Split({";"c}, StringSplitOptions.RemoveEmptyEntries)
        For Each stmt As String In statements
            Dim sql As String = stmt.Trim()
            If String.IsNullOrEmpty(sql) Then Continue For
            If sql.StartsWith("--") Then Continue For
            If sql.ToUpperInvariant() = "COMMIT" Then Continue For

            cmd.CommandText = sql
            cmd.Parameters.Clear()
            cmd.ExecuteNonQuery()
        Next
        Return True
    End Function

    Private Function GetMigrationSql() As String
        Dim sb As New StringBuilder()
        sb.AppendLine("ALTER TABLE rc_menu ADD (mnuparentid VARCHAR2(4) DEFAULT '0');")
        sb.AppendLine("ALTER TABLE rc_menu ADD (mnusortorder NUMBER(10) DEFAULT 0);")
        sb.AppendLine("ALTER TABLE rc_menu ADD (mnuformname VARCHAR2(100));")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '0', mnusortorder = 10 WHERE mnuiid = '10' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '0', mnusortorder = 20 WHERE mnuiid = '20' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '0', mnusortorder = 30 WHERE mnuiid = '30' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '0', mnusortorder = 40 WHERE mnuiid = '40' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '0', mnusortorder = 50 WHERE mnuiid = '50' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '0', mnusortorder = 60 WHERE mnuiid = '60' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '0', mnusortorder = 70 WHERE mnuiid = '70' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '0', mnusortorder = 80 WHERE mnuiid = '80' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '0', mnusortorder = 90 WHERE mnuiid = '90' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '0', mnusortorder = 99 WHERE mnuiid = '99' AND mnuiown = 'RC3';")
        sb.AppendLine("COMMIT;")
        Return sb.ToString()
    End Function

    Private Function GetInitDataSql() As String
        Dim sb As New StringBuilder()
        sb.AppendLine("DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '10';")
        sb.AppendLine("INSERT INTO rc_menu (mnuiid,mnuparentid,mnuicaption,mnuiname,mnuiown,mnusortorder,mnuformname) VALUES ('10','0','系统设置(&B)','MnuiBase','RC3',10,NULL);")
        sb.AppendLine("DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '20';")
        sb.AppendLine("INSERT INTO rc_menu (mnuiid,mnuparentid,mnuicaption,mnuiname,mnuiown,mnusortorder,mnuformname) VALUES ('20','0','销售(&OE)','MnuiOe','RC3',20,NULL);")
        sb.AppendLine("DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '30';")
        sb.AppendLine("INSERT INTO rc_menu (mnuiid,mnuparentid,mnuicaption,mnuiname,mnuiown,mnusortorder,mnuformname) VALUES ('30','0','生产(P&M)','MnuiPm','RC3',30,NULL);")
        sb.AppendLine("DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '40';")
        sb.AppendLine("INSERT INTO rc_menu (mnuiid,mnuparentid,mnuicaption,mnuiname,mnuiown,mnusortorder,mnuformname) VALUES ('40','0','采购(&PO)','MnuiPo','RC3',40,NULL);")
        sb.AppendLine("DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '50';")
        sb.AppendLine("INSERT INTO rc_menu (mnuiid,mnuparentid,mnuicaption,mnuiname,mnuiown,mnusortorder,mnuformname) VALUES ('50','0','库存(&INV)','MnuiInv','RC3',50,NULL);")
        sb.AppendLine("DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '60';")
        sb.AppendLine("INSERT INTO rc_menu (mnuiid,mnuparentid,mnuicaption,mnuiname,mnuiown,mnusortorder,mnuformname) VALUES ('60','0','财务(&F)','MnuiArAp','RC3',60,NULL);")
        sb.AppendLine("DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '70';")
        sb.AppendLine("INSERT INTO rc_menu (mnuiid,mnuparentid,mnuicaption,mnuiname,mnuiown,mnusortorder,mnuformname) VALUES ('70','0','成本(&CM)','MnuiCb','RC3',70,NULL);")
        sb.AppendLine("DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '80';")
        sb.AppendLine("INSERT INTO rc_menu (mnuiid,mnuparentid,mnuicaption,mnuiname,mnuiown,mnusortorder,mnuformname) VALUES ('80','0','总账(&GL)','MnuiGl','RC3',80,NULL);")
        sb.AppendLine("DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '90';")
        sb.AppendLine("INSERT INTO rc_menu (mnuiid,mnuparentid,mnuicaption,mnuiname,mnuiown,mnusortorder,mnuformname) VALUES ('90','0','期末(&T)','MnuiYwf','RC3',90,NULL);")
        sb.AppendLine("DELETE FROM rc_menu WHERE mnuiown = 'RC3' AND mnuiid = '99';")
        sb.AppendLine("INSERT INTO rc_menu (mnuiid,mnuparentid,mnuicaption,mnuiname,mnuiown,mnusortorder,mnuformname) VALUES ('99','0','系统服务(&S)','MnuiSys','RC3',99,NULL);")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 1, mnuformname = 'FrmCplbxx' WHERE mnuiid = '1001' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 2, mnuformname = 'FrmCpGroup' WHERE mnuiid = '1002' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 3, mnuformname = 'FrmCpxx' WHERE mnuiid = '1003' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 4, mnuformname = 'FrmBom' WHERE mnuiid = '1004' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 5, mnuformname = 'FrmKhlbxx' WHERE mnuiid = '1005' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 6, mnuformname = 'FrmKhxx' WHERE mnuiid = '1006' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 7, mnuformname = 'FrmKhshdzxx' WHERE mnuiid = '1007' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 8, mnuformname = 'FrmKhzyxx' WHERE mnuiid = '1008' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 9, mnuformname = 'FrmCslbxx' WHERE mnuiid = '1009' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 10, mnuformname = 'FrmCsxx' WHERE mnuiid = '1010' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 11, mnuformname = 'FrmBmxx' WHERE mnuiid = '1011' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 12, mnuformname = 'FrmZyxx' WHERE mnuiid = '1012' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 13, mnuformname = 'FrmCkxx' WHERE mnuiid = '1013' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 14, mnuformname = 'FrmCostRegionxx' WHERE mnuiid = '1014' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 15, mnuformname = 'FrmJldwxx' WHERE mnuiid = '1015' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 16, mnuformname = 'FrmGxxx' WHERE mnuiid = '1016' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 17, mnuformname = 'FrmKmxx' WHERE mnuiid = '1017' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 18, mnuformname = 'FrmJsfsxx' WHERE mnuiid = '1018' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 19, mnuformname = 'FrmWbxx' WHERE mnuiid = '1019' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 20, mnuformname = 'FrmKcZlxx' WHERE mnuiid = '1020' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 21, mnuformname = 'FrmQccpyeSr' WHERE mnuiid = '1021' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 22, mnuformname = 'FrmQcfcspyeSr' WHERE mnuiid = '1022' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 23, mnuformname = 'FrmQckhyeSr' WHERE mnuiid = '1023' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 24, mnuformname = 'FrmQccsyeSr' WHERE mnuiid = '1024' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 25, mnuformname = 'FrmQckmyeSr' WHERE mnuiid = '1025' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 26, mnuformname = 'FrmPzlxxx' WHERE mnuiid = '1026' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 27, mnuformname = 'FrmKjqj' WHERE mnuiid = '1027' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '99', mnusortorder = 1, mnuformname = 'FrmRoles' WHERE mnuiid = '1028' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '99', mnusortorder = 2, mnuformname = 'FrmUsers' WHERE mnuiid = '1029' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '99', mnusortorder = 3, mnuformname = 'FrmOption' WHERE mnuiid = '1030' AND mnuiown = 'RC3';")
        sb.AppendLine("COMMIT;")
        Return sb.ToString()
    End Function

    Private Function GetUpdateDataSql() As String
        Dim sb As New StringBuilder()
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '0', mnusortorder = 10, mnuformname = NULL WHERE mnuiid = '10' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '0', mnusortorder = 20, mnuformname = NULL WHERE mnuiid = '20' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '0', mnusortorder = 30, mnuformname = NULL WHERE mnuiid = '30' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '0', mnusortorder = 40, mnuformname = NULL WHERE mnuiid = '40' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '0', mnusortorder = 50, mnuformname = NULL WHERE mnuiid = '50' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '0', mnusortorder = 60, mnuformname = NULL WHERE mnuiid = '60' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '0', mnusortorder = 70, mnuformname = NULL WHERE mnuiid = '70' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '0', mnusortorder = 80, mnuformname = NULL WHERE mnuiid = '80' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '0', mnusortorder = 90, mnuformname = NULL WHERE mnuiid = '90' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '0', mnusortorder = 99, mnuformname = NULL WHERE mnuiid = '99' AND mnuiown = 'RC3';")

        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 1, mnuformname = 'FrmCplbxx' WHERE mnuiid = '1001' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 2, mnuformname = 'FrmCpGroup' WHERE mnuiid = '1002' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 3, mnuformname = 'FrmCpxx' WHERE mnuiid = '1003' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 4, mnuformname = 'FrmBom' WHERE mnuiid = '1004' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 5, mnuformname = 'FrmKhlbxx' WHERE mnuiid = '1005' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 6, mnuformname = 'FrmKhXslbxx' WHERE mnuiid = '1006' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 7, mnuformname = 'FrmKhxx' WHERE mnuiid = '1007' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 8, mnuformname = 'FrmKhshdzxx' WHERE mnuiid = '1008' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 9, mnuformname = 'FrmKhzyxx' WHERE mnuiid = '1009' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 10, mnuformname = 'FrmCslbxx' WHERE mnuiid = '1010' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 11, mnuformname = 'FrmCsxx' WHERE mnuiid = '1011' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 12, mnuformname = 'FrmBmxx' WHERE mnuiid = '1012' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 13, mnuformname = 'FrmZyxx' WHERE mnuiid = '1013' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 14, mnuformname = 'FrmCkxx' WHERE mnuiid = '1014' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 15, mnuformname = 'FrmCostRegionxx' WHERE mnuiid = '1015' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 16, mnuformname = 'FrmJldwxx' WHERE mnuiid = '1016' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 17, mnuformname = 'FrmGxxx' WHERE mnuiid = '1017' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 18, mnuformname = 'FrmKmxx' WHERE mnuiid = '1018' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 19, mnuformname = 'FrmJsfsxx' WHERE mnuiid = '1019' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 20, mnuformname = 'FrmWbxx' WHERE mnuiid = '1020' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 21, mnuformname = 'FrmKcZlxx' WHERE mnuiid = '1021' AND mnuiown = 'RC3';")

        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 22, mnuformname = 'FrmQccpyeSr' WHERE mnuiid = '1022' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 23, mnuformname = 'FrmQcfcspyeSr' WHERE mnuiid = '1023' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 24, mnuformname = 'FrmQckhyeSr' WHERE mnuiid = '1024' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 25, mnuformname = 'FrmQccsyeSr' WHERE mnuiid = '1025' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 26, mnuformname = 'FrmQckmyeSr' WHERE mnuiid = '1026' AND mnuiown = 'RC3';")

        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 27, mnuformname = 'FrmPzlxxx' WHERE mnuiid = '1027' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '10', mnusortorder = 28, mnuformname = 'FrmKjqj' WHERE mnuiid = '1028' AND mnuiown = 'RC3';")

        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '99', mnusortorder = 1, mnuformname = 'FrmRoles' WHERE mnuiid = '1029' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '99', mnusortorder = 2, mnuformname = 'FrmUsers' WHERE mnuiid = '1030' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '99', mnusortorder = 3, mnuformname = 'FrmOption' WHERE mnuiid = '1031' AND mnuiown = 'RC3';")

        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 1, mnuformname = 'FrmOeYpddSr' WHERE mnuiid = '2001' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 2, mnuformname = 'FrmOeYpddBmSr' WHERE mnuiid = '2002' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 3, mnuformname = 'FrmOeYpddJqSr' WHERE mnuiid = '2003' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 4, mnuformname = 'FrmOeYpddSh' WHERE mnuiid = '2004' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 5, mnuformname = 'FrmOeYpFhrqSr' WHERE mnuiid = '2005' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 6, mnuformname = 'FrmOeYpFhdhSr' WHERE mnuiid = '2006' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 7, mnuformname = 'FrmOeYpddHx' WHERE mnuiid = '2007' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 8, mnuformname = 'FrmOeYpddCx' WHERE mnuiid = '2008' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 9, mnuformname = 'FrmOeYpddDjb' WHERE mnuiid = '2009' AND mnuiown = 'RC3';")

        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 10, mnuformname = 'FrmOeBjdSr' WHERE mnuiid = '2010' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 11, mnuformname = 'FrmOeBjdSh' WHERE mnuiid = '2011' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 12, mnuformname = 'FrmOeBjdCx' WHERE mnuiid = '2012' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 13, mnuformname = 'FrmOeDdSr' WHERE mnuiid = '2013' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 14, mnuformname = 'FrmOeDddjSh' WHERE mnuiid = '2014' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 15, mnuformname = 'FrmOeDdClose' WHERE mnuiid = '2015' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 16, mnuformname = 'FrmOeDdJqSr' WHERE mnuiid = '2016' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 17, mnuformname = 'FrmOeDdSh' WHERE mnuiid = '2017' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 18, mnuformname = 'FrmOeRkdSr' WHERE mnuiid = '2018' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 19, mnuformname = 'FrmOeRkdSh' WHERE mnuiid = '2019' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 20, mnuformname = 'FrmOeFhdSr' WHERE mnuiid = '2020' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 21, mnuformname = 'FrmOeFhdSh' WHERE mnuiid = '2021' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 22, mnuformname = 'FrmOeXsdSr' WHERE mnuiid = '2022' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 23, mnuformname = 'FrmOeXsdSh' WHERE mnuiid = '2023' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 24, mnuformname = 'FrmOeXsdHx' WHERE mnuiid = '2024' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 25, mnuformname = 'FrmOeFpSr' WHERE mnuiid = '2025' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 26, mnuformname = 'FrmOeFpSh' WHERE mnuiid = '2026' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 27, mnuformname = 'FrmOeDdCx' WHERE mnuiid = '2027' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 28, mnuformname = 'FrmOeRkdCx' WHERE mnuiid = '2028' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 29, mnuformname = 'FrmOeFhdCx' WHERE mnuiid = '2029' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 30, mnuformname = 'FrmOeXsdCx' WHERE mnuiid = '2030' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 31, mnuformname = 'FrmOeFpCx' WHERE mnuiid = '2031' AND mnuiown = 'RC3';")

        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 32, mnuformname = 'FrmOeRkCpHzb' WHERE mnuiid = '2032' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 33, mnuformname = 'FrmOeRkBmHzb' WHERE mnuiid = '2033' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 34, mnuformname = 'FrmOeXsRb' WHERE mnuiid = '2034' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 35, mnuformname = 'FrmOeCplbHzb' WHERE mnuiid = '2035' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 36, mnuformname = 'FrmOeBmHzb' WHERE mnuiid = '2036' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 37, mnuformname = 'FrmOeCpHzb' WHERE mnuiid = '2037' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 38, mnuformname = 'FrmOeCkCpHzb' WHERE mnuiid = '2038' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 39, mnuformname = 'FrmOeKhHzb' WHERE mnuiid = '2039' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 40, mnuformname = 'FrmOeZyHzb' WHERE mnuiid = '2040' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 41, mnuformname = 'FrmOeBmFpHzb' WHERE mnuiid = '2041' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 42, mnuformname = 'FrmOeCpFpHzb' WHERE mnuiid = '2042' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 43, mnuformname = 'FrmOeKhFpHzb' WHERE mnuiid = '2043' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '20', mnusortorder = 44, mnuformname = 'FrmOeKhFpFxb' WHERE mnuiid = '2044' AND mnuiown = 'RC3';")

        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '30', mnusortorder = 1, mnuformname = 'FrmPmDdSr' WHERE mnuiid = '3001' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '30', mnusortorder = 2, mnuformname = 'FrmPmDdClose' WHERE mnuiid = '3002' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '30', mnusortorder = 3, mnuformname = 'FrmPmScGxlzk' WHERE mnuiid = '3003' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '30', mnusortorder = 4, mnuformname = 'FrmPmDdGxPg' WHERE mnuiid = '3004' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '30', mnusortorder = 5, mnuformname = 'FrmPmDdGxHb' WHERE mnuiid = '3005' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '30', mnusortorder = 6, mnuformname = 'FrmPmCkdSr' WHERE mnuiid = '3006' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '30', mnusortorder = 7, mnuformname = 'FrmPmCkdSh' WHERE mnuiid = '3007' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '30', mnusortorder = 8, mnuformname = 'FrmPmRkdSr' WHERE mnuiid = '3008' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '30', mnusortorder = 9, mnuformname = 'FrmPmRkdSh' WHERE mnuiid = '3009' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '30', mnusortorder = 10, mnuformname = 'FrmPmCkdCx' WHERE mnuiid = '3010' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '30', mnusortorder = 11, mnuformname = 'FrmPmRkdCx' WHERE mnuiid = '3011' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '30', mnusortorder = 12, mnuformname = 'FrmPmDdGxlzCx' WHERE mnuiid = '3012' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '30', mnusortorder = 13, mnuformname = 'FrmPmRkCpHzb' WHERE mnuiid = '3013' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '30', mnusortorder = 14, mnuformname = 'FrmPmBmRkHzb' WHERE mnuiid = '3014' AND mnuiown = 'RC3';")

        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 1, mnuformname = 'FrmPoCgjhSr' WHERE mnuiid = '4001' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 2, mnuformname = 'FrmPoCgjhSh' WHERE mnuiid = '4002' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 3, mnuformname = 'FrmPoCgjhClose' WHERE mnuiid = '4003' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 4, mnuformname = 'FrmCsCpCgdjSr' WHERE mnuiid = '4004' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 5, mnuformname = 'FrmCsCpCgdjSh' WHERE mnuiid = '4005' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 6, mnuformname = 'FrmPoCgdSr' WHERE mnuiid = '4006' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 7, mnuformname = 'FrmPoCgdSh' WHERE mnuiid = '4007' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 8, mnuformname = 'FrmPoCgdClose' WHERE mnuiid = '4008' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 9, mnuformname = 'FrmPoRkdSr' WHERE mnuiid = '4009' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 10, mnuformname = 'FrmPoRkdSh' WHERE mnuiid = '4011' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 11, mnuformname = 'FrmPoFpSr' WHERE mnuiid = '4012' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 12, mnuformname = 'FrmPoFpSh' WHERE mnuiid = '4013' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 13, mnuformname = 'FrmPoLlsqSr' WHERE mnuiid = '4014' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 14, mnuformname = 'FrmPoLlsqSh' WHERE mnuiid = '4015' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 15, mnuformname = 'FrmPoLlsqClose' WHERE mnuiid = '4016' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 16, mnuformname = 'FrmInvRecycleSr' WHERE mnuiid = '4010' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 17, mnuformname = 'FrmPoCkdSr' WHERE mnuiid = '4017' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 18, mnuformname = 'FrmPoCkdSr2' WHERE mnuiid = '4018' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 19, mnuformname = 'FrmPoCkdSh' WHERE mnuiid = '4019' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 20, mnuformname = 'FrmInvDbdSr' WHERE mnuiid = '4020' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 21, mnuformname = 'FrmInvDbdSh' WHERE mnuiid = '4021' AND mnuiown = 'RC3';")

        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 22, mnuformname = 'FrmPoCgjhCx' WHERE mnuiid = '4022' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 23, mnuformname = 'FrmCsCpCgdjCx' WHERE mnuiid = '4023' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 24, mnuformname = 'FrmPoCgdCx' WHERE mnuiid = '4024' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 25, mnuformname = 'FrmPoRkdCx' WHERE mnuiid = '4025' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 26, mnuformname = 'FrmPoFpCx' WHERE mnuiid = '4026' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 27, mnuformname = 'FrmPoLlsqCx' WHERE mnuiid = '4027' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 28, mnuformname = 'FrmPoCkdCx' WHERE mnuiid = '4028' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 29, mnuformname = 'FrmInvDbdCx' WHERE mnuiid = '4029' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 30, mnuformname = 'FrmPoCsHzb' WHERE mnuiid = '4030' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 31, mnuformname = 'FrmPoBmHzb' WHERE mnuiid = '4031' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 32, mnuformname = 'FrmPoBmFaLbHzb' WHERE mnuiid = '4032' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 33, mnuformname = 'FrmCkCkCpHzb' WHERE mnuiid = '4033' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '40', mnusortorder = 34, mnuformname = 'FrmCkDbCpHzb' WHERE mnuiid = '4034' AND mnuiown = 'RC3';")

        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '50', mnusortorder = 1, mnuformname = 'FrmInvCktzSr' WHERE mnuiid = '5001' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '50', mnusortorder = 2, mnuformname = 'FrmInvPcSr' WHERE mnuiid = '5002' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '50', mnusortorder = 3, mnuformname = 'FrmFcspSr' WHERE mnuiid = '5003' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '50', mnusortorder = 4, mnuformname = 'FrmInvPcSh' WHERE mnuiid = '5004' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '50', mnusortorder = 5, mnuformname = 'FrmSlSfcMx' WHERE mnuiid = '5005' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '50', mnusortorder = 6, mnuformname = 'FrmSlSfcHz' WHERE mnuiid = '5006' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '50', mnusortorder = 7, mnuformname = 'FrmCpPcb' WHERE mnuiid = '5007' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '50', mnusortorder = 8, mnuformname = 'FrmCpSfcMx' WHERE mnuiid = '5008' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '50', mnusortorder = 9, mnuformname = 'FrmCpSfcHz' WHERE mnuiid = '5009' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '50', mnusortorder = 10, mnuformname = 'FrmJeSfcHz' WHERE mnuiid = '5010' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '50', mnusortorder = 11, mnuformname = 'FrmPhSfcMx' WHERE mnuiid = '5011' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '50', mnusortorder = 12, mnuformname = 'FrmPhSfcHz' WHERE mnuiid = '5012' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '50', mnusortorder = 13, mnuformname = 'FrmCplbSfcHz' WHERE mnuiid = '5013' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '50', mnusortorder = 14, mnuformname = 'FrmCpkcZlfx' WHERE mnuiid = '5014' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '50', mnusortorder = 15, mnuformname = 'FrmFcspPcb' WHERE mnuiid = '5015' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '50', mnusortorder = 16, mnuformname = 'FrmFcspSfcMx' WHERE mnuiid = '5016' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '50', mnusortorder = 17, mnuformname = 'FrmFcspSfcHz' WHERE mnuiid = '5017' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '50', mnusortorder = 18, mnuformname = 'FrmFcspKhSfcHz' WHERE mnuiid = '5018' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '50', mnusortorder = 19, mnuformname = 'FrmFcspBmSfcHz' WHERE mnuiid = '5019' AND mnuiown = 'RC3';")
        sb.AppendLine("UPDATE rc_menu SET mnuparentid = '50', mnusortorder = 20, mnuformname = 'FrmFcspCx' WHERE mnuiid = '5020' AND mnuiown = 'RC3';")
        sb.AppendLine("COMMIT;")
        Return sb.ToString()
    End Function

End Module
