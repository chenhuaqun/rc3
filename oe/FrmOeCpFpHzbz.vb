Imports System.Data.OleDb

Public Class FrmOeCpFpHzbz
    Dim dateBegin As Date
    Dim dateEnd As Date
    'Dim strBmdm As String

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

    'Property ParaStrBmdm() As String
    '    Get
    '        ParaStrBmdm = strBmdm
    '    End Get
    '    Set(ByVal value As String)
    '        strBmdm = value
    '    End Set
    'End Property

    Private Sub FrmOeCpFpHzbz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcSl.Format = g_FormatSl0
        Me.DgtbcFzsl.Format = g_FormatSl0
        Me.DgtbcJe.Format = g_FormatJe0
        Me.DgtbcSe.Format = g_FormatJe0
        Me.DgtbcCbje.Format = g_FormatJe0
        Me.DgtbcDj.Format = g_FormatDj0
        Me.DgtbcCbdj.Format = g_FormatDj0
        Me.DgtbcMle.Format = g_FormatJe0
        Me.DgtbcMll.Format = g_FormatPer
        RcDataGrid.SetDataBinding(rcDataView, "")
    End Sub

    Overrides Sub PageSetupEvent()
        Dim rcFrm As New models.FrmPageSetup
        With rcFrm
            .ParaOleDbConn = rcOleDbConn
            .ParaRpsId = "CKSFCHZ"
            .ParaRpsName = "仓库收发存汇总表"
            .ShowDialog()
        End With
    End Sub

    Overrides Sub DataGridDoubleClick()
        OeFpCx()
    End Sub

    Private Sub MnuiOeFpcx_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuiOeFpCx.Click
        OeFpCx()
    End Sub

    Private Sub OeFpCx()
        ''取数据
        Try
            rcOleDbConn.Open()
            rcOleDbCommand.Connection = rcOleDbConn
            rcOleDbCommand.CommandTimeout = 300
            rcOleDbCommand.CommandType = CommandType.Text
            'rcOleDbCommand.CommandText = "SELECT oe_fp.djh,oe_fp.xh,oe_fp.fprq,oe_fp.bdelete,oe_fp.zydm,oe_fp.zymc,oe_fp.khdm,oe_fp.khmc,'' AS sktj,0 AS skqx,oe_fp.bmdm,oe_fp.bmmc,oe_fp.cpdm,oe_fp.cpmc,oe_fp.hth,oe_fp.sl,oe_fp.dw,oe_fp.mjsl,oe_fp.fzsl,oe_fp.fzdw,oe_fp.dj,oe_fp.hsdj,oe_fp.je,oe_fp.shlv,oe_fp.se,oe_fp.je + oe_fp.se AS jese,oe_fp.cbje,oe_fp.fpmemo,oe_fp.dddjh,oe_fp.ddxh,oe_fp.skje,oe_fp.bsign,oe_fp.srr,oe_fp.shr,oe_fp.jzr FROM rc_cpxx,oe_fp,rc_lx WHERE (" & strBmdm & ") AND rc_cpxx.cpdm = oe_fp.cpdm AND SUBSTR(oe_fp.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_fp.djh,5,4) = rc_lx.kjnd AND rc_lx.lxgs = '产品销售单' AND TRUNC(oe_fp.fprq,'dd') >= ? AND TRUNC(oe_fp.fprq,'dd') <= ? AND oe_fp.cpdm = ? ORDER BY oe_fp.djh,oe_fp.xh"
            rcOleDbCommand.CommandText = "SELECT oe_fp.djh,oe_fp.xh,oe_fp.fprq,oe_fp.bdelete,oe_fp.zydm,oe_fp.zymc,oe_fp.khdm,oe_fp.khmc,'' AS sktj,0 AS skqx,oe_fp.bmdm,oe_fp.bmmc,oe_fp.cpdm,oe_fp.cpmc,oe_fp.hth,oe_fp.sl,oe_fp.dw,oe_fp.mjsl,oe_fp.fzsl,oe_fp.fzdw,oe_fp.dj,oe_fp.hsdj,oe_fp.je,oe_fp.shlv,oe_fp.se,oe_fp.je + oe_fp.se AS jese,oe_fp.cbje,oe_fp.fpmemo,oe_fp.dddjh,oe_fp.ddxh,oe_fp.skje,oe_fp.bsign,oe_fp.srr,oe_fp.shr,oe_fp.jzr FROM rc_cpxx,oe_fp,rc_lx WHERE rc_cpxx.cpdm = oe_fp.cpdm AND SUBSTR(oe_fp.djh,1,4) = rc_lx.pzlxdm AND SUBSTR(oe_fp.djh,5,4) = rc_lx.kjnd AND rc_lx.lxgs = '产品销售单' AND TRUNC(oe_fp.fprq,'dd') >= ? AND TRUNC(oe_fp.fprq,'dd') <= ? AND oe_fp.cpdm = ? ORDER BY oe_fp.djh,oe_fp.xh"
            rcOleDbCommand.Parameters.Clear()
            rcOleDbCommand.Parameters.Add("@fprq1", OleDbType.Date, 8).Value = dateBegin
            rcOleDbCommand.Parameters.Add("@fprq2", OleDbType.Date, 8).Value = dateEnd
            rcOleDbCommand.Parameters.Add("@cpdm", OleDbType.VarChar, 15).Value = rcDataView.Item(RcDataGrid.CurrentRowIndex).Row.Item("cpdm")
            rcOleDbDataAdpt.SelectCommand = rcOleDbCommand
            If rcDataSet.Tables("fplb") IsNot Nothing Then
                rcDataSet.Tables("fplb").Clear()
            End If
            rcOleDbDataAdpt.Fill(rcDataSet, "fplb")
        Catch ex As Exception
            MsgBox("程序错误。" + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        Finally
            rcOleDbConn.Close()
        End Try
        If rcDataSet.Tables("fplb").Rows.Count <= 0 Then
            MsgBox("没有满足条件的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return
        End If
        Dim rcDataRow As DataRow
        rcDataRow = rcDataSet.Tables("fplb").NewRow
        rcDataRow.Item("djh") = "合计"
        rcDataRow.Item("sl") = rcDataSet.Tables("fplb").Compute("Sum(sl)", "")
        rcDataRow.Item("fzsl") = rcDataSet.Tables("fplb").Compute("Sum(fzsl)", "")
        rcDataRow.Item("je") = rcDataSet.Tables("fplb").Compute("Sum(je)", "")
        rcDataRow.Item("se") = rcDataSet.Tables("fplb").Compute("Sum(se)", "")
        rcDataRow.Item("jese") = rcDataSet.Tables("fplb").Compute("Sum(jese)", "")
        rcDataRow.Item("cbje") = rcDataSet.Tables("fplb").Compute("Sum(cbje)", "")
        rcDataRow.Item("skje") = rcDataSet.Tables("fplb").Compute("Sum(skje)", "")
        rcDataSet.Tables("fplb").Rows.Add(rcDataRow)
        '调用表单
        Dim rcFrm As New FrmOeFpCxLb
        With rcFrm
            .ParaDataSet = rcDataSet
            .ParaDataView = New DataView(rcDataSet.Tables("fplb"), "TRUE", "djh,xh", DataViewRowState.CurrentRows)
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class