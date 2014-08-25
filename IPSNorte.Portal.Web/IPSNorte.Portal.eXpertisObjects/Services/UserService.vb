
Imports System.Runtime.Remoting

Public Class UserService
    Inherits MarshalByRefObject
    Implements IUserService

    Shared ReadOnly _users As List(Of User) = New List(Of User)()

    Public Sub New()
        Console.WriteLine("user service instantiated..")

    End Sub
    Public Function RegisterNewUser(user As User) As Boolean Implements IUserService.RegisterNewUser

        If _users.Any(Function(usr) usr.Email = user.Email) Then
            Return False
        End If

        _users.Add(user)
        Return True

    End Function

    Public Function FindByName(ByVal username As String) As User Implements IUserService.FindByName

        Return _users.FirstOrDefault(Function(usr) usr.Email = username)

    End Function

    Public Function FindById(ByVal id As String) As User Implements IUserService.FindById

        Return _users.FirstOrDefault(Function(usr) usr.Id = id)

    End Function

    Public Sub IUserService_Update(ByVal user As User) Implements IUserService.Update
        IUserService_Delete(user)
        _users.Add(user)
    End Sub
    
    Public Sub IUserService_Delete(ByVal user As User) Implements IUserService.Delete
        If (Not IsNothing(FindById(user.Id))) Then
            _users.Remove(FindById(user.Id))
        End If
    End Sub

End Class
