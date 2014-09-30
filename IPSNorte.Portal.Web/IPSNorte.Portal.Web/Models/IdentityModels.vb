Imports System.Security.Claims
Imports System.Threading.Tasks
Imports IPSNorte.Portal.eXpertisObjects
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin

' You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
Public Class ApplicationUser
    Inherits IdentityUser
    Public Async Function GenerateUserIdentityAsync(manager As UserManager(Of ApplicationUser)) As Task(Of ClaimsIdentity)
        ' Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        Dim userIdentity = Await manager.CreateIdentityAsync(Me, DefaultAuthenticationTypes.ApplicationCookie)
        ' Add custom user claims here
        Return userIdentity
    End Function

    Public Shared Function FromServiceUser(user As User) As ApplicationUser
        Dim applicationUser = New ApplicationUser()

        If (IsNothing(user)) Then
            Return Nothing
        End If
        applicationUser.UserName = user.Email
        applicationUser.Email = user.Email
        applicationUser.FirstName = user.FirstName
        applicationUser.JobRole = user.Job
        applicationUser.LastName = user.LastName
        applicationUser.PasswordHash = user.Password
        applicationUser.PhoneNumber = user.Phone1
        applicationUser.PhoneNumber2 = user.Phone2
        applicationUser.ProjectNumber = user.ProjectNumber
        applicationUser.Company = user.CompanyName
        applicationUser.Id = user.Id
        applicationUser.AcceptCookies = user.AcceptCookies
        Return applicationUser
    End Function

    Public Function ToServiceUser() As User

        Dim user As User = New User()
        user.Email = Me.Email
        user.FirstName = Me.FirstName
        user.Job = Me.JobRole
        user.LastName = Me.LastName
        user.Password = Me.PasswordHash
        user.Phone1 = Me.PhoneNumber
        user.Phone2 = Me.PhoneNumber2
        user.ProjectNumber = Me.ProjectNumber
        user.CompanyName = Me.Company
        user.Id = Me.Id
        user.AcceptCookies = Me.AcceptCookies
        Return user

    End Function
    
    Public Property Company() As String

    Public Property ProjectNumber() As String

    Public Property PhoneNumber2() As String

    Public Property JobRole() As String
    
    Public Property LastName() As String
    
    Public Property FirstName() As String

    Public Property AcceptCookies() As Boolean

End Class

