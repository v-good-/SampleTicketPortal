Imports System.ComponentModel.DataAnnotations
Imports IPSNorte.Portal.eXpertisObjects
Imports Microsoft.Ajax.Utilities

Public Class CreateTicketViewModel

    Public Sub New()
        CreatedDate = Now

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

    <Required(ErrorMessage:="Description is required")>
    Property Description() As String

    <Required(ErrorMessage:="Number is required")> 
    Property Number() As Integer


    <Required(ErrorMessage:="Project Number is required")>
    Property ProjectNumber() As String

    <Required(ErrorMessage:="Date is required")> 
    <DataType(DataType.Date)>
    Property CreatedDate() As DateTime

    Property Status() As TicketStatusEnum

    Property Priority() As TicketPriorityEnum

    Property StatusList As List(Of SelectListItem)

    Property PriorityList As List(Of SelectListItem)

    Property File As HttpPostedFileBase
End Class
