Public Class Employee

    Sub New(ByVal name As String)
        nameValue = name
    End Sub

    Private nameValue As String
    Public Property Name() As String
        Get
            Return nameValue
        End Get
        Set(ByVal value As String)
            nameValue = value
        End Set
    End Property

    Public ReadOnly Property Self() As Employee
        Get
            Return Me
        End Get
    End Property

    Public Sub RequestStatus(ByVal taskID As Int32)
        MessageBox.Show(String.Format(
            "Status for task {0} has been requested from {1}.",
            taskID, nameValue), "Status Request")
    End Sub

End Class