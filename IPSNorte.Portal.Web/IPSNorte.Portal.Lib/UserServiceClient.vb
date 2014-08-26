﻿
Imports IPSNorte.Portal.eXpertisObjects

Public Class UserServiceClient

    Dim _userService As IUserService

    Public Sub New()
        
        _userService = New UserService()

    End Sub

    Public Function RegisterNewUser(user As User) As Boolean

        Return _userService.RegisterNewUser(user)

    End Function

    Public Function FindById(id As String) As User

        Return _userService.FindById(id)

    End Function

    Public Function FindByName(username As String) As User

        Return _userService.FindByName(username)

    End Function

    Public Sub Update(user As User)

        _userService.Update(user)

    End Sub

    Public Sub Delete(user As User)

        _userService.Delete(user)

    End Sub

    Public Function GetCurrentUser() As User
        Return _userService.GetCurrentUser()
    End Function

End Class
