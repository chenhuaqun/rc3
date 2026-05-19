Imports System.Data.OleDb

Public Class FrmFcspCx
    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '建立命令
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()

    Private Sub FrmFcspCx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '默认值
        Me.NudYear.Value = Mid(g_Kjqj, 1, 4)
        Me.NudMonth.Value = Mid(g_Kjqj, 5, 2)
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If Me.ChbSc.Checked Then
            '会计期起始日期
            Dim dateKsrq As Date = Now().Date
            '会计期终止日期
            Dim dateZzrq As Date = GetInvEnd(NudYear.Value, Me.NudMonth.Value)

            Dim strDwKjqj As String
            strDwKjqj = GetParaValue("发出商品启用会计期间", True)
            If String.IsNullOrEmpty(strDwKjqj) Then
                strDwKjqj = GetInvKjqj(g_Dwrq)
            End If

            dateKsrq = GetInvBegin(Mid(strDwKjqj, 1, 4), Mid(strDwKjqj, 5, 2))

            '取数据
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                rcOleDbCommand.CommandText = "SELECT ? AS cperiod,djh,xh,shkhdm,fpkhdm,bmdm,cpdm,SUM(sl) AS sl,SUM(je) AS je,SUM(se) AS se,SUM(cbje) AS cbje
  FROM ((SELECT vbillcode as djh,
                to_number(crowno) as xh,
                khdm AS shkhdm,
                fpkhdm as fpkhdm,
                bmdm,
                cpdm,
                SUM(sl) AS sl,
                SUM(je) AS je,
                SUM(se) AS se,
                SUM(cbje) AS cbje
           FROM oe_xsd
          WHERE bdelete = 0
            AND oe_xsd.vbillcode IS NOT NULL
            AND oe_xsd.je <>0 /*过滤掉全是0的数据*/
            AND xsrq >= ? /*发出商品启用时间*/
            AND xsrq <= ? /*销售出库结束时间*/
          GROUP BY vbillcode, crowno, khdm, fpkhdm, bmdm, cpdm) UNION ALL
        (SELECT xsddjh AS djh,
                xsdxh AS xh,
                shkhdm AS shkhdm,
                khdm as fpkhdm,
                bmdm,
                cpdm,
                SUM(0 - sl) AS sl,
                SUM(0 - je) AS je,
                SUM(0 - se) AS se,
                SUM(0 - cbje) AS cbje
           FROM oe_fp
          WHERE bdelete = 0
            AND fprq >= ? /*发出商品启用时间*/
            AND fprq <= ? /*销售发票开票结束时间*/
            AND EXISTS
          (SELECT 1
                   FROM oe_xsd s
                  WHERE s.bdelete = 0
                    AND xsrq >= ? /*发出商品启用时间*/
                    AND xsrq <= ? /*销售出库结束时间*/
                    AND s.vbillcode = oe_fp.xsddjh
                    AND s.crowno = oe_fp.xsdxh) /*销售发票在销售出库中存在才算*/
          GROUP BY xsddjh, xsdxh, shkhdm, khdm, bmdm, cpdm))
 GROUP BY djh, xh, shkhdm, fpkhdm, bmdm, cpdm
