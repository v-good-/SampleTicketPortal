Imports System.ComponentModel.DataAnnotations
Imports IPSNorte.Portal.eXpertisObjects
Imports Microsoft.Ajax.Utilities
Imports IPSNorte.Portal.Web.Web.Resources

Public Class CreateTicketViewModel

    Public Sub New()
        
        PriorityList = New List(Of SelectListItem)
        StatusList = New List(Of SelectListItem)

        Dim values() As Integer = CType([Enum].GetValues(GetType(TicketPriorityEnum)), Integer())
        For Each value In values

            Dim item As New SelectListItem()
            item.Value = value
            item.Text = CType(value, TicketPriorityEnum).ToString()

            PriorityList.Add(item)
        Next

        values = CType([Enum].GetValues(GetType(TicketStatusEnum)), Integer())
        For Each value In values

            Dim item As New SelectListItem()
            item.Value = value
            item.Text = CType(value, TicketStatusEnum).ToString()

            StatusList.Add(item)
        Next

    End Sub

    <Required(ErrorMessageResourceType:=GetType(Resources), ErrorMessageResourceName:="CreateTicketViewModel_Description_Description_is_required")>
    Property Description() As String
    
    <Required(ErrorMessageResourceType:=GetType(Resources), ErrorMessageResourceName:="CreateTicketViewModel_ProjectNumber_Project_Number_is_required")>
    <Display(ResourceType:=GetType(Resources), Name:="CreateTicketViewModel_ProjectNumber")>
    Property ProjectNumber() As String

    <Display(ResourceType:=GetType(Resources), Name:="CreateTicketViewModel_Priority")>
    Property Priority() As TicketPriorityEnum

    Property StatusList As List(Of SelectListItem)

    Property PriorityList As List(Of SelectListItem)

    Property File As HttpPostedFileBase
End Class
