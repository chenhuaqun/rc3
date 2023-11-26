Public Class FrmKhYszkMxz

    Private Sub FrmKhYszkMxz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcYsje.Format = g_FormatJe0
        Me.DgtbcSkje.Format = g_FormatJe0
        Me.DgtbcYe.Format = g_FormatJe0
        rcDataGrid.SetDataBinding(ParaDataView, "")
        'Dim i As Integer
        'Dim dblYe As Double = 0.0
        'For i = 0 To ParaDataView.Table.Rows.Count - 1
        '    If ParaDataView.Table.Rows(i).Item("zy").GetType.ToString <> "System.DBNull" Then
        '        Select Case ParaDataView.Table.Rows(i).Item("zy")
        '            Case "期初结存"
        '                dblYe = ParaDataView.Table.Rows(i).Item("ye")
        '            Case "本月合计"
        '            Case "本年累计"
        '            Case Else
        '                dblYe = dblYe + ParaDataView.Table.Rows(i).Item("ysje") - ParaDataView.Table.Rows(i).Item("skje")
        '                ParaDataView.Table.Rows(i).Item("ye") = dblYe
        '        End Select
        '    Else
        '        dblYe = dblYe + ParaDataView.Table.Rows(i).Item("ysje") - ParaDataView.Table.Rows(i).Item("skje")
        '        ParaDataView.Table.Rows(i).Item("ye") = dblYe
        '    End If
        'Next
    End Sub
End Class