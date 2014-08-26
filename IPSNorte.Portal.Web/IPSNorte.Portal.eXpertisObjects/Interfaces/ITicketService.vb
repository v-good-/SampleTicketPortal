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

    Function GetTicketsPaged(ByVal size As Integer,
                                    ByVal page As Integer,
                                    ByVal orderBy As String,
                                    ByVal orderByDirection As String,
                                    ByVal searchString As String,
                                    ByVal searchTerms As SearchModel,
                                    ByRef total As Integer) As IList(Of Ticket)

End Interface