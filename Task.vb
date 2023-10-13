Public Class Task

    Sub New(ByVal id As Int32)
        idValue = id
    End Sub

    Sub New(ByVal id As Int32, ByVal assignedTo As Employee)
        idValue = id
        assignedToValue = assignedTo
    End Sub

    Private idValue As Int32
    Public Property Id() As Int32
        Get
            Return idValue
        End Get
        Set(ByVal value As Int32)
            idValue = value
        End Set
    End Property

    Private assignedToValue As Employee
    Public Property AssignedTo() As Employee
        Get
            Return assignedToValue
        End Get
        Set(ByVal value As Employee)
            assignedToValue = value
        End Set
    End Property

End Class