Public Class FrmOeYpddSr

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NudYear.KeyPress, NudMonth.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
        End Select
    End Sub

    Private Sub NudYear_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles NudYear.KeyDown, NudMonth.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub FrmOeYpddSr_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.NudYear.Value = g_Kjrq.Year
        Me.NudMonth.Value = g_Kjrq.Month
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        '���ñ�
        Dim rcFrm As New FrmOeYpddSrz
        With rcFrm
            .ParaStrYear = NudYear.Value.ToString.PadLeft(4, "0")
            .ParaStrMonth = NudMonth.Value.ToString.PadLeft(2, "0")
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me.MdiParent
            .Show()
        End With
    End Sub
End Class