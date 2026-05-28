Imports System.Data.OleDb

Public Class DynamicFormFactory

    Public Shared Function CreateForm(formName As String) As Form
        If String.IsNullOrEmpty(formName) Then
            Return Nothing
        End If

        Try
            Dim asm As Reflection.Assembly = Reflection.Assembly.GetExecutingAssembly()
            Dim formType As Type = Nothing

            formType = asm.GetType(formName, False, True)
            If formType Is Nothing Then
                formType = asm.GetType("rc3." & formName, False, True)
            End If
            If formType Is Nothing Then
                formType = asm.GetType("sys." & formName, False, True)
            End If

            If formType IsNot Nothing AndAlso GetType(Form).IsAssignableFrom(formType) Then
                Return CType(Activator.CreateInstance(formType), Form)
            End If

            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Function CreateFormWithParam(formName As String, ByVal createNew As Boolean) As Form
        Dim frm As Form = CreateForm(formName)
        If frm IsNot Nothing AndAlso createNew Then
            frm = CType(Activator.CreateInstance(frm.GetType()), Form)
        End If
        Return frm
    End Function

End Class