Imports System.Data.OleDb


Public Class FrmFcspJz

    '建立数据适配器
    ReadOnly rcOleDbDataAdpt As New OleDbDataAdapter
    '建立DataSet对象
    ReadOnly rcDataset As New DataSet
    '数据更新传递
    Dim rcOleDbTrans As OleDbTransaction
    '建立OleDbCommand对象
    ReadOnly rcOleDbCommand As OleDbCommand = rcOleDbConn.CreateCommand()
    '会计期起始日期
    Dim dateKsrq As Date = Now().Date
    ''会计期终止日期
    'Dim dateZzrq As Date = Now().Date

    Private Sub FrmFcspJz_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim strDwKjqj As String

        strDwKjqj = GetParaValue("发出商品启用会计期间", True)
        If String.IsNullOrEmpty(strDwKjqj) Then
            strDwKjqj = GetInvKjqj(g_Dwrq)
        End If

        dateKsrq = GetInvBegin(Mid(strDwKjqj, 1, 4), Mid(strDwKjqj, 5, 2))

        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            rcOleDbCommand.CommandText = "SELECT ny,jzbz,invbegin,invend FROM rc_yj WHERE jzbz = 0 AND ny >= ? ORDER BY ny"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@ny", OleDbType.VarChar, 6).Value = strDwKjqj
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            rcDataset.Tables("rc_yj")?.Clear()
            rcOleDbDataAdpt.Fill(rcDataset, "rc_yj")
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataset.Tables("rc_yj").Rows.Count = 0 Then
            MsgBox("会计期间设置有错误，请检查。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        '默认值
        NudYear.Value = Mid(rcDataset.Tables("rc_yj").Rows(0).Item("ny"), 1, 4)
        NudMonth.Value = Mid(rcDataset.Tables("rc_yj").Rows(0).Item("ny"), 5, 2)
        'dateKsrq = rcDataset.Tables("rc_yj").Rows(0).Item("invbegin")
        'dateZzrq = rcDataset.Tables("rc_yj").Rows(0).Item("invend")

    End Sub

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NudYear.KeyPress, NudMonth.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

    Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click

        '变量赋值
        'Dim dInvBegin As Date = GetInvBegin(NudYear.Value, Me.NudMonth.Value)
        Dim dInvEnd As Date = GetInvEnd(NudYear.Value, Me.NudMonth.Value)

        rcOleDbConn.Open()
        rcOleDbTrans = rcOleDbConn.BeginTransaction(IsolationLevel.ReadCommitted)
        rcOleDbCommand.Connection = rcOleDbConn
        rcOleDbCommand.Transaction = rcOleDbTrans
        rcOleDbCommand.CommandTimeout = 300
        rcOleDbCommand.CommandType = CommandType.Text
        Try
            '删除历史保存的本月发出商品数据
            LblMsg.Text = "正在删除历史保存的本月发出商品数据，请稍候……"
            rcOleDbCommand.CommandText = "DELETE FROM oe_xsd_fcsp WHERE cperiod = ?"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            Application.DoEvents()
            '生成本月发出商品成本结转数据
            LblMsg.Text = "正在生成本月发出商品数据，请稍候……"
            If Me.ChbOeXsfp.Checked Then
                rcOleDbCommand.CommandText = "INSERT INTO oe_xsd_fcsp (cperiod,ckkjqj,djh,xh,shkhdm,fpkhdm,bmdm,cpdm,sl,je,se,cbje) (SELECT ? AS cperiod,SUBSTR(djh,3,6),
       djh,
       xh,
       shkhdm,
         fpkhdm,
       bmdm,
       cpdm,
       SUM(sl) AS sl,
       SUM(je) AS je,
       SUM(se) AS se,
       SUM(cbje) AS cbje
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
HAVING (SUM(sl) <> 0 OR SUM(je) > 0.1 OR SUM(je) < - 0.1) /*过滤掉全是0的数据*/)"
                rcOleDbCommand.Parameters.Clear()
                rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
                rcOleDbCommand.Parameters.Add("@paraDateXsrq", OleDbType.Date, 8).Value = dateKsrq '/*发出商品启用时间*/
                rcOleDbCommand.Parameters.Add("@paraDateXsrq", OleDbType.Date, 8).Value = dInvEnd
                rcOleDbCommand.Parameters.Add("@paraDateFprq", OleDbType.Date, 8).Value = dateKsrq '/*发出商品启用时间*/
                rcOleDbCommand.Parameters.Add("@paraDateFprq", OleDbType.Date, 8).Value = dInvEnd
                rcOleDbCommand.Parameters.Add("@paraDateXsrq", OleDbType.Date, 8).Value = dateKsrq '/*发出商品启用时间*/
                rcOleDbCommand.Parameters.Add("@paraDateXsrq", OleDbType.Date, 8).Value = dInvEnd
            Else

            End If
            rcOleDbCommand.ExecuteNonQuery()
            Application.DoEvents()
            '删除历史保存的本月发出商品数据
            LblMsg.Text = "正在删除合计数量为0的本月发出商品数据，请稍候……"
            rcOleDbCommand.CommandText = "DELETE FROM oe_xsd_fcsp WHERE cperiod = ? AND EXISTS (SELECT 1 FROM (SELECT shkhdm,fpkhdm,bmdm,cpdm,SUM(sl),SUM(je),SUM(se) FROM oe_xsd_fcsp WHERE cperiod = ? GROUP BY shkhdm,fpkhdm,bmdm,cpdm HAVING SUM(sl)=0 AND SUM(je)=0 AND SUM(se) = 0) temp WHERE oe_xsd_fcsp.shkhdm = temp.shkhdm AND oe_xsd_fcsp.fpkhdm = temp.fpkhdm AND oe_xsd_fcsp.bmdm = temp.bmdm AND oe_xsd_fcsp.cpdm = temp.cpdm)AND EXISTS (SELECT 1 FROM oe_fp temp2 WHERE substr(temp2.djh,5,6) = ? AND oe_xsd_fcsp.shkhdm = temp2.shkhdm AND oe_xsd_fcsp.fpkhdm = temp2.khdm AND oe_xsd_fcsp.bmdm = temp2.bmdm AND oe_xsd_fcsp.cpdm = temp2.cpdm)"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.Parameters.Add("@cperiod", OleDbType.VarChar, 6).Value = NudYear.Value & NudMonth.Value.ToString.PadLeft(2, "0")
            rcOleDbCommand.ExecuteNonQuery()
            Application.DoEvents()
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
        LblMsg.Text = "本月发出商品已生成。"
        MsgBox("本月发出商品已生成，请检查数据的正确性。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示信息")
        Me.Close()

    End Sub
End Class