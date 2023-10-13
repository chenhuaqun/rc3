Imports System.Data.OleDb

Public Class FrmCpFilter
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

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCpdm.KeyPress, TxtCpmc.KeyPress, TxtOldCpdm.KeyPress, TxtKhdm.KeyPress, TxtKhmc.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        TxtCpdm.Text = TxtCpdm.Text.ToUpper
        TxtCpmc.Text = TxtCpmc.Text.ToUpper
        TxtKhdm.Text = TxtKhdm.Text.ToUpper
        TxtKhmc.Text = TxtKhmc.Text.ToUpper
        Select Case True
            Case Trim(Me.TxtCpdm.Text).Length > 0
                rcDataView.RowFilter = "TRIM(cpdm) LIKE '" & Replace(Me.TxtCpdm.Text, "*", "[*]") & "%'"
            Case Trim(Me.TxtCpmc.Text).Length > 0
                rcDataView.RowFilter = "TRIM(cpmc) LIKE '%" & Replace(Me.TxtCpmc.Text, "*", "[*]") & "%'"
            Case Trim(Me.TxtOldCpdm.Text).Length > 0
                rcDataView.RowFilter = "TRIM(oldcpdm) LIKE '%" & Replace(Me.TxtOldCpdm.Text, "*", "[*]") & "%'"
            Case Trim(Me.TxtKhdm.Text).Length > 0
                rcDataView.RowFilter = "TRIM(khdm) LIKE '" & Replace(Me.TxtKhdm.Text, "*", "[*]") & "%'"
            Case Trim(Me.TxtKhmc.Text).Length > 0
                rcDataView.RowFilter = "TRIM(khmc) LIKE '%" & Replace(Me.TxtKhmc.Text, "*", "[*]") & "%'"
            Case Else
                rcDataView.RowFilter = True
        End Select
    End Sub

End Class