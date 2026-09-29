Public Class FrmAbout

    Private Sub FrmAbout_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Label4.Text = "软件版本号：" & System.Diagnostics.FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion.ToString
    End Sub

    Private Sub LblEmail_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblEmail.LinkClicked
        Try
            System.Diagnostics.Process.Start("mailto:chenhuaqun@qq.com")
        Catch ex As Exception
            ' The error message
            MessageBox.Show("Unable to open link that was clicked.")
        End Try
    End Sub

    Private Sub LblHomePage_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblHomePage.LinkClicked
        Try
            Dim rcPci As New System.Diagnostics.ProcessStartInfo(g_WebSite)
            rcPci.UseShellExecute = True
            System.Diagnostics.Process.Start(rcPci)
        Catch ex As Exception
            ' The error message
            MessageBox.Show("无法打开公司官网：" & g_WebSite & vbCrLf & ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub butInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butInfo.Click
        Try
            System.Diagnostics.Process.Start("MSInfo32.exe")
        Catch
        End Try
    End Sub

    Private Sub BtnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub
End Class