Module MdlBindDropDownList
    '…Ë÷√∞Û∂®
    Friend Sub BindDropDownList(ByVal DropDownControl As ComboBox, ByVal DataTable As DataTable, ByVal ValueField As String, Optional ByVal DisplayField As String = "")
        If DropDownControl Is Nothing Then Return
        If DataTable Is Nothing Then Return
        If DisplayField = "" Then DisplayField = ValueField
        Try
            DropDownControl.DisplayMember = DataTable.Columns(DisplayField).ColumnName
            DropDownControl.ValueMember = DataTable.Columns(ValueField).ColumnName
            DropDownControl.DropDownStyle = ComboBoxStyle.DropDownList
            DropDownControl.DataSource = DataTable
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Module
