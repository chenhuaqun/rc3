Imports System.Data.OleDb

Public Class FrmZyFilter
    '������ͼ
    Dim rcDataView As DataView

    Public Property ParaDataView() As DataView
        Get
            ParaDataView = rcDataView
        End Get
        Set(ByVal Value As DataView)
            rcDataView = Value
        End Set
    End Property

#Region "�ؼ��س����Ĵ���"

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtZydm.KeyPress, TxtZymc.KeyPress, TxtBmdm.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
        End Select
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        TxtZydm.Text = TxtZydm.Text.ToUpper
        TxtZymc.Text = TxtZymc.Text.ToUpper
        TxtBmdm.Text = TxtBmdm.Text.ToUpper
        Select Case True
            Case Trim(Me.TxtZydm.Text).Length > 0
                rcDataView.RowFilter = "TRIM(zydm) LIKE '" & Replace(Me.TxtZydm.Text, "*", "[*]") & "%'"
            Case Trim(Me.TxtZymc.Text).Length > 0
                rcDataView.RowFilter = "TRIM(zymc) LIKE '%" & Replace(Me.TxtZymc.Text, "*", "[*]") & "%'"
            Case Trim(Me.TxtBmdm.Text).Length > 0
                rcDataView.RowFilter = "TRIM(bmdm) LIKE '" & Replace(Me.TxtBmdm.Text, "*", "[*]") & "%'"
            Case Else
                rcDataView.RowFilter = True
        End Select
    End Sub

End Class