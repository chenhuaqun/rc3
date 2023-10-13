Imports System.Data.OleDb

Public Class FrmOeCpHzbz
    Dim dateBegin As Date
    Dim dateEnd As Date
    Dim blnCkd As Boolean
    Dim strBmdm As String

    Property ParaDateBegin() As Date
        Get
            ParaDateBegin = dateBegin
        End Get
        Set(ByVal value As Date)
            dateBegin = value
        End Set
    End Property

    Property ParaDateEnd() As Date
        Get
            ParaDateEnd = dateEnd
        End Get
        Set(ByVal value As Date)
            dateEnd = value
        End Set
    End Property

    Property ParaBlnCkd() As Boolean
        Get
            ParaBlnCkd = blnCkd
        End Get
        Set(ByVal value As Boolean)
            blnCkd = value
        End Set
    End Property

    Property ParaStrBmdm() As String
        Get
            ParaStrBmdm = strBmdm
        End Get
        Set(ByVal value As String)
            strBmdm = value
        End Set
    End Property

    Private Sub FrmOeCpHzbz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcSl.Format = g_FormatSl0
        Me.DgtbcFzsl.Format = g_FormatSl0
        Me.DgtbcJe.Format = g_FormatJe0
        Me.DgtbcSe.Format = g_FormatJe0
        Me.DgtbcCbje.Format = g_FormatJe0
        Me.DgtbcDj.Format = g_FormatDj0
        Me.DgtbcCbdj.Format = g_FormatDj0
        Me.DgtbcMle.Format = g_FormatJe0
        Me.DgtbcMll.Format = g_FormatPer
        rcDataGrid.SetDataBinding(rcDataView, "")
    End Sub

    Overrides Sub PageSetupEvent()
        Dim rcFrm As New models.FrmPageSetup
        With rcFrm
            .paraOleDbConn = rcOleDbConn
            .paraRpsId = "CKSFCHZ"
            .paraRpsName = "仓库收发存汇总表"
            .ShowDialog()
        End With
    End Sub

    Overrides Sub DataGridDoubleClick()
        OeXsdCx()
    End Sub

    Private Sub MnuiOeXsdcx_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuiOeXsdcx.Click
        OeXsdCx()
    End Sub

    Private Sub OeXsdCx()
        ''取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            If blnCkd Then
                rcOleDbCommand.CommandText = "(SELECT oe_xsd.djh,oe_xsd.xh,oe_xsd.xsrq,oe_xsd.bdelete,oe_xsd.zydm,oe_xsd.zymc,oe_xsd.khdm,oe_xsd.khmc,'' AS sktj,0 AS skqx,oe_xsd.bmdm,oe_xsd.bmmc,oe_xsd.ckdm,oe_xsd.ckmc,oe_xsd.cpdm,oe_xsd.cpmc,oe_xsd.hth,oe_xsd.khddh,oe_xsd.khlh,oe_xsd.sl,oe_xsd.fpsl,oe_xsd.sl - oe_xsd.fpsl AS wfp,oe_xsd.dw,oe_xsd.mjsl,oe_xsd.fzsl,oe_xsd.fzdw,oe_xsd.dj,oe_xsd.hsdj,oe_xsd.je,oe_xsd.shlv,oe_xsd.se,oe_xsd.je + oe_xsd.se AS jese,oe_xsd.cbje,oe_xsd.xsmemo,oe_xsd.dddjh,oe_xsd.ddxh,oe_xsd.skje,oe_xsd.bsign,oe_xsd.srr,oe_xsd.shr,oe_xsd.jzr FROM rc_cpxx,oe_xsd,rc_lx WHERE (" & strBmdm & ") AND oe_xsd.bdelete = 0 AND rc_cpxx.cpdm = oe_xsd.cpdm AND SUBSTR(oe_xsd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_xsd.djh,5,4) = rc_lx.kjnd AND rc_lx.lxgs = '产品送货单' AND TRUNC(oe_xsd.xsrq,'dd') >= ? AND TRUNC(oe_xsd.xsrq,'dd') <= ? AND oe_xsd.cpdm = ?)" & _
                    " UNION (SELECT inv_ckd.djh,inv_ckd.xh,inv_ckd.ckrq AS xsrq,inv_ckd.bdelete,inv_ckd.zydm,inv_ckd.zymc,'' AS khdm,'' AS khmc,'' AS sktj,0 AS skqx,inv_ckd.bmdm,inv_ckd.bmmc,inv_ckd.ckdm,inv_ckd.ckmc,inv_ckd.cpdm,inv_ckd.cpmc,'' AS hth,'' AS khddh,'' AS khlh,inv_ckd.sl,0 AS fpsl,0 AS wfp,inv_ckd.dw,inv_ckd.mjsl,inv_ckd.fzsl,inv_ckd.fzdw,inv_ckd.dj,0 AS hsdj,0 AS je,0 AS shlv,0 AS se,0 AS jese,inv_ckd.je AS cbje,inv_ckd.ckmemo AS xsmemo,'' AS dddjh,0 AS ddxh,0 AS skje,0 AS bsign,inv_ckd.srr,inv_ckd.shr,inv_ckd.jzr FROM inv_ckd WHERE SUBSTR(inv_ckd.djh,1,4) = 'CKTZ' AND inv_ckd.bdelete = 0 AND TRUNC(inv_ckd.ckrq,'dd') >= ? AND TRUNC(inv_ckd.ckrq,'dd') <= ? AND inv_ckd.cpdm = ?)"
            Else
                rcOleDbCommand.CommandText = "SELECT oe_xsd.djh,oe_xsd.xh,oe_xsd.xsrq,oe_xsd.bdelete,oe_xsd.zydm,oe_xsd.zymc,oe_xsd.khdm,oe_xsd.khmc,'' AS sktj,0 AS skqx,oe_xsd.bmdm,oe_xsd.bmmc,oe_xsd.ckdm,oe_xsd.ckmc,oe_xsd.cpdm,oe_xsd.cpmc,oe_xsd.hth,oe_xsd.khddh,oe_xsd.khlh,oe_xsd.sl,oe_xsd.fpsl,oe_xsd.sl - oe_xsd.fpsl AS wfp,oe_xsd.dw,oe_xsd.mjsl,oe_xsd.fzsl,oe_xsd.fzdw,oe_xsd.dj,oe_xsd.hsdj,oe_xsd.je,oe_xsd.shlv,oe_xsd.se,oe_xsd.je + oe_xsd.se AS jese,oe_xsd.cbje,oe_xsd.xsmemo,oe_xsd.dddjh,oe_xsd.ddxh,oe_xsd.skje,oe_xsd.bsign,oe_xsd.srr,oe_xsd.shr,oe_xsd.jzr FROM rc_cpxx,oe_xsd,rc_lx WHERE (" & strBmdm & ") AND rc_cpxx.cpdm = oe_xsd.cpdm AND SUBSTR(oe_xsd.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_xsd.djh,5,4) = rc_lx.kjnd AND rc_lx.lxgs = '产品送货单' AND TRUNC(oe_xsd.xsrq,'dd') >= ? AND TRUNC(oe_xsd.xsrq,'dd') <= ? AND oe_xsd.cpdm = ? ORDER BY oe_xsd.djh,oe_xsd.xh"
            End If
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@xsrq1", OleDbType.Date, 8).Value = dateBegin
            rcOleDbCommand.Parameters.Add("@xsrq2", OleDbType.Date, 8).Value = dateEnd
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("cpdm")
            If blnCkd Then
                rcOleDbCommand.Parameters.Add("@ckrq1", OleDbType.Date, 8).Value = dateBegin
                rcOleDbCommand.Parameters.Add("@ckrq1", OleDbType.Date, 8).Value = dateEnd
                rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataView.Item(rcDataGrid.CurrentRowIndex).Row.Item("cpdm")
            End If
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("xsdlb") IsNot Nothing Then
                rcDataSet.Tables("xsdlb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "xsdlb")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("xsdlb").Rows.Count <= 0 Then
            MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        Dim rcDataRow As DataRow
        rcDataRow = rcDataSet.Tables("xsdlb").NewRow
        rcDataRow.Item("djh") = "合计"
        rcDataRow.Item("sl") = rcDataSet.Tables("xsdlb").Compute("Sum(sl)", "")
        rcDataRow.Item("fzsl") = rcDataSet.Tables("xsdlb").Compute("Sum(fzsl)", "")
        rcDataRow.Item("je") = rcDataSet.Tables("xsdlb").Compute("Sum(je)", "")
        rcDataRow.Item("se") = rcDataSet.Tables("xsdlb").Compute("Sum(se)", "")
        rcDataRow.Item("jese") = rcDataSet.Tables("xsdlb").Compute("Sum(jese)", "")
        rcDataRow.Item("cbje") = rcDataSet.Tables("xsdlb").Compute("Sum(cbje)", "")
        rcDataRow.Item("skje") = rcDataSet.Tables("xsdlb").Compute("Sum(skje)", "")
        rcDataSet.Tables("xsdlb").Rows.Add(rcDataRow)
        '调用表单
        Dim rcFrm As New FrmOeXsdCxLb
        With rcFrm
            .ParaDataSet = rcDataSet
            .ParaDataView = New DataView(rcDataSet.Tables("xsdlb"), "TRUE", "djh,xh", DataViewRowState.CurrentRows)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class