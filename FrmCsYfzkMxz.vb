Public Class FrmCsYfzkMxz

    Private Sub FrmCsYfzkMxz_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DgtbcYsje.Format = g_FormatJe0
        Me.DgtbcSkje.Format = g_FormatJe0
        Me.DgtbcYe.Format = g_FormatJe0
        rcDataGrid.SetDataBinding(ParaDataView, "")
        'Dim i As Integer
        'Dim dblYe As Double = 0.0
        'For i = 0 To rcDataView.Table.Rows.Count - 1
        '    If rcDataView.Table.Rows(i).Item("zy").GetType.ToString <> "System.DBNull" Then
        '        Select Case rcDataView.Table.Rows(i).Item("zy")
        '            Case "�ڳ����"
        '                dblYe = rcDataView.Table.Rows(i).Item("ye")
        '            Case "���ºϼ�"
        '            Case "�����ۼ�"
        '            Case Else
        '                dblYe = dblYe + rcDataView.Table.Rows(i).Item("yfje") - rcDataView.Table.Rows(i).Item("fkje")
        '                rcDataView.Table.Rows(i).Item("ye") = dblYe
        '        End Select
        '    Else
        '        dblYe = dblYe + rcDataView.Table.Rows(i).Item("yfje") - rcDataView.Table.Rows(i).Item("fkje")
        '        rcDataView.Table.Rows(i).Item("ye") = dblYe
        '    End If
        'Next
    End Sub
End Class