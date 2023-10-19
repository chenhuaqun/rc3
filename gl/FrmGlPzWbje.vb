Public Class FrmGlPzWbje

#Region "限制只能输入数值"

    Public Sub CheckKeyPress(ByVal TargetTextBox As TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs, Optional ByVal Minus As Boolean = False, Optional ByVal DecimalCount As Integer = 0)
        Dim blnHandled As Boolean
        blnHandled = False
        Select Case Asc(e.KeyChar)
            Case Asc("-")                   '   负号：只能在最前头
                If Not (TargetTextBox.SelectionStart = 0 And Minus = True) Then blnHandled = True
            Case Asc(".")                   '   小数点：小数位数大于0；在字符串中没有“.”，且加了“.”后小数位能满足要求
                If DecimalCount <= 0 Then
                    blnHandled = True
                Else
                    If Not (InStr(TargetTextBox.Text, ".") = 0 And (Len(TargetTextBox.Text) - TargetTextBox.SelectionStart <= DecimalCount)) Then blnHandled = True
                End If
            Case 8, 13                      '   退格键，回车键
            Case Asc("0") To Asc("9")       '   0-9
                If InStr(TargetTextBox.Text, ".") > 0 Then
                    If TargetTextBox.SelectionStart > InStr(TargetTextBox.Text, ".") Then
                        '   当前字符位置在小数点后，则小数点后的字符数必须小于小数位
                        If Len(TargetTextBox.Text) - InStr(TargetTextBox.Text, ".") >= DecimalCount Then blnHandled = True
                    Else
                        '   当前字符位置在小数点前，则小数点后的字符数必须不大于小数位
                        If Len(TargetTextBox.Text) - InStr(TargetTextBox.Text, ".") >= DecimalCount Then blnHandled = True
                    End If
                End If
            Case Else
                blnHandled = True
        End Select
        e.Handled = blnHandled
    End Sub

#End Region

#Region "借贷的事件"

    Private Sub CmbJd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbJd.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub CmbJd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbJd.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "外币金额"

    Private Sub TxtWb_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtWb.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtWb_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtWb.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
        If sender.GetType.ToString = "System.Windows.Forms.TextBox" Then
            CheckKeyPress(sender, e, False, 2)
        End If
    End Sub

    Private Sub TxtWb_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtWb.Validating
        If Not String.IsNullOrEmpty(Me.TxtWb.Text) And Not String.IsNullOrEmpty(Me.TxtHl.Text) Then
            Me.TxtJe.Text = System.Math.Round(Me.TxtWb.Text * Me.TxtHl.Text, 2, MidpointRounding.AwayFromZero)
        End If
    End Sub

#End Region

#Region "汇率"

    Private Sub TxtHl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtHl.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtHl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtHl.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
        If sender.GetType.ToString = "System.Windows.Forms.TextBox" Then
            CheckKeyPress(sender, e, False, 6)
        End If
    End Sub

    Private Sub TxtHl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtHl.Validating
        If Not String.IsNullOrEmpty(Me.TxtWb.Text) And Not String.IsNullOrEmpty(Me.TxtHl.Text) Then
            Me.TxtJe.Text = System.Math.Round(Me.TxtWb.Text * Me.TxtHl.Text, 2, MidpointRounding.AwayFromZero)
        End If
    End Sub

#End Region

#Region "金额"

    Private Sub TxtJe_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtJe.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtJe_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtJe.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                '指示 KeyPress 事件已处理，去掉 Windows 缺省的叮当声。
                e.Handled = True
        End Select
        If sender.GetType.ToString = "System.Windows.Forms.TextBox" Then
            CheckKeyPress(sender, e, False, 2)
        End If
    End Sub

    Private Sub TxtJe_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtJe.Validating
        If Not String.IsNullOrEmpty(Me.TxtWb.Text) And Not String.IsNullOrEmpty(Me.TxtHl.Text) Then
            If Me.TxtWb.Text <> 0 Then
                Me.TxtHl.Text = System.Math.Round(Me.TxtJe.Text / Me.TxtWb.Text, 6, MidpointRounding.AwayFromZero)
            End If
        End If
    End Sub

#End Region
End Class
