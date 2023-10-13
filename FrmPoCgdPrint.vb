
Public Class FrmPoCgdPrint
    Dim blnHs As Boolean = False

    Public Property paraBlnHs() As Boolean
        Get
            paraBlnHs = blnHs
        End Get
        Set(ByVal Value As Boolean)
            blnHs = Value
        End Set
    End Property

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        blnHs = IIf(Me.RadioButton1.Checked, True, False)
    End Sub
End Class