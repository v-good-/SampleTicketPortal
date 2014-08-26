Public interface ITicketService
    ''' <summary>
    ''' Create a new ticket.
    ''' </summary>
    Sub CreateTicket(ticket As Ticket)

    ''' <summary>
    ''' Delete an existing ticket.
    ''' </summary>
    Sub DeleteTicket(ticket As Ticket)

    ''' <summary>
    ''' Get tickets.
    ''' </summary>
    Function GetTickets(rows As Integer, page As Integer, sidx As String, sord As String, searchString As String, ByVal searchTerms As SearchModel,
                        ByRef count As Integer) As ICollection(Of Ticket)

    ''' <summary>
    ''' Get all tickets.
    ''' </summary>
    Function GetTickets()
end interface