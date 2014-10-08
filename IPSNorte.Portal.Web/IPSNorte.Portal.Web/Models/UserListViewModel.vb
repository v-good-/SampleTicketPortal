Public Class UserViewModel

    Property FullName() As String

    Property Id() As String

    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        If ReferenceEquals(Nothing, obj) Then Return False
        If ReferenceEquals(Me, obj) Then Return True
        If obj.GetType IsNot Me.GetType Then Return False
        Return Equals(DirectCast(obj, UserViewModel))
    End Function

    Private Overloads Function Equals(ByVal other As UserViewModel) As Boolean
        Return String.Equals(Id, other.Id)
    End Function

    Public Overrides Function GetHashCode() As Integer
        If Id Is Nothing Then Return 0
        Return Id.GetHashCode
    End Function

    Public Shared Operator =(ByVal left As UserViewModel, ByVal right As UserViewModel) As Boolean
        Return Equals(left, right)
    End Operator

    Public Shared Operator <>(ByVal left As UserViewModel, ByVal right As UserViewModel) As Boolean
        Return Not Equals(left, right)
    End Operator
End Class
