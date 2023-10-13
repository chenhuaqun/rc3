Public Class FrmGlPzSlje

#Region "����ֻ��������ֵ"

    Public Sub CheckKeyPress(ByVal TargetTextBox As TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs, Optional ByVal Minus As Boolean = False, Optional ByVal DecimalCount As Integer = 0)
        Dim blnHandled As Boolean
        blnHandled = False
        Select Case Asc(e.KeyChar)
            Case Asc("-")                   '   ���ţ�ֻ������ǰͷ
                If Not (TargetTextBox.SelectionStart = 0 And Minus = True) Then blnHandled = True
            Case Asc(".")                   '   С���㣺С��λ������0�����ַ�����û�С�.�����Ҽ��ˡ�.����С��λ������Ҫ��
                If DecimalCount <= 0 Then
                    blnHandled = True
                Else
                    If Not (InStr(TargetTextBox.Text, ".") = 0 And (Len(TargetTextBox.Text) - TargetTextBox.SelectionStart <= DecimalCount)) Then blnHandled = True
                End If
            Case 8, 13                      '   �˸�����س���
            Case Asc("0") To Asc("9")       '   0-9
                If InStr(TargetTextBox.Text, ".") > 0 Then
                    If TargetTextBox.SelectionStart > InStr(TargetTextBox.Text, ".") Then
                        '   ��ǰ�ַ�λ����С�������С�������ַ�������С��С��λ
                        If Len(TargetTextBox.Text) - InStr(TargetTextBox.Text, ".") >= DecimalCount Then blnHandled = True
                    Else
                        '   ��ǰ�ַ�λ����С����ǰ����С�������ַ������벻����С��λ
                        If Len(TargetTextBox.Text) - InStr(TargetTextBox.Text, ".") >= DecimalCount Then blnHandled = True
                    End If
                End If
            Case Else
                blnHandled = True
        End Select
        e.Handled = blnHandled
    End Sub

#End Region

#Region "������¼�"

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
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "����"

    Private Sub TxtSl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSl.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtSl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSl.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
        End Select
        If sender.GetType.ToString = "System.Windows.Forms.TextBox" Then
            CheckKeyPress(sender, e, False, 2)
        End If
    End Sub

    Private Sub TxtSl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtSl.Validating
        If Not String.IsNullOrEmpty(Me.TxtSl.Text) And Not String.IsNullOrEmpty(Me.TxtDj.Text) Then
            Me.TxtJe.Text = System.Math.Round(Me.TxtSl.Text * Me.TxtDj.Text, 2, MidpointRounding.AwayFromZero)
        End If
    End Sub

#End Region

#Region "����"

    Private Sub TxtDj_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDj.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                SendKeys.Send("{TAB}")
            Case Keys.Up
                SendKeys.Send("+{TAB}")
        End Select
    End Sub

    Private Sub TxtDj_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDj.KeyPress
        Select Case e.KeyChar
            Case Chr(Keys.Return)
                SendKeys.Send("{TAB}")
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
        End Select
        If sender.GetType.ToString = "System.Windows.Forms.TextBox" Then
            CheckKeyPress(sender, e, False, 6)
        End If
    End Sub

    Private Sub TxtDj_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtDj.Validating
        If Not String.IsNullOrEmpty(Me.TxtSl.Text) And Not String.IsNullOrEmpty(Me.TxtDj.Text) Then
            Me.TxtJe.Text = System.Math.Round(Me.TxtSl.Text * Me.TxtDj.Text, 2, MidpointRounding.AwayFromZero)
        End If
    End Sub

#End Region

#Region "���"

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
                'ָʾ KeyPress �¼��Ѵ���ȥ�� Windows ȱʡ�Ķ�������
                e.Handled = True
        End Select
        If sender.GetType.ToString = "System.Windows.Forms.TextBox" Then
            CheckKeyPress(sender, e, False, 2)
        End If
    End Sub

    Private Sub TxtJe_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtJe.Validating
        If Not String.IsNullOrEmpty(Me.TxtSl.Text) And Not String.IsNullOrEmpty(Me.TxtDj.Text) Then
            If Me.TxtSl.Text <> 0 Then
                Me.TxtDj.Text = System.Math.Round(Me.TxtJe.Text / Me.TxtSl.Text, 6, MidpointRounding.AwayFromZero)
            End If
        End If
    End Sub

#End Region

End Class
