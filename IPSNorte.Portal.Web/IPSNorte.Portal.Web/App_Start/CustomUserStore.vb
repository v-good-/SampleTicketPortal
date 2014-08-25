Imports IPSNorte.Portal.Lib
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports System.Threading.Tasks

Public Class CustomUserStore
    Implements IUserStore(Of ApplicationUser)
    Implements IUserPasswordStore(Of ApplicationUser)
    Implements IUserEmailStore(Of ApplicationUser)
    Implements IUserLoginStore(Of ApplicationUser)

    Dim _userServiceClient As UserServiceClient = New UserServiceClient()

    Public Sub Dispose() Implements IDisposable.Dispose

    End Sub

    Public Function CreateAsync(ByVal user As ApplicationUser) As Task Implements IUserStore(Of ApplicationUser, String).CreateAsync
        Return Task.Run(Function() _userServiceClient.RegisterNewUser(user.ToServiceUser()))
    End Function

    Public Function UpdateAsync(ByVal user As ApplicationUser) As Task Implements IUserStore(Of ApplicationUser, String).UpdateAsync
        _userServiceClient.Update(user.ToServiceUser())
        Return Task.FromResult(0)
    End Function

    Public Function DeleteAsync(ByVal user As ApplicationUser) As Task Implements IUserStore(Of ApplicationUser, String).DeleteAsync
        _userServiceClient.Delete(user.ToServiceUser())
        Return Task.FromResult(0)
    End Function

    Public Function FindByIdAsync(ByVal userId As String) As Task(Of ApplicationUser) Implements IUserStore(Of ApplicationUser, String).FindByIdAsync
        Return Task.Run(Of ApplicationUser)(Function() ApplicationUser.FromServiceUser(_userServiceClient.FindById(userId)))
    End Function

    Public Function FindByNameAsync(ByVal userName As String) As Task(Of ApplicationUser) Implements IUserStore(Of ApplicationUser, String).FindByNameAsync
        Return Task.Run(Of ApplicationUser)(Function() ApplicationUser.FromServiceUser(_userServiceClient.FindByName(userName)))
    End Function

    Public Function GetPasswordHashAsync(user As ApplicationUser) As Task(Of String) Implements IUserPasswordStore(Of ApplicationUser, String).GetPasswordHashAsync
        Return Task.Run(Of String)(Function() user.PasswordHash)
    End Function

    Public Function HasPasswordAsync(user As ApplicationUser) As Task(Of Boolean) Implements IUserPasswordStore(Of ApplicationUser, String).HasPasswordAsync
        Return Task.Run(Of Boolean)(Function() String.IsNullOrEmpty(user.PasswordHash))
    End Function

    Public Function SetPasswordHashAsync(user As ApplicationUser, passwordHash As String) As Task Implements IUserPasswordStore(Of ApplicationUser, String).SetPasswordHashAsync
        user.PasswordHash = passwordHash
        Return Task.FromResult(0)
    End Function

    Public Function FindByEmailAsync(email As String) As Task(Of ApplicationUser) Implements IUserEmailStore(Of ApplicationUser, String).FindByEmailAsync
        Return Task.Run(Of ApplicationUser)(Function() ApplicationUser.FromServiceUser(_userServiceClient.FindByName(email)))
    End Function

    Public Function GetEmailAsync(user As ApplicationUser) As Task(Of String) Implements IUserEmailStore(Of ApplicationUser, String).GetEmailAsync
        Return Task.Run(Of String)(Function() user.Email)
    End Function

    Public Function GetEmailConfirmedAsync(user As ApplicationUser) As Task(Of Boolean) Implements IUserEmailStore(Of ApplicationUser, String).GetEmailConfirmedAsync

        'we do not validate emails yet..
        Return Task.Run(Of Boolean)(Function() True)

    End Function

    Public Function SetEmailAsync(user As ApplicationUser, email As String) As Task Implements IUserEmailStore(Of ApplicationUser, String).SetEmailAsync
        user.Email = email
        Return task.FromResult(0)
    End Function

    Public Function SetEmailConfirmedAsync(user As ApplicationUser, confirmed As Boolean) As Task Implements IUserEmailStore(Of ApplicationUser, String).SetEmailConfirmedAsync
        Return task.FromResult(0)
    End Function

    Public Function AddLoginAsync(user As ApplicationUser, login As UserLoginInfo) As Task Implements IUserLoginStore(Of ApplicationUser, String).AddLoginAsync

    End Function

    Public Function FindAsync(login As UserLoginInfo) As Task(Of ApplicationUser) Implements IUserLoginStore(Of ApplicationUser, String).FindAsync

    End Function

    Public Function GetLoginsAsync(user As ApplicationUser) As Task(Of IList(Of UserLoginInfo)) Implements IUserLoginStore(Of ApplicationUser, String).GetLoginsAsync

        'IPSNorte will not support external logins for now.
        Return Task.FromResult(Of IList(Of UserLoginInfo))(New List(Of UserLoginInfo))
        
    End Function

    Public Function RemoveLoginAsync(user As ApplicationUser, login As UserLoginInfo) As Task Implements IUserLoginStore(Of ApplicationUser, String).RemoveLoginAsync
        'No-op
        Return Task.FromResult(0)
    End Function
End Class
