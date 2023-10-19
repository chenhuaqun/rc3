Imports System.Data.OleDb

Public Class FrmCsFilter
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
        Select Case True
            Case Trim(TxtKhdm.Text).Length > 0
                rcDataView.RowFilter = "trim(csdm) LIKE '" & Replace(Me.TxtKhdm.Text, "*", "[*]") & "%'"
            Case Trim(TxtKhmc.Text).Length > 0
                rcDataView.RowFilter = "trim(csmc) LIKE '%" & Replace(Me.TxtKhmc.Text, "*", "[*]") & "%'"
            Case Else
                rcDataView.RowFilter = True
        End Select
    End Sub

End Class