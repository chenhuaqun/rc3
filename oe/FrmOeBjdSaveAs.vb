Public Class FrmOeBjdSaveAs

    Private Sub BtnXzwj_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnXzwj.Click
        If Me.FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            Me.TxtFolderName.Text = Me.FolderBrowserDialog1.SelectedPath
        End If
    End Sub

End Class