Imports System.Runtime.CompilerServices
Imports IPSNorte.Portal.eXpertisObjects

Module TicketExtension
    <Extension()> _
    Public Function ToTicketViewModel(ByVal tickets As ICollection(Of Ticket)) As ICollection(Of TicketViewModel)
        Dim ret As New List(Of TicketViewModel)

        For Each ticket As Ticket In tickets
            Dim model As New TicketViewModel
            model.ID = ticket.ID
            model.CreatedBy = ticket.CreatedBy.FirstName & " " & ticket.CreatedBy.LastName
            model.CreatedDate = ticket.CreatedDate
            model.Description = ticket.Description
            model.Number = ticket.Number
            model.ProjectNumber = ticket.ProjectNumber
            model.Priority = ticket.Priority.ToString()
            model.Status = ticket.Status.ToString()
            model.File = ticket.FileName
            ret.Add(model)
        Next

        Return ret
    End Function 
End Module
