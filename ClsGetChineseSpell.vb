Imports System
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Public Class ClsGetChineseSpell

    Public Function GetSpell(ByVal cnChar As String) As String
        Dim sarr As Byte() = System.Text.Encoding.Default.GetBytes(cnChar)
        Dim len As Integer = sarr.Length
        If len > 1 Then
            'Dim unused(2) As Byte
            Dim array As Byte() = System.Text.Encoding.Default.GetBytes(cnChar)
            Dim area As Integer = CShort(array(0) - Asc(ControlChars.NullChar))
            Dim pos As Integer = CShort(array(1) - Asc(ControlChars.NullChar))
            Dim code As Integer = area * 256 + pos
            Dim getPyChar As String = "*"
            If code >= 45217 And code <= 45252 Then
                getPyChar = "A"
            End If
            If code >= 45253 And code <= 45760 Then
                getPyChar = "B"
            End If
            If code >= 45761 And code <= 46317 Then
                getPyChar = "C"
            End If
            If code >= 46318 And code <= 46825 Then
                getPyChar = "D"
            End If
            If code >= 46826 And code <= 47009 Then
                getPyChar = "E"
            End If
            If code >= 47010 And code <= 47296 Then
                getPyChar = "F"
            End If
            If code >= 47297 And code <= 47613 Then
                getPyChar = "G"
            End If
            If code >= 47614 And code <= 48118 Then
                getPyChar = "H"
            End If
            If code >= 48119 And code <= 49061 Then
                getPyChar = "J"
            End If
            If code >= 49062 And code <= 49323 Then
                getPyChar = "K"
            End If
            If code >= 49324 And code <= 49895 Then
                getPyChar = "L"
            End If
            If code >= 49896 And code <= 50370 Then
                getPyChar = "M"
            End If
            If code >= 50371 And code <= 50613 Then
                getPyChar = "N"
            End If
            If code >= 50614 And code <= 50621 Then
                getPyChar = "O"
            End If
            If code >= 50622 And code <= 50905 Then
                getPyChar = "P"
            End If
            If code >= 50906 And code <= 51386 Then
                getPyChar = "Q"
            End If
            If code >= 51387 And code <= 51445 Then
                getPyChar = "R"
            End If
            If code >= 51446 And code <= 52217 Then
                getPyChar = "S"
            End If
            If code >= 52218 And code <= 52697 Then
                getPyChar = "T"
            End If
            If code >= 52698 And code <= 52979 Then
                getPyChar = "W"
            End If
            If code >= 52980 And code <= 53688 Then
                getPyChar = "X"
            End If
            If code >= 53689 And code <= 54480 Then
                getPyChar = "Y"
            End If
            If code >= 54481 And code <= 55289 Then
                getPyChar = "Z"
            End If
            Return getPyChar
        Else
            Return cnChar
        End If
    End Function

    Public Function GetChineseSpell(ByVal strText As String) As String
        Dim strtemp As String = ""
        Dim strlen As Integer = strText.Length
        Dim i As Integer
        For i = 0 To strlen - 1
            strtemp += getSpell(strText.Substring(i, 1))
        Next i
        Return strtemp
    End Function

End Class
