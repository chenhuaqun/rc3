Public Class FrmYwfDkgsFilter
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

    Private Sub BtnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnOk.Click
        TxtDkgsdm.Text = TxtDkgsdm.Text.ToUpper
        TxtDkgsmc.Text = TxtDkgsmc.Text.ToUpper
        Select Case True
            Case Trim(TxtDkgsdm.Text).Length > 0
                rcDataView.RowFilter = "trim(dkgsdm) LIKE '" & TxtDkgsdm.Text & "%'"
            Case Trim(TxtDkgsmc.Text).Length > 0
                rcDataView.RowFilter = "trim(dkgsmc) LIKE '%" & TxtDkgsmc.Text & "%'"
            Case Else
                rcDataView.RowFilter = True
        End Select
    End Sub
End Class