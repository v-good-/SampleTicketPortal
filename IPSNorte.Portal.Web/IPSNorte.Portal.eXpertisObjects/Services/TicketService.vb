
Public Class TicketService
    Inherits MarshalByRefObject
    Implements ITicketService

    ReadOnly _tickets As List(Of Ticket) = New List(Of Ticket)()

    ''' <summary>
    ''' Create a new ticket.
    ''' </summary>
    Public Sub CreateTicket(ticket As Ticket) Implements ITicketService.CreateTicket

        ticket.Number = _tickets.Last().Number + 1
        _tickets.Add(ticket)

    End Sub

    ''' <summary>
    ''' Delete an existing ticket.
    ''' </summary>
    Public Sub DeleteTicket(ticket As Ticket) Implements ITicketService.DeleteTicket

        _tickets.Remove(ticket)

    End Sub

End Class
