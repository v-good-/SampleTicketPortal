Public Interface ITicketService
    ''' <summary>
    ''' Create a new ticket.
    ''' </summary>
    Sub CreateTicket(ticket As Ticket)

    ''' <summary>
    ''' Delete an existing ticket.
    ''' </summary>
    Sub DeleteTicket(ticket As Ticket)

    Function GetTickets() As IList(Of Ticket)

    Function GetTicketsPaged(size As Integer,
                               page As Integer,
                               orderBy As String,
                               orderByDirection As String,
                               searchString As String) As IList(Of Ticket)

End Interface