Imports System.ComponentModel.DataAnnotations
Imports IPSNorte.Portal.Web.Web.Resources

Public Class ExternalLoginConfirmationViewModel
    <Required>
    <EmailAddress> _
    <Display(ResourceType:=GetType(Resources), Name:="RegisterViewModel_Email_Email")>
    Public Property Email As String
End Class

Public Class ExternalLoginListViewModel
    Public Property Action As String
    Public Property ReturnUrl As String
End Class

Public Class ManageUserViewModel
    <Required>
    <DataType(DataType.Password)>
    <Display(ResourceType:=GetType(Resources), Name:="ManageUserViewModel_OldPassword_Current_password")>
    Public Property OldPassword As String

    <Required>
    <StringLength(100, ErrorMessageResourceType:=GetType(Resources), ErrorMessageResourceName:="RegisterViewModel_Password_The__0__must_be_at_least__2__characters_long_", MinimumLength:=6)>
    <DataType(DataType.Password)>
    <Display(ResourceType:=GetType(Resources), Name:="ManageUserViewModel_NewPassword_New_password")>
    Public Property NewPassword As String

    <DataType(DataType.Password)>
    <Display(ResourceType:=GetType(Resources), Name:="ManageUserViewModel_ConfirmPassword_Confirm_new_password")>
    <Compare("NewPassword", ErrorMessageResourceType:=GetType(Resources), ErrorMessageResourceName:="ManageUserViewModel_ConfirmPassword_The_new_password_and_confirmation_password_do_not_match_")>
    Public Property ConfirmPassword As String
End Class

Public Class LoginViewModel
    <Required>
    <EmailAddress> _
    <Display(ResourceType:=GetType(Resources), Name:="RegisterViewModel_Email_Email")>
    Public Property Email As String

    <Required>
    <DataType(DataType.Password)>
    <Display(ResourceType:=GetType(Resources), Name:="RegisterViewModel_Password_Password")>
    Public Property Password As String

    <Display(ResourceType:=GetType(Resources), Name:="LoginViewModel_RememberMe_Remember_me_")>
    Public Property RememberMe As Boolean
End Class

Public Class RegisterViewModel
    <Required>
    <EmailAddress> _
    <Display(ResourceType:=GetType(Resources), Name:="RegisterViewModel_Email_Email")>
    Public Property Email As String

    <Required>
    <StringLength(100, ErrorMessageResourceType:=GetType(Resources), ErrorMessageResourceName:="RegisterViewModel_Password_The__0__must_be_at_least__2__characters_long_", MinimumLength:=6)>
    <DataType(DataType.Password)>
    <Display(ResourceType:=GetType(Resources), Name:="RegisterViewModel_Password_Password")>
    Public Property Password As String

    <DataType(DataType.Password)>
    <Display(ResourceType:=GetType(Resources), Name:="RegisterViewModel_ConfirmPassword_Confirm_password")>
    <Compare("Password", ErrorMessageResourceType:=GetType(Resources), ErrorMessageResourceName:="RegisterViewModel_ConfirmPassword_The_password_and_confirmation_password_do_not_match_")>
    Public Property ConfirmPassword As String

    <Required>
    <Display(ResourceType:=GetType(Resources), Name:="RegisterViewModel_Phone1_Phone_number")>
    Public Property Phone1 As String

    <Display(ResourceType:=GetType(Resources), Name:="RegisterViewModel_Phone2_Mobile_phone_number")>
    Public Property Phone2 As String

    <Required>
    <Display(ResourceType:=GetType(Resources), Name:="RegisterViewModel_FirstName_First_Name")>
    Public Property FirstName As String

    <Required>
    <Display(ResourceType:=GetType(Resources), Name:="RegisterViewModel_LastName_Last_Name")>
    Public Property LastName As String

    <Required>
    <Display(ResourceType:=GetType(Resources), Name:="RegisterViewModel_JobRole_Job_role")>
    Public Property JobRole As String

    <Required>
    <Display(ResourceType:=GetType(Web.Resources.Resources), Name:="RegisterViewModel_Company_Company")>
    Public Property Company As String
    
    <Display(ResourceType:=GetType(Web.Resources.Resources), Name:="RegisterViewModel_ProjectNumber_Project_number")>
    Public Property ProjectNumber As String

End Class

Public Class ResetPasswordViewModel
    <Required> _
    <EmailAddress> _
    <Display(ResourceType:=GetType(Resources), Name:="RegisterViewModel_Email_Email")> _
    Public Property Email() As String

    <Required> _
    <StringLength(100, ErrorMessageResourceType:=GetType(Resources), ErrorMessageResourceName:="RegisterViewModel_Password_The__0__must_be_at_least__2__characters_long_", MinimumLength:=6)> _
    <DataType(DataType.Password)> _
    <Display(ResourceType:=GetType(Resources), Name:="RegisterViewModel_Password_Password")> _
    Public Property Password() As String

    <DataType(DataType.Password)> _
    <Display(ResourceType:=GetType(Resources), Name:="RegisterViewModel_ConfirmPassword_Confirm_password")> _
    <Compare("Password", ErrorMessageResourceType:=GetType(Resources), ErrorMessageResourceName:="RegisterViewModel_ConfirmPassword_The_password_and_confirmation_password_do_not_match_")> _
    Public Property ConfirmPassword() As String

    Public Property Code() As String
End Class

Public Class ForgotPasswordViewModel
    <Required> _
    <EmailAddress> _
    <Display(ResourceType:=GetType(Resources), Name:="RegisterViewModel_Email_Email")> _
    Public Property Email() As String
End Class
