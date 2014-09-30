Imports System.ComponentModel.DataAnnotations
Imports IPSNorte.Portal.Web.Web.Resources

Public Class TicketCommentViewModel

    Property TicketId() As String

    <Required(ErrorMessageResourceType:=GetType(Resources), ErrorMessageResourceName:="CreateTicketViewModel_Description_Description_is_required")>
    Property Description() As String

    Property File As HttpPostedFileBase
End Class
