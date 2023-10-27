Imports System.Data.OleDb

Public Class FrmKhFilter
    '数据视图
    Dim rcDataView As DataView

    Public Property ParaDataView() As DataView
        Get
            ParaDataView = rcDataView
        End Get
        Set(ByVal Value As DataView)
            rcDataView = Value
        End Set
    End Property

#Region "控键回车键的处理"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKhdm.KeyPress, TxtKhmc.KeyPress, TxtZydm.KeyPress, TxtZymc.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Me.TxtKhdm.Text = Me.TxtKhdm.Text.ToUpper
        Me.TxtKhmc.Text = Me.TxtKhmc.Text.ToUpper
        Select Case True
            Case Trim(Me.TxtKhdm.Text).Length > 0
                rcDataView.RowFilter = "TRIM(khdm) LIKE '" & Replace(Me.TxtKhdm.Text, "*", "[*]") & "%'"
            Case Trim(Me.TxtKhmc.Text).Length > 0
                rcDataView.RowFilter = "TRIM(khmc) LIKE '%" & Replace(Me.TxtKhmc.Text, "*", "[*]") & "%'"
            Case Trim(Me.TxtZydm.Text).Length > 0
                rcDataView.RowFilter = "TRIM(zydm) LIKE '" & Replace(Me.TxtZydm.Text, "*", "[*]") & "%' AND NOT zydm IS NULL" & " OR TRIM(zydm2) LIKE '" & Replace(Me.TxtZydm.Text, "*", "[*]") & "%' AND NOT zydm2 IS NULL"
            Case Trim(Me.TxtZymc.Text).Length > 0
                rcDataView.RowFilter = "TRIM(zymc) LIKE '%" & Replace(Me.TxtZymc.Text, "*", "[*]") & "%' AND NOT zymc IS NULL" & " OR TRIM(zymc2) LIKE '%" & Replace(Me.TxtZymc.Text, "*", "[*]") & "%' AND NOT zymc2 IS NULL"
            Case Else
                rcDataView.RowFilter = True
        End Select
    End Sub

End Class