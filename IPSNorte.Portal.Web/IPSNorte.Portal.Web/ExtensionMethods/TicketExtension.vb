Imports System.Runtime.CompilerServices
Imports IPSNorte.Portal.eXpertisObjects
Imports Microsoft.Ajax.Utilities

Module TicketExtension
    <Extension()> _
    Public Function ToTicketViewModel(ByVal tickets As ICollection(Of Ticket)) As ICollection(Of TicketViewModel)

        Return (From ticket In tickets Select ToTicketViewModel(ticket)).ToList()

    End Function

    <Extension()> _
    Public Function ToTicketViewModel(ByVal ticket As Ticket) As TicketViewModel

        Dim model As New TicketViewModel

        If (IsNothing(ticket)) Then
            Return model
        End If

        model.ID = ticket.Id
        model.CreatedBy = ticket.CreatedBy.FirstName & " " & ticket.CreatedBy.LastName
        model.CreatedDate = ticket.CreatedDate
        model.Description = ticket.Description
        model.ProjectNumber = ticket.ProjectNumber
        model.Priority = ticket.Priority.ToString()
        model.Status = ticket.Status.ToString()
        model.File = ticket.FileName
        model.Number = ticket.Number

        model.Entries = New List(Of TicketEntryViewModel)()

        For Each ticketEntry As TicketEntry In ticket.Entries
            model.Entries.Add(New TicketEntryViewModel() With {
                              .Comment = ticketEntry.Comment,
                              .CreatedBy = ticketEntry.CreatedBy.FirstName & " " & ticketEntry.CreatedBy.LastName,
                              .CreatedDate = ticketEntry.CreatedDate,
                              .FileName = ticketEntry.FileName,
                              .FileId = ticketEntry.FileId,
                              .Id = ticketEntry.Id,
                              .TicketId = ticketEntry.TicketId})
        Next

        Return model

    End Function
End Module