HAVING (SUM(sl) <> 0 OR SUM(je) > 0.1 OR SUM(je) < - 0.1) /*过滤掉全是0的数据*/"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@paraDateXsrq", OleDbType.Date, 8).Value = dateKsrq '/*发出商品启用时间*/
                rcOleDbCommand.Parameters.Add("@paraDateXsrq", OleDbType.Date, 8).Value = dateZzrq
                rcOleDbCommand.Parameters.Add("@paraDateFprq", OleDbType.Date, 8).Value = dateKsrq '/*发出商品启用时间*/
                rcOleDbCommand.Parameters.Add("@paraDateFprq", OleDbType.Date, 8).Value = dateZzrq
                rcOleDbCommand.Parameters.Add("@paraDateXsrq", OleDbType.Date, 8).Value = dateKsrq '/*发出商品启用时间*/
                rcOleDbCommand.Parameters.Add("@paraDateXsrq", OleDbType.Date, 8).Value = dateZzrq
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("fcsplb") IsNot Nothing Then
                    rcDataset.Tables("fcsplb").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "fcsplb")
            Catch ex As Exception
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("fcsplb").Rows.Count <= 0 Then
                MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
        Else
            '取数据
            Try
                rcOleDbConn.Open()
                rcOleDbCommand.Connection = rcOleDbConn
                rcOleDbCommand.CommandTimeout = 300
                rcOleDbCommand.CommandType = CommandType.Text
                If Not Me.CheckBox1.Checked Then
                    rcOleDbCommand.CommandText = "SELECT a.cperiod,a.ckkjqj,a.djh,a.xh,a.shkhdm,k.khmc as shkhmc,a.fpkhdm,h.khmc as fpkhmc,a.bmdm,b.bmmc,a.cpdm,c.cpmc,c.dw,a.sl,(a.sl * c.cpweight / 1000) AS fzsl,a.je,a.se,a.cbje FROM oe_xsd_fcsp a LEFT JOIN rc_khxx k ON k.khdm = a.shkhdm LEFT JOIN rc_khxx h ON h.khdm = a.fpkhdm LEFT JOIN rc_bmxx b ON b.bmdm = a.bmdm LEFT JOIN rc_cpxx c ON c.cpdm = a.cpdm WHERE a.cperiod = ?"
                Else
                    rcOleDbCommand.CommandText = "SELECT a.cperiod,a.bmdm,b.bmmc,a.sl,a.fzsl,a.je,a.se,a.cbje FROM (SELECT cperiod,bmdm,SUM(sl) AS sl,SUM(a.sl * c.cpweight /1000) AS fzsl,SUM(je) AS je,SUM(se) AS se,SUM(cbje) AS cbje FROM oe_xsd_fcsp a,rc_cpxx c WHERE a.cpdm = c.cpdm AND cperiod = ? GROUP BY cperiod,bmdm) a LEFT JOIN rc_bmxx b ON b.bmdm = a.bmdm"
                End If
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("cperiod", OleDbType.VarChar, 6).Value = Me.NudYear.Value.ToString & Me.NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
                If rcDataset.Tables("fcsplb") IsNot Nothing Then
                    rcDataset.Tables("fcsplb").Clear()
                End If
                rcOleDbDataAdpt.Fill(rcDataset, "fcsplb")
            Catch ex As Exception
                MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
                Return
            Finally
                rcOleDbConn.Close()
            End Try
            If rcDataset.Tables("fcsplb").Rows.Count <= 0 Then
                MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
                Return
            End If
        End If
        '添加合计行
        Dim rcRow As DataRow = rcDataset.Tables("fcsplb").NewRow
        If Me.CheckBox1.Checked Then
            rcRow("bmdm") = "合计"
        Else
            rcRow("cpdm") = "合计"
        End If
        rcRow("sl") = rcDataset.Tables("fcsplb").Compute("SUM(sl)", "TRUE")
        rcRow("fzsl") = rcDataset.Tables("fcsplb").Compute("SUM(fzsl)", "TRUE")
        rcRow("je") = rcDataset.Tables("fcsplb").Compute("SUM(je)", "TRUE")
        rcRow("se") = rcDataset.Tables("fcsplb").Compute("SUM(se)", "TRUE")
        rcRow("cbje") = rcDataset.Tables("fcsplb").Compute("SUM(cbje)", "TRUE")
        rcDataset.Tables("fcsplb").Rows.Add(rcRow)



        '调用表单
        Dim rcFrm As New FrmFcspCxz
        With rcFrm
            .ParaDataSet = rcDataset
            If Me.CheckBox1.Checked Then
                .ParaDataView = New DataView(rcDataset.Tables("fcsplb"), "TRUE", "cperiod,bmdm", DataViewRowState.CurrentRows)
            Else
                .ParaDataView = New DataView(rcDataset.Tables("fcsplb"), "TRUE", "cperiod,djh,xh,shkhdm,fpkhdm,bmdm,cpdm", DataViewRowState.CurrentRows)
            End If
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub

    Private Sub ChbSc_CheckedChanged(sender As Object, e As EventArgs) Handles ChbSc.CheckedChanged
        If Me.ChbSc.Checked Then
            Me.CheckBox1.Checked = False
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If Me.CheckBox1.Checked Then
            Me.ChbSc.Checked = False
        End If
    End Sub
End Class