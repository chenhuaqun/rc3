Imports System.Data.OleDb
Public Class FrmKhshdzFilter
    'Êý¾ÝÊÓÍ¼
    Dim rcDataView As DataView

    Public Property ParaDataView() As DataView
        Get
            ParaDataView = rcDataView
        End Get
        Set(ByVal Value As DataView)
            rcDataView = Value
        End Set
    End Property

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        TxtKhdm.Text = TxtKhdm.Text.ToUpper
        TxtKhmc.Text = TxtKhmc.Text.ToUpper
        TxtZydm.Text = TxtZydm.Text.ToUpper
        Select Case True
            Case Trim(Me.TxtKhdm.Text).Length > 0
                rcDataView.RowFilter = "Trim(khdm) LIKE '" & Replace(Me.TxtKhdm.Text, "*", "[*]") & "%'"
            Case Trim(Me.TxtKhmc.Text).Length > 0
                rcDataView.RowFilter = "Trim(khmc) LIKE '%" & Replace(Me.TxtKhmc.Text, "*", "[*]") & "%'"
            Case Trim(Me.TxtZydm.Text).Length > 0
                rcDataView.RowFilter = "Trim(zydm) LIKE '%" & Replace(Me.TxtZydm.Text, "*", "[*]") & "%'"
            Case Trim(Me.TxtAddress.Text).Length > 0
                rcDataView.RowFilter = "Trim(address) LIKE '%" & Replace(Me.TxtAddress.Text, "*", "[*]") & "%'"
            Case Else
                rcDataView.RowFilter = True
        End Select
    End Sub

End Class